using System;
using System.Collections;
using Server;
using Server.Items;

namespace Server.Creatures
{
	public class BloodfenLashtail : BaseCreature
	{
		public BloodfenLashtail() : base()
		{
			Name = "Bloodfen Lashtail";
			Id = 4357;
			Model = 2573;
			Level = RandomLevel(40,41);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*28.2);
			Block= Level;
			Family=11;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1; BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 1.88f;
			CombatReach = 2.62f;
			Size = 1.75f;
			Speed = 6f;
			WalkSpeed = 6f;
			RunSpeed = 9f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 1764, 40 );
			SkinLoot = new Loot[] {new Loot( typeof( ThickLeather), 5.63367f ) 
,new Loot( typeof( HeavyHide), 0.758557f ) 
,new Loot( typeof( HeavyLeather), 21.1656f ) 
};
			Loots = new BaseTreasure[]{  new BaseTreasure( RaptorDrops.BloodfenLashtail , 100f )
										};
		}
	}
}


namespace Server.Creatures
{
	public class BloodfenRaptor : BaseCreature
	{
		public BloodfenRaptor() : base()
		{
			Name = "Bloodfen Raptor";
			Id = 4351;
			Model = 2571;
			Level = RandomLevel(35,36);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*28.2);
			Block= Level;
			Family=11;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1; BaseMana = 0;
			AttackSpeed = 2000;
			BoundingRadius = 1.07f;
			CombatReach = 1.5f;
			Size = 1.18f;
			Speed = 6f;
			WalkSpeed = 6f;
			RunSpeed = 9f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 1352, 35 );
			SkinLoot = new Loot[] {new Loot( typeof( MediumHide), 0.97914f ) 
,new Loot( typeof( MediumLeather), 9.38697f ) 
,new Loot( typeof( HeavyHide), 0.723712f ) 
,new Loot( typeof( HeavyLeather), 10.43f ) 
};
			Loots = new BaseTreasure[]{  new BaseTreasure( RaptorDrops.BloodfenRaptor , 100f )
										};
		}
	}
}

namespace Server.Creatures
{
	public class BloodfenRazormaw : BaseCreature
	{
		public BloodfenRazormaw() : base()
		{
			Name = "Bloodfen Razormaw";
			Id = 4356;
			Model = 11315;
			Level = RandomLevel(39,40);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*28.2);
			Block= Level;
			Family=11;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1; BaseMana = 0;

			AttackSpeed = 2000;
			BoundingRadius = 1.6f;
			CombatReach = 2.25f;
			Size = 1.5f;
			Speed = 6f;
			WalkSpeed = 6f;
			RunSpeed = 9f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 1779, 39 );
			SkinLoot = new Loot[] {new Loot( typeof( ThickLeather), 6.89324f ) 
,new Loot( typeof( HeavyHide), 1.02597f ) 
,new Loot( typeof( HeavyLeather), 25.4889f ) 
};
			Loots = new BaseTreasure[]{  new BaseTreasure( RaptorDrops.BloodfenRazormaw , 100f )
										};
		}
	}
}

namespace Server.Creatures
{
	public class BloodfenScreecher : BaseCreature
	{
		public BloodfenScreecher() : base()
		{
			Name = "Bloodfen Screecher";
			Id = 4352;
			Model = 1962;
			Level = RandomLevel(36,37);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*28.2);
			Block= Level;
			Family=11;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1; BaseMana = 0;

			AttackSpeed = 2000;
			BoundingRadius = 1.23f;
			CombatReach = 1.07f;
			Size = 1.15f;
			Speed = 6f;
			WalkSpeed = 6f;
			RunSpeed = 9f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 1153, 36 );
			SkinLoot = new Loot[] {new Loot( typeof( ThickLeather), 5.09259f ) 
,new Loot( typeof( HeavyHide), 0.881834f ) 
,new Loot( typeof( HeavyLeather), 20.5467f ) 
};
			Loots = new BaseTreasure[]{  new BaseTreasure( RaptorDrops.BloodfenScreecher , 100f )
										};
		}
	}
}

namespace Server.Creatures
{
	public class BloodfenScytheclaw : BaseCreature
	{
		public BloodfenScytheclaw() : base()
		{
			Name = "Bloodfen Scytheclaw";
			Id = 4355;
			Model = 2574;
			Level = RandomLevel(37,38);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*28.2);
			Block= Level;
			Family=11;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1; BaseMana = 0;

			AttackSpeed = 2000;
			BoundingRadius = 1.39f;
			CombatReach = 1.95f;
			Size = 1.3f;
			Speed = 6f;
			WalkSpeed = 6f;
			RunSpeed = 9f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 1545, 37 );
			SkinLoot = new Loot[] {new Loot( typeof( ThickLeather), 3.04896f ) 
,new Loot( typeof( HeavyHide), 0.439754f ) 
,new Loot( typeof( HeavyLeather), 12.3424f ) 
};
			Loots = new BaseTreasure[]{  new BaseTreasure( RaptorDrops.BloodfenScytheclaw , 100f )
										};
		}
	}
}

