namespace NameToStructureApplication.Forms
{
    partial class frmExportOpts
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtFolderPath = new System.Windows.Forms.TextBox();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnRemAll = new System.Windows.Forms.Button();
            this.btnRemOne = new System.Windows.Forms.Button();
            this.btnSelAll = new System.Windows.Forms.Button();
            this.btnSelOne = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAvailProps = new System.Windows.Forms.Label();
            this.lstSelProp = new System.Windows.Forms.ListBox();
            this.lstAvailProp = new System.Windows.Forms.ListBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.pnlMain.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.label2);
            this.pnlMain.Controls.Add(this.btnBrowse);
            this.pnlMain.Controls.Add(this.txtFolderPath);
            this.pnlMain.Controls.Add(this.pnlButtons);
            this.pnlMain.Controls.Add(this.btnRemAll);
            this.pnlMain.Controls.Add(this.btnRemOne);
            this.pnlMain.Controls.Add(this.btnSelAll);
            this.pnlMain.Controls.Add(this.btnSelOne);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.lblAvailProps);
            this.pnlMain.Controls.Add(this.lstSelProp);
            this.pnlMain.Controls.Add(this.lstAvailProp);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(490, 308);
            this.pnlMain.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 223);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Specify Folder Name";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowse.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(439, 242);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(39, 28);
            this.btnBrowse.TabIndex = 4;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtFolderPath
            // 
            this.txtFolderPath.BackColor = System.Drawing.Color.White;
            this.txtFolderPath.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFolderPath.Location = new System.Drawing.Point(12, 243);
            this.txtFolderPath.Name = "txtFolderPath";
            this.txtFolderPath.ReadOnly = true;
            this.txtFolderPath.Size = new System.Drawing.Size(421, 25);
            this.txtFolderPath.TabIndex = 11;
            // 
            // pnlButtons
            // 
            this.pnlButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Controls.Add(this.btnExport);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 273);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(490, 35);
            this.pnlButtons.TabIndex = 10;
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(298, 1);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(89, 30);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnExport.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(393, 1);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(89, 30);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnRemAll
            // 
            this.btnRemAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemAll.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemAll.Location = new System.Drawing.Point(223, 172);
            this.btnRemAll.Name = "btnRemAll";
            this.btnRemAll.Size = new System.Drawing.Size(45, 30);
            this.btnRemAll.TabIndex = 9;
            this.btnRemAll.Text = "<<";
            this.btnRemAll.UseVisualStyleBackColor = true;
            this.btnRemAll.Click += new System.EventHandler(this.btnRemAll_Click);
            // 
            // btnRemOne
            // 
            this.btnRemOne.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemOne.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemOne.Location = new System.Drawing.Point(223, 136);
            this.btnRemOne.Name = "btnRemOne";
            this.btnRemOne.Size = new System.Drawing.Size(45, 30);
            this.btnRemOne.TabIndex = 8;
            this.btnRemOne.Text = "<";
            this.btnRemOne.UseVisualStyleBackColor = true;
            this.btnRemOne.Click += new System.EventHandler(this.btnRemOne_Click);
            // 
            // btnSelAll
            // 
            this.btnSelAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelAll.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelAll.Location = new System.Drawing.Point(223, 79);
            this.btnSelAll.Name = "btnSelAll";
            this.btnSelAll.Size = new System.Drawing.Size(45, 30);
            this.btnSelAll.TabIndex = 7;
            this.btnSelAll.Text = ">>";
            this.btnSelAll.UseVisualStyleBackColor = true;
            this.btnSelAll.Click += new System.EventHandler(this.btnSelAll_Click);
            // 
            // btnSelOne
            // 
            this.btnSelOne.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelOne.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelOne.Location = new System.Drawing.Point(223, 43);
            this.btnSelOne.Name = "btnSelOne";
            this.btnSelOne.Size = new System.Drawing.Size(45, 30);
            this.btnSelOne.TabIndex = 6;
            this.btnSelOne.Text = ">";
            this.btnSelOne.UseVisualStyleBackColor = true;
            this.btnSelOne.Click += new System.EventHandler(this.btnSelOne_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(276, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Selected Properties";
            // 
            // lblAvailProps
            // 
            this.lblAvailProps.AutoSize = true;
            this.lblAvailProps.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailProps.ForeColor = System.Drawing.Color.Blue;
            this.lblAvailProps.Location = new System.Drawing.Point(12, 6);
            this.lblAvailProps.Name = "lblAvailProps";
            this.lblAvailProps.Size = new System.Drawing.Size(142, 17);
            this.lblAvailProps.TabIndex = 4;
            this.lblAvailProps.Text = "Available Properties";
            // 
            // lstSelProp
            // 
            this.lstSelProp.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSelProp.FormattingEnabled = true;
            this.lstSelProp.ItemHeight = 17;
            this.lstSelProp.Location = new System.Drawing.Point(279, 26);
            this.lstSelProp.Name = "lstSelProp";
            this.lstSelProp.Size = new System.Drawing.Size(199, 191);
            this.lstSelProp.TabIndex = 1;
            // 
            // lstAvailProp
            // 
            this.lstAvailProp.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstAvailProp.FormattingEnabled = true;
            this.lstAvailProp.ItemHeight = 17;
            this.lstAvailProp.Location = new System.Drawing.Point(12, 26);
            this.lstAvailProp.Name = "lstAvailProp";
            this.lstAvailProp.Size = new System.Drawing.Size(199, 191);
            this.lstAvailProp.TabIndex = 0;
            // 
            // frmExportOpts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(490, 308);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmExportOpts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Export Options";
            this.Load += new System.EventHandler(this.frmExportOpts_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.ListBox lstSelProp;
        private System.Windows.Forms.ListBox lstAvailProp;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAvailProps;
        private System.Windows.Forms.Button btnSelOne;
        private System.Windows.Forms.Button btnRemAll;
        private System.Windows.Forms.Button btnRemOne;
        private System.Windows.Forms.Button btnSelAll;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtFolderPath;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}