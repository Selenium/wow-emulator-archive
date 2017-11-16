using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections;
using System.Collections.Specialized;
using WoWDaemon.Common;
using WoWDaemon.Database;
using WoWDaemon.Database.Connection;
using WoWDaemon.Database.DataTables;


namespace WoWDaemon.Login
{
	public class DataServer
	{
		public static readonly ObjectDatabase Database = new ObjectDatabase(new DataConnection(ConnectionType.DATABASE_XML, "xml_db"));
		static DataServer()
		{
			Database.RegisterDataObject(typeof(DBAccount));
			Database.RegisterDataObject(typeof(DBFriendList));

			Database.RegisterDataObject(typeof(DBBanned));
			Database.RegisterDataObject(typeof(DBCharacter));
			Database.RegisterDataObject(typeof(DBCreature));
			Database.RegisterDataObject(typeof(DBItem));
			Database.RegisterDataObject(typeof(DBItemTemplate));
			Database.RegisterDataObject(typeof(DBSpawn));
			Database.RegisterDataObject(typeof(DBWorldMap));
			Database.RegisterDataObject(typeof(DBGuild));
			Database.RegisterDataObject(typeof(DBGuildMembers));
			Database.RegisterDataObject(typeof(DBTabard));
			Database.RegisterDataObject(typeof(DBSpell));
			Database.RegisterDataObject(typeof(DBKnownSpell));
			Database.RegisterDataObject(typeof(DBQuest));
			Database.RegisterDataObject(typeof(DBKnownQuest));
			Database.RegisterDataObject(typeof(DBTalents));
			Database.RegisterDataObject(typeof(DBKnownTalents));
			Database.RegisterDataObject(typeof(DBVendor));
			Database.RegisterDataObject(typeof(DBVendorItem));
			Database.RegisterDataObject(typeof(DBTraining));
			Database.RegisterDataObject(typeof(DBLootGroup));
			Database.RegisterDataObject(typeof(DBLootGroupItem));
		}
	}

	public class LoginServer : ServerBase
	{
		public static LoginServer Instance = new LoginServer();
		static string m_serverName = "Noname";
		static bool m_restartserver = false;

		public static string ServerName
		{
			get { return m_serverName;}
			set { m_serverName = value;}
		}

		internal static LoginScriptAssembly Scripts = new LoginScriptAssembly();

		static LoginServer()
		{
			LoginPacketManager.SearchAssemblyForHandlers(System.Reflection.Assembly.GetExecutingAssembly());
		}

		static int m_maxUsers = 100;
		static int m_topUsers = 0;
		static Hashtable m_loginCharacters = new Hashtable();
		static ArrayList m_worldServers = new ArrayList();
		static HybridDictionary m_worldMapServer = new HybridDictionary();

		#region Scripts
		static ScriptManager m_scriptManager = ScriptManager.GetScriptManager();
		static string m_scriptPath = string.Empty;

		public static void AddScriptReference(string module)
		{
			m_scriptManager.AddReference(module);
		}

		public static bool LoadScripts(string path)
		{
			m_scriptPath = path;
			string error;
			if(m_scriptManager.LoadScripts(typeof(LoginScriptAssembly), true, path, out error) == false)
			{	
				Console.WriteLine("Loading login scripts failed. " + error);
				return false;
			}
			else
				Console.WriteLine("Sucessfully loaded Loginscripts");

			return true;
		}

		public static void ReloadScripts()
		{
			string error;
			m_scriptManager.UnloadAllScripts();
			if(m_scriptManager.LoadScripts(typeof(LoginScriptAssembly), true, m_scriptPath, out error) == false)
			{
				Console.WriteLine("Reloading login scripts failed. " + error);
			}
			else
				Console.WriteLine("Sucessfully reloaded Loginscripts");
		}

		#endregion

		public static bool RestartServer 
		{
			get { return m_restartserver; }
			set { m_restartserver = value; }
		}

		public static int MaxUsers
		{
			get { return m_maxUsers;}
			set { m_maxUsers = value;}
		}

		public static int TopUsers
		{
			get { return m_topUsers;}
		}

