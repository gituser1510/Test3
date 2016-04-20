#region Import Assemblies

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PepsiLiteDataAccess;

#endregion

namespace NameToStructureApplication.Dictionary
{
    public partial class frmAddToDict : Form
    {
        #region Class Constructor

        public frmAddToDict()
        {
            InitializeComponent();
        } 

        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string strErrmsg = "";
                if (ValidateUserInputs(out strErrmsg))
                {
                    string strCompname = txtCompName.Text.Trim();
                    string strSmiles = txtSmiles.Text.Trim();
                    int userID = Generic.Generic_PepsiLite.UserID;

                    //Check for duplicate before inserting in database

                    if (!PepsiLiteDataAccess.DataOperations.CheckForDuplicateCompName(strCompname))
                    {
                        if (PepsiLiteDataAccess.DataOperations.InsertDictionaryDetails(strCompname, strSmiles, DateTime.Now, userID))
                        {
                            MessageBox.Show("Added to dictionary successfully", "Add to Dictionary", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error in adding", "Add to Dictionary", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Record already exist", "Add to Dictionary", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show(strErrmsg, "Invalid user inputs", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private bool ValidateUserInputs(out string errmsg_out)
        {
            bool blValStatus = false;
            string strErrMsg = "";
            try
            {
                if (txtCompName.Text.Trim() != "")
                {
                    if (txtSmiles.Text.Trim() != "")
                    {
                        if (Validations.ValidateSMILESforRadicalPosition(txtSmiles.Text.Trim())
                            && Validations.ValidateOpenningAndClosingBrackets(txtSmiles.Text.Trim()))
                        {
                            blValStatus = true;
                        }
                        else
                        {
                            strErrMsg = "Please specify/correct connecting point in SMILES";
                        }
                    }
                    else
                    {
                        strErrMsg = "Please enter SMILES";
                    }
                }
                else
                {
                    strErrMsg = "Please enter compound name";
                }
                
                errmsg_out = strErrMsg;
                return blValStatus;
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
            errmsg_out = strErrMsg;
            return blValStatus;
        }
    }
}
