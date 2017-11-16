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
*				(Light Quiver)
*
***************************************************************/

namespace Server.Items
{
	public class LightQuiver : Item
	{
		public LightQuiver() : base()
		{
			Id = 2101;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 21328;
			ObjectClass = 11;
			SubClass = 2;
			Level = 1;
			ReqLevel = 1;
			Name = "Light Quiver";
			Name2 = "Light Quiver";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 4;
			InventoryType = InventoryTypes.Bag;
			ContainerSlots = 6;
			Stackable = 1;
			Material = -1;
			SetSpell( 14824 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Ribbly's Quiver)
*
***************************************************************/

namespace Server.Items
{
	public class RibblysQuiver : Item
	{
		public RibblysQuiver() : base()
		{
			Id = 2662;
			Bonding = 1;
			SellPrice = 8750;
			AvailableClasses = 0x7FFF;
			Model = 21712;
			ObjectClass = 11;
			SubClass = 2;
			Level = 55;
			ReqLevel = 50;
			Name = "Ribbly's Quiver";
			Name2 = "Ribbly's Quiver";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 35000;
			InventoryType = InventoryTypes.Bag;
			ContainerSlots = 16;
			Stackable = 1;
			MaxCount = 1;
			Material = 8;
			SetSpell( 14828 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Hunting Quiver)
*
***************************************************************/

namespace Server.Items
{
	public class HuntingQuiver : Item
	{
		public HuntingQuiver() : base()
		{
			Id = 3573;
			Bonding = 1;
			SellPrice = 212;
			AvailableClasses = 0x7FFF;
			Model = 21321;
			ObjectClass = 11;
			SubClass = 2;
			Level = 15;
			Name = "Hunting Quiver";
			Name2 = "Hunting Quiver";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 850;
			InventoryType = InventoryTypes.Bag;
			ContainerSlots = 10;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			SetSpell( 14824 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Quiver of the Night Watch)
*
***************************************************************/

namespace Server.Items
{
	public class QuiverOfTheNightWatch : Item
	{
		public QuiverOfTheNightWatch() : base()
		{
			Id = 3605;
			Bonding = 1;
			SellPrice = 500;
			AvailableClasses = 0x7FFF;
			Model = 21332;
			ObjectClass = 11;
			SubClass = 2;
			Level = 25;
			Name = "Quiver of the Night Watch";
			Name2 = "Quiver of the Night Watch";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2000;
			InventoryType = InventoryTypes.Bag;
			ContainerSlots = 12;
			Stackable = 1;
			MaxCount = 1;
			Material = 8;
			SetSpell( 14825 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Small Quiver)
*
***************************************************************/

namespace Server.Items
{
	public class SmallQuiver : Item
	{
		public SmallQuiver() : base()
		{
			Id = 5439;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 21318;
			ObjectClass = 11;
			SubClass = 2;
			Level = 5;
			ReqLevel = 1;
			Name = "Small Quiver";
			Name2 = "Small Quiver";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 100;
			InventoryType = InventoryTypes.Bag;
			ContainerSlots = 8;
			Stackable = 1;
			Material = -1;
			SetSpell( 14824 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Light Leather Quiver)
*
***************************************************************/

namespace Server.Items
{
	public class LightLeatherQuiver : Item
	{
		public LightLeatherQuiver() : base()
		{
			Id = 7278;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 21330;
			ObjectClass = 11;
			SubClass = 2;
			Level = 5;
			ReqLevel = 1;
			Name = "Light Leather Quiver";
			Name2 = "Light Leather Quiver";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 100;
			InventoryType = InventoryTypes.Bag;
			ContainerSlots = 8;
			Stackable = 1;
			Material = -1;
			SetSpell( 14824 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Heavy Quiver)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyQuiver : Item
	{
		public HeavyQuiver() : base()
		{
			Id = 7371;
			SellPrice = 500;
			AvailableClasses = 0x7FFF;
			Model = 21322;
			ObjectClass = 11;
			SubClass = 2;
			Level = 35;
			ReqLevel = 30;
			Name = "Heavy Quiver";
			Name2 = "Heavy Quiver";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2000;
			InventoryType = InventoryTypes.Bag;
			ContainerSlots = 14;
			Stackable = 1;
			Material = 8;
			SetSpell( 14826 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Quickdraw Quiver)
*
***************************************************************/

namespace Server.Items
{
	public class QuickdrawQuiver : Item
	{
		public QuickdrawQuiver() : base()
		{
			Id = 8217;
			SellPrice = 1000;
			AvailableClasses = 0x7FFF;
			Model = 21331;
			ObjectClass = 11;
			SubClass = 2;
			Level = 45;
			ReqLevel = 40;
			Name = "Quickdraw Quiver";
			Name2 = "Quickdraw Quiver";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4000;
			InventoryType = InventoryTypes.Bag;
			ContainerSlots = 16;
			Stackable = 1;
			Material = 8;
			SetSpell( 14827 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Medium Quiver)
*
***************************************************************/

namespace Server.Items
{
	public class MediumQuiver : Item
	{
		public MediumQuiver() : base()
		{
			Id = 11362;
			SellPrice = 250;
			AvailableClasses = 0x7FFF;
			Model = 21329;
			ObjectClass = 11;
			SubClass = 2;
			Level = 15;
			ReqLevel = 10;
			Name = "Medium Quiver";
			Name2 = "Medium Quiver";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1000;
			InventoryType = InventoryTypes.Bag;
			ContainerSlots = 10;
			Stackable = 1;
			Material = -1;
			SetSpell( 14824 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Ancient Sinew Wrapped Lamina)
*
***************************************************************/

namespace Server.Items
{
	public class AncientSinewWrappedLamina : Item
	{
		public AncientSinewWrappedLamina() : base()
		{
			Id = 18714;
			Bonding = 1;
			AvailableClasses = 0x04;
			Model = 31162;
			ObjectClass = 11;
			SubClass = 2;
			Level = 75;
			ReqLevel = 60;
			Name = "Ancient Sinew Wrapped Lamina";
			Name2 = "Ancient Sinew Wrapped Lamina";
			Quality = 4;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.Bag;
			ContainerSlots = 18;
			Stackable = 1;
			MaxCount = 1;
			Material = 8;
			SetSpell( 14829 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Harpy Hide Quiver)
*
***************************************************************/

namespace Server.Items
{
	public class HarpyHideQuiver : Item
	{
		public HarpyHideQuiver() : base()
		{
			Id = 19319;
			Bonding = 1;
			SellPrice = 87500;
			AvailableClasses = 0x7FFF;
			Model = 21712;
			ObjectClass = 11;
			SubClass = 2;
			Level = 60;
			ReqLevel = 55;
			Name = "Harpy Hide Quiver";
			Name2 = "Harpy Hide Quiver";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 350000;
			InventoryType = InventoryTypes.Bag;
			ContainerSlots = 16;
			Stackable = 1;
			MaxCount = 1;
			Material = 8;
			Flags = 32768;
			SetSpell( 14829 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


