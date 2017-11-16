using System;
using Server.Items;
using System.Collections;
using Server;


///////////////////////////////////////////
namespace Server
{
	public class IronForgeGuardsDrops
	{
		public static Loot[] MountaineerThalos = new Loot[] {		
															};
		
		public static Loot[] MountedIronforgeMountaineer = new Loot[] {
																	  };		

		public static Loot[] IronforgeMountaineer = new Loot[] {new Loot( typeof( SilkCloth), 23.1441f ) 
																   ,new Loot( typeof( WoolCloth), 11.7904f ) 
																   ,new Loot( typeof( CrossStitchedGloves), 0.436681f ) 
																   ,new Loot( typeof( CrossStitchedShoulderpads), 0.873362f ) 
																   ,new Loot( typeof( DeftStiletto), 0.436681f ) 
																   ,new Loot( typeof( RockMaul), 0.436681f ) 
																   ,new Loot( typeof( ToughLeatherShoulderpads), 0.873362f ) 
																   ,new Loot( typeof( TowerShield), 0.436681f ) 
															   };		
		
		public static Loot[] ColdridgeMountaineer = new Loot[] {new Loot( typeof( Runecloth), 35f ) 
																   ,new Loot( typeof( LaminatedScaleBoots), 10f ) 
															   };		
		
		public static Loot[] MenethilGuard = new Loot[] {new Loot( typeof( MageweaveCloth), 3.80623f ) 
															,new Loot( typeof( SilkCloth), 29.0657f ) 
															,new Loot( typeof( CrochetGloves), 0.346021f ) 
															,new Loot( typeof( HardenedLeatherPants), 0.346021f ) 
															,new Loot( typeof( HeavyFlintAxe), 0.346021f ) 
															,new Loot( typeof( InterlacedBelt), 0.346021f ) 
															,new Loot( typeof( KeenAxe), 0.692042f ) 
															,new Loot( typeof( LongBarreledMusket), 0.346021f ) 
															,new Loot( typeof( SplinteringBattleAxe), 0.346021f ) 
															,new Loot( typeof( StoneClub), 0.346021f ) 
														};		

		public static Loot[] IronforgeGuard = new Loot[] {new Loot( typeof( Runecloth), 27.3356f ) 
															 ,new Loot( typeof( BalancedWarAxe), 0.346021f ) 
															 ,new Loot( typeof( CloutMace), 0.346021f ) 
															 ,new Loot( typeof( FineLongsword), 0.692042f ) 
															 ,new Loot( typeof( LaminatedScaleArmor), 0.346021f ) 
															 ,new Loot( typeof( RecurveLongBow), 0.346021f ) 
															 ,new Loot( typeof( SmoothCloak), 0.346021f ) 
															 ,new Loot( typeof( SmoothLeatherArmor), 0.346021f ) 
															 ,new Loot( typeof( SmoothLeatherGloves), 0.692042f ) 
															 ,new Loot( typeof( StoutWarStaff), 0.692042f ) 
														 };		

