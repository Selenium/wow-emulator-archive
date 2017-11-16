using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
	public class Tumors : BaseQuest
	{
		public Tumors() : base()
		{
			id = 923;
			npcId = 3517;
			name = "Tumors";
			desc = "Bring 5 Mossy Tumors to Rellian Greenspyre in Darnassus.";
			details = "There is a malevolence growing in the timberlings. We are trying to find the source, but until we do...in order to keep Teldrassil safe we must cut down the timberlings who are beyond help. Those that wander Wellspring Lake in northern Teldrassil are the most tainted. They must be removed! Destroy the Timberlings you find there, and gather the mossy tumors growing upon them. Bring the tumors to me so that they may be burned.";
			questFlags = 0x020;
			idealLevel = 9;
			minLevel = 7;
			zone = 141;
			rewardGold = 600;
			rewardXp = 625;
            previousQuest = 922;
            raceAllowed = qRaces.Alliance;
		}
		public override void InitObjectives()
		{
			deliveryObjectives.Add( 5170, 5 );
            rewardChoice.Add( 5605, 1 );
		}
        public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );
		}
	}
	public class Return_to_Denalan : BaseQuest
	{
		public Return_to_Denalan() : base()
		{
			id = 2498;
			npcId = 3517;
			name = "Return to Denalan";
			desc = "Rellian Greenspyre wants you to speak with Denalan at Lake Al'Ameth.";
			details = "I have just received word that Denalan at Lake Al'Ameth has discovered what may be the cause of the tumors that plague the timberlings. Please speak with him, and tell him I sent you. Make haste, $N; he needs our help.";
			questFlags = 0x020;
			idealLevel = 9;
			minLevel = 7;
			zone = 141;
            npcTargetId = 2080;
            previousQuest = 923;
            raceAllowed = qRaces.Alliance;
		}
        public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );
		}
	}

}
