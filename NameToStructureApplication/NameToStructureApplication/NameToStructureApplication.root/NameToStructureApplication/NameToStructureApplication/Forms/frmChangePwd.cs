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
    public partial class frmChangePwd : Form
    {
        public frmChangePwd()
        {
            InitializeComponent();
        }
        
        private void frmChangePwd_Load(object sender, EventArgs e)
        {
            try
            {
                txtUserName.Text = Classes.Generic_PepsiLite.UserName;
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string strErrMsg = "";
                if (ValidateUserInputs(out strErrMsg))
                {
                    if (PepsiLiteDataAccess.DataOperations.UpdateUserDetails(txtUserName.Text.Trim(), txtPassword.Text.Trim(), txtnewPassword.Text.Trim(), Classes.Generic_PepsiLite.UserRole))
                    {
                        if (MessageBox.Show("Password updated successfully") == DialogResult.OK)
                        {                            
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error in update");
                    }

                }
                else
                {
                    MessageBox.Show(strErrMsg, "Invalid user inputs", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
        }

        private bool ValidateUserInputs(out string errMsg_out)
        {
            bool blStatus = false;
            string strErrMsg = "";
            try
            {
                if (txtPassword.Text.Trim() != "")
                {
                    if (txtnewPassword.Text.Trim() != "")
                    {
                        if (txtconfNewPassword.Text.Trim() != "")
                        {
                            if (txtPassword.Text.Trim() != txtnewPassword.Text.Trim())
                            {
                                if (txtnewPassword.Text.Trim() == txtconfNewPassword.Text.Trim())
                                {
                                    blStatus = true;
                                }
                                else
                                {
                                    strErrMsg = "Password and Confirm Password values are not same";
                                }
                            }
                            else
                            {
                                strErrMsg = "Existinng password and New Password can't be same";
                            }
                        }
                        else
                        {
                            strErrMsg = "Please confirm New Password";
                        }
                    }
                    else
                    {
                        strErrMsg = "Please enter New Password";
                    }
                }
                else
                {
                    strErrMsg = "Please enter existing Password";
                }

                errMsg_out = strErrMsg;
                return blStatus;

            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
            errMsg_out = strErrMsg;
            return blStatus;
        }
    }
}
