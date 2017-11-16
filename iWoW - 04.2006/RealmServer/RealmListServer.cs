using System;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Threading;
using System.Text;
using System.Security.Cryptography;
using WoWDaemon.Common;
using WoWDaemon.Login;
using WoWDaemon.Database.DataTables;

namespace WoWDaemon.Realm
{
	public class RealmWarning : Exception
	{
		public RealmWarning(string msg) : base(msg)
		{
		}
	}

	class RealmListUpdaterServer : ServerBase
	{
		public string UpdaterPassword = string.Empty;

		private RealmListServer m_server;

		internal RealmListUpdaterServer(RealmListServer server)
		{
			m_server = server;
		}

		public override void  Stop()
		{
 			base.Stop();
			/* I think this happens on base.Stop() anyway when the server socket is closed.
			if(base.Clients.Count > 0)
			{
				IEnumerator e = new ArrayList(base.Clients).GetEnumerator();
				while(e.MoveNext())
					((ClientBase)e.Current).Close("Server shutting down.");
			}*/
		}

		public override void RemoveClient(ClientBase client)
		{
			m_server.RemoveRealm(client.RemoteEndPoint.ToString());
 			base.RemoveClient(client);
		}

		public override void OnClientData(ClientBase client, byte[] data)
		{
			BinReader read = new BinReader(data);
			read.BaseStream.Position += 4;//client.PacketHeaderSize;
			string pass = read.ReadString();
			if(pass != UpdaterPassword)
			{
//				client.Close("Wrong updater password");
				return;
			}

			m_server.UpdateRealm(client.RemoteEndPoint.ToString(),
				read.ReadString(), read.ReadString(), read.ReadInt32());
		}
	}

	public class RealmListServer : ServerBase
	{
		public static readonly RealmListServer Instance = new RealmListServer();
//		Socket m_realmUpdateListener = null;
//		Hashtable m_updateClients = new Hashtable();
		RealmListUpdaterServer m_updater_server;
		
		private RealmListServer()
		{
			m_updater_server = new RealmListUpdaterServer(this);
		}

		public bool Start(IPEndPoint iep, int updaterPort)
		{
			bool success = base.Start(iep);

			if (success)
			{
				iep.Port = updaterPort;
				success = m_updater_server.Start(iep);
			}

			return success;
		}

		public override void Stop()
		{
			m_updater_server.Stop();

			realms.Clear();
			base.Stop();
		}

		public override void OnClientData(ClientBase aClient, byte[] data)
		{
			RealmListClient client = aClient as RealmListClient;
			client.LastActivity = DateTime.Now;

			BinReader read = new BinReader(data);
			REALMLISTOPCODE opCode = (REALMLISTOPCODE)read.ReadByte();
			Console.WriteLine("REALMLIST: " + opCode);
			switch(opCode)
			{
				case REALMLISTOPCODE.CHALLENGE: // 0x00
				case REALMLISTOPCODE.RECODE_CHALLENGE: //0x02
				{					
					realm_challenge(read,client);
					break;
				}

				case REALMLISTOPCODE.PROOF: // 0x01
				case REALMLISTOPCODE.RECODE_PROOF: // 0x03
				{
					realm_proof(read, client);
					break;
				}

				case REALMLISTOPCODE.REALMLIST_REQUEST: // 0x10
				{
					client.Send(realmList); 
					client.Close("Done");
					break;
				}
			}
		}

		public string UpdaterPassword
		{
			set
			{
				m_updater_server.UpdaterPassword = value;
			}
		}

		public override bool isBanned(IPAddress address)
		{
			return false;
		}

		public override void OnAcceptSocket(Socket sock)
		{
			ClientBase client = new RealmListClient(sock);
			AddClient(client);
		}

