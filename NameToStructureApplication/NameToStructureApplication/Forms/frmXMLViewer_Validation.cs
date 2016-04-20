
#region Import Assemblies

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

#endregion

namespace NameToStructureApplication
{
    public partial class frmXMLViewer_Validation : Form
    {
        #region Constructor

        public frmXMLViewer_Validation()
        {
            InitializeComponent();
        }

        #endregion

        private void frmXMLViewer_Validation_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }         

        private void btnBrowseXML_Click(object sender, EventArgs e)
        {
            try
            {                
                OpenFile();
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void btnSchema_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsWellFormedXml)
                {
                    ParseXMLFile();
                }
                else
                {
                    MessageBox.Show("Please validate Wellformedness before validating XSD","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string SelItem = null;
                int linN = 0;
                int colN = 0;
                SelItem = lstErrors.SelectedItem.ToString();

                if (!string.IsNullOrEmpty(SelItem))
                {

                    linN = Convert.ToInt16(Regex.Replace(SelItem, "([0-9]+): ([0-9]+)(.*)", "$1"));
                    colN = Convert.ToInt16(Regex.Replace(SelItem, "([0-9]+): ([0-9]+)(.*)", "$2"));


                    MatchCollection mc = default(MatchCollection);
                    int i = 0;
                    int totc = 0;

                    mc = Regex.Matches(RichTextBox1.Text, "\\n", RegexOptions.Singleline);

                    try
                    {
                        RichTextBox1.Select(mc[linN - 2].Index + colN, 2);
                        RichTextBox1.SelectionColor = Color.Blue;

                        RichTextBox1.Focus();
                    }
                    catch (Exception ex)
                    {
                        RichTextBox1.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void frmXMLViewer_Validation_Activated(object sender, EventArgs e)
        {
            RichTextBox1.Focus();
        }

        String strError = "";
        IXmlLineInfo lineInf = null;
        string xmlFileName = "";
        bool IsValidXmlFile = false;
        bool Changed = false;

        private void ParseXMLFile()
        {
            try
            {
                if (xmlFileName == null)
                {
                    MessageBox.Show("Please open an XML file for parsing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                this.Cursor = Cursors.WaitCursor;

                string strXSDPath =  AppDomain.CurrentDomain.BaseDirectory + "PatentEnhancedPrioritySubstanceIndexing-2.3.xsd";

                RichTextBox1.SaveFile(xmlFileName, RichTextBoxStreamType.PlainText);

                XmlTextReader xmlTxtReader = new XmlTextReader(xmlFileName);
                XmlValidatingReader xmlValReader = new XmlValidatingReader(xmlTxtReader);
                xmlValReader.ValidationType = ValidationType.Schema;
                xmlValReader.Schemas.Add(null, strXSDPath);
                strError = "";
                lstErrors.Items.Clear();

                xmlValReader.ValidationEventHandler += WriteErrorLog;

                IsValidXmlFile = true;
                do
                {
                    try
                    {
                        if (xmlValReader.Read())
                        {
                            lineInf = (IXmlLineInfo)xmlValReader;
                        }
                    }
                    catch (Exception exx)
                    {
                        try
                        {

                            IsValidXmlFile = false;

                            if (lineInf.HasLineInfo())
                            {
                                strError = lineInf.LineNumber.ToString() + ": " + lineInf.LinePosition.ToString() + " " + exx.Message;
                            }

                            if (exx.Message.IndexOf("EndElement") > 1)
                            {
                                break; 
                            }
                            lstErrors.Items.Add(strError);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Some unexpected error occurred \r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break; 
                        }
                    }
                }
                while (!xmlTxtReader.EOF);

                xmlValReader.Close();
                xmlTxtReader.Close();

                Cursor = Cursors.Default;

                if (IsValidXmlFile == false)
                {
                    MessageBox.Show("File is not valid", "Invalid XML File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("File is validated with XSD successfully", "Valid XML File", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void OpenFile()
        {
            try
            {

                openFileDialog1.Filter = "XML Files (*.xml)|*.xml|Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                openFileDialog1.FilterIndex = 1;
                openFileDialog1.Title = "Select a file to open";
                openFileDialog1.FileName = "";
                openFileDialog1.ShowDialog();

                if (openFileDialog1.FileName != "")
                {

                    xmlFileName = openFileDialog1.FileName;

                    txtXmlFile.Text = xmlFileName.Trim();

                    RichTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                    this.Text = "Xml Editor | " + xmlFileName.Substring(xmlFileName.LastIndexOf("\\") + 1);

                }

                Changed = false;
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }
               
        private void WriteErrorLog(object sender, ValidationEventArgs args)
        {

            try
            {
                IsValidXmlFile = false;
                strError = lineInf.LineNumber.ToString() + ": " + lineInf.LinePosition.ToString() + " " + args.Message;

                lstErrors.Items.Add(strError);
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (TabControl1.SelectedIndex == 1)
                {
                    RichTextBox1.SaveFile(xmlFileName, RichTextBoxStreamType.PlainText);
                    webBrowser1.Navigate(xmlFileName);
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void RichTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Point LocationCombo = new Point();


            if (e.KeyChar == (char)'<')
            {
                LocationCombo = RichTextBox1.GetPositionFromCharIndex(RichTextBox1.SelectionStart);
                LocationCombo.Y = LocationCombo.Y + RichTextBox1.Font.Height + 3;
                ComboBox1.Location = LocationCombo;
                ComboBox1.Visible = true;
                ComboBox1.DroppedDown = true;
                ComboBox1.Focus();
            }
        }
                
        private void WriteXMLUsingXSD()
        {
            try
            {
                patentInfo pinfo = new patentInfo();
                pinfo.tan = "12345678D";
                pinfo.language = languageType.en;

                patentLocation ploc = new patentLocation();
                ploc.pageLabel = "00";
                ploc.pageNumber = "5";
                ploc.exampleLabel = "00";

                name[] nm = new name[1];

                name nm1 = new name();
                nm1.lang = languageType.en;

                nm[0] = nm1;

                string[] strIUpacName = {"Benzene"};

                nameType nType = new nameType();
                nType.Text = strIUpacName;

                names nms = new names();
                nms.IUPACName = nType;
                nms.name = nm;
                
                string strMol = @"OS0oMy1BY2V0eWwtNC1mbHVvcm9waGVueWwpLTYtY2hsb3JvcHVyaW5lCiAgTWFydmluICAwNDI0MTAxNzA5Mk";
                byte[] br = System.Text.ASCIIEncoding.ASCII.GetBytes(strMol);

                structureDataType sDtype = new structureDataType();
                sDtype.type = structureDataTypeType.MDLMolfileV2000;
                sDtype.encoding = structureDataTypeEncoding.Base64;
                sDtype.Value = br;

                propheticSubstance ps11 = new propheticSubstance();
                ps11.structureData = sDtype;
                ps11.structureData = sDtype;
                ps11.patentLocation = ploc;
                ps11.names = nms;

                propheticSubstance[] ps1 = new propheticSubstance[1];
                ps1[0] = ps11;

                propheticSubstances ps = new propheticSubstances();
                ps.propheticSubstance = ps1;

                patent pr = new patent();              
                pr.patentInfo = pinfo;
                pr.propheticSubstances = ps;
               
             
                // Serialization
                XmlSerializer s = new XmlSerializer(typeof(patent));
                TextWriter w = new StreamWriter(@"c:\list12345.xml");
                s.Serialize(w, pr);
                w.Close();
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        bool IsWellFormedXml = false;
        private void btnWellFormNess_Click(object sender, EventArgs e)
        {
            try
            {
                lstErrors.Items.Clear();

                RichTextBox1.SaveFile(xmlFileName, RichTextBoxStreamType.PlainText);

                IsWellFormedXml = true;

                using (FileStream stream = File.OpenRead(AppDomain.CurrentDomain.BaseDirectory + "PatentEnhancedPrioritySubstanceIndexing-2.3.xsd"))
                {
                    XmlReaderSettings settings = new XmlReaderSettings();

                    XmlSchema schema = XmlSchema.Read(stream, OnXmlSyntaxError);
                    settings.ValidationType = ValidationType.Schema;
                    settings.Schemas.Add(schema);
                    settings.ValidationEventHandler += OnXmlSyntaxError;

                    string strError = "";
                    using (XmlReader validator = XmlReader.Create(txtXmlFile.Text.Trim(), settings))
                    {
                        try
                        {
                            // Validate the entire xml file
                            while (validator.Read())
                            {
                                lineInf = (IXmlLineInfo)validator;
                            }
                        }
                        catch (Exception ex)
                        {
                            if (lineInf.HasLineInfo())
                            {
                                strError = lineInf.LineNumber.ToString() + ": " + lineInf.LinePosition.ToString() + " " + ex.Message;
                            }
                            lstErrors.Items.Add(strError);
                        }
                    }
                }
                if (IsWellFormedXml)
                {
                    MessageBox.Show("Wellformed XML","Wellformed",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }                
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void OnXmlSyntaxError(object sender, ValidationEventArgs args)
        {
            try
            {
                IsWellFormedXml = false;
                strError = lineInf.LineNumber.ToString() + ": " + lineInf.LinePosition.ToString() + " " + args.Message;
                lstErrors.Items.Add(strError);
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }
    }
}
