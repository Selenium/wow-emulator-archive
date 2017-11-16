//originally Scripted By DiScS Converter
//Edited by *place name here*
using System;
using Server.Items;
using Server.Quests;

////////////////////
namespace Server.Creatures
{
public class WynneLarsone : BaseCreature 
 { 
public  WynneLarsone() : base() 
 { 
Model = 1483;
AttackSpeed= 1777;
BoundingRadius = 1.000000f ;
Name = "Wynne Larsone" ;
Flags1 = 0x08400046 ;
Id = 11111 ; 
Guild = "Robe Merchant";
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
NpcType = 10 ;
BaseHitPoints = 984 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 0f ;
SetDamage ( 26, 33 );
NpcText00 = "Greetings $N, I am Wynne Larsone." ;
BaseMana = 820 ;
Sells = new Item[] { new PlainRobe()
                           , new DoubleStitchedRobes()
                           , new RobeOfApprenticeship()
                           , new ChromaticRobe()
                           , new ShimmeringSilkRobes()
                           , new BurningRobes()
                           , new SilverDressRobes()
  } ;
Faction = Factions.Friend;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};

}
}
public class MaevaSnowbraid : BaseCreature 
 { 
public  MaevaSnowbraid() : base() 
 { 
Model = 3071;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Maeva Snowbraid" ;
Flags1 = 0x08480046 ;
Id = 5156 ; 
Guild = "Robe Merchant";
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
NpcText00 = "Greetings $N, I am Maeva Snowbraid." ;
BaseMana = 0 ;
Sells = new Item[] { new PlainRobe()
                           , new DoubleStitchedRobes()
                           , new RobeOfApprenticeship()
                           , new ChromaticRobe()
                           , new ShimmeringSilkRobes()
                           , new BurningRobes()
                           , new SilverDressRobes()
  } ;
Faction = Factions.IronForge;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
}
}
public class LucilleCastleton : BaseCreature 
 { 
public  LucilleCastleton() : base() 
 { 
Model = 2668;
AttackSpeed= 2000;
BoundingRadius = 0.383000f ;
Name = "Lucille Castleton" ;
Flags1 = 0x018480046 ;
Id = 4580 ; 
Guild = "Robe Vendor";
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
NpcText00 = "Greetings $N, I am Lucille Castleton." ;
BaseMana = 0 ;
Sells = new Item[] { new PlainRobe()
                           , new DoubleStitchedRobes()
                           , new RobeOfApprenticeship()
                           , new ChromaticRobe()
                           , new ShimmeringSilkRobes()
                           , new BurningRobes()
                           , new SilverDressRobes()
  } ;
Faction = Factions.Undercity;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 1599, InventoryTypes.TwoHanded, 10, 2, 17, 2, 0, 0, 0 ));
}
}
public class Caynrus : BaseCreature 
 { 
public  Caynrus() : base() 
 { 
Model = 2244;
AttackSpeed= 2000;
BoundingRadius = 0.389000f ;
Name = "Caynrus" ;
Flags1 = 0x08480046 ;
Id = 4240 ; 
Guild = "Shield Merchant";
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
NpcText00 = "Greetings $N, I am Caynrus." ;
BaseMana = 0 ;
Sells = new Item[] { new SmallTarge()
                           , new DullHeaterShield()
                           , new SmallShield()
                           , new SmallTarge()
                           , new RingedBuckler()
                           , new MetalBuckler()
                           , new OrnateBuckler()
                           , new ReinforcedTarge()
                           , new LargeRoundShield()
                           , new SmallShield()
                           , new RingedBuckler()
                           , new ReinforcedTarge()
                           , new MetalBuckler()
                           , new OrnateBuckler()
                           , new LargeMetalShield()
                           , new KiteShield()
                           , new HeavyPavise()
                           , new CrestedHeaterShield()
  } ;
Faction = Factions.Darnasus;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 1600, InventoryTypes.TwoHanded, 10, 2, 17, 2, 0, 0, 0 ));

}
}
public class Shaldyn : BaseCreature 
 { 
public  Shaldyn() : base() 
 { 
Model = 4402;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Shaldyn" ;
Flags1 = 0x08480046 ;
Id = 4185 ; 
Guild = "Clothier";
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
NpcText00 = "Greetings $N, I am Shaldyn." ;
BaseMana = 0 ;
Sells = new Item[] { new CommonBrownShirt()
                           , new CommonWhiteShirt()
                           , new CommonGrayShirt()
                           , new HeavyWeaveBelt()
                           , new HeavyWeaveBracers()
                           , new HeavyWeaveArmor()
                           , new HeavyWeavePants()
                           , new HeavyWeaveGloves()
                           , new HeavyWeaveShoes()
  } ;
Faction = Factions.Darnasus;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
}
}
public class GeeniaSunshadow : BaseCreature 
 { 
public  GeeniaSunshadow() : base() 
 { 
Model = 11907;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Geenia Sunshadow" ;
Flags1 = 0x08080046 ;
Id = 4184 ; 
Guild = "Speciality Dress Maker";
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
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 16+10*Level;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 55, 72 );
NpcText00 = "Greetings $N, I am Geenia Sunshadow." ;
BaseMana = 0 ;
Sells = new Item[] { new FormalDangui()
                           , new BlueWeddingHanbok()
                           , new WhiteTraditionalHanbok()
                           , new RoyalDangui()
                           , new RedTraditionalHanbok()
                           , new GreenWeddingHanbok()
  } ;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
}
}
public class Anadyia : BaseCreature 
 { 
public  Anadyia() : base() 
 { 
Model = 2220;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Anadyia" ;
Flags1 = 0x08480046 ;
Id = 4172 ; 
Guild = "Robe Vendor";
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
NpcText00 = "Greetings $N, I am Anadyia." ;
BaseMana = 0 ;
Sells = new Item[] { new PlainRobe()
                           , new DoubleStitchedRobes()
                           , new RobeOfApprenticeship()
                           , new ChromaticRobe()
                           , new ShimmeringSilkRobes()
                           , new BurningRobes()
                           , new SilverDressRobes()
  } ;
Faction = Factions.Darnasus;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
}
}
public class Veenix : BaseCreature 
 { 
public  Veenix() : base() 
 { 
Model = 7159;
AttackSpeed= 1777;
BoundingRadius = 1.00f ;
Name = "Veenix" ;
Flags1 = 0x066 ;
Id = 4086 ; 
Guild = "Venture Co. Merchant";
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
BaseHitPoints = 984 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 26, 33 );
NpcText00 = "Greetings $N, I am Veenix." ;
BaseMana = 1203 ;
Sells = new Item[] { new Kris()
                           , new BlessedClaymore()
                           , new ExecutionersSword()
                           , new FireproofOrb()
                           , new StrengthOfWill()
                           , new OrbOfPower()
                           , new SchematicGoblinJumperCables()
                           , new DacianFalx()
                           , new Longsword()
                           , new Maul()
                           , new Flail()
                           , new BattleAxe()
                           , new DoubleAxe()
                           , new LongStaff()
  } ;
Faction = Factions.Monster;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7466 , InventoryTypes.OneHand, 14, 1, 13, 0, 0, 0, 0 ), new Item( 6535 , InventoryTypes.HeldInHand, 0, 2, 23, 0, 0, 0, 0 ));
}
}
public class Aeolynn : BaseCreature 
 { 
public  Aeolynn() : base() 
 { 
Model = 2054;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Aeolynn" ;
Flags1 = 0x08480046 ;
Id = 3952 ; 
Guild = "Clothier";
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
BaseHitPoints = 904 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 24, 31 );
NpcText00 = "Greetings $N, I am Aeolynn." ;
BaseMana = 0 ;
Sells = new Item[] { new ThickClothVest()
                           , new ThickClothPants()
                           , new ThickClothShoes()
                           , new ThickClothGloves()
                           , new PaddedBoots()
                           , new PaddedGloves()
                           , new PaddedPants()
                           , new PaddedArmor()
                           , new HeavyWeaveBelt()
                           , new HeavyWeaveBracers()
                           , new PaddedBelt()
                           , new PaddedBracers()
                           , new ThickClothBelt()
                           , new ThickClothBracers()
                           , new KnittedBelt()
                           , new KnittedBracers()
                           , new KnittedSandals()
                           , new KnittedGloves()
                           , new KnittedPants()
                           , new KnittedTunic()
                           , new HeavyWeaveArmor()
                           , new HeavyWeavePants()
                           , new HeavyWeaveGloves()
                           , new HeavyWeaveShoes()
  } ;
Faction = Factions.Darnasus;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}
public class Kiknikle : BaseCreature 
 { 
public  Kiknikle() : base() 
 { 
Model = 7100;
AttackSpeed= 1665;
BoundingRadius = 1.00f ;
Name = "Kiknikle" ;
Flags1 = 0x08000006 ;
Id = 3683 ; 
Guild = "Stylish Clothier";
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
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1304 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 11.00f ;
SetDamage ( 35, 45 );
NpcText00 = "Greetings $N, I am Kiknikle." ;
BaseMana = 1603 ;
Sells = new Item[] { new CommonBrownShirt()
                           , new CommonWhiteShirt()
                           , new CommonGrayShirt()
                           , new HeavyWeaveBelt()
                           , new HeavyWeaveBracers()
                           , new WhisperingVest()
                           , new SolsticeRobe()
                           , new WiseMansBelt()
                           , new PatternRedWoolenBag()
                           , new HeavyWeaveArmor()
                           , new HeavyWeavePants()
                           , new HeavyWeaveGloves()
                           , new HeavyWeaveShoes()
  } ;
Faction = Factions.Beast;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
}
}
public class BrannolEaglemoon : BaseCreature 
 { 
public  BrannolEaglemoon() : base() 
 { 
Model = 1701;
AttackSpeed= 2000;
BoundingRadius = 0.389000f ;
Name = "Brannol Eaglemoon" ;
Flags1 = 0x08480046 ;
Id = 3611 ; 
Guild = "Clothier";
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
Level = RandomLevel( 16 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1424 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 38, 49 );
NpcText00 = "Greetings $N, I am Brannol Eaglemoon." ;
BaseMana = 0 ;
Sells = new Item[] { new KnittedBelt()
                           , new KnittedBracers()
                           , new KnittedSandals()
                           , new KnittedGloves()
                           , new KnittedPants()
                           , new KnittedTunic()
  } ;
Faction = Factions.Darnasus;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
}
}
public class AndreaBoynton : BaseCreature 
 { 
public  AndreaBoynton() : base() 
 { 
Model = 3547;
AttackSpeed= 2000;
BoundingRadius = 0.383000f ;
Name = "Andrea Boynton" ;
Flags1 = 0x08480046 ;
Id = 3554 ; 
Guild = "Clothier";
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
BaseHitPoints = 784 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 20, 26 );
NpcText00 = "Greetings $N, I am Andrea Boynton." ;
BaseMana = 0 ;
Sells = new Item[] { new CommonBrownShirt()
                           , new CommonWhiteShirt()
                           , new CommonGrayShirt()
                           , new HeavyWeaveBelt()
                           , new HeavyWeaveBracers()
                           , new WhisperingVest()
                           , new SolsticeRobe()
                           , new WiseMansBelt()
                           , new HeavyWeaveArmor()
                           , new HeavyWeavePants()
                           , new HeavyWeaveGloves()
                           , new HeavyWeaveShoes()
  } ;
Faction = Factions.Undercity;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 6443 , InventoryTypes.OneHand, 15, 1, 13, 0, 0, 0, 0 ));
}
}
public class KrisLegace : BaseCreature 
 { 
public  KrisLegace() : base() 
 { 
Model = 3643;
AttackSpeed= 2000;
BoundingRadius = 0.208000f ;
Name = "Kris Legace" ;
Flags1 = 0x080066 ;
Id = 3536 ; 
Guild = "Freewheeling Tradeswoman";
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
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 1304 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 35, 45 );
NpcText00 = "Greetings $N, I am Kris Legace." ;
BaseMana = 0 ;
Sells = new Item[] { new CuredLeatherBelt()
                           , new CuredLeatherBracers()
                           , new CuredLeatherArmor()
                           , new CuredLeatherPants()
                           , new CuredLeatherBoots()
                           , new CuredLeatherGloves()
                           , new WolfBracers()
                           , new BearBracers()
                           , new OwlBracers()
                           , new SaberLeggings()
                           , new StalkingPants()
                           , new MysticSarong()
  } ;
Faction = Factions.Friend;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 23316 , InventoryTypes.OneHand, 14, 1, 13, 0, 0, 0, 0 ));
}
}
public class HalijaWhitestrider : BaseCreature 
 { 
public  HalijaWhitestrider() : base() 
 { 
Model = 3875;
AttackSpeed= 2000;
BoundingRadius = 0.872500f ;
Name = "Halija Whitestrider" ;
Flags1 = 0x08400046 ;
Id = 3486 ; 
Guild = "Clothier";
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
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 784 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 3.75f ;
SetDamage ( 20, 26 );
NpcText00 = "Greetings $N, I am Halija Whitestrider." ;
BaseMana = 0 ;
Sells = new Item[] { new CommonBrownShirt()
                           , new CommonWhiteShirt()
                           , new CommonGrayShirt()
                           , new HeavyWeaveBelt()
                           , new HeavyWeaveBracers()
                           , new WhisperingVest()
                           , new SolsticeRobe()
                           , new WiseMansBelt()
                           , new InfernoCloak()
                           , new SpiritCloak()
                           , new SylvanCloak()
                           , new HeavyWeaveArmor()
                           , new HeavyWeavePants()
                           , new HeavyWeaveGloves()
                           , new HeavyWeaveShoes()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 7434 , InventoryTypes.OneHand, 15, 1, 13, 3, 0, 0, 0 ));
}
}
public class TheresaMoulaine : BaseCreature 
 { 
public  TheresaMoulaine() : base() 
 { 
Model = 1498;
AttackSpeed= 2000;
BoundingRadius = 0.208000f ;
Name = "Theresa Moulaine" ;
Flags1 = 0x08480046 ;
Id = 1350 ; 
Guild = "Robe Vendor";
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
NpcText00 = "Greetings $N, I am Theresa Moulaine." ;
BaseMana = 0 ;
Sells = new Item[] { new PlainRobe()
                           , new DoubleStitchedRobes()
                           , new RobeOfApprenticeship()
                           , new ChromaticRobe()
                           , new ShimmeringSilkRobes()
                           , new BurningRobes()
                           , new SilverDressRobes()
  } ;
Faction = Factions.Stormwind;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}
public class MaydaThane : BaseCreature 
 { 
public  MaydaThane() : base() 
 { 
Model = 1522;
AttackSpeed= 2000;
BoundingRadius = 0.208000f ;
Name = "Mayda Thane" ;
Flags1 = 0x08480046 ;
Id = 1339 ; 
Guild = "Cobbler";
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
BaseHitPoints = 824 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 21, 28 );
NpcText00 = "Greetings $N, I am Mayda Thane." ;
BaseMana = 0 ;
Sells = new Item[] { new AugmentedChainBoots()
                           , new BrigandineBoots()
                           , new RussetBoots()
                           , new EmbroideredBoots()
                           , new StuddedBoots()
                           , new ReinforcedLeatherBoots()
  } ;
Faction = Factions.Stormwind;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7441 , InventoryTypes.OneHand, 4, 2, 13, 3, 0, 0, 0 ));
}
}
public class BryanCross : BaseCreature 
 { 
public  BryanCross() : base() 
 { 
Model = 1510;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Bryan Cross" ;
Flags1 = 0x08480046 ;
Id = 1319 ; 
Guild = "Shield Merchant";
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
BaseHitPoints = 700 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 21, 28 );
NpcText00 = "Greetings $N, I am Bryan Cross." ;
BaseMana = 0 ;
Sells = new Item[] { new RingedBuckler()
                           , new MetalBuckler()
                           , new OrnateBuckler()
                           , new ReinforcedTarge()
                           , new RingedBuckler()
                           , new ReinforcedTarge()
                           , new MetalBuckler()
                           , new OrnateBuckler()
                           , new LargeMetalShield()
                           , new KiteShield()
                           , new HeavyPavise()
                           , new CrestedHeaterShield()
  } ;
Faction = Factions.Stormwind;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}
public class EvanLarson : BaseCreature 
 { 
public  EvanLarson() : base() 
 { 
Model = 1489;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Evan Larson" ;
Flags1 = 0x08480046 ;
Id = 1310 ; 
Guild = "Hatter";
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
BaseHitPoints = 760 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 24, 31 );
NpcText00 = "Greetings $N, I am Evan Larson." ;
BaseMana = 0 ;
Sells = new Item[] { new RussetHat()
                           , new StuddedHat()
                           , new AugmentedChainHelm()
                           , new EmbroideredHat()
                           , new ReinforcedLeatherCap()
                           , new BrigandineHelm()
  } ;
Faction = Factions.Stormwind;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}
public class WynneLarson : BaseCreature 
 { 
public  WynneLarson() : base() 
 { 
Model = 1483;
AttackSpeed= 2000;
BoundingRadius = 0.208000f ;
Name = "Wynne Larson" ;
Flags1 = 0x08480046 ;
Id = 1309 ; 
Guild = "Robe Merchant";
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
BaseHitPoints = 820 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 26, 33 );
NpcText00 = "Greetings $N, I am Wynne Larson." ;
BaseMana = 0 ;
Sells = new Item[] { new PlainRobe()
                           , new DoubleStitchedRobes()
                           , new RobeOfApprenticeship()
                           , new ChromaticRobe()
                           , new ShimmeringSilkRobes()
                           , new BurningRobes()
                           , new SilverDressRobes()
  } ;
Faction = Factions.Stormwind;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}
public class LisbethSchneider : BaseCreature 
 { 
public  LisbethSchneider() : base() 
 { 
Model = 1447;
AttackSpeed= 2000;
BoundingRadius = 0.208000f ;
Name = "Lisbeth Schneider" ;
Flags1 = 0x08480046 ;
Id = 1299 ; 
Guild = "Clothier";
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
NpcText00 = "Greetings $N, I am Lisbeth Schneider." ;
BaseMana = 0 ;
Sells = new Item[] { new BlueWeddingHanbok()
                           , new WhiteTraditionalHanbok()
                           , new RoyalDangui()
                           , new BoldYellowShirt()
                           , new StylishBlackShirt()
                           , new CommonGrayShirt()
  } ;
Faction = Factions.Stormwind;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}
public class Grimnal : BaseCreature 
 { 
public  Grimnal() : base() 
 { 
Model = 4562;
AttackSpeed= 2000;
BoundingRadius = 0.372000f ;
Name = "Grimnal" ;
Flags1 = 0x08400046 ;
Id = 980 ; 
Guild = "Mail & Plate Merchant";
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
CombatReach = 1.500000f ;
SetDamage ( 49, 63 );
NpcText00 = "Greetings $N, I am Grimnal." ;
BaseMana = 0 ;
Sells = new Item[] { new OrnateBuckler()
                           , new BrigandineVest()
                           , new BrigandineBelt()
                           , new BrigandineLeggings()
                           , new BrigandineBoots()
                           , new BrigandineBracers()
                           , new BrigandineGloves()
                           , new OrnateBuckler()
                           , new CrestedHeaterShield()
                           , new BrigandineHelm()
                           , new PlatemailBelt()
                           , new PlatemailBoots()
                           , new PlatemailBracers()
                           , new PlatemailGloves()
                           , new PlatemailHelm()
                           , new PlatemailLeggings()
                           , new PlatemailArmor()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 7439 , InventoryTypes.OneHand, 4, 2, 13, 3, 0, 0, 0 ));
}
}
public class MorleyEberlein : BaseCreature 
 { 
public  MorleyEberlein() : base() 
 { 
Model = 5012;
AttackSpeed= 1500;
BoundingRadius = 0.306000f ;
Name = "Morley Eberlein" ;
Flags1 = 0x08480046 ;
Id = 959 ; 
Guild = "Clothier";
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
BaseHitPoints = 200 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 24, 31 );
NpcText00 = "Greetings $N, I am Morley Eberlein." ;
BaseMana = 0 ;
Sells = new Item[] { new KnittedBelt()
                           , new KnittedBracers()
                           , new KnittedSandals()
                           , new KnittedGloves()
                           , new KnittedPants()
                           , new KnittedTunic()
  } ;
Faction = Factions.Stormwind;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
}
}
public class MorhanCoppertongue : BaseCreature 
 { 
public  MorhanCoppertongue() : base() 
 { 
Model = 1844;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Morhan Coppertongue" ;
Flags1 = 0x08480046 ;
Id = 167 ; 
Guild = "Metalsmith";
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
Level = RandomLevel( 13 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 544 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 14, 18 );
NpcText00 = "Greetings $N, I am Morhan Coppertongue." ;
BaseMana = 0 ;
Sells = new Item[] { new ChainmailBelt()
                           , new ChainmailBracers()
                           , new EnamelledBroadsword()
                           , new FeralBlade()
                           , new ChainmailArmor()
                           , new ChainmailPants()
                           , new ChainmailBoots()
                           , new ChainmailGloves()
  } ;
Faction = Factions.IronForge;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
}
}
public class KaraAdams : BaseCreature 
 { 
public  KaraAdams() : base() 
 { 
Model = 3356;
AttackSpeed= 2000;
BoundingRadius = 0.208000f ;
Name = "Kara Adams" ;
Flags1 = 0x08480046 ;
Id = 793 ; 
Guild = "Shield Crafter";
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
NpcText00 = "Greetings $N, I am Kara Adams." ;
BaseMana = 0 ;
Sells = new Item[] { new RingedBuckler()
                           , new RingedBuckler()
                           , new LargeMetalShield()
                           , new GuardianBuckler()
                           , new BearBuckler()
                           , new OwlsDisk()
  } ;
Faction = Factions.Stormwind;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7483, InventoryTypes.OneHand, 7, 1, 13, 3, 0, 0, 0 ), new Item( 1685, InventoryTypes.Shield, 6, 1, 14, 3, 0, 0, 0 ));
}
}
public class KurranSteele : BaseCreature 
 { 
public  KurranSteele() : base() 
 { 
Model = 1289;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Kurran Steele" ;
Flags1 = 0x08480046 ;
Id = 74 ; 
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
NpcType = 7 ;
BaseHitPoints = 200 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 10, 14 );
NpcText00 = "Greetings $N, I am Kurran Steele." ;
BaseMana = 0 ;
Sells = new Item[] { new RoughLeatherBelt()
                           , new RoughLeatherBracers()
                           , new KnittedBelt()
                           , new KnittedBracers()
                           , new KnittedSandals()
                           , new KnittedGloves()
                           , new KnittedPants()
                           , new KnittedTunic()
                           , new RoughLeatherBoots()
                           , new RoughLeatherGloves()
                           , new RoughLeatherPants()
                           , new RoughLeatherVest()
  } ;
Faction = Factions.Stormwind;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
}
}

