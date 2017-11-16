//originally Scripted By DiScS Converter
//Edited by *place name here*
using System;
using Server.Items;
using Server;

////////////////////
namespace Server.Creatures
{
public class GubberBlump : BaseCreature 
 { 
public  GubberBlump() : base() 
 { 
Model = 9550;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Gubber Blump" ;
Flags1 = 0x018480006 ;
Id = 10216 ; 
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
NpcFlags = 2 ;
CombatReach = 1.5f ;
SetDamage ( 16, 21 );
NpcText00 = "Greetings $N, I am Gubber Blump." ;
BaseMana = 0 ;
Sells = new Item[] { new FishingPole()
                           , new ShinyBauble()
  } ;
Faction = Factions.IronForge;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 7453, InventoryTypes.OneHand, 2, 4, 2, 2, 0, 0, 0 ));
}
}
public class Gikkix : BaseCreature 
 { 
public  Gikkix() : base() 
 { 
Model = 7354;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Gikkix" ;
Flags1 = 0x08080046 ;
Id = 8137 ; 
Guild = "Fisherman";
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
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1625 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 43, 56 );
NpcText00 = "Greetings $N, I am Gikkix." ;
BaseMana = 0 ;
Sells = new Item[] { new IceColdMilk()
                           , new MelonJuice()
                           , new RecipeSpottedYellowtail()
                           , new RecipeGrilledSquid()
                           , new RecipeNightfinSoup()
                           , new RecipePoachedSunscaleSalmon()
                           , new RefreshingSpringWater()
                           , new MoonberryJuice()
                           , new SweetNectar()
                           , new LongjawMudSnapper()
                           , new BristleWhiskerCatfish()
                           , new RockscaleCod()
                           , new SpottedYellowtail()
                           , new SlitherskinMackerel()
                           , new MorningGloryDew()
                           , new SpinefinHalibut()
  } ;
Faction = Factions.Gadgetzan;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 10817, InventoryTypes.OneHand, 2, 14, 1, 7, 0, 0, 0 ));
}
}
public class Harklane : BaseCreature 
 { 
public  Harklane() : base() 
 { 
Model = 7019;
AttackSpeed= 2000;
BoundingRadius = 0.389000f ;
Name = "Harklane" ;
Flags1 = 0x08480006 ;
Id = 7943 ; 
Guild = "Fish Vendor";
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
Level = RandomLevel( 49 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1985 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 53, 69 );
NpcText00 = "Greetings $N, I am Harklane." ;
BaseMana = 0 ;
Sells = new Item[] { new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
                           , new MoonberryJuice()
                           , new SweetNectar()
                           , new LongjawMudSnapper()
                           , new BristleWhiskerCatfish()
                           , new RockscaleCod()
                           , new SpottedYellowtail()
                           , new SlitherskinMackerel()
                           , new MorningGloryDew()
                           , new SpinefinHalibut()
  } ;
Faction = Factions.Darnasus;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 10815, InventoryTypes.OneHand, 2, 14, 1, 7, 0, 0, 0 ));
}
}
public class KillianSanatha : BaseCreature 
 { 
public  KillianSanatha() : base() 
 { 
Model = 7689;
AttackSpeed= 1848;
BoundingRadius = 1.00f ;
Name = "Killian Sanatha" ;
Flags1 = 0x08400046 ;
Id = 5748 ; 
Guild = "Fisherman";
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
Level = RandomLevel( 18, 20 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 784 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 11.00f ;
SetDamage ( 20, 26 );
NpcText00 = "Greetings $N, I am Killian Sanatha." ;
BaseMana = 953 ;
Sells = new Item[] { new CopperOre()
                           , new RecipeLongjawMudSnapper()
                           , new RecipeRainbowFinAlbacore()
  } ;
Faction = Factions.Undercity;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}
public class HeldanGalesong : BaseCreature 
 { 
public  HeldanGalesong() : base() 
 { 
Model = 4415;
AttackSpeed= 2000;
BoundingRadius = 0.389000f ;
Name = "Heldan Galesong" ;
Flags1 = 0x08480046 ;
Id = 4307 ; 
Guild = "Fisherman";
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
Level = RandomLevel( 25 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1024 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 27, 35 );
NpcText00 = "Greetings $N, I am Heldan Galesong." ;
BaseMana = 0 ;
Sells = new Item[] { new RecipeMithrilHeadTrout()
                           , new LongjawMudSnapper()
                           , new BristleWhiskerCatfish()
                           , new RockscaleCod()
                           , new RecipeClamChowder()
                           , new RecipeRainbowFinAlbacore()
                           , new RecipeRockscaleCod()
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
public class KriggonTalsone : BaseCreature 
 { 
public  KriggonTalsone() : base() 
 { 
Model = 4417;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Kriggon Talsone" ;
Flags1 = 0x08480046 ;
Id = 4305 ; 
Guild = "Fisherman";
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
Level = RandomLevel( 25 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 984 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 26, 33 );
NpcText00 = "Greetings $N, I am Kriggon Talsone." ;
BaseMana = 0 ;
Sells = new Item[] { new RecipeSpicedChiliCrab()
                           , new ScrollOfAgility()
                           , new LongjawMudSnapper()
                           , new BristleWhiskerCatfish()
                           , new RockscaleCod()
                           , new RecipeClamChowder()
                           , new RecipeSlitherskinMackerel()
                           , new RecipeRainbowFinAlbacore()
                           , new SpottedYellowtail()
                           , new SlitherskinMackerel()
                           , new SpinefinHalibut()
  } ;
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7453, InventoryTypes.OneHand, 2, 4, 2, 2, 0, 0, 0 ));
}
}
public class Zizzek : BaseCreature 
 { 
public  Zizzek() : base() 
 { 
Model = 7074;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Zizzek" ;
Flags1 = 0x08080006 ;
Id = 3572 ; 
Guild = "Fisherman";
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
Level = RandomLevel( 22 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 904 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 24, 31 );
NpcText00 = "Greetings $N, I am Zizzek." ;
BaseMana = 0 ;
Sells = new Item[] { new FishingPole()
                           , new StrongFishingPole()
                           , new ShinyBauble()
                           , new Nightcrawlers()
                           , new BrightBaubles()
                           , new AquadynamicFishAttractor()
  } ;
Faction = Factions.Ratchet;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7453, InventoryTypes.OneHand, 2, 4, 2, 2, 0, 0, 0 ));
}
}
public class Kilxx : BaseCreature 
 { 
public  Kilxx() : base() 
 { 
Model = 7097;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Kilxx" ;
Flags1 = 0x08080006 ;
Id = 3497 ; 
Guild = "Fisherman";
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
Level = RandomLevel( 24 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 984 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 26, 33 );
NpcText00 = "Greetings $N, I am Kilxx." ;
BaseMana = 0 ;
Sells = new Item[] { new LongjawMudSnapper()
                           , new BristleWhiskerCatfish()
                           , new RockscaleCod()
                           , new FishingPole()
                           , new RecipeBristleWhiskerCatfish()
                           , new StrongFishingPole()
                           , new RecipeRainbowFinAlbacore()
                           , new ShinyBauble()
                           , new Nightcrawlers()
                           , new BrightBaubles()
                           , new AquadynamicFishAttractor()
                           , new SpottedYellowtail()
                           , new SlitherskinMackerel()
                           , new SpinefinHalibut()
  } ;
Faction = Factions.Ratchet;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 10815, InventoryTypes.OneHand, 2, 14, 1, 7, 0, 0, 0 ));
}
}
public class StuartFleming : BaseCreature 
 { 
public  StuartFleming() : base() 
 { 
Model = 3468;
AttackSpeed= 1500;
BoundingRadius = 0.306000f ;
Name = "Stuart Fleming" ;
Flags1 = 0x08480046 ;
Id = 3178 ; 
Guild = "Fisherman";
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
Level = RandomLevel( 25 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1024 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 27, 35 );
NpcText00 = "Greetings $N, I am Stuart Fleming." ;
BaseMana = 0 ;
Sells = new Item[] { new RecipeMithrilHeadTrout()
                           , new LongjawMudSnapper()
                           , new BristleWhiskerCatfish()
                           , new RockscaleCod()
                           , new FishingPole()
                           , new StrongFishingPole()
                           , new RecipeRainbowFinAlbacore()
                           , new RecipeRockscaleCod()
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
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7453, InventoryTypes.OneHand, 2, 4, 2, 2, 0, 0, 0 ));
}
}
public class CatherineLeland : BaseCreature 
 { 
public  CatherineLeland() : base() 
 { 
Model = 3290;
AttackSpeed= 2000;
BoundingRadius = 0.208000f ;
Name = "Catherine Leland" ;
Flags1 = 0x08480046 ;
Id = 5494 ; 
Guild = "Fishing Supplier";
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
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Catherine Leland." ;
BaseMana = 0 ;
Sells = new Item[] { new FishingPole()
                           , new RecipeBrilliantSmallfish()
                           , new RecipeBristleWhiskerCatfish()
                           , new StrongFishingPole()
                           , new RecipeRainbowFinAlbacore()
                           , new ShinyBauble()
                           , new Nightcrawlers()
                           , new BrightBaubles()
                           , new AquadynamicFishAttractor()
  } ;
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7453, InventoryTypes.OneHand, 2, 4, 2, 2, 0, 0, 0 ));
}
}
public class TansyPuddlefizz : BaseCreature 
 { 
public  TansyPuddlefizz() : base() 
 { 
Model = 3121;
AttackSpeed= 2000;
BoundingRadius = 0.351900f ;
Name = "Tansy Puddlefizz" ;
Flags1 = 0x08480046 ;
Id = 5162 ; 
Guild = "Fishing Supplier";
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
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.725f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Tansy Puddlefizz." ;
BaseMana = 0 ;
Sells = new Item[] { new RecipeMithrilHeadTrout()
                           , new FishingPole()
                           , new RecipeSlitherskinMackerel()
                           , new RecipeLongjawMudSnapper()
                           , new StrongFishingPole()
                           , new RecipeRockscaleCod()
                           , new ShinyBauble()
                           , new Nightcrawlers()
                           , new BrightBaubles()
                           , new AquadynamicFishAttractor()
  } ;
Faction = Factions.GnomereganExiles;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7453, InventoryTypes.OneHand, 2, 4, 2, 2, 0, 0, 0 ));
}
}
public class LizbethCromwell : BaseCreature 
 { 
public  LizbethCromwell() : base() 
 { 
Model = 2667;
AttackSpeed= 2000;
BoundingRadius = 0.383000f ;
Name = "Lizbeth Cromwell" ;
Flags1 = 0x018480046 ;
Id = 4574 ; 
Guild = "Fishing Supplier";
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
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Lizbeth Cromwell." ;
BaseMana = 0 ;
Sells = new Item[] { new RecipeMithrilHeadTrout()
                           , new FishingPole()
                           , new RecipeBrilliantSmallfish()
                           , new RecipeLongjawMudSnapper()
                           , new StrongFishingPole()
                           , new RecipeRockscaleCod()
                           , new ShinyBauble()
                           , new Nightcrawlers()
                           , new BrightBaubles()
                           , new AquadynamicFishAttractor()
  } ;
Faction = Factions.Undercity;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7453, InventoryTypes.OneHand, 2, 4, 2, 2, 0, 0, 0 ));
}
}
public class Voloren : BaseCreature 
 { 
public  Voloren() : base() 
 { 
Model = 2276;
AttackSpeed= 2000;
BoundingRadius = 0.389000f ;
Name = "Voloren" ;
Flags1 = 0x08480046 ;
Id = 4222 ; 
Guild = "Fishing Supplier";
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
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Voloren." ;
BaseMana = 0 ;
Sells = new Item[] { new FishingPole()
                           , new StrongFishingPole()
                           , new ShinyBauble()
                           , new Nightcrawlers()
                           , new BrightBaubles()
                           , new AquadynamicFishAttractor()
  } ;
Faction = Factions.Darnasus;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7453, InventoryTypes.OneHand, 2, 4, 2, 2, 0, 0, 0 ));
}
}
public class SewaMistrunner : BaseCreature 
 { 
public  SewaMistrunner() : base() 
 { 
Model = 2120;
AttackSpeed= 2000;
BoundingRadius = 0.872500f ;
Name = "Sewa Mistrunner" ;
Flags1 = 0x08480046 ;
Id = 3029 ; 
Guild = "Fishing Supplier";
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
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1625 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 3.75f ;
SetDamage ( 43, 56 );
NpcText00 = "Greetings $N, I am Sewa Mistrunner." ;
BaseMana = 0 ;
Sells = new Item[] { new FishingPole()
                           , new RecipeBrilliantSmallfish()
                           , new RecipeBristleWhiskerCatfish()
                           , new StrongFishingPole()
                           , new ShinyBauble()
                           , new Nightcrawlers()
                           , new BrightBaubles()
                           , new AquadynamicFishAttractor()
  } ;
Faction = Factions.ThunderBluff;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
Equip( new Item( 7453, InventoryTypes.OneHand, 2, 4, 2, 2, 0, 0, 0 ));
}
}
public class Savanne : BaseCreature 
 { 
public  Savanne() : base() 
 { 
Model = 7023;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Savanne" ;
Flags1 = 0x08480006 ;
Id = 7945 ; 
Guild = "Fishing Supplies";
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
Level = RandomLevel( 49 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 2025 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 54, 70 );
NpcText00 = "Greetings $N, I am Savanne." ;
BaseMana = 0 ;
Sells = new Item[] { new FishingPole()
                           , new StrongFishingPole()
                           , new ShinyBauble()
                           , new Nightcrawlers()
                           , new BrightBaubles()
                           , new AquadynamicFishAttractor()
  } ;
Faction = Factions.Darnasus;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
Equip( new Item( 7453, InventoryTypes.OneHand, 2, 4, 2, 2, 0, 0, 0 ));
}
}
public class Zansoa : BaseCreature 
 { 
public  Zansoa() : base() 
 { 
Model = 4610;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Zansoa" ;
Flags1 = 0x08480046 ;
Id = 5942 ; 
Guild = "Fishing Supplies";
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
Level = RandomLevel( 14 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 584 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 15, 19 );
NpcText00 = "Greetings $N, I am Zansoa." ;
BaseMana = 0 ;
Sells = new Item[] { new FishingPole()
                           , new RecipeSlitherskinMackerel()
                           , new StrongFishingPole()
                           , new RecipeRainbowFinAlbacore()
                           , new ShinyBauble()
                           , new Nightcrawlers()
                           , new BrightBaubles()
                           , new AquadynamicFishAttractor()
  } ;
Faction = Factions.DarkspearTrolls;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 10815, InventoryTypes.OneHand, 2, 14, 1, 7, 0, 0, 0 ), new Item( 6434, InventoryTypes.OneHand, 2, 14, 1, 7, 0, 0, 0 ));
}
}
public class HarnLongcast : BaseCreature 
 { 
public  HarnLongcast() : base() 
 { 
Model = 4608;
AttackSpeed= 2000;
BoundingRadius = 0.974700f ;
Name = "Harn Longcast" ;
Flags1 = 0x08480046 ;
Id = 5940 ; 
Guild = "Fishing Supplies";
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
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 384 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 4.05f ;
SetDamage ( 9, 12 );
NpcText00 = "Greetings $N, I am Harn Longcast." ;
BaseMana = 0 ;
Sells = new Item[] { new FishingPole()
                           , new RecipeBrilliantSmallfish()
                           , new RecipeLongjawMudSnapper()
                           , new StrongFishingPole()
                           , new ShinyBauble()
                           , new Nightcrawlers()
                           , new BrightBaubles()
                           , new AquadynamicFishAttractor()
  } ;
Faction = Factions.ThunderBluff;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 10816, InventoryTypes.OneHand, 2, 14, 1, 7, 0, 0, 0 ));
}
}
public class Shankys : BaseCreature 
 { 
public  Shankys() : base() 
 { 
Model = 1333;
AttackSpeed= 1739;
BoundingRadius = 0.236000f ;
Name = "Shankys" ;
Flags1 = 0x08480046 ;
Id = 3333 ; 
Guild = "Fishing Supplies";
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
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Shankys." ;
BaseMana = 0 ;
Sells = new Item[] { new RecipeMithrilHeadTrout()
                           , new FishingPole()
                           , new StrongFishingPole()
                           , new RecipeRainbowFinAlbacore()
                           , new RecipeRockscaleCod()
                           , new ShinyBauble()
                           , new Nightcrawlers()
                           , new BrightBaubles()
                           , new AquadynamicFishAttractor()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7453, InventoryTypes.OneHand, 2, 4, 2, 2, 0, 0, 0 ));
}
}
public class MaiLahii : BaseCreature 
 { 
public  MaiLahii() : base() 
 { 
Model = 12037;
AttackSpeed= 1693;
BoundingRadius = 1.00f ;
Name = "Mai'Lahii" ;
Flags1 = 0x08480046 ;
Id = 12031 ; 
Guild = "Fishing Supplies";
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
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 11.00f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Mai'Lahii." ;
BaseMana = 1503 ;
Sells = new Item[] { new FishingPole()
                           , new StrongFishingPole()
                           , new ShinyBauble()
                           , new Nightcrawlers()
                           , new BrightBaubles()
                           , new AquadynamicFishAttractor()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}
public class Wigcik : BaseCreature 
 { 
public  Wigcik() : base() 
 { 
Model = 7184;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Wigcik" ;
Flags1 = 0x08080046 ;
Id = 2842 ; 
Guild = "Superior Fisherman";
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
Level = RandomLevel( 43 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1745 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 47, 60 );
NpcText00 = "Greetings $N, I am Wigcik." ;
BaseMana = 0 ;
Sells = new Item[] { new LongjawMudSnapper()
                           , new BristleWhiskerCatfish()
                           , new RockscaleCod()
                           , new SpottedYellowtail()
                           , new SlitherskinMackerel()
                           , new SpinefinHalibut()
  } ;
Faction = Factions.BootyBay;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 7453, InventoryTypes.OneHand, 2, 4, 2, 2, 0, 0, 0 ));
}
}
public class OldManHeming : BaseCreature 
 { 
public  OldManHeming() : base() 
 { 
Model = 4491;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Old Man Heming" ;
Flags1 = 0x08080046 ;
Id = 2626 ; 
Guild = "Fisherman";
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
Level = RandomLevel( 43 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1745 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 47, 60 );
NpcText00 = "Greetings $N, I am Old Man Heming." ;
BaseMana = 0 ;
Sells = new Item[] { new ExpertFishingTheBassAndYou()
                           , new FishingPole()
                           , new StrongFishingPole()
                           , new ShinyBauble()
                           , new Nightcrawlers()
                           , new BrightBaubles()
                           , new AquadynamicFishAttractor()
  } ;
Faction = Factions.BootyBay;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 7453, InventoryTypes.OneHand, 2, 4, 2, 2, 0, 0, 0 ));
}
}
public class NessaShadowsong : BaseCreature 
 { 
public  NessaShadowsong() : base() 
 { 
Model = 9344;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Nessa Shadowsong" ;
Flags1 = 0x08480046 ;
Id = 10118 ; 
Guild = "Fishing Supplies";
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
Level = RandomLevel( 25 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1024 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 27, 35 );
NpcText00 = "Greetings $N, I am Nessa Shadowsong." ;
BaseMana = 0 ;
Sells = new Item[] { new FishingPole()
                           , new RecipeSlitherskinMackerel()
                           , new StrongFishingPole()
                           , new RecipeRainbowFinAlbacore()
                           , new ShinyBauble()
                           , new Nightcrawlers()
                           , new BrightBaubles()
                           , new AquadynamicFishAttractor()
  } ;
Faction = Factions.Darnasus;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7453, InventoryTypes.OneHand, 2, 4, 2, 2, 0, 0, 0 ));
}
}
}