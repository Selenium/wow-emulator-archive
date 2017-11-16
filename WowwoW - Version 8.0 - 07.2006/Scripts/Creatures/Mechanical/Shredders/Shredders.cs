//originally Scripted By mmcs
using System;
using Server.Items;
using Server;

////////////////////
namespace Server.Creatures
{
	public class FrostwolfShredderUnit : BaseCreature 
	{ 
		public  FrostwolfShredderUnit() : base() 
		{ 
			Id = 13378 ;
			Name = "Frostwolf Shredder Unit" ;
			Model = 13310;
			Level = RandomLevel( 60 );
			AttackSpeed= 2000 ;
			BoundingRadius = 0.34f ;
			CombatReach = 2f ;
			BaseHitPoints = 7640 ;
			BaseMana = 0 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(42.2f*Level);
			Block=Level+30;
			SetDamage(1f+3.8f*Level,1f+4.5*Level); 
			Size = 1.0f;
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			Elite = 1 ;
			ResistArcane = 2*Level ;
			ResistHoly = 2*Level ;
			ResistShadow = 2*Level ;
			NpcFlags = 0 ; Flags1 = 0x000000 ;
			NpcType = (int)NpcTypes.Mechanical ;
			Faction = Factions.NoFaction;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( ShreddersDrops.FrostwolfShredderUnit, 100f ) };
		}
	}
	public class SneedsShredder : BaseCreature 
	{ 
		public  SneedsShredder() : base() 
		{ 
			Id = 642 ;
			Name = "Sneed's Shredder" ;
			Guild = "Lumbermaster" ;
			Model = 1269;
			Level = RandomLevel( 20 );
			AttackSpeed= 2000 ;
			BoundingRadius = 0.34f ;
			CombatReach = 2.0f ;
			BaseHitPoints = 3210 ;
			BaseMana = 0 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(42.2f*Level);
			Block=Level+30;
			SetDamage(1f+3.8f*Level,1f+4.5*Level); 
			Size = 1.0f;
			Speed = 3.58f ;
			WalkSpeed = 3.58f ;
			RunSpeed = 6.58f ;
			Elite = 1 ;
			ResistArcane = 2*Level ;
			ResistHoly = 2*Level ;
			ResistShadow = 2*Level ;
			NpcFlags = 0 ; Flags1 = 0x000000 ;
			NpcType = (int)NpcTypes.Mechanical ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( ShreddersDrops.SneedsShredder, 100f ) };
		}
	}			
	public class StormpikeShredderUnit : BaseCreature 
	{ 
		public  StormpikeShredderUnit() : base() 
		{ 
			Id = 13416 ;
			Name = "Stormpike Shredder Unit" ;
			Model = 13310;
			Level = RandomLevel( 60 );
			AttackSpeed= 2000 ;
			BoundingRadius = 0.34f ;
			CombatReach = 2f ;
			BaseHitPoints = 7640 ;
			BaseMana = 0 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(42.2f*Level);
			Block=Level+30;
			SetDamage(1f+3.8f*Level,1f+4.5*Level); 
			Size = 1.0f;
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			Elite = 1 ;
			ResistArcane = 2*Level ;
			ResistHoly = 2*Level ;
			ResistShadow = 2*Level ;
			NpcFlags = 0 ; Flags1 = 0x000000 ;
			NpcType = (int)NpcTypes.Mechanical ;
			Faction = Factions.NoFaction;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( ShreddersDrops.StormpikeShredderUnit, 100f ) };
		}
	}
	public class VentureCoShredder : BaseCreature 
	{ 
		public  VentureCoShredder() : base() 
		{ 
			Id = 4260 ;
			Name = "Venture Co. Shredder" ;
			Model = 1269;
			Level = RandomLevel( 37 );
			AttackSpeed= 2000 ;
			BoundingRadius = 0.34f ;
			CombatReach = 2f ;
			BaseHitPoints = 2730 ;
			BaseMana = 0 ;
			Str = (int)(Level);
			Armor = (int)(26.4f*Level);
			Block=Level+10;
			SetDamage( 1.08f*Level, 1.41f*Level ); 
			Size = 1.0f;
			Speed = 3.19f ;
			WalkSpeed = 3.19f ;
			RunSpeed = 6.19f ;
			NpcFlags = 0 ; Flags1 = 0x000000 ;
			NpcType = (int)NpcTypes.Mechanical ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( ShreddersDrops.VentureCoShredder, 100f ) };
		}
	}
	public class WarsongShredder : BaseCreature 
	{ 
		public  WarsongShredder() : base() 
		{ 
			Id = 11684 ;
			Name = "Warsong Shredder" ;
			Model = 1303;
			Level = RandomLevel( 27, 28 );
			AttackSpeed= 2000 ;
			BoundingRadius = 0.255f ;
			CombatReach = 1.5f ;
			BaseHitPoints = (int)(1768*Math.Pow(1.045f,Level-27)) ;
			BaseMana = 0 ;
			Str = (int)(Level);
			Armor = (int)(26.4f*Level);
			Block=Level+10;
			SetDamage( 1.08f*Level, 1.41f*Level ); 
			Size = 0.75f;
			Speed = 3.12f ;
			WalkSpeed = 3.12f ;
			RunSpeed = 6.12f ;
			NpcFlags = 0 ; Flags1 = 0x0400000 ;
			NpcType = (int)NpcTypes.Mechanical ;
			Faction = Factions.Horde;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( ShreddersDrops.WarsongShredder, 100f ) };
		}
	}				
	public class XT4 : BaseCreature 
	{ 
		public  XT4() : base() 
		{ 
			Id = 4073 ;
			Name = "XT:4" ;
			Model = 1269;
			Level = RandomLevel( 23 );
			AttackSpeed= 2000 ;
			BoundingRadius = 0.34f ;
			CombatReach = 2f ;
			BaseHitPoints = 1300 ;
			BaseMana = 0 ;
			Str = (int)(Level);
			Armor = (int)(26.4f*Level);
			Block=Level+10;
			SetDamage( 1.08f*Level, 1.41f*Level ); 
			Size = 1.0f;
			Speed = 3f ;
			WalkSpeed = 3f ;
			RunSpeed = 6f ;
			NpcFlags = 0 ; Flags1 = 0x0400000 ;
			NpcType = (int)NpcTypes.Mechanical ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( ShreddersDrops.XT4, 100f ) };
		}
	}
	public class XT9 : BaseCreature 
	{ 
		public  XT9() : base() 
		{ 
			Id = 4074 ;
			Name = "XT:9" ;
			Model = 1269;
			Level = RandomLevel( 23 );
			AttackSpeed= 2000 ;
			BoundingRadius = 0.34f ;
			CombatReach = 2f ;
			BaseHitPoints = 1300 ;
			BaseMana = 0 ;
			Str = (int)(Level);
			Armor = (int)(26.4f*Level);
			Block=Level+10;
			SetDamage( 1.1f*Level, 1.45f*Level ); 
			Size = 1.0f;
			Speed = 3f ;
			WalkSpeed = 3f ;
			RunSpeed = 6f ;
			NpcFlags = 0 ; Flags1 = 0x0400000 ;
			NpcType = (int)NpcTypes.Mechanical ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( ShreddersDrops.XT9, 100f ) };
		}
	}
}