public class MorgGnarltree : BaseCreature 
 { 
public  MorgGnarltree() : base() 
 { 
Model = 4332;
AttackSpeed= 1500;
BoundingRadius = 0.306000f ;
Name = "Morg Gnarltree" ;
Flags1 = 0x08480046 ;
Id = 226 ; 
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
NpcType = 7 ;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Morg Gnarltree." ;
BaseMana = 0 ;
Sells = new Item[] { new ReinforcedTarge()
                           , new PolishedScaleBelt()
                           , new PolishedScaleBoots()
                           , new PolishedScaleBracers()
                           , new PolishedScaleGloves()
                           , new PolishedScaleLeggings()
                           , new PolishedScaleVest()
                           , new ReinforcedTarge()
                           , new KiteShield()
                           , new FieryCloak()
                           , new HeavyRunedCloak()
                           , new AntiquatedCloak()
                           , new MightyChainPants()
                           , new LegionnairesLeggings()
  } ;
Faction = Factions.Stormwind;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Guild = "Armorer" ;
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7439, InventoryTypes.OneHand, 4, 2, 13, 3, 0, 0, 0 ));
}
}

public class VeldanLightfoot : BaseCreature 
 { 
public  VeldanLightfoot() : base() 
 { 
Model = 3339;
AttackSpeed= 1500;
BoundingRadius = 0.306000f ;
Name = "Veldan Lightfoot" ;
Flags1 = 0x08480046 ;
Id = 896 ; 
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
NpcType = 7 ;
BaseHitPoints = 424 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 10, 14 );
NpcText00 = "Greetings $N, I am Veldan Lightfoot." ;
BaseMana = 0 ;
Sells = new Item[] { new RoughLeatherBelt()
                           , new RoughLeatherBracers()
                           , new TannedLeatherBelt()
                           , new TannedLeatherBracers()
                           , new RoughLeatherBoots()
                           , new RoughLeatherGloves()
                           , new RoughLeatherPants()
                           , new RoughLeatherVest()
                           , new TannedLeatherBoots()
                           , new TannedLeatherGloves()
                           , new TannedLeatherPants()
                           , new TannedLeatherJerkin()
  } ;
Faction = Factions.Stormwind;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Guild = "Armorer" ;
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}

public class KatSampson : BaseCreature 
 { 
public  KatSampson() : base() 
 { 
Model = 1842;
AttackSpeed= 1500;
BoundingRadius = 0.208000f ;
Name = "Kat Sampson" ;
Flags1 = 0x08480046 ;
Id = 954 ; 
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
Level = RandomLevel( 17 );
NpcType = 7 ;
BaseHitPoints = 704 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 18, 23 );
NpcText00 = "Greetings $N, I am Kat Sampson." ;
BaseMana = 0 ;
Sells = new Item[] { new TannedLeatherBelt()
                           , new TannedLeatherBracers()
                           , new AgileBoots()
                           , new StableBoots()
                           , new TannedLeatherBoots()
                           , new TannedLeatherGloves()
                           , new TannedLeatherPants()
                           , new TannedLeatherJerkin()
  } ;
Faction = Factions.IronForge;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Guild = "Armorer" ;
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
}
}

public class DorinSongblade : BaseCreature 
 { 
public  DorinSongblade() : base() 
 { 
Model = 3353;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Dorin Songblade" ;
Flags1 = 0x08480046 ;
Id = 956 ; 
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
NpcType = 7 ;
BaseHitPoints = 904 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 24, 31 );
NpcText00 = "Greetings $N, I am Dorin Songblade." ;
BaseMana = 0 ;
Sells = new Item[] { new ScalemailBracers()
                           , new ScalemailBelt()
                           , new ScalemailVest()
                           , new ScalemailPants()
                           , new ScalemailBoots()
                           , new ScalemailGloves()
  } ;
Faction = Factions.Stormwind;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Guild = "Armorer" ;
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7482, InventoryTypes.OneHand, 7, 1, 13, 3, 0, 0, 0 ));
}
}

public class Thralosh : BaseCreature 
 { 
public  Thralosh() : base() 
 { 
Model = 4565;
AttackSpeed= 2000;
BoundingRadius = 0.372000f ;
Name = "Thralosh" ;
Flags1 = 0x08400046 ;
Id = 984 ; 
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
NpcType = 7 ;
BaseHitPoints = 1825 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 49, 63 );
NpcText00 = "Greetings $N, I am Thralosh." ;
BaseMana = 0 ;
Sells = new Item[] { new PaleLeggings()
                           , new CinderclothLeggings()
                           , new EmbroideredArmor()
                           , new EmbroideredPants()
                           , new EmbroideredBoots()
                           , new EmbroideredGloves()
                           , new ReinforcedLeatherVest()
                           , new ReinforcedLeatherBelt()
                           , new ReinforcedLeatherPants()
                           , new ReinforcedLeatherBoots()
                           , new ReinforcedLeatherBracers()
                           , new ReinforcedLeatherGloves()
                           , new EmbroideredBelt()
                           , new EmbroideredBracers()
                           , new EmbroideredHat()
                           , new ReinforcedLeatherCap()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
}
}

public class GrundelHarkin : BaseCreature 
 { 
public  GrundelHarkin() : base() 
 { 
Model = 3397;
AttackSpeed= 1500;
BoundingRadius = 0.347000f ;
Name = "Grundel Harkin" ;
Flags1 = 0x08080066 ;
Id = 1104 ; 
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
NpcType = 7 ;
BaseHitPoints = 224 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 5, 6 );
NpcText00 = "Greetings $N, I am Grundel Harkin." ;
BaseMana = 0 ;
Sells = new Item[] { new SmallShield()
                           , new LargeRoundShield()
                           , new SmallShield()
                           , new TarnishedChainVest()
                           , new TarnishedChainBelt()
                           , new TarnishedChainLeggings()
                           , new TarnishedChainBoots()
                           , new TarnishedChainBracers()
                           , new TarnishedChainGloves()
  } ;
Faction = Factions.IronForge;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Guild = "Armorer" ;
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
//Equip( new Item( 1684, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
//equipmodel=1 1684 4 6 1 14 4 0 0 0
}
}

public class Hragran : BaseCreature 
 { 
public  Hragran() : base() 
 { 
Model = 4371;
AttackSpeed= 2000;
BoundingRadius = 0.372000f ;
Name = "Hragran" ;
Flags1 = 0x08400046 ;
Id = 1147 ; 
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
NpcType = 7 ;
BaseHitPoints = 1625 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 43, 56 );
NpcText00 = "Greetings $N, I am Hragran." ;
BaseMana = 0 ;
Sells = new Item[] { new RussetVest()
                           , new RussetPants()
                           , new RussetBoots()
                           , new RussetGloves()
                           , new StuddedDoublet()
                           , new StuddedBelt()
                           , new StuddedPants()
                           , new StuddedBoots()
                           , new StuddedBracers()
                           , new StuddedGloves()
                           , new RussetBelt()
                           , new RussetBracers()
                           , new RussetHat()
                           , new StuddedHat()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
}
}

public class AldrenCordon : BaseCreature 
 { 
public  AldrenCordon() : base() 
 { 
Model = 1821;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Aldren Cordon" ;
Flags1 = 0x08480046 ;
Id = 1214 ; 
Guild = "Clothier";
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
BaseHitPoints = 744 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 19, 25 );
NpcText00 = "Greetings $N, I am Aldren Cordon." ;
BaseMana = 0 ;
Sells = new Item[] { new CommonBrownShirt()
                           , new CommonWhiteShirt()
                           , new CommonGrayShirt()
                           , new HeavyWeaveBelt()
                           , new HeavyWeaveBracers()
                           , new WhisperingVest()
                           , new SolsticeRobe()
                           , new WiseMansBelt()
                           , new HeavyWeaveArmor()
                           , new HeavyWeavePants()
                           , new HeavyWeaveGloves()
                           , new HeavyWeaveShoes()
  } ;
Faction = Factions.IronForge;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
}
}
public class GodricRothgar : BaseCreature 
 { 
public  GodricRothgar() : base() 
 { 
Model = 3278;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Godric Rothgar" ;
Flags1 = 0x08080066 ;
Id = 1213 ; 
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
NpcType = 7 ;
BaseHitPoints = 224 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 5, 6 );
NpcText00 = "Greetings $N, I am Godric Rothgar." ;
BaseMana = 0 ;
Sells = new Item[] { new SmallShield()
                           , new LargeRoundShield()
                           , new SmallShield()
                           , new TarnishedChainVest()
                           , new TarnishedChainBelt()
                           , new TarnishedChainLeggings()
                           , new TarnishedChainBoots()
                           , new TarnishedChainBracers()
                           , new TarnishedChainGloves()
  } ;
Faction = Factions.Stormwind;
Guild = "Armorer" ;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 7439, InventoryTypes.OneHand, 4, 2, 13, 3, 0, 0, 0 ));
}
}

public class GamiliFrosthide : BaseCreature 
 { 
public  GamiliFrosthide() : base() 
 { 
Model = 3420;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Gamili Frosthide" ;
Flags1 = 0x08480046 ;
Id = 1238 ; 
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
NpcType = 7 ;
BaseHitPoints = 424 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 10, 14 );
NpcText00 = "Greetings $N, I am Gamili Frosthide." ;
BaseMana = 0 ;
Sells = new Item[] { new RoughLeatherBelt()
                           , new RoughLeatherBracers()
                           , new ThinClothShoes()
                           , new ThinClothGloves()
                           , new ThinClothPants()
                           , new ThinClothArmor()
                           , new CrackedLeatherBelt()
                           , new CrackedLeatherBoots()
                           , new CrackedLeatherBracers()
                           , new CrackedLeatherGloves()
                           , new CrackedLeatherPants()
                           , new CrackedLeatherVest()
                           , new ThinClothBelt()
                           , new ThinClothBracers()
                           , new KnittedBelt()
                           , new KnittedBracers()
                           , new KnittedSandals()
                           , new KnittedGloves()
                           , new KnittedPants()
                           , new KnittedTunic()
                           , new RoughLeatherBoots()
                           , new RoughLeatherGloves()
                           , new RoughLeatherPants()
                           , new RoughLeatherVest()
  } ;
Faction = Factions.IronForge;
Guild = "Armorer" ;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
}
}

public class QuartermasterHudson : BaseCreature 
 { 
public  QuartermasterHudson() : base() 
 { 
Model = 3337;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Quartermaster Hudson" ;
Flags1 = 0x08480046 ;
Id = 1249 ; 
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
NpcType = 7 ;
BaseHitPoints = 424 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 10, 14 );
NpcText00 = "Greetings $N, I am Quartermaster Hudson." ;
BaseMana = 0 ;
Sells = new Item[] { new SmallTarge()
                           , new DullHeaterShield()
                           , new SmallTarge()
                           , new LightMailArmor()
                           , new LightMailBelt()
                           , new LightMailLeggings()
                           , new LightMailBoots()
                           , new LightMailBracers()
                           , new LightMailGloves()
  } ;
Faction = Factions.Stormwind;
Guild = "Armorer" ;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 7439, InventoryTypes.OneHand, 4, 2, 13, 3, 0, 0, 0 ));
}
}

