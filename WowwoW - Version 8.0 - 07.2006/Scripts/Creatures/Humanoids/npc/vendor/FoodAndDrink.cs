//originally Scripted By DiScS Converter
//Edited by *place name here*
using System;
using Server.Items;
using Server.Quests;

////////////////////
namespace Server.Creatures
{
public class EmmithueSmails : BaseCreature 
 { 
public  EmmithueSmails() : base() 
 { 
Model = 14529;
AttackSpeed= 2000;
BoundingRadius = 0.351900f ;
Name = "Emmithue Smails" ;
Flags1 = 0x06 ;
Id = 14481 ; 
Guild = "Sweet Treats";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 10 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 0 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.725f ;
SetDamage ( 32, 42 );
NpcText00 = "Hello" ;
BaseMana = 0 ;
Sells = new Item[] { new MoonbrookRiotTaffy()
                           , new StyleensSourSuckerpop()
                           , new BellarasNutterbar()
                           , new TiguleAndFororsStrawberryIceCream()
  } ;
Faction = Factions.GnomereganExiles;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
}
}
public class AlowiciousCzervik : BaseCreature 
 { 
public  AlowiciousCzervik() : base() 
 { 
Model = 14530;
AttackSpeed= 1739;
BoundingRadius = 0.306000f ;
Name = "Alowicious Czervik" ;
Flags1 = 0x06 ;
Id = 14480 ; 
Guild = "Sweet Treats";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 10 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 0 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 32, 42 );
NpcText00 = "Hello" ;
BaseMana = 0 ;
Sells = new Item[] { new MoonbrookRiotTaffy()
                           , new StyleensSourSuckerpop()
                           , new BellarasNutterbar()
                           , new TiguleAndFororsStrawberryIceCream()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
}
}
public class NardstrumCopperpinch : BaseCreature 
 { 
public  NardstrumCopperpinch() : base() 
 { 
Model = 13346;
AttackSpeed= 1693;
BoundingRadius = 1.00f ;
Name = "Nardstrum Copperpinch" ;
Flags1 = 0x08400046 ;
Id = 13429 ; 
Guild = "Smokywood Pastures";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 30, 30 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 11.00f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Nardstrum Copperpinch." ;
BaseMana = 1503 ;
Sells = new Item[] { new HolidaySpices()
                           , new Mistletoe()
                           , new HolidaySpirits()
                           , new RecipeGingerbreadCookie()
                           , new RecipeEggNog()
                           , new Snowball()
                           , new BlueRibbonedWrappingPaper()
                           , new GreenRibbonedWrappingPaper()
                           , new PurpleRibbonedWrappingPaper()
                           , new CandyCane()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}
public class JaycrueCopperpinch : BaseCreature 
 { 
public  JaycrueCopperpinch() : base() 
 { 
Model = 13345;
AttackSpeed= 1693;
BoundingRadius = 1.00f ;
Name = "Jaycrue Copperpinch" ;
Flags1 = 0x08400046 ;
Id = 13430 ; 
Guild = "Smokywood Pastures";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 30, 30 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 11.00f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Jaycrue Copperpinch." ;
BaseMana = 1503 ;
Sells = new Item[] { new GreatfathersWinterAle()
                           , new SteamwheedleFizzySpirits()
                           , new BlendedBeanBrew()
                           , new GreenGardenTea()
                           , new HolidayCheesewheel()
                           , new GraccusHomemadeMeatPie()
                           , new SpicyBeefstick()
  } ;
  Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};


}
}
public class WhulwertCopperpinch : BaseCreature 
 { 
public  WhulwertCopperpinch() : base() 
 { 
Model = 13348;
AttackSpeed= 1693;
BoundingRadius = 1.00f ;
Name = "Whulwert Copperpinch" ;
Flags1 = 0x08400046 ;
Id = 13431 ; 
Guild = "Smokywood Pastures";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 30, 30 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 11.00f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Whulwert Copperpinch." ;
BaseMana = 1503 ;
Sells = new Item[] { new GreatfathersWinterAle()
                           , new SteamwheedleFizzySpirits()
                           , new BlendedBeanBrew()
                           , new GreenGardenTea()
                           , new HolidayCheesewheel()
                           , new GraccusHomemadeMeatPie()
                           , new SpicyBeefstick()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};

}
}
public class SeersaCopperpinch : BaseCreature 
 { 
public  SeersaCopperpinch() : base() 
 { 
Model = 13347;
AttackSpeed= 1693;
BoundingRadius = 1.00f ;
Name = "Seersa Copperpinch" ;
Flags1 = 0x08400046 ;
Id = 13432 ; 
Guild = "Smokywood Pastures";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 30, 30 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 11.00f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Seersa Copperpinch." ;
BaseMana = 1503 ;
Sells = new Item[] { new HolidaySpices()
                           , new Mistletoe()
                           , new HolidaySpirits()
                           , new RecipeGingerbreadCookie()
                           , new RecipeEggNog()
                           , new Snowball()
                           , new BlueRibbonedWrappingPaper()
                           , new GreenRibbonedWrappingPaper()
                           , new PurpleRibbonedWrappingPaper()
                           , new CandyCane()
  } ;
Faction = Factions.Friend;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}
public class WulmortJinglepocket : BaseCreature 
 { 
public  WulmortJinglepocket() : base() 
 { 
Model = 13349;
AttackSpeed= 1693;
BoundingRadius = 1.00f ;
Name = "Wulmort Jinglepocket" ;
Flags1 = 0x08400046 ;
Id = 13433 ; 
Guild = "Smokywood Pastures";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 30, 30 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 11.00f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Wulmort Jinglepocket." ;
BaseMana = 1503 ;
Sells = new Item[] { new HolidaySpices()
                           , new Mistletoe()
                           , new HolidaySpirits()
                           , new RecipeGingerbreadCookie()
                           , new RecipeEggNog()
                           , new Snowball()
                           , new BlueRibbonedWrappingPaper()
                           , new GreenRibbonedWrappingPaper()
                           , new PurpleRibbonedWrappingPaper()
                           , new CandyCane()
  } ;
Faction = Factions.Friend;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}
public class MaceyJinglepocket : BaseCreature 
 { 
public  MaceyJinglepocket() : base() 
 { 
Model = 13350;
AttackSpeed= 1693;
BoundingRadius = 1.00f ;
Name = "Macey Jinglepocket" ;
Flags1 = 0x08400046 ;
Id = 13434 ; 
Guild = "Smokywood Pastures";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 30, 30 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 11.00f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Macey Jinglepocket." ;
BaseMana = 1503 ;
Sells = new Item[] { new GreatfathersWinterAle()
                           , new SteamwheedleFizzySpirits()
                           , new BlendedBeanBrew()
                           , new GreenGardenTea()
                           , new HolidayCheesewheel()
                           , new GraccusHomemadeMeatPie()
                           , new SpicyBeefstick()
  } ;
Faction = Factions.Friend;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}
public class KholeJinglepocket : BaseCreature 
 { 
public  KholeJinglepocket() : base() 
 { 
Model = 13356;
AttackSpeed= 1693;
BoundingRadius = 1.00f ;
Name = "Khole Jinglepocket" ;
Flags1 = 0x08400046 ;
Id = 13435 ; 
Guild = "Smokywood Pastures";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 30, 30 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 11.00f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Khole Jinglepocket." ;
BaseMana = 1503 ;
Sells = new Item[] { new HolidaySpices()
                           , new Mistletoe()
                           , new HolidaySpirits()
                           , new RecipeGingerbreadCookie()
                           , new RecipeEggNog()
                           , new Snowball()
                           , new BlueRibbonedWrappingPaper()
                           , new GreenRibbonedWrappingPaper()
                           , new PurpleRibbonedWrappingPaper()
                           , new CandyCane()
  } ;
Faction = Factions.Friend;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}
public class GuchieJinglepocket : BaseCreature 
 { 
public  GuchieJinglepocket() : base() 
 { 
Model = 13355;
AttackSpeed= 1693;
BoundingRadius = 1.00f ;
Name = "Guchie Jinglepocket" ;
Flags1 = 0x08400046 ;
Id = 13436 ; 
Guild = "Smokywood Pastures";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 30, 30 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 11.00f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Guchie Jinglepocket." ;
BaseMana = 1503 ;
Sells = new Item[] { new GreatfathersWinterAle()
                           , new SteamwheedleFizzySpirits()
                           , new BlendedBeanBrew()
                           , new GreenGardenTea()
                           , new HolidayCheesewheel()
                           , new GraccusHomemadeMeatPie()
                           , new SpicyBeefstick()
  } ;
Faction = Factions.Friend;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}

public class PenneyCopperpinch : BaseCreature 
 { 
public  PenneyCopperpinch() : base() 
 { 
Model = 13344;
AttackSpeed= 1693;
BoundingRadius = 1.00f ;
Name = "Penney Copperpinch" ;
Flags1 = 0x08400046 ;
Id = 13420 ; 
Guild = "Smokywood Pastures";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 30, 30 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 11.00f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Penney Copperpinch." ;
BaseMana = 1503 ;
Sells = new Item[] { new HolidaySpices()
                           , new Mistletoe()
                           , new HolidaySpirits()
                           , new RecipeGingerbreadCookie()
                           , new RecipeEggNog()
                           , new Snowball()
                           , new BlueRibbonedWrappingPaper()
                           , new GreenRibbonedWrappingPaper()
                           , new PurpleRibbonedWrappingPaper()
                           , new CandyCane()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}
public class KaymardCopperpinch : BaseCreature 
 { 
public  KaymardCopperpinch() : base() 
 { 
Model = 13342;
AttackSpeed= 1693;
BoundingRadius = 1.00f ;
Name = "Kaymard Copperpinch" ;
Flags1 = 0x08400046 ;
Id = 13418 ; 
Guild = "Smokywood Pastures";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 30, 30 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1224 ;
NpcFlags = 2 ;
CombatReach = 11.00f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Kaymard Copperpinch." ;
BaseMana = 1503 ;
Sells = new Item[] { new GreatfathersWinterAle()
                           , new SteamwheedleFizzySpirits()
                           , new BlendedBeanBrew()
                           , new GreenGardenTea()
                           , new HolidayCheesewheel()
                           , new GraccusHomemadeMeatPie()
                           , new SpicyBeefstick()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}
public class Sraaz : BaseCreature 
 { 
public  Sraaz() : base() 
 { 
Model = 8353;
AttackSpeed= 2000;
BoundingRadius = 0.351900f ;
Name = "Sraaz" ;
Flags1 = 0x08480046 ;
Id = 9099 ; 
Guild = "Pie Vendor";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
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
NpcText00 = "Hello" ;
BaseMana = 0 ;
Sells = new Item[] { new HomemadeCherryPie()
  } ;
Faction = Factions.GnomereganExiles;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}
public class TarbanHearthgrain : BaseCreature 
 { 
public  TarbanHearthgrain() : base() 
 { 
Model = 7531;
AttackSpeed= 2000;
BoundingRadius = 0.974700f ;
Name = "Tarban Hearthgrain" ;
Flags1 = 0x08480046 ;
Id = 8307 ; 
Guild = "Baker";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 22 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 904 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 4.05f ;
SetDamage ( 24, 31 );
NpcText00 = "Greetings $N, I am Tarban Hearthgrain." ;
BaseMana = 0 ;
Sells = new Item[] { new RefreshingSpringWater()
                           , new MildSpices()
                           , new HotSpices()
                           , new SoothingSpices()
                           , new ToughHunkOfBread()
                           , new FreshlyBakedBread()
                           , new MoistCornbread()
                           , new MulgoreSpiceBread()
                           , new SoftBananaBread()
                           , new HomemadeCherryPie()
  } ;
Faction = Factions.ThunderBluff;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7443, InventoryTypes.OneHand, 2, 4, 2, 7, 0, 0, 0 ));
}
}
public class DirgeQuikcleave : BaseCreature 
 { 
public  DirgeQuikcleave() : base() 
 { 
Model = 7338;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Dirge Quikcleave" ;
Flags1 = 0x08080006 ;
Id = 8125 ; 
Guild = "Butcher";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
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
NpcText00 = "Greetings $N, I am Dirge Quikcleave." ;
BaseMana = 0 ;
Sells = new Item[] { new ToughJerky()
                           , new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
                           , new MoonberryJuice()
                           , new SweetNectar()
                           , new RecipeTenderWolfSteak()
                           , new HaunchOfMeat()
                           , new MuttonChop()
                           , new WildHogShank()
                           , new CuredHamSteak()
                           , new MorningGloryDew()
                           , new RoastedQuail()
  } ;
Faction = Factions.Gadgetzan;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 7431, InventoryTypes.OneHand , 2, 0, 1, 3, 0, 0, 0 ), new Item( 7431, InventoryTypes.OneHand , 2, 0, 1, 3, 0, 0, 0 ));
}
}
public class QuintisJonespyre : BaseCreature 
 { 
public  QuintisJonespyre() : base() 
 { 
Model = 6984;
AttackSpeed= 2000;
BoundingRadius = 0.389000f ;
Name = "Quintis Jonespyre" ;
Flags1 = 0x08480006 ;
Id = 7879 ; 
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 55 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 2226 ;
NpcFlags = 2 ;
CombatReach = 1.5f ;
SetDamage ( 60, 77 );
NpcText00 = "Greetings $N, I am Quintis Jonespyre." ;
BaseMana = 2117 ;
Sells = new Item[] { new EvergreenPouch()
                           , new PacketOfTharlendrisSeeds()
  } ;
Faction = Factions.Darnasus;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
}
}
public class GreganBrewspewer : BaseCreature 
 { 
public  GreganBrewspewer() : base() 
 { 
Model = 6995;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Gregan Brewspewer" ;
Flags1 = 0x08000046 ;
Id = 7775 ; 
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
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
CombatReach = 1.500000f ;
SetDamage ( 49, 63 );
NpcText00 = "Greetings $N, I am Gregan Brewspewer." ;
BaseMana = 0 ;
Sells = new Item[] { new Bait()
  } ;
Faction = Factions.Friend;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
}
}
public class KalinWindflight : BaseCreature 
 { 
public  KalinWindflight() : base() 
 { 
Model = 6991;
AttackSpeed= 1273;
BoundingRadius = 1.00f ;
Name = "Kalin Windflight" ;
Flags1 = 0x08000046 ;
Id = 7772 ; 
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 60 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 2426 ;
NpcFlags = 0 ;
CombatReach = 1.5f ;
SetDamage ( 65, 85 );
NpcText00 = "Hello" ;
BaseMana = 3005 ;
Sells = new Item[] { new ColossalParachute()
  } ;
Faction = Factions.Friend;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
Equip( new Item( 2840, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
}
}
public class AlessandroLuca : BaseCreature 
 { 
public  AlessandroLuca() : base() 
 { 
Model = 6837;
AttackSpeed= 2000;
BoundingRadius = 0.383000f ;
Name = "Alessandro Luca" ;
Flags1 = 0x018480046 ;
Id = 7683 ; 
Guild = "Blue Moon Odds and Ends";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 35 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Alessandro Luca." ;
BaseMana = 0 ;
Sells = new Item[] { new FieldTestingKit()
  } ;
Faction = Factions.Undercity;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 23319, InventoryTypes.OneHand, 2, 14, 1, 0, 0, 0, 0 ));
}
}
public class MarinNoggenfogger : BaseCreature 
 { 
public  MarinNoggenfogger() : base() 
 { 
Model = 7185;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Marin Noggenfogger" ;
Flags1 = 0x08080046 ;
Id = 7564 ; 
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 40 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1625 ;
NpcFlags = 07 ;
CombatReach = 1.5f ;
SetDamage ( 43, 56 );
NpcText00 = "Hello" ;
BaseMana = 0 ;
Sells = new Item[] { new NoggenfoggerElixir()
  } ;
Faction = Factions.Gadgetzan;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
Equip( new Item( 122236, InventoryTypes.OneHand, 2, 4, 2, 7, 0, 0, 0 ));
}
}
	public class FalkhaanIsenstrider : BaseNPC 
	{ 
		public  FalkhaanIsenstrider() : base() 
		{ 
			Model = 5526;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Falkhaan Isenstrider" ;
			Flags1 = 0x08080066 ;
			Id = 6774 ; 
			Size = 1f;
			Speed = 3f ;
			WalkSpeed = 3f ;
			RunSpeed = 6f ;
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
			NpcText00 = "Greetings $N, I am Falkhaan Isenstrider." ;
			BaseMana = 0 ;
			Sells = new Item[] { new CrownOfThePenitent()
								   , new FireTar()
								   , new ExplosiveShell()
								   , new TinyBronzeKey()
								   , new TinyIronKey()
							   } ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
			//Quests = new BaseQuest[] { new Rest_and_Relaxation() };
		}
	}
public class Brivelthwerp : BaseCreature 
 { 
public  Brivelthwerp() : base() 
 { 
Model = 5451;
AttackSpeed= 2000;
BoundingRadius = 0.351900f ;
Name = "Brivelthwerp" ;
Flags1 = 0x08006E ;
Id = 6496 ; 
Guild = "Ice Cream Vendor";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 35 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1424 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.725f ;
SetDamage ( 38, 49 );
NpcText00 = "Greetings $N, I am Brivelthwerp." ;
BaseMana = 0 ;
Sells = new Item[] { new TiguleAndFororsStrawberryIceCream()
  } ;
Faction = Factions.Friend;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
}
}
public class Larhka : BaseCreature 
 { 
public  Larhka() : base() 
 { 
Model = 4525;
AttackSpeed= 2000;
BoundingRadius = 0.372000f ;
Name = "Larhka" ;
Flags1 = 0x08480046 ;
Id = 5871 ; 
Guild = "Beverage Merchant";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 18 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 744 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 19, 25 );
NpcText00 = "Greetings $N, I am Larhka." ;
BaseMana = 0 ;
Sells = new Item[] { new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
                           , new MoonberryJuice()
                           , new SweetNectar()
                           , new MorningGloryDew()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 24595, InventoryTypes.OneHand, 2, 14, 1, 0, 0, 0, 0 ));
}
}
public class Krond : BaseCreature 
 { 
public  Krond() : base() 
 { 
Model = 4727;
AttackSpeed= 2000;
BoundingRadius = 0.372000f ;
Name = "Krond" ;
Flags1 = 0x08480046 ;
Id = 5870 ; 
Guild = "Butcher";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 27 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 664 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 17, 22 );
NpcText00 = "Greetings $N, I am Krond." ;
BaseMana = 0 ;
Sells = new Item[] { new ToughJerky()
                           , new HaunchOfMeat()
                           , new MuttonChop()
                           , new WildHogShank()
                           , new CuredHamSteak()
                           , new RoastedQuail()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7431, InventoryTypes.OneHand, 2, 0, 1, 3, 0, 0, 0 ), new Item( 24117, InventoryTypes.HeldInHand , 4, 0, 2, 3, 0, 0, 0 ));
}
}
public class EdrisBarleybeard : BaseCreature 
 { 
public  EdrisBarleybeard() : base() 
 { 
Model = 3065;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Edris Barleybeard" ;
Flags1 = 0x08480046 ;
Id = 5140 ; 
Guild = "Barmaid";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
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
NpcText00 = "Greetings $N, I am Edris Barleybeard." ;
BaseMana = 0 ;
Sells = new Item[] { new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
                           , new MoonberryJuice()
                           , new SweetNectar()
                           , new FlaskOfPort()
                           , new FlagonOfMead()
                           , new JugOfBourbon()
                           , new SkinOfDwarvenStout()
                           , new BottleOfPinotNoir()
                           , new MorningGloryDew()
  } ;
Faction = Factions.IronForge;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 24596, InventoryTypes.OneHand, 2, 14, 1, 3, 0, 0, 0 ),new Item( 6469, InventoryTypes.OneHand, 2, 15, 1, 3, 0, 0, 0 ),new Item( 6593, InventoryTypes.RangeRight, 2, 3, 1, 3, 0, 0, 0 ));
}
}
public class SognarCliffbeard : BaseCreature 
 { 
public  SognarCliffbeard() : base() 
 { 
Model = 3078;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Sognar Cliffbeard" ;
Flags1 = 0x08480046 ;
Id = 5124 ; 
Guild = "Meat Vendor";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
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
NpcText00 = "Greetings $N, I am Sognar Cliffbeard." ;
BaseMana = 0 ;
Sells = new Item[] { new ToughJerky()
                           , new HaunchOfMeat()
                           , new MuttonChop()
                           , new WildHogShank()
                           , new CuredHamSteak()
                           , new RoastedQuail()
  } ;
Faction = Factions.IronForge;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7462, InventoryTypes.OneHand, 2, 4, 2, 7, 0, 0, 0 ),new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
}
}
public class GwennaFirebrew : BaseCreature 
 { 
public  GwennaFirebrew() : base() 
 { 
Model = 3051;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Gwenna Firebrew" ;
Flags1 = 0x08480046 ;
Id = 5112 ; 
Guild = "Barmaid";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
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
NpcText00 = "Greetings $N, I am Gwenna Firebrew." ;
BaseMana = 0 ;
Sells = new Item[] { new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
                           , new MoonberryJuice()
                           , new SweetNectar()
                           , new FlaskOfPort()
                           , new FlagonOfMead()
                           , new JugOfBourbon()
                           , new SkinOfDwarvenStout()
                           , new BottleOfPinotNoir()
                           , new MorningGloryDew()
  } ;
Faction = Factions.IronForge;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 24596, InventoryTypes.OneHand, 2, 14, 1, 0, 0, 0, 0 ));
}
}
public class MyraTyrngaarde : BaseCreature 
 { 
public  MyraTyrngaarde() : base() 
 { 
Model = 3050;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Myra Tyrngaarde" ;
Flags1 = 0x08480046 ;
Id = 5109 ; 
Guild = "Bread Vendor";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
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
NpcText00 = "Greetings $N, I am Myra Tyrngaarde." ;
BaseMana = 0 ;
Sells = new Item[] { new ToughHunkOfBread()
                           , new FreshlyBakedBread()
                           , new MoistCornbread()
                           , new MulgoreSpiceBread()
                           , new SoftBananaBread()
                           , new HomemadeCherryPie()
  } ;
Faction = Factions.IronForge;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7443, InventoryTypes.OneHand, 2, 4, 2, 7, 0, 0, 0 ));
}
}
public class BenTrias : BaseCreature 
 { 
public  BenTrias() : base() 
 { 
Model = 5547;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Ben Trias" ;
Flags1 = 0x08480046 ;
Id = 4981 ; 
Guild = "Apprentice of Cheese";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
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
NpcText00 = "Greetings $N, I am Ben Trias." ;
BaseMana = 0 ;
Sells = new Item[] { new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
                           , new MoonberryJuice()
                           , new StormwindBrie()
                           , new SweetNectar()
                           , new DarnassianBleu()
                           , new FineAgedCheddar()
                           , new DalaranSharp()
                           , new DwarvenMild()
                           , new MorningGloryDew()
                           , new AlteracSwiss()
  } ;
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7446, InventoryTypes.OneHand, 2, 14, 1, 13, 0, 0, 0 ));
}
}
public class Uttnar : BaseCreature 
 { 
public  Uttnar() : base() 
 { 
Model = 3957;
AttackSpeed= 2000;
BoundingRadius = 0.372000f ;
Name = "Uttnar" ;
Flags1 = 0x08480046 ;
Id = 4954 ; 
Guild = "Butcher";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
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
NpcText00 = "Greetings $N, I am Uttnar." ;
BaseMana = 0 ;
Sells = new Item[] { new ToughJerky()
                           , new HaunchOfMeat()
                           , new MuttonChop()
                           , new WildHogShank()
                           , new CuredHamSteak()
                           , new RoastedQuail()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 24117, InventoryTypes.HeldInHand, 4, 0, 2, 0, 0, 0, 0 ));
}
}
public class CraigNollward : BaseCreature 
 { 
public  CraigNollward() : base() 
 { 
Model = 4831;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Craig Nollward" ;
Flags1 = 0x08480046 ;
Id = 4894 ; 
Guild = "Cook";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 32 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1304 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 35, 45 );
NpcText00 = "Can I teach you how to turn the meat you find on beasts into a feast?" ;
BaseMana = 0 ;
Sells = new Item[] { new ToughJerky()
                           , new StormwindBrie()
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
                           , new AlteracSwiss()
                           , new HomemadeCherryPie()
                           , new RoastedQuail()
  } ;
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7431, InventoryTypes.OneHand, 2, 0, 1, 3, 0, 0, 0 ),new Item( 24116, InventoryTypes.HeldInHand, 4, 0, 2,0, 0, 0, 0 ));
}
}
public class DwaneWertle : BaseCreature 
 { 
public  DwaneWertle() : base() 
 { 
Model = 4853;
AttackSpeed= 2000;
BoundingRadius = 0.208000f ;
Name = "Dwane Wertle" ;
Flags1 = 0x08480046 ;
Id = 4891 ; 
Guild = "Chef";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 28 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1144 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 30, 39 );
NpcText00 = "Greetings $N, I am Dwane Wertle." ;
BaseMana = 0 ;
Sells = new Item[] { new ToughJerky()
                           , new StormwindBrie()
                           , new DarnassianBleu()
                           , new HaunchOfMeat()
                           , new MuttonChop()
                           , new WildHogShank()
                           , new FineAgedCheddar()
                           , new DalaranSharp()
                           , new DwarvenMild()
                           , new ShinyRedApple()
                           , new TelAbimBanana()
                           , new SnapvineWatermelon()
                           , new GoldenbarkApple()
                           , new ToughHunkOfBread()
                           , new FreshlyBakedBread()
                           , new MoistCornbread()
                           , new MulgoreSpiceBread()
                           , new CuredHamSteak()
                           , new SoftBananaBread()
                           , new MoonHarvestPumpkin()
                           , new AlteracSwiss()
                           , new HomemadeCherryPie()
                           , new RoastedQuail()
                           , new DeepFriedPlantains()
  } ;
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
Equip( new Item( 7443, InventoryTypes.OneHand, 2, 4, 2, 7, 0, 0, 0 ));
}
}
public class Oggmarr : BaseCreature 
 { 
public  Oggmarr() : base() 
 { 
Model = 10704;
AttackSpeed= 2000;
BoundingRadius = 1.294850f ;
Name = "Ogg'marr" ;
Flags1 = 0x08400046 ;
Id = 4879 ; 
Guild = "Butcher";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
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
CombatReach = 2.175f ;
SetDamage ( 43, 56 );
NpcText00 = "Greetings $N, I am Ogg'marr." ;
BaseMana = 0 ;
Sells = new Item[] { new ToughJerky()
                           , new IceColdMilk()
                           , new MelonJuice()
                           , new RecipeRoastRaptor()
                           , new RecipeCarrionSurprise()
                           , new RecipeDragonbreathChili()
                           , new RefreshingSpringWater()
                           , new MoonberryJuice()
                           , new SweetNectar()
                           , new HaunchOfMeat()
                           , new MuttonChop()
                           , new WildHogShank()
                           , new CuredHamSteak()
                           , new MorningGloryDew()
                           , new RoastedQuail()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
}
}
public class Turhaw : BaseCreature 
 { 
public  Turhaw() : base() 
 { 
Model = 4202;
AttackSpeed= 2000;
BoundingRadius = 0.372000f ;
Name = "Turhaw" ;
Flags1 = 0x08400046 ;
Id = 4875 ; 
Guild = "Butcher";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
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
NpcText00 = "Greetings $N, I am Turhaw." ;
BaseMana = 0 ;
Sells = new Item[] { new ToughJerky()
                           , new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
                           , new MoonberryJuice()
                           , new SweetNectar()
                           , new HaunchOfMeat()
                           , new MuttonChop()
                           , new WildHogShank()
                           , new CuredHamSteak()
                           , new MorningGloryDew()
                           , new RoastedQuail()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 7431, InventoryTypes.OneHand, 2, 0, 1, 3, 0, 0, 0 ));
}
}
public class Kyndri : BaseCreature 
 { 
public  Kyndri() : base() 
 { 
Model = 4399;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Kyndri" ;
Flags1 = 0x08480046 ;
Id = 4190 ; 
Guild = "Baker";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 13 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 544 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 14, 18 );
NpcText00 = "Greetings $N, I am Kyndri." ;
BaseMana = 0 ;
Sells = new Item[] { new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
                           , new MoonberryJuice()
                           , new SweetNectar()
                           , new ToughHunkOfBread()
                           , new FreshlyBakedBread()
                           , new MoistCornbread()
                           , new MulgoreSpiceBread()
                           , new SoftBananaBread()
                           , new MorningGloryDew()
                           , new HomemadeCherryPie()
  } ;
Faction = Factions.Darnasus;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 7443, InventoryTypes.OneHand, 2, 4, 2, 7, 0, 0, 0 ));
}
}
public class Jaeana : BaseCreature 
 { 
public  Jaeana() : base() 
 { 
Model = 2217;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Jaeana" ;
Flags1 = 0x08480046 ;
Id = 4169 ; 
Guild = "Meat Vendor";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
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
NpcText00 = "Greetings $N, I am Jaeana." ;
BaseMana = 0 ;
Sells = new Item[] { new ToughJerky()
                           , new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
                           , new MoonberryJuice()
                           , new SweetNectar()
                           , new HaunchOfMeat()
                           , new MuttonChop()
                           , new WildHogShank()
                           , new CuredHamSteak()
                           , new MorningGloryDew()
                           , new RoastedQuail()
  } ;
Faction = Factions.Darnasus;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7462, InventoryTypes.OneHand, 2, 4, 2, 7, 0, 0, 0 ));
}
}
public class Ulthaan : BaseCreature 
 { 
public  Ulthaan() : base() 
 { 
Model = 2067;
AttackSpeed= 2000;
BoundingRadius = 0.389000f ;
Name = "Ulthaan" ;
Flags1 = 0x08480046 ;
Id = 3960 ; 
Guild = "Butcher";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 26 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1064 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 28, 36 );
NpcText00 = "Greetings $N, I am Ulthaan." ;
BaseMana = 0 ;
Sells = new Item[] { new ToughJerky()
                           , new HaunchOfMeat()
                           , new RecipeBigBearSteak()
                           , new MuttonChop()
                           , new WildHogShank()
                           , new CuredHamSteak()
                           , new RecipeLeanVenison()
                           , new RoastedQuail()
  } ;
Faction = Factions.Darnasus;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7431, InventoryTypes.OneHand, 2, 0, 1, 3, 0, 0, 0 ));
}
}
public class Nantar : BaseCreature 
 { 
public  Nantar() : base() 
 { 
Model = 2063;
AttackSpeed= 2000;
BoundingRadius = 0.389000f ;
Name = "Nantar" ;
Flags1 = 0x08480046 ;
Id = 3959 ; 
Guild = "Baker";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 21 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 864 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 22, 29 );
NpcText00 = "Greetings $N, I am Nantar." ;
BaseMana = 0 ;
Sells = new Item[] { new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
                           , new MoonberryJuice()
                           , new SweetNectar()
                           , new ToughHunkOfBread()
                           , new FreshlyBakedBread()
                           , new MoistCornbread()
                           , new MulgoreSpiceBread()
                           , new SoftBananaBread()
                           , new MorningGloryDew()
                           , new HomemadeCherryPie()
  } ;
Faction = Factions.Darnasus;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7443, InventoryTypes.OneHand, 2, 4, 2, 7, 0, 0, 0 ));
}
}
public class HonniGoldenoat : BaseCreature 
 { 
public  HonniGoldenoat() : base() 
 { 
Model = 2036;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Honni Goldenoat" ;
Flags1 = 0x08480046 ;
Id = 3948 ; 
Guild = "Baker";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
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
NpcText00 = "Greetings $N, I am Honni Goldenoat." ;
BaseMana = 0 ;
Sells = new Item[] { new ToughHunkOfBread()
                           , new FreshlyBakedBread()
                           , new MoistCornbread()
                           , new MulgoreSpiceBread()
                           , new SoftBananaBread()
                           , new HomemadeCherryPie()
  } ;
Faction = Factions.IronForge;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
}
}
public class KiraSongshine : BaseCreature 
 { 
public  KiraSongshine() : base() 
 { 
Model = 3234;
AttackSpeed= 1500;
BoundingRadius = 0.208000f ;
Name = "Kira Songshine" ;
Flags1 = 0x08480046 ;
Id = 3937 ; 
Guild = "Traveling Baker";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 12 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 504 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 13, 16 );
NpcText00 = "Greetings $N, I am Kira Songshine." ;
BaseMana = 0 ;
Sells = new Item[] { new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
                           , new MoonberryJuice()
                           , new SweetNectar()
                           , new ToughHunkOfBread()
                           , new FreshlyBakedBread()
                           , new MoistCornbread()
                           , new MulgoreSpiceBread()
                           , new SoftBananaBread()
                           , new MorningGloryDew()
                           , new HomemadeCherryPie()
  } ;
Faction = Factions.Stormwind;
AIEngine = new TravellerSalesmanAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
}
}
public class Toddrick : BaseCreature 
 { 
public  Toddrick() : base() 
 { 
Model = 3236;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Toddrick" ;
Flags1 = 0x08480046 ;
Id = 3935 ; 
Guild = "Butcher";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
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
NpcText00 = "Greetings $N, I am Toddrick." ;
BaseMana = 0 ;
Sells = new Item[] { new ToughJerky()
                           , new HaunchOfMeat()
                           , new MuttonChop()
                           , new WildHogShank()
                           , new CuredHamSteak()
                           , new RoastedQuail()
  } ;
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 7431, InventoryTypes.OneHand, 2, 0, 1, 3, 0, 0, 0 ));
}
}
public class Haizan : BaseCreature 
 { 
public  Haizan() : base() 
 { 
Model = 4082;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Hai'zan" ;
Flags1 = 0x08480046 ;
Id = 3933 ; 
Guild = "Butcher";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 14 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 584 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 15, 19 );
NpcText00 = "Greetings $N, I am Hai'zan." ;
BaseMana = 0 ;
Sells = new Item[] { new ToughJerky()
                           , new HaunchOfMeat()
                           , new MuttonChop()
                           , new WildHogShank()
                           , new CuredHamSteak()
                           , new RoastedQuail()
  } ;
Faction = Factions.DarkspearTrolls;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 7463, InventoryTypes.OneHand, 2, 4, 2, 7, 0, 0, 0 ));
}
}
public class JhawnaOatwind : BaseCreature 
 { 
public  JhawnaOatwind() : base() 
 { 
Model = 3807;
AttackSpeed= 2000;
BoundingRadius = 0.872500f ;
Name = "Jhawna Oatwind" ;
Flags1 = 0x08480046 ;
Id = 3884 ; 
Guild = "Baker";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 13 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 544 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 3.75f ;
SetDamage ( 14, 18 );
NpcText00 = "Greetings $N, I am Jhawna Oatwind." ;
BaseMana = 0 ;
Sells = new Item[] { new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
                           , new MoonberryJuice()
                           , new SweetNectar()
                           , new ToughHunkOfBread()
                           , new FreshlyBakedBread()
                           , new MoistCornbread()
                           , new MulgoreSpiceBread()
                           , new SoftBananaBread()
                           , new MorningGloryDew()
                           , new HomemadeCherryPie()
  } ;
Faction = Factions.ThunderBluff;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 7443, InventoryTypes.OneHand, 2, 4, 7, 0, 0, 0, 0 ));
}
}
public class MoodanSungrain : BaseCreature 
 { 
public  MoodanSungrain() : base() 
 { 
Model = 3812;
AttackSpeed= 2000;
BoundingRadius = 0.974700f ;
Name = "Moodan Sungrain" ;
Flags1 = 0x08080066 ;
Id = 3883 ; 
Guild = "Baker";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 11 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 464 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 4.05f ;
SetDamage ( 11, 15 );
NpcText00 = "Greetings $N, I am Moodan Sungrain." ;
BaseMana = 0 ;
Sells = new Item[] { new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
                           , new MoonberryJuice()
                           , new SweetNectar()
                           , new ToughHunkOfBread()
                           , new FreshlyBakedBread()
                           , new MoistCornbread()
                           , new MulgoreSpiceBread()
                           , new SoftBananaBread()
                           , new MorningGloryDew()
                           , new HomemadeCherryPie()
  } ;
Faction = Factions.ThunderBluff;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 7443, InventoryTypes.OneHand, 2, 4, 7, 0, 0, 0, 0 ));}
}
public class ThomasMiller : BaseCreature 
 { 
public  ThomasMiller() : base() 
 { 
Model = 1541;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Thomas Miller" ;
Flags1 = 0x08480046 ;
Id = 3518 ; 
Guild = "Baker";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
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
NpcText00 = "Greetings $N, I am Thomas Miller." ;
BaseMana = 0 ;
Sells = new Item[] { new ToughHunkOfBread()
                           , new FreshlyBakedBread()
                           , new MoistCornbread()
                           , new MulgoreSpiceBread()
                           , new SoftBananaBread()
                           , new HomemadeCherryPie()
  } ;
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 7443, InventoryTypes.OneHand, 2, 4, 7, 0, 0, 0, 0 ));}
}
public class MooraneHearthgrain : BaseCreature 
 { 
public  MooraneHearthgrain() : base() 
 { 
Model = 3867;
AttackSpeed= 2000;
BoundingRadius = 0.872500f ;
Name = "Moorane Hearthgrain" ;
Flags1 = 0x08480046 ;
Id = 3480 ; 
Guild = "Baker";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 18 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 744 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 3.75f ;
SetDamage ( 19, 25 );
NpcText00 = "Greetings $N, I am Moorane Hearthgrain." ;
BaseMana = 0 ;
Sells = new Item[] { new ToughHunkOfBread()
                           , new FreshlyBakedBread()
                           , new MoistCornbread()
                           , new MulgoreSpiceBread()
                           , new SoftBananaBread()
                           , new HomemadeCherryPie()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 7443, InventoryTypes.OneHand, 2, 4, 7, 0, 0, 0, 0 ));
}
}
public class Borstan : BaseCreature 
 { 
public  Borstan() : base() 
 { 
Model = 1390;
AttackSpeed= 1739;
BoundingRadius = 0.372000f ;
Name = "Borstan" ;
Flags1 = 0x08480046 ;
Id = 3368 ; 
Guild = "Meat Vendor";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
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
NpcText00 = "Greetings $N, I am Borstan." ;
BaseMana = 0 ;
Sells = new Item[] { new ToughJerky()
                           , new HaunchOfMeat()
                           , new MuttonChop()
                           , new WildHogShank()
                           , new CuredHamSteak()
                           , new RoastedQuail()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7431, InventoryTypes.OneHand, 2, 0, 1, 3, 0, 0, 0 ),new Item( 7462, InventoryTypes.OneHand, 2, 4, 2, 7, 0, 0, 0 ));
}
}
public class Shanti : BaseCreature 
 { 
public  Shanti() : base() 
 { 
Model = 1358;
AttackSpeed= 2000;
BoundingRadius = 0.236000f ;
Name = "Shan'ti" ;
Flags1 = 0x08480046 ;
Id = 3342 ; 
Guild = "Fruit Vendor";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 35 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1424 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 38, 49 );
NpcText00 = "Greetings $N, I am Shan'ti." ;
BaseMana = 0 ;
Sells = new Item[] { new ShinyRedApple()
                           , new TelAbimBanana()
                           , new SnapvineWatermelon()
                           , new GoldenbarkApple()
                           , new MoonHarvestPumpkin()
                           , new DeepFriedPlantains()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
Equip( new Item( 22395, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
}
}
public class Olvia : BaseCreature 
 { 
public  Olvia() : base() 
 { 
Model = 1312;
AttackSpeed= 1739;
BoundingRadius = 0.236000f ;
Name = "Olvia" ;
Flags1 = 0x08480046 ;
Id = 3312 ; 
Guild = "Meat Vendor";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 50 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 2025 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 54, 70 );
NpcText00 = "Greetings $N, I am Olvia." ;
BaseMana = 0 ;
Sells = new Item[] { new ToughJerky()
                           , new HaunchOfMeat()
                           , new MuttonChop()
                           , new WildHogShank()
                           , new CuredHamSteak()
                           , new RoastedQuail()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 7431, InventoryTypes.OneHand, 2, 0, 1, 3, 0, 0, 0 ),new Item( 7462, InventoryTypes.OneHand, 2, 4, 2, 7, 0, 0, 0 ),new Item( 10671, InventoryTypes.RangeRight, 2, 18, 1, 0, 0, 0, 0 ));
}
}
public class KagaMistrunner : BaseCreature 
 { 
public  KagaMistrunner() : base() 
 { 
Model = 2111;
AttackSpeed= 2000;
BoundingRadius = 0.872500f ;
Name = "Kaga Mistrunner" ;
Flags1 = 0x08480046 ;
Id = 3025 ; 
Guild = "Meat Vendor";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
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
NpcText00 = "Greetings $N, I am Kaga Mistrunner." ;
BaseMana = 0 ;
Sells = new Item[] { new ToughJerky()
                           , new HaunchOfMeat()
                           , new MuttonChop()
                           , new WildHogShank()
                           , new CuredHamSteak()
                           , new RoastedQuail()
  } ;
Faction = Factions.ThunderBluff;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7462, InventoryTypes.OneHand, 2, 4, 2, 7, 0, 0, 0 ));
}
}
public class NanMistrunner : BaseCreature 
 { 
public  NanMistrunner() : base() 
 { 
Model = 2117;
AttackSpeed= 2000;
BoundingRadius = 0.872500f ;
Name = "Nan Mistrunner" ;
Flags1 = 0x08480046 ;
Id = 3017 ; 
Guild = "Fruit Vendor";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
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
NpcText00 = "Greetings $N, I am Nan Mistrunner." ;
BaseMana = 0 ;
Sells = new Item[] { new ShinyRedApple()
                           , new TelAbimBanana()
                           , new SnapvineWatermelon()
                           , new GoldenbarkApple()
                           , new MoonHarvestPumpkin()
                           , new DeepFriedPlantains()
  } ;
Faction = Factions.ThunderBluff;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7434, InventoryTypes.OneHand, 2, 15, 1, 3, 0, 0, 0 ));
}
}
public class BrontColdcleave : BaseCreature 
 { 
public  BrontColdcleave() : base() 
 { 
Model = 3690;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Bront Coldcleave" ;
Flags1 = 0x08480046 ;
Id = 2365 ; 
Guild = "Butcher";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
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
NpcText00 = "Greetings $N, I am Bront Coldcleave." ;
BaseMana = 0 ;
Sells = new Item[] { new ToughJerky()
                           , new HaunchOfMeat()
                           , new MuttonChop()
                           , new WildHogShank()
                           , new CuredHamSteak()
                           , new RoastedQuail()
  } ;
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
Equip( new Item( 7431, InventoryTypes.OneHand, 2, 0, 1, 3, 0, 0, 0 ), new Item( 24116, InventoryTypes.OneHand, 4, 0, 2, 0, 0, 0, 0 ));
}
}
public class Neema : BaseCreature 
 { 
public  Neema() : base() 
 { 
Model = 3658;
AttackSpeed= 2000;
BoundingRadius = 0.208000f ;
Name = "Neema" ;
Flags1 = 0x08480046 ;
Id = 2364 ; 
Guild = "Waitress";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 33 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1344 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 36, 46 );
NpcText00 = "Hello there... Do you want a drink or somethin ? Or maybe you're looking for a girl..." ;
BaseMana = 0 ;
Sells = new Item[] { new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
                           , new MoonberryJuice()
                           , new StormwindBrie()
                           , new SweetNectar()
                           , new DarnassianBleu()
                           , new FineAgedCheddar()
                           , new DalaranSharp()
                           , new DwarvenMild()
                           , new ToughHunkOfBread()
                           , new FreshlyBakedBread()
                           , new MoistCornbread()
                           , new MulgoreSpiceBread()
                           , new SoftBananaBread()
                           , new MorningGloryDew()
                           , new AlteracSwiss()
                           , new HomemadeCherryPie()
  } ;
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 24596, InventoryTypes.OneHand, 2, 14, 1, 0, 0, 0, 0 ));
}
}
public class Togthar : BaseCreature 
 { 
public  Togthar() : base() 
 { 
Model = 3686;
AttackSpeed= 2000;
BoundingRadius = 0.372000f ;
Name = "Tog'thar" ;
Flags1 = 0x0480006 ;
Id = 2238 ; 
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
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
NpcText00 = "Hello" ;
BaseMana = 0 ;
Sells = new Item[] { new MelonJuice()
                           , new Swiftthistle()
                           , new MuttonChop()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}
public class KeegGibn : BaseCreature 
 { 
public  KeegGibn() : base() 
 { 
Model = 3409;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Keeg Gibn" ;
Flags1 = 0x08480046 ;
Id = 1697 ; 
Guild = "Ale and Wine";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
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
NpcText00 = "Greetings $N, I am Keeg Gibn." ;
BaseMana = 0 ;
Sells = new Item[] { new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
                           , new MoonberryJuice()
                           , new SweetNectar()
                           , new FlaskOfPort()
                           , new FlagonOfMead()
                           , new JugOfBourbon()
                           , new SkinOfDwarvenStout()
                           , new BottleOfPinotNoir()
                           , new MorningGloryDew()
  } ;
Faction = Factions.IronForge;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 7428, InventoryTypes.OneHand, 2, 0, 1, 3, 0, 0, 0 ), new Item( 2080, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
}
}
public class JuliaGallina : BaseCreature 
 { 
public  JuliaGallina() : base() 
 { 
Model = 1443;
AttackSpeed= 2000;
BoundingRadius = 0.208000f ;
Name = "Julia Gallina" ;
Flags1 = 0x08480046 ;
Id = 1301 ; 
Guild = "Wine Vendor";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
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
NpcText00 = "Greetings $N, I am Julia Gallina." ;
BaseMana = 0 ;
Sells = new Item[] { new FlaskOfPort()
                           , new FlagonOfMead()
                           , new JugOfBourbon()
                           , new SkinOfDwarvenStout()
                           , new BottleOfPinotNoir()
  } ;
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7445, InventoryTypes.OneHand, 2, 14, 1, 7, 0, 0, 0 ));
}
}
public class HomerStonefield : BaseCreature 
 { 
public  HomerStonefield() : base() 
 { 
Model = 3332;
AttackSpeed= 1500;
BoundingRadius = 0.306000f ;
Name = "Homer Stonefield" ;
Flags1 = 0x08400046 ;
Id = 894 ; 
Guild = "Fruit Seller";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 5 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 224 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 5, 6 );
NpcText00 = "Greetings $N, I am Homer Stonefield." ;
BaseMana = 0 ;
Sells = new Item[] { new ShinyRedApple()
                           , new TelAbimBanana()
                           , new SnapvineWatermelon()
                           , new GoldenbarkApple()
                           , new MoonHarvestPumpkin()
                           , new DeepFriedPlantains()
  } ;
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
}
}
public class KirenTyrngaarde : BaseCreature 
 { 
public  KirenTyrngaarde() : base() 
 { 
Model = 262;
AttackSpeed= 2100;
BoundingRadius = 1.00f ;
Name = "Kiren Tyrngaarde" ;
Flags1 = 0x102 ;
Id = 5131 ; 
Guild = "Bread Vendor";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 1 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 64 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 11.00f ;
SetDamage ( 0, 1 );
NpcText00 = "Greetings $N, I am Kiren Tyrngaarde." ;
BaseMana = 20 ;
Faction = Factions.Friend;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
}
}
public class FyrMistrunner : BaseCreature 
 { 
public  FyrMistrunner() : base() 
 { 
Model = 2109;
AttackSpeed= 2000;
BoundingRadius = 0.872500f ;
Name = "Fyr Mistrunner" ;
Flags1 = 0x08480046 ;
Id = 3003 ; 
Guild = "Bread Vendor";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
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
NpcText00 = "Greetings $N, I am Fyr Mistrunner." ;
BaseMana = 0 ;
Sells = new Item[] { new ToughHunkOfBread()
                           , new FreshlyBakedBread()
                           , new MoistCornbread()
                           , new MulgoreSpiceBread()
                           , new SoftBananaBread()
                           , new HomemadeCherryPie()
  } ;
Faction = Factions.ThunderBluff;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7443, InventoryTypes.OneHand, 2, 4, 2, 7, 0, 0, 0 ));
}
}
public class MikeMiller : BaseCreature 
 { 
public  MikeMiller() : base() 
 { 
Model = 3262;
AttackSpeed= 1500;
BoundingRadius = 0.306000f ;
Name = "Mike Miller" ;
Flags1 = 0x08480046 ;
Id = 1670 ; 
Guild = "Bread Merchant";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
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
NpcText00 = "Greetings $N, I am Mike Miller." ;
BaseMana = 0 ;
Sells = new Item[] { new ToughHunkOfBread()
                           , new FreshlyBakedBread()
                           , new MoistCornbread()
                           , new MulgoreSpiceBread()
                           , new SoftBananaBread()
                           , new HomemadeCherryPie()
  } ;
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 1599, InventoryTypes.OneHand, 2, 10, 2, 2, 0, 0, 0 ), new Item( 1599, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
}
}

