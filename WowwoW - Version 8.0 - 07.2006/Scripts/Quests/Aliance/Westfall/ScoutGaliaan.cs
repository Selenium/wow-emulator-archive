using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
	public class Red_Leather_Bandanas   : BaseQuest
	{
		public Red_Leather_Bandanas() : base()
		{
			id = 153; 
			npcId = 878;
			name = "Red Leather Bandanas";
			desc = "Bring 15 red leather bandanas to Scout Galiaan at Sentinel Hill.";
			details = "The Defias Front is constantly shifting. I've been following their movements for quite some time now. On a side note, I've ascertained that many members of the gang can be tracked by the Red Leather Bandanas they wear./n/nBring me 15 of these Bandanas and I'll see to it you are rewarded.";
			questFlags = 0x020;
			idealLevel = 15;
			minLevel = 15;
			zone = 108;
			finishDialog = "Nice work, $R. Please accept one of these items as payment for all your hard work.";
			progressDialog = "Bring me 15 red leather bandanas and I'll pay you well.";
			rewardXp = 3000;
		}
		public override void InitObjectives()
		{
			deliveryObjectives.Add( 829, 15 );
			rewardChoice.Add( 3511, 1 );
			rewardChoice.Add( 5944, 1 );
			rewardChoice.Add( 12295, 1 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
	}
}