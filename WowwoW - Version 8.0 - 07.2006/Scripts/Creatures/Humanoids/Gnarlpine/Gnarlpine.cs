using System;
using Server;
using Server.Items;
using Server.Quests;

namespace Server.Creatures
{
	public class GnarlpineAmbusher : BaseCreature
	{
		public GnarlpineAmbusher() : base()
		{
			Id = 2152;
			Level = RandomLevel( 7 );
			Name = "Gnarlpine Ambusher";
			Model = 3024;
			AttackSpeed = 2000;
			CombatReach = 1.25f;
			BoundingRadius = 0.561f;
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
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyA , 100f )
				, new BaseTreasure( WorldDrops.LowDrops, 100f )
				, new BaseTreasure( GnarlpineDrops.GnarlpineAmbusher, 100f ) };
		}
	}
	public class GnarlpineAugur : BaseCreature
	{
		public GnarlpineAugur() : base()
		{
			Id = 2011;
			Level = RandomLevel( 8 );
			Name = "Gnarlpine Augur";
			Model = 3024;
			AttackSpeed = 2000;
			CombatReach = 1.25f;
			BoundingRadius = 0.561f;
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
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7431, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyA , 100f )
				, new BaseTreasure( WorldDrops.LowDrops, 100f )
				, new BaseTreasure( GnarlpineDrops.GnarlpineAugur, 100f ) };
		}
	}
	public class GnarlpineAvenger : BaseCreature
	{
		public GnarlpineAvenger() : base()
		{
			Id = 2013;
			Level = RandomLevel( 9 );
			Name = "Gnarlpine Avenger";
			Model = 6803;
			AttackSpeed = 2000;
			CombatReach = 1.62f;
			BoundingRadius = 0.51f;
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
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7488, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyA , 100f )
				, new BaseTreasure( WorldDrops.LowDrops, 100f )
				, new BaseTreasure( GnarlpineDrops.GnarlpineAvenger, 100f ) };
		}
	}
	public class GnarlpineDefender : BaseCreature
	{
		public GnarlpineDefender() : base()
		{
			Id = 2010;
			Level = RandomLevel( 8 );
			Name = "Gnarlpine Defender";
			Model = 6801;
			AttackSpeed = 2000;
			CombatReach = 1.37f;
			BoundingRadius = 0.464f;
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
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7444, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyA , 100f )
				, new BaseTreasure( WorldDrops.LowDrops, 100f )
				, new BaseTreasure( GnarlpineDrops.GnarlpineDefender, 100f ) };
		}
	}
	public class GnarlpineGardener : BaseCreature
	{
		public GnarlpineGardener() : base()
		{
			Id = 2007;
			Level = RandomLevel( 5 );
			Name = "Gnarlpine Gardener";
			Model = 6799;
			AttackSpeed = 2000;
			CombatReach = 1.12f;
			BoundingRadius = 0.723f;
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
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7495, (InventoryTypes)17, 2, 6, 1, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyA , 100f )
				, new BaseTreasure( WorldDrops.BeginnerDrops, 100f )
				, new BaseTreasure( GnarlpineDrops.GnarlpineGardener, 100f ) };
		}
	}
	public class GnarlpineInstigator : BaseCreature
	{
		public GnarlpineInstigator() : base()
		{
			Id = 11690;
			Level = RandomLevel( 8 );
			Name = "Gnarlpine Instigator";
			Model = 3024;
			AttackSpeed = 2000;
			CombatReach = 1.25f;
			BoundingRadius = 0.561f;
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
			Flags1 = 0x080006;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyA , 100f )
				, new BaseTreasure( WorldDrops.LowDrops, 100f ) };
		}
	}
	public class GnarlpineMystic : BaseCreature
	{
		public GnarlpineMystic() : base()
		{
			Id = 7235;
			Level = RandomLevel( 7 );
			Name = "Gnarlpine Mystic";
			Model = 6804;
			AttackSpeed = 2000;
			CombatReach = 1.0f;
			BoundingRadius = 0.8f;
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
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 2840, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyA , 100f )
				, new BaseTreasure( WorldDrops.LowDrops, 100f )
				, new BaseTreasure( GnarlpineDrops.GnarlpineMystic, 100f ) };
		}
	}
	public class GnarlpinePathfinder : BaseCreature
	{
		public GnarlpinePathfinder() : base()
		{
			Id = 2012;
			Level = RandomLevel( 10 );
			Name = "Gnarlpine Pathfinder";
			Model = 6802;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.735f;
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
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7476, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyA , 100f )
				, new BaseTreasure( WorldDrops.LowDrops, 100f )
				, new BaseTreasure( GnarlpineDrops.GnarlpinePathfinder, 100f ) };
		}
	}
	public class GnarlpineShaman : BaseCreature
	{
		public GnarlpineShaman() : base()
		{
			Id = 2009;
			Level = RandomLevel( 7 );
			Name = "Gnarlpine Shaman";
			Model = 897;
			AttackSpeed = 2000;
			CombatReach = 1.25f;
			BoundingRadius = 0.561f;
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
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 1599, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyA , 100f )
				, new BaseTreasure( WorldDrops.LowDrops, 100f )
				, new BaseTreasure( GnarlpineDrops.GnarlpineShaman, 100f ) };
		}
	}
	public class GnarlpineTotemic : BaseCreature
	{
		public GnarlpineTotemic() : base()
		{
			Id = 2014;
			Level = RandomLevel( 11 );
			Name = "Gnarlpine Totemic";
			Model = 936;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.785f;
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
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7469, (InventoryTypes)13, 2, 4, 2, 7, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyA , 100f )
				, new BaseTreasure( WorldDrops.LowDrops, 100f )
				, new BaseTreasure( GnarlpineDrops.GnarlpineTotemic, 100f ) };
		}
	}
	public class GnarlpineUrsa : BaseCreature
	{
		public GnarlpineUrsa() : base()
		{
			Id = 2006;
			Level = RandomLevel( 6 );
			Name = "Gnarlpine Ursa";
			Model = 6798;
			AttackSpeed = 2000;
			CombatReach = 1.12f;
			BoundingRadius = 0.77f;
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
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyA , 100f )
				, new BaseTreasure( WorldDrops.LowDrops, 100f )
				, new BaseTreasure( GnarlpineDrops.GnarlpineUrsa, 100f ) };
		}
	}
	public class GnarlpineWarrior : BaseCreature
	{
		public GnarlpineWarrior() : base()
		{
			Id = 2008;
			Level = RandomLevel( 7 );
			Name = "Gnarlpine Warrior";
			Model = 6800;
			AttackSpeed = 2000;
			CombatReach = 1.25f;
			BoundingRadius = 0.561f;
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
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7440, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyA , 100f )
				, new BaseTreasure( WorldDrops.LowDrops, 100f )
				, new BaseTreasure( GnarlpineDrops.GnarlpineWarrior, 100f ) };
		}
	}
}