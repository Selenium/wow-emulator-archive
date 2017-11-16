using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
    public class Gnarlpine_Corruption : BaseQuest
    {
        public Gnarlpine_Corruption() : base()
        {
            id = 476;
            npcId = 2107;
            name = "Gnarlpine Corruption";
            desc = "Return to Athridas Bearmantle in Dolanaar.";
            details = "The Gnarlpine tribe has been corrupted!/n/nThe once peaceful furbolgs have turned against the protectors of the forest. They ambushed me as I left for the Ban'ethil Barrow Den and proceeded to pillage Starbreeze Village. Ursal the Mauler, their chieftain, is using the evil powers of the Fel Moss to drive them mad./n/nI am too wounded to return to Athridas to bring him this grave news. The task is left to you, young $C. We can only hope that the deranged Gnarlpines have not made it to Ban'ethil yet!";
            questFlags = 0x020;
            idealLevel = 6;
            minLevel = 6;
            zone = 141;
            rewardGold = 126;
            rewardXp = 267;
            finishDialog = "By the stars! This is quite disturbing indeed!";
            //npcTargetId = 2078;
            previousQuest = 475;
            raceAllowed = qRaces.Alliance;
			questIsBugged = true;
        }
        public override DialogStatus QuestStatus(Mobile questOwner, Character c)
        {
            return BaseNPC.QDS(questOwner, c, this);
        }
    }
}
