using System;
using Server;
using Server.Items;
using Server.Quests;

namespace Server.Creatures
{
	public class VilebranchKidnapper : BaseCreature
	{
		public VilebranchKidnapper() : base()
		{
			Id = 14748;
			Level = RandomLevel( 49 );
			Name = "Vilebranch Kidnapper";
			Model = 6512;
			AttackSpeed = 1441;
			CombatReach = 1.15f;
			BoundingRadius = 0.85f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 20;
			ResistFire = 70;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( WorldDrops.AmazingDrops, 100f )
				, new BaseTreasure(Drops.MoneyC , 100f )
				, new BaseTreasure( VilebranchDrops.VilebranchKidnapper, 100f ) };
		}
	}
	public class VilebranchAmbusher : BaseCreature
	{
		public VilebranchAmbusher() : base()
		{
			Id = 7809;
			Level = RandomLevel( 46 ,47 );
			Name = "Vilebranch Ambusher";
			Model = 6512;
			AttackSpeed = 1483;
			CombatReach = 0.8f;
			BoundingRadius = 0.561f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 20;
			ResistFire = 70;
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
			Loots = new BaseTreasure[]{ new BaseTreasure( WorldDrops.AmazingDrops, 100f )
				, new BaseTreasure(Drops.MoneyC , 100f )
				, new BaseTreasure( VilebranchDrops.VilebranchAmbusher, 100f ) };
		}
	}
	public class VilebranchWarrior : BaseCreature
	{
		public VilebranchWarrior() : base()
		{
			Id = 4465;
			Level = RandomLevel( 46 );
			Name = "Vilebranch Warrior";
			Model = 6509;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 20;
			ResistFire = 70;
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
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Beatstick());
			Loots = new BaseTreasure[]{ new BaseTreasure( WorldDrops.AmazingDrops, 100f )
				, new BaseTreasure(Drops.MoneyC , 100f )
				, new BaseTreasure( VilebranchDrops.VilebranchWarrior, 100f ) };
		}
	}
	public class VilebranchScalper : BaseCreature
	{
		public VilebranchScalper() : base()
		{
			Id = 4466;
			Level = RandomLevel( 47 );
			Name = "Vilebranch Scalper";
			Model = 6513;
			AttackSpeed = 2000;
			CombatReach = 1.57f;
			BoundingRadius = 0.3213f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 20;
			ResistFire = 70;
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
			Equip( new Item ( 7426, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( WorldDrops.AmazingDrops, 100f )
				, new BaseTreasure(Drops.MoneyC , 100f )
				, new BaseTreasure( VilebranchDrops.VilebranchScalper, 100f ) };
		}
	}
	public class VilebranchSoothsayer : BaseCreature
	{
		public VilebranchSoothsayer() : base()
		{
			Id = 4467;
			Level = RandomLevel( 47 );
			Name = "Vilebranch Soothsayer";
			Model = 6536;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 20;
			ResistFire = 70;
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
			Loots = new BaseTreasure[]{ new BaseTreasure( WorldDrops.AmazingDrops, 100f )
				, new BaseTreasure(Drops.MoneyC , 100f )
				, new BaseTreasure( VilebranchDrops.VilebranchSoothsayer, 100f ) };
		}
	}
	public class VilebranchAxeThrower : BaseCreature
	{
		public VilebranchAxeThrower() : base()
		{
			Id = 2639;
			Level = RandomLevel( 45 );
			Name = "Vilebranch Axe Thrower";
			Model = 6491;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 20;
			ResistFire = 70;
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
			Equip( new Item ( 7426, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0), new Item ( 16751, (InventoryTypes)25, 2, 16, 1, 0, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( WorldDrops.HighDrops, 100f )
				, new BaseTreasure( Drops.MoneyC , 100f )
				, new BaseTreasure( VilebranchDrops.VilebranchAxeThrower, 100f ) };
		}
	}
	public class VilebranchWitchDoctor : BaseCreature
	{
		public VilebranchWitchDoctor() : base()
		{
			Id = 2640;
			Level = RandomLevel( 47 );
			Name = "Vilebranch Witch Doctor";
			Model = 6542;
			AttackSpeed = 2000;
			CombatReach = 1.57f;
			BoundingRadius = 0.3213f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 20;
			ResistFire = 70;
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
			Equip( new Item ( 1926, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( WorldDrops.AmazingDrops, 100f )
				, new BaseTreasure(Drops.MoneyC , 100f )
				, new BaseTreasure( VilebranchDrops.VilebranchWitchDoctor, 100f ) };
		}
	}
	public class VilebranchHeadhunter : BaseCreature
	{
		public VilebranchHeadhunter() : base()
		{
			Id = 2641;
			Level = RandomLevel( 46 );
			Name = "Vilebranch Headhunter";
			Model = 6498;
			AttackSpeed = 2000;
			CombatReach = 1.57f;
			BoundingRadius = 0.3213f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 20;
			ResistFire = 70;
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
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7481, (InventoryTypes)17, 2, 6, 1, 2, 0, 0, 0), new Item ( 22671, (InventoryTypes)25, 2, 16, 1, 0, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( WorldDrops.AmazingDrops, 100f )
				, new BaseTreasure(Drops.MoneyC , 100f )
				, new BaseTreasure( VilebranchDrops.VilebranchHeadhunter, 100f ) };
		}
	}
	public class VilebranchShadowcaster : BaseCreature
	{
		public VilebranchShadowcaster() : base()
		{
			Id = 2642;
			Level = RandomLevel( 48 );
			Name = "Vilebranch Shadowcaster";
			Model = 6514;
			AttackSpeed = 2000;
			CombatReach = 1.57f;
			BoundingRadius = 0.3213f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 20;
			ResistFire = 70;
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
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 2469, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0), new Item ( 1705, (InventoryTypes)14, 4, 6, 1, 4, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( WorldDrops.AmazingDrops, 100f )
				, new BaseTreasure(Drops.MoneyC , 100f )
				, new BaseTreasure( VilebranchDrops.VilebranchShadowcaster, 100f ) };
		}
	}
	public class VilebranchBerserker : BaseCreature
	{
		public VilebranchBerserker() : base()
		{
			Id = 2643;
			Level = RandomLevel( 48 );
			Name = "Vilebranch Berserker";
			Model = 6494;
			AttackSpeed = 2000;
			CombatReach = 1.65f;
			BoundingRadius = 0.3366f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 20;
			ResistFire = 70;
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
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7508, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0), new Item ( 7508, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( WorldDrops.AmazingDrops, 100f )
				, new BaseTreasure(Drops.MoneyC , 100f )
				, new BaseTreasure( VilebranchDrops.VilebranchBerserker, 100f ) };
		}
	}
	public class VilebranchHideskinner : BaseCreature
	{
		public VilebranchHideskinner() : base()
		{
			Id = 2644;
			Level = RandomLevel( 48 );
			Name = "Vilebranch Hideskinner";
			Model = 6511;
			AttackSpeed = 2000;
			CombatReach = 1.07f;
			BoundingRadius = 0.3519f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 20;
			ResistFire = 70;
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
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new CrossDagger(), new Item ( 7434, (InventoryTypes)13, 2, 15, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( WorldDrops.AmazingDrops, 100f )
				, new BaseTreasure(Drops.MoneyC , 100f )
				, new BaseTreasure( VilebranchDrops.VilebranchHideskinner, 100f ) };
		}
	}
	public class VilebranchShadowHunter : BaseCreature
	{
		public VilebranchShadowHunter() : base()
		{
			Id = 2645;
			Level = RandomLevel( 49 );
			Name = "Vilebranch Shadow Hunter";
			Model = 6539;
			AttackSpeed = 2000;
			CombatReach = 1.57f;
			BoundingRadius = 0.3213f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 20;
			ResistFire = 70;
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
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7427, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0), new Item ( 6231, (InventoryTypes)15, 2, 2, 2, 0, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( WorldDrops.AmazingDrops, 100f )
				, new BaseTreasure(Drops.MoneyC , 100f )
				, new BaseTreasure( VilebranchDrops.VilebranchShadowHunter, 100f ) };
		}
	}
	public class VilebranchBloodDrinker : BaseCreature
	{
		public VilebranchBloodDrinker() : base()
		{
			Id = 2646;
			Level = RandomLevel( 50 );
			Name = "Vilebranch Blood Drinker";
			Model = 6496;
			AttackSpeed = 2000;
			CombatReach = 1.07f;
			BoundingRadius = 0.3519f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 20;
			ResistFire = 70;
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
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 3385, (InventoryTypes)17, 2, 1, 1, 1, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( WorldDrops.AmazingDrops, 100f )
				, new BaseTreasure(Drops.MoneyC , 100f )
				, new BaseTreasure( VilebranchDrops.VilebranchBloodDrinker, 100f ) };
		}
	}
	public class VilebranchSoulEater : BaseCreature
	{
		public VilebranchSoulEater() : base()
		{
			Id = 2647;
			Level = RandomLevel( 49 );
			Name = "Vilebranch Soul Eater";
			Model = 6540;
			AttackSpeed = 2000;
			CombatReach = 2.0f;
			BoundingRadius = 0.3672f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 20;
			ResistFire = 70;
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
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7469, (InventoryTypes)13, 2, 4, 2, 7, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( WorldDrops.AmazingDrops, 100f )
				, new BaseTreasure(Drops.MoneyC , 100f )
				, new BaseTreasure( VilebranchDrops.VilebranchSoulEater, 100f ) };
		}
	}
	public class VilebranchAmanzasiGuard : BaseCreature
	{
		public VilebranchAmanzasiGuard() : base()
		{
			Id = 2648;
			Level = RandomLevel( 49 ,51 );
			Name = "Vilebranch Aman'zasi Guard";
			Model = 6997;
			AttackSpeed = 1178;
			CombatReach = 1.5f;
			BoundingRadius = 0.561f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 20;
			ResistFire = 70;
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
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( WorldDrops.AmazingDrops, 100f )
				, new BaseTreasure(Drops.MoneyC , 100f )
				, new BaseTreasure( VilebranchDrops.VilebranchAmanzasiGuard, 100f ) };
		}
	}
	
}