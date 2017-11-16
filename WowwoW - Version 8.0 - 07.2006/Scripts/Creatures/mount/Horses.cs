using Server.Items;

///////////////////////////////////////////
namespace Server.Creatures
{
	public class Horse : BaseCreature
	{
		public Horse() : base()
		{
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BoundingRadius = 1.000000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			Model = 229;
			NpcFlags = 0;
			Level = RandomLevel( 5, 5 );
			Name = "Horse";
			CombatReach = 1.500000f;
			Flags1 = 0x07;
			Faction = Factions.Stormwind;
			Id = 385;
			RunSpeed = 12f;
			WalkSpeed = 4f;
			Speed = 10f;
			AIEngine = new NonAgressiveAnimalAI( this );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
			SkinLoot = new Loot[] { new Loot( typeof( LightHide  ), 90.0f ) };
		}
	}
}

namespace Server.Creatures
{
	public class BrownHorse : BaseCreature 
	{ 
		public  BrownHorse() : base() 
		{ 
			Id = 284; 
			Model = 2404;
			AttackSpeed= 2200;			
			BoundingRadius = 1.000f ;
			CombatReach = 0.925f ;
			Name = "Brown Horse " ;			
			Size = 1f;
			Speed = 4.9f ;
			WalkSpeed = 4.9f ;
			RunSpeed = 7.9f ;
			BaseMana=0;
			Level = RandomLevel( 1,2 );
			Faction = Factions.Stormwind;						
			//			BaseHitPoints = 1544 ;
			AIEngine = new NonAgressiveAnimalAI( this );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );

		}
	}	
}	

namespace Server.Creatures
{
	public class PintoHorse : BaseCreature 
	{ 
		public  PintoHorse() : base() 
		{ 
			Id = 307; 
			Model = 2409;
			AttackSpeed= 2200;			
			BoundingRadius = 1.000f ;
			CombatReach = 0.925f ;
			Name = "Pinto Horse " ;			
			Size = 1f;
			Speed = 4.9f ;
			WalkSpeed = 4.9f ;
			RunSpeed = 7.9f ;
			BaseMana=0;
			Level = RandomLevel( 1,2 );
			Faction = Factions.Stormwind;						
			//			BaseHitPoints = 1544 ;
			AIEngine = new NonAgressiveAnimalAI( this );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );

		}
	}	
}

namespace Server.Creatures
{
	public class SkeletalHorse : BaseCreature 
	{ 
		public  SkeletalHorse() : base() 
		{ 
			Id = 6486; 
			Model = 10673;
			AttackSpeed= 2200;			
			BoundingRadius = 1.000f ;
			CombatReach = 0.925f ;
			Name = "Skeletal Horse " ;			
			Size = 1f;
			Speed = 4.9f ;
			WalkSpeed = 4.9f ;
			RunSpeed = 7.9f ;
			BaseMana=0;
			Level = RandomLevel( 1,2 );
			Faction = Factions.Undercity;						
			//			BaseHitPoints = 1544 ;

			AIEngine = new NonAgressiveAnimalAI( this );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
		}
	}	
}



namespace Server.Creatures
{
	public class RedSkeletalHorse : BaseCreature 
	{ 
		public  RedSkeletalHorse() : base() 
		{ 
			Id = 11153; 
			Model = 10670;
			AttackSpeed= 2200;			
			BoundingRadius = 1.000f ;
			CombatReach = 0.925f ;
			Name = "Red Skeletal Horse " ;			
			Size = 1f;
			Speed = 4.9f ;
			WalkSpeed = 4.9f ;
			RunSpeed = 7.9f ;
			BaseMana=0;
			Level = RandomLevel( 1,2 );
			Faction = Factions.Undercity;	
			//			BaseHitPoints = 1544 ;
			AIEngine = new NonAgressiveAnimalAI( this );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );

		}
	}	
}



namespace Server.Creatures
{
	public class BlueSkeletalHorse : BaseCreature 
	{ 
		public  BlueSkeletalHorse() : base() 
		{ 
			Id = 12341; 
			Model = 10671;
			AttackSpeed= 2200;			
			BoundingRadius = 1.000f ;
			CombatReach = 0.925f ;
			Name = "Blue Skeletal Horse " ;			
			Size = 1f;
			Speed = 4.9f ;
			WalkSpeed = 4.9f ;
			RunSpeed = 7.9f ;
			BaseMana=0;
			Level = RandomLevel( 1,2 );
			Faction = Factions.Undercity;	
			//			BaseHitPoints = 1544 ;
			AIEngine = new NonAgressiveAnimalAI( this );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );

		}
	}	
}


namespace Server.Creatures
{
	public class BrownSkeletalHorse : BaseCreature 
	{ 
		public  BrownSkeletalHorse() : base() 
		{ 
			Id = 11154; 
			Model = 10672;
			AttackSpeed= 2200;			
			BoundingRadius = 1.000f ;
			CombatReach = 0.925f ;
			Name = "Brown Skeletal Horse " ;			
			Size = 1f;
			Speed = 4.9f ;
			WalkSpeed = 4.9f ;
			RunSpeed = 7.9f ;
			BaseMana=0;
			Level = RandomLevel( 1,2 );
			Faction = Factions.Undercity;		
			//			BaseHitPoints = 1544 ;
			AIEngine = new NonAgressiveAnimalAI( this );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );

		}
	}	
}


namespace Server.Creatures
{
	public class GreenSkeletalWarhorse : BaseCreature 
	{ 
		public  GreenSkeletalWarhorse() : base() 
		{ 
			Id = 11156; 
			Model = 10672;
			AttackSpeed= 2000;			
			BoundingRadius = 1.000f ;
			CombatReach = 0.925f ;
			Name = "Green Skeletal Warhorse" ;			
			Size = 1f;
			Speed = 4.9f ;
			WalkSpeed = 4.9f ;
			RunSpeed = 7.9f ;
			BaseMana=0;
			Level = RandomLevel( 1,2 );
			Faction = Factions.Undercity;		
			//			BaseHitPoints = 1544 ;
			AIEngine = new NonAgressiveAnimalAI( this );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );

		}
	}	
}


namespace Server.Creatures
{
	public class BlackSkeletalWarhorse : BaseCreature 
	{ 
		public  BlackSkeletalWarhorse() : base() 
		{ 
			Id = 11195; 
			Model = 10672;
			AttackSpeed= 2000;			
			BoundingRadius = 1.000f ;
			CombatReach = 0.925f ;
			Name = "Black Skeletal Warhorse " ;			
			Size = 1f;
			Speed = 4.9f ;
			WalkSpeed = 4.9f ;
			RunSpeed = 7.9f ;
			BaseMana=0;
			Level = RandomLevel( 1,2 );
			Faction = Factions.Undercity;		
			//			BaseHitPoints = 1544 ;
			AIEngine = new NonAgressiveAnimalAI( this );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );

		}
	}	
}

/*22722 14331 Red Skeletal Warhorse  i cant find*/





