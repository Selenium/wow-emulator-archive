using Server.Items;

namespace Server.Creatures
{
	public class BrownRidingKodo : BaseCreature
	{
		public BrownRidingKodo() : base()
		{
			Id = 11689;
			Model = 11641;
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BoundingRadius = 1.000000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			NpcFlags = 0;
			Level = RandomLevel( 1, 2 );
			Name = "Brown Riding Kodo";
			CombatReach = 1.500000f;
			//Flags1 = 0x00;
			Faction = Factions.ThunderBluff;
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
	public class TealRidingKodo : BaseCreature
	{
		public TealRidingKodo() : base()
		{
			Id = 12148;
			Model = 12242;
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BoundingRadius = 1.000000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			NpcFlags = 0;
			Level = RandomLevel( 1, 2 );
			Name = "Teal Riding Kodo";
			CombatReach = 1.500000f;
			//Flags1 = 0x00;
			Faction = Factions.ThunderBluff;
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
	public class GrayRidingKodo : BaseCreature
	{
		public GrayRidingKodo() : base()
		{
			Id = 12149;
			Model = 12244;
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BoundingRadius = 1.000000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			NpcFlags = 0;
			Level = RandomLevel( 1, 2 );
			Name = "Gray Riding Kodo";
			CombatReach = 1.500000f;
			//Flags1 = 0x00;
			Faction = Factions.ThunderBluff;
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
	public class GreenRidingKodo : BaseCreature
	{
		public GreenRidingKodo() : base()
		{
			Id = 12151;
			Model = 12245;
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BoundingRadius = 1.000000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			NpcFlags = 0;
			Level = RandomLevel( 1, 2 );
			Name = "Green Riding Kodo";
			CombatReach = 1.500000f;
			//Flags1 = 0x00;
			Faction = Factions.ThunderBluff;
			RunSpeed = 12f;
			WalkSpeed = 4f;
			Speed = 10f;
			AIEngine = new NonAgressiveAnimalAI( this );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
		}
	}
}



/*18990 11689 Brown Kodo 
22718 14333 Black War Kodo */