using System;
using Server.Items;
using HelperTools;


namespace Server.Creatures
{
	public class Mist : BaseNPC
	{
		public Mist() : base()
		{
			Name = "Mist";
			Id = 3568;
			Model = 599;
			Level = RandomLevel(20);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = Level*15;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x0400066;
			BaseMana = 0;
			BoundingRadius = 0.420f;
			CombatReach = 2.5f;
			Size = 1f;
			Speed = 2.9f;
			WalkSpeed = 2.9f;
			RunSpeed = 6.9f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Darnasus;
			AIEngine = new PatrolAI( this );
			NpcType = 1;
			NpcFlags = (int)NpcActions.Dialog; 
			//Equip( new Item( 6443, (InventoryTypes)13, 2, 15, 1, 3, 0, 0, 0 ) );
			//Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB , 100f ) };
			/*****************************/
			BCAddon.Hp( this, 395, 20 );
			/*****************************/
		}
	}
}
