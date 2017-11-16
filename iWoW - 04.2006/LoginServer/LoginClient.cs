using System;
using System.Net.Sockets;
using System.Collections;
using System.Security.Cryptography;
using WoWDaemon.Common;
using WoWDaemon.Database.DataTables;
using WoWDaemon.Login;

namespace WoWDaemon.Login
{
	public class LoginWarning : Exception
	{
		public LoginWarning(string msg) : base(msg)
		{
		}
	}

	/// <summary>
	/// Summary description for LoginClient.
	/// </summary>
	public class LoginClient : ClientBase
	{
		static Hashtable AccountsLoggedIn = Hashtable.Synchronized(new Hashtable());
		public static bool IsAccountLoggedIn(string name)
		{
			return AccountsLoggedIn.Contains(name);
		}
		
		private DBAccount m_account = null;
		private DBCharacter m_character = null;
		private WorldConnection m_worldServer = null;
		private bool m_isLoggingOut = false;
		private bool m_isChangingMap = false;
		public LoginClient(Socket sock, ServerBase server) : base(sock)
		{
			BinWriter w = NewPacket(SMSG.AUTH_CHALLENGE);
			Console.WriteLine("AUTH_CHALLENGE");
			w.Write(0);
			Send(w);
		}

		public DBAccount Account
		{
			get { return m_account;}
			set 
			{
				if(value == null)
				{
					if(m_account == null)
						return;
					else
						AccountsLoggedIn.Remove(m_account.Name);
				}
				else
				{
					if(m_account == null)
						AccountsLoggedIn.Add(value.Name, value);
					else
					{
						AccountsLoggedIn.Remove(m_account.Name);
						AccountsLoggedIn.Add(value.Name, value);
					}
				}
				m_account = value;
			}
		}

		public DBCharacter Character
		{
			get { return m_character;}
			set { m_character = value;}
		}

		public bool IsLoggingOut
		{
			get { return m_isLoggingOut;}
			set { m_isLoggingOut = value;}
		}

		public bool IsChangingMap
		{
			get { return m_isChangingMap;}
			set { m_isChangingMap = value;}
		}

		public static uint GetActualTime()
		{
			DateTime time = DateTime.Now;
			int num1 = time.Year - 0x7d0;
			int num2 = time.Month - 1;
			int num3 = time.Day - 1;
			int num4 = (int)time.DayOfWeek;
			int num5 = time.Hour;
			int num6 = time.Minute;
			return (uint)(((((num6 | (num5 << 6)) | (num4 << 11)) | (num3 << 14)) | (num1 << 0x12)) | (num2 << 20));
		}

