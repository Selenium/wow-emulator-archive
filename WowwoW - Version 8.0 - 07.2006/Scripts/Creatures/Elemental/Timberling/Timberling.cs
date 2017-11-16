// BaseHitPoints from goblinworkshop.com
using System;
using System.Collections;
using Server;
using Server.Items;

namespace Server.Creatures
{
	public class TimberlingTrampler : BaseCreature
	{
		public TimberlingTrampler() : base()
		{
			Name = "Timberling Trampler";
			Id = 2027;
			Model = 3034;
			Level = RandomLevel(8,9);
			SetDamage(1f+1.0f*Level,1f+1.55f*Level);
			Armor = 240;
			BaseHitPoints = 14 + 18 * Level;
			Str = (int)(Level/2.5f);
			AttackSpeed = 2000;
			ResistNature = 15;
			BoundingRadius = 1f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 4f;
			WalkSpeed = 4f;
			RunSpeed = 7f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 4;
			LearnSpell( 15550, SpellsTypes.Offensive); //Trample
			Loots = new BaseTreasure[]{  new BaseTreasure( TimberlingDrops.TimberlingTrampler , 100f ),
			new BaseTreasure(Drops.MoneyA, 100f )};
		}
	}
}

namespace Server.Creatures
{
	public class TimberlingBarkRipper : BaseCreature
	{
		public TimberlingBarkRipper() : base()
		{
			Name = "Timberling Bark Ripper";
			Id = 2025;
			Model = 6817;
			Level = RandomLevel(7,9);
			BaseHitPoints = 300;
			Str = (int)(Level/2.5f);
			SetDamage(1f+1.0f*Level,1f+1.55f*Level);
			Armor = 220;
			AttackSpeed = 2000;
			ResistNature = 15;
			BoundingRadius = 1f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 4f;
			WalkSpeed = 4f;
			RunSpeed = 7f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 4;
			Loots = new BaseTreasure[]{  new BaseTreasure( TimberlingDrops.TimberlingBarkRipper , 100f ),
			new BaseTreasure(Drops.MoneyA, 100f )};
		}
	}
}

namespace Server.Creatures
{
	public class TimberlingMireBeast : BaseCreature
	{
		public TimberlingMireBeast() : base()
		{
			Name = "Timberling Mire Beast";
			Id = 2029;
			Model = 863;
			Level = RandomLevel(9,10);
			BaseHitPoints = 14 + 18 * Level;
			Str = (int)(Level/2.5f);
			SetDamage(1f+1.0f*Level,1f+1.55f*Level);
			Armor = 280;
			AttackSpeed = 2000;
			ResistNature = 20;
			BoundingRadius = 1f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 4f;
			WalkSpeed = 4f;
			RunSpeed = 7f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 4;
			Loots = new BaseTreasure[]{  new BaseTreasure( TimberlingDrops.TimberlingMireBeast , 100f ),
			new BaseTreasure(Drops.MoneyA, 100f )};
		}
	}
}


namespace Server.Creatures
{
	public class Timberling : BaseNPC
	{
		public Timberling() : base()
		{
			Name = "Timberling";
			Id = 2022;
			Model = 3033;
			Level = RandomLevel(5,6);
			BaseHitPoints = 14 + 18 * Level;
			Str = (int)(Level/2.5f);
			SetDamage(1f+1.0f*Level,1f+1.55f*Level);
			Armor = 180;
			AttackSpeed = 2000;
			ResistNature = 10;
			BoundingRadius = 1f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 4f;
			WalkSpeed = 4f;
			RunSpeed = 7f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 4;
			Loots = new BaseTreasure[]{  new BaseTreasure( TimberlingDrops.Timberling , 100f ),
			new BaseTreasure(Drops.MoneyA, 100f )};
		}
	}
}

namespace Server.Creatures
{
	public class ElderTimberling : BaseCreature
	{
		public ElderTimberling() : base()
		{
			Name = "Elder Timberling";
			Id = 2030;
			Model = 3032;
			Level = RandomLevel(10,11);
			BaseHitPoints = 14 + 20 * Level;
			Str = (int)(Level/2.5f);
			SetDamage(1f+1.0f*Level,1f+1.55f*Level);
			Armor = 300;
			AttackSpeed = 2000;
			ResistNature = 30;
			BoundingRadius = 1f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 4f;
			WalkSpeed = 4f;
			RunSpeed = 7f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 4;
			LearnSpell( 12550, SpellsTypes.Defensive); //Lightning Shield 
			Loots = new BaseTreasure[]{  new BaseTreasure( TimberlingDrops.ElderTimberling , 100f ),
			new BaseTreasure(Drops.MoneyA, 100f )};
		}
	}
}
