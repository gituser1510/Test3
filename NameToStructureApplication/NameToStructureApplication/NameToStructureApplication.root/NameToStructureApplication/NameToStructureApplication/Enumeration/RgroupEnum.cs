using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using chemaxon.formats;
using chemaxon.struc;
using chemaxon.marvin.calculations;
using chemaxon.util;
using java.io;
using System.Collections;
using PepsiLiteDataAccess;

namespace NameToStructureApplication.Enumeration
{
   public static class RgroupEnum
    {
       static ChemDrawControl8.ChemDrawCtlClass chemclass = new ChemDrawControl8.ChemDrawCtlClass();

       public static DataTable CreateRGroupEnumTable(string _indetifier, string[] _rgrparr)
       {
           try
           {
               DataTable dtRgrpTbl = new DataTable();

               if (_rgrparr != null)
               {
                   if (_rgrparr.Length > 0)
                   {
                       dtRgrpTbl.Columns.Add(_indetifier, typeof(string));
                       for (int i = 0; i < _rgrparr.Length; i++)
                       {
                           dtRgrpTbl.Columns.Add(_rgrparr[i], typeof(string));
                       }
                   }
               }
               return dtRgrpTbl;
           }
           catch (Exception ex)
           {
               ErrorHandling_NTS.WriteErrorLog(ex.ToString());
           }
           return null;
       }

       public static DataTable ConvertChemicalNameToSMILES_JChem(DataTable _chemnamestbl)
       {
           DataTable dtSmiles = null;
           try
           {
               if (_chemnamestbl != null)
               {
                   if (_chemnamestbl.Rows.Count > 0)
                   {
                       dtSmiles = _chemnamestbl.Copy();

                       MolHandler molHandler = null;
                       Molecule molObj = null;
                       string strSMILES = "";

                       for (int rowindex = 0; rowindex < dtSmiles.Rows.Count; rowindex++)
                       {
                           for (int colindex = 1; colindex < dtSmiles.Columns.Count; colindex++)
                           {
                               try
                               {
                                   molHandler = new MolHandler(dtSmiles.Rows[rowindex][colindex].ToString());
                                   molObj = molHandler.getMolecule();
                                   strSMILES = molObj.toFormat("smiles:u");
                               }
                               catch
                               {
                                   strSMILES = "";
                               }

                               if (strSMILES == "")
                               {
                                   strSMILES = "";
                               }
                               dtSmiles.Rows[rowindex][colindex] = strSMILES;
                           }
                       }
                       dtSmiles.AcceptChanges();
                   }
               }
           }
           catch (Exception ex)
           {
               ErrorHandling_NTS.WriteErrorLog(ex.ToString());
           }
           return dtSmiles;
       }

       public static DataTable ConvertChemicalNameToSMILES_ChemDraw(DataTable _chemnamestbl)
       {
           DataTable dtSmiles = null;
           try
           {
               if (_chemnamestbl != null)
               {
                   if (_chemnamestbl.Rows.Count > 0)
                   {
                       dtSmiles = _chemnamestbl.Copy();

                       string strSMILES = "";             

                       for (int rowindex = 0; rowindex < dtSmiles.Rows.Count; rowindex++)
                       {
                           for (int colindex = 1; colindex < dtSmiles.Columns.Count; colindex++)
                           {
                               try
                               {
                                   chemclass.Objects.Clear();
                                   chemclass.Objects.set_Data("chemical/x-name", null, null, null, dtSmiles.Rows[rowindex][colindex].ToString());

                                   object objStruct = chemclass.get_Data("chemical/x-smiles");

                                   if (objStruct != null)
                                   {
                                       strSMILES = objStruct.ToString();
                                   }
                                   else
                                   {
                                       strSMILES = PepsiLiteDataAccess.DataOperations.RetrieveDictSmilesOnCompName(dtSmiles.Rows[rowindex][colindex].ToString());
                                   }
                               }
                               catch
                               {
                                   strSMILES = "";
                               }
                               dtSmiles.Rows[rowindex][colindex] = strSMILES;
                           }
                       }
                       dtSmiles.AcceptChanges();
                   }
               }
           }
           catch (Exception ex)
           {
               ErrorHandling_NTS.WriteErrorLog(ex.ToString());
           }
           return dtSmiles;
       }

