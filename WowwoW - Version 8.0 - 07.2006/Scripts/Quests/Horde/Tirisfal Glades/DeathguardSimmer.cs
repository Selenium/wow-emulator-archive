using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
	public class Fields_of_Grief_1 : BaseQuest
	{
		public Fields_of_Grief_1() : base()
		{
			id = 365;
			npcId = 1519;
			name = "Fields of Grief";
			desc = "Steal 10 pumpkins from the farm to the west, just north of Deathknell and take them to Apothecary Johaan in Brill.";
			details = "What have we here? You look like a fledgling C$. If you hope to prove yourself to The Dark Lady, you need to learn the ways of The Forsaken.\n\nTo the west you'll find a farm. Humans infest the land like mold on a rotting corpse. And worse yet, the Scarlet Crusade patrols nearby from their tower. Teach those scum a lesson and steal 10 of their precious pumpkins.\n\nOnce you have 10, take them to Apothecary Johaan in Brill.";
			questFlags = 0x020;
			idealLevel = 6;
			minLevel = 5;
			zone = 14;
			rewardXp = 625;
			finishDialog = "You have performed well, young $C. You are proving yourself to be quite an asset to The Dark Lady's army.";
			progressDialog=  "Deathguard Simmer sent word that you were going to provide me with some much needed reagents. Were you able to gather 10 pumpkins yet, N$? \n\nRequired items: 10 Tirisfal Pumpkins";
		}
		public override void InitObjectives()
		{
			deliveryObjectives.Add( 2846, 10 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
	}
}
