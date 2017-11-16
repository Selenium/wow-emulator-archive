using Server.Items;
using Server.Creatures;

namespace Server.Quests
{	
	public class Zenn_s_Bidding : BaseQuest
	{
		public Zenn_s_Bidding() : base()
		{
			id = 488;
			npcId = 2150;
			name = "Zenn's Bidding";
			desc = "Bring Zenn Foulhoof outside of Dolanaar 3 Nightsaber Fangs, 3 Strigid Owl Feathers and 3 swatches of Webwood Spider Silk.";
			details = "Eager for work, I see.  Lucky for you a day never goes by that I don't wish I had a fledgling $C to perform my bidding.$B$BYou see, $N, I can make you very happy and provide you with things you never dreamed of having.  But in order for that to happen you must bring me certain items.$B$BMy business in the forest often requires certain. . .reagents.  Fetch for me 3 Nightsaber Fangs, 3 Strigid Owl Feathers and 3 swatches of Webwood Spider Silk.$B$BLet's keep this our little secret, $R.";
			questFlags = 0x020;
			idealLevel = 5;
			minLevel = 3;
			zone = 141;
			rewardXp = 256;
			rewardGold = 100;
			finishDialog = "Ha ha! Well, done indeed.$b$bWho would have ever guessed that I, Zenn Foulhoof, would have a $R to do my bidding? Certainly not me! But so it goes... this beloved world of ours is full of surprises.$b$bThree cheers for the naive and gullible!";
			progressDialog = "Have you been a busy little bee, $N? I've been waiting for you to bring me what I need.";
			raceAllowed=qRaces.Alliance;
		}
		public override void InitObjectives()
		{
			reward.Add( 5457, 5 );
			deliveryObjectives.Add( 3409, 3 );
			deliveryObjectives.Add( 3411, 3 );
			deliveryObjectives.Add( 3412, 3 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c ) { return BaseNPC.QDS( questOwner, c, this ); }
	}
}
