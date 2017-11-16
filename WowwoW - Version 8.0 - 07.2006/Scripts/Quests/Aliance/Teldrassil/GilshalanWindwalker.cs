using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
	public class Webwood_Venom : BaseQuest
	{
		public Webwood_Venom() : base()
		{
			id = 916;
			npcId = 2082;
			name = "Webwood Venom";
			desc = "Bring 10 Webwood Venom Sacs to Gilshalan Windwalker at Aldrassil.";
			details = "I came to Shadowglen to observe the webwood spiders that dwell in the Shadowthread Cave. They are cousin to a much smaller variety of spider; I believe the world tree has had a profound effect on them, and I would like specimens to study to confirm this. First, I would like some of their venom. Gather Webwood venom sacs from the spiders in and around the Shadowthread Cave, to the north. I can then examine them for similarities with their smaller cousin's venom.";
			questFlags = 0x020;
			idealLevel = 4;
			minLevel = 2;
			zone = 141;
			rewardXp = 525;
			finishDialog = "Thank you. When I return to Darnassus I will compare the venom within these sacs with the venom of other spiders. It is my belief that it will have the properties linked to the recent growth of our new world tree. ";
			progressDialog= "Did you gather the venom sacs?";
			raceAllowed=qRaces.Alliance;
		}
		public override void InitObjectives()
		{
			deliveryObjectives.Add( 5166, 10 );
			rewardChoice.Add( 1386, 1 );
			rewardChoice.Add( 5392, 1 );
			rewardChoice.Add( 5393, 1 );
			rewardChoice.Add( 5586, 1 );
			rewardChoice.Add( 10544, 1 );
			rewardChoice.Add( 12447, 1 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );
		}
	}
	public class Webwood_Egg : BaseQuest
	{
		public Webwood_Egg() : base()
		{
			id = 917;
			npcId = 2082;
			name = "Webwood Egg";
			desc = "Bring a Webwood Egg to Gilshalan in Aldrassil.";
			details = "Now that I have the spiders' venom, I'd like some live specimens to study. Unfortunately, capturing a living, giant spider is more than I can ask of you, young <Class>. And a giant spider is more than I could handle myself! But if you can find an unhatched egg, then delivering specimens will be much easier, and I can then arrange for the unhatched spiders to be contained. There must be a nest deep in the Shadowthread Cave. Please, search for an egg in the nest and return it to me.";
			questFlags = 0x020;
			idealLevel = 5;
			minLevel = 2;
			rewardXp = 277;
			zone = 141;
			finishDialog = "Ah, very good. I will have this egg and the venom transported to Darnassus, then return there when my studies are done here. I expect to find out a great deal from these specimens. You have been a great help to me.";
			progressDialog= "Have you been inside the Shadowthread Cave? Did you find a spider egg? ";
			previousQuest = 916;
			questIsBugged = true;
			raceAllowed=qRaces.Alliance;
		}
		public override void InitObjectives()
		{
			deliveryObjectives.Add( 5167, 1 );
			rewardChoice.Add( 5395, 1 );
			rewardChoice.Add( 4907, 1 );
			rewardChoice.Add( 11189, 1 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );
		}
	}
	public class Tenarons_Summons  : BaseQuest
	{
		public Tenarons_Summons() : base()
		{
			id = 920;
			npcId = 2082;
			name = "Tenarons Summons";
			desc = "Speak with Tenaron Stormgrip atop Aldrassil in Shadowglen.";
			details = "$N, is it? I heard that Tenaron has been asking for you. You'll find him in the highest room atop Aldrassil. We may live long lives, but it's best you not keep him waiting too long.";
			questFlags = 0x020;
			idealLevel = 5;
			minLevel = 3;
			zone = 141;
			rewardXp = 205;
			finishDialog = "Ah. I was hoping you'd be prompt in answering my summons. I have an important task that I would like you to perform.";
			previousQuest = 917;
			npcTargetId = 3514;
			raceAllowed=qRaces.Alliance;
		}
		public override void InitObjectives()
		{
			rewardChoice.Add( 5395, 1 );
			rewardChoice.Add( 4907, 1 );
			rewardChoice.Add( 11189, 1 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );
		}
	}
}
