//////////////////////////////////////////////////////////////////////////////
// 
// 			 "Ram"
// Made by Dr Nexus
//////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections;
using Server;
using Server.Items;

///////////////////////////////////////////
namespace Server.Creatures
{
	public class Ram : BaseCreature
	{
		public Ram() : base()
		{
			AttackSpeed = 2000-(Level-1)*13;
			ManaType=1;
			BaseHitPoints = 150+33*Level;
			BoundingRadius = 0.350000f;
			SetDamage(1f+1.8f*Level,1f+2.66*Level);			
			NpcType = 1;
			Model = 10000;
			NpcFlags = 0;
			Level = RandomLevel( 4, 10 );
			Name = "Ram";
			CombatReach = 2.500000f;
			Flags1 = 0x0104006;
			Unk3 = 8;
			Speed = 2;
			RunSpeed = 6f;
			WalkSpeed = 2f;			
			Faction = Factions.NoFaction;
			AIEngine = new NonAgressiveAnimalAI( this ); 			
			Id = 2098;
			SkinLoot = new Loot[] { new Loot( typeof( RuinedLeatherScraps ), 90.0f )
					          ,new Loot( typeof( LightLeather ), 10.0f )};			
		}
	}
}
///////////////////////////////////////////
namespace Server.Creatures
{
	public class Cow : BaseCreature
	{
		public Cow() : base()
		{
			AttackSpeed = 2000-(Level-1)*13;
			ManaType=1;
			BoundingRadius = 0.893000f;
			SetDamage( 12.857142, 15.857142 );
			BaseHitPoints = 150+33*Level;			
			NpcType = 1;
			Model = 1060;
			NpcFlags = 0;
			Level = RandomLevel( 5, 10 );
			Name = "Cow";
			CombatReach = 1.500000f;
			Flags1 = 0x0104006;
			Unk3 = 8;
			Faction = Factions.NoFaction;
			AIEngine = new NonAgressiveAnimalAI( this ); 
			Speed = 1.4f;
			RunSpeed = 3.3f;
			WalkSpeed = 1.4f;						
			Id = 2442;
			SkinLoot = new Loot[] { new Loot( typeof( RuinedLeatherScraps ), 90.0f )
					          ,new Loot( typeof( LightLeather ), 10.0f )};
			
		}
	}
}
///////////////////////////////////////////
namespace Server.Creatures
{
	public class Snake : BaseCreature
	{
		public Snake() : base()
		{
			AttackSpeed = 2000-(Level-1)*13;
			ManaType=1;
			BoundingRadius = 0.350000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 1;
			Model = 1206;
			NpcFlags = 0;
			Level = RandomLevel( 1, 1 );
			Name = "Snake";
			CombatReach = 0.500000f;
			Flags1 = 0x010080006;
			Faction = Factions.NoFaction;
			AIEngine = new NonAgressiveAnimalAI( this ); 
			Speed = 3;
			RunSpeed = 5f;
			WalkSpeed = 3f;							
			Id = 2914;
			Loots = new BaseTreasure[]{ new BaseTreasure( SnakeDrops.Snake, 100.0f )};
		}
	}
}
///////////////////////////////////////////

namespace Server
{
	public class SnakeDrops
	{
		public static Loot[] Snake = new Loot[] {  new Loot( typeof( GreaterMagicEssence), 0.045f )
							 , new Loot( typeof( LesserMagicEssence ), 0.045f )
							 , new Loot( typeof( SeersPants), 0.045f )
							  , new Loot( typeof( AtalaiTablet), 10.54f )
							  , new Loot( typeof( Blindweed), 0.385f )
							  , new Loot( typeof( BloodpetalSprout), 0.769f )
							  , new Loot( typeof( BluePowerCrystal), 0.192f )
							  , new Loot( typeof( CopperOre), 0.385f )
							  , new Loot( typeof( DreamDust), 0.577f )
							  , new Loot( typeof( Earthroot), 0.577f )
							  , new Loot( typeof( GhostMushroom), 0.192f )
							  , new Loot( typeof( GoldenSansam), 0.192f )
							  , new Loot( typeof( GordokCourtyardKey), 0.577f )
							  , new Loot( typeof( Kingsblood), 0.192f )
							  , new Loot( typeof( MithrilOre), 0.962f )
							  , new Loot( typeof( Peacebloom), 0.192f )
							  , new Loot( typeof( RoughStone), 0.192f )
							  , new Loot( typeof( Serpentbloom), 0.385f )
							  , new Loot( typeof( Silverleaf), 0.385f )
							  , new Loot( typeof( SolidStone), 0.769f )
							  , new Loot( typeof( StrangeDust), 0.769f )
							  , new Loot( typeof( Sungrass), 0.192f )
							  , new Loot( typeof( TinOre), 0.192f )
							  , new Loot( typeof( VisionDust), 0.192f )
							  };
	}
}

														