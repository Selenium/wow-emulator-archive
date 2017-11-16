/**************************************************************
*
*		Made by fulgas (fulgas@gmail.com)
*
*  WowwoW Item Designer ( 2005/8/23 - 10:05:15 )
*
***************************************************************/

using System;
using System.Collections;

/***************************************************************/

/**************************************************************
*
*				(Recruit's Shirt)
*
***************************************************************/

namespace Server.Items
{
	public class RecruitsShirt : Item
	{
		public RecruitsShirt() : base()
		{
			Id = 38;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 9891;
			ObjectClass = 4;
			SubClass = 0;
			Level = 1;
			Name = "Recruit's Shirt";
			Name2 = "Recruit's Shirt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1;
			InventoryType = InventoryTypes.Shirt;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Squire's Shirt)
*
***************************************************************/

namespace Server.Items
{
	public class SquiresShirt : Item
	{
		public SquiresShirt() : base()
		{
			Id = 45;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 3265;
			ObjectClass = 4;
			SubClass = 0;
			Level = 1;
			Name = "Squire's Shirt";
			Name2 = "Squire's Shirt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1;
			InventoryType = InventoryTypes.Shirt;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Footpad's Shirt)
*
***************************************************************/

namespace Server.Items
{
	public class FootpadsShirt : Item
	{
		public FootpadsShirt() : base()
		{
			Id = 49;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 9906;
			ObjectClass = 4;
			SubClass = 0;
			Level = 1;
			Name = "Footpad's Shirt";
			Name2 = "Footpad's Shirt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1;
			InventoryType = InventoryTypes.Shirt;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Neophyte's Shirt)
*
***************************************************************/

namespace Server.Items
{
	public class NeophytesShirt : Item
	{
		public NeophytesShirt() : base()
		{
			Id = 53;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 9944;
			ObjectClass = 4;
			SubClass = 0;
			Level = 1;
			Name = "Neophyte's Shirt";
			Name2 = "Neophyte's Shirt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1;
			InventoryType = InventoryTypes.Shirt;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Trapper's Shirt)
*
***************************************************************/

namespace Server.Items
{
	public class TrappersShirt : Item
	{
		public TrappersShirt() : base()
		{
			Id = 127;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 9996;
			ObjectClass = 4;
			SubClass = 0;
			Level = 1;
			Name = "Trapper's Shirt";
			Name2 = "Trapper's Shirt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1;
			InventoryType = InventoryTypes.Shirt;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Rugged Trapper's Shirt)
*
***************************************************************/

namespace Server.Items
{
	public class RuggedTrappersShirt : Item
	{
		public RuggedTrappersShirt() : base()
		{
			Id = 148;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 9976;
			ObjectClass = 4;
			SubClass = 0;
			Level = 1;
			Name = "Rugged Trapper's Shirt";
			Name2 = "Rugged Trapper's Shirt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1;
			InventoryType = InventoryTypes.Shirt;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Primitive Mantle)
*
***************************************************************/

namespace Server.Items
{
	public class PrimitiveMantle : Item
	{
		public PrimitiveMantle() : base()
		{
			Id = 154;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 10058;
			ObjectClass = 4;
			SubClass = 0;
			Level = 1;
			Name = "Primitive Mantle";
			Name2 = "Primitive Mantle";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1;
			InventoryType = InventoryTypes.Shirt;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Fine Cloth Shirt)
*
***************************************************************/

namespace Server.Items
{
	public class FineClothShirt : Item
	{
		public FineClothShirt() : base()
		{
			Id = 859;
			Bonding = 1;
			SellPrice = 87;
			AvailableClasses = 0x7FFF;
			Model = 9880;
			ObjectClass = 4;
			SubClass = 0;
			Level = 17;
			Name = "Fine Cloth Shirt";
			Name2 = "Fine Cloth Shirt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 350;
			InventoryType = InventoryTypes.Shirt;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Deprecated Red Linen Shirt)
*
***************************************************************/

namespace Server.Items
{
	public class DeprecatedRedLinenShirt : Item
	{
		public DeprecatedRedLinenShirt() : base()
		{
			Id = 964;
			SellPrice = 12;
			AvailableClasses = 0x7FFF;
			Model = 9744;
			ObjectClass = 4;
			SubClass = 0;
			Level = 8;
			Name = "Deprecated Red Linen Shirt";
			Name2 = "Deprecated Red Linen Shirt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 50;
			InventoryType = InventoryTypes.Shirt;
			Stackable = 1;
			Material = 7;
			Flags = 16;
		}
	}
}


/**************************************************************
*
*				(Thug Shirt)
*
***************************************************************/

namespace Server.Items
{
	public class ThugShirt : Item
	{
		public ThugShirt() : base()
		{
			Id = 2105;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 10005;
			ObjectClass = 4;
			SubClass = 0;
			Level = 1;
			Name = "Thug Shirt";
			Name2 = "Thug Shirt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 5;
			InventoryType = InventoryTypes.Shirt;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Red Linen Shirt)
*
***************************************************************/

namespace Server.Items
{
	public class RedLinenShirt : Item
	{
		public RedLinenShirt() : base()
		{
			Id = 2575;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 10840;
			ObjectClass = 4;
			SubClass = 0;
			Level = 10;
			Name = "Red Linen Shirt";
			Name2 = "Red Linen Shirt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 100;
			InventoryType = InventoryTypes.Shirt;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(White Linen Shirt)
*
***************************************************************/

namespace Server.Items
{
	public class WhiteLinenShirt : Item
	{
		public WhiteLinenShirt() : base()
		{
			Id = 2576;
			SellPrice = 75;
			AvailableClasses = 0x7FFF;
			Model = 10834;
			ObjectClass = 4;
			SubClass = 0;
			Level = 7;
			Name = "White Linen Shirt";
			Name2 = "White Linen Shirt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 300;
			InventoryType = InventoryTypes.Shirt;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Blue Linen Shirt)
*
***************************************************************/

namespace Server.Items
{
	public class BlueLinenShirt : Item
	{
		public BlueLinenShirt() : base()
		{
			Id = 2577;
			SellPrice = 75;
			AvailableClasses = 0x7FFF;
			Model = 10845;
			ObjectClass = 4;
			SubClass = 0;
			Level = 10;
			Name = "Blue Linen Shirt";
			Name2 = "Blue Linen Shirt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 300;
			InventoryType = InventoryTypes.Shirt;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Green Linen Shirt)
*
***************************************************************/

namespace Server.Items
{
	public class GreenLinenShirt : Item
	{
		public GreenLinenShirt() : base()
		{
			Id = 2579;
			SellPrice = 37;
			AvailableClasses = 0x7FFF;
			Model = 12864;
			ObjectClass = 4;
			SubClass = 0;
			Level = 14;
			Name = "Green Linen Shirt";
			Name2 = "Green Linen Shirt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 150;
			InventoryType = InventoryTypes.Shirt;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Gray Woolen Shirt)
*
***************************************************************/

namespace Server.Items
{
	public class GrayWoolenShirt : Item
	{
		public GrayWoolenShirt() : base()
		{
			Id = 2587;
			SellPrice = 200;
			AvailableClasses = 0x7FFF;
			Model = 10892;
			ObjectClass = 4;
			SubClass = 0;
			Level = 20;
			Name = "Gray Woolen Shirt";
			Name2 = "Gray Woolen Shirt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 800;
			InventoryType = InventoryTypes.Shirt;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Work Shirt)
*
***************************************************************/

namespace Server.Items
{
	public class WorkShirt : Item
	{
		public WorkShirt() : base()
		{
			Id = 3148;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 7849;
			ObjectClass = 4;
			SubClass = 0;
			Level = 1;
			Name = "Work Shirt";
			Name2 = "Work Shirt";
			AvailableRaces = 0x1FF;
			BuyPrice = 1;
			InventoryType = InventoryTypes.Shirt;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Captain Sander's Shirt)
*
***************************************************************/

namespace Server.Items
{
	public class CaptainSandersShirt : Item
	{
		public CaptainSandersShirt() : base()
		{
			Id = 3342;
			Bonding = 1;
			SellPrice = 137;
			AvailableClasses = 0x7FFF;
			Model = 7843;
			ObjectClass = 4;
			SubClass = 0;
			Level = 15;
			Name = "Captain Sander's Shirt";
			Name2 = "Captain Sander's Shirt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 550;
			InventoryType = InventoryTypes.Shirt;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Bold Yellow Shirt)
*
***************************************************************/

namespace Server.Items
{
	public class BoldYellowShirt : Item
	{
		public BoldYellowShirt() : base()
		{
			Id = 3426;
			SellPrice = 1000;
			AvailableClasses = 0x7FFF;
			Model = 16610;
			ObjectClass = 4;
			SubClass = 0;
			Level = 30;
			Name = "Bold Yellow Shirt";
			Name2 = "Bold Yellow Shirt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 4000;
			InventoryType = InventoryTypes.Shirt;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Stylish Black Shirt)
*
***************************************************************/

namespace Server.Items
{
	public class StylishBlackShirt : Item
	{
		public StylishBlackShirt() : base()
		{
			Id = 3427;
			SellPrice = 1500;
			AvailableClasses = 0x7FFF;
			Model = 7905;
			ObjectClass = 4;
			SubClass = 0;
			Level = 40;
			Name = "Stylish Black Shirt";
			Name2 = "Stylish Black Shirt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 6000;
			InventoryType = InventoryTypes.Shirt;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Common Gray Shirt)
*
***************************************************************/

namespace Server.Items
{
	public class CommonGrayShirt : Item
	{
		public CommonGrayShirt() : base()
		{
			Id = 3428;
			SellPrice = 100;
			AvailableClasses = 0x7FFF;
			Model = 10892;
			ObjectClass = 4;
			SubClass = 0;
			Level = 20;
			Name = "Common Gray Shirt";
			Name2 = "Common Gray Shirt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 400;
			InventoryType = InventoryTypes.Shirt;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Stylish Red Shirt)
*
***************************************************************/

namespace Server.Items
{
	public class StylishRedShirt : Item
	{
		public StylishRedShirt() : base()
		{
			Id = 4330;
			SellPrice = 250;
			AvailableClasses = 0x7FFF;
			Model = 7906;
			ObjectClass = 4;
			SubClass = 0;
			Level = 22;
			Name = "Stylish Red Shirt";
			Name2 = "Stylish Red Shirt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1000;
			InventoryType = InventoryTypes.Shirt;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Bright Yellow Shirt)
*
***************************************************************/

namespace Server.Items
{
	public class BrightYellowShirt : Item
	{
		public BrightYellowShirt() : base()
		{
			Id = 4332;
			SellPrice = 500;
			AvailableClasses = 0x7FFF;
			Model = 7902;
			ObjectClass = 4;
			SubClass = 0;
			Level = 27;
			Name = "Bright Yellow Shirt";
			Name2 = "Bright Yellow Shirt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2000;
			InventoryType = InventoryTypes.Shirt;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Dark Silk Shirt)
*
***************************************************************/

namespace Server.Items
{
	public class DarkSilkShirt : Item
	{
		public DarkSilkShirt() : base()
		{
			Id = 4333;
			SellPrice = 1200;
			AvailableClasses = 0x7FFF;
			Model = 15858;
			ObjectClass = 4;
			SubClass = 0;
			Level = 31;
			Name = "Dark Silk Shirt";
			Name2 = "Dark Silk Shirt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 4800;
			InventoryType = InventoryTypes.Shirt;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Formal White Shirt)
*
***************************************************************/

namespace Server.Items
{
	public class FormalWhiteShirt : Item
	{
		public FormalWhiteShirt() : base()
		{
			Id = 4334;
			SellPrice = 550;
			AvailableClasses = 0x7FFF;
			Model = 7903;
			ObjectClass = 4;
			SubClass = 0;
			Level = 34;
			Name = "Formal White Shirt";
			Name2 = "Formal White Shirt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2200;
			InventoryType = InventoryTypes.Shirt;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Rich Purple Silk Shirt)
*
***************************************************************/

namespace Server.Items
{
	public class RichPurpleSilkShirt : Item
	{
		public RichPurpleSilkShirt() : base()
		{
			Id = 4335;
			SellPrice = 1500;
			AvailableClasses = 0x7FFF;
			Model = 7904;
			ObjectClass = 4;
			SubClass = 0;
			Level = 37;
			Name = "Rich Purple Silk Shirt";
			Name2 = "Rich Purple Silk Shirt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 6000;
			InventoryType = InventoryTypes.Shirt;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Black Swashbuckler's Shirt)
*
***************************************************************/

namespace Server.Items
{
	public class BlackSwashbucklersShirt : Item
	{
		public BlackSwashbucklersShirt() : base()
		{
			Id = 4336;
			SellPrice = 1500;
			AvailableClasses = 0x7FFF;
			Model = 13055;
			ObjectClass = 4;
			SubClass = 0;
			Level = 40;
			Name = "Black Swashbuckler's Shirt";
			Name2 = "Black Swashbuckler's Shirt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 6000;
			InventoryType = InventoryTypes.Shirt;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Brown Linen Shirt)
*
***************************************************************/

namespace Server.Items
{
	public class BrownLinenShirt : Item
	{
		public BrownLinenShirt() : base()
		{
			Id = 4344;
			SellPrice = 11;
			AvailableClasses = 0x7FFF;
			Model = 12802;
			ObjectClass = 4;
			SubClass = 0;
			Level = 7;
			Name = "Brown Linen Shirt";
			Name2 = "Brown Linen Shirt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 58;
			InventoryType = InventoryTypes.Shirt;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Deckhand's Shirt)
*
***************************************************************/

namespace Server.Items
{
	public class DeckhandsShirt : Item
	{
		public DeckhandsShirt() : base()
		{
			Id = 5107;
			SellPrice = 139;
			AvailableClasses = 0x7FFF;
			Model = 16557;
			ObjectClass = 4;
			SubClass = 0;
			Level = 14;
			Name = "Deckhand's Shirt";
			Name2 = "Deckhand's Shirt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 698;
			InventoryType = InventoryTypes.Shirt;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Apprentice's Shirt)
*
***************************************************************/

namespace Server.Items
{
	public class ApprenticesShirt : Item
	{
		public ApprenticesShirt() : base()
		{
			Id = 6096;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 2163;
			ObjectClass = 4;
			SubClass = 0;
			Level = 1;
			Name = "Apprentice's Shirt";
			Name2 = "Apprentice's Shirt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1;
			InventoryType = InventoryTypes.Shirt;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Acolyte's Shirt)
*
***************************************************************/

namespace Server.Items
{
	public class AcolytesShirt : Item
	{
		public AcolytesShirt() : base()
		{
			Id = 6097;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 2470;
			ObjectClass = 4;
			SubClass = 0;
			Level = 1;
			Name = "Acolyte's Shirt";
			Name2 = "Acolyte's Shirt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1;
			InventoryType = InventoryTypes.Shirt;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Squire's Shirt)
*
***************************************************************/

namespace Server.Items
{
	public class DwarfSquiresShirt : Item
	{
		public DwarfSquiresShirt() : base()
		{
			Id = 6117;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 9972;
			ObjectClass = 4;
			SubClass = 0;
			Level = 1;
			Name = "Squire's Shirt";
			Name2 = "Squire's Shirt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1;
			InventoryType = InventoryTypes.Shirt;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Recruit's Shirt)
*
***************************************************************/

namespace Server.Items
{
	public class NightElfRecruitsShirt : Item
	{
		public NightElfRecruitsShirt() : base()
		{
			Id = 6120;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 9983;
			ObjectClass = 4;
			SubClass = 0;
			Level = 1;
			Name = "Recruit's Shirt";
			Name2 = "Recruit's Shirt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1;
			InventoryType = InventoryTypes.Shirt;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Brawler's Harness)
*
***************************************************************/

namespace Server.Items
{
	public class BrawlersHarness : Item
	{
		public BrawlersHarness() : base()
		{
			Id = 6125;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 9995;
			ObjectClass = 4;
			SubClass = 0;
			Level = 1;
			Name = "Brawler's Harness";
			Name2 = "Brawler's Harness";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1;
			InventoryType = InventoryTypes.Shirt;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Trapper's Shirt)
*
***************************************************************/

namespace Server.Items
{
	public class TrappersShirt6130 : Item
	{
		public TrappersShirt6130() : base()
		{
			Id = 6130;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 17462;
			ObjectClass = 4;
			SubClass = 0;
			Level = 1;
			Name = "Trapper's Shirt";
			Name2 = "Trapper's Shirt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1;
			InventoryType = InventoryTypes.Shirt;
			Stackable = 1;
			Material = 7;
			Flags = 16;
		}
	}
}


/**************************************************************
*
*				(Primitive Mantle)
*
***************************************************************/

namespace Server.Items
{
	public class TrollPrimitiveMantle : Item
	{
		public TrollPrimitiveMantle() : base()
		{
			Id = 6134;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 10108;
			ObjectClass = 4;
			SubClass = 0;
			Level = 1;
			Name = "Primitive Mantle";
			Name2 = "Primitive Mantle";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1;
			InventoryType = InventoryTypes.Shirt;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Thug Shirt)
*
***************************************************************/

namespace Server.Items
{
	public class TrollThugShirt : Item
	{
		public TrollThugShirt() : base()
		{
			Id = 6136;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 10112;
			ObjectClass = 4;
			SubClass = 0;
			Level = 1;
			Name = "Thug Shirt";
			Name2 = "Thug Shirt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 4;
			InventoryType = InventoryTypes.Shirt;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Stylish Blue Shirt)
*
***************************************************************/

namespace Server.Items
{
	public class StylishBlueShirt : Item
	{
		public StylishBlueShirt() : base()
		{
			Id = 6384;
			SellPrice = 250;
			AvailableClasses = 0x7FFF;
			Model = 11518;
			ObjectClass = 4;
			SubClass = 0;
			Level = 25;
			Name = "Stylish Blue Shirt";
			Name2 = "Stylish Blue Shirt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1000;
			InventoryType = InventoryTypes.Shirt;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Stylish Green Shirt)
*
***************************************************************/

namespace Server.Items
{
	public class StylishGreenShirt : Item
	{
		public StylishGreenShirt() : base()
		{
			Id = 6385;
			SellPrice = 250;
			AvailableClasses = 0x7FFF;
			Model = 11519;
			ObjectClass = 4;
			SubClass = 0;
			Level = 25;
			Name = "Stylish Green Shirt";
			Name2 = "Stylish Green Shirt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1000;
			InventoryType = InventoryTypes.Shirt;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(White Swashbuckler's Shirt)
*
***************************************************************/

namespace Server.Items
{
	public class WhiteSwashbucklersShirt : Item
	{
		public WhiteSwashbucklersShirt() : base()
		{
			Id = 6795;
			SellPrice = 500;
			AvailableClasses = 0x7FFF;
			Model = 13056;
			ObjectClass = 4;
			SubClass = 0;
			Level = 32;
			Name = "White Swashbuckler's Shirt";
			Name2 = "White Swashbuckler's Shirt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2000;
			InventoryType = InventoryTypes.Shirt;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Red Swashbuckler's Shirt)
*
***************************************************************/

namespace Server.Items
{
	public class RedSwashbucklersShirt : Item
	{
		public RedSwashbucklersShirt() : base()
		{
			Id = 6796;
			SellPrice = 750;
			AvailableClasses = 0x7FFF;
			Model = 13057;
			ObjectClass = 4;
			SubClass = 0;
			Level = 35;
			Name = "Red Swashbuckler's Shirt";
			Name2 = "Red Swashbuckler's Shirt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 3000;
			InventoryType = InventoryTypes.Shirt;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(White Tuxedo Shirt)
*
***************************************************************/

namespace Server.Items
{
	public class WhiteTuxedoShirt : Item
	{
		public WhiteTuxedoShirt() : base()
		{
			Id = 6833;
			SellPrice = 500;
			AvailableClasses = 0x7FFF;
			Model = 13115;
			ObjectClass = 4;
			SubClass = 0;
			Level = 25;
			Name = "White Tuxedo Shirt";
			Name2 = "White Tuxedo Shirt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2000;
			InventoryType = InventoryTypes.Shirt;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Tuxedo Shirt)
*
***************************************************************/

namespace Server.Items
{
	public class TuxedoShirt : Item
	{
		public TuxedoShirt() : base()
		{
			Id = 10034;
			SellPrice = 2000;
			AvailableClasses = 0x7FFF;
			Model = 13115;
			ObjectClass = 4;
			SubClass = 0;
			Level = 1;
			Name = "Tuxedo Shirt";
			Name2 = "Tuxedo Shirt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 8000;
			InventoryType = InventoryTypes.Shirt;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Orange Martial Shirt)
*
***************************************************************/

namespace Server.Items
{
	public class OrangeMartialShirt : Item
	{
		public OrangeMartialShirt() : base()
		{
			Id = 10052;
			SellPrice = 1500;
			AvailableClasses = 0x7FFF;
			Model = 18916;
			ObjectClass = 4;
			SubClass = 0;
			Level = 40;
			Name = "Orange Martial Shirt";
			Name2 = "Orange Martial Shirt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 6000;
			InventoryType = InventoryTypes.Shirt;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Lavender Mageweave Shirt)
*
***************************************************************/

namespace Server.Items
{
	public class LavenderMageweaveShirt : Item
	{
		public LavenderMageweaveShirt() : base()
		{
			Id = 10054;
			SellPrice = 3000;
			AvailableClasses = 0x7FFF;
			Model = 18924;
			ObjectClass = 4;
			SubClass = 0;
			Level = 46;
			Name = "Lavender Mageweave Shirt";
			Name2 = "Lavender Mageweave Shirt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 12000;
			InventoryType = InventoryTypes.Shirt;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Pink Mageweave Shirt)
*
***************************************************************/

namespace Server.Items
{
	public class PinkMageweaveShirt : Item
	{
		public PinkMageweaveShirt() : base()
		{
			Id = 10055;
			SellPrice = 3000;
			AvailableClasses = 0x7FFF;
			Model = 18923;
			ObjectClass = 4;
			SubClass = 0;
			Level = 47;
			Name = "Pink Mageweave Shirt";
			Name2 = "Pink Mageweave Shirt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 12000;
			InventoryType = InventoryTypes.Shirt;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Orange Mageweave Shirt)
*
***************************************************************/

namespace Server.Items
{
	public class OrangeMageweaveShirt : Item
	{
		public OrangeMageweaveShirt() : base()
		{
			Id = 10056;
			SellPrice = 1500;
			AvailableClasses = 0x7FFF;
			Model = 18925;
			ObjectClass = 4;
			SubClass = 0;
			Level = 43;
			Name = "Orange Mageweave Shirt";
			Name2 = "Orange Mageweave Shirt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 6000;
			InventoryType = InventoryTypes.Shirt;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Master Builder's Shirt)
*
***************************************************************/

namespace Server.Items
{
	public class MasterBuildersShirt : Item
	{
		public MasterBuildersShirt() : base()
		{
			Id = 11840;
			Bonding = 1;
			SellPrice = 7137;
			AvailableClasses = 0x7FFF;
			Model = 21842;
			ObjectClass = 4;
			SubClass = 0;
			Level = 55;
			Name = "Master Builder's Shirt";
			Name2 = "Master Builder's Shirt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 28550;
			InventoryType = InventoryTypes.Shirt;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Sawbones Shirt)
*
***************************************************************/

namespace Server.Items
{
	public class SawbonesShirt : Item
	{
		public SawbonesShirt() : base()
		{
			Id = 14617;
			Bonding = 1;
			SellPrice = 6250;
			AvailableClasses = 0x7FFF;
			Model = 25193;
			ObjectClass = 4;
			SubClass = 0;
			Level = 1;
			Name = "Sawbones Shirt";
			Name2 = "Sawbones Shirt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 25000;
			InventoryType = InventoryTypes.Shirt;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Common Brown Shirt)
*
***************************************************************/

namespace Server.Items
{
	public class CommonBrownShirt : Item
	{
		public CommonBrownShirt() : base()
		{
			Id = 16059;
			SellPrice = 100;
			AvailableClasses = 0x7FFF;
			Model = 26683;
			ObjectClass = 4;
			SubClass = 0;
			Level = 20;
			Name = "Common Brown Shirt";
			Name2 = "Common Brown Shirt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 400;
			InventoryType = InventoryTypes.Shirt;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Common White Shirt)
*
***************************************************************/

namespace Server.Items
{
	public class CommonWhiteShirt : Item
	{
		public CommonWhiteShirt() : base()
		{
			Id = 16060;
			SellPrice = 100;
			AvailableClasses = 0x7FFF;
			Model = 10834;
			ObjectClass = 4;
			SubClass = 0;
			Level = 20;
			Name = "Common White Shirt";
			Name2 = "Common White Shirt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 400;
			InventoryType = InventoryTypes.Shirt;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Green Holiday Shirt)
*
***************************************************************/

namespace Server.Items
{
	public class GreenHolidayShirt : Item
	{
		public GreenHolidayShirt() : base()
		{
			Id = 17723;
			SellPrice = 750;
			AvailableClasses = 0x7FFF;
			Model = 29901;
			ObjectClass = 4;
			SubClass = 0;
			Level = 40;
			Name = "Green Holiday Shirt";
			Name2 = "Green Holiday Shirt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 3000;
			InventoryType = InventoryTypes.Shirt;
			Stackable = 1;
			Material = 7;
		}
	}
}


