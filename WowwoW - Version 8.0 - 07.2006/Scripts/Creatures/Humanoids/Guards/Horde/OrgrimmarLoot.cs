using System;
using Server.Items;
using System.Collections;
using Server;


///////////////////////////////////////////
namespace Server
{
	public class OgrimmarGuardsDrops
	{
		public static Loot[] DenGrunt = new Loot[] {new Loot( typeof( Runecloth), 30.1205f ) 
													   ,new Loot( typeof( LaminatedScaleArmor), 1.20482f ) 
													   ,new Loot( typeof( LaminatedScaleGloves), 1.20482f ) 
													   ,new Loot( typeof( TwillCover), 1.20482f ) 

												   };		

		public static Loot[] StonardGrunt = new Loot[] {new Loot( typeof( LibramOfResilience), 0.316456f ) 
														   ,new Loot( typeof( Runecloth), 26.1076f ) 
														   ,new Loot( typeof( CloutMace), 0.158228f ) 
														   ,new Loot( typeof( DeflectingTower), 0.158228f ) 
														   ,new Loot( typeof( FineLongsword), 0.158228f ) 
														   ,new Loot( typeof( JaggedAxe), 0.158228f ) 
														   ,new Loot( typeof( LaminatedScaleBoots), 0.316456f ) 
														   ,new Loot( typeof( LaminatedScaleBracers), 0.316456f ) 
														   ,new Loot( typeof( LaminatedScalePants), 0.158228f ) 
														   ,new Loot( typeof( LightPlateGloves), 0.158228f ) 
														   ,new Loot( typeof( LightPlateHelmet), 0.158228f ) 
														   ,new Loot( typeof( LightPlatePants), 0.158228f ) 
														   ,new Loot( typeof( SmoothLeatherBoots), 0.158228f ) 
														   ,new Loot( typeof( SmoothLeatherGloves), 0.158228f ) 
														   ,new Loot( typeof( TwillCover), 0.474684f ) 
														   ,new Loot( typeof( TwillShoulderpads), 0.316456f ) 

													   };		

		public static Loot[] GromgolGrunt = new Loot[] {new Loot( typeof( LibramOfVoracity), 0.0682594f ) 
														   ,new Loot( typeof( Runecloth), 22.1843f ) 
														   ,new Loot( typeof( BalancedWarAxe), 0.136519f ) 
														   ,new Loot( typeof( BulkyMaul), 0.204778f ) 
														   ,new Loot( typeof( CloutMace), 0.136519f ) 
														   ,new Loot( typeof( FineLongsword), 0.341297f ) 
														   ,new Loot( typeof( LaminatedScaleBelt), 0.136519f ) 
														   ,new Loot( typeof( LaminatedScaleBracers), 0.0682594f ) 
														   ,new Loot( typeof( LaminatedScaleCloak), 0.0682594f ) 
														   ,new Loot( typeof( LaminatedScalePants), 0.0682594f ) 
														   ,new Loot( typeof( LightPlateBoots), 0.0682594f ) 
														   ,new Loot( typeof( LightPlateShoulderpads), 0.0682594f ) 
														   ,new Loot( typeof( PrimedMusket), 0.204778f ) 
														   ,new Loot( typeof( RecurveLongBow), 0.136519f ) 
														   ,new Loot( typeof( SmoothLeatherBelt), 0.136519f ) 
														   ,new Loot( typeof( SmoothLeatherBoots), 0.136519f ) 
														   ,new Loot( typeof( SmoothLeatherHelmet), 0.0682594f ) 
														   ,new Loot( typeof( SmoothLeatherPants), 0.136519f ) 
														   ,new Loot( typeof( SmoothLeatherShoulderpads), 0.0682594f ) 
														   ,new Loot( typeof( StoutWarStaff), 0.0682594f ) 
														   ,new Loot( typeof( TaperedGreatsword), 0.0682594f ) 
														   ,new Loot( typeof( TwillBracers), 0.273038f ) 
														   ,new Loot( typeof( TwillCover), 0.136519f ) 
														   ,new Loot( typeof( TwillGloves), 0.0682594f ) 
														   ,new Loot( typeof( TwillShoulderpads), 0.136519f ) 

													   };		

		public static Loot[] OrgrimmarGrunt = new Loot[] {new Loot( typeof( Runecloth), 32.7392f ) 
															 ,new Loot( typeof( BalancedWarAxe), 0.0938086f ) 
															 ,new Loot( typeof( CloutMace), 0.0938086f ) 
															 ,new Loot( typeof( FineLongsword), 0.281426f ) 
															 ,new Loot( typeof( JaggedAxe), 0.187617f ) 
															 ,new Loot( typeof( LaminatedScaleArmor), 0.187617f ) 
															 ,new Loot( typeof( LaminatedScaleBelt), 0.187617f ) 
															 ,new Loot( typeof( LaminatedScaleBoots), 0.0938086f ) 
															 ,new Loot( typeof( LaminatedScaleCirclet), 0.187617f ) 
															 ,new Loot( typeof( LaminatedScaleGloves), 0.0938086f ) 
															 ,new Loot( typeof( LaminatedScalePants), 0.0938086f ) 
															 ,new Loot( typeof( LaminatedScaleShoulderpads), 0.562852f ) 
															 ,new Loot( typeof( LightPlateBracers), 0.0938086f ) 
															 ,new Loot( typeof( PrimedMusket), 0.187617f ) 
															 ,new Loot( typeof( RecurveLongBow), 0.187617f ) 
															 ,new Loot( typeof( SmoothLeatherArmor), 0.469043f ) 
															 ,new Loot( typeof( SmoothLeatherBoots), 0.0938086f ) 
															 ,new Loot( typeof( SmoothLeatherGloves), 0.0938086f ) 
															 ,new Loot( typeof( SmoothLeatherPants), 0.0938086f ) 
															 ,new Loot( typeof( SmoothLeatherShoulderpads), 0.0938086f ) 
															 ,new Loot( typeof( StoutWarStaff), 0.375235f ) 
															 ,new Loot( typeof( TwillBracers), 0.375235f ) 
															 ,new Loot( typeof( TwillCloak), 0.375235f ) 

														 };		

