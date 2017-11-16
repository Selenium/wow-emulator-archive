using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
public class Erion_Shadewhisper : BaseQuest
	{
		public Erion_Shadewhisper() : base()
		{
			id = 2259;
			npcId = 4146;
			name = "Erion Shadewhisper";
			desc = "Contact Erion Shadewhisper in Darnassus.";
			details = "Do not worry, $N, I am not sending you to see Syurna. Erion requires your presence at the Cenarion Enclave. Make haste!";
			questFlags = 0x020;
			idealLevel = 16;
			minLevel = 11;
			zone = 1657;
			rewardXp = 643;
			npcTargetId = 4214;
			classAllowed=qClasses.Rogue;
			raceAllowed=qRaces.Alliance;
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c ) 
		{
			return BaseNPC.QDS( questOwner, c, this ); 
		}
	}
}
	
	
