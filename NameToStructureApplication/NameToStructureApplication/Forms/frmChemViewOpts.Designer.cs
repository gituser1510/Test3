namespace NameToStructureApplication
{
    partial class frmChemViewOpts
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
            MDL.Draw.Renderer.Preferences.DisplayPreferences displayPreferences1 = new MDL.Draw.Renderer.Preferences.DisplayPreferences();
            MDL.Draw.Renderer.Preferences.DisplayPreferences displayPreferences2 = new MDL.Draw.Renderer.Preferences.DisplayPreferences();
            MDL.Draw.Renderer.Preferences.DisplayPreferences displayPreferences3 = new MDL.Draw.Renderer.Preferences.DisplayPreferences();
            this.renditor_ChemDraw = new MDL.Draw.Renditor.Renditor();
            this.renditor_OpenEye = new MDL.Draw.Renditor.Renditor();
            this.renditor_ChemAxon = new MDL.Draw.Renditor.Renditor();
            this.lblOpenEye = new System.Windows.Forms.Label();
            this.lblChemDraw = new System.Windows.Forms.Label();
            this.lblChemAxon = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.grpOptions = new System.Windows.Forms.GroupBox();
            this.rbnChemAxon = new System.Windows.Forms.RadioButton();
            this.rbnChemDraw = new System.Windows.Forms.RadioButton();
            this.rbnOpenEye = new System.Windows.Forms.RadioButton();
            this.txtError_OpenEye = new System.Windows.Forms.TextBox();
            this.txtError_ChemDraw = new System.Windows.Forms.TextBox();
            this.txtError_ChemAxon = new System.Windows.Forms.TextBox();
            this.pnlCntrls = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.grpOptions.SuspendLayout();
            this.pnlCntrls.SuspendLayout();
            this.SuspendLayout();
            // 
            // renditor_ChemDraw
            // 
            this.renditor_ChemDraw.AutoSizeStructure = true;
            this.renditor_ChemDraw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.renditor_ChemDraw.ChimeString = null;
            this.renditor_ChemDraw.ClearingEnabled = true;
            this.renditor_ChemDraw.CopyingEnabled = true;
            this.renditor_ChemDraw.DisplayOnEmpty = "ChemDraw not supported";
            this.renditor_ChemDraw.EditingEnabled = false;
            this.renditor_ChemDraw.FileName = null;
            this.renditor_ChemDraw.HighlightInfo = null;
            this.renditor_ChemDraw.IsBitmapFromOLE = false;
            this.renditor_ChemDraw.Location = new System.Drawing.Point(317, 25);
            this.renditor_ChemDraw.Metafile = null;
            this.renditor_ChemDraw.Molecule = null;
            this.renditor_ChemDraw.MolfileString = null;
            this.renditor_ChemDraw.Name = "renditor_ChemDraw";
            this.renditor_ChemDraw.OldScalingMode = MDL.Draw.Renderer.Preferences.StructureScalingMode.ScaleToFitBox;
            this.renditor_ChemDraw.PastingEnabled = true;
            this.renditor_ChemDraw.Preferences = displayPreferences1;
            this.renditor_ChemDraw.PreferencesFileName = "default.xml";
            this.renditor_ChemDraw.RendererBorderStyle = System.Windows.Forms.ButtonBorderStyle.Inset;
            this.renditor_ChemDraw.RenditorMolecule = null;
            this.renditor_ChemDraw.RenditorName = "Demo Renditor";
            this.renditor_ChemDraw.Size = new System.Drawing.Size(305, 261);
            this.renditor_ChemDraw.SketchString = null;
            this.renditor_ChemDraw.SmilesString = null;
            this.renditor_ChemDraw.TabIndex = 3;
            this.renditor_ChemDraw.URLEncodedMolfileString = null;
            this.renditor_ChemDraw.UseLocalXMLConfig = false;
            // 
            // renditor_OpenEye
            // 
            this.renditor_OpenEye.AutoSizeStructure = true;
            this.renditor_OpenEye.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.renditor_OpenEye.ChimeString = null;
            this.renditor_OpenEye.ClearingEnabled = true;
            this.renditor_OpenEye.CopyingEnabled = true;
            this.renditor_OpenEye.DisplayOnEmpty = "Open Eye not supported";
            this.renditor_OpenEye.EditingEnabled = false;
            this.renditor_OpenEye.FileName = null;
            this.renditor_OpenEye.HighlightInfo = null;
            this.renditor_OpenEye.IsBitmapFromOLE = false;
            this.renditor_OpenEye.Location = new System.Drawing.Point(7, 25);
            this.renditor_OpenEye.Metafile = null;
            this.renditor_OpenEye.Molecule = null;
            this.renditor_OpenEye.MolfileString = null;
            this.renditor_OpenEye.Name = "renditor_OpenEye";
            this.renditor_OpenEye.OldScalingMode = MDL.Draw.Renderer.Preferences.StructureScalingMode.ScaleToFitBox;
            this.renditor_OpenEye.PastingEnabled = true;
            this.renditor_OpenEye.Preferences = displayPreferences2;
            this.renditor_OpenEye.PreferencesFileName = "default.xml";
            this.renditor_OpenEye.RendererBorderStyle = System.Windows.Forms.ButtonBorderStyle.Inset;
            this.renditor_OpenEye.RenditorMolecule = null;
            this.renditor_OpenEye.RenditorName = "Demo Renditor";
            this.renditor_OpenEye.Size = new System.Drawing.Size(300, 261);
            this.renditor_OpenEye.SketchString = null;
            this.renditor_OpenEye.SmilesString = null;
            this.renditor_OpenEye.TabIndex = 4;
            this.renditor_OpenEye.URLEncodedMolfileString = null;
            this.renditor_OpenEye.UseLocalXMLConfig = false;
            // 
            // renditor_ChemAxon
            // 
            this.renditor_ChemAxon.AutoSizeStructure = true;
            this.renditor_ChemAxon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.renditor_ChemAxon.ChimeString = null;
            this.renditor_ChemAxon.ClearingEnabled = true;
            this.renditor_ChemAxon.CopyingEnabled = true;
            this.renditor_ChemAxon.DisplayOnEmpty = "ChemAxon not supported";
            this.renditor_ChemAxon.EditingEnabled = false;
            this.renditor_ChemAxon.FileName = null;
            this.renditor_ChemAxon.HighlightInfo = null;
            this.renditor_ChemAxon.IsBitmapFromOLE = false;
            this.renditor_ChemAxon.Location = new System.Drawing.Point(630, 25);
            this.renditor_ChemAxon.Metafile = null;
            this.renditor_ChemAxon.Molecule = null;
            this.renditor_ChemAxon.MolfileString = null;
            this.renditor_ChemAxon.Name = "renditor_ChemAxon";
            this.renditor_ChemAxon.OldScalingMode = MDL.Draw.Renderer.Preferences.StructureScalingMode.ScaleToFitBox;
            this.renditor_ChemAxon.PastingEnabled = true;
            this.renditor_ChemAxon.Preferences = displayPreferences3;
            this.renditor_ChemAxon.PreferencesFileName = "default.xml";
            this.renditor_ChemAxon.RendererBorderStyle = System.Windows.Forms.ButtonBorderStyle.Inset;
            this.renditor_ChemAxon.RenditorMolecule = null;
            this.renditor_ChemAxon.RenditorName = "Demo Renditor";
            this.renditor_ChemAxon.Size = new System.Drawing.Size(294, 261);
            this.renditor_ChemAxon.SketchString = null;
            this.renditor_ChemAxon.SmilesString = null;
            this.renditor_ChemAxon.TabIndex = 5;
            this.renditor_ChemAxon.URLEncodedMolfileString = null;
            this.renditor_ChemAxon.UseLocalXMLConfig = false;
            // 
            // lblOpenEye
            // 
            this.lblOpenEye.AutoSize = true;
            this.lblOpenEye.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpenEye.ForeColor = System.Drawing.Color.Blue;
            this.lblOpenEye.Location = new System.Drawing.Point(4, 4);
            this.lblOpenEye.Name = "lblOpenEye";
            this.lblOpenEye.Size = new System.Drawing.Size(73, 17);
            this.lblOpenEye.TabIndex = 6;
            this.lblOpenEye.Text = "Open Eye";
            // 
            // lblChemDraw
            // 
            this.lblChemDraw.AutoSize = true;
            this.lblChemDraw.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChemDraw.ForeColor = System.Drawing.Color.Blue;
            this.lblChemDraw.Location = new System.Drawing.Point(313, 4);
            this.lblChemDraw.Name = "lblChemDraw";
            this.lblChemDraw.Size = new System.Drawing.Size(81, 17);
            this.lblChemDraw.TabIndex = 7;
            this.lblChemDraw.Text = "ChemDraw";
            // 
            // lblChemAxon
            // 
            this.lblChemAxon.AutoSize = true;
            this.lblChemAxon.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChemAxon.ForeColor = System.Drawing.Color.Blue;
            this.lblChemAxon.Location = new System.Drawing.Point(627, 4);
            this.lblChemAxon.Name = "lblChemAxon";
            this.lblChemAxon.Size = new System.Drawing.Size(82, 17);
            this.lblChemAxon.TabIndex = 8;
            this.lblChemAxon.Text = "ChemAxon";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSubmit.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(832, 4);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(91, 26);
            this.btnSubmit.TabIndex = 12;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // grpOptions
            // 
            this.grpOptions.Controls.Add(this.rbnChemAxon);
            this.grpOptions.Controls.Add(this.rbnChemDraw);
            this.grpOptions.Controls.Add(this.rbnOpenEye);
            this.grpOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpOptions.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpOptions.ForeColor = System.Drawing.Color.Blue;
            this.grpOptions.Location = new System.Drawing.Point(155, -4);
            this.grpOptions.Name = "grpOptions";
            this.grpOptions.Size = new System.Drawing.Size(509, 33);
            this.grpOptions.TabIndex = 13;
            this.grpOptions.TabStop = false;
            // 
            // rbnChemAxon
            // 
            this.rbnChemAxon.AutoSize = true;
            this.rbnChemAxon.Location = new System.Drawing.Point(375, 11);
            this.rbnChemAxon.Name = "rbnChemAxon";
            this.rbnChemAxon.Size = new System.Drawing.Size(95, 21);
            this.rbnChemAxon.TabIndex = 2;
            this.rbnChemAxon.Text = "ChemAxon";
            this.rbnChemAxon.UseVisualStyleBackColor = true;
            // 
            // rbnChemDraw
            // 
            this.rbnChemDraw.AutoSize = true;
            this.rbnChemDraw.Location = new System.Drawing.Point(193, 11);
            this.rbnChemDraw.Name = "rbnChemDraw";
            this.rbnChemDraw.Size = new System.Drawing.Size(95, 21);
            this.rbnChemDraw.TabIndex = 1;
            this.rbnChemDraw.Text = "ChemDraw";
            this.rbnChemDraw.UseVisualStyleBackColor = true;
            // 
            // rbnOpenEye
            // 
            this.rbnOpenEye.AutoSize = true;
            this.rbnOpenEye.Checked = true;
            this.rbnOpenEye.Location = new System.Drawing.Point(4, 11);
            this.rbnOpenEye.Name = "rbnOpenEye";
            this.rbnOpenEye.Size = new System.Drawing.Size(89, 21);
            this.rbnOpenEye.TabIndex = 0;
            this.rbnOpenEye.TabStop = true;
            this.rbnOpenEye.Text = " Open Eye";
            this.rbnOpenEye.UseVisualStyleBackColor = true;
            // 
            // txtError_OpenEye
            // 
            this.txtError_OpenEye.BackColor = System.Drawing.Color.White;
            this.txtError_OpenEye.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtError_OpenEye.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtError_OpenEye.ForeColor = System.Drawing.Color.Red;
            this.txtError_OpenEye.Location = new System.Drawing.Point(7, 289);
            this.txtError_OpenEye.Multiline = true;
            this.txtError_OpenEye.Name = "txtError_OpenEye";
            this.txtError_OpenEye.ReadOnly = true;
            this.txtError_OpenEye.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtError_OpenEye.Size = new System.Drawing.Size(300, 38);
            this.txtError_OpenEye.TabIndex = 14;
            this.txtError_OpenEye.Visible = false;
            // 
            // txtError_ChemDraw
            // 
            this.txtError_ChemDraw.BackColor = System.Drawing.Color.White;
            this.txtError_ChemDraw.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtError_ChemDraw.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtError_ChemDraw.ForeColor = System.Drawing.Color.Red;
            this.txtError_ChemDraw.Location = new System.Drawing.Point(317, 289);
            this.txtError_ChemDraw.Multiline = true;
            this.txtError_ChemDraw.Name = "txtError_ChemDraw";
            this.txtError_ChemDraw.ReadOnly = true;
            this.txtError_ChemDraw.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtError_ChemDraw.Size = new System.Drawing.Size(305, 38);
            this.txtError_ChemDraw.TabIndex = 15;
            this.txtError_ChemDraw.Visible = false;
            // 
            // txtError_ChemAxon
            // 
            this.txtError_ChemAxon.BackColor = System.Drawing.Color.White;
            this.txtError_ChemAxon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtError_ChemAxon.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtError_ChemAxon.ForeColor = System.Drawing.Color.Red;
            this.txtError_ChemAxon.Location = new System.Drawing.Point(630, 289);
            this.txtError_ChemAxon.Multiline = true;
            this.txtError_ChemAxon.Name = "txtError_ChemAxon";
            this.txtError_ChemAxon.ReadOnly = true;
            this.txtError_ChemAxon.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtError_ChemAxon.Size = new System.Drawing.Size(294, 38);
            this.txtError_ChemAxon.TabIndex = 16;
            this.txtError_ChemAxon.Visible = false;
            // 
            // pnlCntrls
            // 
            this.pnlCntrls.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlCntrls.Controls.Add(this.label1);
            this.pnlCntrls.Controls.Add(this.btnSubmit);
            this.pnlCntrls.Controls.Add(this.grpOptions);
            this.pnlCntrls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCntrls.Location = new System.Drawing.Point(0, 335);
            this.pnlCntrls.Name = "pnlCntrls";
            this.pnlCntrls.Size = new System.Drawing.Size(930, 37);
            this.pnlCntrls.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(2, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "Select Structure from";
            // 
            // frmChemViewOpts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 372);
            this.Controls.Add(this.pnlCntrls);
            this.Controls.Add(this.txtError_ChemAxon);
            this.Controls.Add(this.txtError_ChemDraw);
            this.Controls.Add(this.txtError_OpenEye);
            this.Controls.Add(this.lblChemAxon);
            this.Controls.Add(this.lblChemDraw);
            this.Controls.Add(this.lblOpenEye);
            this.Controls.Add(this.renditor_ChemAxon);
            this.Controls.Add(this.renditor_OpenEye);
            this.Controls.Add(this.renditor_ChemDraw);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChemViewOpts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View Options";
            this.Load += new System.EventHandler(this.frmChemDraw_Load);
            this.grpOptions.ResumeLayout(false);
            this.grpOptions.PerformLayout();
            this.pnlCntrls.ResumeLayout(false);
            this.pnlCntrls.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MDL.Draw.Renditor.Renditor renditor_ChemDraw;
        private MDL.Draw.Renditor.Renditor renditor_OpenEye;
        private MDL.Draw.Renditor.Renditor renditor_ChemAxon;
        private System.Windows.Forms.Label lblOpenEye;
        private System.Windows.Forms.Label lblChemDraw;
        private System.Windows.Forms.Label lblChemAxon;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.GroupBox grpOptions;
        private System.Windows.Forms.RadioButton rbnChemAxon;
        private System.Windows.Forms.RadioButton rbnChemDraw;
        private System.Windows.Forms.RadioButton rbnOpenEye;
        private System.Windows.Forms.TextBox txtError_OpenEye;
        private System.Windows.Forms.TextBox txtError_ChemDraw;
        private System.Windows.Forms.TextBox txtError_ChemAxon;
        private System.Windows.Forms.Panel pnlCntrls;
        private System.Windows.Forms.Label label1;

    }
}