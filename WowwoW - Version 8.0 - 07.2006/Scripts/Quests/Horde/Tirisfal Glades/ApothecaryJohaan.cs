using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
	public class A_New_Plague_1 : BaseQuest
	{
		public A_New_Plague_1 () : base()
		{
			id = 367;
			npcId = 1518;
			name = "A New Plague";
			desc = "Apothecary Johaan in the town of Brill wants you to collect 5 Vials of Darkhound Blood.";
			details = "Lady Sylvanas has called upon the Royal Apothecary Society. The Dark Lady believes our knowledge coupled with the newfound magic will provide the key to Arthas's demise. She has challenged us to concoct a new plague, a plague deadlier than any ailment on Azeroth. This new disease will bring Arthas's Scourge Army to ruin.\n\nMy studies show that the blood of beasts might prove to be the key. Bring to me 5 vials of darkhound blood so I can test my theory.";
			questFlags = 0x020;
			idealLevel = 6;
			minLevel = 6;
			zone = 14;
			rewardXp = 550;
			rewardGold = 125;
			finishDialog = "You have done well, and I thank you for your efforts";
			progressDialog = "Have you collected 5 vials of darkhound blood yet, $N? Time is fleeting!\n\n Required items: 5 Darkhound Blood";
		}
		public override void InitObjectives()
		{
			reward.Add( 3382, 3 );
			deliveryObjectives.Add( 2858, 5 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
	}
	public class A_New_Plague_2 : BaseQuest
	{
		public A_New_Plague_2 () : base()
		{
			id = 368;
			npcId = 1518;
			name = "A New Plague";
			desc = "Apothecary Johaan of the town of Brill needs 5 Vile Fin Scales from Murlocs in Tirisfal Glades.";
			details = "While you were collecting samples for me, my experiments led me to realize that more reagents will be required for this new disease to spread properly. Poisoning some hapless victim is child's play. Plaguing an entire world proves to be a bit more complicated.\n\nI will need 5 Vile Fin Scales from Murlocs in the vicinity. You will find the creatures along the coast to the north or to the west.";
			questFlags = 0x020;
			idealLevel = 9;
			minLevel = 7;
			zone = 14;
			rewardXp = 775;
			previousQuest = 367;
			rewardGold = 300;
			finishDialog = "The scales are perfect. Exactly what I needed for this concoction.";
			progressDialog = "Were you able to obtain 5 Vile Fin Scales from the Murlocks?\n\nRequired items: 5 Vile Fin Scales";
		}
		public override void InitObjectives()
		{
			reward.Add( 3434, 5 );
			deliveryObjectives.Add( 2859, 5 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
	}
	public class A_New_Plague_3 : BaseQuest
	{
		public A_New_Plague_3 () : base()
		{
			id = 369;
			npcId = 1518;
			name = "A New Plague";
			desc = "Apothecary Johaan in the town of Brill wants you to bring him 4 samples of venom from a Vicious Night Web Spider.";
			details = "While you were out gathering, I uncovered some old text in one of my tomes that indicates that an ancient plague wiped out thousands of innocent victims. Later it was discovered that the deadly agent in the plague was preserved through the venom of Night Web Spiders.\n\nBring me some venom from a Vicious Night Web Spider to complete this experiment. I want to see if the contagious element from the venom will work with my new concoction. Rumor has it the spiders can be found in Eastern Tirisfal Glades.";
			questFlags = 0x020;
			idealLevel = 11;
			minLevel = 9;
			zone = 14;
			rewardXp = 220;
			previousQuest = 368;
			finishDialog = "Ah, this venom will do perfectly, $N. Everything else has been added to my concoction and boiled down. Finally, I am ready to try this new deadly agent!";
			progressDialog = "Do you have some venom from a Vicious Night Web Spider yet, $N? It's the final component I need in order to test my experiment.";
		}
		public override void InitObjectives()
		{
			reward.Add( 3442, 1 );
			deliveryObjectives.Add( 2872, 4 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );	
		}
	}
	public class A_New_Plague_4 : BaseQuest
	{
		public A_New_Plague_4 () : base()
		{
			id = 492;
			npcId = 1518;
			name = "A New Plague";
			desc = "Bring Johaan's Special Drink to the Captured Mountaineer.";
			details = "According to the Deathguard, another one of those foolish Dwarven Mountaineers has just been captured. The Deathguard likes to use the cellar of the Gallows End Tavern as a holding cell until prisoners can be properly dealt with.\n\nWhy don't you go see how the Captured Mountaineer enjoys this special drink I made for him? It contains a subtle hint of what The Dark Lady has planned for the rest of Azeroth.";
			questFlags = 0x020;
			idealLevel = 11;
			minLevel = 9;
			zone = 14;
			rewardXp = 875;
			previousQuest = 369;
			finishDialog = "Ah, a drink at last. I'm sure it's no Rhapsody Malt but I'll take anything to whet the old whistle at this point.";
			progressDialog = "Why if I had my trusted rifle you'd be as good as dead, $C. Just wait until the Steam Tank Brigade arrives to rescue me!";
		}
		public override void InitObjectives()
		{
			deliveryObjectives.Add( 3460, 1 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
	}
	public class Delivery_to_Silverpine_Forest : BaseQuest
	{
		public Delivery_to_Silverpine_Forest () : base()
		{
			id = 445;
			npcId = 1518;
			name = "Delivery to Silverpine Forest";
			desc = "Take Apothecary Johaan's findings to Apothecary Renferrel in Silverpine Forest.";
			details = "Time is a luxury that is not afforded to those of us under the employ of Lady Sylvanas. Surely you know this by now.\n\nAs a member of the Royal Apothecary Society it is my duty to share my knowledge with my colleagues so that our collective efforts might one day provide The Dark Lady with the New Plague she so badly desires.\n\nTake these findings to Apothecary Renferrel who is stationed at The Sepulcher in Silverpine Forest. Follow the roads to the south from Brill. From the Undercity go southwest.";
			questFlags = 0x020;
			idealLevel = 10;
			minLevel = 9;
			zone = 14;
			rewardXp = 625;
			rewardGold = 250;
			finishDialog = "Ah, how good of Apothecary Johaan to send his research. With so many new developments here in Silverpine, I nearly forgot about the findings coming out of Lordaeron and Tirisfal Glades. Which reminds me, I need to get those samples off to the Necropolis soon.\n\nBut you must excuse my rambling. Extend your stay in Silverpine, $N. We could use an able bodied warlock like you around here.";
			progressDialog = "What business do you have with me $C?";
		}
		public override void InitObjectives()
		{
			deliveryObjectives.Add( 3238, 1 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
	}
	public class Fields_of_Grief_2 : BaseQuest
	{
		public Fields_of_Grief_2 () : base()
		{
			id = 407;
			npcId = 1518;
			name = "Fields of Grief";
			desc = "Take the Laced Pumpkin to the Captured Scarlet Zealot who is being held in the cellar of the Gallow's End Tavern.";
			details = "Harmless pumpkins, right? Or so it would seem. If we are to defeat Arthas's advances from the North and the Human infestation from the South we need to start realizing the full potential of our gift of undeath.\n\nWith a little ingenuity a simple pumpkin becomes an agent for our Dark Lady. This pumpkin, laced with my latest formula, will prove to be quite a treat.\n\nYet another Scarlet Zealot has been captured and is being kept in the cellar of the Gallow's End Tavern. Take this pumpkin to the fool.";
			questFlags = 0x020;
			idealLevel = 7;
			minLevel = 4;
			zone = 14;
			rewardXp = 300;
			previousQuest = 365;
			//npcDeliveryId = 1931;
			finishDialog ="By the Light! Finally some food! Sweet, sweet pumpkin...";
			progressDialog = "Stay away foul and unholy creature! May the Light protect me! The Scarlet Crusade shall rid Azeroth of your...\n\n...oh wait. Is that food for me? I am so hungry...";
			questIsBugged = true;
		}
		public override void InitObjectives()
		{
			deliveryObjectives.Add( 3035, 1 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
		public override void OnAcceptQuest( Character c )
		{
			c.PutObjectInBackpack( new LacedPumpkin(), true );
		}
	}	
}