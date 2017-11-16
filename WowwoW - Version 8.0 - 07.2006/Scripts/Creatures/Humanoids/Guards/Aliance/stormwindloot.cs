using System;
using Server.Items;
using System.Collections;
using Server;


///////////////////////////////////////////
namespace Server
{
	public class StormwindGuardsDrops
	{
		public static Loot[] StormwindCityGuard = new Loot[] {new Loot( typeof( HomemadeCherryPie ), 1.65f )
																 , new Loot( typeof( Runecloth ), 68.65f )
																 , new Loot( typeof( StrangeDust ), 6.65f )
																 , new Loot( typeof( CanvasCloak ), 1.65f )
																 , new Loot( typeof( LaminatedScaleGloves ), 1.65f )			
															 };
		
		public static Loot[] MarshalMcBride = new Loot[] {
														 };		

		public static Loot[] GuardThomas = new Loot[] {
													  };		
		
		public static Loot[] GuardParker = new Loot[] {
													  };		
		
		public static Loot[] GuardHiett = new Loot[] {
													 };		

		public static Loot[] GuardClarke = new Loot[] {
													  };		
		
		public static Loot[] GuardBerton = new Loot[] {
													  };		
		
		public static Loot[] GuardHowe = new Loot[] {
													};		
		
		public static Loot[] GuardAshlock = new Loot[] {new Loot( typeof( SilkCloth), 29.4118f ) 
														   ,new Loot( typeof( WoolCloth), 2.94118f ) 
													   };		
		
		public static Loot[] GuardPearce = new Loot[] {new Loot( typeof( SilkCloth), 29.4118f ) 
													  };		
		
		public static Loot[] GuardAdams = new Loot[] {new Loot( typeof( SilkCloth), 29.4118f ) 
														 ,new Loot( typeof( WoolCloth), 2.94118f ) 
													 };		
		
		public static Loot[] StormwindGuard = new Loot[] {new Loot( typeof( LinenCloth), 5f ) 
															 ,new Loot( typeof( SilkCloth), 3.33333f ) 
															 ,new Loot( typeof( WoolCloth), 25.2778f ) 
															 ,new Loot( typeof( BrocadeCloak), 0.277778f ) 
															 ,new Loot( typeof( BrocadeShoes), 0.277778f ) 
															 ,new Loot( typeof( GougingPick), 0.555556f ) 
															 ,new Loot( typeof( HuntingKnife), 0.833333f ) 
															 ,new Loot( typeof( LinkedChainBracers), 0.833333f ) 
															 ,new Loot( typeof( RawhideBelt), 0.277778f ) 
															 ,new Loot( typeof( RawhideBracers), 0.277778f ) 
															 ,new Loot( typeof( RawhideCloak), 0.277778f ) 
															 ,new Loot( typeof( RawhideGloves), 0.277778f ) 
															 ,new Loot( typeof( RawhideShoulderpads), 0.277778f ) 
															 ,new Loot( typeof( ShinyWarAxe), 0.555556f ) 
															 ,new Loot( typeof( StandardClaymore), 1.11111f ) 
														 };	
		
		public static Loot[] NorthshireGuard = new Loot[] {new Loot( typeof( MageweaveCloth), 29.0323f ) 
															  ,new Loot( typeof( SmoothLeatherBelt), 3.22581f ) 
														  };		

		public static Loot[] StormwindRoyalGuard = new Loot[] {new Loot( typeof( Runecloth), 42.1053f ) 
																  ,new Loot( typeof( StoutWarStaff), 5.26316f ) 
															  };		

