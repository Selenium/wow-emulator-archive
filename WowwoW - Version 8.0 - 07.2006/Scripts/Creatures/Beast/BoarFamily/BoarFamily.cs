//////////////////////////////////////////////////////////////////////////////
// 
// 			 Boar Family
// Made by Phantom			2005.06.15.
//////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections;
using Server;
using Server.Items;
namespace Server.Creatures
{
	public class CragBoar : BaseCreature
	{
		public CragBoar() : base()
		{
			Name = "Crag Boar";
			Id = 1125;
			Model = 607;
			Level = RandomLevel(5,6);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 1500;
			Armor = Level*30;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 10;
			ResistShadow = 0;
			ManaType=1; BaseMana = 0;
			BaseMana = 220;
			Str = (int)(Level/1.1f);
			BoundingRadius = 1.35f;
			CombatReach = 1.35f;
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.Beast;
			AIEngine = new DefensiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;
			BCAddon.Hp( this, 267, 5 );
			SkinLoot = new Loot[] { new Loot( typeof( RuinedLeatherScraps ), 45f )
						,new Loot( typeof( LightLeather ), 30f )
						,new Loot( typeof( MediumLeather ), 20f )
						,new Loot( typeof( HeavyLeather ), 5f )
									};
			Loots = new BaseTreasure[]{  new BaseTreasure( BoarDrops.CragBoar , 100f )
									};
		}
	}
	public class SmallCragBoar : BaseCreature
	{
		public SmallCragBoar() : base()
		{
			Name = "Small Crag Boar";
			Id = 708;
			Model = 607;
			Level = RandomLevel(3,3);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = Level*30;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;

			ManaType=1; BaseMana = 0;
			Str = (int)(Level/1.1f);
			BoundingRadius = 0.7f;
			CombatReach = 0.7f;
			Size = 0.7f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.Beast;
			AIEngine = new DefensiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;
			BCAddon.Hp( this, 144, 3 );
			//LearnSpell( 15571, SpellsTypes.Offensive );
			SkinLoot = new Loot[] { new Loot( typeof( RuinedLeatherScraps ), 50f )
						,new Loot( typeof( LightLeather ), 35f )
						,new Loot( typeof( MediumLeather ), 10f )
						,new Loot( typeof( HeavyLeather ), 5f )
										};
			Loots = new BaseTreasure[]{  new BaseTreasure( BoarDrops.CragBoar , 100f )
										};
		}
	}

	public class Battleboar : BaseCreature
	{
		public Battleboar() : base()
		{
			Name = "Battleboar";
			Id = 2966;
			Model = 8869;
			Level = RandomLevel(3,4);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = Level*30;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			ManaType=1; BaseMana = 0;
			Str = (int)(Level/1.1f);
			BoundingRadius = 1.35f;
			CombatReach = 1.35f;
			Size = 0.9f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;
			BCAddon.Hp( this, 184, 3 );
			//LearnSpell( 15571, SpellsTypes.Offensive );
			SkinLoot = new Loot[] { new Loot( typeof( RuinedLeatherScraps ), 50f )
						,new Loot( typeof( LightLeather ), 35f )
						,new Loot( typeof( MediumLeather ), 10f )
						,new Loot( typeof( HeavyLeather ), 5f )
										};
			Loots = new BaseTreasure[]{  new BaseTreasure( BoarDrops.BattleBoar , 100f )
										};
		}
	}

	public class BristlebackBattleboar : BaseCreature
	{
		public BristlebackBattleboar() : base()
		{
			Name = "Bristleback Battleboar";
			Id = 2954;
			Model = 6807;
			Level = RandomLevel(4,5);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = Level*30;
			ResistArcane = 5;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 5;
			ResistShadow = 0;
			ManaType=1; BaseMana = 100;
			Str = (int)(Level/1.1f);
			BoundingRadius = 0.94f;
			CombatReach = 1.35f;
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.Monster;
			AIEngine = new SpellCasterAI( this );
			NpcType = (int)NpcTypes.Beast;
LearnSpell( 3385, SpellsTypes.Offensive );
BCAddon.Hp( this, 200, 4 );
			SkinLoot = new Loot[] { new Loot( typeof( RuinedLeatherScraps ), 50f )
						,new Loot( typeof( LightLeather ), 35f )
						,new Loot( typeof( MediumLeather ), 10f )
						,new Loot( typeof( HeavyLeather ), 5f )
								};
			Loots = new BaseTreasure[]{  new BaseTreasure( BoarDrops.BattleBoar , 100f )
										};
		}
	}

