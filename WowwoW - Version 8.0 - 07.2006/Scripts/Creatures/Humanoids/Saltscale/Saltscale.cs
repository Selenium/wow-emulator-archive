using System;
using Server;
using Server.Items;
using Server.Quests;

namespace Server.Creatures
{
	public class SaltscaleHunter : BaseCreature
	{
		public SaltscaleHunter() : base()
		{
			Id = 879;
			Level = RandomLevel( 36 );
			Name = "Saltscale Hunter";
			Model = 1079;
			AttackSpeed = 2000;
			CombatReach = 2.25f;
			BoundingRadius = 0.6255f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 30;
			ResistFire = 0;
			ResistFrost = 60;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			Flags1 = 0x010080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7481, (InventoryTypes)17, 2, 6, 1, 2, 0, 0, 0), new Item ( 22671, (InventoryTypes)25, 2, 16, 1, 0, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( ShinyFishScales ), 25.3f )
					, new Loot( typeof( FishOil ), 26.0f )
					, new Loot( typeof( TheSecondTrollLegend ), 0.01f )
					, new Loot( typeof( GreenHillsOfStranglethornPage1 ), 0.53f )
					, new Loot( typeof( GreenHillsOfStranglethornPage4 ), 0.54f )
					, new Loot( typeof( GreenHillsOfStranglethornPage6 ), 0.54f )
					, new Loot( typeof( GreenHillsOfStranglethornPage8 ), 0.47f )
					, new Loot( typeof( GreenHillsOfStranglethornPage10 ), 0.57f )
					, new Loot( typeof( GreenHillsOfStranglethornPage11 ), 0.40f )
					, new Loot( typeof( GreenHillsOfStranglethornPage14 ), 0.69f )
					, new Loot( typeof( GreenHillsOfStranglethornPage16 ), 0.56f )
					, new Loot( typeof( GreenHillsOfStranglethornPage18 ), 0.62f )
					, new Loot( typeof( GreenHillsOfStranglethornPage20 ), 0.46f )
					, new Loot( typeof( GreenHillsOfStranglethornPage21 ), 0.74f )
					, new Loot( typeof( GreenHillsOfStranglethornPage24 ), 0.64f )
					, new Loot( typeof( GreenHillsOfStranglethornPage25 ), 0.63f )
					, new Loot( typeof( GreenHillsOfStranglethornPage26 ), 0.59f )
					, new Loot( typeof( GreenHillsOfStranglethornPage27 ), 0.70f )
					, new Loot( typeof( GoldBar ), 0.01f )
					, new Loot( typeof( TabletShard ), 0.09f )
					, new Loot( typeof( BluePearl ), 0.19f )
					, new Loot( typeof( GiantClamMeat ), 0.01f )
					, new Loot( typeof( ThickMurlocScale ), 8.38f )
					, new Loot( typeof( EncrustedTailFin ), 52.9f )
					}, 100f ) };
		}
	}
	public class SaltscaleForager : BaseCreature
	{
		public SaltscaleForager() : base()
		{
			Id = 877;
			Level = RandomLevel( 35 );
			Name = "Saltscale Forager";
			Model = 4920;
			AttackSpeed = 2000;
			CombatReach = 2.25f;
			BoundingRadius = 0.6255f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 30;
			ResistFire = 0;
			ResistFrost = 60;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			Flags1 = 0x010080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7466, (InventoryTypes)13, 2, 14, 1, 0, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( ShinyFishScales ), 27.6f )
					, new Loot( typeof( FishOil ), 26.3f )
					, new Loot( typeof( CuirboulliBoots ), 0.01f )
					, new Loot( typeof( GreenHillsOfStranglethornPage1 ), 0.38f )
					, new Loot( typeof( GreenHillsOfStranglethornPage4 ), 0.71f )
					, new Loot( typeof( GreenHillsOfStranglethornPage6 ), 0.67f )
					, new Loot( typeof( GreenHillsOfStranglethornPage8 ), 0.60f )
					, new Loot( typeof( GreenHillsOfStranglethornPage10 ), 0.76f )
					, new Loot( typeof( GreenHillsOfStranglethornPage11 ), 0.71f )
					, new Loot( typeof( GreenHillsOfStranglethornPage14 ), 0.49f )
					, new Loot( typeof( GreenHillsOfStranglethornPage16 ), 0.71f )
					, new Loot( typeof( GreenHillsOfStranglethornPage18 ), 0.79f )
					, new Loot( typeof( GreenHillsOfStranglethornPage20 ), 0.59f )
					, new Loot( typeof( GreenHillsOfStranglethornPage21 ), 0.54f )
					, new Loot( typeof( GreenHillsOfStranglethornPage25 ), 0.87f )
					, new Loot( typeof( GreenHillsOfStranglethornPage26 ), 0.76f )
					, new Loot( typeof( GreenHillsOfStranglethornPage27 ), 0.65f )
					, new Loot( typeof( BluePearl ), 0.20f )
					, new Loot( typeof( GiantClamMeat ), 0.06f )
					, new Loot( typeof( ThickMurlocScale ), 9.00f )
					, new Loot( typeof( EncrustedTailFin ), 61.5f )
					}, 100f ) };
		}
	}
	public class SaltscaleTideLord : BaseCreature
	{
		public SaltscaleTideLord() : base()
		{
			Id = 875;
			Level = RandomLevel( 33 ,37 );
			Name = "Saltscale Tide Lord";
			Model = 391;
			AttackSpeed = 1352;
			CombatReach = 0.8f;
			BoundingRadius = 0.561f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 30;
			ResistFire = 0;
			ResistFrost = 60;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			Flags1 = 0x010080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7481, (InventoryTypes)17, 2, 6, 1, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( ShinyFishScales ), 25.4f )
					, new Loot( typeof( FishOil ), 25.1f )
					, new Loot( typeof( TheSecondTrollLegend ), 0.10f )
					, new Loot( typeof( WoolCloth ), 0.05f )
					, new Loot( typeof( GreenHillsOfStranglethornPage1 ), 0.32f )
					, new Loot( typeof( GreenHillsOfStranglethornPage4 ), 0.59f )
					, new Loot( typeof( GreenHillsOfStranglethornPage6 ), 0.91f )
					, new Loot( typeof( GreenHillsOfStranglethornPage8 ), 0.48f )
					, new Loot( typeof( GreenHillsOfStranglethornPage10 ), 0.64f )
					, new Loot( typeof( GreenHillsOfStranglethornPage11 ), 0.37f )
					, new Loot( typeof( GreenHillsOfStranglethornPage14 ), 0.53f )
					, new Loot( typeof( GreenHillsOfStranglethornPage16 ), 0.86f )
					, new Loot( typeof( GreenHillsOfStranglethornPage18 ), 0.75f )
					, new Loot( typeof( GreenHillsOfStranglethornPage20 ), 0.48f )
					, new Loot( typeof( GreenHillsOfStranglethornPage21 ), 0.64f )
					, new Loot( typeof( GreenHillsOfStranglethornPage24 ), 0.43f )
					, new Loot( typeof( GreenHillsOfStranglethornPage25 ), 0.53f )
					, new Loot( typeof( GreenHillsOfStranglethornPage26 ), 0.26f )
					, new Loot( typeof( GreenHillsOfStranglethornPage27 ), 0.48f )
					, new Loot( typeof( TabletShard ), 0.05f )
					, new Loot( typeof( ThickMurlocScale ), 10.6f )
					, new Loot( typeof( EncrustedTailFin ), 40.2f )
					}, 100f ) };
		}
	}
	public class SaltscaleWarrior : BaseCreature
	{
		public SaltscaleWarrior() : base()
		{
			Id = 871;
			Level = RandomLevel( 36 );
			Name = "Saltscale Warrior";
			Model = 506;
			AttackSpeed = 2000;
			CombatReach = 2.62f;
			BoundingRadius = 0.72975f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 30;
			ResistFire = 0;
			ResistFrost = 60;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			Flags1 = 0x010080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7481, (InventoryTypes)17, 2, 6, 1, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( ShinyFishScales ), 25.3f )
					, new Loot( typeof( FishOil ), 25.4f )
					, new Loot( typeof( TheSecondTrollLegend ), 0.01f )
					, new Loot( typeof( GreenHillsOfStranglethornPage1 ), 0.83f )
					, new Loot( typeof( GreenHillsOfStranglethornPage4 ), 0.72f )
					, new Loot( typeof( GreenHillsOfStranglethornPage6 ), 0.65f )
					, new Loot( typeof( GreenHillsOfStranglethornPage8 ), 0.73f )
					, new Loot( typeof( GreenHillsOfStranglethornPage10 ), 0.80f )
					, new Loot( typeof( GreenHillsOfStranglethornPage11 ), 0.63f )
					, new Loot( typeof( GreenHillsOfStranglethornPage14 ), 0.43f )
					, new Loot( typeof( GreenHillsOfStranglethornPage16 ), 0.66f )
					, new Loot( typeof( GreenHillsOfStranglethornPage18 ), 0.66f )
					, new Loot( typeof( GreenHillsOfStranglethornPage20 ), 0.58f )
					, new Loot( typeof( GreenHillsOfStranglethornPage21 ), 0.90f )
					, new Loot( typeof( GreenHillsOfStranglethornPage24 ), 0.54f )
					, new Loot( typeof( GreenHillsOfStranglethornPage25 ), 0.49f )
					, new Loot( typeof( GreenHillsOfStranglethornPage26 ), 0.54f )
					, new Loot( typeof( GreenHillsOfStranglethornPage27 ), 0.74f )
					, new Loot( typeof( TabletShard ), 0.13f )
					, new Loot( typeof( BluePearl ), 0.20f )
					, new Loot( typeof( GiantClamMeat ), 0.05f )
					, new Loot( typeof( ThickMurlocScale ), 8.69f )
					, new Loot( typeof( EncrustedTailFin ), 53.6f )
					}, 100f ) };
		}
	}
	public class SaltscaleOracle : BaseCreature
	{
		public SaltscaleOracle() : base()
		{
			Id = 873;
			Level = RandomLevel( 34 ,37 );
			Name = "Saltscale Oracle";
			Model = 11293;
			AttackSpeed = 1352;
			CombatReach = 0.8f;
			BoundingRadius = 0.561f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 30;
			ResistFire = 0;
			ResistFrost = 60;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			Flags1 = 0x010080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 1600, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( ShinyFishScales ), 24.8f )
					, new Loot( typeof( FishOil ), 24.4f )
					, new Loot( typeof( TheSecondTrollLegend ), 0.14f )
					, new Loot( typeof( GreenHillsOfStranglethornPage1 ), 0.65f )
					, new Loot( typeof( GreenHillsOfStranglethornPage4 ), 0.36f )
					, new Loot( typeof( GreenHillsOfStranglethornPage6 ), 0.32f )
					, new Loot( typeof( GreenHillsOfStranglethornPage8 ), 0.76f )
					, new Loot( typeof( GreenHillsOfStranglethornPage10 ), 0.76f )
					, new Loot( typeof( GreenHillsOfStranglethornPage11 ), 0.43f )
					, new Loot( typeof( GreenHillsOfStranglethornPage14 ), 0.54f )
					, new Loot( typeof( GreenHillsOfStranglethornPage16 ), 0.62f )
					, new Loot( typeof( GreenHillsOfStranglethornPage18 ), 0.69f )
					, new Loot( typeof( GreenHillsOfStranglethornPage20 ), 0.62f )
					, new Loot( typeof( GreenHillsOfStranglethornPage21 ), 0.69f )
					, new Loot( typeof( GreenHillsOfStranglethornPage24 ), 0.87f )
					, new Loot( typeof( GreenHillsOfStranglethornPage25 ), 0.54f )
					, new Loot( typeof( GreenHillsOfStranglethornPage26 ), 0.58f )
					, new Loot( typeof( GreenHillsOfStranglethornPage27 ), 0.54f )
					, new Loot( typeof( TabletShard ), 0.14f )
					, new Loot( typeof( ThickMurlocScale ), 8.50f )
					, new Loot( typeof( EncrustedTailFin ), 40.8f )
					}, 100f ) };
		}
	}
	
}