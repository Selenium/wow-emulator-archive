using Server.Items;
using Server.Creatures;

namespace Server.Quests
{	
public class The_Sprouted_Fronds : BaseQuest
	{
		public The_Sprouted_Fronds() : base()
		{
			id = 2399;
			name = "The Sprouted Fronds";
			desc = "$N, You must get The Sprouted Fronds.";
			details = "The Sprouted Frond starts in a harpy's nest, way north of the glade. You should see a big pink light surrounding a palm-like tree.";
			questFlags = 0x020;
			idealLevel = 10;
			minLevel = 5;
			zone = 9;
			rewardXp = 564;
			previousQuest = 931;
			raceAllowed = qRaces.Any;
			npcTargetId = 2080;
		}
		public override void InitObjectives()
		{
			reward.Add( 5205, 5 );
			deliveryObjectives.Add( 5190, 1 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c ) 
		{
			return BaseNPC.QDS( questOwner, c, this ); 
		}
	}
}
