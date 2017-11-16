using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
	public class Millys_Harvest  : BaseQuest
	{
		public Millys_Harvest() : base()
		{
			id = 3904;
			npcId = 9296;
			name = "Milly's Harvest";
			desc = "Bring 8 crates of Milly's Harvest to Milly Osworth at Northshire Abbey.";
			details = "A gang of brigands, the Defias, moved into the Northshire Vineyards while I was harvesting! I reported it to the Northshire guards and they assured me they'd take care of things, but... I'm afraid for my crop of grapes! If the Defias don't steal them then I fear our guards will trample them when they chase away the thugs.\n\nPlease, you must help me! I gathered most of my grapes into buckets, but I left them in the vineyards to the southeast.\n\nBring me those crates! Save my harvest!";
			questFlags = 0x020;
			idealLevel = 4;
			minLevel = 2;
			zone = 9;
			previousQuest = 3903;
			finishDialog = "Oh thank you, $N! You saved my harvest! And I hope you showed a few of those Defias that they can't cause trouble around here. \n\nWe might be short on guards these days, but we're lucky to have heroes like you to protect us!";
			progressDialog =  "Do you have my harvest, $N?";
		}
		public override void InitObjectives()
		{
			deliveryObjectives.Add( 11119, 8 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
	}
	public class Grape_Manifest  : BaseQuest
	{
		public Grape_Manifest() : base()
		{
			id = 3905;
			npcId = 9296;
			name = "Grape Manifest";
			desc = "Bring the Grape Manifest to Brother Neals in Northshire Abbey.";
			details = "Now that my crop is saved, take this Grape Manifest to Brother Neals. He manages the store of food and drink in Northshire, and I'm sure he'll be delighted to hear that he has fresh grapes.\n\nYou'll find Brother Neals in the abbey, in the bell tower... where he likes to taste his wine.";
			questFlags = 0x020;
			idealLevel = 4;
			minLevel = 2;
			zone = 9;
			//npcTargetId = 952;
			previousQuest = 3904;
			finishDialog = "Let's see here... \n\nOh my! Milly's grapes have been saved! When she told me that brigands overran her vineyards I nearly despaired, but my faith in the Light did not waver! \n\nAnd through your bravery, we now have grapes for more wine! May the Light bless you, $N, and keep you safe!";
			progressDialog= "You look to be in fine spirits! Come! Have a seat, and have a drink!";
			questIsBugged = true;
		}
		public override void InitObjectives()
		{
			deliveryObjectives.Add( 11125, 1 );
			rewardChoice.Add( 11475, 1 );
			rewardChoice.Add( 2690, 1 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
		public override void OnAcceptQuest( Character c )
		{
			c.PutObjectInBackpack( new GrapeManifest(), true );
		}
	}
}
	//==========