using System;
using System.Collections;
using WoWDaemon.Common;

namespace WoWDaemon.World
{

	// http://suchnsuch.no-ip.com:800/WoWPackets/viewTopic.php?t=17

	/// <summary>
	/// Summary description for ChannelManager.
	/// </summary>
	[WorldPacketHandler()]
	public class ChannelManager
	{
		static ArrayList Channels;
		public ChannelManager()
		{
            Channels = new ArrayList();
		}

		[WorldPacketDelegate(CMSG.JOIN_CHANNEL)]
		static void OnJoin(WorldClient client, CMSG msgID, BinReader data)
		{
			string ChanName = (string)data.ReadString();
			if ( ChanName != null )
			{
				Channel Chan;
				if( ( Chan = ChanExists(ChanName) ) != null )
				{
					Chan.Join(client);
				}
				else 
				{
					Chan = new Channel(ChanName,client);
					Channels.Add(Chan);
				}          
			}
		}

		[WorldPacketDelegate(CMSG.LEAVE_CHANNEL)]
		static void OnLeave(WorldClient client, CMSG msgID, BinReader data)
		{
			string ChanName = (string)data.ReadString(0x100);
			if ( ChanName != null )
			{
				Channel Chan;
				if( ( Chan = ChanExists(ChanName) ) != null )
				{
					Chan.Part(client);
				}          
			}
		}

		[WorldPacketDelegate(CMSG.CHANNEL_LIST)]
		static void OnList(WorldClient client, CMSG msgID, BinReader data)
		{
			string ChanName = (string)data.ReadString(0x100);
			if ( ChanName != null )
			{
				Channel Chan;
				if( ( Chan = ChanExists(ChanName) ) != null )
				{
					Chan.List(client);
				}          
			}
		}

		[WorldPacketDelegate(CMSG.CHANNEL_ANNOUNCEMENTS)]
		static void OnAnnouncment(WorldClient client, CMSG msgID, BinReader data)
		{
			string ChanName = (string)data.ReadString();
			if ( ChanName != null )
			{
				Channel Chan;
				if( ( Chan = ChanExists(ChanName) ) != null )
				{
					if(Chan.announcment)
					{
						Chan.AnnouncmentOff(client);
					}
					else
					{
						Chan.AnnouncmentOn(client);
					}
				}          
			}
		}

		[WorldPacketDelegate(CMSG.CHANNEL_KICK)]
		static void OnKick(WorldClient client, CMSG msgID, BinReader data)
		{
			Console.WriteLine("Kick1!");
		}

		[WorldPacketDelegate(CMSG.CHANNEL_INVITE)]
		static void OnInvite(WorldClient client, CMSG msgID, BinReader data)
		{
			string ChanName = (string)data.ReadString();
			if ( ChanName != null )
			{
				Channel Chan;
				if( ( Chan = ChanExists(ChanName) ) != null )
				{
					string nick = (string)data.ReadString();
					Chan.Invite(client,nick);
				}
			}			
		}

		
		public static void Deconnection(WorldClient client)
		{
			foreach(Channel chan in Channels)
			{
				chan.Part(client);
			}
		}

		public static Channel ChanExists(string name)
		{
			IEnumerator Ienum = Channels.GetEnumerator();
			while(Ienum.MoveNext())
			{
				if(((Channel)(Ienum.Current)).name == name )
					return (Channel)(Ienum.Current);
			}
			return null;
		}

		public static bool TalkTo(string chan,WorldClient client, string msg)
		{
			Channel channel;
			if((channel = ChanExists(chan))!=null)
			{
				channel.Talk(client,msg);
				return true;
			}
			return false;
		}
	}

	/// <summary>
	/// Summary description for Channel.
	/// </summary>
	public class Channel
	{
		public ArrayList Users; 
		protected ArrayList Banned;
		protected ArrayList Flags;// o: moderator // m: muted
		protected string password;
		public string name;
		public bool announcment;
		protected bool moderate;

		public Channel()
		{
			Users = new ArrayList();
			Banned = new ArrayList();
			Flags = new ArrayList();
			name = "Default";
			announcment = false;
			moderate = false;
		}
		public Channel(string name)
		{
			Users = new ArrayList();
			Banned = new ArrayList();
			Flags = new ArrayList();
			this.name = name;
			announcment = false;
			moderate = false;
		}
		public Channel(string name,WorldClient client)
		{
			Users = new ArrayList();
			Banned = new ArrayList();
			Flags = new ArrayList();
			this.name = name;
			announcment = false;
			moderate = false;
			Join(client);
		}

