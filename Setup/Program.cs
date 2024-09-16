using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Installing CSVPreview...");
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            path = System.IO.Path.GetDirectoryName(path);
            //string destination = Environment.ExpandEnvironmentVariables(@"%LOCALAPPDATA%") + @"\CSVPreview";
            string destination = Environment.ExpandEnvironmentVariables(@"%APPDATA%") + @"\CSVPreview";
            if (!System.IO.Directory.Exists(destination))
            {
                System.IO.Directory.CreateDirectory(destination);
            }
            Console.WriteLine("Copying CSVPreview.exe...");
            System.IO.File.Copy(path + @"\CSVPreview.exe", destination + @"\CSVPreview.exe", true);
            Console.WriteLine("Copying CSVPreview.exe.config...");
            System.IO.File.Copy(path + @"\CSVPreview.exe.config", destination + @"\CSVPreview.exe.config", true);
            Console.WriteLine("Copying CSVPreview.pdb...");
            System.IO.File.Copy(path + @"\CSVPreview.pdb", destination + @"\CSVPreview.pdb", true);
            Console.WriteLine("Copying GenericParsing.dll...");
            System.IO.File.Copy(path + @"\GenericParsing.dll", destination + @"\GenericParsing.dll", true);
            Console.WriteLine("Copying GenericParsing.xml...");
            System.IO.File.Copy(path + @"\GenericParsing.xml", destination + @"\GenericParsing.xml", true);
            Console.WriteLine("Copying CSVPreview.ico ...");
            System.IO.File.Copy(path + @"\CSVPreview.ico", destination + @"\CSVPreview.ico", true);

            //Microsoft.Win32.RegistryKey key;
            RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64);
            RegistryKey key = hklm.OpenSubKey(@"SOFTWARE\Classes\*\shell", true);

            if(key.GetSubKeyNames().Contains("CSVPreview"))
            {
                key.DeleteSubKeyTree("CSVPreview"); 
            }
            key = key.CreateSubKey("CSVPreview");
            key.SetValue("icon", destination + @"\CSVPreview.ico");
            key = key.CreateSubKey("command");
            key.SetValue("", destination + "\\CSVPreview.exe \"%1\"");






            Console.WriteLine("Done! Press Enter to continue..."); 
            Console.Read();

        }
    }
}
