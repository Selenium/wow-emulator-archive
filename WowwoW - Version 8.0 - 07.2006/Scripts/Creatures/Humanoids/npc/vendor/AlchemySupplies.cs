//originally Scripted By DiScS Converter
//Edited by *place name here*
using System;
using Server.Items;
using Server;

////////////////////
namespace Server.Creatures
{
public class NandarBranson : BaseCreature 
 { 
public  NandarBranson() : base() 
 { 
Model = 3649;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Nandar Branson" ;
Flags1 = 08480046 ;
Id = 2380 ; 
Guild = "Alchemy Supplies";
Size = 1f;
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
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1384 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 37, 48 );
NpcText00 = "Greetings $N, I am Nandar Branson." ;
BaseMana = 0 ;
Sells = new Item[] { new GreaterHealingPotion()
                           , new ImbuedVial()
                           , new EmptyVial()
                           , new LeadedVial()
                           , new ManaPotion()
                           , new RecipeFireProtectionPotion()
                           , new CrystalVial()
  } ;
Faction = Factions.Stormwind;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
//Equip( new Item( 7465, InventoryTypes.OneHand, 14, 1, 13, 0, 0, 0, 0 ),   new Item( 6533, InventoryTypes.HeldInHand, 0, 2, 23, 0, 0, 0, 0 )); 

Item rightHand = new Item( 7465, InventoryTypes.OneHand, 14, 1, 13, 0, 0, 0, 0 );
Item leftHand = new Item( 6533, InventoryTypes.HeldInHand, 0, 2, 23, 0, 0, 0, 0 );
rightHand.InventoryType = InventoryTypes.OneHand; 
leftHand.InventoryType = InventoryTypes.HeldInHand; 
Equip( rightHand, leftHand );

//equipmodel=0 7486 2 7 1 13 3 0 0 0
//equipmodel=1 6537 4 0 1 23 7 0 0 0
/*Item rightHand = new WornDagger(); 
Item leftHand = new WornShortsword(); 
rightHand.InventoryType = InventoryTypes.OneHand; 
leftHand.InventoryType = InventoryTypes.HeldInHand; 
Equip( rightHand, leftHand ); */



}
}


