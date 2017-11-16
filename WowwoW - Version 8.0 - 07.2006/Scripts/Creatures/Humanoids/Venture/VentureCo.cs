using System;
using Server;
using Server.Items;
using Server.Quests;

namespace Server.Creatures
{
	public class SupervisorFizsprocket : BaseCreature
	{
		public SupervisorFizsprocket() : base()
		{
			Id = 3051;
			Level = RandomLevel( 12 );
			Name = "Supervisor Fizsprocket";
			Model = 7134;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			AIEngine = new AgressiveAnimalAI( this );
			Block=Level+30;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 0;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			Equip( new Item ( 7493, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( AllDrops.SupervisorFizsprocket, 100f ) };
		}
	}
	public class MutatedVentureCo_Drone : BaseCreature
	{
		public MutatedVentureCo_Drone() : base()
		{
			Id = 7310;
			Level = RandomLevel( 25 );
			Name = "Mutated Venture Co. Drone";
			Model = 5832;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.383f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 30;
			AIEngine = new AgressiveAnimalAI( this );
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 0;
			NpcFlags = 0;
			Flags1 = 0x04;
			NpcType = (int)NpcTypes.Undead;
			Faction = Factions.Monster;
			Equip( new Item ( 7428, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( AllDrops.MutatedVentureCo_Drone, 100f ) };
		}
	}
	public class VentureCo_Lookout : BaseCreature
	{
		public VentureCo_Lookout() : base()
		{
			Id = 7307;
			Level = RandomLevel( 23 );
			Name = "Venture Co. Lookout";
			Model = 7235;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.2907f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 30;
			AIEngine = new AgressiveAnimalAI( this );
			Block=Level+30;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 0;
			NpcFlags = 0;
			Flags1 = 0x080004;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			Loots = new BaseTreasure[]{ new BaseTreasure( AllDrops.VentureCo_Lookout, 100f ) };
		}
	}
	public class VentureCo_Patroller : BaseCreature
	{
		public VentureCo_Patroller() : base()
		{
			Id = 7308;
			Level = RandomLevel( 22 );
			Name = "Venture Co. Patroller";
			Model = 7239;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 30;
			AIEngine = new AgressiveAnimalAI( this );
			Block=Level+30;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 0;
			NpcFlags = 0;
			Flags1 = 0x080004;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			Loots = new BaseTreasure[]{ new BaseTreasure( AllDrops.VentureCo_Patroller, 100f ) };
		}
	}
	public class VentureCo_Drone : BaseCreature
	{
		public VentureCo_Drone() : base()
		{
			Id = 7067;
			Level = RandomLevel( 22 );
			Name = "Venture Co. Drone";
			Model = 5832;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.383f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 30;
			AIEngine = new AgressiveAnimalAI( this );
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 0;
			NpcFlags = 0;
			Flags1 = 0x04;
			NpcType = (int)NpcTypes.Undead;
			Faction = Factions.Monster;
			Equip( new Item ( 7428, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( AllDrops.VentureCo_Drone, 100f ) };
		}
	}
	public class Piznik : BaseNPC
	{
		public Piznik() : base()
		{
			Id = 4276;
			Level = RandomLevel( 20 );
			Name = "Piznik";
			Guild = "Venture Co.";
			NpcText00 = "Greetings $N, I am Piznik.";
			Model = 7157;
			AttackSpeed = 1833;
			CombatReach = 0.8f;
			BoundingRadius = 0.561f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 30;
			AIEngine = new AgressiveAnimalAI( this );
			Block=Level+30;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 1003;
			NpcFlags = (int)NpcActions.Dialog ;
			Flags1 = 0x066;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			Equip( new Item ( 7493, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0), new Item ( 24294, (InventoryTypes)23, 4, 0, 2, 0, 0, 0, 0) );
		}
	}
	public class VentureCo_Builder : BaseCreature
	{
		public VentureCo_Builder() : base()
		{
			Id = 4070;
			Level = RandomLevel( 20 ,22 );
			Name = "Venture Co. Builder";
			Model = 7224;
			AttackSpeed = 1819;
			CombatReach = 1.5f;
			BoundingRadius = 0.5f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 30;
			AIEngine = new SpellCasterAI( this );
			Block=Level+30;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 1053;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			LearnSpell( 4074, SpellsTypes.Offensive );
			LearnSpell( 4078, SpellsTypes.Offensive );
			Loots = new BaseTreasure[]{ new BaseTreasure( AllDrops.VentureCo_Builder, 100f ) };
			Equip( new Item ( 2777, (InventoryTypes)17, 2, 5, 2, 1, 0, 0, 0), new Item ( 6593, (InventoryTypes)26, 2, 3, 1, 0, 0, 0, 0) );
		}
	}
	public class VentureCo_Grinder : BaseCreature
	{
		public VentureCo_Grinder() : base()
		{
			Id = 4071;
			Level = RandomLevel( 18 ,19 );
			Name = "Venture Co. Grinder";
			Model = 7223;
			AttackSpeed = 1861;
			CombatReach = 0.8f;
			BoundingRadius = 0.561f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 30;
			AIEngine = new AgressiveAnimalAI( this );
			Block=Level+30;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 903;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
		}
	}
	public class VentureCo_Operator : BaseCreature
	{
		public VentureCo_Operator() : base()
		{
			Id = 3988;
			Level = RandomLevel( 17 ,21 );
			Name = "Venture Co. Operator";
			Model = 7230;
			AttackSpeed = 1848;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 30;
			AIEngine = new AgressiveAnimalAI( this );
			Block=Level+30;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 953;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Loots = new BaseTreasure[]{ new BaseTreasure( AllDrops.VentureCo_Operator, 100f ) };
			Faction = Factions.Monster;
		}
	}
	public class VentureCo_Logger : BaseCreature
	{
		public VentureCo_Logger() : base()
		{
			Id = 3989;
			Level = RandomLevel( 17 ,20 );
			Name = "Venture Co. Logger";
			Model = 7228;
			AttackSpeed = 1861;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 30;
			AIEngine = new AgressiveAnimalAI( this );
			Block=Level+30;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 903;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			Loots = new BaseTreasure[]{ new BaseTreasure( AllDrops.VentureCo_Logger, 100f ) };
			Equip( new Item ( 7508, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0), new Item ( 16751, (InventoryTypes)25, 2, 16, 1, 0, 0, 0, 0) );
		}
	}
	public class VentureCo_Cutter : BaseCreature
	{
		public VentureCo_Cutter() : base()
		{
			Id = 3990;
			Level = RandomLevel( 17 ,18 );
			Name = "Venture Co. Cutter";
			Model = 7225;
			AttackSpeed = 1875;
			CombatReach = 0.8f;
			BoundingRadius = 0.561f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 30;
			AIEngine = new AgressiveAnimalAI( this );
			Block=Level+30;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 853;
			NpcType = (int)NpcTypes.Humanoid;
			Loots = new BaseTreasure[]{ new BaseTreasure( AllDrops.VentureCo_Cutter, 100f ) };
			Faction = Factions.Monster;
		}
	}
	public class VentureCo_Deforester : BaseCreature
	{
		public VentureCo_Deforester() : base()
		{
			Id = 3991;
			Level = RandomLevel( 19 ,21 );
			Name = "Venture Co. Deforester";
			Model = 7226;
			AttackSpeed = 1833;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 30;
			AIEngine = new AgressiveAnimalAI( this );
			Block=Level+30;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 1003;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			Loots = new BaseTreasure[]{ new BaseTreasure( AllDrops.VentureCo_Deforester, 100f ) };
			Equip( new Item ( 5010, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
		}
	}
	public class VentureCo_Engineer : BaseCreature
	{
		public VentureCo_Engineer() : base()
		{
			Id = 3992;
			Level = RandomLevel( 20 ,22 );
			Name = "Venture Co. Engineer";
			Model = 7227;
			AttackSpeed = 1819;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 30;
			AIEngine = new SpellCasterAI( this );
			Block=Level+30;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 1053;
			Flags1 = 0x080000;
			Loots = new BaseTreasure[]{ new BaseTreasure( AllDrops.VentureCo_Engineer, 100f ) };
			NpcType = (int)NpcTypes.Humanoid;
			LearnSpell( 4074, SpellsTypes.Offensive );
			LearnSpell( 4078, SpellsTypes.Offensive );
			Faction = Factions.Monster;
		}
	}
	public class VentureCo_MachineSmith : BaseCreature
	{
		public VentureCo_MachineSmith() : base()
		{
			Id = 3993;
			Level = RandomLevel( 21 ,23 );
			Name = "Venture Co. Machine Smith";
			Model = 7229;
			AttackSpeed = 1806;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 30;
			AIEngine = new AgressiveAnimalAI( this );
			Block=Level+30;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 1103;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			Loots = new BaseTreasure[]{ new BaseTreasure( AllDrops.VentureCo_MachineSmith, 100f ) };
			Equip( new Item ( 7494, (InventoryTypes)13, 2, 4, 2, 7, 0, 0, 0) );
		}
	}
	public class VentureCo_Mercenary : BaseCreature
	{
		public VentureCo_Mercenary() : base()
		{
			Id = 3282;
			Level = RandomLevel( 16 );
			Name = "Venture Co. Mercenary";
			Model = 4098;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 30;
			AIEngine = new AgressiveAnimalAI( this );
			Block=Level+30;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 0;
			NpcFlags = 0;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Loots = new BaseTreasure[]{ new BaseTreasure( AllDrops.VentureCo_Mercenary, 100f ) };
			Faction = Factions.Monster;
			Equip( new Item ( 7487, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0), new Item ( 6235, (InventoryTypes)15, 2, 2, 2, 0, 0, 0, 0) );
		}
	}
	public class VentureCo_Enforcer : BaseCreature
	{
		public VentureCo_Enforcer() : base()
		{
			Id = 3283;
			Level = RandomLevel( 17 );
			Name = "Venture Co. Enforcer";
			Model = 7234;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 30;
			AIEngine = new AgressiveAnimalAI( this );
			Block=Level+30;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 0;
			NpcFlags = 0;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Loots = new BaseTreasure[]{ new BaseTreasure( AllDrops.VentureCo_Mercenary, 100f ) };
			Faction = Factions.Monster;
			Equip( new Item ( 5128, (InventoryTypes)17, 2, 1, 1, 1, 0, 0, 0) );
		}
	}
	public class VentureCo_Drudger : BaseCreature
	{
		public VentureCo_Drudger() : base()
		{
			Id = 3284;
			Level = RandomLevel( 15 );
			Name = "Venture Co. Drudger";
			Model = 7233;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 30;
			AIEngine = new AgressiveAnimalAI( this );
			Block=Level+30;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 0;
			NpcFlags = 0;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Loots = new BaseTreasure[]{ new BaseTreasure( AllDrops.VentureCo_Drudger, 100f ) };
			Faction = Factions.Monster;
			Equip( new Item ( 7495, (InventoryTypes)17, 2, 6, 1, 2, 0, 0, 0) );
		}
	}
	public class VentureCo_Peon : BaseCreature
	{
		public VentureCo_Peon() : base()
		{
			Id = 3285;
			Level = RandomLevel( 13 );
			Name = "Venture Co. Peon";
			Model = 7241;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 30;
			AIEngine = new AgressiveAnimalAI( this );
			Block=Level+30;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 0;
			NpcFlags = 0;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Loots = new BaseTreasure[]{ new BaseTreasure( AllDrops.VentureCo_Peon, 100f ) };
			Faction = Factions.Monster;
			Equip( new Item ( 7495, (InventoryTypes)17, 2, 6, 1, 2, 0, 0, 0) );
		}
	}
	public class VentureCo_Overseer : BaseCreature
	{
		public VentureCo_Overseer() : base()
		{
			Id = 3286;
			Level = RandomLevel( 18 );
			Name = "Venture Co. Overseer";
			Model = 7238;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 30;
			AIEngine = new AgressiveAnimalAI( this );
			Block=Level+30;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 0;
			NpcFlags = 0;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Loots = new BaseTreasure[]{ new BaseTreasure( AllDrops.VentureCo_Overseer, 100f ) };
			Faction = Factions.Monster;
			Equip( new Item ( 7419, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0) );
		}
	}
	public class VentureCo_Hireling : BaseCreature
	{
		public VentureCo_Hireling() : base()
		{
			Id = 2975;
			Level = RandomLevel( 6 );
			Name = "Venture Co. Hireling";
			Model = 3901;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 30;
			AIEngine = new AgressiveAnimalAI( this );
			Block=Level+30;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 0;
			NpcFlags = 0;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			Loots = new BaseTreasure[]{ new BaseTreasure( AllDrops.VentureCo_Hireling, 100f ) };
			Equip( new Item ( 7434, (InventoryTypes)13, 2, 15, 1, 3, 0, 0, 0) );
		}
	}
	public class VentureCo_Laborer : BaseCreature
	{
		public VentureCo_Laborer() : base()
		{
			Id = 2976;
			Level = RandomLevel( 6 );
			Name = "Venture Co. Laborer";
			Model = 7244;
			AttackSpeed = 3000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 30;
			AIEngine = new AgressiveAnimalAI( this );
			Block=Level+30;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 0;
			NpcFlags = 0;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			Loots = new BaseTreasure[]{ new BaseTreasure( AllDrops.VentureCo_Laborer, 100f ) };
			Equip( new Item ( 7493, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0) );
		}
	}
	public class VentureCo_Taskmaster : BaseCreature
	{
		public VentureCo_Taskmaster() : base()
		{
			Id = 2977;
			Level = RandomLevel( 8 );
			Name = "Venture Co. Taskmaster";
			Model = 7246;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 30;
			AIEngine = new AgressiveAnimalAI( this );
			Block=Level+30;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 0;
			NpcFlags = 0;
			Flags1 = 0x080000;
			Loots = new BaseTreasure[]{ new BaseTreasure( AllDrops.VentureCo_Taskmaster, 100f ) };
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			Equip( new Item ( 12236, (InventoryTypes)13, 2, 4, 2, 7, 0, 0, 0) );
		}
	}
	public class VentureCo_Worker : BaseCreature
	{
		public VentureCo_Worker() : base()
		{
			Id = 2978;
			Level = RandomLevel( 8 );
			Name = "Venture Co. Worker";
			Model = 355;
			AttackSpeed = 3200;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 30;
			AIEngine = new AgressiveAnimalAI( this );
			Block=Level+30;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 0;
			NpcFlags = 0;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			Loots = new BaseTreasure[]{ new BaseTreasure( AllDrops.VentureCo_Worker, 100f ) };
			Equip( new Item ( 7493, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0) );
		}
	}
	public class VentureCo_Supervisor : BaseCreature
	{
		public VentureCo_Supervisor() : base()
		{
			Id = 2979;
			Level = RandomLevel( 10 );
			Name = "Venture Co. Supervisor";
			Model = 7245;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 30;
			AIEngine = new SpellCasterAI( this );
			Block=Level+30;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			ManaType = 1; 
			BaseMana = 100;
			LearnSpell( 6673, SpellsTypes.Offensive );
			NpcFlags = 0;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Loots = new BaseTreasure[]{ new BaseTreasure( AllDrops.VentureCo_Supervisor, 100f ) };
			Faction = Factions.Monster;
			Equip( new Item ( 7439, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0) );
		}
	}
	public class VentureCo_Miner : BaseCreature
	{
		public VentureCo_Miner() : base()
		{
			Id = 1094;
			Level = RandomLevel( 34 );
			Name = "Venture Co. Miner";
			Model = 7201;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 30;
			AIEngine = new AgressiveAnimalAI( this );
			Block=Level+30;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 0;
			NpcFlags = 0;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			Loots = new BaseTreasure[]{ new BaseTreasure( AllDrops.VentureCo_Miner, 100f ) };
			Equip( new Item ( 7493, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0) );
		}
	}
	public class VentureCo_Workboss : BaseCreature
	{
		public VentureCo_Workboss() : base()
		{
			Id = 1095;
			Level = RandomLevel( 36 );
			Name = "Venture Co. Workboss";
			Model = 7205;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 30;
			AIEngine = new AgressiveAnimalAI( this );
			Block=Level+30;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 0;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Loots = new BaseTreasure[]{ new BaseTreasure( AllDrops.VentureCo_Workboss, 100f ) };
			Faction = Factions.Monster;
			Equip( new Item ( 7485, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0) );
		}
	}
	public class VentureCo_Geologist : BaseCreature
	{
		public VentureCo_Geologist() : base()
		{
			Id = 1096;
			Level = RandomLevel( 35 );
			Name = "Venture Co. Geologist";
			Model = 7197;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 30;
			AIEngine = new AgressiveAnimalAI( this );
			Block=Level+30;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 1067;
			NpcFlags = 0;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			Loots = new BaseTreasure[]{ new BaseTreasure( AllDrops.VentureCo_Geologist, 100f ) };
			Equip( new Item ( 7478, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0) );
		}
	}
	public class VentureCo_Mechanic : BaseCreature
	{
		public VentureCo_Mechanic() : base()
		{
			Id = 1097;
			Level = RandomLevel( 35 );
			Name = "Venture Co. Mechanic";
			Model = 7200;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 30;
			AIEngine = new AgressiveAnimalAI( this );
			Block=Level+30;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 0;
			NpcFlags = 0;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			Loots = new BaseTreasure[]{ new BaseTreasure( AllDrops.VentureCo_Mechanic, 100f ) };
			Equip( new Item ( 7494, (InventoryTypes)13, 2, 4, 2, 7, 0, 0, 0), new Item ( 6593, (InventoryTypes)26, 2, 3, 1, 0, 0, 0, 0) );
		}
	}
	public class VentureCo_Lumberjack : BaseCreature
	{
		public VentureCo_Lumberjack() : base()
		{
			Id = 921;
			Level = RandomLevel( 35 );
			Name = "Venture Co. Lumberjack";
			Model = 7198;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 30;
			AIEngine = new AgressiveAnimalAI( this );
			Block=Level+30;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 0;
			NpcFlags = 0;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			Loots = new BaseTreasure[]{ new BaseTreasure( AllDrops.VentureCo_Lumberjack, 100f ) };
			Equip( new Item ( 7428, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0) );
		}
	}
	public class VentureCo_StripMiner : BaseCreature
	{
		public VentureCo_StripMiner() : base()
		{
			Id = 674;
			Level = RandomLevel( 40 );
			Name = "Venture Co. Strip Miner";
			Model = 7202;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 30;
			AIEngine = new AgressiveAnimalAI( this );
			Block=Level+30;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 0;
			NpcFlags = 0;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Loots = new BaseTreasure[]{ new BaseTreasure( AllDrops.VentureCo_StripMiner, 100f ) };
			Faction = Factions.Monster;
			Equip( new Item ( 7493, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0) );
		}
	}
	public class VentureCo_Foreman : BaseCreature
	{
		public VentureCo_Foreman() : base()
		{
			Id = 675;
			Level = RandomLevel( 42 );
			Name = "Venture Co. Foreman";
			Model = 7196;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 30;
			AIEngine = new AgressiveAnimalAI( this );
			Block=Level+30;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 0;
			NpcFlags = 0;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Loots = new BaseTreasure[]{ new BaseTreasure( AllDrops.VentureCo_Foreman, 100f ) };
			Faction = Factions.Monster;
			Equip( new Item ( 12236, (InventoryTypes)13, 2, 4, 2, 7, 0, 0, 0) );
		}
	}
	public class VentureCo_Surveyor : BaseCreature
	{
		public VentureCo_Surveyor() : base()
		{
			Id = 676;
			Level = RandomLevel( 42 );
			Name = "Venture Co. Surveyor";
			Model = 7203;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 30;
			AIEngine = new AgressiveAnimalAI( this );
			Block=Level+30;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 1381;
			NpcFlags = 0;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Loots = new BaseTreasure[]{ new BaseTreasure( AllDrops.VentureCo_Surveyor, 100f ) };
			Faction = Factions.Monster;
			Equip( new Item ( 7476, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0) );
		}
	}
	public class VentureCo_Tinkerer : BaseCreature
	{
		public VentureCo_Tinkerer() : base()
		{
			Id = 677;
			Level = RandomLevel( 40 );
			Name = "Venture Co. Tinkerer";
			Model = 7204;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage ( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 30;
			AIEngine = new AgressiveAnimalAI( this );
			Block=Level+30;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 3191;
			NpcFlags = 0;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Loots = new BaseTreasure[]{ new BaseTreasure( AllDrops.VentureCo_Tinkerer, 100f ) };
			Faction = Factions.Monster;
			Equip( new Item ( 7494, (InventoryTypes)13, 2, 4, 2, 7, 0, 0, 0) );
		}
	}
	
}