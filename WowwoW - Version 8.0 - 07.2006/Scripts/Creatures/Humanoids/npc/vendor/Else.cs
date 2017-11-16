//originally Scripted By DiScS Converter
//Edited by *place name here*
using System;
using Server.Items;

////////////////////
namespace Server.Creatures
{
	/*public class Harkk : BaseCreature 
	 { 
	public  Harkk() : base() 
	 { 
	Model = 5001;
	AttackSpeed= 2100;
	BoundingRadius = 1.000000f ;
	Name = "Harkk" ;
	Flags1 = 0x08400046 ;
	Id = 36367 ; 
	Guild = "Parrot Trainer";
	Size = 1f;
	Speed = 2.9f ;
	WalkSpeed = 2.9f ;
	RunSpeed = 5.9f ;
	ResistArcane = 0;
	ResistFire = 0;
	ResistFrost = 0;
	ResistHoly = 0;
	ResistNature = 0;
	ResistShadow = 0;
	Level = RandomLevel( 20 );
	NpcType = (int)NpcTypes.Humanoid;
	BaseHitPoints = 0 ;
	NpcFlags = (int)NpcActions.Trainer ; ; ;
	CombatReach = 0f ;
	SetDamage ( 32, 42 );
	NpcText00 = "Greetings $N, I am Harkk." ;
	BaseMana = 0 ;
	Sells = new Item[] { new ParrotCageGreenWingMacaw()
							   , new ParrotCageHyacinthMacaw()
							   , new ParrotCageSenegal()
							   , new ParrotCageCockatiel()
	  } ;
	Faction = Factions.Friend;
	AIEngine = new NonAgressiveAnimalAI( this );
	AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
	AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
	}
	}*/
	public class LokhtosDarkbargainer : BaseCreature 
	{ 
		public  LokhtosDarkbargainer() : base() 
		{ 
			Model = 9969;
			AttackSpeed= 1273;
			BoundingRadius = 1.00f ;
			Name = "Lokhtos Darkbargainer" ;
			Flags1 = 0x080066 ;
			Id = 12944 ; 
			Guild = "The Thorium Brotherhood";
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 60 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 2426 ;
			NpcFlags = (int)NpcActions.Vendor ;
			CombatReach = 11.00f ;
			SetDamage ( 65, 85 );
			NpcText00 = "Greetings $N, I am Lokhtos Darkbargainer." ;
			BaseMana = 3005 ;
			Sells = new Item[] { new PatternFlarecoreMantle()
								   , new PatternFlarecoreGloves()
								   , new PatternCorehoundBoots()
								   , new PatternMoltenHelm()
								   , new PatternBlackDragonscaleBoots()
								   , new PlansFieryChainGirdle()
								   , new PlansDarkIronBracers()
								   , new PlansDarkIronLeggings()
								   , new PlansFieryChainShoulders()
								   , new PlansDarkIronReaver()
								   , new PlansDarkIronDestroyer()
							   } ;
			Faction = Factions.Friend;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 24634, InventoryTypes.OneHand, 2, 4, 2, 3, 0, 0, 0 ), new Item( 6537, InventoryTypes.HeldInHand, 4, 0, 1, 7, 0, 0, 0 ));
		}
	}
	public class OfficerAreyn : BaseCreature 
	{ 
		public  OfficerAreyn() : base() 
		{ 
			Model = 12923;
			AttackSpeed= 2000;
			BoundingRadius = 0.208000f ;
			Name = "Officer Areyn" ;
			Flags1 = 0x0480006 ;
			Id = 12805 ; 
			Guild = "Accessories Quartermaster";
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 55 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 2506 ;
			NpcFlags = (int)NpcActions.Vendor ;
			CombatReach = 1.5f ;
			SetDamage ( 68, 87 );
			NpcText00 = "Hello" ;
			BaseMana = 0 ;
			Sells = new Item[] { new PrivatesTabard()
								   , new SergeantsCape()
								   , new SergeantsCape()
								   , new SergeantsCape()
								   , new MasterSergeantsInsignia()
								   , new MasterSergeantsInsignia()
								   , new MasterSergeantsInsignia()
								   , new SergeantMajorsPlateWristguards()
								   , new SergeantMajorsPlateWristguards()
								   , new SergeantMajorsChainArmguards()
								   , new SergeantMajorsChainArmguards()
								   , new SergeantMajorsDragonhideArmsplints()
								   , new SergeantMajorsDragonhideArmsplints()
								   , new SergeantMajorsLeatherArmsplints()
								   , new SergeantMajorsLeatherArmsplints()
								   , new SergeantMajorsSilkCuffs()
								   , new SergeantMajorsSilkCuffs()
								   , new InsigniaOfTheAlliance()
								   , new InsigniaOfTheAlliance()
								   , new InsigniaOfTheAlliance()
								   , new InsigniaOfTheAlliance()
								   , new InsigniaOfTheAlliance()
								   , new InsigniaOfTheAlliance()
								   , new InsigniaOfTheAlliance()
								   , new InsigniaOfTheAlliance()
							   } ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 7483, InventoryTypes.OneHand, 2, 7, 1, 3, 0, 0, 0 ), new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
		}
	}
	public class SergeantBasha : BaseCreature 
	{ 
		public  SergeantBasha() : base() 
		{ 
			Model = 12681;
			AttackSpeed= 1739;
			BoundingRadius = 0.236000f ;
			Name = "Sergeant Ba'sha" ;
			Flags1 = 0x0480002 ;
			Id = 12799 ; 
			Guild = "Accessories Quartermaster";
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 55 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 2226 ;
			NpcFlags = 00 ;
			CombatReach = 1.5f ;
			SetDamage ( 60, 77 );
			NpcText00 = "Hello" ;
			BaseMana = 0 ;
			Sells = new Item[] { new BulkyMaul()
								   , new Runecloth()
								   , new ScoutsTabard()
								   , new SeniorSergeantsInsignia()
								   , new SeniorSergeantsInsignia()
								   , new SergeantsCloak()
								   , new FirstSergeantsSilkCuffs()
								   , new FirstSergeantsLeatherArmguards()
								   , new FirstSergeantsMailWristguards()
								   , new SergeantsCloak()
								   , new SeniorSergeantsInsignia()
								   , new FirstSergeantsPlateBracers()
								   , new FirstSergeantsPlateBracers()
								   , new FirstSergeantsMailWristguards()
								   , new FirstSergeantsDragonhideArmguards()
								   , new FirstSergeantsLeatherArmguards()
								   , new FirstSergeantsDragonhideArmguards()
								   , new FirstSergeantsSilkCuffs()
								   , new SergeantsCloak()
								   , new MilitaryRanksOfTheHordeAlliance()
								   , new InsigniaOfTheHorde()
								   , new InsigniaOfTheHorde()
								   , new InsigniaOfTheHorde()
								   , new InsigniaOfTheHorde()
								   , new InsigniaOfTheHorde()
								   , new InsigniaOfTheHorde()
								   , new InsigniaOfTheHorde()
								   , new InsigniaOfTheHorde()
							   } ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 19550, InventoryTypes.OneHand, 2, 0, 1, 3, 0, 0, 0 ));
		}
	}
	public class AugustusTheTouched : BaseCreature 
	{ 
		public  AugustusTheTouched() : base() 
		{ 
			Model = 12470;
			AttackSpeed= 1344;
			BoundingRadius = 1.00f ;
			Name = "Augustus the Touched" ;
			Flags1 = 0x0400006 ;
			Id = 12384 ; 
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 55 );
			NpcType = (int)NpcTypes.Undead;
			BaseHitPoints = 2226 ;
			NpcFlags = (int)NpcActions.Vendor ;
			CombatReach = 11.00f ;
			SetDamage ( 60, 77 );
			NpcText00 = "Greetings $N, I am Augustus the Touched." ;
			BaseMana = 2755 ;
			Sells = new Item[] { new ACrazyGrabBag()
								   , new ForestMushroomCap()
								   , new RedSpeckledMushroom()
								   , new SpongyMorel()
								   , new DeliciousCaveMold()
								   , new RawBlackTruffle()
								   , new DriedKingBolete()
							   } ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
	public class SuperSeller680 : BaseCreature 
	{ 
		public  SuperSeller680() : base() 
		{ 
			Model = 1159;
			AttackSpeed= 1609;
			BoundingRadius = 1.00f ;
			Name = "Super-Seller 680" ;
			Flags1 = 0x080046 ;
			Id = 12246 ; 
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 36 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1464 ;
			NpcFlags = (int)NpcActions.Vendor ;
			CombatReach = 11.00f ;
			SetDamage ( 39, 50 );
			NpcText00 = "Greetings $N, I am Super-Seller 680." ;
			BaseMana = 1804 ;
			Sells = new Item[] { new AccurateSlugs()
								   , new JaggedArrow()
								   , new MelonJuice()
								   , new RecipeLeanWolfSteak()
								   , new RecipeHotWolfRibs()
								   , new RecipeMysteryStew()
								   , new RecipeDragonbreathChili()
								   , new SchematicIceDeflector()
								   , new SchematicAccurateScope()
								   , new PatternEnchantersCowl()
								   , new ScrollOfAgilityII()
								   , new GleamingThrowingAxe()
								   , new WickedThrowingDagger()
								   , new RefreshingSpringWater()
								   , new MoonberryJuice()
								   , new SweetNectar()
								   , new ScrollOfStaminaII()
								   , new ScrollOfStrengthII()
								   , new ScrollOfIntellectII()
								   , new SharpArrow()
								   , new HeavyShot()
								   , new RazorArrow()
								   , new SolidShot()
								   , new KeenThrowingKnife()
								   , new HeavyThrowingDagger()
								   , new SharpThrowingAxe()
								   , new DeadlyThrowingAxe()
								   , new RecipeBigBearSteak()
								   , new ScrollOfProtectionIII()
								   , new ScrollOfSpiritIII()
								   , new SimpleWood()
								   , new FlintAndTinder()
								   , new HeavyBrownBag()
								   , new BrownLeatherSatchel()
								   , new RecipeBarbecuedBuzzardWing()
								   , new PatternDarkSilkShirt()
								   , new PatternCrimsonSilkCloak()
								   , new SchematicGoblinJumperCables()
							   } ;
			Faction = Factions.Friend;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
	public class VendorTron1000 : BaseCreature 
	{ 
		public  VendorTron1000() : base() 
		{ 
			Model = 1159;
			AttackSpeed= 2000;
			BoundingRadius = 0.374800f ;
			Name = "Vendor-Tron 1000" ;
			Flags1 = 0x080046 ;
			Id = 12245 ; 
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 38 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1545 ;
			NpcFlags = (int)NpcActions.Vendor ;
			CombatReach = 0.6f ;
			SetDamage ( 41, 53 );
			NpcText00 = "Greetings $N, I am Vendor-Tron 1000." ;
			BaseMana = 0 ;
			Sells = new Item[] { new RecipeRoastRaptor()
								   , new RecipeJungleStew()
								   , new RecipeCarrionSurprise()
								   , new RecipeHeavyKodoStew()
								   , new GreaterHealingPotion()
								   , new CoarseThread()
								   , new FineThread()
								   , new BlackDye()
								   , new RedDye()
								   , new MildSpices()
								   , new HotSpices()
								   , new WeakFlux()
								   , new MiningPick()
								   , new DustOfDecay()
								   , new EmptyVial()
								   , new LeadedVial()
								   , new StrongFlux()
								   , new SoothingSpices()
								   , new RecipeHotLionChops()
								   , new LethargyRoot()
								   , new ManaPotion()
								   , new Coal()
								   , new Salt()
								   , new SilkenThread()
								   , new GrayDye()
								   , new YellowDye()
								   , new PurpleDye()
								   , new WoodenStock()
								   , new HeavyStock()
								   , new RecipeLeanVenison()
								   , new CopperRod()
								   , new FishingPole()
								   , new Nightcrawlers()
								   , new BrightBaubles()
								   , new SkinningKnife()
								   , new HeavySilkenThread()
								   , new CrystalVial()
							   } ;
			Faction = Factions.Friend;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
	public class SamanthaSwifthoof : BaseCreature 
	{ 
		public  SamanthaSwifthoof() : base() 
		{ 
			Model = 11687;
			AttackSpeed= 2000;
			BoundingRadius = 0.872500f ;
			Name = "Samantha Swifthoof" ;
			Flags1 = 0x0480046 ;
			Id = 11748 ; 
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 40 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1625 ;
			NpcFlags = 00 ;
			CombatReach = 3.75f ;
			SetDamage ( 43, 56 );
			NpcText00 = "Hello" ;
			BaseMana = 0 ;
			Sells = new Item[] { new Goldthorn()
							   } ;
			Faction = Factions.ThunderBluff;
			AIEngine = new TravellerSalesmanAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
	public class MagnusFrostwake : BaseCreature 
	{ 
		public  MagnusFrostwake() : base() 
		{ 
			Model = 262;
			AttackSpeed= 1413;
			BoundingRadius = 1.00f ;
			Name = "Magnus Frostwake" ;
			Flags1 = 0x00000000 ;
			Id = 11278 ; 
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 50 );
			NpcType = (int)NpcTypes.Undead;
			BaseHitPoints = 2025 ;
			NpcFlags = (int)NpcActions.Vendor ;
			CombatReach = 0f ;
			SetDamage ( 51, 76 );
			NpcText00 = "Hello" ;
			BaseMana = 1688 ;
			Sells = new Item[] { new PlansStormGauntlets()
								   , new PlansOrnateThoriumHandaxe()
								   , new PlansHugeThoriumBattleaxe()
								   , new RecipeTransmuteWaterToAir()
								   , new RecipeMajorManaPotion()
								   , new PlansEbonShiv()
							   } ;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 23172, InventoryTypes.OneHand, 14, 1, 13, 0, 0, 0, 0 ), new Item( 23172, InventoryTypes.HeldInHand, 0, 1, 23, 0, 0, 0, 0 ));

		}
	}
	public class KerlonianEvershade : BaseCreature 
	{ 
		public  KerlonianEvershade() : base() 
		{ 
			Model = 10858;
			AttackSpeed= 2000;
			BoundingRadius = 0.350000f ;
			Name = "Kerlonian Evershade" ;
			Flags1 = 0x0480046 ;
			Id = 11218 ; 
			Guild = "Druid of the Claw";
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 20 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 824 ;
			NpcFlags = 2 ;
			CombatReach = 1.5f ;
			SetDamage ( 21, 28 );
			NpcText00 = "Greetings $N, I am Kerlonian Evershade." ;
			BaseMana = 0 ;
			Sells = new Item[] { new HornOfAwakening()
							   } ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 24015, InventoryTypes.TwoHanded, 2, 10, 2, 1, 0, 0, 0 ));
		}
	}
	public class BashanaRunetotem : BaseCreature 
	{ 
		public  BashanaRunetotem() : base() 
		{ 
			Model = 8356;
			AttackSpeed= 2000;
			BoundingRadius = 0.872500f ;
			Name = "Bashana Runetotem" ;
			Flags1 = 0x0480006 ;
			Id = 9087 ; 
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 35 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1424 ;
			NpcFlags = (int)NpcActions.Vendor ;
			CombatReach = 3.75f ;
			SetDamage ( 38, 49 );
			NpcText00 = "Greetings $N, I am Bashana Runetotem." ;
			BaseMana = 0 ;
			Sells = new Item[] { new EvergreenPouch()
								   , new PacketOfTharlendrisSeeds()
							   } ;
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 22391, InventoryTypes.OneHand, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class LilTimmy : BaseCreature 
	{ 
		public  LilTimmy() : base() 
		{ 
			Model = 7935;
			AttackSpeed= 1500;
			BoundingRadius = 0.800000f ;
			Name = "Lil Timmy" ;
			Flags1 = 0x080066 ;
			Id = 8666 ; 
			Guild = "Boy with kittens";
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 5 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 224 ;
			NpcFlags = (int)NpcActions.Vendor ;
			CombatReach = 0.8f ;
			SetDamage ( 5, 6 );
			NpcText00 = "Greetings $N, I am Lil Timmy." ;
			BaseMana = 0 ;
			Sells = new Item[] { new CatCarrierWhiteKitten()
							   } ;
			Faction = Factions.Stormwind;
			AIEngine = new TravellerSalesmanAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 7446, InventoryTypes.OneHand, 2, 14, 7, 0, 0, 0, 0 ));

		}
	}
	public class Halpa : BaseCreature 
	{ 
		public  Halpa() : base() 
		{ 
			Model = 7629;
			AttackSpeed= 2000;
			BoundingRadius = 0.974700f ;
			Name = "Halpa" ;
			Flags1 = 0x08480046 ;
			Id = 8401 ; 
			Guild = "Prairie Dog Vendor";
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 30 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1224 ;
			NpcFlags = (int)NpcActions.Vendor ;
			CombatReach = 4.05f ;
			SetDamage ( 32, 42 );
			NpcText00 = "Greetings $N, I am Halpa." ;
			BaseMana = 0 ;
			Sells = new Item[] { new PrairieDogWhistle()
							   } ;
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 22395, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class DonniAnthania : BaseCreature 
	{ 
		public  DonniAnthania() : base() 
		{ 
			Model = 5086;
			AttackSpeed= 1500;
			BoundingRadius = 0.208000f ;
			Name = "Donni Anthania" ;
			Flags1 = 0x08480046 ;
			Id = 6367 ; 
			Guild = "Crazy Cat Lady";
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 5 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 100 ;
			NpcFlags = (int)NpcActions.Vendor ;
			CombatReach = 1.5f ;
			SetDamage ( 5, 6 );
			NpcText00 = "Greetings $N, I am Donni Anthania." ;
			BaseMana = 0 ;
			Sells = new Item[] { new CatCarrierBombay()
								   , new CatCarrierCornishRex()
								   , new CatCarrierOrangeTabby()
								   , new CatCarrierSilverTabby()
								   , new CatCarrierWhiteKitten()
								   , new CatCarrierSiamese()
							   } ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 7431, InventoryTypes.OneHand, 2, 0, 1, 3, 0, 0, 0 ));
		}
	}
	public class PridewingSoarer : BaseCreature 
	{ 
		public  PridewingSoarer() : base() 
		{ 
			Model = 2155;
			AttackSpeed= 2000;
			BoundingRadius = 0.850000f ;
			Name = "Pridewing Soarer" ;
			Flags1 = 0x0266 ;
			Id = 6141 ; 
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 22 );
			NpcType = (int)NpcTypes.Beast ;
			BaseHitPoints = 784 ;
			NpcFlags = 0 ;
			CombatReach = 1.7f ;
			SetDamage ( 32, 42 );
			NpcText00 = "Hello" ;
			BaseMana = 0 ;
			Sells = new Item[] { new PridewingVenomSac()
							   } ;
			Faction = Factions.NoFaction;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
	public class Brine : BaseCreature 
	{ 
		public  Brine() : base() 
		{ 
			Model = 4536;
			AttackSpeed= 2000;
			BoundingRadius = 0.236000f ;
			Name = "Brine" ;
			Flags1 = 0x08400046 ;
			Id = 5899 ; 
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 23 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 904 ;
			NpcFlags = (int)NpcActions.Vendor ;
			CombatReach = 1.5f ;
			SetDamage ( 24, 31 );
			NpcText00 = "Hello" ;
			BaseMana = 581 ;
			Sells = new Item[] { new TinOre()
								   , new CoarseStone()
							   } ;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 11289, InventoryTypes.OneHand, 2, 4, 2, 3, 0, 0, 0 ));
		}
	}
	public class GwynFarrow : BaseCreature 
	{ 
		public  GwynFarrow() : base() 
		{ 
			Model = 4528;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Gwyn Farrow" ;
			Flags1 = 0x08480046 ;
			Id = 5886 ; 
			Guild = "Mushroom Merchant";
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 16 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 424 ;
			NpcFlags = (int)NpcActions.Vendor ;
			CombatReach = 1.5f ;
			SetDamage ( 10, 14 );
			NpcText00 = "Greetings $N, I am Gwyn Farrow." ;
			BaseMana = 0 ;
			Sells = new Item[] { new ForestMushroomCap()
								   , new RedSpeckledMushroom()
								   , new SpongyMorel()
								   , new DeliciousCaveMold()
								   , new RawBlackTruffle()
								   , new DriedKingBolete()
							   } ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 7495, InventoryTypes.TwoHanded, 2, 6, 1, 2, 0, 0, 0 ), new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
		}
	}
	public class FizzlebangBooms : BaseCreature 
	{ 
		public  FizzlebangBooms() : base() 
		{ 
			Model = 3457;
			AttackSpeed= 2000;
			BoundingRadius = 0.351900f ;
			Name = "Fizzlebang Booms" ;
			Flags1 = 0x08480046 ;
			Id = 5569 ; 
			Guild = "Fireworks Vendor";
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 40 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1625 ;
			NpcFlags = (int)NpcActions.Vendor ;
			CombatReach = 1.725f ;
			SetDamage ( 43, 56 );
			NpcText00 = "Greetings $N, I am Fizzlebang Booms." ;
			BaseMana = 0 ;
			Sells = new Item[] { new RedFireworksRocket()
							   } ;
			Faction = Factions.GnomereganExiles;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 5569, InventoryTypes.OneHand, 2, 14, 1, 7, 0, 0, 0 ), new Item( 6593, InventoryTypes.RangeRight, 2, 3, 1, 0, 0, 0, 0 ));

		}
	}
	public class ApothecaryFaustin : BaseCreature 
	{ 
		public  ApothecaryFaustin() : base() 
		{ 
			Model = 4341;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Apothecary Faustin" ;
			Flags1 = 0x08400046 ;
			Id = 5414 ; 
			Guild = "Royal Apothecary Society";
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 40 );
			NpcType = (int)NpcTypes.Undead;
			BaseHitPoints = 1625 ;
			NpcFlags = (int)NpcActions.Vendor ;
			CombatReach = 1.5f ;
			SetDamage ( 43, 56 );
			NpcText00 = "Greetings $N, I am Apothecary Faustin." ;
			BaseMana = 0 ;
			Sells = new Item[] { new MelonJuice()
								   , new IronOre()
							   } ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 7445, InventoryTypes.OneHand, 2, 14, 1, 7, 0, 0, 0 ), new Item( 6530, InventoryTypes.HeldInHand, 4, 0, 2, 7, 0, 0, 0 ));
		}
	}

	public class Thrumn : BaseNPC 
	{ 
		public  Thrumn() : base() 
		{ 
			Model = 3129;
			AttackSpeed= 2000;
			BoundingRadius = 0.974700f ;
			Name = "Thrumn" ;
			Flags1 = 0x08480046 ;
			Id = 5189 ; 
			Guild = "Tabard Vendor";
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 25 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1024 ;
			NpcFlags = (int)NpcActions.Tabard ;
			CombatReach = 4.05f ;
			SetDamage ( 27, 35 );
			NpcText00 = "Welcome to our Guild Registry offices.What can I help you with today ?" ;
			BaseMana = 0 ;
			Sells = new Item[] { new GuildTabard()
							   } ;
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 19549, InventoryTypes.OneHand, 2, 0, 1, 3, 0, 0, 0 ));
		}
	}
	public class MerillPleasance : BaseCreature 
	{ 
		public  MerillPleasance() : base() 
		{ 
			Model = 3130;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Merill Pleasance" ;
			Flags1 = 0x018480046 ;
			Id = 5190 ; 
			Guild = "Tabard Vendor";
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 25 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1024 ;
			NpcFlags = 2 ;
			CombatReach = 1.5f ;
			SetDamage ( 27, 35 );
			NpcText00 = "Welcome to our Guild Registry offices.What can I help you with today ?" ;
			BaseMana = 0 ;
			Sells = new Item[] { new GuildTabard()
							   } ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7461, InventoryTypes.OneHand, 2, 14, 1, 7, 0, 0, 0 ));
		}
	}
	public class Shalumon : BaseCreature 
	{ 
		public  Shalumon() : base() 
		{ 
			Model = 3131;
			AttackSpeed= 2000;
			BoundingRadius = 0.389000f ;
			Name = "Shalumon" ;
			Flags1 = 0x08480046 ;
			Id = 5191 ; 
			Guild = "Tabard Vendor";
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 25 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1024 ;
			NpcFlags = (int)NpcActions.Tabard ;
			CombatReach = 1.5f ;
			SetDamage ( 27, 35 );
			NpcText00 = "Welcome to our Guild Registry offices.What can I help you with today ?" ;
			BaseMana = 0 ;
			Sells = new Item[] { new GuildTabard()
							   } ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
	public class NilsStonebrow : BaseCreature 
	{ 
		public  NilsStonebrow() : base() 
		{ 
			Model = 262;
			AttackSpeed= 2100;
			BoundingRadius = 1.00f ;
			Name = "Nils Stonebrow" ;
			Flags1 = 0x102 ;
			Id = 5192 ; 
			Guild = "Tabard Vendor";
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 1 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 64 ;
			NpcFlags = (int)NpcActions.Tabard ;
			CombatReach = 11.00f ;
			SetDamage ( 0, 1 );
			NpcText00 = "Welcome to our Guild Registry offices.What can I help you with today ?" ;
			BaseMana = 20 ;
			Faction = Factions.Friend;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
		}
	}
	public class RebeccaLaughlin : BaseCreature 
	{ 
		public  RebeccaLaughlin() : base() 
		{ 
			Model = 3133;
			AttackSpeed= 2000;
			BoundingRadius = 0.208000f ;
			Name = "Rebecca Laughlin" ;
			Flags1 = 0x08480046 ;
			Id = 5193 ; 
			Guild = "Tabard Vendor";
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 25 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1024 ;
			NpcFlags = (int)NpcActions.Tabard ;
			CombatReach = 1.5f ;
			SetDamage ( 27, 35 );
			NpcText00 = "Welcome to the Stormwind Guild Registry offices.What can I help you with today ?" ;
			BaseMana = 0 ;
			Sells = new Item[] { new GuildTabard()
							   } ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
	public class Garyl : BaseCreature 
	{ 
		public  Garyl() : base() 
		{ 
			Model = 3128;
			AttackSpeed= 1739;
			BoundingRadius = 0.236000f ;
			Name = "Garyl" ;
			Flags1 = 0x08480046 ;
			Id = 5188 ; 
			Guild = "Tabard Vendor";
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 30 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1224 ;
			NpcFlags = (int)NpcActions.Tabard ;
			CombatReach = 1.5f ;
			SetDamage ( 32, 42 );
			NpcText00 = "Welcome to our Guild Registry offices.What can I help you with today ?" ;
			BaseMana = 0 ;
			Sells = new Item[] { new GuildTabard()
							   } ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 6454, InventoryTypes.OneHand, 2, 15, 1, 3, 0, 0, 0 ), new Item( 23172, InventoryTypes.HeldInHand, 4, 0, 1, 0, 0, 0, 0 ));
		}
	}
	public class LyesaSteelbrow : BaseCreature 
	{ 
		public  LyesaSteelbrow() : base() 
		{ 
			Model = 2999;
			AttackSpeed= 2000;
			BoundingRadius = 0.347000f ;
			Name = "Lyesa Steelbrow" ;
			Flags1 = 0x08480046 ;
			Id = 5049 ; 
			Guild = "Tabard Vendor";
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 25 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1024 ;
			NpcFlags = (int)NpcActions.Tabard ;
			CombatReach = 1.5f ;
			SetDamage ( 27, 35 );
			NpcText00 = "Greetings $N, I am Lyesa Steelbrow." ;
			BaseMana = 0 ;
			Sells = new Item[] { new GuildTabard()
							   } ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7434, InventoryTypes.OneHand, 2, 15, 1, 3, 0, 0, 0 ));
		}
	}

	public class Lelanai : BaseCreature 
	{ 
		public  Lelanai() : base() 
		{ 
			Model = 2788;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Lelanai" ;
			Flags1 = 0x08480046 ;
			Id = 4730 ; 
			Guild = "Tiger Handler";
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 35 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1424 ;
			NpcFlags = (int)NpcActions.Vendor ;
			CombatReach = 1.5f ;
			SetDamage ( 38, 49 );
			NpcText00 = "Hello" ;
			BaseMana = 0 ;
			Sells = new Item[] { new ReinsOfTheFrostsaber()
								   , new ReinsOfTheNightsaber()
								   , new ReinsOfTheSwiftFrostsaber()
								   , new ReinsOfTheSwiftFrostsaber()
								   , new ReinsOfTheSwiftMistsaber()
								   , new ReinsOfTheSwiftMistsaber()
								   , new ReinsOfTheSwiftStormsaber()
								   , new ReinsOfTheSwiftStormsaber()
								   , new ReinsOfTheStripedNightsaber()
								   , new ReinsOfTheStripedNightsaber()
								   , new ReinsOfTheStripedFrostsaber()
								   , new ReinsOfTheStripedFrostsaber()
								   , new ReinsOfTheSpottedFrostsaber()
								   , new ReinsOfTheSpottedFrostsaber()
							   } ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
	public class MorleyBates : BaseCreature 
	{ 
		public  MorleyBates() : base() 
		{ 
			Model = 2640;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Morley Bates" ;
			Flags1 = 0x018480046 ;
			Id = 4571 ; 
			Guild = "Fungus Vendor";
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 30 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1224 ;
			NpcFlags = (int)NpcActions.Vendor ;
			CombatReach = 1.5f ;
			SetDamage ( 32, 42 );
			NpcText00 = "Greetings $N, I am Morley Bates." ;
			BaseMana = 0 ;
			Sells = new Item[] { new IceColdMilk()
								   , new MelonJuice()
								   , new RefreshingSpringWater()
								   , new MoonberryJuice()
								   , new SweetNectar()
								   , new ForestMushroomCap()
								   , new RedSpeckledMushroom()
								   , new SpongyMorel()
								   , new DeliciousCaveMold()
								   , new RawBlackTruffle()
								   , new MorningGloryDew()
								   , new DriedKingBolete()
							   } ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7495, InventoryTypes.TwoHanded, 2, 6, 1, 2, 0, 0, 0 ));
		}
	}
	public class TawnyGrisette : BaseCreature 
	{ 
		public  TawnyGrisette() : base() 
		{ 
			Model = 2674;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Tawny Grisette" ;
			Flags1 = 0x018480046 ;
			Id = 4554 ; 
			Guild = "Mushroom Vendor";
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 30 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1224 ;
			NpcFlags = (int)NpcActions.Vendor ;
			CombatReach = 1.5f ;
			SetDamage ( 32, 42 );
			NpcText00 = "Greetings $N, I am Tawny Grisette." ;
			BaseMana = 0 ;
			Sells = new Item[] { new IceColdMilk()
								   , new MelonJuice()
								   , new RefreshingSpringWater()
								   , new MoonberryJuice()
								   , new SweetNectar()
								   , new ForestMushroomCap()
								   , new RedSpeckledMushroom()
								   , new SpongyMorel()
								   , new DeliciousCaveMold()
								   , new RawBlackTruffle()
								   , new MorningGloryDew()
								   , new DriedKingBolete()
							   } ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 1600, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class Griznak : BaseCreature 
	{ 
		public  Griznak() : base() 
		{ 
			Model = 7214;
			AttackSpeed= 1623;
			BoundingRadius = 1.00f ;
			Name = "Griznak" ;
			Flags1 = 0x06E ;
			Id = 4445 ; 
			Guild = "Race Vendor";
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 35 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1424 ;
			NpcFlags = (int)NpcActions.Vendor ;
			CombatReach = 11.00f ;
			SetDamage ( 38, 49 );
			NpcText00 = "Greetings $N, I am Griznak." ;
			BaseMana = 1754 ;
			Sells = new Item[] { new GoblinVoucher()
							   } ;
			Faction = Factions.Friend;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
	public class Talaelar : BaseCreature 
	{ 
		public  Talaelar() : base() 
		{ 
			Model = 2267;
			AttackSpeed= 2000;
			BoundingRadius = 0.389000f ;
			Name = "Talaelar" ;
			Flags1 = 0x08480046 ;
			Id = 4221 ; 
			Guild = "Fish Vendor";
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 30 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1224 ;
			NpcFlags = (int)NpcActions.Vendor ;
			CombatReach = 1.5f ;
			SetDamage ( 32, 42 );
			NpcText00 = "Greetings $N, I am Talaelar." ;
			BaseMana = 0 ;
			Sells = new Item[] { new LongjawMudSnapper()
								   , new BristleWhiskerCatfish()
								   , new RockscaleCod()
								   , new SpottedYellowtail()
								   , new SlitherskinMackerel()
								   , new SpinefinHalibut()
							   } ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7453, InventoryTypes.OneHand, 2, 4, 2, 2, 0, 0, 0 ));
		}
	}
	public class FahranSilentblade : BaseCreature 
	{ 
		public  FahranSilentblade() : base() 
		{ 
			Model = 2059;
			AttackSpeed= 2000;
			BoundingRadius = 0.389000f ;
			Name = "Fahran Silentblade" ;
			Flags1 = 0x08480046 ;
			Id = 3969 ; 
			Guild = "Tools & Supplies";
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 28 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1144 ;
			NpcFlags = (int)NpcActions.Vendor ;
			CombatReach = 1.5f ;
			SetDamage ( 30, 39 );
			NpcText00 = "Greetings $N, I am Fahran Silentblade." ;
			BaseMana = 0 ;
			Sells = new Item[] { new DustOfDecay()
								   , new EssenceOfPain()
								   , new EmptyVial()
								   , new LeadedVial()
								   , new LethargyRoot()
								   , new ThievesTools()
								   , new FlashPowder()
								   , new Deathweed()
								   , new EssenceOfAgony()
								   , new DustOfDeterioration()
								   , new CrystalVial()
							   } ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7494, InventoryTypes.OneHand, 2, 4, 2, 7, 0, 0, 0 ), new Item( 6536, InventoryTypes.HeldInHand, 4, 0, 2, 0, 0, 0, 0 ));
		}
	}
	public class Biletoad : BaseCreature 
	{ 
		public  Biletoad() : base() 
		{ 
			Model = 1924;
			AttackSpeed= 2000;
			BoundingRadius = 0.200000f ;
			Name = "Biletoad" ;
			Flags1 = 0x06 ;
			Id = 3835 ; 
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 1 );
			NpcType = (int)NpcTypes.Critter ;
			BaseHitPoints = 64 ;
			NpcFlags = 00 ;
			CombatReach = 0f ;
			SetDamage ( 0, 1 );
			NpcText00 = "Hello" ;
			BaseMana = 0 ;
			Sells = new Item[] { new Serpentbloom()
							   } ;
			Faction = Factions.Monster;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
		}
	}
	public class JasonLemieux : BaseCreature 
	{ 
		public  JasonLemieux() : base() 
		{ 
			Model = 3676;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Jason Lemieux" ;
			Flags1 = 0x08480046 ;
			Id = 3544 ; 
			Guild = "Mushroom Seller";
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 40 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1625 ;
			NpcFlags = (int)NpcActions.Vendor ;
			CombatReach = 1.5f ;
			SetDamage ( 43, 56 );
			NpcText00 = "Greetings $N, I am Jason Lemieux." ;
			BaseMana = 0 ;
			Sells = new Item[] { new ForestMushroomCap()
								   , new RedSpeckledMushroom()
								   , new SpongyMorel()
								   , new DeliciousCaveMold()
								   , new RawBlackTruffle()
								   , new DriedKingBolete()
							   } ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 23316, InventoryTypes.OneHand, 2, 14, 1, 0, 0, 0, 0 ));
		}
	}
	public class HalMcAllister : BaseCreature 
	{ 
		public  HalMcAllister() : base() 
		{ 
			Model = 3697;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Hal McAllister" ;
			Flags1 = 0x08480046 ;
			Id = 3540 ; 
			Guild = "Fish Merchant";
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 40 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1625 ;
			NpcFlags = (int)NpcActions.Vendor ;
			CombatReach = 1.5f ;
			SetDamage ( 43, 56 );
			NpcText00 = "Greetings $N, I am Hal McAllister." ;
			BaseMana = 0 ;
			Sells = new Item[] { new LongjawMudSnapper()
								   , new BristleWhiskerCatfish()
								   , new RockscaleCod()
								   , new SpottedYellowtail()
								   , new SlitherskinMackerel()
								   , new SpinefinHalibut()
							   } ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 7453, InventoryTypes.OneHand, 2, 4, 2, 2, 0, 0, 0 ));
		}
	}
	public class Zixil : BaseCreature 
	{ 
		public  Zixil() : base() 
		{ 
			Model = 7133;
			AttackSpeed= 2000;
			BoundingRadius = 0.275400f ;
			Name = "Zixil" ;
			Flags1 = 0x080006 ;
			Id = 3537 ; 
			Guild = "Merchant Supreme";
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 32 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1304 ;
			NpcFlags = (int)NpcActions.Vendor ;
			CombatReach = 1.35f ;
			SetDamage ( 35, 45 );
			NpcText00 = "Greetings $N, I am Zixil." ;
			BaseMana = 0 ;
			Sells = new Item[] { new WizardsBelt()
								   , new NightwindBelt()
								   , new DreamersBelt()
								   , new FireproofOrb()
								   , new StrengthOfWill()
								   , new OrbOfPower()
								   , new PatternRedWoolenBag()
								   , new SoulShard()
								   , new FormulaEnchantBootsMinorAgility()
								   , new PatternEarthenLeatherShoulders()
								   , new SchematicGoblinJumperCables()
							   } ;
			Faction = Factions.BootyBay;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 5569, InventoryTypes.OneHand, 2, 14, 1, 7, 0, 0, 0 ), new Item( 6537, InventoryTypes.HeldInHand, 4, 0, 7, 0, 0, 0, 0 ));
		}
	}
	public class OgunaroWolfrunner : BaseCreature 
	{ 
		public  OgunaroWolfrunner() : base() 
		{ 
			Model = 1384;
			AttackSpeed= 2000;
			BoundingRadius = 0.372000f ;
			Name = "Ogunaro Wolfrunner" ;
			Flags1 = 0x08480046 ;
			Id = 3362 ; 
			Guild = "Kennel Master";
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 45 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1825 ;
			NpcFlags = (int)NpcActions.Vendor ;
			CombatReach = 1.5f ;
			SetDamage ( 49, 63 );
			NpcText00 = "I only make my mounts available to those who are considered exalted to Orgrimmar and the Orcish race.  Go prove yourself to us, and I'll make my mighty wolves abailable for your inspection." ;
			BaseMana = 0 ;
			Sells = new Item[] { new HornOfTheTimberWolf()
								   , new HornOfTheTimberWolf()
								   , new HornOfTheRedWolf()
								   , new HornOfTheArcticWolf()
								   , new HornOfTheSwiftBrownWolf()
								   , new HornOfTheSwiftBrownWolf()
								   , new HornOfTheSwiftTimberWolf()
								   , new HornOfTheSwiftTimberWolf()
								   , new HornOfTheSwiftGrayWolf()
								   , new HornOfTheSwiftGrayWolf()
								   , new HornOfTheDireWolf()
								   , new HornOfTheDireWolf()
								   , new HornOfTheBrownWolf()
								   , new HornOfTheBrownWolf()
							   } ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7419, InventoryTypes.OneHand, 2, 7, 1, 3, 0, 0, 0 ));
		}
	}
	public class Kiro : BaseCreature 
	{ 
		public  Kiro() : base() 
		{ 
			Model = 1381;
			AttackSpeed= 2000;
			BoundingRadius = 0.236000f ;
			Name = "Kiro" ;
			Flags1 = 0x08480046 ;
			Id = 3359 ; 
			Guild = "War Harness Maker";
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 30 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1224 ;
			NpcFlags = (int)NpcActions.Vendor ;
			CombatReach = 1.5f ;
			SetDamage ( 32, 42 );
			NpcText00 = "Greetings $N, I am Kiro." ;
			BaseMana = 0 ;
			Sells = new Item[] { new BuckledHarness()
								   , new StuddedLeatherHarness()
								   , new GruntsHarness()
								   , new BattleHarness()
							   } ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 5569, InventoryTypes.OneHand, 2, 14, 1, 7, 0, 0, 0 ));
		}
	}
	public class Korjus : BaseCreature 
	{ 
		public  Korjus() : base() 
		{ 
			Model = 1329;
			AttackSpeed= 1739;
			BoundingRadius = 0.372000f ;
			Name = "Kor'jus" ;
			Flags1 = 0x08480046 ;
			Id = 3329 ; 
			Guild = "Mushroom Vendor";
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 30 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1224 ;
			NpcFlags = (int)NpcActions.Vendor ;
			CombatReach = 1.5f ;
			SetDamage ( 32, 42 );
			NpcText00 = "Greetings $N, I am Kor'jus." ;
			BaseMana = 0 ;
			Sells = new Item[] { new ForestMushroomCap()
								   , new RedSpeckledMushroom()
								   , new SpongyMorel()
								   , new DeliciousCaveMold()
								   , new RawBlackTruffle()
								   , new DriedKingBolete()
							   } ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7495, InventoryTypes.TwoHanded, 2, 6, 1, 2, 0, 0, 0 ));
		}
	}
	public class GreishanIronstove : BaseCreature 
	{ 
		public  GreishanIronstove() : base() 
		{ 
			Model = 1837;
			AttackSpeed= 2000;
			BoundingRadius = 0.347000f ;
			Name = "Greishan Ironstove" ;
			Flags1 = 0x08480046 ;
			Id = 3291 ; 
			Guild = "Traveling Merchant";
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 24 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 984 ;
			NpcFlags = (int)NpcActions.Vendor ;
			CombatReach = 1.5f ;
			SetDamage ( 26, 33 );
			NpcText00 = "Greetings $N, I am Greishan Ironstove." ;
			BaseMana = 0 ;
			Sells = new Item[] { new ToughHunkOfBread()
								   , new FreshlyBakedBread()
								   , new MoistCornbread()
								   , new MulgoreSpiceBread()
								   , new SoftBananaBread()
								   , new SoulShard()
								   , new HomemadeCherryPie()
							   } ;
			Faction = Factions.IronForge;
			AIEngine = new TravellerSalesmanAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
	public class MishaTorkren : BaseCreature 
	{ 
		public  MishaTorkren() : base() 
		{ 
			Model = 3750;
			AttackSpeed= 2000;
			BoundingRadius = 0.236000f ;
			Name = "Misha Tor'kren" ;
			Flags1 = 0x08400046 ;
			Id = 3193 ; 
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 5 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 224 ;
			NpcFlags = 2 ;
			CombatReach = 1.5f ;
			SetDamage ( 5, 6 );
			NpcText00 = "Greetings $N, I am Misha Tor'kren." ;
			BaseMana = 0 ;
			Sells = new Item[] { new Peacebloom()
							   } ;
			Faction = Factions.Ogrimmar;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
		}
	}
	public class DarkIronEntrepreneur : BaseCreature 
	{ 
		public  DarkIronEntrepreneur() : base() 
		{ 
			Model = 3471;
			AttackSpeed= 2000;
			BoundingRadius = 0.347000f ;
			Name = "Dark Iron Entrepreneur" ;
			Flags1 = 0x080066 ;
			Id = 3180 ; 
			Guild = "Speciality Goods";
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 31 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1224 ;
			NpcFlags = (int)NpcActions.Vendor ;
			CombatReach = 1.5f ;
			SetDamage ( 32, 42 );
			NpcText00 = "Greetings $N, I am Dark Iron Entrepreneur." ;
			BaseMana = 0 ;
			Sells = new Item[] { new HeavyDynamite()
								   , new BlurredAxe()
								   , new CallousAxe()
								   , new MarauderAxe()
								   , new SaberLeggings()
								   , new StalkingPants()
								   , new MysticSarong()
								   , new GloriousShoulders()
								   , new EliteShoulders()
								   , new RedFireworksRocket()
							   } ;
			Faction = Factions.Friend;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
	public class ScottCarevin : BaseCreature 
	{ 
		public  ScottCarevin() : base() 
		{ 
			Model = 4339;
			AttackSpeed= 1000;
			BoundingRadius = 0.306000f ;
			Name = "Scott Carevin" ;
			Flags1 = 0x08480046 ;
			Id = 3138 ; 
			Guild = "Mushroom Seller";
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 25 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1024 ;
			NpcFlags = (int)NpcActions.Vendor ;
			CombatReach = 1.5f ;
			SetDamage ( 27, 35 );
			NpcText00 = "Greetings $N, I am Scott Carevin." ;
			BaseMana = 0 ;
			Sells = new Item[] { new ForestMushroomCap()
								   , new RedSpeckledMushroom()
								   , new SpongyMorel()
								   , new DeliciousCaveMold()
								   , new RawBlackTruffle()
								   , new DriedKingBolete()
							   } ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
	public class Kzixx : BaseCreature 
	{ 
		public  Kzixx() : base() 
		{ 
			Model = 7131;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Kzixx" ;
			Flags1 = 0x08080006 ;
			Id = 3134 ; 
			Guild = "Rare Goods";
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 25 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1024 ;
			NpcFlags = (int)NpcActions.Vendor ;
			CombatReach = 1.5f ;
			SetDamage ( 27, 35 );
			NpcText00 = "Greetings $N, I am Kzixx." ;
			BaseMana = 0 ;
			Sells = new Item[] { new LesserManaPotion()
								   , new WizardsBelt()
								   , new NightwindBelt()
								   , new DreamersBelt()
								   , new FireproofOrb()
								   , new StrengthOfWill()
								   , new OrbOfPower()
								   , new RecipeHolyProtectionPotion()
								   , new SchematicGoblinJumperCables()
								   , new HealingPotion()
							   } ;
			Faction = Factions.BootyBay;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
	public class SuraWildmane : BaseCreature 
	{ 
		public  SuraWildmane() : base() 
		{ 
			Model = 2125;
			AttackSpeed= 2000;
			BoundingRadius = 0.872500f ;
			Name = "Sura Wildmane" ;
			Flags1 = 0x08480046 ;
			Id = 3023 ; 
			Guild = "War Harness Vendor";
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 30 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1224 ;
			NpcFlags = (int)NpcActions.Vendor ;
			CombatReach = 3.75f ;
			SetDamage ( 32, 42 );
			NpcText00 = "Greetings $N, I am Sura Wildmane." ;
			BaseMana = 0 ;
			Sells = new Item[] { new BuckledHarness()
								   , new StuddedLeatherHarness()
								   , new GruntsHarness()
								   , new BattleHarness()
							   } ;
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 1599, InventoryTypes.TwoHanded, 2, 10, 2, 7, 0, 0, 0 ));
		}
	}
	public class SeerWiserunner : BaseCreature 
	{ 
		public  SeerWiserunner() : base() 
		{ 
			Model = 3815;
			AttackSpeed= 2000;
			BoundingRadius = 0.974700f ;
			Name = "Seer Wiserunner" ;
			Flags1 = 0x08400046 ;
			Id = 2984 ; 
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 11 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 464 ;
			NpcFlags = 2 ;
			CombatReach = 4.05f ;
			SetDamage ( 11, 15 );
			NpcText00 = "Greetings $N, I am Seer Wiserunner." ;
			BaseMana = 0 ;
			Sells = new Item[] { new RefreshingSpringWater()
								   , new CopperOre()
								   , new RoughStone()
							   } ;
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
		}
	}
	public class ProspectorRyedol : BaseCreature 
	{ 
		public  ProspectorRyedol() : base() 
		{ 
			Model = 4900;
			AttackSpeed= 2000;
			BoundingRadius = 0.347000f ;
			Name = "Prospector Ryedol" ;
			Flags1 = 0x08480046 ;
			Id = 2910 ; 
			Guild = "Explorers' League";
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 35 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1424 ;
			NpcFlags = 2 ;
			CombatReach = 1.5f ;
			SetDamage ( 38, 49 );
			NpcText00 = "Greetings $N, I am Prospector Ryedol." ;
			BaseMana = 0 ;
			Sells = new Item[] { new SweetNectar()
							   } ;
			Faction = Factions.Alliance;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 12236, InventoryTypes.OneHand, 2, 4, 2, 7, 0, 0, 0 ));
		}
	}
	public class CrazkSparks : BaseCreature 
	{ 
		public  CrazkSparks() : base() 
		{ 
			Model = 7181;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Crazk Sparks" ;
			Flags1 = 0x08080046 ;
			Id = 2838 ; 
			Guild = "Fireworks Merchant";
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 46 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1865 ;
			NpcFlags = (int)NpcActions.Vendor ;
			CombatReach = 1.5f ;
			SetDamage ( 50, 65 );
			NpcText00 = "Greetings $N, I am Crazk Sparks." ;
			BaseMana = 0 ;
			Sells = new Item[] { new SchematicGreenFirework()
								   , new RedFireworksRocket()
							   } ;
			Faction = Factions.BootyBay;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 26367, InventoryTypes.OneHand, 2, 4, 2, 7, 0, 0, 0 ));
		}
	}
	public class Bale : BaseCreature 
	{ 
		public  Bale() : base() 
		{ 
			Model = 2128;
			AttackSpeed= 1623;
			BoundingRadius = 1.00f ;
			Name = "Bale" ;
			Flags1 = 0x08480046 ;
			Id = 2806 ; 
			Guild = "Survival Trainer";
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 35 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1825 ;
			NpcFlags = (int)NpcActions.Vendor ;
			CombatReach = 11.00f ;
			SetDamage ( 49, 63 );
			NpcText00 = "Greetings $N, I am Bale." ;
			BaseMana = 1754 ;
			Sells = new Item[] { new AccurateSlugs()
								   , new JaggedArrow()
								   , new IceColdMilk()
								   , new MelonJuice()
								   , new GleamingThrowingAxe()
								   , new WickedThrowingDagger()
								   , new RefreshingSpringWater()
								   , new RecipeMonsterOmelet()
								   , new MoonberryJuice()
								   , new SweetNectar()
								   , new SharpArrow()
								   , new HeavyShot()
								   , new RazorArrow()
								   , new SolidShot()
								   , new KeenThrowingKnife()
								   , new HeavyThrowingDagger()
								   , new SharpThrowingAxe()
								   , new DeadlyThrowingAxe()
								   , new SimpleWood()
								   , new FlintAndTinder()
								   , new HeavyBrownBag()
								   , new BrownLeatherSatchel()
							   } ;
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
	public class WennaSilkbeard : BaseCreature 
	{ 
		public  WennaSilkbeard() : base() 
		{ 
			Model = 1620;
			AttackSpeed= 2000;
			BoundingRadius = 0.347000f ;
			Name = "Wenna Silkbeard" ;
			Flags1 = 0x08480046 ;
			Id = 2679 ; 
			Guild = "Special Goods Dealer";
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 28 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1184 ;
			NpcFlags = (int)NpcActions.Vendor ;
			CombatReach = 1.5f ;
			SetDamage ( 31, 41 );
			NpcText00 = "Greetings $N, I am Wenna Silkbeard." ;
			BaseMana = 0 ;
			Sells = new Item[] { new WizardsBelt()
								   , new NightwindBelt()
								   , new DreamersBelt()
								   , new SaberLeggings()
								   , new StalkingPants()
								   , new MysticSarong()
								   , new GloriousShoulders()
								   , new EliteShoulders()
								   , new PatternAzureSilkGloves()
								   , new PatternRedWhelpGloves()
								   , new PatternGreenLeatherArmor()
							   } ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
	public class ArchmageAnsiremRuneweaver : BaseCreature 
	{ 
		public  ArchmageAnsiremRuneweaver() : base() 
		{ 
			Model = 1595;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Archmage Ansirem Runeweaver" ;
			Flags1 = 0x080006 ;
			Id = 2543 ; 
			Guild = "Kirin Tor";
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 40 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1585 ;
			NpcFlags = 2 ;
			CombatReach = 1.5f ;
			SetDamage ( 42, 55 );
			NpcText00 = "Greetings $N, I am Archmage Ansirem Runeweaver." ;
			BaseMana = 3191 ;
			Sells = new Item[] { new GryphonFeatherQuill()
								   , new BrokenWand()
							   } ;
			Faction = Factions.Monster;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
			Equip( new Item( 22178, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
		}
	}
	public class DerakNightfall : BaseCreature 
	{ 
		public  DerakNightfall() : base() 
		{ 
			Model = 3652;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Derak Nightfall" ;
			Flags1 = 0x08400046 ;
			Id = 2397 ; 
			Guild = "Cook";
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 32 );
			NpcType = (int)NpcTypes.Undead;
			BaseHitPoints = 1304 ;
			NpcFlags = (int)NpcActions.Vendor ;
			CombatReach = 1.5f ;
			SetDamage ( 35, 45 );
			NpcText00 = "Greetings $N, I am Derak Nightfall." ;
			BaseMana = 0 ;
			Sells = new Item[] { new RefreshingSpringWater()
								   , new MildSpices()
								   , new HotSpices()
								   , new SoothingSpices()
								   , new RecipeBristleWhiskerCatfish()
							   } ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 23317, InventoryTypes.OneHand, 2, 14, 1, 0, 0, 0, 0 ));
		}
	}
	public class JasperFel : BaseCreature 
	{ 
		public  JasperFel() : base() 
		{ 
			Model = 1513;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Jasper Fel" ;
			Flags1 = 0x08480046 ;
			Id = 1325 ; 
			Guild = "Shady Dealer";
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 30 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1224 ;
			NpcFlags = (int)NpcActions.Vendor ;
			CombatReach = 1.5f ;
			SetDamage ( 32, 42 );
			NpcText00 = "Greetings $N, I am Jasper Fel." ;
			BaseMana = 0 ;
			Sells = new Item[] { new DustOfDecay()
								   , new EssenceOfPain()
								   , new EmptyVial()
								   , new LeadedVial()
								   , new LethargyRoot()
								   , new ThievesTools()
								   , new FlashPowder()
								   , new Deathweed()
								   , new EssenceOfAgony()
								   , new DustOfDeterioration()
								   , new CrystalVial()
							   } ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 23172, InventoryTypes.OneHand, 2, 15, 1, 3, 0, 0, 0 ));
		}
	}
	public class AdairGilroy : BaseCreature 
	{ 
		public  AdairGilroy() : base() 
		{ 
			Model = 1485;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Adair Gilroy" ;
			Flags1 = 0x08480046 ;
			Id = 1316 ; 
			Guild = "Librarian";
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 60 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 584 ;
			NpcFlags = (int)NpcActions.Vendor ;
			CombatReach = 1.5f ;
			SetDamage ( 15, 19 );
			NpcText00 = "Greetings $N, I am Adair Gilroy." ;
			BaseMana = 0 ;
			Sells = new Item[] { new EngineersInk()
								   , new BlankParchment()
								   , new ScrollOfStamina()
								   , new ScrollOfSpirit()
								   , new ScrollOfProtectionII()
								   , new ScrollOfStaminaII()
								   , new ScrollOfSpiritII()
								   , new ScrollOfIntellectII()
								   , new ScrollOfAgility()
								   , new ScrollOfProtection()
								   , new ScrollOfStrength()
								   , new ScrollOfIntellect()
							   } ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
			Equip( new Item( 23177, InventoryTypes.OneHand, 2, 14, 1, 0, 0, 0, 0 ));
		}
	}
	public class DarianSingh : BaseCreature 
	{ 
		public  DarianSingh() : base() 
		{ 
			Model = 1487;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Darian Singh" ;
			Flags1 = 0x08480046 ;
			Id = 1304 ; 
			Guild = "Fireworks Vendor";
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 30 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1224 ;
			NpcFlags = (int)NpcActions.Vendor ;
			CombatReach = 1.5f ;
			SetDamage ( 32, 42 );
			NpcText00 = "Greetings $N, I am Darian Singh." ;
			BaseMana = 0 ;
			Sells = new Item[] { new SchematicBlueFirework()
								   , new RedFireworksRocket()
							   } ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 8011, InventoryTypes.OneHand, 2, 4, 2, 3, 0, 0, 0 ));
		}
	}
	public class BernardGump : BaseCreature 
	{ 
		public  BernardGump() : base() 
		{ 
			Model = 1425;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Bernard Gump" ;
			Flags1 = 0x08480046 ;
			Id = 1302 ; 
			Guild = "Florist";
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 30 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1224 ;
			NpcFlags = (int)NpcActions.Vendor ;
			CombatReach = 1.5f ;
			SetDamage ( 32, 42 );
			NpcText00 = "Greetings $N, I am Bernard Gump." ;
			BaseMana = 0 ;
			Sells = new Item[] { new Earthroot()
								   , new Bruiseweed()
								   , new WildSteelbloom()
								   , new Kingsblood()
								   , new Liferoot()
								   , new RedRose()
								   , new BlackRose()
								   , new SimpleWildflowers()
								   , new BeautifulWildflowers()
								   , new BouquetOfWhiteRoses()
								   , new BouquetOfBlackRoses()
								   , new Mageroyal()
							   } ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7447, InventoryTypes.OneHand, 2, 14, 1, 0, 0, 0, 0 ));
		}
	}
	public class YarlynAmberstill : BaseCreature 
	{ 
		public  YarlynAmberstill() : base() 
		{ 
			Model = 1981;
			AttackSpeed= 2000;
			BoundingRadius = 0.208200f ;
			Name = "Yarlyn Amberstill" ;
			Flags1 = 0x08006E ;
			Id = 1263 ; 
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 1 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 64 ;
			NpcFlags = (int)NpcActions.Vendor ;
			CombatReach = 0.9f ;
			SetDamage ( 0, 1 );
			NpcText00 = "Hello" ;
			BaseMana = 0 ;
			Sells = new Item[] { new RabbitCrateSnowshoe()
							   } ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
		}
	}
	public class AntonioPerelli : BaseCreature 
	{ 
		public  AntonioPerelli() : base() 
		{ 
			Model = 4416;
			AttackSpeed= 1500;
			BoundingRadius = 0.306000f ;
			Name = "Antonio Perelli" ;
			Flags1 = 0x08480046 ;
			Id = 844 ; 
			Guild = "Traveling Salesman";
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 35 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1424 ;
			NpcFlags = (int)NpcActions.Vendor ;
			CombatReach = 1.5f ;
			SetDamage ( 38, 49 );
			NpcText00 = "Greetings $N, I am Antonio Perelli." ;
			BaseMana = 0 ;
			Sells = new Item[] { new ImbuedVial()
								   , new Earthroot()
								   , new Bruiseweed()
								   , new WildSteelbloom()
								   , new Kingsblood()
								   , new Liferoot()
								   , new EmptyVial()
								   , new LeadedVial()
								   , new IronwoodMaul()
								   , new HeavySpikedMace()
								   , new WolfBracers()
								   , new BearBracers()
								   , new OwlBracers()
								   , new BlessedClaymore()
								   , new ExecutionersSword()
								   , new Mageroyal()
								   , new LesserHealingPotion()
								   , new CrystalVial()
							   } ;
			Faction = Factions.Stormwind;
			AIEngine = new TravellerSalesmanAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 12236, InventoryTypes.OneHand, 2, 4, 2, 7, 0, 0, 0 ));
		}
	}
	public class SvalbradFarmountain : BaseCreature 
	{ 
		public  SvalbradFarmountain() : base() 
		{ 
			Model = 262;
			AttackSpeed= 2100;
			BoundingRadius = 1.00f ;
			Name = "Svalbrad Farmountain" ;
			Flags1 = 0x102 ;
			Id = 5135 ; 
			Guild = "Cartography Supplier";
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 1 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 64 ;
			NpcFlags = (int)NpcActions.Vendor ;
			CombatReach = 11.00f ;
			SetDamage ( 0, 1 );
			NpcText00 = "Greetings $N, I am Svalbrad Farmountain." ;
			BaseMana = 20 ;
			Faction = Factions.Friend;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
		}
	}
	public class Llana : BaseCreature 
	{ 
		public  Llana() : base() 
		{ 
			Model = 2057;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Llana" ;
			Flags1 = 0x08480046 ;
			Id = 3970 ; 
			Guild = "Reagent Supplies";
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 25 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1024 ;
			NpcFlags = (int)NpcActions.Vendor ;
			CombatReach = 1.5f ;
			SetDamage ( 27, 35 );
			NpcText00 = "Greetings $N, I am Llana." ;
			BaseMana = 0 ;
			Sells = new Item[] { new DemonicFigurine()
								   , new ArcaneDust()
								   , new ArcanePowder()
								   , new WildBerries()
								   , new WildRoot()
								   , new WildThornroot()
								   , new ScentedCandle()
								   , new HolyCandle()
								   , new SacredCandle()
								   , new Ankh()
								   , new RuneOfTeleportation()
								   , new RuneOfPortals()
								   , new SymbolOfDivinity()
								   , new MapleSeed()
								   , new StranglethornSeed()
								   , new AshwoodSeed()
								   , new HornbeamSeed()
								   , new IronwoodSeed()
								   , new InfernalStone()
							   } ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 6232, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
		}
	}
	public class Narkk : BaseCreature 
	{ 
		public  Narkk() : base() 
		{ 
			Model = 7190;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Narkk" ;
			Flags1 = 0x08080046 ;
			Id = 2663 ; 
			Guild = "Pirate Supplies";
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 42 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 1705 ;
			NpcFlags = (int)NpcActions.Vendor ;
			CombatReach = 1.5f ;
			SetDamage ( 46, 59 );
			NpcText00 = "Greetings $N, I am Narkk." ;
			BaseMana = 0 ;
			Sells = new Item[] { new PatternBlackSwashbucklersShirt()
								   , new ParrotCageSenegal()
								   , new ParrotCageCockatiel()
							   } ;
			Faction = Factions.BootyBay;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7492, InventoryTypes.OneHand, 2, 7, 1, 3, 0, 0, 0 ));
		}
	}
	public class VernonHale : BaseCreature 
	{ 
		public  VernonHale() : base() 
		{ 
			Model = 3361;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Vernon Hale" ;
			Flags1 = 0x08480046 ;
			Id = 1678 ; 
			Guild = "Bait and Tackle Supplier";
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 10 );
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 424 ;
			NpcFlags = (int)NpcActions.Vendor ;
			CombatReach = 1.5f ;
			SetDamage ( 10, 14 );
			NpcText00 = "Greetings $N, I am Vernon Hale." ;
			BaseMana = 0 ;
			Sells = new Item[] { new LongjawMudSnapper()
								   , new BristleWhiskerCatfish()
								   , new RockscaleCod()
								   , new FishingPole()
								   , new StrongFishingPole()
								   , new ShinyBauble()
								   , new Nightcrawlers()
								   , new BrightBaubles()
								   , new AquadynamicFishAttractor()
								   , new SpottedYellowtail()
								   , new SlitherskinMackerel()
								   , new SpinefinHalibut()
							   } ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			Equip( new Item( 7453, InventoryTypes.OneHand, 2, 4, 2, 2, 0, 0, 0 ));
		}
	}
	public class FarmerSaldean : BaseCreature 
	{ 
		public  FarmerSaldean() : base() 
		{ 
			Model = 1943;
			AttackSpeed= 1500;
			BoundingRadius = 0.306000f ;
			Name = "Farmer Saldean" ;
			Flags1 = 0x08480046 ;
			Id = 233 ; 
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 20 );
			NpcType = 7 ;
			BaseHitPoints = 824 ;
			NpcFlags = (int)NpcActions.Vendor;
			CombatReach = 1.5f ;
			SetDamage ( 21, 28 );
			NpcText00 = "Greetings $N, I am Farmer Saldean." ;
			BaseMana = 0 ;
			Sells = new Item[] { new SpecialChickenFeed()
								   , new ToughHunkOfBread()
								   , new FreshlyBakedBread()
								   , new MoistCornbread()
								   , new MulgoreSpiceBread()
								   , new SoftBananaBread()
								   , new HomemadeCherryPie()
							   } ;
			Faction = Factions.Stormwind;
			Guild = "Farmer" ;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7464, InventoryTypes.TwoHanded, 2, 6, 1, 2, 0, 0, 0 ));
		}
	}

}