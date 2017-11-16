using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
	public class Scavenging_Deathknell : BaseQuest
	{
		public Scavenging_Deathknell() : base()
		{
			id = 3902;
			npcId = 1740;
			name = "Scavenging Deathknell";
			desc = "Search Deathknell and the vicinity for 6 pieces of Scavenged Goods, and return them to Deathguard Saltain.";
			details = "You there! If you're looking for something to make yourself useful, then listen up!\n\nWe need fresh out-of-the-ground recruits to head into Deathknell and search for any sort of useful equipment that we make use of. Most likely, they'll be in stacks of boxes. We expect more recruits to be rising soon, and unless we want them to stumble about naked we had better get to scavenging!\n\nWell get to work, you miserable bag of bones! I'm not going to reward those without some hustle.";
			questFlags = 0x020;
			idealLevel = 3;
			minLevel = 2;
			zone = 14;
			rewardXp = 320;
			progressDialog =  "Have you managed to scavenge up some useful items for us? There is no shame in reusing that which has been tossed aside. No one is going to give us any handouts - we Forsaken will fend for ourselves! \n\nRequired items: 6 Scavenged Goods";
			finishDialog = 	"Great work $N, I knew you weren't useless. Here - have one of the better items I've found out of the lots that have been collected so far.";
		}
		public override void InitObjectives()
		{
			rewardChoice.Add( 11848, 1 );
			rewardChoice.Add( 11849, 1 );
			rewardChoice.Add( 11850, 1 );
			deliveryObjectives.Add( 11127, 6 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
	}
}