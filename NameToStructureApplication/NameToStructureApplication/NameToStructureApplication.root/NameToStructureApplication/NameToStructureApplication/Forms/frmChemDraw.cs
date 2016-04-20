#region Import Assemblies

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

#endregion

namespace NameToStructureApplication
{
    public partial class frmChemOpts : Form
    {
        #region Constructor

        public frmChemOpts()
        {
            InitializeComponent();
        } 

        #endregion

        #region Property Procedures

        private string _openeyemol = "";
        public string OpenEyeMol
        {
            get
            {
                return _openeyemol;
            }
            set
            {
                _openeyemol = value;
            }
        }

        private string _chemdrawmol = "";
        public string ChemDrawMol
        {
            get
            {
                return _chemdrawmol;
            }
            set
            {
                _chemdrawmol = value;
            }
        }

        private string _chemaxonmol = "";
        public string ChemAxonMol
        {
            get
            {
                return _chemaxonmol;
            }
            set
            {
                _chemaxonmol = value;
            }
        }

        private string _error_openeye = "";
        public string Error_OpenEye
        {
            get
            {
                return _error_openeye;
            }
            set
            {
                _error_openeye = value;
            }
        }

        private string _error_chemdraw = "";
        public string Error_ChemDraw
        {
            get
            {
                return _error_chemdraw;
            }
            set
            {
                _error_chemdraw = value;
            }
        }

        private string _error_chemaxon = "";
        public string Error_ChemAxon
        {
            get
            {
                return _error_chemaxon;
            }
            set
            {
                _error_chemaxon = value;
            }
        }

        private string _selectedmol = "";
        public string SelectedMol
        {
            get
            {
                return _selectedmol;
            }
            set
            {
                _selectedmol = value;
            }
        }
        
        #endregion

        private void AssignMolsToControls()
        {
            try
            {
                if (OpenEyeMol.Trim() != "")
                {
                    txtError_OpenEye.Visible = false;
                    renditor_OpenEye.MolfileString = OpenEyeMol;
                }
                else
                {
                    txtError_OpenEye.Visible = true;
                    txtError_OpenEye.Text = Error_OpenEye;
                }

                if (ChemDrawMol.Trim() != "")
                {
                    txtError_ChemDraw.Visible = false;
                    renditor_ChemDraw.MolfileString = ChemDrawMol;
                }
                else
                {
                    txtError_ChemDraw.Visible = true;
                    txtError_ChemDraw.Text = Error_ChemDraw;
                }

                if (ChemAxonMol.Trim() != "")
                {
                    txtError_ChemAxon.Visible = false;
                    renditor_ChemAxon.MolfileString = ChemAxonMol;
                }
                else
                {
                    txtError_ChemAxon.Visible = true;
                    txtError_ChemAxon.Text = Error_ChemAxon;
                }
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
        }

        private void frmChemDraw_Load(object sender, EventArgs e)
        {
            try
            {
                AssignMolsToControls();
            }
            catch (Exception ex)
            {
                ErrorHandling_NTS.WriteErrorLog(ex.ToString());
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbnOpenEye.Checked)
                {
                    if (renditor_OpenEye.MolfileString != null)
                    {
                        SelectedMol = renditor_OpenEye.MolfileString;                      
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No Molecule in the OpenEye");
                    }
                }
                else if (rbnChemDraw.Checked)
                {
                    if (renditor_ChemDraw.MolfileString != null)
                    {
                        SelectedMol = renditor_ChemDraw.MolfileString;                        
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No Molecule in the ChemDraw");
                    }
                }
                else if (rbnChemAxon.Checked)
                {
                    if (renditor_ChemAxon.MolfileString != null)
                    {
                        SelectedMol = renditor_ChemAxon.MolfileString;                        
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No Molecule in the ChemAxon");
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
