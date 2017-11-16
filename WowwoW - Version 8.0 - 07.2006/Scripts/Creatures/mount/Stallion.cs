using Server.Items;

namespace Server.Creatures
{
	public class WhiteStallion : BaseCreature
	{
		public WhiteStallion() : base()
		{
			Id = 305;
			Model = 2410;
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BoundingRadius = 1.000000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			NpcFlags = 0;
			Level = RandomLevel( 1, 2 );
			Name = "White Stallion";
			CombatReach = 1.500000f;
			//Flags1 = 0x00;
			Faction = Factions.Stormwind;
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
	public class PalaminoStallion : BaseCreature
	{
		public PalaminoStallion() : base()
		{
			Id = 306;
			Model = 2408;
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BoundingRadius = 1.000000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			NpcFlags = 0;
			Level = RandomLevel( 1, 2 );
			Name = "Palamino Stallion";
			CombatReach = 1.500000f;
			//Flags1 = 0x00;
			Faction = Factions.Stormwind;
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
	public class BlackStallion : BaseCreature
	{
		public BlackStallion() : base()
		{
			Id = 308;
			Model = 2402;
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BoundingRadius = 1.000000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			NpcFlags = 0;
			Level = RandomLevel( 1, 2 );
			Name = "Black Stallion";
			CombatReach = 1.500000f;
			//Flags1 = 0x00;
			Faction = Factions.Stormwind;
			RunSpeed = 12f;
			WalkSpeed = 4f;
			Speed = 10f;
			AIEngine = new NonAgressiveAnimalAI( this );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
		}
	}
}



/*16082 306 Palomino Stallion 
16083 305 White Stallion */
