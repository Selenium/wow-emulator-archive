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
*				(Recruit's Pants)
*
***************************************************************/

namespace Server.Items
{
	public class RecruitsPants : Item
	{
		public RecruitsPants() : base()
		{
			Id = 39;
			Resistance[0] = 2;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 9892;
			ObjectClass = 4;
			SubClass = 1;
			Level = 1;
			ReqLevel = 1;
			Name = "Recruit's Pants";
			Name2 = "Recruit's Pants";
			AvailableRaces = 0x1FF;
			BuyPrice = 5;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Squire's Pants)
*
***************************************************************/

namespace Server.Items
{
	public class SquiresPants : Item
	{
		public SquiresPants() : base()
		{
			Id = 44;
			Resistance[0] = 2;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 9937;
			ObjectClass = 4;
			SubClass = 1;
			Level = 1;
			ReqLevel = 1;
			Name = "Squire's Pants";
			Name2 = "Squire's Pants";
			AvailableRaces = 0x1FF;
			BuyPrice = 4;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Footpad's Pants)
*
***************************************************************/

namespace Server.Items
{
	public class FootpadsPants : Item
	{
		public FootpadsPants() : base()
		{
			Id = 48;
			Resistance[0] = 2;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 9913;
			ObjectClass = 4;
			SubClass = 1;
			Level = 1;
			ReqLevel = 1;
			Name = "Footpad's Pants";
			Name2 = "Footpad's Pants";
			AvailableRaces = 0x1FF;
			BuyPrice = 4;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Neophyte's Pants)
*
***************************************************************/

namespace Server.Items
{
	public class NeophytesPants : Item
	{
		public NeophytesPants() : base()
		{
			Id = 52;
			Resistance[0] = 2;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 9945;
			ObjectClass = 4;
			SubClass = 1;
			Level = 1;
			ReqLevel = 1;
			Name = "Neophyte's Pants";
			Name2 = "Neophyte's Pants";
			AvailableRaces = 0x1FF;
			BuyPrice = 5;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Dwarven Cloth Britches)
*
***************************************************************/

namespace Server.Items
{
	public class DwarvenClothBritches : Item
	{
		public DwarvenClothBritches() : base()
		{
			Id = 79;
			Resistance[0] = 9;
			Bonding = 1;
			SellPrice = 10;
			AvailableClasses = 0x7FFF;
			Model = 16847;
			ObjectClass = 4;
			SubClass = 1;
			Level = 5;
			Name = "Dwarven Cloth Britches";
			Name2 = "Dwarven Cloth Britches";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 52;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Thug Pants)
*
***************************************************************/

namespace Server.Items
{
	public class ThugPants : Item
	{
		public ThugPants() : base()
		{
			Id = 120;
			Resistance[0] = 2;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 10006;
			ObjectClass = 4;
			SubClass = 1;
			Level = 1;
			ReqLevel = 1;
			Name = "Thug Pants";
			Name2 = "Thug Pants";
			AvailableRaces = 0x1FF;
			BuyPrice = 4;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Deprecated Tauren Trapper's Pants)
*
***************************************************************/

namespace Server.Items
{
	public class DeprecatedTaurenTrappersPants : Item
	{
		public DeprecatedTaurenTrappersPants() : base()
		{
			Id = 128;
			Resistance[0] = 2;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 396;
			ObjectClass = 4;
			SubClass = 1;
			Level = 1;
			ReqLevel = 1;
			Name = "Deprecated Tauren Trapper's Pants";
			Name2 = "Deprecated Tauren Trapper's Pants";
			AvailableRaces = 0x1FF;
			BuyPrice = 5;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			Flags = 16;
		}
	}
}


/**************************************************************
*
*				(Brawler's Pants)
*
***************************************************************/

namespace Server.Items
{
	public class BrawlersPants : Item
	{
		public BrawlersPants() : base()
		{
			Id = 139;
			Resistance[0] = 2;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 9988;
			ObjectClass = 4;
			SubClass = 1;
			Level = 1;
			ReqLevel = 1;
			Name = "Brawler's Pants";
			Name2 = "Brawler's Pants";
			AvailableRaces = 0x1FF;
			BuyPrice = 4;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Rugged Trapper's Pants)
*
***************************************************************/

namespace Server.Items
{
	public class RuggedTrappersPants : Item
	{
		public RuggedTrappersPants() : base()
		{
			Id = 147;
			Resistance[0] = 2;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 9975;
			ObjectClass = 4;
			SubClass = 1;
			Level = 1;
			ReqLevel = 1;
			Name = "Rugged Trapper's Pants";
			Name2 = "Rugged Trapper's Pants";
			AvailableRaces = 0x1FF;
			BuyPrice = 5;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Tattered Cloth Pants)
*
***************************************************************/

namespace Server.Items
{
	public class TatteredClothPants : Item
	{
		public TatteredClothPants() : base()
		{
			Id = 194;
			Resistance[0] = 9;
			SellPrice = 9;
			AvailableClasses = 0x7FFF;
			Model = 16580;
			ObjectClass = 4;
			SubClass = 1;
			Level = 5;
			ReqLevel = 1;
			Name = "Tattered Cloth Pants";
			Name2 = "Tattered Cloth Pants";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 49;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Thick Cloth Pants)
*
***************************************************************/

namespace Server.Items
{
	public class ThickClothPants : Item
	{
		public ThickClothPants() : base()
		{
			Id = 201;
			Resistance[0] = 30;
			SellPrice = 455;
			AvailableClasses = 0x7FFF;
			Model = 16778;
			ObjectClass = 4;
			SubClass = 1;
			Level = 22;
			ReqLevel = 17;
			Name = "Thick Cloth Pants";
			Name2 = "Thick Cloth Pants";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2278;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Knitted Pants)
*
***************************************************************/

namespace Server.Items
{
	public class KnittedPants : Item
	{
		public KnittedPants() : base()
		{
			Id = 794;
			Resistance[0] = 16;
			SellPrice = 55;
			AvailableClasses = 0x7FFF;
			Model = 14450;
			ObjectClass = 4;
			SubClass = 1;
			Level = 10;
			ReqLevel = 5;
			Name = "Knitted Pants";
			Name2 = "Knitted Pants";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 279;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Heavy Weave Pants)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyWeavePants : Item
	{
		public HeavyWeavePants() : base()
		{
			Id = 838;
			Resistance[0] = 25;
			SellPrice = 225;
			AvailableClasses = 0x7FFF;
			Model = 14468;
			ObjectClass = 4;
			SubClass = 1;
			Level = 17;
			ReqLevel = 12;
			Name = "Heavy Weave Pants";
			Name2 = "Heavy Weave Pants";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1128;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Frayed Pants)
*
***************************************************************/

namespace Server.Items
{
	public class FrayedPants : Item
	{
		public FrayedPants() : base()
		{
			Id = 1378;
			Resistance[0] = 4;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 16656;
			ObjectClass = 4;
			SubClass = 1;
			Level = 2;
			ReqLevel = 1;
			Name = "Frayed Pants";
			Name2 = "Frayed Pants";
			AvailableRaces = 0x1FF;
			BuyPrice = 9;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Apprentice's Pants)
*
***************************************************************/

namespace Server.Items
{
	public class ApprenticesPants : Item
	{
		public ApprenticesPants() : base()
		{
			Id = 1395;
			Resistance[0] = 2;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 9924;
			ObjectClass = 4;
			SubClass = 1;
			Level = 1;
			ReqLevel = 1;
			Name = "Apprentice's Pants";
			Name2 = "Apprentice's Pants";
			AvailableRaces = 0x1FF;
			BuyPrice = 5;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Acolyte's Pants)
*
***************************************************************/

namespace Server.Items
{
	public class AcolytesPants : Item
	{
		public AcolytesPants() : base()
		{
			Id = 1396;
			Resistance[0] = 2;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 3260;
			ObjectClass = 4;
			SubClass = 1;
			Level = 1;
			ReqLevel = 1;
			Name = "Acolyte's Pants";
			Name2 = "Acolyte's Pants";
			AvailableRaces = 0x1FF;
			BuyPrice = 4;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Patchwork Pants)
*
***************************************************************/

namespace Server.Items
{
	public class PatchworkPants : Item
	{
		public PatchworkPants() : base()
		{
			Id = 1431;
			Resistance[0] = 12;
			SellPrice = 20;
			AvailableClasses = 0x7FFF;
			Model = 16796;
			ObjectClass = 4;
			SubClass = 1;
			Level = 8;
			ReqLevel = 3;
			Name = "Patchwork Pants";
			Name2 = "Patchwork Pants";
			AvailableRaces = 0x1FF;
			BuyPrice = 101;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Calico Pants)
*
***************************************************************/

namespace Server.Items
{
	public class CalicoPants : Item
	{
		public CalicoPants() : base()
		{
			Id = 1499;
			Resistance[0] = 17;
			SellPrice = 51;
			AvailableClasses = 0x7FFF;
			Model = 16552;
			ObjectClass = 4;
			SubClass = 1;
			Level = 11;
			ReqLevel = 6;
			Name = "Calico Pants";
			Name2 = "Calico Pants";
			AvailableRaces = 0x1FF;
			BuyPrice = 255;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Canvas Pants)
*
***************************************************************/

namespace Server.Items
{
	public class CanvasPants : Item
	{
		public CanvasPants() : base()
		{
			Id = 1768;
			Resistance[0] = 27;
			SellPrice = 217;
			AvailableClasses = 0x7FFF;
			Model = 14064;
			ObjectClass = 4;
			SubClass = 1;
			Level = 20;
			ReqLevel = 15;
			Name = "Canvas Pants";
			Name2 = "Canvas Pants";
			AvailableRaces = 0x1FF;
			BuyPrice = 1085;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Brocade Pants)
*
***************************************************************/

namespace Server.Items
{
	public class BrocadePants : Item
	{
		public BrocadePants() : base()
		{
			Id = 1776;
			Resistance[0] = 27;
			SellPrice = 257;
			AvailableClasses = 0x7FFF;
			Model = 12930;
			ObjectClass = 4;
			SubClass = 1;
			Level = 21;
			ReqLevel = 16;
			Name = "Brocade Pants";
			Name2 = "Brocade Pants";
			AvailableRaces = 0x1FF;
			BuyPrice = 1287;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Cross-stitched Pants)
*
***************************************************************/

namespace Server.Items
{
	public class CrossStitchedPants : Item
	{
		public CrossStitchedPants() : base()
		{
			Id = 1784;
			Resistance[0] = 32;
			SellPrice = 546;
			AvailableClasses = 0x7FFF;
			Model = 14374;
			ObjectClass = 4;
			SubClass = 1;
			Level = 27;
			ReqLevel = 22;
			Name = "Cross-stitched Pants";
			Name2 = "Cross-stitched Pants";
			AvailableRaces = 0x1FF;
			BuyPrice = 2734;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Lucky Trousers)
*
***************************************************************/

namespace Server.Items
{
	public class LuckyTrousers : Item
	{
		public LuckyTrousers() : base()
		{
			Id = 1832;
			Resistance[0] = 27;
			Bonding = 1;
			SellPrice = 362;
			AvailableClasses = 0x7FFF;
			Model = 16845;
			ObjectClass = 4;
			SubClass = 1;
			Level = 17;
			Name = "Lucky Trousers";
			Name2 = "Lucky Trousers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1811;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 40;
			StaminaBonus = 2;
			AgilityBonus = 2;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Silk-threaded Trousers)
*
***************************************************************/

namespace Server.Items
{
	public class SilkThreadedTrousers : Item
	{
		public SilkThreadedTrousers() : base()
		{
			Id = 1929;
			Resistance[0] = 28;
			Bonding = 2;
			SellPrice = 434;
			AvailableClasses = 0x7FFF;
			Model = 16848;
			ObjectClass = 4;
			SubClass = 1;
			Level = 18;
			ReqLevel = 13;
			Name = "Silk-threaded Trousers";
			Name2 = "Silk-threaded Trousers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2171;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 40;
			AgilityBonus = 3;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Thin Cloth Pants)
*
***************************************************************/

namespace Server.Items
{
	public class ThinClothPants : Item
	{
		public ThinClothPants() : base()
		{
			Id = 2120;
			Resistance[0] = 9;
			SellPrice = 10;
			AvailableClasses = 0x7FFF;
			Model = 8969;
			ObjectClass = 4;
			SubClass = 1;
			Level = 5;
			ReqLevel = 1;
			Name = "Thin Cloth Pants";
			Name2 = "Thin Cloth Pants";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 50;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Padded Pants)
*
***************************************************************/

namespace Server.Items
{
	public class PaddedPants : Item
	{
		public PaddedPants() : base()
		{
			Id = 2159;
			Resistance[0] = 34;
			SellPrice = 829;
			AvailableClasses = 0x7FFF;
			Model = 14479;
			ObjectClass = 4;
			SubClass = 1;
			Level = 27;
			ReqLevel = 22;
			Name = "Padded Pants";
			Name2 = "Padded Pants";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 4148;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Urchin's Pants)
*
***************************************************************/

namespace Server.Items
{
	public class UrchinsPants : Item
	{
		public UrchinsPants() : base()
		{
			Id = 2238;
			Resistance[0] = 16;
			Bonding = 1;
			SellPrice = 60;
			AvailableClasses = 0x7FFF;
			Model = 16842;
			ObjectClass = 4;
			SubClass = 1;
			Level = 10;
			Name = "Urchin's Pants";
			Name2 = "Urchin's Pants";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 303;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Necromancer Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class NecromancerLeggings : Item
	{
		public NecromancerLeggings() : base()
		{
			Id = 2277;
			Resistance[0] = 45;
			Bonding = 2;
			SellPrice = 3620;
			AvailableClasses = 0x7FFF;
			Model = 3173;
			ObjectClass = 4;
			SubClass = 1;
			Level = 35;
			ReqLevel = 30;
			Name = "Necromancer Leggings";
			Name2 = "Necromancer Leggings";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 18104;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 65;
			SetSpell( 7709 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 11;
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Woven Pants)
*
***************************************************************/

namespace Server.Items
{
	public class WovenPants : Item
	{
		public WovenPants() : base()
		{
			Id = 2366;
			Resistance[0] = 16;
			SellPrice = 59;
			AvailableClasses = 0x7FFF;
			Model = 14458;
			ObjectClass = 4;
			SubClass = 1;
			Level = 10;
			ReqLevel = 5;
			Name = "Woven Pants";
			Name2 = "Woven Pants";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 298;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Russet Pants)
*
***************************************************************/

namespace Server.Items
{
	public class RussetPants : Item
	{
		public RussetPants() : base()
		{
			Id = 2431;
			Resistance[0] = 41;
			SellPrice = 2043;
			AvailableClasses = 0x7FFF;
			Model = 14483;
			ObjectClass = 4;
			SubClass = 1;
			Level = 37;
			ReqLevel = 32;
			Name = "Russet Pants";
			Name2 = "Russet Pants";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 10215;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Embroidered Pants)
*
***************************************************************/

namespace Server.Items
{
	public class EmbroideredPants : Item
	{
		public EmbroideredPants() : base()
		{
			Id = 2437;
			Resistance[0] = 54;
			SellPrice = 5578;
			AvailableClasses = 0x7FFF;
			Model = 16770;
			ObjectClass = 4;
			SubClass = 1;
			Level = 50;
			ReqLevel = 45;
			Name = "Embroidered Pants";
			Name2 = "Embroidered Pants";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 27890;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Night Watch Pantaloons)
*
***************************************************************/

namespace Server.Items
{
	public class NightWatchPantaloons : Item
	{
		public NightWatchPantaloons() : base()
		{
			Id = 2954;
			Resistance[0] = 39;
			Bonding = 1;
			SellPrice = 2485;
			AvailableClasses = 0x7FFF;
			Model = 14615;
			ObjectClass = 4;
			SubClass = 1;
			Level = 33;
			Name = "Night Watch Pantaloons";
			Name2 = "Night Watch Pantaloons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 12425;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
			StrBonus = 8;
			IqBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Journeyman's Pants)
*
***************************************************************/

namespace Server.Items
{
	public class JourneymansPants : Item
	{
		public JourneymansPants() : base()
		{
			Id = 2958;
			Resistance[0] = 17;
			Bonding = 2;
			SellPrice = 94;
			AvailableClasses = 0x7FFF;
			Model = 14498;
			ObjectClass = 4;
			SubClass = 1;
			Level = 10;
			ReqLevel = 5;
			Name = "Journeyman's Pants";
			Name2 = "Journeyman's Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 473;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			IqBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Spellbinder Pants)
*
***************************************************************/

namespace Server.Items
{
	public class SpellbinderPants : Item
	{
		public SpellbinderPants() : base()
		{
			Id = 2970;
			Resistance[0] = 25;
			Bonding = 2;
			SellPrice = 333;
			AvailableClasses = 0x7FFF;
			Model = 14529;
			ObjectClass = 4;
			SubClass = 1;
			Level = 16;
			ReqLevel = 11;
			Name = "Spellbinder Pants";
			Name2 = "Spellbinder Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1666;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 40;
			SpiritBonus = 3;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Seer's Pants)
*
***************************************************************/

namespace Server.Items
{
	public class SeersPants : Item
	{
		public SeersPants() : base()
		{
			Id = 2982;
			Resistance[0] = 29;
			Bonding = 2;
			SellPrice = 565;
			AvailableClasses = 0x7FFF;
			Model = 14554;
			ObjectClass = 4;
			SubClass = 1;
			Level = 20;
			ReqLevel = 15;
			Name = "Seer's Pants";
			Name2 = "Seer's Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2829;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			IqBonus = 5;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Bright Pants)
*
***************************************************************/

namespace Server.Items
{
	public class BrightPants : Item
	{
		public BrightPants() : base()
		{
			Id = 3067;
			Resistance[0] = 35;
			Bonding = 2;
			SellPrice = 1275;
			AvailableClasses = 0x7FFF;
			Model = 3217;
			ObjectClass = 4;
			SubClass = 1;
			Level = 26;
			ReqLevel = 21;
			Name = "Bright Pants";
			Name2 = "Bright Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6375;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 50;
			StaminaBonus = 6;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Smoldering Pants)
*
***************************************************************/

namespace Server.Items
{
	public class SmolderingPants : Item
	{
		public SmolderingPants() : base()
		{
			Id = 3073;
			Resistance[0] = 35;
			Bonding = 2;
			SellPrice = 1211;
			AvailableClasses = 0x7FFF;
			Model = 16846;
			ObjectClass = 4;
			SubClass = 1;
			Level = 26;
			ReqLevel = 21;
			Name = "Smoldering Pants";
			Name2 = "Smoldering Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6059;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 50;
			SetSpell( 9400 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Webbed Pants)
*
***************************************************************/

namespace Server.Items
{
	public class WebbedPants : Item
	{
		public WebbedPants() : base()
		{
			Id = 3263;
			Resistance[0] = 6;
			SellPrice = 4;
			AvailableClasses = 0x7FFF;
			Model = 3432;
			ObjectClass = 4;
			SubClass = 1;
			Level = 3;
			ReqLevel = 1;
			Name = "Webbed Pants";
			Name2 = "Webbed Pants";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 22;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Ancestral Woollies)
*
***************************************************************/

namespace Server.Items
{
	public class AncestralWoollies : Item
	{
		public AncestralWoollies() : base()
		{
			Id = 3291;
			Resistance[0] = 22;
			Bonding = 2;
			SellPrice = 202;
			AvailableClasses = 0x7FFF;
			Model = 14511;
			ObjectClass = 4;
			SubClass = 1;
			Level = 13;
			ReqLevel = 8;
			Name = "Ancestral Woollies";
			Name2 = "Ancestral Woollies";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1013;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Barbaric Loincloth)
*
***************************************************************/

namespace Server.Items
{
	public class BarbaricLoincloth : Item
	{
		public BarbaricLoincloth() : base()
		{
			Id = 3309;
			Resistance[0] = 25;
			Bonding = 2;
			SellPrice = 333;
			AvailableClasses = 0x7FFF;
			Model = 16591;
			ObjectClass = 4;
			SubClass = 1;
			Level = 16;
			ReqLevel = 11;
			Name = "Barbaric Loincloth";
			Name2 = "Barbaric Loincloth";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1666;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 40;
			StrBonus = 3;
			SpiritBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Stamped Trousers)
*
***************************************************************/

namespace Server.Items
{
	public class StampedTrousers : Item
	{
		public StampedTrousers() : base()
		{
			Id = 3457;
			Resistance[0] = 28;
			Bonding = 1;
			SellPrice = 444;
			AvailableClasses = 0x7FFF;
			Model = 16850;
			ObjectClass = 4;
			SubClass = 1;
			Level = 18;
			Name = "Stamped Trousers";
			Name2 = "Stamped Trousers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2220;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 40;
			SpiritBonus = 3;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Seafarer's Pantaloons)
*
***************************************************************/

namespace Server.Items
{
	public class SeafarersPantaloons : Item
	{
		public SeafarersPantaloons() : base()
		{
			Id = 3563;
			Resistance[0] = 29;
			Bonding = 2;
			SellPrice = 557;
			AvailableClasses = 0x7FFF;
			Model = 3179;
			ObjectClass = 4;
			SubClass = 1;
			Level = 20;
			ReqLevel = 15;
			Name = "Seafarer's Pantaloons";
			Name2 = "Seafarer's Pantaloons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2787;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			StaminaBonus = 4;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Interlaced Pants)
*
***************************************************************/

namespace Server.Items
{
	public class InterlacedPants : Item
	{
		public InterlacedPants() : base()
		{
			Id = 3797;
			Resistance[0] = 41;
			SellPrice = 1692;
			AvailableClasses = 0x7FFF;
			Model = 14711;
			ObjectClass = 4;
			SubClass = 1;
			Level = 39;
			ReqLevel = 34;
			Name = "Interlaced Pants";
			Name2 = "Interlaced Pants";
			AvailableRaces = 0x1FF;
			BuyPrice = 8460;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Sturdy Cloth Trousers)
*
***************************************************************/

namespace Server.Items
{
	public class SturdyClothTrousers : Item
	{
		public SturdyClothTrousers() : base()
		{
			Id = 3834;
			Resistance[0] = 13;
			Bonding = 1;
			SellPrice = 32;
			AvailableClasses = 0x7FFF;
			Model = 16839;
			ObjectClass = 4;
			SubClass = 1;
			Level = 8;
			Name = "Sturdy Cloth Trousers";
			Name2 = "Sturdy Cloth Trousers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 162;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Crochet Pants)
*
***************************************************************/

namespace Server.Items
{
	public class CrochetPants : Item
	{
		public CrochetPants() : base()
		{
			Id = 3941;
			Resistance[0] = 46;
			SellPrice = 2598;
			AvailableClasses = 0x7FFF;
			Model = 16719;
			ObjectClass = 4;
			SubClass = 1;
			Level = 45;
			ReqLevel = 40;
			Name = "Crochet Pants";
			Name2 = "Crochet Pants";
			AvailableRaces = 0x1FF;
			BuyPrice = 12993;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Twill Pants)
*
***************************************************************/

namespace Server.Items
{
	public class TwillPants : Item
	{
		public TwillPants() : base()
		{
			Id = 3949;
			Resistance[0] = 60;
			SellPrice = 6517;
			AvailableClasses = 0x7FFF;
			Model = 16701;
			ObjectClass = 4;
			SubClass = 1;
			Level = 59;
			ReqLevel = 54;
			Name = "Twill Pants";
			Name2 = "Twill Pants";
			AvailableRaces = 0x1FF;
			BuyPrice = 32586;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Silver-thread Pants)
*
***************************************************************/

namespace Server.Items
{
	public class SilverThreadPants : Item
	{
		public SilverThreadPants() : base()
		{
			Id = 4037;
			Resistance[0] = 37;
			Bonding = 2;
			SellPrice = 1821;
			AvailableClasses = 0x7FFF;
			Model = 14989;
			ObjectClass = 4;
			SubClass = 1;
			Level = 30;
			ReqLevel = 25;
			Name = "Silver-thread Pants";
			Name2 = "Silver-thread Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 9106;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
			SpiritBonus = 8;
			IqBonus = 4;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Aurora Pants)
*
***************************************************************/

namespace Server.Items
{
	public class AuroraPants : Item
	{
		public AuroraPants() : base()
		{
			Id = 4044;
			Resistance[0] = 46;
			Bonding = 2;
			SellPrice = 4584;
			AvailableClasses = 0x7FFF;
			Model = 14659;
			ObjectClass = 4;
			SubClass = 1;
			Level = 40;
			ReqLevel = 35;
			Name = "Aurora Pants";
			Name2 = "Aurora Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 22921;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
			SpiritBonus = 11;
			IqBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Mistscape Pants)
*
***************************************************************/

namespace Server.Items
{
	public class MistscapePants : Item
	{
		public MistscapePants() : base()
		{
			Id = 4046;
			Resistance[0] = 52;
			Bonding = 2;
			SellPrice = 6783;
			AvailableClasses = 0x7FFF;
			Model = 14685;
			ObjectClass = 4;
			SubClass = 1;
			Level = 45;
			ReqLevel = 40;
			Name = "Mistscape Pants";
			Name2 = "Mistscape Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 33919;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
			StaminaBonus = 12;
			IqBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Solliden's Trousers)
*
***************************************************************/

namespace Server.Items
{
	public class SollidensTrousers : Item
	{
		public SollidensTrousers() : base()
		{
			Id = 4261;
			Resistance[0] = 13;
			SellPrice = 31;
			AvailableClasses = 0x7FFF;
			Model = 16794;
			ObjectClass = 4;
			SubClass = 1;
			Level = 8;
			ReqLevel = 3;
			Name = "Solliden's Trousers";
			Name2 = "Solliden's Trousers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 159;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Handstitched Linen Britches)
*
***************************************************************/

namespace Server.Items
{
	public class HandstitchedLinenBritches : Item
	{
		public HandstitchedLinenBritches() : base()
		{
			Id = 4309;
			Resistance[0] = 23;
			Bonding = 2;
			SellPrice = 226;
			AvailableClasses = 0x7FFF;
			Model = 12395;
			ObjectClass = 4;
			SubClass = 1;
			Level = 14;
			ReqLevel = 9;
			Name = "Handstitched Linen Britches";
			Name2 = "Handstitched Linen Britches";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1133;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 40;
			IqBonus = 2;
			SpiritBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Heavy Woolen Pants)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyWoolenPants : Item
	{
		public HeavyWoolenPants() : base()
		{
			Id = 4316;
			Resistance[0] = 31;
			Bonding = 2;
			SellPrice = 743;
			AvailableClasses = 0x7FFF;
			Model = 6297;
			ObjectClass = 4;
			SubClass = 1;
			Level = 22;
			ReqLevel = 17;
			Name = "Heavy Woolen Pants";
			Name2 = "Heavy Woolen Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3715;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			IqBonus = 6;
			SpiritBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Phoenix Pants)
*
***************************************************************/

namespace Server.Items
{
	public class PhoenixPants : Item
	{
		public PhoenixPants() : base()
		{
			Id = 4317;
			Resistance[0] = 34;
			Bonding = 2;
			SellPrice = 1076;
			AvailableClasses = 0x7FFF;
			Model = 12399;
			ObjectClass = 4;
			SubClass = 1;
			Level = 25;
			ReqLevel = 20;
			Name = "Phoenix Pants";
			Name2 = "Phoenix Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5382;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 50;
			SetSpell( 7689 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Brown Linen Pants)
*
***************************************************************/

namespace Server.Items
{
	public class BrownLinenPants : Item
	{
		public BrownLinenPants() : base()
		{
			Id = 4343;
			Resistance[0] = 16;
			SellPrice = 60;
			AvailableClasses = 0x7FFF;
			Model = 12388;
			ObjectClass = 4;
			SubClass = 1;
			Level = 10;
			ReqLevel = 5;
			Name = "Brown Linen Pants";
			Name2 = "Brown Linen Pants";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 301;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Scarecrow Trousers)
*
***************************************************************/

namespace Server.Items
{
	public class ScarecrowTrousers : Item
	{
		public ScarecrowTrousers() : base()
		{
			Id = 4434;
			Resistance[0] = 29;
			Bonding = 2;
			SellPrice = 572;
			AvailableClasses = 0x7FFF;
			Model = 4365;
			ObjectClass = 4;
			SubClass = 1;
			Level = 20;
			ReqLevel = 15;
			Name = "Scarecrow Trousers";
			Name2 = "Scarecrow Trousers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2861;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Swampland Trousers)
*
***************************************************************/

namespace Server.Items
{
	public class SwamplandTrousers : Item
	{
		public SwamplandTrousers() : base()
		{
			Id = 4505;
			Resistance[0] = 38;
			Bonding = 1;
			SellPrice = 1974;
			AvailableClasses = 0x7FFF;
			Model = 16791;
			ObjectClass = 4;
			SubClass = 1;
			Level = 31;
			Name = "Swampland Trousers";
			Name2 = "Swampland Trousers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 9870;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
			AgilityBonus = 8;
			IqBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Humbert's Pants)
*
***************************************************************/

namespace Server.Items
{
	public class HumbertsPants : Item
	{
		public HumbertsPants() : base()
		{
			Id = 4723;
			Resistance[0] = 37;
			Bonding = 2;
			SellPrice = 1703;
			AvailableClasses = 0x7FFF;
			Model = 14332;
			ObjectClass = 4;
			SubClass = 1;
			Level = 29;
			ReqLevel = 24;
			Name = "Humbert's Pants";
			Name2 = "Humbert's Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 8518;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
			StaminaBonus = 7;
			IqBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Artisan's Trousers)
*
***************************************************************/

namespace Server.Items
{
	public class ArtisansTrousers : Item
	{
		public ArtisansTrousers() : base()
		{
			Id = 5016;
			Resistance[0] = 41;
			Bonding = 1;
			SellPrice = 2955;
			AvailableClasses = 0x7FFF;
			Model = 16849;
			ObjectClass = 4;
			SubClass = 1;
			Level = 35;
			Name = "Artisan's Trousers";
			Name2 = "Artisan's Trousers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 14775;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
			AgilityBonus = 9;
			IqBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Sea Dog Britches)
*
***************************************************************/

namespace Server.Items
{
	public class SeaDogBritches : Item
	{
		public SeaDogBritches() : base()
		{
			Id = 5310;
			Resistance[0] = 29;
			Bonding = 1;
			SellPrice = 555;
			AvailableClasses = 0x7FFF;
			Model = 7533;
			ObjectClass = 4;
			SubClass = 1;
			Level = 20;
			Name = "Sea Dog Britches";
			Name2 = "Sea Dog Britches";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2778;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			StrBonus = 4;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Tapered Pants)
*
***************************************************************/

namespace Server.Items
{
	public class TaperedPants : Item
	{
		public TaperedPants() : base()
		{
			Id = 6076;
			Resistance[0] = 9;
			Bonding = 1;
			SellPrice = 9;
			AvailableClasses = 0x7FFF;
			Model = 16843;
			ObjectClass = 4;
			SubClass = 1;
			Level = 5;
			Name = "Tapered Pants";
			Name2 = "Tapered Pants";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 47;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Squire's Pants)
*
***************************************************************/

namespace Server.Items
{
	public class DwarfSquiresPants : Item
	{
		public DwarfSquiresPants() : base()
		{
			Id = 6118;
			Resistance[0] = 2;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 9974;
			ObjectClass = 4;
			SubClass = 1;
			Level = 1;
			ReqLevel = 1;
			Name = "Squire's Pants";
			Name2 = "Squire's Pants";
			AvailableRaces = 0x1FF;
			BuyPrice = 4;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Recruit's Pants)
*
***************************************************************/

namespace Server.Items
{
	public class NightElfRecruitsPants : Item
	{
		public NightElfRecruitsPants() : base()
		{
			Id = 6121;
			Resistance[0] = 2;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 9984;
			ObjectClass = 4;
			SubClass = 1;
			Level = 1;
			ReqLevel = 1;
			Name = "Recruit's Pants";
			Name2 = "Recruit's Pants";
			AvailableRaces = 0x1FF;
			BuyPrice = 4;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Novice's Pants)
*
***************************************************************/

namespace Server.Items
{
	public class NovicesPants : Item
	{
		public NovicesPants() : base()
		{
			Id = 6124;
			Resistance[0] = 2;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 9987;
			ObjectClass = 4;
			SubClass = 1;
			Level = 1;
			ReqLevel = 1;
			Name = "Novice's Pants";
			Name2 = "Novice's Pants";
			AvailableRaces = 0x1FF;
			BuyPrice = 5;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Trapper's Pants)
*
***************************************************************/

namespace Server.Items
{
	public class TrappersPants : Item
	{
		public TrappersPants() : base()
		{
			Id = 6126;
			Resistance[0] = 2;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 10002;
			ObjectClass = 4;
			SubClass = 1;
			Level = 1;
			ReqLevel = 1;
			Name = "Trapper's Pants";
			Name2 = "Trapper's Pants";
			AvailableRaces = 0x1FF;
			BuyPrice = 5;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Trapper's Pants)
*
***************************************************************/

namespace Server.Items
{
	public class TrappersPants6131 : Item
	{
		public TrappersPants6131() : base()
		{
			Id = 6131;
			Resistance[0] = 2;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 10244;
			ObjectClass = 4;
			SubClass = 1;
			Level = 1;
			ReqLevel = 1;
			Name = "Trapper's Pants";
			Name2 = "Trapper's Pants";
			AvailableRaces = 0x1FF;
			BuyPrice = 5;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			Flags = 16;
		}
	}
}


/**************************************************************
*
*				(Thug Pants)
*
***************************************************************/

namespace Server.Items
{
	public class TrollThugPants : Item
	{
		public TrollThugPants() : base()
		{
			Id = 6137;
			Resistance[0] = 2;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 10114;
			ObjectClass = 4;
			SubClass = 1;
			Level = 1;
			ReqLevel = 1;
			Name = "Thug Pants";
			Name2 = "Thug Pants";
			AvailableRaces = 0x1FF;
			BuyPrice = 4;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Disciple's Pants)
*
***************************************************************/

namespace Server.Items
{
	public class DisciplesPants : Item
	{
		public DisciplesPants() : base()
		{
			Id = 6267;
			Resistance[0] = 20;
			Bonding = 2;
			SellPrice = 149;
			AvailableClasses = 0x7FFF;
			Model = 16561;
			ObjectClass = 4;
			SubClass = 1;
			Level = 12;
			ReqLevel = 7;
			Name = "Disciple's Pants";
			Name2 = "Disciple's Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 538;
			BuyPrice = 747;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Sacred Burial Trousers)
*
***************************************************************/

namespace Server.Items
{
	public class SacredBurialTrousers : Item
	{
		public SacredBurialTrousers() : base()
		{
			Id = 6282;
			Resistance[0] = 39;
			Bonding = 1;
			SellPrice = 2243;
			AvailableClasses = 0x7FFF;
			Model = 11166;
			ObjectClass = 4;
			SubClass = 1;
			Level = 32;
			Name = "Sacred Burial Trousers";
			Name2 = "Sacred Burial Trousers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11219;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
			StrBonus = 3;
			SpiritBonus = 5;
			IqBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Nightsky Trousers)
*
***************************************************************/

namespace Server.Items
{
	public class NightskyTrousers : Item
	{
		public NightskyTrousers() : base()
		{
			Id = 6405;
			Resistance[0] = 42;
			Bonding = 2;
			SellPrice = 3167;
			AvailableClasses = 0x7FFF;
			Model = 14625;
			ObjectClass = 4;
			SubClass = 1;
			Level = 36;
			ReqLevel = 31;
			Name = "Nightsky Trousers";
			Name2 = "Nightsky Trousers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 15839;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
			StaminaBonus = 5;
			AgilityBonus = 5;
			IqBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Willow Pants)
*
***************************************************************/

namespace Server.Items
{
	public class WillowPants : Item
	{
		public WillowPants() : base()
		{
			Id = 6540;
			Resistance[0] = 28;
			Bonding = 2;
			SellPrice = 431;
			AvailableClasses = 0x7FFF;
			Model = 14738;
			ObjectClass = 4;
			SubClass = 1;
			Level = 18;
			ReqLevel = 13;
			Name = "Willow Pants";
			Name2 = "Willow Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 540;
			BuyPrice = 2156;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Shimmering Trousers)
*
***************************************************************/

namespace Server.Items
{
	public class ShimmeringTrousers : Item
	{
		public ShimmeringTrousers() : base()
		{
			Id = 6568;
			Resistance[0] = 33;
			Bonding = 2;
			SellPrice = 920;
			AvailableClasses = 0x7FFF;
			Model = 14746;
			ObjectClass = 4;
			SubClass = 1;
			Level = 24;
			ReqLevel = 19;
			Name = "Shimmering Trousers";
			Name2 = "Shimmering Trousers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 542;
			BuyPrice = 4603;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Sage's Pants)
*
***************************************************************/

namespace Server.Items
{
	public class SagesPants : Item
	{
		public SagesPants() : base()
		{
			Id = 6616;
			Resistance[0] = 39;
			Bonding = 2;
			SellPrice = 2203;
			AvailableClasses = 0x7FFF;
			Model = 16863;
			ObjectClass = 4;
			SubClass = 1;
			Level = 32;
			ReqLevel = 27;
			Name = "Sage's Pants";
			Name2 = "Sage's Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 545;
			BuyPrice = 11019;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Scarab Trousers)
*
***************************************************************/

namespace Server.Items
{
	public class ScarabTrousers : Item
	{
		public ScarabTrousers() : base()
		{
			Id = 6659;
			Resistance[0] = 29;
			Bonding = 1;
			SellPrice = 541;
			AvailableClasses = 0x7FFF;
			Model = 12777;
			ObjectClass = 4;
			SubClass = 1;
			Level = 20;
			Name = "Scarab Trousers";
			Name2 = "Scarab Trousers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2705;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			StaminaBonus = 4;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Ripped Pants)
*
***************************************************************/

namespace Server.Items
{
	public class RippedPants : Item
	{
		public RippedPants() : base()
		{
			Id = 6713;
			Resistance[0] = 9;
			Bonding = 1;
			SellPrice = 10;
			AvailableClasses = 0x7FFF;
			Model = 12928;
			ObjectClass = 4;
			SubClass = 1;
			Level = 5;
			Name = "Ripped Pants";
			Name2 = "Ripped Pants";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 51;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Dryleaf Pants)
*
***************************************************************/

namespace Server.Items
{
	public class DryleafPants : Item
	{
		public DryleafPants() : base()
		{
			Id = 6737;
			Resistance[0] = 41;
			Bonding = 1;
			SellPrice = 2805;
			AvailableClasses = 0x7FFF;
			Model = 16852;
			ObjectClass = 4;
			SubClass = 1;
			Level = 35;
			Name = "Dryleaf Pants";
			Name2 = "Dryleaf Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 14027;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
			StaminaBonus = 9;
			IqBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Gaze Dreamer Pants)
*
***************************************************************/

namespace Server.Items
{
	public class GazeDreamerPants : Item
	{
		public GazeDreamerPants() : base()
		{
			Id = 6903;
			Resistance[0] = 36;
			Bonding = 1;
			SellPrice = 1549;
			AvailableClasses = 0x7FFF;
			Model = 13357;
			ObjectClass = 4;
			SubClass = 1;
			Level = 28;
			ReqLevel = 23;
			Name = "Gaze Dreamer Pants";
			Name2 = "Gaze Dreamer Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7747;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 50;
			SpiritBonus = 7;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Leech Pants)
*
***************************************************************/

namespace Server.Items
{
	public class LeechPants : Item
	{
		public LeechPants() : base()
		{
			Id = 6910;
			Resistance[0] = 42;
			Bonding = 1;
			SellPrice = 2298;
			AvailableClasses = 0x7FFF;
			Model = 13365;
			ObjectClass = 4;
			SubClass = 1;
			Level = 31;
			ReqLevel = 26;
			Name = "Leech Pants";
			Name2 = "Leech Pants";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 11492;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 65;
			SpiritBonus = 5;
			IqBonus = 15;
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Azure Silk Pants)
*
***************************************************************/

namespace Server.Items
{
	public class AzureSilkPants : Item
	{
		public AzureSilkPants() : base()
		{
			Id = 7046;
			Resistance[0] = 36;
			Bonding = 2;
			SellPrice = 1494;
			AvailableClasses = 0x7FFF;
			Model = 13649;
			ObjectClass = 4;
			SubClass = 1;
			Level = 28;
			ReqLevel = 23;
			Name = "Azure Silk Pants";
			Name2 = "Azure Silk Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7473;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 50;
			SetSpell( 7703 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Crimson Silk Pantaloons)
*
***************************************************************/

namespace Server.Items
{
	public class CrimsonSilkPantaloons : Item
	{
		public CrimsonSilkPantaloons() : base()
		{
			Id = 7062;
			Resistance[0] = 43;
			SellPrice = 2430;
			AvailableClasses = 0x7FFF;
			Model = 13679;
			ObjectClass = 4;
			SubClass = 1;
			Level = 39;
			ReqLevel = 34;
			Name = "Crimson Silk Pantaloons";
			Name2 = "Crimson Silk Pantaloons";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 12150;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Elder's Pants)
*
***************************************************************/

namespace Server.Items
{
	public class EldersPants : Item
	{
		public EldersPants() : base()
		{
			Id = 7368;
			Resistance[0] = 40;
			Bonding = 2;
			SellPrice = 2677;
			AvailableClasses = 0x7FFF;
			Model = 16600;
			ObjectClass = 4;
			SubClass = 1;
			Level = 34;
			ReqLevel = 29;
			Name = "Elder's Pants";
			Name2 = "Elder's Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 546;
			BuyPrice = 13385;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Twilight Pants)
*
***************************************************************/

namespace Server.Items
{
	public class TwilightPants : Item
	{
		public TwilightPants() : base()
		{
			Id = 7431;
			Resistance[0] = 45;
			Bonding = 2;
			SellPrice = 3899;
			AvailableClasses = 0x7FFF;
			Model = 14644;
			ObjectClass = 4;
			SubClass = 1;
			Level = 39;
			ReqLevel = 34;
			Name = "Twilight Pants";
			Name2 = "Twilight Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 547;
			BuyPrice = 19495;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Regal Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class RegalLeggings : Item
	{
		public RegalLeggings() : base()
		{
			Id = 7469;
			Resistance[0] = 51;
			Bonding = 2;
			SellPrice = 6284;
			AvailableClasses = 0x7FFF;
			Model = 15015;
			ObjectClass = 4;
			SubClass = 1;
			Level = 44;
			ReqLevel = 39;
			Name = "Regal Leggings";
			Name2 = "Regal Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 549;
			BuyPrice = 31421;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Gossamer Pants)
*
***************************************************************/

namespace Server.Items
{
	public class GossamerPants : Item
	{
		public GossamerPants() : base()
		{
			Id = 7519;
			Resistance[0] = 54;
			Bonding = 2;
			SellPrice = 7635;
			AvailableClasses = 0x7FFF;
			Model = 15401;
			ObjectClass = 4;
			SubClass = 1;
			Level = 47;
			ReqLevel = 42;
			Name = "Gossamer Pants";
			Name2 = "Gossamer Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 550;
			BuyPrice = 38175;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Blighted Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class BlightedLeggings : Item
	{
		public BlightedLeggings() : base()
		{
			Id = 7709;
			Resistance[0] = 45;
			Bonding = 1;
			SellPrice = 3559;
			AvailableClasses = 0x7FFF;
			Model = 15824;
			ObjectClass = 4;
			SubClass = 1;
			Level = 35;
			ReqLevel = 30;
			Name = "Blighted Leggings";
			Name2 = "Blighted Leggings";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 17797;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 65;
			SetSpell( 7709 , 1 , 0 , -1 , 0 , -1 );
			IqBonus = 17;
		}
	}
}


/**************************************************************
*
*				(Hibernal Pants)
*
***************************************************************/

namespace Server.Items
{
	public class HibernalPants : Item
	{
		public HibernalPants() : base()
		{
			Id = 8112;
			Resistance[0] = 56;
			Bonding = 2;
			SellPrice = 8436;
			AvailableClasses = 0x7FFF;
			Model = 16632;
			ObjectClass = 4;
			SubClass = 1;
			Level = 49;
			ReqLevel = 44;
			Name = "Hibernal Pants";
			Name2 = "Hibernal Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 42181;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
			SpiritBonus = 11;
			AgilityBonus = 11;
			IqBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Imperial Red Pants)
*
***************************************************************/

namespace Server.Items
{
	public class ImperialRedPants : Item
	{
		public ImperialRedPants() : base()
		{
			Id = 8251;
			Resistance[0] = 61;
			Bonding = 2;
			SellPrice = 12080;
			AvailableClasses = 0x7FFF;
			Model = 16764;
			ObjectClass = 4;
			SubClass = 1;
			Level = 54;
			ReqLevel = 49;
			Name = "Imperial Red Pants";
			Name2 = "Imperial Red Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 60401;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
			AgilityBonus = 15;
			SpiritBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Arcane Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class ArcaneLeggings : Item
	{
		public ArcaneLeggings() : base()
		{
			Id = 8289;
			Resistance[0] = 68;
			Bonding = 2;
			SellPrice = 16688;
			AvailableClasses = 0x7FFF;
			Model = 17252;
			ObjectClass = 4;
			SubClass = 1;
			Level = 60;
			ReqLevel = 55;
			Name = "Arcane Leggings";
			Name2 = "Arcane Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 83441;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
			StaminaBonus = 17;
			SpiritBonus = 17;
		}
	}
}


/**************************************************************
*
*				(Stoneweaver Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class StoneweaverLeggings : Item
	{
		public StoneweaverLeggings() : base()
		{
			Id = 9407;
			Resistance[0] = 51;
			Bonding = 1;
			SellPrice = 5094;
			AvailableClasses = 0x7FFF;
			Model = 12345;
			ObjectClass = 4;
			SubClass = 1;
			Level = 40;
			ReqLevel = 35;
			Name = "Stoneweaver Leggings";
			Name2 = "Stoneweaver Leggings";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 25470;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 65;
			IqBonus = 15;
			StaminaBonus = 9;
			SpiritBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Spellshock Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class SpellshockLeggings : Item
	{
		public SpellshockLeggings() : base()
		{
			Id = 9484;
			Resistance[0] = 63;
			Bonding = 2;
			SellPrice = 10962;
			AvailableClasses = 0x7FFF;
			Model = 22426;
			ObjectClass = 4;
			SubClass = 1;
			Level = 50;
			ReqLevel = 45;
			Name = "Spellshock Leggings";
			Name2 = "Spellshock Leggings";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 54811;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 65;
			SetSpell( 14047 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 10;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Lace Pants)
*
***************************************************************/

namespace Server.Items
{
	public class LacePants : Item
	{
		public LacePants() : base()
		{
			Id = 9600;
			Resistance[0] = 19;
			Bonding = 1;
			SellPrice = 93;
			AvailableClasses = 0x7FFF;
			Model = 18911;
			ObjectClass = 4;
			SubClass = 1;
			Level = 12;
			Name = "Lace Pants";
			Name2 = "Lace Pants";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 465;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Simple Britches)
*
***************************************************************/

namespace Server.Items
{
	public class SimpleBritches : Item
	{
		public SimpleBritches() : base()
		{
			Id = 9747;
			Resistance[0] = 23;
			Bonding = 2;
			SellPrice = 227;
			AvailableClasses = 0x7FFF;
			Model = 14711;
			ObjectClass = 4;
			SubClass = 1;
			Level = 14;
			ReqLevel = 9;
			Name = "Simple Britches";
			Name2 = "Simple Britches";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 539;
			BuyPrice = 1139;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Greenweave Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class GreenweaveLeggings : Item
	{
		public GreenweaveLeggings() : base()
		{
			Id = 9772;
			Resistance[0] = 36;
			Bonding = 2;
			SellPrice = 1328;
			AvailableClasses = 0x7FFF;
			Model = 25942;
			ObjectClass = 4;
			SubClass = 1;
			Level = 27;
			ReqLevel = 22;
			Name = "Greenweave Leggings";
			Name2 = "Greenweave Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 543;
			BuyPrice = 6644;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Ivycloth Pants)
*
***************************************************************/

namespace Server.Items
{
	public class IvyclothPants : Item
	{
		public IvyclothPants() : base()
		{
			Id = 9797;
			Resistance[0] = 36;
			Bonding = 2;
			SellPrice = 1528;
			AvailableClasses = 0x7FFF;
			Model = 27755;
			ObjectClass = 4;
			SubClass = 1;
			Level = 28;
			ReqLevel = 23;
			Name = "Ivycloth Pants";
			Name2 = "Ivycloth Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 544;
			BuyPrice = 7640;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Durable Pants)
*
***************************************************************/

namespace Server.Items
{
	public class DurablePants : Item
	{
		public DurablePants() : base()
		{
			Id = 9825;
			Resistance[0] = 39;
			Bonding = 2;
			SellPrice = 2355;
			AvailableClasses = 0x7FFF;
			Model = 27853;
			ObjectClass = 4;
			SubClass = 1;
			Level = 33;
			ReqLevel = 28;
			Name = "Durable Pants";
			Name2 = "Durable Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 545;
			BuyPrice = 11775;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Conjurer's Breeches)
*
***************************************************************/

namespace Server.Items
{
	public class ConjurersBreeches : Item
	{
		public ConjurersBreeches() : base()
		{
			Id = 9851;
			Resistance[0] = 43;
			Bonding = 2;
			SellPrice = 3524;
			AvailableClasses = 0x7FFF;
			Model = 28419;
			ObjectClass = 4;
			SubClass = 1;
			Level = 37;
			ReqLevel = 32;
			Name = "Conjurer's Breeches";
			Name2 = "Conjurer's Breeches";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 547;
			BuyPrice = 17623;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Sorcerer Pants)
*
***************************************************************/

namespace Server.Items
{
	public class SorcererPants : Item
	{
		public SorcererPants() : base()
		{
			Id = 9883;
			Resistance[0] = 48;
			Bonding = 2;
			SellPrice = 5026;
			AvailableClasses = 0x7FFF;
			Model = 28061;
			ObjectClass = 4;
			SubClass = 1;
			Level = 42;
			ReqLevel = 37;
			Name = "Sorcerer Pants";
			Name2 = "Sorcerer Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 548;
			BuyPrice = 25130;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Royal Trousers)
*
***************************************************************/

namespace Server.Items
{
	public class RoyalTrousers : Item
	{
		public RoyalTrousers() : base()
		{
			Id = 9911;
			Resistance[0] = 53;
			Bonding = 2;
			SellPrice = 7228;
			AvailableClasses = 0x7FFF;
			Model = 28416;
			ObjectClass = 4;
			SubClass = 1;
			Level = 46;
			ReqLevel = 41;
			Name = "Royal Trousers";
			Name2 = "Royal Trousers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 550;
			BuyPrice = 36142;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Abjurer's Pants)
*
***************************************************************/

namespace Server.Items
{
	public class AbjurersPants : Item
	{
		public AbjurersPants() : base()
		{
			Id = 9942;
			Resistance[0] = 57;
			Bonding = 2;
			SellPrice = 9341;
			AvailableClasses = 0x7FFF;
			Model = 14613;
			ObjectClass = 4;
			SubClass = 1;
			Level = 50;
			ReqLevel = 45;
			Name = "Abjurer's Pants";
			Name2 = "Abjurer's Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 551;
			BuyPrice = 46708;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Black Mageweave Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class BlackMageweaveLeggings : Item
	{
		public BlackMageweaveLeggings() : base()
		{
			Id = 9999;
			Resistance[0] = 47;
			Bonding = 2;
			SellPrice = 4832;
			AvailableClasses = 0x7FFF;
			Model = 24354;
			ObjectClass = 4;
			SubClass = 1;
			Level = 41;
			ReqLevel = 36;
			Name = "Black Mageweave Leggings";
			Name2 = "Black Mageweave Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 24164;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
			IqBonus = 14;
			SpiritBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Shadoweave Pants)
*
***************************************************************/

namespace Server.Items
{
	public class ShadoweavePants : Item
	{
		public ShadoweavePants() : base()
		{
			Id = 10002;
			Resistance[0] = 48;
			Bonding = 2;
			SellPrice = 5276;
			AvailableClasses = 0x7FFF;
			Model = 19061;
			ObjectClass = 4;
			SubClass = 1;
			Level = 42;
			ReqLevel = 37;
			Name = "Shadoweave Pants";
			Name2 = "Shadoweave Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 26380;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
			SetSpell( 9328 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Red Mageweave Pants)
*
***************************************************************/

namespace Server.Items
{
	public class RedMageweavePants : Item
	{
		public RedMageweavePants() : base()
		{
			Id = 10009;
			Resistance[0] = 49;
			Bonding = 2;
			SellPrice = 5284;
			AvailableClasses = 0x7FFF;
			Model = 16764;
			ObjectClass = 4;
			SubClass = 1;
			Level = 43;
			ReqLevel = 38;
			Name = "Red Mageweave Pants";
			Name2 = "Red Mageweave Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 26424;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
			SetSpell( 9343 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Tuxedo Pants)
*
***************************************************************/

namespace Server.Items
{
	public class TuxedoPants : Item
	{
		public TuxedoPants() : base()
		{
			Id = 10035;
			Resistance[0] = 39;
			SellPrice = 1735;
			AvailableClasses = 0x7FFF;
			Model = 13117;
			ObjectClass = 4;
			SubClass = 1;
			Level = 35;
			ReqLevel = 30;
			Name = "Tuxedo Pants";
			Name2 = "Tuxedo Pants";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 8676;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Pious Legwraps)
*
***************************************************************/

namespace Server.Items
{
	public class PiousLegwraps : Item
	{
		public PiousLegwraps() : base()
		{
			Id = 10043;
			Resistance[0] = 38;
			Bonding = 1;
			SellPrice = 2033;
			AvailableClasses = 0x7FFF;
			Model = 20209;
			ObjectClass = 4;
			SubClass = 1;
			Level = 31;
			Name = "Pious Legwraps";
			Name2 = "Pious Legwraps";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 10167;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
			StaminaBonus = 8;
			IqBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Simple Linen Pants)
*
***************************************************************/

namespace Server.Items
{
	public class SimpleLinenPants : Item
	{
		public SimpleLinenPants() : base()
		{
			Id = 10045;
			Resistance[0] = 12;
			SellPrice = 23;
			AvailableClasses = 0x7FFF;
			Model = 14450;
			ObjectClass = 4;
			SubClass = 1;
			Level = 7;
			ReqLevel = 2;
			Name = "Simple Linen Pants";
			Name2 = "Simple Linen Pants";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 117;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Simple Kilt)
*
***************************************************************/

namespace Server.Items
{
	public class SimpleKilt : Item
	{
		public SimpleKilt() : base()
		{
			Id = 10047;
			Resistance[0] = 23;
			SellPrice = 164;
			AvailableClasses = 0x7FFF;
			Model = 19009;
			ObjectClass = 4;
			SubClass = 1;
			Level = 15;
			ReqLevel = 10;
			Name = "Simple Kilt";
			Name2 = "Simple Kilt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 822;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Colorful Kilt)
*
***************************************************************/

namespace Server.Items
{
	public class ColorfulKilt : Item
	{
		public ColorfulKilt() : base()
		{
			Id = 10048;
			Resistance[0] = 33;
			Bonding = 2;
			SellPrice = 935;
			AvailableClasses = 0x7FFF;
			Model = 18914;
			ObjectClass = 4;
			SubClass = 1;
			Level = 24;
			ReqLevel = 14;
			Name = "Colorful Kilt";
			Name2 = "Colorful Kilt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4678;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 50;
			AgilityBonus = 5;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Duskwoven Pants)
*
***************************************************************/

namespace Server.Items
{
	public class DuskwovenPants : Item
	{
		public DuskwovenPants() : base()
		{
			Id = 10064;
			Resistance[0] = 60;
			Bonding = 2;
			SellPrice = 10774;
			AvailableClasses = 0x7FFF;
			Model = 28140;
			ObjectClass = 4;
			SubClass = 1;
			Level = 53;
			ReqLevel = 48;
			Name = "Duskwoven Pants";
			Name2 = "Duskwoven Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 552;
			BuyPrice = 53874;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Councillor's Pants)
*
***************************************************************/

namespace Server.Items
{
	public class CouncillorsPants : Item
	{
		public CouncillorsPants() : base()
		{
			Id = 10101;
			Resistance[0] = 66;
			Bonding = 2;
			SellPrice = 15756;
			AvailableClasses = 0x7FFF;
			Model = 27598;
			ObjectClass = 4;
			SubClass = 1;
			Level = 58;
			ReqLevel = 53;
			Name = "Councillor's Pants";
			Name2 = "Councillor's Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 554;
			BuyPrice = 78781;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(High Councillor's Pants)
*
***************************************************************/

namespace Server.Items
{
	public class HighCouncillorsPants : Item
	{
		public HighCouncillorsPants() : base()
		{
			Id = 10141;
			Resistance[0] = 71;
			Bonding = 2;
			SellPrice = 20103;
			AvailableClasses = 0x7FFF;
			Model = 27629;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "High Councillor's Pants";
			Name2 = "High Councillor's Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 555;
			BuyPrice = 100518;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Mystical Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class MysticalLeggings : Item
	{
		public MysticalLeggings() : base()
		{
			Id = 10177;
			Resistance[0] = 63;
			Bonding = 2;
			SellPrice = 12833;
			AvailableClasses = 0x7FFF;
			Model = 28084;
			ObjectClass = 4;
			SubClass = 1;
			Level = 56;
			ReqLevel = 51;
			Name = "Mystical Leggings";
			Name2 = "Mystical Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 553;
			BuyPrice = 64165;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Elegant Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class ElegantLeggings : Item
	{
		public ElegantLeggings() : base()
		{
			Id = 10217;
			Resistance[0] = 69;
			Bonding = 2;
			SellPrice = 16688;
			AvailableClasses = 0x7FFF;
			Model = 25198;
			ObjectClass = 4;
			SubClass = 1;
			Level = 61;
			ReqLevel = 56;
			Name = "Elegant Leggings";
			Name2 = "Elegant Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 555;
			BuyPrice = 83444;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Master's Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class MastersLeggings : Item
	{
		public MastersLeggings() : base()
		{
			Id = 10252;
			Resistance[0] = 72;
			Bonding = 2;
			SellPrice = 20959;
			AvailableClasses = 0x7FFF;
			Model = 27822;
			ObjectClass = 4;
			SubClass = 1;
			Level = 64;
			ReqLevel = 59;
			Name = "Master's Leggings";
			Name2 = "Master's Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 556;
			BuyPrice = 104799;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Rancher's Trousers)
*
***************************************************************/

namespace Server.Items
{
	public class RanchersTrousers : Item
	{
		public RanchersTrousers() : base()
		{
			Id = 10549;
			Resistance[0] = 20;
			Bonding = 1;
			SellPrice = 162;
			AvailableClasses = 0x7FFF;
			Model = 19951;
			ObjectClass = 4;
			SubClass = 1;
			Level = 12;
			Name = "Rancher's Trousers";
			Name2 = "Rancher's Trousers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 811;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			StaminaBonus = 1;
			IqBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Foreman Pants)
*
***************************************************************/

namespace Server.Items
{
	public class ForemanPants : Item
	{
		public ForemanPants() : base()
		{
			Id = 10554;
			Resistance[0] = 18;
			Bonding = 2;
			SellPrice = 119;
			AvailableClasses = 0x7FFF;
			Model = 19918;
			ObjectClass = 4;
			SubClass = 1;
			Level = 11;
			ReqLevel = 6;
			Name = "Foreman Pants";
			Name2 = "Foreman Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 597;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			StrBonus = 1;
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Sedgeweed Britches)
*
***************************************************************/

namespace Server.Items
{
	public class SedgeweedBritches : Item
	{
		public SedgeweedBritches() : base()
		{
			Id = 10655;
			Resistance[0] = 9;
			Bonding = 1;
			SellPrice = 9;
			AvailableClasses = 0x7FFF;
			Model = 20210;
			ObjectClass = 4;
			SubClass = 1;
			Level = 5;
			Name = "Sedgeweed Britches";
			Name2 = "Sedgeweed Britches";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 49;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Dragonflight Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class DragonflightLeggings : Item
	{
		public DragonflightLeggings() : base()
		{
			Id = 10742;
			Resistance[0] = 58;
			Bonding = 1;
			SellPrice = 9589;
			AvailableClasses = 0x7FFF;
			Model = 19710;
			ObjectClass = 4;
			SubClass = 1;
			Level = 51;
			Name = "Dragonflight Leggings";
			Name2 = "Dragonflight Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 47948;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
			AgilityBonus = 13;
			StrBonus = 6;
			IqBonus = 14;
		}
	}
}


/**************************************************************
*
*				(Kilt of the Atal'ai Prophet)
*
***************************************************************/

namespace Server.Items
{
	public class KiltOfTheAtalaiProphet : Item
	{
		public KiltOfTheAtalaiProphet() : base()
		{
			Id = 10807;
			Resistance[0] = 69;
			Bonding = 1;
			SellPrice = 15202;
			AvailableClasses = 0x7FFF;
			Model = 19812;
			ObjectClass = 4;
			SubClass = 1;
			Level = 55;
			ReqLevel = 50;
			Name = "Kilt of the Atal'ai Prophet";
			Name2 = "Kilt of the Atal'ai Prophet";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 76012;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 65;
			IqBonus = 18;
			SpiritBonus = 18;
			StaminaBonus = 9;
			StrBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Rainstrider Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class RainstriderLeggings : Item
	{
		public RainstriderLeggings() : base()
		{
			Id = 11123;
			Resistance[0] = 69;
			Bonding = 1;
			SellPrice = 15037;
			AvailableClasses = 0x7FFF;
			Model = 14590;
			ObjectClass = 4;
			SubClass = 1;
			Level = 55;
			Name = "Rainstrider Leggings";
			Name2 = "Rainstrider Leggings";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 75186;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 65;
			AgilityBonus = 8;
			IqBonus = 27;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Senior Designer's Pantaloons)
*
***************************************************************/

namespace Server.Items
{
	public class SeniorDesignersPantaloons : Item
	{
		public SeniorDesignersPantaloons() : base()
		{
			Id = 11841;
			Resistance[0] = 62;
			Bonding = 1;
			SellPrice = 12527;
			AvailableClasses = 0x7FFF;
			Model = 28720;
			ObjectClass = 4;
			SubClass = 1;
			Level = 55;
			ReqLevel = 50;
			Name = "Senior Designer's Pantaloons";
			Name2 = "Senior Designer's Pantaloons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 62636;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
			IqBonus = 20;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Treetop Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class TreetopLeggings : Item
	{
		public TreetopLeggings() : base()
		{
			Id = 11911;
			Resistance[0] = 62;
			Bonding = 1;
			SellPrice = 12392;
			AvailableClasses = 0x7FFF;
			Model = 28198;
			ObjectClass = 4;
			SubClass = 1;
			Level = 55;
			Name = "Treetop Leggings";
			Name2 = "Treetop Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 61960;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
			StrBonus = 8;
			StaminaBonus = 8;
			IqBonus = 18;
		}
	}
}


/**************************************************************
*
*				(Haunting Specter Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class HauntingSpecterLeggings : Item
	{
		public HauntingSpecterLeggings() : base()
		{
			Id = 11929;
			Resistance[0] = 71;
			Bonding = 1;
			SellPrice = 16581;
			AvailableClasses = 0x7FFF;
			Model = 28736;
			ObjectClass = 4;
			SubClass = 1;
			Level = 57;
			ReqLevel = 52;
			Name = "Haunting Specter Leggings";
			Name2 = "Haunting Specter Leggings";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 82905;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 65;
			IqBonus = 28;
			SpiritBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Whispersilk Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class WhispersilkLeggings : Item
	{
		public WhispersilkLeggings() : base()
		{
			Id = 12107;
			Resistance[0] = 68;
			Bonding = 1;
			SellPrice = 16885;
			AvailableClasses = 0x7FFF;
			Model = 28182;
			ObjectClass = 4;
			SubClass = 1;
			Level = 60;
			Name = "Whispersilk Leggings";
			Name2 = "Whispersilk Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 84428;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
			SetSpell( 9344 , 1 , 0 , -1 , 0 , -1 );
			IqBonus = 20;
		}
	}
}


/**************************************************************
*
*				(Pale Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class PaleLeggings : Item
	{
		public PaleLeggings() : base()
		{
			Id = 12255;
			Resistance[0] = 53;
			Bonding = 2;
			SellPrice = 6997;
			AvailableClasses = 0x7FFF;
			Model = 4765;
			ObjectClass = 4;
			SubClass = 1;
			Level = 46;
			ReqLevel = 41;
			Name = "Pale Leggings";
			Name2 = "Pale Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 34987;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
			SpiritBonus = 13;
			IqBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Cindercloth Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class CinderclothLeggings : Item
	{
		public CinderclothLeggings() : base()
		{
			Id = 12256;
			Resistance[0] = 56;
			Bonding = 2;
			SellPrice = 8765;
			AvailableClasses = 0x7FFF;
			Model = 16764;
			ObjectClass = 4;
			SubClass = 1;
			Level = 49;
			ReqLevel = 44;
			Name = "Cindercloth Leggings";
			Name2 = "Cindercloth Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 43828;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
			SetSpell( 9296 , 1 , 0 , -1 , 0 , -1 );
			IqBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Leggings of the People's Militia)
*
***************************************************************/

namespace Server.Items
{
	public class LeggingsOfThePeoplesMilitia : Item
	{
		public LeggingsOfThePeoplesMilitia() : base()
		{
			Id = 12295;
			Resistance[0] = 24;
			Bonding = 1;
			SellPrice = 282;
			AvailableClasses = 0x7FFF;
			Model = 28204;
			ObjectClass = 4;
			SubClass = 1;
			Level = 15;
			Name = "Leggings of the People's Militia";
			Name2 = "Leggings of the People's Militia";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1413;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 40;
			StrBonus = 2;
			IqBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Spiritshroud Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class SpiritshroudLeggings : Item
	{
		public SpiritshroudLeggings() : base()
		{
			Id = 12965;
			Resistance[0] = 78;
			Bonding = 1;
			SellPrice = 22344;
			AvailableClasses = 0x7FFF;
			Model = 23551;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Spiritshroud Leggings";
			Name2 = "Spiritshroud Leggings";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 111721;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 65;
			IqBonus = 21;
			SpiritBonus = 21;
			StaminaBonus = 10;
			AgilityBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Darkweave Breeches)
*
***************************************************************/

namespace Server.Items
{
	public class DarkweaveBreeches : Item
	{
		public DarkweaveBreeches() : base()
		{
			Id = 12987;
			Resistance[0] = 35;
			Bonding = 2;
			SellPrice = 906;
			AvailableClasses = 0x7FFF;
			Model = 28648;
			ObjectClass = 4;
			SubClass = 1;
			Level = 22;
			ReqLevel = 17;
			Name = "Darkweave Breeches";
			Name2 = "Darkweave Breeches";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 4533;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 50;
			IqBonus = 6;
			SpiritBonus = 7;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Dalewind Trousers)
*
***************************************************************/

namespace Server.Items
{
	public class DalewindTrousers : Item
	{
		public DalewindTrousers() : base()
		{
			Id = 13008;
			Resistance[0] = 65;
			Bonding = 2;
			SellPrice = 12815;
			AvailableClasses = 0x7FFF;
			Model = 28646;
			ObjectClass = 4;
			SubClass = 1;
			Level = 52;
			ReqLevel = 47;
			Name = "Dalewind Trousers";
			Name2 = "Dalewind Trousers";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 64076;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 65;
			IqBonus = 25;
			SpiritBonus = 9;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Skyshroud Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class SkyshroudLeggings : Item
	{
		public SkyshroudLeggings() : base()
		{
			Id = 13170;
			Resistance[0] = 75;
			Bonding = 1;
			SellPrice = 19230;
			AvailableClasses = 0x7FFF;
			Model = 28713;
			ObjectClass = 4;
			SubClass = 1;
			Level = 60;
			ReqLevel = 55;
			Name = "Skyshroud Leggings";
			Name2 = "Skyshroud Leggings";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 96151;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 65;
			SetSpell( 18052 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 8;
			SpiritBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Wolfshear Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class WolfshearLeggings : Item
	{
		public WolfshearLeggings() : base()
		{
			Id = 13206;
			Resistance[0] = 76;
			Bonding = 1;
			SellPrice = 19880;
			AvailableClasses = 0x7FFF;
			Model = 23753;
			ObjectClass = 4;
			SubClass = 1;
			Level = 61;
			ReqLevel = 56;
			Name = "Wolfshear Leggings";
			Name2 = "Wolfshear Leggings";
			Resistance[3] = 10;
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 99402;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 65;
			IqBonus = 30;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(The Postmaster's Trousers)
*
***************************************************************/

namespace Server.Items
{
	public class ThePostmastersTrousers : Item
	{
		public ThePostmastersTrousers() : base()
		{
			Id = 13389;
			Resistance[0] = 76;
			Bonding = 1;
			SellPrice = 21746;
			AvailableClasses = 0x7FFF;
			Model = 25050;
			ObjectClass = 4;
			SubClass = 1;
			Level = 61;
			ReqLevel = 56;
			Name = "The Postmaster's Trousers";
			Name2 = "The Postmaster's Trousers";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 108730;
			Sets = 81;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 65;
			AgilityBonus = 12;
			IqBonus = 20;
			SpiritBonus = 20;
		}
	}
}


/**************************************************************
*
*				(Runecloth Pants)
*
***************************************************************/

namespace Server.Items
{
	public class RuneclothPants : Item
	{
		public RuneclothPants() : base()
		{
			Id = 13865;
			Resistance[0] = 65;
			Bonding = 2;
			SellPrice = 13555;
			AvailableClasses = 0x7FFF;
			Model = 25208;
			ObjectClass = 4;
			SubClass = 1;
			Level = 57;
			ReqLevel = 52;
			Name = "Runecloth Pants";
			Name2 = "Runecloth Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 67775;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
			IqBonus = 20;
			SpiritBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Frostweave Pants)
*
***************************************************************/

namespace Server.Items
{
	public class FrostweavePants : Item
	{
		public FrostweavePants() : base()
		{
			Id = 13871;
			Resistance[0] = 63;
			Bonding = 2;
			SellPrice = 13436;
			AvailableClasses = 0x7FFF;
			Model = 24615;
			ObjectClass = 4;
			SubClass = 1;
			Level = 56;
			ReqLevel = 51;
			Name = "Frostweave Pants";
			Name2 = "Frostweave Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 67183;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
			SetSpell( 17891 , 1 , 0 , -1 , 0 , -1 );
			IqBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Cindercloth Pants)
*
***************************************************************/

namespace Server.Items
{
	public class CinderclothPants : Item
	{
		public CinderclothPants() : base()
		{
			Id = 14045;
			Resistance[0] = 63;
			Bonding = 2;
			SellPrice = 13480;
			AvailableClasses = 0x7FFF;
			Model = 24895;
			ObjectClass = 4;
			SubClass = 1;
			Level = 56;
			ReqLevel = 51;
			Name = "Cindercloth Pants";
			Name2 = "Cindercloth Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 67404;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
			SetSpell( 17867 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Beaded Britches)
*
***************************************************************/

namespace Server.Items
{
	public class BeadedBritches : Item
	{
		public BeadedBritches() : base()
		{
			Id = 14090;
			Resistance[0] = 18;
			Bonding = 2;
			SellPrice = 119;
			AvailableClasses = 0x7FFF;
			Model = 7533;
			ObjectClass = 4;
			SubClass = 1;
			Level = 11;
			ReqLevel = 6;
			Name = "Beaded Britches";
			Name2 = "Beaded Britches";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 538;
			BuyPrice = 597;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Native Pants)
*
***************************************************************/

namespace Server.Items
{
	public class NativePants : Item
	{
		public NativePants() : base()
		{
			Id = 14097;
			Resistance[0] = 23;
			Bonding = 2;
			SellPrice = 236;
			AvailableClasses = 0x7FFF;
			Model = 25876;
			ObjectClass = 4;
			SubClass = 1;
			Level = 14;
			ReqLevel = 9;
			Name = "Native Pants";
			Name2 = "Native Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 539;
			BuyPrice = 1183;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Brightcloth Pants)
*
***************************************************************/

namespace Server.Items
{
	public class BrightclothPants : Item
	{
		public BrightclothPants() : base()
		{
			Id = 14104;
			Resistance[0] = 66;
			Bonding = 2;
			SellPrice = 15484;
			AvailableClasses = 0x7FFF;
			Model = 24927;
			Resistance[4] = 17;
			ObjectClass = 4;
			SubClass = 1;
			Level = 58;
			ReqLevel = 53;
			Name = "Brightcloth Pants";
			Name2 = "Brightcloth Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 77420;
			Resistance[5] = 16;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Felcloth Pants)
*
***************************************************************/

namespace Server.Items
{
	public class FelclothPants : Item
	{
		public FelclothPants() : base()
		{
			Id = 14107;
			Resistance[0] = 62;
			Bonding = 2;
			SellPrice = 13140;
			AvailableClasses = 0x7FFF;
			Model = 13679;
			ObjectClass = 4;
			SubClass = 1;
			Level = 55;
			ReqLevel = 50;
			Name = "Felcloth Pants";
			Name2 = "Felcloth Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 65704;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
			SetSpell( 18008 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Aboriginal Loincloth)
*
***************************************************************/

namespace Server.Items
{
	public class AboriginalLoincloth : Item
	{
		public AboriginalLoincloth() : base()
		{
			Id = 14119;
			Resistance[0] = 27;
			Bonding = 2;
			SellPrice = 378;
			AvailableClasses = 0x7FFF;
			Model = 11421;
			ObjectClass = 4;
			SubClass = 1;
			Level = 17;
			ReqLevel = 12;
			Name = "Aboriginal Loincloth";
			Name2 = "Aboriginal Loincloth";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 540;
			BuyPrice = 1891;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Ritual Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class RitualLeggings : Item
	{
		public RitualLeggings() : base()
		{
			Id = 14125;
			Resistance[0] = 30;
			Bonding = 2;
			SellPrice = 676;
			AvailableClasses = 0x7FFF;
			Model = 16656;
			ObjectClass = 4;
			SubClass = 1;
			Level = 21;
			ReqLevel = 16;
			Name = "Ritual Leggings";
			Name2 = "Ritual Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 541;
			BuyPrice = 3381;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Wizardweave Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class WizardweaveLeggings : Item
	{
		public WizardweaveLeggings() : base()
		{
			Id = 14132;
			Resistance[6] = 16;
			Resistance[0] = 62;
			Bonding = 2;
			SellPrice = 12441;
			AvailableClasses = 0x7FFF;
			Model = 24943;
			Resistance[2] = 16;
			ObjectClass = 4;
			SubClass = 1;
			Level = 55;
			ReqLevel = 50;
			Name = "Wizardweave Leggings";
			Name2 = "Wizardweave Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 62206;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Mooncloth Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class MoonclothLeggings : Item
	{
		public MoonclothLeggings() : base()
		{
			Id = 14137;
			Resistance[0] = 72;
			Bonding = 2;
			SellPrice = 18113;
			AvailableClasses = 0x7FFF;
			Model = 17252;
			ObjectClass = 4;
			SubClass = 1;
			Level = 58;
			ReqLevel = 53;
			Name = "Mooncloth Leggings";
			Name2 = "Mooncloth Leggings";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 90567;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 65;
			IqBonus = 21;
			SpiritBonus = 14;
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Ghostweave Pants)
*
***************************************************************/

namespace Server.Items
{
	public class GhostweavePants : Item
	{
		public GhostweavePants() : base()
		{
			Id = 14144;
			Resistance[0] = 66;
			Bonding = 2;
			SellPrice = 14374;
			AvailableClasses = 0x7FFF;
			Model = 11166;
			ObjectClass = 4;
			SubClass = 1;
			Level = 58;
			ReqLevel = 53;
			Name = "Ghostweave Pants";
			Name2 = "Ghostweave Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 71871;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
			SetSpell( 18378 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Pagan Britches)
*
***************************************************************/

namespace Server.Items
{
	public class PaganBritches : Item
	{
		public PaganBritches() : base()
		{
			Id = 14165;
			Resistance[0] = 34;
			Bonding = 2;
			SellPrice = 1041;
			AvailableClasses = 0x7FFF;
			Model = 25890;
			ObjectClass = 4;
			SubClass = 1;
			Level = 25;
			ReqLevel = 20;
			Name = "Pagan Britches";
			Name2 = "Pagan Britches";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 543;
			BuyPrice = 5208;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Buccaneer's Pants)
*
***************************************************************/

namespace Server.Items
{
	public class BuccaneersPants : Item
	{
		public BuccaneersPants() : base()
		{
			Id = 14171;
			Resistance[0] = 31;
			Bonding = 2;
			SellPrice = 738;
			AvailableClasses = 0x7FFF;
			Model = 13679;
			ObjectClass = 4;
			SubClass = 1;
			Level = 22;
			ReqLevel = 17;
			Name = "Buccaneer's Pants";
			Name2 = "Buccaneer's Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 542;
			BuyPrice = 3693;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Watcher's Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class WatchersLeggings : Item
	{
		public WatchersLeggings() : base()
		{
			Id = 14183;
			Resistance[0] = 37;
			Bonding = 2;
			SellPrice = 1710;
			AvailableClasses = 0x7FFF;
			Model = 25974;
			ObjectClass = 4;
			SubClass = 1;
			Level = 30;
			ReqLevel = 25;
			Name = "Watcher's Leggings";
			Name2 = "Watcher's Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 544;
			BuyPrice = 8550;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Raincaller Pants)
*
***************************************************************/

namespace Server.Items
{
	public class RaincallerPants : Item
	{
		public RaincallerPants() : base()
		{
			Id = 14193;
			Resistance[0] = 38;
			Bonding = 2;
			SellPrice = 2006;
			AvailableClasses = 0x7FFF;
			Model = 18887;
			ObjectClass = 4;
			SubClass = 1;
			Level = 31;
			ReqLevel = 26;
			Name = "Raincaller Pants";
			Name2 = "Raincaller Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 545;
			BuyPrice = 10031;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Thistlefur Pants)
*
***************************************************************/

namespace Server.Items
{
	public class ThistlefurPants : Item
	{
		public ThistlefurPants() : base()
		{
			Id = 14203;
			Resistance[0] = 41;
			Bonding = 2;
			SellPrice = 2754;
			AvailableClasses = 0x7FFF;
			Model = 16719;
			ObjectClass = 4;
			SubClass = 1;
			Level = 35;
			ReqLevel = 30;
			Name = "Thistlefur Pants";
			Name2 = "Thistlefur Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 546;
			BuyPrice = 13770;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Vital Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class VitalLeggings : Item
	{
		public VitalLeggings() : base()
		{
			Id = 14207;
			Resistance[0] = 42;
			Bonding = 2;
			SellPrice = 3076;
			AvailableClasses = 0x7FFF;
			Model = 26021;
			ObjectClass = 4;
			SubClass = 1;
			Level = 36;
			ReqLevel = 31;
			Name = "Vital Leggings";
			Name2 = "Vital Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 546;
			BuyPrice = 15381;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Geomancer's Trousers)
*
***************************************************************/

namespace Server.Items
{
	public class GeomancersTrousers : Item
	{
		public GeomancersTrousers() : base()
		{
			Id = 14224;
			Resistance[0] = 45;
			Bonding = 2;
			SellPrice = 3901;
			AvailableClasses = 0x7FFF;
			Model = 26052;
			ObjectClass = 4;
			SubClass = 1;
			Level = 39;
			ReqLevel = 34;
			Name = "Geomancer's Trousers";
			Name2 = "Geomancer's Trousers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 547;
			BuyPrice = 19508;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Embersilk Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class EmbersilkLeggings : Item
	{
		public EmbersilkLeggings() : base()
		{
			Id = 14233;
			Resistance[0] = 46;
			Bonding = 2;
			SellPrice = 4476;
			AvailableClasses = 0x7FFF;
			Model = 26061;
			ObjectClass = 4;
			SubClass = 1;
			Level = 40;
			ReqLevel = 35;
			Name = "Embersilk Leggings";
			Name2 = "Embersilk Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 548;
			BuyPrice = 22381;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Darkmist Pants)
*
***************************************************************/

namespace Server.Items
{
	public class DarkmistPants : Item
	{
		public DarkmistPants() : base()
		{
			Id = 14242;
			Resistance[0] = 49;
			Bonding = 2;
			SellPrice = 5413;
			AvailableClasses = 0x7FFF;
			Model = 16600;
			ObjectClass = 4;
			SubClass = 1;
			Level = 43;
			ReqLevel = 38;
			Name = "Darkmist Pants";
			Name2 = "Darkmist Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 549;
			BuyPrice = 27068;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Lunar Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class LunarLeggings : Item
	{
		public LunarLeggings() : base()
		{
			Id = 14257;
			Resistance[0] = 52;
			Bonding = 2;
			SellPrice = 6194;
			AvailableClasses = 0x7FFF;
			Model = 18887;
			ObjectClass = 4;
			SubClass = 1;
			Level = 45;
			ReqLevel = 40;
			Name = "Lunar Leggings";
			Name2 = "Lunar Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 549;
			BuyPrice = 30973;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Bloodwoven Pants)
*
***************************************************************/

namespace Server.Items
{
	public class BloodwovenPants : Item
	{
		public BloodwovenPants() : base()
		{
			Id = 14264;
			Resistance[0] = 55;
			Bonding = 2;
			SellPrice = 8013;
			AvailableClasses = 0x7FFF;
			Model = 26196;
			ObjectClass = 4;
			SubClass = 1;
			Level = 48;
			ReqLevel = 43;
			Name = "Bloodwoven Pants";
			Name2 = "Bloodwoven Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 550;
			BuyPrice = 40066;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Gaea's Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class GaeasLeggings : Item
	{
		public GaeasLeggings() : base()
		{
			Id = 14274;
			Resistance[0] = 58;
			Bonding = 2;
			SellPrice = 10448;
			AvailableClasses = 0x7FFF;
			Model = 26144;
			ObjectClass = 4;
			SubClass = 1;
			Level = 51;
			ReqLevel = 46;
			Name = "Gaea's Leggings";
			Name2 = "Gaea's Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 551;
			BuyPrice = 52244;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Opulent Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class OpulentLeggings : Item
	{
		public OpulentLeggings() : base()
		{
			Id = 14283;
			Resistance[0] = 61;
			Bonding = 2;
			SellPrice = 11646;
			AvailableClasses = 0x7FFF;
			Model = 26124;
			ObjectClass = 4;
			SubClass = 1;
			Level = 54;
			ReqLevel = 49;
			Name = "Opulent Leggings";
			Name2 = "Opulent Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 552;
			BuyPrice = 58233;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Arachnidian Legguards)
*
***************************************************************/

namespace Server.Items
{
	public class ArachnidianLegguards : Item
	{
		public ArachnidianLegguards() : base()
		{
			Id = 14295;
			Resistance[0] = 62;
			Bonding = 2;
			SellPrice = 13236;
			AvailableClasses = 0x7FFF;
			Model = 26212;
			ObjectClass = 4;
			SubClass = 1;
			Level = 55;
			ReqLevel = 50;
			Name = "Arachnidian Legguards";
			Name2 = "Arachnidian Legguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 553;
			BuyPrice = 66184;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Bonecaster's Sarong)
*
***************************************************************/

namespace Server.Items
{
	public class BonecastersSarong : Item
	{
		public BonecastersSarong() : base()
		{
			Id = 14305;
			Resistance[0] = 65;
			Bonding = 2;
			SellPrice = 14349;
			AvailableClasses = 0x7FFF;
			Model = 26282;
			ObjectClass = 4;
			SubClass = 1;
			Level = 57;
			ReqLevel = 52;
			Name = "Bonecaster's Sarong";
			Name2 = "Bonecaster's Sarong";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 553;
			BuyPrice = 71747;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Celestial Kilt)
*
***************************************************************/

namespace Server.Items
{
	public class CelestialKilt : Item
	{
		public CelestialKilt() : base()
		{
			Id = 14315;
			Resistance[0] = 67;
			Bonding = 2;
			SellPrice = 16550;
			AvailableClasses = 0x7FFF;
			Model = 26260;
			ObjectClass = 4;
			SubClass = 1;
			Level = 59;
			ReqLevel = 54;
			Name = "Celestial Kilt";
			Name2 = "Celestial Kilt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 554;
			BuyPrice = 82752;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Resplendent Sarong)
*
***************************************************************/

namespace Server.Items
{
	public class ResplendentSarong : Item
	{
		public ResplendentSarong() : base()
		{
			Id = 14324;
			Resistance[0] = 68;
			Bonding = 2;
			SellPrice = 16706;
			AvailableClasses = 0x7FFF;
			Model = 26300;
			ObjectClass = 4;
			SubClass = 1;
			Level = 60;
			ReqLevel = 55;
			Name = "Resplendent Sarong";
			Name2 = "Resplendent Sarong";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 554;
			BuyPrice = 83533;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Eternal Sarong)
*
***************************************************************/

namespace Server.Items
{
	public class EternalSarong : Item
	{
		public EternalSarong() : base()
		{
			Id = 14334;
			Resistance[0] = 71;
			Bonding = 2;
			SellPrice = 20044;
			AvailableClasses = 0x7FFF;
			Model = 26223;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Eternal Sarong";
			Name2 = "Eternal Sarong";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 555;
			BuyPrice = 100221;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Mystic's Woolies)
*
***************************************************************/

namespace Server.Items
{
	public class MysticsWoolies : Item
	{
		public MysticsWoolies() : base()
		{
			Id = 14370;
			Resistance[0] = 29;
			Bonding = 2;
			SellPrice = 472;
			AvailableClasses = 0x7FFF;
			Model = 10079;
			ObjectClass = 4;
			SubClass = 1;
			Level = 19;
			ReqLevel = 14;
			Name = "Mystic's Woolies";
			Name2 = "Mystic's Woolies";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2364;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Sanguine Trousers)
*
***************************************************************/

namespace Server.Items
{
	public class SanguineTrousers : Item
	{
		public SanguineTrousers() : base()
		{
			Id = 14379;
			Resistance[0] = 37;
			Bonding = 2;
			SellPrice = 1615;
			AvailableClasses = 0x7FFF;
			Model = 25968;
			ObjectClass = 4;
			SubClass = 1;
			Level = 29;
			ReqLevel = 24;
			Name = "Sanguine Trousers";
			Name2 = "Sanguine Trousers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 8075;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
			IqBonus = 9;
			StrBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Resilient Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class ResilientLeggings : Item
	{
		public ResilientLeggings() : base()
		{
			Id = 14404;
			Resistance[0] = 39;
			Bonding = 2;
			SellPrice = 2471;
			AvailableClasses = 0x7FFF;
			Model = 12973;
			ObjectClass = 4;
			SubClass = 1;
			Level = 33;
			ReqLevel = 28;
			Name = "Resilient Leggings";
			Name2 = "Resilient Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 12359;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
			IqBonus = 11;
			AgilityBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Stonecloth Britches)
*
***************************************************************/

namespace Server.Items
{
	public class StoneclothBritches : Item
	{
		public StoneclothBritches() : base()
		{
			Id = 14415;
			Resistance[0] = 43;
			Bonding = 2;
			SellPrice = 3410;
			AvailableClasses = 0x7FFF;
			Model = 11166;
			ObjectClass = 4;
			SubClass = 1;
			Level = 37;
			ReqLevel = 32;
			Name = "Stonecloth Britches";
			Name2 = "Stonecloth Britches";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 17051;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
			IqBonus = 12;
			SpiritBonus = 5;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Silksand Legwraps)
*
***************************************************************/

namespace Server.Items
{
	public class SilksandLegwraps : Item
	{
		public SilksandLegwraps() : base()
		{
			Id = 14424;
			Resistance[0] = 48;
			Bonding = 2;
			SellPrice = 5316;
			AvailableClasses = 0x7FFF;
			Model = 26083;
			ObjectClass = 4;
			SubClass = 1;
			Level = 42;
			ReqLevel = 37;
			Name = "Silksand Legwraps";
			Name2 = "Silksand Legwraps";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 26584;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
			IqBonus = 13;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Windchaser Woolies)
*
***************************************************************/

namespace Server.Items
{
	public class WindchaserWoolies : Item
	{
		public WindchaserWoolies() : base()
		{
			Id = 14433;
			Resistance[0] = 53;
			Bonding = 2;
			SellPrice = 6764;
			AvailableClasses = 0x7FFF;
			Model = 26159;
			ObjectClass = 4;
			SubClass = 1;
			Level = 46;
			ReqLevel = 41;
			Name = "Windchaser Woolies";
			Name2 = "Windchaser Woolies";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 33822;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
			StrBonus = 5;
			IqBonus = 10;
			SpiritBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Venomshroud Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class VenomshroudLeggings : Item
	{
		public VenomshroudLeggings() : base()
		{
			Id = 14444;
			Resistance[0] = 59;
			Bonding = 2;
			SellPrice = 10955;
			AvailableClasses = 0x7FFF;
			Model = 16632;
			ObjectClass = 4;
			SubClass = 1;
			Level = 52;
			ReqLevel = 47;
			Name = "Venomshroud Leggings";
			Name2 = "Venomshroud Leggings";
			Resistance[3] = 6;
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 54775;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
			SpiritBonus = 15;
			IqBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Elunarian Sarong)
*
***************************************************************/

namespace Server.Items
{
	public class ElunarianSarong : Item
	{
		public ElunarianSarong() : base()
		{
			Id = 14462;
			Resistance[0] = 70;
			Bonding = 2;
			SellPrice = 18751;
			AvailableClasses = 0x7FFF;
			Model = 26238;
			ObjectClass = 4;
			SubClass = 1;
			Level = 62;
			ReqLevel = 57;
			Name = "Elunarian Sarong";
			Name2 = "Elunarian Sarong";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 93758;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
			StaminaBonus = 11;
			IqBonus = 14;
			SpiritBonus = 14;
		}
	}
}


/**************************************************************
*
*				(Skullsmoke Pants)
*
***************************************************************/

namespace Server.Items
{
	public class SkullsmokePants : Item
	{
		public SkullsmokePants() : base()
		{
			Id = 14577;
			Resistance[0] = 76;
			Bonding = 1;
			SellPrice = 21585;
			AvailableClasses = 0x7FFF;
			Model = 28715;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 1;
			Level = 61;
			ReqLevel = 56;
			Name = "Skullsmoke Pants";
			Name2 = "Skullsmoke Pants";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 107926;
			Resistance[5] = 5;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 65;
			SpiritBonus = 20;
			StaminaBonus = 20;
		}
	}
}


/**************************************************************
*
*				(Necropile Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class NecropileLeggings : Item
	{
		public NecropileLeggings() : base()
		{
			Id = 14632;
			Resistance[0] = 69;
			Bonding = 1;
			SellPrice = 18121;
			AvailableClasses = 0x7FFF;
			Model = 25255;
			ObjectClass = 4;
			SubClass = 1;
			Level = 61;
			ReqLevel = 56;
			Name = "Necropile Leggings";
			Name2 = "Necropile Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 90608;
			Sets = 122;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
			SpiritBonus = 18;
			IqBonus = 5;
			StaminaBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Highborne Pants)
*
***************************************************************/

namespace Server.Items
{
	public class HighbornePants : Item
	{
		public HighbornePants() : base()
		{
			Id = 15119;
			Resistance[0] = 63;
			Bonding = 2;
			SellPrice = 13683;
			AvailableClasses = 0x7FFF;
			Model = 26177;
			ObjectClass = 4;
			SubClass = 1;
			Level = 56;
			ReqLevel = 51;
			Name = "Highborne Pants";
			Name2 = "Highborne Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 68415;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
			SpiritBonus = 15;
			IqBonus = 10;
			AgilityBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Ghastly Trousers)
*
***************************************************************/

namespace Server.Items
{
	public class GhastlyTrousers : Item
	{
		public GhastlyTrousers() : base()
		{
			Id = 15449;
			Resistance[0] = 28;
			Bonding = 1;
			SellPrice = 425;
			AvailableClasses = 0x7FFF;
			Model = 16850;
			ObjectClass = 4;
			SubClass = 1;
			Level = 18;
			Name = "Ghastly Trousers";
			Name2 = "Ghastly Trousers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2127;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 40;
			SpiritBonus = 4;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Knight-Captain's Silk Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class KnightCaptainsSilkLeggings : Item
	{
		public KnightCaptainsSilkLeggings() : base()
		{
			Id = 16414;
			Resistance[0] = 78;
			Bonding = 1;
			SellPrice = 11735;
			AvailableClasses = 0x80;
			Model = 27230;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Knight-Captain's Silk Leggings";
			Name2 = "Knight-Captain's Silk Leggings";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 58676;
			Sets = 343;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 65;
			Flags = 32768;
			SetSpell( 14254 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 16;
			IqBonus = 16;
			SpiritBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Marshal's Silk Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class MarshalsSilkLeggings : Item
	{
		public MarshalsSilkLeggings() : base()
		{
			Id = 16442;
			Resistance[0] = 88;
			Bonding = 1;
			SellPrice = 17745;
			AvailableClasses = 0x80;
			Model = 30342;
			ObjectClass = 4;
			SubClass = 1;
			Level = 65;
			ReqLevel = 60;
			Name = "Marshal's Silk Leggings";
			Name2 = "Marshal's Silk Leggings";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 88726;
			Sets = 388;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 75;
			Flags = 32768;
			SetSpell( 14127 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 23;
			IqBonus = 19;
			SpiritBonus = 16;
		}
	}
}


/**************************************************************
*
*				(Legionnaire's Silk Pants)
*
***************************************************************/

namespace Server.Items
{
	public class LegionnairesSilkPants : Item
	{
		public LegionnairesSilkPants() : base()
		{
			Id = 16490;
			Resistance[0] = 78;
			Bonding = 1;
			SellPrice = 11560;
			AvailableClasses = 0x80;
			Model = 26144;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Legionnaire's Silk Pants";
			Name2 = "Legionnaire's Silk Pants";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 57801;
			Sets = 341;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 65;
			Flags = 32768;
			SetSpell( 14254 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 16;
			IqBonus = 16;
			SpiritBonus = 13;
		}
	}
}


/**************************************************************
*
*				(General's Silk Trousers)
*
***************************************************************/

namespace Server.Items
{
	public class GeneralsSilkTrousers : Item
	{
		public GeneralsSilkTrousers() : base()
		{
			Id = 16534;
			Resistance[0] = 88;
			Bonding = 1;
			SellPrice = 17686;
			AvailableClasses = 0x80;
			Model = 27259;
			ObjectClass = 4;
			SubClass = 1;
			Level = 65;
			ReqLevel = 60;
			Name = "General's Silk Trousers";
			Name2 = "General's Silk Trousers";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 88430;
			Sets = 387;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 75;
			Flags = 32768;
			SetSpell( 14127 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 23;
			IqBonus = 19;
			SpiritBonus = 16;
		}
	}
}


/**************************************************************
*
*				(Magister's Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class MagistersLeggings : Item
	{
		public MagistersLeggings() : base()
		{
			Id = 16687;
			Resistance[0] = 76;
			Bonding = 1;
			SellPrice = 20281;
			AvailableClasses = 0x7FFF;
			Model = 29273;
			ObjectClass = 4;
			SubClass = 1;
			Level = 61;
			ReqLevel = 56;
			Name = "Magister's Leggings";
			Name2 = "Magister's Leggings";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 101407;
			Sets = 181;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 65;
			IqBonus = 21;
			SpiritBonus = 20;
			StaminaBonus = 8;
			AgilityBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Devout Skirt)
*
***************************************************************/

namespace Server.Items
{
	public class DevoutSkirt : Item
	{
		public DevoutSkirt() : base()
		{
			Id = 16694;
			Resistance[0] = 76;
			Bonding = 1;
			SellPrice = 20820;
			AvailableClasses = 0x7FFF;
			Model = 30424;
			ObjectClass = 4;
			SubClass = 1;
			Level = 61;
			ReqLevel = 56;
			Name = "Devout Skirt";
			Name2 = "Devout Skirt";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 104102;
			Sets = 182;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 65;
			IqBonus = 23;
			SpiritBonus = 15;
			StaminaBonus = 8;
			AgilityBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Dreadmist Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class DreadmistLeggings : Item
	{
		public DreadmistLeggings() : base()
		{
			Id = 16699;
			Resistance[0] = 76;
			Bonding = 1;
			SellPrice = 21202;
			AvailableClasses = 0x7FFF;
			Model = 29797;
			ObjectClass = 4;
			SubClass = 1;
			Level = 61;
			ReqLevel = 56;
			Name = "Dreadmist Leggings";
			Name2 = "Dreadmist Leggings";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 106014;
			Sets = 183;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 65;
			IqBonus = 21;
			StaminaBonus = 15;
			SpiritBonus = 12;
			AgilityBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Arcanist Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class ArcanistLeggings : Item
	{
		public ArcanistLeggings() : base()
		{
			Id = 16796;
			Resistance[0] = 89;
			Bonding = 1;
			SellPrice = 33990;
			AvailableClasses = 0x80;
			Model = 30582;
			ObjectClass = 4;
			SubClass = 1;
			Level = 66;
			ReqLevel = 60;
			Name = "Arcanist Leggings";
			Name2 = "Arcanist Leggings";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 169953;
			Sets = 201;
			Resistance[5] = 10;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 75;
			SetSpell( 18384 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 9404 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 24;
			IqBonus = 13;
			StaminaBonus = 23;
		}
	}
}


/**************************************************************
*
*				(Felheart Pants)
*
***************************************************************/

namespace Server.Items
{
	public class FelheartPants : Item
	{
		public FelheartPants() : base()
		{
			Id = 16810;
			Resistance[0] = 89;
			Bonding = 1;
			SellPrice = 35821;
			AvailableClasses = 0x100;
			Model = 31972;
			ObjectClass = 4;
			SubClass = 1;
			Level = 66;
			ReqLevel = 60;
			Name = "Felheart Pants";
			Name2 = "Felheart Pants";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 179108;
			Sets = 203;
			Resistance[5] = 10;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 75;
			SetSpell( 21601 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 9417 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 19;
			IqBonus = 19;
			StaminaBonus = 20;
		}
	}
}


/**************************************************************
*
*				(Pants of Prophecy)
*
***************************************************************/

namespace Server.Items
{
	public class PantsOfProphecy : Item
	{
		public PantsOfProphecy() : base()
		{
			Id = 16814;
			Resistance[0] = 89;
			Bonding = 1;
			SellPrice = 37286;
			AvailableClasses = 0x10;
			Model = 28198;
			ObjectClass = 4;
			SubClass = 1;
			Level = 66;
			ReqLevel = 60;
			Name = "Pants of Prophecy";
			Name2 = "Pants of Prophecy";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 186432;
			Sets = 202;
			Resistance[5] = 10;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 75;
			SetSpell( 21626 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 9408 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 24;
			IqBonus = 20;
			StaminaBonus = 18;
		}
	}
}


/**************************************************************
*
*				(Netherwind Pants)
*
***************************************************************/

namespace Server.Items
{
	public class NetherwindPants : Item
	{
		public NetherwindPants() : base()
		{
			Id = 16915;
			Resistance[6] = 10;
			Resistance[0] = 101;
			Bonding = 1;
			SellPrice = 56647;
			AvailableClasses = 0x80;
			Model = 29782;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 1;
			Level = 76;
			ReqLevel = 60;
			Name = "Netherwind Pants";
			Name2 = "Netherwind Pants";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 283236;
			Sets = 210;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 75;
			SetSpell( 14798 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 27;
			IqBonus = 17;
			StaminaBonus = 16;
		}
	}
}


/**************************************************************
*
*				(Leggings of Transcendence)
*
***************************************************************/

namespace Server.Items
{
	public class LeggingsOfTranscendence : Item
	{
		public LeggingsOfTranscendence() : base()
		{
			Id = 16922;
			Resistance[6] = 10;
			Resistance[0] = 101;
			Bonding = 1;
			SellPrice = 58135;
			AvailableClasses = 0x10;
			Model = 29782;
			ObjectClass = 4;
			SubClass = 1;
			Level = 76;
			ReqLevel = 60;
			Name = "Leggings of Transcendence";
			Name2 = "Leggings of Transcendence";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 290677;
			Sets = 211;
			Resistance[5] = 10;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 75;
			SetSpell( 18033 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 21;
			IqBonus = 21;
			StaminaBonus = 16;
		}
	}
}


/**************************************************************
*
*				(Nemesis Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class NemesisLeggings : Item
	{
		public NemesisLeggings() : base()
		{
			Id = 16930;
			Resistance[6] = 10;
			Resistance[0] = 101;
			Bonding = 1;
			SellPrice = 55575;
			AvailableClasses = 0x100;
			Model = 29857;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 1;
			Level = 76;
			ReqLevel = 60;
			Name = "Nemesis Leggings";
			Name2 = "Nemesis Leggings";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 277879;
			Sets = 212;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 75;
			SetSpell( 14798 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 17;
			IqBonus = 16;
			StaminaBonus = 27;
		}
	}
}


/**************************************************************
*
*				(Knight-Captain's Dreadweave Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class KnightCaptainsDreadweaveLeggings : Item
	{
		public KnightCaptainsDreadweaveLeggings() : base()
		{
			Id = 17567;
			Resistance[0] = 78;
			Bonding = 1;
			SellPrice = 11860;
			AvailableClasses = 0x100;
			Model = 30385;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Knight-Captain's Dreadweave Leggings";
			Name2 = "Knight-Captain's Dreadweave Leggings";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 59304;
			Sets = 346;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 65;
			Flags = 32768;
			SetSpell( 9345 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 21;
			SpiritBonus = 20;
		}
	}
}


/**************************************************************
*
*				(Legionnaire's Dreadweave Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class LegionnairesDreadweaveLeggings : Item
	{
		public LegionnairesDreadweaveLeggings() : base()
		{
			Id = 17571;
			Resistance[0] = 78;
			Bonding = 1;
			SellPrice = 11182;
			AvailableClasses = 0x100;
			Model = 31032;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Legionnaire's Dreadweave Leggings";
			Name2 = "Legionnaire's Dreadweave Leggings";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 55912;
			Sets = 345;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 65;
			Flags = 32768;
			SetSpell( 14127 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 15;
			SpiritBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Marshal's Dreadweave Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class MarshalsDreadweaveLeggings : Item
	{
		public MarshalsDreadweaveLeggings() : base()
		{
			Id = 17579;
			Resistance[0] = 88;
			Bonding = 1;
			SellPrice = 16936;
			AvailableClasses = 0x100;
			Model = 30385;
			ObjectClass = 4;
			SubClass = 1;
			Level = 65;
			ReqLevel = 60;
			Name = "Marshal's Dreadweave Leggings";
			Name2 = "Marshal's Dreadweave Leggings";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 84680;
			Sets = 392;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 75;
			Flags = 32768;
			SetSpell( 14055 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 23;
			SpiritBonus = 16;
		}
	}
}


/**************************************************************
*
*				(General's Dreadweave Pants)
*
***************************************************************/

namespace Server.Items
{
	public class GeneralsDreadweavePants : Item
	{
		public GeneralsDreadweavePants() : base()
		{
			Id = 17593;
			Resistance[0] = 88;
			Bonding = 1;
			SellPrice = 16560;
			AvailableClasses = 0x100;
			Model = 30380;
			ObjectClass = 4;
			SubClass = 1;
			Level = 65;
			ReqLevel = 60;
			Name = "General's Dreadweave Pants";
			Name2 = "General's Dreadweave Pants";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 82801;
			Sets = 391;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 75;
			Flags = 32768;
			SetSpell( 14055 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 23;
			SpiritBonus = 16;
		}
	}
}


/**************************************************************
*
*				(Knight-Captain's Satin Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class KnightCaptainsSatinLeggings : Item
	{
		public KnightCaptainsSatinLeggings() : base()
		{
			Id = 17599;
			Resistance[0] = 78;
			Bonding = 1;
			SellPrice = 11518;
			AvailableClasses = 0x10;
			Model = 25198;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Knight-Captain's Satin Leggings";
			Name2 = "Knight-Captain's Satin Leggings";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 57594;
			Sets = 344;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 65;
			Flags = 32768;
			SetSpell( 14254 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 16;
			SpiritBonus = 13;
			IqBonus = 16;
		}
	}
}


/**************************************************************
*
*				(Marshal's Satin Pants)
*
***************************************************************/

namespace Server.Items
{
	public class MarshalsSatinPants : Item
	{
		public MarshalsSatinPants() : base()
		{
			Id = 17603;
			Resistance[0] = 88;
			Bonding = 1;
			SellPrice = 17630;
			AvailableClasses = 0x10;
			Model = 30385;
			ObjectClass = 4;
			SubClass = 1;
			Level = 65;
			ReqLevel = 60;
			Name = "Marshal's Satin Pants";
			Name2 = "Marshal's Satin Pants";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 88150;
			Sets = 389;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 75;
			Flags = 32768;
			SetSpell( 14127 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 23;
			IqBonus = 19;
			SpiritBonus = 16;
		}
	}
}


/**************************************************************
*
*				(Legionnaire's Satin Trousers)
*
***************************************************************/

namespace Server.Items
{
	public class LegionnairesSatinTrousers : Item
	{
		public LegionnairesSatinTrousers() : base()
		{
			Id = 17611;
			Resistance[0] = 78;
			Bonding = 1;
			SellPrice = 11179;
			AvailableClasses = 0x10;
			Model = 31033;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Legionnaire's Satin Trousers";
			Name2 = "Legionnaire's Satin Trousers";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 55895;
			Sets = 342;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 65;
			Flags = 32768;
			SetSpell( 14254 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 16;
			SpiritBonus = 13;
			IqBonus = 16;
		}
	}
}


/**************************************************************
*
*				(General's Satin Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class GeneralsSatinLeggings : Item
	{
		public GeneralsSatinLeggings() : base()
		{
			Id = 17625;
			Resistance[0] = 88;
			Bonding = 1;
			SellPrice = 17752;
			AvailableClasses = 0x10;
			Model = 30380;
			ObjectClass = 4;
			SubClass = 1;
			Level = 65;
			ReqLevel = 60;
			Name = "General's Satin Leggings";
			Name2 = "General's Satin Leggings";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 88760;
			Sets = 390;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 75;
			Flags = 32768;
			SetSpell( 14127 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 23;
			IqBonus = 19;
			SpiritBonus = 16;
		}
	}
}


/**************************************************************
*
*				(Threadbare Trousers)
*
***************************************************************/

namespace Server.Items
{
	public class ThreadbareTrousers : Item
	{
		public ThreadbareTrousers() : base()
		{
			Id = 18346;
			Resistance[0] = 68;
			Bonding = 1;
			SellPrice = 16345;
			AvailableClasses = 0x7FFF;
			Model = 30698;
			ObjectClass = 4;
			SubClass = 1;
			Level = 60;
			ReqLevel = 55;
			Name = "Threadbare Trousers";
			Name2 = "Threadbare Trousers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 81726;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 55;
			SetSpell( 22849 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Padre's Trousers)
*
***************************************************************/

namespace Server.Items
{
	public class PadresTrousers : Item
	{
		public PadresTrousers() : base()
		{
			Id = 18386;
			Resistance[0] = 76;
			Bonding = 1;
			SellPrice = 20588;
			AvailableClasses = 0x7FFF;
			Model = 21964;
			ObjectClass = 4;
			SubClass = 1;
			Level = 61;
			ReqLevel = 56;
			Name = "Padre's Trousers";
			Name2 = "Padre's Trousers";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 102943;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 65;
			SetSpell( 21626 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 18032 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 20;
		}
	}
}


/**************************************************************
*
*				(Leggings of Arcane Supremacy)
*
***************************************************************/

namespace Server.Items
{
	public class LeggingsOfArcaneSupremacy : Item
	{
		public LeggingsOfArcaneSupremacy() : base()
		{
			Id = 18545;
			Resistance[6] = 10;
			Resistance[0] = 93;
			Bonding = 1;
			SellPrice = 42546;
			AvailableClasses = 0x7FFF;
			Model = 24615;
			Resistance[4] = 10;
			ObjectClass = 4;
			SubClass = 1;
			Level = 69;
			ReqLevel = 60;
			Name = "Leggings of Arcane Supremacy";
			Name2 = "Leggings of Arcane Supremacy";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 212731;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 75;
			SetSpell( 17830 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 24;
			IqBonus = 14;
			StaminaBonus = 14;
		}
	}
}


/**************************************************************
*
*				(Sacred Cloth Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class SacredClothLeggings : Item
	{
		public SacredClothLeggings() : base()
		{
			Id = 18745;
			Resistance[0] = 71;
			Bonding = 1;
			SellPrice = 16238;
			AvailableClasses = 0x7FFF;
			Model = 2311;
			ObjectClass = 4;
			SubClass = 1;
			Level = 57;
			ReqLevel = 52;
			Name = "Sacred Cloth Leggings";
			Name2 = "Sacred Cloth Leggings";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 81194;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 65;
			SetSpell( 9343 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 19;
			IqBonus = 12;
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Manastorm Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class ManastormLeggings : Item
	{
		public ManastormLeggings() : base()
		{
			Id = 18872;
			Resistance[0] = 85;
			Bonding = 1;
			SellPrice = 30394;
			AvailableClasses = 0x7FFF;
			Model = 31331;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Manastorm Leggings";
			Name2 = "Manastorm Leggings";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 151971;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 75;
			SetSpell( 21640 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 19;
			SpiritBonus = 14;
		}
	}
}


/**************************************************************
*
*				(Fel Infused Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class FelInfusedLeggings : Item
	{
		public FelInfusedLeggings() : base()
		{
			Id = 19133;
			Resistance[0] = 95;
			Bonding = 1;
			SellPrice = 43277;
			AvailableClasses = 0x7FFF;
			Model = 31651;
			ObjectClass = 4;
			SubClass = 1;
			Level = 71;
			ReqLevel = 60;
			Name = "Fel Infused Leggings";
			Name2 = "Fel Infused Leggings";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 216387;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 75;
			SetSpell( 23594 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 21;
		}
	}
}


/**************************************************************
*
*				(Flarecore Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class FlarecoreLeggings : Item
	{
		public FlarecoreLeggings() : base()
		{
			Id = 19165;
			Resistance[0] = 94;
			Bonding = 2;
			SellPrice = 45006;
			AvailableClasses = 0x7FFF;
			Model = 31685;
			Resistance[2] = 16;
			ObjectClass = 4;
			SubClass = 1;
			Level = 70;
			ReqLevel = 60;
			Name = "Flarecore Leggings";
			Name2 = "Flarecore Leggings";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 225032;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 75;
			SetSpell( 17886 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 21;
		}
	}
}


/**************************************************************
*
*				(Empowered Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class EmpoweredLeggings : Item
	{
		public EmpoweredLeggings() : base()
		{
			Id = 19385;
			Resistance[0] = 103;
			Bonding = 1;
			SellPrice = 61990;
			AvailableClasses = 0x7FFF;
			Model = 31911;
			ObjectClass = 4;
			SubClass = 1;
			Level = 77;
			ReqLevel = 60;
			Name = "Empowered Leggings";
			Name2 = "Empowered Leggings";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 309954;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 7;
			Durability = 75;
			SetSpell( 18046 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 18384 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 12;
			IqBonus = 24;
			StaminaBonus = 12;
		}
	}
}


