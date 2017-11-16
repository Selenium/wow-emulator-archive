//	Script started by Saphirion, continued by BRDDY311
//	Base script completed 7/20/05
//	Invisibility and spells completed 8/9/05
//Bloodscalp Tiger has no skin/drops
//Skullsplitter Panther has no skin/drops
//Mountain Lion Mother has no skin/drops
//Savannah Cub has no skin/drops
using System;
using System.Collections;
using Server;
using Server.Items;

namespace Server.Creatures
{
	public class Araga : BaseCreature
	{
		public Araga() : base()
		{
			Name = "Araga";
			Id = 14222;
			Model = 1973;
			Level = RandomLevel(35,35);
			SetDamage(51f,76f);
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.91f;
			Armor = (int)(Level*45.2);
			Block = Level*4;
 			BaseHitPoints = 1224;
			Elite = 2;
			NpcFlags = 0;
			CombatReach = 1.5f;
			Size = 1.2f;
			Speed = 5.5f;
			WalkSpeed = 5.5f;
			RunSpeed = 8.8f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			SkinLoot = new Loot[] { new Loot( typeof( MediumLeather ), 50f )
									,new Loot( typeof( HeavyLeather ), 50f )
										};
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.Araga, 100f ) };
		}
	}
}

namespace Server.Creatures
{
	public class Bhagthera : BaseCreature
	{
		public Bhagthera() : base()
		{
			Name = "Bhag'thera";
			Id = 728;
			Model = 613;
			Level = RandomLevel(40,40);
			Elite = 1;
			SetDamage(51f,76f);
			AttackSpeed = 1500;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 1.15f;
			CombatReach = 2.01f;
			Armor = (int)(Level*42.2);
			Block = (int)(Level*2.4);
			BaseHitPoints = 1625;
			NpcFlags = 0;
			Size = 1.45f;
			Speed = 9f;
			WalkSpeed = 9f;
			RunSpeed = 14f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			SkinLoot = new Loot[] { new Loot( typeof( HeavyHide ), 2.1f )
									,new Loot( typeof( HeavyLeather ), 87.3f )
									,new Loot( typeof( ThickLeather ), 19.2f )
										};
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.Bhagthera, 100f ) };
			Visible = InvisibilityLevel.Lesser;
		}
	}
}

namespace Server.Creatures
{
	public class BloodscalpTiger : BaseCreature
	{
		public BloodscalpTiger() : base()
		{
			Name = "Bloodscalp Tiger";
			Id = 698;
			Model = 320;
			Level = RandomLevel(35,35);
			SetDamage(37f,48f);
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.795f;
			CombatReach = 1.5f;
			Armor = (int)(Level*26.2);
			Block = Level;
			BaseHitPoints = 1384;
			NpcFlags = 0;
			Size = 1f;
			Speed = 6f;
			WalkSpeed = 6f;
			RunSpeed = 9.3f;
			Faction = Factions.Beast;
			AIEngine = new DefensiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.BloodscalpTiger, 100f ) };
		}
	}
}

namespace Server.Creatures
{
	public class BrokenTooth : BaseCreature
	{
		public BrokenTooth() : base()
		{
			Name = "Broken Tooth";
			Id = 2850;
			Model = 6082;
			Level = RandomLevel(37,37);
			SetDamage(96f,137f);
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 1f;
			CombatReach = 1.5f;
			Armor = (int)(Level*45.2);
			Block = Level;
			BaseHitPoints = 2002;
			NpcFlags = 0;
			Size = 1f;
			Speed = 9f;
			WalkSpeed = 9f;
			RunSpeed = 14f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			Elite = 2;
			SkinLoot = new Loot[] { new Loot( typeof( HeavyLeather ), 33f )
									,new Loot( typeof( ThickLeather ), 67f )
										};
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.BrokenTooth, 100f ) };
		}
	}
}

namespace Server.Creatures
{
	public class CragStalker : BaseCreature
	{
		public CragStalker() : base()
		{
			Name = "Crag Stalker";
			Id = 4126;
			Model = 1043;
			Level = RandomLevel(25,26);
			SetDamage(26f,33f);
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.795f;
			CombatReach = 1.5f;
			Armor = (int)(Level*26.2);
			Block = Level;
float step=1.045f; //%the HP goes up per extra level
if (Level==25)		
{
 BaseHitPoints = 984;
} 
else
{
for (int i=1; i<=(Level-25); i++)
 {
  step=step*step;
 }	
 BaseHitPoints = (int)(984*(float)step);
} 
			NpcFlags = 0;
			Size = 1f;
			Speed = 5.5f;
			WalkSpeed = 5.5f;
			RunSpeed = 9f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			SkinLoot = new Loot[] { new Loot( typeof( LightHide ), 3.3f )
									,new Loot( typeof( LightLeather ), 69.3f )
									,new Loot( typeof( MediumHide ), 4.7f )
									,new Loot( typeof( MediumLeather ), 51.0f )
										};
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.CragStalker, 100f ) };
			Visible = InvisibilityLevel.Lesser;
		}
	}
}

namespace Server.Creatures
{
	public class Dishu : BaseCreature
	{
		public Dishu() : base()
		{
			Name = "Dishu";
			Id = 5865;
			Model = 1043;
			Level = RandomLevel(13,13);
			SetDamage(14f,18f);
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.795f;
			CombatReach = 1.5f;
			Armor = (int)(Level*45.2);
			Block = Level*2;
			BaseHitPoints = 540;
			NpcFlags = 0;
			Size = 1f;
			Speed = 7f;
			WalkSpeed = 7f;
			RunSpeed = 11f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			Elite = 2;
			SkinLoot = new Loot[] { new Loot( typeof( LightHide ), 7.3f )
									,new Loot( typeof( LightLeather ), 83.6f )
									,new Loot( typeof( RuinedLeatherScraps ), 23.6f )
										};
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.Dishu, 100f ) };
		}
	}
}

namespace Server.Creatures
{
	public class DurotarTiger : BaseCreature
	{
		public DurotarTiger() : base()
		{
			Name = "Durotar Tiger";
			Id = 3121;
			Model = 598;
			Level = RandomLevel(13,13);
			SetDamage(8f,11f);
			AttackSpeed = 1300;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.675f;
			CombatReach = 1.27f;
			Armor = (int)(Level*26.2);
			Block = Level;
			BaseHitPoints = 344;
			NpcFlags = 0;
			Size = 0.85f;
			Speed = 4f;
			WalkSpeed = 4f;
			RunSpeed = 6f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			SkinLoot = new Loot[] { new Loot( typeof( RuinedLeatherScraps ), 60f )
									,new Loot( typeof( LightLeather ), 40.9f )
										};
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.DurotarTiger, 100f ) };
		}
	}
}

namespace Server.Creatures
{
	public class Duskstalker : BaseCreature
	{
		public Duskstalker() : base()
		{
			Name = "Duskstalker";
			Id = 14430;
			Model = 11453;
			Level = RandomLevel(9,9);
			SetDamage(11f,26f);
			AttackSpeed = 1400;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.795f;
			CombatReach = 1.5f;
			Armor = (int)(Level*45.2);
			Block = Level*2;
			BaseHitPoints = 484;
			NpcFlags = 0;
			Size = 1.1f;
			Speed = 5.25f;
			WalkSpeed = 5.25f;
			RunSpeed = 8.4f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			Elite = 2;
			SkinLoot = new Loot[] { new Loot( typeof( LightLeather ), 50f )
									,new Loot( typeof( RuinedLeatherScraps ), 50f )
										};
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.Duskstalker, 100f ) };
		}
	}
}

namespace Server.Creatures
{
	public class Echeyakee : BaseCreature
	{
		public Echeyakee() : base()
		{
			Name = "Echeyakee";
			Id = 3475;
			Model = 1934;
			Level = RandomLevel(16,16);
			SetDamage(17f,22f);
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.914f;
			CombatReach = 1.07f;
			Armor = (int)(Level*26.2);
			Block = Level;
			BaseHitPoints = 664;
			NpcFlags = 0;
			Size = 1.15f;
			Speed = 5.15f;
			WalkSpeed = 5.15f;
			RunSpeed = 8.24f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			SkinLoot = new Loot[] { new Loot( typeof( LightHide ), 5.2f )
									,new Loot( typeof( LightLeather ), 108.3f )
									,new Loot( typeof( MediumHide ), 2.4f )
									,new Loot( typeof( MediumLeather ), 19.7f )
										};
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.Echeyakee, 100f ) };
		}
	}
}

