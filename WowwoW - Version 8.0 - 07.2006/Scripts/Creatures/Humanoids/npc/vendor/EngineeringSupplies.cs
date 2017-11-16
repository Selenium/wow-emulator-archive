//originally Scripted By DiScS Converter
//Edited by *place name here*
using System;
using Server.Items;

////////////////////
namespace Server.Creatures
{
public class JubieGadgetspring : BaseCreature 
 { 
public  JubieGadgetspring() : base() 
 { 
Model = 0;
AttackSpeed= 0;
BoundingRadius = 0.51f ;
Name = "Jubie Gadgetspring" ;
Flags1 = 0x00000000 ;
Id = 8678 ; 
Guild = "Engineering Supplier";
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
BaseHitPoints = 0 ;
NpcFlags = 0 ;
CombatReach = 0f ;
SetDamage ( 32, 42 );
NpcText00 = "Hello" ;
BaseMana = 0 ;
Sells = new Item[] {new BlacksmithHammer()
,new BlankParchment()
,new BronzeFramework() 
,new BronzeTube()
,new CoarseBlastingPowder() 
,new CopperModulator()
,new CopperTube() 
,new EngineersInk()
,new Gyrochronatom()
,new HeavyStock()
,new MiningPick()
,new RoughBlastingPowder()
,new SchematicDeepdiveHelmet()
,new SilverContact()
,new StrongFlux()
,new WeakFlux()
,new WoodenStock()
} ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
}
}
public class BillibubCogspinner : BaseCreature 
 { 
public  BillibubCogspinner() : base() 
 { 
Model = 3315;
AttackSpeed= 2000;
BoundingRadius = 0.351900f ;
Name = "Billibub Cogspinner" ;
Flags1 = 0x08480046 ;
Id = 5519 ; 
Guild = "Engineering Supplier";
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
NpcText00 = "Greetings $N, I am Billibub Cogspinner." ;
BaseMana = 0 ;
Sells = new Item[] { new BlankParchment()
                           , new BronzeFramework()
                           , new BronzeTube()
                           , new CoarseBlastingPowder()
                           , new CopperModulator()
                           , new CopperTube()
                           , new EngineersInk()
                           , new Gyrochronatom()
                           , new HeavyStock()
                           , new MiningPick()
                           , new RoughBlastingPowder()
                           , new SilverContact()
                           , new StrongFlux()
                           , new WeakFlux()
                           , new WoodenStock()
  } ; 
Faction = Factions.GnomereganExiles;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7494, InventoryTypes.MainGauche, 2, 4, 2, 7, 0, 0, 0 ));
}
}

public class NealAllen : BaseCreature 
 { 
public  NealAllen() : base() 
 { 
Model = 3459;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Neal Allen" ;
Flags1 = 0x08480046 ;
Id = 1448 ; 
Size = 1f;
Speed = 5f ;
WalkSpeed = 5f ;
NpcType = 7 ;
RunSpeed = 8f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 20 );
NpcFlags = (int)NpcActions.Vendor;
BaseHitPoints = 824 ;
CombatReach = 1.5f ;
SetDamage ( 21, 28 );
NpcText00 = "Greetings $N, I am Neal Allen." ;
BaseMana = 0 ;
Sells = new Item[] { new HeavyQuiver()
                           , new BattleAxe()
                           , new BeardedAxe()
                           , new Claymore()
                           , new Cleaver()
                           , new Cutlass()
                           , new DacianFalx()
                           , new DoubleAxe()
                           , new Espadon()
                           , new FineLightCrossbow()
                           , new Flail()
                           , new GiantMace()
                           , new GnarledStaff()
                           , new Hammer()
                           , new Hatchet()
                           , new HeavyCrossbow()
                           , new Jambiya()
                           , new Kris()
                           , new LightCrossbow()
                           , new LightQuiver()
                           , new LongStaff()
                           , new Longsword()
                           , new Mace()
                           , new Maul()
                           , new MediumQuiver()
                           , new Poniard()
                           , new QuarterStaff()
                           , new RazorArrow()
                           , new RockHammer()
                           , new RoughArrow()
                           , new Scimitar()
                           , new SharpArrow()
                           , new Tabar()
  } ;

Faction = Factions.Stormwind;
Guild = "Engineering Supplies";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7494, InventoryTypes.MainGauche, 2, 4, 2, 7, 0, 0, 0 ));
}
}

