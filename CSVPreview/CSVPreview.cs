using GenericParsing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            parser.MaxRows = IsNumeric(this.cmbPreviewRows.Text) ? int.Parse(this.cmbPreviewRows.Text) : 100;
            parser.TextQualifier = GetTextQualifier();

            DataTable dt = parser.GetDataTable();
            return dt; // DataTable();
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
            this.dataGridView1.DataSource = ReadFile();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = ReadFile();
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
    }
}
