using System;
using Server.Items;
using System.Collections;
using Server;


///////////////////////////////////////////
namespace Server
{
	public class ThunderBluffGuardsDrops
	{
		public static Loot[] Bluffwatcher = new Loot[] {new Loot( typeof( MageweaveCloth), 32.5773f ) 
														   ,new Loot( typeof( CloutMace), 0.206186f ) 
														   ,new Loot( typeof( CrestedBuckler), 0.412371f ) 
														   ,new Loot( typeof( DeflectingTower), 0.206186f ) 
														   ,new Loot( typeof( FineLongsword), 0.206186f ) 
														   ,new Loot( typeof( LaminatedScaleBelt), 0.206186f ) 
														   ,new Loot( typeof( LaminatedScaleShoulderpads), 0.412371f ) 
														   ,new Loot( typeof( LightPlateChestpiece), 0.412371f ) 
														   ,new Loot( typeof( LightPlatePants), 0.412371f ) 
														   ,new Loot( typeof( RecurveLongBow), 0.412371f ) 
														   ,new Loot( typeof( SmoothLeatherGloves), 0.206186f ) 
														   ,new Loot( typeof( SmoothLeatherHelmet), 0.206186f ) 
														   ,new Loot( typeof( SpikedDagger), 0.412371f ) 
														   ,new Loot( typeof( TaperedGreatsword), 0.206186f ) 
														   ,new Loot( typeof( TwillBelt), 0.412371f ) 
														   ,new Loot( typeof( TwillBracers), 0.206186f ) 
														   ,new Loot( typeof( TwillCloak), 0.206186f ) 
														   ,new Loot( typeof( TwillPants), 0.412371f ) 
														   ,new Loot( typeof( TwillShoulderpads), 0.206186f ) 

													   };

		public static Loot[] BraveWindfeather = new Loot[] {
														   };

		public static Loot[] BraveProudsnout = new Loot[] {new Loot( typeof( LinenCloth), 40.5405f ) 

														  };

		public static Loot[] BraveLightninghorn = new Loot[] {new Loot( typeof( LinenCloth), 51.8519f ) 

															 };

		public static Loot[] BraveIronhorn = new Loot[] {
														};

		public static Loot[] BraveRunningWolf = new Loot[] {new Loot( typeof( LinenCloth), 28f ) 
															   ,new Loot( typeof( CalicoGloves), 4f ) 
															   ,new Loot( typeof( CrudeBattleAxe), 4f ) 

														   };

		public static Loot[] BraveGreathoof = new Loot[] {new Loot( typeof( LinenCloth), 40.4762f ) 
															 ,new Loot( typeof( CalicoPants), 2.38095f ) 
															 ,new Loot( typeof( RoughWoodenStaff), 2.38095f ) 
															 ,new Loot( typeof( WarpedLeatherPants), 2.38095f ) 

														 };

		public static Loot[] BraveStrongbash = new Loot[] {new Loot( typeof( LinenCloth), 19.2308f ) 

														  };

		public static Loot[] BraveDawneagle = new Loot[] {new Loot( typeof( LinenCloth), 30.6452f ) 
															 ,new Loot( typeof( CalicoGloves), 1.6129f ) 
															 ,new Loot( typeof( FeebleShortbow), 1.6129f ) 
															 ,new Loot( typeof( RoughWoodenStaff), 1.6129f ) 
															 ,new Loot( typeof( WarpedLeatherBoots), 1.6129f ) 
															 ,new Loot( typeof( WarpedLeatherBracers), 1.6129f ) 
															 ,new Loot( typeof( WoodenShield), 1.6129f ) 
															 ,new Loot( typeof( WornMailBracers), 1.6129f ) 
															 ,new Loot( typeof( WornMailPants), 1.6129f ) 

														 };

		public static Loot[] BraveSwiftwind = new Loot[] {new Loot( typeof( LinenCloth), 19.3548f ) 
															 ,new Loot( typeof( RoughWoodenStaff), 6.45161f ) 
															 ,new Loot( typeof( WarpedLeatherGloves), 3.22581f ) 
															 ,new Loot( typeof( WoodenBuckler), 3.22581f ) 

														 };

