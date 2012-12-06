using System;
using System.Data;
using System.IO;
using System.Text;
using Microsoft.Win32;

namespace SIMClear
{
    
    public class MsiProductDataTable : DataTable
    {
        DataColumn _dcMsiProductCode = new DataColumn("MsiProductCode", typeof(Guid));
        DataColumn _dcName = new DataColumn("Name", typeof(string));
        DataColumn _dcCompany = new DataColumn("Company", typeof(string));
        DataColumn _dcSystem = new DataColumn("System", typeof(bool));
        DataColumn _dcInstallLocation = new DataColumn("InstallLocation", typeof(string));
        DataColumn _dcInstallSource = new DataColumn("InstallSource", typeof(string));
        DataColumn _dcModifyPath = new DataColumn("ModifyPath", typeof(string));
        DataColumn _dcUninstallString = new DataColumn("UninstallString", typeof(string));
        DataColumn _dcLocalPackage = new DataColumn("LocalPackage", typeof(string));
        //DataColumn _dcVersionMajor = new DataColumn("VersionMajor", typeof(int));
        //DataColumn _dcVersionMinor = new DataColumn("VersionMinor", typeof(int));
        //DataColumn _dcVersionBuild = new DataColumn("VersionBuild", typeof(int));
        //DataColumn _dcVersionRevision = new DataColumn("VersionRevision", typeof(int));
        DataColumn _dcVersion = new DataColumn("Version", typeof(Version));
        DataColumn _dcProductConfig = new DataColumn("ProductConfig", typeof(string));

        public MsiProductDataTable()
        {
            this.TableName = "MsiProducts";
            Columns.AddRange(new DataColumn[] {_dcMsiProductCode,_dcName,_dcCompany, _dcSystem, _dcInstallLocation, _dcInstallSource,
                _dcModifyPath, _dcUninstallString, _dcLocalPackage, 
                /*_dcVersionMajor, _dcVersionMinor, _dcVersionBuild, _dcVersionRevision, */
                _dcVersion, _dcProductConfig});
        }

        public static Guid ConvertGuidHexString(string strGuid)
        {
            int nByteLen = strGuid.Length / 2;
            var baGuid = new byte[nByteLen];

            for (int i = 0; i < nByteLen; i++)
            {
                baGuid[i] = Convert.ToByte(strGuid.Substring(i * 2, 2), 16);
            }

            return new Guid(baGuid);
        }


        public void AddMsiProduct(String productSubKey, RegistryKey regProps)
        {
            DataRow drNew = this.NewRow();

            drNew[this._dcMsiProductCode] = ConvertGuidHexString(productSubKey);
            drNew[this._dcName] = regProps.GetValue("DisplayName");
            drNew[this._dcCompany] = regProps.GetValue("Publisher");
            drNew[this._dcUninstallString] = regProps.GetValue("UninstallString");
            drNew[this._dcInstallLocation] = (string)regProps.GetValue("InstallLocation");
            drNew[this._dcInstallSource] = (string)regProps.GetValue("InstallSource");
            drNew[this._dcSystem] = false;

            if (regProps.GetValue("SystemComponent") != null)
            {
                drNew[this._dcSystem] = ((int)regProps.GetValue("SystemComponent") != 0);
            }

            drNew[_dcModifyPath] = regProps.GetValue("ModifyPath");
            drNew[_dcUninstallString] = regProps.GetValue("UninstallString");
            drNew[_dcLocalPackage] = regProps.GetValue("LocalPackage");

            drNew[_dcProductConfig] = LookupProperty((string)regProps.GetValue("LocalPackage"), "ProductConfigFile");
            //string strProductUpdateConfig = LookupProperty((string)regProps.GetValue("LocalPackage"), "ProductConfigUpdateFile");

            var  uintVersion = (UInt32)(int)regProps.GetValue("Version");
            //drNew[_dcVersionMajor] = (int)((uintVersion & 0xFF000000) >> 24);
            //drNew[_dcVersionMinor] = (int)((uintVersion & 0x00FF0000) >> 16);
            //drNew[_dcVersionBuild] = (int)((uintVersion & 0x0000FF00) >> 8);
            //drNew[_dcVersionRevision] = (int)(uintVersion & 0xFF);

            drNew[_dcVersion] = new Version((int)((uintVersion & 0xFF000000) >> 24),
                (int)((uintVersion & 0x00FF0000) >> 16),
                (int)((uintVersion & 0x0000FF00) >> 8),
                (int)(uintVersion & 0xFF));

            this.Rows.Add(drNew);
        }

        /// <summary>
        /// Reads a Property and returns it as a string from the specified MSI
        /// </summary>
        /// <param name="inputFile"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        private static string LookupProperty(string inputFile, string property)
        {
            IntPtr phDatabase = IntPtr.Zero;
            IntPtr phView = IntPtr.Zero;
            IntPtr phRecord = IntPtr.Zero;

            StringBuilder szValueBuf = new StringBuilder();
            int pcchValueBuf = 4096;

            if (!File.Exists(inputFile))
                return String.Empty;

            try
            {
                uint val = NativeMethods.MsiOpenDatabase(inputFile, IntPtr.Zero, out phDatabase);
                phRecord = NativeMethods.MsiCreateRecord(1);

                String sql = String.Format("SELECT Value FROM Property WHERE Property = '{0}'", property);

                if (NativeMethods.MsiDatabaseOpenViewW(phDatabase, sql, out phView) != 0)
                    return String.Empty;

                if (NativeMethods.MsiViewExecute(phView, phRecord) != 0)
                    return String.Empty;

                if (NativeMethods.MsiViewFetch(phView, out phRecord) != 0)
                    return String.Empty;

                NativeMethods.MsiRecordGetString(phRecord, 1, szValueBuf, ref pcchValueBuf);
            }
            finally
            {
                if (phRecord != IntPtr.Zero)
                    NativeMethods.MsiCloseHandle(phRecord);
                if (phView != IntPtr.Zero)
                    NativeMethods.MsiCloseHandle(phView);
                if (phDatabase != IntPtr.Zero)
                    NativeMethods.MsiCloseHandle(phDatabase);
            }

            return szValueBuf.ToString();
        }

        public void LoadMsiProducts()
        {
            this.BeginLoadData();
            this.Rows.Clear();

            using (RegistryKey baseKey = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64))
            using (RegistryKey regProducts = baseKey.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Installer\\UserData\\S-1-5-18\\Products", false))
            {
                if (regProducts != null)
                {
                    foreach (string strSubkey in regProducts.GetSubKeyNames())
                    {
                        var openSubKey = regProducts.OpenSubKey(strSubkey);
                        if (openSubKey == null) 
                            continue;
                        var regProps = openSubKey.OpenSubKey("InstallProperties", true);
                        if (regProps == null) 
                            continue;

                        var strPublisher = regProps.GetValue("Publisher") as String;
                        if (string.IsNullOrEmpty(strPublisher)) 
                            continue;

                        if ((strPublisher.Contains("Altiris")) || (strPublisher.Contains("Symantec")) || (strPublisher.Contains("Arellia")))
                        {
                            AddMsiProduct(strSubkey, regProps);
                        }
                    }
                }

                this.EndLoadData();
            }
        }
    }

    public class MsiProductDataSet : DataSet
    {
        MsiProductDataTable _dtProduct = new MsiProductDataTable();
        public MsiProductDataTable MsiProductTable { get { return _dtProduct; } }

        public MsiProductDataSet()
        {
            this.Tables.Add(_dtProduct);
            _dtProduct.LoadMsiProducts();
        }
    }
}
