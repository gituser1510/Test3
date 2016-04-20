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
    public partial class frmRetrievePhaseDtls : Form
    {
        public frmRetrievePhaseDtls()
        {
            InitializeComponent();
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            try
            {
                string strSrchQry = GetSearchQuery();
                if (strSrchQry != "")
                {
                    DataTable dtPhaseDtls = DataOperations.RetrieveSearchResults(strSrchQry);

                    if (dtPhaseDtls != null)
                    {
                        if (dtPhaseDtls.Rows.Count > 0)
                        {
                            dtGridPDetails.DataSource = dtPhaseDtls;
                        }
                        else
                        {
                            MessageBox.Show("No data found", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No data found", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private string GetSearchQuery()
        {
            string strSrchQry = "";
            try
            { 
                strSrchQry = "select phase_date,phase_name,shipment_name,tan from pepsilite.phase_shipment_tan where phase_date = '" + dateTimePicker1.Value + "' ";

                //Phase Name
                if (txtPhaseName.Text.Trim() != "")
                {
                    strSrchQry = strSrchQry + " and phase_name = '" + txtPhaseName.Text.Trim() + "' ";
                }
                //Shipment name
                if (txtShipment.Text.Trim() != "")
                {
                    strSrchQry = strSrchQry + " and shipment_name = '" + txtShipment.Text.Trim() + "';";
                }
                return strSrchQry;
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
            return strSrchQry;
        }        
    }
}
