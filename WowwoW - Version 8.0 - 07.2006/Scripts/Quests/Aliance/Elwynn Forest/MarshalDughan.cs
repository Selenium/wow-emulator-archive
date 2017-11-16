using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
	public class The_Fargodeep_Mine : BaseQuest 
	{ 
		public The_Fargodeep_Mine() : base() 
		{ 
			id = 62; 
			npcId = 240;
			name = "The Fargodeep Mine"; 
			desc = "Explore the Fargodeep Mine, then return to Marshal Dughan in Goldshire."; 
			details = "The mine in Northshire isn't the only one with problems!  I have reports that the Fargodeep Mine in Elwynn has also become a haven for Kobolds.\n\nExplore the mine and confirm these reports, then return to me.  The mine is almost due south of Goldshire, between the Stonefield and Maclure homesteads."; 
			questFlags = 0x020; 
			idealLevel = 7; 
			minLevel   = 5; 
			zone = 12; 
			rewardGold = 125; 
			previousQuest = 54; // Report_to_Goldshire 
			finishDialog =  "This is bad news. What's next, dragons?!? We'll have to increase our patrols near that mine. Thanks for your efforts, $N. And hold a moment... I might have another task for you."; 
			progressDialog = "What do you have to report, $N? Have you been to the Fargodeep Mine?"; 
		} 
		public override void InitObjectives()
		{// ( 88[entrance]; 197[center] ) Fargodeep Mine
			discoverigArea.Add( 88 );
			discoverigArea.Add( 197 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c ) 
		{ 
			return BaseNPC.QDS( questOwner, c, this );       
		} 
	}
	//==========
	public class The_Jasperlode_Mine : BaseQuest 
	{ 
		public The_Jasperlode_Mine() : base() 
		{ 
			id = 76; 
			npcId = 240;
			name = "The Jasperlode Mine"; 
			desc = "Explore the Jasperlode Mine, then report back to Marshal Dughan in Goldshire."; 
			details = "Thanks to you we know the Fargodeep Mine is infested with kobolds.  Now we need a scout to investigate the more distant Jasperlode Mine.\nExplore Jasperlode and confirm any kobold presence.  To reach the mine, travel east along the road until you reach the Tower of Azora.  From the tower, head north and you'll find the mine in the foothills."; 
			questFlags = 0x020; 
			idealLevel = 10; 
			minLevel   = 8; 
			zone = 12; 
			previousQuest = 62; // The_Fargodeep_Mine 
			rewardGold = 350; 
			rewardXp = 1650; 
			finishDialog = "Kobolds at the Jasperlode Mine, you say? Curses! The situation is worsening by the minute! Thank you for the report, $N. But I wish that the news you brought was good news."; 
			progressDialog = "Hail, $N. What do you have to report? Have you scouted the Jasperlode Mine?";

		} 
		public override DialogStatus QuestStatus( Mobile questOwner, Character c ) 
		{ 
			return BaseNPC.QDS( questOwner, c, this );       
		}
		public override void InitObjectives()
		{// ( 87[entrance]; 342[center] )Jasperlode Mine
			discoverigArea.Add( 87 );
			discoverigArea.Add( 342 );
		}
	}
	public class Further_Concerns : BaseQuest
	{
		public Further_Concerns() : base()
		{
			id = 35;
			npcId = 240;
			name = "Further Concerns";
			desc = "Marshal Dughan wants you to speak with Guard Thomas.";
			details = "If you are concerned that the rumors of murlocs are true, then do this -- travel to the eastern Elwynn bridge and speak with Guard Thomas. He has been stationed at the bridge for the past week and will know the state of the area.\n\nBring me his report.";
			questFlags = 0x020;
			idealLevel = 10;
			minLevel = 6;
			zone = 9;
			npcTargetId = 261;
			previousQuest = 40;
			finishDialog = "Yes, murlocs have settled in and around the streams of eastern Elwynn. We don't know why they are here, but they are aggressive and at least semi-intelligent.";
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
	}
	public class Cloth_and_Leather_Armor  : BaseQuest
	{
		public Cloth_and_Leather_Armor() : base()
		{
			id = 59;
			npcId = 240;
			name = "Cloth and Leather Armor ";
			desc = "Give Sara Timberlain the Stormwind Armor Marker.";
			details = "For your shrewdness and valor, I have a marker here that is good for one piece of armor. I want you to take it to Sara Timberlain at the Eastvale Logging Camp. Give her the marker, and she will fashion the armor for you. And after you receive it, $N, use it in the defense of Elwynn.\n\nThe Eastvale Logging Camp is beyond Guard Thomas' post to the east.";
			questFlags = 0x020;
			idealLevel = 10;
			minLevel = 6;
			zone = 9;
			previousQuest = 35;
			npcTargetId = 278; 
			finishDialog = "I have been commissioned by the Stormwind Army to supply their people with cloth and leather armor. \n\nIf you have a marker for me, then I'd be happy to make you something. ";
		}
		public override void InitObjectives()
		{
			rewardChoice.Add( 2237, 1 );
			rewardChoice.Add( 1171, 1 );
			deliveryObjectives.Add( 748, 1 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
		public override void OnAcceptQuest( Character c )
		{
			c.PutObjectInBackpack( new StormwindArmorMarker(), true );
		}
	}
	public class Westbrook_Garrison_Needs_Help : BaseQuest
	{
		public Westbrook_Garrison_Needs_Help() : base()
		{
			id = 239;
			npcId = 240;
			name = "Westbrook Garrison Needs Help!";
			desc = "Go to the Westbrook Garrison and speak with Deputy Rainer.";
			details = "The Garrison on our western border sends word of increasing gnoll and thief activity. They're requesting we send more Stormwind soldiers... but we just don't have any to spare!\n\nIf you can help, we could use it. Go and speak with Deputy Rainer at the Westbrook Garrison and see what he needs done.\n\nThe Garrison is down the road to the west. After you cross the bridge over the small brook it will be to the right.";
			questFlags = 0x020;
			idealLevel = 10;
			minLevel = 9;
			zone = 9;
			rewardXp = 420;
			npcTargetId = 963;
			finishDialog = "Marshall Dughan sent you, eh? Well you're not from the army, but if Dughan sent you then that's good enough for me! \n\nOur situation is, to say the least, a stressed one. I hope you can give us a hand. ";
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
	}
	public class Manhunt : BaseQuest
	{
		public Manhunt() : base()
		{
			id = 147;
			npcId = 240;
			name = "Manhunt";
			desc = "Find and kill \"the Collector\"  then return to Marshal Dughan with The Collector's Ring.";
			details = "If the \"Collector\" is taking gold from our mines then he's stealing from the kingdom!  Bring the Collector to justice, and bring me the ring mentioned in the pickup schedule you gave me.  It may tell us whom the Collector is working for...\nThat Pickup Schedule says the Collector is hiding out at the Brackwell Pumpkin Patch.  You should search for him there.";
			questFlags = 0x020;
			idealLevel = 10;
			minLevel = 7;
			zone = 12;
			rewardXp = 850;
			npcTargetId = 240;
			//previousQuest = 123;
			finishDialog = "You found him? Well done, $N. He won't be \"collecting\" from the Elwynn Mines again!\n\nAnd this ring you found is interesting... it's a membership ring for the old Stonemason's Guild in Stormwind. Why would a lowly thief have an artisan guild ring, and why are the Defias Thieves collecting money from our mines?\n\nDifficult questions. I hope one day we'll have answers.";
			questIsBugged = true;
		}
		public override void InitObjectives()
		{
			deliveryObjectives.Add( 2239 , 1 );
			rewardChoice.Add( 1360 , 1 );
			rewardChoice.Add( 1183 , 1 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
	}
}