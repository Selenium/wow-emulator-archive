using System;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Threading;
using System.Collections;
using System.Globalization;
using WoWDaemon.Common;
using WoWDaemon.Database.DataTables;

namespace WoWDaemon.World
{
	[WorldPacketHandler()]
	public class WorldServer
	{
		// Initiate the Server's Clock ( 1 real minute = 1 minutes in game )
		public static WorldClock m_clock = new WorldClock(1);
		public static ChannelManager m_channels = new ChannelManager();

		static WorldServer()
		{
			ObjectUpdateManager.SearchAssemblyForUpdateObjects(Assembly.GetExecutingAssembly());
			WorldPacketManager.SearchAssemblyForHandlers(Assembly.GetExecutingAssembly());
			m_scriptManager = ScriptManager.GetScriptManager();
		}

		public static void AddScriptReference(string module)
		{
			m_scriptManager.AddReference(module);
		}

		static string m_scriptPath = string.Empty;
		public static bool LoadWorldScripts(string path)
		{
			m_scriptPath = path;
			string error;
			if(m_scriptManager.LoadScripts(typeof(WorldScriptAssembly), true, path, out error) == false)
			{
				Console.WriteLine("Loading world scripts failed: " + error);
				return false;
			}
			else
				Console.WriteLine("Sucessfully loaded Worldscripts");
			return true;
		}

		public static void ReloadScripts()
		{
			string error;
			m_scriptManager.UnloadAllScripts();
			if(m_scriptManager.LoadScripts(typeof(WorldScriptAssembly), true, m_scriptPath, out error) == false)
			{
				Console.WriteLine("Reloading world scripts failed: " + error);
			}
			else
				Console.WriteLine("Sucessfully reloaded Worldscripts");
		}

		static ScriptManager m_scriptManager;
		static ClientBase m_connection;
		static Thread m_mainThread;
		static Hashtable m_clients = new Hashtable();
		static bool m_shutdown;
		static WorldScriptAssembly m_scripts = new WorldScriptAssembly();
		static bool m_running = false;
		internal static WorldScriptAssembly Scripts
		{
			get { return m_scripts;}
			set { m_scripts = value;}
		}

		public static void Start(ClientBase connection)
		{
			m_shutdown = false;
			m_connection = connection;
			m_connection.RecievedDataHandler += OnLoginServerData;
			m_mainThread = new Thread(new ThreadStart(mainThread));
			m_mainThread.Start();
		}

		public static void Stop()
		{
			m_shutdown = true;
			m_connection.RecievedDataHandler -= OnLoginServerData;
			//m_mainThread.Abort();
		}

		public static bool ServerRunning
		{
			get { return m_running;}
		}

		private static bool processConnection()
		{
			try {
				if(m_connection.PendingSendData)
					m_connection.SendWork();
				if(m_connection.Connected == false)
					return false;
//				byte[] data;
				// Hmm, bah! if it is not able to handle all the data there's something wrong but not here:)
//				while((data = m_connection.GetNextPacketData()) != null)
//					OnLoginServerData(data);
				return m_connection.Connected;
			} catch (Exception exp) {
				DebugLogger.Logger.Log("", exp);
			}
			return false;
		}

		private static void mainThread()
		{
			Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
			try
			{
				m_running = true;
				int shutdownstage = 0;
				while(true)
				{
					if(!processConnection())
					{
						// Todo handle this
						break;
					}

					EventManager.CheckEvents();

					if(m_shutdown == true)
					{
						if(shutdownstage == 0)
						{
							// save and remove everything
							ArrayList clients = new ArrayList(m_clients.Values);
							IEnumerator e = clients.GetEnumerator();
							while(e.MoveNext())
							{
								WorldClient client = (WorldClient)e.Current;
								client.LeaveWorld();
							}
							shutdownstage = 1;
						}
						if(shutdownstage == 1 && DBManager.CreateRequestsPending() == 0)
						{
							Send(new WorldPacket(WORLDMSG.WORLD_SHUTDOWN));
							shutdownstage = 2;
						}
						if(shutdownstage == 2 && m_connection.PendingSendData == false)
						{
							break;
						}
					}
					Thread.Sleep(5);
				}
			}
			catch(ThreadAbortException)
			{
			}
			catch(Exception e)
			{
				Console.WriteLine("Unhandled worldserver exception!");
				Console.WriteLine(e.Message);
				Console.WriteLine(e.StackTrace);
				DebugLogger.ILog("", e);
			}
			ObjectManager.CheckBeforeShutdown();
			DBManager.CheckBeforeShutdown();
			m_connection.Close("Server shutting down.");
			m_running = false;
		}

