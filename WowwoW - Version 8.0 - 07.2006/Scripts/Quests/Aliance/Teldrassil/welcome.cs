using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
	public class Welcome : BaseQuest
	{
		public Welcome() : base()
		{
			id = 5842;
			name = "Welcome!";
			desc = "Bring the Shadowglen Gift Voucher to Orenthil Whisperwind.";
			details = "Welcome to the World of Warcraft As special thanks for purchasing the World of Warcraft Collector's Edition, turn in this gift voucher to Orenthil Whisperwind in Shadowglen. You'll then be given a gift: a little companion to join you on your quest for adventure and glory. Thanks again, and enjoy your stay in the World of Warcraft!";
			questFlags = 0x020;
			idealLevel = 1;
			minLevel = 1;
			zone = 141;	
			npcTargetId = 11942;
		}
		public override void InitObjectives()
		{
			rewardChoice.Add( 13584, 1 );
			rewardChoice.Add( 13583, 1 );
			rewardChoice.Add( 13582, 1 );
			deliveryObjectives.Add( 14648, 1 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );
		}
	}
}
