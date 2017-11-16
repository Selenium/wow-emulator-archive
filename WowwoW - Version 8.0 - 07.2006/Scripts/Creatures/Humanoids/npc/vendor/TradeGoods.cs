using Server.Items;


namespace Server.Creatures
{
public class Ullanna : BaseCreature 
 { 
public  Ullanna() : base() 
 { 
Model = 4409;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Ullanna" ;
Flags1 = 0x08480046 ;
Id = 4194 ; 
Guild = "Trade Supplies";
Size = 1f;
Speed = 5f ;
WalkSpeed = 5f ;
RunSpeed = 8f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 15 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 624 ;
NpcFlags = (int)NpcActions.Vendor; 
CombatReach = 1.5f ;
SetDamage ( 16, 21 );
NpcText00 = "Greetings $N, I am Ullanna." ;
BaseMana = 0 ;
Sells = new Item[] {new BlacksmithHammer()
, new Bleach()
, new BlueDye()
, new CoarseThread()
, new CopperRod()
, new EmptyVial()
, new FineThread()
, new FishingPole() 
, new GreenDye()
, new HotSpices()
, new MildSpices()
, new MiningPick() 
, new Nightcrawlers()
, new RedDye()
, new Salt()
, new ShinyBauble()
, new SkinningKnife()
, new WeakFlux() } ;
Faction = Factions.Darnasus;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
}
}
public class TharynnBouden : BaseCreature 
 { 
public  TharynnBouden() : base() 
 { 
Model = 1298;
AttackSpeed= 1500;
BoundingRadius = 0.306000f ;
Name = "Tharynn Bouden" ;
Flags1 = 0x08480046 ;
Id = 66 ; 
Size = 1f;
Speed = 5f ;
WalkSpeed = 5f ;
RunSpeed = 8f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 10 );
NpcType = 7 ;
BaseHitPoints = 424 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 10, 14 );
NpcText00 = "Greetings $N, I am Tharynn Bouden." ;
BaseMana = 0 ;
Sells = new Item[] { new CoarseThread()
                           , new Bleach()
                           , new RedDye()
                           , new MildSpices()
                           , new WeakFlux()
                           , new MiningPick()
                           , new EmptyVial()
                           , new Salt()
                           , new BlacksmithHammer()
                           , new CopperRod()
                           , new FishingPole()
                           , new BlueDye()
                           , new PatternBlueLinenVest()
                           , new RecipeBrilliantSmallfish()
                           , new RecipeLongjawMudSnapper()
                           , new ShinyBauble()
                           , new SkinningKnife()
  } ;
Faction = Factions.Stormwind;
Guild = "Trade Supplies" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
}
} 
public class AmyDavenport : BaseCreature 
 { 
public  AmyDavenport() : base() 
 { 
Model = 3366;
AttackSpeed= 2000;
BoundingRadius = 0.208000f ;
Name = "Amy Davenport" ;
Flags1 = 0x08480046 ;
Id = 777 ; 
Size = 1f;
Speed = 5f ;
WalkSpeed = 5f ;
RunSpeed = 8f ;
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
NpcText00 = "Greetings $N, I am Amy Davenport." ;
BaseMana = 0 ;
Sells = new Item[] { new CoarseThread()
                           , new FineThread()
                           , new Bleach()
                           , new MildSpices()
                           , new HotSpices()
                           , new WeakFlux()
                           , new MiningPick()
                           , new DustOfDecay()
                           , new EmptyVial()
                           , new LeadedVial()
                           , new Salt()
                           , new PatternRedWoolenBag()
                           , new BlacksmithHammer()
                           , new MysticalPowder()
                           , new CopperRod()
                           , new FishingPole()
                           , new EnchantedPowder()
                           , new ShinyBauble()
                           , new Nightcrawlers()
                           , new SkinningKnife()
  } ;
Faction = Factions.Stormwind;
Guild = "Trade Goods" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}

public class GinaMacGregor : BaseCreature 
 { 
public  GinaMacGregor() : base() 
 { 
Model = 3260;
AttackSpeed= 1500;
BoundingRadius = 0.208000f ;
Name = "Gina MacGregor" ;
Flags1 = 0x08480046 ;
Id = 843 ; 
Size = 1f;
Speed = 5f ;
WalkSpeed = 5f ;
RunSpeed = 8f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 15 );
NpcType = 7 ;
BaseHitPoints = 624 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 16, 21 );
NpcText00 = "Greetings $N, I am Gina MacGregor." ;
BaseMana = 0 ;
Sells = new Item[] { new CoarseThread()
                           , new FineThread()
                           , new Bleach()
                           , new RedDye()
                           , new GreenDye()
                           , new MildSpices()
                           , new HotSpices()
                           , new WeakFlux()
                           , new MiningPick()
                           , new EmptyVial()
                           , new Salt()
                           , new PatternRedLinenBag()
                           , new PatternMurlocScaleBelt()
                           , new PatternMurlocScaleBreastplate()
                           , new BlacksmithHammer()
                           , new CopperRod()
                           , new FishingPole()
                           , new BlueDye()
                           , new PatternBlueOveralls()
                           , new ShinyBauble()
                           , new Nightcrawlers()
                           , new SkinningKnife()
  } ;
Faction = Factions.Stormwind;
Guild = "Trade Goods" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 12236, InventoryTypes.OneHand, 2, 4, 2, 7, 0, 0, 0 ), new Item( 1684, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
}
}