public class Korgeld : BaseCreature 
 { 
public  Korgeld() : base() 
 { 
Model = 1369;
AttackSpeed= 1739;
BoundingRadius = 0.372000f ;
Name = "Kor'geld" ;
Flags1 = 08480046 ;
Id = 3348 ; 
Guild = "Alchemy Supplies";
Size = 1f;
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
NpcText00 = "Greetings $N, I am Kor'geld." ;
BaseMana = 0 ;
Sells = new Item[] { new RecipeElixirOfSuperiorDefense()
                           , new ImbuedVial()
                           , new EmptyVial()
                           , new LeadedVial()
                           , new RecipeFreeActionPotion()
                           , new CrystalVial()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Equip( new Item( 7465, InventoryTypes.OneHand, 14, 1, 13, 0, 0, 0, 0 ));
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};


}
}
public class HarklanMoongrove : BaseCreature 
 { 
public  HarklanMoongrove() : base() 
 { 
Model = 4183;
AttackSpeed= 2000;
BoundingRadius = 0.389000f ;
Name = "Harklan Moongrove" ;
Flags1 = 08480046 ;
Id = 3956 ; 
Guild = "Alchemy Supplies";
Size = 1f;
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
NpcText00 = "Greetings $N, I am Harklan Moongrove." ;
BaseMana = 0 ;
Sells = new Item[] { new ImbuedVial()
                           , new EmptyVial()
                           , new LeadedVial()
                           , new LesserManaPotion()
                           , new RecipeShadowProtectionPotion()
                           , new CrystalVial()
                           , new HealingPotion()
  } ;
Faction = Factions.Darnasus;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};

}
}
public class Algernon : BaseCreature 
 { 
public  Algernon() : base() 
 { 
Model = 2676;
AttackSpeed= 2000;
BoundingRadius = 1.000000f ;
Name = "Algernon" ;
Flags1 = 08480046 ;
Id = 4610 ; 
Guild = "Alchemy Supplies";
Size = 1f;
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
NpcFlags = (int)NpcActions.Trainer | (int)NpcActions.Trainer ;
CombatReach = 1f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Algernon." ;
BaseMana = 0 ;
Trains = new int[] {  2275   // Apprentice Alchemist (54967)
                           , 2280   // Journeyman Alchemist (54988)
                           , 3465   // Expert Alchemist (85702)
                           , 3186   // Elixir of Defense (75916)
                           , 7846   // Elixir of Firepower (223757)
                           , 7182   // Greater Healing Potion (203953)
                           , 3461   // Mana Potion (85282)
                           , 3459   // Lesser Invisibility Potion (85216)
                           , 3460   // Shadow Oil (85243)
                           , 11482   // Elixir of Waterwalking (313014)
                           , 3178   // Elixir of Fortitude (75934)
                           , 13030   // Mighty Troll's Blood Potion (85254)
                           , 11483   // Elixir of Agility (313057)
                           , 11484   // Elixir of Greater Defense (313075)
                           , 3463   // Frost Oil (85331)
                           , 11488   // Greater Mana Potion (313037)
                           , 11486   // Oil of Immolation (313101)
                           , 12610   // Catseye Elixir (338681)
                           , 11490   // Goblin Rocket Fuel (313186)
                           , 11522   // Restorative Elixir (313119)
  } ;
Sells = new Item[] { new RecipeSuperiorManaPotion()
                           , new ImbuedVial()
                           , new EmptyVial()
                           , new LeadedVial()
                           , new CrystalVial()
                           , new RecipeElixirOfShadowPower()
  } ;
Faction = Factions.Undercity;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Equip( new Item( 7465, InventoryTypes.OneHand, 14, 1, 13, 0, 0, 0, 0 ));
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};

}
}
public class Ulthir : BaseCreature 
 { 
public  Ulthir() : base() 
 { 
Model = 2272;
AttackSpeed= 2000;
BoundingRadius = 0.389000f ;
Name = "Ulthir" ;
Flags1 = 08480046 ;
Id = 4226 ; 
Guild = "Alchemy Supplies";
Size = 1f;
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
NpcText00 = "Greetings $N, I am Ulthir." ;
BaseMana = 0 ;
Sells = new Item[] { new RecipeSuperiorManaPotion()
                           , new ImbuedVial()
                           , new EmptyVial()
                           , new LeadedVial()
                           , new RecipeFreeActionPotion()
                           , new RecipeGreatRagePotion()
                           , new CrystalVial()
  } ;
Faction = Factions.Darnasus;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Equip( new Item( 7465, InventoryTypes.OneHand, 14, 1, 13, 0, 0, 0, 0 ), new Item( 6535, InventoryTypes.HeldInHand, 0, 2, 23, 0, 0, 0, 0 ));
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
}
}

