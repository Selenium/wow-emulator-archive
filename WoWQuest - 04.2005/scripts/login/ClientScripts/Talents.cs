using System; 
using WoWDaemon.Common; 
using WoWDaemon.Common.Attributes; 
using WoWDaemon.Login;
using WoWDaemon.Database;
using WoWDaemon.Database.DataTables;

namespace LoginScripts.TalentsScripts
{
	[LoginPacketHandler()]
	public class Talents
	{
		[LoginPacketDelegate(CMSG.LEARN_TALENT)]
		static bool LearnTalent(LoginClient client, CMSG msgID, BinReader data)
		{
			uint talentid = data.ReadUInt32();
			
			DBTalents targetTalent = null;
			targetTalent = (DBTalents)DataServer.Database.FindObjectByKey(typeof(DBTalents), talentid);
			if (targetTalent == null) {Chat.System(client, "Talent "+talentid+" not found on DB"); return true;}
			DBKnownTalents newTalent = null;

			try
			{
				newTalent = (DBKnownTalents)DataServer.Database.FindObjectByKey(typeof(DBKnownTalents), talentid);
			}
			catch(WoWDaemon.Database.DatabaseException e)
			{
				client.Close(e.Message);
				return true;
			}
			
			if (newTalent == null)
			{
				newTalent = new DBKnownTalents();
				newTalent.CharacterID = client.Character.ObjectId;
				newTalent.Talent_Id = talentid;
				newTalent.TalentLevel = 1;
				DataServer.Database.AddNewObject(newTalent);
				DataServer.Database.FillObjectRelations(client.Character);
			}
			else
			{
				newTalent.TalentLevel++;
				DataServer.Database.SaveObject(newTalent);
			}
				
			Chat.System(client, "Talent Learned: "+talentid);

			return true;
		}
	}
}
