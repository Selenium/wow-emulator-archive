using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
    public class Dolanaar_Delivery : BaseQuest
    {
        public Dolanaar_Delivery() : base()
        {
            id = 2159;
           	npcId = 6780;
            name = "Dolanar Delivery";
            desc = "Bring the Dolanaar Delivery to Innkeeper Keldamyr.";
            details = "Greetings, young $C. Can you offer me aid? I have a package of herbs that I must deliver to the town of Dolanaar. But I still have business with the druids of Shadowglen and cannot yet leave./n/nCan you deliver this package for me? It must be sent to Innkeeper Keldamyr, at the Dolanaar inn. It lies along the road, to the south.";
            questFlags = 0x020;
            idealLevel = 5;
            minLevel = 5;
            zone = 141;
            rewardXp = 277;
            finishDialog = "Ah yes, the delivery of herbs from Shadowglen. It is a shame Porthannius could not bring it himself, for we have much to discuss, he and I. But I am glad to get the herbs nontheless, and I am glad you came./n/n While you are here, please, rest yourself. Heroes must keep their strength and spirits high, and must find rest and solace whenever they may. For to neglect one's peace of body and mind is a sure path to failure./n/n So... rest.";
            progressDialog = "Good day. How might I be of service to you, young one? Are you here to rest in the inn? Do you require a heartstone?";
            raceAllowed=qRaces.Alliance;
            npcTargetId = 6781;
        }
        public override void InitObjectives()
        {
            deliveryObjectives.Add( 7627, 1 );
            rewardChoice.Add( 159, 5 );
			rewardChoice.Add( 2070, 5 );
        }
        public override void OnAcceptQuest(Character c)
        {
            c.PutObjectInBackpack(World.CreateItemInPoolById(7627), true);
        }
        public override DialogStatus QuestStatus(Mobile questOwner, Character c)
        {
            return BaseNPC.QDS(questOwner, c, this);
        }
    }
}
