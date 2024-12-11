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
    public partial class Search : Form
    {
        DataTable _dt;
        public Search(DataTable dt)
        {
            InitializeComponent();
            _dt = dt;
        }

        private void Search_Load(object sender, EventArgs e)
        {
            this.cmbArea.Items.Clear();
            this.cmbArea.Items.Add("Everywhere");
            this.cmbArea.Items.AddRange(_dt.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray());
            this.cmbArea.SelectedIndex = 0;


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(txtSearchFor.Text.Length == 0) 
            {
                txtSearchFor.BackColor = Color.Red;
                return;
            }
            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtSearchFor_Enter(object sender, EventArgs e)
        {
            txtSearchFor.BackColor = SystemColors.Window;
        }
    }
}