namespace Server.Creatures
{
	public class ElderNightsaber : BaseCreature
	{
		public ElderNightsaber() : base()
		{
			Name = "Elder Nightsaber";
			Id = 2033;
			Model = 3030;
			Level = RandomLevel(8,9);
			SetDamage(8f,11f);
			AttackSpeed = 1400;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.795f;
			CombatReach = 1.5f;
			Armor = (int)(Level*26.2);
			Block = Level;
float step=1.045f; //%the HP goes up per extra level
if (Level==8)		
{
 BaseHitPoints = 344;
} 
else
{
for (int i=1; i<=(Level-8); i++)
 {
  step=step*step;
 }	
 BaseHitPoints = (int)(344*(float)step);
} 
			NpcFlags = 0;
			Size = 1.33f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			SkinLoot = new Loot[] { new Loot( typeof( LightLeather ), 40f )
									,new Loot( typeof( RuinedLeatherScraps ), 59.7f )
										};
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.ElderNightsaber, 100f ) };
		}
	}
}

namespace Server.Creatures
{
	public class FeralNightsaber : BaseCreature
	{
		public FeralNightsaber() : base()
		{
			Name = "Feral Nightsaber";
			Id = 2034;
			Model = 3030;
			Level = RandomLevel(10,11);
			SetDamage(10f,14f);
			AttackSpeed = 1500;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.795f;
			CombatReach = 1.5f;
			Armor = (int)(Level*26.2);
			Block = Level;
float step=1.045f; //%the HP goes up per extra level
if (Level==10)		
{
 BaseHitPoints = 424;
} 
else
{
for (int i=1; i<=(Level-10); i++)
 {
  step=step*step;
 }	
 BaseHitPoints = (int)(424*(float)step);
} 
			NpcFlags = 0;
			Size = 1f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			NpcType = 1;
			Flags1 = 010;
			SkinLoot = new Loot[] { new Loot( typeof( LightLeather ), 40f )
									,new Loot( typeof( RuinedLeatherScraps ), 59.7f )
										};
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.FeralNightsaber, 100f ) };
			LearnSpell(12166, SpellsTypes.Offensive);
		}
	}
}

namespace Server.Creatures
{
	public class MangyNightsaber : BaseCreature
	{
		public MangyNightsaber() : base()
		{
			Name = "Mangy Nightsaber";
			Id = 2032;
			Model = 11448;
			Level = RandomLevel(2,2);
			SetDamage(3f,4f);
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.561f;
			CombatReach = 1.06f;
			Armor = (int)(Level*26.2);
			Block = Level;
			BaseHitPoints = 104;
			NpcFlags = 0;
			Size = 0.7f;
			Speed = 4.5f;
			WalkSpeed = 4.5f;
			RunSpeed = 7f;
			Faction = Factions.Beast;
			AIEngine = new DefensiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.MangyNightsaber, 100f ) };
		}
	}
}

namespace Server.Creatures
{
	public class NightsaberStalker : BaseCreature
	{
		public NightsaberStalker() : base()
		{
			Name = "Nightsaber Stalker";
			Id = 2043;
			Model = 14318;
			Level = RandomLevel(7,8);
			SetDamage(7f,9f);
			AttackSpeed = 1400;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.675f;
			CombatReach = 1.27f;
			Armor = (int)(Level*26.2);
			Block = Level;
float step=1.045f; //%the HP goes up per extra level
if (Level==7)		
{
 BaseHitPoints = 304;
} 
else
{
for (int i=1; i<=(Level-7); i++)
 {
  step=step*step;
 }	
 BaseHitPoints = (int)(304*(float)step);
} 
			NpcFlags = 0;
			Size = 0.85f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			SkinLoot = new Loot[] { new Loot( typeof( RuinedLeatherScraps ), 59.7f )
									,new Loot( typeof( LightLeather ), 40f )
										};
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.NightsaberStalker, 100f ) };
		}
	}
}

namespace Server.Creatures
{
	public class Nightsaber : BaseCreature
	{
		public Nightsaber() : base()
		{
			Name = "Nightsaber";
			Id = 2042;
			Model = 6805;
			Level = RandomLevel(5,6);
			SetDamage(5f,6f);
			AttackSpeed = 1400;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.675f;
			CombatReach = 1.27f;
			Armor = (int)(Level*26.2);
			Block = Level;
float step=1.045f; //%the HP goes up per extra level
if (Level==5)		
{
 BaseHitPoints = 224;
} 
else
{
for (int i=1; i<=(Level-5); i++)
 {
  step=step*step;
 }	
 BaseHitPoints = (int)(224*(float)step);
} 
			NpcFlags = 0;
			Size = 0.85f;
			Speed = 4.6f;
			WalkSpeed = 4.6f;
			RunSpeed = 8f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			SkinLoot = new Loot[] { new Loot( typeof( RuinedLeatherScraps ), 59.7f )
									,new Loot( typeof( LightLeather ), 40f )
										};
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.Nightsaber, 100f ) };
		}
	}
}

namespace Server.Creatures
{
	public class YoungNightsaber : BaseCreature
	{
		public YoungNightsaber() : base()
		{
			Name = "Young Nightsaber";
			Id = 2031;
			Model = 11454;
			Level = RandomLevel(1,1);
			SetDamage(0f,1f);
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.556f;
			CombatReach = 1.05f;
			Armor = (int)(Level*26.2);
			Block = Level;
			BaseHitPoints = 64;
			NpcFlags = 0;
			Size = 0.7f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			Faction = Factions.Beast;
			AIEngine = new DefensiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.YoungNightsaber, 100f ) };
		}
	}
}

namespace Server.Creatures
{
	public class ElderShadowmawPanther : BaseCreature
	{
		public ElderShadowmawPanther() : base()
		{
			Name = "Elder Shadowmaw Panther";
			Id = 1713;
			Model = 11452;
			Level = RandomLevel(42,43);
			SetDamage(43f,56f);
			AttackSpeed = 1500;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 1.03f;
			CombatReach = 1.95f;
			Armor = (int)(Level*26.2);
			Block = Level;
float step=1.045f; //%the HP goes up per extra level
if (Level==42)		
{
 BaseHitPoints = 1625;
} 
else
{
for (int i=1; i<=(Level-42); i++)
 {
  step=step*step;
 }	
 BaseHitPoints = (int)(1625*(float)step);
} 
			NpcFlags = 0;
			Size = 1.3f;
			Speed = 6f;
			WalkSpeed = 6f;
			RunSpeed = 9.6f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			SkinLoot = new Loot[] { new Loot( typeof( HeavyHide ), 2.3f )
									,new Loot( typeof( HeavyLeather ), 74.4f )
									,new Loot( typeof( ShadowcatHide ), 8.7f )
									,new Loot( typeof( ThickLeather ), 20.8f )
										};
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.ElderShadowmawPanther, 100f ) };
			Visible = InvisibilityLevel.Lesser;
		}
	}
}

namespace Server.Creatures
{
	public class EnragedPanther : BaseCreature
	{
		public EnragedPanther() : base()
		{
			Name = "Enraged Panther";
			Id = 10992;
			Model = 1095;
			Level = RandomLevel(30,30);
			SetDamage(32f,42f);
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 1.59f;
			CombatReach = 1.95f;
			Armor = (int)(Level * 42.2);
			Block = (int)(Level* 2.2);
			BaseHitPoints = 1224;
			NpcFlags = 0;
			Size = 2f;
			Speed = 8.5f;
			WalkSpeed = 8.5f;
			RunSpeed = 13.5f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 020;
			Elite = 1;
			SkinLoot = new Loot[] { new Loot( typeof( HeavyHide ), 3.9f )
									,new Loot( typeof( HeavyLeather ), 48.4f )
									,new Loot( typeof( MediumHide ), 3.4f )
									,new Loot( typeof( MediumLeather ), 47.3f )
										};
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.EnragedPanther, 100f ) };
		}
	}
}

namespace Server.Creatures
{
	public class KurzenWarPanther : BaseCreature
	{
		public KurzenWarPanther() : base()
		{
			Name = "Kurzen War Panther";
			Id = 977;
			Model = 599;
			Level = RandomLevel(32,33);
			SetDamage(35f,45f);
			AttackSpeed = 1300;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.795f;
			CombatReach = 1.5f;
			Armor = (int)(Level*26.2);
			Block = Level;
float step=1.045f; //%the HP goes up per extra level
if (Level==32)		
{
 BaseHitPoints = 1304;
} 
else
{
for (int i=1; i<=(Level-32); i++)
 {
  step=step*step;
 }	
 BaseHitPoints = (int)(1304*(float)step);
} 
			NpcFlags = 0;
			Size = 1f;
			Speed = 5.8f;
			WalkSpeed = 5.8f;
			RunSpeed = 9.2f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			SkinLoot = new Loot[] { new Loot( typeof( HeavyHide ), 3.9f )
									,new Loot( typeof( HeavyLeather ), 48.4f )
									,new Loot( typeof( MediumHide ), 3.4f )
									,new Loot( typeof( MediumLeather ), 47.3f )
										};
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.KurzenWarPanther, 100f ) };
		}
	}
}

