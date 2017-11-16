//originally Scripted By DiScS Converter
//Edited by *place name here*
using System;
using Server.Items;

////////////////////
namespace Server.Creatures
{
public class Muuran : BaseCreature 
 { 
public  Muuran() : base() 
 { 
Model = 8169;
AttackSpeed= 2000;
BoundingRadius = 0.974700f ;
Name = "Muuran" ;
Flags1 = 0x08480046 ;
Id = 8878 ; 
Guild = "Superior Macecrafter";
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
CombatReach = 4.05f ;
SetDamage ( 43, 56 );
NpcText00 = "Greetings $N, I am Muuran." ;
BaseMana = 0 ;
Sells = new Item[] { new PlansSolidIronMaul()
                           , new Truncheon()
                           , new WarHammer()
                           , new BattleStaff()
                           , new MorningStar()
                           , new WarMaul()
                           , new WarStaff()
  } ;
Faction = Factions.ThunderBluff;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 7477, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ));
}
}
public class Katis : BaseCreature 
 { 
public  Katis() : base() 
 { 
Model = 4355;
AttackSpeed= 2000;
BoundingRadius = 0.236000f ;
Name = "Katis" ;
Flags1 = 0x08480046 ;
Id = 5816 ; 
Guild = "Wand Merchant";
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
NpcText00 = "Greetings $N, I am Katis." ;
BaseMana = 0 ;
Sells = new Item[] { new SmolderingWand()
                           , new GloomWand()
                           , new BurningWand()
                           , new DuskWand()
                           , new CombustibleWand()
                           , new PitchwoodWand()
                           , new BlackboneWand()
                           , new PestilentWand()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 5098, InventoryTypes.TwoHanded, 2, 10, 2, 0, 0, 0, 0 ), new Item( 21094, InventoryTypes.Back, 2, 19, 2, 0, 0, 0, 0 ));
}
}
public class ZaneBradford : BaseCreature 
 { 
public  ZaneBradford() : base() 
 { 
Model = 4150;
AttackSpeed= 1500;
BoundingRadius = 0.383000f ;
Name = "Zane Bradford" ;
Flags1 = 0x018480046 ;
Id = 5754 ; 
Guild = "Wand Vendor";
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
NpcText00 = "Greetings $N, I am Zane Bradford." ;
BaseMana = 0 ;
Sells = new Item[] { new SmolderingWand()
                           , new GloomWand()
                           , new BurningWand()
                           , new DuskWand()
                           , new CombustibleWand()
                           , new PitchwoodWand()
                           , new BlackboneWand()
                           , new PestilentWand()
  } ;
Faction = Factions.Undercity;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 21094, InventoryTypes.Back, 2, 19, 2, 0, 0, 0, 0 ));
}
}
public class HjoldirStoneblade : BaseCreature 
 { 
public  HjoldirStoneblade() : base() 
 { 
Model = 3103;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Hjoldir Stoneblade" ;
Flags1 = 0x08480046 ;
Id = 5170 ; 
Guild = "Blade Merchant";
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
NpcText00 = "Greetings $N, I am Hjoldir Stoneblade." ;
BaseMana = 0 ;
Sells = new Item[] { new Broadsword()
                           , new Flamberge()
                           , new MainGauche()
                           , new Falchion()
                           , new Zweihander()
                           , new Rondel()
  } ;
Faction = Factions.IronForge;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 6434, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
}
}
public class HarickBoulderdrum : BaseCreature 
 { 
public  HarickBoulderdrum() : base() 
 { 
Model = 3082;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Harick Boulderdrum" ;
Flags1 = 0x08480046 ;
Id = 5133 ; 
Guild = "Wands Merchant";
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
NpcText00 = "Greetings $N, I am Harick Boulderdrum." ;
BaseMana = 0 ;
Sells = new Item[] { new SmolderingWand()
                           , new GloomWand()
                           , new BurningWand()
                           , new DuskWand()
                           , new CombustibleWand()
                           , new PitchwoodWand()
                           , new BlackboneWand()
                           , new PestilentWand()
  } ;
Faction = Factions.IronForge;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 21094, InventoryTypes.Back, 2, 19, 2, 26, 0, 0, 0 ));
}
}
public class KelomirIronhand : BaseCreature 
 { 
public  KelomirIronhand() : base() 
 { 
Model = 3076;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Kelomir Ironhand" ;
Flags1 = 0x08480046 ;
Id = 5121 ; 
Guild = "Maces & Staves";
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
NpcText00 = "Greetings $N, I am Kelomir Ironhand." ;
BaseMana = 0 ;
Sells = new Item[] { new GiantMace()
                           , new RockHammer()
                           , new Hammer()
                           , new GnarledStaff()
                           , new Truncheon()
                           , new WarHammer()
                           , new BattleStaff()
                           , new MorningStar()
                           , new WarMaul()
                           , new WarStaff()
                           , new Mace()
                           , new QuarterStaff()
                           , new Maul()
                           , new Flail()
                           , new LongStaff()
  } ;
Faction = Factions.IronForge;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7476, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ));
}
}
public class BrenwynWintersteel : BaseCreature 
 { 
public  BrenwynWintersteel() : base() 
 { 
Model = 3057;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Brenwyn Wintersteel" ;
Flags1 = 0x08480046 ;
Id = 5120 ; 
Guild = "Blade Merchant";
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
NpcText00 = "Greetings $N, I am Brenwyn Wintersteel." ;
BaseMana = 0 ;
Sells = new Item[] { new Claymore()
                           , new GleamingThrowingAxe()
                           , new WickedThrowingDagger()
                           , new Espadon()
                           , new Scimitar()
                           , new Jambiya()
                           , new Poniard()
                           , new Kris()
                           , new Broadsword()
                           , new Flamberge()
                           , new MainGauche()
                           , new Falchion()
                           , new Zweihander()
                           , new Rondel()
                           , new BalancedThrowingDagger()
                           , new SmallThrowingKnife()
                           , new KeenThrowingKnife()
                           , new HeavyThrowingDagger()
                           , new CrudeThrowingAxe()
                           , new WeightedThrowingAxe()
                           , new SharpThrowingAxe()
                           , new DeadlyThrowingAxe()
                           , new Cutlass()
                           , new DacianFalx()
                           , new Longsword()
  } ;
Faction = Factions.IronForge;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7483, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ), new Item( 10968, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
}
}
public class SydneyUpton : BaseCreature 
 { 
public  SydneyUpton() : base() 
 { 
Model = 2673;
AttackSpeed= 2000;
BoundingRadius = 0.383000f ;
Name = "Sydney Upton" ;
Flags1 = 0x018480046 ;
Id = 4570 ; 
Guild = "Staff Merchant";
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
NpcText00 = "Greetings $N, I am Sydney Upton." ;
BaseMana = 0 ;
Sells = new Item[] { new BattleStaff()
                           , new WarStaff()
  } ;
Faction = Factions.Undercity;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 1599, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
}
}
public class CharlesSeaton : BaseCreature 
 { 
public  CharlesSeaton() : base() 
 { 
Model = 2619;
AttackSpeed= 2000;
BoundingRadius = 0.383000f ;
Name = "Charles Seaton" ;
Flags1 = 0x018480046 ;
Id = 4569 ; 
Guild = "Blade Merchant";
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
NpcText00 = "Greetings $N, I am Charles Seaton." ;
BaseMana = 0 ;
Sells = new Item[] { new Claymore()
                           , new Espadon()
                           , new Scimitar()
                           , new Jambiya()
                           , new Poniard()
                           , new Kris()
                           , new Cutlass()
                           , new DacianFalx()
                           , new Longsword()
  } ;
Faction = Factions.Undercity;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7419, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ));
}
}
public class Andrus : BaseCreature 
 { 
public  Andrus() : base() 
 { 
Model = 2249;
AttackSpeed= 2000;
BoundingRadius = 0.389000f ;
Name = "Andrus" ;
Flags1 = 0x08480046 ;
Id = 4234 ; 
Guild = "Staff Merchant";
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
NpcText00 = "Greetings $N, I am Andrus." ;
BaseMana = 0 ;
Sells = new Item[] { new BattleStaff()
                           , new WarStaff()
  } ;
Faction = Factions.Darnasus;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 2840, InventoryTypes.MainGauche, 2, 10, 2, 2, 0, 0, 0 ));
}
}
public class Mythidan : BaseCreature 
 { 
public  Mythidan() : base() 
 { 
Model = 2263;
AttackSpeed= 2000;
BoundingRadius = 0.389000f ;
Name = "Mythidan" ;
Flags1 = 0x08480046 ;
Id = 4233 ; 
Guild = "Mace & Staff Merchant";
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
NpcText00 = "Greetings $N, I am Mythidan." ;
BaseMana = 0 ;
Sells = new Item[] { new GiantMace()
                           , new RockHammer()
                           , new Hammer()
                           , new GnarledStaff()
                           , new Mace()
                           , new QuarterStaff()
                           , new Maul()
                           , new Flail()
                           , new LongStaff()
  } ;
Faction = Factions.Darnasus;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7476, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ));
}
}
public class KizzBluntstrike : BaseCreature 
 { 
public  KizzBluntstrike() : base() 
 { 
Model = 7183;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Kizz Bluntstrike" ;
Flags1 = 0x08080046 ;
Id = 2840 ; 
Guild = "Macecrafter";
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
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1705 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 46, 59 );
NpcText00 = "Greetings $N, I am Kizz Bluntstrike." ;
BaseMana = 0 ;
Sells = new Item[] { new GiantMace()
                           , new IronwoodMaul()
                           , new HeavySpikedMace()
                           , new Mace()
  } ;
Faction = Factions.BootyBay;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 7439, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ));
}
}
public class NillenAndemar : BaseCreature 
 { 
public  NillenAndemar() : base() 
 { 
Model = 1845;
AttackSpeed= 1500;
BoundingRadius = 0.347000f ;
Name = "Nillen Andemar" ;
Flags1 = 0x08480046 ;
Id = 222 ; 
Guild = "Macecrafter";
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
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 784 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 20, 26 );
NpcText00 = "Greetings $N, I am Nillen Andemar." ;
BaseMana = 0 ;
Sells = new Item[] { new GiantMace()
                           , new Cudgel()
                           , new WoodenMallet()
                           , new IronwoodMaul()
                           , new HeavySpikedMace()
                           , new Mace()
  } ;
Faction = Factions.IronForge;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 7476, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ));
}
}
public class Merelyssa : BaseCreature 
 { 
public  Merelyssa() : base() 
 { 
Model = 2219;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Merelyssa" ;
Flags1 = 0x08480046 ;
Id = 4171 ; 
Guild = "Blade Merchant";
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
NpcText00 = "Greetings $N, I am Merelyssa." ;
BaseMana = 0 ;
Sells = new Item[] { new Claymore()
                           , new Espadon()
                           , new Scimitar()
                           , new Jambiya()
                           , new Poniard()
                           , new Kris()
                           , new Broadsword()
                           , new MainGauche()
                           , new Falchion()
                           , new Rondel()
                           , new Cutlass()
                           , new DacianFalx()
                           , new Longsword()
  } ;
Faction = Factions.Darnasus;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7483, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ));
}
}
public class Mankrik : BaseCreature 
 { 
public  Mankrik() : base() 
 { 
Model = 3855;
AttackSpeed= 2000;
BoundingRadius = 0.372000f ;
Name = "Mankrik" ;
Flags1 = 0x08480046 ;
Id = 3432 ; 
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
NpcText00 = "Hello" ;
BaseMana = 0 ;
Sells = new Item[] { new Tabar()
                           , new GiantMace()
                           , new Claymore()
                           , new Jambiya()
                           , new FeralBlade()
                           , new Cutlass()
                           , new Mace()
                           , new Hatchet()
                           , new QuarterStaff()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 20502, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ), new Item( 1755, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
}
}
public class Koru : BaseCreature 
 { 
public  Koru() : base() 
 { 
Model = 1382;
AttackSpeed= 1739;
BoundingRadius = 0.372000f ;
Name = "Koru" ;
Flags1 = 0x08480046 ;
Id = 3360 ; 
Guild = "Mace & Staves Vendor";
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
NpcText00 = "Greetings $N, I am Koru." ;
BaseMana = 0 ;
Sells = new Item[] { new GiantMace()
                           , new RockHammer()
                           , new Hammer()
                           , new GnarledStaff()
                           , new Mace()
                           , new QuarterStaff()
                           , new Maul()
                           , new Flail()
                           , new LongStaff()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7477, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ));
}
}
public class Ukranor : BaseCreature 
 { 
public  Ukranor() : base() 
 { 
Model = 1370;
AttackSpeed= 1739;
BoundingRadius = 0.372000f ;
Name = "Ukra'nor" ;
Flags1 = 0x08480046 ;
Id = 3349 ; 
Guild = "Staff Merchant";
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
NpcText00 = "Greetings $N, I am Ukra'nor." ;
BaseMana = 0 ;
Sells = new Item[] { new BattleStaff()
                           , new WarStaff()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 5098, InventoryTypes.MainGauche, 2, 10, 2, 2, 0, 0, 0 ));
}
}
public class Kareth : BaseCreature 
 { 
public  Kareth() : base() 
 { 
Model = 1331;
AttackSpeed= 1739;
BoundingRadius = 0.372000f ;
Name = "Kareth" ;
Flags1 = 0x08480046 ;
Id = 3331 ; 
Guild = "Blade Merchant";
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
NpcText00 = "Greetings $N, I am Kareth." ;
BaseMana = 0 ;
Sells = new Item[] { new Claymore()
                           , new Espadon()
                           , new Scimitar()
                           , new Jambiya()
                           , new Poniard()
                           , new Kris()
                           , new Broadsword()
                           , new MainGauche()
                           , new Falchion()
                           , new Rondel()
                           , new Cutlass()
                           , new DacianFalx()
                           , new Longsword()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7482, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ));
}
}
public class Muragus : BaseCreature 
 { 
public  Muragus() : base() 
 { 
Model = 1330;
AttackSpeed= 2000;
BoundingRadius = 0.372000f ;
Name = "Muragus" ;
Flags1 = 0x08480046 ;
Id = 3330 ; 
Guild = "Staff Merchant";
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
NpcText00 = "Greetings $N, I am Muragus." ;
BaseMana = 0 ;
Sells = new Item[] { new BattleStaff()
                           , new WarStaff()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 5098, InventoryTypes.MainGauche, 2, 10, 2, 2, 0, 0, 0 ));
}
}
public class SunnRagetotem : BaseCreature 
 { 
public  SunnRagetotem() : base() 
 { 
Model = 2124;
AttackSpeed= 2000;
BoundingRadius = 0.872500f ;
Name = "Sunn Ragetotem" ;
Flags1 = 0x08480046 ;
Id = 3022 ; 
Guild = "Staff Merchant";
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
CombatReach = 3.75f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Sunn Ragetotem." ;
BaseMana = 0 ;
Sells = new Item[] { new BattleStaff()
                           , new WarStaff()
  } ;
Faction = Factions.ThunderBluff;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 5542, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
}
}
public class KardRagetotem : BaseCreature 
 { 
public  KardRagetotem() : base() 
 { 
Model = 2089;
AttackSpeed= 2000;
BoundingRadius = 0.974700f ;
Name = "Kard Ragetotem" ;
Flags1 = 0x08480046 ;
Id = 3021 ; 
Guild = "Sword and Dagger Merchant";
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
NpcText00 = "Greetings $N, I am Kard Ragetotem." ;
BaseMana = 0 ;
Sells = new Item[] { new Claymore()
                           , new Espadon()
                           , new Scimitar()
                           , new Jambiya()
                           , new Poniard()
                           , new Kris()
                           , new Broadsword()
                           , new MainGauche()
                           , new Falchion()
                           , new Rondel()
                           , new Cutlass()
                           , new DacianFalx()
                           , new Longsword()
  } ;
Faction = Factions.ThunderBluff;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 20036, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ));
}
}
public class EtuRagetotem : BaseCreature 
 { 
public  EtuRagetotem() : base() 
 { 
Model = 2085;
AttackSpeed= 2000;
BoundingRadius = 0.974700f ;
Name = "Etu Ragetotem" ;
Flags1 = 0x08480046 ;
Id = 3020 ; 
Guild = "Mace & Staff Merchant";
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
NpcText00 = "Greetings $N, I am Etu Ragetotem." ;
BaseMana = 0 ;
Sells = new Item[] { new GiantMace()
                           , new RockHammer()
                           , new Hammer()
                           , new GnarledStaff()
                           , new Mace()
                           , new QuarterStaff()
                           , new Maul()
                           , new Flail()
                           , new LongStaff()
  } ;
Faction = Factions.ThunderBluff;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 18583, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ));
}
}
public class Jutak : BaseCreature 
 { 
public  Jutak() : base() 
 { 
Model = 4481;
AttackSpeed= 2000;
BoundingRadius = 0.236000f ;
Name = "Jutak" ;
Flags1 = 0x08080046 ;
Id = 2843 ; 
Guild = "Blade Trader";
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
NpcText00 = "Greetings $N, I am Jutak." ;
BaseMana = 0 ;
Sells = new Item[] { new PlansHardenedIronShortsword()
                           , new DaringDirk()
                           , new Broadsword()
                           , new Flamberge()
                           , new MainGauche()
                           , new Falchion()
                           , new Zweihander()
                           , new Rondel()
  } ;
Faction = Factions.BootyBay;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 7483, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ));
}
}
public class JaquilinaDramet : BaseCreature 
 { 
public  JaquilinaDramet() : base() 
 { 
Model = 4394;
AttackSpeed= 2000;
BoundingRadius = 0.208000f ;
Name = "Jaquilina Dramet" ;
Flags1 = 0x08080046 ;
Id = 2483 ; 
Guild = "Superior Axecrafter";
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
Level = RandomLevel( 39 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1585 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 42, 55 );
NpcText00 = "Greetings $N, I am Jaquilina Dramet." ;
BaseMana = 0 ;
Sells = new Item[] { new PlansMassiveIronAxe()
                           , new MidnightAxe()
                           , new CrescentAxe()
                           , new Bullova()
                           , new Francisca()
                           , new GreatAxe()
  } ;
Faction = Factions.Friend;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 3385, InventoryTypes.TwoHanded, 2, 1, 1, 1, 0, 0, 0 ));
}
}
public class GregoryArdus : BaseCreature 
 { 
public  GregoryArdus() : base() 
 { 
Model = 1503;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Gregory Ardus" ;
Flags1 = 0x08480046 ;
Id = 1348 ; 
Guild = "Staff & Mace Merchant";
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
NpcText00 = "Greetings $N, I am Gregory Ardus." ;
BaseMana = 0 ;
Sells = new Item[] { new GiantMace()
                           , new RockHammer()
                           , new Hammer()
                           , new GnarledStaff()
                           , new Cudgel()
                           , new WoodenMallet()
                           , new Mace()
                           , new QuarterStaff()
                           , new Maul()
                           , new Flail()
                           , new LongStaff()
  } ;
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 8011, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ));
}
}
public class HeinrichStone : BaseCreature 
 { 
public  HeinrichStone() : base() 
 { 
Model = 1512;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Heinrich Stone" ;
Flags1 = 0x08480046 ;
Id = 1324 ; 
Guild = "Blade Merchant";
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
NpcText00 = "Greetings $N, I am Heinrich Stone." ;
BaseMana = 0 ;
Sells = new Item[] { new Broadsword()
                           , new MainGauche()
                           , new Falchion()
                           , new Rondel()
  } ;
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7483, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ), new Item( 2080, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
}
}
public class AllanHafgan : BaseCreature 
 { 
public  AllanHafgan() : base() 
 { 
Model = 1486;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Allan Hafgan" ;
Flags1 = 0x08480046 ;
Id = 1315 ; 
Guild = "Staves Merchant";
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
NpcText00 = "Greetings $N, I am Allan Hafgan." ;
BaseMana = 0 ;
Sells = new Item[] { new BattleStaff()
                           , new WarStaff()
  } ;
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}
public class ArdwynCailen : BaseCreature 
 { 
public  ArdwynCailen() : base() 
 { 
Model = 1477;
AttackSpeed= 2000;
BoundingRadius = 0.208000f ;
Name = "Ardwyn Cailen" ;
Flags1 = 0x08480046 ;
Id = 1312 ; 
Guild = "Wand Merchant";
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
BaseHitPoints = 1120 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 37, 48 );
NpcText00 = "Greetings $N, I am Ardwyn Cailen." ;
BaseMana = 0 ;
Sells = new Item[] { new SmolderingWand()
                           , new GloomWand()
                           , new BurningWand()
                           , new DuskWand()
                           , new CombustibleWand()
                           , new PitchwoodWand()
                           , new BlackboneWand()
                           , new PestilentWand()
  } ;
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 21094, InventoryTypes.Back, 2, 19, 2, 0, 0, 0, 0 ));
}
}
public class CorinaSteele : BaseCreature 
 { 
public  CorinaSteele() : base() 
 { 
Model = 1287;
AttackSpeed= 2000;
BoundingRadius = 0.208000f ;
Name = "Corina Steele" ;
Flags1 = 0x08480046 ;
Id = 54 ; 
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
BaseHitPoints = 200 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 10, 14 );
NpcText00 = "Greetings $N, I am Corina Steele." ;
BaseMana = 0 ;
Sells = new Item[] { new Gladius()
                           , new TwoHandedSword()
                           , new Tomahawk()
                           , new LargeAxe()
                           , new Cudgel()
                           , new WoodenMallet()
                           , new Stiletto()
                           , new WalkingStick()
  } ;
Faction = Factions.Stormwind;
Guild = "Weapon Merchant";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 7439, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ));
}
}

