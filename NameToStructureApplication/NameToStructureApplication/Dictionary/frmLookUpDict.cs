using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NameToStructureApplication.Dictionary
{
    public partial class frmLookUpDict : Form
    {
        public frmLookUpDict()
        {
            InitializeComponent();
        }

        private DataTable _dtDictTbl = null;
        public DataTable DictTable
        {
            get
            {
                return _dtDictTbl;
            }
            set
            {
                _dtDictTbl = value;
            }
        }

        private void frmLookUpDict_Load(object sender, EventArgs e)
        {
            try
            {
              DataTable dtDict = PepsiLiteDataAccess.DataOperations.GetAllDictionaryEntries();
              if (dtDict != null)
              {
                  if (dtDict.Rows.Count > 0)
                  {
                      DictTable = dtDict;
                      dtGridDict.DataSource = dtDict;
                  }
              }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void dtGridDict_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                //store a string representation of the row number in 'strRowNumber'
                string strRowNumber = (e.RowIndex + 1).ToString();

                //prepend leading zeros to the string if necessary to improve
                //appearance. For example, if there are ten rows in the grid,
                //row seven will be numbered as "07" instead of "7". Similarly, if 
                //there are 100 rows in the grid, row seven will be numbered as "007".
                while (strRowNumber.Length < dtGridDict.RowCount.ToString().Length) strRowNumber = "0" + strRowNumber;

                //determine the display size of the row number string using
                //the DataGridView's current font.
                SizeF size = e.Graphics.MeasureString(strRowNumber, dtGridDict.Font);

                //adjust the width of the column that contains the row header cells 
                //if necessary
                if (dtGridDict.RowHeadersWidth < (int)(size.Width + 20)) dtGridDict.RowHeadersWidth = (int)(size.Width + 20);

                //this brush will be used to draw the row number string on the
                //row header cell using the system's current ControlText color
                Brush b = SystemBrushes.ControlText;

                //draw the row number string on the current row header cell using
                //the brush defined above and the DataGridView's default font
                e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }

        private void txyCompName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txyCompName.Text.Trim() != "")
                {
                    if (_dtDictTbl != null)
                    {
                        if (_dtDictTbl.Rows.Count > 0)
                        {
                            DataView dtView = new DataView(_dtDictTbl);
                            dtView.RowFilter = "Compound LIKE '" + txyCompName.Text.Trim() + "*'";
                            dtGridDict.DataSource = dtView;
                        }
                    }
                }
                else
                {
                    dtGridDict.DataSource = _dtDictTbl;
                }
            }
            catch (Exception ex)
            {
                PepsiLiteErrorHandling.WriteErrorLog(ex.ToString());
            }
        }
    }
}
