//     Script made by nirvan   - 07.06.2005
// Zombies.cs

using System;
using System.Collections;
using Server;
using Server.Items;

namespace Server.Creatures
{
	public class MindlessZombie : BaseCreature
	{
		public MindlessZombie() : base()
		{
			Name = "Mindless Zombie";
			Id = 1501;
			Model = 10973;
			Level = RandomLevel(1,2);
			SetDamage(1f,4f);
			AttackSpeed = 2000;
			BoundingRadius = 1;
			CombatReach = 1;
			Armor = 20;
			Block = 1;
			ResistArcane = 1;
			ResistFire = 1;
			ResistFrost = 1;
			ResistHoly = 1;
			ResistNature = 1;
			ResistShadow = 1;
			BaseHitPoints = 24;
			Size = 1f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.NoFaction;
			AIEngine = new DefensiveAnimalAI( this );
			NpcType = (int)NpcTypes.Undead;
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA , 100f )
										  , new BaseTreasure(                         ZombiesLoot.MindlessZombie , 100f )
									  };
			BCAddon.Hp( this, 24, 1 );
		}
	}

	public class WretchedZombie : BaseCreature
	{
		public WretchedZombie() : base()
		{
			Name = "Wretched Zombie";
			Id = 1502;
			Model = 10979;
			Level = RandomLevel(1,2);
			SetDamage(2f,4f);
			AttackSpeed = 2000;
			BoundingRadius = 1;
			CombatReach = 1;
			Armor = 25;
			Block = 1;
			ResistArcane = 1;
			ResistFire = 1;
			ResistFrost = 1;
			ResistHoly = 1;
			ResistNature = 1;
			ResistShadow = 1;
			BaseHitPoints = 31;
			Size = 1f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
                        Faction = Factions.NoFaction;
                        AIEngine = new DefensiveAnimalAI( this );
			NpcType = (int)NpcTypes.Undead;
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA , 100f )
										  , new BaseTreasure(                         ZombiesLoot.WretchedZombie , 100f )
									  };
			BCAddon.Hp( this, 31, 1 );
		
		}
	}
}
