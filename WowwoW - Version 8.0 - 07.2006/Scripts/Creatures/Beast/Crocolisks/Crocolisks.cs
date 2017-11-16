//	Script made by Sapphiron - 01/06/05 02:45:30
//Script created by Sapphiron, please feel free to do any correction
//File: Crocilisk.CS 
//May, 26, 2005

using System;
using System.Collections;
using Server;
using Server.Items;

namespace Server.Creatures
{
	public class CorruptedDreadmawCrocolisk : BaseCreature
	{
		public CorruptedDreadmawCrocolisk() : base()
		{
			Name = "Corrupted Dreadmaw Crocolisk";
			Id = 3231;
			Model = 1034;
			Level = RandomLevel(9,13);
			SetDamage(11f,17f);
			AttackSpeed = 2000;
			Armor = 300;
			BaseMana = 0;
			ManaType=1;
			BoundingRadius = 1.3f;
			CombatReach = 1.1f;
			Size = 1f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			BCAddon.Hp( this, 356, 9 );
			SkinLoot = new Loot[] { new Loot( typeof( LightHide ), 1.02f )
									  ,new Loot( typeof( LightLeather ), 14.77f )
								  };
			Loots = new BaseTreasure[]{ new BaseTreasure( CrocoliskDrops.DreadmawCrocolisk, 100.0f )};
		}
	}
}

namespace Server.Creatures
{
	public class DreadmawCrocolisk : BaseCreature
	{
		public DreadmawCrocolisk() : base()
		{
			Name = "Dreadmaw Crocolisk";
			Id = 3110;
			Model = 1250;
			Level = RandomLevel(6,11);
			SetDamage(10f,16f);
			AttackSpeed = 2000;
			Armor = 300;
BaseMana = 100;
ManaType=1;
			BoundingRadius = 1.3f;
			CombatReach = 1.1f;
			Size = 1f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.Monster;
			AIEngine = new SpellCasterAI( this );
			NpcType = 1;
	LearnSpell( 1604, SpellsTypes.Offensive );
	LearnSpell( 12166, SpellsTypes.Offensive );
			BCAddon.Hp( this, 324, 6 );
			SkinLoot = new Loot[] { new Loot( typeof( LightLeather ), 8.12f )
								  };
			Loots = new BaseTreasure[]{ new BaseTreasure( CrocoliskDrops.DreadmawCrocolisk, 100.0f )};

		}
	}
}

namespace Server.Creatures
{
	public class TamedCrocolisk : BaseCreature
	{
		public TamedCrocolisk() : base()
		{
			Name = "Tamed Crocolisk";
			Id = 5440;
			Model = 1036;
			Level = RandomLevel(2,5);
			SetDamage(3f,5f);
			AttackSpeed = 1935;
			Armor = 90;
BaseMana = 0;
ManaType=1;
			BoundingRadius = 1f;
			CombatReach = 0.9f;
			Size = 1f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			BCAddon.Hp( this, 135, 2 );
		}
	}
}

namespace Server.Creatures
{
	public class Deadmire : BaseCreature
	{
		public Deadmire() : base()
		{
			Name = "Deadmire";
			Id = 4841;
			Model = 2850;
			Level = RandomLevel(45,45);
			SetDamage(45f,70f);
			Armor = 1350;
			AttackSpeed = 2114;
BaseMana = 0;
ManaType=1;
			BaseMana = 0;
			BoundingRadius = 1.6f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			BCAddon.Hp( this, 1558, 45 );
			SkinLoot = new Loot[] { new Loot( typeof( HeavyHide ), 0.38f )
									  ,new Loot( typeof( HeavyLeather ), 4.99f )
									  ,new Loot( typeof( ThickHide ), 0.38f )
									  ,new Loot( typeof( ThickLeather ), 7.44f )
								  };
			Loots = new BaseTreasure[]{ new BaseTreasure( CrocoliskDrops.Deadmire, 100.0f )};

		}
	}
}