		internal void MyOnEnterWorld()
		{
			Console.WriteLine("WORLD: Player entering world... sephs code");

			BinWriter packet = LoginClient.NewPacket(SMSG.RWHOIS);
			byte[] buffer = new byte[84]; // I don't know what this is for
			packet.Write(buffer);
			Send(packet);

			packet = LoginClient.NewPacket(SMSG.IGNORE_LIST);
			buffer = new byte[6];
			packet.Write(buffer);
			Send(packet);

			packet = LoginClient.NewPacket(SMSG.FRIEND_LIST);
			packet.Write((int)0);
			Send(packet);

			packet = LoginClient.NewPacket(SMSG.BINDPOINTUPDATE);
			packet.Write(Character.Position.X);
			packet.Write(Character.Position.Y);
			packet.Write(Character.Position.Z);
			packet.Write(Character.WorldMapID);
			packet.Write(Character.Zone);
			Console.WriteLine("Binding character at {0} {1} {2}", Character.Position, Character.WorldMapID, Character.Zone);
//			packet.Write((float)9859.089844);
//			packet.Write((float)588.760986);
//			packet.Write((float)1300.609985);
//			packet.Write((ushort)1);
//			packet.Write((uint)1); // Change me (zoneid!)
			Send(packet);
//			this.Character.Position.X, Y, z instead? :)
			

			packet = LoginClient.NewPacket(SMSG.SET_REST_START);
			packet.Write((uint)17); // in seconds...
			Send(packet);

			packet = LoginClient.NewPacket(SMSG.SET_FLAT_SPELL_MODIFIER);
			packet.Write(new byte[] { 0, 0, 0, 0, 6, 10, 0x38, 0xff, 0xff, 0xff });
			Send(packet);

			packet = LoginClient.NewPacket(SMSG.TUTORIAL_FLAGS);
			packet.Write(new byte[] {
					0, 0x22, 0, 0, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 
					0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 
					0xff, 0xff, 0xff, 0xff
				});
			Send(packet);

			packet = LoginClient.NewPacket(SMSG.INITIAL_SPELLS);
			packet.Write((char)0);
			packet.Write((ushort)this.Character.Spells.Length);
			int slotNum = 1;
			foreach (DBKnownSpell knownSpell in this.Character.Spells)
			{
				// Spell ID
				packet.Write((ushort)knownSpell.Spell_Id);
				// Slot number
				packet.Write((short)knownSpell.Slot);
				slotNum++;
			}
			packet.Write((short)0x00);
			Send(packet);

			packet = LoginClient.NewPacket(SMSG.ACTION_BUTTONS);
			packet.Write(new byte[0x1E0]); // ?????
			Send(packet);

			packet = LoginClient.NewPacket(SMSG.LOGIN_SETTIMESPEED);
			packet.Write(new byte[] { 0, 10, 0, 0, 12, 0xc9, 0x16, 5, 0x89, 0x88, 0x88, 60 });
			Send(packet);

			packet = LoginClient.NewPacket(SMSG.CORPSE_RECLAIM_DELAY);
			packet.Write(new byte[] { 1, 70, 0x22, 1, 0, 0, 0, 0 });
			Send(packet);

//			packet = LoginClient.NewPacket(SMSG.LOGIN_SETTIMESPEED);
//			packet.Write(GetActualTime());
//			packet.Write(0.017f);
//			Send(packet);


		}

		internal void OnEnterWorld()
		{
//			MyOnEnterWorld();
			return;

			Console.WriteLine("WORLD: Player entering world.");
			Console.WriteLine("WORLD: SMSG.ACCOUNT_DATA_MD5");
            // Handle SMSG.ACCOUNT_DATA_MD5. Send out 80 nulls.
            BinWriter w = LoginClient.NewPacket(SMSG.ACCOUNT_DATA_MD5);
            for (int i = 0; i < 80; i++) { w.Write((uint)0); }
            Send(w);

            // Handle MOTD
            Console.WriteLine("WORLD: MOTD");
            Chat.System(this, "Welcome to " + LoginServer.ServerName);
            Chat.System(this, "This server is running off of iWoW SVN.");

            // Handle Action Buttons
            Console.WriteLine("WORLD: SMSG.ACTION_BUTTONS");
            w = LoginClient.NewPacket(SMSG.ACTION_BUTTONS);
            /*w.Write((byte)1);
            w.Write((uint)0);
            w.Write((byte)0);*/
            w.Write((new byte[0x1E0]));
            Send(w);

            // Handle Rest State
            Console.WriteLine("WORLD: SMSG.SET_REST_START");
            w = LoginClient.NewPacket(SMSG.SET_REST_START);
            /*w.Write((byte)1);
            w.Write((uint)0);
            w.Write((byte)0);*/
            w.Write((long)0x466);
            Send(w);

            // Handle Initial Spells
            Console.WriteLine("WORLD: Initial Spells sent.");
            if ((Character.Spells == null) || (Character.Spells.Length == 0))
            {
                return;
            }
            int slotNum = 1;
            w = LoginClient.NewPacket(SMSG.INITIAL_SPELLS);
            /*w.Write((byte)1);
            w.Write((uint)0);
            w.Write((byte)0);*/
            w.Write((char)0); // ?
            w.Write((ushort)this.Character.Spells.Length);
            foreach (DBKnownSpell knownSpell in this.Character.Spells)
            {
                try
                {
                    // Spell ID
                    w.Write((ushort)knownSpell.Spell_Id);
                    // Slot number
                    w.Write((short)knownSpell.Slot);
                    slotNum++;
                }
                catch (Exception) { }
            }
            w.Write((short)0x00);
            Send(w);

            // Handle CMSG.UPDATE_ACCOUNT_DATA. Send out 50 nulls.
            w = LoginClient.NewPacket(SMSG.UPDATE_ACCOUNT_DATA);
            for (int i = 0; i < 50; i++)
            {
                w.Write((uint)0);
            }
			Send(w);

			w = LoginClient.NewPacket(SMSG.SET_REST_START);
			w.Write((uint)123);
			Send(w);

			// Data stolen from WowwoW. I don't know what it means.
			w = LoginClient.NewPacket(SMSG.TUTORIAL_FLAGS);
			byte[] tutorial_flag_data =
			{
				0, 0x22, 0, 0, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 
				0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 
				0xff, 0xff, 0xff, 0xff
			};
			w.Write(tutorial_flag_data);
			Send(w);

        }

