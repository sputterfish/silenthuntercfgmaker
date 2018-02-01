/*
███████╗██╗  ██╗███████╗██████╗ 
██╔════╝██║  ██║██╔════╝██╔══██╗
███████╗███████║█████╗  ██████╔╝
╚════██║██╔══██║██╔══╝  ██╔══██╗
███████║██║  ██║██║     ██║  ██║
╚══════╝╚═╝  ╚═╝╚═╝     ╚═╝  ╚═╝
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.IO;

namespace SilentHunterFolderReader
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\\WOW6432Node\\ubisoft\\silent hunter 5\\gameupdate"))
                {
                    if (key != null)
                    {
                        Object o = key.GetValue("installdir");
                        if (o != null)
                        {   //GPcfg
                            string location = o.ToString();
                            location = @location.TrimEnd(new[] { '\\' });
                            string runfrom = System.IO.Directory.GetCurrentDirectory();
                            FileStream fs1 = new FileStream("GenericPatcher.cfg", FileMode.OpenOrCreate, FileAccess.Write);
                                StreamWriter writer = new StreamWriter(fs1);
                                string line1 = @"ClientAreaWidth=1184";
                                string line2 = @"ClientAreaHeight=765";
                                string line3 = @"CameraManager.act="+ @location;
                                string line4 = @"EnvSim.act=" + @location;
                                string line5 = @"kernel.dll=" + @location;
                                string line6 = @"sh5.exe=" + @location;
                                string line7 = @"SHCollisions.act=" + @location;
                                string line8 = @"SHSim.act=" + @location;
                                string line9 = @"SHSound.act=" + @location;
                                string line10 = @"SH_NClient.dll=" + @location;
                                string line11 = @"SimData.dll=" + @location;
                                string line12 = @"LanguagePackInUse=";
                                writer.WriteLine(line1);
                                writer.WriteLine(line2);
                                writer.WriteLine(line3);
                                writer.WriteLine(line4);
                                writer.WriteLine(line5);
                                writer.WriteLine(line6);
                                writer.WriteLine(line7);
                                writer.WriteLine(line8);
                                writer.WriteLine(line9);
                                writer.WriteLine(line10);
                                writer.WriteLine(line11);
                                writer.WriteLine(line12);
                                writer.Close();
                            // OFEVcfg
                            FileStream fs2 = new FileStream("OptionsFileEditorViewer.cfg", FileMode.OpenOrCreate, FileAccess.Write);
                            StreamWriter writer2 = new StreamWriter(fs2);
                            string newline1 = @"SH5InstallPath=" + @location;
                            string newline2 = @"LastMenuTXT=" + @location + @"\data\Menu\menu.txt";
                            string newline3 = @"LastOptionsFilePath=" + @location + @"\data\Scripts\Menu\";
                            string newline4 = @"ClientAreaWidth=1014";
                            string newline5 = @"ClientAreaHeight=736";
                            string newline6 = @"LanguagePackInUse=";
                            writer2.WriteLine(newline1);
                            writer2.WriteLine(newline2);
                            writer2.WriteLine(newline3);
                            writer2.WriteLine(newline4);
                            writer2.WriteLine(newline5);
                            writer2.WriteLine(newline6);
                            writer2.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write ("There was an error reading the regkey");
                Console.ReadKey();
            }

        }
    }
}
