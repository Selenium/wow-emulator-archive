//originally Scripted By mmcs
using System;
using Server.Items;
using Server;

////////////////////
namespace Server.Creatures
{
	public class AdolescentWhelp : BaseCreature
	{
		public AdolescentWhelp() : base()
		{
			Id = 740 ;
			Name = "Adolescent Whelp" ;
			Model = 9582;
			Level = RandomLevel( 34, 35 );
			AttackSpeed= 2000;
			BoundingRadius = 0.3614f ;
			CombatReach = 1.62f ;
			BaseHitPoints = (int)(1784*Math.Pow(1.045f,Level-34)) ;
			BaseMana = (int)(2680*Math.Pow(1.045f,Level-34)) ;
			Str = (int)(Level);
			Armor = (int)(26.4f*Level);
			Block=Level+10;
			SetDamage( 1.08f*Level, 1.41f*Level ); 
			Size = 1.3f;
			Speed = 3.17f ;
			WalkSpeed = 3.17f ;
			RunSpeed = 6.17f ;
			ResistFire = Level ;
			NpcFlags = 0 ; Flags1 = 0x00000000 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( WhelpsDrops.AdolescentWhelp, 100f ) };
		}
	}
	public class Awbee : BaseCreature
	{
		public Awbee() : base()
		{
			Id = 10740 ;
			Name = "Awbee" ;
			Model = 6293;
			Level = RandomLevel( 57 );
			AttackSpeed= 1096 ;
			BoundingRadius = 1.0f ;
			CombatReach = 1.3f ;
			BaseHitPoints = 6918 ;
			BaseMana = 8565 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(42.2f*Level);
			Block=Level+30;
			SetDamage(1f+3.8f*Level,1f+4.5*Level); 
			Size = 1.3f;
			Speed = 4.03f ;
			WalkSpeed = 4.03f ;
			RunSpeed = 7.03f ;
			Elite = 1 ;
			ResistFire = 5*Level ;
			NpcFlags = (int)NpcActions.Dialog ; Flags1 = 0x06 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Friend;
			AIEngine = new StandingNpcAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( WhelpsDrops.Awbee, 100f ) };
		}
	}// need make quests
	public class BlackBroodling : BaseCreature
	{
		public BlackBroodling() : base()
		{
			Id = 7047 ;
			Name = "Black Broodling" ;
			Model = 397;
			Level = RandomLevel( 51, 52 );
			AttackSpeed= 2000;
			BoundingRadius = 0.417f ;
			CombatReach = 1.87f ;
			BaseHitPoints = (int)(4065*Math.Pow(1.045f,Level-51)) ;
			BaseMana = (int)(1864*Math.Pow(1.045f,Level-51)) ;
			Str = (int)(Level);
			Armor = (int)(26.4f*Level);
			Block=Level+10;
			SetDamage( 1.08f*Level, 1.41f*Level ); 
			Size = 1.5f;
			Speed = 3.31f ;
			WalkSpeed = 3.31f ;
			RunSpeed = 6.31f ;
			ResistFire = Level ;
			NpcFlags = 0 ; Flags1 = 0x00000000 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( WhelpsDrops.BlackBroodling, 100f ) };
		}
	}
	public class BlackDragonWhelp : BaseCreature
	{
		public BlackDragonWhelp() : base()
		{
			Id = 441 ;
			Name = "Black Dragon Whelp" ;
			Model = 387;
			Level = RandomLevel( 17, 18 );
			AttackSpeed= 2000;
			BoundingRadius = 0.2363f ;
			CombatReach = 1.06f ;
			BaseHitPoints = (int)(704*Math.Pow(1.045f,Level-17)) ;
			BaseMana = (int)(938*Math.Pow(1.045f,Level-17)) ;
			Str = (int)(Level);
			Armor = (int)(26.4f*Level);
			Block=Level+10;
			SetDamage( 1.08f*Level, 1.41f*Level );  
			Size = 0.85f;
			Speed = 3.02f ;
			WalkSpeed = 3.02f ;
			RunSpeed = 6.02f ;
			Family = 2 ;
			ResistFire = Level ;
			NpcFlags = 0 ; Flags1 = 0x00000000 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( WhelpsDrops.BlackDragonWhelp, 100f ) };
		}
	}
	public class BlinkDragon : BaseCreature
	{
		public BlinkDragon() : base()
		{
			Id = 3815 ;
			Name = "Blink Dragon" ;
			Model = 1267;
			Level = RandomLevel( 26, 27 );
			AttackSpeed= 2000;
			BoundingRadius = 1.0f ;
			CombatReach = 1.0f ;
			BaseHitPoints = (int)(1564*Math.Pow(1.045f,Level-26)) ;
			BaseMana = 0 ;
			Str = (int)(Level);
			Armor = (int)(26.4f*Level);
			Block=Level+10;
			SetDamage( 1.08f*Level, 1.41f*Level ); 
			Size = 1.0f;
			Speed = 3.11f ;
			WalkSpeed = 3.11f ;
			RunSpeed = 6.11f ;
			ResistFire = Level ;
			NpcFlags = 0 ; Flags1 = 0x00000000 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.NoFaction;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( WhelpsDrops.BlinkDragon, 100f ) };
		}
	}
	public class CapturedSpriteDarter : BaseCreature
	{
		public CapturedSpriteDarter() : base()
		{
			Id = 7997 ;
			Name = "Captured Sprite Darter" ;
			Model = 9345;
			Level = RandomLevel( 42, 43 );
			AttackSpeed= 2700;
			BoundingRadius = 0.9f ;
			CombatReach = 0.9f ;
			BaseHitPoints = (int)(3705*Math.Pow(1.045f,Level-42)) ;
			BaseMana = (int)(2432*Math.Pow(1.045f,Level-42)) ;
			Str = (int)(Level);
			Armor = (int)(26.4f*Level);
			Block=Level+10;
			SetDamage( 1.08f*Level, 1.41f*Level ); 
			Size = 0.9f;
			Speed = 3.24f ;
			WalkSpeed = 3.24f ;
			RunSpeed = 6.24f ;
			ResistFire = Level ;
			NpcFlags = 0 ; Flags1 = 0x020 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Friend; 
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( WhelpsDrops.CapturedSpriteDarter, 100f ) };
		}
	}	
	public class ChromaticWhelp : BaseCreature 
	{ 
		public  ChromaticWhelp() : base() 
		{ 
			Id = 10442 ;
			Name = "Chromatic Whelp" ;
			Model = 10095;
			Level = RandomLevel( 57, 58 );
			AttackSpeed= 1344;
			BoundingRadius = 1.00f ;
			CombatReach = 0.8f ;
			BaseHitPoints = (int)(4226*Math.Pow(1.045f,Level-57)) ;
			BaseMana = (int)(3755*Math.Pow(1.045f,Level-57)) ;
			Str = (int)(Level);
			Armor = (int)(26.4f*Level);
			Block=Level+10;
			SetDamage( 1.08f*Level, 1.41f*Level ); 
			Size = 1f;
			Speed = 3.34f ;
			WalkSpeed = 3.34f ;
			RunSpeed = 6.34f ;
			ResistFire = Level ;
			NpcType = (int)NpcTypes.Dragonkin ;
			NpcFlags = 0 ; Flags1 = 0x00000000 ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( WhelpsDrops.ChromaticWhelp, 100f ) };
		}
	}
	public class CobaltBroodling : BaseCreature 
	{ 
		public  CobaltBroodling() : base() 
		{ 
			Id = 10660 ;
			Name = "Cobalt Broodling" ; 
			Model = 10584;
			Level = RandomLevel( 55, 56 );
			AttackSpeed= 1344;
			BoundingRadius = 1.00f ;
			CombatReach = 0.8f ;
			BaseHitPoints = (int)(3226*Math.Pow(1.045f,Level-55)) ;
			BaseMana = (int)(3755*Math.Pow(1.045f,Level-55)) ;
			Str = (int)(Level);
			Armor = (int)(26.4f*Level);
			Block=Level+10;
			SetDamage( 1.08f*Level, 1.41f*Level ); 
			Size = 1f;
			Speed = 3.34f ;
			WalkSpeed = 3.34f ;
			RunSpeed = 6.34f ;
			ResistFire = Level ;
			NpcFlags = 0 ; Flags1 = 0x00000000 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( WhelpsDrops.CobaltBroodling, 100f ) };
		}
	}
	public class CobaltWhelp : BaseCreature 
	{ 
		public  CobaltWhelp() : base() 
		{ 
			Id = 10659 ;
			Name = "Cobalt Whelp" ;
			Model = 10585;
			Level = RandomLevel( 54, 55 );
			AttackSpeed= 1357;
			BoundingRadius = 1.00f ;
			CombatReach = 0.8f ;
			BaseHitPoints = (int)(3186*Math.Pow(1.045f,Level-54)) ;
			BaseMana = (int)(3705*Math.Pow(1.045f,Level-54)) ;
			Str = (int)(Level);
			Armor = (int)(26.4f*Level);
			Block=Level+10;
			SetDamage( 1.08f*Level, 1.41f*Level ); 
			Size = 1f;
			Speed = 3.33f ;
			WalkSpeed = 3.33f ;
			RunSpeed = 6.33f ;
			ResistFire = Level ;
			NpcFlags = 0 ; Flags1 = 0x00000000 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( WhelpsDrops.CobaltWhelp, 100f ) };
		}
	}
	public class CorruptedBlueWhelp : BaseCreature 
	{ 
		public  CorruptedBlueWhelp() : base() 
		{ 
			Id = 14024 ;
			Name = "Corrupted Blue Whelp" ;
			Model = 9994;
			Level = RandomLevel( 60 );
			AttackSpeed= 2000;
			BoundingRadius = 1.00f ;
			CombatReach = 3.0f ;
			BaseHitPoints = 5226 ;
			BaseMana = 0 ;
			Str = (int)(Level);
			Armor = (int)(26.4f*Level);
			Block=Level+10;
			SetDamage( 1.08f*Level, 1.41f*Level ); 
			Size = 1f;
			Speed = 3f ;
			WalkSpeed = 3f ;
			RunSpeed = 6f ;
			ResistFire = Level ;
			NpcType = (int)NpcTypes.Dragonkin ;
			NpcFlags = 0 ; Flags1 = 0x00000000 ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( WhelpsDrops.CorruptedBlueWhelp, 100f ) };
		}
	}
	public class CorruptedBronzeWhelp : BaseCreature 
	{ 
		public  CorruptedBronzeWhelp() : base() 
		{ 
			Id = 14025 ;
			Name = "Corrupted Bronze Whelp" ;
			Model = 14720;
			Level = RandomLevel( 60 );
			AttackSpeed= 2000;
			BoundingRadius = 1.00f ;
			CombatReach = 3.0f ;
			BaseHitPoints = 5226 ;
			BaseMana = 0 ;
			Str = (int)(Level);
			Armor = (int)(26.4f*Level);
			Block=Level+10;
			SetDamage( 1.08f*Level, 1.41f*Level ); 
			Size = 1f;
			Speed = 3f ;
			WalkSpeed = 3f ;
			RunSpeed = 6f ;
			ResistFire = Level ;
			NpcType = (int)NpcTypes.Dragonkin ;
			NpcFlags = 0 ; Flags1 = 0x00000000 ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( WhelpsDrops.CorruptedBronzeWhelp, 100f ) };
		}
	}	
	public class CorruptedGreenWhelp : BaseCreature 
	{ 
		public  CorruptedGreenWhelp() : base() 
		{ 
			Id = 14023 ;
			Name = "Corrupted Green Whelp" ;
			Model = 694;
			Level = RandomLevel( 60 );
			AttackSpeed= 2000;
			BoundingRadius = 1.00f ;
			CombatReach = 3.0f ;
			BaseHitPoints = 5226 ;
			BaseMana = 0 ;
			Str = (int)(Level);
			Armor = (int)(26.4f*Level);
			Block=Level+10;
			SetDamage( 1.08f*Level, 1.41f*Level ); 
			Size = 1f;
			Speed = 3f ;
			WalkSpeed = 3f ;
			RunSpeed = 6f ;
			ResistFire = Level ;
			NpcType = (int)NpcTypes.Dragonkin ;
			NpcFlags = 0 ; Flags1 = 0x00000000 ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( WhelpsDrops.CorruptedGreenWhelp, 100f ) };
		}
	}
	public class CorruptedRedWhelp : BaseCreature 
	{ 
		public  CorruptedRedWhelp() : base() 
		{ 
			Id = 14022 ;
			Name = "Corrupted Red Whelp" ;
			Model = 956;
			Level = RandomLevel( 60 );
			AttackSpeed= 2000;
			BoundingRadius = 1.00f ;
			CombatReach = 3.0f ;
			BaseHitPoints = 5226 ;
			BaseMana = 0 ;
			Str = (int)(Level);
			Armor = (int)(26.4f*Level);
			Block=Level+10;
			SetDamage( 1.08f*Level, 1.41f*Level ); 
			Size = 1f;
			Speed = 3f ;
			WalkSpeed = 3f ;
			RunSpeed = 6f ;
			ResistFire = Level ;
			NpcType = (int)NpcTypes.Dragonkin ;
			NpcFlags = 0 ; Flags1 = 0x00000000 ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( WhelpsDrops.CorruptedRedWhelp, 100f ) };
		}
	}					
	public class CrimsonWhelp : BaseCreature 
	{ 
		public  CrimsonWhelp() : base() 
		{ 
			Id = 1069 ;
			Name = "Crimson Whelp" ;
			Model = 505;
			Level = RandomLevel( 25, 26 );
			AttackSpeed= 2000;
			BoundingRadius = 0.319700f ;
			CombatReach = 1.5f ;
			BaseHitPoints = (int)(1024*Math.Pow(1.045f,Level-25)) ;
			BaseMana = (int)(655*Math.Pow(1.045f,Level-25)) ;
			Str = (int)(Level);
			Armor = (int)(26.4f*Level);
			Block=Level+10;
			SetDamage( 1.08f*Level, 1.41f*Level ); 
			Size = 1.15f;
			Speed = 3.10f ;
			WalkSpeed = 3.10f ;
			RunSpeed = 6.10f ;
			ResistFire = Level ;
			NpcFlags = 0 ; Flags1 = 0x00000000 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( WhelpsDrops.CrimsonWhelp, 100f ) };
		}
	}
	public class DarkWhelpling : BaseCreature 
	{ 
		public  DarkWhelpling() : base() 
		{ 
			Id = 7543 ;
			Name = "Dark Whelpling" ;
			Model = 6288;
			Level = RandomLevel( 1 );
			AttackSpeed= 2000;
			BoundingRadius = 0.139f ;
			CombatReach = 0.62f ;
			BaseHitPoints = 64 ;
			BaseMana = 0 ;
			Str = (int)(Level);
			Armor = (int)(26.4f*Level);
			Block=Level+10;
			SetDamage( 1.08f*Level, 1.41f*Level ); 
			Size = 0.5f;
			Speed = 2.91f ;
			WalkSpeed = 2.91f ;
			RunSpeed = 5.91f ;
			ResistFire = Level ;
			NpcFlags = 0 ; Flags1 = 0x066 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Friend;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( WhelpsDrops.DarkWhelpling, 100f ) };
		}
	}	
	public class DeviateFaerieDragon : BaseCreature 
	{ 
		public  DeviateFaerieDragon() : base() 
		{ 
			Id = 5912 ;
			Name = "Deviate Faerie Dragon" ;
			Model = 1267;
			Level = RandomLevel( 20 );
			AttackSpeed= 1528;
			BoundingRadius = 1.0f ;
			CombatReach = 1.0f ;
			BaseHitPoints = (int)(3296*Math.Pow(1.2f,Level-55)) ; 
			BaseMana = (int)(4012*Math.Pow(1.2f,Level-55)) ;
			Str = (int)(Level);
			Armor = (int)(26.4f*Level);
			Block=Level+10;
			SetDamage( 1.08f*Level, 1.41f*Level ); 
			Size = 1f;
			Speed = 3.70f ;
			WalkSpeed = 3.70f ;
			RunSpeed = 6.70f ;
			ResistFire = Level ;
			NpcFlags = 0 ; Flags1 = 0x00000000 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( WhelpsDrops.DeviateFaerieDragon, 100f ) };
		}
	}
	public class DreamingWhelp : BaseCreature 
	{ 
		public  DreamingWhelp() : base() 
		{ 
			Id = 741 ;
			Name = "Dreaming Whelp" ;
			Model = 621;
			Level = RandomLevel( 35, 36 );
			AttackSpeed= 2000;
			BoundingRadius = 0.319700f ;
			CombatReach = 1.5f ;
			BaseHitPoints = (int)(1424*Math.Pow(1.045f,Level-35)) ;
			BaseMana = (int)(2763*Math.Pow(1.045f,Level-35)) ;
			Str = (int)(Level);
			Armor = (int)(26.4f*Level);
			Block=Level+10;
			SetDamage( 1.08f*Level, 1.41f*Level ); 
			Size = 1.5f;
			Speed = 3.18f ;
			WalkSpeed = 3.18f ;
			RunSpeed = 6.18f ;
			ResistFire = Level ;
			NpcFlags = 0 ; Flags1 = 0x00000000 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( WhelpsDrops.DreamingWhelp, 100f ) };
		}
	}
	public class EldrethDarter : BaseCreature
	{
		public EldrethDarter() : base()
		{
			Id = 14398 ;
			Name = "Eldreth Darter" ;
			Model = 8471;
			Level = RandomLevel( 57, 59 );
			AttackSpeed= 2100;
			BoundingRadius = 1.0f ;
			CombatReach = 1.5f ;
			BaseHitPoints = 4670 ;
			BaseMana = 0 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(42.2f*Level);
			Block=Level+30;
			SetDamage(1f+3.8f*Level,1f+4.5*Level); 
			Size = 1.0f;
			Speed = 3f ;
			WalkSpeed = 3f ;
			RunSpeed = 6f ;
			Elite = 1 ;
			ResistFire = 5*Level ;
			NpcFlags = 0 ; Flags1 = 0x0266 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( WhelpsDrops.EldrethDarter, 100f ) };
		}
	}
	
	// Emerald Dragon Whelp
	
	public class FeyDragon : BaseCreature 
	{ 
		public  FeyDragon() : base() 
		{ 
			Id = 4016 ;
			Name = "Fey Dragon" ;
			Model = 1267;
			Level = RandomLevel( 24, 25 );
			AttackSpeed= 1778;
			BoundingRadius = 1.0f ;
			CombatReach = 1.0f ;
			BaseHitPoints = (int)(984*Math.Pow(1.045f,Level-24)) ; 
			BaseMana = (int)(1203*Math.Pow(1.045f,Level-24)) ;
			Str = (int)(Level);
			Armor = (int)(26.4f*Level);
			Block=Level+10;
			SetDamage( 1.08f*Level, 1.41f*Level ); 
			Size = 1.0f;
			Speed = 3.09f ;
			WalkSpeed = 3.09f ;
			RunSpeed = 6.09f ;
			ResistFire = Level ;
			NpcFlags = 0 ; Flags1 = 0x00000000 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( WhelpsDrops.FeyDragon, 100f ) };
		}
	}
	public class FlamescaleBroodling : BaseCreature 
	{ 
		public  FlamescaleBroodling() : base() 
		{ 
			Id = 7049 ;
			Name = "Flamescale Broodling" ;
			Model = 457;
			Level = RandomLevel( 56 );
			AttackSpeed= 1750;
			BoundingRadius = 0.556f ;
			CombatReach = 2.5f ;
			BaseHitPoints = 4226 ;
			BaseMana = 4163 ;
			Str = (int)(Level);
			Armor = (int)(26.4f*Level);
			Block=Level+10;
			SetDamage( 1.08f*Level, 1.41f*Level ); 
			Size = 2.0f;
			Speed = 3.33f ;
			WalkSpeed = 3.33f ;
			RunSpeed = 6.33f ;
			ResistFire = Level ;
			NpcFlags = 0 ; Flags1 = 0x00000000 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( WhelpsDrops.FlamescaleBroodling, 100f ) };
		}
	}	
	public class FlamesnortingWhelp : BaseCreature 
	{ 
		
		public  FlamesnortingWhelp() : base() 
		{ 
			Id = 1044 ;
			Name = "Flamesnorting Whelp" ;
			Model = 8712;
			Level = RandomLevel( 26, 27 );
			AttackSpeed= 1750;
			BoundingRadius = 1.0f ;
			CombatReach = 0.8f ;
			BaseHitPoints = (int)(1064*Math.Pow(1.045f,Level-26)) ;
			BaseMana = (int)(1303*Math.Pow(1.045f,Level-26)) ;
			Str = (int)(Level);
			Armor = (int)(26.4f*Level);
			Block=Level+10;
			SetDamage( 1.08f*Level, 1.41f*Level ); 
			Size = 1.0f;
			Speed = 3.11f ;
			WalkSpeed = 3.11f ;
			RunSpeed = 6.11f ;
			ResistFire = Level ;
			NpcFlags = 0 ; Flags1 = 0x00000000 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( WhelpsDrops.FlamesnortingWhelp, 100f ) };
		}
	}
	public class LostWhelp : BaseCreature 
	{ 
		public  LostWhelp() : base() 
		{ 
			Id = 1043 ;
			Name = "Lost Whelp" ;
			Model = 956;
			Level = RandomLevel( 24, 25 );
			AttackSpeed= 2000;
			BoundingRadius = 0.278000f ;
			CombatReach = 1.25f ;
			BaseHitPoints = (int)(984*Math.Pow(1.045f,Level-24)) ;
			BaseMana = (int)(655*Math.Pow(1.045f,Level-24)) ;
			Str = (int)(Level);
			Armor = (int)(26.4f*Level);
			Block=Level+10;
			SetDamage( 1.08f*Level, 1.41f*Level ); 
			Size = 1.0f;
			Speed = 3.09f ;
			WalkSpeed = 3.09f ;
			RunSpeed = 6.09f ;
			ResistFire = Level ;
			NpcFlags = 0 ; Flags1 = 0x00000000 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( WhelpsDrops.LostWhelp, 100f ) };
		}
	}
	public class Naltaszar : BaseCreature 
	{ 
		public  Naltaszar() : base() 
		{ 
			Id = 4066 ;
			Name = "Nal'taszar" ;
			Model = 8471;
			Level = RandomLevel( 30 );
			AttackSpeed= 1411;
			BoundingRadius = 1.0f ;
			CombatReach = 1.5f ;
			BaseHitPoints = 5896 ;
			BaseMana = 6012 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(60.2f*Level);
			Block=Level+40;
			SetDamage(1f+3.8f*Level,1f+4.5*Level); 
			Size = 1.0f;
			Speed = 3.82f ;
			WalkSpeed = 3.82f ;
			RunSpeed = 6.82f ;
			ResistFire = 5*Level ;
			Elite = 2 ;
			NpcFlags = 0 ; Flags1 = 0x00000000 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( WhelpsDrops.Naltaszar, 100f ) };
		}
	}	
	public class NightmareWhelp : BaseCreature 
	{ 
		public  NightmareWhelp() : base() 
		{ 
			Id = 8319 ;
			Name = "Nightmare Whelp" ;
			Model = 621;
			Level = RandomLevel( 48, 50 );
			AttackSpeed= 2000;
			BoundingRadius = 0.417f ;
			CombatReach = 1.87f ;
			BaseHitPoints = (int)(2985*Math.Pow(1.045f,Level-48)) ;
			BaseMana = 0 ;
			Str = (int)(Level);
			Armor = (int)(26.4f*Level);
			Block=Level+10;
			SetDamage( 1.08f*Level, 1.41f*Level ); 
			Size = 1.5f;
			Speed = 3.29f ;
			WalkSpeed = 3.29f ;
			RunSpeed = 6.29f ;
			ResistFire = Level ;
			NpcFlags = 0 ; Flags1 = 0x00000000 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( WhelpsDrops.NightmareWhelp, 100f ) };
		}
	}
	public class OnyxianWhelp : BaseCreature 
	{ 
		public  OnyxianWhelp() : base() 
		{ 
			Id = 11262 ;
			Name = "Onyxian Whelp" ;
			Model = 399;
			Level = RandomLevel( 56, 57 );
			AttackSpeed= 2000;
			BoundingRadius = 5.372000f ;
			CombatReach = 11.500000f ;
			BaseHitPoints = 7000 ;
			BaseMana = 7000 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(42.2f*Level);
			Block=Level+30;
			SetDamage(1f+3.8f*Level,1f+4.5*Level); 
			Size = 1.2f;
			Speed = 4.09f ;
			WalkSpeed = 4.09f ;
			RunSpeed = 6.09f ;
			Elite = 1 ;
			ResistFire = 5*Level ;			
			NpcFlags = 0 ; Flags1 = 0x00000000 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( WhelpsDrops.OnyxianWhelp, 100f ) };
		}
	}
	public class PlaguedHatchling : BaseCreature 
	{ 
		public  PlaguedHatchling() : base() 
		{ 
			Id = 10678 ;
			Name = "Plagued Hatchling" ;
			Model = 10007;
			Level = RandomLevel( 57, 59 );
			AttackSpeed= 1330;
			BoundingRadius = 1.0f ;
			CombatReach = 0.8f ;
			BaseHitPoints = (int)(4266*Math.Pow(1.045f,Level-57)) ;
			BaseMana = (int)(4805*Math.Pow(1.045f,Level-57)) ;
			Str = (int)(Level);
			Armor = (int)(26.4f*Level);
			Block=Level+10;
			SetDamage( 1.08f*Level, 1.41f*Level );  
			Size = 1.0f;
			Speed = 3.35f ;
			WalkSpeed = 3.35f ;
			RunSpeed = 6.35f ;
			ResistFire = Level ;
			NpcFlags = 0 ; Flags1 = 0x00000000 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( WhelpsDrops.PlaguedHatchling, 100f ) };
		}
	}	
	public class RedWhelp : BaseCreature 
	{ 
		public  RedWhelp() : base() 
		{ 
			Id = 1042 ;
			Name = "Red Whelp" ;
			Model = 9583;
			Level = RandomLevel( 23, 24 );
			AttackSpeed= 2000;
			BoundingRadius = 0.2363f ;
			CombatReach = 1.06f ;
			BaseHitPoints = (int)(984*Math.Pow(1.045f,Level-23)) ;
			BaseMana = 0 ;
			Str = (int)(Level);
			Armor = (int)(26.4f*Level);
			Block=Level+10;
			SetDamage( 1.08f*Level, 1.41f*Level ); 
			Size = 0.85f;
			Speed = 3.08f ;
			WalkSpeed = 3.08f ;
			RunSpeed = 6.08f ;
			ResistFire = Level ;
			NpcFlags = 0 ; Flags1 = 0x00000000 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( WhelpsDrops.RedWhelp, 100f ) };
		}
	}
	public class RookeryWhelp : BaseCreature 
	{ 
		public  RookeryWhelp() : base() 
		{ 
			Id = 10161 ;
			Name = "Rookery Whelp" ;
			Model = 397;
			Level = RandomLevel( 56, 57 );
			AttackSpeed= 1330;
			BoundingRadius = 1.0f ;
			CombatReach = 1.3f ;
			BaseHitPoints = (int)(3266*Math.Pow(1.045f,Level-56)) ;
			BaseMana = (int)(3805*Math.Pow(1.045f,Level-56)) ;
			Str = (int)(Level);
			Armor = (int)(26.4f*Level);
			Block=Level+10;
			SetDamage( 1.08f*Level, 1.41f*Level );  
			Size = 1.0f;
			Speed = 3.35f ;
			WalkSpeed = 3.35f ;
			RunSpeed = 6.35f ;
			ResistFire = Level ;
			NpcFlags = 0 ; Flags1 = 0x06 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( WhelpsDrops.RookeryWhelp, 100f ) };
		}
	}
	public class ScaldingBroodling : BaseCreature 
	{ 
		public  ScaldingBroodling() : base() 
		{ 
			Id = 7048 ;
			Name = "Scalding Broodling" ;
			Model = 400;
			Level = RandomLevel( 53, 54 );
			AttackSpeed= 2000;
			BoundingRadius = 0.4865f ;
			CombatReach = 2.18f ;
			BaseHitPoints = (int)(4186*Math.Pow(1.045f,Level-53)) ;
			BaseMana = (int)(4765*Math.Pow(1.045f,Level-53)) ;
			Str = (int)(Level);
			Armor = (int)(26.4f*Level);
			Block=Level+10;
			SetDamage( 1.08f*Level, 1.41f*Level ); 
			Size = 1.75f;
			Speed = 3.33f ;
			WalkSpeed = 3.33f ;
			RunSpeed = 6.33f ;
			ResistFire = Level ;
			NpcFlags = 0 ; Flags1 = 0x06 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( WhelpsDrops.ScaldingBroodling, 100f ) };
		}
	}	
	public class ScaldingWhelp : BaseCreature 
	{ 
		public  ScaldingWhelp() : base() 
		{ 
			Id = 2725 ;
			Name = "Scalding Whelp" ;
			Model = 715;
			Level = RandomLevel( 41, 43 );
			AttackSpeed= 2000;
			BoundingRadius = 0.3614f ;
			CombatReach = 1.62f ;
			BaseHitPoints = (int)(2705*Math.Pow(1.045f,Level-41)) ;
			BaseMana = (int)(2381*Math.Pow(1.045f,Level-41)) ;
			Str = (int)(Level);
			Armor = (int)(26.4f*Level);
			Block=Level+10;
			SetDamage( 1.08f*Level, 1.41f*Level ); 
			Size = 1.3f;
			Speed = 3.23f ;
			WalkSpeed = 3.23f ;
			RunSpeed = 6.23f ;
			ResistFire = Level ;
			NpcFlags = 0 ; Flags1 = 0x00000000 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( WhelpsDrops.ScaldingWhelp, 100f ) };
		}
	}
	public class SearingHatchling : BaseCreature 
	{ 
		public  SearingHatchling() : base() 
		{ 
			Id = 4323 ;
			Name = "Searing Hatchling" ;
			Model = 715;
			Level = RandomLevel( 41, 42 );
			AttackSpeed= 2000;
			BoundingRadius = 0.3614f ;
			CombatReach = 1.62f ;
			BaseHitPoints = (int)(7000*Math.Pow(1.045f,Level-41)) ;
			BaseMana = (int)(3580*Math.Pow(1.045f,Level-41)) ;
			Str = (int)(Level);
			Armor = (int)(26.4f*Level);
			Block=Level+10;
			SetDamage( 1.08f*Level, 1.41f*Level );  
			Size = 1.3f;
			Speed = 3.23f ;
			WalkSpeed = 3.23f ;
			RunSpeed = 6.23f ;
			ResistFire = Level ;
			NpcFlags = 0 ; Flags1 = 0x00000000 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( WhelpsDrops.SearingHatchling, 100f ) };
		}
	}		
	public class SearingWhelp : BaseCreature 
	{ 
		public  SearingWhelp() : base() 
		{ 
			Id = 4324 ;
			Name = "Searing Whelp" ;
			Model = 397;
			Level = RandomLevel( 42, 43 );
			AttackSpeed= 2000;
			BoundingRadius = 0.417f ;
			CombatReach = 1.87f ;
			BaseHitPoints = (int)(3000*Math.Pow(1.045f,Level-42)) ;
			BaseMana = (int)(3580*Math.Pow(1.045f,Level-42)) ;
			Str = (int)(Level);
			Armor = (int)(26.4f*Level);
			Block=Level+10;
			SetDamage( 1.08f*Level, 1.41f*Level );  
			Size = 1.5f;
			Speed = 3.24f ;
			WalkSpeed = 3.24f ;
			RunSpeed = 6.24f ;
			ResistFire = Level ;
			NpcFlags = 0 ; Flags1 = 0x00000000 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( WhelpsDrops.SearingWhelp, 100f ) };
		}
	}
	public class Singe : BaseCreature 
	{ 
		public  Singe() : base() 
		{ 
			Id = 335 ;
			Name = "Singe" ;
			Model = 497;
			Level = RandomLevel( 24 );
			AttackSpeed= 2000;
			BoundingRadius = 0.278f ;
			CombatReach = 1.25f ;
			BaseHitPoints = 2832 ;
			BaseMana = 1545 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(42.2f*Level);
			Block=Level+30;
			SetDamage(1f+3.8f*Level,1f+4.5*Level); 
			Size = 1.0f;
			Speed = 3.65f ;
			WalkSpeed = 3.65f ;
			RunSpeed = 6.65f ;
			Elite = 1 ;
			ResistFire = 5*Level ;
			NpcFlags = 0 ; Flags1 = 0x00000000 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( WhelpsDrops.Singe, 100f ) };
		}
	}
	public class  Snarlflare : BaseCreature 
	{ 
		public   Snarlflare() : base() 
		{ 
			Id = 14272 ;
			Name = "Snarlflare" ;
			Model = 497;
			Level = RandomLevel( 24 );
			AttackSpeed= 2000;
			BoundingRadius = 0.51f ;
			CombatReach = 1.5f ;
			BaseHitPoints = 5200 ;
			BaseMana = 1545 ;
			Str = (int)(Level);
			Armor = (int)(26.4f*Level);
			Block=Level+10;
			SetDamage( 1.08f*Level, 1.41f*Level ); 
			Size = 1.0f;
			Speed = 3f ;
			WalkSpeed = 3f ;
			RunSpeed = 6f ;
			Elite = 4 ;
			ResistFire = 2*Level ;
			NpcFlags = 0 ; Flags1 = 0x00000000 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( WhelpsDrops.Snarlflare, 100f ) };
		}
	}	
	public class SpellEater : BaseCreature 
	{ 
		public  SpellEater() : base() 
		{ 
			Id = 10661 ;
			Name = "Spell Eater" ;
			Model = 10583;
			Level = RandomLevel( 54, 56 );
			AttackSpeed= 1344;
			BoundingRadius = 1.0f ;
			CombatReach = 1.5f ;
			BaseHitPoints = (int)(4186*Math.Pow(1.045f,Level-54)) ;
			BaseMana = (int)(4755*Math.Pow(1.045f,Level-54)) ;
			Str = (int)(Level);
			Armor = (int)(26.4f*Level);
			Block=Level+10;
			SetDamage( 1.08f*Level, 1.41f*Level ); 
			Size = 1.0f;
			Speed = 3.34f ;
			WalkSpeed = 3.34f ;
			RunSpeed = 6.34f ;
			ResistFire = Level ;
			NpcFlags = 0 ; Flags1 = 0x00000000 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( WhelpsDrops.SpellEater, 100f ) };
		}
	}
	public class SpriteDarter : BaseCreature 
	{ 
		public  SpriteDarter() : base() 
		{ 
			Id = 5278 ;
			Name = "Sprite Darter" ;
			Model = 2158;
			Level = RandomLevel( 43, 45 );
			AttackSpeed= 2000;
			BoundingRadius = 1.15f ;
			CombatReach = 1.15f ;
			BaseHitPoints = (int)(3745*Math.Pow(1.045f,Level-43)) ;
			BaseMana = (int)(3483*Math.Pow(1.045f,Level-43)) ;
			Str = (int)(Level);
			Armor = (int)(26.4f*Level);
			Block=Level+10;
			SetDamage( 1.08f*Level, 1.41f*Level ); 
			Size = 1.15f;
			Speed = 3.24f ;
			WalkSpeed = 3.24f ;
			RunSpeed = 6.24f ;
			ResistFire = Level ;
			NpcFlags = 0 ; Flags1 = 0x00000000 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Friend;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( WhelpsDrops.SpriteDarter, 100f ) };
		}
	}
	public class SpriteDragon : BaseCreature 
	{ 
		public  SpriteDragon() : base() 
		{ 
			Id = 5276 ;
			Name = "Sprite Dragon" ;
			Model = 8471;
			Level = RandomLevel( 47, 50 );
			AttackSpeed= 2000;
			BoundingRadius = 1.3f ;
			CombatReach = 1.3f ;
			BaseHitPoints = (int)(2945*Math.Pow(1.045f,Level-47)) ;
			BaseMana = (int)(2807*Math.Pow(1.045f,Level-47)) ;
			Str = (int)(Level);
			Armor = (int)(26.4f*Level);
			Block=Level+10;
			SetDamage( 1.08f*Level, 1.41f*Level ); 
			Size = 1.3f;
			Speed = 3.28f ;
			WalkSpeed = 3.28f ;
			RunSpeed = 6.28f ;
			ResistFire = Level ;
			NpcFlags = 0 ; Flags1 = 0x00000000 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.NoFaction;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( WhelpsDrops.SpriteDragon, 100f ) };
		}
	}
	public class WilyFeyDragon : BaseCreature 
	{ 
		public  WilyFeyDragon() : base() 
		{ 
			Id = 4017 ;
			Name = "Wily Fey Dragon" ;
			Model = 2158;
			Level = RandomLevel( 26, 27 );
			AttackSpeed= 1750;
			BoundingRadius = 1.15f ;
			CombatReach = 1.15f ;
			BaseHitPoints = (int)(1064*Math.Pow(1.045f,Level-47)) ;
			BaseMana = (int)(1303*Math.Pow(1.045f,Level-47)) ;
			Str = (int)(Level);
			Armor = (int)(26.4f*Level);
			Block=Level+10;
			SetDamage( 1.08f*Level, 1.41f*Level ); 
			Size = 1.15f;
			Speed = 3.11f ;
			WalkSpeed = 3.11f ;
			RunSpeed = 6.11f ;
			ResistFire = Level ;
			NpcFlags = 0 ; Flags1 = 0x00000000 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( WhelpsDrops.WilyFeyDragon, 100f ) };
		}
	}
}