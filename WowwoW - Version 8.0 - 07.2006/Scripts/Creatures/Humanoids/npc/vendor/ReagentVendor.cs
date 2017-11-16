//originally Scripted By DiScS Converter
//Edited by *place name here*
using System;
using Server.Items;

////////////////////
namespace Server.Creatures
{
public class BalaiLokWein : BaseCreature 
 { 
public  BalaiLokWein() : base() 
 { 
Model = 13529;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Balai Lok'Wein" ;
Flags1 = 0x08400046 ;
Id = 13476 ; 
Guild = "Potions, Scrolls and Reagents";
Size = 1f;
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
NpcText00 = "Greetings $N, I am Balai Lok'Wein." ;
BaseMana = 0 ;
Sells = new Item[] { new ScrollOfProtectionII()
                           , new ExpertFirstAidUnderWraps()
                           , new ManualHeavySilkBandage()
                           , new ManualMageweaveBandage()
                           , new DemonicFigurine()
                           , new ArcanePowder()
                           , new WildBerries()
                           , new WildThornroot()
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
                           , new ScrollOfStaminaII()
                           , new ScrollOfSpiritII()
                           , new ScrollOfIntellectII()
                           , new ScrollOfAgility()
                           , new LesserManaPotion()
                           , new InfernalStone()
                           , new HealingPotion()
                           , new ScrollOfStrength()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
}
}
public class FirstSergeantHolamahi : BaseCreature 
 { 
public  FirstSergeantHolamahi() : base() 
 { 
Model = 0;
AttackSpeed= 0;
BoundingRadius = 0.51f ;
Name = "First Sergeant Hola'mahi" ;
Flags1 = 0x00000000 ;
Id = 12795 ; 
Guild = "Reagent Vendor";
Size = 1f;
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
Sells = new Item[] { new DemonicFigurine()
                           , new ArcanePowder()
                           , new WildBerries()
                           , new WildThornroot()
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
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
}
}
public class LieutenantJackspring : BaseCreature 
 { 
public  LieutenantJackspring() : base() 
 { 
Model = 0;
AttackSpeed= 0;
BoundingRadius = 0.51f ;
Name = "Lieutenant Jackspring" ;
Flags1 = 0x00000000 ;
Id = 12784 ; 
Guild = "Reagent Vendor";
Size = 1f;
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
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 0f ;
SetDamage ( 32, 42 );
NpcText00 = "Hello" ;
BaseMana = 0 ;
Sells = new Item[] { new DemonicFigurine()
                           , new ArcanePowder()
                           , new WildBerries()
                           , new WildThornroot()
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
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
}
}
public class Chepi : BaseCreature 
 { 
public  Chepi() : base() 
 { 
Model = 7625;
AttackSpeed= 2000;
BoundingRadius = 0.872500f ;
Name = "Chepi" ;
Flags1 = 0x08480046 ;
Id = 8361 ; 
Guild = "Reagent Vendor";
Size = 1f;
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
NpcText00 = "Greetings $N, I am Chepi." ;
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
Faction = Factions.ThunderBluff;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7446, InventoryTypes.OneHand, 2, 14, 1, 7, 0, 0, 0 ));
}
}
public class TynnusVenomsprout : BaseCreature 
 { 
public  TynnusVenomsprout() : base() 
 { 
Model = 3114;
AttackSpeed= 2000;
BoundingRadius = 0.351900f ;
Name = "Tynnus Venomsprout" ;
Flags1 = 0x08480046 ;
Id = 5169 ; 
Guild = "Shady Dealer";
Size = 1f;
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
NpcText00 = "Greetings $N, I am Tynnus Venomsprout." ;
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
Faction = Factions.GnomereganExiles;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 6469, InventoryTypes.OneHand, 2, 15, 1, 2, 0, 0, 0 ), new Item( 6534, InventoryTypes.HeldInHand, 4, 0, 2, 0, 0, 0, 0 ));
}
}
public class GinnyLongberry : BaseCreature 
 { 
public  GinnyLongberry() : base() 
 { 
Model = 3119;
AttackSpeed= 2000;
BoundingRadius = 0.351900f ;
Name = "Ginny Longberry" ;
Flags1 = 0x08480046 ;
Id = 5151 ; 
Guild = "Reagent Vendor";
Size = 1f;
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
NpcText00 = "Greetings $N, I am Ginny Longberry." ;
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
Faction = Factions.GnomereganExiles;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7456, InventoryTypes.OneHand, 2, 14, 1, 0, 0, 0, 0 ), new Item( 6534, InventoryTypes.HeldInHand, 4, 0, 2, 0, 0, 0, 0 ));
}
}
public class BarimJurgenstaad : BaseCreature 
 { 
public  BarimJurgenstaad() : base() 
 { 
Model = 3046;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Barim Jurgenstaad" ;
Flags1 = 0x08480046 ;
Id = 5110 ; 
Guild = "Reagent Vendor";
Size = 1f;
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
NpcText00 = "Greetings $N, I am Barim Jurgenstaad." ;
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
Faction = Factions.IronForge;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7456, InventoryTypes.OneHand, 2, 14, 1, 0, 0, 0, 0 ), new Item( 6534, InventoryTypes.HeldInHand, 4, 0, 2, 0, 0, 0, 0 ));
}
}
public class HannahAkeley : BaseCreature 
 { 
public  HannahAkeley() : base() 
 { 
Model = 2663;
AttackSpeed= 2000;
BoundingRadius = 0.383000f ;
Name = "Hannah Akeley" ;
Flags1 = 0x08400046 ;
Id = 4575 ; 
Guild = "Reagent Supplier";
Size = 1f;
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
NpcText00 = "Greetings $N, I am Hannah Akeley." ;
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
Faction = Factions.Undercity;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}
public class ThomasMordan : BaseCreature 
 { 
public  ThomasMordan() : base() 
 { 
Model = 2652;
AttackSpeed= 2000;
BoundingRadius = 0.383000f ;
Name = "Thomas Mordan" ;
Flags1 = 0x018480046 ;
Id = 4562 ; 
Guild = "Reagent Vendor";
Size = 1f;
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
NpcText00 = "Greetings $N, I am Thomas Mordan." ;
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
Faction = Factions.Undercity;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7456, InventoryTypes.OneHand, 2, 14, 1, 0, 0, 0, 0 ), new Item( 6534, InventoryTypes.HeldInHand, 4, 0, 2, 0, 0, 0, 0 ));
}
}
public class JadenvisSeawatcher : BaseCreature 
 { 
public  JadenvisSeawatcher() : base() 
 { 
Model = 4484;
AttackSpeed= 2000;
BoundingRadius = 0.389000f ;
Name = "Jadenvis Seawatcher" ;
Flags1 = 0x08480046 ;
Id = 3700 ; 
Guild = "Reagent Vendor";
Size = 1f;
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
BaseHitPoints = 0 ;
NpcFlags = 00 ;
CombatReach = 1.5f ;
SetDamage ( 52, 77 );
NpcText00 = "Hello" ;
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
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
}
}
public class JaysinLanyda : BaseCreature 
 { 
public  JaysinLanyda() : base() 
 { 
Model = 3699;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Jaysin Lanyda" ;
Flags1 = 0x08480046 ;
Id = 3542 ; 
Guild = "Poisons & Reagents";
Size = 1f;
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
NpcText00 = "Greetings $N, I am Jaysin Lanyda." ;
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
                           , new DustOfDecay()
                           , new EssenceOfPain()
                           , new EmptyVial()
                           , new LeadedVial()
                           , new LethargyRoot()
                           , new ThievesTools()
                           , new FlashPowder()
                           , new Deathweed()
                           , new InfernalStone()
                           , new EssenceOfAgony()
                           , new DustOfDeterioration()
                           , new CrystalVial()
  } ;
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 7466, InventoryTypes.OneHand, 2, 14, 1, 0, 0, 0, 0 ));
}
}
public class Tarhus : BaseCreature 
 { 
public  Tarhus() : base() 
 { 
Model = 3898;
AttackSpeed= 2000;
BoundingRadius = 0.974700f ;
Name = "Tarhus" ;
Flags1 = 0x08480046 ;
Id = 3500 ; 
Guild = "Reagent Vendor";
Size = 1f;
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
BaseHitPoints = 0 ;
NpcFlags = 0 ;
CombatReach = 4.05f ;
SetDamage ( 32, 42 );
NpcText00 = "Hello" ;
BaseMana = 0 ;
Sells = new Item[] { new DemonicFigurine()
                           , new ArcanePowder()
                           , new WildBerries()
                           , new WildThornroot()
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
Faction = Factions.ThunderBluff;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
}
}
public class Magenius : BaseCreature 
 { 
public  Magenius() : base() 
 { 
Model = 1372;
AttackSpeed= 1739;
BoundingRadius = 0.372000f ;
Name = "Magenius" ;
Flags1 = 0x08480046 ;
Id = 3351 ; 
Guild = "Reagents Vendor";
Size = 1f;
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
NpcText00 = "Greetings $N, I am Magenius." ;
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
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7445, InventoryTypes.OneHand, 2, 14, 1, 0, 0, 0, 0 ));
}
}
public class Hagrus : BaseCreature 
{
public  Hagrus() : base() 
 { 
Model = 1335;
AttackSpeed= 2000;
BoundingRadius = 0.372000f ;
Name = "Hagrus" ;
Flags1 = 0x08480046 ;
Id = 3335 ; 
Guild = "Reagents Vendor";
Size = 1f;
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
NpcText00 = "Greetings $N, I am Hagrus." ;
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
                           , new RecipeRagePotion()
                           , new RecipeGreatRagePotion()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7474, InventoryTypes.OneHand, 2, 14, 1, 0, 0, 0, 0 ));
}
}
public class Horthus : BaseCreature 
 { 
public  Horthus() : base() 
 { 
Model = 1323;
AttackSpeed= 1739;
BoundingRadius = 0.372000f ;
Name = "Horthus" ;
Flags1 = 0x08480046 ;
Id = 3323 ; 
Guild = "Reagents Vendor";
Size = 1f;
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
NpcText00 = "Greetings $N, I am Horthus." ;
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
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7466, InventoryTypes.OneHand, 2, 14, 1, 3, 0, 0, 0 ), new Item( 6537, InventoryTypes.HeldInHand, 4, 0, 1, 7, 0, 0, 0 ));
}
}
public class SlyGarrett : BaseCreature 
 { 
public  SlyGarrett() : base() 
 { 
Model = 4489;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Sly Garrett" ;
Flags1 = 0x08080046 ;
Id = 2622 ; 
Guild = "Shady Goods";
Size = 1f;
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
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1865 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 50, 65 );
NpcText00 = "Greetings $N, I am Sly Garrett." ;
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
Faction = Factions.BootyBay;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 7434, InventoryTypes.OneHand, 2, 15, 1, 3, 0, 0, 0 ), new Item( 6532, InventoryTypes.HeldInHand, 4, 0, 2, 0, 0, 0, 0 ));
}
}
public class AlyssaEva : BaseCreature 
 { 
public  AlyssaEva() : base() 
 { 
Model = 257;
AttackSpeed= 1000;
BoundingRadius = 1.000000f ;
Name = "Alyssa Eva" ;
Flags1 = 0x0808006E ;
Id = 1673 ; 
Guild = "Reagent Vendor";
Size = 1f;
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
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 304 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1f ;
SetDamage ( 7, 9 );
NpcText00 = "Greetings $N, I am Alyssa Eva." ;
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
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
}
}
public class SamorFestivus : BaseCreature 
 { 
public  SamorFestivus() : base() 
 { 
Model = 3464;
AttackSpeed= 1500;
BoundingRadius = 0.306000f ;
Name = "Samor Festivus" ;
Flags1 = 0x08480046 ;
Id = 1457 ; 
Guild = "Shady Dealer";
Size = 1f;
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
NpcText00 = "Greetings $N, I am Samor Festivus." ;
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
                           , new HealingPotion()
  } ;
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}
public class BrotherCassius : BaseCreature 
 { 
public  BrotherCassius() : base() 
 { 
Model = 1501;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Brother Cassius" ;
Flags1 = 0x08480046 ;
Id = 1351 ; 
Guild = "Reagent Vendor";
Size = 1f;
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
NpcText00 = "Greetings $N, I am Brother Cassius." ;
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
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}
public class OwenVaughn : BaseCreature 
 { 
public  OwenVaughn() : base() 
 { 
Model = 1494;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Owen Vaughn" ;
Flags1 = 0x08480046 ;
Id = 1308 ; 
Guild = "Reagent Vendor";
Size = 1f;
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
BaseHitPoints = 790 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 25, 32 );
NpcText00 = "Greetings $N, I am Owen Vaughn." ;
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
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 1600, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
}
}
public class KyraBoucher : BaseCreature 
 { 
public  KyraBoucher() : base() 
 { 
Model = 1444;
AttackSpeed= 1500;
BoundingRadius = 0.208000f ;
Name = "Kyra Boucher" ;
Flags1 = 0x08480046 ;
Id = 1275 ; 
Guild = "Reagent Vendor";
Size = 1f;
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
NpcText00 = "Greetings $N, I am Kyra Boucher." ;
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
                           , new CrownOfThePenitent()
                           , new FireTar()
                           , new ExplosiveShell()
                           , new TinyBronzeKey()
                           , new TinyIronKey()
                           , new InfernalStone()
  } ;
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 6535, InventoryTypes.HeldInHand, 4, 0, 2, 0, 0, 0, 0 ));
}
}

public class Alaindia : BaseCreature 
 { 
public  Alaindia() : base() 
 { 
Model = 2203;
AttackSpeed= 1500;
BoundingRadius = 0.208000f ;
Name = "Alaindia" ;
Flags1 = 0x08480046 ;
Id = 3562 ; 
Guild = "Reagent Vendor";
Size = 1f;
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
BaseMana = 0 ;
Sells = new Item[] { new InfernalStone()
, new DemonicFigurine()
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
  } ;
Faction = Factions.Darnasus;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 1600, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
}
}
	
}