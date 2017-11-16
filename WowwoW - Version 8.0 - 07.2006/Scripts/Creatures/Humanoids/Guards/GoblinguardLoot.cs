using System;
using Server.Items;
using System.Collections;
using Server;


///////////////////////////////////////////
namespace Server
{
	public class GoblinGuardDrops
	{
		public static Loot[] RotHideBruiser = new Loot[] {new Loot( typeof( BruiserClub), 19.084f ) 
															 ,new Loot( typeof( CoralBand), 0.763359f ) 
															 ,new Loot( typeof( RuffianBelt), 71.7557f ) 
															 ,new Loot( typeof( ATalkingHead), 1.52672f ) 
															 ,new Loot( typeof( IceColdMilk), 2.29008f ) 
															 ,new Loot( typeof( LinenCloth), 12.9771f ) 
															 ,new Loot( typeof( MinorManaPotion), 0.763359f ) 
															 ,new Loot( typeof( RedSpeckledMushroom), 2.29008f ) 
															 ,new Loot( typeof( RotHideIchor), 4.58015f ) 
															 ,new Loot( typeof( WoolCloth), 17.5573f ) 
															 ,new Loot( typeof( GougingPick), 0.763359f ) 
															 ,new Loot( typeof( LinkedChainShoulderpads), 0.763359f ) 
															 ,new Loot( typeof( ShoddyBlunderbuss), 1.52672f ) 

														 };

