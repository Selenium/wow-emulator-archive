using Server.Items;
using Server.Creatures;

namespace Server.Quests	
{
	public class Recipe_of_the_Kaldorei : BaseQuest
	{
		public Recipe_of_the_Kaldorei() : base()
		{
			id = 4161;
			name = "Recipe of the Kaldorei";
			desc = "Collect 7 Small Spider Legs for Zarrin in Dolanaar.";
			details = "Long ago, the night elves were called the Kaldorei, a name that means \"children of the stars.\" Learning of the past is an important step in your path as a $C, $N, so listen well to what I have to tell you.$B$BThe Kaldorei have always taken much pride in their harmonious relationship with nature. This means that we only take from nature what is necessary, and that we return in kind. This balance has afforded us much, $N.$B$BGo out and collect seven small spider legs -- no more than that, and return to me.";
			npcId = 6286;
			questFlags = 0x020;
			idealLevel = 7;
			minLevel = 1;
			zone = 141;
			rewardXp = 392;
			rewardGold = 85;
			finishDialog = "Always remember what I have shown you today, $N. You are part of the balance that the night elves strive to keep intact, even during troublesome times.";
			progressDialog = "Remember the balance, $N. I wish you to develop an understanding and a strong empathy for the living forests.";
			raceAllowed=qRaces.Alliance;
		}
		public override void InitObjectives()
		{
			reward.Add( 5482, 1 );
			reward.Add( 5472, 1 );
			deliveryObjectives.Add( 5465, 7 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{ 
			return BaseNPC.QDS( questOwner, c, this ); 
		}
	}
}