public class RobertoPupellyverbos : BaseCreature 
 { 
public  RobertoPupellyverbos() : base() 
 { 
Model = 1433;
AttackSpeed= 1000;
BoundingRadius = 0.306000f ;
Name = "Roberto Pupellyverbos" ;
Flags1 = 0x08480046 ;
Id = 277 ; 
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
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
NpcText00 = "Greetings $N, I am Roberto Pupellyverbos." ;
BaseMana = 0 ;
Sells = new Item[] { new CaskOfMerlot()
                           , new FlaskOfPort()
                           , new FlagonOfMead()
                           , new JugOfBourbon()
                           , new SkinOfDwarvenStout()
                           , new BottleOfPinotNoir()
  } ;
Faction = Factions.Stormwind;
Guild = "Food & Drink" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}

public class ElaineTrias : BaseCreature 
 { 
public  ElaineTrias() : base() 
 { 
Model = 5546;
AttackSpeed= 2000;
BoundingRadius = 0.208000f ;
Name = "Elaine Trias" ;
Flags1 = 0x08480046 ;
Id = 483 ; 
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
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
NpcText00 = "Greetings $N, I am Elaine Trias." ;
BaseMana = 0 ;
Sells = new Item[] { new StormwindBrie()
                           , new DarnassianBleu()
                           , new FineAgedCheddar()
                           , new DalaranSharp()
                           , new DwarvenMild()
                           , new AlteracSwiss()
  } ;
Faction = Factions.Stormwind;
Guild = "Food & Drink" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7443, InventoryTypes.OneHand, 2, 4, 2, 7, 0, 0, 0 ));
}
}

