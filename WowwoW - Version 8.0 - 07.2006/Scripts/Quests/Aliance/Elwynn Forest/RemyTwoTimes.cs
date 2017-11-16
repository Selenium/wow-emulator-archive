using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
	public class A_Fishy_Peril  : BaseQuest
	{
		public A_Fishy_Peril() : base()
		{
			id = 40;
			npcId = 241;
			name = "A Fishy Peril ";
			desc = "Remy 'Two Times' wants you to speak with Marshal Dughan in Goldshire.";
			details = "$N, there's a new threat in Elwynn Forest! Murlocs are swimming up the streams of eastern Elwynn, scaring away fish and attacking gentle folk!\n\nI warned Marshal Dughan, but he's more worried about the gnolls and the bandits. He's not convinced that the murlocs are a danger.\n\nPlease, <Name>, speak to Dughan and persuade him to send more troops to the east!";
			questFlags = 0x020;
			idealLevel = 10;
			minLevel = 6;
			zone = 9;
			npcTargetId = 240;
			finishDialog = " Yes, I spoke with Remy. I respect him as a merchant, though all reports of Murlocs to the east have been sketchy at best.\n\nYour concerns are noted, but unless I receive a military report of a murloc threat, we can't afford to send more troops east.";
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
	}
	public class Gold_Dust_Exchange  : BaseQuest
	{
		public Gold_Dust_Exchange() : base()
		{
			id = 47;
			npcId = 241;
			name = "Gold Dust Exchange";
			desc = "Bring 10 Gold Dust to Remy 'Two Times' in Goldshire. Gold Dust is gathered from Kobolds in Elwynn Forest.";
			details = "The Kobolds in these parts sometimes carry Gold Dust on them. I could really use the stuff - bring me a load of it and I'll give you the best price in town...best price in town!\n\nYou can find kobolds in the Fargodeep Mine to the south, and around the Jasperlode Mine to the northeast.";
			questFlags = 0x020;
			idealLevel = 7;
			minLevel = 5;
			zone = 9;
			rewardGold = 175;
			rewardXp = 675;
			finishDialog = "Thanks for the dust, $N. Here's your cash, and...here is a token from associates of mine. You might find it useful...useful.";
			progressDialog = "Psst! You have that Gold Dust for me...for me?";
		}
		public override void InitObjectives()
		{
			reward.Add( 1191, 1 );
			deliveryObjectives.Add( 773, 10 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
	}
}