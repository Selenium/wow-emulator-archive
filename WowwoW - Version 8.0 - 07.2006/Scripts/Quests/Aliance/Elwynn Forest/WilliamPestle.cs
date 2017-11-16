using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
	public class Kobold_Candles  : BaseQuest
	{
		public Kobold_Candles() : base()
		{
			id = 60;
			npcId = 253;
			name = "Kobold_Candles";
			desc = "Bring 8 Large Candles to William Pestle in Goldshire.";
			details = "Hello, $N! Do you have a moment?\n\n My brother and I run an apothecary in Stormwind, and I'm here to gather large candles for their wax. Can you help me?\n\nYou can get large candles from kobolds, and I hear rumors that kobolds are infesting the Elwynn mines ... the Fargodeep mine to the south and Jasperlode Mine to the east. I suggest looking for candles in one of those places.";
			questFlags = 0x020;
			idealLevel = 7;
			minLevel = 3;
			zone = 9;
			rewardXp = 525;
			rewardGold = 50;
			finishDialog = "You were busy hunting kobolds, were you? Thanks for the candles, $N, and here's your reward...";
			progressDialog = "Did you gather those candles yet?";
		}
		public override void InitObjectives()
		{
			reward.Add( 1434, 5 );
			deliveryObjectives.Add( 772, 8 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
	}
	public class Shipment_to_Stormwind  : BaseQuest
	{
		public Shipment_to_Stormwind () : base()
		{
			id = 61;
			npcId = 253;
			name = "Shipment to Stormwind ";
			desc = "Bring William's Shipment to Morgan Pestle in the Stormwind Trade District.";
			details = "My brother Morgan is waiting in Stormwind for my shipment of candles. I don't have enough time to make the trip myself, but if you'd like to take him the shipment, he'll pay you well.\n\n I've packed up the candles, and you can find Morgan in our shop, Pestle's Apothecary, in the Stormwind Trade District.";
			questFlags = 0x020;
			idealLevel = 7;
			minLevel = 3;
			zone = 9;
			rewardXp = 850;
			previousQuest = 60;
			rewardGold = 350;
			//npcTargetId = 279; 
			finishDialog = "Oh, a shipment from my brother? Splendid! Fortune truly shines on me today!\n\nHere is your payment ... and while you're here, take a look around! I'm sure we have a potion or other trinket you'd find useful.";
			questIsBugged = true;
		}
		public override void InitObjectives()
		{
			rewardChoice.Add( 1178, 15 );
			rewardChoice.Add( 2454, 2 );
			rewardChoice.Add( 1177, 5 );
			deliveryObjectives.Add( 957, 1 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
		public override void OnAcceptQuest( Character c )
		{
			c.PutObjectInBackpack( new WilliamsShipment(), true );
		}
	}
	public class Collecting_Kelp  : BaseQuest
	{
		public Collecting_Kelp() : base()
		{
			id = 112;
			npcId = 253;
			name = "Collecting Kelp ";
			desc = "Bring 4 Crystal Kelp Fronds to William Pestle in Goldshire.";
			details = "I can make an invisibility liquor for Maybell, so she can slip away from the Maclure Vineyards and go to Tommy Joe. But to make the Liquor, I need some crystal kelp.\n\nAlthough the kelp usually grows in the ocean... sometimes murlocs collect it. See if the murlocs near Crystal Lake have any. Crystal Lake is just east of Goldshire.";
			questFlags = 0x020;
			idealLevel = 7;
			minLevel = 6;
			zone = 9;
			rewardXp = 500;
			previousQuest = 107;
			finishDialog = "You got them. Good show! Now, just one moment while I concoct the potion...";
			progressDialog = "Do you have that crystal kelp? I'm sure Maybell is anxious to see her beau...";
		}
		public override void InitObjectives()
		{
			deliveryObjectives.Add( 1256, 4 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
	}
	public class The_Escape  : BaseQuest
	{
		public The_Escape() : base()
		{
			id = 114;
			npcId = 253;
			name = "The Escape ";
			desc = "Take the Invisibility Liquor to Maybell Maclure.";
			details = "Take this invisibility liquor to young Maybell. It should last long enough for her to visit Tommy Joe.";
			questFlags = 0x020;
			idealLevel = 7;
			minLevel = 6;
			zone = 9;
			rewardXp = 800;
			npcTargetId =251; 
			finishDialog = " Oh...my! I feel guilty deceiving my family, but my feelings for Tommy Joe are too strong to ignore. \n\nThank you, $N. I'll drink this liquor as soon as I have the chance and sneak away to my love. \n\nAnd for you... please take this.";
		}
		public override void InitObjectives()
		{
			reward.Add( 118, 5 );
			reward.Add( 2996, 5 );
			deliveryObjectives.Add( 1257, 1 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
		public override void OnAcceptQuest( Character c )
		{
			c.PutObjectInBackpack( new InvisibilityLiquor(), true );
		}
	}
}