namespace Server.Creatures
{
	public class DeviateCrocolisk : BaseCreature
	{
		public DeviateCrocolisk() : base()
		{
			Name = "Deviate Crocolisk";
			Id = 5053;
			Model = 2996;
			Level = RandomLevel(13,19);
			SetDamage(13f,29f);
			AttackSpeed = 2020;
			Armor = 300;
BaseMana = 0;
ManaType=1;

			BaseMana = 0;
			BoundingRadius = 1.3f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			BCAddon.Hp( this, 480, 13 );
			SkinLoot = new Loot[] { new Loot( typeof( LightHide ), 0.65f )
									  ,new Loot( typeof( LightLeather ), 8.81f )
									  ,new Loot( typeof( MediumHide ), 0.24f )
									  ,new Loot( typeof( MediumLeather ), 2.62f )
								  };
			Loots = new BaseTreasure[]{ new BaseTreasure( CrocoliskDrops.DeviateCrocolisk, 100.0f )};

		}
	}
}

namespace Server.Creatures
{
	public class DrywallowCrocolisk : BaseCreature
	{
		public DrywallowCrocolisk() : base()
		{
			Name = "Drywallow Crocolisk";
			Id = 4341;
			Model = 1080;
			Level = RandomLevel(35,36);
			SetDamage(35f,56f);
			AttackSpeed = 2075;
			Armor = 1050;
BaseMana = 0;
ManaType=1;

			BaseMana = 0;
			BoundingRadius = 1.3f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			BCAddon.Hp( this, 1266, 35 );
			SkinLoot = new Loot[] { new Loot( typeof( HeavyHide ), 0.64f )
									  ,new Loot( typeof( HeavyLeather ), 10.29f )
									  ,new Loot( typeof( MediumHide ), 0.95f )
									  ,new Loot( typeof( MediumLeather ), 8.56f )
								  };
			Loots = new BaseTreasure[]{ new BaseTreasure( CrocoliskDrops.DrywallowCrocolisk, 100.0f )};

		}
	}
}

namespace Server.Creatures
{
	public class DrywallowSnapper : BaseCreature
	{
		public DrywallowSnapper() : base()
		{
			Name = "Drywallow Snapper";
			Id = 4343;
			Model = 814;
			Level = RandomLevel(37,38);
			SetDamage(37f,59f);
			AttackSpeed = 2075;
			Armor = 1150;
BaseMana = 0;
ManaType=1;

			BaseMana = 0;
			BoundingRadius = 1.4f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			BCAddon.Hp( this, 1912, 37 );
			SkinLoot = new Loot[] { new Loot( typeof( HeavyHide ), 0.62f )
									  ,new Loot( typeof( HeavyLeather ), 16.33f )
									  ,new Loot( typeof( ThickLeather ), 4.37f )
								  };
			Loots = new BaseTreasure[]{ new BaseTreasure( CrocoliskDrops.DrywallowVicejaw, 100.0f )};

		}
	}
}

namespace Server.Creatures
{
	public class DrywallowVicejaw : BaseCreature
	{
		public DrywallowVicejaw() : base()
		{
			Name = "Drywallow Vicejaw";
			Id = 4342;
			Model = 925;
			Level = RandomLevel(34,37);
			SetDamage(34f,57f);
			AttackSpeed = 2070;
			Armor = 1050;
BaseMana = 0;
ManaType=1;

			BaseMana = 0;
			BoundingRadius = 1.4f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			BCAddon.Hp( this, 1299, 34 );
			SkinLoot = new Loot[] { new Loot( typeof( HeavyHide ), 0.59f )
									  ,new Loot( typeof( HeavyLeather ), 14.60f )
									  ,new Loot( typeof( ThickLeather ), 3.62f )
								  };
			Loots = new BaseTreasure[]{ new BaseTreasure( CrocoliskDrops.DrywallowVicejaw, 100.0f )};

		}
	}
}