namespace Server.Creatures
{
	public class BloodtalonScythemaw : BaseCreature
	{
		public BloodtalonScythemaw() : base()
		{
			Name = "Bloodtalon Scythemaw";
			Id = 3123;
			Model = 1959;
			Level = RandomLevel(6,10);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*28.2);
			Block= Level;
			Family=11;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1; BaseMana = 0;
			AttackSpeed = 2000;
			BoundingRadius = 0.75f;
			CombatReach = 1.05f;
			Size = 0.7f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 53, 6 );
			SkinLoot = new Loot[] {new Loot( typeof( LightLeather), 8.96861f ) 
,new Loot( typeof( RuinedLeatherScraps), 13.0564f ) 
};
			Loots = new BaseTreasure[]{  new BaseTreasure( RaptorDrops.BloodtalonScythemaw , 100f )
										};
		}
	}
}

namespace Server.Creatures
{
	public class BloodtalonTaillasher : BaseCreature
	{
		public BloodtalonTaillasher() : base()
		{
			Name = "Bloodtalon Taillasher";
			Id = 3122;
			Model = 1960;
			Level = RandomLevel(2,8);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*28.2);
			Block= Level;
			Family=11;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1; BaseMana = 0;

			AttackSpeed = 2000;
			BoundingRadius = 0.59f;
			CombatReach = 0.82f;
			Size = 0.55f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 32, 2 );
			SkinLoot = new Loot[] {new Loot( typeof( LightLeather), 9.29117f ) 
,new Loot( typeof( RuinedLeatherScraps), 13.5157f ) 
};
			Loots = new BaseTreasure[]{  new BaseTreasure( RaptorDrops.BloodtalonTaillasher , 100f )
										};
		}
	}
}

namespace Server.Creatures
{
	public class CorruptedBloodtalonScythemaw : BaseCreature
	{
		public CorruptedBloodtalonScythemaw() : base()
		{
			Name = "Corrupted Bloodtalon Scythemaw";
			Id = 3227;
			Model = 787;
			Level = RandomLevel(10,11);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*28.2);
			Block= Level;
			Family=11;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1; BaseMana = 0;
			AttackSpeed = 2000;
			BoundingRadius = 0.75f;
			CombatReach = 1.05f;
			Size = 0.7f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 278, 10 );
			SkinLoot = new Loot[] {new Loot( typeof( LightLeather), 7.83636f ) 
,new Loot( typeof( RuinedLeatherScraps), 11.1207f ) 
};
			Loots = new BaseTreasure[]{  new BaseTreasure( RaptorDrops.CorruptedBloodtalonScythemaw , 100f )
										};
		}
	}
}

