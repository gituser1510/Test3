using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace NameToStructureApplication.Forms
{
    public partial class frmSelectTAN_Xml : Form
    {
        public frmSelectTAN_Xml()
        {
            InitializeComponent();
        }

        #region Property Procedures

        private ArrayList _availtans = null;
        public ArrayList AvailTANs
        {
            get
            {
                return _availtans;
            }
            set
            {
                _availtans = value;
            }
        }

        private ArrayList _selectedtans = null;
        public ArrayList SelectedTANs
        {
            get
            {
                return _selectedtans;
            }
            set
            {
                _selectedtans = value;
            }
        }

        private string _foldername = "";
        public string FolderName
        {
            get
            {
                return _foldername;
            }
            set
            {
                _foldername = value;
            }
        }
        
        #endregion

        #region Public Variables

        ArrayList availList = new ArrayList();
        ArrayList selList = new ArrayList();

        #endregion

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
                if (lstAvailTANs.Items.Count > 0)
                {
                    if (lstAvailTANs.SelectedItem != null)
                    {
                        AddItem(lstAvailTANs.SelectedItem.ToString());

                        lstAvailTANs.DataSource = null;
                        lstAvailTANs.DataSource = availList;
                        lstSelTANs.DataSource = null;
                        lstSelTANs.DataSource = selList;
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
                if (lstAvailTANs.Items.Count > 0)
                {
                    for (int i = 0; i < lstAvailTANs.Items.Count; i++)
                    {
                        AddItem(lstAvailTANs.Items[i].ToString());
                    }
                    lstAvailTANs.DataSource = null;
                    lstAvailTANs.DataSource = availList;
                    lstSelTANs.DataSource = null;
                    lstSelTANs.DataSource = selList;
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
                if (lstSelTANs.SelectedItem != null)
                {
                    DeleteItem(lstSelTANs.SelectedItem.ToString());

                    lstAvailTANs.DataSource = null;
                    lstAvailTANs.DataSource = availList;
                    lstSelTANs.DataSource = null;
                    lstSelTANs.DataSource = selList;

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
                if (lstSelTANs.Items.Count > 0)
                {
                    for (int i = 0; i < lstSelTANs.Items.Count; i++)
                    {
                       DeleteItem(lstSelTANs.Items[i].ToString());                      
                    }
                    lstAvailTANs.DataSource = null;
                    lstAvailTANs.DataSource = availList;
                    lstSelTANs.DataSource = null;
                    lstSelTANs.DataSource = selList;
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void btnWriteXml_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstSelTANs.SelectedItems.Count > 0)
                {
                    if (txtFolderPath.Text.Trim() != "")
                    {                        
                        FolderName = txtFolderPath.Text.Trim();
                        SelectedTANs = selList;
                        
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please specify folder path");
                    }
                }
                else
                {
                    MessageBox.Show("Please select atleast one TAN");
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

        private void frmSelectTAN_Xml_Load(object sender, EventArgs e)
        {
            try
            {
                if (AvailTANs != null)
                {
                    if (AvailTANs.Count > 0)
                    {
                        for (int i = 0; i < AvailTANs.Count; i++)
                        {
                            lstAvailTANs.Items.Add(AvailTANs[i].ToString());
                        }

                        availList = AvailTANs;                    
                    }
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }
    }
}
