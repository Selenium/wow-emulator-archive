using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
	public class The_Balance_of_Nature_1 : BaseQuest
	{
		public The_Balance_of_Nature_1() : base()
		{	
			id = 456;
			npcId = 2079;
			name = "The Balance of Nature";
			desc = "Kill 7 Young Nightsabers and 4 Young Thistle Boars and return to Conservator Ilthalaine.";
			details = "Greetings, $N. I am Conservator Ilthalaine. My purpose in Shadowglen is to ensure that the balance of nature is maintained. The spring rains were particularly heavy this year, causing some of the forest's beasts to flourish while others suffered. Unfortunately, the nightsaber and thistle boar populations grew too large. Shadowglen can only produce so much food for the beasts. Journey forth, young $C, and thin the boar and saber populations so that nature s harmony will be preserved.";
			questFlags = 0x020;
			idealLevel = 2;
			minLevel = 1;
			zone = 141;
			rewardXp = 104;
			rewardGold = 35;
			finishDialog = "You performed your duties well.";
			progressDialog= "Hey $N. be quick and save the balance of nature...";
		}
		public override void InitObjectives()
		{
			npcObjectives.Add( 1984, 4 );
			npcObjectives.Add( 2031, 7 );
			rewardChoice.Add( 5394, 1 );
			rewardChoice.Add( 11187, 1 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
	}
	public class The_Balance_of_Nature_2 : BaseQuest
	{
		public The_Balance_of_Nature_2() : base()
		{	
			id = 457;
			npcId = 2079;
			name = "The Balance of Nature";
			desc = "Conservator Ilthalaine needs you to kill 7 Mangy Nightsabers and 7 Thistle Boars.";
			details = "Thinning the younger population of creatures here in Shadowglen was a good start, $N, but there is still work to be done. The resources of the forest will be depleted too quickly if the problem is not addressed. Killing nature s beasts is a necessary evil for the good of all who share the land. Venture into the forest and slay mangy nightsabers and thistle boars in the name of balance.";
			questFlags = 0x020;
			idealLevel = 3;
			minLevel = 1;
			zone = 141;
			rewardXp = 162;
			rewardGold = 50;
			previousQuest = 456;
			raceAllowed=qRaces.Alliance;
			finishDialog = "You have proven your dedication to nature well. A young one like yourself has a promising future.";
		}
		public override void InitObjectives()
		{
			npcObjectives.Add( 2032, 7 );
			npcObjectives.Add( 1985, 7 );
			rewardChoice.Add( 5405, 1 );
			rewardChoice.Add( 6058, 1 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
	}
	public class Hallowed_Sigil : BaseQuest
	{
		public Hallowed_Sigil() : base()
		{
			id = 3119;
			npcId = 2079;
			name = "Hallowed Sigil";
			desc = "Read the Hallowed Sigil and speak to Shanda in Aldrassil.";
			details = "This sigil was given to me by a messenger from our priest trainer, Shanda. It seems Shanda would have words with you when you have a moment. Read it and bring it to her afterwards.";
			questFlags = 0x020;
			idealLevel = 1;
			minLevel = 1;
			zone = 141;
			rewardXp = 40;
			npcTargetId = 3595;
			classAllowed=qClasses.Priest;
			raceAllowed=qRaces.Alliance;
			finishDialog = "You performed your duties well.";
			progressDialog= "Hey $N. be quick...";
		}
		public override void InitObjectives()
		{
        	deliveryObjectives.Add( 9557, 1 );
		}
		public override void OnAcceptQuest( Character c )
		{
			c.PutObjectInBackpack( World.CreateItemInPoolById( 9557 ), true );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );
		}
	}
	public class Etched_Sigil : BaseQuest
	{
		public Etched_Sigil() : base()
		{
			id = 3117;
			npcId = 2079;
			name = "Etched Sigil";
			desc = "Read the Etched Sigil and speak to Ayanna Everstride at the top of Aldrassil in Shadowglen.";
			details = "This sigil was given to me by a messenger from our hunter trainer, Ayanna. It seems Ayanna would have words with you when you have a moment. Read it and bring it to her afterwards.";
			questFlags = 0x020;
			idealLevel = 1;
			minLevel = 1;
			zone = 141;
			rewardXp = 40;
			npcTargetId = 3596;
			finishDialog = "Good job $N!.";
			progressDialog= "Go to Ayanna Everstride and good luck...";
			classAllowed=qClasses.Hunter;
			raceAllowed=qRaces.Alliance;
		}
		public override void InitObjectives()
		{
        	deliveryObjectives.Add( 9567, 1 );
		}
		public override void OnAcceptQuest( Character c )
		{
			c.PutObjectInBackpack( World.CreateItemInPoolById( 9567 ), true );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );
		}
	}
	public class Verdant_Sigil : BaseQuest
	{
		public Verdant_Sigil() : base()
		{
			id = 3120;
			npcId = 2079;
			name = "Verdant Sigil";
			desc = "Read the Verdant Sigil and speak to Mardant Strongoak, in the tree Aldrassil in Shadowglen.";
			details = "This sigil was given to me by a messenger from our druid trainer, Mardant. It seems Mardant would have words with you when you have a moment. Read it and bring it to him afterwards.";
			questFlags = 0x020;
			idealLevel = 1;
			minLevel = 1;
			zone = 141;
			rewardGold = 35;
			rewardXp = 40;
			finishDialog = "You performed your duties well.";
   			progressDialog = "Do you have something for me ?";
			npcTargetId = 3597;
			classAllowed=qClasses.Druid;
			raceAllowed=qRaces.Alliance;
			questIsBugged = true;
		}
		public override void InitObjectives()
		{
			deliveryObjectives.Add( 9580, 1 );
			rewardChoice.Add( 5394, 1 );
			rewardChoice.Add( 11187, 1 );
		}
        public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );
		}
        public override void OnAcceptQuest( Character c )
		{
			c.PutObjectInBackpack( World.CreateItemInPoolById( 9580 ), true );
		}
	}
	public class Encrypted_Sigil : BaseQuest
	{
		public Encrypted_Sigil() : base()
		{
			id = 3118;
			npcId = 2079;
			name = "Encrypted Sigil";
			desc = "Read the Encrypted Sigil and speak to Frahun Shadewhisper in Shadowglen.";
			details = "This sigil was given to me by a messenger from our rogue trainer, Frahun. It seems Frahun would have words with you when you have a moment. Read it and bring it to him afterwards.";
			questFlags = 0x020;
			idealLevel = 1;
			minLevel = 1;
			zone = 141;
			rewardXp = 47;
			finishDialog = "Until then, know that our kind are needed more than ever in this tenuous time. Peace with the other races can fail at any moment, and there is much talk about members of the Horde looking to sow even greater seeds of distrust. Remember that.$b$bAs you gain in power and feel more prepared, come back to me here and I will see about getting you some training. It's important that you know how to handle your weapon of choice, among other things.";
			progressDialog = "Hello, Ferlis. I'm glad you found me. I was thinking that perhaps you got lost on the way here.$b$bNothing really new has happened in Shadowglen since I sent you my sigil, but I'll leave all the information gathering to you. Speak to the rest of the people around Aldrassil if you'd like.";
			classAllowed=qClasses.Rogue;
			raceAllowed=qRaces.Alliance;
			npcTargetId = 3594;
		}
		public override void InitObjectives()
		{
			deliveryObjectives.Add( 9551, 1 );
		}
		public override void OnAcceptQuest(Character c)
		{
			c.PutObjectInBackpack( World.CreateItemInPoolById(9551), true);
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c ) 
		{ 
			return BaseNPC.QDS( questOwner, c, this );
		}
	}
	public class Simple_Sigil : BaseQuest
	{
		public Simple_Sigil() : base()
		{
			id = 3116;
			npcId = 2079;
			name = "Simple Sigil";
			desc = "Read the Simple Sigil and speak to Alyissia in Shadowglen.";
			details = "This sigil was given to me by a messenger from our warrior trainer, Alyissia. It seems Alyissia would have words with you when you have a moment. Read it and bring it to her afterwards.";
			questFlags = 0x020;
			idealLevel = 1;
			minLevel = 1;
			zone = 141;
			rewardXp = 47;
			previousQuest = 457;
			finishDialog = "Soon you will see others from different races in the boughs of our home--do not let it cause any prejudice within you. They are welcome. They will aid us when they can. Not all of them will be altruistic, but they should be granted some amount of trust.$b$bBut none of this matters now. Now we must focus on you, and how you can aid our people. I am here for that very purpose. I will train you in the ways of a $C as you become stronger. Return to me whenever you wish and I will do what I can to aid you.";
			progressDialog = "You made it. I'm so glad.$b$bMuch has happened over the last few years, Saric: the creation of Teldrassil, the corruption of many of the forest creatures here and abroad, discovery of lands we thought lost to us like Feralas... so much, in so little time. But those are just some of the reasons we are here, the most important being to protect our kind from further evil.";
			classAllowed=qClasses.Warrior;
			raceAllowed=qRaces.Alliance;
			npcTargetId = 3593;
		}
		public override void InitObjectives()
		{
			deliveryObjectives.Add( 9545, 1 );
		}
		public override void OnAcceptQuest(Character c)
		{
			c.PutObjectInBackpack( World.CreateItemInPoolById(9545), 1, true);
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c ) 
		{ 
			return BaseNPC.QDS( questOwner, c, this );
		}
	}
	
}
