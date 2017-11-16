using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
	public class The_Road_to_Darnassus : BaseQuest
	{
		public The_Road_to_Darnassus() : base()
		{	
			id = 487;
			npcId = 2151;
			name = "The Road to Darnassus";
			desc = "Slay 6 Gnarlpine Ambushers and return to Sentinel Amara Nightwalker outside of Dolanaar.";
			details = "The road to Darnassus must be kept safe. Travelers heading from Dolanaar to Darnassus have been reporting ruthless attacks by corrupted furbolgs from the Gnarlpine tribe. Important news and commerce travels to and from Darnassus by way of this road daily. We cannot afford to have a rogue band of heathens terrorizing people. Take up arms in the name of the sacred forest, $N. Their den lies somewhere below this vantage point. Slay 6 of these Gnarlpine ambushers and report back to me.";
			questFlags = 0x020;
			idealLevel = 8;
			minLevel = 6;
			zone = 141;
			rewardXp = 397;
			rewardGold = 225;
			finishDialog = "You have served the good people of Dolanaar and Darnassus well, brave druid. As a member of the Sentinel force of Teldrassil I salute your efforts.";
			progressDialog= "Are you ready..?";
		}
		public override void InitObjectives()
		{
			npcObjectives.Add( 2152, 6 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
	}
}
