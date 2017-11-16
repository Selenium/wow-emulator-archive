using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
	public class Training_the_Beast : BaseQuest
	{
		public Training_the_Beast() : base()
		{
			id = 6103;
			npcId = 3601;
			name = "Training the Beast";
			desc = "Speak to Jocaste in the Cenarion Circle, in Darnassus.";
			details = "You now have the power to tame a pet, but you must also gain the skills to train it.$B$BTravel to Darnassus. There you must speak to one of our most revered hunters, Jocaste. She will give you the ability to train your new pet, so make haste.$B$BWhile Jocaste may seem stern, she is always pleased to see another hunter rising through the ranks. Treat her with respect and she will return in kind. Good luck, $N.";
			questFlags = 0x020;
			idealLevel = 10;
			minLevel = 5;
			zone = 141;
			rewardXp = 418;
			finishDialog = "A fledgling $C, I see. Yes, I can bestow you with the skills you need to train and guide your pet. Not only will you be able to teach your pet new abilities, you will now be able to feed your pet, as well as revive it, should it fall in battle.$b$bRemember, Snowdogchar, always respect the balance and live in awe of nature around you. Now, go forth. We shall speak again, at a later date.";
			classAllowed=qClasses.Hunter;
			raceAllowed=qRaces.Alliance;
			npcTargetId = 4146;
			questIsBugged = true;
		}
		public override void InitObjectives()
		{
			rewardSpell = 23357; // also Reward( 5149 ) ??
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c ) 
		{
			return BaseNPC.QDS( questOwner, c, this ); 
		}
	}
}
