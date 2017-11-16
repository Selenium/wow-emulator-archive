//originally Scripted By DiScS Converter
//Edited by *place name here*
using System;
using Server.Items;

////////////////////
namespace Server.Creatures
{


public class BarkeepHann : BaseCreature 
 { 
public  BarkeepHann() : base() 
 { 
Model = 5039;
AttackSpeed= 1000;
BoundingRadius = 0.306000f ;
Name = "Barkeep Hann" ;
Flags1 = 0x08480046 ;
Id = 274 ; 
Size = 1f;
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
NpcText00 = "Greetings $N, I am Barkeep Hann." ;
BaseMana = 0 ;
Sells = new Item[] { new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
                           , new MoonberryJuice()
                           , new ShredderOperatingManualPage8()
                           , new ShredderOperatingManualPage11()
                           , new SweetNectar()
                           , new BottleOfMoonshine()
                           , new GreenHillsOfStranglethornPage1()
                           , new GreenHillsOfStranglethornPage4()
                           , new GreenHillsOfStranglethornPage6()
                           , new GreenHillsOfStranglethornPage10()
                           , new GreenHillsOfStranglethornPage11()
                           , new GreenHillsOfStranglethornPage14()
                           , new GreenHillsOfStranglethornPage16()
                           , new GreenHillsOfStranglethornPage18()
                           , new GreenHillsOfStranglethornPage20()
                           , new GreenHillsOfStranglethornPage21()
                           , new GreenHillsOfStranglethornPage24()
                           , new GreenHillsOfStranglethornPage25()
                           , new GreenHillsOfStranglethornPage26()
                           , new GreenHillsOfStranglethornPage27()
                           , new GorillaFang()
                           , new MorningGloryDew()
                           , new WhitePunchCard()
                           , new GrimeEncrustedObject()
  } ;
Faction = Factions.Stormwind;
Guild = "Bartender" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
//Equip( new Item( 1599, InventoryTypes.TwoHanded, 10, 2, 17, 2, 0, 0, 0 ));
Item rightHand = new  Item( 7445, InventoryTypes.OneHand, 14, 1, 13, 7, 0, 0, 0 ); 
rightHand.InventoryType = InventoryTypes.Back; 
Equip( rightHand);
/*
Item rightHand = new WornDagger(); 
Item leftHand = new WornShortsword(); 
rightHand.InventoryType = InventoryTypes.OneHand; 
leftHand.InventoryType = InventoryTypes.HeldInHand; 
Equip( rightHand, leftHand ); 
*/
}
}

public class BarkeepDaniels : BaseCreature 
 { 
public  BarkeepDaniels() : base() 
 { 
Model = 3370;
AttackSpeed= 1000;
BoundingRadius = 0.306000f ;
Name = "Barkeep Daniels" ;
Flags1 = 0x08480046 ;
Id = 346 ; 
Size = 1f;
Speed = 5f ;
WalkSpeed = 5f ;
RunSpeed = 8f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 21 );
NpcType = 7 ;
BaseHitPoints = 864 ;
NpcFlags = 2 ;
CombatReach = 1.5f ;
SetDamage ( 22, 29 );
NpcText00 = "Greetings $N, I am Barkeep Daniels." ;
BaseMana = 0 ;
Faction = Factions.Stormwind;
Guild = "Bartender" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}
public class BarkeepDobbins : BaseCreature 
 { 
public  BarkeepDobbins() : base() 
 { 
Model = 3266;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Barkeep Dobbins" ;
Flags1 = 0x08480046 ;
Id = 465 ; 
Size = 1f;
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
NpcText00 = "Greetings $N, I am Barkeep Dobbins." ;
BaseMana = 0 ;
Sells = new Item[] { new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
                           , new MoonberryJuice()
                           , new StormwindBrie()
                           , new SweetNectar()
                           , new SkinOfSweetRum()
                           , new DarnassianBleu()
                           , new FlaskOfPort()
                           , new FlagonOfMead()
                           , new JugOfBourbon()
                           , new SkinOfDwarvenStout()
                           , new BottleOfPinotNoir()
                           , new FineAgedCheddar()
                           , new DalaranSharp()
                           , new DwarvenMild()
                           , new MorningGloryDew()
                           , new AlteracSwiss()
  } ;
Faction = Factions.Stormwind;
Guild = "Bartender" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7445, InventoryTypes.OneHand, 14, 1, 13, 7, 0, 0, 0 ));
}
}

public class BarkeepKelly : BaseCreature 
 { 
public  BarkeepKelly() : base() 
 { 
Model = 3691;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Barkeep Kelly" ;
Flags1 = 0x08480046 ;
Id = 2366 ; 
Size = 1f;
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
NpcText00 = "Hello there... Do you want a drink or somethin'?Or maybe you're looking for a girl..." ;
BaseMana = 0 ;
Sells = new Item[] { new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
                           , new MoonberryJuice()
                           , new SweetNectar()
                           , new MorningGloryDew()
  } ;
Faction = Factions.Stormwind;
Guild = "Bartender" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 7445, InventoryTypes.OneHand, 14, 1, 13, 7, 0, 0, 0 ));
}
}