public class Thultash : BaseCreature 
 { 
public  Thultash() : base() 
 { 
Model = 4563;
AttackSpeed= 2000;
BoundingRadius = 0.372000f ;
Name = "Thultash" ;
Flags1 = 0x08400046 ;
Id = 982 ; 
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
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
NpcText00 = "Greetings $N, I am Thultash." ;
BaseMana = 0 ;
Sells = new Item[] { new ToughJerky()
                           , new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
                           , new MoonberryJuice()
                           , new SweetNectar()
                           , new HaunchOfMeat()
                           , new MuttonChop()
                           , new WildHogShank()
                           , new CuredHamSteak()
                           , new MorningGloryDew()
                           , new RoastedQuail()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
Equip( new Item( 7462, InventoryTypes.OneHand, 2, 4, 2, 7, 0, 0, 0 ));
}
}

public class KazanMogosh : BaseCreature 
 { 
public  KazanMogosh() : base() 
 { 
Model = 3418;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Kazan Mogosh" ;
Flags1 = 0x08480046 ;
Id = 1237 ; 
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
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
CombatReach = 1.5f ;
SetDamage ( 8, 11 );
NpcText00 = "Best deals in all of Stormwind my friend, won't find any better. Now, what can I help you with?" ;
BaseMana = 0 ;
Sells = new Item[] { new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
                           , new MoonberryJuice()
                           , new StormwindBrie()
                           , new SweetNectar()
                           , new RoughLeatherBelt()
                           , new RoughLeatherBracers()
                           , new DarnassianBleu()
                           , new ThinClothShoes()
                           , new ThinClothGloves()
                           , new ThinClothPants()
                           , new ThinClothArmor()
                           , new CrackedLeatherBelt()
                           , new CrackedLeatherBoots()
                           , new CrackedLeatherBracers()
                           , new CrackedLeatherGloves()
                           , new CrackedLeatherPants()
                           , new CrackedLeatherVest()
                           , new ThinClothBelt()
                           , new ThinClothBracers()
                           , new KnittedBelt()
                           , new KnittedBracers()
                           , new FineAgedCheddar()
                           , new DalaranSharp()
                           , new DwarvenMild()
                           , new ToughHunkOfBread()
                           , new FreshlyBakedBread()
                           , new MoistCornbread()
                           , new MulgoreSpiceBread()
                           , new SoftBananaBread()
                           , new KnittedSandals()
                           , new KnittedGloves()
                           , new KnittedPants()
                           , new KnittedTunic()
                           , new RoughLeatherBoots()
                           , new RoughLeatherGloves()
                           , new RoughLeatherPants()
                           , new RoughLeatherVest()
                           , new MorningGloryDew()
                           , new AlteracSwiss()
                           , new HomemadeCherryPie()
  } ;
Faction = Factions.IronForge;
Guild = "Food & Drink" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 7443, InventoryTypes.OneHand, 2, 4, 2, 7, 0, 0, 0 ));
}
}

