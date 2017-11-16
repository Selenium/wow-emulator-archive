//originally Scripted By DiScS Converter
//Edited by *place name here*
using System;
using Server.Items;
using Server;

////////////////////
namespace Server.Creatures
{
public class MasatTandr : BaseCreature 
 { 
public  MasatTandr() : base() 
 { 
Model = 11650;
AttackSpeed= 1386;
BoundingRadius = 1.00f ;
Name = "Masat T'andr" ;
Flags1 = 0x066 ;
Id = 11874 ; 
Guild = "Superior Leatherworker";
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
BaseHitPoints = 1785 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 11.00f ;
SetDamage ( 48, 62 );
NpcText00 = "Hello" ;
BaseMana = 2604 ;
Sells = new Item[] { new PinkDye()
                           , new BrilliantRedCloak()
                           , new WellOiledCloak()
                           , new RuneThread()
                           , new PatternGreenDragonscaleBreastplate()
                           , new CoarseThread()
                           , new FineThread()
                           , new BlackDye()
                           , new RedDye()
                           , new GreenDye()
                           , new Salt()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new ForestMushroomCap()
                           , new RedSpeckledMushroom()
                           , new SpongyMorel()
                           , new DeliciousCaveMold()
                           , new RawBlackTruffle()
                           , new BlueDye()
                           , new OrangeDye()
                           , new SkinningKnife()
                           , new HeavySilkenThread()
                           , new DriedKingBolete()
  } ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
}
}
public class ZannokHidepiercer : BaseCreature 
 { 
public  ZannokHidepiercer() : base() 
 { 
Model = 12977;
AttackSpeed= 2000;
BoundingRadius = 0.389000f ;
Name = "Zannok Hidepiercer" ;
Flags1 = 0x080006 ;
Id = 12956 ; 
Guild = "Leatherworking Supplies";
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
Level = RandomLevel( 59 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 2386 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.500000f ;
SetDamage ( 64, 83 );
NpcText00 = "Greetings $N, I am Zannok Hidepiercer." ;
BaseMana = 0 ;
Sells = new Item[] { new PinkDye()
                           , new RuneThread()
                           , new PatternHeavyScorpidBracers()
                           , new PatternHeavyScorpidHelm()
                           , new CoarseThread()
                           , new FineThread()
                           , new BlackDye()
                           , new RedDye()
                           , new GreenDye()
                           , new Salt()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new BlueDye()
                           , new OrangeDye()
                           , new SkinningKnife()
                           , new HeavySilkenThread()
  } ;
Faction = Factions.Friend;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
}
}
public class LeonardPorter : BaseCreature 
 { 
public  LeonardPorter() : base() 
 { 
Model = 12957;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Leonard Porter" ;
Flags1 = 0x080006 ;
Id = 12942 ; 
Guild = "Leatherworking Supplies";
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
BaseHitPoints = 2226 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 60, 77 );
NpcText00 = "Greetings $N, I am Leonard Porter." ;
BaseMana = 0 ;
Sells = new Item[] { new PinkDye()
                           , new RuneThread()
                           , new PatternWickedLeatherGauntlets()
                           , new PatternStormshroudPants()
                           , new CoarseThread()
                           , new FineThread()
                           , new BlackDye()
                           , new RedDye()
                           , new GreenDye()
                           , new Salt()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new BlueDye()
                           , new OrangeDye()
                           , new SkinningKnife()
                           , new HeavySilkenThread()
  } ;
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
}
}
public class WergThickblade : BaseCreature 
 { 
public  WergThickblade() : base() 
 { 
Model = 12975;
AttackSpeed= 2000;
BoundingRadius = 0.372000f ;
Name = "Werg Thickblade" ;
Flags1 = 0x080006 ;
Id = 12943 ; 
Guild = "Leatherworking Supplies";
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
BaseHitPoints = 2226 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 60, 77 );
NpcText00 = "Greetings $N, I am Werg Thickblade." ;
BaseMana = 0 ;
Sells = new Item[] { new PinkDye()
                           , new RuneThread()
                           , new PatternWickedLeatherGauntlets()
                           , new PatternStormshroudPants()
                           , new CoarseThread()
                           , new FineThread()
                           , new BlackDye()
                           , new RedDye()
                           , new GreenDye()
                           , new Salt()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new BlueDye()
                           , new OrangeDye()
                           , new SkinningKnife()
                           , new HeavySilkenThread()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
Equip( new Item( 6434, InventoryTypes.OneHand, 2, 15, 1, 3, 0, 0, 0 ));
}
}
public class Nioma : BaseCreature 
 { 
public  Nioma() : base() 
 { 
Model = 7382;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Nioma" ;
Flags1 = 0x08480046 ;
Id = 8160 ; 
Guild = "Leatherworking Supplies";
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
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 2025 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 54, 70 );
NpcText00 = "Greetings $N, I am Nioma." ;
BaseMana = 0 ;
Sells = new Item[] { new PinkDye()
                           , new RuneThread()
                           , new CoarseThread()
                           , new FineThread()
                           , new BlackDye()
                           , new RedDye()
                           , new GreenDye()
                           , new Salt()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new BlueDye()
                           , new OrangeDye()
                           , new SkinningKnife()
                           , new HeavySilkenThread()
                           , new PatternNightscapeShoulders()
  } ;
Faction = Factions.WildHammerClan;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
}
}
public class WorbStrongstitch : BaseCreature 
 { 
public  WorbStrongstitch() : base() 
 { 
Model = 7381;
AttackSpeed= 2000;
BoundingRadius = 0.974700f ;
Name = "Worb Strongstitch" ;
Flags1 = 0x08400046 ;
Id = 8159 ; 
Guild = "Leatherworking Supplies";
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
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1865 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 4.05f ;
SetDamage ( 50, 65 );
NpcText00 = "Greetings $N, I am Worb Strongstitch." ;
BaseMana = 0 ;
Sells = new Item[] { new PinkDye()
                           , new BrilliantRedCloak()
                           , new WellOiledCloak()
                           , new RuneThread()
                           , new CoarseThread()
                           , new FineThread()
                           , new BlackDye()
                           , new RussetVest()
                           , new RussetPants()
                           , new RussetBoots()
                           , new RussetGloves()
                           , new StuddedDoublet()
                           , new StuddedBelt()
                           , new StuddedPants()
                           , new StuddedBoots()
                           , new StuddedBracers()
                           , new StuddedGloves()
                           , new RedDye()
                           , new GreenDye()
                           , new RussetBelt()
                           , new RussetBracers()
                           , new RussetHat()
                           , new StuddedHat()
                           , new Salt()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new BlueDye()
                           , new OrangeDye()
                           , new SkinningKnife()
                           , new HeavySilkenThread()
                           , new PatternNightscapeShoulders()
  } ;
Faction = Factions.ThunderBluff;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
}
}
public class JangdorSwiftstrider : BaseCreature 
 { 
public  JangdorSwiftstrider() : base() 
 { 
Model = 6893;
AttackSpeed= 2000;
BoundingRadius = 0.974700f ;
Name = "Jangdor Swiftstrider" ;
Flags1 = 0x08480046 ;
Id = 7854 ; 
Guild = "Leatherworking Supplies";
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
BaseHitPoints = 1625 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 4.05f ;
SetDamage ( 43, 56 );
NpcText00 = "Greetings $N, I am Jangdor Swiftstrider." ;
BaseMana = 0 ;
Sells = new Item[] { new PinkDye()
                           , new RuneThread()
                           , new PatternLivingShoulders()
                           , new CoarseThread()
                           , new FineThread()
                           , new BlackDye()
                           , new RedDye()
                           , new GreenDye()
                           , new Salt()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new BlueDye()
                           , new OrangeDye()
                           , new SkinningKnife()
                           , new PatternGreenWhelpBracers()
                           , new HeavySilkenThread()
                           , new PatternTurtleScaleGloves()
                           , new PatternNightscapeShoulders()
  } ;
Faction = Factions.ThunderBluff;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
}
}
public class PrattMcGrubben : BaseCreature 
 { 
public  PrattMcGrubben() : base() 
 { 
Model = 6892;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Pratt McGrubben" ;
Flags1 = 0x08480006 ;
Id = 7852 ; 
Guild = "Leatherworking Supplies";
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
BaseHitPoints = 2226 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 60, 77 );
NpcText00 = "Greetings $N, I am Pratt McGrubben." ;
BaseMana = 0 ;
Sells = new Item[] { new PinkDye()
                           , new RuneThread()
                           , new PatternLivingShoulders()
                           , new CoarseThread()
                           , new FineThread()
                           , new BlackDye()
                           , new RedDye()
                           , new GreenDye()
                           , new Salt()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new BlueDye()
                           , new OrangeDye()
                           , new SkinningKnife()
                           , new PatternGreenWhelpBracers()
                           , new HeavySilkenThread()
                           , new PatternTurtleScaleGloves()
  } ;
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
}
}
public class HarlownDarkweave : BaseCreature 
 { 
public  HarlownDarkweave() : base() 
 { 
Model = 10980;
AttackSpeed= 1735;
BoundingRadius = 1.00f ;
Name = "Harlown Darkweave" ;
Flags1 = 0x08480046 ;
Id = 6731 ; 
Guild = "Leatherworking Supplies";
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
Level = RandomLevel( 27 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1104 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 11.00f ;
SetDamage ( 29, 38 );
NpcText00 = "Greetings $N, I am Harlown Darkweave." ;
BaseMana = 1353 ;
Sells = new Item[] { new PinkDye()
                           , new RuneThread()
                           , new CoarseThread()
                           , new FineThread()
                           , new BlackDye()
                           , new RedDye()
                           , new GreenDye()
                           , new Salt()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new BlueDye()
                           , new OrangeDye()
                           , new SkinningKnife()
                           , new PatternHerbalistsGloves()
                           , new HeavySilkenThread()
  } ;
Faction = Factions.Friend;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}
public class KalldanFelmoon : BaseCreature 
 { 
public  KalldanFelmoon() : base() 
 { 
Model = 4291;
AttackSpeed= 2000;
BoundingRadius = 0.389000f ;
Name = "Kalldan Felmoon" ;
Flags1 = 0x066 ;
Id = 5783 ; 
Guild = "Specialist Leatherworking Supplies";
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
Level = RandomLevel( 27 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1104 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 29, 38 );
NpcText00 = "Greetings $N, I am Kalldan Felmoon." ;
BaseMana = 0 ;
Sells = new Item[] { new PinkDye()
                           , new RuneThread()
                           , new CuredLeatherBelt()
                           , new CuredLeatherBracers()
                           , new CoarseThread()
                           , new FineThread()
                           , new BlackDye()
                           , new CuredLeatherArmor()
                           , new CuredLeatherPants()
                           , new CuredLeatherBoots()
                           , new CuredLeatherGloves()
                           , new RedDye()
                           , new GreenDye()
                           , new Salt()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new BlueDye()
                           , new OrangeDye()
                           , new PatternDeviateScaleCloak()
                           , new PatternDeviateScaleGloves()
                           , new SkinningKnife()
                           , new HeavySilkenThread()
  } ;
Faction = Factions.Friend;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
}
}
public class JillianTanner : BaseCreature 
 { 
public  JillianTanner() : base() 
 { 
Model = 3448;
AttackSpeed= 2000;
BoundingRadius = 0.208000f ;
Name = "Jillian Tanner" ;
Flags1 = 0x08480046 ;
Id = 5565 ; 
Guild = "Leatherworking Supplies";
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
NpcText00 = "Good! I can tell that my efforts will not be wasted!" ;
BaseMana = 0 ;
Sells = new Item[] { new PinkDye()
                           , new RuneThread()
                           , new CoarseThread()
                           , new FineThread()
                           , new BlackDye()
                           , new RedDye()
                           , new GreenDye()
                           , new Salt()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new BlueDye()
                           , new OrangeDye()
                           , new SkinningKnife()
                           , new HeavySilkenThread()
  } ;
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
}
}
public class BombusFinespindle : BaseCreature 
 { 
public  BombusFinespindle() : base() 
 { 
Model = 3105;
AttackSpeed= 2000;
BoundingRadius = 0.351900f ;
Name = "Bombus Finespindle" ;
Flags1 = 0x08480046 ;
Id = 5128 ; 
Guild = "Leatherworking Supplies";
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
NpcText00 = "Greetings $N, I am Bombus Finespindle." ;
BaseMana = 0 ;
Sells = new Item[] { new PinkDye()
                           , new RuneThread()
                           , new PatternHeavyLeatherBall()
                           , new CoarseThread()
                           , new FineThread()
                           , new BlackDye()
                           , new RedDye()
                           , new GreenDye()
                           , new Salt()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new BlueDye()
                           , new OrangeDye()
                           , new SkinningKnife()
                           , new HeavySilkenThread()
  } ;
Faction = Factions.IronForge;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}
public class JosephMoore : BaseCreature 
 { 
public  JosephMoore() : base() 
 { 
Model = 2635;
AttackSpeed= 2000;
BoundingRadius = 0.383000f ;
Name = "Joseph Moore" ;
Flags1 = 0x018480046 ;
Id = 4589 ; 
Guild = "Leatherworking Supplies";
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
NpcText00 = "Greetings $N, I am Joseph Moore." ;
BaseMana = 0 ;
Sells = new Item[] { new PinkDye()
                           , new RuneThread()
                           , new CoarseThread()
                           , new FineThread()
                           , new BlackDye()
                           , new RedDye()
                           , new GreenDye()
                           , new Salt()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new BlueDye()
                           , new OrangeDye()
                           , new SkinningKnife()
                           , new PatternGreenWhelpBracers()
                           , new HeavySilkenThread()
  } ;
Faction = Factions.Undercity;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}
public class Saenorion : BaseCreature 
 { 
public  Saenorion() : base() 
 { 
Model = 2265;
AttackSpeed= 2000;
BoundingRadius = 0.389000f ;
Name = "Saenorion" ;
Flags1 = 0x08480046 ;
Id = 4225 ; 
Guild = "Leatherworking Supplies";
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
NpcText00 = "Greetings $N, I am Saenorion." ;
BaseMana = 0 ;
Sells = new Item[] { new PinkDye()
                           , new RuneThread()
                           , new CoarseThread()
                           , new FineThread()
                           , new BlackDye()
                           , new RedDye()
                           , new GreenDye()
                           , new Salt()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new BlueDye()
                           , new OrangeDye()
                           , new SkinningKnife()
                           , new PatternGreenWhelpBracers()
                           , new HeavySilkenThread()
  } ;
Faction = Factions.Darnasus;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}
public class Mavralyn : BaseCreature 
 { 
public  Mavralyn() : base() 
 { 
Model = 4406;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Mavralyn" ;
Flags1 = 0x08480046 ;
Id = 4186 ; 
Guild = "Leather Armor & Leatherworking Supplies";
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
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 744 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 19, 25 );
NpcText00 = "Greetings $N, I am Mavralyn." ;
BaseMana = 0 ;
Sells = new Item[] { new TannedLeatherBelt()
                           , new TannedLeatherBracers()
                           , new PatternMurlocScaleBelt()
                           , new PatternMurlocScaleBreastplate()
                           , new TannedLeatherBoots()
                           , new TannedLeatherGloves()
                           , new TannedLeatherPants()
                           , new TannedLeatherJerkin()
  } ;
Faction = Factions.Darnasus;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
}
}
public class Lardan : BaseCreature 
 { 
public  Lardan() : base() 
 { 
Model = 2062;
AttackSpeed= 2000;
BoundingRadius = 0.389000f ;
Name = "Lardan" ;
Flags1 = 0x08480046 ;
Id = 3958 ; 
Guild = "Leatherworking Supplies";
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
NpcText00 = "Greetings $N, I am Lardan." ;
BaseMana = 0 ;
Sells = new Item[] { new PinkDye()
                           , new RuneThread()
                           , new CoarseThread()
                           , new FineThread()
                           , new BlackDye()
                           , new RedDye()
                           , new GreenDye()
                           , new Salt()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new PatternBarbaricLeggings()
                           , new BlueDye()
                           , new OrangeDye()
                           , new SkinningKnife()
                           , new HeavySilkenThread()
  } ;
Faction = Factions.Darnasus;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}
public class Tamar : BaseCreature 
 { 
public  Tamar() : base() 
 { 
Model = 1388;
AttackSpeed= 1739;
BoundingRadius = 0.372000f ;
Name = "Tamar" ;
Flags1 = 0x08480046 ;
Id = 3366 ; 
Guild = "Leatherworking Supplies";
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
NpcText00 = "Greetings $N, I am Tamar." ;
BaseMana = 0 ;
Sells = new Item[] { new PinkDye()
                           , new RuneThread()
                           , new PatternHeavyLeatherBall()
                           , new CoarseThread()
                           , new FineThread()
                           , new BlackDye()
                           , new RedDye()
                           , new GreenDye()
                           , new Salt()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new BlueDye()
                           , new OrangeDye()
                           , new SkinningKnife()
                           , new HeavySilkenThread()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}
public class BlixrezGoodstitch : BaseCreature 
 { 
public  BlixrezGoodstitch() : base() 
 { 
Model = 7186;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Blixrez Goodstitch" ;
Flags1 = 0x08080046 ;
Id = 2846 ; 
Guild = "Leatherworking Supplies";
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
NpcText00 = "Greetings $N, I am Blixrez Goodstitch." ;
BaseMana = 0 ;
Sells = new Item[] { new PinkDye()
                           , new RuneThread()
                           , new CoarseThread()
                           , new FineThread()
                           , new BlackDye()
                           , new RedDye()
                           , new GreenDye()
                           , new Salt()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new PatternThickMurlocArmor()
                           , new PatternMurlocScaleBracers()
                           , new BlueDye()
                           , new OrangeDye()
                           , new SkinningKnife()
                           , new HeavySilkenThread()
  } ;
Faction = Factions.BootyBay;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};

}
}
public class Tunkk : BaseCreature 
 { 
public  Tunkk() : base() 
 { 
Model = 3951;
AttackSpeed= 2000;
BoundingRadius = 0.372000f ;
Name = "Tunkk" ;
Flags1 = 0x08480046 ;
Id = 2819 ; 
Guild = "Leatherworking Supplies";
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
NpcText00 = "Greetings $N, I am Tunkk." ;
BaseMana = 0 ;
Sells = new Item[] { new PinkDye()
                           , new PatternRaptorHideHarness()
                           , new RuneThread()
                           , new CoarseThread()
                           , new FineThread()
                           , new BlackDye()
                           , new RedDye()
                           , new GreenDye()
                           , new Salt()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new BlueDye()
                           , new OrangeDye()
                           , new SkinningKnife()
                           , new HeavySilkenThread()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}
public class AndrodFadran : BaseCreature 
 { 
public  AndrodFadran() : base() 
 { 
Model = 3965;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Androd Fadran" ;
Flags1 = 0x08480046 ;
Id = 2816 ; 
Guild = "Leatherworking Supplies";
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
NpcText00 = "Greetings $N, I am Androd Fadran." ;
BaseMana = 0 ;
Sells = new Item[] { new PinkDye()
                           , new PatternRaptorHideBelt()
                           , new RuneThread()
                           , new CoarseThread()
                           , new FineThread()
                           , new BlackDye()
                           , new RedDye()
                           , new GreenDye()
                           , new Salt()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new BlueDye()
                           , new OrangeDye()
                           , new SkinningKnife()
                           , new HeavySilkenThread()
  } ;
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
}
}
public class ClydeRanthal : BaseCreature 
 { 
public  ClydeRanthal() : base() 
 { 
Model = 3357;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Clyde Ranthal" ;
Flags1 = 0x08400046 ;
Id = 2697 ; 
Guild = "Leatherworking Supplies";
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
Level = RandomLevel( 31 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1264 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 33, 43 );
NpcText00 = "Greetings $N, I am Clyde Ranthal." ;
BaseMana = 0 ;
Sells = new Item[] { new PinkDye()
                           , new RuneThread()
                           , new CoarseThread()
                           , new FineThread()
                           , new BlackDye()
                           , new RedDye()
                           , new GreenDye()
                           , new Salt()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new BlueDye()
                           , new OrangeDye()
                           , new SkinningKnife()
                           , new PatternBlackWhelpCloak()
                           , new HeavySilkenThread()
  } ;
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}
public class GeorgeCandarte : BaseCreature 
 { 
public  GeorgeCandarte() : base() 
 { 
Model = 3680;
AttackSpeed= 1680;
BoundingRadius = 1.00f ;
Name = "George Candarte" ;
Flags1 = 0x08400046 ;
Id = 2698 ; 
Guild = "Leatherworking Supplies";
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
Level = RandomLevel( 31 );
NpcType = (int)NpcTypes.Undead;
BaseHitPoints = 1264 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 11.00f ;
SetDamage ( 33, 43 );
NpcText00 = "Greetings $N, I am George Candarte." ;
BaseMana = 1553 ;
Sells = new Item[] { new PinkDye()
                           , new RuneThread()
                           , new CoarseThread()
                           , new FineThread()
                           , new BlackDye()
                           , new RedDye()
                           , new GreenDye()
                           , new Salt()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new BlueDye()
                           , new OrangeDye()
                           , new SkinningKnife()
                           , new PatternGreenLeatherArmor()
                           , new HeavySilkenThread()
  } ;
Faction = Factions.Beast;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}
public class Rikqiz : BaseCreature 
 { 
public  Rikqiz() : base() 
 { 
Model = 7170;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Rikqiz" ;
Flags1 = 0x08080046 ;
Id = 2699 ; 
Guild = "Leatherworking Supplies";
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
NpcText00 = "Greetings $N, I am Rikqiz." ;
BaseMana = 0 ;
Sells = new Item[] { new PinkDye()
                           , new RuneThread()
                           , new PatternGemStuddedLeatherBelt()
                           , new PatternShadowskinGloves()
                           , new CoarseThread()
                           , new FineThread()
                           , new BlackDye()
                           , new RedDye()
                           , new GreenDye()
                           , new Salt()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new BlueDye()
                           , new OrangeDye()
                           , new SkinningKnife()
                           , new HeavySilkenThread()
  } ;
Faction = Factions.BootyBay;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
}
}
}