namespace Server.Creatures
{
	public class Dart : BaseCreature
	{
		public Dart() : base()
		{
			Name = "Dart";
			Id = 14232;
			Model = 788;
			Level = RandomLevel(38);
			ResistArcane = 60;
			ResistFire = 60;
			ResistFrost = 60;
			ResistHoly = 60;
			ResistNature = 60;
			ResistShadow = 60;
			Str = (int)(Level*4.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= 2158;
			Block= Level;
			Family=11;
			Elite=4;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1; BaseMana = 0;

			AttackSpeed = 2000;
			BoundingRadius = 1.23f;
			CombatReach = 1.07f;
			Size = 1.15f;
			Speed = 7f;
			WalkSpeed = 7f;
			RunSpeed = 11f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			Elite=4;
			BCAddon.Hp( this, 2352, 38 );
			SkinLoot = new Loot[] {new Loot( typeof( ThickLeather), 8.33333f ) 
,new Loot( typeof( HeavyLeather), 16.6667f ) 
};
			Loots = new BaseTreasure[]{  new BaseTreasure( RaptorDrops.Dart , 100f )
										};
		}
	}
}

namespace Server.Creatures
{
	public class DeviateCreeper : BaseCreature
	{
		public DeviateCreeper() : base()
		{
			Name = "Deviate Creeper";
			Id = 3632;
			Model = 1744;
			Level = RandomLevel(15,16);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*3.2f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= (int)(Level*2.2);
			Block= Level;
			Family=11;
			Elite=1;
			SetDamage(1f+2.8f*Level,1f+3.5*Level);
			ManaType=1; BaseMana = 0;

			AttackSpeed = 2000;
			BoundingRadius = 0.75f;
			CombatReach = 1.05f;
			Size = 0.7f;
			Speed = 7f;
			WalkSpeed = 7f;
			RunSpeed = 12f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			Elite=1;
			BCAddon.Hp( this, 736, 15 );
			SkinLoot = new Loot[] {new Loot( typeof( LightHide), 1.67131f ) 
,new Loot( typeof( LightLeather), 13.9915f ) 
,new Loot( typeof( MediumHide), 0.80369f ) 
,new Loot( typeof( MediumLeather), 6.39755f ) 
};
			Loots = new BaseTreasure[]{  new BaseTreasure( RaptorDrops.DeviateCreeper , 100f )
										};
		}
	}
}

namespace Server.Creatures
{
	public class DeviateGuardian : BaseCreature
	{
		public DeviateGuardian() : base()
		{
			Name = "Deviate Guardian";
			Id = 3637;
			Model = 755;
			Level = RandomLevel(18,19);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*3.2f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= (int)(Level*2.2);
			Block= Level;
			Family=11;
			SetDamage(1f+2.8f*Level,1f+3.5*Level);
			ManaType=1; BaseMana = 0;

			AttackSpeed = 2000;
			BoundingRadius = 1.07f;
			CombatReach = 1.5f;
			Size = 1f;
			Speed = 8f;
			WalkSpeed = 8f;
			RunSpeed = 12f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			Elite=1;
			BCAddon.Hp( this, 677, 18 );
			SkinLoot = new Loot[] {new Loot( typeof( MediumHide), 0.512356f ) 
,new Loot( typeof( MediumLeather), 4.20479f ) 
,new Loot( typeof( LightHide), 1.27704f ) 
,new Loot( typeof( LightLeather), 9.70973f ) 
};
			Loots = new BaseTreasure[]{  new BaseTreasure( RaptorDrops.DeviateGuardian , 100f )
										};
		}
	}
}

namespace Server.Creatures
{
	public class DeviateRavager : BaseCreature
	{
		public DeviateRavager() : base()
		{
			Name = "Deviate Ravager";
			Id = 3636;
			Model = 1747;
			Level = RandomLevel(18,19);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*3.2f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= (int)(Level*2.2);
			Block= Level;
			Family=11;
			SetDamage(1f+2.8f*Level,1f+3.5*Level);
			ManaType=1; BaseMana = 0;

			AttackSpeed = 2000;
			BoundingRadius = 0.91f;
			CombatReach = 1.27f;
			Size = 0.85f;
			Speed = 8f;
			WalkSpeed = 8f;
			RunSpeed = 12f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			Elite=1;
			BCAddon.Hp( this, 555, 18 );
			SkinLoot = new Loot[] {new Loot( typeof( MediumHide), 0.521872f ) 
,new Loot( typeof( MediumLeather), 4.20348f ) 
,new Loot( typeof( LightHide), 1.04374f ) 
,new Loot( typeof( LightLeather), 9.40973f ) 
};
			Loots = new BaseTreasure[]{  new BaseTreasure( RaptorDrops.DeviateRavager , 100f )
										};
		}
	}
}

namespace Server.Creatures
{
	public class DeviateSlayer : BaseCreature
	{
		public DeviateSlayer() : base()
		{
			Name = "Deviate Slayer";
			Id = 3633;
			Model = 949;
			Level = RandomLevel(16,17);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*3.2f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= (int)(Level*2.2);
			Block= Level;
			Family=11;
			SetDamage(1f+2.8f*Level,1f+3.5*Level);
			ManaType=1; BaseMana = 0;

			AttackSpeed = 2000;
			BoundingRadius = 0.91f;
			CombatReach = 1.27f;
			Size = 0.85f;
			Speed = 8f;
			WalkSpeed = 8f;
			RunSpeed = 12f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			Elite=1;
			BCAddon.Hp( this, 937, 16 );
			SkinLoot = new Loot[] {new Loot( typeof( MediumHide), 0.620933f ) 
,new Loot( typeof( MediumLeather), 4.43577f ) 
,new Loot( typeof( LightHide), 1.25302f ) 
,new Loot( typeof( LightLeather), 10.3216f ) 
};
			Loots = new BaseTreasure[]{  new BaseTreasure( RaptorDrops.DeviateSlayer , 100f )
										};
		}
	}
}

namespace Server.Creatures
{
	public class DeviateStalker : BaseCreature
	{
		public DeviateStalker() : base()
		{
			Name = "Deviate Stalker";
			Id = 3634;
			Model = 1746;
			Level = RandomLevel(15,17);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*3.2f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= (int)(Level*2.2);
			Block= Level;
			Family=11;
			SetDamage(1f+2.8f*Level,1f+3.5*Level);
			ManaType=1; BaseMana = 0;

			AttackSpeed = 2000;
			BoundingRadius = 0.75f;
			CombatReach = 1.05f;
			Size = 0.7f;
			Speed = 8f;
			WalkSpeed = 8f;
			RunSpeed = 12f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			Elite=1;
			BCAddon.Hp( this, 832, 15 );
			SkinLoot = new Loot[] {new Loot( typeof( MediumHide), 0.700438f ) 
,new Loot( typeof( MediumLeather), 6.00375f ) 
,new Loot( typeof( LightHide), 1.76986f ) 
,new Loot( typeof( LightLeather), 13.2833f ) 
};
			Loots = new BaseTreasure[]{  new BaseTreasure( RaptorDrops.DeviateStalker , 100f )
										};
		}
	}
}

namespace Server.Creatures
{
	public class ElderRazormaw : BaseCreature
	{
		public ElderRazormaw() : base()
		{
			Name = "Elder Razormaw";
			Id = 1019;
			Model = 788;
			Level = RandomLevel(29 );
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*28.2);
			Block= Level;
			Family=11;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1; BaseMana = 0;

