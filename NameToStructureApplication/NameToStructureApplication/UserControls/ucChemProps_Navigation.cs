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
using chemaxon.struc;
using java.io;
using chemaxon.util;
using chemaxon.reaction;
using NameToStructureApplication.Classes;

#endregion

namespace NameToStructureApplication.UserControls
{
    public partial class ucChemProps_Navigation : UserControl
    {
        #region Constructor

        public ucChemProps_Navigation()
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

        private MolImporter _molimporter = null;
        public MolImporter MOLImporter
        {
            get
            {
                return _molimporter;
            }
            set
            {
                _molimporter = value;
            }
        }

        private DataTable _moldatatbl = null;
        public DataTable MolDataTbl
        {
            get
            {
                return _moldatatbl;
            }
            set
            {
                _moldatatbl = value;
            }
        }
        
        #endregion

        #region Public Variables

        Molecule mol = new Molecule();
        int currRecIndex = 0;
        int MaxRecCnt = 0;
               
        Molecule molObj = null;
        Standardizer molSdz = new Standardizer("absolutestereo:set");
        
        #endregion

        public void LoadMolecules()
        {
            try
            {
                if (_filename.Trim() != "")
                {
                    txtTANNo.Text = TANNumber;

                    //Specify input file to MolInputStream object
                    MolInputStream molInStream = new MolInputStream(new FileInputStream(_filename));
                    MolImporter molImp = new MolImporter(molInStream);
                                       
                    MOLImporter = molImp;

                    DataTable dtMolData = ReadAllMoleculesIntoTable(molImp);
                    if (dtMolData != null)
                    {
                        if (dtMolData.Rows.Count > 0)
                        {
                            MaxRecCnt = dtMolData.Rows.Count;

                            numGoToRec.Maximum = MaxRecCnt;

                            MolDataTbl = dtMolData;

                            lblRecCnt.Text = MaxRecCnt.ToString();
                        }
                    }
                    currRecIndex = 1;

                    numGoToRec.Value = 1;
                    numGoToRec.Minimum = 1;  

                    numGoToRec.Value = currRecIndex;

                    //ReadMoleculeFromTable(currRecIndex);                   
                }
                else
                {
                    MessageBox.Show("No file name specified");
                }

                #region Code Commented
                //while (molImp.read(mol))
                //{
                //    //Page No
                //    strPage_No = "";
                //    strPage_No = mol.getProperty("Page Number").Trim();
                //    txtPageNo.Text = strPage_No;

                //    //Page Label
                //    strPage_Lbl = "";
                //    strPage_Lbl = mol.getProperty("Page Label").Trim();
                //    txtPageLabel.Text = strPage_Lbl;

                //    //Example label
                //    strExample_No = "";
                //    strExample_No = mol.getProperty("Example Number").Trim();
                //    txtExampleNo.Text = strExample_No;

                //    //en Name
                //    strEn_name = "";
                //    strEn_name = mol.getProperty("en name").Trim();//en Name
                //    txten_Name.Text = strEn_name;

                //    //IUPAC Name 
                //    strIUPAC_Name = "";
                //    strIUPAC_Name = mol.getProperty("IUPAC Name").Trim();
                //    lblIUPACName.Text = strIUPAC_Name;

                //    strMolfile = "";
                //    strMolfile = mol.toFormat("mol");//MoleculeStandardizer.GetStandardizedMolecule(mol.toFormat("mol"));

                //    chemRenditor.MolfileString = strMolfile;                                      
                //} 
                #endregion
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }        

        private void ReadMolecule()
        {
            try
            {
                //Declare mol property variables
                string strPage_No = "";
                string strPage_Lbl = "";
                string strExample_No = "";
                string strEn_name = "";
                string strIUPAC_Name = "";
                string strMolfile = "";

                string strMolWeight = "";
                string strMolFormula = "";
                 
                if (MOLImporter.read(mol))
                {
                    currRecIndex++;
                    
                    //Page No
                    strPage_No = "";
                    strPage_No = mol.getProperty("Page Number").Trim();
                    txtPageNo.Text = strPage_No;

                    //Page Label
                    strPage_Lbl = "";
                    strPage_Lbl = mol.getProperty("Page Label").Trim();
                    txtPageLabel.Text = strPage_Lbl;

                    //Example label
                    strExample_No = "";
                    strExample_No = mol.getProperty("Example Number").Trim();
                    txtExampleNo.Text = strExample_No;

                    //en Name
                    strEn_name = "";
                    strEn_name = mol.getProperty("en name").Trim();//en Name
                    txten_Name.Text = strEn_name;

                    //IUPAC Name 
                    strIUPAC_Name = "";
                    strIUPAC_Name = mol.getProperty("IUPAC Name").Trim();
                    txtIUPACName.Text = strIUPAC_Name;

                    txtMolFileNo.Text = currRecIndex.ToString();

                    strMolFormula = mol.getFormula();
                    txtMolFormula.Text = strMolFormula;
                    
                    strMolWeight = mol.getMass().ToString();
                    txtMolWeight.Text = strMolWeight;

                    strMolfile = "";
                    strMolfile = mol.toFormat("mol");//MoleculeStandardizer.GetStandardizedMolecule(mol.toFormat("mol"));

                    if (mol.isAbsStereo())
                    {
                        lblChiral.Visible = true;
                    }
                    else
                    {
                        lblChiral.Visible = false;
                    }

                    chemRenditor.MolfileString = strMolfile;
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private DataTable ReadAllMoleculesIntoTable(MolImporter _molImporter)
        {
            DataTable dtMolData = null;
            try
            {
                dtMolData = ChemistryOperations.CreateTANDetailsTable();

                #region Code Commented
                //dtMolData.Columns.Add("Structure", typeof(object));
                //dtMolData.Columns.Add("MolWeight", typeof(string));
                //dtMolData.Columns.Add("MolFormula", typeof(string));
                //dtMolData.Columns.Add("IupacName", typeof(string));
                //dtMolData.Columns.Add("PageNumber", typeof(string));
                //dtMolData.Columns.Add("PageLabel", typeof(string));
                //dtMolData.Columns.Add("ExampleNumber", typeof(string));
                //dtMolData.Columns.Add("EnName", typeof(string));
                //dtMolData.Columns.Add("IsChiral", typeof(string)); 
                #endregion

                DataRow dtRow = null;
                while (_molImporter.read(mol))
                {
                    //mol.toFormat(byte[] s1 = mol.toBinFormat("png:w300,h300,b32");byte[] s1 = mol.toBinFormat("bmp");
                    
                    dtRow = dtMolData.NewRow();
                                        
                    //Mol Structure                  
                    dtRow["Structure"] = mol.toFormat("mol");

                    //Mol Weight                  
                    dtRow["MolWeight"] = mol.getMass().ToString();

                    //Mol Formula                
                    dtRow["MolFormula"] = mol.getFormula();

                    //Page No                  
                    dtRow["PageNumber"] = mol.getProperty("Page Number").Trim();

                    //Page Label                  
                    dtRow["PageLabel"] = mol.getProperty("Page Label").Trim();

                    //Example Number                 
                    dtRow["ExampleNumber"] = mol.getProperty("Example Number").Trim();

                    //IUPAC Name                 
                    dtRow["IupacName"] = mol.getProperty("IUPAC Name").Trim();

                    //en name                  
                    dtRow["EnName"] = mol.getProperty("en name").Trim();

                    //Is Chiral   
                    if (mol.isAbsStereo())
                    {
                        dtRow["IsChiral"] = "True";
                    }
                    else
                    {
                        dtRow["IsChiral"] = "False";
                    }

                    
                    dtMolData.Rows.Add(dtRow);
                }
                return dtMolData;
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
            return dtMolData;
        }

        private bool ReadMoleculeFromTable(int recindex)
        {
            bool blStatus = false;
            try
            {
                if (MolDataTbl != null)
                {
                    if (MolDataTbl.Rows.Count > 0 && (recindex < MolDataTbl.Rows.Count))
                    {
                        chemRenditor.MolfileString = MolDataTbl.Rows[recindex]["Structure"].ToString();

                        if (MolDataTbl.Rows[recindex]["IsChiral"].ToString() == "True")
                        {
                            lblChiral.Visible = true;
                        }
                        else
                        {
                            lblChiral.Visible = false;
                        }

                        txtMolFormula.Text = MolDataTbl.Rows[recindex]["MolFormula"].ToString();
                        txtMolWeight.Text = MolDataTbl.Rows[recindex]["MolWeight"].ToString();
                        txtIUPACName.Text = MolDataTbl.Rows[recindex]["IupacName"].ToString();
                        txtPageNo.Text = MolDataTbl.Rows[recindex]["PageNumber"].ToString();
                        txtPageLabel.Text = MolDataTbl.Rows[recindex]["PageLabel"].ToString();
                        txtExampleNo.Text = MolDataTbl.Rows[recindex]["ExampleNumber"].ToString();
                        txten_Name.Text = MolDataTbl.Rows[recindex]["EnName"].ToString();

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

        private bool UpdateRecordInTable(int recindex, string molstring, string molweight, string molformula, string pagenum, string pagelabel, string examplenum, string iupacname, string enname)
        {
            bool blStatus = false;
            try
            {
                if (MolDataTbl != null)
                {
                    if (recindex < MolDataTbl.Rows.Count)
                    {
                        MolDataTbl.Rows[recindex]["Structure"] = molstring;
                        MolDataTbl.Rows[recindex]["MolWeight"] = molweight;
                        MolDataTbl.Rows[recindex]["MolFormula"] = molformula;
                        MolDataTbl.Rows[recindex]["IupacName"] = iupacname;
                        MolDataTbl.Rows[recindex]["PageNumber"] = pagenum;
                        MolDataTbl.Rows[recindex]["PageLabel"] = pagelabel;
                        MolDataTbl.Rows[recindex]["ExampleNumber"] = examplenum;
                        MolDataTbl.Rows[recindex]["EnName"] = enname;

                        MolDataTbl.AcceptChanges();
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
        
        private bool DelelteRecordFromTable(int recindex)
        {
            bool blStatus = false;
            try
            {
                if (MolDataTbl != null)
                {
                    if (MolDataTbl.Rows.Count > 0)
                    {
                        if (recindex < MolDataTbl.Rows.Count)
                        {
                            MolDataTbl.Rows[recindex].Delete();
                            MolDataTbl.AcceptChanges();

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

        private bool ValidateUserInputs(out string errmsg_out)
        {
            bool blValStatus = false;
            string strErrMsg = "";
            try
            {
                if (chemRenditor.MolfileString != null)
                {
                    if (txtPageNo.Text.Trim() != "")
                    {
                        if (txtTANNo.Text.Trim() != "")
                        {
                            if (Validations.IsValidTanNumber(txtTANNo.Text.Trim()))
                            {
                                if (txtMolFileNo.Text.Trim() != "")
                                {
                                    blValStatus = true;
                                }
                                else
                                {
                                    strErrMsg = "Please enter Molfile number";
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
                        strErrMsg = "Please enter Page Number";
                    }
                }
                else
                {
                    strErrMsg = "Structure can not be a null";
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

        private void ClearUserInputs()
        {
            try
            {                
                chemRenditor.MolfileString = "";
                txtIUPACName.Text = "";
                txtPageNo.Text = "";
                txtPageLabel.Text = "00";
                txtExampleNo.Text = "00";

                txtMolFormula.Text = "";
                txtMolWeight.Text = "";

                txtMolFileNo.Text = "";
                txten_Name.Text = "";

            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        #region Events

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
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
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
            PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
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
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
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
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
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
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                bool blVerified = false;

                if (chkVerifyV2000.Checked)
                {
                    if (!ChemistryOperations.CheckForV3000Format(chemRenditor.MolfileString))
                    {
                        blVerified = true;
                    }
                    else
                    {
                        MessageBox.Show("Molecule is in V3000 format", "V3000 format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    blVerified = true;
                }
                if (blVerified)
                {
                    DialogResult diaRes = MessageBox.Show("Do you want to update?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (diaRes == DialogResult.Yes)
                    {
                        Molecule objMol_out = null;
                        Cursor = Cursors.WaitCursor;

                        if (!ChemistryOperations.CheckForDuplicateStructure(FileName, chemRenditor.MolfileString, currRecIndex, out objMol_out))
                        {
                            string strMolFile = chemRenditor.MolfileString;
                            string strMolWeight = txtMolWeight.Text.Trim();
                            string strMolFormula = txtMolFormula.Text.Trim();
                            string strPageNo = txtPageNo.Text.Trim();

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

                            if (UpdateRecordInTable(currRecIndex - 1, strMolFile, strMolWeight, strMolFormula, strPageNo,
                                                                      strPageLabel, strExampleNo, strIUPACName, strEn_Name))
                            {
                                if (Delete_UpdateOperations.UpdateRecordInSdFile(_filename, currRecIndex, strMolFile, strPageNo, strPageLabel,
                                                                                       strExampleNo, strIUPACName, strEn_Name))
                                {
                                    Cursor = Cursors.Default;
                                    MessageBox.Show("Record updated successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    Cursor = Cursors.Default;
                                    MessageBox.Show("Error in updating", "Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                Cursor = Cursors.Default;
                                MessageBox.Show("Error in updating", "Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            Cursor = Cursors.Default;
                            MessageBox.Show("Duplicate Record");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void chemRenditor_StructureChanged(object sender, EventArgs e)
        {
            try
            {
                if (chemRenditor.MolfileString != null)
                {
                    if (chemRenditor.MolfileString.Trim() != "" && strInchi_Before != "")
                    {
                        chemaxon.util.MolHandler molHandler = new MolHandler(chemRenditor.MolfileString);
                        Molecule objMol = molHandler.getMolecule();

                        string strInchi_After = objMol.toFormat("inchi:key");

                        strInchi_After = Validations.GetInchiKeyFromInchiString(strInchi_After);

                        if (strInchi_After != strInchi_Before)
                        {
                            txtMolWeight.Text = objMol.getMass().ToString();
                            txtMolFormula.Text = objMol.getFormula();

                            if (objMol.isAbsStereo())
                            {
                                lblChiral.Visible = true;
                            }
                            else
                            {
                                lblChiral.Visible = false;
                            }

                            string strMolfile = objMol.toFormat("mol");
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
                }

                #region Code Commented
                //if (chemRenditor.MolfileString.Trim() != "")
                //{
                //    string strChem = MolDataTbl.Rows[currRecIndex - 1]["Structure"].ToString();
                //    chemaxon.util.MolHandler molHandler_Qry = new MolHandler(chemRenditor.MolfileString.Trim());
                //    Molecule molObj_Qry = molHandler_Qry.getMolecule();

                //    chemaxon.util.MolHandler molHandler_Trgt = new MolHandler(strChem);
                //    Molecule molObj_Trgt = molHandler_Trgt.getMolecule();

                //    string strInchi_Qry = molObj_Qry.toFormat("inchi:key");
                //    string strInchi_Trgt = molObj_Trgt.toFormat("inchi:key");

                //    strInchi_Qry = Validations.GetInchiKeyFromInchiString(strInchi_Qry);
                //    strInchi_Trgt = Validations.GetInchiKeyFromInchiString(strInchi_Trgt);

                //    if (!strInchi_Qry.Equals(strInchi_Trgt))
                //    {
                //       txtMolWeight.Text = molObj_Qry.getMass().ToString();
                //       txtMolFormula.Text = molObj_Qry.getFormula();

                //       if (molObj_Qry.isAbsStereo())
                //       {
                //           lblChiral.Visible = true;
                //       }
                //       else
                //       {
                //           lblChiral.Visible = false;
                //       }

                //        string strMolfile = molObj_Qry.toFormat("mol");
                //        string strIUPACName = "";
                //        string strErrMsg = "";
                //        if (ChemistryOperations.GetIUPACNameFromStructure(strMolfile, out strIUPACName, out strErrMsg))
                //        {
                //            strIUPACName = Validations.RemoveSMILESFromIUPACName(strIUPACName);
                //            strIUPACName = Validations.GetConvertedIUPACName(strIUPACName);
                //        }
                //        else
                //        {
                //            strIUPACName = "IUPAC name not provided";
                //        }
                //        lblIUPACName.Text = strIUPACName;
                //    }             
                //} 
                #endregion
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }
        
        string strInchi_Before = "";
        private void chemRenditor_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (chemRenditor.MolfileString != null)
                {
                    chemaxon.util.MolHandler molHandler = new MolHandler(chemRenditor.MolfileString);
                    Molecule molObj = molHandler.getMolecule();

                    strInchi_Before = molObj.toFormat("inchi:key");
                    strInchi_Before = Validations.GetInchiKeyFromInchiString(strInchi_Before);                   
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }
        
        private void btnDelRec_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult diaRes = MessageBox.Show("Do you want to delete the record?","Delete record",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (diaRes == DialogResult.Yes)
                {
                    Cursor = Cursors.WaitCursor;

                    if (DelelteRecordFromTable(currRecIndex - 1))
                    {
                        if (Delete_UpdateOperations.DeleteRecordFromSDFile(FileName, currRecIndex))
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
                            }

                            if (currRecIndex == numGoToRec.Value)
                            {
                                ReadMoleculeFromTable(currRecIndex - 1);
                                currRecIndex = Convert.ToInt32(numGoToRec.Value);
                            }
                            else if (currRecIndex > 0)
                            {
                                numGoToRec.Value = currRecIndex;
                                numGoToRec.Maximum = numGoToRec.Maximum - 1;
                            }
                            else
                            {
                                numGoToRec.Minimum = 0;
                                numGoToRec.Maximum = 0;
                                numGoToRec.Value = 0;
                            }

                            lblRecCnt.Text = MaxRecCnt.ToString();
                        }

                        Cursor = Cursors.Default;
                        MessageBox.Show("Deleted record successfully","Delete record",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
