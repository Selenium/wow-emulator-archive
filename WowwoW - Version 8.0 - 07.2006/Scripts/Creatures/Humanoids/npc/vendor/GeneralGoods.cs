//originally Scripted By DiScS Converter
//Edited by *place name here*
using System;
using Server.Items;

////////////////////
namespace Server.Creatures
{
public class ChristiGalvanis : BaseCreature 
 { 
public  ChristiGalvanis() : base() 
 { 
Model = 12916;
AttackSpeed= 2000;
BoundingRadius = 0.208000f ;
Name = "Christi Galvanis" ;
Flags1 = 0x08480046 ;
Id = 12960 ; 
Guild = "General Goods";
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
NpcText00 = "Greetings $N, I am Christi Galvanis." ;
BaseMana = 0 ;
Sells = new Item[] { new AccurateSlugs()
                           , new JaggedArrow()
                           , new IceColdMilk()
                           , new MelonJuice()
                           , new GleamingThrowingAxe()
                           , new WickedThrowingDagger()
                           , new RefreshingSpringWater()
                           , new MoonberryJuice()
                           , new SweetNectar()
                           , new RoughArrow()
                           , new SharpArrow()
                           , new LightShot()
                           , new HeavyShot()
                           , new BalancedThrowingDagger()
                           , new RazorArrow()
                           , new SolidShot()
                           , new KeenThrowingKnife()
                           , new HeavyThrowingDagger()
                           , new WeightedThrowingAxe()
                           , new SharpThrowingAxe()
                           , new DeadlyThrowingAxe()
                           , new SimpleWood()
                           , new FlintAndTinder()
                           , new SmallBrownPouch()
                           , new HeavyBrownBag()
                           , new BrownLeatherSatchel()
                           , new BlueRibbonedWrappingPaper()
  } ;
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 7462, InventoryTypes.OneHand, 2, 4, 2, 7, 0, 0, 0 ));
}
}
public class Nergal : BaseCreature 
 { 
public  Nergal() : base() 
 { 
Model = 13729;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Nergal" ;
Flags1 = 0x0480006 ;
Id = 12959 ; 
Guild = "General Goods Vendor";
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
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 2105 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 57, 73 );
NpcText00 = "Greetings $N, I am Nergal." ;
BaseMana = 0 ;
Sells = new Item[] { new AccurateSlugs()
                           , new JaggedArrow()
                           , new ToughJerky()
                           , new IceColdMilk()
                           , new MelonJuice()
                           , new GleamingThrowingAxe()
                           , new WickedThrowingDagger()
                           , new PatternDevilsaurGauntlets()
                           , new RefreshingSpringWater()
                           , new MoonberryJuice()
                           , new SweetNectar()
                           , new HaunchOfMeat()
                           , new SharpArrow()
                           , new HeavyShot()
                           , new RazorArrow()
                           , new SolidShot()
                           , new KeenThrowingKnife()
                           , new HeavyThrowingDagger()
                           , new SharpThrowingAxe()
                           , new DeadlyThrowingAxe()
                           , new MuttonChop()
                           , new WildHogShank()
                           , new SimpleWood()
                           , new FlintAndTinder()
                           , new HeavyBrownBag()
                           , new BrownLeatherSatchel()
                           , new CuredHamSteak()
                           , new SoulShard()
                           , new MorningGloryDew()
                           , new RoastedQuail()
  } ;
Faction = Factions.Friend;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
}
}
public class Tukk : BaseCreature 
 { 
public  Tukk() : base() 
 { 
Model = 12039;
AttackSpeed= 1693;
BoundingRadius = 1.00f ;
Name = "Tukk" ;
Flags1 = 0x08480046 ;
Id = 12027 ; 
Guild = "General Goods Vendor";
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
NpcText00 = "Greetings $N, I am Tukk." ;
BaseMana = 1503 ;
Sells = new Item[] { new AccurateSlugs()
                           , new JaggedArrow()
                           , new IceColdMilk()
                           , new MelonJuice()
                           , new GleamingThrowingAxe()
                           , new WickedThrowingDagger()
                           , new RefreshingSpringWater()
                           , new MoonberryJuice()
                           , new SweetNectar()
                           , new RoughArrow()
                           , new SharpArrow()
                           , new LightShot()
                           , new HeavyShot()
                           , new BalancedThrowingDagger()
                           , new RazorArrow()
                           , new SolidShot()
                           , new KeenThrowingKnife()
                           , new HeavyThrowingDagger()
                           , new WeightedThrowingAxe()
                           , new SharpThrowingAxe()
                           , new DeadlyThrowingAxe()
                           , new SimpleWood()
                           , new FlintAndTinder()
                           , new SmallBrownPouch()
                           , new HeavyBrownBag()
                           , new BrownLeatherSatchel()
                           , new BlueRibbonedWrappingPaper()
                           , new SoulShard()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}
public class DaeolynSummerleaf : BaseCreature 
 { 
public  DaeolynSummerleaf() : base() 
 { 
Model = 12045;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Daeolyn Summerleaf" ;
Flags1 = 0x08080046 ;
Id = 12021 ; 
Guild = "General Goods";
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
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 2065 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 55, 72 );
NpcText00 = "Greetings $N, I am Daeolyn Summerleaf." ;
BaseMana = 0 ;
Sells = new Item[] { new AccurateSlugs()
                           , new JaggedArrow()
                           , new IceColdMilk()
                           , new MelonJuice()
                           , new GleamingThrowingAxe()
                           , new WickedThrowingDagger()
                           , new RefreshingSpringWater()
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
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
Equip( new Item( 6434, InventoryTypes.OneHand, 2, 15, 1, 3, 0, 0, 0 ));
}
}
public class GornOneEye : BaseCreature 
 { 
public  GornOneEye() : base() 
 { 
Model = 1012;
AttackSpeed= 2000;
BoundingRadius = 1.500000f ;
Name = "Gorn One Eye" ;
Flags1 = 0x080004 ;
Id = 11555 ; 
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
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 2226 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.875f ;
SetDamage ( 60, 77 );
NpcText00 = "Hello" ;
BaseMana = 0 ;
Sells = new Item[] { new AccurateSlugs()
                           , new JaggedArrow()
                           , new MelonJuice()
                           , new GleamingThrowingAxe()
                           , new WickedThrowingDagger()
                           , new RefreshingSpringWater()
                           , new MoonberryJuice()
                           , new FurbolgMedicinePouch()
                           , new FurbolgMedicineTotem()
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
Faction = Factions.ThundermawFurbolgs;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
}
}
public class CaretakerAlen : BaseCreature 
 { 
public  CaretakerAlen() : base() 
 { 
Model = 10560;
AttackSpeed= 1386;
BoundingRadius = 1.00f ;
Name = "Caretaker Alen" ;
Flags1 = 0x080046 ;
Id = 11038 ; 
Guild = "The Argent Dawn";
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
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 2105 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 11.00f ;
SetDamage ( 57, 73 );
NpcText00 = "Greetings $N, I am Caretaker Alen." ;
BaseMana = 2604 ;
Sells = new Item[] { new AccurateSlugs()
                           , new JaggedArrow()
                           , new IceColdMilk()
                           , new MelonJuice()
                           , new GleamingThrowingAxe()
                           , new WickedThrowingDagger()
                           , new RefreshingSpringWater()
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
                           , new ForestMushroomCap()
                           , new RedSpeckledMushroom()
                           , new SpongyMorel()
                           , new DeliciousCaveMold()
                           , new RawBlackTruffle()
                           , new MorningGloryDew()
                           , new DriedKingBolete()
  } ;
Faction = Factions.ArgentDawn;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
Equip( new Item( 7469, InventoryTypes.OneHand, 2, 4, 2, 7, 0, 0, 0 ));
}
}
public class Kuruk : BaseCreature 
 { 
public  Kuruk() : base() 
 { 
Model = 7626;
AttackSpeed= 2000;
BoundingRadius = 0.974700f ;
Name = "Kuruk" ;
Flags1 = 0x08480046 ;
Id = 8362 ; 
Guild = "General Goods Vendor";
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
CombatReach = 4.05f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Kuruk." ;
BaseMana = 0 ;
Sells = new Item[] { new AccurateSlugs()
                           , new JaggedArrow()
                           , new IceColdMilk()
                           , new MelonJuice()
                           , new GleamingThrowingAxe()
                           , new WickedThrowingDagger()
                           , new RefreshingSpringWater()
                           , new MoonberryJuice()
                           , new SweetNectar()
                           , new RoughArrow()
                           , new SharpArrow()
                           , new LightShot()
                           , new HeavyShot()
                           , new BalancedThrowingDagger()
                           , new SmallThrowingKnife()
                           , new RazorArrow()
                           , new SolidShot()
                           , new KeenThrowingKnife()
                           , new HeavyThrowingDagger()
                           , new CrudeThrowingAxe()
                           , new WeightedThrowingAxe()
                           , new SharpThrowingAxe()
                           , new DeadlyThrowingAxe()
                           , new SimpleWood()
                           , new FlintAndTinder()
                           , new SmallBrownPouch()
                           , new HeavyBrownBag()
                           , new BrownLeatherSatchel()
                           , new ToughHunkOfBread()
                           , new RedRibbonedWrappingPaper()
                           , new BlueRibbonedWrappingPaper()
                           , new SoulShard()
  } ;
Faction = Factions.ThunderBluff;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7443, InventoryTypes.OneHand, 2, 4, 2, 7, 0, 0, 0 ));
}
}
public class Jabbey : BaseCreature 
 { 
public  Jabbey() : base() 
 { 
Model = 7355;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Jabbey" ;
Flags1 = 0x08080046 ;
Id = 8139 ; 
Guild = "General Goods";
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
NpcText00 = "Greetings $N, I am Jabbey." ;
BaseMana = 0 ;
Sells = new Item[] { new AccurateSlugs()
                           , new JaggedArrow()
                           , new IceColdMilk()
                           , new MelonJuice()
                           , new GleamingThrowingAxe()
                           , new WickedThrowingDagger()
                           , new RefreshingSpringWater()
                           , new MoonberryJuice()
                           , new RecipeUndermineClamChowder()
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
Faction = Factions.Gadgetzan;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 23172, InventoryTypes.OneHand, 2, 14, 1, 0, 0, 0, 0 ));
}
}
public class Faralorn : BaseCreature 
 { 
public  Faralorn() : base() 
 { 
Model = 7024;
AttackSpeed= 2000;
BoundingRadius = 0.389000f ;
Name = "Faralorn" ;
Flags1 = 0x08480006 ;
Id = 7942 ; 
Guild = "General Supplies";
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
Level = RandomLevel( 53 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 2145 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 58, 75 );
NpcText00 = "Greetings $N, I am Faralorn." ;
BaseMana = 0 ;
Sells = new Item[] { new AccurateSlugs()
                           , new JaggedArrow()
                           , new IceColdMilk()
                           , new MelonJuice()
                           , new GleamingThrowingAxe()
                           , new WickedThrowingDagger()
                           , new RefreshingSpringWater()
                           , new MoonberryJuice()
                           , new SweetNectar()
                           , new RoughArrow()
                           , new SharpArrow()
                           , new LightShot()
                           , new HeavyShot()
                           , new BalancedThrowingDagger()
                           , new RazorArrow()
                           , new SolidShot()
                           , new KeenThrowingKnife()
                           , new HeavyThrowingDagger()
                           , new WeightedThrowingAxe()
                           , new SharpThrowingAxe()
                           , new DeadlyThrowingAxe()
                           , new SimpleWood()
                           , new FlintAndTinder()
                           , new SmallBrownPouch()
                           , new HeavyBrownBag()
                           , new BrownLeatherSatchel()
                           , new BlueRibbonedWrappingPaper()
  } ;
Faction = Factions.Darnasus;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
}
}
public class BrylliaIronbrand : BaseCreature 
 { 
public  BrylliaIronbrand() : base() 
 { 
Model = 3041;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Bryllia Ironbrand" ;
Flags1 = 0x08480046 ;
Id = 5101 ; 
Guild = "General Goods Vendor";
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
NpcText00 = "Greetings $N, I am Bryllia Ironbrand." ;
BaseMana = 0 ;
Sells = new Item[] { new AccurateSlugs()
                           , new JaggedArrow()
                           , new MelonJuice()
                           , new GleamingThrowingAxe()
                           , new WickedThrowingDagger()
                           , new RefreshingSpringWater()
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
                           , new SoulShard()
  } ;
Faction = Factions.IronForge;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 12236, InventoryTypes.OneHand, 2, 4, 2, 7, 0, 0, 0 ));
}
}
public class CharityMipsy : BaseCreature 
 { 
public  CharityMipsy() : base() 
 { 
Model = 4854;
AttackSpeed= 2000;
BoundingRadius = 0.208000f ;
Name = "Charity Mipsy" ;
Flags1 = 0x08480046 ;
Id = 4896 ; 
Guild = "General Goods";
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
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1424 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 38, 49 );
NpcText00 = "Greetings $N, I am Charity Mipsy." ;
BaseMana = 0 ;
Sells = new Item[] { new AccurateSlugs()
                           , new JaggedArrow()
                           , new MelonJuice()
                           , new GleamingThrowingAxe()
                           , new WickedThrowingDagger()
                           , new RefreshingSpringWater()
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
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 23172, InventoryTypes.OneHand, 2, 14, 1, 0, 0, 0, 0 ));
}
}
public class JawnHighmesa : BaseCreature 
 { 
public  JawnHighmesa() : base() 
 { 
Model = 4306;
AttackSpeed= 2000;
BoundingRadius = 0.974700f ;
Name = "Jawn Highmesa" ;
Flags1 = 0x08400046 ;
Id = 4876 ; 
Guild = "General Goods";
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
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1424 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 4.05f ;
SetDamage ( 38, 49 );
NpcText00 = "Greetings $N, I am Jawn Highmesa." ;
BaseMana = 0 ;
Sells = new Item[] { new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
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
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 23172, InventoryTypes.HeldInHand, 4, 0, 1, 0, 0, 0, 0 ));
}
}
public class EleanorRusk : BaseCreature 
 { 
public  EleanorRusk() : base() 
 { 
Model = 2660;
AttackSpeed= 2000;
BoundingRadius = 0.383000f ;
Name = "Eleanor Rusk" ;
Flags1 = 0x018480046 ;
Id = 4555 ; 
Guild = "General Goods Vendor";
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
NpcText00 = "Greetings $N, I am Eleanor Rusk." ;
BaseMana = 0 ;
Sells = new Item[] { new AccurateSlugs()
                           , new JaggedArrow()
                           , new IceColdMilk()
                           , new MelonJuice()
                           , new GleamingThrowingAxe()
                           , new WickedThrowingDagger()
                           , new RefreshingSpringWater()
                           , new MoonberryJuice()
                           , new SweetNectar()
                           , new RoughArrow()
                           , new SharpArrow()
                           , new LightShot()
                           , new HeavyShot()
                           , new BalancedThrowingDagger()
                           , new SmallThrowingKnife()
                           , new RazorArrow()
                           , new SolidShot()
                           , new KeenThrowingKnife()
                           , new HeavyThrowingDagger()
                           , new CrudeThrowingAxe()
                           , new WeightedThrowingAxe()
                           , new SharpThrowingAxe()
                           , new DeadlyThrowingAxe()
                           , new SimpleWood()
                           , new FlintAndTinder()
                           , new SmallBrownPouch()
                           , new HeavyBrownBag()
                           , new BrownLeatherSatchel()
                           , new RedRibbonedWrappingPaper()
                           , new BlueRibbonedWrappingPaper()
                           , new SoulShard()
  } ;
Faction = Factions.Undercity;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7460, InventoryTypes.OneHand, 2, 14, 1, 7, 0, 0, 0 ), new Item( 23172, InventoryTypes.HeldInHand, 4, 0, 1, 0, 0, 0, 0 ));
}
}
public class Mydrannul : BaseCreature 
 { 
public  Mydrannul() : base() 
 { 
Model = 2262;
AttackSpeed= 2000;
BoundingRadius = 0.389000f ;
Name = "Mydrannul" ;
Flags1 = 0x08480046 ;
Id = 4241 ; 
Guild = "General Goods Vendor";
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
BaseHitPoints = 1625 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 43, 56 );
NpcText00 = "Greetings $N, I am Mydrannul." ;
BaseMana = 0 ;
Sells = new Item[] { new IceColdMilk()
                           , new RefreshingSpringWater()
                           , new RoughArrow()
                           , new SharpArrow()
                           , new LightShot()
                           , new HeavyShot()
                           , new BalancedThrowingDagger()
                           , new SmallThrowingKnife()
                           , new CrudeThrowingAxe()
                           , new WeightedThrowingAxe()
                           , new SimpleWood()
                           , new FlintAndTinder()
                           , new SmallBrownPouch()
                           , new BrownLeatherSatchel()
                           , new RedRibbonedWrappingPaper()
                           , new SoulShard()
  } ;
Faction = Factions.Darnasus;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}
public class Dalmond : BaseCreature 
 { 
public  Dalmond() : base() 
 { 
Model = 4404;
AttackSpeed= 2000;
BoundingRadius = 0.389000f ;
Name = "Dalmond" ;
Flags1 = 0x08480046 ;
Id = 4182 ; 
Guild = "General Goods";
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
Level = RandomLevel( 17 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1625 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 43, 56 );
NpcText00 = "Greetings $N, I am Dalmond." ;
BaseMana = 0 ;
Sells = new Item[] { new IceColdMilk()
                           , new RefreshingSpringWater()
                           , new RoughArrow()
                           , new SharpArrow()
                           , new LightShot()
                           , new HeavyShot()
                           , new BalancedThrowingDagger()
                           , new SmallThrowingKnife()
                           , new CrudeThrowingAxe()
                           , new WeightedThrowingAxe()
                           , new SimpleWood()
                           , new FlintAndTinder()
                           , new SmallBrownPouch()
                           , new BrownLeatherSatchel()
                           , new RedRibbonedWrappingPaper()
  } ;
Faction = Factions.Darnasus;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
}
}
public class Ellandrieth : BaseCreature 
 { 
public  Ellandrieth() : base() 
 { 
Model = 2218;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Ellandrieth" ;
Flags1 = 0x08480046 ;
Id = 4170 ; 
Guild = "General Goods Vendor";
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
NpcText00 = "Greetings $N, I am Ellandrieth." ;
BaseMana = 0 ;
Sells = new Item[] { new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
                           , new RoughArrow()
                           , new SharpArrow()
                           , new LightShot()
                           , new HeavyShot()
                           , new BalancedThrowingDagger()
                           , new SmallThrowingKnife()
                           , new RazorArrow()
                           , new SolidShot()
                           , new KeenThrowingKnife()
                           , new HeavyThrowingDagger()
                           , new CrudeThrowingAxe()
                           , new WeightedThrowingAxe()
                           , new SharpThrowingAxe()
                           , new DeadlyThrowingAxe()
                           , new SimpleWood()
                           , new FlintAndTinder()
                           , new SmallBrownPouch()
                           , new HeavyBrownBag()
                           , new BrownLeatherSatchel()
                           , new RedRibbonedWrappingPaper()
                           , new BlueRibbonedWrappingPaper()
                           , new SoulShard()
  } ;
Faction = Factions.Darnasus;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}
public class Chylina : BaseCreature 
 { 
public  Chylina() : base() 
 { 
Model = 4106;
AttackSpeed= 1777;
BoundingRadius = 1.00f ;
Name = "Chylina" ;
Flags1 = 0x08400046 ;
Id = 4084 ; 
Guild = "General Supplies";
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
NpcText00 = "Greetings $N, I am Chylina." ;
BaseMana = 1203 ;
Sells = new Item[] { new ToughJerky()
                           , new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
                           , new HaunchOfMeat()
                           , new RoughArrow()
                           , new SharpArrow()
                           , new LightShot()
                           , new HeavyShot()
                           , new BalancedThrowingDagger()
                           , new KeenThrowingKnife()
                           , new WeightedThrowingAxe()
                           , new SharpThrowingAxe()
                           , new MuttonChop()
                           , new WildHogShank()
                           , new SimpleWood()
                           , new FlintAndTinder()
                           , new SmallBrownPouch()
                           , new BrownLeatherSatchel()
                           , new SnapvineWatermelon()
                           , new BristleWhiskerCatfish()
                           , new CuredHamSteak()
                           , new BlueRibbonedWrappingPaper()
                           , new RoastedQuail()
  } ;
Faction = Factions.Darnasus;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7434, InventoryTypes.OneHand, 2, 14, 1, 3, 0, 0, 0 ), new Item( 23172, InventoryTypes.HeldInHand, 4, 0, 1, 0, 0, 0, 0 ));
}
}
public class HaljanOakheart : BaseCreature 
 { 
public  HaljanOakheart() : base() 
 { 
Model = 2060;
AttackSpeed= 2000;
BoundingRadius = 0.389000f ;
Name = "Haljan Oakheart" ;
Flags1 = 0x08480046 ;
Id = 3962 ; 
Guild = "General Goods";
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
Level = RandomLevel( 26 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1064 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 28, 36 );
NpcText00 = "Greetings $N, I am Haljan Oakheart." ;
BaseMana = 0 ;
Sells = new Item[] { new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
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
                           , new ClamMeat()
  } ;
Faction = Factions.Darnasus;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}
public class Grawnal : BaseCreature 
 { 
public  Grawnal() : base() 
 { 
Model = 3890;
AttackSpeed= 2000;
BoundingRadius = 0.372000f ;
Name = "Grawnal" ;
Flags1 = 0x08480046 ;
Id = 4082 ; 
Guild = "General Goods";
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
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1264 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 33, 43 );
NpcText00 = "Greetings $N, I am Grawnal." ;
BaseMana = 0 ;
Sells = new Item[] { new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
                           , new RoughArrow()
                           , new SharpArrow()
                           , new LightShot()
                           , new HeavyShot()
                           , new BalancedThrowingDagger()
                           , new KeenThrowingKnife()
                           , new WeightedThrowingAxe()
                           , new SharpThrowingAxe()
                           , new SimpleWood()
                           , new FlintAndTinder()
                           , new SmallBrownPouch()
                           , new BrownLeatherSatchel()
                           , new BlueRibbonedWrappingPaper()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 23172, InventoryTypes.HeldInHand, 4, 0, 1, 0, 0, 0, 0 ));
}
}
public class Zlagk : BaseCreature 
 { 
public  Zlagk() : base() 
 { 
Model = 3753;
AttackSpeed= 2000;
BoundingRadius = 0.372000f ;
Name = "Zlagk" ;
Flags1 = 0x08080066 ;
Id = 3882 ; 
Guild = "Butcher";
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
CombatReach = 1.5f ;
SetDamage ( 9, 12 );
NpcText00 = "Greetings $N, I am Zlagk." ;
BaseMana = 0 ;
Sells = new Item[] { new ToughJerky()
                           , new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
                           , new MoonberryJuice()
                           , new SweetNectar()
                           , new HaunchOfMeat()
                           , new MuttonChop()
                           , new WildHogShank()
                           , new CuredHamSteak()
                           , new MorningGloryDew()
                           , new RoastedQuail()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
}
}
public class Grimtak : BaseCreature 
 { 
public  Grimtak() : base() 
 { 
Model = 3755;
AttackSpeed= 2000;
BoundingRadius = 0.372000f ;
Name = "Grimtak" ;
Flags1 = 0x08480046 ;
Id = 3881 ; 
Guild = "Butcher";
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
NpcText00 = "Greetings $N, I am Grimtak." ;
BaseMana = 0 ;
Sells = new Item[] { new ToughJerky()
                           , new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
                           , new MoonberryJuice()
                           , new SweetNectar()
                           , new HaunchOfMeat()
                           , new MuttonChop()
                           , new WildHogShank()
                           , new CuredHamSteak()
                           , new RecipeScorpidSurprise()
                           , new MorningGloryDew()
                           , new RoastedQuail()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 7431, InventoryTypes.OneHand, 2, 0, 1, 3, 0, 0, 0 ),new Item( 7463, InventoryTypes.OneHand, 2, 4, 2, 7, 0, 0, 0 ));
}
}
public class Gahroot : BaseCreature 
 { 
public  Gahroot() : base() 
 { 
Model = 3843;
AttackSpeed= 2000;
BoundingRadius = 0.974700f ;
Name = "Gahroot" ;
Flags1 = 0x08400046 ;
Id = 3705 ; 
Guild = "Butcher";
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
CombatReach = 4.05f ;
SetDamage ( 27, 35 );
NpcText00 = "Greetings $N, I am Gahroot." ;
BaseMana = 0 ;
Sells = new Item[] { new ToughJerky()
                           , new HaunchOfMeat()
                           , new MuttonChop()
                           , new WildHogShank()
                           , new CuredHamSteak()
                           , new RoastedQuail()
  } ;
Faction = Factions.ThunderBluff;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7462, InventoryTypes.OneHand, 2, 4, 2, 7, 0, 0, 0 ));
}
}
public class Aldia : BaseCreature 
 { 
public  Aldia() : base() 
 { 
Model = 1700;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Aldia" ;
Flags1 = 0x08480046 ;
Id = 3608 ; 
Guild = "General Supplies";
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
Level = RandomLevel( 17 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 704 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 18, 23 );
NpcText00 = "Greetings $N, I am Aldia." ;
BaseMana = 0 ;
Sells = new Item[] { new RefreshingSpringWater()
                           , new RoughArrow()
                           , new LightShot()
                           , new BalancedThrowingDagger()
                           , new SmallThrowingKnife()
                           , new CrudeThrowingAxe()
                           , new WeightedThrowingAxe()
                           , new SimpleWood()
                           , new FlintAndTinder()
                           , new SmallBrownPouch()
                           , new BrownLeatherSatchel()
                           , new RedRibbonedWrappingPaper()
  } ;
Faction = Factions.Darnasus;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 23318, InventoryTypes.OneHand, 2, 14, 1, 0, 0, 0, 0 ));
}
}
public class SarahRaycroft : BaseCreature 
 { 
public  SarahRaycroft() : base() 
 { 
Model = 3696;
AttackSpeed= 2000;
BoundingRadius = 0.208000f ;
Name = "Sarah Raycroft" ;
Flags1 = 0x08480046 ;
Id = 3541 ; 
Guild = "General Goods";
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
NpcText00 = "Greetings $N, I am Sarah Raycroft." ;
BaseMana = 0 ;
Sells = new Item[] { new AccurateSlugs()
                           , new JaggedArrow()
                           , new IceColdMilk()
                           , new MelonJuice()
                           , new GleamingThrowingAxe()
                           , new WickedThrowingDagger()
                           , new RefreshingSpringWater()
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
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 23172, InventoryTypes.OneHand, 2, 14, 1, 0, 0, 0, 0 ));
}
}
public class Zargh : BaseCreature 
 { 
public  Zargh() : base() 
 { 
Model = 3877;
AttackSpeed= 2000;
BoundingRadius = 0.372000f ;
Name = "Zargh" ;
Flags1 = 0x08480046 ;
Id = 3489 ; 
Guild = "Butcher";
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
Level = RandomLevel( 16 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 664 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 17, 22 );
NpcText00 = "Greetings $N, I am Zargh." ;
BaseMana = 0 ;
Sells = new Item[] { new ToughJerky()
                           , new HaunchOfMeat()
                           , new RecipeHotLionChops()
                           , new MuttonChop()
                           , new WildHogShank()
                           , new CuredHamSteak()
                           , new RoastedQuail()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 7431, InventoryTypes.OneHand, 2, 0, 1, 3, 0, 0, 0 ), new Item( 24116, InventoryTypes.OneHand, 4, 0, 2, 0, 0, 0, 0 ));
}
}
public class Barg : BaseCreature 
 { 
public  Barg() : base() 
 { 
Model = 3868;
AttackSpeed= 2000;
BoundingRadius = 0.372000f ;
Name = "Barg" ;
Flags1 = 0x08480046 ;
Id = 3481 ; 
Guild = "General Supplies";
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
NpcText00 = "Greetings $N, I am Barg." ;
BaseMana = 0 ;
Sells = new Item[] { new IceColdMilk()
                           , new RefreshingSpringWater()
                           , new RoughArrow()
                           , new SharpArrow()
                           , new LightShot()
                           , new HeavyShot()
                           , new BalancedThrowingDagger()
                           , new SmallThrowingKnife()
                           , new CrudeThrowingAxe()
                           , new WeightedThrowingAxe()
                           , new SimpleWood()
                           , new FlintAndTinder()
                           , new SmallBrownPouch()
                           , new BrownLeatherSatchel()
                           , new RedRibbonedWrappingPaper()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 19132, InventoryTypes.OneHand, 2, 0, 1, 3, 0, 0, 0 ));
}
}
public class Dennika : BaseCreature 
 { 
public  Dennika() : base() 
 { 
Model = 4357;
AttackSpeed= 1693;
BoundingRadius = 1.00f ;
Name = "Denni'ka" ;
Flags1 = 0x08400046 ;
Id = 3411 ; 
Guild = "Butcher";
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
Level = RandomLevel( 25, 35 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Denni'ka." ;
BaseMana = 1503 ;
Sells = new Item[] { new ToughJerky()
                           , new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
                           , new MoonberryJuice()
                           , new SweetNectar()
                           , new HaunchOfMeat()
                           , new MuttonChop()
                           , new WildHogShank()
                           , new CuredHamSteak()
                           , new MorningGloryDew()
                           , new RoastedQuail()
  } ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7431, InventoryTypes.OneHand, 2, 0, 1, 3, 0, 0, 0 ), new Item( 24116, InventoryTypes.HeldInHand, 4, 0, 2, 4, 0, 0, 0 ),new Item( 6231, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
}
}
public class Asoran : BaseCreature 
 { 
public  Asoran() : base() 
 { 
Model = 1371;
AttackSpeed= 1739;
BoundingRadius = 0.372000f ;
Name = "Asoran" ;
Flags1 = 0x08480046 ;
Id = 3350 ; 
Guild = "General Goods Vendor";
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
NpcText00 = "Greetings $N, I am Asoran." ;
BaseMana = 0 ;
Sells = new Item[] { new AccurateSlugs()
                           , new JaggedArrow()
                           , new MelonJuice()
                           , new GleamingThrowingAxe()
                           , new WickedThrowingDagger()
                           , new RefreshingSpringWater()
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
                           , new SoulShard()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 12236, InventoryTypes.OneHand, 2, 4, 2, 7, 0, 0, 0 ), new Item( 23172, InventoryTypes.HeldInHand, 4, 0, 1, 0, 0, 0, 0 ));
}
}
public class Trakgen : BaseCreature 
 { 
public  Trakgen() : base() 
 { 
Model = 1313;
AttackSpeed= 1739;
BoundingRadius = 0.372000f ;
Name = "Trak'gen" ;
Flags1 = 0x08480046 ;
Id = 3313 ; 
Guild = "General Goods Merchant";
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
NpcText00 = "Greetings $N, I am Trak'gen." ;
BaseMana = 0 ;
Sells = new Item[] { new AccurateSlugs()
                           , new JaggedArrow()
                           , new IceColdMilk()
                           , new MelonJuice()
                           , new GleamingThrowingAxe()
                           , new WickedThrowingDagger()
                           , new RefreshingSpringWater()
                           , new MoonberryJuice()
                           , new SweetNectar()
                           , new RoughArrow()
                           , new SharpArrow()
                           , new LightShot()
                           , new HeavyShot()
                           , new BalancedThrowingDagger()
                           , new SmallThrowingKnife()
                           , new RazorArrow()
                           , new SolidShot()
                           , new KeenThrowingKnife()
                           , new HeavyThrowingDagger()
                           , new CrudeThrowingAxe()
                           , new WeightedThrowingAxe()
                           , new SharpThrowingAxe()
                           , new DeadlyThrowingAxe()
                           , new SimpleWood()
                           , new FlintAndTinder()
                           , new SmallBrownPouch()
                           , new HeavyBrownBag()
                           , new BrownLeatherSatchel()
                           , new ToughHunkOfBread()
                           , new RedRibbonedWrappingPaper()
                           , new BlueRibbonedWrappingPaper()
                           , new SoulShard()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 12236, InventoryTypes.OneHand, 2, 4, 2, 7, 0, 0, 0 ), new Item (23172, InventoryTypes.HeldInHand, 4, 0, 1, 0, 0, 0, 0 ));
}
}
public class Kwaii : BaseCreature 
 { 
public  Kwaii() : base() 
 { 
Model = 4089;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "K'waii" ;
Flags1 = 0x08480046 ;
Id = 3186 ; 
Guild = "General Goods";
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
Level = RandomLevel( 11 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 464 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 11, 15 );
NpcText00 = "Greetings $N, I am K'waii." ;
BaseMana = 0 ;
Sells = new Item[] { new RefreshingSpringWater()
                           , new RoughArrow()
                           , new LightShot()
                           , new BalancedThrowingDagger()
                           , new SmallThrowingKnife()
                           , new CrudeThrowingAxe()
                           , new WeightedThrowingAxe()
                           , new SimpleWood()
                           , new FlintAndTinder()
                           , new SmallBrownPouch()
                           , new BrownLeatherSatchel()
                           , new RedRibbonedWrappingPaper()
  } ;
Faction = Factions.DarkspearTrolls;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 23172, InventoryTypes.OneHand, 2, 14, 1, 0, 0, 0, 0 ));
}
}
public class Jark : BaseCreature 
 { 
public  Jark() : base() 
 { 
Model = 3737;
AttackSpeed= 2000;
BoundingRadius = 0.372000f ;
Name = "Jark" ;
Flags1 = 0x08480046 ;
Id = 3164 ; 
Guild = "General Goods";
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
BaseHitPoints = 624 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 16, 21 );
NpcText00 = "Greetings $N, I am Jark." ;
BaseMana = 0 ;
Sells = new Item[] { new RefreshingSpringWater()
                           , new RoughArrow()
                           , new LightShot()
                           , new BalancedThrowingDagger()
                           , new SmallThrowingKnife()
                           , new CrudeThrowingAxe()
                           , new WeightedThrowingAxe()
                           , new SimpleWood()
                           , new FlintAndTinder()
                           , new SmallBrownPouch()
                           , new BrownLeatherSatchel()
                           , new RedRibbonedWrappingPaper()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 23172, InventoryTypes.HeldInHand , 4, 0, 1, 0, 0, 0, 0 ));
}
}
public class Duokna : BaseCreature 
 { 
public  Duokna() : base() 
 { 
Model = 1879;
AttackSpeed= 2000;
BoundingRadius = 0.236000f ;
Name = "Duokna" ;
Flags1 = 0x08080066 ;
Id = 3158 ; 
Guild = "General Goods";
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
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 464 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 11, 15 );
NpcText00 = "Greetings $N, I am Duokna." ;
BaseMana = 0 ;
Sells = new Item[] { new RefreshingSpringWater()
                           , new RoughArrow()
                           , new LightShot()
                           , new SmallThrowingKnife()
                           , new CrudeThrowingAxe()
                           , new ToughHunkOfBread()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
}
}
public class MooratLongstride : BaseCreature 
 { 
public  MooratLongstride() : base() 
 { 
Model = 3800;
AttackSpeed= 2000;
BoundingRadius = 0.974700f ;
Name = "Moorat Longstride" ;
Flags1 = 0x08480046 ;
Id = 3076 ; 
Guild = "General Goods";
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
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 504 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 4.05f ;
SetDamage ( 13, 16 );
NpcText00 = "Greetings $N, I am Moorat Longstride." ;
BaseMana = 0 ;
Sells = new Item[] { new RefreshingSpringWater()
                           , new RoughArrow()
                           , new LightShot()
                           , new BalancedThrowingDagger()
                           , new SmallThrowingKnife()
                           , new CrudeThrowingAxe()
                           , new WeightedThrowingAxe()
                           , new SimpleWood()
                           , new FlintAndTinder()
                           , new SmallBrownPouch()
                           , new BrownLeatherSatchel()
                           , new RedRibbonedWrappingPaper()
  } ;
Faction = Factions.ThunderBluff;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 23172, InventoryTypes.HeldInHand, 4, 0, 1, 0, 0, 0, 0 ));
}
}
public class KawnieSoftbreeze : BaseCreature 
 { 
public  KawnieSoftbreeze() : base() 
 { 
Model = 3797;
AttackSpeed= 2000;
BoundingRadius = 0.872500f ;
Name = "Kawnie Softbreeze" ;
Flags1 = 0x08080066 ;
Id = 3072 ; 
Guild = "General Goods";
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
Level = RandomLevel( 8 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 304 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 3.75f ;
SetDamage ( 7, 9 );
NpcText00 = "Greetings $N, I am Kawnie Softbreeze." ;
BaseMana = 0 ;
Sells = new Item[] { new RefreshingSpringWater()
                           , new RoughArrow()
                           , new LightShot()
                           , new SmallThrowingKnife()
                           , new CrudeThrowingAxe()
                           , new ToughHunkOfBread()
  } ;
Faction = Factions.ThunderBluff;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 7443, InventoryTypes.OneHand, 2, 4, 2, 7, 0, 0, 0 ));
}
}
public class Grawl : BaseCreature 
 { 
public  Grawl() : base() 
 { 
Model = 4902;
AttackSpeed= 2000;
BoundingRadius = 0.372000f ;
Name = "Grawl" ;
Flags1 = 0x08480046 ;
Id = 2908 ; 
Guild = "General Goods";
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
Level = RandomLevel( 44 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1785 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 48, 62 );
NpcText00 = "Greetings $N, I am Grawl." ;
BaseMana = 0 ;
Sells = new Item[] { new AccurateSlugs()
                           , new JaggedArrow()
                           , new MelonJuice()
                           , new GleamingThrowingAxe()
                           , new WickedThrowingDagger()
                           , new RefreshingSpringWater()
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
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
}
}
public class Graud : BaseCreature 
 { 
public  Graud() : base() 
 { 
Model = 3952;
AttackSpeed= 2000;
BoundingRadius = 0.372000f ;
Name = "Graud" ;
Flags1 = 0x08480046 ;
Id = 2820 ; 
Guild = "General Goods";
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
Level = RandomLevel( 31 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1264 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 33, 43 );
NpcText00 = "Greetings $N, I am Graud." ;
BaseMana = 0 ;
Sells = new Item[] { new AccurateSlugs()
                           , new JaggedArrow()
                           , new MelonJuice()
                           , new GleamingThrowingAxe()
                           , new WickedThrowingDagger()
                           , new RefreshingSpringWater()
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
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 24596, InventoryTypes.OneHand, 2, 14, 1, 0, 0, 0, 0 ), new Item( 24117, InventoryTypes.HeldInHand, 4, 0, 2, 0, 0, 0, 0 ));
}
}
public class VikkiLonsav : BaseCreature 
 { 
public  VikkiLonsav() : base() 
 { 
Model = 3966;
AttackSpeed= 2000;
BoundingRadius = 0.208000f ;
Name = "Vikki Lonsav" ;
Flags1 = 0x08480046 ;
Id = 2808 ; 
Guild = "General Goods";
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
Level = RandomLevel( 36 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1464 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 39, 50 );
NpcText00 = "Greetings $N, I am Vikki Lonsav." ;
BaseMana = 0 ;
Sells = new Item[] { new AccurateSlugs()
                           , new JaggedArrow()
                           , new MelonJuice()
                           , new GleamingThrowingAxe()
                           , new WickedThrowingDagger()
                           , new RefreshingSpringWater()
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
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 23172, InventoryTypes.OneHand, 2, 14, 1, 0, 0, 0, 0 ));
}
}
public class Malygen : BaseCreature 
 { 
public  Malygen() : base() 
 { 
Model = 2241;
AttackSpeed= 2000;
BoundingRadius = 0.389000f ;
Name = "Malygen" ;
Flags1 = 0x08480046 ;
Id = 2803 ; 
Guild = "General Goods";
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
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 2025 ;
NpcFlags = (int)NpcActions.Trainer ;
CombatReach = 1.5f ;
SetDamage ( 54, 70 );
NpcText00 = "Greetings $N, I am Malygen." ;
BaseMana = 0 ;
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
Faction = Factions.Darnasus;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
}
}
public class KayrenSoothallow : BaseCreature 
 { 
public  KayrenSoothallow() : base() 
 { 
Model = 3659;
AttackSpeed= 2000;
BoundingRadius = 0.383000f ;
Name = "Kayren Soothallow" ;
Flags1 = 0x08400046 ;
Id = 2401 ; 
Guild = "General Goods";
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
NpcType = (int)NpcTypes.Undead;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Kayren Soothallow." ;
BaseMana = 0 ;
Sells = new Item[] { new AccurateSlugs()
                           , new JaggedArrow()
                           , new IceColdMilk()
                           , new MelonJuice()
                           , new GleamingThrowingAxe()
                           , new WickedThrowingDagger()
                           , new RefreshingSpringWater()
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
Faction = Factions.Undercity;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 5542, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ), new Item( 23172, InventoryTypes.HeldInHand, 4, 0, 1, 0, 0, 0, 0 ));
}
}
public class MrsWinters : BaseCreature 
 { 
public  MrsWinters() : base() 
 { 
Model = 1637;
AttackSpeed= 2000;
BoundingRadius = 0.383000f ;
Name = "Mrs. Winters" ;
Flags1 = 0x08400046 ;
Id = 2134 ; 
Guild = "General Supplies";
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
NpcType = (int)NpcTypes.Undead;
BaseHitPoints = 424 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 10, 14 );
NpcText00 = "Greetings $N, I am Mrs. Winters." ;
BaseMana = 0 ;
Sells = new Item[] { new RefreshingSpringWater()
                           , new RoughArrow()
                           , new LightShot()
                           , new BalancedThrowingDagger()
                           , new SmallThrowingKnife()
                           , new CrudeThrowingAxe()
                           , new WeightedThrowingAxe()
                           , new SimpleWood()
                           , new FlintAndTinder()
                           , new SmallBrownPouch()
                           , new BrownLeatherSatchel()
                           , new RedRibbonedWrappingPaper()
  } ;
Faction = Factions.Undercity;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 23174, InventoryTypes.OneHand, 2, 14, 1, 0, 0, 0, 0 ));
}
}
public class JoshuaKien : BaseCreature 
 { 
public  JoshuaKien() : base() 
 { 
Model = 1577;
AttackSpeed= 2000;
BoundingRadius = 0.383000f ;
Name = "Joshua Kien" ;
Flags1 = 0x08000066 ;
Id = 2115 ; 
Guild = "General Supplies";
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
Level = RandomLevel( 5 );
NpcType = (int)NpcTypes.Undead;
BaseHitPoints = 224 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 5, 6 );
NpcText00 = "Greetings $N, I am Joshua Kien." ;
BaseMana = 0 ;
Sells = new Item[] { new RefreshingSpringWater()
                           , new RoughArrow()
                           , new LightShot()
                           , new SmallThrowingKnife()
                           , new CrudeThrowingAxe()
                           , new ToughHunkOfBread()
  } ;
Faction = Factions.Undercity;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7443, InventoryTypes.OneHand, 2, 4, 2, 7, 0, 0, 0 ));
}
}
public class NatherilRaincaller : BaseCreature 
 { 
public  NatherilRaincaller() : base() 
 { 
Model = 4243;
AttackSpeed= 1315;
BoundingRadius = 1.00f ;
Name = "Natheril Raincaller" ;
Flags1 = 0x08480046 ;
Id = 2084 ; 
Guild = "General Goods";
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
Level = RandomLevel( 57 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 2306 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 11.00f ;
SetDamage ( 62, 80 );
NpcText00 = "Greetings $N, I am Natheril Raincaller." ;
BaseMana = 2855 ;
Sells = new Item[] { new AccurateSlugs()
                           , new JaggedArrow()
                           , new MelonJuice()
                           , new GleamingThrowingAxe()
                           , new WickedThrowingDagger()
                           , new RefreshingSpringWater()
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
Faction = Factions.Darnasus;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}
public class KregBilmn : BaseCreature 
 { 
public  KregBilmn() : base() 
 { 
Model = 3430;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Kreg Bilmn" ;
Flags1 = 0x08480046 ;
Id = 1691 ; 
Guild = "General Supplies";
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
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 424 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 10, 14 );
NpcText00 = "Greetings $N, I am Kreg Bilmn." ;
BaseMana = 0 ;
Sells = new Item[] { new RefreshingSpringWater()
                           , new RoughArrow()
                           , new LightShot()
                           , new BalancedThrowingDagger()
                           , new SmallThrowingKnife()
                           , new CrudeThrowingAxe()
                           , new WeightedThrowingAxe()
                           , new SimpleWood()
                           , new FlintAndTinder()
                           , new SmallBrownPouch()
                           , new BrownLeatherSatchel()
                           , new RedRibbonedWrappingPaper()
  } ;
Faction = Factions.IronForge;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 24596, InventoryTypes.OneHand, 2, 14, 1, 0, 0, 0, 0 ));
}
}
public class YanniStoutheart : BaseCreature 
 { 
public  YanniStoutheart() : base() 
 { 
Model = 1850;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Yanni Stoutheart" ;
Flags1 = 0x08480046 ;
Id = 1682 ; 
Guild = "General Supplies";
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
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 16, 21 );
NpcText00 = "Greetings $N, I am Yanni Stoutheart." ;
BaseMana = 0 ;
Sells = new Item[] { new IceColdMilk()
                           , new RefreshingSpringWater()
                           , new RoughArrow()
                           , new SharpArrow()
                           , new LightShot()
                           , new HeavyShot()
                           , new ThunderAle()
                           , new RhapsodyMalt()
                           , new BalancedThrowingDagger()
                           , new SmallThrowingKnife()
                           , new CrudeThrowingAxe()
                           , new WeightedThrowingAxe()
                           , new SimpleWood()
                           , new FlintAndTinder()
                           , new SmallBrownPouch()
                           , new BrownLeatherSatchel()
                           , new RedRibbonedWrappingPaper()
  } ;
Faction = Factions.IronForge;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 7483, InventoryTypes.OneHand, 2, 7, 1, 3, 0, 0, 0 ), new Item( 1684, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
}
}
public class QuartermasterHicks : BaseCreature 
 { 
public  QuartermasterHicks() : base() 
 { 
Model = 3336;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Quartermaster Hicks" ;
Flags1 = 0x08480046 ;
Id = 1645 ; 
Guild = "Master Weaponsmith";
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
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 424 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 10, 14 );
NpcText00 = "Greetings $N, I am Quartermaster Hicks." ;
BaseMana = 0 ;
Sells = new Item[] { new Broadsword()
                           , new Flamberge()
                           , new CrescentAxe()
                           , new Bullova()
                           , new Truncheon()
                           , new WarHammer()
                           , new MainGauche()
                           , new BattleStaff()
  } ;
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 7482, InventoryTypes.OneHand, 2, 7, 1, 3, 0, 0, 0 ),new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
}
}
public class ThurmanMullby : BaseCreature 
 { 
public  ThurmanMullby() : base() 
 { 
Model = 1434;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Thurman Mullby" ;
Flags1 = 0x08480046 ;
Id = 1285 ; 
Guild = "General Goods Vendor";
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
NpcText00 = "Greetings $N, I am Thurman Mullby." ;
BaseMana = 0 ;
Sells = new Item[] { new AccurateSlugs()
                           , new JaggedArrow()
                           , new IceColdMilk()
                           , new MelonJuice()
                           , new GleamingThrowingAxe()
                           , new WickedThrowingDagger()
                           , new RefreshingSpringWater()
                           , new MoonberryJuice()
                           , new SweetNectar()
                           , new RoughArrow()
                           , new SharpArrow()
                           , new LightShot()
                           , new HeavyShot()
                           , new BalancedThrowingDagger()
                           , new SmallThrowingKnife()
                           , new RazorArrow()
                           , new SolidShot()
                           , new KeenThrowingKnife()
                           , new HeavyThrowingDagger()
                           , new CrudeThrowingAxe()
                           , new WeightedThrowingAxe()
                           , new SharpThrowingAxe()
                           , new DeadlyThrowingAxe()
                           , new SimpleWood()
                           , new FlintAndTinder()
                           , new SmallBrownPouch()
                           , new HeavyBrownBag()
                           , new BrownLeatherSatchel()
                           , new ToughHunkOfBread()
                           , new RedRibbonedWrappingPaper()
                           , new BlueRibbonedWrappingPaper()
                           , new UnlitPoorTorch()
                           , new SoulShard()
  } ;
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7461, InventoryTypes.OneHand, 2, 4, 2, 7, 0, 0, 0 ));
}
}
public class EllyLangston : BaseCreature 
 { 
public  EllyLangston() : base() 
 { 
Model = 1521;
AttackSpeed= 2000;
BoundingRadius = 0.208000f ;
Name = "Elly Langston" ;
Flags1 = 0x08480046 ;
Id = 1328 ; 
Guild = "Barmaid";
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
Level = RandomLevel( 60 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 2426 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 65, 85 );
NpcText00 = "Greetings $N, I am Elly Langston." ;
BaseMana = 0 ;
Sells = new Item[] { new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
                           , new MoonberryJuice()
                           , new SweetNectar()
                           , new FlaskOfPort()
                           , new FlagonOfMead()
                           , new JugOfBourbon()
                           , new SkinOfDwarvenStout()
                           , new BottleOfPinotNoir()
                           , new MorningGloryDew()
  } ;
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
Equip( new Item( 7446, InventoryTypes.OneHand, 2, 14, 1, 7, 0, 0, 0 ));
}
}
public class Uthok : BaseCreature 
 { 
public  Uthok() : base() 
 { 
Model = 4388;
AttackSpeed= 2000;
BoundingRadius = 0.372000f ;
Name = "Uthok" ;
Flags1 = 0x08400046 ;
Id = 1149 ; 
Guild = "General Supplies";
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
NpcText00 = "Greetings $N, I am Uthok." ;
BaseMana = 0 ;
Sells = new Item[] { new AccurateSlugs()
                           , new JaggedArrow()
                           , new MelonJuice()
                           , new GleamingThrowingAxe()
                           , new WickedThrowingDagger()
                           , new RefreshingSpringWater()
                           , new RecipeSpicedChiliCrab()
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
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
}
}
public class SergeantDeVries : BaseCreature 
 { 
public  SergeantDeVries() : base() 
 { 
Model = 3338;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Sergeant De Vries" ;
Flags1 = 0x08480046 ;
Id = 955 ; 
Guild = "Morale Officer";
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
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 424 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 10, 14 );
NpcText00 = "Greetings $N, I am Sergeant De Vries." ;
BaseMana = 0 ;
Sells = new Item[] { new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
                           , new MoonberryJuice()
                           , new SweetNectar()
                           , new FlaskOfPort()
                           , new FlagonOfMead()
                           , new JugOfBourbon()
                           , new SkinOfDwarvenStout()
                           , new BottleOfPinotNoir()
                           , new MorningGloryDew()
  } ;
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 24595, InventoryTypes.OneHand, 2, 14, 1, 0, 0, 0, 0 ));
}
}
public class AdlinPridedrift : BaseCreature 
 { 
public  AdlinPridedrift() : base() 
 { 
Model = 3388;
AttackSpeed= 1500;
BoundingRadius = 0.347000f ;
Name = "Adlin Pridedrift" ;
Flags1 = 0x08080066 ;
Id = 829 ; 
Guild = "General Supplies";
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
Level = RandomLevel( 5 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 224 ;
NpcFlags = 06 ;
CombatReach = 1.5f ;
SetDamage ( 5, 6 );
NpcText00 = "Greetings $N, I am Adlin Pridedrift." ;
BaseMana = 0 ;
Sells = new Item[] { new RefreshingSpringWater()
                           , new RoughArrow()
                           , new LightShot()
                           , new SmallThrowingKnife()
                           , new CrudeThrowingAxe()
                           , new ToughHunkOfBread()
  } ;
Faction = Factions.IronForge;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 7443, InventoryTypes.OneHand, 2, 4, 2, 7, 0, 0, 0 ));
}
}
public class LindsayAshlock : BaseCreature 
 { 
public  LindsayAshlock() : base() 
 { 
Model = 3368;
AttackSpeed= 2000;
BoundingRadius = 0.208000f ;
Name = "Lindsay Ashlock" ;
Flags1 = 0x08480046 ;
Id = 791 ; 
Guild = "General Supplies";
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
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 824 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 21, 28 );
NpcText00 = "Greetings $N, I am Lindsay Ashlock." ;
BaseMana = 0 ;
Sells = new Item[] { new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
                           , new RoughArrow()
                           , new SharpArrow()
                           , new LightShot()
                           , new HeavyShot()
                           , new BalancedThrowingDagger()
                           , new KeenThrowingKnife()
                           , new WeightedThrowingAxe()
                           , new SharpThrowingAxe()
                           , new SimpleWood()
                           , new FlintAndTinder()
                           , new SmallBrownPouch()
                           , new BrownLeatherSatchel()
                           , new BlueRibbonedWrappingPaper()
                           , new UnlitPoorTorch()
  } ;
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7443, InventoryTypes.OneHand, 2, 4, 2, 7, 0, 0, 0 ));
}
}
public class CorporalBluth : BaseCreature 
 { 
public  CorporalBluth() : base() 
 { 
Model = 4398;
AttackSpeed= 1000;
BoundingRadius = 0.306000f ;
Name = "Corporal Bluth" ;
Flags1 = 0x08480046 ;
Id = 734 ; 
Guild = "Camp Trader";
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
BaseHitPoints = 1545 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.500000f ;
SetDamage ( 41, 53 );
NpcText00 = "Greetings $N, I am Corporal Bluth." ;
BaseMana = 0 ;
Sells = new Item[] { new AccurateSlugs()
                           , new JaggedArrow()
                           , new IceColdMilk()
                           , new MelonJuice()
                           , new RecipeRoastRaptor()
                           , new RecipeJungleStew()
                           , new GleamingThrowingAxe()
                           , new WickedThrowingDagger()
                           , new RefreshingSpringWater()
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
                           , new ShinyRedApple()
                           , new TelAbimBanana()
                           , new SnapvineWatermelon()
                           , new GoldenbarkApple()
                           , new MoonHarvestPumpkin()
                           , new MorningGloryDew()
                           , new DeepFriedPlantains()
  } ;
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
}
}
	public class QuartermasterLewis : BaseNPC 
	{ 
		public  QuartermasterLewis() : base() 
		{ 
			Model = 3342;
			AttackSpeed= 1500;
			BoundingRadius = 0.306000f ;
			Name = "Quartermaster Lewis" ;
			Flags1 = 0x08480046 ;
			Id = 491 ; 
			Guild = "Quartermaster";
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
			NpcType = (int)NpcTypes.Humanoid;
			BaseHitPoints = 600 ;
			NpcFlags = (int)NpcActions.Vendor ;
			CombatReach = 1.5f ;
			SetDamage ( 21, 28 );
			NpcText00 = "Greetings $N, I am Quartermaster Lewis." ;
			BaseMana = 0 ;
			Sells = new Item[] { new IceColdMilk()
								   , new RefreshingSpringWater()
								   , new RoughArrow()
								   , new SharpArrow()
								   , new LightShot()
								   , new HeavyShot()
								   , new BalancedThrowingDagger()
								   , new SmallThrowingKnife()
								   , new CrudeThrowingAxe()
								   , new WeightedThrowingAxe()
								   , new SimpleWood()
								   , new FlintAndTinder()
								   , new SmallBrownPouch()
								   , new BrownLeatherSatchel()
								   , new RedRibbonedWrappingPaper()
							   } ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7426, InventoryTypes.OneHand, 2, 0, 1, 3, 0, 0, 0 ));
		}
	}
