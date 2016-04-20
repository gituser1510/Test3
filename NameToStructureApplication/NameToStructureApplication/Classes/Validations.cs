#region Import Assemblies

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Schema;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Data;

#endregion

namespace NameToStructureApplication
{
    public static class Validations
    {
        static string strErrMSg = "";

        static bool blValidateFail = false;

        public static bool IsValidTanNumber(string tanNumString)
        {
            bool blStatus = false;
            try
            {
                Regex regExp = new Regex("[0-9]{8}[A-Z]{1}$", RegexOptions.Singleline);
                MatchCollection matchColl = regExp.Matches(tanNumString);
                
                if (matchColl.Count > 0)
                {
                    blStatus = true;
                }
                else
                {
                    blStatus = false;
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
            return blStatus;
        }

        public static string RemoveSMILESFromIUPACName(string iupacname)
        {
            string strIUPACName = iupacname;
            try
            {
                if (iupacname.Trim() != "")
                {
                    string[] strSplitter = { " " };
                    string[] strSplitVals = iupacname.Split(strSplitter, StringSplitOptions.RemoveEmptyEntries);
                    if (strSplitVals != null)
                    {
                        if (strSplitVals.Length > 1)
                        {
                            
                            //strIUPACName = strSplitVals[1].Trim();
                            //return strIUPACName;

                            strSplitVals[0] = "";
                            strIUPACName = String.Join(" ", strSplitVals);
                            return strIUPACName.Trim();
                        }
                        else if (strSplitVals.Length == 1)
                        {
                            strIUPACName = String.Join(" ", strSplitVals);
                            return strIUPACName.Trim();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
            return strIUPACName;
        }

        public static string GetConvertedIUPACName(string iupacname)
        {
            string strIUPACName = "";
            try
            {
                if (iupacname.Trim() != "")
                {
                    int intHashCode = 0;
                    foreach (Char c in iupacname.Trim())
                    {
                       intHashCode = c.GetHashCode();
                       switch (intHashCode)
                       { 
                           case 913:

                               strIUPACName = strIUPACName + ".alpha.";
                               break;

                           case 914:

                               strIUPACName = strIUPACName + ".beta.";
                               break;

                           case 915:

                               strIUPACName = strIUPACName + ".gamma.";
                               break;

                           case 916:

                               strIUPACName = strIUPACName + ".delta.";
                               break;

                           case 917:

                               strIUPACName = strIUPACName + ".epsilon.";
                               break;

                           default:
                               strIUPACName = strIUPACName + c;
                               break;
                       }
                    }
                    return strIUPACName;                    
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
            return strIUPACName;
        }
        
        public static bool ValidateXmlAgainstSchema(string xmlFilename, string schemaFilename, out string errmsg)
        {
            bool blStatus = false;
            XmlValidatingReader validator = null;
            try
            {
                XmlTextReader xmlTRdr = new XmlTextReader(xmlFilename);
                validator = new XmlValidatingReader(xmlTRdr);
                validator.ValidationType = ValidationType.Schema;

                XmlSchemaCollection xmlSchColl = new XmlSchemaCollection();
                xmlSchColl.Add(null, schemaFilename);
                validator.Schemas.Add(xmlSchColl);

                blValidateFail = false;

                validator.ValidationEventHandler += new ValidationEventHandler(ValidationEventHandler);
                
                while (validator.Read())
                {
                    if (blValidateFail)
                    {
                        break;
                    }
                }
                if (blValidateFail)
                {
                    blStatus = false;
                }
                else
                {
                    blStatus = true;
                }
            }
            catch (XmlException ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
            finally
            {
                validator.Close();
            }
            errmsg = strErrMSg;
            return blStatus;
        }

        private static void ValidationEventHandler(object sender, ValidationEventArgs args)
        {
            try
            {
                blValidateFail = true;
                strErrMSg = "Validation error: " + args.Message;
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        public static string GetInchiKeyFromInchiString(string inchistring)
        {
            string strInchikey = "";
            try
            {
                if (inchistring.Trim() != "")
                {
                    string[] splitter = { "InChIKey=" };
                    string[] strInchiArr = inchistring.Trim().Split(splitter, StringSplitOptions.RemoveEmptyEntries);
                    if (strInchiArr != null)
                    {
                        if (strInchiArr.Length == 2)
                        {
                            strInchikey = strInchiArr[1];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
            return strInchikey;
        }

        public static ArrayList GetArrayListFromDataTable(DataTable _dtTanIds,int colindex)
        {
            try
            {
                if (_dtTanIds != null)
                {
                    ArrayList lstTANIds = new ArrayList();
                    if (_dtTanIds.Rows.Count > 0)
                    {
                        for (int i = 0; i < _dtTanIds.Rows.Count; i++)
                        {
                            if (!lstTANIds.Contains(_dtTanIds.Rows[i][colindex].ToString()))
                            {
                                lstTANIds.Add(_dtTanIds.Rows[i][colindex].ToString());
                            }
                        }
                    }
                    return lstTANIds;
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
            return null;
        }

        public static bool ValidateSMILESforRadicalPosition(string _smiles)
        {
            bool blStatus = false;
            try
            {
                if (_smiles.Trim() != "")
                {
                    Regex RE = new Regex("\\[[^\\[\\]]+\\]", RegexOptions.Singleline);
                    MatchCollection theMatches = RE.Matches(_smiles);
                    if (theMatches.Count >= 1)
                    {
                        blStatus = true;
                    }
                }
                return blStatus;
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
            return blStatus;
        }

        public static bool ValidateOpenningAndClosingBrackets(string _smiles)
        {
            bool blStatus = false;
            try
            {
                if (_smiles.Trim() != "")
                {
                    var cnt_open = _smiles.Count(c => c == '[');
                    var cnt_close = _smiles.Count(c => c == ']');
                    if (cnt_open == cnt_close)
                    {
                        blStatus = true;
                    }
                    return blStatus;
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
