using System;
using Server;
using Server.Items;
using Server.Quests;

namespace Server.Creatures
{
	public class DarkIronWatchman : BaseCreature
	{
		public DarkIronWatchman() : base()
		{
			Id = 8637;
			Level = RandomLevel( 44 );
			Name = "Dark Iron Watchman";
			Model = 7929;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.347f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			NpcFlags = 0;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7487, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( DarkIronDrops.DarkIronWatchman, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class DarkIronLookout : BaseCreature
	{
		public DarkIronLookout() : base()
		{
			Id = 8566;
			Level = RandomLevel( 47 );
			Name = "Dark Iron Lookout";
			Model = 7865;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.347f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			NpcFlags = 0;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7487, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0), new Item ( 6593, (InventoryTypes)26, 2, 3, 1, 0, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( DarkIronDrops.DarkIronLookout, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class DarkIronSentry : BaseCreature
	{
		public DarkIronSentry() : base()
		{
			Id = 8504;
			Level = RandomLevel( 50 );
			Name = "Dark Iron Sentry";
			Model = 7814;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.347f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage(1f+2.8f*Level,1f+3.5*Level); 
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 100;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			BaseMana = Level * 70;
			NpcFlags = 0;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7419, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( DarkIronDrops.DarkIronSentry, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class DarkIronSteelshifter : BaseCreature
	{
		public DarkIronSteelshifter() : base()
		{
			Id = 8337;
			Level = RandomLevel( 42 );
			Name = "Dark Iron Steelshifter";
			Model = 7762;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.347f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7438, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( DarkIronDrops.DarkIronSteelshifter, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class DarkIronMarksman : BaseCreature
	{
		public DarkIronMarksman() : base()
		{
			Id = 8338;
			Level = RandomLevel( 55 );
			Name = "Dark Iron Marksman";
			Model = 7765;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.347f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			NpcFlags = 0;
			Flags1 = 0x066;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 6593, (InventoryTypes)26, 2, 3, 1, 0, 0, 0, 0) );
		}
	}
	public class DarkIronRifleman : BaseCreature
	{
		public DarkIronRifleman() : base()
		{
			Id = 6523;
			Level = RandomLevel( 28 );
			Name = "Dark Iron Rifleman";
			Model = 825;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.347f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage(1f+2.8f*Level,1f+3.5*Level); 
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 100;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			BaseMana = Level * 70;
			NpcFlags = 0;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7426, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0), new Item ( 6593, (InventoryTypes)26, 2, 3, 1, 0, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( DarkIronDrops.DarkIronRifleman, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class DarkIronAmbassador : BaseCreature
	{
		public DarkIronAmbassador() : base()
		{
			Id = 6228;
			Level = RandomLevel( 33 );
			Name = "Dark Iron Ambassador";
			Model = 6669;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.347f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage(1f+2.8f*Level,1f+3.5*Level); 
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 100;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			BaseMana = Level * 70;
			NpcFlags = 0;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = (Factions)63;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 1927, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( DarkIronDrops.DarkIronAmbassador, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class DarkIronAgent : BaseCreature
	{
		public DarkIronAgent() : base()
		{
			Id = 6212;
			Level = RandomLevel( 33 );
			Name = "Dark Iron Agent";
			Model = 3456;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.347f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage(1f+2.8f*Level,1f+3.5*Level); 
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 100;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			BaseMana = Level * 70;
			NpcFlags = 0;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = (Factions)63;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 6469, (InventoryTypes)13, 2, 15, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( DarkIronDrops.DarkIronAgent, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class CaptainBeld : BaseCreature
	{
		public CaptainBeld() : base()
		{
			Id = 6124;
			Level = RandomLevel( 11 );
			Name = "Captain Beld";
			Guild = "Dark Iron Captain";
			Model = 4957;
			AttackSpeed = 1959;
			CombatReach = 0.8f;
			BoundingRadius = 0.561f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			NpcFlags = 0;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( DarkIronDrops.CaptainBeld, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class DarkIronSpy : BaseCreature
	{
		public DarkIronSpy() : base()
		{
			Id = 6123;
			Level = RandomLevel( 9 ,10 );
			Name = "Dark Iron Spy";
			Model = 4956;
			AttackSpeed = 1987;
			CombatReach = 0.8f;
			BoundingRadius = 0.561f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = (Factions)674;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( DarkIronDrops.DarkIronSpy, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class DarkIronSlaver : BaseCreature
	{
		public DarkIronSlaver() : base()
		{
			Id = 5844;
			Level = RandomLevel( 46 );
			Name = "Dark Iron Slaver";
			Model = 7791;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.347f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			ManaType = 1;
			BaseMana = 100;
			NpcFlags = 0;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			LearnSpell( 11573, SpellsTypes.Offensive );
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7419, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( DarkIronDrops.DarkIronSlaver, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class DarkIronTaskmaster : BaseCreature
	{
		public DarkIronTaskmaster() : base()
		{
			Id = 5846;
			Level = RandomLevel( 48 );
			Name = "Dark Iron Taskmaster";
			Model = 7799;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.347f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			ManaType = 1;
			BaseMana = 100;
			NpcFlags = 0;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			LearnSpell( 11550, SpellsTypes.Offensive );
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 6434, (InventoryTypes)13, 2, 15, 1, 3, 0, 0, 0), new Item ( 6434, (InventoryTypes)13, 2, 15, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( DarkIronDrops.DarkIronTaskmaster, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class DarkIronGeologist : BaseCreature
	{
		public DarkIronGeologist() : base()
		{
			Id = 5839;
			Level = RandomLevel( 43 );
			Name = "Dark Iron Geologist";
			Model = 7794;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.347f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			NpcFlags = 0;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 1599, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( DarkIronDrops.DarkIronGeologist, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class DarkIronSteamsmith : BaseCreature
	{
		public DarkIronSteamsmith() : base()
		{
			Id = 5840;
			Level = RandomLevel( 47 );
			Name = "Dark Iron Steamsmith";
			Model = 7796;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.347f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			NpcFlags = 0;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7483, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( DarkIronDrops.DarkIronSteamsmith, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class DarkIronBombardier : BaseCreature
	{
		public DarkIronBombardier() : base()
		{
			Id = 4062;
			Level = RandomLevel( 30 );
			Name = "Dark Iron Bombardier";
			Model = 3954;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.347f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			NpcFlags = 0;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 26367, (InventoryTypes)13, 2, 4, 2, 7, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( DarkIronDrops.DarkIronBombardier, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class DarkIronSupplier : BaseCreature
	{
		public DarkIronSupplier() : base()
		{
			Id = 2575;
			Level = RandomLevel( 32 );
			Name = "Dark Iron Supplier";
			Model = 3969;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.347f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			NpcFlags = 0;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7445, (InventoryTypes)13, 2, 14, 1, 7, 0, 0, 0), new Item ( 6530, (InventoryTypes)23, 4, 0, 2, 7, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( DarkIronDrops.DarkIronSupplier, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class DarkIronShadowcaster : BaseCreature
	{
		public DarkIronShadowcaster() : base()
		{
			Id = 2577;
			Level = RandomLevel( 31 );
			Name = "Dark Iron Shadowcaster";
			Model = 3970;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.347f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			NpcFlags = 0;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 1599, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( DarkIronDrops.DarkIronShadowcaster, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class DarkIronRaider : BaseCreature
	{
		public DarkIronRaider() : base()
		{
			Id = 2149;
			Level = RandomLevel( 14 );
			Name = "Dark Iron Raider";
			Model = 3451;
			AttackSpeed = 1917;
			CombatReach = 0.8f;
			BoundingRadius = 0.561f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = (Factions)674;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( DarkIronDrops.DarkIronRaider, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class DarkIronAmbusher : BaseCreature
	{
		public DarkIronAmbusher() : base()
		{
			Id = 1981;
			Level = RandomLevel( 9 ,10 );
			Name = "Dark Iron Ambusher";
			Model = 3452;
			AttackSpeed = 1987;
			CombatReach = 0.8f;
			BoundingRadius = 0.561f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = (Factions)674;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( DarkIronDrops.DarkIronAmbusher, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class DarkIronSapper : BaseCreature
	{
		public DarkIronSapper() : base()
		{
			Id = 1222;
			Level = RandomLevel( 17 );
			Name = "Dark Iron Sapper";
			Model = 870;
			AttackSpeed = 1875;
			CombatReach = 1.5f;
			BoundingRadius = 0.347f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = (Factions)674;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( DarkIronDrops.DarkIronSapper, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class DarkIronInsurgent : BaseCreature
	{
		public DarkIronInsurgent() : base()
		{
			Id = 1169;
			Level = RandomLevel( 19 );
			Name = "Dark Iron Insurgent";
			Model = 3456;
			AttackSpeed = 1848;
			CombatReach = 1.5f;
			BoundingRadius = 0.347f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = (Factions)674;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7492, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( DarkIronDrops.DarkIronInsurgent, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class DarkIronDwarf : BaseCreature
	{
		public DarkIronDwarf() : base()
		{
			Id = 1051;
			Level = RandomLevel( 27 );
			Name = "Dark Iron Dwarf";
			Model = 825;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.347f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage(1f+2.8f*Level,1f+3.5*Level); 
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 100;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			BaseMana = Level * 70;
			NpcFlags = 0;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7476, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( DarkIronDrops.DarkIronDwarf, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class DarkIronSaboteur : BaseCreature
	{
		public DarkIronSaboteur() : base()
		{
			Id = 1052;
			Level = RandomLevel( 29 );
			Name = "Dark Iron Saboteur";
			Model = 3490;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.347f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage(1f+2.8f*Level,1f+3.5*Level); 
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 100;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			BaseMana = Level * 70;
			NpcFlags = 0;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7487, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0), new Item ( 1755, (InventoryTypes)14, 4, 6, 1, 4, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( DarkIronDrops.DarkIronSaboteur, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class DarkIronTunneler : BaseCreature
	{
		public DarkIronTunneler() : base()
		{
			Id = 1053;
			Level = RandomLevel( 30 );
			Name = "Dark Iron Tunneler";
			Model = 3488;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.347f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage(1f+2.8f*Level,1f+3.5*Level); 
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 100;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			BaseMana = Level * 70;
			NpcFlags = 0;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7493, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( DarkIronDrops.DarkIronTunneler, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class DarkIronDemolitionist : BaseCreature
	{
		public DarkIronDemolitionist() : base()
		{
			Id = 1054;
			Level = RandomLevel( 30 );
			Name = "Dark Iron Demolitionist";
			Model = 3487;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.347f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage(1f+2.8f*Level,1f+3.5*Level); 
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 100;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			BaseMana = Level * 70;
			NpcFlags = 0;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 26367, (InventoryTypes)13, 2, 4, 2, 7, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( DarkIronDrops.DarkIronDemolitionist, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	
}