public class LyranneFeathersong : BaseCreature 
 { 
public  LyranneFeathersong() : base() 
 { 
Model = 10749;
AttackSpeed= 1329;
BoundingRadius = 1.00f ;
Name = "Lyranne Feathersong" ;
Flags1 = 0x08480046 ;
Id = 2303 ; 
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 56 );
NpcType = 7 ;
BaseHitPoints = 2266 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 11.00f ;
SetDamage ( 61, 79 );
NpcText00 = "Greetings $N, I am Lyranne Feathersong." ;
BaseMana = 2805 ;
Sells = new Item[] { new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
                           , new BeanSoup()
                           , new VersicolorTreat()
                           , new HeavenPeach()
                           , new WildRicecake()
                           , new SteamedMandu()
                           , new Shinsollo()
                           , new MoonberryJuice()
                           , new SweetNectar()
                           , new MorningGloryDew()
  } ;
Faction = Factions.Darnasus;
Guild = "Food & Drink" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
}
}

public class NixxraxFillamug : BaseCreature 
 { 
public  NixxraxFillamug() : base() 
 { 
Model = 7180;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Nixxrax Fillamug" ;
Flags1 = 0x08080046 ;
Id = 2832 ; 
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
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
NpcText00 = "Greetings $N, I am Nixxrax Fillamug." ;
BaseMana = 0 ;
Sells = new Item[] { new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
                           , new MoonberryJuice()
                           , new StormwindBrie()
                           , new SweetNectar()
                           , new DarnassianBleu()
                           , new FlaskOfPort()
                           , new FlagonOfMead()
                           , new JugOfBourbon()
                           , new SkinOfDwarvenStout()
                           , new BottleOfPinotNoir()
                           , new FineAgedCheddar()
                           , new DalaranSharp()
                           , new DwarvenMild()
                           , new ToughHunkOfBread()
                           , new FreshlyBakedBread()
                           , new MoistCornbread()
                           , new MulgoreSpiceBread()
                           , new JunglevineWine()
                           , new CherryGrog()
                           , new SoftBananaBread()
                           , new MorningGloryDew()
                           , new AlteracSwiss()
                           , new HomemadeCherryPie()
  } ;
Faction = Factions.BootyBay;
Guild = "Food & Drink" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
}
}

