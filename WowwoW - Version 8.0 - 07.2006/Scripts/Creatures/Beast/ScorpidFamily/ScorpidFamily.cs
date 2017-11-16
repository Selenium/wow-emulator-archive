using System;
using System.Collections;
using Server;
using Server.Items;

namespace Server.Creatures
{
	public class ArmoredScorpid : BaseCreature
	{
		public ArmoredScorpid() : base()
		{
			Name = "Armored Scorpid";
			Id = 3126;
			Model = 2487;
			Level = RandomLevel(4,8);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*25.2);
			Block= Level;
			Family=20;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1;

			BaseMana = 0;			
			AttackSpeed = 2000;			
			BoundingRadius = 0.4258f;
			CombatReach = 0.8f;
			Size = 0.85f;
			Speed = 2.6f;
			WalkSpeed = 2.6f;
			RunSpeed = 5.6f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 119, 4 );
			Loots = new BaseTreasure[]{  new BaseTreasure( ScorpidDrops.ArmoredScorpid , 100f )
										};
		}
	}
}



namespace Server.Creatures
{
	public class ClackTheReaver : BaseCreature
	{
		public ClackTheReaver() : base()
		{
			Name = "Clack the Reaver";
			Id = 8301;
			Model = 10983;
			Level = RandomLevel(53);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= 3189;
			Block= Level;
			Family=20;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1;
			BaseMana = 0;			
			AttackSpeed = 2000;			
			BoundingRadius = 0.78f;
			CombatReach = 0.8f;
			Size = 1.5f;
			Elite=4;
			Speed = 3.8f;
			WalkSpeed = 3.8f;
			RunSpeed = 6.8f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 3180, 53 );
			Loots = new BaseTreasure[]{  new BaseTreasure( ScorpidDrops.ClackTheReaver , 100f )
										};
		}
	}
}



namespace Server.Creatures
{
	public class ClatteringScorpid : BaseCreature
	{
		public ClatteringScorpid() : base()
		{
			Name = "Clattering Scorpid";
			Id = 3125;
			Model = 2486;
			Level = RandomLevel(1,7);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*25.2);
			Block= Level;
			Family=20;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1;
 
			BaseMana = 100;
			AttackSpeed = 2000;			
			BoundingRadius = 0.4258f;
			CombatReach = 0.8f;
			Size = 0.85f;
			Speed = 2.6f;
			WalkSpeed = 2.6f;
			RunSpeed = 5.6f;
			Faction = Factions.Monster;
			AIEngine = new SpellCasterAI( this );
			Flags1 = 0x010;
			LearnSpell( 744, SpellsTypes.Offensive );
			LearnSpell( 1604, SpellsTypes.Offensive );
			BCAddon.Hp( this, 31, 1 );
			Loots = new BaseTreasure[]{  new BaseTreasure( ScorpidDrops.ClatteringScorpid , 100f )
										};
		}
	}
}



namespace Server.Creatures
{
	public class CleftScorpid : BaseCreature
	{
		public CleftScorpid() : base()
		{
			Name = "Cleft Scorpid";
			Id = 7078;
			Model = 5985;
			Level = RandomLevel(35,36);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*25.2);
			Block= Level;
			Family=20;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1;

			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 0.4258f;
			CombatReach = 0.8f;
			Size = 0.85f;
			Speed = 2.9f;
			WalkSpeed = 2.9f;
			RunSpeed = 5.9f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 394, 35 );
			Loots = new BaseTreasure[]{  new BaseTreasure( ScorpidDrops.CleftScorpid , 100f )
										};
		}
	}
}




namespace Server.Creatures
{
	public class CorruptedScorpid : BaseCreature
	{
		public CorruptedScorpid() : base()
		{
			Name = "Corrupted Scorpid";
			Id = 3226;
			Model = 2488;
			Level = RandomLevel(10,11);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*25.2);
			Block= Level;
			Family=20;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1;

			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 0.58f;
			CombatReach = 0.8f;
			Size = 0.7f;
			Speed = 2.6f;
			WalkSpeed = 2.6f;
			RunSpeed = 5.6f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 202, 10 );
			Loots = new BaseTreasure[]{  new BaseTreasure( ScorpidDrops.CorruptedScorpid , 100f )
										};
		}
	}
}



