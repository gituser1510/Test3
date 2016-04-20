using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NameToStructureApplication.Help
{
    public partial class frmUserGuide : Form
    {
        public frmUserGuide()
        {
            InitializeComponent();
        }

        private string _filename = "";
        public string FileName
        {
            get
            {
                return _filename;
            }
            set
            {
                _filename = value;
            }
        }

        private void frmUserGuide_Load(object sender, EventArgs e)
        {
            try
            {
                pdfDocBrow.Visible = false;
                pdfDocBrow.IsAccessible = true;
                try
                {
                    pdfDocBrow.LoadFile(_filename);
                }
                catch
                {
                    pdfDocBrow.LoadFile(_filename);
                }
                pdfDocBrow.Visible = true;

                this.WindowState = FormWindowState.Maximized;
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }
    }
}
