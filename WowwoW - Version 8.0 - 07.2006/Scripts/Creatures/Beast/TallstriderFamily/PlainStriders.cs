//	Script made by Sapphiron - 31/05/05 21:29:15
//Script created by Sapphiron, please feel free to do any correction
//File: Plainstrider.CS 
//May, 27, 2005

using System;
using System.Collections;
using Server;
using Server.Items;

namespace Server.Creatures
{
	public class AdultPlainstrider : BaseCreature
	{
		public AdultPlainstrider() : base()
		{
			Name = "Adult Plainstrider";
			Id = 2956;
			Model = 1220;
			Level = RandomLevel(6,7);
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*5.2);;
			Block= Level;
			Family=12;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1; BaseMana = 0;

			BoundingRadius = 1f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.NoFaction;;
			AIEngine = new DefensiveAnimalAI( this );
			BCAddon.Hp( this, 130, 6 );
			SkinLoot = new Loot[] {new Loot( typeof( RuinedLeatherScraps), 10.9679f ) 
,new Loot( typeof( LightLeather), 7.14327f ) 
};
			Loots = new BaseTreasure[]{ new BaseTreasure( PlainstriderDrops.AdultPlainstrider, 100.0f )};
		}
	}
}

namespace Server.Creatures
{
	public class ElderPlainstrider : BaseCreature
	{
		public ElderPlainstrider() : base()
		{
			Name = "Elder Plainstrider";
			Id = 2957;
			Model = 1221;
			Level = RandomLevel(6,9);
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*5.2);;
			Block= Level;
			Family=12;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1; BaseMana = 0;

			BoundingRadius = 1f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.NoFaction;;
			AIEngine = new DefensiveAnimalAI( this );
			BCAddon.Hp( this, 161, 6 );
			SkinLoot = new Loot[] {new Loot( typeof( RuinedLeatherScraps), 12.1571f ) };
			Loots = new BaseTreasure[]{ new BaseTreasure( PlainstriderDrops.ElderPlainstrider, 100.0f )};

		}
	}
}

namespace Server.Creatures
{
	public class FleetingPlainstrider : BaseCreature
	{
		public FleetingPlainstrider() : base()
		{
			Name = "Fleeting Plainstrider";
			Id = 3246;
			Model = 1284;
			Level = RandomLevel(12,13);
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*5.2);;
			Block= Level;
			Family=12;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1; BaseMana = 0;
 
			BoundingRadius = 1f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.NoFaction;;
			AIEngine = new DefensiveAnimalAI( this );
			BCAddon.Hp( this, 243, 12 );
			SkinLoot = new Loot[] {new Loot( typeof( RuinedLeatherScraps), 6.89761f ) 
,new Loot( typeof( LightHide), 0.967773f ) 
,new Loot( typeof( LightLeather), 11.7705f ) 
};
			Loots = new BaseTreasure[]{ new BaseTreasure( PlainstriderDrops.FleetingPlainstrider, 100.0f )};
		}
	}
}

namespace Server.Creatures
{
	public class Foreststrider : BaseCreature
	{
		public Foreststrider() : base()
		{
			Name = "Foreststrider";
			Id = 2322;
			Model = 178;
			Level = RandomLevel(14,16);
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*5.2);;
			Block= Level;
			Family=12;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1; BaseMana = 0;

			BoundingRadius = 1f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.NoFaction;;
			AIEngine = new DefensiveAnimalAI( this );
			BCAddon.Hp( this, 141, 14 );
			SkinLoot = new Loot[] {new Loot( typeof( RuinedLeatherScraps), 6.21671f ) 
,new Loot( typeof( LightHide), 0.848868f ) 
,new Loot( typeof( LightLeather), 10.6441f ) 
};
			Loots = new BaseTreasure[]{ new BaseTreasure( PlainstriderDrops.Foreststrider, 100.0f )};

		}
	}
}

namespace Server.Creatures
{
	public class ForeststriderFledgling : BaseCreature
	{
		public ForeststriderFledgling() : base()
		{
			Name = "Foreststrider Fledgling";
			Id = 2321;
			Model = 1042;
			Level = RandomLevel(11,13);
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*5.2);;
			Block= Level;
			Family=12;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1; BaseMana = 0;

			BoundingRadius = 1f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.NoFaction;;
			AIEngine = new DefensiveAnimalAI( this );
			BCAddon.Hp( this, 194, 11 );
			SkinLoot = new Loot[] {new Loot( typeof( RuinedLeatherScraps), 7.39698f ) 
,new Loot( typeof( LightHide), 1.08371f ) 
,new Loot( typeof( LightLeather), 12.4742f ) 
};
			Loots = new BaseTreasure[]{ new BaseTreasure( PlainstriderDrops.ForeststriderFledgling, 100.0f )};
		}
	}
}

namespace Server.Creatures
{
	public class GiantForeststrider : BaseCreature
	{
		public GiantForeststrider() : base()
		{
			Name = "Giant Foreststrider";
			Id = 2323;
			Model = 1283;
			Level = RandomLevel(17,19);
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*5.2);;
			Block= Level;
			Family=12;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1; BaseMana = 0;

			BoundingRadius = 1.3f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.NoFaction;;
			AIEngine = new DefensiveAnimalAI( this );
			BCAddon.Hp( this, 343, 17 );
			SkinLoot = new Loot[] {new Loot( typeof( MediumHide), 0.289178f ) 
,new Loot( typeof( MediumLeather), 3.03835f ) 
,new Loot( typeof( LightHide), 0.720963f ) 
,new Loot( typeof( LightLeather), 10.8224f ) 
};
			Loots = new BaseTreasure[]{ new BaseTreasure( PlainstriderDrops.GiantForeststrider, 100.0f )};
		}
	}
}

