using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
    public class A_Troubling_Breeze  : BaseQuest
	{
		public A_Troubling_Breeze () : base()
		{
			id = 475;
			npcId = 2078;
			name = "A Troubling Breeze";
			desc = "Seek out Gaerolas Talvethren in Starbreeze Village.";
			details = "A troubling breeze blows through the forest./n/nGaerolas Talvethren serves as Great Warden to the hibernating Druids of the Talon in the Ban'ethil Barrow Den. His duty as the chosen protector of the Sleeping is to ensure their safety so that their pact with Ysera remains fulfilled./n/nBut word from Gaerolas is now delayed and I grow nervous. Travel east to Starbreeze Village and bring back a report from Gaerolas so that I can put my worries to rest, knowing my dreaming brethren slumber safely.";
			questFlags = 0x020;
			idealLevel = 6;
			minLevel = 6;
			zone = 141;
            rewardXp = 525;
            finishDialog = "Thank the forest spirits you are here! I knew Athridas would sense trouble and send help.";
            raceAllowed=qRaces.Alliance;
			npcTargetId = 2107;
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );
		}
    }
    public class The_Relics_of_Wakening : BaseQuest
    {
        public The_Relics_of_Wakening() : base()
        {
            id = 483;
            npcId = 2078;
            name = "The Relics of Wakening";
            desc = "Retrieve the Relics of Wakening and bring them to Athridas Bearmantle in Dolanaar.";
            details = "Gnarlpine invaders were seen ravaging the Ban'ethil Barrow Den to the west./n/nThe slumbering druids will be trapped in the Emerald Dream for eternity, unaware of their fate, unless we help. The delicate hibernation ritual cannot be broken without the Relics of Wakening./n/nJourney to the Den and retrieve the Raven Claw Talisman, Black Feather Quill, Sapphire of Sky, and Rune of Nesting. The druids store them in sacred chests. Return them to me and I will prepare the awakening ritual.";
            questFlags = 0x020;
            idealLevel = 9;
            minLevel = 9;
            zone = 141;
            rewardGold = 300;
            rewardXp = 1450;
            finishDialog = "The kidnapped Druids of the Talon will be forever trapped in the Emerald Dream if we cannot retrieve the Relics of Wakening from the Ban'ethil Barrow Den to the west. /n/nFor every minute we delay their fate comes one step closer to eternal doom.";
            previousQuest = 476;
            raceAllowed=qRaces.Alliance;
            questIsBugged = true;
        }
        public override void InitObjectives()
        {
            deliveryObjectives.Add( 3405, 1 );
			deliveryObjectives.Add( 3406, 1 );
			deliveryObjectives.Add( 3407, 1 );
			deliveryObjectives.Add( 3408, 1 );
            rewardChoice.Add( 9599, 1 );
			rewardChoice.Add( 9603, 1 );
        }
        public override DialogStatus QuestStatus(Mobile questOwner, Character c)
        {
            return BaseNPC.QDS(questOwner, c, this);
        }
    }
    public class Ursal_the_Mauler : BaseQuest
    {
        public Ursal_the_Mauler() : base()
        {
            id = 486;
            npcId = 2078;
            name = "Ursal the Mauler";
            desc = "Kill Ursal the Mauler and return to Athridas Bearmantle in Dolanaar.";
            details = "Now the time has come to save the Druids of the Talon. If we fail now, $N, they will be forever lost in sleep./n/nI shall prepare the Relics of Wakening and perform the ritual. For my work to take effect, the cursed beast responsible for this horrible situation must be slain. Only then will the ritual be complete./n/nIt was Ursal the Mauler who meddled with our brethren's calling and it is Ursal the Mauler who must now pay so they can be freed. Travel to Gnarlpine Hold in the southwest and slay him.";
            questFlags = 0x020;
            idealLevel = 10;
            minLevel = 12;
            zone = 141;
            finishDialog = "Oh, I see you kill him!";
            progressDialog = "Kill Ursa the Mauler and come here!";
            rewardXp = 585;
            previousQuest = 483;
            raceAllowed = qRaces.Alliance;
        }
        public override void InitObjectives()
        {
            npcObjectives.Add( 2039, 1 );
            rewardChoice.Add( 5459, 1 );
			rewardChoice.Add( 5587, 1 );
        }
        public override DialogStatus QuestStatus(Mobile questOwner, Character c)
        {
            return BaseNPC.QDS(questOwner, c, this);
        }
    }
}