		public static int CurrentUsers
		{
			get { return Instance.ClientCount;}
		}

		public static IPEndPoint RemoteEndPoint
		{
			get
			{
				if (Instance.LocalEndPoint.Address.Equals(IPAddress.Any))
				{
//					return new IPEndPoint(IPAddress.Loopback, Instance.LocalEndPoint.Port);
					IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

					foreach (IPAddress ip in host.AddressList)
					{
						if (ip.AddressFamily == AddressFamily.InterNetwork)
							return new IPEndPoint(ip, Instance.LocalEndPoint.Port);
					}
					
					// Couldn't find any appropriate IPs.
					throw new Exception("Could not find an appropriate IP to expose");
				}
				else
					return Instance.LocalEndPoint;
			}
		}

		public static void SetWorldServer(ClientBase worldConnection, uint[] worldMapIDs)
		{
			DBWorldMap[] worldMaps = new DBWorldMap[worldMapIDs.Length];
			for(int i = 0;i < worldMapIDs.Length;i++)
			{
				worldMaps[i] = (DBWorldMap)DataServer.Database.FindObjectByKey(typeof(DBWorldMap), worldMapIDs[i]);
				if(worldMaps[i] == null)
					throw new Exception("Missing worldmap " + worldMapIDs[i]);
				if(m_worldMapServer.Contains(worldMaps[i].ObjectId))
					throw new Exception("There's already a worldserver handling worldmap " + worldMaps[i].ObjectId);
			}
			WorldConnection server = new WorldConnection(worldConnection, worldMaps);
			foreach(DBWorldMap map in worldMaps)
				m_worldMapServer[map.ObjectId] = server;
			m_worldServers.Add(server);
		}

		public static bool Start(IPEndPoint iep, int redirectPort, string externalIP)
		{
			return Instance.Start (iep) && RedirectServer.Instance.Start(new IPEndPoint(iep.Address, redirectPort), externalIP);
		}

		public static void Shutdown()
		{
			RedirectServer.Instance.Stop();
			Instance.Stop();
		}


		public static void BroadcastPacket(BinWriter pkg)
		{
			IEnumerator e = Instance.Clients.GetEnumerator();
			while(e.MoveNext())
				((LoginClient)e.Current).Send(pkg);
		}
	
		public static void SendWhoList(LoginClient whoClient)
		{
			BinWriter pkg = LoginClient.NewPacket(SMSG.WHO);
			pkg.Write((int)Instance.ClientCount);
			pkg.Write((int)Instance.ClientCount);
			IEnumerator e = Instance.Clients.GetEnumerator();
			//			int Group = 0; // 0 = No, 1 = Yes
			while(e.MoveNext())
			{
				try
				{
					pkg.Write((string)((LoginClient)e.Current).Character.Name);
					pkg.Write((string)((LoginClient)e.Current).Character.GuildName);
					pkg.Write((int)((LoginClient)e.Current).Character.Level);
					pkg.Write((int)((LoginClient)e.Current).Character.Class);
					pkg.Write((int)((LoginClient)e.Current).Character.Race);
					pkg.Write((int)((LoginClient)e.Current).Character.Zone);
					pkg.Write((int)((LoginClient)e.Current).Character.GroupLook);
				}
				catch (Exception)
				{
				}
			}
			whoClient.Send(pkg);
		}

		public static LoginClient GetLoginClientByCharacterID(uint id)
		{
			return (LoginClient)m_loginCharacters[id];
		}

