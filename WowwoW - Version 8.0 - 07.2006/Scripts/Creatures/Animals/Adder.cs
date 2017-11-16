using System;
using System.Collections;
using Server;
using Server.Items;

namespace Server.Creatures
{
	public class Adder : BaseCreature
	{
		public static Loot[] TinyAnimalLoots = new Loot[] { new Loot( typeof( RuinedLeatherScraps ), 1, 2, 50.260002f ) };

		public Adder() : base()
		{
			AIEngine = new NonAgressiveAnimalAI( this );
			AttackBonii( 2000, 2000 );
			ManaType = 1; 
			BaseMana=100;
			BaseHitPoints = 20;
			Flags1=0x010080006;
			BoundingRadius = 0.235000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 8;
			Model = 1986;
			NpcFlags = 0;
			Level = RandomLevel( 1, 1 );
			Name = "Adder";
			CombatReach = 1.000000f;
			Unk3 = 1;
			Faction = Factions.Prey;
			SkinLoot = new Loot[] { new Loot( typeof( LightHide ), 30f ) };
		//	Loots = new BaseTreasure[]{ new BaseTreasure( AdderDrops.Adder, 60.0f ) };
			Id = 3300;
		}
	}
}
		