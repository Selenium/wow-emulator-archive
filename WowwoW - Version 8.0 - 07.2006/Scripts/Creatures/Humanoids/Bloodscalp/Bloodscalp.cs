using System;
using Server;
using Server.Items;
using Server.Quests;

namespace Server.Creatures
{
	public class BloodscalpAxeThrower : BaseCreature
	{
		public BloodscalpAxeThrower() : base()
		{
			Id = 694;
			Level = RandomLevel( 33 );
			Name = "Bloodscalp Axe Thrower";
			Model = 4572;
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
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Syndicate;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7429, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0), new Item ( 16751, (InventoryTypes)25, 2, 16, 1, 0, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f )
				, new BaseTreasure( BloodscalpDrops.BloodscalpAxeThrower, 100f ) };
		}
	}
	public class BloodscalpBeastmaster : BaseCreature
	{
		public BloodscalpBeastmaster() : base()
		{
			Id = 699;
			Level = RandomLevel( 35 );
			Name = "Bloodscalp Beastmaster";
			Model = 4576;
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
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Syndicate;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7426, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0), new Item ( 6233, (InventoryTypes)15, 2, 2, 2, 0, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f )
				, new BaseTreasure( BloodscalpDrops.BloodscalpBeastmaster, 100f ) };
		}
	}
	public class BloodscalpBerserker : BaseCreature
	{
		public BloodscalpBerserker() : base()
		{
			Id = 597;
			Level = RandomLevel( 36 );
			Name = "Bloodscalp Berserker";
			Model = 4579;
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
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Syndicate;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 3797, (InventoryTypes)17, 2, 1, 1, 1, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f )
				, new BaseTreasure( BloodscalpDrops.BloodscalpBerserker, 100f ) };
		}
	}
	public class Ganzulah : BaseCreature
	{
		public Ganzulah() : base()
		{
			Id = 1061;
			Level = RandomLevel( 41 );
			Name = "Gan'zulah";
			Guild = "Bloodscalp Chief";
			Model = 4582;
			AttackSpeed = 1300;
			CombatReach = 2.25f;
			BoundingRadius = 0.459f;
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
			Elite = 4;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Syndicate;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7427, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0), new Item ( 7427, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f )
				, new BaseTreasure( BloodscalpDrops.Ganzulah, 100f ) };
		}
	}
	public class NezzliokTheDire : BaseCreature
	{
		public NezzliokTheDire() : base()
		{
			Id = 1062;
			Level = RandomLevel( 40 );
			Name = "Nezzliok the Dire";
			Guild = "Bloodscalp Clan Witchdoctor";
			Model = 4584;
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
			Faction = Factions.Syndicate;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 1926, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f )
				, new BaseTreasure( BloodscalpDrops.NezzliokTheDire, 100f ) };
		}
	}
	public class BloodscalpHeadhunter : BaseCreature
	{
		public BloodscalpHeadhunter() : base()
		{
			Id = 671;
			Level = RandomLevel( 36 );
			Name = "Bloodscalp Headhunter";
			Model = 4580;
			AttackSpeed = 2000;
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
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Syndicate;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7427, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0), new Item ( 22671, (InventoryTypes)25, 2, 16, 1, 0, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f )
				, new BaseTreasure( BloodscalpDrops.BloodscalpHeadhunter, 100f ) };
		}
	}
	public class BloodscalpHunter : BaseCreature
	{
		public BloodscalpHunter() : base()
		{
			Id = 595;
			Level = RandomLevel( 34 );
			Name = "Bloodscalp Hunter";
			Model = 4574;
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
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Syndicate;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7433, (InventoryTypes)13, 2, 15, 1, 3, 0, 0, 0), new Item ( 22671, (InventoryTypes)25, 2, 16, 1, 0, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f )
				, new BaseTreasure( BloodscalpDrops.BloodscalpHunter, 100f ) };
		}
	}
	public class BloodscalpMystic : BaseCreature
	{
		public BloodscalpMystic() : base()
		{
			Id = 701;
			Level = RandomLevel( 34 );
			Name = "Bloodscalp Mystic";
			Model = 4577;
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
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Syndicate;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 1600, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f )
				, new BaseTreasure( BloodscalpDrops.BloodscalpMystic, 100f ) };
		}
	}
	public class BloodscalpScavenger : BaseCreature
	{
		public BloodscalpScavenger() : base()
		{
			Id = 702;
			Level = RandomLevel( 34 );
			Name = "Bloodscalp Scavenger";
			Model = 4571;
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
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Syndicate;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7434, (InventoryTypes)13, 2, 15, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f )
				, new BaseTreasure( BloodscalpDrops.BloodscalpScavenger, 100f ) };
		}
	}
	public class BloodscalpScout : BaseCreature
	{
		public BloodscalpScout() : base()
		{
			Id = 588;
			Level = RandomLevel( 35 );
			Name = "Bloodscalp Scout";
			Model = 4575;
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
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Syndicate;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7434, (InventoryTypes)13, 2, 15, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f )
				, new BaseTreasure( BloodscalpDrops.BloodscalpScout, 100f ) };
		}
	}
	public class BloodscalpShaman : BaseCreature
	{
		public BloodscalpShaman() : base()
		{
			Id = 697;
			Level = RandomLevel( 34 );
			Name = "Bloodscalp Shaman";
			Model = 4573;
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
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Syndicate;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 1600, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f )
				, new BaseTreasure( BloodscalpDrops.BloodscalpShaman, 100f ) };
		}
	}
/*	Please have a look at this
	public class BloodscalpSpeaker : BaseCreature
	{
		public BloodscalpSpeaker : Base
		{
			Id = 11389;
			Level = RandomLevel( 61 );
			Name = "Bloodscalp Speaker";
			Model = ?;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.795f;
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
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			ManaType = 1;
			BaseMana = 100;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = (Factions)?;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( BloodscalpDrops.BloodscalpSpeaker, 100f ) };
		}
	}
*/
	public class BloodscalpWarrior : BaseCreature
	{
		public BloodscalpWarrior() : base()
		{
			Id = 587;
			Level = RandomLevel( 33 );
			Name = "Bloodscalp Warrior";
			Model = 4570;
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
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Syndicate;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7440, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0), new Item ( 1706, (InventoryTypes)14, 4, 6, 1, 4, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f )
				, new BaseTreasure( BloodscalpDrops.BloodscalpWarrior, 100f ) };
		}
	}
	public class BloodscalpWitchDoctor : BaseCreature
	{
		public BloodscalpWitchDoctor() : base()
		{
			Id = 660;
			Level = RandomLevel( 37 );
			Name = "Bloodscalp Witch Doctor";
			Model = 4581;
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
			Faction = Factions.Syndicate;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 1600, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f )
				, new BaseTreasure( BloodscalpDrops.BloodscalpWitchDoctor, 100f ) };
		}
	}
}