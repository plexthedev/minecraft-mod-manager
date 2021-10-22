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

            /* DEFAULT CONFIG FILE:
             
            -----------------------------------------------------------
            LAUNCHER_INSTALLDIR::path\to\MinecraftLauncher.exe

            PRELAUNCHER_INSTALLDIR::path\to\Minecraft Prelauncher.exe
            PRELAUNCHER_DEBUG_MODE::  
            -----------------------------------------------------------
            */
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
                        // Editmode.Console()
                        break;

                    case ConsoleKey.D4:
                        ChangeDirectory();
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
