using System;
using Server;
using Server.Items;
using Server.Quests;

namespace Server.Creatures
{
	public class GuardByron : BaseNPC
	{
		public GuardByron() : base()
		{
			Id = 4921;
			Level = RandomLevel( 40 );
			Name = "Guard Byron";
			NpcText00 = "Greetings $N, I am Guard Byron.";
			Model = 2910;
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
			Equip( new Item ( 7483, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0), new Item ( 1705, (InventoryTypes)14, 4, 6, 1, 4, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyC , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f ) };
		}
	}
	public class NazeerBloodpike : BaseNPC
	{
		public NazeerBloodpike() : base()
		{
			Id = 4791;
			Level = RandomLevel( 48 );
			Name = "Nazeer Bloodpike";
			NpcText00 = "Greetings $N, I am Nazeer Bloodpike.";
			Model = 4685;
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
			Flags1 = 0x08400046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Horde;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 7480, (InventoryTypes)17, 2, 6, 1, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyC , 100f )
				, new BaseTreasure( WorldDrops.AmazingDrops, 100f ) };
		}
	}
	public class Dogol : BaseNPC
	{
		public Dogol() : base()
		{
			Id = 5087;
			Level = RandomLevel( 30 );
			Name = "Do'gol";
			NpcText00 = "Greetings $N, I am Do'gol.";
			Model = 655;
			AttackSpeed = 2000;
			CombatReach = 2.01f;
			BoundingRadius = 0.539f;
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
			Equip( new Item ( 7440, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f ) };
		}
	}
	public class Krog : BaseNPC
	{
		public Krog() : base()
		{
			Id = 4926;
			Level = RandomLevel( 40 );
			Name = "Krog";
			NpcText00 = "The humans built an inn on the edge of the Barrens. The Shady Rest, they called it. Weeks ago, it was burned down.$b$bThe Warchief told us to leave the humans alone, so long as they didn't cross our borders, but it appears someone violated his wishes.$b$bHe has put me in charge of getting to the bottom of it. If you wish to provide assistance, go to the remains of the Shady Rest Inn and return any clues you find to me.";
			Model = 2972;
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
			Flags1 = 0x08400046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Horde;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 12236, (InventoryTypes)13, 2, 4, 2, 7, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyC , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f ) };
		}
	}
	public class CazTwosprocket : BaseNPC
	{
		public CazTwosprocket() : base()
		{
			Id = 4941;
			Level = RandomLevel( 35 );
			Name = "Caz Twosprocket";
			NpcText00 = "Greetings $N, I am Caz Twosprocket.";
			Model = 2950;
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
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f ) };
		}
	}
	public class ArchmageTervosh : BaseNPC
	{
		public ArchmageTervosh() : base()
		{
			Id = 4967;
			Level = RandomLevel( 38 );
			Name = "Archmage Tervosh";
			NpcText00 = "Greetings $N, I am Archmage Tervosh.";
			Model = 2969;
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
			Faction = Factions.Alliance;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 1927, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyC , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f ) };
		}
	}
	public class NatPagle : BaseNPC
	{
		public NatPagle() : base()
		{
			Id = 12919;
			Level = RandomLevel( 45 );
			Name = "Nat Pagle";
			NpcText00 = "Greetings $N, I am Nat Pagle.";
			Model = 13099;
			AttackSpeed = 1483;
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
			Flags1 = 0x06;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Friend;
			AIEngine = new StandingGuardAI( this ); 
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyC , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f ) };
		}
	}
	public class OverlordMokMorokk : BaseNPC
	{
		public OverlordMokMorokk() : base()
		{
			Id = 4500;
			Level = RandomLevel( 45 );
			Name = "Overlord Mok'Morokk";
			NpcText00 = "Greetings $N, I am Overlord Mok'Morokk.";
			Model = 11571;
			AttackSpeed = 3000;
			CombatReach = 2.01f;
			BoundingRadius = 0.772f;
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
			Flags1 = 0x06E;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingGuardAI( this ); 
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyC , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f ) };
		}
	}
	public class DrazZilb : BaseNPC
	{
		public DrazZilb() : base()
		{
			Id = 4501;
			Level = RandomLevel( 40 );
			Name = "Draz'Zilb";
			NpcText00 = "Greetings $N, I am Draz'Zilb.";
			Model = 11539;
			AttackSpeed = 2000;
			CombatReach = 2.01f;
			BoundingRadius = 0.599f;
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
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingGuardAI( this ); 
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyC , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f ) };
		}
	}
	public class MudcrushDurtfeet : BaseNPC
	{
		public MudcrushDurtfeet() : base()
		{
			Id = 4503;
			Level = RandomLevel( 42 );
			Name = "Mudcrush Durtfeet";
			NpcText00 = "Greetings $N, I am Mudcrush Durtfeet.";
			Model = 11530;
			AttackSpeed = 2000;
			CombatReach = 2.01f;
			BoundingRadius = 0.57f;
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
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingGuardAI( this ); 
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyC , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f ) };
		}
	}
	public class FioraLongears : BaseNPC
	{
		public FioraLongears() : base()
		{
			Id = 4456;
			Level = RandomLevel( 26 );
			Name = "Fiora Longears";
			NpcText00 = "Greetings $N, I am Fiora Longears.";
			Model = 4691;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.214f;
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
			Equip( new Item ( 24296, (InventoryTypes)13, 2, 14, 1, 7, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f ) };
		}
	}
	public class Tabetha : BaseNPC
	{
		public Tabetha() : base()
		{
			Id = 6546;
			Level = RandomLevel( 60 );
			Name = "Tabetha";
			NpcText01 = "Your errand must mean much, $c, to draw you so deep into the marsh...";
			Model = 5375;
			AttackSpeed = 2000;
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
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x080066;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Friend;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 7465, (InventoryTypes)13, 2, 14, 1, 0, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyD , 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f ) };
		}
	}
	public class Tharg : BaseNPC
	{
		public Tharg() : base()
		{
			Id = 4502;
			Level = RandomLevel( 44 );
			Name = "Tharg";
			NpcText00 = "Greetings $N, I am Tharg.";
			Model = 3193;
			AttackSpeed = 2000;
			CombatReach = 2.16f;
			BoundingRadius = 0.719f;
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
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingGuardAI( this ); 
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyC , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f ) };
		}
	}
	
}