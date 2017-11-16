//////////////////////////////////////////////////////////////////////////////
// 
// 			 "Toad"
// Made by Dr Nexus
//////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections;
using Server;
using Server.Items;

///////////////////////////////////////////
namespace Server.Creatures
{
	public class Toad : BaseCreature
	{
		public Toad() : base()
		{
			AttackBonii( 2000, 2000 );
			ManaType=1;
			BoundingRadius = 0.200000f;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);  //SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			Model = 901;
			NpcFlags = 0;
			Level = RandomLevel( 1, 1 );
			Name = "Toad";
			BaseHitPoints=55;
			CombatReach = 0.010000f;
			Flags1 = 0x06;
			Unk3 = 8;
			Speed=5f;
			WalkSpeed = 5f;
			RunSpeed = 7f;
			Faction = Factions.Prey;
			AIEngine = new NonAgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( Ambient2Drops.Toad, 100.0f )};
			Id = 1420;
		}
	}
}

///////////////////////////////////////////
namespace Server.Creatures
{
	public class Narnie : BaseCreature
	{
		public Narnie() : base()
		{
			AttackBonii( 2000, 2000 );
			ManaType=1;
			Size=0.500000f;
			BoundingRadius = 0.250000f;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);  //SetDamage( 1.542857, 1.542857 );
			NpcType = 1;
			Model = 5448;
			NpcFlags = 0;
			AttackSpeed = 2000-(Level-1)*13;
			BaseRage = 20;
			BoundingRadius = 0.250000f;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);  //SetDamage( 1.542857, 1.542857 );
			BaseHitPoints=55;			
			Level = RandomLevel( 1, 1 );
			Name = "Narnie";
			CombatReach = 0.500000f;
			Flags1 = 0x06E;
			Speed = 3f;
			RunSpeed = 4f;
			WalkSpeed = 3f;				
			Faction = Factions.Prey;
			AIEngine = new NonAgressiveAnimalAI( this );
			SkinLoot = new Loot[] { new Loot( typeof( RuinedLeatherScraps ), 90.0f )
					          ,new Loot( typeof( LightLeather ), 10.0f )};
			Id = 6728;
		}
	}
}

