using System;
using System.Collections;
using Server;
using Server.Items; 


namespace Server.Creatures
{
	public class DustbelcherWarrior : BaseCreature
	{
		public DustbelcherWarrior() : base()
		{
			Name = "Dustbelcher Warrior";
			Id = 2906;
			Model = 5782;
			Level = RandomLevel(35,37);
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
			AttackSpeed = 1500;			
			BoundingRadius = 1.0f;
			CombatReach = 11f;
			Size = 1.0f;
			Speed = 2.19f;
			WalkSpeed = 2.19f;
			RunSpeed = 5.19f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x080000;
			//Equip( new Item ( 7432, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0) );
			BCAddon.Hp( this, 1421, 35 );
			Loots = new BaseTreasure[]{  new BaseTreasure( DustbelcherDrops.DustbelcherWarrior , 100f )
			, new BaseTreasure( Drops.MoneyB , 100f ) };
		}
	}
}



namespace Server.Creatures
{
	public class DustbelcherMystic : BaseCreature
	{
		public DustbelcherMystic() : base()
		{
			Name = "Dustbelcher Mystic";
			Id = 2907;
			Model = 1122;
			Level = RandomLevel(36,37);
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
			BoundingRadius = 0.9f;
			CombatReach = 1.65f;
			Size = 1.1f;
			Speed = 2.19f;
			WalkSpeed = 2.19f;
			RunSpeed = 5.19f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x080000;
			Equip( new Item ( 11289, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0) );
			BCAddon.Hp( this, 1265, 36 );
			Loots = new BaseTreasure[]{  new BaseTreasure( DustbelcherDrops.DustbelcherMystic , 100f )
			, new BaseTreasure( Drops.MoneyB , 100f ) };
		}
	}
}



namespace Server.Creatures
{
	public class DustbelcherBrute : BaseCreature
	{
		public DustbelcherBrute() : base()
		{
			Name = "Dustbelcher Brute";
			Id = 2715;
			Model = 10714;
			Level = RandomLevel(39,40);
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
			BoundingRadius = 0.9f;
			CombatReach = 1.65f;
			Size = 1.6f;
			Speed = 2.21f;
			WalkSpeed = 2.21f;
			RunSpeed = 5.21f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x080000;
			Equip( new Item ( 5128, (InventoryTypes)17, 2, 1, 1, 1, 0, 0, 0) );
			BCAddon.Hp( this, 1583, 39 );
			Loots = new BaseTreasure[]{  new BaseTreasure( DustbelcherDrops.DustbelcherBrute , 100f )
			, new BaseTreasure( Drops.MoneyB , 100f ) };
		}
	}
}




namespace Server.Creatures
{
	public class DustbelcherWyrmhunter : BaseCreature
	{
		public DustbelcherWyrmhunter() : base()
		{
			Name = "Dustbelcher Wyrmhunter";
			Id = 2716;
			Model = 11548;
			Level = RandomLevel(40,41);
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
			AttackSpeed = 1500;			
			BoundingRadius = 1.5f;
			CombatReach = 2.65f;
			Size = 1.75f;
			Speed = 2.21f;
			WalkSpeed = 2.21f;
			RunSpeed = 5.21f;
			Faction = Factions.Monster;
			AIEngine = new PatrolAI( this );
			Flags1 = 0x080000;
			Equip( new Item ( 7476, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0) );
			BCAddon.Hp( this, 1773, 40 );
			Loots = new BaseTreasure[]{  new BaseTreasure( DustbelcherDrops.DustbelcherWyrmhunter , 100f )
			, new BaseTreasure( Drops.MoneyB , 100f ) };
		}
	}
}



namespace Server.Creatures
{
	public class DustbelcherMauler : BaseCreature
	{
		public DustbelcherMauler() : base()
		{
			Name = "Dustbelcher Mauler";
			Id = 2717;
			Model = 1120;
			Level = RandomLevel(41,42);
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
			AttackSpeed = 1700;			
			BoundingRadius = 1.6f;
			CombatReach = 2.85f;
			Size = 1.9f;
			Speed = 2.23f;
			WalkSpeed = 2.23f;
			RunSpeed = 5.23f;
			Faction = Factions.Monster;
			AIEngine = new PatrolAI( this );
			Flags1 = 0x080000;
			Equip( new Item ( 7476, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0), new Item ( 7477, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0) );
			BCAddon.Hp( this, 1913, 41 );
			Loots = new BaseTreasure[]{  new BaseTreasure( DustbelcherDrops.DustbelcherMauler , 100f )
			, new BaseTreasure( Drops.MoneyB , 100f ) };
		}
	}
}



namespace Server.Creatures
{
	public class DustbelcherShaman : BaseCreature
	{
		public DustbelcherShaman() : base()
		{
			Name = "Dustbelcher Shaman";
			Id = 2718;
			Model = 11545;
			Level = RandomLevel(41,42);
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
			AttackSpeed = 1700;			
			BoundingRadius = 1.8f;
			CombatReach = 3f;
			Size = 2.05f;
			Speed = 2.22f;
			WalkSpeed = 2.22f;
			RunSpeed = 5.22f;
			Faction = Factions.Monster;
			AIEngine = new PatrolAI( this );
			Flags1 = 0x080000;
			Equip( new Item ( 1599, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0));
			BCAddon.Hp( this, 1913, 41 );
			Loots = new BaseTreasure[]{  new BaseTreasure( DustbelcherDrops.DustbelcherShaman , 100f )
			, new BaseTreasure( Drops.MoneyB , 100f ) };
		}
	}
}




namespace Server.Creatures
{
	public class DustbelcherLord : BaseCreature
	{
		public DustbelcherLord() : base()
		{
			Name = "Dustbelcher Lord";
			Id = 2719;
			Model = 1120;
			Level = RandomLevel(44,45);
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
			AttackSpeed = 1500;			
			BoundingRadius = 1.6f;
			CombatReach = 2.8f;
			Size = 1.9f;
			Speed = 2.24f;
			WalkSpeed = 2.24f;
			RunSpeed = 5.24f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x080000;
			Equip( new Item ( 7490, (InventoryTypes)17, 2, 8, 1, 1, 0, 0, 0) );
			BCAddon.Hp( this, 2275, 44 );
			Loots = new BaseTreasure[]{  new BaseTreasure( DustbelcherDrops.DustbelcherLord , 100f )
			, new BaseTreasure( Drops.MoneyB , 100f ) };
		}
	}
}




namespace Server.Creatures
{
	public class DustbelcherOgreMage : BaseCreature
	{
		public DustbelcherOgreMage() : base()
		{
			Name = "Dustbelcher Ogre Mage";
			Id = 2720;
			Model = 11546;
			Level = RandomLevel(43,44);
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
			AttackSpeed = 1500;			
			BoundingRadius = 2f;
			CombatReach = 3f;
			Size = 2.059f;
			Speed = 2.23f;
			WalkSpeed = 2.23f;
			RunSpeed = 5.23f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x080000;
			Equip( new Item ( 1600, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			BCAddon.Hp( this, 1530, 43 );
			Loots = new BaseTreasure[]{  new BaseTreasure( DustbelcherDrops.DustbelcherOgreMage , 100f )
			, new BaseTreasure( Drops.MoneyB , 100f ) };
		}
	}
}


