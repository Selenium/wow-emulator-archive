using System;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Globalization;
using System.Xml;
using WoWDaemon.Common;
using WoWDaemon.Realm;
using WoWDaemon.Login;
using WoWDaemon.World;
using WoWDaemon.Database;
using WoWDaemon.Database.DataTables;
using WoWDaemon.Database.MemberValues;
using WoWDaemon.Common.Attributes;

namespace WoWDaemon.Loader
{
	class Loader
	{
		static IPEndPoint GetIPEndPoint(string str)
		{
			string[] split = str.Split(':');
			IPAddress address = GetAddress(split[0]);
			if(address == null)
				return null;
			int port = 0;
			if(split.Length == 2)
			{
				try
				{
					port = int.Parse(split[1]);
				}
				catch(Exception)
				{
					return null;
				}
			}
			return new IPEndPoint(address, port);
		}

		static IPAddress GetAddress(string str)
		{
			IPAddress address;
			if(str == "any")
			{
				address = Dns.Resolve(Dns.GetHostName()).AddressList[0];
			}
			else
			{
				try
				{
					address = IPAddress.Parse(str);
				}
				catch(FormatException)
				{
					try
					{
						Console.WriteLine("Trying to resolve " + str + "...");
						IPHostEntry host = Dns.Resolve(str);
						address = host.AddressList[0];
					}
					catch(Exception e)
					{
						Console.WriteLine(e.Message);
						return null;
					}
				}
			}
			return address;
		}

		static bool ParseWorldServers(XmlNodeList worldServers)
		{
			if(worldServers.Count == 0)
			{
				Console.WriteLine("No worldservers in loginserver config.");
				return false;
			}
			foreach(XmlNode node in worldServers)
			{
				if(node["Address"] == null)
				{
					Console.WriteLine("WorldServer is missing Address element.");
					return false;
				}
				if(node["Worldmaps"] == null)
				{
					Console.WriteLine("WorldServer is missing Worldmaps element.");
					return false;
				}
				string maps = node["Worldmaps"].InnerText;
				string address = node["Address"].InnerText;
				uint[] mapIds;
				if(maps == "all")
				{
					DataObject[] objs = DataServer.Database.SelectAllObjects(typeof(DBWorldMap));
					if(objs.Length == 0)
					{
						Console.WriteLine("No world maps in database!");
						return false;
					}
					mapIds = new uint[objs.Length];
					for(int i = 0;i < objs.Length;i++)
						mapIds[i] = objs[i].ObjectId;
				}
				else
				{
					string[] split = maps.Split(' ');
					mapIds = new uint[split.Length];
					for(int i = 0;i < split.Length;i++)
					{
						try
						{
							mapIds[i] = uint.Parse(split[i]);
						}
						catch(Exception)
						{
							Console.WriteLine("Error parsing worldmap ids on worldserver: " + address);
							return false;
						}
					}
				}
				
				ClientBase client;
				if(address == "local")
				{
					if(localWorldServerStarted == true)
					{
						Console.WriteLine("There can only be one local worldserver!");
						return false;
					}

					client = StartLocalWorldServer();
					if(client == null)
					{
						Console.WriteLine("Failed to start local worldserver.");
						return false;
					}
				}
				else
				{
					IPEndPoint iep = GetIPEndPoint(address);
					if(iep == null)
					{
						Console.WriteLine("Error parsing worldserver address " + address);
						return false;
					}
					Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
					if(iep.Port == 0)
						iep.Port = 9003;
					Console.WriteLine("Connecting to worldserver " + iep.ToString());
					try
					{
						sock.Connect(iep);
					}
					catch(Exception e)
					{
						Console.WriteLine(e.Message);
						return false;
					}
					client = new ClientBase(sock);
				}

				try
				{
					LoginServer.SetWorldServer(client, mapIds);
				}
				catch(Exception e)
				{
					Console.WriteLine(e.Message);
					return false;
				}
			}
			return true;
		}

