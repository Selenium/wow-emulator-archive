using System;
using Server;
using Server.Items;
using Server.Quests;

namespace Server.Creatures
{
	public class HadokenSwiftstrider : BaseNPC
	{
		public HadokenSwiftstrider() : base()
		{
			Id = 7875;
			Level = RandomLevel( 45 );
			Name = "Hadoken Swiftstrider";
			NpcText00 = "Greetings $N, I am Hadoken Swiftstrider.";
			Model = 6983;
			AttackSpeed = 2000;
			CombatReach = 4.05f;
			BoundingRadius = 0.526f;
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
			Flags1 = 0x0400046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 7426, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0), new Item ( 1706, (InventoryTypes)14, 4, 6, 1, 4, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyC, 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f ) };
		}
	}
	public class ShayLeafrunner : BaseNPC
	{
		public ShayLeafrunner() : base()
		{
			Id = 7774;
			Level = RandomLevel( 50 );
			Name = "Shay Leafrunner";
			NpcText00 = "Greetings $N, I am Shay Leafrunner.";
			Model = 6985;
			AttackSpeed = 1413;
			CombatReach = 1.35f;
			BoundingRadius = 0.2754f;
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
			Flags1 = 0x066;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Darnasus;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 7448, (InventoryTypes)13, 2, 14, 1, 0, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyD , 100f )
				, new BaseTreasure( WorldDrops.AmazingDrops, 100f ) };
		}
	}
	public class RokOrhan : BaseNPC
	{
		public RokOrhan() : base()
		{
			Id = 7777;
			Level = RandomLevel( 40 );
			Name = "Rok Orhan";
			NpcText00 = "Greetings $N, I am Rok Orhan.";
			Model = 6993;
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
			Flags1 = 0x08480046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Horde;
			AIEngine = new StandingGuardAI( this ); 
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyC, 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f ) };
		}
	}
	public class AzjTordin : BaseNPC
	{
		public AzjTordin() : base()
		{
			Id = 14355;
			Level = RandomLevel( 60 );
			Name = "Azj'Tordin";
			NpcText00 = "Greetings $N, I am Azj'Tordin.";
			Model = 14386;
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
			Flags1 = 0x080006;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Friend;
			AIEngine = new StandingGuardAI( this ); 
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyD , 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f ) };
		}
	}
	public class TaloThornhoof : BaseNPC
	{
		public TaloThornhoof() : base()
		{
			Id = 7776;
			Level = RandomLevel( 50 );
			Name = "Talo Thornhoof";
			NpcText00 = "Listen to the stories of an elder. $N. I have many to speak of...";
			Model = 6996;
			AttackSpeed = 2000;
			CombatReach = 4.05f;
			BoundingRadius = 0.791f;
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
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 7480, (InventoryTypes)17, 2, 6, 1, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyD , 100f )
				, new BaseTreasure( WorldDrops.AmazingDrops, 100f ) };
		}
	}
	public class LatronicusMoonspear : BaseNPC
	{
		public LatronicusMoonspear() : base()
		{
			Id = 7877;
			Level = RandomLevel( 57 );
			Name = "Latronicus Moonspear";
			NpcText00 = "Greetings $N, I am Latronicus Moonspear.";
			Model = 6988;
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
			Flags1 = 0x08480006;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Darnasus;
			AIEngine = new StandingGuardAI( this ); 
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyD , 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f ) };
		}
	} 
	public class TroyasMoonbreeze : BaseNPC
	{
		public TroyasMoonbreeze() : base()
		{
			Id = 7764;
			Level = RandomLevel( 50 );
			Name = "Troyas Moonbreeze";
			NpcText00 = "Greetings $N, I am Troyas Moonbreeze.";
			Model = 6989;
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
			Equip( new Item ( 23171, (InventoryTypes)13, 2, 14, 1, 0, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyD , 100f )
				, new BaseTreasure( WorldDrops.AmazingDrops, 100f ) };
		}
	}
	public class OrwinGizzmick : BaseNPC
	{
		public OrwinGizzmick() : base()
		{
			Id = 8021;
			Level = RandomLevel( 50 );
			Name = "Orwin Gizzmick";
			NpcText00 = "Greetings $N, I am Orwin Gizzmick.";
			Model = 7272;
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
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyD , 100f )
				, new BaseTreasure( WorldDrops.AmazingDrops, 100f ) };
		}
	}
	public class ZorbinFandazzle : BaseNPC
	{
		public ZorbinFandazzle() : base()
		{
			Id = 14637;
			Level = RandomLevel( 40 );
			Name = "Zorbin Fandazzle";
			Guild = "Blacksmithing Supplies";
			Model = 14664;
			AttackSpeed = 1500;
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
			NpcFlags = (int)NpcActions.Dialog | (int)NpcActions.Vendor;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Stormwind;
			AIEngine = new StandingGuardAI( this ); 
			Sells = new Item[] { new Server.Items.EngineersInk()
				, new Server.Items.BlankParchment()
				, new Server.Items.SchematicSnakeBurstFirework()
				, new Server.Items.WeakFlux()
				, new Server.Items.MiningPick()
				, new Server.Items.StrongFlux()
				, new Server.Items.RoughBlastingPowder()
				, new Server.Items.CopperTube()
				, new Server.Items.CopperModulator()
				, new Server.Items.CoarseBlastingPowder()
				, new Server.Items.BronzeTube()
				, new Server.Items.BronzeFramework()
				, new Server.Items.Gyrochronatom()
				, new Server.Items.WoodenStock()
				, new Server.Items.HeavyStock()
				, new Server.Items.SilverContact()
				, new Server.Items.BlacksmithHammer()
			 };
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyC, 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( EngineersInk ), 5.00f )
					, new Loot( typeof( BlankParchment ), 5.00f )
					, new Loot( typeof( SchematicSnakeBurstFirework ), 5.00f )
					, new Loot( typeof( WeakFlux ), 5.00f )
					, new Loot( typeof( MiningPick ), 5.00f )
					, new Loot( typeof( StrongFlux ), 5.00f )
					, new Loot( typeof( RoughBlastingPowder ), 5.00f )
					, new Loot( typeof( CopperTube ), 5.00f )
					, new Loot( typeof( CopperModulator ), 5.00f )
					, new Loot( typeof( CoarseBlastingPowder ), 5.00f )
					, new Loot( typeof( BronzeTube ), 5.00f )
					, new Loot( typeof( BronzeFramework ), 5.00f )
					, new Loot( typeof( Gyrochronatom ), 5.00f )
					, new Loot( typeof( WoodenStock ), 5.00f )
					, new Loot( typeof( HeavyStock ), 5.00f )
					, new Loot( typeof( SilverContact ), 5.00f )
					, new Loot( typeof( BlacksmithHammer ), 5.00f )
					}, 100f ) };
		}
	}
	public class JerkaiMoonweaver : BaseNPC
	{
		public JerkaiMoonweaver() : base()
		{
			Id = 7957;
			Level = RandomLevel( 36 );
			Name = "Jer'kai Moonweaver";
			NpcText00 = "Greetings $N, I am Jer'kai Moonweaver.";
			Model = 7045;
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
			Faction = Factions.Horde;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 1599, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyC, 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f ) };
		}
	}
	public class KindalMoonweaver : BaseNPC
	{
		public KindalMoonweaver() : base()
		{
			Id = 7956;
			Level = RandomLevel( 42 );
			Name = "Kindal Moonweaver";
			NpcText00 = "Greetings $N, I am Kindal Moonweaver.";
			Model = 7044;
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
			Faction = Factions.Horde;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 6235, (InventoryTypes)15, 2, 2, 2, 0, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyC, 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f ) };
		}
	}
	public class SageKorolusk : BaseNPC
	{
		public SageKorolusk() : base()
		{
			Id = 14373;
			Level = RandomLevel( 59 );
			Name = "Sage Korolusk";
			NpcText00 = "Greetings $N, I am Sage Korolusk.";
			Model = 14427;
			AttackSpeed = 2000;
			CombatReach = 4.05f;
			BoundingRadius = 0.691f;
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
			Flags1 = 0x0400006;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingGuardAI( this ); 
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyD , 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f ) };
		}
	}
	public class ScholarRunethorn : BaseNPC
	{
		public ScholarRunethorn() : base()
		{
			Id = 14374;
			Level = RandomLevel( 59 );
			Name = "Scholar Runethorn";
			NpcText01 = "Oh the horror! The tragedy! We are on the verge of a breakthrough, yet all could be lost.";
			Model = 14426;
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
			Flags1 = 0x0400006;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Darnasus;
			AIEngine = new StandingGuardAI( this ); 
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyD , 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f ) };
		}
	}
	public class WitchDoctorUzeri : BaseNPC
	{
		public WitchDoctorUzeri() : base()
		{
			Id = 8115;
			Level = RandomLevel( 50 );
			Name = "Witch Doctor Uzer'i";
			NpcText00 = "Greetings $N, I am Witch Doctor Uzer'i.";
			Model = 7328;
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
			Faction = Factions.DarkspearTrolls;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 2840, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyD , 100f )
				, new BaseTreasure( WorldDrops.AmazingDrops, 100f ) };
		}
	}
	public class GinroHearthkindle : BaseNPC
	{
		public GinroHearthkindle() : base()
		{
			Id = 7880;
			Level = RandomLevel( 55 );
			Name = "Ginro Hearthkindle";
			NpcText00 = "Greetings $N, I am Ginro Hearthkindle.";
			Model = 6990;
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
			Flags1 = 0x08480006;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Darnasus;
			AIEngine = new StandingGuardAI( this ); 
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyD , 100f )
				, new BaseTreasure( WorldDrops.AmazingDrops, 100f ) };
		}
	}
	
}