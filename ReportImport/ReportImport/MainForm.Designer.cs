namespace ReportImport
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnMerge = new System.Windows.Forms.Button();
            this.lblSource = new System.Windows.Forms.Label();
            this.lblChanges = new System.Windows.Forms.Label();
            this.tbChanges = new System.Windows.Forms.TextBox();
            this.lbSourceDirectories = new System.Windows.Forms.ListBox();
            this.cbTestRun = new System.Windows.Forms.CheckBox();
            this.cbCreateXml = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnMerge
            // 
            this.btnMerge.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnMerge.Location = new System.Drawing.Point(357, 222);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(75, 29);
            this.btnMerge.TabIndex = 0;
            this.btnMerge.Text = "Merge";
            this.btnMerge.UseVisualStyleBackColor = true;
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Location = new System.Drawing.Point(25, 24);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(94, 13);
            this.lblSource.TabIndex = 1;
            this.lblSource.Text = "Source Directories";
            // 
            // lblChanges
            // 
            this.lblChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblChanges.AutoSize = true;
            this.lblChanges.Location = new System.Drawing.Point(25, 192);
            this.lblChanges.Name = "lblChanges";
            this.lblChanges.Size = new System.Drawing.Size(94, 13);
            this.lblChanges.TabIndex = 5;
            this.lblChanges.Text = "Changes Directory";
            // 
            // tbChanges
            // 
            this.tbChanges.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbChanges.Location = new System.Drawing.Point(145, 185);
            this.tbChanges.Name = "tbChanges";
            this.tbChanges.Size = new System.Drawing.Size(555, 20);
            this.tbChanges.TabIndex = 6;
            // 
            // lbSourceDirectories
            // 
            this.lbSourceDirectories.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSourceDirectories.FormattingEnabled = true;
            this.lbSourceDirectories.Location = new System.Drawing.Point(145, 26);
            this.lbSourceDirectories.Name = "lbSourceDirectories";
            this.lbSourceDirectories.Size = new System.Drawing.Size(554, 134);
            this.lbSourceDirectories.TabIndex = 7;
            // 
            // cbTestRun
            // 
            this.cbTestRun.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cbTestRun.AutoSize = true;
            this.cbTestRun.Location = new System.Drawing.Point(493, 229);
            this.cbTestRun.Name = "cbTestRun";
            this.cbTestRun.Size = new System.Drawing.Size(169, 17);
            this.cbTestRun.TabIndex = 8;
            this.cbTestRun.Text = "Test Run (no changes written)";
            this.cbTestRun.UseVisualStyleBackColor = true;
            // 
            // cbCreateXml
            // 
            this.cbCreateXml.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cbCreateXml.AutoSize = true;
            this.cbCreateXml.Location = new System.Drawing.Point(181, 229);
            this.cbCreateXml.Name = "cbCreateXml";
            this.cbCreateXml.Size = new System.Drawing.Size(124, 17);
            this.cbCreateXml.TabIndex = 9;
            this.cbCreateXml.Text = "Create Xml for Import";
            this.cbCreateXml.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 269);
            this.Controls.Add(this.cbCreateXml);
            this.Controls.Add(this.cbTestRun);
            this.Controls.Add(this.lbSourceDirectories);
            this.Controls.Add(this.tbChanges);
            this.Controls.Add(this.lblChanges);
            this.Controls.Add(this.lblSource);
            this.Controls.Add(this.btnMerge);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Ams Report Importer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMerge;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.Label lblChanges;
        private System.Windows.Forms.TextBox tbChanges;
        private System.Windows.Forms.ListBox lbSourceDirectories;
        private System.Windows.Forms.CheckBox cbTestRun;
        private System.Windows.Forms.CheckBox cbCreateXml;
    }
}

