
using System;
using System.Collections;
using Server;
using Server.Items;

namespace Server.Creatures
{
	public class BlackSlayer : BaseCreature
	{
		public BlackSlayer() : base()
		{
			Id = 5982;
			Model = 10824;
			Name = "Black Slayer";
			Flags1 = 0x010;
			Level = RandomLevel(46,48);
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Armor = (int)(Level*25.2);
			Block = Level;
			ManaType=1; BaseMana = 0;
			BaseMana = 0;
			NpcFlags = 0;
			SetDamage(1f+1.8f*Level,1f+2.5f*Level);
			Family = 7;
			BoundingRadius = 0.1f;
			CombatReach = 1.25f;			
			Size = 1f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;
			Loots = new BaseTreasure[]{ new BaseTreasure( CarrionBirdDrops.BlackSlayer , 100f) };
			BCAddon.Hp( this, 2070, 46 );
		}
	}
}



namespace Server.Creatures
{
	public class Buzzard : BaseCreature
	{
		public Buzzard() : base()
		{
			Id = 2830;
			Model = 1105;
			Name = "Buzzard";
			Flags1 = 0x010;
			Level = RandomLevel(37,39);
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Armor = (int)(Level*25.2);
			Block = Level;
			ManaType=1; BaseMana = 0;
			BaseMana = 0;

			NpcFlags = 0;
			SetDamage(1f+1.8f*Level,1f+2.5f*Level);
			Family = 7;
			BoundingRadius = 0.115f;
			CombatReach = 1.425f;			
			Size = 1.15f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;
			Loots = new BaseTreasure[]{ new BaseTreasure( CarrionBirdDrops.Buzzard , 100f) };
			BCAddon.Hp( this, 1472, 37 );

		}
	}
}




namespace Server.Creatures
{
	public class CarrionHorror : BaseCreature
	{
		public CarrionHorror() : base()
		{
			Id = 4695;
			Model = 10825;
			Name = "Carrion Horror";
			Flags1 = 0x010;
			Level = RandomLevel(35,37);
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Armor = (int)(Level*25.2);
			Block = Level;
			ManaType=1; BaseMana = 0;
			BaseMana = 0;
			NpcFlags = 0;
			SetDamage(1f+1.8f*Level,1f+2.5f*Level);
			Family = 7;
			BoundingRadius = 0.115f;
			CombatReach = 1.425f;			
			Size = 1.15f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;
			Loots = new BaseTreasure[]{ new BaseTreasure( CarrionBirdDrops.CarrionHorror , 100f) };
			BCAddon.Hp( this, 983, 35 );

		}
	}
}


namespace Server.Creatures
{
	public class CarrionVulture : BaseCreature
	{
		public CarrionVulture() : base()
		{
			Id = 1809;
			Model = 1105;
			Name = "Carrion Vulture";
			Flags1 = 0x010;
			Level = RandomLevel(50,52);
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Armor = (int)(Level*25.2);
			Block = Level;
			ManaType=1; BaseMana = 0;
			BaseMana = 0;

			NpcFlags = 0;
			SetDamage(1f+1.8f*Level,1f+2.5f*Level);
			Family = 7;
			BoundingRadius = 0.115f;
			CombatReach = 1.425f;			
			Size = 1.15f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;
			Loots = new BaseTreasure[]{ new BaseTreasure( CarrionBirdDrops.CarrionVulture , 100f) };
			BCAddon.Hp( this, 1974, 50 );

		}
	}
}



namespace Server.Creatures
{
	public class DireCondor : BaseCreature
	{
		public DireCondor() : base()
		{
			Id = 428;
			Model = 490;
			Name = "Dire Condor";
			Flags1 = 0x010;
			Level = RandomLevel(18,19);
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Armor = (int)(Level*25.2);
			Block = Level;
			ManaType=1;
			BaseMana = 100;
			NpcFlags = 0;
			SetDamage(1f+1.8f*Level,1f+2.5f*Level);
			Family = 7;
			BoundingRadius = 0.115f;
			CombatReach = 0.93f;			
			Size = 0.75f;
			Speed = 3.03f;
			WalkSpeed = 3.03f;
			RunSpeed = 6.03f;
			Faction = Factions.Monster;
			AIEngine = new SpellCasterAI( this );
			NpcType = (int)NpcTypes.Beast;
LearnSpell( 5708, SpellsTypes.Offensive );
			Loots = new BaseTreasure[]{ new BaseTreasure( CarrionBirdDrops.DireCondor , 100f) };
			BCAddon.Hp( this, 315, 18 );

		}
	}
}