public class LoslorRudge : BaseCreature 
 { 
public  LoslorRudge() : base() 
 { 
Model = 3392;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Loslor Rudge" ;
Flags1 = 0x08480046 ;
Id = 1694 ; 
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
NpcFlags = (int)NpcActions.Vendor;
BaseHitPoints = 424 ;
NpcType = 7 ;
CombatReach = 1.5f ;
SetDamage ( 10, 14 );
NpcText00 = "Greetings $N, I am Loslor Rudge." ;
BaseMana = 0 ;
Sells = new Item[] { new BlankParchment()
                           , new BronzeFramework()
                           , new BronzeTube()
                           , new CoarseBlastingPowder()
                           , new CopperModulator()
                           , new CopperTube()
                           , new EngineersInk()
                           , new Gyrochronatom()
                           , new HeavyStock()
                           , new MiningPick()
                           , new RoughBlastingPowder()
                           , new SilverContact()
                           , new StrongFlux()
                           , new WeakFlux()
                           , new WoodenStock()
  } ;

Faction = Factions.IronForge;
Guild = "Engineering Supplies" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 7483, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ), new Item( 1684, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
}
}

public class NamdoBizzfizzle : BaseCreature 
 { 
public  NamdoBizzfizzle() : base() 
 { 
Model = 4953;
AttackSpeed= 2000;
BoundingRadius = 0.351900f ;
Name = "Namdo Bizzfizzle" ;
Flags1 = 0x08480046 ;
Id = 2683 ; 
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
NpcFlags = (int)NpcActions.Vendor;
BaseHitPoints = 984 ;
NpcType = 7 ;
CombatReach = 1.725f ;
SetDamage ( 26, 33 );
NpcText00 = "Greetings $N, I am Namdo Bizzfizzle." ;
BaseMana = 0 ;
Sells = new Item[] { new BlankParchment()
                           , new BronzeFramework()
                           , new BronzeTube()
                           , new CoarseBlastingPowder()
                           , new CopperModulator()
                           , new CopperTube()
                           , new EngineersInk()
                           , new Gyrochronatom()
                           , new HeavyStock()
                           , new MiningPick()
                           , new RoughBlastingPowder()
                           , new SchematicMinorRecombobulator()
                           , new SilverContact()
                           , new StrongFlux()
                           , new WeakFlux()
                           , new WoodenStock()
  } ;

Faction = Factions.GnomereganExiles;
Guild = "Engineering Supplies" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7494, InventoryTypes.MainGauche, 2, 4, 2, 7, 0, 0, 0 ));
}
}

public class MazkSnipeshot : BaseCreature 
 { 
public  MazkSnipeshot() : base() 
 { 
Model = 7179;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Mazk Snipeshot" ;
Flags1 = 0x08080046 ;
Id = 2685 ; 
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
NpcFlags = (int)NpcActions.Vendor;
BaseHitPoints = 1464 ;
NpcType = 7 ;
CombatReach = 1.5f ;
SetDamage ( 39, 50 );
NpcText00 = "Greetings $N, I am Mazk Snipeshot." ;
BaseMana = 0 ;
Sells = new Item[] { new BlankParchment()
                           , new BronzeFramework()
                           , new BronzeTube()
                           , new CoarseBlastingPowder()
                           , new CopperModulator()
                           , new CopperTube()
                           , new EngineersInk()
                           , new Gyrochronatom()
                           , new HeavyStock()
                           , new MiningPick()
                           , new RoughBlastingPowder()
                           , new SchematicAccurateScope()
                           , new SilverContact()
                           , new StrongFlux()
                           , new WeakFlux()
                           , new WoodenStock()
  } ;
Faction = Factions.BootyBay;
Guild = "Engineering Supplies" ; 
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}

public class GnazBlunderflame : BaseCreature 
 { 
public  GnazBlunderflame() : base() 
 { 
Model = 4493;
AttackSpeed= 2000;
BoundingRadius = 0.351900f ;
Name = "Gnaz Blunderflame" ;
Flags1 = 0x080066 ;
Id = 2687 ; 
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
Level = RandomLevel( 42 );
NpcFlags = (int)NpcActions.Vendor;
BaseHitPoints = 0 ;
NpcType = 7 ;
CombatReach = 1.725f ;
SetDamage ( 41, 61 );
NpcText00 = "Hello" ;
BaseMana = 0 ;
Sells = new Item[] { new EngineersInk()
                           , new BlankParchment()
                           , new SchematicMechanicalDragonling()
                           , new WeakFlux()
                           , new MiningPick()
                           , new StrongFlux()
                           , new RoughBlastingPowder()
                           , new CopperTube()
                           , new CopperModulator()
                           , new CoarseBlastingPowder()
                           , new BronzeTube()
                           , new BronzeFramework()
                           , new Gyrochronatom()
                           , new WoodenStock()
                           , new HeavyStock()
                           , new SilverContact()
  } ;
Faction = Factions.Friend;
Guild = "Engineering Supplies" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 5569, InventoryTypes.OneHand, 2, 14, 1, 7, 0, 0, 0 ));
}
}

