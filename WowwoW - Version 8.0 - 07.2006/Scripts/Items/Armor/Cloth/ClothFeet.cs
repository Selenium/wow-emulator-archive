/**************************************************************
*
*		Made by fulgas (fulgas@gmail.com)
*
*  WowwoW Item Designer ( 2005/8/23 - 10:05:17 )
*
***************************************************************/

using System;
using System.Collections;

/***************************************************************/

/**************************************************************
*
*				(Soft Fur-lined Shoes)
*
***************************************************************/

namespace Server.Items
{
	public class SoftFurLinedShoes : Item
	{
		public SoftFurLinedShoes() : base()
		{
			Id = 80;
			Resistance[0] = 7;
			Bonding = 1;
			SellPrice = 7;
			AvailableClasses = 0x7FFF;
			Model = 16854;
			ObjectClass = 4;
			SubClass = 1;
			Level = 5;
			Name = "Soft Fur-lined Shoes";
			Name2 = "Soft Fur-lined Shoes";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 35;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Tattered Cloth Boots)
*
***************************************************************/

namespace Server.Items
{
	public class TatteredClothBoots : Item
	{
		public TatteredClothBoots() : base()
		{
			Id = 195;
			Resistance[0] = 7;
			SellPrice = 7;
			AvailableClasses = 0x7FFF;
			Model = 16582;
			ObjectClass = 4;
			SubClass = 1;
			Level = 5;
			ReqLevel = 1;
			Name = "Tattered Cloth Boots";
			Name2 = "Tattered Cloth Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 36;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Thick Cloth Shoes)
*
***************************************************************/

namespace Server.Items
{
	public class ThickClothShoes : Item
	{
		public ThickClothShoes() : base()
		{
			Id = 202;
			Resistance[0] = 24;
			SellPrice = 342;
			AvailableClasses = 0x7FFF;
			Model = 16780;
			ObjectClass = 4;
			SubClass = 1;
			Level = 22;
			ReqLevel = 17;
			Name = "Thick Cloth Shoes";
			Name2 = "Thick Cloth Shoes";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1714;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Knitted Sandals)
*
***************************************************************/

namespace Server.Items
{
	public class KnittedSandals : Item
	{
		public KnittedSandals() : base()
		{
			Id = 792;
			Resistance[0] = 13;
			SellPrice = 41;
			AvailableClasses = 0x7FFF;
			Model = 16855;
			ObjectClass = 4;
			SubClass = 1;
			Level = 10;
			ReqLevel = 5;
			Name = "Knitted Sandals";
			Name2 = "Knitted Sandals";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 207;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Heavy Weave Shoes)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyWeaveShoes : Item
	{
		public HeavyWeaveShoes() : base()
		{
			Id = 840;
			Resistance[0] = 20;
			SellPrice = 170;
			AvailableClasses = 0x7FFF;
			Model = 16821;
			ObjectClass = 4;
			SubClass = 1;
			Level = 17;
			ReqLevel = 12;
			Name = "Heavy Weave Shoes";
			Name2 = "Heavy Weave Shoes";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 853;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Cavalier's Boots)
*
***************************************************************/

namespace Server.Items
{
	public class CavaliersBoots : Item
	{
		public CavaliersBoots() : base()
		{
			Id = 860;
			Resistance[0] = 16;
			Bonding = 1;
			SellPrice = 89;
			AvailableClasses = 0x7FFF;
			Model = 3443;
			ObjectClass = 4;
			SubClass = 1;
			Level = 13;
			Name = "Cavalier's Boots";
			Name2 = "Cavalier's Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 447;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Frayed Shoes)
*
***************************************************************/

namespace Server.Items
{
	public class FrayedShoes : Item
	{
		public FrayedShoes() : base()
		{
			Id = 1374;
			Resistance[0] = 5;
			SellPrice = 3;
			AvailableClasses = 0x7FFF;
			Model = 16659;
			ObjectClass = 4;
			SubClass = 1;
			Level = 4;
			ReqLevel = 1;
			Name = "Frayed Shoes";
			Name2 = "Frayed Shoes";
			AvailableRaces = 0x1FF;
			BuyPrice = 16;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 18;
		}
	}
}


/**************************************************************
*
*				(Patchwork Shoes)
*
***************************************************************/

namespace Server.Items
{
	public class PatchworkShoes : Item
	{
		public PatchworkShoes() : base()
		{
			Id = 1427;
			Resistance[0] = 12;
			SellPrice = 29;
			AvailableClasses = 0x7FFF;
			Model = 16798;
			ObjectClass = 4;
			SubClass = 1;
			Level = 10;
			ReqLevel = 5;
			Name = "Patchwork Shoes";
			Name2 = "Patchwork Shoes";
			AvailableRaces = 0x1FF;
			BuyPrice = 147;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Calico Shoes)
*
***************************************************************/

namespace Server.Items
{
	public class CalicoShoes : Item
	{
		public CalicoShoes() : base()
		{
			Id = 1495;
			Resistance[0] = 15;
			SellPrice = 58;
			AvailableClasses = 0x7FFF;
			Model = 16553;
			ObjectClass = 4;
			SubClass = 1;
			Level = 13;
			ReqLevel = 8;
			Name = "Calico Shoes";
			Name2 = "Calico Shoes";
			AvailableRaces = 0x1FF;
			BuyPrice = 294;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Bluegill Sandals)
*
***************************************************************/

namespace Server.Items
{
	public class BluegillSandals : Item
	{
		public BluegillSandals() : base()
		{
			Id = 1560;
			Resistance[0] = 24;
			Bonding = 2;
			SellPrice = 513;
			AvailableClasses = 0x7FFF;
			Model = 16856;
			ObjectClass = 4;
			SubClass = 1;
			Level = 21;
			ReqLevel = 16;
			Name = "Bluegill Sandals";
			Name2 = "Bluegill Sandals";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2568;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 30;
			IqBonus = 4;
			SpiritBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Canvas Shoes)
*
***************************************************************/

namespace Server.Items
{
	public class CanvasShoes : Item
	{
		public CanvasShoes() : base()
		{
			Id = 1764;
			Resistance[0] = 19;
			SellPrice = 113;
			AvailableClasses = 0x7FFF;
			Model = 7578;
			ObjectClass = 4;
			SubClass = 1;
			Level = 17;
			ReqLevel = 12;
			Name = "Canvas Shoes";
			Name2 = "Canvas Shoes";
			AvailableRaces = 0x1FF;
			BuyPrice = 568;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Brocade Shoes)
*
***************************************************************/

namespace Server.Items
{
	public class BrocadeShoes : Item
	{
		public BrocadeShoes() : base()
		{
			Id = 1772;
			Resistance[0] = 23;
			SellPrice = 247;
			AvailableClasses = 0x7FFF;
			Model = 3757;
			ObjectClass = 4;
			SubClass = 1;
			Level = 23;
			ReqLevel = 18;
			Name = "Brocade Shoes";
			Name2 = "Brocade Shoes";
			AvailableRaces = 0x1FF;
			BuyPrice = 1235;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Cross-stitched Sandals)
*
***************************************************************/

namespace Server.Items
{
	public class CrossStitchedSandals : Item
	{
		public CrossStitchedSandals() : base()
		{
			Id = 1780;
			Resistance[0] = 26;
			SellPrice = 489;
			AvailableClasses = 0x7FFF;
			Model = 16820;
			ObjectClass = 4;
			SubClass = 1;
			Level = 29;
			ReqLevel = 24;
			Name = "Cross-stitched Sandals";
			Name2 = "Cross-stitched Sandals";
			AvailableRaces = 0x1FF;
			BuyPrice = 2445;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Thin Cloth Shoes)
*
***************************************************************/

namespace Server.Items
{
	public class ThinClothShoes : Item
	{
		public ThinClothShoes() : base()
		{
			Id = 2117;
			Resistance[0] = 7;
			SellPrice = 7;
			AvailableClasses = 0x7FFF;
			Model = 16576;
			ObjectClass = 4;
			SubClass = 1;
			Level = 5;
			ReqLevel = 1;
			Name = "Thin Cloth Shoes";
			Name2 = "Thin Cloth Shoes";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 36;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Padded Boots)
*
***************************************************************/

namespace Server.Items
{
	public class PaddedBoots : Item
	{
		public PaddedBoots() : base()
		{
			Id = 2156;
			Resistance[0] = 27;
			SellPrice = 615;
			AvailableClasses = 0x7FFF;
			Model = 16858;
			ObjectClass = 4;
			SubClass = 1;
			Level = 27;
			ReqLevel = 22;
			Name = "Padded Boots";
			Name2 = "Padded Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 3077;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Foreman's Boots)
*
***************************************************************/

namespace Server.Items
{
	public class ForemansBoots : Item
	{
		public ForemansBoots() : base()
		{
			Id = 2168;
			Resistance[0] = 24;
			Bonding = 2;
			SellPrice = 469;
			AvailableClasses = 0x7FFF;
			Model = 16713;
			ObjectClass = 4;
			SubClass = 1;
			Level = 21;
			ReqLevel = 16;
			Name = "Foreman's Boots";
			Name2 = "Foreman's Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2349;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 30;
			StaminaBonus = 4;
			SpiritBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Dark Runner Boots)
*
***************************************************************/

namespace Server.Items
{
	public class DarkRunnerBoots : Item
	{
		public DarkRunnerBoots() : base()
		{
			Id = 2232;
			Resistance[0] = 27;
			Bonding = 2;
			SellPrice = 812;
			AvailableClasses = 0x7FFF;
			Model = 4272;
			ObjectClass = 4;
			SubClass = 1;
			Level = 25;
			ReqLevel = 20;
			Name = "Dark Runner Boots";
			Name2 = "Dark Runner Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4064;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			StaminaBonus = 5;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Woven Boots)
*
***************************************************************/

namespace Server.Items
{
	public class WovenBoots : Item
	{
		public WovenBoots() : base()
		{
			Id = 2367;
			Resistance[0] = 13;
			SellPrice = 44;
			AvailableClasses = 0x7FFF;
			Model = 14162;
			ObjectClass = 4;
			SubClass = 1;
			Level = 10;
			ReqLevel = 5;
			Name = "Woven Boots";
			Name2 = "Woven Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 223;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Russet Boots)
*
***************************************************************/

namespace Server.Items
{
	public class RussetBoots : Item
	{
		public RussetBoots() : base()
		{
			Id = 2432;
			Resistance[0] = 32;
			SellPrice = 1538;
			AvailableClasses = 0x7FFF;
			Model = 1861;
			ObjectClass = 4;
			SubClass = 1;
			Level = 37;
			ReqLevel = 32;
			Name = "Russet Boots";
			Name2 = "Russet Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 7690;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Embroidered Boots)
*
***************************************************************/

namespace Server.Items
{
	public class EmbroideredBoots : Item
	{
		public EmbroideredBoots() : base()
		{
			Id = 2438;
			Resistance[0] = 43;
			SellPrice = 4199;
			AvailableClasses = 0x7FFF;
			Model = 16772;
			ObjectClass = 4;
			SubClass = 1;
			Level = 50;
			ReqLevel = 45;
			Name = "Embroidered Boots";
			Name2 = "Embroidered Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 20996;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Linen Boots)
*
***************************************************************/

namespace Server.Items
{
	public class LinenBoots : Item
	{
		public LinenBoots() : base()
		{
			Id = 2569;
			Resistance[0] = 16;
			SellPrice = 87;
			AvailableClasses = 0x7FFF;
			Model = 17120;
			ObjectClass = 4;
			SubClass = 1;
			Level = 13;
			ReqLevel = 8;
			Name = "Linen Boots";
			Name2 = "Linen Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 437;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Viny Wrappings)
*
***************************************************************/

namespace Server.Items
{
	public class VinyWrappings : Item
	{
		public VinyWrappings() : base()
		{
			Id = 2571;
			Resistance[0] = 9;
			Bonding = 1;
			SellPrice = 16;
			AvailableClasses = 0x7FFF;
			Model = 2486;
			ObjectClass = 4;
			SubClass = 1;
			Level = 7;
			Name = "Viny Wrappings";
			Name2 = "Viny Wrappings";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 84;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Woolen Boots)
*
***************************************************************/

namespace Server.Items
{
	public class WoolenBoots : Item
	{
		public WoolenBoots() : base()
		{
			Id = 2583;
			Resistance[0] = 22;
			Bonding = 2;
			SellPrice = 359;
			AvailableClasses = 0x7FFF;
			Model = 13524;
			ObjectClass = 4;
			SubClass = 1;
			Level = 19;
			ReqLevel = 14;
			Name = "Woolen Boots";
			Name2 = "Woolen Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1796;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 30;
			SpiritBonus = 2;
			IqBonus = 2;
			AgilityBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Journeyman's Boots)
*
***************************************************************/

namespace Server.Items
{
	public class JourneymansBoots : Item
	{
		public JourneymansBoots() : base()
		{
			Id = 2959;
			Resistance[0] = 11;
			SellPrice = 32;
			AvailableClasses = 0x7FFF;
			Model = 14525;
			ObjectClass = 4;
			SubClass = 1;
			Level = 9;
			ReqLevel = 4;
			Name = "Journeyman's Boots";
			Name2 = "Journeyman's Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 164;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Spellbinder Boots)
*
***************************************************************/

namespace Server.Items
{
	public class SpellbinderBoots : Item
	{
		public SpellbinderBoots() : base()
		{
			Id = 2971;
			Resistance[0] = 17;
			SellPrice = 108;
			AvailableClasses = 0x7FFF;
			Model = 14531;
			ObjectClass = 4;
			SubClass = 1;
			Level = 14;
			ReqLevel = 9;
			Name = "Spellbinder Boots";
			Name2 = "Spellbinder Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 544;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Seer's Boots)
*
***************************************************************/

namespace Server.Items
{
	public class SeersBoots : Item
	{
		public SeersBoots() : base()
		{
			Id = 2983;
			Resistance[0] = 21;
			Bonding = 2;
			SellPrice = 280;
			AvailableClasses = 0x7FFF;
			Model = 14552;
			ObjectClass = 4;
			SubClass = 1;
			Level = 17;
			ReqLevel = 12;
			Name = "Seer's Boots";
			Name2 = "Seer's Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1400;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			SpiritBonus = 1;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Bright Boots)
*
***************************************************************/

namespace Server.Items
{
	public class BrightBoots : Item
	{
		public BrightBoots() : base()
		{
			Id = 3065;
			Resistance[0] = 25;
			Bonding = 2;
			SellPrice = 658;
			AvailableClasses = 0x7FFF;
			Model = 27547;
			ObjectClass = 4;
			SubClass = 1;
			Level = 23;
			ReqLevel = 18;
			Name = "Bright Boots";
			Name2 = "Bright Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3290;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 30;
			StaminaBonus = 5;
			IqBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Smoldering Boots)
*
***************************************************************/

namespace Server.Items
{
	public class SmolderingBoots : Item
	{
		public SmolderingBoots() : base()
		{
			Id = 3076;
			Resistance[0] = 25;
			Bonding = 2;
			SellPrice = 636;
			AvailableClasses = 0x7FFF;
			Model = 4873;
			ObjectClass = 4;
			SubClass = 1;
			Level = 23;
			ReqLevel = 18;
			Name = "Smoldering Boots";
			Name2 = "Smoldering Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3184;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 30;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Flax Boots)
*
***************************************************************/

namespace Server.Items
{
	public class FlaxBoots : Item
	{
		public FlaxBoots() : base()
		{
			Id = 3274;
			Resistance[0] = 7;
			Bonding = 1;
			SellPrice = 7;
			AvailableClasses = 0x7FFF;
			Model = 16587;
			ObjectClass = 4;
			SubClass = 1;
			Level = 5;
			Name = "Flax Boots";
			Name2 = "Flax Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 38;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Ancestral Boots)
*
***************************************************************/

namespace Server.Items
{
	public class AncestralBoots : Item
	{
		public AncestralBoots() : base()
		{
			Id = 3289;
			Resistance[0] = 14;
			SellPrice = 57;
			AvailableClasses = 0x7FFF;
			Model = 14514;
			ObjectClass = 4;
			SubClass = 1;
			Level = 11;
			ReqLevel = 6;
			Name = "Ancestral Boots";
			Name2 = "Ancestral Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 288;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Barbaric Cloth Boots)
*
***************************************************************/

namespace Server.Items
{
	public class BarbaricClothBoots : Item
	{
		public BarbaricClothBoots() : base()
		{
			Id = 3307;
			Resistance[0] = 19;
			Bonding = 2;
			SellPrice = 215;
			AvailableClasses = 0x7FFF;
			Model = 11060;
			ObjectClass = 4;
			SubClass = 1;
			Level = 15;
			ReqLevel = 10;
			Name = "Barbaric Cloth Boots";
			Name2 = "Barbaric Cloth Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1078;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			SpiritBonus = 2;
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Reconnaissance Boots)
*
***************************************************************/

namespace Server.Items
{
	public class ReconnaissanceBoots : Item
	{
		public ReconnaissanceBoots() : base()
		{
			Id = 3454;
			Resistance[0] = 17;
			Bonding = 1;
			SellPrice = 105;
			AvailableClasses = 0x7FFF;
			Model = 3755;
			ObjectClass = 4;
			SubClass = 1;
			Level = 14;
			Name = "Reconnaissance Boots";
			Name2 = "Reconnaissance Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 527;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Mantis Boots)
*
***************************************************************/

namespace Server.Items
{
	public class MantisBoots : Item
	{
		public MantisBoots() : base()
		{
			Id = 3764;
			Resistance[0] = 36;
			Bonding = 1;
			SellPrice = 3181;
			AvailableClasses = 0x7FFF;
			Model = 3750;
			ObjectClass = 4;
			SubClass = 1;
			Level = 40;
			Name = "Mantis Boots";
			Name2 = "Mantis Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 15905;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			StrBonus = 3;
			IqBonus = 7;
			AgilityBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Interlaced Boots)
*
***************************************************************/

namespace Server.Items
{
	public class InterlacedBoots : Item
	{
		public InterlacedBoots() : base()
		{
			Id = 3793;
			Resistance[0] = 27;
			SellPrice = 648;
			AvailableClasses = 0x7FFF;
			Model = 6190;
			ObjectClass = 4;
			SubClass = 1;
			Level = 32;
			ReqLevel = 27;
			Name = "Interlaced Boots";
			Name2 = "Interlaced Boots";
			AvailableRaces = 0x1FF;
			BuyPrice = 3243;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Crochet Boots)
*
***************************************************************/

namespace Server.Items
{
	public class CrochetBoots : Item
	{
		public CrochetBoots() : base()
		{
			Id = 3937;
			Resistance[0] = 37;
			SellPrice = 2018;
			AvailableClasses = 0x7FFF;
			Model = 16721;
			ObjectClass = 4;
			SubClass = 1;
			Level = 46;
			ReqLevel = 41;
			Name = "Crochet Boots";
			Name2 = "Crochet Boots";
			AvailableRaces = 0x1FF;
			BuyPrice = 10092;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Twill Boots)
*
***************************************************************/

namespace Server.Items
{
	public class TwillBoots : Item
	{
		public TwillBoots() : base()
		{
			Id = 3945;
			Resistance[0] = 44;
			SellPrice = 3852;
			AvailableClasses = 0x7FFF;
			Model = 16703;
			ObjectClass = 4;
			SubClass = 1;
			Level = 55;
			ReqLevel = 50;
			Name = "Twill Boots";
			Name2 = "Twill Boots";
			AvailableRaces = 0x1FF;
			BuyPrice = 19263;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Mistscape Boots)
*
***************************************************************/

namespace Server.Items
{
	public class MistscapeBoots : Item
	{
		public MistscapeBoots() : base()
		{
			Id = 4047;
			Resistance[0] = 39;
			Bonding = 2;
			SellPrice = 3959;
			AvailableClasses = 0x7FFF;
			Model = 14679;
			ObjectClass = 4;
			SubClass = 1;
			Level = 43;
			ReqLevel = 38;
			Name = "Mistscape Boots";
			Name2 = "Mistscape Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 19799;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			StaminaBonus = 11;
			IqBonus = 4;
			SpiritBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Darkspear Shoes)
*
***************************************************************/

namespace Server.Items
{
	public class DarkspearShoes : Item
	{
		public DarkspearShoes() : base()
		{
			Id = 4137;
			Resistance[0] = 38;
			Bonding = 1;
			SellPrice = 4010;
			AvailableClasses = 0x7FFF;
			Model = 4835;
			ObjectClass = 4;
			SubClass = 1;
			Level = 42;
			Name = "Darkspear Shoes";
			Name2 = "Darkspear Shoes";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 20053;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			StaminaBonus = 7;
			IqBonus = 3;
			SpiritBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Junglewalker Sandals)
*
***************************************************************/

namespace Server.Items
{
	public class JunglewalkerSandals : Item
	{
		public JunglewalkerSandals() : base()
		{
			Id = 4139;
			Resistance[0] = 34;
			Bonding = 1;
			SellPrice = 2749;
			AvailableClasses = 0x7FFF;
			Model = 16822;
			ObjectClass = 4;
			SubClass = 1;
			Level = 37;
			Name = "Junglewalker Sandals";
			Name2 = "Junglewalker Sandals";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 13745;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			StaminaBonus = 8;
			IqBonus = 2;
			SpiritBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Soft-soled Linen Boots)
*
***************************************************************/

namespace Server.Items
{
	public class SoftSoledLinenBoots : Item
	{
		public SoftSoledLinenBoots() : base()
		{
			Id = 4312;
			Resistance[0] = 20;
			Bonding = 2;
			SellPrice = 237;
			AvailableClasses = 0x7FFF;
			Model = 14403;
			ObjectClass = 4;
			SubClass = 1;
			Level = 16;
			ReqLevel = 11;
			Name = "Soft-soled Linen Boots";
			Name2 = "Soft-soled Linen Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1186;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			StaminaBonus = 2;
			SpiritBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Red Woolen Boots)
*
***************************************************************/

namespace Server.Items
{
	public class RedWoolenBoots : Item
	{
		public RedWoolenBoots() : base()
		{
			Id = 4313;
			Resistance[0] = 23;
			Bonding = 2;
			SellPrice = 416;
			AvailableClasses = 0x7FFF;
			Model = 4615;
			ObjectClass = 4;
			SubClass = 1;
			Level = 20;
			ReqLevel = 15;
			Name = "Red Woolen Boots";
			Name2 = "Red Woolen Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2083;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 30;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Spidersilk Boots)
*
***************************************************************/

namespace Server.Items
{
	public class SpidersilkBoots : Item
	{
		public SpidersilkBoots() : base()
		{
			Id = 4320;
			Resistance[0] = 29;
			Bonding = 2;
			SellPrice = 979;
			AvailableClasses = 0x7FFF;
			Model = 4301;
			ObjectClass = 4;
			SubClass = 1;
			Level = 25;
			ReqLevel = 20;
			Name = "Spidersilk Boots";
			Name2 = "Spidersilk Boots";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 4897;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 40;
			IqBonus = 7;
			SpiritBonus = 4;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Spider Silk Slippers)
*
***************************************************************/

namespace Server.Items
{
	public class SpiderSilkSlippers : Item
	{
		public SpiderSilkSlippers() : base()
		{
			Id = 4321;
			Resistance[0] = 29;
			Bonding = 2;
			SellPrice = 1120;
			AvailableClasses = 0x7FFF;
			Model = 17138;
			ObjectClass = 4;
			SubClass = 1;
			Level = 28;
			ReqLevel = 23;
			Name = "Spider Silk Slippers";
			Name2 = "Spider Silk Slippers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5600;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			IqBonus = 7;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Boots of the Enchanter)
*
***************************************************************/

namespace Server.Items
{
	public class BootsOfTheEnchanter : Item
	{
		public BootsOfTheEnchanter() : base()
		{
			Id = 4325;
			Resistance[0] = 32;
			Bonding = 2;
			SellPrice = 2272;
			AvailableClasses = 0x7FFF;
			Model = 4631;
			ObjectClass = 4;
			SubClass = 1;
			Level = 35;
			ReqLevel = 30;
			Name = "Boots of the Enchanter";
			Name2 = "Boots of the Enchanter";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11362;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			IqBonus = 8;
			SpiritBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Walking Boots)
*
***************************************************************/

namespace Server.Items
{
	public class WalkingBoots : Item
	{
		public WalkingBoots() : base()
		{
			Id = 4660;
			Resistance[0] = 22;
			Bonding = 2;
			SellPrice = 324;
			AvailableClasses = 0x7FFF;
			Model = 6322;
			ObjectClass = 4;
			SubClass = 1;
			Level = 18;
			ReqLevel = 13;
			Name = "Walking Boots";
			Name2 = "Walking Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1622;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 30;
			SpiritBonus = 3;
			AgilityBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Soft Wool Boots)
*
***************************************************************/

namespace Server.Items
{
	public class SoftWoolBoots : Item
	{
		public SoftWoolBoots() : base()
		{
			Id = 4915;
			Resistance[0] = 7;
			Bonding = 1;
			SellPrice = 7;
			AvailableClasses = 0x7FFF;
			Model = 16802;
			ObjectClass = 4;
			SubClass = 1;
			Level = 5;
			Name = "Soft Wool Boots";
			Name2 = "Soft Wool Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 35;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Dirt-trodden Boots)
*
***************************************************************/

namespace Server.Items
{
	public class DirtTroddenBoots : Item
	{
		public DirtTroddenBoots() : base()
		{
			Id = 4936;
			Resistance[0] = 10;
			Bonding = 1;
			SellPrice = 23;
			AvailableClasses = 0x7FFF;
			Model = 16880;
			ObjectClass = 4;
			SubClass = 1;
			Level = 8;
			Name = "Dirt-trodden Boots";
			Name2 = "Dirt-trodden Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 118;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Wandering Boots)
*
***************************************************************/

namespace Server.Items
{
	public class WanderingBoots : Item
	{
		public WanderingBoots() : base()
		{
			Id = 6095;
			Resistance[0] = 26;
			Bonding = 1;
			SellPrice = 688;
			AvailableClasses = 0x7FFF;
			Model = 11548;
			ObjectClass = 4;
			SubClass = 1;
			Level = 24;
			Name = "Wandering Boots";
			Name2 = "Wandering Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3440;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 30;
			AgilityBonus = 4;
			SpiritBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Web-covered Boots)
*
***************************************************************/

namespace Server.Items
{
	public class WebCoveredBoots : Item
	{
		public WebCoveredBoots() : base()
		{
			Id = 6148;
			Resistance[0] = 13;
			SellPrice = 44;
			AvailableClasses = 0x7FFF;
			Model = 16853;
			ObjectClass = 4;
			SubClass = 1;
			Level = 10;
			ReqLevel = 5;
			Name = "Web-covered Boots";
			Name2 = "Web-covered Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 223;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Snow Boots)
*
***************************************************************/

namespace Server.Items
{
	public class SnowBoots : Item
	{
		public SnowBoots() : base()
		{
			Id = 6173;
			Resistance[0] = 7;
			Bonding = 1;
			SellPrice = 7;
			AvailableClasses = 0x7FFF;
			Model = 16809;
			ObjectClass = 4;
			SubClass = 1;
			Level = 5;
			Name = "Snow Boots";
			Name2 = "Snow Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 36;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Kimbra Boots)
*
***************************************************************/

namespace Server.Items
{
	public class KimbraBoots : Item
	{
		public KimbraBoots() : base()
		{
			Id = 6191;
			Resistance[0] = 25;
			Bonding = 1;
			SellPrice = 615;
			AvailableClasses = 0x7FFF;
			Model = 10454;
			ObjectClass = 4;
			SubClass = 1;
			Level = 23;
			Name = "Kimbra Boots";
			Name2 = "Kimbra Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3079;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 30;
			AgilityBonus = 4;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Silver-thread Boots)
*
***************************************************************/

namespace Server.Items
{
	public class SilverThreadBoots : Item
	{
		public SilverThreadBoots() : base()
		{
			Id = 6394;
			Resistance[0] = 28;
			Bonding = 2;
			SellPrice = 1041;
			AvailableClasses = 0x7FFF;
			Model = 11571;
			ObjectClass = 4;
			SubClass = 1;
			Level = 27;
			ReqLevel = 22;
			Name = "Silver-thread Boots";
			Name2 = "Silver-thread Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5205;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			SpiritBonus = 5;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Nightsky Boots)
*
***************************************************************/

namespace Server.Items
{
	public class NightskyBoots : Item
	{
		public NightskyBoots() : base()
		{
			Id = 6406;
			Resistance[0] = 32;
			Bonding = 2;
			SellPrice = 1970;
			AvailableClasses = 0x7FFF;
			Model = 14617;
			ObjectClass = 4;
			SubClass = 1;
			Level = 34;
			ReqLevel = 29;
			Name = "Nightsky Boots";
			Name2 = "Nightsky Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 9854;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			SpiritBonus = 4;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Aurora Boots)
*
***************************************************************/

namespace Server.Items
{
	public class AuroraBoots : Item
	{
		public AuroraBoots() : base()
		{
			Id = 6416;
			Resistance[0] = 35;
			Bonding = 2;
			SellPrice = 2728;
			AvailableClasses = 0x7FFF;
			Model = 14651;
			ObjectClass = 4;
			SubClass = 1;
			Level = 38;
			ReqLevel = 33;
			Name = "Aurora Boots";
			Name2 = "Aurora Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 13642;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			IqBonus = 10;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Rat Stompers)
*
***************************************************************/

namespace Server.Items
{
	public class RatStompers : Item
	{
		public RatStompers() : base()
		{
			Id = 6478;
			Resistance[0] = 25;
			Bonding = 1;
			SellPrice = 634;
			AvailableClasses = 0x7FFF;
			Model = 11999;
			ObjectClass = 4;
			SubClass = 1;
			Level = 23;
			Name = "Rat Stompers";
			Name2 = "Rat Stompers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3174;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 30;
			StrBonus = 3;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Firewalker Boots)
*
***************************************************************/

namespace Server.Items
{
	public class FirewalkerBoots : Item
	{
		public FirewalkerBoots() : base()
		{
			Id = 6482;
			Resistance[0] = 26;
			Bonding = 1;
			SellPrice = 728;
			AvailableClasses = 0x7FFF;
			Model = 12070;
			ObjectClass = 4;
			SubClass = 1;
			Level = 24;
			Name = "Firewalker Boots";
			Name2 = "Firewalker Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3640;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 30;
			StrBonus = 2;
			IqBonus = 5;
			SpiritBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Willow Boots)
*
***************************************************************/

namespace Server.Items
{
	public class WillowBoots : Item
	{
		public WillowBoots() : base()
		{
			Id = 6537;
			Resistance[0] = 19;
			Bonding = 2;
			SellPrice = 210;
			AvailableClasses = 0x7FFF;
			Model = 12439;
			ObjectClass = 4;
			SubClass = 1;
			Level = 15;
			ReqLevel = 10;
			Name = "Willow Boots";
			Name2 = "Willow Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 791;
			BuyPrice = 1051;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Shimmering Boots)
*
***************************************************************/

namespace Server.Items
{
	public class ShimmeringBoots : Item
	{
		public ShimmeringBoots() : base()
		{
			Id = 6562;
			Resistance[0] = 24;
			Bonding = 2;
			SellPrice = 508;
			AvailableClasses = 0x7FFF;
			Model = 16881;
			ObjectClass = 4;
			SubClass = 1;
			Level = 21;
			ReqLevel = 16;
			Name = "Shimmering Boots";
			Name2 = "Shimmering Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 793;
			BuyPrice = 2542;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Sage's Boots)
*
***************************************************************/

namespace Server.Items
{
	public class SagesBoots : Item
	{
		public SagesBoots() : base()
		{
			Id = 6612;
			Resistance[0] = 29;
			Bonding = 2;
			SellPrice = 1112;
			AvailableClasses = 0x7FFF;
			Model = 19921;
			ObjectClass = 4;
			SubClass = 1;
			Level = 28;
			ReqLevel = 23;
			Name = "Sage's Boots";
			Name2 = "Sage's Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 796;
			BuyPrice = 5562;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Hellion Boots)
*
***************************************************************/

namespace Server.Items
{
	public class HellionBoots : Item
	{
		public HellionBoots() : base()
		{
			Id = 6791;
			Resistance[0] = 36;
			Bonding = 1;
			SellPrice = 3464;
			AvailableClasses = 0x7FFF;
			Model = 17227;
			ObjectClass = 4;
			SubClass = 1;
			Level = 40;
			Name = "Hellion Boots";
			Name2 = "Hellion Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 17321;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			AgilityBonus = 3;
			IqBonus = 9;
			SpiritBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Nimbus Boots)
*
***************************************************************/

namespace Server.Items
{
	public class NimbusBoots : Item
	{
		public NimbusBoots() : base()
		{
			Id = 6998;
			Resistance[0] = 27;
			Bonding = 1;
			SellPrice = 774;
			AvailableClasses = 0x7FFF;
			Model = 13500;
			ObjectClass = 4;
			SubClass = 1;
			Level = 25;
			Name = "Nimbus Boots";
			Name2 = "Nimbus Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3872;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			AgilityBonus = 3;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Boots of Darkness)
*
***************************************************************/

namespace Server.Items
{
	public class BootsOfDarkness : Item
	{
		public BootsOfDarkness() : base()
		{
			Id = 7027;
			Resistance[0] = 15;
			Bonding = 2;
			SellPrice = 1125;
			AvailableClasses = 0x7A08;
			Model = 17148;
			ObjectClass = 4;
			SubClass = 1;
			Level = 28;
			ReqLevel = 23;
			Name = "Boots of Darkness";
			Name2 = "Boots of Darkness";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5625;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			SetSpell( 8732 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Bog Boots)
*
***************************************************************/

namespace Server.Items
{
	public class BogBoots : Item
	{
		public BogBoots() : base()
		{
			Id = 7095;
			Resistance[0] = 11;
			SellPrice = 32;
			AvailableClasses = 0x7FFF;
			Model = 16810;
			ObjectClass = 4;
			SubClass = 1;
			Level = 9;
			ReqLevel = 4;
			Name = "Bog Boots";
			Name2 = "Bog Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 161;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Goblin Rocket Boots)
*
***************************************************************/

namespace Server.Items
{
	public class GoblinRocketBoots : Item
	{
		public GoblinRocketBoots() : base()
		{
			Id = 7189;
			Resistance[0] = 41;
			Bonding = 2;
			SellPrice = 4712;
			AvailableClasses = 0x7FFF;
			Model = 20622;
			ObjectClass = 4;
			SubClass = 1;
			Level = 45;
			Name = "Goblin Rocket Boots";
			Name2 = "Goblin Rocket Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 225;
			BuyPrice = 23562;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			SetSpell( 8892 , 0 , 0 , 0 , 28 , 300000 );
		}
	}
}


/**************************************************************
*
*				(Disciple's Boots)
*
***************************************************************/

namespace Server.Items
{
	public class DisciplesBoots : Item
	{
		public DisciplesBoots() : base()
		{
			Id = 7351;
			Resistance[0] = 14;
			SellPrice = 58;
			AvailableClasses = 0x7FFF;
			Model = 16563;
			ObjectClass = 4;
			SubClass = 1;
			Level = 11;
			ReqLevel = 6;
			Name = "Disciple's Boots";
			Name2 = "Disciple's Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 290;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Elder's Boots)
*
***************************************************************/

namespace Server.Items
{
	public class EldersBoots : Item
	{
		public EldersBoots() : base()
		{
			Id = 7354;
			Resistance[0] = 31;
			Bonding = 2;
			SellPrice = 1864;
			AvailableClasses = 0x7FFF;
			Model = 16605;
			ObjectClass = 4;
			SubClass = 1;
			Level = 33;
			ReqLevel = 28;
			Name = "Elder's Boots";
			Name2 = "Elder's Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 797;
			BuyPrice = 9324;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Twilight Boots)
*
***************************************************************/

namespace Server.Items
{
	public class TwilightBoots : Item
	{
		public TwilightBoots() : base()
		{
			Id = 7434;
			Resistance[0] = 34;
			Bonding = 2;
			SellPrice = 2536;
			AvailableClasses = 0x7FFF;
			Model = 14645;
			ObjectClass = 4;
			SubClass = 1;
			Level = 37;
			ReqLevel = 32;
			Name = "Twilight Boots";
			Name2 = "Twilight Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 799;
			BuyPrice = 12680;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Regal Boots)
*
***************************************************************/

namespace Server.Items
{
	public class RegalBoots : Item
	{
		public RegalBoots() : base()
		{
			Id = 7472;
			Resistance[0] = 37;
			Bonding = 2;
			SellPrice = 3423;
			AvailableClasses = 0x7FFF;
			Model = 13051;
			ObjectClass = 4;
			SubClass = 1;
			Level = 41;
			ReqLevel = 36;
			Name = "Regal Boots";
			Name2 = "Regal Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 800;
			BuyPrice = 17115;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Gossamer Boots)
*
***************************************************************/

namespace Server.Items
{
	public class GossamerBoots : Item
	{
		public GossamerBoots() : base()
		{
			Id = 7522;
			Resistance[0] = 41;
			Bonding = 2;
			SellPrice = 4962;
			AvailableClasses = 0x7FFF;
			Model = 15409;
			ObjectClass = 4;
			SubClass = 1;
			Level = 45;
			ReqLevel = 40;
			Name = "Gossamer Boots";
			Name2 = "Gossamer Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 801;
			BuyPrice = 24814;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Hibernal Boots)
*
***************************************************************/

namespace Server.Items
{
	public class HibernalBoots : Item
	{
		public HibernalBoots() : base()
		{
			Id = 8107;
			Resistance[0] = 42;
			Bonding = 2;
			SellPrice = 5938;
			AvailableClasses = 0x7FFF;
			Model = 16634;
			ObjectClass = 4;
			SubClass = 1;
			Level = 47;
			ReqLevel = 42;
			Name = "Hibernal Boots";
			Name2 = "Hibernal Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 29692;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			StaminaBonus = 11;
			SpiritBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Imperial Red Boots)
*
***************************************************************/

namespace Server.Items
{
	public class ImperialRedBoots : Item
	{
		public ImperialRedBoots() : base()
		{
			Id = 8246;
			Resistance[0] = 47;
			Bonding = 2;
			SellPrice = 7917;
			AvailableClasses = 0x7FFF;
			Model = 16766;
			ObjectClass = 4;
			SubClass = 1;
			Level = 52;
			ReqLevel = 47;
			Name = "Imperial Red Boots";
			Name2 = "Imperial Red Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 39586;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			IqBonus = 15;
			AgilityBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Arcane Boots)
*
***************************************************************/

namespace Server.Items
{
	public class ArcaneBoots : Item
	{
		public ArcaneBoots() : base()
		{
			Id = 8284;
			Resistance[0] = 51;
			Bonding = 2;
			SellPrice = 10514;
			AvailableClasses = 0x7FFF;
			Model = 17256;
			ObjectClass = 4;
			SubClass = 1;
			Level = 57;
			ReqLevel = 52;
			Name = "Arcane Boots";
			Name2 = "Arcane Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 52570;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			IqBonus = 16;
			SpiritBonus = 4;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Acidic Walkers)
*
***************************************************************/

namespace Server.Items
{
	public class AcidicWalkers : Item
	{
		public AcidicWalkers() : base()
		{
			Id = 9454;
			Resistance[0] = 34;
			Bonding = 1;
			SellPrice = 1984;
			AvailableClasses = 0x7FFF;
			Model = 14749;
			ObjectClass = 4;
			SubClass = 1;
			Level = 32;
			ReqLevel = 27;
			Name = "Acidic Walkers";
			Name2 = "Acidic Walkers";
			Resistance[3] = 5;
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 9923;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 40;
			SpiritBonus = 8;
			AgilityBonus = 4;
			IqBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Durtfeet Stompers)
*
***************************************************************/

namespace Server.Items
{
	public class DurtfeetStompers : Item
	{
		public DurtfeetStompers() : base()
		{
			Id = 9519;
			Resistance[0] = 33;
			Bonding = 1;
			SellPrice = 2288;
			AvailableClasses = 0x7FFF;
			Model = 18444;
			ObjectClass = 4;
			SubClass = 1;
			Level = 36;
			Name = "Durtfeet Stompers";
			Name2 = "Durtfeet Stompers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11444;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			StrBonus = 4;
			IqBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Gnomish Inventor Boots)
*
***************************************************************/

namespace Server.Items
{
	public class GnomishInventorBoots : Item
	{
		public GnomishInventorBoots() : base()
		{
			Id = 9645;
			Resistance[0] = 44;
			Bonding = 1;
			SellPrice = 6768;
			AvailableClasses = 0x7FFF;
			Model = 18906;
			ObjectClass = 4;
			SubClass = 1;
			Level = 49;
			Name = "Gnomish Inventor Boots";
			Name2 = "Gnomish Inventor Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 33841;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			StaminaBonus = 7;
			SpiritBonus = 2;
			IqBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Boots of the Maharishi)
*
***************************************************************/

namespace Server.Items
{
	public class BootsOfTheMaharishi : Item
	{
		public BootsOfTheMaharishi() : base()
		{
			Id = 9658;
			Resistance[0] = 39;
			Bonding = 1;
			SellPrice = 4086;
			AvailableClasses = 0x7FFF;
			Model = 19913;
			ObjectClass = 4;
			SubClass = 1;
			Level = 43;
			Name = "Boots of the Maharishi";
			Name2 = "Boots of the Maharishi";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 20432;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			IqBonus = 6;
			AgilityBonus = 4;
			SpiritBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Simple Shoes)
*
***************************************************************/

namespace Server.Items
{
	public class SimpleShoes : Item
	{
		public SimpleShoes() : base()
		{
			Id = 9743;
			Resistance[0] = 15;
			SellPrice = 67;
			AvailableClasses = 0x7FFF;
			Model = 27532;
			ObjectClass = 4;
			SubClass = 1;
			Level = 12;
			ReqLevel = 7;
			Name = "Simple Shoes";
			Name2 = "Simple Shoes";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 335;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Greenweave Sandals)
*
***************************************************************/

namespace Server.Items
{
	public class GreenweaveSandals : Item
	{
		public GreenweaveSandals() : base()
		{
			Id = 9767;
			Resistance[0] = 25;
			Bonding = 2;
			SellPrice = 616;
			AvailableClasses = 0x7FFF;
			Model = 25946;
			ObjectClass = 4;
			SubClass = 1;
			Level = 23;
			ReqLevel = 18;
			Name = "Greenweave Sandals";
			Name2 = "Greenweave Sandals";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 794;
			BuyPrice = 3080;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Ivycloth Boots)
*
***************************************************************/

namespace Server.Items
{
	public class IvyclothBoots : Item
	{
		public IvyclothBoots() : base()
		{
			Id = 9792;
			Resistance[0] = 27;
			Bonding = 2;
			SellPrice = 823;
			AvailableClasses = 0x7FFF;
			Model = 16881;
			ObjectClass = 4;
			SubClass = 1;
			Level = 25;
			ReqLevel = 20;
			Name = "Ivycloth Boots";
			Name2 = "Ivycloth Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 795;
			BuyPrice = 4115;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Durable Boots)
*
***************************************************************/

namespace Server.Items
{
	public class DurableBoots : Item
	{
		public DurableBoots() : base()
		{
			Id = 9820;
			Resistance[0] = 30;
			Bonding = 2;
			SellPrice = 1541;
			AvailableClasses = 0x7FFF;
			Model = 27861;
			ObjectClass = 4;
			SubClass = 1;
			Level = 31;
			ReqLevel = 26;
			Name = "Durable Boots";
			Name2 = "Durable Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 797;
			BuyPrice = 7707;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Conjurer's Shoes)
*
***************************************************************/

namespace Server.Items
{
	public class ConjurersShoes : Item
	{
		public ConjurersShoes() : base()
		{
			Id = 9845;
			Resistance[0] = 32;
			Bonding = 2;
			SellPrice = 2136;
			AvailableClasses = 0x7FFF;
			Model = 28423;
			ObjectClass = 4;
			SubClass = 1;
			Level = 35;
			ReqLevel = 30;
			Name = "Conjurer's Shoes";
			Name2 = "Conjurer's Shoes";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 798;
			BuyPrice = 10683;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Sorcerer Slippers)
*
***************************************************************/

namespace Server.Items
{
	public class SorcererSlippers : Item
	{
		public SorcererSlippers() : base()
		{
			Id = 9876;
			Resistance[0] = 36;
			Bonding = 2;
			SellPrice = 3146;
			AvailableClasses = 0x7FFF;
			Model = 28088;
			ObjectClass = 4;
			SubClass = 1;
			Level = 40;
			ReqLevel = 35;
			Name = "Sorcerer Slippers";
			Name2 = "Sorcerer Slippers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 800;
			BuyPrice = 15733;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Royal Boots)
*
***************************************************************/

namespace Server.Items
{
	public class RoyalBoots : Item
	{
		public RoyalBoots() : base()
		{
			Id = 9907;
			Resistance[0] = 40;
			Bonding = 2;
			SellPrice = 4581;
			AvailableClasses = 0x7FFF;
			Model = 11548;
			ObjectClass = 4;
			SubClass = 1;
			Level = 44;
			ReqLevel = 39;
			Name = "Royal Boots";
			Name2 = "Royal Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 801;
			BuyPrice = 22909;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Abjurer's Boots)
*
***************************************************************/

namespace Server.Items
{
	public class AbjurersBoots : Item
	{
		public AbjurersBoots() : base()
		{
			Id = 9936;
			Resistance[0] = 44;
			Bonding = 2;
			SellPrice = 6403;
			AvailableClasses = 0x7FFF;
			Model = 28010;
			ObjectClass = 4;
			SubClass = 1;
			Level = 49;
			ReqLevel = 44;
			Name = "Abjurer's Boots";
			Name2 = "Abjurer's Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 803;
			BuyPrice = 32016;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Black Mageweave Boots)
*
***************************************************************/

namespace Server.Items
{
	public class BlackMageweaveBoots : Item
	{
		public BlackMageweaveBoots() : base()
		{
			Id = 10026;
			Resistance[0] = 41;
			Bonding = 2;
			SellPrice = 5459;
			AvailableClasses = 0x7FFF;
			Model = 21154;
			ObjectClass = 4;
			SubClass = 1;
			Level = 46;
			ReqLevel = 41;
			Name = "Black Mageweave Boots";
			Name2 = "Black Mageweave Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 27298;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			IqBonus = 11;
			SpiritBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Shadoweave Boots)
*
***************************************************************/

namespace Server.Items
{
	public class ShadoweaveBoots : Item
	{
		public ShadoweaveBoots() : base()
		{
			Id = 10031;
			Resistance[0] = 43;
			Bonding = 2;
			SellPrice = 6030;
			AvailableClasses = 0x7FFF;
			Model = 19051;
			ObjectClass = 4;
			SubClass = 1;
			Level = 48;
			ReqLevel = 43;
			Name = "Shadoweave Boots";
			Name2 = "Shadoweave Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 30150;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			SetSpell( 9414 , 1 , 0 , -1 , 0 , -1 );
			IqBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Cindercloth Boots)
*
***************************************************************/

namespace Server.Items
{
	public class CinderclothBoots : Item
	{
		public CinderclothBoots() : base()
		{
			Id = 10044;
			Resistance[0] = 44;
			Bonding = 2;
			SellPrice = 6765;
			AvailableClasses = 0x7FFF;
			Model = 18933;
			ObjectClass = 4;
			SubClass = 1;
			Level = 49;
			ReqLevel = 44;
			Name = "Cindercloth Boots";
			Name2 = "Cindercloth Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 33827;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			SetSpell( 9298 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Simple Linen Boots)
*
***************************************************************/

namespace Server.Items
{
	public class SimpleLinenBoots : Item
	{
		public SimpleLinenBoots() : base()
		{
			Id = 10046;
			Resistance[0] = 11;
			SellPrice = 32;
			AvailableClasses = 0x7FFF;
			Model = 16853;
			ObjectClass = 4;
			SubClass = 1;
			Level = 9;
			ReqLevel = 4;
			Name = "Simple Linen Boots";
			Name2 = "Simple Linen Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 161;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Duskwoven Sandals)
*
***************************************************************/

namespace Server.Items
{
	public class DuskwovenSandals : Item
	{
		public DuskwovenSandals() : base()
		{
			Id = 10058;
			Resistance[0] = 45;
			Bonding = 2;
			SellPrice = 7083;
			AvailableClasses = 0x7FFF;
			Model = 28151;
			ObjectClass = 4;
			SubClass = 1;
			Level = 50;
			ReqLevel = 45;
			Name = "Duskwoven Sandals";
			Name2 = "Duskwoven Sandals";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 803;
			BuyPrice = 35417;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Councillor's Boots)
*
***************************************************************/

namespace Server.Items
{
	public class CouncillorsBoots : Item
	{
		public CouncillorsBoots() : base()
		{
			Id = 10095;
			Resistance[0] = 50;
			Bonding = 2;
			SellPrice = 10295;
			AvailableClasses = 0x7FFF;
			Model = 27600;
			ObjectClass = 4;
			SubClass = 1;
			Level = 56;
			ReqLevel = 51;
			Name = "Councillor's Boots";
			Name2 = "Councillor's Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 805;
			BuyPrice = 51476;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(High Councillor's Boots)
*
***************************************************************/

namespace Server.Items
{
	public class HighCouncillorsBoots : Item
	{
		public HighCouncillorsBoots() : base()
		{
			Id = 10137;
			Resistance[0] = 54;
			Bonding = 2;
			SellPrice = 13484;
			AvailableClasses = 0x7FFF;
			Model = 27633;
			ObjectClass = 4;
			SubClass = 1;
			Level = 61;
			ReqLevel = 56;
			Name = "High Councillor's Boots";
			Name2 = "High Councillor's Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 807;
			BuyPrice = 67420;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Mystical Boots)
*
***************************************************************/

namespace Server.Items
{
	public class MysticalBoots : Item
	{
		public MysticalBoots() : base()
		{
			Id = 10179;
			Resistance[0] = 48;
			Bonding = 2;
			SellPrice = 8632;
			AvailableClasses = 0x7FFF;
			Model = 28080;
			ObjectClass = 4;
			SubClass = 1;
			Level = 54;
			ReqLevel = 49;
			Name = "Mystical Boots";
			Name2 = "Mystical Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 804;
			BuyPrice = 43161;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Elegant Boots)
*
***************************************************************/

namespace Server.Items
{
	public class ElegantBoots : Item
	{
		public ElegantBoots() : base()
		{
			Id = 10211;
			Resistance[0] = 52;
			Bonding = 2;
			SellPrice = 12276;
			AvailableClasses = 0x7FFF;
			Model = 24291;
			ObjectClass = 4;
			SubClass = 1;
			Level = 59;
			ReqLevel = 54;
			Name = "Elegant Boots";
			Name2 = "Elegant Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 806;
			BuyPrice = 61383;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Master's Boots)
*
***************************************************************/

namespace Server.Items
{
	public class MastersBoots : Item
	{
		public MastersBoots() : base()
		{
			Id = 10247;
			Resistance[0] = 56;
			Bonding = 2;
			SellPrice = 14707;
			AvailableClasses = 0x7FFF;
			Model = 4272;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Master's Boots";
			Name2 = "Master's Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 807;
			BuyPrice = 73539;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Everlast Boots)
*
***************************************************************/

namespace Server.Items
{
	public class EverlastBoots : Item
	{
		public EverlastBoots() : base()
		{
			Id = 10359;
			Resistance[0] = 33;
			Bonding = 1;
			SellPrice = 2430;
			AvailableClasses = 0x7FFF;
			Model = 19917;
			ObjectClass = 4;
			SubClass = 1;
			Level = 36;
			Name = "Everlast Boots";
			Name2 = "Everlast Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 12151;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			IqBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Thoughtcast Boots)
*
***************************************************************/

namespace Server.Items
{
	public class ThoughtcastBoots : Item
	{
		public ThoughtcastBoots() : base()
		{
			Id = 10578;
			Resistance[0] = 38;
			Bonding = 2;
			SellPrice = 3377;
			AvailableClasses = 0x7FFF;
			Model = 19993;
			ObjectClass = 4;
			SubClass = 1;
			Level = 38;
			ReqLevel = 33;
			Name = "Thoughtcast Boots";
			Name2 = "Thoughtcast Boots";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 16885;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 40;
			SpiritBonus = 6;
			StaminaBonus = 3;
			IqBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Mistwalker Boots)
*
***************************************************************/

namespace Server.Items
{
	public class MistwalkerBoots : Item
	{
		public MistwalkerBoots() : base()
		{
			Id = 10629;
			Resistance[0] = 49;
			Bonding = 2;
			SellPrice = 8066;
			AvailableClasses = 0x7FFF;
			Model = 19950;
			ObjectClass = 4;
			SubClass = 1;
			Level = 50;
			ReqLevel = 45;
			Name = "Mistwalker Boots";
			Name2 = "Mistwalker Boots";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 40330;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 40;
			SpiritBonus = 8;
			IqBonus = 18;
		}
	}
}


/**************************************************************
*
*				(Encarmine Boots)
*
***************************************************************/

namespace Server.Items
{
	public class EncarmineBoots : Item
	{
		public EncarmineBoots() : base()
		{
			Id = 10700;
			Resistance[0] = 41;
			Bonding = 1;
			SellPrice = 4983;
			AvailableClasses = 0x7FFF;
			Model = 18832;
			ObjectClass = 4;
			SubClass = 1;
			Level = 45;
			Name = "Encarmine Boots";
			Name2 = "Encarmine Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 24918;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			StrBonus = 4;
			StaminaBonus = 8;
			SpiritBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Gnomish Rocket Boots)
*
***************************************************************/

namespace Server.Items
{
	public class GnomishRocketBoots : Item
	{
		public GnomishRocketBoots() : base()
		{
			Id = 10724;
			Resistance[0] = 41;
			Bonding = 2;
			SellPrice = 4696;
			AvailableClasses = 0x7FFF;
			Model = 19665;
			ObjectClass = 4;
			SubClass = 1;
			Level = 45;
			Name = "Gnomish Rocket Boots";
			Name2 = "Gnomish Rocket Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 225;
			Skill = 202;
			BuyPrice = 23484;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			SetSpell( 13141 , 0 , 0 , 1800000 , 28 , 300000 );
		}
	}
}


/**************************************************************
*
*				(Farmer's Boots)
*
***************************************************************/

namespace Server.Items
{
	public class FarmersBoots : Item
	{
		public FarmersBoots() : base()
		{
			Id = 11191;
			Resistance[0] = 13;
			Bonding = 1;
			SellPrice = 45;
			AvailableClasses = 0x7FFF;
			Model = 28167;
			ObjectClass = 4;
			SubClass = 1;
			Level = 10;
			Name = "Farmer's Boots";
			Name2 = "Farmer's Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 227;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Gamemaster's Slippers)
*
***************************************************************/

namespace Server.Items
{
	public class GamemastersSlippers : Item
	{
		public GamemastersSlippers() : base()
		{
			Id = 11508;
			Resistance[0] = 2;
			Bonding = 1;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 22034;
			ObjectClass = 4;
			SubClass = 1;
			Level = 1;
			Name = "Gamemaster's Slippers";
			Name2 = "Gamemaster's Slippers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 5;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 16;
		}
	}
}


/**************************************************************
*
*				(Omnicast Boots)
*
***************************************************************/

namespace Server.Items
{
	public class OmnicastBoots : Item
	{
		public OmnicastBoots() : base()
		{
			Id = 11822;
			Resistance[0] = 52;
			Bonding = 1;
			SellPrice = 11794;
			AvailableClasses = 0x7FFF;
			Model = 28660;
			ObjectClass = 4;
			SubClass = 1;
			Level = 59;
			ReqLevel = 54;
			Name = "Omnicast Boots";
			Name2 = "Omnicast Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 58973;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			SetSpell( 15714 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Rancor Boots)
*
***************************************************************/

namespace Server.Items
{
	public class RancorBoots : Item
	{
		public RancorBoots() : base()
		{
			Id = 11865;
			Resistance[0] = 47;
			Bonding = 1;
			SellPrice = 8708;
			AvailableClasses = 0x7FFF;
			Model = 16766;
			ObjectClass = 4;
			SubClass = 1;
			Level = 53;
			Name = "Rancor Boots";
			Name2 = "Rancor Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 43541;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			AgilityBonus = 12;
			SpiritBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Archaeologist's Quarry Boots)
*
***************************************************************/

namespace Server.Items
{
	public class ArchaeologistsQuarryBoots : Item
	{
		public ArchaeologistsQuarryBoots() : base()
		{
			Id = 11908;
			Resistance[0] = 49;
			Bonding = 1;
			SellPrice = 9886;
			AvailableClasses = 0x7FFF;
			Model = 28063;
			ObjectClass = 4;
			SubClass = 1;
			Level = 55;
			Name = "Archaeologist's Quarry Boots";
			Name2 = "Archaeologist's Quarry Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 49434;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			StaminaBonus = 10;
			AgilityBonus = 9;
			SpiritBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Hazecover Boots)
*
***************************************************************/

namespace Server.Items
{
	public class HazecoverBoots : Item
	{
		public HazecoverBoots() : base()
		{
			Id = 12050;
			Resistance[0] = 48;
			Bonding = 1;
			SellPrice = 8963;
			AvailableClasses = 0x7FFF;
			Model = 4272;
			ObjectClass = 4;
			SubClass = 1;
			Level = 54;
			Name = "Hazecover Boots";
			Name2 = "Hazecover Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 44818;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			IqBonus = 7;
			StaminaBonus = 8;
			AgilityBonus = 4;
		}
	}
}


/**************************************************************
*
*				(High Priestess Boots)
*
***************************************************************/

namespace Server.Items
{
	public class HighPriestessBoots : Item
	{
		public HighPriestessBoots() : base()
		{
			Id = 12556;
			Resistance[0] = 58;
			Bonding = 1;
			SellPrice = 14317;
			AvailableClasses = 0x7FFF;
			Model = 22779;
			ObjectClass = 4;
			SubClass = 1;
			Level = 59;
			ReqLevel = 54;
			Name = "High Priestess Boots";
			Name2 = "High Priestess Boots";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 71585;
			Resistance[5] = 10;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 40;
			StaminaBonus = 20;
			IqBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Moccasins of the White Hare)
*
***************************************************************/

namespace Server.Items
{
	public class MoccasinsOfTheWhiteHare : Item
	{
		public MoccasinsOfTheWhiteHare() : base()
		{
			Id = 13099;
			Resistance[0] = 32;
			Bonding = 2;
			SellPrice = 1431;
			AvailableClasses = 0x7FFF;
			Model = 28617;
			ObjectClass = 4;
			SubClass = 1;
			Level = 29;
			ReqLevel = 24;
			Name = "Moccasins of the White Hare";
			Name2 = "Moccasins of the White Hare";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 7155;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 40;
			IqBonus = 8;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Furen's Boots)
*
***************************************************************/

namespace Server.Items
{
	public class FurensBoots : Item
	{
		public FurensBoots() : base()
		{
			Id = 13100;
			Resistance[0] = 44;
			Bonding = 2;
			SellPrice = 5421;
			AvailableClasses = 0x7FFF;
			Model = 28645;
			ObjectClass = 4;
			SubClass = 1;
			Level = 44;
			ReqLevel = 39;
			Name = "Furen's Boots";
			Name2 = "Furen's Boots";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 27107;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 40;
			IqBonus = 16;
			SpiritBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Wolfrunner Shoes)
*
***************************************************************/

namespace Server.Items
{
	public class WolfrunnerShoes : Item
	{
		public WolfrunnerShoes() : base()
		{
			Id = 13101;
			Resistance[0] = 58;
			Bonding = 2;
			SellPrice = 14318;
			AvailableClasses = 0x7FFF;
			Model = 28597;
			ObjectClass = 4;
			SubClass = 1;
			Level = 59;
			ReqLevel = 54;
			Name = "Wolfrunner Shoes";
			Name2 = "Wolfrunner Shoes";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 71592;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 40;
			IqBonus = 11;
			AgilityBonus = 11;
			StrBonus = 11;
			StaminaBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Ogreseer Tower Boots)
*
***************************************************************/

namespace Server.Items
{
	public class OgreseerTowerBoots : Item
	{
		public OgreseerTowerBoots() : base()
		{
			Id = 13282;
			Resistance[0] = 58;
			Bonding = 1;
			SellPrice = 13684;
			AvailableClasses = 0x7FFF;
			Model = 18905;
			ObjectClass = 4;
			SubClass = 1;
			Level = 59;
			ReqLevel = 54;
			Name = "Ogreseer Tower Boots";
			Name2 = "Ogreseer Tower Boots";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 68423;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 40;
			SpiritBonus = 7;
			IqBonus = 20;
			StrBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Fire Striders)
*
***************************************************************/

namespace Server.Items
{
	public class FireStriders : Item
	{
		public FireStriders() : base()
		{
			Id = 13369;
			Resistance[0] = 61;
			Bonding = 1;
			SellPrice = 17526;
			AvailableClasses = 0x7FFF;
			Model = 24054;
			Resistance[2] = 15;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Fire Striders";
			Name2 = "Fire Striders";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 87634;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 40;
			SetSpell( 13830 , 1 , 0 , -1 , 0 , -1 );
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(The Postmaster's Treads)
*
***************************************************************/

namespace Server.Items
{
	public class ThePostmastersTreads : Item
	{
		public ThePostmastersTreads() : base()
		{
			Id = 13391;
			Resistance[0] = 60;
			Bonding = 1;
			SellPrice = 16425;
			AvailableClasses = 0x7FFF;
			Model = 25051;
			ObjectClass = 4;
			SubClass = 1;
			Level = 61;
			ReqLevel = 56;
			Name = "The Postmaster's Treads";
			Name2 = "The Postmaster's Treads";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 82127;
			Sets = 81;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 40;
			SpiritBonus = 15;
			AgilityBonus = 6;
			StaminaBonus = 14;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Fangdrip Runners)
*
***************************************************************/

namespace Server.Items
{
	public class FangdripRunners : Item
	{
		public FangdripRunners() : base()
		{
			Id = 13530;
			Resistance[0] = 54;
			Bonding = 1;
			SellPrice = 12453;
			AvailableClasses = 0x7FFF;
			Model = 24181;
			ObjectClass = 4;
			SubClass = 1;
			Level = 61;
			ReqLevel = 56;
			Name = "Fangdrip Runners";
			Name2 = "Fangdrip Runners";
			Resistance[3] = 20;
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 62269;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Runecloth Boots)
*
***************************************************************/

namespace Server.Items
{
	public class RuneclothBoots : Item
	{
		public RuneclothBoots() : base()
		{
			Id = 13864;
			Resistance[0] = 50;
			Bonding = 2;
			SellPrice = 9553;
			AvailableClasses = 0x7FFF;
			Model = 25233;
			ObjectClass = 4;
			SubClass = 1;
			Level = 56;
			ReqLevel = 51;
			Name = "Runecloth Boots";
			Name2 = "Runecloth Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 47767;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			IqBonus = 14;
			SpiritBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Beaded Sandals)
*
***************************************************************/

namespace Server.Items
{
	public class BeadedSandals : Item
	{
		public BeadedSandals() : base()
		{
			Id = 14086;
			Resistance[0] = 13;
			SellPrice = 45;
			AvailableClasses = 0x7FFF;
			Model = 25871;
			ObjectClass = 4;
			SubClass = 1;
			Level = 10;
			ReqLevel = 5;
			Name = "Beaded Sandals";
			Name2 = "Beaded Sandals";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 225;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Felcloth Boots)
*
***************************************************************/

namespace Server.Items
{
	public class FelclothBoots : Item
	{
		public FelclothBoots() : base()
		{
			Id = 14108;
			Resistance[0] = 51;
			Bonding = 2;
			SellPrice = 11112;
			AvailableClasses = 0x7FFF;
			Model = 24935;
			ObjectClass = 4;
			SubClass = 1;
			Level = 57;
			ReqLevel = 52;
			Name = "Felcloth Boots";
			Name2 = "Felcloth Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 55560;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			SetSpell( 9295 , 1 , 0 , -1 , 0 , -1 );
			IqBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Native Sandals)
*
***************************************************************/

namespace Server.Items
{
	public class NativeSandals : Item
	{
		public NativeSandals() : base()
		{
			Id = 14110;
			Resistance[0] = 16;
			SellPrice = 84;
			AvailableClasses = 0x7FFF;
			Model = 25879;
			ObjectClass = 4;
			SubClass = 1;
			Level = 13;
			ReqLevel = 8;
			Name = "Native Sandals";
			Name2 = "Native Sandals";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 420;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Aboriginal Footwraps)
*
***************************************************************/

namespace Server.Items
{
	public class AboriginalFootwraps : Item
	{
		public AboriginalFootwraps() : base()
		{
			Id = 14114;
			Resistance[0] = 20;
			Bonding = 2;
			SellPrice = 242;
			AvailableClasses = 0x7FFF;
			Model = 25857;
			ObjectClass = 4;
			SubClass = 1;
			Level = 16;
			ReqLevel = 11;
			Name = "Aboriginal Footwraps";
			Name2 = "Aboriginal Footwraps";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 792;
			BuyPrice = 1211;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Ritual Sandals)
*
***************************************************************/

namespace Server.Items
{
	public class RitualSandals : Item
	{
		public RitualSandals() : base()
		{
			Id = 14129;
			Resistance[0] = 23;
			Bonding = 2;
			SellPrice = 415;
			AvailableClasses = 0x7FFF;
			Model = 25929;
			ObjectClass = 4;
			SubClass = 1;
			Level = 20;
			ReqLevel = 15;
			Name = "Ritual Sandals";
			Name2 = "Ritual Sandals";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 793;
			BuyPrice = 2079;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Pagan Shoes)
*
***************************************************************/

namespace Server.Items
{
	public class PaganShoes : Item
	{
		public PaganShoes() : base()
		{
			Id = 14159;
			Resistance[0] = 25;
			Bonding = 2;
			SellPrice = 570;
			AvailableClasses = 0x7FFF;
			Model = 25893;
			ObjectClass = 4;
			SubClass = 1;
			Level = 22;
			ReqLevel = 17;
			Name = "Pagan Shoes";
			Name2 = "Pagan Shoes";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 794;
			BuyPrice = 2852;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Buccaneer's Boots)
*
***************************************************************/

namespace Server.Items
{
	public class BuccaneersBoots : Item
	{
		public BuccaneersBoots() : base()
		{
			Id = 14174;
			Resistance[0] = 22;
			Bonding = 2;
			SellPrice = 368;
			AvailableClasses = 0x7FFF;
			Model = 19950;
			ObjectClass = 4;
			SubClass = 1;
			Level = 19;
			ReqLevel = 14;
			Name = "Buccaneer's Boots";
			Name2 = "Buccaneer's Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 793;
			BuyPrice = 1840;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Watcher's Boots)
*
***************************************************************/

namespace Server.Items
{
	public class WatchersBoots : Item
	{
		public WatchersBoots() : base()
		{
			Id = 14176;
			Resistance[0] = 27;
			Bonding = 2;
			SellPrice = 920;
			AvailableClasses = 0x7FFF;
			Model = 9184;
			ObjectClass = 4;
			SubClass = 1;
			Level = 26;
			ReqLevel = 21;
			Name = "Watcher's Boots";
			Name2 = "Watcher's Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 795;
			BuyPrice = 4600;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Raincaller Boots)
*
***************************************************************/

namespace Server.Items
{
	public class RaincallerBoots : Item
	{
		public RaincallerBoots() : base()
		{
			Id = 14195;
			Resistance[0] = 29;
			Bonding = 2;
			SellPrice = 1252;
			AvailableClasses = 0x7FFF;
			Model = 14645;
			ObjectClass = 4;
			SubClass = 1;
			Level = 29;
			ReqLevel = 24;
			Name = "Raincaller Boots";
			Name2 = "Raincaller Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 796;
			BuyPrice = 6262;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Thistlefur Sandals)
*
***************************************************************/

namespace Server.Items
{
	public class ThistlefurSandals : Item
	{
		public ThistlefurSandals() : base()
		{
			Id = 14196;
			Resistance[0] = 31;
			Bonding = 2;
			SellPrice = 1673;
			AvailableClasses = 0x7FFF;
			Model = 26008;
			ObjectClass = 4;
			SubClass = 1;
			Level = 32;
			ReqLevel = 27;
			Name = "Thistlefur Sandals";
			Name2 = "Thistlefur Sandals";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 797;
			BuyPrice = 8365;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Vital Boots)
*
***************************************************************/

namespace Server.Items
{
	public class VitalBoots : Item
	{
		public VitalBoots() : base()
		{
			Id = 14214;
			Resistance[0] = 32;
			Bonding = 2;
			SellPrice = 2009;
			AvailableClasses = 0x7FFF;
			Model = 9184;
			ObjectClass = 4;
			SubClass = 1;
			Level = 34;
			ReqLevel = 29;
			Name = "Vital Boots";
			Name2 = "Vital Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 798;
			BuyPrice = 10048;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Geomancer's Boots)
*
***************************************************************/

namespace Server.Items
{
	public class GeomancersBoots : Item
	{
		public GeomancersBoots() : base()
		{
			Id = 14218;
			Resistance[0] = 34;
			Bonding = 2;
			SellPrice = 2713;
			AvailableClasses = 0x7FFF;
			Model = 16721;
			ObjectClass = 4;
			SubClass = 1;
			Level = 37;
			ReqLevel = 32;
			Name = "Geomancer's Boots";
			Name2 = "Geomancer's Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 799;
			BuyPrice = 13568;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Embersilk Boots)
*
***************************************************************/

namespace Server.Items
{
	public class EmbersilkBoots : Item
	{
		public EmbersilkBoots() : base()
		{
			Id = 14236;
			Resistance[0] = 35;
			Bonding = 2;
			SellPrice = 2909;
			AvailableClasses = 0x7FFF;
			Model = 26066;
			ObjectClass = 4;
			SubClass = 1;
			Level = 38;
			ReqLevel = 33;
			Name = "Embersilk Boots";
			Name2 = "Embersilk Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 799;
			BuyPrice = 14546;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Darkmist Boots)
*
***************************************************************/

namespace Server.Items
{
	public class DarkmistBoots : Item
	{
		public DarkmistBoots() : base()
		{
			Id = 14238;
			Resistance[0] = 37;
			Bonding = 2;
			SellPrice = 3691;
			AvailableClasses = 0x7FFF;
			Model = 26100;
			ObjectClass = 4;
			SubClass = 1;
			Level = 41;
			ReqLevel = 36;
			Name = "Darkmist Boots";
			Name2 = "Darkmist Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 800;
			BuyPrice = 18457;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Lunar Slippers)
*
***************************************************************/

namespace Server.Items
{
	public class LunarSlippers : Item
	{
		public LunarSlippers() : base()
		{
			Id = 14250;
			Resistance[0] = 38;
			Bonding = 2;
			SellPrice = 3872;
			AvailableClasses = 0x7FFF;
			Model = 26117;
			ObjectClass = 4;
			SubClass = 1;
			Level = 42;
			ReqLevel = 37;
			Name = "Lunar Slippers";
			Name2 = "Lunar Slippers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 800;
			BuyPrice = 19364;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Bloodwoven Boots)
*
***************************************************************/

namespace Server.Items
{
	public class BloodwovenBoots : Item
	{
		public BloodwovenBoots() : base()
		{
			Id = 14259;
			Resistance[0] = 41;
			Bonding = 2;
			SellPrice = 5056;
			AvailableClasses = 0x7FFF;
			Model = 26186;
			ObjectClass = 4;
			SubClass = 1;
			Level = 46;
			ReqLevel = 41;
			Name = "Bloodwoven Boots";
			Name2 = "Bloodwoven Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 802;
			BuyPrice = 25280;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Gaea's Slippers)
*
***************************************************************/

namespace Server.Items
{
	public class GaeasSlippers : Item
	{
		public GaeasSlippers() : base()
		{
			Id = 14269;
			Resistance[0] = 42;
			Bonding = 2;
			SellPrice = 5669;
			AvailableClasses = 0x7FFF;
			Model = 26145;
			ObjectClass = 4;
			SubClass = 1;
			Level = 47;
			ReqLevel = 42;
			Name = "Gaea's Slippers";
			Name2 = "Gaea's Slippers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 802;
			BuyPrice = 28346;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Opulent Boots)
*
***************************************************************/

namespace Server.Items
{
	public class OpulentBoots : Item
	{
		public OpulentBoots() : base()
		{
			Id = 14285;
			Resistance[0] = 45;
			Bonding = 2;
			SellPrice = 6905;
			AvailableClasses = 0x7FFF;
			Model = 26134;
			ObjectClass = 4;
			SubClass = 1;
			Level = 50;
			ReqLevel = 45;
			Name = "Opulent Boots";
			Name2 = "Opulent Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 803;
			BuyPrice = 34527;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Arachnidian Footpads)
*
***************************************************************/

namespace Server.Items
{
	public class ArachnidianFootpads : Item
	{
		public ArachnidianFootpads() : base()
		{
			Id = 14290;
			Resistance[0] = 46;
			Bonding = 2;
			SellPrice = 7725;
			AvailableClasses = 0x7FFF;
			Model = 26206;
			ObjectClass = 4;
			SubClass = 1;
			Level = 51;
			ReqLevel = 46;
			Name = "Arachnidian Footpads";
			Name2 = "Arachnidian Footpads";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 803;
			BuyPrice = 38628;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Bonecaster's Boots)
*
***************************************************************/

namespace Server.Items
{
	public class BonecastersBoots : Item
	{
		public BonecastersBoots() : base()
		{
			Id = 14299;
			Resistance[0] = 48;
			Bonding = 2;
			SellPrice = 8602;
			AvailableClasses = 0x7FFF;
			Model = 26268;
			ObjectClass = 4;
			SubClass = 1;
			Level = 54;
			ReqLevel = 49;
			Name = "Bonecaster's Boots";
			Name2 = "Bonecaster's Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 804;
			BuyPrice = 43013;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Celestial Slippers)
*
***************************************************************/

namespace Server.Items
{
	public class CelestialSlippers : Item
	{
		public CelestialSlippers() : base()
		{
			Id = 14310;
			Resistance[0] = 52;
			Bonding = 2;
			SellPrice = 11615;
			AvailableClasses = 0x7FFF;
			Model = 26261;
			ObjectClass = 4;
			SubClass = 1;
			Level = 58;
			ReqLevel = 53;
			Name = "Celestial Slippers";
			Name2 = "Celestial Slippers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 806;
			BuyPrice = 58076;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Resplendent Boots)
*
***************************************************************/

namespace Server.Items
{
	public class ResplendentBoots : Item
	{
		public ResplendentBoots() : base()
		{
			Id = 14319;
			Resistance[0] = 52;
			Bonding = 2;
			SellPrice = 11401;
			AvailableClasses = 0x7FFF;
			Model = 26285;
			ObjectClass = 4;
			SubClass = 1;
			Level = 59;
			ReqLevel = 54;
			Name = "Resplendent Boots";
			Name2 = "Resplendent Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 806;
			BuyPrice = 57007;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Eternal Boots)
*
***************************************************************/

namespace Server.Items
{
	public class EternalBoots : Item
	{
		public EternalBoots() : base()
		{
			Id = 14329;
			Resistance[0] = 55;
			Bonding = 2;
			SellPrice = 14066;
			AvailableClasses = 0x7FFF;
			Model = 26225;
			ObjectClass = 4;
			SubClass = 1;
			Level = 62;
			ReqLevel = 57;
			Name = "Eternal Boots";
			Name2 = "Eternal Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 807;
			BuyPrice = 70332;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Mystic's Slippers)
*
***************************************************************/

namespace Server.Items
{
	public class MysticsSlippers : Item
	{
		public MysticsSlippers() : base()
		{
			Id = 14364;
			Resistance[0] = 22;
			Bonding = 2;
			SellPrice = 324;
			AvailableClasses = 0x7FFF;
			Model = 16802;
			ObjectClass = 4;
			SubClass = 1;
			Level = 18;
			ReqLevel = 13;
			Name = "Mystic's Slippers";
			Name2 = "Mystic's Slippers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1624;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 30;
			SpiritBonus = 2;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Sanguine Sandals)
*
***************************************************************/

namespace Server.Items
{
	public class SanguineSandals : Item
	{
		public SanguineSandals() : base()
		{
			Id = 14374;
			Resistance[0] = 26;
			Bonding = 2;
			SellPrice = 699;
			AvailableClasses = 0x7FFF;
			Model = 25966;
			ObjectClass = 4;
			SubClass = 1;
			Level = 24;
			ReqLevel = 19;
			Name = "Sanguine Sandals";
			Name2 = "Sanguine Sandals";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3497;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 30;
			SpiritBonus = 4;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Resilient Boots)
*
***************************************************************/

namespace Server.Items
{
	public class ResilientBoots : Item
	{
		public ResilientBoots() : base()
		{
			Id = 14399;
			Resistance[0] = 30;
			Bonding = 2;
			SellPrice = 1465;
			AvailableClasses = 0x7FFF;
			Model = 25995;
			ObjectClass = 4;
			SubClass = 1;
			Level = 31;
			ReqLevel = 26;
			Name = "Resilient Boots";
			Name2 = "Resilient Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7328;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			IqBonus = 8;
			AgilityBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Stonecloth Boots)
*
***************************************************************/

namespace Server.Items
{
	public class StoneclothBoots : Item
	{
		public StoneclothBoots() : base()
		{
			Id = 14408;
			Resistance[0] = 32;
			Bonding = 2;
			SellPrice = 2275;
			AvailableClasses = 0x7FFF;
			Model = 26026;
			ObjectClass = 4;
			SubClass = 1;
			Level = 35;
			ReqLevel = 30;
			Name = "Stonecloth Boots";
			Name2 = "Stonecloth Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11376;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			StaminaBonus = 5;
			IqBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Silksand Boots)
*
***************************************************************/

namespace Server.Items
{
	public class SilksandBoots : Item
	{
		public SilksandBoots() : base()
		{
			Id = 14418;
			Resistance[0] = 35;
			Bonding = 2;
			SellPrice = 3098;
			AvailableClasses = 0x7FFF;
			Model = 26086;
			ObjectClass = 4;
			SubClass = 1;
			Level = 39;
			ReqLevel = 34;
			Name = "Silksand Boots";
			Name2 = "Silksand Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 15490;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			IqBonus = 11;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Windchaser Footpads)
*
***************************************************************/

namespace Server.Items
{
	public class WindchaserFootpads : Item
	{
		public WindchaserFootpads() : base()
		{
			Id = 14428;
			Resistance[0] = 40;
			Bonding = 2;
			SellPrice = 4717;
			AvailableClasses = 0x7FFF;
			Model = 26153;
			ObjectClass = 4;
			SubClass = 1;
			Level = 44;
			ReqLevel = 39;
			Name = "Windchaser Footpads";
			Name2 = "Windchaser Footpads";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 23586;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			StaminaBonus = 2;
			AgilityBonus = 3;
			IqBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Venomshroud Boots)
*
***************************************************************/

namespace Server.Items
{
	public class VenomshroudBoots : Item
	{
		public VenomshroudBoots() : base()
		{
			Id = 14438;
			Resistance[0] = 43;
			Bonding = 2;
			SellPrice = 6192;
			AvailableClasses = 0x7FFF;
			Model = 16634;
			ObjectClass = 4;
			SubClass = 1;
			Level = 48;
			ReqLevel = 43;
			Name = "Venomshroud Boots";
			Name2 = "Venomshroud Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 30961;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			StaminaBonus = 13;
			SpiritBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Highborne Footpads)
*
***************************************************************/

namespace Server.Items
{
	public class HighborneFootpads : Item
	{
		public HighborneFootpads() : base()
		{
			Id = 14447;
			Resistance[0] = 47;
			Bonding = 2;
			SellPrice = 8801;
			AvailableClasses = 0x7FFF;
			Model = 26171;
			ObjectClass = 4;
			SubClass = 1;
			Level = 53;
			ReqLevel = 48;
			Name = "Highborne Footpads";
			Name2 = "Highborne Footpads";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 44008;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			SpiritBonus = 12;
			AgilityBonus = 4;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Elunarian Boots)
*
***************************************************************/

namespace Server.Items
{
	public class ElunarianBoots : Item
	{
		public ElunarianBoots() : base()
		{
			Id = 14458;
			Resistance[0] = 53;
			Bonding = 2;
			SellPrice = 12573;
			AvailableClasses = 0x7FFF;
			Model = 26231;
			ObjectClass = 4;
			SubClass = 1;
			Level = 60;
			ReqLevel = 55;
			Name = "Elunarian Boots";
			Name2 = "Elunarian Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 62867;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			IqBonus = 17;
			SpiritBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Necropile Boots)
*
***************************************************************/

namespace Server.Items
{
	public class NecropileBoots : Item
	{
		public NecropileBoots() : base()
		{
			Id = 14631;
			Resistance[0] = 54;
			Bonding = 1;
			SellPrice = 13542;
			AvailableClasses = 0x7FFF;
			Model = 18863;
			ObjectClass = 4;
			SubClass = 1;
			Level = 61;
			ReqLevel = 56;
			Name = "Necropile Boots";
			Name2 = "Necropile Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 67714;
			Sets = 122;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			StaminaBonus = 16;
			SpiritBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Wingborne Boots)
*
***************************************************************/

namespace Server.Items
{
	public class WingborneBoots : Item
	{
		public WingborneBoots() : base()
		{
			Id = 15104;
			Resistance[0] = 35;
			Bonding = 1;
			SellPrice = 3188;
			AvailableClasses = 0x7FFF;
			Model = 28432;
			ObjectClass = 4;
			SubClass = 1;
			Level = 39;
			Name = "Wingborne Boots";
			Name2 = "Wingborne Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 15940;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			IqBonus = 10;
			SpiritBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Sandcomber Boots)
*
***************************************************************/

namespace Server.Items
{
	public class SandcomberBoots : Item
	{
		public SandcomberBoots() : base()
		{
			Id = 15398;
			Resistance[0] = 17;
			Bonding = 1;
			SellPrice = 108;
			AvailableClasses = 0x7FFF;
			Model = 28246;
			ObjectClass = 4;
			SubClass = 1;
			Level = 14;
			Name = "Sandcomber Boots";
			Name2 = "Sandcomber Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 542;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Lightheel Boots)
*
***************************************************************/

namespace Server.Items
{
	public class LightheelBoots : Item
	{
		public LightheelBoots() : base()
		{
			Id = 15461;
			Resistance[0] = 27;
			Bonding = 1;
			SellPrice = 841;
			AvailableClasses = 0x7FFF;
			Model = 26086;
			ObjectClass = 4;
			SubClass = 1;
			Level = 25;
			Name = "Lightheel Boots";
			Name2 = "Lightheel Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4207;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			SpiritBonus = 4;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Kodo Rustler Boots)
*
***************************************************************/

namespace Server.Items
{
	public class KodoRustlerBoots : Item
	{
		public KodoRustlerBoots() : base()
		{
			Id = 15697;
			Resistance[0] = 35;
			Bonding = 1;
			SellPrice = 2825;
			AvailableClasses = 0x7FFF;
			Model = 26415;
			ObjectClass = 4;
			SubClass = 1;
			Level = 38;
			Name = "Kodo Rustler Boots";
			Name2 = "Kodo Rustler Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 14129;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			SpiritBonus = 8;
			IqBonus = 5;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Mooncloth Boots)
*
***************************************************************/

namespace Server.Items
{
	public class MoonclothBoots : Item
	{
		public MoonclothBoots() : base()
		{
			Id = 15802;
			Resistance[0] = 55;
			Bonding = 2;
			SellPrice = 11648;
			AvailableClasses = 0x7FFF;
			Model = 17256;
			ObjectClass = 4;
			SubClass = 1;
			Level = 56;
			ReqLevel = 51;
			Name = "Mooncloth Boots";
			Name2 = "Mooncloth Boots";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 58243;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 40;
			SpiritBonus = 14;
			IqBonus = 13;
			StaminaBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Knight-Lieutenant's Silk Boots)
*
***************************************************************/

namespace Server.Items
{
	public class KnightLieutenantsSilkBoots : Item
	{
		public KnightLieutenantsSilkBoots() : base()
		{
			Id = 16369;
			Resistance[0] = 61;
			Bonding = 1;
			SellPrice = 8416;
			AvailableClasses = 0x80;
			Model = 31063;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Knight-Lieutenant's Silk Boots";
			Name2 = "Knight-Lieutenant's Silk Boots";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 42081;
			Sets = 343;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 40;
			Flags = 32768;
			SetSpell( 9417 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 16;
			SpiritBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Marshal's Silk Footwraps)
*
***************************************************************/

namespace Server.Items
{
	public class MarshalsSilkFootwraps : Item
	{
		public MarshalsSilkFootwraps() : base()
		{
			Id = 16437;
			Resistance[0] = 69;
			Bonding = 1;
			SellPrice = 13076;
			AvailableClasses = 0x80;
			Model = 30337;
			ObjectClass = 4;
			SubClass = 1;
			Level = 65;
			ReqLevel = 60;
			Name = "Marshal's Silk Footwraps";
			Name2 = "Marshal's Silk Footwraps";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 65383;
			Sets = 388;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 50;
			Flags = 32768;
			SetSpell( 9342 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 21;
			StaminaBonus = 21;
		}
	}
}


/**************************************************************
*
*				(Blood Guard's Silk Footwraps)
*
***************************************************************/

namespace Server.Items
{
	public class BloodGuardsSilkFootwraps : Item
	{
		public BloodGuardsSilkFootwraps() : base()
		{
			Id = 16485;
			Resistance[0] = 61;
			Bonding = 1;
			SellPrice = 8511;
			AvailableClasses = 0x80;
			Model = 31097;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Blood Guard's Silk Footwraps";
			Name2 = "Blood Guard's Silk Footwraps";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 42556;
			Sets = 341;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 40;
			Flags = 32768;
			SetSpell( 9417 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 16;
			SpiritBonus = 15;
		}
	}
}


/**************************************************************
*
*				(General's Silk Boots)
*
***************************************************************/

namespace Server.Items
{
	public class GeneralsSilkBoots : Item
	{
		public GeneralsSilkBoots() : base()
		{
			Id = 16539;
			Resistance[0] = 69;
			Bonding = 1;
			SellPrice = 12563;
			AvailableClasses = 0x80;
			Model = 30344;
			ObjectClass = 4;
			SubClass = 1;
			Level = 65;
			ReqLevel = 60;
			Name = "General's Silk Boots";
			Name2 = "General's Silk Boots";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 62818;
			Sets = 387;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 50;
			Flags = 32768;
			SetSpell( 9342 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 21;
			StaminaBonus = 21;
		}
	}
}


/**************************************************************
*
*				(Magister's Boots)
*
***************************************************************/

namespace Server.Items
{
	public class MagistersBoots : Item
	{
		public MagistersBoots() : base()
		{
			Id = 16682;
			Resistance[0] = 58;
			Bonding = 1;
			SellPrice = 14582;
			AvailableClasses = 0x7FFF;
			Model = 29594;
			ObjectClass = 4;
			SubClass = 1;
			Level = 59;
			ReqLevel = 54;
			Name = "Magister's Boots";
			Name2 = "Magister's Boots";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 72914;
			Sets = 181;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 40;
			IqBonus = 14;
			SpiritBonus = 14;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Devout Sandals)
*
***************************************************************/

namespace Server.Items
{
	public class DevoutSandals : Item
	{
		public DevoutSandals() : base()
		{
			Id = 16691;
			Resistance[0] = 58;
			Bonding = 1;
			SellPrice = 14005;
			AvailableClasses = 0x7FFF;
			Model = 30430;
			ObjectClass = 4;
			SubClass = 1;
			Level = 59;
			ReqLevel = 54;
			Name = "Devout Sandals";
			Name2 = "Devout Sandals";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 70029;
			Sets = 182;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 40;
			IqBonus = 17;
			SpiritBonus = 10;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Dreadmist Sandals)
*
***************************************************************/

namespace Server.Items
{
	public class DreadmistSandals : Item
	{
		public DreadmistSandals() : base()
		{
			Id = 16704;
			Resistance[0] = 58;
			Bonding = 1;
			SellPrice = 13639;
			AvailableClasses = 0x7FFF;
			Model = 29799;
			ObjectClass = 4;
			SubClass = 1;
			Level = 59;
			ReqLevel = 54;
			Name = "Dreadmist Sandals";
			Name2 = "Dreadmist Sandals";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 68196;
			Sets = 183;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 40;
			StaminaBonus = 17;
			IqBonus = 10;
			SpiritBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Arcanist Boots)
*
***************************************************************/

namespace Server.Items
{
	public class ArcanistBoots : Item
	{
		public ArcanistBoots() : base()
		{
			Id = 16800;
			Resistance[0] = 70;
			Bonding = 1;
			SellPrice = 25885;
			AvailableClasses = 0x80;
			Model = 30587;
			ObjectClass = 4;
			SubClass = 1;
			Level = 66;
			ReqLevel = 60;
			Name = "Arcanist Boots";
			Name2 = "Arcanist Boots";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 129425;
			Sets = 201;
			Resistance[5] = 10;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 50;
			SetSpell( 18384 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 9402 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 15;
			IqBonus = 14;
			StaminaBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Felheart Slippers)
*
***************************************************************/

namespace Server.Items
{
	public class FelheartSlippers : Item
	{
		public FelheartSlippers() : base()
		{
			Id = 16803;
			Resistance[0] = 70;
			Bonding = 1;
			SellPrice = 26181;
			AvailableClasses = 0x100;
			Model = 31975;
			ObjectClass = 4;
			SubClass = 1;
			Level = 66;
			ReqLevel = 60;
			Name = "Felheart Slippers";
			Name2 = "Felheart Slippers";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 130905;
			Sets = 203;
			Resistance[5] = 7;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 50;
			SetSpell( 9412 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 10;
			IqBonus = 8;
			StaminaBonus = 27;
		}
	}
}


/**************************************************************
*
*				(Boots of Prophecy)
*
***************************************************************/

namespace Server.Items
{
	public class BootsOfProphecy : Item
	{
		public BootsOfProphecy() : base()
		{
			Id = 16811;
			Resistance[0] = 70;
			Bonding = 1;
			SellPrice = 26962;
			AvailableClasses = 0x10;
			Model = 31718;
			ObjectClass = 4;
			SubClass = 1;
			Level = 66;
			ReqLevel = 60;
			Name = "Boots of Prophecy";
			Name2 = "Boots of Prophecy";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 134811;
			Sets = 202;
			Resistance[5] = 7;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 50;
			SetSpell( 9406 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 18;
			IqBonus = 15;
			StaminaBonus = 17;
		}
	}
}


/**************************************************************
*
*				(Netherwind Boots)
*
***************************************************************/

namespace Server.Items
{
	public class NetherwindBoots : Item
	{
		public NetherwindBoots() : base()
		{
			Id = 16912;
			Resistance[0] = 80;
			Bonding = 1;
			SellPrice = 42007;
			AvailableClasses = 0x80;
			Model = 29767;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 1;
			Level = 76;
			ReqLevel = 60;
			Name = "Netherwind Boots";
			Name2 = "Netherwind Boots";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 210038;
			Sets = 210;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 50;
			SetSpell( 14254 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 20;
			IqBonus = 16;
			StaminaBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Boots of Transcendence)
*
***************************************************************/

namespace Server.Items
{
	public class BootsOfTranscendence : Item
	{
		public BootsOfTranscendence() : base()
		{
			Id = 16919;
			Resistance[0] = 80;
			Bonding = 1;
			SellPrice = 43123;
			AvailableClasses = 0x10;
			Model = 29767;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 1;
			Level = 76;
			ReqLevel = 60;
			Name = "Boots of Transcendence";
			Name2 = "Boots of Transcendence";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 215619;
			Sets = 211;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 50;
			SetSpell( 18029 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 17;
			IqBonus = 17;
			StaminaBonus = 17;
		}
	}
}


/**************************************************************
*
*				(Nemesis Boots)
*
***************************************************************/

namespace Server.Items
{
	public class NemesisBoots : Item
	{
		public NemesisBoots() : base()
		{
			Id = 16927;
			Resistance[0] = 80;
			Bonding = 1;
			SellPrice = 45551;
			AvailableClasses = 0x100;
			Model = 29853;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 1;
			Level = 76;
			ReqLevel = 60;
			Name = "Nemesis Boots";
			Name2 = "Nemesis Boots";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 227758;
			Sets = 212;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 50;
			SetSpell( 9346 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 13;
			IqBonus = 10;
			StaminaBonus = 25;
		}
	}
}


/**************************************************************
*
*				(Windseeker Boots)
*
***************************************************************/

namespace Server.Items
{
	public class WindseekerBoots : Item
	{
		public WindseekerBoots() : base()
		{
			Id = 16985;
			Resistance[0] = 27;
			Bonding = 1;
			SellPrice = 847;
			AvailableClasses = 0x7FFF;
			Model = 26026;
			ObjectClass = 4;
			SubClass = 1;
			Level = 25;
			Name = "Windseeker Boots";
			Name2 = "Windseeker Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4238;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Knight-Lieutenant's Dreadweave Boots)
*
***************************************************************/

namespace Server.Items
{
	public class KnightLieutenantsDreadweaveBoots : Item
	{
		public KnightLieutenantsDreadweaveBoots() : base()
		{
			Id = 17562;
			Resistance[0] = 61;
			Bonding = 1;
			SellPrice = 8736;
			AvailableClasses = 0x100;
			Model = 31059;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Knight-Lieutenant's Dreadweave Boots";
			Name2 = "Knight-Lieutenant's Dreadweave Boots";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 43683;
			Sets = 346;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 40;
			Flags = 32768;
			SetSpell( 14254 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 15;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Blood Guard's Dreadweave Boots)
*
***************************************************************/

namespace Server.Items
{
	public class BloodGuardsDreadweaveBoots : Item
	{
		public BloodGuardsDreadweaveBoots() : base()
		{
			Id = 17576;
			Resistance[0] = 61;
			Bonding = 1;
			SellPrice = 8544;
			AvailableClasses = 0x100;
			Model = 31026;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Blood Guard's Dreadweave Boots";
			Name2 = "Blood Guard's Dreadweave Boots";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 42724;
			Sets = 345;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 40;
			Flags = 32768;
			SetSpell( 9417 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 16;
			SpiritBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Marshal's Dreadweave Boots)
*
***************************************************************/

namespace Server.Items
{
	public class MarshalsDreadweaveBoots : Item
	{
		public MarshalsDreadweaveBoots() : base()
		{
			Id = 17583;
			Resistance[0] = 69;
			Bonding = 1;
			SellPrice = 12887;
			AvailableClasses = 0x100;
			Model = 30337;
			ObjectClass = 4;
			SubClass = 1;
			Level = 65;
			ReqLevel = 60;
			Name = "Marshal's Dreadweave Boots";
			Name2 = "Marshal's Dreadweave Boots";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 64437;
			Sets = 392;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 50;
			Flags = 32768;
			SetSpell( 9342 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 21;
			StaminaBonus = 21;
		}
	}
}


/**************************************************************
*
*				(General's Dreadweave Boots)
*
***************************************************************/

namespace Server.Items
{
	public class GeneralsDreadweaveBoots : Item
	{
		public GeneralsDreadweaveBoots() : base()
		{
			Id = 17586;
			Resistance[0] = 69;
			Bonding = 1;
			SellPrice = 12093;
			AvailableClasses = 0x100;
			Model = 30344;
			ObjectClass = 4;
			SubClass = 1;
			Level = 65;
			ReqLevel = 60;
			Name = "General's Dreadweave Boots";
			Name2 = "General's Dreadweave Boots";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 60469;
			Sets = 391;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 50;
			Flags = 32768;
			SetSpell( 9342 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 21;
			StaminaBonus = 21;
		}
	}
}


/**************************************************************
*
*				(Knight-Lieutenant's Satin Boots)
*
***************************************************************/

namespace Server.Items
{
	public class KnightLieutenantsSatinBoots : Item
	{
		public KnightLieutenantsSatinBoots() : base()
		{
			Id = 17594;
			Resistance[0] = 61;
			Bonding = 1;
			SellPrice = 8481;
			AvailableClasses = 0x10;
			Model = 31061;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Knight-Lieutenant's Satin Boots";
			Name2 = "Knight-Lieutenant's Satin Boots";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 42405;
			Sets = 344;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 40;
			Flags = 32768;
			SetSpell( 9417 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 16;
			SpiritBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Marshal's Satin Sandals)
*
***************************************************************/

namespace Server.Items
{
	public class MarshalsSatinSandals : Item
	{
		public MarshalsSatinSandals() : base()
		{
			Id = 17607;
			Resistance[0] = 69;
			Bonding = 1;
			SellPrice = 12138;
			AvailableClasses = 0x10;
			Model = 30337;
			ObjectClass = 4;
			SubClass = 1;
			Level = 65;
			ReqLevel = 60;
			Name = "Marshal's Satin Sandals";
			Name2 = "Marshal's Satin Sandals";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 60691;
			Sets = 389;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 50;
			Flags = 32768;
			SetSpell( 9342 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 21;
			StaminaBonus = 21;
		}
	}
}


/**************************************************************
*
*				(Blood Guard's Satin Boots)
*
***************************************************************/

namespace Server.Items
{
	public class BloodGuardsSatinBoots : Item
	{
		public BloodGuardsSatinBoots() : base()
		{
			Id = 17616;
			Resistance[0] = 61;
			Bonding = 1;
			SellPrice = 8772;
			AvailableClasses = 0x10;
			Model = 31027;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Blood Guard's Satin Boots";
			Name2 = "Blood Guard's Satin Boots";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 43860;
			Sets = 342;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 40;
			Flags = 32768;
			SetSpell( 9417 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 16;
			SpiritBonus = 15;
		}
	}
}


/**************************************************************
*
*				(General's Satin Boots)
*
***************************************************************/

namespace Server.Items
{
	public class GeneralsSatinBoots : Item
	{
		public GeneralsSatinBoots() : base()
		{
			Id = 17618;
			Resistance[0] = 69;
			Bonding = 1;
			SellPrice = 12987;
			AvailableClasses = 0x10;
			Model = 30344;
			ObjectClass = 4;
			SubClass = 1;
			Level = 65;
			ReqLevel = 60;
			Name = "General's Satin Boots";
			Name2 = "General's Satin Boots";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 64938;
			Sets = 390;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 50;
			Flags = 32768;
			SetSpell( 9342 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 21;
			SpiritBonus = 21;
		}
	}
}


/**************************************************************
*
*				(Vinerot Sandals)
*
***************************************************************/

namespace Server.Items
{
	public class VinerotSandals : Item
	{
		public VinerotSandals() : base()
		{
			Id = 17748;
			Resistance[0] = 50;
			Bonding = 1;
			SellPrice = 9107;
			AvailableClasses = 0x7FFF;
			Model = 29927;
			ObjectClass = 4;
			SubClass = 1;
			Level = 51;
			ReqLevel = 46;
			Name = "Vinerot Sandals";
			Name2 = "Vinerot Sandals";
			Resistance[3] = 12;
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 45539;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 40;
			SpiritBonus = 12;
			IqBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Dragonrider Boots)
*
***************************************************************/

namespace Server.Items
{
	public class DragonriderBoots : Item
	{
		public DragonriderBoots() : base()
		{
			Id = 18102;
			Resistance[0] = 61;
			Bonding = 1;
			SellPrice = 17158;
			AvailableClasses = 0x7FFF;
			Model = 14617;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Dragonrider Boots";
			Name2 = "Dragonrider Boots";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 85794;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 40;
			SetSpell( 9346 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 16;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Phasing Boots)
*
***************************************************************/

namespace Server.Items
{
	public class PhasingBoots : Item
	{
		public PhasingBoots() : base()
		{
			Id = 18295;
			Resistance[0] = 54;
			Bonding = 1;
			SellPrice = 11582;
			AvailableClasses = 0x7FFF;
			Model = 30639;
			ObjectClass = 4;
			SubClass = 1;
			Level = 55;
			ReqLevel = 50;
			Name = "Phasing Boots";
			Name2 = "Phasing Boots";
			Quality = 3;
			AvailableRaces = 0x1FF;
			Extra = 3325;
			BuyPrice = 57913;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 40;
			SpiritBonus = 6;
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Riptide Shoes)
*
***************************************************************/

namespace Server.Items
{
	public class RiptideShoes : Item
	{
		public RiptideShoes() : base()
		{
			Id = 18307;
			Resistance[0] = 52;
			Bonding = 1;
			SellPrice = 11163;
			AvailableClasses = 0x7FFF;
			Model = 30667;
			ObjectClass = 4;
			SubClass = 1;
			Level = 58;
			ReqLevel = 53;
			Name = "Riptide Shoes";
			Name2 = "Riptide Shoes";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 55815;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			SetSpell( 9306 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Boots of the Full Moon)
*
***************************************************************/

namespace Server.Items
{
	public class BootsOfTheFullMoon : Item
	{
		public BootsOfTheFullMoon() : base()
		{
			Id = 18507;
			Resistance[0] = 60;
			Bonding = 1;
			SellPrice = 15692;
			AvailableClasses = 0x7FFF;
			Model = 19921;
			ObjectClass = 4;
			SubClass = 1;
			Level = 62;
			ReqLevel = 57;
			Name = "Boots of the Full Moon";
			Name2 = "Boots of the Full Moon";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 78460;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 40;
			SetSpell( 9315 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 12;
			IqBonus = 9;
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Coldstone Slippers)
*
***************************************************************/

namespace Server.Items
{
	public class ColdstoneSlippers : Item
	{
		public ColdstoneSlippers() : base()
		{
			Id = 18697;
			Resistance[0] = 54;
			Bonding = 1;
			SellPrice = 10867;
			AvailableClasses = 0x7FFF;
			Model = 31140;
			ObjectClass = 4;
			SubClass = 1;
			Level = 55;
			ReqLevel = 50;
			Name = "Coldstone Slippers";
			Name2 = "Coldstone Slippers";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 54339;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 40;
			SetSpell( 21618 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 14;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Maleki's Footwraps)
*
***************************************************************/

namespace Server.Items
{
	public class MalekisFootwraps : Item
	{
		public MalekisFootwraps() : base()
		{
			Id = 18735;
			Resistance[0] = 60;
			Bonding = 1;
			SellPrice = 17253;
			AvailableClasses = 0x7FFF;
			Model = 31188;
			ObjectClass = 4;
			SubClass = 1;
			Level = 62;
			ReqLevel = 57;
			Name = "Maleki's Footwraps";
			Name2 = "Maleki's Footwraps";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 86266;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 40;
			SetSpell( 18009 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 9;
			SpiritBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Argent Boots)
*
***************************************************************/

namespace Server.Items
{
	public class ArgentBoots : Item
	{
		public ArgentBoots() : base()
		{
			Id = 19056;
			Resistance[0] = 57;
			Bonding = 2;
			SellPrice = 12941;
			AvailableClasses = 0x7FFF;
			Model = 31557;
			ObjectClass = 4;
			SubClass = 1;
			Level = 58;
			ReqLevel = 53;
			Name = "Argent Boots";
			Name2 = "Argent Boots";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 64705;
			Resistance[5] = 4;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = -1;
			Durability = 40;
			StaminaBonus = 21;
			IqBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Snowblind Shoes)
*
***************************************************************/

namespace Server.Items
{
	public class SnowblindShoes : Item
	{
		public SnowblindShoes() : base()
		{
			Id = 19131;
			Resistance[0] = 73;
			Bonding = 1;
			SellPrice = 29746;
			AvailableClasses = 0x7FFF;
			Model = 31649;
			ObjectClass = 4;
			SubClass = 1;
			Level = 69;
			ReqLevel = 60;
			Name = "Snowblind Shoes";
			Name2 = "Snowblind Shoes";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 148730;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 50;
			SetSpell( 17367 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 21363 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 10;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Boots of Pure Thought)
*
***************************************************************/

namespace Server.Items
{
	public class BootsOfPureThought : Item
	{
		public BootsOfPureThought() : base()
		{
			Id = 19437;
			Resistance[0] = 74;
			Bonding = 1;
			SellPrice = 32075;
			AvailableClasses = 0x7FFF;
			Model = 31982;
			ObjectClass = 4;
			SubClass = 1;
			Level = 70;
			ReqLevel = 60;
			Name = "Boots of Pure Thought";
			Name2 = "Boots of Pure Thought";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 160379;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 50;
			SetSpell( 18039 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 12;
			IqBonus = 12;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Ringo's Blizzard Boots)
*
***************************************************************/

namespace Server.Items
{
	public class RingosBlizzardBoots : Item
	{
		public RingosBlizzardBoots() : base()
		{
			Id = 19438;
			Resistance[0] = 75;
			Bonding = 1;
			SellPrice = 33805;
			AvailableClasses = 0x7FFF;
			Model = 31985;
			ObjectClass = 4;
			SubClass = 1;
			Level = 71;
			ReqLevel = 60;
			Name = "Ringo's Blizzard Boots";
			Name2 = "Ringo's Blizzard Boots";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 169028;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 7;
			Durability = 50;
			SetSpell( 17900 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 23727 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 12;
			StaminaBonus = 11;
		}
	}
}