namespace Server.Creatures
{
	public class Panther : BaseCreature
	{
		public Panther() : base()
		{
			Name = "Panther";
			Id = 736;
			Model = 599;
			Level = RandomLevel(32,33);
			SetDamage(36f,46f);
			AttackSpeed = 1300;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.795f;
			CombatReach = 1.5f;
			Armor = (int)(Level*26.2);
			Block = Level;
float step=1.045f; //%the HP goes up per extra level
if (Level==32)		
{
 BaseHitPoints = 1344;
} 
else
{
for (int i=1; i<=(Level-32); i++)
 {
  step=step*step;
 }	
 BaseHitPoints = (int)(1344*(float)step);
} 
			NpcFlags = 0;
			Size = 1f;
			Speed = 5.8f;
			WalkSpeed = 5.8f;
			RunSpeed = 9.2f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			SkinLoot = new Loot[] { new Loot( typeof( HeavyHide ), 3.9f )
									,new Loot( typeof( MediumHide ), 3.4f )
									,new Loot( typeof( MediumLeather ), 47.3f )
									,new Loot( typeof( HeavyLeather ), 58.9f )
										};
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.Panther, 100f ) };
		}
	}
}

namespace Server.Creatures
{
	public class ShadowPanther : BaseCreature
	{
		public ShadowPanther() : base()
		{
			Name = "Shadow Panther";
			Id = 768;
			Model = 633;
			Level = RandomLevel(39,40);
			SetDamage(42f,55f);
			AttackSpeed = 1600;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.914f;
			CombatReach = 1.07f;
			Armor = (int)(Level*26.2);
			Block = Level;
float step=1.045f; //%the HP goes up per extra level
if (Level==39)		
{
 BaseHitPoints = 1585;
} 
else
{
for (int i=1; i<=(Level-39); i++)
 {
  step=step*step;
 }	
 BaseHitPoints = (int)(1585*(float)step);
} 
			NpcFlags = 0;
			Size = 1.15f;
			Speed = 6f;
			WalkSpeed = 6f;
			RunSpeed = 9.8f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			SkinLoot = new Loot[] { new Loot( typeof( HeavyHide ), 3.9f )
									,new Loot( typeof( HeavyLeather ), 67.5f )
									,new Loot( typeof( ShadowcatHide ), 9.6f )
									,new Loot( typeof( ThickLeather ), 23.3f )
										};
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.ShadowPanther, 100f ) };
		}
	}
}

namespace Server.Creatures
{
	public class ShadowmawPanther : BaseCreature
	{
		public ShadowmawPanther() : base()
		{
			Name = "Shadowmaw Panther";
			Id = 684;
			Model = 633;
			Level = RandomLevel(37,38);
			SetDamage(38f,49f);
			AttackSpeed = 1500;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.914f;
			CombatReach = 1.07f;
			Armor = (int)(Level*26.2);
			Block = Level;
float step=1.045f; //%the HP goes up per extra level
if (Level==37)		
{
 BaseHitPoints = 1424;
} 
else
{
for (int i=1; i<=(Level-37); i++)
 {
  step=step*step;
 }	
 BaseHitPoints = (int)(1424*(float)step);
} 
			NpcFlags = 0;
			Size = 1.15f;
			Speed = 6f;
			WalkSpeed = 6f;
			RunSpeed = 9.4f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			SkinLoot = new Loot[] { new Loot( typeof( ThickLeather ), 23.3f )
									,new Loot( typeof( ShadowcatHide ), 11.5f )
									,new Loot( typeof( HeavyHide ), 3.2f )
									,new Loot( typeof( HeavyLeather ), 72.3f )
										};
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.ShadowmawPanther, 100f ) };
			Visible = InvisibilityLevel.Lesser;
		}
	}
}

namespace Server.Creatures
{
	public class SkullsplitterPanther : BaseCreature
	{
		public SkullsplitterPanther() : base()
		{
			Name = "Skullsplitter Panther";
			Id = 756;
			Model = 633;
			Level = RandomLevel(41,42);
			SetDamage(44f,58f);
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.914f;
			CombatReach = 1.07f;
			Armor = (int)(Level*26.2);
			Block = Level;
float step=1.045f; //%the HP goes up per extra level
if (Level==41)		
{
 BaseHitPoints = 1665;
} 
else
{
for (int i=1; i<=(Level-41); i++)
 {
  step=step*step;
 }	
 BaseHitPoints = (int)(1665*(float)step);
} 
			NpcFlags = 0;
			Size = 1.15f;
			Speed = 6f;
			WalkSpeed = 6f;
			RunSpeed = 9.8f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.SkullsplitterPanther, 100f ) };
		}
	}
}

namespace Server.Creatures
{
	public class YoungPanther : BaseCreature
	{
		public YoungPanther() : base()
		{
			Name = "Young Panther";
			Id = 683;
			Model = 2437;
			Level = RandomLevel(30,31);
			SetDamage(31f,41f);
			AttackSpeed = 1300;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.718f;
			CombatReach = 1.35f;
			Armor = (int)(Level*26.2);
			Block = Level;
float step=1.045f; //%the HP goes up per extra level
if (Level==30)		
{
 BaseHitPoints = 1184;
} 
else
{
for (int i=1; i<=(Level-30); i++)
 {
  step=step*step;
 }	
 BaseHitPoints = (int)(1184*(float)step);
} 
			NpcFlags = 0;
			Size = 0.896f;
			Speed = 5.6f;
			WalkSpeed = 5.6f;
			RunSpeed = 9f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			SkinLoot = new Loot[] { new Loot( typeof( HeavyHide ), 2f )
									,new Loot( typeof( HeavyLeather ), 20.3f )
									,new Loot( typeof( MediumHide ), 5f )
									,new Loot( typeof( MediumLeather ), 80.2f )
										};
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.YoungPanther, 100f ) };
		}
	}
}

namespace Server.Creatures
{
	public class ElderStranglethornTiger : BaseCreature
	{
		public ElderStranglethornTiger() : base()
		{
			Name = "Elder Stranglethorn Tiger";
			Id = 1085;
			Model = 698;
			Level = RandomLevel(34,35);
			SetDamage(36f,46f);
			AttackSpeed = 1300;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.914f;
			CombatReach = 2.7f;
			Armor = (int)(Level*26.2);
			Block = Level;
float step=1.045f; //%the HP goes up per extra level
if (Level==34)		
{
 BaseHitPoints = 1084;
} 
else
{
for (int i=1; i<=(Level-34); i++)
 {
  step=step*step;
 }	
 BaseHitPoints = (int)(1084*(float)step);
} 
			NpcFlags = 0;
			Size = 1.15f;
			Speed = 5.8f;
			WalkSpeed = 5.8f;
			RunSpeed = 9.4f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			SkinLoot = new Loot[] { new Loot( typeof( HeavyHide ), 2f )
									,new Loot( typeof( MediumHide ), 5f )
									,new Loot( typeof( MediumLeather ), 48.1f )
									,new Loot( typeof( HeavyLeather ), 58.0f )
										};
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.ElderStranglethornTiger, 100f ) };
		}
	}
}

namespace Server.Creatures
{
	public class StranglethornTiger : BaseCreature
	{
		public StranglethornTiger() : base()
		{
			Name = "Stranglethorn Tiger";
			Id = 682;
			Model = 320;
			Level = RandomLevel(32,33);
			SetDamage(35f,45f);
			AttackSpeed = 1300;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.795f;
			CombatReach = 1.5f;
			Armor = (int)(Level*26.2);
			Block = Level;
float step=1.045f; //%the HP goes up per extra level
if (Level==32)		
{
 BaseHitPoints = 1304;
} 
else
{
for (int i=1; i<=(Level-32); i++)
 {
  step=step*step;
 }	
 BaseHitPoints = (int)(1304*(float)step);
} 
			NpcFlags = 0;
			Size = 1f;
			Speed = 5.8f;
			WalkSpeed = 5.8f;
			RunSpeed = 9.4f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			SkinLoot = new Loot[] { new Loot( typeof( HeavyHide ), 2f )
									,new Loot( typeof( MediumHide ), 5f )
									,new Loot( typeof( MediumLeather ), 48.1f )
									,new Loot( typeof( HeavyLeather ), 58.0f )
										};
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.StranglethornTiger, 100f ) };
		}
	}
}

namespace Server.Creatures
{
	public class StranglethornTigress : BaseCreature
	{
		public StranglethornTigress() : base()
		{
			Name = "Stranglethorn Tigress";
			Id = 772;
			Model = 614;
			Level = RandomLevel(37,38);
			SetDamage(38f,49f);
			AttackSpeed = 1300;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 1.03f;
			CombatReach = 1.95f;
			Armor = (int)(Level*26.2);
			Block = Level;
float step=1.045f; //%the HP goes up per extra level
if (Level==37)		
{
 BaseHitPoints = 1424;
} 
else
{
for (int i=1; i<=(Level-37); i++)
 {
  step=step*step;
 }	
 BaseHitPoints = (int)(1424*(float)step);
} 
			NpcFlags = 0;
			Size = 1f;
			Speed = 5.9f;
			WalkSpeed = 5.9f;
			RunSpeed = 9.4f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			SkinLoot = new Loot[] { new Loot( typeof( HeavyHide ), 2.8f )
									,new Loot( typeof( HeavyLeather ), 82.9f )
									,new Loot( typeof( ThickLeather ), 21.4f )
										};
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.StranglethornTigress, 100f ) };
		}
	}
}

