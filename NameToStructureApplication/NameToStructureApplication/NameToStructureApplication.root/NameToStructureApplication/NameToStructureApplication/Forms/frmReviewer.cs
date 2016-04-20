#region Import Assemblies

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NameToStructureApplication.UserControls;

#endregion

namespace NameToStructureApplication
{
    public partial class frmReviewer : Form
    {
        #region Constructor

        public frmReviewer()
        {
            InitializeComponent();
        }

        #endregion

        #region Property Procedures

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

        private string _tannumber = "";
        public string TANNumber
        {
            get
            {
                return _tannumber;
            }
            set
            {
                _tannumber = value;
            }
        }

        #endregion

        private void frmReviewer_Load(object sender, EventArgs e)
        {
            try
            {             
                ucChemProps_Navigation1.FileName = FileName;
                ucChemProps_Navigation1.TANNumber = TANNumber;         
                ucChemProps_Navigation1.LoadMolecules();

                this.WindowState = FormWindowState.Maximized;
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
        }

        private void btnBrowsePDFFile_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "PDF|*.pdf";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string strFileName = openFileDialog1.FileName;
                    if (strFileName.Trim() != "")
                    {
                        txtFileName.Text = strFileName;
                        pdfDocBrow.IsAccessible = true;
                        pdfDocBrow.LoadFile(strFileName);
                        pdfDocBrow.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
        }
    }
}
