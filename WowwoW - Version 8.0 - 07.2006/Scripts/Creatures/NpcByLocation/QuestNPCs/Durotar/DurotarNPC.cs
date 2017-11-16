using System;
using Server;
using Server.Items;
using Server.Quests;

namespace Server.Creatures
{
	public class CaptainGarranVimes : BaseNPC
	{
		public CaptainGarranVimes() : base()
		{
			Id = 4944;
			Level = RandomLevel( 50 );
			Name = "Captain Garran Vimes";
			NpcText00 = "Greetings $N, I am Captain Garran Vimes.";
			Model = 2952;
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
			Faction = Factions.Friend;
			AIEngine = new StandingGuardAI( this ); 
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyD , 100f )
				, new BaseTreasure( WorldDrops.AmazingDrops, 100f ) };
		}
	}
	public class Kaltunk : BaseNPC
	{
		public Kaltunk() : base()
		{
			Id = 10176;
			Level = RandomLevel( 20 );
			Name = "Kaltunk";
			NpcText00 = "Greetings $N, I am Kaltunk.";
			Model = 9470;
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
			Flags1 = 0x08080066;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingGuardAI( this ); 
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.MediumDrops, 100f ) };
		}
	}
	public class Rezlak : BaseNPC
	{
		public Rezlak() : base()
		{
			Id = 3293;
			Level = RandomLevel( 5 );
			Name = "Rezlak";
			Guild = "Tinkers' Union";
			NpcText00 = "Greetings $N, I am Rezlak.";
			Model = 7129;
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
			Flags1 = 0x080046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Ratchet;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 7494, (InventoryTypes)13, 2, 4, 2, 7, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyA , 100f )
				, new BaseTreasure( WorldDrops.BeginnerDrops, 100f ) };
		}
	}
	public class ZureethaFargaze : BaseNPC
	{
		public ZureethaFargaze() : base()
		{
			Id = 3145;
			Level = RandomLevel( 12 );
			Name = "Zureetha Fargaze";
			NpcText00 = "Greetings $N, I am Zureetha Fargaze.";
			Model = 1875;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.236f;
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
			Flags1 = 0x08080066;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 1599, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.LowDrops, 100f ) };
		}
	}
	public class Ruzan : BaseNPC
	{
		public Ruzan() : base()
		{
			Id = 5765;
			Level = RandomLevel( 10 );
			Name = "Ruzan";
			NpcText00 = "Greetings $N, I am Ruzan.";
			Model = 4209;
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
			Flags1 = 0x08080066;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 19557, (InventoryTypes)13, 2, 15, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.LowDrops, 100f ) };
		}
	}
	public class LarProwltusk : BaseNPC
	{
		public LarProwltusk() : base()
		{
			Id = 3140;
			Level = RandomLevel( 7 );
			Name = "Lar Prowltusk";
			NpcText00 = "Greetings $N, I am Lar Prowltusk.";
			Model = 4070;
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
			Equip( new Item ( 7434, (InventoryTypes)13, 2, 15, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.LowDrops, 100f ) };
		}
	}
	public class Eitrigg : BaseNPC
	{
		public Eitrigg() : base()
		{
			Id = 3144;
			Level = RandomLevel( 20 );
			Name = "Eitrigg";
			NpcText00 = "Greetings $N, I am Eitrigg.";
			Model = 1619;
			AttackSpeed = 1739;
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
			Equip( new Item ( 19550, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.MediumDrops, 100f ) };
		}
	}
	public class Hanazua : BaseNPC
	{
		public Hanazua() : base()
		{
			Id = 3287;
			Level = RandomLevel( 2 );
			Name = "Hana'zua";
			NpcText00 = "Greetings $N, I am Hana'zua.";
			Model = 2025;
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
			Flags1 = 0x08080066;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Horde;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 7488, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyA , 100f )
				, new BaseTreasure( WorldDrops.BeginnerDrops, 100f ) };
		}
	}
	public class VelrinFang : BaseNPC
	{
		public VelrinFang() : base()
		{
			Id = 3194;
			Level = RandomLevel( 7 );
			Name = "Vel'rin Fang";
			NpcText00 = "Greetings $N, I am Vel'rin Fang.";
			Model = 4074;
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
			Equip( new Item ( 6434, (InventoryTypes)13, 2, 15, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.LowDrops, 100f ) };
		}
	}
	public class Rhinag : BaseNPC
	{
		public Rhinag() : base()
		{
			Id = 3190;
			Level = RandomLevel( 8 );
			Name = "Rhinag";
			NpcText00 = "Greetings $N, I am Rhinag.";
			Model = 4075;
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
			Equip( new Item ( 7434, (InventoryTypes)13, 2, 15, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.LowDrops, 100f ) };
		}
	}
	public class MasterGadrin : BaseNPC
	{
		public MasterGadrin() : base()
		{
			Id = 3188;
			Level = RandomLevel( 12 );
			Name = "Master Gadrin";
			NpcText00 = "Greetings $N, I am Master Gadrin.";
			Model = 4072;
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
			Equip( new Item ( 22391, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.LowDrops, 100f ) };
		}
	}
	public class ForemanThazzril : BaseNPC
	{
		public ForemanThazzril() : base()
		{
			Id = 11378;
			Level = RandomLevel( 4 );
			Name = "Foreman Thazz'ril";
			NpcText00 = "Greetings $N, I am Foreman Thazz'ril.";
			Model = 12089;
			AttackSpeed = 2000;
			CombatReach = 1.3f;
			BoundingRadius = 0.2976f;
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
			Flags1 = 0x08080066;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingGuardAI( this ); 
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyA , 100f )
				, new BaseTreasure( WorldDrops.BeginnerDrops, 100f ) };
		}
	}
	public class GanrulBloodeye : BaseNPC
	{
		public GanrulBloodeye() : base()
		{
			Id = 5875;
			Level = RandomLevel( 40 );
			Name = "Gan'rul Bloodeye";
			NpcText00 = "Greetings $N, I am Gan'rul Bloodeye.";
			Model = 4492;
			AttackSpeed = 1739;
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
			Equip( new Item ( 23322, (InventoryTypes)13, 2, 14, 1, 0, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyC , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f ) };
		}
	}
	public class Ophek : BaseNPC
	{
		public Ophek() : base()
		{
			Id = 3294;
			Level = RandomLevel( 10 );
			Name = "Ophek";
			NpcText00 = "Greetings $N, I am Ophek.";
			Model = 1654;
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
			Equip( new Item ( 7429, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.LowDrops, 100f ) };
		}
	}
	public class Galgar : BaseNPC
	{
		public Galgar() : base()
		{
			Id = 9796;
			Level = RandomLevel( 8 );
			Name = "Galgar";
			NpcText00 = "Greetings $N, I am Galgar.";
			Model = 9151;
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
			Flags1 = 0x08080066;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingGuardAI( this ); 
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.LowDrops, 100f ) };
		}
	}
	public class Gornek : BaseNPC
	{
		public Gornek() : base()
		{
			Id = 3143;
			Level = RandomLevel( 5 );
			Name = "Gornek";
			NpcText00 = "Greetings $N, I am Gornek.";
			Model = 1653;
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
			Flags1 = 0x08080066;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 7429, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyA , 100f )
				, new BaseTreasure( WorldDrops.BeginnerDrops, 100f ) };
		}
	}
	public class GarThok : BaseNPC
	{
		public GarThok() : base()
		{
			Id = 3139;
			Level = RandomLevel( 10 );
			Name = "Gar'Thok";
			NpcText00 = "Greetings $N, I am Gar'Thok.";
			Model = 3736;
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
			Equip( new Item ( 7477, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.LowDrops, 100f ) };
		}
	}
	public class Margoz : BaseNPC
	{
		public Margoz() : base()
		{
			Id = 3208;
			Level = RandomLevel( 18 );
			Name = "Margoz";
			NpcText00 = "Greetings $N, I am Margoz.";
			Model = 3752;
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
			Equip( new Item ( 1600, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0), new Item ( 23172, (InventoryTypes)23, 4, 0, 1, 0, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.MediumDrops, 100f ) };
		}
	}
	public class OrgnilSoulscar : BaseNPC
	{
		public OrgnilSoulscar() : base()
		{
			Id = 3142;
			Level = RandomLevel( 18 );
			Name = "Orgnil Soulscar";
			NpcText00 = "Greetings $N, I am Orgnil Soulscar.";
			Model = 1877;
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
			Equip( new Item ( 19549, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.MediumDrops, 100f ) };
		}
	}
	public class KargalBattlescar : BaseNPC
	{
		public KargalBattlescar() : base()
		{
			Id = 3337;
			Level = RandomLevel( 15 );
			Name = "Kargal Battlescar";
			NpcText00 = "Greetings $N, I am Kargal Battlescar.";
			Model = 3852;
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
			Equip( new Item ( 5224, (InventoryTypes)21, 2, 4, 2, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.LowDrops, 100f ) };
		}
	}
	public class TakrinPathseeker : BaseNPC
	{
		public TakrinPathseeker() : base()
		{
			Id = 3336;
			Level = RandomLevel( 30 );
			Name = "Takrin Pathseeker";
			NpcText00 = "Greetings $N, I am Takrin Pathseeker.";
			Model = 3884;
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
			Equip( new Item ( 6434, (InventoryTypes)13, 2, 15, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f ) };
		}
	}
	public class FurlScornbrow : BaseNPC
	{
		public FurlScornbrow() : base()
		{
			Id = 3147;
			Level = RandomLevel( 6 );
			Name = "Furl Scornbrow";
			NpcText00 = "Greetings $N, I am Furl Scornbrow.";
			Model = 1275;
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
			Equip( new Item ( 7428, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.LowDrops, 100f ) };
		}
	}
	public class KranalFiss : BaseNPC
	{
		public KranalFiss() : base()
		{
			Id = 5907;
			Level = RandomLevel( 15 );
			Name = "Kranal Fiss";
			NpcText00 = "Greetings $N, I am Kranal Fiss.";
			Model = 4543;
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
			Equip( new Item ( 1600, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.LowDrops, 100f ) };
		}
	}
	public class TelfJoolam : BaseNPC
	{
		public TelfJoolam() : base()
		{
			Id = 5900;
			Level = RandomLevel( 35 );
			Name = "Telf Joolam";
			NpcText00 = "Greetings $N, I am Telf Joolam.";
			Model = 4537;
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
			Flags1 = 0x08400046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.DarkspearTrolls;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 11289, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f ) };
		}
	}
	public class CanagaEarthcaller : BaseNPC
	{
		public CanagaEarthcaller() : base()
		{
			Id = 5887;
			Level = RandomLevel( 8 );
			Name = "Canaga Earthcaller";
			NpcText00 = "Greetings $N, I am Canaga Earthcaller.";
			Model = 4532;
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
			Flags1 = 0x08080066;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Horde;
			AIEngine = new StandingGuardAI( this ); 
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.LowDrops, 100f ) };
		}
	}
	public class CookTorka : BaseNPC
	{
		public CookTorka() : base()
		{
			Id = 3191;
			Level = RandomLevel( 6 );
			Name = "Cook Torka";
			NpcText00 = "Greetings $N, I am Cook Torka.";
			Model = 3751;
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
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.LowDrops, 100f ) };
		}
	}
	public class MasterVornal : BaseNPC
	{
		public MasterVornal() : base()
		{
			Id = 3304;
			Level = RandomLevel( 11 );
			Name = "Master Vornal";
			NpcText00 = "Greetings $N, I am Master Vornal.";
			Model = 4086;
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
			Equip( new Item ( 22395, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.LowDrops, 100f ) };
		}
	}
	public class Ukor : BaseNPC
	{
		public Ukor() : base()
		{
			Id = 6786;
			Level = RandomLevel( 4 );
			Name = "Ukor";
			NpcText00 = "Greetings $N, I am Ukor.";
			Model = 5729;
			AttackSpeed = 2000;
			CombatReach = 1.3f;
			BoundingRadius = 0.2976f;
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
			Equip( new Item ( 7443, (InventoryTypes)13, 2, 4, 2, 7, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyA , 100f )
				, new BaseTreasure( WorldDrops.BeginnerDrops, 100f ) };
		}
	}
	
}