		public static Loot[] BurningBladeBruiser = new Loot[] {new Loot( typeof( AncestralOrb), 0.055639f ) 
																  ,new Loot( typeof( BeadedBritches), 0.0834585f ) 
																  ,new Loot( typeof( BeadedOrb), 0.0778946f ) 
																  ,new Loot( typeof( BeadedRobe), 0.0723307f ) 
																  ,new Loot( typeof( BeadedWraps), 0.0445112f ) 
																  ,new Loot( typeof( CarvingKnife), 0.10015f ) 
																  ,new Loot( typeof( ChargersArmor), 0.0834585f ) 
																  ,new Loot( typeof( ChargersPants), 0.105714f ) 
																  ,new Loot( typeof( CompactShotgun), 0.0500751f ) 
																  ,new Loot( typeof( FireWand), 0.0667668f ) 
																  ,new Loot( typeof( HuntingBow), 0.111278f ) 
																  ,new Loot( typeof( Malachite), 0.233684f ) 
																  ,new Loot( typeof( NotchedShortsword), 0.12797f ) 
																  ,new Loot( typeof( PatternRedLinenRobe), 0.10015f ) 
																  ,new Loot( typeof( PlansCopperChainVest), 0.122406f ) 
																  ,new Loot( typeof( PriestsMace), 0.0723307f ) 
																  ,new Loot( typeof( PrimalLeggings), 0.139098f ) 
																  ,new Loot( typeof( PrimalWraps), 0.0945863f ) 
																  ,new Loot( typeof( RecipeElixirOfGiantGrowth), 0.0667668f ) 
																  ,new Loot( typeof( ScalpingTomahawk), 0.105714f ) 
																  ,new Loot( typeof( SeveringAxe), 0.189173f ) 
																  ,new Loot( typeof( Shadowgem), 0.0723307f ) 
																  ,new Loot( typeof( ShortBastardSword), 0.0612029f ) 
																  ,new Loot( typeof( SpikedClub), 0.0500751f ) 
																  ,new Loot( typeof( SturdyQuarterstaff), 0.0445112f ) 
																  ,new Loot( typeof( Tigerseye), 0.189173f ) 
																  ,new Loot( typeof( TrainingSword), 0.194737f ) 
																  ,new Loot( typeof( TribalPants), 0.0500751f ) 
																  ,new Loot( typeof( WarTornShield), 0.0612029f ) 
																  ,new Loot( typeof( AboriginalCape), 0.0333834f ) 
																  ,new Loot( typeof( AncestralBelt), 0.0612029f ) 
																  ,new Loot( typeof( AncestralBoots), 0.0945863f ) 
																  ,new Loot( typeof( AncestralCloak), 0.105714f ) 
																  ,new Loot( typeof( AncestralGloves), 0.0890224f ) 
																  ,new Loot( typeof( BarbaricClothBracers), 0.0500751f ) 
																  ,new Loot( typeof( BattleChainBoots), 0.0612029f ) 
																  ,new Loot( typeof( BattleChainBracers), 0.0612029f ) 
																  ,new Loot( typeof( BattleChainCloak), 0.0778946f ) 
																  ,new Loot( typeof( BattleChainGirdle), 0.144661f ) 
																  ,new Loot( typeof( BattleChainGloves), 0.105714f ) 
																  ,new Loot( typeof( BeadedCord), 0.0612029f ) 
																  ,new Loot( typeof( BeadedGloves), 0.105714f ) 
																  ,new Loot( typeof( BeadedSandals), 0.122406f ) 
																  ,new Loot( typeof( BillyClub), 0.0445112f ) 
																  ,new Loot( typeof( BrackwaterGirdle), 0.0389473f ) 
																  ,new Loot( typeof( CeremonialCloak), 0.0445112f ) 
																  ,new Loot( typeof( CeremonialLeatherBracers), 0.0500751f ) 
																  ,new Loot( typeof( ChargersBelt), 0.0500751f ) 
																  ,new Loot( typeof( ChargersBoots), 0.12797f ) 
																  ,new Loot( typeof( ChargersHandwraps), 0.0667668f ) 
																  ,new Loot( typeof( CopperOre), 0.0333834f ) 
																  ,new Loot( typeof( GrizzlyBelt), 0.105714f ) 
																  ,new Loot( typeof( GrizzlyBracers), 0.0500751f ) 
																  ,new Loot( typeof( GrizzlyCape), 0.144661f ) 
																  ,new Loot( typeof( GrizzlySlippers), 0.0333834f ) 
																  ,new Loot( typeof( HaunchOfMeat), 4.87398f ) 
																  ,new Loot( typeof( HuntingRifle), 0.0723307f ) 
																  ,new Loot( typeof( IceColdMilk), 2.35909f ) 
																  ,new Loot( typeof( LesserHealingPotion), 1.22406f ) 
																  ,new Loot( typeof( LinenCloth), 37.7845f ) 
																  ,new Loot( typeof( MinorManaPotion), 0.639849f ) 
																  ,new Loot( typeof( NativeBands), 0.155789f ) 
																  ,new Loot( typeof( NativeCloak), 0.0890224f ) 
																  ,new Loot( typeof( NativeHandwraps), 0.0445112f ) 
																  ,new Loot( typeof( NativeSandals), 0.0667668f ) 
																  ,new Loot( typeof( NativeSash), 0.0723307f ) 
																  ,new Loot( typeof( PrimalBands), 0.055639f ) 
																  ,new Loot( typeof( PrimalBoots), 0.0778946f ) 
																  ,new Loot( typeof( PrimalMitts), 0.0834585f ) 
																  ,new Loot( typeof( ScrollOfIntellect), 0.144661f ) 
																  ,new Loot( typeof( ScrollOfProtection), 0.283759f ) 
																  ,new Loot( typeof( ScrollOfSpirit), 0.261503f ) 
																  ,new Loot( typeof( ScrollOfStamina), 0.222556f ) 
																  ,new Loot( typeof( TribalBelt), 0.12797f ) 
																  ,new Loot( typeof( TribalBoots), 0.0500751f ) 
																  ,new Loot( typeof( TribalBracers), 0.116842f ) 
																  ,new Loot( typeof( TribalBuckler), 0.0612029f ) 
																  ,new Loot( typeof( TribalCloak), 0.055639f ) 
																  ,new Loot( typeof( TribalGloves), 0.0500751f ) 
																  ,new Loot( typeof( WarTornBands), 0.0945863f ) 
																  ,new Loot( typeof( WarTornCape), 0.0945863f ) 
																  ,new Loot( typeof( WarTornGirdle), 0.0333834f ) 
																  ,new Loot( typeof( WarTornGreaves), 0.0333834f ) 
																  ,new Loot( typeof( BeatenBattleAxe), 0.22812f ) 
																  ,new Loot( typeof( CalicoBelt), 0.144661f ) 
																  ,new Loot( typeof( CalicoBracers), 0.189173f ) 
																  ,new Loot( typeof( CalicoCloak), 0.189173f ) 
																  ,new Loot( typeof( CalicoGloves), 0.122406f ) 
																  ,new Loot( typeof( CalicoPants), 0.172481f ) 
																  ,new Loot( typeof( CalicoShoes), 0.105714f ) 
																  ,new Loot( typeof( CalicoTunic), 0.161353f ) 
																  ,new Loot( typeof( CarpentersMallet), 0.289323f ) 
																  ,new Loot( typeof( CheapBlunderbuss), 0.22812f ) 
																  ,new Loot( typeof( CommonersSword), 0.189173f ) 
																  ,new Loot( typeof( CrackedBuckler), 0.12797f ) 
																  ,new Loot( typeof( CrackedShortbow), 0.255939f ) 
																  ,new Loot( typeof( CrackedSledge), 0.222556f ) 
																  ,new Loot( typeof( CrudeBastardSword), 0.378345f ) 
																  ,new Loot( typeof( CrudeBattleAxe), 0.216992f ) 
																  ,new Loot( typeof( FeebleShortbow), 0.194737f ) 
																  ,new Loot( typeof( FeebleSword), 0.233684f ) 
																  ,new Loot( typeof( FishermanKnife), 0.189173f ) 
																  ,new Loot( typeof( HeavyHammer), 0.189173f ) 
																  ,new Loot( typeof( LooseChainBelt), 0.144661f ) 
																  ,new Loot( typeof( LooseChainBoots), 0.139098f ) 
																  ,new Loot( typeof( LooseChainBracers), 0.172481f ) 
																  ,new Loot( typeof( LooseChainCloak), 0.161353f ) 
																  ,new Loot( typeof( LooseChainGloves), 0.144661f ) 
																  ,new Loot( typeof( LooseChainPants), 0.172481f ) 
																  ,new Loot( typeof( LooseChainVest), 0.161353f ) 
																  ,new Loot( typeof( OldGreatsword), 0.161353f ) 
																  ,new Loot( typeof( PatchworkArmor), 0.2003f ) 
																  ,new Loot( typeof( PatchworkBelt), 0.244812f ) 
																  ,new Loot( typeof( PatchworkBracers), 0.194737f ) 
																  ,new Loot( typeof( PatchworkCloak), 0.183609f ) 
																  ,new Loot( typeof( PatchworkGloves), 0.239248f ) 
																  ,new Loot( typeof( PatchworkPants), 0.255939f ) 
																  ,new Loot( typeof( PatchworkShoes), 0.222556f ) 
																  ,new Loot( typeof( RoughWoodenStaff), 0.111278f ) 
																  ,new Loot( typeof( RustCoveredBlunderbuss), 0.278195f ) 
																  ,new Loot( typeof( RustyHatchet), 0.383909f ) 
																  ,new Loot( typeof( RustyWarhammer), 0.183609f ) 
																  ,new Loot( typeof( SharpenedLetterOpener), 0.306015f ) 
																  ,new Loot( typeof( WarpedCloak), 0.155789f ) 
																  ,new Loot( typeof( WarpedLeatherBelt), 0.105714f ) 
																  ,new Loot( typeof( WarpedLeatherBoots), 0.144661f ) 
																  ,new Loot( typeof( WarpedLeatherBracers), 0.116842f ) 
																  ,new Loot( typeof( WarpedLeatherGloves), 0.161353f ) 
																  ,new Loot( typeof( WarpedLeatherPants), 0.122406f ) 
																  ,new Loot( typeof( WarpedLeatherVest), 0.10015f ) 
																  ,new Loot( typeof( WitheredStaff), 0.22812f ) 
																  ,new Loot( typeof( WoodenBuckler), 0.0723307f ) 
																  ,new Loot( typeof( WoodenShield), 0.105714f ) 
																  ,new Loot( typeof( WornCloak), 0.111278f ) 
																  ,new Loot( typeof( WornHatchet), 0.178045f ) 
																  ,new Loot( typeof( WornHideCloak), 0.300451f ) 
																  ,new Loot( typeof( WornLargeShield), 0.205864f ) 
																  ,new Loot( typeof( WornLeatherBelt), 0.2003f ) 
																  ,new Loot( typeof( WornLeatherBoots), 0.244812f ) 
																  ,new Loot( typeof( WornLeatherBracers), 0.194737f ) 
																  ,new Loot( typeof( WornLeatherGloves), 0.183609f ) 
																  ,new Loot( typeof( WornLeatherPants), 0.205864f ) 
																  ,new Loot( typeof( WornLeatherVest), 0.161353f ) 
																  ,new Loot( typeof( WornMailBelt), 0.0667668f ) 
																  ,new Loot( typeof( WornMailBoots), 0.133534f ) 
																  ,new Loot( typeof( WornMailBracers), 0.10015f ) 
																  ,new Loot( typeof( WornMailGloves), 0.0890224f ) 
																  ,new Loot( typeof( WornMailPants), 0.133534f ) 
																  ,new Loot( typeof( WornMailVest), 0.0612029f ) 

															  };