		static bool ParseRealmLists(XmlNodeList realmLists)
		{
			if(realmLists.Count == 0)
			{
				Console.WriteLine("No realmlists in loginserver config.");
				return false;
			}
			foreach(XmlNode node in realmLists)
			{
				string password = string.Empty;
				if(node["Password"] != null)
					password = node["Password"].InnerText;
				if(node["Address"] == null)
				{
					Console.WriteLine("Realmlist is missing Address element.");
					return false;
				}
				string address = node["Address"].InnerText;
				ClientBase client;
				if(address == "local")
				{
					if(localRealmListServerStarted)
					{
						Console.WriteLine("There can only be one local realmlist server!");
						return false;
					}
					Console.WriteLine("Test Realmlist");
					client = StartLocalRealmListServer();
					if(client == null)
					{
						Console.WriteLine("Failed to start local realmlist server.");
						return false;
					}
				}
				else
				{
					IPEndPoint iep = GetIPEndPoint(address);
					if(iep == null)
					{
						Console.WriteLine("Error parsing realmlist address " + address);
						return false;
					}
					Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
					if(iep.Port == 0)
						iep.Port = 3725;
					Console.WriteLine("Connecting to realmlist " + iep.ToString());
					try
					{
						sock.Connect(iep);
					}
					catch(Exception e)
					{
						Console.WriteLine(e.Message);
						return false;
					}
					client = new ClientBase(sock);
				}
				RedirectServer.AddRealmList(new RealmListUpdater(client, password));
			}
			return true;
		}

		static bool StartLoginServer()
		{
			Console.WriteLine("Welcome to WoWDaemon.");
			Console.WriteLine("Loading server...");
			try
			{
				DataServer.Database.LoadDatabaseTables();
			}
			catch(Exception e)
			{
				Console.WriteLine("Error: " + e.Message);
				return false;
			}
			Console.WriteLine("Loaded " + DataServer.Database.GetObjectCount(typeof(DBAccount)) + " accounts");
			Console.WriteLine("Loaded " + DataServer.Database.GetObjectCount(typeof(DBCharacter)) + " characters");
			Console.WriteLine("Loaded " + DataServer.Database.GetObjectCount(typeof(DBItemTemplate)) + " items");
			Console.WriteLine("Loaded " + DataServer.Database.GetObjectCount(typeof(DBSpawn)) + " spawns");
			Console.WriteLine("Loaded " + DataServer.Database.GetObjectCount(typeof(DBGuild)) + " guilds");
			Console.WriteLine("Loaded " + DataServer.Database.GetObjectCount(typeof(DBTabard)) + " tabards");
			Console.WriteLine("Loaded " + DataServer.Database.GetObjectCount(typeof(DBWorldMap)) + " World Maps");

		Console.WriteLine("Done");

			LoginServerConfig config = new LoginServerConfig(m_configDir + "loginserver.config");
			if(config.Document["LoginServerConfig"] == null)
				config.SetDefaultValues();

			XmlNodeList list = config.Document["LoginServerConfig"].SelectNodes("descendant::RealmList");
			Console.WriteLine("Parsing realmlists...");
			if(ParseRealmLists(list) == false)
				return false;

			list = config.Document["LoginServerConfig"].SelectNodes("descendant::WorldServer");
			Console.WriteLine("Parsing worldservers...");
			if(ParseWorldServers(list) == false)
				return false;
			
			list = config.Document["LoginServerConfig"].SelectNodes("descendant::ScriptReference");
			foreach(XmlNode node in list)
				LoginServer.AddScriptReference(node.InnerText);

			LoginServer.ServerName = config.ServerName;
			if(!LoginServer.LoadScripts(config.Scripts))
				return false;
			IPAddress address = GetAddress(config.Address);
			if(address == null)
				return false;
			IPEndPoint iep = new IPEndPoint(address, config.Port);
			string ExternalIP = GetAddress(config.ExternalHost).ToString();
			if(!LoginServer.Start(iep, config.RedirectPort, ExternalIP))
			{
				Console.WriteLine("Failed to start Loginserver.");
				return false;
			}
			Console.WriteLine("Loginserver started on " + LoginServer.EndPoint);
			Console.WriteLine("Redirectserver started on " + RedirectServer.LocalEndPoint);
			if(localRealmListServerStarted)
				Console.WriteLine("Realmlist server started on " + RealmListServer.Instance.LocalEndPoint);
			return true;
		}

