using System;
using Server;
using Server.Items;
using Server.Quests;

namespace Server.Creatures
{	
	public class SandfuryAcolyte : BaseCreature
	{
		public SandfuryAcolyte() : base()
		{
			Id = 8876;
			Level = RandomLevel( 40 ,44 );
			Name = "Sandfury Acolyte";
			Model = 6411;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			Flags1 = 0x080004;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.BlacksmithingAxeSmithing;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 1600, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyC , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f ) };
		}
	}
	public class SandfuryAxeThrower : BaseCreature
	{
		public SandfuryAxeThrower() : base()
		{
			Id = 5646;
			Level = RandomLevel( 37, 44 );
			Name = "Sandfury Axe Thrower";
			Model = 6412;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.ThoriumBrotherhood;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7426, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0), new Item ( 16751, (InventoryTypes)25, 2, 16, 1, 0, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f )
				, new BaseTreasure( SandfuryDrops.SandfuryAxeThrower, 100f ) };
		}
	}
	public class SandfuryBloodDrinker : BaseCreature
	{
		public SandfuryBloodDrinker() : base()
		{
			Id = 5649;
			Level = RandomLevel( 39, 45 );
			Name = "Sandfury Blood Drinker";
			Model = 6423;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.ThoriumBrotherhood;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 5175, (InventoryTypes)17, 2, 8, 1, 1, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f )
				, new BaseTreasure( SandfuryDrops.SandfuryBloodDrinker, 100f ) };
		}
	}
	public class SandfuryCretin : BaseCreature
	{
		public SandfuryCretin() : base()
		{
			Id = 7789;
			Level = RandomLevel( 40, 45 );
			Name = "Sandfury Cretin";
			Model = 6682;
			AttackSpeed = 2000;
			CombatReach = 1.65f;
			BoundingRadius = 0.3366f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.ThoriumBrotherhood;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 5527, (InventoryTypes)17, 2, 5, 2, 1, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f )
				, new BaseTreasure( SandfuryDrops.SandfuryCretin, 100f ) };
		}
	}
	public class SandfuryDrudge : BaseCreature
	{
		public SandfuryDrudge() : base()
		{
			Id = 7788;
			Level = RandomLevel( 40, 45 );
			Name = "Sandfury Drudge";
			Model = 6681;
			AttackSpeed = 2000;
			CombatReach = 1.35f;
			BoundingRadius = 0.2754f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			Flags1 = 0x080004;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.ThoriumBrotherhood;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7495, (InventoryTypes)17, 2, 6, 1, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyC , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f) };
		}
	}
	public class SandfuryExecutioner : BaseCreature
	{
		public SandfuryExecutioner() : base()
		{
			Id = 7274;
			Level = RandomLevel( 42, 46 );
			Name = "Sandfury Executioner";
			Model = 6440;
			AttackSpeed = 2600;
			CombatReach = 2.0f;
			BoundingRadius = 0.3672f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.ThoriumBrotherhood;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 5128, (InventoryTypes)17, 2, 1, 1, 1, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.AmazingDrops, 100f )
				, new BaseTreasure( SandfuryDrops.SandfuryExecutioner, 100f ) };
		}
	}
	public class SandfuryFirecaller : BaseCreature
	{
		public SandfuryFirecaller() : base()
		{
			Id = 5647;
			Level = RandomLevel( 38, 44 );
			Name = "Sandfury Firecaller";
			Model = 6416;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.ThoriumBrotherhood;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 5010, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f )
				, new BaseTreasure( SandfuryDrops.SandfuryFirecaller, 100f ) };
		}
	}
	public class SandfuryGuardian : BaseCreature
	{
		public SandfuryGuardian() : base()
		{
			Id = 7268;
			Level = RandomLevel( 40, 46 );
			Name = "Sandfury Guardian";
			Model = 4305;
			AttackSpeed = 1700;
			CombatReach = 1.25f;
			BoundingRadius = 0.561f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 0.5f + Level/100f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			ManaType = 1;
			BaseMana = 100;
			Flags1 = 0x010080000;
			NpcType = (int)NpcTypes.Beast;
			Faction = Factions.ThoriumBrotherhood;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( SandfuryDrops.SandfuryGuardian, 100f ) };
		}
	}
	public class SandfuryHideskinner : BaseCreature
	{
		public SandfuryHideskinner() : base()
		{
			Id = 5645;
			Level = RandomLevel( 10, 43 );
			Name = "Sandfury Hideskinner";
			Model = 6413;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.ThoriumBrotherhood;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 6434, (InventoryTypes)13, 2, 15, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f )
				, new BaseTreasure( SandfuryDrops.SandfuryHideskinner, 100f ) };
		}
	}
	public class SandfuryShadowcaster : BaseCreature
	{
		public SandfuryShadowcaster() : base()
		{
			Id = 5648;
			Level = RandomLevel( 38, 44 );
			Name = "Sandfury Shadowcaster";
			Model = 6419;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.ThoriumBrotherhood;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f )
				, new BaseTreasure( SandfuryDrops.SandfuryShadowcaster, 100f ) };
		}
	}
	public class SandfuryShadowhunter : BaseCreature
	{
		public SandfuryShadowhunter() : base()
		{
			Id = 7246;
			Level = RandomLevel( 40, 46 );
			Name = "Sandfury Shadowhunter";
			Model = 6425;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.ThoriumBrotherhood;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7420, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0), new Item ( 6231, (InventoryTypes)15, 2, 2, 2, 0, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f )
				, new BaseTreasure( SandfuryDrops.SandfuryShadowhunter, 100f ) };
		}
	}
	public class SandfurySlave : BaseCreature
	{
		public SandfurySlave() : base()
		{
			Id = 7787;
			Level = RandomLevel( 40, 44 );
			Name = "Sandfury Slave";
			Model = 6678;
			AttackSpeed = 2000;
			CombatReach = 1.3f;
			BoundingRadius = 0.2448f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			Flags1 = 0x080004;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.ThoriumBrotherhood;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7493, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyC , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f )
				, new BaseTreasure( SandfuryDrops.SandfurySlave, 100f ) };
		}
	}
	public class SandfurySoulEater : BaseCreature
	{
		public SandfurySoulEater() : base()
		{
			Id = 7247;
			Level = RandomLevel( 40, 46 );
			Name = "Sandfury Soul Eater";
			Model = 6427;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.ThoriumBrotherhood;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 2469, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.AmazingDrops, 100f )
				, new BaseTreasure( SandfuryDrops.SandfurySoulEater, 100f ) };
		}
	}
