using Server.Items;

namespace Server.Creatures
{
	public class StripedFrostSaber : BaseCreature
	{
		public StripedFrostSaber() : base()
		{
			Id = 6074;
			Model = 6080;
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BoundingRadius = 1.000000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			NpcFlags = 0;
			Level = RandomLevel( 1, 2 );
			Name = "Striped Frost Saber";
			CombatReach = 1.500000f;
			//Flags1 = 0x00;
			Faction = Factions.Darnasus;
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
	public class SpottedFrostSaber : BaseCreature
	{
		public SpottedFrostSaber() : base()
		{
			Id = 7687;
			Model = 6444;
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BoundingRadius = 1.000000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			NpcFlags = 0;
			Level = RandomLevel( 1, 2 );
			Name = "Spotted Frost Saber";
			CombatReach = 1.500000f;
			//Flags1 = 0x00;
			Faction = Factions.Darnasus;
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
	public class StripedNightsaber : BaseCreature
	{
		public StripedNightsaber() : base()
		{
			Id = 7690;
			Model = 6448;
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BoundingRadius = 1.000000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			NpcFlags = 0;
			Level = RandomLevel( 1, 2 );
			Name = "Striped Nightsaber";
			CombatReach = 1.500000f;
			//Flags1 = 0x00;
			Faction = Factions.Darnasus;
			RunSpeed = 12f;
			WalkSpeed = 4f;
			Speed = 10f;
			AIEngine = new NonAgressiveAnimalAI( this );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
		}
	}
}


/*16055 7322 Night Saber */


namespace Server.Creatures
{
	public class FrostSaber : BaseCreature
	{
		public FrostSaber() : base()
		{
			Id = 10322;
			Model = 6080;
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BoundingRadius = 1.000000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			NpcFlags = 0;
			Level = RandomLevel( 1, 2 );
			Name = "Frost Saber";
			CombatReach = 1.500000f;
			//Flags1 = 0x00;
			Faction = Factions.Darnasus;
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
	public class TawnySabercat: BaseCreature
	{
		public TawnySabercat() : base()
		{
			Id = 10337;
			Model = 6079;
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BoundingRadius = 1.000000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			NpcFlags = 0;
			Level = RandomLevel( 1, 2 );
			Name = "Tawny Sabercat";
			CombatReach = 1.500000f;
			//Flags1 = 0x00;
			Faction = Factions.Darnasus;
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
	public class GoldenSabercat: BaseCreature
	{
		public GoldenSabercat() : base()
		{
			Id = 10338;
			Model = 9714;
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BoundingRadius = 1.000000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			NpcFlags = 0;
			Level = RandomLevel( 1, 2 );
			Name = "Golden Sabercat";
			CombatReach = 1.500000f;
			//Flags1 = 0x00;
			Faction = Factions.Darnasus;
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
	public class WinterspringFrostsaber: BaseCreature
	{
		public WinterspringFrostsaber() : base()
		{
			Id = 11021;
			Model = 6444;
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BoundingRadius = 1.000000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			NpcFlags = 0;
			Level = RandomLevel( 1, 2 );
			Name = "Winterspring Frostsaber";
			CombatReach = 1.500000f;
			//Flags1 = 0x00;
			Faction = Factions.Darnasus;
			RunSpeed = 12f;
			WalkSpeed = 4f;
			Speed = 10f;
			AIEngine = new NonAgressiveAnimalAI( this );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
		}
	}
}
