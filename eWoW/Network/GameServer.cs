using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Collections;

namespace eWoW
{
    /// <summary>
    /// GameServer
    /// </summary>

    public class GameServer : ISocket 
	{
		public delegate void LogMessageHandler				(string message);
		public event LogMessageHandler						LogMessageEvent;

		uint      nextGUID=1;
		string    dbPath;
		string    name;
		string    type;

		// dny data
		int       tickSave=0;
		ArrayList clients=new ArrayList();
		Hashtable characters=null; // name -> int[2]
		Hashtable characterids=null; // id -> name
		Hashtable charactersaves=null; // name -> byte[]
		PPoint    ppoint=null;
		GameDB    db=null;
		Spawn     spawn;
		Hashtable objs=new Hashtable(); // GUID -> ObjWithPosition
		ArrayList objRemove=new ArrayList();

		public GameServer()
		{}

        public void Start(IPEndPoint addr, string path, ServerConfig conf)
		{
			spawn = new Spawn(this);
            spawn.LogMessageEvent += new eWoW.Spawn.LogMessageHandler(spawn_LogMessageEvent);
			remote = "GameServer";
			dbPath = path;

            type = conf.ServerRules;
            name = conf.ServerName;

			db = new GameDB(this, path);

			LoadScript();
			LoadWorld();

			sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			sock.Bind(addr);
			sock.Listen(5);
		
			SetTimerFunction("GameServerTick", 1000, new TimerFunction(OnTick));
			SetTimerFunction("GameServerTick100ms", 100, new TimerFunction(OnTick100ms));
			ServerGroup.SetHandle(ServerGroupMessageType.UserReply, new ServerGroupHandler(OnMsgHandler));

			ServerGroup.SetHandle(ServerGroupMessageType.UserLogin, new ServerGroupHandler(OnMsgHandler));

			_channel = new Channel(this);
            LogMessage("Start at " + name + " " + addr.ToString());
		}


		void LoadWorld()
		{
			ppoint=new PPoint(dbPath + "/saves/ppoints.save");
			LogMessage("PPoint: " + ppoint.TotalCount());

			spawn.Load(dbPath);
			LogMessage("worldData: " + spawn.worldData.Count);


			characterids=new Hashtable();
			characters=new Hashtable();

			string bin=dbPath + "/saves/charname.bin";
			if(File.Exists(bin))
			{
				using(FileStream fs=new FileStream(bin, FileMode.Open, FileAccess.Read))
			    {
					characters=(new DBSerial(fs)).Deserialize() as Hashtable;
				}

				foreach(string nm in characters.Keys)
				{
					int[] data=characters[nm] as int[];
					characterids[ data[0] ] = nm;
				}
			}

			LogMessage("Characters: " + characters.Count);
		}

		public void SaveWorld()
		{
			// save points
			ppoint.Save();
			LogMessage("ppoint saved.");
			// save spawns
			SaveSpawns();
			LogMessage("spawns saved.");
			// save players
			SavePlayers();
			LogMessage("players saved.");
			Wall("World saved.");
		}

		public void SaveSpawns()
		{
			spawn.Save(dbPath);
		}

		public void SavePlayers()
		{
			string bin=dbPath + "/saves/charname.bin";
			using(FileStream fs=new FileStream(bin, FileMode.Create, FileAccess.Write))
			{
				(new DBSerial(fs)).Serialize(characters);
			}

			foreach(PlayerConnection cn in clients)
			{
				if(cn.player==null)continue;
				SaveCharacter(cn.player.Name, cn.player.GetSaveData());
			}

			if(charactersaves!=null)
			{
				Hashtable c=new Hashtable();
				foreach(string nm in charactersaves.Keys)
				{
					string nidx=nm.Substring(0,1).ToLower();

					Hashtable h=c[nidx] as Hashtable;
					if(h==null)
					{
						h=LoadChars(nidx);
						c[nidx]=h;
					}
					h[nm]=charactersaves[nm];
				}
				foreach(string nidx in c.Keys)
				{
					SaveChars(nidx, c[nidx] as Hashtable);
				}
				charactersaves=null;
			}
		}

		Hashtable LoadChars(string nidx)
		{
			string bin=dbPath + "/saves/char_" + nidx + ".bin";
			Hashtable h=null;
			if(File.Exists(bin))
			{
				try 
				{
					using(FileStream fs=new FileStream(bin, FileMode.Open, FileAccess.Read))
					{
						h=(new DBSerial(fs)).Deserialize() as Hashtable;
					}
				}
				catch
				{
					h=null;
				}
			}
			if(h==null)h=new Hashtable();
			return h;
		}

