using System;
using Server.Items;
using HelperTools;


namespace Server.Creatures
{
	public class Tarindrella : BaseNPC
	{
		public Tarindrella() : base()
		{
			Name = "Tarindrella";
			Id = 1992;
			Model = 10034;
			Level = RandomLevel(7);
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
			CombatReach = 2.5f;
			Size = 1f;
			Speed = 3.3f;
			WalkSpeed = 3.3f;
			RunSpeed = 6.3f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this );
			NpcType = 7;
			NpcFlags = (int)NpcActions.Dialog; 
			Equip( new Item( 8377, InventoryTypes.MainGauche, 2, 0, 1, 4, 0, 0, 0 ) );
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA , 100f ) };
			/*****************************/
			BCAddon.Hp( this, 100, 7 );
			/*****************************/
		}
	}
}