public class ManiWinterhoof : BaseCreature 
 { 
public  ManiWinterhoof() : base() 
 { 
Model = 2116;
AttackSpeed= 2000;
BoundingRadius = 0.872500f ;
Name = "Mani Winterhoof" ;
Flags1 = 08480046 ;
Id = 3010 ; 
Guild = "Alchemy Supplies";
Size = 1f;
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
NpcText00 = "Greetings $N, I am Mani Winterhoof." ;
BaseMana = 0 ;
Sells = new Item[] { new ImbuedVial()
                           , new EmptyVial()
                           , new LeadedVial()
                           , new CrystalVial()
  } ;
Faction = Factions.ThunderBluff;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Equip( new Item( 7465, InventoryTypes.OneHand, 14, 1, 13, 0, 0, 0, 0 ), new Item( 6535, InventoryTypes.HeldInHand, 0, 2, 23, 0, 0, 0, 0 ));
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
}
}
public class GlyxBrewright : BaseCreature 
 { 
public  GlyxBrewright() : base() 
 { 
Model = 7178;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Glyx Brewright" ;
Flags1 = 08000006 ;
Id = 2848 ; 
Guild = "Alchemy Supplies";
Size = 1f;
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
NpcType = (int)NpcTypes.Critter ;
BaseHitPoints = 1825 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 49, 63 );
NpcText00 = "Greetings $N, I am Glyx Brewright." ;
BaseMana = 0 ;
Sells = new Item[] { new GreaterHealingPotion()
                           , new ImbuedVial()
                           , new EmptyVial()
                           , new LeadedVial()
                           , new ManaPotion()
                           , new RecipeFrostProtectionPotion()
                           , new RecipeNatureProtectionPotion()
                           , new CrystalVial()
  } ;
Faction = Factions.BootyBay;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Equip( new Item( 7466, InventoryTypes.OneHand, 14, 1, 13, 0, 0, 0, 0 ));
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};


}
}
public class DrovnarStrongbrew : BaseCreature 
 { 
public  DrovnarStrongbrew() : base() 
 { 
Model = 3964;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Drovnar Strongbrew" ;
Flags1 = 08480046 ;
Id = 2812 ; 
Guild = "Alchemy Supplies";
Size = 1f;
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
BaseHitPoints = 1585 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 42, 55 );
NpcText00 = "Greetings $N, I am Drovnar Strongbrew." ;
BaseMana = 0 ;
Sells = new Item[] { new GreaterHealingPotion()
                           , new ImbuedVial()
                           , new EmptyVial()
                           , new LeadedVial()
                           , new ManaPotion()
                           , new RecipeFrostProtectionPotion()
                           , new CrystalVial()
  } ;
Faction = Factions.IronForge;
Equip( new Item( 7467, InventoryTypes.OneHand, 14, 1, 13, 0, 0, 0, 0 ), new Item( 6531, InventoryTypes.HeldInHand, 0, 2, 23, 0, 0, 0, 0 ));
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};


}
}
public class Bliztik : BaseCreature 
 { 
public  Bliztik() : base() 
 { 
Model = 7130;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Bliztik" ;
Flags1 = 080006 ;
Id = 2481 ; 
Guild = "Alchemy Supplies";
Size = 1f;
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
NpcText00 = "Greetings $N, I am Bliztik." ;
BaseMana = 0 ;
Sells = new Item[] { new ImbuedVial()
                           , new EmptyVial()
                           , new LeadedVial()
                           , new LesserManaPotion()
                           , new RecipeShadowOil()
                           , new CrystalVial()
                           , new HealingPotion()
  } ;
Faction = Factions.BootyBay;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Equip( new Item( 7465, InventoryTypes.OneHand, 14, 1, 13, 0, 0, 0, 0 ), new Item( 6535, InventoryTypes.HeldInHand, 0, 2, 23, 0, 0, 0, 0 ));
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
}
}

public class Brokin : BaseCreature 
 { 
public  Brokin() : base() 
 { 
Model = 7031;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Bro'kin" ;
Flags1 = 080006 ;
Id = 2480 ; 
Guild = "Alchemy Supplies";
Size = 1f;
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
CombatReach = 1.500000f ;
SetDamage ( 53, 69 );
NpcText00 = "Greetings $N, I am Bro'kin." ;
BaseMana = 0 ;
Sells = new Item[] { new RecipeFrostOil()
                           , new GreaterHealingPotion()
                           , new ImbuedVial()
                           , new EmptyVial()
                           , new LeadedVial()
                           , new ManaPotion()
                           , new CrystalVial()
  } ;
Faction = Factions.BootyBay;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Equip( new Item( 7465, InventoryTypes.OneHand, 14, 1, 13, 0, 0, 0, 0 ), new Item( 6531, InventoryTypes.HeldInHand, 0, 2, 23, 0, 0, 0, 0 ));
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
}
}