		public static Loot[] SouthshoreGuard = new Loot[] {new Loot( typeof( MageweaveCloth), 31.0255f ) 
															  ,new Loot( typeof( BalancedLongBow), 0.143697f ) 
															  ,new Loot( typeof( BlockingTarge), 0.0653168f ) 
															  ,new Loot( typeof( BluntingMace), 0.11757f ) 
															  ,new Loot( typeof( CrochetBelt), 0.0914435f ) 
															  ,new Loot( typeof( CrochetBoots), 0.209014f ) 
															  ,new Loot( typeof( CrochetBracers), 0.0783801f ) 
															  ,new Loot( typeof( CrochetCloak), 0.0914435f ) 
															  ,new Loot( typeof( CrochetGloves), 0.0783801f ) 
															  ,new Loot( typeof( CrochetHat), 0.0653168f ) 
															  ,new Loot( typeof( CrochetPants), 0.0914435f ) 
															  ,new Loot( typeof( CrochetShoulderpads), 0.104507f ) 
															  ,new Loot( typeof( CrochetVest), 0.0914435f ) 
															  ,new Loot( typeof( CrushingMaul), 0.0522534f ) 
															  ,new Loot( typeof( FinePointedDagger), 0.143697f ) 
															  ,new Loot( typeof( HeavyFlintAxe), 0.104507f ) 
															  ,new Loot( typeof( HeavyWarStaff), 0.0783801f ) 
															  ,new Loot( typeof( OverlinkedChainArmor), 0.0653168f ) 
															  ,new Loot( typeof( OverlinkedChainBelt), 0.0783801f ) 
															  ,new Loot( typeof( OverlinkedChainBoots), 0.0783801f ) 
															  ,new Loot( typeof( OverlinkedChainBracers), 0.0391901f ) 
															  ,new Loot( typeof( OverlinkedChainCloak), 0.104507f ) 
															  ,new Loot( typeof( OverlinkedChainGloves), 0.0522534f ) 
															  ,new Loot( typeof( OverlinkedChainPants), 0.0261267f ) 
															  ,new Loot( typeof( OverlinkedChainShoulderpads), 0.0391901f ) 
															  ,new Loot( typeof( OverlinkedCoif), 0.0391901f ) 
															  ,new Loot( typeof( ProtectivePavise), 0.104507f ) 
															  ,new Loot( typeof( SentinelMusket), 0.182887f ) 
															  ,new Loot( typeof( SharpShortsword), 0.19595f ) 
															  ,new Loot( typeof( SplinteringBattleAxe), 0.11757f ) 
															  ,new Loot( typeof( ThickCloak), 0.0653168f ) 
															  ,new Loot( typeof( ThickLeatherBelt), 0.0261267f ) 
															  ,new Loot( typeof( ThickLeatherBoots), 0.0653168f ) 
															  ,new Loot( typeof( ThickLeatherBracers), 0.0261267f ) 
															  ,new Loot( typeof( ThickLeatherGloves), 0.0653168f ) 
															  ,new Loot( typeof( ThickLeatherHat), 0.0653168f ) 
															  ,new Loot( typeof( ThickLeatherPants), 0.0391901f ) 
															  ,new Loot( typeof( ThickLeatherShoulderpads), 0.0130634f ) 
															  ,new Loot( typeof( ThickLeatherTunic), 0.0783801f ) 
															  ,new Loot( typeof( WhettedClaymore), 0.209014f ) 
														  };		

		public static Loot[] MajorSamuelson = new Loot[] {
														 };		

		public static Loot[] GuardLasiter = new Loot[] {
													   };		

		public static Loot[] TheramoreGuard = new Loot[] {new Loot( typeof( Runecloth), 21.9653f ) 
															 ,new Loot( typeof( CloutMace), 0.867052f ) 
															 ,new Loot( typeof( DeflectingTower), 0.289017f ) 
															 ,new Loot( typeof( LaminatedScaleArmor), 0.289017f ) 
															 ,new Loot( typeof( LaminatedScaleBelt), 0.289017f ) 
															 ,new Loot( typeof( LaminatedScaleGloves), 0.289017f ) 
															 ,new Loot( typeof( SmoothLeatherArmor), 0.289017f ) 
															 ,new Loot( typeof( SpikedDagger), 0.289017f ) 
															 ,new Loot( typeof( TwillBelt), 0.578035f ) 
															 ,new Loot( typeof( TwillPants), 0.289017f ) 
														 };		

		public static Loot[] StockadeGuard = new Loot[] {new Loot( typeof( SilkCloth), 12.5f ) 
														};		

		public static Loot[] InjuredStockadeGuard = new Loot[] {
															   };		

