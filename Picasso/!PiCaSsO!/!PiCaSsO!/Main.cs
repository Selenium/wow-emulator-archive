/*
 * Copyright (C) 2006 by pAbLoPiCaSsO and Blumster
 *
 * This program is not free. You may not redistribute it. There will be no
 * warranty for this product.
 */
 
using System;
using System.IO;
using System.Threading;
using System.Globalization;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Database;

namespace Server
{

    class MainConsole
    {
        public static bool BuildAllDlls()
		    {
                ColoredConsole.ConsoleWriteWhiteWithOut("Building external C# scripts, please wait...");
			    int itemsDll = DllBuilder.BuildDll( World.Path + "/Scripts/Global", null );
			    if ( itemsDll == 2 )
                    ColoredConsole.ConsoleWriteGreenWithOut("Global scripts successfully rebuilt!");
			    else
                    ColoredConsole.ConsoleWriteGreenWithOut("Global scripts successfully loaded!");
			    return true;
		    }


        public static Thread RealmserverThread = new Thread(new ThreadStart(AuthSocket.Start));
        public static Thread WorldserverThread = new Thread(new ThreadStart(WorldServer.Start));
        public static Thread HTTPServerThread = new Thread(new ThreadStart(HTTPServer.MyWebServer.Main2));
        public static Thread CommandThread = new Thread(new ThreadStart(ConsoleCommands.Commands));
		private static int Main(string[] args)
		{

            Log.logwriter.AutoFlush = true;
            //Log.ClearFile();
            //Log.CheckFile();
            Console.Title = "!PiCaSsO! Emulator " + World.Version + " by pAbLoPiCaSsO and Blumster";
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Blue;
			Log.WriteLogWithOneWithoutDate("!PiCaSsO! version {0} Copyright (C) 2006 by !PiCaSsO! Developer team", World.Version);
            Console.ForegroundColor = ConsoleColor.White;
            if (RegistryManager.RegistryManager.ReturnRegistry() == "0")
            {
                MessageBox.Show("This version of !PiCaSsO! is not registred. Your 1 week trial will start now. If you want to buy this program, you can do so on http://PiCaSsOEmu.no-ip.info. If you already have a valid licence key, please type in the console: \"register <key>\"");
            }
            Database.Data.ReadAccounts();
            MainConsole data = new MainConsole();

            BuildAllDlls();
            //Declarations();
            //Database.DataClass.Declarations();

            
            bool configerror = Config.ReadConfig();
			if( configerror != true )
			{
				Thread.Sleep(5000);
				return 0;
			}
            HTTPServerThread.Start();
            Thread.Sleep(100);
            WorldserverThread.Start();
            Thread.Sleep(300);
            RealmserverThread.Start();
            CommandThread.Start();
			return 1;
		}
	}
}
