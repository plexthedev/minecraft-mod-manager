using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CommandHandler;

namespace minecraft_mod_manager
{
    // TODO: Make a function to place files into the "%localappdata%/modmanager" directory
    // or do an integrity check on the config.txt if they are already there
    // subdirectories are "mods" and "modconfigs"
    // mod configs will contain .modcfg files for each modfolder (e.g. Hael9.modcfg; Hexxit.modcfg)
    class Program
    {
        private static void IntegrityCheck()
        {
            try
            {
                Config.ReadFile();
            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowError("IntegrityCheck", ex);
            }
        }

        private static void MakeFolders()
        {
            // make the folders and config.txt file.

            string basedir = $@"C:\Users\{Environment.UserName}\AppData\Local\modmanager";
            string defaultconfig = "LAUNCHER_INSTALLDIR=unassigned\n\nPRELAUNCHER_DEBUG=0";

            if (Directory.Exists(basedir))
            {
                Console.WriteLine(basedir + " already exists, skipping");

                if (Directory.Exists(basedir + @"\mods")) Console.WriteLine(basedir + @"\mods already exists, skipping");
                else
                {
                    Directory.CreateDirectory(basedir + @"\mods");
                    Console.WriteLine(basedir + @"\mods created");
                }

                if (Directory.Exists(basedir + @"\modconfigs")) Console.WriteLine(basedir + @"\modconfigs already exists, skipping");
                else
                {
                    Directory.CreateDirectory(basedir + @"\modconfigs");
                    Console.WriteLine(basedir + @"\modconfigs created");

                    if (File.Exists(basedir + @"\config.txt")) Console.WriteLine("Config file already present, skipping");
                    else
                    {
                        var x = File.Create(basedir + @"\config.txt"); x.Close();
                        File.WriteAllText(basedir + @"\config.txt", defaultconfig);
                        Console.WriteLine("Config file not present, created default config");
                    }
                }
            }
            else
            {
                Directory.CreateDirectory(basedir);
                Directory.CreateDirectory(basedir + @"\mods");
                Directory.CreateDirectory(basedir + @"\modconfigs");

                Console.WriteLine("Base directory not present, created directory structure");

                var x = File.Create(basedir + @"\config.txt"); x.Close();
                File.WriteAllText(basedir + @"\config.txt", defaultconfig);

                Console.WriteLine("Default config file created...");
            }

            Console.Write("\n\nPress enter to continue...");
            Console.ReadLine();
            Console.Clear();

        }
        static void Main(string[] args)
        {
            string dir = $@"C:\Users\{Environment.UserName}\AppData\Local\modmanager\config.txt";

            if (File.Exists(dir))
                IntegrityCheck();
            else
                MakeFolders();
            
            while (true)
            {
                Console.CursorVisible = false; // Doesn't show the cursor in the CLI

                Console.WriteLine("Minecraft Prelauncher\n\n[1] Launch \n[2] Select modfolder \n[3] Edit modfolders \n[4] Change launcher directory\n\n[Esc] to exit.");
                Console.SetCursorPosition(0, 0); // Sets cursor position to 0, this eliminates the need for a Console.Clear() and makes stuff go fassfass

                ConsoleKeyInfo INPUT = Console.ReadKey(true);

                switch (INPUT.Key)
                {
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;

                    case ConsoleKey.D1:
                        Launch();
                        break;

                    case ConsoleKey.D2:
                        SelectModfolder();
                        break;

                    case ConsoleKey.D3:
                        // Editmode.Init()
                        break;

                    case ConsoleKey.D4:
                        ChangeDirectory();
                        break;

                    case ConsoleKey.F2:
                        IntegrityCheck();
                        break;

                    default:
                        break;
                }
            }
        }

        private static void Launch()
        {
            // get path from config file and execute
        }

        private static void ChangeDirectory()
        {
            // get a .exe file path from the user with one of those cool ass menu things
        }

        private static void SelectModfolder()
        {
            // change the mods around and shit
        }

        // the modfolder editing part will be accessible in Editmode.cs (should start in static method Main aswell maybe?)
    }
}
