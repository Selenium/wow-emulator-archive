using System;
using Server;
using Server.Items;
using Server.Quests;

namespace Server.Creatures
{
	public class DalaranBrewmaster : BaseCreature
	{
		public DalaranBrewmaster() : base()
		{
			Id = 3577;
			Level = RandomLevel( 15 ,16 );
			Name = "Dalaran Brewmaster";
			Model = 3538;
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
			ResistHoly = 50;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Vendor;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Sells = new Item[] { new Server.Items.IceColdMilk()
				, new Server.Items.MelonJuice()
				, new Server.Items.MoonberryJuice()
				, new Server.Items.SweetNectar()
				, new Server.Items.RefreshingSpringWater18005()
				, new Server.Items.MorningGloryDew()
			 };
			Equip( new Item ( 24595, (InventoryTypes)13, 2, 14, 1, 0, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( WorldDrops.LowDrops, 100f )
				, new BaseTreasure(Drops.MoneyB , 100f ) 
				, new BaseTreasure( DalaranDrops.DalaranBrewmaster, 100f ) };
		}
	}
	public class DalaranMiner : BaseCreature
	{
		public DalaranMiner() : base()
		{
			Id = 3578;
			Level = RandomLevel( 15 ,16 );
			Name = "Dalaran Miner";
			Model = 3539;
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
			ResistHoly = 50;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Vendor;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Sells = new Item[] { new Server.Items.WeakFlux()
				, new Server.Items.MiningPick()
				, new Server.Items.StrongFlux()
				, new Server.Items.Coal()
			 };
			Equip( new Item ( 7493, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( WorldDrops.LowDrops, 100f )
				, new BaseTreasure(Drops.MoneyB , 100f ) 
				, new BaseTreasure( DalaranDrops.DalaranMiner, 100f ) };
		}
	}
	public class DalaranWorker : BaseCreature
	{
		public DalaranWorker() : base()
		{
			Id = 2628;
			Level = RandomLevel( 33 );
			Name = "Dalaran Worker";
			Model = 3720;
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
			ResistHoly = 50;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7439, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( WorldDrops.AdvancedDrops, 100f )
				, new BaseTreasure(Drops.MoneyB , 100f ) 
				, new BaseTreasure( DalaranDrops.DalaranWorker, 100f ) };
		}
	}
	public class DalaranSerpent : BaseCreature
	{
		public DalaranSerpent() : base()
		{
			Id = 2540;
			Level = RandomLevel( 15 );
			Name = "Dalaran Serpent";
			Model = 5966;
			AttackSpeed = 1000;
			CombatReach = 0.3f;
			BoundingRadius = 0.25f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 50;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			Flags1 = 0x01008C006;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( WorldDrops.LowDrops, 100f )
				, new BaseTreasure(Drops.MoneyB , 100f )  };
		}
	}
	public class DalaranSummoner : BaseCreature
	{
		public DalaranSummoner() : base()
		{
			Id = 2358;
			Level = RandomLevel( 35 );
			Name = "Dalaran Summoner";
			Model = 3719;
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
			ResistHoly = 50;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 1927, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( WorldDrops.AdvancedDrops, 100f )
				, new BaseTreasure(Drops.MoneyB , 100f ) 
				, new BaseTreasure( DalaranDrops.DalaranSummoner, 100f ) };
		}
	}
	public class DalaranShieldGuard : BaseCreature
	{
		public DalaranShieldGuard() : base()
		{
			Id = 2271;
			Level = RandomLevel( 32 );
			Name = "Dalaran Shield Guard";
			Model = 11474;
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
			ResistHoly = 50;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7484, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0), new Item ( 20537, (InventoryTypes)14, 4, 6, 1, 4, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( WorldDrops.AdvancedDrops, 100f )
				, new BaseTreasure(Drops.MoneyB , 100f ) 
				, new BaseTreasure( DalaranDrops.DalaranShieldGuard, 100f ) };
		}
	}
	public class DalaranTheurgist : BaseCreature
	{
		public DalaranTheurgist() : base()
		{
			Id = 2272;
			Level = RandomLevel( 32 );
			Name = "Dalaran Theurgist";
			Model = 3715;
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
			ResistHoly = 50;
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
			Loots = new BaseTreasure[]{ new BaseTreasure( WorldDrops.AdvancedDrops, 100f )
				, new BaseTreasure(Drops.MoneyB , 100f ) 
				, new BaseTreasure( DalaranDrops.DalaranTheurgist, 100f ) };
		}
	}
	public class DalaranProtector : BaseCreature
	{
		public DalaranProtector() : base()
		{
			Id = 1912;
			Level = RandomLevel( 14 );
			Name = "Dalaran Protector";
			Model = 3603;
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
			ResistHoly = 50;
			ResistNature = 0;
			ResistShadow = 0;
			// LearnSpell( 3615, SpellsTypes.Offensive ); Summon Dalaran Serpent
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7479, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( WorldDrops.LowDrops, 100f )
				, new BaseTreasure(Drops.MoneyB , 100f ) 
				, new BaseTreasure( DalaranDrops.DalaranProtector, 100f ) };
		}
	}
	public class DalaranWarder : BaseCreature
	{
		public DalaranWarder() : base()
		{
			Id = 1913;
			Level = RandomLevel( 16 );
			Name = "Dalaran Warder";
			Model = 3592;
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
			ResistHoly = 50;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7479, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0), new Item ( 1755, (InventoryTypes)14, 4, 6, 1, 4, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( WorldDrops.MediumDrops, 100f )
				, new BaseTreasure( Drops.MoneyA , 100f )
				, new BaseTreasure( DalaranDrops.DalaranWarder, 100f ) };
		}
	}
	public class DalaranMage : BaseCreature
	{
		public DalaranMage() : base()
		{
			Id = 1914;
			Level = RandomLevel( 15 );
			Name = "Dalaran Mage";
			Model = 3560;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.208f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 50;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			LearnSpell( 145, SpellsTypes.Offensive );
			LearnSpell( 134, SpellsTypes.Defensive );
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 1927, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( WorldDrops.LowDrops, 100f )
				, new BaseTreasure(Drops.MoneyB , 100f ) 
				, new BaseTreasure( DalaranDrops.DalaranMage, 100f ) };
		}
	}
	public class DalaranConjuror : BaseCreature
	{
		public DalaranConjuror() : base()
		{
			Id = 1915;
			Level = RandomLevel( 18 );
			Name = "Dalaran Conjuror";
			Model = 3581;
			AttackSpeed = 2000;
			CombatReach = 1.07f;
			BoundingRadius = 0.3519f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 50;
			ResistNature = 0;

			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			LearnSpell( 705, SpellsTypes.Offensive );
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 2469, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( WorldDrops.MediumDrops, 100f )
				, new BaseTreasure( Drops.MoneyA , 100f )
				, new BaseTreasure( DalaranDrops.DalaranConjuror, 100f ) };
		}
	}
	public class DalaranSpellscribe : BaseCreature
	{
		public DalaranSpellscribe() : base()
		{
			Id = 1920;
			Level = RandomLevel( 21 );
			Name = "Dalaran Spellscribe";
			Model = 3589;
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
			ResistHoly = 50;
			ResistNature = 0;
			ResistShadow = 0;
			Elite = 2;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 3;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( WorldDrops.MediumDrops, 100f )
				, new BaseTreasure( Drops.MoneyA , 100f )
				, new BaseTreasure( DalaranDrops.DalaranSpellscribe, 100f ) };
		}
	}
	public class DalaranWatcher : BaseCreature
	{
		public DalaranWatcher() : base()
		{
			Id = 1888;
			Level = RandomLevel( 19 );
			Name = "Dalaran Watcher";
			Model = 3566;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.208f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 50;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 2388, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( WorldDrops.MediumDrops, 100f )
				, new BaseTreasure( Drops.MoneyA , 100f )
				, new BaseTreasure( DalaranDrops.DalaranWatcher, 100f ) };
		}
	}
	public class DalaranWizard : BaseCreature
	{
		public DalaranWizard() : base()
		{
			Id = 1889;
			Level = RandomLevel( 20 );
			Name = "Dalaran Wizard";
			Model = 3588;
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
			ResistHoly = 50;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			LearnSpell( 837, SpellsTypes.Offensive );
			LearnSpell( 122, SpellsTypes.Offensive );
			LearnSpell( 7321, SpellsTypes.Offensive );
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 1927, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( WorldDrops.MediumDrops, 100f )
				, new BaseTreasure( Drops.MoneyA , 100f )
				, new BaseTreasure( DalaranDrops.DalaranWizard, 100f ) };
		}
	}
	public class DalaranApprentice : BaseCreature
	{
		public DalaranApprentice() : base()
		{
			Id = 1867;
			Level = RandomLevel( 13 );
			Name = "Dalaran Apprentice";
			Model = 3768;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.208f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 50;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			LearnSpell( 205, SpellsTypes.Offensive );
			LearnSpell( 7321, SpellsTypes.Offensive );
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7434, (InventoryTypes)13, 2, 15, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( WorldDrops.LowDrops, 100f )
				, new BaseTreasure(Drops.MoneyB , 100f ) 
				, new BaseTreasure( DalaranDrops.DalaranApprentice, 100f ) };
		}
	}
	
}