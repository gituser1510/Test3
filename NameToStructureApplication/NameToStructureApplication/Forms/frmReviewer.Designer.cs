namespace NameToStructureApplication
{
    partial class frmReviewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReviewer));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.splCont = new System.Windows.Forms.SplitContainer();
            this.pdfDocBrow = new AxAcroPDFLib.AxAcroPDF();
            this.pnlBrowsePdf = new System.Windows.Forms.Panel();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.lblBrowsePdf = new System.Windows.Forms.Label();
            this.btnBrowsePdf = new System.Windows.Forms.Button();
            this.ucChemProps_Navigation1 = new NameToStructureApplication.UserControls.ucChemProps_Navigation();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pnlMain.SuspendLayout();
            this.splCont.Panel1.SuspendLayout();
            this.splCont.Panel2.SuspendLayout();
            this.splCont.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pdfDocBrow)).BeginInit();
            this.pnlBrowsePdf.SuspendLayout();
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
            this.splCont.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splCont.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splCont.Location = new System.Drawing.Point(0, 0);
            this.splCont.Name = "splCont";
            // 
            // splCont.Panel1
            // 
            this.splCont.Panel1.Controls.Add(this.pdfDocBrow);
            this.splCont.Panel1.Controls.Add(this.pnlBrowsePdf);
            // 
            // splCont.Panel2
            // 
            this.splCont.Panel2.Controls.Add(this.ucChemProps_Navigation1);
            this.splCont.Size = new System.Drawing.Size(1028, 746);
            this.splCont.SplitterDistance = 503;
            this.splCont.TabIndex = 0;
            // 
            // pdfDocBrow
            // 
            this.pdfDocBrow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfDocBrow.Enabled = true;
            this.pdfDocBrow.Location = new System.Drawing.Point(0, 34);
            this.pdfDocBrow.Name = "pdfDocBrow";
            this.pdfDocBrow.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("pdfDocBrow.OcxState")));
            this.pdfDocBrow.Size = new System.Drawing.Size(499, 708);
            this.pdfDocBrow.TabIndex = 2;
            this.pdfDocBrow.Visible = false;
            // 
            // pnlBrowsePdf
            // 
            this.pnlBrowsePdf.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBrowsePdf.Controls.Add(this.txtFileName);
            this.pnlBrowsePdf.Controls.Add(this.lblBrowsePdf);
            this.pnlBrowsePdf.Controls.Add(this.btnBrowsePdf);
            this.pnlBrowsePdf.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBrowsePdf.Location = new System.Drawing.Point(0, 0);
            this.pnlBrowsePdf.Name = "pnlBrowsePdf";
            this.pnlBrowsePdf.Size = new System.Drawing.Size(499, 34);
            this.pnlBrowsePdf.TabIndex = 0;
            // 
            // txtFileName
            // 
            this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileName.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFileName.Location = new System.Drawing.Point(81, 3);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(377, 25);
            this.txtFileName.TabIndex = 2;
            // 
            // lblBrowsePdf
            // 
            this.lblBrowsePdf.AutoSize = true;
            this.lblBrowsePdf.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrowsePdf.Location = new System.Drawing.Point(2, 7);
            this.lblBrowsePdf.Name = "lblBrowsePdf";
            this.lblBrowsePdf.Size = new System.Drawing.Size(79, 17);
            this.lblBrowsePdf.TabIndex = 1;
            this.lblBrowsePdf.Text = "Browse Pdf";
            // 
            // btnBrowsePdf
            // 
            this.btnBrowsePdf.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnBrowsePdf.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowsePdf.Location = new System.Drawing.Point(464, 0);
            this.btnBrowsePdf.Name = "btnBrowsePdf";
            this.btnBrowsePdf.Size = new System.Drawing.Size(31, 30);
            this.btnBrowsePdf.TabIndex = 0;
            this.btnBrowsePdf.Text = "...";
            this.btnBrowsePdf.UseVisualStyleBackColor = true;
            this.btnBrowsePdf.Click += new System.EventHandler(this.btnBrowsePDFFile_Click);
            // 
            // ucChemProps_Navigation1
            // 
            this.ucChemProps_Navigation1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucChemProps_Navigation1.FileName = "";
            this.ucChemProps_Navigation1.Location = new System.Drawing.Point(0, 0);
            this.ucChemProps_Navigation1.MolDataTbl = null;
            this.ucChemProps_Navigation1.MOLImporter = null;
            this.ucChemProps_Navigation1.Name = "ucChemProps_Navigation1";
            this.ucChemProps_Navigation1.Size = new System.Drawing.Size(517, 742);
            this.ucChemProps_Navigation1.TabIndex = 0;
            this.ucChemProps_Navigation1.TANNumber = "";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmReviewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1028, 746);
            this.Controls.Add(this.pnlMain);
            this.Name = "frmReviewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reviewer";
            this.Load += new System.EventHandler(this.frmReviewer_Load);
            this.pnlMain.ResumeLayout(false);
            this.splCont.Panel1.ResumeLayout(false);
            this.splCont.Panel2.ResumeLayout(false);
            this.splCont.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pdfDocBrow)).EndInit();
            this.pnlBrowsePdf.ResumeLayout(false);
            this.pnlBrowsePdf.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.SplitContainer splCont;
        private NameToStructureApplication.UserControls.ucChemProps_Navigation ucChemProps_Navigation1;
        private System.Windows.Forms.Panel pnlBrowsePdf;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private AxAcroPDFLib.AxAcroPDF pdfDocBrow;
        private System.Windows.Forms.Label lblBrowsePdf;
        private System.Windows.Forms.Button btnBrowsePdf;
        private System.Windows.Forms.TextBox txtFileName;

    }
}