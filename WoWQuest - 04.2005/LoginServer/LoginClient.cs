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
		public LoginClient(Socket sock) : base(sock, 2)
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

		internal void OnEnterWorld()
		{
			BinWriter w = LoginClient.NewPacket(SMSG.TUTORIAL_FLAGS);
			for(int i = 0;i < 8;i++)
				w.Write(-1);
			Send(w);

			SendConfigCRC();
			// Send initial spells
			initialSpells();
			w = LoginClient.NewPacket(SMSG.ACTION_BUTTONS);
			w.Write(new byte[0x1E0]);
			Send(w);
			Chat.System(this, "Connected to " + LoginServer.ServerName);
			Chat.System(this, "This server is running WoWDaemon 1.3");
			Chat.System(this, "Users Online: " + LoginServer.CurrentUsers +
				" Total Users Online This Session: " + LoginServer.TopUsers);
			if (Character.Guild!=null)
			{
				Chat.GuildSay(0, this, "MOTD: "+Character.Guild.MOTD, CHATMESSAGETYPE.GUILD);
			}
			m_worldServer.OnEnterWorld(m_character, m_account.AccessLvl);
		}

		void initialSpells()
		{
			if((Character.Spells == null) || (Character.Spells.Length == 0))
			{
				return;
			}
			int slotNum = 1;
			BinWriter w = LoginClient.NewPacket(SMSG.INITIAL_SPELLS);
			// Unknow byte
			w.Write((byte)0);
			// Number of abilites/spells
			w.Write((ushort)this.Character.Spells.Length);
			foreach(DBKnownSpell knownSpell in this.Character.Spells)
			{
				try
				{
					// Spell ID : Defensive Stance
					w.Write((ushort) knownSpell.Spell_Id);
					// Slot Number
					w.Write((short)knownSpell.Slot);
					slotNum++;
				}
				catch (Exception){}//{Chat.System(client, e.InnerException.Message);}
			}
			w.Write((byte)0x00);
			w.Write((byte)0x00);
			Send(w);
		}