namespace Server.Creatures
{
	public class YoungStranglethornTiger : BaseCreature
	{
		public YoungStranglethornTiger() : base()
		{
			Name = "Young Stranglethorn Tiger";
			Id = 681;
			Model = 598;
			Level = RandomLevel(30,31);
			SetDamage(32f,42f);
			AttackSpeed = 1300;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.713f;
			CombatReach = 1.34f;
			Armor = (int)(Level*26.2);
			Block = Level;
float step=1.045f; //%the HP goes up per extra level
if (Level==30)		
{
 BaseHitPoints = 1224;
} 
else
{
for (int i=1; i<=(Level-30); i++)
 {
  step=step*step;
 }	
 BaseHitPoints = (int)(1224*(float)step);
} 
			NpcFlags = 0;
			Size = 1f;
			Speed = 5.6f;
			WalkSpeed = 5.6f;
			RunSpeed = 9f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			SkinLoot = new Loot[] { new Loot( typeof( HeavyHide ), 2.8f )
									,new Loot( typeof( HeavyLeather ), 23.5f )
									,new Loot( typeof( MediumHide ), 5.1f )
									,new Loot( typeof( MediumLeather ), 85.4f )
										};
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.YoungStranglethornTiger, 100f ) };
		}
	}
}

namespace Server.Creatures
{
	public class FeralMountainLion : BaseCreature
	{
		public FeralMountainLion() : base()
		{
			Name = "Feral Mountain Lion";
			Id = 2385;
			Model = 1056;
			Level = RandomLevel(27,28);
			SetDamage(29f,38f);
			AttackSpeed = 1200;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.795f;
			CombatReach = 1.5f;
			Armor = (int)(Level*26.2);
			Block = Level;
float step=1.045f; //%the HP goes up per extra level
if (Level==27)		
{
 BaseHitPoints = 1104;
} 
else
{
for (int i=1; i<=(Level-27); i++)
 {
  step=step*step;
 }	
 BaseHitPoints = (int)(1104*(float)step);
} 
			NpcFlags = 0;
			Size = 1f;
			Speed = 5.6f;
			WalkSpeed = 5.6f;
			RunSpeed = 9f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			SkinLoot = new Loot[] { new Loot( typeof( HeavyHide ), 2f )
									,new Loot( typeof( HeavyLeather ), 18.6f )
									,new Loot( typeof( MediumHide ), 3.9f )
									,new Loot( typeof( MediumLeather ), 79.6f )
										};
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.FeralMountainLion, 100f ) };
		}
	}
}

namespace Server.Creatures
{
	public class HulkingMountainLion : BaseCreature
	{
		public HulkingMountainLion() : base()
		{
			Name = "Hulking Mountain Lion";
			Id = 2407;
			Model = 2300;
			Level = RandomLevel(33,34);
			SetDamage(36f,46f);
			AttackSpeed = 1400;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 1.03f;
			CombatReach = 1.95f;
			Armor = (int)(Level*26.2);
			Block = Level;
float step=1.045f; //%the HP goes up per extra level
if (Level==33)		
{
 BaseHitPoints = 1344;
} 
else
{
for (int i=1; i<=(Level-33); i++)
 {
  step=step*step;
 }	
 BaseHitPoints = (int)(1344*(float)step);
} 
			NpcFlags = 0;
			Size = 1.3f;
			Speed = 5.8f;
			WalkSpeed = 5.8f;
			RunSpeed = 9.2f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			SkinLoot = new Loot[] { new Loot( typeof( HeavyHide ), 2f )
									,new Loot( typeof( MediumHide ), 3.9f )
									,new Loot( typeof( HeavyLeather ), 52.6f )
									,new Loot( typeof( MediumLeather ), 44.8f )
										};
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.HulkingMountainLion, 100f ) };
		}
	}
}

namespace Server.Creatures
{
	public class MountainLion : BaseCreature
	{
		public MountainLion() : base()
		{
			Name = "Mountain Lion";
			Id = 2406;
			Model = 1058;
			Level = RandomLevel(32,33);
			SetDamage(35f,45f);
			AttackSpeed = 1400;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.914f;
			CombatReach = 1.07f;
			Armor = (int)(Level*26.2);
			Block = Level;
float step=1.045f; //%the HP goes up per extra level
if (Level==32)		
{
 BaseHitPoints = 1304;
} 
else
{
for (int i=1; i<=(Level-32); i++)
 {
  step=step*step;
 }	
 BaseHitPoints = (int)(1304*(float)step);
} 
			NpcFlags = 0;
			Size = 1.15f;
			Speed = 5.8f;
			WalkSpeed = 5.8f;
			RunSpeed = 9f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			SkinLoot = new Loot[] { new Loot( typeof( HeavyHide ), 3.2f )
									,new Loot( typeof( HeavyLeather ), 51.5f )
									,new Loot( typeof( MediumHide ), 4.4f )
									,new Loot( typeof( MediumLeather ), 47.1f )
										};
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.MountainLion, 100f ) };
		}
	}
}

namespace Server.Creatures
{
	public class MountainLionMother : BaseCreature
	{
		public MountainLionMother() : base()
		{
			Name = "Mountain Lion Mother";
			Id = 20001;
			Model = 1056;
			Level = RandomLevel(26,28);
			SetDamage(29f,38f);
			AttackSpeed = 1700;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 1f;
			CombatReach = 1.5f;
			Armor = (int)(Level*26.2);
			Block = Level;
float step=1.045f; //%the HP goes up per extra level
if (Level==26)		
{
 BaseHitPoints = 1104;
} 
else
{
for (int i=1; i<=(Level-26); i++)
 {
  step=step*step;
 }	
 BaseHitPoints = (int)(1104*(float)step);
} 
			NpcFlags = 0;
			Size = 1.15f;
			Speed = 5.5f;
			WalkSpeed = 5.5f;
			RunSpeed = 9f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.MountainLionMother, 100f ) };
		}
	}
}

namespace Server.Creatures
{
	public class MountainCougar : BaseCreature
	{
		public MountainCougar() : base()
		{
			Name = "Mountain Cougar";
			Id = 2961;
			Model = 11451;
			Level = RandomLevel(3,3);
			SetDamage(3f,4f);
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.567f;
			CombatReach = 1.07f;
			Armor = (int)(Level*26.2);
			Block = Level;
			BaseHitPoints = 144;
			NpcFlags = 0;
			Size = 0.713f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			Faction = Factions.Beast;
			AIEngine = new DefensiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.MountainCougar, 100f ) };
		}
	}
}

namespace Server.Creatures
{
	public class StarvingMountainLion : BaseCreature
	{
		public StarvingMountainLion() : base()
		{
			Name = "Starving Mountain Lion";
			Id = 2384;
			Model = 1059;
			Level = RandomLevel(23,24);
			SetDamage(21f,28f);
			AttackSpeed = 1200;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.675f;
			CombatReach = 1.27f;
			Armor = (int)(Level*26.2);
			Block = Level;
float step=1.045f; //%the HP goes up per extra level
if (Level==23)		
{
 BaseHitPoints = 824;
} 
else
{
for (int i=1; i<=(Level-23); i++)
 {
  step=step*step;
 }	
 BaseHitPoints = (int)(824*(float)step);
} 
			NpcFlags = 0;
			Size = 0.713f;
			Speed = 5.3f;
			WalkSpeed = 5.3f;
			RunSpeed = 8.5f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			SkinLoot = new Loot[] { new Loot( typeof( LightHide ), 3f )
									,new Loot( typeof( LightLeather ), 68.2f )
									,new Loot( typeof( MediumHide ), 5f )
									,new Loot( typeof( MediumLeather ), 52.3f )
										};
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.StarvingMountainLion, 100f ) };
		}
	}
}

namespace Server.Creatures
{
	public class FlatlandCougar : BaseCreature
	{
		public FlatlandCougar() : base()
		{
			Name = "Flatland Cougar";
			Id = 3035;
			Model = 1059;
			Level = RandomLevel(7,8);
			SetDamage(8f,11f);
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.675f;
			CombatReach = 1.27f;
			Armor = (int)(Level*26.2);
			Block = Level;
float step=1.045f; //%the HP goes up per extra level
if (Level==7)		
{
 BaseHitPoints = 344;
} 
else
{
for (int i=1; i<=(Level-7); i++)
 {
  step=step*step;
 }	
 BaseHitPoints = (int)(344*(float)step);
} 
			NpcFlags = 0;
			Size = 0.85f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			SkinLoot = new Loot[] { new Loot( typeof( LightLeather ), 40.1f )
									,new Loot( typeof( RuinedLeatherScraps ), 59.4f )
										};
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.FlatlandCougar, 100f ) };
		}
	}
}