namespace Server.Creatures
{
	public class DreadFlyer : BaseCreature
	{
		public DreadFlyer() : base()
		{
			Id = 4693;
			Model = 10273;
			Name = "Dread Flyer";
			Flags1 = 0x010;
			Level = RandomLevel(36,37);
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Armor = (int)(Level*25.2);
			Block = Level;
			ManaType=1; BaseMana = 0;
			BaseMana = 0;

			NpcFlags = 0;
			SetDamage(1f+1.8f*Level,1f+2.5f*Level);
			Family = 7;
			BoundingRadius = 0.115f;
			CombatReach =1.43f;			
			Size = 1.15f;
			Speed = 2.8f;
			WalkSpeed = 2.8f;
			RunSpeed = 5.8f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;
			Loots = new BaseTreasure[]{ new BaseTreasure( CarrionBirdDrops.DreadFlyer , 100f) };
			BCAddon.Hp( this, 1537, 36 );

		}
	}
}





namespace Server.Creatures
{
	public class DreadRipper : BaseCreature
	{
		public DreadRipper() : base()
		{
			Id = 4694;
			Model = 14319;
			Name = "Dread Ripper";
			Flags1 = 0x010;
			Level = RandomLevel(39,40);
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Armor = (int)(Level*25.2);
			Block = Level;
			ManaType=1; BaseMana = 0;
			BaseMana = 0;
			NpcFlags = 0;
			SetDamage(1f+1.8f*Level,1f+2.5f*Level);
			Family = 7;
			BoundingRadius = 0.115f;
			CombatReach =1.43f;			
			Size = 1.3f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;
			Loots = new BaseTreasure[]{ new BaseTreasure( CarrionBirdDrops.DreadRipper , 100f) };
			BCAddon.Hp( this, 1537, 39 );

		}
	}
}




namespace Server.Creatures
{
	public class DreadSwoop : BaseCreature
	{
		public DreadSwoop() : base()
		{
			Id = 4692;
			Model = 1192;
			Name = "Dread Swoop";
			Flags1 = 0x010;
			Level = RandomLevel(32,33);
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Armor = (int)(Level*25.2);
			Block = Level;
			ManaType=1; BaseMana = 0;
			BaseMana = 0;

			NpcFlags = 0;
			SetDamage(1f+1.8f*Level,1f+2.5f*Level);
			Family = 7;
			BoundingRadius = 0.115f;
			CombatReach =1.43f;			
			Size = 0.7f;
			Speed = 2.8f;
			WalkSpeed = 2.8f;
			RunSpeed = 5.8f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;
			Loots = new BaseTreasure[]{ new BaseTreasure( CarrionBirdDrops.DreadSwoop , 100f) };
			BCAddon.Hp( this, 1095, 32 );

		}
	}
}



namespace Server.Creatures
{
	public class ElderMesaBuzzard : BaseCreature
	{
		public ElderMesaBuzzard() : base()
		{
			Id = 2580;
			Model = 388;
			Name = "Elder Mesa Buzzard";
			Flags1 = 0x010;
			Level = RandomLevel(37,38);
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Armor = (int)(Level*25.2);
			Block = Level;
			ManaType=1; BaseMana = 0;
			BaseMana = 0;

			NpcFlags = 0;
			SetDamage(1f+1.8f*Level,1f+2.5f*Level);
			Family = 7;
			BoundingRadius = 0.13f;
			CombatReach =1.63f;			
			Size = 1.3f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;
			BCAddon.Hp( this, 1537, 37 );
			Loots = new BaseTreasure[]{ new BaseTreasure( CarrionBirdDrops.ElderMesaBuzzard , 100f) };
		}
	}
}