public class GunderThornbush : BaseCreature 
 { 
public  GunderThornbush() : base() 
 { 
Model = 4336;
AttackSpeed= 1500;
BoundingRadius = 0.306000f ;
Name = "Gunder Thornbush" ;
Flags1 = 0x08480046 ;
Id = 960 ; 
Size = 1f;
Speed = 5f ;
WalkSpeed = 5f ;
RunSpeed = 8f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 30 );
NpcType = 7 ;
BaseHitPoints = 904 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 24, 31 );
NpcText00 = "Greetings $N, I am Gunder Thornbush." ;
BaseMana = 0 ;
Sells = new Item[] { new CoarseThread()
                           , new FineThread()
                           , new Bleach()
                           , new MildSpices()
                           , new HotSpices()
                           , new WeakFlux()
                           , new MiningPick()
                           , new EmptyVial()
                           , new LeadedVial()
                           , new StrongFlux()
                           , new SoothingSpices()
                           , new Coal()
                           , new Salt()
                           , new SilkenThread()
                           , new WoodenStock()
                           , new HeavyStock()
                           , new BlacksmithHammer()
                           , new CopperRod()
                           , new Nightcrawlers()
                           , new BrightBaubles()
  } ;
Faction = Factions.Stormwind;
Guild = "Trade Goods";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7457, InventoryTypes.OneHand, 2, 14, 1, 7, 0, 0, 0 ));
}
}


public class Banalash : BaseCreature 
 { 
public  Banalash() : base() 
 { 
Model = 4559;
AttackSpeed= 2000;
BoundingRadius = 0.372000f ;
Name = "Banalash" ;
Flags1 = 0x08400046 ;
Id = 989 ; 
Size = 1f;
Speed = 5f ;
WalkSpeed = 5f ;
RunSpeed = 8f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 50 );
NpcType = 7 ;
BaseHitPoints = 2025 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 54, 70 );
NpcText00 = "Greetings $N, I am Banalash." ;
BaseMana = 0 ;
Sells = new Item[] { new FormulaEnchantBracerDeflection()
                           , new RecipeCarrionSurprise()
                           , new RecipeSpicedChiliCrab()
                           , new CoarseThread()
                           , new FineThread()
                           , new Bleach()
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
                           , new LethargyRoot()
                           , new Coal()
                           , new Salt()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new WoodenStock()
                           , new HeavyStock()
                           , new BlacksmithHammer()
                           , new CopperRod()
                           , new FishingPole()
                           , new Nightcrawlers()
                           , new BrightBaubles()
                           , new SkinningKnife()
                           , new HeavySilkenThread()
                           , new CrystalVial()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
Guild = "Trade Goods";
}
}

public class Nerrist : BaseCreature 
 { 
public  Nerrist() : base() 
 { 
Model = 4377;
AttackSpeed= 2000;
BoundingRadius = 0.236000f ;
Name = "Nerrist" ;
Flags1 = 0x08400046 ;
Id = 1148 ; 
Size = 1f;
Speed = 5f ;
WalkSpeed = 5f ;
RunSpeed = 8f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 40 );
NpcType = 7 ;
BaseHitPoints = 1625 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 43, 56 );
NpcText00 = "Greetings $N, I am Nerrist." ;
BaseMana = 0 ;
Sells = new Item[] { new RecipeRoastRaptor()
                           , new RecipeJungleStew()
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
                           , new RecipeCuriouslyTastyOmelet()
                           , new SoothingSpices()
                           , new LethargyRoot()
                           , new Coal()
                           , new Salt()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new WoodenStock()
                           , new HeavyStock()
                           , new CopperRod()
                           , new FishingPole()
                           , new Nightcrawlers()
                           , new BrightBaubles()
                           , new SkinningKnife()
                           , new HeavySilkenThread()
                           , new CrystalVial()
  } ;
Faction = Factions.Ogrimmar;
Guild = "Trade Goods";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
}
}

public class DrakeLindgren : BaseCreature 
 { 
public  DrakeLindgren() : base() 
 { 
Model = 3326;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Drake Lindgren" ;
Flags1 = 0x08480046 ;
Id = 1250 ; 
Size = 1f;
Speed = 5f ;
WalkSpeed = 5f ;
RunSpeed = 8f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 10 );
NpcType = 7 ;
BaseHitPoints = 424 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 10, 14 );
NpcText00 = "No one's ever stolen anything out of here. Not in the whole history of... the whole history!" ;
NpcText01 = "Welcome to the Bank of Stormwind. We offer financial accounts and safety deposit boxes for valuable items. Do you already have an account with us $g sir : ma'am"; 
BaseMana = 0 ;
Sells = new Item[] { new RefreshingSpringWater()
                           , new CoarseThread()
                           , new Bleach()
                           , new RoughArrow()
                           , new LightShot()
                           , new RedDye()
                           , new MildSpices()
                           , new WeakFlux()
                           , new MiningPick()
                           , new BalancedThrowingDagger()
                           , new SmallThrowingKnife()
                           , new CrudeThrowingAxe()
                           , new WeightedThrowingAxe()
                           , new EmptyVial()
                           , new Salt()
                           , new SimpleWood()
                           , new SmallBrownPouch()
                           , new BrownLeatherSatchel()
                           , new RedRibbonedWrappingPaper()
                           , new BlacksmithHammer()
                           , new UnlitPoorTorch()
                           , new CopperRod()
                           , new FishingPole()
                           , new BlueDye()
                           , new PatternBlueLinenRobe()
                           , new ShinyBauble()
                           , new SkinningKnife()
  } ;
Faction = Factions.Stormwind;
Guild = "Trade Goods";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
}
}

