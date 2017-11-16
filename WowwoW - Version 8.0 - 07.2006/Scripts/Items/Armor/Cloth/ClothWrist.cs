/**************************************************************
*
*		Made by fulgas (fulgas@gmail.com)
*
*  WowwoW Item Designer ( 2005/8/23 - 10:05:29 )
*
***************************************************************/

using System;
using System.Collections;

/***************************************************************/

/**************************************************************
*
*				(Bracers of the People's Militia)
*
***************************************************************/

namespace Server.Items
{
	public class BracersOfThePeoplesMilitia : Item
	{
		public BracersOfThePeoplesMilitia() : base()
		{
			Id = 710;
			Resistance[0] = 11;
			Bonding = 1;
			SellPrice = 72;
			AvailableClasses = 0x7FFF;
			Model = 16936;
			ObjectClass = 4;
			SubClass = 1;
			Level = 14;
			Name = "Bracers of the People's Militia";
			Name2 = "Bracers of the People's Militia";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 361;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 18;
		}
	}
}


/**************************************************************
*
*				(Elastic Wristguards)
*
***************************************************************/

namespace Server.Items
{
	public class ElasticWristguards : Item
	{
		public ElasticWristguards() : base()
		{
			Id = 1183;
			Resistance[0] = 8;
			Bonding = 1;
			SellPrice = 29;
			AvailableClasses = 0x7FFF;
			Model = 16927;
			ObjectClass = 4;
			SubClass = 1;
			Level = 10;
			Name = "Elastic Wristguards";
			Name2 = "Elastic Wristguards";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 149;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 16;
		}
	}
}


/**************************************************************
*
*				(Deprecated Night Mage Wristguards)
*
***************************************************************/

namespace Server.Items
{
	public class DeprecatedNightMageWristguards : Item
	{
		public DeprecatedNightMageWristguards() : base()
		{
			Id = 1298;
			Resistance[0] = 12;
			Bonding = 2;
			SellPrice = 89;
			AvailableClasses = 0x7FFF;
			Model = 6305;
			ObjectClass = 4;
			SubClass = 1;
			Level = 18;
			ReqLevel = 13;
			Name = "Deprecated Night Mage Wristguards";
			Name2 = "Deprecated Night Mage Wristguards";
			AvailableRaces = 0x1FF;
			BuyPrice = 445;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 20;
			Flags = 16;
		}
	}
}


/**************************************************************
*
*				(Fingerbone Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class FingerboneBracers : Item
	{
		public FingerboneBracers() : base()
		{
			Id = 1351;
			Resistance[0] = 18;
			Bonding = 2;
			SellPrice = 768;
			AvailableClasses = 0x7FFF;
			Model = 16897;
			ObjectClass = 4;
			SubClass = 1;
			Level = 28;
			ReqLevel = 23;
			Name = "Fingerbone Bracers";
			Name2 = "Fingerbone Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3843;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			StaminaBonus = 2;
			SpiritBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Mindthrust Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class MindthrustBracers : Item
	{
		public MindthrustBracers() : base()
		{
			Id = 1974;
			Resistance[0] = 17;
			Bonding = 2;
			SellPrice = 464;
			AvailableClasses = 0x7FFF;
			Model = 16901;
			ObjectClass = 4;
			SubClass = 1;
			Level = 22;
			ReqLevel = 17;
			Name = "Mindthrust Bracers";
			Name2 = "Mindthrust Bracers";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 2320;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 20;
			SpiritBonus = 9;
			StaminaBonus = -5;
		}
	}
}


/**************************************************************
*
*				(Gallan Cuffs)
*
***************************************************************/

