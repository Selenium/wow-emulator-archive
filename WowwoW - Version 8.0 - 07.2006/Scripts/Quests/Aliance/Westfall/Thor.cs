using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
	public class Continue_To_Stormwind   : BaseQuest
	{
		public Continue_To_Stormwind() : base()
		{
			id = 6281;
			npcId = 523;//thor
			name = "Continue to Stormwind";
			desc = "Buy a gryphon ride from the gryphon master Thor, then bring Lewis' Note to Osric Strang, in the shop Limited Immunity, in the Old Town of Stormwind.";
			details = "For a small fee, you can take a gryphon to Stormwind, so you can deliver Lewis' note to Osric. You won't get there faster any other way./n/nIf that sounds acceptable, then just speak to me again when you're ready for the ride. I'll charge you a little, but trust me; it'll be worth it!";
			questFlags = 0x020;
			idealLevel = 10;
			minLevel = 10;
			zone = 108;
			finishDialog = "Ah, a note from Quartermaster Lewis? I'm not surprised he needs more gear. Sentinel Hill is far away, in a land Stormwind has all but forgotten. /n/nWell thank you, $N. Here's some money to cover your travel costs.";
			progressDialog = "You've been traveling, eh? Have you been anywhere interesting?";
			rewardXp= 420;
			rewardGold= 175;
			previousQuest = 6181; //A Swift Message
			npcTargetId = 1323;
			questIsBugged = true;
		}
		public override void InitObjectives()
		{
			deliveryObjectives.Add( 15998, 1 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
	}
}