	public class DireMottledBoar : BaseCreature
	{
		public DireMottledBoar() : base()
		{
			Name = "Dire Mottled Boar";
			Id = 3099;
			Model = 381;
			Level = RandomLevel(6,7);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = Level*30;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 10;
			ResistShadow = 0;
			ManaType=1; BaseMana = 100;
			Str = (int)(Level/1.1f);
			BoundingRadius = 1.35f;
			CombatReach = 0.9f;
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.Beast;
			AIEngine = new SpellCasterAI( this );
			NpcType = (int)NpcTypes.Beast;
			LearnSpell( 1604, SpellsTypes.Offensive );
			BCAddon.Hp( this, 304, 6 );
			SkinLoot = new Loot[] { new Loot( typeof( RuinedLeatherScraps ), 40f )
						,new Loot( typeof( LightLeather ), 30f )
						,new Loot( typeof( MediumLeather ), 20f )
						,new Loot( typeof( HeavyLeather ), 10f )
										};
			Loots = new BaseTreasure[]{  new BaseTreasure( BoarDrops.MottledBoar , 100f )										};
		}
	}

	public class ElderCragBoar : BaseCreature
	{
		public ElderCragBoar() : base()
		{
			Name = "Elder Crag Boar";
			Id = 1127;
			Model = 744;
			Level = RandomLevel(7,8);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2300;
			Armor = Level*30;
			ResistArcane = 5;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 20;
			ResistShadow = 0;
			ManaType=1; BaseMana = 0;
			Str = (int)(Level/1.1f);
			BoundingRadius = 1.35f;
			CombatReach = 1.35f;
			Size = 1.3f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.Beast;
			AIEngine = new DefensiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;
			BCAddon.Hp( this, 344, 7 );
			//LearnSpell( 15571, SpellsTypes.Offensive );
			SkinLoot = new Loot[] { new Loot( typeof( RuinedLeatherScraps ), 40f )
						,new Loot( typeof( LightLeather ), 30f )
						,new Loot( typeof( MediumLeather ), 20f )
						,new Loot( typeof( HeavyLeather ), 10f )
										};
			Loots = new BaseTreasure[]{  new BaseTreasure( BoarDrops.CragBoar , 100f )
										};
		}
	}

	public class ElderMottledBoar : BaseCreature
	{
		public ElderMottledBoar() : base()
		{
			Name = "Elder Mottled Boar";
			Id = 3100;
			Model = 193;
			Level = RandomLevel(8,9);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2500;
			Armor = Level*30;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 30;
			ResistShadow = 10;
			ManaType=1; BaseMana = 0;
			Str = (int)(Level/1.1f);
			BoundingRadius = 1.35f;
			CombatReach = 1.35f;
			Size = 1.5f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.Beast;
			AIEngine = new DefensiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;
			BCAddon.Hp( this, 384, 8 );
			//LearnSpell( 15571, SpellsTypes.Offensive );
			SkinLoot = new Loot[] { new Loot( typeof( RuinedLeatherScraps ), 40f )
						,new Loot( typeof( LightLeather ), 30f )
						,new Loot( typeof( MediumLeather ), 20f )
						,new Loot( typeof( HeavyLeather ), 10f )
										};
			Loots = new BaseTreasure[]{  new BaseTreasure( BoarDrops.MottledBoar , 100f )
										};
		}
	}

