using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
	public class Give_Gerard_A_Drink  : BaseQuest
	{
		public Give_Gerard_A_Drink() : base()
		{
			id = 16; //no id quest must be repeatable 
			npcId = 255;
			name = "Give Gerard a Drink ";
			desc = "Bring Gerard a Refreshing Spring Water";
			details = "Farming is thirsty work, and I'm always looking for refreshing spring water. \n\nIf you have any, then I'm willing to make a trade. ";
			questFlags = 0x020;
			idealLevel = 1;
			minLevel = 1;
			zone = 9;
			finishDialog = "Thanks, $N! And come back if you want to trade again.";
		}
		public override void InitObjectives()
		{
			reward.Add( 4536, 1 );
			deliveryObjectives.Add( 159, 1 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
	}
}