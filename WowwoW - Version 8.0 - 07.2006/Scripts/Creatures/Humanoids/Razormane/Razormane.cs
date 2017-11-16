using System;
using Server;
using Server.Items;
using Server.Quests;

namespace Server.Creatures
{
	public class HaggTaurenbane : BaseCreature
	{
		public HaggTaurenbane() : base()
		{
			Id = 5859;
			Level = RandomLevel( 26 );
			Name = "Hagg Taurenbane";
			Guild = "Razormane Champion";
			Model = 6114;
			AttackSpeed = 2700;
			CombatReach = 2.3f;
			BoundingRadius = 0.4872f;
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
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 3385, (InventoryTypes)17, 2, 1, 1, 1, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( WorldDrops.AdvancedDrops, 100f )
				, new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( RazormaneDrops.HaggTaurenbane, 100f ) };
		}
	}
	public class RazormanePathfinder : BaseCreature
	{
		public RazormanePathfinder() : base()
		{
			Id = 3456;
			Level = RandomLevel( 21 );
			Name = "Razormane Pathfinder";
			Model = 1964;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.348f;
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
			Equip( new CrossDagger());
			Loots = new BaseTreasure[]{ new BaseTreasure( WorldDrops.MediumDrops, 100f )
				, new BaseTreasure(Drops.MoneyB , 100f ) 
				, new BaseTreasure( RazormaneDrops.RazormanePathfinder, 100f ) };
		}
	}
	public class RazormaneStalker : BaseCreature
	{
		public RazormaneStalker() : base()
		{
			Id = 3457;
			Level = RandomLevel( 22 );
			Name = "Razormane Stalker";
			NpcText00 = "You haven't lived until you've looked down on the world from the back of a wind rider.";
			Model = 1253;
			AttackSpeed = 2000;
			CombatReach = 1.87f;
			BoundingRadius = 0.435f;
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
			Equip( new Item ( 6469, (InventoryTypes)13, 2, 15, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( WorldDrops.MediumDrops, 100f )
				, new BaseTreasure(Drops.MoneyB , 100f ) 
				, new BaseTreasure( RazormaneDrops.RazormaneStalker, 100f ) };
		}
	}
	public class RazormaneSeer : BaseCreature
	{
		public RazormaneSeer() : base()
		{
			Id = 3458;
			Level = RandomLevel( 24 );
			Name = "Razormane Seer";
			Model = 6095;
			AttackSpeed = 2000;
			CombatReach = 2.3f;
			BoundingRadius = 0.49f;
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
			Equip( new Item ( 1600, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( WorldDrops.MediumDrops, 100f )
				, new BaseTreasure(Drops.MoneyB , 100f ) 
				, new BaseTreasure( RazormaneDrops.RazormaneSeer, 100f ) };
		}
	}
	public class RazormaneWarfrenzy : BaseCreature
	{
		public RazormaneWarfrenzy() : base()
		{
			Id = 3459;
			Level = RandomLevel( 24 );
			Name = "Razormane Warfrenzy";
			Model = 4751;
			AttackSpeed = 1500;
			CombatReach = 2.3f;
			BoundingRadius = 0.4872f;
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
			Equip( new Item ( 7419, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( WorldDrops.MediumDrops, 100f )
				, new BaseTreasure(Drops.MoneyB , 100f ) 
				, new BaseTreasure( RazormaneDrops.RazormaneWarfrenzy, 100f ) };
		}
	}
	public class RazormaneMystic : BaseCreature
	{
		public RazormaneMystic() : base()
		{
			Id = 3271;
			Level = RandomLevel( 13 );
			Name = "Razormane Mystic";
			Model = 4643;
			AttackSpeed = 2000;
			CombatReach = 1.87f;
			BoundingRadius = 0.4375f;
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
			Loots = new BaseTreasure[]{ new BaseTreasure( WorldDrops.LowDrops, 100f )
				, new BaseTreasure(Drops.MoneyA , 100f )
				, new BaseTreasure( RazormaneDrops.RazormaneMystic, 100f ) };
		}
	}
	class RazormaneHunter : BaseCreature
	{
		public RazormaneHunter() : base()
		{
			Id = 3265;
			Level = RandomLevel( 11 );
			Name = "Razormane Hunter";
			Model = 6094;
			AttackSpeed = 2000;
			CombatReach = 1.07f;
			BoundingRadius = 0.4002f;
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
			Equip( new Item ( 7428, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0), new Item ( 10671, (InventoryTypes)26, 2, 18, 1, 0, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( WorldDrops.LowDrops, 100f )
				, new BaseTreasure(Drops.MoneyA , 100f )
				, new BaseTreasure( RazormaneDrops.RazormaneHunter, 100f ) };
		}
	}
	public class RazormaneDefender : BaseCreature
	{
		public RazormaneDefender() : base()
		{
			Id = 3266;
			Level = RandomLevel( 12 );
			Name = "Razormane Defender";
			Model = 1253;
			AttackSpeed = 2000;
			CombatReach = 1.87f;
			BoundingRadius = 0.435f;
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
			Equip( new Item ( 7429, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( WorldDrops.LowDrops, 100f )
				, new BaseTreasure(Drops.MoneyA , 100f )
				, new BaseTreasure( RazormaneDrops.RazormaneDefender, 100f ) };
		}
	}
	public class RazormaneWaterSeeker : BaseCreature
	{
		public RazormaneWaterSeeker() : base()
		{
			Id = 3267;
			Level = RandomLevel( 11 );
			Name = "Razormane Water Seeker";
			Model = 1964;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.348f;
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
			Loots = new BaseTreasure[]{ new BaseTreasure( WorldDrops.LowDrops, 100f )
				, new BaseTreasure(Drops.MoneyA , 100f )
				, new BaseTreasure( RazormaneDrops.RazormaneWaterSeeker, 100f ) };
		}
	}
	public class RazormaneThornweaver : BaseCreature
	{
		public RazormaneThornweaver() : base()
		{
			Id = 3268;
			Level = RandomLevel( 11 );
			Name = "Razormane Thornweaver";
			Model = 6096;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.35f;
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
			Equip( new Item ( 7428, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( WorldDrops.LowDrops, 100f )
				, new BaseTreasure(Drops.MoneyA , 100f )
				, new BaseTreasure( RazormaneDrops.RazormaneThornweaver, 100f ) };
		}
	}
	public class RazormaneGeomancer : BaseCreature
	{
		public RazormaneGeomancer() : base()
		{
			Id = 3269;
			Level = RandomLevel( 12 );
			Name = "Razormane Geomancer";
			Model = 6093;
			AttackSpeed = 2000;
			CombatReach = 1.07f;
			BoundingRadius = 0.4025f;
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
			Equip( new Item ( 12236, (InventoryTypes)13, 2, 4, 2, 7, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( WorldDrops.LowDrops, 100f )
				, new BaseTreasure(Drops.MoneyA , 100f )
				, new BaseTreasure( RazormaneDrops.RazormaneGeomancer, 100f ) };
		}
	}
	public class RazormaneQuilboar : BaseCreature
	{
		public RazormaneQuilboar() : base()
		{
			Id = 3111;
			Level = RandomLevel( 6 );
			Name = "Razormane Quilboar";
			Model = 1218;
			AttackSpeed = 2000;
			CombatReach = 1.3f;
			BoundingRadius = 0.2784f;
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
			//LearnSpell( 5280, SpellsTypes.Offensive ); not scripted yet
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7440, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( WorldDrops.LowDrops, 100f )
				, new BaseTreasure(Drops.MoneyA , 100f )
				, new BaseTreasure( RazormaneDrops.RazormaneQuilboar, 100f ) };
		}
	}
	public class RazormaneScout : BaseCreature
	{
		public RazormaneScout() : base()
		{
			Id = 3112;
			Level = RandomLevel( 7 );
			Name = "Razormane Scout";
			Model = 1252;
			AttackSpeed = 2000;
			CombatReach = 1.35f;
			BoundingRadius = 0.3132f;
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
			Equip( new Item ( 6443, (InventoryTypes)13, 2, 15, 1, 3, 0, 0, 0), new Item ( 10671, (InventoryTypes)26, 2, 18, 1, 0, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( WorldDrops.LowDrops, 100f )
				, new BaseTreasure(Drops.MoneyA , 100f )
				, new BaseTreasure( RazormaneDrops.RazormaneScout, 100f ) };
		}
	}
	public class RazormaneDustrunner : BaseCreature
	{
		public RazormaneDustrunner() : base()
		{
			Id = 3113;
			Level = RandomLevel( 8 );
			Name = "Razormane Dustrunner";
			Model = 6088;
			AttackSpeed = 2000;
			CombatReach = 1.35f;
			BoundingRadius = 0.315f;
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
			LearnSpell( 6950, SpellsTypes.Offensive );
			LearnSpell( 774, SpellsTypes.Healing );
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7429, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( WorldDrops.LowDrops, 100f )
				, new BaseTreasure(Drops.MoneyA , 100f )
				, new BaseTreasure( RazormaneDrops.RazormaneDustrunner, 100f ) };
		}
	}
	public class RazormaneBattleguard : BaseCreature
	{
		public RazormaneBattleguard() : base()
		{
			Id = 3114;
			Level = RandomLevel( 9 );
			Name = "Razormane Battleguard";
			Model = 1964;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.348f;
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
			Equip( new Item ( 7487, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0), new Item ( 1685, (InventoryTypes)14, 4, 6, 1, 4, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( WorldDrops.LowDrops, 100f )
				, new BaseTreasure(Drops.MoneyA , 100f )
				, new BaseTreasure( RazormaneDrops.RazormaneBattleguard, 100f ) };
		}
	}
	
	
}