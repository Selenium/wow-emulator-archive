using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
	public class The_Apple_Falls : BaseQuest
	{
		public The_Apple_Falls() : base()
		{
			id = 2241;
			npcId = 3599;
			name = "The Apple Falls";
			desc = "Take Jannok's Rose to Syurna in Darnassus.";
			details = "They say I'm 'lovestruck,' whatever that means.$B$BSure, I spend my every waking moment thinking about Syurna. Sure, my home is full of paintings and drawings of Syurna. Sure, I often go days without eating, sleeping, or drinking, while I lament about the love we could have had. Is that so wrong?$B$BNow she won't see me! ME! I've tried sending her messages but she won't even talk to another person unless they are a rogue.$B$BCould you deliver this flower to her? Don't forget to tell her it's from Jannok.";
			questFlags = 0x020;
			idealLevel = 10;
			minLevel = 5;
			zone = 141;
			rewardXp = 522;
			classAllowed=qClasses.Rogue;
			raceAllowed=qRaces.Alliance;
			npcTargetId = 4163;
		}
		public override void InitObjectives()
		{
			deliveryObjectives.Add( 7735, 1 );
		}
		public override void OnAcceptQuest(Character c)
		{
			c.PutObjectInBackpack( World.CreateItemInPoolById(7735), 1, true);
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c ) 
		{ 
			return BaseNPC.QDS( questOwner, c, this ); 
		}
	}
}
