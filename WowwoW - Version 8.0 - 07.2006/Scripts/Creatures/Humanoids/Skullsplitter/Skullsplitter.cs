using System;
using Server;
using Server.Items;
using Server.Quests;

namespace Server.Creatures
{
	public class KruegSkullsplitter : BaseNPC
	{
		public KruegSkullsplitter() : base()
		{
			Id = 4544;
			Level = RandomLevel( 37 );
			Name = "Krueg Skullsplitter";
			NpcText00 = "Greetings $N, I am Krueg Skullsplitter.";
			Model = 4204;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.372f;
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
			NpcFlags = (int)NpcActions.Dialog ;
			Flags1 = 0x08400046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.MagranClanCentaure;
			AIEngine = new DefensiveAnimalAI( this );
			Equip( new Item ( 3385, (InventoryTypes)17, 2, 1, 1, 1, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyC , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f ) };
		}
	}
	public class SkullsplitterAxeThrower : BaseCreature
	{
		public SkullsplitterAxeThrower() : base()
		{
			Id = 696;
			Level = RandomLevel( 39 );
			Name = "Skullsplitter Axe Thrower";
			Model = 4622;
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
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.MoroGai;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7428, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0), new Item ( 16751, (InventoryTypes)25, 2, 16, 1, 0, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyC , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f )
				, new BaseTreasure( SkullsplitterDrops.SkullsplitterAxeThrower, 100f ) };
		}
	}
	public class SkullsplitterBeastmaster : BaseCreature
	{
		public SkullsplitterBeastmaster() : base()
		{
			Id = 784;
			Level = RandomLevel( 42 );
			Name = "Skullsplitter Beastmaster";
			Model = 4624;
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
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.MoroGai;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7426, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0), new Item ( 6233, (InventoryTypes)15, 2, 2, 2, 0, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyC , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f )
				, new BaseTreasure( SkullsplitterDrops.SkullsplitterBeastmaster, 100f ) };
		}
	}
	public class SkullsplitterBerserker : BaseCreature
	{
		public SkullsplitterBerserker() : base()
		{
			Id = 783;
			Level = RandomLevel( 43 );
			Name = "Skullsplitter Berserker";
			Model = 4623;
			AttackSpeed = 2400;
			CombatReach = 1.65f;
			BoundingRadius = 0.3366f;
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
			Faction = Factions.MoroGai;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 3797, (InventoryTypes)17, 2, 1, 1, 1, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyC , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f )
				, new BaseTreasure( SkullsplitterDrops.SkullsplitterBerserker, 100f ) };
		}
	}
	public class AnathekTheCruel : BaseCreature
	{
		public AnathekTheCruel() : base()
		{
			Id = 1059;
			Level = RandomLevel( 45 );
			Name = "Ana'thek the Cruel";
			Guild = "Skullsplitter Chief";
			Model = 4634;
			AttackSpeed = 2800;
			CombatReach = 2.5f;
			BoundingRadius = 0.4896f;
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
			Faction = Factions.MoroGai;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 3879, (InventoryTypes)17, 2, 5, 2, 1, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyC , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f )
				, new BaseTreasure( SkullsplitterDrops.AnathekTheCruel, 100f ) };
		}
	}
	public class MoghTheUndying : BaseCreature
	{
		public MoghTheUndying() : base()
		{
			Id = 1060;
			Level = RandomLevel( 44 );
			Name = "Mogh the Undying";
			Guild = "Skullsplitter Clan Witchdoctor";
			Model = 4633;
			AttackSpeed = 2000;
			CombatReach = 2.3f;
			BoundingRadius = 0.4284f;
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
			Faction = Factions.MoroGai;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 1926, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyC , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f )
				, new BaseTreasure( SkullsplitterDrops.MoghTheUndying, 100f ) };
		}
	}
	public class SkullsplitterHeadhunter : BaseCreature
	{
		public SkullsplitterHeadhunter() : base()
		{
			Id = 781;
			Level = RandomLevel( 44 );
			Name = "Skullsplitter Headhunter";
			Model = 4635;
			AttackSpeed = 2000;
			CombatReach = 1.65f;
			BoundingRadius = 0.3366f;
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
			Faction = Factions.MoroGai;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7427, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0), new Item ( 22671, (InventoryTypes)25, 2, 16, 1, 0, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyC , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f )
				, new BaseTreasure( SkullsplitterDrops.SkullsplitterHeadhunter, 100f ) };
		}
	}
	public class SkullsplitterHunter : BaseCreature
	{
		public SkullsplitterHunter() : base()
		{
			Id = 669;
			Level = RandomLevel( 42 );
			Name = "Skullsplitter Hunter";
			Model = 4628;
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
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.MoroGai;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7433, (InventoryTypes)13, 2, 15, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyC , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f )
				, new BaseTreasure( SkullsplitterDrops.SkullsplitterHunter, 100f ) };
		}
	}
	public class SkullsplitterMystic : BaseCreature
	{
		public SkullsplitterMystic() : base()
		{
			Id = 780;
			Level = RandomLevel( 40 );
			Name = "Skullsplitter Mystic";
			Model = 4616;
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
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.MoroGai;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 1600, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyC , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f )
				, new BaseTreasure( SkullsplitterDrops.SkullsplitterMystic, 100f ) };
		}
	}

	public class SkullsplitterScout : BaseCreature
	{
		public SkullsplitterScout() : base()
		{
			Id = 782;
			Level = RandomLevel( 42 );
			Name = "Skullsplitter Scout";
			Model = 4625;
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
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.MoroGai;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7434, (InventoryTypes)13, 2, 15, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyC , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f )
				, new BaseTreasure( SkullsplitterDrops.SkullsplitterScout, 100f ) };
		}
	}
