using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections;
using System.ComponentModel;

namespace PepsiLiteUpdates
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {      
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(OnUnhandledExceptionPolicy);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                //Check for updates
                CheckUpdates();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        /// <summary>
        /// Check For updates in ADOPT 
        /// This Exe will check for the updated adopt dlls and start refering dlls.
        /// </summary>
        static void CheckUpdates()
        {
            #region Check For Updates

            string strPepsiLitever = "1.0.0.";
            frmupdates objUpdates = new frmupdates();
            string strapplicationpath = System.Windows.Forms.Application.StartupPath.ToString(); //Get application startup path
            string FilePath = "";
            ///Check for putty key, if not create puttt
            objUpdates.CreatePuttyKey(System.Configuration.ConfigurationSettings.AppSettings["PuttyKeyPath"].ToString());
            FilePath = strapplicationpath + "\\" + "PEPSILITE";
            objUpdates.Hide();
            objUpdates.Refresh();
            
            try
            {
                Hashtable htwritefilenames = new Hashtable();
                Hashtable htfilestobeupdated = new Hashtable();
                htfilestobeupdated = objUpdates.GetFileNamestobeUpdated();
               
                //This will return no of files to be updated
                string[] strdllnames = null;
                strdllnames = objUpdates.StrDllNames;
                if (strdllnames != null)
                {
                    if (strdllnames.Length > 0)
                    {
                        for (int i = 0; i < strdllnames.Length; i++)
                        {
                            if (!htwritefilenames.ContainsKey(strdllnames[i]))
                            {
                                htwritefilenames.Add(strdllnames[i], objUpdates.fileread(FilePath, strdllnames[i].ToString()));
                            }
                        }
                    }
                }

                if (htfilestobeupdated.Count > 0)
                {                    
                    objUpdates.HtFilestoupdates = htfilestobeupdated;
                    objUpdates.Show();
                    if (objUpdates.HtFilesDownloaded != null)
                    {
                        if (objUpdates.HtFilesDownloaded.Count > 0)
                        {
                            IDictionaryEnumerator myEnumerator = objUpdates.HtFilesDownloaded.GetEnumerator();
                            while (myEnumerator.MoveNext())
                            {
                                if (myEnumerator.Value.ToString().ToUpper() == "Y")
                                {
                                    if (htwritefilenames.ContainsKey(myEnumerator.Key))
                                    {
                                        string strfileoutpath = "";
                                        htwritefilenames[myEnumerator.Key] = myEnumerator.Key.ToString() + "#" + strPepsiLitever + objUpdates.GetNewDLLMinorVersion(myEnumerator.Key.ToString(), out strfileoutpath);
                                    }
                                }
                            }
                        }
                        //Finally updating  files
                        IDictionaryEnumerator updatefile = htwritefilenames.GetEnumerator();
                        string strfinalupdatedtext = "";
                        int i = 0;
                        while (updatefile.MoveNext())
                        {
                            if (i == 0)
                            {
                                if (updatefile.Value != null)
                                    strfinalupdatedtext = updatefile.Value.ToString();
                            }
                            else
                            {
                                if (updatefile.Value != null)
                                    strfinalupdatedtext += "\r\n" + updatefile.Value.ToString();
                            }
                            i++;
                        }
                        objUpdates.fileupdate(FilePath, strfinalupdatedtext);
                    }
                }

                objUpdates.Hide();
                Application.Run(objUpdates.callPepsiLite()); //Show ADOPT Main Screen
            }
            catch (Exception ex)
            {
                objUpdates.WriteLog(ex.ToString());
                objUpdates.Hide();
                Application.Run(objUpdates.callPepsiLite()); //if any error in ADOPT Update opening ADOPT Main screen with dlls updates
            } 
            #endregion
            
        }
        /// <summary>
        /// Catching UnHandled Exception method
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="e"></param>
        static void OnUnhandledExceptionPolicy(Object Sender, UnhandledExceptionEventArgs e)
        {
            String InformationForLogging;
            Exception ex = e.ExceptionObject as Exception;

            if (ex != null)
            {
                // The unhandled Exception is CLS compliant
                // Extract the Information you want to know
                InformationForLogging = ex.ToString();
            }
            else
            {
                // The unhandled Exception is not CLS compliant
                // You can only handle this Exception as Object
                InformationForLogging = String.Format("Type: {0}{2}String: {1}",e.ExceptionObject.GetType(),
                   e.ExceptionObject.ToString(),
                   Environment.NewLine);
            }

            if (!e.IsTerminating)
            {
                // Exception occurred in a thread pool or finalizer thread
                // Debugger launches only explicitly
            }
            else
            {
                // Exception occurred in managed thread
                // Debugger will also launch when not launched explicitly
            }
            // explicitly launch the debugger (Visual Studio)
            Debugger.Launch();
        }
    }
}
