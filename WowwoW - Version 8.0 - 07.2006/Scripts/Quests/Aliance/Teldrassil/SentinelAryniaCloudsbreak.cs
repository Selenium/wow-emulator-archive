using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
	public class The_Enchanted_Glade : BaseQuest
	{
		public The_Enchanted_Glade() : base()
		{
			id = 937;
			npcId = 3519;
			name = "The Enchanted Glade";
			desc = "Acquire 6 Bloodfeather Belts and bring them to Sentinel Arynia Cloudsbreak in the Oracle Glade.";
			details = "I was dispatched with a small group of Sentinels here to protect the Oracle Tree from the harpies that have made nests all around the glade. Little by little we are trying to push them back.$B$BWhen the Oracle Tree attempted to send a runner to Darnassus with a report, the messenger was attacked and killed by a group of the harpies.$B$BIf you feel up to the task, go to their nests, slay them, and return their belts to me as proof of your deeds.";
			questFlags = 0x020;
			idealLevel = 11;
			minLevel = 6;
			zone = 141;
			rewardXp = 570;
			finishDialog = "I am impressed by what you have accomplished here in so short a time, $N. Would that I could ask you to remain here to assist me with my duties... but I know in my heart that greater tasks lie ahead for you.$b$bI have noticed the Oracle Tree has just shed a piece of its bark. No doubt it has a task that it wishes completed. You should speak with it.";
			progressDialog = "Their slashing talons and piercing beaks may prove a difficult match for your own abilities, $N, but I have faith that you will not fail in this task.";
			raceAllowed=qRaces.Alliance;
		}
		public override void InitObjectives()
		{
			rewardChoice.Add( 5592, 1 );
			rewardChoice.Add( 5591, 1 );
			deliveryObjectives.Add( 5204, 6 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c ) 
		{
			return BaseNPC.QDS( questOwner, c, this ); 
		}
	}
	public class Teldrassil : BaseQuest //NPC: 3519
	{
		public Teldrassil() : base()
		{
			id = 940;
			npcId = 3519;
			name = "Teldrassil";
			desc = "Deliver the Oracle Tree's report to Arch Druid Fandral Staghelm in Darnassus.";
			details = "The forest whispers of your feats of valor, $N. As I felt the harpies forced from their nests, a greater calm spread across the forest, its creatures once again feeling safe. I have feared sending another messenger to the Arch Druid, but I know that you will see my message safely to him.$B$BDeliver this to him and know that the forest will see you safely along its paths to the forest of stone.";
			questFlags = 0x020;
			idealLevel = 11;
			minLevel = 6;
			zone = 141;
			rewardXp = 570;
			previousQuest = 937;
			finishDialog = "I wondered why the Oracle Tree had not communicated with me for so long... It seems that some problems are lessened while others grow to greater concerns.$b$bI fear my work on Teldrassil shall never be completed, and our immortality never restored.$b$bNonetheless, you have done the Oracle Tree's task well, and should be rewarded for your diligence.";
			progressDialog = "Hmm... You come with the spirit of the forest strongly within you, $C. What business do you have with the Arch $C of the Kaldorei?";
			raceAllowed=qRaces.Alliance;
			npcTargetId = 3516;
		}
		public override void InitObjectives()
		{
			deliveryObjectives.Add( 5219, 1 );
		}
		public override void OnAcceptQuest(Character c)
		{
			c.PutObjectInBackpack( World.CreateItemInPoolById(5219), 1, true);
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this ); 
		}
	}
}