		void SaveChars(string nidx, Hashtable h)
		{
			string bin=dbPath + "/saves/char_" + nidx + ".bin";

			using(FileStream fs=new FileStream(bin, FileMode.Create, FileAccess.Write))
			{
				( new DBSerial(fs) ).Serialize(h);
			}
		}

		public void LoadScript()
		{
		}

		public override void RunRecv()
		{
			PlayerConnection p=new PlayerConnection(this, sock.Accept() );
            p.LogMessageEvent += new eWoW.PlayerConnection.LogMessageHandler(p_LogMessageEvent);
			NetWork.Add( p );
			clients.Add( p );
		}


		public override int Timeout()
		{
			return 0;
		}

		public void ReqSaveWorld()
		{
			tickSave=Const.Tick;
		}

		void OnTick()
		{
			ArrayList allObjs=new ArrayList();
			allObjs.AddRange( objs.Values );
			foreach(ObjWithPosition ob in allObjs)
			{
				ob.UpdateInRange(allObjs, objRemove);
			}

			if(clients.Count>0)
			{
				ArrayList remove=new ArrayList();
				foreach(PlayerConnection p in clients)
				{
					if(!p.Connected())remove.Add(p);
				}
				foreach(PlayerConnection p in remove)
				{
					clients.Remove(p);
				}

				foreach(PlayerConnection p in clients)
				{
					if(p.player==null)continue;
					p.player.BuildUpdateForSet();
				}

				foreach(PlayerConnection p in clients)
				{
					if(p.player==null)continue;
					p.player.SendUpdate(false);
				}
			}

			// clear objs
			foreach(ObjWithPosition ob in objRemove)
			{
				objs.Remove(ob.GUID);
			}
			objRemove.Clear();

			// GameServerHeartBeat

			Hashtable svr=new Hashtable();
			svr["Name"] = name;
            svr["Type"] = type; // Jedna se o typ serveru PVP nebo pve nebo rp
			svr["Address"] = sock.LocalEndPoint.ToString();
			svr["UserCount"] = (uint)clients.Count;
			ServerGroup.Send(ServerGroupMessageType.GameServerHeartBeat, svr);

			if(tickSave>0 && tickSave<=Const.Tick)
			{
				SaveWorld();
				tickSave=Const.Tick + 600*1000;
			}

			System.GC.Collect();

			if((nextGUID & (1<<Const.GUID_BITS) )!=0)NetWork.Stop=true;
		}

		void OnTick100ms()
		{
			ICollection allObjs=objs.Values;
			foreach(ObjWithPosition ob in allObjs)
			{
				ob.Update();
			}
		}

		void OnMsgHandler(ServerGroupMessageType type, Hashtable msg)
		{
			if(type==ServerGroupMessageType.UserReply)
			{
				int hash=(int)msg["Hash"];

				msg["CHAR"]=msg["CHAR " + name];
				foreach(PlayerConnection p in clients)
				{
					if(p.GetHashCode()==hash && p.SetUserReply(msg))break;
				}
				return;
			}
			if(type==ServerGroupMessageType.UserLogin)
			{
				string name=msg["Name"] as string;
				if(name==null)return;

				// relogin, drop it
				foreach(PlayerConnection c in clients)
				{
					if(name == c.userName)
					{
						c.Dispose();
						break;
					}
				}
			}
		}

		public string Type
		{
			get 
			{
				return type;
			}
		}

		public string Name
		{
			get 
			{
				return name;
			}
		}

		public uint NextGUID()
		{
			while(true)
			{
				uint n=nextGUID++;
				if(!characterids.Contains( (int)n ))return n;
			}
		}


		public void AddCharacter(string name, ulong guid, byte race, byte gender, byte cls)
		{
			int[] data=new int[2];
			data[0]=(int)guid;
			data[1]=race + (gender<<8) + (cls<<16);

			characters[name]=data;
			characterids[data[0]]=name;
		}

		public void DelCharacter(Character c)
		{
			DelObj(c);
			characters.Remove(c.Name);
			characterids.Remove( (int)c.GUID );
		}