namespace Server.Creatures
{
	public class GiantWetlandsCrocolisk : BaseCreature
	{
		public GiantWetlandsCrocolisk() : base()
		{
			Name = "Giant Wetlands Crocolisk";
			Id = 2089;
			Model = 925;
			Level = RandomLevel(22,26);
			SetDamage(22f,40f);
			AttackSpeed = 2000;
			Armor = 750;
BaseMana = 0;
ManaType=1;

			BaseMana = 0;
			BoundingRadius = 1.3f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.Monster;
			AIEngine = new SpellCasterAI( this );
			NpcType = 1;
LearnSpell( 3604, SpellsTypes.Offensive );
BCAddon.Hp( this, 942, 22 );			
			SkinLoot = new Loot[] { new Loot( typeof( LightHide ), 0.61f )
									  ,new Loot( typeof( LightLeather ), 7.60f )
									  ,new Loot( typeof( MediumHide ), 0.90f )
									  ,new Loot( typeof( MediumLeather ), 8.75f )
								  };
			Loots = new BaseTreasure[]{ new BaseTreasure( CrocoliskDrops.GiantWetlandsCrocolisk, 100.0f )};

		}
	}
}

namespace Server.Creatures
{
	public class LargeLochCrocolisk : BaseCreature
	{
		public LargeLochCrocolisk() : base()
		{
			Name = "Large Loch Crocolisk";
			Id = 2476;
			Model = 831;
			Level = RandomLevel(22,23);
			SetDamage(22f,36f);
			AttackSpeed = 2050;
			Armor = 690;
BaseMana = 0;
ManaType=1;

			BaseMana = 0;
			BoundingRadius = 1.3f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			BCAddon.Hp( this, 845, 22 );
			SkinLoot = new Loot[] { new Loot( typeof( LightHide ), 0.50f )
									  ,new Loot( typeof( LightLeather ), 3.75f )
									  ,new Loot( typeof( MediumLeather ), 4.00f )
								  };
			Loots = new BaseTreasure[]{ new BaseTreasure( CrocoliskDrops.LargeLochCrocolisk, 100.0f )};

		}
	}
}

namespace Server.Creatures
{
	public class LochCrocolisk : BaseCreature
	{
		public LochCrocolisk() : base()
		{
			Name = "Loch Crocolisk";
			Id = 1693;
			Model = 1034;
			Level = RandomLevel(11,15);
			SetDamage(11f,21f);
			AttackSpeed = 2000;
			Armor = 390;
BaseMana = 100;
ManaType=1;
float step=1.045f; //%the HP goes up per extra level
if (Level==11)		
{
 BaseHitPoints = 521;
} 
else
{
for (int i=1; i<=(Level-11); i++)
 {
  step=step*step;
 }	
 BaseHitPoints = (int)(521*(float)step);
}
			BoundingRadius = 1.3f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.Monster;
			AIEngine = new SpellCasterAI( this );
			NpcType = 1;
BCAddon.Hp( this, 521, 11 );		
	LearnSpell( 1604, SpellsTypes.Offensive );
			
			SkinLoot = new Loot[] { new Loot( typeof( LightHide ), 1.11f )
									  ,new Loot( typeof( LightLeather ), 13.07f )
								  };
			Loots = new BaseTreasure[]{ new BaseTreasure( CrocoliskDrops.LochCrocolisk, 100.0f )};

		}
	}
}

namespace Server.Creatures
{
	public class MottledDrywallowCrocolisk : BaseCreature
	{
		public MottledDrywallowCrocolisk() : base()
		{
			Name = "Mottled Drywallow Crocolisk";
			Id = 4344;
			Model = 2548;
			Level = RandomLevel(37,39);
			SetDamage(37f,59f);
			AttackSpeed = 2100;
			Armor = 1170;
BaseMana = 0;
ManaType=1;

			BoundingRadius = 1.5f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			BCAddon.Hp( this, 1331, 37 );
			SkinLoot = new Loot[] { new Loot( typeof( HeavyHide ), 0.60f )
									  ,new Loot( typeof( HeavyLeather ), 15.04f )
								  };
			Loots = new BaseTreasure[]{ new BaseTreasure( CrocoliskDrops.DrywallowVicejaw, 100.0f )};

		}
	}
}