		public static Loot[] BaeldunOfficer = new Loot[] {new Loot( typeof( Battlesmasher), 0.0506659f ) 
															 ,new Loot( typeof( CavalierTwoHander), 0.0506659f ) 
															 ,new Loot( typeof( DireWand), 0.0796178f ) 
															 ,new Loot( typeof( GreenweaveMantle), 0.0796178f ) 
															 ,new Loot( typeof( HeavyBronzeLockbox), 0.130284f ) 
															 ,new Loot( typeof( Jade), 0.0579039f ) 
															 ,new Loot( typeof( LesserMoonstone), 0.347423f ) 
															 ,new Loot( typeof( MossAgate), 0.123046f ) 
															 ,new Loot( typeof( PolishedZweihander), 0.0506659f ) 
															 ,new Loot( typeof( RidgeCleaver), 0.0506659f ) 
															 ,new Loot( typeof( RigidShoulders), 0.0579039f ) 
															 ,new Loot( typeof( RobustCloak), 0.0506659f ) 
															 ,new Loot( typeof( SanguineHandwraps), 0.0723798f ) 
															 ,new Loot( typeof( SentrysSash), 0.0651419f ) 
															 ,new Loot( typeof( WatchersBoots), 0.0579039f ) 
															 ,new Loot( typeof( HealingPotion), 1.1436f ) 
															 ,new Loot( typeof( LesserManaPotion), 0.665895f ) 
															 ,new Loot( typeof( LinenCloth), 4.31384f ) 
															 ,new Loot( typeof( MelonJuice), 2.15692f ) 
															 ,new Loot( typeof( MoistCornbread), 4.58164f ) 
															 ,new Loot( typeof( Nitroglycerin), 12.073f ) 
															 ,new Loot( typeof( ScrollOfAgility), 0.332947f ) 
															 ,new Loot( typeof( ScrollOfProtectionII), 0.195426f ) 
															 ,new Loot( typeof( ScrollOfSpiritII), 0.18095f ) 
															 ,new Loot( typeof( ScrollOfStrength), 0.246091f ) 
															 ,new Loot( typeof( SilkCloth), 4.37174f ) 
															 ,new Loot( typeof( SodiumNitrate), 12.1453f ) 
															 ,new Loot( typeof( TearOfTheMoons), 0.0723798f ) 
															 ,new Loot( typeof( WoodPulp), 12.7316f ) 
															 ,new Loot( typeof( WoolCloth), 22.8286f ) 
															 ,new Loot( typeof( BulkyBludgeon), 0.260567f ) 
															 ,new Loot( typeof( CrossStitchedBelt), 0.173712f ) 
															 ,new Loot( typeof( CrossStitchedBracers), 0.173712f ) 
															 ,new Loot( typeof( CrossStitchedCloak), 0.0868558f ) 
															 ,new Loot( typeof( CrossStitchedGloves), 0.137522f ) 
															 ,new Loot( typeof( CrossStitchedPants), 0.151998f ) 
															 ,new Loot( typeof( CrossStitchedSandals), 0.0868558f ) 
															 ,new Loot( typeof( CrossStitchedShoulderpads), 0.123046f ) 
															 ,new Loot( typeof( CrossStitchedVest), 0.0579039f ) 
															 ,new Loot( typeof( DeftStiletto), 0.10857f ) 
															 ,new Loot( typeof( LongBastardSword), 0.166474f ) 
															 ,new Loot( typeof( MeatCleaver), 0.173712f ) 
															 ,new Loot( typeof( OakenWarStaff), 0.137522f ) 
															 ,new Loot( typeof( OiledBlunderbuss), 0.188188f ) 
															 ,new Loot( typeof( ReinforcedChainBelt), 0.101332f ) 
															 ,new Loot( typeof( ReinforcedChainCloak), 0.0940938f ) 
															 ,new Loot( typeof( ReinforcedChainGloves), 0.130284f ) 
															 ,new Loot( typeof( ReinforcedChainPants), 0.0868558f ) 
															 ,new Loot( typeof( ReinforcedChainShoulderpads), 0.0723798f ) 
															 ,new Loot( typeof( ReinforcedChainVest), 0.0506659f ) 
															 ,new Loot( typeof( RockMaul), 0.195426f ) 
															 ,new Loot( typeof( ShortCutlass), 0.123046f ) 
															 ,new Loot( typeof( StiffRecurveBow), 0.173712f ) 
															 ,new Loot( typeof( StoneWarAxe), 0.123046f ) 
															 ,new Loot( typeof( TargeShield), 0.115808f ) 
															 ,new Loot( typeof( ToughCloak), 0.101332f ) 
															 ,new Loot( typeof( ToughLeatherArmor), 0.130284f ) 
															 ,new Loot( typeof( ToughLeatherBelt), 0.0506659f ) 
															 ,new Loot( typeof( ToughLeatherBoots), 0.123046f ) 
															 ,new Loot( typeof( ToughLeatherBracers), 0.0506659f ) 
															 ,new Loot( typeof( ToughLeatherGloves), 0.10857f ) 
															 ,new Loot( typeof( ToughLeatherPants), 0.101332f ) 
															 ,new Loot( typeof( ToughLeatherShoulderpads), 0.0940938f ) 
															 ,new Loot( typeof( TowerShield), 0.123046f ) 
														 };

