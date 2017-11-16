using System; 
using WoWDaemon.Common; 
using WoWDaemon.Common.Attributes; 
using WoWDaemon.Login;
using WoWDaemon.Database;
using WoWDaemon.Database.DataTables;

namespace LoginScripts.ClientPackets
{
	/// <summary>
	/// Summary description for QuestNPC.
	/// </summary>
	[LoginPacketHandler()]
	public class Vendors
	{
		[LoginPacketDelegate(CMSG.QUESTGIVER_STATUS_QUERY)]
		static bool Hello(LoginClient client, CMSG msgID, BinReader data)
		{
			ulong quester = data.ReadUInt64();

			BinWriter pkg = LoginClient.NewPacket(SMSG.QUESTGIVER_STATUS);
			
			pkg.Write(quester);
			pkg.Write((int)3);

			client.Send(pkg);

			return true;
		}

		[LoginPacketDelegate(CMSG.QUESTGIVER_HELLO)]
		static bool Quest(LoginClient client, CMSG msgID, BinReader data)
		{

			BinWriter pkg = LoginClient.NewPacket(SMSG.QUESTGIVER_QUEST_LIST);
			
			ulong quester = data.ReadUInt64();
			string greets = ("Hy, " +client.Character.Name+ ", the " +client.Character.Class+ "!");
			
			int lenght = DataServer.Database.GetObjectCount(typeof(DBQuest));
			
			pkg.Write(quester);
			pkg.Write(greets);
			pkg.Write((int)5);						// Quester Emote Delay (5 is default)
			pkg.Write((int)3);						// Quester Emote 
			pkg.Write((byte)lenght);				// Quest Counter

			int i = 1;
			while (i <= lenght)
			{
				DBQuest quest = null;
				quest = (DBQuest)DataServer.Database.FindObjectByKey(typeof(DBQuest), i);
				
				pkg.Write(i);						// Quest ID
				pkg.Write(quest.RequiredLevel);		// Quest Level
				pkg.Write((int)5);					// ??
				pkg.Write(quest.Title);				// Quest Description
				i++;

			}
			client.Send(pkg);

			return true;
		}

		[LoginPacketDelegate(CMSG.QUESTGIVER_QUERY_QUEST)]
		static bool QuestDetails(LoginClient client, CMSG msgID, BinReader data)
		{
			ulong quester = data.ReadUInt64();
			int questid = data.ReadInt32();

			DBQuest quest = null;
			quest = (DBQuest)DataServer.Database.FindObjectByKey(typeof(DBQuest), questid);
			
			BinWriter q1 = LoginClient.NewPacket(SMSG.QUESTGIVER_QUEST_DETAILS);
			
			q1.Write(quester);						// Quester GUID
			q1.Write(questid);						// Quest ID

			q1.Write(quest.Title);					// Quest Title
			q1.Write(quest.Description);			// Quest Details
			q1.Write(quest.Objectives);				// Quest Objectives

			q1.Write((int)0);						//?

			q1.Write((int)1);						// Choice Reward Item Counter - TODO: ADD ARRAY ON DB
			
			q1.Write(quest.ChooseRewardID);			// Choice Reward Item Template_ID
			q1.Write(quest.ChooseQuantity);			// Choice Reward Item Quantity
			q1.Write(quest.ChooseDisplayID);		// Choice Reward Item Display_ID

			q1.Write((int)1);						// Always Reward Item Counter - TODO: ADD ARRAY ON DB
			
			q1.Write(quest.AlwaysRewardID);			// Always Reward Template_ID
			q1.Write(quest.AlwaysRewardQuantity);	// Always Reward Item Quantity
			q1.Write(quest.AlwaysDisplayID);		// Always Reward Item Display_ID

			q1.Write(quest.MoneyReward);			// Money Reward
			q1.Write((int)0);						// ?
			q1.Write((int)0);						// ?
			
			client.Send(q1);

			Chat.System(client, "Quest Details for quest id " +questid+ " from quester "+quester);
			
			return true;

		}

		[LoginPacketDelegate(CMSG.QUESTGIVER_ACCEPT_QUEST)]
		static bool QuestAccept(LoginClient client, CMSG msgID, BinReader data)
		{
			ulong quester = data.ReadUInt64();
			uint questid = data.ReadUInt32();

			DBKnownQuest nquest = new DBKnownQuest();
			
			nquest.CharacterID = client.Character.ObjectId;
			if (client.Character.Quest == null || client.Character.Quest.Length==0)
				nquest.Quest_Slot=1;
			else
				nquest.Quest_Slot=(uint)client.Character.Quest.Length+1;
			
			nquest.CharacterID=client.Character.ObjectId;
			nquest.Quest_ID = questid;
			nquest.Quest_Status = 1;

			DataServer.Database.AddNewObject(nquest);
			DataServer.Database.FillObjectRelations(client.Character);
			DataServer.Database.FillObjectRelations(client.Character.Quest[nquest.Quest_Slot-1]);
			
			Chat.System(client, "Quest ID "+questid+" accepted on NPC :"+quester);

			return true;

		}

		[LoginPacketDelegate(CMSG.QUEST_QUERY)]
		static bool QuestQuery(LoginClient client, CMSG msgID, BinReader data)
		{
			uint questid = data.ReadUInt32();

			Chat.System(client, "Quest Query for ID "+questid);

			return true;

		}
	}
}
