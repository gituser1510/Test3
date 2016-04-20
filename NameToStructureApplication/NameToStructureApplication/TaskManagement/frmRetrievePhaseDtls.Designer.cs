namespace NameToStructureApplication.TaskManagement
{
    partial class frmRetrievePhaseDtls
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
            this.dtGridPDetails = new System.Windows.Forms.DataGridView();
            this.pnlCntrls = new System.Windows.Forms.Panel();
            this.btnRetrieve = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lblPhaseName = new System.Windows.Forms.Label();
            this.txtPhaseName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblShipment = new System.Windows.Forms.Label();
            this.txtShipment = new System.Windows.Forms.TextBox();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridPDetails)).BeginInit();
            this.pnlCntrls.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.dtGridPDetails);
            this.pnlMain.Controls.Add(this.pnlCntrls);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(770, 515);
            this.pnlMain.TabIndex = 0;
            // 
            // dtGridPDetails
            // 
            this.dtGridPDetails.AllowUserToAddRows = false;
            this.dtGridPDetails.AllowUserToDeleteRows = false;
            this.dtGridPDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridPDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGridPDetails.Location = new System.Drawing.Point(0, 73);
            this.dtGridPDetails.Name = "dtGridPDetails";
            this.dtGridPDetails.ReadOnly = true;
            this.dtGridPDetails.Size = new System.Drawing.Size(770, 442);
            this.dtGridPDetails.TabIndex = 1;
            // 
            // pnlCntrls
            // 
            this.pnlCntrls.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlCntrls.Controls.Add(this.btnRetrieve);
            this.pnlCntrls.Controls.Add(this.dateTimePicker1);
            this.pnlCntrls.Controls.Add(this.lblPhaseName);
            this.pnlCntrls.Controls.Add(this.txtPhaseName);
            this.pnlCntrls.Controls.Add(this.label1);
            this.pnlCntrls.Controls.Add(this.lblShipment);
            this.pnlCntrls.Controls.Add(this.txtShipment);
            this.pnlCntrls.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCntrls.Location = new System.Drawing.Point(0, 0);
            this.pnlCntrls.Name = "pnlCntrls";
            this.pnlCntrls.Size = new System.Drawing.Size(770, 73);
            this.pnlCntrls.TabIndex = 0;
            // 
            // btnRetrieve
            // 
            this.btnRetrieve.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRetrieve.Location = new System.Drawing.Point(660, 32);
            this.btnRetrieve.Name = "btnRetrieve";
            this.btnRetrieve.Size = new System.Drawing.Size(96, 31);
            this.btnRetrieve.TabIndex = 18;
            this.btnRetrieve.Text = "Retrieve";
            this.btnRetrieve.UseVisualStyleBackColor = true;
            this.btnRetrieve.Click += new System.EventHandler(this.btnRetrieve_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "MMM yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 37);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(144, 25);
            this.dateTimePicker1.TabIndex = 16;
            this.dateTimePicker1.Value = new System.DateTime(2010, 6, 1, 0, 0, 0, 0);
            // 
            // lblPhaseName
            // 
            this.lblPhaseName.AutoSize = true;
            this.lblPhaseName.Location = new System.Drawing.Point(165, 17);
            this.lblPhaseName.Name = "lblPhaseName";
            this.lblPhaseName.Size = new System.Drawing.Size(84, 17);
            this.lblPhaseName.TabIndex = 12;
            this.lblPhaseName.Text = "Phase Name";
            // 
            // txtPhaseName
            // 
            this.txtPhaseName.Location = new System.Drawing.Point(168, 38);
            this.txtPhaseName.Name = "txtPhaseName";
            this.txtPhaseName.Size = new System.Drawing.Size(199, 25);
            this.txtPhaseName.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 17);
            this.label1.TabIndex = 17;
            this.label1.Text = "Phase Date";
            // 
            // lblShipment
            // 
            this.lblShipment.AutoSize = true;
            this.lblShipment.Location = new System.Drawing.Point(385, 16);
            this.lblShipment.Name = "lblShipment";
            this.lblShipment.Size = new System.Drawing.Size(102, 17);
            this.lblShipment.TabIndex = 15;
            this.lblShipment.Text = "Shipment Name";
            // 
            // txtShipment
            // 
            this.txtShipment.Location = new System.Drawing.Point(388, 37);
            this.txtShipment.Name = "txtShipment";
            this.txtShipment.Size = new System.Drawing.Size(262, 25);
            this.txtShipment.TabIndex = 14;
            // 
            // frmRetrievePhaseDtls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 515);
            this.Controls.Add(this.pnlMain);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRetrievePhaseDtls";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Retrieve Phase Details";
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGridPDetails)).EndInit();
            this.pnlCntrls.ResumeLayout(false);
            this.pnlCntrls.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.DataGridView dtGridPDetails;
        private System.Windows.Forms.Panel pnlCntrls;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lblPhaseName;
        private System.Windows.Forms.TextBox txtPhaseName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblShipment;
        private System.Windows.Forms.TextBox txtShipment;
        private System.Windows.Forms.Button btnRetrieve;
    }
}