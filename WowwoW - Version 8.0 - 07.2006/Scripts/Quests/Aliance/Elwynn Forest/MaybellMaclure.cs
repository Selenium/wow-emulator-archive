using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
	public class Young_Lovers  : BaseQuest
	{
		public Young_Lovers() : base()
		{
			id = 106;
			npcId = 251;
			name = "Young Lovers";
			desc = "Give Maybell's Love Letter to Tommy Joe Stonefield.";
			details = "Oh, I'm cursed! My heart belongs to Tommy Joe Stonefield, but our families are bitter enemies. So I can't see him, even though my eyes ache to gaze upon that handsome face!\n\n Please, take this letter and give it to Tommy Joe. He's usually at the river to the west of the Stonefield Farm, which is due west of here.";
			questFlags = 0x020;
			idealLevel = 6;
			minLevel = 6;
			zone = 9;
			rewardXp = 100;
			npcTargetId = 252;
			finishDialog = "You have what?? Maybell is the light of my dull life. Hurry, let me see her letter!\n\nAh! I can't stand us being apart. I have to see her!!";
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
	}
}