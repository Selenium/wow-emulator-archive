using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
	public class Redridge_Rendezvous : BaseQuest
	{
		public Redridge_Rendezvous() : base()
		{
			id = 2281;
			npcId = 6946;
			name = "Redridge Rendezvous";
			desc = "Venture forth to Lakeshire in the Redridge Mountains and speak with Lucius.";
			details = "Sending you out in the field now would be suicide. Renzik doesn't need another dead rogue on his hands. Don't fret, though, $N - Renzik is going to get you up to speed.$B$BMake your way to the Redridge Mountains and speak with an associate of SI:7 named Lucius. You will find him hanging around the docks of Lakeshire with the other shady good-for-nothings.";
			questFlags = 0x00;
			idealLevel = 16;
			minLevel = 1;
			zone = 80;
			rewardXp = 728;
			previousQuest = 2260;
			classAllowed=qClasses.Rogue;
			raceAllowed=qRaces.Alliance;
			npcTargetId = 6966;
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c ) 
		{ 
			return BaseNPC.QDS( questOwner, c, this );
		}
	}
}
