namespace NameToStructureApplication.TaskManagement
{
    partial class frmTaskSheet
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.dtGrid_Assign_TANs = new System.Windows.Forms.DataGridView();
            this.SelectColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.cntMnuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.reportTANStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.curationCompletedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reviewCompletedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tANCompletedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblUserName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrid_Assign_TANs)).BeginInit();
            this.cntMnuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.label2);
            this.pnlMain.Controls.Add(this.dtGrid_Assign_TANs);
            this.pnlMain.Controls.Add(this.lblUserName);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(893, 505);
            this.pnlMain.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Assigned TANs";
            // 
            // dtGrid_Assign_TANs
            // 
            this.dtGrid_Assign_TANs.AllowUserToAddRows = false;
            this.dtGrid_Assign_TANs.AllowUserToDeleteRows = false;
            this.dtGrid_Assign_TANs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtGrid_Assign_TANs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtGrid_Assign_TANs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGrid_Assign_TANs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SelectColumn});
            this.dtGrid_Assign_TANs.ContextMenuStrip = this.cntMnuStrip;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtGrid_Assign_TANs.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtGrid_Assign_TANs.Location = new System.Drawing.Point(12, 63);
            this.dtGrid_Assign_TANs.MultiSelect = false;
            this.dtGrid_Assign_TANs.Name = "dtGrid_Assign_TANs";
            this.dtGrid_Assign_TANs.ReadOnly = true;
            this.dtGrid_Assign_TANs.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dtGrid_Assign_TANs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGrid_Assign_TANs.Size = new System.Drawing.Size(868, 430);
            this.dtGrid_Assign_TANs.TabIndex = 3;
            this.dtGrid_Assign_TANs.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dtGrid_Assign_TANs_RowPostPaint);
            this.dtGrid_Assign_TANs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGrid_Assign_TANs_CellContentClick);
            // 
            // SelectColumn
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.SelectColumn.HeaderText = "Select TAN";
            this.SelectColumn.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.SelectColumn.Name = "SelectColumn";
            this.SelectColumn.ReadOnly = true;
            this.SelectColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SelectColumn.Text = "";
            this.SelectColumn.TrackVisitedState = false;
            // 
            // cntMnuStrip
            // 
            this.cntMnuStrip.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cntMnuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportTANStatusToolStripMenuItem});
            this.cntMnuStrip.Name = "cntMnuStrip";
            this.cntMnuStrip.Size = new System.Drawing.Size(204, 26);
            this.cntMnuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.cntMnuStrip_Opening);
            // 
            // reportTANStatusToolStripMenuItem
            // 
            this.reportTANStatusToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.curationCompletedToolStripMenuItem,
            this.reviewCompletedToolStripMenuItem,
            this.tANCompletedToolStripMenuItem});
            this.reportTANStatusToolStripMenuItem.Name = "reportTANStatusToolStripMenuItem";
            this.reportTANStatusToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.reportTANStatusToolStripMenuItem.Text = "Report TAN Status";
            // 
            // curationCompletedToolStripMenuItem
            // 
            this.curationCompletedToolStripMenuItem.Name = "curationCompletedToolStripMenuItem";
            this.curationCompletedToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.curationCompletedToolStripMenuItem.Text = "Curation Completed";
            this.curationCompletedToolStripMenuItem.Click += new System.EventHandler(this.curationCompletedToolStripMenuItem_Click);
            // 
            // reviewCompletedToolStripMenuItem
            // 
            this.reviewCompletedToolStripMenuItem.Name = "reviewCompletedToolStripMenuItem";
            this.reviewCompletedToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.reviewCompletedToolStripMenuItem.Text = "Review Completed";
            this.reviewCompletedToolStripMenuItem.Click += new System.EventHandler(this.reviewCompletedToolStripMenuItem_Click);
            // 
            // tANCompletedToolStripMenuItem
            // 
            this.tANCompletedToolStripMenuItem.Name = "tANCompletedToolStripMenuItem";
            this.tANCompletedToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.tANCompletedToolStripMenuItem.Text = "Curation and Review Completed";
            this.tANCompletedToolStripMenuItem.Click += new System.EventHandler(this.tANCompletedToolStripMenuItem_Click);
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(103, 13);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(42, 17);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "User Name: ";
            // 
            // frmTaskSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(893, 505);
            this.Controls.Add(this.pnlMain);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTaskSheet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Task Sheet";
            this.Load += new System.EventHandler(this.frmTaskSheet_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrid_Assign_TANs)).EndInit();
            this.cntMnuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtGrid_Assign_TANs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewLinkColumn SelectColumn;
        private System.Windows.Forms.ContextMenuStrip cntMnuStrip;
        private System.Windows.Forms.ToolStripMenuItem reportTANStatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem curationCompletedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reviewCompletedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tANCompletedToolStripMenuItem;
    }
}