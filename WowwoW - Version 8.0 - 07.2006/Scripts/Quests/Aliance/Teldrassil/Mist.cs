using Server.Items;
using Server.Creatures;

namespace Server.Quests
{	
	public class Mist : BaseQuest
	{
		public Mist() : base()
		{
			id = 938;
			npcId = 3535;
			name = "Mist";
			desc = "Escort Mist to Sentinel Arynia Cloudsbreak at the moon well near the Oracle Tree.";
			details = "The sabercat's fur is a distinctive gray color, blending into the surrounding forest. As she lays there, you observe that she is badly wounded, with deep lacerations across her back and stomach.$B$BShe raises her head and gazes at you, bright intelligence shining in blue eyes. She seems to wish to follow you.";
			questFlags = 0x020;
			idealLevel = 12;
			minLevel = 7;
			zone = 141;
			rewardXp = 616;
			finishDialog = "Oh, thank you, $N! I feared I would never see Mist again, knowing only her death in my heart, never to be united with my faithful companion. I owe you more than you can know, and you have my eternal gratitude.";
			progressDialog = "Mist... It was my fault! The witches caught me off guard... I should not have let them take you...";
			raceAllowed=qRaces.Alliance;
		}
		public override void InitObjectives()
		{
			rewardChoice.Add( 5590, 1 );
			rewardChoice.Add( 5593, 1 );
			rewardChoice.Add( 5618, 1 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c ) 
		{
			return BaseNPC.QDS( questOwner, c, this ); 
		}
	}
}