public class EdnaMullby : BaseCreature 
 { 
public  EdnaMullby() : base() 
 { 
Model = 1440;
AttackSpeed= 2000;
BoundingRadius = 0.208000f ;
Name = "Edna Mullby" ;
Flags1 = 0x08480046 ;
Id = 1286 ; 
Size = 1f;
Speed = 5f ;
WalkSpeed = 5f ;
RunSpeed = 8f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 30 );
NpcType = 7 ;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Edna Mullby." ;
BaseMana = 0 ;
Sells = new Item[] { new CoarseThread()
                           , new FineThread()
                           , new Bleach()
                           , new BlackDye()
                           , new RedDye()
                           , new GreenDye()
                           , new MildSpices()
                           , new HotSpices()
                           , new WeakFlux()
                           , new MiningPick()
                           , new DustOfDecay()
                           , new EmptyVial()
                           , new LeadedVial()
                           , new StrongFlux()
                           , new SoothingSpices()
                           , new LethargyRoot()
                           , new Coal()
                           , new Salt()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new WoodenStock()
                           , new HeavyStock()
                           , new BlacksmithHammer()
                           , new MysticalPowder()
                           , new CopperRod()
                           , new FishingPole()
                           , new BlueDye()
                           , new EnchantedPowder()
                           , new ShinyBauble()
                           , new Nightcrawlers()
                           , new BrightBaubles()
                           , new SkinningKnife()
                           , new HeavySilkenThread()
                           , new CrystalVial()
  } ;
Faction = Factions.Stormwind;
Guild = "Trade Goods";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}

public class GolornFrostbeard : BaseCreature 
 { 
public  GolornFrostbeard() : base() 
 { 
Model = 3414;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Golorn Frostbeard" ;
Flags1 = 0x08480046 ;
Id = 1692 ; 
Size = 1f;
Speed = 5f ;
WalkSpeed = 5f ;
RunSpeed = 8f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 10 );
NpcType = 7 ;
BaseHitPoints = 424 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 10, 14 );
NpcText00 = "Greetings $N, I am Golorn Frostbeard." ;
BaseMana = 0 ;
Sells = new Item[] { new CoarseThread()
                           , new Bleach()
                           , new RedDye()
                           , new MildSpices()
                           , new WeakFlux()
                           , new MiningPick()
                           , new EmptyVial()
                           , new Salt()
                           , new BlacksmithHammer()
                           , new CopperRod()
                           , new FishingPole()
                           , new BlueDye()
                           , new ShinyBauble()
                           , new SkinningKnife()
  } ;
Faction = Factions.IronForge;
Guild = "Trade Goods";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
}
}

public class AbigailShiel : BaseCreature 
 { 
public  AbigailShiel() : base() 
 { 
Model = 1632;
AttackSpeed= 2000;
BoundingRadius = 0.383000f ;
Name = "Abigail Shiel" ;
Flags1 = 0x08400046 ;
Id = 2118 ; 
Size = 1f;
Speed = 5f ;
WalkSpeed = 5f ;
RunSpeed = 8f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 9 );
NpcType = 6 ;
BaseHitPoints = 384 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 5, 6 );
NpcText00 = "Greetings $N, I am Abigail Shiel." ;
BaseMana = 0 ;
Sells = new Item[] { new RecipeCrispyBatWing()
                           , new CoarseThread()
                           , new Bleach()
                           , new RedDye()
                           , new MildSpices()
                           , new WeakFlux()
                           , new MiningPick()
                           , new EmptyVial()
                           , new Salt()
                           , new BlacksmithHammer()
                           , new CopperRod()
                           , new FishingPole()
                           , new BlueDye()
                           , new ShinyBauble()
                           , new SkinningKnife()
  } ;
Faction = Factions.Undercity;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 7460, InventoryTypes.OneHand, 2, 14, 1, 7, 0, 0, 0 ));
}
}

public class MichaYance : BaseCreature 
 { 
public  MichaYance() : base() 
 { 
Model = 3692;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Micha Yance" ;
Flags1 = 0x08480046 ;
Id = 2381 ; 
Size = 1f;
Speed = 5f ;
WalkSpeed = 5f ;
RunSpeed = 8f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 40 );
NpcType = 7 ;
BaseHitPoints = 6924 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 189, 244 );
NpcText00 = "Greetings $N, I am Micha Yance." ;
BaseMana = 0 ;
Sells = new Item[] { new FormulaEnchantBracerLesserDeflection()
                           , new RefreshingSpringWater()
                           , new CoarseThread()
                           , new FineThread()
                           , new Bleach()
                           , new MildSpices()
                           , new HotSpices()
                           , new WeakFlux()
                           , new MiningPick()
                           , new EmptyVial()
                           , new LeadedVial()
                           , new StrongFlux()
                           , new SoothingSpices()
                           , new Coal()
                           , new Salt()
                           , new SilkenThread()
                           , new PatternIcyCloak()
                           , new WoodenStock()
                           , new HeavyStock()
                           , new PatternThickMurlocArmor()
                           , new BlacksmithHammer()
                           , new CopperRod()
                           , new Nightcrawlers()
                           , new BrightBaubles()
  } ;
Faction = Factions.Stormwind;
Guild = "Trade Goods";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 7439, InventoryTypes.OneHand, 2, 4, 2, 3, 0, 0, 0 ));
}
}

public class ChristophJeffcoat : BaseCreature 
 { 
public  ChristophJeffcoat() : base() 
 { 
Model = 3672;
AttackSpeed= 2000;
BoundingRadius = 0.383000f ;
Name = "Christoph Jeffcoat" ;
Flags1 = 0x08480046 ;
Id = 2393 ; 
Size = 1f;
Speed = 5f ;
WalkSpeed = 5f ;
RunSpeed = 8f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 32 );
NpcType = 7 ;
BaseHitPoints = 1304 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 35, 45 );
NpcText00 = "Oh, if I only had a tree branch to hold up in front of me. The guards would never see me then." ;
BaseMana = 0 ;
Sells = new Item[] { new CoarseThread()
                           , new FineThread()
                           , new Bleach()
                           , new MildSpices()
                           , new HotSpices()
                           , new WeakFlux()
                           , new MiningPick()
                           , new EmptyVial()
                           , new LeadedVial()
                           , new StrongFlux()
                           , new SoothingSpices()
                           , new Coal()
                           , new Salt()
                           , new SilkenThread()
                           , new WoodenStock()
                           , new HeavyStock()
                           , new PatternThickMurlocArmor()
                           , new BlacksmithHammer()
                           , new RecipeShadowProtectionPotion()
                           , new CopperRod()
                           , new Nightcrawlers()
                           , new BrightBaubles()
  } ;
