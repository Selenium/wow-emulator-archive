//script created by ccsman 17/08/05
//i've used :
//size formula : Size = 0.8f + Level/100f;    0.9 for elite/rare
//dmg formula : SetDamage ((1.5f*AttackSpeed/1000f)*Level, (2.5f*AttackSpeed/1000f)*Level );    to get a stable DPS   

using System;
using System.Collections;
using Server;
using Server.Items;

namespace Server.Creatures
{
public class LordKazzak : BaseCreature 
 { 
public  LordKazzak() : base() 
 { 
Model = 12449;
AttackSpeed= 900;
BoundingRadius = 0.3f ;
Name = "Lord Kazzak" ;
Flags1 = 0x00000000 ;
Id = 12397 ; 
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = 63;
Elite = 3;
BaseHitPoints = 37500 ;
NpcFlags = 0 ;
CombatReach = 2.00f ;
SetDamage ( 1450 , 1500 );
NpcText00 = "Hello" ;
BaseMana = 13480 ;
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
Loots = new BaseTreasure[]{ new BaseTreasure( DoomguardFamilyDrops.LordKazzak, 100f ) };
}
}
}
namespace Server.Creatures
{
public class Balnazzar : BaseCreature 
 { 
public  Balnazzar() : base() 
 { 
Model = 10691;
AttackSpeed= 1050;
BoundingRadius = 1.00f ;
Name = "Balnazzar" ;
Flags1 = 0x01000 ;
Id = 10813 ; 
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 57, 62 );
Elite = 2;
NpcType = (int)NpcTypes.Demon;
BaseMana = Level*70;
BaseHitPoints = MobArmorHP.GetMobHP ( Level)*4;
Armor = MobArmorHP.GetMobArmor ( Level);
NpcFlags = 0 ;
CombatReach = 2.5f ;
SetDamage ((1.5f*AttackSpeed/1000f)*Level, (3f*AttackSpeed/1000f)*Level );
LearnSpell( 15571, SpellsTypes.Curse );
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
Loots = new BaseTreasure[]{ new BaseTreasure( DoomguardFamilyDrops.Balnazzar, 100f ) };


}
}
}
namespace Server.Creatures
{
public class DemonPortalGuardian : BaseCreature 
{
public  DemonPortalGuardian() : base() 
 { 
Model = 9017;
AttackSpeed= 2000;
BoundingRadius = 1.3f ;
Name = "Demon Portal Guardian" ;
Flags1 = 0x00000000 ;
Id = 11937 ; 
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 35, 38 );
NpcType = (int)NpcTypes.Demon;
BaseMana = Level*70;
BaseHitPoints = MobArmorHP.GetMobHP ( Level);
Armor = MobArmorHP.GetMobArmor ( Level);
NpcFlags = 0 ;
CombatReach = 2.5f ;
SetDamage ((1.5f*AttackSpeed/1000f)*Level, (3f*AttackSpeed/1000f)*Level );
LearnSpell( 15571, SpellsTypes.Curse );
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
Loots = new BaseTreasure[]{ new BaseTreasure( DoomguardFamilyDrops.DemonPortalGuardian, 100f ) };


}
}
}
namespace Server.Creatures
{
public class DoomguardCommander : BaseCreature 
 { 
public  DoomguardCommander() : base() 
 { 
Model = 4426;
AttackSpeed= 2000;
BoundingRadius = 0.9932f ;
Name = "Doomguard Commander" ;
Flags1 = 0x00000000 ;
Id = 12396 ; 
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 57, 61 );
Elite = 2 ;
NpcType = (int)NpcTypes.Demon;
BaseMana = Level*70;
BaseHitPoints = MobArmorHP.GetMobHP ( Level)*3;
Armor = MobArmorHP.GetMobArmor ( Level);
NpcFlags = 0 ;
CombatReach = 2.5f ;
SetDamage ((1.5f*AttackSpeed/1000f)*Level, (3f*AttackSpeed/1000f)*Level );
LearnSpell( 15571, SpellsTypes.Curse );
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
Loots = new BaseTreasure[]{ new BaseTreasure( DoomguardFamilyDrops.DoomguardCommander, 100f ) };


}
}
}
namespace Server.Creatures
{ 
public class DoomguardMinion : BaseCreature 
 { 
public  DoomguardMinion() : base() 
 { 
Model = 1912;
AttackSpeed= 2000;
BoundingRadius = 0.9932f ;
Name = "Doomguard Minion" ;
Flags1 = 0x00000000 ;
Id = 14385 ; 
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 54, 60 );
NpcType = (int)NpcTypes.Demon;
BaseMana = Level*70;
BaseHitPoints = MobArmorHP.GetMobHP ( Level);
Armor = MobArmorHP.GetMobArmor ( Level);
NpcFlags = 0 ;
CombatReach = 2.5f ;
SetDamage ((1.5f*AttackSpeed/1000f)*Level, (3f*AttackSpeed/1000f)*Level );
LearnSpell( 15571, SpellsTypes.Curse );
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
Loots = new BaseTreasure[]{ new BaseTreasure( DoomguardFamilyDrops.DoomguardMinion, 100f ) };


}
}
}
namespace Server.Creatures
{
public class Doomwarder : BaseCreature 
 { 
public  Doomwarder() : base() 
 { 
Model = 5049;
AttackSpeed= 2000;
BoundingRadius = 1f ;
Name = "Doomwarder" ;
Flags1 = 0x00000000 ;
Id = 4677 ; 
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 37, 38 );
NpcType = (int)NpcTypes.Demon;
BaseMana = Level*70;
BaseHitPoints = MobArmorHP.GetMobHP ( Level);
Armor = MobArmorHP.GetMobArmor ( Level);
NpcFlags = 0 ;
CombatReach = 2.5f ;
SetDamage ((1.5f*AttackSpeed/1000f)*Level, (3f*AttackSpeed/1000f)*Level );
LearnSpell( 15571, SpellsTypes.Curse );
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
Loots = new BaseTreasure[]{ new BaseTreasure( DoomguardFamilyDrops.Doomwarder, 100f ) };


}
}
}
namespace Server.Creatures
{
public class DoomwarderCaptain : BaseCreature 
 { 
public  DoomwarderCaptain() : base() 
 { 
Model = 9015;
AttackSpeed= 2000;
BoundingRadius = 1.15f ;
Name = "Doomwarder Captain" ;
Flags1 = 0x00000000 ;
Id = 4680 ; 
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 38, 39 );
NpcType = (int)NpcTypes.Demon;
BaseMana = Level*70;
BaseHitPoints = MobArmorHP.GetMobHP ( Level);
Armor = MobArmorHP.GetMobArmor ( Level);
NpcFlags = 0 ;
CombatReach = 2.5f ;
SetDamage ((1.5f*AttackSpeed/1000f)*Level, (3f*AttackSpeed/1000f)*Level );
LearnSpell( 15571, SpellsTypes.Curse );
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
Loots = new BaseTreasure[]{ new BaseTreasure( DoomguardFamilyDrops.DoomwarderCaptain, 100f ) };


}
}
}
namespace Server.Creatures
{
public class DoomwarderLord : BaseCreature 
 { 
public  DoomwarderLord() : base() 
 { 
Model = 9015;
AttackSpeed= 2000;
BoundingRadius = 1.15f ;
Name = "Doomwarder Lord" ;
Flags1 = 0x00000000 ;
Id = 4683 ; 
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 39, 40 );
NpcType = (int)NpcTypes.Demon;
BaseMana = Level*70;
BaseHitPoints = MobArmorHP.GetMobHP ( Level);
Armor = MobArmorHP.GetMobArmor ( Level);
NpcFlags = 0 ;
CombatReach = 2.5f ;
SetDamage ((1.5f*AttackSpeed/1000f)*Level, (3f*AttackSpeed/1000f)*Level );
LearnSpell( 15571, SpellsTypes.Curse );
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
Loots = new BaseTreasure[]{ new BaseTreasure( DoomguardFamilyDrops.DoomwarderCaptain, 100f ) };


}
}
}
namespace Server.Creatures
{
public class GrolTheDestroyer : BaseCreature 
 { 
public  GrolTheDestroyer() : base() 
 { 
Model = 10169;
AttackSpeed= 1084;
BoundingRadius = 1.00f ;
Name = "Grol the Destroyer" ;
Flags1 = 0x08 ;
Id = 7665 ; 
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 54, 58 );
Elite = 2;
NpcType = (int)NpcTypes.Demon;
BaseMana = Level*70;
BaseHitPoints = MobArmorHP.GetMobHP ( Level)*3;
Armor = MobArmorHP.GetMobArmor ( Level);
NpcFlags = 0 ;
CombatReach = 2.5f ;
SetDamage ((1.5f*AttackSpeed/1000f)*Level, (3f*AttackSpeed/1000f)*Level );
LearnSpell( 15571, SpellsTypes.Curse );
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
Loots = new BaseTreasure[]{ new BaseTreasure( DoomguardFamilyDrops.GrolTheDestroyer, 100f ) };


}
}
}
namespace Server.Creatures
{
public class LordAzrethoc : BaseCreature 
 { 
public  LordAzrethoc() : base() 
 { 
Model = 4426;
AttackSpeed= 2000;
BoundingRadius = 0.9932f ;
Name = "Lord Azrethoc" ;
Flags1 = 0x00000000 ;
Id = 5760 ; 
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = 40;
Elite = 2;
NpcType = (int)NpcTypes.Demon;
BaseMana = Level*70;
BaseHitPoints = MobArmorHP.GetMobHP ( Level)*3;
Armor = MobArmorHP.GetMobArmor ( Level);
NpcFlags = 0 ;
CombatReach = 2.5f ;
SetDamage ((1.5f*AttackSpeed/1000f)*Level, (3f*AttackSpeed/1000f)*Level );
LearnSpell( 15571, SpellsTypes.Curse );
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
Loots = new BaseTreasure[]{ new BaseTreasure( DoomguardFamilyDrops.LordAzrethoc, 100f ) };


}
}
}
namespace Server.Creatures
{
public class LordBanehollow : BaseCreature 
 { 
public  LordBanehollow() : base() 
 { 
Model = 8611;
AttackSpeed= 1073;
BoundingRadius = 1.00f ;
Name = "Lord Banehollow" ;
Flags1 = 0x00000000 ;
Id = 9516 ; 
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 56, 59 );
Elite = 2;
NpcType = (int)NpcTypes.Demon;
BaseMana = Level*70;
BaseHitPoints = MobArmorHP.GetMobHP ( Level)*3;
Armor = MobArmorHP.GetMobArmor ( Level);
NpcFlags = 0 ;
CombatReach = 2.5f ;
SetDamage ((1.5f*AttackSpeed/1000f)*Level, (3f*AttackSpeed/1000f)*Level );
LearnSpell( 15571, SpellsTypes.Curse );
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
Loots = new BaseTreasure[]{ new BaseTreasure( DoomguardFamilyDrops.LordBanehollow, 100f ) };


}
}
}

