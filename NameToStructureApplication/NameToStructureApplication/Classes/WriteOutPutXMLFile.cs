using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using chemaxon.formats;
using chemaxon.struc;
using java.io;
using System.Xml.Serialization;
using chemaxon.util;
using NameToStructureApplication.Classes;

namespace NameToStructureApplication
{
    class WriteOutPutXMLFile
    {
        public static bool WriteXmlFile(string infilename,string tannumber,string outputfilepath)
        {
            System.IO.StreamWriter sWriter = null;
            try
            {
                sWriter = new System.IO.StreamWriter(outputfilepath);

                //xml file header information
                sWriter.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"no\"?>");
                sWriter.WriteLine("<patent xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:noNamespaceSchemaLocation=\"PatentEnhancedPrioritySubstanceIndexing-2.3.xsd\">");
                sWriter.WriteLine("<patentInfo>");
                sWriter.WriteLine("<tan>" + tannumber + "</tan>");
                sWriter.WriteLine("<language>en</language>");
                sWriter.WriteLine("</patentInfo>");
                sWriter.WriteLine("<propheticSubstances>");

                //Specify input file to MolInputStream object
                MolInputStream molInStream = new MolInputStream(new FileInputStream(infilename));
                MolImporter molImp = new MolImporter(molInStream);
                Molecule mol = new Molecule();

                //Declare mol property variables
                string strPage_No = "";
                string strPage_Lbl = "";
                string strExample_Lbl = "";
                string strEn_name = "";
                string strIUPAC_Name = "";
                string strStandMol = "";
                string strMolBase64 = "";

                //Read molecules from molImporter
                while (molImp.read(mol))
                {
                    sWriter.WriteLine("<propheticSubstance>");
                    sWriter.WriteLine("<patentLocation>");

                    //Page No
                    strPage_No = "";
                    strPage_No = mol.getProperty("Page Number").Trim();
                    sWriter.WriteLine("<pageNumber>" + strPage_No + "</pageNumber>");

                    //Page Label
                    strPage_Lbl = "";
                    strPage_Lbl = mol.getProperty("Page Label").Trim();
                    sWriter.WriteLine("<pageLabel>" + strPage_Lbl + "</pageLabel>");

                    //Example label
                    strExample_Lbl = "";
                    strExample_Lbl = mol.getProperty("Example Number").Trim();
                    sWriter.WriteLine("<exampleLabel>" + strExample_Lbl + "</exampleLabel>");

                    sWriter.WriteLine("</patentLocation>");
                    sWriter.WriteLine("<names>");

                    //en Name
                    strEn_name = "";
                    strEn_name = mol.getProperty("en name").Trim();//En Name
                    sWriter.WriteLine("<name lang=\"en\">" + strEn_name + "</name>");

                    //IUPAC Name 
                    strIUPAC_Name = "";
                    strIUPAC_Name = mol.getProperty("IUPAC Name").Trim();
                    sWriter.WriteLine("<IUPACName>" + strIUPAC_Name + "</IUPACName>");
                    sWriter.WriteLine("</names>");

                    //Check here for V2000 format, if not write in error log
                    string mol2d = mol.toFormat("mol");

					int v3000 = mol2d.IndexOf("V3000");
					if(v3000 != -1)
					{
						//System.out.println("V3000 Error has occured! at Molecule Number: " + molCount + " in SDF file " + fileName);
						//System.exit(0);
					}
					
					double nullMol = mol.getExactMass();
					if(nullMol == 0)
					{
						//System.out.println("NULL Mol Error has occured! at Molecule Number: " + molCount + " in SDF file " + fileName);
						//System.exit(0);
					}


                    strStandMol = "";
                    strStandMol = mol.toFormat("mol");//MoleculeStandardizer.GetStandardizedMolecule(mol.toFormat("mol"));

                    strMolBase64 = "";
                    strMolBase64 = ConvertToBase64.GetConvertedMolString(strStandMol);

                    sWriter.WriteLine("<structureData encoding=\"Base64\" type=\"MDL Molfile V2000\">" + strMolBase64 + "</structureData>");//Base64 Molstring
                    sWriter.WriteLine("</propheticSubstance>");
                }

                sWriter.WriteLine("</propheticSubstances>");
                sWriter.WriteLine("</patent>");
                sWriter.Close();
                sWriter.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
            finally
            {
                sWriter.Close();
                sWriter.Dispose();
            }
            return true;
        }