		public int NbUsers()
		{
			return Users.Count;
		}

		public bool Talk(WorldClient client,string msg)
		{
			try
			{
				int index = Users.IndexOf(client);
				if( !((RightFlag)Flags[index]).IsMute() || ( moderate && ( !((RightFlag)Flags[index]).IsModo() || !((RightFlag)Flags[index]).IsVoice())) )
				{
					BinWriter w = new BinWriter();
					w.Write((byte)CHATMESSAGETYPE.CHANNEL);
					w.Write((int)0);
					w.Write((string)name);
					w.Write(client.Player.GUID);
					w.Write((int)msg.Length+1); // chat fix
					w.Write((string)msg);
					w.Write((byte)0);
            
					int nb_users = NbUsers();
					for(int i=0;i<nb_users;i++)
					{
					   ((WorldClient)Users[i]).Send(SMSG.MESSAGECHAT,w);
					}
				
					return true;
				}
				else
				{
					BinWriter w = new BinWriter();
					w.Write((byte)CHANNEL.CANNOTSPEAK);
					w.Write((string)name);
					client.Send(SMSG.CHANNEL_NOTIFY,w);
					return false;
				}

			}
			catch(Exception e) 
			{
				Console.WriteLine("Channel Exception (Talk): "+e.Message);
				return false;
			}
		}

		public bool Join(WorldClient client)
		{
			try 
			{
				IEnumerator ienum = Users.GetEnumerator();
				int index = 0;
				while(ienum.MoveNext())
				{
					if(((WorldClient)ienum.Current).Player.Name == client.Player.Name)
					{
						Users.RemoveAt(index);
						Flags.RemoveAt(index);
						break;
					}
					index++;
				}

				BinWriter w = new BinWriter();
				w.Write((byte)CHANNEL.JOIN2);
				w.Write((string)name);
				if(Users.Count == 0)
					w.Write((byte)0x00);
				else
					w.Write((byte)0x01);
				w.Write((byte)0x00);
				w.Write((byte)0x00);
				w.Write((byte)0x00);
				client.Send(SMSG.CHANNEL_NOTIFY,w);

				Users.Add(client);

				int nb_users = NbUsers();

				if(client.Player.AccessLvl>=ACCESSLEVEL.GM || nb_users == 1)
				{
					Flags.Add(new RightFlag((string)"o"));
				}
				else 
				{
					Flags.Add(new RightFlag());
				}
				
				BinWriter w3 = new BinWriter();
				w3.Write((byte)CHANNEL.JOIN1);
				w3.Write((string)name);
				w3.Write(client.Player.GUID);
				
				BinWriter w2 = new BinWriter();
				w2.Write((string)name);
				w2.Write((byte)0x00);
				w2.Write((int)nb_users);
				for(int i=0;i<nb_users;i++)
				{
					w2.Write(((WorldClient)(Users[i])).Player.GUID);
					w2.Write((byte)((RightFlag)(Flags[i])).GetRightFlag());

					if(announcment)
					{
						((WorldClient)Users[i]).Send(SMSG.CHANNEL_NOTIFY,w3);
					}
				}
				client.Send(SMSG.CHANNEL_LIST,w2);

				return true;
			}
			catch(Exception e) 
			{
				Console.WriteLine("Channel Exception (Join): "+e.Message);
				return false;
			}
		}

		public bool Part(WorldClient client)
		{
			try
			{
				int index;
				if ( (index = Users.IndexOf(client)) != -1)
				{
					Users.RemoveAt(index);
					Flags.RemoveAt(index);

					if(client.Player.InWorld)
					{
						BinWriter w = new BinWriter();
						w.Write((byte)CHANNEL.LEFT2);
						w.Write(name);
						client.Send(SMSG.CHANNEL_NOTIFY,w);
					}

					if(announcment)
					{
						BinWriter w2 = new BinWriter();
						w2.Write((byte)CHANNEL.LEFT1);
						w2.Write(name);
						w2.Write(client.Player.GUID);
						int nb_users = NbUsers();
						Console.WriteLine("miyu: "+nb_users);
						for(int i=0;i<nb_users;i++)
						{
							Console.WriteLine("miyu!");
							((WorldClient)Users[i]).Send(SMSG.CHANNEL_NOTIFY,w2);
						}
					}

					return true;
				}
				return false;
			}
			catch(Exception e) 
			{
				Console.WriteLine("Channel Exception (Part): "+e.Message);
				return false;
			}
		}

