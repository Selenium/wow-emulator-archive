using System;
using System.Collections;
using Server;
using Server.Items; 


namespace Server.Creatures
{
	public class BoulderfistOgre : BaseCreature
	{
		public BoulderfistOgre() : base()
		{
			Name = "Boulderfist Ogre";
			Id = 2562;
			Model = 1052;
			Level = RandomLevel(32,33);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*3.85f);
			NpcType = (int)NpcTypes.Humanoid ;
			Armor = (int)(Level*26.2);
			Block= Level;
			SetDamage(1f+2.8f*Level,1f+3.5*Level);
			ManaType=0;
 			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 1.0f;
			CombatReach = 1.7f;
			Size = 1.15f;
			Speed = 2.16f;
			WalkSpeed = 2.16f;
			RunSpeed = 5.16f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x080000;
			Equip( new Item ( 7432, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0) );
			BCAddon.Hp( this, 1137, 32 );
			Loots = new BaseTreasure[]{  new BaseTreasure( BoulderfistDrops.BoulderfistOgre , 100f )
			, new BaseTreasure( Drops.MoneyB , 100f ) };
		}
	}
}


namespace Server.Creatures
{
	public class BoulderfistEnforcer : BaseCreature
	{
		public BoulderfistEnforcer() : base()
		{
			Name = "Boulderfist Enforcer";
			Id = 2564;
			Model = 1054;
			Level = RandomLevel(33, 34);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*3.85f);
			NpcType = (int)NpcTypes.Humanoid ;
			Armor = (int)(Level*26.2);
			Block= Level;
			SetDamage(1f+2.8f*Level,1f+3.5*Level);
			ManaType=0;
 			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 1.1f;
			CombatReach = 1.95f;
			Size = 1.3f;
			Speed = 2.16f;
			WalkSpeed = 2.16f;
			RunSpeed = 5.16f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x080000;
			Equip( new Item ( 7429, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0) );
			BCAddon.Hp( this, 898, 33 );
			Loots = new BaseTreasure[]{  new BaseTreasure( BoulderfistDrops.BoulderfistEnforcer , 100f )
			, new BaseTreasure( Drops.MoneyB , 100f ) };
		}
	}
}




namespace Server.Creatures
{
	public class BoulderfistBrute : BaseCreature
	{
		public BoulderfistBrute() : base()
		{
			Name = "Boulderfist Brute";
			Id = 2566;
			Model = 3193;
			Level = RandomLevel(35, 36);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*3.85f);
			NpcType = (int)NpcTypes.Humanoid ;
			Armor = (int)(Level*26.2);
			Block= Level;
			SetDamage(1f+2.8f*Level,1f+3.5*Level);
			ManaType=0;
 			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 1.2f;
			CombatReach = 2.16f;
			Size = 1.44f;
			Speed = 2.17f;
			WalkSpeed = 2.17f;
			RunSpeed = 5.17f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x080000;
			Equip( new Item ( 7432, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0) );
			BCAddon.Hp( this, 898, 35 );
			Loots = new BaseTreasure[]{  new BaseTreasure( BoulderfistDrops.BoulderfistBrute , 100f )
			, new BaseTreasure( Drops.MoneyB , 100f ) };
		}
	}
}




namespace Server.Creatures
{
	public class BoulderfistMagus : BaseCreature
	{
		public BoulderfistMagus() : base()
		{
			Name = "Boulderfist Magus";
			Id = 2567;
			Model = 6170;
			Level = RandomLevel(36, 37);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*3.85f);
			NpcType = (int)NpcTypes.Humanoid ;
			Armor = (int)(Level*26.2);
			Block= Level;
			SetDamage(1f+2.8f*Level,1f+3.5*Level);
			ManaType=0;
 			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 1.3f;
			CombatReach = 1.9f;
			Size = 1.3f;
			Speed = 2.19f;
			WalkSpeed = 2.19f;
			RunSpeed = 5.19f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x080000;
			Equip( new Item ( 1927, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			BCAddon.Hp( this, 1018, 36 );
			Loots = new BaseTreasure[]{  new BaseTreasure( BoulderfistDrops.BoulderfistMagus , 100f )
			, new BaseTreasure( Drops.MoneyB , 100f ) };
		}
	}
}




namespace Server.Creatures
{
	public class BoulderfistMauler : BaseCreature
	{
		public BoulderfistMauler() : base()
		{
			Name = "Boulderfist Mauler";
			Id = 2569;
			Model = 1051;
			Level = RandomLevel(37, 38);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*4.85f);
			NpcType = (int)NpcTypes.Humanoid ;
			Armor = (int)(Level*29.2);
			Block= Level;
			SetDamage(1f+3.5f*Level,1f+4.0*Level);
			ManaType=0;
 			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 1.4f;
			CombatReach = 2.4f;
			Size = 1.6f;
			Speed = 2.19f;
			WalkSpeed = 2.19f;
			RunSpeed = 5.19f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x080000;
			Elite = 1;
			Equip( new Item ( 7439, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0), new Item ( 7440, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0) );
			BCAddon.Hp( this, 1355, 36 );
			Loots = new BaseTreasure[]{  new BaseTreasure( BoulderfistDrops.BoulderfistMauler , 100f )
			,new BaseTreasure(DropsME.MoneyElite1, 100f )}; 
		}
	}
}



namespace Server.Creatures
{
	public class BoulderfistShaman : BaseCreature
	{
		public BoulderfistShaman() : base()
		{
			Name = "Boulderfist Shaman";
			Id = 2570;
			Model = 416;
			Level = RandomLevel(38, 39);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*4.85f);
			NpcType = (int)NpcTypes.Humanoid ;
			Armor = (int)(Level*29.2);
			Block= Level;
			SetDamage(1f+3.5f*Level,1f+4.0*Level);
			ManaType=0;
 			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 1.4f;
			CombatReach = 2.4f;
			Size = 1.6f;
			Speed = 2.81f;
			WalkSpeed = 2.81f;
			RunSpeed = 5.81f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x080000;
			Elite = 1;
			Equip( new Item ( 1600, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0));
			BCAddon.Hp( this, 1555, 38 );
			Loots = new BaseTreasure[]{  new BaseTreasure( BoulderfistDrops.BoulderfistShaman , 100f )
			,new BaseTreasure(DropsME.MoneyElite1, 100f )}; 
		}
	}
}




namespace Server.Creatures
{
	public class BoulderfistLord : BaseCreature
	{
		public BoulderfistLord() : base()
		{
			Name = "Boulderfist Lord";
			Id = 2571;
			Model = 448;
			Level = RandomLevel(39, 40);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*4.85f);
			NpcType = (int)NpcTypes.Humanoid ;
			Armor = (int)(Level*29.2);
			Block= Level;
			SetDamage(1f+3.5f*Level,1f+4.0*Level);
			ManaType=0;
 			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 1.5f;
			CombatReach = 2.6f;
			Size = 1.75f;
			Speed = 2.81f;
			WalkSpeed = 2.81f;
			RunSpeed = 5.81f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x080000;
			Elite = 1;
			Equip( new Item ( 3879, (InventoryTypes)17, 2, 5, 2, 1, 0, 0, 0));
			BCAddon.Hp( this, 2015, 39 );
			Loots = new BaseTreasure[]{  new BaseTreasure( BoulderfistDrops.BoulderfistLord , 100f )
			,new BaseTreasure(DropsME.MoneyElite1, 100f )}; 
		}
	}
}