        public static bool WriteXmlFileUsingXSD(string infilename, string tannumber, string outputfilepath)
        {
            bool blStatus = false;
            try
            {
                patentInfo patentInfo_Obj = new patentInfo();
                patentInfo_Obj.tan = tannumber;
                patentInfo_Obj.language = languageType.en;

                //Specify input file to MolInputStream object
                MolInputStream molInStream = new MolInputStream(new FileInputStream(infilename));
                MolImporter molImp = new MolImporter(molInStream);
                Molecule mol = new Molecule();
                
                //int intMolCnt = molImp.getRecordCount();
                int intMolCnt = ChemistryOperations.GetMoleculeCountFromFile(infilename);

                patentLocation patLoc = null;
                name[] name_Arr = null;
                name name_obj = null;
                names names_Arr = null;
                nameType namType = null;

                structureDataType structDtype = null;

                string[] strIUpacName = null;

                propheticSubstance propSubstance_Obj = null;
                propheticSubstance[] propSubstance_Arr = new propheticSubstance[intMolCnt];
                propheticSubstances propSubstances_Obj = null;

                patent patent_Obj = new patent();
                
                int intCntr = 0;

                //Read molecules from molImporter
                while (molImp.read(mol))
                {
                    patLoc = new patentLocation();
                    patLoc.pageLabel = mol.getProperty("Page Label");
                    patLoc.pageNumber = mol.getProperty("Page Number");
                    patLoc.exampleLabel = mol.getProperty("Example Number");
                    
                    name_Arr = new name[1];

                    name_obj = new name();
                    name_obj.lang = languageType.en;

                    string[] strArr_EnName = new string[1];
                    strArr_EnName[0] = mol.getProperty("en name").Trim();
                    name_obj.Text = strArr_EnName;

                    name_Arr[0] = name_obj;
                    
                    strIUpacName = new string[1];
                    strIUpacName[0] = mol.getProperty("IUPAC Name").Trim();

                    namType = new nameType();
                    namType.Text = strIUpacName;

                    names_Arr = new names();
                    names_Arr.IUPACName = namType;
                    names_Arr.name = name_Arr;

                    string strMol = mol.toFormat("mol");

                    int v3000 = strMol.IndexOf("V3000");
                    double nullMol = mol.getExactMass();

                    byte[] barr_Mol = null;

                    if (v3000 == -1 && nullMol != 0)
                    {
                        barr_Mol = System.Text.ASCIIEncoding.ASCII.GetBytes(strMol);
                    }            

                    structDtype = new structureDataType();
                    structDtype.Value = barr_Mol;

                    propSubstance_Obj = new propheticSubstance();
                    propSubstance_Obj.structureData = structDtype;
                    propSubstance_Obj.patentLocation = patLoc;
                    propSubstance_Obj.names = names_Arr;

                    propSubstance_Arr[intCntr] = propSubstance_Obj;
                    intCntr++;
                }

                propSubstances_Obj = new propheticSubstances();
                propSubstances_Obj.propheticSubstance = propSubstance_Arr;

                patent_Obj.patentInfo = patentInfo_Obj;
                patent_Obj.propheticSubstances = propSubstances_Obj;

                // Serialization
                XmlSerializer xmlSer = new XmlSerializer(typeof(patent));
                TextWriter txtWriter = new StreamWriter(outputfilepath);
                xmlSer.Serialize(txtWriter, patent_Obj);
                
                txtWriter.Close();
                txtWriter.Dispose();
                
                molInStream.close();
                molImp.close();

                blStatus = true;
                return blStatus;
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
            return blStatus;
        }

        public static bool WriteXmlFileUsingDataTable(DataTable _dtTandetails,string _tannumber, string outxmlfile)
        {
            bool blStatus = false;
            try
            {
                if (_dtTandetails != null)
                {
                    if (_dtTandetails.Rows.Count > 0)
                    {
                        patentInfo patentInfo_Obj = new patentInfo();
                        patentInfo_Obj.tan = _tannumber;
                        patentInfo_Obj.language = languageType.en;
                          
                        int intMolCnt = _dtTandetails.Rows.Count;

                        patentLocation patLoc = null;
                        name[] name_Arr = null;
                        name name_obj = null;
                        names names_Arr = null;
                        nameType namType = null;

                        structureDataType structDtype = null;

                        string[] strIUpacName = null;

                        propheticSubstance propSubstance_Obj = null;
                        propheticSubstance[] propSubstance_Arr = new propheticSubstance[intMolCnt];
                        propheticSubstances propSubstances_Obj = null;

                        patent patent_Obj = new patent();

                        int intCntr = 0;
                        string strMol = "";
                        byte[] barr_Mol = null;
                        int v3000 = 0;
                        double nullMol = 0.0;

                        MolHandler objMHandler = null;

                        for (int i = 0; i < _dtTandetails.Rows.Count; i++)
                        {
                            objMHandler = new MolHandler(_dtTandetails.Rows[i]["structure"].ToString());

                            v3000 = 0;
                            v3000 = objMHandler.toFormat("mol").IndexOf("V3000");

                            nullMol = 0.0;
                            nullMol = objMHandler.calcMolWeight();

                            barr_Mol = null;
                            if (v3000 == -1 && nullMol != 0)
                            {
                                patLoc = new patentLocation();
                                patLoc.pageLabel = _dtTandetails.Rows[i]["page_label"].ToString();
                                patLoc.pageNumber = _dtTandetails.Rows[i]["page_number"].ToString();
                                patLoc.exampleLabel = _dtTandetails.Rows[i]["example_number"].ToString();

                                name_obj = new name();
                                name_obj.lang = languageType.en;

                                string[] strArr_EnName = new string[1];
                                strArr_EnName[0] = _dtTandetails.Rows[i]["en_name"].ToString();
                                name_obj.Text = strArr_EnName;

                                name_Arr = new name[1];
                                name_Arr[0] = name_obj;

                                strIUpacName = new string[1];
                                strIUpacName[0] = _dtTandetails.Rows[i]["iupac_name"].ToString();

                                namType = new nameType();
                                namType.Text = strIUpacName;

                                names_Arr = new names();
                                names_Arr.IUPACName = namType;
                                names_Arr.name = name_Arr;

                                strMol = _dtTandetails.Rows[i]["structure"].ToString();      
                                barr_Mol = null;                                
                                barr_Mol = System.Text.ASCIIEncoding.ASCII.GetBytes(strMol);
                                
                                structDtype = new structureDataType();
                                structDtype.Value = barr_Mol;

                                propSubstance_Obj = new propheticSubstance();
                                propSubstance_Obj.structureData = structDtype;
                                propSubstance_Obj.patentLocation = patLoc;
                                propSubstance_Obj.names = names_Arr;

                                propSubstance_Arr[intCntr] = propSubstance_Obj;
                                intCntr++;
                            }
                        }

                        propSubstances_Obj = new propheticSubstances();
                        propSubstances_Obj.propheticSubstance = propSubstance_Arr;

                        patent_Obj.patentInfo = patentInfo_Obj;
                        patent_Obj.propheticSubstances = propSubstances_Obj;

                        // Serialization
                        XmlSerializer xmlSer = new XmlSerializer(typeof(patent));
                        TextWriter txtWriter = new StreamWriter(outxmlfile);
                        xmlSer.Serialize(txtWriter, patent_Obj);

                        txtWriter.Close();
                        txtWriter.Dispose();
                        
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
    }
}