	public class LargeCragBoar : BaseCreature
	{
		public LargeCragBoar() : base()
		{
			Name = "Large Crag Boar";
			Id = 1126;
			Model = 381;
			Level = RandomLevel(6,7);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = Level*30;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 10;
			ResistShadow = 0;
			ManaType=1; BaseMana = 0;
			Str = (int)(Level/1.1f);
			BoundingRadius = 1.35f;
			CombatReach = 1.35f;
			Size = 1.2f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.Beast;
			AIEngine = new DefensiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;
			BCAddon.Hp( this, 367, 6 );
			//LearnSpell( 15571, SpellsTypes.Offensive );
			SkinLoot = new Loot[] { new Loot( typeof( RuinedLeatherScraps ), 40f )
						,new Loot( typeof( LightLeather ), 30f )
						,new Loot( typeof( MediumLeather ), 20f )
						,new Loot( typeof( HeavyLeather ), 10f )
										};
			Loots = new BaseTreasure[]{  new BaseTreasure( BoarDrops.CragBoar , 100f )
										};
		}
	}

	public class Longsnout : BaseCreature
	{
		public Longsnout() : base()
		{
			Name = "Longsnout";
			Id = 119;
			Model = 381;
			Level = RandomLevel(8,9);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = Level*30;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 20;
			ResistShadow = 0;

			ManaType=1; BaseMana = 0;
			Str = (int)(Level/1.1f);
			BoundingRadius = 1.35f;
			CombatReach = 1.35f;
			Size = 1.3f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.Beast;
			AIEngine = new DefensiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;
			BCAddon.Hp( this, 424, 8 );
			//LearnSpell( 15571, SpellsTypes.Offensive );
			SkinLoot = new Loot[] { new Loot( typeof( RuinedLeatherScraps ), 30f )
						,new Loot( typeof( LightLeather ), 30f )
						,new Loot( typeof( MediumLeather ), 30f )
						,new Loot( typeof( HeavyLeather ), 10f )
										};
			Loots = new BaseTreasure[]{  new BaseTreasure( BoarDrops.CragBoar , 100f )
										};
		}
	}

	public class MottledBoar : BaseCreature
	{
		public MottledBoar() : base()
		{
			Name = "Mottled Boar";
			Id = 3098;
			Model = 503;
			Level = RandomLevel(1,2);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = Level*30;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;

			ManaType=1; BaseMana = 100;
			Str = (int)(Level/1.1f);
			BoundingRadius = 1.35f;
			CombatReach = 1.35f;
			Size = 0.8f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.Beast;
			AIEngine = new SpellCasterAI( this );
			NpcType = (int)NpcTypes.Beast;
			LearnSpell( 1604, SpellsTypes.Offensive );
			BCAddon.Hp( this, 70, 1 );
			SkinLoot = new Loot[] { new Loot( typeof( RuinedLeatherScraps ), 50f )
						,new Loot( typeof( LightLeather ), 35f )
						,new Loot( typeof( MediumLeather ), 10f )
						,new Loot( typeof( HeavyLeather ), 5f )
										};
			Loots = new BaseTreasure[]{  new BaseTreasure( BoarDrops.MottledBoar , 100f )
										};
		}
	}

	public class MountainBoar : BaseCreature
	{
		public MountainBoar() : base()
		{
			Name = "Mountain Boar";
			Id = 1190;
			Model = 704;
			Level = RandomLevel(10,11);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2300;
			Armor = Level*30;
			ResistArcane = 5;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 35;
			ResistShadow = 10;

			ManaType=1; BaseMana = 0;
			Str = (int)(Level/1.1f);
			BoundingRadius = 1.35f;
			CombatReach = 1.35f;
			Size = 1.3f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.Beast;
			AIEngine = new DefensiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;
			BCAddon.Hp( this, 464, 10 );
			//LearnSpell( 15571, SpellsTypes.Offensive );
			SkinLoot = new Loot[] { new Loot( typeof( RuinedLeatherScraps ), 25f )
						,new Loot( typeof( LightLeather ), 30f )
						,new Loot( typeof( MediumLeather ), 30f )
						,new Loot( typeof( HeavyLeather ), 15f )
										};
			Loots = new BaseTreasure[]{  new BaseTreasure( BoarDrops.MountainBoar , 100f )
										};
		}
	}

