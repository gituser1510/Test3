#region Import Assemblies

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using chemaxon;
using chemaxon.reaction;
using java.io;
using chemaxon.struc;
using chemaxon.util;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using chemaxon.formats;
using System.Collections;
using System.Data;

#endregion

namespace NameToStructureApplication
{
    public static class ChemistryOperations
    {
        public static string GetStandardizedMolecule(string strMolFile, out bool isChiral_Out)
        {
            string strStandMol = "";
            bool blIsChiral = false;
            try
            {
                chemaxon.util.MolHandler molHandler = new MolHandler(strMolFile);
                Molecule molObj = molHandler.getMolecule();
                Molecule molObj_Stand = StandardizeMolecule(molObj, out blIsChiral);
                strStandMol = molObj_Stand.toFormat("mol");

                isChiral_Out = blIsChiral;
                return strStandMol;
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }

            isChiral_Out = blIsChiral;
            return strStandMol;
        }

        private static Molecule StandardizeMolecule(Molecule mol, out bool ischiral_out)
        {
            Molecule molChem = null;
            bool blIsChiral = false;
            try
            {
                Standardizer molSdz = new Standardizer("absolutestereo:set");
                molChem = molSdz.standardize(mol);

                blIsChiral = molChem.isAbsStereo();

                #region Code Commented
                //string strDirPath = AppDomain.CurrentDomain.BaseDirectory.ToString();
                //string strXmlPath = strDirPath + "chiral.xml";
                //StandardizerConfiguration sconfing = new StandardizerConfiguration();
                //sconfing.read(strXmlPath);
                //Standardizer sdz = sconfing.getStandardizer();
                //molChem = sdz.standardize(mol);                               
                //Standardizer sdz = new Standardizer(new File(strXmlPath)); 
                #endregion

                ischiral_out = blIsChiral;
                return molChem;
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
            ischiral_out = blIsChiral;
            return molChem;
        }

        public static bool GetStructureFromCompoundName(string strCompName, out string molstring_out,out bool ischiral_out, out string errmessage_out)
        {
            bool blStatus = false;
            string strMolString = "";
            string strErrMessage = "";
            bool blIsChiral = false;
            try
            {
                string strDirPath = AppDomain.CurrentDomain.BaseDirectory.ToString();
                string strExePath = strDirPath + "nam2mol.exe";

                string strInputFileName = "CompName.txt";
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
                //startInfo.Arguments = @"-in """ + strDirPath + strInputFileName + @""" -depict true";

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
                    ErrorHandling_NTS.WriteErrorLog(ex.ToString());
                }
                //Read Output molecule from outputfile
                StreamReader sReader = new StreamReader(strDirPath + strOutputFileName);
                string newMolfileString;
                newMolfileString = sReader.ReadToEnd();

                //Standardize the molecule
                string strStandMol = GetStandardizedMolecule(newMolfileString, out blIsChiral);
                 
                sReader.Close();
                sReader.Dispose();

                if (newMolfileString != "")
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
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
            molstring_out = "";
            ischiral_out = blIsChiral;
            errmessage_out = strErrMessage;
            return blStatus;
        }

        public static string GetMoleculeWeightAndMolFormula(string molstring, out string molformula_out)
        {
            string strMolWeight = "";
            string strMolFormula = "";
            try
            {
                MolHandler mHandler = new MolHandler(molstring);
                float fltMolWeight = mHandler.calcMolWeight();

                strMolFormula = mHandler.calcMolFormula();
                strMolWeight = fltMolWeight.ToString();

                molformula_out = strMolFormula;
                return strMolWeight;
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
            molformula_out = strMolFormula;
            return strMolWeight;
        }

        public static bool GetIUPACNameFromStructure(string molfilestring, out string iupacname_out, out string errmessage_out)
        {
            bool blStatus = false;
            string strIUPACName = "";
            string strErrMessage = "";
            try
            {
                string strDirPath = AppDomain.CurrentDomain.BaseDirectory.ToString();
                string strExePath = strDirPath + "mol2nam.exe";

                string strInputFileName = "MolFile.mol";
                //string strOutputFileName = "MolName.txt";

                if (System.IO.File.Exists(strDirPath + strInputFileName))
                {
                    System.IO.File.Delete(strDirPath + strInputFileName);
                }
                System.IO.StreamWriter sWriter = new System.IO.StreamWriter(strDirPath + strInputFileName);                
                sWriter.WriteLine(molfilestring);
                sWriter.Close();
                sWriter.Dispose();

                //if (System.IO.File.Exists(strDirPath + strOutputFileName))
                //{
                //    System.IO.File.Delete(strDirPath + strOutputFileName);
                //}

                //ProcessStartInfo class
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.CreateNoWindow = true;
                startInfo.UseShellExecute = false;
                startInfo.RedirectStandardError = true;
                startInfo.RedirectStandardOutput = true;
                startInfo.FileName = @"" + strExePath + "";
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                //startInfo.Arguments = @"-in """ + strDirPath + strInputFileName + @"""  -out """ + strDirPath + strOutputFileName + @""" -capitalize true";
                startInfo.Arguments = @"-in """ + @"" + strDirPath + strInputFileName + @""" -nobanner";

                string strErrMsg = "";
                string strIUPACName_Out = "";

                try
                {
                    using (Process exeProcess = Process.Start(startInfo))
                    {
                        strErrMsg = exeProcess.StandardError.ReadToEnd();
                        strIUPACName_Out = exeProcess.StandardOutput.ReadToEnd();

                        exeProcess.WaitForExit();
                    }
                }
                catch (Exception ex)
                {
                    ErrorHandling_NTS.WriteErrorLog(ex.ToString());
                }               

                //StreamReader sr = new StreamReader(strDirPath + strOutputFileName);
                //string IUPACName = "";
                //IUPACName = sr.ReadToEnd();
                //sr.Close();
                //sr.Dispose();

                if (strIUPACName_Out != "")
                {
                    strIUPACName = strIUPACName_Out;
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
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }

            iupacname_out = strIUPACName;
            errmessage_out = strErrMessage;
            return blStatus;
        }

        public static int GetMoleculeCountFromFile(string filename)
        {
            try
            {
                string text = "";

                FileStream FS = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
                StreamReader SR = new StreamReader(FS);
                text = SR.ReadToEnd();
               
                SR.Close();
                SR.Dispose();
                
                FS.Close();
                FS.Dispose();
                Regex RE = new Regex("^\\$\\$\\$\\$", RegexOptions.Multiline);
                MatchCollection theMatches = RE.Matches(text);
                
                return (theMatches.Count);
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
            return 0;
        }

        public static bool CheckForV3000Format(string molfilestring)
        {
            bool blIsV3000 = false;
            try
            {
                if (molfilestring != "")
                {                                 
                    int v3000 = molfilestring.IndexOf("V3000");
                    if (v3000 == -1)
                    {
                        blIsV3000 = false;
                    }
                    else
                    {
                        blIsV3000 = true;
                    }                    
                   
                    #region Code Commented 
                    //MolHandler mHandler = new MolHandler(molfilestring);
                    //int atomCnt = mHandler.getAtomCount();
                    //if (atomCnt > 999)
                    //{
                    //    blIsV3000 = true;
                    //}
                    //else
                    //{
                    //    blIsV3000 = false;
                    //}
                    #endregion
                }
                return blIsV3000;
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
            return blIsV3000;
        }

        public static bool CheckForDuplicateStructure(string filename, string qrymolfile,int recindex,out Molecule mol_out)
        {
            bool blStatus = false;
            try
            {
                bool blIsChiral = false;

                MolHandler mHandler = new MolHandler(qrymolfile);
                Molecule qryMol = mHandler.getMolecule();
                qryMol = StandardizeMolecule(qryMol, out blIsChiral);

                string strqryMolInchi = qryMol.toFormat("inchi:key");
                strqryMolInchi = Validations.GetInchiKeyFromInchiString(strqryMolInchi);

                //Specify input file to MolInputStream object
                MolInputStream molInStream = new MolInputStream(new FileInputStream(filename));
                MolImporter molImp = new MolImporter(molInStream);
                Molecule objMol = new Molecule();
                
                blIsChiral = false;
                string strInchiKey = "";
                int intRecIndx = 0;

                Molecule molObj_Stand = null;
                while (molImp.read(objMol))
                {
                    molObj_Stand = StandardizeMolecule(objMol, out blIsChiral);

                    strInchiKey = objMol.toFormat("inchi:key");
                    strInchiKey = Validations.GetInchiKeyFromInchiString(strInchiKey);

                    intRecIndx++;

                    if ((strInchiKey == strqryMolInchi) && (intRecIndx != recindex))
                    {
                        blStatus = true;
                        mol_out = objMol;
                        return blStatus;
                    }
                }

                molImp.close();
                molInStream.close();

            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
            mol_out = null;
            return blStatus;
        }
                
        public static bool DeleteAllDuplicateStructures(string filename,out int totalreccnt, out int dupreccnt)
        {
            bool blStatus = false;
            int intDupRecCnt = 0;
            int intTotalRecCnt = 0;
            try
            {              
                MolInputStream molInStream = new MolInputStream(new FileInputStream(filename));
                MolImporter molImp = new MolImporter(molInStream);
                Molecule objMol = new Molecule();

                DataOutputStream dOutStream = new DataOutputStream(new FileOutputStream(filename));
                MolExporter molExpt = new MolExporter(dOutStream, "sdf");

                bool blIsChiral = false;
                string strInchiKey = "";

                ArrayList molInchiList = new ArrayList();
                               
                while (molImp.read(objMol))
                {
                    objMol = StandardizeMolecule(objMol, out blIsChiral);

                    strInchiKey = objMol.toFormat("inchi:key");
                    strInchiKey = Validations.GetInchiKeyFromInchiString(strInchiKey);

                    if (!molInchiList.Contains(strInchiKey))
                    {
                        molInchiList.Add(strInchiKey);
                        molExpt.write(objMol);
                    }
                    else
                    {
                        intDupRecCnt++;
                    }
                    intTotalRecCnt++;
                }
                //Close all the import & export objects
                molImp.close();               
                molInStream.close();
                dOutStream.close();
                molExpt.close();

                blStatus = true;
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
            totalreccnt = intTotalRecCnt;
            dupreccnt = intDupRecCnt;
            return blStatus;
        }

        public static int GetDuplicateRecordsCount(string filename, out int totalreccnt)
        {            
            int intDupRecCnt = 0;
            int intTotalRecCnt = 0;

            try
            {
                MolInputStream molInStream = new MolInputStream(new FileInputStream(filename));
                MolImporter molImp = new MolImporter(molInStream);
                Molecule objMol = new Molecule();

                bool blIsChiral = false;
                string strInchiKey = "";

                ArrayList molInchiList = new ArrayList();

                while (molImp.read(objMol))
                {
                    objMol = StandardizeMolecule(objMol, out blIsChiral);

                    strInchiKey = objMol.toFormat("inchi:key");
                    strInchiKey = Validations.GetInchiKeyFromInchiString(strInchiKey);

                    if (!molInchiList.Contains(strInchiKey))
                    {
                        molInchiList.Add(strInchiKey);                   
                    }
                    else
                    {
                        intDupRecCnt++;
                    }
                    intTotalRecCnt++;
                }

                molImp.close();
                molInStream.close();
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
            totalreccnt = intTotalRecCnt;
            return intDupRecCnt;
        }

        public static string GetStructureInchiKey(string _molfilestring)
        {
            string strInchiKey = "Inchi Not generated";
            try
            {
                MolHandler mHandler = new MolHandler(_molfilestring);
                Molecule mol = mHandler.getMolecule();
                try
                {
                    strInchiKey = mol.toFormat("inchi:key");                    
                }
                catch //Exception is inchi not generated
                {
                    // if inchi not generated
                    SetMolAbsStereo_Inchi_NotGenerated(ref mol);

                    strInchiKey = mol.toFormat("inchi:key");                    
                }
                if (strInchiKey != "")
                {
                    strInchiKey = Validations.GetInchiKeyFromInchiString(strInchiKey);
                }
                
                return strInchiKey;
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
            return strInchiKey; 
        }

        private static void SetMolAbsStereo_Inchi_NotGenerated(ref Molecule _molobj)
        {
            try
            {
                int atno = 0;
                MolAtom ma = null;
                for (int i = 0; i < (_molobj.getAtomCount() - 1); i++)
                {
                    atno = _molobj.getAtom(i).getAtno();
                    if (atno > 109)
                    {
                        ma = _molobj.getAtom(i);
                        ma.setAtno(6);
                    }
                }
                bool flag1 = _molobj.ungroupSgroups();
                bool flag2 = _molobj.hydrogenize(false);
                if (_molobj.isAbsStereo())
                {
                    _molobj.setAbsStereo(true);
                }
                _molobj.aromatize(false);
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
        }

        public static double GetStructureMolWeight_MolFormula(string _molfilestring,out string _molformula)
        {
            double dblMolWeight = 0.0;
            string strMolFormula = "";
            try
            {
                MolHandler mHandler = new MolHandler(_molfilestring);
                dblMolWeight = mHandler.calcMolWeight();

                strMolFormula = mHandler.calcMolFormula();

                _molformula = strMolFormula;
                return dblMolWeight;
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
            _molformula = strMolFormula;
            return dblMolWeight;
        }
        
        public static DataTable GetDuplicateRecords(string filename, string qrymolstring,out int totalrecs_out)
        {
            DataTable dtDupRecs = null;
            int totalRecCnt = 0;
            try
            {
                dtDupRecs = CreateTANDetailsTable();

                dtDupRecs.Columns.Add("OrigRecIndex",typeof(Int32));
                
                bool blIsChiral = false;
                string InchiKey_Qry = "";
                string InchiKey_Trgt = "";

                MolHandler mHandler = new MolHandler(qrymolstring);
                Molecule qryMol = mHandler.getMolecule();
                StandardizeMolecule(qryMol, out blIsChiral);

                InchiKey_Qry = qryMol.toFormat("inchi:key");
                InchiKey_Qry = Validations.GetInchiKeyFromInchiString(InchiKey_Qry);
                
                MolInputStream molInStream = new MolInputStream(new FileInputStream(filename));
                MolImporter molImp = new MolImporter(molInStream);
                Molecule objMol = new Molecule();
                
                DataRow dtRow = null;

                while (molImp.read(objMol))
                {
                    objMol = StandardizeMolecule(objMol, out blIsChiral);

                    InchiKey_Trgt = objMol.toFormat("inchi:key");
                    InchiKey_Trgt = Validations.GetInchiKeyFromInchiString(InchiKey_Trgt);

                    if (InchiKey_Qry == InchiKey_Trgt)
                    {                    
                        dtRow = dtDupRecs.NewRow();

                        //Mol Structure                  
                        dtRow["Structure"] = objMol.toFormat("mol");

                        //Mol Weight                  
                        dtRow["MolWeight"] = objMol.getMass().ToString();

                        //Mol Formula                
                        dtRow["MolFormula"] = objMol.getFormula();

                        //Page No                  
                        dtRow["PageNumber"] = objMol.getProperty("Page Number").Trim();

                        //Page Label                  
                        dtRow["PageLabel"] = objMol.getProperty("Page Label").Trim();

                        //Example Number                 
                        dtRow["ExampleNumber"] = objMol.getProperty("Example Number").Trim();

                        //IUPAC Name                 
                        dtRow["IupacName"] = objMol.getProperty("IUPAC Name").Trim();

                        //en name                  
                        dtRow["EnName"] = objMol.getProperty("en name").Trim();

                        //Is Chiral   
                        if (objMol.isAbsStereo())
                        {
                            dtRow["IsChiral"] = "True";
                        }
                        else
                        {
                            dtRow["IsChiral"] = "False";
                        }

                        dtRow["OrigRecIndex"] = totalRecCnt;

                        dtDupRecs.Rows.Add(dtRow);
                    }
                    totalRecCnt++;
                }
                molImp.close();
                molInStream.close();

                totalrecs_out = totalRecCnt;
                return dtDupRecs;
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
            totalrecs_out = totalRecCnt;
            return dtDupRecs;
        }

        public static DataTable CreateTANDetailsTable()
        {
            DataTable dtStructData = new DataTable();
            try
            {
                dtStructData.Columns.Add("tan_dtl_id", typeof(Int32));
                dtStructData.Columns.Add("structure", typeof(object));
                dtStructData.Columns.Add("mol_weight", typeof(double));
                dtStructData.Columns.Add("mol_formula", typeof(string));
                dtStructData.Columns.Add("iupac_name", typeof(string));
                dtStructData.Columns.Add("page_number", typeof(int));
                dtStructData.Columns.Add("page_label", typeof(string));
                dtStructData.Columns.Add("example_number", typeof(string));
                dtStructData.Columns.Add("en_name", typeof(string));
                dtStructData.Columns.Add("table_number", typeof(string));
                dtStructData.Columns.Add("inchi_key", typeof(string));               

                return dtStructData;
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
            return dtStructData;
        }
    }
}
