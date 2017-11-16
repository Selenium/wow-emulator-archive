//originally Scripted By DiScS Converter
//Edited by *place name here*
using System;
using Server.Items;

////////////////////
namespace Server.Creatures
{
public class Montarr : BaseCreature 
 { 
public  Montarr() : base() 
 { 
Model = 4308;
AttackSpeed= 2000;
BoundingRadius = 0.974700f ;
Name = "Montarr" ;
Flags1 = 08400046 ;
Id = 4878 ; 
Guild = "Lorekeeper";
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
Level = RandomLevel( 36 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1464 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 4.05f ;
SetDamage ( 39, 50 );
NpcText00 = "Greetings $N, I am Montarr." ;
BaseMana = 0 ;
Sells = new Item[] { new ScrollOfProtectionII()
                           , new DemonicFigurine()
                           , new ArcaneDust()
                           , new ArcanePowder()
                           , new WildBerries()
                           , new WildRoot()
                           , new WildThornroot()
                           , new ScentedCandle()
                           , new HolyCandle()
                           , new SacredCandle()
                           , new Ankh()
                           , new RuneOfTeleportation()
                           , new RuneOfPortals()
                           , new SymbolOfDivinity()
                           , new MapleSeed()
                           , new StranglethornSeed()
                           , new AshwoodSeed()
                           , new HornbeamSeed()
                           , new IronwoodSeed()
                           , new ScrollOfStaminaII()
                           , new ScrollOfSpiritII()
                           , new ScrollOfIntellectII()
                           , new Earthroot()
                           , new Bruiseweed()
                           , new ScrollOfAgility()
                           , new WildSteelbloom()
                           , new Kingsblood()
                           , new Liferoot()
                           , new InfernalStone()
                           , new RecipeShadowOil()
                           , new Mageroyal()
                           , new HealingPotion()
                           , new ScrollOfStrength()
  } ;
Faction = Factions.ThunderBluff;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 21376, InventoryTypes.TwoHanded , 10, 2, 17, 2, 0, 0, 0 ));
}
}
public class SalazarBloch : BaseCreature 
 { 
public  SalazarBloch() : base() 
 { 
Model = 2648;
AttackSpeed= 2000;
BoundingRadius = 0.383000f ;
Name = "Salazar Bloch" ;
Flags1 = 018480046 ;
Id = 4581 ; 
Guild = "Book Dealer";
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
NpcText00 = "Greetings $N, I am Salazar Bloch." ;
BaseMana = 0 ;
Sells = new Item[] { new EngineersInk()
                           , new BlankParchment()
                           , new ScrollOfStamina()
                           , new ScrollOfSpirit()
                           , new ScrollOfProtectionII()
                           , new ScrollOfStaminaII()
                           , new ScrollOfSpiritII()
                           , new ScrollOfIntellectII()
                           , new ScrollOfAgility()
                           , new ScrollOfProtection()
                           , new ScrollOfStrength()
                           , new ScrollOfIntellect()
  } ;
Faction = Factions.Undercity;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 23324, InventoryTypes.OneHand, 14, 1, 13, 0, 0, 0, 0 ));
}
}
public class QuartermasterMirandaBreechlock : BaseCreature 
 { 
public  QuartermasterMirandaBreechlock() : base() 
 { 
Model = 11352;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Quartermaster Miranda Breechlock" ;
Flags1 = 080006 ;
Id = 11536 ; 
Guild = "The Argent Dawn";
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
Level = RandomLevel( 58 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 2346 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.500000f ;
SetDamage ( 63, 82 );
NpcText00 = "Greetings $N, I am Quartermaster Miranda Breechlock." ;
BaseMana = 0 ;
Sells = new Item[] { new MajorManaPotion()
                           , new MajorHealingPotion()
                           , new RecipeTransmuteAirToFire()
                           , new EnrichedMannaBiscuit()
                           , new BlessedSunfruit()
                           , new BlessedSunfruitJuice()
                           , new FlameMantleOfTheDawn()
                           , new FrostMantleOfTheDawn()
                           , new ArcaneMantleOfTheDawn()
                           , new NatureMantleOfTheDawn()
                           , new ShadowMantleOfTheDawn()
                           , new ChromaticMantleOfTheDawn()
  } ;
Faction = Factions.ArgentDawn;
AIEngine = new DefensiveAnimalAI( this );  
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 7438, InventoryTypes.OneHand , 4, 2, 13, 3, 0, 0, 0 ));
}
}
public class ApothecaryDithers : BaseCreature 
 { 
public  ApothecaryDithers() : base() 
 { 
Model = 10552;
AttackSpeed= 2000;
BoundingRadius = 0.383000f ;
Name = "Apothecary Dithers" ;
Flags1 = 0400006 ;
Id = 11057 ; 
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
Level = RandomLevel( 58 );
NpcType = (int)NpcTypes.Undead;
BaseHitPoints = 2226 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 60, 77 );
NpcText00 = "Greetings $N, I am Apothecary Dithers." ;
BaseMana = 5461 ;
Sells = new Item[] { new ArcaneQuickener()
  } ;
Faction = Factions.Undercity;
AIEngine = new DefensiveAnimalAI( this ); 
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 7465, InventoryTypes.OneHand , 14, 1, 13, 0, 0, 0, 0 ), new Item( 23323, InventoryTypes.HeldInHand , 0, 1, 23, 0, 0, 0, 0 ));
}
}
public class AlchemistArbington : BaseCreature 
 { 
public  AlchemistArbington() : base() 
 { 
Model = 10551;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Alchemist Arbington" ;
Flags1 = 0480006 ;
Id = 11056 ; 
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
Level = RandomLevel( 58 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 2346 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 63, 82 );
NpcText00 = "Greetings $N, I am Alchemist Arbington." ;
BaseMana = 5461 ;
Sells = new Item[] { new ArcaneQuickener()
  } ;
Faction = Factions.Stormwind;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};

}
}
public class ArgentQuartermasterLightspark : BaseCreature 
 { 
public  ArgentQuartermasterLightspark() : base() 
 { 
Model = 10213;
AttackSpeed= 2000;
BoundingRadius = 0.351900f ;
Name = "Argent Quartermaster Lightspark" ;
Flags1 = 080006 ;
Id = 10857 ; 
Guild = "The Argent Dawn";
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
Level = RandomLevel( 58 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 2346 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.725f ;
SetDamage ( 63, 82 );
NpcText00 = "Greetings $N, I am Argent Quartermaster Lightspark." ;
BaseMana = 0 ;
Sells = new Item[] { new MajorManaPotion()
                           , new MajorHealingPotion()
                           , new RecipeTransmuteAirToFire()
                           , new EnrichedMannaBiscuit()
                           , new BlessedSunfruit()
                           , new BlessedSunfruitJuice()
                           , new FlameMantleOfTheDawn()
                           , new FrostMantleOfTheDawn()
                           , new ArcaneMantleOfTheDawn()
                           , new NatureMantleOfTheDawn()
                           , new ShadowMantleOfTheDawn()
                           , new ChromaticMantleOfTheDawn()
  } ;
Faction = Factions.ArgentDawn;
AIEngine = new DefensiveAnimalAI( this );  
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 19555, InventoryTypes.OneHand , 15, 1, 13, 3, 0, 0, 0 ), new Item( 23568, InventoryTypes.Shield, 6, 1, 14, 4, 0, 0, 0 ));
}
}
public class ArgentQuartermasterHasana : BaseCreature 
 { 
public  ArgentQuartermasterHasana() : base() 
 { 
Model = 10212;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Argent Quartermaster Hasana" ;
Flags1 = 080006 ;
Id = 10856 ; 
Guild = "The Argent Dawn";
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
Level = RandomLevel( 58 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 2226 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.500000f ;
SetDamage ( 60, 77 );
NpcText00 = "Greetings $N, I am Argent Quartermaster Hasana." ;
BaseMana = 0 ;
Sells = new Item[] { new MajorManaPotion()
                           , new MajorHealingPotion()
                           , new RecipeTransmuteAirToFire()
                           , new EnrichedMannaBiscuit()
                           , new BlessedSunfruit()
                           , new BlessedSunfruitJuice()
                           , new FlameMantleOfTheDawn()
                           , new FrostMantleOfTheDawn()
                           , new ArcaneMantleOfTheDawn()
                           , new NatureMantleOfTheDawn()
                           , new ShadowMantleOfTheDawn()
                           , new ChromaticMantleOfTheDawn()
  } ;
Faction = Factions.ArgentDawn;
AIEngine = new DefensiveAnimalAI( this );  
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 3385, InventoryTypes.TwoHanded, 1, 1, 17, 1, 0, 0, 0 ));
}
}
public class SkeletalServant : BaseCreature 
 { 
public  SkeletalServant() : base() 
 { 
Model = 7846;
AttackSpeed= 2000;
BoundingRadius = 0.850000f ;
Name = "Skeletal Servant" ;
Flags1 = 06 ;
Id = 8477 ; 
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
Level = RandomLevel( 51 );
NpcType = (int)NpcTypes.Undead;
BaseHitPoints = 1825 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.275f ;
SetDamage ( 49, 63 );
NpcText00 = "Greetings $N, I am Skeletal Servant." ;
BaseMana = 0 ;
Sells = new Item[] { new ScrollOfStaminaIV()
                           , new StratholmeHolyWater()
                           , new SpikedDagger()
                           , new SuperiorHealingPotion()
                           , new GreaterManaPotion()
                           , new MorningGloryDew()
                           , new AlteracSwiss()
  } ;
Faction = Factions.Monster;
AIEngine = new DefensiveAnimalAI( this );  
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
}
}
public class Jeeda : BaseCreature 
 { 
public  Jeeda() : base() 
 { 
Model = 3892;
AttackSpeed= 2000;
BoundingRadius = 0.236000f ;
Name = "Jeeda" ;
Flags1 = 08480046 ;
Id = 4083 ; 
Guild = "Apprentice Witch Doctor";
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
Level = RandomLevel( 24 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 864 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 22, 29 );
NpcText00 = "Greetings $N, I am Jeeda." ;
BaseMana = 0 ;
Sells = new Item[] { new DemonicFigurine()
                           , new ArcaneDust()
                           , new ArcanePowder()
                           , new WildBerries()
                           , new WildRoot()
                           , new WildThornroot()
                           , new ScentedCandle()
                           , new HolyCandle()
                           , new SacredCandle()
                           , new Ankh()
                           , new RuneOfTeleportation()
                           , new RuneOfPortals()
                           , new SymbolOfDivinity()
                           , new MapleSeed()
                           , new StranglethornSeed()
                           , new AshwoodSeed()
                           , new HornbeamSeed()
                           , new IronwoodSeed()
                           , new Earthroot()
                           , new Bruiseweed()
                           , new WildSteelbloom()
                           , new Kingsblood()
                           , new Liferoot()
                           , new LesserManaPotion()
                           , new InfernalStone()
                           , new RecipeFireProtectionPotion()
                           , new Mageroyal()
                           , new HealingPotion()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new DefensiveAnimalAI( this ); 
 AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 7469, InventoryTypes.OneHand, 4, 2, 13, 7, 0, 0, 0 ));
}
}
public class DenebWalker : BaseCreature 
 { 
public  DenebWalker() : base() 
 { 
Model = 1506;
AttackSpeed= 1500;
BoundingRadius = 0.306000f ;
Name = "Deneb Walker" ;
Flags1 = 080046 ;
Id = 2805 ; 
Guild = "Scrolls & Potions";
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
NpcText00 = "Greetings $N, I am Deneb Walker." ;
BaseMana = 0 ;
Sells = new Item[] { new ScrollOfProtectionII()
                           , new ExpertFirstAidUnderWraps()
                           , new ManualHeavySilkBandage()
                           , new ManualMageweaveBandage()
                           , new DemonicFigurine()
                           , new ArcaneDust()
                           , new ArcanePowder()
                           , new WildBerries()
                           , new WildRoot()
                           , new WildThornroot()
                           , new ScentedCandle()
                           , new HolyCandle()
                           , new SacredCandle()
                           , new Ankh()
                           , new RuneOfTeleportation()
                           , new RuneOfPortals()
                           , new SymbolOfDivinity()
                           , new MapleSeed()
                           , new StranglethornSeed()
                           , new AshwoodSeed()
                           , new HornbeamSeed()
                           , new IronwoodSeed()
                           , new ScrollOfStaminaII()
                           , new ScrollOfSpiritII()
                           , new ScrollOfIntellectII()
                           , new ScrollOfAgility()
                           , new LesserManaPotion()
                           , new InfernalStone()
                           , new HealingPotion()
                           , new ScrollOfStrength()
  } ;
Faction = Factions.Stormwind;
AIEngine = new DefensiveAnimalAI( this );  
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 2466, InventoryTypes.TwoHanded, 5, 2, 17, 1, 0, 0, 0 ), new Item( 6593, InventoryTypes.RangeRight, 3, 1, 26, 0, 0, 0, 0 ));
}
}
public class CharysYserian : BaseCreature 
 { 
public  CharysYserian() : base() 
 { 
Model = 1480;
AttackSpeed= 2000;
BoundingRadius = 0.208000f ;
Name = "Charys Yserian" ;
Flags1 = 08480046 ;
Id = 1307 ; 
Guild = "Arcane Trinkets Vendor";
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
NpcText00 = "Greetings $N, I am Charys Yserian." ;
BaseMana = 0 ;
Sells = new Item[] { new DemonicFigurine()
                           , new ArcaneDust()
                           , new ArcanePowder()
                           , new WildBerries()
                           , new WildRoot()
                           , new WildThornroot()
                           , new ScentedCandle()
                           , new HolyCandle()
                           , new SacredCandle()
                           , new Ankh()
                           , new RuneOfTeleportation()
                           , new RuneOfPortals()
                           , new SymbolOfDivinity()
                           , new MapleSeed()
                           , new StranglethornSeed()
                           , new AshwoodSeed()
                           , new HornbeamSeed()
                           , new IronwoodSeed()
                           , new LesserManaPotion()
                           , new BlurredAxe()
                           , new CallousAxe()
                           , new MarauderAxe()
                           , new WizardsBelt()
                           , new NightwindBelt()
                           , new DreamersBelt()
                           , new InfernalStone()
                           , new HealingPotion()
  } ;
Faction = Factions.Stormwind;
AIEngine = new DefensiveAnimalAI( this );  
  AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
}
}
public class KeldricBoucher : BaseCreature 
 { 
public  KeldricBoucher() : base() 
 { 
Model = 1431;
AttackSpeed= 1500;
BoundingRadius = 0.306000f ;
Name = "Keldric Boucher" ;
Flags1 = 08480046 ;
Id = 1257 ; 
Guild = "Arcane Goods Vendor";
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
NpcText00 = "Greetings $N, I am Keldric Boucher." ;
BaseMana = 0 ;
Sells = new Item[] { new DemonicFigurine()
                           , new ArcaneDust()
                           , new ArcanePowder()
                           , new WildBerries()
                           , new WildRoot()
                           , new WildThornroot()
                           , new ScentedCandle()
                           , new HolyCandle()
                           , new SacredCandle()
                           , new Ankh()
                           , new RuneOfTeleportation()
                           , new RuneOfPortals()
                           , new SymbolOfDivinity()
                           , new MapleSeed()
                           , new StranglethornSeed()
                           , new AshwoodSeed()
                           , new HornbeamSeed()
                           , new IronwoodSeed()
                           , new ImbuedVial()
                           , new EmptyVial()
                           , new LeadedVial()
                           , new CrownOfThePenitent()
                           , new FireTar()
                           , new ExplosiveShell()
                           , new TinyBronzeKey()
                           , new TinyIronKey()
                           , new InfernalStone()
                           , new SoulShard()
                           , new LesserHealingPotion()
                           , new CrystalVial()
  } ;
Faction = Factions.Stormwind;
AIEngine = new DefensiveAnimalAI( this );  
  AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 7467, InventoryTypes.OneHand, 14, 2, 13, 0, 0, 0, 0 ));

}
}
public class Thultazor : BaseCreature 
 { 
public  Thultazor() : base() 
 { 
Model = 4564;
AttackSpeed= 2000;
BoundingRadius = 0.372000f ;
Name = "Thultazor" ;
Flags1 = 08400046 ;
Id = 983 ; 
Guild = "Arcane Goods Vendor";
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
BaseHitPoints = 1424 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 38, 49 );
NpcText00 = "Greetings $N, I am Thultazor." ;
BaseMana = 0 ;
Sells = new Item[] { new DemonicFigurine()
                           , new ArcaneDust()
                           , new ArcanePowder()
                           , new WildBerries()
                           , new WildRoot()
                           , new WildThornroot()
                           , new ScentedCandle()
                           , new HolyCandle()
                           , new SacredCandle()
                           , new Ankh()
                           , new RuneOfTeleportation()
                           , new RuneOfPortals()
                           , new SymbolOfDivinity()
                           , new MapleSeed()
                           , new StranglethornSeed()
                           , new AshwoodSeed()
                           , new HornbeamSeed()
                           , new IronwoodSeed()
                           , new ImbuedVial()
                           , new EmptyVial()
                           , new LeadedVial()
                           , new SuperiorHealingPotion()
                           , new InfernalStone()
                           , new GreaterManaPotion()
                           , new SoulShard()
                           , new CrystalVial()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new DefensiveAnimalAI( this );  
  AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 7467, InventoryTypes.OneHand, 14, 2, 13, 0, 0, 0, 0 ));
}
}
public class DawnBrightstar : BaseCreature 
 { 
public  DawnBrightstar() : base() 
 { 
Model = 3347;
AttackSpeed= 1500;
BoundingRadius = 0.208000f ;
Name = "Dawn Brightstar" ;
Flags1 = 08480046 ;
Id = 958 ; 
Guild = "Arcane Goods";
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
BaseHitPoints = 500 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 24, 31 );
NpcText00 = "Greetings $N, I am Dawn Brightstar." ;
BaseMana = 0 ;
Sells = new Item[] { new ScrollOfStamina()
                           , new ScrollOfSpirit()
                           , new DemonicFigurine()
                           , new ArcaneDust()
                           , new ArcanePowder()
                           , new WildBerries()
                           , new WildRoot()
                           , new WildThornroot()
                           , new ScentedCandle()
                           , new HolyCandle()
                           , new SacredCandle()
                           , new Ankh()
                           , new RuneOfTeleportation()
                           , new RuneOfPortals()
                           , new SymbolOfDivinity()
                           , new MapleSeed()
                           , new StranglethornSeed()
                           , new AshwoodSeed()
                           , new HornbeamSeed()
                           , new IronwoodSeed()
                           , new ImbuedVial()
                           , new MinorManaPotion()
                           , new ScrollOfAgility()
                           , new ScrollOfProtection()
                           , new EmptyVial()
                           , new LeadedVial()
                           , new InfernalStone()
                           , new LesserHealingPotion()
                           , new CrystalVial()
                           , new ScrollOfStrength()
                           , new ScrollOfIntellect()
  } ;
Faction = Factions.Stormwind;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 1927, InventoryTypes.TwoHanded, 10, 2, 17, 2, 0, 0, 0 ));
}
}
}