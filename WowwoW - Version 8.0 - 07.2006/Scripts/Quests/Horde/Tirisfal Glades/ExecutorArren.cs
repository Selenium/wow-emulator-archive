using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
	public class Night_Webs_Hollow : BaseQuest
	{
		public Night_Webs_Hollow() : base()
		{
			id = 380;
			npcId = 1570;
			name = "Night Web's Hollow";
			desc = "Executor Arren wants you to kill 10 Young Night Web Spiders and 8 Night Web Spiders.";
			details = "One of our greatest struggles is obtaining the natural resources we need to survive. Gold was scarce even in the height of the Alliance's power.\n\nThere is a gold mine to the northwest that has been overrun with spiders. We need gold from the mine, but we can't very well get it while the spiders are crawling around in there. I've not much manpower to commit to the task, so we'll just have to do it little by little.\n\nGet up there and see what you can do for us, N$.";
			questFlags = 0x020;
			idealLevel = 3;
			minLevel = 3;
			zone = 14;
			rewardXp = 360;
			finishDialog =  "Hmm, well, it's a start. It'll take a few weeks or months to fully clean out the infestation. After that, we'll have to get down there with some torches to burn away the webbing. \n\nYou've done your duty well. I'm sure I can find something else for you to do.";
		}
		public override void InitObjectives()
		{ 
			rewardChoice.Add( 3270, 1 );
			rewardChoice.Add( 3273, 1 );
			rewardChoice.Add( 3272, 1 );
			npcObjectives.Add( 1505, 8 );
			npcObjectives.Add( 1504, 10 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
	}
	public class The_Scarlet_Crusade : BaseQuest
	{
		public The_Scarlet_Crusade() : base()
		{
			id = 381;
			npcId = 1570;
			name = "The Scarlet Crusade";
			desc = "Bring Executor Arren 12 Scarlet Armbands from Scarlet Converts and Scarlet Initiates.";
			details = "You'll be happy to know we appear to be making progress in the mine, thanks in no small part to your efforts. We can now turn our eyes to other concerns.\n\nMy scouts have reported that a detachment of the Scarlet Crusade is setting up a camp southeast of here. The Scarlet Crusade is a despicable organization that hunts us, and they will not rest until every undead--Lich King's Scourge or no--is destroyed. We must strike first!\n\nBe careful, their unholy zeal makes them dangerous adversaries.";
			questFlags = 0x020;
			idealLevel = 4;
			minLevel = 3;
			zone = 14;
			rewardXp = 360;
			previousQuest = 380;
			finishDialog = "If only they listened to reason, eh? Perhaps we could sit them down for a reasonable discourse... ha!\n\nLight-blinded fools. ";
		}
		public override void InitObjectives()
		{ 
			reward.Add( 159, 1 );
			rewardChoice.Add( 3268, 1 );
			rewardChoice.Add( 3269, 1 );
			rewardChoice.Add( 3267, 1 );
			rewardChoice.Add( 5779, 1 );
			deliveryObjectives.Add( 3266, 12 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
	}
}