namespace Server.Creatures
{
	public class FireRoc : BaseCreature
	{
		public FireRoc() : base()
		{
			Id = 5429;
			Model = 7348;
			Name = "Fire Roc";
			Flags1 = 0x010;
			Level = RandomLevel(43,45);
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Armor = (int)(Level*25.2);
			Block = Level;
			ManaType=1; BaseMana = 0;
			BaseMana = 0;
 
			NpcFlags = 0;
			SetDamage(1f+1.8f*Level,1f+2.5f*Level);
			Family = 7;
			BoundingRadius = 0.115f;
			CombatReach =1.43f;			
			Size = 1.15f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;
			BCAddon.Hp( this, 1431, 43 );
			Loots = new BaseTreasure[]{ new BaseTreasure( CarrionBirdDrops.FireRoc , 100f) };
		}
	}
}




namespace Server.Creatures
{
	public class Fleshripper : BaseCreature
	{
		public Fleshripper() : base()
		{
			Id = 1109;
			Model = 2305;
			Name = "Fleshripper";
			Flags1 = 0x010;
			Level = RandomLevel(13,14);
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Armor = (int)(Level*25.2);
			Block = Level;
			ManaType=1;
			BaseMana = 100;

			NpcFlags = 0;
			SetDamage(1f+1.8f*Level,1f+2.5f*Level);
			Family = 7;
			BoundingRadius = 0.1f;
			CombatReach =1.25f;			
			Size = 1.15f;
			Speed = 3.0f;
			WalkSpeed = 3.0f;
			RunSpeed = 6.0f;
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
	LearnSpell( 1604, SpellsTypes.Offensive );
	LearnSpell( 12166, SpellsTypes.Offensive );	
			NpcType = (int)NpcTypes.Beast;
			BCAddon.Hp( this, 267, 13 );
			Loots = new BaseTreasure[]{ new BaseTreasure( CarrionBirdDrops.Fleshripper , 100f) };
		}
	}
}





namespace Server.Creatures
{
	public class GiantBuzzard : BaseCreature
	{
		public GiantBuzzard() : base()
		{
			Id = 2831;
			Model = 1106;
			Name = "Giant Buzzard";
			Flags1 = 0x010;
			Level = RandomLevel(39,41);
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Armor = (int)(Level*25.2);
			Block = Level;
			ManaType=1; BaseMana = 0;
			BaseMana = 0;
			NpcFlags = 0;
			SetDamage(1f+1.8f*Level,1f+2.5f*Level);
			Family = 7;
			BoundingRadius = 0.1f;
			CombatReach =1.25f;			
			Size = 1.5f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;
			BCAddon.Hp( this, 1493, 39 );
			Loots = new BaseTreasure[]{ new BaseTreasure( CarrionBirdDrops.GiantBuzzard , 100f) };
		}
	}
}




namespace Server.Creatures
{
	public class GreaterFirebird : BaseCreature
	{
		public GreaterFirebird() : base()
		{
			Id = 8207;
			Model = 7349;
			Name = "Greater Firebird";
			Flags1 = 0x010;
			Level = RandomLevel(46);
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Armor = (int)(Level*60.8f);
			Block = Level;
			ManaType=1; BaseMana = 0;
			BaseMana = 0; 
			NpcFlags = 0;
			SetDamage(1f+1.8f*Level,1f+2.5f*Level);
			Family = 7;
			BoundingRadius = 0.13f;
			CombatReach =1.625f;			
			Size = 1.5f;
			Speed = 3.0f;
			WalkSpeed = 3.0f;
			RunSpeed = 6.0f;
			Elite = 4;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;
			BCAddon.Hp( this, 2399, 46 );
			Loots = new BaseTreasure[]{ new BaseTreasure( CarrionBirdDrops.GreaterFirebird , 100f) };
		}
	}
}



namespace Server.Creatures
{
	public class GreaterFleshripper : BaseCreature
	{
		public GreaterFleshripper() : base()
		{
			Id = 154;
			Model = 1105;
			Name = "Greater Fleshripper";
			Flags1 = 0x010;
			Level = RandomLevel(16,17);
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Armor = (int)(Level*25.2);
			Block = Level;
			ManaType=1; BaseMana = 0;
			BaseMana = 0;

			NpcFlags = 0;
			SetDamage(1f+1.8f*Level,1f+2.5f*Level);
			Family = 7;
			BoundingRadius = 0.1f;
			CombatReach =1.25f;			
			Size = 1.15f;
			Speed = 3.0f;
			WalkSpeed = 3.0f;
			RunSpeed = 6.0f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;
			BCAddon.Hp( this, 1493, 39 );
			Loots = new BaseTreasure[]{ new BaseTreasure( CarrionBirdDrops.GreaterFleshripper , 100f) };
		}
	}
}





