using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Xml;

using Microsoft.Win32;

namespace SIMClear
{
    public partial class Form1 : Form
    {
        MsiProductDataSet MsiProductDataSet { get { return this.DataViewManager.DataSet as MsiProductDataSet; } }
        DataViewManager DataViewManager { get { return this.dsMsiProducts.List as DataViewManager; } }

        protected String m_NSInstallPath;
        protected String m_SIMInstallPath;

        public Form1()
        {
            GetInstallPaths();
            InitializeComponent();

            if (String.IsNullOrEmpty(m_NSInstallPath))
            {
                btnReconfigure.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                var drMsiRow = ((DataRowView)row.DataBoundItem).Row;

                string strParams;

                if (!drMsiRow.IsNull("UninstallString"))
                {
                    var strUninstall = (string)drMsiRow["UninstallString"];
                    if (strUninstall.Contains("/I"))
                    {
                        strUninstall = strUninstall.Replace("/I", "/X");
                    }
                    strParams = strUninstall.Substring(strUninstall.IndexOf("/X"));
                }
                else
                {
                    strParams = "/X" + ((Guid)drMsiRow[0]).ToString("b");
                }

                var psInfo = new System.Diagnostics.ProcessStartInfo("msiexec.exe", strParams + " /passive RUNBYAIM=1 ")
                    {
                        UseShellExecute = false
                    };
                System.Diagnostics.Process procUninstall = System.Diagnostics.Process.Start(psInfo);
                procUninstall.WaitForExit();

                if (procUninstall.ExitCode != 0)
                {
                    string strResult = string.Format("Process exited with Exitcode {0}", procUninstall.ExitCode);

                }
            }

            this.MsiProductDataSet.MsiProductTable.LoadMsiProducts();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnPurgeArellia_Click(object sender, EventArgs e)
        {
            CleanInstallHistory(Program.PurgeLevel.History);
        }

        private void btnPurgeAllArellia_Click(object sender, EventArgs e)
        {
            CleanInstallHistory(Program.PurgeLevel.All);
        }

        private void chkShowAdvanced_CheckedChanged(object sender, EventArgs e)
        {
            ShowAdvancedColumns(((CheckBox)sender).Checked);
        }

        private void btnReconfigure_Click(object sender, EventArgs e)
        {
            string strAeXConfigPath = Path.Combine(m_NSInstallPath, "Bin") + "\\AeXConfig.exe";

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                DataRow drMsiRow = ((DataRowView)row.DataBoundItem).Row;

                if (!drMsiRow.IsNull("InstallLocation") && !drMsiRow.IsNull("ProductConfig") &&
                    !String.IsNullOrEmpty((string)drMsiRow["InstallLocation"]) &&
                    !String.IsNullOrEmpty((string)drMsiRow["ProductConfig"]))
                {
                    // Hardcoded to use <ProductInstallDir>\Config\<ProductConfigFile>
                    string strCommandLine = "/configure \"" + Path.Combine((string)drMsiRow["InstallLocation"], "Config\\" + drMsiRow["ProductConfig"]) + "\"";

                    var psInfo = new System.Diagnostics.ProcessStartInfo(strAeXConfigPath, strCommandLine)
                        {
                            UseShellExecute = false,
                            WindowStyle = System.Diagnostics.ProcessWindowStyle.Minimized
                        };
                    System.Diagnostics.Process procUninstall = System.Diagnostics.Process.Start(psInfo);
                    procUninstall.WaitForExit();
                }
            }
        }