namespace Server.Creatures
{
	public class FlatlandProwler : BaseCreature
	{
		public FlatlandProwler() : base()
		{
			Name = "Flatland Prowler";
			Id = 3566;
			Model = 1056;
			Level = RandomLevel(9,9);
			SetDamage(8f,11f);
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.795f;
			CombatReach = 1.5f;
			Armor = (int)(Level*26.2);
			Block = Level;
			BaseHitPoints = 344;
			NpcFlags = 0;
			Size = 1f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			SkinLoot = new Loot[] { new Loot( typeof( LightLeather ), 40.1f )
									,new Loot( typeof( RuinedLeatherScraps ), 59.4f )
										};
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.FlatlandProwler, 100f ) };
		}
	}
}

namespace Server.Creatures
{
	public class Frostsaber : BaseCreature
	{
		public Frostsaber() : base()
		{
			Name = "Frostsaber";
			Id = 7431;
			Model = 9953;
			Level = RandomLevel(56,57);
			SetDamage(61f,79f);
			AttackSpeed = 1500;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 1.03f;
			CombatReach = 1.95f;
			Armor = (int)(Level*26.2);
			Block = Level;
float step=1.045f; //%the HP goes up per extra level
if (Level==56)		
{
 BaseHitPoints = 2266;
} 
else
{
for (int i=1; i<=(Level-56); i++)
 {
  step=step*step;
 }	
 BaseHitPoints = (int)(2266*(float)step);
} 
			NpcFlags = 0;
			Size = 1.3f;
			Speed = 6.5f;
			WalkSpeed = 6.5f;
			RunSpeed = 10.8f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			SkinLoot = new Loot[] { new Loot( typeof( FrostsaberLeather ), 28.9f )
									,new Loot( typeof( RuggedHide ), 43f )
									,new Loot( typeof( RuggedLeather ), 51.2f )
									,new Loot( typeof( ThickLeather ), 83.5f )
										};
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.Frostsaber, 100f ) };
		}
	}
}

namespace Server.Creatures
{
	public class FrostsaberCub : BaseCreature
	{
		public FrostsaberCub() : base()
		{
			Name = "Frostsaber Cub";
			Id = 7430;
			Model = 9958;
			Level = RandomLevel(55,56);
			SetDamage(60f,77f);
			AttackSpeed = 1500;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.853f;
			CombatReach = 1.7f;
			Armor = (int)(Level*26.2);
			Block = Level;
float step=1.045f; //%the HP goes up per extra level
if (Level==55)		
{
 BaseHitPoints = 2226;
} 
else
{
for (int i=1; i<=(Level-55); i++)
 {
  step=step*step;
 }	
 BaseHitPoints = (int)(2226*(float)step);
} 
			NpcFlags = 0;
			Size = 1.07f;
			Speed = 6.5f;
			WalkSpeed = 6.5f;
			RunSpeed = 10.8f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			SkinLoot = new Loot[] { new Loot( typeof( FrostsaberLeather ), 183.5f )
									,new Loot( typeof( RuggedHide ), 38.1f )
									,new Loot( typeof( RuggedLeather ), 369.5f )
									,new Loot( typeof( ThickHide ), 32.2f )
									,new Loot( typeof( ThickLeather ), 29.7f )
										};
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.FrostsaberCub, 100f ) };
		}
	}
}

namespace Server.Creatures
{
	public class FrostsaberHuntress : BaseCreature
	{
		public FrostsaberHuntress() : base()
		{
			Name = "Frostsaber Huntress";
			Id = 7433;
			Model = 11444;
			Level = RandomLevel(58,59);
			SetDamage(63f,82f);
			AttackSpeed = 1500;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 50;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 1.03f;
			CombatReach = 1.95f;
Armor = (int)(Level*26.2);
			Block = Level;
float step=1.045f; //%the HP goes up per extra level
if (Level==58)		
{
 BaseHitPoints = 2346;
} 
else
{
for (int i=1; i<=(Level-58); i++)
 {
  step=step*step;
 }	
 BaseHitPoints = (int)(2346*(float)step);
} 
			NpcFlags = 0;
			Size = 1.3f;
			Speed = 6.5f;
			WalkSpeed = 6.5f;
			RunSpeed = 10.8f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			SkinLoot = new Loot[] { new Loot( typeof( FrostsaberLeather ), 37.3f )
									,new Loot( typeof( RuggedHide ), 5.7f )
									,new Loot( typeof( RuggedLeather ), 47.4f )
									,new Loot( typeof( ThickLeather ), 62.4f )
										};
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.FrostsaberHuntress, 100f ) };
		}
	}
}

namespace Server.Creatures
{
	public class FrostsaberStalker : BaseCreature
	{
		public FrostsaberStalker() : base()
		{
			Name = "Frostsaber Stalker";
			Id = 7432;
			Model = 11445;
			Level = RandomLevel(59,60);
			SetDamage(64f,83f);
			AttackSpeed = 1500;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 50;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 1.19f;
			CombatReach = 2.25f;
			Armor = (int)(Level*26.2);
			Block = Level;
float step=1.045f; //%the HP goes up per extra level
if (Level==59)		
{
 BaseHitPoints = 2386;
} 
else
{
for (int i=1; i<=(Level-59); i++)
 {
  step=step*step;
 }	
 BaseHitPoints = (int)(2386*(float)step);
} 
			NpcFlags = 0;
			Size = 1.5f;
			Speed = 6.8f;
			WalkSpeed = 6.8f;
			RunSpeed = 10.9f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			SkinLoot = new Loot[] { new Loot( typeof( FrostsaberLeather ), 37.3f )
									,new Loot( typeof( RuggedHide ), 5.7f )
									,new Loot( typeof( RuggedLeather ), 47.4f )
									,new Loot( typeof( ThickLeather ), 10.1f )
										};
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.FrostsaberStalker, 100f ) };
		}
	}
}

namespace Server.Creatures
{
	public class FrostsaberPrideWatcher : BaseCreature
	{
		public FrostsaberPrideWatcher() : base()
		{
			Name = "Frostsaber Pride Watcher";
			Id = 7434;
			Model = 9954;
			Level = RandomLevel(59,60);
			SetDamage(64f,83f);
			AttackSpeed = 1500;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 50;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.383f;
			CombatReach = 1.63f;
Armor = (int)(Level*26.2);
			Block = Level;
float step=1.045f; //%the HP goes up per extra level
if (Level==59)		
{
 BaseHitPoints = 2386;
} 
else
{
for (int i=1; i<=(Level-59); i++)
 {
  step=step*step;
 }	
 BaseHitPoints = (int)(2386*(float)step);
} 
			NpcFlags = 0;
			Size = 1.3f;
			Speed = 6.8f;
			WalkSpeed = 6.8f;
			RunSpeed = 10.9f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			SkinLoot = new Loot[] { new Loot( typeof( FrostsaberLeather ), 37.3f )
									,new Loot( typeof( RuggedHide ), 5.7f )
									,new Loot( typeof( RuggedLeather ), 47.4f )
									,new Loot( typeof( ThickLeather ), 10.1f )
										};
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.FrostsaberPrideWatcher, 100f ) };
		}
	}
}

namespace Server.Creatures
{
	public class HumarThePridelord : BaseCreature
	{
		public HumarThePridelord() : base()
		{
			Name = "Humar the Pridelord";
			Id = 5828;
			Model = 4424;
			Level = RandomLevel(23,23);
			SetDamage(25f,32f);
			AttackSpeed = 1300;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.68f;
			CombatReach = 1.28f;
			Armor = (int)(Level*4.5);
			Block = (int)(Level*2.2);
			BaseHitPoints = 2832;
			NpcFlags = 0;
			Size = 0.856f;
			Speed = 9f;
			WalkSpeed = 9f;
			RunSpeed = 14f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			Elite = 1;
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.HumarThePridelord, 100f ) };
		}
	}
}

namespace Server.Creatures
{
	public class JagueroStalker : BaseCreature
	{
		public JagueroStalker() : base()
		{
			Name = "Jaguero Stalker";
			Id = 2522;
			Model = 1095;
			Level = RandomLevel(50,50);
			SetDamage(52f,67f);
			AttackSpeed = 1400;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 1f;
			CombatReach = 1.5f;
			Armor = (int)(Level*26.2);
			Block = Level;
			BaseHitPoints = 1945;
			NpcFlags = 0;
			Size = 1f;
			Speed = 6.5f;
			WalkSpeed = 6.5f;
			RunSpeed = 10.3f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			SkinLoot = new Loot[] { new Loot( typeof( RuggedLeather ), 19.4f )
									,new Loot( typeof( ThickHide ), 3.4f )
									,new Loot( typeof( ThickLeather ), 77.1f )
										};
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.JagueroStalker, 100f ) };
		}
	}
}

