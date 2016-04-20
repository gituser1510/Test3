using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.IO;

namespace NameToStructureApplication.OSRA
{
    public static class ImageToStructure
    {
        public static bool GetStructureFromImage(Image chemImg, out string molstring_out, out bool ischiral_out, out string errmessage_out)
        {
            bool blStatus = false;
            string strMolString = "";
            string strErrMessage = "";
            bool blIsChiral = false;
            try
            {
                string strInputFileName = "CompName.png";                

                string strDirPath = AppDomain.CurrentDomain.BaseDirectory.ToString();
                string strExePath = strDirPath  + "\\OSRA\\"+ "osra.bat";

                if (System.IO.File.Exists(strDirPath + strInputFileName))
                {
                    System.IO.File.Delete(strDirPath + strInputFileName);
                }

                Bitmap bt = new Bitmap(chemImg);
                bt.Save(strDirPath + strInputFileName); 
                            
                //ProcessStartInfo class
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.CreateNoWindow = true;
                startInfo.UseShellExecute = false;
                startInfo.RedirectStandardError = true;
                startInfo.RedirectStandardOutput = true;
                startInfo.FileName = @"" + strExePath + "";
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                //startInfo.Arguments = @"-f sdf -w """ + strDirPath + strOutputFileName + @""" """ + strDirPath + strInputFileName + @"";
                startInfo.Arguments = @"-f sdf """ + @"" + strDirPath + strInputFileName + @"";
                
                string strErrMsg = "";
                string strOutputMol = "";
                try 
                {
                    using (Process exeProcess = Process.Start(startInfo))
                    {
                        strErrMsg = exeProcess.StandardError.ReadToEnd();
                        strOutputMol = exeProcess.StandardOutput.ReadToEnd();
                        exeProcess.WaitForExit();
                    }
                }
                catch (Exception ex)
                {
                    ErrorHandling_NTS.WriteErrorLog(ex.ToString());
                }
                if (strErrMsg.Trim() == "")
                {
                    #region Code Commented
                    //StreamReader sReader = new StreamReader(strDirPath + strOutputFileName);
                    //string newMolfileString;
                    //newMolfileString = sReader.ReadToEnd();
                    //sReader.Close();
                    //sReader.Dispose(); 
                    #endregion

                    string strStandMol = strOutputMol; //ChemistryOperations.GetStandardizedMolecule(strOutputMol, out blIsChiral);
                    
                    if (strStandMol != "")
                    {
                        strMolString = strStandMol;
                        molstring_out = strMolString;
                        errmessage_out = "";
                        ischiral_out = blIsChiral;
                        blStatus = true;
                        return blStatus;
                    }
                    else
                    {
                        strErrMessage = strErrMsg;
                        molstring_out = "";
                        ischiral_out = blIsChiral;
                        errmessage_out = strErrMessage;
                        blStatus = false;
                        return blStatus;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
            molstring_out = "";
            ischiral_out = blIsChiral;
            errmessage_out = strErrMessage;
            return blStatus;
        }

    }
}
