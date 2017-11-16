using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
	public class Note_to_William  : BaseQuest
	{
		public Note_to_William() : base()
		{
			id = 107;
			npcId = 248;
			name = "Note to William ";
			desc = "Take Gramma Stonefield's Note to William Pestle.";
			details = "I bet William Pestle has a potion to unite our two young lovers!\n\nHere, take this note to William. He's staying at the Lion's Pride Inn in Goldshire.";
			questFlags = 0x020;
			idealLevel = 6;
			minLevel = 6;
			zone = 9;
			rewardXp = 500;
			previousQuest = 111;
			finishDialog = "You have a note from 'Gramma' Stonefield, eh? I haven't seen Mildred in years! I wonder what she has to say...\n\nMy heart goes out to those two poor souls, Maybell and Tommy Joe. I remember being young and in love, once. \n\nThere must be something I can do to help them! Let me think...";
			npcTargetId = 253; 
		}
		public override void InitObjectives()
		{
			deliveryObjectives.Add( 1252, 1 );
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
		public override void OnAcceptQuest( Character c )
		{
			c.PutObjectInBackpack( new GrammaStonefieldsNote(), true );
		}
	}
}