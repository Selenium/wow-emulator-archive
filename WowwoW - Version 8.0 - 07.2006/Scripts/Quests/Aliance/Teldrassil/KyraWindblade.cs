using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
	public class Elanaria  : BaseQuest
	{
		public Elanaria () : base()
		{
			id = 1684;
			npcId = 3598;
			name = "Elanaria";
			desc = "Speak with Elanaria.";
			details = "Greetings, warrior. Your skill grows, but there is more to your profession than you may believe. To further progress, you must soon find a teacher./n/nThe warrior Elanaria dwells in Darnassus, at the Warrior's Terrace. She can instruct you.";
			questFlags = 0x020;
			idealLevel = 10;
			minLevel = 9;
			zone = 141;
			finishDialog = "Ah. I was hoping you'd be prompt in answering my summons. I have an important task that I would like you to perform.";
			npcTargetId = 4088;
			classAllowed=qClasses.Warrior;
			raceAllowed=qRaces.Alliance;
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );
		}
	}
}