		DateTime LastActivityCheck = DateTime.Now;
		bool DoActivityCheck = false;
		/*		public override void OnClientLoopStart()
				{
					TimeSpan span = DateTime.Now.Subtract(LastActivityCheck);
					if(span.TotalSeconds > 300)
						DoActivityCheck = true;
				}

				public override void OnClientLoop(ClientBase aClient)
				{
					if(DoActivityCheck)
						if(aClient.Timedout)
						{
							aClient.Close("Timed out");
							RemoveClient(aClient);
						}
				}

				public override void OnClientLoopStop()
				{
					if(DoActivityCheck)
						DoActivityCheck = false;
					realmUpdaterLoop();
					TimeSpan span = DateTime.Now.Subtract(LastRealmListUpdate);
					if(span.TotalSeconds > 300)
						UpdateList();
					Thread.Sleep(50);
				}
		*/
		#region Realm list management
		struct RealmInfo
		{
			public int Users;
			public string Description;
			public string IP;
			public DateTime LastUpdate;
			public RealmInfo(string desc, string ip, int users)
			{
				Users = users;
				Description = desc;
				IP = ip;
				LastUpdate = DateTime.Now;
			}
		}

		byte[] realmList = {0x10, 0x05, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00};
		Hashtable realms = new Hashtable();
		bool realmListDirty = true;
		internal void UpdateRealm(string UpdaterIP, string Description, string IP, int Users)
		{
			realms[UpdaterIP] = new RealmInfo(Description, IP, Users);
			realmListDirty = true;
			UpdateList();
		}

		internal void RemoveRealm(string UpdaterIP)
		{
			if(realms.Contains(UpdaterIP) == false)
				return;
			realms.Remove(UpdaterIP);
			realmListDirty = true;
			UpdateList();
		}

		public void AddRealmUpdateClient(ClientBase client)
		{
			m_updater_server.AddClient(client);
		}

		DateTime LastRealmListUpdate = DateTime.MinValue;
		#region UpdateList
		private void UpdateList()
		{
			LastRealmListUpdate = DateTime.Now;
			if(realms.Count > 0)
			{
				ArrayList list = new ArrayList(realms.Values);
				DateTime now = DateTime.Now;
				TimeSpan span;
				foreach(RealmInfo info in list)
				{
					span = now.Subtract(info.LastUpdate);
					if(span.TotalSeconds > 30)
					{
						realms.Remove(info.IP);
						realmListDirty = true;
					}
				}
			}

			if(realmListDirty)
			{
				realmListDirty = false;
				BinWriter w = new BinWriter();
				w.Write((byte)0x10);
				w.Write((short)0);
				w.Write(0);
				w.Write((byte)realms.Count);
				if(realms.Count > 0)
				{
					IEnumerator e = realms.Values.GetEnumerator();
					while(e.MoveNext())
					{
						//						Console.WriteLine("Realm: ");
						RealmInfo info = (RealmInfo)e.Current;
						w.Write(0);
						w.Write((byte)0);
						w.Write(info.Description);
						w.Write(info.IP);
						w.Write(info.Users);
						w.Write(0);
						w.Write((byte)0);
					}
					w.Set(1, (short)(w.BaseStream.Length-3));
					byte[] newList = new byte[w.BaseStream.Length];
					Array.Copy(w.GetBuffer(), 0, newList, 0, newList.Length);
					realmList = newList;
				}
			}
		}
		#endregion
		#endregion

		#region SRP Functions

		static byte []N = { 0x89, 0x4B, 0x64, 0x5E, 0x89, 0xE1, 0x53, 0x5B, 
							  0xBD, 0xAD, 0x5B, 0x8B, 0x29, 0x06, 0x50, 0x53, 
							  0x08, 0x01, 0xB1, 0x8E, 0xBF, 0xBF, 0x5E, 0x8F, 
							  0xAB, 0x3C, 0x82, 0x87, 0x2A, 0x3E, 0x9B, 0xB7 }; 
		static byte []rN = Reverse( N ); 
        
