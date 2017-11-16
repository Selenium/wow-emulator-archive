using Server.Items;

///////////////////////////////////////////
namespace Server.Creatures
{
	public class ArticWolf : BaseCreature
	{
		public ArticWolf() : base()
		{
			Id = 4268;
			Model = 2833;
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BoundingRadius = 1.000000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			NpcFlags = 0;
			Level = RandomLevel( 1, 2 );
			Name = "Artic Wolf ";
			CombatReach = 1.500000f;
			//Flags1 = 0x00;
			Faction = Factions.Ogrimmar;
			RunSpeed = 12f;
			WalkSpeed = 4f;
			Speed = 10f;
			AIEngine = new NonAgressiveAnimalAI( this );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
		}
	}
}



namespace Server.Creatures
{
	public class BlackWolf : BaseCreature
	{
		public BlackWolf() : base()
		{
			Id = 356;
			Model = 2833;
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BoundingRadius = 1.000000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			NpcFlags = 0;
			Level = RandomLevel( 1, 2 );
			Name = "Black Wolf ";
			CombatReach = 1.500000f;
			//Flags1 = 0x00;
			Faction = Factions.Ogrimmar;
			RunSpeed = 12f;
			WalkSpeed = 4f;
			Speed = 10f;
			AIEngine = new NonAgressiveAnimalAI( this );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
		}
	}
}


namespace Server.Creatures
{
	public class RedWolf : BaseCreature
	{
		public RedWolf() : base()
		{
			Id = 4270;
			Model = 2326;
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BoundingRadius = 1.000000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			NpcFlags = 0;
			Level = RandomLevel( 1, 2 );
			Name = "Red Wolf";
			CombatReach = 1.500000f;
			//Flags1 = 0x00;
			Faction = Factions.Ogrimmar;
			RunSpeed = 12f;
			WalkSpeed = 4f;
			Speed = 10f;
			AIEngine = new NonAgressiveAnimalAI( this );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
		}
	}
}



namespace Server.Creatures
{
	public class DireWolf : BaseCreature
	{
		public DireWolf() : base()
		{
			Id = 4271;
			Model = 2327;
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BoundingRadius = 1.000000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			NpcFlags = 0;
			Level = RandomLevel( 1, 2 );
			Name = "Dire Wolf";
			CombatReach = 1.500000f;
			//Flags1 = 0x00;
			Faction = Factions.Ogrimmar;
			RunSpeed = 12f;
			WalkSpeed = 4f;
			Speed = 10f;
			AIEngine = new NonAgressiveAnimalAI( this );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
		}
	}
}




namespace Server.Creatures
{
	public class BrownWolf : BaseCreature
	{
		public BrownWolf() : base()
		{
			Id = 4272;
			Model = 2328;
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BoundingRadius = 1.000000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			NpcFlags = 0;
			Level = RandomLevel( 1, 2 );
			Name = "Brown Wolf";
			CombatReach = 1.500000f;
			//Flags1 = 0x00;
			Faction = Factions.Ogrimmar;
			RunSpeed = 12f;
			WalkSpeed = 4f;
			Speed = 10f;
			AIEngine = new NonAgressiveAnimalAI( this );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
		}
	}
}


/*580 358 Large Timber Wolf */


namespace Server.Creatures
{
	public class WinterWolfMount : BaseCreature
	{
		public WinterWolfMount() : base()
		{
			Id = 359;
			Model = 1166;
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BoundingRadius = 1.000000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			NpcFlags = 0;
			Level = RandomLevel( 1, 2 );
			Name = "Winter Wolf";
			CombatReach = 1.500000f;
			//Flags1 = 0x00;
			Faction = Factions.Ogrimmar;
			RunSpeed = 12f;
			WalkSpeed = 4f;
			Speed = 10f;
			AIEngine = new NonAgressiveAnimalAI( this );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
		}
	}
}




namespace Server.Creatures
{
	public class BlackRidingWolf : BaseCreature
	{
		public BlackRidingWolf() : base()
		{
			Id = 5194;
			Model = 207;
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BoundingRadius = 1.000000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 1;
			NpcFlags = 0;
			Level = RandomLevel( 10 );
			Name = "Black Riding Wolf";
			CombatReach = 1.500000f;
			Flags1 = 0x05;
			Faction = Factions.Ogrimmar;
			RunSpeed = 12f;
			WalkSpeed = 4f;
			Speed = 10f;
			AIEngine = new NonAgressiveAnimalAI( this );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
		}
	}
}



namespace Server.Creatures
{
	public class BrownRidingWolf : BaseCreature
	{
		public BrownRidingWolf() : base()
		{
			Id = 5195;
			Model = 2328;
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BoundingRadius = 1.000000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 1;
			NpcFlags = 0;
			Level = RandomLevel( 10 );
			Name = "Brown Riding Wolf";
			CombatReach = 1.500000f;
			Flags1 = 0x05;
			Faction = Factions.Ogrimmar;
			RunSpeed = 12f;
			WalkSpeed = 4f;
			Speed = 10f;
			Size = 1.2f;
			NpcFlags = 0;
			AIEngine = new NonAgressiveAnimalAI( this );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
		}
	}
}





namespace Server.Creatures
{
	public class GrayRidingWolf : BaseCreature
	{
		public GrayRidingWolf() : base()
		{
			Id = 5196;
			Model = 2320;
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BoundingRadius = 1.000000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 1;
			NpcFlags = 0;
			Level = RandomLevel( 10 );
			Name = "Gray Riding Wolf";
			CombatReach = 1.500000f;
			Flags1 = 0x05;
			Faction = Factions.Ogrimmar;
			RunSpeed = 12f;
			WalkSpeed = 4f;
			Speed = 10f;
			Size = 1f;
			NpcFlags = 0;
			AIEngine = new NonAgressiveAnimalAI( this );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
		}
	}
}




namespace Server.Creatures
{
	public class RedRidingWolf : BaseCreature
	{
		public RedRidingWolf() : base()
		{
			Id = 5197;
			Model = 2326;
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BoundingRadius = 1.000000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 1;
			NpcFlags = 0;
			Level = RandomLevel( 10 );
			Name = "Red Riding Wolf";
			CombatReach = 1.500000f;
			Flags1 = 0x05;
			Faction = Factions.Ogrimmar;
			RunSpeed = 12f;
			WalkSpeed = 4f;
			Speed = 10f;
			Size = 1f;
			NpcFlags = 0;
			AIEngine = new NonAgressiveAnimalAI( this );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
		}
	}
}




namespace Server.Creatures
{
	public class WhiteRidingWolf : BaseCreature
	{
		public WhiteRidingWolf() : base()
		{
			Id = 5198;
			Model = 1166;
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BoundingRadius = 1.000000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 1;
			NpcFlags = 0;
			Level = RandomLevel( 10 );
			Name = "White Riding Wolf";
			CombatReach = 1.500000f;
			Flags1 = 0x05;
			Faction = Factions.Ogrimmar;
			RunSpeed = 12f;
			WalkSpeed = 4f;
			Speed = 10f;
			Size = 1f;
			NpcFlags = 0;
			AIEngine = new NonAgressiveAnimalAI( this );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
		}
	}
}


/*22724 14329 Black War Wolf */