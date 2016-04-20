namespace NameToStructureApplication.TaskManagement
{
    partial class frmTaskStatus
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
            this.pnlCntrls = new System.Windows.Forms.Panel();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dtGridTskStatus = new System.Windows.Forms.DataGridView();
            this.pnlMain.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridTskStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlGrid);
            this.pnlMain.Controls.Add(this.pnlCntrls);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(856, 514);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlCntrls
            // 
            this.pnlCntrls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCntrls.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCntrls.Location = new System.Drawing.Point(0, 0);
            this.pnlCntrls.Name = "pnlCntrls";
            this.pnlCntrls.Size = new System.Drawing.Size(856, 55);
            this.pnlCntrls.TabIndex = 0;
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.dtGridTskStatus);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 55);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(856, 459);
            this.pnlGrid.TabIndex = 1;
            // 
            // dtGridTskStatus
            // 
            this.dtGridTskStatus.AllowUserToAddRows = false;
            this.dtGridTskStatus.AllowUserToDeleteRows = false;
            this.dtGridTskStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridTskStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGridTskStatus.Location = new System.Drawing.Point(0, 0);
            this.dtGridTskStatus.Name = "dtGridTskStatus";
            this.dtGridTskStatus.ReadOnly = true;
            this.dtGridTskStatus.Size = new System.Drawing.Size(856, 459);
            this.dtGridTskStatus.TabIndex = 0;
            // 
            // frmTaskStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 514);
            this.Controls.Add(this.pnlMain);
            this.Name = "frmTaskStatus";
            this.Text = "Task Status";
            this.pnlMain.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGridTskStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dtGridTskStatus;
        private System.Windows.Forms.Panel pnlCntrls;
    }
}