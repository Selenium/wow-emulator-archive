//originally Scripted By DiScS Converter
//Edited by *place name here*
using System;
using Server.Items;

////////////////////
namespace Server.Creatures
{
public class Tand : BaseCreature 
 { 
public  Tand() : base() 
 { 
Model = 2099;
AttackSpeed= 2000;
BoundingRadius = 0.974700f ;
Name = "Tand" ;
Flags1 = 0x08480046 ;
Id = 3016 ; 
Guild = "Basket Weaver";
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
NpcText00 = "Greetings $N, I am Tand." ;
BaseMana = 0 ;
Sells = new Item[] { new SmallBrownPouch()
                           , new HeavyBrownBag()
                           , new BrownLeatherSatchel()
  } ;
Faction = Factions.ThunderBluff;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 23172, InventoryTypes.OneHand, 14, 1, 13, 0, 0, 0, 0 ), new Item( 23172, InventoryTypes.HeldInHand, 0, 1, 23, 0, 0, 0, 0 ));
}
}
public class EdwinaMonzor : BaseCreature 
 { 
public  EdwinaMonzor() : base() 
 { 
Model = 3466;
AttackSpeed= 1500;
BoundingRadius = 0.208000f ;
Name = "Edwina Monzor" ;
Flags1 = 0x08480046 ;
Id = 1462 ; 
Guild = "Fletcher";
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
NpcText00 = "Greetings $N, I am Edwina Monzor." ;
BaseMana = 0 ;
Sells = new Item[] { new MediumQuiver()
                           , new RoughArrow()
                           , new SharpArrow()
                           , new RazorArrow()
                           , new CrownOfThePenitent()
                           , new FireTar()
                           , new ExplosiveShell()
                           , new SmallQuiver()
  } ;
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}
public class KimberlyHiett : BaseCreature 
 { 
public  KimberlyHiett() : base() 
 { 
Model = 3369;
AttackSpeed= 2000;
BoundingRadius = 0.208000f ;
Name = "Kimberly Hiett" ;
Flags1 = 0x08480046 ;
Id = 789 ; 
Guild = "Fletcher";
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
NpcText00 = "Greetings $N, I am Kimberly Hiett." ;
BaseMana = 0 ;
Sells = new Item[] { new MediumQuiver()
                           , new RoughArrow()
                           , new SharpArrow()
                           , new RazorArrow()
                           , new CrownOfThePenitent()
                           , new FireTar()
                           , new SmallQuiver()
  } ;
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}
public class SkolminGoldfury : BaseCreature 
 { 
public  SkolminGoldfury() : base() 
 { 
Model = 3077;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Skolmin Goldfury" ;
Flags1 = 0x08480046 ;
Id = 5122 ; 
Guild = "Bow Merchant";
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
NpcText00 = "Greetings $N, I am Skolmin Goldfury." ;
BaseMana = 0 ;
Sells = new Item[] { new JaggedArrow()
                           , new FineShortbow()
                           , new SturdyRecurve()
                           , new MassiveLongbow()
                           , new MediumQuiver()
                           , new RoughArrow()
                           , new SharpArrow()
                           , new ReinforcedBow()
                           , new HeavyRecurveBow()
                           , new RazorArrow()
                           , new SmallQuiver()
  } ;
Faction = Factions.IronForge;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 5569, InventoryTypes.OneHand, 14, 1, 21, 7, 0, 0, 0 ), new Item( 6235, InventoryTypes.Ranged, 2, 2, 15, 0, 0, 0, 0 ));
}
}
public class AbigailSawyer : BaseCreature 
 { 
public  AbigailSawyer() : base() 
 { 
Model = 2656;
AttackSpeed= 2000;
BoundingRadius = 0.383000f ;
Name = "Abigail Sawyer" ;
Flags1 = 0x018480046 ;
Id = 4604 ; 
Guild = "Bow Merchant";
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
BaseHitPoints = 1384 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 37, 48 );
NpcText00 = "Greetings $N, I am Abigail Sawyer." ;
BaseMana = 0 ;
Sells = new Item[] { new JaggedArrow()
                           , new FineShortbow()
                           , new SturdyRecurve()
                           , new MassiveLongbow()
                           , new MediumQuiver()
                           , new RoughArrow()
                           , new SharpArrow()
                           , new ReinforcedBow()
                           , new HeavyRecurveBow()
                           , new RazorArrow()
                           , new SmallQuiver()
  } ;
Faction = Factions.Undercity;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 6232, InventoryTypes.Ranged, 2, 2, 15, 0, 0, 0, 0 ));
}
}
public class Landria : BaseCreature 
 { 
public  Landria() : base() 
 { 
Model = 2222;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Landria" ;
Flags1 = 0x08480046 ;
Id = 4173 ; 
Guild = "Bow Merchant";
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
NpcText00 = "Greetings $N, I am Landria." ;
BaseMana = 0 ;
Sells = new Item[] { new JaggedArrow()
                           , new FineShortbow()
                           , new SturdyRecurve()
                           , new SylvanShortbow()
                           , new MediumQuiver()
                           , new RoughArrow()
                           , new SharpArrow()
                           , new ReinforcedBow()
                           , new HeavyRecurveBow()
                           , new RazorArrow()
                           , new SmallQuiver()
  } ;
Faction = Factions.Darnasus;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 6235, InventoryTypes.Ranged, 2, 2, 15, 0, 0, 0, 0 ));
}
}
public class Jinsora : BaseCreature 
 { 
public  Jinsora() : base() 
 { 
Model = 4359;
AttackSpeed= 1739;
BoundingRadius = 0.306000f ;
Name = "Jin'sora" ;
Flags1 = 0x08480046 ;
Id = 3410 ; 
Guild = "Bow Merchant";
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
NpcText00 = "Greetings $N, I am Jin'sora." ;
BaseMana = 0 ;
Sells = new Item[] { new JaggedArrow()
                           , new FineShortbow()
                           , new SturdyRecurve()
                           , new MassiveLongbow()
                           , new MediumQuiver()
                           , new RoughArrow()
                           , new SharpArrow()
                           , new ReinforcedBow()
                           , new HeavyRecurveBow()
                           , new RazorArrow()
                           , new SmallQuiver()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 6232, InventoryTypes.Ranged, 2, 2, 15, 0, 0, 0, 0 ));
}
}
public class FrederickStover : BaseCreature 
 { 
public  FrederickStover() : base() 
 { 
Model = 1427;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Frederick Stover" ;
Flags1 = 0x08480046 ;
Id = 1298 ; 
Guild = "Bow & Arrow Merchant";
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
NpcText00 = "Greetings $N, I am Frederick Stover." ;
BaseMana = 0 ;
Sells = new Item[] { new JaggedArrow()
                           , new FineShortbow()
                           , new SturdyRecurve()
                           , new MassiveLongbow()
                           , new MediumQuiver()
                           , new LightQuiver()
                           , new WornShortbow()
                           , new PolishedShortbow()
                           , new HornwoodRecurveBow()
                           , new LaminatedRecurveBow()
                           , new RoughArrow()
                           , new SharpArrow()
                           , new ReinforcedBow()
                           , new HeavyRecurveBow()
                           , new RazorArrow()
                           , new CrownOfThePenitent()
                           , new FireTar()
                           , new ExplosiveShell()
                           , new SmallQuiver()
  } ;
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 8106, InventoryTypes.Ranged, 2, 2, 15, 0, 0, 0, 0 ));
}
}
public class MabelSolaj : BaseCreature 
 { 
public  MabelSolaj() : base() 
 { 
Model = 4340;
AttackSpeed= 1500;
BoundingRadius = 0.208000f ;
Name = "Mabel Solaj" ;
Flags1 = 0x08480046 ;
Id = 227 ; 
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
NpcType = 7 ;
BaseHitPoints = 1064 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 28, 36 );
NpcText00 = "Greetings $N, I am Mabel Solaj." ;
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
                           , new SoulShard()
  } ;
