using System;
using Server;
using Server.Items;
using Server.Quests;

namespace Server.Creatures
{
	public class BlackrockRaider : BaseCreature
	{
		public BlackrockRaider() : base()
		{
			Id = 9605;
			Level = RandomLevel( 59 );
			Name = "Blackrock Raider";
			Model = 6049;
			AttackSpeed = 1287;
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
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( BlackrockDrops.BlackrockRaider, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class BlackrockAmbusher : BaseCreature
	{
		public BlackrockAmbusher() : base()
		{
			Id = 9522;
			Level = RandomLevel( 54 ,55 );
			Name = "Blackrock Ambusher";
			Model = 8699;
			AttackSpeed = 1131;
			CombatReach = 0.8f;
			BoundingRadius = 0.561f;
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
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( BlackrockDrops.BlackrockAmbusher, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class BlackrockWarlock : BaseCreature
	{
		public BlackrockWarlock() : base()
		{
			Id = 7028;
			Level = RandomLevel( 57 );
			Name = "Blackrock Warlock";
			Model = 6048;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.372f;
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
			LearnSpell( 11659, SpellsTypes.Offensive );
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 2469, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( BlackrockDrops.BlackrockWarlock, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class BlackrockBattlemaster : BaseCreature
	{
		public BlackrockBattlemaster() : base()
		{
			Id = 7029;
			Level = RandomLevel( 58 );
			Name = "Blackrock Battlemaster";
			Model = 6049;
			AttackSpeed = 1600;
			CombatReach = 1.5f;
			BoundingRadius = 0.372f;
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
			Equip( new Item ( 7508, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0), new Item ( 7508, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( BlackrockDrops.BlackrockBattlemaster, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class BlackrockSoldier : BaseCreature
	{
		public BlackrockSoldier() : base()
		{
			Id = 7025;
			Level = RandomLevel( 55 );
			Name = "Blackrock Soldier";
			Model = 6045;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.372f;
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
			LearnSpell( 11601, SpellsTypes.Offensive );
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7426, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0), new Item ( 1755, (InventoryTypes)14, 4, 6, 1, 4, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( BlackrockDrops.BlackrockSoldier, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class BlackrockSorcerer : BaseCreature
	{
		public BlackrockSorcerer() : base()
		{
			Id = 7026;
			Level = RandomLevel( 55 );
			Name = "Blackrock Sorcerer";
			Model = 6046;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.372f;
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
			LearnSpell( 10148, SpellsTypes.Offensive );
			LearnSpell( 8423, SpellsTypes.Offensive );
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 1927, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( BlackrockDrops.BlackrockSorcerer, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class BlackrockSlayer : BaseCreature
	{
		public BlackrockSlayer() : base()
		{
			Id = 7027;
			Level = RandomLevel( 57 );
			Name = "Blackrock Slayer";
			Model = 6047;
			AttackSpeed = 2700;
			CombatReach = 1.5f;
			BoundingRadius = 0.372f;
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
			LearnSpell( 20662, SpellsTypes.Offensive );
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 3797, (InventoryTypes)17, 2, 1, 1, 1, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( BlackrockDrops.BlackrockSlayer, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class BlackrockHunter : BaseCreature
	{
		public BlackrockHunter() : base()
		{
			Id = 4462;
			Level = RandomLevel( 23 );
			Name = "Blackrock Hunter";
			Model = 6031;
			AttackSpeed = 2000;
			CombatReach = 1.65f;
			BoundingRadius = 0.4092f;
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
			Equip( new Item ( 7481, (InventoryTypes)17, 2, 6, 1, 2, 0, 0, 0), new Item ( 22671, (InventoryTypes)25, 2, 16, 1, 0, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( BlackrockDrops.BlackrockHunter, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class BlackrockSummoner : BaseCreature
	{
		public BlackrockSummoner() : base()
		{
			Id = 4463;
			Level = RandomLevel( 23 );
			Name = "Blackrock Summoner";
			Model = 6030;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.372f;
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
			Equip( new Item ( 1600, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( BlackrockDrops.BlackrockSummoner, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class BlackrockGladiator : BaseCreature
	{
		public BlackrockGladiator() : base()
		{
			Id = 4464;
			Level = RandomLevel( 25 );
			Name = "Blackrock Gladiator";
			Model = 6042;
			AttackSpeed = 2400;
			CombatReach = 2.0f;
			BoundingRadius = 0.4464f;
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
			Equip( new Item ( 5175, (InventoryTypes)17, 2, 8, 1, 1, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( BlackrockDrops.BlackrockGladiator, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class BlackrockScout : BaseCreature
	{
		public BlackrockScout() : base()
		{
			Id = 4064;
			Level = RandomLevel( 20 );
			Name = "Blackrock Scout";
			Model = 6038;
			AttackSpeed = 2000;
			CombatReach = 1.57f;
			BoundingRadius = 0.3906f;
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
			Equip( new Item ( 7487, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0), new Item ( 1684, (InventoryTypes)14, 4, 6, 1, 4, 0, 0, 0), new Item ( 6231, (InventoryTypes)15, 2, 2, 2, 0, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( BlackrockDrops.BlackrockScout, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class BlackrockSentry : BaseCreature
	{
		public BlackrockSentry() : base()
		{
			Id = 4065;
			Level = RandomLevel( 21 );
			Name = "Blackrock Sentry";
			Model = 6029;
			AttackSpeed = 2000;
			CombatReach = 1.65f;
			BoundingRadius = 0.4092f;
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
			Equip( new Item ( 7428, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0), new Item ( 1684, (InventoryTypes)14, 4, 6, 1, 4, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( BlackrockDrops.BlackrockSentry, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class BlackrockTracker : BaseCreature
	{
		public BlackrockTracker() : base()
		{
			Id = 615;
			Level = RandomLevel( 24 );
			Name = "Blackrock Tracker";
			Model = 6040;
			AttackSpeed = 2000;
			CombatReach = 1.65f;
			BoundingRadius = 0.4092f;
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
			Equip( new Item ( 7481, (InventoryTypes)17, 2, 6, 1, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( BlackrockDrops.BlackrockTracker, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class BlackrockOutrunner : BaseCreature
	{
		public BlackrockOutrunner() : base()
		{
			Id = 485;
			Level = RandomLevel( 20 );
			Name = "Blackrock Outrunner";
			Model = 6034;
			AttackSpeed = 2000;
			CombatReach = 1.57f;
			BoundingRadius = 0.3906f;
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
			LearnSpell( 10852, SpellsTypes.Offensive );
			LearnSpell( 14030, SpellsTypes.Offensive );
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7487, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0), new Item ( 1684, (InventoryTypes)14, 4, 6, 1, 4, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( BlackrockDrops.BlackrockOutrunner, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class BlackrockChampion : BaseCreature
	{
		public BlackrockChampion() : base()
		{
			Id = 435;
			Level = RandomLevel( 24 ,25 );
			Name = "Blackrock Champion";
			Model = 6044;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.4464f;
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
			Loots = new BaseTreasure[]{ new BaseTreasure( BlackrockDrops.BlackrockChampion, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class BlackrockShadowcaster : BaseCreature
	{
		public BlackrockShadowcaster() : base()
		{
			Id = 436;
			Level = RandomLevel( 22 );
			Name = "Blackrock Shadowcaster";
			Model = 6039;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.372f;
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
			Equip( new Item ( 1600, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( BlackrockDrops.BlackrockShadowcaster, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class BlackrockRenegade : BaseCreature
	{
		public BlackrockRenegade() : base()
		{
			Id = 437;
			Level = RandomLevel( 21 );
			Name = "Blackrock Renegade";
			Model = 6037;
			AttackSpeed = 2000;
			CombatReach = 1.65f;
			BoundingRadius = 0.4092f;
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
			Equip( new Item ( 7476, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0), new Item ( 1684, (InventoryTypes)14, 4, 6, 1, 4, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( BlackrockDrops.BlackrockRenegade, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class BlackrockGrunt : BaseCreature
	{
		public BlackrockGrunt() : base()
		{
			Id = 440;
			Level = RandomLevel( 20 );
			Name = "Blackrock Grunt";
			NpcText01 = "Well, well... look what the cat brung in... and how can I help you, $c?";
			Model = 6033;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.372f;
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
			LearnSpell( 10852, SpellsTypes.Offensive );
			LearnSpell( 14030, SpellsTypes.Offensive );
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7428, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( BlackrockDrops.BlackrockGrunt, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class GathIlzogg : BaseCreature
	{
		public GathIlzogg() : base()
		{
			Id = 334;
			Level = RandomLevel( 26 );
			Name = "Gath'Ilzogg";
			Guild = "Warlord of the Blackrock Clan";
			Model = 6050;
			AttackSpeed = 2000;
			CombatReach = 2.25f;
			BoundingRadius = 0.558f;
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
			Equip( new Item ( 7482, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0), new Item ( 1755, (InventoryTypes)14, 4, 6, 1, 4, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( BlackrockDrops.GathIlzogg, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	
	
	
}