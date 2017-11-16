//originally Scripted By DiScS Converter
//Edited by *place name here*
using System;
using Server.Items;
using Server;

////////////////////
namespace Server.Creatures
{
public class KelseyYance : BaseCreature 
 { 
public  KelseyYance() : base() 
 { 
Model = 4482;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Kelsey Yance" ;
Flags1 = 0x08080046 ;
Id = 2664 ; 
Guild = "Cook";
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
NpcText00 = "Greetings $N, I am Kelsey Yance." ;
BaseMana = 0 ;
Sells = new Item[] { new RecipeCookedGlossyMightfish()
                           , new RecipeFiletOfRedgill()
                           , new RecipeHotSmokedBass()
                           , new RefreshingSpringWater()
                           , new RecipeMithrilHeadTrout()
                           , new MildSpices()
                           , new HotSpices()
                           , new SoothingSpices()
                           , new RecipeGiantClamScorcho()
                           , new RecipeRockscaleCod()
  } ;
Faction = Factions.BootyBay;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
}
}
public class NaalMistrunner : BaseCreature 
 { 
public  NaalMistrunner() : base() 
 { 
Model = 2095;
AttackSpeed= 2000;
BoundingRadius = 0.974700f ;
Name = "Naal Mistrunner" ;
Flags1 = 0x08480046 ;
Id = 3027 ; 
Guild = "Cooking Supplier";
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
NpcText00 = "Greetings $N, I am Naal Mistrunner." ;
BaseMana = 0 ;
Sells = new Item[] { new RefreshingSpringWater()
                           , new MildSpices()
                           , new HotSpices()
                           , new SoothingSpices()
                           , new RecipeLongjawMudSnapper()
                           , new RecipeBristleWhiskerCatfish()
  } ;
Faction = Factions.ThunderBluff;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 6434, InventoryTypes.OneHand, 15, 1, 13, 3, 0, 0, 0 ), new Item( 6434, InventoryTypes.HeldInHand, 0, 1, 23, 7, 0, 0, 0 ));
}
}
public class ErikaTate : BaseCreature 
 { 
public  ErikaTate() : base() 
 { 
Model = 3288;
AttackSpeed= 2000;
BoundingRadius = 0.208000f ;
Name = "Erika Tate" ;
Flags1 = 0x08480046 ;
Id = 5483 ; 
Guild = "Cooking Supplier";
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
NpcText00 = "Greetings $N, I am Erika Tate." ;
BaseMana = 0 ;
Sells = new Item[] { new RefreshingSpringWater()
                           , new MildSpices()
                           , new HotSpices()
                           , new SoothingSpices()
  } ;
Faction = Factions.IronForge;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7468, InventoryTypes.OneHand, 14, 2, 13, 3, 0, 0, 0 ));
}
}
public class EmrulRiknussun : BaseCreature 
 { 
public  EmrulRiknussun() : base() 
 { 
Model = 3095;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Emrul Riknussun" ;
Flags1 = 0x08480046 ;
Id = 5160 ; 
Guild = "Cooking Supplier";
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
NpcText00 = "Greetings $N, I am Emrul Riknussun." ;
BaseMana = 0 ;
Sells = new Item[] { new RefreshingSpringWater()
                           , new MildSpices()
                           , new HotSpices()
                           , new SoothingSpices()
  } ;
Faction = Factions.IronForge;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7468, InventoryTypes.OneHand, 14, 2, 13, 3, 0, 0, 0 ));
}
}
public class RonaldBurch : BaseCreature 
 { 
public  RonaldBurch() : base() 
 { 
Model = 2647;
AttackSpeed= 2000;
BoundingRadius = 0.383000f ;
Name = "Ronald Burch" ;
Flags1 = 0x018480046 ;
Id = 4553 ; 
Guild = "Cooking Supplier";
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
NpcText00 = "Greetings $N, I am Ronald Burch." ;
BaseMana = 0 ;
Sells = new Item[] { new RefreshingSpringWater()
                           , new MildSpices()
                           , new HotSpices()
                           , new SoothingSpices()
                           , new RecipeBristleWhiskerCatfish()
                           , new RecipeRainbowFinAlbacore()
  } ;
Faction = Factions.Undercity;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7443, InventoryTypes.OneHand, 4, 2, 13, 7, 0, 0, 0 ));
}
}
public class Fyldan : BaseCreature 
 { 
public  Fyldan() : base() 
 { 
Model = 2254;
AttackSpeed= 2000;
BoundingRadius = 0.389000f ;
Name = "Fyldan" ;
Flags1 = 0x08480046 ;
Id = 4223 ; 
Guild = "Cooking Supplier";
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
NpcText00 = "Greetings $N, I am Fyldan." ;
BaseMana = 0 ;
Sells = new Item[] { new RefreshingSpringWater()
                           , new MildSpices()
                           , new HotSpices()
                           , new SoothingSpices()
  } ;
Faction = Factions.Darnasus;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7468, InventoryTypes.OneHand, 14, 2, 13, 3, 0, 0, 0 ));
}
}
	public class Xento : BaseCreature 
 { 
public  Xento() : base() 
 { 
Model = 2735;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Xen'to" ;
Flags1 = 0x08480046 ;
Id = 3400 ; 
Guild = "Cooking Supplier";
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
NpcText00 = "Greetings $N, I am Xen'to." ;
BaseMana = 0 ;
Sells = new Item[] { new RefreshingSpringWater()
                           , new MildSpices()
                           , new HotSpices()
                           , new SoothingSpices()
  } ;
Faction = Factions.DarkspearTrolls;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7468, InventoryTypes.OneHand, 14, 2, 13, 3, 0, 0, 0 ), new Item( 7469, InventoryTypes.OneHand, 4, 2, 13, 7, 0, 0, 0 ));
}
}
public class Wulan : BaseCreature 
 { 
public  Wulan() : base() 
 { 
Model = 12036;
AttackSpeed= 1693;
BoundingRadius = 1.00f ;
Name = "Wulan" ;
Flags1 = 0x08480046 ;
Id = 12033 ; 
Guild = "Cooking Supplies";
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
NpcText00 = "Greetings $N, I am Wulan." ;
BaseMana = 1503 ;
Sells = new Item[] { new RefreshingSpringWater()
                           , new ExpertCookbook()
                           , new RecipeMithrilHeadTrout()
                           , new MildSpices()
                           , new HotSpices()
                           , new SoothingSpices()
                           , new RecipeRockscaleCod()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}
public class Nyoma : BaseCreature 
 { 
public  Nyoma() : base() 
 { 
Model = 4236;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Nyoma" ;
Flags1 = 0x08480046 ;
Id = 4265 ; 
Guild = "Cooking Supplies";
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
NpcText00 = "Greetings $N, I am Nyoma." ;
BaseMana = 0 ;
Sells = new Item[] { new RefreshingSpringWater()
                           , new MildSpices()
                           , new HotSpices()
                           , new SoothingSpices()
                           , new RecipeBrilliantSmallfish()
                           , new RecipeLongjawMudSnapper()
  } ;
Faction = Factions.Darnasus;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}
public class GloriaFemmel : BaseCreature 
 { 
public  GloriaFemmel() : base() 
 { 
Model = 3375;
AttackSpeed= 2000;
BoundingRadius = 0.208000f ;
Name = "Gloria Femmel" ;
Flags1 = 0x08480046 ;
Id = 3085 ; 
Guild = "Cooking Supplies";
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
NpcText00 = "Greetings $N, I am Gloria Femmel." ;
BaseMana = 0 ;
Sells = new Item[] { new RefreshingSpringWater()
                           , new MildSpices()
                           , new HotSpices()
                           , new SoothingSpices()
  } ;
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}
}