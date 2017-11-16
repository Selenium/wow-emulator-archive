//originally Scripted By DiScS Converter
//Edited by *place name here*
using System;
using Server.Items;

////////////////////
namespace Server.Creatures
{
public class TwilightLordEverun : BaseCreature 
 { 
public  TwilightLordEverun() : base() 
 { 
Model = 14526;
AttackSpeed= 1061;
BoundingRadius = 0.208f ;
Name = "Twilight Lord Everun" ;
Flags1 = 0x00000000 ;
Id = 14479 ; 
Guild = "Twilights Hammer";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 100;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 60 );
NpcType = 7 ;
BaseHitPoints = 11704 ;
NpcFlags = 0 ;
CombatReach = 5.91f ;
SetDamage ( 250, 330 );
Equip( new LunarWand() ) ;
Faction = Factions.Monster;
AIEngine = new PredatorAI( this );
Loots = new BaseTreasure[]{ new BaseTreasure( TwilightsHammerDrops.TwilightsHammer, 100f ) };
// Rare = 1 ;

}
}
public class TwilightMaster : BaseCreature 
 { 
public  TwilightMaster() : base() 
 { 
Model = 11824;
AttackSpeed= 2100;
BoundingRadius = 0.561f ;
Name = "Twilight Master" ;
Flags1 = 0x080000 ;
Id = 11883 ; 
Guild = "Twilights Hammer";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 100;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 59 );
NpcType = 7 ;
BaseHitPoints = 8432 ;
NpcFlags = 0 ;
CombatReach = 0.8f ;
SetDamage ( 215, 291 );
Equip( new GrinningAxe());
Faction = Factions.Monster;
AIEngine = new EvilInteligentMonsterAI( this );
Loots = new BaseTreasure[]{ new BaseTreasure( TwilightsHammerDrops.TwilightsHammer, 100f ) };


}
}

public class TwilightStonecaller : BaseCreature 
 { 
public  TwilightStonecaller() : base() 
 { 
Model = 11815;
AttackSpeed= 2100;
BoundingRadius = 0.561f ;
Name = "Twilight Stonecaller" ;
Flags1 = 0x080000 ;
Id = 11882 ; 
Guild = "Twilights Hammer";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 100;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 57 );
NpcType = 7 ;
BaseHitPoints = 7563 ;
NpcFlags = 0 ;
CombatReach = 0.8f ;
SetDamage ( 215, 291 );
Equip( new SolsticeStaff());
Faction = Factions.Monster;
AIEngine = new EvilInteligentMonsterAI( this );
Loots = new BaseTreasure[]{ new BaseTreasure( TwilightsHammerDrops.TwilightsHammer, 100f ) };


}
}
public class TwilightGeolord : BaseCreature 
 { 
public  TwilightGeolord() : base() 
 { 
Model = 11819;
AttackSpeed= 2100;
BoundingRadius = 0.561f ;
Name = "Twilight Geolord" ;
Flags1 = 0x080000 ;
Id = 11881 ; 
Guild = "Twilights Hammer";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 100;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 58 );
NpcType = 7 ;
BaseHitPoints = 8432 ;
NpcFlags = 0 ;
CombatReach = 0.8f ;
SetDamage ( 215, 291 );
Equip( new IvoryWand());
Faction = Factions.Monster;
AIEngine = new EvilInteligentMonsterAI( this );
Loots = new BaseTreasure[]{ new BaseTreasure( TwilightsHammerDrops.TwilightsHammer, 100f ) };


}
}
public class TwilightAvenger : BaseCreature 
 { 
public  TwilightAvenger() : base() 
 { 
Model = 11811;
AttackSpeed= 2100;
BoundingRadius = 0.561f ;
Name = "Twilight Avenger" ;
Flags1 = 0x080000 ;
Id = 11880 ; 
Guild = "Twilights Hammer";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 100;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 57 );
NpcType = 7 ;
BaseHitPoints = 7112 ;
NpcFlags = 0 ;
CombatReach = 0.8f ;
SetDamage ( 215, 291 );
Equip( new GrinningAxe());
Faction = Factions.Monster;
AIEngine = new EvilInteligentMonsterAI( this );
Loots = new BaseTreasure[]{ new BaseTreasure( TwilightsHammerDrops.TwilightsHammer, 100f ) };


}
}
public class Willow : BaseCreature 
 { 
public  Willow() : base() 
 { 
Model = 13909;
AttackSpeed= 2000;
BoundingRadius = 0.383f ;
Name = "Willow" ;
Flags1 = 0x0480006 ;
Id = 13656 ; 
Guild = "Twilights Hammer";
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 100;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 45 );
NpcType = 7 ;
BaseHitPoints = 1825 ;
NpcFlags = 2 ;
CombatReach = 1.5f ;
SetDamage ( 110, 130 );
NpcText00 = "Greetings $N, I am Willow." ;
Faction = Factions.Friend;
new NonAgressiveAnimalAI( this );
Loots = new BaseTreasure[]{ new BaseTreasure( TwilightsHammerDrops.TwilightsHammer, 100f ) };


}
}
public class TwilightsHammerExecutioner : BaseCreature 
 { 
public  TwilightsHammerExecutioner() : base() 
 { 
Model = 8706;
AttackSpeed= 1119;
BoundingRadius = 0.561f ;
Name = "Twilights Hammer Executioner" ;
Flags1 = 0x080000 ;
Id = 9398 ; 
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 100;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 55 );
NpcType = 7 ;
BaseHitPoints = 6678 ;
NpcFlags = 0 ;
CombatReach = 1.5f ;
SetDamage ( 170, 180 );
Faction = Factions.Monster;
AIEngine = new PredatorAI( this );
Loots = new BaseTreasure[]{ new BaseTreasure( TwilightsHammerDrops.TwilightsHammer, 100f ) };


}
}
public class TwilightsHammerAmbassador : BaseCreature 
 { 
public  TwilightsHammerAmbassador() : base() 
 { 
Model = 8778;
AttackSpeed= 1357;
BoundingRadius = 0.561f ;
Name = "Twilights Hammer Ambassador" ;
Flags1 = 0x080000 ;
Id = 8915 ; 
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 100;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 55 );
NpcType = 7 ;
BaseHitPoints = 4342 ;
NpcFlags = 0 ;
CombatReach = 0.8f ;
SetDamage ( 120, 150 );
Faction = Factions.Monster;
AIEngine = new PredatorAI( this );
Loots = new BaseTreasure[]{ new BaseTreasure( TwilightsHammerDrops.TwilightsHammer, 100f ) };


}
}
public class TwilightsHammerTorturer : BaseCreature 
 { 
public  TwilightsHammerTorturer() : base() 
 { 
Model = 8790;
AttackSpeed= 1201;
BoundingRadius = 0.587f ;
Name = "Twilights Hammer Torturer" ;
Flags1 = 0x080000 ;
Id = 8912 ; 
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 100;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 48 );
NpcType = 7 ;
BaseHitPoints = 5835 ;
NpcFlags = 0 ;
CombatReach = 0.8f ;
SetDamage ( 90, 110 );
Faction = Factions.Monster;
AIEngine = new PredatorAI( this );
Loots = new BaseTreasure[]{ new BaseTreasure( TwilightsHammerDrops.TwilightsHammer, 100f ) };


}
}
	
}