public class RuppoZipcoil : BaseCreature 
 { 
public  RuppoZipcoil() : base() 
 { 
Model = 6545;
AttackSpeed= 2000;
BoundingRadius = 0.351900f ;
Name = "Ruppo Zipcoil" ;
Flags1 = 0x066 ;
Id = 2688 ; 
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
NpcFlags = (int)NpcActions.Vendor;
BaseHitPoints = 2105 ;
NpcType = 7 ;
CombatReach = 1.725f ;
SetDamage ( 57, 73 );
NpcText00 = "Greetings $N, I am Ruppo Zipcoil." ;
BaseMana = 0 ;
Sells = new Item[] { new SchematicMithrilMechanicalDragonling()
                           , new EngineersInk()
                           , new BlankParchment()
                           , new WeakFlux()
                           , new MiningPick()
                           , new StrongFlux()
                           , new RoughBlastingPowder()
                           , new CopperTube()
                           , new CopperModulator()
                           , new CoarseBlastingPowder()
                           , new BronzeTube()
                           , new BronzeFramework()
                           , new Gyrochronatom()
                           , new WoodenStock()
                           , new HeavyStock()
                           , new SilverContact()
  } ;
Faction = Factions.Friend;
Guild = "Engineering Supplies" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
}
}


public class Sovik : BaseCreature 
 { 
public  Sovik() : base() 
 { 
Model = 7136;
AttackSpeed= 1739;
BoundingRadius = 0.306000f ;
Name = "Sovik" ;
Flags1 = 0x08080046 ;
Id = 3413 ; 
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
NpcFlags = (int)NpcActions.Vendor;
BaseHitPoints = 1224 ;
NpcType = 7 ;
CombatReach = 1.5f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Sovik." ;
BaseMana = 0 ;
Sells = new Item[] { new EngineersInk()
                           , new BlankParchment()
                           , new SchematicThoriumGrenade()
                           , new SchematicThoriumWidget()
                           , new SchematicRedFirework()
                           , new WeakFlux()
                           , new MiningPick()
                           , new StrongFlux()
                           , new RoughBlastingPowder()
                           , new CopperTube()
                           , new CopperModulator()
                           , new CoarseBlastingPowder()
                           , new BronzeTube()
                           , new BronzeFramework()
                           , new Gyrochronatom()
                           , new WoodenStock()
                           , new HeavyStock()
                           , new SilverContact()
  } ;
Faction = Factions.Ogrimmar;
Guild = "Engineering Supplies" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7494, InventoryTypes.MainGauche, 2, 4, 2, 7, 0, 0, 0 ));
}
}
public class ElizabethVanTalen : BaseCreature 
 { 
public  ElizabethVanTalen() : base() 
 { 
Model = 2661;
AttackSpeed= 2000;
BoundingRadius = 0.383000f ;
Name = "Elizabeth Van Talen" ;
Flags1 = 0x018480046 ;
Id = 4587 ; 
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
NpcFlags = (int)NpcActions.Vendor;
BaseHitPoints = 1224 ;
NpcType = 7 ;
CombatReach = 1.5f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Elizabeth Van Talen." ;
BaseMana = 0 ;
Sells = new Item[] { new EngineersInk()
                           , new BlankParchment()
                           , new WeakFlux()
                           , new MiningPick()
                           , new StrongFlux()
                           , new RoughBlastingPowder()
                           , new CopperTube()
                           , new CopperModulator()
                           , new CoarseBlastingPowder()
                           , new BronzeTube()
                           , new BronzeFramework()
                           , new Gyrochronatom()
                           , new WoodenStock()
                           , new HeavyStock()
                           , new SilverContact()
  } ;
Faction = Factions.Undercity;
Guild = "Engineering Supplies" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7494, InventoryTypes.MainGauche, 2, 4, 2, 7, 0, 0, 0 ));
}
}

