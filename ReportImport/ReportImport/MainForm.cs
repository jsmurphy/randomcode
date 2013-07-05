using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ReportImport
{
    public partial class MainForm : Form
    {
        private readonly List<string> sourceDirectories;
        internal static MergeProgress MergeProgress;

        public MainForm()
        {
            InitializeComponent();
            MergeProgress = new MergeProgress();

            sourceDirectories = new List<string>
                {
                    @"C:\Development\Arellia\AMS\Arellia.AMS.CoreProduct\Configuration\AMSCore\Folders",
                    @"C:\Development\Arellia\AMS\Arellia.AMS.CoreProduct\Configuration\AMSCore\Templates",
                    @"C:\Development\Arellia\AMS\Arellia.AMS.CoreProduct\Configuration\ArelliaCommon",
                    @"C:\Development\Arellia\AMS\Arellia.AMS.CoreProduct\Configuration\ArelliaReport",
                    @"C:\Development\Arellia\Solutions\ApplicationControl\Arellia.Ams.ApplicationControl\Configuration",
                    @"C:\Development\Arellia\Solutions\ApplicationControl\Arellia.Ams.ApplicationControl\Configuration\Report",
                    @"C:\Development\Arellia\Solutions\FileInventory\Arellia.Ams.FileInventory\Configuration",
                    @"C:\Development\Arellia\Solutions\FileInventory\Arellia.Ams.FileInventory\Configuration\Report",
                    @"C:\Development\Arellia\Solutions\LocalSecurity\Arellia.Ams.LocalSecurity\Configuration",
                    @"C:\Development\Arellia\Solutions\LocalSecurity\Arellia.Ams.LocalSecurity\Configuration\Report"
                };

            lbSourceDirectories.DataSource = sourceDirectories;
            tbChanges.Text = @"\\jm-ams\c$\Users\JMurphy\Desktop\InProgress";
        }

        private static void PerformMerge(List<string> SolutionDirectories, string ChangesDirectory, bool TestRun, bool CreateXml)
        {
            var changedItems = 0;

            foreach (var changeFile in Directory.GetFiles(ChangesDirectory, "*.xml"))
            {
                var fileName = Path.GetFileName(changeFile);
                if (fileName != null && fileName.Equals("ImportMe.xml"))
                    continue;

                try
                {
                    var changedItem = new ChangedItem();
                    changedItem.LoadItemXml(changeFile);

                    if (!changedItem.PerformMerge(SolutionDirectories, TestRun, CreateXml))
                    {
                        MergeProgress.Instance.LogMessage("Cancelling merge");
                        return;
                    }
                    changedItems++;
                }
                catch (Exception ex)
                {
                    //ignore and continue with the next file
                    MergeProgress.Instance.LogMessage("Exception Merging {0} - {1}", changeFile, ex.Message);
                }
            }

            if (CreateXml)
            {
                MergeProgress.Instance.LogMessage("Wrote {0} items to {1}", changedItems, Path.Combine(ChangesDirectory, "ImportMe.xml"));
                return;
            }

            MergeProgress.Instance.LogMessage("Finished processing {0} items", changedItems);
        }

        private void btnMerge_Click(object sender, EventArgs e)
        {
            var xmlPath = Path.Combine(tbChanges.Text, "ImportMe.xml");
            if (File.Exists(xmlPath))
                File.Delete(xmlPath);

            MergeProgress.Clear();
            MergeProgress.Visible = true;
            PerformMerge(sourceDirectories, tbChanges.Text, cbTestRun.Checked, cbCreateXml.Checked);
        }
    }
}