		public static Loot[] AnvilrageOfficer = new Loot[] {new Loot( typeof( AbjurersCrystal), 0.0770586f ) 
															   ,new Loot( typeof( AlabasterPlateGauntlets), 0.0550418f ) 
															   ,new Loot( typeof( AlabasterPlateHelmet), 0.0990753f ) 
															   ,new Loot( typeof( AlabasterPlateVambraces), 0.0880669f ) 
															   ,new Loot( typeof( Aquamarine), 0.792602f ) 
															   ,new Loot( typeof( BlackDiamond), 0.517393f ) 
															   ,new Loot( typeof( BlesswindHammer), 0.0550418f ) 
															   ,new Loot( typeof( BurnsideRifle), 0.0990753f ) 
															   ,new Loot( typeof( CorpseHarvester), 0.0550418f ) 
															   ,new Loot( typeof( CouncillorsSash), 0.121092f ) 
															   ,new Loot( typeof( CrusadersBoots), 0.0880669f ) 
															   ,new Loot( typeof( CrusadersHelm), 0.0660502f ) 
															   ,new Loot( typeof( CrusadersPauldrons), 0.0550418f ) 
															   ,new Loot( typeof( DarkEspadon), 0.121092f ) 
															   ,new Loot( typeof( EbonholdGauntlets), 0.0660502f ) 
															   ,new Loot( typeof( EbonholdShoulderpads), 0.0660502f ) 
															   ,new Loot( typeof( GallantFlamberge), 0.0550418f ) 
															   ,new Loot( typeof( HeavyLamellarLeggings), 0.0550418f ) 
															   ,new Loot( typeof( ImperialRedPants), 0.110084f ) 
															   ,new Loot( typeof( LordsBreastplate), 0.0550418f ) 
															   ,new Loot( typeof( MarbleCircle), 0.0880669f ) 
															   ,new Loot( typeof( MithrilLockbox), 0.264201f ) 
															   ,new Loot( typeof( MysticalBoots), 0.110084f ) 
															   ,new Loot( typeof( MysticalBracers), 0.0660502f ) 
															   ,new Loot( typeof( MysticalGloves), 0.165125f ) 
															   ,new Loot( typeof( OrnateCloak), 0.0550418f ) 
															   ,new Loot( typeof( PatternChimericBoots), 0.0550418f ) 
															   ,new Loot( typeof( PatternFelclothBoots), 0.0550418f ) 
															   ,new Loot( typeof( PlansThoriumBelt), 0.0550418f ) 
															   ,new Loot( typeof( RevenantChestplate), 0.0880669f ) 
															   ,new Loot( typeof( RighteousArmor), 0.0770586f ) 
															   ,new Loot( typeof( RighteousHelmet), 0.0550418f ) 
															   ,new Loot( typeof( SerpentskinBoots), 0.0550418f ) 
															   ,new Loot( typeof( SerpentskinSpaulders), 0.0660502f ) 
															   ,new Loot( typeof( SiegeBow), 0.0770586f ) 
															   ,new Loot( typeof( StarRuby), 0.594452f ) 
															   ,new Loot( typeof( TemplarBoots), 0.0550418f ) 
															   ,new Loot( typeof( TemplarGirdle), 0.0550418f ) 
															   ,new Loot( typeof( ThaumaturgistStaff), 0.0770586f ) 
															   ,new Loot( typeof( TravelersBackpack), 0.0770586f ) 
															   ,new Loot( typeof( WanderersBelt), 0.0660502f ) 
															   ,new Loot( typeof( WanderersBracers), 0.0660502f ) 
															   ,new Loot( typeof( WidowBlade), 0.110084f ) 
															   ,new Loot( typeof( WizardsHand), 0.198151f ) 
															   ,new Loot( typeof( ACrumpledUpNote), 0.264201f ) 
															   ,new Loot( typeof( DarkIronFannyPack), 5.82343f ) 
															   ,new Loot( typeof( DarkIronOre), 0.176134f ) 
															   ,new Loot( typeof( HomemadeCherryPie), 4.38133f ) 
															   ,new Loot( typeof( MajorHealingPotion), 0.737561f ) 
															   ,new Loot( typeof( MorningGloryDew), 2.35579f ) 
															   ,new Loot( typeof( RelicCofferKey), 7.71686f ) 
															   ,new Loot( typeof( Runecloth), 26.1229f ) 
															   ,new Loot( typeof( ScrollOfAgilityIII), 0.231176f ) 
															   ,new Loot( typeof( ScrollOfProtectionIV), 0.121092f ) 
															   ,new Loot( typeof( ScrollOfSpiritIV), 0.0770586f ) 
															   ,new Loot( typeof( ScrollOfStrengthIII), 0.330251f ) 
															   ,new Loot( typeof( SmallSackOfCoins), 0.0880669f ) 
															   ,new Loot( typeof( SuperiorManaPotion), 0.572435f ) 
															   ,new Loot( typeof( BalancedWarAxe), 0.275209f ) 
															   ,new Loot( typeof( BulkyMaul), 0.121092f ) 
															   ,new Loot( typeof( CloutMace), 0.308234f ) 
															   ,new Loot( typeof( CrestedBuckler), 0.0990753f ) 
															   ,new Loot( typeof( DeflectingTower), 0.165125f ) 
															   ,new Loot( typeof( FineLongsword), 0.242184f ) 
															   ,new Loot( typeof( JaggedAxe), 0.330251f ) 
															   ,new Loot( typeof( LaminatedScaleArmor), 0.0770586f ) 
															   ,new Loot( typeof( LaminatedScaleBelt), 0.0550418f ) 
															   ,new Loot( typeof( LaminatedScaleBoots), 0.143109f ) 
															   ,new Loot( typeof( LaminatedScaleBracers), 0.0990753f ) 
															   ,new Loot( typeof( LaminatedScaleCirclet), 0.0880669f ) 
															   ,new Loot( typeof( LaminatedScaleCloak), 0.0770586f ) 
															   ,new Loot( typeof( LaminatedScaleGloves), 0.1321f ) 
															   ,new Loot( typeof( LaminatedScalePants), 0.0770586f ) 
															   ,new Loot( typeof( LaminatedScaleShoulderpads), 0.0550418f ) 
															   ,new Loot( typeof( LightPlateBelt), 0.0770586f ) 
															   ,new Loot( typeof( LightPlateBoots), 0.0550418f ) 
															   ,new Loot( typeof( LightPlateBracers), 0.0770586f ) 
															   ,new Loot( typeof( LightPlateChestpiece), 0.121092f ) 
															   ,new Loot( typeof( LightPlateGloves), 0.0550418f ) 
															   ,new Loot( typeof( PrimedMusket), 0.363276f ) 
															   ,new Loot( typeof( RecurveLongBow), 0.374284f ) 
															   ,new Loot( typeof( ShinyBracelet), 0.0660502f ) 
															   ,new Loot( typeof( SmoothCloak), 0.1321f ) 
															   ,new Loot( typeof( SmoothLeatherArmor), 0.0550418f ) 
															   ,new Loot( typeof( SmoothLeatherBelt), 0.0990753f ) 
															   ,new Loot( typeof( SmoothLeatherBracers), 0.143109f ) 
															   ,new Loot( typeof( SmoothLeatherGloves), 0.143109f ) 
															   ,new Loot( typeof( SmoothLeatherHelmet), 0.0770586f ) 
															   ,new Loot( typeof( SmoothLeatherPants), 0.0990753f ) 
															   ,new Loot( typeof( SmoothLeatherShoulderpads), 0.121092f ) 
															   ,new Loot( typeof( SpikedDagger), 0.396301f ) 
															   ,new Loot( typeof( StoutWarStaff), 0.209159f ) 
															   ,new Loot( typeof( TaperedGreatsword), 0.297226f ) 
															   ,new Loot( typeof( TwillBelt), 0.165125f ) 
															   ,new Loot( typeof( TwillBoots), 0.143109f ) 
															   ,new Loot( typeof( TwillBracers), 0.220167f ) 
															   ,new Loot( typeof( TwillCloak), 0.121092f ) 
															   ,new Loot( typeof( TwillCover), 0.143109f ) 
															   ,new Loot( typeof( TwillGloves), 0.143109f ) 
															   ,new Loot( typeof( TwillPants), 0.110084f ) 
															   ,new Loot( typeof( TwillShoulderpads), 0.0660502f ) 
															   ,new Loot( typeof( TwillVest), 0.143109f ) 
														   };
		public static Loot[] MountaineerFlint = new Loot[] {new Loot( typeof( SilkCloth), 24.1758f ) 
															   ,new Loot( typeof( WoolCloth), 7.69231f ) 
															   ,new Loot( typeof( CrossStitchedBelt), 1.0989f ) 
															   ,new Loot( typeof( CrossStitchedShoulderpads), 1.0989f ) 
															   ,new Loot( typeof( TowerShield), 1.0989f ) 		
														   };