Faction = Factions.Stormwind;
Guild = "Bowyer" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}

public class AvetteFellwood : BaseCreature 
 { 
public  AvetteFellwood() : base() 
 { 
Model = 4334;
AttackSpeed= 1500;
BoundingRadius = 0.208000f ;
Name = "Avette Fellwood" ;
Flags1 = 0x08480046 ;
Id = 228 ; 
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
NpcType = 7 ;
BaseHitPoints = 1064 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 28, 36 );
NpcText00 = "Greetings $N, I am Avette Fellwood." ;
BaseMana = 0 ;
Sells = new Item[] { new JaggedArrow()
                           , new FineLongbow()
                           , new MediumQuiver()
                           , new RoughArrow()
                           , new SharpArrow()
                           , new ReinforcedBow()
                           , new HeavyRecurveBow()
                           , new RazorArrow()
                           , new SmallQuiver()
  } ;
Faction = Factions.Stormwind;
Guild = "Bowyer" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 6232, InventoryTypes.Ranged, 2, 2, 15, 0, 0, 0, 0 ));
}
}

public class RallicFinn : BaseCreature 
 { 
public  RallicFinn() : base() 
 { 
Model = 5014;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Rallic Finn" ;
Flags1 = 0x0480046 ;
Id = 1198 ; 
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
Level = RandomLevel( 18 );
NpcType = 7 ;
BaseHitPoints = 344 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 8, 11 );
NpcText00 = "Greetings $N, I am Rallic Finn." ;
BaseMana = 0 ;
Sells = new Item[] { new FineShortbow()
                           , new MediumQuiver()
                           , new HornwoodRecurveBow()
                           , new LaminatedRecurveBow()
                           , new RoughArrow()
                           , new SharpArrow()
                           , new SmallQuiver()
  } ;
Faction = Factions.Stormwind;
Guild = "Bowyer" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 6233, InventoryTypes.Ranged, 2, 2, 15, 0, 0, 0, 0 ));
}
}