namespace Server.Creatures
{
	public class DeadlyCleftScorpid : BaseCreature
	{
		public DeadlyCleftScorpid() : base()
		{
			Name = "Deadly Cleft Scorpid";
			Id = 7405;
			Model = 5985;
			Level = RandomLevel(42,43);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*25.2);
			Block= Level;
			Family=20;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1;
 
			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 0.45f;
			CombatReach = 0.8f;
			Size = 0.9f;
			Speed = 2.99f;
			WalkSpeed = 2.99f;
			RunSpeed = 5.99f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 669, 42 );
			Loots = new BaseTreasure[]{  new BaseTreasure( ScorpidDrops.DeadlyCleftScorpid , 100f )
										};
		}
	}
}


namespace Server.Creatures
{
	public class DeathFlayer : BaseCreature
	{
		public DeathFlayer() : base()
		{
			Name = "Death Flayer";
			Id = 5823;
			Model = 2491;
			Level = RandomLevel(11);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= 3189;
			Block= Level;
			Family=20;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1;

			BaseMana = 0;			
			AttackSpeed = 2000;			
			BoundingRadius = 0.78f;
			CombatReach = 0.8f;
			Size = 1.15f;
			Elite=4;
			Speed = 3.38f;
			WalkSpeed = 3.38f;
			RunSpeed = 6.38f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 652, 11 );
			Loots = new BaseTreasure[]{  new BaseTreasure( ScorpidDrops.DeathFlayer , 100f )
										};
		}
	}
}




namespace Server.Creatures
{
	public class DeathlashScorpid : BaseCreature
	{
		public DeathlashScorpid() : base()
		{
			Name = "Deathlash Scorpid";
			Id = 9695;
			Model = 10984;
			Level = RandomLevel(54,55);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*25.2);
			Block= Level;
			Family=20;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1;
 
			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 0.5f;
			CombatReach = 0.8f;
			Size = 0.8f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 3533, 54 );
			Loots = new BaseTreasure[]{  new BaseTreasure( ScorpidDrops.DeathlashScorpid , 100f )
										};
		}
	}
}




namespace Server.Creatures
{
	public class DeepStinger : BaseCreature
	{
		public DeepStinger() : base()
		{
			Name = "Deep Stinger";
			Id = 8926;
			Model = 6068;
			Level = RandomLevel(50,52);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*25.2);
			Block= Level;
			Family=20;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1;
 
			BaseMana = 0;
			AttackSpeed = 1400;			
			BoundingRadius = 1.0f;
			CombatReach = 0.8f;
			Size = 0.8f;
			Speed = 3.3f;
			WalkSpeed = 3.3f;
			RunSpeed = 6.3f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 2554, 50 );
			Loots = new BaseTreasure[]{  new BaseTreasure( ScorpidDrops.DeepStinger , 100f )
										};
		}
	}
}



namespace Server.Creatures
{
	public class FiretailScorpid : BaseCreature
	{
		public FiretailScorpid() : base()
		{
			Name = "Firetail Scorpid";
			Id = 9698;
			Model = 10985;
			Level = RandomLevel(56,57);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*25.2);
			Block= Level;
			Family=20;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1;

			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 0.870f;
			CombatReach = 0.8f;
			Size = 1.75f;
			Speed = 2.8f;
			WalkSpeed = 2.8f;
			RunSpeed = 5.8f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 3340, 56 );
			Loots = new BaseTreasure[]{  new BaseTreasure( ScorpidDrops.FiretailScorpid , 100f )
										};
		}
	}
}



