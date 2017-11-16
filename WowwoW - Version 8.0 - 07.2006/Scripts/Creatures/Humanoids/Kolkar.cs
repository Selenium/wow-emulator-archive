using System;
using Server;
using Server.Items;
using Server.Quests;

namespace Server.Creatures
{
	public class KolkarWaylayer : BaseCreature
	{
		public KolkarWaylayer() : base()
		{
			Id = 12976;
			Level = RandomLevel( 33 ,34 );
			Name = "Kolkar Waylayer";
			Model = 4871;
			AttackSpeed = 1651;
			CombatReach = 1.5f;
			BoundingRadius = 0.561f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 70;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 30;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( new Loot[] {
				new Loot( typeof( WoolCloth ), 4.35f )
				, new Loot( typeof( SilkCloth ), 27.4f )
				, new Loot( typeof( MageweaveCloth ), 0.55f )
				, new Loot( typeof( CentaurEar ), 6.78f )
				, new Loot( typeof( CrudeCharm ), 1.38f )
				}, 100f ), new BaseTreasure( Drops.MoneyA, 100f ), new BaseTreasure( WorldDrops.AdvancedDrops, 100f ) };
		}
	}
	public class KolkarCentaur : BaseCreature
	{
		public KolkarCentaur() : base()
		{
			Id = 4632;
			Level = RandomLevel( 30 );
			Name = "Kolkar Centaur";
			Model = 9447;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.35f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 70;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 30;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7428, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( new Loot[] {
				new Loot( typeof( WoolCloth ), 3.94f )
				, new Loot( typeof( SilkCloth ), 29.3f )
				, new Loot( typeof( MageweaveCloth ), 0.96f )
				, new Loot( typeof( CentaurEar ), 14.6f )
				, new Loot( typeof( CrudeCharm ), 5.23f )
				}, 100f ), new BaseTreasure( Drops.MoneyA, 100f ), new BaseTreasure( WorldDrops.AdvancedDrops, 100f ) };
		}
	}
	public class KolkarScout : BaseCreature
	{
		public KolkarScout() : base()
		{
			Id = 4633;
			Level = RandomLevel( 30 );
			Name = "Kolkar Scout";
			Model = 9445;
			AttackSpeed = 2000;
			CombatReach = 1.25f;
			BoundingRadius = 0.71f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 70;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 30;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7487, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0), new Item ( 8106, (InventoryTypes)15, 2, 2, 2, 0, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( new Loot[] {
				new Loot( typeof( WoolCloth ), 3.82f )
				, new Loot( typeof( SilkCloth ), 29.1f )
				, new Loot( typeof( MageweaveCloth ), 1.12f )
				, new Loot( typeof( CentaurEar ), 14.2f )
				, new Loot( typeof( CrudeCharm ), 5.45f )
				}, 100f ), new BaseTreasure( Drops.MoneyA, 100f ), new BaseTreasure( WorldDrops.AdvancedDrops, 100f ) };
		}
	}
	public class KolkarMauler : BaseCreature
	{
		public KolkarMauler() : base()
		{
			Id = 4634;
			Level = RandomLevel( 31 );
			Name = "Kolkar Mauler";
			Model = 4874;
			AttackSpeed = 2000;
			CombatReach = 1.07f;
			BoundingRadius = 0.4025f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 70;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 30;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 6434, (InventoryTypes)13, 2, 15, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( new Loot[] {
				new Loot( typeof( WoolCloth ), 3.89f )
				, new Loot( typeof( SilkCloth ), 28.9f )
				, new Loot( typeof( MageweaveCloth ), 0.91f )
				, new Loot( typeof( CentaurEar ), 15.5f )
				, new Loot( typeof( CrudeCharm ), 6.94f )
				}, 100f ), new BaseTreasure( Drops.MoneyA, 100f ), new BaseTreasure( WorldDrops.AdvancedDrops, 100f ) };
		}
	}
	public class KolkarWindchaser : BaseCreature
	{
		public KolkarWindchaser() : base()
		{
			Id = 4635;
			Level = RandomLevel( 31 );
			Name = "Kolkar Windchaser";
			Model = 4871;
			AttackSpeed = 2000;
			CombatReach = 1.25f;
			BoundingRadius = 0.35f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 70;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 30;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( new Loot[] {
				new Loot( typeof( WoolCloth ), 3.82f )
				, new Loot( typeof( SilkCloth ), 29.3f )
				, new Loot( typeof( MageweaveCloth ), 0.94f )
				, new Loot( typeof( CentaurEar ), 15.7f )
				, new Loot( typeof( CrudeCharm ), 7.04f )
				}, 100f ), new BaseTreasure( Drops.MoneyA, 100f ), new BaseTreasure( WorldDrops.AdvancedDrops, 100f ) };
		}
	}
	public class KolkarBattleLord : BaseCreature
	{
		public KolkarBattleLord() : base()
		{
			Id = 4636;
			Level = RandomLevel( 33 );
			Name = "Kolkar Battle Lord";
			Model = 9448;
			AttackSpeed = 2000;
			CombatReach = 1.95f;
			BoundingRadius = 0.455f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 70;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 30;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 2839, (InventoryTypes)17, 2, 5, 2, 1, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( new Loot[] {
				new Loot( typeof( WoolCloth ), 3.78f )
				, new Loot( typeof( SilkCloth ), 28.7f )
				, new Loot( typeof( MageweaveCloth ), 1.10f )
				, new Loot( typeof( CentaurEar ), 14.4f )
				, new Loot( typeof( CrudeCharm ), 7.29f )
				}, 100f ), new BaseTreasure( Drops.MoneyA, 100f ), new BaseTreasure( WorldDrops.AdvancedDrops, 100f ) };
		}
	}
	public class KolkarDestroyer : BaseCreature
	{
		public KolkarDestroyer() : base()
		{
			Id = 4637;
			Level = RandomLevel( 32 );
			Name = "Kolkar Destroyer";
			Model = 9446;
			AttackSpeed = 2000;
			CombatReach = 1.04f;
			BoundingRadius = 0.8165f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 70;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 30;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 5128, (InventoryTypes)17, 2, 1, 1, 1, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( new Loot[] {
				new Loot( typeof( WoolCloth ), 3.81f )
				, new Loot( typeof( SilkCloth ), 28.6f )
				, new Loot( typeof( MageweaveCloth ), 0.92f )
				, new Loot( typeof( CentaurEar ), 14.8f )
				, new Loot( typeof( CrudeCharm ), 7.61f )
				}, 100f ), new BaseTreasure( Drops.MoneyA, 100f ), new BaseTreasure( WorldDrops.AdvancedDrops, 100f ) };
		}
	}
	public class KolkarBloodcharger : BaseCreature
	{
		public KolkarBloodcharger() : base()
		{
			Id = 3397;
			Level = RandomLevel( 15 );
			Name = "Kolkar Bloodcharger";
			Model = 9447;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.35f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 70;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 30;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7429, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( new Loot[] {
				new Loot( typeof( LightLeather ), 0.01f )
				, new Loot( typeof( LinenCloth ), 37.4f )
				, new Loot( typeof( FungalSpores ), 0.01f )
				, new Loot( typeof( CentaurBracers ), 7.75f )
				, new Loot( typeof( BloodShard ), 0.01f )
				, new Loot( typeof( ClamMeat ), 0.01f )
				}, 100f ), new BaseTreasure( Drops.MoneyA, 100f ), new BaseTreasure( WorldDrops.LowDrops, 100f ) };
		}
	}
	public class KolkarWrangler : BaseCreature
	{
		public KolkarWrangler() : base()
		{
			Id = 3272;
			Level = RandomLevel( 13 );
			Name = "Kolkar Wrangler";
			Model = 9442;
			AttackSpeed = 2000;
			CombatReach = 1.06f;
			BoundingRadius = 0.6035f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 70;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 30;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			//LearnSpell( 6533, SpellsTypes.Offensive );
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new LightCrossbow());
			Loots = new BaseTreasure[]{ new BaseTreasure( new Loot[] {
				new Loot( typeof( LinenCloth ), 37.9f )
				, new Loot( typeof( FungalSpores ), 0.03f )
				, new Loot( typeof( KolkarBootyKey ), 3.02f )
				, new Loot( typeof( CentaurBracers ), 20.3f )
				, new Loot( typeof( BloodShard ), 0.01f )
				}, 100f ), new BaseTreasure( Drops.MoneyA, 100f ), new BaseTreasure( WorldDrops.LowDrops, 100f ) };
		}
	}
	public class KolkarStormer : BaseCreature
	{
		public KolkarStormer() : base()
		{
			Id = 3273;
			Level = RandomLevel( 13 );
			Name = "Kolkar Stormer";
			Model = 9443;
			AttackSpeed = 2000;
			CombatReach = 1.06f;
			BoundingRadius = 0.2975f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 70;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 30;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			LearnSpell( 458, SpellsTypes.Offensive );
			LearnSpell( 6535, SpellsTypes.Offensive );
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 5098, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( new Loot[] {
				new Loot( typeof( LinenCloth ), 37.6f )
				, new Loot( typeof( FungalSpores ), 0.07f )
				, new Loot( typeof( KolkarBootyKey ), 3.02f )
				, new Loot( typeof( CentaurBracers ), 16.6f )
				, new Loot( typeof( BloodShard ), 0.02f )
				}, 100f ), new BaseTreasure( Drops.MoneyA, 100f ), new BaseTreasure( WorldDrops.LowDrops, 100f ) };
		}
	}
	public class KolkarPackRunner : BaseCreature
	{
		public KolkarPackRunner() : base()
		{
			Id = 3274;
			Level = RandomLevel( 15 );
			Name = "Kolkar Pack Runner";
			NpcText00 = "My wind riders are trained to fly quickly through the hot Barrens air.";
			Model = 9445;
			AttackSpeed = 2000;
			CombatReach = 1.25f;
			BoundingRadius = 0.71f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 70;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 30;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7483, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( new Loot[] {
				new Loot( typeof( LinenCloth ), 38.1f )
				, new Loot( typeof( CentaurBracers ), 7.18f )
				, new Loot( typeof( BloodShard ), 0.01f )
				, new Loot( typeof( ClamMeat ), 0.04f )
				}, 100f ), new BaseTreasure( Drops.MoneyA, 100f ), new BaseTreasure( WorldDrops.LowDrops, 100f ) };
		}
	}
	public class KolkarMarauder : BaseCreature
	{
		public KolkarMarauder() : base()
		{
			Id = 3275;
			Level = RandomLevel( 15 );
			Name = "Kolkar Marauder";
			Model = 4874;
			AttackSpeed = 2000;
			CombatReach = 1.07f;
			BoundingRadius = 0.4025f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 70;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 30;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7481, (InventoryTypes)17, 2, 6, 1, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( new Loot[] {
				new Loot( typeof( LinenCloth ), 37.8f )
				, new Loot( typeof( SilverBar ), 0.02f )
				, new Loot( typeof( FungalSpores ), 0.02f )
				, new Loot( typeof( CentaurBracers ), 8.39f )
				, new Loot( typeof( ClamMeat ), 0.01f )
				}, 100f ), new BaseTreasure( Drops.MoneyA, 100f ), new BaseTreasure( WorldDrops.LowDrops, 100f ) };
		}
	}
	public class KolkarDrudge : BaseCreature
	{
		public KolkarDrudge() : base()
		{
			Id = 3119;
			Level = RandomLevel( 6 );
			Name = "Kolkar Drudge";
			Model = 9442;
			AttackSpeed = 2000;
			CombatReach = 1.06f;
			BoundingRadius = 0.6035f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 70;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 30;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			LearnSpell( 7272, SpellsTypes.Offensive );
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7487, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( new Loot[] {
				new Loot( typeof( LinenCloth ), 28.8f )
				, new Loot( typeof( CanvasScraps ), 0.90f )
				}, 100f ), new BaseTreasure( Drops.MoneyA, 100f ), new BaseTreasure( WorldDrops.LowDrops, 100f ) };
		}
	}
	public class KolkarOutrunner : BaseCreature
	{
		public KolkarOutrunner() : base()
		{
			Id = 3120;
			Level = RandomLevel( 7 );
			Name = "Kolkar Outrunner";
			Model = 9443;
			AttackSpeed = 2000;
			CombatReach = 1.06f;
			BoundingRadius = 0.2975f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 70;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 30;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7478, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( new Loot[] {
				new Loot( typeof( LightLeather ), 0.01f )
				, new Loot( typeof( LinenCloth ), 29.3f )
				, new Loot( typeof( CanvasScraps ), 0.82f )
				}, 100f ), new BaseTreasure( Drops.MoneyA, 100f ), new BaseTreasure( WorldDrops.LowDrops, 100f ) };
		}
	}
	public class KolkarAmbusher : BaseCreature
	{
		public KolkarAmbusher() : base()
		{
			Id = 12977;
			Level = RandomLevel( 34 ,35 );
			Name = "Kolkar Ambusher";
			Model = 9448;
			AttackSpeed = 1638;
			CombatReach = 1.5f;
			BoundingRadius = 0.561f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 70;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 30;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 2839, (InventoryTypes)17, 2, 5, 2, 1, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( new Loot[] {
				new Loot( typeof( WoolCloth ), 3.57f )
				, new Loot( typeof( SilkCloth ), 26.9f )
				, new Loot( typeof( MageweaveCloth ), 1.07f )
				, new Loot( typeof( CentaurEar ), 5.72f )
				, new Loot( typeof( CrudeCharm ), 1.16f )
				}, 100f ), new BaseTreasure( Drops.MoneyA, 100f ), new BaseTreasure( WorldDrops.AdvancedDrops, 100f ) };
		}
	}
	public class KolkarStormseer : BaseCreature
	{
		public KolkarStormseer() : base()
		{
			Id = 9523;
			Level = RandomLevel( 16 );
			Name = "Kolkar Stormseer";
			Model = 4871;
			AttackSpeed = 2000;
			CombatReach = 1.25f;
			BoundingRadius = 0.35f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 70;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 30;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 5098, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( new Loot[] {
				new Loot( typeof( PieceOfKromzarsBanner ), 0.14f )
				, new Loot( typeof( LinenCloth ), 35.0f )
				, new Loot( typeof( CentaurBracers ), 3.87f )
				}, 100f ), new BaseTreasure( Drops.MoneyA, 100f ), new BaseTreasure( WorldDrops.MediumDrops, 100f ) };
		}
	}
	public class KolkarInvader : BaseCreature
	{
		public KolkarInvader() : base()
		{
			Id = 9524;
			Level = RandomLevel( 17 );
			Name = "Kolkar Invader";
			Model = 1349;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.852f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 70;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 30;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7481, (InventoryTypes)17, 2, 6, 1, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( new Loot[] {
				new Loot( typeof( PieceOfKromzarsBanner ), 0.09f )
				, new Loot( typeof( LinenCloth ), 13.7f )
				, new Loot( typeof( WoolCloth ), 18.0f )
				, new Loot( typeof( CentaurBracers ), 3.56f )
				}, 100f ), new BaseTreasure( Drops.MoneyA, 100f ), new BaseTreasure( WorldDrops.MediumDrops, 100f ) };
		}
	}
	
}