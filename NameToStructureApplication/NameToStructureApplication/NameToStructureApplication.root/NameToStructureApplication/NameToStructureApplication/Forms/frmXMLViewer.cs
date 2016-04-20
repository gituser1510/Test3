#region Import Assemblies

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using NameToStructureApplication;

#endregion

namespace NameToStructureApplication
{
    public partial class frmXMLViewer : Form
    {
        #region Constructor

        public frmXMLViewer()
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

        #endregion

        private void frmXMLViewer_Load(object sender, EventArgs e)
        {
            try
            {
                txtFileName.Text = _filename;

                xmlGridView1.DataFilePath = txtFileName.Text;
                xmlGridView1.DataSetTableIndex = 0;

                SetBehavior();

                this.WindowState = FormWindowState.Maximized;
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
        }
       
        private void SetBehavior()
        {
            try
            {
                bool bFileExists = ((txtFileName.Text.Trim() != string.Empty) && File.Exists(txtFileName.Text));
                xmlGridView1.ViewMode = XmlGridView.VIEW_MODE.XML;
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
        }       
    }
}