			AttackSpeed = 2000;
			BoundingRadius = 1.23f;
			CombatReach = 1.07f;
			Size = 1.15f;
			Speed = 6f;
			WalkSpeed = 6f;
			RunSpeed = 9f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 965, 29 );
			SkinLoot = new Loot[] {new Loot( typeof( LightHide), 0.00688516f ) 
,new Loot( typeof( MediumHide), 1.15671f ) 
,new Loot( typeof( MediumLeather), 16.9375f ) 
,new Loot( typeof( HeavyHide), 0.447535f ) 
,new Loot( typeof( HeavyLeather), 4.63371f ) 
};
			Loots = new BaseTreasure[]{  new BaseTreasure( RaptorDrops.ElderRazormaw , 100f )
										};
		}
	}
}

namespace Server.Creatures
{
	public class HighlandFleshstalker : BaseCreature
	{
		public HighlandFleshstalker() : base()
		{
			Name = "Highland Fleshstalker";
			Id = 2561;
			Model = 961;
			Level = RandomLevel(36,37);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*28.2);
			Block= Level;
			Family=11;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1; BaseMana = 0;

			AttackSpeed = 2000;
			BoundingRadius = 1.39f;
			CombatReach = 1.95f;
			Size = 1.13f;
			Speed = 6f;
			WalkSpeed = 6f;
			RunSpeed = 9f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 996, 36 );
			SkinLoot = new Loot[] {new Loot( typeof( ThickLeather), 4.16821f ) 
,new Loot( typeof( HeavyHide), 0.582068f ) 
,new Loot( typeof( HeavyLeather), 16.49f ) 
};
			Loots = new BaseTreasure[]{  new BaseTreasure( RaptorDrops.HighlandFleshstalker , 100f )
										};
		}
	}
}

namespace Server.Creatures
{
	public class HighlandLashtail : BaseCreature
	{
		public HighlandLashtail() : base()
		{
			Name = "Highland Lashtail";
			Id = 1016;
			Model = 673;
			Level = RandomLevel(24,25);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*28.2);
			Block= Level;
			Family=11;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1; BaseMana = 0;

			AttackSpeed = 2000;
			BoundingRadius = 0.75f;
			CombatReach = 1.05f;
			Size = 0.7f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 9f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 748, 24 );
			SkinLoot = new Loot[] {new Loot( typeof( LightHide), 0.682594f ) 
,new Loot( typeof( LightLeather), 9.59727f ) 
,new Loot( typeof( MediumHide), 1.11945f ) 
,new Loot( typeof( MediumLeather), 11.0034f ) 
};
			Loots = new BaseTreasure[]{  new BaseTreasure( RaptorDrops.HighlandLashtail , 100f )
										};
		}
	}
}

namespace Server.Creatures
{
	public class HighlandRaptor : BaseCreature
	{
		public HighlandRaptor() : base()
		{
			Name = "Highland Raptor";
			Id = 1015;
			Model = 670;
			Level = RandomLevel(23,24);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*28.2);
			Block= Level;
			Family=11;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1; BaseMana = 0;

			AttackSpeed = 2000;
			BoundingRadius = 0.66f;
			CombatReach = 0.92f;
			Size = 0.61f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 9f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 685, 23 );
			SkinLoot = new Loot[] {new Loot( typeof( LightHide), 0.631403f ) 
,new Loot( typeof( LightLeather), 9.01835f ) 
,new Loot( typeof( MediumHide), 1.03645f ) 
,new Loot( typeof( MediumLeather), 10.6743f ) 
};
			Loots = new BaseTreasure[]{  new BaseTreasure( RaptorDrops.HighlandRaptor , 100f )
										};
		}
	}
}

namespace Server.Creatures
{
	public class HighlandRazormaw : BaseCreature
	{
		public HighlandRazormaw() : base()
		{
			Name = "Highland Razormaw";
			Id = 1018;
			Model = 180;
			Level = RandomLevel(27,28);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*28.2);
			Block= Level;
			Family=11;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1; BaseMana = 0;

			AttackSpeed = 2000;
			BoundingRadius = 0.68f;
			CombatReach = 0.94f;
			Size = 0.64f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 9f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 810, 27 );
			SkinLoot = new Loot[] {new Loot( typeof( HeavyLeather), 5.34928f ) 
,new Loot( typeof( LightLeather), 0.00431742f ) 
,new Loot( typeof( MediumHide), 1.29954f ) 
,new Loot( typeof( MediumLeather), 19.4888f ) 
};
			Loots = new BaseTreasure[]{  new BaseTreasure( RaptorDrops.HighlandRazormaw , 100f )
										};
		}
	}
}

namespace Server.Creatures
{
	public class HighlandScytheclaw : BaseCreature
	{
		public HighlandScytheclaw() : base()
		{
			Name = "Highland Scytheclaw";
			Id = 1017;
			Model = 649;
			Level = RandomLevel(25,26);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*28.2);
			Block= Level;
			Family=11;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1; BaseMana = 0;

			AttackSpeed = 2000;
			BoundingRadius = 0.91f;
			CombatReach = 1.27f;
			Size = 0.85f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 9f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 753, 25 );
			SkinLoot = new Loot[] { new Loot( typeof( LightHide), 0.704739f ) 
,new Loot( typeof( LightLeather), 8.79708f ) 
,new Loot( typeof( MediumHide), 1.08141f ) 
,new Loot( typeof( MediumLeather), 11.1908f ) 
};
			Loots = new BaseTreasure[]{  new BaseTreasure( RaptorDrops.HighlandScytheclaw , 100f )
										};
		}
	}
}

