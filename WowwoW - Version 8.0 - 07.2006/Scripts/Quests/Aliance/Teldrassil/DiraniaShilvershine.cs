using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
    public class A_Good_Friend : BaseQuest
    {
        public A_Good_Friend() : base()
        {
            id = 4495;
            npcId = 8583;
            name = "A Good Friend";
            desc = "Find Iverron by the cave to the north.";
            details = "A friend of mine named Iverron usually visits me at the same time every day. The strange thing is that he hasn't been by today at all -- he's several hours late, in fact./n/nI admit, I am a little worried, $N. Iverron spends a lot of time over by the cave to the north, and I'm sure you know how dangerous it is there -- spiders, everywhere!/n/nIf you happen to be going that way, though, will you keep an eye out for him?";
            questFlags = 0x020;
            idealLevel = 4;
            minLevel = 2;
            zone = 141;
            rewardXp = 55;
            finishDialog = "Oh. You Find me. ";
            npcTargetId = 8584;
            raceAllowed=qRaces.Alliance;
        }
        public override DialogStatus QuestStatus(Mobile questOwner, Character c)
        {
            return BaseNPC.QDS(questOwner, c, this);
        }
    }
    public class Iverrons_Antidote1 : BaseQuest
    {
        public Iverrons_Antidote1() : base()
        {
            id = 3521;
            npcId = 8583;
            name = "Iverron's Antidote 1";
            desc = "Collect 7 Hyacinth Mushrooms, 4 Moonpetal Lilies, and 1 Webwood Ichor for Dirania Silveshine in Shadowglen.";
            details = "We may be able to help Iverron, as I know of an antidote that should help with the poison. It requires some ingredients, though, before I can make it./n/nI'll need Hyacinth mushrooms. You can find these growing under trees, or you may collect them from the grell south of here; they seem to have taken a liking to them. I'll also need Moonpetal lilies, which only grow around watery pools./n/nThe last ingredient may prove the most difficult. From the very spiders that poisoned Iverron, collect Webwood ichor.";
            questFlags = 0x020;
            idealLevel = 4;
            minLevel = 4;
            zone = 188;
            finishDialog = "Oh, You collect all of Hyacinth Mushrooms, Moonpetal Lilies and Webwood Ichor.";
            previousQuest = 3519;
            questIsBugged = true;
            raceAllowed=qRaces.Alliance;
        }
        public override void InitObjectives()
        {
			deliveryObjectives.Add( 10639, 7 );
			deliveryObjectives.Add( 10640, 1 );
			deliveryObjectives.Add( 10641, 4 );
		}
        public override DialogStatus QuestStatus(Mobile questOwner, Character c)
        {
            return BaseNPC.QDS(questOwner, c, this);
        }

    }
    public class Iverrons_Antidote2 : BaseQuest
    {
        public Iverrons_Antidote2() : base()
        {
            id = 3522;
            npcId = 8583;
            name = "Iverron's Antidote 2";
            desc = "Bring Iverron's Antidote to Iverron before the time limit is up. Iverron can be found by the cave to the north.";
            details = "The antidote is ready, $N. Please see that Iverron drinks it./n/nThere is something that you should know -- the antidote -- it will only remain viable for 5 minutes. You must get it to him in time./n/nSpeed be with you, $N.";
            questFlags = 0x020;
            idealLevel = 4;
            minLevel = 4;
            zone = 188;
            rewardXp = 286;
            finishDialog = "Oh, Thanks the antidote very much!";
            previousQuest = 3521;
            raceAllowed=qRaces.Alliance;
        }

        public override void InitObjectives()
        {
            deliveryObjectives.Add( 10642, 1 );
            rewardChoice.Add( 10655, 1 );
			rewardChoice.Add( 10656, 1 );
        }
        public override void OnAcceptQuest(Character c)
        {
            c.PutObjectInBackpack(World.CreateItemInPoolById(10642), true);
        }
        public override DialogStatus QuestStatus(Mobile questOwner, Character c)
        {
            return BaseNPC.QDS(questOwner, c, this);
        }

    }
}
