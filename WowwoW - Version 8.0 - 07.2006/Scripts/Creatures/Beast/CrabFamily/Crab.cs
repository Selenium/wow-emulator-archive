// Edited by DrilLer
//change damage and hitpoint
//	Script accepted by DrNexus - 22/05/05 12:11:03
//	Script made by Reguj - 21/05/05 11:20:28
// Crabs under lvl 11
// Reguj
using System;
using System.Collections;
using Server;
using Server.Items; 

namespace Server.Creatures
{
	public class BarbedCrustacean : BaseCreature
	{
		public BarbedCrustacean() : base()
		{
			Name = "Barbed Crustacean";
			Id = 4823;
			Model = 9565;
			Level = RandomLevel(25,26);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*3.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= 3189;
			Block= Level*2;
			Family=8;
			SetDamage(1f+2.5f*Level,1f+3.0*Level);
			ManaType=1;
 
			BaseMana = 0;			
			AttackSpeed = 2000;			
			BoundingRadius = 1.3f;
			CombatReach = 0.8f;
			Size = 1.3f;
			Elite=1;
			Speed = 3.6f;
			WalkSpeed = 3.6f;
			RunSpeed = 6.6f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 010;
			BCAddon.Hp( this, 1266, 25 );

			Loots = new BaseTreasure[]{  new BaseTreasure( CrabDrops.BarbedCrustacean , 100f )
										};
		}
	}
}




namespace Server.Creatures
{
	public class ClatteringCrawler : BaseCreature
	{
		public ClatteringCrawler() : base()
		{
			Name = "Clattering Crawler";
			Id = 3812;
			Model = 9566;
			Level = RandomLevel(19,20);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*31.2);
			Block= Level;
			Family=8;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1;

			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 1.1570f;
			CombatReach = 0.8f;
			Size = 1.15f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.NoFaction;
			AIEngine = new DefensiveAnimalAI( this );
			Flags1 = 0x080010;
			BCAddon.Hp( this, 342, 19 );

			Loots = new BaseTreasure[]{  new BaseTreasure( CrabDrops.ClatteringCrawler , 100f )
										};
		}
	}
}



namespace Server.Creatures
{
	public class CorruptedSurfCrawler : BaseCreature
	{
		public CorruptedSurfCrawler() : base()
		{
			Name = "Corrupted Surf Crawler";
			Id = 3228;
			Model = 1000;
			Level = RandomLevel(10,11);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*31.2);
			Block= Level;
			Family=8;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1;

			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 1.1570f;
			CombatReach = 0.8f;
			Size = 0.85f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );			
			Flags1 = 0x080010;
			BCAddon.Hp( this, 241, 10 );
			Loots = new BaseTreasure[]{  new BaseTreasure( CrabDrops.CorruptedSurfCrawler , 100f )
										};
		}
	}
}




namespace Server.Creatures
{
	public class Crawler : BaseCreature
	{
		public Crawler() : base()
		{
			Name = "Crawler";
			Id = 6250;
			Model = 641;
			Level = RandomLevel(11,12);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*31.2);
			Block= Level;
			Family=8;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1;

			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 1.1570f;
			CombatReach = 0.8f;
			Size = 0.85f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );			
			Flags1 = 0x080014;
			BCAddon.Hp( this, 291, 11 );
			Loots = new BaseTreasure[]{  new BaseTreasure( CrabDrops.Crawler , 100f )
										};
		}
	}
}




namespace Server.Creatures
{
	public class EncrustedSurfCrawler : BaseCreature
	{
		public EncrustedSurfCrawler() : base()
		{
			Name = "Encrusted Surf Crawler";
			Id = 3108;
			Model = 999;
			Level = RandomLevel(9,10);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*31.2);
			Block= Level;
			Family=8;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1;

			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 0.8570f;
			CombatReach = 0.8f;
			Size = 0.85f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.NoFaction;
			AIEngine = new DefensiveAnimalAI( this );		
			Flags1 = 0x080010;
			BCAddon.Hp( this, 182, 9 );
			Loots = new BaseTreasure[]{  new BaseTreasure( CrabDrops.EncrustedSurfCrawler , 100f )
										};
		}
	}
}