public class GabrielleChase : BaseCreature 
 { 
public  GabrielleChase() : base() 
 { 
Model = 1442;
AttackSpeed= 2000;
BoundingRadius = 0.208000f ;
Name = "Gabrielle Chase" ;
Flags1 = 0x08480046 ;
Id = 3298 ; 
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
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
SetDamage ( 54, 80 );
NpcText00 = "Hello" ;
BaseMana = 0 ;
Sells = new Item[] { new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
                           , new MoonberryJuice()
                           , new StormwindBrie()
                           , new SweetNectar()
                           , new DarnassianBleu()
                           , new FineAgedCheddar()
                           , new DalaranSharp()
                           , new DwarvenMild()
                           , new MorningGloryDew()
                           , new AlteracSwiss()
  } ;
Faction = Factions.Stormwind;
Guild = "Food & Drink" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
}
}

public class BernieHeisten : BaseCreature 
 { 
public  BernieHeisten() : base() 
 { 
Model = 3701;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Bernie Heisten" ;
Flags1 = 0x08480046 ;
Id = 3546 ; 
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 45 );
NpcType = 7 ;
BaseHitPoints = 1825 ;
NpcFlags = 21 ;
CombatReach = 1.5f ;
SetDamage ( 49, 63 );
NpcText00 = "Greetings $N, I am Bernie Heisten." ;
BaseMana = 0 ;
Sells = new Item[] { new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
                           , new MoonberryJuice()
                           , new StormwindBrie()
                           , new SweetNectar()
                           , new DarnassianBleu()
                           , new FineAgedCheddar()
                           , new DalaranSharp()
                           , new DwarvenMild()
                           , new ToughHunkOfBread()
                           , new FreshlyBakedBread()
                           , new MoistCornbread()
                           , new MulgoreSpiceBread()
                           , new SoftBananaBread()
                           , new MorningGloryDew()
                           , new AlteracSwiss()
                           , new HomemadeCherryPie()
  } ;
Faction = Factions.Stormwind;
Guild = "Food & Drink" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
}
}