namespace Server.Creatures
{
public class  RazelikhTheDefiler  : BaseCreature 
 { 
public   RazelikhTheDefiler () : base() 
 { 
Model = 10543;
AttackSpeed= 1073;
BoundingRadius = 1.00f ;
Name = "Razelikh the Defiler" ;
Flags1 = 0x00000000 ;
Id = 7664 ; 
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 58, 60 );
Elite = 2;
NpcType = (int)NpcTypes.Demon;
BaseMana = Level*70;
BaseHitPoints = MobArmorHP.GetMobHP ( Level)*3;
Armor = MobArmorHP.GetMobArmor ( Level);
NpcFlags = 0 ;
CombatReach = 2.5f ;
SetDamage ((1.5f*AttackSpeed/1000f)*Level, (3f*AttackSpeed/1000f)*Level );
LearnSpell( 15571, SpellsTypes.Curse );
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
Loots = new BaseTreasure[]{ new BaseTreasure( DoomguardFamilyDrops.RazelikhTheDefiler, 100f ) };


}
}
}
namespace Server.Creatures
{
public class Varimathras : BaseCreature 
 { 
public  Varimathras() : base() 
 { 
Model = 11658;
AttackSpeed= 2000;
BoundingRadius = 1.2f ;
Name = "Varimathras" ;
Flags1 = 0x08C11000 ;
Id = 2425 ; 
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = 62 ;
Elite = 3 ;
NpcType = (int)NpcTypes.Demon;
BaseMana = Level*70;
BaseHitPoints = MobArmorHP.GetMobHP ( Level)*5;
Armor = MobArmorHP.GetMobArmor ( Level);
NpcFlags = 0 ;
CombatReach = 2.5f ;
SetDamage ((1.5f*AttackSpeed/1000f)*Level, (3f*AttackSpeed/1000f)*Level );
LearnSpell( 15571, SpellsTypes.Curse );
Faction = Factions.Undercity;
AIEngine = new AgressiveAnimalAI( this );

}
}
}
namespace Server.Creatures
{
public class  BurningFelguard : BaseCreature 
 { 
public   BurningFelguard() : base() 
 { 
Model = 5047;
AttackSpeed= 2000;
BoundingRadius = 1.2f ;
Name = " Burning Felguard" ;
Flags1 = 0x08C11000 ;
Id = 10263 ; 
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 54, 57 );
Elite = 4;
NpcType = (int)NpcTypes.Demon;
BaseMana = Level*70;
BaseHitPoints = MobArmorHP.GetMobHP ( Level);
Armor = MobArmorHP.GetMobArmor ( Level);
NpcFlags = 0 ;
CombatReach = 2.5f ;
SetDamage ((1.5f*AttackSpeed/1000f)*Level, (3f*AttackSpeed/1000f)*Level );
LearnSpell( 15571, SpellsTypes.Curse );
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
Loots = new BaseTreasure[]{ new BaseTreasure( DoomguardFamilyDrops.BurningFelguard, 100f ) };


}
}
}
namespace Server.Creatures
{
public class  DreadGuard : BaseCreature 
 { 
public   DreadGuard() : base() 
 { 
Model = 14152;
AttackSpeed= 2000;
BoundingRadius = 1.2f ;
Name = " Dread Guard" ;
Flags1 = 0x08C11000 ;
Id = 14483 ; 
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 56, 60 );
Elite = 2;
NpcType = (int)NpcTypes.Demon;
BaseMana = Level*70;
BaseHitPoints = MobArmorHP.GetMobHP ( Level)*3;
Armor = MobArmorHP.GetMobArmor ( Level);
NpcFlags = 0 ;
CombatReach = 2.5f ;
SetDamage ((1.5f*AttackSpeed/1000f)*Level, (3f*AttackSpeed/1000f)*Level );
LearnSpell( 15571, SpellsTypes.Curse );
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );

}
}
}
namespace Server.Creatures
{
public class Dreadlord : BaseCreature 
 { 
public  Dreadlord() : base() 
 { 
Model = 10543;
AttackSpeed= 1050;
BoundingRadius = 1.00f ;
Name = "Dreadlord" ;
Flags1 = 0x00000000 ;
Id = 8716 ; 
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 62 );
Elite = 1;
NpcType = (int)NpcTypes.Demon;
BaseMana = Level*70;
BaseHitPoints = MobArmorHP.GetMobHP ( Level)*3;
Armor = MobArmorHP.GetMobArmor ( Level);
NpcFlags = 0 ;
CombatReach = 2.5f ;
SetDamage ((1.5f*AttackSpeed/1000f)*Level, (3f*AttackSpeed/1000f)*Level );
LearnSpell( 15571, SpellsTypes.Curse );
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
Loots = new BaseTreasure[]{ new BaseTreasure( DoomguardFamilyDrops.Dreadlord, 100f ) };


}
}
}
namespace Server.Creatures
{
public class EnragedFelguard : BaseCreature 
 { 
public  EnragedFelguard() : base() 
 { 
Model = 5048;
AttackSpeed= 1050;
BoundingRadius = 1.00f ;
Name = "Enraged Felguard" ;
Flags1 = 0x00000000 ;
Id = 14101 ; 
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = 60 ;
Elite = 2;
NpcType = (int)NpcTypes.Demon;
BaseMana = Level*70;
BaseHitPoints = MobArmorHP.GetMobHP ( Level)*3;
Armor = MobArmorHP.GetMobArmor ( Level);
NpcFlags = 0 ;
CombatReach = 2.5f ;
SetDamage ((1.5f*AttackSpeed/1000f)*Level, (3f*AttackSpeed/1000f)*Level );
LearnSpell( 15571, SpellsTypes.Curse );
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
Loots = new BaseTreasure[]{ new BaseTreasure( DoomguardFamilyDrops.Felguard, 100f ) };


}
}
}
namespace Server.Creatures
{
public class EnslavedDoomguardCommander : BaseCreature 
 { 
public  EnslavedDoomguardCommander() : base() 
 { 
Model = 4426;
AttackSpeed= 2000;
BoundingRadius = 0.9932f ;
Name = "Enslaved Doomguard Commander" ;
Flags1 = 0x00000000 ;
Id = 14452 ; 
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = 61;
Elite = 2;
NpcType = (int)NpcTypes.Demon;
BaseMana = Level*70;
BaseHitPoints = MobArmorHP.GetMobHP ( Level)*3;
Armor = MobArmorHP.GetMobArmor ( Level);
NpcFlags = 0 ;
CombatReach = 2.5f ;
SetDamage ((1.5f*AttackSpeed/1000f)*Level, (3f*AttackSpeed/1000f)*Level );
LearnSpell( 15571, SpellsTypes.Curse );
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
Loots = new BaseTreasure[]{ new BaseTreasure( DoomguardFamilyDrops.DoomguardCommander, 100f ) };


}
}
}
namespace Server.Creatures
{
public class Felguard : BaseCreature 
 { 
public  Felguard() : base() 
 { 
Model = 5048;
AttackSpeed= 2000;
BoundingRadius = 1f ;
Name = "Felguard" ;
Flags1 = 0x00000000 ;
Id = 6115 ; 
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 29, 30 );
NpcType = (int)NpcTypes.Demon;
BaseMana = Level*70;
BaseHitPoints = MobArmorHP.GetMobHP ( Level);
Armor = MobArmorHP.GetMobArmor ( Level);
NpcFlags = 0 ;
CombatReach = 2.5f ;
SetDamage ((1.5f*AttackSpeed/1000f)*Level, (3f*AttackSpeed/1000f)*Level );
LearnSpell( 15571, SpellsTypes.Curse );
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
Loots = new BaseTreasure[]{ new BaseTreasure( DoomguardFamilyDrops.Felguard, 100f ) };


}
}
}
namespace Server.Creatures
{
public class FelguardElite : BaseCreature 
 { 
public  FelguardElite() : base() 
 { 
Model = 7970;
AttackSpeed= 2000;
BoundingRadius = 1.5f ;
Name = "Felguard Elite" ;
Flags1 = 0x00000000 ;
Id = 8717 ; 
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 56, 61 );
Elite = 2;
NpcType = (int)NpcTypes.Demon;
BaseMana = Level*70;
BaseHitPoints = MobArmorHP.GetMobHP ( Level)*3;
Armor = MobArmorHP.GetMobArmor ( Level);
NpcFlags = 0 ;
CombatReach = 2.5f ;
SetDamage ((1.5f*AttackSpeed/1000f)*Level, (3f*AttackSpeed/1000f)*Level );
LearnSpell( 15571, SpellsTypes.Curse );
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
Loots = new BaseTreasure[]{ new BaseTreasure( DoomguardFamilyDrops.FelguardElite, 100f ) };


}
}
}
namespace Server.Creatures
{ 
public class FelguardSentry : BaseCreature 
 { 
public  FelguardSentry() : base() 
 { 
Model = 9017;
AttackSpeed= 2000;
BoundingRadius = 1.3f ;
Name = "Felguard Sentry" ;
Flags1 = 0x00000000 ;
Id = 6011 ; 
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 53, 55 );
NpcType = (int)NpcTypes.Demon;
BaseMana = Level*70;
BaseHitPoints = MobArmorHP.GetMobHP ( Level);
Armor = MobArmorHP.GetMobArmor ( Level);
NpcFlags = 0 ;
CombatReach = 2.5f ;
SetDamage ((1.5f*AttackSpeed/1000f)*Level, (3f*AttackSpeed/1000f)*Level );
LearnSpell( 15571, SpellsTypes.Curse );
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
Loots = new BaseTreasure[]{ new BaseTreasure( DoomguardFamilyDrops.FelguardSentry, 100f ) };


}
}
}
namespace Server.Creatures
{ 
public class LesserFelguard : BaseCreature 
 { 
public  LesserFelguard() : base() 
 { 
Model = 5049;
AttackSpeed= 2000;
BoundingRadius = 1f ;
Name = "Lesser Felguard" ;
Flags1 = 0x00000000 ;
Id = 3772 ; 
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 23, 24 );
NpcType = (int)NpcTypes.Demon;
BaseMana = Level*70;
BaseHitPoints = MobArmorHP.GetMobHP ( Level);
Armor = MobArmorHP.GetMobArmor ( Level);
NpcFlags = 0 ;
CombatReach = 2.5f ;
SetDamage ((1.5f*AttackSpeed/1000f)*Level, (3f*AttackSpeed/1000f)*Level );
LearnSpell( 15571, SpellsTypes.Curse );
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
Loots = new BaseTreasure[]{ new BaseTreasure( DoomguardFamilyDrops.LesserFelguard, 100f ) };


}
}
}
namespace Server.Creatures
{
public class DemonSpirit : BaseCreature 
 { 
public  DemonSpirit() : base() 
 { 
Model = 4427;
AttackSpeed= 1609;
BoundingRadius = 1.00f ;
Name = "Demon Spirit" ;
Flags1 = 0x00000000 ;
Id = 11876 ; 
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 35, 37 );
NpcType = (int)NpcTypes.Demon;
BaseMana = Level*70;
BaseHitPoints = MobArmorHP.GetMobHP ( Level);
Armor = MobArmorHP.GetMobArmor ( Level);
NpcFlags = 0 ;
CombatReach = 2.5f ;
SetDamage ((1.5f*AttackSpeed/1000f)*Level, (3f*AttackSpeed/1000f)*Level );
LearnSpell( 15571, SpellsTypes.Curse );
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
Loots = new BaseTreasure[]{ new BaseTreasure( DoomguardFamilyDrops.DemonSpirit, 100f ) };


}
}
}
namespace Server.Creatures
{
public class DemonOfTheOrb : BaseCreature 
 { 
public  DemonOfTheOrb() : base() 
 { 
Model = 5048;
AttackSpeed= 1554;
BoundingRadius = 1.00f ;
Name = "Demon of the Orb" ;
Flags1 = 0x06 ;
Id = 6549 ; 
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = 40 ;
Elite = 2;
NpcType = (int)NpcTypes.Demon;
BaseMana = Level*70;
BaseHitPoints = MobArmorHP.GetMobHP ( Level)*3;
Armor = MobArmorHP.GetMobArmor ( Level);
NpcFlags = 0 ;
CombatReach = 2.5f ;
SetDamage ((1.5f*AttackSpeed/1000f)*Level, (3f*AttackSpeed/1000f)*Level );
LearnSpell( 15571, SpellsTypes.Curse );
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );

}
}
}
namespace Server.Creatures
{
public class HederineSlayer : BaseCreature 
 { 
public  HederineSlayer() : base() 
 { 
Model = 9018;
AttackSpeed= 2000;
BoundingRadius = 1.5f ;
Name = "Hederine Slayer" ;
Flags1 = 0x00000000 ;
Id = 7463 ; 
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 54, 60 );
Elite = 2;
NpcType = (int)NpcTypes.Demon;
BaseMana = Level*70;
BaseHitPoints = MobArmorHP.GetMobHP ( Level)*3;
Armor = MobArmorHP.GetMobArmor ( Level);
NpcFlags = 0 ;
CombatReach = 2.5f ;
SetDamage ((1.5f*AttackSpeed/1000f)*Level, (3f*AttackSpeed/1000f)*Level );
LearnSpell( 15571, SpellsTypes.Curse );
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
Loots = new BaseTreasure[]{ new BaseTreasure( DoomguardFamilyDrops.HederineSlayer, 100f ) };


}
}
}
namespace Server.Creatures
{
public class JaedenarLegionnaire : BaseCreature 
 { 
public  JaedenarLegionnaire() : base() 
 { 
Model = 9129;
AttackSpeed= 2000;
BoundingRadius = 1.5f ;
Name = "Jaedenar Legionnaire" ;
Flags1 = 0x00000000 ;
Id = 9862 ; 
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 50, 55 );
NpcType = (int)NpcTypes.Demon;
BaseMana = Level*70;
BaseHitPoints = MobArmorHP.GetMobHP ( Level);
Armor = MobArmorHP.GetMobArmor ( Level);
NpcFlags = 0 ;
CombatReach = 2.5f ;
SetDamage ((1.5f*AttackSpeed/1000f)*Level, (3f*AttackSpeed/1000f)*Level );
LearnSpell( 15571, SpellsTypes.Curse );
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
Loots = new BaseTreasure[]{ new BaseTreasure( DoomguardFamilyDrops.JaedenarLegionnaire, 100f ) };


}
}
}
namespace Server.Creatures
{
public class Rathorian : BaseCreature 
 { 
public  Rathorian() : base() 
 { 
Model = 5047;
AttackSpeed= 2000;
BoundingRadius = 1f ;
Name = "Rathorian" ;
Flags1 = 0x00000000 ;
Id = 3470 ; 
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level =  15 ;
Elite = 4;
NpcType = (int)NpcTypes.Demon;
BaseMana = Level*70;
BaseHitPoints = MobArmorHP.GetMobHP ( Level);
Armor = MobArmorHP.GetMobArmor ( Level);
NpcFlags = 0 ;
CombatReach = 2.5f ;
SetDamage ((1.5f*AttackSpeed/1000f)*Level, (3f*AttackSpeed/1000f)*Level );
LearnSpell( 15571, SpellsTypes.Curse );
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
Loots = new BaseTreasure[]{ new BaseTreasure( DoomguardFamilyDrops.Rathorian, 100f ) };

}
}
}






