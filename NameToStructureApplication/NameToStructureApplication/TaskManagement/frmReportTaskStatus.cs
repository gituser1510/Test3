using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NameToStructureApplication.TaskManagement
{
    public partial class frmReportTaskStatus : Form
    {
        public frmReportTaskStatus()
        {
            InitializeComponent();
        }

        private void frmReportTaskStatus_Load(object sender, EventArgs e)
        {
            try
            {
                //Retrieve assigned TANs for the user based on userid,role
                DataTable dtAssignedTans = PepsiLiteDataAccess.DataOperations.RetrieveTANIDS_All();
                if (dtAssignedTans != null)
                {
                    if (dtAssignedTans.Rows.Count > 0)
                    {
                        cmbAssignedTANs.DataSource = Validations.GetArrayListFromDataTable(dtAssignedTans,0);
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
