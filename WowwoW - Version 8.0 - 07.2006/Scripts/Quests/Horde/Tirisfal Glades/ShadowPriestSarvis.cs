using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
	public class The_Mindless_Ones : BaseQuest
	{
		public The_Mindless_Ones() : base()
		{
			id = 364;
			npcId = 1569;
			name = "The Mindless Ones";
			desc = "Shadow Priest Sarvis wants you to kill 8 Mindless Zombies and 8 Wretched Zombies.";
			details = "We Forsaken are at war with the Lich King's army of the Scourge: necromantically raised armies of the undead, foul beasts of the north, and tormented spectres.\n\nThe northern part of the village has become overrun with the Mindless Ones, and they must be destroyed. Destroy them, show them no mercy, our former brothers and sisters as they might be. The Fallen are nothing but The Lich King's slaves.";
			questFlags = 0x020;
			idealLevel = 2;
			minLevel = 1;
			zone = 14;
			rewardXp = 170;
			previousQuest = 363;
			finishDialog = "It is unfortunate that the Scourge cannot be brought into the fold, their large numbers would be useful in the battles ahead. \n\nBut they will not join us, so we have no choice but to destroy them.";
		}
		public override void InitObjectives()
		{ 
			rewardChoice.Add( 11847, 1 );
			rewardChoice.Add( 3275, 1 );
			npcObjectives.Add( 1501, 8 );
			npcObjectives.Add( 1502, 8 ); 
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
	}
	public class Rattling_the_Rattlecages : BaseQuest
	{
		public Rattling_the_Rattlecages() : base()
		{
			id = 3901;
			npcId = 1569;
			name = "Rattling the Rattlecages";
			desc = "Kill 12 Rattlecage Skeletons, and then return to Shadow Priest Sarvis in Deathknell when you are done.";
			details = "You've shown your potential to the Forsaken under normal circumstances $N - now let's see you under pressure.\n\nThe Rattlecage skeletons, more mindless minions of the Lich King, are a tougher foe than the zombies you have faced thus far. Again, thin their numbers and prove yourself to the Forsaken. /nDo not tarry /nWhen you are done, speak to me again.";
			questFlags = 0x020;
			idealLevel = 3;
			minLevel = 2;
			zone = 14;
			rewardXp = 250;
			previousQuest = 364;
			finishDialog = "I am finished with you, $N - you have shown yourself to be worthy of the freedom that you have been given. Many will stand against you for what you have become, but know that no matter what they may try to do against us, we are free and will not be shackled again. \n\nTake these and be on your way. You have much to accomplish, C$. ";
		}
		public override void InitObjectives()
		{ 
			rewardChoice.Add( 3274, 1 );
			rewardChoice.Add( 11851, 1 );
			rewardChoice.Add( 11852, 1 );
			npcObjectives.Add( 1890, 12 ); 
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
	}
}
