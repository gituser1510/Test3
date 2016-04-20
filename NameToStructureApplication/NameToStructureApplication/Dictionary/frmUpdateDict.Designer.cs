namespace NameToStructureApplication.Dictionary
{
    partial class frmUpdateDict
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
            this.txtSmiles = new System.Windows.Forms.TextBox();
            this.lblSmiles = new System.Windows.Forms.Label();
            this.btnRetrieve = new System.Windows.Forms.Button();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtCompName = new System.Windows.Forms.TextBox();
            this.lblCompName = new System.Windows.Forms.Label();
            this.txtNewSmiles = new System.Windows.Forms.TextBox();
            this.lblNewSmiles = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlMain.Controls.Add(this.txtNewSmiles);
            this.pnlMain.Controls.Add(this.lblNewSmiles);
            this.pnlMain.Controls.Add(this.txtSmiles);
            this.pnlMain.Controls.Add(this.lblSmiles);
            this.pnlMain.Controls.Add(this.btnRetrieve);
            this.pnlMain.Controls.Add(this.pnlButtons);
            this.pnlMain.Controls.Add(this.txtCompName);
            this.pnlMain.Controls.Add(this.lblCompName);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(420, 261);
            this.pnlMain.TabIndex = 0;
            // 
            // txtSmiles
            // 
            this.txtSmiles.BackColor = System.Drawing.Color.White;
            this.txtSmiles.Location = new System.Drawing.Point(9, 82);
            this.txtSmiles.Multiline = true;
            this.txtSmiles.Name = "txtSmiles";
            this.txtSmiles.ReadOnly = true;
            this.txtSmiles.Size = new System.Drawing.Size(402, 51);
            this.txtSmiles.TabIndex = 17;
            // 
            // lblSmiles
            // 
            this.lblSmiles.AutoSize = true;
            this.lblSmiles.Location = new System.Drawing.Point(9, 63);
            this.lblSmiles.Name = "lblSmiles";
            this.lblSmiles.Size = new System.Drawing.Size(109, 17);
            this.lblSmiles.TabIndex = 16;
            this.lblSmiles.Text = "Current SMILES";
            // 
            // btnRetrieve
            // 
            this.btnRetrieve.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRetrieve.Location = new System.Drawing.Point(315, 29);
            this.btnRetrieve.Name = "btnRetrieve";
            this.btnRetrieve.Size = new System.Drawing.Size(96, 27);
            this.btnRetrieve.TabIndex = 14;
            this.btnRetrieve.Text = "Get SMILES";
            this.btnRetrieve.UseVisualStyleBackColor = true;
            this.btnRetrieve.Click += new System.EventHandler(this.btnRetrieve_Click);
            // 
            // pnlButtons
            // 
            this.pnlButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlButtons.Controls.Add(this.btnUpdate);
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 228);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(420, 33);
            this.pnlButtons.TabIndex = 12;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Location = new System.Drawing.Point(331, 1);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(80, 27);
            this.btnUpdate.TabIndex = 11;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(244, 1);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 27);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtCompName
            // 
            this.txtCompName.Location = new System.Drawing.Point(9, 31);
            this.txtCompName.Name = "txtCompName";
            this.txtCompName.Size = new System.Drawing.Size(294, 25);
            this.txtCompName.TabIndex = 8;
            // 
            // lblCompName
            // 
            this.lblCompName.AutoSize = true;
            this.lblCompName.Location = new System.Drawing.Point(6, 11);
            this.lblCompName.Name = "lblCompName";
            this.lblCompName.Size = new System.Drawing.Size(111, 17);
            this.lblCompName.TabIndex = 6;
            this.lblCompName.Text = "Compound Name";
            // 
            // txtNewSmiles
            // 
            this.txtNewSmiles.BackColor = System.Drawing.Color.White;
            this.txtNewSmiles.Location = new System.Drawing.Point(9, 160);
            this.txtNewSmiles.Multiline = true;
            this.txtNewSmiles.Name = "txtNewSmiles";
            this.txtNewSmiles.Size = new System.Drawing.Size(402, 51);
            this.txtNewSmiles.TabIndex = 19;
            // 
            // lblNewSmiles
            // 
            this.lblNewSmiles.AutoSize = true;
            this.lblNewSmiles.Location = new System.Drawing.Point(9, 140);
            this.lblNewSmiles.Name = "lblNewSmiles";
            this.lblNewSmiles.Size = new System.Drawing.Size(93, 17);
            this.lblNewSmiles.TabIndex = 18;
            this.lblNewSmiles.Text = "New SMILES";
            // 
            // frmUpdateDict
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 261);
            this.Controls.Add(this.pnlMain);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUpdateDict";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dictionary-Update";
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtCompName;
        private System.Windows.Forms.Label lblCompName;
        private System.Windows.Forms.Button btnRetrieve;
        private System.Windows.Forms.TextBox txtSmiles;
        private System.Windows.Forms.Label lblSmiles;
        private System.Windows.Forms.TextBox txtNewSmiles;
        private System.Windows.Forms.Label lblNewSmiles;
    }
}