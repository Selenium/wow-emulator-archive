using System;
using Server.Items;

////////////////////// Scarlet.cs
namespace Server.Creatures
{
	public class ScarletAbbot: BaseCreature
	{
		public ScarletAbbot() : base()
		{
			Name = "Scarlet Abbot";
			Id = 4303;
			Model = 2492;
			Level = RandomLevel(39,40);
			SetDamage(1f+2.88f*Level,1f+3.1*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;
			Block = 0;
			Flags1=0x080000;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 10;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.3077550f;
			CombatReach = 0.300f;
			Speed = 3.5f;
			WalkSpeed = 3.5f;
			RunSpeed = 6.5f;
			Faction = Factions.Monster;
			AIEngine = new BerserkerAI( this );
			NpcType = 7;	
			Elite=1; //elite
			Equip(new FightClub());			
			Loots = new BaseTreasure[]{  new BaseTreasure( ScarletDrops.ScarletAbbot, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )};
			/*****************************/
			BCAddon.Hp( this, 2488, 39 );
			/*****************************/			
		}
	}
}

////////////////////// Scarlet.cs
namespace Server.Creatures
{
	public class ScarletAdept: BaseCreature
	{
		public ScarletAdept() : base()
		{
			Name = "Scarlet Adept";
			Id = 4296;
			Model = 5725;
			Level = RandomLevel(33,34);
			SetDamage(1f+2.88f*Level,1f+3.1*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;
			Block = 0;
			Flags1=0x080000;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 10;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.2077550f;
			CombatReach = 0.300f;
			Speed = 3.5f;
			WalkSpeed = 3.5f;
			RunSpeed = 7.0f;
			Faction = Factions.Monster;
			AIEngine = new BerserkerAI( this );
			NpcType = 7;	
			Elite=1; //elite
			Equip( new Item( 1600, InventoryTypes.TwoHanded, 10, 2, 17, 2, 0, 0, 0 ) ); 		
			Loots = new BaseTreasure[]{  new BaseTreasure( ScarletDrops.ScarletAdept, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )};			
			/*****************************/
			BCAddon.Hp( this, 2120, 33 );
			/*****************************/
		}
	}
}

namespace Server.Creatures
{
	public class ScarletArchmage: BaseCreature
	{
		public ScarletArchmage() : base()
		{
			Name = "Scarlet Archmage";
			Id = 9451;
			Model = 10413;
			Level = RandomLevel(55,57);
			SetDamage(1f+2.88f*Level,1f+3.1*Level);			
			AttackSpeed = 2000;
			Armor = 100*Level;
			Block = 0;
			ResistArcane = 10;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.2077550f;
			CombatReach = 1.300f;
			Speed = 3.2f;
			WalkSpeed =3.2f;
			RunSpeed = 7.0f;
			Faction = Factions.Monster;
			AIEngine = new GroupInteligentSpellCasterAI( this );
			NpcType = 7;	
			Elite=1; //elite			
			Loots = new BaseTreasure[]{  new BaseTreasure( ScarletDrops.ScarletArchmage, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )};			
			/*****************************/
			BCAddon.Hp( this, 2120, 55 );
			/*****************************/	
		}
	}
}

namespace Server.Creatures
{
	public class ScarletAugur: BaseCreature
	{
		public ScarletAugur() : base()
		{
			Name = "Scarlet Augur";
			Id = 4284;
			Model = 2496;
			Level = RandomLevel(30,31);
			SetDamage(1f+2.88f*Level,1f+3.1*Level);			
			AttackSpeed = 2000;
			Armor = 100*Level;
			Block = 0;
			ResistArcane = 10;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 10;
			Str = (int)(Level/1.5f);			
			BoundingRadius = 0.2077550f;
			CombatReach = 1.300f;
			Speed = 2.50f;
			WalkSpeed = 2.5f;
			RunSpeed = 6.5f;
			Faction = Factions.Monster;
			AIEngine = new GroupInteligentSpellCasterAI( this );
			NpcType = 7;	
			Elite=1; //elite
			Equip( new Item( 5098, InventoryTypes.TwoHanded, 10, 2, 17, 2, 0, 0, 0 ) ); 			
			Loots = new BaseTreasure[]{  new BaseTreasure( ScarletDrops.ScarletAugur, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )};			
			/*****************************/
			BCAddon.Hp( this, 1443, 30 );
			/*****************************/
		}
	}
}

namespace Server.Creatures
{
	public class ScarletAvenger: BaseCreature
	{
		public ScarletAvenger() : base()
		{
			Name = "Scarlet Avenger";
			Id = 4493;
			Model = 10298;
			Level = RandomLevel(56,57);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;
			Block = 5;
			ResistArcane = 10;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);			
			BoundingRadius = 0.2077550f;
			CombatReach = 0.500f;
			Speed = 3.50f;
			WalkSpeed = 3.5f;
			RunSpeed = 6.5f;
			Faction = Factions.Monster;
			AIEngine = new DefensiveAnimalAI( this );
			NpcType = 7;	
			Unk3=1; 
			Equip( new Item( 23448, InventoryTypes.OneHand, 4, 2, 13, 3, 0, 0, 0 ) , new Item( 23448, InventoryTypes.OneHand, 4, 2, 13, 3, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure( ScarletDrops.ScarletAvenger, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};						
			/*****************************/
			BCAddon.Hp( this, 1831, 56 );
			/*****************************/
		}
	}
}

namespace Server.Creatures
{
	public class ScarletBeastmaster: BaseCreature
	{
		public ScarletBeastmaster() : base()
		{
			Name = "Scarlet Beastmaster";
			Id = 4288;
			Model = 2498;
			Level = RandomLevel(34,35);
			SetDamage(1f+2.88f*Level,1f+3.1*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;
			Block = 0;
			ResistArcane = 10;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 10;
			Str = (int)(Level/1.5f);			
			BoundingRadius = 0.306700f;
			CombatReach = 1.300f;
			Speed = 3.50f;
			WalkSpeed = 3.5f;
			RunSpeed = 7.4f;
			Faction = Factions.Monster;
			AIEngine = new DefensiveAnimalAI( this );
			NpcType = 7;	
			Elite=1; //elite
			Equip( new Item( 7426, InventoryTypes.OneHand, 0, 1, 13, 3, 0, 0, 0 ),  new Item( 6232, InventoryTypes.Ranged, 2, 2, 15, 2, 0, 0, 0 ));			
			Loots = new BaseTreasure[]{  new BaseTreasure( ScarletDrops.ScarletBeastmaster, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )};						
			/*****************************/
			BCAddon.Hp( this, 1756, 34 );
			/*****************************/
		}
	}
}

namespace Server.Creatures
{
	public class ScarletBodyguard: BaseCreature
	{
		public ScarletBodyguard() : base()
		{
			Name = "Scarlet Bodyguard";
			Id = 1660;
			Model = 3145;
			Level = RandomLevel(8);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Str = (int)(Level/2.5f);			
			Armor = 5*Level;
			Block = 5;
			Flags1=0x080000;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = 128;
			BaseMana = 0;
			BoundingRadius = 0.2080f;
			CombatReach = 0.900f;
			Speed = 3.50f;
			WalkSpeed = 3.5f;
			RunSpeed = 7.0f;
			Faction = Factions.Monster;
			AIEngine = new DefensiveAnimalAI( this );
			NpcType = 7;	
			Unk3=1; 
			Equip( new Item( 7483, InventoryTypes.OneHand, 7, 1, 13, 3, 0, 0, 0 ), new Item( 1705, InventoryTypes.Shield, 6, 1, 14, 4, 0, 0, 0 )  ); 			
			Loots = new BaseTreasure[]{  new BaseTreasure( ScarletDrops.ScarletBodyguard, 100f ),
							new BaseTreasure(Drops.MoneyA, 100f )};						
		}
	}
}

//Scarlet Cavalier is not ready i canf find information (model and etc)


namespace Server.Creatures
{
	public class ScarletChampion: BaseCreature
	{
		public ScarletChampion() : base()
		{
			Name = "Scarlet Champion";
			Id = 3975;
			Model = 2041;
			Level = RandomLevel(39,40);
			SetDamage(1f+2.88f*Level,1f+3.1*Level);			
			AttackSpeed = 2500;
			Armor = 150*Level;
			Block = Level-5;
			Flags1=0x080000;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);			
			Size=1.300000f;
			BoundingRadius = 0.396700f;
			CombatReach = 1.300f;
			Speed = 3.8f;
			WalkSpeed = 3.8f;
			RunSpeed = 6.4f;
			Faction = Factions.Monster;
			AIEngine = new EvilInteligentMonsterAI( this );
			NpcType = 7;	
			Elite=1; //elite
			Equip( new Item( 15576, InventoryTypes.TwoHanded, 1, 1, 17, 1, 0, 0, 0 ) ); 
			Guild = "The Scarlet Champion";
			Loots = new BaseTreasure[]{  new BaseTreasure( ScarletDrops.ScarletChampion, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )};						
			/*****************************/
			BCAddon.Hp( this, 2412, 39 );
			/*****************************/
		}
	}
}

namespace Server.Creatures
{
	public class ScarletCenturion: BaseCreature
	{
		public ScarletCenturion() : base()
		{
			Name = "Scarlet Centurion";
			Id = 4301;
			Model = 2500;
			Level = RandomLevel(38,39);
			SetDamage(1f+2.88f*Level,1f+3.1*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;
			Block = Level-5;
			Flags1=0x080000;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);			
			Size=1.300000f;
			BoundingRadius = 0.20800f;
			CombatReach = 1.300f;
			Speed = 3.8f;
			WalkSpeed = 3.8f;
			RunSpeed = 6.4f;
			Faction = Factions.Monster;
			AIEngine = new EvilInteligentMonsterAI( this );
			NpcType = 7;	
			Elite=1; //elite
			Equip( new Item( 7490, InventoryTypes.TwoHanded, 8, 1, 17, 1, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure( ScarletDrops.ScarletCenturion, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )};						
			/*****************************/
			BCAddon.Hp( this, 2302, 38 );
			/*****************************/
		}
	}
}

namespace Server.Creatures
{
	public class ScarletChaplain: BaseCreature
	{
		public ScarletChaplain() : base()
		{
			Name = "Scarlet Chaplain";
			Id = 4299;
			Model = 2501;
			Level = RandomLevel(34,36);
			SetDamage(1f+2.88f*Level,1f+3.1*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;
			Block = Level-5;
			Flags1=0x080000;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);			
			BoundingRadius = 0.20800f;
			CombatReach = 0.800f;
			Speed = 3.8f;
			WalkSpeed = 3.8f;
			RunSpeed = 6.4f;
			Faction = Factions.Monster;
			AIEngine = new EvilInteligentMonsterAI( this );
			NpcType = 7;	
			Elite=1; //elite
			Equip(new FightClub());
			Loots = new BaseTreasure[]{  new BaseTreasure( ScarletDrops.ScarletChaplain, 100f ),
						new BaseTreasure(DropsME.MoneyElite1, 100f )};			
			/*****************************/
			BCAddon.Hp( this, 2194, 34 );
			/*****************************/
		}
	}
}

namespace Server.Creatures
{
	public class ScarletCleric: BaseCreature
	{
		public ScarletCleric() : base()
		{
			Name = "Scarlet Cleric";
			Id = 9449;
			Model = 10387;
			Level = RandomLevel(54,55);
			SetDamage(1f+2.88f*Level,1f+3.1*Level);			
			AttackSpeed = 1185;
			Armor = 150*Level;
			Block = Level-5;
			Flags1=0x080000;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);			
			BoundingRadius = 0.20800f;
			CombatReach = 0.800f;
			Speed = 3.8f;
			WalkSpeed = 3.8f;
			RunSpeed = 6.4f;
			Faction = Factions.Monster;
			AIEngine = new EvilInteligentMonsterAI( this );
			NpcType = 7;	
			Elite=1; //elite
			Equip( new Item( 21341, InventoryTypes.TwoHanded, 10, 2, 17, 2, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure( ScarletDrops.ScarletCleric, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )};						
			/*****************************/
			BCAddon.Hp( this, 1650, 54 );
			/*****************************/
		}
	}
}

namespace Server.Creatures
{
	public class ScarletCommanderMograine: BaseCreature
	{
		public ScarletCommanderMograine() : base()
		{
			Name = "Scarlet Commander Mograine";
			Id = 3976;
			Model = 2042;
			Level = RandomLevel(40,42);
			SetDamage(1f+2.88f*Level,1f+3.1*Level);			
			AttackSpeed = 2200;
			Armor = 150*Level;
			Block = Level-5;
			Flags1=0x080000;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);			
			BoundingRadius = 0.36800f;
			CombatReach = 0.800f;
			Speed = 3.8f;
			WalkSpeed = 3.8f;
			RunSpeed = 6.4f;
			Faction = Factions.Monster;
			AIEngine = new EvilInteligentMonsterAI( this );
			NpcText="May the Light protect you this day";
			NpcType = 7;	
			Size=1.200000f;
			Elite=1; //elite
			Equip( new Item( 15786, InventoryTypes.OneHand, 5, 2, 13, 1, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure( ScarletDrops.ScarletCommanderMograine, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )};						
			/*****************************/
			BCAddon.Hp( this, 2459, 40 );
			/*****************************/
		}
	}
}


namespace Server.Creatures
{
	public class ScarletConjuror: BaseCreature
	{
		public ScarletConjuror() : base()
		{
			Name = "Scarlet Conjuror";
			Id = 4297;
			Model = 2503;
			Level = RandomLevel(35,36);
			SetDamage(1f+2.88f*Level,1f+3.1*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;
			Block = Level-5;
			Flags1=0x080000;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);			
			BoundingRadius = 0.200f;
			CombatReach = 0.400f;
			Speed = 3.8f;
			WalkSpeed = 3.8f;
			RunSpeed = 6.4f;
			Faction = Factions.Monster;
			AIEngine = new EvilInteligentMonsterAI( this );
			NpcType = 7;	
			Elite=1; //elite
			Equip( new Item( 1927, InventoryTypes.TwoHanded, 10, 2, 17, 2, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure( ScarletDrops.ScarletConjuror, 100f ),
						new BaseTreasure(DropsME.MoneyElite1, 100f )};			
			/*****************************/
			BCAddon.Hp( this, 2822, 35 );
			/*****************************/
		}
	}
}

namespace Server.Creatures
{
	public class ScarletConvert: BaseCreature
	{
		public ScarletConvert() : base()
		{
			Name = "Scarlet Convert";
			Id = 1506;
			Model = 2403;
			Level = RandomLevel(3);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Str = (int)(Level/2.5f);			
			Armor = 0;
			Block = 0;
			Flags1=0x080000;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = 41;
			BaseMana = 100;
			BoundingRadius = 0.3080f;
			CombatReach = 0.900f;
			Speed = 3.50f;
			WalkSpeed = 3.5f;
			RunSpeed = 7.0f;
			Faction = Factions.Monster;
			AIEngine = new EvilInteligentMonsterAI( this );
			NpcType = 7;	
			Unk3=1; 
			Equip( new Item( 7434, InventoryTypes.OneHand, 15, 1, 13, 3,  0, 0, 0 ) ); 
			LearnSpell( 6136, SpellsTypes.Offensive); //Chiled
			Loots = new BaseTreasure[]{  new BaseTreasure( ScarletDrops.ScarletConvert, 100f ),
							new BaseTreasure(Drops.MoneyA, 100f )};						
		}
	}
}

namespace Server.Creatures
{
	public class ScarletCurate: BaseCreature
	{
		public ScarletCurate() : base()
		{
			Name = "Scarlet Curate";
			Id = 9450;
			Model = 10398;
			Level = RandomLevel(55,56);
			SetDamage(1f+2.88f*Level,1f+3.1*Level);			
			AttackSpeed = 1173;
			Armor = 150*Level;
			Block = Level-5;
			Flags1=0x080000;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);			
			BoundingRadius = 0.200f;
			CombatReach = 0.400f;
			Speed = 6.0f;
			WalkSpeed = 6.0f;
			RunSpeed =7.4f;
			Faction = Factions.Monster;
			AIEngine = new EvilInteligentMonsterAI( this );
			NpcType = 7;	
			Elite=1; //elite
			Equip(new FightClub());
			Loots = new BaseTreasure[]{  new BaseTreasure( ScarletDrops.ScarletCurate, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )};						
			/*****************************/
			BCAddon.Hp( this, 4521, 55 );
			/*****************************/
		}
	}
}

namespace Server.Creatures
{
	public class ScarletDefender: BaseCreature
	{
		public ScarletDefender() : base()
		{
			Name = "Scarlet Defender";
			Id = 4298;
			Model = 2462;
			Level = RandomLevel(37,38);
			SetDamage(1f+2.88f*Level,1f+3.1*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;
			Block = Level;
			Flags1=0x080000;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);			
			BoundingRadius = 0.200f;
			CombatReach = 0.400f;
			Speed = 4.7f;
			WalkSpeed = 4.7f;
			RunSpeed =6.1f;
			Faction = Factions.Monster;
			AIEngine = new EvilInteligentMonsterAI( this );
			NpcType = 7;	
			Elite=1; //elite
			Equip( new Item( 7487, InventoryTypes.OneHand, 15, 1, 13, 3,  0, 0, 0 ), new Item(1705, InventoryTypes.Shield, 15, 1, 14, 3,  0, 0, 0 ) ); 	
			Loots = new BaseTreasure[]{  new BaseTreasure( ScarletDrops.ScarletDefender, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )};						
			/*****************************/
			BCAddon.Hp( this, 2300, 37 );
			/*****************************/
		}
	}
}

namespace Server.Creatures
{
	public class ScarletEnchanter: BaseCreature
	{
		public ScarletEnchanter() : base()
		{
			Name = "Scarlet Enchanter";
			Id = 9452;
			Model = 10403;
			Level = RandomLevel(53,55);
			SetDamage(1f+2.88f*Level,1f+3.1*Level);			
			AttackSpeed = 1185;
			Armor = 150*Level;
			Block = Level-5;
			Flags1=0x080000;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);			
			BoundingRadius = 1.000f;
			CombatReach = 0.400f;
			Speed = 5.0f;
			WalkSpeed = 5.0f;
			RunSpeed =6.4f;
			Faction = Factions.Monster;
			AIEngine = new EvilInteligentMonsterAI( this );
			NpcType = 7;	
			Elite=1; //elite
			Equip( new Item( 23586, InventoryTypes.TwoHanded, 10, 2, 17, 2,  0, 0, 0 )); 
			Loots = new BaseTreasure[]{  new BaseTreasure( ScarletDrops.ScarletEnchanter, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )};						
			/*****************************/
			BCAddon.Hp( this, 4531, 53 );
			/*****************************/
		}
	}
}

namespace Server.Creatures
{
	public class ScarletEvoker: BaseCreature
	{
		public ScarletEvoker() : base()
		{
			Name = "Scarlet Evoker";
			Id = 4289;
			Model = 2509;
			Level = RandomLevel(36,37);
			SetDamage(1f+2.88f*Level,1f+3.1*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;
			Block = Level-5;
			Flags1=0x080000;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);			
			BoundingRadius = 0.30600f;
			CombatReach = 0.900f;
			Speed = 5.0f;
			WalkSpeed = 5.0f;
			RunSpeed =6.4f;
			Faction = Factions.Monster;
			AIEngine = new EvilInteligentMonsterAI( this );
			NpcType = 7;	
			Elite=1; //elite
			Equip( new Item( 5542, InventoryTypes.TwoHanded, 10, 2, 17, 2,  0, 0, 0 )); 
			Loots = new BaseTreasure[]{  new BaseTreasure( ScarletDrops.ScarletEvoker, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )};						
			/*****************************/
			BCAddon.Hp( this, 1757, 36 );
			/*****************************/
		}
	}
}

namespace Server.Creatures
{
	public class ScarletFriar: BaseCreature
	{
		public ScarletFriar() : base()
		{
			Name = "Scarlet Friar";
			Id = 1538;
			Model = 2466;
			Level = RandomLevel(9,10);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Str = (int)(Level/2.5f);			
			Armor = 50;
			Block = 0;
			Flags1=0x080000;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.3080f;
			CombatReach = 0.900f;
			Speed = 3.15f;
			WalkSpeed = 3.15f;
			RunSpeed = 4.0f;
			Faction = Factions.Monster;
			AIEngine = new EvilInteligentMonsterAI( this );
			NpcType = 7;	
			Unk3=1; 
			Equip( new Item( 1599, InventoryTypes.TwoHanded, 10, 2, 17, 2,  0, 0, 0 )); 
			Loots = new BaseTreasure[]{  new BaseTreasure( ScarletDrops.ScarletFriar, 100f ),
							new BaseTreasure(Drops.MoneyA, 100f )};						
			/*****************************/
			BCAddon.Hp( this, 191, 9 );
			/*****************************/
		}
	}
}


namespace Server.Creatures
{
	public class ScarletGuardsman: BaseCreature
	{
		public ScarletGuardsman() : base()
		{
			Name = "Scarlet Guardsman";
			Id = 4290;
			Model = 2511;
			Level = RandomLevel(36,37);
			SetDamage(1f+2.88f*Level,1f+3.1*Level);			
			AttackSpeed = 2800;
			Armor = 20*Level;
			Block = Level-2;
			Flags1=0x080000;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/0.5f);			
			BoundingRadius = 0.30600f;
			CombatReach = 1.000f;
			Speed = 3.8f;
			WalkSpeed = 3.8f;
			RunSpeed =6.0f;
			Faction = Factions.Monster;
			AIEngine = new EvilInteligentMonsterAI( this );
			NpcType = 7;	
			Elite=1; //elite
			Equip( new Item( 7437, InventoryTypes.OneHand, 6, 1, 17, 2,  0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( ScarletDrops.ScarletGuardsman, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )};						
			/*****************************/
			BCAddon.Hp( this, 2145, 36 );
			/*****************************/
		}
	}
}

namespace Server.Creatures
{
	public class ScarletHound: BaseCreature
	{
		public ScarletHound() : base()
		{
			Name = "Scarlet Hound";
			Id = 10979;
			Model = 2709;
			Level = RandomLevel(52,53);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 1500;
			Str = (int)(Level/3.5f);			
			Armor = 0;
			Block = 0;
			Flags1=0x080000;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.3080f;
			CombatReach = 0.400f;
			Speed = 4.15f;
			WalkSpeed = 4.15f;
			RunSpeed = 6.0f;
			Faction = Factions.Monster;
			AIEngine = new EvilInteligentMonsterAI( this );
			NpcType = 1;	
			Unk3=25; 
			Size=0.872881f;
			SkinLoot = new Loot[] { new Loot( typeof( RuinedLeatherScraps ), 90.0f )
					          ,new Loot( typeof( LightLeather ), 10.0f )};
			/*****************************/
			BCAddon.Hp( this, 820, 52 );
			/*****************************/
		}
	}
}


namespace Server.Creatures
{
	public class ScarletHunter: BaseCreature
	{
		public ScarletHunter() : base()
		{
			Name = "Scarlet Hunter";
			Id = 1831;
			Model = 10280;
			Level = RandomLevel(52,53);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Str = (int)(Level/3.5f);			
			Armor = 0;
			Block = 0;
			Flags1=0x080000;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.2080f;
			CombatReach = 0.400f;
			Speed = 4.00f;
			WalkSpeed = 4.00f;
			RunSpeed = 5.2f;
			Faction = Factions.Monster;
			AIEngine = new EvilInteligentMonsterAI( this );
			NpcType = 7;	
			Unk3=1; 
			Equip( new Item( 7485, InventoryTypes.OneHand, 7, 1, 13, 3,  0, 0, 0 ),  new Item( 6233, InventoryTypes.Ranged, 2, 2, 15, 2,  0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( ScarletDrops.ScarletHunter, 100f ),
							new BaseTreasure(Drops.MoneyA, 100f )};			
			/*****************************/
			BCAddon.Hp( this, 1547, 52 );
			/*****************************/
		}
	}
}


namespace Server.Creatures
{
	public class ScarletInitiate: BaseCreature
	{
		public ScarletInitiate() : base()
		{
			Name = "Scarlet Initiate";
			Id = 1507;
			Model = 10280;
			Level = RandomLevel(3,4);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Str = (int)(Level/3.5f);			
			Armor = 0;
			Block = 0;
			Flags1=0x080000;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.2080f;
			CombatReach = 0.400f;
			Speed = 4.00f;
			WalkSpeed = 4.00f;
			RunSpeed = 5.2f;
			Faction = Factions.Monster;
			AIEngine = new EvilInteligentMonsterAI( this );
			NpcType = 7;	
			Unk3=1; 
			Equip( new Item( 7478, InventoryTypes.OneHand, 4, 2, 13, 3,  0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( ScarletDrops.ScarletInitiate, 100f ),
							new BaseTreasure(Drops.MoneyA, 100f )};		
			/*****************************/
			BCAddon.Hp( this, 142, 3 );
			/*****************************/
		}
	}
}

namespace Server.Creatures
{
	public class ScarletInvoker: BaseCreature
	{
		public ScarletInvoker() : base()
		{
			Name = "Scarlet Invoker";
			Id = 1835;
			Model = 10320;
			Level = RandomLevel(53,54);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Str = (int)(Level/3.5f);			
			Armor = 0;
			Block = 0;
			Flags1=0x080000;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.3080f;
			CombatReach = 0.400f;
			Speed = 4.00f;
			WalkSpeed = 4.00f;
			RunSpeed = 5.2f;
			Faction = Factions.Monster;
			AIEngine = new EvilInteligentMonsterAI( this );
			NpcType = 7;	
			Unk3=1; 			
			Equip( new Item( 19557, InventoryTypes.OneHand, 15, 1, 13, 3,  0, 0, 0 ), new Item( 23455, InventoryTypes.RangeRight, 19, 2, 26, 0,  0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( ScarletDrops.ScarletInvoker, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};	
			/*****************************/
			BCAddon.Hp( this, 1547, 53 );
			/*****************************/
		}
	}
}

namespace Server.Creatures
{
	public class ScarletKnight: BaseCreature
	{
		public ScarletKnight() : base()
		{
			Name = "Scarlet Knight";
			Id = 1833;
			Model = 10292;
			Level = RandomLevel(54,55);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Str = (int)(Level/1.5f);			
			Armor = Level*20;
			Block = (int)((Level)/2.5f);
			Flags1=0x080000;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.3080f;
			CombatReach = 0.400f;
			Speed = 4.00f;
			WalkSpeed = 4.00f;
			RunSpeed = 5.2f;
			Faction = Factions.Monster;
			AIEngine = new EvilInteligentMonsterAI( this );
			NpcType = 7;	
			Unk3=1; 
			Equip( new Item( 7483, InventoryTypes.OneHand, 7, 1, 13, 3,  0, 0, 0 ), new Item( 23455, InventoryTypes.Shield, 6, 1, 14, 4,  0, 0, 0 ));		
			Loots = new BaseTreasure[]{  new BaseTreasure( ScarletDrops.ScarletKnight, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};	
			/*****************************/
			BCAddon.Hp( this, 2809, 54 );
			/*****************************/
		}
	}
}

namespace Server.Creatures
{
	public class ScarletLumberjack: BaseCreature
	{
		public ScarletLumberjack() : base()
		{
			Name = "Scarlet Lumberjack";
			Id = 1884;
			Model = 10300;
			Level = RandomLevel(54,56);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Str = (int)(Level/2.5f);			
			Armor = Level*10;
			Block = (int)((Level)/3.5f);
			Flags1=0x080000;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = Level-30;
			ResistShadow = 0;
			BoundingRadius = 0.3060f;
			CombatReach = 0.400f;
			Speed = 4.00f;
			WalkSpeed = 4.00f;
			RunSpeed = 5.2f;
			Faction = Factions.Monster;
			AIEngine = new EvilInteligentMonsterAI( this );
			NpcType = 7;	
			Unk3=1; 
			Equip( new Item( 7428, InventoryTypes.OneHand, 0, 1, 13, 3,  0, 0, 0 ));		
			Loots = new BaseTreasure[]{  new BaseTreasure( ScarletDrops.ScarletLumberjack, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};	
			/*****************************/
			BCAddon.Hp( this, 1966, 54 );
			/*****************************/
		}
	}
}


//Scarlet Macaw Level ?? Beast - no description

namespace Server.Creatures
{
	public class ScarletMage: BaseCreature
	{
		public ScarletMage() : base()
		{
			Name = "Scarlet Mage";
			Id = 1826;
			Model = 10288;
			Level = RandomLevel(55,56);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Str = (int)(Level/2.5f);			
			Armor = Level*5;
			Block = (int)((Level)/3.5f);
			ResistArcane = Level;
			ResistFire = Level-25;
			ResistFrost = Level-25;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.3060f;
			CombatReach = 1.200f;
			Speed = 4.00f;
			WalkSpeed = 4.00f;
			RunSpeed = 5.2f;
			Faction = Factions.Monster;
			AIEngine = new GroupInteligentSpellCasterAI( this );
			NpcType = 7;	
			Unk3=1; 
			Equip( new Item( 21251, InventoryTypes.TwoHanded, 10, 2, 17, 2,  0, 0, 0 ));		
			Loots = new BaseTreasure[]{  new BaseTreasure( ScarletDrops.ScarletMage, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};			
			/*****************************/
			BCAddon.Hp( this, 2309, 55 );
			/*****************************/
		}
	}
}


namespace Server.Creatures
{
	public class ScarletMagician: BaseCreature
	{
		public ScarletMagician() : base()
		{
			Name = "Scarlet Magician";
			Id = 4282;
			Model = 10288;
			Level = RandomLevel(29,30);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Str = (int)(Level/2.5f);			
			Armor = Level*7;
			Block = (int)((Level)/2.5f);
			ResistArcane = Level+10;
			ResistFire = Level-15;
			ResistFrost = Level-15;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.3060f;
			CombatReach = 1.200f;
			Speed = 4.00f;
			WalkSpeed = 4.00f;
			RunSpeed = 5.2f;
			Faction = Factions.Monster;
			AIEngine = new GroupInteligentSpellCasterAI( this );
			NpcType = 7;	
			Elite=1; 
			Equip( new Item( 1599, InventoryTypes.TwoHanded, 10, 2, 17, 2,  0, 0, 0 ));		
			Loots = new BaseTreasure[]{  new BaseTreasure( ScarletDrops.ScarletMagician, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )};	
			/*****************************/
			BCAddon.Hp( this, 2309, 29 );
			/*****************************/
		}
	}
}

namespace Server.Creatures
{
	public class ScarletMagus: BaseCreature
	{
		public ScarletMagus() : base()
		{
			Name = "Scarlet Magus";
			Id = 1832;
			Model = 10328;
			Level = RandomLevel(56,57);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 1161;
			Str = (int)(Level/2.5f);			
			Armor = Level*7;
			Block = (int)((Level)/2.5f);
			ResistArcane = Level+10;
			ResistFire = Level-15;
			ResistFrost = Level-15;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.7060f;
			CombatReach = 1.200f;
			Speed = 4.00f;
			WalkSpeed = 4.00f;
			RunSpeed = 5.2f;
			Faction = Factions.Monster;
			AIEngine = new GroupInteligentSpellCasterAI( this );
			NpcType = 7;	
			Elite=1; 		
			Loots = new BaseTreasure[]{  new BaseTreasure( ScarletDrops.ScarletMagus, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )};	
			/*****************************/
			BCAddon.Hp( this, 3309, 56 );
			/*****************************/
		}
	}
}

namespace Server.Creatures
{
	public class ScarletMedic: BaseCreature
	{
		public ScarletMedic() : base()
		{
			Name = "Scarlet Medic";
			Id = 10605;
			Model = 10313;
			Level = RandomLevel(52,54);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Str = (int)(Level/2.5f);			
			Armor = Level*5;
			Block = (int)((Level)/3.5f);
			ResistArcane = Level;
			ResistFire = Level-25;
			ResistFrost = Level-25;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.2060f;
			CombatReach = 1.000f;
			Speed = 3.5f;
			WalkSpeed = 3.5f;
			RunSpeed = 4.5f;
			Faction = Factions.Monster;
			AIEngine = new GroupInteligentSpellCasterAI( this );
			NpcType = 7;	
			Unk3=1; 	
			Equip( new Item( 2388, InventoryTypes.TwoHanded, 10, 2, 17, 2,  0, 0, 0 ));	
			Loots = new BaseTreasure[]{  new BaseTreasure( ScarletDrops.ScarletMedic, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};	
			/*****************************/
			BCAddon.Hp( this, 1430, 52 );
			/*****************************/
		}
	}
}

namespace Server.Creatures
{
	public class ScarletMissionary: BaseCreature
	{
		public ScarletMissionary() : base()
		{
			Name = "Scarlet Missionary";
			Id = 1536;
			Model = 2468;
			Level = RandomLevel(7,8);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Str =0;			
			Armor = Level*5;
			Block = (int)((Level)/3.5f);
			ResistArcane = Level;
			ResistFire = Level-25;
			ResistFrost = Level-25;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BoundingRadius = 0.3060f;
			CombatReach = 0.500f;
			Speed = 2.8f;
			WalkSpeed = 2.8f;
			RunSpeed = 3.8f;
			Faction = Factions.Monster;
			AIEngine = new EvilInteligentMonsterAI( this );
			NpcType = 7;	
			Unk3=1; 
			Equip( new Item( 1599, InventoryTypes.TwoHanded, 10, 2, 17, 2,  0, 0, 0 ));		
			Loots = new BaseTreasure[]{  new BaseTreasure( ScarletDrops.ScarletMissionary, 100f ),
							new BaseTreasure(Drops.MoneyA, 100f )};	
			/*****************************/
			BCAddon.Hp( this, 128, 7 );
			/*****************************/
		}
	}
}


namespace Server.Creatures
{
	public class ScarletMonk: BaseCreature
	{
		public ScarletMonk() : base()
		{
			Name = "Scarlet Monk";
			Id = 4540;
			Model = 2603;
			Level = RandomLevel(35,36);
			SetDamage(1f+2.88f*Level,1f+3.1*Level);			
			AttackSpeed = 1800;
			Armor = 50*Level;
			Block = 0;
			Flags1=0x080000;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.3077550f;
			CombatReach = 0.300f;
			Speed = 3.5f;
			WalkSpeed = 3.5f;
			RunSpeed = 6.5f;
			Faction = Factions.Monster;
			AIEngine = new BerserkerAI( this );
			NpcType = 7;	
			Elite=1; //elite
			Loots = new BaseTreasure[]{  new BaseTreasure( ScarletDrops.ScarletMonk, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )};			
			/*****************************/
			BCAddon.Hp( this, 1548, 35 );
			/*****************************/			
		}
	}
}

namespace Server.Creatures
{
	public class ScarletMyrmidon: BaseCreature
	{
		public ScarletMyrmidon() : base()
		{
			Name = "Scarlet Myrmidon";
			Id = 4295;
			Model = 2514;
			Level = RandomLevel(37,38);
			SetDamage(1f+2.88f*Level,1f+3.1*Level);			
			AttackSpeed = 1700;
			Armor = 50*Level;
			Block = 0;
			Flags1=0x080000;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.3077550f;
			CombatReach = 0.2500f;
			Speed = 3.5f;
			WalkSpeed = 3.5f;
			RunSpeed = 6.5f;
			Faction = Factions.Monster;
			AIEngine = new BerserkerAI( this );
			NpcType = 7;	
			Elite=1; //elite
			Equip( new Item( 7526, InventoryTypes.OneHand, 7, 1, 13, 3,  0, 0, 0 ), new Item( 7488, InventoryTypes.OneHand, 7, 1, 13, 3,  0, 0, 0 ));		
			Loots = new BaseTreasure[]{  new BaseTreasure( ScarletDrops.ScarletMyrmidon, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )};	
			/*****************************/
			BCAddon.Hp( this, 3168, 37 );
			/*****************************/			
		}
	}
}


namespace Server.Creatures
{
	public class ScarletNeophyte: BaseCreature
	{
		public ScarletNeophyte() : base()
		{
			Name = "Scarlet Neophyte";
			Id = 1539;
			Model = 2480;
			Level = RandomLevel(10,11);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Str =0;			
			Armor = Level*5;
			Block = (int)((Level)/3.5f);
			ResistArcane = Level;
			ResistFire = Level-25;
			ResistFrost = Level-25;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseMana = 191;
			BoundingRadius = 0.2060f;
			CombatReach = 0.500f;
			Speed = 2.8f;
			WalkSpeed = 2.8f;
			RunSpeed = 3.8f;
			Faction = Factions.Monster;
			AIEngine = new EvilInteligentMonsterAI( this );
			NpcType = 7;	
			Unk3=1; 
			Equip( new Item(1600, InventoryTypes.TwoHanded, 10, 2, 17, 2,  0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( ScarletDrops.ScarletNeophyte, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};	
			/*****************************/
			BCAddon.Hp( this, 200, 10 );
			/*****************************/
		}
	}
}


namespace Server.Creatures
{
	public class ScarletPaladin: BaseCreature
	{
		public ScarletPaladin() : base()
		{
			Name = "Scarlet Paladin";
			Id = 1834;
			Model = 10324;
			Level = RandomLevel(55,56);
			SetDamage(1f+2.88f*Level,1f+3.1*Level);			
			AttackSpeed = 1173;
			Armor = 50*Level;
			Block = 0;
			Flags1=0x080000;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 10;
			Str = (int)(Level/1.5f);
			BaseMana = 8265;
			BoundingRadius = 1.077550f;
			CombatReach = 0.3500f;
			Speed = 5.1f;
			WalkSpeed = 5.1f;
			RunSpeed = 7.1f;
			Faction = Factions.Monster;
			AIEngine = new BerserkerAI( this );
			NpcType = 7;	
			Elite=1; //elite	
			Loots = new BaseTreasure[]{  new BaseTreasure( ScarletDrops.ScarletPaladin, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )};			
			/*****************************/
			BCAddon.Hp( this, 2967, 55 );
			/*****************************/			
		}
	}
}


namespace Server.Creatures
{
	public class ScarletPraetorian: BaseCreature
	{
		public ScarletPraetorian() : base()
		{
			Name = "Scarlet Praetorian";
			Id = 9448;
			Model = 10395;
			Level = RandomLevel(56,57);
			SetDamage(1f+2.88f*Level,1f+3.1*Level);			
			AttackSpeed = 1173;
			Armor = 55*Level;
			Block = 0;
			Flags1=0x080000;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseMana = 8415;
			Str = (int)(Level/1.5f);
			BoundingRadius = 1.077550f;
			CombatReach = 0.3500f;
			Speed = 5.1f;
			WalkSpeed = 5.1f;
			RunSpeed = 7.1f;
			Faction = Factions.Monster;
			AIEngine = new BerserkerAI( this );
			NpcType = 7;	
			Elite=1; //elite	
			Equip( new Item(23472, InventoryTypes.OneHand, 7, 1, 13, 3,  0, 0, 0 ));			
			Loots = new BaseTreasure[]{  new BaseTreasure( ScarletDrops.ScarletPraetorian, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )};	
			/*****************************/
			BCAddon.Hp( this, 3200, 56 );
			/*****************************/			
		}
	}
}

namespace Server.Creatures
{
	public class ScarletPreserver: BaseCreature
	{
		public ScarletPreserver() : base()
		{
			Name = "Scarlet Preserver";
			Id = 4280;
			Model = 2475;
			Level = RandomLevel(29,30);
			SetDamage(1f+2.88f*Level,1f+3.1*Level);			
			AttackSpeed = 2000;
			Armor = 5*Level;
			Block = 0;
			Flags1=0x080000;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.2077550f;
			CombatReach = 0.3500f;
			Speed = 4.1f;
			WalkSpeed = 4.1f;
			RunSpeed = 6.1f;
			Faction = Factions.Monster;
			AIEngine = new BerserkerAI( this );
			NpcType = 7;	
			Elite=1; //elite	
			Equip( new Item(11289, InventoryTypes.OneHand, 4, 2, 13, 3,  0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( ScarletDrops.ScarletPreserver, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )};	
			/*****************************/
			BCAddon.Hp( this, 2588, 29 );
			/*****************************/			
		}
	}
}

namespace Server.Creatures
{
	public class ScarletPriest: BaseCreature
	{
		public ScarletPriest() : base()
		{
			Name = "Scarlet Priest";
			Id = 10608;
			Model = 10332;
			Level = RandomLevel(55,57);
			SetDamage(1f+2.88f*Level,1f+3.1*Level);			
			AttackSpeed = 1161;
			Armor = 5*Level;
			Block = 0;
			ResistArcane = 10;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BoundingRadius = 1.077550f;
			CombatReach = 2.3500f;
			Speed = 4.1f;
			WalkSpeed = 4.1f;
			RunSpeed = 6.1f;
			Faction = Factions.Monster;
			AIEngine = new HealerAI( this );
			NpcType = 7;	
			Elite=1; //elite	
			Loots = new BaseTreasure[]{  new BaseTreasure( ScarletDrops.ScarletPriest, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )};			
			/*****************************/
			BCAddon.Hp( this, 2309, 55 );
			/*****************************/			
		}
	}
}


namespace Server.Creatures
{
	public class ScarletProtector: BaseCreature
	{
		public ScarletProtector() : base()
		{
			Name = "Scarlet Protector";
			Id = 4292;
			Model = 2476;
			Level = RandomLevel(36,37);
			SetDamage(1f+2.88f*Level,1f+3.1*Level);			
			AttackSpeed = 2000;
			Armor = 55*Level;
			Block = 0;
			Flags1=0x080000;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.307550f;
			CombatReach = 0.3500f;
			Speed = 3.8f;
			WalkSpeed = 3.8f;
			RunSpeed = 6.1f;
			Faction = Factions.Monster;
			AIEngine = new BerserkerAI( this );
			NpcType = 7;	
			Elite=1; //elite		
			Equip( new Item(7478, InventoryTypes.OneHand, 4, 2, 13, 3,  0, 0, 0 ), new Item(1705, InventoryTypes.Shield, 6, 1, 14, 4,  0, 0, 0 ));		
			Loots = new BaseTreasure[]{  new BaseTreasure( ScarletDrops.ScarletProtector, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )};			
			/*****************************/
			BCAddon.Hp( this, 2750, 36 );
			/*****************************/			
		}
	}
}

namespace Server.Creatures
{
	public class ScarletScout: BaseCreature
	{
		public ScarletScout() : base()
		{
			Name = "Scarlet Scout";
			Id = 4281;
			Model = 2517;
			Level = RandomLevel(29,30);
			SetDamage(1f+2.88f*Level,1f+3.1*Level);			
			AttackSpeed = 2000;
			Armor = 55*Level;
			Block = 0;
			Flags1=0x080000;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.307550f;
			CombatReach = 0.3500f;
			Speed = 3.8f;
			WalkSpeed = 3.8f;
			RunSpeed = 6.1f;
			Faction = Factions.Monster;
			AIEngine = new BerserkerAI( this );
			NpcType = 7;	
			Elite=1; //elite

			Equip( new Item(7428, InventoryTypes.OneHand, 0, 1, 13, 3,  0, 0, 0 ), new Item(6232, InventoryTypes.Ranged, 2, 2, 15, 2,  0, 0, 0 ));						
			Loots = new BaseTreasure[]{  new BaseTreasure( ScarletDrops.ScarletScout, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )};	
			/*****************************/
			BCAddon.Hp( this, 1312, 29 );
			/*****************************/			
		}
	}
}

namespace Server.Creatures
{
	public class ScarletScryer: BaseCreature
	{
		public ScarletScryer() : base()
		{
			Name = "Scarlet Scryer";
			Id = 4293;
			Model = 2518;
			Level = RandomLevel(30,31);
			SetDamage(1f+2.88f*Level,1f+3.1*Level);			
			AttackSpeed = 1161;
			Armor = 5*Level;
			Block = 0;
			Flags1=0x080000;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BoundingRadius = 1.077550f;
			CombatReach = 2.3500f;
			Speed = 4.1f;
			WalkSpeed = 4.1f;
			RunSpeed = 6.1f;
			Faction = Factions.Monster;
			AIEngine = new BerserkerAI( this );
			NpcType = 7;	
			Elite=1; //elite	
			Equip( new Item(7469, InventoryTypes.OneHand, 4, 2, 13, 7,  0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( ScarletDrops.ScarletScryer, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )};	
			/*****************************/
			BCAddon.Hp( this, 2103, 30 );
			/*****************************/			
		}
	}
}

namespace Server.Creatures
{
	public class ScarletSentinel: BaseCreature
	{
		public ScarletSentinel() : base()
		{
			Name = "Scarlet Sentinel";
			Id = 1827;
			Model = 10350;
			Level = RandomLevel(55,56);
			SetDamage(1f+2.88f*Level,1f+3.1*Level);			
			AttackSpeed = 1173;
			Armor = 5*Level;
			Block = 0;
			Flags1=0x080000;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BoundingRadius = 1.077550f;
			CombatReach = 2.3500f;
			Speed = 3.1f;
			WalkSpeed = 3.1f;
			RunSpeed = 5.1f;
			Faction = Factions.Monster;
			AIEngine = new BerserkerAI( this );
			NpcType = 7;	
			Elite=1; //elite				
			Loots = new BaseTreasure[]{  new BaseTreasure( ScarletDrops.ScarletSentinel, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )};	
			/*****************************/
			BCAddon.Hp( this, 4242, 55 );
			/*****************************/			
		}
	}
}


namespace Server.Creatures
{
	public class ScarletSentry: BaseCreature
	{
		public ScarletSentry() : base()
		{
			Name = "Scarlet Sentry";
			Id = 4283;
			Model = 2520;
			Level = RandomLevel(30,31);
			SetDamage(1f+2.88f*Level,1f+3.1*Level);			
			AttackSpeed = 2000;
			Armor = 55*Level;
			Block = 0;
			Flags1=0x080000;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.307550f;
			CombatReach = 0.3500f;
			Speed = 4.7f;
			WalkSpeed = 4.7f;
			RunSpeed = 6.0f;
			Faction = Factions.NoFaction;
			AIEngine = new BerserkerAI( this );
			NpcType = 7;	
			Elite=1; //elite
			NpcText = "You best head up to Stormwind in the Dwarven District if you want to learn to mine.  Surely one of the dwarves there can teach you the profession.";
			NpcText00 = "I think you'll have better luck looking in Stormwind.  Ask a guard up there and they'll point you in the right direction.";			
			Equip( new Item(7419, InventoryTypes.OneHand, 7, 1, 13, 3,  0, 0, 0 ), new Item(1684, InventoryTypes.Shield, 6, 1, 14, 4,  0, 0, 0 ));			
			Loots = new BaseTreasure[]{  new BaseTreasure( ScarletDrops.ScarletSentry, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )};	
			/*****************************/
			BCAddon.Hp( this, 2662, 30 );
			/*****************************/			
		}
	}
}



namespace Server.Creatures
{
	public class ScarletSoldier: BaseCreature
	{
		public ScarletSoldier() : base()
		{
			Name = "Scarlet Soldier";
			Id = 4286;
			Model = 2522;
			Level = RandomLevel(35,36);
			SetDamage(1f+2.88f*Level,1f+3.1*Level);			
			AttackSpeed = 2000;
			Armor = 55*Level;
			Block = 0;
			Flags1=0x080000;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.307550f;
			CombatReach = 0.3500f;
			Speed = 4.7f;
			WalkSpeed = 4.7f;
			RunSpeed = 6.0f;
			Faction = Factions.Monster;
			AIEngine = new BerserkerAI( this );
			NpcType = 7;	
			Elite=1; //elite
			Equip( new Item(7483, InventoryTypes.OneHand, 7, 1, 13, 3,  0, 0, 0 ));	
			Loots = new BaseTreasure[]{  new BaseTreasure( ScarletDrops.ScarletSoldier, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )};	
			/*****************************/
			BCAddon.Hp( this, 2414, 35 );
			/*****************************/
		}
	}
}

namespace Server.Creatures
{
	public class ScarletSorcerer: BaseCreature
	{
		public ScarletSorcerer() : base()
		{
			Name = "Scarlet Sorcerer";
			Id = 4294;
			Model = 2524;
			Level = RandomLevel(37,38);
			SetDamage(1f+2.88f*Level,1f+3.1*Level);			
			AttackSpeed = 2000;
			Armor = 55*Level;
			Block = 0;
			Flags1=0x080000;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.307550f;
			CombatReach = 0.3500f;
			Speed = 4.7f;
			WalkSpeed = 4.7f;
			RunSpeed = 6.0f;
			Faction = Factions.Monster;
			AIEngine = new GroupInteligentSpellCasterAI( this );
			NpcType = 7;	
			Elite=1; //elite	
			Equip( new Item(1927, InventoryTypes.TwoHanded, 10, 2, 17, 2,  0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( ScarletDrops.ScarletSorcerer, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )};	
			/*****************************/
			BCAddon.Hp( this, 2466, 37 );
			/*****************************/			
		}
	}
}

namespace Server.Creatures
{
	public class ScarletSpellbinder: BaseCreature
	{
		public ScarletSpellbinder() : base()
		{
			Name = "Scarlet Spellbinder";
			Id = 4494;
			Model = 10307;
			Level = RandomLevel(57,58);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 1320;
			Armor = 5*Level;
			Block = 0;
			Flags1=0x080000;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/2.5f);
			BaseMana = 5950;
			BoundingRadius = 1.07550f;
			CombatReach = 10.3500f;
			Speed = 5f;
			WalkSpeed = 5f;
			RunSpeed = 7.0f;
			Faction = Factions.Monster;
			AIEngine = new GroupInteligentSpellCasterAI( this );
			NpcType = 7;	
			Unk3=1;
			Loots = new BaseTreasure[]{  new BaseTreasure( ScarletDrops.ScarletSpellbinder, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};	
			/*****************************/
			BCAddon.Hp( this, 5950, 57 );
			/*****************************/			
		}
	}
}

namespace Server.Creatures
{
	public class ScarletTorturer: BaseCreature
	{
		public ScarletTorturer() : base()
		{
			Name = "Scarlet Torturer";
			Id = 4306;
			Model = 2607;
			Level = RandomLevel(30,31);
			SetDamage(1f+2.88f*Level,1f+3.1*Level);			
			AttackSpeed = 2000;
			Armor = 55*Level;
			Block = 0;
			Flags1=0x080000;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.30550f;
			CombatReach = 0.3500f;
			Speed = 4.7f;
			WalkSpeed = 4.7f;
			RunSpeed = 6.0f;
			Faction = Factions.Monster;
			AIEngine = new BerserkerAI( this );
			NpcType = 7;	
			Elite=1; //elite
			Equip( new Item(8087, InventoryTypes.OneHand, 14, 1, 13, 3,  0, 0, 0 ));	
			Loots = new BaseTreasure[]{  new BaseTreasure( ScarletDrops.ScarletTorturer, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )};	
			/*****************************/
			BCAddon.Hp( this, 1858, 30 );
			/*****************************/			
		}
	}
}

namespace Server.Creatures
{
	public class ScarletTrackingHound: BaseCreature
	{
		public ScarletTrackingHound() : base()
		{
			Name = "Scarlet Tracking Hound";
			Id = 4304;
			Model = 2709;
			Level = RandomLevel(33,34);
			SetDamage(1f+2.88f*Level,1f+3.1*Level);			
			AttackSpeed = 1500;
			Armor = 55*Level;
			Block = 0;
			Flags1=0x080000;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.30550f;
			CombatReach = 0.3500f;
			Speed = 4.7f;
			WalkSpeed = 4.7f;
			RunSpeed = 6.0f;
			Size=0.850000f;
			Faction = Factions.Monster;
			AIEngine = new BerserkerAI( this );
			NpcType = 7;	
			Elite=1; //elite
			Loots = new BaseTreasure[]{  new BaseTreasure( ScarletDrops.ScarletTrackingHound, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )};	
			/*****************************/
			BCAddon.Hp( this, 3265, 33 );
			/*****************************/			
		}
	}
}

namespace Server.Creatures
{
	public class ScarletTrainee: BaseCreature
	{
		public ScarletTrainee() : base()
		{
			Name = "Scarlet Trainee";
			Id = 6575;
			Model = 10413;
			Level = RandomLevel(30);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 5*Level;
			Block = 0;
			ResistArcane = 10;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/2.5f);
			BoundingRadius = 0.2077550f;
			CombatReach = 1.300f;
			Speed = 3.2f;
			WalkSpeed =3.2f;
			RunSpeed = 7.0f;
			Faction = Factions.Monster;
			AIEngine = new GroupInteligentSpellCasterAI( this );
			NpcType = 7;	
			Unk3=1; 
			Equip( new Item(7478, InventoryTypes.OneHand, 4, 2, 13, 3,  0, 0, 0 ));		
			Loots = new BaseTreasure[]{  new BaseTreasure( ScarletDrops.ScarletTrainee, 100f ),
							new BaseTreasure(Drops.MoneyC, 100f )};	
			/*****************************/
			BCAddon.Hp( this, 1500, 30 );
			/*****************************/	
		}
	}
}

namespace Server.Creatures
{
	public class ScarletTrooper: BaseCreature
	{
		public ScarletTrooper() : base()
		{
			Name = "Scarlet Trooper";
			Id = 12352;
			Model = 10503;
			Level = RandomLevel(58,59);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 5*Level;
			Block = 0;
			ResistArcane = 10;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/2.5f);
			BoundingRadius = 0.2077550f;
			CombatReach = 0.600f;
			Speed = 3.2f;
			WalkSpeed =3.2f;
			RunSpeed = 7.0f;
			Faction = Factions.Monster;
			AIEngine = new GroupInteligentSpellCasterAI( this );
			NpcType = 7;	
			Unk3=1; 
			Equip( new Item(7478, InventoryTypes.OneHand, 4, 2, 13, 3,  0, 0, 0 ));				
			Loots = new BaseTreasure[]{  new BaseTreasure( ScarletDrops.ScarletTrooper, 100f ),
						     new BaseTreasure( LowNoCategoryDrops.LowNoCategory, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};	
			/*****************************/
			BCAddon.Hp( this, 1820, 58 );
			/*****************************/	
		}
	}
}

namespace Server.Creatures
{
	public class ScarletVanguard: BaseCreature
	{
		public ScarletVanguard() : base()
		{
			Name = "Scarlet Vanguard";
			Id = 1540;
			Model = 2470;
			Level = RandomLevel(10,11);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 5*Level;
			Block = 0;
			ResistArcane = 10;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/2.5f);
			BoundingRadius = 0.2077550f;
			CombatReach = 0.600f;
			Speed = 3f;
			WalkSpeed =3f;
			RunSpeed = 5.0f;
			Faction = Factions.Monster;
			AIEngine = new BerserkerAI( this );
			NpcType = 7;	
			Unk3=1; 
			Equip( new Item(7483, InventoryTypes.OneHand, 7, 1, 13, 3,  0, 0, 0 ), new Item(1705, InventoryTypes.Shield, 6, 1, 14, 4,  0, 0, 0 ));				
			Loots = new BaseTreasure[]{  new BaseTreasure( ScarletDrops.ScarletVanguard, 100f ),
							new BaseTreasure(Drops.MoneyA, 100f )};	
			/*****************************/
			BCAddon.Hp( this, 191, 10 );
			/*****************************/	
		}
	}
}

namespace Server.Creatures
{
	public class ScarletWarder: BaseCreature
	{
		public ScarletWarder() : base()
		{
			Name = "Scarlet Warder";
			Id = 9447;
			Model = 10376;
			Level = RandomLevel(53,54);
			SetDamage(1f+2.88f*Level,1f+3.1*Level);			
			AttackSpeed = 1197;
			Armor = 55*Level;
			Block = 0;
			Flags1=0x080000;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.30550f;
			CombatReach = 15.3500f;
			Speed = 3.7f;
			WalkSpeed = 3.7f;
			RunSpeed = 5.5f;
			Faction = Factions.Monster;
			AIEngine = new BerserkerAI( this );
			NpcType = 7;	
			Elite=1; //elite
			Equip( new Item(8078, InventoryTypes.OneHand, 14, 1, 13, 3,  0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( ScarletDrops.ScarletWarder, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )};	
			/*****************************/
			BCAddon.Hp( this, 4520, 53 );
			/*****************************/			
		}
	}
}

namespace Server.Creatures
{
	public class ScarletWarrior: BaseCreature
	{
		public ScarletWarrior() : base()
		{
			Name = "Scarlet Warrior";
			Id = 1535;
			Model = 2482;
			Level = RandomLevel(6,7);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 5*Level;
			Block = 0;
			ResistArcane = 10;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/2.5f);
			BoundingRadius = 0.2077550f;
			CombatReach = 0.600f;
			Speed = 2.8f;
			WalkSpeed =2.8f;
			RunSpeed = 4.3f;
			Faction = Factions.Monster;
			AIEngine = new BerserkerAI( this );
			NpcType = 7;	
			Unk3=1; 
			Equip( new Item(7483, InventoryTypes.OneHand, 7, 1, 13, 3,  0, 0, 0 ));				
		 	Loots = new BaseTreasure[]{  new BaseTreasure( ScarletDrops.ScarletWarrior, 100f ),
							new BaseTreasure(Drops.MoneyA, 100f )};	
			/*****************************/
			BCAddon.Hp( this, 112, 6 );
			/*****************************/	
		}
	}
}

namespace Server.Creatures
{
	public class ScarletWizard: BaseCreature
	{
		public ScarletWizard() : base()
		{
			Name = "Scarlet Wizard";
			Id = 4300;
			Model = 2525;
			Level = RandomLevel(38,39);
			SetDamage(1f+2.88f*Level,1f+3.1*Level);			
			AttackSpeed = 2000;
			Armor = 5*Level;
			Block = 0;
			ResistArcane = 10;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.2077550f;
			CombatReach = 1.300f;
			Speed = 3.8f;
			WalkSpeed =4.8f;
			RunSpeed = 6.8f;
			Faction = Factions.Monster;
			AIEngine = new GroupInteligentSpellCasterAI( this );
			NpcType = 7;	
			Elite=1; //elite
			Equip( new Item(1599, InventoryTypes.TwoHanded, 10, 2, 17, 2,  0, 0, 0 ));		
			Loots = new BaseTreasure[]{  new BaseTreasure( ScarletDrops.ScarletWizard, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )};	
			/*****************************/
			BCAddon.Hp( this, 2407, 38 );
			/*****************************/	
		}
	}
}

namespace Server.Creatures
{
	public class ScarletZealot: BaseCreature
	{
		public ScarletZealot() : base()
		{
			Name = "Scarlet Zealot";
			Id = 1537;
			Model = 2472;
			Level = RandomLevel(8,9);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 5*Level;
			Block = 0;
			ResistArcane = 10;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/2.5f);
			BoundingRadius = 0.2077550f;
			CombatReach = 0.600f;
			Speed = 2.8f;
			WalkSpeed =2.8f;
			RunSpeed = 4.3f;
			Faction = Factions.Monster;
			AIEngine = new BerserkerAI( this );
			NpcType = 7;	
			Unk3=1; 
			Equip( new Item(7490, InventoryTypes.TwoHanded, 8, 1, 17, 1,  0, 0, 0 ));		
			Loots = new BaseTreasure[]{  new BaseTreasure( ScarletDrops.ScarletZealot, 100f ),
							new BaseTreasure(Drops.MoneyA, 100f )};	
			/*****************************/
			BCAddon.Hp( this, 123, 8 );
			/*****************************/	
		}
	}
}

namespace Server.Creatures
{
	public class ScarletWorker: BaseCreature
	{
		public ScarletWorker() : base()
		{
			Name = "Scarlet Worker";
			Id = 1883;
			Model = 10303;
			Level = RandomLevel(55,57);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 1400;
			Armor = 5*Level;
			Block = 0;
			ResistArcane = 10;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/2.5f);
			BoundingRadius = 0.2077550f;
			CombatReach = 0.600f;
			Speed = 3.8f;
			WalkSpeed =3.8f;
			RunSpeed = 5.3f;
			Faction = Factions.Monster;
			AIEngine = new BerserkerAI( this );
			NpcType = 7;	
			Unk3=1; 
		 	Loots = new BaseTreasure[]{  new BaseTreasure( ScarletDrops.ScarletWorker, 100f ),
						     new BaseTreasure(Drops.MoneyA, 100f )};	
			/*****************************/
			BCAddon.Hp( this, 123, 8 );
			/*****************************/	
		}
	}
}



namespace Server.Creatures
{
	public class ScarletSnake : BaseCreature
	{
		public ScarletSnake() : base()
		{
			Name = "Scarlet Snake";
			Id = 7566;
			Model = 2954;
			Level = RandomLevel(1);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 0;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/2.5f);
			BoundingRadius = 0.2077550f;
			CombatReach = 0.600f;
			Speed = 3.8f;
			WalkSpeed =3.8f;
			RunSpeed = 5.3f;
			Faction = Factions.NoFaction;
			AIEngine = new DefensiveAnimalAI( this );
			NpcType = (int)NpcTypes.Beast ;
			Unk3=1; 

