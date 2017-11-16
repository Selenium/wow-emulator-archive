/**************************************************************
*
*		Made by fulgas (fulgas@gmail.com)
*
*  WowwoW Item Designer ( 2005/8/23 - 10:05:52 )
*
***************************************************************/

using System;
using System.Collections;

/***************************************************************/

/**************************************************************
*
*				(Overseer's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class OverseersCloak : Item
	{
		public OverseersCloak() : base()
		{
			Id = 1190;
			Resistance[0] = 17;
			Bonding = 2;
			SellPrice = 630;
			AvailableClasses = 0x7FFF;
			Model = 15120;
			ObjectClass = 4;
			SubClass = 1;
			Level = 20;
			ReqLevel = 15;
			Name = "Overseer's Cloak";
			Name2 = "Overseer's Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3150;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Finely Woven Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class FinelyWovenCloak : Item
	{
		public FinelyWovenCloak() : base()
		{
			Id = 1270;
			Resistance[0] = 14;
			Bonding = 1;
			SellPrice = 213;
			AvailableClasses = 0x7FFF;
			Model = 23113;
			ObjectClass = 4;
			SubClass = 1;
			Level = 15;
			Name = "Finely Woven Cloak";
			Name2 = "Finely Woven Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1067;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			IqBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Buckskin Cape)
*
***************************************************************/