namespace Server.Creatures
{
	public class LordCondar : BaseCreature
	{
		public LordCondar() : base()
		{
			Id = 14268;
			Model = 7349;
			Name = "Lord Condar";
			Flags1 = 0x010;
			Level = RandomLevel(16);
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Armor = (int)(Level*60.8f);
			Block = Level;
			ManaType=1; BaseMana = 0;
			BaseMana = 0;

			NpcFlags = 0;
			SetDamage(1f+1.8f*Level,1f+2.5f*Level);
			Family = 7;
			BoundingRadius = 0.13f;
			CombatReach =1.625f;			
			Size = 1.15f;
			Speed = 3.0f;
			WalkSpeed = 3.0f;
			RunSpeed = 6.0f;
			Elite = 4;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;
			BCAddon.Hp( this, 1399, 16 );
			Loots = new BaseTreasure[]{ new BaseTreasure( CarrionBirdDrops.LordCondar , 100f) };
		}
	}
}




namespace Server.Creatures
{
	public class MesaBuzzard : BaseCreature
	{
		public MesaBuzzard() : base()
		{
			Id = 2579;
			Model = 1105;
			Name = "Mesa Buzzard";
			Flags1 = 0x010;
			Level = RandomLevel(34,35);
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Armor = (int)(Level*25.2);
			Block = Level;
			ManaType=1; BaseMana = 0;
			BaseMana = 0;

			NpcFlags = 0;
			SetDamage(1f+1.8f*Level,1f+2.5f*Level);
			Family = 7;
			BoundingRadius = 0.4325f;
			CombatReach =1.625f;			
			Size = 1.15f;
			Speed = 3.1f;
			WalkSpeed = 3.1f;
			RunSpeed = 6.1f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;
			BCAddon.Hp( this, 1285, 34 );
			Loots = new BaseTreasure[]{ new BaseTreasure( CarrionBirdDrops.MesaBuzzard , 100f) };
		}
	}
}




namespace Server.Creatures
{
	public class MountainBuzzard : BaseCreature
	{
		public MountainBuzzard() : base()
		{
			Id = 1194;
			Model = 410;
			Name = "Mountain Buzzard";
			Flags1 = 0x010;
			Level = RandomLevel(15,16);
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Armor = (int)(Level*25.2);
			Block = Level;
			ManaType=1;
			BaseMana = 100;
 
			NpcFlags = 0;
			SetDamage(1f+1.8f*Level,1f+2.5f*Level);
			Family = 7;
			BoundingRadius = 0.085f;			
			CombatReach =1.0625f;
			Size = 0.85f;
			Speed = 3.0f;
			WalkSpeed = 3.0f;
			RunSpeed = 6.0f;
			Faction = Factions.EvilBeast;
	LearnSpell( 1604, SpellsTypes.Offensive );
	LearnSpell( 8014, SpellsTypes.Offensive );
			AIEngine = new SpellCasterAI( this );
			NpcType = (int)NpcTypes.Beast;
			BCAddon.Hp( this, 337, 15 );
			Loots = new BaseTreasure[]{ new BaseTreasure( CarrionBirdDrops.MountainBuzzard , 100f) };
		}
	}
}




namespace Server.Creatures
{
	public class Roc : BaseCreature
	{
		public Roc() : base()
		{
			Id = 5428;
			Model = 3248;
			Name = "Roc";
			Flags1 = 0x010;
			Level = RandomLevel(41,43);
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Armor = (int)(Level*25.2);
			Block = Level;
			ManaType=1; BaseMana = 0;
			BaseMana = 0;

			NpcFlags = 0;
			SetDamage(1f+1.8f*Level,1f+2.5f*Level);
			Family = 7;
			BoundingRadius = 0.1f;
			CombatReach =1.25f;			
			Size = 1.15f;
			Speed = 3.3f;
			WalkSpeed = 3.3f;
			RunSpeed = 6.3f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;
			BCAddon.Hp( this, 1758, 41 );
			Loots = new BaseTreasure[]{ new BaseTreasure( CarrionBirdDrops.Roc , 100f) };
		}
	}
}