		public static void PlayerLogin(LoginClient client, uint id)
		{
			if(client.Account == null)
			{
				client.Close("Tried to login with a character without an account.");
				return;
			}
			DataObject[] chars = DataServer.Database.SelectObjects(typeof(DBCharacter), "Character_ID = '" + id + "'");
			if(chars.Length == 0)
			{
				client.Close("Failed to find character in database?");
				return;
			}
			DBCharacter c = (DBCharacter)chars[0];
			if(c.AccountID != client.Account.ObjectId)
			{
				client.Close("Tried to login another account's character.");
				return;
			}
			client.Character = c;
			if (client.Character.GuildID!=0)
			{
				DBGuild guild = (DBGuild)DataServer.Database.FindObjectByKey((typeof(DBGuild)), client.Character.GuildID);
				if (guild!=null)
				{
					client.Character.Guild = guild;
					client.Character.GuildName=guild.Name;
				}
				else
				{
					client.Character.GuildID=0;
					client.Character.GuildRank=0;
					client.Character.GuildName=" ";
				}

			}
			string[] RemoteIP=client.RemoteEndPoint.ToString().Split(':');
			client.Account.LastIP=RemoteIP[0];
			if(c.WorldMapID == 0)
			{
				client.Close(c.Name + " is missing world map id.");
				return;
			}
			client.WorldConnection = (WorldConnection)m_worldMapServer[c.WorldMapID];
			if(client.WorldConnection == null)
			{
				client.Close("Missing worldserver for world map id " + c.WorldMapID);
				return;
			}
			m_loginCharacters[id] = client;
			FriendIsOnline(client);
			client.OnEnterWorld();
//			client.WorldConnection.OnEnterWorld(client.Character, client.Account.AccessLvl);
		}

		internal static void ChangeMap(LoginClient client)
		{
			client.WorldConnection = (WorldConnection)m_worldMapServer[client.Character.WorldMapID];
			if(client.WorldConnection == null)
			{
				client.Close("(ChangeMap) Missing worldserver for world map id " + client.Character.WorldMapID);
				return;
			}

			DBWorldMap map = (DBWorldMap)DataServer.Database.FindObjectByKey(typeof(DBWorldMap), client.Character.WorldMapID);
			client.Character.Continent = (uint)map.Continent;

			BinWriter pkg = LoginClient.NewPacket(SMSG.NEW_WORLD);
			pkg.Write((byte)client.Character.Continent);
			pkg.WriteVector(client.Character.Position);
			pkg.Write(client.Character.Facing);
			client.Send(pkg);
			FriendIsOnline(client);
			client.WorldConnection.OnEnterWorld(client.Character, client.Account.AccessLvl);
		}

		internal static void LeaveWorld(LoginClient client)
		{
			try
			{
				if(client.Character != null)
				{
					WorldPacket pkg = new WorldPacket(WORLDMSG.PLAYER_LEAVE_WORLD);
					pkg.Write(client.Character.ObjectId);
					client.WorldConnection.Send(pkg);
				}
			}
			catch(Exception e)
			{
				Console.WriteLine("An error happened in LeaveWorld function. Please report it!");
				Console.WriteLine(e);
			}
		}

		internal static void RemoveCharacter(LoginClient client)
		{
			if(client.Character != null)
			{
				m_loginCharacters.Remove(client.Character.ObjectId);
				if (client.Character.OnFriends!=null)
				{
					BinWriter flist = null;
					LoginClient FriendOnline=null;
					foreach (DBFriendList Friend in client.Character.OnFriends)
					{
						flist = LoginClient.NewPacket(SMSG.FRIEND_STATUS);
						FriendOnline = LoginServer.GetLoginClientByCharacterID(Friend.Owner_ID);
						if (FriendOnline!=null)
						{
							//							Chat.System(FriendOnline, client.Character.Name+" has Gone Offline");
							flist.Write((char)0x03);
							flist.Write((ulong)client.Character.ObjectId);
							FriendOnline.Send(flist);
						}
						FriendOnline=null;
						flist=null;
					}
				}
				client.Character = null;
			}
		}


		bool m_shutdown = false;
		private LoginServer()
		{
		}

		public override void Stop()
		{	
			m_shutdown = true;
			WorldPacket pkg = new WorldPacket(WORLDMSG.WORLD_SHUTDOWN);
			IEnumerator e = m_worldServers.GetEnumerator();
			while(e.MoveNext())
				((WorldConnection)e.Current).Send(pkg);

			base.Stop();
		}

		public override bool isBanned(IPAddress address)
		{
			//			DBBanned Banned = (DBBanned)DataServer.Database.FindObjectByKey(typeof(DBBanned), address.ToString());
			//			if(Banned != null)
			//				return true;
			return false;
		}

