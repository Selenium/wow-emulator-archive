using Server.Items;

namespace Server.Creatures
{
	public class ChessnutMare : BaseCreature
	{
		public ChessnutMare() : base()
		{
			Id = 4269;
			Model = 2405;
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BoundingRadius = 1.000000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			NpcFlags = 0;
			Level = RandomLevel( 1, 2 );
			Name = "Chessnut Mare";
			CombatReach = 1.500000f;
			//Flags1 = 0x00;
			Faction = Factions.NoFaction;
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
	public class PantherMount : BaseCreature
	{
		public PantherMount() : base()
		{
			Id = 7322;
			Model = 9991;
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BoundingRadius = 1.000000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			NpcFlags = 0;
			Level = RandomLevel( 1, 2 );
			Name = "Panther";
			CombatReach = 1.500000f;
			//Flags1 = 0x00;
			Faction = Factions.NoFaction;
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
	public class Leopard : BaseCreature
	{
		public Leopard() : base()
		{
			Id = 7684;
			Model = 6447;
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BoundingRadius = 1.000000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			NpcFlags = 0;
			Level = RandomLevel( 1, 2 );
			Name = "Leopard";
			CombatReach = 1.500000f;
			//Flags1 = 0x00;
			Faction = Factions.NoFaction;
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
	public class Tiger : BaseCreature
	{
		public Tiger() : base()
		{
			Id = 7686;
			Model = 9714;
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BoundingRadius = 1.000000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			NpcFlags = 0;
			Level = RandomLevel( 1, 2 );
			Name = "Tiger";
			CombatReach = 1.500000f;
			//Flags1 = 0x00;
			Faction = Factions.NoFaction;
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
	public class SpottedPanther : BaseCreature
	{
		public SpottedPanther() : base()
		{
			Id = 7689;
			Model = 6448;
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BoundingRadius = 1.000000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			NpcFlags = 0;
			Level = RandomLevel( 1, 2 );
			Name = "Spotted Panther";
			CombatReach = 1.500000f;
			//Flags1 = 0x00;
			Faction = Factions.NoFaction;
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
	public class PrimalLeopard : BaseCreature
	{
		public PrimalLeopard() : base()
		{
			Id = 10336;
			Model = 4805;
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BoundingRadius = 1.000000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			NpcFlags = 0;
			Level = RandomLevel( 1, 2 );
			Name = "Primal Leopard";
			CombatReach = 1.500000f;
			//Flags1 = 0x00;
			Faction = Factions.NoFaction;
			RunSpeed = 12f;
			WalkSpeed = 4f;
			Speed = 10f;
			AIEngine = new NonAgressiveAnimalAI( this );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
		}
	}
}


/*22717 14332 Black War Steed 
22719 14334 Black Battlestrider 
22723 14336 Black War Tiger 
*/