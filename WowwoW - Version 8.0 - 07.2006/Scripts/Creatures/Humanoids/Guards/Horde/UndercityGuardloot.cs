using System;
using Server.Items;
using System.Collections;
using Server;


///////////////////////////////////////////
namespace Server
{
	public class UndercityGuardsDrops
	{
		public static Loot[] DeathguardLinnea = new Loot[] {
														   };		

		public static Loot[] DeathguardDillinger = new Loot[] {
															  };		

		public static Loot[] DeathguardSimmer = new Loot[] {
														   };		

		public static Loot[] DeathguardBurgess = new Loot[] {
															};		

		public static Loot[] DeathguardAbraham = new Loot[] {new Loot( typeof( LinenCloth), 4.7619f ) 
																,new Loot( typeof( SilkCloth), 14.2857f ) 
																,new Loot( typeof( WoolCloth), 23.8095f ) 
																,new Loot( typeof( BrocadeShoes), 2.38095f ) 
															};		

		public static Loot[] DeathguardRandolph = new Loot[] {new Loot( typeof( Runecloth), 35.7143f ) 
																 ,new Loot( typeof( TaperedGreatsword), 7.14286f ) 
															 };		

		public static Loot[] DeathguardOliver = new Loot[] {new Loot( typeof( Runecloth), 9.09091f ) 
														   };		

		public static Loot[] DeathguardTerrence = new Loot[] {new Loot( typeof( LinenCloth), 3.28947f ) 
																 ,new Loot( typeof( SilkCloth), 1.97368f ) 
																 ,new Loot( typeof( WoolCloth), 22.3684f ) 
																 ,new Loot( typeof( BoxShield), 0.657895f ) 
																 ,new Loot( typeof( BrocadeGloves), 0.657895f ) 
																 ,new Loot( typeof( CedarWalkingStick), 0.657895f ) 
																 ,new Loot( typeof( GougingPick), 0.657895f ) 
																 ,new Loot( typeof( HuntingKnife), 1.31579f ) 
																 ,new Loot( typeof( LinkedChainBelt), 1.31579f ) 
																 ,new Loot( typeof( LinkedChainBoots), 0.657895f ) 
																 ,new Loot( typeof( LinkedChainGloves), 0.657895f ) 
																 ,new Loot( typeof( SmallRoundShield), 0.657895f ) 
															 };		

		public static Loot[] DeathguardPhillip = new Loot[] {new Loot( typeof( Runecloth), 23.5294f ) 
																,new Loot( typeof( BulkyMaul), 5.88235f ) 
															};		

		public static Loot[] DeathguardBartrand = new Loot[] {new Loot( typeof( Runecloth), 15.3846f ) 
																 ,new Loot( typeof( BulkyMaul), 7.69231f ) 
															 };		

		public static Loot[] DeathguardBartholomew = new Loot[] {new Loot( typeof( WoolCloth), 30.7692f ) 
																	,new Loot( typeof( GougingPick), 7.69231f ) 
																};		

		public static Loot[] DeathguardLawrence = new Loot[] {new Loot( typeof( SilkCloth), 12.5f ) 
																 ,new Loot( typeof( WoolCloth), 37.5f ) 
															 };		

		public static Loot[] DeathguardMort = new Loot[] {new Loot( typeof( SilkCloth), 12.5f ) 
															 ,new Loot( typeof( WoolCloth), 37.5f ) 
														 };		

		public static Loot[] DeathguardMorris = new Loot[] {new Loot( typeof( SilkCloth), 12.5f ) 
															   ,new Loot( typeof( WoolCloth), 37.5f ) 
														   };		

		public static Loot[] DeathguardCyrus = new Loot[] {
														  };		

		public static Loot[] DeathguardGavin = new Loot[] {new Loot( typeof( WoolCloth), 40f ) 
														  };		

		public static Loot[] DeathguardRoyann = new Loot[] {
														   };		

