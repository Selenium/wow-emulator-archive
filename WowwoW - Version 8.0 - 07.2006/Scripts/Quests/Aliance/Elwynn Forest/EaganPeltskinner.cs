using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
	public class Wolves_Across_the_Border : BaseQuest
	{
		public Wolves_Across_the_Border() : base()
		{
			id = 33;
			npcId = 196;
			name = "Wolves Across the Border";
			desc = "Bring 8 pieces of Tough Wolf Meat to Eagan Peltskinner outside Northshire Abbey.";
			details = "I hate those nasty timber wolves!  But I sure like eating wolf steaks...  Bring me tough wolf meat and I will exchange it for something you'll find useful.\nTough wolf meat is gathered from hunting the timber wolves and young wolves wandering the Northshire countryside.";
			questFlags = 0x020;
			idealLevel = 2;
			minLevel   = 1;
			zone = 9;
			rewardXp = 340;
			previousQuest = 5261;
			finishDialog= "Hey $N, I'm getting hungry... did you get that Tough Wolf Meat?\n\nYou've been busy! I can't wait to cook up that Wolf Meat... \n\nI have some things here you might want - take your pick!\n\n";
			progressDialog= "Hey $N. I'm getting hungry...did you get that tough wolf meat?";
		}
		public override void InitObjectives()
		{
			deliveryObjectives.Add( 750, 8 );
			rewardChoice.Add( 6070, 1 );
			rewardChoice.Add( 80, 1 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
	}
	
}
