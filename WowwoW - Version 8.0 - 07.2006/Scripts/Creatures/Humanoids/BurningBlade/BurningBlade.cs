using System;
using Server;
using Server.Items;
using Server.Quests;

namespace Server.Creatures
{
	public class BurningBladeSeer : BaseCreature
	{
		public BurningBladeSeer() : base()
		{
			Id = 13019;
			Level = RandomLevel( 33 );
			Name = "Burning Blade Seer";
			Model = 4707;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.236f;
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
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 1927, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( BurningDrops.BurningBladeSeer, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class BurningBladeToxicologist : BaseCreature
	{
		public BurningBladeToxicologist() : base()
		{
			Id = 12319;
			Level = RandomLevel( 14 );
			Name = "Burning Blade Toxicologist";
			Model = 4196;
			AttackSpeed = 1917;
			CombatReach = 0.81f;
			BoundingRadius = 0.51f;
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
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( BurningDrops.BurningBladeToxicologist, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class BurningBladeCrusher : BaseCreature
	{
		public BurningBladeCrusher() : base()
		{
			Id = 12320;
			Level = RandomLevel( 13 );
			Name = "Burning Blade Crusher";
			Model = 4198;
			AttackSpeed = 1932;
			CombatReach = 0.81f;
			BoundingRadius = 0.51f;
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
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( BurningDrops.BurningBladeCrusher, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class BurningBladeAugur : BaseCreature
	{
		public BurningBladeAugur() : base()
		{
			Id = 4663;
			Level = RandomLevel( 31 );
			Name = "Burning Blade Augur";
			Model = 4700;
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
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 2840, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( BurningDrops.BurningBladeAugur, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class BurningBladeReaver : BaseCreature
	{
		public BurningBladeReaver() : base()
		{
			Id = 4664;
			Level = RandomLevel( 31 );
			Name = "Burning Blade Reaver";
			Model = 4703;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
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
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 5175, (InventoryTypes)17, 2, 8, 1, 1, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( BurningDrops.BurningBladeReaver, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class BurningBladeAdept : BaseCreature
	{
		public BurningBladeAdept() : base()
		{
			Id = 4665;
			Level = RandomLevel( 32 );
			Name = "Burning Blade Adept";
			Model = 4698;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.236f;
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
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 2469, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( BurningDrops.BurningBladeAdept, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class BurningBladeFelsworn : BaseCreature
	{
		public BurningBladeFelsworn() : base()
		{
			Id = 4666;
			Level = RandomLevel( 32 );
			Name = "Burning Blade Felsworn";
			Model = 4702;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.236f;
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
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			NpcFlags = 0;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 6469, (InventoryTypes)13, 2, 15, 1, 3, 0, 0, 0), new Item ( 6443, (InventoryTypes)13, 2, 15, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( BurningDrops.BurningBladeFelsworn, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class BurningBladeShadowmage : BaseCreature
	{
		public BurningBladeShadowmage() : base()
		{
			Id = 4667;
			Level = RandomLevel( 33 );
			Name = "Burning Blade Shadowmage";
			Model = 4706;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.236f;
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
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 1927, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( BurningDrops.BurningBladeShadowmage, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class BurningBladeSummoner : BaseCreature
	{
		public BurningBladeSummoner() : base()
		{
			Id = 4668;
			Level = RandomLevel( 38 );
			Name = "Burning Blade Summoner";
			Model = 4710;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.383f;
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
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			NpcFlags = 0;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 1600, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( BurningDrops.BurningBladeSummoner, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class BurningBladeInvoker : BaseCreature
	{
		public BurningBladeInvoker() : base()
		{
			Id = 4705;
			Level = RandomLevel( 39 ,40 );
			Name = "Burning Blade Invoker";
			Model = 4708;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.236f;
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
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 1927, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( BurningDrops.BurningBladeInvoker, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class BurningBladeAcolyte : BaseCreature
	{
		public BurningBladeAcolyte() : base()
		{
			Id = 3380;
			Level = RandomLevel( 11 );
			Name = "Burning Blade Acolyte";
			Model = 4197;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.236f;
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
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			NpcFlags = 0;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7434, (InventoryTypes)13, 2, 15, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( BurningDrops.BurningBladeAcolyte, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	
	public class BurningBladeThug : BaseCreature
	{
		public BurningBladeThug() : base()
		{
			Id = 3195;
			Level = RandomLevel( 8 );
			Name = "Burning Blade Thug";
			Model = 4189;
			AttackSpeed = 3100;
			CombatReach = 1.5f;
			BoundingRadius = 0.236f;
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
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			NpcFlags = 0;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7432, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( BurningDrops.BurningBladeThug, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class BurningBladeNeophyte : BaseCreature
	{
		public BurningBladeNeophyte() : base()
		{
			Id = 3196;
			Level = RandomLevel( 9 );
			Name = "Burning Blade Neophyte";
			Model = 4186;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.236f;
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
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			NpcFlags = 0;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7476, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( BurningDrops.BurningBladeNeophyte, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class FizzleDarkstorm : BaseCreature
	{
		public FizzleDarkstorm() : base()
		{
			Id = 3203;
			Level = RandomLevel( 12 );
			Name = "Fizzle Darkstorm";
			Model = 7128;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
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
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			NpcFlags = 0;
			AIEngine = new SpellCasterAI( this );
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			LearnSpell( 688, SpellsTypes.Offensive );
			//LearnSpell( 7290, SpellsTypes.Offensive );
			Equip( new Item ( 1599, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( BurningDrops.FizzleDarkstorm, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class NeeruFireblade : BaseNPC
	{
		public NeeruFireblade() : base()
		{
			Id = 3216;
			Level = RandomLevel( 37 );
			Name = "Neeru Fireblade";
			NpcText00 = "Greetings $N, I am Neeru Fireblade.";
			Model = 3754;
			AttackSpeed = 1739;
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
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x08480046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Ogrimmar;
			AIEngine = new DefensiveAnimalAI( this );
			Equip( new Item ( 2469, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
		}
	}
	public class BurningBladeFanatic : BaseCreature
	{
		public BurningBladeFanatic() : base()
		{
			Id = 3197;
			Level = RandomLevel( 10 );
			Name = "Burning Blade Fanatic";
			Model = 4192;
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
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			NpcFlags = 0;
			Flags1 = 0x080000;
			LearnSpell( 5262, SpellsTypes.Offensive );
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7490, (InventoryTypes)17, 2, 8, 1, 1, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( BurningDrops.BurningBladeFanatic, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class BurningBladeApprentice : BaseCreature
	{
		public BurningBladeApprentice() : base()
		{
			Id = 3198;
			Level = RandomLevel( 10 );
			Name = "Burning Blade Apprentice";
			Model = 4190;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.236f;
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
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			NpcFlags = 0;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7476, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( BurningDrops.BurningBladeApprentice, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class BurningBladeCultist : BaseCreature
	{
		public BurningBladeCultist() : base()
		{
			Id = 3199;
			Level = RandomLevel( 9 ,11 );
			Name = "Burning Blade Cultist";
			Model = 4194;
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
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			NpcFlags = 0;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 1599, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( BurningDrops.BurningBladeCultist, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	
	
}