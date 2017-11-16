using Server.Items;
using Server.Creatures;

namespace Server.Quests
{		
	public class The_Woodland_Protector1 : BaseQuest
	{
		public The_Woodland_Protector1() : base()
		{
			id = 458;
			npcId = 2077;
			name = "The Woodland Protector";
			desc = "Seek out the dryad known as Tarindrella.";
			details = "Thank goodness you are here, $C. Strange news has traveled to me through the whisperings of the forest spirits.$B$BThe mysterious woodland protector, Tarindrella, has returned to Shadowglen. The dryad's presence has not been felt in the forests of Kalimdor in years. Something is surely amiss if she has journeyed back to this land.$B$BSeek out Tarindrella and see what business she tends to in our grove. One of the Sentinels reported seeing her to the southwest of Aldrassil.";
			questFlags = 0x020;
			idealLevel = 1;
			minLevel = 1;
			zone = 188;
			rewardXp = 38;
			finishDialog = "I see you found me, young $R. Melithar is a wise $C to have sent you.";
			raceAllowed=qRaces.Alliance;
			npcTargetId = 1992;
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c ) 
		{ 
			return BaseNPC.QDS( questOwner, c, this ); 
		}
	}
}
