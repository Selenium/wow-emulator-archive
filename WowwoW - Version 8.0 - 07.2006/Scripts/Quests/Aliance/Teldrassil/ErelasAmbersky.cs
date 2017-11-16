using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
	public class Favored_of_Elune : BaseQuest
	{
		public Favored_of_Elune() : base()
		{
			id = 3661;
			npcId = 7916;
			name = "Favored of Elune?";
			desc = "Collect 15 Wildkin Feathers from the Hinterlands for Erelas Ambersky in Rut'theran Village.";
			details = "Wildkin are quite unpredictable creatures, $N. Capable of incredible gentleness, these creatures will show extreme ferocity if something they deem important is threatened. These beasts are rumored to have been created by Elune, and I am interested in finding if this is really the truth. Recently, I heard about a population of wildkin living in the Hinterlands -- Vicious, Primitive, and Savage Owlbeasts. They can be found amongst the wildlife there. Will you gather some wildkin feathers for me?";
			questFlags = 0x020;
			idealLevel = 47;
			minLevel = 44;
			zone = 618;
			rewardXp = 2262;
			rewardGold = 1350;
			finishDialog = "You performed your duties well.";
			progressDialog= "Hey $N, can you done it ?";
			raceAllowed=qRaces.Alliance;
		}
		public override void InitObjectives()
		{
			deliveryObjectives.Add( 10819, 15 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );
		}
	}
 	public class Moontouched_Wildkin : BaseQuest
	{
		public Moontouched_Wildkin() : base()
		{
			id = 978;
			npcId = 7916;
			name = "Moontouched Wildkin";
			desc = "Collect 10 Moontouched Feathers from Winterspring, then return to Erelas Ambersky in Rut'theran Village.";
			details = "Wildkin feathers from the Hinterlands appear to contain traces of magical qualities. These powers... they don't seem to be wielded by the creatures, it's more like they are simply inherent to the species -- part of their very essence. During my studies, I heard that a large population of wildkin inhabit the snowy lands of Winterspring. Could these creatures have the same powers? Please help me find an answer, <Name>. Go to Winterspring and gather feathers, then return to me.";
			questFlags = 0x020;
			idealLevel = 55;
			minLevel = 50;
			zone = 618;
			rewardGold = 8500;
			rewardXp = 5650;
			finishDialog = "Good job!";
			progressDialog = "Hey $N, can you done it ?";
			previousQuest = 3661;
			raceAllowed=qRaces.Alliance;
		}
		public override void InitObjectives()
		{
			deliveryObjectives.Add( 12383, 10 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );
		}
	}
	public class Find_Ranshalla : BaseQuest
	{
		public Find_Ranshalla() : base()
		{
			id = 979;
			npcId = 7916;
			name = "Find Ranshalla";
			desc = "Find Ranshalla in eastern Winterspring.";
			details = "Yes, yes, these feathers seem to hold the same magical enchantment that I noticed previously... While I am not certain what we might find, I urge you to continue searching for answers, $N. A colleague of mine recently traveled into Winterspring to observe the wildkin there, in their own habitat. Why don't you catch up with her and see what she has found?";
			questFlags = 0x020;
			idealLevel = 57;
			minLevel = 52;
			zone = 618;
			rewardXp = 3000;
			finishDialog = "Welcome $N!";
			progressDialog = "Hey $N, can you done it ?";
			npcTargetId = 10300;
			previousQuest = 978;
			raceAllowed=qRaces.Alliance;
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );
		}
	}
	public class Wildkin_of_Elune : BaseQuest
	{
		public Wildkin_of_Elune() : base()
		{
			id = 4902;
			npcId = 7916;
			name = "Wildkin of Elune";
			desc = "Speak with Arch Druid Fandral Staghelm in Darnassus.";
			details = "That's fascinating! I have always wondered about the truth... Well, you must share this knowledge, definitely! Go to Arch Druid Fandral Staghelm right away -- you'll find him in Darnassus, in the Cenarion Circle. Explain to him what happened, just the same as you told me. I'm sure he will be just as interested! This is important information, $N!";
			questFlags = 0x020;
			idealLevel = 57;
			minLevel = 54;
			zone = 618;
			rewardXp = 6000;
			finishDialog = "Welcome in Darnassus $N!";
			progressDialog = "Hey $N, can'T find him ???";
			npcTargetId = 3516;
			previousQuest = 4901;
			raceAllowed=qRaces.Alliance;
		}
		public override void InitObjectives()
		{
			rewardChoice.Add( 16622, 1 );
			rewardChoice.Add( 16623, 1 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );
		}
	}
}
