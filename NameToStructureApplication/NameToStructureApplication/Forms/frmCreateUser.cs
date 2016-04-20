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
    public partial class frmCreateUser : Form
    {
        public frmCreateUser()
        {
            InitializeComponent();
        }

        private void frmCreateUser_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dtUserRoles = DataOperations.GetUserRoles();
                if (dtUserRoles != null)
                {
                    if (dtUserRoles.Rows.Count > 0)
                    {
                        cmbUserRoles.DataSource = Validations.GetArrayListFromDataTable(dtUserRoles,1);
                        cmbUserRoles.SelectedIndex = 1;
                    }
                }               

                DataTable dtUserDetails = PepsiLiteDataAccess.DataOperations.RetrieveUserDetails();
                if (dtUserDetails != null)
                {
                    if (dtUserDetails.Rows.Count > 0)
                    {
                        dtGrid_Users.DataSource = dtUserDetails;
                    }
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUserName.Text.Trim() != "")
                {
                    if (txtPassword.Text.Trim() != "")
                    {
                       //Check for dupliate user here
                        if (!PepsiLiteDataAccess.DataOperations.CheckForDuplicateUser(txtUserName.Text.Trim(), cmbUserRoles.SelectedItem.ToString()))
                        {
                            string strPwd_Enc = Encryption.EncriptDecript.Encrypt(txtPassword.Text.Trim());
                            //if not duplicate then insert into database
                            if (PepsiLiteDataAccess.DataOperations.InsertNewUserDetails(txtUserName.Text.Trim(), strPwd_Enc, cmbUserRoles.SelectedItem.ToString(), DateTime.Now))
                            {
                                //refresh usertable in the grid
                                DataTable dtUserDetails = PepsiLiteDataAccess.DataOperations.RetrieveUserDetails();
                                
                                if (dtUserDetails != null)
                                {
                                    if (dtUserDetails.Rows.Count > 0)
                                    {
                                        dtGrid_Users.DataSource = dtUserDetails;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter password");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter user name");
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }
    }
}
