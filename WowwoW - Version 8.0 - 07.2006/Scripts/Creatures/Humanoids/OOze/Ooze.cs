using System;
using Server;
using Server.Items;
using Server.Quests;

namespace Server.Creatures
{
	public class CrimsonOoze : BaseCreature
	{
		public CrimsonOoze() : base()
		{
			Id = 1031;
			Level = RandomLevel( 25 );
			Name = "Crimson Ooze";
			Model = 11138;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.68885f;
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
			ResistShadow = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			NpcFlags = 0;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( OozeDrops.CrimsonOoze, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class CapturedFelwoodOoze : BaseCreature
	{
		public CapturedFelwoodOoze() : base()
		{
			Id = 10290;
			Level = RandomLevel( 30 );
			Name = "Captured Felwood Ooze";
			Model = 2236;
			AttackSpeed = 1693;
			CombatReach = 2.5f;
			BoundingRadius = 0.561f;
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
			ResistShadow = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			Flags1 = 0x066;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
		}
	}
	public class GargantuanOoze : BaseCreature
	{
		public GargantuanOoze() : base()
		{
			Id = 9621;
			Level = RandomLevel( 50 ,52 );
			Name = "Gargantuan Ooze";
			Model = 9595;
			AttackSpeed = 1399;
			CombatReach = 2.5f;
			BoundingRadius = 0.561f;
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
			ResistShadow = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( OozeDrops.GargantuanOoze, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class ClonedOoze : BaseCreature
	{
		public ClonedOoze() : base()
		{
			Id = 9477;
			Level = RandomLevel( 51 );
			Name = "Cloned Ooze";
			Model = 4754;
			AttackSpeed = 2000;
			CombatReach = 1.87f;
			BoundingRadius = 0.8985f;
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
			ResistShadow = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			NpcFlags = 0;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( OozeDrops.ClonedOoze, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class ForestOoze : BaseCreature
	{
		public ForestOoze() : base()
		{
			Id = 8766;
			Level = RandomLevel( 52 ,53 );
			Name = "Forest Ooze";
			Model = 1306;
			AttackSpeed = 2000;
			CombatReach = 1.87f;
			BoundingRadius = 0.8985f;
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
			ResistShadow = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			NpcFlags = 0;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( OozeDrops.ForestOoze, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class Oozeling : BaseCreature
	{
		public Oozeling() : base()
		{
			Id = 8257;
			Level = RandomLevel( 40 );
			Name = "Oozeling";
			Model = 7763;
			AttackSpeed = 1500;
			CombatReach = 0.75f;
			BoundingRadius = 0.175f;
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
			ResistShadow = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			Flags1 = 0x04;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( OozeDrops.Oozeling, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class TaintedOoze : BaseCreature
	{
		public TaintedOoze() : base()
		{
			Id = 7092;
			Level = RandomLevel( 51 );
			Name = "Tainted Ooze";
			Model = 11141;
			AttackSpeed = 2000;
			CombatReach = 1.87f;
			BoundingRadius = 0.8985f;
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
			ResistShadow = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( OozeDrops.TaintedOoze, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class VileOoze : BaseCreature
	{
		public VileOoze() : base()
		{
			Id = 7093;
			Level = RandomLevel( 52 ,53 );
			Name = "Vile Ooze";
			Model = 1306;
			AttackSpeed = 1386;
			CombatReach = 2.5f;
			BoundingRadius = 0.561f;
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
			ResistShadow = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( OozeDrops.VileOoze, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class CursedOoze : BaseCreature
	{
		public CursedOoze() : base()
		{
			Id = 7086;
			Level = RandomLevel( 50 );
			Name = "Cursed Ooze";
			Model = 11137;
			AttackSpeed = 2000;
			CombatReach = 1.62f;
			BoundingRadius = 0.7787f;
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
			ResistShadow = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( OozeDrops.CursedOoze, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class MuculentOoze : BaseCreature
	{
		public MuculentOoze() : base()
		{
			Id = 6556;
			Level = RandomLevel( 49 );
			Name = "Muculent Ooze";
			Model = 11140;
			AttackSpeed = 2000;
			CombatReach = 1.62f;
			BoundingRadius = 0.7787f;
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
			ResistShadow = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			NpcFlags = 0;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( OozeDrops.MuculentOoze, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class GlutinousOoze : BaseCreature
	{
		public GlutinousOoze() : base()
		{
			Id = 6559;
			Level = RandomLevel( 53 );
			Name = "Glutinous Ooze";
			Model = 1146;
			AttackSpeed = 2000;
			CombatReach = 2.18f;
			BoundingRadius = 0.643f;
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
			ResistShadow = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			NpcFlags = 0;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( OozeDrops.GlutinousOoze, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class FungalOoze : BaseCreature
	{
		public FungalOoze() : base()
		{
			Id = 5235;
			Level = RandomLevel( 46 );
			Name = "Fungal Ooze";
			Model = 682;
			AttackSpeed = 2000;
			CombatReach = 1.87f;
			BoundingRadius = 0.8985f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage(1f+2.8f*Level,1f+3.5*Level); 
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 100;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			BaseMana = Level * 70;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( OozeDrops.FungalOoze, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class SaturatedOoze : BaseCreature
	{
		public SaturatedOoze() : base()
		{
			Id = 5228;
			Level = RandomLevel( 47 );
			Name = "Saturated Ooze";
			Model = 682;
			AttackSpeed = 2000;
			CombatReach = 1.87f;
			BoundingRadius = 0.8985f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage(1f+2.8f*Level,1f+3.5*Level); 
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 100;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			BaseMana = Level * 70;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( OozeDrops.SaturatedOoze, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class EmeraldOoze : BaseCreature
	{
		public EmeraldOoze() : base()
		{
			Id = 4469;
			Level = RandomLevel( 46 );
			Name = "Emerald Ooze";
			Model = 358;
			AttackSpeed = 2000;
			CombatReach = 1.25f;
			BoundingRadius = 0.599f;
			Armor = MobArmorHP.GetMobArmor( Level );
			SetDamage(1f+2.8f*Level,1f+3.5*Level); 
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 100;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			BaseMana = Level * 70;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( OozeDrops.EmeraldOoze, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class SwampOoze : BaseCreature
	{
		public SwampOoze() : base()
		{
			Id = 4391;
			Level = RandomLevel( 37 );
			Name = "Swamp Ooze";
			Model = 1145;
			AttackSpeed = 2000;
			CombatReach = 1.04f;
			BoundingRadius = 0.68885f;
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
			ResistShadow = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			NpcFlags = 0;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( OozeDrops.SwampOoze, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class CorrosiveSwampOoze : BaseCreature
	{
		public CorrosiveSwampOoze() : base()
		{
			Id = 4392;
			Level = RandomLevel( 40 );
			Name = "Corrosive Swamp Ooze";
			Model = 2569;
			AttackSpeed = 2000;
			CombatReach = 1.04f;
			BoundingRadius = 0.68885f;
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
			ResistShadow = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( OozeDrops.CorrosiveSwampOoze, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class AcidicSwampOoze : BaseCreature
	{
		public AcidicSwampOoze() : base()
		{
			Id = 4393;
			Level = RandomLevel( 39 );
			Name = "Acidic Swamp Ooze";
			Model = 11137;
			AttackSpeed = 2000;
			CombatReach = 1.62f;
			BoundingRadius = 0.7787f;
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
			ResistShadow = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( OozeDrops.AcidicSwampOoze, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class JadeOoze : BaseCreature
	{
		public JadeOoze() : base()
		{
			Id = 2656;
			Level = RandomLevel( 48 );
			Name = "Jade Ooze";
			Model = 11137;
			AttackSpeed = 2000;
			CombatReach = 1.62f;
			BoundingRadius = 0.7787f;
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
			ResistShadow = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			NpcFlags = 0;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( OozeDrops.JadeOoze, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class DevouringOoze : BaseCreature
	{
		public DevouringOoze() : base()
		{
			Id = 1808;
			Level = RandomLevel( 53 ,56 );
			Name = "Devouring Ooze";
			Model = 11139;
			AttackSpeed = 1357;
			CombatReach = 2.7f;
			BoundingRadius = 0.561f;
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
			ResistShadow = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( OozeDrops.DevouringOoze, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class BlackOoze : BaseCreature
	{
		public BlackOoze() : base()
		{
			Id = 1032;
			Level = RandomLevel( 23 );
			Name = "Black Ooze";
			Model = 767;
			AttackSpeed = 2000;
			CombatReach = 1.04f;
			BoundingRadius = 0.68885f;
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
			ResistShadow = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			NpcFlags = 0;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( OozeDrops.BlackOoze, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	public class MonstrousOoze : BaseCreature
	{
		public MonstrousOoze() : base()
		{
			Id = 1033;
			Level = RandomLevel( 25 ,26 );
			Name = "Monstrous Ooze";
			Model = 11139;
			AttackSpeed = 2000;
			CombatReach = 1.62f;
			BoundingRadius = 0.7787f;
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
			ResistShadow = 100;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = Level * 70;
			NpcFlags = 0;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( OozeDrops.MonstrousOoze, 100f ),new BaseTreasure( Drops.MoneyA, 100f ) };
		}
	}
	
}