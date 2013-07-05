using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ReportImport
{
    public partial class XmlViewer : Form
    {
        public XmlViewer(ChangedItem changedItem)
        {
            InitializeComponent();

            if (!string.IsNullOrEmpty(changedItem.ItemName) && (changedItem.ItemId != Guid.Empty))
                Text = string.Format("XmlViewer - {0} ({1})", changedItem.ItemName, changedItem.ItemId);

            var xDocument = XDocument.Parse(changedItem.Xml.OuterXml);
            rtbXmlViewer.Text = xDocument.ToString();
        }

        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
