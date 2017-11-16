using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
	public class Speak_with_Gramma  : BaseQuest
	{
		public Speak_with_Gramma() : base()
		{
			id = 111;
			npcId = 252;
			name = "Speak with Gramma ";
			desc = "Speak with Gramma Stonefield.";
			details = "Please, $N, talk with my Gramma. If anyone can find a way to bring me together with Maybell, she can.\n\nShe's inside our house east of here.";
			questFlags = 0x020;
			idealLevel = 6;
			minLevel = 6;
			zone = 9;
			rewardXp = 100;
			npcTargetId = 248;
			previousQuest = 106;
			finishDialog = "While our families are feuding, Tommy Joe and Maybell don't have much of a future, but... maybe we can get them together for just a little while. \n\nHm, what can we do...";
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
	}
}