namespace Server.Items
{
	public class BuckskinCape : Item
	{
		public BuckskinCape() : base()
		{
			Id = 1355;
			Resistance[0] = 14;
			Bonding = 2;
			SellPrice = 251;
			AvailableClasses = 0x7FFF;
			Model = 23014;
			ObjectClass = 4;
			SubClass = 1;
			Level = 15;
			ReqLevel = 10;
			Name = "Buckskin Cape";
			Name2 = "Buckskin Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1259;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			AgilityBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Ragged Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class RaggedCloak : Item
	{
		public RaggedCloak() : base()
		{
			Id = 1372;
			Resistance[0] = 3;
			SellPrice = 2;
			AvailableClasses = 0x7FFF;
			Model = 23054;
			ObjectClass = 4;
			SubClass = 1;
			Level = 3;
			ReqLevel = 1;
			Name = "Ragged Cloak";
			Name2 = "Ragged Cloak";
			AvailableRaces = 0x1FF;
			BuyPrice = 11;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Frayed Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class FrayedCloak : Item
	{
		public FrayedCloak() : base()
		{
			Id = 1376;
			Resistance[0] = 5;
			SellPrice = 4;
			AvailableClasses = 0x7FFF;
			Model = 23090;
			ObjectClass = 4;
			SubClass = 1;
			Level = 5;
			ReqLevel = 1;
			Name = "Frayed Cloak";
			Name2 = "Frayed Cloak";
			AvailableRaces = 0x1FF;
			BuyPrice = 23;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Worn Hide Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class WornHideCloak : Item
	{
		public WornHideCloak() : base()
		{
			Id = 1421;
			Resistance[0] = 9;
			SellPrice = 28;
			AvailableClasses = 0x7FFF;
			Model = 23083;
			ObjectClass = 4;
			SubClass = 1;
			Level = 10;
			ReqLevel = 5;
			Name = "Worn Hide Cloak";
			Name2 = "Worn Hide Cloak";
			AvailableRaces = 0x1FF;
			BuyPrice = 144;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Patchwork Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class PatchworkCloak : Item
	{
		public PatchworkCloak() : base()
		{
			Id = 1429;
			Resistance[0] = 5;
			SellPrice = 7;
			AvailableClasses = 0x7FFF;
			Model = 23130;
			ObjectClass = 4;
			SubClass = 1;
			Level = 6;
			ReqLevel = 1;
			Name = "Patchwork Cloak";
			Name2 = "Patchwork Cloak";
			AvailableRaces = 0x1FF;
			BuyPrice = 38;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Calico Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class CalicoCloak : Item
	{
		public CalicoCloak() : base()
		{
			Id = 1497;
			Resistance[0] = 12;
			SellPrice = 71;
			AvailableClasses = 0x7FFF;
			Model = 23094;
			ObjectClass = 4;
			SubClass = 1;
			Level = 14;
			ReqLevel = 9;
			Name = "Calico Cloak";
			Name2 = "Calico Cloak";
			AvailableRaces = 0x1FF;
			BuyPrice = 356;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Warped Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class WarpedCloak : Item
	{
		public WarpedCloak() : base()
		{
			Id = 1505;
			Resistance[0] = 10;
			SellPrice = 48;
			AvailableClasses = 0x7FFF;
			Model = 23076;
			ObjectClass = 4;
			SubClass = 1;
			Level = 12;
			ReqLevel = 7;
			Name = "Warped Cloak";
			Name2 = "Warped Cloak";
			AvailableRaces = 0x1FF;
			BuyPrice = 244;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Worn Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class WornCloak : Item
	{
		public WornCloak() : base()
		{
			Id = 1733;
			Resistance[0] = 13;
			SellPrice = 88;
			AvailableClasses = 0x7FFF;
			Model = 15272;
			ObjectClass = 4;
			SubClass = 1;
			Level = 15;
			ReqLevel = 10;
			Name = "Worn Cloak";
			Name2 = "Worn Cloak";
			AvailableRaces = 0x1FF;
			BuyPrice = 443;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Laced Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class LacedCloak : Item
	{
		public LacedCloak() : base()
		{
			Id = 1741;
			Resistance[0] = 14;
			SellPrice = 112;
			AvailableClasses = 0x7FFF;
			Model = 15065;
			ObjectClass = 4;
			SubClass = 1;
			Level = 17;
			ReqLevel = 12;
			Name = "Laced Cloak";
			Name2 = "Laced Cloak";
			AvailableRaces = 0x1FF;
			BuyPrice = 562;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Linked Chain Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class LinkedChainCloak : Item
	{
		public LinkedChainCloak() : base()
		{
			Id = 1749;
			Resistance[0] = 17;
			SellPrice = 396;
			AvailableClasses = 0x7FFF;
			Model = 15074;
			ObjectClass = 4;
			SubClass = 1;
			Level = 23;
			ReqLevel = 18;
			Name = "Linked Chain Cloak";
			Name2 = "Linked Chain Cloak";
			AvailableRaces = 0x1FF;
			BuyPrice = 1982;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Reinforced Chain Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class ReinforcedChainCloak : Item
	{
		public ReinforcedChainCloak() : base()
		{
			Id = 1757;
			Resistance[0] = 19;
			SellPrice = 728;
			AvailableClasses = 0x7FFF;
			Model = 15181;
			ObjectClass = 4;
			SubClass = 1;
			Level = 29;
			ReqLevel = 24;
			Name = "Reinforced Chain Cloak";
			Name2 = "Reinforced Chain Cloak";
			AvailableRaces = 0x1FF;
			BuyPrice = 3643;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Canvas Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class CanvasCloak : Item
	{
		public CanvasCloak() : base()
		{
			Id = 1766;
			Resistance[0] = 14;
			SellPrice = 131;
			AvailableClasses = 0x7FFF;
			Model = 23095;
			ObjectClass = 4;
			SubClass = 1;
			Level = 18;
			ReqLevel = 13;
			Name = "Canvas Cloak";
			Name2 = "Canvas Cloak";
			AvailableRaces = 0x1FF;
			BuyPrice = 658;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Brocade Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class BrocadeCloak : Item
	{
		public BrocadeCloak() : base()
		{
			Id = 1774;
			Resistance[0] = 17;
			SellPrice = 281;
			AvailableClasses = 0x7FFF;
			Model = 23093;
			ObjectClass = 4;
			SubClass = 1;
			Level = 24;
			ReqLevel = 19;
			Name = "Brocade Cloak";
			Name2 = "Brocade Cloak";
			AvailableRaces = 0x1FF;
			BuyPrice = 1406;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Cross-stitched Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class CrossStitchedCloak : Item
	{
		public CrossStitchedCloak() : base()
		{
			Id = 1782;
			Resistance[0] = 19;
			SellPrice = 541;
			AvailableClasses = 0x7FFF;
			Model = 23102;
			ObjectClass = 4;
			SubClass = 1;
			Level = 30;
			ReqLevel = 25;
			Name = "Cross-stitched Cloak";
			Name2 = "Cross-stitched Cloak";
			AvailableRaces = 0x1FF;
			BuyPrice = 2709;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Patched Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class PatchedCloak : Item
	{
		public PatchedCloak() : base()
		{
			Id = 1790;
			Resistance[0] = 13;
			SellPrice = 93;
			AvailableClasses = 0x7FFF;
			Model = 23050;
			ObjectClass = 4;
			SubClass = 1;
			Level = 16;
			ReqLevel = 11;
			Name = "Patched Cloak";
			Name2 = "Patched Cloak";
			AvailableRaces = 0x1FF;
			BuyPrice = 469;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Rawhide Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class RawhideCloak : Item
	{
		public RawhideCloak() : base()
		{
			Id = 1798;
			Resistance[0] = 16;
			SellPrice = 279;
			AvailableClasses = 0x7FFF;
			Model = 23058;
			ObjectClass = 4;
			SubClass = 1;
			Level = 22;
			ReqLevel = 17;
			Name = "Rawhide Cloak";
			Name2 = "Rawhide Cloak";
			AvailableRaces = 0x1FF;
			BuyPrice = 1397;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Tough Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class ToughCloak : Item
	{
		public ToughCloak() : base()
		{
			Id = 1806;
			Resistance[0] = 19;
			SellPrice = 466;
			AvailableClasses = 0x7FFF;
			Model = 23072;
			ObjectClass = 4;
			SubClass = 1;
			Level = 28;
			ReqLevel = 23;
			Name = "Tough Cloak";
			Name2 = "Tough Cloak";
			AvailableRaces = 0x1FF;
			BuyPrice = 2330;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Stonemason Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class StonemasonCloak : Item
	{
		public StonemasonCloak() : base()
		{
			Id = 1930;
			Resistance[0] = 16;
			Bonding = 2;
			SellPrice = 408;
			AvailableClasses = 0x7FFF;
			Model = 23067;
			ObjectClass = 4;
			SubClass = 1;
			Level = 18;
			ReqLevel = 13;
			Name = "Stonemason Cloak";
			Name2 = "Stonemason Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2044;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Sentry Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class SentryCloak : Item
	{
		public SentryCloak() : base()
		{
			Id = 2059;
			Resistance[0] = 21;
			Bonding = 2;
			SellPrice = 863;
			AvailableClasses = 0x7FFF;
			Model = 22991;
			ObjectClass = 4;
			SubClass = 1;
			Level = 24;
			ReqLevel = 19;
			Name = "Sentry Cloak";
			Name2 = "Sentry Cloak";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 4318;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 5;
			AgilityBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Old Blanchy's Blanket)
*
***************************************************************/

namespace Server.Items
{
	public class OldBlanchysBlanket : Item
	{
		public OldBlanchysBlanket() : base()
		{
			Id = 2165;
			Resistance[0] = 9;
			Bonding = 1;
			SellPrice = 45;
			AvailableClasses = 0x7FFF;
			Model = 23054;
			ObjectClass = 4;
			SubClass = 1;
			Level = 10;
			Name = "Old Blanchy's Blanket";
			Name2 = "Old Blanchy's Blanket";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 227;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Rugged Cape)
*
***************************************************************/

namespace Server.Items
{
	public class RuggedCape : Item
	{
		public RuggedCape() : base()
		{
			Id = 2240;
			Resistance[0] = 13;
			Bonding = 1;
			SellPrice = 151;
			AvailableClasses = 0x7FFF;
			Model = 23061;
			ObjectClass = 4;
			SubClass = 1;
			Level = 15;
			Name = "Rugged Cape";
			Name2 = "Rugged Cape";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 758;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Desperado Cape)
*
***************************************************************/

namespace Server.Items
{
	public class DesperadoCape : Item
	{
		public DesperadoCape() : base()
		{
			Id = 2241;
			Resistance[0] = 17;
			Bonding = 2;
			SellPrice = 615;
			AvailableClasses = 0x7FFF;
			Model = 15248;
			ObjectClass = 4;
			SubClass = 1;
			Level = 20;
			ReqLevel = 15;
			Name = "Desperado Cape";
			Name2 = "Desperado Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3078;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Rat Cloth Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class RatClothCloak : Item
	{
		public RatClothCloak() : base()
		{
			Id = 2284;
			Resistance[0] = 14;
			Bonding = 2;
			SellPrice = 211;
			AvailableClasses = 0x7FFF;
			Model = 23132;
			ObjectClass = 4;
			SubClass = 1;
			Level = 15;
			ReqLevel = 10;
			Name = "Rat Cloth Cloak";
			Name2 = "Rat Cloth Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1055;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Fine Leather Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class FineLeatherCloak : Item
	{
		public FineLeatherCloak() : base()
		{
			Id = 2308;
			Resistance[0] = 14;
			Bonding = 2;
			SellPrice = 267;
			AvailableClasses = 0x7FFF;
			Model = 23028;
			ObjectClass = 4;
			SubClass = 1;
			Level = 15;
			ReqLevel = 10;
			Name = "Fine Leather Cloak";
			Name2 = "Fine Leather Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1338;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Embossed Leather Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class EmbossedLeatherCloak : Item
	{
		public EmbossedLeatherCloak() : base()
		{
			Id = 2310;
			Resistance[0] = 12;
			SellPrice = 112;
			AvailableClasses = 0x7FFF;
			Model = 23025;
			ObjectClass = 4;
			SubClass = 1;
			Level = 13;
			ReqLevel = 8;
			Name = "Embossed Leather Cloak";
			Name2 = "Embossed Leather Cloak";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 561;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Dark Leather Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class DarkLeatherCloak : Item
	{
		public DarkLeatherCloak() : base()
		{
			Id = 2316;
			Resistance[0] = 17;
			SellPrice = 408;
			AvailableClasses = 0x7FFF;
			Model = 23021;
			ObjectClass = 4;
			SubClass = 1;
			Level = 22;
			ReqLevel = 17;
			Name = "Dark Leather Cloak";
			Name2 = "Dark Leather Cloak";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2043;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Linen Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class LinenCloak : Item
	{
		public LinenCloak() : base()
		{
			Id = 2570;
			Resistance[0] = 6;
			SellPrice = 11;
			AvailableClasses = 0x7FFF;
			Model = 23122;
			ObjectClass = 4;
			SubClass = 1;
			Level = 6;
			ReqLevel = 1;
			Name = "Linen Cloak";
			Name2 = "Linen Cloak";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 55;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Reinforced Linen Cape)
*
***************************************************************/

namespace Server.Items
{
	public class ReinforcedLinenCape : Item
	{
		public ReinforcedLinenCape() : base()
		{
			Id = 2580;
			Resistance[0] = 11;
			SellPrice = 67;
			AvailableClasses = 0x7FFF;
			Model = 23133;
			ObjectClass = 4;
			SubClass = 1;
			Level = 12;
			ReqLevel = 7;
			Name = "Reinforced Linen Cape";
			Name2 = "Reinforced Linen Cape";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 338;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Woolen Cape)
*
***************************************************************/

namespace Server.Items
{
	public class WoolenCape : Item
	{
		public WoolenCape() : base()
		{
			Id = 2584;
			Resistance[0] = 14;
			SellPrice = 142;
			AvailableClasses = 0x7FFF;
			Model = 23144;
			ObjectClass = 4;
			SubClass = 1;
			Level = 16;
			ReqLevel = 11;
			Name = "Woolen Cape";
			Name2 = "Woolen Cape";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 711;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Loose Chain Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class LooseChainCloak : Item
	{
		public LooseChainCloak() : base()
		{
			Id = 2644;
			Resistance[0] = 5;
			SellPrice = 11;
			AvailableClasses = 0x7FFF;
			Model = 15082;
			ObjectClass = 4;
			SubClass = 1;
			Level = 6;
			ReqLevel = 1;
			Name = "Loose Chain Cloak";
			Name2 = "Loose Chain Cloak";
			AvailableRaces = 0x1FF;
			BuyPrice = 56;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Flimsy Chain Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class FlimsyChainCloak : Item
	{
		public FlimsyChainCloak() : base()
		{
			Id = 2652;
			Resistance[0] = 5;
			SellPrice = 7;
			AvailableClasses = 0x7FFF;
			Model = 15164;
			ObjectClass = 4;
			SubClass = 1;
			Level = 5;
			ReqLevel = 1;
			Name = "Flimsy Chain Cloak";
			Name2 = "Flimsy Chain Cloak";
			AvailableRaces = 0x1FF;
			BuyPrice = 36;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Yeti Fur Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class YetiFurCloak : Item
	{
		public YetiFurCloak() : base()
		{
			Id = 2805;
			Resistance[0] = 23;
			Bonding = 1;
			SellPrice = 2352;
			AvailableClasses = 0x7FFF;
			Model = 23084;
			ObjectClass = 4;
			SubClass = 1;
			Level = 34;
			Name = "Yeti Fur Cloak";
			Name2 = "Yeti Fur Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11762;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			AgilityBonus = 6;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Cloak of the Faith)
*
***************************************************************/

namespace Server.Items
{
	public class CloakOfTheFaith : Item
	{
		public CloakOfTheFaith() : base()
		{
			Id = 2902;
			Resistance[0] = 21;
			Bonding = 1;
			SellPrice = 1305;
			AvailableClasses = 0x7FFF;
			Model = 23099;
			ObjectClass = 4;
			SubClass = 1;
			Level = 30;
			Name = "Cloak of the Faith";
			Name2 = "Cloak of the Faith";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6527;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 4;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Goat Fur Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class GoatFurCloak : Item
	{
		public GoatFurCloak() : base()
		{
			Id = 2905;
			Resistance[0] = 9;
			Bonding = 1;
			SellPrice = 53;
			AvailableClasses = 0x7FFF;
			Model = 23032;
			ObjectClass = 4;
			SubClass = 1;
			Level = 10;
			Name = "Goat Fur Cloak";
			Name2 = "Goat Fur Cloak";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 266;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Watch Master's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class WatchMastersCloak : Item
	{
		public WatchMastersCloak() : base()
		{
			Id = 2953;
			Resistance[0] = 23;
			Bonding = 1;
			SellPrice = 2321;
			AvailableClasses = 0x7FFF;
			Model = 23077;
			ObjectClass = 4;
			SubClass = 1;
			Level = 33;
			Name = "Watch Master's Cloak";
			Name2 = "Watch Master's Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11606;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Wendigo Fur Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class WendigoFurCloak : Item
	{
		public WendigoFurCloak() : base()
		{
			Id = 3008;
			Resistance[0] = 8;
			SellPrice = 43;
			AvailableClasses = 0x7FFF;
			Model = 23080;
			ObjectClass = 4;
			SubClass = 1;
			Level = 9;
			ReqLevel = 4;
			Name = "Wendigo Fur Cloak";
			Name2 = "Wendigo Fur Cloak";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 218;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Hide of Lupos)
*
***************************************************************/

namespace Server.Items
{
	public class HideOfLupos : Item
	{
		public HideOfLupos() : base()
		{
			Id = 3018;
			Resistance[0] = 18;
			Bonding = 2;
			SellPrice = 781;
			AvailableClasses = 0x7FFF;
			Model = 23027;
			ObjectClass = 4;
			SubClass = 1;
			Level = 23;
			ReqLevel = 18;
			Name = "Hide of Lupos";
			Name2 = "Hide of Lupos";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3906;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 2;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Ensign Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class EnsignCloak : Item
	{
		public EnsignCloak() : base()
		{
			Id = 3070;
			Resistance[0] = 5;
			Bonding = 1;
			SellPrice = 11;
			AvailableClasses = 0x7FFF;
			Model = 15149;
			ObjectClass = 4;
			SubClass = 1;
			Level = 5;
			Name = "Ensign Cloak";
			Name2 = "Ensign Cloak";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 55;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Oil-stained Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class OilStainedCloak : Item
	{
		public OilStainedCloak() : base()
		{
			Id = 3153;
			Resistance[0] = 8;
			Bonding = 1;
			SellPrice = 33;
			AvailableClasses = 0x7FFF;
			Model = 23128;
			ObjectClass = 4;
			SubClass = 1;
			Level = 9;
			Name = "Oil-stained Cloak";
			Name2 = "Oil-stained Cloak";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 169;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Webbed Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class WebbedCloak : Item
	{
		public WebbedCloak() : base()
		{
			Id = 3261;
			Resistance[0] = 5;
			SellPrice = 7;
			AvailableClasses = 0x7FFF;
			Model = 23143;
			ObjectClass = 4;
			SubClass = 1;
			Level = 5;
			ReqLevel = 1;
			Name = "Webbed Cloak";
			Name2 = "Webbed Cloak";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 35;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Wispy Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class WispyCloak : Item
	{
		public WispyCloak() : base()
		{
			Id = 3322;
			Resistance[0] = 6;
			SellPrice = 11;
			AvailableClasses = 0x7FFF;
			Model = 23015;
			ObjectClass = 4;
			SubClass = 1;
			Level = 6;
			ReqLevel = 1;
			Name = "Wispy Cloak";
			Name2 = "Wispy Cloak";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 55;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Melrache's Cape)
*
***************************************************************/

namespace Server.Items
{
	public class MelrachesCape : Item
	{
		public MelrachesCape() : base()
		{
			Id = 3331;
			Resistance[0] = 11;
			SellPrice = 101;
			AvailableClasses = 0x7FFF;
			Model = 15196;
			ObjectClass = 4;
			SubClass = 1;
			Level = 12;
			ReqLevel = 7;
			Name = "Melrache's Cape";
			Name2 = "Melrache's Cape";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 509;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Mystic Shawl)
*
***************************************************************/

namespace Server.Items
{
	public class MysticShawl : Item
	{
		public MysticShawl() : base()
		{
			Id = 3449;
			Resistance[0] = 14;
			Bonding = 1;
			SellPrice = 207;
			AvailableClasses = 0x7FFF;
			Model = 23127;
			ObjectClass = 4;
			SubClass = 1;
			Level = 15;
			Name = "Mystic Shawl";
			Name2 = "Mystic Shawl";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1035;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			SpiritBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Cloak of Flames)
*
***************************************************************/

namespace Server.Items
{
	public class CloakOfFlames : Item
	{
		public CloakOfFlames() : base()
		{
			Id = 3475;
			Resistance[0] = 50;
			Bonding = 2;
			SellPrice = 26018;
			AvailableClasses = 0x7FFF;
			Model = 23421;
			Resistance[2] = 15;
			ObjectClass = 4;
			SubClass = 1;
			Level = 65;
			ReqLevel = 60;
			Name = "Cloak of Flames";
			Name2 = "Cloak of Flames";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 130092;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			SetSpell( 21142 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Cloak of the People's Militia)
*
***************************************************************/

namespace Server.Items
{
	public class CloakOfThePeoplesMilitia : Item
	{
		public CloakOfThePeoplesMilitia() : base()
		{
			Id = 3511;
			Resistance[0] = 14;
			Bonding = 1;
			SellPrice = 267;
			AvailableClasses = 0x7FFF;
			Model = 23020;
			ObjectClass = 4;
			SubClass = 1;
			Level = 15;
			Name = "Cloak of the People's Militia";
			Name2 = "Cloak of the People's Militia";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1338;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			AgilityBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Resilient Poncho)
*
***************************************************************/

namespace Server.Items
{
	public class ResilientPoncho : Item
	{
		public ResilientPoncho() : base()
		{
			Id = 3561;
			Resistance[0] = 20;
			Bonding = 1;
			SellPrice = 895;
			AvailableClasses = 0x7FFF;
			Model = 23135;
			ObjectClass = 4;
			SubClass = 1;
			Level = 26;
			Name = "Resilient Poncho";
			Name2 = "Resilient Poncho";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4475;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Acidproof Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class AcidproofCloak : Item
	{
		public AcidproofCloak() : base()
		{
			Id = 3582;
			Resistance[0] = 16;
			Bonding = 1;
			SellPrice = 474;
			AvailableClasses = 0x7FFF;
			Model = 23085;
			ObjectClass = 4;
			SubClass = 1;
			Level = 18;
			Name = "Acidproof Cloak";
			Name2 = "Acidproof Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2372;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Hillman's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class HillmansCloak : Item
	{
		public HillmansCloak() : base()
		{
			Id = 3719;
			Resistance[0] = 20;
			SellPrice = 1027;
			AvailableClasses = 0x7FFF;
			Model = 23040;
			ObjectClass = 4;
			SubClass = 1;
			Level = 30;
			ReqLevel = 25;
			Name = "Hillman's Cloak";
			Name2 = "Hillman's Cloak";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 5139;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(High Apothecary Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class HighApothecaryCloak : Item
	{
		public HighApothecaryCloak() : base()
		{
			Id = 3749;
			Resistance[0] = 21;
			Bonding = 1;
			SellPrice = 1320;
			AvailableClasses = 0x7FFF;
			Model = 23118;
			ObjectClass = 4;
			SubClass = 1;
			Level = 30;
			Name = "High Apothecary Cloak";
			Name2 = "High Apothecary Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6603;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 2;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Interlaced Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class InterlacedCloak : Item
	{
		public InterlacedCloak() : base()
		{
			Id = 3795;
			Resistance[0] = 21;
			SellPrice = 981;
			AvailableClasses = 0x7FFF;
			Model = 23120;
			ObjectClass = 4;
			SubClass = 1;
			Level = 36;
			ReqLevel = 31;
			Name = "Interlaced Cloak";
			Name2 = "Interlaced Cloak";
			AvailableRaces = 0x1FF;
			BuyPrice = 4909;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Hardened Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class HardenedCloak : Item
	{
		public HardenedCloak() : base()
		{
			Id = 3803;
			Resistance[0] = 23;
			SellPrice = 1086;
			AvailableClasses = 0x7FFF;
			Model = 23036;
			ObjectClass = 4;
			SubClass = 1;
			Level = 38;
			ReqLevel = 33;
			Name = "Hardened Cloak";
			Name2 = "Hardened Cloak";
			AvailableRaces = 0x1FF;
			BuyPrice = 5432;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Double-stitched Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class DoubleStitchedCloak : Item
	{
		public DoubleStitchedCloak() : base()
		{
			Id = 3811;
			Resistance[0] = 22;
			SellPrice = 1064;
			AvailableClasses = 0x7FFF;
			Model = 15121;
			ObjectClass = 4;
			SubClass = 1;
			Level = 37;
			ReqLevel = 32;
			Name = "Double-stitched Cloak";
			Name2 = "Double-stitched Cloak";
			AvailableRaces = 0x1FF;
			BuyPrice = 5323;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Adept's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class AdeptsCloak : Item
	{
		public AdeptsCloak() : base()
		{
			Id = 3833;
			Resistance[0] = 7;
			Bonding = 1;
			SellPrice = 24;
			AvailableClasses = 0x7FFF;
			Model = 23089;
			ObjectClass = 4;
			SubClass = 1;
			Level = 8;
			Name = "Adept's Cloak";
			Name2 = "Adept's Cloak";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 121;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Crochet Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class CrochetCloak : Item
	{
		public CrochetCloak() : base()
		{
			Id = 3939;
			Resistance[0] = 28;
			SellPrice = 2256;
			AvailableClasses = 0x7FFF;
			Model = 23101;
			ObjectClass = 4;
			SubClass = 1;
			Level = 47;
			ReqLevel = 42;
			Name = "Crochet Cloak";
			Name2 = "Crochet Cloak";
			AvailableRaces = 0x1FF;
			BuyPrice = 11283;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Twill Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class TwillCloak : Item
	{
		public TwillCloak() : base()
		{
			Id = 3947;
			Resistance[0] = 30;
			SellPrice = 3258;
			AvailableClasses = 0x7FFF;
			Model = 16707;
			ObjectClass = 4;
			SubClass = 1;
			Level = 52;
			ReqLevel = 47;
			Name = "Twill Cloak";
			Name2 = "Twill Cloak";
			AvailableRaces = 0x1FF;
			BuyPrice = 16292;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Thick Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class ThickCloak : Item
	{
		public ThickCloak() : base()
		{
			Id = 3964;
			Resistance[0] = 27;
			SellPrice = 2127;
			AvailableClasses = 0x7FFF;
			Model = 23070;
			ObjectClass = 4;
			SubClass = 1;
			Level = 46;
			ReqLevel = 41;
			Name = "Thick Cloak";
			Name2 = "Thick Cloak";
			AvailableRaces = 0x1FF;
			BuyPrice = 10638;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Smooth Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class SmoothCloak : Item
	{
		public SmoothCloak() : base()
		{
			Id = 3972;
			Resistance[0] = 33;
			SellPrice = 3891;
			AvailableClasses = 0x7FFF;
			Model = 23065;
			ObjectClass = 4;
			SubClass = 1;
			Level = 56;
			ReqLevel = 51;
			Name = "Smooth Cloak";
			Name2 = "Smooth Cloak";
			AvailableRaces = 0x1FF;
			BuyPrice = 19456;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Laminated Scale Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class LaminatedScaleCloak : Item
	{
		public LaminatedScaleCloak() : base()
		{
			Id = 3995;
			Resistance[0] = 33;
			SellPrice = 6284;
			AvailableClasses = 0x7FFF;
			Model = 15068;
			ObjectClass = 4;
			SubClass = 1;
			Level = 57;
			ReqLevel = 52;
			Name = "Laminated Scale Cloak";
			Name2 = "Laminated Scale Cloak";
			AvailableRaces = 0x1FF;
			BuyPrice = 31422;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Overlinked Chain Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class OverlinkedChainCloak : Item
	{
		public OverlinkedChainCloak() : base()
		{
			Id = 4003;
			Resistance[0] = 29;
			SellPrice = 4090;
			AvailableClasses = 0x7FFF;
			Model = 15106;
			ObjectClass = 4;
			SubClass = 1;
			Level = 49;
			ReqLevel = 44;
			Name = "Overlinked Chain Cloak";
			Name2 = "Overlinked Chain Cloak";
			AvailableRaces = 0x1FF;
			BuyPrice = 20451;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Medicine Blanket)
*
***************************************************************/

namespace Server.Items
{
	public class MedicineBlanket : Item
	{
		public MedicineBlanket() : base()
		{
			Id = 4113;
			Resistance[0] = 30;
			Bonding = 1;
			SellPrice = 4853;
			AvailableClasses = 0x7FFF;
			Model = 23123;
			ObjectClass = 4;
			SubClass = 1;
			Level = 45;
			Name = "Medicine Blanket";
			Name2 = "Medicine Blanket";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 24265;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 4;
			IqBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Darktide Cape)
*
***************************************************************/

namespace Server.Items
{
	public class DarktideCape : Item
	{
		public DarktideCape() : base()
		{
			Id = 4114;
			Resistance[0] = 28;
			Bonding = 1;
			SellPrice = 5826;
			AvailableClasses = 0x7FFF;
			Model = 15246;
			ObjectClass = 4;
			SubClass = 1;
			Level = 42;
			Name = "Darktide Cape";
			Name2 = "Darktide Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 29130;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 7;
			AgilityBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Heavy Woolen Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyWoolenCloak : Item
	{
		public HeavyWoolenCloak() : base()
		{
			Id = 4311;
			Resistance[0] = 17;
			Bonding = 2;
			SellPrice = 475;
			AvailableClasses = 0x7FFF;
			Model = 23117;
			ObjectClass = 4;
			SubClass = 1;
			Level = 21;
			ReqLevel = 16;
			Name = "Heavy Woolen Cloak";
			Name2 = "Heavy Woolen Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2378;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Long Silken Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class LongSilkenCloak : Item
	{
		public LongSilkenCloak() : base()
		{
			Id = 4326;
			Resistance[0] = 24;
			Bonding = 2;
			SellPrice = 2496;
			AvailableClasses = 0x7FFF;
			Model = 15076;
			ObjectClass = 4;
			SubClass = 1;
			Level = 37;
			ReqLevel = 32;
			Name = "Long Silken Cloak";
			Name2 = "Long Silken Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 12482;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			IqBonus = 6;
			SpiritBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Icy Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class IcyCloak : Item
	{
		public IcyCloak() : base()
		{
			Id = 4327;
			Resistance[0] = 29;
			Bonding = 2;
			SellPrice = 3788;
			AvailableClasses = 0x7FFF;
			Model = 15273;
			Resistance[4] = 11;
			ObjectClass = 4;
			SubClass = 1;
			Level = 40;
			ReqLevel = 35;
			Name = "Icy Cloak";
			Name2 = "Icy Cloak";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 18941;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Cloak of Night)
*
***************************************************************/

namespace Server.Items
{
	public class CloakOfNight : Item
	{
		public CloakOfNight() : base()
		{
			Id = 4447;
			Resistance[0] = 20;
			Bonding = 2;
			SellPrice = 901;
			AvailableClasses = 0x7FFF;
			Model = 23019;
			ObjectClass = 4;
			SubClass = 1;
			Level = 26;
			ReqLevel = 21;
			Name = "Cloak of Night";
			Name2 = "Cloak of Night";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4509;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			AgilityBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Cloak of Rot)
*
***************************************************************/

namespace Server.Items
{
	public class CloakOfRot : Item
	{
		public CloakOfRot() : base()
		{
			Id = 4462;
			Resistance[0] = 22;
			Bonding = 2;
			SellPrice = 1425;
			AvailableClasses = 0x7FFF;
			Model = 23098;
			ObjectClass = 4;
			SubClass = 1;
			Level = 31;
			ReqLevel = 26;
			Name = "Cloak of Rot";
			Name2 = "Cloak of Rot";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7126;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = -5;
			SpiritBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Dwarven Guard Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class DwarvenGuardCloak : Item
	{
		public DwarvenGuardCloak() : base()
		{
			Id = 4504;
			Resistance[0] = 22;
			Bonding = 1;
			SellPrice = 2222;
			AvailableClasses = 0x7FFF;
			Model = 15183;
			ObjectClass = 4;
			SubClass = 1;
			Level = 31;
			Name = "Dwarven Guard Cloak";
			Name2 = "Dwarven Guard Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11112;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 6;
			AgilityBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Grimsteel Cape)
*
***************************************************************/

namespace Server.Items
{
	public class GrimsteelCape : Item
	{
		public GrimsteelCape() : base()
		{
			Id = 4643;
			Resistance[0] = 23;
			Bonding = 1;
			SellPrice = 2748;
			AvailableClasses = 0x7FFF;
			Model = 15079;
			ObjectClass = 4;
			SubClass = 1;
			Level = 33;
			Name = "Grimsteel Cape";
			Name2 = "Grimsteel Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 13741;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 6;
			AgilityBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Warrior's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class WarriorsCloak : Item
	{
		public WarriorsCloak() : base()
		{
			Id = 4658;
			Resistance[0] = 7;
			SellPrice = 23;
			AvailableClasses = 0x7FFF;
			Model = 25945;
			ObjectClass = 4;
			SubClass = 1;
			Level = 8;
			ReqLevel = 3;
			Name = "Warrior's Cloak";
			Name2 = "Warrior's Cloak";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 118;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Journeyman's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class JourneymansCloak : Item
	{
		public JourneymansCloak() : base()
		{
			Id = 4662;
			Resistance[0] = 7;
			SellPrice = 24;
			AvailableClasses = 0x7FFF;
			Model = 15061;
			ObjectClass = 4;
			SubClass = 1;
			Level = 8;
			ReqLevel = 3;
			Name = "Journeyman's Cloak";
			Name2 = "Journeyman's Cloak";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 123;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Burnt Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class BurntCloak : Item
	{
		public BurntCloak() : base()
		{
			Id = 4665;
			Resistance[0] = 7;
			SellPrice = 22;
			AvailableClasses = 0x7FFF;
			Model = 23015;
			ObjectClass = 4;
			SubClass = 1;
			Level = 8;
			ReqLevel = 3;
			Name = "Burnt Cloak";
			Name2 = "Burnt Cloak";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 113;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Battle Chain Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class BattleChainCloak : Item
	{
		public BattleChainCloak() : base()
		{
			Id = 4668;
			Resistance[0] = 8;
			SellPrice = 32;
			AvailableClasses = 0x7FFF;
			Model = 26979;
			ObjectClass = 4;
			SubClass = 1;
			Level = 9;
			ReqLevel = 4;
			Name = "Battle Chain Cloak";
			Name2 = "Battle Chain Cloak";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 160;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Ancestral Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class AncestralCloak : Item
	{
		public AncestralCloak() : base()
		{
			Id = 4671;
			Resistance[0] = 8;
			SellPrice = 32;
			AvailableClasses = 0x7FFF;
			Model = 25657;
			ObjectClass = 4;
			SubClass = 1;
			Level = 9;
			ReqLevel = 4;
			Name = "Ancestral Cloak";
			Name2 = "Ancestral Cloak";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 162;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Tribal Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class TribalCloak : Item
	{
		public TribalCloak() : base()
		{
			Id = 4674;
			Resistance[0] = 8;
			SellPrice = 32;
			AvailableClasses = 0x7FFF;
			Model = 27997;
			ObjectClass = 4;
			SubClass = 1;
			Level = 9;
			ReqLevel = 4;
			Name = "Tribal Cloak";
			Name2 = "Tribal Cloak";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 164;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Veteran Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class VeteranCloak : Item
	{
		public VeteranCloak() : base()
		{
			Id = 4677;
			Resistance[0] = 11;
			SellPrice = 70;
			AvailableClasses = 0x7FFF;
			Model = 25950;
			ObjectClass = 4;
			SubClass = 1;
			Level = 12;
			ReqLevel = 7;
			Name = "Veteran Cloak";
			Name2 = "Veteran Cloak";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 351;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Brackwater Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class BrackwaterCloak : Item
	{
		public BrackwaterCloak() : base()
		{
			Id = 4680;
			Resistance[0] = 12;
			SellPrice = 91;
			AvailableClasses = 0x7FFF;
			Model = 26981;
			ObjectClass = 4;
			SubClass = 1;
			Level = 13;
			ReqLevel = 8;
			Name = "Brackwater Cloak";
			Name2 = "Brackwater Cloak";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 456;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Spellbinder Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class SpellbinderCloak : Item
	{
		public SpellbinderCloak() : base()
		{
			Id = 4683;
			Resistance[0] = 12;
			SellPrice = 92;
			AvailableClasses = 0x7FFF;
			Model = 23113;
			ObjectClass = 4;
			SubClass = 1;
			Level = 13;
			ReqLevel = 8;
			Name = "Spellbinder Cloak";
			Name2 = "Spellbinder Cloak";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 461;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Barbaric Cloth Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class BarbaricClothCloak : Item
	{
		public BarbaricClothCloak() : base()
		{
			Id = 4686;
			Resistance[0] = 11;
			SellPrice = 67;
			AvailableClasses = 0x7FFF;
			Model = 23137;
			ObjectClass = 4;
			SubClass = 1;
			Level = 12;
			ReqLevel = 7;
			Name = "Barbaric Cloth Cloak";
			Name2 = "Barbaric Cloth Cloak";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 336;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Hunting Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class HuntingCloak : Item
	{
		public HuntingCloak() : base()
		{
			Id = 4689;
			Resistance[0] = 12;
			SellPrice = 106;
			AvailableClasses = 0x7FFF;
			Model = 23041;
			ObjectClass = 4;
			SubClass = 1;
			Level = 13;
			ReqLevel = 8;
			Name = "Hunting Cloak";
			Name2 = "Hunting Cloak";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 532;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Ceremonial Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class CeremonialCloak : Item
	{
		public CeremonialCloak() : base()
		{
			Id = 4692;
			Resistance[0] = 11;
			SellPrice = 68;
			AvailableClasses = 0x7FFF;
			Model = 28049;
			ObjectClass = 4;
			SubClass = 1;
			Level = 12;
			ReqLevel = 7;
			Name = "Ceremonial Cloak";
			Name2 = "Ceremonial Cloak";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 344;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Burnished Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class BurnishedCloak : Item
	{
		public BurnishedCloak() : base()
		{
			Id = 4695;
			Resistance[0] = 16;
			Bonding = 2;
			SellPrice = 327;
			AvailableClasses = 0x7FFF;
			Model = 26048;
			ObjectClass = 4;
			SubClass = 1;
			Level = 18;
			ReqLevel = 13;
			Name = "Burnished Cloak";
			Name2 = "Burnished Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1635;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Inscribed Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class InscribedCloak : Item
	{
		public InscribedCloak() : base()
		{
			Id = 4701;
			Resistance[0] = 15;
			Bonding = 2;
			SellPrice = 252;
			AvailableClasses = 0x7FFF;
			Model = 23044;
			ObjectClass = 4;
			SubClass = 1;
			Level = 16;
			ReqLevel = 11;
			Name = "Inscribed Cloak";
			Name2 = "Inscribed Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1263;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Lambent Scale Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class LambentScaleCloak : Item
	{
		public LambentScaleCloak() : base()
		{
			Id = 4706;
			Resistance[0] = 19;
			Bonding = 2;
			SellPrice = 687;
			AvailableClasses = 0x7FFF;
			Model = 25979;
			ObjectClass = 4;
			SubClass = 1;
			Level = 24;
			ReqLevel = 19;
			Name = "Lambent Scale Cloak";
			Name2 = "Lambent Scale Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3438;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StrBonus = 4;
			IqBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Forest Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class ForestCloak : Item
	{
		public ForestCloak() : base()
		{
			Id = 4710;
			Resistance[0] = 18;
			Bonding = 2;
			SellPrice = 561;
			AvailableClasses = 0x7FFF;
			Model = 23029;
			ObjectClass = 4;
			SubClass = 1;
			Level = 22;
			ReqLevel = 17;
			Name = "Forest Cloak";
			Name2 = "Forest Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2808;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 3;
			SpiritBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Glimmering Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class GlimmeringCloak : Item
	{
		public GlimmeringCloak() : base()
		{
			Id = 4711;
			Resistance[0] = 21;
			Bonding = 2;
			SellPrice = 1112;
			AvailableClasses = 0x7FFF;
			Model = 26047;
			ObjectClass = 4;
			SubClass = 1;
			Level = 28;
			ReqLevel = 23;
			Name = "Glimmering Cloak";
			Name2 = "Glimmering Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5561;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 2;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Silver-thread Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class SilverThreadCloak : Item
	{
		public SilverThreadCloak() : base()
		{
			Id = 4713;
			Resistance[0] = 20;
			Bonding = 2;
			SellPrice = 926;
			AvailableClasses = 0x7FFF;
			Model = 23140;
			ObjectClass = 4;
			SubClass = 1;
			Level = 26;
			ReqLevel = 21;
			Name = "Silver-thread Cloak";
			Name2 = "Silver-thread Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4630;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			SpiritBonus = 4;
			IqBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Emblazoned Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class EmblazonedCloak : Item
	{
		public EmblazonedCloak() : base()
		{
			Id = 4715;
			Resistance[0] = 20;
			Bonding = 2;
			SellPrice = 1026;
			AvailableClasses = 0x7FFF;
			Model = 23024;
			ObjectClass = 4;
			SubClass = 1;
			Level = 27;
			ReqLevel = 22;
			Name = "Emblazoned Cloak";
			Name2 = "Emblazoned Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5130;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 5;
			IqBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Combat Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class CombatCloak : Item
	{
		public CombatCloak() : base()
		{
			Id = 4716;
			Resistance[0] = 22;
			Bonding = 2;
			SellPrice = 1658;
			AvailableClasses = 0x7FFF;
			Model = 26016;
			ObjectClass = 4;
			SubClass = 1;
			Level = 32;
			ReqLevel = 27;
			Name = "Combat Cloak";
			Name2 = "Combat Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 8294;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 6;
			IqBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Nightsky Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class NightskyCloak : Item
	{
		public NightskyCloak() : base()
		{
			Id = 4719;
			Resistance[0] = 22;
			Bonding = 2;
			SellPrice = 1676;
			AvailableClasses = 0x7FFF;
			Model = 18131;
			ObjectClass = 4;
			SubClass = 1;
			Level = 32;
			ReqLevel = 27;
			Name = "Nightsky Cloak";
			Name2 = "Nightsky Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 8383;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 2;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Insignia Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class InsigniaCloak : Item
	{
		public InsigniaCloak() : base()
		{
			Id = 4722;
			Resistance[0] = 22;
			Bonding = 2;
			SellPrice = 2118;
			AvailableClasses = 0x7FFF;
			Model = 23045;
			ObjectClass = 4;
			SubClass = 1;
			Level = 32;
			ReqLevel = 27;
			Name = "Insignia Cloak";
			Name2 = "Insignia Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 10591;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 2;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Chief Brigadier Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class ChiefBrigadierCloak : Item
	{
		public ChiefBrigadierCloak() : base()
		{
			Id = 4726;
			Resistance[0] = 24;
			Bonding = 2;
			SellPrice = 2340;
			AvailableClasses = 0x7FFF;
			Model = 25900;
			ObjectClass = 4;
			SubClass = 1;
			Level = 36;
			ReqLevel = 31;
			Name = "Chief Brigadier Cloak";
			Name2 = "Chief Brigadier Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11703;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 7;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Glyphed Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class GlyphedCloak : Item
	{
		public GlyphedCloak() : base()
		{
			Id = 4732;
			Resistance[0] = 24;
			Bonding = 2;
			SellPrice = 2632;
			AvailableClasses = 0x7FFF;
			Model = 23031;
			ObjectClass = 4;
			SubClass = 1;
			Level = 37;
			ReqLevel = 32;
			Name = "Glyphed Cloak";
			Name2 = "Glyphed Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 13162;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 2;
			SpiritBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Mistscape Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class MistscapeCloak : Item
	{
		public MistscapeCloak() : base()
		{
			Id = 4735;
			Resistance[0] = 27;
			Bonding = 2;
			SellPrice = 3621;
			AvailableClasses = 0x7FFF;
			Model = 23125;
			ObjectClass = 4;
			SubClass = 1;
			Level = 41;
			ReqLevel = 36;
			Name = "Mistscape Cloak";
			Name2 = "Mistscape Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 18105;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 3;
			IqBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Harvest Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class HarvestCloak : Item
	{
		public HarvestCloak() : base()
		{
			Id = 4771;
			Resistance[0] = 14;
			Bonding = 2;
			SellPrice = 264;
			AvailableClasses = 0x7FFF;
			Model = 23012;
			ObjectClass = 4;
			SubClass = 1;
			Level = 15;
			ReqLevel = 10;
			Name = "Harvest Cloak";
			Name2 = "Harvest Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1324;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			IqBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Warm Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class WarmCloak : Item
	{
		public WarmCloak() : base()
		{
			Id = 4772;
			Resistance[0] = 10;
			SellPrice = 70;
			AvailableClasses = 0x7FFF;
			Model = 23075;
			ObjectClass = 4;
			SubClass = 1;
			Level = 11;
			ReqLevel = 6;
			Name = "Warm Cloak";
			Name2 = "Warm Cloak";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 353;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Inferno Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class InfernoCloak : Item
	{
		public InfernoCloak() : base()
		{
			Id = 4790;
			Resistance[0] = 19;
			Bonding = 2;
			SellPrice = 831;
			AvailableClasses = 0x7FFF;
			Model = 15165;
			Resistance[2] = 5;
			ObjectClass = 4;
			SubClass = 1;
			Level = 25;
			ReqLevel = 20;
			Name = "Inferno Cloak";
			Name2 = "Inferno Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4158;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Spirit Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class SpiritCloak : Item
	{
		public SpiritCloak() : base()
		{
			Id = 4792;
			Resistance[0] = 18;
			Bonding = 2;
			SellPrice = 655;
			AvailableClasses = 0x7FFF;
			Model = 23131;
			ObjectClass = 4;
			SubClass = 1;
			Level = 23;
			ReqLevel = 18;
			Name = "Spirit Cloak";
			Name2 = "Spirit Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3279;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Sylvan Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class SylvanCloak : Item
	{
		public SylvanCloak() : base()
		{
			Id = 4793;
			Resistance[0] = 19;
			Bonding = 2;
			SellPrice = 744;
			AvailableClasses = 0x7FFF;
			Model = 15247;
			ObjectClass = 4;
			SubClass = 1;
			Level = 24;
			ReqLevel = 19;
			Name = "Sylvan Cloak";
			Name2 = "Sylvan Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3720;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 2;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Fiery Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class FieryCloak : Item
	{
		public FieryCloak() : base()
		{
			Id = 4797;
			Resistance[0] = 19;
			Bonding = 2;
			SellPrice = 852;
			AvailableClasses = 0x7FFF;
			Model = 15161;
			Resistance[2] = 5;
			ObjectClass = 4;
			SubClass = 1;
			Level = 25;
			ReqLevel = 20;
			Name = "Fiery Cloak";
			Name2 = "Fiery Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4262;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Heavy Runed Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyRunedCloak : Item
	{
		public HeavyRunedCloak() : base()
		{
			Id = 4798;
			Resistance[0] = 19;
			Bonding = 2;
			SellPrice = 1166;
			AvailableClasses = 0x7FFF;
			Model = 15206;
			ObjectClass = 4;
			SubClass = 1;
			Level = 25;
			ReqLevel = 20;
			Name = "Heavy Runed Cloak";
			Name2 = "Heavy Runed Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5832;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 3;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Antiquated Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class AntiquatedCloak : Item
	{
		public AntiquatedCloak() : base()
		{
			Id = 4799;
			Resistance[0] = 18;
			Bonding = 2;
			SellPrice = 608;
			AvailableClasses = 0x7FFF;
			Model = 23087;
			ObjectClass = 4;
			SubClass = 1;
			Level = 23;
			ReqLevel = 18;
			Name = "Antiquated Cloak";
			Name2 = "Antiquated Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3042;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Demon Scarred Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class DemonScarredCloak : Item
	{
		public DemonScarredCloak() : base()
		{
			Id = 4854;
			Resistance[0] = 10;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 23103;
			ObjectClass = 4;
			SubClass = 1;
			Level = 11;
			ReqLevel = 6;
			Name = "Demon Scarred Cloak";
			Name2 = "Demon Scarred Cloak";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			StartQuest = 770;
			MaxCount = 1;
			Material = 7;
			Flags = 2048;
		}
	}
}


/**************************************************************
*
*				(Battleworn Cape)
*
***************************************************************/

namespace Server.Items
{
	public class BattlewornCape : Item
	{
		public BattlewornCape() : base()
		{
			Id = 4920;
			Resistance[0] = 5;
			Bonding = 1;
			SellPrice = 7;
			AvailableClasses = 0x7FFF;
			Model = 23007;
			ObjectClass = 4;
			SubClass = 1;
			Level = 5;
			Name = "Battleworn Cape";
			Name2 = "Battleworn Cape";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 37;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Seasoned Fighter's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class SeasonedFightersCloak : Item
	{
		public SeasonedFightersCloak() : base()
		{
			Id = 4933;
			Resistance[0] = 8;
			Bonding = 1;
			SellPrice = 48;
			AvailableClasses = 0x7FFF;
			Model = 15211;
			ObjectClass = 4;
			SubClass = 1;
			Level = 9;
			Name = "Seasoned Fighter's Cloak";
			Name2 = "Seasoned Fighter's Cloak";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 241;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Handsewn Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class HandsewnCloak : Item
	{
		public HandsewnCloak() : base()
		{
			Id = 4944;
			Resistance[0] = 11;
			Bonding = 1;
			SellPrice = 72;
			AvailableClasses = 0x7FFF;
			Model = 23116;
			ObjectClass = 4;
			SubClass = 1;
			Level = 12;
			Name = "Handsewn Cloak";
			Name2 = "Handsewn Cloak";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 361;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Sun-beaten Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class SunBeatenCloak : Item
	{
		public SunBeatenCloak() : base()
		{
			Id = 4958;
			Resistance[0] = 7;
			Bonding = 1;
			SellPrice = 36;
			AvailableClasses = 0x7FFF;
			Model = 15244;
			ObjectClass = 4;
			SubClass = 1;
			Level = 8;
			Name = "Sun-beaten Cloak";
			Name2 = "Sun-beaten Cloak";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 180;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Thunderhorn Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class ThunderhornCloak : Item
	{
		public ThunderhornCloak() : base()
		{
			Id = 4963;
			Resistance[0] = 7;
			Bonding = 1;
			SellPrice = 30;
			AvailableClasses = 0x7FFF;
			Model = 23071;
			ObjectClass = 4;
			SubClass = 1;
			Level = 8;
			Name = "Thunderhorn Cloak";
			Name2 = "Thunderhorn Cloak";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 152;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Rathorian's Cape)
*
***************************************************************/

namespace Server.Items
{
	public class RathoriansCape : Item
	{
		public RathoriansCape() : base()
		{
			Id = 5111;
			Resistance[0] = 14;
			Bonding = 2;
			SellPrice = 320;
			AvailableClasses = 0x7FFF;
			Model = 18133;
			ObjectClass = 4;
			SubClass = 1;
			Level = 15;
			ReqLevel = 10;
			Name = "Rathorian's Cape";
			Name2 = "Rathorian's Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1601;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Vibrant Silk Cape)
*
***************************************************************/

namespace Server.Items
{
	public class VibrantSilkCape : Item
	{
		public VibrantSilkCape() : base()
		{
			Id = 5181;
			Resistance[0] = 23;
			Bonding = 2;
			SellPrice = 1778;
			AvailableClasses = 0x7FFF;
			Model = 23142;
			ObjectClass = 4;
			SubClass = 1;
			Level = 33;
			ReqLevel = 28;
			Name = "Vibrant Silk Cape";
			Name2 = "Vibrant Silk Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 8890;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			SpiritBonus = 1;
			IqBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Cape of the Brotherhood)
*
***************************************************************/

namespace Server.Items
{
	public class CapeOfTheBrotherhood : Item
	{
		public CapeOfTheBrotherhood() : base()
		{
			Id = 5193;
			Resistance[0] = 21;
			Bonding = 1;
			SellPrice = 940;
			AvailableClasses = 0x7FFF;
			Model = 22998;
			ObjectClass = 4;
			SubClass = 1;
			Level = 25;
			ReqLevel = 20;
			Name = "Cape of the Brotherhood";
			Name2 = "Cape of the Brotherhood";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 4700;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			AgilityBonus = 6;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Dark Hooded Cape)
*
***************************************************************/

namespace Server.Items
{
	public class DarkHoodedCape : Item
	{
		public DarkHoodedCape() : base()
		{
			Id = 5257;
			Resistance[0] = 27;
			Bonding = 2;
			SellPrice = 3159;
			AvailableClasses = 0x7FFF;
			Model = 23000;
			ObjectClass = 4;
			SubClass = 1;
			Level = 37;
			ReqLevel = 32;
			Name = "Dark Hooded Cape";
			Name2 = "Dark Hooded Cape";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 15799;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			AgilityBonus = 10;
			StrBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Boar Hunter's Cape)
*
***************************************************************/

namespace Server.Items
{
	public class BoarHuntersCape : Item
	{
		public BoarHuntersCape() : base()
		{
			Id = 5314;
			Resistance[0] = 17;
			Bonding = 1;
			SellPrice = 528;
			AvailableClasses = 0x7FFF;
			Model = 23012;
			ObjectClass = 4;
			SubClass = 1;
			Level = 20;
			Name = "Boar Hunter's Cape";
			Name2 = "Boar Hunter's Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2643;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Barkeeper's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class BarkeepersCloak : Item
	{
		public BarkeepersCloak() : base()
		{
			Id = 5343;
			Resistance[0] = 16;
			Bonding = 1;
			SellPrice = 462;
			AvailableClasses = 0x7FFF;
			Model = 23088;
			ObjectClass = 4;
			SubClass = 1;
			Level = 18;
			Name = "Barkeeper's Cloak";
			Name2 = "Barkeeper's Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2310;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Enchanted Moonstalker Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class EnchantedMoonstalkerCloak : Item
	{
		public EnchantedMoonstalkerCloak() : base()
		{
			Id = 5387;
			Resistance[0] = 17;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 23108;
			ObjectClass = 4;
			SubClass = 1;
			Level = 20;
			Name = "Enchanted Moonstalker Cloak";
			Name2 = "Enchanted Moonstalker Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Flags = 32832;
			SetSpell( 6298 , 0 , 1 , 1000 , 0 , -1 );
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Draped Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class DrapedCloak : Item
	{
		public DrapedCloak() : base()
		{
			Id = 5405;
			Resistance[0] = 5;
			Bonding = 1;
			SellPrice = 7;
			AvailableClasses = 0x7FFF;
			Model = 23105;
			ObjectClass = 4;
			SubClass = 1;
			Level = 5;
			Name = "Draped Cloak";
			Name2 = "Draped Cloak";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 36;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Miner's Cape)
*
***************************************************************/

namespace Server.Items
{
	public class MinersCape : Item
	{
		public MinersCape() : base()
		{
			Id = 5444;
			Resistance[0] = 16;
			Bonding = 1;
			SellPrice = 548;
			AvailableClasses = 0x7FFF;
			Model = 15089;
			ObjectClass = 4;
			SubClass = 1;
			Level = 19;
			ReqLevel = 14;
			Name = "Miner's Cape";
			Name2 = "Miner's Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2740;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Pearl-clasped Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class PearlClaspedCloak : Item
	{
		public PearlClaspedCloak() : base()
		{
			Id = 5542;
			Resistance[0] = 16;
			Bonding = 2;
			SellPrice = 370;
			AvailableClasses = 0x7FFF;
			Model = 23131;
			ObjectClass = 4;
			SubClass = 1;
			Level = 19;
			ReqLevel = 14;
			Name = "Pearl-clasped Cloak";
			Name2 = "Pearl-clasped Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1852;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			SpiritBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Rain-spotted Cape)
*
***************************************************************/

namespace Server.Items
{
	public class RainSpottedCape : Item
	{
		public RainSpottedCape() : base()
		{
			Id = 5591;
			Resistance[0] = 10;
			Bonding = 1;
			SellPrice = 67;
			AvailableClasses = 0x7FFF;
			Model = 23055;
			ObjectClass = 4;
			SubClass = 1;
			Level = 11;
			Name = "Rain-spotted Cape";
			Name2 = "Rain-spotted Cape";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 338;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Gustweald Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class GustwealdCloak : Item
	{
		public GustwealdCloak() : base()
		{
			Id = 5610;
			Resistance[0] = 14;
			Bonding = 1;
			SellPrice = 208;
			AvailableClasses = 0x7FFF;
			Model = 23115;
			ObjectClass = 4;
			SubClass = 1;
			Level = 15;
			Name = "Gustweald Cloak";
			Name2 = "Gustweald Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1040;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Scout's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class ScoutsCloak : Item
	{
		public ScoutsCloak() : base()
		{
			Id = 5618;
			Resistance[0] = 10;
			Bonding = 1;
			SellPrice = 86;
			AvailableClasses = 0x7FFF;
			Model = 15032;
			ObjectClass = 4;
			SubClass = 1;
			Level = 11;
			Name = "Scout's Cloak";
			Name2 = "Scout's Cloak";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 430;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Webwing Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class WebwingCloak : Item
	{
		public WebwingCloak() : base()
		{
			Id = 5751;
			Resistance[0] = 19;
			Bonding = 2;
			SellPrice = 1028;
			AvailableClasses = 0x7FFF;
			Model = 23078;
			ObjectClass = 4;
			SubClass = 1;
			Level = 25;
			ReqLevel = 20;
			Name = "Webwing Cloak";
			Name2 = "Webwing Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5140;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			AgilityBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Guardian Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class GuardianCloak : Item
	{
		public GuardianCloak() : base()
		{
			Id = 5965;
			Resistance[0] = 24;
			Bonding = 2;
			SellPrice = 2536;
			AvailableClasses = 0x7FFF;
			Model = 23033;
			ObjectClass = 4;
			SubClass = 1;
			Level = 37;
			ReqLevel = 32;
			Name = "Guardian Cloak";
			Name2 = "Guardian Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 12680;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			IqBonus = 6;
			SpiritBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Regent's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class RegentsCloak : Item
	{
		public RegentsCloak() : base()
		{
			Id = 5969;
			Resistance[0] = 18;
			Bonding = 2;
			SellPrice = 781;
			AvailableClasses = 0x7FFF;
			Model = 23059;
			ObjectClass = 4;
			SubClass = 1;
			Level = 23;
			ReqLevel = 18;
			Name = "Regent's Cloak";
			Name2 = "Regent's Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3908;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Feathered Cape)
*
***************************************************************/

namespace Server.Items
{
	public class FeatheredCape : Item
	{
		public FeatheredCape() : base()
		{
			Id = 5971;
			Resistance[0] = 20;
			Bonding = 2;
			SellPrice = 1136;
			AvailableClasses = 0x7FFF;
			Model = 23026;
			ObjectClass = 4;
			SubClass = 1;
			Level = 26;
			ReqLevel = 21;
			Name = "Feathered Cape";
			Name2 = "Feathered Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5681;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 4;
			AgilityBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Privateer's Cape)
*
***************************************************************/

namespace Server.Items
{
	public class PrivateersCape : Item
	{
		public PrivateersCape() : base()
		{
			Id = 6179;
			Resistance[0] = 16;
			Bonding = 2;
			SellPrice = 556;
			AvailableClasses = 0x7FFF;
			Model = 15166;
			ObjectClass = 4;
			SubClass = 1;
			Level = 19;
			ReqLevel = 14;
			Name = "Privateer's Cape";
			Name2 = "Privateer's Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2782;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 2;
			AgilityBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Bear Shawl)
*
***************************************************************/

namespace Server.Items
{
	public class BearShawl : Item
	{
		public BearShawl() : base()
		{
			Id = 6185;
			Resistance[0] = 5;
			Bonding = 1;
			SellPrice = 9;
			AvailableClasses = 0x7FFF;
			Model = 23008;
			ObjectClass = 4;
			SubClass = 1;
			Level = 5;
			Name = "Bear Shawl";
			Name2 = "Bear Shawl";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 47;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Wolfmaster Cape)
*
***************************************************************/

namespace Server.Items
{
	public class WolfmasterCape : Item
	{
		public WolfmasterCape() : base()
		{
			Id = 6314;
			Resistance[0] = 20;
			Bonding = 1;
			SellPrice = 1268;
			AvailableClasses = 0x7FFF;
			Model = 23082;
			ObjectClass = 4;
			SubClass = 1;
			Level = 27;
			ReqLevel = 22;
			Name = "Wolfmaster Cape";
			Name2 = "Wolfmaster Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6343;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 2;
			AgilityBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Fenrus' Hide)
*
***************************************************************/

namespace Server.Items
{
	public class FenrusHide : Item
	{
		public FenrusHide() : base()
		{
			Id = 6340;
			Resistance[0] = 20;
			Bonding = 1;
			SellPrice = 875;
			AvailableClasses = 0x7FFF;
			Model = 23027;
			ObjectClass = 4;
			SubClass = 1;
			Level = 26;
			ReqLevel = 21;
			Name = "Fenrus' Hide";
			Name2 = "Fenrus' Hide";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4375;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			AgilityBonus = 4;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Seer's Cape)
*
***************************************************************/

namespace Server.Items
{
	public class SeersCape : Item
	{
		public SeersCape() : base()
		{
			Id = 6378;
			Resistance[0] = 15;
			Bonding = 2;
			SellPrice = 292;
			AvailableClasses = 0x7FFF;
			Model = 23139;
			ObjectClass = 4;
			SubClass = 1;
			Level = 17;
			ReqLevel = 12;
			Name = "Seer's Cape";
			Name2 = "Seer's Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1463;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			IqBonus = 2;
			SpiritBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Bright Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class BrightCloak : Item
	{
		public BrightCloak() : base()
		{
			Id = 6381;
			Resistance[0] = 18;
			Bonding = 2;
			SellPrice = 625;
			AvailableClasses = 0x7FFF;
			Model = 27549;
			ObjectClass = 4;
			SubClass = 1;
			Level = 23;
			ReqLevel = 18;
			Name = "Bright Cloak";
			Name2 = "Bright Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3127;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 2;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Aurora Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class AuroraCloak : Item
	{
		public AuroraCloak() : base()
		{
			Id = 6417;
			Resistance[0] = 24;
			Bonding = 2;
			SellPrice = 2536;
			AvailableClasses = 0x7FFF;
			Model = 23091;
			ObjectClass = 4;
			SubClass = 1;
			Level = 37;
			ReqLevel = 32;
			Name = "Aurora Cloak";
			Name2 = "Aurora Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 12680;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			IqBonus = 7;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Blackforge Cape)
*
***************************************************************/

namespace Server.Items
{
	public class BlackforgeCape : Item
	{
		public BlackforgeCape() : base()
		{
			Id = 6424;
			Resistance[0] = 28;
			Bonding = 2;
			SellPrice = 3825;
			AvailableClasses = 0x7FFF;
			Model = 26082;
			ObjectClass = 4;
			SubClass = 1;
			Level = 42;
			ReqLevel = 37;
			Name = "Blackforge Cape";
			Name2 = "Blackforge Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 19127;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			IqBonus = 4;
			SpiritBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Imperial Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class ImperialCloak : Item
	{
		public ImperialCloak() : base()
		{
			Id = 6432;
			Resistance[0] = 27;
			Bonding = 2;
			SellPrice = 3741;
			AvailableClasses = 0x7FFF;
			Model = 23039;
			ObjectClass = 4;
			SubClass = 1;
			Level = 41;
			ReqLevel = 36;
			Name = "Imperial Cloak";
			Name2 = "Imperial Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 18708;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 3;
			AgilityBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Glowing Lizardscale Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class GlowingLizardscaleCloak : Item
	{
		public GlowingLizardscaleCloak() : base()
		{
			Id = 6449;
			Resistance[0] = 20;
			Bonding = 1;
			SellPrice = 701;
			AvailableClasses = 0x7FFF;
			Model = 23001;
			ObjectClass = 4;
			SubClass = 1;
			Level = 22;
			ReqLevel = 17;
			Name = "Glowing Lizardscale Cloak";
			Name2 = "Glowing Lizardscale Cloak";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 3509;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			AgilityBonus = 6;
			IqBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Deviate Scale Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class DeviateScaleCloak : Item
	{
		public DeviateScaleCloak() : base()
		{
			Id = 6466;
			Resistance[0] = 16;
			Bonding = 2;
			SellPrice = 413;
			AvailableClasses = 0x7FFF;
			Model = 23010;
			ObjectClass = 4;
			SubClass = 1;
			Level = 18;
			ReqLevel = 13;
			Name = "Deviate Scale Cloak";
			Name2 = "Deviate Scale Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2067;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 2;
			AgilityBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Infantry Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class InfantryCloak : Item
	{
		public InfantryCloak() : base()
		{
			Id = 6508;
			Resistance[0] = 8;
			SellPrice = 34;
			AvailableClasses = 0x7FFF;
			Model = 25948;
			ObjectClass = 4;
			SubClass = 1;
			Level = 9;
			ReqLevel = 4;
			Name = "Infantry Cloak";
			Name2 = "Infantry Cloak";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 172;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Disciple's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class DisciplesCloak : Item
	{
		public DisciplesCloak() : base()
		{
			Id = 6514;
			Resistance[0] = 9;
			SellPrice = 42;
			AvailableClasses = 0x7FFF;
			Model = 23104;
			ObjectClass = 4;
			SubClass = 1;
			Level = 10;
			ReqLevel = 5;
			Name = "Disciple's Cloak";
			Name2 = "Disciple's Cloak";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 212;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Pioneer Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class PioneerCloak : Item
	{
		public PioneerCloak() : base()
		{
			Id = 6520;
			Resistance[0] = 8;
			SellPrice = 41;
			AvailableClasses = 0x7FFF;
			Model = 23052;
			ObjectClass = 4;
			SubClass = 1;
			Level = 9;
			ReqLevel = 4;
			Name = "Pioneer Cloak";
			Name2 = "Pioneer Cloak";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 209;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Willow Cape)
*
***************************************************************/

namespace Server.Items
{
	public class WillowCape : Item
	{
		public WillowCape() : base()
		{
			Id = 6542;
			Resistance[0] = 14;
			Bonding = 2;
			SellPrice = 219;
			AvailableClasses = 0x7FFF;
			Model = 15267;
			ObjectClass = 4;
			SubClass = 1;
			Level = 15;
			ReqLevel = 10;
			Name = "Willow Cape";
			Name2 = "Willow Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 959;
			BuyPrice = 1099;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Soldier's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class SoldiersCloak : Item
	{
		public SoldiersCloak() : base()
		{
			Id = 6549;
			Resistance[0] = 12;
			SellPrice = 101;
			AvailableClasses = 0x7FFF;
			Model = 25953;
			ObjectClass = 4;
			SubClass = 1;
			Level = 14;
			ReqLevel = 9;
			Name = "Soldier's Cloak";
			Name2 = "Soldier's Cloak";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 509;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Bard's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class BardsCloak : Item
	{
		public BardsCloak() : base()
		{
			Id = 6555;
			Resistance[0] = 12;
			SellPrice = 130;
			AvailableClasses = 0x7FFF;
			Model = 23006;
			ObjectClass = 4;
			SubClass = 1;
			Level = 14;
			ReqLevel = 9;
			Name = "Bard's Cloak";
			Name2 = "Bard's Cloak";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 652;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Shimmering Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class ShimmeringCloak : Item
	{
		public ShimmeringCloak() : base()
		{
			Id = 6564;
			Resistance[0] = 17;
			Bonding = 2;
			SellPrice = 512;
			AvailableClasses = 0x7FFF;
			Model = 23109;
			ObjectClass = 4;
			SubClass = 1;
			Level = 21;
			ReqLevel = 16;
			Name = "Shimmering Cloak";
			Name2 = "Shimmering Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 961;
			BuyPrice = 2560;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Defender Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class DefenderCloak : Item
	{
		public DefenderCloak() : base()
		{
			Id = 6575;
			Resistance[0] = 17;
			Bonding = 2;
			SellPrice = 431;
			AvailableClasses = 0x7FFF;
			Model = 25967;
			ObjectClass = 4;
			SubClass = 1;
			Level = 20;
			ReqLevel = 15;
			Name = "Defender Cloak";
			Name2 = "Defender Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1003;
			BuyPrice = 2155;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Scouting Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class ScoutingCloak : Item
	{
		public ScoutingCloak() : base()
		{
			Id = 6585;
			Resistance[0] = 17;
			Bonding = 2;
			SellPrice = 558;
			AvailableClasses = 0x7FFF;
			Model = 23053;
			ObjectClass = 4;
			SubClass = 1;
			Level = 20;
			ReqLevel = 15;
			Name = "Scouting Cloak";
			Name2 = "Scouting Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 982;
			BuyPrice = 2792;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Battleforge Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class BattleforgeCloak : Item
	{
		public BattleforgeCloak() : base()
		{
			Id = 6593;
			Resistance[0] = 20;
			Bonding = 2;
			SellPrice = 922;
			AvailableClasses = 0x7FFF;
			Model = 25993;
			ObjectClass = 4;
			SubClass = 1;
			Level = 26;
			ReqLevel = 21;
			Name = "Battleforge Cloak";
			Name2 = "Battleforge Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1005;
			BuyPrice = 4614;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Dervish Cape)
*
***************************************************************/

namespace Server.Items
{
	public class DervishCape : Item
	{
		public DervishCape() : base()
		{
			Id = 6604;
			Resistance[0] = 20;
			Bonding = 2;
			SellPrice = 1200;
			AvailableClasses = 0x7FFF;
			Model = 23022;
			ObjectClass = 4;
			SubClass = 1;
			Level = 26;
			ReqLevel = 21;
			Name = "Dervish Cape";
			Name2 = "Dervish Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 984;
			BuyPrice = 6000;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Sage's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class SagesCloak : Item
	{
		public SagesCloak() : base()
		{
			Id = 6614;
			Resistance[0] = 21;
			Bonding = 2;
			SellPrice = 1120;
			AvailableClasses = 0x7FFF;
			Model = 23138;
			ObjectClass = 4;
			SubClass = 1;
			Level = 28;
			ReqLevel = 23;
			Name = "Sage's Cloak";
			Name2 = "Sage's Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 964;
			BuyPrice = 5603;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Sporid Cape)
*
***************************************************************/

namespace Server.Items
{
	public class SporidCape : Item
	{
		public SporidCape() : base()
		{
			Id = 6629;
			Resistance[0] = 18;
			Bonding = 1;
			SellPrice = 630;
			AvailableClasses = 0x7FFF;
			Model = 23141;
			ObjectClass = 4;
			SubClass = 1;
			Level = 23;
			ReqLevel = 18;
			Name = "Sporid Cape";
			Name2 = "Sporid Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3150;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 3;
			IqBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Feyscale Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class FeyscaleCloak : Item
	{
		public FeyscaleCloak() : base()
		{
			Id = 6632;
			Resistance[0] = 17;
			Bonding = 1;
			SellPrice = 642;
			AvailableClasses = 0x7FFF;
			Model = 15156;
			ObjectClass = 4;
			SubClass = 1;
			Level = 20;
			ReqLevel = 15;
			Name = "Feyscale Cloak";
			Name2 = "Feyscale Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3211;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 3;
			IqBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Engineer's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class EngineersCloak : Item
	{
		public EngineersCloak() : base()
		{
			Id = 6667;
			Resistance[0] = 20;
			Bonding = 1;
			SellPrice = 992;
			AvailableClasses = 0x7FFF;
			Model = 23110;
			ObjectClass = 4;
			SubClass = 1;
			Level = 27;
			Name = "Engineer's Cloak";
			Name2 = "Engineer's Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4962;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 5;
			SpiritBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Swiftrunner Cape)
*
***************************************************************/

namespace Server.Items
{
	public class SwiftrunnerCape : Item
	{
		public SwiftrunnerCape() : base()
		{
			Id = 6745;
			Resistance[0] = 23;
			Bonding = 1;
			SellPrice = 2239;
			AvailableClasses = 0x7FFF;
			Model = 23069;
			ObjectClass = 4;
			SubClass = 1;
			Level = 33;
			Name = "Swiftrunner Cape";
			Name2 = "Swiftrunner Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11197;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 2;
			AgilityBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Mourning Shawl)
*
***************************************************************/

namespace Server.Items
{
	public class MourningShawl : Item
	{
		public MourningShawl() : base()
		{
			Id = 6751;
			Resistance[0] = 21;
			Bonding = 1;
			SellPrice = 1411;
			AvailableClasses = 0x7FFF;
			Model = 23126;
			ObjectClass = 4;
			SubClass = 1;
			Level = 30;
			Name = "Mourning Shawl";
			Name2 = "Mourning Shawl";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7057;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			IqBonus = -3;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Ceremonial Centaur Blanket)
*
***************************************************************/

namespace Server.Items
{
	public class CeremonialCentaurBlanket : Item
	{
		public CeremonialCentaurBlanket() : base()
		{
			Id = 6789;
			Resistance[0] = 28;
			Bonding = 1;
			SellPrice = 4012;
			AvailableClasses = 0x7FFF;
			Model = 23096;
			ObjectClass = 4;
			SubClass = 1;
			Level = 42;
			Name = "Ceremonial Centaur Blanket";
			Name2 = "Ceremonial Centaur Blanket";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 20060;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			SpiritBonus = 2;
			IqBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Cloak of Blight)
*
***************************************************************/

namespace Server.Items
{
	public class CloakOfBlight : Item
	{
		public CloakOfBlight() : base()
		{
			Id = 6832;
			Resistance[0] = 28;
			Bonding = 1;
			SellPrice = 3769;
			AvailableClasses = 0x7FFF;
			Model = 23097;
			ObjectClass = 4;
			SubClass = 1;
			Level = 42;
			Name = "Cloak of Blight";
			Name2 = "Cloak of Blight";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 18849;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			IqBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Glowing Thresher Cape)
*
***************************************************************/

namespace Server.Items
{
	public class GlowingThresherCape : Item
	{
		public GlowingThresherCape() : base()
		{
			Id = 6901;
			Resistance[0] = 23;
			Bonding = 1;
			SellPrice = 1523;
			AvailableClasses = 0x7FFF;
			Model = 23002;
			ObjectClass = 4;
			SubClass = 1;
			Level = 29;
			ReqLevel = 24;
			Name = "Glowing Thresher Cape";
			Name2 = "Glowing Thresher Cape";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 7615;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			IqBonus = 8;
			StrBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Prelacy Cape)
*
***************************************************************/

namespace Server.Items
{
	public class PrelacyCape : Item
	{
		public PrelacyCape() : base()
		{
			Id = 7004;
			Resistance[0] = 20;
			Bonding = 1;
			SellPrice = 984;
			AvailableClasses = 0x7FFF;
			Model = 15042;
			ObjectClass = 4;
			SubClass = 1;
			Level = 27;
			Name = "Prelacy Cape";
			Name2 = "Prelacy Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4924;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Azure Silk Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class AzureSilkCloak : Item
	{
		public AzureSilkCloak() : base()
		{
			Id = 7053;
			Resistance[0] = 23;
			Bonding = 2;
			SellPrice = 2240;
			AvailableClasses = 0x7FFF;
			Model = 23092;
			ObjectClass = 4;
			SubClass = 1;
			Level = 35;
			ReqLevel = 30;
			Name = "Azure Silk Cloak";
			Name2 = "Azure Silk Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11201;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			SetSpell( 7703 , 1 , 0 , -1 , 0 , -1 );
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Crimson Silk Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class CrimsonSilkCloak : Item
	{
		public CrimsonSilkCloak() : base()
		{
			Id = 7056;
			Resistance[0] = 24;
			Bonding = 2;
			SellPrice = 2314;
			AvailableClasses = 0x7FFF;
			Model = 15243;
			Resistance[2] = 7;
			ObjectClass = 4;
			SubClass = 1;
			Level = 36;
			ReqLevel = 31;
			Name = "Crimson Silk Cloak";
			Name2 = "Crimson Silk Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11574;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Handstitched Leather Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class HandstitchedLeatherCloak : Item
	{
		public HandstitchedLeatherCloak() : base()
		{
			Id = 7276;
			Resistance[0] = 8;
			SellPrice = 34;
			AvailableClasses = 0x7FFF;
			Model = 23035;
			ObjectClass = 4;
			SubClass = 1;
			Level = 9;
			ReqLevel = 4;
			Name = "Handstitched Leather Cloak";
			Name2 = "Handstitched Leather Cloak";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 170;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Black Whelp Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class BlackWhelpCloak : Item
	{
		public BlackWhelpCloak() : base()
		{
			Id = 7283;
			Resistance[0] = 17;
			Bonding = 2;
			SellPrice = 519;
			AvailableClasses = 0x7FFF;
			Model = 23010;
			ObjectClass = 4;
			SubClass = 1;
			Level = 20;
			ReqLevel = 15;
			Name = "Black Whelp Cloak";
			Name2 = "Black Whelp Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2595;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Elder's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class EldersCloak : Item
	{
		public EldersCloak() : base()
		{
			Id = 7356;
			Resistance[0] = 21;
			Bonding = 2;
			SellPrice = 1411;
			AvailableClasses = 0x7FFF;
			Model = 23100;
			ObjectClass = 4;
			SubClass = 1;
			Level = 30;
			ReqLevel = 25;
			Name = "Elder's Cloak";
			Name2 = "Elder's Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 964;
			BuyPrice = 7056;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Frost Leather Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class FrostLeatherCloak : Item
	{
		public FrostLeatherCloak() : base()
		{
			Id = 7377;
			Resistance[0] = 24;
			Bonding = 2;
			SellPrice = 2269;
			AvailableClasses = 0x7FFF;
			Model = 23030;
			ObjectClass = 4;
			SubClass = 1;
			Level = 36;
			ReqLevel = 31;
			Name = "Frost Leather Cloak";
			Name2 = "Frost Leather Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11347;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			SetSpell( 9402 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Infiltrator Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class InfiltratorCloak : Item
	{
		public InfiltratorCloak() : base()
		{
			Id = 7411;
			Resistance[0] = 22;
			Bonding = 2;
			SellPrice = 1769;
			AvailableClasses = 0x7FFF;
			Model = 23043;
			ObjectClass = 4;
			SubClass = 1;
			Level = 31;
			ReqLevel = 26;
			Name = "Infiltrator Cloak";
			Name2 = "Infiltrator Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 986;
			BuyPrice = 8846;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Phalanx Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class PhalanxCloak : Item
	{
		public PhalanxCloak() : base()
		{
			Id = 7419;
			Resistance[0] = 21;
			Bonding = 2;
			SellPrice = 1326;
			AvailableClasses = 0x7FFF;
			Model = 26043;
			ObjectClass = 4;
			SubClass = 1;
			Level = 30;
			ReqLevel = 25;
			Name = "Phalanx Cloak";
			Name2 = "Phalanx Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1006;
			BuyPrice = 6631;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Twilight Cape)
*
***************************************************************/

namespace Server.Items
{
	public class TwilightCape : Item
	{
		public TwilightCape() : base()
		{
			Id = 7436;
			Resistance[0] = 23;
			Bonding = 2;
			SellPrice = 2111;
			AvailableClasses = 0x7FFF;
			Model = 15175;
			ObjectClass = 4;
			SubClass = 1;
			Level = 35;
			ReqLevel = 30;
			Name = "Twilight Cape";
			Name2 = "Twilight Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 966;
			BuyPrice = 10558;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Sentinel Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class SentinelCloak : Item
	{
		public SentinelCloak() : base()
		{
			Id = 7446;
			Resistance[0] = 24;
			Bonding = 2;
			SellPrice = 3092;
			AvailableClasses = 0x7FFF;
			Model = 23062;
			ObjectClass = 4;
			SubClass = 1;
			Level = 36;
			ReqLevel = 31;
			Name = "Sentinel Cloak";
			Name2 = "Sentinel Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 987;
			BuyPrice = 15462;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Knight's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class KnightsCloak : Item
	{
		public KnightsCloak() : base()
		{
			Id = 7460;
			Resistance[0] = 23;
			Bonding = 2;
			SellPrice = 2000;
			AvailableClasses = 0x7FFF;
			Model = 26064;
			ObjectClass = 4;
			SubClass = 1;
			Level = 34;
			ReqLevel = 29;
			Name = "Knight's Cloak";
			Name2 = "Knight's Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1008;
			BuyPrice = 10004;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Regal Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class RegalCloak : Item
	{
		public RegalCloak() : base()
		{
			Id = 7474;
			Resistance[0] = 26;
			Bonding = 2;
			SellPrice = 3281;
			AvailableClasses = 0x7FFF;
			Model = 15178;
			ObjectClass = 4;
			SubClass = 1;
			Level = 40;
			ReqLevel = 35;
			Name = "Regal Cloak";
			Name2 = "Regal Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 968;
			BuyPrice = 16407;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Ranger Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class RangerCloak : Item
	{
		public RangerCloak() : base()
		{
			Id = 7483;
			Resistance[0] = 26;
			Bonding = 2;
			SellPrice = 4238;
			AvailableClasses = 0x7FFF;
			Model = 23057;
			ObjectClass = 4;
			SubClass = 1;
			Level = 40;
			ReqLevel = 35;
			Name = "Ranger Cloak";
			Name2 = "Ranger Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 989;
			BuyPrice = 21192;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Captain's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class CaptainsCloak : Item
	{
		public CaptainsCloak() : base()
		{
			Id = 7492;
			Resistance[0] = 26;
			Bonding = 2;
			SellPrice = 3015;
			AvailableClasses = 0x7FFF;
			Model = 26018;
			ObjectClass = 4;
			SubClass = 1;
			Level = 39;
			ReqLevel = 34;
			Name = "Captain's Cloak";
			Name2 = "Captain's Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1009;
			BuyPrice = 15077;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Gossamer Cape)
*
***************************************************************/

namespace Server.Items
{
	public class GossamerCape : Item
	{
		public GossamerCape() : base()
		{
			Id = 7524;
			Resistance[0] = 29;
			Bonding = 2;
			SellPrice = 4297;
			AvailableClasses = 0x7FFF;
			Model = 15406;
			ObjectClass = 4;
			SubClass = 1;
			Level = 44;
			ReqLevel = 39;
			Name = "Gossamer Cape";
			Name2 = "Gossamer Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 969;
			BuyPrice = 21486;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Cabalist Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class CabalistCloak : Item
	{
		public CabalistCloak() : base()
		{
			Id = 7533;
			Resistance[0] = 29;
			Bonding = 2;
			SellPrice = 5557;
			AvailableClasses = 0x7FFF;
			Model = 23016;
			ObjectClass = 4;
			SubClass = 1;
			Level = 44;
			ReqLevel = 39;
			Name = "Cabalist Cloak";
			Name2 = "Cabalist Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 990;
			BuyPrice = 27789;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Champion's Cape)
*
***************************************************************/

namespace Server.Items
{
	public class ChampionsCape : Item
	{
		public ChampionsCape() : base()
		{
			Id = 7544;
			Resistance[0] = 29;
			Bonding = 2;
			SellPrice = 4296;
			AvailableClasses = 0x7FFF;
			Model = 26097;
			ObjectClass = 4;
			SubClass = 1;
			Level = 44;
			ReqLevel = 39;
			Name = "Champion's Cape";
			Name2 = "Champion's Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1011;
			BuyPrice = 21484;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Timberland Cape)
*
***************************************************************/

namespace Server.Items
{
	public class TimberlandCape : Item
	{
		public TimberlandCape() : base()
		{
			Id = 7739;
			Resistance[0] = 16;
			Bonding = 1;
			SellPrice = 480;
			AvailableClasses = 0x7FFF;
			Model = 15866;
			ObjectClass = 4;
			SubClass = 1;
			Level = 18;
			Name = "Timberland Cape";
			Name2 = "Timberland Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2401;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Hibernal Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class HibernalCloak : Item
	{
		public HibernalCloak() : base()
		{
			Id = 8109;
			Resistance[0] = 30;
			Bonding = 2;
			SellPrice = 5011;
			AvailableClasses = 0x7FFF;
			Model = 23107;
			ObjectClass = 4;
			SubClass = 1;
			Level = 46;
			ReqLevel = 41;
			Name = "Hibernal Cloak";
			Name2 = "Hibernal Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 25059;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 4;
			IqBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Heraldic Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class HeraldicCloak : Item
	{
		public HeraldicCloak() : base()
		{
			Id = 8120;
			Resistance[0] = 30;
			Bonding = 2;
			SellPrice = 6207;
			AvailableClasses = 0x7FFF;
			Model = 23038;
			ObjectClass = 4;
			SubClass = 1;
			Level = 45;
			ReqLevel = 40;
			Name = "Heraldic Cloak";
			Name2 = "Heraldic Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 31036;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 9;
			AgilityBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Myrmidon's Cape)
*
***************************************************************/

namespace Server.Items
{
	public class MyrmidonsCape : Item
	{
		public MyrmidonsCape() : base()
		{
			Id = 8127;
			Resistance[0] = 31;
			Bonding = 2;
			SellPrice = 5937;
			AvailableClasses = 0x7FFF;
			Model = 26118;
			ObjectClass = 4;
			SubClass = 1;
			Level = 47;
			ReqLevel = 42;
			Name = "Myrmidon's Cape";
			Name2 = "Myrmidon's Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 29689;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 10;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Wild Leather Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class WildLeatherCloak : Item
	{
		public WildLeatherCloak() : base()
		{
			Id = 8215;
			Resistance[0] = 33;
			Bonding = 2;
			SellPrice = 9017;
			AvailableClasses = 0x7FFF;
			Model = 23081;
			ObjectClass = 4;
			SubClass = 1;
			Level = 50;
			ReqLevel = 45;
			Name = "Wild Leather Cloak";
			Name2 = "Wild Leather Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 992;
			BuyPrice = 45086;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Big Voodoo Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class BigVoodooCloak : Item
	{
		public BigVoodooCloak() : base()
		{
			Id = 8216;
			Resistance[0] = 31;
			Bonding = 2;
			SellPrice = 6323;
			AvailableClasses = 0x7FFF;
			Model = 24297;
			ObjectClass = 4;
			SubClass = 1;
			Level = 48;
			ReqLevel = 43;
			Name = "Big Voodoo Cloak";
			Name2 = "Big Voodoo Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 31617;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			SpiritBonus = 9;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Imperial Red Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class ImperialRedCloak : Item
	{
		public ImperialRedCloak() : base()
		{
			Id = 8248;
			Resistance[0] = 33;
			Bonding = 2;
			SellPrice = 7032;
			AvailableClasses = 0x7FFF;
			Model = 17238;
			ObjectClass = 4;
			SubClass = 1;
			Level = 50;
			ReqLevel = 45;
			Name = "Imperial Red Cloak";
			Name2 = "Imperial Red Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 35161;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			IqBonus = 4;
			SpiritBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Serpentskin Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class SerpentskinCloak : Item
	{
		public SerpentskinCloak() : base()
		{
			Id = 8259;
			Resistance[0] = 33;
			Bonding = 2;
			SellPrice = 9144;
			AvailableClasses = 0x7FFF;
			Model = 23063;
			ObjectClass = 4;
			SubClass = 1;
			Level = 50;
			ReqLevel = 45;
			Name = "Serpentskin Cloak";
			Name2 = "Serpentskin Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 45721;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 2;
			AgilityBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Ebonhold Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class EbonholdCloak : Item
	{
		public EbonholdCloak() : base()
		{
			Id = 8266;
			Resistance[0] = 33;
			Bonding = 2;
			SellPrice = 7468;
			AvailableClasses = 0x7FFF;
			Model = 26228;
			ObjectClass = 4;
			SubClass = 1;
			Level = 51;
			ReqLevel = 46;
			Name = "Ebonhold Cloak";
			Name2 = "Ebonhold Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 37341;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 4;
			AgilityBonus = 7;
			IqBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Arcane Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class ArcaneCloak : Item
	{
		public ArcaneCloak() : base()
		{
			Id = 8286;
			Resistance[0] = 36;
			Bonding = 2;
			SellPrice = 9427;
			AvailableClasses = 0x7FFF;
			Model = 13984;
			ObjectClass = 4;
			SubClass = 1;
			Level = 55;
			ReqLevel = 50;
			Name = "Arcane Cloak";
			Name2 = "Arcane Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 47137;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 3;
			IqBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Traveler's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class TravelersCloak : Item
	{
		public TravelersCloak() : base()
		{
			Id = 8297;
			Resistance[0] = 36;
			Bonding = 2;
			SellPrice = 9113;
			AvailableClasses = 0x7FFF;
			Model = 23066;
			ObjectClass = 4;
			SubClass = 1;
			Level = 55;
			ReqLevel = 50;
			Name = "Traveler's Cloak";
			Name2 = "Traveler's Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 45565;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 4;
			IqBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Hero's Cape)
*
***************************************************************/

namespace Server.Items
{
	public class HerosCape : Item
	{
		public HerosCape() : base()
		{
			Id = 8304;
			Resistance[0] = 37;
			Bonding = 2;
			SellPrice = 10513;
			AvailableClasses = 0x7FFF;
			Model = 26323;
			ObjectClass = 4;
			SubClass = 1;
			Level = 57;
			ReqLevel = 52;
			Name = "Hero's Cape";
			Name2 = "Hero's Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 52565;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 11;
			SpiritBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Energy Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class EnergyCloak : Item
	{
		public EnergyCloak() : base()
		{
			Id = 9397;
			Resistance[0] = 28;
			Bonding = 2;
			SellPrice = 3672;
			AvailableClasses = 0x7FFF;
			Model = 22996;
			ObjectClass = 4;
			SubClass = 1;
			Level = 39;
			ReqLevel = 34;
			Name = "Energy Cloak";
			Name2 = "Energy Cloak";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 18364;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			SetSpell( 5405 , 0 , 0 , 3600000 , 30 , 180000 );
			IqBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Blackmetal Cape)
*
***************************************************************/

namespace Server.Items
{
	public class BlackmetalCape : Item
	{
		public BlackmetalCape() : base()
		{
			Id = 9512;
			Resistance[0] = 33;
			Bonding = 2;
			SellPrice = 6341;
			AvailableClasses = 0x7FFF;
			Model = 22988;
			ObjectClass = 4;
			SubClass = 1;
			Level = 46;
			ReqLevel = 41;
			Name = "Blackmetal Cape";
			Name2 = "Blackmetal Cape";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 31705;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			AgilityBonus = 12;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Repairman's Cape)
*
***************************************************************/

namespace Server.Items
{
	public class RepairmansCape : Item
	{
		public RepairmansCape() : base()
		{
			Id = 9605;
			Resistance[0] = 21;
			Bonding = 1;
			SellPrice = 1356;
			AvailableClasses = 0x7FFF;
			Model = 23134;
			ObjectClass = 4;
			SubClass = 1;
			Level = 30;
			Name = "Repairman's Cape";
			Name2 = "Repairman's Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6783;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			SpiritBonus = 1;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Master Apothecary Cape)
*
***************************************************************/

namespace Server.Items
{
	public class MasterApothecaryCape : Item
	{
		public MasterApothecaryCape() : base()
		{
			Id = 9635;
			Resistance[0] = 30;
			Bonding = 1;
			SellPrice = 4713;
			AvailableClasses = 0x7FFF;
			Model = 18915;
			ObjectClass = 4;
			SubClass = 1;
			Level = 45;
			Name = "Master Apothecary Cape";
			Name2 = "Master Apothecary Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 23567;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			SpiritBonus = 1;
			IqBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Chainlink Towel)
*
***************************************************************/

namespace Server.Items
{
	public class ChainlinkTowel : Item
	{
		public ChainlinkTowel() : base()
		{
			Id = 9648;
			Resistance[0] = 31;
			Bonding = 1;
			SellPrice = 6392;
			AvailableClasses = 0x7FFF;
			Description = "Now even less absorbant!";
			Model = 28097;
			ObjectClass = 4;
			SubClass = 1;
			Level = 48;
			Name = "Chainlink Towel";
			Name2 = "Chainlink Towel";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 31963;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			SpiritBonus = 3;
			IqBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Stargazer Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class StargazerCloak : Item
	{
		public StargazerCloak() : base()
		{
			Id = 9660;
			Resistance[0] = 28;
			Bonding = 1;
			SellPrice = 4227;
			AvailableClasses = 0x7FFF;
			Model = 28299;
			ObjectClass = 4;
			SubClass = 1;
			Level = 43;
			Name = "Stargazer Cloak";
			Name2 = "Stargazer Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 21139;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			IqBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Garrison Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class GarrisonCloak : Item
	{
		public GarrisonCloak() : base()
		{
			Id = 9699;
			Resistance[0] = 23;
			Bonding = 1;
			SellPrice = 1812;
			AvailableClasses = 0x7FFF;
			Model = 28326;
			ObjectClass = 4;
			SubClass = 1;
			Level = 33;
			Name = "Garrison Cloak";
			Name2 = "Garrison Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 9062;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 6;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Scorched Cape)
*
***************************************************************/

namespace Server.Items
{
	public class ScorchedCape : Item
	{
		public ScorchedCape() : base()
		{
			Id = 9703;
			Resistance[0] = 28;
			Bonding = 1;
			SellPrice = 4272;
			AvailableClasses = 0x7FFF;
			Model = 28297;
			ObjectClass = 4;
			SubClass = 1;
			Level = 43;
			Name = "Scorched Cape";
			Name2 = "Scorched Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 21362;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 2;
			IqBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Simple Cape)
*
***************************************************************/

namespace Server.Items
{
	public class SimpleCape : Item
	{
		public SimpleCape() : base()
		{
			Id = 9745;
			Resistance[0] = 10;
			SellPrice = 54;
			AvailableClasses = 0x7FFF;
			Model = 27533;
			ObjectClass = 4;
			SubClass = 1;
			Level = 11;
			ReqLevel = 6;
			Name = "Simple Cape";
			Name2 = "Simple Cape";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 270;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Gypsy Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class GypsyCloak : Item
	{
		public GypsyCloak() : base()
		{
			Id = 9754;
			Resistance[0] = 10;
			SellPrice = 70;
			AvailableClasses = 0x7FFF;
			Model = 23034;
			ObjectClass = 4;
			SubClass = 1;
			Level = 11;
			ReqLevel = 6;
			Name = "Gypsy Cloak";
			Name2 = "Gypsy Cloak";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 350;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Cadet Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class CadetCloak : Item
	{
		public CadetCloak() : base()
		{
			Id = 9761;
			Resistance[0] = 10;
			SellPrice = 58;
			AvailableClasses = 0x7FFF;
			Model = 25960;
			ObjectClass = 4;
			SubClass = 1;
			Level = 11;
			ReqLevel = 6;
			Name = "Cadet Cloak";
			Name2 = "Cadet Cloak";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 294;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Greenweave Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class GreenweaveCloak : Item
	{
		public GreenweaveCloak() : base()
		{
			Id = 9770;
			Resistance[0] = 17;
			Bonding = 2;
			SellPrice = 416;
			AvailableClasses = 0x7FFF;
			Model = 23106;
			ObjectClass = 4;
			SubClass = 1;
			Level = 20;
			ReqLevel = 15;
			Name = "Greenweave Cloak";
			Name2 = "Greenweave Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 961;
			BuyPrice = 2084;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Bandit Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class BanditCloak : Item
	{
		public BanditCloak() : base()
		{
			Id = 9779;
			Resistance[0] = 16;
			Bonding = 2;
			SellPrice = 334;
			AvailableClasses = 0x7FFF;
			Model = 28433;
			ObjectClass = 4;
			SubClass = 1;
			Level = 18;
			ReqLevel = 13;
			Name = "Bandit Cloak";
			Name2 = "Bandit Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 981;
			BuyPrice = 1671;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Raider's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class RaidersCloak : Item
	{
		public RaidersCloak() : base()
		{
			Id = 9786;
			Resistance[0] = 15;
			Bonding = 2;
			SellPrice = 234;
			AvailableClasses = 0x7FFF;
			Model = 25978;
			ObjectClass = 4;
			SubClass = 1;
			Level = 16;
			ReqLevel = 11;
			Name = "Raider's Cloak";
			Name2 = "Raider's Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1002;
			BuyPrice = 1173;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Ivycloth Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class IvyclothCloak : Item
	{
		public IvyclothCloak() : base()
		{
			Id = 9794;
			Resistance[0] = 19;
			Bonding = 2;
			SellPrice = 829;
			AvailableClasses = 0x7FFF;
			Model = 27752;
			ObjectClass = 4;
			SubClass = 1;
			Level = 25;
			ReqLevel = 20;
			Name = "Ivycloth Cloak";
			Name2 = "Ivycloth Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 963;
			BuyPrice = 4145;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Superior Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class SuperiorCloak : Item
	{
		public SuperiorCloak() : base()
		{
			Id = 9805;
			Resistance[0] = 19;
			Bonding = 2;
			SellPrice = 709;
			AvailableClasses = 0x7FFF;
			Model = 23108;
			ObjectClass = 4;
			SubClass = 1;
			Level = 24;
			ReqLevel = 19;
			Name = "Superior Cloak";
			Name2 = "Superior Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 983;
			BuyPrice = 3549;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Fortified Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class FortifiedCloak : Item
	{
		public FortifiedCloak() : base()
		{
			Id = 9812;
			Resistance[0] = 18;
			Bonding = 2;
			SellPrice = 570;
			AvailableClasses = 0x7FFF;
			Model = 25975;
			ObjectClass = 4;
			SubClass = 1;
			Level = 22;
			ReqLevel = 17;
			Name = "Fortified Cloak";
			Name2 = "Fortified Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1004;
			BuyPrice = 2851;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Durable Cape)
*
***************************************************************/

namespace Server.Items
{
	public class DurableCape : Item
	{
		public DurableCape() : base()
		{
			Id = 9822;
			Resistance[0] = 21;
			Bonding = 2;
			SellPrice = 1192;
			AvailableClasses = 0x7FFF;
			Model = 27858;
			ObjectClass = 4;
			SubClass = 1;
			Level = 29;
			ReqLevel = 24;
			Name = "Durable Cape";
			Name2 = "Durable Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 964;
			BuyPrice = 5963;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Scaled Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class ScaledCloak : Item
	{
		public ScaledCloak() : base()
		{
			Id = 9831;
			Resistance[0] = 21;
			Bonding = 2;
			SellPrice = 1233;
			AvailableClasses = 0x7FFF;
			Model = 27768;
			ObjectClass = 4;
			SubClass = 1;
			Level = 29;
			ReqLevel = 24;
			Name = "Scaled Cloak";
			Name2 = "Scaled Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 985;
			BuyPrice = 6166;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Banded Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class BandedCloak : Item
	{
		public BandedCloak() : base()
		{
			Id = 9838;
			Resistance[0] = 21;
			Bonding = 2;
			SellPrice = 1174;
			AvailableClasses = 0x7FFF;
			Model = 27779;
			ObjectClass = 4;
			SubClass = 1;
			Level = 29;
			ReqLevel = 24;
			Name = "Banded Cloak";
			Name2 = "Banded Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1006;
			BuyPrice = 5872;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Conjurer's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class ConjurersCloak : Item
	{
		public ConjurersCloak() : base()
		{
			Id = 9847;
			Resistance[0] = 23;
			Bonding = 2;
			SellPrice = 1779;
			AvailableClasses = 0x7FFF;
			Model = 15236;
			ObjectClass = 4;
			SubClass = 1;
			Level = 33;
			ReqLevel = 28;
			Name = "Conjurer's Cloak";
			Name2 = "Conjurer's Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 965;
			BuyPrice = 8895;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Archer's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class ArchersCloak : Item
	{
		public ArchersCloak() : base()
		{
			Id = 9860;
			Resistance[0] = 23;
			Bonding = 2;
			SellPrice = 2382;
			AvailableClasses = 0x7FFF;
			Model = 23004;
			ObjectClass = 4;
			SubClass = 1;
			Level = 34;
			ReqLevel = 29;
			Name = "Archer's Cloak";
			Name2 = "Archer's Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 987;
			BuyPrice = 11912;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Renegade Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class RenegadeCloak : Item
	{
		public RenegadeCloak() : base()
		{
			Id = 9867;
			Resistance[0] = 23;
			Bonding = 2;
			SellPrice = 1778;
			AvailableClasses = 0x7FFF;
			Model = 26251;
			ObjectClass = 4;
			SubClass = 1;
			Level = 33;
			ReqLevel = 28;
			Name = "Renegade Cloak";
			Name2 = "Renegade Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1007;
			BuyPrice = 8894;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Sorcerer Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class SorcererCloak : Item
	{
		public SorcererCloak() : base()
		{
			Id = 9877;
			Resistance[0] = 25;
			Bonding = 2;
			SellPrice = 2708;
			AvailableClasses = 0x7FFF;
			Model = 28065;
			ObjectClass = 4;
			SubClass = 1;
			Level = 38;
			ReqLevel = 33;
			Name = "Sorcerer Cloak";
			Name2 = "Sorcerer Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 967;
			BuyPrice = 13541;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Huntsman's Cape)
*
***************************************************************/

namespace Server.Items
{
	public class HuntsmansCape : Item
	{
		public HuntsmansCape() : base()
		{
			Id = 9890;
			Resistance[0] = 25;
			Bonding = 2;
			SellPrice = 2919;
			AvailableClasses = 0x7FFF;
			Model = 23023;
			ObjectClass = 4;
			SubClass = 1;
			Level = 38;
			ReqLevel = 33;
			Name = "Huntsman's Cape";
			Name2 = "Huntsman's Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 988;
			BuyPrice = 14595;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Jazeraint Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class JazeraintCloak : Item
	{
		public JazeraintCloak() : base()
		{
			Id = 9898;
			Resistance[0] = 25;
			Bonding = 2;
			SellPrice = 2718;
			AvailableClasses = 0x7FFF;
			Model = 27794;
			ObjectClass = 4;
			SubClass = 1;
			Level = 38;
			ReqLevel = 33;
			Name = "Jazeraint Cloak";
			Name2 = "Jazeraint Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1009;
			BuyPrice = 13591;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Royal Cape)
*
***************************************************************/

namespace Server.Items
{
	public class RoyalCape : Item
	{
		public RoyalCape() : base()
		{
			Id = 9908;
			Resistance[0] = 28;
			Bonding = 2;
			SellPrice = 4257;
			AvailableClasses = 0x7FFF;
			Model = 28412;
			ObjectClass = 4;
			SubClass = 1;
			Level = 43;
			ReqLevel = 38;
			Name = "Royal Cape";
			Name2 = "Royal Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 969;
			BuyPrice = 21289;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Tracker's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class TrackersCloak : Item
	{
		public TrackersCloak() : base()
		{
			Id = 9919;
			Resistance[0] = 28;
			Bonding = 2;
			SellPrice = 5149;
			AvailableClasses = 0x7FFF;
			Model = 23073;
			ObjectClass = 4;
			SubClass = 1;
			Level = 43;
			ReqLevel = 38;
			Name = "Tracker's Cloak";
			Name2 = "Tracker's Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 990;
			BuyPrice = 25746;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Brigade Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class BrigadeCloak : Item
	{
		public BrigadeCloak() : base()
		{
			Id = 9929;
			Resistance[0] = 27;
			Bonding = 2;
			SellPrice = 3662;
			AvailableClasses = 0x7FFF;
			Model = 25938;
			ObjectClass = 4;
			SubClass = 1;
			Level = 41;
			ReqLevel = 36;
			Name = "Brigade Cloak";
			Name2 = "Brigade Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1010;
			BuyPrice = 18314;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Abjurer's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class AbjurersCloak : Item
	{
		public AbjurersCloak() : base()
		{
			Id = 9938;
			Resistance[0] = 31;
			Bonding = 2;
			SellPrice = 6029;
			AvailableClasses = 0x7FFF;
			Model = 15040;
			ObjectClass = 4;
			SubClass = 1;
			Level = 48;
			ReqLevel = 43;
			Name = "Abjurer's Cloak";
			Name2 = "Abjurer's Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 970;
			BuyPrice = 30147;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Chieftain's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class ChieftainsCloak : Item
	{
		public ChieftainsCloak() : base()
		{
			Id = 9951;
			Resistance[0] = 31;
			Bonding = 2;
			SellPrice = 6795;
			AvailableClasses = 0x7FFF;
			Model = 23018;
			ObjectClass = 4;
			SubClass = 1;
			Level = 47;
			ReqLevel = 42;
			Name = "Chieftain's Cloak";
			Name2 = "Chieftain's Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 991;
			BuyPrice = 33976;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Warmonger's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class WarmongersCloak : Item
	{
		public WarmongersCloak() : base()
		{
			Id = 9959;
			Resistance[0] = 30;
			Bonding = 2;
			SellPrice = 4803;
			AvailableClasses = 0x7FFF;
			Model = 26202;
			ObjectClass = 4;
			SubClass = 1;
			Level = 45;
			ReqLevel = 40;
			Name = "Warmonger's Cloak";
			Name2 = "Warmonger's Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1011;
			BuyPrice = 24017;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Duskwoven Cape)
*
***************************************************************/

namespace Server.Items
{
	public class DuskwovenCape : Item
	{
		public DuskwovenCape() : base()
		{
			Id = 10060;
			Resistance[0] = 32;
			Bonding = 2;
			SellPrice = 6667;
			AvailableClasses = 0x7FFF;
			Model = 28125;
			ObjectClass = 4;
			SubClass = 1;
			Level = 49;
			ReqLevel = 44;
			Name = "Duskwoven Cape";
			Name2 = "Duskwoven Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 971;
			BuyPrice = 33339;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Righteous Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class RighteousCloak : Item
	{
		public RighteousCloak() : base()
		{
			Id = 10071;
			Resistance[0] = 32;
			Bonding = 2;
			SellPrice = 8063;
			AvailableClasses = 0x7FFF;
			Model = 23060;
			ObjectClass = 4;
			SubClass = 1;
			Level = 49;
			ReqLevel = 44;
			Name = "Righteous Cloak";
			Name2 = "Righteous Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 992;
			BuyPrice = 40315;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Lord's Cape)
*
***************************************************************/

namespace Server.Items
{
	public class LordsCape : Item
	{
		public LordsCape() : base()
		{
			Id = 10079;
			Resistance[0] = 31;
			Bonding = 2;
			SellPrice = 6370;
			AvailableClasses = 0x7FFF;
			Model = 26331;
			ObjectClass = 4;
			SubClass = 1;
			Level = 48;
			ReqLevel = 43;
			Name = "Lord's Cape";
			Name2 = "Lord's Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1012;
			BuyPrice = 31852;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Councillor's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class CouncillorsCloak : Item
	{
		public CouncillorsCloak() : base()
		{
			Id = 10098;
			Resistance[0] = 34;
			Bonding = 2;
			SellPrice = 8736;
			AvailableClasses = 0x7FFF;
			Model = 27607;
			ObjectClass = 4;
			SubClass = 1;
			Level = 53;
			ReqLevel = 48;
			Name = "Councillor's Cloak";
			Name2 = "Councillor's Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 972;
			BuyPrice = 43684;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Wanderer's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class WanderersCloak : Item
	{
		public WanderersCloak() : base()
		{
			Id = 10108;
			Resistance[0] = 34;
			Bonding = 2;
			SellPrice = 8203;
			AvailableClasses = 0x7FFF;
			Model = 27721;
			ObjectClass = 4;
			SubClass = 1;
			Level = 53;
			ReqLevel = 48;
			Name = "Wanderer's Cloak";
			Name2 = "Wanderer's Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 993;
			BuyPrice = 41016;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Ornate Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class OrnateCloak : Item
	{
		public OrnateCloak() : base()
		{
			Id = 10120;
			Resistance[0] = 34;
			Bonding = 2;
			SellPrice = 8797;
			AvailableClasses = 0x7FFF;
			Model = 26304;
			ObjectClass = 4;
			SubClass = 1;
			Level = 53;
			ReqLevel = 48;
			Name = "Ornate Cloak";
			Name2 = "Ornate Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1014;
			BuyPrice = 43987;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(High Councillor's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class HighCouncillorsCloak : Item
	{
		public HighCouncillorsCloak() : base()
		{
			Id = 10138;
			Resistance[0] = 38;
			Bonding = 2;
			SellPrice = 12274;
			AvailableClasses = 0x7FFF;
			Model = 27631;
			ObjectClass = 4;
			SubClass = 1;
			Level = 59;
			ReqLevel = 54;
			Name = "High Councillor's Cloak";
			Name2 = "High Councillor's Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 974;
			BuyPrice = 61371;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Mighty Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class MightyCloak : Item
	{
		public MightyCloak() : base()
		{
			Id = 10148;
			Resistance[0] = 38;
			Bonding = 2;
			SellPrice = 11273;
			AvailableClasses = 0x7FFF;
			Model = 27743;
			ObjectClass = 4;
			SubClass = 1;
			Level = 58;
			ReqLevel = 53;
			Name = "Mighty Cloak";
			Name2 = "Mighty Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 995;
			BuyPrice = 56367;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Mercurial Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class MercurialCloak : Item
	{
		public MercurialCloak() : base()
		{
			Id = 10159;
			Resistance[0] = 38;
			Bonding = 2;
			SellPrice = 11444;
			AvailableClasses = 0x7FFF;
			Model = 26141;
			ObjectClass = 4;
			SubClass = 1;
			Level = 59;
			ReqLevel = 54;
			Name = "Mercurial Cloak";
			Name2 = "Mercurial Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1016;
			BuyPrice = 57220;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Mystical Cape)
*
***************************************************************/

namespace Server.Items
{
	public class MysticalCape : Item
	{
		public MysticalCape() : base()
		{
			Id = 10174;
			Resistance[0] = 34;
			Bonding = 2;
			SellPrice = 8121;
			AvailableClasses = 0x7FFF;
			Model = 23136;
			ObjectClass = 4;
			SubClass = 1;
			Level = 52;
			ReqLevel = 47;
			Name = "Mystical Cape";
			Name2 = "Mystical Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 972;
			BuyPrice = 40607;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Swashbuckler's Cape)
*
***************************************************************/

namespace Server.Items
{
	public class SwashbucklersCape : Item
	{
		public SwashbucklersCape() : base()
		{
			Id = 10185;
			Resistance[0] = 33;
			Bonding = 2;
			SellPrice = 7412;
			AvailableClasses = 0x7FFF;
			Model = 23042;
			ObjectClass = 4;
			SubClass = 1;
			Level = 51;
			ReqLevel = 46;
			Name = "Swashbuckler's Cape";
			Name2 = "Swashbuckler's Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 992;
			BuyPrice = 37064;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Crusader's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class CrusadersCloak : Item
	{
		public CrusadersCloak() : base()
		{
			Id = 10194;
			Resistance[0] = 33;
			Bonding = 2;
			SellPrice = 7345;
			AvailableClasses = 0x7FFF;
			Model = 26173;
			ObjectClass = 4;
			SubClass = 1;
			Level = 50;
			ReqLevel = 45;
			Name = "Crusader's Cloak";
			Name2 = "Crusader's Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1013;
			BuyPrice = 36728;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Elegant Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class ElegantCloak : Item
	{
		public ElegantCloak() : base()
		{
			Id = 10212;
			Resistance[0] = 37;
			Bonding = 2;
			SellPrice = 11069;
			AvailableClasses = 0x7FFF;
			Model = 15214;
			ObjectClass = 4;
			SubClass = 1;
			Level = 57;
			ReqLevel = 52;
			Name = "Elegant Cloak";
			Name2 = "Elegant Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 973;
			BuyPrice = 55348;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Nightshade Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class NightshadeCloak : Item
	{
		public NightshadeCloak() : base()
		{
			Id = 10224;
			Resistance[0] = 37;
			Bonding = 2;
			SellPrice = 10755;
			AvailableClasses = 0x7FFF;
			Model = 23048;
			ObjectClass = 4;
			SubClass = 1;
			Level = 57;
			ReqLevel = 52;
			Name = "Nightshade Cloak";
			Name2 = "Nightshade Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 994;
			BuyPrice = 53778;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Engraved Cape)
*
***************************************************************/

namespace Server.Items
{
	public class EngravedCape : Item
	{
		public EngravedCape() : base()
		{
			Id = 10231;
			Resistance[0] = 36;
			Bonding = 2;
			SellPrice = 9815;
			AvailableClasses = 0x7FFF;
			Model = 26278;
			ObjectClass = 4;
			SubClass = 1;
			Level = 55;
			ReqLevel = 50;
			Name = "Engraved Cape";
			Name2 = "Engraved Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1015;
			BuyPrice = 49079;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Master's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class MastersCloak : Item
	{
		public MastersCloak() : base()
		{
			Id = 10249;
			Resistance[0] = 39;
			Bonding = 2;
			SellPrice = 13435;
			AvailableClasses = 0x7FFF;
			Model = 26126;
			ObjectClass = 4;
			SubClass = 1;
			Level = 61;
			ReqLevel = 56;
			Name = "Master's Cloak";
			Name2 = "Master's Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 975;
			BuyPrice = 67179;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Adventurer's Cape)
*
***************************************************************/

namespace Server.Items
{
	public class AdventurersCape : Item
	{
		public AdventurersCape() : base()
		{
			Id = 10258;
			Resistance[0] = 39;
			Bonding = 2;
			SellPrice = 12292;
			AvailableClasses = 0x7FFF;
			Model = 27850;
			ObjectClass = 4;
			SubClass = 1;
			Level = 60;
			ReqLevel = 55;
			Name = "Adventurer's Cape";
			Name2 = "Adventurer's Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 995;
			BuyPrice = 61461;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Masterwork Cape)
*
***************************************************************/

namespace Server.Items
{
	public class MasterworkCape : Item
	{
		public MasterworkCape() : base()
		{
			Id = 10267;
			Resistance[0] = 39;
			Bonding = 2;
			SellPrice = 13337;
			AvailableClasses = 0x7FFF;
			Model = 26259;
			ObjectClass = 4;
			SubClass = 1;
			Level = 61;
			ReqLevel = 56;
			Name = "Masterwork Cape";
			Name2 = "Masterwork Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1017;
			BuyPrice = 66689;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Parachute Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class ParachuteCloak : Item
	{
		public ParachuteCloak() : base()
		{
			Id = 10518;
			Resistance[0] = 30;
			Bonding = 2;
			SellPrice = 4696;
			AvailableClasses = 0x7FFF;
			Model = 23129;
			ObjectClass = 4;
			SubClass = 1;
			Level = 45;
			Name = "Parachute Cloak";
			Name2 = "Parachute Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 225;
			Skill = 202;
			BuyPrice = 23482;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			SetSpell( 12438 , 0 , 0 , 1800000 , 0 , -1 );
			AgilityBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Long Draping Cape)
*
***************************************************************/

namespace Server.Items
{
	public class LongDrapingCape : Item
	{
		public LongDrapingCape() : base()
		{
			Id = 10638;
			Resistance[0] = 14;
			Bonding = 1;
			SellPrice = 210;
			AvailableClasses = 0x7FFF;
			Model = 28209;
			ObjectClass = 4;
			SubClass = 1;
			Level = 15;
			Name = "Long Draping Cape";
			Name2 = "Long Draping Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1052;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Silky Spider Cape)
*
***************************************************************/

namespace Server.Items
{
	public class SilkySpiderCape : Item
	{
		public SilkySpiderCape() : base()
		{
			Id = 10776;
			Resistance[0] = 30;
			Bonding = 1;
			SellPrice = 4799;
			AvailableClasses = 0x7FFF;
			Model = 22994;
			ObjectClass = 4;
			SubClass = 1;
			Level = 42;
			ReqLevel = 35;
			Name = "Silky Spider Cape";
			Name2 = "Silky Spider Cape";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 23999;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 11;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Wingveil Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class WingveilCloak : Item
	{
		public WingveilCloak() : base()
		{
			Id = 10802;
			Resistance[0] = 34;
			Bonding = 1;
			SellPrice = 7831;
			AvailableClasses = 0x7FFF;
			Model = 18968;
			ObjectClass = 4;
			SubClass = 1;
			Level = 52;
			ReqLevel = 47;
			Name = "Wingveil Cloak";
			Name2 = "Wingveil Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 39156;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			IqBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Sower's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class SowersCloak : Item
	{
		public SowersCloak() : base()
		{
			Id = 10821;
			Resistance[0] = 14;
			Bonding = 1;
			SellPrice = 208;
			AvailableClasses = 0x7FFF;
			Model = 28298;
			ObjectClass = 4;
			SubClass = 1;
			Level = 15;
			Name = "Sower's Cloak";
			Name2 = "Sower's Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1040;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			IqBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Featherskin Cape)
*
***************************************************************/

namespace Server.Items
{
	public class FeatherskinCape : Item
	{
		public FeatherskinCape() : base()
		{
			Id = 10843;
			Resistance[0] = 39;
			Bonding = 1;
			SellPrice = 10595;
			AvailableClasses = 0x7FFF;
			Model = 22995;
			ObjectClass = 4;
			SubClass = 1;
			Level = 54;
			ReqLevel = 49;
			Name = "Featherskin Cape";
			Name2 = "Featherskin Cape";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 52977;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 4;
			IqBonus = 15;
			SpiritBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Emberscale Cape)
*
***************************************************************/

namespace Server.Items
{
	public class EmberscaleCape : Item
	{
		public EmberscaleCape() : base()
		{
			Id = 11311;
			Resistance[0] = 30;
			Bonding = 1;
			SellPrice = 5110;
			AvailableClasses = 0x7FFF;
			Model = 28731;
			ObjectClass = 4;
			SubClass = 1;
			Level = 46;
			ReqLevel = 41;
			Name = "Emberscale Cape";
			Name2 = "Emberscale Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 25553;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			IqBonus = 3;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Wine-stained Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class WineStainedCloak : Item
	{
		public WineStainedCloak() : base()
		{
			Id = 11475;
			Resistance[0] = 5;
			Bonding = 1;
			SellPrice = 7;
			AvailableClasses = 0x7FFF;
			Model = 28181;
			ObjectClass = 4;
			SubClass = 1;
			Level = 5;
			Name = "Wine-stained Cloak";
			Name2 = "Wine-stained Cloak";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 38;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Spritecaster Cape)
*
***************************************************************/

namespace Server.Items
{
	public class SpritecasterCape : Item
	{
		public SpritecasterCape() : base()
		{
			Id = 11623;
			Resistance[0] = 34;
			Bonding = 1;
			SellPrice = 8333;
			AvailableClasses = 0x7FFF;
			Model = 26137;
			ObjectClass = 4;
			SubClass = 1;
			Level = 52;
			ReqLevel = 47;
			Name = "Spritecaster Cape";
			Name2 = "Spritecaster Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 41665;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 2;
			SpiritBonus = 4;
			IqBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Blackveil Cape)
*
***************************************************************/

namespace Server.Items
{
	public class BlackveilCape : Item
	{
		public BlackveilCape() : base()
		{
			Id = 11626;
			Resistance[0] = 34;
			Bonding = 1;
			SellPrice = 8081;
			AvailableClasses = 0x7FFF;
			Model = 26278;
			ObjectClass = 4;
			SubClass = 1;
			Level = 53;
			ReqLevel = 48;
			Name = "Blackveil Cape";
			Name2 = "Blackveil Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 40409;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StrBonus = 5;
			AgilityBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Graverot Cape)
*
***************************************************************/

namespace Server.Items
{
	public class GraverotCape : Item
	{
		public GraverotCape() : base()
		{
			Id = 11677;
			Resistance[0] = 36;
			Bonding = 1;
			SellPrice = 9712;
			AvailableClasses = 0x7FFF;
			Model = 28381;
			ObjectClass = 4;
			SubClass = 1;
			Level = 55;
			ReqLevel = 50;
			Name = "Graverot Cape";
			Name2 = "Graverot Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 48563;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 11;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Cape of the Fire Salamander)
*
***************************************************************/

namespace Server.Items
{
	public class CapeOfTheFireSalamander : Item
	{
		public CapeOfTheFireSalamander() : base()
		{
			Id = 11812;
			Resistance[0] = 41;
			Bonding = 1;
			SellPrice = 13979;
			AvailableClasses = 0x7FFF;
			Model = 22997;
			Resistance[2] = 7;
			ObjectClass = 4;
			SubClass = 1;
			Level = 58;
			ReqLevel = 53;
			Name = "Cape of the Fire Salamander";
			Name2 = "Cape of the Fire Salamander";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 69895;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			IqBonus = 16;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Battered Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class BatteredCloak : Item
	{
		public BatteredCloak() : base()
		{
			Id = 11847;
			Resistance[0] = 5;
			Bonding = 1;
			SellPrice = 7;
			AvailableClasses = 0x7FFF;
			Model = 28071;
			ObjectClass = 4;
			SubClass = 1;
			Level = 5;
			Name = "Battered Cloak";
			Name2 = "Battered Cloak";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 38;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Short Duskbat Cape)
*
***************************************************************/

namespace Server.Items
{
	public class ShortDuskbatCape : Item
	{
		public ShortDuskbatCape() : base()
		{
			Id = 11850;
			Resistance[0] = 5;
			Bonding = 1;
			SellPrice = 7;
			AvailableClasses = 0x7FFF;
			Model = 23128;
			ObjectClass = 4;
			SubClass = 1;
			Level = 5;
			Name = "Short Duskbat Cape";
			Name2 = "Short Duskbat Cape";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 35;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Battlehard Cape)
*
***************************************************************/

namespace Server.Items
{
	public class BattlehardCape : Item
	{
		public BattlehardCape() : base()
		{
			Id = 11858;
			Resistance[0] = 30;
			Bonding = 1;
			SellPrice = 4768;
			AvailableClasses = 0x7FFF;
			Model = 28260;
			ObjectClass = 4;
			SubClass = 1;
			Level = 45;
			Name = "Battlehard Cape";
			Name2 = "Battlehard Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 23842;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			SetSpell( 9140 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Ethereal Mist Cape)
*
***************************************************************/

namespace Server.Items
{
	public class EtherealMistCape : Item
	{
		public EtherealMistCape() : base()
		{
			Id = 11873;
			Resistance[0] = 36;
			Bonding = 1;
			SellPrice = 9661;
			AvailableClasses = 0x7FFF;
			Model = 28325;
			ObjectClass = 4;
			SubClass = 1;
			Level = 56;
			Name = "Ethereal Mist Cape";
			Name2 = "Ethereal Mist Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 48309;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			SpiritBonus = 3;
			IqBonus = 12;
		}
	}
}


/**************************************************************
*
*				(The Emperor's New Cape)
*
***************************************************************/

namespace Server.Items
{
	public class TheEmperorsNewCape : Item
	{
		public TheEmperorsNewCape() : base()
		{
			Id = 11930;
			Resistance[0] = 43;
			Bonding = 1;
			SellPrice = 14588;
			AvailableClasses = 0x7FFF;
			Model = 21965;
			ObjectClass = 4;
			SubClass = 1;
			Level = 60;
			ReqLevel = 55;
			Name = "The Emperor's New Cape";
			Name2 = "The Emperor's New Cape";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 72941;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 16;
			AgilityBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Shaleskin Cape)
*
***************************************************************/

namespace Server.Items
{
	public class ShaleskinCape : Item
	{
		public ShaleskinCape() : base()
		{
			Id = 12066;
			Resistance[0] = 38;
			Bonding = 1;
			SellPrice = 11149;
			AvailableClasses = 0x7FFF;
			Model = 28251;
			ObjectClass = 4;
			SubClass = 1;
			Level = 58;
			Name = "Shaleskin Cape";
			Name2 = "Shaleskin Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 55747;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 11;
			AgilityBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Raincaster Drape)
*
***************************************************************/

namespace Server.Items
{
	public class RaincasterDrape : Item
	{
		public RaincasterDrape() : base()
		{
			Id = 12110;
			Resistance[0] = 38;
			Bonding = 1;
			SellPrice = 11610;
			AvailableClasses = 0x7FFF;
			Model = 28240;
			ObjectClass = 4;
			SubClass = 1;
			Level = 58;
			Name = "Raincaster Drape";
			Name2 = "Raincaster Drape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 58054;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			SetSpell( 9408 , 1 , 0 , -1 , 0 , -1 );
			IqBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Sunborne Cape)
*
***************************************************************/

namespace Server.Items
{
	public class SunborneCape : Item
	{
		public SunborneCape() : base()
		{
			Id = 12113;
			Resistance[0] = 36;
			Bonding = 1;
			SellPrice = 10443;
			AvailableClasses = 0x7FFF;
			Model = 28210;
			ObjectClass = 4;
			SubClass = 1;
			Level = 56;
			Name = "Sunborne Cape";
			Name2 = "Sunborne Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 52219;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			SetSpell( 9295 , 1 , 0 , -1 , 0 , -1 );
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Brilliant Red Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class BrilliantRedCloak : Item
	{
		public BrilliantRedCloak() : base()
		{
			Id = 12253;
			Resistance[0] = 27;
			Bonding = 2;
			SellPrice = 3545;
			AvailableClasses = 0x7FFF;
			Model = 28690;
			ObjectClass = 4;
			SubClass = 1;
			Level = 41;
			ReqLevel = 36;
			Name = "Brilliant Red Cloak";
			Name2 = "Brilliant Red Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 17728;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Well Oiled Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class WellOiledCloak : Item
	{
		public WellOiledCloak() : base()
		{
			Id = 12254;
			Resistance[0] = 29;
			Bonding = 2;
			SellPrice = 4483;
			AvailableClasses = 0x7FFF;
			Model = 23079;
			ObjectClass = 4;
			SubClass = 1;
			Level = 44;
			ReqLevel = 39;
			Name = "Well Oiled Cloak";
			Name2 = "Well Oiled Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 22416;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Nightfall Drape)
*
***************************************************************/

namespace Server.Items
{
	public class NightfallDrape : Item
	{
		public NightfallDrape() : base()
		{
			Id = 12465;
			Resistance[0] = 38;
			Bonding = 1;
			SellPrice = 10261;
			AvailableClasses = 0x7FFF;
			Model = 22989;
			ObjectClass = 4;
			SubClass = 1;
			Level = 53;
			ReqLevel = 48;
			Name = "Nightfall Drape";
			Name2 = "Nightfall Drape";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 51309;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 14;
			IqBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Stoneshield Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class StoneshieldCloak : Item
	{
		public StoneshieldCloak() : base()
		{
			Id = 12551;
			Resistance[0] = 190;
			Bonding = 2;
			SellPrice = 11594;
			AvailableClasses = 0x7FFF;
			Model = 28695;
			ObjectClass = 4;
			SubClass = 1;
			Level = 56;
			ReqLevel = 51;
			Name = "Stoneshield Cloak";
			Name2 = "Stoneshield Cloak";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 57972;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Blisterbane Wrap)
*
***************************************************************/

namespace Server.Items
{
	public class BlisterbaneWrap : Item
	{
		public BlisterbaneWrap() : base()
		{
			Id = 12552;
			Resistance[0] = 39;
			Bonding = 2;
			SellPrice = 10980;
			AvailableClasses = 0x7FFF;
			Model = 23111;
			ObjectClass = 4;
			SubClass = 1;
			Level = 55;
			ReqLevel = 50;
			Name = "Blisterbane Wrap";
			Name2 = "Blisterbane Wrap";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 54901;
			Resistance[5] = 6;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			AgilityBonus = 15;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Butcher's Apron)
*
***************************************************************/

namespace Server.Items
{
	public class ButchersApron : Item
	{
		public ButchersApron() : base()
		{
			Id = 12608;
			Resistance[0] = 38;
			Bonding = 1;
			SellPrice = 11026;
			AvailableClasses = 0x7FFF;
			Model = 28693;
			ObjectClass = 4;
			SubClass = 1;
			Level = 58;
			ReqLevel = 53;
			Name = "Butcher's Apron";
			Name2 = "Butcher's Apron";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 55132;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 4;
			IqBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Wildfire Cape)
*
***************************************************************/

namespace Server.Items
{
	public class WildfireCape : Item
	{
		public WildfireCape() : base()
		{
			Id = 12905;
			Resistance[0] = 39;
			Bonding = 1;
			SellPrice = 13633;
			AvailableClasses = 0x7FFF;
			Model = 28605;
			Resistance[2] = 15;
			ObjectClass = 4;
			SubClass = 1;
			Level = 61;
			ReqLevel = 56;
			Name = "Wildfire Cape";
			Name2 = "Wildfire Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 68165;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Bloodmoon Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class BloodmoonCloak : Item
	{
		public BloodmoonCloak() : base()
		{
			Id = 12967;
			Resistance[6] = 7;
			Resistance[0] = 45;
			Bonding = 1;
			SellPrice = 16884;
			AvailableClasses = 0x7FFF;
			Model = 23553;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Bloodmoon Cloak";
			Name2 = "Bloodmoon Cloak";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 84420;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 17;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Frostweaver Cape)
*
***************************************************************/

namespace Server.Items
{
	public class FrostweaverCape : Item
	{
		public FrostweaverCape() : base()
		{
			Id = 12968;
			Resistance[0] = 45;
			Bonding = 1;
			SellPrice = 16948;
			AvailableClasses = 0x7FFF;
			Model = 23554;
			Resistance[4] = 10;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Frostweaver Cape";
			Name2 = "Frostweaver Cape";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 84740;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			SpiritBonus = 12;
			IqBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Firebane Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class FirebaneCloak : Item
	{
		public FirebaneCloak() : base()
		{
			Id = 12979;
			Resistance[0] = 19;
			Bonding = 2;
			SellPrice = 617;
			AvailableClasses = 0x7FFF;
			Model = 28661;
			Resistance[2] = 5;
			ObjectClass = 4;
			SubClass = 1;
			Level = 21;
			ReqLevel = 16;
			Name = "Firebane Cloak";
			Name2 = "Firebane Cloak";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 3086;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Amy's Blanket)
*
***************************************************************/

namespace Server.Items
{
	public class AmysBlanket : Item
	{
		public AmysBlanket() : base()
		{
			Id = 13005;
			Resistance[0] = 23;
			Bonding = 2;
			SellPrice = 1331;
			AvailableClasses = 0x7FFF;
			Model = 28951;
			ObjectClass = 4;
			SubClass = 1;
			Level = 28;
			ReqLevel = 23;
			Name = "Amy's Blanket";
			Name2 = "Amy's Blanket";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 6657;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			IqBonus = 7;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Mageflame Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class MageflameCloak : Item
	{
		public MageflameCloak() : base()
		{
			Id = 13007;
			Resistance[0] = 41;
			Bonding = 2;
			SellPrice = 13585;
			AvailableClasses = 0x7FFF;
			Model = 28616;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 1;
			Level = 58;
			ReqLevel = 53;
			Name = "Mageflame Cloak";
			Name2 = "Mageflame Cloak";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 67926;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			SetSpell( 9298 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Tigerstrike Mantle)
*
***************************************************************/

namespace Server.Items
{
	public class TigerstrikeMantle : Item
	{
		public TigerstrikeMantle() : base()
		{
			Id = 13108;
			Resistance[0] = 25;
			Bonding = 2;
			SellPrice = 2446;
			AvailableClasses = 0x7FFF;
			Model = 28614;
			ObjectClass = 4;
			SubClass = 1;
			Level = 34;
			ReqLevel = 29;
			Name = "Tigerstrike Mantle";
			Name2 = "Tigerstrike Mantle";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 12231;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			AgilityBonus = 8;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Blackflame Cape)
*
***************************************************************/

namespace Server.Items
{
	public class BlackflameCape : Item
	{
		public BlackflameCape() : base()
		{
			Id = 13109;
			Resistance[0] = 35;
			Bonding = 2;
			SellPrice = 8152;
			AvailableClasses = 0x7FFF;
			Model = 28609;
			Resistance[2] = 5;
			ObjectClass = 4;
			SubClass = 1;
			Level = 49;
			ReqLevel = 44;
			Name = "Blackflame Cape";
			Name2 = "Blackflame Cape";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 40762;
			Resistance[5] = 5;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			AgilityBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Wing of the Whelpling)
*
***************************************************************/

namespace Server.Items
{
	public class WingOfTheWhelpling : Item
	{
		public WingOfTheWhelpling() : base()
		{
			Id = 13121;
			Resistance[0] = 28;
			Bonding = 2;
			SellPrice = 3428;
			AvailableClasses = 0x7FFF;
			Model = 28602;
			ObjectClass = 4;
			SubClass = 1;
			Level = 38;
			ReqLevel = 33;
			Name = "Wing of the Whelpling";
			Name2 = "Wing of the Whelpling";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 17142;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 10;
			AgilityBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Dark Phantom Cape)
*
***************************************************************/

namespace Server.Items
{
	public class DarkPhantomCape : Item
	{
		public DarkPhantomCape() : base()
		{
			Id = 13122;
			Resistance[0] = 39;
			Bonding = 2;
			SellPrice = 11489;
			AvailableClasses = 0x7FFF;
			Model = 28652;
			ObjectClass = 4;
			SubClass = 1;
			Level = 55;
			ReqLevel = 50;
			Name = "Dark Phantom Cape";
			Name2 = "Dark Phantom Cape";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 57447;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			AgilityBonus = 15;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Armswake Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class ArmswakeCloak : Item
	{
		public ArmswakeCloak() : base()
		{
			Id = 13203;
			Resistance[0] = 39;
			Bonding = 1;
			SellPrice = 19498;
			AvailableClasses = 0x7FFF;
			Model = 23747;
			ObjectClass = 4;
			SubClass = 1;
			Level = 60;
			ReqLevel = 55;
			Name = "Armswake Cloak";
			Name2 = "Armswake Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 97492;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Cape of the Black Baron)
*
***************************************************************/

namespace Server.Items
{
	public class CapeOfTheBlackBaron : Item
	{
		public CapeOfTheBlackBaron() : base()
		{
			Id = 13340;
			Resistance[0] = 45;
			Bonding = 1;
			SellPrice = 16498;
			AvailableClasses = 0x7FFF;
			Model = 24013;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Cape of the Black Baron";
			Name2 = "Cape of the Black Baron";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 82494;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			SetSpell( 9331 , 1 , 0 , -1 , 0 , -1 );
			AgilityBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Royal Tribunal Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class RoyalTribunalCloak : Item
	{
		public RoyalTribunalCloak() : base()
		{
			Id = 13376;
			Resistance[0] = 42;
			Bonding = 1;
			SellPrice = 13738;
			AvailableClasses = 0x7FFF;
			Model = 24065;
			ObjectClass = 4;
			SubClass = 1;
			Level = 59;
			ReqLevel = 54;
			Name = "Royal Tribunal Cloak";
			Name2 = "Royal Tribunal Cloak";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 68693;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			SpiritBonus = 16;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Archivist Cape)
*
***************************************************************/

namespace Server.Items
{
	public class ArchivistCape : Item
	{
		public ArchivistCape() : base()
		{
			Id = 13386;
			Resistance[0] = 43;
			Bonding = 1;
			SellPrice = 15722;
			AvailableClasses = 0x7FFF;
			Model = 24073;
			ObjectClass = 4;
			SubClass = 1;
			Level = 61;
			ReqLevel = 56;
			Name = "Archivist Cape";
			Name2 = "Archivist Cape";
			Quality = 3;
			AvailableRaces = 0x1FF;
			Extra = 975;
			BuyPrice = 78610;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			SetSpell( 21618 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Stoneskin Gargoyle Cape)
*
***************************************************************/

namespace Server.Items
{
	public class StoneskinGargoyleCape : Item
	{
		public StoneskinGargoyleCape() : base()
		{
			Id = 13397;
			Resistance[0] = 43;
			Bonding = 1;
			SellPrice = 15201;
			AvailableClasses = 0x7FFF;
			Model = 24108;
			ObjectClass = 4;
			SubClass = 1;
			Level = 61;
			ReqLevel = 56;
			Name = "Stoneskin Gargoyle Cape";
			Name2 = "Stoneskin Gargoyle Cape";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 76008;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			AgilityBonus = 8;
			StrBonus = 7;
			StaminaBonus = 14;
		}
	}
}


/**************************************************************
*
*				(Runecloth Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class RuneclothCloak : Item
	{
		public RuneclothCloak() : base()
		{
			Id = 13860;
			Resistance[0] = 34;
			Bonding = 2;
			SellPrice = 8741;
			AvailableClasses = 0x7FFF;
			Model = 25232;
			ObjectClass = 4;
			SubClass = 1;
			Level = 53;
			ReqLevel = 48;
			Name = "Runecloth Cloak";
			Name2 = "Runecloth Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 43705;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			IqBonus = 9;
			SpiritBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Cindercloth Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class CinderclothCloak : Item
	{
		public CinderclothCloak() : base()
		{
			Id = 14044;
			Resistance[0] = 36;
			Bonding = 2;
			SellPrice = 9503;
			AvailableClasses = 0x7FFF;
			Model = 23422;
			ObjectClass = 4;
			SubClass = 1;
			Level = 55;
			ReqLevel = 50;
			Name = "Cindercloth Cloak";
			Name2 = "Cindercloth Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 47516;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			SetSpell( 9400 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Beaded Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class BeadedCloak : Item
	{
		public BeadedCloak() : base()
		{
			Id = 14088;
			Resistance[0] = 7;
			SellPrice = 24;
			AvailableClasses = 0x7FFF;
			Model = 23132;
			ObjectClass = 4;
			SubClass = 1;
			Level = 8;
			ReqLevel = 3;
			Name = "Beaded Cloak";
			Name2 = "Beaded Cloak";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 124;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Native Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class NativeCloak : Item
	{
		public NativeCloak() : base()
		{
			Id = 14098;
			Resistance[0] = 9;
			SellPrice = 43;
			AvailableClasses = 0x7FFF;
			Model = 25875;
			ObjectClass = 4;
			SubClass = 1;
			Level = 10;
			ReqLevel = 5;
			Name = "Native Cloak";
			Name2 = "Native Cloak";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 218;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Brightcloth Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class BrightclothCloak : Item
	{
		public BrightclothCloak() : base()
		{
			Id = 14103;
			Resistance[0] = 36;
			Bonding = 2;
			SellPrice = 9716;
			AvailableClasses = 0x7FFF;
			Model = 24928;
			Resistance[4] = 7;
			ObjectClass = 4;
			SubClass = 1;
			Level = 55;
			ReqLevel = 50;
			Name = "Brightcloth Cloak";
			Name2 = "Brightcloth Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 48582;
			Resistance[5] = 7;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			SetSpell( 7703 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Aboriginal Cape)
*
***************************************************************/

namespace Server.Items
{
	public class AboriginalCape : Item
	{
		public AboriginalCape() : base()
		{
			Id = 14116;
			Resistance[0] = 12;
			SellPrice = 106;
			AvailableClasses = 0x7FFF;
			Model = 25855;
			ObjectClass = 4;
			SubClass = 1;
			Level = 14;
			ReqLevel = 9;
			Name = "Aboriginal Cape";
			Name2 = "Aboriginal Cape";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 530;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Ritual Cape)
*
***************************************************************/

namespace Server.Items
{
	public class RitualCape : Item
	{
		public RitualCape() : base()
		{
			Id = 14123;
			Resistance[0] = 15;
			Bonding = 2;
			SellPrice = 287;
			AvailableClasses = 0x7FFF;
			Model = 25916;
			ObjectClass = 4;
			SubClass = 1;
			Level = 17;
			ReqLevel = 12;
			Name = "Ritual Cape";
			Name2 = "Ritual Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 960;
			BuyPrice = 1439;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Cloak of Fire)
*
***************************************************************/

namespace Server.Items
{
	public class CloakOfFire : Item
	{
		public CloakOfFire() : base()
		{
			Id = 14134;
			Resistance[0] = 39;
			Bonding = 2;
			SellPrice = 11280;
			AvailableClasses = 0x7FFF;
			Model = 24946;
			Resistance[2] = 6;
			ObjectClass = 4;
			SubClass = 1;
			Level = 55;
			ReqLevel = 50;
			Name = "Cloak of Fire";
			Name2 = "Cloak of Fire";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 56401;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			Flags = 64;
			SetSpell( 18364 , 0 , 0 , 120000 , 0 , -1 );
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Subterranean Cape)
*
***************************************************************/

namespace Server.Items
{
	public class SubterraneanCape : Item
	{
		public SubterraneanCape() : base()
		{
			Id = 14149;
			Resistance[0] = 16;
			Bonding = 1;
			SellPrice = 307;
			AvailableClasses = 0x7FFF;
			Model = 24985;
			ObjectClass = 4;
			SubClass = 1;
			Level = 18;
			ReqLevel = 13;
			Name = "Subterranean Cape";
			Name2 = "Subterranean Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1538;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			AgilityBonus = 2;
			StrBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Pagan Cape)
*
***************************************************************/

namespace Server.Items
{
	public class PaganCape : Item
	{
		public PaganCape() : base()
		{
			Id = 14161;
			Resistance[0] = 16;
			Bonding = 2;
			SellPrice = 337;
			AvailableClasses = 0x7FFF;
			Model = 23101;
			ObjectClass = 4;
			SubClass = 1;
			Level = 18;
			ReqLevel = 13;
			Name = "Pagan Cape";
			Name2 = "Pagan Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 960;
			BuyPrice = 1685;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Buccaneer's Cape)
*
***************************************************************/

namespace Server.Items
{
	public class BuccaneersCape : Item
	{
		public BuccaneersCape() : base()
		{
			Id = 14167;
			Resistance[0] = 16;
			Bonding = 2;
			SellPrice = 358;
			AvailableClasses = 0x7FFF;
			Model = 28054;
			ObjectClass = 4;
			SubClass = 1;
			Level = 19;
			ReqLevel = 14;
			Name = "Buccaneer's Cape";
			Name2 = "Buccaneer's Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 961;
			BuyPrice = 1793;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Watcher's Cape)
*
***************************************************************/

namespace Server.Items
{
	public class WatchersCape : Item
	{
		public WatchersCape() : base()
		{
			Id = 14179;
			Resistance[0] = 19;
			Bonding = 2;
			SellPrice = 747;
			AvailableClasses = 0x7FFF;
			Model = 23109;
			ObjectClass = 4;
			SubClass = 1;
			Level = 24;
			ReqLevel = 19;
			Name = "Watcher's Cape";
			Name2 = "Watcher's Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 962;
			BuyPrice = 3738;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Raincaller Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class RaincallerCloak : Item
	{
		public RaincallerCloak() : base()
		{
			Id = 14188;
			Resistance[0] = 20;
			Bonding = 2;
			SellPrice = 982;
			AvailableClasses = 0x7FFF;
			Model = 23138;
			ObjectClass = 4;
			SubClass = 1;
			Level = 27;
			ReqLevel = 22;
			Name = "Raincaller Cloak";
			Name2 = "Raincaller Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 963;
			BuyPrice = 4911;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Thistlefur Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class ThistlefurCloak : Item
	{
		public ThistlefurCloak() : base()
		{
			Id = 14198;
			Resistance[0] = 22;
			Bonding = 2;
			SellPrice = 1531;
			AvailableClasses = 0x7FFF;
			Model = 26006;
			ObjectClass = 4;
			SubClass = 1;
			Level = 31;
			ReqLevel = 26;
			Name = "Thistlefur Cloak";
			Name2 = "Thistlefur Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 965;
			BuyPrice = 7659;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Vital Cape)
*
***************************************************************/

namespace Server.Items
{
	public class VitalCape : Item
	{
		public VitalCape() : base()
		{
			Id = 14210;
			Resistance[0] = 22;
			Bonding = 2;
			SellPrice = 1636;
			AvailableClasses = 0x7FFF;
			Model = 26015;
			ObjectClass = 4;
			SubClass = 1;
			Level = 32;
			ReqLevel = 27;
			Name = "Vital Cape";
			Name2 = "Vital Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 965;
			BuyPrice = 8184;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Geomancer's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class GeomancersCloak : Item
	{
		public GeomancersCloak() : base()
		{
			Id = 14219;
			Resistance[0] = 23;
			Bonding = 2;
			SellPrice = 2046;
			AvailableClasses = 0x7FFF;
			Model = 26045;
			ObjectClass = 4;
			SubClass = 1;
			Level = 34;
			ReqLevel = 29;
			Name = "Geomancer's Cloak";
			Name2 = "Geomancer's Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 966;
			BuyPrice = 10230;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Embersilk Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class EmbersilkCloak : Item
	{
		public EmbersilkCloak() : base()
		{
			Id = 14229;
			Resistance[0] = 24;
			Bonding = 2;
			SellPrice = 2387;
			AvailableClasses = 0x7FFF;
			Model = 26057;
			ObjectClass = 4;
			SubClass = 1;
			Level = 36;
			ReqLevel = 31;
			Name = "Embersilk Cloak";
			Name2 = "Embersilk Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 966;
			BuyPrice = 11938;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Darkmist Cape)
*
***************************************************************/

namespace Server.Items
{
	public class DarkmistCape : Item
	{
		public DarkmistCape() : base()
		{
			Id = 14239;
			Resistance[0] = 26;
			Bonding = 2;
			SellPrice = 3176;
			AvailableClasses = 0x7FFF;
			Model = 26101;
			ObjectClass = 4;
			SubClass = 1;
			Level = 39;
			ReqLevel = 34;
			Name = "Darkmist Cape";
			Name2 = "Darkmist Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 967;
			BuyPrice = 15881;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Lunar Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class LunarCloak : Item
	{
		public LunarCloak() : base()
		{
			Id = 14251;
			Resistance[0] = 26;
			Bonding = 2;
			SellPrice = 3332;
			AvailableClasses = 0x7FFF;
			Model = 26112;
			ObjectClass = 4;
			SubClass = 1;
			Level = 40;
			ReqLevel = 35;
			Name = "Lunar Cloak";
			Name2 = "Lunar Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 968;
			BuyPrice = 16661;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Bloodwoven Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class BloodwovenCloak : Item
	{
		public BloodwovenCloak() : base()
		{
			Id = 14261;
			Resistance[0] = 28;
			Bonding = 2;
			SellPrice = 4044;
			AvailableClasses = 0x7FFF;
			Model = 26189;
			ObjectClass = 4;
			SubClass = 1;
			Level = 43;
			ReqLevel = 38;
			Name = "Bloodwoven Cloak";
			Name2 = "Bloodwoven Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 969;
			BuyPrice = 20222;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Gaea's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class GaeasCloak : Item
	{
		public GaeasCloak() : base()
		{
			Id = 14270;
			Resistance[0] = 30;
			Bonding = 2;
			SellPrice = 4877;
			AvailableClasses = 0x7FFF;
			Model = 23031;
			ObjectClass = 4;
			SubClass = 1;
			Level = 45;
			ReqLevel = 40;
			Name = "Gaea's Cloak";
			Name2 = "Gaea's Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 969;
			BuyPrice = 24389;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Opulent Cape)
*
***************************************************************/

namespace Server.Items
{
	public class OpulentCape : Item
	{
		public OpulentCape() : base()
		{
			Id = 14280;
			Resistance[0] = 31;
			Bonding = 2;
			SellPrice = 5919;
			AvailableClasses = 0x7FFF;
			Model = 26137;
			ObjectClass = 4;
			SubClass = 1;
			Level = 48;
			ReqLevel = 43;
			Name = "Opulent Cape";
			Name2 = "Opulent Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 970;
			BuyPrice = 29596;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Arachnidian Cape)
*
***************************************************************/

namespace Server.Items
{
	public class ArachnidianCape : Item
	{
		public ArachnidianCape() : base()
		{
			Id = 14292;
			Resistance[0] = 32;
			Bonding = 2;
			SellPrice = 6795;
			AvailableClasses = 0x7FFF;
			Model = 26215;
			ObjectClass = 4;
			SubClass = 1;
			Level = 49;
			ReqLevel = 44;
			Name = "Arachnidian Cape";
			Name2 = "Arachnidian Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 971;
			BuyPrice = 33978;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Bonecaster's Cape)
*
***************************************************************/

namespace Server.Items
{
	public class BonecastersCape : Item
	{
		public BonecastersCape() : base()
		{
			Id = 14300;
			Resistance[0] = 34;
			Bonding = 2;
			SellPrice = 7685;
			AvailableClasses = 0x7FFF;
			Model = 26271;
			ObjectClass = 4;
			SubClass = 1;
			Level = 52;
			ReqLevel = 47;
			Name = "Bonecaster's Cape";
			Name2 = "Bonecaster's Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 972;
			BuyPrice = 38425;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Celestial Cape)
*
***************************************************************/

namespace Server.Items
{
	public class CelestialCape : Item
	{
		public CelestialCape() : base()
		{
			Id = 14313;
			Resistance[0] = 35;
			Bonding = 2;
			SellPrice = 9298;
			AvailableClasses = 0x7FFF;
			Model = 26262;
			ObjectClass = 4;
			SubClass = 1;
			Level = 54;
			ReqLevel = 49;
			Name = "Celestial Cape";
			Name2 = "Celestial Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 972;
			BuyPrice = 46493;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Resplendent Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class ResplendentCloak : Item
	{
		public ResplendentCloak() : base()
		{
			Id = 14321;
			Resistance[0] = 36;
			Bonding = 2;
			SellPrice = 9438;
			AvailableClasses = 0x7FFF;
			Model = 26299;
			ObjectClass = 4;
			SubClass = 1;
			Level = 55;
			ReqLevel = 50;
			Name = "Resplendent Cloak";
			Name2 = "Resplendent Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 973;
			BuyPrice = 47190;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Eternal Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class EternalCloak : Item
	{
		public EternalCloak() : base()
		{
			Id = 14331;
			Resistance[0] = 38;
			Bonding = 2;
			SellPrice = 11654;
			AvailableClasses = 0x7FFF;
			Model = 26227;
			ObjectClass = 4;
			SubClass = 1;
			Level = 58;
			ReqLevel = 53;
			Name = "Eternal Cloak";
			Name2 = "Eternal Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 974;
			BuyPrice = 58273;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Mystic's Cape)
*
***************************************************************/

namespace Server.Items
{
	public class MysticsCape : Item
	{
		public MysticsCape() : base()
		{
			Id = 14365;
			Resistance[0] = 14;
			Bonding = 2;
			SellPrice = 214;
			AvailableClasses = 0x7FFF;
			Model = 25884;
			ObjectClass = 4;
			SubClass = 1;
			Level = 15;
			ReqLevel = 10;
			Name = "Mystic's Cape";
			Name2 = "Mystic's Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1072;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			AgilityBonus = 1;
			IqBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Sanguine Cape)
*
***************************************************************/

namespace Server.Items
{
	public class SanguineCape : Item
	{
		public SanguineCape() : base()
		{
			Id = 14376;
			Resistance[0] = 18;
			Bonding = 2;
			SellPrice = 551;
			AvailableClasses = 0x7FFF;
			Model = 25958;
			ObjectClass = 4;
			SubClass = 1;
			Level = 22;
			ReqLevel = 17;
			Name = "Sanguine Cape";
			Name2 = "Sanguine Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2759;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			SpiritBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Resilient Cape)
*
***************************************************************/

namespace Server.Items
{
	public class ResilientCape : Item
	{
		public ResilientCape() : base()
		{
			Id = 14400;
			Resistance[0] = 21;
			Bonding = 2;
			SellPrice = 1215;
			AvailableClasses = 0x7FFF;
			Model = 25997;
			ObjectClass = 4;
			SubClass = 1;
			Level = 29;
			ReqLevel = 24;
			Name = "Resilient Cape";
			Name2 = "Resilient Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6078;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			SpiritBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Stonecloth Cape)
*
***************************************************************/

namespace Server.Items
{
	public class StoneclothCape : Item
	{
		public StoneclothCape() : base()
		{
			Id = 14409;
			Resistance[0] = 23;
			Bonding = 2;
			SellPrice = 1707;
			AvailableClasses = 0x7FFF;
			Model = 26027;
			ObjectClass = 4;
			SubClass = 1;
			Level = 33;
			ReqLevel = 28;
			Name = "Stonecloth Cape";
			Name2 = "Stonecloth Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 8535;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 5;
			IqBonus = 3;
			StrBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Silksand Cape)
*
***************************************************************/

namespace Server.Items
{
	public class SilksandCape : Item
	{
		public SilksandCape() : base()
		{
			Id = 14420;
			Resistance[0] = 25;
			Bonding = 2;
			SellPrice = 2889;
			AvailableClasses = 0x7FFF;
			Model = 26080;
			ObjectClass = 4;
			SubClass = 1;
			Level = 38;
			ReqLevel = 33;
			Name = "Silksand Cape";
			Name2 = "Silksand Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 14446;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 6;
			SpiritBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Windchaser Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class WindchaserCloak : Item
	{
		public WindchaserCloak() : base()
		{
			Id = 14430;
			Resistance[0] = 28;
			Bonding = 2;
			SellPrice = 3686;
			AvailableClasses = 0x7FFF;
			Model = 26175;
			ObjectClass = 4;
			SubClass = 1;
			Level = 42;
			ReqLevel = 37;
			Name = "Windchaser Cloak";
			Name2 = "Windchaser Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 18432;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 4;
			IqBonus = 4;
			SpiritBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Venomshroud Cape)
*
***************************************************************/

namespace Server.Items
{
	public class VenomshroudCape : Item
	{
		public VenomshroudCape() : base()
		{
			Id = 14440;
			Resistance[0] = 30;
			Bonding = 2;
			SellPrice = 5347;
			AvailableClasses = 0x7FFF;
			Model = 26201;
			ObjectClass = 4;
			SubClass = 1;
			Level = 46;
			ReqLevel = 41;
			Name = "Venomshroud Cape";
			Name2 = "Venomshroud Cape";
			Resistance[3] = 4;
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 26737;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 6;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Highborne Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class HighborneCloak : Item
	{
		public HighborneCloak() : base()
		{
			Id = 14450;
			Resistance[0] = 33;
			Bonding = 2;
			SellPrice = 7364;
			AvailableClasses = 0x7FFF;
			Model = 26184;
			ObjectClass = 4;
			SubClass = 1;
			Level = 51;
			ReqLevel = 46;
			Name = "Highborne Cloak";
			Name2 = "Highborne Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 36824;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 4;
			SpiritBonus = 9;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Elunarian Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class ElunarianCloak : Item
	{
		public ElunarianCloak() : base()
		{
			Id = 14459;
			Resistance[0] = 37;
			Bonding = 2;
			SellPrice = 10798;
			AvailableClasses = 0x7FFF;
			Model = 26233;
			ObjectClass = 4;
			SubClass = 1;
			Level = 57;
			ReqLevel = 52;
			Name = "Elunarian Cloak";
			Name2 = "Elunarian Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 53991;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 6;
			IqBonus = 11;
			StrBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Prospector's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class ProspectorsCloak : Item
	{
		public ProspectorsCloak() : base()
		{
			Id = 14563;
			Resistance[0] = 15;
			Bonding = 2;
			SellPrice = 275;
			AvailableClasses = 0x7FFF;
			Model = 27525;
			ObjectClass = 4;
			SubClass = 1;
			Level = 17;
			ReqLevel = 12;
			Name = "Prospector's Cloak";
			Name2 = "Prospector's Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1377;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 2;
			StrBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Bristlebark Cape)
*
***************************************************************/

namespace Server.Items
{
	public class BristlebarkCape : Item
	{
		public BristlebarkCape() : base()
		{
			Id = 14571;
			Resistance[0] = 17;
			Bonding = 2;
			SellPrice = 496;
			AvailableClasses = 0x7FFF;
			Model = 27673;
			ObjectClass = 4;
			SubClass = 1;
			Level = 21;
			ReqLevel = 16;
			Name = "Bristlebark Cape";
			Name2 = "Bristlebark Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2481;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			AgilityBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Dokebi Cape)
*
***************************************************************/

namespace Server.Items
{
	public class DokebiCape : Item
	{
		public DokebiCape() : base()
		{
			Id = 14582;
			Resistance[0] = 21;
			Bonding = 2;
			SellPrice = 1088;
			AvailableClasses = 0x7FFF;
			Model = 27584;
			ObjectClass = 4;
			SubClass = 1;
			Level = 28;
			ReqLevel = 23;
			Name = "Dokebi Cape";
			Name2 = "Dokebi Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5444;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 5;
			SpiritBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Hawkeye's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class HawkeyesCloak : Item
	{
		public HawkeyesCloak() : base()
		{
			Id = 14593;
			Resistance[0] = 23;
			Bonding = 2;
			SellPrice = 2210;
			AvailableClasses = 0x7FFF;
			Model = 27980;
			ObjectClass = 4;
			SubClass = 1;
			Level = 35;
			ReqLevel = 30;
			Name = "Hawkeye's Cloak";
			Name2 = "Hawkeye's Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11051;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			AgilityBonus = 7;
			StrBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Warden's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class WardensCloak : Item
	{
		public WardensCloak() : base()
		{
			Id = 14602;
			Resistance[0] = 26;
			Bonding = 2;
			SellPrice = 2995;
			AvailableClasses = 0x7FFF;
			Model = 27986;
			ObjectClass = 4;
			SubClass = 1;
			Level = 39;
			ReqLevel = 34;
			Name = "Warden's Cloak";
			Name2 = "Warden's Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 14975;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StrBonus = 4;
			IqBonus = 4;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Scorpashi Cape)
*
***************************************************************/

namespace Server.Items
{
	public class ScorpashiCape : Item
	{
		public ScorpashiCape() : base()
		{
			Id = 14656;
			Resistance[0] = 29;
			Bonding = 2;
			SellPrice = 4300;
			AvailableClasses = 0x7FFF;
			Model = 27584;
			ObjectClass = 4;
			SubClass = 1;
			Level = 44;
			ReqLevel = 39;
			Name = "Scorpashi Cape";
			Name2 = "Scorpashi Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 21500;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 7;
			AgilityBonus = 5;
			StrBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Keeper's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class KeepersCloak : Item
	{
		public KeepersCloak() : base()
		{
			Id = 14665;
			Resistance[0] = 31;
			Bonding = 2;
			SellPrice = 6214;
			AvailableClasses = 0x7FFF;
			Model = 27573;
			ObjectClass = 4;
			SubClass = 1;
			Level = 48;
			ReqLevel = 43;
			Name = "Keeper's Cloak";
			Name2 = "Keeper's Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 31072;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			SpiritBonus = 10;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Pridelord Cape)
*
***************************************************************/

namespace Server.Items
{
	public class PridelordCape : Item
	{
		public PridelordCape() : base()
		{
			Id = 14673;
			Resistance[0] = 34;
			Bonding = 2;
			SellPrice = 8303;
			AvailableClasses = 0x7FFF;
			Model = 27653;
			ObjectClass = 4;
			SubClass = 1;
			Level = 52;
			ReqLevel = 47;
			Name = "Pridelord Cape";
			Name2 = "Pridelord Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 41518;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StrBonus = 3;
			AgilityBonus = 9;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Indomitable Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class IndomitableCloak : Item
	{
		public IndomitableCloak() : base()
		{
			Id = 14683;
			Resistance[0] = 38;
			Bonding = 2;
			SellPrice = 11932;
			AvailableClasses = 0x7FFF;
			Model = 27573;
			ObjectClass = 4;
			SubClass = 1;
			Level = 59;
			ReqLevel = 54;
			Name = "Indomitable Cloak";
			Name2 = "Indomitable Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 59660;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 3;
			IqBonus = 13;
		}
	}
}


/**************************************************************
*
*				(War Paint Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class WarPaintCloak : Item
	{
		public WarPaintCloak() : base()
		{
			Id = 14724;
			Resistance[0] = 15;
			Bonding = 2;
			SellPrice = 253;
			AvailableClasses = 0x7FFF;
			Model = 26958;
			ObjectClass = 4;
			SubClass = 1;
			Level = 16;
			ReqLevel = 11;
			Name = "War Paint Cloak";
			Name2 = "War Paint Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1265;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 1;
			StrBonus = 1;
			AgilityBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Hulking Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class HulkingCloak : Item
	{
		public HulkingCloak() : base()
		{
			Id = 14745;
			Resistance[0] = 17;
			Bonding = 2;
			SellPrice = 444;
			AvailableClasses = 0x7FFF;
			Model = 27011;
			ObjectClass = 4;
			SubClass = 1;
			Level = 20;
			ReqLevel = 15;
			Name = "Hulking Cloak";
			Name2 = "Hulking Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2221;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 3;
			StrBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Slayer's Cape)
*
***************************************************************/

namespace Server.Items
{
	public class SlayersCape : Item
	{
		public SlayersCape() : base()
		{
			Id = 14752;
			Resistance[0] = 20;
			Bonding = 2;
			SellPrice = 978;
			AvailableClasses = 0x7FFF;
			Model = 27033;
			ObjectClass = 4;
			SubClass = 1;
			Level = 27;
			ReqLevel = 22;
			Name = "Slayer's Cape";
			Name2 = "Slayer's Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4892;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StrBonus = 4;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Enduring Cape)
*
***************************************************************/

namespace Server.Items
{
	public class EnduringCape : Item
	{
		public EnduringCape() : base()
		{
			Id = 14763;
			Resistance[0] = 22;
			Bonding = 2;
			SellPrice = 1685;
			AvailableClasses = 0x7FFF;
			Model = 27051;
			ObjectClass = 4;
			SubClass = 1;
			Level = 32;
			ReqLevel = 27;
			Name = "Enduring Cape";
			Name2 = "Enduring Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 8425;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 7;
			AgilityBonus = 2;
			StrBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Ravager's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class RavagersCloak : Item
	{
		public RavagersCloak() : base()
		{
			Id = 14771;
			Resistance[0] = 26;
			Bonding = 2;
			SellPrice = 3030;
			AvailableClasses = 0x7FFF;
			Model = 26141;
			ObjectClass = 4;
			SubClass = 1;
			Level = 39;
			ReqLevel = 34;
			Name = "Ravager's Cloak";
			Name2 = "Ravager's Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 15150;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 8;
			StrBonus = 2;
			IqBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Khan's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class KhansCloak : Item
	{
		public KhansCloak() : base()
		{
			Id = 14781;
			Resistance[0] = 29;
			Bonding = 2;
			SellPrice = 4617;
			AvailableClasses = 0x7FFF;
			Model = 27152;
			ObjectClass = 4;
			SubClass = 1;
			Level = 44;
			ReqLevel = 39;
			Name = "Khan's Cloak";
			Name2 = "Khan's Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 23089;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StrBonus = 4;
			StaminaBonus = 8;
			IqBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Protector Cape)
*
***************************************************************/

namespace Server.Items
{
	public class ProtectorCape : Item
	{
		public ProtectorCape() : base()
		{
			Id = 14791;
			Resistance[0] = 31;
			Bonding = 2;
			SellPrice = 6056;
			AvailableClasses = 0x7FFF;
			Model = 27161;
			ObjectClass = 4;
			SubClass = 1;
			Level = 48;
			ReqLevel = 43;
			Name = "Protector Cape";
			Name2 = "Protector Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 30282;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 9;
			StrBonus = 4;
			AgilityBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Bloodlust Cape)
*
***************************************************************/

namespace Server.Items
{
	public class BloodlustCape : Item
	{
		public BloodlustCape() : base()
		{
			Id = 14801;
			Resistance[0] = 34;
			Bonding = 2;
			SellPrice = 8156;
			AvailableClasses = 0x7FFF;
			Model = 27197;
			ObjectClass = 4;
			SubClass = 1;
			Level = 52;
			ReqLevel = 47;
			Name = "Bloodlust Cape";
			Name2 = "Bloodlust Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 40782;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 6;
			StrBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Warstrike Cape)
*
***************************************************************/

namespace Server.Items
{
	public class WarstrikeCape : Item
	{
		public WarstrikeCape() : base()
		{
			Id = 14813;
			Resistance[0] = 37;
			Bonding = 2;
			SellPrice = 10601;
			AvailableClasses = 0x7FFF;
			Model = 27143;
			ObjectClass = 4;
			SubClass = 1;
			Level = 57;
			ReqLevel = 52;
			Name = "Warstrike Cape";
			Name2 = "Warstrike Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 53007;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StrBonus = 7;
			StaminaBonus = 10;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Primal Cape)
*
***************************************************************/

namespace Server.Items
{
	public class PrimalCape : Item
	{
		public PrimalCape() : base()
		{
			Id = 15007;
			Resistance[0] = 7;
			SellPrice = 24;
			AvailableClasses = 0x7FFF;
			Model = 28011;
			ObjectClass = 4;
			SubClass = 1;
			Level = 8;
			ReqLevel = 3;
			Name = "Primal Cape";
			Name2 = "Primal Cape";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 122;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Lupine Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class LupineCloak : Item
	{
		public LupineCloak() : base()
		{
			Id = 15015;
			Resistance[0] = 12;
			SellPrice = 86;
			AvailableClasses = 0x7FFF;
			Model = 23050;
			ObjectClass = 4;
			SubClass = 1;
			Level = 13;
			ReqLevel = 8;
			Name = "Lupine Cloak";
			Name2 = "Lupine Cloak";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 433;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Rigid Cape)
*
***************************************************************/

namespace Server.Items
{
	public class RigidCape : Item
	{
		public RigidCape() : base()
		{
			Id = 15114;
			Resistance[0] = 16;
			Bonding = 2;
			SellPrice = 372;
			AvailableClasses = 0x7FFF;
			Model = 27514;
			ObjectClass = 4;
			SubClass = 1;
			Level = 19;
			ReqLevel = 14;
			Name = "Rigid Cape";
			Name2 = "Rigid Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 982;
			BuyPrice = 1862;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Robust Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class RobustCloak : Item
	{
		public RobustCloak() : base()
		{
			Id = 15124;
			Resistance[0] = 19;
			Bonding = 2;
			SellPrice = 847;
			AvailableClasses = 0x7FFF;
			Model = 27693;
			ObjectClass = 4;
			SubClass = 1;
			Level = 25;
			ReqLevel = 20;
			Name = "Robust Cloak";
			Name2 = "Robust Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 984;
			BuyPrice = 4237;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Cutthroat's Cape)
*
***************************************************************/

namespace Server.Items
{
	public class CutthroatsCape : Item
	{
		public CutthroatsCape() : base()
		{
			Id = 15135;
			Resistance[0] = 21;
			Bonding = 2;
			SellPrice = 1357;
			AvailableClasses = 0x7FFF;
			Model = 28563;
			ObjectClass = 4;
			SubClass = 1;
			Level = 30;
			ReqLevel = 25;
			Name = "Cutthroat's Cape";
			Name2 = "Cutthroat's Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 985;
			BuyPrice = 6788;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Onyxia Scale Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class OnyxiaScaleCloak : Item
	{
		public OnyxiaScaleCloak() : base()
		{
			Id = 15138;
			Resistance[0] = 43;
			Bonding = 2;
			SellPrice = 15198;
			AvailableClasses = 0x7FFF;
			Model = 25921;
			Resistance[2] = 16;
			ObjectClass = 4;
			SubClass = 1;
			Level = 60;
			ReqLevel = 55;
			Name = "Onyxia Scale Cloak";
			Name2 = "Onyxia Scale Cloak";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 75993;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			SetSpell( 22683 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Ghostwalker Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class GhostwalkerCloak : Item
	{
		public GhostwalkerCloak() : base()
		{
			Id = 15147;
			Resistance[0] = 23;
			Bonding = 2;
			SellPrice = 1753;
			AvailableClasses = 0x7FFF;
			Model = 27686;
			ObjectClass = 4;
			SubClass = 1;
			Level = 33;
			ReqLevel = 28;
			Name = "Ghostwalker Cloak";
			Name2 = "Ghostwalker Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 986;
			BuyPrice = 8769;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Nocturnal Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class NocturnalCloak : Item
	{
		public NocturnalCloak() : base()
		{
			Id = 15153;
			Resistance[0] = 24;
			Bonding = 2;
			SellPrice = 2626;
			AvailableClasses = 0x7FFF;
			Model = 23048;
			ObjectClass = 4;
			SubClass = 1;
			Level = 37;
			ReqLevel = 32;
			Name = "Nocturnal Cloak";
			Name2 = "Nocturnal Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 988;
			BuyPrice = 13131;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Imposing Cape)
*
***************************************************************/

namespace Server.Items
{
	public class ImposingCape : Item
	{
		public ImposingCape() : base()
		{
			Id = 15165;
			Resistance[0] = 28;
			Bonding = 2;
			SellPrice = 3744;
			AvailableClasses = 0x7FFF;
			Model = 22253;
			ObjectClass = 4;
			SubClass = 1;
			Level = 42;
			ReqLevel = 37;
			Name = "Imposing Cape";
			Name2 = "Imposing Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 989;
			BuyPrice = 18723;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Potent Cape)
*
***************************************************************/

namespace Server.Items
{
	public class PotentCape : Item
	{
		public PotentCape() : base()
		{
			Id = 15173;
			Resistance[0] = 30;
			Bonding = 2;
			SellPrice = 5387;
			AvailableClasses = 0x7FFF;
			Model = 27593;
			ObjectClass = 4;
			SubClass = 1;
			Level = 46;
			ReqLevel = 41;
			Name = "Potent Cape";
			Name2 = "Potent Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 991;
			BuyPrice = 26939;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Praetorian Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class PraetorianCloak : Item
	{
		public PraetorianCloak() : base()
		{
			Id = 15183;
			Resistance[0] = 33;
			Bonding = 2;
			SellPrice = 6751;
			AvailableClasses = 0x7FFF;
			Model = 24159;
			ObjectClass = 4;
			SubClass = 1;
			Level = 50;
			ReqLevel = 45;
			Name = "Praetorian Cloak";
			Name2 = "Praetorian Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 992;
			BuyPrice = 33756;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Grand Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class GrandCloak : Item
	{
		public GrandCloak() : base()
		{
			Id = 15190;
			Resistance[0] = 36;
			Bonding = 2;
			SellPrice = 9614;
			AvailableClasses = 0x7FFF;
			Model = 23051;
			ObjectClass = 4;
			SubClass = 1;
			Level = 55;
			ReqLevel = 50;
			Name = "Grand Cloak";
			Name2 = "Grand Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 994;
			BuyPrice = 48070;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Grizzly Cape)
*
***************************************************************/

namespace Server.Items
{
	public class GrizzlyCape : Item
	{
		public GrizzlyCape() : base()
		{
			Id = 15299;
			Resistance[0] = 9;
			SellPrice = 42;
			AvailableClasses = 0x7FFF;
			Model = 23054;
			ObjectClass = 4;
			SubClass = 1;
			Level = 10;
			ReqLevel = 5;
			Name = "Grizzly Cape";
			Name2 = "Grizzly Cape";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 211;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Feral Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class FeralCloak : Item
	{
		public FeralCloak() : base()
		{
			Id = 15309;
			Resistance[0] = 14;
			Bonding = 2;
			SellPrice = 220;
			AvailableClasses = 0x7FFF;
			Model = 28042;
			ObjectClass = 4;
			SubClass = 1;
			Level = 15;
			ReqLevel = 10;
			Name = "Feral Cloak";
			Name2 = "Feral Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 980;
			BuyPrice = 1100;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Wrangler's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class WranglersCloak : Item
	{
		public WranglersCloak() : base()
		{
			Id = 15333;
			Resistance[0] = 18;
			Bonding = 2;
			SellPrice = 537;
			AvailableClasses = 0x7FFF;
			Model = 28006;
			ObjectClass = 4;
			SubClass = 1;
			Level = 22;
			ReqLevel = 17;
			Name = "Wrangler's Cloak";
			Name2 = "Wrangler's Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 983;
			BuyPrice = 2685;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Pathfinder Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class PathfinderCloak : Item
	{
		public PathfinderCloak() : base()
		{
			Id = 15340;
			Resistance[0] = 20;
			Bonding = 2;
			SellPrice = 1016;
			AvailableClasses = 0x7FFF;
			Model = 27679;
			ObjectClass = 4;
			SubClass = 1;
			Level = 27;
			ReqLevel = 22;
			Name = "Pathfinder Cloak";
			Name2 = "Pathfinder Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 984;
			BuyPrice = 5081;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Headhunter's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class HeadhuntersCloak : Item
	{
		public HeadhuntersCloak() : base()
		{
			Id = 15354;
			Resistance[0] = 22;
			Bonding = 2;
			SellPrice = 1600;
			AvailableClasses = 0x7FFF;
			Model = 27700;
			ObjectClass = 4;
			SubClass = 1;
			Level = 32;
			ReqLevel = 27;
			Name = "Headhunter's Cloak";
			Name2 = "Headhunter's Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 986;
			BuyPrice = 8003;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Trickster's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class TrickstersCloak : Item
	{
		public TrickstersCloak() : base()
		{
			Id = 15364;
			Resistance[0] = 24;
			Bonding = 2;
			SellPrice = 2431;
			AvailableClasses = 0x7FFF;
			Model = 27960;
			ObjectClass = 4;
			SubClass = 1;
			Level = 36;
			ReqLevel = 31;
			Name = "Trickster's Cloak";
			Name2 = "Trickster's Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 987;
			BuyPrice = 12157;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Wolf Rider's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class WolfRidersCloak : Item
	{
		public WolfRidersCloak() : base()
		{
			Id = 15371;
			Resistance[0] = 27;
			Bonding = 2;
			SellPrice = 3467;
			AvailableClasses = 0x7FFF;
			Model = 27974;
			ObjectClass = 4;
			SubClass = 1;
			Level = 41;
			ReqLevel = 36;
			Name = "Wolf Rider's Cloak";
			Name2 = "Wolf Rider's Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 989;
			BuyPrice = 17338;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Rageclaw Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class RageclawCloak : Item
	{
		public RageclawCloak() : base()
		{
			Id = 15382;
			Resistance[0] = 30;
			Bonding = 2;
			SellPrice = 5043;
			AvailableClasses = 0x7FFF;
			Model = 23018;
			ObjectClass = 4;
			SubClass = 1;
			Level = 45;
			ReqLevel = 40;
			Name = "Rageclaw Cloak";
			Name2 = "Rageclaw Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 990;
			BuyPrice = 25215;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Jadefire Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class JadefireCloak : Item
	{
		public JadefireCloak() : base()
		{
			Id = 15392;
			Resistance[0] = 32;
			Bonding = 2;
			SellPrice = 6382;
			AvailableClasses = 0x7FFF;
			Model = 27658;
			ObjectClass = 4;
			SubClass = 1;
			Level = 49;
			ReqLevel = 44;
			Name = "Jadefire Cloak";
			Name2 = "Jadefire Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 992;
			BuyPrice = 31911;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Shroud of the Exile)
*
***************************************************************/

namespace Server.Items
{
	public class ShroudOfTheExile : Item
	{
		public ShroudOfTheExile() : base()
		{
			Id = 15421;
			Resistance[0] = 45;
			Bonding = 1;
			SellPrice = 17855;
			AvailableClasses = 0x7FFF;
			Model = 26681;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			Name = "Shroud of the Exile";
			Name2 = "Shroud of the Exile";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 89275;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			SpiritBonus = 15;
			IqBonus = 7;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Peerless Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class PeerlessCloak : Item
	{
		public PeerlessCloak() : base()
		{
			Id = 15427;
			Resistance[0] = 35;
			Bonding = 2;
			SellPrice = 8536;
			AvailableClasses = 0x7FFF;
			Model = 23048;
			ObjectClass = 4;
			SubClass = 1;
			Level = 54;
			ReqLevel = 49;
			Name = "Peerless Cloak";
			Name2 = "Peerless Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 993;
			BuyPrice = 42683;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Supreme Cape)
*
***************************************************************/

namespace Server.Items
{
	public class SupremeCape : Item
	{
		public SupremeCape() : base()
		{
			Id = 15437;
			Resistance[0] = 39;
			Bonding = 2;
			SellPrice = 13301;
			AvailableClasses = 0x7FFF;
			Model = 26271;
			ObjectClass = 4;
			SubClass = 1;
			Level = 61;
			ReqLevel = 56;
			Name = "Supreme Cape";
			Name2 = "Supreme Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 996;
			BuyPrice = 66506;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Windsong Drape)
*
***************************************************************/

namespace Server.Items
{
	public class WindsongDrape : Item
	{
		public WindsongDrape() : base()
		{
			Id = 15468;
			Resistance[0] = 21;
			Bonding = 1;
			SellPrice = 1207;
			AvailableClasses = 0x7FFF;
			Model = 28303;
			ObjectClass = 4;
			SubClass = 1;
			Level = 29;
			Name = "Windsong Drape";
			Name2 = "Windsong Drape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6035;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			IqBonus = 4;
			SpiritBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Charger's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class ChargersCloak : Item
	{
		public ChargersCloak() : base()
		{
			Id = 15475;
			Resistance[0] = 7;
			SellPrice = 24;
			AvailableClasses = 0x7FFF;
			Model = 26980;
			ObjectClass = 4;
			SubClass = 1;
			Level = 8;
			ReqLevel = 3;
			Name = "Charger's Cloak";
			Name2 = "Charger's Cloak";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 120;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(War Torn Cape)
*
***************************************************************/

namespace Server.Items
{
	public class WarTornCape : Item
	{
		public WarTornCape() : base()
		{
			Id = 15483;
			Resistance[0] = 9;
			SellPrice = 41;
			AvailableClasses = 0x7FFF;
			Model = 26958;
			ObjectClass = 4;
			SubClass = 1;
			Level = 10;
			ReqLevel = 5;
			Name = "War Torn Cape";
			Name2 = "War Torn Cape";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 209;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Bloodspattered Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class BloodspatteredCloak : Item
	{
		public BloodspatteredCloak() : base()
		{
			Id = 15490;
			Resistance[0] = 12;
			SellPrice = 105;
			AvailableClasses = 0x7FFF;
			Model = 27006;
			ObjectClass = 4;
			SubClass = 1;
			Level = 14;
			ReqLevel = 9;
			Name = "Bloodspattered Cloak";
			Name2 = "Bloodspattered Cloak";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 526;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Outrunner's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class OutrunnersCloak : Item
	{
		public OutrunnersCloak() : base()
		{
			Id = 15501;
			Resistance[0] = 15;
			Bonding = 2;
			SellPrice = 269;
			AvailableClasses = 0x7FFF;
			Model = 26991;
			ObjectClass = 4;
			SubClass = 1;
			Level = 17;
			ReqLevel = 12;
			Name = "Outrunner's Cloak";
			Name2 = "Outrunner's Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1002;
			BuyPrice = 1346;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Grunt's Cape)
*
***************************************************************/

namespace Server.Items
{
	public class GruntsCape : Item
	{
		public GruntsCape() : base()
		{
			Id = 15508;
			Resistance[0] = 16;
			Bonding = 2;
			SellPrice = 365;
			AvailableClasses = 0x7FFF;
			Model = 26977;
			ObjectClass = 4;
			SubClass = 1;
			Level = 19;
			ReqLevel = 14;
			Name = "Grunt's Cape";
			Name2 = "Grunt's Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1003;
			BuyPrice = 1827;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Spiked Chain Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class SpikedChainCloak : Item
	{
		public SpikedChainCloak() : base()
		{
			Id = 15519;
			Resistance[0] = 18;
			Bonding = 2;
			SellPrice = 607;
			AvailableClasses = 0x7FFF;
			Model = 26962;
			ObjectClass = 4;
			SubClass = 1;
			Level = 23;
			ReqLevel = 18;
			Name = "Spiked Chain Cloak";
			Name2 = "Spiked Chain Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1004;
			BuyPrice = 3035;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Sentry's Cape)
*
***************************************************************/

namespace Server.Items
{
	public class SentrysCape : Item
	{
		public SentrysCape() : base()
		{
			Id = 15526;
			Resistance[0] = 19;
			Bonding = 2;
			SellPrice = 704;
			AvailableClasses = 0x7FFF;
			Model = 27082;
			ObjectClass = 4;
			SubClass = 1;
			Level = 24;
			ReqLevel = 19;
			Name = "Sentry's Cape";
			Name2 = "Sentry's Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1004;
			BuyPrice = 3523;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Wicked Chain Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class WickedChainCloak : Item
	{
		public WickedChainCloak() : base()
		{
			Id = 15537;
			Resistance[0] = 21;
			Bonding = 2;
			SellPrice = 1163;
			AvailableClasses = 0x7FFF;
			Model = 27040;
			ObjectClass = 4;
			SubClass = 1;
			Level = 28;
			ReqLevel = 23;
			Name = "Wicked Chain Cloak";
			Name2 = "Wicked Chain Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1006;
			BuyPrice = 5816;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Thick Scale Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class ThickScaleCloak : Item
	{
		public ThickScaleCloak() : base()
		{
			Id = 15547;
			Resistance[0] = 21;
			Bonding = 2;
			SellPrice = 1234;
			AvailableClasses = 0x7FFF;
			Model = 26951;
			ObjectClass = 4;
			SubClass = 1;
			Level = 29;
			ReqLevel = 24;
			Name = "Thick Scale Cloak";
			Name2 = "Thick Scale Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1006;
			BuyPrice = 6172;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Pillager's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class PillagersCloak : Item
	{
		public PillagersCloak() : base()
		{
			Id = 15559;
			Resistance[0] = 22;
			Bonding = 2;
			SellPrice = 1450;
			AvailableClasses = 0x7FFF;
			Model = 27072;
			ObjectClass = 4;
			SubClass = 1;
			Level = 31;
			ReqLevel = 26;
			Name = "Pillager's Cloak";
			Name2 = "Pillager's Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1007;
			BuyPrice = 7250;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Marauder's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class MaraudersCloak : Item
	{
		public MaraudersCloak() : base()
		{
			Id = 15568;
			Resistance[0] = 23;
			Bonding = 2;
			SellPrice = 1813;
			AvailableClasses = 0x7FFF;
			Model = 27062;
			ObjectClass = 4;
			SubClass = 1;
			Level = 33;
			ReqLevel = 28;
			Name = "Marauder's Cloak";
			Name2 = "Marauder's Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1007;
			BuyPrice = 9069;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Sparkleshell Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class SparkleshellCloak : Item
	{
		public SparkleshellCloak() : base()
		{
			Id = 15579;
			Resistance[0] = 23;
			Bonding = 2;
			SellPrice = 2122;
			AvailableClasses = 0x7FFF;
			Model = 25910;
			ObjectClass = 4;
			SubClass = 1;
			Level = 35;
			ReqLevel = 30;
			Name = "Sparkleshell Cloak";
			Name2 = "Sparkleshell Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1008;
			BuyPrice = 10614;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Steadfast Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class SteadfastCloak : Item
	{
		public SteadfastCloak() : base()
		{
			Id = 15594;
			Resistance[0] = 24;
			Bonding = 2;
			SellPrice = 2520;
			AvailableClasses = 0x7FFF;
			Model = 27108;
			ObjectClass = 4;
			SubClass = 1;
			Level = 37;
			ReqLevel = 32;
			Name = "Steadfast Cloak";
			Name2 = "Steadfast Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1009;
			BuyPrice = 12600;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Ancient Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class AncientCloak : Item
	{
		public AncientCloak() : base()
		{
			Id = 15603;
			Resistance[0] = 27;
			Bonding = 2;
			SellPrice = 3546;
			AvailableClasses = 0x7FFF;
			Model = 27082;
			ObjectClass = 4;
			SubClass = 1;
			Level = 41;
			ReqLevel = 36;
			Name = "Ancient Cloak";
			Name2 = "Ancient Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1010;
			BuyPrice = 17731;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Bonelink Cape)
*
***************************************************************/

namespace Server.Items
{
	public class BonelinkCape : Item
	{
		public BonelinkCape() : base()
		{
			Id = 15611;
			Resistance[0] = 28;
			Bonding = 2;
			SellPrice = 4369;
			AvailableClasses = 0x7FFF;
			Model = 27325;
			ObjectClass = 4;
			SubClass = 1;
			Level = 43;
			ReqLevel = 38;
			Name = "Bonelink Cape";
			Name2 = "Bonelink Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1011;
			BuyPrice = 21847;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Gryphon Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class GryphonCloak : Item
	{
		public GryphonCloak() : base()
		{
			Id = 15624;
			Resistance[0] = 30;
			Bonding = 2;
			SellPrice = 4971;
			AvailableClasses = 0x7FFF;
			Model = 28565;
			ObjectClass = 4;
			SubClass = 1;
			Level = 45;
			ReqLevel = 40;
			Name = "Gryphon Cloak";
			Name2 = "Gryphon Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1011;
			BuyPrice = 24855;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Formidable Cape)
*
***************************************************************/

namespace Server.Items
{
	public class FormidableCape : Item
	{
		public FormidableCape() : base()
		{
			Id = 15632;
			Resistance[0] = 30;
			Bonding = 2;
			SellPrice = 4997;
			AvailableClasses = 0x7FFF;
			Model = 27220;
			ObjectClass = 4;
			SubClass = 1;
			Level = 46;
			ReqLevel = 41;
			Name = "Formidable Cape";
			Name2 = "Formidable Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1012;
			BuyPrice = 24989;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Ironhide Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class IronhideCloak : Item
	{
		public IronhideCloak() : base()
		{
			Id = 15643;
			Resistance[0] = 32;
			Bonding = 2;
			SellPrice = 6675;
			AvailableClasses = 0x7FFF;
			Model = 27176;
			ObjectClass = 4;
			SubClass = 1;
			Level = 49;
			ReqLevel = 44;
			Name = "Ironhide Cloak";
			Name2 = "Ironhide Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1013;
			BuyPrice = 33379;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Merciless Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class MercilessCloak : Item
	{
		public MercilessCloak() : base()
		{
			Id = 15652;
			Resistance[0] = 33;
			Bonding = 2;
			SellPrice = 7139;
			AvailableClasses = 0x7FFF;
			Model = 27292;
			ObjectClass = 4;
			SubClass = 1;
			Level = 51;
			ReqLevel = 46;
			Name = "Merciless Cloak";
			Name2 = "Merciless Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1013;
			BuyPrice = 35699;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Impenetrable Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class ImpenetrableCloak : Item
	{
		public ImpenetrableCloak() : base()
		{
			Id = 15661;
			Resistance[0] = 35;
			Bonding = 2;
			SellPrice = 9036;
			AvailableClasses = 0x7FFF;
			Model = 27304;
			ObjectClass = 4;
			SubClass = 1;
			Level = 54;
			ReqLevel = 49;
			Name = "Impenetrable Cloak";
			Name2 = "Impenetrable Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1014;
			BuyPrice = 45180;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Magnificent Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class MagnificentCloak : Item
	{
		public MagnificentCloak() : base()
		{
			Id = 15671;
			Resistance[0] = 36;
			Bonding = 2;
			SellPrice = 9782;
			AvailableClasses = 0x7FFF;
			Model = 26141;
			ObjectClass = 4;
			SubClass = 1;
			Level = 56;
			ReqLevel = 51;
			Name = "Magnificent Cloak";
			Name2 = "Magnificent Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1015;
			BuyPrice = 48912;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Triumphant Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class TriumphantCloak : Item
	{
		public TriumphantCloak() : base()
		{
			Id = 15681;
			Resistance[0] = 38;
			Bonding = 2;
			SellPrice = 11406;
			AvailableClasses = 0x7FFF;
			Model = 26259;
			ObjectClass = 4;
			SubClass = 1;
			Level = 58;
			ReqLevel = 53;
			Name = "Triumphant Cloak";
			Name2 = "Triumphant Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1016;
			BuyPrice = 57033;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Chemist's Smock)
*
***************************************************************/

namespace Server.Items
{
	public class ChemistsSmock : Item
	{
		public ChemistsSmock() : base()
		{
			Id = 15703;
			Resistance[0] = 36;
			Bonding = 1;
			SellPrice = 9032;
			AvailableClasses = 0x7FFF;
			Model = 26431;
			ObjectClass = 4;
			SubClass = 1;
			Level = 55;
			Name = "Chemist's Smock";
			Name2 = "Chemist's Smock";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 45163;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			AgilityBonus = 3;
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Deep River Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class DeepRiverCloak : Item
	{
		public DeepRiverCloak() : base()
		{
			Id = 15789;
			Resistance[0] = 36;
			Bonding = 1;
			SellPrice = 9574;
			AvailableClasses = 0x7FFF;
			Model = 26468;
			ObjectClass = 4;
			SubClass = 1;
			Level = 56;
			Name = "Deep River Cloak";
			Name2 = "Deep River Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 47873;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 7;
			AgilityBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Cerise Drape)
*
***************************************************************/

namespace Server.Items
{
	public class CeriseDrape : Item
	{
		public CeriseDrape() : base()
		{
			Id = 15804;
			Resistance[0] = 36;
			Bonding = 1;
			SellPrice = 9574;
			AvailableClasses = 0x7FFF;
			Model = 25958;
			ObjectClass = 4;
			SubClass = 1;
			Level = 56;
			Name = "Cerise Drape";
			Name2 = "Cerise Drape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 47873;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			AgilityBonus = 6;
			SpiritBonus = 6;
			IqBonus = 6;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Hameya's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class HameyasCloak : Item
	{
		public HameyasCloak() : base()
		{
			Id = 15815;
			Resistance[6] = 15;
			Resistance[0] = 39;
			Bonding = 1;
			SellPrice = 11860;
			AvailableClasses = 0x7FFF;
			Model = 23042;
			ObjectClass = 4;
			SubClass = 1;
			Level = 60;
			Name = "Hameya's Cloak";
			Name2 = "Hameya's Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 59304;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Sergeant Major's Cape)
*
***************************************************************/

namespace Server.Items
{
	public class SergeantMajorsCape : Item
	{
		public SergeantMajorsCape() : base()
		{
			Id = 16315;
			Resistance[0] = 24;
			Bonding = 1;
			SellPrice = 805;
			AvailableClasses = 0x7FFF;
			Model = 27087;
			ObjectClass = 4;
			SubClass = 1;
			Level = 30;
			ReqLevel = 25;
			Name = "Sergeant Major's Cape";
			Name2 = "Sergeant Major's Cape";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 4029;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Flags = 32768;
			SpiritBonus = 4;
			StaminaBonus = 4;
			IqBonus = 4;
			StrBonus = 4;
			AgilityBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Sergeant Major's Cape)
*
***************************************************************/

namespace Server.Items
{
	public class SergeantMajorsCape16336 : Item
	{
		public SergeantMajorsCape16336() : base()
		{
			Id = 16336;
			Resistance[0] = 32;
			Bonding = 1;
			SellPrice = 2917;
			AvailableClasses = 0x7FFF;
			Model = 27087;
			ObjectClass = 4;
			SubClass = 1;
			Level = 45;
			ReqLevel = 40;
			Name = "Sergeant Major's Cape";
			Name2 = "Sergeant Major's Cape";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 14587;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Flags = 32768;
			SpiritBonus = 6;
			StaminaBonus = 6;
			IqBonus = 6;
			StrBonus = 6;
			AgilityBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Sergeant Major's Cape)
*
***************************************************************/

namespace Server.Items
{
	public class SergeantMajorsCape16337 : Item
	{
		public SergeantMajorsCape16337() : base()
		{
			Id = 16337;
			Resistance[0] = 43;
			Bonding = 1;
			SellPrice = 7491;
			AvailableClasses = 0x7FFF;
			Model = 27087;
			ObjectClass = 4;
			SubClass = 1;
			Level = 60;
			ReqLevel = 55;
			Name = "Sergeant Major's Cape";
			Name2 = "Sergeant Major's Cape";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 37455;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Flags = 32768;
			SpiritBonus = 8;
			StaminaBonus = 8;
			IqBonus = 8;
			StrBonus = 8;
			AgilityBonus = 8;
		}
	}
}


/**************************************************************
*
*				(First Sergeant's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class FirstSergeantsCloak : Item
	{
		public FirstSergeantsCloak() : base()
		{
			Id = 16340;
			Resistance[0] = 32;
			Bonding = 1;
			SellPrice = 2960;
			AvailableClasses = 0x7FFF;
			Model = 27088;
			ObjectClass = 4;
			SubClass = 1;
			Level = 45;
			ReqLevel = 40;
			Name = "First Sergeant's Cloak";
			Name2 = "First Sergeant's Cloak";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 14802;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Flags = 32768;
			SpiritBonus = 6;
			StaminaBonus = 6;
			IqBonus = 6;
			StrBonus = 6;
			AgilityBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Sergeant's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class SergeantsCloak : Item
	{
		public SergeantsCloak() : base()
		{
			Id = 16341;
			Resistance[0] = 96;
			Bonding = 1;
			SellPrice = 4285;
			AvailableClasses = 0x7FFF;
			Model = 27088;
			ObjectClass = 4;
			SubClass = 1;
			Level = 50;
			ReqLevel = 45;
			Name = "Sergeant's Cloak";
			Name2 = "Sergeant's Cloak";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 21425;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Flags = 32768;
			StaminaBonus = 14;
		}
	}
}


/**************************************************************
*
*				(Sergeant's Cape)
*
***************************************************************/

namespace Server.Items
{
	public class SergeantsCape : Item
	{
		public SergeantsCape() : base()
		{
			Id = 16342;
			Resistance[0] = 115;
			Bonding = 1;
			SellPrice = 8830;
			AvailableClasses = 0x7FFF;
			Model = 27087;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Sergeant's Cape";
			Name2 = "Sergeant's Cape";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 44154;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Flags = 32768;
			StaminaBonus = 17;
		}
	}
}


/**************************************************************
*
*				(Wildhunter Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class WildhunterCloak : Item
	{
		public WildhunterCloak() : base()
		{
			Id = 16658;
			Resistance[0] = 22;
			Bonding = 1;
			SellPrice = 1649;
			AvailableClasses = 0x7FFF;
			Model = 27514;
			ObjectClass = 4;
			SubClass = 1;
			Level = 32;
			Name = "Wildhunter Cloak";
			Name2 = "Wildhunter Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 8246;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			SetSpell( 19691 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Soft Willow Cape)
*
***************************************************************/

namespace Server.Items
{
	public class SoftWillowCape : Item
	{
		public SoftWillowCape() : base()
		{
			Id = 16661;
			Resistance[0] = 20;
			Bonding = 1;
			SellPrice = 965;
			AvailableClasses = 0x7FFF;
			Model = 27521;
			ObjectClass = 4;
			SubClass = 1;
			Level = 27;
			Name = "Soft Willow Cape";
			Name2 = "Soft Willow Cape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4828;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			SpiritBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Spritekin Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class SpritekinCloak : Item
	{
		public SpritekinCloak() : base()
		{
			Id = 16990;
			Resistance[0] = 20;
			Bonding = 1;
			SellPrice = 998;
			AvailableClasses = 0x7FFF;
			Model = 28775;
			ObjectClass = 4;
			SubClass = 1;
			Level = 27;
			Name = "Spritekin Cloak";
			Name2 = "Spritekin Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4990;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			AgilityBonus = 4;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Sapphiron Drape)
*
***************************************************************/

namespace Server.Items
{
	public class SapphironDrape : Item
	{
		public SapphironDrape() : base()
		{
			Id = 17078;
			Resistance[6] = 6;
			Resistance[0] = 55;
			Bonding = 1;
			SellPrice = 37203;
			AvailableClasses = 0x7FFF;
			Model = 29719;
			Resistance[4] = 6;
			ObjectClass = 4;
			SubClass = 1;
			Level = 72;
			ReqLevel = 60;
			Name = "Sapphiron Drape";
			Name2 = "Sapphiron Drape";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 186019;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			SetSpell( 9343 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 17;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Cloak of the Shrouded Mists)
*
***************************************************************/

namespace Server.Items
{
	public class CloakOfTheShroudedMists : Item
	{
		public CloakOfTheShroudedMists() : base()
		{
			Id = 17102;
			Resistance[0] = 57;
			Bonding = 1;
			SellPrice = 38689;
			AvailableClasses = 0x7FFF;
			Model = 29824;
			Resistance[2] = 6;
			ObjectClass = 4;
			SubClass = 1;
			Level = 74;
			ReqLevel = 60;
			Name = "Cloak of the Shrouded Mists";
			Name2 = "Cloak of the Shrouded Mists";
			Resistance[3] = 6;
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 193445;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			AgilityBonus = 22;
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Dragon's Blood Cape)
*
***************************************************************/

namespace Server.Items
{
	public class DragonsBloodCape : Item
	{
		public DragonsBloodCape() : base()
		{
			Id = 17107;
			Resistance[6] = 5;
			Resistance[0] = 116;
			Bonding = 1;
			SellPrice = 37537;
			AvailableClasses = 0x7FFF;
			Model = 29827;
			Resistance[2] = 5;
			ObjectClass = 4;
			SubClass = 1;
			Level = 73;
			ReqLevel = 60;
			Name = "Dragon's Blood Cape";
			Name2 = "Dragon's Blood Cape";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 187685;
			Resistance[5] = 5;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 22;
			StrBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Smokey's Drape)
*
***************************************************************/

namespace Server.Items
{
	public class SmokeysDrape : Item
	{
		public SmokeysDrape() : base()
		{
			Id = 17523;
			Resistance[0] = 38;
			Bonding = 1;
			SellPrice = 10758;
			AvailableClasses = 0x7FFF;
			Model = 29630;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 1;
			Level = 58;
			Name = "Smokey's Drape";
			Name2 = "Smokey's Drape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 53790;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Grovekeeper's Drape)
*
***************************************************************/

namespace Server.Items
{
	public class GrovekeepersDrape : Item
	{
		public GrovekeepersDrape() : base()
		{
			Id = 17739;
			Resistance[0] = 37;
			Bonding = 1;
			SellPrice = 9100;
			AvailableClasses = 0x7FFF;
			Model = 29916;
			ObjectClass = 4;
			SubClass = 1;
			Level = 52;
			ReqLevel = 47;
			Name = "Grovekeeper's Drape";
			Name2 = "Grovekeeper's Drape";
			Resistance[3] = 10;
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 45504;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Eskhandar's Pelt)
*
***************************************************************/

namespace Server.Items
{
	public class EskhandarsPelt : Item
	{
		public EskhandarsPelt() : base()
		{
			Id = 18204;
			Resistance[0] = 51;
			Bonding = 1;
			SellPrice = 27370;
			AvailableClasses = 0x7FFF;
			Model = 30577;
			ObjectClass = 4;
			SubClass = 1;
			Level = 66;
			ReqLevel = 60;
			Name = "Eskhandar's Pelt";
			Name2 = "Eskhandar's Pelt";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 136851;
			Sets = 261;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 20;
		}
	}
}


/**************************************************************
*
*				(Drape of Benediction)
*
***************************************************************/

namespace Server.Items
{
	public class DrapeOfBenediction : Item
	{
		public DrapeOfBenediction() : base()
		{
			Id = 18208;
			Resistance[0] = 52;
			Bonding = 1;
			SellPrice = 29147;
			AvailableClasses = 0x7FFF;
			Model = 15273;
			ObjectClass = 4;
			SubClass = 1;
			Level = 67;
			ReqLevel = 60;
			Name = "Drape of Benediction";
			Name2 = "Drape of Benediction";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 145737;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			SetSpell( 9408 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 10;
			StaminaBonus = 9;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Shadewood Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class ShadewoodCloak : Item
	{
		public ShadewoodCloak() : base()
		{
			Id = 18328;
			Resistance[0] = 42;
			Bonding = 1;
			SellPrice = 14116;
			AvailableClasses = 0x7FFF;
			Model = 30689;
			ObjectClass = 4;
			SubClass = 1;
			Level = 59;
			ReqLevel = 54;
			Name = "Shadewood Cloak";
			Name2 = "Shadewood Cloak";
			Resistance[3] = 7;
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 70583;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StrBonus = 13;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Eidolon Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class EidolonCloak : Item
	{
		public EidolonCloak() : base()
		{
			Id = 18339;
			Resistance[0] = 38;
			Bonding = 1;
			SellPrice = 11370;
			AvailableClasses = 0x7FFF;
			Model = 30703;
			ObjectClass = 4;
			SubClass = 1;
			Level = 59;
			ReqLevel = 54;
			Name = "Eidolon Cloak";
			Name2 = "Eidolon Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 56853;
			Resistance[5] = 12;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Amplifying Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class AmplifyingCloak : Item
	{
		public AmplifyingCloak() : base()
		{
			Id = 18350;
			Resistance[0] = 39;
			Bonding = 1;
			SellPrice = 13063;
			AvailableClasses = 0x7FFF;
			Model = 15217;
			ObjectClass = 4;
			SubClass = 1;
			Level = 61;
			ReqLevel = 56;
			Name = "Amplifying Cloak";
			Name2 = "Amplifying Cloak";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 65319;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			SetSpell( 9346 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Fluctuating Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class FluctuatingCloak : Item
	{
		public FluctuatingCloak() : base()
		{
			Id = 18382;
			Resistance[0] = 44;
			Bonding = 1;
			SellPrice = 15971;
			AvailableClasses = 0x7FFF;
			Model = 30739;
			ObjectClass = 4;
			SubClass = 1;
			Level = 62;
			ReqLevel = 57;
			Name = "Fluctuating Cloak";
			Name2 = "Fluctuating Cloak";
			Quality = 3;
			AvailableRaces = 0x1FF;
			Extra = 3458;
			BuyPrice = 79858;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			SetSpell( 21347 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Cloak of the Cosmos)
*
***************************************************************/

namespace Server.Items
{
	public class CloakOfTheCosmos : Item
	{
		public CloakOfTheCosmos() : base()
		{
			Id = 18389;
			Resistance[0] = 44;
			Bonding = 1;
			SellPrice = 16830;
			AvailableClasses = 0x7FFF;
			Model = 15247;
			ObjectClass = 4;
			SubClass = 1;
			Level = 62;
			ReqLevel = 57;
			Name = "Cloak of the Cosmos";
			Name2 = "Cloak of the Cosmos";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 84152;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			SetSpell( 9315 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 11;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Cloak of Warding)
*
***************************************************************/

namespace Server.Items
{
	public class CloakOfWarding : Item
	{
		public CloakOfWarding() : base()
		{
			Id = 18413;
			Resistance[0] = 214;
			Bonding = 2;
			SellPrice = 17070;
			AvailableClasses = 0x7FFF;
			Model = 30783;
			ObjectClass = 4;
			SubClass = 1;
			Level = 62;
			ReqLevel = 57;
			Name = "Cloak of Warding";
			Name2 = "Cloak of Warding";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 85353;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			SetSpell( 7518 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Sergeant's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class SergeantsCloak18427 : Item
	{
		public SergeantsCloak18427() : base()
		{
			Id = 18427;
			Resistance[0] = 66;
			Bonding = 1;
			SellPrice = 1322;
			AvailableClasses = 0x7FFF;
			Model = 27088;
			ObjectClass = 4;
			SubClass = 1;
			Level = 35;
			ReqLevel = 30;
			Name = "Sergeant's Cloak";
			Name2 = "Sergeant's Cloak";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 6611;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Flags = 32768;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Sergeant's Cape)
*
***************************************************************/

namespace Server.Items
{
	public class SergeantsCape18440 : Item
	{
		public SergeantsCape18440() : base()
		{
			Id = 18440;
			Resistance[0] = 66;
			Bonding = 1;
			SellPrice = 1288;
			AvailableClasses = 0x7FFF;
			Model = 27087;
			ObjectClass = 4;
			SubClass = 1;
			Level = 35;
			ReqLevel = 30;
			Name = "Sergeant's Cape";
			Name2 = "Sergeant's Cape";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 6443;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Flags = 32768;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Sergeant's Cape)
*
***************************************************************/

namespace Server.Items
{
	public class SergeantsCape18441 : Item
	{
		public SergeantsCape18441() : base()
		{
			Id = 18441;
			Resistance[0] = 96;
			Bonding = 1;
			SellPrice = 4178;
			AvailableClasses = 0x7FFF;
			Model = 27087;
			ObjectClass = 4;
			SubClass = 1;
			Level = 50;
			ReqLevel = 45;
			Name = "Sergeant's Cape";
			Name2 = "Sergeant's Cape";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 20891;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Flags = 32768;
			StaminaBonus = 14;
		}
	}
}


/**************************************************************
*
*				(Sergeant's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class SergeantsCloak18461 : Item
	{
		public SergeantsCloak18461() : base()
		{
			Id = 18461;
			Resistance[0] = 115;
			Bonding = 1;
			SellPrice = 8577;
			AvailableClasses = 0x7FFF;
			Model = 27088;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Sergeant's Cloak";
			Name2 = "Sergeant's Cloak";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 42888;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Flags = 32768;
			StaminaBonus = 17;
		}
	}
}


/**************************************************************
*
*				(Redoubt Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class RedoubtCloak : Item
	{
		public RedoubtCloak() : base()
		{
			Id = 18495;
			Resistance[0] = 45;
			Bonding = 1;
			SellPrice = 16770;
			AvailableClasses = 0x7FFF;
			Model = 30831;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Redoubt Cloak";
			Name2 = "Redoubt Cloak";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 83851;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			SetSpell( 13385 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Heliotrope Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class HeliotropeCloak : Item
	{
		public HeliotropeCloak() : base()
		{
			Id = 18496;
			Resistance[0] = 43;
			Bonding = 1;
			SellPrice = 14233;
			AvailableClasses = 0x7FFF;
			Model = 30832;
			ObjectClass = 4;
			SubClass = 1;
			Level = 60;
			ReqLevel = 55;
			Name = "Heliotrope Cloak";
			Name2 = "Heliotrope Cloak";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 71165;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			SetSpell( 18384 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Chromatic Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class ChromaticCloak : Item
	{
		public ChromaticCloak() : base()
		{
			Id = 18509;
			Resistance[0] = 48;
			Bonding = 2;
			SellPrice = 23006;
			AvailableClasses = 0x7FFF;
			Model = 30849;
			Resistance[2] = 9;
			ObjectClass = 4;
			SubClass = 1;
			Level = 62;
			ReqLevel = 57;
			Name = "Chromatic Cloak";
			Name2 = "Chromatic Cloak";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 115033;
			Resistance[5] = 9;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			SetSpell( 18384 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Hide of the Wild)
*
***************************************************************/

namespace Server.Items
{
	public class HideOfTheWild : Item
	{
		public HideOfTheWild() : base()
		{
			Id = 18510;
			Resistance[0] = 48;
			Bonding = 2;
			SellPrice = 20889;
			AvailableClasses = 0x7FFF;
			Model = 30850;
			ObjectClass = 4;
			SubClass = 1;
			Level = 62;
			ReqLevel = 57;
			Name = "Hide of the Wild";
			Name2 = "Hide of the Wild";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 104449;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			SetSpell( 18032 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 10;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Shifting Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class ShiftingCloak : Item
	{
		public ShiftingCloak() : base()
		{
			Id = 18511;
			Resistance[0] = 48;
			Bonding = 2;
			SellPrice = 20971;
			AvailableClasses = 0x7FFF;
			Model = 30851;
			ObjectClass = 4;
			SubClass = 1;
			Level = 62;
			ReqLevel = 57;
			Name = "Shifting Cloak";
			Name2 = "Shifting Cloak";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 104855;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			SetSpell( 13669 , 1 , 0 , -1 , 0 , -1 );
			AgilityBonus = 17;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Puissant Cape)
*
***************************************************************/

namespace Server.Items
{
	public class PuissantCape : Item
	{
		public PuissantCape() : base()
		{
			Id = 18541;
			Resistance[0] = 54;
			Bonding = 1;
			SellPrice = 33028;
			AvailableClasses = 0x7FFF;
			Model = 30882;
			ObjectClass = 4;
			SubClass = 1;
			Level = 70;
			ReqLevel = 60;
			Name = "Puissant Cape";
			Name2 = "Puissant Cape";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 165144;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			SetSpell( 14049 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 15464 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Zephyr Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class ZephyrCloak : Item
	{
		public ZephyrCloak() : base()
		{
			Id = 18677;
			Resistance[0] = 39;
			Bonding = 2;
			SellPrice = 12487;
			AvailableClasses = 0x7FFF;
			Model = 15148;
			ObjectClass = 4;
			SubClass = 1;
			Level = 61;
			ReqLevel = 56;
			Name = "Zephyr Cloak";
			Name2 = "Zephyr Cloak";
			Resistance[3] = 15;
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 62439;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Phantasmal Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class PhantasmalCloak : Item
	{
		public PhantasmalCloak() : base()
		{
			Id = 18689;
			Resistance[0] = 114;
			Bonding = 1;
			SellPrice = 16460;
			AvailableClasses = 0x7FFF;
			Model = 31131;
			ObjectClass = 4;
			SubClass = 1;
			Level = 62;
			ReqLevel = 57;
			Name = "Phantasmal Cloak";
			Name2 = "Phantasmal Cloak";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 82301;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StrBonus = 12;
			StaminaBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Pale Moon Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class PaleMoonCloak : Item
	{
		public PaleMoonCloak() : base()
		{
			Id = 18734;
			Resistance[0] = 44;
			Bonding = 1;
			SellPrice = 17194;
			AvailableClasses = 0x7FFF;
			Model = 31351;
			ObjectClass = 4;
			SubClass = 1;
			Level = 62;
			ReqLevel = 57;
			Name = "Pale Moon Cloak";
			Name2 = "Pale Moon Cloak";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 85970;
			Resistance[5] = 10;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StrBonus = 8;
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Gracious Cape)
*
***************************************************************/

namespace Server.Items
{
	public class GraciousCape : Item
	{
		public GraciousCape() : base()
		{
			Id = 18743;
			Resistance[0] = 42;
			Bonding = 1;
			SellPrice = 13555;
			AvailableClasses = 0x7FFF;
			Model = 15163;
			ObjectClass = 4;
			SubClass = 1;
			Level = 59;
			ReqLevel = 54;
			Name = "Gracious Cape";
			Name2 = "Gracious Cape";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 67777;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			SetSpell( 21627 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Fireproof Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class FireproofCloak : Item
	{
		public FireproofCloak() : base()
		{
			Id = 18811;
			Resistance[0] = 54;
			Bonding = 1;
			SellPrice = 32665;
			AvailableClasses = 0x7FFF;
			Model = 24159;
			Resistance[2] = 18;
			ObjectClass = 4;
			SubClass = 1;
			Level = 71;
			ReqLevel = 60;
			Name = "Fireproof Cloak";
			Name2 = "Fireproof Cloak";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 163328;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			StaminaBonus = 12;
			SpiritBonus = 9;
			IqBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Frostwolf Legionnaire's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class FrostwolfLegionnairesCloak : Item
	{
		public FrostwolfLegionnairesCloak() : base()
		{
			Id = 19083;
			Resistance[0] = 43;
			Bonding = 1;
			SellPrice = 15044;
			AvailableClasses = 0x7FFF;
			Model = 26468;
			Resistance[4] = 5;
			ObjectClass = 4;
			SubClass = 1;
			Level = 60;
			ReqLevel = 55;
			Name = "Frostwolf Legionnaire's Cloak";
			Name2 = "Frostwolf Legionnaire's Cloak";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 75224;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			Flags = 32768;
			SetSpell( 14027 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Stormpike Soldier's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class StormpikeSoldiersCloak : Item
	{
		public StormpikeSoldiersCloak() : base()
		{
			Id = 19084;
			Resistance[0] = 43;
			Bonding = 1;
			SellPrice = 15100;
			AvailableClasses = 0x7FFF;
			Model = 27197;
			Resistance[4] = 5;
			ObjectClass = 4;
			SubClass = 1;
			Level = 60;
			ReqLevel = 55;
			Name = "Stormpike Soldier's Cloak";
			Name2 = "Stormpike Soldier's Cloak";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 75500;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			Flags = 32768;
			SetSpell( 14027 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Frostwolf Advisor's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class FrostwolfAdvisorsCloak : Item
	{
		public FrostwolfAdvisorsCloak() : base()
		{
			Id = 19085;
			Resistance[0] = 43;
			Bonding = 1;
			SellPrice = 15155;
			AvailableClasses = 0x7FFF;
			Model = 31592;
			Resistance[4] = 5;
			ObjectClass = 4;
			SubClass = 1;
			Level = 60;
			ReqLevel = 55;
			Name = "Frostwolf Advisor's Cloak";
			Name2 = "Frostwolf Advisor's Cloak";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 75776;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			Flags = 32768;
			SetSpell( 9343 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Stormpike Sage's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class StormpikeSagesCloak : Item
	{
		public StormpikeSagesCloak() : base()
		{
			Id = 19086;
			Resistance[0] = 43;
			Bonding = 1;
			SellPrice = 15209;
			AvailableClasses = 0x7FFF;
			Model = 15042;
			Resistance[4] = 5;
			ObjectClass = 4;
			SubClass = 1;
			Level = 60;
			ReqLevel = 55;
			Name = "Stormpike Sage's Cloak";
			Name2 = "Stormpike Sage's Cloak";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 76045;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			Flags = 32768;
			SetSpell( 9343 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Deep Woodlands Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class DeepWoodlandsCloak : Item
	{
		public DeepWoodlandsCloak() : base()
		{
			Id = 19121;
			Resistance[0] = 37;
			Bonding = 1;
			SellPrice = 8585;
			AvailableClasses = 0x7FFF;
			Model = 31632;
			ObjectClass = 4;
			SubClass = 1;
			Level = 51;
			Name = "Deep Woodlands Cloak";
			Name2 = "Deep Woodlands Cloak";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 42929;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			SetSpell( 9417 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 9;
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Cloak of Firemaw)
*
***************************************************************/

namespace Server.Items
{
	public class CloakOfFiremaw : Item
	{
		public CloakOfFiremaw() : base()
		{
			Id = 19398;
			Resistance[0] = 57;
			Bonding = 1;
			SellPrice = 40003;
			AvailableClasses = 0x7FFF;
			Model = 23422;
			ObjectClass = 4;
			SubClass = 1;
			Level = 75;
			ReqLevel = 60;
			Name = "Cloak of Firemaw";
			Name2 = "Cloak of Firemaw";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 200015;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			SetSpell( 14056 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Shroud of Pure Thought)
*
***************************************************************/

namespace Server.Items
{
	public class ShroudOfPureThought : Item
	{
		public ShroudOfPureThought() : base()
		{
			Id = 19430;
			Resistance[0] = 57;
			Bonding = 1;
			SellPrice = 42919;
			AvailableClasses = 0x7FFF;
			Model = 16879;
			ObjectClass = 4;
			SubClass = 1;
			Level = 75;
			ReqLevel = 60;
			Name = "Shroud of Pure Thought";
			Name2 = "Shroud of Pure Thought";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 214596;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			SetSpell( 9318 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 21626 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 11;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Cloak of Draconic Might)
*
***************************************************************/

namespace Server.Items
{
	public class CloakOfDraconicMight : Item
	{
		public CloakOfDraconicMight() : base()
		{
			Id = 19436;
			Resistance[0] = 54;
			Bonding = 1;
			SellPrice = 31956;
			AvailableClasses = 0x7FFF;
			Model = 31978;
			ObjectClass = 4;
			SubClass = 1;
			Level = 70;
			ReqLevel = 60;
			Name = "Cloak of Draconic Might";
			Name2 = "Cloak of Draconic Might";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 159780;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			Material = 7;
			AgilityBonus = 16;
			StrBonus = 16;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Battle Healer's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class BattleHealersCloak : Item
	{
		public BattleHealersCloak() : base()
		{
			Id = 19526;
			Resistance[0] = 45;
			Bonding = 1;
			SellPrice = 18116;
			AvailableClasses = 0x7FFF;
			Model = 32066;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Battle Healer's Cloak";
			Name2 = "Battle Healer's Cloak";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 90580;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Flags = 32768;
			SetSpell( 9315 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 11;
			IqBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Battle Healer's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class BattleHealersCloak19527 : Item
	{
		public BattleHealersCloak19527() : base()
		{
			Id = 19527;
			Resistance[0] = 38;
			Bonding = 1;
			SellPrice = 9631;
			AvailableClasses = 0x7FFF;
			Model = 32069;
			ObjectClass = 4;
			SubClass = 1;
			Level = 53;
			ReqLevel = 48;
			Name = "Battle Healer's Cloak";
			Name2 = "Battle Healer's Cloak";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 48159;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Flags = 32768;
			SetSpell( 9408 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 9;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Battle Healer's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class BattleHealersCloak19528 : Item
	{
		public BattleHealersCloak19528() : base()
		{
			Id = 19528;
			Resistance[0] = 31;
			Bonding = 1;
			SellPrice = 4780;
			AvailableClasses = 0x7FFF;
			Model = 32070;
			ObjectClass = 4;
			SubClass = 1;
			Level = 43;
			ReqLevel = 38;
			Name = "Battle Healer's Cloak";
			Name2 = "Battle Healer's Cloak";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 23904;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Flags = 32768;
			SetSpell( 9406 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 8;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Battle Healer's Cloak)
*
***************************************************************/

namespace Server.Items
{
	public class BattleHealersCloak19529 : Item
	{
		public BattleHealersCloak19529() : base()
		{
			Id = 19529;
			Resistance[0] = 25;
			Bonding = 1;
			SellPrice = 2122;
			AvailableClasses = 0x7FFF;
			Model = 28042;
			ObjectClass = 4;
			SubClass = 1;
			Level = 33;
			ReqLevel = 28;
			Name = "Battle Healer's Cloak";
			Name2 = "Battle Healer's Cloak";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 10613;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Flags = 32768;
			SetSpell( 7680 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 6;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Caretaker's Cape)
*
***************************************************************/

namespace Server.Items
{
	public class CaretakersCape : Item
	{
		public CaretakersCape() : base()
		{
			Id = 19530;
			Resistance[0] = 45;
			Bonding = 1;
			SellPrice = 17098;
			AvailableClasses = 0x7FFF;
			Model = 32067;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Caretaker's Cape";
			Name2 = "Caretaker's Cape";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 85492;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Flags = 32768;
			SetSpell( 9315 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 11;
			IqBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Caretaker's Cape)
*
***************************************************************/

namespace Server.Items
{
	public class CaretakersCape19531 : Item
	{
		public CaretakersCape19531() : base()
		{
			Id = 19531;
			Resistance[0] = 38;
			Bonding = 1;
			SellPrice = 10048;
			AvailableClasses = 0x7FFF;
			Model = 32068;
			ObjectClass = 4;
			SubClass = 1;
			Level = 53;
			ReqLevel = 48;
			Name = "Caretaker's Cape";
			Name2 = "Caretaker's Cape";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 50242;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Flags = 32768;
			SetSpell( 9408 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 9;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Caretaker's Cape)
*
***************************************************************/

namespace Server.Items
{
	public class CaretakersCape19532 : Item
	{
		public CaretakersCape19532() : base()
		{
			Id = 19532;
			Resistance[0] = 31;
			Bonding = 1;
			SellPrice = 4986;
			AvailableClasses = 0x7FFF;
			Model = 32071;
			ObjectClass = 4;
			SubClass = 1;
			Level = 43;
			ReqLevel = 38;
			Name = "Caretaker's Cape";
			Name2 = "Caretaker's Cape";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 24934;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Flags = 32768;
			SetSpell( 9406 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 8;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Caretaker's Cape)
*
***************************************************************/

namespace Server.Items
{
	public class CaretakersCape19533 : Item
	{
		public CaretakersCape19533() : base()
		{
			Id = 19533;
			Resistance[0] = 25;
			Bonding = 1;
			SellPrice = 2154;
			AvailableClasses = 0x7FFF;
			Model = 32072;
			ObjectClass = 4;
			SubClass = 1;
			Level = 33;
			ReqLevel = 28;
			Name = "Caretaker's Cape";
			Name2 = "Caretaker's Cape";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 10772;
			InventoryType = InventoryTypes.Back;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Flags = 32768;
			SetSpell( 7680 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 6;
			IqBonus = 4;
		}
	}
}


