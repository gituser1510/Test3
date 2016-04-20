using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NameToStructureApplication
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmMain_PepsiLite());//Enumeration.frmRGrpEnum frmMain_PepsiLite
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
        }
    }
}
