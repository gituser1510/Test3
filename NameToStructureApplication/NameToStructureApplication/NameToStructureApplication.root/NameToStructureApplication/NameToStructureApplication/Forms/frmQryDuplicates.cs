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
    public partial class frmQryDuplicates : Form
    {
        public frmQryDuplicates()
        {
            InitializeComponent();
        }

        private void frmQryDuplicates_Load(object sender, EventArgs e)
        {
            try
            {
                ucCheckDuplicates1.pnlDups.Enabled = false;               
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
        }       
    }
}
