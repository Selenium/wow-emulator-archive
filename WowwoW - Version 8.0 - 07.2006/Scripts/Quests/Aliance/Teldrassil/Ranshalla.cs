using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
	public class Guardians_of_the_Altar : BaseQuest
    {
        public Guardians_of_the_Altar() : base()
        {
            id = 4901;
            npcId = 10300;
            name = "Guardians of the Altar";
            desc = "Just go back and Speak with Erelas Ambersky. - Protect Ranshalla while she attempts to reactivate the Altar of Elune. Report your findings to Erelas Ambersky in Rut'theran Village.";
            details = "At the very top of the ridge lies what I believe to be an altar of the goddess Elune. From what I can tell, we need to light the five torches in each cave, and then we will be able to access the altar directly. I transcribed some incantations carved into the stone in the ancient ruins of Kel'Theril, which I believe are the secret to unlocking the altar. I'll need your help to light each torch, while I recite the spell. If we are successful, you'll be able to report our findings to Erelas!";
            questFlags = 0x020;
            idealLevel = 59;
            minLevel = 57;
            zone = 618;
            rewardXp = 4800;
            finishDialog = "I hope Ranshalla didn't injured";
            progressDialog = "Rush!";
            previousQuest = 979;
            npcTargetId = 7916;
        }
        public override DialogStatus QuestStatus(Mobile questOwner, Character c)
        {
            return BaseNPC.QDS(questOwner, c, this);
        }
    }
}
