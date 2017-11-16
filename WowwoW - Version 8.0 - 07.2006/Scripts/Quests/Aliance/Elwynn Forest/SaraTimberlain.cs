using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
	public class Red_Linen_Goods  : BaseQuest
	{
		public Red_Linen_Goods() : base()
		{
			id = 83;
			npcId = 278;
			name = "Red Linen Goods";
			desc = "Bring 6 Red Linen Bandanas to Sara Timberlain at the Eastvale Logging Camp.";
			details = "The Defias gang in Northshire wears burlap masks, but the Defias in Elwynn wear linen which I can use to make fine linen goods.\n\nBring me red linen bandanas and I'll use them to fashion something for you.\n\nDefias gang members have camps pocketed throughout Elwynn.";
			questFlags = 0x020;
			idealLevel = 9;
			minLevel = 9;
			zone = 9;
			rewardXp = 600;
			finishDialog = " Ah, these are nice bandanas, if a little rough... \n\nHere you are!";
		}
		public override void InitObjectives()
		{
			rewardChoice.Add( 983, 1 );
			rewardChoice.Add( 2575, 1 );
			deliveryObjectives.Add( 1019, 6 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
	}
}