        byte[] HashConfig(string conf)
		{
			MD5 md5 = new MD5CryptoServiceProvider();
			byte[] data = System.Text.ASCIIEncoding.ASCII.GetBytes(conf);
			return md5.ComputeHash(data, 0, data.Length);
		}

		public void SendConfig(int type)
		{
			string config = string.Empty;
			switch(type)
			{
				case 0:
					config = m_character.UIConfig0;
					break;
				case 1:
					config = m_character.UIConfig1;
					break;
				case 2:
					config = m_character.UIConfig2;
					break;
				case 3:
					config = m_character.UIConfig3;
					break;
				case 4:
					config = m_character.UIConfig4;
					break;
				default:
					return;
			}


			//byte[] data = System.Text.ASCIIEncoding.ASCII.GetBytes(config);
			//w.Write(data.Length);
			//w.Write(ZLib.Compress(data));
		}

        public override void Close(string reason)
		{
			if(m_account != null)
				Account = null;
			if(m_character != null)
			{
				LoginServer.LeaveWorld(this);
				LoginServer.RemoveCharacter(this);
			}
			Console.WriteLine(this + " closed: " + reason);
			base.Close (reason);
		}


		public override void OnException(Exception e)
		{
			if(e is SocketException)
			{
				Close(e.Message + " (" + ((SocketException)e).ErrorCode.ToString() + ")");
				Console.WriteLine(e);
			}
			else if(e is LoginWarning)
				Close(e.Message);
			else
				Close(e.Message + Environment.NewLine + e.StackTrace);
		}

		public override int PacketHeaderSize
		{
			get
			{
				return 2;
			}
		}

		public override int PacketDataSize
		{
			get
			{
				byte[] header_data = m_packet_header.Peek();
				int size = (header_data[0] << 8) + header_data[1];
				if(size > 0x7FFF || size == 0)
					throw new LoginWarning("Corrupted Packet!");
				return size;
			}
		}

		public static BinWriter NewPacket(SMSG msgID)
		{
			DebugLogger.Logger.Log("LoginClient crafting packet " + msgID.ToString());
			BinWriter w = new BinWriter();
			w.Write((short)0);
			w.Write((ushort)msgID);
			return w;
		}
		
		public void Send(BinWriter w)
		{
//			DebugLogger.Logger.Log("Sending packet: " + w.ToString());
			ushort len = (ushort)(w.BaseStream.Length-2);
			len = (ushort)((len >> 8) + ((len&0xFF) << 8));
			w.Set(0, len);
			Send(w.GetBuffer(), (int)w.BaseStream.Length);
		}

		public WorldConnection WorldConnection
		{
			get { return m_worldServer;}
			set { m_worldServer = value;}
		}

		public void SendWorldServer(WorldPacket pkg)
		{
			m_worldServer.Send(pkg);
		}
	}
}
