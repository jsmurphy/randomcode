using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ReportImport
{
    public partial class FilePicker : Form
    {
        private readonly string _itemName;
        private readonly Guid _itemId;
        private readonly List<string> _targetFiles;

        public FilePicker(string ItemName, Guid ItemId, List<string> TargetFiles)
        {
            _itemName = ItemName;
            _itemId = ItemId;
            _targetFiles = TargetFiles;

            InitializeComponent();
        }

        private void PopulateListBox()
        {
            lbFiles.Items.Clear();

            foreach (var filePath in _targetFiles)
                lbFiles.Items.Add(filePath);
        }


        public string GetFile()
        {
            PopulateListBox();

            if (!string.IsNullOrEmpty(_itemName) && _itemId != Guid.Empty)
                tbDestinationInfo.Text += string.Format(" for {0} ({1})", _itemName, _itemId);

            ShowDialog();

            return (lbFiles.SelectedItem != null) ? lbFiles.SelectedItem.ToString() : String.Empty;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lbFiles_DoubleClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
