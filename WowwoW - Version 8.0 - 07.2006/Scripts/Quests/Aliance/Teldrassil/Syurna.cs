using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
    public class Destiny_Calls : BaseQuest
    {
        public Destiny_Calls() : base()
        {
            id = 2242;
            npcId = 4163;
            name = "Destiny Calls";
            desc = "Find Sethir the Ancient and bring back any clues that you may discover to Syurna.";
            details = "We believe there is one being that may be able to help us understand what is happening to the forests of Teldrassil. Unfortunately, getting the creature to cooperate has proven disastrous./n/nHe hides on a branch at the outskirts of the Oracle Glade. All who have so far approached the satyr, whether through force or diplomacy, have met with doom. Perhaps stealth is the answer, $N. /n/n Find what Sethir the Ancient carries in his packs and report back to me.";
            questFlags = 0x020;
            idealLevel = 10;
            minLevel = 9;
            zone = 141;
            rewardXp = 564;
            finishDialog = "Ah yes, the Setrihl's Journal from Teldrassil.";
            progressDialog = "You have something for me?";
            classAllowed=qClasses.Rogue;
			raceAllowed=qRaces.Alliance;
        }
        public override void InitObjectives()
        {
            deliveryObjectives.Add( 7737, 1 );
            rewardChoice.Add( 7298, 1 );
        }
        public override DialogStatus QuestStatus(Mobile questOwner, Character c)
        {
            return BaseNPC.QDS(questOwner, c, this);
        }
    }
}