		static bool localWorldServerStarted = false;
		static LocalClientBase StartLocalWorldServer()
		{
			WorldServerConfig config = new WorldServerConfig(m_configDir + "worldserver.config");
			if(config.Document["WorldServerConfig"] == null)
				config.SetDefaultValues();

			XmlNodeList list = config.Document["WorldServerConfig"].SelectNodes("descendant::ScriptReference");
			foreach(XmlNode node in list)
				WorldServer.AddScriptReference(node.InnerText);

			if(WorldServer.LoadWorldScripts(config.Scripts) == false)
				return null;
			LocalClientBase c1 = new LocalClientBase();
			LocalClientBase c2 = new LocalClientBase();
			c1.SetRemoteClient(c2);
			c2.SetRemoteClient(c1);
			WorldServer.Start(c2);
			localWorldServerStarted = true;
			Console.WriteLine("Local Worldserver started.");
			return c1;
		}

		static ClientBase StartLocalRealmListServer()
		{
			if(!StartRealmListServer())
				return null;			
			return RealmProxy.GetProxy(RealmListServer.Instance);
		}

		static void StopLoginServer()
		{
			LoginServer.Shutdown();
			if(localRealmListServerStarted) {
				RealmListServer.Instance.Stop();
				localRealmListServerStarted = false;
			}
			DataServer.Database.WriteDatabaseTables();
			LoginServer.RestartServer = false;
		}

		static bool localRealmListServerStarted = false;
		static bool StartRealmListServer()
		{
			RealmListConfig config = new RealmListConfig(m_configDir + "realmlist.config");
			if(config.Document["RealmListConfig"] == null)
				config.SetDefaultValues();
			RealmListServer.Instance.UpdaterPassword = config.Password;
			IPAddress address = GetAddress(config.Address);
			if(address == null)
				return false;
//			string ExternalIP = GetAddress(config.ExternalHost).ToString();
			localRealmListServerStarted = RealmListServer.Instance.Start(new IPEndPoint(address, config.Port), config.UpdatePort);
			return localRealmListServerStarted;
		}

		static bool StartWorldServer()
		{
			WorldServerConfig config = new WorldServerConfig(m_configDir + "worldserver.config");
			if(config.Document["WorldServerConfig"] == null)
				config.SetDefaultValues();

			XmlNodeList list = config.Document["WorldServerConfig"].SelectNodes("descendant::ScriptReference");
			foreach(XmlNode node in list)
				WorldServer.AddScriptReference(node.InnerText);

			if(!WorldServer.LoadWorldScripts(config.Scripts))
				return false;
			IPAddress address = GetAddress(config.Address);
			int port = config.Port;
			if(port == 0)
				port = 9003;
			Socket listen = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			ClientBase client;
			try
			{
				listen.Bind(new IPEndPoint(address, port));
				listen.Listen(1);
				Console.WriteLine("Waiting for loginserver to connect on " + listen.LocalEndPoint);
				Socket sock = listen.Accept();
				Console.WriteLine("Loginserver connected from " + sock.RemoteEndPoint);
				listen.Close();
				client = new ClientBase(sock);
			}
			catch(Exception e)
			{
				Console.WriteLine("Worldserver listening socket failed. " + e.Message);
				return false;
			}
			WorldServer.Start(client);
			Console.WriteLine("Worldserver started.");
			return true;
		}

		static void PrintUsage()
		{
			Console.WriteLine("Usage: loader -<l|r|w> [config dir]");
			Console.WriteLine("-l : Starts loginserver");
			Console.WriteLine("-r : Starts a standalone realmlist server.");
			Console.WriteLine("-w : Starts a standalone worldserver.");
		}
		