	public class RockhideBoar : BaseCreature
	{
		public RockhideBoar() : base()
		{
			Name = "Rockhide Boar";
			Id = 524;
			Model = 389;
			Level = RandomLevel(7,8);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = Level*30;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 20;
			ResistShadow = 0;

			ManaType=1; BaseMana = 0;
			Str = (int)(Level/1.1f);
			BoundingRadius = 1.35f;
			CombatReach = 1.35f;
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.Beast;
			AIEngine = new DefensiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;
			BCAddon.Hp( this, 344, 7 );
			//LearnSpell( 15571, SpellsTypes.Offensive );
			SkinLoot = new Loot[] { new Loot( typeof( RuinedLeatherScraps ), 35f )
						,new Loot( typeof( LightLeather ), 30f )
						,new Loot( typeof( MediumLeather ), 25f )
						,new Loot( typeof( HeavyLeather ), 10f )
										};
			Loots = new BaseTreasure[]{  new BaseTreasure( BoarDrops.StoneTuskBoar , 100f )
										};
		}
	}

	public class StonetuskBoar : BaseCreature
	{
		public StonetuskBoar() : base()
		{
			Name = "Stonetusk Boar";
			Id = 113;
			Model = 503;
			Level = RandomLevel(5,6);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = Level*30;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 20;
			ResistShadow = 0;

			ManaType=1; BaseMana = 0;
			Str = (int)(Level/1.1f);
			BoundingRadius = 1.35f;
			CombatReach = 1.35f;
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.Beast;
			AIEngine = new DefensiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;
			BCAddon.Hp( this, 267, 5 );
			//LearnSpell( 15571, SpellsTypes.Offensive );
			SkinLoot = new Loot[] { new Loot( typeof( RuinedLeatherScraps ), 40f )
						,new Loot( typeof( LightLeather ), 30f )
						,new Loot( typeof( MediumLeather ), 20f )
						,new Loot( typeof( HeavyLeather ), 10f )
										};
			Loots = new BaseTreasure[]{  new BaseTreasure( BoarDrops.StoneTuskBoar , 100f )
										};
		}
	}

	public class YoungThistleBoar : BaseCreature
	{
		public YoungThistleBoar() : base()
		{
			Name = "Young Thistle Boar";
			Id = 1984;
			Model = 8869;
			Level = RandomLevel(1,2);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = Level*30;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;

			ManaType=1; BaseMana = 0;
			Str = (int)(Level/1.1f);
			BoundingRadius = 1.35f;
			CombatReach = 1.35f;
			Size = 0.7f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.Beast;
			AIEngine = new DefensiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;
			BCAddon.Hp( this, 64, 1 );
			//LearnSpell( 15571, SpellsTypes.Offensive );
			SkinLoot = new Loot[] { new Loot( typeof( RuinedLeatherScraps ), 50f )
						,new Loot( typeof( LightLeather ), 35f )
						,new Loot( typeof( MediumLeather ), 10f )
						,new Loot( typeof( HeavyLeather ), 5f )
										};
			Loots = new BaseTreasure[]{  new BaseTreasure( BoarDrops.ThistleBoar , 100f )
										};
		}
	}

	public class ThistleBoar : BaseCreature
	{
		public ThistleBoar() : base()
		{
			Name = "Thistle Boar";
			Id = 1985;
			Model = 6807;
			Level = RandomLevel(3,4);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = Level*30;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 10;
			ResistShadow = 0;

			ManaType=1; BaseMana = 0;
			Str = (int)(Level/1.1f);
			BoundingRadius = 1.35f;
			CombatReach = 1.35f;
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.Beast;
			AIEngine = new DefensiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;	
			BCAddon.Hp( this, 144, 3 );
			//LearnSpell( 15571, SpellsTypes.Offensive );
			SkinLoot = new Loot[] { new Loot( typeof( RuinedLeatherScraps ), 40f )
						,new Loot( typeof( LightLeather ), 30f )
						,new Loot( typeof( MediumLeather ), 20f )
						,new Loot( typeof( HeavyLeather ), 10f )
										};
			Loots = new BaseTreasure[]{  new BaseTreasure( Drops.ThistleBoar , 100f )
										};
		}
	}

//*******  New Creatures:  *****************************************

