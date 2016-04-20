namespace NameToStructureApplication
{
    partial class frmXMLViewer_Validation
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
            this.pnlBrowse = new System.Windows.Forms.Panel();
            this.btnSchema = new System.Windows.Forms.Button();
            this.btnWellFormNess = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowseXML = new System.Windows.Forms.Button();
            this.txtXmlFile = new System.Windows.Forms.TextBox();
            this.lblBrowseXml = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.ComboBox1 = new System.Windows.Forms.ComboBox();
            this.RichTextBox1 = new System.Windows.Forms.RichTextBox();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.ListBox1 = new System.Windows.Forms.ListBox();
            this.splCont = new System.Windows.Forms.SplitContainer();
            this.pnlBrowse.SuspendLayout();
            this.TabControl1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.TabPage2.SuspendLayout();
            this.splCont.Panel1.SuspendLayout();
            this.splCont.Panel2.SuspendLayout();
            this.splCont.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBrowse
            // 
            this.pnlBrowse.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBrowse.Controls.Add(this.btnSchema);
            this.pnlBrowse.Controls.Add(this.btnWellFormNess);
            this.pnlBrowse.Controls.Add(this.label1);
            this.pnlBrowse.Controls.Add(this.btnBrowseXML);
            this.pnlBrowse.Controls.Add(this.txtXmlFile);
            this.pnlBrowse.Controls.Add(this.lblBrowseXml);
            this.pnlBrowse.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBrowse.Location = new System.Drawing.Point(0, 0);
            this.pnlBrowse.Name = "pnlBrowse";
            this.pnlBrowse.Size = new System.Drawing.Size(921, 43);
            this.pnlBrowse.TabIndex = 0;
            // 
            // btnSchema
            // 
            this.btnSchema.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSchema.Location = new System.Drawing.Point(791, 5);
            this.btnSchema.Name = "btnSchema";
            this.btnSchema.Size = new System.Drawing.Size(117, 30);
            this.btnSchema.TabIndex = 5;
            this.btnSchema.Text = "XSD Schema";
            this.btnSchema.UseVisualStyleBackColor = true;
            this.btnSchema.Click += new System.EventHandler(this.btnSchema_Click);
            // 
            // btnWellFormNess
            // 
            this.btnWellFormNess.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWellFormNess.Location = new System.Drawing.Point(664, 5);
            this.btnWellFormNess.Name = "btnWellFormNess";
            this.btnWellFormNess.Size = new System.Drawing.Size(114, 30);
            this.btnWellFormNess.TabIndex = 4;
            this.btnWellFormNess.Text = "Wellformedness";
            this.btnWellFormNess.UseVisualStyleBackColor = true;
            this.btnWellFormNess.Click += new System.EventHandler(this.btnWellFormNess_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(598, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Validate";
            // 
            // btnBrowseXML
            // 
            this.btnBrowseXML.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseXML.Location = new System.Drawing.Point(549, 4);
            this.btnBrowseXML.Name = "btnBrowseXML";
            this.btnBrowseXML.Size = new System.Drawing.Size(29, 30);
            this.btnBrowseXML.TabIndex = 2;
            this.btnBrowseXML.Text = "...";
            this.btnBrowseXML.UseVisualStyleBackColor = true;
            this.btnBrowseXML.Click += new System.EventHandler(this.btnBrowseXML_Click);
            // 
            // txtXmlFile
            // 
            this.txtXmlFile.BackColor = System.Drawing.Color.White;
            this.txtXmlFile.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtXmlFile.Location = new System.Drawing.Point(114, 7);
            this.txtXmlFile.Name = "txtXmlFile";
            this.txtXmlFile.ReadOnly = true;
            this.txtXmlFile.Size = new System.Drawing.Size(429, 25);
            this.txtXmlFile.TabIndex = 1;
            // 
            // lblBrowseXml
            // 
            this.lblBrowseXml.AutoSize = true;
            this.lblBrowseXml.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrowseXml.Location = new System.Drawing.Point(5, 9);
            this.lblBrowseXml.Name = "lblBrowseXml";
            this.lblBrowseXml.Size = new System.Drawing.Size(102, 17);
            this.lblBrowseXml.TabIndex = 0;
            this.lblBrowseXml.Text = "Browse XML:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // TabControl1
            // 
            this.TabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.TabControl1.Controls.Add(this.TabPage1);
            this.TabControl1.Controls.Add(this.TabPage2);
            this.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabControl1.Location = new System.Drawing.Point(0, 0);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(919, 321);
            this.TabControl1.TabIndex = 3;
            this.TabControl1.SelectedIndexChanged += new System.EventHandler(this.TabControl1_SelectedIndexChanged);
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.ComboBox1);
            this.TabPage1.Controls.Add(this.RichTextBox1);
            this.TabPage1.Location = new System.Drawing.Point(4, 4);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Size = new System.Drawing.Size(911, 291);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Source";
            // 
            // ComboBox1
            // 
            this.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox1.Location = new System.Drawing.Point(160, 64);
            this.ComboBox1.Name = "ComboBox1";
            this.ComboBox1.Size = new System.Drawing.Size(160, 25);
            this.ComboBox1.TabIndex = 1;
            this.ComboBox1.Visible = false;
            // 
            // RichTextBox1
            // 
            this.RichTextBox1.AcceptsTab = true;
            this.RichTextBox1.DetectUrls = false;
            this.RichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RichTextBox1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichTextBox1.Location = new System.Drawing.Point(0, 0);
            this.RichTextBox1.Name = "RichTextBox1";
            this.RichTextBox1.Size = new System.Drawing.Size(911, 291);
            this.RichTextBox1.TabIndex = 1;
            this.RichTextBox1.Text = "";
            this.RichTextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RichTextBox1_KeyPress);
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.webBrowser1);
            this.TabPage2.Location = new System.Drawing.Point(4, 4);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Size = new System.Drawing.Size(911, 291);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Output";
            this.TabPage2.Visible = false;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(911, 291);
            this.webBrowser1.TabIndex = 0;
            // 
            // ListBox1
            // 
            this.ListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListBox1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListBox1.HorizontalScrollbar = true;
            this.ListBox1.ItemHeight = 17;
            this.ListBox1.Location = new System.Drawing.Point(0, 0);
            this.ListBox1.Name = "ListBox1";
            this.ListBox1.Size = new System.Drawing.Size(919, 310);
            this.ListBox1.TabIndex = 4;
            this.ListBox1.SelectedIndexChanged += new System.EventHandler(this.ListBox1_SelectedIndexChanged);
            // 
            // splCont
            // 
            this.splCont.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splCont.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splCont.Location = new System.Drawing.Point(0, 43);
            this.splCont.Name = "splCont";
            this.splCont.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splCont.Panel1
            // 
            this.splCont.Panel1.Controls.Add(this.TabControl1);
            // 
            // splCont.Panel2
            // 
            this.splCont.Panel2.Controls.Add(this.ListBox1);
            this.splCont.Size = new System.Drawing.Size(921, 647);
            this.splCont.SplitterDistance = 323;
            this.splCont.TabIndex = 5;
            // 
            // frmXMLViewer_Validation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(921, 690);
            this.Controls.Add(this.splCont);
            this.Controls.Add(this.pnlBrowse);
            this.Name = "frmXMLViewer_Validation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XML Validation";
            this.Load += new System.EventHandler(this.frmXMLViewer_Validation_Load);
            this.Activated += new System.EventHandler(this.frmXMLViewer_Validation_Activated);
            this.pnlBrowse.ResumeLayout(false);
            this.pnlBrowse.PerformLayout();
            this.TabControl1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.TabPage2.ResumeLayout(false);
            this.splCont.Panel1.ResumeLayout(false);
            this.splCont.Panel2.ResumeLayout(false);
            this.splCont.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBrowse;
        private System.Windows.Forms.Label lblBrowseXml;
        private System.Windows.Forms.Button btnBrowseXML;
        private System.Windows.Forms.TextBox txtXmlFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSchema;
        private System.Windows.Forms.Button btnWellFormNess;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        internal System.Windows.Forms.TabControl TabControl1;
        internal System.Windows.Forms.TabPage TabPage1;
        internal System.Windows.Forms.RichTextBox RichTextBox1;
        internal System.Windows.Forms.TabPage TabPage2;
        internal System.Windows.Forms.ListBox ListBox1;
        private System.Windows.Forms.SplitContainer splCont;
        private System.Windows.Forms.WebBrowser webBrowser1;
        internal System.Windows.Forms.ComboBox ComboBox1;
    }
}