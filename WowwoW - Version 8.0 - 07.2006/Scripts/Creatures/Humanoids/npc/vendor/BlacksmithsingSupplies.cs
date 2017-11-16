//originally Scripted By DiScS Converter
//Edited by *place name here*
using System;
using Server.Items;

////////////////////
namespace Server.Creatures
{
public class ThrawnBoltar : BaseCreature 
 { 
public  ThrawnBoltar() : base() 
 { 
Model = 3427;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Thrawn Boltar" ;
Flags1 = 0x08480046 ;
Id = 1690 ; 
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
Level = RandomLevel( 29 );
NpcType = 7 ;
BaseHitPoints = 1184 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 31, 41 );
NpcText00 = "Greetings $N, I am Thrawn Boltar." ;
BaseMana = 0 ;
Sells = new Item[] { new WeakFlux()
                           , new MiningPick()
                           , new StrongFlux()
                           , new Coal()
                           , new BlacksmithHammer()
  } ;
Faction = Factions.IronForge;
Guild = "Blacksmithsing Supplies" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7439, InventoryTypes.Back, 4, 2, 13, 3, 0, 0, 0 ));
}
}

public class Hurklor : BaseCreature 
 { 
public  Hurklor() : base() 
 { 
Model = 4477;
AttackSpeed= 2000;
BoundingRadius = 0.372000f ;
Name = "Hurklor" ;
Flags1 = 0x08080046 ;
Id = 2844 ; 
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
Level = RandomLevel( 46 );
NpcType = 7 ;
BaseHitPoints = 1865 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 50, 65 );
NpcText00 = "Greetings $N, I am Hurklor." ;
BaseMana = 0 ;
Sells = new Item[] { new WeakFlux()
                           , new MiningPick()
                           , new StrongFlux()
                           , new Coal()
                           , new BlacksmithHammer()
  } ;
Faction = Factions.BootyBay;
Guild = "Blacksmithsing Supplies" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
Equip( new Item( 7439, InventoryTypes.Back, 4, 2, 13, 3, 0, 0, 0 ));
}
}

public class JansenUnderwood : BaseCreature 
 { 
public  JansenUnderwood() : base() 
 { 
Model = 4479;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Jansen Underwood" ;
Flags1 = 0x08080046 ;
Id = 2847 ; 
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
NpcType = 7 ;
BaseHitPoints = 1985 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 53, 69 );
NpcText00 = "Greetings $N, I am Jansen Underwood." ;
BaseMana = 0 ;
Sells = new Item[] { new WeakFlux()
                           , new MiningPick()
                           , new StrongFlux()
                           , new Coal()
                           , new BlacksmithHammer()
  } ;
Faction = Factions.BootyBay;
Guild = "Blacksmithsing Supplies" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
Equip( new Item( 7439, InventoryTypes.Back, 4, 2, 13, 3, 0, 0, 0 ));
}
}

public class TaurStonehoof : BaseCreature 
 { 
public  TaurStonehoof() : base() 
 { 
Model = 2100;
AttackSpeed= 2000;
BoundingRadius = 0.974700f ;
Name = "Taur Stonehoof" ;
Flags1 = 0x08480046 ;
Id = 2999 ; 
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
NpcText00 = "Greetings $N, I am Taur Stonehoof." ;
BaseMana = 0 ;
Sells = new Item[] { new WeakFlux()
                           , new MiningPick()
                           , new StrongFlux()
                           , new Coal()
                           , new BlacksmithHammer()
  } ;
Faction = Factions.ThunderBluff;
Guild = "Blacksmithsing Supplies" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 8078, InventoryTypes.OneHand, 14, 1, 13, 3, 0, 0, 0 ));
}
}

public class Sumi : BaseCreature 
 { 
public  Sumi() : base() 
 { 
Model = 1378;
AttackSpeed= 1739;
BoundingRadius = 0.236000f ;
Name = "Sumi" ;
Flags1 = 0x08480046 ;
Id = 3356 ; 
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
NpcText00 = "Greetings $N, I am Sumi." ;
BaseMana = 0 ;
Sells = new Item[] { new PlansHardenedIronShortsword()
                           , new WeakFlux()
                           , new MiningPick()
                           , new StrongFlux()
                           , new Coal()
                           , new BlacksmithHammer()
  } ;
Faction = Factions.Ogrimmar;
Guild = "Blacksmithsing Supplies" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7434, InventoryTypes.OneHand, 15, 1, 13, 3, 0, 0, 0 ));
}
}

public class Hraq : BaseCreature 
 { 
public  Hraq() : base() 
 { 
Model = 3866;
AttackSpeed= 2000;
BoundingRadius = 0.372000f ;
Name = "Hraq" ;
Flags1 = 0x08480046 ;
Id = 3477 ; 
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
BaseHitPoints = 744 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 19, 25 );
NpcText00 = "Greetings $N, I am Hraq." ;
BaseMana = 0 ;
Sells = new Item[] { new WeakFlux()
                           , new MiningPick()
                           , new StrongFlux()
                           , new Coal()
                           , new BlacksmithHammer()
  } ;
Faction = Factions.Ogrimmar;
Guild = "Blacksmithsing Supplies" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7439, InventoryTypes.OneHand, 4, 2, 13, 3, 0, 0, 0 ));
}
}