Faction = Factions.Undercity;
Guild = "Trade Goods";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7493, InventoryTypes.OneHand, 2, 0, 1, 3, 0, 0, 0 ));
}
}


public class HammonKarwn : BaseCreature 
 { 
public  HammonKarwn() : base() 
 { 
Model = 3967;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Hammon Karwn" ;
Flags1 = 0x08480046 ;
Id = 2810 ; 
Size = 1f;
Speed = 5f ;
WalkSpeed = 5f ;
RunSpeed = 8f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 35 );
NpcType = 7 ;
BaseHitPoints = 1424 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 38, 49 );
NpcText00 = "Greetings $N, I am Hammon Karwn." ;
BaseMana = 0 ;
Sells = new Item[] { new RecipeRoastRaptor()
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
                           , new LethargyRoot()
                           , new Coal()
                           , new Salt()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new WoodenStock()
                           , new HeavyStock()
                           , new PatternBarbaricLeggings()
                           , new CopperRod()
                           , new FishingPole()
                           , new Nightcrawlers()
                           , new BrightBaubles()
                           , new SkinningKnife()
                           , new HeavySilkenThread()
                           , new CrystalVial()
  } ;
Faction = Factions.Stormwind;
Guild = "Trade Goods";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 7434, InventoryTypes.OneHand, 2, 15, 1, 3, 0, 0, 0 ), new Item( 24293, InventoryTypes.HeldInHand, 4, 0, 2, 0, 0, 0, 0 ));
}
}

public class Keena : BaseCreature 
 { 
public  Keena() : base() 
 { 
Model = 3953;
AttackSpeed= 2000;
BoundingRadius = 0.236000f ;
Name = "Keena" ;
Flags1 = 0x08480046 ;
Id = 2821 ; 
Size = 1f;
Speed = 5f ;
WalkSpeed = 5f ;
RunSpeed = 8f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 33 );
NpcType = 7 ;
BaseHitPoints = 1344 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 36, 46 );
NpcText00 = "Greetings $N, I am Keena." ;
BaseMana = 0 ;
Sells = new Item[] { new FormulaEnchantBracerLesserDeflection()
                           , new RecipeRoastRaptor()
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
                           , new RecipeCuriouslyTastyOmelet()
                           , new SoothingSpices()
                           , new LethargyRoot()
                           , new Coal()
                           , new Salt()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new WoodenStock()
                           , new HeavyStock()
                           , new PatternBarbaricLeggings()
                           , new CopperRod()
                           , new FishingPole()
                           , new Nightcrawlers()
                           , new BrightBaubles()
                           , new SkinningKnife()
                           , new HeavySilkenThread()
                           , new CrystalVial()
  } ;
Faction = Factions.Ogrimmar;
Guild = "Trade Goods";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7445, InventoryTypes.OneHand, 2, 14, 1, 7, 0, 0, 0 ), new Item( 24117, InventoryTypes.HeldInHand, 4, 0, 2, 0, 0, 0, 0 ));
}
}


public class WunnaDarkmane : BaseCreature 
 { 
public  WunnaDarkmane() : base() 
 { 
Model = 3806;
AttackSpeed= 2000;
BoundingRadius = 0.872500f ;
Name = "Wunna Darkmane" ;
Flags1 = 0x08480046 ;
Id = 3081 ; 
Size = 1f;
Speed = 5f ;
WalkSpeed = 5f ;
RunSpeed = 8f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 10 );
NpcType = 7 ;
BaseHitPoints = 424 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 3.75f ;
SetDamage ( 10, 14 );
NpcText00 = "Greetings $N, I am Wunna Darkmane." ;
BaseMana = 0 ;
Sells = new Item[] { new CoarseThread()
                           , new Bleach()
                           , new RedDye()
                           , new MildSpices()
                           , new WeakFlux()
                           , new MiningPick()
                           , new EmptyVial()
                           , new Salt()
                           , new RecipeRoastedKodoMeat()
                           , new BlacksmithHammer()
                           , new CopperRod()
                           , new FishingPole()
                           , new BlueDye()
                           , new ShinyBauble()
                           , new SkinningKnife()
  } ;
Faction = Factions.ThunderBluff;
Guild = "Trade Goods";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 7493, InventoryTypes.OneHand, 2, 0, 1, 3, 0, 0, 0 ));
}
}

public class Flakk : BaseCreature 
 { 
public  Flakk() : base() 
 { 
Model = 3741;
AttackSpeed= 2000;
BoundingRadius = 0.372000f ;
Name = "Flakk" ;
Flags1 = 0x08480046 ;
Id = 3168 ; 
Size = 1f;
Speed = 5f ;
WalkSpeed = 5f ;
RunSpeed = 8f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 15 );
NpcType = 7 ;
BaseHitPoints = 624 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 16, 21 );
NpcText00 = "Greetings $N, I am Flakk." ;
BaseMana = 0 ;
Sells = new Item[] { new CoarseThread()
                           , new Bleach()
                           , new RedDye()
                           , new MildSpices()
                           , new WeakFlux()
                           , new MiningPick()
                           , new EmptyVial()
                           , new Salt()
                           , new BlacksmithHammer()
                           , new CopperRod()
                           , new FishingPole()
                           , new BlueDye()
                           , new ShinyBauble()
                           , new SkinningKnife()
  } ;
Faction = Factions.Ogrimmar;
Guild = "Trade Goods";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 7465, InventoryTypes.OneHand, 2, 14, 1, 0, 0, 0, 0 ));
}
}