       public static DataTable GetRGroupEnumerationResults(DataTable _enumDataTbl, string _qryRCore)
       {
           DataTable dtEnumResData = new DataTable();
           try
           {
               dtEnumResData.Columns.Add("id", typeof(string));
               dtEnumResData.Columns.Add("structure", typeof(object));
               dtEnumResData.Columns.Add("mol_weight", typeof(double));
               dtEnumResData.Columns.Add("mol_formula", typeof(string));
               dtEnumResData.Columns.Add("iupac_name", typeof(string));               
               dtEnumResData.Columns.Add("inchi_key", typeof(string));      
               
               int rgrpNum = 1;

               Molecule molEnum = null;
               MolHandler mHandler = null;
               Molecule rCoreMol = null;
               RgMolecule rgMol = null;
               MolHandler mHand_Result = null;

               DataRow dtRow = null;

               string strMolFile = "";
               string strIUPACName = "";
               string strErrMsg = "";

               if (_enumDataTbl != null)
               {
                   if (_enumDataTbl.Rows.Count > 0)
                   {
                       for (int rowindx = 0; rowindx < _enumDataTbl.Rows.Count; rowindx++)
                       {
                           molEnum = new Molecule();
                           mHandler = new MolHandler(_qryRCore);
                           rCoreMol = mHandler.getMolecule();

                           try
                           {
                               for (int colindx = 1; colindx < _enumDataTbl.Columns.Count; colindx++)
                               {
                                   rgrpNum = GetRgroupNumFromRGroupName(_enumDataTbl.Columns[colindx].ColumnName);
                                   rgMol = ReturnRGroupMolecule(_enumDataTbl.Rows[rowindx][colindx].ToString(), rgrpNum);
                                   molEnum = AddRGrpMolToCoreMolecule(rgMol, rCoreMol, rgrpNum);
                               }
                               mHand_Result = new MolHandler(molEnum);
                               strMolFile = "";
                               strMolFile = mHand_Result.toFormat("mol");
                           }
                           catch
                           { 
                           
                           }
                           dtRow = dtEnumResData.NewRow();
                           
                           dtRow["id"] = _enumDataTbl.Rows[rowindx][0].ToString();
                           dtRow["structure"] = strMolFile;
                           if (strMolFile != "")
                           {
                               dtRow["mol_weight"] = mHand_Result.calcMolWeight();
                               dtRow["mol_formula"] = mHand_Result.calcMolFormula();
                               dtRow["inchi_key"] = ChemistryOperations.GetStructureInchiKey(strMolFile);

                               strIUPACName = "";
                               strErrMsg = "";
                               if (ChemistryOperations.GetIUPACNameFromStructure(strMolFile, out strIUPACName, out strErrMsg))
                               {
                                   strIUPACName = Validations.GetConvertedIUPACName(strIUPACName);
                               }
                               else
                               {
                                   strIUPACName = "IUPAC name not provided";
                               }

                               dtRow["iupac_name"] = strIUPACName;
                           }

                           dtEnumResData.Rows.Add(dtRow);
                       }

                       return dtEnumResData;                       
                   }
               }
           }
           catch (Exception ex)
           {
               ErrorHandling_NTS.WriteErrorLog(ex.ToString());
           }
           return dtEnumResData;
       }

       public static RgMolecule ReturnRGroupMolecule(string _rgrpSmiles,int _rgrpNum)
       {
           try
           {
               MolHandler mHandler = new MolHandler(_rgrpSmiles);
               Molecule objMol = mHandler.getMolecule();
               RgMolecule rgMol = new RgMolecule();            
               MolAtom mAtom = new MolAtom(MolAtom.RGROUP, 1, 0, 0);
               mAtom.setRgroup(_rgrpNum);
               rgMol.add(mAtom);

               int radNum = 0;
               for (int i = 0; i < objMol.getAtomCount(); i++)
               {
                   if (objMol.getRadical(i) > 0)
                   {
                       radNum = i;
                   }
               }

               for (int i = 0; i < objMol.getAtomCount(); i++)
               {
                   if (i == 0)
                   {
                       objMol.getAtom(radNum).setRadical(MolAtom.RAD_OFF);
                   }
                   rgMol.add(objMol.getAtom(i));
               }

               for (int j = 0; j < objMol.getBondCount(); j++)
               {
                   rgMol.add(objMol.getBond(j));
               }

               rgMol.add(new MolBond(objMol.getAtom(radNum), mAtom));
               rgMol.clean(2, null, null);
               return rgMol;
           }
           catch (Exception ex)
           {
               ErrorHandling_NTS.WriteErrorLog(ex.ToString());
           }
           return null;
       }

