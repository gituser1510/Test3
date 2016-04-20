using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PepsiLiteDataAccess;
using System.Data.OleDb;

namespace NameToStructureApplication.TaskManagement
{
    public partial class frmInsertPhaseDetails : Form
    {
        public frmInsertPhaseDetails()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (pnlManual.Enabled)
                {
                    string strErrMsg_out = "";
                    if (ValidateUserInputs(out strErrMsg_out))
                    {
                        InsertPhaseDetails_Manual();
                    }
                    else
                    {
                        MessageBox.Show(strErrMsg_out, "Invalid User Inputs", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (pnlFromFile.Enabled)
                {
                    InsertPhaseDetails_FromFile();
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private bool ValidateUserInputs(out string errmsg_out)
        {
            bool blStatus = false;
            string strErrMsg = "";
            try
            {
                if (txtPhaseName.Text.Trim() != "")
                {
                    if (txtShipment.Text.Trim() != "")
                    {
                        if (txtTAN.Text.Trim() != "")
                        {
                            if (Validations.IsValidTanNumber(txtTAN.Text.Trim()))
                            {
                                blStatus = true;
                            }
                            else
                            {
                                strErrMsg = "Invalid TAN \r\n TAN format must be 12345678A";
                            }
                        }
                        else
                        {
                            strErrMsg = "Please enter TAN";
                        }
                    }
                    else
                    {
                        strErrMsg = "Please enter shipment name";
                    }
                }
                else
                {
                    strErrMsg = "Please enter phase name";
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
            errmsg_out = strErrMsg;
            return blStatus;
        }

        private void frmInsertPhaseDetails_Load(object sender, EventArgs e)
        {
            try
            {
                cmbIsEligible.SelectedIndex = 0;

                rbnManual.Checked = true;
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "Excel|*.xls";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    txtFilePath.Text = openFileDialog1.FileName;
                    BtnProceed_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        protected void BtnProceed_Click(object sender, EventArgs e)
        {
            string strfilename = txtFilePath.Text;

            string ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;" + @"Data Source=" + strfilename + ";" +
                                      @"Extended Properties=" + Convert.ToChar(34).ToString() +
                                      @"Excel 8.0;HDR=YES" + Convert.ToChar(34).ToString();

            OleDbConnection conn = new OleDbConnection(ConnectionString);
            conn.Open();
            try
            {               
                OleDbDataAdapter oda = new OleDbDataAdapter("select * from [Sheet1$]", conn);
                DataSet ds = new DataSet();
                oda.Fill(ds);
                dtGridPhaseDtls.DataSource = ds.Tables[0];             
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        private void rbnFrmFile_CheckedChanged(object sender, EventArgs e)
        {
            EnablePanelOnSelection();
        }

        private void rbnManual_CheckedChanged(object sender, EventArgs e)
        {
            EnablePanelOnSelection();
        }

        private void EnablePanelOnSelection()
        {
            try
            {
                dtGridPhaseDtls.DataSource = null;
                txtFilePath.Text = "";

                txtPhaseName.Text = "";
                txtShipment.Text = "";
                txtTAN.Text = "";
                numDDSubsCnt.Value = 0;

                if (rbnFrmFile.Checked)
                {                   
                    pnlFromFile.Enabled = true;                    
                    pnlManual.Enabled = false;
                }
                else if (rbnManual.Checked)
                {
                    pnlFromFile.Enabled = false;
                    pnlManual.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void InsertPhaseDetails_Manual()
        {
            try
            {
                bool blIsEligible = false;
                if (cmbIsEligible.SelectedItem.ToString().ToUpper() == "YES")
                {
                    blIsEligible = true;
                }            

                //Check for duplicate entries here
                if (!DataOperations.CheckDuplicatePhase_Shipment_TAN(txtPhaseName.Text.Trim(), txtShipment.Text.Trim(), txtTAN.Text.Trim(), dateTimePicker1.Value))
                {
                    if (DataOperations.InsertPhase_Shipment_TAN_Details(txtPhaseName.Text.Trim(), txtShipment.Text.Trim(),
                                    txtTAN.Text.Trim(), blIsEligible, Convert.ToInt32(numDDSubsCnt.Value), dateTimePicker1.Value, Generic.Generic_PepsiLite.UserID))//DateTime.Now
                    {
                        MessageBox.Show("Inserted details in database successfully", "Phase Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error in insertion", "Phase Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Duplicate Entry", "Phase Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void InsertPhaseDetails_FromFile()
        {
            try
            {
                DataTable dtGridData = (DataTable)dtGridPhaseDtls.DataSource;
                if (dtGridData != null)
                {
                    if (dtGridData.Rows.Count > 0)
                    {
                        int cntr = 0;
                        DialogResult diares = MessageBox.Show("Duplicate records will be removed automatically. Do you want to continue?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (diares == DialogResult.Yes)
                        {
                            string strPhaseName = "";
                            string strShipmentName = "";
                            string strTANName = "";
                            bool blIsEligible = false;
                            int intSubsCnt = 0;
                            DateTime date;

                            for (int i = 0; i < dtGridData.Rows.Count; i++)
                            {
                                strPhaseName = dtGridData.Rows[i]["Phase Name"].ToString().Trim();
                                strShipmentName = dtGridData.Rows[i]["Shipment Name"].ToString().Trim();
                                strTANName = dtGridData.Rows[i]["TAN"].ToString().Trim();

                                date = DateTime.Parse(dtGridData.Rows[i]["Phase Date"].ToString().Trim());

                                if (dtGridData.Rows[i]["Is Eligible"].ToString().Trim().ToUpper() == "YES")
                                {
                                    blIsEligible = true;
                                }
                                else
                                {
                                    blIsEligible = false;
                                }
                                int.TryParse(dtGridData.Rows[i]["Substance Count"].ToString(), out intSubsCnt);

                                if (!DataOperations.CheckDuplicatePhase_Shipment_TAN(strPhaseName, strShipmentName, strTANName, date))
                                {
                                    if (DataOperations.InsertPhase_Shipment_TAN_Details(strPhaseName, strShipmentName, strTANName, blIsEligible, intSubsCnt, date, Generic.Generic_PepsiLite.UserID))//DateTime.Now
                                    {
                                        cntr++;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Error in insertion", "Phase Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                            if (cntr == dtGridData.Rows.Count)
                            {
                                MessageBox.Show("Inserted details in database successfully", "Phase Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No Data is available", "Phase details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("No Data is available", "Phase details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }
    }
}