	public class AshmaneBoar : BaseCreature
	{
		public AshmaneBoar() : base()
		{
			Name = "Ashmane Boar";
			Id = 5992;
			Model = 3026;
			Level = RandomLevel(46,47);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = Level*30;
			ResistArcane = 40;
			ResistFire = 20;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 200;
			ResistShadow = 30;

			ManaType=1; BaseMana = 0;
			Str = (int)(Level/1.1f);
			BoundingRadius = 1.76f;
			CombatReach = 1.76f;
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;
			BCAddon.Hp( this, 1945, 46 );
			//LearnSpell( 15571, SpellsTypes.Offensive );
			SkinLoot = new Loot[] { new Loot( typeof( MediumLeather ), 40f )
						,new Loot( typeof( HeavyLeather ), 35f )
						,new Loot( typeof( ThickLeather ), 20f )
						,new Loot( typeof( RuggedLeather ), 5f )
										};
			Loots = new BaseTreasure[]{  new BaseTreasure( BoarDrops.AshmaneBoar , 100f )
										};
		}
	}

	public class Bellygrub : BaseCreature
	{
		public Bellygrub() : base()
		{
			Name = "Bellygrub";
			Id = 345;
			Model = 703;
			Level = RandomLevel(23,24);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = Level*30;
			ResistArcane = 10;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 100;
			ResistShadow = 10;

			ManaType=1; BaseMana = 100;
			Str = (int)(Level/1.1f);
			BoundingRadius = 1.53f;
			CombatReach = 1.53f;
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.Monster;
			AIEngine = new SpellCasterAI( this );
			NpcType = (int)NpcTypes.Beast;
LearnSpell( 5568, SpellsTypes.Offensive );
LearnSpell( 8260, SpellsTypes.Offensive );
LearnSpell( 1604, SpellsTypes.Offensive );
			BCAddon.Hp( this, 904, 23 );
			SkinLoot = new Loot[] { new Loot( typeof( LightLeather ), 40f )
						,new Loot( typeof( MediumLeather ), 20f )
						,new Loot( typeof( HeavyLeather ), 35f )
										};
			Loots = new BaseTreasure[]{  new BaseTreasure( BoarDrops.Bellygrub , 100f )
										};
		}
	}

	public class CorruptedMottledBoar : BaseCreature
	{
		public CorruptedMottledBoar() : base()
		{
			Name = "Corrupted Mottled Boar";
			Id = 3225;
			Model = 744;
			Level = RandomLevel(10,11);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = Level*30;
			ResistArcane = 0;
			ResistFire = 10;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 30;
			ResistShadow = 0;

			ManaType=1; BaseMana = 0;
			Str = (int)(Level/1.1f);
			BoundingRadius = 1.17f;
			CombatReach = 1.17f;
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;
			BCAddon.Hp( this, 424, 10 );
			//LearnSpell( 15571, SpellsTypes.Offensive );
			SkinLoot = new Loot[] { new Loot( typeof( RuinedLeatherScraps ), 25f )
						,new Loot( typeof( LightLeather ), 30f )
						,new Loot( typeof( MediumLeather ), 30f )
						,new Loot( typeof( HeavyLeather ), 15f )
										};
			Loots = new BaseTreasure[]{  new BaseTreasure( BoarDrops.MottledBoar , 100f )
										};
		}
	}