namespace Server.Creatures
{
	public class EncrustedTideCrawler : BaseCreature
	{
		public EncrustedTideCrawler() : base()
		{
			Name = "Encrusted Tide Crawler";
			Id = 2233;
			Model = 9566;
			Level = RandomLevel(18,20);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*31.2);
			Block= Level;
			Family=8;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1;

			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 1.1570f;
			CombatReach = 0.8f;
			Size = 1.15f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.NoFaction;
			AIEngine = new DefensiveAnimalAI( this );		
			Flags1 = 0x080010;
			BCAddon.Hp( this, 182, 18 );
			Loots = new BaseTreasure[]{  new BaseTreasure( CrabDrops.EncrustedTideCrawler , 100f )
										};
		}
	}
}



namespace Server.Creatures
{
	public class EnragedReefCrawler : BaseCreature
	{
		public EnragedReefCrawler() : base()
		{
			Name = "Enraged Reef Crawler";
			Id = 12347;
			Model = 1001;
			Level = RandomLevel(30,32);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*31.2);
			Block= Level;
			Family=8;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1;
 
			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 1.1570f;
			CombatReach = 0.8f;
			Size = 1.15f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.NoFaction;
			AIEngine = new DefensiveAnimalAI( this );		
			Flags1 = 0x080010;
			BCAddon.Hp( this, 960, 30 );
			Loots = new BaseTreasure[]{  new BaseTreasure( CrabDrops.EnragedReefCrawler , 100f )
										};
		}
	}
}



namespace Server.Creatures
{
	public class MonstrousCrawler : BaseCreature
	{
		public MonstrousCrawler() : base()
		{
			Name = "Monstrous Crawler";
			Id = 1088;
			Model = 699;
			Level = RandomLevel(43,44);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*31.2);
			Block= Level;
			Family=8;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1;

			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 1.570f;
			CombatReach = 0.8f;
			Size = 1.5f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.NoFaction;
			AIEngine = new DefensiveAnimalAI( this );		
			Flags1 = 0x080010;
			BCAddon.Hp( this, 1506, 43 );
			Loots = new BaseTreasure[]{  new BaseTreasure( CrabDrops.MonstrousCrawler , 100f )
										};
		}
	}
}



namespace Server.Creatures
{
	public class PygmySurfCrawler : BaseCreature
	{
		public PygmySurfCrawler() : base()
		{
			Name = "Pygmy Surf Crawler";
			Id = 3106;
			Model = 1307;
			Level = RandomLevel(2,6);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*31.2);
			Block= Level;
			Family=8;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1;
 
			BaseMana = 100;
			AttackSpeed = 2000;			
			BoundingRadius = 0.750f;
			CombatReach = 0.8f;
			Size = 0.75f;
			Speed = 3.0f;
			WalkSpeed = 3.0f;
			RunSpeed = 6.0f;
			Faction = Factions.NoFaction;
			AIEngine = new SpellCasterAI( this );
			Flags1 = 0x080010;
LearnSpell( 1604, SpellsTypes.Offensive );
			BCAddon.Hp( this, 104, 2 );
			Loots = new BaseTreasure[]{  new BaseTreasure( CrabDrops.PygmySurfCrawler , 100f )
										};
		}
	}
}




namespace Server.Creatures
{
	public class PygmyTideCrawler : BaseCreature
	{
		public PygmyTideCrawler() : base()
		{
			Name = "Pygmy Tide Crawler";
			Id = 2231;
			Model = 1000;
			Level = RandomLevel(9,11);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*31.2);
			Block= Level;
			Family=8;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1;
 
			BaseMana = 100;
			AttackSpeed = 2000;			
			BoundingRadius = 0.850f;
			CombatReach = 0.8f;
			Size = 0.85f;
			Speed = 3.0f;
			WalkSpeed = 3.0f;
			RunSpeed = 6.0f;
			Faction = Factions.NoFaction;
			AIEngine = new SpellCasterAI( this );
			Flags1 = 0x080010;
LearnSpell( 1604, SpellsTypes.Offensive );
BCAddon.Hp( this, 174, 9 );
			Loots = new BaseTreasure[]{  new BaseTreasure( CrabDrops.PygmyTideCrawler , 100f )
										};
		}
	}
}



