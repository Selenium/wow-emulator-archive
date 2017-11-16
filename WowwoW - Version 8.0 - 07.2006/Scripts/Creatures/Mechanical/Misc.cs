//Script made by Dark_Ranger
//Script modified by Natsukawa
using System;
using System.Collections;
using Server;
using Server.Items;
////////////////////// Misc.cs
namespace Server.Creatures
{
   public class AMe01 : BaseCreature
   {
      public AMe01() : base()
      {
         Name = "A-Me 01";
         Id = 9623;
         Model = 8841;
         Level = 48;
         BaseHitPoints = 1945;
         BaseMana = 0;
         SetDamage(52f,67f);
         AttackSpeed = 2000;
         Block = 20;
         ResistArcane = 0;
         ResistFire = 0;
         ResistFrost = 0;
         ResistHoly = 0;
         ResistNature = 0;
         ResistShadow = 0;
         Size = 1f;
         Speed = 3f;
         WalkSpeed = 3f;
         RunSpeed = 6f;
         Faction = Factions.Friend;
         AIEngine = new AgressiveAnimalAI( this );
         NpcType = 9;
         Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyA , 100f )
                                , new BaseTreasure(MiscLoot.AMe01 , 100f )
                             };
      }
   }
}
namespace Server.Creatures
{
   public class Clunk : BaseCreature
   {
      public Clunk() : base()
      {
         Name = "Clunk";
         Id = 8447;
         Model = 6569;
         Level = 48;
         BaseHitPoints =  6228;
         BaseMana = 0;
         BoundingRadius = 0.3500000f;
         CombatReach = 1.5f;
         SetDamage(1f+3f*Level,1f+3.5*Level);
         Armor = 20*Level;
         Block = 2*Level;
         AttackSpeed = 2000;
         Block = 20;
         ResistArcane = 0;
         ResistFire = 0;
         ResistFrost = 0;
         ResistHoly = 0;
         ResistNature = 0;
         ResistShadow = 0;
         Elite=1;
         Size = 1f;
         Speed = 3f;
         WalkSpeed = 3f;
         RunSpeed = 6f;
         Faction = Factions.BlacksmithingGnomeSmithing;
         AIEngine = new PredatorAI( this );
         AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
         AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
         NpcType = 9;
         Guild = "The Undermarket";
         Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyA , 100f )
                                , new BaseTreasure(MiscLoot.Clunk , 100f )
                             };
      }
   }
}
namespace Server.Creatures
{
   public class GnomeDragCar : BaseCreature
   {
      public GnomeDragCar() : base()
      {
         Name = "Gnome Drag Car";
         Id = 4946;
         Model = 2490;
         Level = 32;
         AttackSpeed = 2000;
         Size = 1f;
         Speed = 3f;
         WalkSpeed = 3f;
         RunSpeed = 10f;
         BaseHitPoints =  1304;
         BaseMana = 0;
         BoundingRadius = 0.5000000f;
         CombatReach = 1.5f;
         SetDamage(1f+3f*Level,1f+3.5*Level);
         Armor = 20*Level;
         Block = 2*Level;
         ResistArcane = 0;
         ResistFire = 0;
         ResistFrost = 0;
         ResistHoly = 0;
         ResistNature = 0;
         ResistShadow = 0;
         Faction = Factions.Friend;
         AIEngine = new NonAgressiveAnimalAI( this );
         AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
         NpcType = 9;
         Guild = "Placeholder for Rocket Car";
         //Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyA , 100f )
         //, new BaseTreasure(MiscLoot.GnomeDragCar , 100f )
         //No drops found in this time.
      }
   }
}
namespace Server.Creatures
{
   public class GnomeCar : BaseCreature
   {
      public GnomeCar() : base()
      {
         Name = "Gnome Car";
         Id = 4252;
         Model = 2490;
         Level = 32;
         AttackSpeed = 2000;
         Size = 1f;
         Speed = 3f;
         WalkSpeed = 3f;
         RunSpeed = 10f;
         BaseHitPoints =  1304;
         BaseMana = 0;
         BoundingRadius = 0.4200000f;
         CombatReach = 1.5f;
         SetDamage(1f+3f*Level,1f+3.5*Level);
         Armor = 20*Level;
         Block = 2*Level;
         ResistArcane = 0;
         ResistFire = 0;
         ResistFrost = 0;
         ResistHoly = 0;
         ResistNature = 0;
         ResistShadow = 0;
         Faction = Factions.Friend;
         AIEngine = new NonAgressiveAnimalAI( this );
         AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
         NpcType = 9;
         Guild = "Placeholder for Rocket Car";
         //Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyA , 100f )
         //, new BaseTreasure(MiscLoot.GnomeCar , 100f )
         //No drops found in this time.
      }
   }
}
namespace Server.Creatures
{
   public class GoblinDragCar : BaseCreature
   {
      public GoblinDragCar() : base()
      {
         Name = "Goblin Drag Car";
         Id = 4945;
         Model = 10318;
         Level = 32;
         AttackSpeed = 2000;
         Size = 1f;
         Speed = 3f;
         WalkSpeed = 3f;
         RunSpeed = 10f;
         BaseHitPoints =  1304;
         BaseMana = 0;
         BoundingRadius = 0.3500000f;
         CombatReach = 2.5f;
         SetDamage(1f+3f*Level,1f+3.5*Level);
         Armor = 20*Level;
         Block = 2*Level;
         ResistArcane = 0;
         ResistFire = 0;
         ResistFrost = 0;
         ResistHoly = 0;
         ResistNature = 0;
         ResistShadow = 0;
         Faction = Factions.Friend;
         AIEngine = new NonAgressiveAnimalAI( this );
         AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
         NpcType = 9;
         Guild = "Placeholder for Rocket Car";
         //Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyA , 100f )
         //, new BaseTreasure(MiscLoot.GoblinDragCar , 100f )
         //No drops found in this time.
      }
   }
}
namespace Server.Creatures
{
   public class GoblinCar : BaseCreature
   {
      public GoblinCar() : base()
      {
         Name = "Goblin Car";
         Id = 4251;
         Model = 10318;
         Level = 32;
         AttackSpeed = 2000;
         Size = 1f;
         Speed = 3f;
         WalkSpeed = 3f;
         RunSpeed = 10f;
         BaseHitPoints =  1304;
         BaseMana = 0;
         BoundingRadius = 0.3500000f;
         CombatReach = 2.5f;
         SetDamage(1f+3f*Level,1f+3.5*Level);
         Armor = 20*Level;
         Block = 2*Level;
         ResistArcane = 0;
         ResistFire = 0;
         ResistFrost = 0;
         ResistHoly = 0;
         ResistNature = 0;
         ResistShadow = 0;
         Faction = Factions.Friend;
         AIEngine = new NonAgressiveAnimalAI( this );
         AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
         NpcType = 9;
         Guild = "Placeholder for Rocket Car";
         //Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyA , 100f )
         //, new BaseTreasure(MiscLoot.GoblinCar , 100f )
         //No drops found in this time.
      }
   }
}
namespace Server.Creatures
{
   public class HomingRobotOOX09HL : BaseCreature
   {
      public HomingRobotOOX09HL() : base()
      {
         Name = "Homing Robot OOX-09/HL";
         Id = 7806;
         Model = 6909;
         Level = 42;
         BaseHitPoints = 1665;
         BaseMana = 0;
         SetDamage(44f,58f);
         AttackSpeed = 2000;
         Block = 20;
         ResistArcane = 0;
         ResistFire = 0;
         ResistFrost = 0;
         ResistHoly = 0;
         ResistNature = 0;
         ResistShadow = 0;
         CombatReach = 3f;
         Size = 1f;
         Speed = 3f;
         WalkSpeed = 3f;
         RunSpeed = 6f;
         Faction = Factions.Friend;
         AIEngine = new AgressiveAnimalAI( this );
         AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
         AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
         NpcType = 9;
         Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyA , 100f )
                                , new BaseTreasure(MiscLoot.HomingRobotOOX09HL , 100f )
                             };
      }
   }
}
namespace Server.Creatures
{
   public class HomingRobotOOX17TN : BaseCreature
   {
      public HomingRobotOOX17TN() : base()
      {
         Name = "Homing Robot OOX-17/TN";
         Id = 7784;
         Model = 6909;
         Level = 42;
         BaseHitPoints = 1705;
         BaseMana = 0;
         AttackSpeed = 2000;
         Block = 20;
         ResistArcane = 0;
         ResistFire = 0;
         ResistFrost = 0;
         ResistHoly = 0;
         ResistNature = 0;
         ResistShadow = 0;
         BoundingRadius = 0.4350000f;
         CombatReach = 3f;
         Size = 1f;
         Speed = 3f;
         WalkSpeed = 3f;
         RunSpeed = 6f;
         Faction = Factions.NoFaction;
         AIEngine = new DefensiveAnimalAI( this );
         AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
         AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
         NpcType = 9;
         Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyA , 100f )
                                , new BaseTreasure(MiscLoot.HomingRobotOOX17TN , 100f )
                             };

      }
   }
}
namespace Server.Creatures
{
   public class HomingRobotOOX22FE : BaseCreature
   {
      public HomingRobotOOX22FE() : base()
      {
         Name = "Homing Robot OOX-22/FE";
         Id = 7807;
         Model = 6909;
         Level = 42;
         BaseHitPoints = 1665;
         BaseMana = 0;
         SetDamage(44f,58f);
         AttackSpeed = 2000;
         Block = 20;
         ResistArcane = 0;
         ResistFire = 0;
         ResistFrost = 0;
         ResistHoly = 0;
         ResistNature = 0;
         ResistShadow = 0;
         CombatReach = 3f;
         Size = 1f;
         Speed = 3f;
         WalkSpeed = 3f;
         RunSpeed = 6f;
         Faction = Factions.Friend;
         AIEngine = new AgressiveAnimalAI( this );
         AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
         AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
         NpcType = 9;
         Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyA , 100f )
                                , new BaseTreasure(MiscLoot.HomingRobotOOX22FE , 100f )
                             };
      }
   }
}
namespace Server.Creatures
{
   public class MortarTeamAdvancedTargetDummy : BaseCreature
   {
      public MortarTeamAdvancedTargetDummy() : base()
      {
         Name = "Mortar Team Advanced Target Dummy";
         Id = 12385;
         Model = 12434;
         Level = 1;
         BaseHitPoints = 24;
         BaseMana = 0;
         SetDamage(0f,0f);
         AttackSpeed = 2000;
         Block = 0;
         ResistArcane = 0;
         ResistFire = 0;
         ResistFrost = 0;
         ResistHoly = 0;
         ResistNature = 0;
         ResistShadow = 0;
         BoundingRadius = 0.5610000f;
         CombatReach = 1f;
         Size = 1f;
         Speed = 3f;
         WalkSpeed = 3f;
         RunSpeed = 6f;
         Faction = Factions.Everlook;
         AIEngine = new NonAgressiveAnimalAI( this );
         AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
         AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
         NpcType = 9;
         //Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyA , 100f )
         //, new BaseTreasure(MiscLoot.MortarTeamAdvancedTargetDummy , 100f )
         //No drops found in this time.

      }
   }
}
namespace Server.Creatures
{
   public class MortarTeamTargetDummy : BaseCreature
   {
      public MortarTeamTargetDummy() : base()
      {
         Name = "Mortar Team Target Dummy";
         Id = 11875;
         Model = 1555;
         Level = 1;
         BaseHitPoints = 24;
         BaseMana = 0;
         SetDamage(0f,0f);
         AttackSpeed = 2000;
         Block = 0;
         ResistArcane = 0;
         ResistFire = 0;
         ResistFrost = 0;
         ResistHoly = 0;
         ResistNature = 0;
         ResistShadow = 0;
         BoundingRadius = 0.5610000f;
         CombatReach = 1f;
         Size = 1f;
         Speed = 3f;
         WalkSpeed = 3f;
         RunSpeed = 6f;
         Faction = Factions.Everlook;
         AIEngine = new NonAgressiveAnimalAI( this );
         AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
         AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
         NpcType = 9;
         //Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyA , 100f )
         //, new BaseTreasure(MiscLoot.MortarTeamTargetDummy , 100f )
         //No drops found in this time.

      }
   }
}
namespace Server.Creatures
{
   public class ObsidianGolem : BaseCreature
   {
      public ObsidianGolem() : base()
      {
         Name = "Obsidian Golem";
         Id = 4872;
         Model = 2695;
         Level = 38;
         BaseHitPoints = 4512;
         BaseMana = 0;
         SetDamage(40f,52f);
         AttackSpeed = 2000;
         Block = 30;
         ResistArcane = 0;
         ResistFire = 0;
         ResistFrost = 0;
         ResistHoly = 0;
         ResistNature = 0;
         ResistShadow = 0;
         BoundingRadius = 0.6380000f;
         CombatReach = 1.5f;
         Elite=1;
         Size = 1f;
         Speed = 3f;
         WalkSpeed = 3f;
         RunSpeed = 6f;
         Faction = Factions.Syndicate;
         AIEngine = new AgressiveAnimalAI( this );
         AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
         AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
         NpcType = 9;
         Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyA , 100f )
                                , new BaseTreasure(MiscLoot.ObsidianGolem , 100f )
                             };
      }
   }
}
namespace Server.Creatures
{
   public class ObsidianSentinel : BaseCreature
   {
      public ObsidianSentinel() : base()
      {
         Name = "Obsidian Sentinel";
         Id = 7023;
         Model = 5285;
         Level = 42;
         BaseHitPoints = 4512;
         BaseMana = 0;
         SetDamage(44f,58f);
         AttackSpeed = 2000;
         Block = 30;
         ResistArcane = 0;
         ResistFire = 0;
         ResistFrost = 0;
         ResistHoly = 0;
         ResistNature = 0;
         ResistShadow = 0;
         BoundingRadius = 0.7290000f;
         CombatReach = 2.25f;
         Elite=1;
         Size = 1f;
         Speed = 3f;
         WalkSpeed = 3f;
         RunSpeed = 6f;
         Faction = Factions.Syndicate;
         AIEngine = new AgressiveAnimalAI( this );
         AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
         AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
         NpcType = 9;
         Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyA , 100f )
                                , new BaseTreasure(MiscLoot.ObsidianSentinel , 100f )
                             };
      }
   }
}
namespace Server.Creatures
{
   public class ObsidianShard : BaseCreature
   {
      public ObsidianShard() : base()
      {
         Name = "Obsidian Shard";
         Id = 7209;
         Model = 3731;
         Level = 35;
         BaseHitPoints = 5115;
         BaseMana = 0;
         SetDamage(37f,48f);
         AttackSpeed = 2000;
         Block = 25;
         ResistArcane = 0;
         ResistFire = 0;
         ResistFrost = 0;
         ResistHoly = 0;
         ResistNature = 0;
         ResistShadow = 0;
         BoundingRadius = 0.51500000f;
         CombatReach = 0.75f;
         Size = 1f;
         Speed = 3f;
         WalkSpeed = 3f;
         RunSpeed = 6f;
         Faction = Factions.Syndicate;
         AIEngine = new AgressiveAnimalAI( this );
         AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
         AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
         NpcType = 9;
         //Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyA , 100f )
         //, new BaseTreasure(MiscLoot.ObsidianShard , 100f )
         //No drops found in this time.
      }
   }
}
namespace Server.Creatures
{
   public class OverwatchMark : BaseCreature
   {
      public OverwatchMark() : base()
      {
         Name = "Overwatch Mark I";
         Id = 3538;
         Model = 5299;
         Level = 32;
         BaseHitPoints = 1304;
         BaseMana = 0;
         SetDamage(35f,45f);
         AttackSpeed = 2000;
         Block = 10;
         ResistArcane = 0;
         ResistFire = 0;
         ResistFrost = 0;
         ResistHoly = 0;
         ResistNature = 0;
         ResistShadow = 0;
         BoundingRadius = 0.7820000f;
         CombatReach = 1.5f;
         Size = 1f;
         Speed = 3f;
         WalkSpeed = 3f;
         RunSpeed = 6f;
         Faction = Factions.Shendralar;
         AIEngine = new PatrolAI( this );
         NpcType = 9;
         Guild = "Protector";
         Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyA , 100f )
                                , new BaseTreasure(MiscLoot.OverwatchMark , 100f )
                             };
      }
   }
}
namespace Server.Creatures
{
   public class PracticeDummy : BaseCreature
   {
      public PracticeDummy() : base()
      {
         Name = "Practice Dummy";
         Id = 5652;
         Model = 3019;
         Level = 1;
         SetDamage(0f,0f);
         AttackSpeed = 2000;
         Block = 0;
         ResistArcane = 0;
         ResistFire = 0;
         ResistFrost = 0;
         ResistHoly = 0;
         ResistNature = 0;
         ResistShadow = 0;
         BoundingRadius = 1f;
         CombatReach = 1f;
         BaseHitPoints = 24;
         BaseMana = 0;
         Size = 1f;
         Speed = 3f;
         WalkSpeed = 3f;
         RunSpeed = 6f;
         Faction = Factions.Everlook;
         AIEngine = new NonAgressiveAnimalAI( this );
         AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
         AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
         NpcType = 9;
         //Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyA , 100f )
         //, new BaseTreasure(MiscLoot.PracticeDummy , 100f )
         //No drops found in this time.
      }
   }
}
namespace Server.Creatures
{
   public class RemoteControlledGolem : BaseCreature
   {
      public RemoteControlledGolem() : base()
      {
         Name = "Remote-Controlled Golem";
         Id = 2520;
         Model = 1159;
         Level = 18;
         BaseHitPoints = 744;
         BaseMana = 0;
         SetDamage(35f,45f);
         AttackSpeed = 2000;
         Block = 40;
         ResistArcane = 0;
         ResistFire = 0;
         ResistFrost = 0;
         ResistHoly = 0;
         ResistNature = 0;
         ResistShadow = 0;
         BoundingRadius = 0.3748000f;
         CombatReach = 0.6f;
         Elite=1;
         Size = 1f;
         Speed = 3f;
         WalkSpeed = 3f;
         RunSpeed = 6f;
         Faction = Factions.BlacksmithingGnomeSmithing;
         AIEngine = new AgressiveAnimalAI( this );
         AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
         AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
         NpcType = 9;
         Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyA , 100f )
                                , new BaseTreasure(MiscLoot.RemoteControlledGolem , 100f )
                             };
      }
   }
}
namespace Server.Creatures
{
   public class Servo : BaseCreature
   {
      public Servo() : base()
      {
         Name = "Servo";
         Id = 2922;
         Model = 1150;
         Level = 5;
         BaseHitPoints = 224;
         BaseMana = 0;
         SetDamage(5f,6f);
         AttackSpeed = 2000;
         Block = 5;
         ResistArcane = 0;
         ResistFire = 0;
         ResistFrost = 0;
         ResistHoly = 0;
         ResistNature = 0;
         ResistShadow = 0;
         CombatReach = 2f;
         Size = 1f;
         Speed = 3f;
         WalkSpeed = 3f;
         RunSpeed = 6f;
         Faction = Factions.HydraxianWaterlords;
         AIEngine = new AgressiveAnimalAI( this );
         AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
         AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
         NpcType = 9;
         Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyA , 100f )
                                , new BaseTreasure(MiscLoot.Servo , 100f )
                             };
      }
   }
}
namespace Server.Creatures
{
   public class TheramoreCombatDummy : BaseCreature
   {
      public TheramoreCombatDummy() : base()
      {
         Name = "Theramore Combat Dummy";
         Id = 4952;
         Model = 3019;
         Level = 1;
         BaseHitPoints = 24;
         BaseMana = 0;
         SetDamage(0f,0f);
         AttackSpeed = 2000;
         Block = 0;
         ResistArcane = 0;
         ResistFire = 0;
         ResistFrost = 0;
         ResistHoly = 0;
         ResistNature = 0;
         ResistShadow = 0;
         BoundingRadius = 1f;
         CombatReach = 1f;
         Size = 1f;
         Speed = 3f;
         WalkSpeed = 3f;
         RunSpeed = 6f;
         Faction = Factions.Everlook;
         AIEngine = new NonAgressiveAnimalAI( this );
         AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
         AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
         NpcType = 9;
         Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyA , 100f )
                                , new BaseTreasure(MiscLoot.TheramoreCombatDummy , 100f )
                             };
      }
   }
}
namespace Server.Creatures
{
   public class TyrionsSpybot : BaseCreature
   {
      public TyrionsSpybot() : base()
      {
         Name = "Tyrion's Spybot";
         Id = 8856;
         Model = 1159;
         Level = 25;
         BaseHitPoints = 1024;
         BaseMana = 0;
         SetDamage(27f,35f);
         AttackSpeed = 2000;
         Block = 18;
         ResistArcane = 0;
         ResistFire = 0;
         ResistFrost = 0;
         ResistHoly = 0;
         ResistNature = 0;
         ResistShadow = 0;
         BoundingRadius = 1f;
         CombatReach = 1f;
         Size = 1f;
         Speed = 3f;
         WalkSpeed = 3f;
         RunSpeed = 6f;
         Faction = Factions.MoroGai;
         AIEngine = new EvilInteligentMonsterAI( this );
         AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
         AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
         NpcType = 9;
         //Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyA , 100f )
         //, new BaseTreasure(MiscLoot.TyrionsSpybot , 100f )
         //No drops found in this time.
      }
   }
}
namespace Server.Creatures
{
   public class WardOfLaze : BaseCreature
   {
      public WardOfLaze() : base()
      {
         Name = "Ward of Laze";
         Id = 2667;
         Model = 2420;
         Level = 37;
         BaseHitPoints = 1424;
         BaseMana = 0;
         SetDamage(38f,49f);
         AttackSpeed = 2000;
         Block = 16;
         ResistArcane = 0;
         ResistFire = 0;
         ResistFrost = 0;
         ResistHoly = 0;
         ResistNature = 0;
         ResistShadow = 0;
         BoundingRadius = 1f;
         CombatReach = 1f;
         Size = 1f;
         Speed = 3f;
         WalkSpeed = 3f;
         RunSpeed = 6f;
         Faction = Factions.BlacksmithingTribalSmithing;
         AIEngine = new EvilInteligentMonsterAI( this );
         AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
         AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
         NpcType = 9;
         //Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyA , 100f )
         //, new BaseTreasure(MiscLoot.WardOfLaze , 100f )
         //No drops found in this time.
      }
   }
}
namespace Server.Creatures
{
   public class WardOfZanzil : BaseCreature
   {
      public WardOfZanzil() : base()
      {
         Name = "Ward of Zanzil";
         Id = 6386;
         Model = 2418;
         Level = 46;
         BaseHitPoints = 1865;
         BaseMana = 0;
         SetDamage(50f,65f);
         AttackSpeed = 2000;
         Block = 20;
         ResistArcane = 0;
         ResistFire = 0;
         ResistFrost = 0;
         ResistHoly = 0;
         ResistNature = 0;
         ResistShadow = 0;
         BoundingRadius = 1f;
         CombatReach = 1f;
         Size = 1f;
         Speed = 3f;
         WalkSpeed = 3f;
         RunSpeed = 6f;
         Faction = Factions.BlacksmithingSwordSmithing;
         AIEngine = new AgressiveAnimalAI( this );
         AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
         AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
         NpcType = 9;
         //Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyA , 100f )
         //, new BaseTreasure(MiscLoot.WardOfZanzil , 100f )
         //No drops found in this time.
      }
   }
}
namespace Server.Creatures
{
   public class WarugsTargetDummy : BaseCreature
   {
      public WarugsTargetDummy() : base()
      {
         Name = "Warug's Target Dummy";
         Id = 5723;
         Model = 1555;
         Level = 1;
         BaseHitPoints = 24;
         BaseMana = 0;
         SetDamage(0f,0f);
         AttackSpeed = 2000;
         Block = 0;
         ResistArcane = 0;
         ResistFire = 0;
         ResistFrost = 0;
         ResistHoly = 0;
         ResistNature = 0;
         ResistShadow = 0;
         BoundingRadius = 1f;
         CombatReach = 1f;
         Size = 1f;
         Speed = 3f;
         WalkSpeed = 3f;
         RunSpeed = 6f;
         Faction = Factions.Everlook;
         AIEngine = new AgressiveAnimalAI( this );
         NpcType = 9;
         Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyA , 100f )
                                , new BaseTreasure(MiscLoot.WarugsTargetDummy , 100f )
                             };
      }
   }
}
namespace Server.Creatures
{
   public class WrenixsGizmotronicApparatus : BaseCreature
   {
      public WrenixsGizmotronicApparatus() : base()
      {
         Name = "Wrenix's Gizmotronic Apparatus";
         Id = 7166;
         Model = 1097;
         Level = 20;
         BaseHitPoints = 824;
         BaseMana = 0;
         SetDamage(21f,28f);
         AttackSpeed = 2000;
         Block = 16;
         ResistArcane = 0;
         ResistFire = 0;
         ResistFrost = 0;
         ResistHoly = 0;
         ResistNature = 0;
         ResistShadow = 0;
         BoundingRadius = 1f;
         CombatReach = 1f;
         Size = 1f;
         Speed = 3f;
         WalkSpeed = 3f;
         RunSpeed = 6f;
         Faction = Factions.MoroGai;
         AIEngine = new EvilInteligentMonsterAI( this );
         AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
         AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
         NpcType = 9;
         Loots = new BaseTreasure[]{ new BaseTreasure(Drops.MoneyA , 100f )
                                , new BaseTreasure(MiscLoot.WrenixsGizmotronicApparatus , 100f )
                             };
      }
   }
} 