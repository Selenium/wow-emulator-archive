using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
	public class Timberling_Seeds : BaseQuest
	{
		public Timberling_Seeds() : base()
		{
			id = 918;
			npcId = 2080;
			name = "Timberling Seeds";
			desc = "Bring 8 Timberling Seeds to Denelan at Lake Al'Ameth.";
			details = "The timberlings of Teldrassil are elementals of nature. In some ways they reflect the natural order of plants and animals on our great tree. So it is disturbing to see how angry the timberlings have become. I believe it has something to do with the soil. I have been working on different methods of nurturing plants and would like to try them on timberling seeds. Please, can you gather seeds from timberlings around Lake Al'Ameth and bring them to me?";
			questFlags = 0x020;
			idealLevel = 7;
            minLevel = 5;
			zone = 141;
			rewardGold = 50;
			rewardXp = 400;
		 	finishDialog = "You got them. This is good! I will plant these seeds in special soil I have prepared. I believe the seeds will sprout into timberlings who are much more docile. Perhaps later you can see the results!Click Complete Quest.";
            progressDialog = "Do you have the seeds? I am eager to plant them.";
            previousQuest = 997;
            raceAllowed=qRaces.Alliance;
		}
		public override void InitObjectives()
		{
			reward.Add( 18002, 10 );
			deliveryObjectives.Add( 5168, 8 );
		}
        public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );
		}
	}
	public class Rellian_Greenspyre : BaseQuest
	{
		public Rellian_Greenspyre() : base()
		{
			id = 922;
			npcId = 2080;
			name = "Rellian Greenspyre";
			desc = "Bring a Timberling Seed to Rellian Greenspyre in Darnassus.";
			details = "$N, can you take one of the seeds you brought me to my friend, Rellian Greenspyre? He is a druid in Darnassus, and when last we spoke he revealed his interest in my work with the Timberlings. He had some ideas himself, and he will appreciate a specimen seed to work with. Thank you, $N. You have been a great help to me. I hope that, some day, you will see the fruit of my labors. You will usually find Rellian walking the pathways of the Cenarian Enclave in Darnassus.";
			questFlags = 0x020;
			idealLevel = 7;
			minLevel = 3;
			zone = 141;
			rewardGold = 50;
			rewardXp = 400;
		 	finishDialog = "Ah, a timberling seed? I wanted to try growing one of these to help Denalan with his studies.But I'm afraid I've discovered that a corruption has grown in many of the timberlings, and seeds from such creatures carry their parent's taint. They are beyond my talents to repair.Denalan is very skilled with things that grow. He may find a cure for future timberlings. He may be their only hope.";
            progressDialog = "Hello...And how may I help you?";
            npcTargetId = 3517;
            previousQuest = 918;
            raceAllowed=qRaces.Alliance;
		}
		public override void InitObjectives()
		{
			deliveryObjectives.Add( 5168, 1 );
		}
        public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );
		}

	}
	public class Oakenscowl_Elite : BaseQuest
	{
		public Oakenscowl_Elite() : base()
		{
			id = 2499;
			npcId = 2080;
			name = "Oakenscowl (Elite)";
			desc = "Denalan at Lake Al'Ameth wants you to collect the Gargantuan Tumor from Oakenscowl.";
			details = "In a cave along the southern bank of the lake, a timberling named Oakenscowl is spreading corruption to all the creatures that make Lake Al'Ameth their home. I dared not get too close, but even from a distance, it is obvious: Oakenscowl is being poisoned by the largest tumor I have ever seen... I would call it gargantuan, even. $N, you have already done much to aid my efforts, but I ask of you one more task. Hunt down Oakenscowl and collect the tumor; remove this source of corruption from my home.";
			questFlags = 0x020;
			idealLevel = 9;
			minLevel = 7;
			zone = 141;
			rewardGold = 600;
			rewardXp = 476;
		 	finishDialog = "I never seen such a big Gargantuan Tumor";
            progressDialog = "Do you have something for me ?";
            previousQuest = 2498;
            raceAllowed=qRaces.Alliance;
		}
		public override void InitObjectives()
		{
			rewardChoice.Add( 5458, 1 );
			rewardChoice.Add( 5589, 1 );
			deliveryObjectives.Add( 8136, 1 );
		}
        public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );
		}
	}
	public class Planting_the_Heart : BaseQuest
	{
		public Planting_the_Heart() : base()
		{
			id = 941;
			npcId = 2080;
			name = "Planting the Heart";
			desc = "Plant the Tainted Heart in Denalan's Planter.";
			details = "I have removed that foul moss from the heart, but it remains tainted... Try placing the heart in my planter. It is filled with a nutritive soil that may cleanse and heal the heart.";
			questFlags = 0x020;
			idealLevel = 12;
			minLevel = 10;
			zone = 141;
		 	finishDialog = "Thank you $N!";
            progressDialog = "Do you have something for me ?";
            previousQuest = 927;
            raceAllowed = qRaces.Alliance;
            questIsBugged = true;
		}
		public override void OnAcceptQuest( Character c )
		{
			c.PutObjectInBackpack( World.CreateItemInPoolById( 5217 ), true );
		}
        public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );
		}
	}
	public class Timberling_Sprouts : BaseQuest
	{
		public Timberling_Sprouts() : base()
		{
			id = 919;
			npcId = 2080;
			name = "Timberling Sprouts";
			desc = "Bring 12 Timberling Sprouts to Denalan at Lake Al'Ameth.";
			details = "Small timberlings are sprouting around the waters of Lake Al'Ameth. I'm afraid these sprouts are beyond help -- we should try to clear them from the land before they grow large enough to cause trouble. When you're wandering the lake, if you see any timberling sprouts please take them. Help keep our land clean!";
			questFlags = 0x020;
			idealLevel = 7;
			minLevel = 4;
			zone = 141;
			rewardGold = 350;
			rewardXp = 600;
			questIsBugged = true;
		 	finishDialog = "Thank you $N!";
            progressDialog = "Do you have something for me ?";
            raceAllowed=qRaces.Alliance;
		}
		public override void InitObjectives()
		{
			deliveryObjectives.Add( 5169, 12 );
            rewardChoice.Add( 5606, 1 );
			rewardChoice.Add( 6061, 1 );
		}
        public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );
		}
	}
}