namespace Server.Creatures
{
	public class RiverCrocolisk : BaseCreature
	{
		public RiverCrocolisk() : base()
		{
			Name = "River Crocolisk";
			Id = 1150;
			Model = 1039;
			Level = RandomLevel(30,31);
			SetDamage(31f,48f);
			AttackSpeed = 2100;
			Armor = 930;
BaseMana = 0;
ManaType=1;

			BoundingRadius = 1.33f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			BCAddon.Hp( this, 1072, 30 );
			SkinLoot = new Loot[] { new Loot( typeof( HeavyLeather ), 10.94f )
									  ,new Loot( typeof( MediumLeather ), 40.63f )
									  ,new Loot( typeof( ThickLeather ), 3.73f )
								  };
			Loots = new BaseTreasure[]{ new BaseTreasure( CrocoliskDrops.RiverCrocolisk, 100.0f )};

		}
	}
}

namespace Server.Creatures
{
	public class SaltwaterCrocolisk : BaseCreature
	{
		public SaltwaterCrocolisk() : base()
		{
			Name = "Saltwater Crocolisk";
			Id = 1151;
			Model = 2548;
			Level = RandomLevel(35,36);
			SetDamage(36f,56f);
			AttackSpeed = 2125;
			Armor = 1080;
BaseMana = 0;
ManaType=1;

			BoundingRadius = 1.33f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			BCAddon.Hp( this, 1266, 35 );
			SkinLoot = new Loot[] { new Loot( typeof( MediumLeather ), 18.52f )
									  ,new Loot( typeof( HeavyLeather ), 25.93f )
								  };
			Loots = new BaseTreasure[]{ new BaseTreasure( CrocoliskDrops.SaltwaterCrocolisk, 100.0f )};

		}
	}
}

namespace Server.Creatures
{
	public class SawtoothCrocolisk : BaseCreature
	{
		public SawtoothCrocolisk() : base()
		{
			Name = "Sawtooth Crocolisk";
			Id = 1082;
			Model = 807;
			Level = RandomLevel(38,39);
			SetDamage(39f,61f);
			AttackSpeed = 2125;
			Armor = 1170;
BaseMana = 0;
ManaType=1;

			BoundingRadius = 1.33f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			BCAddon.Hp( this, 1363, 38 );
			SkinLoot = new Loot[] { new Loot( typeof( HeavyHide ), 0.81f )
									  ,new Loot( typeof( HeavyLeather ), 41.67f )
									  ,new Loot( typeof( ThickLeather ), 11.59f )
								  };
			Loots = new BaseTreasure[]{ new BaseTreasure( CrocoliskDrops.SawtoothCrocolisk, 100.0f )};

		}
	}
}

namespace Server.Creatures
{
	public class SawtoothSnapper : BaseCreature
	{
		public SawtoothSnapper() : base()
		{
			Name = "Sawtooth Snapper";
			Id = 1087;
			Model = 815;
			Level = RandomLevel(41,42);
			SetDamage(42f,65f);
			AttackSpeed = 2190;
			Armor = 1230;
BaseMana = 0;
ManaType=1;

			BoundingRadius = 1.4f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			BCAddon.Hp( this, 1460, 41 );
			SkinLoot = new Loot[] { new Loot( typeof( HeavyHide ), 0.72f )
									  ,new Loot( typeof( HeavyLeather ), 23.10f )
									  ,new Loot( typeof( ThickHide ), 1.44f )
									  ,new Loot( typeof( ThickLeather ), 26.71f )
								  };
			Loots = new BaseTreasure[]{ new BaseTreasure( CrocoliskDrops.SawtoothSnapper, 100.0f )};

		}
	}
}

namespace Server.Creatures
{
	public class SewerBeast : BaseCreature
	{
		public SewerBeast() : base()
		{
			Name = "Sewer Beast";
			Id = 3581;
			Model = 2850;
			Level = RandomLevel(50,50);
			SetDamage(432f,614f);
			AttackSpeed = 2200;
			Armor = 1500;
BaseMana = 0;
ManaType=1;

			BoundingRadius = 1.5f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			BCAddon.Hp( this, 1720, 50 );
			SkinLoot = new Loot[] { new Loot( typeof( RuggedLeather ), 3.06f )
									  ,new Loot( typeof( ThickHide ), 2.06f )
									  ,new Loot( typeof( ThickLeather ), 14.29f )
								  };
			Loots = new BaseTreasure[]{ new BaseTreasure( CrocoliskDrops.SewerBeast, 100.0f )};

		}
	}
}

