using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSVPreview
{
    public partial class AnalizeColumn : Form
    {
        private readonly int colIndex;
        private readonly DataTable dt;
        private readonly string colName;
        private string colType;
        dynamic[] arr;
        public AnalizeColumn(int ColIndex, DataTable dt)
        {
            InitializeComponent();
            colIndex = ColIndex;
            this.dt = dt;
            colName=dt.Columns[colIndex].ColumnName.ToString();
            this.Text = "Analize Column:" + colName;
        }

        private void AnalizeColumn_Load(object sender, EventArgs e)
        {
            this.txtColName.Text = colName;
            colType = GetColumnDataType();
            if (arr.Length < 1)
            {
                this.txtColType.Text = "No data to analize.";
                return;
            }
            else
                this.txtColType.Text = colType;

            switch (colType)
            {
                case "Integer":
                    int[] iresult = arr.Select(x => (int)Convert.ChangeType(x, typeof(int), CultureInfo.InvariantCulture)).ToArray();
                    this.txtMax.Text = iresult.Max().ToString();
                    this.txtMin.Text = iresult.Min().ToString();
                    break;
                case "Decimal":
                    decimal[] dresult = arr.Select(x => (decimal)Convert.ChangeType(x, typeof(decimal), CultureInfo.InvariantCulture)).ToArray();
                    this.txtMax.Text = dresult.Max().ToString();
                    this.txtMin.Text = dresult.Min().ToString();
                    break;
                case "Date":
                    DateTime[] dateresult = arr.Select(x => (DateTime)Convert.ChangeType(x, typeof(DateTime), CultureInfo.InvariantCulture)).ToArray();
                    this.txtMax.Text = dateresult.Max().ToString();
                    this.txtMin.Text = dateresult.Min().ToString();
                    break;
                default:
                    break;
            }
            //this.txtMax.Text = arr.Max<dynamic>();
                //dt.AsEnumerable().Select(r => r.Field<dynamic>(colName)).Max().ToString();
        }
        #region "Type"
        private string GetColumnDataType()
        {
            arr =dt.AsEnumerable().Select(r => r.Field<dynamic>(colName)).Where(e => e != null).Where(e => e != "").ToArray();
            if (isIntegerArray(arr))
                return "Integer";
            if (isNumericArray(arr))
                return "Decimal";
            if (isDateArray(arr))
                return "Date";
            return "Text";
        }

        private bool isDateArray(dynamic[] arr)
        {
            DateTime d=DateTime.Now;
            foreach (dynamic item in arr)
            {
                string sitem = item.ToString();
                if(!DateTime.TryParse(sitem,out d)) return false;
            }
            return true;
        }
        private bool isNumericArray(dynamic[] arr)
        {
            foreach (dynamic item in arr)
            {
                string sitem = item.ToString().Replace(".", "").Replace("-", "");
                if (!sitem.All(char.IsNumber)) return false;
            }
            return true;
        }

        private bool isIntegerArray(dynamic[] arr)
        {
            foreach (dynamic item in arr)
            {
                string sitem = item.ToString().Replace("-", "");
                if (!sitem.All(char.IsNumber)) return false;
            }
            return true;
        }
        #endregion
    }
}