public class CarlaGranger : BaseCreature 
 { 
public  CarlaGranger() : base() 
 { 
Model = 1439;
AttackSpeed= 2000;
BoundingRadius = 0.208000f ;
Name = "Carla Granger" ;
Flags1 = 0x08480046 ;
Id = 1291 ; 
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
NpcType = 7 ;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Carla Granger." ;
BaseMana = 0 ;
Sells = new Item[] { new CommonBrownShirt()
                           , new CommonWhiteShirt()
                           , new ThickClothVest()
                           , new ThickClothPants()
                           , new ThickClothShoes()
                           , new ThickClothGloves()
                           , new CommonGrayShirt()
                           , new HeavyWeaveBelt()
                           , new HeavyWeaveBracers()
                           , new ThickClothBelt()
                           , new ThickClothBracers()
                           , new KnittedBelt()
                           , new KnittedBracers()
                           , new KnittedSandals()
                           , new KnittedGloves()
                           , new KnittedPants()
                           , new KnittedTunic()
                           , new HeavyWeaveArmor()
                           , new HeavyWeavePants()
                           , new HeavyWeaveGloves()
                           , new HeavyWeaveShoes()
  } ;
Faction = Factions.Stormwind;
Guild = "Armorer" ;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}

public class AldricMoore : BaseCreature 
 { 
public  AldricMoore() : base() 
 { 
Model = 1423;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Aldric Moore" ;
Flags1 = 0x08480046 ;
Id = 1294 ; 
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
NpcType = 7 ;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Aldric Moore." ;
BaseMana = 0 ;
Sells = new Item[] { new ChainmailBelt()
                           , new ChainmailBracers()
                           , new ScalemailBracers()
                           , new ScalemailBelt()
                           , new LightMailArmor()
                           , new LightMailBelt()
                           , new LightMailLeggings()
                           , new LightMailBoots()
                           , new LightMailBracers()
                           , new LightMailGloves()
                           , new ScalemailVest()
                           , new ScalemailPants()
                           , new ScalemailBoots()
                           , new ScalemailGloves()
                           , new ChainmailArmor()
                           , new ChainmailPants()
                           , new ChainmailBoots()
                           , new ChainmailGloves()
  } ;
Faction = Factions.Stormwind;
Guild = "Armorer" ;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}

public class LaraMoore : BaseCreature 
 { 
public  LaraMoore() : base() 
 { 
Model = 1445;
AttackSpeed= 2000;
BoundingRadius = 0.208000f ;
Name = "Lara Moore" ;
Flags1 = 0x08480046 ;
Id = 1295 ; 
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
NpcType = 7 ;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Lara Moore." ;
BaseMana = 0 ;
Sells = new Item[] { new RoughLeatherBelt()
                           , new RoughLeatherBracers()
                           , new TannedLeatherBelt()
                           , new TannedLeatherBracers()
                           , new CuredLeatherBelt()
                           , new CuredLeatherBracers()
                           , new CuredLeatherArmor()
                           , new CuredLeatherPants()
                           , new CuredLeatherBoots()
                           , new CuredLeatherGloves()
                           , new RoughLeatherBoots()
                           , new RoughLeatherGloves()
                           , new RoughLeatherPants()
                           , new RoughLeatherVest()
                           , new TannedLeatherBoots()
                           , new TannedLeatherGloves()
                           , new TannedLeatherPants()
                           , new TannedLeatherJerkin()
  } ;
Faction = Factions.Stormwind;
Guild = "Armorer" ;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}

public class DuncanCullen : BaseCreature 
 { 
public  DuncanCullen() : base() 
 { 
Model = 1488;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Duncan Cullen" ;
Flags1 = 0x08480046 ;
Id = 1314 ; 
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
NpcType = 7 ;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Duncan Cullen." ;
BaseMana = 0 ;
Sells = new Item[] { new CuirboulliVest()
                           , new CuirboulliBelt()
                           , new CuirboulliBoots()
                           , new CuirboulliBracers()
                           , new CuirboulliGloves()
                           , new CuirboulliPants()
                           , new PaddedBoots()
                           , new PaddedGloves()
                           , new PaddedPants()
                           , new PaddedArmor()
                           , new RussetVest()
                           , new RussetPants()
                           , new RussetBoots()
                           , new RussetGloves()
                           , new EmbroideredArmor()
                           , new EmbroideredPants()
                           , new EmbroideredBoots()
                           , new EmbroideredGloves()
                           , new StuddedDoublet()
                           , new StuddedBelt()
                           , new StuddedPants()
                           , new StuddedBoots()
                           , new StuddedBracers()
                           , new StuddedGloves()
                           , new ReinforcedLeatherVest()
                           , new ReinforcedLeatherBelt()
                           , new ReinforcedLeatherPants()
                           , new ReinforcedLeatherBoots()
                           , new ReinforcedLeatherBracers()
                           , new ReinforcedLeatherGloves()
                           , new EmbroideredBelt()
                           , new EmbroideredBracers()
                           , new PaddedBelt()
                           , new PaddedBracers()
                           , new RussetBelt()
                           , new RussetBracers()
                           , new RussetHat()
                           , new StuddedHat()
                           , new EmbroideredHat()
                           , new ReinforcedLeatherCap()
  } ;
Faction = Factions.Stormwind;
Guild = "Armorer" ;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}

public class SeomanGriffith : BaseCreature 
 { 
public  SeomanGriffith() : base() 
 { 
Model = 1517;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Seoman Griffith" ;
Flags1 = 0x08480046 ;
Id = 1320 ; 
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
NpcType = 7 ;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Seoman Griffith." ;
BaseMana = 0 ;
Sells = new Item[] { new StuddedDoublet()
                           , new StuddedBelt()
                           , new StuddedPants()
                           , new StuddedBoots()
                           , new StuddedBracers()
                           , new StuddedGloves()
                           , new ReinforcedLeatherVest()
                           , new ReinforcedLeatherBelt()
                           , new ReinforcedLeatherPants()
                           , new ReinforcedLeatherBoots()
                           , new ReinforcedLeatherBracers()
                           , new ReinforcedLeatherGloves()
                           , new StuddedHat()
                           , new ReinforcedLeatherCap()
  } ;
Faction = Factions.Stormwind;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Guild = "Armorer" ;
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}

public class MaxtonStrang : BaseCreature 
 { 
public  MaxtonStrang() : base() 
 { 
Model = 1514;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Maxton Strang" ;
Flags1 = 0x08480046 ;
Id = 1322 ; 
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
NpcType = 7 ;
BaseHitPoints = 1625 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 43, 56 );
NpcText00 = "Greetings $N, I am Maxton Strang." ;
BaseMana = 0 ;
Sells = new Item[] { new MetalBuckler()
                           , new AugmentedChainVest()
                           , new AugmentedChainLeggings()
                           , new AugmentedChainBelt()
                           , new AugmentedChainBoots()
                           , new AugmentedChainBracers()
                           , new AugmentedChainGloves()
                           , new HeavyPavise()
                           , new AugmentedChainHelm()
  } ;
Faction = Factions.Stormwind;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Guild = "Armorer" ;
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 7439, InventoryTypes.OneHand, 4, 2, 13, 3, 0, 0, 0 ));
}
}

	public class OsricStrang : BaseNPC 
	{ 
		public  OsricStrang() : base() 
		{ 
			Model = 1515;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Osric Strang" ;
			Flags1 = 0x08480046 ;
			Id = 1323 ; 
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
			NpcType = 7 ;
			BaseHitPoints = 1224 ;
			NpcFlags = (int)NpcActions.Vendor;
			CombatReach = 1.5f ;
			SetDamage ( 32, 42 );
			NpcText00 = "Greetings $N, I am Osric Strang." ;
			BaseMana = 0 ;
			Sells = new Item[] { new MetalBuckler()
								   , new OrnateBuckler()
								   , new ReinforcedTarge()
								   , new PolishedScaleBelt()
								   , new PolishedScaleBoots()
								   , new PolishedScaleBracers()
								   , new PolishedScaleGloves()
								   , new PolishedScaleLeggings()
								   , new PolishedScaleVest()
								   , new AugmentedChainVest()
								   , new AugmentedChainLeggings()
								   , new AugmentedChainBelt()
								   , new AugmentedChainBoots()
								   , new AugmentedChainBracers()
								   , new AugmentedChainGloves()
								   , new BrigandineVest()
								   , new BrigandineBelt()
								   , new BrigandineLeggings()
								   , new BrigandineBoots()
								   , new BrigandineBracers()
								   , new BrigandineGloves()
								   , new ReinforcedTarge()
								   , new MetalBuckler()
								   , new OrnateBuckler()
								   , new KiteShield()
								   , new HeavyPavise()
								   , new CrestedHeaterShield()
								   , new AugmentedChainHelm()
								   , new BrigandineHelm()
								   , new PlatemailBelt()
								   , new PlatemailBoots()
								   , new PlatemailBracers()
								   , new PlatemailGloves()
								   , new PlatemailHelm()
								   , new PlatemailLeggings()
								   , new PlatemailArmor()
							   } ;
			Faction = Factions.Stormwind;
			AIEngine = new DefensiveAnimalAI( this );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
			Guild = "Armorer" ;
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
			Equip( new Item( 7439, InventoryTypes.OneHand, 4, 2, 13, 3, 0, 0, 0 ));
			//Quests = new BaseQuest[] { new Dungar_Longdrink() };
		}
	}

public class WilhelmStrang : BaseCreature 
 { 
public  WilhelmStrang() : base() 
 { 
Model = 1518;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Wilhelm Strang" ;
Flags1 = 0x08480046 ;
Id = 1341 ; 
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
NpcType = 7 ;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Wilhelm Strang." ;
BaseMana = 0 ;
Sells = new Item[] { new ScalemailBracers()
                           , new ScalemailBelt()
                           , new PolishedScaleBelt()
                           , new PolishedScaleBoots()
                           , new PolishedScaleBracers()
                           , new PolishedScaleGloves()
                           , new PolishedScaleLeggings()
                           , new PolishedScaleVest()
                           , new ScalemailVest()
                           , new ScalemailPants()
                           , new ScalemailBoots()
                           , new ScalemailGloves()
  } ;
Faction = Factions.Stormwind;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Guild = "Armorer" ;
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}

public class AgustusMoulaine : BaseCreature 
 { 
public  AgustusMoulaine() : base() 
 { 
Model = 1500;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Agustus Moulaine" ;
Flags1 = 0x08480046 ;
Id = 1349 ; 
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
NpcType = 7 ;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Agustus Moulaine." ;
BaseMana = 0 ;
Sells = new Item[] { new MetalBuckler()
                           , new OrnateBuckler()
                           , new ReinforcedTarge()
                           , new PolishedScaleBelt()
                           , new PolishedScaleBoots()
                           , new PolishedScaleBracers()
                           , new PolishedScaleGloves()
                           , new PolishedScaleLeggings()
                           , new PolishedScaleVest()
                           , new AugmentedChainVest()
                           , new AugmentedChainLeggings()
                           , new AugmentedChainBelt()
                           , new AugmentedChainBoots()
                           , new AugmentedChainBracers()
                           , new AugmentedChainGloves()
                           , new BrigandineVest()
                           , new BrigandineBelt()
                           , new BrigandineLeggings()
                           , new BrigandineBoots()
                           , new BrigandineBracers()
                           , new BrigandineGloves()
                           , new ReinforcedTarge()
                           , new MetalBuckler()
                           , new OrnateBuckler()
                           , new KiteShield()
                           , new HeavyPavise()
                           , new CrestedHeaterShield()
                           , new AugmentedChainHelm()
                           , new BrigandineHelm()
                           , new PlatemailBelt()
                           , new PlatemailBoots()
                           , new PlatemailBracers()
                           , new PlatemailGloves()
                           , new PlatemailHelm()
                           , new PlatemailLeggings()
                           , new PlatemailArmor()
  } ;
Faction = Factions.Stormwind;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Guild = "Armorer" ;
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}

public class Krakk : BaseCreature 
 { 
public  Krakk() : base() 
 { 
Model = 4373;
AttackSpeed= 2000;
BoundingRadius = 0.372000f ;
Name = "Krakk" ;
Flags1 = 0x08400046 ;
Id = 1381 ; 
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
NpcType = 7 ;
BaseHitPoints = 1625 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 43, 56 );
NpcText00 = "Greetings $N, I am Krakk." ;
BaseMana = 0 ;
Sells = new Item[] { new MetalBuckler()
                           , new AugmentedChainVest()
                           , new AugmentedChainLeggings()
                           , new AugmentedChainBelt()
                           , new AugmentedChainBoots()
                           , new AugmentedChainBracers()
                           , new AugmentedChainGloves()
                           , new MetalBuckler()
                           , new HeavyPavise()
                           , new AugmentedChainHelm()
  } ;
Faction = Factions.Ogrimmar;
  AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
}
}

public class Sranda : BaseCreature 
 { 
public  Sranda() : base() 
 { 
Model = 4385;
AttackSpeed= 2000;
BoundingRadius = 0.236000f ;
Name = "Sranda" ;
Flags1 = 0x08480046 ;
Id = 1407 ; 
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
NpcType = 7 ;
BaseHitPoints = 1625 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 43, 56 );
NpcText00 = "Greetings $N, I am Sranda." ;
BaseMana = 0 ;
Sells = new Item[] { new RussetVest()
                           , new RussetPants()
                           , new RussetBoots()
                           , new RussetGloves()
                           , new EmbroideredArmor()
                           , new EmbroideredPants()
                           , new EmbroideredBoots()
                           , new EmbroideredGloves()
                           , new StuddedDoublet()
                           , new StuddedBelt()
                           , new StuddedPants()
                           , new StuddedBoots()
                           , new StuddedBracers()
                           , new StuddedGloves()
                           , new ReinforcedLeatherVest()
                           , new ReinforcedLeatherBelt()
                           , new ReinforcedLeatherPants()
                           , new ReinforcedLeatherBoots()
                           , new ReinforcedLeatherBracers()
                           , new ReinforcedLeatherGloves()
                           , new Falchion()
                           , new Zweihander()
                           , new Francisca()
                           , new GreatAxe()
                           , new MorningStar()
                           , new WarMaul()
                           , new Rondel()
                           , new WarStaff()
                           , new EmbroideredBelt()
                           , new EmbroideredBracers()
                           , new RussetBelt()
                           , new RussetBracers()
                           , new RussetHat()
                           , new StuddedHat()
                           , new EmbroideredHat()
                           , new ReinforcedLeatherCap()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 7492, InventoryTypes.OneHand, 7, 1, 13, 3, 0, 0, 0 ), new Item( 6434, InventoryTypes.OneHand, 15, 1, 13, 3, 0, 0, 0 ));
}
}

public class Brahnmar : BaseCreature 
 { 
public  Brahnmar() : base() 
 { 
Model = 3474;
AttackSpeed= 1500;
BoundingRadius = 0.347000f ;
Name = "Brahnmar" ;
Flags1 = 0x08480046 ;
Id = 1450 ; 
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
NpcType = 7 ;
BaseHitPoints = 1024 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 27, 35 );
NpcText00 = "Greetings $N, I am Brahnmar." ;
BaseMana = 0 ;
Sells = new Item[] { new ReinforcedTarge()
                           , new PolishedScaleBelt()
                           , new PolishedScaleBoots()
                           , new PolishedScaleBracers()
                           , new PolishedScaleGloves()
                           , new PolishedScaleLeggings()
                           , new PolishedScaleVest()
                           , new ReinforcedTarge()
                           , new KiteShield()
  } ;
Faction = Factions.IronForge;
Guild = "Armorer" ;
AIEngine = new AgressiveAnimalAI( this );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7439, InventoryTypes.OneHand, 4, 2, 13, 3, 0, 0, 0 ), new Item( 1755, InventoryTypes.Shield, 6, 1, 14, 4, 0, 0, 0 ));
}
}

public class AndrewKrighton : BaseCreature 
 { 
public  AndrewKrighton() : base() 
 { 
Model = 3340;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Andrew Krighton" ;
Flags1 = 0x08480006 ;
Id = 2046 ; 
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
Level = RandomLevel( 8 );
NpcType = 7 ;
BaseHitPoints = 160 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 8, 11 );
NpcText00 = "Greetings $N, I am Andrew Krighton." ;
BaseMana = 0 ;
Sells = new Item[] { new SmallTarge()
                           , new DullHeaterShield()
                           , new SmallTarge()
                           , new LightMailArmor()
                           , new LightMailBelt()
                           , new LightMailLeggings()
                           , new LightMailBoots()
                           , new LightMailBracers()
                           , new LightMailGloves()
  } ;
Faction = Factions.Stormwind;
Guild = "Armorer" ;
AIEngine = new AgressiveAnimalAI( this );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
}
}

public class ArchibaldKava : BaseCreature 
 { 
public  ArchibaldKava() : base() 
 { 
Model = 1574;
AttackSpeed= 2000;
BoundingRadius = 0.383000f ;
Name = "Archibald Kava" ;
Flags1 = 0x08000066 ;
Id = 2113 ; 
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
NpcType = 6 ;
BaseHitPoints = 224 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 5, 6 );
NpcText00 = "Greetings $N, I am Archibald Kava." ;
BaseMana = 0 ;
Sells = new Item[] { new DirtyLeatherBelt()
                           , new DirtyLeatherBracers()
                           , new TatteredClothVest()
                           , new TatteredClothPants()
                           , new TatteredClothBoots()
                           , new DirtyLeatherPants()
                           , new DirtyLeatherBoots()
                           , new TatteredClothBelt()
                           , new TatteredClothBracers()
                           , new TatteredClothGloves()
                           , new DirtyLeatherGloves()
                           , new DirtyLeatherVest()
  } ;
Faction = Factions.Undercity;
Guild = "Armorer" ;
AIEngine = new AgressiveAnimalAI( this );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 1599, InventoryTypes.TwoHanded, 10, 2, 17, 2, 0, 0, 0 ));
}
}

public class DefiasProfiteer : BaseCreature 
 { 
public  DefiasProfiteer() : base() 
 { 
Model = 4423;
AttackSpeed= 1500;
BoundingRadius = 0.306000f ;
Name = "Defias Profiteer" ;
Flags1 = 0x080066 ;
Id = 1669 ; 
Guild = "Free Wheeling Merchant";
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
Level = RandomLevel( 20 );
NpcType = (int)NpcTypes.Humanoid;
BaseHitPoints = 824 ;
NpcFlags = (int)NpcActions.Vendor ;
CombatReach = 1.5f ;
SetDamage ( 21, 28 );
NpcText00 = "Greetings $N, I am Defias Profiteer." ;
BaseMana = 0 ;
Sells = new Item[] { new TannedLeatherBelt()
                           , new TannedLeatherBracers()
                           , new AgileBoots()
                           , new StableBoots()
                           , new RecipeRagePotion()
                           , new TannedLeatherBoots()
                           , new TannedLeatherGloves()
                           , new TannedLeatherPants()
                           , new TannedLeatherJerkin()
  } ;
Faction = Factions.Friend;
AIEngine = new AgressiveAnimalAI( this );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7428, InventoryTypes.OneHand, 0, 1, 13, 3, 0, 0, 0 ));
}
}
public class BlacksmithRand : BaseCreature 
 { 
public  BlacksmithRand() : base() 
 { 
Model = 1575;
AttackSpeed= 2000;
BoundingRadius = 0.383000f ;
Name = "Blacksmith Rand" ;
Flags1 = 0x08000066 ;
Id = 2116 ; 
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
NpcType = 6 ;
BaseHitPoints = 224 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 5, 6 );
NpcText00 = "Greetings $N, I am Blacksmith Rand." ;
BaseMana = 0 ;
Sells = new Item[] { new DentedBuckler()
                           , new LargeWoodenShield()
                           , new DentedBuckler()
                           , new RustedChainVest()
                           , new RustedChainBelt()
                           , new RustedChainLeggings()
                           , new RustedChainBoots()
                           , new RustedChainBracers()
                           , new RustedChainGloves()
  } ;
Faction = Factions.Undercity;
Guild = "Armorer" ;
AIEngine = new AgressiveAnimalAI( this );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 7439, InventoryTypes.OneHand, 4, 2, 13, 3, 0, 0, 0 ));
}
}