		public Character LoadCharacter(PlayerConnection conn, ulong guid)
		{
			Character c=GetObj(guid) as Character; // already in game?
			if(c!=null)return c;
			string name=characterids[(int)guid] as string;
			if(name==null)return null;

			// in save cache?
			byte[] b=null;
			if(charactersaves!=null && charactersaves.Contains(name))
			{
				b=charactersaves[name] as byte[];
			}

			// in save file?
			if(b==null)
			{
				Hashtable h=LoadChars(name.Substring(0,1).ToLower());
				if(h==null || !h.Contains(name))return null;
				b=h[name] as byte[];
			}

			c=new Character(this);
			if(!c.Create(guid, name, b))return null;
			AddObj(c);
			return c;
		}

		public Character LoadCharacter(PlayerConnection conn, string name)
		{
			ulong guid=GetCharacter(name);
			if(guid==0)return null;
			return LoadCharacter(conn, guid);
		}

		public void SaveCharacter(string name, byte[] data)
		{
			if(charactersaves==null)charactersaves=new Hashtable();
			charactersaves[name]=data;
		}

		public ulong GetCharacter(string name)
		{
			int[] data=characters[name] as int[];
			if(data==null)return 0;
			return (ulong)data[0];
		}

		public string GetCharacter(ulong guid, out byte race, out byte gender, out byte cls)
		{
			race=gender=cls=0;
			string nm=characterids[(int)guid] as string;
			if(nm==null)return null;

			int[] data=characters[nm] as int[];
			if(data==null)return null;

			race=(byte)data[1];
			gender=(byte)(data[1]>>8);
			cls=(byte)(data[1]>>16);
			return nm;
		}

		public void SetChar(string userName, string chars)
		{
			Hashtable svr=new Hashtable();
			svr["Name"] = userName;
			svr["CHAR " + name] = chars;
			ServerGroup.Send(ServerGroupMessageType.UserSetChar, svr);
		}

		//public GameServer gameServer=null;
		public Channel _channel=null;



		public PPoint PPoint
		{
			get 
			{
				return this.ppoint;
			}
		}

		public void RefrencePosition(ObjWithPosition c)
		{
			this.spawn.TrySpawnObj(c.Map, c.Pos);
		}

		public bool AddObj(ObjWithPosition c)
		{
			this.objs[ c.GUID ] = c;
			return true;
		}

		public bool DelObj(ObjWithPosition c)
		{
			if(!this.objs.Contains( c.GUID ))return false;
			if(this.objRemove.Contains(c))return true;
			this.objRemove.Add(c);
			return true;
		}

		public ObjWithPosition GetObj(ulong guid)
		{
			if(this.objs.Contains(guid))return (ObjWithPosition)this.objs[guid];
			return null;
		}

		public Item GetItem(ulong guid)
		{
			Character c=GetObj( (uint)(guid>>Const.GUID_BITS) ) as Character;
			if(c==null)return null;
			return c.GetItem(guid);
		}

		public int OnlinePlayerCount
		{
			get
			{
				return GetOnline().Count;
			}
		}

		public ArrayList GetOnline()
		{
			ArrayList us=new ArrayList();
			foreach(PlayerConnection c in this.clients)
			{
				if(!c.Connected() || c.player==null)continue;
				us.Add(c.player);
			}
			return us;
		}

		public void Wall(string msg)
		{
			ByteArrayBuilder pack=new ByteArrayBuilder(false);
			pack.Add((byte)CHAT.SYSTEM)
				.Add((uint)0, 0, 0, 0);
			pack.Add(msg);
			pack.Add((byte)0);
			pack.Set(13, (ushort)(pack.Length-18) );

			foreach(Character c in GetOnline())
			{
				c.Send(OP.SMSG_MESSAGECHAT, pack);
			}
		}

		public Channel Channel 
		{
			get
			{
				return _channel;
			}
		}

		public GameDB DB
		{
			get 
			{
				return this.db;
			}
		}

		public GameServer instance 
		{
			get 
			{
				return this;
			}
		}

		public void LogMessage( string from, string fmt, params object[] obs )
		{
			string output = "";
			for (int i=0;i<obs.Length;i++)
				output += " " + obs[i].ToString() + " ";

			string s = from + fmt + output;
			if (LogMessageEvent != null)
				LogMessageEvent ( s );
		}

		public void LogMessage (string message)
		{
			if (LogMessageEvent != null)
				LogMessageEvent ( message );
		}

		private void p_LogMessageEvent(string message)
		{
			if (LogMessageEvent != null)
				LogMessageEvent ( message );
		}

		private void spawn_LogMessageEvent(string message)
		{
			if (LogMessageEvent != null)
				LogMessageEvent ( message );
		}
	}

}
