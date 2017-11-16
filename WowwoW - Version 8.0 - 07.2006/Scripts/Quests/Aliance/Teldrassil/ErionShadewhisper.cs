using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
	public class Erions_Behest : BaseQuest
	{
		public Erions_Behest() : base()
		{
			id = 2260;
			npcId = 4214;
			name = "Erion's Behest";
			desc = "Travel to Stormwind City and seek council with Renzik The Shiv.";
			details = "Word of your deeds has spread far and wide, $N. So far, in fact, that Stormwind Intelligence has asked for you by name. The journey is taxing and not without peril, but an opportunity to train under SI:7 should not be taken lightly. A new world awaits you, $N. Make your way to Old Town in Stormwind and speak with Renzik The Shiv at SI:7 headquarters. ";
			questFlags = 0x020;
			idealLevel = 16;
			minLevel = 14;
			zone = 1657;
			rewardXp = 728;
			finishDialog = "You performed your duties well.";
			progressDialog = "Hey $N, can you done it ?";
			classAllowed = qClasses.Rogue;
			raceAllowed = qRaces.Alliance;
			npcTargetId = 6946; 
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );
		}
	}
}