public class GavinGnarltree : BaseCreature 
 { 
public  GavinGnarltree() : base() 
 { 
Model = 4331;
AttackSpeed= 1500;
BoundingRadius = 0.306000f ;
Name = "Gavin Gnarltree" ;
Flags1 = 0x08480046 ;
Id = 225 ; 
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
Unk3 = 7;
NpcType = 7 ;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Gavin Gnarltree." ;
BaseMana = 0 ;
Sells = new Item[] { new BroadBladedKnife()
                           , new MercilessAxe()
                           , new Espadon()
                           , new BeardedAxe()
                           , new RockHammer()
                           , new Scimitar()
                           , new Hammer()
                           , new Cleaver()
                           , new GnarledStaff()
                           , new Poniard()
                           , new Kris()
                           , new DacianFalx()
                           , new Longsword()
                           , new Maul()
                           , new Flail()
                           , new BattleAxe()
                           , new DoubleAxe()
                           , new LongStaff()
  } ;
Faction = Factions.Stormwind;
Guild = "Weapon Merchant";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 11289, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ));
}
}

public class RybradColdbank : BaseCreature 
 { 
public  RybradColdbank() : base() 
 { 
Model = 3391;
AttackSpeed= 1500;
BoundingRadius = 0.347000f ;
Name = "Rybrad Coldbank" ;
Flags1 = 0x08080066 ;
Id = 945 ; 
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
NpcType = 7 ;
BaseHitPoints = 224 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 5, 6 );
NpcText00 = "Greetings $N, I am Rybrad Coldbank." ;
BaseMana = 0 ;
Sells = new Item[] { new BastardSword()
                           , new Club()
                           , new Shortsword()
                           , new ShortStaff()
                           , new HandAxe()
                           , new Dirk()
                           , new BroadAxe()
                           , new LargeClub()
  } ;
Faction = Factions.IronForge;
Guild = "Weapon Merchant";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 7482, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ), new Item( 7486, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ));
}
}

