using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
	public class Return_To_Lewis   : BaseQuest
	{
		public Return_To_Lewis() : base()
		{
			id = 6285; 
			npcId = 352;
			name = "Return to Lewis ";
			desc = "Buy a gryphon ride to Sentinel Hill from the gryphon master Dungar Longdrink, then take Osric's Crate to Lewis at Sentinel Hill.";
			details = "The gryphon master in Westfall is Thor. If you've spoken to him before, then you can take one of my gryphons to him./n/nThat's a good lesson to know: gryphons are always trained to fly to their capital city, but they'll only take you to a remote gryphon master after you've already been there./n/nYou've already been to Thor, so just speak with me again when you're ready to take a gryphon to Westfall. Once there, you can deliver Osric's Crate to Quartermaster Lewis.";
			questFlags = 0x020;
			idealLevel = 10;
			minLevel = 10;
			zone = 1519;
			finishDialog = "Great, you brought the armor! We'll get this divvied to those who need it immediately. /n/nThank you, $N. Your efforts have been a great help to us. And now that you're no stranger to gryphons, I hope you'll come and lend your aid to Sentinel Hill often!";
			rewardXp= 1050;
			rewardGold = 350;
			previousQuest = 6261;
			npcTargetId = 491;
			questIsBugged = true;
		}
		public override void InitObjectives()
		{
			deliveryObjectives.Add( 16115, 1 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
	}
}