        /// <summary>
        /// Clean up InstallHistoryPL.xml
        /// </summary>
        /// <param name="purgeLevel"></param>
        private void CleanInstallHistory(Program.PurgeLevel purgeLevel)
        {
            string strPath = Path.Combine(m_SIMInstallPath, "InstallHistoryPL.Xml");
            if (!File.Exists(strPath))
            {
                MessageBox.Show("Unable to load InstallHistoryPL.Xml", "Error loading XML");
                return;
            }

            if (purgeLevel == Program.PurgeLevel.All)
            {
                if (System.Windows.Forms.DialogResult.Cancel == MessageBox.Show("Are you sure you wish to remove ALL traces of Arellia from the SIM installation history?", 
                    "Confirmation",
                    MessageBoxButtons.OKCancel))
                    return;
            }

            XmlDocument docHistory = new XmlDocument();
            docHistory.Load(strPath);

            int nArelliaProducts = 0;
            int nArelliaProductsPurged = 0;

            var nodeProducts = docHistory.DocumentElement.SelectSingleNode("//ProductListing/products");
            var productVersionLookup = new Dictionary<Guid, Version>();

            // 1st pass to determine highest installed version of all Arellia products
            foreach (XmlNode nodeProduct in nodeProducts.SelectNodes("product"))
            {
                XmlElement eleProduct = nodeProduct as XmlElement;
                if (eleProduct == null)
                    continue;

                try
                {
                    string strProduct = eleProduct.GetAttribute("definitionName");
                    if (strProduct.Contains("Arellia"))
                    {
                        nArelliaProducts++;

                        switch (purgeLevel)
                        {
                            case Program.PurgeLevel.All:
                                nodeProducts.RemoveChild(nodeProduct);
                                continue;

                            case Program.PurgeLevel.History:
                                Version verProduct = new Version(int.Parse(eleProduct.GetAttribute("majorVersion")),
                                                                    int.Parse(eleProduct.GetAttribute("minorVersion")),
                                                                    int.Parse(eleProduct.GetAttribute("buildVersion")));

                                Guid productGuid = new Guid(eleProduct.SelectSingleNode("productGuid").InnerText);

                                if (!productVersionLookup.ContainsKey(productGuid))
                                {
                                    productVersionLookup.Add(productGuid, verProduct);
                                }
                                else if (verProduct > productVersionLookup[productGuid])
                                {
                                    productVersionLookup[productGuid] = verProduct;
                                }
                                break;

                        }
                    }
                }
                catch
                {
                    // unable to determine product details, skip this node
                }
            }

            string strStatusMsg = string.Format("{0}\nRemoved {1} Arellia Products", 
                Path.GetFileName(strPath), nArelliaProducts);

            // If we are purging everything except the highest version 
            // we run a 2nd pass to remove all Arellia products that are not the highest version
            if (purgeLevel == Program.PurgeLevel.History)
            {
                foreach (XmlNode nodeProduct in nodeProducts.SelectNodes("product"))
                {
                    XmlElement eleProduct = nodeProduct as XmlElement;
                    if (eleProduct == null)
                        continue;

                    try
                    {
                        string strProduct = eleProduct.GetAttribute("definitionName");
                        if (strProduct.Contains("Arellia"))
                        {
                            Version verProduct = new Version(int.Parse(eleProduct.GetAttribute("majorVersion")),
                                int.Parse(eleProduct.GetAttribute("minorVersion")),
                                int.Parse(eleProduct.GetAttribute("buildVersion")));

                            var productGuid = new Guid(eleProduct.SelectSingleNode("productGuid").InnerText);

                            if (verProduct != productVersionLookup[productGuid])
                            {
                                nodeProducts.RemoveChild(nodeProduct);
                                nArelliaProductsPurged++;
                            }
                        }
                    }
                    catch
                    {
                        // unable to determine product details, skip this node
                        continue;
                    }
                }
                strStatusMsg = string.Format("{0}\nDiscovered {1} Arellia Products\nRemoved {2} products that do not match highest installed version",
                    Path.GetFileName(strPath), nArelliaProducts, nArelliaProductsPurged);
            }

            docHistory.Save(strPath);

            MessageBox.Show(strStatusMsg, "Finished");
        }

        private void ShowAdvancedColumns(bool bShowAdvanced)
        {
            dataGridView1.Columns[msiProductCodeDataGridViewTextBoxColumn.Name].Visible = bShowAdvanced;
            dataGridView1.Columns[installSourceDataGridViewTextBoxColumn.Name].Visible = bShowAdvanced;
            dataGridView1.Columns[modifyPathDataGridViewTextBoxColumn.Name].Visible = bShowAdvanced;
            dataGridView1.Columns[uninstallStringDataGridViewTextBoxColumn.Name].Visible = bShowAdvanced;
            dataGridView1.Columns[localPackageDataGridViewTextBoxColumn.Name].Visible = bShowAdvanced;

            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {

            ShowAdvancedColumns(false);
            dataGridView1.Sort(dataGridView1.Columns[nameDataGridViewTextBoxColumn.Name], ListSortDirection.Ascending);
        }

        /// <summary>
        /// Gets install paths for NS and SIM.
        /// </summary>
        private void GetInstallPaths()
        {
            using (var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
            {
                using (var registryKey = baseKey.OpenSubKey("SOFTWARE\\Altiris\\eXpress\\Notification Server"))
                {
                    if (registryKey != null) m_NSInstallPath = (string)registryKey.GetValue("InstallPath");
                }

                if (String.IsNullOrEmpty(m_NSInstallPath))
                {
                    MessageBox.Show(string.Format("Unable to determine where NS is installed, reconfigure will be disabled"), "Cannot find NS installation directory");
                    //Environment.Exit(-1);
                }

                using (RegistryKey registryKey = baseKey.OpenSubKey("SOFTWARE\\Altiris\\AIM"))
                {
                    if (registryKey != null) m_SIMInstallPath = (string)registryKey.GetValue("InstallDir");
                }

                if (String.IsNullOrEmpty(m_SIMInstallPath))
                {
                    MessageBox.Show(string.Format("Unable to determine where SIM is installed"), "Error");
                    Environment.Exit(-1);
                }
            }
        }
    }
}