		public void realm_challenge(BinReader read, RealmListClient client)
		{
			int t;
			BinWriter pkg;
			byte[] useless = read.ReadBytes(32);
			int namelen = read.ReadByte();

			client.Busername = read.ReadBytes(namelen);
			client.username = System.Text.Encoding.ASCII.GetString(client.Busername);

			getPassword(client);

			if(client.password == null)
			{
				Console.WriteLine("Can not retreive password for: " + client.username);						
				pkg = new BinWriter();
				pkg.Write((byte)1);
				pkg.Write((byte)3);
				client.Send(pkg.GetBuffer(),26);
				client.Close("Accountless");
			}

			byte []hash = GetUserPasswordHash(client.username,client.password);
			
			if(hash==null)
			{	
				Console.WriteLine("Can not calculate hash for: " + client.username);						
				pkg = new BinWriter();
				pkg.Write((byte)1);
				pkg.Write((byte)3);
				client.Send(pkg.GetBuffer(),26);
				client.Close("Accountless");
			}

			byte []res = new Byte[ hash.Length + client.salt.Length ]; 
			Const.rand.NextBytes( client.salt );

			t = 0; 
			foreach( byte s in client.salt ) res[ t++ ] = s; 
			foreach( byte s in hash ) res[ t++ ] = s; 

			SHA1 sha = new SHA1CryptoServiceProvider(); 
			byte []hash2 = sha.ComputeHash( res, 0, res.Length ); 
			byte []x = Reverse( hash2 ); 

			rN = Reverse( N ); 
			Const.rand.NextBytes( client.b ); 

			client.rb = Reverse( client.b ); 

			BigInteger bi = new BigInteger( x ); 
			BigInteger bi2 = new BigInteger( rN ); 
			client.G = new BigInteger( new byte[] { 7 } ); 
			client.v = client.G.modPow( bi, bi2 ); 
			
			client.K = new BigInteger( new Byte[] { 3 } ); 
			BigInteger temp1 = client.K * client.v; 
			BigInteger temp2 = client.G.modPow( new BigInteger( client.rb ), new BigInteger( rN ) ); 
			BigInteger temp3 = temp1 + temp2; 
			client.B = temp3 % new BigInteger( rN );

			pkg = new BinWriter();
			pkg.Write((byte)0);
			pkg.Write((byte)0);
			pkg.Write((byte)0);
			pkg.Write(Reverse( client.B.getBytes(32) ));
			pkg.Write((byte)1);
			pkg.Write((byte)7);
			pkg.Write((byte)32);
			pkg.Write(N);
			pkg.Write(client.salt);
			pkg.Write((byte[])new byte[16]);
			
			client.Send(pkg.GetBuffer(),118);
		}