public class AbeWinters : BaseCreature 
 { 
public  AbeWinters() : base() 
 { 
Model = 1631;
AttackSpeed= 2000;
BoundingRadius = 0.383000f ;
Name = "Abe Winters" ;
Flags1 = 0x08400046 ;
Id = 2135 ; 
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
NpcType = 6 ;
BaseHitPoints = 584 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 15, 19 );
NpcText00 = "Greetings $N, I am Abe Winters." ;
BaseMana = 0 ;
Sells = new Item[] { new RoundBuckler()
                           , new WornHeaterShield()
                           , new RoundBuckler()
                           , new LightChainArmor()
                           , new LightChainBelt()
                           , new LightChainLeggings()
                           , new LightChainBoots()
                           , new LightChainBracers()
                           , new LightChainGloves()
  } ;
Faction = Factions.Undercity;
AIEngine = new AgressiveAnimalAI( this );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 7439, InventoryTypes.OneHand, 4, 2, 13, 3, 0, 0, 0 ));
}
}

public class ElizaCallen : BaseCreature 
 { 
public  ElizaCallen() : base() 
 { 
Model = 1634;
AttackSpeed= 2000;
BoundingRadius = 0.383000f ;
Name = "Eliza Callen" ;
Flags1 = 0x08400046 ;
Id = 2137 ; 
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
Level = RandomLevel( 12 );
NpcType = 6 ;
BaseHitPoints = 504 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 13, 16 );
NpcText00 = "Greetings $N, I am Eliza Callen." ;
BaseMana = 0 ;
Sells = new Item[] { new BatteredLeatherHarness()
                           , new BatteredLeatherBelt()
                           , new BatteredLeatherPants()
                           , new BatteredLeatherBoots()
                           , new BatteredLeatherBracers()
                           , new BatteredLeatherGloves()
  } ;
Faction = Factions.Undercity;
AIEngine = new AgressiveAnimalAI( this );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 1599, InventoryTypes.TwoHanded, 10, 2, 17, 2, 0, 0, 0 ));
}
}

public class FargonMortalak : BaseCreature 
 { 
public  FargonMortalak() : base() 
 { 
Model = 4476;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Fargon Mortalak" ;
Flags1 = 0x08080046 ;
Id = 2845 ; 
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
Level = RandomLevel( 42 );
NpcType = 7 ;
BaseHitPoints = 1705 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 46, 59 );
NpcText00 = "Greetings $N, I am Fargon Mortalak." ;
BaseMana = 0 ;
Sells = new Item[] { new HeavyNotchedBelt()
                           , new MetalBuckler()
                           , new AugmentedChainVest()
                           , new AugmentedChainLeggings()
                           , new AugmentedChainBelt()
                           , new AugmentedChainBoots()
                           , new AugmentedChainBracers()
                           , new AugmentedChainGloves()
                           , new MetalBuckler()
                           , new HeavyPavise()
                           , new AugmentedChainHelm()
  } ;
Faction = Factions.BootyBay;
AIEngine = new StandingNpcAI( this );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 7439, InventoryTypes.OneHand, 4, 2, 13, 3, 0, 0, 0 ));
}
}

public class QixdiGoodstitch : BaseCreature 
 { 
public  QixdiGoodstitch() : base() 
 { 
Model = 7187;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Qixdi Goodstitch" ;
Flags1 = 0x08080046 ;
Id = 2849 ; 
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
Level = RandomLevel( 44 );
NpcType = 7 ;
BaseHitPoints = 1785 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 48, 62 );
NpcText00 = "Greetings $N, I am Qixdi Goodstitch." ;
BaseMana = 0 ;
Sells = new Item[] { new ThickClothVest()
                           , new ThickClothPants()
                           , new ThickClothShoes()
                           , new ThickClothGloves()
                           , new PaddedBoots()
                           , new PaddedGloves()
                           , new PaddedPants()
                           , new PaddedArmor()
                           , new RussetVest()
                           , new RussetPants()
                           , new RussetBoots()
                           , new RussetGloves()
                           , new EmbroideredArmor()
                           , new EmbroideredPants()
                           , new EmbroideredBoots()
                           , new EmbroideredGloves()
                           , new EmbroideredBelt()
                           , new EmbroideredBracers()
                           , new PaddedBelt()
                           , new PaddedBracers()
                           , new RussetBelt()
                           , new RussetBracers()
                           , new ThickClothBelt()
                           , new ThickClothBracers()
                           , new RussetHat()
                           , new EmbroideredHat()
                           , new TheRock()
                           , new MoodRing()
                           , new MinisculeDiamondRing()
                           , new FlawlessDiamondSolitaire()
                           , new CubicZirconiaRing()
                           , new SilverPiffenyBand()
  } ;
Faction = Factions.BootyBay;
AIEngine = new StandingNpcAI( this );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
}
}

public class VariaHardhide : BaseCreature 
 { 
public  VariaHardhide() : base() 
 { 
Model = 3798;
AttackSpeed= 2000;
BoundingRadius = 0.872500f ;
Name = "Varia Hardhide" ;
Flags1 = 0x08080066 ;
Id = 3074 ; 
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
Level = RandomLevel( 7 );
NpcType = 7 ;
BaseHitPoints = 304 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 3.75f ;
SetDamage ( 7, 9 );
NpcText00 = "Greetings $N, I am Varia Hardhide." ;
BaseMana = 0 ;
Sells = new Item[] { new DirtyLeatherBelt()
                           , new DirtyLeatherBracers()
                           , new DirtyLeatherPants()
                           , new DirtyLeatherBoots()
                           , new DirtyLeatherGloves()
                           , new DirtyLeatherVest()
  } ;
Faction = Factions.ThunderBluff;
AIEngine = new StandingNpcAI( this );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
}
}

public class BronkSteelrage : BaseCreature 
 { 
public  BronkSteelrage() : base() 
 { 
Model = 3801;
AttackSpeed= 2000;
BoundingRadius = 0.974700f ;
Name = "Bronk Steelrage" ;
Flags1 = 0x08080066 ;
Id = 3075 ; 
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
NpcType = 7 ;
BaseHitPoints = 424 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 4.05f ;
SetDamage ( 10, 14 );
NpcText00 = "Greetings $N, I am Bronk Steelrage." ;
BaseMana = 0 ;
Sells = new Item[] { new DentedBuckler()
                           , new LargeWoodenShield()
                           , new DentedBuckler()
                           , new RustedChainVest()
                           , new RustedChainBelt()
                           , new RustedChainLeggings()
                           , new RustedChainBoots()
                           , new RustedChainBracers()
                           , new RustedChainGloves()
  } ;
Faction = Factions.ThunderBluff;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
//Equip( new Item( 1705, InventoryTypes.Shield, 6, 1, 14, 4, 0, 0, 0 ));
}
}

public class VargWindwhisper : BaseCreature 
 { 
public  VargWindwhisper() : base() 
 { 
Model = 10182;
AttackSpeed= 2000;
BoundingRadius = 0.974700f ;
Name = "Varg Windwhisper" ;
Flags1 = 0x08480046 ;
Id = 3079 ; 
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
NpcType = 7 ;
BaseHitPoints = 584 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 4.05f ;
SetDamage ( 15, 19 );
NpcText00 = "Greetings $N, I am Varg Windwhisper." ;
BaseMana = 0 ;
Sells = new Item[] { new BatteredLeatherHarness()
                           , new BatteredLeatherBelt()
                           , new BatteredLeatherPants()
                           , new BatteredLeatherBoots()
                           , new BatteredLeatherBracers()
                           , new BatteredLeatherGloves()
  } ;
Faction = Factions.ThunderBluff;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
}

public class HarantIronbrace : BaseCreature 
 { 
public  HarantIronbrace() : base() 
 { 
Model = 3804;
AttackSpeed= 2000;
BoundingRadius = 0.974700f ;
Name = "Harant Ironbrace" ;
Flags1 = 0x08480046 ;
Id = 3080 ; 
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
Level = RandomLevel( 13 );
NpcType = 7 ;
BaseHitPoints = 544 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 4.05f ;
SetDamage ( 14, 18 );
NpcText00 = "Greetings $N, I am Harant Ironbrace." ;
BaseMana = 0 ;
Sells = new Item[] { new RoundBuckler()
                           , new WornHeaterShield()
                           , new RoundBuckler()
                           , new LightChainArmor()
                           , new LightChainBelt()
                           , new LightChainLeggings()
                           , new LightChainBoots()
                           , new LightChainBracers()
                           , new LightChainGloves()
  } ;
Faction = Factions.ThunderBluff;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
}
}


public class Tagain : BaseCreature 
 { 
public  Tagain() : base() 
 { 
Model = 2133;
AttackSpeed= 2000;
BoundingRadius = 0.872500f ;
Name = "Tagain" ;
Flags1 = 0x08480046 ;
Id = 3092 ; 
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
NpcType = 7 ;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 3.75f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Tagain." ;
BaseMana = 0 ;
Sells = new Item[] { new ThickClothVest()
                           , new ThickClothPants()
                           , new ThickClothShoes()
                           , new ThickClothGloves()
                           , new PaddedBoots()
                           , new PaddedGloves()
                           , new PaddedPants()
                           , new PaddedArmor()
                           , new RussetVest()
                           , new RussetPants()
                           , new RussetBoots()
                           , new RussetGloves()
                           , new EmbroideredArmor()
                           , new EmbroideredPants()
                           , new EmbroideredBoots()
                           , new EmbroideredGloves()
                           , new PlainRobe()
                           , new DoubleStitchedRobes()
                           , new RobeOfApprenticeship()
                           , new ChromaticRobe()
                           , new ShimmeringSilkRobes()
                           , new BurningRobes()
                           , new SilverDressRobes()
                           , new EmbroideredBelt()
                           , new EmbroideredBracers()
                           , new HeavyWeaveBelt()
                           , new HeavyWeaveBracers()
                           , new PaddedBelt()
                           , new PaddedBracers()
                           , new RussetBelt()
                           , new RussetBracers()
                           , new ThickClothBelt()
                           , new ThickClothBracers()
                           , new KnittedBelt()
                           , new KnittedBracers()
                           , new RussetHat()
                           , new EmbroideredHat()
                           , new KnittedSandals()
                           , new KnittedGloves()
                           , new KnittedPants()
                           , new KnittedTunic()
                           , new HeavyWeaveArmor()
                           , new HeavyWeavePants()
                           , new HeavyWeaveGloves()
                           , new HeavyWeaveShoes()
  } ;
Faction = Factions.ThunderBluff;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 22893, InventoryTypes.OneHand, 0, 1, 13, 3, 0, 0, 0 ));
}
}

public class Grod : BaseCreature 
 { 
public  Grod() : base() 
 { 
Model = 2129;
AttackSpeed= 2000;
BoundingRadius = 0.974700f ;
Name = "Grod" ;
Flags1 = 0x08480046 ;
Id = 3093 ; 
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
NpcType = 7 ;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 4.05f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Grod." ;
BaseMana = 0 ;
Sells = new Item[] { new TannedLeatherBelt()
                           , new TannedLeatherBracers()
                           , new CuredLeatherBelt()
                           , new CuredLeatherBracers()
                           , new CuredLeatherArmor()
                           , new CuredLeatherPants()
                           , new BatteredLeatherHarness()
                           , new BatteredLeatherBelt()
                           , new BatteredLeatherPants()
                           , new BatteredLeatherBoots()
                           , new BatteredLeatherBracers()
                           , new BatteredLeatherGloves()
                           , new CuredLeatherBoots()
                           , new CuredLeatherGloves()
                           , new TannedLeatherBoots()
                           , new TannedLeatherGloves()
                           , new TannedLeatherPants()
                           , new TannedLeatherJerkin()
  } ;
Faction = Factions.ThunderBluff;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 5224, InventoryTypes.OneHand, 0, 1, 21, 3, 0, 0, 0 ));
}
}

public class Fela : BaseCreature 
 { 
public  Fela() : base() 
 { 
Model = 2132;
AttackSpeed= 2000;
BoundingRadius = 0.872500f ;
Name = "Fela" ;
Flags1 = 0x08480046 ;
Id = 3095 ; 
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
NpcType = 7 ;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 3.75f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Fela." ;
BaseMana = 0 ;
Sells = new Item[] { new MetalBuckler()
                           , new OrnateBuckler()
                           , new ReinforcedTarge()
                           , new PolishedScaleBelt()
                           , new PolishedScaleBoots()
                           , new PolishedScaleBracers()
                           , new PolishedScaleGloves()
                           , new PolishedScaleLeggings()
                           , new PolishedScaleVest()
                           , new AugmentedChainVest()
                           , new AugmentedChainLeggings()
                           , new AugmentedChainBelt()
                           , new AugmentedChainBoots()
                           , new AugmentedChainBracers()
                           , new AugmentedChainGloves()
                           , new BrigandineVest()
                           , new BrigandineBelt()
                           , new BrigandineLeggings()
                           , new BrigandineBoots()
                           , new BrigandineBracers()
                           , new BrigandineGloves()
                           , new ReinforcedTarge()
                           , new MetalBuckler()
                           , new OrnateBuckler()
                           , new KiteShield()
                           , new HeavyPavise()
                           , new CrestedHeaterShield()
                           , new AugmentedChainHelm()
                           , new BrigandineHelm()
                           , new PlatemailBelt()
                           , new PlatemailBoots()
                           , new PlatemailBracers()
                           , new PlatemailGloves()
                           , new PlatemailHelm()
                           , new PlatemailLeggings()
                           , new PlatemailArmor()
  } ;
Faction = Factions.ThunderBluff;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 22366, InventoryTypes.OneHand, 7, 1, 13, 3, 0, 0, 0 ));
}
}

public class BernardBrubaker : BaseCreature 
 { 
public  BernardBrubaker() : base() 
 { 
Model = 5013;
AttackSpeed= 1000;
BoundingRadius = 0.306000f ;
Name = "Bernard Brubaker" ;
Flags1 = 0x08400046 ;
Id = 3097 ; 
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
Level = RandomLevel( 20 );
NpcType = 7 ;
BaseHitPoints = 824 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 21, 28 );
NpcText00 = "Greetings $N, I am Bernard Brubaker." ;
BaseMana = 0 ;
Sells = new Item[] { new CuredLeatherBelt()
                           , new CuredLeatherBracers()
                           , new CuredLeatherArmor()
                           , new CuredLeatherPants()
                           , new CuredLeatherBoots()
                           , new CuredLeatherGloves()
                           , new WolfBracers()
                           , new BearBracers()
                           , new OwlBracers()
  } ;
Faction = Factions.Stormwind;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}

public class Huklah : BaseCreature 
 { 
public  Huklah() : base() 
 { 
Model = 1881;
AttackSpeed= 2000;
BoundingRadius = 0.372000f ;
Name = "Huklah" ;
Flags1 = 0x08080066 ;
Id = 3160 ; 
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
Level = RandomLevel( 11 );
NpcType = 7 ;
BaseHitPoints = 464 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 11, 15 );
NpcText00 = "Greetings $N, I am Huklah." ;
BaseMana = 0 ;
Sells = new Item[] { new DirtyLeatherBelt()
                           , new DirtyLeatherBracers()
                           , new TatteredClothVest()
                           , new TatteredClothPants()
                           , new TatteredClothBoots()
                           , new DirtyLeatherPants()
                           , new DirtyLeatherBoots()
                           , new TatteredClothBelt()
                           , new TatteredClothBracers()
                           , new TatteredClothGloves()
                           , new DirtyLeatherGloves()
                           , new DirtyLeatherVest()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
}
}

public class Rarc : BaseCreature 
 { 
public  Rarc() : base() 
 { 
Model = 1885;
AttackSpeed= 2000;
BoundingRadius = 0.372000f ;
Name = "Rarc" ;
Flags1 = 0x08080066 ;
Id = 3161 ; 
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
NpcType = 7 ;
BaseHitPoints = 1000 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 10, 14 );
NpcText00 = "Greetings $N, I am Rarc." ;
BaseMana = 0 ;
Sells = new Item[] { new DentedBuckler()
                           , new LargeWoodenShield()
                           , new DentedBuckler()
                           , new RustedChainVest()
                           , new RustedChainBelt()
                           , new RustedChainLeggings()
                           , new RustedChainBoots()
                           , new RustedChainBracers()
                           , new RustedChainGloves()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
}
}