namespace Server.Creatures
{
	public class Krellack : BaseCreature
	{
		public Krellack() : base()
		{
			Name = "Krellack";
			Id = 14476;
			Model = 6068;
			Level = RandomLevel(56);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= 3189;
			Block= Level;
			Family=20;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1;

			BaseMana = 0;			
			AttackSpeed = 2000;			
			BoundingRadius = 0.78f;
			CombatReach = 0.8f;
			Size = 1.5f;
			Elite=4;
			Speed = 3.8f;
			WalkSpeed = 3.8f;
			RunSpeed = 6.8f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 4183, 56 );
			Loots = new BaseTreasure[]{  new BaseTreasure( ScorpidDrops.Krellack , 100f )
										};
		}
	}
}



namespace Server.Creatures
{
	public class Sarkoth : BaseCreature
	{
		public Sarkoth() : base()
		{
			Name = "Sarkoth";
			Id = 3281;
			Model = 10985;
			Level = RandomLevel(4);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*25.2);
			Block= Level;
			Family=20;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1;
float step=1.045f;//step by incrase Heals in elite mobs first rang
if (Level==4)		
{
 BaseHitPoints = 87;
} 
else
{
for (int i=1; i<=(Level-4); i++)
 {
  step=step*step;
 }	
 BaseHitPoints = (int)(87*(float)step);
} 
			BaseMana = 100;
			AttackSpeed = 2000;			
			BoundingRadius = 0.870f;
			CombatReach = 0.8f;
			Size = 0.85f;
			Speed = 2.9f;
			WalkSpeed = 2.9f;
			RunSpeed = 5.9f;
			Faction = Factions.Monster;
BCAddon.Hp( this, 87, 4 );				
LearnSpell( 744, SpellsTypes.Offensive );			
			AIEngine = new SpellCasterAI( this );
			Flags1 = 0x010;
			Loots = new BaseTreasure[]{  new BaseTreasure( ScorpidDrops.Sarkoth , 100f )
										};
		}
	}
}



namespace Server.Creatures
{
	public class ScorpashiLasher : BaseCreature
	{
		public ScorpashiLasher() : base()
		{
			Name = "Scorpashi Lasher";
			Id = 4697;
			Model = 2765;
			Level = RandomLevel(34,35);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*25.2);
			Block= Level;
			Family=20;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1;

			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 0.570f;
			CombatReach = 0.8f;
			Size = 1.15f;
			Speed = 2.9f;
			WalkSpeed = 2.9f;
			RunSpeed = 5.9f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 1357, 34 );
			Loots = new BaseTreasure[]{  new BaseTreasure( ScorpidDrops.ScorpashiLasher , 100f )
										};
		}
	}
}



namespace Server.Creatures
{
	public class ScorpashiSnapper : BaseCreature
	{
		public ScorpashiSnapper() : base()
		{
			Name = "Scorpashi Snapper";
			Id = 4696;
			Model = 2729;
			Level = RandomLevel(30,31);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*25.2);
			Block= Level;
			Family=20;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1;

			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 0.570f;
			CombatReach = 0.8f;
			Size = 1.15f;
			Speed = 3.4f;
			WalkSpeed = 3.4f;
			RunSpeed = 6.4f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 1152, 30 );
			Loots = new BaseTreasure[]{  new BaseTreasure( ScorpidDrops.ScorpashiSnapper , 100f )
										};
		}
	}
}




namespace Server.Creatures
{
	public class ScorpashiVenomlash : BaseCreature
	{
		public ScorpashiVenomlash() : base()
		{
			Name = "Scorpashi Venomlash";
			Id = 4699;
			Model = 2766;
			Level = RandomLevel(38,39);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*25.2);
			Block= Level;
			Family=20;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1;

			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 0.650f;
			CombatReach = 0.8f;
			Size = 1.3f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 1590, 38 );
			Loots = new BaseTreasure[]{  new BaseTreasure( ScorpidDrops.ScorpashiVenomlash , 100f )
										};
		}
	}
}



namespace Server.Creatures
{
	public class ScorpidDuneburrower : BaseCreature
	{
		public ScorpidDuneburrower() : base()
		{
			Name = "Scorpid Duneburrower";
			Id = 7803;
			Model = 2414;
			Level = RandomLevel(46,47);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*25.2);
			Block= Level;
			Family=20;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1;
 
			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 0.50f;
			CombatReach = 0.8f;
			Size = 0.8f;
			Speed = 3.0f;
			WalkSpeed = 3.0f;
			RunSpeed = 6.0f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 2213, 46 );
			Loots = new BaseTreasure[]{  new BaseTreasure( ScorpidDrops.ScorpidDuneburrower , 100f )
										};
		}
	}
}




