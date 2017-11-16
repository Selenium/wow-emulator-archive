using System;
using System.Text.RegularExpressions;
using System.Collections;
using WoWDaemon.Common;
using WoWDaemon.Common.Attributes;
//using WoWDaemon.Login;
using WoWDaemon.Database.DataTables;
using WoWDaemon.Database;
using WoWDaemon.World;
using WorldScripts.Living;
namespace WorldScripts.ScriptPackets
{
	/// <summary>
	/// Summary description for Spawn.
	/// </summary>
	[ScriptPacketHandler()]
	public class MiscPackets
	{
		[ScriptPacketHandler(MsgID=0x03)]
		static void OnAccessUpdate(int msgID, BinReader data)
		{
			uint charID = data.ReadUInt32();
			ACCESSLEVEL newAccessLevel=(ACCESSLEVEL)data.ReadByte();
			WorldClient client=WorldServer.GetClientByCharacterID(charID);
			client.Player.AccessLvl=newAccessLevel;
			client.Player.UpdateData();
		}		

		[ScriptPacketHandler(MsgID=0x04)]
		static void OnZoneUpdate(int msgID, BinReader data)
		{
			uint charID = data.ReadUInt32();
			uint newZone= data.ReadUInt32();
			WorldClient client = WorldServer.GetClientByCharacterID(charID);
			client.Player.Zone = newZone;
			client.Player.UpdateData();
		}		

		[ScriptPacketHandler(MsgID=0x07)]
		static void OnGuildUpdate(int msgID, BinReader data)
		{
			uint charID = data.ReadUInt32();
			WorldClient client=WorldServer.GetClientByCharacterID(charID);
			client.Player.GuildID = data.ReadUInt32();
			client.Player.GuildRank = data.ReadUInt32();
			client.Player.GuildTimeStamp = WorldClock.GetTimeStamp();
			client.Player.Save();
			client.Player.UpdateData();
			client.Player.GuildTimeStamp = WorldClock.GetTimeStamp();
			client.Player.UpdateData();
			//			EventManager.AddEvent(new DelayedUpdateEvent(client.Player));
			return;
		}		

		[ScriptPacketHandler(MsgID=0x08)]
		static void OnGroupCreate(int msgID, BinReader data)
		{
			Console.WriteLine("Creating Group");
			uint charID = data.ReadUInt32();
			WorldClient client=WorldServer.GetClientByCharacterID(charID);
			uint leaderID = data.ReadUInt32();
			WorldClient leader=WorldServer.GetClientByCharacterID(leaderID);
			if (leader==null)
				Console.WriteLine("Leader not found");
			if (leader.Player.Group==null)
			{
				leader.Player.Group = new GroupObject(client.Player, leader.Player);
			}
			else
			{
				leader.Player.Group.AddMember(client.Player);
			}
			if (leader.Player.Group==null)
				Console.WriteLine("Error creating group");
			client.Player.Group=leader.Player.Group; 
			leader.Player.IsLeader=true;
			client.Player.Group.LeaderGUID=leader.Player.GUID;
			Console.WriteLine("Groups assigned");
			client.Player.Group.SendGroupList();
		}		

/*		public class DelayedUpdateEvent : WorldEvent
		{
			PlayerObject m_player;
			public DelayedUpdateEvent(PlayerObject player) : base(TimeSpan.FromSeconds(2))
			{
				m_player = player;
			}

			public override void FireEvent()
			{
				m_player.GuildTimeStamp = WorldClock.GetTimeStamp();
				m_player.UpdateData();
				m_player.PlayerFlags |= (byte)0x10;
				m_player.Flags |= 0x10000;
				m_player.UpdateData();

				m_player.PlayerFlags ^= (byte)0x10;
				m_player.Flags ^= 0x10000;
				m_player.UpdateData();

			}
		}
*/		
	}
}