public class BurdrakHarglhelm : BaseCreature 
 { 
public  BurdrakHarglhelm() : base() 
 { 
Model = 3408;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Burdrak Harglhelm" ;
Flags1 = 0x08480046 ;
Id = 3162 ; 
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
Level = RandomLevel( 12 );
NpcType = 7 ;
BaseHitPoints = 504 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 13, 16 );
NpcText00 = "Greetings $N, I am Burdrak Harglhelm." ;
BaseMana = 0 ;
Sells = new Item[] { new RoughLeatherBelt()
                           , new RoughLeatherBracers()
                           , new RoughLeatherBoots()
                           , new RoughLeatherGloves()
                           , new RoughLeatherPants()
                           , new RoughLeatherVest()
  } ;
Faction = Factions.IronForge;
Guild = "Armorer" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
}
}

public class Cutac : BaseCreature 
 { 
public  Cutac() : base() 
 { 
Model = 3740;
AttackSpeed= 2000;
BoundingRadius = 0.372000f ;
Name = "Cutac" ;
Flags1 = 0x08480046 ;
Id = 3166 ; 
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
NpcType = 7 ;
BaseHitPoints = 624 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 16, 21 );
NpcText00 = "Greetings $N, I am Cutac." ;
BaseMana = 0 ;
Sells = new Item[] { new WovenVest()
                           , new WovenPants()
                           , new WovenBoots()
                           , new WovenGloves()
                           , new BatteredLeatherHarness()
                           , new BatteredLeatherBelt()
                           , new BatteredLeatherPants()
                           , new BatteredLeatherBoots()
                           , new BatteredLeatherBracers()
                           , new BatteredLeatherGloves()
                           , new WovenBelt()
                           , new WovenBracers()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
}
}

public class Wuark : BaseCreature 
 { 
public  Wuark() : base() 
 { 
Model = 3742;
AttackSpeed= 2000;
BoundingRadius = 0.372000f ;
Name = "Wuark" ;
Flags1 = 0x08480046 ;
Id = 3167 ; 
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
Level = RandomLevel( 16 );
NpcType = 7 ;
BaseHitPoints = 624 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 16, 21 );
NpcText00 = "Greetings $N, I am Wuark." ;
BaseMana = 0 ;
Sells = new Item[] { new RoundBuckler()
                           , new WornHeaterShield()
                           , new RoundBuckler()
                           , new LightChainArmor()
                           , new LightChainBelt()
                           , new LightChainLeggings()
                           , new LightChainBoots()
                           , new LightChainBracers()
                           , new LightChainGloves()
                           , new WeakFlux()
                           , new MiningPick()
                           , new StrongFlux()
                           , new Coal()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 8078, InventoryTypes.OneHand, 14, 1, 13, 3, 0, 0, 0 ));
}
}

public class Torphan : BaseCreature 
 { 
public  Torphan() : base() 
 { 
Model = 1315;
AttackSpeed= 1739;
BoundingRadius = 0.372000f ;
Name = "Tor'phan" ;
Flags1 = 0x08480046 ;
Id = 3315 ; 
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
NpcType = 7 ;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Tor'phan." ;
BaseMana = 0 ;
Sells = new Item[] { new Tabar()
                           , new GiantMace()
                           , new Claymore()
                           , new PaleLeggings()
                           , new Espadon()
                           , new BeardedAxe()
                           , new RockHammer()
                           , new Scimitar()
                           , new Hammer()
                           , new Cleaver()
                           , new GnarledStaff()
                           , new CuirboulliVest()
                           , new CuirboulliBelt()
                           , new CuirboulliBoots()
                           , new CuirboulliBracers()
                           , new CuirboulliGloves()
                           , new CuirboulliPants()
                           , new PaddedBoots()
                           , new PaddedGloves()
                           , new PaddedPants()
                           , new PaddedArmor()
                           , new Jambiya()
                           , new Poniard()
                           , new RussetVest()
                           , new RussetPants()
                           , new RussetBoots()
                           , new RussetGloves()
                           , new EmbroideredArmor()
                           , new EmbroideredPants()
                           , new EmbroideredBoots()
                           , new EmbroideredGloves()
                           , new StuddedDoublet()
                           , new StuddedBelt()
                           , new StuddedPants()
                           , new StuddedBoots()
                           , new StuddedBracers()
                           , new StuddedGloves()
                           , new ReinforcedLeatherVest()
                           , new ReinforcedLeatherBelt()
                           , new ReinforcedLeatherPants()
                           , new ReinforcedLeatherBoots()
                           , new ReinforcedLeatherBracers()
                           , new ReinforcedLeatherGloves()
                           , new PlainRobe()
                           , new DoubleStitchedRobes()
                           , new RobeOfApprenticeship()
                           , new ChromaticRobe()
                           , new ShimmeringSilkRobes()
                           , new BurningRobes()
                           , new SilverDressRobes()
                           , new EmbroideredBelt()
                           , new EmbroideredBracers()
                           , new PaddedBelt()
                           , new PaddedBracers()
                           , new RussetBelt()
                           , new RussetBracers()
                           , new RussetHat()
                           , new StuddedHat()
                           , new EmbroideredHat()
                           , new ReinforcedLeatherCap()
                           , new Cutlass()
                           , new Mace()
                           , new Hatchet()
                           , new QuarterStaff()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7487, InventoryTypes.OneHand, 7, 1, 13, 3, 0, 0, 0 ), new Item( 6593, InventoryTypes.RangeRight, 3, 1, 26, 0, 0, 0, 0 ));
}
}

public class Handor : BaseCreature 
 { 
public  Handor() : base() 
 { 
Model = 1316;
AttackSpeed= 1739;
BoundingRadius = 0.372000f ;
Name = "Handor" ;
Flags1 = 0x08480046 ;
Id = 3316 ; 
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
NpcType = 7 ;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Handor." ;
BaseMana = 0 ;
Sells = new Item[] { new CinderclothLeggings()
                           , new CuirboulliVest()
                           , new CuirboulliBelt()
                           , new CuirboulliBoots()
                           , new CuirboulliBracers()
                           , new CuirboulliGloves()
                           , new CuirboulliPants()
                           , new PaddedBoots()
                           , new PaddedGloves()
                           , new PaddedPants()
                           , new PaddedArmor()
                           , new RussetVest()
                           , new RussetPants()
                           , new RussetBoots()
                           , new RussetGloves()
                           , new EmbroideredArmor()
                           , new EmbroideredPants()
                           , new EmbroideredBoots()
                           , new EmbroideredGloves()
                           , new StuddedDoublet()
                           , new StuddedBelt()
                           , new StuddedPants()
                           , new StuddedBoots()
                           , new StuddedBracers()
                           , new StuddedGloves()
                           , new ReinforcedLeatherVest()
                           , new ReinforcedLeatherBelt()
                           , new ReinforcedLeatherPants()
                           , new ReinforcedLeatherBoots()
                           , new ReinforcedLeatherBracers()
                           , new ReinforcedLeatherGloves()
                           , new EmbroideredBelt()
                           , new EmbroideredBracers()
                           , new PaddedBelt()
                           , new PaddedBracers()
                           , new RussetBelt()
                           , new RussetBracers()
                           , new RussetHat()
                           , new StuddedHat()
                           , new EmbroideredHat()
                           , new ReinforcedLeatherCap()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}

public class Ollanus : BaseCreature 
 { 
public  Ollanus() : base() 
 { 
Model = 1317;
AttackSpeed= 1739;
BoundingRadius = 0.372000f ;
Name = "Ollanus" ;
Flags1 = 0x08480046 ;
Id = 3317 ; 
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
NpcType = 7 ;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Ollanus." ;
BaseMana = 0 ;
Sells = new Item[] { new CommonBrownShirt()
                           , new CommonWhiteShirt()
                           , new ThickClothVest()
                           , new ThickClothPants()
                           , new ThickClothShoes()
                           , new ThickClothGloves()
                           , new WovenVest()
                           , new WovenPants()
                           , new WovenBoots()
                           , new WovenGloves()
                           , new CommonGrayShirt()
                           , new HeavyWeaveBelt()
                           , new HeavyWeaveBracers()
                           , new ThickClothBelt()
                           , new ThickClothBracers()
                           , new WovenBelt()
                           , new WovenBracers()
                           , new HeavyWeaveArmor()
                           , new HeavyWeavePants()
                           , new HeavyWeaveGloves()
                           , new HeavyWeaveShoes()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}

public class Sana : BaseCreature 
 { 
public  Sana() : base() 
 { 
Model = 1319;
AttackSpeed= 1739;
BoundingRadius = 0.236000f ;
Name = "Sana" ;
Flags1 = 0x08480046 ;
Id = 3319 ; 
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
NpcType = 7 ;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Sana." ;
BaseMana = 0 ;
Sells = new Item[] { new BandedBuckler()
                           , new WallShield()
                           , new RoundBuckler()
                           , new BandedBuckler()
                           , new RingedBuckler()
                           , new ChainmailBelt()
                           , new ChainmailBracers()
                           , new ScalemailBracers()
                           , new ScalemailBelt()
                           , new WornHeaterShield()
                           , new RoundBuckler()
                           , new LightChainArmor()
                           , new LightChainBelt()
                           , new LightChainLeggings()
                           , new LightChainBoots()
                           , new LightChainBracers()
                           , new LightChainGloves()
                           , new RingedBuckler()
                           , new LargeMetalShield()
                           , new ScalemailVest()
                           , new ScalemailPants()
                           , new ScalemailBoots()
                           , new ScalemailGloves()
                           , new ChainmailArmor()
                           , new ChainmailPants()
                           , new ChainmailBoots()
                           , new ChainmailGloves()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 1706, InventoryTypes.Shield, 6, 1, 14, 4, 0, 0, 0 ));
}
}

public class Morgum : BaseCreature 
 { 
public  Morgum() : base() 
 { 
Model = 1321;
AttackSpeed= 1739;
BoundingRadius = 0.372000f ;
Name = "Morgum" ;
Flags1 = 0x08480046 ;
Id = 3321 ; 
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
NpcType = 7 ;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Morgum." ;
BaseMana = 0 ;
Sells = new Item[] { new TannedLeatherBelt()
                           , new TannedLeatherBracers()
                           , new CuredLeatherBelt()
                           , new CuredLeatherBracers()
                           , new CuredLeatherArmor()
                           , new CuredLeatherPants()
                           , new BatteredLeatherHarness()
                           , new BatteredLeatherBelt()
                           , new BatteredLeatherPants()
                           , new BatteredLeatherBoots()
                           , new BatteredLeatherBracers()
                           , new BatteredLeatherGloves()
                           , new CuredLeatherBoots()
                           , new CuredLeatherGloves()
                           , new TannedLeatherBoots()
                           , new TannedLeatherGloves()
                           , new TannedLeatherPants()
                           , new TannedLeatherJerkin()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 3879, InventoryTypes.TwoHanded, 5, 2, 17, 1, 0, 0, 0 ));
}
}

public class JahanHawkwing : BaseCreature 
 { 
public  JahanHawkwing() : base() 
 { 
Model = 3872;
AttackSpeed= 2000;
BoundingRadius = 0.974700f ;
Name = "Jahan Hawkwing" ;
Flags1 = 0x08480046 ;
Id = 3483 ; 
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
Level = RandomLevel( 21 );
NpcType = 7 ;
BaseHitPoints = 864 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 4.05f ;
SetDamage ( 22, 29 );
NpcText00 = "Greetings $N, I am Jahan Hawkwing." ;
BaseMana = 0 ;
Sells = new Item[] { new TannedLeatherBelt()
                           , new TannedLeatherBracers()
                           , new ChainmailBelt()
                           , new ChainmailBracers()
                           , new TannedLeatherBoots()
                           , new TannedLeatherGloves()
                           , new TannedLeatherPants()
                           , new TannedLeatherJerkin()
                           , new ChainmailArmor()
                           , new ChainmailPants()
                           , new ChainmailBoots()
                           , new ChainmailGloves()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7433, InventoryTypes.OneHand, 15, 1, 13, 3, 0, 0, 0 ), new Item( 6593, InventoryTypes.RangeRight, 3, 1, 26, 0, 0, 0, 0 ));
}
}

public class Vexspindle : BaseCreature 
 { 
public  Vexspindle() : base() 
 { 
Model = 7094;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Vexspindle" ;
Flags1 = 0x08080006 ;
Id = 3492 ; 
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
NpcType = 7 ;
BaseHitPoints = 1024 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 27, 35 );
NpcText00 = "Greetings $N, I am Vexspindle." ;
BaseMana = 0 ;
Sells = new Item[] { new CuredLeatherBelt()
                           , new CuredLeatherBracers()
                           , new ThickClothVest()
                           , new ThickClothPants()
                           , new ThickClothShoes()
                           , new ThickClothGloves()
                           , new CuredLeatherArmor()
                           , new CuredLeatherPants()
                           , new CuredLeatherBoots()
                           , new CuredLeatherGloves()
                           , new ThickClothBelt()
                           , new ThickClothBracers()
                           , new WolfBracers()
                           , new BearBracers()
                           , new OwlBracers()
  } ;
Faction = Factions.Ratchet;
Guild = "Armorer" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7434, InventoryTypes.OneHand, 15, 1, 13, 3, 0, 0, 0 ), new Item( 6593, InventoryTypes.RangeRight, 3, 1, 26, 0, 0, 0, 0 ));
}
}

public class Grazlix : BaseCreature 
 { 
public  Grazlix() : base() 
 { 
Model = 7095;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Grazlix" ;
Flags1 = 0x08080046 ;
Id = 3493 ; 
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
NpcType = 7 ;
BaseHitPoints = 1024 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 27, 35 );
NpcText00 = "Greetings $N, I am Grazlix." ;
BaseMana = 0 ;
Sells = new Item[] { new RingedBuckler()
                           , new ScalemailBracers()
                           , new ScalemailBelt()
                           , new RingedBuckler()
                           , new LargeMetalShield()
                           , new ScalemailVest()
                           , new ScalemailPants()
                           , new ScalemailBoots()
                           , new FieryCloak()
                           , new HeavyRunedCloak()
                           , new AntiquatedCloak()
                           , new MightyChainPants()
                           , new LegionnairesLeggings()
                           , new GuardianBuckler()
                           , new BearBuckler()
                           , new OwlsDisk()
                           , new ScalemailGloves()
  } ;
Faction = Factions.Ratchet;
Guild = "Armorer" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 8078, InventoryTypes.OneHand, 14, 1, 13, 3, 0, 0, 0 ));
}
}

public class RobertAebischer : BaseCreature 
 { 
public  RobertAebischer() : base() 
 { 
Model = 3698;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Robert Aebischer" ;
Flags1 = 0x08480046 ;
Id = 3543 ; 
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
NpcType = 7 ;
BaseHitPoints = 1625 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 43, 56 );
NpcText00 = "Greetings $N, I am Robert Aebischer." ;
BaseMana = 0 ;
Sells = new Item[] { new ScalemailBracers()
                           , new ScalemailBelt()
                           , new ScalemailVest()
                           , new ScalemailPants()
                           , new ScalemailBoots()
                           , new FieryCloak()
                           , new HeavyRunedCloak()
                           , new AntiquatedCloak()
                           , new MightyChainPants()
                           , new LegionnairesLeggings()
                           , new GloriousShoulders()
                           , new EliteShoulders()
                           , new ScalemailGloves()
  } ;
Faction = Factions.Stormwind;
Guild = "Armorer" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 7439, InventoryTypes.OneHand, 4, 2, 13, 3, 0, 0, 0 ));
}
}

public class AlexandreLefevre : BaseCreature 
 { 
public  AlexandreLefevre() : base() 
 { 
Model = 3544;
AttackSpeed= 2000;
BoundingRadius = 0.383000f ;
Name = "Alexandre Lefevre" ;
Flags1 = 0x08480046 ;
Id = 3552 ; 
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
NpcType = 7 ;
BaseHitPoints = 744 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 19, 25 );
NpcText00 = "Greetings $N, I am Alexandre Lefevre." ;
BaseMana = 0 ;
Sells = new Item[] { new TannedLeatherBelt()
                           , new TannedLeatherBracers()
                           , new AgileBoots()
                           , new StableBoots()
                           , new TannedLeatherBoots()
                           , new TannedLeatherGloves()
                           , new TannedLeatherPants()
                           , new TannedLeatherJerkin()
  } ;
Faction = Factions.Undercity;
Guild = "Armorer" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 7434, InventoryTypes.OneHand, 15, 1, 13, 3, 0, 0, 0 ));
}
}

public class SebastianMeloche : BaseCreature 
 { 
public  SebastianMeloche() : base() 
 { 
Model = 3536;
AttackSpeed= 2000;
BoundingRadius = 0.383000f ;
Name = "Sebastian Meloche" ;
Flags1 = 0x08400046 ;
Id = 3553 ; 
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
NpcType = 6 ;
BaseHitPoints = 744 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 19, 25 );
NpcText00 = "Greetings $N, I am Sebastian Meloche." ;
BaseMana = 0 ;
Sells = new Item[] { new ChainmailBelt()
                           , new ChainmailBracers()
                           , new ChainmailArmor()
                           , new ChainmailPants()
                           , new ChainmailBoots()
                           , new ChainmailGloves()
  } ;
Faction = Factions.Undercity;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 7439, InventoryTypes.OneHand, 4, 2, 13, 3, 0, 0, 0 ));
}
}

public class Sinda : BaseCreature 
 { 
public  Sinda() : base() 
 { 
Model = 1714;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Sinda" ;
Flags1 = 0x08480046 ;
Id = 3612 ; 
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
Level = RandomLevel( 20 );
NpcType = 7 ;
BaseHitPoints = 1424 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 38, 49 );
NpcText00 = "Greetings $N, I am Sinda." ;
BaseMana = 0 ;
Sells = new Item[] { new RoughLeatherBelt()
                           , new RoughLeatherBracers()
                           , new RoughLeatherBoots()
                           , new RoughLeatherGloves()
                           , new RoughLeatherPants()
                           , new RoughLeatherVest()
  } ;
Faction = Factions.Darnasus;
Guild = "Armorer" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}

