namespace NameToStructureApplication.UserControls
{
    partial class ucCheckDuplicates
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
            MDL.Draw.Renderer.Preferences.DisplayPreferences displayPreferences1 = new MDL.Draw.Renderer.Preferences.DisplayPreferences();
            MDL.Draw.Renderer.Preferences.DisplayPreferences displayPreferences2 = new MDL.Draw.Renderer.Preferences.DisplayPreferences();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.splCont = new System.Windows.Forms.SplitContainer();
            this.cmbEnName = new System.Windows.Forms.ComboBox();
            this.lblEnName_Qry = new System.Windows.Forms.Label();
            this.txtEnName_Qry = new System.Windows.Forms.TextBox();
            this.cmbIUPACName = new System.Windows.Forms.ComboBox();
            this.lblIUPAC_Qry = new System.Windows.Forms.Label();
            this.txtIUPACName_Qry = new System.Windows.Forms.TextBox();
            this.cmbTableNo = new System.Windows.Forms.ComboBox();
            this.lblTableNo_Qry = new System.Windows.Forms.Label();
            this.txtTableNo_Qry = new System.Windows.Forms.TextBox();
            this.cmbExampleNo = new System.Windows.Forms.ComboBox();
            this.lblExampleNo_Qry = new System.Windows.Forms.Label();
            this.txtExampleNo_Qry = new System.Windows.Forms.TextBox();
            this.cmbPageLabel = new System.Windows.Forms.ComboBox();
            this.lblPageLabel_Qry = new System.Windows.Forms.Label();
            this.txtPageLabel_Qry = new System.Windows.Forms.TextBox();
            this.cmbMolFormula = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMolFormula_Qry = new System.Windows.Forms.TextBox();
            this.cmbMolWeight = new System.Windows.Forms.ComboBox();
            this.cmbPageNum = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblMolWeight_qry = new System.Windows.Forms.Label();
            this.txtMolWeight_Qry = new System.Windows.Forms.TextBox();
            this.lblPageNo_Qry = new System.Windows.Forms.Label();
            this.txtPageNum_Qry = new System.Windows.Forms.TextBox();
            this.lblChiral_Qry = new System.Windows.Forms.Label();
            this.pnlBrowse = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTANNumber_Qry = new System.Windows.Forms.TextBox();
            this.lblQryStruct = new System.Windows.Forms.Label();
            this.chemRenditor_Qry = new MDL.Draw.Renditor.Renditor();
            this.pnlDups = new System.Windows.Forms.Panel();
            this.txtIUPACName = new System.Windows.Forms.TextBox();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.chkVerifyV2000 = new System.Windows.Forms.CheckBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelRec = new System.Windows.Forms.Button();
            this.txten_Name = new System.Windows.Forms.TextBox();
            this.lblen_name = new System.Windows.Forms.Label();
            this.txtTableNo = new System.Windows.Forms.TextBox();
            this.lblMolFileNo = new System.Windows.Forms.Label();
            this.txtExampleNo = new System.Windows.Forms.TextBox();
            this.lblExampleNo = new System.Windows.Forms.Label();
            this.lblPageLabel = new System.Windows.Forms.Label();
            this.txtPageLabel = new System.Windows.Forms.TextBox();
            this.lblPageNo = new System.Windows.Forms.Label();
            this.txtPageNo = new System.Windows.Forms.TextBox();
            this.txtMolWeight = new System.Windows.Forms.TextBox();
            this.lblMolWeight = new System.Windows.Forms.Label();
            this.lblMolFormula = new System.Windows.Forms.Label();
            this.txtMolFormula = new System.Windows.Forms.TextBox();
            this.lblIUPAC = new System.Windows.Forms.Label();
            this.pnlNavigation = new System.Windows.Forms.Panel();
            this.lblRecCnt = new System.Windows.Forms.Label();
            this.pnlNavig = new System.Windows.Forms.Panel();
            this.btnPrev = new System.Windows.Forms.Button();
            this.numGoToRec = new System.Windows.Forms.NumericUpDown();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblChiral = new System.Windows.Forms.Label();
            this.lblStructure = new System.Windows.Forms.Label();
            this.chemRenditor_Trgt = new MDL.Draw.Renditor.Renditor();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pnlMain.SuspendLayout();
            this.splCont.Panel1.SuspendLayout();
            this.splCont.Panel2.SuspendLayout();
            this.splCont.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlBrowse.SuspendLayout();
            this.pnlDups.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.pnlNavigation.SuspendLayout();
            this.pnlNavig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGoToRec)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.Controls.Add(this.splCont);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(879, 622);
            this.pnlMain.TabIndex = 0;
            // 
            // splCont
            // 
            this.splCont.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splCont.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splCont.Location = new System.Drawing.Point(0, 0);
            this.splCont.Name = "splCont";
            // 
            // splCont.Panel1
            // 
            this.splCont.Panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.splCont.Panel1.Controls.Add(this.cmbEnName);
            this.splCont.Panel1.Controls.Add(this.lblEnName_Qry);
            this.splCont.Panel1.Controls.Add(this.txtEnName_Qry);
            this.splCont.Panel1.Controls.Add(this.cmbIUPACName);
            this.splCont.Panel1.Controls.Add(this.lblIUPAC_Qry);
            this.splCont.Panel1.Controls.Add(this.txtIUPACName_Qry);
            this.splCont.Panel1.Controls.Add(this.cmbTableNo);
            this.splCont.Panel1.Controls.Add(this.lblTableNo_Qry);
            this.splCont.Panel1.Controls.Add(this.txtTableNo_Qry);
            this.splCont.Panel1.Controls.Add(this.cmbExampleNo);
            this.splCont.Panel1.Controls.Add(this.lblExampleNo_Qry);
            this.splCont.Panel1.Controls.Add(this.txtExampleNo_Qry);
            this.splCont.Panel1.Controls.Add(this.cmbPageLabel);
            this.splCont.Panel1.Controls.Add(this.lblPageLabel_Qry);
            this.splCont.Panel1.Controls.Add(this.txtPageLabel_Qry);
            this.splCont.Panel1.Controls.Add(this.cmbMolFormula);
            this.splCont.Panel1.Controls.Add(this.label4);
            this.splCont.Panel1.Controls.Add(this.txtMolFormula_Qry);
            this.splCont.Panel1.Controls.Add(this.cmbMolWeight);
            this.splCont.Panel1.Controls.Add(this.cmbPageNum);
            this.splCont.Panel1.Controls.Add(this.panel1);
            this.splCont.Panel1.Controls.Add(this.lblMolWeight_qry);
            this.splCont.Panel1.Controls.Add(this.txtMolWeight_Qry);
            this.splCont.Panel1.Controls.Add(this.lblPageNo_Qry);
            this.splCont.Panel1.Controls.Add(this.txtPageNum_Qry);
            this.splCont.Panel1.Controls.Add(this.lblChiral_Qry);
            this.splCont.Panel1.Controls.Add(this.pnlBrowse);
            this.splCont.Panel1.Controls.Add(this.lblQryStruct);
            this.splCont.Panel1.Controls.Add(this.chemRenditor_Qry);
            // 
            // splCont.Panel2
            // 
            this.splCont.Panel2.Controls.Add(this.pnlDups);
            this.splCont.Size = new System.Drawing.Size(877, 620);
            this.splCont.SplitterDistance = 420;
            this.splCont.TabIndex = 0;
            // 
            // cmbEnName
            // 
            this.cmbEnName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEnName.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEnName.FormattingEnabled = true;
            this.cmbEnName.Items.AddRange(new object[] {
            "Equal To",
            "Not Equal To",
            "Like",
            "Not Like"});
            this.cmbEnName.Location = new System.Drawing.Point(6, 463);
            this.cmbEnName.Name = "cmbEnName";
            this.cmbEnName.Size = new System.Drawing.Size(89, 25);
            this.cmbEnName.TabIndex = 16;
            // 
            // lblEnName_Qry
            // 
            this.lblEnName_Qry.AutoSize = true;
            this.lblEnName_Qry.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnName_Qry.Location = new System.Drawing.Point(5, 443);
            this.lblEnName_Qry.Name = "lblEnName_Qry";
            this.lblEnName_Qry.Size = new System.Drawing.Size(66, 17);
            this.lblEnName_Qry.TabIndex = 60;
            this.lblEnName_Qry.Text = "en Name";
            // 
            // txtEnName_Qry
            // 
            this.txtEnName_Qry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEnName_Qry.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEnName_Qry.Location = new System.Drawing.Point(100, 463);
            this.txtEnName_Qry.Multiline = true;
            this.txtEnName_Qry.Name = "txtEnName_Qry";
            this.txtEnName_Qry.Size = new System.Drawing.Size(310, 76);
            this.txtEnName_Qry.TabIndex = 17;
            // 
            // cmbIUPACName
            // 
            this.cmbIUPACName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIUPACName.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbIUPACName.FormattingEnabled = true;
            this.cmbIUPACName.Items.AddRange(new object[] {
            "Equal To",
            "Not Equal To",
            "Like",
            "Not Like"});
            this.cmbIUPACName.Location = new System.Drawing.Point(5, 374);
            this.cmbIUPACName.Name = "cmbIUPACName";
            this.cmbIUPACName.Size = new System.Drawing.Size(89, 25);
            this.cmbIUPACName.TabIndex = 14;
            // 
            // lblIUPAC_Qry
            // 
            this.lblIUPAC_Qry.AutoSize = true;
            this.lblIUPAC_Qry.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIUPAC_Qry.Location = new System.Drawing.Point(5, 354);
            this.lblIUPAC_Qry.Name = "lblIUPAC_Qry";
            this.lblIUPAC_Qry.Size = new System.Drawing.Size(98, 17);
            this.lblIUPAC_Qry.TabIndex = 57;
            this.lblIUPAC_Qry.Text = "IUPAC Name";
            // 
            // txtIUPACName_Qry
            // 
            this.txtIUPACName_Qry.AcceptsReturn = true;
            this.txtIUPACName_Qry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIUPACName_Qry.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIUPACName_Qry.Location = new System.Drawing.Point(99, 374);
            this.txtIUPACName_Qry.Multiline = true;
            this.txtIUPACName_Qry.Name = "txtIUPACName_Qry";
            this.txtIUPACName_Qry.Size = new System.Drawing.Size(311, 76);
            this.txtIUPACName_Qry.TabIndex = 15;
            // 
            // cmbTableNo
            // 
            this.cmbTableNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTableNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTableNo.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTableNo.FormattingEnabled = true;
            this.cmbTableNo.Items.AddRange(new object[] {
            "Equal To",
            "Not Equal To",
            "Like",
            "Not Like"});
            this.cmbTableNo.Location = new System.Drawing.Point(205, 318);
            this.cmbTableNo.Name = "cmbTableNo";
            this.cmbTableNo.Size = new System.Drawing.Size(89, 25);
            this.cmbTableNo.TabIndex = 12;
            // 
            // lblTableNo_Qry
            // 
            this.lblTableNo_Qry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTableNo_Qry.AutoSize = true;
            this.lblTableNo_Qry.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTableNo_Qry.Location = new System.Drawing.Point(205, 298);
            this.lblTableNo_Qry.Name = "lblTableNo_Qry";
            this.lblTableNo_Qry.Size = new System.Drawing.Size(72, 17);
            this.lblTableNo_Qry.TabIndex = 54;
            this.lblTableNo_Qry.Text = "Table No.";
            // 
            // txtTableNo_Qry
            // 
            this.txtTableNo_Qry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTableNo_Qry.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTableNo_Qry.Location = new System.Drawing.Point(300, 318);
            this.txtTableNo_Qry.Name = "txtTableNo_Qry";
            this.txtTableNo_Qry.Size = new System.Drawing.Size(110, 25);
            this.txtTableNo_Qry.TabIndex = 13;
            // 
            // cmbExampleNo
            // 
            this.cmbExampleNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbExampleNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbExampleNo.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbExampleNo.FormattingEnabled = true;
            this.cmbExampleNo.Items.AddRange(new object[] {
            "Equal To",
            "Not Equal To",
            "Like",
            "Not Like"});
            this.cmbExampleNo.Location = new System.Drawing.Point(205, 267);
            this.cmbExampleNo.Name = "cmbExampleNo";
            this.cmbExampleNo.Size = new System.Drawing.Size(89, 25);
            this.cmbExampleNo.TabIndex = 10;
            // 
            // lblExampleNo_Qry
            // 
            this.lblExampleNo_Qry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExampleNo_Qry.AutoSize = true;
            this.lblExampleNo_Qry.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExampleNo_Qry.Location = new System.Drawing.Point(205, 248);
            this.lblExampleNo_Qry.Name = "lblExampleNo_Qry";
            this.lblExampleNo_Qry.Size = new System.Drawing.Size(88, 17);
            this.lblExampleNo_Qry.TabIndex = 51;
            this.lblExampleNo_Qry.Text = "ExampleNo.";
            // 
            // txtExampleNo_Qry
            // 
            this.txtExampleNo_Qry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExampleNo_Qry.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExampleNo_Qry.Location = new System.Drawing.Point(300, 267);
            this.txtExampleNo_Qry.Name = "txtExampleNo_Qry";
            this.txtExampleNo_Qry.Size = new System.Drawing.Size(110, 25);
            this.txtExampleNo_Qry.TabIndex = 11;
            // 
            // cmbPageLabel
            // 
            this.cmbPageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPageLabel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPageLabel.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPageLabel.FormattingEnabled = true;
            this.cmbPageLabel.Items.AddRange(new object[] {
            "Equal To",
            "Not Equal To",
            "Like",
            "Not Like"});
            this.cmbPageLabel.Location = new System.Drawing.Point(205, 218);
            this.cmbPageLabel.Name = "cmbPageLabel";
            this.cmbPageLabel.Size = new System.Drawing.Size(89, 25);
            this.cmbPageLabel.TabIndex = 8;
            // 
            // lblPageLabel_Qry
            // 
            this.lblPageLabel_Qry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPageLabel_Qry.AutoSize = true;
            this.lblPageLabel_Qry.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageLabel_Qry.Location = new System.Drawing.Point(205, 198);
            this.lblPageLabel_Qry.Name = "lblPageLabel_Qry";
            this.lblPageLabel_Qry.Size = new System.Drawing.Size(81, 17);
            this.lblPageLabel_Qry.TabIndex = 48;
            this.lblPageLabel_Qry.Text = "Page Label";
            // 
            // txtPageLabel_Qry
            // 
            this.txtPageLabel_Qry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPageLabel_Qry.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPageLabel_Qry.Location = new System.Drawing.Point(300, 218);
            this.txtPageLabel_Qry.Name = "txtPageLabel_Qry";
            this.txtPageLabel_Qry.Size = new System.Drawing.Size(110, 25);
            this.txtPageLabel_Qry.TabIndex = 9;
            // 
            // cmbMolFormula
            // 
            this.cmbMolFormula.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbMolFormula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMolFormula.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMolFormula.FormattingEnabled = true;
            this.cmbMolFormula.Items.AddRange(new object[] {
            "Equal To",
            "Not Equal To",
            "In",
            "Not In",
            "Like",
            "Not Like"});
            this.cmbMolFormula.Location = new System.Drawing.Point(205, 65);
            this.cmbMolFormula.Name = "cmbMolFormula";
            this.cmbMolFormula.Size = new System.Drawing.Size(89, 25);
            this.cmbMolFormula.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(205, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 17);
            this.label4.TabIndex = 45;
            this.label4.Text = "Mol Formula";
            // 
            // txtMolFormula_Qry
            // 
            this.txtMolFormula_Qry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMolFormula_Qry.BackColor = System.Drawing.Color.White;
            this.txtMolFormula_Qry.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMolFormula_Qry.ForeColor = System.Drawing.Color.Red;
            this.txtMolFormula_Qry.Location = new System.Drawing.Point(300, 65);
            this.txtMolFormula_Qry.Name = "txtMolFormula_Qry";
            this.txtMolFormula_Qry.Size = new System.Drawing.Size(110, 25);
            this.txtMolFormula_Qry.TabIndex = 3;
            // 
            // cmbMolWeight
            // 
            this.cmbMolWeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbMolWeight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMolWeight.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMolWeight.FormattingEnabled = true;
            this.cmbMolWeight.Items.AddRange(new object[] {
            "=",
            "!=",
            ">",
            ">=",
            "<",
            "<="});
            this.cmbMolWeight.Location = new System.Drawing.Point(205, 116);
            this.cmbMolWeight.Name = "cmbMolWeight";
            this.cmbMolWeight.Size = new System.Drawing.Size(89, 25);
            this.cmbMolWeight.TabIndex = 4;
            // 
            // cmbPageNum
            // 
            this.cmbPageNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPageNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPageNum.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPageNum.FormattingEnabled = true;
            this.cmbPageNum.Items.AddRange(new object[] {
            "=",
            "!=",
            ">",
            ">=",
            "<",
            "<="});
            this.cmbPageNum.Location = new System.Drawing.Point(205, 167);
            this.cmbPageNum.Name = "cmbPageNum";
            this.cmbPageNum.Size = new System.Drawing.Size(89, 25);
            this.cmbPageNum.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 582);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(416, 34);
            this.panel1.TabIndex = 41;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(313, 1);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(95, 29);
            this.btnSearch.TabIndex = 18;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblMolWeight_qry
            // 
            this.lblMolWeight_qry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMolWeight_qry.AutoSize = true;
            this.lblMolWeight_qry.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMolWeight_qry.ForeColor = System.Drawing.Color.Blue;
            this.lblMolWeight_qry.Location = new System.Drawing.Point(205, 96);
            this.lblMolWeight_qry.Name = "lblMolWeight_qry";
            this.lblMolWeight_qry.Size = new System.Drawing.Size(86, 17);
            this.lblMolWeight_qry.TabIndex = 40;
            this.lblMolWeight_qry.Text = "Mol Weight";
            // 
            // txtMolWeight_Qry
            // 
            this.txtMolWeight_Qry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMolWeight_Qry.BackColor = System.Drawing.Color.White;
            this.txtMolWeight_Qry.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMolWeight_Qry.ForeColor = System.Drawing.Color.Red;
            this.txtMolWeight_Qry.Location = new System.Drawing.Point(300, 116);
            this.txtMolWeight_Qry.Name = "txtMolWeight_Qry";
            this.txtMolWeight_Qry.Size = new System.Drawing.Size(110, 25);
            this.txtMolWeight_Qry.TabIndex = 5;
            // 
            // lblPageNo_Qry
            // 
            this.lblPageNo_Qry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPageNo_Qry.AutoSize = true;
            this.lblPageNo_Qry.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageNo_Qry.Location = new System.Drawing.Point(205, 147);
            this.lblPageNo_Qry.Name = "lblPageNo_Qry";
            this.lblPageNo_Qry.Size = new System.Drawing.Size(67, 17);
            this.lblPageNo_Qry.TabIndex = 38;
            this.lblPageNo_Qry.Text = "Page No.";
            // 
            // txtPageNum_Qry
            // 
            this.txtPageNum_Qry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPageNum_Qry.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPageNum_Qry.Location = new System.Drawing.Point(300, 167);
            this.txtPageNum_Qry.Name = "txtPageNum_Qry";
            this.txtPageNum_Qry.Size = new System.Drawing.Size(110, 25);
            this.txtPageNum_Qry.TabIndex = 7;
            // 
            // lblChiral_Qry
            // 
            this.lblChiral_Qry.AutoSize = true;
            this.lblChiral_Qry.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChiral_Qry.ForeColor = System.Drawing.Color.Blue;
            this.lblChiral_Qry.Location = new System.Drawing.Point(148, 44);
            this.lblChiral_Qry.Name = "lblChiral_Qry";
            this.lblChiral_Qry.Size = new System.Drawing.Size(48, 17);
            this.lblChiral_Qry.TabIndex = 21;
            this.lblChiral_Qry.Text = "Chiral";
            this.lblChiral_Qry.Visible = false;
            // 
            // pnlBrowse
            // 
            this.pnlBrowse.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBrowse.Controls.Add(this.label1);
            this.pnlBrowse.Controls.Add(this.txtTANNumber_Qry);
            this.pnlBrowse.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBrowse.Location = new System.Drawing.Point(0, 0);
            this.pnlBrowse.Name = "pnlBrowse";
            this.pnlBrowse.Size = new System.Drawing.Size(416, 41);
            this.pnlBrowse.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Specify TAN";
            // 
            // txtTANNumber_Qry
            // 
            this.txtTANNumber_Qry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTANNumber_Qry.BackColor = System.Drawing.Color.White;
            this.txtTANNumber_Qry.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTANNumber_Qry.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTANNumber_Qry.ForeColor = System.Drawing.Color.Red;
            this.txtTANNumber_Qry.Location = new System.Drawing.Point(98, 6);
            this.txtTANNumber_Qry.Name = "txtTANNumber_Qry";
            this.txtTANNumber_Qry.Size = new System.Drawing.Size(194, 25);
            this.txtTANNumber_Qry.TabIndex = 0;
            // 
            // lblQryStruct
            // 
            this.lblQryStruct.AutoSize = true;
            this.lblQryStruct.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQryStruct.Location = new System.Drawing.Point(3, 44);
            this.lblQryStruct.Name = "lblQryStruct";
            this.lblQryStruct.Size = new System.Drawing.Size(114, 17);
            this.lblQryStruct.TabIndex = 18;
            this.lblQryStruct.Text = "Query Structure";
            // 
            // chemRenditor_Qry
            // 
            this.chemRenditor_Qry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chemRenditor_Qry.AutoSizeStructure = true;
            this.chemRenditor_Qry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chemRenditor_Qry.ChimeString = null;
            this.chemRenditor_Qry.ClearingEnabled = true;
            this.chemRenditor_Qry.CopyingEnabled = true;
            this.chemRenditor_Qry.DisplayOnEmpty = null;
            this.chemRenditor_Qry.EditingEnabled = true;
            this.chemRenditor_Qry.FileName = null;
            this.chemRenditor_Qry.HighlightInfo = null;
            this.chemRenditor_Qry.IsBitmapFromOLE = false;
            this.chemRenditor_Qry.Location = new System.Drawing.Point(6, 64);
            this.chemRenditor_Qry.Metafile = null;
            this.chemRenditor_Qry.Molecule = null;
            this.chemRenditor_Qry.MolfileString = null;
            this.chemRenditor_Qry.Name = "chemRenditor_Qry";
            this.chemRenditor_Qry.OldScalingMode = MDL.Draw.Renderer.Preferences.StructureScalingMode.ScaleToFitBox;
            this.chemRenditor_Qry.PastingEnabled = true;
            this.chemRenditor_Qry.Preferences = displayPreferences1;
            this.chemRenditor_Qry.PreferencesFileName = "default.xml";
            this.chemRenditor_Qry.RendererBorderStyle = System.Windows.Forms.ButtonBorderStyle.Inset;
            this.chemRenditor_Qry.RenditorMolecule = null;
            this.chemRenditor_Qry.RenditorName = "Demo Renditor";
            this.chemRenditor_Qry.Size = new System.Drawing.Size(193, 279);
            this.chemRenditor_Qry.SketchString = null;
            this.chemRenditor_Qry.SmilesString = null;
            this.chemRenditor_Qry.TabIndex = 1;
            this.chemRenditor_Qry.URLEncodedMolfileString = null;
            this.chemRenditor_Qry.UseLocalXMLConfig = false;
            this.chemRenditor_Qry.StructureChanged += new System.EventHandler(this.chemRenditor_Qry_StructureChanged);
            // 
            // pnlDups
            // 
            this.pnlDups.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlDups.Controls.Add(this.txtIUPACName);
            this.pnlDups.Controls.Add(this.pnlButtons);
            this.pnlDups.Controls.Add(this.txten_Name);
            this.pnlDups.Controls.Add(this.lblen_name);
            this.pnlDups.Controls.Add(this.txtTableNo);
            this.pnlDups.Controls.Add(this.lblMolFileNo);
            this.pnlDups.Controls.Add(this.txtExampleNo);
            this.pnlDups.Controls.Add(this.lblExampleNo);
            this.pnlDups.Controls.Add(this.lblPageLabel);
            this.pnlDups.Controls.Add(this.txtPageLabel);
            this.pnlDups.Controls.Add(this.lblPageNo);
            this.pnlDups.Controls.Add(this.txtPageNo);
            this.pnlDups.Controls.Add(this.txtMolWeight);
            this.pnlDups.Controls.Add(this.lblMolWeight);
            this.pnlDups.Controls.Add(this.lblMolFormula);
            this.pnlDups.Controls.Add(this.txtMolFormula);
            this.pnlDups.Controls.Add(this.lblIUPAC);
            this.pnlDups.Controls.Add(this.pnlNavigation);
            this.pnlDups.Controls.Add(this.lblChiral);
            this.pnlDups.Controls.Add(this.lblStructure);
            this.pnlDups.Controls.Add(this.chemRenditor_Trgt);
            this.pnlDups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDups.Location = new System.Drawing.Point(0, 0);
            this.pnlDups.Name = "pnlDups";
            this.pnlDups.Size = new System.Drawing.Size(449, 616);
            this.pnlDups.TabIndex = 1;
            // 
            // txtIUPACName
            // 
            this.txtIUPACName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIUPACName.BackColor = System.Drawing.Color.White;
            this.txtIUPACName.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIUPACName.Location = new System.Drawing.Point(10, 373);
            this.txtIUPACName.Multiline = true;
            this.txtIUPACName.Name = "txtIUPACName";
            this.txtIUPACName.ReadOnly = true;
            this.txtIUPACName.Size = new System.Drawing.Size(432, 66);
            this.txtIUPACName.TabIndex = 48;
            // 
            // pnlButtons
            // 
            this.pnlButtons.BackColor = System.Drawing.Color.Silver;
            this.pnlButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlButtons.Controls.Add(this.chkVerifyV2000);
            this.pnlButtons.Controls.Add(this.btnUpdate);
            this.pnlButtons.Controls.Add(this.btnDelRec);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 583);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(449, 33);
            this.pnlButtons.TabIndex = 47;
            // 
            // chkVerifyV2000
            // 
            this.chkVerifyV2000.AutoSize = true;
            this.chkVerifyV2000.Checked = true;
            this.chkVerifyV2000.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVerifyV2000.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkVerifyV2000.ForeColor = System.Drawing.Color.Blue;
            this.chkVerifyV2000.Location = new System.Drawing.Point(9, 3);
            this.chkVerifyV2000.Name = "chkVerifyV2000";
            this.chkVerifyV2000.Size = new System.Drawing.Size(158, 21);
            this.chkVerifyV2000.TabIndex = 51;
            this.chkVerifyV2000.Text = "Verify V2000 format";
            this.chkVerifyV2000.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkVerifyV2000.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(339, 1);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 29);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelRec
            // 
            this.btnDelRec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelRec.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelRec.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelRec.Location = new System.Drawing.Point(220, 1);
            this.btnDelRec.Name = "btnDelRec";
            this.btnDelRec.Size = new System.Drawing.Size(100, 28);
            this.btnDelRec.TabIndex = 45;
            this.btnDelRec.Text = "Delete";
            this.btnDelRec.UseVisualStyleBackColor = true;
            this.btnDelRec.Click += new System.EventHandler(this.btnDelRec_Click);
            // 
            // txten_Name
            // 
            this.txten_Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txten_Name.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txten_Name.Location = new System.Drawing.Point(10, 462);
            this.txten_Name.Multiline = true;
            this.txten_Name.Name = "txten_Name";
            this.txten_Name.Size = new System.Drawing.Size(432, 76);
            this.txten_Name.TabIndex = 6;
            // 
            // lblen_name
            // 
            this.lblen_name.AutoSize = true;
            this.lblen_name.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblen_name.Location = new System.Drawing.Point(8, 442);
            this.lblen_name.Name = "lblen_name";
            this.lblen_name.Size = new System.Drawing.Size(66, 17);
            this.lblen_name.TabIndex = 44;
            this.lblen_name.Text = "en Name";
            // 
            // txtTableNo
            // 
            this.txtTableNo.BackColor = System.Drawing.Color.White;
            this.txtTableNo.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTableNo.ForeColor = System.Drawing.Color.Black;
            this.txtTableNo.Location = new System.Drawing.Point(328, 317);
            this.txtTableNo.Name = "txtTableNo";
            this.txtTableNo.ReadOnly = true;
            this.txtTableNo.Size = new System.Drawing.Size(113, 25);
            this.txtTableNo.TabIndex = 21;
            this.txtTableNo.Text = "00";
            this.txtTableNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblMolFileNo
            // 
            this.lblMolFileNo.AutoSize = true;
            this.lblMolFileNo.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMolFileNo.Location = new System.Drawing.Point(325, 297);
            this.lblMolFileNo.Name = "lblMolFileNo";
            this.lblMolFileNo.Size = new System.Drawing.Size(72, 17);
            this.lblMolFileNo.TabIndex = 42;
            this.lblMolFileNo.Text = "Table No.";
            // 
            // txtExampleNo
            // 
            this.txtExampleNo.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExampleNo.Location = new System.Drawing.Point(328, 266);
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
            this.lblExampleNo.Location = new System.Drawing.Point(325, 246);
            this.lblExampleNo.Name = "lblExampleNo";
            this.lblExampleNo.Size = new System.Drawing.Size(92, 17);
            this.lblExampleNo.TabIndex = 40;
            this.lblExampleNo.Text = "Example No.";
            // 
            // lblPageLabel
            // 
            this.lblPageLabel.AutoSize = true;
            this.lblPageLabel.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageLabel.Location = new System.Drawing.Point(325, 195);
            this.lblPageLabel.Name = "lblPageLabel";
            this.lblPageLabel.Size = new System.Drawing.Size(81, 17);
            this.lblPageLabel.TabIndex = 38;
            this.lblPageLabel.Text = "Page Label";
            // 
            // txtPageLabel
            // 
            this.txtPageLabel.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPageLabel.Location = new System.Drawing.Point(328, 215);
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
            this.lblPageNo.Location = new System.Drawing.Point(325, 144);
            this.lblPageNo.Name = "lblPageNo";
            this.lblPageNo.Size = new System.Drawing.Size(67, 17);
            this.lblPageNo.TabIndex = 36;
            this.lblPageNo.Text = "Page No.";
            // 
            // txtPageNo
            // 
            this.txtPageNo.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPageNo.Location = new System.Drawing.Point(328, 164);
            this.txtPageNo.Name = "txtPageNo";
            this.txtPageNo.Size = new System.Drawing.Size(113, 25);
            this.txtPageNo.TabIndex = 3;
            this.txtPageNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtMolWeight
            // 
            this.txtMolWeight.BackColor = System.Drawing.Color.White;
            this.txtMolWeight.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMolWeight.ForeColor = System.Drawing.Color.Red;
            this.txtMolWeight.Location = new System.Drawing.Point(328, 114);
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
            this.lblMolWeight.Location = new System.Drawing.Point(325, 94);
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
            this.lblMolFormula.Location = new System.Drawing.Point(325, 43);
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
            this.txtMolFormula.Location = new System.Drawing.Point(328, 63);
            this.txtMolFormula.Name = "txtMolFormula";
            this.txtMolFormula.ReadOnly = true;
            this.txtMolFormula.Size = new System.Drawing.Size(113, 25);
            this.txtMolFormula.TabIndex = 1;
            // 
            // lblIUPAC
            // 
            this.lblIUPAC.AutoSize = true;
            this.lblIUPAC.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIUPAC.Location = new System.Drawing.Point(6, 353);
            this.lblIUPAC.Name = "lblIUPAC";
            this.lblIUPAC.Size = new System.Drawing.Size(98, 17);
            this.lblIUPAC.TabIndex = 17;
            this.lblIUPAC.Text = "IUPAC Name";
            // 
            // pnlNavigation
            // 
            this.pnlNavigation.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlNavigation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlNavigation.Controls.Add(this.lblRecCnt);
            this.pnlNavigation.Controls.Add(this.pnlNavig);
            this.pnlNavigation.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNavigation.Location = new System.Drawing.Point(0, 0);
            this.pnlNavigation.Name = "pnlNavigation";
            this.pnlNavigation.Size = new System.Drawing.Size(449, 40);
            this.pnlNavigation.TabIndex = 16;
            // 
            // lblRecCnt
            // 
            this.lblRecCnt.AutoSize = true;
            this.lblRecCnt.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecCnt.ForeColor = System.Drawing.Color.Red;
            this.lblRecCnt.Location = new System.Drawing.Point(6, 9);
            this.lblRecCnt.Name = "lblRecCnt";
            this.lblRecCnt.Size = new System.Drawing.Size(0, 17);
            this.lblRecCnt.TabIndex = 15;
            // 
            // pnlNavig
            // 
            this.pnlNavig.Controls.Add(this.btnPrev);
            this.pnlNavig.Controls.Add(this.numGoToRec);
            this.pnlNavig.Controls.Add(this.btnFirst);
            this.pnlNavig.Controls.Add(this.btnLast);
            this.pnlNavig.Controls.Add(this.btnNext);
            this.pnlNavig.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlNavig.Location = new System.Drawing.Point(202, 0);
            this.pnlNavig.Name = "pnlNavig";
            this.pnlNavig.Size = new System.Drawing.Size(243, 36);
            this.pnlNavig.TabIndex = 6;
            // 
            // btnPrev
            // 
            this.btnPrev.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrev.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnPrev.Location = new System.Drawing.Point(45, 1);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(39, 34);
            this.btnPrev.TabIndex = 0;
            this.btnPrev.Text = "<";
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
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnNext
            // 
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnNext.Location = new System.Drawing.Point(157, 1);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(39, 34);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = " >";
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
            this.lblStructure.Size = new System.Drawing.Size(117, 17);
            this.lblStructure.TabIndex = 14;
            this.lblStructure.Text = "Target Structure";
            // 
            // chemRenditor_Trgt
            // 
            this.chemRenditor_Trgt.AutoSizeStructure = true;
            this.chemRenditor_Trgt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chemRenditor_Trgt.ChimeString = null;
            this.chemRenditor_Trgt.ClearingEnabled = true;
            this.chemRenditor_Trgt.CopyingEnabled = true;
            this.chemRenditor_Trgt.DisplayOnEmpty = null;
            this.chemRenditor_Trgt.EditingEnabled = true;
            this.chemRenditor_Trgt.FileName = null;
            this.chemRenditor_Trgt.HighlightInfo = null;
            this.chemRenditor_Trgt.IsBitmapFromOLE = false;
            this.chemRenditor_Trgt.Location = new System.Drawing.Point(9, 63);
            this.chemRenditor_Trgt.Metafile = null;
            this.chemRenditor_Trgt.Molecule = null;
            this.chemRenditor_Trgt.MolfileString = null;
            this.chemRenditor_Trgt.Name = "chemRenditor_Trgt";
            this.chemRenditor_Trgt.OldScalingMode = MDL.Draw.Renderer.Preferences.StructureScalingMode.ScaleToFitBox;
            this.chemRenditor_Trgt.PastingEnabled = true;
            this.chemRenditor_Trgt.Preferences = displayPreferences2;
            this.chemRenditor_Trgt.PreferencesFileName = "default.xml";
            this.chemRenditor_Trgt.RendererBorderStyle = System.Windows.Forms.ButtonBorderStyle.Inset;
            this.chemRenditor_Trgt.RenditorMolecule = null;
            this.chemRenditor_Trgt.RenditorName = "Demo Renditor";
            this.chemRenditor_Trgt.Size = new System.Drawing.Size(313, 279);
            this.chemRenditor_Trgt.SketchString = null;
            this.chemRenditor_Trgt.SmilesString = null;
            this.chemRenditor_Trgt.TabIndex = 0;
            this.chemRenditor_Trgt.URLEncodedMolfileString = null;
            this.chemRenditor_Trgt.UseLocalXMLConfig = false;
            this.chemRenditor_Trgt.StructureChanged += new System.EventHandler(this.chemRenditor_Trgt_StructureChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // ucCheckDuplicates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Name = "ucCheckDuplicates";
            this.Size = new System.Drawing.Size(879, 622);
            this.Load += new System.EventHandler(this.ucCheckDuplicates_Load);
            this.pnlMain.ResumeLayout(false);
            this.splCont.Panel1.ResumeLayout(false);
            this.splCont.Panel1.PerformLayout();
            this.splCont.Panel2.ResumeLayout(false);
            this.splCont.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlBrowse.ResumeLayout(false);
            this.pnlBrowse.PerformLayout();
            this.pnlDups.ResumeLayout(false);
            this.pnlDups.PerformLayout();
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
        private System.Windows.Forms.SplitContainer splCont;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelRec;
        private System.Windows.Forms.TextBox txten_Name;
        private System.Windows.Forms.Label lblen_name;
        private System.Windows.Forms.TextBox txtTableNo;
        private System.Windows.Forms.Label lblMolFileNo;
        private System.Windows.Forms.TextBox txtExampleNo;
        private System.Windows.Forms.Label lblExampleNo;
        private System.Windows.Forms.Label lblPageLabel;
        private System.Windows.Forms.TextBox txtPageLabel;
        private System.Windows.Forms.Label lblPageNo;
        private System.Windows.Forms.TextBox txtPageNo;
        private System.Windows.Forms.TextBox txtMolWeight;
        private System.Windows.Forms.Label lblMolWeight;
        private System.Windows.Forms.Label lblMolFormula;
        private System.Windows.Forms.TextBox txtMolFormula;
        private System.Windows.Forms.Label lblIUPAC;
        private System.Windows.Forms.Panel pnlNavigation;
        private System.Windows.Forms.Label lblRecCnt;
        private System.Windows.Forms.Panel pnlNavig;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.NumericUpDown numGoToRec;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblChiral;
        private System.Windows.Forms.Label lblStructure;
        private MDL.Draw.Renditor.Renditor chemRenditor_Trgt;
        private MDL.Draw.Renditor.Renditor chemRenditor_Qry;
        private System.Windows.Forms.Label lblQryStruct;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel pnlBrowse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTANNumber_Qry;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        public System.Windows.Forms.Panel pnlDups;
        private System.Windows.Forms.Label lblChiral_Qry;
        private System.Windows.Forms.Label lblMolWeight_qry;
        private System.Windows.Forms.TextBox txtMolWeight_Qry;
        private System.Windows.Forms.Label lblPageNo_Qry;
        private System.Windows.Forms.TextBox txtPageNum_Qry;
        private System.Windows.Forms.TextBox txtIUPACName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbPageNum;
        private System.Windows.Forms.ComboBox cmbMolFormula;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMolFormula_Qry;
        private System.Windows.Forms.ComboBox cmbMolWeight;
        private System.Windows.Forms.ComboBox cmbPageLabel;
        private System.Windows.Forms.Label lblPageLabel_Qry;
        private System.Windows.Forms.TextBox txtPageLabel_Qry;
        private System.Windows.Forms.ComboBox cmbEnName;
        private System.Windows.Forms.Label lblEnName_Qry;
        private System.Windows.Forms.TextBox txtEnName_Qry;
        private System.Windows.Forms.ComboBox cmbIUPACName;
        private System.Windows.Forms.Label lblIUPAC_Qry;
        private System.Windows.Forms.TextBox txtIUPACName_Qry;
        private System.Windows.Forms.ComboBox cmbTableNo;
        private System.Windows.Forms.Label lblTableNo_Qry;
        private System.Windows.Forms.TextBox txtTableNo_Qry;
        private System.Windows.Forms.ComboBox cmbExampleNo;
        private System.Windows.Forms.Label lblExampleNo_Qry;
        private System.Windows.Forms.TextBox txtExampleNo_Qry;
        private System.Windows.Forms.CheckBox chkVerifyV2000;
    }
}
