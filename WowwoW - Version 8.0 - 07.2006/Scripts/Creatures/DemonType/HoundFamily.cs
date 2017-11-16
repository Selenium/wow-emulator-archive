//script created by ccsman 30/08/05
//i've used :
//size formula : Size = 0.8f + Level/100f;    0.9 for elite/rare  - hounds
//size formula : Size = 0.6f + Level/100f;    0.7 for elite/rare  - felhounds
//dmg formula : SetDamage ((1.5f*AttackSpeed/1000f)*Level, (2.5f*AttackSpeed/1000f)*Level );    to get a stable DPS   

using System;
using System.Collections;
using Server;
using Server.Items;

namespace Server.Creatures
{
public class CursedDarkhound : BaseCreature 
 { 
public  CursedDarkhound() : base() 
 { 
Model = 9020;
AttackSpeed= 2000;
BoundingRadius = 0.2754f ;
Name = "Cursed Darkhound" ;
Flags1 = 0x00000000 ;
Id = 1548 ; 
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 3f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 3, 8 );
Size = 0.8f + Level/100f;
NpcType = (int)NpcTypes.Demon; 
NpcFlags = 0 ;
CombatReach = 1.8f ;
SetDamage ((1.5f*AttackSpeed/1000f)*Level, (2.5f*AttackSpeed/1000f)*Level ); 
ManaType = 1;
BaseMana = Level*70;
BaseHitPoints = MobArmorHP.GetMobHP ( Level);
Armor = MobArmorHP.GetMobArmor ( Level);
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
LearnSpell( 15571, SpellsTypes.Curse );
SkinLoot = new Loot[] { new Loot( typeof( RuinedLeatherScraps ), 90f )
			     ,new Loot( typeof( LightLeather ), 30f )
			    };
Loots = new BaseTreasure[]{ new BaseTreasure( HoundFamilyDrops.CursedDarkhound, 100f ) };


}
}
}
namespace Server.Creatures
{
public class DecrepitDarkhound : BaseCreature 
 { 
public  DecrepitDarkhound() : base() 
 { 
Model = 9021;
AttackSpeed= 2000;
BoundingRadius = 0.2295f ;
Name = "Decrepit Darkhound" ;
Flags1 = 0x00000000 ;
Id = 1547 ; 
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 3f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 5, 6 );
Size = 0.8f + Level/100f;
NpcType = (int)NpcTypes.Demon; 
NpcFlags = 0 ;
CombatReach = 1.5f ;
SetDamage ((1.5f*AttackSpeed/1000f)*Level, (2.5f*AttackSpeed/1000f)*Level ); 
ManaType = 1;
BaseMana = Level*70;
BaseHitPoints = MobArmorHP.GetMobHP ( Level);
Armor = MobArmorHP.GetMobArmor ( Level);
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
LearnSpell( 15571, SpellsTypes.Curse );
SkinLoot = new Loot[] { new Loot( typeof( RuinedLeatherScraps ), 90f )
			     ,new Loot( typeof( LightLeather ), 30f )
			    };
Loots = new BaseTreasure[]{ new BaseTreasure( HoundFamilyDrops.DecrepitDarkhound, 100f ) };


}
}
}
namespace Server.Creatures
{
public class Bloodhound : BaseCreature 
 { 
public  Bloodhound() : base() 
 { 
Model = 8180;
AttackSpeed= 2000;
BoundingRadius = 0.306f ;
Name = "Bloodhound" ;
Flags1 = 0x00000000 ;
Id = 8921 ; 
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 3f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 44, 50 );
Size = 0.8f + Level/100f;
NpcType = (int)NpcTypes.Demon; 
NpcFlags = 0 ;
CombatReach = 2f ;
SetDamage ((1.5f*AttackSpeed/1000f)*Level, (2.5f*AttackSpeed/1000f)*Level ); 
ManaType = 1;
BaseMana = Level*70;
BaseHitPoints = MobArmorHP.GetMobHP ( Level);
Armor = MobArmorHP.GetMobArmor ( Level);
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
LearnSpell( 15571, SpellsTypes.Curse );
SkinLoot = new Loot[] { new Loot( typeof( ThickLeather ), 90f )
			     ,new Loot( typeof( ThickHide ), 30f )
			     ,new Loot( typeof( RuggedLeather ), 20f )
			    };
Loots = new BaseTreasure[]{ new BaseTreasure( HoundFamilyDrops.Bloodhound, 100f ) };


}
}
}
namespace Server.Creatures
{
public class BloodhoundMastiff : BaseCreature
{
public BloodhoundMastiff() : base() 
 { 
Model = 8181;
AttackSpeed= 2000;
BoundingRadius = 0.3519f ;
Name = "Bloodhound Mastiff" ;
Flags1 = 0x00000000 ;
Id = 8922 ; 
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 3f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 49, 55 );
Size = 0.8f + Level/100f;
NpcType = (int)NpcTypes.Demon; 
NpcFlags = 0 ;
CombatReach = 2.3f ;
SetDamage ((1.5f*AttackSpeed/1000f)*Level, (2.5f*AttackSpeed/1000f)*Level ); 
ManaType = 1;
BaseMana = Level*70;
BaseHitPoints = MobArmorHP.GetMobHP ( Level);
Armor = MobArmorHP.GetMobArmor ( Level);
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
LearnSpell( 15571, SpellsTypes.Curse );
SkinLoot = new Loot[] { new Loot( typeof( ThickLeather ), 60f )
			     ,new Loot( typeof( ThickHide ), 20f )
			     ,new Loot( typeof( RuggedLeather ), 75f )
			     ,new Loot( typeof( RuggedHide ), 25f )
			    };
Loots = new BaseTreasure[]{ new BaseTreasure( HoundFamilyDrops.BloodhoundMastiff, 100f ) };


}
}
}
namespace Server.Creatures
{
public class BurningFelhound : BaseCreature 
 { 
public  BurningFelhound() : base() 
 { 
Model = 1913;
AttackSpeed= 1357;
BoundingRadius = 1.00f ;
Name = "Burning Felhound" ;
Flags1 = 0x00000000 ;
Id = 10261 ; 
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 3f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 53, 55 );
Size = 0.6f + Level/100f;
NpcType = (int)NpcTypes.Demon; 
NpcFlags = 0 ;
CombatReach = 11.00f ;
SetDamage ((1.5f*AttackSpeed/1000f)*Level, (2.5f*AttackSpeed/1000f)*Level ); 
ManaType = 1;
BaseMana = Level*70;
BaseHitPoints = MobArmorHP.GetMobHP ( Level);
Armor = MobArmorHP.GetMobArmor ( Level);
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
LearnSpell( 15571, SpellsTypes.Curse );
SkinLoot = new Loot[] { new Loot( typeof( ThickLeather ), 60f )
			     ,new Loot( typeof( ThickHide ), 20f )
			     ,new Loot( typeof( RuggedLeather ), 75f )
			     ,new Loot( typeof( RuggedHide ), 25f )
			    };
Loots = new BaseTreasure[]{ new BaseTreasure( HoundFamilyDrops.BurningFelhound, 100f ) };


}
}
}
namespace Server.Creatures
{
public class Felhound : BaseCreature 
 { 
public  Felhound() : base() 
 { 
Model = 1913;
AttackSpeed= 2000;
BoundingRadius = 0.347f ;
Name = "Felhound" ;
Flags1 = 0x00000000 ;
Id = 6010 ; 
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 3f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 49, 55 );
Size = 0.6f + Level/100f;
NpcType = (int)NpcTypes.Demon; 
NpcFlags = 0 ;
CombatReach = 1.5f ;
SetDamage ((1.5f*AttackSpeed/1000f)*Level, (2.5f*AttackSpeed/1000f)*Level ); 
ManaType = 1;
BaseMana = Level*70;
BaseHitPoints = MobArmorHP.GetMobHP ( Level);
Armor = MobArmorHP.GetMobArmor ( Level);
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
LearnSpell( 15571, SpellsTypes.Curse );
SkinLoot = new Loot[] { new Loot( typeof( ThickLeather ), 60f )
			     ,new Loot( typeof( ThickHide ), 20f )
			     ,new Loot( typeof( RuggedLeather ), 75f )
			     ,new Loot( typeof( RuggedHide ), 25f )
			    };
Loots = new BaseTreasure[]{ new BaseTreasure( HoundFamilyDrops.Felhound, 100f ) };


}
}
}
namespace Server.Creatures
{
public class FrenziedPlaguehound : BaseCreature 
 { 
public  FrenziedPlaguehound() : base() 
 { 
Model = 9022;
AttackSpeed= 2000;
BoundingRadius = 0.3978f ;
Name = "Frenzied Plaguehound" ;
Flags1 = 0x00000000 ;
Id = 8598 ; 
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 3f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 52, 58 );
Size = 0.8f + Level/100f;
NpcType = (int)NpcTypes.Demon; 
NpcFlags = 0 ;
CombatReach = 2.6f ;
SetDamage ((1.5f*AttackSpeed/1000f)*Level, (2.5f*AttackSpeed/1000f)*Level ); 
ManaType = 1;
BaseMana = Level*70;
BaseHitPoints = MobArmorHP.GetMobHP ( Level);
Armor = MobArmorHP.GetMobArmor ( Level);
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
LearnSpell( 15571, SpellsTypes.Curse );
SkinLoot = new Loot[] { new Loot( typeof( ThickLeather ), 60f )
			     ,new Loot( typeof( ThickHide ), 20f )
			     ,new Loot( typeof( RuggedLeather ), 75f )
			     ,new Loot( typeof( RuggedHide ), 25f )
			    };
Loots = new BaseTreasure[]{ new BaseTreasure( HoundFamilyDrops.FrenziedPlaguehound, 100f ) };


}
}
}
namespace Server.Creatures
{
public class LegionHound : BaseCreature 
 { 
public  LegionHound() : base() 
 { 
Model = 7949;
AttackSpeed= 2000;
BoundingRadius = 0.29495f ;
Name = "Legion Hound" ;
Flags1 = 0x00000000 ;
Id = 6071 ; 
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 3f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 29, 30 );
Size = 0.6f + Level/100f;
NpcType = (int)NpcTypes.Demon; 
NpcFlags = 0 ;
CombatReach = 1.275f ;
SetDamage ((1.5f*AttackSpeed/1000f)*Level, (2.5f*AttackSpeed/1000f)*Level ); 
ManaType = 1;
BaseMana = Level*70;
BaseHitPoints = MobArmorHP.GetMobHP ( Level);
Armor = MobArmorHP.GetMobArmor ( Level);
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
LearnSpell( 15571, SpellsTypes.Curse );
SkinLoot = new Loot[] { new Loot( typeof( LightLeather ), 45f )
			     ,new Loot( typeof( LightHide ), 15f )
			     ,new Loot( typeof( MediumLeather ), 75f )
			     ,new Loot( typeof( MediumHide ), 25f )
			     ,new Loot( typeof( HeavyLeather), 30f )
			     ,new Loot( typeof( HeavyHide ), 10f )
			    };
Loots = new BaseTreasure[]{ new BaseTreasure( HoundFamilyDrops.LegionHound, 100f ) };


}
}
}
namespace Server.Creatures
{
public class Manahound : BaseCreature 
 { 
public  Manahound() : base() 
 { 
Model = 6173;
AttackSpeed= 2000;
BoundingRadius = 0.4511f ;
Name = "Manahound" ;
Flags1 = 0x00000000 ;
Id = 8718 ; 
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 3f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 55, 60 );
Size = 0.7f + Level/100f;
Elite = 2;
NpcType = (int)NpcTypes.Demon; 
NpcFlags = 04004 ;
CombatReach = 1.95f ;
SetDamage ((1.5f*AttackSpeed/1000f)*Level, (2.5f*AttackSpeed/1000f)*Level ); 
ManaType = 1;
BaseMana = Level*70;
BaseHitPoints = MobArmorHP.GetMobHP ( Level)*3;
Armor = MobArmorHP.GetMobArmor ( Level);
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
LearnSpell( 15571, SpellsTypes.Curse );
SkinLoot = new Loot[] { new Loot( typeof( ThickLeather ), 60f )
			     ,new Loot( typeof( ThickHide ), 20f )
			     ,new Loot( typeof( RuggedLeather ), 75f )
			     ,new Loot( typeof( RuggedHide ), 25f )
			    };
Loots = new BaseTreasure[]{ new BaseTreasure( HoundFamilyDrops.Manahound, 100f ) };


}
}
}
namespace Server.Creatures
{ 
public class PlaguehoundRunt : BaseCreature 
 { 
public  PlaguehoundRunt() : base() 
 { 
Model = 7890;
AttackSpeed= 1500;
BoundingRadius = 0.306f ;
Name = "Plaguehound Runt" ;
Flags1 = 0x00000000 ;
Id = 8596 ; 
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 3f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 48, 54 );
Size = 0.8f + Level/100f;
NpcType = (int)NpcTypes.Demon; 
NpcFlags = 0 ;
CombatReach = 2f ;
SetDamage ((1.5f*AttackSpeed/1000f)*Level, (2.5f*AttackSpeed/1000f)*Level ); 
ManaType = 1;
BaseMana = Level*70;
BaseHitPoints = MobArmorHP.GetMobHP ( Level);
Armor = MobArmorHP.GetMobArmor ( Level);
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
LearnSpell( 15571, SpellsTypes.Curse );
SkinLoot = new Loot[] { new Loot( typeof( ThickLeather ), 60f )
			     ,new Loot( typeof( ThickHide ), 20f )
			     ,new Loot( typeof( RuggedLeather ), 75f )
			     ,new Loot( typeof( RuggedHide ), 25f )
			    };
Loots = new BaseTreasure[]{ new BaseTreasure( HoundFamilyDrops.PlaguehoundRunt, 100f ) };


}
}
}
namespace Server.Creatures
{
public class Plaguehound : BaseCreature 
 { 
public  Plaguehound() : base() 
 { 
Model = 7891;
AttackSpeed= 2000;
BoundingRadius = 0.3519f ;
Name = "Plaguehound" ;
Flags1 = 0x00000000 ;
Id = 8597 ; 
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 3f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 50, 56 );
Size = 0.8f + Level/100f;
NpcType = (int)NpcTypes.Demon; 
NpcFlags = 0 ;
CombatReach = 2.3f ;
SetDamage ((1.5f*AttackSpeed/1000f)*Level, (2.5f*AttackSpeed/1000f)*Level ); 
ManaType = 1;
BaseMana = Level*70;
BaseHitPoints = MobArmorHP.GetMobHP ( Level);
Armor = MobArmorHP.GetMobArmor ( Level);
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
LearnSpell( 15571, SpellsTypes.Curse );
SkinLoot = new Loot[] { new Loot( typeof( ThickLeather ), 60f )
			     ,new Loot( typeof( ThickHide ), 20f )
			     ,new Loot( typeof( RuggedLeather ), 75f )
			     ,new Loot( typeof( RuggedHide ), 25f )
			    };
Loots = new BaseTreasure[]{ new BaseTreasure( HoundFamilyDrops.Plaguehound, 100f ) };


}
}
}
namespace Server.Creatures
{
public class RavenousDarkhound : BaseCreature 
 { 
public  RavenousDarkhound() : base() 
 { 
Model = 3916;
AttackSpeed= 2000;
BoundingRadius = 0.306f ;
Name = "Ravenous Darkhound" ;
Flags1 = 0x00000000 ;
Id = 1549 ; 
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 3f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 9, 10 );
Size = 0.8f + Level/100f;
NpcType = (int)NpcTypes.Demon; 
NpcFlags = 0 ;
CombatReach = 2f ;
SetDamage ((1.5f*AttackSpeed/1000f)*Level, (2.5f*AttackSpeed/1000f)*Level ); 
ManaType = 1;
BaseMana = Level*70;
BaseHitPoints = MobArmorHP.GetMobHP ( Level);
Armor = MobArmorHP.GetMobArmor ( Level);
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
LearnSpell( 15571, SpellsTypes.Curse );
SkinLoot = new Loot[] { new Loot( typeof( RuinedLeatherScraps ), 90f )
			     ,new Loot( typeof( LightLeather ), 30f )
			    };
Loots = new BaseTreasure[]{ new BaseTreasure( HoundFamilyDrops.RavenousDarkhound, 100f ) };


}
}
}
namespace Server.Creatures
{
public class WitherbarkFelhunter : BaseCreature 
 { 
public  WitherbarkFelhunter() : base() 
 { 
Model = 850;
AttackSpeed= 2000;
BoundingRadius = 0.2429f ;
Name = "Witherbark Felhunter" ;
Flags1 = 0x00000000 ;
Id = 7767 ; 
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 3f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 42, 46 );
Size = 0.6f + Level/100f;
NpcType = (int)NpcTypes.Demon; 
NpcFlags = 0 ;
CombatReach = 1.05f ;
SetDamage ((1.5f*AttackSpeed/1000f)*Level, (2.5f*AttackSpeed/1000f)*Level ); 
ManaType = 1;
BaseMana = Level*70;
BaseHitPoints = MobArmorHP.GetMobHP ( Level);
Armor = MobArmorHP.GetMobArmor ( Level);
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
LearnSpell( 15571, SpellsTypes.Curse );
SkinLoot = new Loot[] { new Loot( typeof( ThickLeather ), 90f )
			     ,new Loot( typeof( ThickHide ), 30f )
			     ,new Loot( typeof( RuggedLeather ), 20f )
			    };
Loots = new BaseTreasure[]{ new BaseTreasure( HoundFamilyDrops.WitherbarkFelhunter, 100f ) };


}
}
}
namespace Server.Creatures
{
public class Bayne : BaseCreature 
 { 
public  Bayne() : base() 
 { 
Model = 7892;
AttackSpeed= 2000;
BoundingRadius = 0.2754f ;
Name = "Bayne" ;
Flags1 = 0x00000000 ;
Id = 10356 ; 
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 3f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = 10;
Size = 0.9f + Level/100f;
Elite = 4;
NpcType = (int)NpcTypes.Demon; 
NpcFlags = 0 ;
CombatReach = 1.8f ;
SetDamage ((1.5f*AttackSpeed/1000f)*Level, (2.5f*AttackSpeed/1000f)*Level ); 
ManaType = 1;
BaseMana = Level*70;
BaseHitPoints = MobArmorHP.GetMobHP ( Level);
Armor = MobArmorHP.GetMobArmor ( Level);
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
LearnSpell( 15571, SpellsTypes.Curse );
SkinLoot = new Loot[] { new Loot( typeof( RuinedLeatherScraps ), 50f ) 
                       ,new Loot( typeof( LightLeather ), 75f )
			     ,new Loot( typeof( LightHide ), 25f )
			     ,new Loot( typeof( MediumLeather ), 30f )
			     ,new Loot( typeof( MediumHide ), 10f )
			    };
Loots = new BaseTreasure[]{ new BaseTreasure( HoundFamilyDrops.Bayne, 100f ) };


}
}
}
namespace Server.Creatures
{
public class Felslayer : BaseCreature 
 { 
public  Felslayer() : base() 
 { 
Model = 10950;
AttackSpeed= 2000;
BoundingRadius = 0.2429f ;
Name = "Felslayer" ;
Flags1 = 0x00000000 ;
Id = 3774 ; 
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 3f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 22, 23 );
Size = 0.6f + Level/100f;
NpcType = (int)NpcTypes.Demon; 
NpcFlags = 0 ;
CombatReach = 1.05f ;
SetDamage ((1.5f*AttackSpeed/1000f)*Level, (2.5f*AttackSpeed/1000f)*Level ); 
ManaType = 1;
BaseMana = Level*70;
BaseHitPoints = MobArmorHP.GetMobHP ( Level);
Armor = MobArmorHP.GetMobArmor ( Level);
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
LearnSpell( 15571, SpellsTypes.Curse );
SkinLoot = new Loot[] { new Loot( typeof( LightLeather ), 45f )
			     ,new Loot( typeof( LightHide ), 15f )
			     ,new Loot( typeof( MediumLeather ), 75f )
			     ,new Loot( typeof( MediumHide ), 25f )
			     ,new Loot( typeof( HeavyLeather), 30f )
			     ,new Loot( typeof( HeavyHide ), 10f )
			    };
Loots = new BaseTreasure[]{ new BaseTreasure( HoundFamilyDrops.Felslayer, 100f ) };

}
}
}
namespace Server.Creatures
{
public class Felstalker : BaseCreature 
 { 
public  Felstalker() : base() 
 { 
Model = 850;
AttackSpeed= 2000;
BoundingRadius = 0.2429f ;
Name = "Felstalker" ;
Flags1 = 0x00000000 ;
Id = 3102 ; 
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 3f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 3, 4 );
Size = 0.6f + Level/100f;
NpcType = (int)NpcTypes.Demon; 
NpcFlags = 0 ;
CombatReach = 1.05f ;
SetDamage ((1.5f*AttackSpeed/1000f)*Level, (2.5f*AttackSpeed/1000f)*Level ); 
ManaType = 1;
BaseMana = Level*70;
BaseHitPoints = MobArmorHP.GetMobHP ( Level);
Armor = MobArmorHP.GetMobArmor ( Level);
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
LearnSpell( 15571, SpellsTypes.Curse );
SkinLoot = new Loot[] { new Loot( typeof( RuinedLeatherScraps ), 90f )
			     ,new Loot( typeof( LightLeather ), 30f )
			    };
Loots = new BaseTreasure[]{ new BaseTreasure( HoundFamilyDrops.Felstalker, 100f ) };


}
}
}
namespace Server.Creatures
{
public class JaedenarHound : BaseCreature 
 { 
public  JaedenarHound() : base() 
 { 
Model = 6172;
AttackSpeed= 2000;
BoundingRadius = 0.39905f ;
Name = "Jaedenar Hound" ;
Flags1 = 0x00000000 ;
Id = 7125 ; 
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 3f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 48, 51 );
Size = 0.6f + Level/100f;
NpcType = (int)NpcTypes.Demon; 
NpcFlags = 0 ;
CombatReach = 1.725f ;
SetDamage ((1.5f*AttackSpeed/1000f)*Level, (2.5f*AttackSpeed/1000f)*Level ); 
ManaType = 1;
BaseMana = Level*70;
BaseHitPoints = MobArmorHP.GetMobHP ( Level);
Armor = MobArmorHP.GetMobArmor ( Level);
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
LearnSpell( 15571, SpellsTypes.Curse );
SkinLoot = new Loot[] { new Loot( typeof( ThickLeather ), 90f )
			     ,new Loot( typeof( ThickHide ), 30f )
			     ,new Loot( typeof( RuggedLeather ), 20f )
			    };
Loots = new BaseTreasure[]{ new BaseTreasure( HoundFamilyDrops.JaedenarHound, 100f ) };


}
}
}
namespace Server.Creatures
{ 
public class JaedenarHunter : BaseCreature 
 { 
public  JaedenarHunter() : base() 
 { 
Model = 6173;
AttackSpeed= 1386;
BoundingRadius = 1.00f ;
Name = "Jaedenar Hunter" ;
Flags1 = 0x00000000 ;
Id = 7126 ; 
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 3f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 47, 53 );
Size = 0.6f + Level/100f;
NpcType = (int)NpcTypes.Demon; 
BaseHitPoints = 0 ;
CombatReach = 11.00f ;
SetDamage ((1.5f*AttackSpeed/1000f)*Level, (2.5f*AttackSpeed/1000f)*Level ); 
ManaType = 1;
BaseMana = Level*70;
BaseHitPoints = MobArmorHP.GetMobHP ( Level);
Armor = MobArmorHP.GetMobArmor ( Level);
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
LearnSpell( 15571, SpellsTypes.Curse );
SkinLoot = new Loot[] { new Loot( typeof( ThickLeather ), 90f )
			     ,new Loot( typeof( ThickHide ), 30f )
			     ,new Loot( typeof( RuggedLeather ), 20f )
			    };
Loots = new BaseTreasure[]{ new BaseTreasure( HoundFamilyDrops.JaedenarHunter, 100f ) };


}
}
}
namespace Server.Creatures
{
public class MageHunter : BaseCreature 
 { 
public  MageHunter() : base() 
 { 
Model = 6172;
AttackSpeed= 2000;
BoundingRadius = 0.39905f ;
Name = "Mage Hunter" ;
Flags1 = 0x00000000 ;
Id = 4681 ; 
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 3f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 38, 39 );
Size = 0.6f + Level/100f;
NpcType = (int)NpcTypes.Demon; 
NpcFlags = 0 ;
CombatReach = 1.725f ;
SetDamage ((1.5f*AttackSpeed/1000f)*Level, (2.5f*AttackSpeed/1000f)*Level ); 
ManaType = 1;
BaseMana = Level*70;
BaseHitPoints = MobArmorHP.GetMobHP ( Level);
Armor = MobArmorHP.GetMobArmor ( Level);
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
LearnSpell( 15571, SpellsTypes.Curse );
SkinLoot = new Loot[] { new Loot( typeof( HeavyLeather ), 90f )
			     ,new Loot( typeof( HeavyHide ), 30f )
			    };
Loots = new BaseTreasure[]{ new BaseTreasure( HoundFamilyDrops.MageHunter, 100f ) };


}
}
}
namespace Server.Creatures
{ 
public class ManaEater : BaseCreature 
 { 
public  ManaEater() : base() 
 { 
Model = 1913;
AttackSpeed= 2000;
BoundingRadius = 0.347f ;
Name = "Mana Eater" ;
Flags1 = 0x00000000 ;
Id = 4678 ; 
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 3f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 35, 38 );
Size = 0.7f + Level/100f;
NpcType = (int)NpcTypes.Demon; 
NpcFlags = 0 ;
CombatReach = 1.5f ;
SetDamage ((1.5f*AttackSpeed/1000f)*Level, (2.5f*AttackSpeed/1000f)*Level ); 
ManaType = 1;
BaseMana = Level*70;
BaseHitPoints = MobArmorHP.GetMobHP ( Level);
Armor = MobArmorHP.GetMobArmor ( Level);
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
LearnSpell( 15571, SpellsTypes.Curse );
SkinLoot = new Loot[] { new Loot( typeof( HeavyLeather ), 90f )
			     ,new Loot( typeof( HeavyHide ), 30f )
			    };
Loots = new BaseTreasure[]{ new BaseTreasure( HoundFamilyDrops.ManaEater, 100f ) };


}
}
}
namespace Server.Creatures
{ 
public class Felbeast : BaseCreature 
 { 
public  Felbeast() : base() 
 { 
Model = 7949;
AttackSpeed= 2000;
BoundingRadius = 0.29495f ;
Name = "Felbeast" ;
Flags1 = 0x00000000 ;
Id = 8675 ; 
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 3f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 48, 51 );
Size = 0.6f + Level/100f;
NpcType = (int)NpcTypes.Demon; 
NpcFlags = 0 ;
CombatReach = 1.275f ;
SetDamage ((1.5f*AttackSpeed/1000f)*Level, (2.5f*AttackSpeed/1000f)*Level ); 
ManaType = 1;
BaseMana = Level*70;
BaseHitPoints = MobArmorHP.GetMobHP ( Level);
Armor = MobArmorHP.GetMobArmor ( Level);
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
LearnSpell( 15571, SpellsTypes.Curse );
SkinLoot = new Loot[] { new Loot( typeof( ThickLeather ), 90f )
			     ,new Loot( typeof( ThickHide ), 30f )
			     ,new Loot( typeof( RuggedLeather ), 20f )
			    };
Loots = new BaseTreasure[]{ new BaseTreasure( HoundFamilyDrops.Felbeast, 100f ) };


}
}
}
namespace Server.Creatures
{
public class KirithTheDamned : BaseCreature 
 { 
public  KirithTheDamned() : base() 
 { 
Model = 6688;
AttackSpeed= 1119;
BoundingRadius = 1.00f ;
Name = "Kirith the Damned" ;
Flags1 = 0x00000000 ;
Id = 7728 ; 
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 3f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 53, 55 );
Size = 0.7f + Level/100f;
Elite = 2;
NpcType = (int)NpcTypes.Demon; 
NpcFlags = 0 ;
CombatReach = 19.00f ;
SetDamage ((1.5f*AttackSpeed/1000f)*Level, (2.5f*AttackSpeed/1000f)*Level ); 
ManaType = 1;
BaseMana = Level*70;
BaseHitPoints = MobArmorHP.GetMobHP ( Level)*3;
Armor = MobArmorHP.GetMobArmor ( Level);
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
LearnSpell( 15571, SpellsTypes.Curse );
SkinLoot = new Loot[] { new Loot( typeof( ThickLeather ), 60f )
			     ,new Loot( typeof( ThickHide ), 20f )
			     ,new Loot( typeof( RuggedLeather ), 75f )
			     ,new Loot( typeof( RuggedHide ), 25f )
			    };
Loots = new BaseTreasure[]{ new BaseTreasure( HoundFamilyDrops.KirithTheDamned, 100f ) };


}
}
}
namespace Server.Creatures
{
public class LeyHunter : BaseCreature 
 { 
public  LeyHunter() : base() 
 { 
Model = 6173;
AttackSpeed= 2000;
BoundingRadius = 0.4511f ;
Name = "Ley Hunter" ;
Flags1 = 0x00000000 ;
Id = 4685 ; 
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 3f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 36, 40 );
Size = 0.6f + Level/100f;
NpcType = (int)NpcTypes.Demon; 
NpcFlags = 0 ;
CombatReach = 1.95f ;
SetDamage ((1.5f*AttackSpeed/1000f)*Level, (2.5f*AttackSpeed/1000f)*Level ); 
ManaType = 1;
BaseMana = Level*70;
BaseHitPoints = MobArmorHP.GetMobHP ( Level);
Armor = MobArmorHP.GetMobArmor ( Level);
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
LearnSpell( 15571, SpellsTypes.Curse );
SkinLoot = new Loot[] { new Loot( typeof( HeavyLeather ), 90f )
			     ,new Loot( typeof( HeavyHide ), 30f )
			    };
Loots = new BaseTreasure[]{ new BaseTreasure( HoundFamilyDrops.LeyHunter, 100f ) };


}
}
}
namespace Server.Creatures