public class Taitasi : BaseCreature 
 { 
public  Taitasi() : base() 
 { 
Model = 4087;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Tai'tasi" ;
Flags1 = 0x08480046 ;
Id = 3187 ; 
Size = 1f;
Speed = 5f ;
WalkSpeed = 5f ;
RunSpeed = 8f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 12 );
NpcType = 7 ;
BaseHitPoints = 504 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 13, 16 );
NpcText00 = "Greetings $N, I am Tai'tasi." ;
BaseMana = 0 ;
Sells = new Item[] { new CoarseThread()
                           , new Bleach()
                           , new RedDye()
                           , new MildSpices()
                           , new WeakFlux()
                           , new MiningPick()
                           , new EmptyVial()
                           , new Salt()
                           , new BlacksmithHammer()
                           , new CopperRod()
                           , new FishingPole()
                           , new BlueDye()
                           , new ShinyBauble()
                           , new SkinningKnife()
  } ;
Faction = Factions.DarkspearTrolls;
Guild = "Trade Goods";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 7493, InventoryTypes.OneHand, 2, 0, 1, 3, 0, 0, 0 ));
}
}

public class Shimra : BaseCreature 
 { 
public  Shimra() : base() 
 { 
Model = 4356;
AttackSpeed= 1739;
BoundingRadius = 0.236000f ;
Name = "Shimra" ;
Flags1 = 0x08480046 ;
Id = 5817 ; 
Size = 1f;
Speed = 5f ;
WalkSpeed = 5f ;
RunSpeed = 8f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 30 );
NpcType = 7 ;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Shimra." ;
BaseMana = 0 ;
Sells = new Item[] { new CoarseThread()
                           , new FineThread()
                           , new Bleach()
                           , new BlackDye()
                           , new RedDye()
                           , new GreenDye()
                           , new MildSpices()
                           , new HotSpices()
                           , new WeakFlux()
                           , new MiningPick()
                           , new DustOfDecay()
                           , new EmptyVial()
                           , new LeadedVial()
                           , new StrongFlux()
                           , new SoothingSpices()
                           , new LethargyRoot()
                           , new Coal()
                           , new Salt()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new WoodenStock()
                           , new HeavyStock()
                           , new BlacksmithHammer()
                           , new CopperRod()
                           , new FishingPole()
                           , new BlueDye()
                           , new SoulShard()
                           , new ShinyBauble()
                           , new Nightcrawlers()
                           , new BrightBaubles()
                           , new SkinningKnife()
                           , new HeavySilkenThread()
                           , new CrystalVial()
  } ;
Faction = Factions.Ogrimmar;
Guild = "Trade Goods";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7493, InventoryTypes.OneHand, 2, 0, 1, 3, 0, 0, 0 ));
}
}

public class GorboldSteelhand : BaseCreature 
 { 
public  GorboldSteelhand() : base() 
 { 
Model = 5023;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Gorbold Steelhand" ;
Flags1 = 0x08480046 ;
Id = 6301 ; 
Size = 1f;
Speed = 5f ;
WalkSpeed = 5f ;
RunSpeed = 8f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 30 );
NpcType = 7 ;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Gorbold Steelhand." ;
BaseMana = 0 ;
Sells = new Item[] { new CoarseThread()
                           , new FineThread()
                           , new Bleach()
                           , new BlackDye()
                           , new RedDye()
                           , new GreenDye()
                           , new MildSpices()
                           , new HotSpices()
                           , new WeakFlux()
                           , new MiningPick()
                           , new DustOfDecay()
                           , new EmptyVial()
                           , new LeadedVial()
                           , new StrongFlux()
                           , new SoothingSpices()
                           , new LethargyRoot()
                           , new Coal()
                           , new Salt()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new WoodenStock()
                           , new HeavyStock()
                           , new BlacksmithHammer()
                           , new CopperRod()
                           , new FishingPole()
                           , new BlueDye()
                           , new ShinyBauble()
                           , new Nightcrawlers()
                           , new BrightBaubles()
                           , new SkinningKnife()
                           , new HeavySilkenThread()
                           , new CrystalVial()
  } ;
Faction = Factions.Darnasus;
Guild = "Trade Goods";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7493, InventoryTypes.OneHand, 2, 0, 1, 3, 0, 0, 0 ));
}
}

public class Vivianna : BaseCreature 
 { 
public  Vivianna() : base() 
 { 
Model = 7017;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Vivianna" ;
Flags1 = 0x08480006 ;
Id = 7947 ; 
Size = 1f;
Speed = 5f ;
WalkSpeed = 5f ;
RunSpeed = 8f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 52 );
NpcType = 7 ;
BaseHitPoints = 16+10*Level;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 57, 73 );
NpcText00 = "Greetings $N, I am Vivianna." ;
BaseMana = 0 ;
Sells = new Item[] { new RecipeHotWolfRibs()
                           , new RecipeLobsterStew()
                           , new RecipeMightfishSteak()
                           , new RecipeBakedSalmon()
                           , new CoarseThread()
                           , new FineThread()
                           , new Bleach()
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
                           , new LethargyRoot()
                           , new Coal()
                           , new Salt()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new WoodenStock()
                           , new HeavyStock()
                           , new BlacksmithHammer()
                           , new CopperRod()
                           , new FishingPole()
                           , new Nightcrawlers()
                           , new BrightBaubles()
                           , new SkinningKnife()
                           , new HeavySilkenThread()
                           , new CrystalVial()
  } ;
Faction = Factions.Darnasus;
Guild = "Trade Goods";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
Equip( new Item( 7446, InventoryTypes.OneHand, 2, 14, 1, 7, 0, 0, 0 ));
}
}