		public bool Kick(WorldClient client)
		{
			try
			{
				int index;
				if ( (index = Users.IndexOf(client)) != -1)
				{
					Users.RemoveAt(index);
					Flags.RemoveAt(index);
					return true;
				}
				return false;
			}
			catch(Exception e) 
			{
				Console.WriteLine("Channel Exception (Kick): "+e.Message);
				return false;
			}
		}/*

		public bool IsBanned(WorldClient client)
		{
			try
			{
				int index;
				if ( (index = Users.IndexOf(client)) != -1)
				{
					Users.RemoveAt(index);
					Flags.RemoveAt(index);
					Banned.Add(client);
					return true;
				}
				return false;
			}
			catch(Exception e) 
			{
				Console.WriteLine("Channel Exception : "+e.Message);
				return false;
			}
		}*/

		public bool Voice(WorldClient client)
		{
			try
			{
				int index;
				if ( (index = Users.IndexOf(client)) != -1)
				{
					((RightFlag)Flags[index]).GiveVoice();
					return true;
				}
				return false;
			}
			catch(Exception e)
			{
				Console.WriteLine("Channel Exception (Voice): "+e.Message);
				return false;
			}
		}

		public bool UnVoice(WorldClient client)
		{
			try
			{
				int index;
				if ( (index = Users.IndexOf(client)) != -1)
				{
					((RightFlag)Flags[index]).RemVoice();
					return true;
				}
				return false;
			}
			catch(Exception e)
			{
				Console.WriteLine("Channel Exception (UnVoice): "+e.Message);
				return false;
			}
		}

		public bool UnModerator(WorldClient client)
		{
			try
			{
				int index;
				if ( (index = Users.IndexOf(client)) != -1)
				{
					((RightFlag)Flags[index]).RemModo();
					return true;
				}
				return false;
			}
			catch(Exception e)
			{
				Console.WriteLine("Channel Exception (UnModerator): "+e.Message);
				return false;
			}
		}

		public bool GiveModerator(WorldClient client)
		{
			try
			{
				int index;
				if ( (index = Users.IndexOf(client)) != -1 )
				{
					((RightFlag)Flags[index]).GiveModo();
					return true;
				}
				return false;
			}
			catch(Exception e)
			{
				Console.WriteLine("Channel Exception (GiveModerator): "+e.Message);
				return false;
			}
		}

		public bool Mute(WorldClient client)
		{
			try
			{
				int index;
				if ( (index = Users.IndexOf(client)) != -1)
				{
					((RightFlag)Flags[index]).GiveMute();
					return true;
				}
				return false;
			}
			catch(Exception e)
			{
				Console.WriteLine("Channel Exception (Mute): "+e.Message);
				return false;
			}
		}

		public bool UnMute(WorldClient client)
		{
			try
			{
				int index;
				if ( (index = Users.IndexOf(client)) != -1)
				{
					((RightFlag)Flags[index]).RemMute();
					return true;
				}
				return false;
			}
			catch(Exception e)
			{
				Console.WriteLine("Channel Exception (Unmute): "+e.Message);
				return false;
			}
		}/*

		public bool Ban(WorldClient client)
		{
			try
			{
				int index;
				if ( (index = Users.IndexOf(client)) != -1)
				{
					if( Banned.IndexOf(client.Player.GUID) == -1 )
					{
						Banned.Add(client.Player.GUID);
						return true;
					}
				}
				return false;
			}
			catch(Exception e)
			{
				Console.WriteLine("Channel Exception : "+e.Message);
				return false;
			}
		}

		public bool UnBan(WorldClient client)
		{
			try
			{
				int index;
				if ( (index = Users.IndexOf(client)) != -1)
				{
					if( Banned.IndexOf(client.Player.GUID) != -1)
					{
						Banned.Remove(client.Player.GUID);
						return true;
					}
				}
				return false;
			}
			catch(Exception e)
			{
				Console.WriteLine("Channel Exception : "+e.Message);
				return false;
			}
		}
		*/