       public static Molecule AddRGrpMolToCoreMolecule(RgMolecule _rgMol,Molecule _coreMol,int _rgrpNum)
       {
           try
           {
               //Get RGroup position
               int rgrpPos = GetRGroupPosition(_coreMol, _rgrpNum);

               //Get Radical position
               int radPos = GetRadicalPosition(_rgMol);         
               
               //Add Rgroup Molecule to Core Molecule
               AddRGroupToCore(ref _coreMol, _rgMol);                            
                            
               _coreMol.add(new MolBond(_coreMol.getAtom(rgrpPos).getBond(0).getAtom1(), _rgMol.getAtom(radPos)));
                       
               _coreMol.removeNode(_coreMol.getNode(rgrpPos), CGraph.RMCLEANUP_ALL);  
               _coreMol.clean(2, null, null);

               rgrpPos = GetRGroupPosition(_coreMol, _rgrpNum);

               _coreMol.removeNode(_coreMol.getNode(rgrpPos), CGraph.RMCLEANUP_ALL);
               _coreMol.clean(2, null, null);
               
               return _coreMol;
           }
           catch (Exception ex)
           {
               ErrorHandling_NTS.WriteErrorLog(ex.ToString());
           }
           return null;
       }

       private static int GetRGroupPosition(Molecule _coreMol, int _rgrpNum)
       {
           int rgroupPos = 0;
           try
           {
               for (int j = 0; j < _coreMol.getAtomCount(); j++)
               {
                   if (_coreMol.getAtom(j).getRgroup() == _rgrpNum)
                   {
                       rgroupPos = j;
                   }
               }
           }
           catch (Exception ex)
           {
               ErrorHandling_NTS.WriteErrorLog(ex.ToString());
           }
           return rgroupPos;
       }

       private static int GetRadicalPosition(RgMolecule _rgMol)
       {
           int radPos = 0;
           try
           {
               for (int k = 0; k < _rgMol.getAtomCount(); k++)
               {
                   if (_rgMol.getAtom(k).getRadical() > 0)
                   {
                       radPos = k;
                   }
               }
           }
           catch (Exception ex)
           {
               ErrorHandling_NTS.WriteErrorLog(ex.ToString());
           }
           return radPos;
       }

       private static void AddRGroupToCore(ref Molecule _coreMol, RgMolecule _rgMol)
       {
           try
           {
               for (int aIndx = 0; aIndx < _rgMol.getAtomCount(); aIndx++)
               {
                   if (aIndx == 0)
                   {
                       _rgMol.getAtom(0).setRadical(MolAtom.RAD_OFF);
                   }
                   _coreMol.add(_rgMol.getAtom(aIndx));
               }
               
               for (int bIndx = 0; bIndx < _rgMol.getBondCount(); bIndx++)
               {
                   _coreMol.add(_rgMol.getBond(bIndx));
               }
           }
           catch (Exception ex)
           {
               ErrorHandling_NTS.WriteErrorLog(ex.ToString());
           }
       }

       private static int GetRgroupNumFromRGroupName(string _rgrpname)
       {
           int rgrpNum = 0;
           try
           {
               if (_rgrpname.Trim() != "")
               {
                   string[] splitter = { "R" };
                   string[] strVals = _rgrpname.Trim().Split(splitter, StringSplitOptions.RemoveEmptyEntries);
                   if (strVals != null)
                   {
                       if (strVals.Length > 0)
                       {
                           rgrpNum = Convert.ToInt16(strVals[0]);
                           return rgrpNum;
                       }
                   }
               }
           }
           catch (Exception ex)
           {
               ErrorHandling_NTS.WriteErrorLog(ex.ToString());
           }
           return rgrpNum;
       }
           
    }
}