public class SheendraTallgrass : BaseCreature 
 { 
public  SheendraTallgrass() : base() 
 { 
Model = 7359;
AttackSpeed= 2000;
BoundingRadius = 0.872500f ;
Name = "Sheendra Tallgrass" ;
Flags1 = 0x08480046 ;
Id = 8145 ; 
Size = 1f;
Speed = 5f ;
WalkSpeed = 5f ;
RunSpeed = 8f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 50 );
NpcType = 7 ;
BaseHitPoints = 1705 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 3.75f ;
SetDamage ( 46, 59 );
NpcText00 = "Greetings $N, I am Sheendra Tallgrass." ;
BaseMana = 0 ;
Sells = new Item[] { new RecipeHotWolfRibs()
                           , new RecipeLobsterStew()
                           , new RecipeMightfishSteak()
                           , new RecipeBakedSalmon()
                           , new CoarseThread()
                           , new FineThread()
                           , new Bleach()
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
                           , new LethargyRoot()
                           , new Coal()
                           , new Salt()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new WoodenStock()
                           , new HeavyStock()
                           , new BlacksmithHammer()
                           , new CopperRod()
                           , new FishingPole()
                           , new Nightcrawlers()
                           , new BrightBaubles()
                           , new SkinningKnife()
                           , new HeavySilkenThread()
                           , new CrystalVial()
  } ;
Faction = Factions.ThunderBluff;
Guild = "Trade Goods";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
}
}

public class ShadiMistrunner : BaseCreature 
 { 
public  ShadiMistrunner() : base() 
 { 
Model = 7628;
AttackSpeed= 2000;
BoundingRadius = 0.872500f ;
Name = "Shadi Mistrunner" ;
Flags1 = 0x08480046 ;
Id = 8363 ; 
Size = 1f;
Speed = 5f ;
WalkSpeed = 5f ;
RunSpeed = 8f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 30 );
NpcType = 7 ;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 3.75f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Shadi Mistrunner." ;
BaseMana = 0 ;
Sells = new Item[] { new CoarseThread()
                           , new FineThread()
                           , new Bleach()
                           , new BlackDye()
                           , new RedDye()
                           , new GreenDye()
                           , new MildSpices()
                           , new HotSpices()
                           , new WeakFlux()
                           , new MiningPick()
                           , new DustOfDecay()
                           , new EmptyVial()
                           , new LeadedVial()
                           , new StrongFlux()
                           , new SoothingSpices()
                           , new LethargyRoot()
                           , new Coal()
                           , new Salt()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new WoodenStock()
                           , new HeavyStock()
                           , new BlacksmithHammer()
                           , new CopperRod()
                           , new FishingPole()
                           , new BlueDye()
                           , new ShinyBauble()
                           , new Nightcrawlers()
                           , new BrightBaubles()
                           , new SkinningKnife()
                           , new HeavySilkenThread()
                           , new CrystalVial()
  } ;
Faction = Factions.ThunderBluff;
Guild = "Trade Goods";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7439, InventoryTypes.OneHand, 2, 4, 2, 3, 0, 0, 0 ));
}
}


public class ChristopherHewen : BaseCreature 
 { 
public  ChristopherHewen() : base() 
 { 
Model = 8186;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Christopher Hewen" ;
Flags1 = 0x08480046 ;
Id = 8934 ; 
Size = 1f;
Speed = 5f ;
WalkSpeed = 5f ;
RunSpeed = 8f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 30 );
NpcType = 7 ;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Christopher Hewen." ;
BaseMana = 0 ;
Sells = new Item[] { new CoarseThread()
                           , new FineThread()
                           , new Bleach()
                           , new BlackDye()
                           , new RedDye()
                           , new GreenDye()
                           , new MildSpices()
                           , new HotSpices()
                           , new WeakFlux()
                           , new MiningPick()
                           , new DustOfDecay()
                           , new EmptyVial()
                           , new LeadedVial()
                           , new StrongFlux()
                           , new SoothingSpices()
                           , new LethargyRoot()
                           , new Coal()
                           , new Salt()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new WoodenStock()
                           , new HeavyStock()
                           , new BlacksmithHammer()
                           , new CopperRod()
                           , new FishingPole()
                           , new BlueDye()
                           , new SoulShard()
                           , new ShinyBauble()
                           , new Nightcrawlers()
                           , new BrightBaubles()
                           , new SkinningKnife()
                           , new HeavySilkenThread()
                           , new CrystalVial()
  } ;
Faction = Factions.Stormwind;
Guild = "Trade Goods";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}

public class Kireena : BaseCreature 
 { 
public  Kireena() : base() 
 { 
Model = 10692;
AttackSpeed= 2000;
BoundingRadius = 0.872500f ;
Name = "Kireena" ;
Flags1 = 0x08480046 ;
Id = 9636 ; 
Size = 1f;
Speed = 5f ;
WalkSpeed = 5f ;
RunSpeed = 8f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 41 );
NpcType = 7 ;
BaseHitPoints = 1665 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 3.75f ;
SetDamage ( 44, 58 );
NpcText00 = "Greetings $N, I am Kireena." ;
BaseMana = 0 ;
Sells = new Item[] { new RecipeCarrionSurprise()
                           , new RecipeHeavyKodoStew()
                           , new CoarseThread()
                           , new FineThread()
                           , new Bleach()
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
                           , new LethargyRoot()
                           , new Coal()
                           , new Salt()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new WoodenStock()
                           , new HeavyStock()
                           , new BlacksmithHammer()
                           , new CopperRod()
                           , new FishingPole()
                           , new ShinyBauble()
                           , new Nightcrawlers()
                           , new BrightBaubles()
                           , new SkinningKnife()
                           , new PatternAzureSilkGloves()
                           , new HeavySilkenThread()
                           , new CrystalVial()
  } ;
Faction = Factions.ThunderBluff;
Guild = "Trade Goods";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 7474, InventoryTypes.OneHand, 2, 14, 1, 0, 0, 0, 0 ), new Item( 6536, InventoryTypes.HeldInHand, 4, 0, 2, 0, 0, 0, 0 ));
}
}

