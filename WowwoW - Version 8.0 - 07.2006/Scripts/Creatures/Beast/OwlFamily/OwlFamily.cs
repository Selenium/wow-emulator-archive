//Script Created by BRDDY311 7/4/05
//Olm the Wise has no loot table on gw, al, or thott
//Stormpike Owl has no entry in creatures.scp

using System;
using System.Collections;
using Server;
using Server.Items;

namespace Server.Creatures
{
	public class IronbeakHunter : BaseCreature
	{
		public IronbeakHunter() : base()
		{
			Id = 7099;
			Model = 10829;
			Name = "Ironbeak Hunter";
			Flags1 = 0x010;
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 20;
			ResistShadow = 0;
			Level = RandomLevel(50,51);
			Armor = (int)(Level*21.2);;
			Block = Level;
			BaseMana = 0;
			ManaType=1;
			NpcFlags = 0;
			SetDamage(1f+1.8f*Level,1f+2.5f*Level);
			Family = 26;
			BoundingRadius = 0.455f;
			CombatReach = 1.95f;			
			Size = 1.3f;
			Speed = 6f;
			WalkSpeed = 6f;
			RunSpeed = 10f;
			Faction = Factions.Beast;
			AIEngine = new DefensiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;
			BCAddon.Hp( this, 2842, 50 );
			Loots = new BaseTreasure[]{ new BaseTreasure( OwlDrops.IronbeakHunter , 100f) };
		}
	}
}

namespace Server.Creatures
{
	public class IronbeakOwl : BaseCreature
	{
		public IronbeakOwl() : base()
		{
			Name = "Ironbeak Owl";
			Id = 7097;
			Model = 4877;
			Level = RandomLevel(48,49);
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Flags1 = 0x010;
			Armor = (int)(Level*21.2);;
			Block = Level;
			BaseMana = 0;
 			ManaType=1;
			NpcFlags = 0;
			SetDamage(1f+1.8f*Level,1f+2.5f*Level);
			Family = 26;
			BoundingRadius = 0.35f;
			CombatReach = 1.5f;
			Size = 1f;
			Speed = 6f;
			WalkSpeed = 6f;
			RunSpeed = 10f;
			Faction = Factions.Beast;
			AIEngine = new DefensiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;
			BCAddon.Hp( this, 1250, 48 );
			Loots = new BaseTreasure[]{ new BaseTreasure( OwlDrops.IronbeakOwl , 100f) };
		}
	}
}

namespace Server.Creatures
{
	public class IronbeakScreecher : BaseCreature
	{
		public IronbeakScreecher() : base()
		{
			Name = "Ironbeak Screecher";
			Id = 7098;
			Model = 10831;
			Level = RandomLevel(52,53);
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Flags1 = 0x010;
			Armor = (int)(Level*21.2);;
			Block = Level;
			BaseMana = 0;
ManaType=1;
			NpcFlags = 0;
			SetDamage(1f+1.8f*Level,1f+2.5f*Level);
			Family = 26;
			BoundingRadius = 0.525f;
			CombatReach = 2.25f;
			Size = 1.5f;
			Speed = 6.6f;
			WalkSpeed = 6.6f;
			RunSpeed = 10.5f;
			Faction = Factions.Beast;
			AIEngine = new DefensiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;
			BCAddon.Hp( this, 2089, 52 );
			Loots = new BaseTreasure[]{ new BaseTreasure( OwlDrops.IronbeakScreecher , 100f) };
		}
	}
}

namespace Server.Creatures
{
	public class OlmTheWise : BaseCreature
	{
		public OlmTheWise() : base()
		{
			Name = "Olm the Wise";
			Id = 14343;
			Model = 10833;
			Level = RandomLevel(52);
			AttackSpeed = 1500;
			ResistArcane = 0;
			ResistFire = 20;
			ResistFrost = 20;
			ResistHoly = 0;
			ResistNature = Level+35;
			ResistShadow = 30;
			Flags1 = 0x010;
			Armor = Level*4;
			Block = Level*2;
			BaseMana = 0;
ManaType=1;
 
			NpcFlags = 0;
			SetDamage(1f+3.8f*Level,1f+4.5f*Level);
			Family = 26;
			BoundingRadius = 1f;
			CombatReach = 1.5f;
			Size = 1f;
			Speed = 6.25f;
			WalkSpeed = 6.25f;
			RunSpeed = 10f;
			Faction = Factions.Beast;
			AIEngine = new DefensiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;
			Elite = 2;
			BCAddon.Hp( this, 5380, 52 );
			Loots = new BaseTreasure[]{ new BaseTreasure( OwlDrops.OlmtheWise , 100f) };
		}
	}
}




namespace Server.Creatures
{
	public class StormpikeOwl : BaseCreature
	{
		public StormpikeOwl() : base()
		{
			Name = "Stormpike Owl";
			Id = 14283;
			Model = 10828;
			Level = RandomLevel(8,9);
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Flags1 = 0x010;
			Armor = (int)(Level*21.2);;
			Block = Level;
			BaseMana = 0;
ManaType=1;
			NpcFlags = 0;
			SetDamage(1f+1.8f*Level,1f+2.5f*Level);
			Family = 26;
			BoundingRadius = 0.40f;
			CombatReach = 1.07f;
			Size = 1.15f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.Alliance;
			AIEngine = new DefensiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;
			BCAddon.Hp( this, 570, 53 );
			Loots = new BaseTreasure[]{ new BaseTreasure( OwlDrops.StrigidHunter , 100f) };
		}
	}
}