		public static Loot[] SentryPointGuard = new Loot[] {new Loot( typeof( ViscousHammer), 0.239808f ) 
															   ,new Loot( typeof( MageEyeBlunderbuss), 0.479616f ) 
															   ,new Loot( typeof( Citrine), 0.239808f ) 
															   ,new Loot( typeof( GlimmeringFlamberge), 0.239808f ) 
															   ,new Loot( typeof( PathfinderVest), 0.239808f ) 
															   ,new Loot( typeof( PatternGreenSilkArmor), 0.239808f ) 
															   ,new Loot( typeof( PlansGoldenIronDestroyer), 0.239808f ) 
															   ,new Loot( typeof( PlansIronCounterweight), 0.239808f ) 
															   ,new Loot( typeof( SplittingHatchet), 0.239808f ) 
															   ,new Loot( typeof( ThickScaleLegguards), 0.239808f ) 
															   ,new Loot( typeof( ThistlefurBelt), 0.239808f ) 
															   ,new Loot( typeof( TundraRing), 0.239808f ) 
															   ,new Loot( typeof( WickedChainHelmet), 0.719424f ) 
															   ,new Loot( typeof( GreaterHealingPotion), 0.959233f ) 
															   ,new Loot( typeof( MageweaveCloth), 0.959233f ) 
															   ,new Loot( typeof( ManaPotion), 0.719424f ) 
															   ,new Loot( typeof( RecipeElixirOfLesserAgility), 0.239808f ) 
															   ,new Loot( typeof( ScrollOfAgilityII), 0.239808f ) 
															   ,new Loot( typeof( ScrollOfIntellectII), 1.19904f ) 
															   ,new Loot( typeof( ScrollOfStaminaII), 0.239808f ) 
															   ,new Loot( typeof( ScrollOfStrengthII), 0.479616f ) 
															   ,new Loot( typeof( SilkCloth), 32.1343f ) 
															   ,new Loot( typeof( StormwindBrie), 5.27578f ) 
															   ,new Loot( typeof( SweetNectar), 1.91847f ) 
															   ,new Loot( typeof( WoolCloth), 2.8777f ) 
															   ,new Loot( typeof( DoubleMailBelt), 0.239808f ) 
															   ,new Loot( typeof( DoubleMailBracers), 0.719424f ) 
															   ,new Loot( typeof( DoubleMailGloves), 0.479616f ) 
															   ,new Loot( typeof( HardenedLeatherBoots), 0.239808f ) 
															   ,new Loot( typeof( HardenedLeatherPants), 0.479616f ) 
															   ,new Loot( typeof( HardenedLeatherShoulderpads), 0.239808f ) 
															   ,new Loot( typeof( HardenedLeatherTunic), 0.239808f ) 
															   ,new Loot( typeof( InterlacedShoulderpads), 0.239808f ) 
															   ,new Loot( typeof( LargeWarClub), 0.239808f ) 
															   ,new Loot( typeof( LightScimitar), 0.479616f ) 
															   ,new Loot( typeof( MetalStave), 0.239808f ) 
															   ,new Loot( typeof( ReflectiveHeater), 0.479616f ) 
															   ,new Loot( typeof( ShinyDirk), 0.239808f ) 
															   ,new Loot( typeof( StoneClub), 0.239808f ) 
														   };		

		public static Loot[] SentryPointCaptain = new Loot[] {new Loot( typeof( EnduringBracers), 2.94118f ) 
																 ,new Loot( typeof( SilkCloth), 23.5294f ) 
																 ,new Loot( typeof( StormwindBrie), 11.7647f ) 
																 ,new Loot( typeof( SweetNectar), 2.94118f ) 
																 ,new Loot( typeof( TautCompoundBow), 2.94118f ) 
															 };		

		public static Loot[] CaptainAndrews = new Loot[] {
														 };		

		public static Loot[] CaptainThomas = new Loot[] {
														};		