public class WilliamMacGregor : BaseCreature 
 { 
public  WilliamMacGregor() : base() 
 { 
Model = 3259;
AttackSpeed= 1500;
BoundingRadius = 0.306000f ;
Name = "William MacGregor" ;
Flags1 = 0x08480046 ;
Id = 1668 ; 
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
NpcText00 = "Greetings $N, I am William MacGregor." ;
BaseMana = 0 ;
Sells = new Item[] { new FineLongbow()
                           , new MediumQuiver()
                           , new LaminatedRecurveBow()
                           , new RoughArrow()
                           , new SharpArrow()
                           , new ReinforcedBow()
                           , new SmallQuiver()
  } ;
Faction = Factions.Stormwind;
Guild = "Bowyer" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 7483, InventoryTypes.OneHand, 2, 7, 1, 3, 0, 0, 0 ), new Item( 1684, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ),new Item( 6232, InventoryTypes.OneHand, 2, 2, 2, 0, 0, 0, 0 ));
}
}

public class CliffHadin : BaseCreature 
 { 
public  CliffHadin() : base() 
 { 
Model = 1823;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Cliff Hadin" ;
Flags1 = 0x08480046 ;
Id = 1687 ; 
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
NpcText00 = "Greetings $N, I am Cliff Hadin." ;
BaseMana = 0 ;
Sells = new Item[] { new FineLongbow()
                           , new MediumQuiver()
                           , new LaminatedRecurveBow()
                           , new RoughArrow()
                           , new SharpArrow()
                           , new ReinforcedBow()
                           , new SmallQuiver()
  } ;
Faction = Factions.IronForge;
Guild = "Bowyer" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
}
}

public class HarenKanmae : BaseCreature 
 { 
public  HarenKanmae() : base() 
 { 
Model = 4478;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Haren Kanmae" ;
Flags1 = 0x08080046 ;
Id = 2839 ; 
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
CombatReach = 1.5f ;
SetDamage ( 44, 58 );
NpcText00 = "Greetings $N, I am Haren Kanmae." ;
BaseMana = 0 ;
Sells = new Item[] { new JaggedArrow()
                           , new DenseShortbow()
                           , new MediumQuiver()
                           , new RoughArrow()
                           , new SharpArrow()
                           , new ReinforcedBow()
                           , new HeavyRecurveBow()
                           , new RazorArrow()
                           , new SmallQuiver()
  } ;
Faction = Factions.BootyBay;
Guild = "Bowyer" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 6232, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
}
}

