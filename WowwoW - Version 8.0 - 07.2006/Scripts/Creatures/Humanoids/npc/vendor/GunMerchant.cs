//originally Scripted By DiScS Converter
//Edited by *place name here*
using System;
using Server.Items;
using Server;

////////////////////
namespace Server.Creatures
{
public class BlizrikBuckshot : BaseCreature 
 { 
public  BlizrikBuckshot() : base() 
 { 
Model = 7342;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Blizrik Buckshot" ;
Flags1 = 0x08080006 ;
Id = 8131 ; 
Guild = "Gunsmith";
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
NpcText00 = "Greetings $N, I am Blizrik Buckshot." ;
BaseMana = 0 ;
Sells = new Item[] { new AccurateSlugs()
                           , new SchematicEZThroDynamiteII()
                           , new LightShot()
                           , new HeavyShot()
                           , new LargeBoreBlunderbuss()
                           , new BKP2700Enforcer()
                           , new BKP42Ultra()
                           , new SolidShot()
  } ;
Faction = Factions.Gadgetzan;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 20504, InventoryTypes.RangeRight, 3, 1, 26, 0, 0, 0, 0 ));
}
}
public class ThulmanFlintcrag : BaseCreature 
 { 
public  ThulmanFlintcrag() : base() 
 { 
Model = 3306;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Thulman Flintcrag" ;
Flags1 = 0x08480046 ;
Id = 5510 ; 
Guild = "Guns Vendor";
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
NpcText00 = "Greetings $N, I am Thulman Flintcrag." ;
BaseMana = 0 ;
Sells = new Item[] { new OldBlunderbuss()
                           , new OrnateBlunderbuss()
                           , new SolidBlunderbuss()
                           , new LightShot()
                           , new HeavyShot()
                           , new SmallShotPouch()
  } ;
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 5569, InventoryTypes.OneHand, 14, 1, 21, 7, 0, 0, 0 ),new Item( 6535, InventoryTypes.HeldInHand, 0, 2, 23, 0, 0, 0, 0 ),new Item( 20726 , InventoryTypes.RangeRight, 3, 1, 26, 0, 0, 0, 0 ));
}
}
public class BrettaGoldfury : BaseCreature 
 { 
public  BrettaGoldfury() : base() 
 { 
Model = 5408;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Bretta Goldfury" ;
Flags1 = 0x08480046 ;
Id = 5123 ; 
Guild = "Gun Merchant";
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
NpcText00 = "Greetings $N, I am Bretta Goldfury." ;
BaseMana = 0 ;
Sells = new Item[] { new AccurateSlugs()
                           , new OrnateBlunderbuss()
                           , new SolidBlunderbuss()
                           , new LightShot()
                           , new HeavyShot()
                           , new LargeBoreBlunderbuss()
                           , new BKP2700Enforcer()
                           , new SolidShot()
                           , new SmallShotPouch()
  } ;
Faction = Factions.IronForge;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7453, InventoryTypes.OneHand, 4, 2, 13, 2, 0, 0, 0 ), new Item( 6593, InventoryTypes.RangeRight, 3, 1, 26, 0, 0, 0, 0 ));
}
}
public class LaeneThundershot : BaseCreature 
 { 
public  LaeneThundershot() : base() 
 { 
Model = 262;
AttackSpeed= 1554;
BoundingRadius = 1.00f ;
Name = "Laene Thundershot" ;
Flags1 = 0x102 ;
Id = 5104 ; 
Guild = "Guns and Ammuntion Merchant";
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
NpcText00 = "Greetings $N, I am Laene Thundershot." ;
BaseMana = 2004 ;
Faction = Factions.IronForge;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
}
}
public class TorqIronblast : BaseCreature 
 { 
public  TorqIronblast() : base() 
 { 
Model = 4828;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Torq Ironblast" ;
Flags1 = 0x08480046 ;
Id = 4889 ; 
Guild = "Gunsmith";
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
NpcText00 = "Greetings $N, I am Torq Ironblast." ;
BaseMana = 0 ;
Sells = new Item[] { new AccurateSlugs()
                           , new LightShot()
                           , new HeavyShot()
                           , new LargeBoreBlunderbuss()
                           , new BKP2700Enforcer()
                           , new SolidShot()
  } ;
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Item back = new Item( 20726, InventoryTypes.RangeRight, 3, 1, 26, 0, 0, 0, 0 );
back.InventoryType = InventoryTypes.Back;
Equip( back);
}
}
public class NicholasAtwood : BaseCreature 
 { 
public  NicholasAtwood() : base() 
 { 
Model = 2643;
AttackSpeed= 2000;
BoundingRadius = 0.383000f ;
Name = "Nicholas Atwood" ;
Flags1 = 0x018480046 ;
Id = 4603 ; 
Guild = "Gun Merchant";
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
NpcText00 = "Greetings $N, I am Nicholas Atwood." ;
BaseMana = 0 ;
Sells = new Item[] { new AccurateSlugs()
                           , new OrnateBlunderbuss()
                           , new SolidBlunderbuss()
                           , new LightShot()
                           , new HeavyShot()
                           , new LargeBoreBlunderbuss()
                           , new BKP2700Enforcer()
                           , new SolidShot()
                           , new SmallShotPouch()
  } ;
Faction = Factions.Undercity;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Item back = new Item( 6593, InventoryTypes.RangeRight, 3, 1, 26, 0, 0, 0, 0 );
back.InventoryType = InventoryTypes.Back;
Equip( back);
}
}
public class Kaja : BaseCreature 
 { 
public  Kaja() : base() 
 { 
Model = 1322;
AttackSpeed= 1739;
BoundingRadius = 1.047000f ;
Name = "Kaja" ;
Flags1 = 0x08480046 ;
Id = 3322 ; 
Guild = "Guns and Ammo Merchant";
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
CombatReach = 4.5f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Kaja." ;
BaseMana = 0 ;
Sells = new Item[] { new StrangeDust()
                           , new AccurateSlugs()
                           , new OrnateBlunderbuss()
                           , new HuntersBoomstick()
                           , new LightShot()
                           , new HeavyShot()
                           , new LargeBoreBlunderbuss()
                           , new BKP2700Enforcer()
                           , new SolidShot()
                           , new SmallShotPouch()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Item back = new Item( 6593, InventoryTypes.RangeRight, 3, 1, 26, 0, 0, 0, 0 );
back.InventoryType = InventoryTypes.Back;
Equip( back);
}
}
public class HenryChapal : BaseCreature 
 { 
public  HenryChapal() : base() 
 { 
Model = 3380;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Henry Chapal" ;
Flags1 = 0x08480046 ;
Id = 3088 ; 
Guild = "Gunsmith";
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
NpcText00 = "Greetings $N, I am Henry Chapal." ;
BaseMana = 0 ;
Sells = new Item[] { new HuntersBoomstick()
                           , new LightShot()
                           , new HeavyShot()
                           , new LargeBoreBlunderbuss()
                           , new SolidShot()
                           , new SmallShotPouch()
  } ;
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Item back = new Item( 6593, InventoryTypes.RangeRight, 3, 1, 26, 0, 0, 0, 0 );
back.InventoryType = InventoryTypes.Back;
Equip( back);
}
}
public class KennahHawkseye : BaseCreature 
 { 
public  KennahHawkseye() : base() 
 { 
Model = 3803;
AttackSpeed= 2000;
BoundingRadius = 0.974700f ;
Name = "Kennah Hawkseye" ;
Flags1 = 0x08480046 ;
Id = 3078 ; 
Guild = "Gunsmith";
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
Level = RandomLevel( 10 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 424 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 4.05f ;
SetDamage ( 10, 14 );
NpcText00 = "Greetings $N, I am Kennah Hawkseye." ;
BaseMana = 0 ;
Sells = new Item[] { new OrnateBlunderbuss()
                           , new SolidBlunderbuss()
                           , new LightShot()
                           , new HeavyShot()
                           , new SmallShotPouch()
  } ;
Faction = Factions.ThunderBluff;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Item back = new Item( 6593, InventoryTypes.RangeRight, 3, 1, 26, 0, 0, 0, 0 );
back.InventoryType = InventoryTypes.Back;
Equip( back);
}
}
public class Synge : BaseCreature 
 { 
public  Synge() : base() 
 { 
Model = 7219;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Synge" ;
Flags1 = 0x08480046 ;
Id = 3053 ; 
Guild = "Gun Merchant";
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
NpcText00 = "Greetings $N, I am Synge." ;
BaseMana = 0 ;
Sells = new Item[] { new AccurateSlugs()
                           , new LightShot()
                           , new HeavyShot()
                           , new LargeBoreBlunderbuss()
                           , new BKP2700Enforcer()
                           , new SolidShot()
  } ;
Faction = Factions.Friend;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Item back = new Item( 6593, InventoryTypes.RangeRight, 3, 1, 26, 0, 0, 0, 0 );
back.InventoryType = InventoryTypes.Back;
Equip( back);
}
}
public class HogorThunderhoof : BaseCreature 
 { 
public  HogorThunderhoof() : base() 
 { 
Model = 2086;
AttackSpeed= 2000;
BoundingRadius = 0.974700f ;
Name = "Hogor Thunderhoof" ;
Flags1 = 0x08480046 ;
Id = 3018 ; 
Guild = "Guns Merchant";
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
NpcText00 = "Greetings $N, I am Hogor Thunderhoof." ;
BaseMana = 0 ;
Sells = new Item[] { new AccurateSlugs()
                           , new OrnateBlunderbuss()
                           , new SolidBlunderbuss()
                           , new HuntersBoomstick()
                           , new LightShot()
                           , new HeavyShot()
                           , new LargeBoreBlunderbuss()
                           , new BKP2700Enforcer()
                           , new SolidShot()
                           , new SmallShotPouch()
  } ;
Faction = Factions.ThunderBluff;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Item back = new Item( 6593, InventoryTypes.RangeRight, 3, 1, 26, 0, 0, 0, 0 );
back.InventoryType = InventoryTypes.Back;
Equip( back);
}
}
public class VrokBlunderblast : BaseCreature 
 { 
public  VrokBlunderblast() : base() 
 { 
Model = 1847;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Vrok Blunderblast" ;
Flags1 = 0x08480046 ;
Id = 1469 ; 
Guild = "Gunsmith";
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
NpcText00 = "Greetings $N, I am Vrok Blunderblast." ;
BaseMana = 0 ;
Sells = new Item[] { new OrnateBlunderbuss()
                           , new HuntersBoomstick()
                           , new LightShot()
                           , new HeavyShot()
                           , new SmallShotPouch()
  } ;
Faction = Factions.IronForge;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Item back = new Item( 6593, InventoryTypes.RangeRight, 3, 1, 26, 0, 0, 0, 0 );
back.InventoryType = InventoryTypes.Back;
Equip( back);
}
}

public class LinaStover : BaseCreature 
 { 
public  LinaStover() : base() 
 { 
Model = 1446;
AttackSpeed= 2000;
BoundingRadius = 0.208000f ;
Name = "Lina Stover" ;
Flags1 = 0x08480046 ;
Id = 1297 ; 
Guild = "Bow & Gun Merchant";
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
NpcText00 = "Greetings $N, I am Lina Stover." ;
BaseMana = 0 ;
Sells = new Item[] { new AccurateSlugs()
                           , new MediumQuiver()
                           , new LightQuiver()
                           , new WornShortbow()
                           , new PolishedShortbow()
                           , new HornwoodRecurveBow()
                           , new LaminatedRecurveBow()
                           , new OrnateBlunderbuss()
                           , new SolidBlunderbuss()
                           , new HuntersBoomstick()
                           , new RoughArrow()
                           , new SharpArrow()
                           , new LightShot()
                           , new HeavyShot()
                           , new LargeBoreBlunderbuss()
                           , new BKP2700Enforcer()
                           , new ReinforcedBow()
                           , new HeavyRecurveBow()
                           , new RazorArrow()
                           , new SolidShot()
                           , new SmallQuiver()
                           , new SmallShotPouch()
  } ;
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Item back = new Item( 6593, InventoryTypes.RangeRight, 3, 1, 26, 0, 0, 0, 0 );
back.InventoryType = InventoryTypes.Back;
Equip( back);
}
}
public class HegnarRumbleshot : BaseCreature 
 { 
public  HegnarRumbleshot() : base() 
 { 
Model = 3412;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Hegnar Rumbleshot" ;
Flags1 = 0x08480046 ;
Id = 1243 ; 
Guild = "Gunsmith";
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
Level = RandomLevel( 9 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 424 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 10, 14 );
NpcText00 = "Greetings $N, I am Hegnar Rumbleshot." ;
BaseMana = 0 ;
Sells = new Item[] { new OrnateBlunderbuss()
                           , new SolidBlunderbuss()
                           , new LightShot()
                           , new HeavyShot()
                           , new SmallShotPouch()
  } ;
Faction = Factions.IronForge;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Item back = new Item( 6593, InventoryTypes.RangeRight, 3, 1, 26, 0, 0, 0, 0 );
back.InventoryType = InventoryTypes.Back;
Equip( back);
}
}
}