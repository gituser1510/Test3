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
    public partial class frmLogin : Form
    {
        #region Class Constructor

        public frmLogin()
        {
            InitializeComponent();
        }
 
        #endregion

        #region Property Procedures

        private string _userrole = "";
        public string UserRole
        {
            get
            {
                return _userrole;
            }
            set
            {
                _userrole = value;
            }
        }

        private bool _submitclick = false;
        public bool SubmitClick
        {
            get
            {
                return _submitclick;
            }
            set
            {
                _submitclick = value;
            }
        }       

        #endregion

        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                cmbUserRoles.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUserName.Text.Trim() != "")
                {
                    if (txtPassword.Text.Trim() != "")
                    {                  
                        int userID = 0;
                        if (PepsiLiteDataAccess.DataOperations.CheckForValidUser(txtUserName.Text.Trim(), txtPassword.Text.Trim(), cmbUserRoles.SelectedItem.ToString(),out userID))
                        {
                            Classes.Generic_PepsiLite.UserID = userID;
                            Classes.Generic_PepsiLite.UserName = txtUserName.Text.Trim();
                            Classes.Generic_PepsiLite.UserRole = cmbUserRoles.SelectedItem.ToString();

                            UserRole = cmbUserRoles.SelectedItem.ToString();
                            SubmitClick = true;

                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Login Failed","Login",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter password", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter user name", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
        }
    }
}
