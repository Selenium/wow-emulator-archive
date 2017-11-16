using Server.Items;
using Server.Creatures;

namespace Server.Quests
{
	public class Dungar_Longdrink   : BaseQuest
	{
		public Dungar_Longdrink () : base()
		{
			id = 6261; 
			npcId = 1323;
			name = "Dungar Longdrink";
			desc = "Bring Osric's Crate to Dungar Longdrink the gryphon master.";
			details = "$N, I gathered into this crate everything Lewis asked for. Can you take it to him?/n/nIf you've already spoken to Thor in Westfall, then you can take a gryphon back to him. Dungar Longdrink is our gryphon master, over in the trade district./n/nSpeak with Dungar, then get this crate to Lewis as fast as you can. We don't want our fighting men and women in Westfall to go without fresh equipment!";
			questFlags = 0x020;
			idealLevel = 10;
			minLevel = 10;
			zone = 1519;
			finishDialog = "A crate for Westfall, eh? Have you been to Westall before? If so, then it's no problem, my friend. I have plenty of gryphons trained to fly that route!";
			progressDialog = "Is that sweat on your brow, lad? You've been running too much. Next time, take a gryphon!";
			rewardXp= 210;
			previousQuest = 6281;
			npcTargetId = 352;
		}
		public override void InitObjectives()
		{
            deliveryObjectives.Add( 16115, 1 ); // ?			
		}
		public override DialogStatus QuestStatus( Mobile questOwner, Character c )
		{
			return BaseNPC.QDS( questOwner, c, this );		
		}
		public override void OnAcceptQuest( Character c )
		{
			c.PutObjectInBackpack( new OsricsCrate(), true );
		}
	}
}