namespace Server.Creatures
{
	public class SaltFlatsScavenger : BaseCreature
	{
		public SaltFlatsScavenger() : base()
		{
			Id = 4154;
			Model = 2305;
			Name = "Salt Flats Scavenger";
			Flags1 = 0x010;
			Level = RandomLevel(30,32);
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Armor = (int)(Level*25.2);
			Block = Level;
			ManaType=1; BaseMana = 0;
			BaseMana = 0;

			NpcFlags = 0;
			SetDamage(1f+1.8f*Level,1f+2.5f*Level);
			Family = 7;
			BoundingRadius = 0.1f;
			CombatReach =1.25f;			
			Size = 1f;
			Speed = 3.1f;
			WalkSpeed = 3.1f;
			RunSpeed = 6.1f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;
			BCAddon.Hp( this, 951, 30 );
			Loots = new BaseTreasure[]{ new BaseTreasure( CarrionBirdDrops.SaltFlatsScavenger , 100f) };
		}
	}
}




namespace Server.Creatures
{
	public class SaltFlatsVulture : BaseCreature
	{
		public SaltFlatsVulture() : base()
		{
			Id = 4158;
			Model = 10825;
			Name = "Salt Flats Vulture";
			Level = RandomLevel(32,34);
			Flags1 = 0x010;
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Armor = (int)(Level*25.2);
			Block = Level;
			ManaType=1; BaseMana = 0;
			BaseMana = 0;
 
			NpcFlags = 0;
			SetDamage(1f+1.8f*Level,1f+2.5f*Level);
			Family = 7;
			BoundingRadius = 0.115f;
			CombatReach =1.43f;			
			Size = 1.15f;
			Speed = 3.1f;
			WalkSpeed = 3.1f;
			RunSpeed = 6.1f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;
			BCAddon.Hp( this, 1137, 32 );
			Loots = new BaseTreasure[]{ new BaseTreasure( CarrionBirdDrops.SaltFlatsVulture , 100f) };
		}
	}
}




namespace Server.Creatures
{
	public class SearingRoc : BaseCreature
	{
		public SearingRoc() : base()
		{
			Id = 5430;
			Model = 10827;
			Name = "Searing Roc";
			Flags1 = 0x010;
			Level = RandomLevel(47,49);
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Armor = (int)(Level*25.2);
			Block = Level;
			ManaType=1; BaseMana = 0;
			BaseMana = 0;
 
			NpcFlags = 0;
			SetDamage(1f+1.8f*Level,1f+2.5f*Level);
			Family = 7;
			BoundingRadius = 0.15f;
			CombatReach =1.875f;			
			Size = 1.5f;
			Speed = 3.3f;
			WalkSpeed = 3.3f;
			RunSpeed = 6.3f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;
			BCAddon.Hp( this, 2555, 47 );
			Loots = new BaseTreasure[]{ new BaseTreasure( CarrionBirdDrops.SearingRoc , 100f) };
		}
	}
}



namespace Server.Creatures
{
	public class Spiteflayer : BaseCreature
	{
		public Spiteflayer() : base()
		{
			Id = 8299;
			Model = 388;
			Name = "Spiteflayer";
			Level = RandomLevel(52);
			Flags1 = 0x010;
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Armor = (int)(Level*60.8f);
			Block = Level;
			ManaType=1; BaseMana = 0;
			BaseMana = 0;

			NpcFlags = 0;
			SetDamage(1f+1.8f*Level,1f+2.5f*Level);
			Family = 7;
			BoundingRadius = 1.0f;
			CombatReach =1.625f;			
			Size = 1f;
			Speed = 3.3f;
			WalkSpeed = 3.3f;
			RunSpeed = 6.3f;
			Elite = 4;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;
			BCAddon.Hp( this, 3082, 52 );
			Loots = new BaseTreasure[]{ new BaseTreasure( CarrionBirdDrops.Spiteflayer , 100f) };
		}
	}
}




