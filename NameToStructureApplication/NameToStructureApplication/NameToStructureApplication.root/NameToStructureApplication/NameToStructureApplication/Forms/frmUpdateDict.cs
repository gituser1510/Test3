using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NameToStructureApplication.Forms
{
    public partial class frmUpdateDict : Form
    {
        public frmUpdateDict()
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNewSmiles.Text.Trim() != "")
                {
                    if (txtCompName.Text.Trim() != "")
                    {
                        if (PepsiLiteDataAccess.DataOperations.UpdateDictCompSmilesDetails(txtCompName.Text.Trim(),txtNewSmiles.Text.Trim(),DateTime.Now,Classes.Generic_PepsiLite.UserID))
                        {
                            MessageBox.Show("Record updated successfully","Update",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Record not updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter compound name", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter SMILES", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
        }
    }
}
