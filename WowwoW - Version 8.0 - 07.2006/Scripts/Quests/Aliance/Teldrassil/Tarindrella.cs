using Server.Items;
using Server.Creatures;

namespace Server.Quests
{	
	public class The_Woodland_Protector2 : BaseQuest
	{
		public The_Woodland_Protector2() : base()
		{
			id = 459;
			npcId = 1992;
			name = "The Woodland Protector";
			desc = "Collect 8 Fel Moss and bring them to Tarindrella.";
			details = "Something evil is brewing in the forests of Teldrassil.  Look long the hills to where the peaceful furbolgs used to dwell.  They have deserted their homes and are amassing under the name of the Gnarlpine tribe.$B$BOnly the corruption of wicked Fel Moss could cause such a transformation.  The grells and grellkin have infested the area and are threatening the residents of Shadowglen.  $B$BEngage these grells and grellkin, $N, and see if they are indeed caught under the enchantment of the wicked Fel Moss.";
			questFlags = 0x020;
			idealLevel = 3;
			minLevel = 1;
			zone = 141;
			rewardXp = 162;
			previousQuest = 458;
			finishDialog = "Your service to the creatures of Shadowglen is worthy of reward, $N.$b$bYou confirmed my fears, however. If the grells have become tainted by the Fel Moss, one can only imagine what has become of the Gnarlpine tribe of furbolgs who once lived here.$b$bShould you find yourself in Dolanaar, able $C, seek out the knowledgeable $C, Athridas Bearmantle. He shares our concern for the well being of the forest.";
			progressDialog = "Satisfy my suspicions, $N. Bring to me 8 Fel Moss.";
			raceAllowed=qRaces.Alliance;
		}
		public override void InitObjectives()
		{
			rewardChoice.Add( 5398, 1 );
			rewardChoice.Add( 5399, 1 );
			rewardChoice.Add( 11190, 1 );
			reward.Add( 961, 3 );
			deliveryObjectives.Add( 3297, 8 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c ) 
		{ 
			return BaseNPC.QDS( questOwner, c, this ); 
		}
	}
}
