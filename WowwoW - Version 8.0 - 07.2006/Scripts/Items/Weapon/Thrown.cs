/**************************************************************
*
*		Made by fulgas (fulgas@gmail.com)
*
*  WowwoW Item Designer ( 2005/8/23 - 10:07:18 )
*
***************************************************************/

using System;
using System.Collections;

/***************************************************************/

/**************************************************************
*
*				(Balanced Throwing Dagger)
*
***************************************************************/

namespace Server.Items
{
	public class BalancedThrowingDagger : Item
	{
		public BalancedThrowingDagger() : base()
		{
			Id = 2946;
			AvailableClasses = 0x7FFF;
			Model = 16752;
			ObjectClass = 2;
			SubClass = 16;
			Level = 8;
			ReqLevel = 3;
			Name = "Balanced Throwing Dagger";
			Name2 = "Balanced Throwing Dagger";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 30;
			InventoryType = InventoryTypes.Thrown;
			Delay = 2200;
			Stackable = 200;
			Material = 1;
			AmmoType = 4;
			SetDamage( 4 , 9 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Small Throwing Knife)
*
***************************************************************/

namespace Server.Items
{
	public class SmallThrowingKnife : Item
	{
		public SmallThrowingKnife() : base()
		{
			Id = 2947;
			AvailableClasses = 0x7FFF;
			Model = 16754;
			ObjectClass = 2;
			SubClass = 16;
			Level = 3;
			ReqLevel = 1;
			Name = "Small Throwing Knife";
			Name2 = "Small Throwing Knife";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 15;
			InventoryType = InventoryTypes.Thrown;
			Delay = 2000;
			Stackable = 200;
			Material = 1;
			AmmoType = 4;
			SetDamage( 1 , 3 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Keen Throwing Knife)
*
***************************************************************/

namespace Server.Items
{
	public class KeenThrowingKnife : Item
	{
		public KeenThrowingKnife() : base()
		{
			Id = 3107;
			AvailableClasses = 0x7FFF;
			Model = 20779;
			ObjectClass = 2;
			SubClass = 16;
			Level = 16;
			ReqLevel = 11;
			Name = "Keen Throwing Knife";
			Name2 = "Keen Throwing Knife";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 75;
			InventoryType = InventoryTypes.Thrown;
			Delay = 1900;
			Stackable = 200;
			Material = 1;
			AmmoType = 4;
			SetDamage( 8 , 16 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Heavy Throwing Dagger)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyThrowingDagger : Item
	{
		public HeavyThrowingDagger() : base()
		{
			Id = 3108;
			AvailableClasses = 0x7FFF;
			Model = 20773;
			ObjectClass = 2;
			SubClass = 16;
			Level = 27;
			ReqLevel = 22;
			Name = "Heavy Throwing Dagger";
			Name2 = "Heavy Throwing Dagger";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 200;
			InventoryType = InventoryTypes.Thrown;
			Delay = 2100;
			Stackable = 200;
			Material = 1;
			AmmoType = 4;
			SetDamage( 17 , 32 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Crude Throwing Axe)
*
***************************************************************/

namespace Server.Items
{
	public class CrudeThrowingAxe : Item
	{
		public CrudeThrowingAxe() : base()
		{
			Id = 3111;
			AvailableClasses = 0x7FFF;
			Model = 20777;
			ObjectClass = 2;
			SubClass = 16;
			Level = 3;
			ReqLevel = 1;
			Name = "Crude Throwing Axe";
			Name2 = "Crude Throwing Axe";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 15;
			InventoryType = InventoryTypes.Thrown;
			Delay = 2000;
			Stackable = 200;
			Material = 1;
			AmmoType = 4;
			SetDamage( 1 , 3 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Weighted Throwing Axe)
*
***************************************************************/

namespace Server.Items
{
	public class WeightedThrowingAxe : Item
	{
		public WeightedThrowingAxe() : base()
		{
			Id = 3131;
			AvailableClasses = 0x7FFF;
			Model = 16760;
			ObjectClass = 2;
			SubClass = 16;
			Level = 8;
			ReqLevel = 3;
			Name = "Weighted Throwing Axe";
			Name2 = "Weighted Throwing Axe";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 30;
			InventoryType = InventoryTypes.Thrown;
			Delay = 2200;
			Stackable = 200;
			Material = 1;
			AmmoType = 4;
			SetDamage( 4 , 9 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Sharp Throwing Axe)
*
***************************************************************/

namespace Server.Items
{
	public class SharpThrowingAxe : Item
	{
		public SharpThrowingAxe() : base()
		{
			Id = 3135;
			AvailableClasses = 0x7FFF;
			Model = 20782;
			ObjectClass = 2;
			SubClass = 16;
			Level = 16;
			ReqLevel = 11;
			Name = "Sharp Throwing Axe";
			Name2 = "Sharp Throwing Axe";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 75;
			InventoryType = InventoryTypes.Thrown;
			Delay = 1900;
			Stackable = 200;
			Material = 1;
			AmmoType = 4;
			SetDamage( 8 , 16 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Deadly Throwing Axe)
*
***************************************************************/

namespace Server.Items
{
	public class DeadlyThrowingAxe : Item
	{
		public DeadlyThrowingAxe() : base()
		{
			Id = 3137;
			AvailableClasses = 0x7FFF;
			Model = 20783;
			ObjectClass = 2;
			SubClass = 16;
			Level = 27;
			ReqLevel = 22;
			Name = "Deadly Throwing Axe";
			Name2 = "Deadly Throwing Axe";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 200;
			InventoryType = InventoryTypes.Thrown;
			Delay = 2100;
			Stackable = 200;
			Material = 1;
			AmmoType = 4;
			SetDamage( 17 , 32 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Silver Star)
*
***************************************************************/

namespace Server.Items
{
	public class SilverStar : Item
	{
		public SilverStar() : base()
		{
			Id = 3463;
			Bonding = 1;
			SellPrice = 9;
			AvailableClasses = 0x7FFF;
			Model = 20772;
			ObjectClass = 2;
			SubClass = 16;
			Level = 37;
			Name = "Silver Star";
			Name2 = "Silver Star";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 37;
			InventoryType = InventoryTypes.Thrown;
			Delay = 2300;
			Stackable = 200;
			Material = 1;
			AmmoType = 4;
			SetDamage( 28 , 53 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Throwing Tomahawk)
*
***************************************************************/

namespace Server.Items
{
	public class ThrowingTomahawk : Item
	{
		public ThrowingTomahawk() : base()
		{
			Id = 4959;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 5416;
			ObjectClass = 2;
			SubClass = 16;
			Level = 7;
			ReqLevel = 4;
			Name = "Throwing Tomahawk";
			Name2 = "Throwing Tomahawk";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1;
			InventoryType = InventoryTypes.Thrown;
			Delay = 2000;
			Stackable = 100;
			Material = 1;
			AmmoType = 4;
			Flags = 16;
			SetDamage( 2 , 4 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Boot Knife)
*
***************************************************************/

namespace Server.Items
{
	public class BootKnife : Item
	{
		public BootKnife() : base()
		{
			Id = 5379;
			AvailableClasses = 0x7FFF;
			Model = 20781;
			ObjectClass = 2;
			SubClass = 16;
			Level = 8;
			ReqLevel = 3;
			Name = "Boot Knife";
			Name2 = "Boot Knife";
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.Thrown;
			Delay = 1700;
			Stackable = 200;
			Material = 1;
			AmmoType = 4;
			SetDamage( 2 , 5 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Flightblade Throwing Axe)
*
***************************************************************/

namespace Server.Items
{
	public class FlightbladeThrowingAxe : Item
	{
		public FlightbladeThrowingAxe() : base()
		{
			Id = 13173;
			Bonding = 1;
			SellPrice = 11;
			AvailableClasses = 0x7FFF;
			Model = 23723;
			ObjectClass = 2;
			SubClass = 16;
			Level = 60;
			ReqLevel = 55;
			Name = "Flightblade Throwing Axe";
			Name2 = "Flightblade Throwing Axe";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 47;
			InventoryType = InventoryTypes.Thrown;
			Delay = 2200;
			Stackable = 200;
			Material = 1;
			AmmoType = 4;
			SetDamage( 54 , 102 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Gleaming Throwing Axe)
*
***************************************************************/

namespace Server.Items
{
	public class GleamingThrowingAxe : Item
	{
		public GleamingThrowingAxe() : base()
		{
			Id = 15326;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 26358;
			ObjectClass = 2;
			SubClass = 16;
			Level = 40;
			ReqLevel = 35;
			Name = "Gleaming Throwing Axe";
			Name2 = "Gleaming Throwing Axe";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 800;
			InventoryType = InventoryTypes.Thrown;
			Delay = 1800;
			Stackable = 200;
			Material = 1;
			AmmoType = 4;
			SetDamage( 23 , 43 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Wicked Throwing Dagger)
*
***************************************************************/

namespace Server.Items
{
	public class WickedThrowingDagger : Item
	{
		public WickedThrowingDagger() : base()
		{
			Id = 15327;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 26361;
			ObjectClass = 2;
			SubClass = 16;
			Level = 40;
			ReqLevel = 35;
			Name = "Wicked Throwing Dagger";
			Name2 = "Wicked Throwing Dagger";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 800;
			InventoryType = InventoryTypes.Thrown;
			Delay = 1800;
			Stackable = 200;
			Material = 1;
			AmmoType = 4;
			SetDamage( 23 , 43 , Resistances.Armor );
		}
	}
}