	public class Agamar : BaseCreature
	{
		public Agamar() : base()
		{
			Name = "Agam'ar";
			Id = 4511;
			Model = 4713;
			Level = RandomLevel(24,25);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = Level*30;
			ResistArcane = 20;
			ResistFire = 30;
			ResistFrost = 10;
			ResistHoly = 10;
			ResistNature = 150;
			ResistShadow = 20;

			ManaType=1; BaseMana = 0;
			Str = (int)(Level/1.1f);
			BoundingRadius = 1.17f;
			CombatReach = 1.17f;
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Elite = 1;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;
			BCAddon.Hp( this, 1050, 24 );
			//LearnSpell( 15571, SpellsTypes.Offensive );
			SkinLoot = new Loot[] { new Loot( typeof( LightLeather ), 50f )
						,new Loot( typeof( MediumLeather ), 35f )
						,new Loot( typeof( HeavyLeather ), 15f )
										};
			Loots = new BaseTreasure[]{  new BaseTreasure( BoarDrops.Agamar , 100f )
										};
		}
	}

	public class ElderMountainBoar : BaseCreature
	{
		public ElderMountainBoar() : base()
		{
			Name = "Elder Mountain Boar";
			Id = 1192;
			Model = 1208;
			Level = RandomLevel(15,16);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = Level*30;
			ResistArcane = 20;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 60;
			ResistShadow = 10;

			ManaType=1; BaseMana = 0;
			Str = (int)(Level/1.1f);
			BoundingRadius = 1.17f;
			CombatReach = 1.17f;
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.Beast;
			AIEngine = new DefensiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;
			BCAddon.Hp( this, 570, 15 );
			//LearnSpell( 15571, SpellsTypes.Offensive );
			SkinLoot = new Loot[] { new Loot( typeof( RuinedLeatherScraps ), 25f )
						,new Loot( typeof( LightLeather ), 35f )
						,new Loot( typeof( MediumLeather ), 25f )
						,new Loot( typeof( HeavyLeather ), 15f )
										};
			Loots = new BaseTreasure[]{  new BaseTreasure( BoarDrops.MountainBoar , 100f )
										};
		}
	}

	public class Goretusk : BaseCreature
	{
		public Goretusk() : base()
		{
			Name = "Goretusk";
			Id = 157;
			Model = 3027;
			Level = RandomLevel(12,13);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = Level*30;
			ResistArcane = 10;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 40;
			ResistShadow = 10;
			ManaType=1; BaseMana = 100;
			Str = (int)(Level/1.1f);
			BoundingRadius = 1.17f;
			CombatReach = 1.17f;
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.Beast;
			AIEngine = new SpellCasterAI( this );
			NpcType = (int)NpcTypes.Beast;
			LearnSpell( 6268, SpellsTypes.Offensive );
			BCAddon.Hp( this, 490, 12 );
			SkinLoot = new Loot[] { new Loot( typeof( RuinedLeatherScraps ), 40f )
						,new Loot( typeof( LightLeather ), 30f )
						,new Loot( typeof( MediumLeather ), 20f )
						,new Loot( typeof( HeavyLeather ), 10f )
										};
			Loots = new BaseTreasure[]{  new BaseTreasure( BoarDrops.Goretusk , 100f )
										};
		}
	}

	public class Grunter : BaseCreature
	{
		public Grunter() : base()
		{
			Name = "Grunter";
			Id = 8303;
			Model = 381;
			Level = 50;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = Level*30;
			ResistArcane = 30;
			ResistFire = 40;
			ResistFrost = 10;
			ResistHoly = 0;
			ResistNature = 230;
			ResistShadow = 60;
			ManaType=1; BaseMana = 0;
			BaseMana = 0;
			Str = (int)(Level/1.1f);
			BoundingRadius = 0.61f;
			CombatReach = 0.61f;
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;
			BCAddon.Hp( this, 2360, 50 );
			SkinLoot = new Loot[] { new Loot( typeof( ThickLeather ), 30f )
						,new Loot( typeof( RuggedLeather ), 20f )
						,new Loot( typeof( ChimeraLeather ), 10f )
						,new Loot( typeof( HeavyLeather ), 40f )
										};
			Loots = new BaseTreasure[]{  new BaseTreasure( BoarDrops.Grunter , 100f )
										};
		}
	}