		public void realm_proof(BinReader read, RealmListClient client)
		{	
			int t;
			byte[] A= read.ReadBytes(32);
			byte[] kM1= read.ReadBytes(20);
			
			byte []rA = Reverse(A); 
			
			byte []AB = Concat( A, Reverse( client.B.getBytes(32) ) ); 

			SHA1 shaM1 = new SHA1CryptoServiceProvider(); 
			byte []U = shaM1.ComputeHash( AB );       
			
			byte []rU = Reverse( U );                
			
			// SS_Hash
			BigInteger temp1 = client.v.modPow( new BigInteger( rU ), new BigInteger( rN ) ); 
			BigInteger temp2 = temp1 * new BigInteger( rA ); 
			BigInteger temp3 = temp2.modPow( new BigInteger( client.rb ), new BigInteger( rN ) ); 

			byte []S1 = new byte[ 16 ]; 
			byte []S2 = new byte[ 16 ]; 
			byte []S = temp3.getBytes(32); 
			byte []rS = Reverse( S ); 
			
			for( t = 0;t < 16;t++) 
			{ 
				S1[ t ] = rS[ t * 2 ]; 
				S2[ t ] = rS[ ( t * 2 ) + 1 ]; 
			} 

			byte []hashS1 = shaM1.ComputeHash( S1 ); 
			byte []hashS2 = shaM1.ComputeHash( S2 ); 
			byte []SS_Hash = new byte[ hashS1.Length + hashS2.Length ]; 
			for( t = 0;t < hashS1.Length ;t++ ) 
			{ 
				SS_Hash[ t * 2 ] = hashS1[ t ]; 
				SS_Hash[ ( t * 2 ) + 1 ] = hashS2[ t ]; 
			} 

			// cal M1
			byte []NHash = shaM1.ComputeHash( N ); 
			byte []GHash = shaM1.ComputeHash( client.G.getBytes() ); 
			byte []userHash = shaM1.ComputeHash( client.Busername ); 
			byte []NG_Hash = new byte[ 20 ]; 
			for( t = 0;t < 20;t++ ) 
			{ 
				NG_Hash[ t ] = (byte)( NHash[ t ] ^ GHash[ t ] ); 
			} 
			byte []Temp = Concat( NG_Hash, userHash ); 
			Temp = Concat( Temp, client.salt ); 
			Temp = Concat( Temp, A ); 
			Temp = Concat( Temp, Reverse(client.B.getBytes(32)) ); 
			Temp = Concat( Temp, SS_Hash );

			byte []M1 = shaM1.ComputeHash( Temp ); 

			BinWriter pkg;

			if(!Same(M1,kM1))
			{	
				Console.WriteLine("{0} Failed authentication", client.username);

				pkg = new BinWriter();
				pkg.Write((byte)1);
				pkg.Write((byte)3);
				client.Send(pkg.GetBuffer(),26);
				client.Close("Failed authentication");
				return;
			}

			Console.WriteLine("{0} authenticated", client.username);
			setHash(client, SS_Hash); // sets session key in db

			// cal M2
			Temp = Concat( A, M1 ); 
			Temp = Concat( Temp, SS_Hash ); 
			byte []M2 = shaM1.ComputeHash( Temp ); 

			pkg = new BinWriter();
			pkg.Write((byte)1);
			pkg.Write((byte)0);
			pkg.Write(M2);
			pkg.Write(new byte[4]);
			client.Send(pkg.GetBuffer(),26);
		}

		public static byte[] Reverse( byte[]from ) 
		{ 
			byte []res = new byte[ from.Length ]; 
			int i = 0; 
			for(int t = from.Length - 1;t>=0;t--) 
				res[ i++ ] = from[ t ]; 
			return res; 
		}

		public static byte[] Concat( byte []a, byte []b ) 
		{ 
			byte []res = new byte[ a.Length + b.Length ]; 
			for(int t = 0;t < a.Length;t++ ) 
				res[ t ] = a[ t ]; 
			for(int t = 0;t < b.Length;t++ ) 
				res[ t + a.Length ] = b[ t ]; 
			return res; 
		} 

		public byte[] GetUserPasswordHash(string nm, string pw)
		{
			SHA1 sha = new SHA1CryptoServiceProvider(); 
			byte[] user=Encoding.ASCII.GetBytes(nm + ":" + pw);
			return sha.ComputeHash( user, 0 , user.Length ); 
		}

		public static bool Same(byte[] m1, byte[] m2)
		{
			if(m1.Length!=m2.Length)return false;
			for(int i=0; i<m1.Length; i++)
			{
				if(m1[i] != m2[i])return false;
			}
			return true;
		}

		#endregion

		#region Database Functions
        
		public void getPassword(RealmListClient client)
		{	
			client.account = (DBAccount)DataServer.Database.FindObjectByKey(typeof(DBAccount), client.username);
			if (client.account != null)
				client.password = client.account.Password.ToUpper();
		}

		public void setHash(RealmListClient client, byte[] ss_hash)
		{
            client.account.SessionKey = BitConverter.ToString(ss_hash);
			DataServer.Database.SaveObject(client.account);
		}

		#endregion
	}
}

