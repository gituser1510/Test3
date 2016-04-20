namespace NameToStructureApplication.Forms
{
    partial class frmSelectTAN_Xml
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
            this.btnBrowse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFolderPath = new System.Windows.Forms.TextBox();
            this.btnRemAll = new System.Windows.Forms.Button();
            this.btnRemOne = new System.Windows.Forms.Button();
            this.btnSelAll = new System.Windows.Forms.Button();
            this.btnSelOne = new System.Windows.Forms.Button();
            this.lblSelTANs = new System.Windows.Forms.Label();
            this.lblAvailTANS = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnWriteXml = new System.Windows.Forms.Button();
            this.lstSelTANs = new System.Windows.Forms.ListBox();
            this.lstAvailTANs = new System.Windows.Forms.ListBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlMain.Controls.Add(this.btnBrowse);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.txtFolderPath);
            this.pnlMain.Controls.Add(this.btnRemAll);
            this.pnlMain.Controls.Add(this.btnRemOne);
            this.pnlMain.Controls.Add(this.btnSelAll);
            this.pnlMain.Controls.Add(this.btnSelOne);
            this.pnlMain.Controls.Add(this.lblSelTANs);
            this.pnlMain.Controls.Add(this.lblAvailTANS);
            this.pnlMain.Controls.Add(this.btnCancel);
            this.pnlMain.Controls.Add(this.btnWriteXml);
            this.pnlMain.Controls.Add(this.lstSelTANs);
            this.pnlMain.Controls.Add(this.lstAvailTANs);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(445, 414);
            this.pnlMain.TabIndex = 0;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowse.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(393, 342);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(39, 28);
            this.btnBrowse.TabIndex = 22;
            this.btnBrowse.Text = "...";
            this.btnBrowse.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(7, 324);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 17);
            this.label1.TabIndex = 21;
            this.label1.Text = "Specify folder name";
            // 
            // txtFolderPath
            // 
            this.txtFolderPath.BackColor = System.Drawing.Color.White;
            this.txtFolderPath.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFolderPath.Location = new System.Drawing.Point(10, 344);
            this.txtFolderPath.Name = "txtFolderPath";
            this.txtFolderPath.ReadOnly = true;
            this.txtFolderPath.Size = new System.Drawing.Size(377, 25);
            this.txtFolderPath.TabIndex = 20;
            // 
            // btnRemAll
            // 
            this.btnRemAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemAll.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemAll.Location = new System.Drawing.Point(198, 216);
            this.btnRemAll.Name = "btnRemAll";
            this.btnRemAll.Size = new System.Drawing.Size(45, 30);
            this.btnRemAll.TabIndex = 19;
            this.btnRemAll.Text = "<<";
            this.btnRemAll.UseVisualStyleBackColor = true;
            this.btnRemAll.Click += new System.EventHandler(this.btnRemAll_Click);
            // 
            // btnRemOne
            // 
            this.btnRemOne.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemOne.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemOne.Location = new System.Drawing.Point(198, 180);
            this.btnRemOne.Name = "btnRemOne";
            this.btnRemOne.Size = new System.Drawing.Size(45, 30);
            this.btnRemOne.TabIndex = 18;
            this.btnRemOne.Text = "<";
            this.btnRemOne.UseVisualStyleBackColor = true;
            this.btnRemOne.Click += new System.EventHandler(this.btnRemOne_Click);
            // 
            // btnSelAll
            // 
            this.btnSelAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelAll.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelAll.Location = new System.Drawing.Point(198, 123);
            this.btnSelAll.Name = "btnSelAll";
            this.btnSelAll.Size = new System.Drawing.Size(45, 30);
            this.btnSelAll.TabIndex = 17;
            this.btnSelAll.Text = ">>";
            this.btnSelAll.UseVisualStyleBackColor = true;
            this.btnSelAll.Click += new System.EventHandler(this.btnSelAll_Click);
            // 
            // btnSelOne
            // 
            this.btnSelOne.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelOne.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelOne.Location = new System.Drawing.Point(198, 87);
            this.btnSelOne.Name = "btnSelOne";
            this.btnSelOne.Size = new System.Drawing.Size(45, 30);
            this.btnSelOne.TabIndex = 16;
            this.btnSelOne.Text = ">";
            this.btnSelOne.UseVisualStyleBackColor = true;
            this.btnSelOne.Click += new System.EventHandler(this.btnSelOne_Click);
            // 
            // lblSelTANs
            // 
            this.lblSelTANs.AutoSize = true;
            this.lblSelTANs.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelTANs.ForeColor = System.Drawing.Color.Blue;
            this.lblSelTANs.Location = new System.Drawing.Point(263, 7);
            this.lblSelTANs.Name = "lblSelTANs";
            this.lblSelTANs.Size = new System.Drawing.Size(107, 17);
            this.lblSelTANs.TabIndex = 15;
            this.lblSelTANs.Text = "Selected TANs";
            // 
            // lblAvailTANS
            // 
            this.lblAvailTANS.AutoSize = true;
            this.lblAvailTANS.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailTANS.ForeColor = System.Drawing.Color.Blue;
            this.lblAvailTANS.Location = new System.Drawing.Point(10, 7);
            this.lblAvailTANS.Name = "lblAvailTANS";
            this.lblAvailTANS.Size = new System.Drawing.Size(112, 17);
            this.lblAvailTANS.TabIndex = 14;
            this.lblAvailTANS.Text = "Available TANs";
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(235, 375);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(89, 30);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnWriteXml
            // 
            this.btnWriteXml.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWriteXml.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnWriteXml.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWriteXml.Location = new System.Drawing.Point(343, 375);
            this.btnWriteXml.Name = "btnWriteXml";
            this.btnWriteXml.Size = new System.Drawing.Size(89, 30);
            this.btnWriteXml.TabIndex = 12;
            this.btnWriteXml.Text = "Write Xml";
            this.btnWriteXml.UseVisualStyleBackColor = true;
            this.btnWriteXml.Click += new System.EventHandler(this.btnWriteXml_Click);
            // 
            // lstSelTANs
            // 
            this.lstSelTANs.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSelTANs.FormattingEnabled = true;
            this.lstSelTANs.ItemHeight = 17;
            this.lstSelTANs.Location = new System.Drawing.Point(266, 27);
            this.lstSelTANs.Name = "lstSelTANs";
            this.lstSelTANs.Size = new System.Drawing.Size(166, 293);
            this.lstSelTANs.TabIndex = 11;
            // 
            // lstAvailTANs
            // 
            this.lstAvailTANs.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstAvailTANs.FormattingEnabled = true;
            this.lstAvailTANs.ItemHeight = 17;
            this.lstAvailTANs.Location = new System.Drawing.Point(10, 27);
            this.lstAvailTANs.Name = "lstAvailTANs";
            this.lstAvailTANs.Size = new System.Drawing.Size(166, 293);
            this.lstAvailTANs.TabIndex = 10;
            // 
            // frmSelectTAN_Xml
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(445, 414);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSelectTAN_Xml";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select TAN";
            this.Load += new System.EventHandler(this.frmSelectTAN_Xml_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnRemAll;
        private System.Windows.Forms.Button btnRemOne;
        private System.Windows.Forms.Button btnSelAll;
        private System.Windows.Forms.Button btnSelOne;
        private System.Windows.Forms.Label lblSelTANs;
        private System.Windows.Forms.Label lblAvailTANS;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnWriteXml;
        private System.Windows.Forms.ListBox lstSelTANs;
        private System.Windows.Forms.ListBox lstAvailTANs;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFolderPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}