public class Hartash : BaseCreature 
 { 
public  Hartash() : base() 
 { 
Model = 4561;
AttackSpeed= 2000;
BoundingRadius = 0.372000f ;
Name = "Hartash" ;
Flags1 = 0x08400046 ;
Id = 981 ; 
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
BaseHitPoints = 1825 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 49, 63 );
NpcText00 = "Greetings $N, I am Hartash." ;
BaseMana = 0 ;
Sells = new Item[] { new Falchion()
                           , new Zweihander()
                           , new Francisca()
                           , new GreatAxe()
                           , new MorningStar()
                           , new WarMaul()
                           , new Rondel()
                           , new WarStaff()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 20502, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ));
}
}

public class Vharr : BaseCreature 
 { 
public  Vharr() : base() 
 { 
Model = 4389;
AttackSpeed= 2000;
BoundingRadius = 0.372000f ;
Name = "Vharr" ;
Flags1 = 0x08400046 ;
Id = 1146 ; 
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
NpcText00 = "Greetings $N, I am Vharr." ;
BaseMana = 0 ;
Sells = new Item[] { new PlansMassiveIronAxe()
                           , new DaringDirk()
                           , new MidnightAxe()
                           , new Broadsword()
                           , new Flamberge()
                           , new CrescentAxe()
                           , new Bullova()
                           , new Truncheon()
                           , new WarHammer()
                           , new MainGauche()
                           , new BattleStaff()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
}
}

public class GrawnThromwyn : BaseCreature 
 { 
public  GrawnThromwyn() : base() 
 { 
Model = 3417;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Grawn Thromwyn" ;
Flags1 = 0x08480046 ;
Id = 1273 ; 
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
NpcText00 = "Greetings $N, I am Grawn Thromwyn." ;
BaseMana = 0 ;
Sells = new Item[] { new Gladius()
                           , new TwoHandedSword()
                           , new Tomahawk()
                           , new LargeAxe()
                           , new Cudgel()
                           , new WoodenMallet()
                           , new Stiletto()
                           , new WalkingStick()
  } ;
Faction = Factions.IronForge;
Guild = "Weapon Merchant";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 7483, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ));
}
}

public class MardaWeller : BaseCreature 
 { 
public  MardaWeller() : base() 
 { 
Model = 1448;
AttackSpeed= 2000;
BoundingRadius = 0.208000f ;
Name = "Marda Weller" ;
Flags1 = 0x08480046 ;
Id = 1287 ; 
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
NpcText00 = "Greetings $N, I am Marda Weller." ;
BaseMana = 0 ;
Sells = new Item[] { new MediumQuiver()
                           , new Tabar()
                           , new GiantMace()
                           , new Claymore()
                           , new LightCrossbow()
                           , new FineLightCrossbow()
                           , new HeavyCrossbow()
                           , new Espadon()
                           , new BeardedAxe()
                           , new RockHammer()
                           , new Scimitar()
                           , new Hammer()
                           , new Cleaver()
                           , new GnarledStaff()
                           , new LightQuiver()
                           , new Jambiya()
                           , new Poniard()
                           , new Kris()
                           , new RoughArrow()
                           , new SharpArrow()
                           , new RazorArrow()
                           , new HeavyQuiver()
                           , new Cutlass()
                           , new Mace()
                           , new Hatchet()
                           , new QuarterStaff()
                           , new DacianFalx()
                           , new Longsword()
                           , new Maul()
                           , new Flail()
                           , new BattleAxe()
                           , new DoubleAxe()
                           , new LongStaff()
  } ;
Faction = Factions.Stormwind;
Guild = "Weapon Merchant";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7487, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ));
}
}

public class GuntherWeller : BaseCreature 
 { 
public  GuntherWeller() : base() 
 { 
Model = 1429;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Gunther Weller" ;
Flags1 = 0x08480046 ;
Id = 1289 ; 
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
NpcText00 = "Greetings $N, I am Gunther Weller." ;
BaseMana = 0 ;
Sells = new Item[] { new Tabar()
                           , new GiantMace()
                           , new Claymore()
                           , new ShortSpear()
                           , new HeavySpear()
                           , new Espadon()
                           , new BeardedAxe()
                           , new RockHammer()
                           , new Scimitar()
                           , new Hammer()
                           , new Cleaver()
                           , new GnarledStaff()
                           , new Jambiya()
                           , new Poniard()
                           , new Kris()
                           , new Cutlass()
                           , new Mace()
                           , new Hatchet()
                           , new QuarterStaff()
                           , new DacianFalx()
                           , new Longsword()
                           , new Maul()
                           , new Flail()
                           , new BattleAxe()
                           , new DoubleAxe()
                           , new LongStaff()
  } ;
Faction = Factions.Stormwind;
Guild = "Weapon Merchant";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7439, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ));
}
}

public class FelderStover : BaseCreature 
 { 
public  FelderStover() : base() 
 { 
Model = 1426;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Felder Stover" ;
Flags1 = 0x08480046 ;
Id = 1296 ; 
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
BaseHitPoints = 2105 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 53, 79 );
NpcText00 = "Hello" ;
BaseMana = 0 ;
Sells = new Item[] { new Kris()
                           , new Falchion()
                           , new Zweihander()
                           , new Francisca()
                           , new GreatAxe()
                           , new MorningStar()
                           , new WarMaul()
                           , new Rondel()
                           , new WarStaff()
                           , new BlessedClaymore()
                           , new ExecutionersSword()
                           , new DacianFalx()
                           , new Longsword()
                           , new Maul()
                           , new Flail()
                           , new BattleAxe()
                           , new DoubleAxe()
                           , new LongStaff()
  } ;
Faction = Factions.Stormwind;
Guild = "Weapon Merchant";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
}
}

public class GerikKoen : BaseCreature 
 { 
public  GerikKoen() : base() 
 { 
Model = 1511;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Gerik Koen" ;
Flags1 = 0x08480046 ;
Id = 1333 ; 
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
NpcText00 = "Greetings $N, I am Gerik Koen." ;
BaseMana = 0 ;
Sells = new Item[] { new Flamberge()
                           , new Bullova()
                           , new WarHammer()
                           , new Zweihander()
                           , new GreatAxe()
                           , new WarMaul()
  } ;
Faction = Factions.Stormwind;
Guild = "Weapon Merchant";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}

public class BrakDurnad : BaseCreature 
 { 
public  BrakDurnad() : base() 
 { 
Model = 3473;
AttackSpeed= 1500;
BoundingRadius = 0.347000f ;
Name = "Brak Durnad" ;
Flags1 = 0x08480046 ;
Id = 1441 ; 
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
NpcType = 7 ;
BaseHitPoints = 1024 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 27, 35 );
NpcText00 = "Greetings $N, I am Brak Durnad." ;
BaseMana = 0 ;
Sells = new Item[] { new Kris()
                           , new BlessedClaymore()
                           , new ExecutionersSword()
                           , new DacianFalx()
                           , new Longsword()
                           , new Maul()
                           , new Flail()
                           , new BattleAxe()
                           , new DoubleAxe()
                           , new LongStaff()
  } ;
Faction = Factions.IronForge;
Guild = "Weapon Merchant";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7482, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ));
}
}
public class HaroldRaims : BaseCreature 
 { 
public  HaroldRaims() : base() 
 { 
Model = 1576;
AttackSpeed= 2000;
BoundingRadius = 0.383000f ;
Name = "Harold Raims" ;
Flags1 = 0x08000066 ;
Id = 2117 ; 
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
NpcType = 6 ;
BaseHitPoints = 224 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 5, 6 );
NpcText00 = "Greetings $N, I am Harold Raims." ;
BaseMana = 0 ;
Sells = new Item[] { new BastardSword()
                           , new ScratchedClaymore()
                           , new Club()
                           , new Shortsword()
                           , new ShortStaff()
                           , new HandAxe()
                           , new Dirk()
                           , new BroadAxe()
                           , new LargeClub()
                           , new PeonSword()
                           , new InferiorTomahawk()
                           , new RoughBroadAxe()
                           , new SmallKnife()
                           , new SplinteredBoard()
                           , new LargeStoneMace()
                           , new AcolyteStaff()
  } ;
Faction = Factions.Undercity;
Guild = "Weapon Merchant";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 7487, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ));
}
}

