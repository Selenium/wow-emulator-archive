using System;
using Server;
using Server.Items;
using Server.Quests;

namespace Server.Creatures
{
	public class AtalaiDeathwalkersSpirit : BaseCreature
	{
		public AtalaiDeathwalkersSpirit() : base()
		{
			Id = 8317;
			Level = RandomLevel( 49 ,51 );
			Name = "Atal'ai Deathwalker's Spirit";
			Model = 146;
			AttackSpeed = 1178;
			CombatReach = 1.5f;
			BoundingRadius = 0.561f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 30;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 70;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			NpcType = (int)NpcTypes.Undead;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.AmazingDrops, 100f ) };
		}
	}
	public class MummifiedAtalai : BaseCreature
	{
		public MummifiedAtalai() : base()
		{
			Id = 5263;
			Level = RandomLevel( 47 );
			Name = "Mummified Atal'ai";
			Model = 4770;
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
			ResistFrost = 30;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 70;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			NpcType = (int)NpcTypes.Undead;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.AmazingDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( WintersBite ), 0.01f )
					, new Loot( typeof( MurkwaterGauntlets ), 0.01f )
					, new Loot( typeof( TrollSweat ), 30.2f )
					, new Loot( typeof( MageweaveCloth ), 22.7f )
					, new Loot( typeof( FetishOfHakkar ), 6.30f )
					, new Loot( typeof( FlaskOfBigMojo ), 8.31f )
					}, 100f ) };
		}
	}
	public class UnlivingAtalai : BaseCreature
	{
		public UnlivingAtalai() : base()
		{
			Id = 5267;
			Level = RandomLevel( 49 );
			Name = "Unliving Atal'ai";
			Model = 4772;
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
			ResistFrost = 30;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 70;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			NpcType = (int)NpcTypes.Undead;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7476, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.AmazingDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( Stealthblade ), 0.02f )
					, new Loot( typeof( Ragehammer ), 0.01f )
					, new Loot( typeof( SoulcatcherHalo ), 0.01f )
					, new Loot( typeof( MurkwaterGauntlets ), 0.03f )
					, new Loot( typeof( SilvershellLeggings ), 0.01f )
					, new Loot( typeof( TrollSweat ), 31.6f )
					, new Loot( typeof( MageweaveCloth ), 22.4f )
					, new Loot( typeof( FetishOfHakkar ), 4.96f )
					, new Loot( typeof( AtalaiTablet ), 0.01f )
					, new Loot( typeof( FlaskOfBigMojo ), 8.55f )
					}, 100f ) };
		}
	}
	public class AtalaiCorpseEater : BaseCreature
	{
		public AtalaiCorpseEater() : base()
		{
			Id = 5270;
			Level = RandomLevel( 50 );
			Name = "Atal'ai Corpse Eater";
			Model = 4778;
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
			ResistFrost = 30;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 70;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			NpcType = (int)NpcTypes.Undead;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7427, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.AmazingDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( TrollSweat ), 32.9f )
					, new Loot( typeof( MageweaveCloth ), 22.2f )
					, new Loot( typeof( FetishOfHakkar ), 4.14f )
					, new Loot( typeof( FlaskOfBigMojo ), 8.83f )
					}, 100f ) };
		}
	}
	public class AtalaiDeathwalker : BaseCreature
	{
		public AtalaiDeathwalker() : base()
		{
			Id = 5271;
			Level = RandomLevel( 50 );
			Name = "Atal'ai Deathwalker";
			Model = 4773;
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
			ResistFrost = 30;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 70;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			NpcType = (int)NpcTypes.Undead;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 3797, (InventoryTypes)17, 2, 1, 1, 1, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.AmazingDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( Stealthblade ), 0.01f )
					, new Loot( typeof( MistwalkerBoots ), 0.03f )
					, new Loot( typeof( MurkwaterGauntlets ), 0.01f )
					, new Loot( typeof( SilvershellLeggings ), 0.01f )
					, new Loot( typeof( TrollSweat ), 34.6f )
					, new Loot( typeof( MageweaveCloth ), 21.8f )
					, new Loot( typeof( FetishOfHakkar ), 2.77f )
					, new Loot( typeof( FlaskOfBigMojo ), 8.94f )
					}, 100f ) };
		}
	}
	public class AtalaiSkeleton : BaseCreature
	{
		public AtalaiSkeleton() : base()
		{
			Id = 8324;
			Level = RandomLevel( 45 ,47 );
			Name = "Atal'ai Skeleton";
			Model = 7555;
			AttackSpeed = 1470;
			CombatReach = 1.5f;
			BoundingRadius = 0.561f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 30;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 70;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			Flags1 = 0x080004;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyC , 100f )
				, new BaseTreasure( WorldDrops.AmazingDrops, 100f ) };
		}
	}
	public class AtalaiExile : BaseNPC
	{
		public AtalaiExile() : base()
		{
			Id = 5598;
			Level = RandomLevel( 45 );
			Name = "Atal'ai Exile";
			NpcText00 = "Greetings $N, I am Atal'ai Exile.";
			Model = 6590;
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
			ResistFrost = 30;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 70;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog ;
			Flags1 = 0x066;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new DefensiveAnimalAI( this );
			Equip( new Item ( 7449, (InventoryTypes)13, 2, 14, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyC , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f ) };
		}
	}
	public class AtalaiWitchDoctor : BaseCreature
	{
		public AtalaiWitchDoctor() : base()
		{
			Id = 5259;
			Level = RandomLevel( 49 );
			Name = "Atal'ai Witch Doctor";
			Model = 6671;
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
			ResistFrost = 30;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 70;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7469, (InventoryTypes)13, 2, 4, 2, 7, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.AmazingDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( WintersBite ), 0.01f )
					, new Loot( typeof( Stealthblade ), 0.01f )
					, new Loot( typeof( Ragehammer ), 0.01f )
					, new Loot( typeof( MistwalkerBoots ), 0.01f )
					, new Loot( typeof( SoulcatcherHalo ), 0.01f )
					, new Loot( typeof( MurkwaterGauntlets ), 0.02f )
					, new Loot( typeof( TrollSweat ), 31.4f )
					, new Loot( typeof( FormulaEnchantCloakGreaterResistance ), 0.66f )
					, new Loot( typeof( MageweaveCloth ), 22.2f )
					, new Loot( typeof( FetishOfHakkar ), 4.95f )
					, new Loot( typeof( AtalaiTablet ), 0.05f )
					, new Loot( typeof( FlaskOfBigMojo ), 8.64f )
					}, 100f ) };
		}
	}
	public class EnthralledAtalai : BaseCreature
	{
		public EnthralledAtalai() : base()
		{
			Id = 5261;
			Level = RandomLevel( 46 );
			Name = "Enthralled Atal'ai";
			Model = 6673;
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
			ResistFrost = 30;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 70;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7433, (InventoryTypes)13, 2, 15, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.AmazingDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( TrollSweat ), 30.2f )
					, new Loot( typeof( MageweaveCloth ), 23.3f )
					, new Loot( typeof( FetishOfHakkar ), 7.90f )
					, new Loot( typeof( AtalaiTablet ), 0.10f )
					, new Loot( typeof( FlaskOfBigMojo ), 8.96f )
					}, 100f ) };
		}
	}
	public class AtalaiPriest : BaseCreature
	{
		public AtalaiPriest() : base()
		{
			Id = 5269;
			Level = RandomLevel( 46 );
			Name = "Atal'ai Priest";
			Model = 4776;
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
			ResistFrost = 30;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 70;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7477, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.AmazingDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( WintersBite ), 0.01f )
					, new Loot( typeof( TrollSweat ), 29.8f )
					, new Loot( typeof( MageweaveCloth ), 23.9f )
					, new Loot( typeof( FetishOfHakkar ), 7.46f )
					, new Loot( typeof( AtalaiTablet ), 0.05f )
					, new Loot( typeof( ZestyClamMeat ), 0.04f )
					, new Loot( typeof( FlaskOfBigMojo ), 8.64f )
					}, 100f ) };
		}
	}
	public class AtalaiHighPriest : BaseCreature
	{
		public AtalaiHighPriest() : base()
		{
			Id = 5273;
			Level = RandomLevel( 50 );
			Name = "Atal'ai High Priest";
			Model = 6675;
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
			ResistFrost = 30;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 70;
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
					new Loot( typeof( Ragehammer ), 0.06f )
					, new Loot( typeof( SoulcatcherHalo ), 0.01f )
					, new Loot( typeof( MurkwaterGauntlets ), 0.01f )
					, new Loot( typeof( TrollSweat ), 34.6f )
					, new Loot( typeof( MageweaveCloth ), 22.0f )
					, new Loot( typeof( FetishOfHakkar ), 2.43f )
					, new Loot( typeof( FlaskOfBigMojo ), 8.13f )
					}, 100f ) };
		}
	}
	public class AtalaiWarrior : BaseCreature
	{
		public AtalaiWarrior() : base()
		{
			Id = 5256;
			Level = RandomLevel( 48 );
			Name = "Atal'ai Warrior";
			Model = 7709;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.595f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 30;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 70;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.AmazingDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( WintersBite ), 0.02f )
					, new Loot( typeof( Stealthblade ), 0.01f )
					, new Loot( typeof( Ragehammer ), 0.01f )
					, new Loot( typeof( MistwalkerBoots ), 0.01f )
					, new Loot( typeof( TrollSweat ), 31.5f )
					, new Loot( typeof( MageweaveCloth ), 21.9f )
					, new Loot( typeof( FetishOfHakkar ), 4.98f )
					, new Loot( typeof( AtalaiTablet ), 0.01f )
					, new Loot( typeof( FlaskOfBigMojo ), 8.31f )
					}, 100f ) };
		}
	}
	public class CursedAtalai : BaseCreature
	{
		public CursedAtalai() : base()
		{
			Id = 5243;
			Level = RandomLevel( 46 );
			Name = "Cursed Atal'ai";
			Model = 4780;
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
			ResistFrost = 30;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 70;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item ( 7432, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.AmazingDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( MurkwaterGauntlets ), 0.01f )
					, new Loot( typeof( TrollSweat ), 30.4f )
					, new Loot( typeof( MageweaveCloth ), 24.6f )
					, new Loot( typeof( FetishOfHakkar ), 8.18f )
					, new Loot( typeof( AtalaiTablet ), 0.11f )
					, new Loot( typeof( FlaskOfBigMojo ), 8.34f )
					}, 100f ) };
		}
	}
	
	
}