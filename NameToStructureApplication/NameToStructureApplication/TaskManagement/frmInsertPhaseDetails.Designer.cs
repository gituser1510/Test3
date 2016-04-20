namespace NameToStructureApplication.TaskManagement
{
    partial class frmInsertPhaseDetails
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
            this.numDDSubsCnt = new System.Windows.Forms.NumericUpDown();
            this.cmbIsEligible = new System.Windows.Forms.ComboBox();
            this.lblSubsCnt = new System.Windows.Forms.Label();
            this.lblIsEligible = new System.Windows.Forms.Label();
            this.txtTAN = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnInsert = new System.Windows.Forms.Button();
            this.txtShipment = new System.Windows.Forms.TextBox();
            this.lblShipment = new System.Windows.Forms.Label();
            this.lblTans = new System.Windows.Forms.Label();
            this.txtPhaseName = new System.Windows.Forms.TextBox();
            this.lblPhaseName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtGridPhaseDtls = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowseFile = new System.Windows.Forms.Button();
            this.grpInsertOpt = new System.Windows.Forms.GroupBox();
            this.pnlFromFile = new System.Windows.Forms.Panel();
            this.rbnManual = new System.Windows.Forms.RadioButton();
            this.rbnFrmFile = new System.Windows.Forms.RadioButton();
            this.pnlManual = new System.Windows.Forms.Panel();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDDSubsCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridPhaseDtls)).BeginInit();
            this.grpInsertOpt.SuspendLayout();
            this.pnlFromFile.SuspendLayout();
            this.pnlManual.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlManual);
            this.pnlMain.Controls.Add(this.pnlFromFile);
            this.pnlMain.Controls.Add(this.grpInsertOpt);
            this.pnlMain.Controls.Add(this.pnlButtons);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(719, 610);
            this.pnlMain.TabIndex = 0;
            // 
            // numDDSubsCnt
            // 
            this.numDDSubsCnt.Location = new System.Drawing.Point(273, 80);
            this.numDDSubsCnt.Name = "numDDSubsCnt";
            this.numDDSubsCnt.Size = new System.Drawing.Size(123, 25);
            this.numDDSubsCnt.TabIndex = 5;
            // 
            // cmbIsEligible
            // 
            this.cmbIsEligible.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIsEligible.FormattingEnabled = true;
            this.cmbIsEligible.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.cmbIsEligible.Location = new System.Drawing.Point(162, 80);
            this.cmbIsEligible.Name = "cmbIsEligible";
            this.cmbIsEligible.Size = new System.Drawing.Size(90, 25);
            this.cmbIsEligible.TabIndex = 4;
            // 
            // lblSubsCnt
            // 
            this.lblSubsCnt.AutoSize = true;
            this.lblSubsCnt.Location = new System.Drawing.Point(270, 61);
            this.lblSubsCnt.Name = "lblSubsCnt";
            this.lblSubsCnt.Size = new System.Drawing.Size(83, 17);
            this.lblSubsCnt.TabIndex = 10;
            this.lblSubsCnt.Text = "Subst. Count";
            // 
            // lblIsEligible
            // 
            this.lblIsEligible.AutoSize = true;
            this.lblIsEligible.Location = new System.Drawing.Point(162, 61);
            this.lblIsEligible.Name = "lblIsEligible";
            this.lblIsEligible.Size = new System.Drawing.Size(65, 17);
            this.lblIsEligible.TabIndex = 8;
            this.lblIsEligible.Text = "Is Eligible";
            // 
            // txtTAN
            // 
            this.txtTAN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTAN.Location = new System.Drawing.Point(6, 81);
            this.txtTAN.Name = "txtTAN";
            this.txtTAN.Size = new System.Drawing.Size(144, 25);
            this.txtTAN.TabIndex = 3;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "MMM yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(6, 24);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(144, 25);
            this.dateTimePicker1.TabIndex = 8;
            this.dateTimePicker1.Value = new System.DateTime(2010, 6, 1, 0, 0, 0, 0);
            // 
            // btnInsert
            // 
            this.btnInsert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInsert.Location = new System.Drawing.Point(609, 2);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(96, 31);
            this.btnInsert.TabIndex = 6;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // txtShipment
            // 
            this.txtShipment.Location = new System.Drawing.Point(409, 25);
            this.txtShipment.Name = "txtShipment";
            this.txtShipment.Size = new System.Drawing.Size(290, 25);
            this.txtShipment.TabIndex = 2;
            // 
            // lblShipment
            // 
            this.lblShipment.AutoSize = true;
            this.lblShipment.Location = new System.Drawing.Point(406, 4);
            this.lblShipment.Name = "lblShipment";
            this.lblShipment.Size = new System.Drawing.Size(102, 17);
            this.lblShipment.TabIndex = 4;
            this.lblShipment.Text = "Shipment Name";
            // 
            // lblTans
            // 
            this.lblTans.AutoSize = true;
            this.lblTans.Location = new System.Drawing.Point(6, 61);
            this.lblTans.Name = "lblTans";
            this.lblTans.Size = new System.Drawing.Size(39, 17);
            this.lblTans.TabIndex = 2;
            this.lblTans.Text = "TAN";
            // 
            // txtPhaseName
            // 
            this.txtPhaseName.Location = new System.Drawing.Point(162, 25);
            this.txtPhaseName.Name = "txtPhaseName";
            this.txtPhaseName.Size = new System.Drawing.Size(234, 25);
            this.txtPhaseName.TabIndex = 1;
            // 
            // lblPhaseName
            // 
            this.lblPhaseName.AutoSize = true;
            this.lblPhaseName.Location = new System.Drawing.Point(159, 4);
            this.lblPhaseName.Name = "lblPhaseName";
            this.lblPhaseName.Size = new System.Drawing.Size(84, 17);
            this.lblPhaseName.TabIndex = 0;
            this.lblPhaseName.Text = "Phase Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Phase Date";
            // 
            // dtGridPhaseDtls
            // 
            this.dtGridPhaseDtls.AllowUserToAddRows = false;
            this.dtGridPhaseDtls.AllowUserToDeleteRows = false;
            this.dtGridPhaseDtls.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtGridPhaseDtls.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtGridPhaseDtls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridPhaseDtls.Location = new System.Drawing.Point(3, 37);
            this.dtGridPhaseDtls.Name = "dtGridPhaseDtls";
            this.dtGridPhaseDtls.ReadOnly = true;
            this.dtGridPhaseDtls.Size = new System.Drawing.Size(703, 355);
            this.dtGridPhaseDtls.TabIndex = 12;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtFilePath
            // 
            this.txtFilePath.BackColor = System.Drawing.Color.White;
            this.txtFilePath.Location = new System.Drawing.Point(69, 6);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(523, 25);
            this.txtFilePath.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "File Path";
            // 
            // btnBrowseFile
            // 
            this.btnBrowseFile.Location = new System.Drawing.Point(598, 3);
            this.btnBrowseFile.Name = "btnBrowseFile";
            this.btnBrowseFile.Size = new System.Drawing.Size(92, 28);
            this.btnBrowseFile.TabIndex = 16;
            this.btnBrowseFile.Text = "Browse";
            this.btnBrowseFile.UseVisualStyleBackColor = true;
            this.btnBrowseFile.Click += new System.EventHandler(this.button1_Click);
            // 
            // grpInsertOpt
            // 
            this.grpInsertOpt.Controls.Add(this.rbnFrmFile);
            this.grpInsertOpt.Controls.Add(this.rbnManual);
            this.grpInsertOpt.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpInsertOpt.Location = new System.Drawing.Point(0, 0);
            this.grpInsertOpt.Name = "grpInsertOpt";
            this.grpInsertOpt.Size = new System.Drawing.Size(719, 48);
            this.grpInsertOpt.TabIndex = 17;
            this.grpInsertOpt.TabStop = false;
            this.grpInsertOpt.Text = "Insert Phase details";
            // 
            // pnlFromFile
            // 
            this.pnlFromFile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlFromFile.Controls.Add(this.dtGridPhaseDtls);
            this.pnlFromFile.Controls.Add(this.label2);
            this.pnlFromFile.Controls.Add(this.txtFilePath);
            this.pnlFromFile.Controls.Add(this.btnBrowseFile);
            this.pnlFromFile.Location = new System.Drawing.Point(3, 54);
            this.pnlFromFile.Name = "pnlFromFile";
            this.pnlFromFile.Size = new System.Drawing.Size(713, 399);
            this.pnlFromFile.TabIndex = 18;
            // 
            // rbnManual
            // 
            this.rbnManual.AutoSize = true;
            this.rbnManual.Location = new System.Drawing.Point(74, 21);
            this.rbnManual.Name = "rbnManual";
            this.rbnManual.Size = new System.Drawing.Size(80, 21);
            this.rbnManual.TabIndex = 0;
            this.rbnManual.Text = "Manually";
            this.rbnManual.UseVisualStyleBackColor = true;
            this.rbnManual.CheckedChanged += new System.EventHandler(this.rbnManual_CheckedChanged);
            // 
            // rbnFrmFile
            // 
            this.rbnFrmFile.AutoSize = true;
            this.rbnFrmFile.Location = new System.Drawing.Point(202, 21);
            this.rbnFrmFile.Name = "rbnFrmFile";
            this.rbnFrmFile.Size = new System.Drawing.Size(119, 21);
            this.rbnFrmFile.TabIndex = 1;
            this.rbnFrmFile.Text = "From Excel File";
            this.rbnFrmFile.UseVisualStyleBackColor = true;
            this.rbnFrmFile.CheckedChanged += new System.EventHandler(this.rbnFrmFile_CheckedChanged);
            // 
            // pnlManual
            // 
            this.pnlManual.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlManual.Controls.Add(this.dateTimePicker1);
            this.pnlManual.Controls.Add(this.lblPhaseName);
            this.pnlManual.Controls.Add(this.txtPhaseName);
            this.pnlManual.Controls.Add(this.label1);
            this.pnlManual.Controls.Add(this.lblTans);
            this.pnlManual.Controls.Add(this.lblShipment);
            this.pnlManual.Controls.Add(this.numDDSubsCnt);
            this.pnlManual.Controls.Add(this.txtShipment);
            this.pnlManual.Controls.Add(this.cmbIsEligible);
            this.pnlManual.Controls.Add(this.txtTAN);
            this.pnlManual.Controls.Add(this.lblSubsCnt);
            this.pnlManual.Controls.Add(this.lblIsEligible);
            this.pnlManual.Location = new System.Drawing.Point(3, 455);
            this.pnlManual.Name = "pnlManual";
            this.pnlManual.Size = new System.Drawing.Size(713, 115);
            this.pnlManual.TabIndex = 19;
            // 
            // pnlButtons
            // 
            this.pnlButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Controls.Add(this.btnInsert);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 572);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(719, 38);
            this.pnlButtons.TabIndex = 6;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(504, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(92, 31);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmInsertPhaseDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(719, 610);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInsertPhaseDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Insert Phase Details";
            this.Load += new System.EventHandler(this.frmInsertPhaseDetails_Load);
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numDDSubsCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridPhaseDtls)).EndInit();
            this.grpInsertOpt.ResumeLayout(false);
            this.grpInsertOpt.PerformLayout();
            this.pnlFromFile.ResumeLayout(false);
            this.pnlFromFile.PerformLayout();
            this.pnlManual.ResumeLayout(false);
            this.pnlManual.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.TextBox txtShipment;
        private System.Windows.Forms.Label lblShipment;
        private System.Windows.Forms.Label lblTans;
        private System.Windows.Forms.TextBox txtPhaseName;
        private System.Windows.Forms.Label lblPhaseName;
        private System.Windows.Forms.Label lblSubsCnt;
        private System.Windows.Forms.Label lblIsEligible;
        private System.Windows.Forms.TextBox txtTAN;
        private System.Windows.Forms.ComboBox cmbIsEligible;
        private System.Windows.Forms.NumericUpDown numDDSubsCnt;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtGridPhaseDtls;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnBrowseFile;
        private System.Windows.Forms.Panel pnlFromFile;
        private System.Windows.Forms.GroupBox grpInsertOpt;
        private System.Windows.Forms.Panel pnlManual;
        private System.Windows.Forms.RadioButton rbnFrmFile;
        private System.Windows.Forms.RadioButton rbnManual;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnCancel;
    }
}