public class KunaThunderhorn : BaseCreature 
 { 
public  KunaThunderhorn() : base() 
 { 
Model = 2114;
AttackSpeed= 2000;
BoundingRadius = 0.872500f ;
Name = "Kuna Thunderhorn" ;
Flags1 = 0x08480046 ;
Id = 3015 ; 
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
NpcText00 = "Greetings $N, I am Kuna Thunderhorn." ;
BaseMana = 0 ;
Sells = new Item[] { new JaggedArrow()
                           , new FineShortbow()
                           , new SturdyRecurve()
                           , new MassiveLongbow()
                           , new MediumQuiver()
                           , new RoughArrow()
                           , new SharpArrow()
                           , new ReinforcedBow()
                           , new HeavyRecurveBow()
                           , new RazorArrow()
                           , new SmallQuiver()
  } ;
Faction = Factions.ThunderBluff;
Guild = "Bowyer" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 6232, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
}
}

public class Ghrawt : BaseCreature 
 { 
public  Ghrawt() : base() 
 { 
Model = 3739;
AttackSpeed= 2000;
BoundingRadius = 0.372000f ;
Name = "Ghrawt" ;
Flags1 = 0x08480046 ;
Id = 3165 ; 
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
Level = RandomLevel( 13 );
NpcType = 7 ;
BaseHitPoints = 624 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 16, 21 );
NpcText00 = "Greetings $N, I am Ghrawt." ;
BaseMana = 0 ;
Sells = new Item[] { new MediumQuiver()
                           , new HornwoodRecurveBow()
                           , new LaminatedRecurveBow()
                           , new RoughArrow()
                           , new SharpArrow()
                           , new SmallQuiver()
  } ;
Faction = Factions.Ogrimmar;
Guild = "Bowyer" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 6233, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
}
}


public class Uthrok : BaseCreature 
 { 
public  Uthrok() : base() 
 { 
Model = 1866;
AttackSpeed= 2000;
BoundingRadius = 0.372000f ;
Name = "Uthrok" ;
Flags1 = 0x08480046 ;
Id = 3488 ; 
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
BaseHitPoints = 1024 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 27, 35 );
NpcText00 = "Greetings $N, I am Uthrok." ;
BaseMana = 0 ;
Sells = new Item[] { new FineLongbow()
                           , new MediumQuiver()
                           , new LaminatedRecurveBow()
                           , new OrnateBlunderbuss()
                           , new HuntersBoomstick()
                           , new RoughArrow()
                           , new SharpArrow()
                           , new LightShot()
                           , new HeavyShot()
                           , new ReinforcedBow()
                           , new SmallQuiver()
                           , new SmallShotPouch()
  } ;
Faction = Factions.Ogrimmar;
Guild = "Bowyer" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 7477, InventoryTypes.OneHand, 2, 4, 2, 3, 0, 0, 0 ), new Item( 6235, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
}
}

public class JeenaFeatherbow : BaseCreature 
 { 
public  JeenaFeatherbow() : base() 
 { 
Model = 1705;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Jeena Featherbow" ;
Flags1 = 0x08480046 ;
Id = 3610 ; 
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
Level = RandomLevel( 19 );
NpcType = 7 ;
BaseHitPoints = 1424 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 38, 49 );
NpcText00 = "Greetings $N, I am Jeena Featherbow." ;
BaseMana = 0 ;
Sells = new Item[] { new MediumQuiver()
                           , new HornwoodRecurveBow()
                           , new LaminatedRecurveBow()
                           , new RoughArrow()
                           , new SharpArrow()
                           , new SmallQuiver()
  } ;
Faction = Factions.Darnasus;
Guild = "Bowyer" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 6232, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
}
}

public class BhaldaranRavenshade : BaseCreature 
 { 
public  BhaldaranRavenshade() : base() 
 { 
Model = 2065;
AttackSpeed= 2000;
BoundingRadius = 0.389000f ;
Name = "Bhaldaran Ravenshade" ;
Flags1 = 0x08480046 ;
Id = 3951 ; 
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
Level = RandomLevel( 34 );
NpcType = 7 ;
BaseHitPoints = 1384 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 37, 48 );
NpcText00 = "Greetings $N, I am Bhaldaran Ravenshade." ;
BaseMana = 0 ;
Sells = new Item[] { new DenseShortbow()
                           , new MediumQuiver()
                           , new LaminatedRecurveBow()
                           , new RoughArrow()
                           , new SharpArrow()
                           , new ReinforcedBow()
                           , new SmallQuiver()
  } ;
Faction = Factions.Darnasus;
Guild = "Bowyer" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 6231, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
}
}

