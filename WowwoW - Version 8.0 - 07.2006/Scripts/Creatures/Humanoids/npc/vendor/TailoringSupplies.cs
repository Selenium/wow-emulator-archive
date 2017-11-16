//originally Scripted By DiScS Converter
//Edited by *place name here*
using System;
using Server.Items;
using Server;

////////////////////
namespace Server.Creatures
{
public class OutfitterEric : BaseCreature 
 { 
public  OutfitterEric() : base() 
 { 
Model = 7951;
AttackSpeed= 2000;
BoundingRadius = 0.351900f ;
Name = "Outfitter Eric" ;
Flags1 = 0x08480006 ;
Id = 8681 ; 
Guild = "Speciality Tailoring Supplies";
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
Level = RandomLevel( 35 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1424 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.725f ;
SetDamage ( 38, 49 );
NpcText00 = "Greetings $N, I am Outfitter Eric." ;
BaseMana = 0 ;
Sells = new Item[] { new PinkDye()
                           , new PatternLavenderMageweaveShirt()
                           , new PatternPinkMageweaveShirt()
                           , new PatternTuxedoShirt()
                           , new PatternTuxedoPants()
                           , new PatternTuxedoJacket()
                           , new RuneThread()
                           , new CoarseThread()
                           , new FineThread()
                           , new Bleach()
                           , new BlackDye()
                           , new RedDye()
                           , new GreenDye()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new BlueDye()
                           , new OrangeDye()
                           , new HeavySilkenThread()
  } ;
Faction = Factions.GnomereganExiles;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 12236, InventoryTypes.OneHand, 2, 4, 2, 7, 0, 0, 0 ), new Item( 6530, InventoryTypes.HeldInHand, 4, 0, 2, 7, 0, 0, 0 ));
}
}
public class Darnall : BaseCreature 
 { 
public  Darnall() : base() 
 { 
Model = 7016;
AttackSpeed= 2000;
BoundingRadius = 0.389000f ;
Name = "Darnall" ;
Flags1 = 0x08080046 ;
Id = 7940 ; 
Guild = "Tailoring Supplies";
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
Level = RandomLevel( 53 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 2145 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 58, 75 );
NpcText00 = "Greetings $N, I am Darnall." ;
BaseMana = 0 ;
Sells = new Item[] { new PinkDye()
                           , new RuneThread()
                           , new PatternRuneclothRobe()
                           , new PatternRuneclothCloak()
                           , new PatternRuneclothBoots()
                           , new CoarseThread()
                           , new FineThread()
                           , new Bleach()
                           , new BlackDye()
                           , new RedDye()
                           , new GreenDye()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new BlueDye()
                           , new OrangeDye()
                           , new HeavySilkenThread()
  } ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
}
}
public class BriennaStarglow : BaseCreature 
 { 
public  BriennaStarglow() : base() 
 { 
Model = 5366;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Brienna Starglow" ;
Flags1 = 0x08480046 ;
Id = 6576 ; 
Guild = "Tailoring Supplies";
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
NpcText00 = "Greetings $N, I am Brienna Starglow." ;
BaseMana = 0 ;
Sells = new Item[] { new PinkDye()
                           , new RuneThread()
                           , new CoarseThread()
                           , new FineThread()
                           , new Bleach()
                           , new BlackDye()
                           , new RedDye()
                           , new GreenDye()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new BlueDye()
                           , new OrangeDye()
                           , new PatternAzureSilkCloak()
                           , new HeavySilkenThread()
  } ;
Faction = Factions.Darnasus;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
}
}
public class Junha : BaseCreature 
 { 
public  Junha() : base() 
 { 
Model = 5367;
AttackSpeed= 1680;
BoundingRadius = 1.00f ;
Name = "Jun'ha" ;
Flags1 = 0x08480046 ;
Id = 6574 ; 
Guild = "Tailoring Supplies";
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
CombatReach = 11.00f ;
SetDamage ( 33, 43 );
NpcText00 = "Greetings $N, I am Jun'ha." ;
BaseMana = 1553 ;
Sells = new Item[] { new PinkDye()
                           , new RuneThread()
                           , new CoarseThread()
                           , new FineThread()
                           , new Bleach()
                           , new BlackDye()
                           , new RedDye()
                           , new GreenDye()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new BlueDye()
                           , new OrangeDye()
                           , new PatternAzureSilkCloak()
                           , new HeavySilkenThread()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 6443, InventoryTypes.OneHand, 2, 15, 3, 0, 0, 0, 0 ));
}
}
public class Vizzklick : BaseCreature 
 { 
public  Vizzklick() : base() 
 { 
Model = 7216;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Vizzklick" ;
Flags1 = 0x08080006 ;
Id = 6568 ; 
Guild = "Tailoring Supplies";
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
NpcText00 = "Greetings $N, I am Vizzklick." ;
BaseMana = 0 ;
Sells = new Item[] { new PinkDye()
                           , new RuneThread()
                           , new CoarseThread()
                           , new FineThread()
                           , new Bleach()
                           , new BlackDye()
                           , new RedDye()
                           , new GreenDye()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new BlueDye()
                           , new OrangeDye()
                           , new PatternCrimsonSilkRobe()
                           , new HeavySilkenThread()
  } ;
Faction = Factions.Gadgetzan;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
Equip( new Item( 7466, InventoryTypes.OneHand, 2, 14, 1, 0, 0, 0, 0 ), new Item( 6535, InventoryTypes.HeldInHand, 4, 0, 3, 0, 0, 0, 0 ));
}
}
public class Ghokkah : BaseCreature 
 { 
public  Ghokkah() : base() 
 { 
Model = 5368;
AttackSpeed= 2000;
BoundingRadius = 0.372000f ;
Name = "Ghok'kah" ;
Flags1 = 0x08400046 ;
Id = 6567 ; 
Guild = "Tailoring Supplies";
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
NpcText00 = "Greetings $N, I am Ghok'kah." ;
BaseMana = 0 ;
Sells = new Item[] { new PinkDye()
                           , new RuneThread()
                           , new ExpertFirstAidUnderWraps()
                           , new ManualHeavySilkBandage()
                           , new ManualMageweaveBandage()
                           , new CoarseThread()
                           , new FineThread()
                           , new Bleach()
                           , new BlackDye()
                           , new RedDye()
                           , new GreenDye()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new PatternIcyCloak()
                           , new BlueDye()
                           , new OrangeDye()
                           , new HeavySilkenThread()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
}
}

public class PorannaSnowbraid : BaseCreature 
 { 
public  PorannaSnowbraid() : base() 
 { 
Model = 3069;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Poranna Snowbraid" ;
Flags1 = 0x08480046 ;
Id = 5154 ; 
Guild = "Tailoring Supplies";
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
NpcText00 = "Greetings $N, I am Poranna Snowbraid." ;
BaseMana = 0 ;
Sells = new Item[] { new PinkDye()
                           , new RuneThread()
                           , new CoarseThread()
                           , new FineThread()
                           , new Bleach()
                           , new BlackDye()
                           , new RedDye()
                           , new GreenDye()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new BlueDye()
                           , new OrangeDye()
                           , new HeavySilkenThread()
  } ;
Faction = Factions.IronForge;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7493, InventoryTypes.OneHand, 2, 0, 1, 3, 0, 0, 0 ));
}
}
public class MillieGregorian : BaseCreature 
 { 
public  MillieGregorian() : base() 
 { 
Model = 2671;
AttackSpeed= 2000;
BoundingRadius = 0.383000f ;
Name = "Millie Gregorian" ;
Flags1 = 0x018480046 ;
Id = 4577 ; 
Guild = "Tailoring Supplies";
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
NpcText00 = "Greetings $N, I am Millie Gregorian." ;
BaseMana = 0 ;
Sells = new Item[] { new PinkDye()
                           , new PatternTuxedoShirt()
                           , new PatternTuxedoPants()
                           , new PatternTuxedoJacket()
                           , new RuneThread()
                           , new CoarseThread()
                           , new FineThread()
                           , new Bleach()
                           , new BlackDye()
                           , new RedDye()
                           , new GreenDye()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new PatternRedWoolenBag()
                           , new BlueDye()
                           , new OrangeDye()
                           , new PatternGreaterAdeptsRobe()
                           , new HeavySilkenThread()
  } ;
Faction = Factions.Undercity;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7466, InventoryTypes.OneHand, 2, 14, 1, 0, 0, 0, 0 ), new Item( 6234, InventoryTypes.OneHand, 4, 0, 2, 0, 0, 0, 0 ));
}
}
public class Valdaron : BaseCreature 
 { 
public  Valdaron() : base() 
 { 
Model = 4401;
AttackSpeed= 2000;
BoundingRadius = 0.389000f ;
Name = "Valdaron" ;
Flags1 = 0x08480046 ;
Id = 4189 ; 
Guild = "Tailoring Supplies";
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
Level = RandomLevel( 14 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 584 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 15, 19 );
NpcText00 = "Greetings $N, I am Valdaron." ;
BaseMana = 0 ;
Sells = new Item[] { new PinkDye()
                           , new RuneThread()
                           , new CoarseThread()
                           , new FineThread()
                           , new Bleach()
                           , new BlackDye()
                           , new RedDye()
                           , new GreenDye()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new PatternRedLinenBag()
                           , new PatternRedWoolenBag()
                           , new BlueDye()
                           , new OrangeDye()
                           , new PatternBlueLinenVest()
                           , new HeavySilkenThread()
  } ;
Faction = Factions.Darnasus;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
}
}
public class Elynna : BaseCreature 
 { 
public  Elynna() : base() 
 { 
Model = 2214;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Elynna" ;
Flags1 = 0x08480046 ;
Id = 4168 ; 
Guild = "Tailoring Supplies";
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
NpcText00 = "Greetings $N, I am Elynna." ;
BaseMana = 0 ;
Sells = new Item[] { new PinkDye()
                           , new PatternOrangeMartialShirt()
                           , new RuneThread()
                           , new CoarseThread()
                           , new FineThread()
                           , new Bleach()
                           , new BlackDye()
                           , new RedDye()
                           , new GreenDye()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new BlueDye()
                           , new OrangeDye()
                           , new PatternBlueLinenRobe()
                           , new PatternGreaterAdeptsRobe()
                           , new HeavySilkenThread()
  } ;
Faction = Factions.Darnasus;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}
public class Wrahk : BaseCreature 
 { 
public  Wrahk() : base() 
 { 
Model = 3873;
AttackSpeed= 2000;
BoundingRadius = 0.372000f ;
Name = "Wrahk" ;
Flags1 = 0x08480046 ;
Id = 3485 ; 
Guild = "Tailoring Supplies";
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
BaseHitPoints = 1024 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 27, 35 );
NpcText00 = "Greetings $N, I am Wrahk." ;
BaseMana = 0 ;
Sells = new Item[] { new PinkDye()
                           , new RuneThread()
                           , new CoarseThread()
                           , new FineThread()
                           , new Bleach()
                           , new BlackDye()
                           , new RedDye()
                           , new GreenDye()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new PatternRedWoolenBag()
                           , new BlueDye()
                           , new OrangeDye()
                           , new PatternBlueLinenVest()
                           , new PatternBlueLinenRobe()
                           , new HeavySilkenThread()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7466, InventoryTypes.OneHand, 2, 14, 1, 0, 0, 0, 0 ));
}
}
public class Borya : BaseCreature 
 { 
public  Borya() : base() 
 { 
Model = 1386;
AttackSpeed= 2000;
BoundingRadius = 0.372000f ;
Name = "Borya" ;
Flags1 = 0x08480046 ;
Id = 3364 ; 
Guild = "Tailoring Supplies";
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
NpcText00 = "Greetings $N, I am Borya." ;
BaseMana = 0 ;
Sells = new Item[] { new PinkDye()
                           , new PatternLavenderMageweaveShirt()
                           , new PatternPinkMageweaveShirt()
                           , new RuneThread()
                           , new CoarseThread()
                           , new FineThread()
                           , new Bleach()
                           , new BlackDye()
                           , new RedDye()
                           , new GreenDye()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new PatternRedWoolenBag()
                           , new BlueDye()
                           , new OrangeDye()
                           , new PatternBlueLinenVest()
                           , new PatternBlueOveralls()
                           , new HeavySilkenThread()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}
public class CapturedServantOfAzora : BaseCreature 
 { 
public  CapturedServantOfAzora() : base() 
 { 
Model = 5015;
AttackSpeed= 2000;
BoundingRadius = 0.351900f ;
Name = "Captured Servant of Azora" ;
Flags1 = 0x066 ;
Id = 3096 ; 
Guild = "Specialist Tailoring Supplies";
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
Level = RandomLevel( 22 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 944 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.725f ;
SetDamage ( 25, 32 );
NpcText00 = "Greetings $N, I am Captured Servant of Azora." ;
BaseMana = 0 ;
Sells = new Item[] { new PinkDye()
                           , new RuneThread()
                           , new CoarseThread()
                           , new FineThread()
                           , new Bleach()
                           , new BlackDye()
                           , new RedDye()
                           , new GreenDye()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new InfernoCloak()
                           , new SpiritCloak()
                           , new SylvanCloak()
                           , new BlueDye()
                           , new OrangeDye()
                           , new HeavySilkenThread()
  } ;
Faction = Factions.Friend;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}
public class FranklinHamar : BaseCreature 
 { 
public  FranklinHamar() : base() 
 { 
Model = 3376;
AttackSpeed= 1000;
BoundingRadius = 0.306000f ;
Name = "Franklin Hamar" ;
Flags1 = 0x08480046 ;
Id = 3091 ; 
Guild = "Tailoring Supplies";
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
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1064 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 28, 36 );
NpcText00 = "Greetings $N, I am Franklin Hamar." ;
BaseMana = 0 ;
Sells = new Item[] { new PinkDye()
                           , new RuneThread()
                           , new CoarseThread()
                           , new FineThread()
                           , new Bleach()
                           , new BlackDye()
                           , new RedDye()
                           , new GreenDye()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new WhisperingVest()
                           , new SolsticeRobe()
                           , new WiseMansBelt()
                           , new BlueDye()
                           , new OrangeDye()
                           , new HeavySilkenThread()
  } ;
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}
public class Mahu : BaseCreature 
 { 
public  Mahu() : base() 
 { 
Model = 2093;
AttackSpeed= 2000;
BoundingRadius = 0.974700f ;
Name = "Mahu" ;
Flags1 = 0x08480046 ;
Id = 3005 ; 
Guild = "Leatherworking & Tailoring Supplies";
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
NpcText00 = "Greetings $N, I am Mahu." ;
BaseMana = 0 ;
Sells = new Item[] { new PinkDye()
                           , new PatternOrangeMartialShirt()
                           , new PatternWhiteWeddingDress()
                           , new RuneThread()
                           , new CoarseThread()
                           , new FineThread()
                           , new Bleach()
                           , new BlackDye()
                           , new RedDye()
                           , new GreenDye()
                           , new Salt()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new PatternRedLinenBag()
                           , new PatternRedWoolenBag()
                           , new BlueDye()
                           , new OrangeDye()
                           , new SkinningKnife()
                           , new HeavySilkenThread()
  } ;
Faction = Factions.ThunderBluff;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 6443, InventoryTypes.OneHand, 2, 15, 1, 0, 0, 0, 0 ));
}
}
public class CowardlyCrosby : BaseCreature 
 { 
public  CowardlyCrosby() : base() 
 { 
Model = 4397;
AttackSpeed= 1554;
BoundingRadius = 1.00f ;
Name = "Cowardly Crosby" ;
Flags1 = 0x066 ;
Id = 2672 ; 
Guild = "Tailoring Supplies";
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
CombatReach = 11.00f ;
SetDamage ( 43, 56 );
NpcText00 = "Greetings $N, I am Cowardly Crosby." ;
BaseMana = 2004 ;
Sells = new Item[] { new PinkDye()
                           , new PatternAdmiralsHat()
                           , new RuneThread()
                           , new CoarseThread()
                           , new FineThread()
                           , new Bleach()
                           , new BlackDye()
                           , new RedDye()
                           , new GreenDye()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new BlueDye()
                           , new OrangeDye()
                           , new HeavySilkenThread()
  } ;
Faction = Factions.Friend;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
}
}
public class XizkGoodstitch : BaseCreature 
 { 
public  XizkGoodstitch() : base() 
 { 
Model = 7177;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Xizk Goodstitch" ;
Flags1 = 0x08080046 ;
Id = 2670 ; 
Guild = "Tailoring Supplies";
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
NpcText00 = "Greetings $N, I am Xizk Goodstitch." ;
BaseMana = 0 ;
Sells = new Item[] { new PinkDye()
                           , new RuneThread()
                           , new PatternEnchantersCowl()
                           , new CoarseThread()
                           , new FineThread()
                           , new Bleach()
                           , new BlackDye()
                           , new RedDye()
                           , new GreenDye()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new BlueDye()
                           , new OrangeDye()
                           , new PatternCrimsonSilkCloak()
                           , new HeavySilkenThread()
  } ;
Faction = Factions.BootyBay;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
}
}
public class SheriZipstitch : BaseCreature 
 { 
public  SheriZipstitch() : base() 
 { 
Model = 4274;
AttackSpeed= 1000;
BoundingRadius = 0.208000f ;
Name = "Sheri Zipstitch" ;
Flags1 = 0x08480046 ;
Id = 2669 ; 
Guild = "Tailoring Supplies";
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
NpcText00 = "Greetings $N, I am Sheri Zipstitch." ;
BaseMana = 0 ;
Sells = new Item[] { new PinkDye()
                           , new RuneThread()
                           , new CoarseThread()
                           , new FineThread()
                           , new Bleach()
                           , new BlackDye()
                           , new RedDye()
                           , new GreenDye()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new BlueDye()
                           , new OrangeDye()
                           , new PatternGreaterAdeptsRobe()
                           , new PatternDarkSilkShirt()
                           , new HeavySilkenThread()
  } ;
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}
public class DanielleZipstitch : BaseCreature 
 { 
public  DanielleZipstitch() : base() 
 { 
Model = 4273;
AttackSpeed= 1000;
BoundingRadius = 0.208000f ;
Name = "Danielle Zipstitch" ;
Flags1 = 0x08480046 ;
Id = 2668 ; 
Guild = "Tailoring Supplies";
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
NpcText00 = "Greetings $N, I am Danielle Zipstitch." ;
BaseMana = 0 ;
Sells = new Item[] { new PinkDye()
                           , new RuneThread()
                           , new PatternBrightYellowShirt()
                           , new CoarseThread()
                           , new FineThread()
                           , new Bleach()
                           , new BlackDye()
                           , new RedDye()
                           , new GreenDye()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new BlueDye()
                           , new OrangeDye()
                           , new HeavySilkenThread()
  } ;
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}
public class MallenSwain : BaseCreature 
 { 
public  MallenSwain() : base() 
 { 
Model = 3679;
AttackSpeed= 2000;
BoundingRadius = 0.383000f ;
Name = "Mallen Swain" ;
Flags1 = 0x08400046 ;
Id = 2394 ; 
Guild = "Tailoring Supplies";
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
Level = RandomLevel( 32 );
NpcType = (int)NpcTypes.Undead;
BaseHitPoints = 1304 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 35, 45 );
NpcText00 = "You'll have to be patient with me, $N. I've got my Spybot inside working on a very delicate matter. I'll be with ya in a second.$B$BOh, and do me a favor, try not to see Lescovar see you... we're about to ambush him." ;
BaseMana = 0 ;
Sells = new Item[] { new PinkDye()
                           , new RuneThread()
                           , new CoarseThread()
                           , new FineThread()
                           , new Bleach()
                           , new BlackDye()
                           , new RedDye()
                           , new GreenDye()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new BlueDye()
                           , new OrangeDye()
                           , new PatternBlueOveralls()
                           , new PatternDarkSilkShirt()
                           , new HeavySilkenThread()
  } ;
Faction = Factions.Undercity;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 6532, InventoryTypes.HeldInHand, 4, 0, 2, 0, 0, 0, 0 ));
}
}
public class LohganEva : BaseCreature 
 { 
public  LohganEva() : base() 
 { 
Model = 221;
AttackSpeed= 1000;
BoundingRadius = 1.000000f ;
Name = "Lohgan Eva" ;
Flags1 = 0x0808006E ;
Id = 1672 ; 
Guild = "Tailoring Supplies";
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
Level = RandomLevel( 5 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 224 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1f ;
SetDamage ( 5, 6 );
NpcText00 = "Greetings $N, I am Lohgan Eva." ;
BaseMana = 0 ;
Sells = new Item[] { new PinkDye()
                           , new RuneThread()
                           , new CoarseThread()
                           , new FineThread()
                           , new Bleach()
                           , new BlackDye()
                           , new RedDye()
                           , new GreenDye()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new BlueDye()
                           , new OrangeDye()
                           , new HeavySilkenThread()
  } ;
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
}
}
public class RannFlamespinner : BaseCreature 
 { 
public  RannFlamespinner() : base() 
 { 
Model = 1846;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Rann Flamespinner" ;
Flags1 = 0x08480046 ;
Id = 1474 ; 
Guild = "Tailoring Supplies";
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
Level = RandomLevel( 15 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 624 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 16, 21 );
NpcText00 = "Greetings $N, I am Rann Flamespinner." ;
BaseMana = 0 ;
Sells = new Item[] { new PinkDye()
                           , new RuneThread()
                           , new CoarseThread()
                           , new FineThread()
                           , new Bleach()
                           , new BlackDye()
                           , new RedDye()
                           , new GreenDye()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new PatternRedWoolenBag()
                           , new BlueDye()
                           , new OrangeDye()
                           , new PatternGreaterAdeptsRobe()
                           , new HeavySilkenThread()
  } ;
Faction = Factions.IronForge;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 1600, InventoryTypes.TwoHanded, 2, 10, 2, 0, 0, 0, 0 ));
}
}
public class JennabinkPowerseam : BaseCreature 
 { 
public  JennabinkPowerseam() : base() 
 { 
Model = 5033;
AttackSpeed= 1500;
BoundingRadius = 0.351900f ;
Name = "Jennabink Powerseam" ;
Flags1 = 0x08480046 ;
Id = 1454 ; 
Guild = "Tailoring Supplies & Specialty Goods";
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
CombatReach = 1.725f ;
SetDamage ( 27, 35 );
NpcText00 = "Greetings $N, I am Jennabink Powerseam." ;
BaseMana = 0 ;
Sells = new Item[] { new PinkDye()
                           , new RuneThread()
                           , new CoarseThread()
                           , new FineThread()
                           , new Bleach()
                           , new BlackDye()
                           , new RedDye()
                           , new GreenDye()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new InfernoCloak()
                           , new SpiritCloak()
                           , new SylvanCloak()
                           , new WizardsBelt()
                           , new NightwindBelt()
                           , new DreamersBelt()
                           , new PatternRedWoolenBag()
                           , new BlueDye()
                           , new OrangeDye()
                           , new PatternGreaterAdeptsRobe()
                           , new HeavySilkenThread()
  } ;
Faction = Factions.GnomereganExiles;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}
public class AlexandraBolero : BaseCreature 
 { 
public  AlexandraBolero() : base() 
 { 
Model = 1497;
AttackSpeed= 2000;
BoundingRadius = 0.208000f ;
Name = "Alexandra Bolero" ;
Flags1 = 0x08480046 ;
Id = 1347 ; 
Guild = "Tailoring Supplies";
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
NpcText00 = "Greetings $N, I am Alexandra Bolero." ;
BaseMana = 0 ;
Sells = new Item[] { new PinkDye()
                           , new PatternWhiteWeddingDress()
                           , new RuneThread()
                           , new CoarseThread()
                           , new FineThread()
                           , new Bleach()
                           , new BlackDye()
                           , new RedDye()
                           , new GreenDye()
                           , new SilkenThread()
                           , new GrayDye()
                           , new YellowDye()
                           , new PurpleDye()
                           , new BlueDye()
                           , new OrangeDye()
                           , new PatternBlueOveralls()
                           , new HeavySilkenThread()
  } ;
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}
}