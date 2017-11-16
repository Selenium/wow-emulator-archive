using System;
using Server;
using Server.Items;
using Server.Quests;

namespace Server.Creatures
{
	public class RazorfenBattleguard : BaseCreature
	{
		public RazorfenBattleguard() : base()
		{
			Id = 7873;
			Level = RandomLevel( 34 );
			Name = "Razorfen Battleguard";
			Model = 6108;
			AttackSpeed = 2000;
			CombatReach = 1.87f;
			BoundingRadius = 0.4375f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 70;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 100;
			ResistShadow = 0;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new FightClub(), new Item ( 1684, (InventoryTypes)14, 4, 6, 1, 4, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f ) 
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f )
				, new BaseTreasure( RazorfenDrops.RazorfenBattleguard , 100f ) };
		}
	}
	public class RazorfenThornweaver : BaseCreature
	{
		public RazorfenThornweaver() : base()
		{
			Id = 7874;
			Level = RandomLevel( 34 );
			Name = "Razorfen Thornweaver";
			Model = 1963;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.348f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 70;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 100;
			ResistShadow = 0;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new BigStick());
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f ) 
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f )
				, new BaseTreasure( RazorfenDrops.RazorfenThornweaver, 100f ) };
		}
	}
	public class RazorfenServitor : BaseCreature
	{
		public RazorfenServitor() : base()
		{
			Id = 6132;
			Level = RandomLevel( 23 );
			Name = "Razorfen Servitor";
			Model = 1343;
			AttackSpeed = 2000;
			CombatReach = 2.0f;
			BoundingRadius = 0.4176f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 70;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 100;
			ResistShadow = 0;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Slaghammer() );
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f ) 
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f )
				, new BaseTreasure( RazorfenDrops.RazorfenServitor , 100f ) };
		}
	}
	public class RazorfenStalker : BaseCreature
	{
		public RazorfenStalker() : base()
		{
			Id = 6035;
			Level = RandomLevel( 28 ,29 );
			Name = "Razorfen Stalker";
			Model = 6106;
			AttackSpeed = 1434;
			CombatReach = 1.5f;
			BoundingRadius = 0.348f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 70;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 100;
			ResistShadow = 0;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new CrossDagger());
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f )
				, new BaseTreasure( RazorfenDrops.RazorfenStalker , 100f ) };
		}
	}
	public class RazorfenHandler : BaseCreature
	{
		public RazorfenHandler() : base()
		{
			Id = 4530;
			Level = RandomLevel( 25 ,26 );
			Name = "Razorfen Handler";
			Model = 1963;
			AttackSpeed = 1470;
			CombatReach = 0.8f;
			BoundingRadius = 0.348f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 70;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 100;
			ResistShadow = 0;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new UnbalancedAxe(), new FineLightCrossbow() );
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f ) 
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f )
				, new BaseTreasure( RazorfenDrops.RazorfenHandler , 100f ) };
		}
	}
	public class RazorfenBeastTrainer : BaseCreature
	{
		public RazorfenBeastTrainer() : base()
		{
			Id = 4531;
			Level = RandomLevel( 28 ,29 );
			Name = "Razorfen Beast Trainer";
			Model = 4453;
			AttackSpeed = 1434;
			CombatReach = 0.8f;
			BoundingRadius = 0.4002f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 70;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 100;
			ResistShadow = 0;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new FineLightCrossbow() );
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f )
				, new BaseTreasure( RazorfenDrops.RazorfenBeastTrainer , 100f ) };
		}
	}
	public class RazorfenBeastmaster : BaseCreature
	{
		public RazorfenBeastmaster() : base()
		{
			Id = 4532;
			Level = RandomLevel( 30 ,31 );
			Name = "Razorfen Beastmaster";
			Model = 6105;
			AttackSpeed = 1411;
			CombatReach = 0.8f;
			BoundingRadius = 0.4524f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 70;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 100;
			ResistShadow = 0;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new CrossDagger());
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f )
				, new BaseTreasure( RazorfenDrops.RazorfenBeastmaster , 100f ) };
		}
	}
	public class RazorfenEarthbreaker : BaseCreature
	{
		public RazorfenEarthbreaker() : base()
		{
			Id = 4525;
			Level = RandomLevel( 30 ,31 );
			Name = "Razorfen Earthbreaker";
			Model = 4647;
			AttackSpeed = 1411;
			CombatReach = 0.8f;
			BoundingRadius = 0.35f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 70;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 100;
			ResistShadow = 0;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new LesserMysticWand());
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f )
				, new BaseTreasure( RazorfenDrops.RazorfenEarthbreaker , 100f ) };
		}
	}
	public class RazorfenDustweaver : BaseCreature
	{
		public RazorfenDustweaver() : base()
		{
			Id = 4522;
			Level = RandomLevel( 28 ,29 );
			Name = "Razorfen Dustweaver";
			Model = 6110;
			AttackSpeed = 1434;
			CombatReach = 0.8f;
			BoundingRadius = 0.42f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 70;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 100;
			ResistShadow = 0;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new BigStick());
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f )
				, new BaseTreasure( RazorfenDrops.RazorfenDustweaver , 100f ) };
		}
	}
	public class RazorfenGroundshaker : BaseCreature
	{
		public RazorfenGroundshaker() : base()
		{
			Id = 4523;
			Level = RandomLevel( 26 ,28 );
			Name = "Razorfen Groundshaker";
			Model = 6111;
			AttackSpeed = 1446;
			CombatReach = 0.8f;
			BoundingRadius = 0.455f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 70;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 100;
			ResistShadow = 0;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new BigStick());
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f )
				, new BaseTreasure( RazorfenDrops.RazorfenGroundshaker , 100f ) };
		}
	}
	
	public class RazorfenGeomancer : BaseCreature
	{
		public RazorfenGeomancer() : base()
		{
			Id = 4520;
			Level = RandomLevel( 25 ,26 );
			Name = "Razorfen Geomancer";
			Model = 4647;
			AttackSpeed = 1470;
			CombatReach = 1.5f;
			BoundingRadius = 0.35f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 70;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 100;
			ResistShadow = 0;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new EmberstoneStaff() );
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f )
				, new BaseTreasure( RazorfenDrops.RazorfenGeomancer , 100f ) };
		}
	}
	public class RazorfenTotemic : BaseCreature
	{
		public RazorfenTotemic() : base()
		{
			Id = 4440;
			Level = RandomLevel( 29 );
			Name = "Razorfen Totemic";
			Model = 6112;
			AttackSpeed = 1423;
			CombatReach = 1.5f;
			BoundingRadius = 0.49f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 70;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 100;
			ResistShadow = 0;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new BigStick());
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f )
				, new BaseTreasure( RazorfenDrops.RazorfenTotemic , 100f ) };
		}
	}
	public class RazorfenDefender : BaseCreature
	{
		public RazorfenDefender() : base()
		{
			Id = 4442;
			Level = RandomLevel( 26 ,28 );
			Name = "Razorfen Defender";
			Model = 6103;
			AttackSpeed = 1446;
			CombatReach = 1.5f;
			BoundingRadius = 0.49f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 70;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 100;
			ResistShadow = 0;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Longsword(), new Item ( 1706, (InventoryTypes)14, 4, 6, 1, 4, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f )
				, new BaseTreasure( RazorfenDrops.RazorfenDefender , 100f ) };
		}
	}
	public class RazorfenWarrior : BaseCreature
	{
		public RazorfenWarrior() : base()
		{
			Id = 4435;
			Level = RandomLevel( 24 ,25 );
			Name = "Razorfen Warrior";
			Model = 6109;
			AttackSpeed = 1481;
			CombatReach = 1.5f;
			BoundingRadius = 0.4375f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 70;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 100;
			ResistShadow = 0;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new BlackMetalShortsword() );
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f )
				, new BaseTreasure( RazorfenDrops.RazorfenWarrior , 100f ) };
		}
	}
	public class RazorfenQuilguard : BaseCreature
	{
		public RazorfenQuilguard() : base()
		{
			Id = 4436;
			Level = RandomLevel( 25 ,26 );
			Name = "Razorfen Quilguard";
			Model = 6108;
			AttackSpeed = 1470;
			CombatReach = 1.5f;
			BoundingRadius = 0.4375f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 70;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 100;
			ResistShadow = 0;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new BlackMetalShortsword() );
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f )
				, new BaseTreasure( RazorfenDrops.RazorfenQuilguard , 100f ) };
		}
	}
	public class RazorfenWarden : BaseCreature
	{
		public RazorfenWarden() : base()
		{
			Id = 4437;
			Level = RandomLevel( 25 ,26 );
			Name = "Razorfen Warden";
			Model = 4758;
			AttackSpeed = 1470;
			CombatReach = 1.5f;
			BoundingRadius = 0.4375f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 70;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 100;
			ResistShadow = 0;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new FightClub() );
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f )
				, new BaseTreasure( RazorfenDrops.RazorfenWarden , 100f ) };
		}
	}
	public class RazorfenSpearhide : BaseCreature
	{
		public RazorfenSpearhide() : base()
		{
			Id = 4438;
			Level = RandomLevel( 29 ,30 );
			Name = "Razorfen Spearhide";
			Model = 6078;
			AttackSpeed = 1423;
			CombatReach = 1.5f;
			BoundingRadius = 0.4176f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 70;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 100;
			ResistShadow = 0;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 12857, (InventoryTypes)17, 2, 6, 1, 2, 0, 0, 0), new Item ( 22671, (InventoryTypes)25, 2, 16, 1, 0, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f )
				, new BaseTreasure( RazorfenDrops.RazorfenSpearhide , 100f ) };
		}
	}
	
}