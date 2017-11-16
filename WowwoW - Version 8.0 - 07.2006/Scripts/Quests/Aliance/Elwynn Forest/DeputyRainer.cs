using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
	public class Riverpaw_Gnoll_Bounty  : BaseQuest
	{
		public Riverpaw_Gnoll_Bounty() : base()
		{
			id = 11;
			npcId = 963;
			name = "Riverpaw Gnoll Bounty ";
			desc = "Bring 8 Painted Gnoll Armbands to Deputy Rainer at the Barracks.";
			details = "Gnolls, brutish creatures with no decent business in these lands, have been seen along the borders of Elwynn Forest. A large pack of them, many more than we can handle alone, have infested the woods south of the guard tower yonder. Another group has infested the areas near Stone Cairn Lake to the east.\n\nThe Stormwind Army will commend whomever helps kill them. Bring me their painted gnoll armbands as proof of your deed.";
			questFlags = 0x020;
			idealLevel = 10;
			minLevel = 9;
			zone = 9;
			rewardXp = 1000;
			previousQuest = 239;
			finishDialog = "I see you've been busy! You have our thanks, $N.";
		}
		public override void InitObjectives()
		{
			reward.Add( 2249, 1 );
			reward.Add( 2238, 1 );
			deliveryObjectives.Add( 782, 8 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
	}
}