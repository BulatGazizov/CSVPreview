using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSVPreview
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                if(System.IO.File.Exists(args[0]))
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new CSVPreview(args[0]));
                }
                else
                {
                    MessageBox.Show("File not found: " + args[0], "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.DefaultExt = "*.csv";
                openFileDialog.FileName = "";
                openFileDialog.Filter = "CSV files|*.csv|All files|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new CSVPreview(openFileDialog.FileName));
                }
                else
                {
                    MessageBox.Show("No file specified", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                openFileDialog.Dispose();
            }
        }
    }
}