public class BarkeepMorag : BaseCreature 
 { 
public  BarkeepMorag() : base() 
 { 
Model = 3606;
AttackSpeed= 1739;
BoundingRadius = 0.372000f ;
Name = "Barkeep Morag" ;
Flags1 = 0x0480046 ;
Id = 5611 ; 
Size = 1f;
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
BaseHitPoints = 544 ;
NpcFlags = 6 ;
CombatReach = 1.5f ;
SetDamage ( 14, 18 );
NpcText00 = "Hello" ;
BaseMana = 0 ;
Sells = new Item[] { new ToughJerky()
                           , new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
                           , new MoonberryJuice()
                           , new SweetNectar()
                           , new HaunchOfMeat()
                           , new FlaskOfPort()
                           , new FlagonOfMead()
                           , new JugOfBourbon()
                           , new SkinOfDwarvenStout()
                           , new BottleOfPinotNoir()
                           , new MuttonChop()
                           , new WildHogShank()
                           , new CuredHamSteak()
                           , new MorningGloryDew()
                           , new RoastedQuail()
  } ;
Faction = Factions.Ogrimmar;
Guild = "Bartender" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 7445, InventoryTypes.OneHand, 14, 1, 13, 7, 0, 0, 0 ));
}
}

public class JarelMoor : BaseCreature 
 { 
public  JarelMoor() : base() 
 { 
Model = 1490;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Jarel Moor" ;
Flags1 = 0x08480046 ;
Id = 1305 ; 
Size = 1f;
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
NpcText00 = "Greetings $N, I am Jarel Moor." ;
BaseMana = 0 ;
Sells = new Item[] { new FlaskOfPort()
                           , new FlagonOfMead()
                           , new JugOfBourbon()
                           , new SkinOfDwarvenStout()
                           , new BottleOfPinotNoir()
  } ;
Faction = Factions.Stormwind;
Guild = "Bartender" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7445, InventoryTypes.OneHand, 14, 1, 13, 7, 0, 0, 0 ));
}
}

public class JoachimBrenlow : BaseCreature 
 { 
public  JoachimBrenlow() : base() 
 { 
Model = 1491;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Joachim Brenlow" ;
Flags1 = 0x08480046 ;
Id = 1311 ; 
Size = 1f;
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
NpcText00 = "Greetings $N, I am Joachim Brenlow." ;
BaseMana = 0 ;
Sells = new Item[] { new FlaskOfPort()
                           , new FlagonOfMead()
                           , new JugOfBourbon()
                           , new SkinOfDwarvenStout()
                           , new BottleOfPinotNoir()
  } ;
Faction = Factions.Stormwind;
Guild = "Bartender" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7445, InventoryTypes.OneHand, 14, 1, 13, 7, 0, 0, 0 ));
}
}

public class TrukWildbeard : BaseCreature 
 { 
public  TrukWildbeard() : base() 
 { 
Model = 7009;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Truk Wildbeard" ;
Flags1 = 0x08480046 ;
Id = 4782 ; 
Size = 1f;
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
NpcText00 = "Greetings $N, I am Truk Wildbeard." ;
BaseMana = 0 ;
Sells = new Item[] { new ToughJerky()
                           , new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
                           , new MoonberryJuice()
                           , new StormwindBrie()
                           , new SweetNectar()
                           , new RecipeTenderWolfSteak()
                           , new DarnassianBleu()
                           , new HaunchOfMeat()
                           , new MuttonChop()
                           , new WildHogShank()
                           , new FineAgedCheddar()
                           , new DalaranSharp()
                           , new DwarvenMild()
                           , new CuredHamSteak()
                           , new CherryGrog()
                           , new MorningGloryDew()
                           , new AlteracSwiss()
                           , new RoastedQuail()
  } ;
Faction = Factions.WildHammerClan;
Guild = "Bartender" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
Equip( new Item( 7445, InventoryTypes.OneHand, 14, 1, 13, 7, 0, 0, 0 ));
}
}

public class BartenderLillian : BaseCreature 
 { 
public  BartenderLillian() : base() 
 { 
Model = 4858;
AttackSpeed= 2000;
BoundingRadius = 0.208000f ;
Name = "Bartender Lillian" ;
Flags1 = 0x08480046 ;
Id = 4893 ; 
Size = 1f;
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
NpcText00 = "Greetings $N, I am Bartender Lillian." ;
BaseMana = 0 ;
Sells = new Item[] { new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
                           , new MoonberryJuice()
                           , new SweetNectar()
                           , new MorningGloryDew()
  } ;
Faction = Factions.Stormwind;
Guild = "Bartender" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 7445, InventoryTypes.OneHand, 14, 1, 13, 7, 0, 0, 0 ));
}
}