namespace Server.Creatures
{
	public class HighlandStrider : BaseCreature
	{
		public HighlandStrider() : base()
		{
			Name = "Highland Strider";
			Id = 2559;
			Model = 11316;
			Level = RandomLevel(30,44);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*28.2);
			Block= Level;
			Family=11;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1; BaseMana = 0;

			AttackSpeed = 2000;
			BoundingRadius = 1.23f;
			CombatReach = 1.07f;
			Size = 1.15f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 7f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 970, 30 );
			SkinLoot = new Loot[] {new Loot( typeof( MediumHide), 1.0275f ) 
,new Loot( typeof( MediumLeather), 14.5443f ) 
,new Loot( typeof( HeavyHide), 0.395598f ) 
,new Loot( typeof( HeavyLeather), 3.90073f ) 
};
			Loots = new BaseTreasure[]{  new BaseTreasure( RaptorDrops.HighlandStrider , 100f )
										};
		}
	}
}

namespace Server.Creatures
{
	public class HighlandThrasher : BaseCreature
	{
		public HighlandThrasher() : base()
		{
			Name = "Highland Thrasher";
			Id = 2560;
			Model = 180;
			Level = RandomLevel(33,34);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*28.2);
			Block= Level;
			Family=11;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1; BaseMana = 0;

			AttackSpeed = 2000;
			BoundingRadius = 0.71f;
			CombatReach = 1.0f;
			Size = 0.67f;
			Speed = 6f;
			WalkSpeed = 6f;
			RunSpeed = 9f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 1105, 33 );
			SkinLoot = new Loot[] {new Loot( typeof( MediumHide), 0.709502f ) 
,new Loot( typeof( MediumLeather), 7.08618f ) 
,new Loot( typeof( HeavyHide), 0.479632f ) 
,new Loot( typeof( HeavyLeather), 8.15154f ) 
};
			Loots = new BaseTreasure[]{  new BaseTreasure( RaptorDrops.HighlandThrasher , 100f )
										};
		}
	}
}

namespace Server.Creatures
{
	public class Ishamuhale : BaseCreature
	{
		public Ishamuhale() : base()
		{
			Name = "Ishamuhale";
			Id = 3257;
			Model = 2571;
			Level = RandomLevel(19 );
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*28.2);
			Block= Level;
			Family=11;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1; BaseMana = 0;
 
			AttackSpeed = 2000;
			BoundingRadius = 1.07f;
			CombatReach = 1.5f;
			Size = 1f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 405, 19 );
			SkinLoot = new Loot[] {new Loot( typeof( MediumHide), 0.323339f ) 
,new Loot( typeof( MediumLeather), 1.73427f ) 
,new Loot( typeof( LightHide), 0.440917f ) 
,new Loot( typeof( LightLeather), 6.408f ) 
};
			Loots = new BaseTreasure[]{  new BaseTreasure( RaptorDrops.Ishamuhale , 100f )
										};
		}
	}
}

namespace Server.Creatures
{
	public class JungleStalker : BaseCreature
	{
		public JungleStalker() : base()
		{
			Name = "Jungle Stalker";
			Id = 687;
			Model = 11317;
			Level = RandomLevel(40,41);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*28.2);
			Block= Level;
			Family=11;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1; BaseMana = 0;

			AttackSpeed = 2000;
			BoundingRadius = 1.39f;
			CombatReach = 1.95f;
			Size = 1.3f;
			Speed = 6f;
			WalkSpeed = 6f;
			RunSpeed = 10f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 1490, 40 );
			SkinLoot = new Loot[] {new Loot( typeof( ThickLeather), 5.18062f ) 
,new Loot( typeof( HeavyHide), 0.733237f ) 
,new Loot( typeof( HeavyLeather), 19.7138f ) 
};
			Loots = new BaseTreasure[]{  new BaseTreasure( RaptorDrops.JungleStalker , 100f )
										};
		}
	}
}

namespace Server.Creatures
{
	public class LashtailRaptor : BaseCreature
	{
		public LashtailRaptor() : base()
		{
			Name = "Lashtail Raptor";
			Id = 686;
			Model = 788;
			Level = RandomLevel(35,36);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*28.2);
			Block= Level;
			Family=11;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1; BaseMana = 0;

			AttackSpeed = 2000;
			BoundingRadius = 1.23f;
			CombatReach = 1.07f;
			Size = 1.15f;
			Speed = 6f;
			WalkSpeed = 6f;
			RunSpeed = 10f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 1187, 35 );
			SkinLoot = new Loot[] {new Loot( typeof( MediumHide), 0.74381f ) 
,new Loot( typeof( MediumLeather), 8.23329f ) 
,new Loot( typeof( HeavyHide), 0.604345f ) 
,new Loot( typeof( HeavyLeather), 9.62385f ) 
};
			Loots = new BaseTreasure[]{  new BaseTreasure( RaptorDrops.LashtailRaptor , 100f )
										};
		}
	}
}

