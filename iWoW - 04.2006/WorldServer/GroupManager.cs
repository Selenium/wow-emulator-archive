using System; 
using WoWDaemon.Common; 
using WoWDaemon.Common.Attributes; 
//using WoWDaemon.World;
using WoWDaemon.Database;
using WoWDaemon.Database.DataTables;

namespace WoWDaemon.World
{
//	[WorldPacketHandler()]
	public class GroupObject
	{
		public PlayerObject[] Members;
		public ulong LeaderGUID;
		public uint LootMethod;
		public ulong LootMaster;
		public string LootMasterName;
		public uint Size;
		//			uint MemberCount;
		public GroupObject(PlayerObject player, PlayerObject leader)
		{
			Console.WriteLine("Initilizing Group");
			Members=new PlayerObject[16];
			Members[0]=leader;
			Members[1]=player;
			Size=2;
			LeaderGUID=leader.GUID;
			LootMethod=0;
			LootMaster=leader.GUID;
			LootMasterName=leader.Name;
		}

		public void AddMember(PlayerObject player)
		{
			Members[Size]= player;
			Size++;
			player.Group=this;
		}


/*		public void SendNewLeader(string newleadername)
		{
			SendToGroup(grp);
		}
*/

/*		public void SetLootMethod(uint lootmethod, ulong lootmaster)
		{
			LootMethod=lootmethod;
			LootMaster=lootmaster;
			SendGroupList();
		}
*/
		public void RemoveMember(string membername)
		{
			ServerPacket grp = new ServerPacket(SMSG.GROUP_UNINVITE);
			grp.Write(membername);
			for (uint h=0;h<Size;h++)
				if (Members[h].Name==membername) grp.Write(Members[h].GUID);
			SendToGroup(grp);
			bool Removed=false;
			for (uint i=0;i<Size;i++)
			{
				if (Members[i].Name.ToLower()==membername.ToLower())
				{
					Removed=true;
					Members[i].Group=null;
					Removed=true;
				}
				else
				{
					if (Removed)
						Members[i-1]=Members[i];
				}
				if (Removed && i==Size-1)
				{
					Members[1]= null;
					Size--;
				}
			}
		}

		public void Destroy()
		{
			ServerPacket grp = new ServerPacket(SMSG.GROUP_DESTROYED);
			SendToGroup(grp);
			for (uint i=0;i<Size;i++)
			{
				Members[i].Group=null;
				Members[i].IsLeader=false;
			}
		}

		public void SendToGroup(ServerPacket grp)
		{
			grp.Finish();
			for (uint i=0;i<Size;i++)
				grp.AddDestination(Members[i].CharacterID);
			WorldServer.Send(grp);
		}

		public void SendGroupList()
		{
			Console.WriteLine("Sending Group List");
			
			for (uint i=0;i<Size;i++)
			{
				ServerPacket grp = new ServerPacket(SMSG.GROUP_LIST);	
				grp.Write((int)Size-1);						// Counter
				for (uint j=0;j<Size;j++)
					if (j!=i)
					{	
						grp.Write(Members[j].Name);			// Member Name
						grp.Write(Members[j].GUID);			// Member GUID
						grp.Write(Members[j].IsLeader);		// Is Member Leader?
					}											
				grp.Write(LeaderGUID);						// Leader GUID
				grp.Write(LootMethod);
				grp.Write(LootMasterName);
				grp.Write(LootMaster);
//				grp.Write((byte)0);
//				grp.Write(LootMaster);						// Trying LootMaster GUID - Phaze
				grp.Finish();						
				grp.AddDestination(Members[i].CharacterID);
				WorldServer.Send(grp);
			}
		}//SendGroupList
	}//GroupObject

	[WorldPacketHandler()]
	public class GroupManager
	{

		[WorldPacketDelegate(CMSG.GROUP_SET_LEADER)]
		static void OnSetLeader(WorldClient client, CMSG msgID, BinReader data)
		{
			string newleadername=data.ReadString();
			if (client.Player.IsLeader==false) {Chat.System(client, "Only the leader can set a new leader");return;}
			if (client.Player.Group==null) {Chat.System(client, "You must be in a group");return;}
			bool SetNew=false;
			for (uint i=0;i<client.Player.Group.Size;i++)
			{
				if (client.Player.Group.Members[i].Name.ToLower()==newleadername.ToLower())
				{
					client.Player.IsLeader=false;
					client.Player.Group.Members[i].IsLeader=true;
					client.Player.Group.LeaderGUID=client.Player.Group.Members[i].GUID;
					client.Player.Group.LootMaster=client.Player.Group.LeaderGUID;
					client.Player.Group.LootMasterName=newleadername;
					SetNew=true;
					break;
				}
			}

			if (!SetNew) {Chat.System(client, "Invalid new leader");return;}
			else
			{
				ServerPacket grp = new ServerPacket(SMSG.GROUP_SET_LEADER);
				grp.Write(newleadername);
//				grp.Write(client.Player.Group.LeaderGUID);
				client.Player.Group.SendToGroup(grp);
			}
			client.Player.Group.SendGroupList();
			return;
		}		

		[WorldPacketDelegate(CMSG.LOOT_METHOD)]
		static void LootMethod(WorldClient client, CMSG msgID, BinReader data)
		{
			uint newlootmethod=data.ReadUInt32();
			if (newlootmethod==2)
			{
				Chat.System(client, "This looting method is temporarily disabled");
				return;
			}
			client.Player.Group.LootMaster = data.ReadUInt64();
			client.Player.Group.SendGroupList();			
			return;
		}

		[WorldPacketDelegate(CMSG.GROUP_UNINVITE)]
		static void OnUninvite(WorldClient client, CMSG msgID, BinReader data)
		{
			string name = data.ReadString();
			if (client.Player.Group.Size>2)
				client.Player.Group.RemoveMember(name);
			else
				client.Player.Group.Destroy();
			return;
		}

		[WorldPacketDelegate(CMSG.GROUP_DISBAND)]
		static void OnDisband(WorldClient client, CMSG msgID, BinReader data)
		{
			if (client.Player.IsLeader||client.Player.Group.Size<3)
				client.Player.Group.Destroy();
			else
				client.Player.Group.RemoveMember(client.Player.Name);
			return;
		}

		[WorldPacketDelegate(WORLDMSG.GROUPCREATE)]
		static void OnGroupCreate(WORLDMSG msgID, BinReader data) 
		{
			uint charID = data.ReadUInt32();
			WorldClient client=WorldServer.GetClientByCharacterID(charID);
			uint leaderID = data.ReadUInt32();
			WorldClient leader=WorldServer.GetClientByCharacterID(leaderID);
			if (leader==null)
			{
				Console.WriteLine("Leader not found");
				return;
			}

			if (leader.Player.Group==null)
			{
				leader.Player.Group = new GroupObject(client.Player, leader.Player);
			}
			else
			{
				for (uint i=0;i<leader.Player.Group.Size;i++)
					if (leader.Player.Group.Members[i].CharacterID==charID)
						return;
				leader.Player.Group.AddMember(client.Player);
			}

			client.Player.Group=leader.Player.Group; 
			leader.Player.IsLeader=true;
			client.Player.Group.LeaderGUID=leader.Player.GUID;
			client.Player.Group.SendGroupList();
		}		

	}//GroupManager
}//NameSpace 
