using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
	public class Goretusk_Liver_Pie   : BaseQuest
	{
		public Goretusk_Liver_Pie() : base()
		{
			id = 22;
			npcId = 235;
			name = "Goretusk Liver Pie";
			desc = "Salma Saldean needs 8 Goretusk livers to make a Goretusk Liver Pie.";
			details = "The onions are peeled. The garlic is minced. The rosemary is crushed. The crust has been baked. The dill weed is chopped. The gravy is simmering. Now all I need for my famous meat pie are 8 Goretusk Livers.";
			questFlags = 0x020;
			idealLevel = 12;
			minLevel = 9;
			zone = 108;
			finishDialog = " The onions are peeled. The garlic is minced. The rosemary is crushed. The crust has been baked. The dill weed is chopped. The gravy is simmering. Now all I need for my famous meat pie are 8 Goretusk Livers!";
			progressDialog = "All I need for my famous meat pie are 8 Goretusk Livers!";
			rewardXp = 1500;
		}
		public override void InitObjectives()
		{
			reward.Add( 724, 3 );
			reward.Add( 2697, 1 );
			deliveryObjectives.Add( 723, 8 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
	}
}