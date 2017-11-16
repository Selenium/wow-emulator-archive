/**************************************************************
*
*		Made by fulgas (fulgas@gmail.com)
*
*  WowwoW Item Designer ( 2005/8/23 - 10:05:21 )
*
***************************************************************/

using System;
using System.Collections;

/***************************************************************/

/**************************************************************
*
*				(Tattered Cloth Vest)
*
***************************************************************/

namespace Server.Items
{
	public class TatteredClothVest : Item
	{
		public TatteredClothVest() : base()
		{
			Id = 193;
			Resistance[0] = 10;
			SellPrice = 9;
			AvailableClasses = 0x7FFF;
			Model = 16579;
			ObjectClass = 4;
			SubClass = 1;
			Level = 5;
			ReqLevel = 1;
			Name = "Tattered Cloth Vest";
			Name2 = "Tattered Cloth Vest";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 48;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Thick Cloth Vest)
*
***************************************************************/

namespace Server.Items
{
	public class ThickClothVest : Item
	{
		public ThickClothVest() : base()
		{
			Id = 200;
			Resistance[0] = 34;
			SellPrice = 454;
			AvailableClasses = 0x7FFF;
			Model = 16777;
			ObjectClass = 4;
			SubClass = 1;
			Level = 22;
			ReqLevel = 17;
			Name = "Thick Cloth Vest";
			Name2 = "Thick Cloth Vest";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2270;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Knitted Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class KnittedTunic : Item
	{
		public KnittedTunic() : base()
		{
			Id = 795;
			Resistance[0] = 18;
			SellPrice = 56;
			AvailableClasses = 0x7FFF;
			Model = 14154;
			ObjectClass = 4;
			SubClass = 1;
			Level = 10;
			ReqLevel = 5;
			Name = "Knitted Tunic";
			Name2 = "Knitted Tunic";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 280;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Heavy Weave Armor)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyWeaveArmor : Item
	{
		public HeavyWeaveArmor() : base()
		{
			Id = 837;
			Resistance[0] = 29;
			SellPrice = 224;
			AvailableClasses = 0x7FFF;
			Model = 14466;
			ObjectClass = 4;
			SubClass = 1;
			Level = 17;
			ReqLevel = 12;
			Name = "Heavy Weave Armor";
			Name2 = "Heavy Weave Armor";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1124;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Patchwork Armor)
*
***************************************************************/

namespace Server.Items
{
	public class PatchworkArmor : Item
	{
		public PatchworkArmor() : base()
		{
			Id = 1433;
			Resistance[0] = 13;
			SellPrice = 14;
			AvailableClasses = 0x7FFF;
			Model = 16795;
			ObjectClass = 4;
			SubClass = 1;
			Level = 7;
			ReqLevel = 2;
			Name = "Patchwork Armor";
			Name2 = "Patchwork Armor";
			AvailableRaces = 0x1FF;
			BuyPrice = 72;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Tree Bark Jacket)
*
***************************************************************/

namespace Server.Items
{
	public class TreeBarkJacket : Item
	{
		public TreeBarkJacket() : base()
		{
			Id = 1486;
			Resistance[0] = 42;
			Bonding = 2;
			SellPrice = 1202;
			AvailableClasses = 0x7FFF;
			Model = 9889;
			ObjectClass = 4;
			SubClass = 1;
			Level = 24;
			ReqLevel = 19;
			Name = "Tree Bark Jacket";
			Name2 = "Tree Bark Jacket";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 6012;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 75;
			StaminaBonus = 6;
			SpiritBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Calico Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class CalicoTunic : Item
	{
		public CalicoTunic() : base()
		{
			Id = 1501;
			Resistance[0] = 22;
			SellPrice = 80;
			AvailableClasses = 0x7FFF;
			Model = 16551;
			ObjectClass = 4;
			SubClass = 1;
			Level = 13;
			ReqLevel = 8;
			Name = "Calico Tunic";
			Name2 = "Calico Tunic";
			AvailableRaces = 0x1FF;
			BuyPrice = 402;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Canvas Vest)
*
***************************************************************/

namespace Server.Items
{
	public class CanvasVest : Item
	{
		public CanvasVest() : base()
		{
			Id = 1770;
			Resistance[0] = 27;
			SellPrice = 143;
			AvailableClasses = 0x7FFF;
			Model = 14378;
			ObjectClass = 4;
			SubClass = 1;
			Level = 17;
			ReqLevel = 12;
			Name = "Canvas Vest";
			Name2 = "Canvas Vest";
			AvailableRaces = 0x1FF;
			BuyPrice = 719;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Brocade Vest)
*
***************************************************************/

namespace Server.Items
{
	public class BrocadeVest : Item
	{
		public BrocadeVest() : base()
		{
			Id = 1778;
			Resistance[0] = 33;
			SellPrice = 337;
			AvailableClasses = 0x7FFF;
			Model = 14377;
			ObjectClass = 4;
			SubClass = 1;
			Level = 23;
			ReqLevel = 18;
			Name = "Brocade Vest";
			Name2 = "Brocade Vest";
			AvailableRaces = 0x1FF;
			BuyPrice = 1685;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Cross-stitched Vest)
*
***************************************************************/

namespace Server.Items
{
	public class CrossStitchedVest : Item
	{
		public CrossStitchedVest() : base()
		{
			Id = 1786;
			Resistance[0] = 38;
			SellPrice = 683;
			AvailableClasses = 0x7FFF;
			Model = 14376;
			ObjectClass = 4;
			SubClass = 1;
			Level = 29;
			ReqLevel = 24;
			Name = "Cross-stitched Vest";
			Name2 = "Cross-stitched Vest";
			AvailableRaces = 0x1FF;
			BuyPrice = 3419;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Thin Cloth Armor)
*
***************************************************************/

namespace Server.Items
{
	public class ThinClothArmor : Item
	{
		public ThinClothArmor() : base()
		{
			Id = 2121;
			Resistance[0] = 10;
			SellPrice = 10;
			AvailableClasses = 0x7FFF;
			Model = 16575;
			ObjectClass = 4;
			SubClass = 1;
			Level = 5;
			ReqLevel = 1;
			Name = "Thin Cloth Armor";
			Name2 = "Thin Cloth Armor";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 50;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Padded Armor)
*
***************************************************************/

namespace Server.Items
{
	public class PaddedArmor : Item
	{
		public PaddedArmor() : base()
		{
			Id = 2160;
			Resistance[0] = 39;
			SellPrice = 832;
			AvailableClasses = 0x7FFF;
			Model = 14477;
			ObjectClass = 4;
			SubClass = 1;
			Level = 27;
			ReqLevel = 22;
			Name = "Padded Armor";
			Name2 = "Padded Armor";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 4163;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Nightwalker Armor)
*
***************************************************************/

namespace Server.Items
{
	public class NightwalkerArmor : Item
	{
		public NightwalkerArmor() : base()
		{
			Id = 2234;
			Resistance[0] = 43;
			Bonding = 2;
			SellPrice = 1806;
			AvailableClasses = 0x7FFF;
			Model = 8677;
			ObjectClass = 4;
			SubClass = 1;
			Level = 30;
			ReqLevel = 25;
			Name = "Nightwalker Armor";
			Name2 = "Nightwalker Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 9033;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
			StrBonus = 9;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Woven Vest)
*
***************************************************************/

namespace Server.Items
{
	public class WovenVest : Item
	{
		public WovenVest() : base()
		{
			Id = 2364;
			Resistance[0] = 18;
			SellPrice = 59;
			AvailableClasses = 0x7FFF;
			Model = 14459;
			ObjectClass = 4;
			SubClass = 1;
			Level = 10;
			ReqLevel = 5;
			Name = "Woven Vest";
			Name2 = "Woven Vest";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 296;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Russet Vest)
*
***************************************************************/

namespace Server.Items
{
	public class RussetVest : Item
	{
		public RussetVest() : base()
		{
			Id = 2429;
			Resistance[0] = 46;
			SellPrice = 2027;
			AvailableClasses = 0x7FFF;
			Model = 14484;
			ObjectClass = 4;
			SubClass = 1;
			Level = 37;
			ReqLevel = 32;
			Name = "Russet Vest";
			Name2 = "Russet Vest";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 10138;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Embroidered Armor)
*
***************************************************************/

namespace Server.Items
{
	public class EmbroideredArmor : Item
	{
		public EmbroideredArmor() : base()
		{
			Id = 2435;
			Resistance[0] = 62;
			SellPrice = 5536;
			AvailableClasses = 0x7FFF;
			Model = 16769;
			ObjectClass = 4;
			SubClass = 1;
			Level = 50;
			ReqLevel = 45;
			Name = "Embroidered Armor";
			Name2 = "Embroidered Armor";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 27683;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Brown Linen Vest)
*
***************************************************************/

namespace Server.Items
{
	public class BrownLinenVest : Item
	{
		public BrownLinenVest() : base()
		{
			Id = 2568;
			Resistance[0] = 15;
			SellPrice = 31;
			AvailableClasses = 0x7FFF;
			Model = 17125;
			ObjectClass = 4;
			SubClass = 1;
			Level = 8;
			ReqLevel = 3;
			Name = "Brown Linen Vest";
			Name2 = "Brown Linen Vest";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 156;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Barbaric Linen Vest)
*
***************************************************************/

namespace Server.Items
{
	public class BarbaricLinenVest : Item
	{
		public BarbaricLinenVest() : base()
		{
			Id = 2578;
			Resistance[0] = 26;
			Bonding = 2;
			SellPrice = 224;
			AvailableClasses = 0x7FFF;
			Model = 10891;
			ObjectClass = 4;
			SubClass = 1;
			Level = 14;
			ReqLevel = 9;
			Name = "Barbaric Linen Vest";
			Name2 = "Barbaric Linen Vest";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1120;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 50;
			StaminaBonus = 2;
			IqBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Green Woolen Vest)
*
***************************************************************/

namespace Server.Items
{
	public class GreenWoolenVest : Item
	{
		public GreenWoolenVest() : base()
		{
			Id = 2582;
			Resistance[0] = 29;
			SellPrice = 216;
			AvailableClasses = 0x7FFF;
			Model = 12394;
			ObjectClass = 4;
			SubClass = 1;
			Level = 17;
			ReqLevel = 12;
			Name = "Green Woolen Vest";
			Name2 = "Green Woolen Vest";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1082;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Journeyman's Vest)
*
***************************************************************/

namespace Server.Items
{
	public class JourneymansVest : Item
	{
		public JourneymansVest() : base()
		{
			Id = 2957;
			Resistance[0] = 21;
			Bonding = 2;
			SellPrice = 119;
			AvailableClasses = 0x7FFF;
			Model = 14499;
			ObjectClass = 4;
			SubClass = 1;
			Level = 11;
			ReqLevel = 6;
			Name = "Journeyman's Vest";
			Name2 = "Journeyman's Vest";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 596;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			IqBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Spellbinder Vest)
*
***************************************************************/

namespace Server.Items
{
	public class SpellbinderVest : Item
	{
		public SpellbinderVest() : base()
		{
			Id = 2969;
			Resistance[0] = 30;
			Bonding = 2;
			SellPrice = 381;
			AvailableClasses = 0x7FFF;
			Model = 14524;
			ObjectClass = 4;
			SubClass = 1;
			Level = 17;
			ReqLevel = 12;
			Name = "Spellbinder Vest";
			Name2 = "Spellbinder Vest";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1909;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 55;
			SpiritBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Flax Vest)
*
***************************************************************/

namespace Server.Items
{
	public class FlaxVest : Item
	{
		public FlaxVest() : base()
		{
			Id = 3270;
			Resistance[0] = 10;
			Bonding = 1;
			SellPrice = 10;
			AvailableClasses = 0x7FFF;
			Model = 16585;
			ObjectClass = 4;
			SubClass = 1;
			Level = 5;
			Name = "Flax Vest";
			Name2 = "Flax Vest";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 51;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Ancestral Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class AncestralTunic : Item
	{
		public AncestralTunic() : base()
		{
			Id = 3292;
			Resistance[0] = 25;
			Bonding = 2;
			SellPrice = 203;
			AvailableClasses = 0x7FFF;
			Model = 14513;
			ObjectClass = 4;
			SubClass = 1;
			Level = 13;
			ReqLevel = 8;
			Name = "Ancestral Tunic";
			Name2 = "Ancestral Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1016;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 50;
			SpiritBonus = 2;
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Barbaric Cloth Vest)
*
***************************************************************/

namespace Server.Items
{
	public class BarbaricClothVest : Item
	{
		public BarbaricClothVest() : base()
		{
			Id = 3310;
			Resistance[0] = 32;
			Bonding = 2;
			SellPrice = 442;
			AvailableClasses = 0x7FFF;
			Model = 16590;
			ObjectClass = 4;
			SubClass = 1;
			Level = 18;
			ReqLevel = 13;
			Name = "Barbaric Cloth Vest";
			Name2 = "Barbaric Cloth Vest";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2211;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 55;
			SpiritBonus = 2;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Grunt Vest)
*
***************************************************************/

namespace Server.Items
{
	public class GruntVest : Item
	{
		public GruntVest() : base()
		{
			Id = 3752;
			Resistance[0] = 36;
			Bonding = 1;
			SellPrice = 745;
			AvailableClasses = 0x7FFF;
			Model = 8666;
			ObjectClass = 4;
			SubClass = 1;
			Level = 22;
			Name = "Grunt Vest";
			Name2 = "Grunt Vest";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3729;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 60;
			StrBonus = 5;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Interlaced Vest)
*
***************************************************************/

namespace Server.Items
{
	public class InterlacedVest : Item
	{
		public InterlacedVest() : base()
		{
			Id = 3799;
			Resistance[0] = 44;
			SellPrice = 1460;
			AvailableClasses = 0x7FFF;
			Model = 16568;
			ObjectClass = 4;
			SubClass = 1;
			Level = 37;
			ReqLevel = 32;
			Name = "Interlaced Vest";
			Name2 = "Interlaced Vest";
			AvailableRaces = 0x1FF;
			BuyPrice = 7304;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Crochet Vest)
*
***************************************************************/

namespace Server.Items
{
	public class CrochetVest : Item
	{
		public CrochetVest() : base()
		{
			Id = 3943;
			Resistance[0] = 51;
			SellPrice = 2244;
			AvailableClasses = 0x7FFF;
			Model = 16718;
			ObjectClass = 4;
			SubClass = 1;
			Level = 43;
			ReqLevel = 38;
			Name = "Crochet Vest";
			Name2 = "Crochet Vest";
			AvailableRaces = 0x1FF;
			BuyPrice = 11221;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Twill Vest)
*
***************************************************************/

namespace Server.Items
{
	public class TwillVest : Item
	{
		public TwillVest() : base()
		{
			Id = 3951;
			Resistance[0] = 66;
			SellPrice = 5897;
			AvailableClasses = 0x7FFF;
			Model = 16700;
			ObjectClass = 4;
			SubClass = 1;
			Level = 57;
			ReqLevel = 52;
			Name = "Twill Vest";
			Name2 = "Twill Vest";
			AvailableRaces = 0x1FF;
			BuyPrice = 29487;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Azure Silk Vest)
*
***************************************************************/

namespace Server.Items
{
	public class AzureSilkVest : Item
	{
		public AzureSilkVest() : base()
		{
			Id = 4324;
			Resistance[0] = 43;
			Bonding = 2;
			SellPrice = 1874;
			AvailableClasses = 0x7FFF;
			Model = 17128;
			ObjectClass = 4;
			SubClass = 1;
			Level = 30;
			ReqLevel = 25;
			Name = "Azure Silk Vest";
			Name2 = "Azure Silk Vest";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 9373;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
			SetSpell( 7701 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Whispering Vest)
*
***************************************************************/

namespace Server.Items
{
	public class WhisperingVest : Item
	{
		public WhisperingVest() : base()
		{
			Id = 4781;
			Resistance[0] = 34;
			Bonding = 2;
			SellPrice = 547;
			AvailableClasses = 0x7FFF;
			Model = 8702;
			ObjectClass = 4;
			SubClass = 1;
			Level = 20;
			ReqLevel = 15;
			Name = "Whispering Vest";
			Name2 = "Whispering Vest";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2735;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 60;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Soft Wool Vest)
*
***************************************************************/

namespace Server.Items
{
	public class SoftWoolVest : Item
	{
		public SoftWoolVest() : base()
		{
			Id = 4916;
			Resistance[0] = 10;
			Bonding = 1;
			SellPrice = 9;
			AvailableClasses = 0x7FFF;
			Model = 16800;
			ObjectClass = 4;
			SubClass = 1;
			Level = 5;
			Name = "Soft Wool Vest";
			Name2 = "Soft Wool Vest";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 48;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Stonesplinter Rags)
*
***************************************************************/

namespace Server.Items
{
	public class StonesplinterRags : Item
	{
		public StonesplinterRags() : base()
		{
			Id = 5109;
			Resistance[0] = 29;
			SellPrice = 223;
			AvailableClasses = 0x7FFF;
			Model = 16589;
			ObjectClass = 4;
			SubClass = 1;
			Level = 17;
			ReqLevel = 12;
			Name = "Stonesplinter Rags";
			Name2 = "Stonesplinter Rags";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1116;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Corsair's Overshirt)
*
***************************************************************/

namespace Server.Items
{
	public class CorsairsOvershirt : Item
	{
		public CorsairsOvershirt() : base()
		{
			Id = 5202;
			Resistance[0] = 42;
			Bonding = 1;
			SellPrice = 1147;
			AvailableClasses = 0x7FFF;
			Model = 12803;
			ObjectClass = 4;
			SubClass = 1;
			Level = 24;
			ReqLevel = 19;
			Name = "Corsair's Overshirt";
			Name2 = "Corsair's Overshirt";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 5737;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 75;
			IqBonus = 11;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Banshee Armor)
*
***************************************************************/

namespace Server.Items
{
	public class BansheeArmor : Item
	{
		public BansheeArmor() : base()
		{
			Id = 5420;
			Resistance[0] = 26;
			Bonding = 1;
			SellPrice = 227;
			AvailableClasses = 0x7FFF;
			Model = 8635;
			ObjectClass = 4;
			SubClass = 1;
			Level = 14;
			Name = "Banshee Armor";
			Name2 = "Banshee Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1138;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 50;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Red Linen Vest)
*
***************************************************************/

namespace Server.Items
{
	public class RedLinenVest : Item
	{
		public RedLinenVest() : base()
		{
			Id = 6239;
			Resistance[0] = 23;
			Bonding = 2;
			SellPrice = 160;
			AvailableClasses = 0x7FFF;
			Model = 12400;
			ObjectClass = 4;
			SubClass = 1;
			Level = 12;
			ReqLevel = 7;
			Name = "Red Linen Vest";
			Name2 = "Red Linen Vest";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 802;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 50;
			IqBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Blue Linen Vest)
*
***************************************************************/

namespace Server.Items
{
	public class BlueLinenVest : Item
	{
		public BlueLinenVest() : base()
		{
			Id = 6240;
			Resistance[0] = 23;
			Bonding = 2;
			SellPrice = 161;
			AvailableClasses = 0x7FFF;
			Model = 12387;
			ObjectClass = 4;
			SubClass = 1;
			Level = 12;
			ReqLevel = 7;
			Name = "Blue Linen Vest";
			Name2 = "Blue Linen Vest";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 805;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 50;
			IqBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Disciple's Vest)
*
***************************************************************/

namespace Server.Items
{
	public class DisciplesVest : Item
	{
		public DisciplesVest() : base()
		{
			Id = 6266;
			Resistance[0] = 25;
			Bonding = 2;
			SellPrice = 205;
			AvailableClasses = 0x7FFF;
			Model = 16560;
			ObjectClass = 4;
			SubClass = 1;
			Level = 13;
			ReqLevel = 8;
			Name = "Disciple's Vest";
			Name2 = "Disciple's Vest";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 455;
			BuyPrice = 1028;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Willow Vest)
*
***************************************************************/

namespace Server.Items
{
	public class WillowVest : Item
	{
		public WillowVest() : base()
		{
			Id = 6536;
			Resistance[0] = 33;
			Bonding = 2;
			SellPrice = 488;
			AvailableClasses = 0x7FFF;
			Model = 14739;
			ObjectClass = 4;
			SubClass = 1;
			Level = 19;
			ReqLevel = 14;
			Name = "Willow Vest";
			Name2 = "Willow Vest";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 457;
			BuyPrice = 2443;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Seer's Padded Armor)
*
***************************************************************/

namespace Server.Items
{
	public class SeersPaddedArmor : Item
	{
		public SeersPaddedArmor() : base()
		{
			Id = 6561;
			Resistance[0] = 35;
			Bonding = 2;
			SellPrice = 675;
			AvailableClasses = 0x7FFF;
			Model = 14551;
			ObjectClass = 4;
			SubClass = 1;
			Level = 21;
			ReqLevel = 16;
			Name = "Seer's Padded Armor";
			Name2 = "Seer's Padded Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3378;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 60;
			IqBonus = 6;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Shimmering Armor)
*
***************************************************************/

namespace Server.Items
{
	public class ShimmeringArmor : Item
	{
		public ShimmeringArmor() : base()
		{
			Id = 6567;
			Resistance[0] = 39;
			Bonding = 2;
			SellPrice = 1036;
			AvailableClasses = 0x7FFF;
			Model = 14748;
			ObjectClass = 4;
			SubClass = 1;
			Level = 25;
			ReqLevel = 20;
			Name = "Shimmering Armor";
			Name2 = "Shimmering Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 459;
			BuyPrice = 5182;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Bright Armor)
*
***************************************************************/

namespace Server.Items
{
	public class BrightArmor : Item
	{
		public BrightArmor() : base()
		{
			Id = 6608;
			Resistance[0] = 41;
			Bonding = 2;
			SellPrice = 1328;
			AvailableClasses = 0x7FFF;
			Model = 27542;
			ObjectClass = 4;
			SubClass = 1;
			Level = 27;
			ReqLevel = 22;
			Name = "Bright Armor";
			Name2 = "Bright Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6644;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
			SpiritBonus = 8;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Sage's Cloth)
*
***************************************************************/

namespace Server.Items
{
	public class SagesCloth : Item
	{
		public SagesCloth() : base()
		{
			Id = 6609;
			Resistance[0] = 44;
			Bonding = 2;
			SellPrice = 2148;
			AvailableClasses = 0x7FFF;
			Model = 16862;
			ObjectClass = 4;
			SubClass = 1;
			Level = 32;
			ReqLevel = 27;
			Name = "Sage's Cloth";
			Name2 = "Sage's Cloth";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 461;
			BuyPrice = 10740;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Earthen Vest)
*
***************************************************************/

namespace Server.Items
{
	public class EarthenVest : Item
	{
		public EarthenVest() : base()
		{
			Id = 7051;
			Resistance[0] = 46;
			Bonding = 2;
			SellPrice = 2696;
			AvailableClasses = 0x7FFF;
			Model = 8721;
			ObjectClass = 4;
			SubClass = 1;
			Level = 34;
			ReqLevel = 29;
			Name = "Earthen Vest";
			Name2 = "Earthen Vest";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 13481;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
			IqBonus = 10;
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Crimson Silk Vest)
*
***************************************************************/

namespace Server.Items
{
	public class CrimsonSilkVest : Item
	{
		public CrimsonSilkVest() : base()
		{
			Id = 7058;
			Resistance[0] = 46;
			SellPrice = 2052;
			AvailableClasses = 0x7FFF;
			Model = 13671;
			ObjectClass = 4;
			SubClass = 1;
			Level = 37;
			ReqLevel = 32;
			Name = "Crimson Silk Vest";
			Name2 = "Crimson Silk Vest";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 10262;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Green Silk Armor)
*
***************************************************************/

namespace Server.Items
{
	public class GreenSilkArmor : Item
	{
		public GreenSilkArmor() : base()
		{
			Id = 7065;
			Resistance[0] = 45;
			Bonding = 2;
			SellPrice = 2398;
			AvailableClasses = 0x7FFF;
			Model = 13684;
			ObjectClass = 4;
			SubClass = 1;
			Level = 33;
			ReqLevel = 28;
			Name = "Green Silk Armor";
			Name2 = "Green Silk Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11990;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
			SpiritBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Silver-thread Armor)
*
***************************************************************/

namespace Server.Items
{
	public class SilverThreadArmor : Item
	{
		public SilverThreadArmor() : base()
		{
			Id = 7110;
			Resistance[0] = 44;
			Bonding = 2;
			SellPrice = 2069;
			AvailableClasses = 0x7FFF;
			Model = 8720;
			ObjectClass = 4;
			SubClass = 1;
			Level = 31;
			ReqLevel = 26;
			Name = "Silver-thread Armor";
			Name2 = "Silver-thread Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 10349;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
			IqBonus = 11;
			SpiritBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Nightsky Armor)
*
***************************************************************/

namespace Server.Items
{
	public class NightskyArmor : Item
	{
		public NightskyArmor() : base()
		{
			Id = 7111;
			Resistance[0] = 49;
			Bonding = 2;
			SellPrice = 3329;
			AvailableClasses = 0x7FFF;
			Model = 14986;
			ObjectClass = 4;
			SubClass = 1;
			Level = 37;
			ReqLevel = 32;
			Name = "Nightsky Armor";
			Name2 = "Nightsky Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 16648;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
			StaminaBonus = 8;
			SpiritBonus = 8;
			IqBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Aurora Armor)
*
***************************************************************/

namespace Server.Items
{
	public class AuroraArmor : Item
	{
		public AuroraArmor() : base()
		{
			Id = 7112;
			Resistance[0] = 54;
			Bonding = 2;
			SellPrice = 4547;
			AvailableClasses = 0x7FFF;
			Model = 14657;
			ObjectClass = 4;
			SubClass = 1;
			Level = 41;
			ReqLevel = 36;
			Name = "Aurora Armor";
			Name2 = "Aurora Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 22735;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
			StaminaBonus = 4;
			IqBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Mistscape Armor)
*
***************************************************************/

namespace Server.Items
{
	public class MistscapeArmor : Item
	{
		public MistscapeArmor() : base()
		{
			Id = 7113;
			Resistance[0] = 60;
			Bonding = 2;
			SellPrice = 6707;
			AvailableClasses = 0x7FFF;
			Model = 14678;
			ObjectClass = 4;
			SubClass = 1;
			Level = 46;
			ReqLevel = 41;
			Name = "Mistscape Armor";
			Name2 = "Mistscape Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 33535;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
			StaminaBonus = 3;
			IqBonus = 18;
		}
	}
}


/**************************************************************
*
*				(Regal Armor)
*
***************************************************************/

namespace Server.Items
{
	public class RegalArmor : Item
	{
		public RegalArmor() : base()
		{
			Id = 7332;
			Resistance[0] = 59;
			Bonding = 2;
			SellPrice = 6692;
			AvailableClasses = 0x7FFF;
			Model = 15003;
			ObjectClass = 4;
			SubClass = 1;
			Level = 45;
			ReqLevel = 40;
			Name = "Regal Armor";
			Name2 = "Regal Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 465;
			BuyPrice = 33462;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Elder's Padded Armor)
*
***************************************************************/

namespace Server.Items
{
	public class EldersPaddedArmor : Item
	{
		public EldersPaddedArmor() : base()
		{
			Id = 7353;
			Resistance[0] = 46;
			Bonding = 2;
			SellPrice = 2998;
			AvailableClasses = 0x7FFF;
			Model = 16599;
			ObjectClass = 4;
			SubClass = 1;
			Level = 35;
			ReqLevel = 30;
			Name = "Elder's Padded Armor";
			Name2 = "Elder's Padded Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 462;
			BuyPrice = 14991;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Twilight Armor)
*
***************************************************************/

namespace Server.Items
{
	public class TwilightArmor : Item
	{
		public TwilightArmor() : base()
		{
			Id = 7429;
			Resistance[0] = 53;
			Bonding = 2;
			SellPrice = 4620;
			AvailableClasses = 0x7FFF;
			Model = 14646;
			ObjectClass = 4;
			SubClass = 1;
			Level = 40;
			ReqLevel = 35;
			Name = "Twilight Armor";
			Name2 = "Twilight Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 464;
			BuyPrice = 23100;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Gossamer Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class GossamerTunic : Item
	{
		public GossamerTunic() : base()
		{
			Id = 7517;
			Resistance[0] = 65;
			Bonding = 2;
			SellPrice = 9372;
			AvailableClasses = 0x7FFF;
			Model = 15398;
			ObjectClass = 4;
			SubClass = 1;
			Level = 50;
			ReqLevel = 45;
			Name = "Gossamer Tunic";
			Name2 = "Gossamer Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 467;
			BuyPrice = 46863;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Hibernal Armor)
*
***************************************************************/

namespace Server.Items
{
	public class HibernalArmor : Item
	{
		public HibernalArmor() : base()
		{
			Id = 8106;
			Resistance[0] = 66;
			Bonding = 2;
			SellPrice = 10438;
			AvailableClasses = 0x7FFF;
			Model = 16631;
			ObjectClass = 4;
			SubClass = 1;
			Level = 51;
			ReqLevel = 45;
			Name = "Hibernal Armor";
			Name2 = "Hibernal Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 52194;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
			StaminaBonus = 4;
			IqBonus = 20;
		}
	}
}


/**************************************************************
*
*				(Imperial Red Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class ImperialRedTunic : Item
	{
		public ImperialRedTunic() : base()
		{
			Id = 8245;
			Resistance[0] = 73;
			Bonding = 2;
			SellPrice = 12922;
			AvailableClasses = 0x7FFF;
			Model = 17211;
			ObjectClass = 4;
			SubClass = 1;
			Level = 56;
			ReqLevel = 51;
			Name = "Imperial Red Tunic";
			Name2 = "Imperial Red Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 64614;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
			StaminaBonus = 6;
			IqBonus = 21;
		}
	}
}


/**************************************************************
*
*				(Arcane Armor)
*
***************************************************************/

namespace Server.Items
{
	public class ArcaneArmor : Item
	{
		public ArcaneArmor() : base()
		{
			Id = 8283;
			Resistance[0] = 79;
			Bonding = 2;
			SellPrice = 17138;
			AvailableClasses = 0x7FFF;
			Model = 17251;
			ObjectClass = 4;
			SubClass = 1;
			Level = 61;
			ReqLevel = 56;
			Name = "Arcane Armor";
			Name2 = "Arcane Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 85690;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
			StaminaBonus = 7;
			SpiritBonus = 23;
		}
	}
}


/**************************************************************
*
*				(Grimlok's Tribal Vestments)
*
***************************************************************/

namespace Server.Items
{
	public class GrimloksTribalVestments : Item
	{
		public GrimloksTribalVestments() : base()
		{
			Id = 9415;
			Resistance[0] = 68;
			Bonding = 1;
			SellPrice = 8997;
			AvailableClasses = 0x7FFF;
			Model = 18347;
			ObjectClass = 4;
			SubClass = 1;
			Level = 47;
			ReqLevel = 42;
			Name = "Grimlok's Tribal Vestments";
			Name2 = "Grimlok's Tribal Vestments";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 44986;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 80;
			StaminaBonus = 10;
			IqBonus = 20;
			SpiritBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Elemental Raiment)
*
***************************************************************/

namespace Server.Items
{
	public class ElementalRaiment : Item
	{
		public ElementalRaiment() : base()
		{
			Id = 9434;
			Resistance[6] = 5;
			Resistance[0] = 59;
			Bonding = 2;
			SellPrice = 5648;
			AvailableClasses = 0x7FFF;
			Model = 18338;
			Resistance[2] = 5;
			Resistance[4] = 5;
			ObjectClass = 4;
			SubClass = 1;
			Level = 41;
			ReqLevel = 36;
			Name = "Elemental Raiment";
			Name2 = "Elemental Raiment";
			Resistance[3] = 5;
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 28240;
			Resistance[5] = 5;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 80;
			SetSpell( 14248 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Nether-lace Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class NetherLaceTunic : Item
	{
		public NetherLaceTunic() : base()
		{
			Id = 9515;
			Resistance[0] = 40;
			Bonding = 1;
			SellPrice = 1248;
			AvailableClasses = 0x80;
			Model = 18439;
			ObjectClass = 4;
			SubClass = 1;
			Level = 26;
			Name = "Nether-lace Tunic";
			Name2 = "Nether-lace Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6243;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 65;
			StaminaBonus = 2;
			IqBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Astral Knot Blouse)
*
***************************************************************/

namespace Server.Items
{
	public class AstralKnotBlouse : Item
	{
		public AstralKnotBlouse() : base()
		{
			Id = 9516;
			Resistance[0] = 40;
			Bonding = 1;
			SellPrice = 1285;
			AvailableClasses = 0x80;
			Model = 18440;
			ObjectClass = 4;
			SubClass = 1;
			Level = 26;
			Name = "Astral Knot Blouse";
			Name2 = "Astral Knot Blouse";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6429;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 65;
			StaminaBonus = 2;
			IqBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Simple Blouse)
*
***************************************************************/

namespace Server.Items
{
	public class SimpleBlouse : Item
	{
		public SimpleBlouse() : base()
		{
			Id = 9749;
			Resistance[0] = 28;
			Bonding = 2;
			SellPrice = 275;
			AvailableClasses = 0x7FFF;
			Model = 27529;
			ObjectClass = 4;
			SubClass = 1;
			Level = 15;
			ReqLevel = 10;
			Name = "Simple Blouse";
			Name2 = "Simple Blouse";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 455;
			BuyPrice = 1376;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Greenweave Vest)
*
***************************************************************/

namespace Server.Items
{
	public class GreenweaveVest : Item
	{
		public GreenweaveVest() : base()
		{
			Id = 9774;
			Resistance[0] = 41;
			Bonding = 2;
			SellPrice = 1374;
			AvailableClasses = 0x7FFF;
			Model = 25949;
			ObjectClass = 4;
			SubClass = 1;
			Level = 27;
			ReqLevel = 22;
			Name = "Greenweave Vest";
			Name2 = "Greenweave Vest";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 459;
			BuyPrice = 6872;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Ivycloth Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class IvyclothTunic : Item
	{
		public IvyclothTunic() : base()
		{
			Id = 9791;
			Resistance[0] = 42;
			Bonding = 2;
			SellPrice = 1644;
			AvailableClasses = 0x7FFF;
			Model = 27751;
			ObjectClass = 4;
			SubClass = 1;
			Level = 29;
			ReqLevel = 24;
			Name = "Ivycloth Tunic";
			Name2 = "Ivycloth Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 460;
			BuyPrice = 8224;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Durable Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class DurableTunic : Item
	{
		public DurableTunic() : base()
		{
			Id = 9819;
			Resistance[0] = 46;
			Bonding = 2;
			SellPrice = 2726;
			AvailableClasses = 0x7FFF;
			Model = 27860;
			ObjectClass = 4;
			SubClass = 1;
			Level = 34;
			ReqLevel = 29;
			Name = "Durable Tunic";
			Name2 = "Durable Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 462;
			BuyPrice = 13630;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Conjurer's Vest)
*
***************************************************************/

namespace Server.Items
{
	public class ConjurersVest : Item
	{
		public ConjurersVest() : base()
		{
			Id = 9844;
			Resistance[0] = 50;
			Bonding = 2;
			SellPrice = 3709;
			AvailableClasses = 0x7FFF;
			Model = 28424;
			ObjectClass = 4;
			SubClass = 1;
			Level = 38;
			ReqLevel = 33;
			Name = "Conjurer's Vest";
			Name2 = "Conjurer's Vest";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 463;
			BuyPrice = 18546;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Sorcerer Drape)
*
***************************************************************/

namespace Server.Items
{
	public class SorcererDrape : Item
	{
		public SorcererDrape() : base()
		{
			Id = 9874;
			Resistance[0] = 57;
			Bonding = 2;
			SellPrice = 5801;
			AvailableClasses = 0x7FFF;
			Model = 28064;
			ObjectClass = 4;
			SubClass = 1;
			Level = 43;
			ReqLevel = 38;
			Name = "Sorcerer Drape";
			Name2 = "Sorcerer Drape";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 465;
			BuyPrice = 29005;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Royal Blouse)
*
***************************************************************/

namespace Server.Items
{
	public class RoyalBlouse : Item
	{
		public RoyalBlouse() : base()
		{
			Id = 9905;
			Resistance[0] = 63;
			Bonding = 2;
			SellPrice = 8251;
			AvailableClasses = 0x7FFF;
			Model = 28411;
			ObjectClass = 4;
			SubClass = 1;
			Level = 48;
			ReqLevel = 43;
			Name = "Royal Blouse";
			Name2 = "Royal Blouse";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 466;
			BuyPrice = 41258;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Abjurer's Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class AbjurersTunic : Item
	{
		public AbjurersTunic() : base()
		{
			Id = 9946;
			Resistance[0] = 69;
			Bonding = 2;
			SellPrice = 11396;
			AvailableClasses = 0x7FFF;
			Model = 28972;
			ObjectClass = 4;
			SubClass = 1;
			Level = 53;
			ReqLevel = 48;
			Name = "Abjurer's Tunic";
			Name2 = "Abjurer's Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 468;
			BuyPrice = 56982;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Black Mageweave Vest)
*
***************************************************************/

namespace Server.Items
{
	public class BlackMageweaveVest : Item
	{
		public BlackMageweaveVest() : base()
		{
			Id = 9998;
			Resistance[0] = 54;
			Bonding = 2;
			SellPrice = 4815;
			AvailableClasses = 0x7FFF;
			Model = 24352;
			ObjectClass = 4;
			SubClass = 1;
			Level = 41;
			ReqLevel = 36;
			Name = "Black Mageweave Vest";
			Name2 = "Black Mageweave Vest";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 24076;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
			IqBonus = 12;
			SpiritBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Red Mageweave Vest)
*
***************************************************************/

namespace Server.Items
{
	public class RedMageweaveVest : Item
	{
		public RedMageweaveVest() : base()
		{
			Id = 10007;
			Resistance[0] = 57;
			Bonding = 2;
			SellPrice = 5799;
			AvailableClasses = 0x7FFF;
			Model = 19114;
			ObjectClass = 4;
			SubClass = 1;
			Level = 43;
			ReqLevel = 38;
			Name = "Red Mageweave Vest";
			Name2 = "Red Mageweave Vest";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 28999;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
			SpiritBonus = 18;
		}
	}
}


/**************************************************************
*
*				(Dreamweave Vest)
*
***************************************************************/

namespace Server.Items
{
	public class DreamweaveVest : Item
	{
		public DreamweaveVest() : base()
		{
			Id = 10021;
			Resistance[0] = 65;
			Bonding = 2;
			SellPrice = 7946;
			AvailableClasses = 0x7FFF;
			Model = 18949;
			ObjectClass = 4;
			SubClass = 1;
			Level = 45;
			ReqLevel = 40;
			Name = "Dreamweave Vest";
			Name2 = "Dreamweave Vest";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 39731;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 80;
			SetSpell( 9346 , 1 , 0 , -1 , 0 , -1 );
			IqBonus = 14;
			SpiritBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Tuxedo Jacket)
*
***************************************************************/

namespace Server.Items
{
	public class TuxedoJacket : Item
	{
		public TuxedoJacket() : base()
		{
			Id = 10036;
			Resistance[0] = 44;
			SellPrice = 1741;
			AvailableClasses = 0x7FFF;
			Model = 13116;
			ObjectClass = 4;
			SubClass = 1;
			Level = 35;
			ReqLevel = 30;
			Name = "Tuxedo Jacket";
			Name2 = "Tuxedo Jacket";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 8708;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
			SetSpell( 17816 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Duskwoven Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class DuskwovenTunic : Item
	{
		public DuskwovenTunic() : base()
		{
			Id = 10057;
			Resistance[0] = 71;
			Bonding = 2;
			SellPrice = 12711;
			AvailableClasses = 0x7FFF;
			Model = 28158;
			ObjectClass = 4;
			SubClass = 1;
			Level = 55;
			ReqLevel = 50;
			Name = "Duskwoven Tunic";
			Name2 = "Duskwoven Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 469;
			BuyPrice = 63558;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Councillor's Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class CouncillorsTunic : Item
	{
		public CouncillorsTunic() : base()
		{
			Id = 10104;
			Resistance[0] = 76;
			Bonding = 2;
			SellPrice = 15137;
			AvailableClasses = 0x7FFF;
			Model = 27599;
			ObjectClass = 4;
			SubClass = 1;
			Level = 59;
			ReqLevel = 54;
			Name = "Councillor's Tunic";
			Name2 = "Councillor's Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 470;
			BuyPrice = 75686;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(High Councillor's Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class HighCouncillorsTunic : Item
	{
		public HighCouncillorsTunic() : base()
		{
			Id = 10135;
			Resistance[0] = 82;
			Bonding = 2;
			SellPrice = 20663;
			AvailableClasses = 0x7FFF;
			Model = 27628;
			ObjectClass = 4;
			SubClass = 1;
			Level = 64;
			ReqLevel = 59;
			Name = "High Councillor's Tunic";
			Name2 = "High Councillor's Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 472;
			BuyPrice = 103318;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Mystical Armor)
*
***************************************************************/

namespace Server.Items
{
	public class MysticalArmor : Item
	{
		public MysticalArmor() : base()
		{
			Id = 10181;
			Resistance[0] = 75;
			Bonding = 2;
			SellPrice = 14640;
			AvailableClasses = 0x7FFF;
			Model = 28078;
			ObjectClass = 4;
			SubClass = 1;
			Level = 58;
			ReqLevel = 53;
			Name = "Mystical Armor";
			Name2 = "Mystical Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 470;
			BuyPrice = 73202;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Elegant Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class ElegantTunic : Item
	{
		public ElegantTunic() : base()
		{
			Id = 10218;
			Resistance[0] = 80;
			Bonding = 2;
			SellPrice = 17589;
			AvailableClasses = 0x7FFF;
			Model = 27866;
			ObjectClass = 4;
			SubClass = 1;
			Level = 62;
			ReqLevel = 57;
			Name = "Elegant Tunic";
			Name2 = "Elegant Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 471;
			BuyPrice = 87945;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Master's Vest)
*
***************************************************************/

namespace Server.Items
{
	public class MastersVest : Item
	{
		public MastersVest() : base()
		{
			Id = 10246;
			Resistance[0] = 83;
			Bonding = 2;
			SellPrice = 21542;
			AvailableClasses = 0x7FFF;
			Model = 27821;
			ObjectClass = 4;
			SubClass = 1;
			Level = 65;
			ReqLevel = 60;
			Name = "Master's Vest";
			Name2 = "Master's Vest";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 472;
			BuyPrice = 107712;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Foreman Vest)
*
***************************************************************/

namespace Server.Items
{
	public class ForemanVest : Item
	{
		public ForemanVest() : base()
		{
			Id = 10553;
			Resistance[0] = 21;
			Bonding = 2;
			SellPrice = 131;
			AvailableClasses = 0x7FFF;
			Model = 19919;
			ObjectClass = 4;
			SubClass = 1;
			Level = 11;
			ReqLevel = 6;
			Name = "Foreman Vest";
			Name2 = "Foreman Vest";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 657;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			StrBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Death's Head Vestment)
*
***************************************************************/

namespace Server.Items
{
	public class DeathsHeadVestment : Item
	{
		public DeathsHeadVestment() : base()
		{
			Id = 10581;
			Resistance[0] = 58;
			Bonding = 2;
			SellPrice = 5310;
			AvailableClasses = 0x7FFF;
			Model = 19506;
			ObjectClass = 4;
			SubClass = 1;
			Level = 40;
			ReqLevel = 35;
			Name = "Death's Head Vestment";
			Name2 = "Death's Head Vestment";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 26553;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 80;
			StrBonus = 8;
			IqBonus = 13;
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Vestments of the Atal'ai Prophet)
*
***************************************************************/

namespace Server.Items
{
	public class VestmentsOfTheAtalaiProphet : Item
	{
		public VestmentsOfTheAtalaiProphet() : base()
		{
			Id = 10806;
			Resistance[0] = 78;
			Bonding = 1;
			SellPrice = 15146;
			AvailableClasses = 0x7FFF;
			Model = 19810;
			ObjectClass = 4;
			SubClass = 1;
			Level = 55;
			ReqLevel = 50;
			Name = "Vestments of the Atal'ai Prophet";
			Name2 = "Vestments of the Atal'ai Prophet";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 75731;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 80;
			SpiritBonus = 11;
			IqBonus = 27;
		}
	}
}


/**************************************************************
*
*				(The Postmaster's Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class ThePostmastersTunic : Item
	{
		public ThePostmastersTunic() : base()
		{
			Id = 13388;
			Resistance[0] = 87;
			Bonding = 1;
			SellPrice = 21117;
			AvailableClasses = 0x7FFF;
			Model = 25049;
			ObjectClass = 4;
			SubClass = 1;
			Level = 61;
			ReqLevel = 56;
			Name = "The Postmaster's Tunic";
			Name2 = "The Postmaster's Tunic";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 105586;
			Sets = 81;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 80;
			IqBonus = 10;
			AgilityBonus = 5;
			SpiritBonus = 30;
		}
	}
}


/**************************************************************
*
*				(Runecloth Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class RuneclothTunic : Item
	{
		public RuneclothTunic() : base()
		{
			Id = 13857;
			Resistance[0] = 68;
			Bonding = 2;
			SellPrice = 10878;
			AvailableClasses = 0x7FFF;
			Model = 25207;
			ObjectClass = 4;
			SubClass = 1;
			Level = 52;
			ReqLevel = 47;
			Name = "Runecloth Tunic";
			Name2 = "Runecloth Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 54393;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
			IqBonus = 17;
			SpiritBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Frostweave Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class FrostweaveTunic : Item
	{
		public FrostweaveTunic() : base()
		{
			Id = 13869;
			Resistance[0] = 66;
			Bonding = 2;
			SellPrice = 9702;
			AvailableClasses = 0x7FFF;
			Model = 24610;
			ObjectClass = 4;
			SubClass = 1;
			Level = 51;
			ReqLevel = 46;
			Name = "Frostweave Tunic";
			Name2 = "Frostweave Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 48513;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
			SetSpell( 17890 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Cindercloth Vest)
*
***************************************************************/

namespace Server.Items
{
	public class CinderclothVest : Item
	{
		public CinderclothVest() : base()
		{
			Id = 14042;
			Resistance[0] = 68;
			Bonding = 2;
			SellPrice = 10561;
			AvailableClasses = 0x7FFF;
			Model = 24893;
			ObjectClass = 4;
			SubClass = 1;
			Level = 52;
			ReqLevel = 47;
			Name = "Cindercloth Vest";
			Name2 = "Cindercloth Vest";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 52808;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
			SetSpell( 17866 , 1 , 0 , -1 , 0 , -1 );
			IqBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Beaded Wraps)
*
***************************************************************/

namespace Server.Items
{
	public class BeadedWraps : Item
	{
		public BeadedWraps() : base()
		{
			Id = 14094;
			Resistance[0] = 21;
			Bonding = 2;
			SellPrice = 121;
			AvailableClasses = 0x7FFF;
			Model = 25873;
			ObjectClass = 4;
			SubClass = 1;
			Level = 11;
			ReqLevel = 6;
			Name = "Beaded Wraps";
			Name2 = "Beaded Wraps";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 454;
			BuyPrice = 606;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Native Vest)
*
***************************************************************/

namespace Server.Items
{
	public class NativeVest : Item
	{
		public NativeVest() : base()
		{
			Id = 14096;
			Resistance[0] = 29;
			Bonding = 2;
			SellPrice = 325;
			AvailableClasses = 0x7FFF;
			Model = 25880;
			ObjectClass = 4;
			SubClass = 1;
			Level = 16;
			ReqLevel = 11;
			Name = "Native Vest";
			Name2 = "Native Vest";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 456;
			BuyPrice = 1627;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Aboriginal Vest)
*
***************************************************************/

namespace Server.Items
{
	public class AboriginalVest : Item
	{
		public AboriginalVest() : base()
		{
			Id = 14121;
			Resistance[0] = 34;
			Bonding = 2;
			SellPrice = 579;
			AvailableClasses = 0x7FFF;
			Model = 17462;
			ObjectClass = 4;
			SubClass = 1;
			Level = 20;
			ReqLevel = 15;
			Name = "Aboriginal Vest";
			Name2 = "Aboriginal Vest";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 457;
			BuyPrice = 2897;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Ritual Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class RitualTunic : Item
	{
		public RitualTunic() : base()
		{
			Id = 14133;
			Resistance[0] = 38;
			Bonding = 2;
			SellPrice = 950;
			AvailableClasses = 0x7FFF;
			Model = 25952;
			ObjectClass = 4;
			SubClass = 1;
			Level = 24;
			ReqLevel = 19;
			Name = "Ritual Tunic";
			Name2 = "Ritual Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 458;
			BuyPrice = 4752;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Mooncloth Vest)
*
***************************************************************/

namespace Server.Items
{
	public class MoonclothVest : Item
	{
		public MoonclothVest() : base()
		{
			Id = 14138;
			Resistance[0] = 85;
			Bonding = 2;
			SellPrice = 20042;
			AvailableClasses = 0x7FFF;
			Model = 25228;
			ObjectClass = 4;
			SubClass = 1;
			Level = 60;
			ReqLevel = 55;
			Name = "Mooncloth Vest";
			Name2 = "Mooncloth Vest";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 100210;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 80;
			SpiritBonus = 20;
			IqBonus = 19;
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Ghostweave Vest)
*
***************************************************************/

namespace Server.Items
{
	public class GhostweaveVest : Item
	{
		public GhostweaveVest() : base()
		{
			Id = 14141;
			Resistance[0] = 71;
			Bonding = 2;
			SellPrice = 12859;
			AvailableClasses = 0x7FFF;
			Model = 25571;
			ObjectClass = 4;
			SubClass = 1;
			Level = 55;
			ReqLevel = 50;
			Name = "Ghostweave Vest";
			Name2 = "Ghostweave Vest";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 64296;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
			SetSpell( 18378 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Pagan Vest)
*
***************************************************************/

namespace Server.Items
{
	public class PaganVest : Item
	{
		public PaganVest() : base()
		{
			Id = 14158;
			Resistance[0] = 40;
			Bonding = 2;
			SellPrice = 1236;
			AvailableClasses = 0x7FFF;
			Model = 9996;
			ObjectClass = 4;
			SubClass = 1;
			Level = 26;
			ReqLevel = 21;
			Name = "Pagan Vest";
			Name2 = "Pagan Vest";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 459;
			BuyPrice = 6180;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Buccaneer's Vest)
*
***************************************************************/

namespace Server.Items
{
	public class BuccaneersVest : Item
	{
		public BuccaneersVest() : base()
		{
			Id = 14175;
			Resistance[0] = 37;
			Bonding = 2;
			SellPrice = 847;
			AvailableClasses = 0x7FFF;
			Model = 28052;
			ObjectClass = 4;
			SubClass = 1;
			Level = 23;
			ReqLevel = 18;
			Name = "Buccaneer's Vest";
			Name2 = "Buccaneer's Vest";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 458;
			BuyPrice = 4235;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Watcher's Jerkin)
*
***************************************************************/

namespace Server.Items
{
	public class WatchersJerkin : Item
	{
		public WatchersJerkin() : base()
		{
			Id = 14180;
			Resistance[0] = 43;
			Bonding = 2;
			SellPrice = 1870;
			AvailableClasses = 0x7FFF;
			Model = 26023;
			ObjectClass = 4;
			SubClass = 1;
			Level = 30;
			ReqLevel = 25;
			Name = "Watcher's Jerkin";
			Name2 = "Watcher's Jerkin";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 460;
			BuyPrice = 9351;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Raincaller Vest)
*
***************************************************************/

namespace Server.Items
{
	public class RaincallerVest : Item
	{
		public RaincallerVest() : base()
		{
			Id = 14190;
			Resistance[0] = 44;
			Bonding = 2;
			SellPrice = 1932;
			AvailableClasses = 0x7FFF;
			Model = 25984;
			ObjectClass = 4;
			SubClass = 1;
			Level = 31;
			ReqLevel = 26;
			Name = "Raincaller Vest";
			Name2 = "Raincaller Vest";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 461;
			BuyPrice = 9660;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Thistlefur Jerkin)
*
***************************************************************/

namespace Server.Items
{
	public class ThistlefurJerkin : Item
	{
		public ThistlefurJerkin() : base()
		{
			Id = 14202;
			Resistance[0] = 48;
			Bonding = 2;
			SellPrice = 3336;
			AvailableClasses = 0x7FFF;
			Model = 26049;
			ObjectClass = 4;
			SubClass = 1;
			Level = 36;
			ReqLevel = 31;
			Name = "Thistlefur Jerkin";
			Name2 = "Thistlefur Jerkin";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 462;
			BuyPrice = 16681;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Vital Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class VitalTunic : Item
	{
		public VitalTunic() : base()
		{
			Id = 14215;
			Resistance[0] = 49;
			Bonding = 2;
			SellPrice = 3579;
			AvailableClasses = 0x7FFF;
			Model = 25973;
			ObjectClass = 4;
			SubClass = 1;
			Level = 37;
			ReqLevel = 32;
			Name = "Vital Tunic";
			Name2 = "Vital Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 463;
			BuyPrice = 17898;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Geomancer's Jerkin)
*
***************************************************************/

namespace Server.Items
{
	public class GeomancersJerkin : Item
	{
		public GeomancersJerkin() : base()
		{
			Id = 14216;
			Resistance[0] = 54;
			Bonding = 2;
			SellPrice = 4887;
			AvailableClasses = 0x7FFF;
			Model = 26051;
			ObjectClass = 4;
			SubClass = 1;
			Level = 41;
			ReqLevel = 36;
			Name = "Geomancer's Jerkin";
			Name2 = "Geomancer's Jerkin";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 464;
			BuyPrice = 24438;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Embersilk Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class EmbersilkTunic : Item
	{
		public EmbersilkTunic() : base()
		{
			Id = 14230;
			Resistance[0] = 55;
			Bonding = 2;
			SellPrice = 5164;
			AvailableClasses = 0x7FFF;
			Model = 26063;
			ObjectClass = 4;
			SubClass = 1;
			Level = 42;
			ReqLevel = 37;
			Name = "Embersilk Tunic";
			Name2 = "Embersilk Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 464;
			BuyPrice = 25822;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Darkmist Armor)
*
***************************************************************/

namespace Server.Items
{
	public class DarkmistArmor : Item
	{
		public DarkmistArmor() : base()
		{
			Id = 14237;
			Resistance[0] = 60;
			Bonding = 2;
			SellPrice = 7206;
			AvailableClasses = 0x7FFF;
			Model = 16599;
			ObjectClass = 4;
			SubClass = 1;
			Level = 46;
			ReqLevel = 41;
			Name = "Darkmist Armor";
			Name2 = "Darkmist Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 466;
			BuyPrice = 36030;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Lunar Vest)
*
***************************************************************/

namespace Server.Items
{
	public class LunarVest : Item
	{
		public LunarVest() : base()
		{
			Id = 14249;
			Resistance[0] = 61;
			Bonding = 2;
			SellPrice = 7559;
			AvailableClasses = 0x7FFF;
			Model = 14646;
			ObjectClass = 4;
			SubClass = 1;
			Level = 47;
			ReqLevel = 42;
			Name = "Lunar Vest";
			Name2 = "Lunar Vest";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 466;
			BuyPrice = 37798;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Bloodwoven Jerkin)
*
***************************************************************/

namespace Server.Items
{
	public class BloodwovenJerkin : Item
	{
		public BloodwovenJerkin() : base()
		{
			Id = 14267;
			Resistance[0] = 66;
			Bonding = 2;
			SellPrice = 9926;
			AvailableClasses = 0x7FFF;
			Model = 26192;
			ObjectClass = 4;
			SubClass = 1;
			Level = 51;
			ReqLevel = 46;
			Name = "Bloodwoven Jerkin";
			Name2 = "Bloodwoven Jerkin";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 467;
			BuyPrice = 49633;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Gaea's Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class GaeasTunic : Item
	{
		public GaeasTunic() : base()
		{
			Id = 14277;
			Resistance[0] = 68;
			Bonding = 2;
			SellPrice = 10131;
			AvailableClasses = 0x7FFF;
			Model = 26311;
			ObjectClass = 4;
			SubClass = 1;
			Level = 52;
			ReqLevel = 47;
			Name = "Gaea's Tunic";
			Name2 = "Gaea's Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 468;
			BuyPrice = 50656;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Opulent Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class OpulentTunic : Item
	{
		public OpulentTunic() : base()
		{
			Id = 14287;
			Resistance[0] = 73;
			Bonding = 2;
			SellPrice = 13282;
			AvailableClasses = 0x7FFF;
			Model = 27927;
			ObjectClass = 4;
			SubClass = 1;
			Level = 56;
			ReqLevel = 51;
			Name = "Opulent Tunic";
			Name2 = "Opulent Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 469;
			BuyPrice = 66414;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Arachnidian Armor)
*
***************************************************************/

namespace Server.Items
{
	public class ArachnidianArmor : Item
	{
		public ArachnidianArmor() : base()
		{
			Id = 14288;
			Resistance[0] = 74;
			Bonding = 2;
			SellPrice = 14132;
			AvailableClasses = 0x7FFF;
			Model = 26203;
			ObjectClass = 4;
			SubClass = 1;
			Level = 57;
			ReqLevel = 52;
			Name = "Arachnidian Armor";
			Name2 = "Arachnidian Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 469;
			BuyPrice = 70662;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Bonecaster's Vest)
*
***************************************************************/

namespace Server.Items
{
	public class BonecastersVest : Item
	{
		public BonecastersVest() : base()
		{
			Id = 14306;
			Resistance[0] = 77;
			Bonding = 2;
			SellPrice = 16830;
			AvailableClasses = 0x7FFF;
			Model = 26279;
			ObjectClass = 4;
			SubClass = 1;
			Level = 60;
			ReqLevel = 55;
			Name = "Bonecaster's Vest";
			Name2 = "Bonecaster's Vest";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 470;
			BuyPrice = 84154;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Celestial Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class CelestialTunic : Item
	{
		public CelestialTunic() : base()
		{
			Id = 14308;
			Resistance[0] = 79;
			Bonding = 2;
			SellPrice = 17799;
			AvailableClasses = 0x7FFF;
			Model = 26256;
			ObjectClass = 4;
			SubClass = 1;
			Level = 61;
			ReqLevel = 56;
			Name = "Celestial Tunic";
			Name2 = "Celestial Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 471;
			BuyPrice = 88997;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Resplendent Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class ResplendentTunic : Item
	{
		public ResplendentTunic() : base()
		{
			Id = 14318;
			Resistance[0] = 81;
			Bonding = 2;
			SellPrice = 18408;
			AvailableClasses = 0x7FFF;
			Model = 26288;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Resplendent Tunic";
			Name2 = "Resplendent Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 471;
			BuyPrice = 92044;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Eternal Chestguard)
*
***************************************************************/

namespace Server.Items
{
	public class EternalChestguard : Item
	{
		public EternalChestguard() : base()
		{
			Id = 14328;
			Resistance[0] = 83;
			Bonding = 2;
			SellPrice = 21633;
			AvailableClasses = 0x7FFF;
			Model = 26219;
			ObjectClass = 4;
			SubClass = 1;
			Level = 65;
			ReqLevel = 60;
			Name = "Eternal Chestguard";
			Name2 = "Eternal Chestguard";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 472;
			BuyPrice = 108167;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Mystic's Wrap)
*
***************************************************************/

namespace Server.Items
{
	public class MysticsWrap : Item
	{
		public MysticsWrap() : base()
		{
			Id = 14369;
			Resistance[0] = 37;
			Bonding = 2;
			SellPrice = 809;
			AvailableClasses = 0x7FFF;
			Model = 25888;
			ObjectClass = 4;
			SubClass = 1;
			Level = 23;
			ReqLevel = 18;
			Name = "Mystic's Wrap";
			Name2 = "Mystic's Wrap";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4048;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 65;
			AgilityBonus = 3;
			SpiritBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Sanguine Armor)
*
***************************************************************/

namespace Server.Items
{
	public class SanguineArmor : Item
	{
		public SanguineArmor() : base()
		{
			Id = 14372;
			Resistance[0] = 41;
			Bonding = 2;
			SellPrice = 1430;
			AvailableClasses = 0x7FFF;
			Model = 25954;
			ObjectClass = 4;
			SubClass = 1;
			Level = 28;
			ReqLevel = 23;
			Name = "Sanguine Armor";
			Name2 = "Sanguine Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7151;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
			SpiritBonus = 6;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Resilient Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class ResilientTunic : Item
	{
		public ResilientTunic() : base()
		{
			Id = 14398;
			Resistance[0] = 45;
			Bonding = 2;
			SellPrice = 2355;
			AvailableClasses = 0x7FFF;
			Model = 26003;
			ObjectClass = 4;
			SubClass = 1;
			Level = 33;
			ReqLevel = 28;
			Name = "Resilient Tunic";
			Name2 = "Resilient Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11778;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
			AgilityBonus = 4;
			SpiritBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Stonecloth Vest)
*
***************************************************************/

namespace Server.Items
{
	public class StoneclothVest : Item
	{
		public StoneclothVest() : base()
		{
			Id = 14407;
			Resistance[0] = 52;
			Bonding = 2;
			SellPrice = 4266;
			AvailableClasses = 0x7FFF;
			Model = 26028;
			ObjectClass = 4;
			SubClass = 1;
			Level = 39;
			ReqLevel = 34;
			Name = "Stonecloth Vest";
			Name2 = "Stonecloth Vest";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 21331;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
			StaminaBonus = 2;
			StrBonus = 2;
			IqBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Silksand Tunic)
*
***************************************************************/

namespace Server.Items
{
	public class SilksandTunic : Item
	{
		public SilksandTunic() : base()
		{
			Id = 14417;
			Resistance[0] = 58;
			Bonding = 2;
			SellPrice = 5888;
			AvailableClasses = 0x7FFF;
			Model = 26084;
			ObjectClass = 4;
			SubClass = 1;
			Level = 44;
			ReqLevel = 39;
			Name = "Silksand Tunic";
			Name2 = "Silksand Tunic";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 29440;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
			IqBonus = 5;
			SpiritBonus = 16;
		}
	}
}


/**************************************************************
*
*				(Windchaser Wraps)
*
***************************************************************/

namespace Server.Items
{
	public class WindchaserWraps : Item
	{
		public WindchaserWraps() : base()
		{
			Id = 14427;
			Resistance[0] = 64;
			Bonding = 2;
			SellPrice = 9124;
			AvailableClasses = 0x7FFF;
			Model = 26161;
			ObjectClass = 4;
			SubClass = 1;
			Level = 49;
			ReqLevel = 44;
			Name = "Windchaser Wraps";
			Name2 = "Windchaser Wraps";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 45623;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
			StaminaBonus = 10;
			IqBonus = 17;
		}
	}
}


/**************************************************************
*
*				(Venomshroud Vest)
*
***************************************************************/

namespace Server.Items
{
	public class VenomshroudVest : Item
	{
		public VenomshroudVest() : base()
		{
			Id = 14437;
			Resistance[0] = 70;
			Bonding = 2;
			SellPrice = 12002;
			AvailableClasses = 0x7FFF;
			Model = 16631;
			ObjectClass = 4;
			SubClass = 1;
			Level = 54;
			ReqLevel = 49;
			Name = "Venomshroud Vest";
			Name2 = "Venomshroud Vest";
			Resistance[3] = 4;
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 60014;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
			IqBonus = 9;
			StaminaBonus = 18;
		}
	}
}


/**************************************************************
*
*				(Highborne Padded Armor)
*
***************************************************************/

namespace Server.Items
{
	public class HighbornePaddedArmor : Item
	{
		public HighbornePaddedArmor() : base()
		{
			Id = 14455;
			Resistance[0] = 76;
			Bonding = 2;
			SellPrice = 15792;
			AvailableClasses = 0x7FFF;
			Model = 26178;
			ObjectClass = 4;
			SubClass = 1;
			Level = 59;
			ReqLevel = 54;
			Name = "Highborne Padded Armor";
			Name2 = "Highborne Padded Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 78962;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
			SpiritBonus = 19;
			IqBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Elunarian Vest)
*
***************************************************************/

namespace Server.Items
{
	public class ElunarianVest : Item
	{
		public ElunarianVest() : base()
		{
			Id = 14456;
			Resistance[0] = 82;
			Bonding = 2;
			SellPrice = 20230;
			AvailableClasses = 0x7FFF;
			Model = 26240;
			ObjectClass = 4;
			SubClass = 1;
			Level = 64;
			ReqLevel = 59;
			Name = "Elunarian Vest";
			Name2 = "Elunarian Vest";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 101151;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 7;
			Durability = 70;
			StaminaBonus = 12;
			IqBonus = 21;
			StrBonus = 5;
		}
	}
}


