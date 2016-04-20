
#region Import Assemblies

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

#endregion

namespace NameToStructureApplication
{
    public partial class frmMain_PepsiLite : Form
    {
        #region Constructor
                
        public frmMain_PepsiLite()
        {
            InitializeComponent();           
        }

        #endregion

        #region Public Variables

        string strEnvVarName = "OE_LICENSE";
        string strEnvVarVal = AppDomain.CurrentDomain.BaseDirectory + "oe_license.txt";

        #endregion       

        private void browsePDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmCurator frmNToS = new frmCurator();
                frmNToS.MdiParent = this;
                frmNToS.Show();
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
        }

        private void frmMain_PepsiLite_Load(object sender, EventArgs e)
        {
            try
            {
                CheckAndSetEnvironVariable.SetEnvironmentVariableEx(strEnvVarName, strEnvVarVal);
                CheckAndSetEnvironVariable.SetChemaxonLicenseFilePath(AppDomain.CurrentDomain.BaseDirectory + "license.cxl");

                //Disable menu Items
                DisableMenuItems();

                //Open Login form
                loginToolStripMenuItem_Click(null, null);              
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
        }
        
        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "SDF|*.sdf|TXT|*.txt";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string strFileName = openFileDialog1.FileName;
                    if (strFileName.Trim() != "")
                    {
                        System.IO.FileInfo finfo = new System.IO.FileInfo(strFileName);
                        if (finfo.Length > 0)
                        {
                            string strFileName_TAN = System.IO.Path.GetFileNameWithoutExtension(strFileName);

                            if (Validations.IsValidTanNumber(strFileName_TAN.Trim()))
                            {
                                FormCollection frmColl = Application.OpenForms;
                                frmReviewer frmReview = null;
                                bool blFrmOpen = false;

                                foreach (Form frm in frmColl)
                                {
                                    if (frm.Name.ToUpper() == "FRMREVIEWER")
                                    {
                                        frmReview = (frmReviewer)frm;
                                        if (frmReview.FileName == strFileName)
                                        {
                                            blFrmOpen = true;
                                            frmReview.Show();
                                            frmReview.WindowState = FormWindowState.Maximized;
                                        }
                                    }
                                }
                                if (!blFrmOpen)
                                {
                                    #region Code Commented
                                    //DialogResult diares = MessageBox.Show("Do you want to check duplicate records?","Check duplicates",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                                    //if (diares == DialogResult.Yes)
                                    //{
                                    //    int intDupRCnt = 0;
                                    //    int intTotalRCnt = 0;

                                    //    intDupRCnt = ChemistryOperations.GetDuplicateRecordsCount(strFileName.Trim(), out intTotalRCnt);

                                    //    if (intDupRCnt > 0)
                                    //    {
                                    //        diares = MessageBox.Show(intDupRCnt + " duplicate records found out of " + intTotalRCnt + " record(s). \r\n Do you want to delete duplicates?", "Delete duplicates", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                    //        if (diares == DialogResult.Yes)
                                    //        {
                                    //            if (ChemistryOperations.DeleteAllDuplicateStructures(strFileName.Trim(), out intTotalRCnt, out intDupRCnt))
                                    //            {
                                    //                MessageBox.Show(intDupRCnt + " duplicate records deleted out of " + intTotalRCnt + "record(s)");                                                  
                                    //            }
                                    //        }
                                    //    }
                                    //    else
                                    //    {
                                    //        MessageBox.Show("No duplicate records found out of " + intTotalRCnt + " record(s)");                                            
                                    //    }
                                    //    frmReview = new frmReviewer();
                                    //    frmReview.FileName = strFileName.Trim();
                                    //    frmReview.TANNumber = strFileName_TAN.Trim();
                                    //    frmReview.MdiParent = this;
                                    //    frmReview.Show();
                                    //} 
                                    #endregion

                                    frmReview = new frmReviewer();
                                    frmReview.FileName = strFileName.Trim();
                                    frmReview.TANNumber = strFileName_TAN.Trim();
                                    frmReview.MdiParent = this;
                                    frmReview.Show();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Not a valid file name with TAN Number", "In valid file", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }                            
                        }
                        else
                        {
                            MessageBox.Show("Can not read empty file","Empty file",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
        }

        private void openXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FormCollection frmColl = Application.OpenForms;
                frmXMLViewer_Validation xmlView_Valid = null;
                bool blFrmOpen = false;

                foreach (Form frm in frmColl)
                {
                    if (frm.Name.ToUpper() == "FRMXMLVIEWER_VALIDATION")
                    {
                        xmlView_Valid = (frmXMLViewer_Validation)frm;

                        blFrmOpen = true;
                        xmlView_Valid.Show();
                        xmlView_Valid.WindowState = FormWindowState.Maximized;
                    }
                }
                if (!blFrmOpen)
                {
                    xmlView_Valid = new frmXMLViewer_Validation();
                    xmlView_Valid.MdiParent = this;
                    xmlView_Valid.Show();
                }
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
        }

        private void checkDuplicatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Forms.frmQryDuplicates objfrmQryDups = new Forms.frmQryDuplicates();
                objfrmQryDups.MdiParent = this;
                objfrmQryDups.Show();
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string strTanNumber = "";
                string strSrcCntrl = "";
                DataTable dtTanDetails = GetTanDetailsTableFromActiveForm(out strTanNumber, out strSrcCntrl);
                
                if (dtTanDetails != null)
                {
                    if (dtTanDetails.Rows.Count > 0)
                    {
                        if (strTanNumber.Trim() != "")
                        {
                            Forms.frmExportOpts objfrmExp = new Forms.frmExportOpts();

                            ArrayList availProplst = GetExportListOnSourceControl(strSrcCntrl);

                            objfrmExp.AvailProps = availProplst;

                            if (objfrmExp.ShowDialog() == DialogResult.OK)
                            {
                                string strFilepath = objfrmExp.FolderPath + "\\" + strTanNumber + ".sdf";
                                if (Export.PepsiLite_Export.EmportToSdFile(strFilepath, dtTanDetails, objfrmExp.SelectedProps))
                                {
                                    MessageBox.Show("Data exported to sd file successfully", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please specify TAN Number", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No data is available to export", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("No data is available to export", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }            
        }

        private ArrayList GetExportListOnSourceControl(string _srcCntrl)
        {
            ArrayList availProplst = new ArrayList();
            try
            {
                if (_srcCntrl.Trim() != "")
                {
                    if (_srcCntrl.Trim().ToUpper() == "FRMCURATOR" || _srcCntrl.Trim().ToUpper() == "FRMQRYDUPLICATES")
                    {
                        availProplst.Add("Structure");
                        availProplst.Add("Mol Weight");
                        availProplst.Add("Mol Formula");
                        availProplst.Add("IUPAC Name");
                        availProplst.Add("Page Number");
                        availProplst.Add("Page Label");
                        availProplst.Add("Example Number");
                        availProplst.Add("En Name");
                        availProplst.Add("Table Number");
                    }
                    else if (_srcCntrl.Trim().ToUpper() == "FRMRGRPENUM")
                    {
                        availProplst.Add("Structure");
                        availProplst.Add("Mol Weight");
                        availProplst.Add("Mol Formula");
                        availProplst.Add("IUPAC Name");
                        availProplst.Add("Page Number");
                        availProplst.Add("Page Label");
                        availProplst.Add("Example Number");                        
                        availProplst.Add("Table Number");
                    }
                    return availProplst;
                }
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
            return availProplst;
        }

        private void fromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "SDF|*.sdf|TXT|*.txt";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string strFilePath = openFileDialog1.FileName;
                    if (strFilePath.Trim() != "")
                    {
                        System.IO.FileInfo finfo = new System.IO.FileInfo(strFilePath);
                        if (finfo.Length > 0)
                        {
                            string strFileName_TAN = System.IO.Path.GetFileNameWithoutExtension(strFilePath);

                            string strDirPath = System.IO.Path.GetDirectoryName(strFilePath);

                            if (Validations.IsValidTanNumber(strFileName_TAN.Trim()))
                            {
                                string strXmlPath = strDirPath + "\\" + strFileName_TAN + ".xml";

                                FormCollection frmColl = Application.OpenForms;
                                frmXMLViewer xmlView = null;
                                bool blFrmOpen = false;

                                foreach (Form frm in frmColl)
                                {
                                    if (frm.Name.ToUpper() == "FRMXMLVIEWER")
                                    {
                                        xmlView = (frmXMLViewer)frm;

                                        if (xmlView.FileName == strXmlPath)
                                        {
                                            blFrmOpen = true;
                                            xmlView.Show();
                                            xmlView.WindowState = FormWindowState.Maximized;
                                        }
                                    }
                                }
                                if (!blFrmOpen)
                                {
                                    //statStripLbl_User.Text = "Generating XML, please wait...";
                                    toolSProgBar.Visible = true;

                                    if (WriteOutPutXMLFile.WriteXmlFileUsingXSD(strFilePath, strFileName_TAN, strXmlPath))
                                    {
                                        //statStripLbl_User.Text = "Validating XML...";
                                        string strXMLSchema = AppDomain.CurrentDomain.BaseDirectory + "PatentEnhancedPrioritySubstanceIndexing-2.3.xsd";// "PEPSILiteSchema.xsd";

                                        string strErr_out = "";
                                        if (Validations.ValidateXmlAgainstSchema(strXmlPath, strXMLSchema, out strErr_out))
                                        {
                                            toolSProgBar.Visible = false;

                                            xmlView = new frmXMLViewer();
                                            xmlView.FileName = strXmlPath;
                                            xmlView.MdiParent = this;
                                            xmlView.Show();
                                        }
                                        else
                                        {
                                            toolSProgBar.Visible = false;
                                            MessageBox.Show(strErr_out, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                    else
                                    {
                                        //statStripLbl_User.Text = "";
                                        toolSProgBar.Visible = false;
                                        MessageBox.Show("Error in writing Xml file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                            else
                            {
                                toolSProgBar.Visible = false;
                                MessageBox.Show("Not a valid file name with TAN Number");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Can not read empty file", "Empty file", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
        }

        private void fromDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {                
                DataTable dtTANs = PepsiLiteDataAccess.DataOperations.RetrieveTANIDS_All();
                if (dtTANs != null)
                {
                    if (dtTANs.Rows.Count > 0)
                    {
                        ArrayList lstTans = Validations.GetTANListFromTanTable(dtTANs);
                        if (lstTans != null)
                        {
                            if (lstTans.Count > 0)
                            {
                                Forms.frmSelectTAN_Xml objSelTan_Xml = new Forms.frmSelectTAN_Xml();
                                objSelTan_Xml.AvailTANs = lstTans;
                                if (objSelTan_Xml.ShowDialog() == DialogResult.OK)
                                {
                                    Cursor = Cursors.WaitCursor;

                                    DataTable dtTanDetails = null;
                                    bool blWriteStatus = false;
                                    string strXmlFilePath = "";

                                    for (int i = 0; i < objSelTan_Xml.SelectedTANs.Count; i++)
                                    {
                                        if (objSelTan_Xml.SelectedTANs.Count == 1)
                                        {
                                            dtTanDetails = PepsiLiteDataAccess.DataOperations.RetrieveTANDetails(objSelTan_Xml.SelectedTANs[i].ToString());

                                            if (dtTanDetails != null)
                                            {
                                                if (dtTanDetails.Rows.Count > 0)
                                                {
                                                    strXmlFilePath = objSelTan_Xml.FolderName + "\\" + objSelTan_Xml.SelectedTANs[i].ToString() + ".xml";

                                                    WriteOutPutXMLFile.WriteXmlFileUsingDataTable(dtTanDetails, objSelTan_Xml.SelectedTANs[i].ToString(), strXmlFilePath);

                                                    frmXMLViewer xmlView = new frmXMLViewer();
                                                    xmlView.FileName = strXmlFilePath;
                                                    xmlView.MdiParent = this;
                                                    xmlView.Show();
                                                }
                                                else
                                                {
                                                    MessageBox.Show("No data found","No Data",MessageBoxButtons.OK,MessageBoxIcon.Information);
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("No data found", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                        }
                                        else
                                        {
                                            dtTanDetails = PepsiLiteDataAccess.DataOperations.RetrieveTANDetails(objSelTan_Xml.SelectedTANs[i].ToString());

                                            strXmlFilePath = objSelTan_Xml.FolderName + "\\" + objSelTan_Xml.SelectedTANs[i].ToString() + ".xml";

                                            WriteOutPutXMLFile.WriteXmlFileUsingDataTable(dtTanDetails, objSelTan_Xml.SelectedTANs[i].ToString(), strXmlFilePath);
                                            blWriteStatus = true;
                                        }
                                    }
                                    if (blWriteStatus)
                                    {
                                        openFileDialog1.FileName = strXmlFilePath;
                                        openFileDialog1.ShowDialog();
                                    }
                                    Cursor = Cursors.Default;
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No TANs are available");
                    }
                }
                else
                {
                    MessageBox.Show("No TANs are available");
                }
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
        }

        private void rGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FormCollection frmColl = Application.OpenForms;
                Enumeration.frmRGrpEnum  objRgrpEnum = null;
                bool blFrmOpen = false;

                foreach (Form frm in frmColl)
                {
                    if (frm.Name.ToUpper() == "FRMRGRPENUM")
                    {
                        objRgrpEnum = (Enumeration.frmRGrpEnum)frm;
                        blFrmOpen = true;
                        objRgrpEnum.Show();
                        objRgrpEnum.WindowState = FormWindowState.Maximized;

                    }
                }
                if (!blFrmOpen)
                {
                    objRgrpEnum = new Enumeration.frmRGrpEnum();                   
                    objRgrpEnum.MdiParent = this;
                    objRgrpEnum.Show();
                }
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
        }

        private DataTable GetTanDetailsTableFromActiveForm(out string tan_out,out string srcCntrl_out)
        {
            DataTable dtTanDetails = null;
            string strTanNumber = "";
            string strSrcCntrl = "";
            try
            {
                frmCurator objfrmCurator = null;
                Forms.frmQryDuplicates objfrmQueryDups = null;
                Enumeration.frmRGrpEnum objfrmEnum = null;

                Form objActiveForm = this.ActiveMdiChild;

                if (objActiveForm != null)
                {
                    if (objActiveForm.Name.ToUpper() == "FRMCURATOR")
                    {
                        objfrmCurator = (frmCurator)objActiveForm;
                        dtTanDetails = objfrmCurator.TANDetailsTbl;
                        strTanNumber = objfrmCurator.TANNumber;

                        strSrcCntrl = "FRMCURATOR";
                    }
                    else if (objActiveForm.Name.ToUpper() == "FRMQRYDUPLICATES")
                    {
                        objfrmQueryDups = (Forms.frmQryDuplicates)objActiveForm;
                        dtTanDetails = objfrmQueryDups.ucCheckDuplicates1.SearchResults;
                        strTanNumber = objfrmQueryDups.ucCheckDuplicates1.TANNumber;

                        strSrcCntrl = "FRMQRYDUPLICATES";
                    }
                    else if(objActiveForm.Name.ToUpper() == "FRMRGRPENUM")
                    {                       
                        objfrmEnum = (Enumeration.frmRGrpEnum)objActiveForm;
                        dtTanDetails = objfrmEnum.EnumResultsTbl;
                        strTanNumber = objfrmEnum.TANNumber;

                        string strPageNo = objfrmEnum.PageNumber;
                        string strPageLabel = objfrmEnum.PageLabel;
                        string strExampleNo = objfrmEnum.ExampleNumber;
                        string strTableNo = objfrmEnum.TableNumber;

                        strSrcCntrl = "FRMRGRPENUM";

                        RebuildTANDetailsTable_Enum(ref dtTanDetails, strPageNo, strPageLabel, strExampleNo, strTableNo);
                    }
                    tan_out = strTanNumber;
                    srcCntrl_out = strSrcCntrl;
                    return dtTanDetails;
                }
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
            tan_out = strTanNumber;
            srcCntrl_out = strSrcCntrl;
            return dtTanDetails;
        }

        private void RebuildTANDetailsTable_Enum(ref DataTable _dtEnumdetails, string _pageno, string _pagelabel, string _exampleno, string _tableno)
        {
            try
            {
                if (_dtEnumdetails != null)
                {
                    if (_dtEnumdetails.Rows.Count > 0)
                    {
                        if (!_dtEnumdetails.Columns.Contains("page_number"))
                        {
                            _dtEnumdetails.Columns.Add("page_number", typeof(int));
                        }
                        if (!_dtEnumdetails.Columns.Contains("page_label"))
                        {
                            _dtEnumdetails.Columns.Add("page_label", typeof(string));
                        }
                        if (!_dtEnumdetails.Columns.Contains("example_number"))
                        {
                            _dtEnumdetails.Columns.Add("example_number", typeof(string));
                        }
                        if (!_dtEnumdetails.Columns.Contains("table_number"))
                        {
                            _dtEnumdetails.Columns.Add("table_number", typeof(string));
                        }

                        for (int rowindx = 0; rowindx < _dtEnumdetails.Rows.Count; rowindx++)
                        {
                            _dtEnumdetails.Rows[rowindx]["page_number"] = Convert.ToInt32(_pageno);
                            _dtEnumdetails.Rows[rowindx]["page_label"] = _pagelabel;
                            _dtEnumdetails.Rows[rowindx]["example_number"] = _exampleno;
                            _dtEnumdetails.Rows[rowindx]["table_number"] = _tableno;
                        }
                        _dtEnumdetails.AcceptChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
        }

        private void DisableMenuItems()
        {
            try
            {
                browsePDFToolStripMenuItem.Enabled = false;
                exportToolStripMenuItem.Enabled = false;
                XMLToolStripMenuItem.Enabled = false;
                queryToolStripMenuItem.Enabled = false;
                EnumtoolStripMenuItem.Enabled = false;
                setttingsToolStripMenuItem.Enabled = false;
                dictionaryToolStripMenuItem.Enabled = false;
                
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
        }

        private void EnableMenuItems(string _userrole)
        {
            try
            {
                loginToolStripMenuItem.Enabled = false;
                
                browsePDFToolStripMenuItem.Enabled = true;
                exportToolStripMenuItem.Enabled = true;

                queryToolStripMenuItem.Enabled = true;
                EnumtoolStripMenuItem.Enabled = true;

                setttingsToolStripMenuItem.Enabled = true;                

                if (_userrole.Trim().ToUpper() == "REVIEWER")
                {
                    XMLToolStripMenuItem.Enabled = true;
                    userAccountsToolStripMenuItem.Enabled = false;
                }
                else if (_userrole.Trim().ToUpper() == "ADMINISTRATOR")
                {
                    XMLToolStripMenuItem.Enabled = true;
                    userAccountsToolStripMenuItem.Enabled = true;
                    dictionaryToolStripMenuItem.Enabled = true;
                }
                else if (_userrole.Trim().ToUpper() == "CURATOR")
                {
                    XMLToolStripMenuItem.Enabled = false;
                    userAccountsToolStripMenuItem.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Forms.frmLogin objLogin = new Forms.frmLogin();
                if (objLogin.ShowDialog() != DialogResult.OK)
                {
                    if (objLogin.SubmitClick)
                    {
                        EnableMenuItems(objLogin.UserRole);

                        statStripLbl_User.Visible = true;
                        statStripLbl_User.Text = Classes.Generic_PepsiLite.UserRole + ": " + Classes.Generic_PepsiLite.UserName;
                    }

                }
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Forms.frmCreateUser objCreateUser = new NameToStructureApplication.Forms.frmCreateUser();
                objCreateUser.Show();
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Forms.frmUpdateDict objUpdateDict = new NameToStructureApplication.Forms.frmUpdateDict();
                objUpdateDict.ShowDialog();
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
        }
                
        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Forms.frmChangePwd objChangePwd = new NameToStructureApplication.Forms.frmChangePwd();
                objChangePwd.ShowDialog();
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
        }

        private void insertDictToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Forms.frmAddToDict objfrmDict = new Forms.frmAddToDict();
                objfrmDict.ShowDialog();
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
        }

        private void retrieveDictStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Forms.frmRetrieveDict objRetDict = new NameToStructureApplication.Forms.frmRetrieveDict();
                objRetDict.ShowDialog();
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
        }

        private void deleteDictToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Forms.frmDeleteDict objDeleteDict = new Forms.frmDeleteDict();
                objDeleteDict.ShowDialog();
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
        }
    }
}
