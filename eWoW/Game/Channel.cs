using System;
using System.Collections;


namespace eWoW
{
	public class Channel
	{
		Hashtable chnls=new Hashtable();
		GMCmd gmcmd;

		public Channel(GameServer gs)
		{
			gmcmd = new GMCmd(gs);
		}

		public void Set(Character c)
		{
			c.Conn.AddHandler( OP.CMSG_JOIN_CHANNEL, new DoMessageFunction(Join), c);
			c.Conn.AddHandler( OP.CMSG_LEAVE_CHANNEL, new DoMessageFunction(Leave), c);
			c.Conn.AddHandler( OP.CMSG_MESSAGECHAT, new DoMessageFunction(MessageChat), c);
			/*
			c.Conn.AddHandler( OP.CMSG_CHANNEL_LIST, new DoMessageFunction(Leave), c);
			c.Conn.AddHandler( OP.CMSG_CHANNEL_PASSWORD, new DoMessageFunction(Leave), c);
			c.Conn.AddHandler( OP.CMSG_CHANNEL_SET_OWNER, new DoMessageFunction(Leave), c);
			c.Conn.AddHandler( OP.CMSG_CHANNEL_OWNER, new DoMessageFunction(Leave), c);
			c.Conn.AddHandler( OP.CMSG_CHANNEL_MODERATOR, new DoMessageFunction(Leave), c);
			c.Conn.AddHandler( OP.CMSG_CHANNEL_UNMODERATOR, new DoMessageFunction(Leave), c);
			c.Conn.AddHandler( OP.CMSG_CHANNEL_MUTE, new DoMessageFunction(Leave), c);
			c.Conn.AddHandler( OP.CMSG_CHANNEL_UNMUTE, new DoMessageFunction(Leave), c);
			c.Conn.AddHandler( OP.CMSG_CHANNEL_INVITE, new DoMessageFunction(Leave), c);
			c.Conn.AddHandler( OP.CMSG_CHANNEL_KICK, new DoMessageFunction(Leave), c);
			c.Conn.AddHandler( OP.CMSG_CHANNEL_BAN, new DoMessageFunction(Leave), c);
			c.Conn.AddHandler( OP.CMSG_CHANNEL_UNBAN, new DoMessageFunction(Leave), c);
			c.Conn.AddHandler( OP.CMSG_CHANNEL_ANNOUNCEMENTS, new DoMessageFunction(Leave), c);
			c.Conn.AddHandler( OP.CMSG_CHANNEL_MODERATE, new DoMessageFunction(Leave), c);
			*/
		}

		void ChannelNotify(PlayerConnection c, string chnl, byte type, uint data)
		{
			ByteArrayBuilder pack = new ByteArrayBuilder();
			
			pack.Add( type );
			pack.Add( chnl );
			if(type==2)pack.Add( data );


			c.Send(OP.SMSG_CHANNEL_NOTIFY, pack);
		}

		ArrayList GetChannel(string chnl)
		{
			ArrayList h = chnls[ chnl ] as ArrayList;
			if(h == null)
			{
				h = new ArrayList();
				chnls[ chnl ] = h;
			}
			return h;
		}

		void MessageChat(OP code, PlayerConnection c)
		{
			uint t;
			uint lang;
			c.Seek(2).Get(out t).Get(out lang);

			CHAT mode=(CHAT)t;

			string text=null;
			string target=null;
			if(mode==CHAT.CHANNEL || mode==CHAT.WHISPER)
			{
				c.Get(out target);
			}
			c.Get( out text );

			if( mode == CHAT.SAY || mode == CHAT.GUILD )
			{
				if(gmcmd.Parse(c.player, text))return;
			}
			c.player.MessageChat(mode, lang, text, target);
		}

		public ArrayList MessageChatGetSet(string tag)
		{
			ArrayList us = new ArrayList();
			foreach(PlayerConnection c in GetChannel(tag))
			{
				if(!c.Connected() || c.player==null)
                    continue;
				us.Add( c.player );
			}
			return us;
		}


		void Join(OP code, PlayerConnection c)
		{
			string chnl;
			c.Seek(2).Get(out chnl);

			ArrayList pchnl=GetChannel(chnl);
			if(pchnl.Contains(c))
			{
				ChannelNotify(c, chnl, 3, 1);
			} 
			else 
			{
				pchnl.Add(c);
				ChannelNotify(c, chnl, 2, 1);  // join
			}
		}

		void Leave(OP code, PlayerConnection c)
		{
			string chnl;
			c.Seek(2).Get(out chnl);

			ArrayList pchnl=GetChannel(chnl);
			if(pchnl.Contains(c))
			{
				pchnl.Remove(c);
				ChannelNotify(c, chnl, 3, 0); // leave
			} 
		}

		public void Logout(PlayerConnection c)
		{
			foreach(string chnl in chnls.Keys)
			{
				ArrayList pchnl=chnls[chnl] as ArrayList;
				if(pchnl.Contains(c))
				{
					pchnl.Remove(c);
					ChannelNotify(c, chnl, 3, 0); // leave
				}
			}
		}
	}
}