namespace Server.Creatures
{
	public class ScorpidDunestalker : BaseCreature
	{
		public ScorpidDunestalker() : base()
		{
			Name = "Scorpid Dunestalker";
			Id = 5424;
			Model = 10986;
			Level = RandomLevel(46,47);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*25.2);
			Block= Level;
			Family=20;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1;

			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 0.650f;
			CombatReach = 0.8f;
			Size = 1.3f;
			Speed = 3.0f;
			WalkSpeed = 3.0f;
			RunSpeed = 6.0f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 2222, 46 );
			Loots = new BaseTreasure[]{  new BaseTreasure( ScorpidDrops.ScorpidDunestalker , 100f )
										};
		}
	}
}



namespace Server.Creatures
{
	public class ScorpidHunter : BaseCreature
	{
		public ScorpidHunter() : base()
		{
			Name = "Scorpid Hunter";
			Id = 5422;
			Model = 2414;
			Level = RandomLevel(39,41);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*25.2);
			Block= Level;
			Family=20;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1;
 
			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 0.50f;
			CombatReach = 0.8f;
			Size = 0.5f;
			Speed = 2.6f;
			WalkSpeed = 2.6f;
			RunSpeed = 5.6f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 1483, 39 );
			Loots = new BaseTreasure[]{  new BaseTreasure( ScorpidDrops.ScorpidHunter , 100f )
										};
		}
	}
}



namespace Server.Creatures
{
	public class ScorpidReaver : BaseCreature
	{
		public ScorpidReaver() : base()
		{
			Name = "Scorpid Reaver";
			Id = 4140;
			Model = 2414;
			Level = RandomLevel(31,32);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*25.2);
			Block= Level;
			Family=20;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1;

			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 0.50f;
			CombatReach = 0.8f;
			Size = 0.8f;
			Speed = 2.9f;
			WalkSpeed = 2.9f;
			RunSpeed = 5.9f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 907, 31 );
			Loots = new BaseTreasure[]{  new BaseTreasure( ScorpidDrops.ScorpidReaver , 100f )
										};
		}
	}
}



namespace Server.Creatures
{
	public class ScorpidTailLasher : BaseCreature
	{
		public ScorpidTailLasher() : base()
		{
			Name = "Scorpid Tail Lasher";
			Id = 5423;
			Model = 10987;
			Level = RandomLevel(43,44);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*25.2);
			Block= Level;
			Family=20;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1;
 
			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 0.50f;
			CombatReach = 0.8f;
			Size = 1.15f;
			Speed = 2.9f;
			WalkSpeed = 2.9f;
			RunSpeed = 5.9f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 1889, 43 );
			Loots = new BaseTreasure[]{  new BaseTreasure( ScorpidDrops.ScorpidTailLasher , 100f )
										};
		}
	}
}




namespace Server.Creatures
{
	public class ScorpidTerror : BaseCreature
	{
		public ScorpidTerror() : base()
		{
			Name = "Scorpid Terror";
			Id = 4139;
			Model = 2491;
			Level = RandomLevel(33,34);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*25.2);
			Block= Level;
			Family=20;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1;

			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 0.570f;
			CombatReach = 0.8f;
			Size = 1.15f;
			Speed = 2.8f;
			WalkSpeed = 2.8f;
			RunSpeed = 5.8f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 1210, 33 );
			Loots = new BaseTreasure[]{  new BaseTreasure( ScorpidDrops.ScorpidTerror , 100f )
										};
		}
	}
}



namespace Server.Creatures
{
	public class ScorpidWorker : BaseCreature
	{
		public ScorpidWorker() : base()
		{
			Name = "Scorpid Worker";
			Id = 3124;
			Model = 2485;
			Level = RandomLevel(3);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*25.2);
			Block= Level;
			Family=20;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1;

