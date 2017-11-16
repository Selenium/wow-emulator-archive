//originally Scripted By DiScS Converter
//Edited by *place name here*
using System;
using Server.Items;

////////////////////
namespace Server.Creatures
{
public class Pakwa : BaseCreature 
 { 
public  Pakwa() : base() 
 { 
Model = 7627;
AttackSpeed= 2000;
BoundingRadius = 0.872500f ;
Name = "Pakwa" ;
Flags1 = 0x08480046 ;
Id = 8364 ; 
Guild = "Bag Vendor";
Size = 1f;
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
NpcFlags = 128 ;
CombatReach = 3.75f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Pakwa." ;
BaseMana = 0 ;
Sells = new Item[] { new SmallBrownPouch()
                           , new HeavyBrownBag()
                           , new BrownLeatherSatchel()
                           , new HugeBrownSack()
  } ;
Faction = Factions.ThunderBluff;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 23172, InventoryTypes.OneHand, 14, 1, 13, 0, 0, 0, 0 ), new Item( 23172, InventoryTypes.OneHand, 0, 1, 23, 0, 0, 0, 0 ));
}
}
public class Pithwick : BaseCreature 
 { 
public  Pithwick() : base() 
 { 
Model = 3107;
AttackSpeed= 2000;
BoundingRadius = 0.351900f ;
Name = "Pithwick" ;
Flags1 = 0x08480046 ;
Id = 5132 ; 
Guild = "Bag Vendor";
Size = 1f;
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
NpcFlags = 128 ;
CombatReach = 1.725f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Pithwick." ;
BaseMana = 0 ;
Sells = new Item[] { new SmallBrownPouch()
                           , new HeavyBrownBag()
                           , new BrownLeatherSatchel()
                           , new HugeBrownSack()
  } ;
Faction = Factions.GnomereganExiles;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 5569, InventoryTypes.OneHand, 14, 1, 21, 7, 0, 0, 0 ));
}
}
public class JonathanChambers : BaseCreature 
 { 
public  JonathanChambers() : base() 
 { 
Model = 2633;
AttackSpeed= 2000;
BoundingRadius = 0.383000f ;
Name = "Jonathan Chambers" ;
Flags1 = 0x018480046 ;
Id = 4590 ; 
Guild = "Bag Vendor";
Size = 1f;
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
NpcText00 = "Greetings $N, I am Jonathan Chambers." ;
BaseMana = 0 ;
Sells = new Item[] { new SmallBrownPouch()
                           , new HeavyBrownBag()
                           , new BrownLeatherSatchel()
                           , new HugeBrownSack()
  } ;
Faction = Factions.Undercity;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 23172, InventoryTypes.OneHand, 14, 1, 13, 0, 0, 0, 0 ), new Item( 23172, InventoryTypes.HeldInHand, 0, 1, 23, 0, 0, 0, 0 ));
}
}
public class Yldan : BaseCreature 
 { 
public  Yldan() : base() 
 { 
Model = 2277;
AttackSpeed= 2000;
BoundingRadius = 0.389000f ;
Name = "Yldan" ;
Flags1 = 0x08480046 ;
Id = 4230 ; 
Guild = "Bag Merchant";
Size = 1f;
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
NpcText00 = "Greetings $N, I am Yldan." ;
BaseMana = 0 ;
Sells = new Item[] { new SmallBrownPouch()
                           , new HeavyBrownBag()
                           , new BrownLeatherSatchel()
                           , new HugeBrownSack()
  } ;
Faction = Factions.Darnasus;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 23172, InventoryTypes.OneHand, 14, 1, 13, 0, 0, 0, 0 ));
}
}
public class KalyimahStormcloud : BaseCreature 
 { 
public  KalyimahStormcloud() : base() 
 { 
Model = 4097;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Kalyimah Stormcloud" ;
Flags1 = 0x08480046 ;
Id = 3487 ; 
Guild = "Bags & Sacks";
Size = 1f;
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
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 944 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 25, 32 );
NpcText00 = "Greetings $N, I am Kalyimah Stormcloud." ;
BaseMana = 0 ;
Sells = new Item[] { new SmallBrownPouch()
                           , new HeavyBrownBag()
                           , new BrownLeatherSatchel()
  } ;
Faction = Factions.DarkspearTrolls;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 23172, InventoryTypes.OneHand, 14, 1, 13, 0, 0, 0, 0 ),  new Item(23172, InventoryTypes.Back, 0, 1, 23, 0, 0, 0, 0 ));
}
}
public class Gotri : BaseCreature 
 { 
public  Gotri() : base() 
 { 
Model = 1391;
AttackSpeed= 2000;
BoundingRadius = 0.372000f ;
Name = "Gotri" ;
Flags1 = 0x08480046 ;
Id = 3369 ; 
Guild = "Bag Vendor";
Size = 1f;
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
NpcText00 = "Greetings $N, I am Gotri." ;
BaseMana = 0 ;
Sells = new Item[] { new SmallBrownPouch()
                           , new HeavyBrownBag()
                           , new BrownLeatherSatchel()
                           , new HugeBrownSack()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7477, InventoryTypes.OneHand, 4, 2, 13, 3, 0, 0, 0 ),  new Item( 23172, InventoryTypes.OneHand, 4, 0, 23, 0, 0, 0, 0 ));
}
}
public class AlyssaGriffith : BaseCreature 
 { 
public  AlyssaGriffith() : base() 
 { 
Model = 1520;
AttackSpeed= 2000;
BoundingRadius = 0.208000f ;
Name = "Alyssa Griffith" ;
Flags1 = 0x08480046 ;
Id = 1321 ; 
Guild = "Bag Vendor";
Size = 1f;
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
NpcText00 = "Greetings $N, I am Alyssa Griffith." ;
BaseMana = 0 ;
Sells = new Item[] { new SmallBrownPouch()
                           , new HeavyBrownBag()
                           , new BrownLeatherSatchel()
                           , new HugeBrownSack()
  } ;
Faction = Factions.Stormwind;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 23318, InventoryTypes.OneHand, 14, 1, 13, 0, 0, 0, 0 ));
}
}

}