	public class MangyMountainBoar : BaseCreature
	{
		public MangyMountainBoar() : base()
		{
			Name = "Mangy Mountain Boar";
			Id = 1191;
			Model = 3027;
			Level = RandomLevel(13,14);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = Level*30;
			ResistArcane = 10;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 40;
			ResistShadow = 10;
			ManaType=1; BaseMana = 0;
			Str = (int)(Level/1.1f);
			BoundingRadius = 1.17f;
			CombatReach = 1.17f;
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.Beast;
			AIEngine = new DefensiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;
			BCAddon.Hp( this, 520, 13 );
			SkinLoot = new Loot[] { new Loot( typeof( RuinedLeatherScraps ), 40f )
						,new Loot( typeof( LightLeather ), 30f )
						,new Loot( typeof( MediumLeather ), 20f )
						,new Loot( typeof( HeavyLeather ), 10f )
										};
			Loots = new BaseTreasure[]{  new BaseTreasure( BoarDrops.MountainBoar , 100f )
										};
		}
	}

	public class Princess : BaseCreature
	{
		public Princess() : base()
		{
			Name = "Princess";
			Id = 330;
			Model = 8871;
			Level = RandomLevel(7,8);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 1500;
			Armor = Level*30;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 15;
			ResistShadow = 0;
			ManaType=1; BaseMana = 0;
			Str = (int)(Level/1.1f);
			BoundingRadius = 0.88f;
			CombatReach = 0.88f;
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.Beast;
			AIEngine = new DefensiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;
			BCAddon.Hp( this, 370, 7 );
			SkinLoot = new Loot[] { new Loot( typeof( RuinedLeatherScraps ), 45f )
						,new Loot( typeof( LightLeather ), 30f )
						,new Loot( typeof( MediumLeather ), 20f )
						,new Loot( typeof( HeavyLeather ), 5f )
										};
			Loots = new BaseTreasure[]{  new BaseTreasure( BoarDrops.Princess , 100f )
										};
		}
	}

	public class RagingAgamar : BaseCreature
	{
		public RagingAgamar() : base()
		{
			Name = "Raging Agam'ar";
			Id = 4514;
			Model = 2453;
			Level = RandomLevel(25,26);
			SetDamage(1f+2.8f*Level,1f+3.5*Level);
			AttackSpeed = 2000;
			Armor = Level*30;
			ResistArcane = 20;
			ResistFire = 30;
			ResistFrost = 10;
			ResistHoly = 10;
			ResistNature = 160;
			ResistShadow = 20;
			ManaType=1; BaseMana = 0;
			BaseMana = 0;
			Str = (int)(Level/1.1f);
			BoundingRadius = 1.00f;
			CombatReach = 1.00f;
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Elite = 1;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;
			BCAddon.Hp( this, 1150, 25 );
			SkinLoot = new Loot[] { new Loot( typeof( LightLeather ), 45f )
						,new Loot( typeof( MediumLeather ), 35f )
						,new Loot( typeof( HeavyLeather ), 20f )
										};
			Loots = new BaseTreasure[]{  new BaseTreasure( BoarDrops.Agamar , 100f )
										};
		}
	}

	public class RottingAgamar : BaseCreature
	{
		public RottingAgamar() : base()
		{
			Name = "Rotting Agam'ar";
			Id = 4512;
			Model = 4714;
			Level = 28;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = Level*30;
			ResistArcane = 20;
			ResistFire = 30;
			ResistFrost = 10;
			ResistHoly = 10;
			ResistNature = 170;
			ResistShadow = 20;

			ManaType=1; BaseMana = 0;
			Str = (int)(Level/1.1f);
			BoundingRadius = 1.00f;
			CombatReach = 1.00f;
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Elite = 1;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;
			BCAddon.Hp( this, 1250, 28 );
			SkinLoot = new Loot[] { new Loot( typeof( MediumLeather ), 70f )
						,new Loot( typeof( HeavyLeather ), 30f )
										};
			Loots = new BaseTreasure[]{  new BaseTreasure( BoarDrops.Agamar , 100f )
										};
		}
	}