namespace Server.Creatures
{
	public class StarvingBuzzard : BaseCreature
	{
		public StarvingBuzzard() : base()
		{
			Id = 2829;
			Model = 10824;
			Name = "Starving Buzzard";
			Level = RandomLevel(35,37);
			Flags1 = 0x010;
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Armor = (int)(Level*25.2);
			Block = Level;
			ManaType=1; BaseMana = 0;
			BaseMana = 0;

			NpcFlags = 0;
			SetDamage(1f+1.8f*Level,1f+2.5f*Level);
			Family = 7;
			BoundingRadius = 0.15f;
			CombatReach =1.25f;			
			Size = 1.5f;
			Speed = 3.1f;
			WalkSpeed = 3.1f;
			RunSpeed = 6.1f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;
			BCAddon.Hp( this, 1238, 35 );
			Loots = new BaseTreasure[]{ new BaseTreasure( CarrionBirdDrops.StarvingBuzzard , 100f) };
		}
	}
}



namespace Server.Creatures
{
	public class Swoop : BaseCreature
	{
		public Swoop() : base()
		{
			Id = 2970;
			Model = 1229;
			Name = "Swoop";
			Level = RandomLevel(7,9);
			Flags1 = 0x010;
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Armor = (int)(Level*25.2);
			Block = Level;
			ManaType=1;
			BaseMana = 100;
 
			NpcFlags = 0;
			SetDamage(1f+1.8f*Level,1f+2.5f*Level);
			Family = 7;
			BoundingRadius = 0.085f;
			CombatReach =1.06f;			
			Size = 0.85f;
			Speed = 3.0f;
			WalkSpeed = 3.0f;
			RunSpeed = 6.0f;
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			NpcType = (int)NpcTypes.Beast;
LearnSpell( 5708, SpellsTypes.Offensive );
BCAddon.Hp( this, 158, 7 );
			Loots = new BaseTreasure[]{ new BaseTreasure( CarrionBirdDrops.Swoop , 100f) };
		}
	}
}



namespace Server.Creatures
{
	public class TalonedSwoop : BaseCreature
	{
		public TalonedSwoop() : base()
		{
			Id = 2971;
			Model = 10824;
			Name = "Taloned Swoop";
			Level = RandomLevel(8,10);
			Flags1 = 0x010;
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Armor = (int)(Level*25.2);
			Block = Level;
			ManaType=1;
			BaseMana = 100;

			NpcFlags = 0;
			SetDamage(1f+1.8f*Level,1f+2.5f*Level);
			Family = 7;
			BoundingRadius = 0.1f;
			CombatReach =1.25f;			
			Size = 0.7f;
			Speed = 2.7f;
			WalkSpeed = 2.7f;
			RunSpeed = 5.7f;
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			NpcType = (int)NpcTypes.Beast;
BCAddon.Hp( this, 213, 8 );
LearnSpell( 5708, SpellsTypes.Offensive );
			Loots = new BaseTreasure[]{ new BaseTreasure( CarrionBirdDrops.TalonedSwoop , 100f) };
		}
	}
}




namespace Server.Creatures
{
	public class Vultros : BaseCreature
	{
		public Vultros() : base()
		{
			Id = 462;
			Model = 14319;
			Name = "Vultros";
			Level = RandomLevel(26);
			Flags1 = 0x010;
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Armor = (int)(Level*60.8);
			Block = Level;
			ManaType=1; BaseMana = 0;
			BaseMana = 0;
 
			NpcFlags = 0;
			SetDamage(1f+1.8f*Level,1f+2.5f*Level);
			Family = 7;
			BoundingRadius = 0.115f;
			CombatReach =1.43f;			
			Size = 1.0f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Elite = 4;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;
			BCAddon.Hp( this, 787, 26 );
			Loots = new BaseTreasure[]{ new BaseTreasure( CarrionBirdDrops.Vultros , 100f) };
		}
	}
}



namespace Server.Creatures
{
	public class WaywardBuzzard : BaseCreature
	{
		public WaywardBuzzard() : base()
		{
			Id = 6013;
			Model = 1105;
			Name = "Wayward Buzzard";
			Level = RandomLevel(35,37);
			Flags1 = 0x016;
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Armor = (int)(Level*25.2);
			Block = Level;
			ManaType=1; BaseMana = 0;
			BaseMana = 0;
			NpcFlags = 0;
			SetDamage(1f+1.8f*Level,1f+2.5f*Level);
			Family = 7;
			BoundingRadius = 0.115f;
			CombatReach =1.43f;			
			Size = 1.15f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Beast;
			AIEngine = new DefensiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;	
			BCAddon.Hp( this, 1213, 35 );		
			Loots = new BaseTreasure[]{ new BaseTreasure( CarrionBirdDrops.WaywardBuzzard , 100f) };
		}
	}
}




