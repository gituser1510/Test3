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
                cmbUserRoles.SelectedIndex = 0;

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
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
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
                            //if not duplicate then insert into database
                            if (PepsiLiteDataAccess.DataOperations.InsertNewUserDetails(txtUserName.Text.Trim(), txtPassword.Text.Trim(), cmbUserRoles.SelectedItem.ToString(),DateTime.Now))
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
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
        }
    }
}
