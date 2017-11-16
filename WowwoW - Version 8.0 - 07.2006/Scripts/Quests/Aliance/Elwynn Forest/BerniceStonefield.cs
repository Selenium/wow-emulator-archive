using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
	public class Lost_Necklace  : BaseQuest
	{
		public Lost_Necklace() : base()
		{
			id = 85;
			npcId = 246;
			name = "Lost Necklace ";
			desc = "Speak with Billy Maclure.";
			details = "I lost my necklace, and think that guttersnipe Billy Maclure took it! He's usually scuttling like a rat around the Maclure vineyards east of here. \n\n Get my necklace back for me, and you'll warm an old widow's heart.";
			questFlags = 0x020;
			idealLevel = 6;
			minLevel = 6;
			zone = 9;
			npcTargetId = 247;
			finishDialog = "You lost a what? Well I didn't take no necklace, because I ain't no thief! \n\nI might know who did but...<grin>...I'm too hungry to remember.";
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
		
	}
	public class Back_To_Billy  : BaseQuest
	{
		public Back_To_Billy() : base()
		{
			id = 84;
			npcId = 246;
			name = "Back to Billy ";
			desc = "Bring the Pork Belly Pie to Billy Maclure at the Maclure Vineyards.";
			details = "Here you go. And when you give this pie to that Billy, you tell him I hope he chokes on it!";
			questFlags = 0x020;
			idealLevel = 6;
			minLevel = 6;
			zone = 9;
			rewardXp = 140;
			previousQuest = 86;
			npcTargetId =247; 
			finishDialog = "Mm, yum! This pie is the best! \n\nI think my memory is coming back to me...";
		}
		public override void InitObjectives()
		{
			deliveryObjectives.Add( 962, 1 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
		public override void OnAcceptQuest( Character c )
		{
			c.PutObjectInBackpack( new PorkBellyPie(), true );
		}
	}
}