namespace Server.Creatures
{
	public class MottledRaptor : BaseCreature
	{
		public MottledRaptor() : base()
		{
			Name = "Mottled Raptor";
			Id = 1020;
			Model = 960;
			Level = RandomLevel(22,23);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*28.2);
			Block= Level;
			Family=11;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1; BaseMana = 0;

			AttackSpeed = 2000;
			BoundingRadius = 0.66f;
			CombatReach = 0.91f;
			Size = 0.61f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 9f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 553, 22 );
			SkinLoot = new Loot[] {new Loot( typeof( LightHide), 0.981154f ) 
,new Loot( typeof( LightLeather), 13.6585f ) 
,new Loot( typeof( MediumHide), 1.78336f ) 
,new Loot( typeof( MediumLeather), 16.2257f ) 
};
			Loots = new BaseTreasure[]{  new BaseTreasure( RaptorDrops.MottledRaptor , 100f )
										};
		}
	}
}

namespace Server.Creatures
{
	public class MottledRazormaw : BaseCreature
	{
		public MottledRazormaw() : base()
		{
			Name = "Mottled Razormaw";
			Id = 1023;
			Model = 949;
			Level = RandomLevel(26,27);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*28.2);
			Block= Level;
			Family=11;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1; BaseMana = 0;

			AttackSpeed = 2000;
			BoundingRadius = 0.91f;
			CombatReach = 1.27f;
			Size = 0.85f;
			Speed = 6f;
			WalkSpeed = 6f;
			RunSpeed = 9f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 759, 26 );
			SkinLoot = new Loot[] {new Loot( typeof( MediumHide), 1.82172f ) 
,new Loot( typeof( MediumLeather), 27.1237f ) 
,new Loot( typeof( HeavyHide), 0.758774f ) 
,new Loot( typeof( HeavyLeather), 7.41204f ) 
};
			Loots = new BaseTreasure[]{  new BaseTreasure( RaptorDrops.MottledRazormaw , 100f )
										};
		}
	}
}

namespace Server.Creatures
{
	public class MottledScreecher : BaseCreature
	{
		public MottledScreecher() : base()
		{
			Name = "Mottled Screecher";
			Id = 1021;
			Model = 677;
			Level = RandomLevel(24,25);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*28.2);
			Block= Level;
			Family=11;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1; BaseMana = 0;

			AttackSpeed = 2000;
			BoundingRadius = 0.75f;
			CombatReach = 1.05f;
			Size = 0.7f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 9f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 576, 24 );
			SkinLoot = new Loot[] {new Loot( typeof( LightHide), 0.85535f ) 
,new Loot( typeof( LightLeather), 12.5777f ) 
,new Loot( typeof( MediumHide), 1.5232f ) 
,new Loot( typeof( MediumLeather), 14.778f ) 
};
			Loots = new BaseTreasure[]{  new BaseTreasure( RaptorDrops.MottledScreecher , 100f )
										};
		}
	}
}

namespace Server.Creatures
{
	public class MottledScytheclaw : BaseCreature
	{
		public MottledScytheclaw() : base()
		{
			Name = "Mottled Scytheclaw";
			Id = 1022;
			Model = 648;
			Level = RandomLevel(25,26);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*28.2);
			Block= Level;
			Family=11;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1; BaseMana = 0;

			AttackSpeed = 2000;
			BoundingRadius = 0.91f;
			CombatReach = 1.27f;
			Size = 0.85f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 9f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 723, 25 );
			SkinLoot = new Loot[] {new Loot( typeof( LightHide), 0.986269f ) 
,new Loot( typeof( LightLeather), 14.1356f ) 
,new Loot( typeof( MediumHide), 1.71257f ) 
,new Loot( typeof( MediumLeather), 17.0337f ) 
};
			Loots = new BaseTreasure[]{  new BaseTreasure( RaptorDrops.MottledScytheclaw , 100f )
										};
		}
	}
}

namespace Server.Creatures
{
	public class RazormawMatriarch : BaseCreature
	{
		public RazormawMatriarch() : base()
		{
			Name = "Razormaw Matriarch";
			Id = 1140;
			Model = 11316;
			Level = RandomLevel(31 );
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*3.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= 1248;
			Block= Level;
			Family=11;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1; BaseMana = 0;

			AttackSpeed = 2000;
			BoundingRadius = 1f;
			CombatReach = 2.7f;
			Size = 1f;
			Speed = 8f;
			WalkSpeed = 8f;
			RunSpeed = 13f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			Elite=4;
			BCAddon.Hp( this, 1352, 31 );
			SkinLoot = new Loot[] {new Loot( typeof( HeavyHide), 0.47619f ) 
,new Loot( typeof( HeavyLeather), 4.7619f ) 
,new Loot( typeof( MediumLeather), 2.85714f ) 
};
			Loots = new BaseTreasure[]{  new BaseTreasure( RaptorDrops.RazormawMatriarch , 100f )
										};
		}
	}
}

