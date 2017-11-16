//originally Scripted By DiScS Converter
//Edited by *place name here*
using System;
using Server.Items;

////////////////////
namespace Server.Creatures
{
public class KurzenMindslave : BaseCreature 
 { 
public  KurzenMindslave() : base() 
 { 
Model = 5065;
AttackSpeed= 2000;
BoundingRadius = 0.306f ;
Name = "Kurzen Mindslave" ;
Flags1 = 0x04 ;
Id = 6366 ; 
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
Level = RandomLevel( 44 );
NpcType = 7 ;
BaseHitPoints = 2345 ;
NpcFlags = 0 ;
CombatReach = 1.5f ;
SetDamage ( 47, 60 );
BaseMana = 0 ;
Faction = Factions.Monster;
AIEngine = new PredatorAI( this );
Loots = new BaseTreasure[]{ new BaseTreasure( KurzenHumanoidDrops.KurzenHumanoid, 100f ) };


}
}
public class KurzenSubchief : BaseCreature 
 { 
public  KurzenSubchief() : base() 
 { 
Model = 4459;
AttackSpeed= 2000;
BoundingRadius = 0.306f ;
Name = "Kurzen Subchief" ;
Flags1 = 0x080000 ;
Id = 978 ; 
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
BaseHitPoints = 1845 ;
NpcFlags = 0 ;
CombatReach = 1.5f ;
SetDamage ( 41, 53 );
BaseMana = 0 ;
Equip( new BlackMetalAxe() ) ;
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
Loots = new BaseTreasure[]{ new BaseTreasure( KurzenHumanoidDrops.KurzenHumanoid, 100f ) };


}
}
public class KurzenShadowHunter : BaseCreature 
 { 
public  KurzenShadowHunter() : base() 
 { 
Model = 4454;
AttackSpeed= 2000;
BoundingRadius = 0.306f ;
Name = "Kurzen Shadow Hunter" ;
Flags1 = 0x080000 ;
Id = 979 ; 
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
BaseHitPoints = 1845 ;
NpcFlags = 0 ;
CombatReach = 1.5f ;
SetDamage ( 41, 53 );
BaseMana = 0 ;
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
Loots = new BaseTreasure[]{ new BaseTreasure( KurzenHumanoidDrops.KurzenHumanoid, 100f ) };


}
}
public class KurzenJungleFighter : BaseCreature 
 { 
public  KurzenJungleFighter() : base() 
 { 
Model = 4443;
AttackSpeed= 2000;
BoundingRadius = 0.306f ;
Name = "Kurzen Jungle Fighter" ;
Flags1 = 0x080000 ;
Id = 937 ; 
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
NpcType = 7 ;
BaseHitPoints = 1324 ;
NpcFlags = 0 ;
CombatReach = 1.5f ;
SetDamage ( 32, 42 );
BaseMana = 0 ;
Equip( new Longsword() ) ;
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
Loots = new BaseTreasure[]{ new BaseTreasure( KurzenHumanoidDrops.KurzenHumanoid, 100f ) };


}
}
public class KurzenCommando : BaseCreature 
 { 
public  KurzenCommando() : base() 
 { 
Model = 4439;
AttackSpeed= 2000;
BoundingRadius = 0.306f ;
Name = "Kurzen Commando" ;
Flags1 = 0x080000 ;
Id = 938 ; 
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
BaseHitPoints = 1644 ;
NpcFlags = 0 ;
CombatReach = 1.5f ;
SetDamage ( 36, 46 );
BaseMana = 0 ;
Equip( new Longsword() ) ;
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
Loots = new BaseTreasure[]{ new BaseTreasure( KurzenHumanoidDrops.KurzenHumanoid, 100f ) };


}
}
public class KurzenElite : BaseCreature 
 { 
public  KurzenElite() : base() 
 { 
Model = 4446;
AttackSpeed= 2000;
BoundingRadius = 0.306f ;
Name = "Kurzen Elite" ;
Flags1 = 0x080000 ;
Id = 939 ; 
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
Level = RandomLevel( 37 );
NpcType = 7 ;
BaseHitPoints = 1724 ;
NpcFlags = 0 ;
CombatReach = 1.5f ;
SetDamage ( 38, 49 );
BaseMana = 0 ;
Equip( new Longsword() ) ;
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
Loots = new BaseTreasure[]{ new BaseTreasure( KurzenHumanoidDrops.KurzenHumanoid, 100f ) };


}
}
public class KurzenMedicineMan : BaseCreature 
 { 
public  KurzenMedicineMan() : base() 
 { 
Model = 4436;
AttackSpeed= 2000;
BoundingRadius = 0.306f ;
Name = "Kurzen Medicine Man" ;
Flags1 = 0x080000 ;
Id = 940 ; 
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
NpcType = 7 ;
BaseHitPoints = 1564 ;
NpcFlags = 0 ;
CombatReach = 1.5f ;
SetDamage ( 33, 43 );
BaseMana = 0 ;
Equip( new DuskWand() ) ;
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
Loots = new BaseTreasure[]{ new BaseTreasure( KurzenHumanoidDrops.KurzenHumanoid, 100f ) };


}
}
public class KurzenHeadshrinker : BaseCreature 
 { 
public  KurzenHeadshrinker() : base() 
 { 
Model = 4444;
AttackSpeed= 2000;
BoundingRadius = 0.306f ;
Name = "Kurzen Headshrinker" ;
Flags1 = 0x080000 ;
Id = 941 ; 
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
BaseHitPoints = 1484 ;
NpcFlags = 0 ;
CombatReach = 1.5f ;
SetDamage ( 37, 48 );
BaseMana = 0 ;
Equip( new DuskWand() ) ;
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
Loots = new BaseTreasure[]{ new BaseTreasure( KurzenHumanoidDrops.KurzenHumanoid, 100f ) };


}
}
public class KurzenWitchDoctor : BaseCreature 
 { 
public  KurzenWitchDoctor() : base() 
 { 
Model = 4450;
AttackSpeed= 2000;
BoundingRadius = 0.306f ;
Name = "Kurzen Witch Doctor" ;
Flags1 = 0x080000 ;
Id = 942 ; 
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
Level = RandomLevel( 37 );
NpcType = 7 ;
BaseHitPoints = 1824 ;
NpcFlags = 0 ;
CombatReach = 1.5f ;
SetDamage ( 38, 49 );
BaseMana = 0 ;
Equip( new DuskWand() ) ;
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
Loots = new BaseTreasure[]{ new BaseTreasure( KurzenHumanoidDrops.KurzenHumanoid, 100f ) };


}
}
public class KurzenWrangler : BaseCreature 
 { 
public  KurzenWrangler() : base() 
 { 
Model = 4438;
AttackSpeed= 2000;
BoundingRadius = 0.306f ;
Name = "Kurzen Wrangler" ;
Flags1 = 0x080000 ;
Id = 943 ; 
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
Level = RandomLevel( 34 );
NpcType = 7 ;
BaseHitPoints = 1884 ;
NpcFlags = 0 ;
CombatReach = 1.5f ;
SetDamage ( 37, 48 );
BaseMana = 0 ;
Equip( new Longsword() ) ;
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
Loots = new BaseTreasure[]{ new BaseTreasure( KurzenHumanoidDrops.KurzenHumanoid, 100f ) };


}
}
public class ColonelKurzen : BaseCreature 
 { 
public  ColonelKurzen() : base() 
 { 
Model = 637;
AttackSpeed= 1700;
BoundingRadius = 0.336600f ;
Name = "Colonel Kurzen" ;
Flags1 = 0x080000 ;
Id = 813 ; 
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 50;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 40 );
NpcType = 7 ;
BaseHitPoints = 4875 ;
NpcFlags = 0 ;
CombatReach = 1.65f ;
SetDamage ( 50, 62 );
BaseMana = 0 ;
Elite = 1 ;
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
Equip( new KnightlyLongsword() ) ;
Loots = new BaseTreasure[]{ new BaseTreasure( KurzenHumanoid1Drops.KurzenHumanoid1, 100f ) };


}
}
public class KurzensAgent : BaseCreature 
 { 
public  KurzensAgent() : base() 
 { 
Model = 4460;
AttackSpeed= 1680;
BoundingRadius = 0.561f ;
Name = "Kurzens Agent" ;
Flags1 = 0x080000 ;
Id = 775 ; 
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
Level = RandomLevel( 31 );
NpcType = 7 ;
BaseHitPoints = 1264 ;
NpcFlags = 0 ;
CombatReach = 0.8f ;
SetDamage ( 33, 43 );
BaseMana =  0;
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
Loots = new BaseTreasure[]{ new BaseTreasure( KurzenHumanoidDrops.KurzenHumanoid, 100f ) };


}
}
	
}