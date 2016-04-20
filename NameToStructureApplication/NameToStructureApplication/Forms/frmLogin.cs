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
using System.Collections;

#endregion

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

        #region Public Variables

        DataTable UserRoleTbl = null;

        #endregion

        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                GetUserNamesAndSetToUserNameTxtBox_AutoComplete();
                
                DataTable dtUserRoles = DataOperations.GetUserRoles();
                if (dtUserRoles != null)
                {
                    if (dtUserRoles.Rows.Count > 0)
                    {
                        UserRoleTbl = dtUserRoles;

                        cmbUserRoles.DataSource = Validations.GetArrayListFromDataTable(dtUserRoles,1);
                        cmbUserRoles.SelectedIndex = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
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

                        string strEncrpPwd = Encryption.EncriptDecript.Encrypt(txtPassword.Text.Trim());

                        if (PepsiLiteDataAccess.DataOperations.CheckForValidUser(txtUserName.Text.Trim(), strEncrpPwd, cmbUserRoles.SelectedItem.ToString(), out userID))
                        {
                            Generic.Generic_PepsiLite.UserID = userID;
                            Generic.Generic_PepsiLite.UserName = txtUserName.Text.Trim();
                            Generic.Generic_PepsiLite.UserRole = cmbUserRoles.SelectedItem.ToString();
                            Generic.Generic_PepsiLite.UserRoleID = GetRoleIDFromRoleName(cmbUserRoles.SelectedItem.ToString());

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
                        MessageBox.Show("Please enter password", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter user name", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private int GetRoleIDFromRoleName(string _rolename)
        {
            int intRoleID = 0;
            try
            {
                if (UserRoleTbl != null)
                {
                    if (UserRoleTbl.Rows.Count > 0)
                    {
                        DataRow[] dtResRows = UserRoleTbl.Select("Role = '" + _rolename + "'");
                        if (dtResRows != null)
                        {
                            if (dtResRows.Length > 0)
                            {
                                intRoleID = Convert.ToInt32(dtResRows[0][0]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
            return intRoleID;
        }

        private void GetUserNamesAndSetToUserNameTxtBox_AutoComplete()
        {
            try
            {
                DataTable dtUserNames = PepsiLiteDataAccess.DataOperations.RetrieveAllUserNames();
                if (dtUserNames != null)
                {
                    if (dtUserNames.Rows.Count > 0)
                    {
                        AutoCompleteStringCollection usrNameColl = new AutoCompleteStringCollection();

                        for (int i = 0; i < dtUserNames.Rows.Count; i++)
                        {
                            if (dtUserNames.Rows[i][0] != null)
                            {
                                usrNameColl.Add(dtUserNames.Rows[i][0].ToString());
                            }
                        }                        

                        txtUserName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        txtUserName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        txtUserName.AutoCompleteCustomSource = usrNameColl;
                    }
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }
    }
}
