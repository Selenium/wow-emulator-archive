/*
 * Copyright (C) 2006 by pAbLoPiCaSsO and Blumster
 *
 * This program is not free. You may not redistribute it. There will be no
 * warranty for this product.
 */
 
using System;
using System.IO;
using System.Net;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Server
{
	class Config
	{
		public static bool ReadConfig()
		{
			if(!File.Exists("Configs/config.ini"))
            {						
				Config.ConfigsCreate();
            }
			
			FileStream config = new FileStream("Configs/config.ini", FileMode.Open, FileAccess.Read);
			StreamReader configreader = new StreamReader(config);

			string Configsversion = configreader.ReadLine();
			string serverConfigsversion = World.Version;
			if ( serverConfigsversion != Configsversion)
			{
				Log.WriteLogWithout("Your config.ini is outdated!");
				return false;
			}
            World.DNS = Dns.Resolve(configreader.ReadLine());
            World.RealmserverPort = Int32.Parse(configreader.ReadLine());
			World.WorldPort = Int32.Parse(configreader.ReadLine());
			World.HTTPPort = Int32.Parse(configreader.ReadLine());
            World.ServerName = configreader.ReadLine();
			configreader.Close();
			return true;
		}
		
		public static void ConfigsCreate()
		{

                if (Directory.Exists("Configs"))
                {
                	File.Create("Configs/config.ini").Close();
                    MessageBox.Show("Configs directory found, config.ini file created.", "Ready");
                    WriteTextWhenCreatingNewFile();
                }
                else
                {
                	Directory.CreateDirectory("Configs");
                	File.Create("Configs/config.ini").Close();
                    MessageBox.Show("Configs directory was not found, Configs directory and config.ini file created.", "Ready");
                    WriteTextWhenCreatingNewFile();
                }
          
		}
		
		public static void WriteTextWhenCreatingNewFile()
        {
            FileStream newConfigsfilewrite = new FileStream("Configs/config.ini", FileMode.Open, FileAccess.Write);
            StreamWriter nfsw = new StreamWriter(newConfigsfilewrite);
            nfsw.AutoFlush = true;

            nfsw.WriteLine("Alpha 0.01");
            nfsw.WriteLine("localhost");
            nfsw.WriteLine("3724");
            nfsw.WriteLine("8085");
            nfsw.WriteLine("8080");
            nfsw.WriteLine("Local Server");


            nfsw.Close();
        }
	}
}
