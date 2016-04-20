
#region Imported DLLS

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PepsiLiteUpdates;
using System.Diagnostics;
using System.IO;
using System.Configuration;
using Microsoft.Win32;
using System.Collections;
using NLog.Targets;
using NLog.Targets.Wrappers;
using NLog;
using Npgsql;
using System.Security.Principal;
using System.Security.AccessControl;
using NameToStructureApplication;

#endregion

namespace PepsiLiteUpdates
{
    /// <summary>
    /// Updates form 
    /// </summary>
    public partial class frmupdates : Form
    {
        #region Contructor
        public frmupdates()
        {
            InitializeComponent();
        } 
        #endregion

        #region Public Variables
        private bool _isdownloaded = false;

        public bool isdownloaded
        {
            get { return _isdownloaded; }
            set { _isdownloaded = value; }
        }

        private Hashtable _htfilestobeupdate = null;
        public Hashtable HtFilestoupdates
        {
            get { return _htfilestobeupdate; }
            set { _htfilestobeupdate = value; }
        }
        private Hashtable _htFilesDone = null;
        public Hashtable HtFilesDownloaded
        {
            get { return _htFilesDone; }
            set { _htFilesDone = value; }
        }
        private string[] _strdllnames = null;
        public string[] StrDllNames
        {
            get { return _strdllnames; }
            set { _strdllnames = value; }
        }
        private DataSet _dsAdoptBuild = null;
        public DataSet dsAdoptBuild
        {
            get { return _dsAdoptBuild; }
            set { _dsAdoptBuild = value; }
        }
        BackgroundWorker bgworker1 = new BackgroundWorker();
        string strADOptVersion = "4.0.0.";
        #endregion

        #region Events
       
        /// <summary>
        /// Load Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void frmupdates_Load(object sender, EventArgs e)
        {
            RunUpdates(); //Checking for updates
        } 
       
        #endregion

        #region Methods

