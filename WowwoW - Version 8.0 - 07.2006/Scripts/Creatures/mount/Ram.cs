using Server.Items;

namespace Server.Creatures
{
	public class GrayRam : BaseCreature
	{
		public GrayRam() : base()
		{
			Id = 4710;
			Model = 2736;
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BoundingRadius = 1.000000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			NpcFlags = 0;
			Level = RandomLevel( 1, 2 );
			Name = "Gray Ram";
			CombatReach = 1.500000f;
			//Flags1 = 0x00;
			Faction = Factions.IronForge;
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
	public class WhiteRam : BaseCreature
	{
		public WhiteRam() : base()
		{
			Id = 4777;
			Model = 2786;
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BoundingRadius = 1.000000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			NpcFlags = 0;
			Level = RandomLevel( 1, 2 );
			Name = "White Ram";
			CombatReach = 1.500000f;
			//Flags1 = 0x00;
			Faction = Factions.IronForge;
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
	public class FrostRam : BaseCreature
	{
		public FrostRam() : base()
		{
			Id = 4778;
			Model = 2787;
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BoundingRadius = 1.000000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			NpcFlags = 0;
			Level = RandomLevel( 1, 2 );
			Name = "Frost Ram";
			CombatReach = 1.500000f;
			//Flags1 = 0x00;
			Faction = Factions.IronForge;
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
	public class BrownRam : BaseCreature
	{
		public BrownRam() : base()
		{
			Id = 4779;
			Model = 2785;
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BoundingRadius = 1.000000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			NpcFlags = 0;
			Level = RandomLevel( 1, 2 );
			Name = "Brown Ram";
			CombatReach = 1.500000f;
			//Flags1 = 0x00;
			Faction = Factions.IronForge;
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
	public class BlackRam : BaseCreature
	{
		public BlackRam() : base()
		{
			Id = 4780;
			Model = 2784;
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BoundingRadius = 1.000000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			NpcFlags = 0;
			Level = RandomLevel( 1, 2 );
			Name = "Black Ram";
			CombatReach = 1.500000f;
			//Flags1 = 0x00;
			Faction = Factions.IronForge;
			RunSpeed = 12f;
			WalkSpeed = 4f;
			Speed = 10f;
			AIEngine = new NonAgressiveAnimalAI( this );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );
		}
	}
}



/*6897 4778 Blue Ram 
22720 14335 White War Ram */
