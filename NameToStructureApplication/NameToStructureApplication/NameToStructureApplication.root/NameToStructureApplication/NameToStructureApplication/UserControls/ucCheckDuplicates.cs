
#region Import Assemblies

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using chemaxon.formats;
using java.io;
using chemaxon.struc;
using chemaxon.util;
using NameToStructureApplication.Classes;
using PepsiLiteDataAccess;

#endregion

namespace NameToStructureApplication.UserControls
{
    public partial class ucCheckDuplicates : UserControl
    {
        #region Class Constructor

        public ucCheckDuplicates()
        {
            InitializeComponent();
        } 

        #endregion

        #region Property Procedures

        private DataTable _srchresultstbl = null;
        public DataTable SearchResults
        {
            get
            {
                return _srchresultstbl;
            }
            set
            {
                _srchresultstbl = value;
            }
        }

        private int _userid = 5;
        public int UserID
        {
            get
            {
                return _userid;
            }
            set
            {
                _userid = value;
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

        #endregion

        int currRecIndex = 0;
        int MaxRecCnt = 0;
        int ToTalRecCnt = 0;       

        private void GetDuplicateStructures(string filename,string molfile)
        {
            try
            {
               // txtTANNo.Text = strTANNumber;
                
                int totalRecCnt = 0;
                DataTable dtDupRecs = ChemistryOperations.GetDuplicateRecords(filename, molfile, out totalRecCnt);
                if (dtDupRecs != null)
                {
                    if (dtDupRecs.Rows.Count > 1)
                    {
                        pnlDups.Enabled = true;

                        SearchResults = dtDupRecs;
                        lblRecCnt.Text = dtDupRecs.Rows.Count.ToString() + " duplicates out of  " + totalRecCnt + "  records";

                        ToTalRecCnt = totalRecCnt;

                        MaxRecCnt = dtDupRecs.Rows.Count;

                        currRecIndex = 1;

                        numGoToRec.Value = 1;
                        numGoToRec.Minimum = 1;
                        numGoToRec.Maximum = MaxRecCnt;
                        numGoToRec.Value = currRecIndex;
                    }
                    else
                    {
                        MessageBox.Show("No duplicate records found","No Duplicates",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ReadMoleculeFromTable(int recindex)
        {
            bool blStatus = false;
            try
            {
                if (SearchResults != null)
                {
                    if (SearchResults.Rows.Count > 0 && (recindex < SearchResults.Rows.Count))
                    {
                        chemRenditor_Trgt.MolfileString = SearchResults.Rows[recindex]["Structure"].ToString();

                        //if (SearchResults.Rows[recindex]["IsChiral"].ToString() == "True")
                        //{
                        //    lblChiral.Visible = true;
                        //}
                        //else
                        //{
                        //    lblChiral.Visible = false;
                        //}

                       // txtMolFormula.Text = SearchResults.Rows[recindex]["MolFormula"].ToString();
                       // txtMolWeight.Text = SearchResults.Rows[recindex]["MolWeight"].ToString();
                        txtIUPACName.Text = SearchResults.Rows[recindex]["iupac_name"].ToString();
                        txtPageNo.Text = SearchResults.Rows[recindex]["page_number"].ToString();
                        txtPageLabel.Text = SearchResults.Rows[recindex]["page_label"].ToString();
                        txtExampleNo.Text = SearchResults.Rows[recindex]["example_number"].ToString();
                        txten_Name.Text = SearchResults.Rows[recindex]["en_name"].ToString();

                        txtTableNo.Text = (recindex + 1).ToString();

                        blStatus = true;
                        return blStatus;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
            return blStatus;
        }

        private bool DeleteStructFromSearchResultTable(int tandtlsid, int currecindex)
        {
            bool blStatus = false;
            try
            {
                if (SearchResults != null)
                {
                    if (SearchResults.Rows.Count > 0)
                    {
                        if (Convert.ToInt32(SearchResults.Rows[currecindex]["tan_dtl_id"]) == tandtlsid)
                        {
                            SearchResults.Rows[currecindex].Delete();
                            SearchResults.AcceptChanges();

                            blStatus = true;
                            return blStatus;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
            return blStatus;
        }
        
        private int GetMainRecordIndex(int displayindex)
        {
            int mainIndex = 0;
            try
            {
                if (SearchResults != null)
                {
                    if (SearchResults.Rows.Count > 0)
                    {
                        mainIndex = Convert.ToInt16(SearchResults.Rows[displayindex]["tan_dtl_id"]);
                        return mainIndex;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
            return mainIndex;
        }

        private void ClearUserInputs()
        {
            try
            {
                chemRenditor_Trgt.MolfileString = "";
                txtIUPACName.Text = "";
                txtPageNo.Text = "";
                txtPageLabel.Text = "00";
                txtExampleNo.Text = "00";

                txtMolFormula.Text = "";
                txtMolWeight.Text = "";

                txtTableNo.Text = "";
                txten_Name.Text = "";

                lblRecCnt.Text = "";

            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
        }

        private bool UpdateRecordInTable(int recindex, string molstring, double molweight, string molformula, int pagenum, string pagelabel, string examplenum, string iupacname, string enname,string inchikey)
        {
            bool blStatus = false;
            try
            {
                if (SearchResults != null)
                {
                    if (recindex < SearchResults.Rows.Count)
                    {
                        SearchResults.Rows[recindex]["structure"] = molstring;
                        SearchResults.Rows[recindex]["mol_weight"] = molweight;
                        SearchResults.Rows[recindex]["mol_formula"] = molformula;
                        SearchResults.Rows[recindex]["iupac_name"] = iupacname;
                        SearchResults.Rows[recindex]["page_number"] = pagenum;
                        SearchResults.Rows[recindex]["page_label"] = pagelabel;
                        SearchResults.Rows[recindex]["example_number"] = examplenum;
                        SearchResults.Rows[recindex]["table_number"] = examplenum;
                        SearchResults.Rows[recindex]["en_name"] = enname;
                        SearchResults.Rows[recindex]["inchi_key"] = inchikey;

                        SearchResults.AcceptChanges();
                        blStatus = true;
                        return blStatus;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
            return blStatus;
        }

        private string GetSearchQuery(int _tanID)
        {
            string strSrchQry = "";
            try
            {

                strSrchQry = "select * from pepsilite.tan_details where tan_id = " + _tanID;

                //Structure
                if (chemRenditor_Qry.MolfileString != null)
                {
                    string strInchiKey = ChemistryOperations.GetStructureInchiKey(chemRenditor_Qry.MolfileString);
                    strSrchQry = strSrchQry + " and inchi_key = '" + strInchiKey + "' ";
                }
                //Mol Formula
                if (txtMolFormula_Qry.Text.Trim() != "")
                {
                    string strMolFormulaQry = GetSearchOperator(cmbMolFormula, txtMolFormula_Qry, "mol_formula");
                    strSrchQry = strSrchQry + " and " + strMolFormulaQry;
                }
                //Mol Weight
                if (txtMolWeight_Qry.Text.Trim() != "")
                {
                    string strMolWeightQry = GetSearchOperator(cmbMolWeight, txtMolWeight_Qry, "mol_weight");
                    strSrchQry = strSrchQry + " and " + strMolWeightQry;
                }
                //Page Number
                if (txtPageNum_Qry.Text.Trim() != "")
                {
                    string strPageNumQry = GetSearchOperator(cmbPageNum, txtPageNum_Qry, "page_number");
                    strSrchQry = strSrchQry + " and " + strPageNumQry;
                }
                //Page Label
                if (txtPageLabel_Qry.Text.Trim() != "")
                {
                    string strPagelabelQry = GetSearchOperator(cmbPageLabel, txtPageLabel_Qry, "page_label");
                    strSrchQry = strSrchQry + " and " + strPagelabelQry;
                }
                //Example Number
                if (txtExampleNo_Qry.Text.Trim() != "")
                {
                    string strExampleQry = GetSearchOperator(cmbExampleNo, txtExampleNo_Qry, "example_number");
                    strSrchQry = strSrchQry + " and " + strExampleQry;
                }
                //Table Number
                if (txtTableNo_Qry.Text.Trim() != "")
                {
                    string strTableNoQry = GetSearchOperator(cmbTableNo, txtTableNo_Qry, "table_number");
                    strSrchQry = strSrchQry + " and " + strTableNoQry;
                }
                //IUPAC Name
                if (txtIUPACName_Qry.Text.Trim() != "")
                {
                    string strIUPACQry = GetSearchOperator(cmbIUPACName, txtIUPACName_Qry, "iupac_name");
                    strSrchQry = strSrchQry + " and " + strIUPACQry;
                }
                //en Name
                if (txtEnName_Qry.Text.Trim() != "")
                {
                    string strEnNameQry = GetSearchOperator(cmbEnName, txtEnName_Qry, "en_name");
                    strSrchQry = strSrchQry + " and " + strEnNameQry;
                }

                return strSrchQry;

            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
            return strSrchQry;
        }

        private string GetSearchOperator(ComboBox _qryoperator, TextBox _qrytext,string _qrylabel)
        {
            string strSrchQry = "";
            try
            {
                if (_qrytext.Text.Trim() != "")
                {
                    string strCmbText = _qryoperator.SelectedItem.ToString();
                    switch (strCmbText.ToUpper())
                    {
                        case "=":
                            strSrchQry = _qrylabel + " = " + _qrytext.Text.Trim() + "";
                            break;

                        case "!=":
                            strSrchQry = _qrylabel + " != " + _qrytext.Text.Trim() + "";
                            break;

                        case ">":
                            strSrchQry = _qrylabel + " > " + _qrytext.Text.Trim() + "";
                            break;

                        case ">=":
                            strSrchQry = _qrylabel + " >= " + _qrytext.Text.Trim() + "";
                            break;

                        case "<":
                            strSrchQry = _qrylabel + " < " + _qrytext.Text.Trim() + "";
                            break;

                        case "<=":
                            strSrchQry = _qrylabel + " <= " + _qrytext.Text.Trim() + "";
                            break;

                        case "EQUAL TO":
                            strSrchQry = _qrylabel + " = '" + _qrytext.Text.Trim() + "'";
                            break;

                        case "NOT EQUAL TO":
                            strSrchQry = _qrylabel + " != '" + _qrytext.Text.Trim() + "'";
                            break;

                        case "LIKE":
                            strSrchQry = _qrylabel + " like '" + _qrytext.Text.Trim() + "%'";
                            break;

                        case "NOT LIKE":
                            strSrchQry = _qrylabel + " not like '" + _qrytext.Text.Trim() + "%'";
                            break;   
                    }
                    return strSrchQry;
                }
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
            return strSrchQry;
        }
                
        private bool ValidateUserInputs(out string errmsg_out)
        {
            bool blValStatus = false;
            string strErrMsg = "";
            try
            {
                if (chemRenditor_Trgt.MolfileString != null)
                {
                    if (txtPageNo.Text.Trim() != "")
                    {
                        blValStatus = true;
                    }
                    else
                    {
                        strErrMsg = "Please enter Page Number";
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
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
            errmsg_out = strErrMsg;
            return blValStatus;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTANNumber_Qry.Text.Trim() != "")
                {
                    if (Validations.IsValidTanNumber(txtTANNumber_Qry.Text.Trim()))
                    {
                        TANNumber = txtTANNumber_Qry.Text.Trim();

                        int intTAN_ID = PepsiLiteDataAccess.DataOperations.RetrieveTANID_ForTAN(txtTANNumber_Qry.Text.Trim());

                        string strSearchQry = GetSearchQuery(intTAN_ID);

                        int intTotalRecCnt = PepsiLiteDataAccess.DataOperations.GetRecordCount_ForTAN(intTAN_ID);

                        DataTable dtSrchRes = PepsiLiteDataAccess.DataOperations.RetrieveSearchResults(strSearchQry);

                        if (dtSrchRes != null)
                        {
                            if (dtSrchRes.Rows.Count > 0)
                            {
                                pnlDups.Enabled = true;

                                SearchResults = dtSrchRes;
                                ToTalRecCnt = intTotalRecCnt;
                                MaxRecCnt = dtSrchRes.Rows.Count;

                                lblRecCnt.Text = dtSrchRes.Rows.Count.ToString() + " records out of  " + ToTalRecCnt + "  records";
                                
                                currRecIndex = 1;
                                //ReadMoleculeFromTable(currRecIndex - 1);                                
                                numGoToRec.Minimum = 1;
                                numGoToRec.Maximum = MaxRecCnt;
                                numGoToRec.Value = 1;
                                numGoToRec.Value = currRecIndex;
                            }
                            else
                            {
                                ClearUserInputs();
                                pnlDups.Enabled = false;
                                MessageBox.Show("No records found for the search query", "No Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid TAN number","Invalid TAN",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter TAN","TAN is required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }               
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
        }
        
        private void numGoToRec_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                ReadMoleculeFromTable(Convert.ToInt32(numGoToRec.Value - 1));
                currRecIndex = Convert.ToInt32(numGoToRec.Value);
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (currRecIndex < MaxRecCnt)
                {
                    currRecIndex = currRecIndex + 1;
                }
                else if (currRecIndex == MaxRecCnt)
                {
                    currRecIndex = MaxRecCnt;
                }
                numGoToRec.Value = currRecIndex;
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            try
            {
                currRecIndex = MaxRecCnt;
                numGoToRec.Value = currRecIndex;
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            try
            {
                if (currRecIndex <= MaxRecCnt && currRecIndex > 1)
                {
                    currRecIndex = (currRecIndex - 1);
                }
                numGoToRec.Value = currRecIndex;
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            try
            {
                currRecIndex = 1;
                numGoToRec.Value = currRecIndex;
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
        }

        private void btnDelRec_Click(object sender, EventArgs e)
        {
            try
            {
                if (SearchResults != null)
                {
                    if (SearchResults.Rows.Count > 0)
                    {

                        DialogResult diaRes = MessageBox.Show("Do you want to delete the record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (diaRes == DialogResult.Yes)
                        {
                            int recIndex = currRecIndex;
                            if (recIndex > 1)
                            {
                                recIndex = recIndex - 1;
                            }
                            else
                            {
                                recIndex = 0;
                            }

                            if (recIndex < SearchResults.Rows.Count)
                            {
                                string strTAN = TANNumber;

                                int intTanDtlsID = Convert.ToInt32(SearchResults.Rows[recIndex]["tan_dtl_id"]);
                                int userID = UserID;

                                if (DataOperations.DeleteTANDetails(intTanDtlsID, userID))
                                {
                                    if (DeleteStructFromSearchResultTable(intTanDtlsID, recIndex))
                                    {
                                        if (currRecIndex > 1)
                                        {
                                            currRecIndex--;
                                            MaxRecCnt--;
                                        }
                                        else if (currRecIndex == 1 && MaxRecCnt > 1)
                                        {
                                            currRecIndex = 1;
                                            MaxRecCnt--;
                                        }
                                        else if (currRecIndex == 1 && MaxRecCnt == 1)
                                        {
                                            currRecIndex = 0;
                                            MaxRecCnt = 0;

                                            ClearUserInputs();
                                            pnlDups.Enabled = false;
                                        }

                                        if (currRecIndex > 0)
                                        {
                                            numGoToRec.Value = currRecIndex;
                                            numGoToRec.Maximum = numGoToRec.Maximum - 1;

                                            ToTalRecCnt = ToTalRecCnt - 1;
                                        }
                                        else
                                        {
                                            numGoToRec.Minimum = 0;
                                            numGoToRec.Maximum = 0;
                                            numGoToRec.Value = 0;
                                        }             
                                   
                                        //MaxRecCnt--;
                                        //numGoToRec.Maximum--;
                                        //ReadMoleculeFromTable(currRecIndex);                                      
                                        
                                        lblRecCnt.Text = MaxRecCnt + " duplicates out of " + ToTalRecCnt + " records";
                                        MessageBox.Show("Record deleted successfully", "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Error in delete", "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                #region Old Code Commented
                                //int mainRecIndx = 0;
                                //if (DelelteRecordFromTable(currRecIndex - 1, out mainRecIndx))
                                //{
                                //    if (Delete_UpdateOperations.DeleteRecordFromSDFile(FileName, mainRecIndx + 1))
                                //    {
                                //        if (currRecIndex > 1)
                                //        {
                                //            currRecIndex--;
                                //            MaxRecCnt--;
                                //        }
                                //        else if (currRecIndex == 1 && MaxRecCnt > 1)
                                //        {
                                //            currRecIndex = 1;
                                //            MaxRecCnt--;
                                //        }
                                //        else if (currRecIndex == 1 && MaxRecCnt == 1)
                                //        {
                                //            currRecIndex = 0;
                                //            MaxRecCnt = 0;

                                //            ClearUserInputs();
                                //        }

                                //        if (currRecIndex > 0)
                                //        {
                                //            numGoToRec.Value = currRecIndex;
                                //            numGoToRec.Maximum = numGoToRec.Maximum - 1;

                                //            ToTalRecCnt = ToTalRecCnt - 1;
                                //        }
                                //        else
                                //        {
                                //            numGoToRec.Minimum = 0;
                                //            numGoToRec.Maximum = 0;
                                //            numGoToRec.Value = 0;
                                //        }

                                //        lblRecCnt.Text = MaxRecCnt + " duplicates out of " + ToTalRecCnt + " records";
                                //    }
                                //    MessageBox.Show("Deleted record successfully", "Delete record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //} 
                                #endregion
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void chemRenditor_Qry_StructureChanged(object sender, EventArgs e)
        {
            try
            {
                if (chemRenditor_Qry.MolfileString != null)
                {
                    MolHandler molHandler = new MolHandler(chemRenditor_Qry.MolfileString);
                    Molecule molObj = molHandler.getMolecule();

                    bool blIsChiral = false;

                    if (molObj.isAbsStereo())
                    {
                        lblChiral_Qry.Visible = true;
                    }
                    else
                    {
                        lblChiral_Qry.Visible = false;
                    }           
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (SearchResults != null)
                {
                    if (SearchResults.Rows.Count > 0)
                    {
                        string strErrMsg = "";
                        if (ValidateUserInputs(out strErrMsg))
                        {
                            DialogResult diaRes = MessageBox.Show("Do you want to update the record?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (diaRes == DialogResult.Yes)
                            {
                                int recIndex = currRecIndex;
                                if (recIndex > 1)
                                {
                                    recIndex = recIndex - 1;
                                }
                                else
                                {
                                    recIndex = 0;
                                }
                                int tanDtlID = Convert.ToInt32(SearchResults.Rows[recIndex]["tan_dtl_id"]);

                                string strMolString = chemRenditor_Trgt.MolfileString;
                                string strInchiKey = ChemistryOperations.GetStructureInchiKey(strMolString);

                                if (!PepsiLiteDataAccess.DataOperations.CheckForDuplicateStructure(strInchiKey,TANNumber, tanDtlID))
                                {
                                    Cursor = Cursors.WaitCursor;
                                    
                                    double dblMolWeight = Convert.ToDouble(txtMolWeight.Text.Trim());
                                    string strMolFormula = txtMolFormula.Text.Trim();                                    

                                    int intPageNo = Convert.ToInt32(txtPageNo.Text.Trim());

                                    string strPageLabel = txtPageLabel.Text.Trim();
                                    if (strPageLabel == "")
                                    {
                                        strPageLabel = "00";
                                    }

                                    string strExampleNo = txtExampleNo.Text.Trim();
                                    if (strExampleNo == "")
                                    {
                                        strExampleNo = "00";
                                    }

                                    string strIUPACName = txtIUPACName.Text.Trim();
                                    string strEn_Name = txten_Name.Text.Trim();

                                    string strTableNo = txtTableNo.Text.Trim();

                                    bool blVerified = false;

                                    if (chkVerifyV2000.Checked)
                                    {
                                        if (!ChemistryOperations.CheckForV3000Format(strMolString))
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
                                        

                                        if (PepsiLiteDataAccess.DataOperations.UpdateTanDetails(TANNumber, tanDtlID, strMolString, strMolFormula, dblMolWeight, strIUPACName, intPageNo,
                                                                                               strPageLabel, strExampleNo, strTableNo, strEn_Name, strInchiKey, DateTime.Now, UserID))
                                        {
                                            if (UpdateRecordInTable(recIndex, strMolString, dblMolWeight, strMolFormula, intPageNo,
                                                                                      strPageLabel, strExampleNo, strIUPACName, strEn_Name, strInchiKey))
                                            {
                                                Cursor = Cursors.Default;
                                                MessageBox.Show("Record updated successfully", "Update Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                            else
                                            {
                                                Cursor = Cursors.Default;
                                                MessageBox.Show("Error in updating", "Update Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                        }
                                        else
                                        {
                                            Cursor = Cursors.Default;
                                            MessageBox.Show("Error in updating", "Update Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }                                    
                                }                                
                                else
                                {
                                    MessageBox.Show("Duplicate Record");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show(strErrMsg, "Invalid user inputs", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
        }

        private void chemRenditor_Trgt_StructureChanged(object sender, EventArgs e)
        {
            try
            {
                if (chemRenditor_Trgt.MolfileString != null)
                {
                    MolHandler molHandler1 = new MolHandler(chemRenditor_Trgt.MolfileString);
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ucCheckDuplicates_Load(object sender, EventArgs e)
        {
            try
            {
                GetTANIds_AssignToTANTxtBox_AutoComplete();

                cmbMolFormula.SelectedIndex = 0;
                cmbMolWeight.SelectedIndex = 0;
                cmbPageNum.SelectedIndex = 0;
                cmbPageLabel.SelectedIndex = 0;
                cmbExampleNo.SelectedIndex = 0;
                cmbTableNo.SelectedIndex = 0;
                cmbIUPACName.SelectedIndex = 0;
                cmbEnName.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
        }

        private void GetTANIds_AssignToTANTxtBox_AutoComplete()
        {
            try
            {
                int userID = Classes.Generic_PepsiLite.UserID;
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

                        txtTANNumber_Qry.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        txtTANNumber_Qry.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        txtTANNumber_Qry.AutoCompleteCustomSource = tancollection;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
        }
    }
}
