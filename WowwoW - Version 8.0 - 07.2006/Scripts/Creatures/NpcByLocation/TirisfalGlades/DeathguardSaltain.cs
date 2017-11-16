using System;
using Server.Items;
using HelperTools;

namespace Server.Creatures
{
	public class DeathguardSaltain : BaseNPC
	{
		public DeathguardSaltain() : base()
		{
			Name = "Deathguard Saltain";
			Id = 1740;
			Model = 3523;
			Level = RandomLevel(7);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 3*Level;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x08480046;
			BaseMana = 0;
			BoundingRadius = 0.561000f;
			CombatReach = 0.12f;
			Size = 1f;
			Speed = 3.0f;
			WalkSpeed = 3.0f;
			RunSpeed = 6.0f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Horde;
			AIEngine = new StandingNpcAI( this );
			NpcType = 6;
			NpcFlags = (int)NpcActions.Dialog;
			Equip( new Item( 7428, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ) ); 
			BCAddon.Hp( this, 250, 7 );
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD , 100f )};
		}
	}
}

