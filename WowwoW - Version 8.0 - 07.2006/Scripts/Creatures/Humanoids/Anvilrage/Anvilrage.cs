using System;
using Server;
using Server.Items;
using Server.Quests;

namespace Server.Creatures
{
	public class AnvilrageCaptain : BaseCreature
	{
		public AnvilrageCaptain() : base()
		{
			Id = 8903;
			Level = RandomLevel( 53 ,56 );
			Name = "Anvilrage Captain";
			Model = 8749;
			AttackSpeed = 1131;
			CombatReach = 0.8f;
			BoundingRadius = 0.561f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 100;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 20;
			ResistShadow = 0;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.AmazingDrops, 100f ) };
		}
	}
	public class AnvilrageReservist : BaseCreature
	{
		public AnvilrageReservist() : base()
		{
			Id = 8901;
			Level = RandomLevel( 49 ,55 );
			Name = "Anvilrage Reservist";
			Model = 8755;
			AttackSpeed = 1386;
			CombatReach = 0.8f;
			BoundingRadius = 0.3123f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 100;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 20;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			Flags1 = 0x080004;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7487, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0), new Item ( 1755, (InventoryTypes)14, 4, 6, 1, 4, 0, 0, 0), new Item ( 6593, (InventoryTypes)26, 2, 3, 1, 0, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyC , 100f )
				, new BaseTreasure( WorldDrops.AmazingDrops, 100f ) };
		}
	}
	public class AnvilrageOverseer : BaseCreature
	{
		public AnvilrageOverseer() : base()
		{
			Id = 8889;
			Level = RandomLevel( 49 );
			Name = "Anvilrage Overseer";
			Model = 8754;
			AttackSpeed = 1333;
			CombatReach = 1.5f;
			BoundingRadius = 0.347f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 100;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 20;
			ResistShadow = 0;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7434, (InventoryTypes)13, 2, 15, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.AmazingDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( RelicCofferKey ), 8.49f )
					, new Loot( typeof( ACrumpledUpNote ), 0.52f )
					, new Loot( typeof( DarkIronFannyPack ), 8.73f )
					, new Loot( typeof( LibramOfRumination ), 0.02f )
					, new Loot( typeof( LibramOfConstitution ), 0.01f )
					, new Loot( typeof( LibramOfTenacity ), 0.05f )
					, new Loot( typeof( LibramOfResilience ), 0.03f )
					, new Loot( typeof( LibramOfVoracity ), 0.03f )
					, new Loot( typeof( BlackDiamond ), 0.47f )
					, new Loot( typeof( Runecloth ), 29.8f )
					, new Loot( typeof( DarkIronResidue ), 18.9f )
					}, 100f ) };
		}
	}
	public class AnvilrageWarden : BaseCreature
	{
		public AnvilrageWarden() : base()
		{
			Id = 8890;
			Level = RandomLevel( 50 );
			Name = "Anvilrage Warden";
			Model = 8758;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.347f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 100;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 20;
			ResistShadow = 0;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7488, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0), new Item ( 1685, (InventoryTypes)14, 4, 6, 1, 4, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.AmazingDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( RelicCofferKey ), 22.6f )
					, new Loot( typeof( ACrumpledUpNote ), 1.00f )
					, new Loot( typeof( LibramOfRumination ), 0.09f )
					, new Loot( typeof( LibramOfConstitution ), 0.08f )
					, new Loot( typeof( LibramOfTenacity ), 0.08f )
					, new Loot( typeof( LibramOfResilience ), 0.04f )
					, new Loot( typeof( LibramOfVoracity ), 0.14f )
					, new Loot( typeof( BlackDiamond ), 1.17f )
					, new Loot( typeof( Runecloth ), 76.0f )
					, new Loot( typeof( DarkIronResidue ), 48.2f )
					}, 100f ) };
		}
	}
	public class AnvilrageGuardsman : BaseCreature
	{
		public AnvilrageGuardsman() : base()
		{
			Id = 8891;
			Level = RandomLevel( 45 ,51 );
			Name = "Anvilrage Guardsman";
			Model = 8750;
			AttackSpeed = 1201;
			CombatReach = 0.8f;
			BoundingRadius = 0.347f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 100;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 20;
			ResistShadow = 0;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7476, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0), new Item ( 1705, (InventoryTypes)14, 4, 6, 1, 4, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.AmazingDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( RelicCofferKey ), 8.41f )
					, new Loot( typeof( ACrumpledUpNote ), 0.26f )
					, new Loot( typeof( DarkIronFannyPack ), 7.44f )
					, new Loot( typeof( LibramOfRumination ), 0.02f )
					, new Loot( typeof( LibramOfConstitution ), 0.03f )
					, new Loot( typeof( LibramOfTenacity ), 0.02f )
					, new Loot( typeof( LibramOfResilience ), 0.02f )
					, new Loot( typeof( LibramOfVoracity ), 0.03f )
					, new Loot( typeof( BlackDiamond ), 0.51f )
					, new Loot( typeof( Runecloth ), 27.7f )
					, new Loot( typeof( DarkIronResidue ), 18.1f )
					}, 100f ) };
		}
	}
	public class AnvilrageFootman : BaseCreature
	{
		public AnvilrageFootman() : base()
		{
			Id = 8892;
			Level = RandomLevel( 46 ,52 );
			Name = "Anvilrage Footman";
			Model = 8718;
			AttackSpeed = 1189;
			CombatReach = 0.8f;
			BoundingRadius = 0.347f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 100;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 20;
			ResistShadow = 0;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7487, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0), new Item ( 7487, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.AmazingDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( RelicCofferKey ), 8.36f )
					, new Loot( typeof( ACrumpledUpNote ), 0.24f )
					, new Loot( typeof( DarkIronFannyPack ), 6.48f )
					, new Loot( typeof( LibramOfRumination ), 0.03f )
					, new Loot( typeof( LibramOfConstitution ), 0.03f )
					, new Loot( typeof( LibramOfTenacity ), 0.03f )
					, new Loot( typeof( LibramOfResilience ), 0.03f )
					, new Loot( typeof( LibramOfVoracity ), 0.04f )
					, new Loot( typeof( BlackDiamond ), 0.48f )
					, new Loot( typeof( Runecloth ), 27.6f )
					, new Loot( typeof( DarkIronResidue ), 18.4f )
					}, 100f ) };
		}
	}
	public class AnvilrageSoldier : BaseCreature
	{
		public AnvilrageSoldier() : base()
		{
			Id = 8893;
			Level = RandomLevel( 51 ,53 );
			Name = "Anvilrage Soldier";
			Model = 8757;
			AttackSpeed = 1155;
			CombatReach = 0.8f;
			BoundingRadius = 0.347f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 100;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 20;
			ResistShadow = 0;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 3797, (InventoryTypes)17, 2, 1, 1, 1, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.AmazingDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( RelicCofferKey ), 8.09f )
					, new Loot( typeof( ACrumpledUpNote ), 0.23f )
					, new Loot( typeof( DarkIronFannyPack ), 6.72f )
					, new Loot( typeof( LibramOfRumination ), 0.03f )
					, new Loot( typeof( LibramOfConstitution ), 0.04f )
					, new Loot( typeof( LibramOfTenacity ), 0.03f )
					, new Loot( typeof( LibramOfResilience ), 0.03f )
					, new Loot( typeof( LibramOfVoracity ), 0.02f )
					, new Loot( typeof( BlackDiamond ), 0.53f )
					, new Loot( typeof( BattlechasersGreaves ), 0.02f )
					, new Loot( typeof( Runecloth ), 28.2f )
					, new Loot( typeof( DarkIronResidue ), 16.6f )
					}, 100f ) };
		}
	}
	public class AnvilrageMedic : BaseCreature
	{
		public AnvilrageMedic() : base()
		{
			Id = 8894;
			Level = RandomLevel( 48 ,53 );
			Name = "Anvilrage Medic";
			Model = 8752;
			AttackSpeed = 1178;
			CombatReach = 0.8f;
			BoundingRadius = 0.347f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 100;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 20;
			ResistShadow = 0;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 1926, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.AmazingDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( RelicCofferKey ), 7.90f )
					, new Loot( typeof( ACrumpledUpNote ), 0.19f )
					, new Loot( typeof( DarkIronFannyPack ), 5.97f )
					, new Loot( typeof( LibramOfRumination ), 0.01f )
					, new Loot( typeof( LibramOfConstitution ), 0.01f )
					, new Loot( typeof( LibramOfTenacity ), 0.01f )
					, new Loot( typeof( LibramOfVoracity ), 0.03f )
					, new Loot( typeof( BlackDiamond ), 0.47f )
					, new Loot( typeof( Runecloth ), 27.4f )
					, new Loot( typeof( DarkIronResidue ), 18.0f )
					}, 100f ) };
		}
	}
	
}