public class Qia : BaseCreature 
 { 
public  Qia() : base() 
 { 
Model = 10746;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Qia" ;
Flags1 = 0x08080006 ;
Id = 11189 ; 
Size = 1f;
Speed = 5f ;
WalkSpeed = 5f ;
RunSpeed = 8f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 51 );
NpcType = 7 ;
BaseHitPoints = 2065 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 55, 72 );
NpcText00 = "Greetings $N, I am Qia." ;
BaseMana = 0 ;
Sells = new Item[] { new PatternRuneclothBag()
                           , new PatternRuneclothGloves()
                           , new PatternMooncloth()
                           , new PatternFrostsaberBoots()
                           , new RecipeMonsterOmelet()
                           , new FormulaEnchantChestMajorHealth()
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
                           , new LethargyRoot()
                           , new Coal()
                           , new Salt()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new WoodenStock()
                           , new HeavyStock()
                           , new CopperRod()
                           , new FishingPole()
                           , new Nightcrawlers()
                           , new BrightBaubles()
                           , new SkinningKnife()
                           , new HeavySilkenThread()
                           , new CrystalVial()
  } ;
Faction = Factions.Everlook;
Guild = "Trade Goods";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
Equip( new Item( 7434, InventoryTypes.OneHand, 2, 15, 1, 3, 0, 0, 0 ));
}
}

public class Meilosh : BaseCreature 
 { 
public  Meilosh() : base() 
 { 
Model = 11363;
AttackSpeed= 2000;
BoundingRadius = 1.500000f ;
Name = "Meilosh" ;
Flags1 = 0x080004 ;
Id = 11557 ; 
Size = 1f;
Speed = 5f ;
WalkSpeed = 5f ;
RunSpeed = 8f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 55 );
NpcType = 7 ;
BaseHitPoints = 2226 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.875f ;
SetDamage ( 60, 77 );
NpcText00 = "Greetings $N, I am Meilosh." ;
BaseMana = 0 ;
Sells = new Item[] { new PinkDye()
                           // , new RecipeTransmuteEarthtoWater()
                           , new RuneThread()
                           , new PatternWarbearHarness()
                           , new PatternWarbearWoolies()
                           , new CoarseThread()
                           , new FineThread()
                           , new Bleach()
                           , new BlackDye()
                           , new RedDye()
                           , new GreenDye()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new BlueDye()
                           , new OrangeDye()
                           , new HeavySilkenThread()
  } ;
Faction = Factions.ThundermawFurbolgs;
Guild = "Trade Goods";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
}
}

public class LorelaeWintersong : BaseCreature 
 { 
public  LorelaeWintersong() : base() 
 { 
Model = 12033;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Lorelae Wintersong" ;
Flags1 = 0x08080046 ;
Id = 12022 ; 
Size = 1f;
Speed = 5f ;
WalkSpeed = 5f ;
RunSpeed = 8f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 51 );
NpcType = 7 ;
BaseHitPoints = 2065 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 55, 72 );
NpcText00 = "Greetings $N, I am Lorelae Wintersong." ;
BaseMana = 0 ;
Sells = new Item[] { new PatternFelclothPants()
                           , new FormulaEnchantCloakSuperiorDefense()
                           , new FormulaRunedArcaniteRod()
                           , new CoarseThread()
                           , new FineThread()
                           , new Bleach()
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
                           , new LethargyRoot()
                           , new Coal()
                           , new Salt()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new WoodenStock()
                           , new HeavyStock()
                           , new BlacksmithHammer()
                           , new CopperRod()
                           , new FishingPole()
                           , new Nightcrawlers()
                           , new BrightBaubles()
                           , new SkinningKnife()
                           , new HeavySilkenThread()
                           , new CrystalVial()
  } ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
}
}

public class LahMawhani : BaseCreature 
 { 
public  LahMawhani() : base() 
 { 
Model = 12042;
AttackSpeed= 1693;
BoundingRadius = 1.00f ;
Name = "Lah'Mawhani" ;
Flags1 = 0x08480046 ;
Id = 12028 ; 
Size = 1f;
Speed = 5f ;
WalkSpeed = 5f ;
RunSpeed = 8f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 30 );
NpcType = 7 ;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 11.00f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Lah'Mawhani." ;
BaseMana = 1503 ;
Sells = new Item[] { new CoarseThread()
                           , new FineThread()
                           , new Bleach()
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
                           , new LethargyRoot()
                           , new Coal()
                           , new Salt()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new WoodenStock()
                           , new HeavyStock()
                           , new BlacksmithHammer()
                           , new CopperRod()
                           , new FishingPole()
                           , new ShinyBauble()
                           , new Nightcrawlers()
                           , new BrightBaubles()
                           , new SkinningKnife()
                           , new HeavySilkenThread()
                           , new CrystalVial()
  } ;
Faction = Factions.Ogrimmar;
Guild = "Trade Goods";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}

public class Kulwia : BaseCreature 
 { 
public  Kulwia() : base() 
 { 
Model = 12059;
AttackSpeed= 2000;
BoundingRadius = 0.872500f ;
Name = "Kulwia" ;
Flags1 = 0x08480046 ;
Id = 12043 ; 
Size = 1.25f;
Speed = 5f ;
WalkSpeed = 5f ;
RunSpeed = 8f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 32 );
NpcType = 7 ;
BaseHitPoints = 1304 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 3.75f ;
SetDamage ( 35, 45 );
NpcText00 = "Greetings $N, I am Kulwia." ;
BaseMana = 0 ;
Sells = new Item[] { new FormulaEnchantCloakMinorAgility()
                           , new FormulaEnchantBracerLesserStrength()
                           , new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
                           , new CoarseThread()
                           , new FineThread()
                           , new Bleach()
                           , new RoughArrow()
                           , new SharpArrow()
                           , new LightShot()
                           , new HeavyShot()
                           , new MildSpices()
                           , new HotSpices()
                           , new WeakFlux()
                           , new MiningPick()
                           , new DustOfDecay()
                           , new BalancedThrowingDagger()
                           , new KeenThrowingKnife()
                           , new WeightedThrowingAxe()
                           , new SharpThrowingAxe()
                           , new EmptyVial()
                           , new LeadedVial()
                           , new Salt()
                           , new SimpleWood()
                           , new FlintAndTinder()
                           , new SmallBrownPouch()
                           , new BrownLeatherSatchel()
                           , new BlueRibbonedWrappingPaper()
                           , new BlacksmithHammer()
                           , new CopperRod()
                           , new FishingPole()
                           , new ShinyBauble()
                           , new Nightcrawlers()
                           , new SkinningKnife()
  } ;
Faction = Factions.Ogrimmar;
Guild = "Trade Goods";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7439, InventoryTypes.OneHand, 2, 0, 1, 3, 0, 0, 0 ), new Item( 23174, InventoryTypes.HeldInHand, 4, 0, 1, 0, 0, 0, 0 ));
}
}

