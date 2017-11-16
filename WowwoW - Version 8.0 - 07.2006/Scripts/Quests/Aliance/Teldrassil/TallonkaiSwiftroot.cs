using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
	public class The_Emerald_Dreamcatcher : BaseQuest
	{
		public The_Emerald_Dreamcatcher() : base()
		{
			id = 2438;
			npcId = 3567;
			name = "The Emerald Dreamcatcher";
			desc = "Bring the Emerald Dreamcatcher to Tallonkai Swiftroot in Dolanaar.";
			details = "I was once given an emerald dreamcatcher from Gaerolas Talvethen, the warden of the druids in the Ban'ethil Barrow Den. This powerful amulet is able to siphon energy from the Emerald Dream, bestowing luck upon those who carry it. Sadly, I have not been able to retrieve it from my dresser in Starbreeze Village... Although Starbreeze was once a tranquil place, it has now succumbed to the corruption of the furbolg that reside there. Perhaps you would be willing to recover my dreamcatcher, $C ?";
			questFlags = 0x020;
			idealLevel = 6;
			minLevel = 3;
			zone = 141;
			rewardXp = 410;
			rewardGold = 100;
			finishDialog = "Ah, very good. I will have this egg and the venom transported to Darnassus, then return there when my studies are done here. I expect to find out a great deal from these specimens. You have been a great help to me.";
			progressDialog= "Do you think that you are able to complete my quest ?";
			raceAllowed=qRaces.Alliance;
			questIsBugged = true;
		}
		public override void InitObjectives()
		{
			deliveryObjectives.Add( 8048, 1 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );
		}
	}
	public class Ferocitas_the_Dream_Eater : BaseQuest
	{
		public Ferocitas_the_Dream_Eater() : base()
		{
			id = 2459;
			npcId = 3567;
			name = "Ferocitas the Dream Eater";
			desc = "Tallonkai Swiftroot in Dolanaar wants you to kill 7 Gnarlpine Mystics and find the Missing Jewel.";
			details = "The emerald... It is missing! My dreamcatcher has been damaged! There is a band of Gnarlpine mystics located to the north of Starbreeze. I have heard reports that their leader, Ferocitas the Dream Eater has been wearing a necklace that glows green in the night. Now seeing my dreamcatcher, I am sure that he has stolen my emerald... He would never realize that its power is useless to him. Find this missing jewel, $N. And, while you're there, clear out some of the corrupted mystics as well.";
			questFlags = 0x020;
			idealLevel = 8;
			minLevel = 5;
			zone = 141;
			rewardXp = 428;
			rewardGold = 450;
			previousQuest = 2438;
			finishDialog = "Awesome work $N!";
			progressDialog= "Did you find my Jewel ?";
			raceAllowed=qRaces.Alliance;
		}
		public override void InitObjectives()
		{
			npcObjectives.Add( 7235, 7 );
			deliveryObjectives.Add( 8050, 1 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );
		}
	}
	public class Twisted_Hatred : BaseQuest
	{
		public Twisted_Hatred() : base()
		{
			id = 932;
			npcId = 3567;
			name = "Twisted Hatred";
			desc = "Kill Lord Melenas and bring his head to Tallonkai Swiftroot in Dolanaar.";
			details = "I must warn you, $N, this matter must stay between us. The satyr are enough of an embarrassment to us already, and this one is much too close to home. He is called Lord Melenas. He resides in the nearby cave of Fel Rock where he has gathered a large group of grell warriors. His heart is black as night, and he plots something most foul. You must find him within his nearby cave just to the north of here, and bring me his head.";
			questFlags = 0x020;
			idealLevel = 7;
			minLevel = 6;
			zone = 141;
			rewardXp = 340;
			finishDialog = "$N! you killed the bad guy...";
			progressDialog= "Destroy him!";
			raceAllowed=qRaces.Alliance;
		}
		public override void InitObjectives()
		{
			deliveryObjectives.Add( 5221, 1 );
			rewardChoice.Add( 5419, 1 );
			rewardChoice.Add( 2571, 1 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );
		}
	}
}
