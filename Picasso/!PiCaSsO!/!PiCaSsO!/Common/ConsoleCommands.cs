/*
 * Copyright (C) 2006 by pAbLoPiCaSsO and Blumster
 *
 * This program is not free. You may not redistribute it. There will be no
 * warranty for this product.
 */

using System;
using System.Threading;
using System.Diagnostics;

namespace Server
{
    class ConsoleCommands
    {
        public static void Commands()
        {
            while (true)
            {
                string command = Console.ReadLine();
                switch (command)
                {
                    case "exit":
                        {
                            Process Process;
                            Process = Process.GetCurrentProcess();
                            Process.CloseMainWindow();
                            return;
                        }
                    case "restart":
                        {
                            Process Process;
                            Process Process2;
                            Process2 = Process.GetCurrentProcess();
                            Log.logwriter.Close();
                            Process.Start("!PiCaSsO!.exe");
                            Process2.Kill();                            
                            return;
                        }
                    case "help":
                        {
                            ColoredConsole.ConsoleWriteBlueWithOut("!PiCaSsO!-Help:\nhelp -displays this help-\nrestart -restarts the server-\nexit -shuts the server down-\ncls -clears the console window-");
                            break;
                        }
                    case "cls":
                        {
                            Console.Clear();
                            break;
                        }
                    case "unregister":
                        {
                            RegistryManager.RegistryManager.UnRegisterKey();
                            break;
                        }
                    default:
                        {
                            if (command.StartsWith("register"))
                            {
                                if (command.Length >= 8)
                                    RegistryManager.RegistryManager.RegisterKey(command.Substring(command.LastIndexOf(" ") + 1, command.Length - 9));
                                else
                                    ColoredConsole.ConsoleWriteErrorWithOut("Invalid key.");
                            }
                            else ColoredConsole.ConsoleWriteErrorWithOut("Unknown command: " + command);
                            break;
                        }
                }
            }

        }
    }
}

