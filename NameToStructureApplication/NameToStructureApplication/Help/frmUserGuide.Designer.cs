namespace NameToStructureApplication.Help
{
    partial class frmUserGuide
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserGuide));
            this.pdfDocBrow = new AxAcroPDFLib.AxAcroPDF();
            ((System.ComponentModel.ISupportInitialize)(this.pdfDocBrow)).BeginInit();
            this.SuspendLayout();
            // 
            // pdfDocBrow
            // 
            this.pdfDocBrow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfDocBrow.Enabled = true;
            this.pdfDocBrow.Location = new System.Drawing.Point(0, 0);
            this.pdfDocBrow.Name = "pdfDocBrow";
            this.pdfDocBrow.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("pdfDocBrow.OcxState")));
            this.pdfDocBrow.Size = new System.Drawing.Size(751, 512);
            this.pdfDocBrow.TabIndex = 0;
            // 
            // frmUserGuide
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 512);
            this.Controls.Add(this.pdfDocBrow);
            this.Name = "frmUserGuide";
            this.Text = "User Guide";
            this.Load += new System.EventHandler(this.frmUserGuide_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pdfDocBrow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxAcroPDFLib.AxAcroPDF pdfDocBrow;
    }
}