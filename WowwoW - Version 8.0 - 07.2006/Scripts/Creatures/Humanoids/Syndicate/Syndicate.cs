using System;
using Server;
using Server.Items;
using Server.Quests;

namespace Server.Creatures
{
	public class SyndicateBrigand : BaseCreature
	{
		public SyndicateBrigand() : base()
		{
			Id = 13149;
			Level = RandomLevel( 55 ,56 );
			Name = "Syndicate Brigand";
			Model = 13440;
			AttackSpeed = 1119;
			CombatReach = 1.39f;
			BoundingRadius = 0.85f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage(1f+2.8f*Level,1f+3.5*Level); 
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 100;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			BaseMana = Level * 70;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Syndicate;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( SyndicateDrops.SyndicateBrigand, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class SyndicateAgent : BaseCreature
	{
		public SyndicateAgent() : base()
		{
			Id = 13150;
			Level = RandomLevel( 57 ,58 );
			Name = "Syndicate Agent";
			Model = 13449;
			AttackSpeed = 1096;
			CombatReach = 1.39f;
			BoundingRadius = 0.85f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage(1f+2.8f*Level,1f+3.5*Level); 
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 100;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			BaseMana = Level * 70;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Syndicate;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( SyndicateDrops.SyndicateAgent, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class SyndicateMasterRyson : BaseNPC
	{
		public SyndicateMasterRyson() : base()
		{
			Id = 13151;
			Level = RandomLevel( 60 );
			Name = "Syndicate Master Ryson";
			Model = 13454;
			AttackSpeed = 1061;
			CombatReach = 1.39f;
			BoundingRadius = 0.85f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage(1f+2.8f*Level,1f+3.5*Level); 
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 100;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Syndicate;
			AIEngine = new DefensiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( SyndicateDrops.SyndicateMasterRyson, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class LordFalconcrest : BaseCreature
	{
		public LordFalconcrest() : base()
		{
			Id = 2597;
			Level = RandomLevel( 40 );
			Name = "Lord Falconcrest";
			Guild = "Syndicate Leader";
			Model = 3985;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage(1f+2.8f*Level,1f+3.5*Level); 
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 100;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			BaseMana = Level * 70;
			NpcFlags = 0;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7482, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0), new Item ( 7482, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( SyndicateDrops.LordFalconcrest, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class SyndicateHighwayman : BaseCreature
	{
		public SyndicateHighwayman() : base()
		{
			Id = 2586;
			Level = RandomLevel( 31 );
			Name = "Syndicate Highwayman";
			Model = 3984;
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
			ResistFrost = 100;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			NpcFlags = 0;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Syndicate;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7434, (InventoryTypes)13, 2, 15, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( SyndicateDrops.SyndicateHighwayman, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class SyndicatePathstalker : BaseCreature
	{
		public SyndicatePathstalker() : base()
		{
			Id = 2587;
			Level = RandomLevel( 32 );
			Name = "Syndicate Pathstalker";
			Model = 3982;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.208f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 100;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			NpcFlags = 0;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Syndicate;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7485, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0), new Item ( 6234, (InventoryTypes)15, 2, 2, 2, 0, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( SyndicateDrops.SyndicatePathstalker, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class SyndicateProwler : BaseCreature
	{
		public SyndicateProwler() : base()
		{
			Id = 2588;
			Level = RandomLevel( 37 );
			Name = "Syndicate Prowler";
			Model = 4016;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage(1f+2.8f*Level,1f+3.5*Level); 
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 100;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			BaseMana = Level * 70;
			NpcFlags = 0;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Syndicate;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7433, (InventoryTypes)13, 2, 15, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( SyndicateDrops.SyndicateProwler, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class SyndicateMercenary : BaseCreature
	{
		public SyndicateMercenary() : base()
		{
			Id = 2589;
			Level = RandomLevel( 32 );
			Name = "Syndicate Mercenary";
			Model = 3987;
			AttackSpeed = 1300;
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
			ResistFrost = 100;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			NpcFlags = 0;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Syndicate;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7483, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0), new Item ( 7487, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( SyndicateDrops.SyndicateMercenary, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class SyndicateConjuror : BaseCreature
	{
		public SyndicateConjuror() : base()
		{
			Id = 2590;
			Level = RandomLevel( 36 );
			Name = "Syndicate Conjuror";
			Model = 4015;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage(1f+2.8f*Level,1f+3.5*Level); 
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 100;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			BaseMana = Level * 70;
			NpcFlags = 0;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Syndicate;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7433, (InventoryTypes)13, 2, 15, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( SyndicateDrops.SyndicateConjuror, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class SyndicateMagus : BaseCreature
	{
		public SyndicateMagus() : base()
		{
			Id = 2591;
			Level = RandomLevel( 38 );
			Name = "Syndicate Magus";
			Model = 4018;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage(1f+2.8f*Level,1f+3.5*Level); 
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 100;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			BaseMana = Level * 70;
			NpcFlags = 0;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Syndicate;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 1927, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( SyndicateDrops.SyndicateMagus, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class SyndicateWizard : BaseCreature
	{
		public SyndicateWizard() : base()
		{
			Id = 2319;
			Level = RandomLevel( 35 );
			Name = "Syndicate Wizard";
			Model = 3712;
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
			ResistFrost = 100;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Syndicate;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 5542, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( SyndicateDrops.SyndicateWizard, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class SyndicateRogue : BaseCreature
	{
		public SyndicateRogue() : base()
		{
			Id = 2260;
			Level = RandomLevel( 22 );
			Name = "Syndicate Rogue";
			Model = 3618;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.208f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 100;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			NpcFlags = 0;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Syndicate;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7433, (InventoryTypes)13, 2, 15, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( SyndicateDrops.SyndicateRogue, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class SyndicateWatchman : BaseCreature
	{
		public SyndicateWatchman() : base()
		{
			Id = 2261;
			Level = RandomLevel( 21 );
			Name = "Syndicate Watchman";
			Model = 3623;
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
			ResistFrost = 100;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			NpcFlags = 0;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Syndicate;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 12236, (InventoryTypes)13, 2, 4, 2, 7, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( SyndicateDrops.SyndicateWatchman, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	
	public class SyndicateFootpad : BaseCreature
	{
		public SyndicateFootpad() : base()
		{
			Id = 2240;
			Level = RandomLevel( 32 );
			Name = "Syndicate Footpad";
			Model = 3707;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.208f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 100;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Syndicate;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7434, (InventoryTypes)13, 2, 15, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( SyndicateDrops.SyndicateFootpad, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class SyndicateThief : BaseCreature
	{
		public SyndicateThief() : base()
		{
			Id = 2241;
			Level = RandomLevel( 33 );
			Name = "Syndicate Thief";
			Model = 3710;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.208f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 100;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Syndicate;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7434, (InventoryTypes)13, 2, 15, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( SyndicateDrops.SyndicateThief, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class SyndicateSpy : BaseCreature
	{
		public SyndicateSpy() : base()
		{
			Id = 2242;
			Level = RandomLevel( 32 ,36 );
			Name = "Syndicate Spy";
			Model = 3716;
			AttackSpeed = 1638;
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
			ResistFrost = 100;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Syndicate;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( SyndicateDrops.SyndicateSpy, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class SyndicateSentry : BaseCreature
	{
		public SyndicateSentry() : base()
		{
			Id = 2243;
			Level = RandomLevel( 36 ,37 );
			Name = "Syndicate Sentry";
			Model = 3721;
			AttackSpeed = 1609;
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
			ResistFrost = 100;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Syndicate;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7429, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0), new Item ( 1706, (InventoryTypes)14, 4, 6, 1, 4, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( SyndicateDrops.SyndicateSentry, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class SyndicateShadowMage : BaseCreature
	{
		public SyndicateShadowMage() : base()
		{
			Id = 2244;
			Level = RandomLevel( 22 );
			Name = "Syndicate Shadow Mage";
			Model = 3621;
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
			ResistFrost = 100;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			NpcFlags = 0;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Syndicate;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 2469, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( SyndicateDrops.SyndicateShadowMage, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class SyndicateSaboteur : BaseCreature
	{
		public SyndicateSaboteur() : base()
		{
			Id = 2245;
			Level = RandomLevel( 37 ,38 );
			Name = "Syndicate Saboteur";
			Model = 3725;
			AttackSpeed = 1596;
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
			ResistFrost = 100;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Syndicate;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7508, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0), new Item ( 6233, (InventoryTypes)15, 2, 2, 2, 0, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( SyndicateDrops.SyndicateSaboteur, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class SyndicateAssassin : BaseCreature
	{
		public SyndicateAssassin() : base()
		{
			Id = 2246;
			Level = RandomLevel( 37 ,39 );
			Name = "Syndicate Assassin";
			Model = 3727;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.208f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 100;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			NpcFlags = 0;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Syndicate;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7433, (InventoryTypes)13, 2, 15, 1, 3, 0, 0, 0), new Item ( 7419, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( SyndicateDrops.SyndicateAssassin, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class SyndicateEnforcer : BaseCreature
	{
		public SyndicateEnforcer() : base()
		{
			Id = 2247;
			Level = RandomLevel( 38 ,40 );
			Name = "Syndicate Enforcer";
			Model = 3729;
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
			ResistFrost = 100;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			NpcFlags = 0;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Syndicate;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7490, (InventoryTypes)17, 2, 8, 1, 1, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( SyndicateDrops.SyndicateEnforcer, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	
	
}