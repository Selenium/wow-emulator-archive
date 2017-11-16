/**************************************************************
*
*		Made by fulgas (fulgas@gmail.com)
*
*  WowwoW Item Designer ( 2005/8/23 - 10:06:37 )
*
***************************************************************/

using System;
using System.Collections;

/***************************************************************/

/**************************************************************
*
*				(Double-barreled Shotgun)
*
***************************************************************/

namespace Server.Items
{
	public class DoubleBarreledShotgun : Item
	{
		public DoubleBarreledShotgun() : base()
		{
			Id = 2098;
			Bonding = 2;
			SellPrice = 3020;
			AvailableClasses = 0x7FFF;
			Model = 28718;
			ObjectClass = 2;
			SubClass = 3;
			Level = 27;
			ReqLevel = 22;
			Name = "Double-barreled Shotgun";
			Name2 = "Double-barreled Shotgun";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 15104;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2300;
			Stackable = 1;
			Material = 1;
			Durability = 70;
			AmmoType = 3;
			SetDamage( 21 , 40 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Dwarven Hand Cannon)
*
***************************************************************/

namespace Server.Items
{
	public class DwarvenHandCannon : Item
	{
		public DwarvenHandCannon() : base()
		{
			Id = 2099;
			Bonding = 2;
			SellPrice = 45040;
			AvailableClasses = 0x7FFF;
			Model = 28636;
			ObjectClass = 2;
			SubClass = 3;
			Level = 58;
			ReqLevel = 53;
			Name = "Dwarven Hand Cannon";
			Name2 = "Dwarven Hand Cannon";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 225203;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2900;
			Stackable = 1;
			Material = 1;
			Durability = 90;
			AmmoType = 3;
			SetDamage( 66 , 124 , Resistances.Armor );
			SetDamage( 1 , 11 , Resistances.Fire );
		}
	}
}


/**************************************************************
*
*				(Precisely Calibrated Boomstick)
*
***************************************************************/

namespace Server.Items
{
	public class PreciselyCalibratedBoomstick : Item
	{
		public PreciselyCalibratedBoomstick() : base()
		{
			Id = 2100;
			Bonding = 2;
			SellPrice = 24539;
			AvailableClasses = 0x7FFF;
			Model = 8258;
			ObjectClass = 2;
			SubClass = 3;
			Level = 48;
			ReqLevel = 43;
			Name = "Precisely Calibrated Boomstick";
			Name2 = "Precisely Calibrated Boomstick";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 122699;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1500;
			Stackable = 1;
			Material = 1;
			Durability = 90;
			AmmoType = 3;
			SetDamage( 38 , 45 , Resistances.Armor );
			AgilityBonus = 14;
		}
	}
}


/**************************************************************
*
*				(Old Blunderbuss)
*
***************************************************************/

namespace Server.Items
{
	public class OldBlunderbuss : Item
	{
		public OldBlunderbuss() : base()
		{
			Id = 2508;
			SellPrice = 5;
			AvailableClasses = 0x7FFF;
			Model = 6606;
			ObjectClass = 2;
			SubClass = 3;
			Level = 2;
			ReqLevel = 1;
			Name = "Old Blunderbuss";
			Name2 = "Old Blunderbuss";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 27;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2300;
			Stackable = 1;
			Material = 1;
			Durability = 20;
			AmmoType = 3;
			SetDamage( 2 , 5 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Ornate Blunderbuss)
*
***************************************************************/

namespace Server.Items
{
	public class OrnateBlunderbuss : Item
	{
		public OrnateBlunderbuss() : base()
		{
			Id = 2509;
			SellPrice = 82;
			AvailableClasses = 0x7FFF;
			Model = 6607;
			ObjectClass = 2;
			SubClass = 3;
			Level = 9;
			ReqLevel = 4;
			Name = "Ornate Blunderbuss";
			Name2 = "Ornate Blunderbuss";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 414;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2200;
			Stackable = 1;
			Material = 1;
			Durability = 30;
			AmmoType = 3;
			SetDamage( 4 , 9 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Solid Blunderbuss)
*
***************************************************************/

namespace Server.Items
{
	public class SolidBlunderbuss : Item
	{
		public SolidBlunderbuss() : base()
		{
			Id = 2510;
			SellPrice = 8;
			AvailableClasses = 0x7FFF;
			Model = 6594;
			ObjectClass = 2;
			SubClass = 3;
			Level = 3;
			ReqLevel = 1;
			Name = "Solid Blunderbuss";
			Name2 = "Solid Blunderbuss";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 41;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2200;
			Stackable = 1;
			Material = 1;
			Durability = 20;
			AmmoType = 3;
			SetDamage( 3 , 6 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Hunter's Boomstick)
*
***************************************************************/

namespace Server.Items
{
	public class HuntersBoomstick : Item
	{
		public HuntersBoomstick() : base()
		{
			Id = 2511;
			SellPrice = 264;
			AvailableClasses = 0x7FFF;
			Model = 20728;
			ObjectClass = 2;
			SubClass = 3;
			Level = 14;
			ReqLevel = 9;
			Name = "Hunter's Boomstick";
			Name2 = "Hunter's Boomstick";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1324;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2100;
			Stackable = 1;
			Material = 1;
			Durability = 40;
			AmmoType = 3;
			SetDamage( 7 , 14 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Rust-covered Blunderbuss)
*
***************************************************************/

namespace Server.Items
{
	public class RustCoveredBlunderbuss : Item
	{
		public RustCoveredBlunderbuss() : base()
		{
			Id = 2774;
			SellPrice = 28;
			AvailableClasses = 0x7FFF;
			Model = 20654;
			ObjectClass = 2;
			SubClass = 3;
			Level = 7;
			ReqLevel = 2;
			Name = "Rust-covered Blunderbuss";
			Name2 = "Rust-covered Blunderbuss";
			AvailableRaces = 0x1FF;
			BuyPrice = 140;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2400;
			Stackable = 1;
			Material = 1;
			Durability = 30;
			AmmoType = 3;
			SetDamage( 3 , 6 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Cheap Blunderbuss)
*
***************************************************************/

namespace Server.Items
{
	public class CheapBlunderbuss : Item
	{
		public CheapBlunderbuss() : base()
		{
			Id = 2778;
			SellPrice = 147;
			AvailableClasses = 0x7FFF;
			Model = 20654;
			ObjectClass = 2;
			SubClass = 3;
			Level = 13;
			ReqLevel = 8;
			Name = "Cheap Blunderbuss";
			Name2 = "Cheap Blunderbuss";
			AvailableRaces = 0x1FF;
			BuyPrice = 737;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2200;
			Stackable = 1;
			Material = 1;
			Durability = 35;
			AmmoType = 3;
			SetDamage( 5 , 9 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Dirty Blunderbuss)
*
***************************************************************/

namespace Server.Items
{
	public class DirtyBlunderbuss : Item
	{
		public DirtyBlunderbuss() : base()
		{
			Id = 2781;
			SellPrice = 335;
			AvailableClasses = 0x7FFF;
			Model = 20979;
			ObjectClass = 2;
			SubClass = 3;
			Level = 18;
			ReqLevel = 13;
			Name = "Dirty Blunderbuss";
			Name2 = "Dirty Blunderbuss";
			AvailableRaces = 0x1FF;
			BuyPrice = 1676;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2200;
			Stackable = 1;
			Material = 1;
			Durability = 45;
			AmmoType = 3;
			SetDamage( 6 , 12 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Shoddy Blunderbuss)
*
***************************************************************/

namespace Server.Items
{
	public class ShoddyBlunderbuss : Item
	{
		public ShoddyBlunderbuss() : base()
		{
			Id = 2783;
			SellPrice = 590;
			AvailableClasses = 0x7FFF;
			Model = 20717;
			ObjectClass = 2;
			SubClass = 3;
			Level = 22;
			ReqLevel = 17;
			Name = "Shoddy Blunderbuss";
			Name2 = "Shoddy Blunderbuss";
			AvailableRaces = 0x1FF;
			BuyPrice = 2954;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2100;
			Stackable = 1;
			Material = 1;
			Durability = 50;
			AmmoType = 3;
			SetDamage( 7 , 14 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Oiled Blunderbuss)
*
***************************************************************/

namespace Server.Items
{
	public class OiledBlunderbuss : Item
	{
		public OiledBlunderbuss() : base()
		{
			Id = 2786;
			SellPrice = 1173;
			AvailableClasses = 0x7FFF;
			Model = 20718;
			ObjectClass = 2;
			SubClass = 3;
			Level = 29;
			ReqLevel = 24;
			Name = "Oiled Blunderbuss";
			Name2 = "Oiled Blunderbuss";
			AvailableRaces = 0x1FF;
			BuyPrice = 5865;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2000;
			Stackable = 1;
			Material = 1;
			Durability = 65;
			AmmoType = 3;
			SetDamage( 9 , 19 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Daryl's Hunting Rifle)
*
***************************************************************/

namespace Server.Items
{
	public class DarylsHuntingRifle : Item
	{
		public DarylsHuntingRifle() : base()
		{
			Id = 2904;
			Bonding = 1;
			SellPrice = 595;
			AvailableClasses = 0x7FFF;
			Model = 20732;
			ObjectClass = 2;
			SubClass = 3;
			Level = 16;
			Name = "Daryl's Hunting Rifle";
			Name2 = "Daryl's Hunting Rifle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2977;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2500;
			Stackable = 1;
			Material = 1;
			Durability = 40;
			AmmoType = 3;
			SetDamage( 11 , 21 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Large Bore Blunderbuss)
*
***************************************************************/

namespace Server.Items
{
	public class LargeBoreBlunderbuss : Item
	{
		public LargeBoreBlunderbuss() : base()
		{
			Id = 3023;
			SellPrice = 754;
			AvailableClasses = 0x7FFF;
			Model = 20727;
			ObjectClass = 2;
			SubClass = 3;
			Level = 21;
			ReqLevel = 16;
			Name = "Large Bore Blunderbuss";
			Name2 = "Large Bore Blunderbuss";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 3771;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2500;
			Stackable = 1;
			Material = 1;
			Durability = 50;
			AmmoType = 3;
			SetDamage( 13 , 24 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(BKP 2700 "Enforcer")
*
***************************************************************/

namespace Server.Items
{
	public class BKP2700Enforcer : Item
	{
		public BKP2700Enforcer() : base()
		{
			Id = 3024;
			SellPrice = 1419;
			AvailableClasses = 0x7FFF;
			Model = 20726;
			ObjectClass = 2;
			SubClass = 3;
			Level = 26;
			ReqLevel = 21;
			Name = "BKP 2700 Enforcer";
			Name2 = "BKP 2700 Enforcer";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 7098;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2700;
			Stackable = 1;
			Material = 1;
			Durability = 60;
			AmmoType = 3;
			SetDamage( 18 , 34 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(BKP 42 "Ultra")
*
***************************************************************/

namespace Server.Items
{
	public class BKP42Ultra : Item
	{
		public BKP42Ultra() : base()
		{
			Id = 3025;
			SellPrice = 3695;
			AvailableClasses = 0x7FFF;
			Model = 20725;
			ObjectClass = 2;
			SubClass = 3;
			Level = 36;
			ReqLevel = 31;
			Name = "BKP 42 Ultra";
			Name2 = "BKP 42 Ultra";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 18478;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2100;
			Stackable = 1;
			Material = 1;
			Durability = 65;
			AmmoType = 3;
			SetDamage( 20 , 38 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Hunter's Muzzle Loader)
*
***************************************************************/

namespace Server.Items
{
	public class HuntersMuzzleLoader : Item
	{
		public HuntersMuzzleLoader() : base()
		{
			Id = 3040;
			Bonding = 2;
			SellPrice = 940;
			AvailableClasses = 0x7FFF;
			Model = 20740;
			ObjectClass = 2;
			SubClass = 3;
			Level = 19;
			ReqLevel = 14;
			Name = "Hunter's Muzzle Loader";
			Name2 = "Hunter's Muzzle Loader";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4701;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1800;
			Stackable = 1;
			Material = 1;
			Durability = 45;
			AmmoType = 3;
			SetDamage( 9 , 18 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				("Mage-Eye" Blunderbuss)
*
***************************************************************/

namespace Server.Items
{
	public class MageEyeBlunderbuss : Item
	{
		public MageEyeBlunderbuss() : base()
		{
			Id = 3041;
			Bonding = 2;
			SellPrice = 3769;
			AvailableClasses = 0x7FFF;
			Model = 20729;
			ObjectClass = 2;
			SubClass = 3;
			Level = 31;
			ReqLevel = 26;
			Name = "Mage-Eye Blunderbuss";
			Name2 = "Mage-Eye Blunderbuss";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 18846;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2800;
			Stackable = 1;
			Material = 1;
			Durability = 65;
			AmmoType = 3;
			SetDamage( 24 , 46 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(BKP "Sparrow" Smallbore)
*
***************************************************************/

namespace Server.Items
{
	public class BKPSparrowSmallbore : Item
	{
		public BKPSparrowSmallbore() : base()
		{
			Id = 3042;
			Bonding = 2;
			SellPrice = 4577;
			AvailableClasses = 0x7FFF;
			Model = 20734;
			ObjectClass = 2;
			SubClass = 3;
			Level = 33;
			ReqLevel = 28;
			Name = "BKP Sparrow Smallbore";
			Name2 = "BKP Sparrow Smallbore";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 22887;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1700;
			Stackable = 1;
			Material = 1;
			Durability = 65;
			AmmoType = 3;
			SetDamage( 15 , 30 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Skorn's Rifle)
*
***************************************************************/

namespace Server.Items
{
	public class SkornsRifle : Item
	{
		public SkornsRifle() : base()
		{
			Id = 3079;
			Bonding = 1;
			SellPrice = 297;
			AvailableClasses = 0x7FFF;
			Model = 20738;
			ObjectClass = 2;
			SubClass = 3;
			Level = 12;
			Name = "Skorn's Rifle";
			Name2 = "Skorn's Rifle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1486;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1900;
			Stackable = 1;
			Material = 1;
			Durability = 35;
			AmmoType = 3;
			SetDamage( 6 , 13 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Sniper Rifle)
*
***************************************************************/

namespace Server.Items
{
	public class SniperRifle : Item
	{
		public SniperRifle() : base()
		{
			Id = 3430;
			Bonding = 2;
			SellPrice = 11026;
			AvailableClasses = 0x7FFF;
			Model = 6612;
			ObjectClass = 2;
			SubClass = 3;
			Level = 44;
			ReqLevel = 39;
			Name = "Sniper Rifle";
			Name2 = "Sniper Rifle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5852;
			BuyPrice = 55134;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 3000;
			Stackable = 1;
			Material = 1;
			Durability = 65;
			AmmoType = 3;
			SetDamage( 56 , 65 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Dwarven Fishing Pole)
*
***************************************************************/

namespace Server.Items
{
	public class DwarvenFishingPole : Item
	{
		public DwarvenFishingPole() : base()
		{
			Id = 3567;
			Bonding = 1;
			SellPrice = 922;
			AvailableClasses = 0x7FFF;
			Description = "Dwarves aren't known for their subtlety.";
			Model = 6601;
			ObjectClass = 2;
			SubClass = 3;
			Level = 19;
			Name = "Dwarven Fishing Pole";
			Name2 = "Dwarven Fishing Pole";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4613;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1900;
			Stackable = 1;
			Material = 1;
			Durability = 45;
			AmmoType = 3;
			SetDamage( 9 , 19 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Long-barreled Musket)
*
***************************************************************/

namespace Server.Items
{
	public class LongBarreledMusket : Item
	{
		public LongBarreledMusket() : base()
		{
			Id = 3780;
			SellPrice = 1877;
			AvailableClasses = 0x7FFF;
			Model = 20717;
			ObjectClass = 2;
			SubClass = 3;
			Level = 33;
			ReqLevel = 28;
			Name = "Long-barreled Musket";
			Name2 = "Long-barreled Musket";
			AvailableRaces = 0x1FF;
			BuyPrice = 9388;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2600;
			Stackable = 1;
			Material = 1;
			Durability = 65;
			AmmoType = 3;
			SetDamage( 14 , 27 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Sentinel Musket)
*
***************************************************************/

namespace Server.Items
{
	public class SentinelMusket : Item
	{
		public SentinelMusket() : base()
		{
			Id = 4026;
			SellPrice = 4362;
			AvailableClasses = 0x7FFF;
			Model = 20721;
			ObjectClass = 2;
			SubClass = 3;
			Level = 43;
			ReqLevel = 38;
			Name = "Sentinel Musket";
			Name2 = "Sentinel Musket";
			AvailableRaces = 0x1FF;
			BuyPrice = 21812;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2800;
			Stackable = 1;
			Material = 1;
			Durability = 65;
			AmmoType = 3;
			SetDamage( 22 , 43 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Flash Rifle)
*
***************************************************************/

namespace Server.Items
{
	public class FlashRifle : Item
	{
		public FlashRifle() : base()
		{
			Id = 4086;
			Bonding = 1;
			SellPrice = 6386;
			AvailableClasses = 0x7FFF;
			Model = 20736;
			ObjectClass = 2;
			SubClass = 3;
			Level = 37;
			Name = "Flash Rifle";
			Name2 = "Flash Rifle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 31934;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1800;
			Stackable = 1;
			Material = 1;
			Durability = 65;
			AmmoType = 3;
			SetDamage( 19 , 36 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Ricochet Blunderbuss)
*
***************************************************************/

namespace Server.Items
{
	public class RicochetBlunderbuss : Item
	{
		public RicochetBlunderbuss() : base()
		{
			Id = 4089;
			Bonding = 2;
			SellPrice = 15060;
			AvailableClasses = 0x7FFF;
			Model = 6592;
			ObjectClass = 2;
			SubClass = 3;
			Level = 48;
			ReqLevel = 43;
			Name = "Ricochet Blunderbuss";
			Name2 = "Ricochet Blunderbuss";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5853;
			BuyPrice = 75302;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2300;
			Stackable = 1;
			Material = 1;
			Durability = 65;
			AmmoType = 3;
			SetDamage( 36 , 67 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Master Hunter's Rifle)
*
***************************************************************/

namespace Server.Items
{
	public class MasterHuntersRifle : Item
	{
		public MasterHuntersRifle() : base()
		{
			Id = 4111;
			Bonding = 1;
			SellPrice = 12042;
			AvailableClasses = 0x7FFF;
			Model = 8095;
			ObjectClass = 2;
			SubClass = 3;
			Level = 45;
			Name = "Master Hunter's Rifle";
			Name2 = "Master Hunter's Rifle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 60214;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2600;
			Stackable = 1;
			Material = 1;
			Durability = 65;
			AmmoType = 3;
			Flags = 16;
			SetDamage( 37 , 70 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Shrapnel Blaster)
*
***************************************************************/

namespace Server.Items
{
	public class ShrapnelBlaster : Item
	{
		public ShrapnelBlaster() : base()
		{
			Id = 4127;
			Bonding = 1;
			SellPrice = 8073;
			AvailableClasses = 0x7FFF;
			Model = 20662;
			ObjectClass = 2;
			SubClass = 3;
			Level = 40;
			Name = "Shrapnel Blaster";
			Name2 = "Shrapnel Blaster";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 40368;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1900;
			Stackable = 1;
			Material = 1;
			Durability = 65;
			AmmoType = 3;
			SetDamage( 23 , 43 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Rough Boomstick)
*
***************************************************************/

namespace Server.Items
{
	public class RoughBoomstick : Item
	{
		public RoughBoomstick() : base()
		{
			Id = 4362;
			Bonding = 2;
			SellPrice = 187;
			AvailableClasses = 0x7FFF;
			Model = 6600;
			ObjectClass = 2;
			SubClass = 3;
			Level = 10;
			ReqLevel = 5;
			Name = "Rough Boomstick";
			Name2 = "Rough Boomstick";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 938;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2300;
			Stackable = 1;
			Material = 1;
			Durability = 35;
			AmmoType = 3;
			SetDamage( 6 , 13 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Deadly Blunderbuss)
*
***************************************************************/

namespace Server.Items
{
	public class DeadlyBlunderbuss : Item
	{
		public DeadlyBlunderbuss() : base()
		{
			Id = 4369;
			Bonding = 2;
			SellPrice = 1179;
			AvailableClasses = 0x7FFF;
			Model = 20743;
			ObjectClass = 2;
			SubClass = 3;
			Level = 21;
			ReqLevel = 16;
			Name = "Deadly Blunderbuss";
			Name2 = "Deadly Blunderbuss";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5899;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2600;
			Stackable = 1;
			Material = 1;
			Durability = 50;
			AmmoType = 3;
			SetDamage( 15 , 28 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Lovingly Crafted Boomstick)
*
***************************************************************/

namespace Server.Items
{
	public class LovinglyCraftedBoomstick : Item
	{
		public LovinglyCraftedBoomstick() : base()
		{
			Id = 4372;
			Bonding = 2;
			SellPrice = 1800;
			AvailableClasses = 0x7FFF;
			Model = 6594;
			ObjectClass = 2;
			SubClass = 3;
			Level = 24;
			ReqLevel = 19;
			Name = "Lovingly Crafted Boomstick";
			Name2 = "Lovingly Crafted Boomstick";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 9000;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1800;
			Stackable = 1;
			Material = 1;
			Durability = 55;
			AmmoType = 3;
			SetDamage( 12 , 23 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Silver-plated Shotgun)
*
***************************************************************/

namespace Server.Items
{
	public class SilverPlatedShotgun : Item
	{
		public SilverPlatedShotgun() : base()
		{
			Id = 4379;
			Bonding = 2;
			SellPrice = 2357;
			AvailableClasses = 0x7FFF;
			Model = 15835;
			ObjectClass = 2;
			SubClass = 3;
			Level = 26;
			ReqLevel = 21;
			Name = "Silver-plated Shotgun";
			Name2 = "Silver-plated Shotgun";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11788;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2700;
			Stackable = 1;
			Material = 1;
			Durability = 60;
			AmmoType = 3;
			SetDamage( 19 , 37 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Moonsight Rifle)
*
***************************************************************/

namespace Server.Items
{
	public class MoonsightRifle : Item
	{
		public MoonsightRifle() : base()
		{
			Id = 4383;
			Bonding = 2;
			SellPrice = 3183;
			AvailableClasses = 0x7FFF;
			Model = 8257;
			ObjectClass = 2;
			SubClass = 3;
			Level = 29;
			ReqLevel = 24;
			Name = "Moonsight Rifle";
			Name2 = "Moonsight Rifle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 15915;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1700;
			Stackable = 1;
			Material = 1;
			Durability = 65;
			AmmoType = 3;
			SetDamage( 14 , 26 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Compact Shotgun)
*
***************************************************************/

namespace Server.Items
{
	public class CompactShotgun : Item
	{
		public CompactShotgun() : base()
		{
			Id = 4577;
			Bonding = 2;
			SellPrice = 356;
			AvailableClasses = 0x7FFF;
			Model = 6592;
			ObjectClass = 2;
			SubClass = 3;
			Level = 13;
			ReqLevel = 8;
			Name = "Compact Shotgun";
			Name2 = "Compact Shotgun";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1784;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2000;
			Stackable = 1;
			Material = 1;
			Durability = 35;
			AmmoType = 3;
			SetDamage( 7 , 14 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Privateer Musket)
*
***************************************************************/

namespace Server.Items
{
	public class PrivateerMusket : Item
	{
		public PrivateerMusket() : base()
		{
			Id = 5309;
			Bonding = 1;
			SellPrice = 1038;
			AvailableClasses = 0x7FFF;
			Model = 7531;
			ObjectClass = 2;
			SubClass = 3;
			Level = 20;
			Name = "Privateer Musket";
			Name2 = "Privateer Musket";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5190;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2300;
			Stackable = 1;
			Material = 1;
			Durability = 50;
			AmmoType = 3;
			SetDamage( 12 , 24 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Blasting Hackbut)
*
***************************************************************/

namespace Server.Items
{
	public class BlastingHackbut : Item
	{
		public BlastingHackbut() : base()
		{
			Id = 6798;
			Bonding = 1;
			SellPrice = 6386;
			AvailableClasses = 0x7FFF;
			Model = 13060;
			ObjectClass = 2;
			SubClass = 3;
			Level = 37;
			Name = "Blasting Hackbut";
			Name2 = "Blasting Hackbut";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 31934;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2800;
			Stackable = 1;
			Material = 1;
			Durability = 65;
			AmmoType = 3;
			SetDamage( 30 , 56 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Chesterfall Musket)
*
***************************************************************/

namespace Server.Items
{
	public class ChesterfallMusket : Item
	{
		public ChesterfallMusket() : base()
		{
			Id = 7729;
			Bonding = 2;
			SellPrice = 5514;
			AvailableClasses = 0x7FFF;
			Model = 15821;
			ObjectClass = 2;
			SubClass = 3;
			Level = 33;
			ReqLevel = 28;
			Name = "Chesterfall Musket";
			Name2 = "Chesterfall Musket";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 27573;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2300;
			Stackable = 1;
			Material = 1;
			Durability = 75;
			AmmoType = 3;
			SetDamage( 26 , 50 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Hunting Rifle)
*
***************************************************************/

namespace Server.Items
{
	public class HuntingRifle : Item
	{
		public HuntingRifle() : base()
		{
			Id = 8181;
			SellPrice = 79;
			AvailableClasses = 0x7FFF;
			Model = 20728;
			ObjectClass = 2;
			SubClass = 3;
			Level = 9;
			ReqLevel = 4;
			Name = "Hunting Rifle";
			Name2 = "Hunting Rifle";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 397;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2700;
			Stackable = 1;
			Material = 1;
			Durability = 30;
			AmmoType = 3;
			SetDamage( 5 , 11 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Pellet Rifle)
*
***************************************************************/

namespace Server.Items
{
	public class PelletRifle : Item
	{
		public PelletRifle() : base()
		{
			Id = 8182;
			SellPrice = 40;
			AvailableClasses = 0x7FFF;
			Model = 20741;
			ObjectClass = 2;
			SubClass = 3;
			Level = 7;
			ReqLevel = 2;
			Name = "Pellet Rifle";
			Name2 = "Pellet Rifle";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 203;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2600;
			Stackable = 1;
			Material = 1;
			Durability = 30;
			AmmoType = 3;
			SetDamage( 4 , 9 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Explosive Shotgun)
*
***************************************************************/

namespace Server.Items
{
	public class ExplosiveShotgun : Item
	{
		public ExplosiveShotgun() : base()
		{
			Id = 8188;
			Bonding = 2;
			SellPrice = 6414;
			AvailableClasses = 0x7FFF;
			Model = 20735;
			ObjectClass = 2;
			SubClass = 3;
			Level = 37;
			ReqLevel = 32;
			Name = "Explosive Shotgun";
			Name2 = "Explosive Shotgun";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 32071;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2100;
			Stackable = 1;
			Material = 1;
			Durability = 65;
			AmmoType = 3;
			SetDamage( 22 , 42 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Galgann's Fireblaster)
*
***************************************************************/

namespace Server.Items
{
	public class GalgannsFireblaster : Item
	{
		public GalgannsFireblaster() : base()
		{
			Id = 9412;
			Bonding = 1;
			SellPrice = 16681;
			AvailableClasses = 0x7FFF;
			Model = 18298;
			ObjectClass = 2;
			SubClass = 3;
			Level = 47;
			ReqLevel = 42;
			Name = "Galgann's Fireblaster";
			Name2 = "Galgann's Fireblaster";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 83405;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2600;
			Stackable = 1;
			Material = 1;
			Durability = 75;
			AmmoType = 3;
			SetDamage( 44 , 84 , Resistances.Armor );
			SetDamage( 1 , 3 , Resistances.Fire );
		}
	}
}


/**************************************************************
*
*				(Shadowforge Bushmaster)
*
***************************************************************/

namespace Server.Items
{
	public class ShadowforgeBushmaster : Item
	{
		public ShadowforgeBushmaster() : base()
		{
			Id = 9422;
			Bonding = 2;
			SellPrice = 13052;
			AvailableClasses = 0x7FFF;
			Model = 20663;
			ObjectClass = 2;
			SubClass = 3;
			Level = 43;
			ReqLevel = 38;
			Name = "Shadowforge Bushmaster";
			Name2 = "Shadowforge Bushmaster";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 65262;
			Resistance[5] = 7;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2900;
			Stackable = 1;
			Material = 1;
			Durability = 75;
			AmmoType = 3;
			SetDamage( 46 , 86 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Glass Shooter)
*
***************************************************************/

namespace Server.Items
{
	public class GlassShooter : Item
	{
		public GlassShooter() : base()
		{
			Id = 9456;
			Bonding = 1;
			SellPrice = 6652;
			AvailableClasses = 0x7FFF;
			Model = 18372;
			ObjectClass = 2;
			SubClass = 3;
			Level = 35;
			ReqLevel = 30;
			Name = "Glass Shooter";
			Name2 = "Glass Shooter";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 33262;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2900;
			Stackable = 1;
			Material = 1;
			Durability = 75;
			AmmoType = 3;
			SetDamage( 36 , 68 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Hi-tech Supergun)
*
***************************************************************/

namespace Server.Items
{
	public class HiTechSupergun : Item
	{
		public HiTechSupergun() : base()
		{
			Id = 9487;
			Bonding = 2;
			SellPrice = 3632;
			AvailableClasses = 0x7FFF;
			Model = 18405;
			ObjectClass = 2;
			SubClass = 3;
			Level = 29;
			ReqLevel = 24;
			Name = "Hi-tech Supergun";
			Name2 = "Hi-tech Supergun";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 18163;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2300;
			Stackable = 1;
			Material = 1;
			Durability = 75;
			AmmoType = 3;
			SetDamage( 23 , 43 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Mithril Blunderbuss)
*
***************************************************************/

namespace Server.Items
{
	public class MithrilBlunderbuss : Item
	{
		public MithrilBlunderbuss() : base()
		{
			Id = 10508;
			Bonding = 2;
			SellPrice = 8958;
			AvailableClasses = 0x7FFF;
			Model = 18298;
			ObjectClass = 2;
			SubClass = 3;
			Level = 41;
			ReqLevel = 36;
			Name = "Mithril Blunderbuss";
			Name2 = "Mithril Blunderbuss";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 44794;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2900;
			Stackable = 1;
			Material = 1;
			Durability = 65;
			AmmoType = 3;
			SetDamage( 36 , 68 , Resistances.Armor );
			AgilityBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Mithril Heavy-bore Rifle)
*
***************************************************************/

namespace Server.Items
{
	public class MithrilHeavyBoreRifle : Item
	{
		public MithrilHeavyBoreRifle() : base()
		{
			Id = 10510;
			Bonding = 2;
			SellPrice = 11369;
			AvailableClasses = 0x7FFF;
			Model = 20744;
			ObjectClass = 2;
			SubClass = 3;
			Level = 44;
			ReqLevel = 39;
			Name = "Mithril Heavy-bore Rifle";
			Name2 = "Mithril Heavy-bore Rifle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 56845;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2900;
			Stackable = 1;
			Material = 1;
			Durability = 65;
			AmmoType = 3;
			SetSpell( 21431 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 41 , 76 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Houndmaster's Rifle)
*
***************************************************************/

namespace Server.Items
{
	public class HoundmastersRifle : Item
	{
		public HoundmastersRifle() : base()
		{
			Id = 11629;
			Bonding = 1;
			SellPrice = 24527;
			AvailableClasses = 0x7FFF;
			Model = 28781;
			ObjectClass = 2;
			SubClass = 3;
			Level = 53;
			ReqLevel = 48;
			Name = "Houndmaster's Rifle";
			Name2 = "Houndmaster's Rifle";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 122635;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2300;
			Stackable = 1;
			Material = 1;
			Durability = 75;
			AmmoType = 3;
			SetSpell( 18201 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 44 , 82 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Anvilmar Musket)
*
***************************************************************/

namespace Server.Items
{
	public class AnvilmarMusket : Item
	{
		public AnvilmarMusket() : base()
		{
			Id = 12446;
			Bonding = 1;
			SellPrice = 19;
			AvailableClasses = 0x7FFF;
			Model = 28060;
			ObjectClass = 2;
			SubClass = 3;
			Level = 5;
			Name = "Anvilmar Musket";
			Name2 = "Anvilmar Musket";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 95;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2700;
			Stackable = 1;
			Material = 1;
			Durability = 25;
			AmmoType = 3;
			SetDamage( 4 , 8 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Light Hunting Rifle)
*
***************************************************************/

namespace Server.Items
{
	public class LightHuntingRifle : Item
	{
		public LightHuntingRifle() : base()
		{
			Id = 12448;
			Bonding = 1;
			SellPrice = 19;
			AvailableClasses = 0x7FFF;
			Model = 28206;
			ObjectClass = 2;
			SubClass = 3;
			Level = 5;
			Name = "Light Hunting Rifle";
			Name2 = "Light Hunting Rifle";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 96;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1900;
			Stackable = 1;
			Material = 1;
			Durability = 25;
			AmmoType = 3;
			SetDamage( 2 , 6 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Lil Timmy's Peashooter)
*
***************************************************************/

namespace Server.Items
{
	public class LilTimmysPeashooter : Item
	{
		public LilTimmysPeashooter() : base()
		{
			Id = 13136;
			Bonding = 2;
			SellPrice = 1456;
			AvailableClasses = 0x7FFF;
			Model = 21071;
			ObjectClass = 2;
			SubClass = 3;
			Level = 21;
			ReqLevel = 16;
			Name = "Lil Timmy's Peashooter";
			Name2 = "Lil Timmy's Peashooter";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 7280;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2600;
			Stackable = 1;
			Material = 1;
			Durability = 60;
			AmmoType = 3;
			SetDamage( 20 , 37 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Ironweaver)
*
***************************************************************/

namespace Server.Items
{
	public class Ironweaver : Item
	{
		public Ironweaver() : base()
		{
			Id = 13137;
			Bonding = 2;
			SellPrice = 5874;
			AvailableClasses = 0x7FFF;
			Model = 28786;
			ObjectClass = 2;
			SubClass = 3;
			Level = 34;
			ReqLevel = 29;
			Name = "Ironweaver";
			Name2 = "Ironweaver";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 29374;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2600;
			Stackable = 1;
			Material = 1;
			Durability = 75;
			AmmoType = 3;
			SetDamage( 31 , 59 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(The Silencer)
*
***************************************************************/

namespace Server.Items
{
	public class TheSilencer : Item
	{
		public TheSilencer() : base()
		{
			Id = 13138;
			Bonding = 2;
			SellPrice = 11532;
			AvailableClasses = 0x7FFF;
			Model = 28634;
			ObjectClass = 2;
			SubClass = 3;
			Level = 42;
			ReqLevel = 37;
			Name = "The Silencer";
			Name2 = "The Silencer";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 57661;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2800;
			Stackable = 1;
			Material = 1;
			Durability = 75;
			AmmoType = 3;
			SetSpell( 9142 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 43 , 82 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Guttbuster)
*
***************************************************************/

namespace Server.Items
{
	public class Guttbuster : Item
	{
		public Guttbuster() : base()
		{
			Id = 13139;
			Bonding = 2;
			SellPrice = 21029;
			AvailableClasses = 0x7FFF;
			Model = 28769;
			ObjectClass = 2;
			SubClass = 3;
			Level = 50;
			ReqLevel = 45;
			Name = "Guttbuster";
			Name2 = "Guttbuster";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 105149;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2700;
			Stackable = 1;
			Material = 1;
			Durability = 75;
			AmmoType = 3;
			SetDamage( 49 , 92 , Resistances.Armor );
			AgilityBonus = 8;
			StrBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Shell Launcher Shotgun)
*
***************************************************************/

namespace Server.Items
{
	public class ShellLauncherShotgun : Item
	{
		public ShellLauncherShotgun() : base()
		{
			Id = 13146;
			Bonding = 2;
			SellPrice = 34704;
			AvailableClasses = 0x7FFF;
			Model = 28743;
			ObjectClass = 2;
			SubClass = 3;
			Level = 58;
			ReqLevel = 53;
			Name = "Shell Launcher Shotgun";
			Name2 = "Shell Launcher Shotgun";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 173521;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2300;
			Stackable = 1;
			Material = 1;
			Durability = 75;
			AmmoType = 3;
			SetDamage( 48 , 89 , Resistances.Armor );
			SetDamage( 1 , 4 , Resistances.Fire );
		}
	}
}


/**************************************************************
*
*				(Burstshot Harquebus)
*
***************************************************************/

namespace Server.Items
{
	public class BurstshotHarquebus : Item
	{
		public BurstshotHarquebus() : base()
		{
			Id = 13248;
			Bonding = 1;
			SellPrice = 29669;
			AvailableClasses = 0x7FFF;
			Model = 8257;
			ObjectClass = 2;
			SubClass = 3;
			Level = 56;
			ReqLevel = 51;
			Name = "Burstshot Harquebus";
			Name2 = "Burstshot Harquebus";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 148349;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2600;
			Stackable = 1;
			Material = 1;
			Durability = 75;
			AmmoType = 3;
			SetSpell( 9140 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 52 , 98 , Resistances.Armor );
			IqBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Willey's Portable Howitzer)
*
***************************************************************/

namespace Server.Items
{
	public class WilleysPortableHowitzer : Item
	{
		public WilleysPortableHowitzer() : base()
		{
			Id = 13380;
			Bonding = 1;
			SellPrice = 38443;
			AvailableClasses = 0x7FFF;
			Model = 18298;
			ObjectClass = 2;
			SubClass = 3;
			Level = 61;
			ReqLevel = 56;
			Name = "Willey's Portable Howitzer";
			Name2 = "Willey's Portable Howitzer";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 192216;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2400;
			Stackable = 1;
			Material = 1;
			Durability = 75;
			AmmoType = 3;
			SetDamage( 52 , 98 , Resistances.Armor );
			StaminaBonus = 9;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Farmer Dalson's Shotgun)
*
***************************************************************/

namespace Server.Items
{
	public class FarmerDalsonsShotgun : Item
	{
		public FarmerDalsonsShotgun() : base()
		{
			Id = 13474;
			Bonding = 1;
			SellPrice = 24724;
			AvailableClasses = 0x7FFF;
			Model = 13060;
			ObjectClass = 2;
			SubClass = 3;
			Level = 56;
			Name = "Farmer Dalson's Shotgun";
			Name2 = "Farmer Dalson's Shotgun";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 123624;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1900;
			Stackable = 1;
			Material = 1;
			Durability = 65;
			AmmoType = 3;
			SetDamage( 34 , 64 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Primed Musket)
*
***************************************************************/

namespace Server.Items
{
	public class PrimedMusket : Item
	{
		public PrimedMusket() : base()
		{
			Id = 13825;
			SellPrice = 10168;
			AvailableClasses = 0x7FFF;
			Model = 20721;
			ObjectClass = 2;
			SubClass = 3;
			Level = 57;
			ReqLevel = 52;
			Name = "Primed Musket";
			Name2 = "Primed Musket";
			AvailableRaces = 0x1FF;
			BuyPrice = 50841;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1800;
			Stackable = 1;
			Material = 1;
			Durability = 65;
			AmmoType = 3;
			SetDamage( 20 , 37 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Owlsight Rifle)
*
***************************************************************/

namespace Server.Items
{
	public class OwlsightRifle : Item
	{
		public OwlsightRifle() : base()
		{
			Id = 15205;
			Bonding = 1;
			SellPrice = 1063;
			AvailableClasses = 0x7FFF;
			Model = 28229;
			ObjectClass = 2;
			SubClass = 3;
			Level = 20;
			Name = "Owlsight Rifle";
			Name2 = "Owlsight Rifle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5317;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2600;
			Stackable = 1;
			Material = 1;
			Durability = 50;
			AmmoType = 3;
			SetDamage( 14 , 27 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Smoothbore Gun)
*
***************************************************************/

namespace Server.Items
{
	public class SmoothboreGun : Item
	{
		public SmoothboreGun() : base()
		{
			Id = 15322;
			Bonding = 2;
			SellPrice = 7745;
			AvailableClasses = 0x7FFF;
			Model = 6591;
			ObjectClass = 2;
			SubClass = 3;
			Level = 39;
			ReqLevel = 34;
			Name = "Smoothbore Gun";
			Name2 = "Smoothbore Gun";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 38726;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2500;
			Stackable = 1;
			Material = 1;
			Durability = 65;
			AmmoType = 3;
			SetDamage( 29 , 54 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Percussion Shotgun)
*
***************************************************************/

namespace Server.Items
{
	public class PercussionShotgun : Item
	{
		public PercussionShotgun() : base()
		{
			Id = 15323;
			Bonding = 2;
			SellPrice = 17791;
			AvailableClasses = 0x7FFF;
			Model = 28557;
			ObjectClass = 2;
			SubClass = 3;
			Level = 50;
			ReqLevel = 45;
			Name = "Percussion Shotgun";
			Name2 = "Percussion Shotgun";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5854;
			BuyPrice = 88956;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2300;
			Stackable = 1;
			Material = 1;
			Durability = 65;
			AmmoType = 3;
			SetDamage( 37 , 70 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Burnside Rifle)
*
***************************************************************/

namespace Server.Items
{
	public class BurnsideRifle : Item
	{
		public BurnsideRifle() : base()
		{
			Id = 15324;
			Bonding = 2;
			SellPrice = 25565;
			AvailableClasses = 0x7FFF;
			Model = 28331;
			ObjectClass = 2;
			SubClass = 3;
			Level = 56;
			ReqLevel = 51;
			Name = "Burnside Rifle";
			Name2 = "Burnside Rifle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5856;
			BuyPrice = 127828;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2500;
			Stackable = 1;
			Material = 1;
			Durability = 65;
			AmmoType = 3;
			SetDamage( 45 , 85 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Sharpshooter Harquebus)
*
***************************************************************/

namespace Server.Items
{
	public class SharpshooterHarquebus : Item
	{
		public SharpshooterHarquebus() : base()
		{
			Id = 15325;
			Bonding = 2;
			SellPrice = 31784;
			AvailableClasses = 0x7FFF;
			Model = 8258;
			ObjectClass = 2;
			SubClass = 3;
			Level = 60;
			ReqLevel = 55;
			Name = "Sharpshooter Harquebus";
			Name2 = "Sharpshooter Harquebus";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5857;
			BuyPrice = 158924;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2200;
			Stackable = 1;
			Material = 1;
			Durability = 65;
			AmmoType = 3;
			SetDamage( 43 , 80 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Sidegunner Shottie)
*
***************************************************************/

namespace Server.Items
{
	public class SidegunnerShottie : Item
	{
		public SidegunnerShottie() : base()
		{
			Id = 15691;
			Bonding = 1;
			SellPrice = 6909;
			AvailableClasses = 0x7FFF;
			Model = 26411;
			ObjectClass = 2;
			SubClass = 3;
			Level = 38;
			Name = "Sidegunner Shottie";
			Name2 = "Sidegunner Shottie";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 34545;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2900;
			Stackable = 1;
			Material = 1;
			Durability = 65;
			AmmoType = 3;
			SetDamage( 32 , 61 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Thorium Rifle)
*
***************************************************************/

namespace Server.Items
{
	public class ThoriumRifle : Item
	{
		public ThoriumRifle() : base()
		{
			Id = 15995;
			Bonding = 2;
			SellPrice = 19739;
			AvailableClasses = 0x7FFF;
			Model = 26616;
			ObjectClass = 2;
			SubClass = 3;
			Level = 52;
			ReqLevel = 47;
			Name = "Thorium Rifle";
			Name2 = "Thorium Rifle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 98697;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2500;
			Stackable = 1;
			Material = 1;
			Durability = 65;
			AmmoType = 3;
			SetSpell( 21432 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 42 , 79 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Dark Iron Rifle)
*
***************************************************************/

namespace Server.Items
{
	public class DarkIronRifle : Item
	{
		public DarkIronRifle() : base()
		{
			Id = 16004;
			Bonding = 2;
			SellPrice = 29152;
			AvailableClasses = 0x7FFF;
			Model = 26737;
			ObjectClass = 2;
			SubClass = 3;
			Level = 55;
			ReqLevel = 50;
			Name = "Dark Iron Rifle";
			Name2 = "Dark Iron Rifle";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 145762;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2700;
			Stackable = 1;
			Material = 1;
			Durability = 75;
			AmmoType = 3;
			SetDamage( 53 , 100 , Resistances.Armor );
			SetDamage( 2 , 4 , Resistances.Shadow );
		}
	}
}


/**************************************************************
*
*				(Flawless Arcanite Rifle)
*
***************************************************************/

namespace Server.Items
{
	public class FlawlessArcaniteRifle : Item
	{
		public FlawlessArcaniteRifle() : base()
		{
			Id = 16007;
			Bonding = 2;
			SellPrice = 40625;
			AvailableClasses = 0x7FFF;
			Model = 24721;
			ObjectClass = 2;
			SubClass = 3;
			Level = 61;
			ReqLevel = 56;
			Name = "Flawless Arcanite Rifle";
			Name2 = "Flawless Arcanite Rifle";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 203125;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 3000;
			Stackable = 1;
			Material = 1;
			Durability = 75;
			AmmoType = 3;
			SetSpell( 7581 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 21429 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 65 , 122 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Smokey's Explosive Launcher)
*
***************************************************************/

namespace Server.Items
{
	public class SmokeysExplosiveLauncher : Item
	{
		public SmokeysExplosiveLauncher() : base()
		{
			Id = 16992;
			Bonding = 1;
			SellPrice = 30874;
			AvailableClasses = 0x7FFF;
			Model = 28786;
			ObjectClass = 2;
			SubClass = 3;
			Level = 60;
			Name = "Smokey's Explosive Launcher";
			Name2 = "Smokey's Explosive Launcher";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 154370;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2700;
			Stackable = 1;
			Material = 1;
			Durability = 65;
			AmmoType = 3;
			SetDamage( 52 , 98 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Nail Spitter)
*
***************************************************************/

namespace Server.Items
{
	public class NailSpitter : Item
	{
		public NailSpitter() : base()
		{
			Id = 17042;
			Bonding = 1;
			SellPrice = 5692;
			AvailableClasses = 0x7FFF;
			Model = 28870;
			ObjectClass = 2;
			SubClass = 3;
			Level = 36;
			Name = "Nail Spitter";
			Name2 = "Nail Spitter";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 28464;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1900;
			Stackable = 1;
			Material = 1;
			Durability = 65;
			AmmoType = 3;
			SetDamage( 19 , 37 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Blastershot Launcher)
*
***************************************************************/

namespace Server.Items
{
	public class BlastershotLauncher : Item
	{
		public BlastershotLauncher() : base()
		{
			Id = 17072;
			Bonding = 1;
			SellPrice = 82572;
			AvailableClasses = 0x7FFF;
			Model = 29163;
			ObjectClass = 2;
			SubClass = 3;
			Level = 70;
			ReqLevel = 60;
			Name = "Blastershot Launcher";
			Name2 = "Blastershot Launcher";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 412860;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2600;
			Stackable = 1;
			Material = 1;
			Durability = 90;
			AmmoType = 3;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 73 , 136 , Resistances.Armor );
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Master Hunter's Rifle)
*
***************************************************************/

namespace Server.Items
{
	public class MasterHuntersRifle17687 : Item
	{
		public MasterHuntersRifle17687() : base()
		{
			Id = 17687;
			Bonding = 1;
			SellPrice = 9937;
			AvailableClasses = 0x7FFF;
			Model = 8095;
			ObjectClass = 2;
			SubClass = 3;
			Level = 43;
			Name = "Master Hunter's Rifle";
			Name2 = "Master Hunter's Rifle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 49686;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2600;
			Stackable = 1;
			Material = 1;
			Durability = 65;
			AmmoType = 3;
			SetDamage( 35 , 66 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Megashot Rifle)
*
***************************************************************/

namespace Server.Items
{
	public class MegashotRifle : Item
	{
		public MegashotRifle() : base()
		{
			Id = 17717;
			Resistance[6] = 5;
			Bonding = 1;
			SellPrice = 26425;
			AvailableClasses = 0x7FFF;
			Model = 4427;
			ObjectClass = 2;
			SubClass = 3;
			Level = 53;
			ReqLevel = 48;
			Name = "Megashot Rifle";
			Name2 = "Megashot Rifle";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 132129;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 1700;
			Stackable = 1;
			Material = 1;
			Durability = 75;
			AmmoType = 3;
			SetSpell( 21433 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 32 , 61 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Core Marksman Rifle)
*
***************************************************************/

namespace Server.Items
{
	public class CoreMarksmanRifle : Item
	{
		public CoreMarksmanRifle() : base()
		{
			Id = 18282;
			Bonding = 2;
			SellPrice = 66347;
			AvailableClasses = 0x7FFF;
			Model = 31210;
			ObjectClass = 2;
			SubClass = 3;
			Level = 65;
			ReqLevel = 60;
			Name = "Core Marksman Rifle";
			Name2 = "Core Marksman Rifle";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 331739;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2500;
			Stackable = 1;
			Material = 1;
			Durability = 90;
			AmmoType = 3;
			SetSpell( 21434 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 15464 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 64 , 120 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Unsophisticated Hand Cannon)
*
***************************************************************/

namespace Server.Items
{
	public class UnsophisticatedHandCannon : Item
	{
		public UnsophisticatedHandCannon() : base()
		{
			Id = 18460;
			Bonding = 1;
			SellPrice = 30762;
			AvailableClasses = 0x7FFF;
			Model = 30809;
			ObjectClass = 2;
			SubClass = 3;
			Level = 60;
			ReqLevel = 55;
			Name = "Unsophisticated Hand Cannon";
			Name2 = "Unsophisticated Hand Cannon";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 153811;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2500;
			Stackable = 1;
			Material = 1;
			Durability = 65;
			AmmoType = 3;
			SetDamage( 48 , 91 , Resistances.Armor );
			StrBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Xorothian Firestick)
*
***************************************************************/

namespace Server.Items
{
	public class XorothianFirestick : Item
	{
		public XorothianFirestick() : base()
		{
			Id = 18755;
			Bonding = 1;
			SellPrice = 43129;
			AvailableClasses = 0x7FFF;
			Model = 31237;
			ObjectClass = 2;
			SubClass = 3;
			Level = 62;
			ReqLevel = 57;
			Name = "Xorothian Firestick";
			Name2 = "Xorothian Firestick";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 215646;
			Resistance[5] = 6;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2600;
			Stackable = 1;
			Material = 2;
			Durability = 75;
			AmmoType = 3;
			SetDamage( 57 , 108 , Resistances.Armor );
			StaminaBonus = 6;
			AgilityBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Grand Marshal's Hand Cannon)
*
***************************************************************/

namespace Server.Items
{
	public class GrandMarshalsHandCannon : Item
	{
		public GrandMarshalsHandCannon() : base()
		{
			Id = 18855;
			Bonding = 1;
			SellPrice = 35945;
			AvailableClasses = 0x7FFF;
			Model = 31758;
			ObjectClass = 2;
			SubClass = 3;
			Level = 78;
			ReqLevel = 60;
			Name = "Grand Marshal's Hand Cannon";
			Name2 = "Grand Marshal's Hand Cannon";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 179726;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2900;
			Stackable = 1;
			Material = 1;
			Durability = 90;
			AmmoType = 3;
			Flags = 32768;
			SetSpell( 21440 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 107 , 162 , Resistances.Armor );
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(High Warlord's Street Sweeper)
*
***************************************************************/

namespace Server.Items
{
	public class HighWarlordsStreetSweeper : Item
	{
		public HighWarlordsStreetSweeper() : base()
		{
			Id = 18860;
			Bonding = 1;
			SellPrice = 36602;
			AvailableClasses = 0x7FFF;
			Model = 31747;
			ObjectClass = 2;
			SubClass = 3;
			Level = 78;
			ReqLevel = 60;
			Name = "High Warlord's Street Sweeper";
			Name2 = "High Warlord's Street Sweeper";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 183012;
			InventoryType = InventoryTypes.RangeRight;
			Delay = 2900;
			Stackable = 1;
			Material = 1;
			Durability = 90;
			AmmoType = 3;
			Flags = 32768;
			SetSpell( 21440 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 107 , 162 , Resistances.Armor );
			StaminaBonus = 7;
		}
	}
}