		public static Loot[] BraveLeapingDeer = new Loot[] {new Loot( typeof( LinenCloth), 39.2857f ) 
															   ,new Loot( typeof( CalicoGloves), 1.78571f ) 
															   ,new Loot( typeof( CommonersSword), 1.78571f ) 
															   ,new Loot( typeof( RoughWoodenStaff), 1.78571f ) 
															   ,new Loot( typeof( WarpedLeatherGloves), 1.78571f ) 

														   };

		public static Loot[] BraveDarksky = new Loot[] {new Loot( typeof( LinenCloth), 27.027f ) 
														   ,new Loot( typeof( WornHatchet), 2.7027f ) 
														   ,new Loot( typeof( WornMailVest), 2.7027f ) 

													   };

		public static Loot[] BraveRockhorn = new Loot[] {new Loot( typeof( LinenCloth), 28.9855f ) 
															,new Loot( typeof( CalicoBracers), 1.44928f ) 
															,new Loot( typeof( CalicoPants), 1.44928f ) 
															,new Loot( typeof( CalicoShoes), 1.44928f ) 
															,new Loot( typeof( WornMailVest), 1.44928f ) 

														};

		public static Loot[] BraveWildrunner = new Loot[] {new Loot( typeof( LinenCloth), 42.8571f ) 

														  };

		public static Loot[] BraveRainchaser = new Loot[] {new Loot( typeof( LinenCloth), 28.9474f ) 
															  ,new Loot( typeof( FishermanKnife), 2.63158f ) 
															  ,new Loot( typeof( WornMailGloves), 2.63158f ) 

														  };

		public static Loot[] BraveCloudmane = new Loot[] {
														 };

		public static Loot[] CampMojacheBrave = new Loot[] {new Loot( typeof( Runecloth), 33.3811f ) 
															   ,new Loot( typeof( BulkyMaul), 0.286533f ) 
															   ,new Loot( typeof( CloutMace), 0.143266f ) 
															   ,new Loot( typeof( CrestedBuckler), 0.286533f ) 
															   ,new Loot( typeof( FineLongsword), 0.429799f ) 
															   ,new Loot( typeof( JaggedAxe), 0.143266f ) 
															   ,new Loot( typeof( LaminatedScaleBelt), 0.143266f ) 
															   ,new Loot( typeof( LaminatedScaleCloak), 0.143266f ) 
															   ,new Loot( typeof( LightPlateBoots), 0.143266f ) 
															   ,new Loot( typeof( LightPlateGloves), 0.143266f ) 
															   ,new Loot( typeof( SmoothCloak), 0.286533f ) 
															   ,new Loot( typeof( SmoothLeatherArmor), 0.859599f ) 
															   ,new Loot( typeof( SmoothLeatherBracers), 0.143266f ) 
															   ,new Loot( typeof( SmoothLeatherShoulderpads), 0.286533f ) 
															   ,new Loot( typeof( SpikedDagger), 0.286533f ) 
															   ,new Loot( typeof( StoutWarStaff), 0.286533f ) 
															   ,new Loot( typeof( TaperedGreatsword), 0.143266f ) 
															   ,new Loot( typeof( TwillBelt), 0.143266f ) 
															   ,new Loot( typeof( TwillBracers), 0.143266f ) 
															   ,new Loot( typeof( TwillCover), 0.143266f ) 
															   ,new Loot( typeof( TwillPants), 0.143266f ) 
															   ,new Loot( typeof( TwillVest), 0.143266f ) 

														   };

		public static Loot[] GhostWalkerBrave= new Loot[] {new Loot( typeof( MageweaveCloth), 34.6154f ) 
															  ,new Loot( typeof( BalancedLongBow), 0.384615f ) 
															  ,new Loot( typeof( CrochetBracers), 0.384615f ) 
															  ,new Loot( typeof( CrochetVest), 0.384615f ) 
															  ,new Loot( typeof( OverlinkedChainBelt), 0.384615f ) 
															  ,new Loot( typeof( OverlinkedChainCloak), 0.384615f ) 
															  ,new Loot( typeof( ThickLeatherBracers), 0.769231f ) 
															  ,new Loot( typeof( WhettedClaymore), 0.769231f ) 

														  };