		public static Loot[] NijelsPointGuard = new Loot[] {new Loot( typeof( MageweaveCloth), 22.0624f ) 
															   ,new Loot( typeof( SilkCloth), 8.15348f ) 
															   ,new Loot( typeof( BalancedLongBow), 0.479616f ) 
															   ,new Loot( typeof( CrochetBoots), 0.239808f ) 
															   ,new Loot( typeof( CrochetVest), 0.479616f ) 
															   ,new Loot( typeof( CrushingMaul), 0.239808f ) 
															   ,new Loot( typeof( HeavyFlintAxe), 0.479616f ) 
															   ,new Loot( typeof( OverlinkedChainBoots), 0.239808f ) 
															   ,new Loot( typeof( OverlinkedChainBracers), 0.239808f ) 
															   ,new Loot( typeof( SentinelMusket), 0.479616f ) 
															   ,new Loot( typeof( ThickCloak), 0.239808f ) 
															   ,new Loot( typeof( ThickLeatherTunic), 0.239808f ) 
															   ,new Loot( typeof( WhettedClaymore), 0.239808f ) 
														   };		

		public static Loot[] LakeshireGuard = new Loot[] {new Loot( typeof( MageweaveCloth), 0.661813f ) 
															 ,new Loot( typeof( SilkCloth), 21.4428f ) 
															 ,new Loot( typeof( WoolCloth), 4.76506f ) 
															 ,new Loot( typeof( BroadClaymore), 0.198544f ) 
															 ,new Loot( typeof( DoubleMailBelt), 0.0661813f ) 
															 ,new Loot( typeof( DoubleMailBoots), 0.132363f ) 
															 ,new Loot( typeof( DoubleMailPants), 0.132363f ) 
															 ,new Loot( typeof( DoubleMailShoulderpads), 0.0661813f ) 
															 ,new Loot( typeof( DoubleStitchedCloak), 0.198544f ) 
															 ,new Loot( typeof( HardenedCloak), 0.132363f ) 
															 ,new Loot( typeof( HardenedLeatherBelt), 0.264725f ) 
															 ,new Loot( typeof( HardenedLeatherGloves), 0.0661813f ) 
															 ,new Loot( typeof( HardenedLeatherShoulderpads), 0.132363f ) 
															 ,new Loot( typeof( InterlacedBelt), 0.198544f ) 
															 ,new Loot( typeof( InterlacedBracers), 0.0661813f ) 
															 ,new Loot( typeof( InterlacedShoulderpads), 0.198544f ) 
															 ,new Loot( typeof( KeenAxe), 0.198544f ) 
															 ,new Loot( typeof( LargeWarClub), 0.0661813f ) 
															 ,new Loot( typeof( LongBarreledMusket), 0.132363f ) 
															 ,new Loot( typeof( MetalStave), 0.198544f ) 
															 ,new Loot( typeof( ReflectiveHeater), 0.0661813f ) 
															 ,new Loot( typeof( ShinyDirk), 0.198544f ) 
															 ,new Loot( typeof( StoneClub), 0.132363f ) 
															 ,new Loot( typeof( TautCompoundBow), 0.132363f ) 
														 };		

		public static Loot[] GuardRoberts = new Loot[] {
													   };		

		public static Loot[] DeputyWillem = new Loot[] {
													   };		

		public static Loot[] MarshalDughan = new Loot[] {
														};		
		
		public static Loot[] MarshalHaggard = new Loot[] {
														 };		
		
		public static Loot[] MarshalMarris = new Loot[] {
														};		

		public static Loot[] MarshalRedpath = new Loot[] {
														 };		
		
		public static Loot[] GeneralMarcusJonathan = new Loot[] {new Loot( typeof( AlteracSwiss), 7.69231f ) 
																	,new Loot( typeof( Runecloth), 23.0769f ) 
																	,new Loot( typeof( SmoothLeatherBracers), 23.0769f ) 
																};		
			
		public static Loot[] MajorMattingly = new Loot[] {
														 };		
		
		public static Loot[] StormwindCityPatroller = new Loot[] {new Loot( typeof( Runecloth), 14.2857f ) 
																	 ,new Loot( typeof( TwillCloak), 4.7619f ) 
																 };	
		
		public static Loot[] MelrisMalagan = new Loot[] {
														};		

		public static Loot[] OfficerBrady = new Loot[] {
													   };
			
		public static Loot[] OfficerPomeroy = new Loot[] {
														 };		

		public static Loot[] OfficerJaxon = new Loot[] {
													   };
		
		public static Loot[] LieutenantDoren= new Loot[] {
														 };		

		public static Loot[] DeputyRainer = new Loot[] {
													   };		

		/*		public static Loot[] OfficerBrady = new Loot[] {
				};
		*/
	}	
}