public class GearcutterCogspinner : BaseCreature 
 { 
public  GearcutterCogspinner() : base() 
 { 
Model = 3118;
AttackSpeed= 2000;
BoundingRadius = 0.351900f ;
Name = "Gearcutter Cogspinner" ;
Flags1 = 0x08480046 ;
Id = 5175 ; 
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
NpcFlags = (int)NpcActions.Vendor;
BaseHitPoints = 1224 ;
NpcType = 7 ;
CombatReach = 1.725f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Gearcutter Cogspinner." ;
BaseMana = 0 ;
Sells = new Item[] { new GnomereganAmulet()
                           , new EngineersInk()
                           , new BlankParchment()
                           , new MossAgate()
                           , new SchematicThoriumGrenade()
                           , new SchematicThoriumWidget()
                           , new SchematicBlueFirework()
                           , new CopperOre()
                           , new TinOre()
                           , new SilverOre()
                           , new RoughStone()
                           , new CoarseStone()
                           , new HeavyStone()
                           , new WeakFlux()
                           , new MiningPick()
                           , new StrongFlux()
                           , new RoughBlastingPowder()
                           , new CopperTube()
                           , new CopperModulator()
                           , new CoarseBlastingPowder()
                           , new BronzeTube()
                           , new BronzeFramework()
                           , new Gyrochronatom()
                           , new WoodenStock()
                           , new HeavyStock()
                           , new SilverContact()
                           , new SmoothPebble()
                           , new SchematicGnomishUniversalRemote()
                           , new Malachite()
  } ;
Faction = Factions.GnomereganExiles;
Guild = "Engineering Supplies" ; 
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7494, InventoryTypes.MainGauche, 2, 4, 2, 7, 0, 0, 0 ), new Item( 6532, InventoryTypes.HeldInHand, 4, 0, 2, 0, 0, 0, 0 ), new Item( 6593, InventoryTypes.RangeRight, 2, 3, 1, 0, 0, 0, 0 ));
}
}

public class RizzLoosebolt : BaseCreature 
 { 
public  RizzLoosebolt() : base() 
 { 
Model = 3733;
AttackSpeed= 1680;
BoundingRadius = 1.00f ;
Name = "Rizz Loosebolt" ;
Flags1 = 0x066 ;
Id = 2684 ; 
Guild = "Superior Engineer";
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
CombatReach = 11.00f ;
SetDamage ( 33, 43 );
NpcText00 = "Greetings $N, I am Rizz Loosebolt." ;
BaseMana = 1553 ;
Sells = new Item[] { new EngineersInk()
                           , new BlankParchment()
                           , new SchematicIceDeflector()
                           , new WeakFlux()
                           , new MiningPick()
                           , new StrongFlux()
                           , new RoughBlastingPowder()
                           , new CopperTube()
                           , new CopperModulator()
                           , new CoarseBlastingPowder()
                           , new BronzeTube()
                           , new BronzeFramework()
                           , new Gyrochronatom()
                           , new WoodenStock()
                           , new HeavyStock()
                           , new SilverContact()
  } ;
Faction = Factions.Friend;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}
public class JinkyTwizzlefixxit : BaseCreature 
 { 
public  JinkyTwizzlefixxit() : base() 
 { 
Model = 5425;
AttackSpeed= 2000;
BoundingRadius = 0.351900f ;
Name = "Jinky Twizzlefixxit" ;
Flags1 = 0x080066 ;
Id = 6730 ; 
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
NpcFlags = (int)NpcActions.Vendor;
BaseHitPoints = 1224 ;
NpcType = 7 ;
CombatReach = 1.725f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Jinky Twizzlefixxit." ;
BaseMana = 0 ;
Sells = new Item[] { new EngineersInk()
                           , new BlankParchment()
                           , new SchematicLovinglyCraftedBoomstick()
                           , new WeakFlux()
                           , new MiningPick()
                           , new StrongFlux()
                           , new RoughBlastingPowder()
                           , new CopperTube()
                           , new CopperModulator()
                           , new CoarseBlastingPowder()
                           , new BronzeTube()
                           , new BronzeFramework()
                           , new Gyrochronatom()
                           , new WoodenStock()
                           , new HeavyStock()
                           , new SilverContact()
                           , new SchematicGnomishUniversalRemote()
  } ;
Faction = Factions.Friend;
Guild = "Engineering Supplies" ; 
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7494, InventoryTypes.MainGauche, 2, 4, 2, 7, 0, 0, 0 ));
}
}
public class KnazBlunderflame : BaseCreature 
 { 
public  KnazBlunderflame() : base() 
 { 
Model = 7952;
AttackSpeed= 2000;
BoundingRadius = 0.351900f ;
Name = "Knaz Blunderflame" ;
Flags1 = 0x080066 ;
Id = 8679 ; 
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
Level = RandomLevel( 42 );
NpcFlags = (int)NpcActions.Vendor;
BaseHitPoints = 0 ;
NpcType = 7 ;
CombatReach = 1.725f ;
SetDamage ( 55, 65 );
NpcText00 = "Hello" ;
BaseMana = 0 ;
Sells = new Item[] { new SchematicDeadlyScope()
                           , new EngineersInk()
                           , new BlankParchment()
                           , new WeakFlux()
                           , new MiningPick()
                           , new StrongFlux()
                           , new RoughBlastingPowder()
                           , new CopperTube()
                           , new CopperModulator()
                           , new CoarseBlastingPowder()
                           , new BronzeTube()
                           , new BronzeFramework()
                           , new Gyrochronatom()
                           , new WoodenStock()
                           , new HeavyStock()
                           , new SilverContact()
  } ;
Faction = Factions.Friend;
Guild = "Engineering Supplies" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 5569, InventoryTypes.OneHand, 2, 14, 1, 7, 0, 0, 0 ));
}
}

