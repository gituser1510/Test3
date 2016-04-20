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

namespace NameToStructureApplication.TaskManagement
{
    public partial class frmTaskAssignment : Form
    {
        public frmTaskAssignment()
        {
            InitializeComponent();
        }

        #region Property Procedures

        private DataTable _dtavailtans = null;
        public DataTable AvailTANsTbl
        {
            get
            {
                return _dtavailtans;
            }
            set
            {
                _dtavailtans = value;
            }
        }

        private DataTable _dtselectedtans = null;
        public DataTable SelectedTANsTbl
        {
            get
            {
                return _dtselectedtans;
            }
            set
            {
                _dtselectedtans = value;
            }
        }

        #endregion

        #region Public Variables

        ArrayList availTANList = new ArrayList();
        ArrayList selTANList = new ArrayList();

        #endregion

        private void frmTaskAssignment_Load(object sender, EventArgs e)
        {
            try
            {
                int userID = Generic.Generic_PepsiLite.UserID;
                int userRoleID = Generic.Generic_PepsiLite.UserRoleID;

                string userRole = Generic.Generic_PepsiLite.UserRole;

                //If the user is PM he can only assign TANS,So TAN status always "TAN Assigned"
                if (userRole.ToUpper() == "PROJECT MANAGER")
                {
                    lblAssTansFor.Visible = false;
                    cmbAssignFor.Visible = false;
                }
                else
                {
                    cmbAssignFor.SelectedIndex = 0;
                }

                //Get reporting users details
                DataTable dtUserDetails = DataOperations.GetReportingUserDetails(userID, userRoleID);
                if (dtUserDetails != null)
                {
                    if (dtUserDetails.Rows.Count > 0)
                    {
                        ArrayList lstUserDtls = Validations.GetArrayListFromDataTable(dtUserDetails,0);
                        cmbUserName.DataSource = lstUserDtls;
                    }
                }

                //Phase details
                DataTable dtPhaseDetails = DataOperations.RetrievePhaseDetailsOnUserRole(userID, userRoleID);
                if (dtPhaseDetails != null)
                {
                    if (dtPhaseDetails.Rows.Count > 0)
                    {
                        ArrayList lstPhaseDtls = Validations.GetArrayListFromDataTable(dtPhaseDetails,0);
                        cmbPhase.DataSource = lstPhaseDtls;
                        cmbPhase.SelectedIndex = 0;
                    }
                }
                
                //Get already assigned TANs
                DataTable dtAssTANDetails = DataOperations.GetAssignedTANsOnPhase_Shipment(userID, userRoleID);
                if (dtAssTANDetails != null)
                {
                    if (dtAssTANDetails.Rows.Count > 0)
                    {
                        dtGridAssigedTANs.DataSource = dtAssTANDetails;
                    }
                }    
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }
        
        private void cmbUserName_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbUserName.SelectedItem != null)
                {
                    DataTable dtUserRoles = DataOperations.RetrieveUserRolesOnuserName(cmbUserName.SelectedItem.ToString());
                    if (dtUserRoles != null)
                    {
                        if (dtUserRoles.Rows.Count > 0)
                        {
                            ArrayList lstUserRoles = Validations.GetArrayListFromDataTable(dtUserRoles,0);
                            cmbUserRole.DataSource = lstUserRoles;
                        }
                    }                    
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        DataTable dtselTans = null;
        private void btnSelOne_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtGrid_TANs.Rows.Count > 0)
                {
                    if (dtGrid_TANs.SelectedRows.Count > 0)
                    {
                        if (dtselTans == null)
                        {
                            dtselTans = AvailTANsTbl.Clone();
                        }
                        int rindex_out = 0;
                        for (int i = 0; i < dtGrid_TANs.SelectedRows.Count; i++)
                        {
                            dtselTans.ImportRow(GetSelectedRowFromMainTable(dtGrid_TANs.SelectedRows[i].Cells[0].Value.ToString(), out rindex_out));
                            AvailTANsTbl.Rows[rindex_out].Delete();                            
                        }

                        AvailTANsTbl.AcceptChanges();                       

                        dtGrid_TANs.DataSource = null;
                        dtGrid_TANs.DataSource = AvailTANsTbl;

                        SelectedTANsTbl = dtselTans;

                        dtGridSelTANs.DataSource = null;
                        dtGridSelTANs.DataSource = SelectedTANsTbl;
                    }
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private DataRow GetSelectedRowFromMainTable(string _tannumber,out int _rowindex_out)
        {
            try
            {
                if (AvailTANsTbl != null)
                {
                    if (AvailTANsTbl.Rows.Count > 0)
                    {
                        DataRow dtRow = null;
                        for (int i = 0; i < AvailTANsTbl.Rows.Count; i++)
                        {
                            if (AvailTANsTbl.Rows[i][0].ToString() == _tannumber)
                            {
                                dtRow = AvailTANsTbl.Rows[i];
                                _rowindex_out = i;
                                return dtRow;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
            _rowindex_out = 0;
            return null;
        }

        private void btnDelOne_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtGridSelTANs.Rows.Count > 0)
                {
                    if (dtGridSelTANs.SelectedRows.Count > 0)
                    {
                        DataTable dtAvailTans = AvailTANsTbl;
                        int seltan_out = 0;
                        for (int i = 0; i < dtGridSelTANs.SelectedRows.Count; i++)
                        {
                           dtAvailTans.ImportRow(GetSelectedRowFromSelectedTANSTable(dtGridSelTANs.SelectedRows[i].Cells[0].Value.ToString().ToString(), out seltan_out));
                           SelectedTANsTbl.Rows[seltan_out].Delete();
                        }
                        SelectedTANsTbl.AcceptChanges();

                        AvailTANsTbl = dtAvailTans;

                        dtGrid_TANs.DataSource = null;
                        dtGrid_TANs.DataSource = AvailTANsTbl;                        

                        dtGridSelTANs.DataSource = null;
                        dtGridSelTANs.DataSource = SelectedTANsTbl;
                    }
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private DataRow GetSelectedRowFromSelectedTANSTable(string _tannumber, out int _rowindex_out)
        {
            try
            {
                if (SelectedTANsTbl != null)
                {
                    if (SelectedTANsTbl.Rows.Count > 0)
                    {
                        DataRow dtRow = null;
                        for (int i = 0; i < SelectedTANsTbl.Rows.Count; i++)
                        {
                            if (SelectedTANsTbl.Rows[i][0].ToString() == _tannumber)
                            {
                                dtRow = SelectedTANsTbl.Rows[i];
                                _rowindex_out = i;
                                return dtRow;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
            _rowindex_out = 0;
            return null;
        }

        private void AddItem(string itemname)
        {
            try
            {
                selTANList.Add(itemname);
                availTANList.Remove(itemname);
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void DeleteItem(string itemname)
        {
            try
            {
                availTANList.Add(itemname);
                selTANList.Remove(itemname);
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void cmbPhase_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Shipment details
                if (cmbPhase.SelectedItem != null)
                {
                    DataTable dtShipmentDetails = DataOperations.GetShipmentDetailsOnPhase(cmbPhase.SelectedItem.ToString());
                    if (dtShipmentDetails != null)
                    {
                        if (dtShipmentDetails.Rows.Count > 0)
                        {
                            ArrayList lstShipDtls = Validations.GetArrayListFromDataTable(dtShipmentDetails,0);
                            cmbShipment.DataSource = lstShipDtls;
                            cmbShipment.SelectedIndex = 0;
                        }
                    }
                }

                GetTANsAndBindToControl();
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void cmbShipment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetTANsAndBindToControl();
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            } 
        }

        private void GetTANsAndBindToControl()
        {
            try
            {
                //TANs on Phase,Shipment,userid and roleid
                if (cmbPhase.SelectedItem != null && cmbShipment.SelectedItem != null)
                {
                    DataTable dtTANs = DataOperations.GetTANsOnPhase_Shipment_UID_RoleID(cmbPhase.SelectedItem.ToString(), cmbShipment.SelectedItem.ToString(), Generic.Generic_PepsiLite.UserID, Generic.Generic_PepsiLite.UserRoleID);
                    if (dtTANs != null)
                    {
                        if (dtTANs.Rows.Count > 0)
                        {
                            AvailTANsTbl = dtTANs;
                            dtGrid_TANs.DataSource = AvailTANsTbl;
                        }
                        else
                        {
                            AvailTANsTbl = null;
                            dtGrid_TANs.DataSource = AvailTANsTbl;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtGridSelTANs.Rows.Count > 0)
                {
                    string strPhName = cmbPhase.SelectedItem.ToString();
                    string strShName = cmbShipment.SelectedItem.ToString();
                    
                    string strAss_to_User = cmbUserName.SelectedItem.ToString();
                    string strAss_to_URole = cmbUserRole.SelectedItem.ToString();

                    string strTanStatus = "";

                    if (cmbAssignFor.Visible)//means Team Lead
                    {
                        strTanStatus = cmbAssignFor.SelectedItem.ToString();
                    }
                    else
                    {
                        strTanStatus = "TAN Assigned";
                    }

                    //Validate Assignment details here
                    string strErrMsg_out = "";
                    if (ValidateAssignmentDetails(strAss_to_URole, strTanStatus, out strErrMsg_out))
                    {
                        string strTAN = "";
                        string strErrMsg = "";
                        int intCntr = 0;

                        for (int i = 0; i < dtGridSelTANs.Rows.Count; i++)
                        {
                            strTAN = dtGridSelTANs.Rows[i].Cells[0].Value.ToString();
                            if (DataOperations.InsertTaskAssignmentDetails(strPhName, strShName, strTAN, strAss_to_User, strAss_to_URole, DateTime.Now, Generic.Generic_PepsiLite.UserID, Generic.Generic_PepsiLite.UserRole, strTanStatus))
                            {
                                intCntr++;
                            }
                            else
                            {
                                strErrMsg = "Error in assigning TAN - " + strTAN;
                                break;
                            }
                        }
                        if (intCntr == dtGridSelTANs.Rows.Count)
                        {
                            //Refresh Assigned TANs grid to refrect changes
                            DataTable dtAssTANDetails = DataOperations.GetAssignedTANsOnPhase_Shipment(Generic.Generic_PepsiLite.UserID, Generic.Generic_PepsiLite.UserRoleID);
                            if (dtAssTANDetails != null)
                            {
                                if (dtAssTANDetails.Rows.Count > 0)
                                {
                                    dtGridAssigedTANs.DataSource = dtAssTANDetails;
                                }
                            }

                            //Clear selected TANS grid
                            dtGridSelTANs.DataSource = null;
                            SelectedTANsTbl = null;
                            dtselTans = null;
                            MessageBox.Show("Assigned TANs successfully", "Assign TAN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show(strErrMsg_out, "In-Valid Assignment Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please assign TANs");
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private bool ValidateAssignmentDetails(string _userrole,string _assignedfor,out string _errmsg_out)
        {
            bool blStatus = false;
            string strErrMsg = "";
            try
            {
                if (Generic.Generic_PepsiLite.UserRole.ToUpper() != "PROJECT MANAGER")
                {
                    if (dtGridSelTANs.Rows.Count > 0)
                    {
                        string strTanStatus = "";
                        for (int i = 0; i < dtGridSelTANs.Rows.Count; i++)
                        {
                            strTanStatus = dtGridSelTANs.Rows[i].Cells[2].Value.ToString();

                            if (_userrole.ToUpper() == "REVIEWER" && strTanStatus.ToUpper() == "CURATION COMPLETED")
                            {
                                if (!(_assignedfor.ToUpper() == "ASSIGNED FOR REVIEW" || _assignedfor.ToUpper() == "RE ASSIGNED FOR REVIEW"))
                                {
                                    strErrMsg = "Only Assigned for Review/Re-Assigned for Review task can be assigned to Reviewer";
                                    break;
                                }
                                else
                                {
                                    blStatus = true;
                                }
                            }
                            else if (_userrole.ToUpper() == "CURATOR" && strTanStatus.ToUpper() == "TAN ASSIGNED")
                            {
                                if (!(_assignedfor.ToUpper() == "ASSIGNED FOR CURATION" || _assignedfor.ToUpper() == "RE ASSIGNED FOR CURATION"))
                                {
                                    strErrMsg = "Only Assigned for Curation/Re-Assigned for Curation task can be assigned to Curator";
                                    break;
                                }
                                else
                                {
                                    blStatus = true;
                                }
                            }
                            else if (_userrole.ToUpper() == "REVIEWER" && strTanStatus.ToUpper() == "TAN ASSIGNED")
                            {
                                strErrMsg = "Only Curation Completed tasks can be assigned to Reviewer";
                                break;
                            }
                            else
                            {
                                blStatus = true;
                            }
                        }
                    }
                }
                else
                {
                    blStatus = true;
                    strErrMsg = "";
                }
                _errmsg_out = strErrMsg;
                return blStatus;
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
            _errmsg_out = strErrMsg;
            return blStatus;
        }

        private void cmbShipment_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (dtGridSelTANs.Rows.Count > 0)
                {
                    MessageBox.Show("Assign/Delete selected TANs before selecting Shipment","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }       

        private void cmbPhase_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (dtGridSelTANs.Rows.Count > 0)
                {
                    MessageBox.Show("Assign/Delete selected TANs before selecting Phase", "",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }
    }
}