		public static Loot[] MountaineerCobbleflint = new Loot[] {		
																 };

		public static Loot[] MountaineerWallbang = new Loot[] {		
															  };

		public static Loot[] MountaineerGravelgaw = new Loot[] {		
															   };

		public static Loot[] MountaineerBrokk = new Loot[] {new Loot( typeof( SilkCloth), 14.1593f ) 
															   ,new Loot( typeof( WoolCloth), 15.9292f ) 
															   ,new Loot( typeof( CrossStitchedSandals), 1.76991f ) 
															   ,new Loot( typeof( ShortCutlass), 0.884956f ) 
															   ,new Loot( typeof( StiffRecurveBow), 0.884956f ) 
															   ,new Loot( typeof( ToughLeatherGloves), 1.76991f ) 
		
														   };

		public static Loot[] MountaineerGanin = new Loot[] {new Loot( typeof( SilkCloth), 25f ) 		
														   };

		public static Loot[] MountaineerStenn = new Loot[] {new Loot( typeof( SilkCloth), 29.7297f ) 
															   ,new Loot( typeof( WoolCloth), 8.10811f ) 
															   ,new Loot( typeof( CrossStitchedSandals), 2.7027f ) 		
														   };

		public static Loot[] MountaineerDroken = new Loot[] {new Loot( typeof( SilkCloth), 19.5122f ) 
																,new Loot( typeof( WoolCloth), 2.43902f ) 
																,new Loot( typeof( DeftStiletto), 2.43902f ) 
		
															};

