//originally Scripted By DiScS Converter
//Edited by *place name here*
using System;
using Server.Items;

////////////////////
namespace Server.Creatures
{
public class HaeWilani : BaseCreature 
 { 
public  HaeWilani() : base() 
 { 
Model = 12049;
AttackSpeed= 1693;
BoundingRadius = 1.00f ;
Name = "Hae'Wilani" ;
Flags1 = 0x08480046 ;
Id = 12045 ; 
Guild = "Axecrafter";
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
CombatReach = 11.00f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Hae'Wilani." ;
BaseMana = 1503 ;
Sells = new Item[] { new MercilessAxe()
                           , new MidnightAxe()
                           , new CrescentAxe()
                           , new Bullova()
                           , new Francisca()
                           , new GreatAxe()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 25470, InventoryTypes.OneHand, 0, 1, 13, 3, 0, 0, 0 ));
}
}
public class KathrumAxehand : BaseCreature 
 { 
public  KathrumAxehand() : base() 
 { 
Model = 3305;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Kathrum Axehand" ;
Flags1 = 0x08480046 ;
Id = 5509 ; 
Guild = "Axe Merchant";
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
NpcText00 = "Greetings $N, I am Kathrum Axehand." ;
BaseMana = 0 ;
Sells = new Item[] { new CrescentAxe()
                           , new Bullova()
                           , new Francisca()
                           , new GreatAxe()
  } ;
Faction = Factions.Stormwind;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7508, InventoryTypes.OneHand, 0, 1, 13, 3, 0, 0, 0 ));
}
}
public class HegnarSwiftaxe : BaseCreature 
 { 
public  HegnarSwiftaxe() : base() 
 { 
Model = 3075;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Hegnar Swiftaxe" ;
Flags1 = 0x08480046 ;
Id = 5119 ; 
Guild = "Axe Merchant";
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
NpcText00 = "Greetings $N, I am Hegnar Swiftaxe." ;
BaseMana = 0 ;
Sells = new Item[] { new Tabar()
                           , new BeardedAxe()
                           , new Cleaver()
                           , new CrescentAxe()
                           , new Bullova()
                           , new Francisca()
                           , new GreatAxe()
                           , new Hatchet()
                           , new BattleAxe()
                           , new DoubleAxe()
  } ;
Faction = Factions.IronForge;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7508, InventoryTypes.OneHand, 0, 1, 13, 3, 0, 0, 0 ));
}
}
public class Glorandiir : BaseCreature 
 { 
public  Glorandiir() : base() 
 { 
Model = 2257;
AttackSpeed= 2000;
BoundingRadius = 0.389000f ;
Name = "Glorandiir" ;
Flags1 = 0x08480046 ;
Id = 4232 ; 
Guild = "Axe Merchant";
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
NpcText00 = "Greetings $N, I am Glorandiir." ;
BaseMana = 0 ;
Sells = new Item[] { new Tabar()
                           , new MercilessAxe()
                           , new BeardedAxe()
                           , new Cleaver()
                           , new CrescentAxe()
                           , new Bullova()
                           , new Francisca()
                           , new GreatAxe()
                           , new Hatchet()
                           , new BattleAxe()
                           , new DoubleAxe()
  } ;
Faction = Factions.Darnasus;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7428, InventoryTypes.OneHand, 0, 1, 13, 3, 0, 0, 0 ));}
}
public class DelgoRagetotem : BaseCreature 
 { 
public  DelgoRagetotem() : base() 
 { 
Model = 2084;
AttackSpeed= 2000;
BoundingRadius = 0.974700f ;
Name = "Delgo Ragetotem" ;
Flags1 = 0x08480046 ;
Id = 3019 ; 
Guild = "Axe Merchant";
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
NpcText00 = "Greetings $N, I am Delgo Ragetotem." ;
BaseMana = 0 ;
Sells = new Item[] { new Tabar()
                           , new MercilessAxe()
                           , new BeardedAxe()
                           , new Cleaver()
                           , new CrescentAxe()
                           , new Bullova()
                           , new Francisca()
                           , new GreatAxe()
                           , new Hatchet()
                           , new BattleAxe()
                           , new DoubleAxe()
  } ;
Faction = Factions.ThunderBluff;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 19549, InventoryTypes.OneHand, 0, 1, 13, 3, 0, 0, 0 ));

}
}
	
}