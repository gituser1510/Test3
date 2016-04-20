#region Import Assemblies

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

#endregion

namespace NameToStructureApplication.Export
{
    public partial class frmExportOpts : Form
    {
        #region Constructor

        public frmExportOpts()
        {
            InitializeComponent();
        } 

        #endregion

        #region Property Procedures

        private ArrayList _availprops = null;
        public ArrayList AvailProps
        {
            get
            {
                return _availprops;
            }
            set
            {
                _availprops = value;
            }
        }

        private ArrayList _selectedprops = null;
        public ArrayList SelectedProps
        {
            get
            {
                return _selectedprops;
            }
            set
            {
                _selectedprops = value;
            }
        }
        
        private string _folderpath = "";
        public string FolderPath
        {
            get
            {
                return _folderpath;
            }
            set
            {
                _folderpath = value;
            }
        }

        #endregion

        #region Public Variables

        ArrayList availList = new ArrayList();
        ArrayList selList = new ArrayList();

        #endregion

        private void frmExportOpts_Load(object sender, EventArgs e)
        {
            try
            {
                if (AvailProps != null)
                {
                    if (AvailProps.Count > 0)
                    {
                        for (int i = 0; i < AvailProps.Count; i++)
                        {
                            lstAvailProp.Items.Add(AvailProps[i].ToString());
                        }

                        availList = AvailProps;
                        selList.Add("Structure");

                        lstSelProp.Items.Add("Structure");
                    }
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }
        
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFolderPath.Text != "")
                {
                    FolderPath = txtFolderPath.Text;
                    SelectedProps = selList;                  

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please specify the path");
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }
        
        private void AddItem(string itemname)
        {
            try
            {
                selList.Add(itemname);
                availList.Remove(itemname);
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void DeleteItem(string itemname)
        {
            try
            {
                availList.Add(itemname);
                selList.Remove(itemname);
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void btnSelOne_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstAvailProp.Items.Count > 0)
                {
                    if (lstAvailProp.SelectedItem != null)
                    {
                        if (lstAvailProp.SelectedItem.ToString() != "Structure")
                        {
                            AddItem(lstAvailProp.SelectedItem.ToString());

                            lstAvailProp.DataSource = null;
                            lstAvailProp.DataSource = availList;
                            lstSelProp.DataSource = null;
                            lstSelProp.DataSource = selList;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void btnSelAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstAvailProp.Items.Count > 0)
                {
                    for (int i = 0; i < lstAvailProp.Items.Count; i++)
                    {
                        if (lstAvailProp.Items[i].ToString() != "Structure")
                        {
                            AddItem(lstAvailProp.Items[i].ToString());
                        }
                    }

                    lstAvailProp.DataSource = null;
                    lstAvailProp.DataSource = availList;
                    lstSelProp.DataSource = null;
                    lstSelProp.DataSource = selList;
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void btnRemOne_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstSelProp.SelectedItem != null)
                {
                    if (lstSelProp.SelectedItem.ToString() != "Structure")
                    {
                        DeleteItem(lstSelProp.SelectedItem.ToString());

                        lstAvailProp.DataSource = null;
                        lstAvailProp.DataSource = availList;
                        lstSelProp.DataSource = null;
                        lstSelProp.DataSource = selList;
                    }
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void btnRemAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstSelProp.Items.Count > 0)
                {
                    for (int i = 0; i < lstSelProp.Items.Count; i++)
                    {
                        if (lstSelProp.Items[i].ToString() != "Structure")
                        {
                            DeleteItem(lstSelProp.Items[i].ToString());
                        }
                    }
                    lstAvailProp.DataSource = null;
                    lstAvailProp.DataSource = availList;
                    lstSelProp.DataSource = null;
                    lstSelProp.DataSource = selList;
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {               
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {                    
                    txtFolderPath.Text = folderBrowserDialog1.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }
    }
}
