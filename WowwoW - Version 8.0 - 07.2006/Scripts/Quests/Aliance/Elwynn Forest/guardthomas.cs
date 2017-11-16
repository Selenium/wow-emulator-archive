using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
	public class Deliver_Thomas_Report  : BaseQuest
	{
		public Deliver_Thomas_Report() : base()
		{
			id = 39;
			npcId = 261;
			name = "Deliver Thomas' Report";
			desc = "Report to Marshal Dughan in Goldshire.";
			details = "Tell Marshal Dughan of Malakai and Rolf's deaths, and report to him that the Murlocs in eastern Elwynn cannot be contained by our current troop presence.\n\n I know we don't have many troops to spare, but hopefully Dughan can find someone.";
			questFlags = 0x020;
			idealLevel = 10;
			minLevel = 6;
			zone = 9;
			rewardXp = 1450;
			npcTargetId = 240;
			//previousQuest = 71;
			rewardGold = 700;
			finishDialog = "Hmmm, this news is troubling. Already our defenses are stretched thin, and losing Rolf and Malakai to those murlocs put us in an even worse position. \n\nIf things don't improve, there will be fighting in Goldshire by the week's end!";
			questIsBugged = true;
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
	}
	public class Bounty_On_Murlocs  : BaseQuest
	{
		public Bounty_On_Murlocs() : base()
		{
			id = 46;
			npcId = 261;
			name = "Bounty on Murlocs ";
			desc = "Bring 8 Torn Murloc Fins to Guard Thomas at the east Elwynn bridge.";
			details = "The Stormwind Army has placed a bounty on murloc lurkers and foragers in Elwynn. Slaughter them and bring me their torn murloc fins, and the Stormwind Army will reward you well.\n\nThe murlocs have built a village at Stone Cairn Lake north of here, and another to the south where the stream forks.";
			questFlags = 0x020;
			idealLevel = 10;
			minLevel = 6;
			zone = 9;
			previousQuest = 39;
			finishDialog = "You have the fins? Great! Marshal Dughan is anxious about the Murloc situation in eastern Elwynn, and I'd like to tell him that it's becoming under control.\n\nYour actions have helped realize that.";
			questIsBugged = true;
		}
		public override void InitObjectives()
		{
			rewardChoice.Add( 4840, 1 );
			rewardChoice.Add( 1158, 1 );
			rewardChoice.Add( 1008, 1 ); 
			deliveryObjectives.Add( 780, 1 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
		
	}
	public class Protect_The_Frontier : BaseQuest
	{
		public Protect_The_Frontier() : base()
		{
			id = 52;
			npcId = 261;
			name = "Protect the Frontier";
			desc = "Kill 8 Prowlers and 5 Young Forest Bears, and then return to Guard Thomas at the east Elwynn bridge.";
			details = "Hail, $N. Wild animals are growing more and more aggressive the farther we get from Goldshire, and the Eastvale Logging Camp suffers nearly constant attacks from wolves and bears!\n\n We could use your help out here.";
			questFlags = 0x020;
			idealLevel = 10;
			minLevel = 9;
			zone = 9;
			rewardXp = 875;
			rewardGold = 250;
			finishDialog =  "Thanks a lot for the help, $N. Something in the forest must be making these animals so bold. \n\nWhatever it is, I hope it stays there.";
		}
		public override void InitObjectives()
		{
			reward.Add( 858, 2 );
			npcObjectives.Add( 118, 8 );
			npcObjectives.Add( 822, 5 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
	}
	public class Report_To_Gryan_Stoutmantle  : BaseQuest
	{
		public Report_To_Gryan_Stoutmantle() : base()
		{
			id = 109;
			npcId = 261;
			name = "Report to Gryan Stoutmantle ";
			desc = "Talk to Gryan Stoutmantle. He usually can be found in the stone tower on Sentinel Hill, just off the road, in the middle of Westfall.";
			details = "Looks to me you've seen quite a bit of combat in your time, $C. If you haven't already, you should report to Gryan Stoutmantle. He heads up the People's Militia, aimed at protecting the farmlands of Westfall. I bet he could use your help. You can usually find him in the stone tower on Sentinel Hill, just off the road in the middle of Westfall.";
			questFlags = 0x020;
			idealLevel = 10;
			minLevel =9;
			zone = 9;
			rewardXp = 1250;
			npcTargetId = 234;
			rewardGold = 250;
			finishDialog =  "Ah, so my friend sent you here? How kind. \n\nWell the Stormwind Monarchy has abandoned our cause. Now it is up to the People's Militia to keep the land free from corruption. If our cause interests you, I can put your combat skills to use in the name of freedom. ";
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
	}
}