using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
	public class Kobold_Camp_Cleanup : BaseQuest
	{
		public Kobold_Camp_Cleanup() : base()
		{
			id = 7;
			npcId = 197;
			name = "Kobold Camp Cleanup";
			desc = "Kill 10 Kobold Vermin, then return to Marshal McBride.";
			details = "Your first task is one of cleansing, $N.  A clan of kobolds have infested the woods to the north.  Go there and fight the kobold vermin you find.  Reduce their numbers so that we may one day drive them from Northshire.";
			questFlags = 0x020;
			idealLevel = 2;
			minLevel   = 1;
			zone = 9;
			previousQuest = 783;//typeof( A_Threat_Within );
			rewardXp = 260;
			rewardGold	= 25;
			finishDialog =  "Well done, citizen. Those kobolds are thieves and cowards, but in large numbers they pose a threat to us. And the humans of Stormwind do not need another threat.\n\n For defeating them, you have my gratitude.";
		}
		public override void InitObjectives()
		{
			npcObjectives.Add( 6, 10 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
	}
	//==========
	public class Investigate_Echo_Ridge : BaseQuest
	{
		public Investigate_Echo_Ridge() : base()
		{
			id = 15;
			npcId = 197;
			name = "Investigate Echo Ridge";
			desc = "Kill 10 Kobold Workers, then report back to Marshal McBride.";
			details = "$N, my scouts tell me that the kobold infestation is larger than we had thought.  A group of kobold workers has camped near the Echo Ridge Mine to the north.\n\nGo to the mine and remove them.  We know there are at least 10.  Kill them, see if there are more, then report back to me.";
			questFlags = 0x020;
			idealLevel = 3;
			minLevel   = 2;
			zone = 9;
			previousQuest = 7;//typeof( Kobold_Camp_Cleanup );
			rewardXp = 390;
			rewardGold	= 40;
			finishDialog = "I don't like hearing of all these kobolds in our mine. No good can come of this. Here, take this as payment, and when you're ready, speak to me again. I would like you to go back to the mines one more time...";
		}
		public override void InitObjectives()
		{
			npcObjectives.Add( 257, 10 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
	}
	//==========
	public class Skirmish_at_Echo_Ridge : BaseQuest
	{
		public Skirmish_at_Echo_Ridge() : base()
		{
			id = 21;
			npcId = 197;
			name = "Skirmish at Echo Ridge";
			desc = "Kill 12 Kobold Laborers, then return to Marshal McBride at Northshire Abbey.";
			details = "Your previous investigations are proof that the Echo Ridge Mine needs purging.  Return to the mine and help clear it of kobolds.\n\nWaste no time, $N.  The longer the kobolds are left unmolested in the mine, the deeper a foothold they gain in Northshire.";
			questFlags = 0x20;
			idealLevel = 5;
			minLevel   = 3;
			zone = 9;
			previousQuest = 15;//typeof( Investigate_Echo_Ridge );
			rewardXp = 675;
			finishDialog = "Once again, you have earned my respect, and the gratitude of the Stormwind Army. There may yet be kobolds in the mine, but I will marshal others against them. We have further tasks for you.";
		}
		public override void InitObjectives()
		{
			npcObjectives.Add( 80, 12 );
			rewardChoice.Add( 2186, 1 );
			rewardChoice.Add( 2691, 1 );
			rewardChoice.Add( 11192, 1 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
	}
	//==========
	public class Report_to_Goldshire : BaseQuest
	{//пока не работает нужен id в базовый класс
		public Report_to_Goldshire() : base()
		{
			id = 54;
			npcId = 197;
			name = "Report to Goldshire";
			desc = "Take Marshal McBride's Documents to Marshal Dughan in Goldshire.";
			details = "$N, you are a $C with proven interest in the security of Northshire.  You are now tasked with the protection of the surrounding Elwynn Forest.\n\nIf you accept this duty, then I have prepared papers that must be delivered to Marshal Dughan in Goldshire.  Goldshire lies along the southern road, past the border gates.";
			questFlags = 0x020;
			idealLevel = 5;
			minLevel = 4;
			zone = 9;
			previousQuest = 21;//typeof( Skirmish_at_Echo_Ridge );
			npcTargetId = 240;// MarshalDughan
			rewardXp = 450;
			finishDialog = "Well, it says here that you've been awarded Acting Deputy Status with the Stormwind Marshals. Congratulations. And good luck - keeping Elwynn safe is no picnic... what with most the army busy doing who knows what for who knows which noble! It's hard to keep track of politics in these dark days...";
			progressDialog = "You have word from McBride? Northshire is a garden compared to Elwynn Forest, but I wonder what Marshal McBride has to report. Here, let me have his papers...";
		}
		public override void InitObjectives()
		{
			deliveryObjectives.Add( 745, 1 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
		public override void OnAcceptQuest( Character c )
		{
			c.PutObjectInBackpack( new MarshalMcBridesDocuments(), true );
		}
	}
	//==========
	/* OLD
	public class FindStormWindQuest : BaseQuest
	{//Test only, disabled
		public FindStormWindQuest()
		{
			Id = 12;
			npcId = 197;
			Name = "Please go to the west and find the Stormwind city";
			Desc = "Stormwind is the most beautiful city";
			Details = "You need to visit it !";
			QuestFlags = 0x020;
			IdealLevel = 2;
			MinLevel = 1;
			RewardXp = 100;
			DiscoveryTitle = "Quest completed";
			DiscoveryMessage = "You have sucsessfuly discovery Stormwind City";
			DiscoveringAreaId = 0xAE2;
			Zone = 12;
			PreviousQuest = 783;//typeof( A_Threat_Within );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			if ( questOwner.Reputation( c ) > 0.5f && c.Level >= MinLevel )
			{
				if ( c.QuestDone( this ) ) return DialogStatus.ChatAvailable;
				if ( !c.HaveQuest( this ) ) return DialogStatus.QuestStatusAvailable;
				ActiveQuest aq = c.FindPlayerQuest( this );
				if ( aq.Completed ) return DialogStatus.QuestReward;
				return DialogStatus.QuestStatusIncomplete;
			}
			return DialogStatus.QuestStatusNone;
		}
	}*/
}
