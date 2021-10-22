using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace minecraft_mod_manager
{
    class Config
    {
        private static string CONFIG_DIR = $@"C:\Users\{Environment.UserName}\AppData\Local\modmanager\config.txt";
        private static string LAUNCHER_INSTALLDIR;
        private static bool PRELAUNCHER_DEBUG;

        public static void ReadFile()
        {
            string[] content = File.ReadAllLines(CONFIG_DIR);

            foreach (string variable in content)
            {
                if (variable.Contains("::")) 
                {
                    string[] splitVariable = variable.Split('=');

                    if ((splitVariable[0]) == "LAUNCHER_INSTALLDIR" && File.Exists(splitVariable[1]))
                        LAUNCHER_INSTALLDIR = splitVariable[1];

                    if ((splitVariable[0]) == "PRELAUNCHER_DEBUG")
                    {
                        if (splitVariable[1].ToLower() == "true")
                            PRELAUNCHER_DEBUG = true;

                        else if (splitVariable[1].ToLower() == "false")
                            PRELAUNCHER_DEBUG = false;
                    }



                }
            }
        }

        public static void WriteFile()
        {

        }
    }
}
