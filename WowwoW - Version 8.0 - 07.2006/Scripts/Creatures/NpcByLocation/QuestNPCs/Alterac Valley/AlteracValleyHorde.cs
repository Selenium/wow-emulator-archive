using System;
using Server;
using Server.Items;
using Server.Quests;

namespace Server.Creatures
{
	public class CorporalNoregStormpike : BaseNPC
	{
		public CorporalNoregStormpike() : base()
		{
			Id = 13447;
			Level = RandomLevel( 58 ,59 );
			Name = "Corporal Noreg Stormpike";
			Model = 13383;
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
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( Runecloth ), 29.8f )
					, new Loot( typeof( StormpikeSoldiersBlood ), 32.6f )
					, new Loot( typeof( StormpikeSoldiersFlesh ), 1.19f )
					, new Loot( typeof( StormpikeLieutenantsFlesh ), 0.23f )
					, new Loot( typeof( StormpikeCommandersFlesh ), 0.23f )
					, new Loot( typeof( ArmorScraps ), 5.25f )
					, new Loot( typeof( StormCrystal ), 1.43f )
					, new Loot( typeof( FrostwolfSoldiersMedal ), 1.67f )
					, new Loot( typeof( FrostwolfLieutenantsMedal ), 0.71f )
					, new Loot( typeof( FrostwolfCommandersMedal ), 1.19f )
					, new Loot( typeof( SeveredNightElfHead ), 0.47f )
					, new Loot( typeof( TuftOfGnomeHair ), 0.23f )
					, new Loot( typeof( HumanBoneChip ), 0.47f )
					, new Loot( typeof( TaurenHoof ), 1.19f )
					, new Loot( typeof( ForsakenHeart ), 1.43f )
					, new Loot( typeof( DwarfSpine ), 0.23f )
					, new Loot( typeof( OrcTooth ), 0.71f )
					, new Loot( typeof( WornRunningShoes ), 0.23f )
					, new Loot( typeof( DocumentFromBoomstickImports ), 0.47f )
					}, 100f ) };
		}
	}
	public class SergeantYazraBloodsnarl : BaseNPC
	{
		public SergeantYazraBloodsnarl() : base()
		{
			Id = 13448;
			Level = RandomLevel( 55 ,57 );
			Name = "Sergeant Yazra Bloodsnarl";
			NpcText00 = "Greetings $N.";
			Model = 13402;
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
			NpcFlags = (int)NpcActions.Dialog;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Ogrimmar;
			AIEngine = new DefensiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( Runecloth ), 35.7f )
					, new Loot( typeof( StormpikeSoldiersBlood ), 0.30f )
					, new Loot( typeof( StormpikeSoldiersFlesh ), 0.60f )
					, new Loot( typeof( StormpikeLieutenantsFlesh ), 0.60f )
					, new Loot( typeof( ArmorScraps ), 2.70f )
					, new Loot( typeof( StormCrystal ), 40.2f )
					, new Loot( typeof( FrostwolfSoldiersMedal ), 0.60f )
					, new Loot( typeof( FrostwolfLieutenantsMedal ), 1.20f )
					, new Loot( typeof( SeveredNightElfHead ), 0.90f )
					, new Loot( typeof( TaurenHoof ), 0.60f )
					, new Loot( typeof( ForsakenHeart ), 1.20f )
					}, 100f ) };
		}
	}
	public class FrostwolfWolfRiderCommander : BaseNPC

	{
		public FrostwolfWolfRiderCommander() : base()
		{
			Id = 13441;
			Level = RandomLevel( 60 );
			Name = "Frostwolf Wolf Rider Commander";
			Model = 13415;
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
			Faction = Factions.Horde;
			AIEngine = new DefensiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( Runecloth ), 34.1f )
					, new Loot( typeof( ArmorScraps ), 84.6f )
					, new Loot( typeof( StormCrystal ), 0.49f )
					, new Loot( typeof( FrostwolfSoldiersMedal ), 0.49f )
					, new Loot( typeof( FrostwolfCommandersMedal ), 45.0f )
					, new Loot( typeof( ForsakenHeart ), 0.99f )
					}, 100f ) };
		}
	}
	public class CommanderMulfort : BaseNPC
	{
		public CommanderMulfort() : base()
		{
			Id = 13153;
			Level = RandomLevel( 61 );
			Name = "Commander Mulfort";
			Model = 13464;
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
			Faction = Factions.ThunderBluff;
			AIEngine = new DefensiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( Runecloth ), 25.7f )
					, new Loot( typeof( StormpikeSoldiersFlesh ), 0.37f )
					, new Loot( typeof( ArmorScraps ), 86.1f )
					, new Loot( typeof( StormCrystal ), 38.4f )
					, new Loot( typeof( FrostwolfLieutenantsMedal ), 29.8f )
					, new Loot( typeof( FrostwolfCommandersMedal ), 15.6f )
					, new Loot( typeof( SeveredNightElfHead ), 0.37f )
					}, 100f ) };
		}
	}
	public class SmithRegzar : BaseNPC
	{
		public SmithRegzar() : base()
		{
			Id = 13176;
			Level = RandomLevel( 60 );
			Name = "Smith Regzar";
			Model = 13152;
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
			NpcFlags = (int)NpcActions.Dialog;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Horde;
			AIEngine = new DefensiveAnimalAI( this );
			Equip( new Item ( 2401, (InventoryTypes)17, 2, 6, 1, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( Runecloth ), 25.8f )
					, new Loot( typeof( StormpikeSoldiersBlood ), 0.24f )
					, new Loot( typeof( StormpikeLieutenantsFlesh ), 0.24f )
					, new Loot( typeof( ArmorScraps ), 84.8f )
					, new Loot( typeof( StormCrystal ), 43.1f )
					, new Loot( typeof( FrostwolfLieutenantsMedal ), 38.7f )
					, new Loot( typeof( FrostwolfCommandersMedal ), 19.8f )
					, new Loot( typeof( HumanBoneChip ), 0.24f )
					, new Loot( typeof( ForsakenHeart ), 0.24f )
					}, 100f ) };
		}
	}
	public class FrostwolfStableMaster : BaseNPC
	{
		public FrostwolfStableMaster() : base()
		{
			Id = 13616;
			Level = RandomLevel( 60 );
			Name = "Frostwolf Stable Master";
			Guild = "Stable Master";
			Model = 13670;
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
			NpcFlags = (int)NpcActions.Banker | (int)NpcActions.InKeeper | (int)NpcActions.Trainer | (int)NpcActions.StableMaster | (int)NpcActions.Petition | 81920;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Horde;
			AIEngine = new DefensiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( Runecloth ), 19.0f )
					, new Loot( typeof( ArmorScraps ), 80.9f )
					, new Loot( typeof( StormCrystal ), 14.2f )
					, new Loot( typeof( FrostwolfSoldiersMedal ), 28.5f )
					, new Loot( typeof( FrostwolfLieutenantsMedal ), 14.2f )
					}, 100f ) };
		}
	}
	public class FrostwolfExplosivesExpert : BaseNPC
	{
		public FrostwolfExplosivesExpert() : base()
		{
			Id = 13597;
			Level = RandomLevel( 61 );
			Name = "Frostwolf Explosives Expert";
			NpcText00 = "Greetings $N.";
			Model = 13793;
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
			Faction = Factions.Horde;
			AIEngine = new DefensiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( Runecloth ), 30.1f )
					, new Loot( typeof( ArmorScraps ), 87.3f )
					, new Loot( typeof( StormCrystal ), 41.2f )
					, new Loot( typeof( FrostwolfLieutenantsMedal ), 26.9f )
					, new Loot( typeof( FrostwolfCommandersMedal ), 15.8f )
					}, 100f ) };
		}
	}
	public class NajakHexxen : BaseNPC
	{
		public NajakHexxen() : base()
		{
			Id = 14185;
			Level = RandomLevel( 58 ,59 );
			Name = "Najak Hexxen";
			Guild = "Bounty Hunter";
			NpcText00 = "Greetings $N.";
			Model = 14232;
			AttackSpeed = 1302;
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
			Faction = Factions.Ogrimmar;
			AIEngine = new DefensiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( Runecloth ), 28.2f )
					, new Loot( typeof( StormpikeSoldiersBlood ), 0.27f )
					, new Loot( typeof( StormpikeSoldiersFlesh ), 0.55f )
					, new Loot( typeof( StormpikeLieutenantsFlesh ), 0.27f )
					, new Loot( typeof( StormpikeCommandersFlesh ), 0.27f )
					, new Loot( typeof( ArmorScraps ), 90.2f )
					, new Loot( typeof( StormCrystal ), 31.0f )
					, new Loot( typeof( FrostwolfSoldiersMedal ), 37.7f )
					, new Loot( typeof( FrostwolfLieutenantsMedal ), 19.5f )
					, new Loot( typeof( FrostwolfCommandersMedal ), 0.27f )
					, new Loot( typeof( SeveredNightElfHead ), 0.27f )
					, new Loot( typeof( TuftOfGnomeHair ), 0.27f )
					, new Loot( typeof( HumanBoneChip ), 0.27f )
					, new Loot( typeof( TaurenHoof ), 0.55f )
					, new Loot( typeof( DarkspearTrollMojo ), 0.55f )
					, new Loot( typeof( ForsakenHeart ), 0.83f )
					, new Loot( typeof( DwarfSpine ), 0.27f )
					, new Loot( typeof( OrcTooth ), 1.11f )
					, new Loot( typeof( NublessPacifier ), 0.27f )
					, new Loot( typeof( DocumentFromBoomstickImports ), 0.27f )
					}, 100f ) };
		}
	}
	public class FrostwolfQuartermaster : BaseNPC
	{
		public FrostwolfQuartermaster() : base()
		{
			Id = 12097;
			Level = RandomLevel( 55 );
			Name = "Frostwolf Quartermaster";
			Model = 13385;
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
			NpcFlags = (int)NpcActions.Dialog | (int)NpcActions.Vendor;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Horde;
			AIEngine = new DefensiveAnimalAI( this );
			Sells = new Item[] { new Server.Items.IceColdMilk()
				, new Server.Items.MelonJuice()
				, new Server.Items.MoonberryJuice()
				, new Server.Items.DemonicFigurine()
				, new Server.Items.ArcanePowder()
				, new Server.Items.WildBerries()
				, new Server.Items.WildThornroot()
				, new Server.Items.HolyCandle()
				, new Server.Items.SacredCandle()
				, new Server.Items.Ankh()
				, new Server.Items.RuneOfTeleportation()
				, new Server.Items.RuneOfPortals()
				, new Server.Items.SymbolOfDivinity()
				, new Server.Items.MapleSeed()
				, new Server.Items.StranglethornSeed()
				, new Server.Items.AshwoodSeed()
				, new Server.Items.HornbeamSeed()
				, new Server.Items.IronwoodSeed()
				, new Server.Items.SweetNectar()
				, new Server.Items.ToughJerky18000()
				, new Server.Items.RefreshingSpringWater18005()
				, new Server.Items.HaunchOfMeat()
				, new Server.Items.DustOfDecay()
				, new Server.Items.EmptyVial()
				, new Server.Items.LeadedVial()
				, new Server.Items.MuttonChop()
				, new Server.Items.WildHogShank()
				, new Server.Items.LethargyRoot()
				, new Server.Items.CuredHamSteak()
				, new Server.Items.FlashPowder()
				, new Server.Items.Deathweed()
				, new Server.Items.InfernalStone()
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
					, new Loot( typeof( ArmorScraps ), 5.00f )
					, new Loot( typeof( StormCrystal ), 5.00f )
					, new Loot( typeof( FrostwolfSoldiersMedal ), 5.00f )
					, new Loot( typeof( TaurenHoof ), 5.00f )
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
	public class WingCommanderGuse : BaseNPC
	{
		public WingCommanderGuse() : base()
		{
			Id = 13179;
			Level = RandomLevel( 59 );
			Name = "Wing Commander Guse";
			Model = 13473;
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
			Faction = Factions.Ogrimmar;
			AIEngine = new DefensiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( Runecloth ), 50f )
					, new Loot( typeof( ArmorScraps ), 83.3f )
					, new Loot( typeof( StormCrystal ), 25f )
					, new Loot( typeof( FrostwolfLieutenantsMedal ), 58.3f )
					, new Loot( typeof( FrostwolfCommandersMedal ), 8.33f )
					}, 100f ) };
		}
	}
	public class WingCommanderJeztor : BaseNPC
	{
		public WingCommanderJeztor() : base()
		{
			Id = 13180;
			Level = RandomLevel( 58 );
			Name = "Wing Commander Jeztor";
			Model = 13474;
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
			Faction = Factions.Friend;
			AIEngine = new DefensiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( Runecloth ), 40f )
					, new Loot( typeof( ArmorScraps ), 95f )
					, new Loot( typeof( StormCrystal ), 30f )
					, new Loot( typeof( FrostwolfLieutenantsMedal ), 50f )
					, new Loot( typeof( FrostwolfCommandersMedal ), 20f )
					}, 100f ) };
		}
	}
	public class RavakGrimtotem : BaseNPC
	{
		public RavakGrimtotem() : base()
		{
			Id = 14186;
			Level = RandomLevel( 60 );
			Name = "Ravak Grimtotem";
			Guild = "Bounty Hunter";
			NpcText00 = "Greetings $N.";
			Model = 14233;
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
			NpcFlags = (int)NpcActions.Dialog;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Ogrimmar;
			AIEngine = new DefensiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( Runecloth ), 24.1f )
					, new Loot( typeof( StormpikeSoldiersBlood ), 0.57f )
					, new Loot( typeof( StormpikeSoldiersFlesh ), 1.14f )
					, new Loot( typeof( StormpikeLieutenantsFlesh ), 0.28f )
					, new Loot( typeof( ArmorScraps ), 90.5f )
					, new Loot( typeof( StormCrystal ), 21.5f )
					, new Loot( typeof( FrostwolfSoldiersMedal ), 32.7f )
					, new Loot( typeof( FrostwolfLieutenantsMedal ), 12.9f )
					, new Loot( typeof( FrostwolfCommandersMedal ), 0.28f )
					, new Loot( typeof( SeveredNightElfHead ), 0.57f )
					, new Loot( typeof( TuftOfGnomeHair ), 0.86f )
					, new Loot( typeof( HumanBoneChip ), 0.57f )
					, new Loot( typeof( TaurenHoof ), 1.14f )
					, new Loot( typeof( ForsakenHeart ), 0.86f )
					, new Loot( typeof( NatPaglesGuideToExtremeAnglin ), 0.57f )
					, new Loot( typeof( SleevelessTShirt ), 0.28f )
					}, 100f ) };
		}
	}
	public class PrimalistThurloga : BaseNPC
	{
		public PrimalistThurloga() : base()
		{
			Id = 13236;
			Level = RandomLevel( 60 );
			Name = "Primalist Thurloga";
			Model = 13478;
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
			Faction = Factions.Horde;
			AIEngine = new DefensiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( Runecloth ), 38.1f )
					, new Loot( typeof( StormpikeLieutenantsFlesh ), 0.50f )
					, new Loot( typeof( ArmorScraps ), 88.4f )
					, new Loot( typeof( StormCrystal ), 46.2f )
					, new Loot( typeof( FrostwolfSoldiersMedal ), 1.00f )
					, new Loot( typeof( FrostwolfLieutenantsMedal ), 40.2f )
					, new Loot( typeof( FrostwolfCommandersMedal ), 15.5f )
					, new Loot( typeof( SeveredNightElfHead ), 0.50f )
					, new Loot( typeof( TaurenHoof ), 1.00f )
					, new Loot( typeof( ForsakenHeart ), 1.00f )
					}, 100f ) };
		}
	}
	
}