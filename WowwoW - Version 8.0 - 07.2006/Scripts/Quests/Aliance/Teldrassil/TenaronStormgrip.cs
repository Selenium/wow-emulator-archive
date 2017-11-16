using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
	public class Crown_of_the_Earth2 : BaseQuest
	{
		public Crown_of_the_Earth2() : base()
		{
			id = 921;
			npcId = 3514;
			name = "Crown of the Earth";
			desc = "Fill the Crystal Phial and bring it back to Tenaron Stormgrip atop Aldrassil.";
			details = "It is time for you to set out to seek your destiny, $N. But before you are ready to set out into the world beyond our enchanted forests, there is much you must learn about our recent history.Much has changed with our people since the Battle of Mount Hyjal. Nordrassil lies a pale shadow of what it once was, its power used to defeat Archimonde and drive back the Burning Legion...There is a task you must perform. Go to the moonwell north of Aldrassil and return me a phial of its water.";
			questFlags = 0x020;
			idealLevel = 3;
			minLevel = 1;
			zone = 141;
			rewardXp = 98;
			finishDialog = "So you have heard the first part of the aftermath of the Battle of Mount Hyjal. There is much more to be told and the task you have begun here will continue through the rest of your journey through Teldrassil and into Darnassus.";
			progressDialog = "The moonwells hold the waters of the Well of Eternity the ancient source of magic that has wrought so many horrors upon our world.The druids take advantage of its properties, and the Sentinels revere the wells as shrines to Elune, but sorcery is forbidden to all.Required items: Filled Crystal Phial ";
			questIsBugged = true;
			raceAllowed=qRaces.Alliance;
		}
		public override void InitObjectives()
		{
			deliveryObjectives.Add( 5184, 1 );
		}
		public override void OnAcceptQuest( Character c )
		{
			c.PutObjectInBackpack( World.CreateItemInPoolById(5185), true );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );
		}
	}
	public class Crown_of_the_Earth3 : BaseQuest
	{
		public Crown_of_the_Earth3() : base()
		{
			id = 928;
			name = "Crown of the Earth";
			desc = "Bring the Partially Filled Vessel to Corithras Moonrage in Dolanaar.";
			details = "While there is more I could speak to you of the moonwells and of Teldrassil, I must send you along. Corithras Moonrage will be expecting you. I have poured the phial of water you brought to me into this vessel to bring to him.Seek out Corithras. You will find him at the moonwell in Dolanaar. Follow the road south from Aldrassil out of Shadowglen, and continue to follow the cobblestones as the road turns west.Mind you stay on the road though, $N. There are dangerous beasts in the forests of late.";
			questFlags = 0x020;
			idealLevel = 4;
			minLevel = 2;
			zone = 141;
			rewardXp = 100;
			finishDialog = "Ah, I see. You were sent by Tenaron. Well then, it would seem we have much to talk about, much to do, and little time to do it in.I think we'd best get started. ";
			progressDialog = "Greetings. For what purpose do I owe the pleasure of our meeting?Required items: Partially Filled Vessel";
			npcTargetId = 3515;
			previousQuest = 921;
			questIsBugged = true;
		}
		public override void InitObjectives()
		{
			deliveryObjectives.Add( 5188, 1 );
		}
		public override void OnAcceptQuest( Character c )
		{
			c.PutObjectInBackpack( World.CreateItemInPoolById(5186), true );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );
		}
	}
}