public class ThurgrumDeepforge : BaseCreature 
 { 
public  ThurgrumDeepforge() : base() 
 { 
Model = 3098;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Thurgrum Deepforge" ;
Flags1 = 0x08480046 ;
Id = 4259 ; 
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
NpcText00 = "Greetings $N, I am Thurgrum Deepforge." ;
BaseMana = 0 ;
Sells = new Item[] { new WeakFlux()
                           , new MiningPick()
                           , new StrongFlux()
                           , new Coal()
                           , new BlacksmithHammer()
  } ;
Faction = Factions.IronForge;
Guild = "Blacksmithsing Supplies" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 8078, InventoryTypes.OneHand, 14, 1, 13, 3, 0, 0, 0 ));
}
}

public class SamuelVanBrunt : BaseCreature 
 { 
public  SamuelVanBrunt() : base() 
 { 
Model = 2649;
AttackSpeed= 2000;
BoundingRadius = 0.383000f ;
Name = "Samuel Van Brunt" ;
Flags1 = 0x018480046 ;
Id = 4597 ; 
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
NpcText00 = "Greetings $N, I am Samuel Van Brunt." ;
BaseMana = 0 ;
Sells = new Item[] { new WeakFlux()
                           , new MiningPick()
                           , new StrongFlux()
                           , new Coal()
                           , new BlacksmithHammer()
  } ;
Faction = Factions.Undercity;
Guild = "Blacksmithsing Supplies" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7439, InventoryTypes.OneHand, 4, 2, 13, 3, 0, 0, 0 ));

}
}

public class KrinkleGoodsteel : BaseCreature 
 { 
public  KrinkleGoodsteel() : base() 
 { 
Model = 7217;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Krinkle Goodsteel" ;
Flags1 = 0x08080006 ;
Id = 5411 ; 
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
NpcFlags = 22 ;
CombatReach = 1.5f ;
SetDamage ( 43, 56 );
NpcText00 = "Greetings $N, I am Krinkle Goodsteel." ;
BaseMana = 0 ;
Sells = new Item[] { new WeakFlux()
                           , new MiningPick()
                           , new StrongFlux()
                           , new Coal()
                           , new BlacksmithHammer()
                           , new PlansGoldenScaleCoif()
  } ;
Faction = Factions.Gadgetzan;
new NonAgressiveAnimalAI( this );
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
}
}

public class KaitaDeepforge : BaseCreature 
 { 
public  KaitaDeepforge() : base() 
 { 
Model = 3311;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Kaita Deepforge" ;
Flags1 = 0x08480046 ;
Id = 5512 ; 
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
NpcText00 = "Greetings $N, I am Kaita Deepforge." ;
BaseMana = 0 ;
Sells = new Item[] { new PlansHardenedIronShortsword()
                           , new WeakFlux()
                           , new MiningPick()
                           , new StrongFlux()
                           , new Coal()
                           , new BlacksmithHammer()
  } ;
Faction = Factions.Stormwind;
Guild = "Blacksmithsing Supplies" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 8078, InventoryTypes.OneHand, 14, 1, 13, 3, 0, 0, 0 ));
}
}

public class ElisaSteelhand : BaseCreature 
 { 
public  ElisaSteelhand() : base() 
 { 
Model = 5022;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Elisa Steelhand" ;
Flags1 = 0x08480046 ;
Id = 6300 ; 
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
NpcText00 = "Greetings $N, I am Elisa Steelhand." ;
BaseMana = 0 ;
Sells = new Item[] { new WeakFlux()
                           , new MiningPick()
                           , new StrongFlux()
                           , new Coal()
                           , new BlacksmithHammer()
  } ;
Faction = Factions.Darnasus;
Guild = "Blacksmithsing Supplies" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 8078, InventoryTypes.OneHand, 14, 1, 13, 3, 0, 0, 0 ));
}
}

public class Harggan : BaseCreature 
 { 
public  Harggan() : base() 
 { 
Model = 7383;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Harggan" ;
Flags1 = 0x08480046 ;
Id = 8161 ; 
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
NpcType = 7 ;
BaseHitPoints = 1985 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 53, 69 );
NpcText00 = "Greetings $N, I am Harggan." ;
BaseMana = 0 ;
Sells = new Item[] { new WeakFlux()
                           , new MiningPick()
                           , new StrongFlux()
                           , new Coal()
                           , new BlacksmithHammer()
                           , new PlansMithrilScaleBracers()
  } ;
Faction = Factions.WildHammerClan;
Guild = "Blacksmithsing Supplies" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
}
}

public class Gharash : BaseCreature 
 { 
public  Gharash() : base() 
 { 
Model = 7384;
AttackSpeed= 2000;
BoundingRadius = 0.372000f ;
Name = "Gharash" ;
Flags1 = 0x08400046 ;
Id = 8176 ; 
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
NpcText00 = "Greetings $N, I am Gharash." ;
BaseMana = 0 ;
Sells = new Item[] { new WeakFlux()
                           , new MiningPick()
                           , new StrongFlux()
                           , new Coal()
                           , new BlacksmithHammer()
                           , new PlansMithrilScaleBracers()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
}
}

public class Jazzrik : BaseCreature 
 { 
public  Jazzrik() : base() 
 { 
Model = 13050;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Jazzrik" ;
Flags1 = 0x080006 ;
Id = 9179 ; 
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
Level = RandomLevel( 38 );
NpcType = 7 ;
BaseHitPoints = 1545 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 41, 53 );
NpcText00 = "Greetings $N, I am Jazzrik." ;
BaseMana = 0 ;
Sells = new Item[] { new PlansSolidIronMaul()
                           , new WeakFlux()
                           , new MiningPick()
                           , new StrongFlux()
                           , new Coal()
                           , new BlacksmithHammer()
  } ;
Faction = Factions.BootyBay;
Guild = "Blacksmithsing Supplies" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7493, InventoryTypes.OneHand, 0, 1, 13, 3, 0, 0, 0 ));
}
}

}
