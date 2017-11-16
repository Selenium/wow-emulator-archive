/**************************************************************
*
*		Made by fulgas (fulgas@gmail.com)
*
*  WowwoW Item Designer ( 2005/8/23 - 10:05:16 )
*
***************************************************************/

using System;
using System.Collections;

/***************************************************************/

/**************************************************************
*
*				(Dwarven Leather Pants)
*
***************************************************************/

namespace Server.Items
{
	public class DwarvenLeatherPants : Item
	{
		public DwarvenLeatherPants() : base()
		{
			Id = 61;
			Resistance[0] = 29;
			Bonding = 1;
			SellPrice = 12;
			AvailableClasses = 0x7FFF;
			Model = 16953;
			ObjectClass = 4;
			SubClass = 2;
			Level = 5;
			Name = "Dwarven Leather Pants";
			Name2 = "Dwarven Leather Pants";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 60;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Primitive Kilt)
*
***************************************************************/

namespace Server.Items
{
	public class PrimitiveKilt : Item
	{
		public PrimitiveKilt() : base()
		{
			Id = 153;
			Resistance[0] = 14;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 10050;
			ObjectClass = 4;
			SubClass = 2;
			Level = 1;
			ReqLevel = 1;
			Name = "Primitive Kilt";
			Name2 = "Primitive Kilt";
			AvailableRaces = 0x1FF;
			BuyPrice = 5;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Dirty Leather Pants)
*
***************************************************************/

namespace Server.Items
{
	public class DirtyLeatherPants : Item
	{
		public DirtyLeatherPants() : base()
		{
			Id = 209;
			Resistance[0] = 29;
			SellPrice = 12;
			AvailableClasses = 0x7FFF;
			Model = 17140;
			ObjectClass = 4;
			SubClass = 2;
			Level = 5;
			ReqLevel = 1;
			Name = "Dirty Leather Pants";
			Name2 = "Dirty Leather Pants";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 60;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Cured Leather Pants)
*
***************************************************************/

namespace Server.Items
{
	public class CuredLeatherPants : Item
	{
		public CuredLeatherPants() : base()
		{
			Id = 237;
			Resistance[0] = 67;
			SellPrice = 561;
			AvailableClasses = 0x7FFF;
			Model = 14476;
			ObjectClass = 4;
			SubClass = 2;
			Level = 22;
			ReqLevel = 17;
			Name = "Cured Leather Pants";
			Name2 = "Cured Leather Pants";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2805;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Rough Leather Pants)
*
***************************************************************/

namespace Server.Items
{
	public class RoughLeatherPants : Item
	{
		public RoughLeatherPants() : base()
		{
			Id = 798;
			Resistance[0] = 46;
			SellPrice = 70;
			AvailableClasses = 0x7FFF;
			Model = 22972;
			ObjectClass = 4;
			SubClass = 2;
			Level = 10;
			ReqLevel = 5;
			Name = "Rough Leather Pants";
			Name2 = "Rough Leather Pants";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 354;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Tanned Leather Pants)
*
***************************************************************/

namespace Server.Items
{
	public class TannedLeatherPants : Item
	{
		public TannedLeatherPants() : base()
		{
			Id = 845;
			Resistance[0] = 60;
			SellPrice = 289;
			AvailableClasses = 0x7FFF;
			Model = 9640;
			ObjectClass = 4;
			SubClass = 2;
			Level = 17;
			ReqLevel = 12;
			Name = "Tanned Leather Pants";
			Name2 = "Tanned Leather Pants";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1447;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Smith's Trousers)
*
***************************************************************/

namespace Server.Items
{
	public class SmithsTrousers : Item
	{
		public SmithsTrousers() : base()
		{
			Id = 1310;
			Resistance[0] = 68;
			Bonding = 1;
			SellPrice = 715;
			AvailableClasses = 0x7FFF;
			Model = 16971;
			ObjectClass = 4;
			SubClass = 2;
			Level = 20;
			Name = "Smith's Trousers";
			Name2 = "Smith's Trousers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3576;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 55;
			StrBonus = 4;
			AgilityBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Ragged Leather Pants)
*
***************************************************************/

namespace Server.Items
{
	public class RaggedLeatherPants : Item
	{
		public RaggedLeatherPants() : base()
		{
			Id = 1366;
			Resistance[0] = 17;
			SellPrice = 2;
			AvailableClasses = 0x7FFF;
			Model = 14338;
			ObjectClass = 4;
			SubClass = 2;
			Level = 2;
			ReqLevel = 1;
			Name = "Ragged Leather Pants";
			Name2 = "Ragged Leather Pants";
			AvailableRaces = 0x1FF;
			BuyPrice = 11;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Worn Leather Pants)
*
***************************************************************/

namespace Server.Items
{
	public class WornLeatherPants : Item
	{
		public WornLeatherPants() : base()
		{
			Id = 1423;
			Resistance[0] = 34;
			SellPrice = 18;
			AvailableClasses = 0x7FFF;
			Model = 14346;
			ObjectClass = 4;
			SubClass = 2;
			Level = 7;
			ReqLevel = 2;
			Name = "Worn Leather Pants";
			Name2 = "Worn Leather Pants";
			AvailableRaces = 0x1FF;
			BuyPrice = 94;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Frontier Britches)
*
***************************************************************/

namespace Server.Items
{
	public class FrontierBritches : Item
	{
		public FrontierBritches() : base()
		{
			Id = 1436;
			Resistance[0] = 64;
			Bonding = 1;
			SellPrice = 458;
			AvailableClasses = 0x7FFF;
			Model = 17144;
			ObjectClass = 4;
			SubClass = 2;
			Level = 17;
			Name = "Frontier Britches";
			Name2 = "Frontier Britches";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2290;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 50;
			StrBonus = 3;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Warped Leather Pants)
*
***************************************************************/

namespace Server.Items
{
	public class WarpedLeatherPants : Item
	{
		public WarpedLeatherPants() : base()
		{
			Id = 1507;
			Resistance[0] = 54;
			SellPrice = 123;
			AvailableClasses = 0x7FFF;
			Model = 17156;
			ObjectClass = 4;
			SubClass = 2;
			Level = 14;
			ReqLevel = 9;
			Name = "Warped Leather Pants";
			Name2 = "Warped Leather Pants";
			AvailableRaces = 0x1FF;
			BuyPrice = 616;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Basilisk Hide Pants)
*
***************************************************************/

namespace Server.Items
{
	public class BasiliskHidePants : Item
	{
		public BasiliskHidePants() : base()
		{
			Id = 1718;
			Resistance[0] = 113;
			Bonding = 2;
			SellPrice = 8040;
			AvailableClasses = 0x7FFF;
			Model = 17137;
			ObjectClass = 4;
			SubClass = 2;
			Level = 43;
			ReqLevel = 38;
			Name = "Basilisk Hide Pants";
			Name2 = "Basilisk Hide Pants";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 40202;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 75;
			AgilityBonus = 21;
			IqBonus = 3;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Patched Leather Pants)
*
***************************************************************/

namespace Server.Items
{
	public class PatchedLeatherPants : Item
	{
		public PatchedLeatherPants() : base()
		{
			Id = 1792;
			Resistance[0] = 59;
			SellPrice = 208;
			AvailableClasses = 0x7FFF;
			Model = 6731;
			ObjectClass = 4;
			SubClass = 2;
			Level = 18;
			ReqLevel = 13;
			Name = "Patched Leather Pants";
			Name2 = "Patched Leather Pants";
			AvailableRaces = 0x1FF;
			BuyPrice = 1041;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Rawhide Pants)
*
***************************************************************/

namespace Server.Items
{
	public class RawhidePants : Item
	{
		public RawhidePants() : base()
		{
			Id = 1800;
			Resistance[0] = 66;
			SellPrice = 479;
			AvailableClasses = 0x7FFF;
			Model = 16967;
			ObjectClass = 4;
			SubClass = 2;
			Level = 24;
			ReqLevel = 19;
			Name = "Rawhide Pants";
			Name2 = "Rawhide Pants";
			AvailableRaces = 0x1FF;
			BuyPrice = 2397;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Tough Leather Pants)
*
***************************************************************/

namespace Server.Items
{
	public class ToughLeatherPants : Item
	{
		public ToughLeatherPants() : base()
		{
			Id = 1808;
			Resistance[0] = 74;
			SellPrice = 856;
			AvailableClasses = 0x7FFF;
			Model = 16977;
			ObjectClass = 4;
			SubClass = 2;
			Level = 30;
			ReqLevel = 25;
			Name = "Tough Leather Pants";
			Name2 = "Tough Leather Pants";
			AvailableRaces = 0x1FF;
			BuyPrice = 4284;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Stonemason Trousers)
*
***************************************************************/

namespace Server.Items
{
	public class StonemasonTrousers : Item
	{
		public StonemasonTrousers() : base()
		{
			Id = 1934;
			Resistance[0] = 68;
			Bonding = 2;
			SellPrice = 731;
			AvailableClasses = 0x7FFF;
			Model = 6774;
			ObjectClass = 4;
			SubClass = 2;
			Level = 20;
			ReqLevel = 15;
			Name = "Stonemason Trousers";
			Name2 = "Stonemason Trousers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3656;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 55;
			AgilityBonus = 4;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Cracked Leather Pants)
*
***************************************************************/

namespace Server.Items
{
	public class CrackedLeatherPants : Item
	{
		public CrackedLeatherPants() : base()
		{
			Id = 2126;
			Resistance[0] = 29;
			SellPrice = 11;
			AvailableClasses = 0x7FFF;
			Model = 14429;
			ObjectClass = 4;
			SubClass = 2;
			Level = 5;
			ReqLevel = 1;
			Name = "Cracked Leather Pants";
			Name2 = "Cracked Leather Pants";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 59;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Cuirboulli Pants)
*
***************************************************************/

namespace Server.Items
{
	public class CuirboulliPants : Item
	{
		public CuirboulliPants() : base()
		{
			Id = 2146;
			Resistance[0] = 74;
			SellPrice = 961;
			AvailableClasses = 0x7FFF;
			Model = 14481;
			ObjectClass = 4;
			SubClass = 2;
			Level = 27;
			ReqLevel = 22;
			Name = "Cuirboulli Pants";
			Name2 = "Cuirboulli Pants";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 4809;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Shadow Weaver Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class ShadowWeaverLeggings : Item
	{
		public ShadowWeaverLeggings() : base()
		{
			Id = 2233;
			Resistance[0] = 78;
			Bonding = 2;
			SellPrice = 1690;
			AvailableClasses = 0x7FFF;
			Model = 18489;
			ObjectClass = 4;
			SubClass = 2;
			Level = 27;
			ReqLevel = 22;
			Name = "Shadow Weaver Leggings";
			Name2 = "Shadow Weaver Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 8452;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 60;
			AgilityBonus = 6;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Patched Pants)
*
***************************************************************/

namespace Server.Items
{
	public class PatchedPants : Item
	{
		public PatchedPants() : base()
		{
			Id = 2237;
			Resistance[0] = 46;
			Bonding = 1;
			SellPrice = 75;
			AvailableClasses = 0x7FFF;
			Model = 2628;
			ObjectClass = 4;
			SubClass = 2;
			Level = 10;
			Name = "Patched Pants";
			Name2 = "Patched Pants";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 377;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Handstitched Leather Pants)
*
***************************************************************/

namespace Server.Items
{
	public class HandstitchedLeatherPants : Item
	{
		public HandstitchedLeatherPants() : base()
		{
			Id = 2303;
			Resistance[0] = 46;
			SellPrice = 71;
			AvailableClasses = 0x7FFF;
			Model = 9500;
			ObjectClass = 4;
			SubClass = 2;
			Level = 10;
			ReqLevel = 5;
			Name = "Handstitched Leather Pants";
			Name2 = "Handstitched Leather Pants";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 358;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Battered Leather Pants)
*
***************************************************************/

namespace Server.Items
{
	public class BatteredLeatherPants : Item
	{
		public BatteredLeatherPants() : base()
		{
			Id = 2372;
			Resistance[0] = 46;
			SellPrice = 68;
			AvailableClasses = 0x7FFF;
			Model = 18478;
			ObjectClass = 4;
			SubClass = 2;
			Level = 10;
			ReqLevel = 5;
			Name = "Battered Leather Pants";
			Name2 = "Battered Leather Pants";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 343;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Studded Pants)
*
***************************************************************/

namespace Server.Items
{
	public class StuddedPants : Item
	{
		public StuddedPants() : base()
		{
			Id = 2465;
			Resistance[0] = 87;
			SellPrice = 2495;
			AvailableClasses = 0x7FFF;
			Model = 17031;
			ObjectClass = 4;
			SubClass = 2;
			Level = 37;
			ReqLevel = 32;
			Name = "Studded Pants";
			Name2 = "Studded Pants";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 12477;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Reinforced Leather Pants)
*
***************************************************************/

namespace Server.Items
{
	public class ReinforcedLeatherPants : Item
	{
		public ReinforcedLeatherPants() : base()
		{
			Id = 2472;
			Resistance[0] = 110;
			SellPrice = 6842;
			AvailableClasses = 0x7FFF;
			Model = 14495;
			ObjectClass = 4;
			SubClass = 2;
			Level = 50;
			ReqLevel = 45;
			Name = "Reinforced Leather Pants";
			Name2 = "Reinforced Leather Pants";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 34211;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Stretched Leather Trousers)
*
***************************************************************/

namespace Server.Items
{
	public class StretchedLeatherTrousers : Item
	{
		public StretchedLeatherTrousers() : base()
		{
			Id = 2818;
			Resistance[0] = 61;
			Bonding = 1;
			SellPrice = 363;
			AvailableClasses = 0x7FFF;
			Model = 1963;
			ObjectClass = 4;
			SubClass = 2;
			Level = 15;
			Name = "Stretched Leather Trousers";
			Name2 = "Stretched Leather Trousers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1817;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 45;
			StrBonus = 2;
			AgilityBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Burnt Leather Breeches)
*
***************************************************************/

namespace Server.Items
{
	public class BurntLeatherBreeches : Item
	{
		public BurntLeatherBreeches() : base()
		{
			Id = 2962;
			Resistance[0] = 48;
			Bonding = 2;
			SellPrice = 120;
			AvailableClasses = 0x7FFF;
			Model = 17160;
			ObjectClass = 4;
			SubClass = 2;
			Level = 10;
			ReqLevel = 5;
			Name = "Burnt Leather Breeches";
			Name2 = "Burnt Leather Breeches";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 600;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 40;
			AgilityBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Hunting Pants)
*
***************************************************************/

namespace Server.Items
{
	public class HuntingPants : Item
	{
		public HuntingPants() : base()
		{
			Id = 2974;
			Resistance[0] = 62;
			Bonding = 2;
			SellPrice = 392;
			AvailableClasses = 0x7FFF;
			Model = 14537;
			ObjectClass = 4;
			SubClass = 2;
			Level = 16;
			ReqLevel = 11;
			Name = "Hunting Pants";
			Name2 = "Hunting Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1962;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 50;
			AgilityBonus = 3;
			IqBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Inscribed Leather Pants)
*
***************************************************************/

namespace Server.Items
{
	public class InscribedLeatherPants : Item
	{
		public InscribedLeatherPants() : base()
		{
			Id = 2986;
			Resistance[0] = 68;
			Bonding = 2;
			SellPrice = 718;
			AvailableClasses = 0x7FFF;
			Model = 11369;
			ObjectClass = 4;
			SubClass = 2;
			Level = 20;
			ReqLevel = 15;
			Name = "Inscribed Leather Pants";
			Name2 = "Inscribed Leather Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3590;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 55;
			StaminaBonus = 4;
			SpiritBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Bluegill Breeches)
*
***************************************************************/

namespace Server.Items
{
	public class BluegillBreeches : Item
	{
		public BluegillBreeches() : base()
		{
			Id = 3022;
			Resistance[0] = 72;
			Bonding = 2;
			SellPrice = 1085;
			AvailableClasses = 0x7FFF;
			Model = 16534;
			ObjectClass = 4;
			SubClass = 2;
			Level = 23;
			ReqLevel = 18;
			Name = "Bluegill Breeches";
			Name2 = "Bluegill Breeches";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5427;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 55;
			AgilityBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Forest Leather Pants)
*
***************************************************************/

namespace Server.Items
{
	public class ForestLeatherPants : Item
	{
		public ForestLeatherPants() : base()
		{
			Id = 3056;
			Resistance[0] = 76;
			Bonding = 2;
			SellPrice = 1532;
			AvailableClasses = 0x7FFF;
			Model = 16954;
			ObjectClass = 4;
			SubClass = 2;
			Level = 26;
			ReqLevel = 21;
			Name = "Forest Leather Pants";
			Name2 = "Forest Leather Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7660;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 60;
			AgilityBonus = 6;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Zombie Skin Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class ZombieSkinLeggings : Item
	{
		public ZombieSkinLeggings() : base()
		{
			Id = 3272;
			Resistance[0] = 29;
			Bonding = 1;
			SellPrice = 13;
			AvailableClasses = 0x7FFF;
			Model = 3442;
			ObjectClass = 4;
			SubClass = 2;
			Level = 5;
			Name = "Zombie Skin Leggings";
			Name2 = "Zombie Skin Leggings";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 65;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Tribal Pants)
*
***************************************************************/

namespace Server.Items
{
	public class TribalPants : Item
	{
		public TribalPants() : base()
		{
			Id = 3287;
			Resistance[0] = 54;
			Bonding = 2;
			SellPrice = 199;
			AvailableClasses = 0x7FFF;
			Model = 28591;
			ObjectClass = 4;
			SubClass = 2;
			Level = 12;
			ReqLevel = 7;
			Name = "Tribal Pants";
			Name2 = "Tribal Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 998;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 45;
			StrBonus = 1;
			AgilityBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Ceremonial Leather Loincloth)
*
***************************************************************/

namespace Server.Items
{
	public class CeremonialLeatherLoincloth : Item
	{
		public CeremonialLeatherLoincloth() : base()
		{
			Id = 3315;
			Resistance[0] = 64;
			Bonding = 2;
			SellPrice = 454;
			AvailableClasses = 0x7FFF;
			Model = 14547;
			ObjectClass = 4;
			SubClass = 2;
			Level = 17;
			ReqLevel = 12;
			Name = "Ceremonial Leather Loincloth";
			Name2 = "Ceremonial Leather Loincloth";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2274;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 50;
			StrBonus = 3;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Harvester's Pants)
*
***************************************************************/

namespace Server.Items
{
	public class HarvestersPants : Item
	{
		public HarvestersPants() : base()
		{
			Id = 3578;
			Resistance[0] = 61;
			Bonding = 1;
			SellPrice = 339;
			AvailableClasses = 0x7FFF;
			Model = 9380;
			ObjectClass = 4;
			SubClass = 2;
			Level = 15;
			Name = "Harvester's Pants";
			Name2 = "Harvester's Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1699;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 45;
			IqBonus = 3;
			AgilityBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Hardened Leather Pants)
*
***************************************************************/

namespace Server.Items
{
	public class HardenedLeatherPants : Item
	{
		public HardenedLeatherPants() : base()
		{
			Id = 3805;
			Resistance[0] = 76;
			SellPrice = 1049;
			AvailableClasses = 0x7FFF;
			Model = 19041;
			ObjectClass = 4;
			SubClass = 2;
			Level = 32;
			ReqLevel = 27;
			Name = "Hardened Leather Pants";
			Name2 = "Hardened Leather Pants";
			AvailableRaces = 0x1FF;
			BuyPrice = 5245;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Thick Leather Pants)
*
***************************************************************/

namespace Server.Items
{
	public class ThickLeatherPants : Item
	{
		public ThickLeatherPants() : base()
		{
			Id = 3966;
			Resistance[0] = 91;
			SellPrice = 2625;
			AvailableClasses = 0x7FFF;
			Model = 17155;
			ObjectClass = 4;
			SubClass = 2;
			Level = 42;
			ReqLevel = 37;
			Name = "Thick Leather Pants";
			Name2 = "Thick Leather Pants";
			AvailableRaces = 0x1FF;
			BuyPrice = 13128;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Smooth Leather Pants)
*
***************************************************************/

namespace Server.Items
{
	public class SmoothLeatherPants : Item
	{
		public SmoothLeatherPants() : base()
		{
			Id = 3974;
			Resistance[0] = 110;
			SellPrice = 5486;
			AvailableClasses = 0x7FFF;
			Model = 16972;
			ObjectClass = 4;
			SubClass = 2;
			Level = 53;
			ReqLevel = 48;
			Name = "Smooth Leather Pants";
			Name2 = "Smooth Leather Pants";
			AvailableRaces = 0x1FF;
			BuyPrice = 27434;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Emblazoned Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class EmblazonedLeggings : Item
	{
		public EmblazonedLeggings() : base()
		{
			Id = 4050;
			Resistance[0] = 83;
			Bonding = 2;
			SellPrice = 2374;
			AvailableClasses = 0x7FFF;
			Model = 17141;
			ObjectClass = 4;
			SubClass = 2;
			Level = 31;
			ReqLevel = 26;
			Name = "Emblazoned Leggings";
			Name2 = "Emblazoned Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11874;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
			StaminaBonus = 8;
			IqBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Insignia Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class InsigniaLeggings : Item
	{
		public InsigniaLeggings() : base()
		{
			Id = 4054;
			Resistance[0] = 89;
			Bonding = 2;
			SellPrice = 3625;
			AvailableClasses = 0x7FFF;
			Model = 17149;
			ObjectClass = 4;
			SubClass = 2;
			Level = 35;
			ReqLevel = 30;
			Name = "Insignia Leggings";
			Name2 = "Insignia Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 18129;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
			AgilityBonus = 9;
			IqBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Glyphed Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class GlyphedLeggings : Item
	{
		public GlyphedLeggings() : base()
		{
			Id = 4060;
			Resistance[0] = 96;
			Bonding = 2;
			SellPrice = 5648;
			AvailableClasses = 0x7FFF;
			Model = 14675;
			ObjectClass = 4;
			SubClass = 2;
			Level = 40;
			ReqLevel = 35;
			Name = "Glyphed Leggings";
			Name2 = "Glyphed Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 28244;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
			StaminaBonus = 11;
			SpiritBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Imperial Leather Pants)
*
***************************************************************/

namespace Server.Items
{
	public class ImperialLeatherPants : Item
	{
		public ImperialLeatherPants() : base()
		{
			Id = 4062;
			Resistance[0] = 106;
			Bonding = 2;
			SellPrice = 8359;
			AvailableClasses = 0x7FFF;
			Model = 17147;
			ObjectClass = 4;
			SubClass = 2;
			Level = 45;
			ReqLevel = 40;
			Name = "Imperial Leather Pants";
			Name2 = "Imperial Leather Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 41795;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
			StaminaBonus = 12;
			IqBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Panther Hunter Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class PantherHunterLeggings : Item
	{
		public PantherHunterLeggings() : base()
		{
			Id = 4108;
			Resistance[0] = 96;
			Bonding = 1;
			SellPrice = 5403;
			AvailableClasses = 0x7FFF;
			Model = 4439;
			ObjectClass = 4;
			SubClass = 2;
			Level = 40;
			Name = "Panther Hunter Leggings";
			Name2 = "Panther Hunter Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 27017;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
			StaminaBonus = 11;
			AgilityBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Feathered Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class FeatheredLeggings : Item
	{
		public FeatheredLeggings() : base()
		{
			Id = 4191;
			Resistance[0] = 34;
			SellPrice = 1029;
			AvailableClasses = 0x7FFF;
			Model = 4497;
			ObjectClass = 4;
			SubClass = 2;
			Level = 27;
			ReqLevel = 22;
			Name = "Feathered Leggings";
			Name2 = "Feathered Leggings";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 5148;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
		}
	}
}


/**************************************************************
*
*				(Embossed Leather Pants)
*
***************************************************************/

namespace Server.Items
{
	public class EmbossedLeatherPants : Item
	{
		public EmbossedLeatherPants() : base()
		{
			Id = 4242;
			Resistance[0] = 61;
			Bonding = 2;
			SellPrice = 347;
			AvailableClasses = 0x7FFF;
			Model = 9505;
			ObjectClass = 4;
			SubClass = 2;
			Level = 15;
			ReqLevel = 10;
			Name = "Embossed Leather Pants";
			Name2 = "Embossed Leather Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1739;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 45;
			StaminaBonus = 2;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Saber Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class SaberLeggings : Item
	{
		public SaberLeggings() : base()
		{
			Id = 4830;
			Resistance[0] = 79;
			Bonding = 2;
			SellPrice = 1894;
			AvailableClasses = 0x7FFF;
			Model = 17153;
			ObjectClass = 4;
			SubClass = 2;
			Level = 28;
			ReqLevel = 23;
			Name = "Saber Leggings";
			Name2 = "Saber Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 9474;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
			AgilityBonus = 7;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Stalking Pants)
*
***************************************************************/

namespace Server.Items
{
	public class StalkingPants : Item
	{
		public StalkingPants() : base()
		{
			Id = 4831;
			Resistance[0] = 76;
			Bonding = 2;
			SellPrice = 1571;
			AvailableClasses = 0x7FFF;
			Model = 17154;
			ObjectClass = 4;
			SubClass = 2;
			Level = 26;
			ReqLevel = 21;
			Name = "Stalking Pants";
			Name2 = "Stalking Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7858;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 60;
			StaminaBonus = 6;
			AgilityBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Mystic Sarong)
*
***************************************************************/

namespace Server.Items
{
	public class MysticSarong : Item
	{
		public MysticSarong() : base()
		{
			Id = 4832;
			Resistance[0] = 80;
			Bonding = 2;
			SellPrice = 2099;
			AvailableClasses = 0x7FFF;
			Model = 22428;
			ObjectClass = 4;
			SubClass = 2;
			Level = 29;
			ReqLevel = 24;
			Name = "Mystic Sarong";
			Name2 = "Mystic Sarong";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 10497;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
			StaminaBonus = 7;
			IqBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Kodo Hunter's Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class KodoHuntersLeggings : Item
	{
		public KodoHuntersLeggings() : base()
		{
			Id = 4909;
			Resistance[0] = 61;
			Bonding = 1;
			SellPrice = 368;
			AvailableClasses = 0x7FFF;
			Model = 7560;
			ObjectClass = 4;
			SubClass = 2;
			Level = 15;
			Name = "Kodo Hunter's Leggings";
			Name2 = "Kodo Hunter's Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1844;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 45;
			AgilityBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Dust-covered Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class DustCoveredLeggings : Item
	{
		public DustCoveredLeggings() : base()
		{
			Id = 4921;
			Resistance[0] = 29;
			Bonding = 1;
			SellPrice = 12;
			AvailableClasses = 0x7FFF;
			Model = 9671;
			ObjectClass = 4;
			SubClass = 2;
			Level = 5;
			Name = "Dust-covered Leggings";
			Name2 = "Dust-covered Leggings";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 63;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Rough-hewn Kodo Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class RoughHewnKodoLeggings : Item
	{
		public RoughHewnKodoLeggings() : base()
		{
			Id = 4970;
			Resistance[0] = 43;
			Bonding = 1;
			SellPrice = 54;
			AvailableClasses = 0x7FFF;
			Model = 16968;
			ObjectClass = 4;
			SubClass = 2;
			Level = 9;
			Name = "Rough-hewn Kodo Leggings";
			Name2 = "Rough-hewn Kodo Leggings";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 271;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Mistspray Kilt)
*
***************************************************************/

namespace Server.Items
{
	public class MistsprayKilt : Item
	{
		public MistsprayKilt() : base()
		{
			Id = 4976;
			Resistance[0] = 96;
			Bonding = 1;
			SellPrice = 5486;
			AvailableClasses = 0x7FFF;
			Model = 28287;
			ObjectClass = 4;
			SubClass = 2;
			Level = 40;
			Name = "Mistspray Kilt";
			Name2 = "Mistspray Kilt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 27431;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
			IqBonus = 16;
		}
	}
}


/**************************************************************
*
*				(Smelting Pants)
*
***************************************************************/

namespace Server.Items
{
	public class SmeltingPants : Item
	{
		public SmeltingPants() : base()
		{
			Id = 5199;
			Resistance[0] = 69;
			Bonding = 1;
			SellPrice = 804;
			AvailableClasses = 0x7FFF;
			Model = 1978;
			ObjectClass = 4;
			SubClass = 2;
			Level = 21;
			ReqLevel = 16;
			Name = "Smelting Pants";
			Name2 = "Smelting Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4024;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 55;
			StaminaBonus = 5;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Greasy Tinker's Pants)
*
***************************************************************/

namespace Server.Items
{
	public class GreasyTinkersPants : Item
	{
		public GreasyTinkersPants() : base()
		{
			Id = 5327;
			Resistance[0] = 65;
			Bonding = 1;
			SellPrice = 519;
			AvailableClasses = 0x7FFF;
			Model = 16958;
			ObjectClass = 4;
			SubClass = 2;
			Level = 18;
			Name = "Greasy Tinker's Pants";
			Name2 = "Greasy Tinker's Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2595;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 50;
			StrBonus = 3;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Canopy Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class CanopyLeggings : Item
	{
		public CanopyLeggings() : base()
		{
			Id = 5398;
			Resistance[0] = 29;
			Bonding = 1;
			SellPrice = 13;
			AvailableClasses = 0x7FFF;
			Model = 16951;
			ObjectClass = 4;
			SubClass = 2;
			Level = 5;
			Name = "Canopy Leggings";
			Name2 = "Canopy Leggings";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 65;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Brambleweed Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class BrambleweedLeggings : Item
	{
		public BrambleweedLeggings() : base()
		{
			Id = 5422;
			Resistance[0] = 68;
			Bonding = 2;
			SellPrice = 692;
			AvailableClasses = 0x7FFF;
			Model = 16974;
			ObjectClass = 4;
			SubClass = 2;
			Level = 20;
			ReqLevel = 15;
			Name = "Brambleweed Leggings";
			Name2 = "Brambleweed Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3460;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 55;
			AgilityBonus = 4;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Vagabond Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class VagabondLeggings : Item
	{
		public VagabondLeggings() : base()
		{
			Id = 5617;
			Resistance[0] = 57;
			Bonding = 1;
			SellPrice = 247;
			AvailableClasses = 0x7FFF;
			Model = 6718;
			ObjectClass = 4;
			SubClass = 2;
			Level = 13;
			Name = "Vagabond Leggings";
			Name2 = "Vagabond Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1235;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 45;
			StrBonus = 2;
			AgilityBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Fine Leather Pants)
*
***************************************************************/

namespace Server.Items
{
	public class FineLeatherPants : Item
	{
		public FineLeatherPants() : base()
		{
			Id = 5958;
			Resistance[0] = 69;
			Bonding = 2;
			SellPrice = 829;
			AvailableClasses = 0x7FFF;
			Model = 9514;
			ObjectClass = 4;
			SubClass = 2;
			Level = 21;
			ReqLevel = 16;
			Name = "Fine Leather Pants";
			Name2 = "Fine Leather Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4145;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 55;
			SpiritBonus = 5;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Dark Leather Pants)
*
***************************************************************/

namespace Server.Items
{
	public class DarkLeatherPants : Item
	{
		public DarkLeatherPants() : base()
		{
			Id = 5961;
			Resistance[0] = 72;
			Bonding = 2;
			SellPrice = 1089;
			AvailableClasses = 0x7FFF;
			Model = 12402;
			ObjectClass = 4;
			SubClass = 2;
			Level = 23;
			ReqLevel = 18;
			Name = "Dark Leather Pants";
			Name2 = "Dark Leather Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5446;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 55;
			AgilityBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Guardian Pants)
*
***************************************************************/

namespace Server.Items
{
	public class GuardianPants : Item
	{
		public GuardianPants() : base()
		{
			Id = 5962;
			Resistance[0] = 85;
			Bonding = 2;
			SellPrice = 2794;
			AvailableClasses = 0x7FFF;
			Model = 9535;
			ObjectClass = 4;
			SubClass = 2;
			Level = 32;
			ReqLevel = 27;
			Name = "Guardian Pants";
			Name2 = "Guardian Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 13972;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
			SpiritBonus = 8;
			IqBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Barbaric Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class BarbaricLeggings : Item
	{
		public BarbaricLeggings() : base()
		{
			Id = 5963;
			Resistance[0] = 87;
			Bonding = 2;
			SellPrice = 3151;
			AvailableClasses = 0x7FFF;
			Model = 17212;
			ObjectClass = 4;
			SubClass = 2;
			Level = 34;
			ReqLevel = 29;
			Name = "Barbaric Leggings";
			Name2 = "Barbaric Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 15756;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
			StaminaBonus = 7;
			IqBonus = 7;
			AgilityBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Primitive Kilt)
*
***************************************************************/

namespace Server.Items
{
	public class TrollPrimitiveKilt : Item
	{
		public TrollPrimitiveKilt() : base()
		{
			Id = 6135;
			Resistance[0] = 14;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 10109;
			ObjectClass = 4;
			SubClass = 2;
			Level = 1;
			ReqLevel = 1;
			Name = "Primitive Kilt";
			Name2 = "Primitive Kilt";
			AvailableRaces = 0x1FF;
			BuyPrice = 5;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Pioneer Trousers)
*
***************************************************************/

namespace Server.Items
{
	public class PioneerTrousers : Item
	{
		public PioneerTrousers() : base()
		{
			Id = 6269;
			Resistance[0] = 54;
			Bonding = 2;
			SellPrice = 193;
			AvailableClasses = 0x7FFF;
			Model = 17152;
			ObjectClass = 4;
			SubClass = 2;
			Level = 12;
			ReqLevel = 7;
			Name = "Pioneer Trousers";
			Name2 = "Pioneer Trousers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 559;
			BuyPrice = 966;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Slick Deviate Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class SlickDeviateLeggings : Item
	{
		public SlickDeviateLeggings() : base()
		{
			Id = 6480;
			Resistance[0] = 68;
			Bonding = 1;
			SellPrice = 713;
			AvailableClasses = 0x7FFF;
			Model = 9541;
			ObjectClass = 4;
			SubClass = 2;
			Level = 20;
			Name = "Slick Deviate Leggings";
			Name2 = "Slick Deviate Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3566;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 55;
			StaminaBonus = 4;
			AgilityBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Bard's Trousers)
*
***************************************************************/

namespace Server.Items
{
	public class BardsTrousers : Item
	{
		public BardsTrousers() : base()
		{
			Id = 6553;
			Resistance[0] = 65;
			Bonding = 2;
			SellPrice = 525;
			AvailableClasses = 0x7FFF;
			Model = 14730;
			ObjectClass = 4;
			SubClass = 2;
			Level = 18;
			ReqLevel = 13;
			Name = "Bard's Trousers";
			Name2 = "Bard's Trousers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 561;
			BuyPrice = 2626;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Scouting Trousers)
*
***************************************************************/

namespace Server.Items
{
	public class ScoutingTrousers : Item
	{
		public ScoutingTrousers() : base()
		{
			Id = 6587;
			Resistance[0] = 73;
			Bonding = 2;
			SellPrice = 1146;
			AvailableClasses = 0x7FFF;
			Model = 14757;
			ObjectClass = 4;
			SubClass = 2;
			Level = 24;
			ReqLevel = 19;
			Name = "Scouting Trousers";
			Name2 = "Scouting Trousers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 563;
			BuyPrice = 5732;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Dervish Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class DervishLeggings : Item
	{
		public DervishLeggings() : base()
		{
			Id = 6607;
			Resistance[0] = 82;
			Bonding = 2;
			SellPrice = 2202;
			AvailableClasses = 0x7FFF;
			Model = 14776;
			ObjectClass = 4;
			SubClass = 2;
			Level = 30;
			ReqLevel = 25;
			Name = "Dervish Leggings";
			Name2 = "Dervish Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 565;
			BuyPrice = 11012;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Ferine Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class FerineLeggings : Item
	{
		public FerineLeggings() : base()
		{
			Id = 6690;
			Resistance[0] = 87;
			Bonding = 1;
			SellPrice = 3346;
			AvailableClasses = 0x7FFF;
			Model = 17142;
			ObjectClass = 4;
			SubClass = 2;
			Level = 34;
			ReqLevel = 29;
			Name = "Ferine Leggings";
			Name2 = "Ferine Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 16731;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
			StrBonus = 9;
			AgilityBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Rugged Leather Pants)
*
***************************************************************/

namespace Server.Items
{
	public class RuggedLeatherPants : Item
	{
		public RuggedLeatherPants() : base()
		{
			Id = 7280;
			Resistance[0] = 51;
			Bonding = 2;
			SellPrice = 162;
			AvailableClasses = 0x7FFF;
			Model = 17232;
			ObjectClass = 4;
			SubClass = 2;
			Level = 11;
			ReqLevel = 6;
			Name = "Rugged Leather Pants";
			Name2 = "Rugged Leather Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 814;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 40;
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Light Leather Pants)
*
***************************************************************/

namespace Server.Items
{
	public class LightLeatherPants : Item
	{
		public LightLeatherPants() : base()
		{
			Id = 7282;
			Resistance[0] = 66;
			Bonding = 2;
			SellPrice = 599;
			AvailableClasses = 0x7FFF;
			Model = 3248;
			ObjectClass = 4;
			SubClass = 2;
			Level = 19;
			ReqLevel = 14;
			Name = "Light Leather Pants";
			Name2 = "Light Leather Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2998;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 50;
			AgilityBonus = 5;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Dusky Leather Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class DuskyLeatherLeggings : Item
	{
		public DuskyLeatherLeggings() : base()
		{
			Id = 7373;
			Resistance[0] = 86;
			Bonding = 2;
			SellPrice = 3097;
			AvailableClasses = 0x7FFF;
			Model = 14777;
			ObjectClass = 4;
			SubClass = 2;
			Level = 33;
			ReqLevel = 28;
			Name = "Dusky Leather Leggings";
			Name2 = "Dusky Leather Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 15485;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
			AgilityBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Infiltrator Pants)
*
***************************************************************/

namespace Server.Items
{
	public class InfiltratorPants : Item
	{
		public InfiltratorPants() : base()
		{
			Id = 7414;
			Resistance[0] = 87;
			Bonding = 2;
			SellPrice = 3175;
			AvailableClasses = 0x7FFF;
			Model = 21901;
			ObjectClass = 4;
			SubClass = 2;
			Level = 34;
			ReqLevel = 29;
			Name = "Infiltrator Pants";
			Name2 = "Infiltrator Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 567;
			BuyPrice = 15879;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Sentinel Trousers)
*
***************************************************************/

namespace Server.Items
{
	public class SentinelTrousers : Item
	{
		public SentinelTrousers() : base()
		{
			Id = 7440;
			Resistance[0] = 95;
			Bonding = 2;
			SellPrice = 5042;
			AvailableClasses = 0x7FFF;
			Model = 15001;
			ObjectClass = 4;
			SubClass = 2;
			Level = 39;
			ReqLevel = 34;
			Name = "Sentinel Trousers";
			Name2 = "Sentinel Trousers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 568;
			BuyPrice = 25212;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Ranger Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class RangerLeggings : Item
	{
		public RangerLeggings() : base()
		{
			Id = 7478;
			Resistance[0] = 103;
			Bonding = 2;
			SellPrice = 6991;
			AvailableClasses = 0x7FFF;
			Model = 15020;
			ObjectClass = 4;
			SubClass = 2;
			Level = 43;
			ReqLevel = 38;
			Name = "Ranger Leggings";
			Name2 = "Ranger Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 570;
			BuyPrice = 34958;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Cabalist Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class CabalistLeggings : Item
	{
		public CabalistLeggings() : base()
		{
			Id = 7528;
			Resistance[0] = 112;
			Bonding = 2;
			SellPrice = 9894;
			AvailableClasses = 0x7FFF;
			Model = 15416;
			ObjectClass = 4;
			SubClass = 2;
			Level = 48;
			ReqLevel = 43;
			Name = "Cabalist Leggings";
			Name2 = "Cabalist Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 571;
			BuyPrice = 49471;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Warchief Kilt)
*
***************************************************************/

namespace Server.Items
{
	public class WarchiefKilt : Item
	{
		public WarchiefKilt() : base()
		{
			Id = 7760;
			Resistance[0] = 105;
			Bonding = 2;
			SellPrice = 6074;
			AvailableClasses = 0x7FFF;
			Model = 21404;
			ObjectClass = 4;
			SubClass = 2;
			Level = 39;
			ReqLevel = 34;
			Name = "Warchief Kilt";
			Name2 = "Warchief Kilt";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 30371;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 75;
			SpiritBonus = 6;
			IqBonus = 19;
			StrBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Ninja Pants)
*
***************************************************************/

namespace Server.Items
{
	public class NinjaPants : Item
	{
		public NinjaPants() : base()
		{
			Id = 7949;
			Resistance[0] = 40;
			Bonding = 1;
			SellPrice = 2252;
			AvailableClasses = 0x7FFF;
			Model = 16133;
			ObjectClass = 4;
			SubClass = 2;
			Level = 30;
			Name = "Ninja Pants";
			Name2 = "Ninja Pants";
			Resistance[3] = 1;
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11261;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
		}
	}
}


/**************************************************************
*
*				(Heraldic Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class HeraldicLeggings : Item
	{
		public HeraldicLeggings() : base()
		{
			Id = 8123;
			Resistance[0] = 114;
			Bonding = 2;
			SellPrice = 11275;
			AvailableClasses = 0x7FFF;
			Model = 14697;
			ObjectClass = 4;
			SubClass = 2;
			Level = 49;
			ReqLevel = 44;
			Name = "Heraldic Leggings";
			Name2 = "Heraldic Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 56379;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
			AgilityBonus = 14;
			IqBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Nightscape Pants)
*
***************************************************************/

namespace Server.Items
{
	public class NightscapePants : Item
	{
		public NightscapePants() : base()
		{
			Id = 8193;
			Resistance[0] = 108;
			Bonding = 2;
			SellPrice = 8708;
			AvailableClasses = 0x7FFF;
			Model = 17151;
			ObjectClass = 4;
			SubClass = 2;
			Level = 46;
			ReqLevel = 41;
			Name = "Nightscape Pants";
			Name2 = "Nightscape Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 43542;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
			AgilityBonus = 16;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Big Voodoo Pants)
*
***************************************************************/

namespace Server.Items
{
	public class BigVoodooPants : Item
	{
		public BigVoodooPants() : base()
		{
			Id = 8202;
			Resistance[0] = 110;
			Bonding = 2;
			SellPrice = 9022;
			AvailableClasses = 0x7FFF;
			Model = 16510;
			ObjectClass = 4;
			SubClass = 2;
			Level = 47;
			ReqLevel = 42;
			Name = "Big Voodoo Pants";
			Name2 = "Big Voodoo Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 45112;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
			IqBonus = 15;
			SpiritBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Wild Leather Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class WildLeatherLeggings : Item
	{
		public WildLeatherLeggings() : base()
		{
			Id = 8212;
			Resistance[0] = 116;
			Bonding = 2;
			SellPrice = 11585;
			AvailableClasses = 0x7FFF;
			Model = 18935;
			ObjectClass = 4;
			SubClass = 2;
			Level = 50;
			ReqLevel = 45;
			Name = "Wild Leather Leggings";
			Name2 = "Wild Leather Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 572;
			BuyPrice = 57925;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Serpentskin Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class SerpentskinLeggings : Item
	{
		public SerpentskinLeggings() : base()
		{
			Id = 8262;
			Resistance[0] = 124;
			Bonding = 2;
			SellPrice = 14605;
			AvailableClasses = 0x7FFF;
			Model = 17265;
			ObjectClass = 4;
			SubClass = 2;
			Level = 54;
			ReqLevel = 49;
			Name = "Serpentskin Leggings";
			Name2 = "Serpentskin Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 73029;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
			StrBonus = 13;
			StaminaBonus = 5;
			AgilityBonus = 16;
		}
	}
}


/**************************************************************
*
*				(Traveler's Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class TravelersLeggings : Item
	{
		public TravelersLeggings() : base()
		{
			Id = 8300;
			Resistance[0] = 135;
			Bonding = 2;
			SellPrice = 20172;
			AvailableClasses = 0x7FFF;
			Model = 17313;
			ObjectClass = 4;
			SubClass = 2;
			Level = 60;
			ReqLevel = 55;
			Name = "Traveler's Leggings";
			Name2 = "Traveler's Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 100862;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
			StrBonus = 17;
			AgilityBonus = 17;
		}
	}
}


/**************************************************************
*
*				(Earthborn Kilt)
*
***************************************************************/

namespace Server.Items
{
	public class EarthbornKilt : Item
	{
		public EarthbornKilt() : base()
		{
			Id = 9402;
			Resistance[0] = 148;
			Bonding = 2;
			SellPrice = 25308;
			AvailableClasses = 0x7FFF;
			Model = 21403;
			ObjectClass = 4;
			SubClass = 2;
			Level = 60;
			ReqLevel = 55;
			Name = "Earthborn Kilt";
			Name2 = "Earthborn Kilt";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 126543;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 75;
			IqBonus = 29;
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Oilskin Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class OilskinLeggings : Item
	{
		public OilskinLeggings() : base()
		{
			Id = 9414;
			Resistance[0] = 108;
			Bonding = 1;
			SellPrice = 8645;
			AvailableClasses = 0x7FFF;
			Model = 18434;
			ObjectClass = 4;
			SubClass = 2;
			Level = 46;
			ReqLevel = 41;
			Name = "Oilskin Leggings";
			Name2 = "Oilskin Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 43227;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
			AgilityBonus = 13;
			IqBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Jinxed Hoodoo Kilt)
*
***************************************************************/

namespace Server.Items
{
	public class JinxedHoodooKilt : Item
	{
		public JinxedHoodooKilt() : base()
		{
			Id = 9474;
			Resistance[0] = 126;
			Bonding = 1;
			SellPrice = 13290;
			AvailableClasses = 0x7FFF;
			Model = 18387;
			ObjectClass = 4;
			SubClass = 2;
			Level = 49;
			ReqLevel = 44;
			Name = "Jinxed Hoodoo Kilt";
			Name2 = "Jinxed Hoodoo Kilt";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 66450;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 75;
			IqBonus = 24;
			SpiritBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Petrolspill Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class PetrolspillLeggings : Item
	{
		public PetrolspillLeggings() : base()
		{
			Id = 9509;
			Resistance[0] = 90;
			Bonding = 2;
			SellPrice = 2683;
			AvailableClasses = 0x7FFF;
			Description = "Keep away from fire.";
			Model = 18429;
			ObjectClass = 4;
			SubClass = 2;
			Level = 30;
			ReqLevel = 25;
			Name = "Petrolspill Leggings";
			Name2 = "Petrolspill Leggings";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 13416;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 75;
			AgilityBonus = 14;
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Triprunner Dungarees)
*
***************************************************************/

namespace Server.Items
{
	public class TriprunnerDungarees : Item
	{
		public TriprunnerDungarees() : base()
		{
			Id = 9624;
			Resistance[0] = 101;
			Bonding = 1;
			SellPrice = 5267;
			AvailableClasses = 0x7FFF;
			Model = 28195;
			ObjectClass = 4;
			SubClass = 2;
			Level = 37;
			Name = "Triprunner Dungarees";
			Name2 = "Triprunner Dungarees";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 26338;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 75;
			StaminaBonus = 6;
			AgilityBonus = 18;
			StrBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Gryphon Rider's Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class GryphonRidersLeggings : Item
	{
		public GryphonRidersLeggings() : base()
		{
			Id = 9652;
			Resistance[0] = 122;
			Bonding = 1;
			SellPrice = 13466;
			AvailableClasses = 0x7FFF;
			Model = 17150;
			ObjectClass = 4;
			SubClass = 2;
			Level = 53;
			Name = "Gryphon Rider's Leggings";
			Name2 = "Gryphon Rider's Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 67330;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
			StrBonus = 15;
			AgilityBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Gypsy Trousers)
*
***************************************************************/

namespace Server.Items
{
	public class GypsyTrousers : Item
	{
		public GypsyTrousers() : base()
		{
			Id = 9756;
			Resistance[0] = 60;
			Bonding = 2;
			SellPrice = 294;
			AvailableClasses = 0x7FFF;
			Model = 19030;
			ObjectClass = 4;
			SubClass = 2;
			Level = 14;
			ReqLevel = 9;
			Name = "Gypsy Trousers";
			Name2 = "Gypsy Trousers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 560;
			BuyPrice = 1471;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Bandit Pants)
*
***************************************************************/

namespace Server.Items
{
	public class BanditPants : Item
	{
		public BanditPants() : base()
		{
			Id = 9781;
			Resistance[0] = 71;
			Bonding = 2;
			SellPrice = 982;
			AvailableClasses = 0x7FFF;
			Model = 28431;
			ObjectClass = 4;
			SubClass = 2;
			Level = 22;
			ReqLevel = 17;
			Name = "Bandit Pants";
			Name2 = "Bandit Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 563;
			BuyPrice = 4910;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Superior Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class SuperiorLeggings : Item
	{
		public SuperiorLeggings() : base()
		{
			Id = 9808;
			Resistance[0] = 79;
			Bonding = 2;
			SellPrice = 1848;
			AvailableClasses = 0x7FFF;
			Model = 691;
			ObjectClass = 4;
			SubClass = 2;
			Level = 28;
			ReqLevel = 23;
			Name = "Superior Leggings";
			Name2 = "Superior Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 565;
			BuyPrice = 9242;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Scaled Leather Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class ScaledLeatherLeggings : Item
	{
		public ScaledLeatherLeggings() : base()
		{
			Id = 9833;
			Resistance[0] = 86;
			Bonding = 2;
			SellPrice = 3031;
			AvailableClasses = 0x7FFF;
			Model = 6772;
			ObjectClass = 4;
			SubClass = 2;
			Level = 33;
			ReqLevel = 28;
			Name = "Scaled Leather Leggings";
			Name2 = "Scaled Leather Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 566;
			BuyPrice = 15157;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Archer's Trousers)
*
***************************************************************/

namespace Server.Items
{
	public class ArchersTrousers : Item
	{
		public ArchersTrousers() : base()
		{
			Id = 9862;
			Resistance[0] = 92;
			Bonding = 2;
			SellPrice = 4260;
			AvailableClasses = 0x7FFF;
			Model = 14635;
			ObjectClass = 4;
			SubClass = 2;
			Level = 37;
			ReqLevel = 32;
			Name = "Archer's Trousers";
			Name2 = "Archer's Trousers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 568;
			BuyPrice = 21302;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Huntsman's Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class HuntsmansLeggings : Item
	{
		public HuntsmansLeggings() : base()
		{
			Id = 9893;
			Resistance[0] = 101;
			Bonding = 2;
			SellPrice = 6689;
			AvailableClasses = 0x7FFF;
			Model = 27807;
			ObjectClass = 4;
			SubClass = 2;
			Level = 42;
			ReqLevel = 37;
			Name = "Huntsman's Leggings";
			Name2 = "Huntsman's Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 569;
			BuyPrice = 33448;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Tracker's Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class TrackersLeggings : Item
	{
		public TrackersLeggings() : base()
		{
			Id = 9922;
			Resistance[0] = 108;
			Bonding = 2;
			SellPrice = 8745;
			AvailableClasses = 0x7FFF;
			Model = 18935;
			ObjectClass = 4;
			SubClass = 2;
			Level = 46;
			ReqLevel = 41;
			Name = "Tracker's Leggings";
			Name2 = "Tracker's Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 571;
			BuyPrice = 43726;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Chieftain's Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class ChieftainsLeggings : Item
	{
		public ChieftainsLeggings() : base()
		{
			Id = 9954;
			Resistance[0] = 118;
			Bonding = 2;
			SellPrice = 12125;
			AvailableClasses = 0x7FFF;
			Model = 18947;
			ObjectClass = 4;
			SubClass = 2;
			Level = 51;
			ReqLevel = 46;
			Name = "Chieftain's Leggings";
			Name2 = "Chieftain's Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 572;
			BuyPrice = 60629;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Righteous Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class RighteousLeggings : Item
	{
		public RighteousLeggings() : base()
		{
			Id = 10074;
			Resistance[0] = 122;
			Bonding = 2;
			SellPrice = 13985;
			AvailableClasses = 0x7FFF;
			Model = 19018;
			ObjectClass = 4;
			SubClass = 2;
			Level = 53;
			ReqLevel = 48;
			Name = "Righteous Leggings";
			Name2 = "Righteous Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 573;
			BuyPrice = 69928;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Wanderer's Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class WanderersLeggings : Item
	{
		public WanderersLeggings() : base()
		{
			Id = 10112;
			Resistance[0] = 131;
			Bonding = 2;
			SellPrice = 19071;
			AvailableClasses = 0x7FFF;
			Model = 27731;
			ObjectClass = 4;
			SubClass = 2;
			Level = 58;
			ReqLevel = 53;
			Name = "Wanderer's Leggings";
			Name2 = "Wanderer's Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 575;
			BuyPrice = 95356;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Mighty Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class MightyLeggings : Item
	{
		public MightyLeggings() : base()
		{
			Id = 10152;
			Resistance[0] = 140;
			Bonding = 2;
			SellPrice = 24333;
			AvailableClasses = 0x7FFF;
			Model = 18962;
			ObjectClass = 4;
			SubClass = 2;
			Level = 63;
			ReqLevel = 58;
			Name = "Mighty Leggings";
			Name2 = "Mighty Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 576;
			BuyPrice = 121666;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Swashbuckler's Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class SwashbucklersLeggings : Item
	{
		public SwashbucklersLeggings() : base()
		{
			Id = 10188;
			Resistance[0] = 127;
			Bonding = 2;
			SellPrice = 16717;
			AvailableClasses = 0x7FFF;
			Model = 17137;
			ObjectClass = 4;
			SubClass = 2;
			Level = 56;
			ReqLevel = 51;
			Name = "Swashbuckler's Leggings";
			Name2 = "Swashbuckler's Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 574;
			BuyPrice = 83587;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Nightshade Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class NightshadeLeggings : Item
	{
		public NightshadeLeggings() : base()
		{
			Id = 10227;
			Resistance[0] = 138;
			Bonding = 2;
			SellPrice = 23348;
			AvailableClasses = 0x7FFF;
			Model = 18982;
			ObjectClass = 4;
			SubClass = 2;
			Level = 62;
			ReqLevel = 57;
			Name = "Nightshade Leggings";
			Name2 = "Nightshade Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 576;
			BuyPrice = 116741;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Adventurer's Legguards)
*
***************************************************************/

namespace Server.Items
{
	public class AdventurersLegguards : Item
	{
		public AdventurersLegguards() : base()
		{
			Id = 10262;
			Resistance[0] = 142;
			Bonding = 2;
			SellPrice = 25272;
			AvailableClasses = 0x7FFF;
			Model = 27843;
			ObjectClass = 4;
			SubClass = 2;
			Level = 64;
			ReqLevel = 59;
			Name = "Adventurer's Legguards";
			Name2 = "Adventurer's Legguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 577;
			BuyPrice = 126364;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Blackened Defias Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class BlackenedDefiasLeggings : Item
	{
		public BlackenedDefiasLeggings() : base()
		{
			Id = 10400;
			Resistance[0] = 65;
			Bonding = 2;
			SellPrice = 563;
			AvailableClasses = 0x7FFF;
			Model = 27947;
			ObjectClass = 4;
			SubClass = 2;
			Level = 18;
			ReqLevel = 13;
			Name = "Blackened Defias Leggings";
			Name2 = "Blackened Defias Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2817;
			Sets = 161;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 50;
			StrBonus = 3;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Leggings of the Fang)
*
***************************************************************/

namespace Server.Items
{
	public class LeggingsOfTheFang : Item
	{
		public LeggingsOfTheFang() : base()
		{
			Id = 10410;
			Resistance[0] = 79;
			Bonding = 1;
			SellPrice = 1256;
			AvailableClasses = 0x7FFF;
			Model = 28385;
			ObjectClass = 4;
			SubClass = 2;
			Level = 23;
			ReqLevel = 18;
			Name = "Leggings of the Fang";
			Name2 = "Leggings of the Fang";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 6280;
			Sets = 162;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
			StrBonus = 5;
			StaminaBonus = 4;
			AgilityBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Atal'ai Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class AtalaiLeggings : Item
	{
		public AtalaiLeggings() : base()
		{
			Id = 10785;
			Resistance[0] = 120;
			Bonding = 1;
			SellPrice = 13200;
			AvailableClasses = 0x7FFF;
			Model = 14776;
			ObjectClass = 4;
			SubClass = 2;
			Level = 52;
			ReqLevel = 47;
			Name = "Atal'ai Leggings";
			Name2 = "Atal'ai Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 573;
			BuyPrice = 66003;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Windscale Sarong)
*
***************************************************************/

namespace Server.Items
{
	public class WindscaleSarong : Item
	{
		public WindscaleSarong() : base()
		{
			Id = 10842;
			Resistance[0] = 136;
			Bonding = 1;
			SellPrice = 17595;
			AvailableClasses = 0x7FFF;
			Model = 22427;
			ObjectClass = 4;
			SubClass = 2;
			Level = 54;
			ReqLevel = 49;
			Name = "Windscale Sarong";
			Name2 = "Windscale Sarong";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 87976;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 75;
			IqBonus = 20;
			StaminaBonus = 10;
			SpiritBonus = 10;
			AgilityBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Warstrife Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class WarstrifeLeggings : Item
	{
		public WarstrifeLeggings() : base()
		{
			Id = 11821;
			Resistance[0] = 144;
			Bonding = 1;
			SellPrice = 22384;
			AvailableClasses = 0x7FFF;
			Model = 28623;
			ObjectClass = 4;
			SubClass = 2;
			Level = 58;
			ReqLevel = 53;
			Name = "Warstrife Leggings";
			Name2 = "Warstrife Leggings";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 111924;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 75;
			SetSpell( 13670 , 1 , 0 , -1 , 0 , -1 );
			StrBonus = 6;
			StaminaBonus = 12;
			AgilityBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Luminary Kilt)
*
***************************************************************/

namespace Server.Items
{
	public class LuminaryKilt : Item
	{
		public LuminaryKilt() : base()
		{
			Id = 11823;
			Resistance[0] = 133;
			Bonding = 1;
			SellPrice = 19730;
			AvailableClasses = 0x7FFF;
			Model = 28728;
			ObjectClass = 4;
			SubClass = 2;
			Level = 59;
			ReqLevel = 54;
			Name = "Luminary Kilt";
			Name2 = "Luminary Kilt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 98654;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
			SpiritBonus = 17;
			IqBonus = 17;
		}
	}
}


/**************************************************************
*
*				(Windshear Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class WindshearLeggings : Item
	{
		public WindshearLeggings() : base()
		{
			Id = 12041;
			Resistance[0] = 124;
			Bonding = 1;
			SellPrice = 14446;
			AvailableClasses = 0x7FFF;
			Model = 28429;
			ObjectClass = 4;
			SubClass = 2;
			Level = 54;
			Name = "Windshear Leggings";
			Name2 = "Windshear Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 72233;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
			StaminaBonus = 4;
			AgilityBonus = 14;
			IqBonus = 16;
		}
	}
}


/**************************************************************
*
*				(Leggings of Arcana)
*
***************************************************************/

namespace Server.Items
{
	public class LeggingsOfArcana : Item
	{
		public LeggingsOfArcana() : base()
		{
			Id = 12756;
			Resistance[0] = 166;
			Bonding = 1;
			SellPrice = 35057;
			AvailableClasses = 0x7FFF;
			Model = 23199;
			ObjectClass = 4;
			SubClass = 2;
			Level = 62;
			Name = "Leggings of Arcana";
			Name2 = "Leggings of Arcana";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 175287;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 90;
			SetSpell( 9346 , 1 , 0 , -1 , 0 , -1 );
			IqBonus = 30;
			SpiritBonus = 20;
		}
	}
}


/**************************************************************
*
*				(Blademaster Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class BlademasterLeggings : Item
	{
		public BlademasterLeggings() : base()
		{
			Id = 12963;
			Resistance[0] = 154;
			Bonding = 1;
			SellPrice = 27717;
			AvailableClasses = 0x7FFF;
			Model = 23547;
			ObjectClass = 4;
			SubClass = 2;
			Level = 63;
			ReqLevel = 58;
			Name = "Blademaster Leggings";
			Name2 = "Blademaster Leggings";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 138586;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 75;
			SetSpell( 15464 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 13670 , 1 , 0 , -1 , 0 , -1 );
			AgilityBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Troll's Bane Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class TrollsBaneLeggings : Item
	{
		public TrollsBaneLeggings() : base()
		{
			Id = 13114;
			Resistance[0] = 90;
			Bonding = 2;
			SellPrice = 2574;
			AvailableClasses = 0x7FFF;
			Model = 17031;
			ObjectClass = 4;
			SubClass = 2;
			Level = 30;
			ReqLevel = 25;
			Name = "Troll's Bane Leggings";
			Name2 = "Troll's Bane Leggings";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 12870;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 75;
			AgilityBonus = 14;
			IqBonus = 4;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Tressermane Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class TressermaneLeggings : Item
	{
		public TressermaneLeggings() : base()
		{
			Id = 13169;
			Resistance[0] = 148;
			Bonding = 1;
			SellPrice = 23948;
			AvailableClasses = 0x7FFF;
			Model = 23710;
			ObjectClass = 4;
			SubClass = 2;
			Level = 60;
			ReqLevel = 55;
			Name = "Tressermane Leggings";
			Name2 = "Tressermane Leggings";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 119741;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 75;
			IqBonus = 23;
			StaminaBonus = 12;
			SpiritBonus = 14;
		}
	}
}


/**************************************************************
*
*				(Crypt Stalker Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class CryptStalkerLeggings : Item
	{
		public CryptStalkerLeggings() : base()
		{
			Id = 13531;
			Resistance[0] = 136;
			Bonding = 1;
			SellPrice = 21191;
			AvailableClasses = 0x7FFF;
			Model = 24182;
			ObjectClass = 4;
			SubClass = 2;
			Level = 61;
			ReqLevel = 56;
			Name = "Crypt Stalker Leggings";
			Name2 = "Crypt Stalker Leggings";
			Resistance[3] = 18;
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 105959;
			Resistance[5] = 18;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Ghostloom Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class GhostloomLeggings : Item
	{
		public GhostloomLeggings() : base()
		{
			Id = 14545;
			Resistance[0] = 152;
			Bonding = 1;
			SellPrice = 26397;
			AvailableClasses = 0x7FFF;
			Model = 25169;
			ObjectClass = 4;
			SubClass = 2;
			Level = 62;
			ReqLevel = 57;
			Name = "Ghostloom Leggings";
			Name2 = "Ghostloom Leggings";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 131987;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 75;
			SetSpell( 21627 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 18;
			IqBonus = 13;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Prospector's Woolies)
*
***************************************************************/

namespace Server.Items
{
	public class ProspectorsWoolies : Item
	{
		public ProspectorsWoolies() : base()
		{
			Id = 14565;
			Resistance[0] = 69;
			Bonding = 2;
			SellPrice = 809;
			AvailableClasses = 0x7FFF;
			Model = 27522;
			ObjectClass = 4;
			SubClass = 2;
			Level = 21;
			ReqLevel = 16;
			Name = "Prospector's Woolies";
			Name2 = "Prospector's Woolies";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4045;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 55;
			AgilityBonus = 6;
			StrBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Bristlebark Britches)
*
***************************************************************/

namespace Server.Items
{
	public class BristlebarkBritches : Item
	{
		public BristlebarkBritches() : base()
		{
			Id = 14574;
			Resistance[0] = 76;
			Bonding = 2;
			SellPrice = 1568;
			AvailableClasses = 0x7FFF;
			Model = 27670;
			ObjectClass = 4;
			SubClass = 2;
			Level = 26;
			ReqLevel = 21;
			Name = "Bristlebark Britches";
			Name2 = "Bristlebark Britches";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7840;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 60;
			AgilityBonus = 8;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Dokebi Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class DokebiLeggings : Item
	{
		public DokebiLeggings() : base()
		{
			Id = 14585;
			Resistance[0] = 85;
			Bonding = 2;
			SellPrice = 2687;
			AvailableClasses = 0x7FFF;
			Model = 27967;
			ObjectClass = 4;
			SubClass = 2;
			Level = 32;
			ReqLevel = 27;
			Name = "Dokebi Leggings";
			Name2 = "Dokebi Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 13438;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
			IqBonus = 8;
			SpiritBonus = 7;
			StrBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Hawkeye's Breeches)
*
***************************************************************/

namespace Server.Items
{
	public class HawkeyesBreeches : Item
	{
		public HawkeyesBreeches() : base()
		{
			Id = 14595;
			Resistance[0] = 93;
			Bonding = 2;
			SellPrice = 4500;
			AvailableClasses = 0x7FFF;
			Model = 27975;
			ObjectClass = 4;
			SubClass = 2;
			Level = 38;
			ReqLevel = 33;
			Name = "Hawkeye's Breeches";
			Name2 = "Hawkeye's Breeches";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 22502;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
			AgilityBonus = 14;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Warden's Woolies)
*
***************************************************************/

namespace Server.Items
{
	public class WardensWoolies : Item
	{
		public WardensWoolies() : base()
		{
			Id = 14605;
			Resistance[0] = 103;
			Bonding = 2;
			SellPrice = 6868;
			AvailableClasses = 0x7FFF;
			Model = 27984;
			ObjectClass = 4;
			SubClass = 2;
			Level = 43;
			ReqLevel = 38;
			Name = "Warden's Woolies";
			Name2 = "Warden's Woolies";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 34340;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
			SpiritBonus = 12;
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Cadaverous Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class CadaverousLeggings : Item
	{
		public CadaverousLeggings() : base()
		{
			Id = 14638;
			Resistance[0] = 136;
			Bonding = 1;
			SellPrice = 20954;
			AvailableClasses = 0x7FFF;
			Model = 26966;
			ObjectClass = 4;
			SubClass = 2;
			Level = 61;
			ReqLevel = 56;
			Name = "Cadaverous Leggings";
			Name2 = "Cadaverous Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 104773;
			Sets = 121;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
			StaminaBonus = 18;
			AgilityBonus = 12;
			StrBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Scorpashi Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class ScorpashiLeggings : Item
	{
		public ScorpashiLeggings() : base()
		{
			Id = 14659;
			Resistance[0] = 110;
			Bonding = 2;
			SellPrice = 9382;
			AvailableClasses = 0x7FFF;
			Model = 27578;
			ObjectClass = 4;
			SubClass = 2;
			Level = 47;
			ReqLevel = 42;
			Name = "Scorpashi Leggings";
			Name2 = "Scorpashi Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 46912;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
			AgilityBonus = 15;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Keeper's Woolies)
*
***************************************************************/

namespace Server.Items
{
	public class KeepersWoolies : Item
	{
		public KeepersWoolies() : base()
		{
			Id = 14668;
			Resistance[0] = 120;
			Bonding = 2;
			SellPrice = 13596;
			AvailableClasses = 0x7FFF;
			Model = 27570;
			ObjectClass = 4;
			SubClass = 2;
			Level = 52;
			ReqLevel = 47;
			Name = "Keeper's Woolies";
			Name2 = "Keeper's Woolies";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 67984;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
			AgilityBonus = 19;
			StaminaBonus = 7;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Pridelord Pants)
*
***************************************************************/

namespace Server.Items
{
	public class PridelordPants : Item
	{
		public PridelordPants() : base()
		{
			Id = 14677;
			Resistance[0] = 131;
			Bonding = 2;
			SellPrice = 18524;
			AvailableClasses = 0x7FFF;
			Model = 27651;
			ObjectClass = 4;
			SubClass = 2;
			Level = 58;
			ReqLevel = 53;
			Name = "Pridelord Pants";
			Name2 = "Pridelord Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 92621;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
			AgilityBonus = 23;
			StaminaBonus = 4;
			StrBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Indomitable Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class IndomitableLeggings : Item
	{
		public IndomitableLeggings() : base()
		{
			Id = 14687;
			Resistance[0] = 138;
			Bonding = 2;
			SellPrice = 23357;
			AvailableClasses = 0x7FFF;
			Model = 17265;
			ObjectClass = 4;
			SubClass = 2;
			Level = 62;
			ReqLevel = 57;
			Name = "Indomitable Leggings";
			Name2 = "Indomitable Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 116787;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
			SpiritBonus = 18;
			StaminaBonus = 15;
			IqBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Primal Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class PrimalLeggings : Item
	{
		public PrimalLeggings() : base()
		{
			Id = 15009;
			Resistance[0] = 51;
			Bonding = 2;
			SellPrice = 162;
			AvailableClasses = 0x7FFF;
			Model = 28008;
			ObjectClass = 4;
			SubClass = 2;
			Level = 11;
			ReqLevel = 6;
			Name = "Primal Leggings";
			Name2 = "Primal Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 559;
			BuyPrice = 812;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Lupine Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class LupineLeggings : Item
	{
		public LupineLeggings() : base()
		{
			Id = 15017;
			Resistance[0] = 66;
			Bonding = 2;
			SellPrice = 611;
			AvailableClasses = 0x7FFF;
			Model = 27991;
			ObjectClass = 4;
			SubClass = 2;
			Level = 19;
			ReqLevel = 14;
			Name = "Lupine Leggings";
			Name2 = "Lupine Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 562;
			BuyPrice = 3059;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Volcanic Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class VolcanicLeggings : Item
	{
		public VolcanicLeggings() : base()
		{
			Id = 15054;
			Resistance[0] = 204;
			Bonding = 2;
			SellPrice = 14559;
			AvailableClasses = 0x7FFF;
			Model = 25683;
			Resistance[2] = 20;
			ObjectClass = 4;
			SubClass = 2;
			Level = 54;
			ReqLevel = 49;
			Name = "Volcanic Leggings";
			Name2 = "Volcanic Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 72799;
			Sets = 141;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Stormshroud Pants)
*
***************************************************************/

namespace Server.Items
{
	public class StormshroudPants : Item
	{
		public StormshroudPants() : base()
		{
			Id = 15057;
			Resistance[0] = 138;
			Bonding = 2;
			SellPrice = 18728;
			AvailableClasses = 0x7FFF;
			Model = 25686;
			ObjectClass = 4;
			SubClass = 2;
			Level = 55;
			ReqLevel = 50;
			Name = "Stormshroud Pants";
			Name2 = "Stormshroud Pants";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 93642;
			Sets = 142;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 75;
			SetSpell( 7598 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 13669 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Living Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class LivingLeggings : Item
	{
		public LivingLeggings() : base()
		{
			Id = 15060;
			Resistance[0] = 142;
			Bonding = 2;
			SellPrice = 21277;
			AvailableClasses = 0x7FFF;
			Model = 25694;
			ObjectClass = 4;
			SubClass = 2;
			Level = 57;
			ReqLevel = 52;
			Name = "Living Leggings";
			Name2 = "Living Leggings";
			Resistance[3] = 5;
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 106387;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 75;
			SetSpell( 9315 , 1 , 0 , -1 , 0 , -1 );
			IqBonus = 25;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Devilsaur Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class DevilsaurLeggings : Item
	{
		public DevilsaurLeggings() : base()
		{
			Id = 15062;
			Resistance[0] = 148;
			Bonding = 2;
			SellPrice = 25709;
			AvailableClasses = 0x7FFF;
			Model = 26071;
			ObjectClass = 4;
			SubClass = 2;
			Level = 60;
			ReqLevel = 55;
			Name = "Devilsaur Leggings";
			Name2 = "Devilsaur Leggings";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 128545;
			Sets = 143;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 75;
			SetSpell( 15811 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Warbear Woolies)
*
***************************************************************/

namespace Server.Items
{
	public class WarbearWoolies : Item
	{
		public WarbearWoolies() : base()
		{
			Id = 15065;
			Resistance[0] = 142;
			Bonding = 2;
			SellPrice = 22233;
			AvailableClasses = 0x7FFF;
			Model = 14547;
			ObjectClass = 4;
			SubClass = 2;
			Level = 57;
			ReqLevel = 52;
			Name = "Warbear Woolies";
			Name2 = "Warbear Woolies";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 111165;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 75;
			StrBonus = 28;
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Frostsaber Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class FrostsaberLeggings : Item
	{
		public FrostsaberLeggings() : base()
		{
			Id = 15069;
			Resistance[0] = 129;
			Bonding = 2;
			SellPrice = 17012;
			AvailableClasses = 0x7FFF;
			Model = 25701;
			Resistance[4] = 17;
			ObjectClass = 4;
			SubClass = 2;
			Level = 57;
			ReqLevel = 52;
			Name = "Frostsaber Leggings";
			Name2 = "Frostsaber Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 85064;
			Resistance[5] = 16;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Chimeric Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class ChimericLeggings : Item
	{
		public ChimericLeggings() : base()
		{
			Id = 15072;
			Resistance[6] = 16;
			Resistance[0] = 127;
			Bonding = 2;
			SellPrice = 16233;
			AvailableClasses = 0x7FFF;
			Model = 25705;
			ObjectClass = 4;
			SubClass = 2;
			Level = 56;
			ReqLevel = 51;
			Name = "Chimeric Leggings";
			Name2 = "Chimeric Leggings";
			Resistance[3] = 16;
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 81169;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Wicked Leather Pants)
*
***************************************************************/

namespace Server.Items
{
	public class WickedLeatherPants : Item
	{
		public WickedLeatherPants() : base()
		{
			Id = 15087;
			Resistance[0] = 131;
			Bonding = 2;
			SellPrice = 17892;
			AvailableClasses = 0x7FFF;
			Model = 25722;
			ObjectClass = 4;
			SubClass = 2;
			Level = 58;
			ReqLevel = 53;
			Name = "Wicked Leather Pants";
			Name2 = "Wicked Leather Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 89463;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
			AgilityBonus = 20;
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Runic Leather Pants)
*
***************************************************************/

namespace Server.Items
{
	public class RunicLeatherPants : Item
	{
		public RunicLeatherPants() : base()
		{
			Id = 15095;
			Resistance[0] = 135;
			Bonding = 2;
			SellPrice = 20885;
			AvailableClasses = 0x7FFF;
			Model = 25732;
			ObjectClass = 4;
			SubClass = 2;
			Level = 60;
			ReqLevel = 55;
			Name = "Runic Leather Pants";
			Name2 = "Runic Leather Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 104426;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
			IqBonus = 20;
			SpiritBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Rigid Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class RigidLeggings : Item
	{
		public RigidLeggings() : base()
		{
			Id = 15117;
			Resistance[0] = 73;
			Bonding = 2;
			SellPrice = 1219;
			AvailableClasses = 0x7FFF;
			Model = 1978;
			ObjectClass = 4;
			SubClass = 2;
			Level = 24;
			ReqLevel = 19;
			Name = "Rigid Leggings";
			Name2 = "Rigid Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 563;
			BuyPrice = 6096;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Robust Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class RobustLeggings : Item
	{
		public RobustLeggings() : base()
		{
			Id = 15126;
			Resistance[0] = 80;
			Bonding = 2;
			SellPrice = 1989;
			AvailableClasses = 0x7FFF;
			Model = 27884;
			ObjectClass = 4;
			SubClass = 2;
			Level = 29;
			ReqLevel = 24;
			Name = "Robust Leggings";
			Name2 = "Robust Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 565;
			BuyPrice = 9947;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Cutthroat's Pants)
*
***************************************************************/

namespace Server.Items
{
	public class CutthroatsPants : Item
	{
		public CutthroatsPants() : base()
		{
			Id = 15139;
			Resistance[0] = 86;
			Bonding = 2;
			SellPrice = 3055;
			AvailableClasses = 0x7FFF;
			Model = 27712;
			ObjectClass = 4;
			SubClass = 2;
			Level = 33;
			ReqLevel = 28;
			Name = "Cutthroat's Pants";
			Name2 = "Cutthroat's Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 566;
			BuyPrice = 15279;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Ghostwalker Legguards)
*
***************************************************************/

namespace Server.Items
{
	public class GhostwalkerLegguards : Item
	{
		public GhostwalkerLegguards() : base()
		{
			Id = 15151;
			Resistance[0] = 90;
			Bonding = 2;
			SellPrice = 3949;
			AvailableClasses = 0x7FFF;
			Model = 3442;
			ObjectClass = 4;
			SubClass = 2;
			Level = 36;
			ReqLevel = 31;
			Name = "Ghostwalker Legguards";
			Name2 = "Ghostwalker Legguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 567;
			BuyPrice = 19747;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Nocturnal Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class NocturnalLeggings : Item
	{
		public NocturnalLeggings() : base()
		{
			Id = 15157;
			Resistance[0] = 99;
			Bonding = 2;
			SellPrice = 6200;
			AvailableClasses = 0x7FFF;
			Model = 27723;
			ObjectClass = 4;
			SubClass = 2;
			Level = 41;
			ReqLevel = 36;
			Name = "Nocturnal Leggings";
			Name2 = "Nocturnal Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 569;
			BuyPrice = 31000;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Imposing Pants)
*
***************************************************************/

namespace Server.Items
{
	public class ImposingPants : Item
	{
		public ImposingPants() : base()
		{
			Id = 15168;
			Resistance[0] = 106;
			Bonding = 2;
			SellPrice = 7951;
			AvailableClasses = 0x7FFF;
			Model = 17153;
			ObjectClass = 4;
			SubClass = 2;
			Level = 45;
			ReqLevel = 40;
			Name = "Imposing Pants";
			Name2 = "Imposing Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 570;
			BuyPrice = 39757;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Potent Pants)
*
***************************************************************/

namespace Server.Items
{
	public class PotentPants : Item
	{
		public PotentPants() : base()
		{
			Id = 15176;
			Resistance[0] = 116;
			Bonding = 2;
			SellPrice = 12121;
			AvailableClasses = 0x7FFF;
			Model = 14697;
			ObjectClass = 4;
			SubClass = 2;
			Level = 50;
			ReqLevel = 45;
			Name = "Potent Pants";
			Name2 = "Potent Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 572;
			BuyPrice = 60606;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Praetorian Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class PraetorianLeggings : Item
	{
		public PraetorianLeggings() : base()
		{
			Id = 15186;
			Resistance[0] = 126;
			Bonding = 2;
			SellPrice = 15373;
			AvailableClasses = 0x7FFF;
			Model = 27662;
			ObjectClass = 4;
			SubClass = 2;
			Level = 55;
			ReqLevel = 50;
			Name = "Praetorian Leggings";
			Name2 = "Praetorian Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 574;
			BuyPrice = 76867;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Grand Legguards)
*
***************************************************************/

namespace Server.Items
{
	public class GrandLegguards : Item
	{
		public GrandLegguards() : base()
		{
			Id = 15194;
			Resistance[0] = 136;
			Bonding = 2;
			SellPrice = 22412;
			AvailableClasses = 0x7FFF;
			Model = 28019;
			ObjectClass = 4;
			SubClass = 2;
			Level = 61;
			ReqLevel = 56;
			Name = "Grand Legguards";
			Name2 = "Grand Legguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 576;
			BuyPrice = 112063;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Wildkeeper Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class WildkeeperLeggings : Item
	{
		public WildkeeperLeggings() : base()
		{
			Id = 15202;
			Resistance[0] = 65;
			Bonding = 1;
			SellPrice = 515;
			AvailableClasses = 0x7FFF;
			Model = 7834;
			ObjectClass = 4;
			SubClass = 2;
			Level = 18;
			Name = "Wildkeeper Leggings";
			Name2 = "Wildkeeper Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2579;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 50;
			AgilityBonus = 4;
			IqBonus = 2;
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Grizzly Pants)
*
***************************************************************/

namespace Server.Items
{
	public class GrizzlyPants : Item
	{
		public GrizzlyPants() : base()
		{
			Id = 15303;
			Resistance[0] = 60;
			Bonding = 2;
			SellPrice = 299;
			AvailableClasses = 0x7FFF;
			Model = 28014;
			ObjectClass = 4;
			SubClass = 2;
			Level = 14;
			ReqLevel = 9;
			Name = "Grizzly Pants";
			Name2 = "Grizzly Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 560;
			BuyPrice = 1495;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Feral Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class FeralLeggings : Item
	{
		public FeralLeggings() : base()
		{
			Id = 15312;
			Resistance[0] = 68;
			Bonding = 2;
			SellPrice = 745;
			AvailableClasses = 0x7FFF;
			Model = 14522;
			ObjectClass = 4;
			SubClass = 2;
			Level = 20;
			ReqLevel = 15;
			Name = "Feral Leggings";
			Name2 = "Feral Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 562;
			BuyPrice = 3728;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Wrangler's Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class WranglersLeggings : Item
	{
		public WranglersLeggings() : base()
		{
			Id = 15336;
			Resistance[0] = 78;
			Bonding = 2;
			SellPrice = 1669;
			AvailableClasses = 0x7FFF;
			Model = 28003;
			ObjectClass = 4;
			SubClass = 2;
			Level = 27;
			ReqLevel = 22;
			Name = "Wrangler's Leggings";
			Name2 = "Wrangler's Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 564;
			BuyPrice = 8345;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Pathfinder Pants)
*
***************************************************************/

namespace Server.Items
{
	public class PathfinderPants : Item
	{
		public PathfinderPants() : base()
		{
			Id = 15344;
			Resistance[0] = 83;
			Bonding = 2;
			SellPrice = 2516;
			AvailableClasses = 0x7FFF;
			Model = 27681;
			ObjectClass = 4;
			SubClass = 2;
			Level = 31;
			ReqLevel = 26;
			Name = "Pathfinder Pants";
			Name2 = "Pathfinder Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 566;
			BuyPrice = 12582;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Headhunter's Woolies)
*
***************************************************************/

namespace Server.Items
{
	public class HeadhuntersWoolies : Item
	{
		public HeadhuntersWoolies() : base()
		{
			Id = 15358;
			Resistance[0] = 89;
			Bonding = 2;
			SellPrice = 3604;
			AvailableClasses = 0x7FFF;
			Model = 27704;
			ObjectClass = 4;
			SubClass = 2;
			Level = 35;
			ReqLevel = 30;
			Name = "Headhunter's Woolies";
			Name2 = "Headhunter's Woolies";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 567;
			BuyPrice = 18020;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Trickster's Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class TrickstersLeggings : Item
	{
		public TrickstersLeggings() : base()
		{
			Id = 15366;
			Resistance[0] = 96;
			Bonding = 2;
			SellPrice = 5250;
			AvailableClasses = 0x7FFF;
			Model = 17155;
			ObjectClass = 4;
			SubClass = 2;
			Level = 40;
			ReqLevel = 35;
			Name = "Trickster's Leggings";
			Name2 = "Trickster's Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 569;
			BuyPrice = 26251;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Wolf Rider's Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class WolfRidersLeggings : Item
	{
		public WolfRidersLeggings() : base()
		{
			Id = 15374;
			Resistance[0] = 105;
			Bonding = 2;
			SellPrice = 7363;
			AvailableClasses = 0x7FFF;
			Model = 17153;
			ObjectClass = 4;
			SubClass = 2;
			Level = 44;
			ReqLevel = 39;
			Name = "Wolf Rider's Leggings";
			Name2 = "Wolf Rider's Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 570;
			BuyPrice = 36816;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Rageclaw Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class RageclawLeggings : Item
	{
		public RageclawLeggings() : base()
		{
			Id = 15385;
			Resistance[0] = 114;
			Bonding = 2;
			SellPrice = 11449;
			AvailableClasses = 0x7FFF;
			Model = 27555;
			ObjectClass = 4;
			SubClass = 2;
			Level = 49;
			ReqLevel = 44;
			Name = "Rageclaw Leggings";
			Name2 = "Rageclaw Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 572;
			BuyPrice = 57248;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Jadefire Pants)
*
***************************************************************/

namespace Server.Items
{
	public class JadefirePants : Item
	{
		public JadefirePants() : base()
		{
			Id = 15394;
			Resistance[0] = 124;
			Bonding = 2;
			SellPrice = 14614;
			AvailableClasses = 0x7FFF;
			Model = 27570;
			ObjectClass = 4;
			SubClass = 2;
			Level = 54;
			ReqLevel = 49;
			Name = "Jadefire Pants";
			Name2 = "Jadefire Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 573;
			BuyPrice = 73074;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Peerless Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class PeerlessLeggings : Item
	{
		public PeerlessLeggings() : base()
		{
			Id = 15431;
			Resistance[0] = 133;
			Bonding = 2;
			SellPrice = 19673;
			AvailableClasses = 0x7FFF;
			Model = 28029;
			ObjectClass = 4;
			SubClass = 2;
			Level = 59;
			ReqLevel = 54;
			Name = "Peerless Leggings";
			Name2 = "Peerless Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 575;
			BuyPrice = 98368;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Supreme Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class SupremeLeggings : Item
	{
		public SupremeLeggings() : base()
		{
			Id = 15440;
			Resistance[0] = 140;
			Bonding = 2;
			SellPrice = 24707;
			AvailableClasses = 0x7FFF;
			Model = 27615;
			ObjectClass = 4;
			SubClass = 2;
			Level = 63;
			ReqLevel = 58;
			Name = "Supreme Leggings";
			Name2 = "Supreme Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 576;
			BuyPrice = 123537;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Dredgemire Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class DredgemireLeggings : Item
	{
		public DredgemireLeggings() : base()
		{
			Id = 15450;
			Resistance[0] = 65;
			Bonding = 1;
			SellPrice = 533;
			AvailableClasses = 0x7FFF;
			Model = 28147;
			ObjectClass = 4;
			SubClass = 2;
			Level = 18;
			Name = "Dredgemire Leggings";
			Name2 = "Dredgemire Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2669;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 50;
			StaminaBonus = 2;
			IqBonus = 2;
			AgilityBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Lightstep Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class LightstepLeggings : Item
	{
		public LightstepLeggings() : base()
		{
			Id = 15456;
			Resistance[0] = 92;
			Bonding = 1;
			SellPrice = 4442;
			AvailableClasses = 0x7FFF;
			Model = 17155;
			ObjectClass = 4;
			SubClass = 2;
			Level = 37;
			Name = "Lightstep Leggings";
			Name2 = "Lightstep Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 22211;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
			AgilityBonus = 13;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Knight-Captain's Leather Legguards)
*
***************************************************************/

namespace Server.Items
{
	public class KnightCaptainsLeatherLegguards : Item
	{
		public KnightCaptainsLeatherLegguards() : base()
		{
			Id = 16419;
			Resistance[0] = 154;
			Bonding = 1;
			SellPrice = 14934;
			AvailableClasses = 0x08;
			Model = 31073;
			ObjectClass = 4;
			SubClass = 2;
			Level = 63;
			ReqLevel = 58;
			Name = "Knight-Captain's Leather Legguards";
			Name2 = "Knight-Captain's Leather Legguards";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 74670;
			Sets = 348;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			MaxCount = 1;
			Material = 8;
			Durability = 75;
			Flags = 32768;
			SetSpell( 7598 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 13;
			StrBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Knight-Captain's Dragonhide Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class KnightCaptainsDragonhideLeggings : Item
	{
		public KnightCaptainsDragonhideLeggings() : base()
		{
			Id = 16422;
			Resistance[0] = 154;
			Bonding = 1;
			SellPrice = 15092;
			AvailableClasses = 0x400;
			Model = 27235;
			ObjectClass = 4;
			SubClass = 2;
			Level = 63;
			ReqLevel = 58;
			Name = "Knight-Captain's Dragonhide Leggings";
			Name2 = "Knight-Captain's Dragonhide Leggings";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 75461;
			Sets = 381;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			MaxCount = 1;
			Material = 8;
			Durability = 75;
			Flags = 32768;
			SetSpell( 13669 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 9330 , 1 , 0 , -1 , 0 , -1 );
			StrBonus = 12;
			AgilityBonus = 12;
			StaminaBonus = 12;
			SpiritBonus = 9;
			IqBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Marshal's Dragonhide Legguards)
*
***************************************************************/

namespace Server.Items
{
	public class MarshalsDragonhideLegguards : Item
	{
		public MarshalsDragonhideLegguards() : base()
		{
			Id = 16450;
			Resistance[0] = 173;
			Bonding = 1;
			SellPrice = 21246;
			AvailableClasses = 0x400;
			Model = 30329;
			ObjectClass = 4;
			SubClass = 2;
			Level = 65;
			ReqLevel = 60;
			Name = "Marshal's Dragonhide Legguards";
			Name2 = "Marshal's Dragonhide Legguards";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 106231;
			Sets = 397;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			MaxCount = 1;
			Material = 8;
			Durability = 90;
			Flags = 32768;
			SetSpell( 13669 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 9332 , 1 , 0 , -1 , 0 , -1 );
			StrBonus = 16;
			AgilityBonus = 16;
			StaminaBonus = 15;
			SpiritBonus = 13;
			IqBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Marshal's Leather Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class MarshalsLeatherLeggings : Item
	{
		public MarshalsLeatherLeggings() : base()
		{
			Id = 16456;
			Resistance[0] = 173;
			Bonding = 1;
			SellPrice = 21713;
			AvailableClasses = 0x08;
			Model = 30329;
			ObjectClass = 4;
			SubClass = 2;
			Level = 65;
			ReqLevel = 60;
			Name = "Marshal's Leather Leggings";
			Name2 = "Marshal's Leather Leggings";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 108569;
			Sets = 394;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			MaxCount = 1;
			Material = 8;
			Durability = 90;
			Flags = 32768;
			SetSpell( 7598 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 15464 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 24;
			StrBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Legionnaire's Dragonhide Trousers)
*
***************************************************************/

namespace Server.Items
{
	public class LegionnairesDragonhideTrousers : Item
	{
		public LegionnairesDragonhideTrousers() : base()
		{
			Id = 16502;
			Resistance[0] = 154;
			Bonding = 1;
			SellPrice = 14025;
			AvailableClasses = 0x400;
			Model = 27267;
			ObjectClass = 4;
			SubClass = 2;
			Level = 63;
			ReqLevel = 58;
			Name = "Legionnaire's Dragonhide Trousers";
			Name2 = "Legionnaire's Dragonhide Trousers";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 70128;
			Sets = 382;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			MaxCount = 1;
			Material = 8;
			Durability = 75;
			Flags = 32768;
			SetSpell( 13669 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 9330 , 1 , 0 , -1 , 0 , -1 );
			StrBonus = 12;
			AgilityBonus = 12;
			StaminaBonus = 12;
			IqBonus = 12;
			SpiritBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Legionnaire's Leather Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class LegionnairesLeatherLeggings : Item
	{
		public LegionnairesLeatherLeggings() : base()
		{
			Id = 16508;
			Resistance[0] = 154;
			Bonding = 1;
			SellPrice = 14723;
			AvailableClasses = 0x08;
			Model = 31040;
			ObjectClass = 4;
			SubClass = 2;
			Level = 63;
			ReqLevel = 58;
			Name = "Legionnaire's Leather Leggings";
			Name2 = "Legionnaire's Leather Leggings";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 73619;
			Sets = 347;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			MaxCount = 1;
			Material = 8;
			Durability = 75;
			Flags = 32768;
			SetSpell( 7598 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 13;
			StrBonus = 7;
		}
	}
}


/**************************************************************
*
*				(General's Dragonhide Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class GeneralsDragonhideLeggings : Item
	{
		public GeneralsDragonhideLeggings() : base()
		{
			Id = 16552;
			Resistance[0] = 173;
			Bonding = 1;
			SellPrice = 21948;
			AvailableClasses = 0x400;
			Model = 32108;
			ObjectClass = 4;
			SubClass = 2;
			Level = 65;
			ReqLevel = 60;
			Name = "General's Dragonhide Leggings";
			Name2 = "General's Dragonhide Leggings";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 109744;
			Sets = 398;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			MaxCount = 1;
			Material = 8;
			Durability = 90;
			Flags = 32768;
			SetSpell( 13669 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 9332 , 1 , 0 , -1 , 0 , -1 );
			StrBonus = 16;
			AgilityBonus = 16;
			StaminaBonus = 15;
			IqBonus = 15;
			SpiritBonus = 13;
		}
	}
}


/**************************************************************
*
*				(General's Leather Legguards)
*
***************************************************************/

namespace Server.Items
{
	public class GeneralsLeatherLegguards : Item
	{
		public GeneralsLeatherLegguards() : base()
		{
			Id = 16564;
			Resistance[0] = 173;
			Bonding = 1;
			SellPrice = 21324;
			AvailableClasses = 0x08;
			Model = 32112;
			ObjectClass = 4;
			SubClass = 2;
			Level = 65;
			ReqLevel = 60;
			Name = "General's Leather Legguards";
			Name2 = "General's Leather Legguards";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 106622;
			Sets = 393;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			MaxCount = 1;
			Material = 8;
			Durability = 90;
			Flags = 32768;
			SetSpell( 7598 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 15464 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 24;
			StrBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Shadowcraft Pants)
*
***************************************************************/

namespace Server.Items
{
	public class ShadowcraftPants : Item
	{
		public ShadowcraftPants() : base()
		{
			Id = 16709;
			Resistance[0] = 150;
			Bonding = 1;
			SellPrice = 25542;
			AvailableClasses = 0x7FFF;
			Model = 28161;
			ObjectClass = 4;
			SubClass = 2;
			Level = 61;
			ReqLevel = 56;
			Name = "Shadowcraft Pants";
			Name2 = "Shadowcraft Pants";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 127712;
			Sets = 184;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 75;
			AgilityBonus = 25;
			StaminaBonus = 12;
			StrBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Wildheart Kilt)
*
***************************************************************/

namespace Server.Items
{
	public class WildheartKilt : Item
	{
		public WildheartKilt() : base()
		{
			Id = 16719;
			Resistance[0] = 150;
			Bonding = 1;
			SellPrice = 27192;
			AvailableClasses = 0x7FFF;
			Model = 29975;
			ObjectClass = 4;
			SubClass = 2;
			Level = 61;
			ReqLevel = 56;
			Name = "Wildheart Kilt";
			Name2 = "Wildheart Kilt";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 135964;
			Sets = 185;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 75;
			SpiritBonus = 14;
			IqBonus = 14;
			StaminaBonus = 14;
			StrBonus = 13;
			AgilityBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Nightslayer Pants)
*
***************************************************************/

namespace Server.Items
{
	public class NightslayerPants : Item
	{
		public NightslayerPants() : base()
		{
			Id = 16822;
			Resistance[0] = 175;
			Bonding = 1;
			SellPrice = 43466;
			AvailableClasses = 0x08;
			Model = 31340;
			ObjectClass = 4;
			SubClass = 2;
			Level = 66;
			ReqLevel = 60;
			Name = "Nightslayer Pants";
			Name2 = "Nightslayer Pants";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 217330;
			Sets = 204;
			Resistance[5] = 10;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 90;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			AgilityBonus = 33;
			StaminaBonus = 15;
			StrBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Cenarion Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class CenarionLeggings : Item
	{
		public CenarionLeggings() : base()
		{
			Id = 16835;
			Resistance[0] = 175;
			Bonding = 1;
			SellPrice = 42315;
			AvailableClasses = 0x400;
			Model = 31729;
			ObjectClass = 4;
			SubClass = 2;
			Level = 66;
			ReqLevel = 60;
			Name = "Cenarion Leggings";
			Name2 = "Cenarion Leggings";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 211575;
			Sets = 205;
			Resistance[5] = 10;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 90;
			SetSpell( 18384 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 21362 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 9408 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 19;
			IqBonus = 20;
			StaminaBonus = 18;
		}
	}
}


/**************************************************************
*
*				(Stormrage Legguards)
*
***************************************************************/

namespace Server.Items
{
	public class StormrageLegguards : Item
	{
		public StormrageLegguards() : base()
		{
			Id = 16901;
			Resistance[6] = 10;
			Resistance[0] = 197;
			Bonding = 1;
			SellPrice = 72415;
			AvailableClasses = 0x400;
			Model = 29777;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 2;
			Level = 76;
			ReqLevel = 60;
			Name = "Stormrage Legguards";
			Name2 = "Stormrage Legguards";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 362079;
			Sets = 214;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 90;
			SetSpell( 18034 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 26;
			IqBonus = 23;
			StaminaBonus = 17;
		}
	}
}


/**************************************************************
*
*				(Bloodfang Pants)
*
***************************************************************/

namespace Server.Items
{
	public class BloodfangPants : Item
	{
		public BloodfangPants() : base()
		{
			Id = 16909;
			Resistance[6] = 10;
			Resistance[0] = 197;
			Bonding = 1;
			SellPrice = 69209;
			AvailableClasses = 0x08;
			Model = 25683;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 2;
			Level = 76;
			ReqLevel = 60;
			Name = "Bloodfang Pants";
			Name2 = "Bloodfang Pants";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 346046;
			Sets = 213;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 90;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			AgilityBonus = 37;
			StaminaBonus = 17;
			StrBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Brusslehide Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class BrusslehideLeggings : Item
	{
		public BrusslehideLeggings() : base()
		{
			Id = 17751;
			Resistance[0] = 118;
			Bonding = 1;
			SellPrice = 12787;
			AvailableClasses = 0x7FFF;
			Model = 29930;
			ObjectClass = 4;
			SubClass = 2;
			Level = 51;
			ReqLevel = 46;
			Name = "Brusslehide Leggings";
			Name2 = "Brusslehide Leggings";
			Resistance[3] = 10;
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 63936;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
			SpiritBonus = 15;
			StaminaBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Unbridled Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class UnbridledLeggings : Item
	{
		public UnbridledLeggings() : base()
		{
			Id = 18298;
			Resistance[0] = 140;
			Bonding = 1;
			SellPrice = 20685;
			AvailableClasses = 0x7FFF;
			Model = 30654;
			ObjectClass = 4;
			SubClass = 2;
			Level = 56;
			ReqLevel = 51;
			Name = "Unbridled Leggings";
			Name2 = "Unbridled Leggings";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 103427;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 75;
			SetSpell( 21601 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 18;
			StrBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Tanglemoss Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class TanglemossLeggings : Item
	{
		public TanglemossLeggings() : base()
		{
			Id = 18390;
			Resistance[0] = 150;
			Bonding = 1;
			SellPrice = 26811;
			AvailableClasses = 0x7FFF;
			Model = 18935;
			ObjectClass = 4;
			SubClass = 2;
			Level = 61;
			ReqLevel = 57;
			Name = "Tanglemoss Leggings";
			Name2 = "Tanglemoss Leggings";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 134059;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 75;
			SetSpell( 18384 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 20;
			IqBonus = 13;
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Shaggy Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class ShaggyLeggings : Item
	{
		public ShaggyLeggings() : base()
		{
			Id = 18477;
			Resistance[0] = 135;
			Bonding = 1;
			SellPrice = 19768;
			AvailableClasses = 0x7FFF;
			Model = 17142;
			ObjectClass = 4;
			SubClass = 2;
			Level = 60;
			ReqLevel = 55;
			Name = "Shaggy Leggings";
			Name2 = "Shaggy Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 98841;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 65;
			SetSpell( 21629 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 19;
		}
	}
}


/**************************************************************
*
*				(Gnarlpine Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class GnarlpineLeggings : Item
	{
		public GnarlpineLeggings() : base()
		{
			Id = 18611;
			Resistance[0] = 36;
			Bonding = 2;
			SellPrice = 27;
			AvailableClasses = 0x7FFF;
			Model = 9975;
			ObjectClass = 4;
			SubClass = 2;
			Level = 7;
			ReqLevel = 2;
			Name = "Gnarlpine Leggings";
			Name2 = "Gnarlpine Leggings";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 139;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Ghoul Skin Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class GhoulSkinLeggings : Item
	{
		public GhoulSkinLeggings() : base()
		{
			Id = 18682;
			Resistance[0] = 150;
			Bonding = 1;
			SellPrice = 25456;
			AvailableClasses = 0x7FFF;
			Model = 10006;
			ObjectClass = 4;
			SubClass = 2;
			Level = 61;
			ReqLevel = 56;
			Name = "Ghoul Skin Leggings";
			Name2 = "Ghoul Skin Leggings";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 127282;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 75;
			SetSpell( 17371 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 20;
			SpiritBonus = 8;
			IqBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Plaguehound Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class PlaguehoundLeggings : Item
	{
		public PlaguehoundLeggings() : base()
		{
			Id = 18736;
			Resistance[0] = 152;
			Bonding = 1;
			SellPrice = 26112;
			AvailableClasses = 0x7FFF;
			Model = 16133;
			ObjectClass = 4;
			SubClass = 2;
			Level = 62;
			ReqLevel = 57;
			Name = "Plaguehound Leggings";
			Name2 = "Plaguehound Leggings";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 130561;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 75;
			SetSpell( 15464 , 1 , 0 , -1 , 0 , -1 );
			AgilityBonus = 30;
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Salamander Scale Pants)
*
***************************************************************/

namespace Server.Items
{
	public class SalamanderScalePants : Item
	{
		public SalamanderScalePants() : base()
		{
			Id = 18875;
			Resistance[0] = 171;
			Bonding = 1;
			SellPrice = 38445;
			AvailableClasses = 0x7FFF;
			Model = 31333;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 2;
			Level = 64;
			ReqLevel = 59;
			Name = "Salamander Scale Pants";
			Name2 = "Salamander Scale Pants";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 192227;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 8;
			Durability = 90;
			SetSpell( 18035 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 21365 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 14;
			StaminaBonus = 14;
		}
	}
}


