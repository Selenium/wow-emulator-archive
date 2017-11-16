using System;
using Server;
using Server.Items;
using Server.Quests;

namespace Server.Creatures
{
	public class RedridgeThrasher : BaseCreature
	{
		public RedridgeThrasher() : base()
		{
			Id = 712;
			Level = RandomLevel( 14 );
			Name = "Redridge Thrasher";
			Model = 489;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.376f;
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
			ResistNature = 50;
			ResistShadow = 0;
			Block=Level+30;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 0;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			Equip( new Item ( 7430, (InventoryTypes)13, 2, 13, 1, 7, 0, 0, 0) );
		}
	}
	public class RedridgeDrudger : BaseCreature
	{
		public RedridgeDrudger() : base()
		{
			Id = 580;
			Level = RandomLevel( 19 ,21 );
			Name = "Redridge Drudger";
			Model = 551;
			AttackSpeed = 1833;
			CombatReach = 1.07f;
			BoundingRadius = 0.575f;
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
			ResistNature = 50;
			ResistShadow = 0;
			Block=Level+30;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 1003;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			Equip( new Item ( 7442, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0), new Item ( 7476, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( RedridgeGrudgerDrops.RedridgeGrudger, 100f ) };
		}
	}
	public class RedridgeAlpha : BaseCreature
	{
		public RedridgeAlpha() : base()
		{
			Id = 445;
			Level = RandomLevel( 21 );
			Name = "Redridge Alpha";
			Model = 609;
			AttackSpeed = 2000;
			CombatReach = 1.95f;
			BoundingRadius = 0.4888f;
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
			ResistNature = 50;
			ResistShadow = 0;
			Block=Level+30;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 76;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			Equip( new Item ( 7429, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( RedridgeAlphaDrops.RedridgeAlpha, 100f ) };
		}
	}
	public class RedridgeBasher : BaseCreature
	{
		public RedridgeBasher() : base()
		{
			Id = 446;
			Level = RandomLevel( 18 ,20 );
			Name = "Redridge Basher";
			Model = 609;
			AttackSpeed = 2000;
			CombatReach = 1.95f;
			BoundingRadius = 0.4888f;
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
			ResistNature = 50;
			ResistShadow = 0;
			Block=Level+30;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 68;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			Equip( new Item ( 7476, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0), new Item ( 1755, (InventoryTypes)14, 4, 6, 1, 4, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( RedridgeBruteDrops.RedridgeBrute, 100f ) };
		}
	}
	public class RedridgeMystic : BaseCreature
	{
		public RedridgeMystic() : base()
		{
			Id = 430;
			Level = RandomLevel( 18 );
			Name = "Redridge Mystic";
			Model = 10789;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.376f;
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
			ResistNature = 50;
			ResistShadow = 0;
			Block=Level+30;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 1020;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			Equip( new Item ( 1600, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( RedridgeBruteDrops.RedridgeBrute, 100f ) };
		}
	}
	public class RedridgeMongrel : BaseCreature
	{
		public RedridgeMongrel() : base()
		{
			Id = 423;
			Level = RandomLevel( 16 );
			Name = "Redridge Mongrel";
			Model = 487;
			AttackSpeed = 2000;
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
			ResistNature = 50;
			ResistShadow = 0;
			Block=Level+30;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 0;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			Equip( new Item ( 7440, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0) );Loots = new BaseTreasure[]{ new BaseTreasure( RedridgeMongrelDrops.RedridgeMongrel, 100f ) };
		}
	}
	public class RedridgePoacher : BaseCreature
	{
		public RedridgePoacher() : base()
		{
			Id = 424;
			Level = RandomLevel( 17 );
			Name = "Redridge Poacher";
			Model = 551;
			AttackSpeed = 2000;
			CombatReach = 1.07f;
			BoundingRadius = 0.575f;
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
			ResistNature = 50;
			ResistShadow = 0;
			Block=Level+30;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 0;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			Equip( new Item ( 7428, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0), new Item ( 10671, (InventoryTypes)26, 2, 18, 1, 0, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( RedridgePoacherDrops.RedridgePoacher, 100f ) };
		}
	}
	public class RedridgeBrute : BaseCreature
	{
		public RedridgeBrute() : base()
		{
			Id = 426;
			Level = RandomLevel( 17 );
			Name = "Redridge Brute";
			Model = 500;
			AttackSpeed = 2700;
			CombatReach = 1.07f;
			BoundingRadius = 0.4324f;
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
			ResistNature = 50;
			ResistShadow = 0;
			Block=Level+30;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			BaseMana = 0;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			Equip( new Item ( 2839, (InventoryTypes)17, 2, 5, 2, 1, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( RedridgeBruteDrops.RedridgeBrute, 100f ) };
		}
	}
	
}