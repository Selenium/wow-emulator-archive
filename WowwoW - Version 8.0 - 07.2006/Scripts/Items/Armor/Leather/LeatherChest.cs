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
*				(Layered Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class LayeredTunic : Item
	{
		public LayeredTunic() : base()
		{
			Id = 60;
			Resistance[0] = 33;
			Bonding = 1;
			SellPrice = 12;
			AvailableClasses = 0x7FFF;
			Model = 16891;
			ObjectClass = 4;
			SubClass = 2;
			Level = 5;
			Name = "Layered Tunic";
			Name2 = "Layered Tunic";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 60;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Dirty Leather Vest)
*
***************************************************************/

namespace Server.Items
{
	public class DirtyLeatherVest : Item
	{
		public DirtyLeatherVest() : base()
		{
			Id = 85;
			Resistance[0] = 33;
			SellPrice = 12;
			AvailableClasses = 0x7FFF;
			Model = 16883;
			ObjectClass = 4;
			SubClass = 2;
			Level = 5;
			ReqLevel = 1;
			Name = "Dirty Leather Vest";
			Name2 = "Dirty Leather Vest";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 62;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Cured Leather Armor)
*
***************************************************************/

namespace Server.Items
{
	public class CuredLeatherArmor : Item
	{
		public CuredLeatherArmor() : base()
		{
			Id = 236;
			Resistance[0] = 77;
			SellPrice = 559;
			AvailableClasses = 0x7FFF;
			Model = 14278;
			ObjectClass = 4;
			SubClass = 2;
			Level = 22;
			ReqLevel = 17;
			Name = "Cured Leather Armor";
			Name2 = "Cured Leather Armor";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2795;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 75;
		}
	}
}


/**************************************************************
*
*				(Rough Leather Vest)
*
***************************************************************/

namespace Server.Items
{
	public class RoughLeatherVest : Item
	{
		public RoughLeatherVest() : base()
		{
			Id = 799;
			Resistance[0] = 52;
			SellPrice = 71;
			AvailableClasses = 0x7FFF;
			Model = 2106;
			ObjectClass = 4;
			SubClass = 2;
			Level = 10;
			ReqLevel = 5;
			Name = "Rough Leather Vest";
			Name2 = "Rough Leather Vest";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 355;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Riverpaw Leather Vest)
*
***************************************************************/

namespace Server.Items
{
	public class RiverpawLeatherVest : Item
	{
		public RiverpawLeatherVest() : base()
		{
			Id = 821;
			Resistance[0] = 65;
			Bonding = 2;
			SellPrice = 249;
			AvailableClasses = 0x7FFF;
			Model = 17102;
			ObjectClass = 4;
			SubClass = 2;
			Level = 13;
			ReqLevel = 8;
			Name = "Riverpaw Leather Vest";
			Name2 = "Riverpaw Leather Vest";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1248;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 60;
			StaminaBonus = 2;
			AgilityBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Tanned Leather Jerkin)
*
***************************************************************/

namespace Server.Items
{
	public class TannedLeatherJerkin : Item
	{
		public TannedLeatherJerkin() : base()
		{
			Id = 846;
			Resistance[0] = 69;
			SellPrice = 290;
			AvailableClasses = 0x7FFF;
			Model = 14472;
			ObjectClass = 4;
			SubClass = 2;
			Level = 17;
			ReqLevel = 12;
			Name = "Tanned Leather Jerkin";
			Name2 = "Tanned Leather Jerkin";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1452;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Gnoll War Harness)
*
***************************************************************/

namespace Server.Items
{
	public class GnollWarHarness : Item
	{
		public GnollWarHarness() : base()
		{
			Id = 1211;
			Resistance[0] = 70;
			Bonding = 2;
			SellPrice = 347;
			AvailableClasses = 0x7FFF;
			Model = 14260;
			ObjectClass = 4;
			SubClass = 2;
			Level = 15;
			ReqLevel = 10;
			Name = "Gnoll War Harness";
			Name2 = "Gnoll War Harness";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1738;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 65;
			StrBonus = 2;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Ragged Leather Vest)
*
***************************************************************/

namespace Server.Items
{
	public class RaggedLeatherVest : Item
	{
		public RaggedLeatherVest() : base()
		{
			Id = 1364;
			Resistance[0] = 31;
			SellPrice = 8;
			AvailableClasses = 0x7FFF;
			Model = 14339;
			ObjectClass = 4;
			SubClass = 2;
			Level = 5;
			ReqLevel = 1;
			Name = "Ragged Leather Vest";
			Name2 = "Ragged Leather Vest";
			AvailableRaces = 0x1FF;
			BuyPrice = 41;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Worn Leather Vest)
*
***************************************************************/

namespace Server.Items
{
	public class WornLeatherVest : Item
	{
		public WornLeatherVest() : base()
		{
			Id = 1425;
			Resistance[0] = 46;
			SellPrice = 37;
			AvailableClasses = 0x7FFF;
			Model = 14190;
			ObjectClass = 4;
			SubClass = 2;
			Level = 9;
			ReqLevel = 4;
			Name = "Worn Leather Vest";
			Name2 = "Worn Leather Vest";
			AvailableRaces = 0x1FF;
			BuyPrice = 188;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Gloomshroud Armor)
*
***************************************************************/

namespace Server.Items
{
	public class GloomshroudArmor : Item
	{
		public GloomshroudArmor() : base()
		{
			Id = 1489;
			Resistance[0] = 94;
			Bonding = 2;
			SellPrice = 1553;
			AvailableClasses = 0x7FFF;
			Model = 8676;
			ObjectClass = 4;
			SubClass = 2;
			Level = 25;
			ReqLevel = 20;
			Name = "Gloomshroud Armor";
			Name2 = "Gloomshroud Armor";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 7767;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 95;
			IqBonus = 12;
			StrBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Warped Leather Vest)
*
***************************************************************/

namespace Server.Items
{
	public class WarpedLeatherVest : Item
	{
		public WarpedLeatherVest() : base()
		{
			Id = 1509;
			Resistance[0] = 52;
			SellPrice = 59;
			AvailableClasses = 0x7FFF;
			Model = 18466;
			ObjectClass = 4;
			SubClass = 2;
			Level = 11;
			ReqLevel = 6;
			Name = "Warped Leather Vest";
			Name2 = "Warped Leather Vest";
			AvailableRaces = 0x1FF;
			BuyPrice = 299;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Patched Leather Jerkin)
*
***************************************************************/

namespace Server.Items
{
	public class PatchedLeatherJerkin : Item
	{
		public PatchedLeatherJerkin() : base()
		{
			Id = 1794;
			Resistance[0] = 70;
			SellPrice = 277;
			AvailableClasses = 0x7FFF;
			Model = 14272;
			ObjectClass = 4;
			SubClass = 2;
			Level = 20;
			ReqLevel = 15;
			Name = "Patched Leather Jerkin";
			Name2 = "Patched Leather Jerkin";
			AvailableRaces = 0x1FF;
			BuyPrice = 1387;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Rawhide Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class RawhideTunic : Item
	{
		public RawhideTunic() : base()
		{
			Id = 1802;
			Resistance[0] = 71;
			SellPrice = 337;
			AvailableClasses = 0x7FFF;
			Model = 16895;
			ObjectClass = 4;
			SubClass = 2;
			Level = 21;
			ReqLevel = 16;
			Name = "Rawhide Tunic";
			Name2 = "Rawhide Tunic";
			AvailableRaces = 0x1FF;
			BuyPrice = 1688;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Tough Leather Armor)
*
***************************************************************/

namespace Server.Items
{
	public class ToughLeatherArmor : Item
	{
		public ToughLeatherArmor() : base()
		{
			Id = 1810;
			Resistance[0] = 80;
			SellPrice = 648;
			AvailableClasses = 0x7FFF;
			Model = 14418;
			ObjectClass = 4;
			SubClass = 2;
			Level = 27;
			ReqLevel = 22;
			Name = "Tough Leather Armor";
			Name2 = "Tough Leather Armor";
			AvailableRaces = 0x1FF;
			BuyPrice = 3243;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 80;
		}
	}
}


/**************************************************************
*
*				(Tunic of Westfall)
*
***************************************************************/

namespace Server.Items
{
	public class TunicOfWestfall : Item
	{
		public TunicOfWestfall() : base()
		{
			Id = 2041;
			Resistance[0] = 92;
			Bonding = 1;
			SellPrice = 1412;
			AvailableClasses = 0x7FFF;
			Model = 8703;
			ObjectClass = 4;
			SubClass = 2;
			Level = 24;
			Name = "Tunic of Westfall";
			Name2 = "Tunic of Westfall";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 7060;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 90;
			StaminaBonus = 5;
			AgilityBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Black Bear Hide Vest)
*
***************************************************************/

namespace Server.Items
{
	public class BlackBearHideVest : Item
	{
		public BlackBearHideVest() : base()
		{
			Id = 2069;
			Resistance[0] = 59;
			SellPrice = 121;
			AvailableClasses = 0x7FFF;
			Model = 16868;
			ObjectClass = 4;
			SubClass = 2;
			Level = 12;
			ReqLevel = 7;
			Name = "Black Bear Hide Vest";
			Name2 = "Black Bear Hide Vest";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 609;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Hard Crawler Carapace)
*
***************************************************************/

namespace Server.Items
{
	public class HardCrawlerCarapace : Item
	{
		public HardCrawlerCarapace() : base()
		{
			Id = 2087;
			Resistance[0] = 65;
			Bonding = 2;
			SellPrice = 252;
			AvailableClasses = 0x7FFF;
			Model = 17095;
			ObjectClass = 4;
			SubClass = 2;
			Level = 13;
			ReqLevel = 8;
			Name = "Hard Crawler Carapace";
			Name2 = "Hard Crawler Carapace";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1262;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 60;
			StrBonus = 2;
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Frostmane Leather Vest)
*
***************************************************************/

namespace Server.Items
{
	public class FrostmaneLeatherVest : Item
	{
		public FrostmaneLeatherVest() : base()
		{
			Id = 2108;
			Resistance[0] = 29;
			SellPrice = 8;
			AvailableClasses = 0x7FFF;
			Model = 8662;
			ObjectClass = 4;
			SubClass = 2;
			Level = 4;
			ReqLevel = 1;
			Name = "Frostmane Leather Vest";
			Name2 = "Frostmane Leather Vest";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 40;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Lumberjack Jerkin)
*
***************************************************************/

namespace Server.Items
{
	public class LumberjackJerkin : Item
	{
		public LumberjackJerkin() : base()
		{
			Id = 2112;
			Resistance[0] = 49;
			SellPrice = 54;
			AvailableClasses = 0x7FFF;
			Model = 14279;
			ObjectClass = 4;
			SubClass = 2;
			Level = 9;
			ReqLevel = 4;
			Name = "Lumberjack Jerkin";
			Name2 = "Lumberjack Jerkin";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 271;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Cracked Leather Vest)
*
***************************************************************/

namespace Server.Items
{
	public class CrackedLeatherVest : Item
	{
		public CrackedLeatherVest() : base()
		{
			Id = 2127;
			Resistance[0] = 33;
			SellPrice = 12;
			AvailableClasses = 0x7FFF;
			Model = 14430;
			ObjectClass = 4;
			SubClass = 2;
			Level = 5;
			ReqLevel = 1;
			Name = "Cracked Leather Vest";
			Name2 = "Cracked Leather Vest";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 60;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Cuirboulli Vest)
*
***************************************************************/

namespace Server.Items
{
	public class CuirboulliVest : Item
	{
		public CuirboulliVest() : base()
		{
			Id = 2141;
			Resistance[0] = 84;
			SellPrice = 1044;
			AvailableClasses = 0x7FFF;
			Model = 8655;
			ObjectClass = 4;
			SubClass = 2;
			Level = 27;
			ReqLevel = 22;
			Name = "Cuirboulli Vest";
			Name2 = "Cuirboulli Vest";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 5223;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 80;
		}
	}
}


/**************************************************************
*
*				(Embossed Leather Vest)
*
***************************************************************/

namespace Server.Items
{
	public class EmbossedLeatherVest : Item
	{
		public EmbossedLeatherVest() : base()
		{
			Id = 2300;
			Resistance[0] = 62;
			Bonding = 2;
			SellPrice = 192;
			AvailableClasses = 0x7FFF;
			Model = 9502;
			ObjectClass = 4;
			SubClass = 2;
			Level = 12;
			ReqLevel = 7;
			Name = "Embossed Leather Vest";
			Name2 = "Embossed Leather Vest";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 962;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 60;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(White Leather Jerkin)
*
***************************************************************/

namespace Server.Items
{
	public class WhiteLeatherJerkin : Item
	{
		public WhiteLeatherJerkin() : base()
		{
			Id = 2311;
			Resistance[0] = 62;
			SellPrice = 150;
			AvailableClasses = 0x7FFF;
			Model = 17233;
			ObjectClass = 4;
			SubClass = 2;
			Level = 13;
			ReqLevel = 8;
			Name = "White Leather Jerkin";
			Name2 = "White Leather Jerkin";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 751;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Toughened Leather Armor)
*
***************************************************************/

namespace Server.Items
{
	public class ToughenedLeatherArmor : Item
	{
		public ToughenedLeatherArmor() : base()
		{
			Id = 2314;
			Resistance[0] = 80;
			SellPrice = 743;
			AvailableClasses = 0x7FFF;
			Model = 9531;
			ObjectClass = 4;
			SubClass = 2;
			Level = 24;
			ReqLevel = 19;
			Name = "Toughened Leather Armor";
			Name2 = "Toughened Leather Armor";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 3717;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 75;
		}
	}
}


/**************************************************************
*
*				(Dark Leather Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class DarkLeatherTunic : Item
	{
		public DarkLeatherTunic() : base()
		{
			Id = 2317;
			Resistance[0] = 78;
			Bonding = 2;
			SellPrice = 689;
			AvailableClasses = 0x7FFF;
			Model = 17214;
			ObjectClass = 4;
			SubClass = 2;
			Level = 20;
			ReqLevel = 15;
			Name = "Dark Leather Tunic";
			Name2 = "Dark Leather Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3446;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 70;
			AgilityBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Battered Leather Harness)
*
***************************************************************/

namespace Server.Items
{
	public class BatteredLeatherHarness : Item
	{
		public BatteredLeatherHarness() : base()
		{
			Id = 2370;
			Resistance[0] = 52;
			SellPrice = 75;
			AvailableClasses = 0x7FFF;
			Model = 16871;
			ObjectClass = 4;
			SubClass = 2;
			Level = 10;
			ReqLevel = 5;
			Name = "Battered Leather Harness";
			Name2 = "Battered Leather Harness";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 377;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Studded Doublet)
*
***************************************************************/

namespace Server.Items
{
	public class StuddedDoublet : Item
	{
		public StuddedDoublet() : base()
		{
			Id = 2463;
			Resistance[0] = 100;
			SellPrice = 2739;
			AvailableClasses = 0x7FFF;
			Model = 16900;
			ObjectClass = 4;
			SubClass = 2;
			Level = 37;
			ReqLevel = 32;
			Name = "Studded Doublet";
			Name2 = "Studded Doublet";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 13695;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Reinforced Leather Vest)
*
***************************************************************/

namespace Server.Items
{
	public class ReinforcedLeatherVest : Item
	{
		public ReinforcedLeatherVest() : base()
		{
			Id = 2470;
			Resistance[0] = 126;
			SellPrice = 6790;
			AvailableClasses = 0x7FFF;
			Model = 14496;
			ObjectClass = 4;
			SubClass = 2;
			Level = 50;
			ReqLevel = 45;
			Name = "Reinforced Leather Vest";
			Name2 = "Reinforced Leather Vest";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 33952;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Soft Leather Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class SoftLeatherTunic : Item
	{
		public SoftLeatherTunic() : base()
		{
			Id = 2817;
			Resistance[0] = 62;
			Bonding = 1;
			SellPrice = 201;
			AvailableClasses = 0x7FFF;
			Model = 17103;
			ObjectClass = 4;
			SubClass = 2;
			Level = 12;
			Name = "Soft Leather Tunic";
			Name2 = "Soft Leather Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1006;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 60;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Burnt Leather Vest)
*
***************************************************************/

namespace Server.Items
{
	public class BurntLeatherVest : Item
	{
		public BurntLeatherVest() : base()
		{
			Id = 2961;
			Resistance[0] = 58;
			Bonding = 2;
			SellPrice = 155;
			AvailableClasses = 0x7FFF;
			Model = 17093;
			ObjectClass = 4;
			SubClass = 2;
			Level = 11;
			ReqLevel = 6;
			Name = "Burnt Leather Vest";
			Name2 = "Burnt Leather Vest";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 779;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 55;
			IqBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Hunting Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class HuntingTunic : Item
	{
		public HuntingTunic() : base()
		{
			Id = 2973;
			Resistance[0] = 73;
			Bonding = 2;
			SellPrice = 484;
			AvailableClasses = 0x7FFF;
			Model = 14539;
			ObjectClass = 4;
			SubClass = 2;
			Level = 17;
			ReqLevel = 12;
			Name = "Hunting Tunic";
			Name2 = "Hunting Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2420;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 65;
			StaminaBonus = 4;
			AgilityBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Inscribed Leather Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class InscribedLeatherBreastplate : Item
	{
		public InscribedLeatherBreastplate() : base()
		{
			Id = 2985;
			Resistance[0] = 79;
			Bonding = 2;
			SellPrice = 822;
			AvailableClasses = 0x7FFF;
			Model = 9739;
			ObjectClass = 4;
			SubClass = 2;
			Level = 21;
			ReqLevel = 16;
			Name = "Inscribed Leather Breastplate";
			Name2 = "Inscribed Leather Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4113;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 70;
			StaminaBonus = 5;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Brood Mother Carapace)
*
***************************************************************/

namespace Server.Items
{
	public class BroodMotherCarapace : Item
	{
		public BroodMotherCarapace() : base()
		{
			Id = 3000;
			Resistance[0] = 55;
			Bonding = 2;
			SellPrice = 119;
			AvailableClasses = 0x7FFF;
			Model = 16888;
			ObjectClass = 4;
			SubClass = 2;
			Level = 10;
			ReqLevel = 5;
			Name = "Brood Mother Carapace";
			Name2 = "Brood Mother Carapace";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 596;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 55;
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Forest Leather Chestpiece)
*
***************************************************************/

namespace Server.Items
{
	public class ForestLeatherChestpiece : Item
	{
		public ForestLeatherChestpiece() : base()
		{
			Id = 3055;
			Resistance[0] = 87;
			Bonding = 2;
			SellPrice = 1526;
			AvailableClasses = 0x7FFF;
			Model = 8665;
			ObjectClass = 4;
			SubClass = 2;
			Level = 26;
			ReqLevel = 21;
			Name = "Forest Leather Chestpiece";
			Name2 = "Forest Leather Chestpiece";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7631;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 80;
			IqBonus = 7;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Tribal Vest)
*
***************************************************************/

namespace Server.Items
{
	public class TribalVest : Item
	{
		public TribalVest() : base()
		{
			Id = 3288;
			Resistance[0] = 65;
			Bonding = 2;
			SellPrice = 250;
			AvailableClasses = 0x7FFF;
			Model = 27996;
			ObjectClass = 4;
			SubClass = 2;
			Level = 13;
			ReqLevel = 8;
			Name = "Tribal Vest";
			Name2 = "Tribal Vest";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1253;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 60;
			AgilityBonus = 2;
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Ceremonial Leather Harness)
*
***************************************************************/

namespace Server.Items
{
	public class CeremonialLeatherHarness : Item
	{
		public CeremonialLeatherHarness() : base()
		{
			Id = 3313;
			Resistance[0] = 74;
			Bonding = 2;
			SellPrice = 519;
			AvailableClasses = 0x7FFF;
			Model = 28047;
			ObjectClass = 4;
			SubClass = 2;
			Level = 18;
			ReqLevel = 13;
			Name = "Ceremonial Leather Harness";
			Name2 = "Ceremonial Leather Harness";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2595;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 65;
			AgilityBonus = 4;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Bone-studded Leather)
*
***************************************************************/

namespace Server.Items
{
	public class BoneStuddedLeather : Item
	{
		public BoneStuddedLeather() : base()
		{
			Id = 3431;
			Resistance[0] = 86;
			Bonding = 1;
			SellPrice = 1335;
			AvailableClasses = 0x7FFF;
			Model = 17092;
			ObjectClass = 4;
			SubClass = 2;
			Level = 25;
			Name = "Bone-studded Leather";
			Name2 = "Bone-studded Leather";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6677;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 80;
			StrBonus = 6;
			StaminaBonus = 5;
			AgilityBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Tiller's Vest)
*
***************************************************************/

namespace Server.Items
{
	public class TillersVest : Item
	{
		public TillersVest() : base()
		{
			Id = 3444;
			Resistance[0] = 55;
			Bonding = 1;
			SellPrice = 90;
			AvailableClasses = 0x7FFF;
			Model = 8698;
			ObjectClass = 4;
			SubClass = 2;
			Level = 11;
			Name = "Tiller's Vest";
			Name2 = "Tiller's Vest";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 451;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Raptorbane Armor)
*
***************************************************************/

namespace Server.Items
{
	public class RaptorbaneArmor : Item
	{
		public RaptorbaneArmor() : base()
		{
			Id = 3566;
			Resistance[0] = 92;
			Bonding = 1;
			SellPrice = 2023;
			AvailableClasses = 0x7FFF;
			Model = 17101;
			ObjectClass = 4;
			SubClass = 2;
			Level = 29;
			Name = "Raptorbane Armor";
			Name2 = "Raptorbane Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 10116;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
			SetSpell( 14565 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Camouflaged Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class CamouflagedTunic : Item
	{
		public CamouflagedTunic() : base()
		{
			Id = 3585;
			Resistance[0] = 81;
			Bonding = 1;
			SellPrice = 953;
			AvailableClasses = 0x7FFF;
			Model = 16876;
			ObjectClass = 4;
			SubClass = 2;
			Level = 22;
			Name = "Camouflaged Tunic";
			Name2 = "Camouflaged Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4767;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 75;
			StaminaBonus = 6;
			AgilityBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Ribbed Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class RibbedBreastplate : Item
	{
		public RibbedBreastplate() : base()
		{
			Id = 3750;
			Resistance[0] = 94;
			Bonding = 1;
			SellPrice = 2209;
			AvailableClasses = 0x7FFF;
			Model = 8732;
			ObjectClass = 4;
			SubClass = 2;
			Level = 30;
			Name = "Ribbed Breastplate";
			Name2 = "Ribbed Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11048;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
			StrBonus = 5;
			StaminaBonus = 5;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Hardened Leather Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class HardenedLeatherTunic : Item
	{
		public HardenedLeatherTunic() : base()
		{
			Id = 3807;
			Resistance[0] = 89;
			SellPrice = 1162;
			AvailableClasses = 0x7FFF;
			Model = 19040;
			ObjectClass = 4;
			SubClass = 2;
			Level = 33;
			ReqLevel = 28;
			Name = "Hardened Leather Tunic";
			Name2 = "Hardened Leather Tunic";
			AvailableRaces = 0x1FF;
			BuyPrice = 5813;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Thick Leather Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class ThickLeatherTunic : Item
	{
		public ThickLeatherTunic() : base()
		{
			Id = 3968;
			Resistance[0] = 109;
			SellPrice = 3331;
			AvailableClasses = 0x7FFF;
			Model = 17105;
			ObjectClass = 4;
			SubClass = 2;
			Level = 45;
			ReqLevel = 40;
			Name = "Thick Leather Tunic";
			Name2 = "Thick Leather Tunic";
			AvailableRaces = 0x1FF;
			BuyPrice = 16656;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Smooth Leather Armor)
*
***************************************************************/

namespace Server.Items
{
	public class SmoothLeatherArmor : Item
	{
		public SmoothLeatherArmor() : base()
		{
			Id = 3976;
			Resistance[0] = 133;
			SellPrice = 6978;
			AvailableClasses = 0x7FFF;
			Model = 11138;
			ObjectClass = 4;
			SubClass = 2;
			Level = 57;
			ReqLevel = 52;
			Name = "Smooth Leather Armor";
			Name2 = "Smooth Leather Armor";
			AvailableRaces = 0x1FF;
			BuyPrice = 34894;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Insignia Chestguard)
*
***************************************************************/

namespace Server.Items
{
	public class InsigniaChestguard : Item
	{
		public InsigniaChestguard() : base()
		{
			Id = 4057;
			Resistance[0] = 103;
			Bonding = 2;
			SellPrice = 4032;
			AvailableClasses = 0x7FFF;
			Model = 16890;
			ObjectClass = 4;
			SubClass = 2;
			Level = 36;
			ReqLevel = 31;
			Name = "Insignia Chestguard";
			Name2 = "Insignia Chestguard";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 20163;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
			IqBonus = 3;
			StaminaBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Glyphed Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class GlyphedBreastplate : Item
	{
		public GlyphedBreastplate() : base()
		{
			Id = 4058;
			Resistance[0] = 113;
			Bonding = 2;
			SellPrice = 6056;
			AvailableClasses = 0x7FFF;
			Model = 14674;
			ObjectClass = 4;
			SubClass = 2;
			Level = 41;
			ReqLevel = 36;
			Name = "Glyphed Breastplate";
			Name2 = "Glyphed Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 30283;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
			StaminaBonus = 4;
			IqBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Raptor Hunter Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class RaptorHunterTunic : Item
	{
		public RaptorHunterTunic() : base()
		{
			Id = 4119;
			Resistance[0] = 117;
			Bonding = 1;
			SellPrice = 7271;
			AvailableClasses = 0x7FFF;
			Model = 17100;
			ObjectClass = 4;
			SubClass = 2;
			Level = 43;
			Name = "Raptor Hunter Tunic";
			Name2 = "Raptor Hunter Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 36357;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
			StrBonus = 4;
			StaminaBonus = 16;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Fine Leather Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class FineLeatherTunic : Item
	{
		public FineLeatherTunic() : base()
		{
			Id = 4243;
			Resistance[0] = 73;
			Bonding = 2;
			SellPrice = 461;
			AvailableClasses = 0x7FFF;
			Model = 9511;
			ObjectClass = 4;
			SubClass = 2;
			Level = 17;
			ReqLevel = 12;
			Name = "Fine Leather Tunic";
			Name2 = "Fine Leather Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2308;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 65;
			AgilityBonus = 4;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Hillman's Leather Vest)
*
***************************************************************/

namespace Server.Items
{
	public class HillmansLeatherVest : Item
	{
		public HillmansLeatherVest() : base()
		{
			Id = 4244;
			Resistance[0] = 78;
			Bonding = 2;
			SellPrice = 723;
			AvailableClasses = 0x7FFF;
			Model = 18458;
			ObjectClass = 4;
			SubClass = 2;
			Level = 20;
			ReqLevel = 15;
			Name = "Hillman's Leather Vest";
			Name2 = "Hillman's Leather Vest";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3618;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 70;
			StaminaBonus = 4;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Green Leather Armor)
*
***************************************************************/

namespace Server.Items
{
	public class GreenLeatherArmor : Item
	{
		public GreenLeatherArmor() : base()
		{
			Id = 4255;
			Resistance[0] = 95;
			Bonding = 2;
			SellPrice = 2366;
			AvailableClasses = 0x7FFF;
			Model = 9532;
			ObjectClass = 4;
			SubClass = 2;
			Level = 31;
			ReqLevel = 26;
			Name = "Green Leather Armor";
			Name2 = "Green Leather Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11830;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
			AgilityBonus = 8;
			IqBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Guardian Armor)
*
***************************************************************/

namespace Server.Items
{
	public class GuardianArmor : Item
	{
		public GuardianArmor() : base()
		{
			Id = 4256;
			Resistance[0] = 102;
			Bonding = 2;
			SellPrice = 3477;
			AvailableClasses = 0x7FFF;
			Model = 9545;
			ObjectClass = 4;
			SubClass = 2;
			Level = 35;
			ReqLevel = 30;
			Name = "Guardian Armor";
			Name2 = "Guardian Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 17387;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
			SpiritBonus = 10;
			IqBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Raptor Hide Harness)
*
***************************************************************/

namespace Server.Items
{
	public class RaptorHideHarness : Item
	{
		public RaptorHideHarness() : base()
		{
			Id = 4455;
			Resistance[0] = 98;
			Bonding = 2;
			SellPrice = 3096;
			AvailableClasses = 0x7FFF;
			Model = 14261;
			ObjectClass = 4;
			SubClass = 2;
			Level = 33;
			ReqLevel = 28;
			Name = "Raptor Hide Harness";
			Name2 = "Raptor Hide Harness";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 15483;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
			StaminaBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Sleek Feathered Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class SleekFeatheredTunic : Item
	{
		public SleekFeatheredTunic() : base()
		{
			Id = 4861;
			Resistance[0] = 55;
			Bonding = 2;
			SellPrice = 119;
			AvailableClasses = 0x7FFF;
			Model = 5243;
			ObjectClass = 4;
			SubClass = 2;
			Level = 10;
			ReqLevel = 5;
			Name = "Sleek Feathered Tunic";
			Name2 = "Sleek Feathered Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 596;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 55;
			AgilityBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Woodland Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class WoodlandTunic : Item
	{
		public WoodlandTunic() : base()
		{
			Id = 4907;
			Resistance[0] = 33;
			Bonding = 1;
			SellPrice = 13;
			AvailableClasses = 0x7FFF;
			Model = 8701;
			ObjectClass = 4;
			SubClass = 2;
			Level = 5;
			Name = "Woodland Tunic";
			Name2 = "Woodland Tunic";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 65;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Light Scorpid Armor)
*
***************************************************************/

namespace Server.Items
{
	public class LightScorpidArmor : Item
	{
		public LightScorpidArmor() : base()
		{
			Id = 4929;
			Resistance[0] = 49;
			Bonding = 1;
			SellPrice = 58;
			AvailableClasses = 0x7FFF;
			Model = 17097;
			ObjectClass = 4;
			SubClass = 2;
			Level = 9;
			Name = "Light Scorpid Armor";
			Name2 = "Light Scorpid Armor";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 291;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Bound Harness)
*
***************************************************************/

namespace Server.Items
{
	public class BoundHarness : Item
	{
		public BoundHarness() : base()
		{
			Id = 4968;
			Resistance[0] = 55;
			Bonding = 1;
			SellPrice = 90;
			AvailableClasses = 0x7FFF;
			Model = 9925;
			ObjectClass = 4;
			SubClass = 2;
			Level = 11;
			Name = "Bound Harness";
			Name2 = "Bound Harness";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 454;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Dark Iron Leather)
*
***************************************************************/

namespace Server.Items
{
	public class DarkIronLeather : Item
	{
		public DarkIronLeather() : base()
		{
			Id = 5108;
			Resistance[0] = 88;
			SellPrice = 1616;
			AvailableClasses = 0x7FFF;
			Model = 16882;
			ObjectClass = 4;
			SubClass = 2;
			Level = 32;
			ReqLevel = 27;
			Name = "Dark Iron Leather";
			Name2 = "Dark Iron Leather";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 8081;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
			Flags = 16;
		}
	}
}


/**************************************************************
*
*				(Barkshell Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class BarkshellTunic : Item
	{
		public BarkshellTunic() : base()
		{
			Id = 5316;
			Resistance[0] = 86;
			Bonding = 1;
			SellPrice = 1355;
			AvailableClasses = 0x7FFF;
			Model = 16870;
			ObjectClass = 4;
			SubClass = 2;
			Level = 25;
			Name = "Barkshell Tunic";
			Name2 = "Barkshell Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6778;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 80;
			StaminaBonus = 4;
			SpiritBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Dry Moss Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class DryMossTunic : Item
	{
		public DryMossTunic() : base()
		{
			Id = 5317;
			Resistance[0] = 86;
			Bonding = 1;
			SellPrice = 1360;
			AvailableClasses = 0x7FFF;
			Model = 8658;
			ObjectClass = 4;
			SubClass = 2;
			Level = 25;
			Name = "Dry Moss Tunic";
			Name2 = "Dry Moss Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6803;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 80;
			StaminaBonus = 8;
			AgilityBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Spore-covered Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class SporeCoveredTunic : Item
	{
		public SporeCoveredTunic() : base()
		{
			Id = 5341;
			Resistance[0] = 70;
			Bonding = 1;
			SellPrice = 368;
			AvailableClasses = 0x7FFF;
			Model = 8717;
			ObjectClass = 4;
			SubClass = 2;
			Level = 15;
			Name = "Spore-covered Tunic";
			Name2 = "Spore-covered Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1844;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 65;
			StaminaBonus = 1;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Barbaric Harness)
*
***************************************************************/

namespace Server.Items
{
	public class BarbaricHarness : Item
	{
		public BarbaricHarness() : base()
		{
			Id = 5739;
			Resistance[0] = 101;
			SellPrice = 2738;
			AvailableClasses = 0x7FFF;
			Model = 12368;
			ObjectClass = 4;
			SubClass = 2;
			Level = 38;
			ReqLevel = 33;
			Name = "Barbaric Harness";
			Name2 = "Barbaric Harness";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 13694;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Murloc Scale Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class MurlocScaleBreastplate : Item
	{
		public MurlocScaleBreastplate() : base()
		{
			Id = 5781;
			Resistance[0] = 76;
			Bonding = 2;
			SellPrice = 601;
			AvailableClasses = 0x7FFF;
			Model = 8908;
			ObjectClass = 4;
			SubClass = 2;
			Level = 19;
			ReqLevel = 14;
			Name = "Murloc Scale Breastplate";
			Name2 = "Murloc Scale Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3008;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 70;
			StrBonus = 5;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Thick Murloc Armor)
*
***************************************************************/

namespace Server.Items
{
	public class ThickMurlocArmor : Item
	{
		public ThickMurlocArmor() : base()
		{
			Id = 5782;
			Resistance[0] = 100;
			Bonding = 2;
			SellPrice = 3211;
			AvailableClasses = 0x7FFF;
			Model = 22393;
			ObjectClass = 4;
			SubClass = 2;
			Level = 34;
			ReqLevel = 29;
			Name = "Thick Murloc Armor";
			Name2 = "Thick Murloc Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 16055;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
			StrBonus = 9;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Snapbrook Armor)
*
***************************************************************/

namespace Server.Items
{
	public class SnapbrookArmor : Item
	{
		public SnapbrookArmor() : base()
		{
			Id = 5814;
			Resistance[0] = 94;
			Bonding = 1;
			SellPrice = 2351;
			AvailableClasses = 0x7FFF;
			Model = 16899;
			ObjectClass = 4;
			SubClass = 2;
			Level = 30;
			Name = "Snapbrook Armor";
			Name2 = "Snapbrook Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11756;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
			StrBonus = 4;
			IqBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Handstitched Leather Vest)
*
***************************************************************/

namespace Server.Items
{
	public class HandstitchedLeatherVest : Item
	{
		public HandstitchedLeatherVest() : base()
		{
			Id = 5957;
			Resistance[0] = 45;
			SellPrice = 40;
			AvailableClasses = 0x7FFF;
			Model = 9499;
			ObjectClass = 4;
			SubClass = 2;
			Level = 8;
			ReqLevel = 3;
			Name = "Handstitched Leather Vest";
			Name2 = "Handstitched Leather Vest";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 200;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Nomadic Vest)
*
***************************************************************/

namespace Server.Items
{
	public class NomadicVest : Item
	{
		public NomadicVest() : base()
		{
			Id = 6059;
			Resistance[0] = 33;
			Bonding = 1;
			SellPrice = 13;
			AvailableClasses = 0x7FFF;
			Model = 9930;
			ObjectClass = 4;
			SubClass = 2;
			Level = 5;
			Name = "Nomadic Vest";
			Name2 = "Nomadic Vest";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 65;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Footman Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class FootmanTunic : Item
	{
		public FootmanTunic() : base()
		{
			Id = 6085;
			Resistance[0] = 65;
			Bonding = 1;
			SellPrice = 243;
			AvailableClasses = 0x7FFF;
			Model = 11368;
			ObjectClass = 4;
			SubClass = 2;
			Level = 13;
			Name = "Footman Tunic";
			Name2 = "Footman Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1217;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 60;
			StaminaBonus = 2;
			AgilityBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Loch Croc Hide Vest)
*
***************************************************************/

namespace Server.Items
{
	public class LochCrocHideVest : Item
	{
		public LochCrocHideVest() : base()
		{
			Id = 6197;
			Resistance[0] = 81;
			Bonding = 2;
			SellPrice = 929;
			AvailableClasses = 0x7FFF;
			Model = 2644;
			ObjectClass = 4;
			SubClass = 2;
			Level = 22;
			ReqLevel = 17;
			Name = "Loch Croc Hide Vest";
			Name2 = "Loch Croc Hide Vest";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4646;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 75;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Pioneer Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class PioneerTunic : Item
	{
		public PioneerTunic() : base()
		{
			Id = 6268;
			Resistance[0] = 65;
			Bonding = 2;
			SellPrice = 234;
			AvailableClasses = 0x7FFF;
			Model = 17098;
			ObjectClass = 4;
			SubClass = 2;
			Level = 13;
			ReqLevel = 8;
			Name = "Pioneer Tunic";
			Name2 = "Pioneer Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 476;
			BuyPrice = 1171;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Emblazoned Chestpiece)
*
***************************************************************/

namespace Server.Items
{
	public class EmblazonedChestpiece : Item
	{
		public EmblazonedChestpiece() : base()
		{
			Id = 6396;
			Resistance[0] = 97;
			Bonding = 2;
			SellPrice = 2814;
			AvailableClasses = 0x7FFF;
			Model = 14602;
			ObjectClass = 4;
			SubClass = 2;
			Level = 32;
			ReqLevel = 27;
			Name = "Emblazoned Chestpiece";
			Name2 = "Emblazoned Chestpiece";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 14073;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
			AgilityBonus = 7;
			StaminaBonus = 6;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Imperial Leather Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class ImperialLeatherBreastplate : Item
	{
		public ImperialLeatherBreastplate() : base()
		{
			Id = 6430;
			Resistance[0] = 124;
			Bonding = 2;
			SellPrice = 9098;
			AvailableClasses = 0x7FFF;
			Model = 18471;
			ObjectClass = 4;
			SubClass = 2;
			Level = 46;
			ReqLevel = 41;
			Name = "Imperial Leather Breastplate";
			Name2 = "Imperial Leather Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 45493;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
			SpiritBonus = 7;
			StaminaBonus = 16;
		}
	}
}


/**************************************************************
*
*				(Armor of the Fang)
*
***************************************************************/

namespace Server.Items
{
	public class ArmorOfTheFang : Item
	{
		public ArmorOfTheFang() : base()
		{
			Id = 6473;
			Resistance[0] = 82;
			Bonding = 1;
			SellPrice = 1010;
			AvailableClasses = 0x7FFF;
			Model = 17091;
			ObjectClass = 4;
			SubClass = 2;
			Level = 23;
			ReqLevel = 18;
			Name = "Armor of the Fang";
			Name2 = "Armor of the Fang";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5053;
			Sets = 162;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 75;
			StrBonus = 2;
			IqBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Buckled Harness)
*
***************************************************************/

namespace Server.Items
{
	public class BuckledHarness : Item
	{
		public BuckledHarness() : base()
		{
			Id = 6523;
			Resistance[0] = 69;
			SellPrice = 284;
			AvailableClasses = 0x7FFF;
			Model = 14259;
			ObjectClass = 4;
			SubClass = 2;
			Level = 17;
			ReqLevel = 12;
			Name = "Buckled Harness";
			Name2 = "Buckled Harness";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1422;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Studded Leather Harness)
*
***************************************************************/

namespace Server.Items
{
	public class StuddedLeatherHarness : Item
	{
		public StuddedLeatherHarness() : base()
		{
			Id = 6524;
			Resistance[0] = 77;
			SellPrice = 574;
			AvailableClasses = 0x7FFF;
			Model = 12370;
			ObjectClass = 4;
			SubClass = 2;
			Level = 22;
			ReqLevel = 17;
			Name = "Studded Leather Harness";
			Name2 = "Studded Leather Harness";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2870;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 75;
		}
	}
}


/**************************************************************
*
*				(Grunt's Harness)
*
***************************************************************/

namespace Server.Items
{
	public class GruntsHarness : Item
	{
		public GruntsHarness() : base()
		{
			Id = 6525;
			Resistance[0] = 84;
			SellPrice = 1033;
			AvailableClasses = 0x7FFF;
			Model = 12371;
			ObjectClass = 4;
			SubClass = 2;
			Level = 27;
			ReqLevel = 22;
			Name = "Grunt's Harness";
			Name2 = "Grunt's Harness";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 5167;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 80;
		}
	}
}


/**************************************************************
*
*				(Battle Harness)
*
***************************************************************/

namespace Server.Items
{
	public class BattleHarness : Item
	{
		public BattleHarness() : base()
		{
			Id = 6526;
			Resistance[0] = 100;
			SellPrice = 2497;
			AvailableClasses = 0x7FFF;
			Model = 12372;
			ObjectClass = 4;
			SubClass = 2;
			Level = 37;
			ReqLevel = 32;
			Name = "Battle Harness";
			Name2 = "Battle Harness";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 12487;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Bard's Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class BardsTunic : Item
	{
		public BardsTunic() : base()
		{
			Id = 6552;
			Resistance[0] = 76;
			Bonding = 2;
			SellPrice = 601;
			AvailableClasses = 0x7FFF;
			Model = 14731;
			ObjectClass = 4;
			SubClass = 2;
			Level = 19;
			ReqLevel = 14;
			Name = "Bard's Tunic";
			Name2 = "Bard's Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 478;
			BuyPrice = 3009;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Scouting Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class ScoutingTunic : Item
	{
		public ScoutingTunic() : base()
		{
			Id = 6584;
			Resistance[0] = 86;
			Bonding = 2;
			SellPrice = 1416;
			AvailableClasses = 0x7FFF;
			Model = 14758;
			ObjectClass = 4;
			SubClass = 2;
			Level = 25;
			ReqLevel = 20;
			Name = "Scouting Tunic";
			Name2 = "Scouting Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 480;
			BuyPrice = 7082;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 80;
		}
	}
}


/**************************************************************
*
*				(Dervish Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class DervishTunic : Item
	{
		public DervishTunic() : base()
		{
			Id = 6603;
			Resistance[0] = 94;
			Bonding = 2;
			SellPrice = 2334;
			AvailableClasses = 0x7FFF;
			Model = 14773;
			ObjectClass = 4;
			SubClass = 2;
			Level = 30;
			ReqLevel = 25;
			Name = "Dervish Tunic";
			Name2 = "Dervish Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 481;
			BuyPrice = 11674;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Panther Armor)
*
***************************************************************/

namespace Server.Items
{
	public class PantherArmor : Item
	{
		public PantherArmor() : base()
		{
			Id = 6670;
			Resistance[0] = 89;
			Bonding = 1;
			SellPrice = 1672;
			AvailableClasses = 0x7FFF;
			Model = 12794;
			ObjectClass = 4;
			SubClass = 2;
			Level = 27;
			Name = "Panther Armor";
			Name2 = "Panther Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 8363;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 80;
			AgilityBonus = 9;
			StrBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Moonglow Vest)
*
***************************************************************/

namespace Server.Items
{
	public class MoonglowVest : Item
	{
		public MoonglowVest() : base()
		{
			Id = 6709;
			Resistance[0] = 74;
			Bonding = 2;
			SellPrice = 545;
			AvailableClasses = 0x7FFF;
			Model = 12924;
			ObjectClass = 4;
			SubClass = 2;
			Level = 18;
			ReqLevel = 13;
			Name = "Moonglow Vest";
			Name2 = "Moonglow Vest";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2726;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 65;
			IqBonus = 4;
			SpiritBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Grizzly Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class GrizzlyTunic : Item
	{
		public GrizzlyTunic() : base()
		{
			Id = 7335;
			Resistance[0] = 90;
			Bonding = 1;
			SellPrice = 1937;
			AvailableClasses = 0x7FFF;
			Model = 12482;
			ObjectClass = 4;
			SubClass = 2;
			Level = 28;
			Name = "Grizzly Tunic";
			Name2 = "Grizzly Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 9685;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Dusky Leather Armor)
*
***************************************************************/

namespace Server.Items
{
	public class DuskyLeatherArmor : Item
	{
		public DuskyLeatherArmor() : base()
		{
			Id = 7374;
			Resistance[0] = 102;
			Bonding = 2;
			SellPrice = 3760;
			AvailableClasses = 0x7FFF;
			Model = 14781;
			ObjectClass = 4;
			SubClass = 2;
			Level = 35;
			ReqLevel = 30;
			Name = "Dusky Leather Armor";
			Name2 = "Dusky Leather Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 18804;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
			AgilityBonus = 14;
		}
	}
}


/**************************************************************
*
*				(Green Whelp Armor)
*
***************************************************************/

namespace Server.Items
{
	public class GreenWhelpArmor : Item
	{
		public GreenWhelpArmor() : base()
		{
			Id = 7375;
			Resistance[0] = 102;
			Bonding = 2;
			SellPrice = 3773;
			AvailableClasses = 0x7FFF;
			Model = 25674;
			ObjectClass = 4;
			SubClass = 2;
			Level = 35;
			ReqLevel = 30;
			Name = "Green Whelp Armor";
			Name2 = "Green Whelp Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 18869;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
			SetSpell( 9160 , 1 , 0 , 10000 , 0 , -1 );
			IqBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Infiltrator Armor)
*
***************************************************************/

namespace Server.Items
{
	public class InfiltratorArmor : Item
	{
		public InfiltratorArmor() : base()
		{
			Id = 7407;
			Resistance[0] = 102;
			Bonding = 2;
			SellPrice = 3666;
			AvailableClasses = 0x7FFF;
			Model = 21900;
			ObjectClass = 4;
			SubClass = 2;
			Level = 35;
			ReqLevel = 30;
			Name = "Infiltrator Armor";
			Name2 = "Infiltrator Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 483;
			BuyPrice = 18333;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Sentinel Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class SentinelBreastplate : Item
	{
		public SentinelBreastplate() : base()
		{
			Id = 7439;
			Resistance[0] = 110;
			Bonding = 2;
			SellPrice = 5425;
			AvailableClasses = 0x7FFF;
			Model = 14995;
			ObjectClass = 4;
			SubClass = 2;
			Level = 40;
			ReqLevel = 35;
			Name = "Sentinel Breastplate";
			Name2 = "Sentinel Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 485;
			BuyPrice = 27127;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Ranger Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class RangerTunic : Item
	{
		public RangerTunic() : base()
		{
			Id = 7477;
			Resistance[0] = 121;
			Bonding = 2;
			SellPrice = 8124;
			AvailableClasses = 0x7FFF;
			Model = 17099;
			ObjectClass = 4;
			SubClass = 2;
			Level = 45;
			ReqLevel = 40;
			Name = "Ranger Tunic";
			Name2 = "Ranger Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 486;
			BuyPrice = 40624;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Cabalist Chestpiece)
*
***************************************************************/

namespace Server.Items
{
	public class CabalistChestpiece : Item
	{
		public CabalistChestpiece() : base()
		{
			Id = 7527;
			Resistance[0] = 132;
			Bonding = 2;
			SellPrice = 11284;
			AvailableClasses = 0x7FFF;
			Model = 17094;
			ObjectClass = 4;
			SubClass = 2;
			Level = 50;
			ReqLevel = 45;
			Name = "Cabalist Chestpiece";
			Name2 = "Cabalist Chestpiece";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 488;
			BuyPrice = 56423;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Ninja Armor)
*
***************************************************************/

namespace Server.Items
{
	public class NinjaArmor : Item
	{
		public NinjaArmor() : base()
		{
			Id = 7950;
			Resistance[0] = 46;
			Bonding = 1;
			SellPrice = 2260;
			AvailableClasses = 0x7FFF;
			Model = 16134;
			ObjectClass = 4;
			SubClass = 2;
			Level = 30;
			Name = "Ninja Armor";
			Name2 = "Ninja Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11302;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
		}
	}
}


/**************************************************************
*
*				(Heraldic Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class HeraldicBreastplate : Item
	{
		public HeraldicBreastplate() : base()
		{
			Id = 8119;
			Resistance[0] = 135;
			Bonding = 2;
			SellPrice = 12725;
			AvailableClasses = 0x7FFF;
			Model = 28737;
			ObjectClass = 4;
			SubClass = 2;
			Level = 51;
			ReqLevel = 46;
			Name = "Heraldic Breastplate";
			Name2 = "Heraldic Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 63629;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
			StrBonus = 4;
			StaminaBonus = 20;
		}
	}
}


/**************************************************************
*
*				(Nightscape Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class NightscapeTunic : Item
	{
		public NightscapeTunic() : base()
		{
			Id = 8175;
			Resistance[0] = 113;
			Bonding = 2;
			SellPrice = 5971;
			AvailableClasses = 0x7FFF;
			Model = 16482;
			ObjectClass = 4;
			SubClass = 2;
			Level = 41;
			ReqLevel = 36;
			Name = "Nightscape Tunic";
			Name2 = "Nightscape Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 29857;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
			AgilityBonus = 15;
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Wild Leather Vest)
*
***************************************************************/

namespace Server.Items
{
	public class WildLeatherVest : Item
	{
		public WildLeatherVest() : base()
		{
			Id = 8211;
			Resistance[0] = 121;
			Bonding = 2;
			SellPrice = 8002;
			AvailableClasses = 0x7FFF;
			Model = 25689;
			ObjectClass = 4;
			SubClass = 2;
			Level = 45;
			ReqLevel = 40;
			Name = "Wild Leather Vest";
			Name2 = "Wild Leather Vest";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 486;
			BuyPrice = 40012;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Serpentskin Armor)
*
***************************************************************/

namespace Server.Items
{
	public class SerpentskinArmor : Item
	{
		public SerpentskinArmor() : base()
		{
			Id = 8258;
			Resistance[0] = 146;
			Bonding = 2;
			SellPrice = 17396;
			AvailableClasses = 0x7FFF;
			Model = 18470;
			ObjectClass = 4;
			SubClass = 2;
			Level = 56;
			ReqLevel = 51;
			Name = "Serpentskin Armor";
			Name2 = "Serpentskin Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 86983;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
			SpiritBonus = 10;
			StaminaBonus = 15;
			IqBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Traveler's Jerkin)
*
***************************************************************/

namespace Server.Items
{
	public class TravelersJerkin : Item
	{
		public TravelersJerkin() : base()
		{
			Id = 8296;
			Resistance[0] = 156;
			Bonding = 2;
			SellPrice = 20861;
			AvailableClasses = 0x7FFF;
			Model = 17312;
			ObjectClass = 4;
			SubClass = 2;
			Level = 61;
			ReqLevel = 56;
			Name = "Traveler's Jerkin";
			Name2 = "Traveler's Jerkin";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 104305;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
			SpiritBonus = 21;
			StaminaBonus = 6;
			IqBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Feathered Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class FeatheredBreastplate : Item
	{
		public FeatheredBreastplate() : base()
		{
			Id = 8349;
			Resistance[0] = 146;
			Bonding = 2;
			SellPrice = 14478;
			AvailableClasses = 0x7FFF;
			Model = 8660;
			ObjectClass = 4;
			SubClass = 2;
			Level = 50;
			ReqLevel = 45;
			Name = "Feathered Breastplate";
			Name2 = "Feathered Breastplate";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 72391;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 100;
			IqBonus = 24;
			SpiritBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Spirewind Fetter)
*
***************************************************************/

namespace Server.Items
{
	public class SpirewindFetter : Item
	{
		public SpirewindFetter() : base()
		{
			Id = 9406;
			Resistance[0] = 112;
			Bonding = 2;
			SellPrice = 4161;
			AvailableClasses = 0x7FFF;
			Model = 18284;
			ObjectClass = 4;
			SubClass = 2;
			Level = 35;
			ReqLevel = 30;
			Name = "Spirewind Fetter";
			Name2 = "Spirewind Fetter";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 20807;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 100;
			SpiritBonus = 12;
			StrBonus = 7;
			StaminaBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Jinxed Hoodoo Skin)
*
***************************************************************/

namespace Server.Items
{
	public class JinxedHoodooSkin : Item
	{
		public JinxedHoodooSkin() : base()
		{
			Id = 9473;
			Resistance[0] = 144;
			Bonding = 1;
			SellPrice = 13241;
			AvailableClasses = 0x7FFF;
			Model = 18386;
			ObjectClass = 4;
			SubClass = 2;
			Level = 49;
			ReqLevel = 44;
			Name = "Jinxed Hoodoo Skin";
			Name2 = "Jinxed Hoodoo Skin";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 66207;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 100;
			IqBonus = 20;
			StrBonus = 8;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Gypsy Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class GypsyTunic : Item
	{
		public GypsyTunic() : base()
		{
			Id = 9757;
			Resistance[0] = 70;
			Bonding = 2;
			SellPrice = 363;
			AvailableClasses = 0x7FFF;
			Model = 19029;
			ObjectClass = 4;
			SubClass = 2;
			Level = 15;
			ReqLevel = 10;
			Name = "Gypsy Tunic";
			Name2 = "Gypsy Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 476;
			BuyPrice = 1819;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Bandit Jerkin)
*
***************************************************************/

namespace Server.Items
{
	public class BanditJerkin : Item
	{
		public BanditJerkin() : base()
		{
			Id = 9782;
			Resistance[0] = 82;
			Bonding = 2;
			SellPrice = 1113;
			AvailableClasses = 0x7FFF;
			Model = 28430;
			ObjectClass = 4;
			SubClass = 2;
			Level = 23;
			ReqLevel = 18;
			Name = "Bandit Jerkin";
			Name2 = "Bandit Jerkin";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 479;
			BuyPrice = 5568;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 75;
		}
	}
}


/**************************************************************
*
*				(Superior Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class SuperiorTunic : Item
	{
		public SuperiorTunic() : base()
		{
			Id = 9809;
			Resistance[0] = 90;
			Bonding = 2;
			SellPrice = 1855;
			AvailableClasses = 0x7FFF;
			Model = 27758;
			ObjectClass = 4;
			SubClass = 2;
			Level = 28;
			ReqLevel = 23;
			Name = "Superior Tunic";
			Name2 = "Superior Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 481;
			BuyPrice = 9276;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Scaled Leather Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class ScaledLeatherTunic : Item
	{
		public ScaledLeatherTunic() : base()
		{
			Id = 9835;
			Resistance[0] = 98;
			Bonding = 2;
			SellPrice = 3053;
			AvailableClasses = 0x7FFF;
			Model = 11580;
			ObjectClass = 4;
			SubClass = 2;
			Level = 33;
			ReqLevel = 28;
			Name = "Scaled Leather Tunic";
			Name2 = "Scaled Leather Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 482;
			BuyPrice = 15266;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Archer's Jerkin)
*
***************************************************************/

namespace Server.Items
{
	public class ArchersJerkin : Item
	{
		public ArchersJerkin() : base()
		{
			Id = 9854;
			Resistance[0] = 106;
			Bonding = 2;
			SellPrice = 4935;
			AvailableClasses = 0x7FFF;
			Model = 14068;
			ObjectClass = 4;
			SubClass = 2;
			Level = 38;
			ReqLevel = 33;
			Name = "Archer's Jerkin";
			Name2 = "Archer's Jerkin";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 484;
			BuyPrice = 24677;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Huntsman's Armor)
*
***************************************************************/

namespace Server.Items
{
	public class HuntsmansArmor : Item
	{
		public HuntsmansArmor() : base()
		{
			Id = 9887;
			Resistance[0] = 117;
			Bonding = 2;
			SellPrice = 7071;
			AvailableClasses = 0x7FFF;
			Model = 18903;
			ObjectClass = 4;
			SubClass = 2;
			Level = 43;
			ReqLevel = 38;
			Name = "Huntsman's Armor";
			Name2 = "Huntsman's Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 486;
			BuyPrice = 35357;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Tracker's Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class TrackersTunic : Item
	{
		public TrackersTunic() : base()
		{
			Id = 9924;
			Resistance[0] = 129;
			Bonding = 2;
			SellPrice = 10276;
			AvailableClasses = 0x7FFF;
			Model = 18934;
			ObjectClass = 4;
			SubClass = 2;
			Level = 48;
			ReqLevel = 43;
			Name = "Tracker's Tunic";
			Name2 = "Tracker's Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 487;
			BuyPrice = 51380;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Chieftain's Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class ChieftainsBreastplate : Item
	{
		public ChieftainsBreastplate() : base()
		{
			Id = 9950;
			Resistance[0] = 139;
			Bonding = 2;
			SellPrice = 13418;
			AvailableClasses = 0x7FFF;
			Model = 18943;
			ObjectClass = 4;
			SubClass = 2;
			Level = 53;
			ReqLevel = 48;
			Name = "Chieftain's Breastplate";
			Name2 = "Chieftain's Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 489;
			BuyPrice = 67091;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Righteous Armor)
*
***************************************************************/

namespace Server.Items
{
	public class RighteousArmor : Item
	{
		public RighteousArmor() : base()
		{
			Id = 10070;
			Resistance[0] = 144;
			Bonding = 2;
			SellPrice = 15482;
			AvailableClasses = 0x7FFF;
			Model = 19012;
			ObjectClass = 4;
			SubClass = 2;
			Level = 55;
			ReqLevel = 50;
			Name = "Righteous Armor";
			Name2 = "Righteous Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 490;
			BuyPrice = 77411;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Wanderer's Armor)
*
***************************************************************/

namespace Server.Items
{
	public class WanderersArmor : Item
	{
		public WanderersArmor() : base()
		{
			Id = 10105;
			Resistance[0] = 154;
			Bonding = 2;
			SellPrice = 19942;
			AvailableClasses = 0x7FFF;
			Model = 27716;
			ObjectClass = 4;
			SubClass = 2;
			Level = 60;
			ReqLevel = 55;
			Name = "Wanderer's Armor";
			Name2 = "Wanderer's Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 491;
			BuyPrice = 99711;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Mighty Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class MightyTunic : Item
	{
		public MightyTunic() : base()
		{
			Id = 10151;
			Resistance[0] = 163;
			Bonding = 2;
			SellPrice = 25456;
			AvailableClasses = 0x7FFF;
			Model = 27739;
			ObjectClass = 4;
			SubClass = 2;
			Level = 64;
			ReqLevel = 59;
			Name = "Mighty Tunic";
			Name2 = "Mighty Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 493;
			BuyPrice = 127283;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Swashbuckler's Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class SwashbucklersBreastplate : Item
	{
		public SwashbucklersBreastplate() : base()
		{
			Id = 10182;
			Resistance[0] = 150;
			Bonding = 2;
			SellPrice = 18370;
			AvailableClasses = 0x7FFF;
			Model = 19002;
			ObjectClass = 4;
			SubClass = 2;
			Level = 58;
			ReqLevel = 53;
			Name = "Swashbuckler's Breastplate";
			Name2 = "Swashbuckler's Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 491;
			BuyPrice = 91850;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Nightshade Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class NightshadeTunic : Item
	{
		public NightshadeTunic() : base()
		{
			Id = 10220;
			Resistance[0] = 160;
			Bonding = 2;
			SellPrice = 23263;
			AvailableClasses = 0x7FFF;
			Model = 18977;
			ObjectClass = 4;
			SubClass = 2;
			Level = 63;
			ReqLevel = 58;
			Name = "Nightshade Tunic";
			Name2 = "Nightshade Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 492;
			BuyPrice = 116316;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Adventurer's Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class AdventurersTunic : Item
	{
		public AdventurersTunic() : base()
		{
			Id = 10264;
			Resistance[0] = 165;
			Bonding = 2;
			SellPrice = 26729;
			AvailableClasses = 0x7FFF;
			Model = 8664;
			ObjectClass = 4;
			SubClass = 2;
			Level = 65;
			ReqLevel = 60;
			Name = "Adventurer's Tunic";
			Name2 = "Adventurer's Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 493;
			BuyPrice = 133648;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Blackened Defias Armor)
*
***************************************************************/

namespace Server.Items
{
	public class BlackenedDefiasArmor : Item
	{
		public BlackenedDefiasArmor() : base()
		{
			Id = 10399;
			Resistance[0] = 92;
			Bonding = 1;
			SellPrice = 1467;
			AvailableClasses = 0x7FFF;
			Model = 9123;
			ObjectClass = 4;
			SubClass = 2;
			Level = 24;
			ReqLevel = 19;
			Name = "Blackened Defias Armor";
			Name2 = "Blackened Defias Armor";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 7335;
			Sets = 161;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 90;
			StaminaBonus = 11;
			AgilityBonus = 3;
			StrBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Quillward Harness)
*
***************************************************************/

namespace Server.Items
{
	public class QuillwardHarness : Item
	{
		public QuillwardHarness() : base()
		{
			Id = 10583;
			Resistance[0] = 120;
			Bonding = 2;
			SellPrice = 6191;
			AvailableClasses = 0x7FFF;
			Model = 28808;
			ObjectClass = 4;
			SubClass = 2;
			Level = 39;
			ReqLevel = 34;
			Name = "Quillward Harness";
			Name2 = "Quillward Harness";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 30956;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 100;
			AgilityBonus = 19;
			StrBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Hakkar'i Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class HakkariBreastplate : Item
	{
		public HakkariBreastplate() : base()
		{
			Id = 10781;
			Resistance[0] = 144;
			Bonding = 1;
			SellPrice = 15071;
			AvailableClasses = 0x7FFF;
			Model = 18470;
			ObjectClass = 4;
			SubClass = 2;
			Level = 55;
			Name = "Hakkar'i Breastplate";
			Name2 = "Hakkar'i Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 75359;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
			StaminaBonus = 22;
			AgilityBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Surveyor's Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class SurveyorsTunic : Item
	{
		public SurveyorsTunic() : base()
		{
			Id = 10827;
			Resistance[0] = 129;
			Bonding = 1;
			SellPrice = 10238;
			AvailableClasses = 0x7FFF;
			Model = 28205;
			ObjectClass = 4;
			SubClass = 2;
			Level = 48;
			Name = "Surveyor's Tunic";
			Name2 = "Surveyor's Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 51191;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
			StrBonus = 11;
			IqBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Blazewind Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class BlazewindBreastplate : Item
	{
		public BlazewindBreastplate() : base()
		{
			Id = 11193;
			Resistance[0] = 148;
			Bonding = 1;
			SellPrice = 16938;
			AvailableClasses = 0x7FFF;
			Model = 19002;
			ObjectClass = 4;
			SubClass = 2;
			Level = 57;
			Name = "Blazewind Breastplate";
			Name2 = "Blazewind Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 84692;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
			AgilityBonus = 23;
			StaminaBonus = 5;
			StrBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Scavenger Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class ScavengerTunic : Item
	{
		public ScavengerTunic() : base()
		{
			Id = 11851;
			Resistance[0] = 33;
			Bonding = 1;
			SellPrice = 12;
			AvailableClasses = 0x7FFF;
			Model = 28249;
			ObjectClass = 4;
			SubClass = 2;
			Level = 5;
			Name = "Scavenger Tunic";
			Name2 = "Scavenger Tunic";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 60;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Plainstalker Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class PlainstalkerTunic : Item
	{
		public PlainstalkerTunic() : base()
		{
			Id = 11876;
			Resistance[0] = 146;
			Bonding = 1;
			SellPrice = 16287;
			AvailableClasses = 0x7FFF;
			Model = 28233;
			ObjectClass = 4;
			SubClass = 2;
			Level = 56;
			Name = "Plainstalker Tunic";
			Name2 = "Plainstalker Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 81437;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
			StaminaBonus = 23;
			AgilityBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Brindlethorn Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class BrindlethornTunic : Item
	{
		public BrindlethornTunic() : base()
		{
			Id = 12104;
			Resistance[0] = 154;
			Bonding = 1;
			SellPrice = 20879;
			AvailableClasses = 0x7FFF;
			Model = 28095;
			ObjectClass = 4;
			SubClass = 2;
			Level = 60;
			Name = "Brindlethorn Tunic";
			Name2 = "Brindlethorn Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 104395;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
			SetSpell( 9331 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 22;
		}
	}
}


/**************************************************************
*
*				(Nightbrace Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class NightbraceTunic : Item
	{
		public NightbraceTunic() : base()
		{
			Id = 12603;
			Resistance[0] = 172;
			Bonding = 1;
			SellPrice = 25048;
			AvailableClasses = 0x7FFF;
			Model = 8725;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 2;
			Level = 61;
			ReqLevel = 56;
			Name = "Nightbrace Tunic";
			Name2 = "Nightbrace Tunic";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 125244;
			Resistance[5] = 10;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 100;
			SetSpell( 14056 , 1 , 0 , -1 , 0 , -1 );
			AgilityBonus = 5;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Breastplate of Bloodthirst)
*
***************************************************************/

namespace Server.Items
{
	public class BreastplateOfBloodthirst : Item
	{
		public BreastplateOfBloodthirst() : base()
		{
			Id = 12757;
			Resistance[0] = 190;
			Bonding = 1;
			SellPrice = 35192;
			AvailableClasses = 0x7FFF;
			Model = 23200;
			ObjectClass = 4;
			SubClass = 2;
			Level = 62;
			Name = "Breastplate of Bloodthirst";
			Name2 = "Breastplate of Bloodthirst";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 175964;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 120;
			SetSpell( 7598 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 13669 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 20;
			StrBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Mixologist's Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class MixologistsTunic : Item
	{
		public MixologistsTunic() : base()
		{
			Id = 12793;
			Resistance[0] = 144;
			Bonding = 1;
			SellPrice = 16538;
			AvailableClasses = 0x7FFF;
			Model = 23266;
			ObjectClass = 4;
			SubClass = 2;
			Level = 55;
			ReqLevel = 50;
			Name = "Mixologist's Tunic";
			Name2 = "Mixologist's Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 82691;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
			StrBonus = 15;
			StaminaBonus = 14;
			AgilityBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Starsight Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class StarsightTunic : Item
	{
		public StarsightTunic() : base()
		{
			Id = 12988;
			Resistance[0] = 89;
			Bonding = 2;
			SellPrice = 1137;
			AvailableClasses = 0x7FFF;
			Model = 28375;
			ObjectClass = 4;
			SubClass = 2;
			Level = 22;
			ReqLevel = 17;
			Name = "Starsight Tunic";
			Name2 = "Starsight Tunic";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 5687;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 90;
			StaminaBonus = 4;
			IqBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Cow King's Hide)
*
***************************************************************/

namespace Server.Items
{
	public class CowKingsHide : Item
	{
		public CowKingsHide() : base()
		{
			Id = 13009;
			Resistance[6] = 10;
			Resistance[0] = 148;
			Bonding = 2;
			SellPrice = 15167;
			AvailableClasses = 0x7FFF;
			Model = 28700;
			Resistance[2] = 10;
			Resistance[4] = 10;
			ObjectClass = 4;
			SubClass = 2;
			Level = 51;
			ReqLevel = 46;
			Name = "Cow King's Hide";
			Name2 = "Cow King's Hide";
			Resistance[3] = 10;
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 75839;
			Resistance[5] = 10;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 100;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Dragonstalker Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class DragonstalkerTunic : Item
	{
		public DragonstalkerTunic() : base()
		{
			Id = 13092;
			Resistance[0] = 266;
			Bonding = 1;
			SellPrice = 30173;
			AvailableClasses = 0x7FFF;
			Model = 23607;
			ObjectClass = 4;
			SubClass = 2;
			Level = 63;
			ReqLevel = 58;
			Name = "Dragonstalker Tunic";
			Name2 = "Dragonstalker Tunic";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 150865;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			SetSpell( 9346 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 25;
			IqBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Wolffear Harness)
*
***************************************************************/

namespace Server.Items
{
	public class WolffearHarness : Item
	{
		public WolffearHarness() : base()
		{
			Id = 13110;
			Resistance[0] = 113;
			Bonding = 2;
			SellPrice = 4968;
			AvailableClasses = 0x7FFF;
			Model = 28368;
			ObjectClass = 4;
			SubClass = 2;
			Level = 36;
			ReqLevel = 31;
			Name = "Wolffear Harness";
			Name2 = "Wolffear Harness";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 24840;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 100;
			AgilityBonus = 17;
			IqBonus = 3;
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Songbird Blouse)
*
***************************************************************/

namespace Server.Items
{
	public class SongbirdBlouse : Item
	{
		public SongbirdBlouse() : base()
		{
			Id = 13378;
			Resistance[0] = 165;
			Bonding = 1;
			SellPrice = 21972;
			AvailableClasses = 0x7FFF;
			Model = 24066;
			ObjectClass = 4;
			SubClass = 2;
			Level = 58;
			ReqLevel = 53;
			Name = "Songbird Blouse";
			Name2 = "Songbird Blouse";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 109860;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 100;
			AgilityBonus = 13;
			IqBonus = 13;
			StrBonus = 13;
			SpiritBonus = 13;
			StaminaBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Tombstone Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class TombstoneBreastplate : Item
	{
		public TombstoneBreastplate() : base()
		{
			Id = 13944;
			Resistance[0] = 174;
			Bonding = 1;
			SellPrice = 26808;
			AvailableClasses = 0x7FFF;
			Model = 28632;
			ObjectClass = 4;
			SubClass = 2;
			Level = 62;
			ReqLevel = 57;
			Name = "Tombstone Breastplate";
			Name2 = "Tombstone Breastplate";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 134043;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 100;
			SetSpell( 7598 , 1 , 0 , -1 , 0 , -1 );
			StrBonus = 4;
			StaminaBonus = 10;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Prospector's Chestpiece)
*
***************************************************************/

namespace Server.Items
{
	public class ProspectorsChestpiece : Item
	{
		public ProspectorsChestpiece() : base()
		{
			Id = 14562;
			Resistance[0] = 82;
			Bonding = 2;
			SellPrice = 1039;
			AvailableClasses = 0x7FFF;
			Model = 27518;
			ObjectClass = 4;
			SubClass = 2;
			Level = 23;
			ReqLevel = 18;
			Name = "Prospector's Chestpiece";
			Name2 = "Prospector's Chestpiece";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5199;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 75;
			AgilityBonus = 6;
			StaminaBonus = 3;
			StrBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Bristlebark Blouse)
*
***************************************************************/

namespace Server.Items
{
	public class BristlebarkBlouse : Item
	{
		public BristlebarkBlouse() : base()
		{
			Id = 14570;
			Resistance[0] = 90;
			Bonding = 2;
			SellPrice = 1870;
			AvailableClasses = 0x7FFF;
			Model = 27669;
			ObjectClass = 4;
			SubClass = 2;
			Level = 28;
			ReqLevel = 23;
			Name = "Bristlebark Blouse";
			Name2 = "Bristlebark Blouse";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 9350;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
			AgilityBonus = 7;
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Dokebi Chestguard)
*
***************************************************************/

namespace Server.Items
{
	public class DokebiChestguard : Item
	{
		public DokebiChestguard() : base()
		{
			Id = 14581;
			Resistance[0] = 98;
			Bonding = 2;
			SellPrice = 2912;
			AvailableClasses = 0x7FFF;
			Model = 27962;
			ObjectClass = 4;
			SubClass = 2;
			Level = 33;
			ReqLevel = 28;
			Name = "Dokebi Chestguard";
			Name2 = "Dokebi Chestguard";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 14562;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
			StaminaBonus = 10;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Hawkeye's Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class HawkeyesTunic : Item
	{
		public HawkeyesTunic() : base()
		{
			Id = 14592;
			Resistance[0] = 110;
			Bonding = 2;
			SellPrice = 5594;
			AvailableClasses = 0x7FFF;
			Model = 27979;
			ObjectClass = 4;
			SubClass = 2;
			Level = 40;
			ReqLevel = 35;
			Name = "Hawkeye's Tunic";
			Name2 = "Hawkeye's Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 27974;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
			StaminaBonus = 8;
			AgilityBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Warden's Wraps)
*
***************************************************************/

namespace Server.Items
{
	public class WardensWraps : Item
	{
		public WardensWraps() : base()
		{
			Id = 14601;
			Resistance[0] = 120;
			Bonding = 2;
			SellPrice = 7307;
			AvailableClasses = 0x7FFF;
			Model = 14995;
			ObjectClass = 4;
			SubClass = 2;
			Level = 44;
			ReqLevel = 39;
			Name = "Warden's Wraps";
			Name2 = "Warden's Wraps";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 36535;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
			AgilityBonus = 12;
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Cadaverous Armor)
*
***************************************************************/

namespace Server.Items
{
	public class CadaverousArmor : Item
	{
		public CadaverousArmor() : base()
		{
			Id = 14637;
			Resistance[0] = 172;
			Bonding = 1;
			SellPrice = 25048;
			AvailableClasses = 0x7FFF;
			Model = 25249;
			ObjectClass = 4;
			SubClass = 2;
			Level = 61;
			ReqLevel = 56;
			Name = "Cadaverous Armor";
			Name2 = "Cadaverous Armor";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 125244;
			Sets = 121;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 100;
			SetSpell( 14052 , 1 , 0 , -1 , 0 , -1 );
			StrBonus = 8;
			AgilityBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Scorpashi Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class ScorpashiBreastplate : Item
	{
		public ScorpashiBreastplate() : base()
		{
			Id = 14655;
			Resistance[0] = 131;
			Bonding = 2;
			SellPrice = 10392;
			AvailableClasses = 0x7FFF;
			Model = 27576;
			ObjectClass = 4;
			SubClass = 2;
			Level = 49;
			ReqLevel = 44;
			Name = "Scorpashi Breastplate";
			Name2 = "Scorpashi Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 51962;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
			AgilityBonus = 17;
			StaminaBonus = 8;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Keeper's Armor)
*
***************************************************************/

namespace Server.Items
{
	public class KeepersArmor : Item
	{
		public KeepersArmor() : base()
		{
			Id = 14664;
			Resistance[0] = 142;
			Bonding = 2;
			SellPrice = 15058;
			AvailableClasses = 0x7FFF;
			Model = 27564;
			ObjectClass = 4;
			SubClass = 2;
			Level = 54;
			ReqLevel = 49;
			Name = "Keeper's Armor";
			Name2 = "Keeper's Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 75293;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
			StaminaBonus = 9;
			IqBonus = 18;
			AgilityBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Pridelord Armor)
*
***************************************************************/

namespace Server.Items
{
	public class PridelordArmor : Item
	{
		public PridelordArmor() : base()
		{
			Id = 14670;
			Resistance[0] = 152;
			Bonding = 2;
			SellPrice = 20396;
			AvailableClasses = 0x7FFF;
			Model = 27649;
			ObjectClass = 4;
			SubClass = 2;
			Level = 59;
			ReqLevel = 54;
			Name = "Pridelord Armor";
			Name2 = "Pridelord Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 101980;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
			AgilityBonus = 24;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Indomitable Vest)
*
***************************************************************/

namespace Server.Items
{
	public class IndomitableVest : Item
	{
		public IndomitableVest() : base()
		{
			Id = 14680;
			Resistance[0] = 163;
			Bonding = 2;
			SellPrice = 25101;
			AvailableClasses = 0x7FFF;
			Model = 18470;
			ObjectClass = 4;
			SubClass = 2;
			Level = 64;
			ReqLevel = 59;
			Name = "Indomitable Vest";
			Name2 = "Indomitable Vest";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 125507;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
			StaminaBonus = 5;
			IqBonus = 23;
			SpiritBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Primal Wraps)
*
***************************************************************/

namespace Server.Items
{
	public class PrimalWraps : Item
	{
		public PrimalWraps() : base()
		{
			Id = 15010;
			Resistance[0] = 58;
			Bonding = 2;
			SellPrice = 163;
			AvailableClasses = 0x7FFF;
			Model = 9536;
			ObjectClass = 4;
			SubClass = 2;
			Level = 11;
			ReqLevel = 6;
			Name = "Primal Wraps";
			Name2 = "Primal Wraps";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 475;
			BuyPrice = 815;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Lupine Vest)
*
***************************************************************/

namespace Server.Items
{
	public class LupineVest : Item
	{
		public LupineVest() : base()
		{
			Id = 15018;
			Resistance[0] = 78;
			Bonding = 2;
			SellPrice = 706;
			AvailableClasses = 0x7FFF;
			Model = 3390;
			ObjectClass = 4;
			SubClass = 2;
			Level = 20;
			ReqLevel = 15;
			Name = "Lupine Vest";
			Name2 = "Lupine Vest";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 478;
			BuyPrice = 3531;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Volcanic Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class VolcanicBreastplate : Item
	{
		public VolcanicBreastplate() : base()
		{
			Id = 15053;
			Resistance[0] = 268;
			Bonding = 2;
			SellPrice = 17275;
			AvailableClasses = 0x7FFF;
			Model = 25682;
			Resistance[2] = 20;
			ObjectClass = 4;
			SubClass = 2;
			Level = 57;
			ReqLevel = 52;
			Name = "Volcanic Breastplate";
			Name2 = "Volcanic Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 86377;
			Sets = 141;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Stormshroud Armor)
*
***************************************************************/

namespace Server.Items
{
	public class StormshroudArmor : Item
	{
		public StormshroudArmor() : base()
		{
			Id = 15056;
			Resistance[0] = 163;
			Bonding = 2;
			SellPrice = 20966;
			AvailableClasses = 0x7FFF;
			Model = 8682;
			ObjectClass = 4;
			SubClass = 2;
			Level = 57;
			ReqLevel = 52;
			Name = "Stormshroud Armor";
			Name2 = "Stormshroud Armor";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 104834;
			Sets = 142;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 100;
			SetSpell( 7598 , 1 , 0 , 3600000 , 0 , 600000 );
			SetSpell( 13669 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Living Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class LivingBreastplate : Item
	{
		public LivingBreastplate() : base()
		{
			Id = 15059;
			Resistance[0] = 169;
			Bonding = 2;
			SellPrice = 24776;
			AvailableClasses = 0x7FFF;
			Model = 25688;
			ObjectClass = 4;
			SubClass = 2;
			Level = 60;
			ReqLevel = 55;
			Name = "Living Breastplate";
			Name2 = "Living Breastplate";
			Resistance[3] = 5;
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 123882;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 100;
			SetSpell( 9315 , 1 , 0 , 3600000 , 0 , 600000 );
			IqBonus = 25;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Warbear Harness)
*
***************************************************************/

namespace Server.Items
{
	public class WarbearHarness : Item
	{
		public WarbearHarness() : base()
		{
			Id = 15064;
			Resistance[0] = 158;
			Bonding = 2;
			SellPrice = 19717;
			AvailableClasses = 0x7FFF;
			Model = 12368;
			ObjectClass = 4;
			SubClass = 2;
			Level = 55;
			ReqLevel = 50;
			Name = "Warbear Harness";
			Name2 = "Warbear Harness";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 98585;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 100;
			StaminaBonus = 27;
			StrBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Ironfeather Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class IronfeatherBreastplate : Item
	{
		public IronfeatherBreastplate() : base()
		{
			Id = 15066;
			Resistance[0] = 165;
			Bonding = 2;
			SellPrice = 23650;
			AvailableClasses = 0x7FFF;
			Model = 25699;
			ObjectClass = 4;
			SubClass = 2;
			Level = 58;
			ReqLevel = 53;
			Name = "Ironfeather Breastplate";
			Name2 = "Ironfeather Breastplate";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 118252;
			Sets = 144;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 100;
			IqBonus = 28;
			SpiritBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Frostsaber Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class FrostsaberTunic : Item
	{
		public FrostsaberTunic() : base()
		{
			Id = 15068;
			Resistance[0] = 158;
			Bonding = 2;
			SellPrice = 21835;
			AvailableClasses = 0x7FFF;
			Model = 19012;
			Resistance[4] = 18;
			ObjectClass = 4;
			SubClass = 2;
			Level = 62;
			ReqLevel = 57;
			Name = "Frostsaber Tunic";
			Name2 = "Frostsaber Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 109178;
			Resistance[5] = 18;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Chimeric Vest)
*
***************************************************************/

namespace Server.Items
{
	public class ChimericVest : Item
	{
		public ChimericVest() : base()
		{
			Id = 15075;
			Resistance[6] = 16;
			Resistance[0] = 150;
			Bonding = 2;
			SellPrice = 18449;
			AvailableClasses = 0x7FFF;
			Model = 25704;
			ObjectClass = 4;
			SubClass = 2;
			Level = 58;
			ReqLevel = 53;
			Name = "Chimeric Vest";
			Name2 = "Chimeric Vest";
			Resistance[3] = 17;
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 92245;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Wicked Leather Armor)
*
***************************************************************/

namespace Server.Items
{
	public class WickedLeatherArmor : Item
	{
		public WickedLeatherArmor() : base()
		{
			Id = 15085;
			Resistance[0] = 156;
			Bonding = 2;
			SellPrice = 22732;
			AvailableClasses = 0x7FFF;
			Model = 25721;
			ObjectClass = 4;
			SubClass = 2;
			Level = 61;
			ReqLevel = 56;
			Name = "Wicked Leather Armor";
			Name2 = "Wicked Leather Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 113662;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
			AgilityBonus = 25;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Runic Leather Armor)
*
***************************************************************/

namespace Server.Items
{
	public class RunicLeatherArmor : Item
	{
		public RunicLeatherArmor() : base()
		{
			Id = 15090;
			Resistance[0] = 158;
			Bonding = 2;
			SellPrice = 22002;
			AvailableClasses = 0x7FFF;
			Model = 25731;
			ObjectClass = 4;
			SubClass = 2;
			Level = 62;
			ReqLevel = 57;
			Name = "Runic Leather Armor";
			Name2 = "Runic Leather Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 110012;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
			SpiritBonus = 21;
			IqBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Rigid Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class RigidTunic : Item
	{
		public RigidTunic() : base()
		{
			Id = 15118;
			Resistance[0] = 87;
			Bonding = 2;
			SellPrice = 1562;
			AvailableClasses = 0x7FFF;
			Model = 27877;
			ObjectClass = 4;
			SubClass = 2;
			Level = 26;
			ReqLevel = 21;
			Name = "Rigid Tunic";
			Name2 = "Rigid Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 480;
			BuyPrice = 7812;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 80;
		}
	}
}


/**************************************************************
*
*				(Robust Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class RobustTunic : Item
	{
		public RobustTunic() : base()
		{
			Id = 15128;
			Resistance[0] = 95;
			Bonding = 2;
			SellPrice = 2425;
			AvailableClasses = 0x7FFF;
			Model = 27882;
			ObjectClass = 4;
			SubClass = 2;
			Level = 31;
			ReqLevel = 26;
			Name = "Robust Tunic";
			Name2 = "Robust Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 482;
			BuyPrice = 12126;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Cutthroat's Vest)
*
***************************************************************/

namespace Server.Items
{
	public class CutthroatsVest : Item
	{
		public CutthroatsVest() : base()
		{
			Id = 15130;
			Resistance[0] = 100;
			Bonding = 2;
			SellPrice = 3252;
			AvailableClasses = 0x7FFF;
			Model = 9548;
			ObjectClass = 4;
			SubClass = 2;
			Level = 34;
			ReqLevel = 29;
			Name = "Cutthroat's Vest";
			Name2 = "Cutthroat's Vest";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 483;
			BuyPrice = 16262;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Ghostwalker Rags)
*
***************************************************************/

namespace Server.Items
{
	public class GhostwalkerRags : Item
	{
		public GhostwalkerRags() : base()
		{
			Id = 15144;
			Resistance[0] = 105;
			Bonding = 2;
			SellPrice = 4232;
			AvailableClasses = 0x7FFF;
			Model = 27689;
			ObjectClass = 4;
			SubClass = 2;
			Level = 37;
			ReqLevel = 32;
			Name = "Ghostwalker Rags";
			Name2 = "Ghostwalker Rags";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 484;
			BuyPrice = 21160;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Nocturnal Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class NocturnalTunic : Item
	{
		public NocturnalTunic() : base()
		{
			Id = 15159;
			Resistance[0] = 115;
			Bonding = 2;
			SellPrice = 6743;
			AvailableClasses = 0x7FFF;
			Model = 27728;
			ObjectClass = 4;
			SubClass = 2;
			Level = 42;
			ReqLevel = 37;
			Name = "Nocturnal Tunic";
			Name2 = "Nocturnal Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 485;
			BuyPrice = 33715;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Imposing Vest)
*
***************************************************************/

namespace Server.Items
{
	public class ImposingVest : Item
	{
		public ImposingVest() : base()
		{
			Id = 15164;
			Resistance[0] = 126;
			Bonding = 2;
			SellPrice = 9135;
			AvailableClasses = 0x7FFF;
			Model = 27914;
			ObjectClass = 4;
			SubClass = 2;
			Level = 47;
			ReqLevel = 42;
			Name = "Imposing Vest";
			Name2 = "Imposing Vest";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 487;
			BuyPrice = 45679;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Potent Armor)
*
***************************************************************/

namespace Server.Items
{
	public class PotentArmor : Item
	{
		public PotentArmor() : base()
		{
			Id = 15170;
			Resistance[0] = 137;
			Bonding = 2;
			SellPrice = 13103;
			AvailableClasses = 0x7FFF;
			Model = 27586;
			ObjectClass = 4;
			SubClass = 2;
			Level = 52;
			ReqLevel = 47;
			Name = "Potent Armor";
			Name2 = "Potent Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 489;
			BuyPrice = 65519;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Praetorian Padded Armor)
*
***************************************************************/

namespace Server.Items
{
	public class PraetorianPaddedArmor : Item
	{
		public PraetorianPaddedArmor() : base()
		{
			Id = 15179;
			Resistance[0] = 148;
			Bonding = 2;
			SellPrice = 18593;
			AvailableClasses = 0x7FFF;
			Model = 27663;
			ObjectClass = 4;
			SubClass = 2;
			Level = 57;
			ReqLevel = 52;
			Name = "Praetorian Padded Armor";
			Name2 = "Praetorian Padded Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 490;
			BuyPrice = 92965;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Grand Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class GrandBreastplate : Item
	{
		public GrandBreastplate() : base()
		{
			Id = 15195;
			Resistance[0] = 158;
			Bonding = 2;
			SellPrice = 23617;
			AvailableClasses = 0x7FFF;
			Model = 28018;
			ObjectClass = 4;
			SubClass = 2;
			Level = 62;
			ReqLevel = 57;
			Name = "Grand Breastplate";
			Name2 = "Grand Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 492;
			BuyPrice = 118089;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Grizzly Jerkin)
*
***************************************************************/

namespace Server.Items
{
	public class GrizzlyJerkin : Item
	{
		public GrizzlyJerkin() : base()
		{
			Id = 15304;
			Resistance[0] = 71;
			Bonding = 2;
			SellPrice = 414;
			AvailableClasses = 0x7FFF;
			Model = 12369;
			ObjectClass = 4;
			SubClass = 2;
			Level = 16;
			ReqLevel = 11;
			Name = "Grizzly Jerkin";
			Name2 = "Grizzly Jerkin";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 477;
			BuyPrice = 2071;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Feral Harness)
*
***************************************************************/

namespace Server.Items
{
	public class FeralHarness : Item
	{
		public FeralHarness() : base()
		{
			Id = 15311;
			Resistance[0] = 81;
			Bonding = 2;
			SellPrice = 982;
			AvailableClasses = 0x7FFF;
			Model = 11382;
			ObjectClass = 4;
			SubClass = 2;
			Level = 22;
			ReqLevel = 17;
			Name = "Feral Harness";
			Name2 = "Feral Harness";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 479;
			BuyPrice = 4913;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 75;
		}
	}
}


/**************************************************************
*
*				(Wrangler's Wraps)
*
***************************************************************/

namespace Server.Items
{
	public class WranglersWraps : Item
	{
		public WranglersWraps() : base()
		{
			Id = 15337;
			Resistance[0] = 92;
			Bonding = 2;
			SellPrice = 2027;
			AvailableClasses = 0x7FFF;
			Model = 27683;
			ObjectClass = 4;
			SubClass = 2;
			Level = 29;
			ReqLevel = 24;
			Name = "Wrangler's Wraps";
			Name2 = "Wrangler's Wraps";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 481;
			BuyPrice = 10136;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Pathfinder Vest)
*
***************************************************************/

namespace Server.Items
{
	public class PathfinderVest : Item
	{
		public PathfinderVest() : base()
		{
			Id = 15346;
			Resistance[0] = 97;
			Bonding = 2;
			SellPrice = 2788;
			AvailableClasses = 0x7FFF;
			Model = 27683;
			ObjectClass = 4;
			SubClass = 2;
			Level = 32;
			ReqLevel = 27;
			Name = "Pathfinder Vest";
			Name2 = "Pathfinder Vest";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 482;
			BuyPrice = 13941;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Headhunter's Armor)
*
***************************************************************/

namespace Server.Items
{
	public class HeadhuntersArmor : Item
	{
		public HeadhuntersArmor() : base()
		{
			Id = 15356;
			Resistance[0] = 103;
			Bonding = 2;
			SellPrice = 3935;
			AvailableClasses = 0x7FFF;
			Model = 18284;
			ObjectClass = 4;
			SubClass = 2;
			Level = 36;
			ReqLevel = 31;
			Name = "Headhunter's Armor";
			Name2 = "Headhunter's Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 483;
			BuyPrice = 19678;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Trickster's Vest)
*
***************************************************************/

namespace Server.Items
{
	public class TrickstersVest : Item
	{
		public TrickstersVest() : base()
		{
			Id = 15359;
			Resistance[0] = 113;
			Bonding = 2;
			SellPrice = 5955;
			AvailableClasses = 0x7FFF;
			Model = 27956;
			ObjectClass = 4;
			SubClass = 2;
			Level = 41;
			ReqLevel = 36;
			Name = "Trickster's Vest";
			Name2 = "Trickster's Vest";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 485;
			BuyPrice = 29776;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Wolf Rider's Padded Armor)
*
***************************************************************/

namespace Server.Items
{
	public class WolfRidersPaddedArmor : Item
	{
		public WolfRidersPaddedArmor() : base()
		{
			Id = 15376;
			Resistance[0] = 124;
			Bonding = 2;
			SellPrice = 8653;
			AvailableClasses = 0x7FFF;
			Model = 27971;
			ObjectClass = 4;
			SubClass = 2;
			Level = 46;
			ReqLevel = 41;
			Name = "Wolf Rider's Padded Armor";
			Name2 = "Wolf Rider's Padded Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 487;
			BuyPrice = 43266;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Rageclaw Chestguard)
*
***************************************************************/

namespace Server.Items
{
	public class RageclawChestguard : Item
	{
		public RageclawChestguard() : base()
		{
			Id = 15381;
			Resistance[0] = 135;
			Bonding = 2;
			SellPrice = 12593;
			AvailableClasses = 0x7FFF;
			Model = 17094;
			ObjectClass = 4;
			SubClass = 2;
			Level = 51;
			ReqLevel = 46;
			Name = "Rageclaw Chestguard";
			Name2 = "Rageclaw Chestguard";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 488;
			BuyPrice = 62967;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Jadefire Chestguard)
*
***************************************************************/

namespace Server.Items
{
	public class JadefireChestguard : Item
	{
		public JadefireChestguard() : base()
		{
			Id = 15390;
			Resistance[0] = 146;
			Bonding = 2;
			SellPrice = 16175;
			AvailableClasses = 0x7FFF;
			Model = 27656;
			ObjectClass = 4;
			SubClass = 2;
			Level = 56;
			ReqLevel = 51;
			Name = "Jadefire Chestguard";
			Name2 = "Jadefire Chestguard";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 490;
			BuyPrice = 80876;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Peerless Armor)
*
***************************************************************/

namespace Server.Items
{
	public class PeerlessArmor : Item
	{
		public PeerlessArmor() : base()
		{
			Id = 15433;
			Resistance[0] = 156;
			Bonding = 2;
			SellPrice = 21849;
			AvailableClasses = 0x7FFF;
			Model = 28028;
			ObjectClass = 4;
			SubClass = 2;
			Level = 61;
			ReqLevel = 56;
			Name = "Peerless Armor";
			Name2 = "Peerless Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 492;
			BuyPrice = 109245;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Supreme Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class SupremeBreastplate : Item
	{
		public SupremeBreastplate() : base()
		{
			Id = 15442;
			Resistance[0] = 165;
			Bonding = 2;
			SellPrice = 27433;
			AvailableClasses = 0x7FFF;
			Model = 27610;
			ObjectClass = 4;
			SubClass = 2;
			Level = 65;
			ReqLevel = 60;
			Name = "Supreme Breastplate";
			Name2 = "Supreme Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 493;
			BuyPrice = 137166;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Brawnhide Armor)
*
***************************************************************/

namespace Server.Items
{
	public class BrawnhideArmor : Item
	{
		public BrawnhideArmor() : base()
		{
			Id = 15471;
			Resistance[0] = 92;
			Bonding = 1;
			SellPrice = 2034;
			AvailableClasses = 0x7FFF;
			Model = 28266;
			ObjectClass = 4;
			SubClass = 2;
			Level = 29;
			Name = "Brawnhide Armor";
			Name2 = "Brawnhide Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 10172;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
			StaminaBonus = 9;
			IqBonus = 3;
			AgilityBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Fernpulse Jerkin)
*
***************************************************************/

namespace Server.Items
{
	public class FernpulseJerkin : Item
	{
		public FernpulseJerkin() : base()
		{
			Id = 15786;
			Resistance[0] = 152;
			Bonding = 1;
			SellPrice = 18826;
			AvailableClasses = 0x7FFF;
			Model = 26466;
			ObjectClass = 4;
			SubClass = 2;
			Level = 59;
			Name = "Fernpulse Jerkin";
			Name2 = "Fernpulse Jerkin";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 94134;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
			IqBonus = 22;
			StaminaBonus = 5;
			SpiritBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Traphook Jerkin)
*
***************************************************************/

namespace Server.Items
{
	public class TraphookJerkin : Item
	{
		public TraphookJerkin() : base()
		{
			Id = 15825;
			Resistance[0] = 152;
			Bonding = 1;
			SellPrice = 19302;
			AvailableClasses = 0x7FFF;
			Model = 26514;
			ObjectClass = 4;
			SubClass = 2;
			Level = 59;
			Name = "Traphook Jerkin";
			Name2 = "Traphook Jerkin";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 96512;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
			AgilityBonus = 24;
			StrBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Knight-Captain's Leather Armor)
*
***************************************************************/

namespace Server.Items
{
	public class KnightCaptainsLeatherArmor : Item
	{
		public KnightCaptainsLeatherArmor() : base()
		{
			Id = 16417;
			Resistance[0] = 176;
			Bonding = 1;
			SellPrice = 14827;
			AvailableClasses = 0x08;
			Model = 31072;
			ObjectClass = 4;
			SubClass = 2;
			Level = 63;
			ReqLevel = 58;
			Name = "Knight-Captain's Leather Armor";
			Name2 = "Knight-Captain's Leather Armor";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 74137;
			Sets = 348;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			MaxCount = 1;
			Material = 8;
			Durability = 100;
			Flags = 32768;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 25;
			AgilityBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Knight-Captain's Dragonhide Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class KnightCaptainsDragonhideTunic : Item
	{
		public KnightCaptainsDragonhideTunic() : base()
		{
			Id = 16421;
			Resistance[0] = 176;
			Bonding = 1;
			SellPrice = 15039;
			AvailableClasses = 0x400;
			Model = 31074;
			ObjectClass = 4;
			SubClass = 2;
			Level = 63;
			ReqLevel = 58;
			Name = "Knight-Captain's Dragonhide Tunic";
			Name2 = "Knight-Captain's Dragonhide Tunic";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 75195;
			Sets = 381;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			MaxCount = 1;
			Material = 8;
			Durability = 100;
			Flags = 32768;
			SetSpell( 9345 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 14;
			StrBonus = 13;
			AgilityBonus = 9;
			SpiritBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Field Marshal's Dragonhide Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class FieldMarshalsDragonhideBreastplate : Item
	{
		public FieldMarshalsDragonhideBreastplate() : base()
		{
			Id = 16452;
			Resistance[0] = 197;
			Bonding = 1;
			SellPrice = 21402;
			AvailableClasses = 0x400;
			Model = 30327;
			ObjectClass = 4;
			SubClass = 2;
			Level = 65;
			ReqLevel = 60;
			Name = "Field Marshal's Dragonhide Breastplate";
			Name2 = "Field Marshal's Dragonhide Breastplate";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 107014;
			Sets = 397;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			MaxCount = 1;
			Material = 8;
			Durability = 120;
			Flags = 32768;
			SetSpell( 14089 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			StrBonus = 19;
			StaminaBonus = 18;
			AgilityBonus = 14;
			SpiritBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Field Marshal's Leather Chestpiece)
*
***************************************************************/

namespace Server.Items
{
	public class FieldMarshalsLeatherChestpiece : Item
	{
		public FieldMarshalsLeatherChestpiece() : base()
		{
			Id = 16453;
			Resistance[0] = 197;
			Bonding = 1;
			SellPrice = 21481;
			AvailableClasses = 0x08;
			Model = 30327;
			ObjectClass = 4;
			SubClass = 2;
			Level = 65;
			ReqLevel = 60;
			Name = "Field Marshal's Leather Chestpiece";
			Name2 = "Field Marshal's Leather Chestpiece";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 107405;
			Sets = 394;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			MaxCount = 1;
			Material = 8;
			Durability = 120;
			Flags = 32768;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 35;
			AgilityBonus = 20;
		}
	}
}


/**************************************************************
*
*				(Legionnaire's Dragonhide Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class LegionnairesDragonhideBreastplate : Item
	{
		public LegionnairesDragonhideBreastplate() : base()
		{
			Id = 16504;
			Resistance[0] = 176;
			Bonding = 1;
			SellPrice = 14130;
			AvailableClasses = 0x400;
			Model = 31037;
			ObjectClass = 4;
			SubClass = 2;
			Level = 63;
			ReqLevel = 58;
			Name = "Legionnaire's Dragonhide Breastplate";
			Name2 = "Legionnaire's Dragonhide Breastplate";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 70653;
			Sets = 382;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			MaxCount = 1;
			Material = 8;
			Durability = 100;
			Flags = 32768;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 9345 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 14;
			StrBonus = 13;
			AgilityBonus = 9;
			SpiritBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Legionnaire's Leather Hauberk)
*
***************************************************************/

namespace Server.Items
{
	public class LegionnairesLeatherHauberk : Item
	{
		public LegionnairesLeatherHauberk() : base()
		{
			Id = 16505;
			Resistance[0] = 176;
			Bonding = 1;
			SellPrice = 14184;
			AvailableClasses = 0x08;
			Model = 31039;
			ObjectClass = 4;
			SubClass = 2;
			Level = 63;
			ReqLevel = 58;
			Name = "Legionnaire's Leather Hauberk";
			Name2 = "Legionnaire's Leather Hauberk";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 70920;
			Sets = 347;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			MaxCount = 1;
			Material = 8;
			Durability = 100;
			Flags = 32768;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 25;
			AgilityBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Warlord's Dragonhide Hauberk)
*
***************************************************************/

namespace Server.Items
{
	public class WarlordsDragonhideHauberk : Item
	{
		public WarlordsDragonhideHauberk() : base()
		{
			Id = 16549;
			Resistance[0] = 197;
			Bonding = 1;
			SellPrice = 21716;
			AvailableClasses = 0x400;
			Model = 32110;
			ObjectClass = 4;
			SubClass = 2;
			Level = 65;
			ReqLevel = 60;
			Name = "Warlord's Dragonhide Hauberk";
			Name2 = "Warlord's Dragonhide Hauberk";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 108580;
			Sets = 398;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			MaxCount = 1;
			Material = 8;
			Durability = 120;
			Flags = 32768;
			SetSpell( 14248 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			StrBonus = 19;
			StaminaBonus = 18;
			AgilityBonus = 14;
			SpiritBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Warlord's Leather Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class WarlordsLeatherBreastplate : Item
	{
		public WarlordsLeatherBreastplate() : base()
		{
			Id = 16563;
			Resistance[0] = 197;
			Bonding = 1;
			SellPrice = 21246;
			AvailableClasses = 0x08;
			Model = 32115;
			ObjectClass = 4;
			SubClass = 2;
			Level = 65;
			ReqLevel = 60;
			Name = "Warlord's Leather Breastplate";
			Name2 = "Warlord's Leather Breastplate";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 106231;
			Sets = 393;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			MaxCount = 1;
			Material = 8;
			Durability = 120;
			Flags = 32768;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 35;
			AgilityBonus = 20;
		}
	}
}


/**************************************************************
*
*				(Wildheart Vest)
*
***************************************************************/

namespace Server.Items
{
	public class WildheartVest : Item
	{
		public WildheartVest() : base()
		{
			Id = 16706;
			Resistance[0] = 176;
			Bonding = 1;
			SellPrice = 27841;
			AvailableClasses = 0x7FFF;
			Model = 29974;
			ObjectClass = 4;
			SubClass = 2;
			Level = 63;
			ReqLevel = 58;
			Name = "Wildheart Vest";
			Name2 = "Wildheart Vest";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 139205;
			Sets = 185;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 100;
			SpiritBonus = 20;
			IqBonus = 20;
			StaminaBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Shadowcraft Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class ShadowcraftTunic : Item
	{
		public ShadowcraftTunic() : base()
		{
			Id = 16721;
			Resistance[0] = 176;
			Bonding = 1;
			SellPrice = 30190;
			AvailableClasses = 0x7FFF;
			Model = 28160;
			ObjectClass = 4;
			SubClass = 2;
			Level = 63;
			ReqLevel = 58;
			Name = "Shadowcraft Tunic";
			Name2 = "Shadowcraft Tunic";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 150952;
			Sets = 184;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 100;
			AgilityBonus = 26;
			StaminaBonus = 13;
			IqBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Nightslayer Chestpiece)
*
***************************************************************/

namespace Server.Items
{
	public class NightslayerChestpiece : Item
	{
		public NightslayerChestpiece() : base()
		{
			Id = 16820;
			Resistance[0] = 200;
			Bonding = 1;
			SellPrice = 43137;
			AvailableClasses = 0x08;
			Model = 31105;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 2;
			Level = 66;
			ReqLevel = 60;
			Name = "Nightslayer Chestpiece";
			Name2 = "Nightslayer Chestpiece";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 215686;
			Sets = 204;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 120;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			AgilityBonus = 29;
			StaminaBonus = 20;
			StrBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Stormrage Chestguard)
*
***************************************************************/

namespace Server.Items
{
	public class StormrageChestguard : Item
	{
		public StormrageChestguard() : base()
		{
			Id = 16897;
			Resistance[0] = 225;
			Bonding = 1;
			SellPrice = 71351;
			AvailableClasses = 0x400;
			Model = 29770;
			Resistance[2] = 5;
			Resistance[4] = 6;
			ObjectClass = 4;
			SubClass = 2;
			Level = 76;
			ReqLevel = 60;
			Name = "Stormrage Chestguard";
			Name2 = "Stormrage Chestguard";
			Resistance[3] = 7;
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 356759;
			Sets = 214;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 120;
			SetSpell( 13594 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 7694 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 7679 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 23;
			IqBonus = 32;
			StaminaBonus = 16;
			StrBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Bloodfang Chestpiece)
*
***************************************************************/

namespace Server.Items
{
	public class BloodfangChestpiece : Item
	{
		public BloodfangChestpiece() : base()
		{
			Id = 16905;
			Resistance[0] = 225;
			Bonding = 1;
			SellPrice = 73480;
			AvailableClasses = 0x08;
			Model = 29746;
			Resistance[2] = 8;
			ObjectClass = 4;
			SubClass = 2;
			Level = 76;
			ReqLevel = 60;
			Name = "Bloodfang Chestpiece";
			Name2 = "Bloodfang Chestpiece";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 367400;
			Sets = 213;
			Resistance[5] = 8;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 120;
			SetSpell( 13669 , 1 , 0 , -1 , 0 , -1 );
			AgilityBonus = 40;
			IqBonus = 11;
			StaminaBonus = 12;
			StrBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Boorguard Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class BoorguardTunic : Item
	{
		public BoorguardTunic() : base()
		{
			Id = 17005;
			Resistance[0] = 89;
			Bonding = 1;
			SellPrice = 1632;
			AvailableClasses = 0x7FFF;
			Model = 28837;
			ObjectClass = 4;
			SubClass = 2;
			Level = 27;
			Name = "Boorguard Tunic";
			Name2 = "Boorguard Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 8161;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 80;
			AgilityBonus = 7;
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Fungus Shroud Armor)
*
***************************************************************/

namespace Server.Items
{
	public class FungusShroudArmor : Item
	{
		public FungusShroudArmor() : base()
		{
			Id = 17742;
			Resistance[0] = 148;
			Bonding = 1;
			SellPrice = 14450;
			AvailableClasses = 0x7FFF;
			Model = 29919;
			ObjectClass = 4;
			SubClass = 2;
			Level = 51;
			ReqLevel = 46;
			Name = "Fungus Shroud Armor";
			Name2 = "Fungus Shroud Armor";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 72253;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 100;
			AgilityBonus = 25;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Lionfur Armor)
*
***************************************************************/

namespace Server.Items
{
	public class LionfurArmor : Item
	{
		public LionfurArmor() : base()
		{
			Id = 17922;
			Resistance[0] = 55;
			Bonding = 2;
			SellPrice = 115;
			AvailableClasses = 0x7FFF;
			Model = 30171;
			ObjectClass = 4;
			SubClass = 2;
			Level = 10;
			ReqLevel = 5;
			Name = "Lionfur Armor";
			Name2 = "Lionfur Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 576;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 55;
			SpiritBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Chestplate of Tranquility)
*
***************************************************************/

namespace Server.Items
{
	public class ChestplateOfTranquility : Item
	{
		public ChestplateOfTranquility() : base()
		{
			Id = 18373;
			Resistance[0] = 174;
			Bonding = 1;
			SellPrice = 28459;
			AvailableClasses = 0x7FFF;
			Model = 17099;
			ObjectClass = 4;
			SubClass = 2;
			Level = 62;
			ReqLevel = 57;
			Name = "Chestplate of Tranquility";
			Name2 = "Chestplate of Tranquility";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 142297;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 100;
			SetSpell( 14047 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 20;
			IqBonus = 6;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Hyena Hide Jerkin)
*
***************************************************************/

namespace Server.Items
{
	public class HyenaHideJerkin : Item
	{
		public HyenaHideJerkin() : base()
		{
			Id = 18478;
			Resistance[0] = 154;
			Bonding = 1;
			SellPrice = 19768;
			AvailableClasses = 0x7FFF;
			Model = 30819;
			ObjectClass = 4;
			SubClass = 2;
			Level = 60;
			ReqLevel = 55;
			Name = "Hyena Hide Jerkin";
			Name2 = "Hyena Hide Jerkin";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 98841;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
			AgilityBonus = 20;
			StaminaBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Pratt's Handcrafted Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class PrattsHandcraftedTunic : Item
	{
		public PrattsHandcraftedTunic() : base()
		{
			Id = 19041;
			Resistance[0] = 129;
			Bonding = 1;
			SellPrice = 9946;
			AvailableClasses = 0x7FFF;
			Model = 31529;
			ObjectClass = 4;
			SubClass = 2;
			Level = 48;
			Name = "Pratt's Handcrafted Tunic";
			Name2 = "Pratt's Handcrafted Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 49732;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
			AgilityBonus = 7;
			StaminaBonus = 15;
			StrBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Jangdor's Handcrafted Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class JangdorsHandcraftedTunic : Item
	{
		public JangdorsHandcraftedTunic() : base()
		{
			Id = 19042;
			Resistance[0] = 129;
			Bonding = 1;
			SellPrice = 9984;
			AvailableClasses = 0x7FFF;
			Model = 31531;
			ObjectClass = 4;
			SubClass = 2;
			Level = 48;
			Name = "Jangdor's Handcrafted Tunic";
			Name2 = "Jangdor's Handcrafted Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 49920;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
			AgilityBonus = 7;
			StaminaBonus = 15;
			StrBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Charred Leather Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class CharredLeatherTunic : Item
	{
		public CharredLeatherTunic() : base()
		{
			Id = 19127;
			Resistance[0] = 132;
			Bonding = 1;
			SellPrice = 12258;
			AvailableClasses = 0x7FFF;
			Model = 31639;
			ObjectClass = 4;
			SubClass = 2;
			Level = 50;
			Name = "Charred Leather Tunic";
			Name2 = "Charred Leather Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 61290;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 85;
			AgilityBonus = 18;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Malfurion's Blessed Bulwark)
*
***************************************************************/

namespace Server.Items
{
	public class MalfurionsBlessedBulwark : Item
	{
		public MalfurionsBlessedBulwark() : base()
		{
			Id = 19405;
			Resistance[0] = 392;
			Bonding = 1;
			SellPrice = 70277;
			AvailableClasses = 0x7FFF;
			Model = 31934;
			ObjectClass = 4;
			SubClass = 2;
			Level = 75;
			ReqLevel = 60;
			Name = "Malfurion's Blessed Bulwark";
			Name2 = "Malfurion's Blessed Bulwark";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 351387;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 120;
			StrBonus = 40;
			StaminaBonus = 22;
		}
	}
}


/**************************************************************
*
*				(Interlaced Shadow Jerkin)
*
***************************************************************/

namespace Server.Items
{
	public class InterlacedShadowJerkin : Item
	{
		public InterlacedShadowJerkin() : base()
		{
			Id = 19439;
			Resistance[0] = 212;
			Bonding = 1;
			SellPrice = 56552;
			AvailableClasses = 0x7FFF;
			Model = 31986;
			ObjectClass = 4;
			SubClass = 2;
			Level = 71;
			ReqLevel = 60;
			Name = "Interlaced Shadow Jerkin";
			Name2 = "Interlaced Shadow Jerkin";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 282763;
			Resistance[5] = 30;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 8;
			Durability = 120;
			SetSpell( 9335 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 25;
		}
	}
}


