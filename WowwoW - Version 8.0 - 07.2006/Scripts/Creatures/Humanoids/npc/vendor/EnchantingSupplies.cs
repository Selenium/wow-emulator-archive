//originally Scripted By DiScS Converter
//Edited by *place name here*
using System;
using Server.Items;
using Server;

////////////////////
namespace Server.Creatures
{
	public class JessaraCordell : BaseCreature 
 { 
public  JessaraCordell() : base() 
 { 
Model = 1481;
AttackSpeed= 2000;
BoundingRadius = 0.208000f ;
Name = "Jessara Cordell" ;
Flags1 = 0x08480046 ;
Id = 1318 ; 
Guild = "Enchanting Supplies";
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
NpcText00 = "Greetings $N, I am Jessara Cordell." ;
BaseMana = 0 ;
Sells = new Item[] { new LesserMagicEssence()
                           , new StrangeDust()
                           , new StarWood()
                           , new SimpleWood()
                           , new CopperRod()
                           , new FormulaEnchantChestMinorMana()
  } ;
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}

public class NataDawnstrider : BaseCreature 
 { 
public  NataDawnstrider() : base() 
 { 
Model = 2118;
AttackSpeed= 2000;
BoundingRadius = 0.872500f ;
Name = "Nata Dawnstrider" ;
Flags1 = 0x08480046 ;
Id = 3012 ; 
Guild = "Enchanting Supplies";
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
CombatReach = 3.75f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Nata Dawnstrider." ;
BaseMana = 0 ;
Sells = new Item[] { new LesserMagicEssence()
                           , new StrangeDust()
                           , new StarWood()
                           , new SimpleWood()
                           , new CopperRod()
                           , new FormulaEnchantChestMinorMana()
                           , new FormulaEnchant2HWeaponLesserIntellect()
                           , new FormulaEnchantBootsMinorAgility()
  } ;
Faction = Factions.ThunderBluff;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 12236, InventoryTypes.OneHand, 4, 2, 13, 7, 0, 0, 0 ));
}
}

public class Kithas : BaseCreature 
 { 
public  Kithas() : base() 
 { 
Model = 1367;
AttackSpeed= 1739;
BoundingRadius = 0.236000f ;
Name = "Kithas" ;
Flags1 = 0x08480046 ;
Id = 3346 ; 
Guild = "Enchanting Supplies";
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
BaseHitPoints = 1024 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 27, 35 );
NpcText00 = "Greetings $N, I am Kithas." ;
BaseMana = 0 ;
Sells = new Item[] { new LesserMagicEssence()
                           , new StrangeDust()
                           , new StarWood()
                           , new SimpleWood()
                           , new CopperRod()
                           , new FormulaEnchantChestMinorMana()
                           , new FormulaEnchantChestLesserMana()
                           , new FormulaEnchant2HWeaponLesserIntellect()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}

public class Vaean : BaseCreature 
 { 
public  Vaean() : base() 
 { 
Model = 2274;
AttackSpeed= 2000;
BoundingRadius = 0.389000f ;
Name = "Vaean" ;
Flags1 = 0x08480046 ;
Id = 4228 ; 
Guild = "Enchanting Supplies";
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
NpcText00 = "Greetings $N, I am Vaean." ;
BaseMana = 0 ;
Sells = new Item[] { new LesserMagicEssence()
                           , new StrangeDust()
                           , new StarWood()
                           , new SimpleWood()
                           , new CopperRod()
                           , new FormulaEnchantChestMinorMana()
  } ;
Faction = Factions.Darnasus;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 8377, InventoryTypes.OneHand, 0, 1, 13, 4, 0, 0, 0 ));
}
}

public class ThaddeusWebb : BaseCreature 
 { 
public  ThaddeusWebb() : base() 
 { 
Model = 2651;
AttackSpeed= 2000;
BoundingRadius = 0.383000f ;
Name = "Thaddeus Webb" ;
Flags1 = 0x018480046 ;
Id = 4617 ; 
Guild = "Enchanting Supplies";
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
NpcText00 = "Greetings $N, I am Thaddeus Webb." ;
BaseMana = 0 ;
Sells = new Item[] { new LesserMagicEssence()
                           , new StrangeDust()
                           , new StarWood()
                           , new SimpleWood()
                           , new CopperRod()
                           , new FormulaEnchantChestMinorMana()
  } ;
Faction = Factions.Undercity;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 23455, InventoryTypes.RangeRight, 19, 2, 26, 0, 0, 0, 0 ));
}
}

public class TilliThistlefuzz : BaseCreature 
 { 
public  TilliThistlefuzz() : base() 
 { 
Model = 3120;
AttackSpeed= 2000;
BoundingRadius = 0.351900f ;
Name = "Tilli Thistlefuzz" ;
Flags1 = 0x08480046 ;
Id = 5158 ; 
Guild = "Enchanting Supplies";
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
NpcText00 = "Greetings $N, I am Tilli Thistlefuzz." ;
BaseMana = 0 ;
Sells = new Item[] { new LesserMagicEssence()
                           , new StrangeDust()
                           , new StarWood()
                           , new SimpleWood()
                           , new CopperRod()
                           , new FormulaEnchantChestMinorMana()
                           , new FormulaEnchant2HWeaponLesserIntellect()
  } ;
Faction = Factions.GnomereganExiles;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}

public class Lilly : BaseCreature 
 { 
public  Lilly() : base() 
 { 
Model = 4177;
AttackSpeed= 2000;
BoundingRadius = 0.383000f ;
Name = "Lilly" ;
Flags1 = 0x08400046 ;
Id = 5757 ; 
Guild = "Enchanting Supplies";
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
Level = RandomLevel( 19 );
NpcType = (int)NpcTypes.Undead;
BaseHitPoints = 784 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 20, 26 );
NpcText00 = "Greetings $N, I am Lilly." ;
BaseMana = 0 ;
Sells = new Item[] { new LesserMagicEssence()
                           , new StrangeDust()
                           , new StarWood()
                           , new SimpleWood()
                           , new CopperRod()
                           , new FormulaEnchantChestMinorMana()
                           , new FormulaEnchantChestLesserMana()
  } ;
Faction = Factions.Undercity;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
}
}

public class LeoSarn : BaseCreature 
 { 
public  LeoSarn() : base() 
 { 
Model = 4178;
AttackSpeed= 1861;
BoundingRadius = 1.00f ;
Name = "Leo Sarn" ;
Flags1 = 0x08400046 ;
Id = 5758 ; 
Guild = "Enchanting Supplies";
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
NpcType = (int)NpcTypes.Undead;
BaseHitPoints = 744 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 11.00f ;
SetDamage ( 19, 25 );
NpcText00 = "Greetings $N, I am Leo Sarn." ;
BaseMana = 903 ;
Sells = new Item[] { new LesserMagicEssence()
                           , new StrangeDust()
                           , new StarWood()
                           , new CopperOre()
                           , new SimpleWood()
                           , new CopperRod()
                           , new FormulaEnchantChestMinorMana()
                           , new FormulaEnchant2HWeaponLesserIntellect()
  } ;
Faction = Factions.Friend;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}

}