	public class PorcineEntourage : BaseCreature
	{
		public PorcineEntourage() : base()
		{
			Name = "Porcine Entourage";
			Id = 390;
			Model = 377;
			Level = RandomLevel(6,7);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = Level*30;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 20;
			ResistShadow = 0;
			ManaType=1; BaseMana = 0;
			BaseMana = 0;
			Str = (int)(Level/1.1f);
			BoundingRadius = 1.1f;
			CombatReach = 1.1f;
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.Beast;
			AIEngine = new DefensiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;
			BCAddon.Hp( this, 314, 6 );
			SkinLoot = new Loot[] { new Loot( typeof( RuinedLeatherScraps ), 40f )
						,new Loot( typeof( LightLeather ), 30f )
						,new Loot( typeof( MediumLeather ), 20f )
						,new Loot( typeof( HeavyLeather ), 10f )
										};
			Loots = new BaseTreasure[]{  new BaseTreasure( BoarDrops.PorcineEntourage , 100f )										};
		}
	}

	public class ScarredCragBoar : BaseCreature
	{
		public ScarredCragBoar() : base()
		{
			Name = "Elder Crag Boar";
			Id = 1689;
			Model = 193;
			Level = RandomLevel(7,8);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2300;
			Armor = Level*30;
			ResistArcane = 5;
			ResistFire = 0;
			ResistFrost = 20;
			ResistHoly = 0;
			ResistNature = 10;
			ResistShadow = 0;
			ManaType=1; BaseMana = 0;
			Str = (int)(Level/1.1f);
			BoundingRadius = 1.17f;
			CombatReach = 1.17f;
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.Beast;
			AIEngine = new DefensiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;
			BCAddon.Hp( this, 344, 7 );
			SkinLoot = new Loot[] { new Loot( typeof( RuinedLeatherScraps ), 40f )
						,new Loot( typeof( LightLeather ), 30f )
						,new Loot( typeof( MediumLeather ), 20f )
						,new Loot( typeof( HeavyLeather ), 10f )
										};
			Loots = new BaseTreasure[]{  new BaseTreasure( BoarDrops.CragBoar , 100f )
										};
		}
	}

	public class TamedBattleboar : BaseCreature
	{
		public TamedBattleboar() : base()
		{
			Name = "Tamed Battleboar";
			Id = 4535;
			Model = 4713;
			Level = RandomLevel(24,25);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = Level*30;
			ResistArcane = 20;
			ResistFire = 30;
			ResistFrost = 10;
			ResistHoly = 10;
			ResistNature = 150;
			ResistShadow = 20;
			ManaType=1; BaseMana = 0;
			Str = (int)(Level/1.1f);
			BoundingRadius = 1.0f;
			CombatReach = 1.0f;
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Elite = 1;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;
			BCAddon.Hp( this, 1050, 24 );
			SkinLoot = new Loot[] { new Loot( typeof( LightLeather ), 50f )
						,new Loot( typeof( MediumLeather ), 35f )
						,new Loot( typeof( HeavyLeather ), 15f )
										};
			Loots = new BaseTreasure[]{  new BaseTreasure( BoarDrops.TamedBattleboar , 100f )
										};
		}
	}

	public class YoungGoretusk : BaseCreature
	{
		public YoungGoretusk() : base()
		{
			Name = "Young Goretusk";
			Id = 454;
			Model = 8871;
			Level = RandomLevel(9,10);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = Level*30;
			ResistArcane = 10;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 30;
			ResistShadow = 0;
			ManaType=1; BaseMana = 0;
			Str = (int)(Level/1.1f);
			BoundingRadius = 0.88f;
			CombatReach = 0.88f;
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Faction = Factions.Beast;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast;
			BCAddon.Hp( this, 384, 9 );
			SkinLoot = new Loot[] { new Loot( typeof( RuinedLeatherScraps ), 30f )
						,new Loot( typeof( LightLeather ), 30f )
						,new Loot( typeof( MediumLeather ), 30f )
						,new Loot( typeof( HeavyLeather ), 10f )
										};
			Loots = new BaseTreasure[]{  new BaseTreasure( BoarDrops.Goretusk , 100f )
										};
		}
	}


}