namespace Server.Creatures
{
	public class RagingReefCrawler : BaseCreature
	{
		public RagingReefCrawler() : base()
		{
			Name = "Raging Reef Crawler";
			Id = 2236;
			Model = 1001;
			Level = RandomLevel(20,21);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*31.2);
			Block= Level;
			Family=8;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1;

			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 1.150f;
			CombatReach = 0.8f;
			Size = 1.15f;
			Speed = 3.0f;
			WalkSpeed = 3.0f;
			RunSpeed = 6.0f;
			Faction = Factions.NoFaction;
			AIEngine = new DefensiveAnimalAI( this );		
			Flags1 = 0x080010;
			BCAddon.Hp( this, 413, 20 );			
			Loots = new BaseTreasure[]{  new BaseTreasure( CrabDrops.RagingReefCrawler , 100f )
										};
		}
	}
}



namespace Server.Creatures
{
	public class ReefCrawler : BaseCreature
	{
		public ReefCrawler() : base()
		{
			Name = "Reef Crawler";
			Id = 2235;
			Model = 981;
			Level = RandomLevel(15,17);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*31.2);
			Block= Level;
			Family=8;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1;

			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 1.0f;
			CombatReach = 0.8f;
			Size = 1.15f;
			Speed = 3.0f;
			WalkSpeed = 3.0f;
			RunSpeed = 6.0f;
			Faction = Factions.NoFaction;
			AIEngine = new DefensiveAnimalAI( this );		
			Flags1 = 0x080010;
			BCAddon.Hp( this, 304, 15 );			
			Loots = new BaseTreasure[]{  new BaseTreasure( CrabDrops.ReefCrawler , 100f )
										};
		}
	}
}




namespace Server.Creatures
{
	public class SandCrawler : BaseCreature
	{
		public SandCrawler() : base()
		{
			Name = "Sand Crawler";
			Id = 830;
			Model = 342;
			Level = RandomLevel(13,14);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*31.2);
			Block= Level;
			Family=8;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1;

			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 1.0f;
			CombatReach = 0.8f;
			Size = 1.15f;
			Speed = 3.0f;
			WalkSpeed = 3.0f;
			RunSpeed = 6.0f;
			Faction = Factions.NoFaction;
			AIEngine = new DefensiveAnimalAI( this );		
			Flags1 = 0x080010;
			BCAddon.Hp( this, 301, 13 );			
			Loots = new BaseTreasure[]{  new BaseTreasure( CrabDrops.SandCrawler , 100f )
										};
		}
	}
}





namespace Server.Creatures
{
	public class SeaCrawler : BaseCreature
	{
		public SeaCrawler() : base()
		{
			Name = "Sea Crawler";
			Id = 831;
			Model = 979;
			Level = RandomLevel(15,16);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*31.2);
			Block= Level;
			Family=8;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1;

			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 1.0f;
			CombatReach = 0.8f;
			Size = 1.15f;
			Speed = 3.0f;
			WalkSpeed = 3.0f;
			RunSpeed = 6.0f;
			Faction = Factions.NoFaction;
			AIEngine = new DefensiveAnimalAI( this );		
			Flags1 = 0x080010;
			BCAddon.Hp( this, 336, 15 );			
			Loots = new BaseTreasure[]{  new BaseTreasure( CrabDrops.SeaCrawler , 100f )
										};
		}
	}
}