/*	please have a look at this
	public class SandfurySpeaker : BaseCreature
	{
		public SandfurySpeaker : base()
		{
			Id = 11387;
			Level = RandomLevel( 59, 61 );
			Name = "Sandfury Speaker";
			Model = ?;
			AttackSpeed = 2000;
			CombatReach = 1.65f;
			BoundingRadius = 0.3366f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = (Factions)?;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 1600, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyC , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f )
				, new BaseTreasure( SandfuryDrops.SandfurySpeaker, 100f ) };
		}
	}
*/
	public class SandfuryWitchDoctor : BaseCreature
	{
		public SandfuryWitchDoctor() : base()
		{
			Id = 5650;
			Level = RandomLevel( 39, 45 );
			Name = "Sandfury Witch Doctor";
			Model = 6421;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.ThoriumBrotherhood;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 1600, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f )
				, new BaseTreasure( SandfuryDrops.SandfuryWitchDoctor, 100f ) };
		}
	}
	public class SandfuryZealot : BaseCreature
	{
		public SandfuryZealot() : base()
		{
			Id = 8877;
			Level = RandomLevel( 42, 123 );
			Name = "Sandfury Zealot";
			Model = 6423;
			AttackSpeed = 2400;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			Flags1 = 0x080004;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.ThoriumBrotherhood;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7490, (InventoryTypes)17, 2, 8, 1, 1, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyC , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f ) };
		}
	}
}