public class OliverDwor : BaseCreature 
 { 
public  OliverDwor() : base() 
 { 
Model = 1638;
AttackSpeed= 2000;
BoundingRadius = 0.383000f ;
Name = "Oliver Dwor" ;
Flags1 = 0x08400046 ;
Id = 2136 ; 
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
NpcType = 6 ;
BaseHitPoints = 544 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 14, 18 );
NpcText00 = "Greetings $N, I am Oliver Dwor." ;
BaseMana = 0 ;
Sells = new Item[] { new Gladius()
                           , new TwoHandedSword()
                           , new Tomahawk()
                           , new LargeAxe()
                           , new Cudgel()
                           , new WoodenMallet()
                           , new Stiletto()
                           , new WalkingStick()
                           , new RaiderShortsword()
                           , new RustedClaymore()
                           , new SmallTomahawk()
                           , new DoubleBladedAxe()
                           , new LightHammer()
                           , new WoodenWarhammer()
                           , new ScuffedDagger()
                           , new AdeptShortStaff()
  } ;
Faction = Factions.Undercity;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 5569, InventoryTypes.OneHand, 2, 14, 1, 7, 0, 0, 0 ));
}
}

public class ZarenaCromwind : BaseCreature 
 { 
public  ZarenaCromwind() : base() 
 { 
Model = 4490;
AttackSpeed= 2000;
BoundingRadius = 0.208000f ;
Name = "Zarena Cromwind" ;
Flags1 = 0x08080046 ;
Id = 2482 ; 
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
NpcText00 = "Greetings $N, I am Zarena Cromwind." ;
BaseMana = 0 ;
Sells = new Item[] { new PlansMoonsteelBroadsword()
                           , new BigStick()
                           , new StaffOfProtection()
                           , new Broadsword()
                           , new Flamberge()
                           , new CrescentAxe()
                           , new Bullova()
                           , new Truncheon()
                           , new WarHammer()
                           , new MainGauche()
                           , new BattleStaff()
  } ;
Faction = Factions.BootyBay;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
}
}

public class JynStonehoof : BaseCreature 
 { 
public  JynStonehoof() : base() 
 { 
Model = 2110;
AttackSpeed= 2000;
BoundingRadius = 0.872500f ;
Name = "Jyn Stonehoof" ;
Flags1 = 0x08480046 ;
Id = 2997 ; 
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
NpcText00 = "Greetings $N, I am Jyn Stonehoof." ;
BaseMana = 0 ;
Sells = new Item[] { new BastardSword()
                           , new Tabar()
                           , new GiantMace()
                           , new Claymore()
                           , new Espadon()
                           , new BeardedAxe()
                           , new RockHammer()
                           , new Scimitar()
                           , new Hammer()
                           , new Cleaver()
                           , new GnarledStaff()
                           , new ScratchedClaymore()
                           , new Club()
                           , new Shortsword()
                           , new ShortStaff()
                           , new HandAxe()
                           , new Dirk()
                           , new Jambiya()
                           , new Poniard()
                           , new BroadAxe()
                           , new LargeClub()
                           , new PeonSword()
                           , new InferiorTomahawk()
                           , new RoughBroadAxe()
                           , new SmallKnife()
                           , new SplinteredBoard()
                           , new LargeStoneMace()
                           , new AcolyteStaff()
                           , new Gladius()
                           , new TwoHandedSword()
                           , new Tomahawk()
                           , new LargeAxe()
                           , new Cudgel()
                           , new WoodenMallet()
                           , new Stiletto()
                           , new WalkingStick()
                           , new RaiderShortsword()
                           , new RustedClaymore()
                           , new SmallTomahawk()
                           , new DoubleBladedAxe()
                           , new LightHammer()
                           , new WoodenWarhammer()
                           , new ScuffedDagger()
                           , new AdeptShortStaff()
                           , new OrnateBlunderbuss()
                           , new HuntersBoomstick()
                           , new LightShot()
                           , new HeavyShot()
                           , new SmallShotPouch()
                           , new Cutlass()
                           , new Mace()
                           , new Hatchet()
                           , new QuarterStaff()
  } ;
Faction = Factions.ThunderBluff;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 2777, InventoryTypes.TwoHanded, 2, 5, 2, 1, 0, 0, 0 ));
}
}

public class Gibbert : BaseCreature 
 { 
public  Gibbert() : base() 
 { 
Model = 7218;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Gibbert" ;
Flags1 = 0x0480046 ;
Id = 3000 ; 
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
BaseHitPoints = 1825 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 49, 63 );
NpcText00 = "Greetings $N, I am Gibbert." ;
BaseMana = 0 ;
Sells = new Item[] { new Broadsword()
                           , new Flamberge()
                           , new CrescentAxe()
                           , new Bullova()
                           , new Truncheon()
                           , new WarHammer()
                           , new MainGauche()
                           , new BattleStaff()
                           , new Falchion()
                           , new Zweihander()
                           , new Francisca()
                           , new GreatAxe()
                           , new MorningStar()
                           , new WarMaul()
                           , new Rondel()
                           , new WarStaff()
  } ;
Faction = Factions.Friend;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
}
}

public class MarjakKeenblade : BaseCreature 
 { 
public  MarjakKeenblade() : base() 
 { 
Model = 3799;
AttackSpeed= 2000;
BoundingRadius = 0.974700f ;
Name = "Marjak Keenblade" ;
Flags1 = 0x08080066 ;
Id = 3073 ; 
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
NpcType = 7 ;
BaseHitPoints = 384 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 4.05f ;
SetDamage ( 9, 12 );
NpcText00 = "Greetings $N, I am Marjak Keenblade." ;
BaseMana = 0 ;
Sells = new Item[] { new BastardSword()
                           , new ScratchedClaymore()
                           , new Club()
                           , new Shortsword()
                           , new ShortStaff()
                           , new HandAxe()
                           , new Dirk()
                           , new BroadAxe()
                           , new LargeClub()
                           , new PeonSword()
                           , new InferiorTomahawk()
                           , new RoughBroadAxe()
                           , new SmallKnife()
                           , new SplinteredBoard()
                           , new LargeStoneMace()
                           , new AcolyteStaff()
  } ;
Faction = Factions.ThunderBluff;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 7419, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ));
}
}

public class MahnottRoughwound : BaseCreature 
 { 
public  MahnottRoughwound() : base() 
 { 
Model = 3802;
AttackSpeed= 2000;
BoundingRadius = 0.974700f ;
Name = "Mahnott Roughwound" ;
Flags1 = 0x08480046 ;
Id = 3077 ; 
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
NpcType = 7 ;
BaseHitPoints = 464 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 4.05f ;
SetDamage ( 11, 15 );
NpcText00 = "Greetings $N, I am Mahnott Roughwound." ;
BaseMana = 0 ;
Sells = new Item[] { new Gladius()
                           , new TwoHandedSword()
                           , new Tomahawk()
                           , new LargeAxe()
                           , new Cudgel()
                           , new WoodenMallet()
                           , new Stiletto()
                           , new WalkingStick()
                           , new RaiderShortsword()
                           , new RustedClaymore()
                           , new SmallTomahawk()
                           , new DoubleBladedAxe()
                           , new LightHammer()
                           , new WoodenWarhammer()
                           , new ScuffedDagger()
                           , new AdeptShortStaff()
  } ;
Faction = Factions.ThunderBluff;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 223866, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ));
}
}

public class KzanThornslash : BaseCreature 
 { 
public  KzanThornslash() : base() 
 { 
Model = 1883;
AttackSpeed= 2000;
BoundingRadius = 0.372000f ;
Name = "Kzan Thornslash" ;
Flags1 = 0x08080066 ;
Id = 3159 ; 
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
BaseHitPoints = 464 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 11, 15 );
NpcText00 = "Greetings $N, I am Kzan Thornslash." ;
BaseMana = 0 ;
Sells = new Item[] { new BastardSword()
                           , new ScratchedClaymore()
                           , new Club()
                           , new Shortsword()
                           , new ShortStaff()
                           , new HandAxe()
                           , new Dirk()
                           , new BroadAxe()
                           , new LargeClub()
                           , new PeonSword()
                           , new InferiorTomahawk()
                           , new RoughBroadAxe()
                           , new SmallKnife()
                           , new SplinteredBoard()
                           , new LargeStoneMace()
                           , new AcolyteStaff()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}

public class Uhgar : BaseCreature 
 { 
public  Uhgar() : base() 
 { 
Model = 3738;
AttackSpeed= 2000;
BoundingRadius = 0.372000f ;
Name = "Uhgar" ;
Flags1 = 0x08480046 ;
Id = 3163 ; 
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
NpcText00 = "Greetings $N, I am Uhgar." ;
BaseMana = 0 ;
Sells = new Item[] { new Gladius()
                           , new TwoHandedSword()
                           , new Tomahawk()
                           , new LargeAxe()
                           , new Cudgel()
                           , new WoodenMallet()
                           , new Stiletto()
                           , new WalkingStick()
                           , new RaiderShortsword()
                           , new RustedClaymore()
                           , new SmallTomahawk()
                           , new DoubleBladedAxe()
                           , new LightHammer()
                           , new WoodenWarhammer()
                           , new ScuffedDagger()
                           , new AdeptShortStaff()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7426, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ));
}
}

