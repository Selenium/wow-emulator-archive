using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
	public class Poor_Old_Blanchy  : BaseQuest
	{
		public Poor_Old_Blanchy() : base()
		{
			id = 151; 
			npcId = 238;
			name = "Poor Old Blanchy ";
			desc = "Verna Furlbrow in Westfall wants you to bring her 8 Handfuls of Oats.";
			details = "Poor Old Blanchy! Such a tired beast after all the work we put her through. I fed her before we left the farm, but we weren't expecting the wagon to break on us. If you could bring her a few handfuls of oats from the fields, I'd be grateful./n/nI bet you could find some around all of the farms in Westfall, if you can steer clear of those horrific machines that have taken over. There are several farms southwest of here.";
			questFlags = 0x020;
			idealLevel = 14;
			minLevel = 9;
			zone = 108;
			finishDialog = "Thank you so much, $N! Poor Old Blanchy will be so happy! ";
			progressDialog = "Old Blanchy is on her last legs. Did yo happen to find any oats for her?";
			rewardXp= 1650;
		}
		public override void InitObjectives()
		{
			reward.Add( 2165, 1 );
			reward.Add( 1537, 1 );
			deliveryObjectives.Add( 1528, 1 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
	}
}