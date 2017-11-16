using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
	public class Denalans_Earth : BaseQuest
	{
		public Denalans_Earth() : base()
		{
			id = 997;
			npcId = 2083;
			name = "Denalan's Earth";
			desc = "Bring the package of Rare Earth to Denalan at Lake Al'Ameth.";
			details = "Are you heading to the south? To Lake Al'Ameth? If so, then I have a task I might ask of you...My colleague Denalan has a camp along the eastern end of the lake, where he is studying and experimenting on the plant life of Teldrassil. He requested a package of rare earths from Darnassus and it was late, only recently arriving here in Dolanaar.Can you take the package to him?";
			questFlags = 0x020;
			idealLevel = 5;
			minLevel = 2;
			zone = 141;
			rewardGold = 50;
			rewardXp = 400;
		 	finishDialog = "Ah, it's here! I have waited for this rare earth for quite some time. I hope it's still fresh...Thank you for bringing it to me. You are a night elf who is generous with her time.Click Complete Quest.";
            progressDialog = "You have something for me?";
            npcTargetId = 2080;
		}
		public override void InitObjectives()
		{
			deliveryObjectives.Add( 5391, 1 );
		}
		public override void OnAcceptQuest( Character c )
		{
			c.PutObjectInBackpack( World.CreateItemInPoolById( 5391 ), true );
		}
        public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );
		}
	}
	public class Elixirs_for_the_Bladeleafs : BaseQuest
	{
		public Elixirs_for_the_Bladeleafs() : base()
		{
			id = 1581;
			npcId = 2083;
			name = "Elixirs for the Bladeleafs";
			desc = "Bring 6 Elixirs of Lion's Strength and 2 Elixirs of Minor Defense to Syral Bladeleaf in Dolanaar.";
			details = "Our herb and alchemy shop is booming, but my husband spends so much time mixing potions that we never have time for each other.Can you help us?If you can bring me a supply of pre-made elixirs, then I would be happy to trade with you. I have some rare herbs that you might find useful.";
			questFlags = 0x020;
			idealLevel = 8;
			minLevel = 6;
			zone = 141;
			rewardGold = 225;
			rewardXp = 625;
			raceAllowed=qRaces.Alliance;
		}
		public override void InitObjectives()
		{
			deliveryObjectives.Add( 2454, 6 );
			deliveryObjectives.Add( 5997, 2 );
            rewardChoice.Add( 2449, 1 );
			rewardChoice.Add( 785, 1 );
		}
        public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );
		}
	}
	public class Seek_Redemption : BaseQuest
	{
		public Seek_Redemption() : base()
		{
			id = 489;
			npcId = 2083;
			name = "Seek Redemption!";
			desc = "Collect 3 Fel Cones and give them to Zenn Foulhoof outside of Dolanaar.";
			details = "The Council of the Forest has news that you aided Zenn Foulhoof. The satyr is an enemy of the forest. As a $R, you should know better than to defile the forest by killing Nature's creatures. You must redeem yourself in the eyes of the Council if you wish to remain a friend of Teldrassil. Teach Foulhoof a lesson and you shall be redeemed. Fel Cones are corrupted seeds that fall from the trees. They billow with green smoke. Give some to Foulhoof. He'll think you have brought him a harmless snack.";
			questFlags = 0x020;
			idealLevel = 7;
			minLevel = 4;
			zone = 141;
			rewardGold = 175;
			rewardXp = 625;
		 	finishDialog = "Ah, what a sweet $R! I knew you would come in handy!";
            progressDialog = "What do you have for me? A lovely snack I presume?";
            npcTargetId = 2150;
            questIsBugged = true;
		}
		public override void InitObjectives()
		{
			deliveryObjectives.Add( 3418, 3 );
		}
        public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );
		}
	}
}
