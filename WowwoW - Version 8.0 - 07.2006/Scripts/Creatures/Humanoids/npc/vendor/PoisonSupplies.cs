//originally Scripted By DiScS Converter
//Edited by *place name here*
using System;
using Server.Items;
using Server;

////////////////////
namespace Server.Creatures
{
public class Malissa : BaseCreature 
 { 
public  Malissa() : base() 
 { 
Model = 4337;
AttackSpeed= 1500;
BoundingRadius = 0.208000f ;
Name = "Malissa" ;
Flags1 = 0x08480046 ;
Id = 3135 ; 
Guild = "Poison Supplier";
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
NpcText00 = "Greetings $N, I am Malissa." ;
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
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 10825, InventoryTypes.OneHand, 14, 1, 13, 0, 0, 0, 0 ));
}
}
public class GeraldCrawley : BaseCreature 
 { 
public  GeraldCrawley() : base() 
 { 
Model = 3381;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Gerald Crawley" ;
Flags1 = 0x08480046 ;
Id = 3090 ; 
Guild = "Poison Supplier";
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
NpcText00 = "Greetings $N, I am Gerald Crawley." ;
BaseMana = 0 ;
Sells = new Item[] { new DustOfDecay()
                           , new EssenceOfPain()
                           , new EmptyVial()
                           , new LeadedVial()
                           , new LethargyRoot()
                           , new ThievesTools()
                           , new FlashPowder()
                           , new Deathweed()
                           , new TinyBronzeKey()
                           , new TinyIronKey()
                           , new EssenceOfAgony()
                           , new DustOfDeterioration()
                           , new CrystalVial()
  } ;
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7466, InventoryTypes.OneHand, 14, 1, 13, 0, 0, 0, 0 ), new Item( 6532, InventoryTypes.HeldInHand, 0, 2, 23, 0, 0, 0, 0 ));
}
}
public class SloanMcCoy : BaseCreature 
 { 
public  SloanMcCoy() : base() 
 { 
Model = 1523;
AttackSpeed= 2000;
BoundingRadius = 0.208000f ;
Name = "Sloan McCoy" ;
Flags1 = 0x08480046 ;
Id = 1326 ; 
Guild = "Poison Supplier";
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
NpcText00 = "Greetings $N, I am Sloan McCoy." ;
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
Faction = Factions.Stormwind;
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7466, InventoryTypes.OneHand, 14, 1, 13, 0, 0, 0, 0 ), new Item( 7473, InventoryTypes.OneHand, 14, 1, 13, 0, 0, 0, 0 ));
}
}
public class PatriceDwyer : BaseCreature 
 { 
public  PatriceDwyer() : base() 
 { 
Model = 3543;
AttackSpeed= 2000;
BoundingRadius = 0.383000f ;
Name = "Patrice Dwyer" ;
Flags1 = 0x08480046 ;
Id = 3551 ; 
Guild = "Poison Supplies";
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
NpcText00 = "Greetings $N, I am Patrice Dwyer." ;
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
Faction = Factions.Undercity;
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7473, InventoryTypes.OneHand, 14, 1, 13, 0, 0, 0, 0 ), new Item( 6434, InventoryTypes.HeldInHand, 0, 2, 23, 0, 0, 0, 0 ));
}
}

	
}