public class Pizznukle : BaseCreature 
 { 
public  Pizznukle() : base() 
 { 
Model = 7101;
AttackSpeed= 1651;
BoundingRadius = 1.00f ;
Name = "Pizznukle" ;
Flags1 = 0x08000006 ;
Id = 3684 ; 
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
Level = RandomLevel( 33 );
NpcType = 7 ;
BaseHitPoints = 1344 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 11.00f ;
SetDamage ( 36, 46 );
NpcText00 = "Greetings $N, I am Pizznukle." ;
BaseMana = 1653 ;
Sells = new Item[] { new TannedLeatherBelt()
                           , new TannedLeatherBracers()
                           , new AgileBoots()
                           , new StableBoots()
                           , new TannedLeatherBoots()
                           , new TannedLeatherGloves()
                           , new TannedLeatherPants()
                           , new TannedLeatherJerkin()
  } ;
Faction = Factions.Friend;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}

public class TandaanLightmane : BaseCreature 
 { 
public  TandaanLightmane() : base() 
 { 
Model = 2064;
AttackSpeed= 2000;
BoundingRadius = 0.389000f ;
Name = "Tandaan Lightmane" ;
Flags1 = 0x08480046 ;
Id = 3953 ; 
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
Level = RandomLevel( 23 );
NpcType = 7 ;
BaseHitPoints = 944 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 25, 32 );
NpcText00 = "Greetings $N, I am Tandaan Lightmane." ;
BaseMana = 0 ;
Sells = new Item[] { new RoughLeatherBelt()
                           , new RoughLeatherBracers()
                           , new TannedLeatherBelt()
                           , new TannedLeatherBracers()
                           , new CuredLeatherBelt()
                           , new CuredLeatherBracers()
                           , new CuirboulliVest()
                           , new CuirboulliBelt()
                           , new CuirboulliBoots()
                           , new CuirboulliBracers()
                           , new CuirboulliGloves()
                           , new CuirboulliPants()
                           , new CuredLeatherArmor()
                           , new CuredLeatherPants()
                           , new CuredLeatherBoots()
                           , new CuredLeatherGloves()
                           , new RoughLeatherBoots()
                           , new RoughLeatherGloves()
                           , new RoughLeatherPants()
                           , new RoughLeatherVest()
                           , new TannedLeatherBoots()
                           , new TannedLeatherGloves()
                           , new TannedLeatherPants()
                           , new TannedLeatherJerkin()
  } ;
Faction = Factions.Darnasus;
Guild = "Armorer" ;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}

public class Nizzik : BaseCreature 
 { 
public  Nizzik() : base() 
 { 
Model = 7158;
AttackSpeed= 1777;
BoundingRadius = 1.00f ;
Name = "Nizzik" ;
Flags1 = 0x080066 ;
Id = 4085 ; 
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
NpcType = 7 ;
BaseHitPoints = 984 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 26, 33 );
NpcText00 = "Greetings $N, I am Nizzik." ;
BaseMana = 1203 ;
Sells = new Item[] { new PolishedScaleBelt()
                           , new PolishedScaleBoots()
                           , new PolishedScaleBracers()
                           , new PolishedScaleGloves()
                           , new PolishedScaleLeggings()
                           , new PolishedScaleVest()
                           , new WizardsBelt()
                           , new NightwindBelt()
                           , new DreamersBelt()
                           , new SaberLeggings()
                           , new StalkingPants()
                           , new MysticSarong()
                           , new GloriousShoulders()
                           , new EliteShoulders()
  } ;
Faction = Factions.Monster;
AIEngine = new StandingNpcAI( this ); 
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 23319 , InventoryTypes.OneHand, 14, 1, 13, 0, 0, 0, 0 ), new Item( 6537 , InventoryTypes.HeldInHand, 0, 1, 23, 7, 0, 0, 0 ));
}
}

public class Cylania : BaseCreature 
 { 
public  Cylania() : base() 
 { 
Model = 2199;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Cylania" ;
Flags1 = 0x08480006 ;
Id = 4164 ; 
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
NpcType = 7 ;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Cylania." ;
BaseMana = 0 ;
Sells = new Item[] { new RoughLeatherBelt()
                           , new RoughLeatherBracers()
                           , new TannedLeatherBelt()
                           , new TannedLeatherBracers()
                           , new ChainmailBelt()
                           , new ChainmailBracers()
                           , new LightMailArmor()
                           , new LightMailBelt()
                           , new LightMailLeggings()
                           , new LightMailBoots()
                           , new LightMailBracers()
                           , new LightMailGloves()
                           , new HeavyWeaveBelt()
                           , new HeavyWeaveBracers()
                           , new KnittedBelt()
                           , new KnittedBracers()
                           , new KnittedSandals()
                           , new KnittedGloves()
                           , new KnittedPants()
                           , new KnittedTunic()
                           , new RoughLeatherBoots()
                           , new RoughLeatherGloves()
                           , new RoughLeatherPants()
                           , new RoughLeatherVest()
                           , new HeavyWeaveArmor()
                           , new HeavyWeavePants()
                           , new HeavyWeaveGloves()
                           , new HeavyWeaveShoes()
                           , new TannedLeatherBoots()
                           , new TannedLeatherGloves()
                           , new TannedLeatherPants()
                           , new TannedLeatherJerkin()
                           , new ChainmailArmor()
                           , new ChainmailPants()
                           , new ChainmailBoots()
                           , new ChainmailGloves()
  } ;
Faction = Factions.Darnasus;
Guild = "Armorer" ;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}

public class Vinasia : BaseCreature 
 { 
public  Vinasia() : base() 
 { 
Model = 2224;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Vinasia" ;
Flags1 = 0x08480046 ;
Id = 4175 ; 
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
NpcType = 7 ;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Vinasia." ;
BaseMana = 0 ;
Sells = new Item[] { new CinderclothLeggings()
                           , new ThickClothVest()
                           , new ThickClothPants()
                           , new ThickClothShoes()
                           , new ThickClothGloves()
                           , new ThinClothShoes()
                           , new ThinClothGloves()
                           , new ThinClothPants()
                           , new ThinClothArmor()
                           , new PaddedBoots()
                           , new PaddedGloves()
                           , new PaddedPants()
                           , new PaddedArmor()
                           , new RussetVest()
                           , new RussetPants()
                           , new RussetBoots()
                           , new RussetGloves()
                           , new EmbroideredArmor()
                           , new EmbroideredPants()
                           , new EmbroideredBoots()
                           , new EmbroideredGloves()
                           , new EmbroideredBelt()
                           , new EmbroideredBracers()
                           , new HeavyWeaveBelt()
                           , new HeavyWeaveBracers()
                           , new PaddedBelt()
                           , new PaddedBracers()
                           , new RussetBelt()
                           , new RussetBracers()
                           , new ThickClothBelt()
                           , new ThickClothBracers()
                           , new ThinClothBelt()
                           , new ThinClothBracers()
                           , new KnittedBelt()
                           , new KnittedBracers()
                           , new RussetHat()
                           , new EmbroideredHat()
                           , new KnittedSandals()
                           , new KnittedGloves()
                           , new KnittedPants()
                           , new KnittedTunic()
                           , new HeavyWeaveArmor()
                           , new HeavyWeavePants()
                           , new HeavyWeaveGloves()
                           , new HeavyWeaveShoes()
  } ;
Faction = Factions.Darnasus;
Guild = "Armorer" ;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 23574, InventoryTypes.OneHand, 7, 1, 13, 3, 0, 0, 0 ), new Item( 23574, InventoryTypes.OneHand, 7, 1, 13, 3, 0, 0, 0 ));
}
}

public class Melea : BaseCreature 
 { 
public  Melea() : base() 
 { 
Model = 2226;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Melea" ;
Flags1 = 0x08480046 ;
Id = 4177 ; 
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
NpcType = 7 ;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Melea." ;
BaseMana = 0 ;
Sells = new Item[] { new MetalBuckler()
                           , new OrnateBuckler()
                           , new ChainmailBelt()
                           , new ChainmailBracers()
                           , new ScalemailBracers()
                           , new ScalemailBelt()
                           , new PolishedScaleBelt()
                           , new PolishedScaleBoots()
                           , new PolishedScaleBracers()
                           , new PolishedScaleGloves()
                           , new PolishedScaleLeggings()
                           , new PolishedScaleVest()
                           , new TarnishedChainVest()
                           , new TarnishedChainBelt()
                           , new TarnishedChainLeggings()
                           , new TarnishedChainBoots()
                           , new TarnishedChainBracers()
                           , new TarnishedChainGloves()
                           , new LightMailArmor()
                           , new LightMailBelt()
                           , new LightMailLeggings()
                           , new LightMailBoots()
                           , new LightMailBracers()
                           , new LightMailGloves()
                           , new AugmentedChainVest()
                           , new AugmentedChainLeggings()
                           , new AugmentedChainBelt()
                           , new AugmentedChainBoots()
                           , new AugmentedChainBracers()
                           , new AugmentedChainGloves()
                           , new BrigandineVest()
                           , new BrigandineBelt()
                           , new BrigandineLeggings()
                           , new BrigandineBoots()
                           , new BrigandineBracers()
                           , new BrigandineGloves()
                           , new MetalBuckler()
                           , new OrnateBuckler()
                           , new HeavyPavise()
                           , new CrestedHeaterShield()
                           , new ScalemailVest()
                           , new ScalemailPants()
                           , new ScalemailBoots()
                           , new AugmentedChainHelm()
                           , new BrigandineHelm()
                           , new ScalemailGloves()
                           , new PlatemailBelt()
                           , new PlatemailBoots()
                           , new PlatemailBracers()
                           , new PlatemailGloves()
                           , new PlatemailHelm()
                           , new PlatemailLeggings()
                           , new PlatemailArmor()
                           , new ChainmailArmor()
                           , new ChainmailPants()
                           , new ChainmailBoots()
                           , new ChainmailGloves()
  } ;
Faction = Factions.Darnasus;
Guild = "Armorer" ;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}


public class HarlonThornguard : BaseCreature 
 { 
public  HarlonThornguard() : base() 
 { 
Model = 4407;
AttackSpeed= 2000;
BoundingRadius = 0.389000f ;
Name = "Harlon Thornguard" ;
Flags1 = 0x08480046 ;
Id = 4187 ; 
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
NpcType = 7 ;
BaseHitPoints = 1024 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 27, 35 );
NpcText00 = "Greetings $N, I am Harlon Thornguard." ;
BaseMana = 0 ;
Sells = new Item[] { new BandedBuckler()
                           , new WallShield()
                           , new BandedBuckler()
                           , new ChainmailBelt()
                           , new ChainmailBracers()
                           , new ChainmailArmor()
                           , new ChainmailPants()
                           , new ChainmailBoots()
                           , new ChainmailGloves()
  } ;
Faction = Factions.Darnasus;
Guild = "Armorer" ;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}

public class Illyanie : BaseCreature 
 { 
public  Illyanie() : base() 
 { 
Model = 13189;
AttackSpeed= 1764;
BoundingRadius = 1.00f ;
Name = "Illyanie" ;
Flags1 = 0x08C00046 ;
Id = 4188 ; 
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
NpcType = 7 ;
BaseHitPoints = 1024 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 27, 35 );
NpcText00 = "Greetings $N, I am Illyanie." ;
BaseMana = 1253 ;
Sells = new Item[] { new ThickClothVest()
                           , new ThickClothPants()
                           , new ThickClothShoes()
                           , new ThickClothGloves()
                           , new PaddedBoots()
                           , new PaddedGloves()
                           , new PaddedPants()
                           , new PaddedArmor()
                           , new PaddedBelt()
                           , new PaddedBracers()
                           , new ThickClothBelt()
                           , new ThickClothBracers()
  } ;
Faction = Factions.Darnasus;
Guild = "Armorer" ;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 23318, InventoryTypes.OneHand, 14, 1, 13, 3, 0, 0, 0 ));
}
}

public class Cyridan : BaseCreature 
 { 
public  Cyridan() : base() 
 { 
Model = 2246;
AttackSpeed= 2000;
BoundingRadius = 0.389000f ;
Name = "Cyridan" ;
Flags1 = 0x08480046 ;
Id = 4236 ; 
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
NpcType = 7 ;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Cyridan." ;
BaseMana = 0 ;
Sells = new Item[] { new RoughLeatherBelt()
                           , new RoughLeatherBracers()
                           , new TannedLeatherBelt()
                           , new TannedLeatherBracers()
                           , new CuredLeatherBelt()
                           , new CuredLeatherBracers()
                           , new CrackedLeatherBelt()
                           , new CrackedLeatherBoots()
                           , new CrackedLeatherBracers()
                           , new CrackedLeatherGloves()
                           , new CrackedLeatherPants()
                           , new CrackedLeatherVest()
                           , new CuirboulliVest()
                           , new CuirboulliBelt()
                           , new CuirboulliBoots()
                           , new CuirboulliBracers()
                           , new CuirboulliGloves()
                           , new CuirboulliPants()
                           , new CuredLeatherArmor()
                           , new CuredLeatherPants()
                           , new CuredLeatherBoots()
                           , new CuredLeatherGloves()
                           , new StuddedDoublet()
                           , new StuddedBelt()
                           , new StuddedPants()
                           , new StuddedBoots()
                           , new StuddedBracers()
                           , new StuddedGloves()
                           , new ReinforcedLeatherVest()
                           , new ReinforcedLeatherBelt()
                           , new ReinforcedLeatherPants()
                           , new ReinforcedLeatherBoots()
                           , new ReinforcedLeatherBracers()
                           , new ReinforcedLeatherGloves()
                           , new StuddedHat()
                           , new ReinforcedLeatherCap()
                           , new RoughLeatherBoots()
                           , new RoughLeatherGloves()
                           , new RoughLeatherPants()
                           , new RoughLeatherVest()
                           , new TannedLeatherBoots()
                           , new TannedLeatherGloves()
                           , new TannedLeatherPants()
                           , new TannedLeatherJerkin()
  } ;
Faction = Factions.Darnasus;
Guild = "Armorer" ;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7443, InventoryTypes.OneHand, 4, 2, 13, 7, 0, 0, 0 ));
}
}

public class LaurenNewcomb : BaseCreature 
 { 
public  LaurenNewcomb() : base() 
 { 
Model = 2666;
AttackSpeed= 2000;
BoundingRadius = 0.383000f ;
Name = "Lauren Newcomb" ;
Flags1 = 0x018480046 ;
Id = 4558 ; 
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
NpcType = 7 ;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Lauren Newcomb." ;
BaseMana = 0 ;
Sells = new Item[] { new CommonBrownShirt()
                           , new CommonWhiteShirt()
                           , new DirtyLeatherBelt()
                           , new DirtyLeatherBracers()
                           , new TannedLeatherBelt()
                           , new TannedLeatherBracers()
                           , new TatteredClothVest()
                           , new TatteredClothPants()
                           , new TatteredClothBoots()
                           , new DirtyLeatherPants()
                           , new DirtyLeatherBoots()
                           , new WovenVest()
                           , new WovenPants()
                           , new WovenBoots()
                           , new WovenGloves()
                           , new BatteredLeatherHarness()
                           , new BatteredLeatherBelt()
                           , new BatteredLeatherPants()
                           , new BatteredLeatherBoots()
                           , new BatteredLeatherBracers()
                           , new BatteredLeatherGloves()
                           , new CommonGrayShirt()
                           , new HeavyWeaveBelt()
                           , new HeavyWeaveBracers()
                           , new TatteredClothBelt()
                           , new TatteredClothBracers()
                           , new WovenBelt()
                           , new WovenBracers()
                           , new TatteredClothGloves()
                           , new DirtyLeatherGloves()
                           , new HeavyWeaveArmor()
                           , new HeavyWeavePants()
                           , new HeavyWeaveGloves()
                           , new HeavyWeaveShoes()
                           , new TannedLeatherBoots()
                           , new TannedLeatherGloves()
                           , new TannedLeatherPants()
                           , new TannedLeatherJerkin()
                           , new DirtyLeatherVest()
  } ;
Faction = Factions.Undercity;
Guild = "Armorer" ;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7434, InventoryTypes.OneHand, 15, 1, 13, 3, 0, 0, 0 ));
}
}

public class TimothyWeldon : BaseCreature 
 { 
public  TimothyWeldon() : base() 
 { 
Model = 2653;
AttackSpeed= 2000;
BoundingRadius = 0.383000f ;
Name = "Timothy Weldon" ;
Flags1 = 0x018480046 ;
Id = 4559 ; 
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
NpcType = 6 ;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Timothy Weldon." ;
BaseMana = 0 ;
Sells = new Item[] { new DentedBuckler()
                           , new BandedBuckler()
                           , new LargeWoodenShield()
                           , new WallShield()
                           , new DentedBuckler()
                           , new RoundBuckler()
                           , new BandedBuckler()
                           , new WornHeaterShield()
                           , new RoundBuckler()
                           , new RustedChainVest()
                           , new RustedChainBelt()
                           , new RustedChainLeggings()
                           , new RustedChainBoots()
                           , new RustedChainBracers()
                           , new RustedChainGloves()
                           , new LightChainArmor()
                           , new LightChainBelt()
                           , new LightChainLeggings()
                           , new LightChainBoots()
                           , new LightChainBracers()
                           , new LightChainGloves()
  } ;
Faction = Factions.Undercity;
Guild = "Armorer" ;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 6434, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
}
}

