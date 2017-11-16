using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
	public class Stormpikes_Delivery  : BaseQuest
	{
		public Stormpikes_Delivery() : base()
		{
			id = 353;
			npcId = 1416;
			name = "Stormpike's Delivery ";
			desc = "Deliver the Package for Stormpike to Mountaineer Stormpike in Loch Modan.";
			details = "The Stormpikes are a respected dwarven clan, and are well known for their fine and discerning tastes. So it's no wonder that Gringer Stormpike, a Mountaineer of Ironforge, commissioned me to craft him a weapon.\n\n The weapon is finished, but... Mountaineer Stormpike is far away, in distant Loch Modan. If you plan on traveling to the north, can you deliver this package to him?\n\nMy last message from Mountaineer Stormpike said he's stationed at the northern guard tower in Loch Modan.";
			questFlags = 0x020;
			idealLevel = 15;
			minLevel = 9;
			zone = 1;
			rewardXp = 1050;
			previousQuest = 1097;
			rewardGold = 700;
			//npcTargetId =12047;
			finishDialog = "Aha! So Grimand finally finished my axe! I can't wait to try it against some troggs and kobolds! \n\nMany thanks, $N. It was a long distance to travel for this delivery. Here are some coins for your efforts.";
			questIsBugged = true;
		}
		public override void InitObjectives()
		{
			rewardChoice.Add( 2186, 1 );
			rewardChoice.Add( 2691, 1 );
			rewardChoice.Add( 11192, 1 );
			deliveryObjectives.Add( 2806, 1 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
		public override void OnAcceptQuest( Character c )
		{
			c.PutObjectInBackpack( new PackageForStormpike(), true );
		}
	}
}