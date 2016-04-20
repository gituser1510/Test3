namespace NameToStructureApplication.UserControls
{
    partial class ucChemProps_Navigation
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            MDL.Draw.Renderer.Preferences.DisplayPreferences displayPreferences2 = new MDL.Draw.Renderer.Preferences.DisplayPreferences();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.txtIUPACName = new System.Windows.Forms.TextBox();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.chkVerifyV2000 = new System.Windows.Forms.CheckBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelRec = new System.Windows.Forms.Button();
            this.txten_Name = new System.Windows.Forms.TextBox();
            this.lblen_name = new System.Windows.Forms.Label();
            this.txtMolFileNo = new System.Windows.Forms.TextBox();
            this.lblMolFileNo = new System.Windows.Forms.Label();
            this.txtExampleNo = new System.Windows.Forms.TextBox();
            this.lblExampleNo = new System.Windows.Forms.Label();
            this.lblPageLabel = new System.Windows.Forms.Label();
            this.txtPageLabel = new System.Windows.Forms.TextBox();
            this.lblPageNo = new System.Windows.Forms.Label();
            this.txtPageNo = new System.Windows.Forms.TextBox();
            this.lblTanNo = new System.Windows.Forms.Label();
            this.txtTANNo = new System.Windows.Forms.TextBox();
            this.txtMolWeight = new System.Windows.Forms.TextBox();
            this.lblMolWeight = new System.Windows.Forms.Label();
            this.lblMolFormula = new System.Windows.Forms.Label();
            this.txtMolFormula = new System.Windows.Forms.TextBox();
            this.lblIUPAC = new System.Windows.Forms.Label();
            this.pnlNavigation = new System.Windows.Forms.Panel();
            this.lblRecCnt = new System.Windows.Forms.Label();
            this.lblTRecs = new System.Windows.Forms.Label();
            this.pnlNavig = new System.Windows.Forms.Panel();
            this.btnPrev = new System.Windows.Forms.Button();
            this.numGoToRec = new System.Windows.Forms.NumericUpDown();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblChiral = new System.Windows.Forms.Label();
            this.lblStructure = new System.Windows.Forms.Label();
            this.chemRenditor = new MDL.Draw.Renditor.Renditor();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlMain.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.pnlNavigation.SuspendLayout();
            this.pnlNavig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGoToRec)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.Controls.Add(this.txtIUPACName);
            this.pnlMain.Controls.Add(this.pnlButtons);
            this.pnlMain.Controls.Add(this.txten_Name);
            this.pnlMain.Controls.Add(this.lblen_name);
            this.pnlMain.Controls.Add(this.txtMolFileNo);
            this.pnlMain.Controls.Add(this.lblMolFileNo);
            this.pnlMain.Controls.Add(this.txtExampleNo);
            this.pnlMain.Controls.Add(this.lblExampleNo);
            this.pnlMain.Controls.Add(this.lblPageLabel);
            this.pnlMain.Controls.Add(this.txtPageLabel);
            this.pnlMain.Controls.Add(this.lblPageNo);
            this.pnlMain.Controls.Add(this.txtPageNo);
            this.pnlMain.Controls.Add(this.lblTanNo);
            this.pnlMain.Controls.Add(this.txtTANNo);
            this.pnlMain.Controls.Add(this.txtMolWeight);
            this.pnlMain.Controls.Add(this.lblMolWeight);
            this.pnlMain.Controls.Add(this.lblMolFormula);
            this.pnlMain.Controls.Add(this.txtMolFormula);
            this.pnlMain.Controls.Add(this.lblIUPAC);
            this.pnlMain.Controls.Add(this.pnlNavigation);
            this.pnlMain.Controls.Add(this.lblChiral);
            this.pnlMain.Controls.Add(this.lblStructure);
            this.pnlMain.Controls.Add(this.chemRenditor);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(522, 610);
            this.pnlMain.TabIndex = 0;
            // 
            // txtIUPACName
            // 
            this.txtIUPACName.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIUPACName.Location = new System.Drawing.Point(9, 419);
            this.txtIUPACName.Multiline = true;
            this.txtIUPACName.Name = "txtIUPACName";
            this.txtIUPACName.Size = new System.Drawing.Size(505, 47);
            this.txtIUPACName.TabIndex = 48;
            // 
            // pnlButtons
            // 
            this.pnlButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlButtons.Controls.Add(this.chkVerifyV2000);
            this.pnlButtons.Controls.Add(this.btnUpdate);
            this.pnlButtons.Controls.Add(this.btnDelRec);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 575);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(520, 33);
            this.pnlButtons.TabIndex = 47;
            // 
            // chkVerifyV2000
            // 
            this.chkVerifyV2000.AutoSize = true;
            this.chkVerifyV2000.Checked = true;
            this.chkVerifyV2000.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVerifyV2000.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkVerifyV2000.ForeColor = System.Drawing.Color.Blue;
            this.chkVerifyV2000.Location = new System.Drawing.Point(3, 5);
            this.chkVerifyV2000.Name = "chkVerifyV2000";
            this.chkVerifyV2000.Size = new System.Drawing.Size(158, 21);
            this.chkVerifyV2000.TabIndex = 49;
            this.chkVerifyV2000.Text = "Verify V2000 format";
            this.chkVerifyV2000.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkVerifyV2000.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(411, 1);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 29);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelRec
            // 
            this.btnDelRec.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelRec.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelRec.Location = new System.Drawing.Point(296, 2);
            this.btnDelRec.Name = "btnDelRec";
            this.btnDelRec.Size = new System.Drawing.Size(100, 28);
            this.btnDelRec.TabIndex = 45;
            this.btnDelRec.Text = "Delete";
            this.btnDelRec.UseVisualStyleBackColor = true;
            this.btnDelRec.Click += new System.EventHandler(this.btnDelRec_Click);
            // 
            // txten_Name
            // 
            this.txten_Name.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txten_Name.Location = new System.Drawing.Point(8, 489);
            this.txten_Name.Multiline = true;
            this.txten_Name.Name = "txten_Name";
            this.txten_Name.Size = new System.Drawing.Size(505, 59);
            this.txten_Name.TabIndex = 6;
            // 
            // lblen_name
            // 
            this.lblen_name.AutoSize = true;
            this.lblen_name.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblen_name.Location = new System.Drawing.Point(6, 469);
            this.lblen_name.Name = "lblen_name";
            this.lblen_name.Size = new System.Drawing.Size(66, 17);
            this.lblen_name.TabIndex = 44;
            this.lblen_name.Text = "en Name";
            // 
            // txtMolFileNo
            // 
            this.txtMolFileNo.BackColor = System.Drawing.Color.White;
            this.txtMolFileNo.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMolFileNo.ForeColor = System.Drawing.Color.Red;
            this.txtMolFileNo.Location = new System.Drawing.Point(400, 369);
            this.txtMolFileNo.Name = "txtMolFileNo";
            this.txtMolFileNo.ReadOnly = true;
            this.txtMolFileNo.Size = new System.Drawing.Size(113, 25);
            this.txtMolFileNo.TabIndex = 21;
            this.txtMolFileNo.Text = "1";
            this.txtMolFileNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblMolFileNo
            // 
            this.lblMolFileNo.AutoSize = true;
            this.lblMolFileNo.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMolFileNo.Location = new System.Drawing.Point(397, 349);
            this.lblMolFileNo.Name = "lblMolFileNo";
            this.lblMolFileNo.Size = new System.Drawing.Size(82, 17);
            this.lblMolFileNo.TabIndex = 42;
            this.lblMolFileNo.Text = "Molfile No.";
            // 
            // txtExampleNo
            // 
            this.txtExampleNo.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExampleNo.Location = new System.Drawing.Point(400, 318);
            this.txtExampleNo.Name = "txtExampleNo";
            this.txtExampleNo.Size = new System.Drawing.Size(113, 25);
            this.txtExampleNo.TabIndex = 5;
            this.txtExampleNo.Text = "00";
            this.txtExampleNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblExampleNo
            // 
            this.lblExampleNo.AutoSize = true;
            this.lblExampleNo.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExampleNo.Location = new System.Drawing.Point(397, 298);
            this.lblExampleNo.Name = "lblExampleNo";
            this.lblExampleNo.Size = new System.Drawing.Size(92, 17);
            this.lblExampleNo.TabIndex = 40;
            this.lblExampleNo.Text = "Example No.";
            // 
            // lblPageLabel
            // 
            this.lblPageLabel.AutoSize = true;
            this.lblPageLabel.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageLabel.Location = new System.Drawing.Point(397, 247);
            this.lblPageLabel.Name = "lblPageLabel";
            this.lblPageLabel.Size = new System.Drawing.Size(81, 17);
            this.lblPageLabel.TabIndex = 38;
            this.lblPageLabel.Text = "Page Label";
            // 
            // txtPageLabel
            // 
            this.txtPageLabel.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPageLabel.Location = new System.Drawing.Point(400, 267);
            this.txtPageLabel.Name = "txtPageLabel";
            this.txtPageLabel.Size = new System.Drawing.Size(113, 25);
            this.txtPageLabel.TabIndex = 4;
            this.txtPageLabel.Text = "00";
            this.txtPageLabel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblPageNo
            // 
            this.lblPageNo.AutoSize = true;
            this.lblPageNo.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageNo.Location = new System.Drawing.Point(397, 196);
            this.lblPageNo.Name = "lblPageNo";
            this.lblPageNo.Size = new System.Drawing.Size(67, 17);
            this.lblPageNo.TabIndex = 36;
            this.lblPageNo.Text = "Page No.";
            // 
            // txtPageNo
            // 
            this.txtPageNo.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPageNo.Location = new System.Drawing.Point(400, 216);
            this.txtPageNo.Name = "txtPageNo";
            this.txtPageNo.Size = new System.Drawing.Size(113, 25);
            this.txtPageNo.TabIndex = 3;
            this.txtPageNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblTanNo
            // 
            this.lblTanNo.AutoSize = true;
            this.lblTanNo.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTanNo.ForeColor = System.Drawing.Color.Blue;
            this.lblTanNo.Location = new System.Drawing.Point(397, 145);
            this.lblTanNo.Name = "lblTanNo";
            this.lblTanNo.Size = new System.Drawing.Size(67, 17);
            this.lblTanNo.TabIndex = 34;
            this.lblTanNo.Text = "TAN No.";
            // 
            // txtTANNo
            // 
            this.txtTANNo.BackColor = System.Drawing.Color.White;
            this.txtTANNo.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTANNo.ForeColor = System.Drawing.Color.Red;
            this.txtTANNo.Location = new System.Drawing.Point(400, 165);
            this.txtTANNo.Name = "txtTANNo";
            this.txtTANNo.ReadOnly = true;
            this.txtTANNo.Size = new System.Drawing.Size(113, 25);
            this.txtTANNo.TabIndex = 20;
            // 
            // txtMolWeight
            // 
            this.txtMolWeight.BackColor = System.Drawing.Color.White;
            this.txtMolWeight.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMolWeight.ForeColor = System.Drawing.Color.Red;
            this.txtMolWeight.Location = new System.Drawing.Point(400, 114);
            this.txtMolWeight.Name = "txtMolWeight";
            this.txtMolWeight.ReadOnly = true;
            this.txtMolWeight.Size = new System.Drawing.Size(113, 25);
            this.txtMolWeight.TabIndex = 2;
            // 
            // lblMolWeight
            // 
            this.lblMolWeight.AutoSize = true;
            this.lblMolWeight.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMolWeight.ForeColor = System.Drawing.Color.Blue;
            this.lblMolWeight.Location = new System.Drawing.Point(397, 94);
            this.lblMolWeight.Name = "lblMolWeight";
            this.lblMolWeight.Size = new System.Drawing.Size(86, 17);
            this.lblMolWeight.TabIndex = 31;
            this.lblMolWeight.Text = "Mol Weight";
            // 
            // lblMolFormula
            // 
            this.lblMolFormula.AutoSize = true;
            this.lblMolFormula.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMolFormula.ForeColor = System.Drawing.Color.Blue;
            this.lblMolFormula.Location = new System.Drawing.Point(397, 43);
            this.lblMolFormula.Name = "lblMolFormula";
            this.lblMolFormula.Size = new System.Drawing.Size(93, 17);
            this.lblMolFormula.TabIndex = 28;
            this.lblMolFormula.Text = "Mol Formula";
            // 
            // txtMolFormula
            // 
            this.txtMolFormula.BackColor = System.Drawing.Color.White;
            this.txtMolFormula.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMolFormula.ForeColor = System.Drawing.Color.Red;
            this.txtMolFormula.Location = new System.Drawing.Point(400, 63);
            this.txtMolFormula.Name = "txtMolFormula";
            this.txtMolFormula.ReadOnly = true;
            this.txtMolFormula.Size = new System.Drawing.Size(113, 25);
            this.txtMolFormula.TabIndex = 1;
            // 
            // lblIUPAC
            // 
            this.lblIUPAC.AutoSize = true;
            this.lblIUPAC.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIUPAC.ForeColor = System.Drawing.Color.Blue;
            this.lblIUPAC.Location = new System.Drawing.Point(5, 399);
            this.lblIUPAC.Name = "lblIUPAC";
            this.lblIUPAC.Size = new System.Drawing.Size(98, 17);
            this.lblIUPAC.TabIndex = 17;
            this.lblIUPAC.Text = "IUPAC Name";
            // 
            // pnlNavigation
            // 
            this.pnlNavigation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlNavigation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlNavigation.Controls.Add(this.lblRecCnt);
            this.pnlNavigation.Controls.Add(this.lblTRecs);
            this.pnlNavigation.Controls.Add(this.pnlNavig);
            this.pnlNavigation.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNavigation.Location = new System.Drawing.Point(0, 0);
            this.pnlNavigation.Name = "pnlNavigation";
            this.pnlNavigation.Size = new System.Drawing.Size(520, 40);
            this.pnlNavigation.TabIndex = 16;
            // 
            // lblRecCnt
            // 
            this.lblRecCnt.AutoSize = true;
            this.lblRecCnt.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecCnt.ForeColor = System.Drawing.Color.Red;
            this.lblRecCnt.Location = new System.Drawing.Point(122, 9);
            this.lblRecCnt.Name = "lblRecCnt";
            this.lblRecCnt.Size = new System.Drawing.Size(0, 17);
            this.lblRecCnt.TabIndex = 18;
            // 
            // lblTRecs
            // 
            this.lblTRecs.AutoSize = true;
            this.lblTRecs.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTRecs.Location = new System.Drawing.Point(6, 9);
            this.lblTRecs.Name = "lblTRecs";
            this.lblTRecs.Size = new System.Drawing.Size(110, 17);
            this.lblTRecs.TabIndex = 15;
            this.lblTRecs.Text = "Total Records: ";
            // 
            // pnlNavig
            // 
            this.pnlNavig.Controls.Add(this.btnPrev);
            this.pnlNavig.Controls.Add(this.numGoToRec);
            this.pnlNavig.Controls.Add(this.btnFirst);
            this.pnlNavig.Controls.Add(this.btnLast);
            this.pnlNavig.Controls.Add(this.btnNext);
            this.pnlNavig.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlNavig.Location = new System.Drawing.Point(273, 0);
            this.pnlNavig.Name = "pnlNavig";
            this.pnlNavig.Size = new System.Drawing.Size(243, 36);
            this.pnlNavig.TabIndex = 6;
            // 
            // btnPrev
            // 
            this.btnPrev.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrev.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnPrev.Location = new System.Drawing.Point(43, 1);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(39, 34);
            this.btnPrev.TabIndex = 0;
            this.btnPrev.Text = "<";
            this.toolTip1.SetToolTip(this.btnPrev, "Previous Record");
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // numGoToRec
            // 
            this.numGoToRec.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numGoToRec.Location = new System.Drawing.Point(89, 5);
            this.numGoToRec.Name = "numGoToRec";
            this.numGoToRec.Size = new System.Drawing.Size(63, 25);
            this.numGoToRec.TabIndex = 5;
            this.numGoToRec.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numGoToRec.ValueChanged += new System.EventHandler(this.numGoToRec_ValueChanged);
            // 
            // btnFirst
            // 
            this.btnFirst.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFirst.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFirst.Location = new System.Drawing.Point(0, 1);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(39, 34);
            this.btnFirst.TabIndex = 1;
            this.btnFirst.Text = "<<";
            this.toolTip1.SetToolTip(this.btnFirst, "First Record");
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnLast
            // 
            this.btnLast.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLast.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnLast.Location = new System.Drawing.Point(202, 1);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(39, 34);
            this.btnLast.TabIndex = 3;
            this.btnLast.Text = ">>";
            this.toolTip1.SetToolTip(this.btnLast, "Last Record");
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnNext
            // 
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnNext.Location = new System.Drawing.Point(159, 1);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(39, 34);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = " >";
            this.toolTip1.SetToolTip(this.btnNext, "Next Record");
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lblChiral
            // 
            this.lblChiral.AutoSize = true;
            this.lblChiral.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChiral.ForeColor = System.Drawing.Color.Blue;
            this.lblChiral.Location = new System.Drawing.Point(200, 43);
            this.lblChiral.Name = "lblChiral";
            this.lblChiral.Size = new System.Drawing.Size(48, 17);
            this.lblChiral.TabIndex = 15;
            this.lblChiral.Text = "Chiral";
            this.lblChiral.Visible = false;
            // 
            // lblStructure
            // 
            this.lblStructure.AutoSize = true;
            this.lblStructure.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStructure.Location = new System.Drawing.Point(8, 43);
            this.lblStructure.Name = "lblStructure";
            this.lblStructure.Size = new System.Drawing.Size(69, 17);
            this.lblStructure.TabIndex = 14;
            this.lblStructure.Text = "Structure";
            // 
            // chemRenditor
            // 
            this.chemRenditor.AutoSizeStructure = true;
            this.chemRenditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chemRenditor.ChimeString = null;
            this.chemRenditor.ClearingEnabled = true;
            this.chemRenditor.CopyingEnabled = true;
            this.chemRenditor.DisplayOnEmpty = null;
            this.chemRenditor.EditingEnabled = true;
            this.chemRenditor.FileName = null;
            this.chemRenditor.HighlightInfo = null;
            this.chemRenditor.IsBitmapFromOLE = false;
            this.chemRenditor.Location = new System.Drawing.Point(9, 63);
            this.chemRenditor.Metafile = null;
            this.chemRenditor.Molecule = null;
            this.chemRenditor.MolfileString = null;
            this.chemRenditor.Name = "chemRenditor";
            this.chemRenditor.OldScalingMode = MDL.Draw.Renderer.Preferences.StructureScalingMode.ScaleToFitBox;
            this.chemRenditor.PastingEnabled = true;
            this.chemRenditor.Preferences = displayPreferences2;
            this.chemRenditor.PreferencesFileName = "default.xml";
            this.chemRenditor.RendererBorderStyle = System.Windows.Forms.ButtonBorderStyle.Inset;
            this.chemRenditor.RenditorMolecule = null;
            this.chemRenditor.RenditorName = "Demo Renditor";
            this.chemRenditor.Size = new System.Drawing.Size(382, 331);
            this.chemRenditor.SketchString = null;
            this.chemRenditor.SmilesString = null;
            this.chemRenditor.TabIndex = 0;
            this.chemRenditor.URLEncodedMolfileString = null;
            this.chemRenditor.UseLocalXMLConfig = false;
            this.chemRenditor.DoubleClick += new System.EventHandler(this.chemRenditor_DoubleClick);
            this.chemRenditor.StructureChanged += new System.EventHandler(this.chemRenditor_StructureChanged);
            // 
            // ucChemProps_Navigation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Name = "ucChemProps_Navigation";
            this.Size = new System.Drawing.Size(522, 610);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.pnlButtons.PerformLayout();
            this.pnlNavigation.ResumeLayout(false);
            this.pnlNavigation.PerformLayout();
            this.pnlNavig.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numGoToRec)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlNavigation;
        private System.Windows.Forms.Label lblChiral;
        private System.Windows.Forms.Label lblStructure;
        private MDL.Draw.Renditor.Renditor chemRenditor;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Label lblIUPAC;
        private System.Windows.Forms.Label lblMolFormula;
        private System.Windows.Forms.TextBox txtMolFormula;
        private System.Windows.Forms.TextBox txtMolWeight;
        private System.Windows.Forms.Label lblMolWeight;
        private System.Windows.Forms.Label lblTanNo;
        private System.Windows.Forms.TextBox txtTANNo;
        private System.Windows.Forms.Label lblPageNo;
        private System.Windows.Forms.TextBox txtPageNo;
        private System.Windows.Forms.Label lblPageLabel;
        private System.Windows.Forms.TextBox txtPageLabel;
        private System.Windows.Forms.TextBox txtExampleNo;
        private System.Windows.Forms.Label lblExampleNo;
        private System.Windows.Forms.TextBox txtMolFileNo;
        private System.Windows.Forms.Label lblMolFileNo;
        private System.Windows.Forms.TextBox txten_Name;
        private System.Windows.Forms.Label lblen_name;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.NumericUpDown numGoToRec;
        private System.Windows.Forms.Panel pnlNavig;
        private System.Windows.Forms.Button btnDelRec;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Label lblTRecs;
        private System.Windows.Forms.TextBox txtIUPACName;
        private System.Windows.Forms.Label lblRecCnt;
        private System.Windows.Forms.CheckBox chkVerifyV2000;
    }
}