namespace Server.Creatures
{
	public class JuvenileSnowLeopard : BaseCreature
	{
		public JuvenileSnowLeopard() : base()
		{
			Name = "Juvenile Snow Leopard";
			Id = 1199;
			Model = 748;
			Level = RandomLevel(5,6);
			SetDamage(5f,6f);
			AttackSpeed = 1500;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 10;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.578f;
			CombatReach = 1.09f;
			Armor = (int)(Level*26.2);
			Block = Level;
float step=1.045f; //%the HP goes up per extra level
if (Level==5)		
{
 BaseHitPoints = 224;
} 
else
{
for (int i=1; i<=(Level-5); i++)
 {
  step=step*step;
 }	
 BaseHitPoints = (int)(224*(float)step);
} 
			NpcFlags = 0;
			Size = 0.727f;
			Speed = 2.8f;
			WalkSpeed = 2.8f;
			RunSpeed = 4.5f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			SkinLoot = new Loot[] { new Loot( typeof( LightLeather ), 40.7f )
									,new Loot( typeof( RuinedLeatherScraps ), 59.6f )
										};
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.JuvenileSnowLeopard, 100f ) };
		}
	}
}

namespace Server.Creatures
{
	public class SnowLeopard : BaseCreature
	{
		public SnowLeopard() : base()
		{
			Name = "Snow Leopard";
			Id = 1201;
			Model = 954;
			Level = RandomLevel(7,8);
			SetDamage(7f,9f);
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 10;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.675f;
			CombatReach = 1.27f;
			Armor = (int)(Level*26.2);
			Block = Level;
float step=1.045f; //%the HP goes up per extra level
if (Level==7)		
{
 BaseHitPoints = 304;
} 
else
{
for (int i=1; i<=(Level-7); i++)
 {
  step=step*step;
 }	
 BaseHitPoints = (int)(304*(float)step);
} 
			NpcFlags = 0;
			Size = 0.85f;
			Speed = 3.3f;
			WalkSpeed = 3.3f;
			RunSpeed = 5.3f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			SkinLoot = new Loot[] { new Loot( typeof( LightLeather ), 40f )
									,new Loot( typeof( RuinedLeatherScraps ), 60f )
										};
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.SnowLeopard, 100f ) };
		}
	}
}

namespace Server.Creatures
{
	public class KingBangalash : BaseCreature
	{
		public KingBangalash() : base()
		{
			Name = "King Bangalash";
			Id = 731;
			Model = 616;
			Level = RandomLevel(43,43);
			SetDamage(43f,56f);
			AttackSpeed = 1400;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 1.19f;
			CombatReach = 2.25f;
			Armor = (int)(Level*42.2);
			Block = (int)(Level*2.2);
			BaseHitPoints = 1625;
			NpcFlags = 0;
			Size = 1.5f;
			Speed = 9f;
			WalkSpeed = 9f;
			RunSpeed = 14.5f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			Elite = 1;
			SkinLoot = new Loot[] { new Loot( typeof( RuggedLeather ), 21.9f )
									,new Loot( typeof( ThickHide ), 2.7f )
									,new Loot( typeof( ThickLeather ), 79.9f )
										};
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.KingBangalash, 100f ) };
		}
	}
}

namespace Server.Creatures
{
	public class Moonstalker : BaseCreature
	{
		public Moonstalker() : base()
		{
			Name = "Moonstalker";
			Id = 2069;
			Model = 321;
			Level = RandomLevel(14,15);
			SetDamage(14f,18f);
			AttackSpeed = 1300;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.795f;
			CombatReach = 1.5f;
			Armor = (int)(Level*26.2);
			Block = Level;
float step=1.045f; //%the HP goes up per extra level
if (Level==14)		
{
 BaseHitPoints = 544;
} 
else
{
for (int i=1; i<=(Level-14); i++)
 {
  step=step*step;
 }	
 BaseHitPoints = (int)(544*(float)step);
} 
			NpcFlags = 0;
			Size = 1f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			SkinLoot = new Loot[] { new Loot( typeof( LightHide ), 4.9f )
									,new Loot( typeof( LightLeather ), 74.9f )
									,new Loot( typeof( RuinedLeatherScraps ), 34.7f )
										};
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.Moonstalker, 100f ) };
		}
	}
}

namespace Server.Creatures
{
	public class MoonstalkerMatriarch : BaseCreature
	{
		public MoonstalkerMatriarch() : base()
		{
			Name = "Moonstalker Matriarch";
			Id = 2071;
			Model = 3031;
			Level = RandomLevel(19,20);
			SetDamage(20f,26f);
			AttackSpeed = 1300;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.914f;
			CombatReach = 1.07f;
			Armor = (int)(Level*26.2);
			Block = Level;
float step=1.045f; //%the HP goes up per extra level
if (Level==19)		
{
 BaseHitPoints = 784;
} 
else
{
for (int i=1; i<=(Level-19); i++)
 {
  step=step*step;
 }	
 BaseHitPoints = (int)(784*(float)step);
} 
			NpcFlags = 0;
			Size = 1.15f;
			Speed = 7.5f;
			WalkSpeed = 7.5f;
			RunSpeed = 12f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			SkinLoot = new Loot[] { new Loot( typeof( LightHide ), 4.8f )
									,new Loot( typeof( LightLeather ), 109.5f )
									,new Loot( typeof( MediumHide ), 2.4f )
									,new Loot( typeof( MediumLeather ), 20.1f )
										};
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.MoonstalkerMatriarch, 100f ) };
		}
	}
}

namespace Server.Creatures
{
	public class MoonstalkerRunt : BaseCreature
	{
		public MoonstalkerRunt() : base()
		{
			Name = "Moonstalker Runt";
			Id = 2070;
			Model = 11449;
			Level = RandomLevel(10,11);
			SetDamage(11f,15f);
			AttackSpeed = 1300;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.675f;
			CombatReach = 1.27f;
			Armor = (int)(Level*26.2);
			Block = Level;
float step=1.045f; //%the HP goes up per extra level
if (Level==10)		
{
 BaseHitPoints = 504;
} 
else
{
for (int i=1; i<=(Level-10); i++)
 {
  step=step*step;
 }	
 BaseHitPoints = (int)(504*(float)step);
} 
			NpcFlags = 0;
			Size = 0.85f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			SkinLoot = new Loot[] { new Loot( typeof( LightLeather ), 39.2f )
							,new Loot( typeof( RuinedLeatherScraps ), 60.2f )
										};
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.MoonstalkerRunt, 100f ) };
		}
	}
}

namespace Server.Creatures
{
	public class MoonstalkerSire : BaseCreature
	{
		public MoonstalkerSire() : base()
		{
			Name = "Moonstalker Sire";
			Id = 2237;
			Model = 11450;
			Level = RandomLevel(17,18);
			SetDamage(17f,22f);
			AttackSpeed = 1300;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.914f;
			CombatReach = 1.07f;
			Armor = (int)(Level*26.2);
			Block = Level;
float step=1.045f; //%the HP goes up per extra level
if (Level==17)		
{
 BaseHitPoints = 664;
} 
else
{
for (int i=1; i<=(Level-17); i++)
 {
  step=step*step;
 }	
 BaseHitPoints = (int)(664*(float)step);
} 
			NpcFlags = 0;
			Size = 1.15f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			SkinLoot = new Loot[] { new Loot( typeof( LightHide ), 5f )
									,new Loot( typeof( LightLeather ), 111.9f )
									,new Loot( typeof( MediumHide ), 1.9f )
									,new Loot( typeof( MediumLeather ), 19.0f )
										};
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.MoonstalkerSire, 100f ) };
		}
	}
}

namespace Server.Creatures
{
	public class NeedlesCougar : BaseCreature
	{
		public NeedlesCougar() : base()
		{
			Name = "Needles Cougar";
			Id = 4124;
			Model = 1056;
			Level = RandomLevel(27,28);
			SetDamage(28f,36f);
			AttackSpeed = 1200;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.795f;
			CombatReach = 1.5f;
			Armor = (int)(Level*26.2);
			Block = Level;
float step=1.045f; //%the HP goes up per extra level
if (Level==27)		
{
 BaseHitPoints = 1064;
} 
else
{
for (int i=1; i<=(Level-27); i++)
 {
  step=step*step;
 }	
 BaseHitPoints = (int)(1064*(float)step);
} 
			NpcFlags = 0;
			Size = 1f;
			Speed = 5.5f;
			WalkSpeed = 5.5f;
			RunSpeed = 8.8f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			SkinLoot = new Loot[] { new Loot( typeof( HeavyHide ), 2.2f )
									,new Loot( typeof( HeavyLeather ), 20.8f )
									,new Loot( typeof( MediumHide ), 5.3f )
									,new Loot( typeof( MediumLeather ), 79.5f )
										};
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.NeedlesCougar, 100f ) };
		}
	}
}

