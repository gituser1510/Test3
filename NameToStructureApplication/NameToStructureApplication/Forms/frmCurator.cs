#region Import Assemblies

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;
using chemaxon.util;
using chemaxon.struc;
using System.Security.Permissions;
using NameToStructureApplication.OCR;
using NameToStructureApplication.OSRA;
using java.io;
using chemaxon.formats;
using PepsiLiteDataAccess;
using NameToStructureApplication.Generic;
using NameToStructureApplication.Classes;

#endregion

namespace NameToStructureApplication
{
    public partial class frmCurator : Form
    {
        #region Constructor

        public frmCurator()
        {
            InitializeComponent();
        }

        #endregion

        #region Property Procedures

        private string _filename = "";
        public string FileName
        {
            get
            {
                return _filename;
            }
            set
            {
                _filename = value;
            }
        }

        private DataTable  _tandetails = null;
        public DataTable TANDetailsTbl
        {
            get
            {
                return _tandetails;
            }
            set
            {
                _tandetails = value;
            }
        }        

        private string _tannumber = "";
        public string TANNumber
        {
            get
            {
                return _tannumber;
            }
            set
            {
                _tannumber = value;
            }
        }

        private int _maxreccnt = 0;
        public int MaxRecCount
        {
            get
            {
                return _maxreccnt;
            }
            set
            {
                _maxreccnt = value;
            }
        }

        #endregion

        #region Public Variables
                 
        string strEnvVarVal = AppDomain.CurrentDomain.BaseDirectory + "oe_license.txt";
        OCRImageToText ImageToText_OCR = new OCRImageToText();
        
        int curRecIndex = 0;
        //int MaxRecCnt = 0;
        
        #endregion

        #region Events