///////////////////////////////////////////
namespace Server.Creatures
{
	public class SilverTabby : BaseCreature
	{
		public SilverTabby() : base()
		{
			AttackBonii( 2000, 2000 );
			ManaType=1;
			AttackSpeed = 2000-(Level-1)*13;			
			Size = 0.800000f;
			BoundingRadius = 0.250000f;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);  //SetDamage(1f+1.8f*Level,1f+2.66*Level);			
			NpcType = 1;
			Model = 5555;
			NpcFlags = 0;
			Level = RandomLevel(1, 20 );
			Name = "Silver Tabby";
			CombatReach = 0.500000f;
			Flags1 = 0x066;
			Unk3 = 1;
			BaseRage = 76;
			BaseHitPoints = 50+5*Level;	
			Faction = Factions.Beast;
////			AIEngine = new SummonedAI( this );
			Id = 7381;
			Speed = 3f;
			RunSpeed = 4f;
			WalkSpeed = 3f;		
			Size=0.500000f;
			SkinLoot = new Loot[] { new Loot( typeof( RuinedLeatherScraps ), 90.0f )
					          ,new Loot( typeof( LightLeather ), 10.0f )};			
		}
	}
}
///////////////////////////////////////////
namespace Server.Creatures
{
	public class OrangeTabby : BaseCreature
	{
		public OrangeTabby() : base()
		{
			AttackBonii( 2000, 2000 );
			ManaType=1;
			AttackSpeed = 2000-(Level-1)*13;			
			Size = 0.500000f;
			BoundingRadius = 0.250000f;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);  //SetDamage(1f+1.0f*Level,1f+1.55f*Level);
			NpcType = 1;
			Model = 5554;
			NpcFlags = 0;
			Level = RandomLevel( 1, 20 );
			Name = "Orange Tabby";
			CombatReach = 0.500000f;
			Flags1 = 0x066;
			Unk3 = 1;
			BaseRage = 76;
			BaseHitPoints = 50+5*Level;				
			Faction = Factions.Beast;
//			AIEngine = new SummonedAI( this );
			Id = 7382;
			Speed = 3f;
			RunSpeed = 4f;
			WalkSpeed = 3f;		
			Size=0.500000f;
			SkinLoot = new Loot[] { new Loot( typeof( RuinedLeatherScraps ), 90.0f )
					          ,new Loot( typeof( LightLeather ), 10.0f )};				
		}
	}
}
///////////////////////////////////////////
namespace Server.Creatures
{
	public class CornishRex : BaseCreature
	{
		public CornishRex() : base()
		{
			AttackBonii( 2000, 2000 );
			ManaType=1;
			AttackSpeed = 2000-(Level-1)*13;			
			Size = 0.500000f;
			BoundingRadius = 0.250000f;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);  //SetDamage(1f+1.0f*Level,1f+1.55f*Level);
			NpcType = 1;
			Model = 5586;
			NpcFlags = 0;
			Level = RandomLevel( 1, 20 );
			Name = "Cornish Rex";
			CombatReach = 0.500000f;
			Flags1 = 0x066;
			Unk3 = 1;
			BaseRage = 76;
			BaseHitPoints = 50+5*Level;				
			Faction = Factions.Beast;
//			AIEngine = new SummonedAI( this );
			Speed = 4f;
			RunSpeed = 5f;
			WalkSpeed = 4f;	
			SkinLoot = new Loot[] { new Loot( typeof( RuinedLeatherScraps ), 90.0f )
					          ,new Loot( typeof( LightLeather ), 10.0f )};				
			Id = 7384;
		}
	}
}
///////////////////////////////////////////
namespace Server.Creatures
{
	public class Bombay : BaseCreature
	{
		public Bombay() : base()
		{
			AttackBonii( 2000, 2000 );
			ManaType=1;
			AttackSpeed = 2000-(Level-1)*13;			
			Size = 0.500000f;
			BoundingRadius = 0.250000f;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);  //SetDamage(1f+1.0f*Level,1f+1.55f*Level);
			NpcType = 1;
			Model = 5556;
			NpcFlags = 0;
			Level = RandomLevel( 1, 20 );
			Name = "Bombay";
			CombatReach = 0.500000f;
			Flags1 = 0x066;
			BaseRage = 76;
			BaseHitPoints = 50+5*Level;				
			Faction = Factions.Beast;
//			AIEngine = new SummonedAI( this );
			AIEngine = new NonAgressiveAnimalAI( this ); 	
			Speed = 4.5f;
			RunSpeed = 5.5f;
			WalkSpeed = 4.5f;	
			SkinLoot = new Loot[] { new Loot( typeof( RuinedLeatherScraps ), 90.0f )
					          ,new Loot( typeof( LightLeather ), 10.0f )};				
			Id = 7385;
		}
	}
}
///////////////////////////////////////////
namespace Server.Creatures
{
	public class GreenWingMacaw : BaseCreature
	{
		public GreenWingMacaw() : base()
		{
			AttackBonii( 2000, 2000 );
			ManaType=1;
			AttackSpeed = 2000-(Level-1)*13;			
			Size = 0.500000f;
			BoundingRadius = 0.250000f;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);  //SetDamage(1f+1.0f*Level,1f+1.55f*Level);
			NpcType = 1;
			Model = 5207;
			NpcFlags = 0;
			Level = RandomLevel( 1, 20 );
			Name = "Green Wing Macaw";
			CombatReach = 0.010000f;
			Flags1 = 0x066;
			Unk3 = 1;
			BaseRage = 76;
			BaseHitPoints = 50+5*Level;				
			Faction = Factions.Beast;
//			AIEngine = new SummonedAI( this );
			AIEngine = new NonAgressiveAnimalAI( this ); 	
			Speed = 2.5f;
			RunSpeed = 3.5f;
			WalkSpeed = 2.5f;	
			SkinLoot = new Loot[] { new Loot( typeof( RuinedLeatherScraps ), 90.0f )
					          ,new Loot( typeof( LightLeather ), 10.0f )};
			Id = 7387;
		}
	}
}
///////////////////////////////////////////
namespace Server.Creatures
{
	public class Senegal : BaseCreature
	{
		public Senegal() : base()
		{
			AttackBonii( 2000, 2000 );
			ManaType=1;
			AttackSpeed = 2000-(Level-1)*13;			
			Size = 0.500000f;
			BoundingRadius = 0.250000f;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);  //SetDamage(1f+1.0f*Level,1f+1.55f*Level);
			NpcType = 1;
			Model = 6190;
			NpcFlags = 0;
			Level = RandomLevel( 1, 20 );
			Name = "Senegal";
			CombatReach = 0.010000f;
			Flags1 = 0x066;
			Unk3 = 1;
			BaseRage = 76;
			BaseHitPoints = 50+5*Level;				
			Faction = Factions.Beast;
//			AIEngine = new SummonedAI( this );
			AIEngine = new NonAgressiveAnimalAI( this ); 	
			Speed = 3.5f;
			RunSpeed = 4.5f;
			WalkSpeed = 3.5f;	
			Id = 7389;
		}
	}
}
///////////////////////////////////////////
namespace Server.Creatures
{
	public class Cockatiel : BaseCreature
	{
		public Cockatiel() : base()
		{
			AttackBonii( 2000, 2000 );
			ManaType=1;
			AttackSpeed = 2000-(Level-1)*13;			
			Size = 0.500000f;
			BoundingRadius = 0.250000f;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);  //SetDamage(1f+1.0f*Level,1f+1.55f*Level);
			NpcType = 1;
			Model = 6191;
			NpcFlags = 0;
			Level = RandomLevel( 1, 20 );
			Name = "Cockatiel";
			CombatReach = 0.010000f;
			Flags1 = 0x066;
			Unk3 = 1;
			BaseRage = 76;
			BaseHitPoints = 50+5*Level;				
			Faction = Factions.Beast;
//			AIEngine = new SummonedAI( this );
			AIEngine = new NonAgressiveAnimalAI( this ); 	
			Speed = 3.5f;
			RunSpeed = 4.5f;
			WalkSpeed = 3.5f;	
			SkinLoot = new Loot[] { new Loot( typeof( RuinedLeatherScraps ), 90.0f )
					          ,new Loot( typeof( LightLeather ), 10.0f )};
			Id = 7390;
		}
	}
}
///////////////////////////////////////////
namespace Server.Creatures
{
	public class HyacinthMacaw : BaseCreature
	{
		public HyacinthMacaw() : base()
		{
			AttackBonii( 2000, 2000 );
			ManaType=1;
			AttackSpeed = 2000-(Level-1)*13;			
			Size = 0.500000f;
			BoundingRadius = 0.250000f;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);  //SetDamage(1f+1.0f*Level,1f+1.55f*Level);
			NpcType = 1;
			Model = 6192;
			NpcFlags = 0;
			Level = RandomLevel( 1, 20 );
			Name = "Hyacinth Macaw";
			CombatReach = 0.010000f;
			Flags1 = 0x066;
			Unk3 = 1;
			BaseRage = 76;
			BaseHitPoints = 50+5*Level;				
			Faction = Factions.Beast;
//			AIEngine = new SummonedAI( this );
			AIEngine = new NonAgressiveAnimalAI( this ); 	
			Speed = 2.3f;
			RunSpeed = 3.3f;
			WalkSpeed = 2.3f;	
			SkinLoot = new Loot[] { new Loot( typeof( RuinedLeatherScraps ), 90.0f )
					          ,new Loot( typeof( LightLeather ), 10.0f )};
			Id = 7391;
		}
	}
}
///////////////////////////////////////////
namespace Server.Creatures
{
	public class CrimsonWhelpling : BaseCreature
	{
		public CrimsonWhelpling() : base()
		{
			AttackBonii( 2000, 2000 );
			ManaType=1;
			AttackSpeed = 2000-(Level-1)*13;			
			Size = 0.500000f;
			BoundingRadius = 0.250000f;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);  //SetDamage(1f+1.0f*Level,1f+1.55f*Level);
			NpcType = 1;
			Model = 6290;
			NpcFlags = 0;
			Level = RandomLevel( 1, 30 );
			Name = "Crimson Whelpling";
			CombatReach = 0.750000f;
			Flags1 = 0x066;
			Unk3 = 1;
			BaseRage = 76;
			BaseHitPoints = 50+5*Level;				
			Faction = Factions.Beast;
//			AIEngine = new SummonedAI( this );
			AIEngine = new NonAgressiveAnimalAI( this ); 	
			Speed = 4.5f;
			RunSpeed = 5.5f;
			WalkSpeed = 4.5f;	
			SkinLoot = new Loot[] { new Loot( typeof( RuinedLeatherScraps ), 90.0f )
					          ,new Loot( typeof( LightLeather ), 10.0f )};
			Id = 7544;
		}
	}
}
///////////////////////////////////////////
namespace Server.Creatures
{
	public class SnowshoeRabbit : BaseCreature
	{
		public SnowshoeRabbit() : base()
		{
			AttackBonii( 2000, 2000 );
			ManaType=1;
			AttackSpeed = 2000-(Level-1)*13;			
			Size = 0.500000f;
			BoundingRadius = 0.250000f;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);  //SetDamage(1f+1.0f*Level,1f+1.55f*Level);
			NpcType = 1;
			Model = 328;
			NpcFlags = 0;
			Level = RandomLevel(1, 20 );
			Name = "Snowshoe Rabbit";
			CombatReach = 1.000000f;
			Flags1 = 0x066;
			Unk3 = 1;
			BaseRage = 76;
			BaseHitPoints = 50+5*Level;				
			Faction = Factions.Beast;
//			AIEngine = new SummonedAI( this );
			AIEngine = new NonAgressiveAnimalAI( this ); 	
			Speed = 4.7f;
			RunSpeed = 5.7f;
			WalkSpeed = 4.7f;	
			SkinLoot = new Loot[] { new Loot( typeof( RuinedLeatherScraps ), 90.0f )
					          ,new Loot( typeof( LightLeather ), 10.0f )};
			Id = 7560;
		}
	}
}
