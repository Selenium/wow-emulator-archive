using System;
using System.Collections;
using System.Reflection;
using WoWDaemon.Common;
using WoWDaemon.Database;
using WoWDaemon.Database.DataTables;

namespace WoWDaemon.World
{
	public delegate bool ChatCmdDelegate(WorldClient client, string input);

	[WorldPacketHandler()]
	public class ChatManager
	{
		
		class ChatCommand
		{
			public string cmd;
			public string usage;
			public ChatCmdDelegate func;
		}

		static Hashtable cmds = new Hashtable();

		public static void RegisterChatCommand(string cmd, string usage, ChatCmdDelegate func)
		{
			ChatCommand chatcmd = new ChatCommand();
			chatcmd.cmd = cmd.ToLower();
			chatcmd.usage = usage;
			chatcmd.func = func;
			cmds[chatcmd.cmd] = chatcmd;
		}

		internal static void ClearChatCmds()
		{
			cmds.Clear();
		}

		static void OnChatCommand(WorldClient client, string msg)
		{
			string[] split = msg.Split(' ');
			string cmd = split[0].ToLower();
			ChatCommand chatcmd = (ChatCommand)cmds[cmd];
			if(chatcmd == null)
				return;
			if(chatcmd.func(client, msg) == false)
			{
				Chat.System(client, chatcmd.usage);
			}
		}

		[WorldPacketDelegate(CMSG.MESSAGECHAT)]
		static void OnMessageChat(WorldClient client, CMSG msgID, BinReader data)
		{
			string channel=" ";
			CHATMESSAGETYPE type = (CHATMESSAGETYPE)data.ReadInt32();
			/*int channel = */data.ReadInt32();
			/*string target = string.Empty;*/
			if(type == CHATMESSAGETYPE.WHISPER)
				/*target =*/ data.ReadString(0x100);
			if(type == CHATMESSAGETYPE.CHANNEL ||
				type == CHATMESSAGETYPE.CHANNEL_JOIN ||
				type == CHATMESSAGETYPE.CHANNEL_LEAVE ||
				type == CHATMESSAGETYPE.CHANNEL_LIST ||
				type == CHATMESSAGETYPE.CHANNEL_NOTICE ||
				type == CHATMESSAGETYPE.CHANNEL_NOTICE_USER)
			{
				channel = (string)data.ReadString();
			}
			string msg = data.ReadString(0x100);
			if(msg.StartsWith("!") || msg.StartsWith("%"))
			{
				OnChatCommand(client, msg.Substring(1));
				return;
			}
			switch(type)
			{
				case CHATMESSAGETYPE.SAY:
				{
					ServerPacket pkg = new ServerPacket(SMSG.MESSAGECHAT);
					pkg.Write((byte)CHATMESSAGETYPE.SAY);
					pkg.Write((int)0);
					pkg.Write((ulong)0); // Receiver Guid
					pkg.Write(client.Player.GUID); // Sender Guid
					pkg.Write((int)msg.Length+1); // chat fix , that did it :)
					pkg.Write(msg);
					pkg.Write((byte)0);
					pkg.Finish();
					client.Player.MapTile.Map.Send(pkg, client.Player.Position, 25.0f);
					break;
				}
				case CHATMESSAGETYPE.YELL:
				{
					ServerPacket pkg = new ServerPacket(SMSG.MESSAGECHAT);
					pkg.Write((byte)CHATMESSAGETYPE.YELL);
					pkg.Write((int)0);
					pkg.Write((ulong)0);
                    pkg.Write(client.Player.GUID); // fix 1.3.1
					pkg.Write((int)msg.Length+1); // chat fix
					pkg.Write(msg);
					pkg.Write((byte)0);
					pkg.Finish();
					client.Player.MapTile.Map.Send(pkg, client.Player.Position, 50.0f);
					break;
				}
				case CHATMESSAGETYPE.EMOTE:
				{
					ServerPacket pkg = new ServerPacket(SMSG.MESSAGECHAT);
					pkg.Write((byte)CHATMESSAGETYPE.EMOTE);
					pkg.Write((int)0);
					pkg.Write((ulong)0);
					pkg.Write(client.Player.GUID); // fix 1.3.1
					pkg.Write((int)msg.Length+1); // chat fix
					pkg.Write(msg);
					pkg.Write((byte)0);
					pkg.Finish();
					client.Player.MapTile.Map.Send(pkg, client.Player.Position, 25.0f);
					break;
				}
				case CHATMESSAGETYPE.CHANNEL:
				{
					ChannelManager.TalkTo(channel,client,msg);
					break;
				}

				case CHATMESSAGETYPE.PARTY:
				{	
					ServerPacket pkg = new ServerPacket(SMSG.MESSAGECHAT);
					pkg.Write((byte)CHATMESSAGETYPE.PARTY);
					pkg.Write((int)0);
					pkg.Write((ulong)0);
					pkg.Write(client.Player.GUID); // fix 1.3.1
					pkg.Write((int)msg.Length+1); // chat fix
					pkg.Write(msg);
					pkg.Write((byte)0);
					client.Player.Group.SendToGroup(pkg);
					break;
				}
					
			}
			return;
		}
	}

	public class Chat
	{
		public static void System(string msg)
		{
			/*BinWriter pkg = LoginClient.NewPacket(SMSG.MESSAGECHAT);
			pkg.Write((byte)CHATMESSAGETYPE.SYSTEM);
			pkg.Write((int)0);
			pkg.Write((ulong)0);
			pkg.Write(msg);
			pkg.Write((byte)0);
			LoginServer.Instance.BroadcastPacket(pkg);*/
			Console.WriteLine("WoWDaemon.World.Chat.System(msg) not in yet");
		}


		static void System(string msg, uint to)
		{
			ServerPacket pkg = new ServerPacket(SMSG.MESSAGECHAT);
			pkg.Write((byte)CHATMESSAGETYPE.SYSTEM);
			pkg.Write((int)0);
			pkg.Write((ulong)0);
			pkg.Write((int)msg.Length+1); // chat fix
			pkg.Write(msg);
			pkg.Write((byte)0);
			pkg.Finish();
			pkg.AddDestination(to);
			WorldServer.Send(pkg);
		}

		public static void System(WorldClient client, string msg)
		{
			System(msg, client.CharacterID);
		}
		public static void System(PlayerObject player, string msg)
		{
			System(msg, player.CharacterID);
		}

	}

}
