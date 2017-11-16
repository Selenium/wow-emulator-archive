using System;
using Server;
using Server.Items;
using Server.Quests;

namespace Server.Creatures
{
	public class ZanzilWitchDoctor : BaseCreature
	{
		public ZanzilWitchDoctor() : base()
		{
			Id = 1490;
			Level = RandomLevel( 44 );
			Name = "Zanzil Witch Doctor";
			Model = 317;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.522f;
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
			Faction = Factions.BlacksmithingSwordSmithing;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7479, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyC , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f )
				, new BaseTreasure( ZanzilDrops.ZanzilWitchDoctor, 100f ) };
		}
	}
	public class ZanzilTheOutcast : BaseCreature
	{
		public ZanzilTheOutcast() : base()
		{
			Id = 2534;
			Level = RandomLevel( 46 );
			Name = "Zanzil the Outcast";
			Model = 314;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.522f;
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
			Faction = Factions.BlacksmithingSwordSmithing;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 2840, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyC , 100f )
				, new BaseTreasure( WorldDrops.AmazingDrops, 100f )
				, new BaseTreasure( ZanzilDrops.ZanzilTheOutcast, 100f ) };
		}
	}
	public class ZanzilZombie : BaseCreature
	{
		public ZanzilZombie() : base()
		{
			Id = 1488;
			Level = RandomLevel( 44 );
			Name = "Zanzil Zombie";
			Model = 1065;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.533f;
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
			NpcType = (int)NpcTypes.Undead;
			Faction = Factions.BlacksmithingSwordSmithing;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyC , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f )
				, new BaseTreasure( ZanzilDrops.ZanzilZombie, 100f ) };
		}
	}
	public class ZanzilHunter : BaseCreature
	{
		public ZanzilHunter() : base()
		{
			Id = 1489;
			Level = RandomLevel( 44 );
			Name = "Zanzil Hunter";
			Model = 828;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.533f;
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
			NpcType = (int)NpcTypes.Undead;
			Faction = Factions.BlacksmithingSwordSmithing;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7481, (InventoryTypes)17, 2, 6, 1, 2, 0, 0, 0), new Item ( 22671, (InventoryTypes)25, 2, 16, 1, 0, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyC , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f )
				, new BaseTreasure( ZanzilDrops.ZanzilHunter, 100f ) };
		}
	}
	public class ZanzilNaga : BaseCreature
	{
		public ZanzilNaga() : base()
		{
			Id = 1491;
			Level = RandomLevel( 44 );
			Name = "Zanzil Naga";
			Model = 4923;
			AttackSpeed = 2000;
			CombatReach = 1.95f;
			BoundingRadius = 0.757f;
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
			Flags1 = 0x010080000;
			NpcType = (int)NpcTypes.Undead;
			Faction = Factions.BlacksmithingSwordSmithing;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7428, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyC , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f )
				, new BaseTreasure( ZanzilDrops.ZanzilNaga, 100f ) };
		}
	}
	public class ZanzilSkeleton : BaseCreature
	{
		public ZanzilSkeleton() : base()
		{
			Id = 6388;
			Level = RandomLevel( 45 );
			Name = "Zanzil Skeleton";
			Model = 200;
			AttackSpeed = 2000;
			CombatReach = 1.27f;
			BoundingRadius = 0.3349f;
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
			Flags1 = 0x04;
			NpcType = (int)NpcTypes.Undead;
			Faction = Factions.BlacksmithingSwordSmithing;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyC , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f )
				, new BaseTreasure( ZanzilDrops.ZanzilSkeleton, 100f ) };
		}
	}
}