/**************************************************************
*
*		Made by fulgas (fulgas@gmail.com)
*
*  WowwoW Item Designer ( 2005/8/23 - 10:07:01 )
*
***************************************************************/

using System;
using System.Collections;

/***************************************************************/

/**************************************************************
*
*				(Rough Arrow)
*
***************************************************************/

namespace Server.Items
{
	public class RoughArrow : Item
	{
		public RoughArrow() : base()
		{
			Id = 2512;
			AvailableClasses = 0x7FFF;
			Model = 5996;
			ObjectClass = 6;
			SubClass = 2;
			Level = 5;
			ReqLevel = 1;
			Name = "Rough Arrow";
			Name2 = "Rough Arrow";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 10;
			InventoryType = InventoryTypes.Projectile;
			Delay = 3000;
			Stackable = 200;
			Material = 2;
			SetDamage( 1 , 2 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Sharp Arrow)
*
***************************************************************/

namespace Server.Items
{
	public class SharpArrow : Item
	{
		public SharpArrow() : base()
		{
			Id = 2515;
			AvailableClasses = 0x7FFF;
			Model = 5996;
			ObjectClass = 6;
			SubClass = 2;
			Level = 15;
			ReqLevel = 10;
			Name = "Sharp Arrow";
			Name2 = "Sharp Arrow";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 50;
			InventoryType = InventoryTypes.Projectile;
			Delay = 3000;
			Stackable = 200;
			Material = 2;
			SetDamage( 3 , 4 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Razor Arrow)
*
***************************************************************/

namespace Server.Items
{
	public class RazorArrow : Item
	{
		public RazorArrow() : base()
		{
			Id = 3030;
			AvailableClasses = 0x7FFF;
			Model = 26497;
			ObjectClass = 6;
			SubClass = 2;
			Level = 30;
			ReqLevel = 25;
			Name = "Razor Arrow";
			Name2 = "Razor Arrow";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 300;
			InventoryType = InventoryTypes.Projectile;
			Delay = 3000;
			Stackable = 200;
			Material = 2;
			SetDamage( 7 , 8 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Feathered Arrow)
*
***************************************************************/

namespace Server.Items
{
	public class FeatheredArrow : Item
	{
		public FeatheredArrow() : base()
		{
			Id = 3464;
			SellPrice = 8;
			AvailableClasses = 0x7FFF;
			Model = 26497;
			ObjectClass = 6;
			SubClass = 2;
			Level = 35;
			Name = "Feathered Arrow";
			Name2 = "Feathered Arrow";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 35;
			InventoryType = InventoryTypes.Projectile;
			Delay = 3000;
			Stackable = 200;
			Material = 2;
			SetDamage( 9 , 10 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Precision Arrow)
*
***************************************************************/

namespace Server.Items
{
	public class PrecisionArrow : Item
	{
		public PrecisionArrow() : base()
		{
			Id = 9399;
			SellPrice = 10;
			AvailableClasses = 0x7FFF;
			Model = 26498;
			ObjectClass = 6;
			SubClass = 2;
			Level = 40;
			ReqLevel = 35;
			Name = "Precision Arrow";
			Name2 = "Precision Arrow";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 40;
			InventoryType = InventoryTypes.Projectile;
			Delay = 3000;
			Stackable = 200;
			Material = 2;
			SetDamage( 11 , 12 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Jagged Arrow)
*
***************************************************************/

namespace Server.Items
{
	public class JaggedArrow : Item
	{
		public JaggedArrow() : base()
		{
			Id = 11285;
			SellPrice = 2;
			AvailableClasses = 0x7FFF;
			Model = 21091;
			ObjectClass = 6;
			SubClass = 2;
			Level = 45;
			ReqLevel = 40;
			Name = "Jagged Arrow";
			Name2 = "Jagged Arrow";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1000;
			InventoryType = InventoryTypes.Projectile;
			Delay = 3000;
			Stackable = 200;
			Material = 2;
			SetDamage( 13 , 13 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Doomshot)
*
***************************************************************/

namespace Server.Items
{
	public class Doomshot : Item
	{
		public Doomshot() : base()
		{
			Id = 12654;
			Bonding = 1;
			SellPrice = 62;
			AvailableClasses = 0x7FFF;
			Model = 22931;
			ObjectClass = 6;
			SubClass = 2;
			Level = 59;
			ReqLevel = 54;
			Name = "Doomshot";
			Name2 = "Doomshot";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 250;
			InventoryType = InventoryTypes.Projectile;
			Delay = 3000;
			Stackable = 200;
			Material = 2;
			SetDamage( 20 , 20 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Thorium Headed Arrow)
*
***************************************************************/

namespace Server.Items
{
	public class ThoriumHeadedArrow : Item
	{
		public ThoriumHeadedArrow() : base()
		{
			Id = 18042;
			SellPrice = 10;
			AvailableClasses = 0x7FFF;
			Model = 30433;
			ObjectClass = 6;
			SubClass = 2;
			Level = 57;
			ReqLevel = 52;
			Name = "Thorium Headed Arrow";
			Name2 = "Thorium Headed Arrow";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4000;
			InventoryType = InventoryTypes.Projectile;
			Delay = 3000;
			Stackable = 200;
			Material = 2;
			SetDamage( 17 , 18 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Ice Threaded Arrow)
*
***************************************************************/

namespace Server.Items
{
	public class IceThreadedArrow : Item
	{
		public IceThreadedArrow() : base()
		{
			Id = 19316;
			Bonding = 1;
			SellPrice = 7;
			AvailableClasses = 0x7FFF;
			Model = 31814;
			ObjectClass = 6;
			SubClass = 2;
			Level = 54;
			ReqLevel = 51;
			Name = "Ice Threaded Arrow";
			Name2 = "Ice Threaded Arrow";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6000;
			InventoryType = InventoryTypes.Projectile;
			Delay = 3000;
			Stackable = 200;
			Material = 2;
			SetDamage( 16 , 17 , Resistances.Armor );
		}
	}
}


