using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
	public class The_Shimmering_Frond : BaseQuest 
	{
		public The_Shimmering_Frond() : base()
		{
			id = 931;
			npcId = 3535;
			name = "The Shimmering Frond";
			desc = "Bring a Shimmering Frond to Denalan at Lake Al'Ameth";
			details = "The fronds on this plant shimmer in the forest light, giving it a twisting, pulsing aura.$B$BYou believe that Denalan would want a specimen of this.";
			questFlags = 0x020;
			idealLevel = 10;
			minLevel = 5;
			zone = 141;
			rewardXp = 522;
			rewardGold = 350;
			finishDialog = "Where did you get this? I haven't seen a plant like this since a sojourn I made to the Swamp of Sorrows... decades ago! It's amazing that a specimen made its way to Teldrassil. And it's grown to such a size!$b$bThank you, $N. Forgive my shortness of words, but there is a test I would like to perform on this frond...";
			progressDialog = "You have something for me?";
			raceAllowed=qRaces.Alliance;
			npcTargetId = 2080;
		}
		public override void InitObjectives()
		{
			deliveryObjectives.Add( 5190, 1 );
		}
		public override void OnAcceptQuest(Character c)
		{
			c.PutObjectInBackpack( World.CreateItemInPoolById(5190), 1, true);
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c ) 
		{
			return BaseNPC.QDS( questOwner, c, this ); 
		}
	}
	public class The_Moss_twined_Heart : BaseQuest
	{
		public The_Moss_twined_Heart() : base()
		{
			id = 927;
			npcId = 3535;
			name = "The Moss-twined Heart";
			desc = "Bring the Moss-twined Heart to Denalan at Lake Al'Ameth.";
			details = "The heart of Blackmoss the Fetid is covered with a dark, oily moss. In fact, the only way to tell this is a heart is from its slow, rhythmic beat... A beat that continues even now.$B$BPerhaps Denalan will want to see this heart.";
			questFlags = 0x020;
			idealLevel = 12;
			minLevel = 7;
			zone = 141;
			rewardXp = 616;
			finishDialog = "...What is this? A timberling heart?? It's covered with a foul moss!$b$bThank you for bringing this to me, $N. I will examine the heart and, if fortune shines, determine the nature of the moss about it.";
			progressDialog = "$N! You have something for me?";
			raceAllowed=qRaces.Alliance;
			npcTargetId = 2080;
		}
		public override void InitObjectives()
		{
			deliveryObjectives.Add( 5179, 1 );
		}
		public override void OnAcceptQuest(Character c)
		{
			c.PutObjectInBackpack( World.CreateItemInPoolById(5179), 1, true);
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );
		}
	}
}
