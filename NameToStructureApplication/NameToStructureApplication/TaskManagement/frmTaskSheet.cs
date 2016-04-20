using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PepsiLiteDataAccess;

namespace NameToStructureApplication.TaskManagement
{
    public partial class frmTaskSheet : Form
    {
        public frmTaskSheet()
        {
            InitializeComponent();
        }

        #region Property Procedures

        private string _selectedTAN = "";
        public string SelectedTAN
        {
            get
            {
                return _selectedTAN;
            }
            set
            {
                _selectedTAN = value;
            }
        }

        private DataTable _selTANDetails = null;
        public DataTable SelTANDetails
        {
            get
            {
                return _selTANDetails;
            }
            set
            {
                _selTANDetails = value;
            }
        }

        private DataTable _assignedTANs = null;
        public DataTable AssignedTANs
        {
            get
            {
                return _assignedTANs;
            }
            set
            {
                _assignedTANs = value;
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

        private void frmTaskSheet_Load(object sender, EventArgs e)
        {
            try
            {
                lblUserName.Text = Generic.Generic_PepsiLite.UserName;

                //Get Assigned TANs for this user and bind to grid here
                BindAssignedTANsToGrid(_assignedTANs);
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void BindAssignedTANsToGrid(DataTable _dtassignedtans)
        {
            try
            {
                if (_dtassignedtans != null)
                {
                    if (_dtassignedtans.Rows.Count > 0)
                    {
                        dtGrid_Assign_TANs.DataSource = _dtassignedtans;
                        dtGrid_Assign_TANs.Columns[0].DataPropertyName = _dtassignedtans.Columns[0].ColumnName;
                        dtGrid_Assign_TANs.Columns[1].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void dtGrid_Assign_TANs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    SelectedTAN = dtGrid_Assign_TANs.Rows[e.RowIndex].Cells[0].Value.ToString();

                    DataTable dtTanDetails = PepsiLiteDataAccess.DataOperations.GetTANDetailsOnUserIDAndRoleID(_selectedTAN, Generic.Generic_PepsiLite.UserID, Generic.Generic_PepsiLite.UserRoleID);
                    if (dtTanDetails != null)
                    {
                        if (dtTanDetails.Rows.Count > 0)
                        {
                            SelTANDetails = dtTanDetails;
                            SubmitClick = true;
                            this.Close();
                        }
                        else
                        {
                            if (MessageBox.Show("No data found for the selected TAN \r\n Do you want to load it as new TAN?", "No data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                SelTANDetails = dtTanDetails;
                                SubmitClick = true;
                                this.Close();
                            }
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("No data found for the selected TAN \r\n Do you want to load it as new TAN?", "No data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            SelTANDetails = dtTanDetails;
                            SubmitClick = true;
                            this.Close();
                        }
                    }                   
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void dtGrid_Assign_TANs_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                //store a string representation of the row number in 'strRowNumber'
                string strRowNumber = (e.RowIndex + 1).ToString();

                //prepend leading zeros to the string if necessary to improve
                //appearance. For example, if there are ten rows in the grid,
                //row seven will be numbered as "07" instead of "7". Similarly, if 
                //there are 100 rows in the grid, row seven will be numbered as "007".
                while (strRowNumber.Length < dtGrid_Assign_TANs.RowCount.ToString().Length) strRowNumber = "0" + strRowNumber;

                //determine the display size of the row number string using
                //the DataGridView's current font.
                SizeF size = e.Graphics.MeasureString(strRowNumber, dtGrid_Assign_TANs.Font);

                //adjust the width of the column that contains the row header cells 
                //if necessary
                if (dtGrid_Assign_TANs.RowHeadersWidth < (int)(size.Width + 20)) dtGrid_Assign_TANs.RowHeadersWidth = (int)(size.Width + 20);

                //this brush will be used to draw the row number string on the
                //row header cell using the system's current ControlText color
                Brush b = SystemBrushes.ControlText;

                //draw the row number string on the current row header cell using
                //the brush defined above and the DataGridView's default font
                e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void curationCompletedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtGrid_Assign_TANs.SelectedRows.Count == 1)
                {
                    if (MessageBox.Show("Do you want to report curation complete status?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string strPhName = dtGrid_Assign_TANs.SelectedRows[0].Cells["Phase Name"].Value.ToString();
                        string strShName = dtGrid_Assign_TANs.SelectedRows[0].Cells["Shipment Name"].Value.ToString();
                        string strAssignedUser = dtGrid_Assign_TANs.SelectedRows[0].Cells["Assigned User"].Value.ToString();
                        string strAssUserRole = dtGrid_Assign_TANs.SelectedRows[0].Cells["Assigned User Role"].Value.ToString();
                        string strTAN = dtGrid_Assign_TANs.SelectedRows[0].Cells["TAN"].Value.ToString();

                        string strTanStatus = "Curation Completed";                       

                        if (DataOperations.InsertTaskAssignmentDetails(strPhName, strShName, strTAN, strAssignedUser, strAssUserRole, DateTime.Now, Generic.Generic_PepsiLite.UserID, Generic.Generic_PepsiLite.UserRole, strTanStatus))
                        {
                            //Retrieve assigned TANs for the user based on userid,role
                            DataTable dtAssignedTans = PepsiLiteDataAccess.DataOperations.RetrieveUserAssignedTANs(Generic.Generic_PepsiLite.UserName, Generic.Generic_PepsiLite.UserRole);
                            BindAssignedTANsToGrid(dtAssignedTans);
                            
                            MessageBox.Show("Reported Curation Complete Status","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        }
                        else
                        {                        
                            MessageBox.Show("Error in Reporting Curation Complete Status", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }        

        private void reviewCompletedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtGrid_Assign_TANs.SelectedRows.Count == 1)
                {
                    if (MessageBox.Show("Do you want to report review complete status?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string strPhName = dtGrid_Assign_TANs.SelectedRows[0].Cells["Phase Name"].Value.ToString();
                        string strShName = dtGrid_Assign_TANs.SelectedRows[0].Cells["Shipment Name"].Value.ToString();
                        string strAssignedUser = dtGrid_Assign_TANs.SelectedRows[0].Cells["Assigned User"].Value.ToString();
                        string strAssUserRole = dtGrid_Assign_TANs.SelectedRows[0].Cells["Assigned User Role"].Value.ToString();
                        string strTAN = dtGrid_Assign_TANs.SelectedRows[0].Cells["TAN"].Value.ToString();

                        string strTanStatus = "Review Completed";

                        if (DataOperations.InsertTaskAssignmentDetails(strPhName, strShName, strTAN, strAssignedUser, strAssUserRole, DateTime.Now, Generic.Generic_PepsiLite.UserID, Generic.Generic_PepsiLite.UserRole, strTanStatus))
                        {
                            //Retrieve assigned TANs for the user based on userid,role
                            DataTable dtAssignedTans = PepsiLiteDataAccess.DataOperations.RetrieveUserAssignedTANs(Generic.Generic_PepsiLite.UserName, Generic.Generic_PepsiLite.UserRole);
                            BindAssignedTANsToGrid(dtAssignedTans);
                            
                            MessageBox.Show("Reported Review Complete Status", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error in Reporting Review Complete Status", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }
        
        private void tANCompletedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtGrid_Assign_TANs.SelectedRows.Count == 1)
                {
                    if (MessageBox.Show("Do you want to report Curation and Review Completed status?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string strPhName = dtGrid_Assign_TANs.SelectedRows[0].Cells["Phase Name"].Value.ToString();
                        string strShName = dtGrid_Assign_TANs.SelectedRows[0].Cells["Shipment Name"].Value.ToString();
                        string strAssignedUser = dtGrid_Assign_TANs.SelectedRows[0].Cells["Assigned User"].Value.ToString();
                        string strAssUserRole = dtGrid_Assign_TANs.SelectedRows[0].Cells["Assigned User Role"].Value.ToString();
                        string strTAN = dtGrid_Assign_TANs.SelectedRows[0].Cells["TAN"].Value.ToString();

                        string strTanStatus = "Curation and Review Completed";

                        if (DataOperations.InsertTaskAssignmentDetails(strPhName, strShName, strTAN, strAssignedUser, strAssUserRole, DateTime.Now, Generic.Generic_PepsiLite.UserID, Generic.Generic_PepsiLite.UserRole, strTanStatus))
                        {
                            //Retrieve assigned TANs for the user based on userid,role
                            DataTable dtAssignedTans = PepsiLiteDataAccess.DataOperations.RetrieveUserAssignedTANs(Generic.Generic_PepsiLite.UserName, Generic.Generic_PepsiLite.UserRole);
                            BindAssignedTANsToGrid(dtAssignedTans);
                            
                            MessageBox.Show("Reported Curation and Review Completed Status", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error in Reporting Curation and Review Completed Status", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void cntMnuStrip_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                DisableContextMenuItems();

                string strUserRole = Generic.Generic_PepsiLite.UserRole.ToUpper();
                switch (strUserRole)
                {
                    case "CURATOR":
                        curationCompletedToolStripMenuItem.Visible = true;
                        break;
                    case "REVIEWER":
                        reviewCompletedToolStripMenuItem.Visible = true;
                        break;
                    case "TEAM LEAD":
                        tANCompletedToolStripMenuItem.Visible = true;
                        break;
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void DisableContextMenuItems()
        {
            try
            {
                curationCompletedToolStripMenuItem.Visible = false;                
                reviewCompletedToolStripMenuItem.Visible = false;         
                tANCompletedToolStripMenuItem.Visible = false;
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }
    }
}