		public bool List(WorldClient client)
		{
			try
			{
				int nb_users = NbUsers();
				BinWriter w = new BinWriter();
				w.Write((string)name);
				w.Write((byte)0x00);
				w.Write((int)nb_users);
				for(int i=0;i<nb_users;i++)
				{
					w.Write(((WorldClient)(Users[i])).Player.GUID);
					w.Write((byte)((RightFlag)(Flags[i])).GetRightFlag());
				}
				client.Send(SMSG.CHANNEL_LIST,w);
				return true;
			}
			catch(Exception e)
			{
				Console.WriteLine("Channel Exception (List): "+e.Message);
				return false;
			}
		}

		public bool AnnouncmentOn(WorldClient client)
		{
			try
			{
				int nb_users = NbUsers();
				BinWriter w = new BinWriter();
				w.Write((byte)CHANNEL.ANNOUNCEON);
				w.Write((string)name);
				w.Write(client.Player.GUID);
				for(int i=0;i<nb_users;i++)
				{
					((WorldClient)Users[i]).Send(SMSG.CHANNEL_NOTIFY,w);
				}
                announcment = true;			
				return true;
			}
			catch(Exception e)
			{
				Console.WriteLine("Channel Exception (AnnouncmentOn): "+e.Message);
				return false;
			}
		}

		public bool AnnouncmentOff(WorldClient client)
		{
			try
			{
				int nb_users = NbUsers();
				BinWriter w = new BinWriter();
				w.Write((byte)CHANNEL.ANNOUNCEOFF);
				w.Write((string)name);
				w.Write(client.Player.GUID);
				for(int i=0;i<nb_users;i++)
				{
					((WorldClient)Users[i]).Send(SMSG.CHANNEL_NOTIFY,w);
				}
				announcment = false;			
				return true;
			}
			catch(Exception e)
			{
				Console.WriteLine("Channel Exception (AnnouncmentOff): "+e.Message);
				return false;
			}
		}

		public bool Invite(WorldClient client,string name)
		{
			try
			{
				WorldClient t_client = (WorldClient)(WorldServer.GetClientByName(name));
				if( t_client != null )
				{
					if(!Users.Contains(t_client))
					{
						BinWriter w = new BinWriter();
						w.Write((byte)CHANNEL.INVITE);
						w.Write((string)name);
						w.Write(client.Player.GUID);
						t_client.Send(SMSG.CHANNEL_NOTIFY,w);

						Join(t_client);
					}
					else
					{
						BinWriter w = new BinWriter();
						w.Write((byte)CHANNEL.ALREADYON);
						w.Write((string)name);
						w.Write(t_client.Player.GUID);
						client.Send(SMSG.CHANNEL_NOTIFY,w);
					}					
					return true;
				}
				return false;
			}
			catch(Exception e)
			{
				Console.WriteLine("Channel Exception (Invite): "+e.Message);
				return false;
			}
		}

		public class RightFlag
		{
			public byte Flag;
			static byte Voice = (byte)0x00;
			static byte Mute = (byte)0x10;
			static byte Modo = (byte)0x01;
			static byte Normal = (byte)0x00;
			
			public RightFlag()
			{
				Flag=Normal;
			}
			public RightFlag(string flag)
			{
				if(flag == (string)"v")
					Flag=Voice;
				if(flag == (string)"o")
					Flag=Modo;
				if(flag == (string)"m")
					Flag=Mute;
			}

			public bool IsVoice()
			{
				if(Flag==Voice)
				{
						return true;
				}
				return false;
			}
			public bool IsMute()
			{
				if(Flag==Mute)
				{
					return true;
				}
				return false;
			}
			public bool IsModo()
			{
				if(Flag==Modo)
				{
					return true;
				}
				return false;
			}

			public void GiveVoice()
			{
					Flag = Voice;
			}
			public void GiveMute()
			{
				Flag = Mute;
			}
			public void GiveModo()
			{
				Flag = Modo;
			}

			public void RemVoice()
			{
				Flag = Normal;
			}
			public void RemMute()
			{
				Flag = Normal;
			}
			public void RemModo()
			{
				Flag = Normal;
			}

			public byte GetRightFlag()
			{
				return Flag;
			}
		}
	}
}