namespace Server.Creatures
{
	public class Rakshiri : BaseCreature
	{
		public Rakshiri() : base()
		{
			Name = "Rak'shiri";
			Id = 10200;
			Model = 10054;
			Level = RandomLevel(57,57);
			SetDamage(62f,80f);
			AttackSpeed = 1500;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.385f;
			CombatReach = 1.65f;
			Armor = (int)(Level*26.2);
			Block = Level;
			BaseHitPoints = 2306;
			NpcFlags = 0;
			Size = 1f;
			Speed = 6f;
			WalkSpeed = 6f;
			RunSpeed = 10f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			Elite = 2;
			SkinLoot = new Loot[] { new Loot( typeof( RuggedLeather ), 82.2f )
									,new Loot( typeof( ThickLeather ), 13.7f )
										};
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.Rakshiri, 100f ) };
		}
	}
}

namespace Server.Creatures
{
	public class RidgeHuntress : BaseCreature
	{
		public RidgeHuntress() : base()
		{
			Name = "Ridge Huntress";
			Id = 2732;
			Model = 1055;
			Level = RandomLevel(38,39);
			BaseHitPoints = 1545;
			SetDamage(41f,53f);
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 1.03f;
			CombatReach = 1.95f;
			Armor = (int)(Level*26.2);
			Block = Level;
float step=1.045f; //%the HP goes up per extra level
if (Level==38)		
{
 BaseHitPoints = 1545;
} 
else
{
for (int i=1; i<=(Level-38); i++)
 {
  step=step*step;
 }	
 BaseHitPoints = (int)(1545*(float)step);
} 
			NpcFlags = 0;
			Size = 1.3f;
			Speed = 6f;
			WalkSpeed = 6f;
			RunSpeed = 10f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			SkinLoot = new Loot[] { new Loot( typeof( HeavyHide ), 2.5f )
									,new Loot( typeof( HeavyLeather ), 85.8f )
									,new Loot( typeof( ThickLeather ), 22.4f )
										};
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.RidgeHuntress, 100f ) };
		}
	}
}

namespace Server.Creatures
{
	public class RidgeStalker : BaseCreature
	{
		public RidgeStalker() : base()
		{
			Name = "Ridge Stalker";
			Id = 2731;
			Model = 632;
			Level = RandomLevel(36,37);
			SetDamage(37f,48f);
			AttackSpeed = 1300;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.914f;
			CombatReach = 1.07f;
			Armor = (int)(Level*26.2);
			Block = Level;
float step=1.045f; //%the HP goes up per extra level
if (Level==36)		
{
 BaseHitPoints = 1384;
} 
else
{
for (int i=1; i<=(Level-36); i++)
 {
  step=step*step;
 }	
 BaseHitPoints = (int)(1384*(float)step);
} 
			NpcFlags = 0;
			Size = 1.15f;
			Speed = 6f;
			WalkSpeed = 6f;
			RunSpeed = 9.5f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			SkinLoot = new Loot[] { new Loot( typeof( HeavyHide ), 3.5f )
									,new Loot( typeof( HeavyLeather ), 82.4f )
									,new Loot( typeof( ThickLeather ), 20.6f )
										};
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.RidgeStalker, 100f ) };
			Visible = InvisibilityLevel.Lesser;
		}
	}
}

namespace Server.Creatures
{
	public class RidgeStalkerPatriarch : BaseCreature
	{
		public RidgeStalkerPatriarch() : base()
		{
			Name = "Ridge Stalker Patriarch";
			Id = 2734;
			Model = 917;
			Level = RandomLevel(40,41);
			SetDamage(42f,55f);
			AttackSpeed = 1300;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 1.19f;
			CombatReach = 2.25f;
			Armor = (int)(Level*26.2);
			Block = Level;
float step=1.045f; //%the HP goes up per extra level
if (Level==40)		
{
 BaseHitPoints = 1585;
} 
else
{
for (int i=1; i<=(Level-40); i++)
 {
  step=step*step;
 }	
 BaseHitPoints = (int)(1585*(float)step);
} 
			NpcFlags = 0;
			Size = 1.5f;
			Speed = 6.2f;
			WalkSpeed = 6.2f;
			RunSpeed = 9.5f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			SkinLoot = new Loot[] { new Loot( typeof( HeavyHide ), 3.5f )
									,new Loot( typeof( HeavyLeather ), 44.5f )
									,new Loot( typeof( ThickHide ), 3.4f )
									,new Loot( typeof( ThickLeather ), 52.8f )
										};
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.RidgeStalkerPatriarch, 100f ) };
			Visible = InvisibilityLevel.Lesser;
		}
	}
}

namespace Server.Creatures
{
	public class SavannahCub : BaseCreature
	{
		public SavannahCub() : base()
		{
			Name = "Savannah Cub";
			Id = 5766;
			Model = 2278;
			Level = RandomLevel(9,9);
			SetDamage(6f,8f);
			AttackSpeed = 1200;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.57f;
			CombatReach = 1.08f;
			Armor = (int)(Level*26.2);
			Block = Level;
			BaseHitPoints = 264;
			NpcFlags = 0;
			Size = 0.75f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.SavannahCub, 100f ) };
		}
	}
}

namespace Server.Creatures
{
	public class SavannahHighmane : BaseCreature
	{
		public SavannahHighmane() : base()
		{
			Name = "Savannah Highmane";
			Id = 3243;
			Model = 1973;
			Level = RandomLevel(12,13);
			SetDamage(13f,16f);
			AttackSpeed = 1500;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.795f;
			CombatReach = 1.5f;
			Armor = (int)(Level*26.2);
			Block = Level;
float step=1.045f; //%the HP goes up per extra level
if (Level==12)		
{
 BaseHitPoints = 504;
} 
else
{
for (int i=1; i<=(Level-12); i++)
 {
  step=step*step;
 }	
 BaseHitPoints = (int)(504*(float)step);
} 
			NpcFlags = 0;
			Size = 1f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			SkinLoot = new Loot[] { new Loot( typeof( LightHide ), 4.4f )
									,new Loot( typeof( LightLeather ), 74.4f )
									,new Loot( typeof( RuinedLeatherScraps ), 38.1f )
										};
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.SavannahHighmane, 100f ) };
		}
	}
}

namespace Server.Creatures
{
	public class SavannahHuntress : BaseCreature
	{
		public SavannahHuntress() : base()
		{
			Name = "Savannah Huntress";
			Id = 3415;
			Model = 1056;
			Level = RandomLevel(11,12);
			SetDamage(9f,12f);
			AttackSpeed = 1500;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.795f;
			CombatReach = 1.5f;
			Armor = (int)(Level*26.2);
			Block = Level;
float step=1.045f; //%the HP goes up per extra level
if (Level==11)		
{
 BaseHitPoints = 384;
} 
else
{
for (int i=1; i<=(Level-11); i++)
 {
  step=step*step;
 }	
 BaseHitPoints = (int)(384*(float)step);
} 
			NpcFlags = 0;
			Size = 1f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			SkinLoot = new Loot[] { new Loot( typeof( LightHide ), 4.4f )
									,new Loot( typeof( LightLeather ), 74.4f )
									,new Loot( typeof( RuinedLeatherScraps ), 38.1f )
										};
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.SavannahHuntress, 100f ) };
		}
	}
}

namespace Server.Creatures
{
	public class SavannahMatriarch : BaseCreature
	{
		public SavannahMatriarch() : base()
		{
			Name = "Savannah Matriarch";
			Id = 3416;
			Model = 1058;
			Level = RandomLevel(17,18);
			SetDamage(20f,26f);
			AttackSpeed = 1700;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.914f;
			CombatReach = 1.07f;
			Armor = (int)(Level*26.2);
			Block = Level;
float step=1.045f; //%the HP goes up per extra level
if (Level==17)		
{
 BaseHitPoints = 784;
} 
else
{
for (int i=1; i<=(Level-17); i++)
 {
  step=step*step;
 }	
 BaseHitPoints = (int)(784*(float)step);
} 
			NpcFlags = 0;
			Size = 1.15f;
			Speed = 5.2f;
			WalkSpeed = 5.2f;
			RunSpeed = 8.3f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			SkinLoot = new Loot[] { new Loot( typeof( LightHide ), 6.3f )
									,new Loot( typeof( LightLeather ), 105.3f )
									,new Loot( typeof( MediumHide ), 2.7f )
									,new Loot( typeof( MediumLeather ), 20.8f )
										};
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.SavannahMatriarch, 100f ) };
		}
	}
}