		[WorldPacketDelegate(WORLDMSG.WORLD_SHUTDOWN)]
		static void OnWorldShutdown(WORLDMSG msgID, BinReader data)
		{
			m_shutdown = true;
		}


		private static void OnLoginServerData(ClientBase client, byte[] data)
		{
			try {
				BinReader read = new BinReader(data);
				read.BaseStream.Position += 4; // skip len
				WORLDMSG msgID = (WORLDMSG)read.ReadInt32();

				if (msgID != WORLDMSG.DESERIALIZE_OBJ)
				{
					Console.WriteLine("OnLoginServerData read {0}", msgID);
				}

				if(msgID == WORLDMSG.CLIENT_MESSAGE)
				{
					uint charID = read.ReadUInt32();
					CMSG cmsg = (CMSG)read.ReadInt32();
					WorldClient world_client = GetClientByCharacterID(charID);
					if(client != null)
					{
						WorldPacketManager.HandlePacket(world_client, cmsg, read);
					}
					else
						Console.WriteLine("Client(" + charID + ") was missing when " + cmsg.ToString() + " was received.");
				}
				else if(msgID == WORLDMSG.SCRIPT_MESSAGE)
				{
					int msg = read.ReadInt32();
                    Console.WriteLine("Read SMSG: " + msg);
					Scripts.OnScriptMessage(msg, read);
				}
				else
				{
					WorldPacketManager.HandlePacket(msgID, read);
				}
			} catch (Exception exp) {
				DebugLogger.ILog("", exp);
			}
		}

		public static void Send(WorldPacket pkg)
		{
			DebugLogger.ILog("Sending packet " + pkg.ToString());
			try {
				pkg.Set(0, (int)(pkg.BaseStream.Length-4));
				m_connection.Send(pkg.GetBuffer(), pkg.BaseStream.Length);
			} catch (Exception exp) {
				DebugLogger.ILog("", exp);
			}
		}

		internal static void AddClient(WorldClient client)
		{
			DebugLogger.ILog("Added client: " + client.ToString());
			try {
				m_clients[client.CharacterID] = client;
			} catch (Exception exp) {
				DebugLogger.ILog("", exp);
			}
		}

		internal static void RemoveClient(WorldClient client)
		{
			try {
				m_clients.Remove(client.CharacterID);
			} catch (Exception exp) {
				DebugLogger.ILog("", exp);
			}
		}

		public static WorldClient GetClientByCharacterID(uint id)
		{
			try {
				return (WorldClient)m_clients[id];
			} catch (Exception exp) {
				DebugLogger.ILog("", exp);
			}
			return null;
		}

		public static WorldClient GetClientByName(string name)
		{
			try {
				int numclient = m_clients.Count;
				System.Collections.IDictionaryEnumerator ienum = m_clients.GetEnumerator();
				while(ienum.MoveNext())
				{
					if( ((WorldClient)ienum.Value).Player.Name == name )
					{
						return (WorldClient)ienum.Value;
					}
				}		
			} catch (Exception exp) {
				DebugLogger.ILog("", exp);
			}
			return null;
		}

		public static System.Collections.IDictionaryEnumerator GetClientsEnum() 
		{
			return m_clients.GetEnumerator();
		}
	}
}