public class BrogHamfist : BaseCreature 
 { 
public  BrogHamfist() : base() 
 { 
Model = 1292;
AttackSpeed= 1500;
BoundingRadius = 0.306000f ;
Name = "Brog Hamfist" ;
Flags1 = 0x08480046 ;
Id = 151 ; 
Guild = "General Supplies";
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
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 424 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 10, 14 );
NpcText00 = "Greetings $N, I am Brog Hamfist." ;
BaseMana = 0 ;
Sells = new Item[] { new RefreshingSpringWater()
                           , new RoughArrow()
                           , new LightShot()
                           , new BalancedThrowingDagger()
                           , new SmallThrowingKnife()
                           , new CrudeThrowingAxe()
                           , new WeightedThrowingAxe()
                           , new SimpleWood()
                           , new FlintAndTinder()
                           , new SmallBrownPouch()
                           , new BrownLeatherSatchel()
                           , new RedRibbonedWrappingPaper()
  } ;
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 7443, InventoryTypes.OneHand, 2, 4, 2, 7, 0, 0, 0 ));
}
}

public class BrotherDanil : BaseCreature 
 { 
public  BrotherDanil() : base() 
 { 
Model = 3277;
AttackSpeed= 1500;
BoundingRadius = 0.306000f ;
Name = "Brother Danil" ;
Flags1 = 0x08080066 ;
Id = 152 ; 
Guild = "General Supplies";
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
Level = RandomLevel( 5 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 424 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 10, 14 );
NpcText00 = "Greetings $N, I am Brog Hamfist." ;
BaseMana = 0 ;
Sells = new Item[] { new CrudeThrowingAxe()
                           , new LightShot()
                           , new RefreshingSpringWater()
                           , new RoughArrow()
                           , new SmallThrowingKnife()
                           , new ToughHunkOfBread()
  } ;
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 7443, InventoryTypes.MainGauche, 2, 4, 2, 7, 0, 0, 0 ));
}
}
	
}