namespace Server.Creatures
{
	public class Sarltooth : BaseCreature
	{
		public Sarltooth() : base()
		{
			Name = "Sarltooth";
			Id = 1353;
			Model = 755;
			Level = RandomLevel(29 );
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*28.2);
			Block= Level;
			Family=11;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1; BaseMana = 0;

			AttackSpeed = 2000;
			BoundingRadius = 1f;
			CombatReach = 2f;
			Size = 1f;
			Speed = 6f;
			WalkSpeed = 6f;
			RunSpeed = 9f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 965, 29 );
			SkinLoot = new Loot[] {new Loot( typeof( MediumHide), 0.717328f ) 
,new Loot( typeof( MediumLeather), 11.8807f ) 
,new Loot( typeof( HeavyHide), 0.650078f ) 
,new Loot( typeof( HeavyLeather), 3.60906f ) 
};
			Loots = new BaseTreasure[]{  new BaseTreasure( RaptorDrops.Sarltooth , 100f )
										};
		}
	}
}

namespace Server.Creatures
{
	public class StranglethornRaptor : BaseCreature
	{
		public StranglethornRaptor() : base()
		{
			Name = "Stranglethorn Raptor";
			Id = 685;
			Model = 788;
			Level = RandomLevel(33,34);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*28.2);
			Block= Level;
			Family=11;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1; BaseMana = 0;

			AttackSpeed = 2000;
			BoundingRadius = 1.23f;
			CombatReach = 1.07f;
			Size = 1.15f;
			Speed = 6f;
			WalkSpeed = 6f;
			RunSpeed = 9f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 975, 33 );
			SkinLoot = new Loot[] {new Loot( typeof( MediumHide), 0.841633f ) 
,new Loot( typeof( MediumLeather), 9.25796f ) 
,new Loot( typeof( HeavyHide), 0.689671f ) 
,new Loot( typeof( HeavyLeather), 10.6841f ) 
};
			Loots = new BaseTreasure[]{  new BaseTreasure( RaptorDrops.StranglethornRaptor , 100f )
										};
		}
	}
}

namespace Server.Creatures
{
	public class SunscaleLashtail : BaseCreature
	{
		public SunscaleLashtail() : base()
		{
			Name = "Sunscale Lashtail";
			Id = 3254;
			Model = 1744;
			Level = RandomLevel(11,13);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*28.2);
			Block= Level;
			Family=11;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1; BaseMana = 0;
 
			AttackSpeed = 2000;
			BoundingRadius = 0.75f;
			CombatReach = 1.05f;
			Size = 0.7f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 178, 11 );
			SkinLoot = new Loot[] {new Loot( typeof( LightHide), 0.948213f ) 
,new Loot( typeof( LightLeather), 11.2874f ) 
,new Loot( typeof( RuinedLeatherScraps), 6.27279f ) 
};
			Loots = new BaseTreasure[]{  new BaseTreasure( RaptorDrops.SunscaleLashtail , 100f )
										};
		}
	}
}

namespace Server.Creatures
{
	public class SunscaleScreecher : BaseCreature
	{
		public SunscaleScreecher() : base()
		{
			Name = "Sunscale Screecher";
			Id = 3255;
			Model = 1747;
			Level = RandomLevel(13,15);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*28.2);
			Block= Level;
			Family=11;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1; BaseMana = 0;

			AttackSpeed = 2000;
			BoundingRadius = 0.91f;
			CombatReach = 1.27f;
			Size = 0.85f;
			Speed = 4f;
			WalkSpeed = 4f;
			RunSpeed = 6f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 272, 13 );
			SkinLoot = new Loot[] {new Loot( typeof( LightHide), 1.18407f ) 
,new Loot( typeof( RuinedLeatherScraps), 8.38713f ) 
,new Loot( typeof( LightLeather), 14.1937f ) 
};
			Loots = new BaseTreasure[]{  new BaseTreasure( RaptorDrops.SunscaleScreecher , 100f )
										};
		}
	}
}

namespace Server.Creatures
{
	public class SunscaleScytheclaw : BaseCreature
	{
		public SunscaleScytheclaw() : base()
		{
			Name = "Sunscale Scytheclaw";
			Id = 3256;
			Model = 4442;
			Level = RandomLevel(16,18);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*28.2);
			Block= Level;
			Family=11;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1; BaseMana = 0;

			AttackSpeed = 2000;
			BoundingRadius = 1.07f;
			CombatReach = 1.5f;
			Size = 1f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 342, 16 );
			SkinLoot = new Loot[] {new Loot( typeof( MediumHide), 0.530102f ) 
,new Loot( typeof( MediumLeather), 5.37675f ) 
,new Loot( typeof( LightHide), 1.31156f ) 
,new Loot( typeof( LightLeather), 19.2899f ) 
};
			Loots = new BaseTreasure[]{  new BaseTreasure( RaptorDrops.SunscaleScytheclaw , 100f )
										};
		}
	}
}

