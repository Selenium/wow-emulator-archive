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
public class AngeredInfernal : BaseCreature 
 { 
public  AngeredInfernal() : base() 
 { 
Model = 10905;
AttackSpeed= 2000;
BoundingRadius = 1f ;
Name = "Angered Infernal" ;
Flags1 = 0x06 ;
Id = 8608 ; 
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 52, 53 );
Size = 0.8f + Level/100f;
NpcType = (int)NpcTypes.Demon;
BaseMana = Level*70;
BaseHitPoints = MobArmorHP.GetMobHP ( Level);
Armor = MobArmorHP.GetMobArmor ( Level);
NpcFlags = 0 ;
CombatReach = 2.5f ;
SetDamage ((1.5f*AttackSpeed/1000f)*Level, (2.5f*AttackSpeed/1000f)*Level );
LearnSpell( 15571, SpellsTypes.Curse );
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
Loots = new BaseTreasure[]{ new BaseTreasure( InfernalFamilyDrops.AngeredInfernal, 100f ) };

}
}
}
namespace Server.Creatures
{
public class InfernalBodyguard : BaseCreature 
 { 
public  InfernalBodyguard() : base() 
 { 
Model = 12817;
AttackSpeed= 2000;
BoundingRadius = 1.58025f ;
Name = "Infernal Bodyguard" ;
Flags1 = 0x00000000 ;
Id = 7135 ; 
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 51, 54 );
Size = 0.9f + Level/100f;
NpcType = (int)NpcTypes.Demon;
BaseMana = Level*70;
BaseHitPoints = MobArmorHP.GetMobHP ( Level) * 3;
Armor = MobArmorHP.GetMobArmor ( Level);
NpcFlags = 0 ;
CombatReach = 3.5f ;
SetDamage ((1.5f*AttackSpeed/1000f)*Level, (3f*AttackSpeed/1000f)*Level );
Elite = 2;
LearnSpell( 15571, SpellsTypes.Curse );
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
Loots = new BaseTreasure[]{ new BaseTreasure( InfernalFamilyDrops.InfernalBodyguard, 100f ) };
}
}
}
namespace Server.Creatures
{
public class InfernalSentry : BaseCreature 
 { 
public  InfernalSentry() : base() 
 { 
Model = 4200;
AttackSpeed= 2000;
BoundingRadius = 1.4448f ;
Name = "Infernal Sentry" ;
Flags1 = 0x00000000 ;
Id = 7136 ; 
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 51, 53 );
Size = 0.9f + Level/100f;
NpcType = (int)NpcTypes.Demon;
BaseMana = Level*70;
BaseHitPoints = MobArmorHP.GetMobHP ( Level) * 3;
Armor = MobArmorHP.GetMobArmor ( Level);
NpcFlags = 0 ;
CombatReach = 3.2f ;
SetDamage ((1.5f*AttackSpeed/1000f)*Level, (3f*AttackSpeed/1000f)*Level );
Elite = 2;
LearnSpell( 15571, SpellsTypes.Curse );
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
Loots = new BaseTreasure[]{ new BaseTreasure( InfernalFamilyDrops.InfernalSentry, 100f ) };
}
}
}
namespace Server.Creatures
{
public class InfernalServant : BaseCreature 
 { 
public  InfernalServant() : base() 
 { 
Model = 12817;
AttackSpeed= 1344;
BoundingRadius = 1.00f ;
Name = "Infernal Servant" ;
Flags1 = 0x06 ;
Id = 8616 ; 
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 54, 55 );
Size = 0.8f + Level/100f;
NpcType = (int)NpcTypes.Demon;
BaseMana = Level*70;
BaseHitPoints = MobArmorHP.GetMobHP ( Level);
Armor = MobArmorHP.GetMobArmor ( Level);
LearnSpell( 15571, SpellsTypes.Curse );
NpcFlags = 0 ;
CombatReach = 2.7f ;
SetDamage ((1.5f*AttackSpeed/1000f)*Level, (2.5f*AttackSpeed/1000f)*Level );
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
}
}
}
namespace Server.Creatures
{
public class LesserInfernal : BaseCreature 
 { 
public  LesserInfernal() : base() 
 { 
Model = 10906;
AttackSpeed= 2200;
BoundingRadius = 1.1739f ;
Name = "Lesser Infernal" ;
Flags1 = 0x00000000 ;
Id = 4676 ; 
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 33, 37 );
Size = 0.8f + Level/100f;
NpcType = (int)NpcTypes.Demon;
BaseMana = Level*70;
BaseHitPoints = MobArmorHP.GetMobHP ( Level);
Armor = MobArmorHP.GetMobArmor ( Level);
NpcFlags = 0 ;
LearnSpell( 15571, SpellsTypes.Curse );
CombatReach = 2.6f ;
SetDamage ((1.5f*AttackSpeed/1000f)*Level, (2.5f*AttackSpeed/1000f)*Level );
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
Loots = new BaseTreasure[]{ new BaseTreasure( InfernalFamilyDrops.LesserInfernal, 100f ) };
}
} 
}
namespace Server.Creatures
{
public class MassiveInfernal : BaseCreature // not sure if this monster exists
 { 
public  MassiveInfernal() : base() 
 { 
Model = 7950;
AttackSpeed= 840;
BoundingRadius = 1.00f ;
Name = "Massive Infernal" ;
Flags1 = 0x010000 ;
Id = 8680 ; 
Size = 3f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 496, 500 );
NpcType = (int)NpcTypes.Demon;
BaseMana = Level*70;
BaseHitPoints = 20000;
Armor = 20000;
NpcFlags = 0 ;
Elite = 4;
LearnSpell( 15571, SpellsTypes.Curse );
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
CombatReach = 4.00f ;
SetDamage ( 300, 1000 );
}
}
}
namespace Server.Creatures
{
public class SearingInfernal : BaseCreature 
 { 
public  SearingInfernal() : base() 
 { 
Model = 10905;
AttackSpeed= 2000;
BoundingRadius = 1.30935f ;
Name = "Searing Infernal" ;
Flags1 = 0x00000000 ;
Id = 6073 ; 
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
Level = RandomLevel( 28, 30 );
Size = 0.8f + Level/100f;
NpcType = (int)NpcTypes.Demon;
BaseMana = Level*70;
BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
Armor = MobArmorHP.GetMobArmor ( Level);
NpcFlags = 0 ;
LearnSpell( 15571, SpellsTypes.Curse );
CombatReach = 2f ;
SetDamage ((1.5f*AttackSpeed/1000f)*Level, (2.5f*AttackSpeed/1000f)*Level );
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
Loots = new BaseTreasure[]{ new BaseTreasure( InfernalFamilyDrops.SearingInfernal, 100f ) };
}
} 
}
namespace Server.Creatures
{
public class Immolatus : BaseCreature 
 { 
public  Immolatus() : base() 
 { 
Model = 7029;
AttackSpeed= 1649;
BoundingRadius = 1.00f ;
Name = "Immolatus" ;
Flags1 = 0x00000000 ;
Id = 7137 ; 
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 6f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = 56;
Size = 0.9f + Level/100f;
NpcType = (int)NpcTypes.Demon;
BaseMana = Level*70;
BaseHitPoints = MobArmorHP.GetMobHP ( Level) ;
Armor = MobArmorHP.GetMobArmor ( Level);
LearnSpell( 15571, SpellsTypes.Curse );
Elite = 4;
NpcFlags = 0 ;
CombatReach = 2.7f ;
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
SetDamage ((1.5f*AttackSpeed/1000f)*Level, (3f*AttackSpeed/1000f)*Level );
Loots = new BaseTreasure[]{ new BaseTreasure( InfernalFamilyDrops.Immolatus, 100f ) };
}
}
}
 
