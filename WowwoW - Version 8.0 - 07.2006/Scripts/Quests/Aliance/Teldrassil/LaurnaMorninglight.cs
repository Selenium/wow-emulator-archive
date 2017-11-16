using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
	public class Garments_of_the_Moon : BaseQuest
	{
		public Garments_of_the_Moon() : base()
		{
			id = 5621;
			npcId = 3600;
			name = "Garments of the Moon";
			desc = "Find Sentinel Shaya and heal her wounds using Lesser Heal (Rank 2). Afterwards, grant her Power Word: Fortitude and then return to Laurna Morninglight in Dolanaar.";
			details = "I need your help, $N. I am needed here to train the other students, but you, you can help one of our injured Sentinels just south of Dolanaar. She was hurt patrolling the town and could use our aid. Her name is Shaya.$B$BWhen you find her, heal her wounds, and then fortify her body with your spells. This will at least protect her from harm longer if she finds trouble. Return to me here after you've done your duty to Elune.";
			questFlags = 0x020;
			idealLevel = 4;
			minLevel = 2;
			zone = 141;
			rewardXp = 209;
			previousQuest = 5622;
			classAllowed=qClasses.Priest;
			raceAllowed=qRaces.Alliance;
		}
		public override void InitObjectives()
		{
			reward.Add( 16604, 1 );
			npcObjectives.Add( 12429, 1 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c ) { return BaseNPC.QDS( questOwner, c, this ); }
	}
	public class Returning_Home : BaseQuest
	{
		public Returning_Home() : base()
		{
			id = 5628;
			npcId = 3600;
			name = "Returning Home";
			desc = "Speak to Priestess Alathea in Darnassus.";
			details = "Ah, yes, hello, $N? I'm glad you stopped to talk for a moment. You are a far way from home at such a young age--I admire such ambition. I wish when I was younger I could have mustered the courage to travel the world.$B$BThere was a priestess of your order here looking for you not too long ago. She said it was very urgent you returned to the Temple of the Moon in Darnassus and speak to Priestess Alathea--it had something to do with your training. I wouldn't dally too long if you can help it.";
			questFlags = 0x020;
			idealLevel = 10;
			minLevel = 5;
			zone = 141;
			rewardXp = 418;
			finishDialog = "Wonderful, you've returned home, $N. It always pleases Tyrande and myself when those we've trained go out into the world and return to us safely. How have things been with you? Does Elune still bless your travels? Perhaps after we speak more about the business at hand, you could tell me more of your travels.";
			classAllowed=qClasses.Priest;
			raceAllowed=qRaces.Alliance;
			npcTargetId = 11401;
		}
		public override void InitObjectives()
		{
			rewardSpell = 10797;
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c ) { return BaseNPC.QDS( questOwner, c, this ); }
	}
}
