using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
	public class A_Bundle_of_Trouble  : BaseQuest
	{
		public A_Bundle_of_Trouble() : base()
		{
			id = 5545;
			npcId = 10616;
			name = "A Bundle of Trouble";
			desc = "Bring 8 Bundles of Wood to Raelen at the Eastvale Logging Camp.";
			details = "I've got a real problem on my hands. I have a deadline looming for an order of lumber, and I'm running out of time. The wolves and bears north of here have chased my workers away from the bundles of wood that they've already chopped.\n\nI've already talked to Deputy Rainer about clearing the animals, but I need someone to go collect the wood for me. If you could collect eight bundles of wood for me I might just make my deadline.";
			questFlags = 0x020;
			idealLevel = 9;
			minLevel = 7;
			zone = 9;
			rewardXp = 775;
			rewardGold = 300;
			finishDialog = "Excellent! Thanks to you, I should be able to complete the order in time. To show my gratitude, I would like to offer some coin as compensation for your troubles. \n\nThank you and farewell. ";
			progressDialog = "That deadline isn't getting any further away, $C. Please hurry and collect those bundles of wood. ";
		}
		public override void InitObjectives()
		{
			deliveryObjectives.Add( 13872, 8 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
	}
}