
#region Import Assemblies

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using chemaxon.struc;
using chemaxon.util;
using NameToStructureApplication.Classes;

#endregion

namespace NameToStructureApplication.UserControls
{
    public partial class ucRGroupEnum : UserControl
    {
        #region Constructor

        public ucRGroupEnum()
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

        #endregion

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
                throw ex;
            }
        }      
        
        DataTable dtRgrpEnum = null;

        private DataTable ConvertTextAndAddToTable(string _convText,string _identifier,string _rgroups)
        {
            try
            {
                if (_convText != "")
                {
                    DataTable dtEnumData = null;// dtRgrpEnum;

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
                                            dtRow[i] = strValArr[i];
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

        private void btnAddToTable_Click(object sender, EventArgs e)
        {
            try
            {
                if (rtxtOCRData.Text.Trim() != "")
                {
                    //Convert Text Data to Data Table
                    dtRgrpEnum = ConvertTextAndAddToTable(rtxtOCRData.Text, txtIdentifier.Text.Trim(), txtRGroups.Text.Trim());
                    dtGridTable.DataSource = dtRgrpEnum;

                    //DataTable dtSmiles = Enumeration.RgroupEnum.ConvertChemicalNameToSMILES_JChem(dtRgrpEnum);
                    //dtGridSmiles.DataSource = dtSmiles;

                    DataTable dtSmiles = Enumeration.RgroupEnum.ConvertChemicalNameToSMILES_ChemDraw(dtRgrpEnum);
                    dtGridSmiles.DataSource = dtSmiles;

                    SMILESDataTbl = dtSmiles;

                    tbCntrl_Data.TabPages[1].Show();
                    tbCntrl_Data.SelectedIndex = 1;
                }
                else
                {
                    MessageBox.Show("No data found");
                }

                #region Code commented
                ////Generate R-Group Enumeration Results
                //DataTable dtEnumData = Enumeration.RgroupEnum.GetRGroupEnumerationResults(dtSmiles, chemRenditor.MolfileString);

                //if (dtEnumData != null)
                //{
                //    if (dtEnumData.Rows.Count > 0)
                //    {
                //        tbCntrl_Main.TabPages[1].Show();
                //        tbCntrl_Main.SelectedIndex = 1;

                //        EnumResultsTbl = dtEnumData;

                //        numGoToRec.Minimum = 0;
                //        numGoToRec.Value = 0;
                //        numGoToRec.Maximum = 0;

                //        numGoToRec.Minimum = 1;
                //        numGoToRec.Maximum = dtEnumData.Rows.Count;
                //        numGoToRec.Value = 1;

                //        MaxRecCount = dtEnumData.Rows.Count;
                //    }
                //    else
                //    {
                //        MessageBox.Show("No Enumeration results");
                //    }
                //}
                //else
                //{
                //    MessageBox.Show("No Enumeration results");
                //} 
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
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
                if (EnumResultsTbl != null)
                {
                    if (EnumResultsTbl.Rows.Count > 0 && (recindex < EnumResultsTbl.Rows.Count))
                    {
                        chemRenditor_Results.MolfileString = EnumResultsTbl.Rows[recindex]["structure"].ToString();
                                                
                        txtMolFileNo.Text = (recindex + 1).ToString();

                        blStatus = true;
                        return blStatus;
                    }
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
            return blStatus;
        }

        private void chemRenditor_Results_StructureChanged(object sender, EventArgs e)
        {
            try
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
            }
            catch (Exception ex)
            {
                throw ex;
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

        private void rtxtOCRData_Click(object sender, EventArgs e)
        {
            try
            {
                ConvertTextImageToText();
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void btnRunEnum_Click(object sender, EventArgs e)
        {
            try
            {
                string strErrMsg_out = "";
                if (ValidateUserInputs(out strErrMsg_out))
                {
                    Cursor = Cursors.WaitCursor;

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
                                    blValStatus = true;
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

        private void ucRGroupEnum_Load(object sender, EventArgs e)
        {
            try
            {
                pnlEnumResults.Enabled = false;
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void brnBrowseFile_Click(object sender, EventArgs e)
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
                        pdfDocBrow.LoadFile(strFileName);
                        pdfDocBrow.Visible = true;

                    }
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }
        
        private void InsertStructureDetailsInDB()
        {
            try
            {
                if (EnumResultsTbl != null)
                {
                    if (EnumResultsTbl.Rows.Count > 0)
                    {
                        for (int i = 0; i < EnumResultsTbl.Rows.Count; i++)
                        {
                            string strTanNumber = txtTANNo.Text.Trim();

                            string strMolString = EnumResultsTbl.Rows[i]["structure"].ToString();
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

                            int userID = Generic.Generic_PepsiLite.UserID;

                            bool blVerified = false;

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

                                int tanDtl_Id_out = 0;

                                if (!PepsiLiteDataAccess.DataOperations.CheckForDuplicateStructure(strInchiKey, strTanNumber, tanDtl_Id_out))
                                {
                                    if (PepsiLiteDataAccess.DataOperations.InsertTanDetails(strTanNumber, strMolString, strMolFormula, dblMolWeight, strIUPACName, intPageNo,
                                                                                            strPageLabel, strExampleNo, strTableNo, strEnName, strInchiKey, DateTime.Now, userID,Generic.Generic_PepsiLite.UserRoleID,"", out tanDtl_Id_out))
                                    {

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
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void btnADD_Click(object sender, EventArgs e)
        {

        }            
    }
}