		static string m_configDir = string.Empty;

		#region Restart Thread Handling
		static Thread m_restartthread = null;
		private static void RestartLoop() {
			while(true) {
				Thread.Sleep(1000);
				if (LoginServer.RestartServer) {
					try {
						Console.WriteLine("Stopping server for restart!");
						WorldServer.Stop();
						localWorldServerStarted = false;

						StopLoginServer();
						Thread.Sleep(3000);
					} catch {
					} finally {
						DebugLogger.Log("Restarted the server...");

						Process.Start("Loader.exe", "-lr");

						Thread.Sleep(500);
						// Collect all trash
						GC.Collect();
						// Just exit the program!!
						Environment.Exit(0);
					}
				}
			}
		}
		#endregion

		#region Main
		static void Main(string[] args)
		{
			CultureInfo info = CultureInfo.CreateSpecificCulture("en-US");
			Thread.CurrentThread.CurrentCulture = info;

			if(args.Length == 0)
			{
				PrintUsage();
				return;
			}
			if(args.Length == 2)
			{
				m_configDir = args[1];
				if(!(m_configDir.EndsWith("\\") || m_configDir.EndsWith("/")))
					m_configDir += "/";
				DirectoryInfo dir;
				try
				{
					dir = new DirectoryInfo(m_configDir);
				}
				catch(FormatException)
				{
					Console.WriteLine("'" + m_configDir + "' is not a valid directory.");
					return;
				}
				if(dir.Exists == false)
				{
					try
					{
						dir.Create();
					}
					catch(IOException e)
					{
						Console.WriteLine(e.Message);
						return;
					}
				}
			}
			if(args[0].StartsWith("-l"))
			{
				if (args[0] == "-lr") {
					Console.WriteLine("Waiting for other server to close before we start a new one!");
					Thread.Sleep(10000);
				}

				if(!StartLoginServer())
					return;
				m_restartthread = new Thread(new ThreadStart(RestartLoop));
				m_restartthread.Start();
				while(true)
				{
					string str = Console.ReadLine();
					if(str.ToLower() == "quit" || str.ToLower() == "shutdown")
						break;
					else if(str == "clients")
					{
						Console.WriteLine("LoginServer clients: " + LoginServer.CurrentUsers);
					}
					else if(str.ToLower() == "reload loginscripts"||str.ToLower() == "rl")
					{
						Console.WriteLine("Reloading Loginscripts...");
						LoginServer.ReloadScripts();
					}
					else if(str.ToLower() == "reload worldscripts"||str.ToLower() == "rw")
					{
						Console.WriteLine("Reloading Worldscripts...");
						if(localWorldServerStarted)
							WorldServer.ReloadScripts();
					}
					else if(str.ToLower() == "restart")
					{
						LoginServer.RestartServer = true;
					}
				}
				m_restartthread.Abort();
				m_restartthread = null;
				StopLoginServer();
			}
			else if(args[0].StartsWith("-r"))
			{
				if(!StartRealmListServer())
				{
					Console.WriteLine("Failed to start realm list server.");
					return;
				}
				while(true)
				{
					string str = Console.ReadLine();
					if(str == "quit" || str == "shutdown")
						break;
				}
				RealmListServer.Instance.Stop();
			}
			else if(args[0].StartsWith("-w"))
			{
				if(StartWorldServer() == false)
				{
					Console.WriteLine("Failed to start worldserver.");
					return;
				}
				while(true)
				{
					string str = Console.ReadLine();
					if(str == "quit" || str == "shutdown")
						break;
					else if(str == "reload worldscripts")
					{
						WorldServer.ReloadScripts();
					}
					else if(str == "restart")
					{
						if(WorldServer.ServerRunning)
						{
							Console.WriteLine("Worldserver is still running.");
							continue;
						}
						if(StartWorldServer() == false)
							Console.WriteLine("Failed to start worldserver.");
					}
				}
				WorldServer.Stop();
			}
			else
			{
				PrintUsage();
			}
		}
		#endregion
	}
}