public class WalterEllingson : BaseCreature 
 { 
public  WalterEllingson() : base() 
 { 
Model = 2654;
AttackSpeed= 2000;
BoundingRadius = 0.383000f ;
Name = "Walter Ellingson" ;
Flags1 = 0x018480046 ;
Id = 4560 ; 
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
NpcType = 7 ;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Walter Ellingson." ;
BaseMana = 0 ;
Sells = new Item[] { new BandedBuckler()
                           , new WallShield()
                           , new BandedBuckler()
                           , new ChainmailBelt()
                           , new ChainmailBracers()
                           , new ChainmailArmor()
                           , new ChainmailPants()
                           , new ChainmailBoots()
                           , new ChainmailGloves()
  } ;
Faction = Factions.Undercity;
Guild = "Armorer" ;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 1926, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
}
}

public class Krak : BaseCreature 
 { 
public  Krak() : base() 
 { 
Model = 10704;
AttackSpeed= 2000;
BoundingRadius = 1.294850f ;
Name = "Krak" ;
Flags1 = 0x08400046 ;
Id = 4883 ; 
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
NpcType = 7 ;
BaseHitPoints = 1745 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 2.175f ;
SetDamage ( 47, 60 );
NpcText00 = "Greetings $N, I am Krak." ;
BaseMana = 0 ;
Sells = new Item[] { new PolishedScaleBelt()
                           , new PolishedScaleBoots()
                           , new PolishedScaleBracers()
                           , new PolishedScaleGloves()
                           , new PolishedScaleLeggings()
                           , new PolishedScaleVest()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
}
}

public class HansWeston : BaseCreature 
 { 
public  HansWeston() : base() 
 { 
Model = 11038;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Hans Weston" ;
Flags1 = 0x08480046 ;
Id = 4886 ; 
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
Level = RandomLevel( 37 );
NpcType = 7 ;
BaseHitPoints = 1504 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 40, 52 );
NpcText00 = "Greetings $N, I am Hans Weston." ;
BaseMana = 0 ;
Sells = new Item[] { new ReinforcedTarge()
                           , new PolishedScaleBelt()
                           , new PolishedScaleBoots()
                           , new PolishedScaleBracers()
                           , new PolishedScaleGloves()
                           , new PolishedScaleLeggings()
                           , new PolishedScaleVest()
                           , new ReinforcedTarge()
                           , new KiteShield()
  } ;
Faction = Factions.Stormwind;
Guild = "Armorer" ;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 7439, InventoryTypes.OneHand, 4, 2, 13, 3, 0, 0, 0 ));
}
}

public class BromiirOrmsen : BaseCreature 
 { 
public  BromiirOrmsen() : base() 
 { 
Model = 3044;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Bromiir Ormsen" ;
Flags1 = 0x08480046 ;
Id = 5106 ; 
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
NpcType = 7 ;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Bromiir Ormsen." ;
BaseMana = 0 ;
Sells = new Item[] { new SmallTarge()
                           , new DullHeaterShield()
                           , new SmallTarge()
                           , new LightMailArmor()
                           , new LightMailBelt()
                           , new LightMailLeggings()
                           , new LightMailBoots()
                           , new LightMailBracers()
                           , new LightMailGloves()
  } ;
Faction = Factions.IronForge;
Guild = "Armorer" ;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 1706, InventoryTypes.Shield, 6, 1, 14, 4, 0, 0, 0 ));
}
}

public class RaenaFlinthammer : BaseCreature 
 { 
public  RaenaFlinthammer() : base() 
 { 
Model = 3049;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Raena Flinthammer" ;
Flags1 = 0x08480046 ;
Id = 5108 ; 
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
NpcType = 7 ;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Raena Flinthammer." ;
BaseMana = 0 ;
Sells = new Item[] { new CommonBrownShirt()
                           , new CommonWhiteShirt()
                           , new TannedLeatherBelt()
                           , new TannedLeatherBracers()
                           , new CommonGrayShirt()
                           , new HeavyWeaveBelt()
                           , new HeavyWeaveBracers()
                           , new HeavyWeaveArmor()
                           , new HeavyWeavePants()
                           , new HeavyWeaveGloves()
                           , new HeavyWeaveShoes()
                           , new TannedLeatherBoots()
                           , new TannedLeatherGloves()
                           , new TannedLeatherPants()
                           , new TannedLeatherJerkin()
  } ;
Faction = Factions.IronForge;
Guild = "Armorer" ;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}

public class DolkinCraghelm : BaseCreature 
 { 
public  DolkinCraghelm() : base() 
 { 
Model = 3079;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Dolkin Craghelm" ;
Flags1 = 0x08480046 ;
Id = 5125 ; 
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
NpcType = 7 ;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Dolkin Craghelm." ;
BaseMana = 0 ;
Sells = new Item[] { new MetalBuckler()
                           , new ScalemailBracers()
                           , new ScalemailBelt()
                           , new PolishedScaleBelt()
                           , new PolishedScaleBoots()
                           , new PolishedScaleBracers()
                           , new PolishedScaleGloves()
                           , new PolishedScaleLeggings()
                           , new PolishedScaleVest()
                           , new AugmentedChainVest()
                           , new AugmentedChainLeggings()
                           , new AugmentedChainBelt()
                           , new AugmentedChainBoots()
                           , new AugmentedChainBracers()
                           , new AugmentedChainGloves()
                           , new MetalBuckler()
                           , new HeavyPavise()
                           , new ScalemailVest()
                           , new ScalemailPants()
                           , new ScalemailBoots()
                           , new AugmentedChainHelm()
                           , new ScalemailGloves()
  } ;
Faction = Factions.IronForge;
Guild = "Armorer" ;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7446, InventoryTypes.OneHand, 14, 1, 13, 7, 0, 0, 0 ), new Item( 6535, InventoryTypes.HeldInHand, 0, 2, 23, 0, 0, 0, 0 ));
}
}

public class OlthranCraghelm : BaseCreature 
 { 
public  OlthranCraghelm() : base() 
 { 
Model = 3080;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Olthran Craghelm" ;
Flags1 = 0x08480046 ;
Id = 5126 ; 
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
NpcType = 7 ;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Olthran Craghelm." ;
BaseMana = 0 ;
Sells = new Item[] { new RingedBuckler()
                           , new MetalBuckler()
                           , new OrnateBuckler()
                           , new ReinforcedTarge()
                           , new BrigandineVest()
                           , new BrigandineBelt()
                           , new BrigandineLeggings()
                           , new BrigandineBoots()
                           , new BrigandineBracers()
                           , new BrigandineGloves()
                           , new RingedBuckler()
                           , new ReinforcedTarge()
                           , new MetalBuckler()
                           , new OrnateBuckler()
                           , new LargeMetalShield()
                           , new KiteShield()
                           , new HeavyPavise()
                           , new CrestedHeaterShield()
                           , new BrigandineHelm()
                           , new PlatemailBelt()
                           , new PlatemailBoots()
                           , new PlatemailBracers()
                           , new PlatemailGloves()
                           , new PlatemailHelm()
                           , new PlatemailLeggings()
                           , new PlatemailArmor()
  } ;
Faction = Factions.IronForge;
Guild = "Armorer" ;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7447, InventoryTypes.OneHand, 4, 2, 13, 3, 0, 0, 0 ), new Item( 20537, InventoryTypes.Shield, 6, 1, 14, 4, 0, 0, 0 ), new Item( 6593, InventoryTypes.RangeRight, 3, 1, 26, 0, 0, 0, 0 ));
}
}

public class LissyphusFinespindle : BaseCreature 
 { 
public  LissyphusFinespindle() : base() 
 { 
Model = 3106;
AttackSpeed= 2000;
BoundingRadius = 0.351900f ;
Name = "Lissyphus Finespindle" ;
Flags1 = 0x08480046 ;
Id = 5129 ; 
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
NpcType = 7 ;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.725f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Lissyphus Finespindle." ;
BaseMana = 0 ;
Sells = new Item[] { new EmbroideredArmor()
                           , new EmbroideredPants()
                           , new EmbroideredBoots()
                           , new EmbroideredGloves()
                           , new StuddedDoublet()
                           , new StuddedBelt()
                           , new StuddedPants()
                           , new StuddedBoots()
                           , new StuddedBracers()
                           , new StuddedGloves()
                           , new ReinforcedLeatherVest()
                           , new ReinforcedLeatherBelt()
                           , new ReinforcedLeatherPants()
                           , new ReinforcedLeatherBoots()
                           , new ReinforcedLeatherBracers()
                           , new ReinforcedLeatherGloves()
                           , new EmbroideredBelt()
                           , new EmbroideredBracers()
                           , new StuddedHat()
                           , new EmbroideredHat()
                           , new ReinforcedLeatherCap()
  } ;
Faction = Factions.IronForge;
Guild = "Armorer" ;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}

public class IngrysStonebrow : BaseCreature 
 { 
public  IngrysStonebrow() : base() 
 { 
Model = 3070;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Ingrys Stonebrow" ;
Flags1 = 0x08480046 ;
Id = 5155 ; 
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
NpcType = 7 ;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Ingrys Stonebrow." ;
BaseMana = 0 ;
Sells = new Item[] { new ThickClothVest()
                           , new ThickClothPants()
                           , new ThickClothShoes()
                           , new ThickClothGloves()
                           , new RussetVest()
                           , new RussetPants()
                           , new RussetBoots()
                           , new RussetGloves()
                           , new EmbroideredArmor()
                           , new EmbroideredPants()
                           , new EmbroideredBoots()
                           , new EmbroideredGloves()
                           , new EmbroideredBelt()
                           , new EmbroideredBracers()
                           , new RussetBelt()
                           , new RussetBracers()
                           , new ThickClothBelt()
                           , new ThickClothBracers()
                           , new RussetHat()
                           , new EmbroideredHat()
  } ;
Faction = Factions.IronForge;
Guild = "Armorer" ;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 24596, InventoryTypes.OneHand, 14, 1, 13, 7, 0, 0, 0 ));
}
}

public class StrumnerFlintheel : BaseCreature 
 { 
public  StrumnerFlintheel() : base() 
 { 
Model = 3304;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Strumner Flintheel" ;
Flags1 = 0x08480046 ;
Id = 5508 ; 
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
NpcType = 7 ;
BaseHitPoints = 1625 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 43, 56 );
NpcText00 = "Greetings $N, I am Strumner Flintheel." ;
BaseMana = 0 ;
Sells = new Item[] { new OrnateBuckler()
                           , new BrigandineVest()
                           , new BrigandineBelt()
                           , new BrigandineLeggings()
                           , new BrigandineBoots()
                           , new BrigandineBracers()
                           , new BrigandineGloves()
                           , new CrestedHeaterShield()
                           , new BrigandineHelm()
                           , new PlatemailBelt()
                           , new PlatemailBoots()
                           , new PlatemailBracers()
                           , new PlatemailGloves()
                           , new PlatemailHelm()
                           , new PlatemailLeggings()
                           , new PlatemailArmor()
  } ;
Faction = Factions.Stormwind;
Guild = "Armorer" ;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 7442, InventoryTypes.OneHand, 4, 2, 13, 3, 0, 0, 0 ));
}
}

public class Tumi : BaseCreature 
 { 
public  Tumi() : base() 
 { 
Model = 4351;
AttackSpeed= 1739;
BoundingRadius = 0.236000f ;
Name = "Tumi" ;
Flags1 = 0x08480046 ;
Id = 5812 ; 
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
NpcType = 7 ;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Tumi." ;
BaseMana = 0 ;
Sells = new Item[] { new MetalBuckler()
                           , new OrnateBuckler()
                           , new ReinforcedTarge()
                           , new ChainmailBelt()
                           , new ChainmailBracers()
                           , new ScalemailBracers()
                           , new ScalemailBelt()
                           , new PolishedScaleBelt()
                           , new PolishedScaleBoots()
                           , new PolishedScaleBracers()
                           , new PolishedScaleGloves()
                           , new PolishedScaleLeggings()
                           , new PolishedScaleVest()
                           , new LightMailArmor()
                           , new LightMailBelt()
                           , new LightMailLeggings()
                           , new LightMailBoots()
                           , new LightMailBracers()
                           , new LightMailGloves()
                           , new AugmentedChainVest()
                           , new AugmentedChainLeggings()
                           , new AugmentedChainBelt()
                           , new AugmentedChainBoots()
                           , new AugmentedChainBracers()
                           , new AugmentedChainGloves()
                           , new BrigandineVest()
                           , new BrigandineBelt()
                           , new BrigandineLeggings()
                           , new BrigandineBoots()
                           , new BrigandineBracers()
                           , new BrigandineGloves()
                           , new ReinforcedTarge()
                           , new MetalBuckler()
                           , new OrnateBuckler()
                           , new KiteShield()
                           , new HeavyPavise()
                           , new CrestedHeaterShield()
                           , new ScalemailVest()
                           , new ScalemailPants()
                           , new ScalemailBoots()
                           , new AugmentedChainHelm()
                           , new BrigandineHelm()
                           , new ScalemailGloves()
                           , new PlatemailBelt()
                           , new PlatemailBoots()
                           , new PlatemailBracers()
                           , new PlatemailGloves()
                           , new PlatemailHelm()
                           , new PlatemailLeggings()
                           , new PlatemailArmor()
                           , new ChainmailArmor()
                           , new ChainmailPants()
                           , new ChainmailBoots()
                           , new ChainmailGloves()
  } ;
Faction = Factions.Ogrimmar;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7439, InventoryTypes.OneHand, 4, 2, 13, 3, 0, 0, 0 ));
}
}

public class MirelleTremayne : BaseCreature 
 { 
public  MirelleTremayne() : base() 
 { 
Model = 4378;
AttackSpeed= 2000;
BoundingRadius = 0.383000f ;
Name = "Mirelle Tremayne" ;
Flags1 = 0x018480046 ;
Id = 5819 ; 
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
NpcType = 7 ;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Mirelle Tremayne." ;
BaseMana = 0 ;
Sells = new Item[] { new MetalBuckler()
                           , new OrnateBuckler()
                           , new ReinforcedTarge()
                           , new ChainmailBelt()
                           , new ChainmailBracers()
                           , new ScalemailBracers()
                           , new ScalemailBelt()
                           , new PolishedScaleBelt()
                           , new PolishedScaleBoots()
                           , new PolishedScaleBracers()
                           , new PolishedScaleGloves()
                           , new PolishedScaleLeggings()
                           , new PolishedScaleVest()
                           , new LightMailArmor()
                           , new LightMailBelt()
                           , new LightMailLeggings()
                           , new LightMailBoots()
                           , new LightMailBracers()
                           , new LightMailGloves()
                           , new AugmentedChainVest()
                           , new AugmentedChainLeggings()
                           , new AugmentedChainBelt()
                           , new AugmentedChainBoots()
                           , new AugmentedChainBracers()
                           , new AugmentedChainGloves()
                           , new BrigandineVest()
                           , new BrigandineBelt()
                           , new BrigandineLeggings()
                           , new BrigandineBoots()
                           , new BrigandineBracers()
                           , new BrigandineGloves()
                           , new ReinforcedTarge()
                           , new MetalBuckler()
                           , new OrnateBuckler()
                           , new KiteShield()
                           , new HeavyPavise()
                           , new CrestedHeaterShield()
                           , new ScalemailVest()
                           , new ScalemailPants()
                           , new ScalemailBoots()
                           , new AugmentedChainHelm()
                           , new BrigandineHelm()
                           , new ScalemailGloves()
                           , new PlatemailBelt()
                           , new PlatemailBoots()
                           , new PlatemailBracers()
                           , new PlatemailGloves()
                           , new PlatemailHelm()
                           , new PlatemailLeggings()
                           , new PlatemailArmor()
                           , new ChainmailArmor()
                           , new ChainmailPants()
                           , new ChainmailBoots()
                           , new ChainmailGloves()
  } ;
Faction = Factions.Undercity;
Guild = "Armorer" ;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7439, InventoryTypes.OneHand, 4, 2, 13, 3, 0, 0, 0 ));
}
}

public class GillianMoore : BaseCreature 
 { 
public  GillianMoore() : base() 
 { 
Model = 4379;
AttackSpeed= 2000;
BoundingRadius = 0.383000f ;
Name = "Gillian Moore" ;
Flags1 = 0x018480046 ;
Id = 5820 ; 
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
NpcType = 7 ;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Gillian Moore." ;
BaseMana = 0 ;
Sells = new Item[] { new RoughLeatherBelt()
                           , new RoughLeatherBracers()
                           , new TannedLeatherBelt()
                           , new TannedLeatherBracers()
                           , new CuredLeatherBelt()
                           , new CuredLeatherBracers()
                           , new CuirboulliVest()
                           , new CuirboulliBelt()
                           , new CuirboulliBoots()
                           , new CuirboulliBracers()
                           , new CuirboulliGloves()
                           , new CuirboulliPants()
                           , new CuredLeatherArmor()
                           , new CuredLeatherPants()
                           , new CuredLeatherBoots()
                           , new CuredLeatherGloves()
                           , new StuddedDoublet()
                           , new StuddedBelt()
                           , new StuddedPants()
                           , new StuddedBoots()
                           , new StuddedBracers()
                           , new StuddedGloves()
                           , new ReinforcedLeatherVest()
                           , new ReinforcedLeatherBelt()
                           , new ReinforcedLeatherPants()
                           , new ReinforcedLeatherBoots()
                           , new ReinforcedLeatherBracers()
                           , new ReinforcedLeatherGloves()
                           , new StuddedHat()
                           , new ReinforcedLeatherCap()
                           , new RoughLeatherBoots()
                           , new RoughLeatherGloves()
                           , new RoughLeatherPants()
                           , new RoughLeatherVest()
                           , new TannedLeatherBoots()
                           , new TannedLeatherGloves()
                           , new TannedLeatherPants()
                           , new TannedLeatherJerkin()
  } ;
Faction = Factions.Undercity;
Guild = "Armorer" ;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 11289, InventoryTypes.OneHand, 4, 2, 13, 3, 0, 0, 0 ));
}
}

