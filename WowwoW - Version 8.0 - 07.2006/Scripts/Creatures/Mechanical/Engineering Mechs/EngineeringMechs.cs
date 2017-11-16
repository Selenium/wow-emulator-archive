//originally Scripted By mmcs
using System;
using Server.Items;
using Server;

////////////////////
namespace Server.Creatures
{
	public class AdvancedTargetDummy : BaseCreature 
	{ 
		public  AdvancedTargetDummy() : base() 
		{ 
			Id = 2674 ;
			Name = "Advanced Target Dummy" ;
			Model = 1555;
			Level = RandomLevel( 26 );
			AttackSpeed= 2000 ;
			BoundingRadius = 0.28f ;
			CombatReach = 5f ;
			BaseHitPoints = 1600 ;
			BaseMana = 0 ;
			Str = (int)(Level);
			Armor = (int)(26.4f*Level);
			Block=Level+10;
			SetDamage( 1.1f*Level, 1.45f*Level ); 
			Size = 2.0f;
			Speed = 3f ;
			WalkSpeed = 3f ;
			RunSpeed = 6f ;
			NpcFlags = 0 ; Flags1 = 0x0103102 ;
			NpcType = (int)NpcTypes.Mechanical ;
			Faction = Factions.NoFaction;
			AIEngine = new DefensiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( EngineeringMechsDrops.AdvancedTargetDummy, 100f ) };
		}
	}
	public class ArcaniteDragonling : BaseCreature 
	{ 
		public  ArcaniteDragonling() : base() 
		{ 
			Id = 12473 ;
			Name = "Arcanite Dragonling" ;
			Model = 12489;
			Level = RandomLevel( 60 );
			AttackSpeed= 2000 ;
			BoundingRadius = 0.3475f ;
			CombatReach = 1.5625f ;
			BaseHitPoints = 5000 ;
			BaseMana = 0 ;
			Str = (int)(Level);
			Armor = (int)(26.4f*Level);
			Block=Level+10;
			SetDamage( 1.1f*Level, 1.45f*Level ); 
			Size = 1.25f;
			Speed = 3f ;
			WalkSpeed = 3f ;
			RunSpeed = 6f ;
			NpcFlags = 0 ; Flags1 = 0x06 ;
			NpcType = (int)NpcTypes.Mechanical ;
			Faction = Factions.Darnasus ;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( EngineeringMechsDrops.ArcaniteDragonling, 100f ) };
		}
	}
	public class ArcheryTarget : BaseCreature 
	{ 
		public  ArcheryTarget() : base() 
		{ 
			Id = 5202 ;
			Name = "Archery Target" ;
			Model = 3020;
			Level = RandomLevel( 1 );
			AttackSpeed= 2000 ;
			BoundingRadius = 0.66f ;
			CombatReach = 1.0f ;
			BaseHitPoints = 64 ;
			BaseMana = 0 ;
			Str = (int)(Level);
			Armor = (int)(26.4f*Level);
			Block=Level+10;
			SetDamage( 1.1f*Level, 1.45f*Level ); 
			Size = 1.0f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			NpcFlags = 0 ; Flags1 = 0x010032E ;
			NpcType = (int)NpcTypes.Mechanical ;
			Faction = Factions.NoFaction ;
			AIEngine = new DefensiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( EngineeringMechsDrops.ArcheryTarget, 100f ) };
		}
	}							
	public class BattleChicken : BaseCreature 
	{ 
		public  BattleChicken() : base() 
		{ 
			Id = 8836 ;
			Name = "Battle Chicken" ;
			Model = 6909;
			Level = RandomLevel( 52 );
			AttackSpeed= 1000 ;
			BoundingRadius = 0.435f ;
			CombatReach = 3f ;
			BaseHitPoints = 5000 ;
			BaseMana = 0 ;
			Str = (int)(Level);
			Armor = (int)(26.4f*Level);
			Block=Level+10;
			SetDamage( 1.1f*Level, 1.45f*Level ); 
			Size = 3f;
			Speed = 3f ;
			WalkSpeed = 3f ;
			RunSpeed = 6f ;
			NpcFlags = 0 ; Flags1 = 0x0404 ;
			NpcType = (int)NpcTypes.Mechanical ;
			Faction = Factions.GnomereganExiles ;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( EngineeringMechsDrops.BattleChicken, 100f ) };
		}
	}	
	public class FieldRepairBot74A : BaseCreature 
	{ 
		public  FieldRepairBot74A() : base() 
		{ 
			Id = 14337 ;
			Name = "Field Repair Bot 74A" ;
			Model = 14379;
			Level = RandomLevel( 50 );
			AttackSpeed= 1000 ;
			BoundingRadius = 0.435f ;
			CombatReach = 3f ;
			BaseHitPoints = 4000 ;
			BaseMana = 0 ;
			Str = (int)(Level);
			Armor = (int)(26.4f*Level);
			Block=Level+10;
			SetDamage( 1.1f*Level, 1.45f*Level ); 
			Size = 1f;
			Speed = 3f ;
			WalkSpeed = 3f ;
			RunSpeed = 6f ;
			NpcFlags = 0 ; Flags1 = 0x0166 ;
			NpcType = (int)NpcTypes.Mechanical ;
			Faction = Factions.GnomereganExiles ;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( EngineeringMechsDrops.FieldRepairBot74A, 100f ) };
		}
	}	
	public class LilSmokey : BaseCreature 
	{ 
		public  LilSmokey() : base() 
		{ 
			Id = 9657 ;
			Name = "Lil' Smokey" ;
			Model = 8910;
			Level = RandomLevel( 1 );
			AttackSpeed= 2000 ;
			BoundingRadius = 0.225f ;
			CombatReach = 0.225f ;
			BaseHitPoints = 64 ;
			BaseMana = 0 ;
			Str = (int)(Level);
			Armor = (int)(26.4f*Level);
			Block=Level+10;
			SetDamage( 1.1f*Level, 1.45f*Level ); 
			Size = 0.15f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			NpcFlags = 0 ; Flags1 = 0x066 ;
			NpcType = (int)NpcTypes.Mechanical ;
			Faction = Factions.NoFaction ;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( EngineeringMechsDrops.LilSmokey, 100f ) };
		}
	}
	public class MasterworkTargetDummy : BaseCreature 
	{ 
		public  MasterworkTargetDummy() : base() 
		{ 
			Id = 12426 ;
			Name = "Masterwork Target Dummy" ;
			Model = 1555;
			Level = RandomLevel( 1 );
			AttackSpeed= 2100 ;
			BoundingRadius = 0.225f ;
			CombatReach = 0.225f ;
			BaseHitPoints = 64 ;
			BaseMana = 0 ;
			Str = (int)(Level);
			Armor = (int)(26.4f*Level);
			Block=Level+10;
			SetDamage( 1.1f*Level, 1.45f*Level ); 
			Size = 1.0f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			NpcFlags = 0 ; Flags1 = 0x0103102 ;
			NpcType = (int)NpcTypes.Mechanical ;
			Faction = Factions.NoFaction ;
			AIEngine = new DefensiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( EngineeringMechsDrops.MasterworkTargetDummy, 100f ) };
		}
	}
	public class MechanicalChicken : BaseCreature 
	{ 
		public  MechanicalChicken() : base() 
		{ 
			Id = 8376 ;
			Name = "Mechanical Chicken" ;
			Model = 7920;
			Level = RandomLevel( 1 );
			AttackSpeed= 2000 ;
			BoundingRadius = 0.145f ;
			CombatReach = 1.0f ;
			BaseHitPoints = 64 ;
			BaseMana = 0 ;
			Str = (int)(Level);
			Armor = (int)(26.4f*Level);
			Block=Level+10;
			SetDamage( 1.1f*Level, 1.45f*Level ); 
			Size = 1.0f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			NpcFlags = 0 ; Flags1 = 0x066 ;
			NpcType = (int)NpcTypes.Mechanical ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( EngineeringMechsDrops.MechanicalChicken, 100f ) };
		}
	}
	public class MechanicalDragonling : BaseCreature 
	{ 
		public  MechanicalDragonling() : base() 
		{ 
			Id = 2678 ;
			Name = "Mechanical Dragonling" ;
			Model = 4465;
			Level = RandomLevel( 45 );
			AttackSpeed= 2000 ;
			BoundingRadius = 0.278f ;
			CombatReach = 1.25f ;
			BaseHitPoints = 3500 ;
			BaseMana = 0 ;
			Str = (int)(Level);
			Armor = (int)(26.4f*Level);
			Block=Level+10;
			SetDamage( 1.1f*Level, 1.45f*Level ); 
			Size = 1f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			NpcFlags = 0 ; Flags1 = 0x06 ;
			NpcType = (int)NpcTypes.Mechanical ;
			Faction = Factions.GnomereganExiles ;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( EngineeringMechsDrops.MechanicalDragonling, 100f ) };
		}
	}
	public class MechanicalSquirrel : BaseCreature 
	{ 
		public  MechanicalSquirrel() : base() 
		{ 
			Id = 2671 ;
			Name = "Mechanical Squirrel" ;
			Model = 7937;
			Level = RandomLevel( 15 );
			AttackSpeed= 2000 ;
			BoundingRadius = 1.3f ;
			CombatReach = 1.95f ;
			BaseHitPoints = 750 ;
			BaseMana = 0 ;
			Str = (int)(Level);
			Armor = (int)(26.4f*Level);
			Block=Level+10;
			SetDamage( 1.1f*Level, 1.45f*Level ); 
			Size = 1.3f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			NpcFlags = 0 ; Flags1 = 0x0104066 ;
			NpcType = (int)NpcTypes.Mechanical ;
			Faction = Factions.NoFaction ;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( EngineeringMechsDrops.MechanicalSquirrel, 100f ) };
		}
	}
	public class MithrilDragonling : BaseCreature 
	{ 
		public  MithrilDragonling() : base() 
		{ 
			Id = 8615 ;
			Name = "Mithril Dragonling" ;
			Model = 7908;
			Level = RandomLevel( 58 );
			AttackSpeed= 1000 ;
			BoundingRadius = 0.3197f ;
			CombatReach = 1.4375f ;
			BaseHitPoints = 4800 ;
			BaseMana = 0 ;
			Str = (int)(Level);
			Armor = (int)(26.4f*Level);
			Block=Level+10;
			SetDamage( 1.1f*Level, 1.45f*Level ); 
			Size = 1.15f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			NpcFlags = 0 ; Flags1 = 0x06 ;
			NpcType = (int)NpcTypes.Mechanical ;
			Faction = Factions.IronForge ;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( EngineeringMechsDrops.MithrilDragonling, 100f ) };
		}
	}
	public class TargetDummy : BaseCreature 
	{ 
		public  TargetDummy() : base() 
		{ 
			Id = 2673 ;
			Name = "Target Dummy" ;
			Model = 1555;
			Level = RandomLevel( 16 );
			AttackSpeed= 2000 ;
			BoundingRadius = 0.28f ;
			CombatReach = 5f ;
			BaseHitPoints = 800 ;
			BaseMana = 0 ;
			Str = (int)(Level);
			Armor = (int)(26.4f*Level);
			Block=Level+10;
			SetDamage( 1.1f*Level, 1.45f*Level ); 
			Size = 2.0f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			NpcFlags = 0 ; Flags1 = 0x0103102 ;
			NpcType = (int)NpcTypes.Mechanical ;
			Faction = Factions.NoFaction;
			AIEngine = new DefensiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( EngineeringMechsDrops.TargetDummy, 100f ) };
		}
	}
	public class TinyWalkingBomb : BaseCreature 
	{ 
		public  TinyWalkingBomb() : base() 
		{ 
			Id = 9656 ;
			Name = "Tiny Walking Bomb" ;
			Model = 8909;
			Level = RandomLevel( 1 );
			AttackSpeed= 2000 ;
			BoundingRadius = 0.225f ;
			CombatReach = 0.3f ;
			BaseHitPoints = 64 ;
			BaseMana = 0 ;
			Str = (int)(Level);
			Armor = (int)(26.4f*Level);
			Block=Level+10;
			SetDamage( 1.1f*Level, 1.45f*Level ); 
			Size = 0.15f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			NpcFlags = 0 ; Flags1 = 0x066 ;
			NpcType = (int)NpcTypes.Mechanical ;
			Faction = Factions.NoFaction ;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( EngineeringMechsDrops.TinyWalkingBomb, 100f ) };
		}
	}				
}