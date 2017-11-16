//originally Scripted By DiScS Converter
//Edited by *place name here*
using System;
using Server.Items;
using Server;

////////////////////
namespace Server.Creatures
{
public class Hulamahi : BaseCreature 
 { 
public  Hulamahi() : base() 
 { 
Model = 4096;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Hula'mahi" ;
Flags1 = 0x08480046 ;
Id = 3490 ; 
Guild = "Reagents and Herbs";
Size = 1f;
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
NpcText00 = "Greetings $N, I am Hula'mahi." ;
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
                           , new Peacebloom()
                           , new Earthroot()
                           , new Bruiseweed()
                           , new DustOfDecay()
                           , new EssenceOfPain()
                           , new EmptyVial()
                           , new LeadedVial()
                           , new LethargyRoot()
                           , new ThievesTools()
                           , new FlashPowder()
                           , new Deathweed()
                           , new InfernalStone()
                           , new RecipeHolyProtectionPotion()
                           , new Silverleaf()
                           , new Mageroyal()
                           , new EssenceOfAgony()
                           , new DustOfDeterioration()
                           , new CrystalVial()
  } ;
Faction = Factions.DarkspearTrolls;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 10821, InventoryTypes.OneHand, 14, 1, 13, 0, 0, 0, 0 ));
}
}
public class NidaWinterhoof : BaseCreature 
 { 
public  NidaWinterhoof() : base() 
 { 
Model = 2119;
AttackSpeed= 2000;
BoundingRadius = 0.872500f ;
Name = "Nida Winterhoof" ;
Flags1 = 0x08480046 ;
Id = 3014 ; 
Guild = "Herbalism Supplier";
Size = 1f;
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
NpcText00 = "Greetings $N, I am Nida Winterhoof." ;
BaseMana = 0 ;
Sells = new Item[] { new ImbuedVial()
                           , new EmptyVial()
                           , new LeadedVial()
                           , new CopperRod()
                           , new CrystalVial()
  } ;
Faction = Factions.ThunderBluff;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 10821, InventoryTypes.OneHand, 14, 1, 13, 0, 0, 0, 0 ));
}
}
public class Zealaya : BaseCreature 
 { 
public  Zealaya() : base() 
 { 
Model = 4362;
AttackSpeed= 1739;
BoundingRadius = 0.306000f ;
Name = "Zeal'aya" ;
Flags1 = 0x08480046 ;
Id = 3405 ; 
Guild = "Herbalism Supplier";
Size = 1f;
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
NpcText00 = "I'm sorry, I'm a bit busy right now making horseshoes for Verner Osgood in Lakeshire." ;
BaseMana = 0 ;
Sells = new Item[] { new EmptyVial()
                           , new LeadedVial()
                           , new CopperRod()
                           , new CrystalVial()
  } ;
Faction = Factions.DarkspearTrolls;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7475, InventoryTypes.OneHand, 14, 2, 13, 0, 0, 0, 0 ));
}
}
public class Eldraeith : BaseCreature 
 { 
public  Eldraeith() : base() 
 { 
Model = 3297;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Eldraeith" ;
Flags1 = 0x08480046 ;
Id = 5503 ; 
Guild = "Herbalism Supplier";
Size = 1f;
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
NpcText00 = "Greetings $N, I am Eldraeith." ;
BaseMana = 0 ;
Sells = new Item[] { new EmptyVial()
                           , new LeadedVial()
                           , new CopperRod()
                           , new CrystalVial()
  } ;
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}
public class GwinaStonebranch : BaseCreature 
 { 
public  GwinaStonebranch() : base() 
 { 
Model = 3064;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Gwina Stonebranch" ;
Flags1 = 0x08480046 ;
Id = 5138 ; 
Guild = "Herbalism Supplier";
Size = 1f;
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
NpcText00 = "Greetings $N, I am Gwina Stonebranch." ;
BaseMana = 0 ;
Sells = new Item[] { new EmptyVial()
                           , new LeadedVial()
                           , new CopperRod()
                           , new CrystalVial()
  } ;
Faction = Factions.IronForge;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7456, InventoryTypes.OneHand, 14, 1, 13, 0, 0, 0, 0 ));
}
}
public class KatrinaAlliestar : BaseCreature 
 { 
public  KatrinaAlliestar() : base() 
 { 
Model = 2665;
AttackSpeed= 2000;
BoundingRadius = 0.383000f ;
Name = "Katrina Alliestar" ;
Flags1 = 0x018480046 ;
Id = 4615 ; 
Guild = "Herbalism Supplier";
Size = 1f;
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
NpcText00 = "Greetings $N, I am Katrina Alliestar." ;
BaseMana = 0 ;
Sells = new Item[] { new EmptyVial()
                           , new LeadedVial()
                           , new CopperRod()
                           , new CrystalVial()
  } ;
Faction = Factions.Undercity;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7495, InventoryTypes.TwoHanded, 6,  1, 17, 2, 0, 0, 0 ));
}
}
public class Chardryn : BaseCreature 
 { 
public  Chardryn() : base() 
 { 
Model = 2245;
AttackSpeed= 2000;
BoundingRadius = 0.389000f ;
Name = "Chardryn" ;
Flags1 = 0x08480046 ;
Id = 4216 ; 
Guild = "Herbalism Supplier";
Size = 1f;
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
NpcText00 = "Greetings $N, I am Chardryn." ;
BaseMana = 0 ;
Sells = new Item[] { new EmptyVial()
                           , new LeadedVial()
                           , new CopperRod()
                           , new CrystalVial()
  } ;
Faction = Factions.Darnasus;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 10821, InventoryTypes.OneHand, 14,  1, 13, 0, 0, 0, 0 ));
}
}
public class FeliciaGump : BaseCreature 
 { 
public  FeliciaGump() : base() 
 { 
Model = 1441;
AttackSpeed= 2000;
BoundingRadius = 0.208000f ;
Name = "Felicia Gump" ;
Flags1 = 0x08480046 ;
Id = 1303 ; 
Guild = "Herbalism Supplier";
Size = 1f;
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
NpcText00 = "Greetings $N, I am Felicia Gump." ;
BaseMana = 0 ;
Sells = new Item[] { new StormwindSeasoningHerbs()
                           , new RedRose()
                           , new BlackRose()
                           , new SimpleWildflowers()
                           , new BeautifulWildflowers()
                           , new BouquetOfWhiteRoses()
                           , new BouquetOfBlackRoses()
  } ;
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 10821, InventoryTypes.OneHand, 14,  1, 13, 0, 0, 0, 0 ));
}
}
}