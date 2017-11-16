using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
	public class The_Sleeping_Druid : BaseQuest
	{
		public The_Sleeping_Druid() : base()
		{
			id = 2541;
			npcId = 7317;
			name = "The Sleeping Druid";
			desc = "Bring a Shaman Voodoo Charm to Oben Rageclaw in the Ban'ethil Barrow Den.";
			details = "The Gnarlpine shaman that inhabit this place have discovered a way of separating a sleeping druid's spirit from the physical body. The furbolg have animated my physical form and are using it to attack anyone that attempts to explore the Ban'ethil Barrow Den. I am now trapped in the Emerald Dream, powerless to stop this.$B$BYou must help me. The Gnarlpine shaman carry a strange charm which is used to perform this ritual, and I'd like to examine it. Please, $N, bring one to me.";
			questFlags = 0x020;
			idealLevel = 8;
			minLevel = 3;
			zone = 141;
			rewardXp = 428;
			finishDialog = "Thank you, $N.$b$bWhat an odd trinket this is... I can sense the vile aura emanating from it; this is a very powerful enchantment.";
			progressDialog = "If I can examine the charm, I may be able to figure out how to break the enchantment. Have you found one?";
			raceAllowed=qRaces.Alliance;
		}
		public override void InitObjectives()
		{
			deliveryObjectives.Add( 8363, 1 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c ) 
		{
			return BaseNPC.QDS( questOwner, c, this ); 
		}
	}
	public class Druid_of_the_Claw : BaseQuest
	{
		public Druid_of_the_Claw() : base()
		{
			id = 2561;
			npcId = 7317;
			name = "Druid of the Claw";
			desc = "Oben Rageclaw wants you to kill his soulless body, and then use the Voodoo Charm.";
			details = "After examining this charm, $N, I see now what must be done. Please take it, and do as I ask.$B$BYou are to explore the deepest areas of the Ban'ethil Barrow Den. There, you will find my soulless body... Although I regret what I am about to tell you, I see no other way to free myself from the control of the Gnarlpine.$B$BIn order for me to escape them, you must kill my physical form.  Once that is done, use the voodoo charm on my fallen body. After you have completed this task, please return to me.";
			questFlags = 0x020;
			idealLevel = 10;
			minLevel = 1;
			zone = 141;
			rewardXp = 451;
			previousQuest = 2541;
			finishDialog = "I am finally free of the control of the Gnarlpine. Thank you, $N.$b$bMy spirit may now rest peacefully forever in the Emerald Dream.$b$bPerhaps one day we may meet again, young $C. But, for now, please accept this reward as a symbol of my gratitude.";
			raceAllowed=qRaces.Alliance;
			npcTargetId = 5189;
		}
		public override void InitObjectives()
		{
			rewardChoice.Add( 9598, 1 );
			rewardChoice.Add( 18957, 1 );
			rewardChoice.Add( 8149, 2 );
		}
		public override void OnAcceptQuest(Character c)
		{
			c.PutObjectInBackpack( World.CreateItemInPoolById(8149), 1, true);
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c ) 
		{
			return BaseNPC.QDS( questOwner, c, this ); 
		}
	}
}
