namespace NameToStructureApplication
{
    partial class frmCurator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCurator));
            MDL.Draw.Renderer.Preferences.DisplayPreferences displayPreferences1 = new MDL.Draw.Renderer.Preferences.DisplayPreferences();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.splCont = new System.Windows.Forms.SplitContainer();
            this.pnlText = new System.Windows.Forms.Panel();
            this.richTxt_Browse = new System.Windows.Forms.RichTextBox();
            this.pnlPdf = new System.Windows.Forms.Panel();
            this.pdfDocBrow = new AxAcroPDFLib.AxAcroPDF();
            this.pnlBrowse = new System.Windows.Forms.Panel();
            this.brnBrowseFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.pnlComp_Chem_IUPAC = new System.Windows.Forms.Panel();
            this.pnlChemistry = new System.Windows.Forms.Panel();
            this.pnlStruct_Naving = new System.Windows.Forms.Panel();
            this.lblStructure = new System.Windows.Forms.Label();
            this.pnlNavig = new System.Windows.Forms.Panel();
            this.btnPrev = new System.Windows.Forms.Button();
            this.numGoToRec = new System.Windows.Forms.NumericUpDown();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblChiral = new System.Windows.Forms.Label();
            this.chemRenditor = new MDL.Draw.Renditor.Renditor();
            this.pnlCompName = new System.Windows.Forms.Panel();
            this.pnlTan = new System.Windows.Forms.Panel();
            this.btnGetRecs = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtChkTAN = new System.Windows.Forms.TextBox();
            this.grpDrawOpts = new System.Windows.Forms.GroupBox();
            this.rbnViewAll = new System.Windows.Forms.RadioButton();
            this.rbnChemAxon = new System.Windows.Forms.RadioButton();
            this.rbnChemDraw = new System.Windows.Forms.RadioButton();
            this.rbnOpenEye = new System.Windows.Forms.RadioButton();
            this.txtCompName = new System.Windows.Forms.RichTextBox();
            this.btnGetStructure = new System.Windows.Forms.Button();
            this.lblCompName = new System.Windows.Forms.Label();
            this.pnlIUPACName = new System.Windows.Forms.Panel();
            this.txtIUPACName = new System.Windows.Forms.TextBox();
            this.lblIUPACName = new System.Windows.Forms.Label();
            this.pnlUserInputs = new System.Windows.Forms.Panel();
            this.lblID = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnADD = new System.Windows.Forms.Button();
            this.chkVerifyV2000 = new System.Windows.Forms.CheckBox();
            this.txtTableNo = new System.Windows.Forms.TextBox();
            this.lblTableNo = new System.Windows.Forms.Label();
            this.lblTanNo = new System.Windows.Forms.Label();
            this.txtTANNo = new System.Windows.Forms.TextBox();
            this.lblMolWeight = new System.Windows.Forms.Label();
            this.txtMolWeight = new System.Windows.Forms.TextBox();
            this.lblMolFormula = new System.Windows.Forms.Label();
            this.txtMolFormula = new System.Windows.Forms.TextBox();
            this.txten_Name = new System.Windows.Forms.TextBox();
            this.lblen_name = new System.Windows.Forms.Label();
            this.lblPageNo = new System.Windows.Forms.Label();
            this.txtMolFileNo = new System.Windows.Forms.TextBox();
            this.txtPageNo = new System.Windows.Forms.TextBox();
            this.lblMolFileNo = new System.Windows.Forms.Label();
            this.lblPageLabel = new System.Windows.Forms.Label();
            this.txtExampleNo = new System.Windows.Forms.TextBox();
            this.txtPageLabel = new System.Windows.Forms.TextBox();
            this.lblExampleNo = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pnlMain.SuspendLayout();
            this.splCont.Panel1.SuspendLayout();
            this.splCont.Panel2.SuspendLayout();
            this.splCont.SuspendLayout();
            this.pnlText.SuspendLayout();
            this.pnlPdf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pdfDocBrow)).BeginInit();
            this.pnlBrowse.SuspendLayout();
            this.pnlComp_Chem_IUPAC.SuspendLayout();
            this.pnlChemistry.SuspendLayout();
            this.pnlStruct_Naving.SuspendLayout();
            this.pnlNavig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGoToRec)).BeginInit();
            this.pnlCompName.SuspendLayout();
            this.pnlTan.SuspendLayout();
            this.grpDrawOpts.SuspendLayout();
            this.pnlIUPACName.SuspendLayout();
            this.pnlUserInputs.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.splCont);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1028, 746);
            this.pnlMain.TabIndex = 0;
            // 
            // splCont
            // 
            this.splCont.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splCont.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splCont.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splCont.Location = new System.Drawing.Point(0, 0);
            this.splCont.Name = "splCont";
            // 
            // splCont.Panel1
            // 
            this.splCont.Panel1.Controls.Add(this.pnlText);
            this.splCont.Panel1.Controls.Add(this.pnlPdf);
            this.splCont.Panel1.Controls.Add(this.pnlBrowse);
            // 
            // splCont.Panel2
            // 
            this.splCont.Panel2.Controls.Add(this.pnlComp_Chem_IUPAC);
            this.splCont.Panel2.Controls.Add(this.pnlUserInputs);
            this.splCont.Size = new System.Drawing.Size(1028, 746);
            this.splCont.SplitterDistance = 512;
            this.splCont.SplitterWidth = 5;
            this.splCont.TabIndex = 0;
            // 
            // pnlText
            // 
            this.pnlText.Controls.Add(this.richTxt_Browse);
            this.pnlText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlText.Location = new System.Drawing.Point(0, 32);
            this.pnlText.Name = "pnlText";
            this.pnlText.Size = new System.Drawing.Size(510, 712);
            this.pnlText.TabIndex = 3;
            this.pnlText.Visible = false;
            // 
            // richTxt_Browse
            // 
            this.richTxt_Browse.BackColor = System.Drawing.Color.White;
            this.richTxt_Browse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTxt_Browse.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTxt_Browse.Location = new System.Drawing.Point(0, 0);
            this.richTxt_Browse.Name = "richTxt_Browse";
            this.richTxt_Browse.ReadOnly = true;
            this.richTxt_Browse.Size = new System.Drawing.Size(510, 712);
            this.richTxt_Browse.TabIndex = 0;
            this.richTxt_Browse.Text = "";
            // 
            // pnlPdf
            // 
            this.pnlPdf.Controls.Add(this.pdfDocBrow);
            this.pnlPdf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPdf.Location = new System.Drawing.Point(0, 32);
            this.pnlPdf.Name = "pnlPdf";
            this.pnlPdf.Size = new System.Drawing.Size(510, 712);
            this.pnlPdf.TabIndex = 2;
            // 
            // pdfDocBrow
            // 
            this.pdfDocBrow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfDocBrow.Enabled = true;
            this.pdfDocBrow.Location = new System.Drawing.Point(0, 0);
            this.pdfDocBrow.Name = "pdfDocBrow";
            this.pdfDocBrow.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("pdfDocBrow.OcxState")));
            this.pdfDocBrow.Size = new System.Drawing.Size(510, 712);
            this.pdfDocBrow.TabIndex = 1;
            this.pdfDocBrow.Visible = false;
            // 
            // pnlBrowse
            // 
            this.pnlBrowse.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBrowse.Controls.Add(this.brnBrowseFile);
            this.pnlBrowse.Controls.Add(this.label1);
            this.pnlBrowse.Controls.Add(this.txtFileName);
            this.pnlBrowse.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBrowse.Location = new System.Drawing.Point(0, 0);
            this.pnlBrowse.Name = "pnlBrowse";
            this.pnlBrowse.Size = new System.Drawing.Size(510, 32);
            this.pnlBrowse.TabIndex = 0;
            // 
            // brnBrowseFile
            // 
            this.brnBrowseFile.Dock = System.Windows.Forms.DockStyle.Right;
            this.brnBrowseFile.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.brnBrowseFile.Location = new System.Drawing.Point(462, 0);
            this.brnBrowseFile.Name = "brnBrowseFile";
            this.brnBrowseFile.Size = new System.Drawing.Size(44, 28);
            this.brnBrowseFile.TabIndex = 4;
            this.brnBrowseFile.Text = "...";
            this.brnBrowseFile.UseVisualStyleBackColor = true;
            this.brnBrowseFile.Click += new System.EventHandler(this.brnBrowseFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "File Name";
            // 
            // txtFileName
            // 
            this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileName.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFileName.Location = new System.Drawing.Point(77, 2);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(379, 25);
            this.txtFileName.TabIndex = 0;
            // 
            // pnlComp_Chem_IUPAC
            // 
            this.pnlComp_Chem_IUPAC.Controls.Add(this.pnlChemistry);
            this.pnlComp_Chem_IUPAC.Controls.Add(this.pnlCompName);
            this.pnlComp_Chem_IUPAC.Controls.Add(this.pnlIUPACName);
            this.pnlComp_Chem_IUPAC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlComp_Chem_IUPAC.Location = new System.Drawing.Point(0, 0);
            this.pnlComp_Chem_IUPAC.Name = "pnlComp_Chem_IUPAC";
            this.pnlComp_Chem_IUPAC.Size = new System.Drawing.Size(509, 514);
            this.pnlComp_Chem_IUPAC.TabIndex = 10;
            // 
            // pnlChemistry
            // 
            this.pnlChemistry.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlChemistry.Controls.Add(this.pnlStruct_Naving);
            this.pnlChemistry.Controls.Add(this.chemRenditor);
            this.pnlChemistry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChemistry.Location = new System.Drawing.Point(0, 127);
            this.pnlChemistry.Name = "pnlChemistry";
            this.pnlChemistry.Size = new System.Drawing.Size(509, 317);
            this.pnlChemistry.TabIndex = 7;
            // 
            // pnlStruct_Naving
            // 
            this.pnlStruct_Naving.Controls.Add(this.lblStructure);
            this.pnlStruct_Naving.Controls.Add(this.pnlNavig);
            this.pnlStruct_Naving.Controls.Add(this.lblChiral);
            this.pnlStruct_Naving.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStruct_Naving.Location = new System.Drawing.Point(0, 0);
            this.pnlStruct_Naving.Name = "pnlStruct_Naving";
            this.pnlStruct_Naving.Size = new System.Drawing.Size(505, 30);
            this.pnlStruct_Naving.TabIndex = 14;
            // 
            // lblStructure
            // 
            this.lblStructure.AutoSize = true;
            this.lblStructure.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStructure.Location = new System.Drawing.Point(4, 8);
            this.lblStructure.Name = "lblStructure";
            this.lblStructure.Size = new System.Drawing.Size(69, 17);
            this.lblStructure.TabIndex = 11;
            this.lblStructure.Text = "Structure";
            // 
            // pnlNavig
            // 
            this.pnlNavig.Controls.Add(this.btnPrev);
            this.pnlNavig.Controls.Add(this.numGoToRec);
            this.pnlNavig.Controls.Add(this.btnFirst);
            this.pnlNavig.Controls.Add(this.btnLast);
            this.pnlNavig.Controls.Add(this.btnNext);
            this.pnlNavig.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlNavig.Location = new System.Drawing.Point(259, 0);
            this.pnlNavig.Name = "pnlNavig";
            this.pnlNavig.Size = new System.Drawing.Size(246, 30);
            this.pnlNavig.TabIndex = 13;
            // 
            // btnPrev
            // 
            this.btnPrev.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrev.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrev.Location = new System.Drawing.Point(45, 1);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(39, 28);
            this.btnPrev.TabIndex = 0;
            this.btnPrev.Text = "<";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // numGoToRec
            // 
            this.numGoToRec.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numGoToRec.Location = new System.Drawing.Point(91, 3);
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
            this.btnFirst.Location = new System.Drawing.Point(1, 1);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(39, 28);
            this.btnFirst.TabIndex = 1;
            this.btnFirst.Text = "<<";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnLast
            // 
            this.btnLast.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLast.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnLast.Location = new System.Drawing.Point(203, 1);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(39, 28);
            this.btnLast.TabIndex = 3;
            this.btnLast.Text = ">>";
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnNext
            // 
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnNext.Location = new System.Drawing.Point(160, 1);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(39, 28);
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
            this.lblChiral.Location = new System.Drawing.Point(98, 6);
            this.lblChiral.Name = "lblChiral";
            this.lblChiral.Size = new System.Drawing.Size(48, 17);
            this.lblChiral.TabIndex = 12;
            this.lblChiral.Text = "Chiral";
            this.lblChiral.Visible = false;
            // 
            // chemRenditor
            // 
            this.chemRenditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chemRenditor.AutoSizeStructure = true;
            this.chemRenditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chemRenditor.ChimeString = null;
            this.chemRenditor.ClearingEnabled = true;
            this.chemRenditor.CopyingEnabled = true;
            this.chemRenditor.DisplayOnEmpty = "No Structure";
            this.chemRenditor.EditingEnabled = true;
            this.chemRenditor.FileName = null;
            this.chemRenditor.HighlightInfo = null;
            this.chemRenditor.IsBitmapFromOLE = false;
            this.chemRenditor.Location = new System.Drawing.Point(6, 30);
            this.chemRenditor.Metafile = null;
            this.chemRenditor.Molecule = null;
            this.chemRenditor.MolfileString = null;
            this.chemRenditor.Name = "chemRenditor";
            this.chemRenditor.OldScalingMode = MDL.Draw.Renderer.Preferences.StructureScalingMode.ScaleToFitBox;
            this.chemRenditor.PastingEnabled = true;
            this.chemRenditor.Preferences = displayPreferences1;
            this.chemRenditor.PreferencesFileName = "default.xml";
            this.chemRenditor.RendererBorderStyle = System.Windows.Forms.ButtonBorderStyle.Inset;
            this.chemRenditor.RenditorMolecule = null;
            this.chemRenditor.RenditorName = "Demo Renditor";
            this.chemRenditor.Size = new System.Drawing.Size(493, 283);
            this.chemRenditor.SketchString = null;
            this.chemRenditor.SmilesString = null;
            this.chemRenditor.TabIndex = 2;
            this.chemRenditor.URLEncodedMolfileString = null;
            this.chemRenditor.UseLocalXMLConfig = false;
            this.chemRenditor.DoubleClick += new System.EventHandler(this.chemRenditor_DoubleClick);
            this.chemRenditor.Click += new System.EventHandler(this.chemRenditor_Click);
            this.chemRenditor.StructureChanged += new System.EventHandler(this.chemRenditor_StructureChanged);
            // 
            // pnlCompName
            // 
            this.pnlCompName.Controls.Add(this.pnlTan);
            this.pnlCompName.Controls.Add(this.grpDrawOpts);
            this.pnlCompName.Controls.Add(this.txtCompName);
            this.pnlCompName.Controls.Add(this.btnGetStructure);
            this.pnlCompName.Controls.Add(this.lblCompName);
            this.pnlCompName.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCompName.Location = new System.Drawing.Point(0, 0);
            this.pnlCompName.Name = "pnlCompName";
            this.pnlCompName.Size = new System.Drawing.Size(509, 127);
            this.pnlCompName.TabIndex = 13;
            // 
            // pnlTan
            // 
            this.pnlTan.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlTan.Controls.Add(this.btnGetRecs);
            this.pnlTan.Controls.Add(this.label2);
            this.pnlTan.Controls.Add(this.txtChkTAN);
            this.pnlTan.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTan.Location = new System.Drawing.Point(0, 0);
            this.pnlTan.Name = "pnlTan";
            this.pnlTan.Size = new System.Drawing.Size(509, 30);
            this.pnlTan.TabIndex = 10;
            // 
            // btnGetRecs
            // 
            this.btnGetRecs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetRecs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGetRecs.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetRecs.Location = new System.Drawing.Point(398, -1);
            this.btnGetRecs.Name = "btnGetRecs";
            this.btnGetRecs.Size = new System.Drawing.Size(102, 26);
            this.btnGetRecs.TabIndex = 32;
            this.btnGetRecs.Text = "Get Records";
            this.btnGetRecs.UseVisualStyleBackColor = true;
            this.btnGetRecs.Click += new System.EventHandler(this.btnGetRecs_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(0, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 17);
            this.label2.TabIndex = 31;
            this.label2.Text = "Check records on TAN";
            // 
            // txtChkTAN
            // 
            this.txtChkTAN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtChkTAN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtChkTAN.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChkTAN.ForeColor = System.Drawing.Color.Red;
            this.txtChkTAN.Location = new System.Drawing.Point(167, 0);
            this.txtChkTAN.Name = "txtChkTAN";
            this.txtChkTAN.Size = new System.Drawing.Size(225, 25);
            this.txtChkTAN.TabIndex = 30;            
            // 
            // grpDrawOpts
            // 
            this.grpDrawOpts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDrawOpts.BackColor = System.Drawing.Color.Transparent;
            this.grpDrawOpts.Controls.Add(this.rbnViewAll);
            this.grpDrawOpts.Controls.Add(this.rbnChemAxon);
            this.grpDrawOpts.Controls.Add(this.rbnChemDraw);
            this.grpDrawOpts.Controls.Add(this.rbnOpenEye);
            this.grpDrawOpts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpDrawOpts.Location = new System.Drawing.Point(8, 101);
            this.grpDrawOpts.Name = "grpDrawOpts";
            this.grpDrawOpts.Size = new System.Drawing.Size(386, 23);
            this.grpDrawOpts.TabIndex = 9;
            this.grpDrawOpts.TabStop = false;
            // 
            // rbnViewAll
            // 
            this.rbnViewAll.AutoSize = true;
            this.rbnViewAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbnViewAll.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbnViewAll.Location = new System.Drawing.Point(285, 4);
            this.rbnViewAll.Name = "rbnViewAll";
            this.rbnViewAll.Size = new System.Drawing.Size(79, 21);
            this.rbnViewAll.TabIndex = 3;
            this.rbnViewAll.Text = "View All";
            this.rbnViewAll.UseVisualStyleBackColor = true;
            // 
            // rbnChemAxon
            // 
            this.rbnChemAxon.AutoSize = true;
            this.rbnChemAxon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbnChemAxon.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbnChemAxon.Location = new System.Drawing.Point(186, 4);
            this.rbnChemAxon.Name = "rbnChemAxon";
            this.rbnChemAxon.Size = new System.Drawing.Size(93, 21);
            this.rbnChemAxon.TabIndex = 2;
            this.rbnChemAxon.Text = "ChemAxon";
            this.rbnChemAxon.UseVisualStyleBackColor = true;
            // 
            // rbnChemDraw
            // 
            this.rbnChemDraw.AutoSize = true;
            this.rbnChemDraw.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbnChemDraw.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbnChemDraw.Location = new System.Drawing.Point(89, 4);
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
            this.rbnOpenEye.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbnOpenEye.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbnOpenEye.Location = new System.Drawing.Point(1, 4);
            this.rbnOpenEye.Name = "rbnOpenEye";
            this.rbnOpenEye.Size = new System.Drawing.Size(85, 21);
            this.rbnOpenEye.TabIndex = 0;
            this.rbnOpenEye.TabStop = true;
            this.rbnOpenEye.Text = "Open Eye";
            this.rbnOpenEye.UseVisualStyleBackColor = true;
            // 
            // txtCompName
            // 
            this.txtCompName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCompName.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompName.Location = new System.Drawing.Point(6, 51);
            this.txtCompName.Name = "txtCompName";
            this.txtCompName.Size = new System.Drawing.Size(497, 49);
            this.txtCompName.TabIndex = 8;
            this.txtCompName.Text = "";
            this.txtCompName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtCompName_MouseClick);
            this.txtCompName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCompName_KeyPress);
            this.txtCompName.TextChanged += new System.EventHandler(this.txtCompName_TextChanged);
            // 
            // btnGetStructure
            // 
            this.btnGetStructure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetStructure.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGetStructure.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetStructure.Location = new System.Drawing.Point(402, 101);
            this.btnGetStructure.Name = "btnGetStructure";
            this.btnGetStructure.Size = new System.Drawing.Size(102, 26);
            this.btnGetStructure.TabIndex = 5;
            this.btnGetStructure.Text = "Get Structure";
            this.btnGetStructure.UseVisualStyleBackColor = true;
            this.btnGetStructure.Click += new System.EventHandler(this.btnGetStructure_Click);
            // 
            // lblCompName
            // 
            this.lblCompName.AutoSize = true;
            this.lblCompName.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompName.Location = new System.Drawing.Point(3, 32);
            this.lblCompName.Name = "lblCompName";
            this.lblCompName.Size = new System.Drawing.Size(126, 17);
            this.lblCompName.TabIndex = 7;
            this.lblCompName.Text = "Component Name";
            // 
            // pnlIUPACName
            // 
            this.pnlIUPACName.Controls.Add(this.txtIUPACName);
            this.pnlIUPACName.Controls.Add(this.lblIUPACName);
            this.pnlIUPACName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlIUPACName.Location = new System.Drawing.Point(0, 444);
            this.pnlIUPACName.Name = "pnlIUPACName";
            this.pnlIUPACName.Size = new System.Drawing.Size(509, 70);
            this.pnlIUPACName.TabIndex = 12;
            // 
            // txtIUPACName
            // 
            this.txtIUPACName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIUPACName.BackColor = System.Drawing.Color.White;
            this.txtIUPACName.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIUPACName.Location = new System.Drawing.Point(5, 21);
            this.txtIUPACName.Multiline = true;
            this.txtIUPACName.Name = "txtIUPACName";
            this.txtIUPACName.ReadOnly = true;
            this.txtIUPACName.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtIUPACName.Size = new System.Drawing.Size(498, 47);
            this.txtIUPACName.TabIndex = 11;
            // 
            // lblIUPACName
            // 
            this.lblIUPACName.AutoSize = true;
            this.lblIUPACName.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIUPACName.Location = new System.Drawing.Point(2, 1);
            this.lblIUPACName.Name = "lblIUPACName";
            this.lblIUPACName.Size = new System.Drawing.Size(98, 17);
            this.lblIUPACName.TabIndex = 8;
            this.lblIUPACName.Text = "IUPAC Name";
            // 
            // pnlUserInputs
            // 
            this.pnlUserInputs.Controls.Add(this.lblID);
            this.pnlUserInputs.Controls.Add(this.txtID);
            this.pnlUserInputs.Controls.Add(this.pnlButtons);
            this.pnlUserInputs.Controls.Add(this.txtTableNo);
            this.pnlUserInputs.Controls.Add(this.lblTableNo);
            this.pnlUserInputs.Controls.Add(this.lblTanNo);
            this.pnlUserInputs.Controls.Add(this.txtTANNo);
            this.pnlUserInputs.Controls.Add(this.lblMolWeight);
            this.pnlUserInputs.Controls.Add(this.txtMolWeight);
            this.pnlUserInputs.Controls.Add(this.lblMolFormula);
            this.pnlUserInputs.Controls.Add(this.txtMolFormula);
            this.pnlUserInputs.Controls.Add(this.txten_Name);
            this.pnlUserInputs.Controls.Add(this.lblen_name);
            this.pnlUserInputs.Controls.Add(this.lblPageNo);
            this.pnlUserInputs.Controls.Add(this.txtMolFileNo);
            this.pnlUserInputs.Controls.Add(this.txtPageNo);
            this.pnlUserInputs.Controls.Add(this.lblMolFileNo);
            this.pnlUserInputs.Controls.Add(this.lblPageLabel);
            this.pnlUserInputs.Controls.Add(this.txtExampleNo);
            this.pnlUserInputs.Controls.Add(this.txtPageLabel);
            this.pnlUserInputs.Controls.Add(this.lblExampleNo);
            this.pnlUserInputs.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlUserInputs.Location = new System.Drawing.Point(0, 514);
            this.pnlUserInputs.Name = "pnlUserInputs";
            this.pnlUserInputs.Size = new System.Drawing.Size(509, 230);
            this.pnlUserInputs.TabIndex = 22;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.ForeColor = System.Drawing.Color.Blue;
            this.lblID.Location = new System.Drawing.Point(2, 170);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(25, 17);
            this.lblID.TabIndex = 55;
            this.lblID.Text = "ID";
            // 
            // txtID
            // 
            this.txtID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtID.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.ForeColor = System.Drawing.Color.Red;
            this.txtID.Location = new System.Drawing.Point(104, 166);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(142, 25);
            this.txtID.TabIndex = 54;
            // 
            // pnlButtons
            // 
            this.pnlButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlButtons.Controls.Add(this.btnDelete);
            this.pnlButtons.Controls.Add(this.btnUpdate);
            this.pnlButtons.Controls.Add(this.btnADD);
            this.pnlButtons.Controls.Add(this.chkVerifyV2000);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 195);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(509, 35);
            this.pnlButtons.TabIndex = 53;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(175, 1);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(104, 30);
            this.btnDelete.TabIndex = 52;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(286, 1);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(104, 30);
            this.btnUpdate.TabIndex = 51;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnADD
            // 
            this.btnADD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnADD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnADD.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnADD.Location = new System.Drawing.Point(398, 1);
            this.btnADD.Name = "btnADD";
            this.btnADD.Size = new System.Drawing.Size(104, 30);
            this.btnADD.TabIndex = 11;
            this.btnADD.Text = "Add";
            this.btnADD.UseVisualStyleBackColor = true;
            this.btnADD.Click += new System.EventHandler(this.btnADD_Click);
            // 
            // chkVerifyV2000
            // 
            this.chkVerifyV2000.AutoSize = true;
            this.chkVerifyV2000.Checked = true;
            this.chkVerifyV2000.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVerifyV2000.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkVerifyV2000.ForeColor = System.Drawing.Color.Blue;
            this.chkVerifyV2000.Location = new System.Drawing.Point(4, 7);
            this.chkVerifyV2000.Name = "chkVerifyV2000";
            this.chkVerifyV2000.Size = new System.Drawing.Size(158, 21);
            this.chkVerifyV2000.TabIndex = 50;
            this.chkVerifyV2000.Text = "Verify V2000 format";
            this.chkVerifyV2000.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkVerifyV2000.UseVisualStyleBackColor = true;
            // 
            // txtTableNo
            // 
            this.txtTableNo.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTableNo.Location = new System.Drawing.Point(361, 62);
            this.txtTableNo.Name = "txtTableNo";
            this.txtTableNo.Size = new System.Drawing.Size(143, 25);
            this.txtTableNo.TabIndex = 51;
            this.txtTableNo.Text = "00";
            // 
            // lblTableNo
            // 
            this.lblTableNo.AutoSize = true;
            this.lblTableNo.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTableNo.Location = new System.Drawing.Point(262, 65);
            this.lblTableNo.Name = "lblTableNo";
            this.lblTableNo.Size = new System.Drawing.Size(72, 17);
            this.lblTableNo.TabIndex = 52;
            this.lblTableNo.Text = "Table No.";
            // 
            // lblTanNo
            // 
            this.lblTanNo.AutoSize = true;
            this.lblTanNo.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTanNo.ForeColor = System.Drawing.Color.Blue;
            this.lblTanNo.Location = new System.Drawing.Point(2, 95);
            this.lblTanNo.Name = "lblTanNo";
            this.lblTanNo.Size = new System.Drawing.Size(67, 17);
            this.lblTanNo.TabIndex = 29;
            this.lblTanNo.Text = "TAN No.";
            // 
            // txtTANNo
            // 
            this.txtTANNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTANNo.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTANNo.ForeColor = System.Drawing.Color.Red;
            this.txtTANNo.Location = new System.Drawing.Point(104, 91);
            this.txtTANNo.Name = "txtTANNo";
            this.txtTANNo.Size = new System.Drawing.Size(142, 25);
            this.txtTANNo.TabIndex = 28;
            // 
            // lblMolWeight
            // 
            this.lblMolWeight.AutoSize = true;
            this.lblMolWeight.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMolWeight.ForeColor = System.Drawing.Color.Blue;
            this.lblMolWeight.Location = new System.Drawing.Point(262, 8);
            this.lblMolWeight.Name = "lblMolWeight";
            this.lblMolWeight.Size = new System.Drawing.Size(86, 17);
            this.lblMolWeight.TabIndex = 25;
            this.lblMolWeight.Text = "Mol Weight";
            // 
            // txtMolWeight
            // 
            this.txtMolWeight.BackColor = System.Drawing.Color.White;
            this.txtMolWeight.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMolWeight.ForeColor = System.Drawing.Color.Red;
            this.txtMolWeight.Location = new System.Drawing.Point(361, 4);
            this.txtMolWeight.Name = "txtMolWeight";
            this.txtMolWeight.ReadOnly = true;
            this.txtMolWeight.Size = new System.Drawing.Size(143, 25);
            this.txtMolWeight.TabIndex = 23;
            // 
            // lblMolFormula
            // 
            this.lblMolFormula.AutoSize = true;
            this.lblMolFormula.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMolFormula.ForeColor = System.Drawing.Color.Blue;
            this.lblMolFormula.Location = new System.Drawing.Point(4, 7);
            this.lblMolFormula.Name = "lblMolFormula";
            this.lblMolFormula.Size = new System.Drawing.Size(93, 17);
            this.lblMolFormula.TabIndex = 26;
            this.lblMolFormula.Text = "Mol Formula";
            // 
            // txtMolFormula
            // 
            this.txtMolFormula.BackColor = System.Drawing.Color.White;
            this.txtMolFormula.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMolFormula.ForeColor = System.Drawing.Color.Red;
            this.txtMolFormula.Location = new System.Drawing.Point(104, 4);
            this.txtMolFormula.Name = "txtMolFormula";
            this.txtMolFormula.ReadOnly = true;
            this.txtMolFormula.Size = new System.Drawing.Size(142, 25);
            this.txtMolFormula.TabIndex = 24;
            // 
            // txten_Name
            // 
            this.txten_Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txten_Name.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txten_Name.Location = new System.Drawing.Point(103, 120);
            this.txten_Name.Multiline = true;
            this.txten_Name.Name = "txten_Name";
            this.txten_Name.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txten_Name.Size = new System.Drawing.Size(401, 42);
            this.txten_Name.TabIndex = 10;
            // 
            // lblen_name
            // 
            this.lblen_name.AutoSize = true;
            this.lblen_name.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblen_name.Location = new System.Drawing.Point(4, 120);
            this.lblen_name.Name = "lblen_name";
            this.lblen_name.Size = new System.Drawing.Size(66, 17);
            this.lblen_name.TabIndex = 22;
            this.lblen_name.Text = "en Name";
            // 
            // lblPageNo
            // 
            this.lblPageNo.AutoSize = true;
            this.lblPageNo.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageNo.Location = new System.Drawing.Point(5, 38);
            this.lblPageNo.Name = "lblPageNo";
            this.lblPageNo.Size = new System.Drawing.Size(67, 17);
            this.lblPageNo.TabIndex = 9;
            this.lblPageNo.Text = "Page No.";
            // 
            // txtMolFileNo
            // 
            this.txtMolFileNo.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMolFileNo.Location = new System.Drawing.Point(361, 91);
            this.txtMolFileNo.Name = "txtMolFileNo";
            this.txtMolFileNo.Size = new System.Drawing.Size(143, 25);
            this.txtMolFileNo.TabIndex = 9;
            this.txtMolFileNo.Text = "1";
            // 
            // txtPageNo
            // 
            this.txtPageNo.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPageNo.Location = new System.Drawing.Point(104, 33);
            this.txtPageNo.Name = "txtPageNo";
            this.txtPageNo.Size = new System.Drawing.Size(142, 25);
            this.txtPageNo.TabIndex = 6;
            // 
            // lblMolFileNo
            // 
            this.lblMolFileNo.AutoSize = true;
            this.lblMolFileNo.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMolFileNo.Location = new System.Drawing.Point(262, 96);
            this.lblMolFileNo.Name = "lblMolFileNo";
            this.lblMolFileNo.Size = new System.Drawing.Size(82, 17);
            this.lblMolFileNo.TabIndex = 20;
            this.lblMolFileNo.Text = "Molfile No.";
            // 
            // lblPageLabel
            // 
            this.lblPageLabel.AutoSize = true;
            this.lblPageLabel.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageLabel.Location = new System.Drawing.Point(262, 37);
            this.lblPageLabel.Name = "lblPageLabel";
            this.lblPageLabel.Size = new System.Drawing.Size(81, 17);
            this.lblPageLabel.TabIndex = 16;
            this.lblPageLabel.Text = "Page Label";
            // 
            // txtExampleNo
            // 
            this.txtExampleNo.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExampleNo.Location = new System.Drawing.Point(104, 62);
            this.txtExampleNo.Name = "txtExampleNo";
            this.txtExampleNo.Size = new System.Drawing.Size(142, 25);
            this.txtExampleNo.TabIndex = 8;
            this.txtExampleNo.Text = "00";
            // 
            // txtPageLabel
            // 
            this.txtPageLabel.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPageLabel.Location = new System.Drawing.Point(361, 33);
            this.txtPageLabel.Name = "txtPageLabel";
            this.txtPageLabel.Size = new System.Drawing.Size(143, 25);
            this.txtPageLabel.TabIndex = 7;
            this.txtPageLabel.Text = "00";
            // 
            // lblExampleNo
            // 
            this.lblExampleNo.AutoSize = true;
            this.lblExampleNo.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExampleNo.Location = new System.Drawing.Point(5, 67);
            this.lblExampleNo.Name = "lblExampleNo";
            this.lblExampleNo.Size = new System.Drawing.Size(92, 17);
            this.lblExampleNo.TabIndex = 18;
            this.lblExampleNo.Text = "Example No.";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmCurator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1028, 746);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmCurator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Curator";
            this.Load += new System.EventHandler(this.frmNameToStruct_Load);
            this.pnlMain.ResumeLayout(false);
            this.splCont.Panel1.ResumeLayout(false);
            this.splCont.Panel2.ResumeLayout(false);
            this.splCont.ResumeLayout(false);
            this.pnlText.ResumeLayout(false);
            this.pnlPdf.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pdfDocBrow)).EndInit();
            this.pnlBrowse.ResumeLayout(false);
            this.pnlBrowse.PerformLayout();
            this.pnlComp_Chem_IUPAC.ResumeLayout(false);
            this.pnlChemistry.ResumeLayout(false);
            this.pnlStruct_Naving.ResumeLayout(false);
            this.pnlStruct_Naving.PerformLayout();
            this.pnlNavig.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numGoToRec)).EndInit();
            this.pnlCompName.ResumeLayout(false);
            this.pnlCompName.PerformLayout();
            this.pnlTan.ResumeLayout(false);
            this.pnlTan.PerformLayout();
            this.grpDrawOpts.ResumeLayout(false);
            this.grpDrawOpts.PerformLayout();
            this.pnlIUPACName.ResumeLayout(false);
            this.pnlIUPACName.PerformLayout();
            this.pnlUserInputs.ResumeLayout(false);
            this.pnlUserInputs.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.pnlButtons.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.SplitContainer splCont;
        private System.Windows.Forms.Panel pnlBrowse;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label label1;
        private AxAcroPDFLib.AxAcroPDF pdfDocBrow;
        private System.Windows.Forms.Panel pnlChemistry;
        private System.Windows.Forms.Label lblIUPACName;
        private MDL.Draw.Renditor.Renditor chemRenditor;
        private System.Windows.Forms.Label lblStructure;
        private System.Windows.Forms.Panel pnlComp_Chem_IUPAC;
        private System.Windows.Forms.Button btnGetStructure;
        private System.Windows.Forms.Label lblCompName;
        private System.Windows.Forms.Button btnADD;
        private System.Windows.Forms.TextBox txtExampleNo;
        private System.Windows.Forms.Label lblExampleNo;
        private System.Windows.Forms.TextBox txtPageLabel;
        private System.Windows.Forms.Label lblPageLabel;
        private System.Windows.Forms.TextBox txtPageNo;
        private System.Windows.Forms.Label lblPageNo;
        private System.Windows.Forms.TextBox txtMolFileNo;
        private System.Windows.Forms.Label lblMolFileNo;
        private System.Windows.Forms.Panel pnlUserInputs;
        private System.Windows.Forms.TextBox txten_Name;
        private System.Windows.Forms.Label lblen_name;
        private System.Windows.Forms.Label lblMolWeight;
        private System.Windows.Forms.TextBox txtMolWeight;
        private System.Windows.Forms.Label lblMolFormula;
        private System.Windows.Forms.TextBox txtMolFormula;
        private System.Windows.Forms.Panel pnlIUPACName;
        private System.Windows.Forms.Panel pnlCompName;
        private System.Windows.Forms.RichTextBox txtCompName;
        private System.Windows.Forms.Label lblChiral;
        private System.Windows.Forms.Label lblTanNo;
        private System.Windows.Forms.TextBox txtTANNo;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button brnBrowseFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel pnlText;
        private System.Windows.Forms.RichTextBox richTxt_Browse;
        private System.Windows.Forms.Panel pnlPdf;
        private System.Windows.Forms.GroupBox grpDrawOpts;
        private System.Windows.Forms.RadioButton rbnChemAxon;
        private System.Windows.Forms.RadioButton rbnChemDraw;
        private System.Windows.Forms.RadioButton rbnOpenEye;
        private System.Windows.Forms.RadioButton rbnViewAll;
        private System.Windows.Forms.TextBox txtIUPACName;
        private System.Windows.Forms.CheckBox chkVerifyV2000;
        private System.Windows.Forms.Panel pnlNavig;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TextBox txtTableNo;
        private System.Windows.Forms.Label lblTableNo;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Panel pnlTan;
        private System.Windows.Forms.Button btnGetRecs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtChkTAN;
        private System.Windows.Forms.Panel pnlStruct_Naving;
        public System.Windows.Forms.NumericUpDown numGoToRec;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtID;


    }
}