public class TinkSprocketwhistle : BaseCreature 
 { 
public  TinkSprocketwhistle() : base() 
 { 
Model = 9027;
AttackSpeed= 2000;
BoundingRadius = 0.351900f ;
Name = "Tink Sprocketwhistle" ;
Flags1 = 0x08480046 ;
Id = 9676 ; 
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
NpcFlags = (int)NpcActions.Vendor;
BaseHitPoints = 984 ;
NpcType = 7 ;
CombatReach = 1.725f ;
SetDamage ( 26, 33 );
NpcText00 = "Greetings $N, I am Tink Sprocketwhistle." ;
BaseMana = 0 ;
Sells = new Item[] { new GnomereganAmulet()
                           , new EngineersInk()
                           , new BlankParchment()
                           , new MossAgate()
                           , new CopperOre()
                           , new TinOre()
                           , new SilverOre()
                           , new RoughStone()
                           , new CoarseStone()
                           , new HeavyStone()
                           , new WeakFlux()
                           , new MiningPick()
                           , new StrongFlux()
                           , new RoughBlastingPowder()
                           , new CopperTube()
                           , new CopperModulator()
                           , new CoarseBlastingPowder()
                           , new BronzeTube()
                           , new BronzeFramework()
                           , new Gyrochronatom()
                           , new WoodenStock()
                           , new HeavyStock()
                           , new SilverContact()
                           , new SmoothPebble()
                           , new Malachite()
  } ;
Faction = Factions.GnomereganExiles;
Guild = "Engineering Supplies" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 5569, InventoryTypes.OneHand, 2, 14, 1, 7, 0, 0, 0 ));
}
}

public class XizzerFizzbolt : BaseCreature 
 { 
public  XizzerFizzbolt() : base() 
 { 
Model = 10742;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Xizzer Fizzbolt" ;
Flags1 = 0x08080006 ;
Id = 11185 ; 
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
NpcFlags = (int)NpcActions.Vendor;
BaseHitPoints = 2306 ;
NpcType = 7 ;
CombatReach = 1.5f ;
SetDamage ( 62, 80 );
NpcText00 = "Greetings $N, I am Xizzer Fizzbolt." ;
BaseMana = 0 ;
Sells = new Item[] { new EngineersInk()
                           , new BlankParchment()
                           , new SchematicMasterworkTargetDummy()
                           , new SchematicThoriumTube()
                           , new SchematicDelicateArcaniteConverter()
                           , new SchematicGyrofreezeIceReflector()
                           , new SchematicGoblinJumperCablesXL()
                           , new WeakFlux()
                           , new MiningPick()
                           , new StrongFlux()
                           , new RoughBlastingPowder()
                           , new CopperTube()
                           , new CopperModulator()
                           , new CoarseBlastingPowder()
                           , new BronzeTube()
                           , new BronzeFramework()
                           , new Gyrochronatom()
                           , new WoodenStock()
                           , new HeavyStock()
                           , new SilverContact()
  } ;
Faction = Factions.Everlook;
Guild = "Engineering Supplies" ; 
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
Equip( new Item( 7494, InventoryTypes.MainGauche, 2, 4, 2, 7, 0, 0, 0 ));
}
}

}