public class MariaLumere : BaseCreature 
 { 
public  MariaLumere() : base() 
 { 
Model = 1482;
AttackSpeed= 2000;
BoundingRadius = 0.208000f ;
Name = "Maria Lumere" ;
Flags1 = 08480046 ;
Id = 1313 ; 
Guild = "Alchemy Supplies";
Size = 1f;
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
NpcText00 = "Greetings $N, I am Maria Lumere." ;
BaseMana = 0 ;
Sells = new Item[] { new ImbuedVial()
                           , new Peacebloom()
                           , new Earthroot()
                           , new Bruiseweed()
                           , new WildSteelbloom()
                           , new Kingsblood()
                           , new Liferoot()
                           , new EmptyVial()
                           , new LeadedVial()
                           , new Silverleaf()
                           , new Mageroyal()
                           , new CrystalVial()
                           , new RecipeElixirOfShadowPower()
  } ;
Faction = Factions.Stormwind;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Equip( new Item( 1600, InventoryTypes.TwoHanded, 10, 2, 17, 2, 0, 0, 0 ), new Item( 6535, InventoryTypes.HeldInHand, 0, 2, 23, 0, 0, 0, 0 ));
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
}
}
public class EvieWhirlbrew : BaseCreature 
 { 
public  EvieWhirlbrew() : base() 
 { 
Model = 10745;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Evie Whirlbrew" ;
Flags1 = 08080006 ;
Id = 11188 ; 
Guild = "Alchemy Supplies";
Size = 1f;
Speed = 5f ;
WalkSpeed = 5f ;
RunSpeed = 8f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 58 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 2346 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 63, 82 );
NpcText00 = "Greetings $N, I am Evie Whirlbrew." ;
BaseMana = 0 ;
Sells = new Item[] { new RecipeMajorHealingPotion()
                           , new PatternMooncloth()
                           , new ImbuedVial()
                           , new EmptyVial()
                           , new LeadedVial()
                           , new SuperiorHealingPotion()
                           , new GreaterManaPotion()
                           , new CrystalVial()
  } ;
Faction = Factions.Everlook;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Equip( new Item( 7467, InventoryTypes.OneHand, 14, 2, 13, 0, 0, 0, 0 ), new Item( 6535, InventoryTypes.HeldInHand, 0, 2, 23, 0, 0, 0, 0 ));
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};}
}
public class NinaLightbrew : BaseCreature 
 { 
public  NinaLightbrew() : base() 
 { 
Model = 7390;
AttackSpeed= 2000;
BoundingRadius = 0.208000f ;
Name = "Nina Lightbrew" ;
Flags1 = 0480046 ;
Id = 8178 ; 
Guild = "Alchemy Supplies";
Size = 1f;
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
NpcText00 = "Greetings $N, I am Nina Lightbrew." ;
BaseMana = 0 ;
Sells = new Item[] { new ImbuedVial()
                           , new EmptyVial()
                           , new LeadedVial()
                           , new SuperiorHealingPotion()
                           , new GreaterManaPotion()
                           , new CrystalVial()
                           , new RecipeElixirOfDemonslaying()
  } ;
Faction = Factions.Stormwind;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
}
}
public class Rartar : BaseCreature 
 { 
public  Rartar() : base() 
 { 
Model = 7389;
AttackSpeed= 2000;
BoundingRadius = 0.372000f ;
Name = "Rartar" ;
Flags1 = 08400046 ;
Id = 8177 ; 
Guild = "Alchemy Supplies";
Size = 1f;
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
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1825 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 49, 63 );
NpcText00 = "Greetings $N, I am Rartar." ;
BaseMana = 0 ;
Sells = new Item[] { new ImbuedVial()
                           , new EmptyVial()
                           , new LeadedVial()
                           , new SuperiorHealingPotion()
                           , new GreaterManaPotion()
                           , new CrystalVial()
                           , new RecipeElixirOfDemonslaying()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Equip( new Item( 7465, InventoryTypes.TwoHanded, 14, 1, 13,  0, 0, 0, 0 ));
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
}
}
public class Bronk : BaseCreature 
 { 
public  Bronk() : base() 
 { 
Model = 7380;
AttackSpeed= 2000;
BoundingRadius = 0.974700f ;
Name = "Bronk" ;
Flags1 = 08480046 ;
Id = 8158 ; 
Guild = "Alchemy Supplies";
Size = 1f;
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
BaseHitPoints = 1825 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 4.05f ;
SetDamage ( 49, 63 );
NpcText00 = "Greetings $N, I am Bronk." ;
BaseMana = 0 ;
Sells = new Item[] { new ImbuedVial()
                           , new EmptyVial()
                           , new LeadedVial()
                           , new SuperiorHealingPotion()
                           , new RecipeNatureProtectionPotion()
                           , new GreaterManaPotion()
                           , new CrystalVial()
                           , new RecipeGhostDye()
  } ;
Faction = Factions.ThunderBluff;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Equip( new Item( 7465, InventoryTypes.TwoHanded, 14, 1, 13,  0, 0, 0, 0 ));
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
}
}
public class Logannas : BaseCreature 
 { 
public  Logannas() : base() 
 { 
Model = 7379;
AttackSpeed= 2000;
BoundingRadius = 0.389000f ;
Name = "Logannas" ;
Flags1 = 08480006 ;
Id = 8157 ; 
Guild = "Alchemy Supplies";
Size = 1f;
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
NpcText00 = "Greetings $N, I am Logannas." ;
BaseMana = 0 ;
Sells = new Item[] { new ImbuedVial()
                           , new EmptyVial()
                           , new LeadedVial()
                           , new SuperiorHealingPotion()
                           , new RecipeNatureProtectionPotion()
                           , new GreaterManaPotion()
                           , new CrystalVial()
                           , new RecipeGhostDye()
  } ;
Faction = Factions.Darnasus;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Equip( new Item( 7465, InventoryTypes.TwoHanded, 14, 1, 13,  0, 0, 0, 0 ));
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
}
}
public class AlchemistPestlezugg : BaseCreature 
 { 
public  AlchemistPestlezugg() : base() 
 { 
Model = 7215;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Alchemist Pestlezugg" ;
Flags1 = 08080006 ;
Id = 5594 ; 
Guild = "Alchemy Supplies";
Size = 1f;
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
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1825 ;
NpcFlags = (int)NpcActions.Vendor | (int)NpcActions.Trainer ;
CombatReach = 1.5f ;
SetDamage ( 49, 63 );
NpcText00 = "Greetings $N, I am Alchemist Pestlezugg." ;
BaseMana = 0 ;
Sells = new Item[] { new RecipeTransmuteArcanite()
                           , new ImbuedVial()
                           , new EmptyVial()
                           , new LeadedVial()
                           , new RecipeNatureProtectionPotion()
                           , new CrystalVial()
                           , new RecipePhilosophersStone()
                           , new RecipeTransmuteIronToGold()
                           , new RecipeTransmuteMithrilToTruesilver()
  } ;
Faction = Factions.Gadgetzan;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
}
}