		public static Loot[] MountaineerZaren = new Loot[] {new Loot( typeof( SilkCloth), 24.1379f ) 
															   ,new Loot( typeof( WoolCloth), 13.7931f ) 
															   ,new Loot( typeof( ShortCutlass), 6.89655f ) 		
														   };

		public static Loot[] MountaineerVeek = new Loot[] {new Loot( typeof( SilkCloth), 29.4118f ) 
		
														  };

		public static Loot[] MountaineerKalmir = new Loot[] {new Loot( typeof( SilkCloth), 18.3333f ) 
																,new Loot( typeof( WoolCloth), 18.3333f ) 		
															};

		public static Loot[] MountaineerNaarh = new Loot[] {new Loot( typeof( SilkCloth), 25f ) 		
														   };

		public static Loot[] MountaineerTyraw = new Loot[] {new Loot( typeof( SilkCloth), 20f ) 
															   ,new Loot( typeof( WoolCloth), 20f ) 
		
														   };

		public static Loot[] MountaineerLuxst = new Loot[] {new Loot( typeof( SilkCloth), 20f ) 
															   ,new Loot( typeof( WoolCloth), 20f ) 
		
														   };

		public static Loot[] MountaineerMorran = new Loot[] {new Loot( typeof( SilkCloth), 20f ) 
																,new Loot( typeof( WoolCloth), 20f ) 
		
															};

		public static Loot[] MountaineerHammerfall = new Loot[] {new Loot( typeof( SilkCloth), 15.3846f ) 
		
																};

		public static Loot[] MountaineerYuttha = new Loot[] {new Loot( typeof( SilkCloth), 15.3846f ) 
		
															};

		public static Loot[] MountaineerZwarn = new Loot[] {new Loot( typeof( SilkCloth), 40f ) 
															   ,new Loot( typeof( WoolCloth), 6.66667f ) 
		
														   };

		public static Loot[] MountaineerGwarth = new Loot[] {new Loot( typeof( SilkCloth), 9.09091f ) 
																,new Loot( typeof( WoolCloth), 18.1818f ) 
																,new Loot( typeof( ReinforcedChainPants), 4.54545f ) 
		
															};

		public static Loot[] MountaineerDalk = new Loot[] {new Loot( typeof( SilkCloth), 23.0769f ) 
															  ,new Loot( typeof( StiffRecurveBow), 7.69231f ) 
		
														  };

		public static Loot[] MountaineerKadrell = new Loot[] {		
															 };

		public static Loot[] MountaineerRockgar = new Loot[] {		
															 };

		public static Loot[] MountaineerStormpike = new Loot[] {		
															   };

		public static Loot[] MountaineerBarleybrew = new Loot[] {		
																};