namespace Server.Creatures
{
	public class WirySwoop : BaseCreature
	{
		public WirySwoop() : base()
		{
			Id = 2969;
			Model = 1228;
			Name = "Wiry Swoop";
			Level = RandomLevel(5,7);
			Flags1 = 0x010;
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Armor = (int)(Level*25.2);
			Block = Level;
			ManaType=1;
			BaseMana = 100;

			NpcFlags = 0;
			SetDamage(1f+1.8f*Level,1f+2.5f*Level);
			Family = 7;
			BoundingRadius = 0.07f;
			CombatReach =0.875f;			
			Size = 0.7f;
			Speed = 2.9f;
			WalkSpeed = 2.9f;
			RunSpeed = 5.9f;
			Faction = Factions.EvilBeast;
			AIEngine = new SpellCasterAI( this );
			NpcType = (int)NpcTypes.Beast;
LearnSpell( 5708, SpellsTypes.Offensive );
BCAddon.Hp( this, 94, 5 );
			Loots = new BaseTreasure[]{ new BaseTreasure( CarrionBirdDrops.WirySwoop , 100f) };
		}
	}
}



namespace Server.Creatures
{
	public class YoungFleshripper : BaseCreature
	{
		public YoungFleshripper() : base()
		{
			Id = 199;
			Model = 410;
			Name = "Young Fleshripper";
			Level = RandomLevel(10,11);
			Flags1 = 0x010;
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Armor = (int)(Level*25.2);
			Block = Level;
			ManaType=1; BaseMana = 0;
 
			NpcFlags = 0;
			SetDamage(1f+1.8f*Level,1f+2.5f*Level);
			Family = 7;
			BoundingRadius = 0.085f;
			CombatReach =1.0625f;			
			Size = 0.85f;
			Speed = 2.9f;
			WalkSpeed = 2.9f;
			RunSpeed = 5.9f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;
			BCAddon.Hp( this, 168, 10 );
			Loots = new BaseTreasure[]{ new BaseTreasure( CarrionBirdDrops.YoungFleshripper , 100f) };
		}
	}
}




namespace Server.Creatures
{
	public class YoungMesaBuzzard : BaseCreature
	{
		public YoungMesaBuzzard() : base()
		{
			Id = 2578;
			Model = 410;
			Name = "Young Mesa Buzzard";
			Level = RandomLevel(31,32);
			Flags1 = 0x010;
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Armor = (int)(Level*25.2);
			Block = Level;
			ManaType=1; BaseMana = 0;
			BaseMana = 00;

			NpcFlags = 0;
			SetDamage(1f+1.8f*Level,1f+2.5f*Level);
			Family = 7;
			BoundingRadius = 0.085f;
			CombatReach =1.25f;			
			Size = 0.7f;
			Speed = 2.8f;
			WalkSpeed = 2.8f;
			RunSpeed = 5.8f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;
			BCAddon.Hp( this, 1117, 31 );
			Loots = new BaseTreasure[]{ new BaseTreasure( CarrionBirdDrops.YoungMesaBuzzard , 100f) };
		}
	}
}




namespace Server.Creatures
{
	public class Zaricotl : BaseCreature
	{
		public Zaricotl() : base()
		{
			Id = 2931;
			Model = 1210;
			Name = "Zaricotl";
			Level = RandomLevel(55);
			Flags1 = 0x010;
			AttackSpeed = 2000;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Armor = (int)(Level*40.2);
			Block = Level;
			ManaType=1; BaseMana = 0;
			BaseMana = 00;

			NpcFlags = 0;
			SetDamage(1f+7.8f*Level,1f+8.5f*Level);
			Family = 7;
			BoundingRadius = 0.2f;
			CombatReach =2.25f;			
			Size = 2f;
			Speed = 2.1f;
			Elite = 2;
			WalkSpeed = 2.1f;
			RunSpeed = 5.1f;
			Faction = Factions.Beast;
			AIEngine = new DefensiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;
			BCAddon.Hp( this, 3200, 55 );
			Loots = new BaseTreasure[]{ new BaseTreasure( CarrionBirdDrops.Zaricotl , 100f) };
		}
	}
}

