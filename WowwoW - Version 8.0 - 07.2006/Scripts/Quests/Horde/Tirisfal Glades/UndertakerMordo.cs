using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
	public class Rude_Awakening : BaseQuest
	{
		public Rude_Awakening() : base()
		{
			id = 363;
			npcId = 1568;
			name = "Rude Awakening";
			desc = "Speak with Shadow Priest Sarvis.";
			details = "About time you woke up. We were ready to toss you into the fire with the others, but it looks like you made it.\n I am Mordo, the caretaker of the crypt of Deathknell. And you are the Lich King's slave no more.\n Speak with Shadow Priest Sarvis in the chapel at the base of the hill, he will tell you more of what you must know.";
			questFlags = 0x020;
			idealLevel = 1;
			minLevel = 1;
			zone = 14;
			npcTargetId = 1569;
			rewardXp = 40;
			finishDialog = "Another of the walking dead, hm? Must have been quite a shock, waking up in the crypt with only the cold and Mordo to greet you... \nI see the confusion on your face. Let me try to explain our... situation... to you. \nWe have been freed from the control of the Lich King by our new leader. Lady Sylvanas. The Dark Lady guides us in our war against the hated Scourge and the holdouts of humanity who dog our every step.";
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
	}
}
	
	