		public static Loot[] TarrenMillDeathguard = new Loot[] {new Loot( typeof( MageweaveCloth), 31.969f ) 
																   ,new Loot( typeof( BalancedLongBow), 0.159291f ) 
																   ,new Loot( typeof( BlockingTarge), 0.0900339f ) 
																   ,new Loot( typeof( BluntingMace), 0.186994f ) 
																   ,new Loot( typeof( CrochetBelt), 0.0865711f ) 
																   ,new Loot( typeof( CrochetBoots), 0.0831082f ) 
																   ,new Loot( typeof( CrochetBracers), 0.0692569f ) 
																   ,new Loot( typeof( CrochetCloak), 0.114274f ) 
																   ,new Loot( typeof( CrochetGloves), 0.0415541f ) 
																   ,new Loot( typeof( CrochetHat), 0.0831082f ) 
																   ,new Loot( typeof( CrochetPants), 0.1212f ) 
																   ,new Loot( typeof( CrochetShoulderpads), 0.110811f ) 
																   ,new Loot( typeof( CrochetVest), 0.135051f ) 
																   ,new Loot( typeof( CrushingMaul), 0.100422f ) 
																   ,new Loot( typeof( FinePointedDagger), 0.159291f ) 
																   ,new Loot( typeof( HeavyFlintAxe), 0.138514f ) 
																   ,new Loot( typeof( HeavyWarStaff), 0.135051f ) 
																   ,new Loot( typeof( OverlinkedChainArmor), 0.0484798f ) 
																   ,new Loot( typeof( OverlinkedChainBelt), 0.0277027f ) 
																   ,new Loot( typeof( OverlinkedChainBoots), 0.0796454f ) 
																   ,new Loot( typeof( OverlinkedChainBracers), 0.0588683f ) 
																   ,new Loot( typeof( OverlinkedChainCloak), 0.0831082f ) 
																   ,new Loot( typeof( OverlinkedChainGloves), 0.0415541f ) 
																   ,new Loot( typeof( OverlinkedChainPants), 0.0519427f ) 
																   ,new Loot( typeof( OverlinkedChainShoulderpads), 0.0554055f ) 
																   ,new Loot( typeof( OverlinkedCoif), 0.0623312f ) 
																   ,new Loot( typeof( ProtectivePavise), 0.110811f ) 
																   ,new Loot( typeof( SentinelMusket), 0.193919f ) 
																   ,new Loot( typeof( SharpShortsword), 0.138514f ) 
																   ,new Loot( typeof( SplinteringBattleAxe), 0.124662f ) 
																   ,new Loot( typeof( ThickCloak), 0.124662f ) 
																   ,new Loot( typeof( ThickLeatherBelt), 0.0761826f ) 
																   ,new Loot( typeof( ThickLeatherBoots), 0.0692569f ) 
																   ,new Loot( typeof( ThickLeatherBracers), 0.0623312f ) 
																   ,new Loot( typeof( ThickLeatherGloves), 0.0969596f ) 
																   ,new Loot( typeof( ThickLeatherHat), 0.0415541f ) 
																   ,new Loot( typeof( ThickLeatherPants), 0.0554055f ) 
																   ,new Loot( typeof( ThickLeatherShoulderpads), 0.0623312f ) 
																   ,new Loot( typeof( ThickLeatherTunic), 0.0623312f ) 
																   ,new Loot( typeof( WhettedClaymore), 0.138514f ) 
															   };		

		public static Loot[] DeathguardSamsa = new Loot[] {
														  };		

		public static Loot[] DeathguardHumbert = new Loot[] {
															};		

		public static Loot[] UndercityGuardian = new Loot[] {new Loot( typeof( Runecloth), 21.2518f ) 
																,new Loot( typeof( BalancedWarAxe), 0.14556f ) 
																,new Loot( typeof( CloutMace), 0.14556f ) 
																,new Loot( typeof( CrestedBuckler), 0.14556f ) 
																,new Loot( typeof( LightPlatePants), 0.14556f ) 
																,new Loot( typeof( PrimedMusket), 0.291121f ) 
																,new Loot( typeof( SmoothLeatherBelt), 0.14556f ) 
																,new Loot( typeof( SmoothLeatherBoots), 0.14556f ) 
																,new Loot( typeof( TaperedGreatsword), 0.14556f ) 
																,new Loot( typeof( TwillBracers), 0.291121f ) 
																,new Loot( typeof( TwillCover), 0.14556f ) 
															};		

		public static Loot[] DeathguardLundmark = new Loot[] {new Loot( typeof( LinenCloth), 29.4643f ) 
																 ,new Loot( typeof( CalicoBracers), 1.78571f ) 
																 ,new Loot( typeof( CrudeBattleAxe), 0.892857f ) 
																 ,new Loot( typeof( FeebleShortbow), 0.892857f ) 
																 ,new Loot( typeof( FishermanKnife), 2.67857f ) 
																 ,new Loot( typeof( RustyWarhammer), 0.892857f ) 
																 ,new Loot( typeof( WarpedLeatherBelt), 0.892857f ) 
																 ,new Loot( typeof( WarpedLeatherBracers), 0.892857f ) 
																 ,new Loot( typeof( WarpedLeatherGloves), 0.892857f ) 
																 ,new Loot( typeof( WarpedLeatherPants), 1.78571f ) 
																 ,new Loot( typeof( WarpedLeatherVest), 0.892857f ) 
															 };		