namespace Server.Creatures
{
	public class TakkTheLeaper : BaseCreature
	{
		public TakkTheLeaper() : base()
		{
			Name = "Takk the Leaper";
			Id = 5842;
			Model = 1337;
			Level = RandomLevel(19 );
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = 44;
			NpcType = (int)NpcTypes.Beast ;
			Armor= 851;
			Block= Level;
			Family=11;
			SetDamage(1f+2.8f*Level,1f+3.5*Level);
			ManaType=1; BaseMana = 0;

			AttackSpeed = 2000;
			BoundingRadius = 1.07f;
			CombatReach = 1.5f;
			Size = 1f;
			Speed = 8f;
			WalkSpeed = 8f;
			RunSpeed = 13f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			Elite=1;
			BCAddon.Hp( this, 1392, 19 );
			SkinLoot = new Loot[] {new Loot( typeof( LightLeather), 6.07287f ) 
,new Loot( typeof( MediumHide), 0.809717f ) 
,new Loot( typeof( MediumLeather), 2.02429f ) 
};
			Loots = new BaseTreasure[]{  new BaseTreasure( RaptorDrops.TakktheLeaper , 100f )
										};
		}
	}
}

namespace Server.Creatures
{
	public class Tethis : BaseCreature
	{
		public Tethis() : base()
		{
			Name = "Tethis";
			Id = 730;
			Model = 8472;
			Level = RandomLevel(43 );
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*3.2f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= 4964;
			Block= Level;
			Family=11;
			SetDamage(1f+2.8f*Level,1f+3.5*Level);
			ManaType=1; BaseMana = 0;

			AttackSpeed = 2000;
			BoundingRadius = 1.6f;
			CombatReach = 2.25f;
			Size = 1.5f;
			Speed = 9f;
			WalkSpeed = 9f;
			RunSpeed = 15f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			Elite=1;
			BCAddon.Hp( this, 5015, 43 );
			SkinLoot = new Loot[] {new Loot( typeof( HeavyHide), 0.608195f ) 
,new Loot( typeof( HeavyLeather), 6.69014f ) 
,new Loot( typeof( ThickHide), 0.608195f ) 
,new Loot( typeof( ThickLeather), 8.03457f ) 
};
			Loots = new BaseTreasure[]{  new BaseTreasure( RaptorDrops.Tethis , 100f )
										};
		}
	}
}

namespace Server.Creatures
{
	public class YoungJungleStalker : BaseCreature
	{
		public YoungJungleStalker() : base()
		{
			Name = "Young Jungle Stalker";
			Id = 854;
			Model = 615;
			Level = RandomLevel(36,37);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*28.2);
			Block= Level;
			Family=11;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1; BaseMana = 0;

			AttackSpeed = 2000;
			BoundingRadius = 1.23f;
			CombatReach = 1.07f;
			Size = 1.15f;
			Speed = 6f;
			WalkSpeed = 6f;
			RunSpeed = 10f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 1204, 36 );
			SkinLoot = new Loot[] {new Loot( typeof( ThickLeather), 5.72706f ) 
,new Loot( typeof( HeavyHide), 0.596125f ) 
,new Loot( typeof( HeavyLeather), 19.1825f ) 
};
			Loots = new BaseTreasure[]{  new BaseTreasure( RaptorDrops.YoungJungleStalker , 100f )
										};
		}
	}
}

namespace Server.Creatures
{
	public class YoungLashtailRaptor : BaseCreature
	{
		public YoungLashtailRaptor() : base()
		{
			Name = "Young Lashtail Raptor";
			Id = 856;
			Model = 2571;
			Level = RandomLevel(33,34);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*28.2);
			Block= Level;
			Family=11;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1; BaseMana = 0;

			AttackSpeed = 2000;
			BoundingRadius = 1.07f;
			CombatReach = 1.5f;
			Size = 0.75f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 1214, 33 );
			SkinLoot = new Loot[] {new Loot( typeof( MediumHide), 0.852941f ) 
,new Loot( typeof( MediumLeather), 8.41176f ) 
,new Loot( typeof( HeavyHide), 0.411765f ) 
,new Loot( typeof( HeavyLeather), 11.0882f ) 
};
			Loots = new BaseTreasure[]{  new BaseTreasure( RaptorDrops.YoungLashtailRaptor , 100f )
										};
		}
	}
}

namespace Server.Creatures
{
	public class YoungStranglethornRaptor : BaseCreature
	{
		public YoungStranglethornRaptor() : base()
		{
			Name = "Young Stranglethorn Raptor";
			Id = 855;
			Model = 180;
			Level = RandomLevel(30,31);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*28.2);
			Block= Level;
			Family=11;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			ManaType=1; BaseMana = 0;

			AttackSpeed = 2000;
			BoundingRadius = 0.69f;
			CombatReach = 0.97f;
			Size = 0.65f;
			Speed = 6f;
			WalkSpeed = 6f;
			RunSpeed = 9f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 1091, 30 );
			SkinLoot = new Loot[] {new Loot( typeof( MediumHide), 0.879044f ) 
,new Loot( typeof( MediumLeather), 16.2096f ) 
,new Loot( typeof( HeavyHide), 0.492264f ) 
,new Loot( typeof( HeavyLeather), 4.25457f ) 
};
			Loots = new BaseTreasure[]{  new BaseTreasure( RaptorDrops.YoungStranglethornRaptor , 100f )
										};
		}
	}
}