		public static Loot[] MountaineerDokkin = new Loot[] {new Loot( typeof( SilkCloth), 26.4591f ) 
																,new Loot( typeof( WoolCloth), 8.56031f ) 
																,new Loot( typeof( CrossStitchedGloves), 0.389105f ) 
																,new Loot( typeof( CrossStitchedSandals), 0.389105f ) 
																,new Loot( typeof( MeatCleaver), 0.77821f ) 
																,new Loot( typeof( OakenWarStaff), 0.77821f ) 
																,new Loot( typeof( OiledBlunderbuss), 0.389105f ) 
																,new Loot( typeof( ReinforcedChainBoots), 0.77821f ) 
																,new Loot( typeof( ReinforcedChainBracers), 0.389105f ) 
																,new Loot( typeof( ReinforcedChainPants), 0.389105f ) 
																,new Loot( typeof( RockMaul), 0.389105f ) 
																,new Loot( typeof( ToughLeatherArmor), 0.389105f ) 
																,new Loot( typeof( ToughLeatherBelt), 0.389105f ) 
																,new Loot( typeof( ToughLeatherGloves), 0.389105f ) 
		
															};

		public static Loot[] MountaineerGrugelm = new Loot[] {new Loot( typeof( SilkCloth), 21.49f ) 
																 ,new Loot( typeof( WoolCloth), 12.3209f ) 
																 ,new Loot( typeof( CrossStitchedCloak), 0.859599f ) 
																 ,new Loot( typeof( CrossStitchedPants), 0.286533f ) 
																 ,new Loot( typeof( LongBastardSword), 0.286533f ) 
																 ,new Loot( typeof( OiledBlunderbuss), 0.286533f ) 
																 ,new Loot( typeof( RockMaul), 0.286533f ) 
																 ,new Loot( typeof( StoneWarAxe), 0.286533f ) 
																 ,new Loot( typeof( ToughLeatherBracers), 0.573066f ) 
		
															 };

		public static Loot[] MountaineerThar = new Loot[] {new Loot( typeof( SilkCloth), 19.9203f ) 
															  ,new Loot( typeof( WoolCloth), 9.16335f ) 
															  ,new Loot( typeof( ReinforcedChainPants), 0.398406f ) 
															  ,new Loot( typeof( StoneWarAxe), 0.398406f ) 
															  ,new Loot( typeof( ToughLeatherBelt), 0.796813f ) 
															  ,new Loot( typeof( ToughLeatherGloves), 0.398406f ) 
		
														  };

		public static Loot[] MountaineerRharen = new Loot[] {new Loot( typeof( SilkCloth), 21.978f ) 
																,new Loot( typeof( WoolCloth), 7.14286f ) 
																,new Loot( typeof( CrossStitchedShoulderpads), 0.549451f ) 
																,new Loot( typeof( LongBastardSword), 0.549451f ) 
																,new Loot( typeof( MeatCleaver), 0.549451f ) 
																,new Loot( typeof( OakenWarStaff), 0.549451f ) 
																,new Loot( typeof( ReinforcedChainPants), 0.549451f ) 
																,new Loot( typeof( RockMaul), 1.0989f ) 
																,new Loot( typeof( StoneWarAxe), 0.549451f ) 
																,new Loot( typeof( ToughLeatherPants), 0.549451f ) 
		
															};

		public static Loot[] MountaineerHarn = new Loot[] {new Loot( typeof( SilkCloth), 20f ) 
															  ,new Loot( typeof( WoolCloth), 10f ) 
		
														  };

		public static Loot[] MountaineerUthan = new Loot[] {new Loot( typeof( SilkCloth), 29.4118f ) 
															   ,new Loot( typeof( CrossStitchedGloves), 5.88235f ) 
		
														   };

		public static Loot[] MountaineerWuar = new Loot[] {new Loot( typeof( WoolCloth), 11.1111f ) 
		
														  };

		public static Loot[] MountaineerCragg = new Loot[] {new Loot( typeof( SilkCloth), 30f ) 
		
														   };

		public static Loot[] MountaineerOzmok = new Loot[] {new Loot( typeof( SilkCloth), 22.2222f ) 
															   ,new Loot( typeof( WoolCloth), 11.1111f ) 
		
														   };

		public static Loot[] MountaineerBludd = new Loot[] {new Loot( typeof( SilkCloth), 22.7273f ) 
															   ,new Loot( typeof( WoolCloth), 9.09091f ) 
		
														   };

		public static Loot[] MountaineerRoghan = new Loot[] {new Loot( typeof( SilkCloth), 16.6667f ) 
																,new Loot( typeof( WoolCloth), 5.55556f ) 
																,new Loot( typeof( CrossStitchedPants), 5.55556f ) 
		
															};

