using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
	public class The_Glowing_Fruit : BaseQuest
	{
		public The_Glowing_Fruit() : base()
		{
			id = 930;
			npcId = 3515;
			name = "The Glowing Fruit";
			desc = "Bring the glowing fruit to Denalan at Lake Al'Ameth.";
			details = "Hanging from beneath its fronds of this glowing plant is a large, round fruit.$B$BDenalan would want to study this fruit, you are certain.";
			questFlags = 0x020;
			idealLevel = 10;
			minLevel = 5;
			zone = 141;
			rewardXp = 522;
			rewardGold = 350;
			previousQuest = 929;
			finishDialog = "You found this on Teldrassil? Intriguing... this fruit is exotic. Perhaps its seeds were brought here from far off. Perhaps even as far as Azeroth! And there's something about this fruit... it seems to have reacted very strangely with the soil of Teldrassil.$b$bThank you, $N. Now if you'll excuse me, I must study this further...";
			progressDialog = "$N, you look like you have something to tell me. Do you have news concerning the timberlings?";
			raceAllowed=qRaces.Alliance;
			npcTargetId = 2080;
		}
		public override void InitObjectives()
		{
			deliveryObjectives.Add( 5189, 1 );
		}
		public override void OnAcceptQuest( Character c )
		{
			c.PutObjectInBackpack( World.CreateItemInPoolById(5189), true );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c ) 
		{
			return BaseNPC.QDS( questOwner, c, this ); 
		}
	}
	public class Crown_of_the_Earth4 : BaseQuest
	{
		public Crown_of_the_Earth4() : base()
		{
			id = 929;
			npcId = 3515;
			name = "Crown of the Earth";
			desc = "Fill the Jade Phial and bring it back to Corithras Moonrage in Dolanaar.";
			details = "First, let me tell you more of the task you must complete. The druids in Darnassus use the water of the moonwells of Teldrassil, and their moonwell must be replenished from time to time. Using these specially crafted phials, you can collect the water of the moonwells.Take this vessel to the moonwell outside of Starbreeze Village to the east, and fill it with some of its waters, then return to me. When you have completed your task, I shall continue the story where Tenaron left off...";
			questFlags = 0x020;
			idealLevel = 3;
			minLevel = 1;
			zone = 141;
			rewardXp = 100;
			previousQuest = 928;
            questIsBugged = true;
		 	finishDialog = "After the Battle of Mount Hyjal, we were without direction. Nordrassil smoked from the fire it unleashed, and our immortality -- the very essence of our beings! -- was lost.It was in this trying time that the Betrayer was freed from his prison, and Shan'do Stormrage disappeared. A dark time for all. ";
            progressDialog = "Hello again. Have you completed your task?Required items: Filled Jade Phial";
		}
		public override void InitObjectives()
		{
			deliveryObjectives.Add( 5639, 1 );
		}
		public override void OnAcceptQuest( Character c )
		{
			c.PutObjectInBackpack( World.CreateItemInPoolById(5619), true );
		}
        	public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );
		}
	}
	public class Crown_of_the_Earth5 : BaseQuest
	{
		public Crown_of_the_Earth5() : base()
		{
			id = 933;
			npcId = 3515;
			name = "Crown of the Earth";
			desc = "Fill the Tourmaline Phial and bring it back to Corithras Moonrage in Dolanaar.";
			details = "There is another moonwell southeast of the entrance to Darnassus, on the shores of the Pools of Arlithrien. The Sentinels are having problems patrolling the area because of attacks and the growing ill-temperedness of the Gnarlpine furbolgs.Be wary as you seek out the well, and keep your weapons close at hand.";
			questFlags = 0x020;
			idealLevel = 6;
			minLevel = 2;
			zone = 141;
			rewardXp = 100;
			previousQuest = 929;
            questIsBugged = true;
		}
		public override void InitObjectives()
		{
			deliveryObjectives.Add( 5621, 1 );
		}
		public override void OnAcceptQuest( Character c )
		{
			c.PutObjectInBackpack( World.CreateItemInPoolById(5645), true );
		}
        public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );
		}
	}
	public class Crown_of_the_Earth6 : BaseQuest
	{
		public Crown_of_the_Earth6() : base()
		{
			id = 934;
			npcId = 3515;
			name = "Crown of the Earth";
			desc = "Fill the Amethyst Phial and bring it back to Corithras Moonrage in Dolanaar.";
			details = "All was not well with Teldrassil, however. Staghelm's carefully made plans for the new World Tree had borne out as he had hoped, but there was one small problem, a problem to which many of the troubles on Teldrassil may be attributed.However, I will not get into that yet. You must visit the last moonwell, to the northwest in the Oracle Glade. Under the boughs of the Oracle Tree lies the first and most powerful of our wells. Retrieve a phial of its water and return to me.";
			questFlags = 0x020;
			idealLevel = 6;
			minLevel = 2;
			zone = 141;
			rewardXp = 100;
			previousQuest = 933;
            questIsBugged = true;
		}
		public override void InitObjectives()
		{
			deliveryObjectives.Add( 18151, 1 );
		}
		public override void OnAcceptQuest( Character c )
		{
			c.PutObjectInBackpack( World.CreateItemInPoolById( 18152 ), true );
		}
        public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );
		}
	}
	public class Crown_of_the_Earth7 : BaseQuest
	{
		public Crown_of_the_Earth7() : base()
		{
			id = 935;
			npcId = 3515;
			name = "Crown of the Earth";
			desc = "Bring the Filled Vessel to Arch Druid Fandral Staghelm in Darnassus.";
			details = "Without the blessings of Alexstrasza the Life-Binder and Nozdormu the Timeless, Teldrassil's growth has not been without flaw. Strange beasts have been reported arising from the very ground of the tree, and crazed furbolgs attack passing travelers.I can only hope that the solution the Arch Druid is looking for will be found quickly. I will pour all the phials you brought into this vessel, for you to deliver to Darnassus.Bring it to Fandral Staghelm, you will find him in the druid grove.";
			questFlags = 0x020;
			idealLevel = 6;
			minLevel = 4;
			zone = 141;
			rewardXp = 100;
			previousQuest = 934;
			npcTargetId = 3516;
		}
		public override void InitObjectives()
		{
			deliveryObjectives.Add( 5188, 1 );
		}
		public override void OnAcceptQuest( Character c )
		{
			c.PutObjectInBackpack( World.CreateItemInPoolById( 5188 ), true );
		}
        public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );
		}
	}
}
