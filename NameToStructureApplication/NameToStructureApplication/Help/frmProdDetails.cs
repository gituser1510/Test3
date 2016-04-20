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
    public partial class frmProdDetails : Form
    {
        public frmProdDetails()
        {
            InitializeComponent();
        }

        private void frmProdDetails_Load(object sender, EventArgs e)
        {
            try
            {
                string strProdFile = AppDomain.CurrentDomain.BaseDirectory + "PepsiLiteApplication.DLL";
                string strDtAccFile = AppDomain.CurrentDomain.BaseDirectory + "PepsiLiteDataAccess.DLL";

                string strProdVer = System.Reflection.Assembly.LoadFile(strProdFile).GetName().Version.ToString();
                string strDtAccVer = System.Reflection.Assembly.LoadFile(strDtAccFile).GetName().Version.ToString();
                
                lblProdVer.Text = strProdVer;
                lblDtAccVer.Text = strDtAccVer;
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }
    }
}
