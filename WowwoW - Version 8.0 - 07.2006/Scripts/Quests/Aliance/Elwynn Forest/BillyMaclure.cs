using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
	public class Pie_For_Billy  : BaseQuest
	{
		public Pie_For_Billy() : base()
		{
			id = 86;
			npcId = 247;
			name = "Pie_For_Billy";
			desc = "Bring 4 Chunks of Boar Meat to Auntie Bernice Stonefield at the Stonefield's Farm.";
			details = "Maybe if I got a pie, I could tell you who has that necklace. And you know, I think that old Bernice lady at that other farm makes great Pork Belly Pies... \n\n Maybe if you gave her some chunks of boar meat from the boars that hang around our farms, and told her what it was for, she'd bake up a pie for you.";
			questFlags = 0x020;
			idealLevel = 6;
			minLevel = 6;
			zone = 9;
			previousQuest = 85;
			npcTargetId = 246; 
			finishDialog= "I don't think it's right feeding the boy who stole my necklace in the first place, but if that's what it takes to get back what's mine, then so be it! \n\nThough this wild boar meat is tough, simmer it enough and it sure does make for some tasty pie!";
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
	}
	public class Goldtooth : BaseQuest
	{
		public Goldtooth() : base()
		{
			id = 87;
			npcId = 247;
			name = "Goldtooth";
			desc = "Bring Bernice's Necklace to 'Auntie' Bernice Stonefield at the Stonefield Farm.";
			details = "I was playing near the Fargodeep Mine, and I think I dropped, er...I mean I saw, the old lady's necklace. Don't ask me how it got there...it wasn't me!\n\nWell anyway, I saw this big, gold-toothed kobold pick up the necklace and run into the mine. Go find that kobold and you'll find the necklace, I swear!";
			questFlags = 0x020;
			idealLevel = 8;
			minLevel = 6;
			zone = 9;
			rewardXp = 500;
			previousQuest = 84;
			npcTargetId = 246;
			finishDialog= "Oh, you found it! Thank you, thank you dear! \n\nHere, take this. It was my husband's and he always said it was lucky. If only he didn't forget it on his last campaign! *sniff*";
		}
		public override void InitObjectives()
		{
			reward.Add( 1359, 1 );
			deliveryObjectives.Add( 981, 1 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
	}

}