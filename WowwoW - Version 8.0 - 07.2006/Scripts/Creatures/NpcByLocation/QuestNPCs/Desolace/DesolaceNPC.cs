using System;
using Server;
using Server.Items;
using Server.Quests;

namespace Server.Creatures
{
	public class VarkBattlescar : BaseNPC
	{
		public VarkBattlescar() : base()
		{
			Id = 11823;
			Level = RandomLevel( 10 );
			Name = "Vark Battlescar";
			NpcText00 = "Greetings $N, I am Vark Battlescar.";
			Model = 11738;
			AttackSpeed = 1974;
			CombatReach = 0.8f;
			BoundingRadius = 0.444f;
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
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 7480, (InventoryTypes)17, 2, 6, 1, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyA , 100f )
				, new BaseTreasure( WorldDrops.LowDrops, 100f ) };
		}
	}
	public class DalindaMalem : BaseNPC
	{
		public DalindaMalem() : base()
		{
			Id = 5644;
			Level = RandomLevel( 35 );
			Name = "Dalinda Malem";
			NpcText00 = "Greetings $N, I am Dalinda Malem.";
			Model = 3791;
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
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( WoolCloth ), 17.3f )
					, new Loot( typeof( BoltOfWoolenCloth ), 4.34f )
					, new Loot( typeof( GoldBar ), 13.0f )
					, new Loot( typeof( SilkCloth ), 4.34f )
					}, 100f ) };
		}
	}
	public class VahlarrielDemonslayer : BaseNPC
	{
		public VahlarrielDemonslayer() : base()
		{
			Id = 5642;
			Level = RandomLevel( 37 );
			Name = "Vahlarriel Demonslayer";
			NpcText00 = "Greetings $N, I am Vahlarriel Demonslayer.";
			Model = 3789;
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
			Faction = Factions.Alliance;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 21555, (InventoryTypes)13, 2, 8, 1, 1, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f ) };
		}
	}
	public class CentaurPariah : BaseNPC
	{
		public CentaurPariah() : base()
		{
			Id = 13717;
			Level = RandomLevel( 42 );
			Name = "Centaur Pariah";
			NpcText00 = "Greetings $N, I am Centaur Pariah.";
			Model = 9419;
			AttackSpeed = 2000;
			CombatReach = 1.25f;
			BoundingRadius = 0.71f;
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
			Flags1 = 0x080006;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Friend;
			AIEngine = new StandingGuardAI( this ); 
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f ) };
		}
	}
	public class MaurinBonesplitter : BaseNPC
	{
		public MaurinBonesplitter() : base()
		{
			Id = 4498;
			Level = RandomLevel( 35 );
			Name = "Maurin Bonesplitter";
			NpcText00 = "Greetings $N, I am Maurin Bonesplitter.";
			Model = 4171;
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
			Flags1 = 0x08480046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Undercity;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 1600, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f ) };
		}
	}
	public class UthekTheWise : BaseNPC
	{
		public UthekTheWise() : base()
		{
			Id = 5397;
			Level = RandomLevel( 44 );
			Name = "Uthek the Wise";
			NpcText00 = "Greetings $N, I am Uthek the Wise.";
			Model = 4875;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.4025f;
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
			Flags1 = 0x080066;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Friend;
			AIEngine = new StandingGuardAI( this ); 
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f ) };
		}
	}
	public class DrulzegarSkraghook : BaseNPC
	{
		public DrulzegarSkraghook() : base()
		{
			Id = 12340;
			Level = RandomLevel( 35 );
			Name = "Drulzegar Skraghook";
			NpcText00 = "If you seek to hunt naga, then you will need all the help you can get. Deep in the water you can find bubbly fissures that produce enough air bubbles that will allow you to breath underwater. Swim up close so that you can use the bubbles.";
			Model = 12934;
			AttackSpeed = 1623;
			CombatReach = 1.3f;
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
			Flags1 = 0x0480046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 8746, (InventoryTypes)17, 2, 6, 1, 2, 0, 0, 0), new Item ( 24293, (InventoryTypes)23, 4, 0, 2, 0, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f ) };
		}
	}
	public class Cavindra : BaseNPC
	{
		public Cavindra() : base()
		{
			Id = 13697;
			Level = RandomLevel( 45 );
			Name = "Cavindra";
			NpcText00 = "Greetings $N, I am Cavindra.";
			Model = 14425;
			AttackSpeed = 2000;
			CombatReach = 1.15f;
			BoundingRadius = 0.8947f;
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
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x080066;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Friend;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 12236, (InventoryTypes)13, 2, 4, 2, 7, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f ) };
		}
	}
	public class SmeedScrabblescrew : BaseNPC
	{
		public SmeedScrabblescrew() : base()
		{
			Id = 11596;
			Level = RandomLevel( 45 );
			Name = "Smeed Scrabblescrew";
			NpcText00 = "Greetings $N, I am Smeed Scrabblescrew.";
			Model = 11470;
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
			Equip( new Item ( 7459, (InventoryTypes)13, 2, 14, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f ) };
		}
	}
	public class RoonWildmane : BaseNPC
	{
		public RoonWildmane() : base()
		{
			Id = 11877;
			Level = RandomLevel( 41 ,45 );
			Name = "Roon Wildmane";
			NpcText00 = "Greetings $N, I am Roon Wildmane.";
			Model = 11852;
			AttackSpeed = 1512;
			CombatReach = 0.8f;
			BoundingRadius = 0.714f;
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
			Flags1 = 0x0480006;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 19550, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0), new Item ( 22640, (InventoryTypes)14, 4, 6, 1, 4, 0, 0, 0), new Item ( 25260, (InventoryTypes)26, 2, 3, 1, 0, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f ) };
		}
	}
	public class HornizzBrimbuzzle : BaseNPC
	{
		public HornizzBrimbuzzle() : base()
		{
			Id = 6019;
			Level = RandomLevel( 30 );
			Name = "Hornizz Brimbuzzle";
			NpcText00 = "Greetings $N, I am Hornizz Brimbuzzle.";
			Model = 7127;
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
			Flags1 = 0x080006;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Friend;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 5569, (InventoryTypes)21, 2, 14, 1, 7, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f ) };
		}
	}
	public class TaigaWisemane : BaseNPC
	{
		public TaigaWisemane() : base()
		{
			Id = 11624;
			Level = RandomLevel( 60 );
			Name = "Taiga Wisemane";
			NpcText00 = "Greetings $N, I am Taiga Wisemane.";
			Model = 11792;
			AttackSpeed = 1273;
			CombatReach = 1.7f;
			BoundingRadius = 0.426f;
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
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 24015, (InventoryTypes)17, 2, 10, 2, 1, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyD, 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f ) };
		}
	}
	public class GurdaWildmane : BaseNPC
	{
		public GurdaWildmane() : base()
		{
			Id = 5412;
			Level = RandomLevel( 35 );
			Name = "Gurda Wildmane";
			NpcText00 = "Greetings $N, I am Gurda Wildmane.";
			Model = 4695;
			AttackSpeed = 2000;
			CombatReach = 3.75f;
			BoundingRadius = 0.8725f;
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
			Equip( new Item ( 5527, (InventoryTypes)17, 2, 5, 2, 1, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f ) };
		}
	}
	public class KeeperMarandis : BaseNPC
	{
		public KeeperMarandis() : base()
		{
			Id = 13698;
			Level = RandomLevel( 43 );
			Name = "Keeper Marandis";
			NpcText00 = "May Cenarius guide you, $c.$B$BI am here in this corrupt land with my sisters on a mission of great importance to the Cenarian Circle. But only those who are powerful enough I ask speak to me about such matters--to send a lesser being would be folly.";
			Model = 150;
			AttackSpeed = 2000;
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
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x08480006;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Alliance;
			AIEngine = new StandingGuardAI( this ); 
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f ) };
		}
	}
	public class Selendra : BaseNPC
	{
		public Selendra() : base()
		{
			Id = 13699;
			Level = RandomLevel( 40 );
			Name = "Selendra";
			NpcText00 = "Greetings $N, I am Selendra.";
			Model = 13672;
			AttackSpeed = 2000;
			CombatReach = 1.15f;
			BoundingRadius = 0.8947f;
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
			Flags1 = 0x0480006;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Alliance;
			AIEngine = new StandingGuardAI( this ); 
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f ) };
		}
	}
	public class CorporalMelkins : BaseNPC
	{
		public CorporalMelkins() : base()
		{
			Id = 5752;
			Level = RandomLevel( 39 );
			Name = "Corporal Melkins";
			NpcText00 = "Greetings $N, I am Corporal Melkins.";
			Model = 4692;
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
			Equip( new Item ( 23948, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0), new Item ( 2080, (InventoryTypes)14, 4, 6, 1, 4, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f ) };
		}
	}
	public class NatakaLonghorn : BaseNPC
	{
		public NatakaLonghorn() : base()
		{
			Id = 11259;
			Level = RandomLevel( 40 );
			Name = "Nataka Longhorn";
			NpcText00 = "Greetings $N, I am Nataka Longhorn.";
			Model = 11469;
			AttackSpeed = 2000;
			CombatReach = 4.05f;
			BoundingRadius = 0.752f;
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
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 19550, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f ) };
		}
	}
	public class Warug : BaseNPC
	{
		public Warug() : base()
		{
			Id = 5398;
			Level = RandomLevel( 44 );
			Name = "Warug";
			NpcText00 = "Greetings $N, I am Warug.";
			Model = 1258;
			AttackSpeed = 2000;
			CombatReach = 1.25f;
			BoundingRadius = 0.71f;
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
			Flags1 = 0x080066;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Friend;
			AIEngine = new StandingGuardAI( this ); 
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f ) };
		}
	}
	public class CaptainPentigast : BaseNPC
	{
		public CaptainPentigast() : base()
		{
			Id = 5396;
			Level = RandomLevel( 42 );
			Name = "Captain Pentigast";
			NpcText00 = "Greetings $N, I am Captain Pentigast.";
			Model = 4693;
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
			Equip( new Item ( 7482, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0), new Item ( 2080, (InventoryTypes)14, 4, 6, 1, 4, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f ) };
		}
	}
	public class BibblyFutzbuckle : BaseNPC
	{
		public BibblyFutzbuckle() : base()
		{
			Id = 11438;
			Level = RandomLevel( 45 );
			Name = "Bibbly F'utzbuckle";
			NpcText00 = "Greetings $N, I am Bibbly F'utzbuckle.";
			Model = 11461;
			AttackSpeed = 2000;
			CombatReach = 1.12f;
			BoundingRadius = 0.2295f;
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
			Equip( new Item ( 7495, (InventoryTypes)17, 2, 6, 1, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f ) };
		}
	}
	public class CorkGizelton : BaseNPC
	{
		public CorkGizelton() : base()
		{
			Id = 11625;
			Level = RandomLevel( 38 );
			Name = "Cork Gizelton";
			NpcText00 = "Ah... a customer! Talk to my greatest invention, the Vendor-Tron 1000. He has all your needs... some of the rarest items you will ever find on the market anywhere in Kalimdor... not to mention that his programming will not allow any bargaining, so the price you see is the price you pay.";
			Model = 11629;
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
			Faction = Factions.Friend;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 7461, (InventoryTypes)13, 2, 14, 1, 7, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f ) };
		}
	}
	public class TakataSteelblade : BaseNPC
	{
		public TakataSteelblade() : base()
		{
			Id = 5641;
			Level = RandomLevel( 40 );
			Name = "Takata Steelblade";
			NpcText00 = "Greetings $N, I am Takata Steelblade.";
			Model = 3760;
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
			Equip( new Item ( 7491, (InventoryTypes)13, 2, 8, 1, 1, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f ) };
		}
	}
	
}