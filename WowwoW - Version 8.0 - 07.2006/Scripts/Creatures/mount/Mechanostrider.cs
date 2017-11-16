using Server.Items;

namespace Server.Creatures
{
	public class RedMechanostrider : BaseCreature
	{
		public RedMechanostrider() : base()
		{
			Id = 7739;
			Model = 6978;
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BoundingRadius = 1.000000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			NpcFlags = 0;
			Level = RandomLevel( 1, 2 );
			Name = "Red Mechanostrider";
			CombatReach = 1.500000f;
			//Flags1 = 0x00;
			Faction = Factions.GnomereganExiles;
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
	public class BlueMechanostrider : BaseCreature
	{
		public BlueMechanostrider() : base()
		{
			Id = 7749;
			Model = 6569;
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BoundingRadius = 1.000000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			NpcFlags = 0;
			Level = RandomLevel( 1, 2 );
			Name = "Blue Mechanostrider";
			CombatReach = 1.500000f;
			//Flags1 = 0x00;
			Faction = Factions.GnomereganExiles;
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
	public class FlourescentGreenMechanostrider : BaseCreature
	{
		public FlourescentGreenMechanostrider() : base()
		{
			Id = 10178;
			Model = 9475;
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BoundingRadius = 1.000000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			NpcFlags = 0;
			Level = RandomLevel( 1, 2 );
			Name = "Flourescent Green Mechanostrider";
			CombatReach = 1.500000f;
			//Flags1 = 0x00;
			Faction = Factions.GnomereganExiles;
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
	public class WhiteMechanostrider : BaseCreature
	{
		public WhiteMechanostrider() : base()
		{
			Id = 10179;
			Model = 6569;
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BoundingRadius = 1.000000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			NpcFlags = 0;
			Level = RandomLevel( 1, 2 );
			Name = "White Mechanostrider";
			CombatReach = 1.500000f;
			//Flags1 = 0x00;
			Faction = Factions.GnomereganExiles;
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
	public class SteelMechanostrider : BaseCreature
	{
		public SteelMechanostrider() : base()
		{
			Id = 10180;
			Model = 9476;
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BoundingRadius = 1.000000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			NpcFlags = 0;
			Level = RandomLevel( 1, 2 );
			Name = "Steel Mechanostrider";
			CombatReach = 1.500000f;
			//Flags1 = 0x00;
			Faction = Factions.GnomereganExiles;
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
	public class GreenMechanostrider : BaseCreature
	{
		public GreenMechanostrider() : base()
		{
			Id = 11147;
			Model = 10661;
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BoundingRadius = 1.000000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			NpcFlags = 0;
			Level = RandomLevel( 1, 2 );
			Name = "Green Mechanostrider";
			CombatReach = 1.500000f;
			//Flags1 = 0x00;
			Faction = Factions.GnomereganExiles;
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
	public class PurpleMechanostrider : BaseCreature
	{
		public PurpleMechanostrider() : base()
		{
			Id = 11148;
			Model = 10662;
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BoundingRadius = 1.000000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			NpcFlags = 0;
			Level = RandomLevel( 1, 2 );
			Name = "Purple Mechanostrider";
			CombatReach = 1.500000f;
			//Flags1 = 0x00;
			Faction = Factions.GnomereganExiles;
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
	public class RedBlueMechanostrider : BaseCreature
	{
		public RedBlueMechanostrider() : base()
		{
			Id = 11149;
			Model = 10664;
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BoundingRadius = 1.000000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			NpcFlags = 0;
			Level = RandomLevel( 1, 2 );
			Name = "Red & Blue Mechanostrider";
			CombatReach = 1.500000f;
			//Flags1 = 0x00;
			Faction = Factions.GnomereganExiles;
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
	public class IcyBlueMechanostrider : BaseCreature
	{
		public IcyBlueMechanostrider() : base()
		{
			Id = 11150;
			Model = 10666;
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BoundingRadius = 1.000000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			NpcFlags = 0;
			Level = RandomLevel( 1, 2 );
			Name = "Icy Blue Mechanostrider";
			CombatReach = 1.500000f;
			//Flags1 = 0x00;
			Faction = Factions.GnomereganExiles;
			RunSpeed = 12f;
			WalkSpeed = 4f;
			Speed = 10f;
			AIEngine = new NonAgressiveAnimalAI( this );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
		}
	}
}


/*17454 10180 Unpainted Mechanostrider 
17458 10178 Fluorescent Green Mechanostrid */

