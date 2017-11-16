using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
	public class Elmores_Task  : BaseQuest
	{
		public Elmores_Task() : base()
		{
			id = 1097;
			npcId = 514;
			name = "Elmore's Task ";
			desc = "Speak with Grimand Elmore.";
			details = "There's a dwarven weaponsmith in Stormwind, Grimand Elmore, who sent word that he needs help with a delivery. I believe he wants a package sent to his homeland in the north.\n\nYou have a sturdy pair on you! So if you're interested in some legwork then speak with Grimand. We could use you down here, but we must also keep our ties strong with the dwarves.\n\nYou can find Grimand Elmore at the weapon shop in the Dwarven District of Stormwind, in the northeast section of town.";
			questFlags = 0x020;
			idealLevel = 9;
			minLevel = 15;
			zone = 1;
			rewardXp = 180;
			npcTargetId = 1416;
			finishDialog = "You're here to help with my delivery? Very good!";
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
	}
}