public class Kurll : BaseCreature 
 { 
public  Kurll() : base() 
 { 
Model = 4293;
AttackSpeed= 2000;
BoundingRadius = 0.372000f ;
Name = "Kurll" ;
Flags1 = 0x08480006 ;
Id = 3621 ; 
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 50 );
NpcType = 7 ;
BaseHitPoints = 0 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 60, 75 );
NpcText00 = "Hello" ;
BaseMana = 0 ;
Sells = new Item[] { new ToughJerky()
                           , new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
                           , new MoonberryJuice()
                           , new SweetNectar()
                           , new HaunchOfMeat()
                           , new MuttonChop()
                           , new WildHogShank()
                           , new CuredHamSteak()
                           , new MorningGloryDew()
                           , new RoastedQuail()
  } ;
Faction = Factions.Ogrimmar;
Guild = "Food & Drink" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
Equip( new Item( 7431, InventoryTypes.OneHand, 2, 0, 1, 3, 0, 0, 0 ));
}
}

public class LaerStepperunner : BaseCreature 
 { 
public  LaerStepperunner() : base() 
 { 
Model = 4301;
AttackSpeed= 2000;
BoundingRadius = 0.974700f ;
Name = "Laer Stepperunner" ;
Flags1 = 0x08480046 ;
Id = 3689 ; 
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 42 );
NpcType = 7 ;
BaseHitPoints = 424 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 4.05f ;
SetDamage ( 10, 14 );
NpcText00 = "Greetings $N, I am Laer Stepperunner." ;
BaseMana = 0 ;
Sells = new Item[] { new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
                           , new MoonberryJuice()
                           , new SweetNectar()
                           , new IronOre()
                           , new ToughHunkOfBread()
                           , new FreshlyBakedBread()
                           , new MoistCornbread()
                           , new MulgoreSpiceBread()
                           , new SoftBananaBread()
                           , new MorningGloryDew()
                           , new HomemadeCherryPie()
  } ;
Faction = Factions.ThunderBluff;
Guild = "Food & Drink" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
Equip( new Item( 22366, InventoryTypes.OneHand, 2, 7, 1, 3, 0, 0, 0 ), new Item( 7443, InventoryTypes.OneHand, 2, 4, 2, 7, 0, 0, 0 ));
}
}

public class Gruna : BaseCreature 
 { 
public  Gruna() : base() 
 { 
Model = 13970;
AttackSpeed= 2000;
BoundingRadius = 0.236000f ;
Name = "Gruna" ;
Flags1 = 0x08480046 ;
Id = 3708 ; 
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 52 );
NpcType = 7 ;
BaseHitPoints = 0 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 27, 40 );
NpcText00 = "Hello" ;
BaseMana = 0 ;
Sells = new Item[] { new ThoriumOre()
                           , new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
                           , new MoonberryJuice()
                           , new SweetNectar()
                           , new ToughHunkOfBread()
                           , new FreshlyBakedBread()
                           , new MoistCornbread()
                           , new MulgoreSpiceBread()
                           , new SoftBananaBread()
                           , new MorningGloryDew()
                           , new HomemadeCherryPie()
  } ;