public class JensenFarran : BaseCreature 
 { 
public  JensenFarran() : base() 
 { 
Model = 4827;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Jensen Farran" ;
Flags1 = 0x08480046 ;
Id = 4892 ; 
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
Level = RandomLevel( 37 );
NpcType = 7 ;
BaseHitPoints = 1504 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 40, 52 );
NpcText00 = "Greetings $N, I am Jensen Farran." ;
BaseMana = 0 ;
Sells = new Item[] { new JaggedArrow()
                           , new DenseShortbow()
                           , new MediumQuiver()
                           , new RoughArrow()
                           , new SharpArrow()
                           , new ReinforcedBow()
                           , new HeavyRecurveBow()
                           , new RazorArrow()
                           , new SmallQuiver()
  } ;
Faction = Factions.Stormwind;
Guild = "Bowyer" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 6235, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
}
}

public class CawindTrueaim : BaseCreature 
 { 
public  CawindTrueaim() : base() 
 { 
Model = 8666;
AttackSpeed= 2000;
BoundingRadius = 0.974700f ;
Name = "Cawind Trueaim" ;
Flags1 = 0x08480046 ;
Id = 9548 ; 
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
BaseHitPoints = 1865 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 4.05f ;
SetDamage ( 50, 65 );
NpcText00 = "Greetings $N, I am Cawind Trueaim." ;
BaseMana = 0 ;
Sells = new Item[] { new AccurateSlugs()
                           , new JaggedArrow()
                           , new SylvanShortbow()
                           , new MediumQuiver()
                           , new RoughArrow()
                           , new SharpArrow()
                           , new LightShot()
                           , new HeavyShot()
                           , new LargeBoreBlunderbuss()
                           , new BKP2700Enforcer()
                           , new BKP42Ultra()
                           , new ReinforcedBow()
                           , new HeavyRecurveBow()
                           , new RazorArrow()
                           , new SolidShot()
                           , new SmallQuiver()
  } ;
Faction = Factions.ThunderBluff;
Guild = "Bowyer" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
Equip( new Item( 20726, InventoryTypes.RangeRight, 2, 3, 1, 0, 0, 0, 0 ));
}
}

public class Borand : BaseCreature 
 { 
public  Borand() : base() 
 { 
Model = 8668;
AttackSpeed= 2000;
BoundingRadius = 0.372000f ;
Name = "Borand" ;
Flags1 = 0x08480046 ;
Id = 9549 ; 
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
NpcText00 = "Greetings $N, I am Borand." ;
BaseMana = 0 ;
Sells = new Item[] { new FineLongbow()
                           , new MediumQuiver()
                           , new LaminatedRecurveBow()
                           , new RoughArrow()
                           , new SharpArrow()
                           , new ReinforcedBow()
                           , new SmallQuiver()
  } ;
Faction = Factions.Ogrimmar;
Guild = "Bowyer" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 6233, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
}
}

public class Starn : BaseCreature 
 { 
public  Starn() : base() 
 { 
Model = 8670;
AttackSpeed= 2000;
BoundingRadius = 0.974700f ;
Name = "Starn" ;
Flags1 = 0x08400046 ;
Id = 9551 ; 
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
Level = RandomLevel( 37 );
NpcType = 7 ;
BaseHitPoints = 1504 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 4.05f ;
SetDamage ( 40, 52 );
NpcText00 = "Greetings $N, I am Starn." ;
BaseMana = 0 ;
Sells = new Item[] { new AccurateSlugs()
                           , new JaggedArrow()
                           , new FineLongbow()
                           , new DenseShortbow()
                           , new MediumQuiver()
                           , new OrnateBlunderbuss()
                           , new HuntersBoomstick()
                           , new RoughArrow()
                           , new SharpArrow()
                           , new LightShot()
                           , new HeavyShot()
                           , new LargeBoreBlunderbuss()
                           , new BKP2700Enforcer()
                           , new ReinforcedBow()
                           , new HeavyRecurveBow()
                           , new RazorArrow()
                           , new SolidShot()
                           , new SmallQuiver()
                           , new SmallShotPouch()
  } ;
Faction = Factions.ThunderBluff;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 20726, InventoryTypes.RangeRight, 2, 3, 1, 0, 0, 0, 0 ));
}
}