namespace Server.Creatures
{
	public class StrigidHunter : BaseCreature
	{
		public StrigidHunter() : base()
		{
			Name = "Strigid Hunter";
			Id = 1997;
			Model = 10830;
			Level = RandomLevel(8,9);
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Flags1 = 0x010;
			Armor = (int)(Level*21.2);;
			Block = Level;
			BaseMana = 0;
ManaType=1;
			NpcFlags = 0;
			SetDamage(1f+1.8f*Level,1f+2.5f*Level);
			Family = 26;
			BoundingRadius = 0.40f;
			CombatReach = 1.07f;
			Size = 1.15f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.Beast;
			AIEngine = new DefensiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;
			BCAddon.Hp( this, 158, 8 );
			Loots = new BaseTreasure[]{ new BaseTreasure( OwlDrops.StrigidHunter , 100f) };
		}
	}
}

namespace Server.Creatures
{
	public class StrigidOwl : BaseCreature
	{
		public StrigidOwl() : base()
		{
			Name = "Strigid Owl";
			Id = 1995;
			Model = 10832;
			Level = RandomLevel(4,5);
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Flags1 = 0x010;
			Armor = (int)(Level*21.2);;
			Block = Level;
			BaseMana = 0;
ManaType=1;
			NpcFlags = 0;
			SetDamage(1f+1.8f*Level,1f+2.5f*Level);
			Family = 26;
			BoundingRadius = 0.30f;
			CombatReach = 1.27f;
			Size = 0.85f;
			Speed = 4f;
			WalkSpeed = 4f;
			RunSpeed = 6f;
			Faction = Factions.Beast;
			AIEngine = new DefensiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;
			BCAddon.Hp( this, 109, 4 );
			Loots = new BaseTreasure[]{ new BaseTreasure( OwlDrops.StrigidOwl , 100f) };
		}
	}
}

namespace Server.Creatures
{
	public class StrigidScreecher : BaseCreature
	{
		public StrigidScreecher() : base()
		{
			Name = "Strigid Screecher";
			Id = 1996;
			Model = 4877;
			Level = RandomLevel(7,8);
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Flags1 = 0x010;
			Armor = (int)(Level*21.2);;
			Block = Level;
			BaseMana = 0;
ManaType=1;

			NpcFlags = 0;
			SetDamage(1f+1.8f*Level,1f+2.5f*Level);
			Family = 26;
			BoundingRadius = 0.35f;
			CombatReach = 1.5f;
			Size = 1f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			Faction = Factions.Beast;
			AIEngine = new DefensiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;
			BCAddon.Hp( this, 149, 8 );
			Loots = new BaseTreasure[]{ new BaseTreasure( OwlDrops.StrigidScreecher , 100f) };
		}
	}
}

namespace Server.Creatures
{
	public class WinterspringOwl : BaseCreature
	{
		public WinterspringOwl() : base()
		{
			Name = "Winterspring Owl";
			Id = 7455;
			Model = 6212;
			Level = RandomLevel(54,56);
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = Level;
			ResistHoly = 0;
			ResistNature = 25;
			ResistShadow = 0;
			Flags1 = 0x010;
			Armor = (int)(Level*21.2);;
			Block = Level;
			BaseMana = 0;
ManaType=1;
 
			NpcFlags = 0;
			SetDamage(1f+1.8f*Level,1f+2.5f*Level);
			Family = 26;
			BoundingRadius = 0.455f;
			CombatReach = 1.95f;
			Size = 1.3f;
			Speed = 6f;
			WalkSpeed = 6f;
			RunSpeed = 9.6f;
			Faction = Factions.Beast;
			AIEngine = new DefensiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;
			BCAddon.Hp( this, 2480, 54 );
			Loots = new BaseTreasure[]{ new BaseTreasure( OwlDrops.WinterspringOwl , 100f) };
		}
	}
}

namespace Server.Creatures
{
	public class WinterspringScreecher : BaseCreature
	{
		public WinterspringScreecher() : base()
		{
			Name = "Winterspring Screecher";
			Id = 7456;
			Model = 10833;
			Level = RandomLevel(54,56);
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = Level;
			ResistHoly = 0;
			ResistNature = 25;
			ResistShadow = 0;
			Flags1 = 0x010;
			Armor = (int)(Level*21.2);;
			Block = Level;
			BaseMana = 0;
ManaType=1;
			NpcFlags = 0;
			SetDamage(1f+1.8f*Level,1f+2.5f*Level);
			Family = 26;
			BoundingRadius = 0.53f;
			CombatReach = 2.25f;
			Size = 1.5f;
			Speed = 6.8f;
			WalkSpeed = 6.8f;
			RunSpeed = 10.8f;
			Faction = Factions.Beast;
			AIEngine = new DefensiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;
			BCAddon.Hp( this, 3899, 54 );
			Loots = new BaseTreasure[]{ new BaseTreasure( OwlDrops.WinterspringScreecher , 100f) };
		}
	}
}
