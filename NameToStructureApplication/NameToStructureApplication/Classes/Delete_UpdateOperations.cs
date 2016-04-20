using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using chemaxon.formats;
using java.io;
using chemaxon.struc;
using System.Windows.Forms;
using chemaxon.util;

namespace NameToStructureApplication.Classes
{
    public static class Delete_UpdateOperations
    {
        public static bool UpdateRecordInSdFile(string filename, int recindex, string molstring, string pagenum, string pagelabel, string examplenum, string iupacname, string enname)
        {
            bool blStatus = false;
            try
            {
                int intRecIndex = 0;

                MolInputStream molInStream = new MolInputStream(new FileInputStream(filename));
                MolImporter molImp = new MolImporter(molInStream);

                string strInputFilePath = System.IO.Path.GetDirectoryName(filename);

                string strExecPath = Application.StartupPath;
                string strFileName = System.IO.Path.GetFileName(filename);

                string strOutFile = strExecPath + "\\" + strFileName;

                DataOutputStream dOutStream = new DataOutputStream(new FileOutputStream(strOutFile));
                MolExporter mExpt = new MolExporter(dOutStream, "sdf");

                Molecule objMolecule = new Molecule();

                try
                {
                    while (molImp.read(objMolecule))
                    {
                        intRecIndex++;
                        if (intRecIndex == recindex)
                        {
                            MolHandler molHandler = new MolHandler(molstring);
                            Molecule molObj = molHandler.getMolecule();

                            objMolecule = molObj;

                            objMolecule.setProperty("Page Number", pagenum);
                            objMolecule.setProperty("Page Label", pagelabel);
                            objMolecule.setProperty("Example Number", examplenum);
                            objMolecule.setProperty("IUPAC Name", iupacname);
                            objMolecule.setProperty("en name", enname);

                            blStatus = true;
                        }
                        mExpt.write(objMolecule);
                    }

                    molImp.close();
                    molInStream.close();

                    mExpt.close();
                    dOutStream.close();

                    System.IO.File.Copy(strOutFile, filename, true);
                    System.IO.File.Delete(strOutFile);

                }
                catch (Exception ex)
                {
                    PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
                }
                finally
                {
                    molImp.close();
                    molInStream.close();

                    mExpt.close();
                    dOutStream.close();
                }

            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
            return blStatus;
        }

        public static bool DeleteRecordFromSDFile(string _infilename, int _recindex)
        {
            bool blStatus = false;
            try
            {
                int intRecIndex = 0;

                MolInputStream molInStream = new MolInputStream(new FileInputStream(_infilename));
                MolImporter molImp = new MolImporter(molInStream);

                string strInputFilePath = System.IO.Path.GetDirectoryName(_infilename);

                string strExecPath = Application.StartupPath;
                string strFileName = System.IO.Path.GetFileName(_infilename);

                string strOutFile = strExecPath + "\\" + strFileName;

                DataOutputStream dOutStream = new DataOutputStream(new FileOutputStream(strOutFile));
                MolExporter mExpt = new MolExporter(dOutStream, "sdf");

                Molecule objMol = new Molecule();

                while (molImp.read(objMol))
                {
                    intRecIndex++;
                    if (intRecIndex != _recindex)
                    {
                        mExpt.write(objMol);
                    }
                }

                molImp.close();
                molInStream.close();

                mExpt.close();
                dOutStream.close();

                System.IO.File.Copy(strOutFile, _infilename, true);
                System.IO.File.Delete(strOutFile);

                blStatus = true;

            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
            return blStatus;
        }
    }
}
