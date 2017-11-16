///////////////////////////////////////////
namespace Server
{
	public class Imp : BaseCreature
	{
		public Imp() : base()
		{
			AttackBonii( 2000, 2000 );
			Size = 0.500000f;
			BoundingRadius = 0.500000f;
			SetDamage( 3.928571, 5.578572 );
			NpcType = 3;
			Model = 4449;
			BaseHitPoints = 48;
			AttackSpeed = 1200;
			Level = RandomLevel( 5, 5 );
			Name = "Imp";
			CombatReach = 1.000000f;
			NpcFlags = 0;
			Flags1 = 0x0100006;
			Unk3 = 23;
			BaseMana = 135;
			RunSpeed = 16f;
			WalkSpeed = 10f;
			Speed = 10.5f;
			Id = 416;
			LearnSpell( 6307, SpellsTypes.Defensive );	
			LearnSpell( 701, SpellsTypes.Offensive );					
		}
	}
}

//	Script made by Sapphiron - 04/06/05 22:11:34
//Script created by Sapphiron, please feel free to do any correction
//File: WarlockSummons.CS 
//June, 04, 2005

namespace Server.Creatures
{
	public class Succubus : BaseCreature
	{
		public Succubus() : base()
		{
			Name = "Succubus";
			Id = 1863;
			Model = 4162;
			Level = RandomLevel(20,20);
			SetDamage(21f,31f);
			AttackSpeed = 2095;
			ResistShadow = 20;
			Armor = 600;
			BaseHitPoints = 862;
			BaseMana = 778;
			BoundingRadius = 1.3f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			NpcType = 3;
		}
	}
}

namespace Server.Creatures
{
	public class EyeOfKilrogg : BaseCreature
	{
		public EyeOfKilrogg() : base()
		{
			Name = "Eye of Kilrogg";
			Id = 4277;
			Model = 2421;
			Level = RandomLevel(23,23);
			SetDamage(24f,36f);
			AttackSpeed = 2115;
			ResistShadow = 20;
			Armor = 690;
			BaseHitPoints = 1006;
			BaseMana = 778;
			BoundingRadius = 1.4f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			NpcType = 3;
		}
	}
}


namespace Server.Creatures
{
	public class Voidwalker : BaseCreature
	{
		public Voidwalker() : base()
		{
			Name = "Voidwalker";
			Id = 1860;
			Model = 1132;
			Level = RandomLevel(15,15);
			SetDamage(16f,24f);
			AttackSpeed = 2000;
			Armor = 450;
			ResistShadow = 15;
			BaseHitPoints = 685;
			BaseMana = 575;
			BoundingRadius = 1.1f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			NpcType = 3;
		}
	}
}


namespace Server.Creatures
{
	public class Felhunter : BaseCreature
	{
		public Felhunter() : base()
		{
			Name = "Felhunter";
			Id = 417;
			Model = 850;
			Level = RandomLevel(15,15);
			SetDamage(120f,140f);
			AttackSpeed = 1600;
			Armor = 1200;
			ResistShadow = 15;
			BaseHitPoints = 1100;
			BaseMana = 1100;
			BoundingRadius = 1.1f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 8f;
			NpcType = 3;
		}
	}
}

namespace Server.Creatures
{
	public class Felsteed : BaseCreature
	{
		public Felsteed() : base()
		{
			Name = "Felsteed";
			Id = 304;
			Model = 2830;
			Level = RandomLevel(1,1);
			SetDamage( 20f, 30f);
			AttackSpeed = 2600;
			Armor = 1200;
			ResistShadow = 15;
			BaseHitPoints = 800;
			BaseMana = 500;
			BoundingRadius = 1.1f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 6f;
			WalkSpeed = 6f;
			RunSpeed = 11f;
			NpcType = 3;
		}
	}
}
namespace Server.Creatures
{
	public class Infernal : BaseCreature
	{
		public Infernal() : base()
		{
			Name = "Infernal";
			Id = 89;
			Model = 169;
			Level = RandomLevel(60,60);
			SetDamage( 250f, 300f);
			AttackSpeed = 2100;
			Armor = 3200;
			ResistShadow = 15;
			BaseHitPoints = 1800;
			BaseMana = 1500;
			BoundingRadius = 1.4f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 6f;
			WalkSpeed = 6f;
			RunSpeed = 11f;
			NpcType = 3;
		}
	}
}


namespace Server.Creatures
{
	public class Warhorse : BaseCreature 
	{ 
		public  Warhorse() : base() 
		{ 
			Id = 9158; 
			Model = 8469;
			AttackSpeed= 2200;			
			BoundingRadius = 1.000f ;
			CombatReach = 0.925f ;
			Name = "Warhorse" ;			
			Size = 1f;
			Speed = 4.9f ;
			WalkSpeed = 4.9f ;
			RunSpeed = 7.9f ;
			BaseMana=0;
			Level = RandomLevel( 1,2 );
			Faction = Factions.Stormwind;							
			//			BaseHitPoints = 1544 ;
			AIEngine = new NonAgressiveAnimalAI( this );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.Stay );
			AIEngine.CustomBehaviours.Add( CustomBehavioursTypes.KeepOrientation );

		}
	}	
}