public class JaseFarlane : BaseCreature 
 { 
public  JaseFarlane() : base() 
 { 
Model = 12954;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Jase Farlane" ;
Flags1 = 0x080046 ;
Id = 12941 ; 
Size = 1f;
Speed = 5f ;
WalkSpeed = 5f ;
RunSpeed = 8f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 56 );
NpcType = 7 ;
BaseHitPoints = 2266 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 61, 79 );
NpcText00 = "Greetings $N, I am Jase Farlane." ;
BaseMana = 0 ;
Sells = new Item[] { new PatternRunicLeatherHeadband()
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
                           , new LethargyRoot()
                           , new Coal()
                           , new Salt()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new WoodenStock()
                           , new HeavyStock()
                           , new CopperRod()
                           , new FishingPole()
                           , new Nightcrawlers()
                           , new BrightBaubles()
                           , new SkinningKnife()
                           , new HeavySilkenThread()
                           , new CrystalVial()
  } ;
Faction = Factions.ArgentDawn;
Guild = "Trade Goods";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
Equip( new Item( 23316, InventoryTypes.OneHand, 2, 14, 1, 0, 0, 0, 0 ));
}
}


public class BlimoGadgetspring : BaseCreature 
 { 
public  BlimoGadgetspring() : base() 
 { 
Model = 262;
AttackSpeed= 2100;
BoundingRadius = 1.00f ;
Name = "Blimo Gadgetspring" ;
Flags1 = 0x0 ;
Id = 12957 ; 
Size = 1f;
Speed = 5f ;
WalkSpeed = 5f ;
RunSpeed = 8f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 55 );
NpcType = 7 ;
BaseHitPoints = 0 ;
NpcFlags = 0 ;
CombatReach = 0f ;
SetDamage ( 52, 77 );
NpcText00 = "Hello" ;
BaseMana = 0 ;
Sells = new Item[] { new PatternChimericGloves()
                           , new PatternBlueDragonscaleBreastplate()
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
                           , new LethargyRoot()
                           , new Coal()
                           , new Salt()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new WoodenStock()
                           , new HeavyStock()
                           , new CopperRod()
                           , new FishingPole()
                           , new Nightcrawlers()
                           , new BrightBaubles()
                           , new SkinningKnife()
                           , new HeavySilkenThread()
                           , new CrystalVial()
  } ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
}
}

public class GiggetZipcoil : BaseCreature 
 { 
public  GiggetZipcoil() : base() 
 { 
Model = 12935;
AttackSpeed= 2000;
BoundingRadius = 0.351900f ;
Name = "Gigget Zipcoil" ;
Flags1 = 0x066 ;
Id = 12958 ; 
Size = 1f;
Speed = 5f ;
WalkSpeed = 5f ;
RunSpeed = 8f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 52 );
NpcType = 7 ;
BaseHitPoints = 16+10*Level;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.725f ;
SetDamage ( 57, 73 );
NpcText00 = "Hello" ;
BaseMana = 0 ;
Sells = new Item[] { new PatternIronfeatherShoulders()
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
                           , new LethargyRoot()
                           , new Coal()
                           , new Salt()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new WoodenStock()
                           , new HeavyStock()
                           , new CopperRod()
                           , new FishingPole()
                           , new Nightcrawlers()
                           , new BrightBaubles()
                           , new SkinningKnife()
                           , new HeavySilkenThread()
                           , new CrystalVial()
  } ;
Faction = Factions.Friend;
Guild = "Trade Goods";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
}
}

public class AndrewHilbert : BaseCreature 
 { 
public  AndrewHilbert() : base() 
 { 
Model = 3548;
AttackSpeed= 2000;
BoundingRadius = 0.351900f ;
Name = "Andrew Hilbert" ;
Flags1 = 0x08480046;
Id = 3556 ; 
Size = 1f;
Speed = 5f ;
WalkSpeed = 5f ;
RunSpeed = 8f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 52 );
NpcType = 6;
BaseHitPoints = 16+10*Level;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.725f ;
SetDamage ( 57, 73 );
NpcText00 = "Hello" ;
BaseMana = 0 ;
Sells = new Item[] {new CoarseThread()
,new FineThread()
,new Bleach()
,new MildSpices()
,new HotSpices()
,new WeakFlux()
,new MiningPick()
,new DustOfDecay()
,new EmptyVial()
,new LeadedVial()
,new Salt()
,new PatternRedLinenBag()
,new PatternMurlocScaleBelt()
,new PatternMurlocScaleBreastplate()
,new BlacksmithHammer()
,new CopperRod()
,new FishingPole()
,new PatternBlueLinenRobe()
,new ShinyBauble()
,new Nightcrawlers()
,new RecipeSmokedBearMeat()
,new SkinningKnife()

  } ;
Faction = Factions.Undercity;
Guild = "Trade Goods";
AIEngine = new StandingNpcAI( this ); 
Equip( new Item( 7434, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ) ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}

}
