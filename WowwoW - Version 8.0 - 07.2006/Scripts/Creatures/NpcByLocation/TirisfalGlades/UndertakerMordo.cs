using System;
using Server.Items;
using HelperTools;

namespace Server.Creatures
{
	public class UndertakerMordo : BaseNPC
	{
		public UndertakerMordo() : base()
		{
			Name = "Undertaker Mordo";
			Id = 1568;
			Model = 1582;
			Level = RandomLevel(5);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 3*Level;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x08000066;
			BaseMana = 0;
			BoundingRadius = 0.561000f;
			CombatReach = 0.12f;
			Size = 1f;
			Speed = 3.0f;
			WalkSpeed = 3.0f;
			RunSpeed = 6.0f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this );
			NpcType = 6;
			NpcFlags = (int)NpcActions.Dialog;
			Equip( new Item( 7461, InventoryTypes.MainGauche, 2, 14, 1, 7, 0, 0, 0 ) ); 
			BCAddon.Hp( this, 190, 5 );
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD , 100f )};
		}
	}
}