/*	please have a look at this
	public class ScullsplitterSpeaker : BaseCreature
	{
		public ScullsplitterSpeaker : base()
		{
			Id = 11390;
			Level = RandomLevel( 61 );
			Name = "Skullsplitter Speaker";
			Model = ?;
			AttackSpeed = 2000;
			CombatReach = 1.65f;
			BoundingRadius = 0.3366f;
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
			Faction = (Factions)?;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 1600, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyC , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f )
				, new BaseTreasure( SkullsplitterDrops.SkullsplitterSpiritchaser, 100f ) };
		}
	}
*/
	public class SkullsplitterSpiritchaser : BaseCreature
	{
		public SkullsplitterSpiritchaser() : base()
		{
			Id = 672;
			Level = RandomLevel( 44 );
			Name = "Skullsplitter Spiritchaser";
			Model = 4621;
			AttackSpeed = 2000;
			CombatReach = 1.65f;
			BoundingRadius = 0.3366f;
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
			Faction = Factions.MoroGai;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( SkullsplitterDrops.SkullsplitterSpeaker, 100f ) };
		}
	}
	public class SkullsplitterWarrior : BaseCreature
	{
		public SkullsplitterWarrior() : base()
		{
			Id = 667;
			Level = RandomLevel( 39 );
			Name = "Skullsplitter Warrior";
			Model = 4632;
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
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.MoroGai;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7440, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0), new Item ( 1706, (InventoryTypes)14, 4, 6, 1, 4, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyC , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f )
				, new BaseTreasure( SkullsplitterDrops.SkullsplitterWarrior, 100f ) };
		}
	}
	public class SkullsplitterWitchDoctor : BaseCreature
	{
		public SkullsplitterWitchDoctor() : base()
		{
			Id = 670;
			Level = RandomLevel( 41 );
			Name = "Skullsplitter Witch Doctor";
			Model = 4627;
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
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.MoroGai;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 1600, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyC , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f )
				, new BaseTreasure( SkullsplitterDrops.SkullsplitterWitchDoctor, 100f ) };
		}
	}
}