using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PepsiLiteDataAccess;

namespace NameToStructureApplication.Forms
{
    public partial class frmRetrieveDict : Form
    {
        public frmRetrieveDict()
        {
            InitializeComponent();
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCompName.Text.Trim() != "")
                {
                    string strSmiles = PepsiLiteDataAccess.DataOperations.RetrieveDictSmilesOnCompName(txtCompName.Text.Trim());
                    if (strSmiles != "")
                    {
                        txtSmiles.Text = strSmiles;
                    }
                    else
                    {
                        MessageBox.Show("No record found", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter compound name","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
        }
    }
}