        private void frmNameToStruct_Load(object sender, EventArgs e)
        {
            try
            {
                if (TANDetailsTbl == null)
                {
                    DataTable dtTanDetails = ChemistryOperations.CreateTANDetailsTable();
                    if (dtTanDetails != null)
                    {
                        TANDetailsTbl = dtTanDetails;
                    }

                    numGoToRec.Minimum = 0;
                    numGoToRec.Maximum = 0;
                }

                //Get TAN IDs and Assign to Specify TAN textbox with Auto Complete 
                GetTANIds_AssignToTANTxtBox_AutoComplete();                

                this.WindowState = FormWindowState.Maximized;
                
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void btnGetStructure_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCompName.Text.Trim() != "")
                {
                    Cursor = Cursors.WaitCursor;

                    chemRenditor.MolfileString = "";
                    txtMolFormula.Text = "";
                    txtMolWeight.Text = "";
                    txtIUPACName.Text = "";                    

                    string strIUPACName = "";
                    string strMolFile = "";
                    string strErrMsg = "";

                    string strMolWeight = "";
                    string strMolFormula = "";
                    bool blIsChiral = false;

                    if (rbnOpenEye.Checked)
                    {
                        chemRenditor.MolfileString = "";
                        txtIUPACName.Text = "";
                        
                        if (ChemistryOperations.GetStructureFromCompoundName(txtCompName.Text.Trim(), out strMolFile, out blIsChiral, out strErrMsg))
                        {
                            chemRenditor.MolfileString = strMolFile;//Mol file 
                            
                            if (blIsChiral)
                            {
                                lblChiral.Visible = true;
                            }
                            else
                            {
                                lblChiral.Visible = false;
                            }                            
                        }
                        else
                        {
                            MessageBox.Show(strErrMsg, "Conversion Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else if (rbnChemDraw.Checked) //Get Structure using ChemDraw
                    {
                        string strMol_out = "";
                        string strErr_out = "";
                        if (GetStructureFromChemDraw(txtCompName.Text.Trim(), out strMol_out, out strErr_out))
                        {
                            chemRenditor.MolfileString = strMol_out;
                        }
                        else
                        {
                            chemRenditor.MolfileString = "";

                            txtMolWeight.Text = "";
                            txtMolFormula.Text = "";

                            txtIUPACName.Text = "";

                            MessageBox.Show(strErr_out);
                        }
                    }
                    else if (rbnChemAxon.Checked)//Get Structure using JChem 
                    {
                        string strMol_out = "";
                        string strErr_out = "";
                        if (GetStructureFromChemAxon(txtCompName.Text.Trim(), out strMol_out, out strErr_out))
                        {
                            chemRenditor.MolfileString = strMol_out;
                        }
                        else
                        {
                            chemRenditor.MolfileString = "";

                            txtMolWeight.Text = "";
                            txtMolFormula.Text = "";

                            txtIUPACName.Text = "";

                            MessageBox.Show(strErr_out);
                        }
                    }
                    else if (rbnViewAll.Checked)
                    {
                        frmChemViewOpts objfrmChemOpts = new frmChemViewOpts();

                        string strErr_out = "";
                        string strMol_out = "";
                        bool blIsChir = false;

                        if (ChemistryOperations.GetStructureFromCompoundName(txtCompName.Text.Trim(), out strMol_out, out blIsChir, out strErr_out))
                        {
                            objfrmChemOpts.OpenEyeMol = strMol_out;
                        }
                        else
                        {
                            objfrmChemOpts.Error_OpenEye = strErr_out;
                        }

                        strErr_out = "";
                        strMol_out = "";
                        if (GetStructureFromChemDraw(txtCompName.Text.Trim(), out strMol_out, out strErr_out))
                        {
                            objfrmChemOpts.ChemDrawMol = strMol_out;
                        }
                        else
                        {
                            objfrmChemOpts.Error_ChemDraw = strErr_out;
                        }

                        strErr_out = "";
                        strMol_out = "";
                        if (GetStructureFromChemAxon(txtCompName.Text.Trim(), out strMol_out, out strErr_out))
                        {
                            objfrmChemOpts.ChemAxonMol = strMol_out;
                        }
                        else
                        {
                            objfrmChemOpts.Error_ChemAxon = strErr_out;
                        }                        

                        if (objfrmChemOpts.ShowDialog() == DialogResult.OK)
                        {
                            chemRenditor.MolfileString = objfrmChemOpts.SelectedMol;
                        }
                    }

                    if (chemRenditor.MolfileString != null)
                    {
                        //if (ChemistryOperations.GetIUPACNameFromStructure(chemRenditor.MolfileString, out strIUPACName, out strErrMsg))
                        //{
                        //    if (strIUPACName != "")
                        //    {
                        //        strIUPACName = Validations.RemoveSMILESFromIUPACName(strIUPACName);//IUPAC Name

                        //        strIUPACName = Validations.GetConvertedIUPACName(strIUPACName);
                        //        if (strIUPACName == "")
                        //        {
                        //            strIUPACName = "IUPAC name not provided";
                        //        }
                        //        lblIUPACNameVal.Text = strIUPACName;

                        //        strMolWeight = ChemistryOperations.GetMoleculeWeightAndMolFormula(chemRenditor.MolfileString, out strMolFormula);

                        //        txtMolWeight.Text = strMolWeight;
                        //        txtMolFormula.Text = strMolFormula;

                        //        Cursor = Cursors.Default;
                        //    }
                        //}
                        //else
                        //{
                        //    MessageBox.Show(strErrMsg, "Conversion Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //}
                    }                    
                    Cursor = Cursors.Default;
                }
                else
                {
                    MessageBox.Show("Please enter compound name");
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
                Cursor = Cursors.Default;
            }
        }
        
        private void txtCompName_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13)
                {
                    btnGetStructure_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        #endregion

        #region Methods

        private bool ValidateUserInputs(out string errmsg_out)
        {
            bool blValStatus = false;
            string strErrMsg = "";
            try
            {
                if (chemRenditor.MolfileString != null)
                {
                    if (txtTANNo.Text.Trim() != "")
                    {
                        if (Validations.IsValidTanNumber(txtTANNo.Text.Trim()))
                        {
                            if (txtIUPACName.Text.Trim() != "")
                            {
                                if (txtPageNo.Text.Trim() != "")
                                {
                                    if (txtPageLabel.Text.Trim() != "")
                                    {
                                        if (txtExampleNo.Text.Trim() != "")
                                        {
                                            if (txtTableNo.Text.Trim() != "")
                                            {
                                                if (txten_Name.Text.Trim() != "")
                                                {
                                                    blValStatus = true;
                                                }
                                                else
                                                {
                                                    strErrMsg = "Please enter en Name";
                                                }
                                            }
                                            else
                                            {
                                                strErrMsg = "Please enter Table Number";
                                            }
                                        }
                                        else
                                        {
                                            strErrMsg = "Please enter Example Number";
                                        }
                                    }
                                    else
                                    {
                                        strErrMsg = "Please enter Page Label";
                                    }
                                }
                                else
                                {
                                    strErrMsg = "Please enter Page Number";
                                }
                            }
                            else
                            {
                                strErrMsg = "Please enter IUPAC Name";
                            }
                        }
                        else
                        {
                            strErrMsg = "Not a Valid TAN number\r\nTAN format is 12345678A";
                        }
                    }
                    else
                    {
                        strErrMsg = "Please enter TAN Number";
                    }
                }
                else
                {
                    strErrMsg = "Structure can not be null";
                }

                errmsg_out = strErrMsg;
                return blValStatus;
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
            errmsg_out = strErrMsg;
            return blValStatus;
        }

        private bool GetStructureFromCompoundName(string strCompName, out string molstring_out, out string errmessage_out)
        {
            bool blStatus = false;
            string strMolString = "";
            string strErrMessage = "";
            try
            {
                string strDirPath = AppDomain.CurrentDomain.BaseDirectory.ToString();
                string strExePath = strDirPath + "nam2mol.exe";

                string strInputFileName = "CompName.doc";
                string strOutputFileName = "CompStructure.mol";

                if (System.IO.File.Exists(strDirPath + strInputFileName))
                {
                    System.IO.File.Delete(strDirPath + strInputFileName);
                }
                System.IO.StreamWriter sWriter = new System.IO.StreamWriter(strDirPath + strInputFileName);
                sWriter.WriteLine(strCompName.Trim());
                sWriter.Close();
                sWriter.Dispose();

                if (System.IO.File.Exists(strDirPath + strOutputFileName))
                {
                    System.IO.File.Delete(strDirPath + strOutputFileName);
                }

                //ProcessStartInfo class
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.CreateNoWindow = true;
                startInfo.UseShellExecute = false;
                startInfo.RedirectStandardError = true;
                startInfo.FileName = @"" + strExePath + "";
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.Arguments = @"-in """ + strDirPath + strInputFileName + @"""  -out """ + strDirPath + strOutputFileName + @""" -depict true";

                string strErrMsg = "";

                try
                {
                    using (Process exeProcess = Process.Start(startInfo))
                    {
                        strErrMsg = exeProcess.StandardError.ReadToEnd();
                        exeProcess.WaitForExit();
                    }
                }
                catch (Exception ex)
                {
                    PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
                }
                StreamReader sReader = new StreamReader(strDirPath + strOutputFileName);
                string newMolfileString;
                newMolfileString = sReader.ReadToEnd();

                bool blChiral = false;
                string strStandMol = ChemistryOperations.GetStandardizedMolecule(newMolfileString, out blChiral);

                if (blChiral)
                {
                    lblChiral.Visible = true;
                }
                else
                {
                    lblChiral.Visible = false;
                }

                sReader.Close();
                sReader.Dispose();

                if (newMolfileString != "")
                {
                    strMolString = strStandMol;
                    molstring_out = strMolString;
                    errmessage_out = "";
                    blStatus = true;
                    return blStatus;
                }
                else
                {
                    strErrMessage = strErrMsg;
                    molstring_out = "";
                    errmessage_out = strErrMessage;
                    blStatus = false;
                    return blStatus;
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
            molstring_out = "";
            errmessage_out = strErrMessage;
            return blStatus;
        }

        private bool GetIUPACNameFromStructure(string molfilestring, out string iupacname_out, out string errmessage_out)
        {
            bool blStatus = false;
            string strIUPACName = "";
            string strErrMessage = "";
            try
            {
                string strDirPath = AppDomain.CurrentDomain.BaseDirectory.ToString();
                string strExePath = strDirPath + "mol2nam.exe";

                string strInputFileName = "MolFile.mol";
                string strOutputFileName = "MolName.txt";

                if (System.IO.File.Exists(strDirPath + strInputFileName))
                {
                    System.IO.File.Delete(strDirPath + strInputFileName);
                }
                System.IO.StreamWriter sWriter = new System.IO.StreamWriter(strDirPath + strInputFileName);
                sWriter.WriteLine(molfilestring);
                sWriter.Close();
                sWriter.Dispose();

                if (System.IO.File.Exists(strDirPath + strOutputFileName))
                {
                    System.IO.File.Delete(strDirPath + strOutputFileName);
                }

                //ProcessStartInfo class
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.CreateNoWindow = true;
                startInfo.UseShellExecute = false;
                startInfo.RedirectStandardError = true;
                startInfo.FileName = @"" + strExePath + "";
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.Arguments = @"-in """ + strDirPath + strInputFileName + @"""  -out """ + strDirPath + strOutputFileName + @""" -capitalize true";

                string strErrMsg = "";

                try
                {
                    using (Process exeProcess = Process.Start(startInfo))
                    {
                        strErrMsg = exeProcess.StandardError.ReadToEnd();
                        exeProcess.WaitForExit();
                    }
                }
                catch (Exception ex)
                {
                    PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
                }
                StreamReader sr = new StreamReader(strDirPath + strOutputFileName);
                string IUPACName = "";
                IUPACName = sr.ReadToEnd();
                sr.Close();
                sr.Dispose();

                if (IUPACName != "")
                {
                    strIUPACName = IUPACName;
                    strErrMessage = "";
                    blStatus = true;
                }
                else
                {
                    strIUPACName = "";
                    strErrMessage = strErrMsg;
                    blStatus = false;
                }

                iupacname_out = strIUPACName;
                errmessage_out = strErrMessage;
                return blStatus;

            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }

            iupacname_out = strIUPACName;
            errmessage_out = strErrMessage;
            return blStatus;
        }

        private int GetMoleculeCountFromFile(string filename)
        {
            try
            {
                string strFileText = "";

                FileStream FS = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
                StreamReader SR = new StreamReader(FS);
                strFileText = SR.ReadToEnd();

                SR.Close();
                SR.Dispose();
                FS.Close();
                FS.Dispose();

                Regex RE = new Regex("^\\$\\$\\$\\$", RegexOptions.Multiline);
                MatchCollection theMatches = RE.Matches(strFileText);
                return (theMatches.Count);
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
            return 0;
        }

        private void ClearUserInputs()
        {
            try
            {
                txtCompName.Clear();
                chemRenditor.MolfileString = "";
                txtIUPACName.Text = "";
                txtPageNo.Text = "";
                txtPageLabel.Text = "00";
                txtExampleNo.Text = "00";
                txtMolFileNo.Text = "";
                txten_Name.Text = "";
                txtMolWeight.Text = "";
                txtMolFormula.Text = "";

                lblChiral.Visible = false;

                int intMolCnt = GetMoleculeCountFromFile(txtTANNo.Text.Trim() + ".sdf");
                if (intMolCnt == 0)
                {
                    txtMolFileNo.Text = "1";
                }
                else
                {
                    txtMolFileNo.Text = (intMolCnt + 1).ToString();
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private bool AppendMolToSDFile(string filename, string molstring, string iupacname, string pageno, string pagelabel, string molfileno, string exampleno, string enname)
        {
            bool blWriteStatus = false;
            try
            {

                FileOutputStream foutStream = new FileOutputStream(filename, true);
                MolExporter molExp = new MolExporter(foutStream, "sdf");

                MolHandler molHandler = new MolHandler(molstring);
                Molecule molObj = molHandler.getMolecule();

                molObj.setProperty("Page Number", pageno);
                molObj.setProperty("Page Label", pagelabel);
                molObj.setProperty("Molfile Number", molfileno);
                molObj.setProperty("Example Number", exampleno);
                molObj.setProperty("en name", enname);
                molObj.setProperty("IUPAC Name", iupacname);
                molObj.setProperty("Page Number", pageno);

                molExp.write(molObj);

                #region Manual writing to Sdf code commented
                //sWriter = System.IO.File.AppendText(filename);

                //sWriter.Write(molstring);

                //sWriter.WriteLine(">  <Page Number>");
                //sWriter.WriteLine(pageno);

                //sWriter.WriteLine(">  <Page Label>");
                //sWriter.WriteLine(pagelabel);

                //sWriter.WriteLine(">  <Molfile Number>");
                //sWriter.WriteLine(molfileno);

                //sWriter.WriteLine(">  <Example Number>");
                //sWriter.WriteLine(exampleno);

                //sWriter.WriteLine(">  <en name>");
                //sWriter.WriteLine(enname);

                //sWriter.WriteLine(">  <IUPAC Name>");
                //sWriter.WriteLine(iupacname);

                //sWriter.WriteLine("$$$$");

                //sWriter.Close();
                //sWriter.Dispose(); 
                #endregion

                foutStream.close();
                molExp.close();

                blWriteStatus = true;
                return blWriteStatus;
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }

            return blWriteStatus;
        }

        private bool AddStructToTANDetailsTable(int tandtlsid, string molstring, string molformula, double molweight, string inchikey, string iupacname, int pageno, string pagelabel, string exampleno, string enname, string tableno)
        {
            bool blWriteStatus = false;
            try
            {
                if (TANDetailsTbl != null)
                {
                    DataRow dtRow = TANDetailsTbl.NewRow();
                    dtRow["tan_dtl_id"] = tandtlsid;
                    dtRow["structure"] = molstring;
                    dtRow["mol_weight"] = molweight;
                    dtRow["mol_formula"] = molformula;
                    dtRow["iupac_name"] = iupacname;
                    dtRow["page_number"] = pageno;
                    dtRow["page_label"] = pagelabel;
                    dtRow["example_number"] = exampleno;
                    dtRow["en_name"] = enname;
                    dtRow["table_number"] = tableno;
                    dtRow["inchi_key"] = inchikey;                                      

                    TANDetailsTbl.Rows.Add(dtRow);

                    blWriteStatus = true;
                }
                
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }

            return blWriteStatus;
        }

        private bool UpdateStructInTANDetailsTable(int recindex, string molstring, string molformula, double molweight, string inchikey, string iupacname, int pageno, string pagelabel, string exampleno,string enname,string tableno)
        {
            bool blUpdateStatus = false;
            try
            {
                if (TANDetailsTbl != null)
                {
                    if (TANDetailsTbl.Rows.Count > 0)
                    {
                        TANDetailsTbl.Rows[recindex]["structure"] = molstring;
                        TANDetailsTbl.Rows[recindex]["mol_weight"] = molweight;
                        TANDetailsTbl.Rows[recindex]["mol_formula"] = molformula;
                        TANDetailsTbl.Rows[recindex]["iupac_name"] = iupacname;
                        TANDetailsTbl.Rows[recindex]["page_number"] = pageno;
                        TANDetailsTbl.Rows[recindex]["page_label"] = pagelabel;
                        TANDetailsTbl.Rows[recindex]["example_number"] = exampleno;
                        TANDetailsTbl.Rows[recindex]["en_name"] = enname;
                        TANDetailsTbl.Rows[recindex]["table_number"] = tableno;
                        TANDetailsTbl.Rows[recindex]["inchi_key"] = inchikey;

                        TANDetailsTbl.AcceptChanges();

                        blUpdateStatus = true;
                    }
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }

            return blUpdateStatus;
        }

        private bool DeleteStructFromTANDetailsTable(int tandtlsid,int currecindex)
        {
            bool blStatus = false;
            try
            {
                if (TANDetailsTbl != null)
                {
                    if (TANDetailsTbl.Rows.Count > 0)
                    {
                        if (Convert.ToInt32(TANDetailsTbl.Rows[currecindex]["tan_dtl_id"]) == tandtlsid)
                        {
                            TANDetailsTbl.Rows[currecindex].Delete();
                            TANDetailsTbl.AcceptChanges();

                            blStatus = true;
                            return blStatus;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
            return blStatus;
        }

        #endregion

        private void brnBrowseFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenPdfOrTextFile();
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void OpenPdfOrTextFile()
        {
            try
            {
                openFileDialog1.Filter = "PDF|*.pdf|TXT|*.txt";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string strFileName = openFileDialog1.FileName;
                    txtFileName.Text = "";
                    if (strFileName.Trim() != "")
                    {                        
                        FileName = strFileName;
                        string strFileExt = Path.GetExtension(strFileName).ToUpper();

                        if (strFileExt == ".PDF")
                        {
                            string strFileName_TAN = System.IO.Path.GetFileNameWithoutExtension(FileName);                           
                            if (txtTANNo.ReadOnly && TANNumber != "")
                            {
                                if (strFileName_TAN == TANNumber)
                                {
                                    txtFileName.Text = strFileName;
                                    
                                    pnlPdf.Visible = true;
                                    pnlText.Visible = false;

                                    pdfDocBrow.IsAccessible = true;
                                    try
                                    {
                                        pdfDocBrow.LoadFile(FileName);
                                    }
                                    catch
                                    {
                                        pdfDocBrow.LoadFile(FileName);
                                    }
                                    pdfDocBrow.Visible = true;

                                    //Get the filename, if its valid TAN, then add to TAN textbox                                
                                    if (NameToStructureApplication.Validations.IsValidTanNumber(strFileName_TAN))
                                    {
                                        txtTANNo.Text = strFileName_TAN;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("TAN number and filename are different", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                txtFileName.Text = strFileName;
                                
                                pnlPdf.Visible = true;
                                pnlText.Visible = false;

                                pdfDocBrow.IsAccessible = true;
                                pdfDocBrow.LoadFile(FileName);
                                pdfDocBrow.Visible = true;
                            }
                        }
                        else if (strFileExt == ".TXT")
                        {
                            pnlPdf.Visible = false;
                            pnlText.Visible = true;

                            txtFileName.Text = strFileName;

                            System.IO.StreamReader sReader = new StreamReader(FileName);
                            richTxt_Browse.Text = sReader.ReadToEnd();

                            sReader.Close();
                            sReader.Dispose();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void chemRenditor_StructureChanged(object sender, EventArgs e)
        {
            try
            {
                if (chemRenditor.MolfileString != null)
                {
                    if (chemRenditor.MolfileString != "" && strInchi_BeforeChange != "")
                    {                 
                        chemaxon.util.MolHandler molHandler = new MolHandler(chemRenditor.MolfileString);
                        Molecule molObj = molHandler.getMolecule();

                        string strInchi_AfterChange = ChemistryOperations.GetStructureInchiKey(chemRenditor.MolfileString);
                       
                        if (strInchi_AfterChange != strInchi_BeforeChange)
                        {
                            txtMolWeight.Text = "";
                            txtMolFormula.Text = "";

                            txtMolWeight.Text = molObj.getMass().ToString();
                            txtMolFormula.Text = molObj.getFormula();

                            if (molObj.isAbsStereo())
                            {
                                lblChiral.Visible = true;
                            }
                            else
                            {
                                lblChiral.Visible = false;
                            }

                            string strMolfile = molObj.toFormat("mol");
                            string strIUPACName = "";
                            string strErrMsg = "";
                            if (ChemistryOperations.GetIUPACNameFromStructure(strMolfile, out strIUPACName, out strErrMsg))
                            {
                                //strIUPACName = Validations.RemoveSMILESFromIUPACName(strIUPACName);
                                strIUPACName = Validations.GetConvertedIUPACName(strIUPACName);
                            }
                            else
                            {
                                strIUPACName = "IUPAC name not provided";
                            }
                            txtIUPACName.Text = strIUPACName;
                        }
                    }
                    else
                    {
                        chemaxon.util.MolHandler molHandler1 = new MolHandler(chemRenditor.MolfileString);
                        Molecule molObj1 = molHandler1.getMolecule();

                        txtMolWeight.Text = "";
                        txtMolFormula.Text = "";

                        txtMolWeight.Text = molObj1.getMass().ToString();
                        txtMolFormula.Text = molObj1.getFormula();

                        if (molObj1.isAbsStereo())
                        {
                            lblChiral.Visible = true;
                        }
                        else
                        {
                            lblChiral.Visible = false;
                        }

                        string strMolfile = molObj1.toFormat("mol");
                        string strIUPACName = "";
                        string strErrMsg = "";
                        ////if (TANDetailsTbl.Rows[curRecIndex]["iupac_name"].ToString() == "")
                        ////{
                        //    if (ChemistryOperations.GetIUPACNameFromStructure(strMolfile, out strIUPACName, out strErrMsg))
                        //    {                               
                        //        strIUPACName = Validations.GetConvertedIUPACName(strIUPACName);
                        //    }
                        //    else
                        //    {
                        //        strIUPACName = "IUPAC name not provided";
                        //    }
                        ////}
                        ////else
                        ////{
                        ////    strIUPACName = TANDetailsTbl.Rows[curRecIndex]["iupac_name"].ToString();
                        ////}
                        //txtIUPACName.Text = strIUPACName;
                    }
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        string strInchi_BeforeChange = "";

        private void chemRenditor_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (chemRenditor.MolfileString != null)
                {                   
                    strInchi_BeforeChange = ChemistryOperations.GetStructureInchiKey(chemRenditor.MolfileString);
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void txtCompName_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                IDataObject clipData = Clipboard.GetDataObject();
                if (clipData.GetDataPresent(DataFormats.Text))
                {
                    txtCompName.Text = Clipboard.GetText();
                    txten_Name.Text = Clipboard.GetText();
                }
                else if (clipData.GetDataPresent(DataFormats.Bitmap))
                {
                    Image img = Clipboard.GetImage();

                    if (img != null)
                    {
                        string strText = ImageToText_OCR.GetOCRDataFromBMP((Bitmap)img);

                        txtCompName.Text = strText;
                        txten_Name.Text = strText;
                    }
                }
                Clipboard.Clear();
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void chemRenditor_Click(object sender, EventArgs e)
        {
            try
            {
                GetStructureFromImage();
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void GetStructureFromImage()
        {
            try
            {
                IDataObject clipData = Clipboard.GetDataObject();
                if (clipData.GetDataPresent(DataFormats.Bitmap))
                {
                    Cursor = Cursors.WaitCursor;

                    Image imgChemistry = Clipboard.GetImage();

                    string strMol_out = "";
                    bool blIsChiral_out = false;
                    string strErrMsg_out = "";

                    if (ImageToStructure.GetStructureFromImage(imgChemistry, out strMol_out, out blIsChiral_out, out strErrMsg_out))
                    {
                        chemRenditor.MolfileString = strMol_out;

                        chemaxon.util.MolHandler molHandler_Trgt = new MolHandler(chemRenditor.MolfileString);
                        Molecule molObj = molHandler_Trgt.getMolecule();


                        txtMolWeight.Text = molObj.getMass().ToString();
                        txtMolFormula.Text = molObj.getFormula();

                        if (molObj.isAbsStereo())
                        {
                            lblChiral.Visible = true;
                        }
                        else
                        {
                            lblChiral.Visible = false;
                        }

                        string strMolfile = molObj.toFormat("mol");
                        string strIUPACName = "";
                        string strErrMsg = "";
                        if (ChemistryOperations.GetIUPACNameFromStructure(strMolfile, out strIUPACName, out strErrMsg))
                        {
                            strIUPACName = Validations.RemoveSMILESFromIUPACName(strIUPACName);
                            strIUPACName = Validations.GetConvertedIUPACName(strIUPACName);
                        }
                        else
                        {
                            strIUPACName = "IUPAC name not provided";
                        }
                        txtIUPACName.Text = strIUPACName;

                        Cursor = Cursors.Default;
                    }
                    else
                    {
                        Cursor = Cursors.Default;
                        MessageBox.Show(strErrMsg_out);
                    }
                }
                Clipboard.Clear();
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
            Cursor = Cursors.Default;
        }

        private bool GetStructureFromChemDraw(string _compoundname, out string _molstring, out string _errmsg)
        {
            bool blStatus = false;
            string strMol = "";
            string strErrMsg = "";
            try
            {
                ChemDrawControl8.ChemDrawCtlClass objChemDraw = new ChemDrawControl8.ChemDrawCtlClass();

                objChemDraw.Objects.Clear();
                objChemDraw.Objects.set_Data("chemical/x-name", null, null, null, _compoundname);
                object objStruct = objChemDraw.get_Data("chemical/x-mdl-molfile");
                                       
                double dblMolWeight = objChemDraw.Objects.MolecularWeight;
                string strMolString = objStruct.ToString();

                if (strMolString != "" && dblMolWeight > 0)
                {
                    strMol = strMolString;
                    strErrMsg = "";
                    blStatus = true;
                }
                else
                {
                    strMol = "";
                    strErrMsg = "Unable to get structure";
                    blStatus = true;
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());

                strErrMsg = ex.Message;
                _molstring = "";
                blStatus = false;
            }
            _molstring = strMol;
            _errmsg = strErrMsg;
            return blStatus;
        }

        private bool GetStructureFromChemAxon(string _compoundname,out string _molstring, out string _errmsg)
        {
            bool blStatus = false;
            string strMol = "";
            string strErrMsg = "";
            try
            {
                MolHandler mHandler = new MolHandler(_compoundname);
                Molecule objMol = mHandler.getMolecule();
                objMol.clean(2, null);
                string strMolString = objMol.toFormat("mol");
                if (strMolString != "")
                {
                    strMol = strMolString;
                    strErrMsg = "";
                    blStatus = true;
                }
                else
                {
                    strMol = strMolString;
                    strErrMsg = "Unable to get structure";
                    blStatus = true;
                }
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                _molstring = "";           
                 blStatus = false;                
            }
            _molstring = strMol;
            _errmsg = strErrMsg;
            return blStatus;
        }
        
        private void txtCompName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txten_Name.Text = txtCompName.Text;
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {          
                if (TANDetailsTbl != null)
                {
                    if (TANDetailsTbl.Rows.Count > 0)
                    {
                        DialogResult diaRes = MessageBox.Show("Do you want to delete the record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (diaRes == DialogResult.Yes)
                        {
                            int recIndex = curRecIndex;
                            if (recIndex > 1)
                            {
                                recIndex = recIndex - 1;
                            }
                            else
                            {
                                recIndex = 0;
                            }
                            
                            if (recIndex < TANDetailsTbl.Rows.Count)
                            {
                                string strTAN = txtTANNo.Text.Trim();

                                int intTanDtlsID = Convert.ToInt32(TANDetailsTbl.Rows[recIndex]["tan_dtl_id"]);
                                int userID = Generic.Generic_PepsiLite.UserID;

                                if (DataOperations.DeleteTANDetails(intTanDtlsID, userID))
                                {
                                    if (DeleteStructFromTANDetailsTable(intTanDtlsID, recIndex))
                                    {
                                        MaxRecCount--;
                                        numGoToRec.Maximum--;
                                        ReadMoleculeFromTable(curRecIndex);

                                        MessageBox.Show("Record deleted successfully", "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Error in delete", "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Insert_UpdateRecord("UPDATE");
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            try
            {
                Insert_UpdateRecord("INSERT");
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }   

        public bool ReadMoleculeFromTable(int recindex)
        {
            bool blStatus = false;
            try
            {
                if (TANDetailsTbl != null)
                {
                    if (TANDetailsTbl.Rows.Count > 0 && (recindex < TANDetailsTbl.Rows.Count))
                    {
                        if (TANDetailsTbl.Rows[recindex]["structure"].ToString() != "")
                        {

                            chemRenditor.MolfileString = TANDetailsTbl.Rows[recindex]["structure"].ToString();

                            //if (TANDetailsTbl.Rows[recindex]["IsChiral"].ToString() == "True")
                            //{
                            //    lblChiral.Visible = true;
                            //}
                            //else
                            //{
                            //    lblChiral.Visible = false;
                            //}
                            //txtMolFormula.Text = TANDetailsTbl.Rows[recindex]["mol_formula"].ToString();
                            //txtMolWeight.Text = TANDetailsTbl.Rows[recindex]["mol_weight"].ToString();
                            //txtIUPACName.Text = TANDetailsTbl.Rows[recindex]["iupac_name"].ToString();

                            if (TANDetailsTbl.Rows[recindex]["iupac_name"].ToString() != "")
                            {
                                txtIUPACName.Text = TANDetailsTbl.Rows[recindex]["iupac_name"].ToString();
                            }
                            
                            txtPageNo.Text = TANDetailsTbl.Rows[recindex]["page_number"].ToString();
                            txtPageLabel.Text = TANDetailsTbl.Rows[recindex]["page_label"].ToString();
                            txtExampleNo.Text = TANDetailsTbl.Rows[recindex]["example_number"].ToString();
                            txten_Name.Text = TANDetailsTbl.Rows[recindex]["en_name"].ToString();
                            txtTableNo.Text = TANDetailsTbl.Rows[recindex]["table_number"].ToString();

                            txtMolFileNo.Text = (recindex + 1).ToString();

                            txtID.Text = TANDetailsTbl.Rows[recindex]["id"].ToString();

                            blStatus = true;
                            return blStatus;
                        }
                        else
                        {
                            chemRenditor.MolfileString = "";
                            txtIUPACName.Text = "";
                            txtMolFormula.Text = "";
                            txtMolWeight.Text = "";
                            txtID.Text = TANDetailsTbl.Rows[recindex]["id"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
            return blStatus;
        }

        private void Insert_UpdateRecord(string _srcControl)
        {
            try
            {
                string strErrMsg = "";
                if (ValidateUserInputs(out strErrMsg))
                {
                    string strTanNumber = txtTANNo.Text.Trim();
                    TANNumber = strTanNumber;

                    string strMolString = chemRenditor.MolfileString;
                    string strMolFormula = txtMolFormula.Text.Trim();
                    double dblMolWeight = Convert.ToDouble(txtMolWeight.Text.Trim());

                    int intPageNo = Convert.ToInt32(txtPageNo.Text.Trim());
                    string strPageLabel = txtPageLabel.Text.Trim();
                    string strMolFileNo = txtMolFileNo.Text.Trim();
                    string strExampleNo = txtExampleNo.Text.Trim();
                    string strEnName = txten_Name.Text.Trim();
                    string strIUPACName = txtIUPACName.Text.Trim();
                    string strTableNo = txtTableNo.Text.Trim();

                    string strInchiKey = ChemistryOperations.GetStructureInchiKey(strMolString);

                    string strIdentifier = "";

                    bool blVerified = false;

                    int userID = Generic.Generic_PepsiLite.UserID;

                    if (chkVerifyV2000.Checked)
                    {
                        if (!ChemistryOperations.CheckForV3000Format(chemRenditor.MolfileString))
                        {
                            blVerified = true;
                        }
                        else
                        {
                            MessageBox.Show("Molecule is in V3000 format", "V3000", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        blVerified = true;
                    }

                    if (blVerified)
                    {
                        Cursor = Cursors.WaitCursor;

                        if (strEnName == "")
                        {
                            strEnName = "no name";
                        }
                        if (strIUPACName == "")
                        {
                            strIUPACName = "IUPAC name not provided";
                        }                      

                        if (_srcControl.Trim().ToUpper() == "INSERT")
                        {
                            int tanDtl_Id_out = 0;                            

                            if (!PepsiLiteDataAccess.DataOperations.CheckForDuplicateStructure(strInchiKey, strTanNumber, tanDtl_Id_out))
                            {
                                if (PepsiLiteDataAccess.DataOperations.InsertTanDetails(strTanNumber, strMolString, strMolFormula, dblMolWeight, strIUPACName, intPageNo,
                                                                                        strPageLabel, strExampleNo, strTableNo, strEnName, strInchiKey, DateTime.Now, userID,Generic.Generic_PepsiLite.UserRoleID, strIdentifier, out tanDtl_Id_out))
                                {
                                    if (AddStructToTANDetailsTable(tanDtl_Id_out, strMolString, strMolFormula, dblMolWeight, strInchiKey, strIUPACName, intPageNo, strPageLabel, strExampleNo, strEnName, strTableNo))
                                    {
                                        MaxRecCount++;
                                        numGoToRec.Minimum = 1;
                                        numGoToRec.Maximum = TANDetailsTbl.Rows.Count;

                                        txtMolFileNo.Text = TANDetailsTbl.Rows.Count.ToString();

                                        MessageBox.Show("Added to TAN successfully", "Molecule added", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        ClearUserInputs();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Error in adding record to TAN", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Duplicate structure", "Duplicate Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else if (_srcControl.Trim().ToUpper() == "UPDATE")
                        {
                            int recIndex = curRecIndex;
                            if (recIndex > 1)
                            {
                                recIndex = recIndex - 1;
                            }
                            else
                            {
                                recIndex = 0;
                            }

                            int tanDtlID = Convert.ToInt32(TANDetailsTbl.Rows[recIndex]["tan_dtl_id"]);

                            if (!PepsiLiteDataAccess.DataOperations.CheckForDuplicateStructure(strInchiKey,strTanNumber, tanDtlID))
                            {

                                if (PepsiLiteDataAccess.DataOperations.UpdateTanDetails(strTanNumber, tanDtlID, strMolString, strMolFormula, dblMolWeight, strIUPACName, intPageNo,
                                                                                       strPageLabel, strExampleNo, strTableNo, strEnName, strInchiKey, DateTime.Now, userID))
                                {
                                    if (UpdateStructInTANDetailsTable(recIndex, strMolString, strMolFormula, dblMolWeight, strInchiKey, strIUPACName, intPageNo,
                                                                       strPageLabel, strExampleNo, strEnName, strTableNo))
                                    {
                                        MessageBox.Show("Updated record successfully", "Update Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Error in update", "Update Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Duplicate structure","Duplicate Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    Cursor = Cursors.Default;
                }
                else
                {
                    MessageBox.Show(strErrMsg, "Invalid user inputs", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void GetTANIds_AssignToTANTxtBox_AutoComplete()
        {
            try
            {
                int userID = Generic.Generic_PepsiLite.UserID;
                DataTable dtTanIDs = PepsiLiteDataAccess.DataOperations.RetrieveTANIDS(userID);
                if (dtTanIDs != null)
                {
                    if (dtTanIDs.Rows.Count > 0)
                    {
                        AutoCompleteStringCollection tancollection = new AutoCompleteStringCollection();

                        for (int i = 0; i < dtTanIDs.Rows.Count; i++)
                        {
                            if (dtTanIDs.Rows[i][0] != null)
                            {
                                tancollection.Add(dtTanIDs.Rows[i][0].ToString());
                            }
                        }
                        Generic.AutoCompleteCol.TANcollection = tancollection;

                        txtChkTAN.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        txtChkTAN.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        txtChkTAN.AutoCompleteCustomSource = tancollection;
                    }
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        public void BindTANResultsToControls(DataTable _dttandetails)
        {
            try
            {
                if (_dttandetails != null)
                {
                    if (_dttandetails.Rows.Count > 0)
                    {
                        TANDetailsTbl = _dttandetails;

                        this.Text = TANNumber;

                        curRecIndex = 0;

                        txtTANNo.Text = TANNumber;
                        txtTANNo.ReadOnly = true;

                        numGoToRec.Minimum = 0;
                        numGoToRec.Value = 0;
                        numGoToRec.Maximum = 0;

                        numGoToRec.Minimum = 1;
                        numGoToRec.Maximum = _dttandetails.Rows.Count;
                        numGoToRec.Value = 1;

                        MaxRecCount = _dttandetails.Rows.Count;
                    }
                    else
                    {
                        this.Text = TANNumber;

                        txtTANNo.Text = TANNumber;
                        txtTANNo.ReadOnly = true;
                    }
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void numGoToRec_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                ReadMoleculeFromTable(Convert.ToInt32(numGoToRec.Value - 1));
                curRecIndex = Convert.ToInt32(numGoToRec.Value);
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void btnGetRecs_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validations.IsValidTanNumber(txtChkTAN.Text.Trim()))
                {
                    txtCompName.Text = "";

                    TANNumber = txtChkTAN.Text.Trim();

                    DataTable dtTanDetails = PepsiLiteDataAccess.DataOperations.GetTANDetailsOnUserIDAndRoleID(txtChkTAN.Text.Trim(), Generic.Generic_PepsiLite.UserID, Generic.Generic_PepsiLite.UserRoleID);
                    if (dtTanDetails != null)
                    {              
                        if (dtTanDetails.Rows.Count > 0)
                        {
                            BindTANResultsToControls(dtTanDetails);
                        }
                        else
                        {
                            MessageBox.Show("No records found for this TAN","No Records",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No records found for this TAN", "No Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Not a valid TAN \r\n TAN format must be 12345678A", "Invalid TAN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            try
            {
                curRecIndex = 1;
                numGoToRec.Value = curRecIndex;
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            try
            {
                if (curRecIndex <= MaxRecCount && curRecIndex > 1)
                {
                    curRecIndex = (curRecIndex - 1);
                }

                numGoToRec.Value = curRecIndex;
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (curRecIndex < MaxRecCount)
                {
                    curRecIndex = curRecIndex + 1;
                }
                else if (curRecIndex == MaxRecCount)
                {
                    curRecIndex = MaxRecCount;
                }
                numGoToRec.Value = curRecIndex;
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            try
            {
                curRecIndex = MaxRecCount;
                numGoToRec.Value = curRecIndex;
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }              

    }
}
