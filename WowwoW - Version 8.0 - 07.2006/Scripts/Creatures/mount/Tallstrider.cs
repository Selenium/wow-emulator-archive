using Server.Items;

namespace Server.Creatures
{
	public class IvoryTallstrider : BaseCreature
	{
		public IvoryTallstrider() : base()
		{
			Id = 6076;
			Model = 6471;
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BoundingRadius = 1.000000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			NpcFlags = 0;
			Level = RandomLevel( 1, 2 );
			Name = "Ivory Tallstrider";
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
	public class BrownTallstrider : BaseCreature
	{
		public BrownTallstrider() : base()
		{
			Id = 7709;
			Model = 1283;
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BoundingRadius = 1.000000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			NpcFlags = 0;
			Level = RandomLevel( 1, 2 );
			Name = "Brown Tallstrider";
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
	public class GrayTallstrider : BaseCreature
	{
		public GrayTallstrider() : base()
		{
			Id = 7710;
			Model = 2741;
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BoundingRadius = 1.000000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			NpcFlags = 0;
			Level = RandomLevel( 1, 2 );
			Name = "Gray Tallstrider";
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
	public class PinkTallstrider : BaseCreature
	{
		public PinkTallstrider() : base()
		{
			Id = 7711;
			Model = 1961;
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BoundingRadius = 1.000000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			NpcFlags = 0;
			Level = RandomLevel( 1, 2 );
			Name = "Pink Tallstrider";
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
	public class PurpleTallstrider : BaseCreature
	{
		public PurpleTallstrider() : base()
		{
			Id = 7712;
			Model = 1281;
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BoundingRadius = 1.000000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			NpcFlags = 0;
			Level = RandomLevel( 1, 2 );
			Name = "Purple Tallstrider";
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
	public class TurquoiseTallstrider : BaseCreature
	{
		public TurquoiseTallstrider() : base()
		{
			Id = 7713;
			Model = 459;
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BoundingRadius = 1.000000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			NpcFlags = 0;
			Level = RandomLevel( 1, 2 );
			Name = "Turquoise Tallstrider";
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



