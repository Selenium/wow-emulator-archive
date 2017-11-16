using System;
using Server.Items;
using HelperTools;


namespace Server.Creatures
{
	public class GerardTiller : BaseNPC
	{
		public GerardTiller() : base()
		{
			Name = "Gerard Tiller";
			Id = 255;
			Model = 3324;
			Level = RandomLevel(6);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 1500;
			Armor = 20;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x08480046;
			BaseMana = 0;
			BoundingRadius = 0.420f;
			CombatReach = 1.2f;
			Size = 1f;
			Speed = 2.9f;
			WalkSpeed = 2.9f;
			RunSpeed = 5.9f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this );
			NpcType = 7;
			NpcFlags = (int)NpcActions.Dialog ; 
			Equip( new Item( 7483, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ), new Item( 1684, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 )  ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA , 100f ) };
			/*****************************/
			BCAddon.Hp( this, 95, 6 );
			/*****************************/
		}
	}
}