		public static Loot[] GruntZuul = new Loot[] {new Loot( typeof( Runecloth), 25f ) 

													};		

		public static Loot[] GruntTharlak = new Loot[] {
													   };		

		public static Loot[] GruntKomak = new Loot[] {
													 };		

		public static Loot[] GruntMojka = new Loot[] {
													 };		

		public static Loot[] RazorHillGrunt = new Loot[] {new Loot( typeof( SilkCloth), 21.3645f ) 
															 ,new Loot( typeof( WoolCloth), 10.0539f ) 
															 ,new Loot( typeof( CrossStitchedCloak), 0.179533f ) 
															 ,new Loot( typeof( CrossStitchedPants), 0.179533f ) 
															 ,new Loot( typeof( CrossStitchedSandals), 0.179533f ) 
															 ,new Loot( typeof( DeftStiletto), 0.179533f ) 
															 ,new Loot( typeof( DoubleMailShoulderpads), 0.179533f ) 
															 ,new Loot( typeof( InterlacedBracers), 0.179533f ) 
															 ,new Loot( typeof( KeenAxe), 0.179533f ) 
															 ,new Loot( typeof( ToughLeatherArmor), 0.179533f ) 
															 ,new Loot( typeof( ToughLeatherBracers), 0.179533f ) 

														 };		

		public static Loot[] StonetalonGrunt = new Loot[] {new Loot( typeof( MageweaveCloth), 4.27404f ) 
															  ,new Loot( typeof( MithrilOre), 0.502828f ) 
															  ,new Loot( typeof( SilkCloth), 24.3243f ) 
															  ,new Loot( typeof( SolidStone), 0.314268f ) 
															  ,new Loot( typeof( BroadClaymore), 0.188561f ) 
															  ,new Loot( typeof( DoubleMailCoif), 0.125707f ) 
															  ,new Loot( typeof( DoubleMailGloves), 0.0628536f ) 
															  ,new Loot( typeof( DoubleMailShoulderpads), 0.0628536f ) 
															  ,new Loot( typeof( DoubleStitchedCloak), 0.188561f ) 
															  ,new Loot( typeof( HardenedLeatherBelt), 0.0628536f ) 
															  ,new Loot( typeof( HardenedLeatherPants), 0.0628536f ) 
															  ,new Loot( typeof( HardenedLeatherTunic), 0.0628536f ) 
															  ,new Loot( typeof( HeftyWarAxe), 0.125707f ) 
															  ,new Loot( typeof( InterlacedBelt), 0.0628536f ) 
															  ,new Loot( typeof( InterlacedBoots), 0.125707f ) 
															  ,new Loot( typeof( InterlacedBracers), 0.125707f ) 
															  ,new Loot( typeof( InterlacedCloak), 0.188561f ) 
															  ,new Loot( typeof( InterlacedCowl), 0.125707f ) 
															  ,new Loot( typeof( InterlacedPants), 0.0628536f ) 
															  ,new Loot( typeof( InterlacedShoulderpads), 0.0628536f ) 
															  ,new Loot( typeof( InterlacedVest), 0.125707f ) 
															  ,new Loot( typeof( KeenAxe), 0.188561f ) 
															  ,new Loot( typeof( LargeWarClub), 0.0628536f ) 
															  ,new Loot( typeof( LongBarreledMusket), 0.125707f ) 
															  ,new Loot( typeof( ReinforcedBuckler), 0.377121f ) 
															  ,new Loot( typeof( StoneClub), 0.0628536f ) 
															  ,new Loot( typeof( TautCompoundBow), 0.0628536f ) 

														  };		

		public static Loot[] KargathGrunt = new Loot[] {new Loot( typeof( Runecloth), 20.2381f ) 
														   ,new Loot( typeof( BalancedWarAxe), 0.297619f ) 
														   ,new Loot( typeof( FineLongsword), 1.19048f ) 
														   ,new Loot( typeof( JaggedAxe), 0.297619f ) 
														   ,new Loot( typeof( LaminatedScaleGloves), 0.595238f ) 
														   ,new Loot( typeof( LightPlateBoots), 0.595238f ) 
														   ,new Loot( typeof( RecurveLongBow), 0.297619f ) 
														   ,new Loot( typeof( SmoothLeatherArmor), 0.297619f ) 
														   ,new Loot( typeof( SmoothLeatherShoulderpads), 0.297619f ) 
														   ,new Loot( typeof( TwillBelt), 0.297619f ) 
														   ,new Loot( typeof( TwillCover), 0.595238f ) 
														   ,new Loot( typeof( TwillVest), 0.297619f ) 

													   };		

		public static Loot[] GruntKorja = new Loot[] {
													 };		

		/*			public static Loot[] DeathguardSimmer = new Loot[] {
					};		

					public static Loot[] DeathguardBurgess = new Loot[] {
					};		

					public static Loot[] DeathguardSimmer = new Loot[] {
					};		

					public static Loot[] DeathguardBurgess = new Loot[] {
					};		

					public static Loot[] DeathguardSimmer = new Loot[] {
					};		

					public static Loot[] DeathguardBurgess = new Loot[] {
					};	*/	

	}
}
