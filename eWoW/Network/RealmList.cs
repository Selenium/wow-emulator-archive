//#define CHECK

using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Security.Cryptography;


namespace eWoW
{
	/// <summary>
	/// RealmList
	/// </summary>
	public class RealmList : ISocket
	{
		public delegate void LogMessageHandler				(string message);
		public event LogMessageHandler						LogMessageEvent;

		DB accounts=null;
		Hashtable servers=new Hashtable();
		Hashtable skeys=new Hashtable();

		public RealmList(ushort port, string accountPath)
		{
			remote = "RealmList";
			sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			sock.Bind(new IPEndPoint(IPAddress.Any, port));
			sock.Listen(5);

			accounts = new DBDir(accountPath);

			SetTimerFunction("RealmListTick", 1000, new TimerFunction(OnTick));
			ServerGroup.SetHandle(ServerGroupMessageType.GameServerHeartBeat, new ServerGroupHandler(OnMsgHandler));
			ServerGroup.SetHandle(ServerGroupMessageType.UserQuery, new ServerGroupHandler(OnMsgHandler));
			ServerGroup.SetHandle(ServerGroupMessageType.UserSetChar, new ServerGroupHandler(OnMsgHandler));

			if (LogMessageEvent != null)
				LogMessageEvent( "start port={0} account={1} port:" + port + "accounts" + accounts.Count() );
		}

		public override void RunRecv()
		{
			RealmListConnection rlc = new RealmListConnection( sock.Accept(), this );
            rlc.LogMessageEvent += new eWoW.RealmListConnection.LogMessageHandler(rlc_LogMessageEvent);
			NetWork.Add( rlc );
		}

		public override int Timeout()
		{
			return 0;
		}

		public byte[] GetUserPasswordHash(string name)
		{
			Hashtable h = accounts.Get(name.ToLower());
			if (h == null)return null;

			SHA1 sha = new SHA1CryptoServiceProvider(); 
			byte[] user=Encoding.ASCII.GetBytes(name + ":" + (string)h["PASSWORD"]);
			return sha.ComputeHash( user, 0 , user.Length ); 
		}

		public void SetUserSessionKey(string nm, byte[] sk)
		{
			nm = nm.ToLower();
			skeys[nm] = sk;

			// ÈÃGameServerÌßµôËû
			Hashtable h = new Hashtable();
			h["Name"] = nm;
			ServerGroup.Send(ServerGroupMessageType.UserLogin, h);
		}

		public void OnMsgHandler(ServerGroupMessageType type, Hashtable msg)
		{
			if(type==ServerGroupMessageType.GameServerHeartBeat)
			{
				string nm=msg["Name"] as string;
				if(nm==null)return;

				msg["UpdateTick"]=Const.Tick;
				servers[nm]=msg;
			}

			// GameServer ask username & SessionKey
			if(type==ServerGroupMessageType.UserQuery)
			{
				string nm=msg["Name"] as string;
				if(nm==null)return;
				nm=nm.ToLower();


				Hashtable user=accounts.Get(nm);
				if(user==null)return;

				if(skeys.Contains(nm))
					user["SESSIONKEY"]=skeys[nm];
				user["Hash"]=msg["Hash"];
				ServerGroup.Send(ServerGroupMessageType.UserReply, user);
			}
			if(type==ServerGroupMessageType.UserSetChar)
			{
				string nm=msg["Name"] as string;
				if(nm==null)return;
				nm=nm.ToLower();


				Hashtable user=accounts.Get(nm);
				if(user==null)return;

				foreach(string n in msg.Keys)
				{
					if(!n.StartsWith("CHAR "))continue;
					user[n]=msg[n];
				}
				accounts.Set(nm, user);
			}
		}

		void OnTick()
		{
			ArrayList remove = new ArrayList();
			foreach(string nm in servers.Keys)
			{
				Hashtable h = servers[nm] as Hashtable;

				int tick = (int)h["UpdateTick"];
				if(Const.Tick - tick > 600*1000)
				{
					remove.Add(nm);
				}
			}

			foreach(string nm in remove)
			{
				servers.Remove(nm);
			}
		}

		public void GetRealmList(string nm, ByteArrayBuilder pack)
		{
			Hashtable user = accounts.Get(nm.ToLower());
			if(user == null)
			{
				pack.Add( (byte)0 );
				return;
			}

			pack.Add( (byte)servers.Count );
			foreach(string svr in servers.Keys)
			{
				Hashtable h = servers[svr] as Hashtable;
				
				if( ((string)h["Type"]).ToLower() == "pvp")
					pack.Add( (uint)1 );
				else
					pack.Add( (uint)0 );

				// 
				int tick = (int)h["UpdateTick"];
				if(Const.Tick - tick > 30*1000)
					pack.Add( (byte)1);
				else
                    pack.Add( (byte)0); // 0 - green, 1 - red, 2 - grey (offline)*/

				pack.Add( svr ); // Jmeno serveru

				pack.Add( (string)h["Address"] );
                //h["UserCount"];
				pack.Add( (uint)0); // Pripojenych uzivatelu nebo timezone?

				string charnm = "CHAR " + svr; // pocet postav na accountu
				if(user.Contains(charnm))
				{
					pack.Add( (byte)((string)user[charnm]).Split(' ').Length );
				} 
				else 
				{
					pack.Add( (byte)0 );
				}
				pack.Add((byte)0,0); // Prvni byte je narodnost serveru 0,1 - english atd.. Druhy byte meni pozadi pro postavy pouze kdyz je postav 0
			}
		}

		private void rlc_LogMessageEvent(string message)
		{
			if (LogMessageEvent != null)
				LogMessageEvent( message );
		}
	}
}