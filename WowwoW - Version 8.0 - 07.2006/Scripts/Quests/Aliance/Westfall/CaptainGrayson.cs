using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
	public class Keeper_Of_The_Flame   : BaseQuest
	{
		public Keeper_Of_The_Flame() : base()
		{
			id = 103;
			npcId = 392;
			name = "Keeper of the Flame ";
			desc = "Bring 5 Flasks of Oil to Captain Grayson at the Westfall Lighthouse.";
			details = "The night the Lighthouse Keeper's family died was horrible. I watched, helpless, as Old Murk-Eye led the attack. But what's done is done and now my concern is for the lives of the sailors on The Great Sea whose ships come close to the perilous rocks of the coastline. With no one to keep watch on the flame the responsibility has fallen upon me./n/n";
			questFlags = 0x020;
			idealLevel = 16;
			minLevel = 16;
			zone = 108;
			finishDialog = "Praise you, brave $C. The rocks of the Westfall Coast shall be lit thanks to your hard work. Many lives will be spared so long as the torch is kept lit. /n/nI died needlessly on this very shore. My afterlife plight is to see that no others follow my destiny.";
			progressDialog = "The flame will not burn for long without oil, $N.";
			rewardXp= 1500;
			rewardGold = 600;
		}
		public override void InitObjectives()
		{
			reward.Add( 955, 1 );
			reward.Add( 1180, 1 );
			deliveryObjectives.Add( 814, 5 );
			rewardChoice.Add( 2455, 1 );
			rewardChoice.Add( 118, 1 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
	}
}