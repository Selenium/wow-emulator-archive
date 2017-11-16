using System;
using Server;
using Server.Items;
using Server.Quests;

namespace Server.Creatures
{
	public class ArchaeologistHollee : BaseNPC
	{
		public ArchaeologistHollee() : base()
		{
			Id = 2913;
			Level = RandomLevel( 12 );
			Name = "Archaeologist Hollee";
			Guild = "Explorers' League";
			NpcText00 = "Greetings $N, I am Archaeologist Hollee.";
			Model = 1286;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.347f;
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
			Faction = Factions.IronForge;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 7461, (InventoryTypes)13, 2, 14, 1, 7, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.LowDrops, 100f ) };
		}
	}

	public class GwennythBlyLeggonde : BaseNPC
	{
		public GwennythBlyLeggonde() : base()
		{
			Id = 10219;
			Level = RandomLevel( 21 );
			Name = "Gwennyth Bly'Leggonde";
			NpcText01 = "May Elune walk with you, $c.  The Temple of the Moon has come to help the troubled citizens of Auberdine.";
			Model = 9551;
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
			Flags1 = 0x08480006;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Darnasus;
			AIEngine = new StandingGuardAI( this ); 
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.MediumDrops, 100f ) };
		}
	}
	public class Therylune : BaseNPC
	{
		public Therylune() : base()
		{
			Id = 3584;
			Level = RandomLevel( 17 );
			Name = "Therylune";
			NpcText00 = "Greetings $N, I am Therylune.";
			Model = 2723;
			AttackSpeed = 2000;
			CombatReach = 1.0f;
			BoundingRadius = 0.778f;
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
			Flags1 = 0x0480046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Horde;
			AIEngine = new StandingGuardAI( this ); 
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.MediumDrops, 100f ) };
		}
	}
	public class DelgrenThePurifier : BaseNPC
	{
		public DelgrenThePurifier() : base()
		{
			Id = 3663;
			Level = RandomLevel( 19 );
			Name = "Delgren the Purifier";
			NpcText00 = "Greetings $N, I am Delgren the Purifier.";
			Model = 2531;
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
			Faction = Factions.Alliance;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 2466, (InventoryTypes)17, 2, 5, 2, 1, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.MediumDrops, 100f ) };
		}
	}
	public class GelkakGyromast : BaseNPC
	{
		public GelkakGyromast() : base()
		{
			Id = 6667;
			Level = RandomLevel( 18 );
			Name = "Gelkak Gyromast";
			NpcText00 = "Greetings $N, I am Gelkak Gyromast.";
			Model = 5485;
			AttackSpeed = 2000;
			CombatReach = 1.07f;
			BoundingRadius = 0.3519f;
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
			Faction = Factions.IronForge;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 7485, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.MediumDrops, 100f ) };
		}
	}
	public class CerelleanWhiteclaw : BaseNPC
	{
		public CerelleanWhiteclaw() : base()
		{
			Id = 3644;
			Level = RandomLevel( 15 );
			Name = "Cerellean Whiteclaw";
			NpcText00 = "Greetings $N, I am Cerellean Whiteclaw.";
			Model = 1757;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.389f;
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
			Faction = Factions.Darnasus;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 7430, (InventoryTypes)13, 2, 13, 1, 7, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.LowDrops, 100f ) };
		}
	}
	public class BarithrasMoonshade : BaseNPC
	{
		public BarithrasMoonshade() : base()
		{
			Id = 3583;
			Level = RandomLevel( 14 );
			Name = "Barithras Moonshade";
			NpcText00 = "Greetings $N, I am Barithras Moonshade.";
			Model = 4414;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.389f;
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
			Faction = Factions.Darnasus;
			AIEngine = new StandingGuardAI( this ); 
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.LowDrops, 100f ) };
		}
	}
	public class WizbangCranktoggle : BaseNPC
	{
		public WizbangCranktoggle() : base()
		{
			Id = 3666;
			Level = RandomLevel( 15 );
			Name = "Wizbang Cranktoggle";
			NpcText00 = "Greetings $N, I am Wizbang Cranktoggle.";
			Model = 4474;
			AttackSpeed = 2000;
			CombatReach = 1.07f;
			BoundingRadius = 0.3519f;
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
			Faction = Factions.Friend;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 7494, (InventoryTypes)13, 2, 4, 2, 7, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.LowDrops, 100f ) };
		}
	}
	public class Asterion : BaseNPC
	{
		public Asterion() : base()
		{
			Id = 3650;
			Level = RandomLevel( 15 );
			Name = "Asterion";
			NpcText00 = "Greetings $N, I am Asterion.";
			Model = 1771;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.389f;
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
			Faction = Factions.Darnasus;
			AIEngine = new StandingGuardAI( this ); 
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.LowDrops, 100f ) };
		}
	}
	public class ThundrisWindweaver : BaseNPC
	{
		public ThundrisWindweaver() : base()
		{
			Id = 3649;
			Level = RandomLevel( 15 );
			Name = "Thundris Windweaver";
			NpcText00 = "Greetings $N, I am Thundris Windweaver.";
			Model = 1770;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.389f;
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
			Faction = Factions.Darnasus;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 7478, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0), new Item ( 16752, (InventoryTypes)25, 2, 16, 1, 0, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.LowDrops, 100f ) };
		}
	}
	public class Terenthis : BaseNPC
	{
		public Terenthis() : base()
		{
			Id = 3693;
			Level = RandomLevel( 15 );
			Name = "Terenthis";
			NpcText00 = "Greetings $N, I am Terenthis.";
			Model = 1956;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.389f;
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
			Equip( new Item ( 23198, (InventoryTypes)17, 2, 1, 1, 1, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.LowDrops, 100f ) };
		}
	}
	
	
}