			BaseMana = 100;
			AttackSpeed = 2000;			
			BoundingRadius = 0.570f;
			CombatReach = 0.8f;
			Size = 0.7f;
			Speed = 2.8f;
			WalkSpeed = 2.8f;
			RunSpeed = 5.8f;
			Faction = Factions.NoFaction;
			AIEngine = new SpellCasterAI( this );
BCAddon.Hp( this, 46, 3 );				
LearnSpell( 6751, SpellsTypes.Offensive );
			Flags1 = 0x010;
			Loots = new BaseTreasure[]{  new BaseTreasure( ScorpidDrops.ScorpidWorker , 100f )
										};
		}
	}
}



namespace Server.Creatures
{
	public class ScorpokStinger : BaseCreature
	{
		public ScorpokStinger() : base()
		{
			Name = "Scorpok Stinger";
			Id = 5988;
			Model = 6068;
			Level = RandomLevel(50,51);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*25.2);
			Block= Level;
			Family=20;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1;
			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 0.75f;
			CombatReach = 0.8f;
			Size = 1.5f;
			Speed = 2.8f;
			WalkSpeed = 2.8f;
			RunSpeed = 5.8f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 1407, 50 );
			Loots = new BaseTreasure[]{  new BaseTreasure( ScorpidDrops.ScorpokStinger, 100f )
										};
		}
	}
}



namespace Server.Creatures
{
	public class SilithidCreeper : BaseCreature
	{
		public SilithidCreeper() : base()
		{
			Name = "Silithid Creeper";
			Id = 3250;
			Model = 2730;
			Level = RandomLevel(20,21);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*25.2);
			Block= Level;
			Family=20;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1;

			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 0.5f;
			CombatReach = 0.8f;
			Size = 1f;
			Speed = 3.5f;
			WalkSpeed = 3.5f;
			RunSpeed = 6.5f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 365, 20 );
			Loots = new BaseTreasure[]{  new BaseTreasure( ScorpidDrops.SilithidCreeper, 100f )
										};
		}
	}
}




namespace Server.Creatures
{
	public class SilithidSwarmer : BaseCreature
	{
		public SilithidSwarmer() : base()
		{
			Name = "Silithid Swarmer";
			Id = 3252;
			Model = 2731;
			Level = RandomLevel(21,22);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*25.2);
			Block= Level;
			Family=20;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1;
 
			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 0.45f;
			CombatReach = 0.8f;
			Size = 0.85f;
			Speed = 3.0f;
			WalkSpeed = 3.0f;
			RunSpeed = 6.0f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 256, 21 );
			Loots = new BaseTreasure[]{  new BaseTreasure( ScorpidDrops.SilithidSwarmer, 100f )
										};
		}
	}
}



namespace Server.Creatures
{
	public class StonelashFlayer : BaseCreature
	{
		public StonelashFlayer() : base()
		{
			Name = "Stonelash Flayer";
			Id = 11737;
			Model = 10988;
			Level = RandomLevel(58,59);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*25.2);
			Block= Level;
			Family=20;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1;

			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 0.45f;
			CombatReach = 0.8f;
			Size = 1f;
			Speed = 2.9f;
			WalkSpeed = 2.9f;
			RunSpeed = 5.9f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 3365, 58 );
			Loots = new BaseTreasure[]{  new BaseTreasure( ScorpidDrops.StonelashFlayer, 100f )
										};
		}
	}
}



namespace Server.Creatures
{
	public class StonelashPincer : BaseCreature
	{
		public StonelashPincer() : base()
		{
			Name = "Stonelash Pincer";
			Id = 11736;
			Model = 10988;
			Level = RandomLevel(56,57);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*25.2);
			Block= Level;
			Family=20;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1;

			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 1f;
			CombatReach = 0.8f;
			Size = 1f;
			Speed = 2.9f;
			WalkSpeed = 2.9f;
			RunSpeed = 5.9f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 3884, 56 );
			Loots = new BaseTreasure[]{  new BaseTreasure( ScorpidDrops.StonelashPincer, 100f )
										};
		}
	}
}



