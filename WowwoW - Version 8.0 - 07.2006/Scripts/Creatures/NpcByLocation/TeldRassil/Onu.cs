using System;
using Server.Items;
using HelperTools;


namespace Server.Creatures
{
	public class Onu : BaseNPC
	{
		public Onu() : base()
		{
			Name = "Onu";
			Guild = "Ancient of Lore";
			Id = 3616;
			Model = 1455;
			Level = RandomLevel(55);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 4526;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x08400046;
			BaseMana = 0;
			BoundingRadius = 0.420f;
			CombatReach = 2.5f;
			Size = 1f;
			Speed = 3.3f;
			WalkSpeed = 3.3f;
			RunSpeed = 6.3f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Alliance;
			AIEngine = new StandingGuardAI( this );
			NpcType = 0;
			NpcFlags = (int)NpcActions.Dialog; 
//			Equip( new Item( 7428, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ) );
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD , 100f ) };
			/*****************************/
			BCAddon.Hp( this, 2110, 55 );
			/*****************************/
		}
	}
}
