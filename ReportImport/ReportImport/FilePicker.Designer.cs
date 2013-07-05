using System.Drawing;

namespace ReportImport
{
    partial class FilePicker
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
            this.lbFiles = new System.Windows.Forms.ListBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.tbDestinationInfo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbFiles
            // 
            this.lbFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFiles.FormattingEnabled = true;
            this.lbFiles.Location = new System.Drawing.Point(18, 53);
            this.lbFiles.Name = "lbFiles";
            this.lbFiles.Size = new System.Drawing.Size(622, 173);
            this.lbFiles.TabIndex = 0;
            this.lbFiles.DoubleClick += new System.EventHandler(this.lbFiles_DoubleClick);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.Location = new System.Drawing.Point(293, 244);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(70, 25);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tbDestinationInfo
            // 
            this.tbDestinationInfo.BackColor = this.BackColor;
            this.tbDestinationInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbDestinationInfo.Location = new System.Drawing.Point(15, 18);
            this.tbDestinationInfo.Name = "tbDestinationInfo";
            this.tbDestinationInfo.ReadOnly = true;
            this.tbDestinationInfo.Size = new System.Drawing.Size(580, 13);
            this.tbDestinationInfo.TabIndex = 4;
            this.tbDestinationInfo.TabStop = false;
            this.tbDestinationInfo.Text = "Pick a Destination Xml File";
            // 
            // FilePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 281);
            this.Controls.Add(this.tbDestinationInfo);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lbFiles);
            this.Name = "FilePicker";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "FilePicker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbFiles;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox tbDestinationInfo;
    }
}