		public static void FriendIsOnline(LoginClient client)
		{
			LoginClient FriendOnline=null;
			BinWriter flist = null;
			if (client.Character.OnFriends!=null)
			{
				foreach (DBFriendList Friend in client.Character.OnFriends)
				{
				
					FriendOnline = LoginServer.GetLoginClientByCharacterID(Friend.Owner_ID);
					if (FriendOnline!=null)
					{
						flist = LoginClient.NewPacket(SMSG.FRIEND_STATUS);
						//						Chat.System(FriendOnline, client.Character.Name+" is Online");
						flist.Write((char)0x02);
						flist.Write((ulong)client.Character.ObjectId);

						flist.Write((int)client.Character.Zone);
						flist.Write((int)client.Character.Level);
						flist.Write((int)client.Character.Class);
						FriendOnline.Send(flist);
					}
					FriendOnline=null;
					flist = null;
				}
			}
		}

		public override void OnAcceptSocket(Socket sock)
		{
			if(m_shutdown || m_clients.Count >= MaxUsers)
			{
				sock.Close();
				return;
			}
			string[] RemoteIP = sock.RemoteEndPoint.ToString().Split(':');
			Console.WriteLine("RemoteEndPoint:" + RemoteIP[0]);
			DBBanned Banned = (DBBanned)DataServer.Database.FindObjectByKey(typeof(DBBanned), RemoteIP[0]);
			if(Banned != null)
			{
				sock.Close();
				return;
			}
			AddClient(new LoginClient(sock, this));
			if(m_clients.Count > m_topUsers)
				m_topUsers = m_clients.Count;
		}

		public override void OnClientData(ClientBase aClient, byte[] data)
		{
			LoginClient client = aClient as LoginClient;
			BinReader read = new BinReader(data);
			CMSG msgID;

			if (client.Authenticated == true)
			{
				// Why do we discard the first two bytes?
				read.BaseStream.Position += 2;
				byte[] header = read.ReadBytes(4);
				client.Decode(header,4);
				BinReader decoded = new BinReader(header);
				msgID = (CMSG)decoded.ReadInt32();
				/*BinReader ops = new BinReader(client.m_opcode);
				msgID = (CMSG)ops.ReadInt32();*/
			}
			else
			{
				read.BaseStream.Position += 2; // skip len
				msgID = (CMSG)read.ReadInt32();
			}

//			Console.WriteLine("CMSG:"+ msgID.ToString()); // log opcode to console
			if(!LoginPacketManager.HandlePacket(client, msgID, read))
			{
				Console.WriteLine("Login Handler not found for CMSG "+msgID + " ..sending to worldserver"); // report error

				if(client.WorldConnection != null)
				{
					ClientPacket pkg = new ClientPacket(msgID, client.Character.ObjectId, data, 6, data.Length-6);
					client.SendWorldServer(pkg);
				}
			}
		}
/*
		public override void OnClientLoopStop()
		{
			try 
			{
				IEnumerator e = new ArrayList(m_worldServers).GetEnumerator();
				while(e.MoveNext())
				{
					WorldConnection connection = (WorldConnection)e.Current;
					if(!connection.processWorldServerData())
					{
						if(m_shutdown == false)
						{
							Console.WriteLine("Lost connection to world server " + connection.ToString());
							LoginServer.Shutdown();
						}
						else
						{
							m_worldServers.Remove(connection);
						}
						DebugLogger.Log("Lost connection to world server " + connection.ToString() + " -- Server will be restarted!");
						LoginServer.RestartServer = true;
					}
				}

				if(m_shutdown && m_worldServers.Count == 0)
				{
					base.Stop();
				}

				Thread.Sleep(5);
			} 
			catch (Exception exp) 
			{
				if (exp.GetType() != typeof(ThreadAbortException))
					DebugLogger.Log("Will restart server!", exp);

				LoginServer.RestartServer = true;
			}
		}
		
		public override void OnClientLoopException(Exception exp) 
		{
			DebugLogger.Log("Will restart server!", exp);
			LoginServer.RestartServer = true;
		}*/
	}
}
