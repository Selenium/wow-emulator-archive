using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
	public class Patrolling_Westfall  : BaseQuest
	{
		public Patrolling_Westfall() : base()
		{
			id = 102; 
			npcId = 821;
			name = "Patrolling Westfall";
			desc = "Bring 8 Gnoll Paws to Captain Danuvin on Sentinel Hill.";
			details = "Stormwind has abandoned us. A foul wind of depravity rustles through the plains of Westfall. This was my homeland and I will not turn my back on the citizens who choose to remain here. We, the former farmers, shall make our stand./n/nYour task, should you choose to accept, is to patrol the grasslands of Westfall. Track down and slay the vile Gnolls that seem to be working in conjunction with the Deadmines thieves. Bring me eight Gnoll Paws and I will reward your bravery.";
			questFlags = 0x020;
			idealLevel = 14;
			minLevel = 9;
			zone = 108;
			finishDialog = "Well done, $N. With valiant adventurers such as yourself fighting alongside The People's Militia, Westfall just might return to the prosperous breadbasket it once was. Please accept this in recognition of your tireless efforts. ";
			progressDialog = "Have you collected 9 paws from those treacherous Gnolls yet? ";
			rewardXp= 1800;
		}
		public override void InitObjectives()
		{
			deliveryObjectives.Add( 725 , 8 );
			rewardChoice.Add( 1154, 1 );
			rewardChoice.Add( 710, 1 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
	}
}