public class SheldonVonCroy : BaseCreature 
 { 
public  SheldonVonCroy() : base() 
 { 
Model = 4381;
AttackSpeed= 2000;
BoundingRadius = 0.383000f ;
Name = "Sheldon Von Croy" ;
Flags1 = 0x018480046 ;
Id = 5821 ; 
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
NpcType = 7 ;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Sheldon Von Croy." ;
BaseMana = 0 ;
Sells = new Item[] { new BlueWeddingHanbok()
                           , new WhiteTraditionalHanbok()
                           , new RoyalDangui()
                           , new ThickClothVest()
                           , new ThickClothPants()
                           , new ThickClothShoes()
                           , new ThickClothGloves()
                           , new CuirboulliVest()
                           , new CuirboulliBelt()
                           , new CuirboulliBoots()
                           , new CuirboulliBracers()
                           , new CuirboulliGloves()
                           , new CuirboulliPants()
                           , new PaddedBoots()
                           , new PaddedGloves()
                           , new PaddedPants()
                           , new PaddedArmor()
                           , new RussetVest()
                           , new RussetPants()
                           , new RussetBoots()
                           , new RussetGloves()
                           , new EmbroideredArmor()
                           , new EmbroideredPants()
                           , new EmbroideredBoots()
                           , new EmbroideredGloves()
                           , new StuddedDoublet()
                           , new StuddedBelt()
                           , new StuddedPants()
                           , new StuddedBoots()
                           , new StuddedBracers()
                           , new StuddedGloves()
                           , new ReinforcedLeatherVest()
                           , new ReinforcedLeatherBelt()
                           , new ReinforcedLeatherPants()
                           , new ReinforcedLeatherBoots()
                           , new ReinforcedLeatherBracers()
                           , new ReinforcedLeatherGloves()
                           , new EmbroideredBelt()
                           , new EmbroideredBracers()
                           , new HeavyWeaveBelt()
                           , new HeavyWeaveBracers()
                           , new PaddedBelt()
                           , new PaddedBracers()
                           , new RussetBelt()
                           , new RussetBracers()
                           , new ThickClothBelt()
                           , new ThickClothBracers()
                           , new KnittedBelt()
                           , new KnittedBracers()
                           , new RussetHat()
                           , new StuddedHat()
                           , new EmbroideredHat()
                           , new ReinforcedLeatherCap()
                           , new KnittedSandals()
                           , new KnittedGloves()
                           , new KnittedPants()
                           , new KnittedTunic()
                           , new HeavyWeaveArmor()
                           , new HeavyWeavePants()
                           , new HeavyWeaveGloves()
                           , new HeavyWeaveShoes()
  } ;
Faction = Factions.Undercity;
Guild = "Armorer" ;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 21752, InventoryTypes.OneHand, 0, 1, 13, 3, 0, 0, 0 ));
}
}

public class Burkrum : BaseCreature 
 { 
public  Burkrum() : base() 
 { 
Model = 4726;
AttackSpeed= 2000;
BoundingRadius = 0.974700f ;
Name = "Burkrum" ;
Flags1 = 0x08480046 ;
Id = 6028 ; 
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
NpcType = 7 ;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 4.05f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Burkrum." ;
BaseMana = 0 ;
Sells = new Item[] { new MetalBuckler()
                           , new ReinforcedTarge()
                           , new PolishedScaleBelt()
                           , new PolishedScaleBoots()
                           , new PolishedScaleBracers()
                           , new PolishedScaleGloves()
                           , new PolishedScaleLeggings()
                           , new PolishedScaleVest()
                           , new AugmentedChainVest()
                           , new AugmentedChainLeggings()
                           , new AugmentedChainBelt()
                           , new AugmentedChainBoots()
                           , new AugmentedChainBracers()
                           , new AugmentedChainGloves()
                           , new KiteShield()
                           , new HeavyPavise()
                           , new AugmentedChainHelm()
  } ;
Faction = Factions.ThunderBluff;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 12857, InventoryTypes.TwoHanded, 6, 1, 17, 2, 0, 0, 0 ));
}
}

public class WrinkleGoodsteel : BaseCreature 
 { 
public  WrinkleGoodsteel() : base() 
 { 
Model = 7343;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Wrinkle Goodsteel" ;
Flags1 = 0x08080006 ;
Id = 8129 ; 
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
NpcType = 7 ;
BaseHitPoints = 1625 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 43, 56 );
NpcText00 = "Greetings $N, I am Wrinkle Goodsteel." ;
BaseMana = 0 ;
Sells = new Item[] { new MetalBuckler()
                           , new OrnateBuckler()
                           , new AugmentedChainVest()
                           , new AugmentedChainLeggings()
                           , new AugmentedChainBelt()
                           , new AugmentedChainBoots()
                           , new AugmentedChainBracers()
                           , new AugmentedChainGloves()
                           , new BrigandineVest()
                           , new BrigandineBelt()
                           , new BrigandineLeggings()
                           , new BrigandineBoots()
                           , new BrigandineBracers()
                           , new BrigandineGloves()
                           , new MetalBuckler()
                           , new OrnateBuckler()
                           , new HeavyPavise()
                           , new CrestedHeaterShield()
                           , new AugmentedChainHelm()
                           , new BrigandineHelm()
                           , new PlatemailBelt()
                           , new PlatemailBoots()
                           , new PlatemailBracers()
                           , new PlatemailGloves()
                           , new PlatemailHelm()
                           , new PlatemailLeggings()
                           , new PlatemailArmor()
  } ;
Faction = Factions.Gadgetzan;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
Equip( new Item( 7438, InventoryTypes.OneHand, 4, 2, 13, 3, 0, 0, 0 ));
}
}

public class Hewa : BaseCreature 
 { 
public  Hewa() : base() 
 { 
Model = 7622;
AttackSpeed= 2000;
BoundingRadius = 0.974700f ;
Name = "Hewa" ;
Flags1 = 0x08480046 ;
Id = 8358 ; 
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
NpcType = 7 ;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 4.05f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Hewa." ;
BaseMana = 0 ;
Sells = new Item[] { new CommonBrownShirt()
                           , new CommonWhiteShirt()
                           , new ThickClothVest()
                           , new ThickClothPants()
                           , new ThickClothShoes()
                           , new ThickClothGloves()
                           , new CommonGrayShirt()
                           , new HeavyWeaveBelt()
                           , new HeavyWeaveBracers()
                           , new ThickClothBelt()
                           , new ThickClothBracers()
                           , new HeavyWeaveArmor()
                           , new HeavyWeavePants()
                           , new HeavyWeaveGloves()
                           , new HeavyWeaveShoes()
  } ;
Faction = Factions.ThunderBluff;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
}
}

public class Ahanu : BaseCreature 
 { 
public  Ahanu() : base() 
 { 
Model = 7623;
AttackSpeed= 2000;
BoundingRadius = 0.974700f ;
Name = "Ahanu" ;
Flags1 = 0x08480046 ;
Id = 8359 ; 
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
NpcType = 7 ;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 4.05f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Ahanu." ;
BaseMana = 0 ;
Sells = new Item[] { new TannedLeatherBelt()
                           , new TannedLeatherBracers()
                           , new CuredLeatherBelt()
                           , new CuredLeatherBracers()
                           , new CuredLeatherArmor()
                           , new CuredLeatherPants()
                           , new CuredLeatherBoots()
                           , new CuredLeatherGloves()
                           , new TannedLeatherBoots()
                           , new TannedLeatherGloves()
                           , new TannedLeatherPants()
                           , new TannedLeatherJerkin()
  } ;
Faction = Factions.ThunderBluff;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 23172, InventoryTypes.OneHand, 14, 1, 13, 0, 0, 0, 0 ), new Item( 23172, InventoryTypes.HeldInHand, 0, 1, 23, 0, 0, 0, 0 ));
}
}

public class Elki : BaseCreature 
 { 
public  Elki() : base() 
 { 
Model = 7624;
AttackSpeed= 2000;
BoundingRadius = 0.974700f ;
Name = "Elki" ;
Flags1 = 0x08480046 ;
Id = 8360 ; 
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
NpcType = 7 ;
BaseHitPoints = 1224 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 4.05f ;
SetDamage ( 32, 42 );
NpcText00 = "Greetings $N, I am Elki." ;
BaseMana = 0 ;
Sells = new Item[] { new BandedBuckler()
                           , new WallShield()
                           , new BandedBuckler()
                           , new RingedBuckler()
                           , new ChainmailBelt()
                           , new ChainmailBracers()
                           , new ScalemailBracers()
                           , new ScalemailBelt()
                           , new RingedBuckler()
                           , new LargeMetalShield()
                           , new ScalemailVest()
                           , new ScalemailPants()
                           , new ScalemailBoots()
                           , new ScalemailGloves()
                           , new ChainmailArmor()
                           , new ChainmailPants()
                           , new ChainmailBoots()
                           , new ChainmailGloves()
  } ;
Faction = Factions.ThunderBluff;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
Equip( new Item( 7439, InventoryTypes.OneHand, 4, 2, 13, 3, 0, 0, 0 ));
}
}

public class DulcieaFrostmoon : BaseCreature 
 { 
public  DulcieaFrostmoon() : base() 
 { 
Model = 9822;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Dulciea Frostmoon" ;
Flags1 = 0x08480046 ;
Id = 10293 ; 
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
NpcType = 7 ;
BaseHitPoints = 16+10*Level;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 55, 72 );
NpcText00 = "Greetings $N, I am Dulciea Frostmoon." ;
BaseMana = 0 ;
Sells = new Item[] { new RussetVest()
                           , new RussetPants()
                           , new RussetBoots()
                           , new RussetGloves()
                           , new EmbroideredArmor()
                           , new EmbroideredPants()
                           , new EmbroideredBoots()
                           , new EmbroideredGloves()
                           , new EmbroideredBelt()
                           , new EmbroideredBracers()
                           , new RussetBelt()
                           , new RussetBracers()
                           , new RussetHat()
                           , new EmbroideredHat()
  } ;
Faction = Factions.Darnasus;
Guild = "Armorer" ;
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
}
}

public class SanuyeRunetotem : BaseCreature 
 { 
public  SanuyeRunetotem() : base() 
 { 
Model = 9772;
AttackSpeed= 2000;
BoundingRadius = 0.974700f ;
Name = "Sanuye Runetotem" ;
Flags1 = 0x08480046 ;
Id = 10380 ; 
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
NpcType = 7 ;
BaseHitPoints = 1104 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 4.05f ;
SetDamage ( 29, 38 );
NpcText00 = "Greetings $N, I am Sanuye Runetotem." ;
BaseMana = 0 ;
Sells = new Item[] { new TannedLeatherBelt()
                           , new TannedLeatherBracers()
                           , new TannedLeatherBoots()
                           , new TannedLeatherGloves()
                           , new TannedLeatherPants()
                           , new TannedLeatherJerkin()
  } ;
Faction = Factions.ThunderBluff;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
Equip( new Item( 6434, InventoryTypes.OneHand, 15, 1, 13, 3, 0, 0, 0 ));
}
}

public class Nixxrak : BaseCreature 
 { 
public  Nixxrak() : base() 
 { 
Model = 10739;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Nixxrak" ;
Flags1 = 0x08080006 ;
Id = 11182 ; 
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
Level = RandomLevel( 54 );
NpcType = 7 ;
BaseHitPoints = 2186 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.500000f ;
SetDamage ( 59, 76 );
NpcText00 = "Greetings $N, I am Nixxrak." ;
BaseMana = 0 ;
Sells = new Item[] { new OrnateBuckler()
                           , new BrigandineVest()
                           , new BrigandineBelt()
                           , new BrigandineLeggings()
                           , new BrigandineBoots()
                           , new BrigandineBracers()
                           , new BrigandineGloves()
                           , new OrnateBuckler()
                           , new CrestedHeaterShield()
                           , new BrigandineHelm()
                           , new PlatemailBelt()
                           , new PlatemailBoots()
                           , new PlatemailBracers()
                           , new PlatemailGloves()
                           , new PlatemailHelm()
                           , new PlatemailLeggings()
                           , new PlatemailArmor()
  } ;
Faction = Factions.Everlook;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
Equip( new Item( 12236, InventoryTypes.OneHand, 4, 2, 13, 7, 0, 0, 0 ));
}
}

public class Blixxrak : BaseCreature 
 { 
public  Blixxrak() : base() 
 { 
Model = 10740;
AttackSpeed= 2000;
BoundingRadius = 0.306000f ;
Name = "Blixxrak" ;
Flags1 = 0x08080006 ;
Id = 11183 ; 
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
Level = RandomLevel( 55 );
NpcType = 7 ;
BaseHitPoints = 2226 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 60, 77 );
NpcText00 = "Greetings $N, I am Blixxrak." ;
BaseMana = 0 ;
Sells = new Item[] { new EmbroideredArmor()
                           , new EmbroideredPants()
                           , new EmbroideredBoots()
                           , new EmbroideredGloves()
                           , new ReinforcedLeatherVest()
                           , new ReinforcedLeatherBelt()
                           , new ReinforcedLeatherPants()
                           , new ReinforcedLeatherBoots()
                           , new ReinforcedLeatherBracers()
                           , new ReinforcedLeatherGloves()
                           , new EmbroideredBelt()
                           , new EmbroideredBracers()
                           , new EmbroideredHat()
                           , new ReinforcedLeatherCap()
  } ;
Faction = Factions.Everlook;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
Equip( new Item( 7460, InventoryTypes.OneHand, 14, 1, 13, 7, 0, 0, 0 ));
}
}

public class GrawCornerstone : BaseCreature 
 { 
public  GrawCornerstone() : base() 
 { 
Model = 11666;
AttackSpeed= 2000;
BoundingRadius = 0.347000f ;
Name = "Graw Cornerstone" ;
Flags1 = 0x0480046 ;
Id = 11703 ; 
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
NpcType = 7 ;
BaseHitPoints = 2346 ;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 63, 82 );
NpcText00 = "Greetings $N, I am Graw Cornerstone." ;
BaseMana = 0 ;
Sells = new Item[] { new ChainmailBelt()
                           , new ChainmailBracers()
                           , new ChainmailArmor()
                           , new ChainmailPants()
                           , new ChainmailBoots()
                           , new ChainmailGloves()
  } ;
Faction = Factions.IronForge;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Guild = "Armorer" ;
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
Equip( new Item( 7438, InventoryTypes.Neck, 4, 2, 10, 3, 0, 0, 0 ));
}
}
}

public class Kharedon : BaseCreature 
 { 
public  Kharedon() : base() 
 { 
Model = 12034;
AttackSpeed= 2000;
BoundingRadius = 0.389000f ;
Name = "Kharedon" ;
Flags1 = 0x08000046 ;
Id = 12023 ; 
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
NpcType = 7 ;
BaseHitPoints = 16+10*Level;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 55, 72 );
NpcText00 = "Greetings $N, I am Kharedon." ;
BaseMana = 0 ;
Sells = new Item[] { new WellOiledCloak()
                           , new EmbroideredArmor()
                           , new EmbroideredPants()
                           , new EmbroideredBoots()
                           , new EmbroideredGloves()
                           , new ReinforcedLeatherVest()
                           , new ReinforcedLeatherBelt()
                           , new ReinforcedLeatherPants()
                           , new ReinforcedLeatherBoots()
                           , new ReinforcedLeatherBracers()
                           , new ReinforcedLeatherGloves()
                           , new EmbroideredBelt()
                           , new EmbroideredBracers()
                           , new EmbroideredHat()
                           , new ReinforcedLeatherCap()
  } ;
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
}
}
public class DermotJohns : BaseCreature 
 { 
public  DermotJohns() : base() 
 { 
Model = 3276;
AttackSpeed= 2000;
BoundingRadius = 0.389000f ;
Name = "Dermot Johns" ;
Guild="Cloth & Leather Armor Merchant";
Flags1 = 0x08080066 ;
Id = 190 ; 
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
NpcType = 7 ;
BaseHitPoints = 16+10*Level;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 5, 7 );
BaseMana = 0 ;
Sells = new Item[] {new CrackedLeatherBelt() 
,new CrackedLeatherBoots()
,new CrackedLeatherBracers()
,new CrackedLeatherGloves()
,new CrackedLeatherPants()
,new CrackedLeatherVest()
,new ThinClothArmor()
,new ThinClothBelt()
,new ThinClothBracers()
,new ThinClothGloves()
,new ThinClothPants()
,new ThinClothShoes()
  } ;
Faction = Factions.Stormwind;  
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Equip( new Item( 7483, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ), new Item( 1684, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
}
}


public class Andiss : BaseCreature 
 { 
public  Andiss() : base() 
 { 
Model = 1722;
AttackSpeed= 2000;
BoundingRadius = 0.389000f ;
Name = "Dermot Johns" ;
Guild="Armorer & Shieldcrafter";
Flags1 = 0x08080066;
Id = 3592 ; 
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
Level = RandomLevel(10);
NpcType = 7 ;
BaseHitPoints = 16+10*Level;
NpcFlags = (int)NpcActions.Vendor;
CombatReach = 1.5f ;
SetDamage ( 5, 7 );
BaseMana = 0 ;
Sells = new Item[] {new LargeRoundShield()
,new SmallShield()
,new TarnishedChainVest()
,new TarnishedChainBelt()
,new TarnishedChainLeggings()
,new TarnishedChainBoots()
,new TarnishedChainBracers()
,new TarnishedChainGloves()
,new SmallShield()
  } ;
Faction = Factions.Darnasus;  
AIEngine = new DefensiveAnimalAI( this );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
Equip( new Item( 7441, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ));
Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA, 100f )};
}
}

}
