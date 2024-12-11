using GenericParsing;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CSVPreview
{
    public partial class CSVPreview : Form
    {
        string filename = "";
        bool ShowMenuStrip = false;
        int ColumnIndex = -1;
        public CSVPreview(string filename)
        {
            InitializeComponent();
            this.filename = filename;
            this.Text = this.Text + " " + filename;
            //this.dataGridView1.DataSource = ReadFile();
        }

        internal DataTable ReadFile()
        {
            GenericParserAdapter parser = new GenericParserAdapter(this.filename);
            parser.ColumnDelimiter = GetColumnDelimiter(); 
            parser.FirstRowHasHeader = this.chkFirstRowHasHeader.Checked;
            parser.SkipStartingDataRows = (int)Math.Round(this.txtSkipFirstRows.Value);
            parser.MaxBufferSize = 4096;
            parser.MaxRows = GetMaxRows();
            parser.TextQualifier = GetTextQualifier();

            DataTable dt = parser.GetDataTable();
            return dt; // DataTable();
        }

        private void EnumerateRows()
        {
            int rowNumber = 1 + (int)Math.Round(this.txtSkipFirstRows.Value);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                row.HeaderCell.Value = rowNumber.ToString();
                rowNumber = rowNumber + 1;
            }
            dataGridView1.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
        }
        private int GetMaxRows()
        {
            int maxRows = 0;
            if (IsNumeric(this.cmbPreviewRows.Text))
                maxRows = int.Parse(this.cmbPreviewRows.Text);
            return maxRows;
        }
        private char? GetColumnDelimiter()
        {
            string delimiter = this.cmbColumnDelimiter.Text;
            delimiter = delimiter.Trim();
            if(delimiter.Length > 1) //if 1 char, then user entered a single char else means user selected delimiter from list
            {
                delimiter= delimiter.Remove(delimiter.IndexOf('}')).Substring(delimiter.IndexOf('{') + 1);
            }

            
            if (delimiter.Length > 0)
            {
                char? chardelimiter = string.IsNullOrEmpty(delimiter) ? (char?)',' : delimiter[0];
                if (chardelimiter == (char?)'t' || chardelimiter == (char?)'T')
                {
                    chardelimiter = '\t';
                }
                return chardelimiter;
            }
            else
            {
                return ",".ToCharArray()[0];
            }
        }
        private char? GetTextQualifier()
        {
            char? TextQualifier = this.txtTextQualifier.Text.Trim().ToCharArray()[0];
            if (TextQualifier.HasValue)
            {
                if (TextQualifier == (char?)'t' || TextQualifier == (char?)'T')
                {
                    TextQualifier = '\t';
                }
                return TextQualifier;
            }
            else
            {
                return '\"';
            }
        }


        private void CSVPreview_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.dataGridView1.DataSource = ReadFile();
            EnumerateRows();
            this.Cursor = Cursors.Default;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Application.DoEvents();
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = ReadFile();
            EnumerateRows();
            this.Cursor = Cursors.Default;
        }
        public bool IsNumeric(string value)
        {
            return value.All(char.IsNumber);
        }





        private void analizeColumnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AnalizeColumn ac = new AnalizeColumn(ColumnIndex, this.dataGridView1.DataSource as DataTable);
            //ac.Parent = this;
            ac.Show(this);
        }

        private void dataGridView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            DataGridView.HitTestInfo hit = this.dataGridView1.HitTest(e.X, e.Y);
            ColumnIndex = hit.ColumnIndex;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if(ColumnIndex<0) e.Cancel = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search search = new Search(this.dataGridView1.DataSource as DataTable);
            search.StartPosition = FormStartPosition.Manual;
            search.Location = new Point(this.Location.X + this.Width - search.Width - 30, this.Location.Y  + 70)   ;
            if(search.ShowDialog() == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
                string WhereToSearch = search.cmbArea.SelectedItem.ToString();
                string SearchValue = search.txtSearchFor.Text.Trim();
                if (WhereToSearch.Equals("Everywhere")) 
                    SearchEverywhere(SearchValue);
                else
                    SearchColumn(WhereToSearch, SearchValue);

                this.Cursor = Cursors.Default;
            }
        }

        private void SearchColumn(string whereToSearch, string SearchValue)
        {
            DataGridViewSelectionMode dataGridViewSelectionMode = this.dataGridView1.SelectionMode;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                        if (row.Cells[whereToSearch].Value.ToString().Contains(SearchValue))
                        {
                            row.Selected = true;
                            continue;
                        }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            dataGridView1.SelectionMode = dataGridViewSelectionMode;
        }

        private void SearchEverywhere(string SearchValue)
        {
            DataGridViewSelectionMode dataGridViewSelectionMode = this.dataGridView1.SelectionMode;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value.ToString().Contains(SearchValue))
                        {
                            row.Selected = true;
                            continue;
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            dataGridView1.SelectionMode = dataGridViewSelectionMode;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if(this.dataGridView1.DataSource == null) return;
            string fileName = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".xlsx";
            using (ExcelPackage pck = new ExcelPackage(fileName))
            {
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("DATA");
                ws.Cells["A1"].LoadFromDataTable(this.dataGridView1.DataSource as DataTable, true);
                pck.Save();
            }
            System.Diagnostics.Process.Start(fileName); 
        }
    }
}
