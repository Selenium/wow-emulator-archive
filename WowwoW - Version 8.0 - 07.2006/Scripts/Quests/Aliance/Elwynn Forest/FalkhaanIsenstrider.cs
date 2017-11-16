using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
	public class Rest_and_Relaxation  : BaseQuest
	{
		public Rest_and_Relaxation() : base()
		{
			id = 2158;
			npcId = 6774;
			name = "Rest and Relaxation ";
			desc = "Speak with Innkeeper Farley at the Lion's Pride Inn.";
			details = "Every adventurer should rest when exhaustion sets in - and there is no finer place to get rest and relaxation than at the Lion's Pride Inn!\n\n My best friend, Innkeeper Farley, runs the Lion's Pride. If you tell him I sent you, he may give you the special discounted rates on food and drink.\n\nTo find the Lion's Pride Inn, travel south along the road from here -- you can't miss it!";
			questFlags = 0x020;
			idealLevel = 5;
			minLevel = 1;
			zone = 9;
			rewardXp = 15;
			npcTargetId = 295;
			finishDialog= "Rest and relaxation for the tired and cold... that's our motto! Please, take a seat by the fire and rest your weary bones. \n\nWould you like to try a sampling of some of our fine food and drink? ";
		}
		public override void InitObjectives()
		{
			rewardChoice.Add( 4656, 5 );
			rewardChoice.Add( 159, 5 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
	}
}