public class Mikhail : BaseCreature 
 { 
public  Mikhail() : base() 
 { 
Model = 2964;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Mikhail" ;
Flags1 = 0x08480046 ;
Id = 4963 ; 
Size = 1f;
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
BaseHitPoints = 1625 ;
NpcFlags = 2 ;
CombatReach = 1.5f ;
SetDamage ( 43, 56 );
NpcText00 = "Greetings $N, I am Mikhail." ;
BaseMana = 0 ;
Sells = new Item[] { new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
                           , new MoonberryJuice()
                           , new ShredderOperatingManualPage8()
                           , new ShredderOperatingManualPage11()
                           , new SweetNectar()
                           , new BottleOfMoonshine()
                           , new GreenHillsOfStranglethornPage1()
                           , new GreenHillsOfStranglethornPage4()
                           , new GreenHillsOfStranglethornPage6()
                           , new GreenHillsOfStranglethornPage10()
                           , new GreenHillsOfStranglethornPage11()
                           , new GreenHillsOfStranglethornPage14()
                           , new GreenHillsOfStranglethornPage16()
                           , new GreenHillsOfStranglethornPage18()
                           , new GreenHillsOfStranglethornPage20()
                           , new GreenHillsOfStranglethornPage21()
                           , new GreenHillsOfStranglethornPage24()
                           , new GreenHillsOfStranglethornPage25()
                           , new GreenHillsOfStranglethornPage26()
                           , new GreenHillsOfStranglethornPage27()
                           , new GorillaFang()
                           , new MorningGloryDew()
                           , new WhitePunchCard()
                           , new GrimeEncrustedObject()
  } ;
Faction = Factions.Stormwind;
Guild = "Bartender" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7445, InventoryTypes.OneHand, 14, 1, 13, 7, 0, 0, 0 ));
}
}

public class KurdrumBarleybeard : BaseCreature 
 { 
public  KurdrumBarleybeard() : base() 
 { 
Model = 262;
AttackSpeed= 2100;
BoundingRadius = 1.00f ;
Name = "Kurdrum Barleybeard" ;
Flags1 = 0x102 ;
Id = 5139 ; 
Size = 1f;
Speed = 5f ;
WalkSpeed = 5f ;
RunSpeed = 8f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 1 );
NpcType = 7 ;
BaseHitPoints = 24 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 11.00f ;
SetDamage ( 0, 1 );
NpcText00 = "Greetings $N, I am Kurdrum Barleybeard." ;
BaseMana = 20 ;
Faction = Factions.NoFaction;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 7445, InventoryTypes.OneHand, 14, 1, 13, 7, 0, 0, 0 ));
}
}

public class BruukBarleybeard : BaseCreature 
 { 
public  BruukBarleybeard() : base() 
 { 
Model = 3458;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Bruuk Barleybeard" ;
Flags1 = 0x08480046 ;
Id = 5570 ; 
Size = 1f;
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
NpcText00 = "Greetings $N, I am Bruuk Barleybeard." ;
BaseMana = 0 ;
Sells = new Item[] { new FlaskOfPort()
                           , new FlagonOfMead()
                           , new JugOfBourbon()
                           , new SkinOfDwarvenStout()
                           , new BottleOfPinotNoir()
                           , new CherryGrog()
  } ;
Faction = Factions.IronForge;
Guild = "Bartender" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
Equip( new Item( 7445, InventoryTypes.OneHand, 14, 1, 13, 7, 0, 0, 0 ));
}
}

public class BartenderWental : BaseCreature 
 { 
public  BartenderWental() : base() 
 { 
Model = 3638;
AttackSpeed= 1000;
BoundingRadius = 0.306000f ;
Name = "Bartender Wental" ;
Flags1 = 0x08480046 ;
Id = 5620 ; 
Size = 1f;
Speed = 5f ;
WalkSpeed = 5f ;
RunSpeed = 8f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 21 );
NpcType = 7 ;
BaseHitPoints = 864 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 22, 29 );
NpcText00 = "Greetings $N, I am Bartender Wental." ;
BaseMana = 0 ;
Sells = new Item[] { new ToughJerky()
                           , new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
                           , new MoonberryJuice()
                           , new StormwindBrie()
                           , new SweetNectar()
                           , new DarnassianBleu()
                           , new HaunchOfMeat()
                           , new MuttonChop()
                           , new WildHogShank()
                           , new FineAgedCheddar()
                           , new DalaranSharp()
                           , new DwarvenMild()
                           , new ToughHunkOfBread()
                           , new FreshlyBakedBread()
                           , new MoistCornbread()
                           , new MulgoreSpiceBread()
                           , new CuredHamSteak()
                           , new SoftBananaBread()
                           , new MorningGloryDew()
                           , new AlteracSwiss()
                           , new HomemadeCherryPie()
                           , new RoastedQuail()
  } ;
Faction = Factions.Stormwind;
Guild = "Bartender" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7445, InventoryTypes.OneHand, 14, 1, 13, 7, 0, 0, 0 ));
}
}

}