namespace Server.Creatures
{
	public class GreaterPlainstrider : BaseCreature
	{
		public GreaterPlainstrider() : base()
		{
			Name = "Greater Plainstrider";
			Id = 3244;
			Model = 178;
			Level = RandomLevel(11,12);
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*5.2);;
			Block= Level;
			Family=12;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1; BaseMana = 0;

			BoundingRadius = 1.3f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.NoFaction;;
			AIEngine = new DefensiveAnimalAI( this );
			BCAddon.Hp( this, 197, 11 );
			SkinLoot = new Loot[] {new Loot( typeof( RuinedLeatherScraps), 8.07693f ) 
,new Loot( typeof( LightHide), 1.14845f ) 
,new Loot( typeof( LightLeather), 13.7528f ) 
};
			Loots = new BaseTreasure[]{ new BaseTreasure( PlainstriderDrops.GreaterPlainstrider, 100.0f )};
		}
	}
}

namespace Server.Creatures
{
	public class Mazzranache : BaseCreature
	{
		public Mazzranache() : base()
		{
			Name = "Mazzranache";
			Id = 3068;
			Model = 1961;
			Level = RandomLevel(9,9);
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= 851;
			Block= Level;
			Family=12;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1; BaseMana = 0;

			BoundingRadius = 1.1f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Elite=4;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 521, 9 );
			SkinLoot = new Loot[] {new Loot( typeof( RuinedLeatherScraps), 6.66667f ) 
,new Loot( typeof( LightLeather), 4.21456f ) 
};
			Loots = new BaseTreasure[]{ new BaseTreasure( PlainstriderDrops.Mazzranache, 100.0f )};			
		}
	}
}

namespace Server.Creatures
{
	public class OrneryPlainstrider : BaseCreature
	{
		public OrneryPlainstrider() : base()
		{
			Name = "Ornery Plainstrider";
			Id = 3245;
			Model = 6076;
			Level = RandomLevel(16,17);
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*5.2);;
			Block= Level;
			Family=12;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1; BaseMana = 0;

			BoundingRadius = 1.1f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 330, 16 );
			SkinLoot = new Loot[] {new Loot( typeof( MediumHide), 0.275903f ) 
,new Loot( typeof( MediumLeather), 2.89563f ) 
,new Loot( typeof( LightHide), 0.71275f ) 
,new Loot( typeof( LightLeather), 10.4289f ) 
};
			Loots = new BaseTreasure[]{ new BaseTreasure( PlainstriderDrops.OrneryPlainstrider, 100.0f )};

		}
	}
}

namespace Server.Creatures
{
	public class Plainstrider : BaseCreature
	{
		public Plainstrider() : base()
		{
			Name = "Plainstrider";
			Id = 2955;
			Model = 1219;
			Level = RandomLevel(1,2);
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*5.2);;
			Block= Level;
			Family=12;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1; BaseMana = 0;
 
			BoundingRadius = 1f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.NoFaction;;
			AIEngine = new DefensiveAnimalAI( this );
			BCAddon.Hp( this, 37, 1 );
			SkinLoot = new Loot[] {new Loot( typeof( MediumHide), 0.275903f ) 
,new Loot( typeof( MediumLeather), 2.89563f ) 
,new Loot( typeof( LightHide), 0.71275f ) 
,new Loot( typeof( LightLeather), 10.4289f ) 
};			
			Loots = new BaseTreasure[]{ new BaseTreasure( PlainstriderDrops.Plainstrider, 100.0f )};
		}
	}
}

namespace Server.Creatures
{
	public class Sandstrider : BaseCreature
	{
		public Sandstrider() : base()
		{
			Name = "Sandstrider";
			Id = 4724;
			Model = 2741;
			Level = RandomLevel(30,31);
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*5.2);;
			Block= Level;
			Family=12;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1; BaseMana = 0;

			BoundingRadius = 1.5f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.NoFaction;;
			AIEngine = new DefensiveAnimalAI( this );
			BCAddon.Hp( this, 851, 30 );
			SkinLoot = new Loot[] {new Loot( typeof( MediumHide), 0.275903f ) 
,new Loot( typeof( MediumLeather), 2.89563f ) 
,new Loot( typeof( LightHide), 0.71275f ) 
,new Loot( typeof( LightLeather), 10.4289f ) 
};			
			Loots = new BaseTreasure[]{ new BaseTreasure( PlainstriderDrops.Sandstrider, 100.0f )};			
			
		}
	}
}

namespace Server.Creatures
{
	public class StriderClutchmother : BaseCreature
	{
		public StriderClutchmother() : base()
		{
			Name = "Strider Clutchmother";
			Id = 2172;
			Model = 38;
			Level = RandomLevel(20,20);
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= 861;
			Block= Level;
			Family=12;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1; BaseMana = 0;

			BoundingRadius = 1.2f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 5f;
			WalkSpeed = 5f;
			Elite=4;
			RunSpeed = 8f;
			Faction = Factions.Monster;
			AIEngine = new DefensiveAnimalAI( this );
			BCAddon.Hp( this, 484, 20 );
			SkinLoot = new Loot[] {new Loot( typeof( LightHide), 2.15517f ) 
,new Loot( typeof( LightLeather), 15.9483f ) 
,new Loot( typeof( MediumHide), 0.431034f ) 
,new Loot( typeof( MediumLeather), 6.89655f ) 
};			
			Loots = new BaseTreasure[]{ new BaseTreasure( PlainstriderDrops.StriderClutchmother, 100.0f )};			
			
			
		}
	}
}
