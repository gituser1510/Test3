#region Import Assemblies

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using chemaxon.util;
using chemaxon.struc;
using NameToStructureApplication.OSRA;
using System.Collections;
using NameToStructureApplication.Classes;

#endregion

namespace NameToStructureApplication.Enumeration
{
    public partial class frmRGrpEnum : Form
    {
        #region Class Constructor

        public frmRGrpEnum()
        {
            InitializeComponent();
        } 

        #endregion

        #region Property Procedures

        private DataTable _rgrouptbl = null;
        public DataTable RGroupTbl
        {
            get
            {
                return _rgrouptbl;
            }
            set
            {
                _rgrouptbl = value;
            }
        }

        private DataTable _smilesdatatbl = null;
        public DataTable SMILESDataTbl
        {
            get
            {
                return _smilesdatatbl;
            }
            set
            {
                _smilesdatatbl = value;
            }
        }

        private DataTable _enumrestbl = null;
        public DataTable EnumResultsTbl
        {
            get
            {
                return _enumrestbl;
            }
            set
            {
                _enumrestbl = value;
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

        private string _pagenumber = "0";
        public string PageNumber
        {
            get
            {
                return _pagenumber;
            }
            set
            {
                _pagenumber = value;
            }
        }

        private string _pagelabel = "00";
        public string PageLabel
        {
            get
            {
                return _pagelabel;
            }
            set
            {
                _pagelabel = value;
            }
        }

        private string _examplenumber = "00";
        public string ExampleNumber
        {
            get
            {
                return _examplenumber;
            }
            set
            {
                _examplenumber = value;
            }
        }

        private string _tablenumber = "00";
        public string TableNumber
        {
            get
            {
                return _tablenumber;
            }
            set
            {
                _tablenumber = value;
            }
        }

        #endregion

        private void frmRGrpEnum_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                pnlEnumResults.Enabled = false;
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }        

        private void btnBrowsePdf_Click(object sender, EventArgs e)
        {
            try
            {
                OpenPdfFile();
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void OpenPdfFile()
        {
            try
            {
                openFileDialog1.Filter = "PDF|*.pdf";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string strFileName = openFileDialog1.FileName;
                    if (strFileName.Trim() != "")
                    {
                        txtFileName.Text = strFileName;

                        pnlPdf.Enabled = true;

                        pdfDocBrow.IsAccessible = true;
                        try
                        {
                            pdfDocBrow.LoadFile(strFileName);
                        }
                        catch
                        {
                            pdfDocBrow.LoadFile(strFileName);
                        }
                        pdfDocBrow.Visible = true;

                    }
                }
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

        DataTable dtRgrpEnum = null;
        private void btnAddToTable_Click(object sender, EventArgs e)
        {
            try
            {
                string strErrMsg = "";

                if (ValidateUserInputs_TableLevel(out strErrMsg))
                {
                    //Convert Text Data to Data Table
                    dtRgrpEnum = ConvertTextAndAddToTable(rtxtOCRData.Text, txtIdentifier.Text.Trim(), txtRGroups.Text.Trim());
                    dtGridTable.DataSource = dtRgrpEnum;

                    DataTable dtSmiles = Enumeration.RgroupEnum.ConvertChemicalNameToSMILES_ChemDraw(dtRgrpEnum);
                    dtGridSmiles.DataSource = dtSmiles;

                    SMILESDataTbl = dtSmiles;

                    tbCntrl_Data.TabPages[1].Show();
                    tbCntrl_Data.SelectedIndex = 1;
                }
                else
                {
                    MessageBox.Show(strErrMsg, "Invalid user inputs", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private bool ValidateUserInputs_TableLevel(out string _errmsg)
        {
            bool blStatus = false;
            string strErrMsg = "";
            try
            {
                if (chemRenditor.MolfileString != null)
                {                   
                    //Validate R-Group Columns here
                    if (ValidateDrawnAndDefinedRGroups(out strErrMsg))
                    {
                        if (rtxtOCRData.Text.Trim() != "")
                        {
                            if (txtIdentifier.Text.Trim() != "")
                            {
                                if (txtRGroups.Text.Trim() != "")
                                {
                                    blStatus = true;
                                }
                                else
                                {
                                    strErrMsg = "Please specify R-Groups";
                                }
                            }
                            else
                            {
                                strErrMsg = "Please specify Identifier";
                            }
                        }
                        else
                        {
                            strErrMsg = "No data is available to convert into a table";
                        }
                    }                    
                }
                else
                {
                    strErrMsg = "Please draw R-Core";
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
            _errmsg = strErrMsg;
            return blStatus;
        }

        private DataTable ConvertTextAndAddToTable(string _convText, string _identifier, string _rgroups)
        {
            try
            {
                if (_convText != "")
                {
                    DataTable dtEnumData = null;

                    if (dtEnumData == null)
                    {
                        string strID = _identifier.Trim();
                        string[] splitter = { "," };
                        string[] strRGrpsArr = _rgroups.Trim().Split(splitter, StringSplitOptions.RemoveEmptyEntries);

                        dtEnumData = Enumeration.RgroupEnum.CreateRGroupEnumTable(strID, strRGrpsArr);
                    }

                    string[] strSplit_NLine = { "\n" };
                    string[] strValArr_Rows = _convText.Split(strSplit_NLine, StringSplitOptions.RemoveEmptyEntries);

                    if (strValArr_Rows != null)
                    {
                        if (strValArr_Rows.Length > 0)
                        {
                            for (int rindx = 0; rindx < strValArr_Rows.Length; rindx++)
                            {
                                string[] strSplitter = { "\t" };
                                string[] strValArr = strValArr_Rows[rindx].Split(strSplitter, StringSplitOptions.RemoveEmptyEntries);

                                DataRow dtRow = dtEnumData.NewRow();

                                if (strValArr != null)
                                {
                                    if (strValArr.Length > 0)
                                    {
                                        for (int i = 0; i < strValArr.Length; i++)
                                        {
                                            if (i < dtEnumData.Columns.Count)
                                            {
                                                dtRow[i] = strValArr[i];
                                            }
                                        }
                                    }
                                }
                                dtEnumData.Rows.Add(dtRow);
                            }
                        }
                    }
                    return dtEnumData;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }

        private void btnRunEnum_Click(object sender, EventArgs e)
        {
            try
            {
                string strErrMsg_out = "";
                if (ValidateUserInputs(out strErrMsg_out))
                {
                    Cursor = Cursors.WaitCursor;

                    TANNumber = txtTANNo.Text.Trim();

                    SMILESDataTbl = (DataTable)dtGridSmiles.DataSource;
                    
                    //Generate R-Group Enumeration Results
                    DataTable dtEnumData = Enumeration.RgroupEnum.GetRGroupEnumerationResults(SMILESDataTbl, chemRenditor.MolfileString);

                    if (dtEnumData != null)
                    {
                        if (dtEnumData.Rows.Count > 0)
                        {
                            pnlEnumResults.Enabled = true;

                            tbCntrl_Main.TabPages[1].Show();
                            tbCntrl_Main.SelectedIndex = 1;

                            EnumResultsTbl = dtEnumData;

                            numGoToRec.Minimum = 0;
                            numGoToRec.Value = 0;
                            numGoToRec.Maximum = 0;

                            numGoToRec.Minimum = 1;
                            numGoToRec.Maximum = dtEnumData.Rows.Count;
                            numGoToRec.Value = 1;

                            MaxRecCount = dtEnumData.Rows.Count;

                            Cursor = Cursors.Default;
                        }
                        else
                        {
                            Cursor = Cursors.Default;
                            MessageBox.Show("No Enumeration results");
                        }
                    }
                    else
                    {
                        Cursor = Cursors.Default;
                        MessageBox.Show("No Enumeration results");
                    }
                }
                else
                {
                    MessageBox.Show(strErrMsg_out, "In-valid user inputs", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private bool ValidateUserInputs(out string errmsg_out)
        {
            bool blValStatus = false;
            string strErrMsg = "";
            try
            {
                if (chemRenditor.MolfileString != null)
                {
                    if (txtIdentifier.Text.Trim() != "")
                    {
                        if (txtRGroups.Text.Trim() != "")
                        {
                            if (SMILESDataTbl != null)
                            {
                                if (SMILESDataTbl.Rows.Count > 0)
                                {
                                    //Validate Drawn R-Groups and defined R-Groups
                                    if (ValidateDrawnAndDefinedRGroups(out strErrMsg))
                                    {
                                        blValStatus = true;
                                    }                                    
                                }
                                else
                                {
                                    strErrMsg = "No Smiles Data table";
                                }
                            }
                            else
                            {
                                strErrMsg = "No Smiles Data table";
                            }
                        }
                        else
                        {
                            strErrMsg = "Please enter R-Groups";
                        }
                    }
                    else
                    {
                        strErrMsg = "Please enter Identifier";
                    }
                }
                else
                {
                    strErrMsg = "Please draw R-Core structure";
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

        private bool ValidateDrawnAndDefinedRGroups(out string _errmsg_out)
        {
            bool blStatus = true;
            string strErrMsg = "";
            try
            {
                //Get Drawn R-Groups from R-Core
                ArrayList lstRgrps_Core = GetRgroupsFromCoreMolecule(chemRenditor.MolfileString);

                //Get Defined R-Groups from Textbox
                ArrayList lstRgrps_Def = GetRGroupsFromDefinedTable(txtRGroups.Text.Trim());

                int intCntr = 0;

                if (lstRgrps_Core != null && lstRgrps_Def != null)
                {
                    if (lstRgrps_Core.Count == lstRgrps_Def.Count)
                    {
                        for (int i = 0; i < lstRgrps_Core.Count; i++)
                        {
                            if (lstRgrps_Def.Contains(lstRgrps_Core[i]))
                            {
                                intCntr++;
                            }
                            else
                            {
                                strErrMsg = "Defined and drawn R-Groups are not same";
                                blStatus = false;
                                break;
                            }
                        }
                        if (intCntr == lstRgrps_Core.Count)
                        {
                            strErrMsg = "";
                            blStatus = true;
                        }
                        else
                        {
                            strErrMsg = "Defined and drawn R-Groups are not same";
                            blStatus = false;                       
                        }
                    }
                    else
                    {
                        strErrMsg = "Please define correct R-Groups";
                        blStatus = false;
                    }
                }
                else
                {
                    strErrMsg = "Please define correct R-Groups";
                    blStatus = false;
                }
                _errmsg_out = strErrMsg;
                return blStatus;
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
            _errmsg_out = strErrMsg;
            return blStatus;
        }

        private ArrayList GetRgroupsFromCoreMolecule(string _rCoreMol)
        {
            ArrayList lstRGroups = new ArrayList();
            try
            {
                if (_rCoreMol != "")
                {
                    MolHandler mHandler = new MolHandler(_rCoreMol);
                    Molecule objMol = mHandler.getMolecule();
                    MolAtom mAtom = null;

                    int intRgrpId = 0;

                    for (int i = 0; i < objMol.getAtomCount(); i++)
                    {
                        mAtom = objMol.getAtom(i);
                        intRgrpId = mAtom.getRgroup();

                        if (intRgrpId > 0)
                        {
                            if (!lstRGroups.Contains("R" + intRgrpId))
                            {
                                lstRGroups.Add("R" + intRgrpId);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
            return lstRGroups;
        }

        private ArrayList GetRGroupsFromDefinedTable(string _defRgrps)
        {
            ArrayList lstDefRgrps = new ArrayList();
            try
            {
                if (_defRgrps.Trim() != "")
                {
                    string[] splitter = { "," };
                    string[] strValArr = _defRgrps.Trim().Split(splitter, StringSplitOptions.RemoveEmptyEntries);
                    if (strValArr != null)
                    {
                        if (strValArr.Length > 0)
                        {
                            for (int i = 0; i < strValArr.Length; i++)
                            {
                                if (!lstDefRgrps.Contains(strValArr[i]))
                                {
                                    lstDefRgrps.Add(strValArr[i]);
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
            return lstDefRgrps;
        }

        private bool InsertStructureDetailsInDB(out string _errMsg)
        {
            string strErrMsg = "";
            try
            {
                if (EnumResultsTbl != null)
                {
                    if (EnumResultsTbl.Rows.Count > 0)
                    {
                        int intPageNo = Convert.ToInt32(txtPageNo.Text.Trim());

                        string strTanNumber = txtTANNo.Text.Trim();
                        string strMolString = "";
                        string strMolFormula = "";
                        double dblMolWeight = 0.0;
                        string strIUPACName = "";
                        string strInchiKey = "";
                        string strEnName = "";
                        string strIdentifier = "";

                        string strPageLabel = txtPageLabel.Text.Trim();
                        string strExampleNo = txtExampleNo.Text.Trim();
                        string strTableNo = txtTableNo.Text.Trim();

                        int userID = Generic.Generic_PepsiLite.UserID;

                        bool blVerified = false;
                        int tanDtl_Id_out = 0;

                        int intCntr = 0;

                        for (int i = 0; i < EnumResultsTbl.Rows.Count; i++)
                        {
                            strMolString = EnumResultsTbl.Rows[i]["structure"].ToString();
                            strMolFormula = EnumResultsTbl.Rows[i]["mol_formula"].ToString();
                            Double.TryParse(EnumResultsTbl.Rows[i]["mol_weight"].ToString(), out dblMolWeight);

                            strIUPACName = EnumResultsTbl.Rows[i]["iupac_name"].ToString();                            
                            strInchiKey = EnumResultsTbl.Rows[i]["inchi_key"].ToString();
                            strIdentifier = EnumResultsTbl.Rows[i]["id"].ToString();

                            blVerified = false;

                            if (chkVerifyV2000.Checked)
                            {
                                if (!ChemistryOperations.CheckForV3000Format(strMolString))
                                {
                                    blVerified = true;
                                }
                                else
                                {                                    
                                    strErrMsg = "Molecule is in V3000 format";
                                    break;                                   
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

                                tanDtl_Id_out = 0;

                                if (strInchiKey != "")//Inchi will be null if result is from Enumeration
                                {
                                    if (!PepsiLiteDataAccess.DataOperations.CheckForDuplicateStructure(strInchiKey, strTanNumber, tanDtl_Id_out))
                                    {
                                        if (PepsiLiteDataAccess.DataOperations.InsertTanDetails(strTanNumber, strMolString, strMolFormula, dblMolWeight, strIUPACName, intPageNo,
                                                                                                strPageLabel, strExampleNo, strTableNo, strEnName, strInchiKey, DateTime.Now, userID,Generic.Generic_PepsiLite.UserRoleID,strIdentifier, out tanDtl_Id_out))
                                        {
                                            intCntr++;
                                        }
                                        else
                                        {
                                            strErrMsg = "Error in adding record to TAN";
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        strErrMsg = "Duplicate structure";
                                        break;
                                    }
                                }
                                else
                                {
                                    if (PepsiLiteDataAccess.DataOperations.InsertTanDetails(strTanNumber, strMolString, strMolFormula, dblMolWeight, strIUPACName, intPageNo,
                                                                                                    strPageLabel, strExampleNo, strTableNo, strEnName, strInchiKey, DateTime.Now, userID,Generic.Generic_PepsiLite.UserRoleID, strIdentifier, out tanDtl_Id_out))
                                    {
                                        intCntr++;
                                    }
                                    else
                                    {
                                        strErrMsg = "Error in adding record to TAN";
                                        break;
                                    }
                                }
                            }
                        }

                        if (intCntr == EnumResultsTbl.Rows.Count)
                        {
                            _errMsg = strErrMsg;
                            return true;
                        }
                        else
                        {
                            _errMsg = strErrMsg;
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
            _errMsg = strErrMsg;
            return false;
        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTANNo.Text.Trim() != "")
                {
                    if (txtPageNo.Text.Trim() != "")
                    {
                        if (Validations.IsValidTanNumber(txtTANNo.Text.Trim()))
                        {
                            Cursor = Cursors.WaitCursor;
                            string strErrMsg_out = "";

                            if (InsertStructureDetailsInDB(out strErrMsg_out))
                            {
                                Cursor = Cursors.Default;
                                MessageBox.Show("Records inserted to database successfully");
                            }
                            else
                            {
                                Cursor = Cursors.Default;                                
                                MessageBox.Show(strErrMsg_out);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Not a Valid TAN number\r\nTAN format is 12345678A");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter page number");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter TAN number");
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        int curRecIndex = 0;
        private void numGoToRec_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                ReadMoleculeFromTable(Convert.ToInt32(numGoToRec.Value - 1));
                curRecIndex = Convert.ToInt32(numGoToRec.Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ReadMoleculeFromTable(int recindex)
        {
            bool blStatus = false;
            try
            {
                if (EnumResultsTbl != null && recindex >= 0)
                {
                    if (EnumResultsTbl.Rows.Count > 0 && (recindex < EnumResultsTbl.Rows.Count))
                    {
                        if (EnumResultsTbl.Rows[recindex]["structure"].ToString() != "")
                        {
                            chemRenditor_Results.MolfileString = EnumResultsTbl.Rows[recindex]["structure"].ToString();

                            txtMolFileNo.Text = (recindex + 1).ToString();

                            txtID.Text = EnumResultsTbl.Rows[recindex][0].ToString();

                            blStatus = true;
                            return blStatus;
                        }
                        else
                        {
                            chemRenditor_Results.MolfileString = "";
                            txtIUPACName.Text = "";
                            txtMolFormula.Text = "";
                            txtMolWeight.Text = "";
                            txtID.Text = EnumResultsTbl.Rows[recindex][0].ToString();
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

        private void chemRenditor_Results_StructureChanged(object sender, EventArgs e)
        {
            try
            {
                if (chemRenditor_Results.MolfileString != null)
                {
                    chemaxon.util.MolHandler molHandler = new MolHandler(chemRenditor_Results.MolfileString);
                    Molecule molObj = molHandler.getMolecule();

                    txtMolWeight.Text = molObj.getMass().ToString();
                    txtMolFormula.Text = molObj.getFormula();

                    string strMolfile = molObj.toFormat("mol");
                    string strIUPACName = "";
                    string strErrMsg = "";
                    if (ChemistryOperations.GetIUPACNameFromStructure(strMolfile, out strIUPACName, out strErrMsg))
                    {
                        strIUPACName = Validations.GetConvertedIUPACName(strIUPACName);
                    }
                    else
                    {
                        strIUPACName = "IUPAC name not provided";
                    }
                    txtIUPACName.Text = strIUPACName;

                    if (molObj.isAbsStereo())
                    {
                        lblChiral.Visible = true;
                    }
                    else
                    {
                        lblChiral.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void rtxtOCRData_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                ConvertTextImageToText();

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        public void ConvertTextImageToText()
        {
            try
            {
                IDataObject clipData = Clipboard.GetDataObject();
                if (clipData.GetDataPresent(DataFormats.Bitmap))
                {
                    Image img = Clipboard.GetImage();

                    OCR.OCRImageToText oc = new NameToStructureApplication.OCR.OCRImageToText();
                    string strText = oc.GetOCRDataFromBMP((Bitmap)img);

                    strText = strText.Replace(" ", "\t");

                    rtxtOCRData.Text = strText;

                    Clipboard.Clear();
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void txtTANNo_TextChanged(object sender, EventArgs e)
        {
            try
            {               
                TANNumber = txtTANNo.Text.Trim();
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void txtPageNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                PageNumber = txtPageNo.Text.Trim();
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void txtPageLabel_TextChanged(object sender, EventArgs e)
        {
            try
            {
                PageLabel = txtPageLabel.Text.Trim();
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void txtExampleNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ExampleNumber = txtExampleNo.Text.Trim();
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void txtTableNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TableNumber = txtTableNo.Text.Trim();
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                object objClipData = Clipboard.GetData(DataFormats.Text);
                if (objClipData != null)
                {
                    if (dtGridSmiles.SelectedCells.Count > 0)
                    {
                        for (int i = 0; i < dtGridSmiles.SelectedCells.Count; i++)
                        {
                            dtGridSmiles.SelectedCells[i].Value = objClipData;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtGridSmiles.SelectedCells.Count > 0)
                {
                    if (dtGridSmiles.SelectedCells[0].Value != null)
                    {
                        Clipboard.SetText(dtGridSmiles.SelectedCells[0].Value.ToString(), TextDataFormat.Text);
                    }
                }
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

        private void getSmilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtGridSmiles.SelectedCells.Count == 1)
                {
                    string strCompName = dtGridSmiles.SelectedCells[0].Value.ToString();
                    string strSmiles = PepsiLiteDataAccess.DataOperations.GetDictSmilesOnCompName(strCompName);
                    if (strSmiles != "")
                    {
                        dtGridSmiles.SelectedCells[0].Value = strSmiles;
                    }
                    else
                    {
                        MessageBox.Show("No record found", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        //private void dtGridSmiles_RowValidated(object sender, DataGridViewCellEventArgs e)
        //{
        //    DataGridView gridView = sender as DataGridView;

        //    if (null != gridView)
        //    {
        //        gridView.Rows[e.RowIndex].HeaderCell.Value = e.RowIndex.ToString();
        //    }
        //}             
    }
}