{
public class ServantOfIlgalar : BaseCreature 
 { 
public  ServantOfIlgalar() : base() 
 { 
Model = 3916;
AttackSpeed= 2000;
BoundingRadius = 0.306f ;
Name = "Servant of Ilgalar" ;
Flags1 = 0x00000000 ;
Id = 819 ; 
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 3f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 23, 25 );
Size = 0.8f + Level/100f;
NpcType = (int)NpcTypes.Demon; 
NpcFlags = 0 ;
CombatReach = 2f ;
SetDamage ((1.5f*AttackSpeed/1000f)*Level, (2.5f*AttackSpeed/1000f)*Level ); 
ManaType = 1;
BaseMana = Level*70;
BaseHitPoints = MobArmorHP.GetMobHP ( Level);
Armor = MobArmorHP.GetMobArmor ( Level);
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
LearnSpell( 15571, SpellsTypes.Curse );
SkinLoot = new Loot[] { new Loot( typeof( LightLeather ), 45f )
			     ,new Loot( typeof( LightHide ), 15f )
			     ,new Loot( typeof( MediumLeather ), 75f )
			     ,new Loot( typeof( MediumHide ), 25f )
			     ,new Loot( typeof( HeavyLeather), 30f )
			     ,new Loot( typeof( HeavyHide ), 10f )
			    };
Loots = new BaseTreasure[]{ new BaseTreasure( HoundFamilyDrops.ServantOfIlgalar, 100f ) };


}
}
}
namespace Server.Creatures
{
public class Verek : BaseCreature 
 { 
public  Verek() : base() 
 { 
Model = 9019;
AttackSpeed= 2000;
BoundingRadius = 0.3978f ;
Name = "Verek" ;
Flags1 = 0x01000 ;
Id = 9042 ; 
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 3f ;
ResistArcane = 0;
ResistFire = 0;
ResistFrost = 0;
ResistHoly = 0;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 50, 55 );
Size = 0.9f + Level/100f;
Elite = 4;
NpcType = (int)NpcTypes.Demon; 
NpcFlags = 0 ;
CombatReach = 2.6f ;
SetDamage ((1.5f*AttackSpeed/1000f)*Level, (2.5f*AttackSpeed/1000f)*Level ); 
ManaType = 1;
BaseMana = Level*70;
BaseHitPoints = MobArmorHP.GetMobHP ( Level);
Armor = MobArmorHP.GetMobArmor ( Level);
Faction = Factions.Monster;
AIEngine = new AgressiveAnimalAI( this );
LearnSpell( 15571, SpellsTypes.Curse );
SkinLoot = new Loot[] { new Loot( typeof( ThickLeather ), 60f )
			     ,new Loot( typeof( ThickHide ), 20f )
			     ,new Loot( typeof( RuggedLeather ), 75f )
			     ,new Loot( typeof( RuggedHide ), 25f )
			    };
Loots = new BaseTreasure[]{ new BaseTreasure( HoundFamilyDrops.Verek, 100f ) };


}
}
}

