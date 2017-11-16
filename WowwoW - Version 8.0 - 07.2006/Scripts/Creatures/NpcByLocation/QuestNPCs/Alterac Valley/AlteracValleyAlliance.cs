using System;
using Server;
using Server.Items;
using Server.Quests;

namespace Server.Creatures
{
	public class MountaineerBoombellow : BaseNPC
	{
		public MountaineerBoombellow() : base()
		{
			Id = 13797;
			Level = RandomLevel( 60 ,61 );
			Name = "Mountaineer Boombellow";
			Model = 13849;
			AttackSpeed = 1061;
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
			NpcFlags = (int)NpcActions.Dialog ;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Friend;
			AIEngine = new DefensiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( Runecloth ), 25.5f )
					, new Loot( typeof( StormpikeSoldiersBlood ), 47.3f )
					, new Loot( typeof( StormpikeSoldiersFlesh ), 0.90f )
					, new Loot( typeof( StormpikeLieutenantsFlesh ), 35.6f )
					, new Loot( typeof( StormpikeCommandersFlesh ), 20f )
					, new Loot( typeof( ArmorScraps ), 90.7f )
					, new Loot( typeof( StormCrystal ), 0.25f )
					, new Loot( typeof( FrostwolfSoldiersMedal ), 0.25f )
					, new Loot( typeof( FrostwolfLieutenantsMedal ), 0.38f )
					, new Loot( typeof( FrostwolfCommandersMedal ), 0.12f )
					, new Loot( typeof( SeveredNightElfHead ), 0.38f )
					, new Loot( typeof( TuftOfGnomeHair ), 0.12f )
					, new Loot( typeof( HumanBoneChip ), 0.51f )
					, new Loot( typeof( TaurenHoof ), 0.12f )
					, new Loot( typeof( DarkspearTrollMojo ), 0.38f )
					, new Loot( typeof( ForsakenHeart ), 0.25f )
					, new Loot( typeof( DwarfSpine ), 0.12f )
					, new Loot( typeof( WornRunningShoes ), 0.12f )
					, new Loot( typeof( SleevelessTShirt ), 0.12f )
					}, 100f ) };
		}
	}
	public class Athramanis : BaseNPC
	{
		public Athramanis() : base()
		{
			Id = 14187;
			Level = RandomLevel( 60 );
			Name = "Athramanis";
			Guild = "Bounty Hunter";
			Model = 14215;
			AttackSpeed = 1273;
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
			NpcFlags = (int)NpcActions.Dialog ;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Stormwind;
			AIEngine = new DefensiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( Runecloth ), 27.2f )
					, new Loot( typeof( StormpikeSoldiersBlood ), 40.1f )
					, new Loot( typeof( StormpikeSoldiersFlesh ), 34.4f )
					, new Loot( typeof( StormpikeLieutenantsFlesh ), 20.8f )
					, new Loot( typeof( StormpikeCommandersFlesh ), 1.51f )
					, new Loot( typeof( ArmorScraps ), 90.5f )
					, new Loot( typeof( StormCrystal ), 2.27f )
					, new Loot( typeof( FrostwolfSoldiersMedal ), 1.51f )
					, new Loot( typeof( FrostwolfLieutenantsMedal ), 1.13f )
					, new Loot( typeof( FrostwolfCommandersMedal ), 0.75f )
					, new Loot( typeof( SeveredNightElfHead ), 0.37f )
					, new Loot( typeof( TuftOfGnomeHair ), 0.37f )
					, new Loot( typeof( HumanBoneChip ), 2.65f )
					, new Loot( typeof( TaurenHoof ), 0.37f )
					, new Loot( typeof( ForsakenHeart ), 1.51f )
					, new Loot( typeof( OrcTooth ), 1.13f )
					, new Loot( typeof( NublessPacifier ), 0.37f )
					, new Loot( typeof( TearStainedHandkerchief ), 1.13f )
					, new Loot( typeof( DocumentFromBoomstickImports ), 0.37f )
					}, 100f ) };
		}
	}
	public class StormpikeRamRiderCommander : BaseNPC
	{
		public StormpikeRamRiderCommander() : base()
		{
			Id = 13577;
			Level = RandomLevel( 60 );
			Name = "Stormpike Ram Rider Commander";
			Model = 13714;
			AttackSpeed = 1061;
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
			NpcFlags = (int)NpcActions.Dialog ;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Alliance;
			AIEngine = new DefensiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( Runecloth ), 21.8f )
					, new Loot( typeof( StormpikeSoldiersBlood ), 29.3f )
					, new Loot( typeof( StormpikeSoldiersFlesh ), 0.31f )
					, new Loot( typeof( StormpikeCommandersFlesh ), 47.5f )
					, new Loot( typeof( ArmorScraps ), 88.4f )
					, new Loot( typeof( StormCrystal ), 0.93f )
					, new Loot( typeof( FrostwolfSoldiersMedal ), 0.93f )
					, new Loot( typeof( IrondeepSupplies ), 3.12f )
					, new Loot( typeof( HumanBoneChip ), 0.31f )
					, new Loot( typeof( TaurenHoof ), 0.62f )
					, new Loot( typeof( ForsakenHeart ), 0.31f )
					}, 100f ) };
		}
	}
	public class DirkSwindle : BaseNPC
	{
		public DirkSwindle() : base()
		{
			Id = 14188;
			Level = RandomLevel( 59 );
			Name = "Dirk Swindle";
			Guild = "Bounty Hunter";
			Model = 14234;
			AttackSpeed = 1287;
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
			NpcFlags = (int)NpcActions.Dialog ;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Stormwind;
			AIEngine = new DefensiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( Runecloth ), 23.9f )
					, new Loot( typeof( StormpikeSoldiersBlood ), 30.7f )
					, new Loot( typeof( StormpikeSoldiersFlesh ), 29.7f )
					, new Loot( typeof( StormpikeLieutenantsFlesh ), 21.9f )
					, new Loot( typeof( StormpikeCommandersFlesh ), 0.33f )
					, new Loot( typeof( ArmorScraps ), 90.2f )
					, new Loot( typeof( StormCrystal ), 1.35f )
					, new Loot( typeof( FrostwolfSoldiersMedal ), 0.33f )
					, new Loot( typeof( FrostwolfLieutenantsMedal ), 2.36f )
					, new Loot( typeof( FrostwolfCommandersMedal ), 1.01f )
					, new Loot( typeof( SeveredNightElfHead ), 0.33f )
					, new Loot( typeof( HumanBoneChip ), 1.68f )
					, new Loot( typeof( TaurenHoof ), 0.67f )
					, new Loot( typeof( DarkspearTrollMojo ), 1.68f )
					, new Loot( typeof( ForsakenHeart ), 1.01f )
					, new Loot( typeof( OrcTooth ), 0.33f )
					, new Loot( typeof( TearStainedHandkerchief ), 1.01f )
					, new Loot( typeof( DocumentFromBoomstickImports ), 0.67f )
					}, 100f ) };
		}
	}
	public class CommanderDuffy : BaseNPC
	{
		public CommanderDuffy() : base()
		{
			Id = 13319;
			Level = RandomLevel( 61 );
			Name = "Commander Duffy";
			Model = 13445;
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
			NpcFlags = (int)NpcActions.Dialog;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Friend;
			AIEngine = new DefensiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( Runecloth ), 22.0f )
					, new Loot( typeof( StormpikeSoldiersBlood ), 40.5f )
					, new Loot( typeof( StormpikeLieutenantsFlesh ), 40.5f )
					, new Loot( typeof( StormpikeCommandersFlesh ), 15.6f )
					, new Loot( typeof( ArmorScraps ), 91.9f )
					, new Loot( typeof( FrostwolfSoldiersMedal ), 1.20f )
					, new Loot( typeof( TaurenHoof ), 0.80f )
					, new Loot( typeof( OrcTooth ), 0.40f )
					}, 100f ) };
		}
	}
	public class StormpikeStableMaster : BaseNPC
	{
		public StormpikeStableMaster() : base()
		{
			Id = 13617;
			Level = RandomLevel( 60 );
			Name = "Stormpike Stable Master";
			Guild = "Stable Master";
			Model = 13669;
			AttackSpeed = 1061;
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
			NpcFlags = (int)NpcActions.Dialog;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Alliance;
			AIEngine = new DefensiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( Runecloth ), 27.0f )
					, new Loot( typeof( StormpikeSoldiersBlood ), 29.2f )
					, new Loot( typeof( StormpikeSoldiersFlesh ), 30.1f )
					, new Loot( typeof( StormpikeLieutenantsFlesh ), 20.9f )
					, new Loot( typeof( ArmorScraps ), 86.8f )
					}, 100f ) };
		}
	}
	public class StormpikeExplosivesExpert : BaseNPC
	{
		public StormpikeExplosivesExpert() : base()
		{
			Id = 13598;
			Level = RandomLevel( 61 );
			Name = "Stormpike Explosives Expert";
			Model = 13671;
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
			NpcFlags = (int)NpcActions.Dialog;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Alliance;
			AIEngine = new DefensiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( Runecloth ), 20.5f )
					, new Loot( typeof( StormpikeSoldiersBlood ), 48.7f )
					, new Loot( typeof( StormpikeLieutenantsFlesh ), 41.0f )
					, new Loot( typeof( StormpikeCommandersFlesh ), 12.8f )
					, new Loot( typeof( ArmorScraps ), 89.7f )
					}, 100f ) };
		}
	}
	public class ArchDruidRenferal : BaseNPC
	{
		public ArchDruidRenferal() : base()
		{
			Id = 13442;
			Level = RandomLevel( 60 );
			Name = "Arch Druid Renferal";
			Model = 13403;
			AttackSpeed = 1061;
			CombatReach = 6.25f;
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
			NpcFlags = (int)NpcActions.Dialog ;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Friend;
			AIEngine = new DefensiveAnimalAI( this );
			Equip( new Item ( 2943, (InventoryTypes)17, 2, 6, 1, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( Runecloth ), 23.3f )
					, new Loot( typeof( StormpikeSoldiersBlood ), 40.9f )
					, new Loot( typeof( StormpikeLieutenantsFlesh ), 41.9f )
					, new Loot( typeof( StormpikeCommandersFlesh ), 17.6f )
					, new Loot( typeof( ArmorScraps ), 91.1f )
					, new Loot( typeof( FrostwolfSoldiersMedal ), 1.55f )
					, new Loot( typeof( FrostwolfLieutenantsMedal ), 0.51f )
					, new Loot( typeof( SeveredNightElfHead ), 0.51f )
					, new Loot( typeof( HumanBoneChip ), 0.51f )
					, new Loot( typeof( TaurenHoof ), 0.51f )
					, new Loot( typeof( ForsakenHeart ), 1.55f )
					}, 100f ) };
		}
	}
	public class StormpikeQuartermaster : BaseNPC
	{
		public StormpikeQuartermaster() : base()
		{
			Id = 12096;
			Level = RandomLevel( 55 );
			Name = "Stormpike Quartermaster";
			Model = 13384;
			AttackSpeed = 1344;
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
			NpcFlags = (int)NpcActions.Dialog;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Alliance;
			AIEngine = new DefensiveAnimalAI( this );
			Sells = new Item[] { new Server.Items.RefreshingSpringWater()
				, new Server.Items.HaunchOfMeat()
				, new Server.Items.DustOfDecay()
				, new Server.Items.EssenceOfPain()
				, new Server.Items.EmptyVial()
				, new Server.Items.LeadedVial()
				, new Server.Items.LethargyRoot()
				, new Server.Items.CuredHamSteak()
				, new Server.Items.ThievesTools()
				, new Server.Items.FlashPowder()
				, new Server.Items.Deathweed()
				, new Server.Items.MorningGloryDew()
				, new Server.Items.EssenceOfAgony()
				, new Server.Items.DustOfDeterioration()
				, new Server.Items.CrystalVial()
				, new Server.Items.RoastedQuail()
			 };
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyD , 100f )
				, new BaseTreasure( WorldDrops.AmazingDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( DemonicFigurine ), 5.00f )

					, new Loot( typeof( ArcanePowder ), 5.00f )
					, new Loot( typeof( WildBerries ), 5.00f )
					, new Loot( typeof( WildThornroot ), 5.00f )
					, new Loot( typeof( HolyCandle ), 5.00f )
					, new Loot( typeof( SacredCandle ), 5.00f )
					, new Loot( typeof( Ankh ), 5.00f )
					, new Loot( typeof( RuneOfTeleportation ), 5.00f )
					, new Loot( typeof( RuneOfPortals ), 5.00f )
					, new Loot( typeof( SymbolOfDivinity ), 5.00f )
					, new Loot( typeof( MapleSeed ), 5.00f )
					, new Loot( typeof( StranglethornSeed ), 5.00f )
					, new Loot( typeof( AshwoodSeed ), 5.00f )
					, new Loot( typeof( HornbeamSeed ), 5.00f )
					, new Loot( typeof( IronwoodSeed ), 5.00f )
					, new Loot( typeof( DustOfDecay ), 5.00f )
					, new Loot( typeof( EssenceOfPain ), 5.00f )
					, new Loot( typeof( EmptyVial ), 5.00f )
					, new Loot( typeof( LeadedVial ), 5.00f )
					, new Loot( typeof( LethargyRoot ), 5.00f )
					, new Loot( typeof( ThievesTools ), 5.00f )
					, new Loot( typeof( FlashPowder ), 5.00f )
					, new Loot( typeof( Deathweed ), 5.00f )
					, new Loot( typeof( InfernalStone ), 5.00f )
					, new Loot( typeof( EssenceOfAgony ), 5.00f )
					, new Loot( typeof( DustOfDeterioration ), 5.00f )
					, new Loot( typeof( CrystalVial ), 5.00f )
					}, 100f ) };
		}
	}
	public class WingCommanderSlidore : BaseNPC
	{
		public WingCommanderSlidore() : base()
		{
			Id = 13438;
			Level = RandomLevel( 58 );
			Name = "Wing Commander Slidore";
			Model = 13471;
			AttackSpeed = 1084;
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
			NpcFlags = (int)NpcActions.Dialog;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Alliance;
			AIEngine = new DefensiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( Runecloth ), 28.9f )
					, new Loot( typeof( StormpikeSoldiersBlood ), 42.1f )
					, new Loot( typeof( StormpikeLieutenantsFlesh ), 7.89f )
					, new Loot( typeof( StormpikeCommandersFlesh ), 21.0f )
					, new Loot( typeof( ArmorScraps ), 92.1f )
					}, 100f ) };
		}
	}
	public class WingCommanderVipore : BaseNPC
	{
		public WingCommanderVipore() : base()
		{
			Id = 13439;
			Level = RandomLevel( 59 );
			Name = "Wing Commander Vipore";
			Model = 13472;
			AttackSpeed = 1073;
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
			NpcFlags = (int)NpcActions.Dialog;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Friend;
			AIEngine = new DefensiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( Runecloth ), 33.3f )
					, new Loot( typeof( StormpikeSoldiersBlood ), 33.3f )
					, new Loot( typeof( StormpikeLieutenantsFlesh ), 27.7f )
					, new Loot( typeof( StormpikeCommandersFlesh ), 27.7f )
					, new Loot( typeof( ArmorScraps ), 88.8f )
					}, 100f ) };
		}
	}
	public class MurgotDeepforge : BaseNPC
	{
		public MurgotDeepforge() : base()
		{
			Id = 13257;
			Level = RandomLevel( 60 );
			Name = "Murgot Deepforge";
			Model = 13151;
			AttackSpeed = 1061;
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
			NpcFlags = (int)NpcActions.Dialog;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Alliance;
			AIEngine = new DefensiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( Runecloth ), 24.5f )
					, new Loot( typeof( StormpikeSoldiersBlood ), 50.1f )
					, new Loot( typeof( StormpikeSoldiersFlesh ), 0.24f )
					, new Loot( typeof( StormpikeLieutenantsFlesh ), 40.3f )
					, new Loot( typeof( StormpikeCommandersFlesh ), 15.0f )
					, new Loot( typeof( ArmorScraps ), 90.7f )
					, new Loot( typeof( HumanBoneChip ), 0.48f )
					, new Loot( typeof( DwarfSpine ), 0.24f )
					}, 100f ) };
		}
	}
	
}