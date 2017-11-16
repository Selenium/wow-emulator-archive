//originally Scripted By DiScS Converter
//Edited by *place name here*
using System;
using Server.Items;

////////////////////
namespace Server.Creatures
{
public class ThelgrumStonehammer : BaseCreature 
 { 
public  ThelgrumStonehammer() : base() 
 { 
Model = 5020;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Thelgrum Stonehammer" ;
Flags1 = 0x08480046 ;
Id = 6298 ; 
Guild = "Mining Supplier";
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
NpcText00 = "Greetings $N, I am Thelgrum Stonehammer." ;
BaseMana = 0 ;
Sells = new Item[] { new WeakFlux()
                           , new MiningPick()
                           , new StrongFlux()
                           , new Coal()
  } ;
Faction = Factions.Darnasus;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7493, InventoryTypes.OneHand, 0, 1, 13, 3, 0, 0, 0 ));
}
}
public class BrookeStonebraid : BaseCreature 
 { 
public  BrookeStonebraid() : base() 
 { 
Model = 3313;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Brooke Stonebraid" ;
Flags1 = 0x08480046 ;
Id = 5514 ; 
Guild = "Mining Supplier";
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
NpcText00 = "Greetings $N, I am Brooke Stonebraid." ;
BaseMana = 0 ;
Sells = new Item[] { new WeakFlux()
                           , new MiningPick()
                           , new StrongFlux()
                           , new Coal()
  } ;
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7493, InventoryTypes.OneHand, 0, 1, 13, 3, 0, 0, 0 ));
}
}
public class SarahKillian : BaseCreature 
 { 
public  SarahKillian() : base() 
 { 
Model = 2672;
AttackSpeed= 2000;
BoundingRadius = 0.383000f ;
Name = "Sarah Killian" ;
Flags1 = 0x018480046 ;
Id = 4599 ; 
Guild = "Mining Supplier";
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
NpcText00 = "Greetings $N, I am Sarah Killian." ;
BaseMana = 0 ;
Sells = new Item[] { new WeakFlux()
                           , new MiningPick()
                           , new StrongFlux()
                           , new Coal()
  } ;
Faction = Factions.Undercity;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7439, InventoryTypes.OneHand, 4, 2, 13, 3, 0, 0, 0 ));
}
}
public class GolnirBouldertoe : BaseCreature 
 { 
public  GolnirBouldertoe() : base() 
 { 
Model = 3093;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Golnir Bouldertoe" ;
Flags1 = 0x08480046 ;
Id = 4256 ; 
Guild = "Mining Supplier";
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
NpcText00 = "Greetings $N, I am Golnir Bouldertoe." ;
BaseMana = 0 ;
Sells = new Item[] { new WeakFlux()
                           , new MiningPick()
                           , new StrongFlux()
                           , new Coal()
  } ;
Faction = Factions.IronForge;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7493, InventoryTypes.OneHand, 0, 1, 13, 3, 0, 0, 0 ));
}
}
public class Gorina : BaseCreature 
 { 
public  Gorina() : base() 
 { 
Model = 1380;
AttackSpeed= 1739;
BoundingRadius = 0.236000f ;
Name = "Gorina" ;
Flags1 = 0x08480046 ;
Id = 3358 ; 
Guild = "Mining Supplier";
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
NpcText00 = "Greetings $N, I am Gorina." ;
BaseMana = 0 ;
Sells = new Item[] { new WeakFlux()
                           , new MiningPick()
                           , new StrongFlux()
                           , new Coal()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7461, InventoryTypes.OneHand, 14, 1, 13, 7, 0, 0, 0 ));
}
}
public class KarmIronquill : BaseCreature 
 { 
public  KarmIronquill() : base() 
 { 
Model = 8089;
AttackSpeed= 1500;
BoundingRadius = 0.347000f ;
Name = "Karm Ironquill" ;
Flags1 = 0x08480046 ;
Id = 372 ; 
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
NpcType = 7 ;
BaseHitPoints = 664 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 17, 22 );
NpcText00 = "Greetings $N, I am Karm Ironquill." ;
BaseMana = 0 ;
Sells = new Item[] { new WeakFlux()
                           , new MiningPick()
                           , new StrongFlux()
                           , new Coal()
  } ;
Faction = Factions.Stormwind;
Guild = "Mining Supplies" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 10821, InventoryTypes.OneHand, 14, 1, 13, 0, 0, 0, 0 ));
}
}

public class KarenTaylor : BaseCreature 
 { 
public  KarenTaylor() : base() 
 { 
Model = 3363;
AttackSpeed= 2000;
BoundingRadius = 0.208000f ;
Name = "Karen Taylor" ;
Flags1 = 0x08480046 ;
Id = 790 ; 
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
NpcType = 7 ;
BaseHitPoints = 904 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 24, 31 );
NpcText00 = "Greetings $N, I am Karen Taylor." ;
BaseMana = 0 ;
Sells = new Item[] { new WeakFlux()
                           , new MiningPick()
                           , new StrongFlux()
                           , new Coal()
                           , new BlacksmithHammer()
  } ;
Faction = Factions.Stormwind;
Guild = "Mining Supplies" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 7439, InventoryTypes.OneHand, 4, 2, 13, 3, 0, 0, 0 ));}
}

public class HerbleBaubbletump : BaseCreature 
 { 
public  HerbleBaubbletump() : base() 
 { 
Model = 4286;
AttackSpeed= 1000;
BoundingRadius = 0.351900f ;
Name = "Herble Baubbletump" ;
Flags1 = 0x08480046 ;
Id = 3133 ; 
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
CombatReach = 1.725f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Herble Baubbletump." ;
BaseMana = 0 ;
Sells = new Item[] { new EngineersInk()
                           , new BlankParchment()
                           , new WeakFlux()
                           , new MiningPick()
                           , new StrongFlux()
                           , new Coal()
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
Faction = Factions.GnomereganExiles;
Guild = "Mining Supplies" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 5569, InventoryTypes.OneHand, 14, 1, 21, 7, 0, 0, 0 ));
}
}

public class LunnixSprocketslip : BaseCreature 
 { 
public  LunnixSprocketslip() : base() 
 { 
Model = 10744;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Lunnix Sprocketslip" ;
Flags1 = 0x08080006 ;
Id = 11186 ; 
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
Level = RandomLevel( 54 );
NpcType = 7 ;
BaseHitPoints = 2186 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 59, 76 );
NpcText00 = "Greetings $N, I am Lunnix Sprocketslip." ;
BaseMana = 0 ;
Sells = new Item[] { new WeakFlux()
                           , new MiningPick()
                           , new StrongFlux()
                           , new Coal()
  } ;
Faction = Factions.Everlook;
Guild = "Mining Supplies" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
Equip( new Item( 7493, InventoryTypes.OneHand, 0, 1, 13, 3, 0, 0, 0 ));
}
}
}