		public static Loot[] FreewindBrave= new Loot[] {new Loot( typeof( MageweaveCloth), 22.4398f ) 
														   ,new Loot( typeof( SilkCloth), 7.89032f ) 
														   ,new Loot( typeof( BalancedLongBow), 0.0559597f ) 
														   ,new Loot( typeof( BlockingTarge), 0.0559597f ) 
														   ,new Loot( typeof( BluntingMace), 0.111919f ) 
														   ,new Loot( typeof( CrochetBoots), 0.111919f ) 
														   ,new Loot( typeof( CrochetCloak), 0.0559597f ) 
														   ,new Loot( typeof( CrochetGloves), 0.167879f ) 
														   ,new Loot( typeof( CrochetPants), 0.167879f ) 
														   ,new Loot( typeof( CrushingMaul), 0.0559597f ) 
														   ,new Loot( typeof( FinePointedDagger), 0.335758f ) 
														   ,new Loot( typeof( HeavyFlintAxe), 0.111919f ) 
														   ,new Loot( typeof( HeavyWarStaff), 0.0559597f ) 
														   ,new Loot( typeof( OverlinkedChainBelt), 0.111919f ) 
														   ,new Loot( typeof( OverlinkedChainBracers), 0.0559597f ) 
														   ,new Loot( typeof( OverlinkedChainCloak), 0.279799f ) 
														   ,new Loot( typeof( OverlinkedChainGloves), 0.0559597f ) 
														   ,new Loot( typeof( OverlinkedChainPants), 0.0559597f ) 
														   ,new Loot( typeof( OverlinkedChainShoulderpads), 0.0559597f ) 
														   ,new Loot( typeof( SentinelMusket), 0.111919f ) 
														   ,new Loot( typeof( SharpShortsword), 0.167879f ) 
														   ,new Loot( typeof( SplinteringBattleAxe), 0.167879f ) 
														   ,new Loot( typeof( ThickCloak), 0.111919f ) 
														   ,new Loot( typeof( ThickLeatherBelt), 0.0559597f ) 
														   ,new Loot( typeof( ThickLeatherBoots), 0.111919f ) 
														   ,new Loot( typeof( ThickLeatherHat), 0.167879f ) 
														   ,new Loot( typeof( ThickLeatherTunic), 0.0559597f ) 
														   ,new Loot( typeof( WhettedClaymore), 0.111919f ) 

													   };

		public static Loot[] BraveMoonhorn = new Loot[] {
														};

		public static Loot[] BloodvenomPostBrave = new Loot[] {new Loot( typeof( Runecloth), 25f ) 
																  ,new Loot( typeof( TaperedGreatsword), 1.78571f ) 

															  };

		/*			public static Loot[] TorturedSentinel = new Loot[] {
					};

					public static Loot[] TorturedSentinel = new Loot[] {
					};

					public static Loot[] TorturedSentinel = new Loot[] {
					};

					public static Loot[] TorturedSentinel = new Loot[] {
					};

					public static Loot[] TorturedSentinel = new Loot[] {
					};

					public static Loot[] TorturedSentinel = new Loot[] {
					};

					public static Loot[] TorturedSentinel = new Loot[] {
					};

					public static Loot[] TorturedSentinel = new Loot[] {
					};

					public static Loot[] TorturedSentinel = new Loot[] {
					};

					public static Loot[] TorturedSentinel = new Loot[] {
					};

					public static Loot[] TorturedSentinel = new Loot[] {
					};

					public static Loot[] TorturedSentinel = new Loot[] {
					};

					public static Loot[] TorturedSentinel = new Loot[] {
					};

					public static Loot[] TorturedSentinel = new Loot[] {
					};

					public static Loot[] TorturedSentinel = new Loot[] {
					};

					public static Loot[] TorturedSentinel = new Loot[] {
					};

					public static Loot[] TorturedSentinel = new Loot[] {
					};

					public static Loot[] TorturedSentinel = new Loot[] {
					};*/

	}
}