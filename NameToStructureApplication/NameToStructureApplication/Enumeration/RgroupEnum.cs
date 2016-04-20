#region Import Assemblies

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
using NameToStructureApplication.Classes;
using chemaxon.reaction;

#endregion

namespace NameToStructureApplication.Enumeration
{
   public static class RgroupEnum
    {
       static ChemDrawControl8.ChemDrawCtlClass chemclass = new ChemDrawControl8.ChemDrawCtlClass();
       //static Standardizer objStnd = new Standardizer(new File(@"C:\Documents and Settings\sairam.punyamantula\Desktop\stand.xml"));

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
               PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
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
               PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
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
                                       strSMILES = PepsiLiteDataAccess.DataOperations.GetDictSmilesOnCompName(dtSmiles.Rows[rowindex][colindex].ToString());
                                       if (strSMILES.Trim() == "")
                                       {
                                           strSMILES = objStruct.ToString();
                                       }                                       
                                   }
                                   else
                                   {
                                       strSMILES = PepsiLiteDataAccess.DataOperations.GetDictSmilesOnCompName(dtSmiles.Rows[rowindex][colindex].ToString());
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
               PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
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
                                   //molEnum = AddRGrpMolToCoreMolecule(rgMol, rCoreMol, rgrpNum);
                                  AddRGrpMolToCoreMolecule(ref rCoreMol, rgMol, rgrpNum);
                               }
                               //Set Radical Empty to Result Mol
                               SetRadicalEmptyToResultMol(ref rCoreMol);

                               mHand_Result = new MolHandler(rCoreMol);
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
               PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
           }
           return dtEnumResData;
       }

       private static void SetRadicalEmptyToResultMol(ref Molecule _enumResMol)
       {
           try
           {
               for (int i = 0; i < _enumResMol.getAtomCount(); i++)
               {
                   if (_enumResMol.getAtom(i).getRadical() > 0)
                   {
                       _enumResMol.getAtom(i).setRadical(MolAtom.EMPTY);
                   }
               }
           }
           catch (Exception ex)
           {
               PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
           }
       }

       public static RgMolecule ReturnRGroupMolecule(string _rgrpSmiles,int _rgrpNum)
       {
           RgMolecule rgMol = null;
           try
           {
               if (_rgrpSmiles != "")
               {
                   MolHandler mHandler = new MolHandler(_rgrpSmiles);
                   Molecule objSmileMol = mHandler.getMolecule();
                   rgMol = new RgMolecule();

                   MolAtom mAtom = new MolAtom(MolAtom.RGROUP, 1, 0, 0);
                   mAtom.setRgroup(_rgrpNum);
                   rgMol.add(mAtom);

                   int radNum = 0;
                   for (int i = 0; i < objSmileMol.getAtomCount(); i++)
                   {
                       if (objSmileMol.getAtom(i).getRadical() > 0) //objSmileMol.getRadical(i) 
                       {
                           radNum = i;
                           break;                           
                       }                       
                   }

                   for (int i = 0; i < objSmileMol.getAtomCount(); i++)
                   {
                       if (i == radNum)
                       {
                           objSmileMol.getAtom(i).setRadical(MolAtom.RAD_OFF);
                       }
                       rgMol.add(objSmileMol.getAtom(i));
                   }


                   for (int j = 0; j < objSmileMol.getBondCount(); j++)
                   {
                       rgMol.add(objSmileMol.getBond(j));
                   }
                   rgMol.add(new MolBond(objSmileMol.getAtom(radNum), mAtom));
                   rgMol.clean(2, null, null);                  

                   return rgMol;
               }
           }
           catch (Exception ex)
           {
               PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
           }
           return rgMol;
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
               AddRGrpMolToCoreMol(ref _coreMol, _rgMol, radPos);

               _coreMol.add(new MolBond(_coreMol.getAtom(rgrpPos).getBond(0).getAtom1(), _rgMol.getAtom(radPos)));
               
               _coreMol.removeNode(_coreMol.getNode(rgrpPos), CGraph.RMCLEANUP_ALL);
               _coreMol.clean(2, null, null);

               rgrpPos = GetRGroupPosition(_coreMol, _rgrpNum);

               _coreMol.removeNode(_coreMol.getNode(rgrpPos), CGraph.RMCLEANUP_ALL);
               _coreMol.clean(2, null, null);               

               //chemaxon.reaction.Standardizer stnd = new chemaxon.reaction.Standardizer("removeexplicitH:radical");
               //Molecule molCore = stnd.standardize(_coreMol);             

               //Standardize the molecule
               Standardizer objStnd = new Standardizer(new File(@"C:\Documents and Settings\sairam.punyamantula\Desktop\stand.xml"));
               Molecule molCore = objStnd.standardize(_coreMol);            

               molCore.clean(2, null, null);          

               return molCore;
           }
           catch (Exception ex)
           {
               PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
           }
           return null;
       }

       public static void AddRGrpMolToCoreMolecule(ref Molecule _coreMol, RgMolecule _rgMol,int _rgrpNum)
       {
           try
           {
               //Get RGroup position
               int rgrpPos = GetRGroupPosition(_coreMol, _rgrpNum);

               //Get Radical position
               int radPos = GetRadicalPosition(_rgMol);

               //Add Rgroup Molecule to Core Molecule
               AddRGrpMolToCoreMol(ref _coreMol, _rgMol, radPos);

               _coreMol.add(new MolBond(_coreMol.getAtom(rgrpPos).getBond(0).getAtom1(), _rgMol.getAtom(radPos)));

               _coreMol.removeNode(_coreMol.getNode(rgrpPos), CGraph.RMCLEANUP_ALL);
               _coreMol.clean(2, null, null);

               rgrpPos = GetRGroupPosition(_coreMol, _rgrpNum);

               _coreMol.removeNode(_coreMol.getNode(rgrpPos), CGraph.RMCLEANUP_ALL);
               _coreMol.clean(2, null, null);
               
               //chemaxon.reaction.Standardizer stnd = new chemaxon.reaction.Standardizer("removeexplicitH:radical");
               //Molecule molCore = stnd.standardize(_coreMol);  

               ////Standardize the molecule
               //Standardizer objStnd = new Standardizer(new File(@"C:\Documents and Settings\sairam.punyamantula\Desktop\stand.xml"));
               //Molecule molCore = objStnd.standardize(_coreMol);

               _coreMol.clean(2, null, null);              
           }
           catch (Exception ex)
           {
               PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
           }           
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
                       return rgroupPos;
                   }
               }
           }
           catch (Exception ex)
           {
               PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
           }
           return rgroupPos;
       }

       private static int GetRadicalPosition(RgMolecule _rgMol)
       {
           int radPos = 0;
           try
           {
               if (_rgMol != null)
               {
                   for (int k = 0; k < _rgMol.getAtomCount(); k++)
                   {
                       if (_rgMol.getAtom(k).getRadical() > 0)
                       {
                           radPos = k;
                           return radPos;
                       }
                   }
               }
           }
           catch (Exception ex)
           {
               PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
           }
           return radPos;
       }

       private static void AddRGrpMolToCoreMol(ref Molecule _coreMol, RgMolecule _rgMol,int _radicalpos)
       {
           try
           {
               for (int aIndx = 0; aIndx < _rgMol.getAtomCount(); aIndx++)
               {
                   if (aIndx == _radicalpos)
                   {
                       _rgMol.getAtom(aIndx).setRadical(MolAtom.RAD_OFF);
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
               PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
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
               PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
           }
           return rgrpNum;
       }
           
    }
}