/*
		void initialSpells()
		{
			Console.WriteLine(Character.Class.ToString());
			BinWriter w = null;
			switch(this.Character.Class)
			{
				case CLASS.WARRIOR:
					w = LoginClient.NewPacket(SMSG.INITIAL_SPELLS);
					// Unknow byte
					w.Write((byte)0);
					// Number of abilites/spells
					w.Write((ushort)3);
					// Spell ID : Defensive Stance
					w.Write((ushort) 71);
					// Slot Number
					w.Write((short)1);
					// Spell ID : Berserker Stance
					w.Write((ushort)2458);
					// Slot Number
					w.Write((short)2);
					// Spell ID : WhirlWind
					w.Write((ushort) 1680);
					// Slot Number
					w.Write((short)3);
					w.Write((byte)0x00);
					w.Write((byte)0x00);
					Send(w);
					break;

				case CLASS.PALADIN:
					w = LoginClient.NewPacket(SMSG.INITIAL_SPELLS);
					// Unknow byte
					w.Write((byte)0);
					// Number of abilites/spells
					w.Write((ushort)3);
					// Spell ID : Divine Shield
					w.Write((ushort) 642);
					// Slot Number
					w.Write((short)1);
					// Spell ID : Devotion Aura
					w.Write((ushort) 465);
					// Slot Number
					w.Write((short)2);
					// Spell ID : Holy Light
					w.Write((ushort) 635);
					// Slot Number
					w.Write((short)3);
					w.Write((byte)0x00);
					w.Write((byte)0x00);
					Send(w);
					break;

				case CLASS.HUNTER :
					w = LoginClient.NewPacket(SMSG.INITIAL_SPELLS);
					// Unknow byte
					w.Write((byte)0);
					// Number of abilites/spells
					w.Write((ushort)3);
					// Spell ID : Beast Tracking
					w.Write((ushort) 1494);
					// Slot Number
					w.Write((short)1);
					// Spell ID : Beast Soothe
					w.Write((ushort) 1513);
					// Slot Number
					w.Write((short)2);
					// Spell ID : Beast Taming
					w.Write((ushort) 1515);
					// Slot Number
					w.Write((short)3);
					w.Write((byte)0x00);
					w.Write((byte)0x00);
					Send(w);
					break;

				case CLASS.ROGUE :
					w = LoginClient.NewPacket(SMSG.INITIAL_SPELLS);
					// Unknow byte
					w.Write((byte)0);
					// Number of abilites/spells
					w.Write((ushort)3);
					// Spell ID : Backstab
					w.Write((ushort) 53);
					// Slot Number
					w.Write((short)1);
					// Spell ID : Stealth
					w.Write((ushort) 1784);
					// Slot Number
					w.Write((short)2);
					// Spell ID : Dual Wield
					w.Write((ushort) 674);
					// Slot Number
					w.Write((short)3);
					w.Write((byte)0x00);
					w.Write((byte)0x00);
					Send(w);
					break;

				case CLASS.PRIEST :
					w = LoginClient.NewPacket(SMSG.INITIAL_SPELLS);
					// Unknow byte
					w.Write((byte)0);
					// Number of abilites/spells
					w.Write((ushort)3);
					// Spell ID : Sleep
					w.Write((ushort) 700);
					// Slot Number
					w.Write((short)1);
					// Spell ID : Lesser Heal
					w.Write((ushort) 2050);
					// Slot Number
					w.Write((short)2);
					// Spell ID : Shadow Word: Pain
					w.Write((ushort) 589);
					// Slot Number
					w.Write((short)3);
					w.Write((byte)0x00);
					w.Write((byte)0x00);
					Send(w);
					break;

				case CLASS.SHAMAN :
					w = LoginClient.NewPacket(SMSG.INITIAL_SPELLS);
					// Unknow byte
					w.Write((byte)0);
					// Number of abilites/spells
					w.Write((ushort)3);
					// Spell ID : Lightning Bolt
					w.Write((ushort) 403);
					// Slot Number
					w.Write((short)1);
					
					// Spell ID : Lightning SHield
					w.Write((ushort) 324);
					// Slot Number
					w.Write((short)2);
					
					// Spell ID : Healing Wave
					w.Write((ushort) 331);
					// Slot Number
					w.Write((short)3);
					w.Write((byte)0x00);
					w.Write((byte)0x00);
					Send(w);
					break;

				case CLASS.MAGE :
					w = LoginClient.NewPacket(SMSG.INITIAL_SPELLS);
					// Unknow byte
					w.Write((byte)0);
					// Number of abilites/spells
					w.Write((ushort)3);
					// Spell ID : Invisibility
					w.Write((ushort) 885);
					// Slot Number
					w.Write((short)1);
					
					// Spell ID : Frost Armor
					w.Write((ushort) 168);
					// Slot Number
					w.Write((short)2);
					
					// Spell ID : FireBall
					w.Write((ushort) 133);
					// Slot Number
					w.Write((short)3);
					w.Write((byte)0x00);
					w.Write((byte)0x00);
					Send(w);
					break;

				case CLASS.WARLOCK :
					w = LoginClient.NewPacket(SMSG.INITIAL_SPELLS);
					// Unknow byte
					w.Write((byte)0);
					// Number of abilites/spells
					w.Write((ushort)3);
					// Spell ID : Immolate
					w.Write((ushort) 348);
					// Slot Number
					w.Write((short)1);
					
					// Spell ID : Anti-Magic
					w.Write((ushort) 1399);
					// Slot Number
					w.Write((short)2);
					
					// Spell ID : Infernal
					w.Write((ushort) 1413);
					// Slot Number
					w.Write((short)3);
					w.Write((byte)0x00);
					w.Write((byte)0x00);
					Send(w);
					break;

				case CLASS.DRUID :
					w = LoginClient.NewPacket(SMSG.INITIAL_SPELLS);
					// Unknow byte
					w.Write((byte)0);
					// Number of abilites/spells
					w.Write((ushort)3);
					// Spell ID : Polymorph : Pig
					w.Write((ushort) 118);
					// Slot Number
					w.Write((short)1);
					
					// Spell ID : Rejuvenation
					w.Write((ushort) 774);
					// Slot Number
					w.Write((short)2);
					
					// Spell ID : Faerie Fire
					w.Write((ushort) 770);
					// Slot Number
					w.Write((short)3);
					w.Write((byte)0x00);
					w.Write((byte)0x00);
					Send(w);
					break;
			}
		}
*/
		void SendConfigCRC()
		{
			BinWriter w = LoginClient.NewPacket(SMSG.ACCOUNT_DATA_MD5);
			if(m_character.UIConfig0 == string.Empty)
				w.Write(new byte[0x10]);
			else
				w.Write(HashConfig(m_character.UIConfig0));
			if(m_character.UIConfig1 == string.Empty)
				w.Write(new byte[0x10]);
			else
				w.Write(HashConfig(m_character.UIConfig1));
			if(m_character.UIConfig2 == string.Empty)
				w.Write(new byte[0x10]);
			else
				w.Write(HashConfig(m_character.UIConfig2));
			if(m_character.UIConfig3 == string.Empty)
				w.Write(new byte[0x10]);
			else
				w.Write(HashConfig(m_character.UIConfig3));
			if(m_character.UIConfig4 == string.Empty)
				w.Write(new byte[0x10]);
			else
				w.Write(HashConfig(m_character.UIConfig4));
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
			BinWriter w = LoginClient.NewPacket(SMSG.UPDATE_ACCOUNT_DATA);
			w.Write(type);
			if(config == string.Empty)
			{
				w.Write(0);
				Send(w);
				return;
			}
			byte[] data = System.Text.ASCIIEncoding.ASCII.GetBytes(config);
			w.Write(data.Length);
			w.Write(ZLib.Compress(data));
			Send(w);
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

		public override int PacketSize
		{
			get
			{
				int size = (m_header[0] << 8) + m_header[1];
				if(size > 0x7FFF || size == 0)
					throw new LoginWarning("blah blah probably corrupt packet.");
				return size + 2;
			}
		}

		public static BinWriter NewPacket(SMSG msgID)
		{
			BinWriter w = new BinWriter();
			w.Write((short)0);
			w.Write((ushort)msgID);
			return w;
		}
		
		public void Send(BinWriter w)
		{
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