public class TurukAmberstill : BaseCreature 
 { 
public  TurukAmberstill() : base() 
 { 
Model = 3411;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Turuk Amberstill" ;
Flags1 = 0x08480046 ;
Id = 3177 ; 
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
NpcText00 = "Greetings $N, I am Turuk Amberstill." ;
BaseMana = 0 ;
Sells = new Item[] { new Tomahawk()
                           , new LargeAxe()
                           , new Cudgel()
                           , new WoodenMallet()
                           , new DoubleBladedAxe()
                           , new LightHammer()
                           , new WoodenWarhammer()
  } ;
Faction = Factions.IronForge;
Guild = "Weapon Merchant";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 21752, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ));
}
}

public class Urtharo : BaseCreature 
 { 
public  Urtharo() : base() 
 { 
Model = 1314;
AttackSpeed= 1739;
BoundingRadius = 0.372000f ;
Name = "Urtharo" ;
Flags1 = 0x08480046 ;
Id = 3314 ; 
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
NpcText00 = "Greetings $N, I am Urtharo." ;
BaseMana = 0 ;
Sells = new Item[] { new BastardSword()
                           , new Tabar()
                           , new GiantMace()
                           , new Claymore()
                           , new ScratchedClaymore()
                           , new Club()
                           , new Shortsword()
                           , new ShortStaff()
                           , new HandAxe()
                           , new Dirk()
                           , new Jambiya()
                           , new BroadAxe()
                           , new LargeClub()
                           , new PeonSword()
                           , new InferiorTomahawk()
                           , new RoughBroadAxe()
                           , new SmallKnife()
                           , new SplinteredBoard()
                           , new LargeStoneMace()
                           , new AcolyteStaff()
                           , new Gladius()
                           , new TwoHandedSword()
                           , new Tomahawk()
                           , new LargeAxe()
                           , new Cudgel()
                           , new WoodenMallet()
                           , new Stiletto()
                           , new WalkingStick()
                           , new RustedClaymore()
                           , new SmallTomahawk()
                           , new DoubleBladedAxe()
                           , new LightHammer()
                           , new WoodenWarhammer()
                           , new ScuffedDagger()
                           , new Cutlass()
                           , new Mace()
                           , new Hatchet()
                           , new QuarterStaff()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 19549, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ));
}
}

public class Shoma : BaseCreature 
 { 
public  Shoma() : base() 
 { 
Model = 1383;
AttackSpeed= 1739;
BoundingRadius = 0.372000f ;
Name = "Shoma" ;
Flags1 = 0x08480046 ;
Id = 3361 ; 
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
NpcText00 = "Greetings $N, I am Shoma." ;
BaseMana = 0 ;
Sells = new Item[] { new Claymore()
                           , new RightHandedClaw()
                           , new RightHandedBlades()
                           , new RightHandedBrassKnuckles()
                           , new LeftHandedBrassKnuckles()
                           , new LeftHandedClaw()
                           , new LeftHandedBlades()
                           , new Espadon()
                           , new Scimitar()
                           , new Jambiya()
                           , new Poniard()
                           , new Kris()
                           , new Broadsword()
                           , new MainGauche()
                           , new Falchion()
                           , new Rondel()
                           , new Cutlass()
                           , new DacianFalx()
                           , new Longsword()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7485, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ));
}
}

public class Zendojian : BaseCreature 
 { 
public  Zendojian() : base() 
 { 
Model = 4363;
AttackSpeed= 1739;
BoundingRadius = 0.306000f ;
Name = "Zendo'jian" ;
Flags1 = 0x08480046 ;
Id = 3409 ; 
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
NpcFlags = 17 ;
CombatReach = 1.5f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Zendo'jian." ;
BaseMana = 0 ;
Sells = new Item[] { new MediumQuiver()
                           , new Tabar()
                           , new GleamingThrowingAxe()
                           , new WickedThrowingDagger()
                           , new BeardedAxe()
                           , new Cleaver()
                           , new GnarledStaff()
                           , new WalkingStick()
                           , new LaminatedRecurveBow()
                           , new RoughArrow()
                           , new SharpArrow()
                           , new BalancedThrowingDagger()
                           , new SmallThrowingKnife()
                           , new ReinforcedBow()
                           , new KeenThrowingKnife()
                           , new HeavyThrowingDagger()
                           , new CrudeThrowingAxe()
                           , new WeightedThrowingAxe()
                           , new SharpThrowingAxe()
                           , new DeadlyThrowingAxe()
                           , new SmallQuiver()
                           , new Hatchet()
                           , new QuarterStaff()
                           , new BattleAxe()
                           , new DoubleAxe()
                           , new LongStaff()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7426, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ));
}
}

public class NargalDeatheye : BaseCreature 
 { 
public  NargalDeatheye() : base() 
 { 
Model = 3869;
AttackSpeed= 2000;
BoundingRadius = 0.372000f ;
Name = "Nargal Deatheye" ;
Flags1 = 0x08480046 ;
Id = 3479 ; 
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
NpcText00 = "Greetings $N, I am Nargal Deatheye." ;
BaseMana = 0 ;
Sells = new Item[] { new Tabar()
                           , new GiantMace()
                           , new Claymore()
                           , new Jambiya()
                           , new EnamelledBroadsword()
                           , new FeralBlade()
                           , new Cutlass()
                           , new Mace()
                           , new Hatchet()
                           , new QuarterStaff()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 19550, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ));
}
}

public class Ironzar : BaseCreature 
 { 
public  Ironzar() : base() 
 { 
Model = 7093;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Ironzar" ;
Flags1 = 0x08080006 ;
Id = 3491 ; 
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
Level = RandomLevel( 23 );
NpcType = 7 ;
BaseHitPoints = 1024 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 27, 35 );
NpcText00 = "Greetings $N, I am Ironzar." ;
BaseMana = 0 ;
Sells = new Item[] { new Espadon()
                           , new BeardedAxe()
                           , new RockHammer()
                           , new Scimitar()
                           , new Hammer()
                           , new Cleaver()
                           , new GnarledStaff()
                           , new Poniard()
                           , new IridescentPearl()
  } ;
Faction = Factions.Ratchet;
Guild = "Weapon Merchant";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7439, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ),  new Item( 19555, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
}
}

public class WallacetheBlind : BaseCreature 
 { 
public  WallacetheBlind() : base() 
 { 
Model = 3552;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Wallace the Blind" ;
Flags1 = 0x066 ;
Id = 3534 ; 
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
BaseHitPoints = 784 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 20, 26 );
NpcText00 = "Greetings $N, I am Wallace the Blind." ;
BaseMana = 0 ;
Sells = new Item[] { new FineLongbow()
                           , new Tabar()
                           , new GiantMace()
                           , new Claymore()
                           , new Jambiya()
                           , new IronwoodMaul()
                           , new HeavySpikedMace()
                           , new BlessedClaymore()
                           , new ExecutionersSword()
                           , new Cutlass()
                           , new Mace()
                           , new Hatchet()
                           , new QuarterStaff()
                           , new HealingPotion()
  } ;
Faction = Factions.Friend;
Guild = "Weapon Merchant";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}

public class Ott : BaseCreature 
 { 
public  Ott() : base() 
 { 
Model = 3673;
AttackSpeed= 2000;
BoundingRadius = 0.372000f ;
Name = "Ott" ;
Flags1 = 0x08480046 ;
Id = 3539 ; 
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
NpcText00 = "Greetings $N, I am Ott." ;
BaseMana = 0 ;
Sells = new Item[] { new BroadBladedKnife()
                           , new MercilessAxe()
                           , new Kris()
                           , new ExecutorStaff()
                           , new BlessedClaymore()
                           , new ExecutionersSword()
                           , new BlurredAxe()
                           , new CallousAxe()
                           , new MarauderAxe()
                           , new DacianFalx()
                           , new Longsword()
                           , new Maul()
                           , new Flail()
                           , new BattleAxe()
                           , new DoubleAxe()
                           , new LongStaff()
  } ;
Faction = Factions.Ogrimmar;
Guild = "Weapon Merchant";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 19549, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ));
}
}


public class Shalomon : BaseCreature 
 { 
public  Shalomon() : base() 
 { 
Model = 1712;
AttackSpeed= 2000;
BoundingRadius = 0.389000f ;
Name = "Shalomon" ;
Flags1 = 0x08480046 ;
Id = 3609 ; 
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
BaseHitPoints = 1625 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 43, 56 );
NpcText00 = "Greetings $N, I am Shalomon." ;
BaseMana = 0 ;
Sells = new Item[] { new Gladius()
                           , new TwoHandedSword()
                           , new Tomahawk()
                           , new LargeAxe()
                           , new Cudgel()
                           , new WoodenMallet()
                           , new Stiletto()
                           , new WalkingStick()
  } ;
Faction = Factions.Darnasus;
Guild = "Weapon Merchant";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 7439, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ));
}
}

public class Lizzarik : BaseCreature 
 { 
public  Lizzarik() : base() 
 { 
Model = 7057;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Lizzarik" ;
Flags1 = 0x08080006 ;
Id = 3658 ; 
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
BaseHitPoints = 1024 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 27, 35 );
NpcText00 = "Greetings $N, I am Lizzarik." ;
BaseMana = 0 ;
Sells = new Item[] { new Tabar()
                           , new GiantMace()
                           , new Claymore()
                           , new Jambiya()
                           , new MinorManaPotion()
                           , new EnamelledBroadsword()
                           , new FeralBlade()
                           , new IronwoodMaul()
                           , new HeavySpikedMace()
                           , new Cutlass()
                           , new Mace()
                           , new Hatchet()
                           , new QuarterStaff()
                           , new LesserHealingPotion()
  } ;
Faction = Factions.Ratchet;
Guild = "Weapon Merchant";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 6441, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
}
}

