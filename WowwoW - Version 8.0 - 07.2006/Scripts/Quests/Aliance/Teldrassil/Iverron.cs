using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
    public class A_Freind_in_Need : BaseQuest
    {
        public A_Freind_in_Need() : base()
        {
            id = 3519;
            npcId = 8584;
            name = "A Freind in Need";
            desc = "Speak to Dirania Silvershine in Shadowglen.";
            details = "Ughhh... I was bitten very badly by a spider named Githyiss the Vile while exploring the spider cave very close to here. I am sure I have been seriously poisoned; you must help me./n/nPlease tell Dirania Silvershine. She will be able to help me./n/nHurry... I'm so dizzy...";
            questFlags = 0x020;
            idealLevel = 4;
            minLevel = 2;
            zone = 188;
            finishDialog = "Oh, You Bring Iverron's answer.";
            previousQuest = 4495;
            npcTargetId = 8583;
            raceAllowed=qRaces.Alliance;
        }
        public override DialogStatus QuestStatus(Mobile questOwner, Character c)
        {
            return BaseNPC.QDS(questOwner, c, this);
        }

    }
}
