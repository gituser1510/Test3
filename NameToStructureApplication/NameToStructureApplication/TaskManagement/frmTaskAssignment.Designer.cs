namespace NameToStructureApplication.TaskManagement
{
    partial class frmTaskAssignment
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.dtGridAssigedTANs = new System.Windows.Forms.DataGridView();
            this.lblAssTANS = new System.Windows.Forms.Label();
            this.dtGridSelTANs = new System.Windows.Forms.DataGridView();
            this.dtGrid_TANs = new System.Windows.Forms.DataGridView();
            this.cmbShipment = new System.Windows.Forms.ComboBox();
            this.lblShipment = new System.Windows.Forms.Label();
            this.cmbPhase = new System.Windows.Forms.ComboBox();
            this.lblPhase = new System.Windows.Forms.Label();
            this.lblSelTANs = new System.Windows.Forms.Label();
            this.lblAvailTANs = new System.Windows.Forms.Label();
            this.btnDelOne = new System.Windows.Forms.Button();
            this.btnSelOne = new System.Windows.Forms.Button();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.cmbAssignFor = new System.Windows.Forms.ComboBox();
            this.lblAssTansFor = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAssign = new System.Windows.Forms.Button();
            this.cmbUserRole = new System.Windows.Forms.ComboBox();
            this.lblUserRole = new System.Windows.Forms.Label();
            this.cmbUserName = new System.Windows.Forms.ComboBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridAssigedTANs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridSelTANs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrid_TANs)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.dtGridAssigedTANs);
            this.pnlMain.Controls.Add(this.lblAssTANS);
            this.pnlMain.Controls.Add(this.dtGridSelTANs);
            this.pnlMain.Controls.Add(this.dtGrid_TANs);
            this.pnlMain.Controls.Add(this.cmbShipment);
            this.pnlMain.Controls.Add(this.lblShipment);
            this.pnlMain.Controls.Add(this.cmbPhase);
            this.pnlMain.Controls.Add(this.lblPhase);
            this.pnlMain.Controls.Add(this.lblSelTANs);
            this.pnlMain.Controls.Add(this.lblAvailTANs);
            this.pnlMain.Controls.Add(this.btnDelOne);
            this.pnlMain.Controls.Add(this.btnSelOne);
            this.pnlMain.Controls.Add(this.pnlButtons);
            this.pnlMain.Controls.Add(this.cmbUserRole);
            this.pnlMain.Controls.Add(this.lblUserRole);
            this.pnlMain.Controls.Add(this.cmbUserName);
            this.pnlMain.Controls.Add(this.lblUserName);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(841, 602);
            this.pnlMain.TabIndex = 0;
            // 
            // dtGridAssigedTANs
            // 
            this.dtGridAssigedTANs.AllowUserToAddRows = false;
            this.dtGridAssigedTANs.AllowUserToDeleteRows = false;
            this.dtGridAssigedTANs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridAssigedTANs.Location = new System.Drawing.Point(15, 353);
            this.dtGridAssigedTANs.Name = "dtGridAssigedTANs";
            this.dtGridAssigedTANs.ReadOnly = true;
            this.dtGridAssigedTANs.Size = new System.Drawing.Size(814, 206);
            this.dtGridAssigedTANs.TabIndex = 22;
            // 
            // lblAssTANS
            // 
            this.lblAssTANS.AutoSize = true;
            this.lblAssTANS.Location = new System.Drawing.Point(12, 333);
            this.lblAssTANS.Name = "lblAssTANS";
            this.lblAssTANS.Size = new System.Drawing.Size(103, 17);
            this.lblAssTANS.TabIndex = 21;
            this.lblAssTANS.Text = "Assigned TANs";
            // 
            // dtGridSelTANs
            // 
            this.dtGridSelTANs.AllowUserToAddRows = false;
            this.dtGridSelTANs.AllowUserToDeleteRows = false;
            this.dtGridSelTANs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridSelTANs.Location = new System.Drawing.Point(459, 90);
            this.dtGridSelTANs.Name = "dtGridSelTANs";
            this.dtGridSelTANs.ReadOnly = true;
            this.dtGridSelTANs.Size = new System.Drawing.Size(370, 240);
            this.dtGridSelTANs.TabIndex = 20;
            // 
            // dtGrid_TANs
            // 
            this.dtGrid_TANs.AllowUserToAddRows = false;
            this.dtGrid_TANs.AllowUserToDeleteRows = false;
            this.dtGrid_TANs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGrid_TANs.Location = new System.Drawing.Point(15, 90);
            this.dtGrid_TANs.Name = "dtGrid_TANs";
            this.dtGrid_TANs.ReadOnly = true;
            this.dtGrid_TANs.Size = new System.Drawing.Size(357, 240);
            this.dtGrid_TANs.TabIndex = 19;
            // 
            // cmbShipment
            // 
            this.cmbShipment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShipment.FormattingEnabled = true;
            this.cmbShipment.Location = new System.Drawing.Point(97, 38);
            this.cmbShipment.Name = "cmbShipment";
            this.cmbShipment.Size = new System.Drawing.Size(275, 25);
            this.cmbShipment.TabIndex = 18;
            this.cmbShipment.SelectedIndexChanged += new System.EventHandler(this.cmbShipment_SelectedIndexChanged);
            this.cmbShipment.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmbShipment_MouseDown);
            // 
            // lblShipment
            // 
            this.lblShipment.AutoSize = true;
            this.lblShipment.Location = new System.Drawing.Point(14, 42);
            this.lblShipment.Name = "lblShipment";
            this.lblShipment.Size = new System.Drawing.Size(62, 17);
            this.lblShipment.TabIndex = 17;
            this.lblShipment.Text = "Shipment";
            // 
            // cmbPhase
            // 
            this.cmbPhase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPhase.FormattingEnabled = true;
            this.cmbPhase.Location = new System.Drawing.Point(97, 6);
            this.cmbPhase.Name = "cmbPhase";
            this.cmbPhase.Size = new System.Drawing.Size(275, 25);
            this.cmbPhase.TabIndex = 16;
            this.cmbPhase.SelectedIndexChanged += new System.EventHandler(this.cmbPhase_SelectedIndexChanged);
            this.cmbPhase.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmbPhase_MouseDown);
            // 
            // lblPhase
            // 
            this.lblPhase.AutoSize = true;
            this.lblPhase.Location = new System.Drawing.Point(14, 10);
            this.lblPhase.Name = "lblPhase";
            this.lblPhase.Size = new System.Drawing.Size(44, 17);
            this.lblPhase.TabIndex = 15;
            this.lblPhase.Text = "Phase";
            // 
            // lblSelTANs
            // 
            this.lblSelTANs.AutoSize = true;
            this.lblSelTANs.Location = new System.Drawing.Point(456, 70);
            this.lblSelTANs.Name = "lblSelTANs";
            this.lblSelTANs.Size = new System.Drawing.Size(99, 17);
            this.lblSelTANs.TabIndex = 12;
            this.lblSelTANs.Text = "Selected TANs";
            // 
            // lblAvailTANs
            // 
            this.lblAvailTANs.AutoSize = true;
            this.lblAvailTANs.Location = new System.Drawing.Point(12, 70);
            this.lblAvailTANs.Name = "lblAvailTANs";
            this.lblAvailTANs.Size = new System.Drawing.Size(104, 17);
            this.lblAvailTANs.TabIndex = 11;
            this.lblAvailTANs.Text = "Available TANs";
            // 
            // btnDelOne
            // 
            this.btnDelOne.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelOne.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelOne.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelOne.Location = new System.Drawing.Point(390, 225);
            this.btnDelOne.Name = "btnDelOne";
            this.btnDelOne.Size = new System.Drawing.Size(51, 32);
            this.btnDelOne.TabIndex = 9;
            this.btnDelOne.Text = "<";
            this.toolTip1.SetToolTip(this.btnDelOne, "Remove One");
            this.btnDelOne.UseVisualStyleBackColor = true;
            this.btnDelOne.Click += new System.EventHandler(this.btnDelOne_Click);
            // 
            // btnSelOne
            // 
            this.btnSelOne.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelOne.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelOne.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelOne.Location = new System.Drawing.Point(390, 153);
            this.btnSelOne.Name = "btnSelOne";
            this.btnSelOne.Size = new System.Drawing.Size(51, 32);
            this.btnSelOne.TabIndex = 7;
            this.btnSelOne.Text = ">";
            this.toolTip1.SetToolTip(this.btnSelOne, "Add one");
            this.btnSelOne.UseVisualStyleBackColor = true;
            this.btnSelOne.Click += new System.EventHandler(this.btnSelOne_Click);
            // 
            // pnlButtons
            // 
            this.pnlButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlButtons.Controls.Add(this.cmbAssignFor);
            this.pnlButtons.Controls.Add(this.lblAssTansFor);
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Controls.Add(this.btnAssign);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 565);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(841, 37);
            this.pnlButtons.TabIndex = 5;
            // 
            // cmbAssignFor
            // 
            this.cmbAssignFor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAssignFor.FormattingEnabled = true;
            this.cmbAssignFor.Items.AddRange(new object[] {
            "Assigned for Curation",
            "Assigned for Review",
            "Re-Assigned for Curation",
            "Re-Assigned for Review "});
            this.cmbAssignFor.Location = new System.Drawing.Point(308, 4);
            this.cmbAssignFor.Name = "cmbAssignFor";
            this.cmbAssignFor.Size = new System.Drawing.Size(264, 25);
            this.cmbAssignFor.TabIndex = 5;
            // 
            // lblAssTansFor
            // 
            this.lblAssTansFor.AutoSize = true;
            this.lblAssTansFor.Location = new System.Drawing.Point(138, 9);
            this.lblAssTansFor.Name = "lblAssTansFor";
            this.lblAssTansFor.Size = new System.Drawing.Size(164, 17);
            this.lblAssTansFor.TabIndex = 4;
            this.lblAssTansFor.Text = "Assign Selected TANs for";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(737, 1);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 32);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAssign
            // 
            this.btnAssign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAssign.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAssign.Location = new System.Drawing.Point(627, 1);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(90, 32);
            this.btnAssign.TabIndex = 0;
            this.btnAssign.Text = "Assign";
            this.btnAssign.UseVisualStyleBackColor = true;
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);
            // 
            // cmbUserRole
            // 
            this.cmbUserRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUserRole.FormattingEnabled = true;
            this.cmbUserRole.Location = new System.Drawing.Point(543, 39);
            this.cmbUserRole.Name = "cmbUserRole";
            this.cmbUserRole.Size = new System.Drawing.Size(286, 25);
            this.cmbUserRole.TabIndex = 3;
            // 
            // lblUserRole
            // 
            this.lblUserRole.AutoSize = true;
            this.lblUserRole.Location = new System.Drawing.Point(456, 44);
            this.lblUserRole.Name = "lblUserRole";
            this.lblUserRole.Size = new System.Drawing.Size(68, 17);
            this.lblUserRole.TabIndex = 2;
            this.lblUserRole.Text = "User Role";
            // 
            // cmbUserName
            // 
            this.cmbUserName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUserName.FormattingEnabled = true;
            this.cmbUserName.Location = new System.Drawing.Point(543, 6);
            this.cmbUserName.Name = "cmbUserName";
            this.cmbUserName.Size = new System.Drawing.Size(286, 25);
            this.cmbUserName.TabIndex = 1;
            this.cmbUserName.SelectedValueChanged += new System.EventHandler(this.cmbUserName_SelectedValueChanged);
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(456, 10);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(77, 17);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "User Name";
            // 
            // frmTaskAssignment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(841, 602);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTaskAssignment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Task Assignment";
            this.Load += new System.EventHandler(this.frmTaskAssignment_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridAssigedTANs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridSelTANs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrid_TANs)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.pnlButtons.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAssign;
        private System.Windows.Forms.ComboBox cmbUserRole;
        private System.Windows.Forms.Label lblUserRole;
        private System.Windows.Forms.ComboBox cmbUserName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Button btnDelOne;
        private System.Windows.Forms.Button btnSelOne;
        private System.Windows.Forms.Label lblSelTANs;
        private System.Windows.Forms.Label lblAvailTANs;
        private System.Windows.Forms.ComboBox cmbShipment;
        private System.Windows.Forms.Label lblShipment;
        private System.Windows.Forms.ComboBox cmbPhase;
        private System.Windows.Forms.Label lblPhase;
        private System.Windows.Forms.DataGridView dtGridSelTANs;
        private System.Windows.Forms.DataGridView dtGrid_TANs;
        private System.Windows.Forms.DataGridView dtGridAssigedTANs;
        private System.Windows.Forms.Label lblAssTANS;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox cmbAssignFor;
        private System.Windows.Forms.Label lblAssTansFor;
    }
}