using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
	public class Princess_Must_Die  : BaseQuest
	{
		public Princess_Must_Die() : base()
		{
			id = 88;
			npcId = 244;
			name = "Princess Must Die! ";
			desc = "Kill Princess, grab her collar, then bring it back to Ma Stonefield at the Stonefield Farm.";
			details = "The Brackwells have a prize-winning pig, Princess. The sow is HUGE, and she got that way from sneaking over here and eating my veggies!\n\nSo before she comes to our fields...Princess must die! Bring me her collar as proof of the deed and I'll give you something for your time!\n\nPrincess is usually over at the Brackwell Pumpkin Patch, to the east and beyond the Maclure farm. Get her before she gets hungry and comes back here!";
			questFlags = 0x020;
			idealLevel = 9;
			minLevel = 6;
			zone = 9;
			rewardXp = 775;
			finishDialog= "Thank goodness! That pig was getting so big she'd have eaten our whole crop! Thank you, $N. \n\nNow, do either of these suit you?";
		}
		public override void InitObjectives()
		{
			rewardChoice.Add( 1173, 1 );
			rewardChoice.Add( 11191, 1 );
			rewardChoice.Add( 1182, 1 );
			npcObjectives.Add( 330, 1 );
			deliveryObjectives.Add( 1006, 1 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
	}
}