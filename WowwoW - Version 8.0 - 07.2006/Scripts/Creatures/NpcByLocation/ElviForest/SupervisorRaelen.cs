using System;
using Server.Items;
using HelperTools;


namespace Server.Creatures
{
	public class SupervisorRaelen : BaseNPC
	{
		public SupervisorRaelen() : base()
		{
			Name = "Supervisor Raelen";
			Id = 10616;
			Model = 10995;
			Level = RandomLevel(15);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 1500;
			Armor = 20;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x08480006;
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
			//Equip( new Item( 12236, InventoryTypes.MainGauche, 2, 4, 2, 7, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA , 100f ) 
			,new BaseTreasure( SupervisorRaelenDrops.SupervisorRaelen , 100f ) };
			/*****************************/
			BCAddon.Hp( this, 165, 15 );
			/*****************************/
		}
	}
}

namespace Server.Items
{
public class SupervisorRaelenDrops
	{
		public static Loot[] SupervisorRaelen = new Loot[] {};
	}
}