		public static Loot[] DeathguardPodrig = new Loot[] {
														   };		

		public static Loot[] SilverpineDeathguard = new Loot[] {new Loot( typeof( MageweaveCloth), 2.65152f ) 
																   ,new Loot( typeof( SilkCloth), 27.0202f ) 
																   ,new Loot( typeof( BroadClaymore), 0.252525f ) 
																   ,new Loot( typeof( DoubleMailBoots), 0.126263f ) 
																   ,new Loot( typeof( DoubleMailPants), 0.126263f ) 
																   ,new Loot( typeof( DoubleStitchedCloak), 0.126263f ) 
																   ,new Loot( typeof( HardenedLeatherShoulderpads), 0.126263f ) 
																   ,new Loot( typeof( HeftyWarAxe), 0.378788f ) 
																   ,new Loot( typeof( InterlacedBelt), 0.126263f ) 
																   ,new Loot( typeof( InterlacedBracers), 0.126263f ) 
																   ,new Loot( typeof( InterlacedGloves), 0.126263f ) 
																   ,new Loot( typeof( InterlacedPants), 0.126263f ) 
																   ,new Loot( typeof( InterlacedShoulderpads), 0.126263f ) 
																   ,new Loot( typeof( InterlacedVest), 0.126263f ) 
																   ,new Loot( typeof( KeenAxe), 0.126263f ) 
																   ,new Loot( typeof( LargeWarClub), 0.252525f ) 
																   ,new Loot( typeof( LongBarreledMusket), 0.252525f ) 
																   ,new Loot( typeof( ReflectiveHeater), 0.378788f ) 
																   ,new Loot( typeof( ShinyDirk), 0.126263f ) 
																   ,new Loot( typeof( StoneClub), 0.126263f ) 
															   };		

		public static Loot[] DeathguardElite = new Loot[] {new Loot( typeof( Runecloth), 33.5372f ) 
															  ,new Loot( typeof( BalancedWarAxe), 0.203874f ) 
															  ,new Loot( typeof( CrestedBuckler), 0.101937f ) 
															  ,new Loot( typeof( DeflectingTower), 0.30581f ) 
															  ,new Loot( typeof( FineLongsword), 0.101937f ) 
															  ,new Loot( typeof( JaggedAxe), 0.203874f ) 
															  ,new Loot( typeof( LaminatedScaleBoots), 0.203874f ) 
															  ,new Loot( typeof( LaminatedScalePants), 0.203874f ) 
															  ,new Loot( typeof( LightPlatePants), 0.101937f ) 
															  ,new Loot( typeof( LightPlateShoulderpads), 0.101937f ) 
															  ,new Loot( typeof( RecurveLongBow), 0.101937f ) 
															  ,new Loot( typeof( SmoothLeatherArmor), 0.101937f ) 
															  ,new Loot( typeof( SmoothLeatherGloves), 0.101937f ) 
															  ,new Loot( typeof( SmoothLeatherHelmet), 0.101937f ) 
															  ,new Loot( typeof( SpikedDagger), 0.101937f ) 
															  ,new Loot( typeof( StoutWarStaff), 0.101937f ) 
															  ,new Loot( typeof( TwillBelt), 0.203874f ) 
															  ,new Loot( typeof( TwillBracers), 0.101937f ) 
															  ,new Loot( typeof( TwillCloak), 0.101937f ) 
															  ,new Loot( typeof( TwillCover), 0.203874f ) 
															  ,new Loot( typeof( TwillGloves), 0.203874f ) 
															  ,new Loot( typeof( TwillPants), 0.30581f ) 
														  };		

		public static Loot[] DeathguardKel = new Loot[] {
														};		

		public static Loot[] RoyalDreadguard = new Loot[] {
														  };		

		public static Loot[] ExecutorZygand = new Loot[] {
														 };		

		public static Loot[] ExecutorArren = new Loot[] {
														};		

		public static Loot[] JuniorApothecaryHolland = new Loot[] {
																  };

	}
}