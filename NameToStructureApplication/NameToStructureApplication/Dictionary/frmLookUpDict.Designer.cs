namespace NameToStructureApplication.Dictionary
{
    partial class frmLookUpDict
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
            this.dtGridDict = new System.Windows.Forms.DataGridView();
            this.pnlCntrls = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txyCompName = new System.Windows.Forms.TextBox();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridDict)).BeginInit();
            this.pnlCntrls.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.dtGridDict);
            this.pnlMain.Controls.Add(this.pnlCntrls);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(621, 466);
            this.pnlMain.TabIndex = 0;
            // 
            // dtGridDict
            // 
            this.dtGridDict.AllowUserToAddRows = false;
            this.dtGridDict.AllowUserToDeleteRows = false;
            this.dtGridDict.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtGridDict.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtGridDict.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridDict.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGridDict.Location = new System.Drawing.Point(0, 46);
            this.dtGridDict.Name = "dtGridDict";
            this.dtGridDict.ReadOnly = true;
            this.dtGridDict.Size = new System.Drawing.Size(621, 420);
            this.dtGridDict.TabIndex = 0;
            this.dtGridDict.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dtGridDict_RowPostPaint);
            // 
            // pnlCntrls
            // 
            this.pnlCntrls.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlCntrls.Controls.Add(this.txyCompName);
            this.pnlCntrls.Controls.Add(this.label1);
            this.pnlCntrls.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCntrls.Location = new System.Drawing.Point(0, 0);
            this.pnlCntrls.Name = "pnlCntrls";
            this.pnlCntrls.Size = new System.Drawing.Size(621, 46);
            this.pnlCntrls.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search for Compound Name";
            // 
            // txyCompName
            // 
            this.txyCompName.Location = new System.Drawing.Point(186, 10);
            this.txyCompName.Name = "txyCompName";
            this.txyCompName.Size = new System.Drawing.Size(300, 25);
            this.txyCompName.TabIndex = 1;
            this.txyCompName.TextChanged += new System.EventHandler(this.txyCompName_TextChanged);
            // 
            // frmLookUpDict
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 466);
            this.Controls.Add(this.pnlMain);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLookUpDict";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Look Up Dictionary";
            this.Load += new System.EventHandler(this.frmLookUpDict_Load);
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGridDict)).EndInit();
            this.pnlCntrls.ResumeLayout(false);
            this.pnlCntrls.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.DataGridView dtGridDict;
        private System.Windows.Forms.Panel pnlCntrls;
        private System.Windows.Forms.TextBox txyCompName;
        private System.Windows.Forms.Label label1;
    }
}