namespace Server.Creatures
{
	public class ShoreCrawler : BaseCreature
	{
		public ShoreCrawler() : base()
		{
			Name = "Shore Crawler";
			Id = 1216;
			Model = 9570;
			Level = RandomLevel(17,18);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*31.2);
			Block= Level;
			Family=8;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1;

			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 1.150f;
			CombatReach = 0.8f;
			Size = 1.15f;
			Speed = 3.0f;
			WalkSpeed = 3.0f;
			RunSpeed = 6.0f;
			Faction = Factions.NoFaction;
			AIEngine = new DefensiveAnimalAI( this );		
			Flags1 = 0x080010;
			BCAddon.Hp( this, 435, 17 );			
			Loots = new BaseTreasure[]{  new BaseTreasure( CrabDrops.ShoreCrawler , 100f )
										};
		}
	}
}



namespace Server.Creatures
{
	public class SilithidProtector : BaseCreature
	{
		public SilithidProtector() : base()
		{
			Name = "Silithid Protector";
			Id = 3503;
			Model = 1307;
			Level = RandomLevel(18,19);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*31.2);
			Block= Level;
			Family=8;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1;

			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 0.950f;
			CombatReach = 0.8f;
			Size = 0.9f;
			Speed = 3.0f;
			WalkSpeed = 3.0f;
			RunSpeed = 6.0f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );	
			Flags1 = 0x080010;	
			BCAddon.Hp( this, 435, 18 );		
			Loots = new BaseTreasure[]{  new BaseTreasure( CrabDrops.SilithidProtector , 100f )
										};
		}
	}
}




namespace Server.Creatures
{
	public class SiltCrawler : BaseCreature
	{
		public SiltCrawler() : base()
		{
			Name = "Silt Crawler";
			Id = 922;
			Model = 9571;
			Level = RandomLevel(40,41);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*31.2);
			Block= Level;
			Family=8;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1;

			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 1.30f;
			CombatReach = 0.8f;
			Size = 1.3f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.NoFaction;
			AIEngine = new DefensiveAnimalAI( this );		
			Flags1 = 0x080010;
			BCAddon.Hp( this, 1425, 40 );			
			Loots = new BaseTreasure[]{  new BaseTreasure( CrabDrops.SiltCrawler , 100f )
										};
		}
	}
}



namespace Server.Creatures
{
	public class SkitteringCrustacean : BaseCreature
	{
		public SkitteringCrustacean() : base()
		{
			Name = "Skittering Crustacean";
			Id = 4821;
			Model = 981;
			Level = RandomLevel(22,23);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*3.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= 3189;
			Block= Level*2;
			Family=8;
			SetDamage(1f+2.5f*Level,1f+3.0*Level);
			ManaType=1;

			BaseMana = 0;			
			AttackSpeed = 2000;			
			BoundingRadius = 1.03f;
			CombatReach = 0.8f;
			Size = 1.0f;
			Elite=1;
			Speed = 3.6f;
			WalkSpeed = 3.6f;
			RunSpeed = 6.6f;
			Faction = Factions.NoFaction;
			AIEngine = new DefensiveAnimalAI( this );
			Flags1 = 010;
			BCAddon.Hp( this, 1066, 22 );
			Loots = new BaseTreasure[]{  new BaseTreasure( CrabDrops.SkitteringCrustacean , 100f )
										};
		}
	}
}




namespace Server.Creatures
{
	public class SnappingCrustacean : BaseCreature
	{
		public SnappingCrustacean() : base()
		{
			Name = "Snapping Crustacean";
			Id = 4822;
			Model = 1001;
			Level = RandomLevel(23,24);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*3.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= 3189;
			Block= Level*2;
			Family=8;
			SetDamage(1f+2.5f*Level,1f+3.0*Level);
			ManaType=1;

			BaseMana = 0;			
			AttackSpeed = 2000;			
			BoundingRadius = 1.15f;
			CombatReach = 0.8f;
			Size = 1.15f;
			Elite=1;
			Speed = 3.6f;
			WalkSpeed = 3.6f;
			RunSpeed = 6.6f;
			Faction = Factions.NoFaction;
			AIEngine = new DefensiveAnimalAI( this );
			Flags1 = 010;
			BCAddon.Hp( this, 2022, 23 );
			Loots = new BaseTreasure[]{  new BaseTreasure( CrabDrops.SnappingCrustacean , 100f )
										};
		}
	}
}



