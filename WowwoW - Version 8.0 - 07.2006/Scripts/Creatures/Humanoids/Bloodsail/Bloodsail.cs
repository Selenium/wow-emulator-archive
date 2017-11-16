using System;
using Server.Items;

////////////////////
namespace Server.Creatures
{
public class BloodsailRaider : BaseCreature 
 { 
public  BloodsailRaider() : base() 
 { 
Model = 793;
AttackSpeed= 2000;
BoundingRadius = 0.561f ;
Name = "Bloodsail Raider" ;
Flags1 = 0x010080000 ;
Id = 1561 ; 
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 5f ;
ResistArcane = 0;
ResistFire = 0;
Armor = 2500 ;
ResistHoly = 50;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 41 );
NpcType = (int)NpcTypes.Humanoid ;
BCAddon.Hp( this, 1585, 41 );
NpcFlags = 0 ;
CombatReach = 1.5f ;
SetDamage ( 80, 100 );

// BaseMana = 0 ;
Equip( new Longsword());
Faction = Factions.BloodsailBuccaneers;
AIEngine = new DefensiveAnimalAI( this );
Loots = new BaseTreasure[]{ new BaseTreasure( BloodsailDrops.Bloodsail, 100f ) };


}
}
public class BloodsailDeckhand : BaseCreature 
 { 
public  BloodsailDeckhand() : base() 
 { 
Model = 2557;
AttackSpeed= 1539;
BoundingRadius = 0.561f ;
Name = "Bloodsail Deckhand" ;
Flags1 = 0x010080000 ;
Id = 4505 ; 
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 5f ;
ResistArcane = 0;
ResistFire = 0;
Armor = 2500 ;
ResistHoly = 50;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 40, 44 );
NpcType = (int)NpcTypes.Humanoid ;
BCAddon.Hp( this, 15665, 40 );
NpcFlags = 0 ;
CombatReach = 0.8f ;
SetDamage ( 80, 100 );

// BaseMana = 2054 ;
Equip( new BronzeShortsword());
Faction = Factions.BloodsailBuccaneers;
AIEngine = new DefensiveAnimalAI( this );
Loots = new BaseTreasure[]{ new BaseTreasure( BloodsailDrops.Bloodsail, 100f ) };


}
}
public class BloodsailSwabby : BaseCreature 
 { 
public  BloodsailSwabby() : base() 
 { 
Model = 1902;
AttackSpeed= 1539;
BoundingRadius = 0.561f ;
Name = "Bloodsail Swabby" ;
Flags1 = 0x010080000 ;
Id = 4506 ; 
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 5f ;
ResistArcane = 0;
ResistFire = 0;
Armor = 2500 ;
ResistHoly = 50;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 41, 44 );
NpcType = (int)NpcTypes.Humanoid ;
BCAddon.Hp( this, 1665, 41 );
NpcFlags = 0 ;
CombatReach = 0.8f ;
SetDamage ( 80, 100 );

// BaseMana = 2054 ;
Equip( new GlintingSteelDagger());
Faction = Factions.BloodsailBuccaneers;
AIEngine = new DefensiveAnimalAI( this );
Loots = new BaseTreasure[]{ new BaseTreasure( BloodsailDrops.Bloodsail, 100f ) };


}
}
public class BloodsailElderMagus : BaseCreature 
 { 
public  BloodsailElderMagus() : base() 
 { 
Model = 2563;
AttackSpeed= 2000;
BoundingRadius = 0.306f ;
Name = "Bloodsail Elder Magus" ;
Flags1 = 0x010080000 ;
Id = 1653 ; 
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 5f ;
ResistArcane = 0;
ResistFire = 0;
Armor = 2500 ;
ResistHoly = 50;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 44 );
NpcType = (int)NpcTypes.Humanoid ;
BCAddon.Hp( this, 2100, 44 );
NpcFlags = 0 ;
CombatReach = 1.5f ;
SetDamage ( 80, 100 );
BaseMana = 3680 ;
LearnSpell( 11310, SpellsTypes.Offensive );
LearnSpell( 8402, SpellsTypes.Offensive );
LearnSpell( 8423, SpellsTypes.Offensive );
Faction = Factions.BloodsailBuccaneers;
Equip( new GnarledAshStaff());
AIEngine = new DefensiveAnimalAI( this );
Loots = new BaseTreasure[]{ new BaseTreasure( BloodsailDrops.Bloodsail, 100f ) };


}
}
public class BloodsailMage : BaseCreature 
 { 
public  BloodsailMage() : base() 
 { 
Model = 2562;
AttackSpeed= 2000;
BoundingRadius = 0.208f ;
Name = "Bloodsail Mage" ;
Flags1 = 0x010080000 ;
Id = 1562 ; 
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 5f ;
ResistArcane = 0;
ResistFire = 0;
Armor = 2500 ;
ResistHoly = 50;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 40 );
NpcType = (int)NpcTypes.Humanoid ;
BCAddon.Hp( this, 1545, 40 );
NpcFlags = 0 ;
CombatReach = 1.5f ;
SetDamage ( 70, 93 );
BaseMana = 3191 ;
LearnSpell( 8402, SpellsTypes.Offensive );
Equip( new BattleStaff());
Faction = Factions.BloodsailBuccaneers;
AIEngine = new DefensiveAnimalAI( this );
Loots = new BaseTreasure[]{ new BaseTreasure( BloodsailDrops.Bloodsail, 100f ) };


}
}
public class BloodsailSwashbuckler : BaseCreature 
 { 
public  BloodsailSwashbuckler() : base() 
 { 
Model = 794;
AttackSpeed= 2000;
BoundingRadius = 0.561f ;
Name = "Bloodsail Swashbuckler" ;
Flags1 = 0x010080000 ;
Id = 1563 ; 
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 5f ;
ResistArcane = 0;
ResistFire = 0;
Armor = 2500 ;
ResistHoly = 50;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 42 );
NpcType = (int)NpcTypes.Humanoid ;
BCAddon.Hp( this, 1625, 42 );
NpcFlags = 0 ;
CombatReach = 1.5f ;
SetDamage ( 70, 93 );
ManaType = 2 ;
BaseMana = 100 ;
LearnSpell( 1768, SpellsTypes.Offensive );
LearnSpell( 13534, SpellsTypes.Offensive );
Equip( new DragonmawShortsword());
Faction = Factions.BloodsailBuccaneers;
AIEngine = new DefensiveAnimalAI( this );
Loots = new BaseTreasure[]{ new BaseTreasure( BloodsailDrops.Bloodsail, 100f ) };


}
}
public class BloodsailWarlock : BaseCreature 
 { 
public  BloodsailWarlock() : base() 
 { 
Model = 4462;
AttackSpeed= 2000;
BoundingRadius = 0.306f ;
Name = "Bloodsail Warlock" ;
Flags1 = 0x010080000 ;
Id = 1564 ; 
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 5f ;
ResistArcane = 0;
ResistFire = 0;
Armor = 2500 ;
ResistHoly = 50;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 42 );
NpcType = (int)NpcTypes.Humanoid ;
BCAddon.Hp( this, 1625, 42 );
NpcFlags = 0 ;
CombatReach = 1.5f ;
SetDamage ( 70, 93 );
BaseMana = 3471 ;
LearnSpell( 7641, SpellsTypes.Offensive );
LearnSpell( 11707, SpellsTypes.Offensive );
LearnSpell( 11939, SpellsTypes.Offensive );
LearnSpell( 12746, SpellsTypes.Offensive );
Equip( new OakenWarStaff());
Faction = Factions.BloodsailBuccaneers;
AIEngine = new DefensiveAnimalAI( this );
Loots = new BaseTreasure[]{ new BaseTreasure( BloodsailDrops.Bloodsail, 100f ) };


}
}
public class BloodsailSeaDog : BaseCreature 
 { 
public  BloodsailSeaDog() : base() 
 { 
Model = 796;
AttackSpeed= 2000;
BoundingRadius = 0.561f ;
Name = "Bloodsail Sea Dog" ;
Flags1 = 0x010080000 ;
Id = 1565 ; 
Size = 1f;
Speed = 3f ;
WalkSpeed = 3f ;
RunSpeed = 5f ;
ResistArcane = 0;
ResistFire = 0;
Armor = 2500 ;
ResistHoly = 50;
ResistNature = 0;
ResistShadow = 0;
Level = RandomLevel( 45 );
NpcType = (int)NpcTypes.Humanoid ;
BCAddon.Hp( this, 1705, 45 );
NpcFlags = 0 ;
CombatReach = 1.5f ;
SetDamage ( 70, 93 );
BaseMana = 100 ;
ManaType = 2;
LearnSpell( 16401, SpellsTypes.Offensive );
LearnSpell( 8629, SpellsTypes.Offensive );
LearnSpell( 11279, SpellsTypes.Offensive );
Equip( new CrossDagger());
Faction = Factions.BloodsailBuccaneers;
AIEngine = new DefensiveAnimalAI( this );
Loots = new BaseTreasure[]{ new BaseTreasure( BloodsailDrops.Bloodsail, 100f ) };


}
}
}