public class VrangWildgore : BaseCreature 
 { 
public  VrangWildgore() : base() 
 { 
Model = 3878;
AttackSpeed= 2000;
BoundingRadius = 0.372000f ;
Name = "Vrang Wildgore" ;
Flags1 = 0x08400046 ;
Id = 3682 ; 
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
Level = RandomLevel( 48 );
NpcType = 7 ;
BaseHitPoints = 1945 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 52, 67 );
NpcText00 = "Greetings $N, I am Vrang Wildgore." ;
BaseMana = 0 ;
Sells = new Item[] { new ScalemailBracers()
                           , new ScalemailBelt()
                           , new HaunchOfMeat()
                           , new ScalemailVest()
                           , new ScalemailPants()
                           , new ScalemailBoots()
                           , new EnamelledBroadsword()
                           , new FeralBlade()
                           , new IronwoodMaul()
                           , new HeavySpikedMace()
                           , new FieryCloak()
                           , new HeavyRunedCloak()
                           , new AntiquatedCloak()
                           , new MightyChainPants()
                           , new LegionnairesLeggings()
                           , new ScalemailGloves()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
}
}

public class Galthuk : BaseCreature 
 { 
public  Galthuk() : base() 
 { 
Model = 4612;
AttackSpeed= 1739;
BoundingRadius = 0.409200f ;
Name = "Galthuk" ;
Flags1 = 0x08480046 ;
Id = 4043 ; 
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
NpcType = 7 ;
BaseHitPoints = 344 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.65f ;
SetDamage ( 8, 11 );
NpcText00 = "Greetings $N, I am Galthuk." ;
BaseMana = 0 ;
Sells = new Item[] { new Flamberge()
                           , new Bullova()
                           , new WarHammer()
                           , new Zweihander()
                           , new GreatAxe()
                           , new WarMaul()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 7439, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ));
}
}

public class EalyshiaDewwhisper : BaseCreature 
 { 
public  EalyshiaDewwhisper() : base() 
 { 
Model = 2229;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Ealyshia Dewwhisper" ;
Flags1 = 0x08480046 ;
Id = 4180 ; 
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
NpcText00 = "Greetings $N, I am Ealyshia Dewwhisper." ;
BaseMana = 0 ;
Sells = new Item[] { new Flamberge()
                           , new Bullova()
                           , new WarHammer()
                           , new Zweihander()
                           , new GreatAxe()
                           , new WarMaul()
  } ;
Faction = Factions.Darnasus;
Guild = "Weapon Merchant";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
Equip( new Item( 7491, InventoryTypes.MainGauche, 2, 8, 1, 1, 0, 0, 0 ));
}
}

public class NaramLongclaw : BaseCreature 
 { 
public  NaramLongclaw() : base() 
 { 
Model = 4408;
AttackSpeed= 2000;
BoundingRadius = 0.389000f ;
Name = "Naram Longclaw" ;
Flags1 = 0x08480046 ;
Id = 4183 ; 
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
NpcText00 = "Greetings $N, I am Naram Longclaw." ;
BaseMana = 0 ;
Sells = new Item[] { new Tabar()
                           , new GiantMace()
                           , new Claymore()
                           , new Jambiya()
                           , new Cutlass()
                           , new Mace()
                           , new Hatchet()
                           , new QuarterStaff()
  } ;
Faction = Factions.Darnasus;
Guild = "Weapon Merchant";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7441, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ),new Item( 22671, InventoryTypes.Back, 2, 16, 1, 3, 0, 0, 0 ));
}
}

public class AriyellSkyshadow : BaseCreature 
 { 
public  AriyellSkyshadow() : base() 
 { 
Model = 2221;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Ariyell Skyshadow" ;
Flags1 = 0x08480046 ;
Id = 4203 ; 
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
NpcText00 = "Greetings $N, I am Ariyell Skyshadow." ;
BaseMana = 0 ;
Sells = new Item[] { new MediumQuiver()
                           , new Tabar()
                           , new GiantMace()
                           , new Claymore()
                           , new GleamingThrowingAxe()
                           , new WickedThrowingDagger()
                           , new RightHandedClaw()
                           , new RightHandedBlades()
                           , new RightHandedBrassKnuckles()
                           , new LeftHandedBrassKnuckles()
                           , new LeftHandedClaw()
                           , new LeftHandedBlades()
                           , new Espadon()
                           , new BeardedAxe()
                           , new RockHammer()
                           , new Scimitar()
                           , new Hammer()
                           , new Cleaver()
                           , new GnarledStaff()
                           , new Jambiya()
                           , new Poniard()
                           , new Kris()
                           , new LaminatedRecurveBow()
                           , new RoughArrow()
                           , new SharpArrow()
                           , new BalancedThrowingDagger()
                           , new SmallThrowingKnife()
                           , new ReinforcedBow()
                           , new KeenThrowingKnife()
                           , new HeavyThrowingDagger()
                           , new CrudeThrowingAxe()
                           , new WeightedThrowingAxe()
                           , new SharpThrowingAxe()
                           , new DeadlyThrowingAxe()
                           , new SmallQuiver()
                           , new Cutlass()
                           , new Mace()
                           , new Hatchet()
                           , new QuarterStaff()
                           , new DacianFalx()
                           , new Longsword()
                           , new Maul()
                           , new Flail()
                           , new BattleAxe()
                           , new DoubleAxe()
                           , new LongStaff()
  } ;
Faction = Factions.Darnasus;
Guild = "Weapon Merchant";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7483, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ));
}
}

public class Kieran : BaseCreature 
 { 
public  Kieran() : base() 
 { 
Model = 2258;
AttackSpeed= 2000;
BoundingRadius = 0.389000f ;
Name = "Kieran" ;
Flags1 = 0x08480046 ;
Id = 4231 ; 
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
NpcText00 = "Greetings $N, I am Kieran." ;
BaseMana = 0 ;
Sells = new Item[] { new BastardSword()
                           , new Tabar()
                           , new GiantMace()
                           , new Claymore()
                           , new Espadon()
                           , new BeardedAxe()
                           , new RockHammer()
                           , new Scimitar()
                           , new Hammer()
                           , new Cleaver()
                           , new GnarledStaff()
                           , new Club()
                           , new Shortsword()
                           , new ShortStaff()
                           , new HandAxe()
                           , new Dirk()
                           , new Jambiya()
                           , new Poniard()
                           , new BroadAxe()
                           , new LargeClub()
                           , new Gladius()
                           , new TwoHandedSword()
                           , new Tomahawk()
                           , new LargeAxe()
                           , new Cudgel()
                           , new WoodenMallet()
                           , new Stiletto()
                           , new WalkingStick()
                           , new Cutlass()
                           , new Mace()
                           , new Hatchet()
                           , new QuarterStaff()
  } ;
Faction = Factions.Darnasus;
Guild = "Weapon Merchant";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7487, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ));
}
}

public class Turian : BaseCreature 
 { 
public  Turian() : base() 
 { 
Model = 2271;
AttackSpeed= 2000;
BoundingRadius = 0.389000f ;
Name = "Turian" ;
Flags1 = 0x08480006 ;
Id = 4235 ; 
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
NpcText00 = "Greetings $N, I am Turian." ;
BaseMana = 0 ;
Sells = new Item[] { new BroadBladedKnife()
                           , new GleamingThrowingAxe()
                           , new WickedThrowingDagger()
                           , new BalancedThrowingDagger()
                           , new SmallThrowingKnife()
                           , new KeenThrowingKnife()
                           , new HeavyThrowingDagger()
                           , new CrudeThrowingAxe()
                           , new WeightedThrowingAxe()
                           , new SharpThrowingAxe()
                           , new DeadlyThrowingAxe()
  } ;
Faction = Factions.Darnasus;
Guild = "Weapon Merchant";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7434, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
}
}

public class GordonWendham : BaseCreature 
 { 
public  GordonWendham() : base() 
 { 
Model = 2629;
AttackSpeed= 2000;
BoundingRadius = 0.383000f ;
Name = "Gordon Wendham" ;
Flags1 = 0x018480046 ;
Id = 4556 ; 
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
NpcText00 = "Greetings $N, I am Gordon Wendham." ;
BaseMana = 0 ;
Sells = new Item[] { new BastardSword()
                           , new ScratchedClaymore()
                           , new Club()
                           , new Shortsword()
                           , new ShortStaff()
                           , new HandAxe()
                           , new Dirk()
                           , new BroadAxe()
                           , new LargeClub()
                           , new PeonSword()
                           , new InferiorTomahawk()
                           , new RoughBroadAxe()
                           , new SmallKnife()
                           , new SplinteredBoard()
                           , new LargeStoneMace()
                           , new AcolyteStaff()
                           , new Gladius()
                           , new TwoHandedSword()
                           , new Tomahawk()
                           , new LargeAxe()
                           , new Cudgel()
                           , new WoodenMallet()
                           , new Stiletto()
                           , new WalkingStick()
                           , new RaiderShortsword()
                           , new RustedClaymore()
                           , new SmallTomahawk()
                           , new DoubleBladedAxe()
                           , new LightHammer()
                           , new WoodenWarhammer()
                           , new ScuffedDagger()
                           , new AdeptShortStaff()
  } ;
Faction = Factions.Undercity;
Guild = "Weapon Merchant";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7434, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ));
}
}

public class FrastDokner : BaseCreature 
 { 
public  FrastDokner() : base() 
 { 
Model = 3426;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Frast Dokner" ;
Flags1 = 0x08480046 ;
Id = 1698 ; 
Guild = "Apprentice Weaponsmith";
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
NpcText00 = "Greetings $N, I am Frast Dokner." ;
BaseMana = 0 ;
Sells = new Item[] { new Gladius()
                           , new TwoHandedSword()
                           , new Tomahawk()
                           , new LargeAxe()
                           , new Cudgel()
                           , new WoodenMallet()
                           , new Stiletto()
                           , new WalkingStick()
  } ;
Faction = Factions.IronForge;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 7428, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ), new Item( 2080, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
}
}
public class LouisWarren : BaseCreature 
 { 
public  LouisWarren() : base() 
 { 
Model = 2636;
AttackSpeed= 2000;
BoundingRadius = 0.383000f ;
Name = "Louis Warren" ;
Flags1 = 0x018480046 ;
Id = 4557 ; 
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
NpcText00 = "Greetings $N, I am Louis Warren." ;
BaseMana = 0 ;
Sells = new Item[] { new Tabar()
                           , new GiantMace()
                           , new Claymore()
                           , new Espadon()
                           , new BeardedAxe()
                           , new RockHammer()
                           , new Scimitar()
                           , new Hammer()
                           , new Cleaver()
                           , new GnarledStaff()
                           , new Jambiya()
                           , new Poniard()
                           , new Cutlass()
                           , new Mace()
                           , new Hatchet()
                           , new QuarterStaff()
  } ;
Faction = Factions.Undercity;
Guild = "Weapon Merchant";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7428, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ));
}
}

