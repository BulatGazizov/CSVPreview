using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uninstall
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("UnInstalling CSVPreview...");
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            path = System.IO.Path.GetDirectoryName(path);
            //string destination = Environment.ExpandEnvironmentVariables(@"%LOCALAPPDATA%") + @"\CSVPreview";
            string destination = Environment.ExpandEnvironmentVariables(@"%APPDATA%") + @"\CSVPreview";

            Console.WriteLine("Deleting files...");

            System.IO.DirectoryInfo di = new DirectoryInfo(destination);
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
            if (System.IO.Directory.Exists(destination))
            {
                System.IO.Directory.Delete(destination);
            }
            
            
            Console.WriteLine("Unregistring CSVPreview...");

            //Microsoft.Win32.RegistryKey key;
            RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64);
            RegistryKey key = hklm.OpenSubKey(@"SOFTWARE\Classes\*\shell", true);

            if (key.GetSubKeyNames().Contains("CSVPreview"))
            {
                key.DeleteSubKeyTree("CSVPreview");
            }
            //key = key.CreateSubKey("CSVPreview");
            //key.SetValue("icon", destination + @"\CSVPreview.ico");
            //key = key.CreateSubKey("command");
            //key.SetValue("", destination + "\\CSVPreview.exe \"%1\"");






            Console.WriteLine("Done! Press Enter to continue...");
            Console.Read();

        }
    }
}