namespace Server.Items
{
	public class GallanCuffs : Item
	{
		public GallanCuffs() : base()
		{
			Id = 2032;
			Resistance[0] = 21;
			Bonding = 1;
			SellPrice = 1665;
			AvailableClasses = 0x7FFF;
			Model = 16887;
			ObjectClass = 4;
			SubClass = 1;
			Level = 36;
			Name = "Gallan Cuffs";
			Name2 = "Gallan Cuffs";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 8328;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			StaminaBonus = 3;
			SpiritBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Ivy-weave Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class IvyWeaveBracers : Item
	{
		public IvyWeaveBracers() : base()
		{
			Id = 2326;
			Resistance[0] = 8;
			Bonding = 1;
			SellPrice = 29;
			AvailableClasses = 0x7FFF;
			Model = 16905;
			ObjectClass = 4;
			SubClass = 1;
			Level = 10;
			Name = "Ivy-weave Bracers";
			Name2 = "Ivy-weave Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 145;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 16;
		}
	}
}


/**************************************************************
*
*				(Silver-lined Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class SilverLinedBracers : Item
	{
		public SilverLinedBracers() : base()
		{
			Id = 3224;
			Resistance[0] = 8;
			SellPrice = 28;
			AvailableClasses = 0x7FFF;
			Model = 16926;
			ObjectClass = 4;
			SubClass = 1;
			Level = 10;
			ReqLevel = 5;
			Name = "Silver-lined Bracers";
			Name2 = "Silver-lined Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 142;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 16;
		}
	}
}


/**************************************************************
*
*				(Ghostly Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class GhostlyBracers : Item
	{
		public GhostlyBracers() : base()
		{
			Id = 3323;
			Resistance[0] = 7;
			SellPrice = 15;
			AvailableClasses = 0x7FFF;
			Model = 16906;
			ObjectClass = 4;
			SubClass = 1;
			Level = 8;
			ReqLevel = 3;
			Name = "Ghostly Bracers";
			Name2 = "Ghostly Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 79;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 14;
		}
	}
}


/**************************************************************
*
*				(Frayed Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class FrayedBracers : Item
	{
		public FrayedBracers() : base()
		{
			Id = 3365;
			Resistance[0] = 4;
			SellPrice = 3;
			AvailableClasses = 0x7FFF;
			Model = 16664;
			ObjectClass = 4;
			SubClass = 1;
			Level = 5;
			ReqLevel = 1;
			Name = "Frayed Bracers";
			Name2 = "Frayed Bracers";
			AvailableRaces = 0x1FF;
			BuyPrice = 16;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 14;
		}
	}
}


/**************************************************************
*
*				(Patchwork Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class PatchworkBracers : Item
	{
		public PatchworkBracers() : base()
		{
			Id = 3373;
			Resistance[0] = 7;
			SellPrice = 14;
			AvailableClasses = 0x7FFF;
			Model = 16804;
			ObjectClass = 4;
			SubClass = 1;
			Level = 9;
			ReqLevel = 4;
			Name = "Patchwork Bracers";
			Name2 = "Patchwork Bracers";
			AvailableRaces = 0x1FF;
			BuyPrice = 71;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 16;
		}
	}
}


/**************************************************************
*
*				(Calico Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class CalicoBracers : Item
	{
		public CalicoBracers() : base()
		{
			Id = 3375;
			Resistance[0] = 9;
			SellPrice = 30;
			AvailableClasses = 0x7FFF;
			Model = 16555;
			ObjectClass = 4;
			SubClass = 1;
			Level = 12;
			ReqLevel = 7;
			Name = "Calico Bracers";
			Name2 = "Calico Bracers";
			AvailableRaces = 0x1FF;
			BuyPrice = 152;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 16;
		}
	}
}


/**************************************************************
*
*				(Canvas Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class CanvasBracers : Item
	{
		public CanvasBracers() : base()
		{
			Id = 3377;
			Resistance[0] = 13;
			SellPrice = 99;
			AvailableClasses = 0x7FFF;
			Model = 14111;
			ObjectClass = 4;
			SubClass = 1;
			Level = 19;
			ReqLevel = 14;
			Name = "Canvas Bracers";
			Name2 = "Canvas Bracers";
			AvailableRaces = 0x1FF;
			BuyPrice = 497;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Brocade Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class BrocadeBracers : Item
	{
		public BrocadeBracers() : base()
		{
			Id = 3379;
			Resistance[0] = 14;
			SellPrice = 152;
			AvailableClasses = 0x7FFF;
			Model = 16806;
			ObjectClass = 4;
			SubClass = 1;
			Level = 22;
			ReqLevel = 17;
			Name = "Brocade Bracers";
			Name2 = "Brocade Bracers";
			AvailableRaces = 0x1FF;
			BuyPrice = 762;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Cross-stitched Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class CrossStitchedBracers : Item
	{
		public CrossStitchedBracers() : base()
		{
			Id = 3381;
			Resistance[0] = 16;
			SellPrice = 303;
			AvailableClasses = 0x7FFF;
			Model = 16913;
			ObjectClass = 4;
			SubClass = 1;
			Level = 28;
			ReqLevel = 23;
			Name = "Cross-stitched Bracers";
			Name2 = "Cross-stitched Bracers";
			AvailableRaces = 0x1FF;
			BuyPrice = 1515;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Quilted Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class QuiltedBracers : Item
	{
		public QuiltedBracers() : base()
		{
			Id = 3453;
			Resistance[0] = 9;
			Bonding = 1;
			SellPrice = 46;
			AvailableClasses = 0x7FFF;
			Model = 16907;
			ObjectClass = 4;
			SubClass = 1;
			Level = 12;
			Name = "Quilted Bracers";
			Name2 = "Quilted Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 232;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 16;
		}
	}
}


/**************************************************************
*
*				(Embroidered Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class EmbroideredBracers : Item
	{
		public EmbroideredBracers() : base()
		{
			Id = 3588;
			Resistance[0] = 27;
			SellPrice = 2873;
			AvailableClasses = 0x7FFF;
			Model = 16774;
			ObjectClass = 4;
			SubClass = 1;
			Level = 50;
			ReqLevel = 45;
			Name = "Embroidered Bracers";
			Name2 = "Embroidered Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 14365;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Heavy Weave Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyWeaveBracers : Item
	{
		public HeavyWeaveBracers() : base()
		{
			Id = 3590;
			Resistance[0] = 13;
			SellPrice = 115;
			AvailableClasses = 0x7FFF;
			Model = 16816;
			ObjectClass = 4;
			SubClass = 1;
			Level = 17;
			ReqLevel = 12;
			Name = "Heavy Weave Bracers";
			Name2 = "Heavy Weave Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 578;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Padded Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class PaddedBracers : Item
	{
		public PaddedBracers() : base()
		{
			Id = 3592;
			Resistance[0] = 17;
			SellPrice = 420;
			AvailableClasses = 0x7FFF;
			Model = 3645;
			ObjectClass = 4;
			SubClass = 1;
			Level = 27;
			ReqLevel = 22;
			Name = "Padded Bracers";
			Name2 = "Padded Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2104;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Russet Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class RussetBracers : Item
	{
		public RussetBracers() : base()
		{
			Id = 3594;
			Resistance[0] = 20;
			SellPrice = 1099;
			AvailableClasses = 0x7FFF;
			Model = 3740;
			ObjectClass = 4;
			SubClass = 1;
			Level = 37;
			ReqLevel = 32;
			Name = "Russet Bracers";
			Name2 = "Russet Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 5497;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Tattered Cloth Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class TatteredClothBracers : Item
	{
		public TatteredClothBracers() : base()
		{
			Id = 3596;
			Resistance[0] = 4;
			SellPrice = 4;
			AvailableClasses = 0x7FFF;
			Model = 16584;
			ObjectClass = 4;
			SubClass = 1;
			Level = 5;
			ReqLevel = 1;
			Name = "Tattered Cloth Bracers";
			Name2 = "Tattered Cloth Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 23;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 14;
		}
	}
}


/**************************************************************
*
*				(Thick Cloth Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class ThickClothBracers : Item
	{
		public ThickClothBracers() : base()
		{
			Id = 3598;
			Resistance[0] = 15;
			SellPrice = 217;
			AvailableClasses = 0x7FFF;
			Model = 3895;
			ObjectClass = 4;
			SubClass = 1;
			Level = 22;
			ReqLevel = 17;
			Name = "Thick Cloth Bracers";
			Name2 = "Thick Cloth Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1085;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Thin Cloth Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class ThinClothBracers : Item
	{
		public ThinClothBracers() : base()
		{
			Id = 3600;
			Resistance[0] = 4;
			SellPrice = 4;
			AvailableClasses = 0x7FFF;
			Model = 16929;
			ObjectClass = 4;
			SubClass = 1;
			Level = 5;
			ReqLevel = 1;
			Name = "Thin Cloth Bracers";
			Name2 = "Thin Cloth Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 24;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 14;
		}
	}
}


/**************************************************************
*
*				(Knitted Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class KnittedBracers : Item
	{
		public KnittedBracers() : base()
		{
			Id = 3603;
			Resistance[0] = 8;
			SellPrice = 29;
			AvailableClasses = 0x7FFF;
			Model = 16930;
			ObjectClass = 4;
			SubClass = 1;
			Level = 10;
			ReqLevel = 5;
			Name = "Knitted Bracers";
			Name2 = "Knitted Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 145;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 16;
		}
	}
}


/**************************************************************
*
*				(Woven Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class WovenBracers : Item
	{
		public WovenBracers() : base()
		{
			Id = 3607;
			Resistance[0] = 8;
			SellPrice = 29;
			AvailableClasses = 0x7FFF;
			Model = 14161;
			ObjectClass = 4;
			SubClass = 1;
			Level = 10;
			ReqLevel = 5;
			Name = "Woven Bracers";
			Name2 = "Woven Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 148;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 16;
		}
	}
}


/**************************************************************
*
*				(Journeyman's Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class JourneymansBracers : Item
	{
		public JourneymansBracers() : base()
		{
			Id = 3641;
			Resistance[0] = 7;
			SellPrice = 15;
			AvailableClasses = 0x7FFF;
			Model = 14423;
			ObjectClass = 4;
			SubClass = 1;
			Level = 8;
			ReqLevel = 3;
			Name = "Journeyman's Bracers";
			Name2 = "Journeyman's Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 78;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 14;
		}
	}
}


/**************************************************************
*
*				(Ancestral Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class AncestralBracers : Item
	{
		public AncestralBracers() : base()
		{
			Id = 3642;
			Resistance[0] = 7;
			SellPrice = 22;
			AvailableClasses = 0x7FFF;
			Model = 14510;
			ObjectClass = 4;
			SubClass = 1;
			Level = 9;
			ReqLevel = 4;
			Name = "Ancestral Bracers";
			Name2 = "Ancestral Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 111;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 16;
		}
	}
}


/**************************************************************
*
*				(Spellbinder Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class SpellbinderBracers : Item
	{
		public SpellbinderBracers() : base()
		{
			Id = 3643;
			Resistance[0] = 11;
			SellPrice = 71;
			AvailableClasses = 0x7FFF;
			Model = 14342;
			ObjectClass = 4;
			SubClass = 1;
			Level = 14;
			ReqLevel = 9;
			Name = "Spellbinder Bracers";
			Name2 = "Spellbinder Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 355;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 18;
		}
	}
}


/**************************************************************
*
*				(Barbaric Cloth Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class BarbaricClothBracers : Item
	{
		public BarbaricClothBracers() : base()
		{
			Id = 3644;
			Resistance[0] = 9;
			SellPrice = 47;
			AvailableClasses = 0x7FFF;
			Model = 16595;
			ObjectClass = 4;
			SubClass = 1;
			Level = 12;
			ReqLevel = 7;
			Name = "Barbaric Cloth Bracers";
			Name2 = "Barbaric Cloth Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 237;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 16;
		}
	}
}


/**************************************************************
*
*				(Seer's Cuffs)
*
***************************************************************/

namespace Server.Items
{
	public class SeersCuffs : Item
	{
		public SeersCuffs() : base()
		{
			Id = 3645;
			Resistance[0] = 13;
			Bonding = 2;
			SellPrice = 189;
			AvailableClasses = 0x7FFF;
			Model = 16915;
			ObjectClass = 4;
			SubClass = 1;
			Level = 17;
			ReqLevel = 12;
			Name = "Seer's Cuffs";
			Name2 = "Seer's Cuffs";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 947;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 20;
			IqBonus = 2;
			SpiritBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Bright Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class BrightBracers : Item
	{
		public BrightBracers() : base()
		{
			Id = 3647;
			Resistance[0] = 16;
			Bonding = 2;
			SellPrice = 433;
			AvailableClasses = 0x7FFF;
			Model = 14566;
			ObjectClass = 4;
			SubClass = 1;
			Level = 23;
			ReqLevel = 18;
			Name = "Bright Bracers";
			Name2 = "Bright Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2169;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 20;
			SpiritBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Interlaced Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class InterlacedBracers : Item
	{
		public InterlacedBracers() : base()
		{
			Id = 3794;
			Resistance[0] = 20;
			SellPrice = 774;
			AvailableClasses = 0x7FFF;
			Model = 16571;
			ObjectClass = 4;
			SubClass = 1;
			Level = 38;
			ReqLevel = 33;
			Name = "Interlaced Bracers";
			Name2 = "Interlaced Bracers";
			AvailableRaces = 0x1FF;
			BuyPrice = 3874;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Crochet Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class CrochetBracers : Item
	{
		public CrochetBracers() : base()
		{
			Id = 3938;
			Resistance[0] = 23;
			SellPrice = 1189;
			AvailableClasses = 0x7FFF;
			Model = 16724;
			ObjectClass = 4;
			SubClass = 1;
			Level = 44;
			ReqLevel = 39;
			Name = "Crochet Bracers";
			Name2 = "Crochet Bracers";
			AvailableRaces = 0x1FF;
			BuyPrice = 5949;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Twill Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class TwillBracers : Item
	{
		public TwillBracers() : base()
		{
			Id = 3946;
			Resistance[0] = 28;
			SellPrice = 2431;
			AvailableClasses = 0x7FFF;
			Model = 9894;
			ObjectClass = 4;
			SubClass = 1;
			Level = 54;
			ReqLevel = 49;
			Name = "Twill Bracers";
			Name2 = "Twill Bracers";
			AvailableRaces = 0x1FF;
			BuyPrice = 12159;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Silver-thread Cuffs)
*
***************************************************************/

namespace Server.Items
{
	public class SilverThreadCuffs : Item
	{
		public SilverThreadCuffs() : base()
		{
			Id = 4036;
			Resistance[0] = 18;
			Bonding = 2;
			SellPrice = 681;
			AvailableClasses = 0x7FFF;
			Model = 4607;
			ObjectClass = 4;
			SubClass = 1;
			Level = 27;
			ReqLevel = 22;
			Name = "Silver-thread Cuffs";
			Name2 = "Silver-thread Cuffs";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3408;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			SpiritBonus = 5;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Aurora Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class AuroraBracers : Item
	{
		public AuroraBracers() : base()
		{
			Id = 4043;
			Resistance[0] = 22;
			Bonding = 2;
			SellPrice = 1958;
			AvailableClasses = 0x7FFF;
			Model = 14652;
			ObjectClass = 4;
			SubClass = 1;
			Level = 38;
			ReqLevel = 33;
			Name = "Aurora Bracers";
			Name2 = "Aurora Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 9790;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			SpiritBonus = 8;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Mistscape Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class MistscapeBracers : Item
	{
		public MistscapeBracers() : base()
		{
			Id = 4045;
			Resistance[0] = 24;
			Bonding = 2;
			SellPrice = 2683;
			AvailableClasses = 0x7FFF;
			Model = 14680;
			ObjectClass = 4;
			SubClass = 1;
			Level = 42;
			ReqLevel = 37;
			Name = "Mistscape Bracers";
			Name2 = "Mistscape Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 13415;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			StaminaBonus = 3;
			SpiritBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Darkspear Cuffs)
*
***************************************************************/

namespace Server.Items
{
	public class DarkspearCuffs : Item
	{
		public DarkspearCuffs() : base()
		{
			Id = 4133;
			Resistance[0] = 21;
			Bonding = 1;
			SellPrice = 1794;
			AvailableClasses = 0x7FFF;
			Model = 4462;
			ObjectClass = 4;
			SubClass = 1;
			Level = 37;
			Name = "Darkspear Cuffs";
			Name2 = "Darkspear Cuffs";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 8970;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			StaminaBonus = 3;
			SpiritBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Green Linen Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class GreenLinenBracers : Item
	{
		public GreenLinenBracers() : base()
		{
			Id = 4308;
			Resistance[0] = 9;
			SellPrice = 45;
			AvailableClasses = 0x7FFF;
			Model = 8089;
			ObjectClass = 4;
			SubClass = 1;
			Level = 12;
			ReqLevel = 7;
			Name = "Green Linen Bracers";
			Name2 = "Green Linen Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 225;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 16;
		}
	}
}


/**************************************************************
*
*				(Radiant Silver Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class RadiantSilverBracers : Item
	{
		public RadiantSilverBracers() : base()
		{
			Id = 4545;
			Resistance[0] = 23;
			Bonding = 1;
			SellPrice = 2202;
			AvailableClasses = 0x7FFF;
			Model = 16892;
			ObjectClass = 4;
			SubClass = 1;
			Level = 40;
			Name = "Radiant Silver Bracers";
			Name2 = "Radiant Silver Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11010;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			StaminaBonus = 3;
			SpiritBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Arcane Runed Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class ArcaneRunedBracers : Item
	{
		public ArcaneRunedBracers() : base()
		{
			Id = 4744;
			Resistance[0] = 23;
			Bonding = 1;
			SellPrice = 1986;
			AvailableClasses = 0x7FFF;
			Model = 16925;
			ObjectClass = 4;
			SubClass = 1;
			Level = 39;
			Name = "Arcane Runed Bracers";
			Name2 = "Arcane Runed Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 9933;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			StaminaBonus = 1;
			SpiritBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Enchanted Stonecloth Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class EnchantedStoneclothBracers : Item
	{
		public EnchantedStoneclothBracers() : base()
		{
			Id = 4979;
			Resistance[0] = 24;
			Bonding = 1;
			SellPrice = 2587;
			AvailableClasses = 0x7FFF;
			Model = 5434;
			ObjectClass = 4;
			SubClass = 1;
			Level = 42;
			Name = "Enchanted Stonecloth Bracers";
			Name2 = "Enchanted Stonecloth Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 12939;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			StaminaBonus = 4;
			SpiritBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Scorched Bands)
*
***************************************************************/

namespace Server.Items
{
	public class ScorchedBands : Item
	{
		public ScorchedBands() : base()
		{
			Id = 4990;
			Resistance[0] = 29;
			Bonding = 1;
			SellPrice = 4546;
			AvailableClasses = 0x7FFF;
			Model = 16934;
			ObjectClass = 4;
			SubClass = 1;
			Level = 50;
			Name = "Scorched Bands";
			Name2 = "Scorched Bands";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 22732;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			SpiritBonus = 8;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Timberland Armguards)
*
***************************************************************/

namespace Server.Items
{
	public class TimberlandArmguards : Item
	{
		public TimberlandArmguards() : base()
		{
			Id = 5315;
			Resistance[0] = 14;
			Bonding = 1;
			SellPrice = 213;
			AvailableClasses = 0x7FFF;
			Model = 28200;
			ObjectClass = 4;
			SubClass = 1;
			Level = 18;
			Name = "Timberland Armguards";
			Name2 = "Timberland Armguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1069;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 20;
			IqBonus = 2;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Cord Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class CordBracers : Item
	{
		public CordBracers() : base()
		{
			Id = 5590;
			Resistance[0] = 9;
			Bonding = 1;
			SellPrice = 35;
			AvailableClasses = 0x7FFF;
			Model = 16918;
			ObjectClass = 4;
			SubClass = 1;
			Level = 11;
			Name = "Cord Bracers";
			Name2 = "Cord Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 179;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 16;
		}
	}
}


/**************************************************************
*
*				(Flax Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class FlaxBracers : Item
	{
		public FlaxBracers() : base()
		{
			Id = 6060;
			Resistance[0] = 4;
			Bonding = 1;
			SellPrice = 4;
			AvailableClasses = 0x7FFF;
			Model = 16588;
			ObjectClass = 4;
			SubClass = 1;
			Level = 5;
			Name = "Flax Bracers";
			Name2 = "Flax Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 24;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 14;
		}
	}
}


/**************************************************************
*
*				(Heavy Cord Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyCordBracers : Item
	{
		public HeavyCordBracers() : base()
		{
			Id = 6062;
			Resistance[0] = 8;
			Bonding = 1;
			SellPrice = 28;
			AvailableClasses = 0x7FFF;
			Model = 16805;
			ObjectClass = 4;
			SubClass = 1;
			Level = 10;
			Name = "Heavy Cord Bracers";
			Name2 = "Heavy Cord Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 142;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 16;
		}
	}
}


/**************************************************************
*
*				(Nightsky Wristbands)
*
***************************************************************/

namespace Server.Items
{
	public class NightskyWristbands : Item
	{
		public NightskyWristbands() : base()
		{
			Id = 6407;
			Resistance[0] = 20;
			Bonding = 2;
			SellPrice = 1198;
			AvailableClasses = 0x7FFF;
			Model = 14618;
			ObjectClass = 4;
			SubClass = 1;
			Level = 33;
			ReqLevel = 28;
			Name = "Nightsky Wristbands";
			Name2 = "Nightsky Wristbands";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5994;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			SpiritBonus = 6;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Willow Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class WillowBracers : Item
	{
		public WillowBracers() : base()
		{
			Id = 6543;
			Resistance[0] = 12;
			Bonding = 2;
			SellPrice = 147;
			AvailableClasses = 0x7FFF;
			Model = 14736;
			ObjectClass = 4;
			SubClass = 1;
			Level = 15;
			ReqLevel = 10;
			Name = "Willow Bracers";
			Name2 = "Willow Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1043;
			BuyPrice = 735;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 18;
		}
	}
}


/**************************************************************
*
*				(Shimmering Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class ShimmeringBracers : Item
	{
		public ShimmeringBracers() : base()
		{
			Id = 6563;
			Resistance[0] = 15;
			Bonding = 2;
			SellPrice = 295;
			AvailableClasses = 0x7FFF;
			Model = 14750;
			ObjectClass = 4;
			SubClass = 1;
			Level = 20;
			ReqLevel = 15;
			Name = "Shimmering Bracers";
			Name2 = "Shimmering Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1045;
			BuyPrice = 1478;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Sage's Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class SagesBracers : Item
	{
		public SagesBracers() : base()
		{
			Id = 6613;
			Resistance[0] = 18;
			Bonding = 2;
			SellPrice = 744;
			AvailableClasses = 0x7FFF;
			Model = 16869;
			ObjectClass = 4;
			SubClass = 1;
			Level = 28;
			ReqLevel = 23;
			Name = "Sage's Bracers";
			Name2 = "Sage's Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1048;
			BuyPrice = 3722;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Disciple's Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class DisciplesBracers : Item
	{
		public DisciplesBracers() : base()
		{
			Id = 7350;
			Resistance[0] = 8;
			SellPrice = 29;
			AvailableClasses = 0x7FFF;
			Model = 16566;
			ObjectClass = 4;
			SubClass = 1;
			Level = 10;
			ReqLevel = 5;
			Name = "Disciple's Bracers";
			Name2 = "Disciple's Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 148;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 16;
		}
	}
}


/**************************************************************
*
*				(Elder's Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class EldersBracers : Item
	{
		public EldersBracers() : base()
		{
			Id = 7355;
			Resistance[0] = 19;
			Bonding = 2;
			SellPrice = 1031;
			AvailableClasses = 0x7FFF;
			Model = 16604;
			ObjectClass = 4;
			SubClass = 1;
			Level = 31;
			ReqLevel = 26;
			Name = "Elder's Bracers";
			Name2 = "Elder's Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1049;
			BuyPrice = 5155;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Twilight Cuffs)
*
***************************************************************/

namespace Server.Items
{
	public class TwilightCuffs : Item
	{
		public TwilightCuffs() : base()
		{
			Id = 7437;
			Resistance[0] = 21;
			Bonding = 2;
			SellPrice = 1554;
			AvailableClasses = 0x7FFF;
			Model = 14647;
			ObjectClass = 4;
			SubClass = 1;
			Level = 36;
			ReqLevel = 31;
			Name = "Twilight Cuffs";
			Name2 = "Twilight Cuffs";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1050;
			BuyPrice = 7772;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Regal Cuffs)
*
***************************************************************/

namespace Server.Items
{
	public class RegalCuffs : Item
	{
		public RegalCuffs() : base()
		{
			Id = 7475;
			Resistance[0] = 24;
			Bonding = 2;
			SellPrice = 2371;
			AvailableClasses = 0x7FFF;
			Model = 15410;
			ObjectClass = 4;
			SubClass = 1;
			Level = 41;
			ReqLevel = 36;
			Name = "Regal Cuffs";
			Name2 = "Regal Cuffs";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1052;
			BuyPrice = 11856;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Gossamer Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class GossamerBracers : Item
	{
		public GossamerBracers() : base()
		{
			Id = 7525;
			Resistance[0] = 26;
			Bonding = 2;
			SellPrice = 3106;
			AvailableClasses = 0x7FFF;
			Model = 15407;
			ObjectClass = 4;
			SubClass = 1;
			Level = 45;
			ReqLevel = 40;
			Name = "Gossamer Bracers";
			Name2 = "Gossamer Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1053;
			BuyPrice = 15530;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Hibernal Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class HibernalBracers : Item
	{
		public HibernalBracers() : base()
		{
			Id = 8108;
			Resistance[0] = 27;
			Bonding = 2;
			SellPrice = 3594;
			AvailableClasses = 0x7FFF;
			Model = 16636;
			ObjectClass = 4;
			SubClass = 1;
			Level = 47;
			ReqLevel = 42;
			Name = "Hibernal Bracers";
			Name2 = "Hibernal Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 17972;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			StaminaBonus = 3;
			SpiritBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Imperial Red Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class ImperialRedBracers : Item
	{
		public ImperialRedBracers() : base()
		{
			Id = 8247;
			Resistance[0] = 29;
			Bonding = 2;
			SellPrice = 4997;
			AvailableClasses = 0x7FFF;
			Model = 17229;
			ObjectClass = 4;
			SubClass = 1;
			Level = 51;
			ReqLevel = 46;
			Name = "Imperial Red Bracers";
			Name2 = "Imperial Red Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 24988;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			StaminaBonus = 3;
			SpiritBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Arcane Bands)
*
***************************************************************/

namespace Server.Items
{
	public class ArcaneBands : Item
	{
		public ArcaneBands() : base()
		{
			Id = 8285;
			Resistance[0] = 32;
			Bonding = 2;
			SellPrice = 6637;
			AvailableClasses = 0x7FFF;
			Model = 17262;
			ObjectClass = 4;
			SubClass = 1;
			Level = 56;
			ReqLevel = 51;
			Name = "Arcane Bands";
			Name2 = "Arcane Bands";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 33186;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			StaminaBonus = 6;
			SpiritBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Forgotten Wraps)
*
***************************************************************/

namespace Server.Items
{
	public class ForgottenWraps : Item
	{
		public ForgottenWraps() : base()
		{
			Id = 9433;
			Resistance[0] = 29;
			Bonding = 2;
			SellPrice = 4133;
			AvailableClasses = 0x7FFF;
			Model = 18337;
			ObjectClass = 4;
			SubClass = 1;
			Level = 46;
			ReqLevel = 41;
			Name = "Forgotten Wraps";
			Name2 = "Forgotten Wraps";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 20669;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 30;
			SpiritBonus = 12;
			StaminaBonus = 4;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Spidertank Oilrag)
*
***************************************************************/

namespace Server.Items
{
	public class SpidertankOilrag : Item
	{
		public SpidertankOilrag() : base()
		{
			Id = 9448;
			Resistance[0] = 20;
			Bonding = 1;
			SellPrice = 1154;
			AvailableClasses = 0x7FFF;
			Model = 18366;
			ObjectClass = 4;
			SubClass = 1;
			Level = 33;
			ReqLevel = 28;
			Name = "Spidertank Oilrag";
			Name2 = "Spidertank Oilrag";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5774;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			AgilityBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Simple Bands)
*
***************************************************************/

namespace Server.Items
{
	public class SimpleBands : Item
	{
		public SimpleBands() : base()
		{
			Id = 9744;
			Resistance[0] = 9;
			SellPrice = 44;
			AvailableClasses = 0x7FFF;
			Model = 14705;
			ObjectClass = 4;
			SubClass = 1;
			Level = 12;
			ReqLevel = 7;
			Name = "Simple Bands";
			Name2 = "Simple Bands";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 224;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 16;
		}
	}
}


/**************************************************************
*
*				(Greenweave Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class GreenweaveBracers : Item
	{
		public GreenweaveBracers() : base()
		{
			Id = 9768;
			Resistance[0] = 15;
			Bonding = 2;
			SellPrice = 317;
			AvailableClasses = 0x7FFF;
			Model = 25939;
			ObjectClass = 4;
			SubClass = 1;
			Level = 21;
			ReqLevel = 16;
			Name = "Greenweave Bracers";
			Name2 = "Greenweave Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1045;
			BuyPrice = 1586;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Ivycloth Bracelets)
*
***************************************************************/

namespace Server.Items
{
	public class IvyclothBracelets : Item
	{
		public IvyclothBracelets() : base()
		{
			Id = 9793;
			Resistance[0] = 17;
			Bonding = 2;
			SellPrice = 550;
			AvailableClasses = 0x7FFF;
			Model = 14736;
			ObjectClass = 4;
			SubClass = 1;
			Level = 25;
			ReqLevel = 20;
			Name = "Ivycloth Bracelets";
			Name2 = "Ivycloth Bracelets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1047;
			BuyPrice = 2753;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Durable Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class DurableBracers : Item
	{
		public DurableBracers() : base()
		{
			Id = 9821;
			Resistance[0] = 19;
			Bonding = 2;
			SellPrice = 871;
			AvailableClasses = 0x7FFF;
			Model = 27857;
			ObjectClass = 4;
			SubClass = 1;
			Level = 30;
			ReqLevel = 25;
			Name = "Durable Bracers";
			Name2 = "Durable Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1048;
			BuyPrice = 4357;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Conjurer's Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class ConjurersBracers : Item
	{
		public ConjurersBracers() : base()
		{
			Id = 9846;
			Resistance[0] = 20;
			Bonding = 2;
			SellPrice = 1429;
			AvailableClasses = 0x7FFF;
			Model = 28418;
			ObjectClass = 4;
			SubClass = 1;
			Level = 35;
			ReqLevel = 30;
			Name = "Conjurer's Bracers";
			Name2 = "Conjurer's Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1050;
			BuyPrice = 7148;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Sorcerer Bracelets)
*
***************************************************************/

namespace Server.Items
{
	public class SorcererBracelets : Item
	{
		public SorcererBracelets() : base()
		{
			Id = 9879;
			Resistance[0] = 23;
			Bonding = 2;
			SellPrice = 1964;
			AvailableClasses = 0x7FFF;
			Model = 28057;
			ObjectClass = 4;
			SubClass = 1;
			Level = 39;
			ReqLevel = 34;
			Name = "Sorcerer Bracelets";
			Name2 = "Sorcerer Bracelets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1051;
			BuyPrice = 9824;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Royal Bands)
*
***************************************************************/

namespace Server.Items
{
	public class RoyalBands : Item
	{
		public RoyalBands() : base()
		{
			Id = 9909;
			Resistance[0] = 25;
			Bonding = 2;
			SellPrice = 2848;
			AvailableClasses = 0x7FFF;
			Model = 28410;
			ObjectClass = 4;
			SubClass = 1;
			Level = 43;
			ReqLevel = 38;
			Name = "Royal Bands";
			Name2 = "Royal Bands";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1053;
			BuyPrice = 14242;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Abjurer's Bands)
*
***************************************************************/

namespace Server.Items
{
	public class AbjurersBands : Item
	{
		public AbjurersBands() : base()
		{
			Id = 9937;
			Resistance[0] = 27;
			Bonding = 2;
			SellPrice = 4004;
			AvailableClasses = 0x7FFF;
			Model = 16936;
			ObjectClass = 4;
			SubClass = 1;
			Level = 48;
			ReqLevel = 43;
			Name = "Abjurer's Bands";
			Name2 = "Abjurer's Bands";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1054;
			BuyPrice = 20023;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Duskwoven Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class DuskwovenBracers : Item
	{
		public DuskwovenBracers() : base()
		{
			Id = 10059;
			Resistance[0] = 29;
			Bonding = 2;
			SellPrice = 4739;
			AvailableClasses = 0x7FFF;
			Model = 28124;
			ObjectClass = 4;
			SubClass = 1;
			Level = 50;
			ReqLevel = 45;
			Name = "Duskwoven Bracers";
			Name2 = "Duskwoven Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1055;
			BuyPrice = 23697;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Councillor's Cuffs)
*
***************************************************************/

namespace Server.Items
{
	public class CouncillorsCuffs : Item
	{
		public CouncillorsCuffs() : base()
		{
			Id = 10096;
			Resistance[0] = 31;
			Bonding = 2;
			SellPrice = 6130;
			AvailableClasses = 0x7FFF;
			Model = 27601;
			ObjectClass = 4;
			SubClass = 1;
			Level = 54;
			ReqLevel = 49;
			Name = "Councillor's Cuffs";
			Name2 = "Councillor's Cuffs";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1056;
			BuyPrice = 30653;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(High Councillor's Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class HighCouncillorsBracers : Item
	{
		public HighCouncillorsBracers() : base()
		{
			Id = 10136;
			Resistance[0] = 34;
			Bonding = 2;
			SellPrice = 8530;
			AvailableClasses = 0x7FFF;
			Model = 27630;
			ObjectClass = 4;
			SubClass = 1;
			Level = 60;
			ReqLevel = 55;
			Name = "High Councillor's Bracers";
			Name2 = "High Councillor's Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1058;
			BuyPrice = 42653;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Mystical Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class MysticalBracers : Item
	{
		public MysticalBracers() : base()
		{
			Id = 10173;
			Resistance[0] = 30;
			Bonding = 2;
			SellPrice = 5718;
			AvailableClasses = 0x7FFF;
			Model = 28082;
			ObjectClass = 4;
			SubClass = 1;
			Level = 53;
			ReqLevel = 48;
			Name = "Mystical Bracers";
			Name2 = "Mystical Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1056;
			BuyPrice = 28592;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Elegant Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class ElegantBracers : Item
	{
		public ElegantBracers() : base()
		{
			Id = 10213;
			Resistance[0] = 33;
			Bonding = 2;
			SellPrice = 7850;
			AvailableClasses = 0x7FFF;
			Model = 27870;
			ObjectClass = 4;
			SubClass = 1;
			Level = 58;
			ReqLevel = 53;
			Name = "Elegant Bracers";
			Name2 = "Elegant Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1058;
			BuyPrice = 39251;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Master's Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class MastersBracers : Item
	{
		public MastersBracers() : base()
		{
			Id = 10248;
			Resistance[0] = 35;
			Bonding = 2;
			SellPrice = 9371;
			AvailableClasses = 0x7FFF;
			Model = 16892;
			ObjectClass = 4;
			SubClass = 1;
			Level = 62;
			ReqLevel = 57;
			Name = "Master's Bracers";
			Name2 = "Master's Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1059;
			BuyPrice = 46856;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Shadowy Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class ShadowyBracers : Item
	{
		public ShadowyBracers() : base()
		{
			Id = 10461;
			Resistance[0] = 26;
			Bonding = 1;
			SellPrice = 3082;
			AvailableClasses = 0x7FFF;
			Model = 19314;
			ObjectClass = 4;
			SubClass = 1;
			Level = 45;
			Name = "Shadowy Bracers";
			Name2 = "Shadowy Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 15410;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			SetSpell( 7706 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 8;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Firwillow Wristbands)
*
***************************************************************/

namespace Server.Items
{
	public class FirwillowWristbands : Item
	{
		public FirwillowWristbands() : base()
		{
			Id = 10705;
			Resistance[0] = 27;
			Bonding = 1;
			SellPrice = 3666;
			AvailableClasses = 0x7FFF;
			Model = 19915;
			ObjectClass = 4;
			SubClass = 1;
			Level = 47;
			Name = "Firwillow Wristbands";
			Name2 = "Firwillow Wristbands";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 18333;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			AgilityBonus = 2;
			SpiritBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Stemleaf Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class StemleafBracers : Item
	{
		public StemleafBracers() : base()
		{
			Id = 11187;
			Resistance[0] = 4;
			Bonding = 1;
			SellPrice = 5;
			AvailableClasses = 0x7FFF;
			Model = 25939;
			ObjectClass = 4;
			SubClass = 1;
			Level = 5;
			Name = "Stemleaf Bracers";
			Name2 = "Stemleaf Bracers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 25;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 14;
		}
	}
}


/**************************************************************
*
*				(Bloodband Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class BloodbandBracers : Item
	{
		public BloodbandBracers() : base()
		{
			Id = 11469;
			Resistance[0] = 26;
			Bonding = 1;
			SellPrice = 3563;
			AvailableClasses = 0x7FFF;
			Model = 14601;
			ObjectClass = 4;
			SubClass = 1;
			Level = 46;
			Name = "Bloodband Bracers";
			Name2 = "Bloodband Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 17815;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			SpiritBonus = 9;
			StaminaBonus = 4;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Flameweave Cuffs)
*
***************************************************************/

namespace Server.Items
{
	public class FlameweaveCuffs : Item
	{
		public FlameweaveCuffs() : base()
		{
			Id = 11766;
			Resistance[0] = 35;
			Bonding = 1;
			SellPrice = 8606;
			AvailableClasses = 0x7FFF;
			Model = 21755;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 1;
			Level = 57;
			ReqLevel = 52;
			Name = "Flameweave Cuffs";
			Name2 = "Flameweave Cuffs";
			Quality = 3;
			AvailableRaces = 0x1FF;
			Extra = 1059;
			BuyPrice = 43031;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Incendic Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class IncendicBracers : Item
	{
		public IncendicBracers() : base()
		{
			Id = 11768;
			Resistance[0] = 32;
			Bonding = 1;
			SellPrice = 7224;
			AvailableClasses = 0x7FFF;
			Model = 28785;
			Resistance[2] = 14;
			ObjectClass = 4;
			SubClass = 1;
			Level = 57;
			ReqLevel = 52;
			Name = "Incendic Bracers";
			Name2 = "Incendic Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 36121;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Breezecloud Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class BreezecloudBracers : Item
	{
		public BreezecloudBracers() : base()
		{
			Id = 11875;
			Resistance[0] = 31;
			Bonding = 1;
			SellPrice = 5776;
			AvailableClasses = 0x7FFF;
			Model = 28305;
			ObjectClass = 4;
			SubClass = 1;
			Level = 54;
			Name = "Breezecloud Bracers";
			Name2 = "Breezecloud Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 28881;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			StaminaBonus = 3;
			SpiritBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Shizzle's Nozzle Wiper)
*
***************************************************************/

namespace Server.Items
{
	public class ShizzlesNozzleWiper : Item
	{
		public ShizzlesNozzleWiper() : base()
		{
			Id = 11917;
			Resistance[0] = 31;
			Bonding = 1;
			SellPrice = 6334;
			AvailableClasses = 0x7FFF;
			Model = 28255;
			ObjectClass = 4;
			SubClass = 1;
			Level = 55;
			Name = "Shizzle's Nozzle Wiper";
			Name2 = "Shizzle's Nozzle Wiper";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 31674;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			StaminaBonus = 3;
			SpiritBonus = 12;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Manacle Cuffs)
*
***************************************************************/

namespace Server.Items
{
	public class ManacleCuffs : Item
	{
		public ManacleCuffs() : base()
		{
			Id = 11962;
			Resistance[0] = 34;
			Bonding = 1;
			SellPrice = 7939;
			AvailableClasses = 0x7FFF;
			Model = 17229;
			ObjectClass = 4;
			SubClass = 1;
			Level = 55;
			Name = "Manacle Cuffs";
			Name2 = "Manacle Cuffs";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 39699;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 30;
			StaminaBonus = 6;
			SpiritBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Aristocratic Cuffs)
*
***************************************************************/

namespace Server.Items
{
	public class AristocraticCuffs : Item
	{
		public AristocraticCuffs() : base()
		{
			Id = 12546;
			Resistance[0] = 34;
			Bonding = 2;
			SellPrice = 7463;
			AvailableClasses = 0x7FFF;
			Model = 28637;
			ObjectClass = 4;
			SubClass = 1;
			Level = 54;
			ReqLevel = 49;
			Name = "Aristocratic Cuffs";
			Name2 = "Aristocratic Cuffs";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 37316;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 30;
			SpiritBonus = 15;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Funeral Cuffs)
*
***************************************************************/

namespace Server.Items
{
	public class FuneralCuffs : Item
	{
		public FuneralCuffs() : base()
		{
			Id = 12626;
			Resistance[0] = 37;
			Bonding = 1;
			SellPrice = 9191;
			AvailableClasses = 0x7FFF;
			Model = 14618;
			ObjectClass = 4;
			SubClass = 1;
			Level = 59;
			ReqLevel = 54;
			Name = "Funeral Cuffs";
			Name2 = "Funeral Cuffs";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 45956;
			Resistance[5] = 10;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 30;
			SpiritBonus = 14;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Glowing Magical Bracelets)
*
***************************************************************/

namespace Server.Items
{
	public class GlowingMagicalBracelets : Item
	{
		public GlowingMagicalBracelets() : base()
		{
			Id = 13106;
			Resistance[0] = 21;
			Bonding = 2;
			SellPrice = 1216;
			AvailableClasses = 0x7FFF;
			Model = 28656;
			ObjectClass = 4;
			SubClass = 1;
			Level = 31;
			ReqLevel = 26;
			Name = "Glowing Magical Bracelets";
			Name2 = "Glowing Magical Bracelets";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 6081;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 30;
			SpiritBonus = 8;
			StrBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Magiskull Cuffs)
*
***************************************************************/

namespace Server.Items
{
	public class MagiskullCuffs : Item
	{
		public MagiskullCuffs() : base()
		{
			Id = 13107;
			Resistance[0] = 38;
			Bonding = 2;
			SellPrice = 11291;
			AvailableClasses = 0x7FFF;
			Model = 28619;
			ObjectClass = 4;
			SubClass = 1;
			Level = 62;
			ReqLevel = 57;
			Name = "Magiskull Cuffs";
			Name2 = "Magiskull Cuffs";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 56457;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 30;
			SpiritBonus = 17;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Tearfall Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class TearfallBracers : Item
	{
		public TearfallBracers() : base()
		{
			Id = 13409;
			Resistance[0] = 35;
			Bonding = 1;
			SellPrice = 8119;
			AvailableClasses = 0x7FFF;
			Model = 24120;
			ObjectClass = 4;
			SubClass = 1;
			Level = 57;
			ReqLevel = 52;
			Name = "Tearfall Bracers";
			Name2 = "Tearfall Bracers";
			Quality = 3;
			AvailableRaces = 0x1FF;
			Extra = 1059;
			BuyPrice = 40596;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Wyrmthalak's Shackles)
*
***************************************************************/

namespace Server.Items
{
	public class WyrmthalaksShackles : Item
	{
		public WyrmthalaksShackles() : base()
		{
			Id = 13958;
			Resistance[0] = 37;
			Bonding = 1;
			SellPrice = 9505;
			AvailableClasses = 0x7FFF;
			Model = 24767;
			ObjectClass = 4;
			SubClass = 1;
			Level = 60;
			Name = "Wyrmthalak's Shackles";
			Name2 = "Wyrmthalak's Shackles";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 47528;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 30;
			IqBonus = 15;
			SpiritBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Beaded Cuffs)
*
***************************************************************/

namespace Server.Items
{
	public class BeadedCuffs : Item
	{
		public BeadedCuffs() : base()
		{
			Id = 14087;
			Resistance[0] = 7;
			SellPrice = 16;
			AvailableClasses = 0x7FFF;
			Model = 25864;
			ObjectClass = 4;
			SubClass = 1;
			Level = 8;
			ReqLevel = 3;
			Name = "Beaded Cuffs";
			Name2 = "Beaded Cuffs";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 82;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 14;
		}
	}
}


/**************************************************************
*
*				(Native Bands)
*
***************************************************************/

namespace Server.Items
{
	public class NativeBands : Item
	{
		public NativeBands() : base()
		{
			Id = 14095;
			Resistance[0] = 9;
			SellPrice = 36;
			AvailableClasses = 0x7FFF;
			Model = 25874;
			ObjectClass = 4;
			SubClass = 1;
			Level = 11;
			ReqLevel = 6;
			Name = "Native Bands";
			Name2 = "Native Bands";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 182;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 16;
		}
	}
}


/**************************************************************
*
*				(Aboriginal Bands)
*
***************************************************************/

namespace Server.Items
{
	public class AboriginalBands : Item
	{
		public AboriginalBands() : base()
		{
			Id = 14115;
			Resistance[0] = 11;
			SellPrice = 70;
			AvailableClasses = 0x7FFF;
			Model = 14541;
			ObjectClass = 4;
			SubClass = 1;
			Level = 14;
			ReqLevel = 9;
			Name = "Aboriginal Bands";
			Name2 = "Aboriginal Bands";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 351;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 18;
		}
	}
}


/**************************************************************
*
*				(Ritual Bands)
*
***************************************************************/

namespace Server.Items
{
	public class RitualBands : Item
	{
		public RitualBands() : base()
		{
			Id = 14122;
			Resistance[0] = 14;
			Bonding = 2;
			SellPrice = 219;
			AvailableClasses = 0x7FFF;
			Model = 16664;
			ObjectClass = 4;
			SubClass = 1;
			Level = 18;
			ReqLevel = 13;
			Name = "Ritual Bands";
			Name2 = "Ritual Bands";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1044;
			BuyPrice = 1098;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Crystalline Cuffs)
*
***************************************************************/

namespace Server.Items
{
	public class CrystallineCuffs : Item
	{
		public CrystallineCuffs() : base()
		{
			Id = 14148;
			Resistance[0] = 14;
			Bonding = 1;
			SellPrice = 208;
			AvailableClasses = 0x7FFF;
			Model = 24983;
			ObjectClass = 4;
			SubClass = 1;
			Level = 18;
			ReqLevel = 13;
			Name = "Crystalline Cuffs";
			Name2 = "Crystalline Cuffs";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1043;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 20;
			IqBonus = 2;
			SpiritBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Pagan Bands)
*
***************************************************************/

namespace Server.Items
{
	public class PaganBands : Item
	{
		public PaganBands() : base()
		{
			Id = 14160;
			Resistance[0] = 14;
			Bonding = 2;
			SellPrice = 251;
			AvailableClasses = 0x7FFF;
			Model = 16907;
			ObjectClass = 4;
			SubClass = 1;
			Level = 19;
			ReqLevel = 14;
			Name = "Pagan Bands";
			Name2 = "Pagan Bands";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1045;
			BuyPrice = 1255;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Buccaneer's Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class BuccaneersBracers : Item
	{
		public BuccaneersBracers() : base()
		{
			Id = 14166;
			Resistance[0] = 14;
			Bonding = 2;
			SellPrice = 238;
			AvailableClasses = 0x7FFF;
			Model = 28050;
			ObjectClass = 4;
			SubClass = 1;
			Level = 19;
			ReqLevel = 14;
			Name = "Buccaneer's Bracers";
			Name2 = "Buccaneer's Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1045;
			BuyPrice = 1191;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Watcher's Cuffs)
*
***************************************************************/

namespace Server.Items
{
	public class WatchersCuffs : Item
	{
		public WatchersCuffs() : base()
		{
			Id = 14177;
			Resistance[0] = 17;
			Bonding = 2;
			SellPrice = 631;
			AvailableClasses = 0x7FFF;
			Model = 25970;
			ObjectClass = 4;
			SubClass = 1;
			Level = 26;
			ReqLevel = 21;
			Name = "Watcher's Cuffs";
			Name2 = "Watcher's Cuffs";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1047;
			BuyPrice = 3159;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Raincaller Cuffs)
*
***************************************************************/

namespace Server.Items
{
	public class RaincallerCuffs : Item
	{
		public RaincallerCuffs() : base()
		{
			Id = 14187;
			Resistance[0] = 18;
			Bonding = 2;
			SellPrice = 717;
			AvailableClasses = 0x7FFF;
			Model = 14640;
			ObjectClass = 4;
			SubClass = 1;
			Level = 28;
			ReqLevel = 23;
			Name = "Raincaller Cuffs";
			Name2 = "Raincaller Cuffs";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1048;
			BuyPrice = 3587;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Thistlefur Bands)
*
***************************************************************/

namespace Server.Items
{
	public class ThistlefurBands : Item
	{
		public ThistlefurBands() : base()
		{
			Id = 14197;
			Resistance[0] = 19;
			Bonding = 2;
			SellPrice = 925;
			AvailableClasses = 0x7FFF;
			Model = 26004;
			ObjectClass = 4;
			SubClass = 1;
			Level = 30;
			ReqLevel = 25;
			Name = "Thistlefur Bands";
			Name2 = "Thistlefur Bands";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1048;
			BuyPrice = 4625;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Vital Bracelets)
*
***************************************************************/

namespace Server.Items
{
	public class VitalBracelets : Item
	{
		public VitalBracelets() : base()
		{
			Id = 14206;
			Resistance[0] = 19;
			Bonding = 2;
			SellPrice = 1046;
			AvailableClasses = 0x7FFF;
			Model = 25970;
			ObjectClass = 4;
			SubClass = 1;
			Level = 32;
			ReqLevel = 27;
			Name = "Vital Bracelets";
			Name2 = "Vital Bracelets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1049;
			BuyPrice = 5232;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Geomancer's Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class GeomancersBracers : Item
	{
		public GeomancersBracers() : base()
		{
			Id = 14221;
			Resistance[0] = 20;
			Bonding = 2;
			SellPrice = 1510;
			AvailableClasses = 0x7FFF;
			Model = 26042;
			ObjectClass = 4;
			SubClass = 1;
			Level = 35;
			ReqLevel = 30;
			Name = "Geomancer's Bracers";
			Name2 = "Geomancer's Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1050;
			BuyPrice = 7554;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Embersilk Bracelets)
*
***************************************************************/

namespace Server.Items
{
	public class EmbersilkBracelets : Item
	{
		public EmbersilkBracelets() : base()
		{
			Id = 14226;
			Resistance[0] = 21;
			Bonding = 2;
			SellPrice = 1731;
			AvailableClasses = 0x7FFF;
			Model = 26055;
			ObjectClass = 4;
			SubClass = 1;
			Level = 37;
			ReqLevel = 32;
			Name = "Embersilk Bracelets";
			Name2 = "Embersilk Bracelets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1051;
			BuyPrice = 8658;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Darkmist Bands)
*
***************************************************************/

namespace Server.Items
{
	public class DarkmistBands : Item
	{
		public DarkmistBands() : base()
		{
			Id = 14240;
			Resistance[0] = 23;
			Bonding = 2;
			SellPrice = 2294;
			AvailableClasses = 0x7FFF;
			Model = 16604;
			ObjectClass = 4;
			SubClass = 1;
			Level = 40;
			ReqLevel = 35;
			Name = "Darkmist Bands";
			Name2 = "Darkmist Bands";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1052;
			BuyPrice = 11473;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Lunar Bindings)
*
***************************************************************/

namespace Server.Items
{
	public class LunarBindings : Item
	{
		public LunarBindings() : base()
		{
			Id = 14248;
			Resistance[0] = 24;
			Bonding = 2;
			SellPrice = 2372;
			AvailableClasses = 0x7FFF;
			Model = 14647;
			ObjectClass = 4;
			SubClass = 1;
			Level = 41;
			ReqLevel = 36;
			Name = "Lunar Bindings";
			Name2 = "Lunar Bindings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1052;
			BuyPrice = 11864;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Bloodwoven Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class BloodwovenBracers : Item
	{
		public BloodwovenBracers() : base()
		{
			Id = 14260;
			Resistance[0] = 25;
			Bonding = 2;
			SellPrice = 2900;
			AvailableClasses = 0x7FFF;
			Model = 26187;
			ObjectClass = 4;
			SubClass = 1;
			Level = 44;
			ReqLevel = 39;
			Name = "Bloodwoven Bracers";
			Name2 = "Bloodwoven Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1053;
			BuyPrice = 14503;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Gaea's Cuffs)
*
***************************************************************/

namespace Server.Items
{
	public class GaeasCuffs : Item
	{
		public GaeasCuffs() : base()
		{
			Id = 14268;
			Resistance[0] = 26;
			Bonding = 2;
			SellPrice = 3486;
			AvailableClasses = 0x7FFF;
			Model = 17262;
			ObjectClass = 4;
			SubClass = 1;
			Level = 46;
			ReqLevel = 41;
			Name = "Gaea's Cuffs";
			Name2 = "Gaea's Cuffs";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1054;
			BuyPrice = 17432;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Opulent Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class OpulentBracers : Item
	{
		public OpulentBracers() : base()
		{
			Id = 14279;
			Resistance[0] = 28;
			Bonding = 2;
			SellPrice = 4206;
			AvailableClasses = 0x7FFF;
			Model = 14618;
			ObjectClass = 4;
			SubClass = 1;
			Level = 49;
			ReqLevel = 44;
			Name = "Opulent Bracers";
			Name2 = "Opulent Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1055;
			BuyPrice = 21031;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Arachnidian Bracelets)
*
***************************************************************/

namespace Server.Items
{
	public class ArachnidianBracelets : Item
	{
		public ArachnidianBracelets() : base()
		{
			Id = 14291;
			Resistance[0] = 29;
			Bonding = 2;
			SellPrice = 4830;
			AvailableClasses = 0x7FFF;
			Model = 26205;
			ObjectClass = 4;
			SubClass = 1;
			Level = 50;
			ReqLevel = 45;
			Name = "Arachnidian Bracelets";
			Name2 = "Arachnidian Bracelets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1055;
			BuyPrice = 24153;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Bonecaster's Bindings)
*
***************************************************************/

namespace Server.Items
{
	public class BonecastersBindings : Item
	{
		public BonecastersBindings() : base()
		{
			Id = 14301;
			Resistance[0] = 30;
			Bonding = 2;
			SellPrice = 5451;
			AvailableClasses = 0x7FFF;
			Model = 26266;
			ObjectClass = 4;
			SubClass = 1;
			Level = 53;
			ReqLevel = 48;
			Name = "Bonecaster's Bindings";
			Name2 = "Bonecaster's Bindings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1056;
			BuyPrice = 27257;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Celestial Bindings)
*
***************************************************************/

namespace Server.Items
{
	public class CelestialBindings : Item
	{
		public CelestialBindings() : base()
		{
			Id = 14311;
			Resistance[0] = 31;
			Bonding = 2;
			SellPrice = 6524;
			AvailableClasses = 0x7FFF;
			Model = 26253;
			ObjectClass = 4;
			SubClass = 1;
			Level = 55;
			ReqLevel = 50;
			Name = "Celestial Bindings";
			Name2 = "Celestial Bindings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1057;
			BuyPrice = 32621;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Resplendent Bracelets)
*
***************************************************************/

namespace Server.Items
{
	public class ResplendentBracelets : Item
	{
		public ResplendentBracelets() : base()
		{
			Id = 14320;
			Resistance[0] = 32;
			Bonding = 2;
			SellPrice = 6855;
			AvailableClasses = 0x7FFF;
			Model = 26287;
			ObjectClass = 4;
			SubClass = 1;
			Level = 57;
			ReqLevel = 52;
			Name = "Resplendent Bracelets";
			Name2 = "Resplendent Bracelets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1057;
			BuyPrice = 34277;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Eternal Bindings)
*
***************************************************************/

namespace Server.Items
{
	public class EternalBindings : Item
	{
		public EternalBindings() : base()
		{
			Id = 14330;
			Resistance[0] = 34;
			Bonding = 2;
			SellPrice = 8962;
			AvailableClasses = 0x7FFF;
			Model = 26216;
			ObjectClass = 4;
			SubClass = 1;
			Level = 61;
			ReqLevel = 56;
			Name = "Eternal Bindings";
			Name2 = "Eternal Bindings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1059;
			BuyPrice = 44812;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Mystic's Bracelets)
*
***************************************************************/

namespace Server.Items
{
	public class MysticsBracelets : Item
	{
		public MysticsBracelets() : base()
		{
			Id = 14366;
			Resistance[0] = 13;
			Bonding = 2;
			SellPrice = 189;
			AvailableClasses = 0x7FFF;
			Model = 16805;
			ObjectClass = 4;
			SubClass = 1;
			Level = 17;
			ReqLevel = 12;
			Name = "Mystic's Bracelets";
			Name2 = "Mystic's Bracelets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 948;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 20;
			SpiritBonus = 2;
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Sanguine Cuffs)
*
***************************************************************/

namespace Server.Items
{
	public class SanguineCuffs : Item
	{
		public SanguineCuffs() : base()
		{
			Id = 14375;
			Resistance[0] = 17;
			Bonding = 2;
			SellPrice = 528;
			AvailableClasses = 0x7FFF;
			Model = 25959;
			ObjectClass = 4;
			SubClass = 1;
			Level = 25;
			ReqLevel = 20;
			Name = "Sanguine Cuffs";
			Name2 = "Sanguine Cuffs";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2644;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			StaminaBonus = 4;
			IqBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Resilient Bands)
*
***************************************************************/

namespace Server.Items
{
	public class ResilientBands : Item
	{
		public ResilientBands() : base()
		{
			Id = 14402;
			Resistance[0] = 18;
			Bonding = 2;
			SellPrice = 837;
			AvailableClasses = 0x7FFF;
			Model = 25994;
			ObjectClass = 4;
			SubClass = 1;
			Level = 29;
			ReqLevel = 24;
			Name = "Resilient Bands";
			Name2 = "Resilient Bands";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4189;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			StaminaBonus = 4;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Stonecloth Bindings)
*
***************************************************************/

namespace Server.Items
{
	public class StoneclothBindings : Item
	{
		public StoneclothBindings() : base()
		{
			Id = 14416;
			Resistance[0] = 20;
			Bonding = 2;
			SellPrice = 1285;
			AvailableClasses = 0x7FFF;
			Model = 26025;
			ObjectClass = 4;
			SubClass = 1;
			Level = 34;
			ReqLevel = 29;
			Name = "Stonecloth Bindings";
			Name2 = "Stonecloth Bindings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6429;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			SpiritBonus = 5;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Silksand Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class SilksandBracers : Item
	{
		public SilksandBracers() : base()
		{
			Id = 14419;
			Resistance[0] = 22;
			Bonding = 2;
			SellPrice = 1919;
			AvailableClasses = 0x7FFF;
			Model = 26079;
			ObjectClass = 4;
			SubClass = 1;
			Level = 38;
			ReqLevel = 33;
			Name = "Silksand Bracers";
			Name2 = "Silksand Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 9596;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			StaminaBonus = 6;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Windchaser Cuffs)
*
***************************************************************/

namespace Server.Items
{
	public class WindchaserCuffs : Item
	{
		public WindchaserCuffs() : base()
		{
			Id = 14429;
			Resistance[0] = 25;
			Bonding = 2;
			SellPrice = 2644;
			AvailableClasses = 0x7FFF;
			Model = 26151;
			ObjectClass = 4;
			SubClass = 1;
			Level = 43;
			ReqLevel = 38;
			Name = "Windchaser Cuffs";
			Name2 = "Windchaser Cuffs";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 13220;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			AgilityBonus = 2;
			SpiritBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Venomshroud Armguards)
*
***************************************************************/

namespace Server.Items
{
	public class VenomshroudArmguards : Item
	{
		public VenomshroudArmguards() : base()
		{
			Id = 14439;
			Resistance[0] = 27;
			Bonding = 2;
			SellPrice = 3836;
			AvailableClasses = 0x7FFF;
			Model = 16636;
			ObjectClass = 4;
			SubClass = 1;
			Level = 47;
			ReqLevel = 42;
			Name = "Venomshroud Armguards";
			Name2 = "Venomshroud Armguards";
			Resistance[3] = 3;
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 19180;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			IqBonus = 8;
			SpiritBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Highborne Bracelets)
*
***************************************************************/

namespace Server.Items
{
	public class HighborneBracelets : Item
	{
		public HighborneBracelets() : base()
		{
			Id = 14448;
			Resistance[0] = 30;
			Bonding = 2;
			SellPrice = 5555;
			AvailableClasses = 0x7FFF;
			Model = 26168;
			ObjectClass = 4;
			SubClass = 1;
			Level = 52;
			ReqLevel = 47;
			Name = "Highborne Bracelets";
			Name2 = "Highborne Bracelets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 27777;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			SpiritBonus = 9;
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Elunarian Cuffs)
*
***************************************************************/

namespace Server.Items
{
	public class ElunarianCuffs : Item
	{
		public ElunarianCuffs() : base()
		{
			Id = 14457;
			Resistance[0] = 33;
			Bonding = 2;
			SellPrice = 7575;
			AvailableClasses = 0x7FFF;
			Model = 26235;
			ObjectClass = 4;
			SubClass = 1;
			Level = 58;
			ReqLevel = 53;
			Name = "Elunarian Cuffs";
			Name2 = "Elunarian Cuffs";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 37878;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			StaminaBonus = 9;
			IqBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Necropile Cuffs)
*
***************************************************************/

namespace Server.Items
{
	public class NecropileCuffs : Item
	{
		public NecropileCuffs() : base()
		{
			Id = 14629;
			Resistance[0] = 34;
			Bonding = 1;
			SellPrice = 8965;
			AvailableClasses = 0x7FFF;
			Model = 4607;
			ObjectClass = 4;
			SubClass = 1;
			Level = 61;
			ReqLevel = 56;
			Name = "Necropile Cuffs";
			Name2 = "Necropile Cuffs";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 44825;
			Sets = 122;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			StaminaBonus = 5;
			IqBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Featherbead Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class FeatherbeadBracers : Item
	{
		public FeatherbeadBracers() : base()
		{
			Id = 15452;
			Resistance[0] = 14;
			Bonding = 1;
			SellPrice = 215;
			AvailableClasses = 0x7FFF;
			Model = 28168;
			ObjectClass = 4;
			SubClass = 1;
			Level = 18;
			Name = "Featherbead Bracers";
			Name2 = "Featherbead Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1075;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 20;
			SpiritBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Condor Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class CondorBracers : Item
	{
		public CondorBracers() : base()
		{
			Id = 15864;
			Resistance[0] = 23;
			Bonding = 1;
			SellPrice = 1947;
			AvailableClasses = 0x7FFF;
			Model = 3658;
			ObjectClass = 4;
			SubClass = 1;
			Level = 39;
			Name = "Condor Bracers";
			Name2 = "Condor Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 9738;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			StaminaBonus = 6;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(First Sergeant's Silk Cuffs)
*
***************************************************************/

namespace Server.Items
{
	public class FirstSergeantsSilkCuffs : Item
	{
		public FirstSergeantsSilkCuffs() : base()
		{
			Id = 16486;
			Resistance[0] = 39;
			Bonding = 1;
			SellPrice = 5695;
			AvailableClasses = 0x190;
			Model = 27255;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "First Sergeant's Silk Cuffs";
			Name2 = "First Sergeant's Silk Cuffs";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 28477;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 30;
			Flags = 32768;
			StaminaBonus = 17;
			SpiritBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Magister's Bindings)
*
***************************************************************/

namespace Server.Items
{
	public class MagistersBindings : Item
	{
		public MagistersBindings() : base()
		{
			Id = 16683;
			Resistance[0] = 35;
			Bonding = 2;
			SellPrice = 8765;
			AvailableClasses = 0x7FFF;
			Model = 29597;
			ObjectClass = 4;
			SubClass = 1;
			Level = 57;
			ReqLevel = 52;
			Name = "Magister's Bindings";
			Name2 = "Magister's Bindings";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 43827;
			Sets = 181;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 30;
			SpiritBonus = 15;
			IqBonus = 5;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Devout Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class DevoutBracers : Item
	{
		public DevoutBracers() : base()
		{
			Id = 16697;
			Resistance[0] = 35;
			Bonding = 2;
			SellPrice = 8577;
			AvailableClasses = 0x7FFF;
			Model = 30426;
			ObjectClass = 4;
			SubClass = 1;
			Level = 57;
			ReqLevel = 52;
			Name = "Devout Bracers";
			Name2 = "Devout Bracers";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 42886;
			Sets = 182;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 30;
			SpiritBonus = 10;
			IqBonus = 10;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Dreadmist Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class DreadmistBracers : Item
	{
		public DreadmistBracers() : base()
		{
			Id = 16703;
			Resistance[0] = 35;
			Bonding = 2;
			SellPrice = 8138;
			AvailableClasses = 0x7FFF;
			Model = 29795;
			ObjectClass = 4;
			SubClass = 1;
			Level = 57;
			ReqLevel = 52;
			Name = "Dreadmist Bracers";
			Name2 = "Dreadmist Bracers";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 40690;
			Sets = 183;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 30;
			SpiritBonus = 10;
			StaminaBonus = 10;
			IqBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Silkstream Cuffs)
*
***************************************************************/

namespace Server.Items
{
	public class SilkstreamCuffs : Item
	{
		public SilkstreamCuffs() : base()
		{
			Id = 16791;
			Resistance[0] = 22;
			Bonding = 1;
			SellPrice = 1912;
			AvailableClasses = 0x7FFF;
			Model = 26168;
			ObjectClass = 4;
			SubClass = 1;
			Level = 38;
			Name = "Silkstream Cuffs";
			Name2 = "Silkstream Cuffs";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 9561;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			StaminaBonus = 4;
			IqBonus = 4;
			SpiritBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Arcanist Bindings)
*
***************************************************************/

namespace Server.Items
{
	public class ArcanistBindings : Item
	{
		public ArcanistBindings() : base()
		{
			Id = 16799;
			Resistance[6] = 4;
			Resistance[0] = 44;
			Bonding = 2;
			SellPrice = 17192;
			AvailableClasses = 0x80;
			Model = 30584;
			Resistance[2] = 7;
			Resistance[4] = 4;
			ObjectClass = 4;
			SubClass = 1;
			Level = 66;
			ReqLevel = 60;
			Name = "Arcanist Bindings";
			Name2 = "Arcanist Bindings";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 85963;
			Sets = 201;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			SetSpell( 9396 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 21624 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 20;
			IqBonus = 8;
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Felheart Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class FelheartBracers : Item
	{
		public FelheartBracers() : base()
		{
			Id = 16804;
			Resistance[0] = 44;
			Bonding = 2;
			SellPrice = 17517;
			AvailableClasses = 0x100;
			Model = 31970;
			ObjectClass = 4;
			SubClass = 1;
			Level = 66;
			ReqLevel = 60;
			Name = "Felheart Bracers";
			Name2 = "Felheart Bracers";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 87589;
			Sets = 203;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			SetSpell( 21346 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 7708 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 11;
			IqBonus = 8;
			StaminaBonus = 18;
		}
	}
}


/**************************************************************
*
*				(Vambraces of Prophecy)
*
***************************************************************/

namespace Server.Items
{
	public class VambracesOfProphecy : Item
	{
		public VambracesOfProphecy() : base()
		{
			Id = 16819;
			Resistance[0] = 44;
			Bonding = 2;
			SellPrice = 17189;
			AvailableClasses = 0x10;
			Model = 30617;
			ObjectClass = 4;
			SubClass = 1;
			Level = 66;
			ReqLevel = 60;
			Name = "Vambraces of Prophecy";
			Name2 = "Vambraces of Prophecy";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 85945;
			Sets = 202;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			SetSpell( 21624 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 9407 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 12;
			IqBonus = 7;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Netherwind Bindings)
*
***************************************************************/

namespace Server.Items
{
	public class NetherwindBindings : Item
	{
		public NetherwindBindings() : base()
		{
			Id = 16918;
			Resistance[0] = 51;
			Bonding = 1;
			SellPrice = 28642;
			AvailableClasses = 0x80;
			Model = 29871;
			ObjectClass = 4;
			SubClass = 1;
			Level = 76;
			ReqLevel = 60;
			Name = "Netherwind Bindings";
			Name2 = "Netherwind Bindings";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 143210;
			Sets = 210;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			SetSpell( 9416 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 19;
			IqBonus = 9;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Bindings of Transcendence)
*
***************************************************************/

namespace Server.Items
{
	public class BindingsOfTranscendence : Item
	{
		public BindingsOfTranscendence() : base()
		{
			Id = 16926;
			Resistance[0] = 51;
			Bonding = 1;
			SellPrice = 30260;
			AvailableClasses = 0x10;
			Model = 29779;
			ObjectClass = 4;
			SubClass = 1;
			Level = 76;
			ReqLevel = 60;
			Name = "Bindings of Transcendence";
			Name2 = "Bindings of Transcendence";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 151303;
			Sets = 211;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			SetSpell( 9318 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 13;
			IqBonus = 16;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Nemesis Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class NemesisBracers : Item
	{
		public NemesisBracers() : base()
		{
			Id = 16934;
			Resistance[0] = 51;
			Bonding = 1;
			SellPrice = 28213;
			AvailableClasses = 0x100;
			Model = 29854;
			ObjectClass = 4;
			SubClass = 1;
			Level = 76;
			ReqLevel = 60;
			Name = "Nemesis Bracers";
			Name2 = "Nemesis Bracers";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 141067;
			Sets = 212;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			SetSpell( 9397 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 13;
			IqBonus = 9;
			StaminaBonus = 21;
		}
	}
}


/**************************************************************
*
*				(Owlbeard Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class OwlbeardBracers : Item
	{
		public OwlbeardBracers() : base()
		{
			Id = 16981;
			Resistance[0] = 15;
			Bonding = 1;
			SellPrice = 271;
			AvailableClasses = 0x7FFF;
			Model = 16664;
			ObjectClass = 4;
			SubClass = 1;
			Level = 20;
			Name = "Owlbeard Bracers";
			Name2 = "Owlbeard Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1356;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 20;
			SpiritBonus = 2;
			StaminaBonus = 1;
			IqBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Flarecore Wraps)
*
***************************************************************/

namespace Server.Items
{
	public class FlarecoreWraps : Item
	{
		public FlarecoreWraps() : base()
		{
			Id = 18263;
			Resistance[0] = 43;
			Bonding = 2;
			SellPrice = 16911;
			AvailableClasses = 0x5FF;
			Model = 27972;
			Resistance[2] = 7;
			ObjectClass = 4;
			SubClass = 1;
			Level = 64;
			ReqLevel = 60;
			Name = "Flarecore Wraps";
			Name2 = "Flarecore Wraps";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 84557;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			SetSpell( 21365 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Orphic Bracers)
*
***************************************************************/

namespace Server.Items
{
	public class OrphicBracers : Item
	{
		public OrphicBracers() : base()
		{
			Id = 18337;
			Resistance[0] = 33;
			Bonding = 1;
			SellPrice = 8103;
			AvailableClasses = 0x7FFF;
			Model = 30693;
			ObjectClass = 4;
			SubClass = 1;
			Level = 59;
			ReqLevel = 54;
			Name = "Orphic Bracers";
			Name2 = "Orphic Bracers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 40516;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			SetSpell( 13597 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 7;
			IqBonus = 7;
		}
	}
}


/**************************************************************
*
*				(First Sergeant's Silk Cuffs)
*
***************************************************************/

namespace Server.Items
{
	public class FirstSergeantsSilkCuffs18437 : Item
	{
		public FirstSergeantsSilkCuffs18437() : base()
		{
			Id = 18437;
			Resistance[0] = 31;
			Bonding = 1;
			SellPrice = 2744;
			AvailableClasses = 0x190;
			Model = 27255;
			ObjectClass = 4;
			SubClass = 1;
			Level = 50;
			ReqLevel = 45;
			Name = "First Sergeant's Silk Cuffs";
			Name2 = "First Sergeant's Silk Cuffs";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 13721;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 30;
			Flags = 32768;
			StaminaBonus = 14;
			SpiritBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Sergeant Major's Silk Cuffs)
*
***************************************************************/

namespace Server.Items
{
	public class SergeantMajorsSilkCuffs : Item
	{
		public SergeantMajorsSilkCuffs() : base()
		{
			Id = 18456;
			Resistance[0] = 39;
			Bonding = 1;
			SellPrice = 5613;
			AvailableClasses = 0x190;
			Model = 30806;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Sergeant Major's Silk Cuffs";
			Name2 = "Sergeant Major's Silk Cuffs";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 28065;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 30;
			Flags = 32768;
			StaminaBonus = 18;
			SpiritBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Sergeant Major's Silk Cuffs)
*
***************************************************************/

namespace Server.Items
{
	public class SergeantMajorsSilkCuffs18457 : Item
	{
		public SergeantMajorsSilkCuffs18457() : base()
		{
			Id = 18457;
			Resistance[0] = 31;
			Bonding = 1;
			SellPrice = 2674;
			AvailableClasses = 0x190;
			Model = 30806;
			ObjectClass = 4;
			SubClass = 1;
			Level = 50;
			ReqLevel = 45;
			Name = "Sergeant Major's Silk Cuffs";
			Name2 = "Sergeant Major's Silk Cuffs";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 13373;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 30;
			Flags = 32768;
			StaminaBonus = 14;
			SpiritBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Sublime Wristguards)
*
***************************************************************/

namespace Server.Items
{
	public class SublimeWristguards : Item
	{
		public SublimeWristguards() : base()
		{
			Id = 18497;
			Resistance[0] = 37;
			Bonding = 1;
			SellPrice = 9488;
			AvailableClasses = 0x7FFF;
			Model = 30833;
			ObjectClass = 4;
			SubClass = 1;
			Level = 60;
			ReqLevel = 55;
			Name = "Sublime Wristguards";
			Name2 = "Sublime Wristguards";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 47443;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 30;
			SetSpell( 9417 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 10;
			IqBonus = 6;
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Arena Wristguards)
*
***************************************************************/

namespace Server.Items
{
	public class ArenaWristguards : Item
	{
		public ArenaWristguards() : base()
		{
			Id = 18709;
			Resistance[0] = 31;
			Bonding = 2;
			SellPrice = 5758;
			AvailableClasses = 0x7FFF;
			Model = 31151;
			ObjectClass = 4;
			SubClass = 1;
			Level = 50;
			ReqLevel = 45;
			Name = "Arena Wristguards";
			Name2 = "Arena Wristguards";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 28794;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 6;
			Durability = 30;
			SetSpell( 18384 , 1 , 0 , -1 , 0 , -1 );
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Blacklight Bracer)
*
***************************************************************/

namespace Server.Items
{
	public class BlacklightBracer : Item
	{
		public BlacklightBracer() : base()
		{
			Id = 19135;
			Resistance[0] = 44;
			Bonding = 1;
			SellPrice = 16954;
			AvailableClasses = 0x7FFF;
			Model = 14618;
			ObjectClass = 4;
			SubClass = 1;
			Level = 66;
			ReqLevel = 60;
			Name = "Blacklight Bracer";
			Name2 = "Blacklight Bracer";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 84772;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			SetSpell( 18384 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 13;
			IqBonus = 8;
			StaminaBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Bracers of Arcane Accuracy)
*
***************************************************************/

namespace Server.Items
{
	public class BracersOfArcaneAccuracy : Item
	{
		public BracersOfArcaneAccuracy() : base()
		{
			Id = 19374;
			Resistance[0] = 50;
			Bonding = 1;
			SellPrice = 26268;
			AvailableClasses = 0x7FFF;
			Model = 31892;
			ObjectClass = 4;
			SubClass = 1;
			Level = 75;
			ReqLevel = 60;
			Name = "Bracers of Arcane Accuracy";
			Name2 = "Bracers of Arcane Accuracy";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 131344;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			SetSpell( 23727 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 14248 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 12;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Dryad's Wrist Bindings)
*
***************************************************************/

namespace Server.Items
{
	public class DryadsWristBindings : Item
	{
		public DryadsWristBindings() : base()
		{
			Id = 19595;
			Resistance[0] = 44;
			Bonding = 1;
			SellPrice = 17509;
			AvailableClasses = 0x7FFF;
			Model = 32091;
			ObjectClass = 4;
			SubClass = 1;
			Level = 65;
			ReqLevel = 60;
			Name = "Dryad's Wrist Bindings";
			Name2 = "Dryad's Wrist Bindings";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 87549;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			Flags = 32768;
			SetSpell( 15714 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 8;
			IqBonus = 7;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Dryad's Wrist Bindings)
*
***************************************************************/

namespace Server.Items
{
	public class DryadsWristBindings19596 : Item
	{
		public DryadsWristBindings19596() : base()
		{
			Id = 19596;
			Resistance[0] = 37;
			Bonding = 1;
			SellPrice = 10485;
			AvailableClasses = 0x7FFF;
			Model = 32091;
			ObjectClass = 4;
			SubClass = 1;
			Level = 55;
			ReqLevel = 50;
			Name = "Dryad's Wrist Bindings";
			Name2 = "Dryad's Wrist Bindings";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 52427;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			Flags = 32768;
			SetSpell( 14799 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 6;
			IqBonus = 6;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Dryad's Wrist Bindings)
*
***************************************************************/

namespace Server.Items
{
	public class DryadsWristBindings19597 : Item
	{
		public DryadsWristBindings19597() : base()
		{
			Id = 19597;
			Resistance[0] = 31;
			Bonding = 1;
			SellPrice = 5401;
			AvailableClasses = 0x7FFF;
			Model = 32091;
			ObjectClass = 4;
			SubClass = 1;
			Level = 45;
			ReqLevel = 40;
			Name = "Dryad's Wrist Bindings";
			Name2 = "Dryad's Wrist Bindings";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 27006;
			InventoryType = InventoryTypes.Wrist;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			Flags = 32768;
			SetSpell( 9345 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 6;
			IqBonus = 5;
			StaminaBonus = 6;
		}
	}
}