Faction = Factions.Ogrimmar;
Guild = "Food & Drink" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 7443, InventoryTypes.OneHand, 2, 4, 2, 7, 0, 0, 0 ),new Item( 19132, InventoryTypes.OneHand, 2, 0, 1, 3, 0, 0, 0 ));
}
}

public class Maliynn : BaseCreature 
 { 
public  Maliynn() : base() 
 { 
Model = 2058;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Maliynn" ;
Flags1 = 0x08480046 ;
Id = 3961 ; 
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
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
NpcText00 = "Greetings $N, I am Maliynn." ;
BaseMana = 0 ;
Sells = new Item[] { new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
                           , new BeanSoup()
                           , new VersicolorTreat()
                           , new HeavenPeach()
                           , new WildRicecake()
                           , new SteamedMandu()
                           , new Shinsollo()
                           , new MoonberryJuice()
                           , new SweetNectar()
                           , new ShinyRedApple()
                           , new TelAbimBanana()
                           , new SnapvineWatermelon()
                           , new GoldenbarkApple()
                           , new MoonHarvestPumpkin()
                           , new MorningGloryDew()
                           , new DeepFriedPlantains()
  } ;
Faction = Factions.Darnasus;
Guild = "Food & Drink" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
}
}

public class Dendrythis : BaseCreature 
 { 
public  Dendrythis() : base() 
 { 
Model = 2208;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Dendrythis" ;
Flags1 = 0x08480046 ;
Id = 4167 ; 
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
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
NpcText00 = "Greetings $N, I am Dendrythis." ;
BaseMana = 0 ;
Sells = new Item[] { new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
                           , new BeanSoup()
                           , new VersicolorTreat()
                           , new HeavenPeach()
                           , new WildRicecake()
                           , new SteamedMandu()
                           , new Shinsollo()
                           , new MoonberryJuice()
                           , new SweetNectar()
                           , new ShinyRedApple()
                           , new TelAbimBanana()
                           , new SnapvineWatermelon()
                           , new GoldenbarkApple()
                           , new MoonHarvestPumpkin()
                           , new MorningGloryDew()
                           , new DeepFriedPlantains()
  } ;
Faction = Factions.Darnasus;
Guild = "Food & Drink" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
}
}

public class Fyrenna : BaseCreature 
 { 
public  Fyrenna() : base() 
 { 
Model = 2230;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Fyrenna" ;
Flags1 = 0x08480046 ;
Id = 4181 ; 
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
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
NpcText00 = "Greetings $N, I am Fyrenna." ;
BaseMana = 0 ;
Sells = new Item[] { new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
                           , new BeanSoup()
                           , new VersicolorTreat()
                           , new HeavenPeach()
                           , new WildRicecake()
                           , new SteamedMandu()
                           , new Shinsollo()
                           , new MoonberryJuice()
                           , new SweetNectar()
                           , new ShinyRedApple()
                           , new TelAbimBanana()
                           , new SnapvineWatermelon()
                           , new GoldenbarkApple()
                           , new MoonHarvestPumpkin()
                           , new MorningGloryDew()
                           , new DeepFriedPlantains()
  } ;
Faction = Factions.Darnasus;
Guild = "Food & Drink" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}

public class Allyndia : BaseCreature 
 { 
public  Allyndia() : base() 
 { 
Model = 4403;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Allyndia" ;
Flags1 = 0x08480046 ;
Id = 4191 ; 
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
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
NpcText00 = "Greetings $N, I am Allyndia." ;
BaseMana = 0 ;
Sells = new Item[] { new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
                           , new BeanSoup()
                           , new VersicolorTreat()
                           , new HeavenPeach()
                           , new WildRicecake()
                           , new SteamedMandu()
                           , new Shinsollo()
                           , new MoonberryJuice()
                           , new SweetNectar()
                           , new ShinyRedApple()
                           , new TelAbimBanana()
                           , new SnapvineWatermelon()
                           , new GoldenbarkApple()
                           , new MoonHarvestPumpkin()
                           , new MorningGloryDew()
                           , new DeepFriedPlantains()
  } ;
Faction = Factions.Darnasus;
Guild = "Food & Drink" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
}
}

public class Tiyani : BaseCreature 
 { 
public  Tiyani() : base() 
 { 
Model = 4410;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Tiyani" ;
Flags1 = 0x08480046 ;
Id = 4195 ; 
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
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
NpcText00 = "Greetings $N, I am Tiyani." ;
BaseMana = 0 ;
Sells = new Item[] { new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
                           , new BeanSoup()
                           , new VersicolorTreat()
                           , new HeavenPeach()
                           , new WildRicecake()
                           , new SteamedMandu()
                           , new Shinsollo()
                           , new MoonberryJuice()
                           , new SweetNectar()
                           , new ShinyRedApple()
                           , new TelAbimBanana()
                           , new SnapvineWatermelon()
                           , new GoldenbarkApple()
                           , new MoonHarvestPumpkin()
                           , new MorningGloryDew()
                           , new DeepFriedPlantains()
  } ;
Faction = Factions.Darnasus;
Guild = "Food & Drink" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
}
}

public class Danlyia : BaseCreature 
 { 
public  Danlyia() : base() 
 { 
Model = 4235;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Danlyia" ;
Flags1 = 0x08480046 ;
Id = 4266 ; 
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 17 );
NpcType = 7 ;
BaseHitPoints = 704 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 18, 23 );
NpcText00 = "Greetings $N, I am Danlyia." ;
BaseMana = 0 ;
Sells = new Item[] { new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
                           , new BeanSoup()
                           , new VersicolorTreat()
                           , new HeavenPeach()
                           , new WildRicecake()
                           , new SteamedMandu()
                           , new Shinsollo()
                           , new MoonberryJuice()
                           , new SweetNectar()
                           , new ShinyRedApple()
                           , new TelAbimBanana()
                           , new SnapvineWatermelon()
                           , new GoldenbarkApple()
                           , new ToughHunkOfBread()
                           , new FreshlyBakedBread()
                           , new MoistCornbread()
                           , new MulgoreSpiceBread()
                           , new SoftBananaBread()
                           , new MoonHarvestPumpkin()
                           , new MorningGloryDew()
                           , new HomemadeCherryPie()
                           , new DeepFriedPlantains()
  } ;
Faction = Factions.Darnasus;
Guild = "Food & Drink" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 23319, InventoryTypes.OneHand, 2, 14, 1, 3, 0, 0, 0 ));
}
}

public class Dellylah : BaseCreature 
 { 
public  Dellylah() : base() 
 { 
Model = 4861;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Dellylah" ;
Flags1 = 0x08080066 ;
Id = 6091 ; 
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
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
CombatReach = 1.5f ;
SetDamage ( 9, 12 );
NpcText00 = "Greetings $N, I am Dellylah." ;
BaseMana = 0 ;
Sells = new Item[] { new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
                           , new BeanSoup()
                           , new VersicolorTreat()
                           , new HeavenPeach()
                           , new WildRicecake()
                           , new SteamedMandu()
                           , new Shinsollo()
                           , new MoonberryJuice()
                           , new SweetNectar()
                           , new ShinyRedApple()
                           , new TelAbimBanana()
                           , new SnapvineWatermelon()
                           , new GoldenbarkApple()
                           , new MoonHarvestPumpkin()
                           , new MorningGloryDew()
                           , new DeepFriedPlantains()
  } ;
Faction = Factions.Darnasus;
Guild = "Food & Drink" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 7445, InventoryTypes.OneHand, 2, 14, 1, 7, 0, 0, 0 ));
}
}

public class Nargatt : BaseCreature 
 { 
public  Nargatt() : base() 
 { 
Model = 6308;
AttackSpeed= 2000;
BoundingRadius = 0.372000f ;
Name = "Nargatt" ;
Flags1 = 0x08400046 ;
Id = 7485 ; 
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
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
NpcText00 = "Greetings $N, I am Nargatt." ;
BaseMana = 0 ;
Sells = new Item[] { new ToughJerky()
                           , new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
                           , new MoonberryJuice()
                           , new SweetNectar()
                           , new HaunchOfMeat()
                           , new MuttonChop()
                           , new WildHogShank()
                           , new ToughHunkOfBread()
                           , new FreshlyBakedBread()
                           , new MoistCornbread()
                           , new MulgoreSpiceBread()
                           , new CuredHamSteak()
                           , new SoftBananaBread()
                           , new MorningGloryDew()
                           , new HomemadeCherryPie()
                           , new RoastedQuail()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
}
}

public class MardrackGreenwell : BaseCreature 
 { 
public  MardrackGreenwell() : base() 
 { 
Model = 7022;
AttackSpeed= 2000;
BoundingRadius = 0.389000f ;
Name = "Mardrack Greenwell" ;
Flags1 = 0x08480006 ;
Id = 7941 ; 
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 54 );
NpcType = 7 ;
BaseHitPoints = 2186 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 59, 76 );
NpcText00 = "Greetings $N, I am Mardrack Greenwell." ;
BaseMana = 0 ;
Sells = new Item[] { new ToughJerky()
                           , new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
                           , new BeanSoup()
                           , new VersicolorTreat()
                           , new HeavenPeach()
                           , new WildRicecake()
                           , new SteamedMandu()
                           , new Shinsollo()
                           , new MoonberryJuice()
                           , new SweetNectar()
                           , new HaunchOfMeat()
                           , new MuttonChop()
                           , new WildHogShank()
                           , new ToughHunkOfBread()
                           , new FreshlyBakedBread()
                           , new MoistCornbread()
                           , new MulgoreSpiceBread()
                           , new CuredHamSteak()
                           , new SoftBananaBread()
                           , new MorningGloryDew()
                           , new HomemadeCherryPie()
                           , new RoastedQuail()
  } ;
Faction = Factions.Darnasus;
Guild = "Food & Drink" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
}
}

public class Loorana : BaseCreature 
 { 
public  Loorana() : base() 
 { 
Model = 7358;
AttackSpeed= 2000;
BoundingRadius = 0.872500f ;
Name = "Loorana" ;
Flags1 = 0x08480046 ;
Id = 8143 ; 
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 49 );
NpcType = 7 ;
BaseHitPoints = 1745 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 3.75f ;
SetDamage ( 47, 60 );
NpcText00 = "Greetings $N, I am Loorana." ;
BaseMana = 0 ;
Sells = new Item[] { new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
                           , new MoonberryJuice()
                           , new SweetNectar()
                           , new ToughHunkOfBread()
                           , new FreshlyBakedBread()
                           , new MoistCornbread()
                           , new MulgoreSpiceBread()
                           , new SoftBananaBread()
                           , new MorningGloryDew()
                           , new HomemadeCherryPie()
  } ;
Faction = Factions.ThunderBluff;
Guild = "Food & Drink" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
}
}

