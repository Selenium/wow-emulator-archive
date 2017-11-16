using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
	public class A_Swift_Message   : BaseQuest
	{
		public A_Swift_Message() : base()
		{
			id = 6181; 
			npcId = 491;
			name = "A Swift Message";
			desc = "Bring Lewis' Note to Thor the gryphon master.";
			details = "Although we don't get much aid from Stormwind directly, I do have a contact in the city who helps supply us with armor. His name is Osric Strang. His shop, Limited Immunity, is in the Old Town of Stormwind./n/nAlthough we don't get much aid from Stormwind directly, I do have a contact in the city who helps supply us with armor. His name is Osric Strang. His shop, Limited Immunity, is in the Old Town of Stormwind./n/nAlthough we don't get much aid from Stormwind directly, I do have a contact in the city who helps supply us with armor. His name is Osric Strang. His shop, Limited Immunity, is in the Old Town of Stormwind.";
			questFlags = 0x020;
			idealLevel = 10;
			minLevel = 10;
			zone = 108;
			finishDialog = "You have to get this note to Stormwind? That's not a problem, you can take one of my gryphons!";
			progressDialog = "You look like you're in a hurry. Well, then you came to the right place!";
			npcTargetId = 491;
			rewardXp = 210;
		}
		public override void InitObjectives()
		{
			deliveryObjectives.Add( 15998, 1 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
		public override void OnAcceptQuest( Character c )
		{
			c.PutObjectInBackpack( new LewisNote(), true );
		}
	}
}