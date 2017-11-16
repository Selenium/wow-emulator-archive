using System;
using Server.Items;
using HelperTools;

namespace Server.Creatures
{
	public class CaptainGrayson : BaseNPC
	{
		public CaptainGrayson() : base()
		{
			Name = "Captain Grayson";
			Id = 392;
			Model = 1279;
			Level = RandomLevel(50);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 3*Level;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x066;
			BaseMana = 0;
			BoundingRadius = 0.561000f;
			CombatReach = 0.12f;
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Str = (int)(Level/2.5f);
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this );
			NpcType = 7;
			NpcFlags = (int)NpcActions.Dialog;
			BCAddon.Hp( this, 750, 50 );
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD , 100f )};
		}
	}
}

