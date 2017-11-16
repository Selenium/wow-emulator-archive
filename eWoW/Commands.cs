using System;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Collections;
using System.Reflection;

namespace eWoW
{

    public class ServerConfig
    {
        public string ServerName;
        public string ServerRules; // PVP or PVE or RP
        public string Address; // Realm Address
        public ushort RealmListPort; // default 3724
        public ushort WorldServerPort; // default 8085
        public ServerConfig() { }
    }	
    
    /// <summary>
	/// Summary description for Commands.
	/// </summary>
	/// 
	public class Commands
	{
		public GameServer gameServer;

		public delegate void LogMessageHandler					(string message);
		public delegate void ServerStartedHandler				();
		public delegate void ServerStoppedHandler				();

		public event ServerStartedHandler						ServerStarted;
		public event LogMessageHandler							LogMessageEvent;
		public event ServerStoppedHandler						ServerStopped;

		public Commands()
		{

		}

		public static Thread ServerThread;
		public bool StartServer()
		{
			if (ServerThread == null)
			{
				ServerThread=new Thread(new ThreadStart(StartServerThread));
				ServerThread.Name = "ServerThread";
				ServerThread.Start();
				return true;
			}
			else
			{
				return false;
			}
		}

		public void StopServerAndSave()
		{
			gameServer.instance.SaveWorld();
			StopServer();
		}

		public bool StopServer()
		{
			if (ServerThread != null)
			{
				gameServer.instance.Dispose();
				ServerThread.Abort();
				ServerThread.Join();
				ServerThread = null;
				if (ServerStopped != null)
					ServerStopped();
				return true;
			}
			else
			{
				return false;
			}
		}

		private string		url;
		private	IPAddress	ip;
		public	IPAddress	Ip
		{
			get
			{
				try
				{
					ip = resolveIP( getString(url) );
					if (ip == null)
						validIp = false;
					else
						validIp = true;
					return ip;
				}
                catch (Exception exp)
				{
					validIp = false;
					//Log.LogError (exp);
                    Console.WriteLine(exp);
                    return null;
				}
			}
		}

		private IPAddress resolveIP( string ipa )
		{
			IPAddress ad = null;
			if (ipa == null)						return null;
			if (ipa.Trim() == String.Empty)		return null;

			IPHostEntry hostInfo = Dns.GetHostEntry( ipa );
			try
			{
				if (hostInfo != null)
				{
					if (hostInfo.AddressList != null)
					{
						if (hostInfo.AddressList.Length > 0)
						{
							ad = hostInfo.AddressList[0];
						}
						else
						{
							ad = null;
						}
					}
					else
					{
						ad = null;
					}
				}
			}
			catch(Exception exp)
			{
                //Log.LogError( exp );
                Console.WriteLine(exp);
			}
			return ad;
		}


        

		protected string getString(string st)
		{
			if( st == null ) return string.Empty;
			return st;
		}

		private bool validIp;
		public bool ValidIP
		{
			get
			{
				IPAddress ip = Ip;
				return validIp;
			}
		}

		public void StartServerThread()
		{
            Console.WriteLine("eWoW " + eWoWClass.version + "(c) DjAli");
            XmlSerializer serializer = new XmlSerializer(typeof(ServerConfig));
            ServerConfig srvconf = (ServerConfig)serializer.Deserialize(XmlReader.Create("eWoW.config"));

#region if check
#if CHECK

			StreamWriter w=new StreamWriter("op.txt", false);
			for(ushort c=0; c<=(ushort)OP.NUM_MSG_TYPES; c++)
			{
				string msg=((OP)c).ToString() + ",";
				if(msg.Length<40)msg+=new string(' ', 40-msg.Length);
				w.WriteLine("    {0} // = 0x{1:X}", msg, c);
			}
			w.Close();
			
			Hashtable mt=new Hashtable();
			foreach(MemberInfo m in typeof(UpdateFields).GetMembers())
			{
				FieldInfo f=m as FieldInfo;
				if(f==null || !f.IsStatic)continue;
				ushort v=(ushort)f.GetValue(null);
				string n=m.Name;
				int pos=n.IndexOf('_');
				if(pos<0)continue;

				Hashtable h=mt[ n.Substring(0, pos) ] as Hashtable;
				if(h==null)
				{
					h=new Hashtable();
					mt[ n.Substring(0, pos) ]=h;
				}
				if(h.Contains(v))
				{
					h[v]=(h[v] as string) + "," + m.Name;
				} 
				else 
				{
					h[v]=m.Name;
				}
			}

			w=new StreamWriter("up.txt", false);
			foreach(string k in new string[]{"OBJECT", "ITEM", "CONTAINER", "UNIT", "PLAYER", "GAMEOBJECT", "DYNAMICOBJECT", "CORPSE"})
			{
				Hashtable h=mt[k] as Hashtable;
				ArrayList datav=new ArrayList();
				datav.AddRange(h.Keys);
				datav.Sort();

				w.WriteLine("");
				w.WriteLine("    // {0}", k);

				string begin=null;
				ushort beginv=0;
				for(int i=0; i<datav.Count; i++)
				{
					ushort v=(ushort)datav[i];
					string ns=h[v] as String;

					foreach(string _n in ns.Split(','))
					{
						string n=_n;
						if(n.Length<30)n+=new string(' ', 30-n.Length);

						if(begin==null)
						{
							w.WriteLine("    {0} = 0x{1:X}, // pos={1}" , n,  v);
						}
						else if(i<datav.Count-1)
						{
							int size=(ushort)datav[i+1] - (ushort)datav[i];
							w.WriteLine("    {0} = 0x{1:X} + {2}, // size={3}, pos={4}", n,  v-beginv, begin, size, v);
						} 
						else 
						{
							w.WriteLine("    {0} = 0x{1:X} + {2}, // pos={3}", n,  v-beginv, begin, v);
						}

						if(begin==null)
						{
							begin=n.Trim();
							beginv=v;
						}
					}
				}
			}
			w.Close();
#endif
#endregion end if check
            ServerGroup.Start(srvconf.RealmListPort);

            url = srvconf.Address; 


			if( IPAddress.Parse( Ip.ToString() ).Equals(IPAddress.Loopback) )
			{
                RealmList rserver = new RealmList(srvconf.RealmListPort, "accounts");
                rserver.LogMessageEvent += new eWoW.RealmList.LogMessageHandler(rserver_LogMessageEvent);
				NetWork.Add( rserver );
			}
			
			//if(gameServer!=null)return;
			//new IPEndPoint(IPAddress.Parse(r["ws_host"] as string), ushort.Parse(r["ws_port"] as string)), ".", db
            System.Net.IPEndPoint addr = new IPEndPoint(Ip, srvconf.WorldServerPort);
			string path = ".";
			gameServer = new GameServer();
            gameServer.LogMessageEvent += new eWoW.GameServer.LogMessageHandler(gameServer_LogMessageEvent);
            gameServer.Start(addr, path, srvconf);
			NetWork.Add( gameServer );

			//GameServer.Start( );
            srvconf = null;

			if (ServerStarted != null)
				ServerStarted();
			NetWork.Run();
			if (ServerStopped != null)
				ServerStopped();
			if (LogMessageEvent != null)
				LogMessageEvent( "SYSTEM" + "stop" );


		}

		private void gameServer_LogMessageEvent(string message)
		{
			// this.LogMessageEvent ( message ); // For Win Loader
            Console.WriteLine(message); // For console Loader
		}

		private void rserver_LogMessageEvent(string message)
		{
			// this.LogMessageEvent ( message ); // For Win Loader
            Console.WriteLine(message); // For console Loader
		}
	}
}