			/*****************************/
			BCAddon.Hp( this, 32, 1 );
			/*****************************/	
		}
	}
}


namespace Server.Creatures
{
	public class ScarletCavalier: BaseCreature
	{
		public ScarletCavalier() : base()
		{
			Name = "Scarlet Cavalier";
			Id = 1836;
			Model = 10336;
			Level = RandomLevel(58);
			SetDamage(1f+2.88f*Level,1f+3.1*Level);			
			AttackSpeed = 2000;
			Armor = 150*Level;
			Block = 0;
			Flags1=0x080000;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 10;
			Str = (int)(Level/1.5f);
			BoundingRadius = 0.3077550f;
			CombatReach = 0.300f;
			Speed = 3.5f;
			WalkSpeed = 3.5f;
			RunSpeed = 6.5f;
			Faction = Factions.Monster;
			AIEngine = new BerserkerAI( this );
			NpcType = 7;	
			Elite=1; //elite
			//Equip(new FightClub());			
			Loots = new BaseTreasure[]{  new BaseTreasure( ScarletDrops.ScarletCavalier, 100f ),
							new BaseTreasure( LowNoCategoryDrops.LowNoCategory, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )};
			/*****************************/
			BCAddon.Hp( this, 5568, 58 );
			/*****************************/			
		}
	}
}