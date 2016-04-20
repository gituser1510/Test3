namespace NameToStructureApplication.Dictionary
{
    partial class frmRetrieveDict
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
            this.txtCompName = new System.Windows.Forms.TextBox();
            this.lblCompName = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlMain.Controls.Add(this.txtSmiles);
            this.pnlMain.Controls.Add(this.lblSmiles);
            this.pnlMain.Controls.Add(this.btnRetrieve);
            this.pnlMain.Controls.Add(this.txtCompName);
            this.pnlMain.Controls.Add(this.lblCompName);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(415, 237);
            this.pnlMain.TabIndex = 1;
            // 
            // txtSmiles
            // 
            this.txtSmiles.BackColor = System.Drawing.Color.White;
            this.txtSmiles.Location = new System.Drawing.Point(9, 103);
            this.txtSmiles.Multiline = true;
            this.txtSmiles.Name = "txtSmiles";
            this.txtSmiles.ReadOnly = true;
            this.txtSmiles.Size = new System.Drawing.Size(399, 124);
            this.txtSmiles.TabIndex = 15;
            // 
            // lblSmiles
            // 
            this.lblSmiles.AutoSize = true;
            this.lblSmiles.Location = new System.Drawing.Point(6, 84);
            this.lblSmiles.Name = "lblSmiles";
            this.lblSmiles.Size = new System.Drawing.Size(60, 17);
            this.lblSmiles.TabIndex = 14;
            this.lblSmiles.Text = "SMILES";
            // 
            // btnRetrieve
            // 
            this.btnRetrieve.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRetrieve.Location = new System.Drawing.Point(310, 62);
            this.btnRetrieve.Name = "btnRetrieve";
            this.btnRetrieve.Size = new System.Drawing.Size(98, 30);
            this.btnRetrieve.TabIndex = 13;
            this.btnRetrieve.Text = "Get SMILES";
            this.btnRetrieve.UseVisualStyleBackColor = true;
            this.btnRetrieve.Click += new System.EventHandler(this.btnRetrieve_Click);
            // 
            // txtCompName
            // 
            this.txtCompName.Location = new System.Drawing.Point(9, 31);
            this.txtCompName.Name = "txtCompName";
            this.txtCompName.Size = new System.Drawing.Size(399, 25);
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
            // frmRetrieveDict
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 237);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRetrieveDict";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dictionary-Retrieve";
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.TextBox txtCompName;
        private System.Windows.Forms.Label lblCompName;
        private System.Windows.Forms.TextBox txtSmiles;
        private System.Windows.Forms.Label lblSmiles;
        private System.Windows.Forms.Button btnRetrieve;
    }
}