		public static Loot[] RatchetBruiser = new Loot[] {new Loot( typeof( SilkCloth), 33.3333f ) 

														 };

		public static Loot[] BootyBayBruiser = new Loot[] {new Loot( typeof( Runecloth), 22.093f ) 
															  ,new Loot( typeof( BalancedWarAxe), 0.387597f ) 
															  ,new Loot( typeof( LaminatedScaleBoots), 0.387597f ) 
															  ,new Loot( typeof( LaminatedScaleCloak), 0.387597f ) 
															  ,new Loot( typeof( PrimedMusket), 0.387597f ) 
															  ,new Loot( typeof( SmoothCloak), 0.387597f ) 
															  ,new Loot( typeof( SmoothLeatherHelmet), 0.775194f ) 
															  ,new Loot( typeof( TaperedGreatsword), 0.387597f ) 
															  ,new Loot( typeof( TwillBracers), 0.387597f ) 
															  ,new Loot( typeof( TwillPants), 0.387597f ) 
															  ,new Loot( typeof( TwillVest), 0.387597f ) 

														  };

		public static Loot[] GadgetzanBruiser = new Loot[] {new Loot( typeof( Runecloth), 40f ) 

														   };

		public static Loot[] EverlookBruiser = new Loot[] {new Loot( typeof( Runecloth), 40f ) 

														  };

		/*			public static Loot[] RotHideBruiser = new Loot[] {
					};

					public static Loot[] RotHideBruiser = new Loot[] {
					};

					public static Loot[] RotHideBruiser = new Loot[] {
					};

					public static Loot[] RotHideBruiser = new Loot[] {
					};

					public static Loot[] RotHideBruiser = new Loot[] {
					};

					public static Loot[] RotHideBruiser = new Loot[] {
					};*/

	}
}		