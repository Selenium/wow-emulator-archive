using Server.Items;

namespace Server.Creatures
{
	public class EmeraldRaptor : BaseCreature
	{
		public EmeraldRaptor() : base()
		{
			Id = 6075;
			Model = 4806;
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BoundingRadius = 1.000000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			NpcFlags = 0;
			Level = RandomLevel( 1, 2 );
			Name = "Emerald Raptor";
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
	public class IvoryRaptor : BaseCreature
	{
		public IvoryRaptor() : base()
		{
			Id = 7706;
			Model = 6471;
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BoundingRadius = 1.000000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			NpcFlags = 0;
			Level = RandomLevel( 1, 2 );
			Name = "Ivory Raptor";
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
	public class TurquoiseRaptor : BaseCreature
	{
		public TurquoiseRaptor() : base()
		{
			Id = 7707;
			Model = 6472;
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BoundingRadius = 1.000000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			NpcFlags = 0;
			Level = RandomLevel( 1, 2 );
			Name = "Turquoise Raptor";
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
	public class VioletRaptor : BaseCreature
	{
		public VioletRaptor() : base()
		{
			Id = 7708;
			Model = 6473;
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BoundingRadius = 1.000000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			NpcFlags = 0;
			Level = RandomLevel( 1, 2 );
			Name = "Violet Raptor";
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
	public class ObsidianRaptor : BaseCreature
	{
		public ObsidianRaptor() : base()
		{
			Id = 7703;
			Model = 6468;
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BoundingRadius = 1.000000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			NpcFlags = 0;
			Level = RandomLevel( 1, 2 );
			Name = "Obsidian Raptor";
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
	public class CrimsonRaptor : BaseCreature
	{
		public CrimsonRaptor() : base()
		{
			Id = 7704;
			Model = 6469;
			AttackBonii( 2000, 2000 );
			BaseMana = 0;
			BoundingRadius = 1.000000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			NpcFlags = 0;
			Level = RandomLevel( 1, 2 );
			Name = "Crimson Raptor";
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


/*10798 7703 Obsidian Raptor 
16084 7704 Crimson Raptor 
17450 7706 Ivory Raptor 
22721 14330 Black War Raptor */