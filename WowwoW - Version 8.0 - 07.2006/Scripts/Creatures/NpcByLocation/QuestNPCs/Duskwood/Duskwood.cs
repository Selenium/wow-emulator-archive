using System;
using Server;
using Server.Items;
using Server.Quests;

namespace Server.Creatures
{
	public class Calor : BaseNPC
	{
		public Calor() : base()
		{
			Id = 663;
			Level = RandomLevel( 20 );
			Name = "Calor";
			NpcText00 = "Greetings $N, I am Calor.";
			Model = 2027;
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
			Faction = Factions.Stormwind;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 7483, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )				, new BaseTreasure( WorldDrops.MediumDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( CalorsNote ), 5.00f )
					}, 100f ) };
		}
	}
	public class SirraVonIndi : BaseNPC
	{
		public SirraVonIndi() : base()
		{
			Id = 268;
			Level = RandomLevel( 24 );
			Name = "Sirra Von'Indi";
			Guild = "Historian of Darkshire";
			NpcText00 = "Greetings $N, I am Sirra Von'Indi.";
			Model = 4324;
			AttackSpeed = 1000;
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
			Faction = Factions.Stormwind;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 7428, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0), new Item ( 1705, (InventoryTypes)14, 4, 6, 1, 4, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )				, new BaseTreasure( WorldDrops.MediumDrops, 100f ) };
		}
	}
	public class LordElloEbonlocke : BaseNPC
	{
		public LordElloEbonlocke() : base()
		{
			Id = 263;
			Level = RandomLevel( 30 );
			Name = "Lord Ello Ebonlocke";
			Guild = "Mayor of Darkshire";
			NpcText00 = "Greetings $N, I am Lord Ello Ebonlocke.";
			Model = 4321;
			AttackSpeed = 1000;
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
			Faction = Factions.Stormwind;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 7428, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0), new Item ( 1705, (InventoryTypes)14, 4, 6, 1, 4, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f ) };
		}
	}
	public class GlorinSteelbrow : BaseNPC
	{
		public GlorinSteelbrow() : base()
		{
			Id = 1217;
			Level = RandomLevel( 25 );
			Name = "Glorin Steelbrow";
			NpcText00 = "Greetings $N, I am Glorin Steelbrow.";
			Model = 3460;
			AttackSpeed = 1000;
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
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )				, new BaseTreasure( WorldDrops.MediumDrops, 100f ) };
		}
	}
	public class MadameEva : BaseNPC
	{
		public MadameEva() : base()
		{
			Id = 265;
			Level = RandomLevel( 25 );
			Name = "Madame Eva";
			NpcText00 = "Greetings $N, I am Madame Eva.";
			Model = 4323;
			AttackSpeed = 1000;
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
			Flags1 = 0x08480046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Stormwind;
			AIEngine = new StandingGuardAI( this ); 
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )				, new BaseTreasure( WorldDrops.MediumDrops, 100f ) };
		}
	}
	public class SvenYorgen : BaseNPC
	{
		public SvenYorgen() : base()
		{
			Id = 311;
			Level = RandomLevel( 20 );
			Name = "Sven Yorgen";
			NpcText00 = "Greetings $N, I am Sven Yorgen.";
			Model = 4327;
			AttackSpeed = 1000;
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
			Faction = Factions.Stormwind;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 12236, (InventoryTypes)13, 2, 4, 2, 7, 0, 0, 0), new Item ( 1684, (InventoryTypes)14, 4, 6, 1, 4, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )				, new BaseTreasure( WorldDrops.MediumDrops, 100f ) };
		}
	}
	public class TavernkeepSmitts : BaseNPC
	{
		public TavernkeepSmitts() : base()
		{
			Id = 273;
			Level = RandomLevel( 22 );
			Name = "Tavernkeep Smitts";
			NpcText00 = "Greetings $N, I am Tavernkeep Smitts.";
			Model = 1731;
			AttackSpeed = 1000;
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
			Faction = Factions.Stormwind;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 7426, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )				, new BaseTreasure( WorldDrops.MediumDrops, 100f ) };
		}
	}
	public class ChefGrual : BaseNPC
	{
		public ChefGrual() : base()
		{
			Id = 272;
			Level = RandomLevel( 30 );
			Name = "Chef Grual";
			NpcText00 = "Greetings $N, I am Chef Grual.";
			Model = 1715;
			AttackSpeed = 1000;
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
			Faction = Factions.Stormwind;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 7431, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f ) };
		}
	}
	public class Jitters : BaseNPC
	{
		public Jitters() : base()
		{
			Id = 288;
			Level = RandomLevel( 25 );
			Name = "Jitters";
			NpcText00 = "Greetings $N, I am Jitters.";
			Model = 4325;
			AttackSpeed = 1000;
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
			Faction = Factions.Stormwind;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 6537, (InventoryTypes)23, 4, 0, 1, 7, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )				, new BaseTreasure( WorldDrops.MediumDrops, 100f ) };
		}
	}
	public class DeathstalkerZraedus : BaseNPC
	{
		public DeathstalkerZraedus() : base()
		{
			Id = 5418;
			Level = RandomLevel( 40 );
			Name = "Deathstalker Zraedus";
			NpcText00 = "Greetings $N, I am Deathstalker Zraedus.";
			Model = 4342;
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
			Faction = Factions.Undercity;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 20095, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyC , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( Morrowgrain ), 33.3f )
					}, 100f ) };
		}
	}
	public class ViktoriPrismAntras : BaseNPC
	{
		public ViktoriPrismAntras() : base()
		{
			Id = 276;
			Level = RandomLevel( 28 );
			Name = "Viktori Prism'Antras";
			NpcText00 = "Greetings $N, I am Viktori Prism'Antras.";
			Model = 4326;
			AttackSpeed = 1000;
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
			Faction = Factions.Stormwind;
			AIEngine = new StandingGuardAI( this ); 
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f ) };
		}
	}
	public class ElaineCarevin : BaseNPC
	{
		public ElaineCarevin() : base()
		{
			Id = 633;
			Level = RandomLevel( 18 );
			Name = "Elaine Carevin";
			NpcText00 = "Greetings $N, I am Elaine Carevin.";
			Model = 1571;
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
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x08480046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Stormwind;
			AIEngine = new StandingGuardAI( this ); 
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )				, new BaseTreasure( WorldDrops.MediumDrops, 100f ) };
		}
	}
	public class CouncilmanMillstipe : BaseNPC
	{
		public CouncilmanMillstipe() : base()
		{
			Id = 270;
			Level = RandomLevel( 28 );
			Name = "Councilman Millstipe";
			Guild = "Council of Darkshire";
			NpcText00 = "Greetings $N, I am Councilman Millstipe.";
			Model = 1724;
			AttackSpeed = 1000;
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
			Faction = Factions.Stormwind;
			AIEngine = new StandingGuardAI( this ); 
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f ) };
		}
	}
	
}