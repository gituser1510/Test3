using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using java.io;
using chemaxon.formats;
using chemaxon.util;
using chemaxon.struc;

namespace NameToStructureApplication.Export
{
    public static class PepsiLite_Export
    {
        public static bool EmportToSdFile(string _filename,DataTable _dtTanDetails,ArrayList _selproplist)
        {
            bool blWriteStatus = false;
            try
            {
                if (_filename.Trim() != "" && _dtTanDetails != null)
                {
                    if (_dtTanDetails.Rows.Count > 0)
                    {
                        FileOutputStream fOutStream = new FileOutputStream(_filename, true);
                        MolExporter objmExporter = new MolExporter(fOutStream, "sdf");

                        MolHandler objmHandler = null;
                        Molecule objMol = null;

                        for (int rIndx = 0; rIndx < _dtTanDetails.Rows.Count; rIndx++)
                        {
                            objmHandler = new MolHandler(_dtTanDetails.Rows[rIndx]["structure"].ToString());
                            objMol = objmHandler.getMolecule();

                            if (_selproplist.Contains("Mol Weight"))
                            {
                                objMol.setProperty("Mol Weight", _dtTanDetails.Rows[rIndx]["mol_weight"].ToString());
                            }
                            if (_selproplist.Contains("Mol Formula"))
                            {
                                objMol.setProperty("Mol Formula", _dtTanDetails.Rows[rIndx]["mol_formula"].ToString());
                            }
                            if (_selproplist.Contains("Page Number"))
                            {
                                objMol.setProperty("Page Number", _dtTanDetails.Rows[rIndx]["page_number"].ToString());
                            }
                            if (_selproplist.Contains("Page Label"))
                            {
                                objMol.setProperty("Page Label", _dtTanDetails.Rows[rIndx]["page_label"].ToString());
                            }
                            if (_selproplist.Contains("Example Number"))
                            {
                                objMol.setProperty("Example Number", _dtTanDetails.Rows[rIndx]["example_number"].ToString());
                            }
                            if (_selproplist.Contains("Table Number"))
                            {
                                objMol.setProperty("Table Number", _dtTanDetails.Rows[rIndx]["table_number"].ToString());
                            }
                            if (_selproplist.Contains("en name"))
                            {
                                objMol.setProperty("en name", _dtTanDetails.Rows[rIndx]["en_name"].ToString());
                            }
                            if (_selproplist.Contains("IUPAC Name"))
                            {
                                objMol.setProperty("IUPAC Name", _dtTanDetails.Rows[rIndx]["iupac_name"].ToString());
                            }

                            objmExporter.write(objMol);
                        }

                        fOutStream.close();
                        objmExporter.close();

                        blWriteStatus = true;
                        return blWriteStatus;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
            return blWriteStatus;
        }
    }
}