public class Zanara : BaseCreature 
 { 
public  Zanara() : base() 
 { 
Model = 8671;
AttackSpeed= 2000;
BoundingRadius = 0.236000f ;
Name = "Zanara" ;
Flags1 = 0x08400046 ;
Id = 9552 ; 
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
NpcType = 7 ;
BaseHitPoints = 1745 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 47, 60 );
NpcText00 = "Greetings $N, I am Zanara." ;
BaseMana = 0 ;
Sells = new Item[] { new JaggedArrow()
                           , new DenseShortbow()
                           , new MediumQuiver()
                           , new RoughArrow()
                           , new SharpArrow()
                           , new ReinforcedBow()
                           , new HeavyRecurveBow()
                           , new RazorArrow()
                           , new SmallQuiver()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
}
}

public class NadiaVernon : BaseCreature 
 { 
public  NadiaVernon() : base() 
 { 
Model = 8672;
AttackSpeed= 2000;
BoundingRadius = 0.383000f ;
Name = "Nadia Vernon" ;
Flags1 = 0x08480046 ;
Id = 9553 ; 
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
NpcText00 = "Greetings $N, I am Nadia Vernon." ;
BaseMana = 0 ;
Sells = new Item[] { new FineLongbow()
                           , new MediumQuiver()
                           , new LaminatedRecurveBow()
                           , new RoughArrow()
                           , new SharpArrow()
                           , new ReinforcedBow()
                           , new SmallQuiver()
  } ;
Faction = Factions.Undercity;
Guild = "Bowyer" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 6232, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
}
}

public class Muuta : BaseCreature 
 { 
public  Muuta() : base() 
 { 
Model = 8677;
AttackSpeed= 2000;
BoundingRadius = 0.372000f ;
Name = "Mu'uta" ;
Flags1 = 0x08480046 ;
Id = 9555 ; 
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
NpcText00 = "Greetings $N, I am Mu'uta." ;
BaseMana = 0 ;
Sells = new Item[] { new JaggedArrow()
                           , new DenseShortbow()
                           , new MediumQuiver()
                           , new RoughArrow()
                           , new SharpArrow()
                           , new ReinforcedBow()
                           , new HeavyRecurveBow()
                           , new RazorArrow()
                           , new SmallQuiver()
  } ;
Faction = Factions.Ogrimmar;
Guild = "Bowyer" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 6235, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
}
}

public class Narianna : BaseCreature 
 { 
public  Narianna() : base() 
 { 
Model = 12040;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Narianna" ;
Flags1 = 0x08080046 ;
Id = 12029 ; 
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
NpcText00 = "Greetings $N, I am Narianna." ;
BaseMana = 0 ;
Sells = new Item[] { new SylvanShortbow()
                           , new MediumQuiver()
                           , new WornShortbow()
                           , new PolishedShortbow()
                           , new HornwoodRecurveBow()
                           , new LaminatedRecurveBow()
                           , new RoughArrow()
                           , new SharpArrow()
                           , new ReinforcedBow()
                           , new HeavyRecurveBow()
                           , new RazorArrow()
                           , new SmallQuiver()
  } ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
Equip( new Item( 7483, InventoryTypes.Ranged, 2, 2, 15, 0, 0, 0, 0 ));
}
}

public class BrinnaValanaar : BaseCreature 
 { 
public  BrinnaValanaar() : base() 
 { 
Model = 14353;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Brinna Valanaar" ;
Flags1 = 0x08480006 ;
Id = 14301 ; 
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
Level = RandomLevel( 45 );
NpcType = 7 ;
BaseHitPoints = 0 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.500000f ;
SetDamage ( 41, 61 );
NpcText00 = "Hello" ;
BaseMana = 0 ;
Sells = new Item[] { new DenseShortbow()
                           , new MediumQuiver()
                           , new WornShortbow()
                           , new PolishedShortbow()
                           , new HornwoodRecurveBow()
                           , new LaminatedRecurveBow()
                           , new RoughArrow()
                           , new SharpArrow()
                           , new ReinforcedBow()
                           , new HeavyRecurveBow()
                           , new RazorArrow()
                           , new SmallQuiver()
  } ;
Faction = Factions.Darnasus;
Guild = "Bowyer" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 23317, InventoryTypes.OneHand, 2, 14, 1, 0, 0, 0, 0 ));
}
}

}