		public static Loot[] MountaineerJanha = new Loot[] {new Loot( typeof( SilkCloth), 33.3333f ) 
		
														   };

		public static Loot[] MountaineerModax = new Loot[] {new Loot( typeof( SilkCloth), 16.6667f ) 
															   ,new Loot( typeof( WoolCloth), 16.6667f ) 
		
														   };

		public static Loot[] MountaineerFazgard = new Loot[] {new Loot( typeof( SilkCloth), 31.25f ) 
																 ,new Loot( typeof( WoolCloth), 12.5f ) 
																 ,new Loot( typeof( DeftStiletto), 6.25f ) 
																 ,new Loot( typeof( ReinforcedChainVest), 6.25f ) 
		
															 };

		public static Loot[] MountaineerKamdar = new Loot[] {new Loot( typeof( SilkCloth), 40f ) 
																,new Loot( typeof( WoolCloth), 6.66667f ) 
																,new Loot( typeof( ShortCutlass), 6.66667f ) 
		
															};

		public static Loot[] MountaineerLangarr = new Loot[] {new Loot( typeof( SilkCloth), 42.8571f ) 
																 ,new Loot( typeof( WoolCloth), 28.5714f ) 
		
															 };

		public static Loot[] MountaineerSwarth = new Loot[] {new Loot( typeof( SilkCloth), 28.5714f ) 
																,new Loot( typeof( WoolCloth), 4.7619f ) 
		
															};

		public static Loot[] MountaineerHaggis = new Loot[] {new Loot( typeof( CopperOre), 11.7647f ) 
																,new Loot( typeof( RoughStone), 5.88235f ) 
																,new Loot( typeof( SilkCloth), 11.7647f ) 
		
															};

		public static Loot[] MountaineerBarn = new Loot[] {new Loot( typeof( SilkCloth), 34.7826f ) 
		
														  };

		public static Loot[] MountaineerMorlic = new Loot[] {new Loot( typeof( SilkCloth), 33.3333f ) 
																,new Loot( typeof( WoolCloth), 4.16667f ) 
																,new Loot( typeof( CrossStitchedPants), 4.16667f ) 
																,new Loot( typeof( ToughLeatherShoulderpads), 4.16667f ) 
		
															};

		public static Loot[] MountaineerAngst = new Loot[] {new Loot( typeof( SilkCloth), 18.1818f ) 
															   ,new Loot( typeof( WoolCloth), 18.1818f ) 
															   ,new Loot( typeof( TowerShield), 9.09091f ) 
		
														   };

		public static Loot[] MountaineerHaggil = new Loot[] {new Loot( typeof( SilkCloth), 7.14286f ) 
																,new Loot( typeof( WoolCloth), 14.2857f ) 
		
															};

		public static Loot[] MountaineerPebblebitty = new Loot[] {		
																 };

		public static Loot[] ThelsamarMountaineer = new Loot[] {new Loot( typeof( MageweaveCloth), 6.66667f ) 
																   ,new Loot( typeof( SilkCloth), 27.3684f ) 
																   ,new Loot( typeof( DoubleMailBracers), 0.350877f ) 
																   ,new Loot( typeof( DoubleMailCoif), 0.350877f ) 
																   ,new Loot( typeof( DoubleMailPants), 0.350877f ) 
																   ,new Loot( typeof( HardenedLeatherTunic), 0.350877f ) 
																   ,new Loot( typeof( InterlacedBracers), 0.350877f ) 
																   ,new Loot( typeof( InterlacedCowl), 0.350877f ) 
																   ,new Loot( typeof( LightScimitar), 0.701754f ) 
																   ,new Loot( typeof( MetalStave), 0.350877f ) 
		
															   };

		public static Loot[] MountaineerDolf = new Loot[] {		
														  };

		public static Loot[] DunMoroghMountaineer = new Loot[] {new Loot( typeof( SilkCloth), 20.2381f ) 
																   ,new Loot( typeof( WoolCloth), 7.14286f ) 
																   ,new Loot( typeof( OiledBlunderbuss), 2.38095f ) 
																   ,new Loot( typeof( ShortCutlass), 1.19048f ) 
		
															   };

		public static Loot[] ExpeditionaryMountaineer = new Loot[] {		
																   };



	}
}