public class NathanielSteenwick : BaseCreature 
 { 
public  NathanielSteenwick() : base() 
 { 
Model = 2642;
AttackSpeed= 2000;
BoundingRadius = 0.383000f ;
Name = "Nathaniel Steenwick" ;
Flags1 = 0x018480046 ;
Id = 4592 ; 
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
NpcText00 = "Greetings $N, I am Nathaniel Steenwick." ;
BaseMana = 0 ;
Sells = new Item[] { new GleamingThrowingAxe()
                           , new WickedThrowingDagger()
                           , new BalancedThrowingDagger()
                           , new SmallThrowingKnife()
                           , new KeenThrowingKnife()
                           , new HeavyThrowingDagger()
                           , new CrudeThrowingAxe()
                           , new WeightedThrowingAxe()
                           , new SharpThrowingAxe()
                           , new DeadlyThrowingAxe()
  } ;
Faction = Factions.Undercity;
Guild = "Weapon Merchant";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7434, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
}
}

public class GeoffreyHartwell : BaseCreature 
 { 
public  GeoffreyHartwell() : base() 
 { 
Model = 2628;
AttackSpeed= 2000;
BoundingRadius = 0.383000f ;
Name = "Geoffrey Hartwell" ;
Flags1 = 0x018480046 ;
Id = 4600 ; 
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
NpcText00 = "Greetings $N, I am Geoffrey Hartwell." ;
BaseMana = 0 ;
Sells = new Item[] { new Broadsword()
                           , new Flamberge()
                           , new Bullova()
                           , new WarHammer()
                           , new MainGauche()
                           , new Falchion()
                           , new Zweihander()
                           , new GreatAxe()
                           , new WarMaul()
                           , new Rondel()
  } ;
Faction = Factions.Undercity;
Guild = "Weapon Merchant";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7483, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ));
}
}

public class FrancisEliot : BaseCreature 
 { 
public  FrancisEliot() : base() 
 { 
Model = 2627;
AttackSpeed= 2000;
BoundingRadius = 0.383000f ;
Name = "Francis Eliot" ;
Flags1 = 0x018480046 ;
Id = 4601 ; 
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
NpcText00 = "Greetings $N, I am Francis Eliot." ;
BaseMana = 0 ;
Sells = new Item[] { new Tabar()
                           , new ShortSpear()
                           , new HeavySpear()
                           , new BeardedAxe()
                           , new Cleaver()
                           , new Hatchet()
                           , new BattleAxe()
                           , new DoubleAxe()
  } ;
Faction = Factions.Undercity;
Guild = "Weapon Merchant";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7428, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ));
}
}

public class BenijahFenner : BaseCreature 
 { 
public  BenijahFenner() : base() 
 { 
Model = 2616;
AttackSpeed= 2000;
BoundingRadius = 0.383000f ;
Name = "Benijah Fenner" ;
Flags1 = 0x018480046 ;
Id = 4602 ; 
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
NpcText00 = "Greetings $N, I am Benijah Fenner." ;
BaseMana = 0 ;
Sells = new Item[] { new MediumQuiver()
                           , new GiantMace()
                           , new LightCrossbow()
                           , new FineLightCrossbow()
                           , new HeavyCrossbow()
                           , new RockHammer()
                           , new Hammer()
                           , new GnarledStaff()
                           , new LightQuiver()
                           , new RoughArrow()
                           , new SharpArrow()
                           , new RazorArrow()
                           , new HeavyQuiver()
                           , new Mace()
                           , new QuarterStaff()
                           , new Maul()
                           , new Flail()
                           , new LongStaff()
  } ;
Faction = Factions.Undercity;
Guild = "Weapon Merchant";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7478, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ));
}
}

public class Zulrg : BaseCreature 
 { 
public  Zulrg() : base() 
 { 
Model = 10704;
AttackSpeed= 2000;
BoundingRadius = 1.294850f ;
Name = "Zulrg" ;
Flags1 = 0x08400046 ;
Id = 4884 ; 
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
CombatReach = 2.175f ;
SetDamage ( 47, 60 );
NpcText00 = "Greetings $N, I am Zulrg." ;
BaseMana = 0 ;
Sells = new Item[] { new MidnightAxe()
                           , new BigStick()
                           , new Broadsword()
                           , new Flamberge()
                           , new CrescentAxe()
                           , new Bullova()
                           , new Truncheon()
                           , new WarHammer()
                           , new MainGauche()
                           , new BattleStaff()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
}
}

public class MarieHoldston : BaseCreature 
 { 
public  MarieHoldston() : base() 
 { 
Model = 4859;
AttackSpeed= 2000;
BoundingRadius = 0.208000f ;
Name = "Marie Holdston" ;
Flags1 = 0x08480046 ;
Id = 4888 ; 
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
NpcText00 = "Greetings $N, I am Marie Holdston." ;
BaseMana = 0 ;
Sells = new Item[] { new DaringDirk()
                           , new MidnightAxe()
                           , new Broadsword()
                           , new Flamberge()
                           , new CrescentAxe()
                           , new Bullova()
                           , new Truncheon()
                           , new WarHammer()
                           , new MainGauche()
                           , new BattleStaff()
  } ;
Faction = Factions.Stormwind;
Guild = "Weapon Merchant";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 7439, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ), new Item( 24295, InventoryTypes.HeldInHand, 4, 0, 2, 0, 0, 0, 0 ));
}
}

public class PiterVerance : BaseCreature 
 { 
public  PiterVerance() : base() 
 { 
Model = 4833;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Piter Verance" ;
Flags1 = 0x08480046 ;
Id = 4890 ; 
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
NpcText00 = "Greetings $N, I am Piter Verance." ;
BaseMana = 0 ;
Sells = new Item[] { new BlessedClaymore()
                           , new ExecutionersSword()
                           , new BlurredAxe()
                           , new CallousAxe()
                           , new MarauderAxe()
                           , new SaberLeggings()
                           , new StalkingPants()
                           , new MysticSarong()
                           , new GloriousShoulders()
                           , new EliteShoulders()
  } ;
Faction = Factions.Stormwind;
Guild = "Weapon Merchant";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 5176, InventoryTypes.TwoHanded, 2, 8, 1, 1, 0, 0, 0 ));
}
}

public class DolmanSteelfury : BaseCreature 
 { 
public  DolmanSteelfury() : base() 
 { 
Model = 3042;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Dolman Steelfury" ;
Flags1 = 0x08480046 ;
Id = 5102 ; 
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
NpcText00 = "Greetings $N, I am Dolman Steelfury." ;
BaseMana = 0 ;
Sells = new Item[] { new BastardSword()
                           , new Club()
                           , new Shortsword()
                           , new ShortStaff()
                           , new HandAxe()
                           , new Dirk()
                           , new BroadAxe()
                           , new LargeClub()
                           , new Gladius()
                           , new TwoHandedSword()
                           , new Tomahawk()
                           , new LargeAxe()
                           , new Cudgel()
                           , new WoodenMallet()
                           , new Stiletto()
                           , new WalkingStick()
  } ;
Faction = Factions.IronForge;
Guild = "Weapon Merchant";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7487, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ));
}
}

public class GrenilSteelfury : BaseCreature 
 { 
public  GrenilSteelfury() : base() 
 { 
Model = 3043;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Grenil Steelfury" ;
Flags1 = 0x08480046 ;
Id = 5103 ; 
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
NpcText00 = "Greetings $N, I am Grenil Steelfury." ;
BaseMana = 0 ;
Sells = new Item[] { new Tabar()
                           , new GiantMace()
                           , new Claymore()
                           , new Espadon()
                           , new BeardedAxe()
                           , new RockHammer()
                           , new Scimitar()
                           , new Hammer()
                           , new Cleaver()
                           , new GnarledStaff()
                           , new Jambiya()
                           , new Poniard()
                           , new Cutlass()
                           , new Mace()
                           , new Hatchet()
                           , new QuarterStaff()
  } ;
Faction = Factions.IronForge;
Guild = "Weapon Merchant";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7426, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ));
}
}

public class Bingus : BaseCreature 
 { 
public  Bingus() : base() 
 { 
Model = 3110;
AttackSpeed= 2000;
BoundingRadius = 0.351900f ;
Name = "Bingus" ;
Flags1 = 0x08480046 ;
Id = 5152 ; 
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
NpcText00 = "Greetings $N, I am Bingus." ;
BaseMana = 0 ;
Sells = new Item[] { new Truncheon()
                           , new WarHammer()
                           , new BattleStaff()
                           , new MorningStar()
                           , new WarMaul()
                           , new WarStaff()
  } ;
Faction = Factions.GnomereganExiles;
Guild = "Weapon Merchant";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 5098, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
}
}

public class ThalgusThunderfist : BaseCreature 
 { 
public  ThalgusThunderfist() : base() 
 { 
Model = 7120;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Thalgus Thunderfist" ;
Flags1 = 0x08480046 ;
Id = 7976 ; 
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
NpcText00 = "Greetings $N, I am Thalgus Thunderfist." ;
BaseMana = 0 ;
Sells = new Item[] { new MediumQuiver()
                           , new LightCrossbow()
                           , new FineLightCrossbow()
                           , new HeavyCrossbow()
                           , new RightHandedClaw()
                           , new RightHandedBlades()
                           , new RightHandedBrassKnuckles()
                           , new LeftHandedBrassKnuckles()
                           , new LeftHandedClaw()
                           , new LeftHandedBlades()
                           , new LightQuiver()
                           , new OrnateBlunderbuss()
                           , new HuntersBoomstick()
                           , new RoughArrow()
                           , new SharpArrow()
                           , new LightShot()
                           , new HeavyShot()
                           , new Flamberge()
                           , new Bullova()
                           , new WarHammer()
                           , new Zweihander()
                           , new GreatAxe()
                           , new WarMaul()
                           , new RazorArrow()
                           , new SmallShotPouch()
                           , new HeavyQuiver()
  } ;
Faction = Factions.IronForge;
Guild = "Weapon Merchant";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 6593, InventoryTypes.RangeRight, 2, 3, 1, 0, 0, 0, 0 ));
}
}