namespace Server.Creatures
{
	public class SnapjawCrocolisk : BaseCreature
	{
		public SnapjawCrocolisk() : base()
		{
			Name = "Snapjaw Crocolisk";
			Id = 1152;
			Model = 833;
			Level = RandomLevel(35,36);
			SetDamage(36f,56f);
			AttackSpeed = 2155;
			Armor = 1080;
BaseMana = 0;
ManaType=1;

			BoundingRadius = 1.43f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			BCAddon.Hp( this, 1266, 35 );
			SkinLoot = new Loot[] { new Loot( typeof( HeavyLeather ), 29.36f )
									  ,new Loot( typeof( MediumLeather ), 23.85f )
								  };
			Loots = new BaseTreasure[]{ new BaseTreasure( CrocoliskDrops.SnapjawCrocolisk, 100.0f )};

		}
	}
}

namespace Server.Creatures
{
	public class WetlandsCrocolisk : BaseCreature
	{
		public WetlandsCrocolisk() : base()
		{
			Name = "Wetlands Crocolisk";
			Id = 1400;
			Model = 1036;
			Level = RandomLevel(21,22);
			SetDamage(22f,34f);
			AttackSpeed = 2050;
			Armor = 660;
BaseMana = 100;
ManaType=1;

			BoundingRadius = 1.23f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.Monster;
			AIEngine = new SpellCasterAI( this );
			NpcType = 1;
BCAddon.Hp( this, 813, 21 );		
	LearnSpell( 3604, SpellsTypes.Offensive );
			
			SkinLoot = new Loot[] { new Loot( typeof( LightHide ), 0.73f )
									  ,new Loot( typeof( LightLeather ), 10.30f )
									  ,new Loot( typeof( MediumHide ), 1.15f )
									  ,new Loot( typeof( MediumLeather ), 11.71f )
								  };
			Loots = new BaseTreasure[]{ new BaseTreasure( CrocoliskDrops.GiantWetlandsCrocolisk, 100.0f )};

		}
	}
}

namespace Server.Creatures
{
	public class YoungSawtoothCrocolisk : BaseCreature
	{
		public YoungSawtoothCrocolisk() : base()
		{
			Name = "Young Sawtooth Crocolisk";
			Id = 1084;
			Model = 814;
			Level = RandomLevel(35,36);
			SetDamage(36f,56f);
			AttackSpeed = 2125;
			Armor = 1070;
BaseMana = 0;
ManaType=1;

			BoundingRadius = 1.33f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			BCAddon.Hp( this, 1266, 35 );
			SkinLoot = new Loot[] { new Loot( typeof( HeavyHide ), 0.81f )
									  ,new Loot( typeof( HeavyLeather ), 41.67f )
									  ,new Loot( typeof( ThickLeather ), 11.59f )
								  };
			Loots = new BaseTreasure[]{ new BaseTreasure( CrocoliskDrops.SawtoothCrocolisk, 100.0f )};
		}
	}
}


namespace Server.Creatures
{
	public class YoungWetlandsCrocolisk : BaseCreature
	{
		public YoungWetlandsCrocolisk() : base()
		{
			Name = "Young Wetlands Crocolisk";
			Id = 1417;
			Model = 1035;
			Level = RandomLevel(21,22);
			SetDamage(22f,34f);
			AttackSpeed = 2020;
			Armor = 660;
BaseMana = 0;
ManaType=1;

			BoundingRadius = 1.2f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			BCAddon.Hp( this, 813, 21 );
			SkinLoot = new Loot[] { new Loot( typeof( LightLeather ), 11.11f )
									  ,new Loot( typeof( MediumHide ), 3.70f )
									  ,new Loot( typeof( MediumLeather ), 14.81f )
								  };
			Loots = new BaseTreasure[]{ new BaseTreasure( CrocoliskDrops.GiantWetlandsCrocolisk, 100.0f )};

		}
	}
}