using System;
using System.Collections;
using Server;
using Server.Items;

namespace Server.Creatures
{
	public class HammerfallPeon : BaseCreature
	{
		public HammerfallPeon() : base()
		{
			Name = "Hammerfall Peon";
			Id = 2618;
			Model = 4030;
			Level = RandomLevel(33,34);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Flags1=0x080000;
			Armor = 18*Level;
			Block = 1*Level;
			BaseMana = 0;
			BoundingRadius = 0.3f;
			CombatReach = 1.5f;
			Size = 1f;
			Speed = 2.6f;
			WalkSpeed = 2.6f;
			RunSpeed = 5.6f;
			Faction = Factions.Horde;
			AIEngine = new DefensiveAnimalAI( this );
			NpcType = 7;
			Equip( new Item( 7428, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ) ); 
			/*****************************/
			BCAddon.Hp( this, 705, 33 );
			/*****************************/
			Loots = new BaseTreasure[]{  new BaseTreasure( PeonDrops.HammerfallPeon , 100f )
						, new BaseTreasure( Drops.MoneyB , 100f )};

		}
	}
} 




namespace Server.Creatures
{
	public class VentureCoPeon : BaseCreature
	{
		public VentureCoPeon() : base()
		{
			Name = "Venture Co. Peon";
			Id = 3285;
			Model = 7241;
			Level = RandomLevel(13,14);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Flags1=0x080000;
			Armor = 18*Level;
			Block = 1*Level;
			BaseMana = 0;
			BoundingRadius = 0.3f;
			CombatReach = 1.5f;
			Size = 1f;
			Speed = 2.0f;
			WalkSpeed = 2.0f;
			RunSpeed = 5.0f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 7;
			Equip( new Item( 7495, InventoryTypes.TwoHanded, 2, 6, 1, 2, 0, 0, 0 ) ); 
			/*****************************/
			BCAddon.Hp( this, 184, 13 );
			/*****************************/
			Loots = new BaseTreasure[]{  new BaseTreasure( PeonDrops.VentureCoPeon , 100f )
						, new BaseTreasure( Drops.MoneyA , 100f )};

		}
	}
} 



namespace Server.Creatures
{
	public class LazyPeon : BaseCreature
	{
		public LazyPeon() : base()
		{
			Name = "Lazy Peon";
			Id = 10556;
			Model = 10038;
			Level = RandomLevel(4);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Flags1=0x08080046;
			Armor = 18*Level;
			Block = 1*Level;
			BaseMana = 0;
			BoundingRadius = 0.2f;
			CombatReach = 1.2f;
			Size = 0.8f;
			Speed = 2.9f;
			WalkSpeed = 2.9f;
			RunSpeed = 5.9f;
			Faction = Factions.Ogrimmar;
			AIEngine = new DefensiveAnimalAI( this );
			NpcType = 7;
			Equip( new Item( 22893, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ) ); 
			/*****************************/
			BCAddon.Hp( this, 85, 4 );
			/*****************************/
			Loots = new BaseTreasure[]{  new BaseTreasure( PeonDrops.LazyPeon , 100f )
						, new BaseTreasure( Drops.MoneyA , 100f )};

		}
	}
}



namespace Server.Creatures
{
	public class HordePeon : BaseCreature
	{
		public HordePeon() : base()
		{
			Name = "Horde Peon";
			Id = 11656;
			Model = 10038;
			Level = RandomLevel(4);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Flags1=0x08080046;
			Armor = 18*Level;
			Block = 1*Level;
			BaseMana = 0;
			BoundingRadius = 0.3f;
			CombatReach = 1.5f;
			Size = 0.8f;
			Speed = 2.9f;
			WalkSpeed = 2.9f;
			RunSpeed = 5.9f;
			Faction = Factions.Horde;
			AIEngine = new DefensiveAnimalAI( this );
			NpcType = 7;
			Equip( new Item( 7441, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ) ); 
			/*****************************/
			BCAddon.Hp( this, 85, 4 );
			/*****************************/
			Loots = new BaseTreasure[]{  new BaseTreasure( PeonDrops.HordePeon , 100f )
						, new BaseTreasure( Drops.MoneyA , 100f )};

		}
	}
}



