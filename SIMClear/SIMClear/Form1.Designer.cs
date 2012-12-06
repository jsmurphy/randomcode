namespace SIMClear
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnPurgeArellia = new System.Windows.Forms.Button();
            this.btnPurgeAllArellia = new System.Windows.Forms.Button();
            this.chkShowAdvanced = new System.Windows.Forms.CheckBox();
            this.btnReconfigure = new System.Windows.Forms.Button();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.msiProductCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.installSourceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modifyPathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uninstallStringDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localPackageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productConfigDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsMsiProducts = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMsiProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(57, 14);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(246, 27);
            this.button2.TabIndex = 1;
            this.button2.Text = "Uninstall Selected Component(s)";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.msiProductCodeDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn4,
            this.installSourceDataGridViewTextBoxColumn,
            this.modifyPathDataGridViewTextBoxColumn,
            this.uninstallStringDataGridViewTextBoxColumn,
            this.localPackageDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn13,
            this.productConfigDataGridViewTextBoxColumn});
            this.dataGridView1.DataMember = "MsiProducts";
            this.dataGridView1.DataSource = this.dsMsiProducts;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(14, 97);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1123, 569);
            this.dataGridView1.TabIndex = 2;
            // 
            // btnPurgeArellia
            // 
            this.btnPurgeArellia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPurgeArellia.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPurgeArellia.Location = new System.Drawing.Point(837, 12);
            this.btnPurgeArellia.Name = "btnPurgeArellia";
            this.btnPurgeArellia.Size = new System.Drawing.Size(251, 27);
            this.btnPurgeArellia.TabIndex = 3;
            this.btnPurgeArellia.Text = "Purge Old Arellia Install History";
            this.btnPurgeArellia.UseVisualStyleBackColor = true;
            this.btnPurgeArellia.Click += new System.EventHandler(this.btnPurgeArellia_Click);
            // 
            // btnPurgeAllArellia
            // 
            this.btnPurgeAllArellia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPurgeAllArellia.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPurgeAllArellia.Location = new System.Drawing.Point(837, 52);
            this.btnPurgeAllArellia.Name = "btnPurgeAllArellia";
            this.btnPurgeAllArellia.Size = new System.Drawing.Size(251, 29);
            this.btnPurgeAllArellia.TabIndex = 4;
            this.btnPurgeAllArellia.Text = "Purge ALL Arellia Products from SIM";
            this.btnPurgeAllArellia.UseVisualStyleBackColor = true;
            this.btnPurgeAllArellia.Click += new System.EventHandler(this.btnPurgeAllArellia_Click);
            // 
            // chkShowAdvanced
            // 
            this.chkShowAdvanced.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkShowAdvanced.AutoSize = true;
            this.chkShowAdvanced.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowAdvanced.Location = new System.Drawing.Point(939, 676);
            this.chkShowAdvanced.Name = "chkShowAdvanced";
            this.chkShowAdvanced.Size = new System.Drawing.Size(173, 19);
            this.chkShowAdvanced.TabIndex = 5;
            this.chkShowAdvanced.Text = "Show Advanced properties";
            this.chkShowAdvanced.UseVisualStyleBackColor = true;
            this.chkShowAdvanced.CheckedChanged += new System.EventHandler(this.chkShowAdvanced_CheckedChanged);
            // 
            // btnReconfigure
            // 
            this.btnReconfigure.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReconfigure.Location = new System.Drawing.Point(57, 52);
            this.btnReconfigure.Name = "btnReconfigure";
            this.btnReconfigure.Size = new System.Drawing.Size(246, 29);
            this.btnReconfigure.TabIndex = 6;
            this.btnReconfigure.Text = "Reconfigure Selected Component(s)";
            this.btnReconfigure.UseVisualStyleBackColor = true;
            this.btnReconfigure.Click += new System.EventHandler(this.btnReconfigure_Click);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // msiProductCodeDataGridViewTextBoxColumn
            // 
            this.msiProductCodeDataGridViewTextBoxColumn.DataPropertyName = "MsiProductCode";
            this.msiProductCodeDataGridViewTextBoxColumn.HeaderText = "MsiProductCode";
            this.msiProductCodeDataGridViewTextBoxColumn.Name = "msiProductCodeDataGridViewTextBoxColumn";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Company";
            this.dataGridViewTextBoxColumn3.HeaderText = "Company";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "System";
            this.dataGridViewCheckBoxColumn1.HeaderText = "System";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "InstallLocation";
            this.dataGridViewTextBoxColumn4.HeaderText = "InstallLocation";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // installSourceDataGridViewTextBoxColumn
            // 
            this.installSourceDataGridViewTextBoxColumn.DataPropertyName = "InstallSource";
            this.installSourceDataGridViewTextBoxColumn.HeaderText = "InstallSource";
            this.installSourceDataGridViewTextBoxColumn.Name = "installSourceDataGridViewTextBoxColumn";
            // 
            // modifyPathDataGridViewTextBoxColumn
            // 
            this.modifyPathDataGridViewTextBoxColumn.DataPropertyName = "ModifyPath";
            this.modifyPathDataGridViewTextBoxColumn.HeaderText = "ModifyPath";
            this.modifyPathDataGridViewTextBoxColumn.Name = "modifyPathDataGridViewTextBoxColumn";
            // 
            // uninstallStringDataGridViewTextBoxColumn
            // 
            this.uninstallStringDataGridViewTextBoxColumn.DataPropertyName = "UninstallString";
            this.uninstallStringDataGridViewTextBoxColumn.HeaderText = "UninstallString";
            this.uninstallStringDataGridViewTextBoxColumn.Name = "uninstallStringDataGridViewTextBoxColumn";
            // 
            // localPackageDataGridViewTextBoxColumn
            // 
            this.localPackageDataGridViewTextBoxColumn.DataPropertyName = "LocalPackage";
            this.localPackageDataGridViewTextBoxColumn.HeaderText = "LocalPackage";
            this.localPackageDataGridViewTextBoxColumn.Name = "localPackageDataGridViewTextBoxColumn";
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "Version";
            this.dataGridViewTextBoxColumn13.HeaderText = "Version";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            // 
            // productConfigDataGridViewTextBoxColumn
            // 
            this.productConfigDataGridViewTextBoxColumn.DataPropertyName = "ProductConfig";
            this.productConfigDataGridViewTextBoxColumn.HeaderText = "ProductConfig";
            this.productConfigDataGridViewTextBoxColumn.Name = "productConfigDataGridViewTextBoxColumn";
            // 
            // dsMsiProducts
            // 
            this.dsMsiProducts.DataSource = typeof(SIMClear.MsiProductDataSet);
            this.dsMsiProducts.Position = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 703);
            this.Controls.Add(this.btnReconfigure);
            this.Controls.Add(this.chkShowAdvanced);
            this.Controls.Add(this.btnPurgeAllArellia);
            this.Controls.Add(this.btnPurgeArellia);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Arellia SIM Utility";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMsiProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn msiProductCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productConfigDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource dsMsiProducts;
        private System.Windows.Forms.Button btnPurgeArellia;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn installSourceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn modifyPathDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uninstallStringDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn localPackageDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        //private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        //private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        //private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.Button btnPurgeAllArellia;
        private System.Windows.Forms.CheckBox chkShowAdvanced;
        private System.Windows.Forms.Button btnReconfigure;
    }
}