namespace Server.Creatures
{
	public class StonelashScorpid : BaseCreature
	{
		public StonelashScorpid() : base()
		{
			Name = "Stonelash Scorpid";
			Id = 11735;
			Model = 10988;
			Level = RandomLevel(54,55);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*25.2);
			Block= Level;
			Family=20;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1;

			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 1f;
			CombatReach = 0.8f;
			Size = 1f;
			Speed = 1.3f;
			WalkSpeed = 1.3f;
			RunSpeed = 6.3f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 3012, 54 );
			Loots = new BaseTreasure[]{  new BaseTreasure( ScorpidDrops.StonelashScorpid, 100f )
										};
		}
	}
}



namespace Server.Creatures
{
	public class VenomlashScorpid : BaseCreature
	{
		public VenomlashScorpid() : base()
		{
			Name = "Venomlash Scorpid";
			Id = 7022;
			Model = 2488;
			Level = RandomLevel(39,40);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*3.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= 3189;
			Block= Level*2;
			Family=20;
			SetDamage(1f+2.5f*Level,1f+3.0*Level);
			ManaType=1;

			BaseMana = 0;			
			AttackSpeed = 2000;			
			BoundingRadius = 0.78f;
			CombatReach = 0.8f;
			Size = 0.8f;
			Elite=1;
			Speed = 3.4f;
			WalkSpeed = 3.4f;
			RunSpeed = 6.4f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 3183, 39 );
			Loots = new BaseTreasure[]{  new BaseTreasure( ScorpidDrops.VenomlashScorpid , 100f )
										};
		}
	}
}



namespace Server.Creatures
{
	public class VenomtailScorpid : BaseCreature
	{
		public VenomtailScorpid() : base()
		{
			Name = "Venomtail Scorpid";
			Id = 3127;
			Model = 2732;
			Level = RandomLevel(9,10);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*25.2);
			Block= Level;
			Family=20;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1;
 
			BaseMana = 100;
			AttackSpeed = 2000;			
			BoundingRadius = 1f;
			CombatReach = 0.8f;
			Size = 0.7f;
			Speed = 2.6f;
			WalkSpeed = 2.6f;
			RunSpeed = 5.6f;
			Faction = Factions.Monster;
			AIEngine = new SpellCasterAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 189, 9 );
LearnSpell( 5416, SpellsTypes.Offensive );
LearnSpell( 8257, SpellsTypes.Offensive );
LearnSpell( 1604, SpellsTypes.Offensive );
			Loots = new BaseTreasure[]{  new BaseTreasure( ScorpidDrops.VenomtailScorpid, 100f )
										};
		}
	}
}





namespace Server.Creatures
{
	public class VenomtipScorpid : BaseCreature
	{
		public VenomtipScorpid() : base()
		{
			Name = "Venomtip Scorpid";
			Id = 9691;
			Model = 8970;
			Level = RandomLevel(52,53);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*25.2);
			Block= Level;
			Family=20;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1;

			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 0.65f;
			CombatReach = 0.8f;
			Size = 1.3f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 2333, 52 );
			Loots = new BaseTreasure[]{  new BaseTreasure( ScorpidDrops.VenomtipScorpid, 100f )
										};
		}
	}
}



namespace Server.Creatures
{
	public class VileSting : BaseCreature
	{
		public VileSting() : base()
		{
			Name = "Vile Sting";
			Id = 5937;
			Model = 10988;
			Level = RandomLevel(35);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*4.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= 3989;
			Block= Level*3;
			Family=20;
			SetDamage(1f+3.0f*Level,1f+3.5*Level);
			ManaType=1;

			BaseMana = 0;			
			AttackSpeed = 2000;			
			BoundingRadius = 1f;
			CombatReach = 0.8f;
			Size = 1.15f;
			Elite=1;
			Speed = 4f;
			WalkSpeed = 4f;
			RunSpeed = 7f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 3783, 35 );
			Loots = new BaseTreasure[]{  new BaseTreasure( ScorpidDrops.VileSting , 100f )
										};
		}
	}
}
