using System;
using Server.Items;
using HelperTools;


namespace Server.Creatures
{
	public class MillyOsworth : BaseNPC
	{
		public MillyOsworth() : base()
		{
			Name = "Milly Osworth";
			Id = 9296;
			Model = 8489;
			Level = RandomLevel(2);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = Level*15;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x08080066;
			BaseMana = 0;
			BoundingRadius = 0.420f;
			CombatReach = 1.2f;
			Size = 1f;
			Speed = 2.9f;
			WalkSpeed = 2.9f;
			RunSpeed = 5.9f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Alliance;
			AIEngine = new StandingNpcAI( this );
			NpcType = 7;
			NpcFlags = (int)NpcActions.Dialog ; 
			//Equip( new Item( 24930, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA , 100f ) };
			/*****************************/
			BCAddon.Hp( this, 95, 2 );
			/*****************************/
		}
	}
}
