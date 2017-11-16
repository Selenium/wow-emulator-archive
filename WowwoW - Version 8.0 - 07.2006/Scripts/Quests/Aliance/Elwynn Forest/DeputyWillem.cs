using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
	public class A_Threat_Within : BaseQuest
	{
		public A_Threat_Within() : base()
		{
			id = 783;
			npcId = 823;
			name = "A Threat Within";
			desc = "Speak with Marshal McBride.";
			details = "I hope you strapped your belt on tight, young $C, because there is work to do here in Northshire.\n\nAnd I don't mean farming.\n\nThe Stormwind guards are hard pressed to keep the peace here, with so many of us in distant lands and so many threats pressing close. And so we're enlisting the aid of anyone willing to defend their home. And their alliance.\n\nIf you're here to answer the call, then speak with my superior, Marshal McBride. He's inside the abbey behind me.";
			questFlags = 0x020;
			idealLevel = 1;
			minLevel = 1;
			zone = 9;
			rewardXp = 50;
			npcTargetId = 197;
			finishDialog = "Ah, good. Another volunteer. We're getting a lot of you these days. I hope it's enough. The human lands are threatened from without, and so many of our forces have been marshaled abroad. This, in turn, leaves room for corrupt and lawless groups to thrive within our borders. It is a many-fronted battle we wage, $N. Gird yourself for a long campaign.";
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
	}
	//==========
	public class Bounty_on_Garrick_Padfoot : BaseQuest
	{
		public Bounty_on_Garrick_Padfoot() : base()
		{
			id = 6;
			npcId = 823;
			name = "Bounty on Garrick Padfoot";
			desc = "Kill Garrick Padfoot and bring his head to Deputy Willem at Northshire Abbey.";
			details = "Garrick Padfoot - a cutthroat who's plagued our farmers and merchants for weeks - was seen at a shack near the vineyards, which lies east of the Abbey and across the bridge.  Bring me the villain's head, and earn his bounty!\n\nBut be wary, $N.  Garrick has gathered a gang of thugs around him.  He will not be an easy man to reach.";
			questFlags = 0x020;
			idealLevel = 5;
			minLevel = 4;
			zone = 9;
			rewardXp = 675;
			finishDialog = "Hah - you caught him! You've done Elwynn a great service, and earned a nice bounty!";
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
		public override void InitObjectives()
		{
			deliveryObjectives.Add( 182, 1 );
			rewardChoice.Add( 60, 1 );
			rewardChoice.Add( 6076, 1 );
			rewardChoice.Add( 3070, 1 );
		}
	}
	//==========
	public class Brotherhood_of_Thieves : BaseQuest
	{
		public Brotherhood_of_Thieves() : base()
		{
			id = 18;
			npcId = 823;
			name = "Brotherhood of Thieves";
			desc = "Bring 12 Red Burlap Bandanas to Deputy Willem outside the Northshire Abbey.";
			details = "Recently, a new group of thieves has been hanging around Northshire.  They call themselves the Defias Brotherhood, and have been seen across the river to the east.\n\nI don't know what they're up to, but I'm sure it's not good!  Bring me the bandanas they wear, and I'll reward you with a weapon.";
			questFlags = 0x020;
			idealLevel = 4;
			minLevel = 2;
			zone = 9;
			finishDialog = "Back with some bandanas, I see. The Stormwind Army appreciates your help.";
			rewardXp = 550;
		}
		public override void InitObjectives()
		{
			deliveryObjectives.Add( 752, 12 );
			rewardChoice.Add( 5580, 1 );
			rewardChoice.Add( 5579, 1 );
			rewardChoice.Add( 2224, 1 );
			rewardChoice.Add( 1161, 1 );
			rewardChoice.Add( 1159, 1 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
	}
	//==========
	public class Eagan_Peltskinner : BaseQuest
	{
		public Eagan_Peltskinner() : base()
		{
			id = 5261;
			npcId = 823;
			name = "Eagan Peltskinner";
			desc = "Speak with Eagan Peltskinner.";
			details = "Eagan Peltskinner is looking for someone to hunt wolves for him.  That's good news, because we're seeing a lot more wolves in Northshire valley lately.\n\nIf you're interested then speak with Eagan.  He's around the side of the abbey, to the left.";
			questFlags = 0x020;
			idealLevel = 2;
			minLevel = 2;
			zone = 9;
            npcTargetId = 196;
			finishDialog =  "That's true. I'm looking for someone to hunt me some wolves! Are you that person?";
			rewardXp = 100;
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
	}
	public class Milly_Osworth  : BaseQuest
	{
		public Milly_Osworth() : base()
		{
			id = 3903;
			npcId = 823;
			name = "Milly Osworth";
			desc = "Speak with Milly Osworth.";
			details = "You've shown yourself a dependable $C, $N. Dependable, and not afraid to get your hands dirty, eh?\n\nI have a friend, Milly Osworth, who's in some trouble. She's over with her wagon on the other side of the abbey, near the stable. I'm sure she could use a pair of hands like yours.";
			questFlags = 0x020;
			idealLevel = 4;
			minLevel = 2;
			zone = 9;
			rewardXp = 135;
			npcTargetId = 9296;
			previousQuest = 33;
			finishDialog = "Oh, Deputy Willem told you to speak with me? He's a brave man and always willing to help, but his duties keep him stuck at Northshire Abbey and I'm afraid the problem I have today is beyond him. \n\nPerhaps you can help me?";
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
	}

}
