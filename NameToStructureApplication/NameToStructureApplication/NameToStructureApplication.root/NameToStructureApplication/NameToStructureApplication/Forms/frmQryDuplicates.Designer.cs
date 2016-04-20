namespace NameToStructureApplication.Forms
{
    partial class frmQryDuplicates
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
            this.ucCheckDuplicates1 = new NameToStructureApplication.UserControls.ucCheckDuplicates();
            this.SuspendLayout();
            // 
            // ucCheckDuplicates1
            // 
            this.ucCheckDuplicates1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucCheckDuplicates1.SearchResults = null;
            this.ucCheckDuplicates1.Location = new System.Drawing.Point(0, 0);
            this.ucCheckDuplicates1.Name = "ucCheckDuplicates1";
            this.ucCheckDuplicates1.Size = new System.Drawing.Size(877, 591);
            this.ucCheckDuplicates1.TabIndex = 0;
            // 
            // frmQryDuplicates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 591);
            this.Controls.Add(this.ucCheckDuplicates1);
            this.Name = "frmQryDuplicates";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Query Duplicates";
            this.Load += new System.EventHandler(this.frmQryDuplicates_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public NameToStructureApplication.UserControls.ucCheckDuplicates ucCheckDuplicates1;

    }
}