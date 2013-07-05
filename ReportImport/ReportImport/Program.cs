using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;

namespace ReportImport
{
    static class Program
    {
        static public Dictionary<string, string> FileOverrides { get; private set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SetupFileOverrides();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        private static void SetupFileOverrides()
        {
            FileOverrides = new Dictionary<string, string>
                {
                    {
                        @"Arellia.Ams.LocalSecurity\Configuration\Report\SmpImported\Reports.xml",
                        @"Arellia.Ams.LocalSecurity\Configuration\Report\DefaultReports.xml"
                    },
                    {
                        @"Arellia.Ams.LocalSecurity\Configuration\Report\SmpImported\Reports_raw.xml",
                        @"Arellia.Ams.LocalSecurity\Configuration\Report\DefaultReports_raw.xml"
                    },
                    {
                        @"Arellia.Ams.LocalSecurity\Configuration\Report\SmpImported\Reports_rt.xml",
                        @"Arellia.Ams.LocalSecurity\Configuration\Report\DefaultReports_rt.xml"
                    },
                    {
                        @"Arellia.Ams.LocalSecurity\Configuration\Report\SmpImported\Reports_sql.xml",
                        @"Arellia.Ams.LocalSecurity\Configuration\Report\DefaultReports_sql.xml"
                    }
                };
        }

        public static XmlNamespaceManager CreateNsMgrForDocument(XmlDocument sourceDocument)
        {
            var nsMgr = new XmlNamespaceManager(sourceDocument.NameTable);
            nsMgr.AddNamespace("adc", "http://schemas.arellia.com/dc/");
            nsMgr.AddNamespace("arr", "http://schemas.microsoft.com/2003/10/Serialization/Arrays");
            nsMgr.AddNamespace("i", "http://www.w3.org/2001/XMLSchema-instance");

            var attrNode = sourceDocument.SelectSingleNode("/*");
            if (attrNode != null && attrNode.Attributes != null)
            {
                foreach (XmlAttribute attr in attrNode.Attributes)
                {
                    if (attr.Name != "xmlns") 
                        continue;
                    nsMgr.AddNamespace("default", attr.Value);
                    break;
                }
            }
            return nsMgr;
        }
    }
}