public class JanetHommers : BaseCreature 
 { 
public  JanetHommers() : base() 
 { 
Model = 7371;
AttackSpeed= 2000;
BoundingRadius = 0.208000f ;
Name = "Janet Hommers" ;
Flags1 = 0x08480046 ;
Id = 8150 ; 
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
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
NpcText00 = "Greetings $N, I am Janet Hommers." ;
BaseMana = 0 ;
Sells = new Item[] { new IceColdMilk()
                           , new MelonJuice()
                           , new RecipeMysteryStew()
                           , new RecipeHeavyKodoStew()
                           , new RefreshingSpringWater()
                           , new MoonberryJuice()
                           , new SweetNectar()
                           , new ForestMushroomCap()
                           , new RedSpeckledMushroom()
                           , new SpongyMorel()
                           , new DeliciousCaveMold()
                           , new RawBlackTruffle()
                           , new MorningGloryDew()
                           , new DriedKingBolete()
  } ;
Faction = Factions.Stormwind;
Guild = "Food & Drink" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 7462, InventoryTypes.OneHand, 2, 4, 2, 7, 0, 0, 0 ));
}
}

public class Harnor : BaseCreature 
 { 
public  Harnor() : base() 
 { 
Model = 7372;
AttackSpeed= 2000;
BoundingRadius = 0.974700f ;
Name = "Harnor" ;
Flags1 = 0x08480046 ;
Id = 8152 ; 
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
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
CombatReach = 4.05f ;
SetDamage ( 43, 56 );
NpcText00 = "Greetings $N, I am Harnor." ;
BaseMana = 0 ;
Sells = new Item[] { new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
                           , new MoonberryJuice()
                           , new SweetNectar()
                           , new ForestMushroomCap()
                           , new RedSpeckledMushroom()
                           , new SpongyMorel()
                           , new DeliciousCaveMold()
                           , new RawBlackTruffle()
                           , new MorningGloryDew()
                           , new DriedKingBolete()
  } ;
Faction = Factions.ThunderBluff;
Guild = "Food & Drink" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 23316, InventoryTypes.OneHand, 2, 14, 1, 3, 0, 0, 0 ));
}
}

public class Himmik : BaseCreature 
 { 
public  Himmik() : base() 
 { 
Model = 10743;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Himmik" ;
Flags1 = 0x08080006 ;
Id = 11187 ; 
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 60 );
NpcType = 7 ;
BaseHitPoints = 2426 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 65, 85 );
NpcText00 = "Greetings $N, I am Himmik." ;
BaseMana = 0 ;
Sells = new Item[] { new ToughJerky()
                           , new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
                           , new RecipeMonsterOmelet()
                           , new MoonberryJuice()
                           , new SweetNectar()
                           , new HaunchOfMeat()
                           , new MuttonChop()
                           , new WildHogShank()
                           , new LongjawMudSnapper()
                           , new BristleWhiskerCatfish()
                           , new RockscaleCod()
                           , new CuredHamSteak()
                           , new SpottedYellowtail()
                           , new SlitherskinMackerel()
                           , new MorningGloryDew()
                           , new RoastedQuail()
                           , new SpinefinHalibut()
  } ;
Faction = Factions.Everlook;
Guild = "Food & Drink" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
Equip( new Item( 7431, InventoryTypes.OneHand, 2, 0, 1, 3, 0, 0, 0 ), new Item( 10816, InventoryTypes.OneHand, 2, 14, 1, 7, 0, 0, 0 ));
}
}

public class Dargon : BaseCreature 
 { 
public  Dargon() : base() 
 { 
Model = 12044;
AttackSpeed= 2000;
BoundingRadius = 0.389000f ;
Name = "Dargon" ;
Flags1 = 0x08080046 ;
Id = 12019 ; 
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
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
NpcText00 = "Greetings $N, I am Dargon." ;
BaseMana = 0 ;
Sells = new Item[] { new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
                           , new BeanSoup()
                           , new VersicolorTreat()
                           , new HeavenPeach()
                           , new WildRicecake()
                           , new SteamedMandu()
                           , new Shinsollo()
                           , new MoonberryJuice()
                           , new SweetNectar()
                           , new MorningGloryDew()
  } ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
}
}

public class Mylanna : BaseCreature 
 { 
public  Mylanna() : base() 
 { 
Model = 12050;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "My'lanna" ;
Flags1 = 0x08080046 ;
Id = 12026 ; 
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
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
NpcText00 = "Greetings $N, I am My'lanna." ;
BaseMana = 0 ;
Sells = new Item[] { new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
                           , new BeanSoup()
                           , new VersicolorTreat()
                           , new HeavenPeach()
                           , new WildRicecake()
                           , new SteamedMandu()
                           , new Shinsollo()
                           , new MoonberryJuice()
                           , new SweetNectar()
                           , new MorningGloryDew()
  } ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
}
}

public class SergeantMajorClate : BaseCreature 
 { 
public  SergeantMajorClate() : base() 
 { 
Model = 0;
AttackSpeed= 0;
BoundingRadius = 0.51f ;
Name = "Sergeant Major Clate" ;
Flags1 = 0x0 ;
Id = 12785 ; 
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
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
SetDamage ( 50, 60 );
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
                           , new ShinyRedApple()
                           , new TelAbimBanana()
                           , new SnapvineWatermelon()
                           , new GoldenbarkApple()
                           , new ToughHunkOfBread()
                           , new FreshlyBakedBread()
                           , new MoistCornbread()
                           , new MulgoreSpiceBread()
                           , new CuredHamSteak()
                           , new SoftBananaBread()
                           , new MoonHarvestPumpkin()
                           , new ForestMushroomCap()
                           , new RedSpeckledMushroom()
                           , new SpongyMorel()
                           , new DeliciousCaveMold()
                           , new RawBlackTruffle()
                           , new MorningGloryDew()
                           , new DriedKingBolete()
                           , new HomemadeCherryPie()
                           , new RoastedQuail()
                           , new DeepFriedPlantains()
  } ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
}
}

public class StoneGuardZarg : BaseCreature 
 { 
public  StoneGuardZarg() : base() 
 { 
Model = 0;
AttackSpeed= 0;
BoundingRadius = 0.51f ;
Name = "Stone Guard Zarg" ;
Flags1 = 0x0 ;
Id = 12794 ; 
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 55 );
NpcType = 7 ;
BaseHitPoints = 0 ;
NpcFlags = 0 ;
CombatReach = 0f ;
SetDamage ( 50, 60 );
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
                           , new ShinyRedApple()
                           , new TelAbimBanana()
                           , new SnapvineWatermelon()
                           , new GoldenbarkApple()
                           , new ToughHunkOfBread()
                           , new FreshlyBakedBread()
                           , new MoistCornbread()
                           , new MulgoreSpiceBread()
                           , new CuredHamSteak()
                           , new SoftBananaBread()
                           , new MoonHarvestPumpkin()
                           , new ForestMushroomCap()
                           , new RedSpeckledMushroom()
                           , new SpongyMorel()
                           , new DeliciousCaveMold()
                           , new RawBlackTruffle()
                           , new MorningGloryDew()
                           , new DriedKingBolete()
                           , new HomemadeCherryPie()
                           , new RoastedQuail()
                           , new DeepFriedPlantains()
  } ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};

}
}

public class Taldan : BaseCreature 
 { 
public  Taldan() : base() 
 { 
Model = 4405;
AttackSpeed= 2000;
BoundingRadius = 0.389000f ;
Name = "Taldan" ;
Flags1 = 0x08480046 ;
Id = 4192 ; 
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 16 );
NpcType = 7 ;
BaseHitPoints = 664 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 17, 22 );
NpcText00 = "Greetings $N, I am Taldan." ;
BaseMana = 0 ;
Sells = new Item[] { new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
                           , new MoonberryJuice()
                           , new SweetNectar()
                           , new MorningGloryDew()
  } ;
Faction = Factions.Darnasus;
Guild = "Food & Drink" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
}
}

public class Riznek : BaseCreature 
 { 
public  Riznek() : base() 
 { 
Model = 7195;
AttackSpeed= 2000;
BoundingRadius = 0.290700f ;
Name = "Riznek" ;
Flags1 = 0x08006E ;
Id = 6495 ; 
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 35 );
NpcType = 7 ;
BaseHitPoints = 1024 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.425f ;
SetDamage ( 27, 35 );
NpcText00 = "Greetings $N, I am Riznek." ;
BaseMana = 0 ;
Sells = new Item[] { new IceColdMilk()
                           , new MelonJuice()
                           , new RefreshingSpringWater()
                           , new MoonberryJuice()
                           , new SweetNectar()
                           , new MorningGloryDew()
  } ;
Faction = Factions.Friend;
Guild = "Food & Drink" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 24596, InventoryTypes.OneHand, 2, 14, 1, 0, 0, 0, 0 ));
}
}



public class HamlinAtkins : BaseCreature 
 { 
public  HamlinAtkins() : base() 
 { 
Model = 1635;
AttackSpeed= 2000;
BoundingRadius = 0.290700f ;
Name = "Hamlin Atkins" ;
Guild = "Mushroom Farmer";
Flags1 = 0x08400046 ;
Id = 3547 ; 
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 10 );
NpcType = 7 ;
BaseHitPoints = 324 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.425f ;
SetDamage ( 27, 35 );
//NpcText00 = "Greetings $N, I am Riznek." ;
BaseMana = 0 ;
Sells = new Item[] { new ForestMushroomCap()
                           , new RedSpeckledMushroom()
                           , new SpongyMorel()
                           , new DeliciousCaveMold()
                           , new RawBlackTruffle()
                           , new DriedKingBolete()
  } ;
Faction = Factions.Undercity;
AIEngine = new TravellerSalesmanAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 23317, InventoryTypes.MainGauche, 2, 14, 1, 0, 0, 0, 0 ));
}
}

}
