using Server.Items;
using Server.Creatures;

namespace Server.Quests	
{
public class Stars_of_Elune_5627 : BaseQuest //NPC: 11401
	{
		public Stars_of_Elune_5627() : base()
		{
			id = 5627;
			npcId = 11401;
			npcTargetId = 11401;
			name = "Stars of Elune";
			desc = "Speak with Priestess Alathea again in result of learning a spell!";
			details = "You've proven yourself worthy of Elune's attention, $N. If you feel you're ready, I would very much like to teach you one of her spells unique to our people.";
			questFlags = 0x020;
			idealLevel = 10;
			minLevel = 10;
			zone = 1657;
			rewardXp = 226;
			previousQuest = 5628;
			classAllowed=qClasses.Priest;
			raceAllowed=qRaces.Alliance;
		}
		public override void InitObjectives()
		{
			rewardSpell = 10797;
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c ) 
		{ 
			return BaseNPC.QDS( questOwner, c, this ); 
		}
	}
}