        /// <summary>
        /// Run Updates In Background Process
        /// </summary>
        public void RunUpdates()
        {
            //Create a pscp key in registry if not
            CreatePuttyKey(System.Configuration.ConfigurationSettings.AppSettings["PuttyKeyPath"].ToString());
            CheckForIllegalCrossThreadCalls = false;
            this.Visible = true;
            this.Cursor = Cursors.WaitCursor;

            #region Code

            this.Refresh();
            this.label1.Text = "PEPSILiTE found new updates...";
            this.label1.Refresh();
            
            Hashtable htdownloadedfiles = new Hashtable();
            try
            {
                if (HtFilestoupdates != null)
                {
                    if (HtFilestoupdates.Count > 0)
                    {
                        IDictionaryEnumerator myEnumerator = HtFilestoupdates.GetEnumerator();

                        string strout = null;
                        while (myEnumerator.MoveNext())
                        {

                            if (CallSCP(myEnumerator.Key.ToString(), "", myEnumerator.Value.ToString(), out strout))
                            {
                                if (htdownloadedfiles.ContainsKey(myEnumerator.Key) == false)
                                {
                                    htdownloadedfiles.Add(myEnumerator.Key.ToString(), "Y");
                                }
                                else
                                {
                                    htdownloadedfiles.Remove(myEnumerator.Key);
                                    htdownloadedfiles.Add(myEnumerator.Key.ToString(), "Y");
                                }
                            }
                            else
                            {
                                if (htdownloadedfiles.ContainsKey(myEnumerator.Key) == false)
                                {
                                    htdownloadedfiles.Add(myEnumerator.Key.ToString(), "N");
                                }
                                else
                                {
                                    htdownloadedfiles.Remove(myEnumerator.Key);
                                    htdownloadedfiles.Add(myEnumerator.Key.ToString(), "N");
                                }
                            }
                        }
                    }
                    HtFilesDownloaded = htdownloadedfiles;
                }
            }
            catch (Exception ex)
            {
                WriteLog("Error At frmUpdates Load" + ex.ToString());
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            #endregion
        }

        /// <summary>
        /// Get File Names to be updated
        /// </summary>
        /// <returns></returns>
        public Hashtable GetFileNamestobeUpdated()
        {      
            string[] strdlls = null;
            DataSet dsdllnames = new DataSet();
            dsdllnames = GetDllNames();
            dsAdoptBuild = GetPepsiLiteBuildDllsversions();
            strdlls = GetDllNamesFromds(dsdllnames);
            if (strdlls != null)
            {
                StrDllNames = strdlls;
            }
            Hashtable htFiletobeupdate = new Hashtable();

            if (strdlls != null)
            {
                for (int i = 0; i < strdlls.Length; i++)
                {
                    string stroutfilepath = "";
                    if (CheckCurrentDLLMinorversion(strdlls[i]) < GetNewDLLMinorVersion(strdlls[i], out stroutfilepath))
                    {
                        htFiletobeupdate.Add(strdlls[i], stroutfilepath);
                        stroutfilepath = "";
                    }
                    else if (CheckCurrentDLLMinorversion(strdlls[i]) > GetNewDLLMinorVersion(strdlls[i], out stroutfilepath))
                    {
                        htFiletobeupdate.Add(strdlls[i], stroutfilepath);
                        stroutfilepath = "";
                    }
                }
            }
            return htFiletobeupdate;           
         
        }
        
        /// <summary>
        /// Get Dll Names from DataSet
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public string[] GetDllNamesFromds(DataSet ds)
        {
            string[] strdlls = null;
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    strdlls = new string[ds.Tables[0].Rows.Count];

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        strdlls[i] = ds.Tables[0].Rows[i]["dll_name"].ToString();
                    }

                    return strdlls;
                }
            }
            return null;
        }

        /// <summary>
        /// Create PSCP key in Registry
        /// </summary>
        /// <param name="baseKey"></param>
        public void CreatePuttyKey(string baseKey)
        {
            RegistryKey key;
            try
            {
                #region registry key updates

                key = Registry.CurrentUser.OpenSubKey(baseKey, true);
                string strsettings = System.Configuration.ConfigurationSettings.AppSettings["PSCPSettings"];

                string strPuttyKeypath = System.Configuration.ConfigurationSettings.AppSettings["PuttyKeyPath"];
                string strPuttyKey = System.Configuration.ConfigurationSettings.AppSettings["PuttyKey"];
                string strKeyValue = System.Configuration.ConfigurationSettings.AppSettings["KeyValue"];
                
                WriteLog("Start writing pscp cache key in registry");
                key = Registry.CurrentUser.CreateSubKey(strPuttyKeypath);
                //GrantAllAccessPermission(strPuttyKey);
                object objtest = (Object)strKeyValue;

                if (key.GetValue(strPuttyKey) == null)
                {
                    key.SetValue(strPuttyKey, objtest);  //Installer Changes //wyeth

                    WriteLog("End writing pscp cache key in registry");
                }
                else if (key.GetValue(strPuttyKey).ToString() != strKeyValue)
                {
                    key.SetValue(strPuttyKey, objtest);  //Installer Changes //wyeth
                }

                #endregion

            }
            catch (Exception e)
            {
                MessageBox.Show("Creating Registry Key for PUTTY Problem");
            }
        }

        /// <summary>
        /// Grant All Access Permission to user
        /// </summary>
        /// <param name="key"></param>
        protected void GrantAllAccessPermission(String key)
        {
            try
            {
                SecurityIdentifier sid = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
                NTAccount account = sid.Translate(typeof(NTAccount)) as NTAccount;

                // Get ACL from Windows 
                using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(key))
                {

                    RegistrySecurity rs = new RegistrySecurity();

                    // Creating registry access rule for 'Everyone' NT account 
                    RegistryAccessRule rar = new RegistryAccessRule(
                        account.ToString(),
                        RegistryRights.FullControl,
                        InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                        PropagationFlags.None,
                        AccessControlType.Allow);

                    rs.AddAccessRule(rar);
                    rk.SetAccessControl(rs);
                }

            }
            catch (System.Security.SecurityException ex)
            {
                //throw new InstallException(
                //    String.Format("An exception in GrantAllAccessPermission, security exception! {0}", key),
                //    ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                //throw new InstallException(
                //    String.Format("An exception in GrantAllAccessPermission, access denied! {0}", key),
                //    ex);
            }
        }

        /// <summary>
        /// Call ADOPT Main Form
        /// </summary>
        /// <returns></returns>
        public Form callPepsiLite()
        {
            NameToStructureApplication.frmMain_PepsiLite objMain = null;   
            try
            {
                objMain = new NameToStructureApplication.frmMain_PepsiLite();
                this.Close();
                return objMain;
            }
            catch (Exception ex)
            {
              PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());        
            }
            return objMain;
        }
        
        /// <summary>
        /// Check Current DLL Minor Revision from installer folder
        /// </summary>
        /// <param name="strfilename"></param>
        /// <returns></returns>
        public int CheckCurrentDLLMinorversion(string strfilename)
        {  

            string strapplicationpath = System.Windows.Forms.Application.StartupPath.ToString();
            string FilePath = "";
            FilePath = strapplicationpath + "\\" + "PEPSILITE";// "CAS";

            string strdllversion = fileread(FilePath, strfilename);
            string[] strnameanddllversion = null;
            //Trace.WriteLine("strdllversion" + strdllversion);
            if (strdllversion != null)
            {
                if (strdllversion.Contains("#"))
                {
                    strnameanddllversion = strdllversion.Split('#');
                }
            }

            string[] strversions = null;
            try
            {
                if (strnameanddllversion != null && strnameanddllversion.Length > 0)
                {
                    if (strnameanddllversion[1].Contains("."))
                    {
                        strversions = strnameanddllversion[1].Split('.');
                        if (strversions.Length > 0)
                        {
                            return Convert.ToInt32(strversions[3]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLog("Error at frmupdates:CheckCurrentDLLMinorversion" + ex.ToString());
            }
            return 0;     

        }
        
        /// <summary>
        /// parsing File 
        /// </summary>
        /// <param name="strpath"></param>
        /// <param name="strdllname"></param>
        /// <returns></returns>
        public string fileread(string strpath, string strdllname)
        {
            StreamReader sr = null;
            try
            {
                if (System.IO.File.Exists(strpath))
                {
                    sr = new StreamReader(strpath);
                    string strtext = "";

                    while (!sr.EndOfStream)
                    {
                        strtext = sr.ReadLine();
                        if (strtext.StartsWith(strdllname))
                        {
                            return strtext;
                        }
                    }
                    sr.Close();
                    sr.Dispose();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                WriteLog("Error at frmupdates: fileread" + ex.ToString());
                sr.Close();
                sr.Dispose();
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                    sr.Dispose();
                }
            }
            return "";
        }

        /// <summary>
        /// Update file contents, ADOPTDLL configuration file
        /// </summary>
        /// <param name="strpath"></param>
        /// <param name="write"></param>
        public void fileupdate(string strpath, string write)
        {
            StreamWriter sr = null;
            try
            {
                if (System.IO.File.Exists(strpath))
                {
                    sr = new StreamWriter(strpath);
                    string strtext = "";

                    sr.Write(write);
                    sr.Close();
                    sr.Dispose();
                }
            }
            catch (Exception ex)
            {
                WriteLog("Error at frmupdates: fileupdate" + ex.ToString());
                sr.Close();
                sr.Dispose();
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                    sr.Dispose();
                }
            }
        }

        /// <summary>
        /// Get DLL Minor Revision from dll configuration file
        /// </summary>
        /// <param name="strfilename"></param>
        /// <param name="stroutfilepath"></param>
        /// <returns></returns>
        public int GetNewDLLMinorVersion(string strfilename, out string stroutfilepath)
        {
            return Convert.ToInt32(GetProductDetails_new(strfilename, out stroutfilepath));
        }

        /// <summary>
        /// Check Dlls 
        /// </summary>
        /// <param name="strfilename"></param>
        public void CheckProduct(string strfilename)
        {
            string stroutpath = "";
            if (CheckCurrentDLLMinorversion(strfilename) < GetNewDLLMinorVersion(strfilename, out stroutpath))
            {
                //GetNew Dll from ddd
                #region MyRegion

                string strout = "";
                string FilePath = null;
                string strapplicationpath = System.Windows.Forms.Application.StartupPath.ToString();
                if (strfilename.ToUpper() == "PEPSILITE")
                {
                    FilePath = strapplicationpath + "\\" + "PEPSILITE";//"CAS";
                }

                if (CallSCP(strfilename, stroutpath, "", out strout))
                {
                    string stroutfilepath = "";
                    fileupdate(FilePath, strADOptVersion + GetNewDLLMinorVersion(strfilename, out stroutfilepath) + " ");
                }

                #endregion
            }
        }

        /// <summary>
        /// Retrieve dlls from specified location using pscp.
        /// </summary>
        /// <param name="strfinalname"></param>
        /// <param name="strsplitfilename"></param>
        /// <param name="strdirpath"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool CallSCP(string strfinalname, string strsplitfilename, string strdirpath, out string error)
        {
            error = "";
            try
            {
                #region callscp

                string strfilename = "";
                if (strfinalname.Contains(".") == false)
                {
                    strfilename = strfinalname + ".dll";
                }
                else
                {
                    strfilename = strfinalname;
                }
                label2.Text = "Updating " + strfinalname + "....";

                label2.Refresh();

                string strsettings = System.Configuration.ConfigurationSettings.AppSettings["PSCPSettings"];
                string serverusernameandpwd = "";
                string serverpwd = "";

                //string _pscpusername = EncriptDecript.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["pscpusername"], "Pas5pr@se", "s@1tValue", "SHA1", 2, "@1B2c3D4e5F6g7H8", 256);
                //string _pscpservername = EncriptDecript.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["pscpservername"], "Pas5pr@se", "s@1tValue", "SHA1", 2, "@1B2c3D4e5F6g7H8", 256);
                string _pscpusername = System.Configuration.ConfigurationSettings.AppSettings["pscpusername"].ToString();
                string _pscpservername = System.Configuration.ConfigurationSettings.AppSettings["pscpservername"].ToString();

                //serverpwd = EncriptDecript.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["pscppassword"], "Pas5pr@se", "s@1tValue", "SHA1", 2, "@1B2c3D4e5F6g7H8", 256);
                serverpwd = System.Configuration.ConfigurationSettings.AppSettings["pscppassword"].ToString();

                serverusernameandpwd = _pscpusername + "@" + _pscpservername + ":" + strdirpath;


                string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase.ToString();
                string filename = "\"" + path + "pscp.exe\"";
                string sdFilename = "\"" + strdirpath + "\\" + strsplitfilename + "\"";


                string strFinalpathfile = "\"" + serverusernameandpwd + strfinalname + "\"";
                string strapplicationpath = System.Windows.Forms.Application.StartupPath.ToString();
                string FilePath = strapplicationpath + "\\" + strfilename;

                string arg = " -scp -pw " + serverpwd + "  " + serverusernameandpwd + "" + strfilename + "  " + "\"" + strapplicationpath + "\"" + "";

                if (startProcess(path, filename, arg, out error))
                {
                    return true;
                }
                else
                {
                    return false;
                }

                #endregion
            }
            catch (Exception ex)
            {
                WriteLog("Error at frmupdates: CallSCP" + ex.ToString());
            }
            finally
            {
                label2.Text = "";
            }
            return false;
        }

        /// <summary>
        /// Start Downloading files in backgorund
        /// </summary>
        /// <param name="Path"></param> -scp -pw gvkbio123  root@172.21.2.17:/root/CAS-Narrative-Tool/16034538T.pdf  "E:\CAS\CAS-Narrative\CASUpdates\bin\Debug"
        /// <param name="fileName"></param>
        /// <param name="arg"></param>
        /// <param name="strconerror"></param>
        /// <returns></returns>
        public bool startProcess(string Path, string fileName, string arg, out string strconerror)
        {
            Process install = new Process();
            string strstart = "";
            string endtime = "";
            string strOutput = "";
            string strError = "";
            strconerror = "";

            #region Start Process

            try
            {
                install.EnableRaisingEvents = true;
                install.StartInfo.WorkingDirectory = Path;
                install.StartInfo.FileName = fileName;
                install.StartInfo.Arguments = arg;
                install.StartInfo.RedirectStandardOutput = true;
                install.StartInfo.CreateNoWindow = true;
                install.StartInfo.RedirectStandardError = true;
                install.StartInfo.UseShellExecute = false;
                strstart = DateTime.Now.ToString();
                install.Start();

                strOutput = install.StandardOutput.ReadToEnd();
                strError = install.StandardError.ReadToEnd();

                if (strError.Length > 0)
                {
                    WriteLog("Error at frmupdates: startProcess : StrError Output" + strError);
                    strconerror = strError;
                    return false;
                }

                if (install.HasExited)
                {
                    endtime = DateTime.Now.ToString();
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                WriteLog("Error at frmupdates: startProcess" + ex.ToString());
                install.Dispose();
                return false;
            }

            #endregion

        }
        //----------------------------------------------------------------------------------///
        #region Declaration
        
        string plainText = null;
        string strencript = "Pas5pr@se";
        string strdecode = "s@1tValue";
        string hashAlgorithm = "SHA1";
        int passwordIterations = 2;
        string initVector = "@1B2c3D4e5F6g7H8"; // must be 16 bytes
        int keySize = 256;

        #endregion

        /// <summary>
        /// Get Oracle Connection string
        /// </summary>
        /// <returns></returns>
        public string GetOracleConnectionString()
        {
            #region MyRegion

            //string conHostName = EncriptDecript.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["ORAHOST"].ToString(), "Pas5pr@se", "s@1tValue", "SHA1", 2, initVector, keySize);
            //string conPort = EncriptDecript.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["ORAPORTNUMBER"].ToString(), "Pas5pr@se", "s@1tValue", "SHA1", 2, initVector, keySize);
            //string conDatabase = EncriptDecript.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["ORASERVICENAME"].ToString(), "Pas5pr@se", "s@1tValue", "SHA1", 2, initVector, keySize);
            
            #endregion

            //string conHostName = System.Configuration.ConfigurationSettings.AppSettings["ORAHOST"].ToString();
            //string conPort = System.Configuration.ConfigurationSettings.AppSettings["ORAPORTNUMBER"].ToString();
            //string conDatabase = System.Configuration.ConfigurationSettings.AppSettings["ORASERVICENAME"].ToString();
            //string conUserName = EncriptDecript.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["USERNAME"].ToString(), "Pas5pr@se", "s@1tValue", "SHA1", 2, initVector, keySize);
            //string conPassword = EncriptDecript.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["PASSWORD"].ToString(), "Pas5pr@se", "s@1tValue", "SHA1", 2, initVector, keySize);
            
            //Create OracleClient Connection
            //string strCon = string.Format("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST={0})(PORT={1})))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME={2})));User Id={3};Password={4}; ",
            //       conHostName, conPort, conDatabase, conUserName, conPassword);
            
            string strCon = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"].ToString(); ;
            return strCon;
        }

        /// <summary>
        /// Get New Dll names from db
        /// </summary>
        /// <returns></returns>
        public DataSet GetDllNames()
        {
            NpgsqlConnection con = new NpgsqlConnection(GetOracleConnectionString());
            string strsql = "select dll_name,dll_version from pepsilite.pepsilite_application_dll where application_version= 2 order by dll_name";
            try
            {
                NpgsqlDataAdapter objda = new NpgsqlDataAdapter(strsql, con);
                DataSet ds = new DataSet();
                objda.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                WriteLog(ex.ToString());
                return null;
            }
            return null;
        }

        /// <summary>
        /// Get ADOPT Build DLL Versions
        /// </summary>
        /// <returns></returns>
        public DataSet GetPepsiLiteBuildDllsversions()
        {

            NpgsqlConnection con = new NpgsqlConnection(GetOracleConnectionString());
            string strsql = "select * from pepsilite.pepsilite_app_build_dll where application_version=2 ORDER BY created_date ";
            try
            {
                NpgsqlDataAdapter objda = new NpgsqlDataAdapter(strsql, con);
                DataSet ds = new DataSet();
                objda.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                WriteLog(ex.ToString());
            }
            return null;
        }

        /// <summary>
        /// Get Product Details
        /// </summary>
        /// <param name="strfilename"></param>
        /// <returns></returns>
        public int GetProductDetails(string strfilename)
        {
            string strsql = "";

            NpgsqlConnection con = new NpgsqlConnection(GetOracleConnectionString());
            if (strfilename.Contains(".") == false)
            {
                strsql = "select max(dllminorrevision) from pepsilite.pepsilite_app_build_dll where upper(dll_name)=upper('" + strfilename + ".dll" + "') and application_version=1 ORDER BY created_date";
            }
            else
            {
                strsql = "select max(dllminorrevision) from pepsilite.pepsilite_app_build_dll where upper(dll_name)=upper('" + strfilename + "') and application_version=1  ORDER BY created_date";
            }

            try
            {
                con.Open();
                object objretval = null;

                NpgsqlCommand objcmd = new NpgsqlCommand(strsql, con);
                objretval = objcmd.ExecuteScalar();
                con.Close();
                if (objretval != null)
                {
                    if (Convert.ToInt32(objretval) > 0)
                    {
                        return Convert.ToInt32(objretval);
                    }
                    else
                    {
                        return 0;
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                WriteLog(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return 0;
        }

        /// <summary>
        /// Get Product Details
        /// </summary>
        /// <param name="strfilename"></param>
        /// <param name="strfilepath"></param>
        /// <returns></returns>
        public int GetProductDetails_new(string strfilename, out string strfilepath)
        {
            Object obj = 0;
            string strsql = null;
            try
            {
                if (strfilename.Contains(".") == false)
                {
                    strsql = strfilename.ToUpper() + ".dll";
                }
                else
                {
                    strsql = strfilename.ToUpper();
                }
                if (dsAdoptBuild != null)
                {
                    if (dsAdoptBuild.Tables[0].Rows.Count > 0)
                    {
                        obj = dsAdoptBuild.Tables[0].Compute("max(dllminorrevision)", "dll_name='" + strsql + "'");
                    }
                }
                if (obj.ToString() != "")
                {
                    strfilepath = GetDllfolderPath(strsql, Convert.ToInt32(obj), dsAdoptBuild);
                    return Convert.ToInt32(obj);
                }
            }
            catch (Exception ex)
            {
                WriteLog(ex.ToString());
            }
            strfilepath = "";
            return 0;
        }
       
        /// <summary>
        /// Get DLL Folder path
        /// </summary>
        /// <param name="strfilename"></param>
        /// <param name="dllversion"></param>
        /// <param name="ds"></param>
        /// <returns></returns>
        private string GetDllfolderPath(string strfilename, int dllversion, DataSet ds)
        {
            string strdllpath = "";
            DataRow[] dr = ds.Tables[0].Select("dll_name='" + strfilename + "' and dllminorrevision=" + dllversion + "");
            if (dr.Length > 0)
            {
                return dr[0]["FOLDERPATH"].ToString();
            }
            return null;
        }

        string instMsg = ".";
        int i = 0;
        /// <summary>
        /// Trace Log
        /// </summary>
        /// <param name="exMsg"></param>
        public void WriteLog(string exMsg)
        {
            try
            {
                string traceFolder = "TRACE";
                string traceFileName = "PEPSILiTETrace.txt";
                string applPath = Environment.CurrentDirectory;
                string traceFolderPath = applPath + "\\" + traceFolder;

                if (!Directory.Exists(traceFolderPath))
                {
                    Directory.CreateDirectory(traceFolderPath);
                }

                FileTarget target = new FileTarget();

                target.Layout = "${longdate} ${logger} ${message}";
                target.FileName = "${basedir}/Trace/PEPSILiTELog.txt";
                target.KeepFileOpen = false;
                target.Encoding = "iso-8859-2";

                AsyncTargetWrapper wrapper = new AsyncTargetWrapper();
                wrapper.WrappedTarget = target;
                wrapper.QueueLimit = 5000;
                wrapper.OverflowAction = AsyncTargetWrapperOverflowAction.Discard;

                NLog.Config.SimpleConfigurator.ConfigureForTargetLogging(wrapper, NLog.LogLevel.Trace);

                Logger logger = LogManager.GetLogger("PEPSILiTE LOG");
                logger.Trace(exMsg.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 

        #endregion

    }
}