using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
	public class Althers_Mill : BaseQuest
	{
		public Althers_Mill() : base()
		{
			id = 2282;
			npcId = 6966;
			name = "Alther's Mill";
			desc = "Open Lucius's Lockbox, recover the Token of Thievery and return it to Lucius in Lakeshire.";
			details = "We've been training thieves here for years! After all, not every rapscallion is born with the grace and finesse of old Lucius.$B$BUp off the road here you'll find Alther's Mill. I got a chest up there with something important inside. Go get it for me! Bring back that token and you'll receive your Certificate of Thievery!";
			questFlags = 0x022;
			idealLevel = 20;
			minLevel = 18;
			zone = 44;
			rewardXp = 1140;
			previousQuest = 2281;
			raceAllowed=qRaces.Alliance;
			classAllowed=qClasses.Rogue;
			questIsBugged = true;
		}
		public override void InitObjectives()
		{
			reward.Add( 7907, 1 );
			deliveryObjectives.Add( 7871, 1 );
		}
		public override void OnAcceptQuest(Character c)
		{
			c.PutObjectInBackpack( World.CreateItemInPoolById(5060), 1, true);
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c ) 
		{
			return BaseNPC.QDS( questOwner, c, this ); 
		}
	}
}
