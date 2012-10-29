namespace CheckElevation
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
            this.lbInAdminGroupText = new System.Windows.Forms.Label();
            this.lblElevatedText = new System.Windows.Forms.Label();
            this.lblIntegrityText = new System.Windows.Forms.Label();
            this.lbIntegrityLevel = new System.Windows.Forms.Label();
            this.lbIsRunAsAdminText = new System.Windows.Forms.Label();
            this.lbIsElevated = new System.Windows.Forms.Label();
            this.lbIsRunAsAdmin = new System.Windows.Forms.Label();
            this.lbInAdminGroup = new System.Windows.Forms.Label();
            this.lbLUAEnabledText = new System.Windows.Forms.Label();
            this.lbLUAEnabled = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbInAdminGroupText
            // 
            this.lbInAdminGroupText.AutoSize = true;
            this.lbInAdminGroupText.Location = new System.Drawing.Point(29, 46);
            this.lbInAdminGroupText.Name = "lbInAdminGroupText";
            this.lbInAdminGroupText.Size = new System.Drawing.Size(182, 13);
            this.lbInAdminGroupText.TabIndex = 0;
            this.lbInAdminGroupText.Text = "Process token in Administrator group:";
            // 
            // lblElevatedText
            // 
            this.lblElevatedText.AutoSize = true;
            this.lblElevatedText.Location = new System.Drawing.Point(29, 102);
            this.lblElevatedText.Name = "lblElevatedText";
            this.lblElevatedText.Size = new System.Drawing.Size(95, 13);
            this.lblElevatedText.TabIndex = 1;
            this.lblElevatedText.Text = "Running Elevated:";
            // 
            // lblIntegrityText
            // 
            this.lblIntegrityText.AutoSize = true;
            this.lblIntegrityText.Location = new System.Drawing.Point(29, 130);
            this.lblIntegrityText.Name = "lblIntegrityText";
            this.lblIntegrityText.Size = new System.Drawing.Size(72, 13);
            this.lblIntegrityText.TabIndex = 2;
            this.lblIntegrityText.Text = "Integrity level:";
            // 
            // lbIntegrityLevel
            // 
            this.lbIntegrityLevel.AutoSize = true;
            this.lbIntegrityLevel.Location = new System.Drawing.Point(240, 130);
            this.lbIntegrityLevel.Name = "lbIntegrityLevel";
            this.lbIntegrityLevel.Size = new System.Drawing.Size(63, 13);
            this.lbIntegrityLevel.TabIndex = 3;
            this.lbIntegrityLevel.Text = "<unknown>";
            // 
            // lbIsRunAsAdminText
            // 
            this.lbIsRunAsAdminText.AutoSize = true;
            this.lbIsRunAsAdminText.Location = new System.Drawing.Point(29, 74);
            this.lbIsRunAsAdminText.Name = "lbIsRunAsAdminText";
            this.lbIsRunAsAdminText.Size = new System.Drawing.Size(143, 13);
            this.lbIsRunAsAdminText.TabIndex = 4;
            this.lbIsRunAsAdminText.Text = "Process run as Administrator:";
            // 
            // lbIsElevated
            // 
            this.lbIsElevated.AutoSize = true;
            this.lbIsElevated.Location = new System.Drawing.Point(240, 102);
            this.lbIsElevated.Name = "lbIsElevated";
            this.lbIsElevated.Size = new System.Drawing.Size(63, 13);
            this.lbIsElevated.TabIndex = 5;
            this.lbIsElevated.Text = "<unknown>";
            // 
            // lbIsRunAsAdmin
            // 
            this.lbIsRunAsAdmin.AutoSize = true;
            this.lbIsRunAsAdmin.Location = new System.Drawing.Point(240, 74);
            this.lbIsRunAsAdmin.Name = "lbIsRunAsAdmin";
            this.lbIsRunAsAdmin.Size = new System.Drawing.Size(63, 13);
            this.lbIsRunAsAdmin.TabIndex = 6;
            this.lbIsRunAsAdmin.Text = "<unknown>";
            // 
            // lbInAdminGroup
            // 
            this.lbInAdminGroup.AutoSize = true;
            this.lbInAdminGroup.Location = new System.Drawing.Point(240, 46);
            this.lbInAdminGroup.Name = "lbInAdminGroup";
            this.lbInAdminGroup.Size = new System.Drawing.Size(63, 13);
            this.lbInAdminGroup.TabIndex = 7;
            this.lbInAdminGroup.Text = "<unknown>";
            // 
            // lbLUAEnabledText
            // 
            this.lbLUAEnabledText.AutoSize = true;
            this.lbLUAEnabledText.Location = new System.Drawing.Point(29, 18);
            this.lbLUAEnabledText.Name = "lbLUAEnabledText";
            this.lbLUAEnabledText.Size = new System.Drawing.Size(106, 13);
            this.lbLUAEnabledText.TabIndex = 8;
            this.lbLUAEnabledText.Text = "User Access Control:";
            // 
            // lbLUAEnabled
            // 
            this.lbLUAEnabled.AutoSize = true;
            this.lbLUAEnabled.Location = new System.Drawing.Point(240, 18);
            this.lbLUAEnabled.Name = "lbLUAEnabled";
            this.lbLUAEnabled.Size = new System.Drawing.Size(63, 13);
            this.lbLUAEnabled.TabIndex = 9;
            this.lbLUAEnabled.Text = "<unknown>";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(134, 154);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 24);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 190);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lbLUAEnabled);
            this.Controls.Add(this.lbLUAEnabledText);
            this.Controls.Add(this.lbInAdminGroup);
            this.Controls.Add(this.lbIsRunAsAdmin);
            this.Controls.Add(this.lbIsElevated);
            this.Controls.Add(this.lbIsRunAsAdminText);
            this.Controls.Add(this.lbIntegrityLevel);
            this.Controls.Add(this.lblIntegrityText);
            this.Controls.Add(this.lblElevatedText);
            this.Controls.Add(this.lbInAdminGroupText);
            this.Name = "MainForm";
            this.Text = "CheckElevation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbInAdminGroupText;
        private System.Windows.Forms.Label lblElevatedText;
        private System.Windows.Forms.Label lblIntegrityText;
        private System.Windows.Forms.Label lbIntegrityLevel;
        private System.Windows.Forms.Label lbIsRunAsAdminText;
        private System.Windows.Forms.Label lbIsElevated;
        private System.Windows.Forms.Label lbIsRunAsAdmin;
        private System.Windows.Forms.Label lbInAdminGroup;
        private System.Windows.Forms.Label lbLUAEnabledText;
        private System.Windows.Forms.Label lbLUAEnabled;
        private System.Windows.Forms.Button btnExit;

    }
}

