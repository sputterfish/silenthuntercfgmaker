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
                        {
                            string location = o.ToString();
                            location = @location.TrimEnd(new[] { '\\' });
                            string runfrom = System.IO.Directory.GetCurrentDirectory();
                            if (!File.Exists(@runfrom+@"\config.cfg"))//Change config.cfg to your filename
                            {
                                FileStream fs1 = new FileStream("config.cfg", FileMode.OpenOrCreate, FileAccess.Write);//Change config.cfg to your filename
                                StreamWriter writer = new StreamWriter(fs1);
                                string line1 = @"ClientAreaWidth = 1184";
                                string line2 = @"ClientAreaHeight = 765";
                                string line3 = @"CameraManager.act = "+'"' + @location + '"';
                                string line4 = @"EnvSim.act = " + '"' + @location + '"';
                                string line5 = @"kernel.dll = " + '"' + @location + '"';
                                string line6 = @"sh5.exe = " + '"' + @location + '"';
                                string line7 = @"SHCollisions.act = " + '"' + @location + '"';
                                string line8 = @"SHSound.act = " + '"' + @location + '"';
                                string line9 = @"SH_NClient.dll = " + '"' + @location + '"';
                                string line10 = @"SimData.dll = " + '"' + @location + '"';
                                string line11 = @"LanguagePackInUse =";
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
                                writer.Close();
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write ("There was an error");
            }

        }
    }
}
