//////////////////////////////////////////////////////////////////////////////
// 
// 			 "Annimals"
// Made by Dr Nexus
//////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections;
using Server;
using Server.Items;

///////////////////////////////////////////
namespace Server.Creatures
{
	public class Chicken : BaseCreature
	{
		public Chicken() : base()
		{
			AttackBonii( 2000, 2000 );
			Speed = 0.500000f;
			BaseMana = 0;
			BaseHitPoints = 15;
			BoundingRadius = 0.145000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			//Model = 304;
			Model = 589;
			NpcFlags = 0;
			Level = RandomLevel( 1, 1 );
			Name = "Chicken";
			CombatReach = 1.500000f;
			Flags1 = 0x06;
			Unk3 = 8;
			Faction = Factions.NoFaction;
			Id = 620;
			AIEngine = new NonAgressiveAnimalAI( this );
		}
	}
}
///////////////////////////////////////////
namespace Server.Creatures
{
	public class Rabbit : BaseCreature
	{
		public static Loot[] TinyAnimalLoots = new Loot[] { new Loot( typeof( RuinedLeatherScraps ), 1, 2, 50.260002f ) };

		public Rabbit() : base()
		{
			AIEngine = new NonAgressiveAnimalAI( this );
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BaseHitPoints = 20;
			BoundingRadius = 0.235000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			Model = 1560;
			//Model = Rnd.RandomIntArr( 328, 1560);
			NpcFlags = 0;
			Level = RandomLevel( 1, 1 );
			Name = "Rabbit";
			CombatReach = 1.000000f;
			Flags1 = 0x06;
			Unk3 = 8;
			Faction = Factions.Prey;
			SkinLoot = new Loot[] { new Loot( typeof( LightHide ), 30f ) };
			Loots = new BaseTreasure[]{ new BaseTreasure( Rabbit.TinyAnimalLoots, 60.0f ) };
			Id = 721;
		}
	}
}
///////////////////////////////////////////
namespace Server.Creatures
{
	public class Deer : BaseCreature
	{
		public Deer() : base()
		{			
			AIEngine = new NonAgressiveAnimalAI( this );
			AttackBonii( 2000, 2000 );
			BaseMana = 28;
			BaseHitPoints = 30;
			BoundingRadius = 1.000000f;
			SetDamage( 4.500000, 5.500000 );
			NpcType = 8;
			Model = 347;
			NpcFlags = 0;
			Level = RandomLevel( 5, 6 );
			Name = "Deer";
			CombatReach = 1.558700f;
			Flags1 = 0x0104006;
			Unk3 = 8;
			Speed = 3;
			Faction = Factions.NoFaction;
			SkinLoot = new Loot[] { new Loot( typeof( LightLeather ), 1, 4, 90f ) };
			Loots = new BaseTreasure[]{ new BaseTreasure( Rabbit.TinyAnimalLoots, 100.0f ) };
			Id = 883;
		}
	}
}
///////////////////////////////////////////
namespace Server.Creatures
{
	public class Fawn : BaseCreature
	{
		public Fawn() : base()
		{
			AIEngine = new NonAgressiveAnimalAI( this );
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BaseHitPoints = 30;
			BoundingRadius = 0.600000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			Model = 654;
			NpcFlags = 0;
			Level = RandomLevel( 1, 1 );
			Name = "Fawn";
			CombatReach = 0.900000f;
			Flags1 = 0x06;
			Unk3 = 8;
			Speed = 4;
			Faction = Factions.NoFaction;
			SkinLoot = new Loot[] { new Loot( typeof( LightLeather ), 90f ) };
			Loots = new BaseTreasure[]{ new BaseTreasure( Rabbit.TinyAnimalLoots, 100.0f ) };
			Id = 890;
		}
	}
}
///////////////////////////////////////////
namespace Server.Creatures
{
	public class Squirrel : BaseCreature
	{
		public Squirrel() : base()
		{
			AIEngine = new NonAgressiveAnimalAI( this );
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BaseHitPoints = 15;
			BoundingRadius = 1.300000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			Model = 134;
			NpcFlags = 0;
			Level = RandomLevel( 1, 1 );
			Name = "Squirrel";
			CombatReach = 1.950000f;
			Flags1 = 0x06;
			Unk3 = 8;
			Faction = Factions.Prey;
			Loots = new BaseTreasure[]{ new BaseTreasure( Rabbit.TinyAnimalLoots, 30.0f ) };
			Id = 1412;
		}
	}
}
///////////////////////////////////////////
namespace Server.Creatures
{
	public class Sheep : BaseCreature
	{
		public Sheep() : base()
		{
			AIEngine = new NonAgressiveAnimalAI( this );
			AttackBonii( 2000, 2000 );
			BaseMana = 44;
			BaseHitPoints = 30;
			BoundingRadius = 1.000000f;
			SetDamage( 12.857142, 15.857142 );
			NpcType = 8;
			Model = 857;
			//Model = Rnd.RandomIntArr( 856, 857);
			NpcFlags = 0;
			Level = RandomLevel( 2, 10 );
			Name = "Sheep";
			CombatReach = 1.500000f;
			Flags1 = 0x0104006;
			Unk3 = 8;
			Faction = Factions.NoFaction;
			Loots = new BaseTreasure[]{ new BaseTreasure( Rabbit.TinyAnimalLoots, 100.0f ) };
			Id = 1933;
		}
	}
}
///////////////////////////////////////////
namespace Server.Creatures
{
	public class BlackRat : BaseCreature
	{
		public BlackRat() : base()
		{
			AIEngine = new NonAgressiveAnimalAI( this );
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BaseHitPoints = 15;
			BoundingRadius = 1.000000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			Model = 1141;
			NpcFlags = 0;
			Level = RandomLevel( 1, 1 );
			Name = "Black Rat";
			CombatReach = 1.000000f;
			Flags1 = 0x06;
			Unk3 = 8;
			Faction = Factions.Prey;
			
			Id = 2110;
		}
	}
}
///////////////////////////////////////////
namespace Server.Creatures
{
	public class PrairieDog : BaseCreature
	{
		public PrairieDog() : base()
		{
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BaseHitPoints = 30;
			BoundingRadius = 0.122000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			Model = 1072;
			NpcFlags = 0;
			Level = RandomLevel( 1, 1 );
			Name = "Prairie Dog";
			CombatReach = 1.000000f;
			Flags1 = 0x06;
			Unk3 = 8;
			Faction = Factions.NoFaction;
			
			Loots = new BaseTreasure[]{ new BaseTreasure( Rabbit.TinyAnimalLoots, 100.0f ) };
			Id = 2620;
			AIEngine = new DefensiveAnimalAI( this );
		}
	}
}
///////////////////////////////////////////
namespace Server.Creatures
{
	public class Mouse : BaseCreature
	{
		public Mouse() : base()
		{
			AIEngine = new NonAgressiveAnimalAI( this );
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BaseHitPoints = 10;
			BoundingRadius = 0.800000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			Model = 4959;
			NpcFlags = 0;
			Level = RandomLevel( 1, 1 );
			Name = "Mouse";
			CombatReach = 1.558700f;
			Flags1 = 0x06;
			Faction = Factions.Prey;
			Id = 6271;
		}
	}
}

