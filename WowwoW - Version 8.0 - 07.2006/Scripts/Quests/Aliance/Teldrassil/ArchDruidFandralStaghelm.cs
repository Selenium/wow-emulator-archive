using Server.Items;
using Server.Creatures;

namespace Server.Quests	
{
	public class Grove_of_the_Ancients : BaseQuest
	{
		public Grove_of_the_Ancients() : base()
		{
			id = 952;
			npcId = 3516;
			name = "Grove of the Ancients";
			desc = "Deliver Fandral's message to Onu in the Grove of the Ancients in Darkshore, south of Auberdine.";
			details = "If you had enough time to run messages for the Oracle Tree, then I'm sure that I can press you into service to deliver a message to the Grove of the Ancients in Darkshore, due south of Auberdine.$B$BYou will most likely have to secure transport on a hippogryph, but I have faith enough in you that you can manage that. Take this to Onu, the Ancient of Lore. He has been awaiting word from me, even as I waited for news from the Oracle Glade.";
			questFlags = 0x020;
			idealLevel = 11;
			minLevel = 1;
			zone = 1657;
			rewardXp = 622;
			previousQuest = 940;
			finishDialog = "Ah. Thank you, $N. It is strange, though. The Arch $C always seems in such a hurry. The forest knows that all shall come to pass in the appointed time. Shan'do Stormrage understood that.";
			progressDialog = "Ah. $C. How may Onu assist you?";
			npcTargetId = 3616;
		}
		public override void InitObjectives()
		{
			deliveryObjectives.Add( 5390, 1 );
		}
		public override void OnAcceptQuest(Character c)
		{
			c.PutObjectInBackpack( World.CreateItemInPoolById( 5390 ), true );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c ) 
		{
			return BaseNPC.QDS( questOwner, c, this ); 
		}
	}
	public class Morrowgrain_Research : BaseQuest
	{
		public Morrowgrain_Research() : base()
		{
			id = 3781;
			npcId = 3516;
			name = "Morrowgrain Research";
			desc = "Take the Arch Druid's Seed Voucher to Mathrengyl Bearwalker in the Cenarion Enclave of Darnassus.";
			details = "With what we call an Evergreen Pouch, we have cultivated Tharlendris seeds in the soil from Un'Goro Crater. These seeds blossom into an array of random, potent herbs. One result is morrowgrain, a mysterious herb we know little about; I intend to unravel this mystery.$B$B Take this to Mathrengyl downstairs, and he will give you some seeds so you can get started. If you run out, you will need to purchase more from him.";
			questFlags = 0x020;
			idealLevel = 50;
			minLevel = 45;
			zone = 1657;
			rewardXp = 2402;
			previousQuest = 3764;
			raceAllowed = qRaces.Alliance;
			npcTargetId = 4217;
		}
		public override void InitObjectives()
		{
			reward.Add( 11022, 20 );
			deliveryObjectives.Add( 11103, 1 );
		}
		public override void OnAcceptQuest(Character c)
		{
			c.PutObjectInBackpack( World.CreateItemInPoolById( 11103 ), true );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c ) 
		{
			return BaseNPC.QDS( questOwner, c, this ); 
		}
	}
	public class Rabine_Saturna : BaseQuest
	{
		public Rabine_Saturna() : base()
		{
			id = 6762;
			npcId = 3516;
			name = "Rabine Saturna";
			desc = "Speak with Rabine Saturna in the village of Nighthaven, Moonglade.  Moonglade lies between Felwood and Winterspring, accessible through a path out of Timbermaw Hold.";
			details = "For this task, the majordomo for Keeper Remulos in Moonglade - Rabine Saturna - seeks aid in exploring the vast wastelands far to the west of Tanaris... and even further west of Un'Goro.  You should find him in Nighthaven, the main village of Moonglade.$B$BWhile your work will of no doubt be tremendous benefit to us all, I advise you to tread gingerly.  There are tensions between Darnassus and Moonglade... ones that may grow over the course of time.";
			questFlags = 0x020;
			idealLevel = 55;
			minLevel = 50;
			zone = 1657;
			rewardXp = 2514;
			previousQuest = 1047;
			raceAllowed = qRaces.Alliance;
			npcTargetId = 11801;
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c ) 
		{
			return BaseNPC.QDS( questOwner, c, this );
		}
	}
	public class The_New_Frontier2 : BaseQuest
	{
		public The_New_Frontier2() : base()
		{
			id = 6761;
			npcId = 3516;
			name = "The New Frontier";
			desc = "Speak with Mathrengyl Bearwalker at the Cenarion Enclave of Darnassus.";
			details = "I have relegated my second, Mathrengyl Bearwalker, to deal with Moonglade's call for aid. Speak to him on this matter - NOT me.$B$BLet me give you some... friendly... advice. It is I who led us out of the darkness - NOT the Cenarion Circle in Moonglade - when all was lost for our race. Teldrassil gives us all new life! They would have you believe otherwise, and to believe their propaganda would be a fool's task.$B$BI'll leave it to you to decide whether or not you're a fool.";
			questFlags = 0x020;
			idealLevel = 55;
			minLevel = 50;
			zone = 1657;
			rewardXp = 2110;
			classAllowed = qClasses.Priest;
			raceAllowed = qRaces.Alliance;
			npcTargetId = 4217;
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c ) 
		{
			return BaseNPC.QDS( questOwner, c, this );
		}
	}
	public class Un_Goro_Soil : BaseQuest
	{
		public Un_Goro_Soil() : base()
		{
			id = 3764;
			npcId = 3516;
			name = "Un'Goro Soil";
			desc = "Bring 20 Un'Goro Soil samples to Jenal in Darnassus.";
			details = "The soil of Un'Goro Crater is reportedly enriched with potent magical qualities. I want to know facts from falsehoods; go into the wilds of Un'Goro and acquire enough quality samples of soil for our continued study.$B$B You may think that collection tasks are beneath you; that sort of attitude does not endear yourself to me or the Cenarion Circle. Bring the samples to Jenal, who is no doubt wasting time outside behind this tree; just look for the piles of dirt. He will handle the logistics - not I.";
			questFlags = 0x020;
			idealLevel = 50;
			minLevel = 45;
			zone = 1657;
			rewardXp = 2402;
			rewardGold = 14500;
			previousQuest = 3790;
			raceAllowed = qRaces.Alliance;
			npcTargetId = 9047;
			questIsBugged = true;
		}
		public override void InitObjectives()
		{
			deliveryObjectives.Add( 11018, 20 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c ) 
		{
			return BaseNPC.QDS( questOwner, c, this ); 
		}
	}
}
