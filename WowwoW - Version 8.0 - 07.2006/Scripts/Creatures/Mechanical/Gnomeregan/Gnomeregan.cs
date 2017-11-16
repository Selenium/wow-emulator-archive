//originally Scripted By mmcs
using System;
using Server.Items;
using Server;

////////////////////
namespace Server.Creatures
{
	public class Alarmabomb2600 : BaseCreature 
	{ 
		public  Alarmabomb2600() : base() 
		{ 
			Id = 7897 ;
			Name = "Alarm-a-bomb 2600" ;
			Model = 6888;
			Level = RandomLevel( 20 );
			AttackSpeed= 2000 ;
			BoundingRadius = 0.6f ;
			CombatReach = 0.8f ;
			BaseHitPoints = 1000 ;
			BaseMana = 0 ;
			Str = (int)(Level);
			Armor = (int)(26.4f*Level);
			Block=Level+10;
			SetDamage( 1.1f*Level, 1.45f*Level ); 
			Size = 0.4f;
			Speed = 3f ;
			WalkSpeed = 3f ;
			RunSpeed = 6f ;
			NpcFlags = 0 ; Flags1 = 0x066 ;
			NpcType = (int)NpcTypes.Mechanical ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( GnomereganDrops.Alarmabomb2600, 100f ) };
		}
	}
	public class ArcaneNullifierX21 : BaseCreature 
	{ 
		public  ArcaneNullifierX21() : base() 
		{ 
			Id = 6232 ;
			Name = "Arcane Nullifier X-21" ;
			Model = 6889;
			Level = RandomLevel( 33 );
			AttackSpeed= 2000 ;
			BoundingRadius = 1.125f ;
			CombatReach = 1.125f ;
			BaseHitPoints = 4450 ;
			BaseMana = 0 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(42.2f*Level);
			Block=Level+30;
			SetDamage(1f+3.8f*Level,1f+4.5*Level); 
			Size = 0.75f;
			Speed = 2.75f ;
			WalkSpeed = 2.75f ;
			RunSpeed = 5.75f ;
			Elite = 1 ;
			ResistArcane = 5*Level ;
			ResistHoly = 2*Level ;
			ResistShadow = 2*Level ;
			NpcFlags = 0 ; Flags1 = 0x000000 ;
			NpcType = (int)NpcTypes.Mechanical ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( GnomereganDrops.ArcaneNullifierX21, 100f ) };
		}
	}
	public class CrowdPummeler960 : BaseCreature 
	{ 
		public  CrowdPummeler960() : base() 
		{ 
			Id = 6229 ;
			Name = "Crowd Pummeler 9-60" ;
			Model = 6774;
			Level = RandomLevel( 32 );
			AttackSpeed= 2000 ;
			BoundingRadius = 1.65f ;
			CombatReach = 1.65f ;
			BaseHitPoints = 4100 ;
			BaseMana = 0 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(42.2f*Level);
			Block=Level+30;
			SetDamage(1f+3.8f*Level,1f+4.5*Level); 
			Size = 1.1f;
			Speed = 3.75f ;
			WalkSpeed = 3.75f ;
			RunSpeed = 6.75f ;
			Elite = 1 ;
			ResistArcane = 2*Level ;
			ResistHoly = 2*Level ;
			ResistShadow = 2*Level ;
			NpcFlags = 0 ; Flags1 = 0x01000 ;
			NpcType = (int)NpcTypes.Mechanical ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( GnomereganDrops.CrowdPummeler960, 100f ) };
		}
	}
	public class DarkIronLandMine : BaseCreature 
	{ 
		public  DarkIronLandMine() : base() 
		{ 
			Id = 8035 ;
			Name = "Dark Iron Land Mine" ;
			Model = 6271;
			Level = RandomLevel( 57 );
			AttackSpeed= 2000 ;
			BoundingRadius = 1f ;
			CombatReach = 1f ;
			BaseHitPoints = 4700 ;
			BaseMana = 0 ;
			Str = (int)(Level);
			Armor = (int)(26.4f*Level);
			Block=Level+10;
			SetDamage( 1.1f*Level, 1.45f*Level ); 
			Size = 1.0f;
			Speed = 2.9f ;
			WalkSpeed = 2.9f ;
			RunSpeed = 5.9f ;
			NpcFlags = 0 ; Flags1 = 0x0104106 ;
			NpcType = (int)NpcTypes.Mechanical ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( GnomereganDrops.DarkIronLandMine, 100f ) };
		}
	}
	public class Electrocutioner6000 : BaseCreature 
	{ 
		public  Electrocutioner6000() : base() 
		{ 
			Id = 6235 ;
			Name = "Electrocutioner 6000" ;
			Model = 6915;
			Level = RandomLevel( 32 );
			AttackSpeed= 2000 ;
			BoundingRadius = 1.2f ;
			CombatReach = 2.4f ;
			BaseHitPoints = 4100 ;
			BaseMana = 0 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(42.2f*Level);
			Block=Level+30;
			SetDamage(1f+3.8f*Level,1f+4.5*Level); 
			Size = 1.2f;
			Speed = 3.75f ;
			WalkSpeed = 3.75f ;
			RunSpeed = 6.75f ;
			Elite = 1 ;
			ResistArcane = 2*Level ;
			ResistHoly = 2*Level ;
			ResistShadow = 2*Level ;
			NpcFlags = 0 ; Flags1 = 0x01000 ;
			NpcType = (int)NpcTypes.Mechanical ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( GnomereganDrops.Electrocutioner6000, 100f ) };
		}
	}
	public class GoblinLandMine : BaseCreature 
	{ 
		public  GoblinLandMine() : base() 
		{ 
			Id = 7527 ;
			Name = "Goblin Land Mine" ;
			Model = 6271;
			Level = RandomLevel( 39 );
			AttackSpeed= 2000 ;
			BoundingRadius = 1f ;
			CombatReach = 1f ;
			BaseHitPoints = 2900 ;
			BaseMana = 0 ;
			Str = (int)(Level);
			Armor = (int)(26.4f*Level);
			Block=Level+10;
			SetDamage( 1.1f*Level, 1.45f*Level ); 
			Size = 1.0f;
			Speed = 3.24f ;
			WalkSpeed = 3.24f ;
			RunSpeed = 6.24f ;
			NpcFlags = 0 ; Flags1 = 0x0104106 ;
			NpcType = (int)NpcTypes.Mechanical ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( GnomereganDrops.GoblinLandMine, 100f ) };
		}
	}
	public class MechanizedGuardian : BaseCreature 
	{ 
		public  MechanizedGuardian() : base() 
		{ 
			Id = 6234 ;
			Name = "Mechanized Guardian" ;
			Model = 6979;
			Level = RandomLevel( 31 );
			AttackSpeed= 2000 ;
			BoundingRadius = 0.42f ;
			CombatReach = 3f ;
			BaseHitPoints = 4100 ;
			BaseMana = 0 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(42.2f*Level);
			Block=Level+30;
			SetDamage(1f+3.8f*Level,1f+4.5*Level); 
			Size = 1.2f;
			Speed = 3.7f ;
			WalkSpeed = 3.7f ;
			RunSpeed = 6.7f ;
			Elite = 1 ;
			ResistArcane = 2*Level ;
			ResistHoly = 2*Level ;
			ResistShadow = 2*Level ;
			NpcFlags = 0 ; Flags1 = 0x01000 ;
			NpcType = (int)NpcTypes.Mechanical ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( GnomereganDrops.MechanizedGuardian, 100f ) };
		}
	}
	public class MechanizedSentry : BaseCreature 
	{ 
		public  MechanizedSentry() : base() 
		{ 
			Id = 6233 ;
			Name = "Mechanized Sentry" ;
			Model = 6978;
			Level = RandomLevel( 28 );
			AttackSpeed= 2000 ;
			BoundingRadius = 0.35f ;
			CombatReach = 2.5f ;
			BaseHitPoints = 3800 ;
			BaseMana = 0 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(42.2f*Level);
			Block=Level+30;
			SetDamage(1f+3.8f*Level,1f+4.5*Level); 
			Size = 1.0f;
			Speed = 3.66f ;
			WalkSpeed = 3.66f ;
			RunSpeed = 6.66f ;
			Elite = 1 ;
			ResistArcane = 2*Level ;
			ResistHoly = 2*Level ;
			ResistShadow = 2*Level ;
			NpcFlags = 0 ; Flags1 = 0x01000 ;
			NpcType = (int)NpcTypes.Mechanical ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( GnomereganDrops.MechanizedSentry, 100f ) };
		}
	}
	public class MechanoFlamewalker : BaseCreature 
	{ 
		public  MechanoFlamewalker() : base() 
		{ 
			Id = 6226 ;
			Name = "Mechano-Flamewalker" ;
			Model = 6890;
			Level = RandomLevel( 30 );
			AttackSpeed= 2000 ;
			BoundingRadius = 1.1f ;
			CombatReach = 2.2f ;
			BaseHitPoints = 4000 ;
			BaseMana = 0 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(42.2f*Level);
			Block=Level+30;
			SetDamage(1f+3.8f*Level,1f+4.5*Level); 
			Size = 1.1f;
			Speed = 3.7f ;
			WalkSpeed = 3.7f ;
			RunSpeed = 6.7f ;
			Elite = 1 ;
			ResistArcane = 2*Level ;
			ResistHoly = 2*Level ;
			ResistShadow = 2*Level ;
			ResistFire = 5*Level ;
			NpcFlags = 0 ; Flags1 = 0x00000 ;
			NpcType = (int)NpcTypes.Mechanical ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( GnomereganDrops.MechanoFlamewalker, 100f ) };
		}
	}
	public class MechanoFrostwalker : BaseCreature 
	{ 
		public  MechanoFrostwalker() : base() 
		{ 
			Id = 6227 ;
			Name = "Mechano-Frostwalker" ;
			Model = 6891;
			Level = RandomLevel( 32 );
			AttackSpeed= 2000 ;
			BoundingRadius = 1.1f ;
			CombatReach = 2.2f ;
			BaseHitPoints = 4200 ;
			BaseMana = 0 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(42.2f*Level);
			Block=Level+30;
			SetDamage(1f+3.8f*Level,1f+4.5*Level); 
			Size = 1.1f;
			Speed = 3.7f ;
			WalkSpeed = 3.7f ;
			RunSpeed = 6.7f ;
			Elite = 1 ;
			ResistArcane = 2*Level ;
			ResistHoly = 2*Level ;
			ResistShadow = 2*Level ;
			ResistFrost = 5*Level ;
			NpcFlags = 0 ; Flags1 = 0x00000 ;
			NpcType = (int)NpcTypes.Mechanical ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( GnomereganDrops.MechanoFrostwalker, 100f ) };
		}
	}
	public class MechanoTank : BaseCreature 
	{ 
		public  MechanoTank() : base() 
		{ 
			Id = 6225 ;
			Name = "Mechano-Tank" ;
			Model = 5926;
			Level = RandomLevel( 30 );
			AttackSpeed= 2000 ;
			BoundingRadius = 1f ;
			CombatReach = 2f ;
			BaseHitPoints = 4000 ;
			BaseMana = 0 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(42.2f*Level);
			Block=Level+30;
			SetDamage(1f+3.8f*Level,1f+4.5*Level); 
			Size = 1.0f;
			Speed = 3.7f ;
			WalkSpeed = 3.7f ;
			RunSpeed = 6.7f ;
			Elite = 1 ;
			ResistArcane = 2*Level ;
			ResistHoly = 2*Level ;
			ResistShadow = 2*Level ;
			ResistFire = 4*Level ;			
			ResistFrost = 4*Level ;
			NpcFlags = 0 ; Flags1 = 0x00000 ;
			NpcType = (int)NpcTypes.Mechanical ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( GnomereganDrops.MechanoTank, 100f ) };
		}
	}
	public class MekgineerThermaplugg : BaseCreature 
	{ 
		public  MekgineerThermaplugg() : base() 
		{ 
			Id = 7800 ;
			Name = "Mekgineer Thermaplugg" ;
			Model = 6980;
			Level = RandomLevel( 34 );
			AttackSpeed= 2000 ;
			BoundingRadius = 2f ;
			CombatReach = 2.5f ;
			BaseHitPoints = 4400 ;
			BaseMana = 0 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(42.2f*Level);
			Block=Level+30;
			SetDamage(3f+3.8f*Level,3f+4.5*Level); 
			Size = 1.0f;
			Speed = 3.7f ;
			WalkSpeed = 3.7f ;
			RunSpeed = 6.7f ;
			Elite = 1 ;
			ResistArcane = 2*Level ;
			ResistHoly = 2*Level ;
			ResistShadow = 2*Level ;
			ResistFire = 5*Level ;			
			ResistFrost = 5*Level ;
			NpcFlags = 0 ; Flags1 = 0x080001000 ;
			NpcType = (int)NpcTypes.Mechanical ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( GnomereganDrops.MekgineerThermaplugg, 100f ) };
		}
	}
	public class MobileAlertSystem : BaseCreature 
	{ 
		public  MobileAlertSystem() : base() 
		{ 
			Id = 7849 ;
			Name = "Mobile Alert System" ;
			Model = 6888;
			Level = RandomLevel( 25 );
			AttackSpeed= 2000 ;
			BoundingRadius = 0.6f ;
			CombatReach = 0.8f ;
			BaseHitPoints = 1500 ;
			BaseMana = 0 ;
			Str = (int)(Level);
			Armor = (int)(26.4f*Level);
			Block=Level+10;
			SetDamage( 1.1f*Level, 1.45f*Level ); 
			Size = 0.4f;
			Speed = 3f ;
			WalkSpeed = 3f ;
			RunSpeed = 6f ;
			NpcFlags = 0 ; Flags1 = 0x06 ;
			NpcType = (int)NpcTypes.Mechanical ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( GnomereganDrops.MobileAlertSystem, 100f ) };
		}
	}
	public class PeacekeeperSecuritySuit : BaseCreature 
	{ 
		public  PeacekeeperSecuritySuit() : base() 
		{ 
			Id = 6230 ;
			Name = "Peacekeeper Security Suit" ;
			Model = 8369;
			Level = RandomLevel( 31 );
			AttackSpeed= 2000 ;
			BoundingRadius = 1.125f ;
			CombatReach = 1.125f ;
			BaseHitPoints = 4100 ;
			BaseMana = 0 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(42.2f*Level);
			Block=Level+30;
			SetDamage(1f+3.8f*Level,1f+4.5*Level); 
			Size = 0.75f;
			Speed = 3.7f ;
			WalkSpeed = 3.7f ;
			RunSpeed = 6.7f ;
			Elite = 1 ;
			ResistArcane = 2*Level ;
			ResistHoly = 2*Level ;
			ResistShadow = 2*Level ;
			NpcFlags = 0 ; Flags1 = 0x000000 ;
			NpcType = (int)NpcTypes.Mechanical ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( GnomereganDrops.PeacekeeperSecuritySuit, 100f ) };
		}
	}
	public class Techbot : BaseCreature 
	{ 
		public  Techbot() : base() 
		{ 
			Id = 6231 ;
			Name = "Techbot" ;
			Model = 7288;
			Level = RandomLevel( 26 );
			AttackSpeed= 2000 ;
			BoundingRadius = 1.5f ;
			CombatReach = 1.5f ;
			BaseHitPoints = 3600 ;
			BaseMana = 0 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(42.2f*Level);
			Block=Level+30;
			SetDamage(1f+3.8f*Level,1f+4.5*Level); 
			Size = 1.0f;
			Speed = 3.7f ;
			WalkSpeed = 3.7f ;
			RunSpeed = 6.7f ;
			Elite = 1 ;
			ResistArcane = 2*Level ;
			ResistHoly = 2*Level ;
			ResistShadow = 2*Level ;
			NpcFlags = 0 ; Flags1 = 0x000000 ;
			NpcType = (int)NpcTypes.Mechanical ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( GnomereganDrops.Techbot, 100f ) };
		}
	}
	public class WalkingBomb : BaseCreature 
	{ 
		public  WalkingBomb() : base() 
		{ 
			Id = 7915 ;
			Name = "Walking Bomb" ;
			Model = 6977;
			Level = RandomLevel( 30 );
			AttackSpeed= 2000 ;
			BoundingRadius = 0.75f ;
			CombatReach = 1.0f ;
			BaseHitPoints = 2000 ;
			BaseMana = 0 ;
			Str = (int)(Level);
			Armor = (int)(26.4f*Level);
			Block=Level+10;
			SetDamage( 1.1f*Level, 1.45f*Level ); 
			Size = 0.5f;
			Speed = 3.1f ;
			WalkSpeed = 3.1f ;
			RunSpeed = 6.1f ;
			NpcFlags = 0 ; Flags1 = 0x06 ;
			NpcType = (int)NpcTypes.Mechanical ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( GnomereganDrops.WalkingBomb, 100f ) };
		}
	}		
}