namespace Server.Creatures
{
	public class SavannahPatriarch : BaseCreature
	{
		public SavannahPatriarch() : base()
		{
			Name = "Savannah Patriarch";
			Id = 3241;
			Model = 1977;
			Level = RandomLevel(15,16);
			SetDamage(16f,21f);
			AttackSpeed = 1300;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 1.03f;
			CombatReach = 1.95f;
			Armor = (int)(Level*26.2);
			Block = Level;
float step=1.045f; //%the HP goes up per extra level
if (Level==15)		
{
 BaseHitPoints = 624;
} 
else
{
for (int i=1; i<=(Level-15); i++)
 {
  step=step*step;
 }	
 BaseHitPoints = (int)(624*(float)step);
} 
			NpcFlags = 0;
			Size = 1.3f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			SkinLoot = new Loot[] { new Loot( typeof( LightHide ), 6.3f )
									,new Loot( typeof( LightLeather ), 75.2f )
									,new Loot( typeof( RuinedLeatherScraps ), 31.9f )
										};
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.SavannahPatriarch, 100f ) };
		}
	}
}

namespace Server.Creatures
{
	public class SavannahProwler : BaseCreature
	{
		public SavannahProwler() : base()
		{
			Name = "Savannah Prowler";
			Id = 3425;
			Model = 1973;
			Level = RandomLevel(14,15);
			SetDamage(13f,16f);
			AttackSpeed = 1400;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.795f;
			CombatReach = 1.5f;
			Armor = (int)(Level*26.2);
			Block = Level;
float step=1.045f; //%the HP goes up per extra level
if (Level==14)		
{
 BaseHitPoints = 504;
} 
else
{
for (int i=1; i<=(Level-14); i++)
 {
  step=step*step;
 }	
 BaseHitPoints = (int)(504*(float)step);
} 
			NpcFlags = 0;
			Size = 1f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			SkinLoot = new Loot[] { new Loot( typeof( LightHide ), 6.3f )
									,new Loot( typeof( LightLeather ), 75.2f )
									,new Loot( typeof( RuinedLeatherScraps ), 31.9f )
										};
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.SavannahProwler, 100f ) };
		}
	}
}

namespace Server.Creatures
{
	public class Shadowclaw : BaseCreature
	{
		public Shadowclaw() : base()
		{
			Name = "Shadowclaw";
			Id = 2175;
			Model = 3030;
			Level = RandomLevel(13,13);
			SetDamage(22f,30f);
			AttackSpeed = 1700;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 10;
			BoundingRadius = 0.626f;
			CombatReach = 1.3f;
			Armor = (int)(Level*4);
			Block = Level*2;
			BaseHitPoints = 544;
			NpcFlags = 0;
			Size = 0.788f;
			Speed = 7f;
			WalkSpeed = 7f;
			RunSpeed = 11f;
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			NpcType = 1;
			Flags1 = 010;
			Elite = 2;
			SkinLoot = new Loot[] { new Loot( typeof( LightHide ), 6.3f )
									,new Loot( typeof( LightLeather ), 75.2f )
									,new Loot( typeof( RuinedLeatherScraps ), 46.6f )
										};
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.Shadowclaw, 100f ) };
			LearnSpell( 11980, SpellsTypes.Curse);
		}
	}
}

namespace Server.Creatures
{
	public class ShyRotam : BaseCreature
	{
		public ShyRotam() : base()
		{
			Name = "Shy-Rotam";
			Id = 10737;
			Model = 10113;
			Level = RandomLevel(60,60);
			SetDamage(65f,85f);
			AttackSpeed = 1500;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 10;
			BoundingRadius = 1.65f;
			CombatReach = 1.65f;
			Armor = (int)(Level*42.2);
			Block = (int)(Level*2.2);
			BaseHitPoints = 2426;
			NpcFlags = 0;
			Size = 1f;
			Speed = 10.3f;
			WalkSpeed = 10.3f;
			RunSpeed = 16.5f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			Elite = 1;
			SkinLoot = new Loot[] { new Loot( typeof( RuggedHide ), 2.5f )
									,new Loot( typeof( RuggedLeather ), 127.2f )
									,new Loot( typeof( ThickLeather ), 16f )
										};
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.ShyRotam, 100f ) };
		}
	}
}

namespace Server.Creatures
{
	public class SianRotam : BaseCreature
	{
		public SianRotam() : base()
		{
			Name = "Sian-Rotam";
			Id = 10741;
			Model = 10114;
			Level = RandomLevel(60,60);
			SetDamage(65f,85f);
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.875f;
			CombatReach = 1.65f;
			Armor = (int)(Level*42.2);
			Block = (int)(Level*2.2);
			BaseHitPoints = 2426;
			NpcFlags = 0;
			Size = 1f;
			Speed = 10.3f;
			WalkSpeed = 10.3f;
			RunSpeed = 16.5f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			Elite = 1;
			SkinLoot = new Loot[] { new Loot( typeof( ThickLeather ), 16f )
									,new Loot( typeof( RuggedHide ), 1.8f )
									,new Loot( typeof( RuggedLeather ), 82.5f )
										};
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.SianRotam, 100f ) };
		}
	}
}

namespace Server.Creatures
{
	public class SinDall : BaseCreature
	{
		public SinDall() : base()
		{
			Name = "Sin'Dall";
			Id = 729;
			Model = 471;
			Level = RandomLevel(37,37);
			SetDamage(40f,52f);
			AttackSpeed = 1300;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 1.19f;
			CombatReach = 2.25f;
			Armor = (int)(Level*26.2);
			Block = Level;
			BaseHitPoints = 1504;
			NpcFlags = 0;
			Size = 1.5f;
			Speed = 6f;
			WalkSpeed = 6f;
			RunSpeed = 9.6f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			SkinLoot = new Loot[] { new Loot( typeof( HeavyHide ), 3.5f )
									,new Loot( typeof( HeavyLeather ), 88.3f )
									,new Loot( typeof( ThickLeather ), 19.8f )
										};
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.SinDall, 100f ) };
		}
	}
}

namespace Server.Creatures
{
	public class SwampJaguar : BaseCreature
	{
		public SwampJaguar() : base()
		{
			Name = "Swamp Jaguar";
			Id = 767;
			Model = 632;
			Level = RandomLevel(36,37);
			SetDamage(38f,49f);
			AttackSpeed = 1200;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.914f;
			CombatReach = 1.07f;
			Armor = (int)(Level*26.2);
			Block = Level;
float step=1.045f; //%the HP goes up per extra level
if (Level==36)		
{
 BaseHitPoints = 1424;
} 
else
{
for (int i=1; i<=(Level-36); i++)
 {
  step=step*step;
 }	
 BaseHitPoints = (int)(1424*(float)step);
} 
			NpcFlags = 0;
			Size = 1.15f;
			Speed = 6f;
			WalkSpeed = 6f;
			RunSpeed = 9.6f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			SkinLoot = new Loot[] { new Loot( typeof( HeavyHide ), 3.5f )
									,new Loot( typeof( HeavyLeather ), 88.3f )
									,new Loot( typeof( ThickLeather ), 19.8f )
										};
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.SwampJaguar, 100f ) };
		}
	}
}

namespace Server.Creatures
{
	public class TheRake : BaseCreature
	{
		public TheRake() : base()
		{
			Name = "The Rake";
			Id = 5807;
			Model = 1973;
			Level = RandomLevel(10,10);
			SetDamage(10f,14f);
			AttackSpeed = 1200;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.795f;
			CombatReach = 1.5f;
			Armor = (int)(Level*45.2);
			Block = Level*2;
			BaseHitPoints = 424;
			NpcFlags = 0;
			Size = 1f;
			Speed = 7f;
			WalkSpeed = 7f;
			RunSpeed = 11f;
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			NpcType = 1;
			Flags1 = 010;
			Elite = 2;
			SkinLoot = new Loot[] { new Loot( typeof( LightLeather ), 50.3f )
									,new Loot( typeof( RuinedLeatherScraps ), 49.7f )
										};
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.TheRake, 100f ) };
			LearnSpell(12166, SpellsTypes.Offensive);
		}
	}
}

namespace Server.Creatures
{
	public class TwilightRunner : BaseCreature
	{
		public TwilightRunner() : base()
		{
			Name = "Twilight Runner";
			Id = 4067;
			Model = 11453;
			Level = RandomLevel(23,24);
			SetDamage(25f,32f);
			AttackSpeed = 1700;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.795f;
			CombatReach = 1.5f;
			Armor = (int)(Level*26.2);
			Block = Level;
float step=1.045f; //%the HP goes up per extra level
if (Level==23)		
{
 BaseHitPoints = 944;
} 
else
{
for (int i=1; i<=(Level-23); i++)
 {
  step=step*step;
 }	
 BaseHitPoints = (int)(944*(float)step);
} 
			NpcFlags = 0;
			Size = 1f;
			Speed = 5.4f;
			WalkSpeed = 5.4f;
			RunSpeed = 8.6f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 1;
			Flags1 = 010;
			SkinLoot = new Loot[] { new Loot( typeof( LightHide ), 3.1f )
									,new Loot( typeof( LightLeather ), 62.7f )
									,new Loot( typeof( MediumHide ), 5.2f )
									,new Loot( typeof( MediumLeather ), 52.2f )
										};
			Loots = new BaseTreasure[]{ new BaseTreasure( CatFamilyLoots.TwilightRunner, 100f ) };
		}
	}
}