public class SoolieBerryfizz : BaseCreature 
 { 
public  SoolieBerryfizz() : base() 
 { 
Model = 3125;
AttackSpeed= 2000;
BoundingRadius = 0.351900f ;
Name = "Soolie Berryfizz" ;
Flags1 = 08480046 ;
Id = 5178 ; 
Guild = "Alchemy Supplies";
Size = 1f;
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
NpcText00 = "Greetings $N, I am Soolie Berryfizz." ;
BaseMana = 0 ;
Sells = new Item[] { new RecipeElixirOfSuperiorDefense()
                           , new ImbuedVial()
                           , new EmptyVial()
                           , new LeadedVial()
                           , new RecipeFreeActionPotion()
                           , new CrystalVial()
  } ;
Faction = Factions.GnomereganExiles;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Equip( new Item( 7466, InventoryTypes.TwoHanded, 14, 1, 13,  0, 0, 0, 0 ), new Item( 6535, InventoryTypes.HeldInHand, 0, 2, 23, 2, 0, 0, 0 ));
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
}
}
public class UmaBartulm : BaseCreature 
 { 
public  UmaBartulm() : base() 
 { 
Model = 4857;
AttackSpeed= 2000;
BoundingRadius = 0.208000f ;
Name = "Uma Bartulm" ;
Flags1 = 08480046 ;
Id = 4899 ; 
Guild = "Herbalism & Alchemy Supplies";
Size = 1f;
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
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1504 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 40, 52 );
NpcText00 = "Greetings $N, I am Uma Bartulm." ;
BaseMana = 0 ;
Sells = new Item[] { new GreaterHealingPotion()
                           , new ImbuedVial()
                           , new EmptyVial()
                           , new LeadedVial()
                           , new ManaPotion()
                           , new CopperRod()
                           , new CrystalVial()
  } ;
Faction = Factions.Stormwind;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Equip( new Item( 7475, InventoryTypes.TwoHanded, 14, 2, 13,  0, 0, 0, 0 ));
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
}
}
}