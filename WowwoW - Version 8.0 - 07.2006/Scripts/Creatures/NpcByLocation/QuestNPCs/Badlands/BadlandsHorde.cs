using System;
using Server;
using Server.Items;
using Server.Quests;

namespace Server.Creatures
{
	public class HierophantTheodoraMulvadania : BaseNPC
	{
		public HierophantTheodoraMulvadania() : base()
		{
			Id = 9079;
			Level = RandomLevel( 58 );
			Name = "Hierophant Theodora Mulvadania";
			Guild = "Kargath Expeditionary Force";
			NpcText00 = "Greetings $N, I am Hierophant Theodora Mulvadania.";
			Model = 8332;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.383f;
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
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x08400046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Horde;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 7477, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0), new Item ( 6537, (InventoryTypes)23, 4, 0, 1, 7, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyD , 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f ) };
		}
	}
	public class ShadowmageVivianLagrave : BaseNPC
	{
		public ShadowmageVivianLagrave() : base()
		{
			Id = 9078;
			Level = RandomLevel( 58 );
			Name = "Shadowmage Vivian Lagrave";
			Guild = "Kargath Expeditionary Force";
			NpcText00 = "Greetings $N, I am Shadowmage Vivian Lagrave.";
			Model = 8330;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.383f;
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
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x08400046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Horde;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 5542, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyD , 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f ) };
		}
	}
	public class WarlordGoretooth : BaseNPC
	{
		public WarlordGoretooth() : base()
		{
			Id = 9077;
			Level = RandomLevel( 60 );
			Name = "Warlord Goretooth";
			Guild = "Kargath Expeditionary Force";
			NpcText00 = "Greetings $N, I am Warlord Goretooth.";
			Model = 8331;
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
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x08480046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Horde;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 20538, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyD , 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f ) };
		}
	}
	public class Lexlort : BaseNPC
	{
		public Lexlort() : base()
		{
			Id = 9080;
			Level = RandomLevel( 58 );
			Name = "Lexlort";
			Guild = "Kargath Expeditionary Force";
			NpcText00 = "Greetings $N, I am Lexlort.";
			Model = 8333;
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
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x08480046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Horde;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 20507, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0), new Item ( 20504, (InventoryTypes)26, 2, 3, 1, 0, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyD , 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f ) };
		}
	}
	public class ThaltrakProudtusk : BaseNPC
	{
		public ThaltrakProudtusk() : base()
		{
			Id = 9082;
			Level = RandomLevel( 55 );
			Name = "Thal'trak Proudtusk";
			Guild = "Kargath Expeditionary Force";
			NpcText00 = "Greetings $N, I am Thal'trak Proudtusk.";
			Model = 8335;
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
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x08480046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 2840, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyD, 100f )
				, new BaseTreasure( WorldDrops.AmazingDrops, 100f ) };
		}
	}
	public class Thunderheart : BaseNPC
	{
		public Thunderheart() : base()
		{
			Id = 9084;
			Level = RandomLevel( 52 );
			Name = "Thunderheart";
			Guild = "Kargath Expeditionary Force";
			NpcText00 = "Greetings $N, I am Thunderheart.";
			Model = 8350;
			AttackSpeed = 2000;
			CombatReach = 4.05f;
			BoundingRadius = 0.61f;
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
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x08480046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Horde;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 1600, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyD, 100f )
				, new BaseTreasure( WorldDrops.AmazingDrops, 100f ) };
		}
	}
	public class GalamavTheMarksman : BaseNPC
	{
		public GalamavTheMarksman() : base()
		{
			Id = 9081;
			Level = RandomLevel( 58 );
			Name = "Galamav the Marksman";
			Guild = "Kargath Expeditionary Force";
			NpcText00 = "Greetings $N, I am Galamav the Marksman.";
			Model = 8334;
			AttackSpeed = 2000;
			CombatReach = 4.05f;
			BoundingRadius = 0.674f;
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
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x08480046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Horde;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 3385, (InventoryTypes)17, 2, 1, 1, 1, 0, 0, 0), new Item ( 20504, (InventoryTypes)26, 2, 3, 1, 0, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyD , 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f ) };
		}
	}
	public class Gorn : BaseNPC
	{
		public Gorn() : base()
		{
			Id = 1068;
			Level = RandomLevel( 40 );
			Name = "Gorn";
			NpcText00 = "Greetings $N, I am Gorn.";
			Model = 2740;
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
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x08480046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 7485, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyC, 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f ) };
		}
	}
	public class JarkalMossmeld : BaseNPC
	{
		public JarkalMossmeld() : base()
		{
			Id = 6868;
			Level = RandomLevel( 35 );
			Name = "Jarkal Mossmeld";
			NpcText00 = "Greetings $N, I am Jarkal Mossmeld.";
			Model = 5646;
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
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x08480046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Horde;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 2840, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB, 100f )
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f ) };
		}
	}
	
}