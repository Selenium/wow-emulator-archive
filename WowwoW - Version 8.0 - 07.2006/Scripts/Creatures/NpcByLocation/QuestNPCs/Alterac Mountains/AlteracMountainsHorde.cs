using System;
using Server;
using Server.Items;
using Server.Quests;

namespace Server.Creatures
{
	public class VoggahDeathgrip : BaseNPC
	{
		public VoggahDeathgrip() : base()
		{
			Id = 13817;
			Level = RandomLevel( 61 );
			Name = "Voggah Deathgrip";
			NpcText00 = "Greetings $N.";
			Model = 13852;
			AttackSpeed = 1260;
			CombatReach = 1.15f;
			BoundingRadius = 0.85f;
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
			NpcFlags = (int)NpcActions.Dialog | (int)NpcActions.SpiritHealer;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Ogrimmar;
			AIEngine = new DefensiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyD , 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f ) };
		}
	}
	public class WarmasterLaggrond : BaseNPC
	{
		public WarmasterLaggrond() : base()
		{
			Id = 13840;
			Level = RandomLevel( 61 );
			Name = "Warmaster Laggrond";
			NpcText00 = "Greetings $N.";
			Model = 13852;
			AttackSpeed = 1050;
			CombatReach = 1.39f;
			BoundingRadius = 0.85f;
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
			NpcFlags = (int)NpcActions.Dialog | (int)NpcActions.SpiritHealer;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Ogrimmar;
			AIEngine = new DefensiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyD , 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( Runecloth ), 33.3f )
					, new Loot( typeof( ArmorScraps ), 83.3f )
					, new Loot( typeof( StormCrystal ), 16.6f )
					, new Loot( typeof( FrostwolfLieutenantsMedal ), 25f )
					, new Loot( typeof( FrostwolfCommandersMedal ), 8.33f )
					}, 100f ) };
		}
	}
	public class CorporalTeekaBloodsnarl : BaseNPC
	{
		public CorporalTeekaBloodsnarl() : base()
		{
			Id = 13776;
			Level = RandomLevel( 56 ,57 );
			Name = "Corporal Teeka Bloodsnarl";
			NpcText00 = "Greetings $N.";
			Model = 13851;
			AttackSpeed = 1329;
			CombatReach = 1.15f;
			BoundingRadius = 0.85f;
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
			NpcFlags = (int)NpcActions.Dialog | (int)NpcActions.SpiritHealer;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Ogrimmar;
			AIEngine = new DefensiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyD , 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( Runecloth ), 17.6f )
					, new Loot( typeof( ArmorScraps ), 82.3f )
					, new Loot( typeof( StormCrystal ), 23.5f )
					, new Loot( typeof( FrostwolfSoldiersMedal ), 11.7f )
					, new Loot( typeof( FrostwolfLieutenantsMedal ), 41.1f )
					}, 100f ) };
		}
	}
	public class HenchmanValik : BaseNPC
	{
		public HenchmanValik() : base()
		{
			Id = 2333;
			Level = RandomLevel( 30 );
			Name = "Henchman Valik";
			NpcText00 = "Greetings $N, I am Henchman Valik.";
			Model = 3636;
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
			NpcFlags = (int)NpcActions.Dialog | (int)NpcActions.SpiritHealer;
			Flags1 = 0x080046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Horde;
			AIEngine = new DefensiveAnimalAI( this );
			Equip( new Item ( 24594, (InventoryTypes)13, 2, 14, 1, 7, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f ) };
		}
	}
	public class Elysa : BaseNPC
	{
		public Elysa() : base()
		{
			Id = 2317;
			Level = RandomLevel( 25 );
			Name = "Elysa";
			NpcText00 = "Greetings $N, I am Elysa.";
			Model = 1361;
			AttackSpeed = 1500;
			CombatReach = 1.5f;
			BoundingRadius = 0.208f;
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
			NpcFlags = (int)NpcActions.Dialog | (int)NpcActions.SpiritHealer;
			Flags1 = 0x080066;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Friend;
			AIEngine = new DefensiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.MediumDrops, 100f ) };
		}
	}
	
	public class Goldir : BaseNPC
	{
		public Goldir() : base()
		{
			Id = 2316;
			Level = RandomLevel( 25 );
			Name = "Gol'dir";
			NpcText00 = "Greetings $N, I am Gol'dir.";
			Model = 3684;
			AttackSpeed = 1764;
			CombatReach = 1.5f;
			BoundingRadius = 0.561f;
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
			NpcFlags = (int)NpcActions.Dialog | (int)NpcActions.SpiritHealer;
			Flags1 = 0x08480046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Ogrimmar;
			AIEngine = new DefensiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.MediumDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( GoldBar ), 16.6f )
					, new Loot( typeof( TruesilverBar ), 16.6f )
					}, 100f ) };
		}
	}
}