namespace Server.Creatures
{
	public class SouthernSandCrawler : BaseCreature
	{
		public SouthernSandCrawler() : base()
		{
			Name = "Southern Sand Crawler";
			Id = 2544;
			Model = 9573;
			Level = RandomLevel(40,41);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*31.2);
			Block= Level;
			Family=8;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1;
			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 1.30f;
			CombatReach = 0.8f;
			Size = 1.3f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.NoFaction;
			AIEngine = new DefensiveAnimalAI( this );		
			Flags1 = 0x080010;
			BCAddon.Hp( this, 1926, 40 );			
			Loots = new BaseTreasure[]{  new BaseTreasure( CrabDrops.SouthernSandCrawler , 100f )
										};
		}
	}
}




namespace Server.Creatures
{
	public class SpinedCrawler : BaseCreature
	{
		public SpinedCrawler() : base()
		{
			Name = "Spined Crawler";
			Id = 3814;
			Model = 1001;
			Level = RandomLevel(20,21);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*31.2);
			Block= Level;
			Family=8;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1;

			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 1.15f;
			CombatReach = 0.8f;
			Size = 1.15f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.NoFaction;
			AIEngine = new DefensiveAnimalAI( this );		
			Flags1 = 0x080010;
			BCAddon.Hp( this, 495, 20 );			
			Loots = new BaseTreasure[]{  new BaseTreasure( CrabDrops.SpinedCrawler , 100f )
										};
		}
	}
}



namespace Server.Creatures
{
	public class SurfCrawler : BaseCreature
	{
		public SurfCrawler() : base()
		{
			Name = "Surf Crawler";
			Id = 3107;
			Model = 1001;
			Level = RandomLevel(5,8);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*31.2);
			Block= Level;
			Family=8;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1;

			BaseMana = 100;
			AttackSpeed = 2000;			
			BoundingRadius = 1.15f;
			CombatReach = 0.8f;
			Size = 0.85f;
			Speed = 2.9f;
			WalkSpeed = 2.9f;
			RunSpeed = 2.9f;
			Faction = Factions.NoFaction;
			AIEngine = new SpellCasterAI( this );
			Flags1 = 0x080010;
LearnSpell( 1604, SpellsTypes.Offensive );	
BCAddon.Hp( this, 144, 5 );		
			Loots = new BaseTreasure[]{  new BaseTreasure( CrabDrops.SurfCrawler , 100f )
										};
		}
	}
}




namespace Server.Creatures
{
	public class TideCrawler : BaseCreature
	{
		public TideCrawler() : base()
		{
			Name = "Tide Crawler";
			Id = 2232;
			Model = 979;
			Level = RandomLevel(12,14);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*31.2);
			Block= Level;
			Family=8;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1;

			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 1.0f;
			CombatReach = 0.8f;
			Size = 0.85f;
			Speed = 2.9f;
			WalkSpeed = 2.9f;
			RunSpeed = 2.9f;
			Faction = Factions.NoFaction;
			AIEngine = new DefensiveAnimalAI( this );		
			Flags1 = 0x080010;
			BCAddon.Hp( this, 301, 12 );
			Loots = new BaseTreasure[]{  new BaseTreasure( CrabDrops.TideCrawler , 100f )
										};
		}
	}
}





namespace Server.Creatures
{
	public class YoungReefCrawler : BaseCreature
	{
		public YoungReefCrawler() : base()
		{
			Name = "Young Reef Crawler";
			Id = 2234;
			Model = 999;
			Level = RandomLevel(12,14);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*31.2);
			Block= Level;
			Family=8;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1;
 
			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 0.85f;
			CombatReach = 0.8f;
			Size = 0.85f;
			Speed = 2.9f;
			WalkSpeed = 2.9f;
			RunSpeed = 2.9f;
			Faction = Factions.NoFaction;
			AIEngine = new DefensiveAnimalAI( this );		
			Flags1 = 0x080010;
			BCAddon.Hp( this, 301, 12 );
			Loots = new BaseTreasure[]{  new BaseTreasure( CrabDrops.YoungReefCrawler , 100f )
										};
		}
	}
}


