using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ReportImport
{
    public partial class MergeProgress : Form
    {
        public MergeProgress()
        {
            Visible = false;
            InitializeComponent();
            Instance = this;
        }

        public static MergeProgress Instance { get; private set; }

        public void LogMessage(string formatString, params object[] args)
        {
            var message = string.Format("[{0}] {1}", DateTime.Now, string.Format(formatString, args));

            Debug.WriteLine(message);

            lbMergeProgress.Items.Add(message);
            lbMergeProgress.SelectedIndex = lbMergeProgress.Items.Count - 1;
            Update();

        }

        public static void Clear()
        {
            Instance.lbMergeProgress.Items.Clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Visible = false;
        }
    }
}