public class Ohanko : BaseCreature 
 { 
public  Ohanko() : base() 
 { 
Model = 10689;
AttackSpeed= 2000;
BoundingRadius = 0.974700f ;
Name = "Ohanko" ;
Flags1 = 0x08480046 ;
Id = 8398 ; 
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
CombatReach = 4.05f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Ohanko." ;
BaseMana = 0 ;
Sells = new Item[] { new Flamberge()
                           , new Bullova()
                           , new WarHammer()
                           , new Zweihander()
                           , new GreatAxe()
                           , new WarMaul()
  } ;
Faction = Factions.ThunderBluff;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 23379, InventoryTypes.TwoHanded, 2, 8, 1, 1, 0, 0, 0 ));
}
}

public class GruulDarkblade : BaseCreature 
 { 
public  GruulDarkblade() : base() 
 { 
Model = 9761;
AttackSpeed= 2000;
BoundingRadius = 0.372000f ;
Name = "Gruul Darkblade" ;
Flags1 = 0x08480006 ;
Id = 10361 ; 
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
BaseHitPoints = 0 ;
NpcFlags = 02004 ;
CombatReach = 1.5f ;
SetDamage ( 45, 62 );
NpcText00 = "Hello" ;
BaseMana = 0 ;
Sells = new Item[] { new Falchion()
                           , new Zweihander()
                           , new Francisca()
                           , new GreatAxe()
                           , new MorningStar()
                           , new WarMaul()
                           , new Rondel()
                           , new WarStaff()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
Equip( new Item( 7442, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ));
}
}

public class Trayexir : BaseCreature 
 { 
public  Trayexir() : base() 
 { 
Model = 9768;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Trayexir" ;
Flags1 = 0x08480046 ;
Id = 10369 ; 
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
NpcText00 = "Greetings $N, I am Trayexir." ;
BaseMana = 0 ;
Sells = new Item[] { new MediumQuiver()
                           , new Gladius()
                           , new TwoHandedSword()
                           , new Tomahawk()
                           , new LargeAxe()
                           , new Cudgel()
                           , new WoodenMallet()
                           , new Stiletto()
                           , new WalkingStick()
                           , new HornwoodRecurveBow()
                           , new LaminatedRecurveBow()
                           , new RoughArrow()
                           , new SharpArrow()
                           , new SmallQuiver()
  } ;
Faction = Factions.DarkspearTrolls;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 6234, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ));
}
}

public class AltsobaRagetotem : BaseCreature 
 { 
public  AltsobaRagetotem() : base() 
 { 
Model = 9770;
AttackSpeed= 1554;
BoundingRadius = 1.00f ;
Name = "Altsoba Ragetotem" ;
Flags1 = 0x08480046 ;
Id = 10379 ; 
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
CombatReach = 11.00f ;
SetDamage ( 43, 56 );
NpcText00 = "Greetings $N, I am Altsoba Ragetotem." ;
BaseMana = 2004 ;
Sells = new Item[] { new CrescentAxe()
                           , new Bullova()
                           , new Truncheon()
                           , new WarHammer()
                           , new BattleStaff()
                           , new Francisca()
                           , new GreatAxe()
                           , new MorningStar()
                           , new WarMaul()
                           , new WarStaff()
  } ;
Faction = Factions.ThunderBluff;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
}
}

public class Xaiander : BaseCreature 
 { 
public  Xaiander() : base() 
 { 
Model = 10636;
AttackSpeed= 2000;
BoundingRadius = 0.389000f ;
Name = "Xai'ander" ;
Flags1 = 0x08480046 ;
Id = 11137 ; 
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
NpcText00 = "Greetings $N, I am Xai'ander." ;
BaseMana = 0 ;
Sells = new Item[] { new Kris()
                           , new Broadsword()
                           , new Flamberge()
                           , new CrescentAxe()
                           , new Bullova()
                           , new Truncheon()
                           , new WarHammer()
                           , new MainGauche()
                           , new BattleStaff()
                           , new DacianFalx()
                           , new Longsword()
                           , new Maul()
                           , new Flail()
                           , new BattleAxe()
                           , new DoubleAxe()
                           , new LongStaff()
  } ;
Faction = Factions.Darnasus;
Guild = "Weapon Merchant";
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}

public class BorgoshCorebender : BaseCreature 
 { 
public  BorgoshCorebender() : base() 
 { 
Model = 10697;
AttackSpeed= 1739;
BoundingRadius = 0.372000f ;
Name = "Borgosh Corebender" ;
Flags1 = 0x0480006 ;
Id = 11178 ; 
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
NpcFlags = 18 ;
CombatReach = 1.5f ;
SetDamage ( 55, 72 );
NpcText00 = "Greetings $N, I am Borgosh Corebender." ;
BaseMana = 0 ;
Sells = new Item[] { new Kris()
                           , new Broadsword()
                           , new Flamberge()
                           , new CrescentAxe()
                           , new Bullova()
                           , new Truncheon()
                           , new WarHammer()
                           , new MainGauche()
                           , new BattleStaff()
                           , new DacianFalx()
                           , new Longsword()
                           , new Maul()
                           , new Flail()
                           , new BattleAxe()
                           , new DoubleAxe()
                           , new LongStaff()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
Equip( new Item( 7439, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ));
}
}

public class Wixxrak : BaseCreature 
 { 
public  Wixxrak() : base() 
 { 
Model = 10741;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Wixxrak" ;
Flags1 = 0x08080006 ;
Id = 11184 ; 
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
NpcType = 7 ;
BaseHitPoints = 2145 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 58, 75 );
NpcText00 = "Greetings $N, I am Wixxrak." ;
BaseMana = 0 ;
Sells = new Item[] { new AccurateSlugs()
                           , new LightShot()
                           , new HeavyShot()
                           , new Falchion()
                           , new Zweihander()
                           , new Francisca()
                           , new GreatAxe()
                           , new MorningStar()
                           , new WarMaul()
                           , new Rondel()
                           , new WarStaff()
                           , new LargeBoreBlunderbuss()
                           , new BKP2700Enforcer()
                           , new BKP42Ultra()
                           , new SolidShot()
  } ;
Faction = Factions.Everlook;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
Equip( new Item( 20504, InventoryTypes.RangeRight, 2, 3, 1, 0, 0, 0, 0 ));
}
}

public class Meliri : BaseCreature 
 { 
public  Meliri() : base() 
 { 
Model = 12031;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Meliri" ;
Flags1 = 0x08080046 ;
Id = 12024 ; 
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
NpcText00 = "Greetings $N, I am Meliri." ;
BaseMana = 0 ;
Sells = new Item[] { new Falchion()
                           , new Zweihander()
                           , new Francisca()
                           , new GreatAxe()
                           , new MorningStar()
                           , new WarMaul()
                           , new Rondel()
                           , new WarStaff()
  } ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
}
}

public class CaptainONeal : BaseCreature 
 { 
public  CaptainONeal() : base() 
 { 
Model = 0;
AttackSpeed= 0;
BoundingRadius = 0.51f ;
Name = "Captain O'Neal" ;
Flags1 = 0x0 ;
Id = 12782 ; 
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
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 0f ;
SetDamage ( 45, 62 );
NpcText00 = "Hello" ;
BaseMana = 0 ;
Sells = new Item[] { new GrandMarshalsAegis()
                           , new GrandMarshalsLongsword()
                           , new GrandMarshalsHandaxe()
                           , new GrandMarshalsSunderer()
                           , new GrandMarshalsBullseye()
                           , new GrandMarshalsRepeater()
                           , new GrandMarshalsDirk()
                           , new GrandMarshalsRightHandBlade()
                           , new GrandMarshalsLeftHandBlade()
                           , new GrandMarshalsHandCannon ()
                           , new GrandMarshalsPunisher()
                           , new GrandMarshalsBattleHammer()
                           , new GrandMarshalsGlaive()
                           , new GrandMarshalsStave()
                           , new GrandMarshalsClaymore()
  } ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
}
}

public class SergeantThunderhorn : BaseCreature 
 { 
public  SergeantThunderhorn() : base() 
 { 
Model = 0;
AttackSpeed= 0;
BoundingRadius = 0.51f ;
Name = "Sergeant Thunderhorn" ;
Flags1 = 0x0 ;
Id = 14581 ; 
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
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 0f ;
SetDamage ( 45, 62 );
NpcText00 = "Hello" ;
BaseMana = 0 ;
Sells = new Item[] { new HighWarlordsBlade()
                           , new HighWarlordsShieldWall()
                           , new HighWarlordsCleaver()
                           , new HighWarlordsBattleAxe()
                           , new HighWarlordsRecurve()
                           , new HighWarlordsCrossbow()
                           , new HighWarlordsRazor()
                           , new HighWarlordsRightClaw()
                           , new HighWarlordsLeftClaw ()
                           , new HighWarlordsStreetSweeper()
                           , new HighWarlordsBludgeon()
                           , new HighWarlordsPulverizer()
                           , new HighWarlordsPigSticker()
                           , new HighWarlordsWarStaff()
                           , new HighWarlordsGreatsword()
  } ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
}
}


public class JanosHammerknuckle : BaseCreature 
 { 
public  JanosHammerknuckle() : base() 
 { 
Model = 3275;
AttackSpeed= 2000;
BoundingRadius = 0.51f ;
Name = "Janos Hammerknuckle" ;
Guild="Weaponsmith";
Flags1 = 0x08080066 ;
Id = 78 ; 
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
NpcType = 7 ;
BaseHitPoints = 0 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 0f ;
SetDamage ( 4, 6);
NpcText00 = "Hello" ;
BaseMana = 0 ;
Sells = new Item[] { new BastardSword()
                           , new BroadAxe()
                           , new Club()
                           , new Dirk()
                           , new HandAxe()
                           , new LargeClub()
                           , new ShortStaff ()
                           , new Shortsword()
} ;
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Equip( new Item( 7439, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ));
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
}
}

public class MerissaStilwell : BaseCreature 
 { 
public  MerissaStilwell() : base() 
 { 
Model = 3275;
AttackSpeed= 2000;
BoundingRadius = 0.51f ;
Name = "Merissa Stilwell" ;
Flags1 = 0x08080066 ;
Id = 11898 ; 
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
Level = RandomLevel( 7 );
NpcType = 7 ;
BaseHitPoints = 0 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 0f ;
SetDamage ( 4, 6);
NpcText00 = "Hello" ;
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
Equip( new Item( 7439, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ));
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
}
}

}
