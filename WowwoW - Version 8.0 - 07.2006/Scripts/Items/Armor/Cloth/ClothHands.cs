/**************************************************************
*
*		Made by fulgas (fulgas@gmail.com)
*
*  WowwoW Item Designer ( 2005/8/23 - 10:05:22 )
*
***************************************************************/

using System;
using System.Collections;

/***************************************************************/

/**************************************************************
*
*				(Thick Cloth Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class ThickClothGloves : Item
	{
		public ThickClothGloves() : base()
		{
			Id = 203;
			Resistance[0] = 21;
			SellPrice = 229;
			AvailableClasses = 0x7FFF;
			Model = 16779;
			ObjectClass = 4;
			SubClass = 1;
			Level = 22;
			ReqLevel = 17;
			Name = "Thick Cloth Gloves";
			Name2 = "Thick Cloth Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1147;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Tattered Cloth Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class TatteredClothGloves : Item
	{
		public TatteredClothGloves() : base()
		{
			Id = 711;
			Resistance[0] = 6;
			SellPrice = 5;
			AvailableClasses = 0x7FFF;
			Model = 16581;
			ObjectClass = 4;
			SubClass = 1;
			Level = 5;
			ReqLevel = 1;
			Name = "Tattered Cloth Gloves";
			Name2 = "Tattered Cloth Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 25;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 14;
		}
	}
}


/**************************************************************
*
*				(Rabbit Handler Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class RabbitHandlerGloves : Item
	{
		public RabbitHandlerGloves() : base()
		{
			Id = 719;
			Resistance[0] = 6;
			Bonding = 1;
			SellPrice = 4;
			AvailableClasses = 0x7FFF;
			Model = 16970;
			ObjectClass = 4;
			SubClass = 1;
			Level = 5;
			Name = "Rabbit Handler Gloves";
			Name2 = "Rabbit Handler Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 23;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 14;
		}
	}
}


/**************************************************************
*
*				(Knitted Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class KnittedGloves : Item
	{
		public KnittedGloves() : base()
		{
			Id = 793;
			Resistance[0] = 11;
			SellPrice = 27;
			AvailableClasses = 0x7FFF;
			Model = 14449;
			ObjectClass = 4;
			SubClass = 1;
			Level = 10;
			ReqLevel = 5;
			Name = "Knitted Gloves";
			Name2 = "Knitted Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 139;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 16;
		}
	}
}


/**************************************************************
*
*				(Heavy Weave Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyWeaveGloves : Item
	{
		public HeavyWeaveGloves() : base()
		{
			Id = 839;
			Resistance[0] = 18;
			SellPrice = 113;
			AvailableClasses = 0x7FFF;
			Model = 14467;
			ObjectClass = 4;
			SubClass = 1;
			Level = 17;
			ReqLevel = 12;
			Name = "Heavy Weave Gloves";
			Name2 = "Heavy Weave Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 566;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Gnoll Casting Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class GnollCastingGloves : Item
	{
		public GnollCastingGloves() : base()
		{
			Id = 892;
			Resistance[0] = 22;
			Bonding = 2;
			SellPrice = 369;
			AvailableClasses = 0x7FFF;
			Model = 16950;
			ObjectClass = 4;
			SubClass = 1;
			Level = 22;
			ReqLevel = 17;
			Name = "Gnoll Casting Gloves";
			Name2 = "Gnoll Casting Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1849;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 20;
			SetSpell( 9396 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Riding Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class RidingGloves : Item
	{
		public RidingGloves() : base()
		{
			Id = 1304;
			Resistance[0] = 21;
			Bonding = 1;
			SellPrice = 279;
			AvailableClasses = 0x7FFF;
			Model = 16818;
			ObjectClass = 4;
			SubClass = 1;
			Level = 20;
			Name = "Riding Gloves";
			Name2 = "Riding Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1398;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 20;
			AgilityBonus = 3;
			SpiritBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Frayed Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class FrayedGloves : Item
	{
		public FrayedGloves() : base()
		{
			Id = 1377;
			Resistance[0] = 4;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 16657;
			ObjectClass = 4;
			SubClass = 1;
			Level = 3;
			ReqLevel = 1;
			Name = "Frayed Gloves";
			Name2 = "Frayed Gloves";
			AvailableRaces = 0x1FF;
			BuyPrice = 6;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 12;
		}
	}
}


/**************************************************************
*
*				(Patchwork Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class PatchworkGloves : Item
	{
		public PatchworkGloves() : base()
		{
			Id = 1430;
			Resistance[0] = 8;
			SellPrice = 7;
			AvailableClasses = 0x7FFF;
			Model = 16797;
			ObjectClass = 4;
			SubClass = 1;
			Level = 7;
			ReqLevel = 2;
			Name = "Patchwork Gloves";
			Name2 = "Patchwork Gloves";
			AvailableRaces = 0x1FF;
			BuyPrice = 38;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 14;
		}
	}
}


/**************************************************************
*
*				(Salma's Oven Mitts)
*
***************************************************************/

namespace Server.Items
{
	public class SalmasOvenMitts : Item
	{
		public SalmasOvenMitts() : base()
		{
			Id = 1479;
			Resistance[0] = 13;
			Bonding = 1;
			SellPrice = 47;
			AvailableClasses = 0x7FFF;
			Model = 16710;
			ObjectClass = 4;
			SubClass = 1;
			Level = 12;
			Name = "Salma's Oven Mitts";
			Name2 = "Salma's Oven Mitts";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 238;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 16;
		}
	}
}


/**************************************************************
*
*				(Calico Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class CalicoGloves : Item
	{
		public CalicoGloves() : base()
		{
			Id = 1498;
			Resistance[0] = 16;
			SellPrice = 57;
			AvailableClasses = 0x7FFF;
			Model = 14348;
			ObjectClass = 4;
			SubClass = 1;
			Level = 15;
			ReqLevel = 10;
			Name = "Calico Gloves";
			Name2 = "Calico Gloves";
			AvailableRaces = 0x1FF;
			BuyPrice = 285;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 18;
		}
	}
}


/**************************************************************
*
*				(Engineering Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class EngineeringGloves : Item
	{
		public EngineeringGloves() : base()
		{
			Id = 1659;
			Resistance[0] = 33;
			Bonding = 2;
			SellPrice = 2136;
			AvailableClasses = 0x7FFF;
			Model = 1795;
			ObjectClass = 4;
			SubClass = 1;
			Level = 40;
			ReqLevel = 35;
			Name = "Engineering Gloves";
			Name2 = "Engineering Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 10682;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			StrBonus = 8;
			SpiritBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Canvas Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class CanvasGloves : Item
	{
		public CanvasGloves() : base()
		{
			Id = 1767;
			Resistance[0] = 18;
			SellPrice = 101;
			AvailableClasses = 0x7FFF;
			Model = 14065;
			ObjectClass = 4;
			SubClass = 1;
			Level = 19;
			ReqLevel = 14;
			Name = "Canvas Gloves";
			Name2 = "Canvas Gloves";
			AvailableRaces = 0x1FF;
			BuyPrice = 505;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Brocade Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class BrocadeGloves : Item
	{
		public BrocadeGloves() : base()
		{
			Id = 1775;
			Resistance[0] = 22;
			SellPrice = 212;
			AvailableClasses = 0x7FFF;
			Model = 14370;
			ObjectClass = 4;
			SubClass = 1;
			Level = 25;
			ReqLevel = 20;
			Name = "Brocade Gloves";
			Name2 = "Brocade Gloves";
			AvailableRaces = 0x1FF;
			BuyPrice = 1064;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Cross-stitched Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class CrossStitchedGloves : Item
	{
		public CrossStitchedGloves() : base()
		{
			Id = 1783;
			Resistance[0] = 22;
			SellPrice = 247;
			AvailableClasses = 0x7FFF;
			Model = 14373;
			ObjectClass = 4;
			SubClass = 1;
			Level = 26;
			ReqLevel = 21;
			Name = "Cross-stitched Gloves";
			Name2 = "Cross-stitched Gloves";
			AvailableRaces = 0x1FF;
			BuyPrice = 1238;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Thin Cloth Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class ThinClothGloves : Item
	{
		public ThinClothGloves() : base()
		{
			Id = 2119;
			Resistance[0] = 6;
			SellPrice = 4;
			AvailableClasses = 0x7FFF;
			Model = 16969;
			ObjectClass = 4;
			SubClass = 1;
			Level = 5;
			ReqLevel = 1;
			Name = "Thin Cloth Gloves";
			Name2 = "Thin Cloth Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 24;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 14;
		}
	}
}


/**************************************************************
*
*				(Padded Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class PaddedGloves : Item
	{
		public PaddedGloves() : base()
		{
			Id = 2158;
			Resistance[0] = 24;
			SellPrice = 413;
			AvailableClasses = 0x7FFF;
			Model = 14478;
			ObjectClass = 4;
			SubClass = 1;
			Level = 27;
			ReqLevel = 22;
			Name = "Padded Gloves";
			Name2 = "Padded Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2066;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Woven Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class WovenGloves : Item
	{
		public WovenGloves() : base()
		{
			Id = 2369;
			Resistance[0] = 11;
			SellPrice = 30;
			AvailableClasses = 0x7FFF;
			Model = 14457;
			ObjectClass = 4;
			SubClass = 1;
			Level = 10;
			ReqLevel = 5;
			Name = "Woven Gloves";
			Name2 = "Woven Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 150;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 16;
		}
	}
}


/**************************************************************
*
*				(Russet Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class RussetGloves : Item
	{
		public RussetGloves() : base()
		{
			Id = 2434;
			Resistance[0] = 29;
			SellPrice = 1033;
			AvailableClasses = 0x7FFF;
			Model = 14482;
			ObjectClass = 4;
			SubClass = 1;
			Level = 37;
			ReqLevel = 32;
			Name = "Russet Gloves";
			Name2 = "Russet Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 5165;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Embroidered Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class EmbroideredGloves : Item
	{
		public EmbroideredGloves() : base()
		{
			Id = 2440;
			Resistance[0] = 39;
			SellPrice = 2819;
			AvailableClasses = 0x7FFF;
			Model = 16771;
			ObjectClass = 4;
			SubClass = 1;
			Level = 50;
			ReqLevel = 45;
			Name = "Embroidered Gloves";
			Name2 = "Embroidered Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 14099;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Journeyman's Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class JourneymansGloves : Item
	{
		public JourneymansGloves() : base()
		{
			Id = 2960;
			Resistance[0] = 10;
			SellPrice = 21;
			AvailableClasses = 0x7FFF;
			Model = 14497;
			ObjectClass = 4;
			SubClass = 1;
			Level = 9;
			ReqLevel = 4;
			Name = "Journeyman's Gloves";
			Name2 = "Journeyman's Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 109;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 16;
		}
	}
}


/**************************************************************
*
*				(Spellbinder Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class SpellbinderGloves : Item
	{
		public SpellbinderGloves() : base()
		{
			Id = 2972;
			Resistance[0] = 16;
			SellPrice = 72;
			AvailableClasses = 0x7FFF;
			Model = 14528;
			ObjectClass = 4;
			SubClass = 1;
			Level = 14;
			ReqLevel = 9;
			Name = "Spellbinder Gloves";
			Name2 = "Spellbinder Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 364;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 18;
		}
	}
}


/**************************************************************
*
*				(Seer's Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class SeersGloves : Item
	{
		public SeersGloves() : base()
		{
			Id = 2984;
			Resistance[0] = 20;
			Bonding = 2;
			SellPrice = 215;
			AvailableClasses = 0x7FFF;
			Model = 16789;
			ObjectClass = 4;
			SubClass = 1;
			Level = 18;
			ReqLevel = 13;
			Name = "Seer's Gloves";
			Name2 = "Seer's Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1077;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 20;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Bright Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class BrightGloves : Item
	{
		public BrightGloves() : base()
		{
			Id = 3066;
			Resistance[0] = 24;
			Bonding = 2;
			SellPrice = 497;
			AvailableClasses = 0x7FFF;
			Model = 27550;
			ObjectClass = 4;
			SubClass = 1;
			Level = 24;
			ReqLevel = 19;
			Name = "Bright Gloves";
			Name2 = "Bright Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2487;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 20;
			IqBonus = 4;
			SpiritBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Smoldering Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class SmolderingGloves : Item
	{
		public SmolderingGloves() : base()
		{
			Id = 3074;
			Resistance[0] = 24;
			Bonding = 2;
			SellPrice = 476;
			AvailableClasses = 0x7FFF;
			Model = 12420;
			ObjectClass = 4;
			SubClass = 1;
			Level = 24;
			ReqLevel = 19;
			Name = "Smoldering Gloves";
			Name2 = "Smoldering Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2380;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 20;
			StaminaBonus = 3;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Flax Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class FlaxGloves : Item
	{
		public FlaxGloves() : base()
		{
			Id = 3275;
			Resistance[0] = 6;
			Bonding = 1;
			SellPrice = 5;
			AvailableClasses = 0x7FFF;
			Model = 16586;
			ObjectClass = 4;
			SubClass = 1;
			Level = 5;
			Name = "Flax Gloves";
			Name2 = "Flax Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 26;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 14;
		}
	}
}


/**************************************************************
*
*				(Ancestral Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class AncestralGloves : Item
	{
		public AncestralGloves() : base()
		{
			Id = 3290;
			Resistance[0] = 13;
			SellPrice = 48;
			AvailableClasses = 0x7FFF;
			Model = 14509;
			ObjectClass = 4;
			SubClass = 1;
			Level = 12;
			ReqLevel = 7;
			Name = "Ancestral Gloves";
			Name2 = "Ancestral Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 241;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 16;
		}
	}
}


/**************************************************************
*
*				(Barbaric Cloth Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class BarbaricClothGloves : Item
	{
		public BarbaricClothGloves() : base()
		{
			Id = 3308;
			Resistance[0] = 17;
			Bonding = 2;
			SellPrice = 144;
			AvailableClasses = 0x7FFF;
			Model = 16592;
			ObjectClass = 4;
			SubClass = 1;
			Level = 15;
			ReqLevel = 10;
			Name = "Barbaric Cloth Gloves";
			Name2 = "Barbaric Cloth Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 721;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 18;
			IqBonus = 2;
			StaminaBonus = 1;
			StrBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Beerstained Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class BeerstainedGloves : Item
	{
		public BeerstainedGloves() : base()
		{
			Id = 3565;
			Resistance[0] = 21;
			Bonding = 1;
			SellPrice = 280;
			AvailableClasses = 0x7FFF;
			Model = 14127;
			ObjectClass = 4;
			SubClass = 1;
			Level = 20;
			Name = "Beerstained Gloves";
			Name2 = "Beerstained Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1403;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 20;
			StrBonus = 3;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Insulated Sage Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class InsulatedSageGloves : Item
	{
		public InsulatedSageGloves() : base()
		{
			Id = 3759;
			Resistance[0] = 28;
			Bonding = 1;
			SellPrice = 1216;
			AvailableClasses = 0x7FFF;
			Model = 16944;
			ObjectClass = 4;
			SubClass = 1;
			Level = 33;
			Name = "Insulated Sage Gloves";
			Name2 = "Insulated Sage Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6080;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			StaminaBonus = 7;
			SpiritBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Interlaced Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class InterlacedGloves : Item
	{
		public InterlacedGloves() : base()
		{
			Id = 3796;
			Resistance[0] = 25;
			SellPrice = 493;
			AvailableClasses = 0x7FFF;
			Model = 16569;
			ObjectClass = 4;
			SubClass = 1;
			Level = 33;
			ReqLevel = 28;
			Name = "Interlaced Gloves";
			Name2 = "Interlaced Gloves";
			AvailableRaces = 0x1FF;
			BuyPrice = 2467;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Crochet Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class CrochetGloves : Item
	{
		public CrochetGloves() : base()
		{
			Id = 3940;
			Resistance[0] = 35;
			SellPrice = 1630;
			AvailableClasses = 0x7FFF;
			Model = 16720;
			ObjectClass = 4;
			SubClass = 1;
			Level = 48;
			ReqLevel = 43;
			Name = "Crochet Gloves";
			Name2 = "Crochet Gloves";
			AvailableRaces = 0x1FF;
			BuyPrice = 8154;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Twill Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class TwillGloves : Item
	{
		public TwillGloves() : base()
		{
			Id = 3948;
			Resistance[0] = 42;
			SellPrice = 3092;
			AvailableClasses = 0x7FFF;
			Model = 16702;
			ObjectClass = 4;
			SubClass = 1;
			Level = 58;
			ReqLevel = 53;
			Name = "Twill Gloves";
			Name2 = "Twill Gloves";
			AvailableRaces = 0x1FF;
			BuyPrice = 15463;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Nightsky Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class NightskyGloves : Item
	{
		public NightskyGloves() : base()
		{
			Id = 4040;
			Resistance[0] = 29;
			Bonding = 2;
			SellPrice = 1347;
			AvailableClasses = 0x7FFF;
			Model = 14623;
			ObjectClass = 4;
			SubClass = 1;
			Level = 34;
			ReqLevel = 29;
			Name = "Nightsky Gloves";
			Name2 = "Nightsky Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6738;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			StaminaBonus = 7;
			SpiritBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Aurora Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class AuroraGloves : Item
	{
		public AuroraGloves() : base()
		{
			Id = 4042;
			Resistance[0] = 32;
			Bonding = 2;
			SellPrice = 2107;
			AvailableClasses = 0x7FFF;
			Model = 14661;
			ObjectClass = 4;
			SubClass = 1;
			Level = 39;
			ReqLevel = 34;
			Name = "Aurora Gloves";
			Name2 = "Aurora Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 10536;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			AgilityBonus = 8;
			SpiritBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Gemmed Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class GemmedGloves : Item
	{
		public GemmedGloves() : base()
		{
			Id = 4121;
			Resistance[0] = 29;
			Bonding = 1;
			SellPrice = 1380;
			AvailableClasses = 0x7FFF;
			Model = 14323;
			ObjectClass = 4;
			SubClass = 1;
			Level = 35;
			Name = "Gemmed Gloves";
			Name2 = "Gemmed Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6902;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			IqBonus = 5;
			AgilityBonus = 5;
			SpiritBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Heavy Linen Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyLinenGloves : Item
	{
		public HeavyLinenGloves() : base()
		{
			Id = 4307;
			Resistance[0] = 11;
			SellPrice = 29;
			AvailableClasses = 0x7FFF;
			Model = 6295;
			ObjectClass = 4;
			SubClass = 1;
			Level = 10;
			ReqLevel = 5;
			Name = "Heavy Linen Gloves";
			Name2 = "Heavy Linen Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 149;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 16;
		}
	}
}


/**************************************************************
*
*				(Heavy Woolen Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyWoolenGloves : Item
	{
		public HeavyWoolenGloves() : base()
		{
			Id = 4310;
			Resistance[0] = 19;
			Bonding = 2;
			SellPrice = 180;
			AvailableClasses = 0x7FFF;
			Model = 12865;
			ObjectClass = 4;
			SubClass = 1;
			Level = 17;
			ReqLevel = 12;
			Name = "Heavy Woolen Gloves";
			Name2 = "Heavy Woolen Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 902;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 20;
			SpiritBonus = 2;
			IqBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Gloves of Meditation)
*
***************************************************************/

namespace Server.Items
{
	public class GlovesOfMeditation : Item
	{
		public GlovesOfMeditation() : base()
		{
			Id = 4318;
			Resistance[0] = 25;
			Bonding = 2;
			SellPrice = 610;
			AvailableClasses = 0x7FFF;
			Model = 6291;
			ObjectClass = 4;
			SubClass = 1;
			Level = 26;
			ReqLevel = 21;
			Name = "Gloves of Meditation";
			Name2 = "Gloves of Meditation";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3052;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			IqBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Azure Silk Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class AzureSilkGloves : Item
	{
		public AzureSilkGloves() : base()
		{
			Id = 4319;
			Resistance[0] = 26;
			Bonding = 2;
			SellPrice = 815;
			AvailableClasses = 0x7FFF;
			Model = 17130;
			ObjectClass = 4;
			SubClass = 1;
			Level = 29;
			ReqLevel = 24;
			Name = "Azure Silk Gloves";
			Name2 = "Azure Silk Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4076;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			SetSpell( 7703 , 1 , 0 , -1 , 0 , -1 );
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Phoenix Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class PhoenixGloves : Item
	{
		public PhoenixGloves() : base()
		{
			Id = 4331;
			Resistance[0] = 24;
			Bonding = 2;
			SellPrice = 526;
			AvailableClasses = 0x7FFF;
			Model = 13195;
			ObjectClass = 4;
			SubClass = 1;
			Level = 25;
			ReqLevel = 20;
			Name = "Phoenix Gloves";
			Name2 = "Phoenix Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2630;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			SetSpell( 7688 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Coppercloth Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class CopperclothGloves : Item
	{
		public CopperclothGloves() : base()
		{
			Id = 4767;
			Resistance[0] = 17;
			Bonding = 2;
			SellPrice = 139;
			AvailableClasses = 0x7FFF;
			Model = 3528;
			ObjectClass = 4;
			SubClass = 1;
			Level = 15;
			ReqLevel = 10;
			Name = "Coppercloth Gloves";
			Name2 = "Coppercloth Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 695;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 18;
			StrBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Adept's Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class AdeptsGloves : Item
	{
		public AdeptsGloves() : base()
		{
			Id = 4768;
			Resistance[0] = 17;
			Bonding = 2;
			SellPrice = 139;
			AvailableClasses = 0x7FFF;
			Model = 16946;
			ObjectClass = 4;
			SubClass = 1;
			Level = 15;
			ReqLevel = 10;
			Name = "Adept's Gloves";
			Name2 = "Adept's Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 698;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 18;
			SpiritBonus = 2;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Gold-flecked Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class GoldFleckedGloves : Item
	{
		public GoldFleckedGloves() : base()
		{
			Id = 5195;
			Resistance[0] = 22;
			Bonding = 1;
			SellPrice = 364;
			AvailableClasses = 0x7FFF;
			Model = 16966;
			ObjectClass = 4;
			SubClass = 1;
			Level = 22;
			ReqLevel = 17;
			Name = "Gold-flecked Gloves";
			Name2 = "Gold-flecked Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1823;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 20;
			StrBonus = 4;
			SpiritBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Wayfaring Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class WayfaringGloves : Item
	{
		public WayfaringGloves() : base()
		{
			Id = 5337;
			Resistance[0] = 18;
			Bonding = 1;
			SellPrice = 167;
			AvailableClasses = 0x7FFF;
			Model = 19899;
			ObjectClass = 4;
			SubClass = 1;
			Level = 16;
			Name = "Wayfaring Gloves";
			Name2 = "Wayfaring Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 836;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 18;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Gardening Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class GardeningGloves : Item
	{
		public GardeningGloves() : base()
		{
			Id = 5606;
			Resistance[0] = 10;
			Bonding = 1;
			SellPrice = 23;
			AvailableClasses = 0x7FFF;
			Model = 16817;
			ObjectClass = 4;
			SubClass = 1;
			Level = 9;
			Name = "Gardening Gloves";
			Name2 = "Gardening Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 115;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 16;
		}
	}
}


/**************************************************************
*
*				(Serpent Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class SerpentGloves : Item
	{
		public SerpentGloves() : base()
		{
			Id = 5970;
			Resistance[0] = 23;
			Bonding = 1;
			SellPrice = 418;
			AvailableClasses = 0x7FFF;
			Model = 19128;
			ObjectClass = 4;
			SubClass = 1;
			Level = 23;
			ReqLevel = 18;
			Name = "Serpent Gloves";
			Name2 = "Serpent Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2092;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 20;
			AgilityBonus = 4;
			SpiritBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Fingerless Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class FingerlessGloves : Item
	{
		public FingerlessGloves() : base()
		{
			Id = 6202;
			Resistance[0] = 12;
			SellPrice = 35;
			AvailableClasses = 0x7FFF;
			Model = 10535;
			ObjectClass = 4;
			SubClass = 1;
			Level = 11;
			ReqLevel = 6;
			Name = "Fingerless Gloves";
			Name2 = "Fingerless Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 179;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 16;
		}
	}
}


/**************************************************************
*
*				(Silver-thread Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class SilverThreadGloves : Item
	{
		public SilverThreadGloves() : base()
		{
			Id = 6393;
			Resistance[0] = 26;
			Bonding = 2;
			SellPrice = 760;
			AvailableClasses = 0x7FFF;
			Model = 16642;
			ObjectClass = 4;
			SubClass = 1;
			Level = 28;
			ReqLevel = 23;
			Name = "Silver-thread Gloves";
			Name2 = "Silver-thread Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3803;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			IqBonus = 5;
			SpiritBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Mistscape Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class MistscapeGloves : Item
	{
		public MistscapeGloves() : base()
		{
			Id = 6428;
			Resistance[0] = 35;
			Bonding = 2;
			SellPrice = 2795;
			AvailableClasses = 0x7FFF;
			Model = 14684;
			ObjectClass = 4;
			SubClass = 1;
			Level = 43;
			ReqLevel = 38;
			Name = "Mistscape Gloves";
			Name2 = "Mistscape Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 13975;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			StaminaBonus = 4;
			AgilityBonus = 4;
			SpiritBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Disciple's Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class DisciplesGloves : Item
	{
		public DisciplesGloves() : base()
		{
			Id = 6515;
			Resistance[0] = 12;
			SellPrice = 37;
			AvailableClasses = 0x7FFF;
			Model = 16562;
			ObjectClass = 4;
			SubClass = 1;
			Level = 11;
			ReqLevel = 6;
			Name = "Disciple's Gloves";
			Name2 = "Disciple's Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 185;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 16;
		}
	}
}


/**************************************************************
*
*				(Willow Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class WillowGloves : Item
	{
		public WillowGloves() : base()
		{
			Id = 6541;
			Resistance[0] = 18;
			Bonding = 2;
			SellPrice = 163;
			AvailableClasses = 0x7FFF;
			Model = 14737;
			ObjectClass = 4;
			SubClass = 1;
			Level = 16;
			ReqLevel = 11;
			Name = "Willow Gloves";
			Name2 = "Willow Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 708;
			BuyPrice = 817;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 18;
		}
	}
}


/**************************************************************
*
*				(Shimmering Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class ShimmeringGloves : Item
	{
		public ShimmeringGloves() : base()
		{
			Id = 6565;
			Resistance[0] = 22;
			Bonding = 2;
			SellPrice = 393;
			AvailableClasses = 0x7FFF;
			Model = 16793;
			ObjectClass = 4;
			SubClass = 1;
			Level = 22;
			ReqLevel = 17;
			Name = "Shimmering Gloves";
			Name2 = "Shimmering Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 710;
			BuyPrice = 1969;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Sage's Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class SagesGloves : Item
	{
		public SagesGloves() : base()
		{
			Id = 6615;
			Resistance[0] = 26;
			Bonding = 2;
			SellPrice = 824;
			AvailableClasses = 0x7FFF;
			Model = 16864;
			ObjectClass = 4;
			SubClass = 1;
			Level = 29;
			ReqLevel = 24;
			Name = "Sage's Gloves";
			Name2 = "Sage's Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 712;
			BuyPrice = 4123;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Raven's Claws)
*
***************************************************************/

namespace Server.Items
{
	public class RavensClaws : Item
	{
		public RavensClaws() : base()
		{
			Id = 6628;
			Resistance[0] = 22;
			Bonding = 2;
			SellPrice = 370;
			AvailableClasses = 0x7FFF;
			Model = 16952;
			ObjectClass = 4;
			SubClass = 1;
			Level = 22;
			ReqLevel = 17;
			Name = "Raven's Claws";
			Name2 = "Raven's Claws";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1851;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 20;
			StaminaBonus = 4;
			SpiritBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Gloves of Kapelan)
*
***************************************************************/

namespace Server.Items
{
	public class GlovesOfKapelan : Item
	{
		public GlovesOfKapelan() : base()
		{
			Id = 6744;
			Resistance[0] = 28;
			Bonding = 1;
			SellPrice = 1190;
			AvailableClasses = 0x7FFF;
			Model = 16956;
			ObjectClass = 4;
			SubClass = 1;
			Level = 33;
			Name = "Gloves of Kapelan";
			Name2 = "Gloves of Kapelan";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5950;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			StrBonus = 7;
			SpiritBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Hands of Darkness)
*
***************************************************************/

namespace Server.Items
{
	public class HandsOfDarkness : Item
	{
		public HandsOfDarkness() : base()
		{
			Id = 7047;
			Resistance[0] = 26;
			Bonding = 2;
			SellPrice = 824;
			AvailableClasses = 0x7FFF;
			Model = 17146;
			ObjectClass = 4;
			SubClass = 1;
			Level = 29;
			ReqLevel = 24;
			Name = "Hands of Darkness";
			Name2 = "Hands of Darkness";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4124;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			SetSpell( 7710 , 1 , 0 , -1 , 0 , -1 );
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Truefaith Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class TruefaithGloves : Item
	{
		public TruefaithGloves() : base()
		{
			Id = 7049;
			Resistance[0] = 27;
			Bonding = 2;
			SellPrice = 914;
			AvailableClasses = 0x7FFF;
			Model = 17143;
			ObjectClass = 4;
			SubClass = 1;
			Level = 30;
			ReqLevel = 25;
			Name = "Truefaith Gloves";
			Name2 = "Truefaith Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4570;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			SetSpell( 7681 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Crimson Silk Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class CrimsonSilkGloves : Item
	{
		public CrimsonSilkGloves() : base()
		{
			Id = 7064;
			Resistance[0] = 35;
			Bonding = 2;
			SellPrice = 2569;
			AvailableClasses = 0x7FFF;
			Model = 13681;
			ObjectClass = 4;
			SubClass = 1;
			Level = 42;
			ReqLevel = 37;
			Name = "Crimson Silk Gloves";
			Name2 = "Crimson Silk Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 12849;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			SetSpell( 9401 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Zodiac Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class ZodiacGloves : Item
	{
		public ZodiacGloves() : base()
		{
			Id = 7106;
			Resistance[0] = 28;
			Bonding = 1;
			SellPrice = 1234;
			AvailableClasses = 0x7FFF;
			Model = 16959;
			ObjectClass = 4;
			SubClass = 1;
			Level = 33;
			Name = "Zodiac Gloves";
			Name2 = "Zodiac Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6173;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			SpiritBonus = 4;
			IqBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Elder's Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class EldersGloves : Item
	{
		public EldersGloves() : base()
		{
			Id = 7366;
			Resistance[0] = 28;
			Bonding = 2;
			SellPrice = 1098;
			AvailableClasses = 0x7FFF;
			Model = 16601;
			ObjectClass = 4;
			SubClass = 1;
			Level = 32;
			ReqLevel = 27;
			Name = "Elder's Gloves";
			Name2 = "Elder's Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 713;
			BuyPrice = 5490;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Twilight Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class TwilightGloves : Item
	{
		public TwilightGloves() : base()
		{
			Id = 7433;
			Resistance[0] = 31;
			Bonding = 2;
			SellPrice = 1684;
			AvailableClasses = 0x7FFF;
			Model = 16651;
			ObjectClass = 4;
			SubClass = 1;
			Level = 37;
			ReqLevel = 32;
			Name = "Twilight Gloves";
			Name2 = "Twilight Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 715;
			BuyPrice = 8421;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Regal Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class RegalGloves : Item
	{
		public RegalGloves() : base()
		{
			Id = 7471;
			Resistance[0] = 35;
			Bonding = 2;
			SellPrice = 2455;
			AvailableClasses = 0x7FFF;
			Model = 15008;
			ObjectClass = 4;
			SubClass = 1;
			Level = 42;
			ReqLevel = 37;
			Name = "Regal Gloves";
			Name2 = "Regal Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 716;
			BuyPrice = 12275;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Gossamer Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class GossamerGloves : Item
	{
		public GossamerGloves() : base()
		{
			Id = 7521;
			Resistance[0] = 38;
			Bonding = 2;
			SellPrice = 3560;
			AvailableClasses = 0x7FFF;
			Model = 15405;
			ObjectClass = 4;
			SubClass = 1;
			Level = 46;
			ReqLevel = 41;
			Name = "Gossamer Gloves";
			Name2 = "Gossamer Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 718;
			BuyPrice = 17803;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Evergreen Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class EvergreenGloves : Item
	{
		public EvergreenGloves() : base()
		{
			Id = 7738;
			Resistance[0] = 20;
			Bonding = 1;
			SellPrice = 211;
			AvailableClasses = 0x7FFF;
			Model = 16815;
			ObjectClass = 4;
			SubClass = 1;
			Level = 18;
			Name = "Evergreen Gloves";
			Name2 = "Evergreen Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1058;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 20;
			SpiritBonus = 3;
			IqBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Hibernal Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class HibernalGloves : Item
	{
		public HibernalGloves() : base()
		{
			Id = 8110;
			Resistance[0] = 38;
			Bonding = 2;
			SellPrice = 3622;
			AvailableClasses = 0x7FFF;
			Model = 16633;
			ObjectClass = 4;
			SubClass = 1;
			Level = 47;
			ReqLevel = 42;
			Name = "Hibernal Gloves";
			Name2 = "Hibernal Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 18110;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			AgilityBonus = 10;
			SpiritBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Imperial Red Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class ImperialRedGloves : Item
	{
		public ImperialRedGloves() : base()
		{
			Id = 8249;
			Resistance[0] = 42;
			Bonding = 2;
			SellPrice = 5336;
			AvailableClasses = 0x7FFF;
			Model = 17216;
			ObjectClass = 4;
			SubClass = 1;
			Level = 52;
			ReqLevel = 47;
			Name = "Imperial Red Gloves";
			Name2 = "Imperial Red Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 26682;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			StaminaBonus = 11;
			SpiritBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Arcane Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class ArcaneGloves : Item
	{
		public ArcaneGloves() : base()
		{
			Id = 8287;
			Resistance[0] = 46;
			Bonding = 2;
			SellPrice = 7087;
			AvailableClasses = 0x7FFF;
			Model = 17255;
			ObjectClass = 4;
			SubClass = 1;
			Level = 57;
			ReqLevel = 52;
			Name = "Arcane Gloves";
			Name2 = "Arcane Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 35437;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			StaminaBonus = 13;
			SpiritBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Revelosh's Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class ReveloshsGloves : Item
	{
		public ReveloshsGloves() : base()
		{
			Id = 9390;
			Resistance[0] = 33;
			Bonding = 1;
			SellPrice = 2146;
			AvailableClasses = 0x7FFF;
			Model = 19056;
			ObjectClass = 4;
			SubClass = 1;
			Level = 40;
			ReqLevel = 35;
			Name = "Revelosh's Gloves";
			Name2 = "Revelosh's Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 716;
			BuyPrice = 10734;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Gloves of Old)
*
***************************************************************/

namespace Server.Items
{
	public class GlovesOfOld : Item
	{
		public GlovesOfOld() : base()
		{
			Id = 9395;
			Resistance[0] = 32;
			Bonding = 2;
			SellPrice = 1565;
			AvailableClasses = 0x7FFF;
			Model = 18271;
			ObjectClass = 4;
			SubClass = 1;
			Level = 34;
			ReqLevel = 29;
			Name = "Gloves of Old";
			Name2 = "Gloves of Old";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 7828;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 30;
			SpiritBonus = 5;
			IqBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Hotshot Pilot's Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class HotshotPilotsGloves : Item
	{
		public HotshotPilotsGloves() : base()
		{
			Id = 9491;
			Resistance[0] = 31;
			Bonding = 2;
			SellPrice = 1308;
			AvailableClasses = 0x7FFF;
			Model = 14765;
			ObjectClass = 4;
			SubClass = 1;
			Level = 32;
			ReqLevel = 27;
			Name = "Hotshot Pilot's Gloves";
			Name2 = "Hotshot Pilot's Gloves";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 6542;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 30;
			SpiritBonus = 8;
			IqBonus = 5;
			StaminaBonus = 5;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Shilly Mitts)
*
***************************************************************/

namespace Server.Items
{
	public class ShillyMitts : Item
	{
		public ShillyMitts() : base()
		{
			Id = 9609;
			Resistance[0] = 27;
			Bonding = 1;
			SellPrice = 1009;
			AvailableClasses = 0x7FFF;
			Model = 18991;
			ObjectClass = 4;
			SubClass = 1;
			Level = 31;
			Name = "Shilly Mitts";
			Name2 = "Shilly Mitts";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5046;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			SpiritBonus = 6;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Skilled Handling Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class SkilledHandlingGloves : Item
	{
		public SkilledHandlingGloves() : base()
		{
			Id = 9634;
			Resistance[0] = 38;
			Bonding = 1;
			SellPrice = 3381;
			AvailableClasses = 0x7FFF;
			Model = 18998;
			ObjectClass = 4;
			SubClass = 1;
			Level = 46;
			Name = "Skilled Handling Gloves";
			Name2 = "Skilled Handling Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 16905;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			StaminaBonus = 6;
			AgilityBonus = 6;
			SpiritBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Wingcrest Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class WingcrestGloves : Item
	{
		public WingcrestGloves() : base()
		{
			Id = 9665;
			Resistance[0] = 41;
			Bonding = 1;
			SellPrice = 4826;
			AvailableClasses = 0x7FFF;
			Model = 18586;
			ObjectClass = 4;
			SubClass = 1;
			Level = 50;
			Name = "Wingcrest Gloves";
			Name2 = "Wingcrest Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 24134;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			StaminaBonus = 11;
			SpiritBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Simple Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class SimpleGloves : Item
	{
		public SimpleGloves() : base()
		{
			Id = 9746;
			Resistance[0] = 15;
			SellPrice = 56;
			AvailableClasses = 0x7FFF;
			Model = 14706;
			ObjectClass = 4;
			SubClass = 1;
			Level = 13;
			ReqLevel = 8;
			Name = "Simple Gloves";
			Name2 = "Simple Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 282;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 18;
		}
	}
}


/**************************************************************
*
*				(Greenweave Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class GreenweaveGloves : Item
	{
		public GreenweaveGloves() : base()
		{
			Id = 9771;
			Resistance[0] = 24;
			Bonding = 2;
			SellPrice = 532;
			AvailableClasses = 0x7FFF;
			Model = 25941;
			ObjectClass = 4;
			SubClass = 1;
			Level = 25;
			ReqLevel = 20;
			Name = "Greenweave Gloves";
			Name2 = "Greenweave Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 711;
			BuyPrice = 2662;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Ivycloth Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class IvyclothGloves : Item
	{
		public IvyclothGloves() : base()
		{
			Id = 9795;
			Resistance[0] = 25;
			Bonding = 2;
			SellPrice = 626;
			AvailableClasses = 0x7FFF;
			Model = 27753;
			ObjectClass = 4;
			SubClass = 1;
			Level = 26;
			ReqLevel = 21;
			Name = "Ivycloth Gloves";
			Name2 = "Ivycloth Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 711;
			BuyPrice = 3134;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Durable Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class DurableGloves : Item
	{
		public DurableGloves() : base()
		{
			Id = 9823;
			Resistance[0] = 27;
			Bonding = 2;
			SellPrice = 965;
			AvailableClasses = 0x7FFF;
			Model = 10508;
			ObjectClass = 4;
			SubClass = 1;
			Level = 31;
			ReqLevel = 26;
			Name = "Durable Gloves";
			Name2 = "Durable Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 713;
			BuyPrice = 4828;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Conjurer's Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class ConjurersGloves : Item
	{
		public ConjurersGloves() : base()
		{
			Id = 9848;
			Resistance[0] = 30;
			Bonding = 2;
			SellPrice = 1584;
			AvailableClasses = 0x7FFF;
			Model = 28422;
			ObjectClass = 4;
			SubClass = 1;
			Level = 36;
			ReqLevel = 31;
			Name = "Conjurer's Gloves";
			Name2 = "Conjurer's Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 714;
			BuyPrice = 7922;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Sorcerer Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class SorcererGloves : Item
	{
		public SorcererGloves() : base()
		{
			Id = 9880;
			Resistance[0] = 33;
			Bonding = 2;
			SellPrice = 2130;
			AvailableClasses = 0x7FFF;
			Model = 28062;
			ObjectClass = 4;
			SubClass = 1;
			Level = 40;
			ReqLevel = 35;
			Name = "Sorcerer Gloves";
			Name2 = "Sorcerer Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 716;
			BuyPrice = 10650;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Royal Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class RoyalGloves : Item
	{
		public RoyalGloves() : base()
		{
			Id = 9910;
			Resistance[0] = 36;
			Bonding = 2;
			SellPrice = 3087;
			AvailableClasses = 0x7FFF;
			Model = 28413;
			ObjectClass = 4;
			SubClass = 1;
			Level = 44;
			ReqLevel = 39;
			Name = "Royal Gloves";
			Name2 = "Royal Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 717;
			BuyPrice = 15437;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Abjurer's Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class AbjurersGloves : Item
	{
		public AbjurersGloves() : base()
		{
			Id = 9939;
			Resistance[0] = 40;
			Bonding = 2;
			SellPrice = 4317;
			AvailableClasses = 0x7FFF;
			Model = 17130;
			ObjectClass = 4;
			SubClass = 1;
			Level = 49;
			ReqLevel = 44;
			Name = "Abjurer's Gloves";
			Name2 = "Abjurer's Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 719;
			BuyPrice = 21586;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Black Mageweave Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class BlackMageweaveGloves : Item
	{
		public BlackMageweaveGloves() : base()
		{
			Id = 10003;
			Resistance[0] = 35;
			Bonding = 2;
			SellPrice = 2859;
			AvailableClasses = 0x7FFF;
			Model = 18835;
			ObjectClass = 4;
			SubClass = 1;
			Level = 43;
			ReqLevel = 38;
			Name = "Black Mageweave Gloves";
			Name2 = "Black Mageweave Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 14296;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			SetSpell( 9344 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Red Mageweave Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class RedMageweaveGloves : Item
	{
		public RedMageweaveGloves() : base()
		{
			Id = 10018;
			Resistance[0] = 37;
			Bonding = 2;
			SellPrice = 3275;
			AvailableClasses = 0x7FFF;
			Model = 19111;
			ObjectClass = 4;
			SubClass = 1;
			Level = 45;
			ReqLevel = 40;
			Name = "Red Mageweave Gloves";
			Name2 = "Red Mageweave Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 16376;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			SetSpell( 9416 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Dreamweave Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class DreamweaveGloves : Item
	{
		public DreamweaveGloves() : base()
		{
			Id = 10019;
			Resistance[0] = 41;
			Bonding = 2;
			SellPrice = 3944;
			AvailableClasses = 0x7FFF;
			Model = 18999;
			ObjectClass = 4;
			SubClass = 1;
			Level = 45;
			ReqLevel = 40;
			Name = "Dreamweave Gloves";
			Name2 = "Dreamweave Gloves";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 19721;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 30;
			SetSpell( 9346 , 1 , 0 , -1 , 0 , -1 );
			IqBonus = 7;
			SpiritBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Shadoweave Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class ShadoweaveGloves : Item
	{
		public ShadoweaveGloves() : base()
		{
			Id = 10023;
			Resistance[0] = 37;
			Bonding = 2;
			SellPrice = 3334;
			AvailableClasses = 0x7FFF;
			Model = 19055;
			ObjectClass = 4;
			SubClass = 1;
			Level = 45;
			ReqLevel = 40;
			Name = "Shadoweave Gloves";
			Name2 = "Shadoweave Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 16672;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			SetSpell( 9325 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Duskwoven Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class DuskwovenGloves : Item
	{
		public DuskwovenGloves() : base()
		{
			Id = 10062;
			Resistance[0] = 41;
			Bonding = 2;
			SellPrice = 4758;
			AvailableClasses = 0x7FFF;
			Model = 29002;
			ObjectClass = 4;
			SubClass = 1;
			Level = 51;
			ReqLevel = 46;
			Name = "Duskwoven Gloves";
			Name2 = "Duskwoven Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 719;
			BuyPrice = 23791;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Councillor's Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class CouncillorsGloves : Item
	{
		public CouncillorsGloves() : base()
		{
			Id = 10099;
			Resistance[0] = 45;
			Bonding = 2;
			SellPrice = 6567;
			AvailableClasses = 0x7FFF;
			Model = 27602;
			ObjectClass = 4;
			SubClass = 1;
			Level = 55;
			ReqLevel = 50;
			Name = "Councillor's Gloves";
			Name2 = "Councillor's Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 721;
			BuyPrice = 32839;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(High Councillor's Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class HighCouncillorsGloves : Item
	{
		public HighCouncillorsGloves() : base()
		{
			Id = 10140;
			Resistance[0] = 49;
			Bonding = 2;
			SellPrice = 9085;
			AvailableClasses = 0x7FFF;
			Model = 27639;
			ObjectClass = 4;
			SubClass = 1;
			Level = 61;
			ReqLevel = 56;
			Name = "High Councillor's Gloves";
			Name2 = "High Councillor's Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 723;
			BuyPrice = 45425;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Mystical Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class MysticalGloves : Item
	{
		public MysticalGloves() : base()
		{
			Id = 10176;
			Resistance[0] = 44;
			Bonding = 2;
			SellPrice = 5689;
			AvailableClasses = 0x7FFF;
			Model = 28083;
			ObjectClass = 4;
			SubClass = 1;
			Level = 54;
			ReqLevel = 49;
			Name = "Mystical Gloves";
			Name2 = "Mystical Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 720;
			BuyPrice = 28446;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Elegant Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class ElegantGloves : Item
	{
		public ElegantGloves() : base()
		{
			Id = 10214;
			Resistance[0] = 48;
			Bonding = 2;
			SellPrice = 8271;
			AvailableClasses = 0x7FFF;
			Model = 27868;
			ObjectClass = 4;
			SubClass = 1;
			Level = 59;
			ReqLevel = 54;
			Name = "Elegant Gloves";
			Name2 = "Elegant Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 722;
			BuyPrice = 41356;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Master's Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class MastersGloves : Item
	{
		public MastersGloves() : base()
		{
			Id = 10251;
			Resistance[0] = 51;
			Bonding = 2;
			SellPrice = 9946;
			AvailableClasses = 0x7FFF;
			Model = 16642;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Master's Gloves";
			Name2 = "Master's Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 723;
			BuyPrice = 49731;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Wooly Mittens)
*
***************************************************************/

namespace Server.Items
{
	public class WoolyMittens : Item
	{
		public WoolyMittens() : base()
		{
			Id = 10550;
			Resistance[0] = 13;
			Bonding = 1;
			SellPrice = 48;
			AvailableClasses = 0x7FFF;
			Model = 19994;
			ObjectClass = 4;
			SubClass = 1;
			Level = 12;
			Name = "Wooly Mittens";
			Name2 = "Wooly Mittens";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 243;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 16;
		}
	}
}


/**************************************************************
*
*				(Brewer's Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class BrewersGloves : Item
	{
		public BrewersGloves() : base()
		{
			Id = 10637;
			Resistance[0] = 17;
			Bonding = 1;
			SellPrice = 139;
			AvailableClasses = 0x7FFF;
			Model = 14152;
			ObjectClass = 4;
			SubClass = 1;
			Level = 15;
			Name = "Brewer's Gloves";
			Name2 = "Brewer's Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 698;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 18;
			SpiritBonus = 2;
			StrBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Jutebraid Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class JutebraidGloves : Item
	{
		public JutebraidGloves() : base()
		{
			Id = 10654;
			Resistance[0] = 27;
			Bonding = 1;
			SellPrice = 965;
			AvailableClasses = 0x7FFF;
			Model = 19949;
			ObjectClass = 4;
			SubClass = 1;
			Level = 31;
			Name = "Jutebraid Gloves";
			Name2 = "Jutebraid Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4827;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			StrBonus = 6;
			SpiritBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Atal'ai Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class AtalaiGloves : Item
	{
		public AtalaiGloves() : base()
		{
			Id = 10787;
			Resistance[0] = 47;
			Bonding = 1;
			SellPrice = 6382;
			AvailableClasses = 0x7FFF;
			Model = 19796;
			ObjectClass = 4;
			SubClass = 1;
			Level = 52;
			ReqLevel = 47;
			Name = "Atal'ai Gloves";
			Name2 = "Atal'ai Gloves";
			Quality = 3;
			AvailableRaces = 0x1FF;
			Extra = 722;
			BuyPrice = 31914;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 30;
			SetSpell( 9415 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Gloves of the Atal'ai Prophet)
*
***************************************************************/

namespace Server.Items
{
	public class GlovesOfTheAtalaiProphet : Item
	{
		public GlovesOfTheAtalaiProphet() : base()
		{
			Id = 10808;
			Resistance[0] = 49;
			Bonding = 1;
			SellPrice = 7629;
			AvailableClasses = 0x7FFF;
			Model = 19813;
			ObjectClass = 4;
			SubClass = 1;
			Level = 55;
			ReqLevel = 50;
			Name = "Gloves of the Atal'ai Prophet";
			Name2 = "Gloves of the Atal'ai Prophet";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 38146;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 30;
			IqBonus = 20;
			StrBonus = 5;
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Apothecary Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class ApothecaryGloves : Item
	{
		public ApothecaryGloves() : base()
		{
			Id = 10919;
			Resistance[0] = 20;
			Bonding = 1;
			SellPrice = 214;
			AvailableClasses = 0x7FFF;
			Model = 20476;
			ObjectClass = 4;
			SubClass = 1;
			Level = 18;
			Name = "Apothecary Gloves";
			Name2 = "Apothecary Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1074;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 20;
			SpiritBonus = 3;
			IqBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Viny Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class VinyGloves : Item
	{
		public VinyGloves() : base()
		{
			Id = 11190;
			Resistance[0] = 6;
			Bonding = 1;
			SellPrice = 5;
			AvailableClasses = 0x7FFF;
			Model = 28188;
			ObjectClass = 4;
			SubClass = 1;
			Level = 5;
			Name = "Viny Gloves";
			Name2 = "Viny Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 26;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 14;
		}
	}
}


/**************************************************************
*
*				(Outfitter Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class OutfitterGloves : Item
	{
		public OutfitterGloves() : base()
		{
			Id = 11192;
			Resistance[0] = 6;
			Bonding = 1;
			SellPrice = 4;
			AvailableClasses = 0x7FFF;
			Model = 4685;
			ObjectClass = 4;
			SubClass = 1;
			Level = 5;
			Name = "Outfitter Gloves";
			Name2 = "Outfitter Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 23;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 14;
		}
	}
}


/**************************************************************
*
*				(Silkweb Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class SilkwebGloves : Item
	{
		public SilkwebGloves() : base()
		{
			Id = 11634;
			Resistance[0] = 44;
			Bonding = 1;
			SellPrice = 5886;
			AvailableClasses = 0x7FFF;
			Model = 28741;
			ObjectClass = 4;
			SubClass = 1;
			Level = 54;
			ReqLevel = 49;
			Name = "Silkweb Gloves";
			Name2 = "Silkweb Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 29432;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			StaminaBonus = 12;
			SpiritBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Quintis' Research Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class QuintisResearchGloves : Item
	{
		public QuintisResearchGloves() : base()
		{
			Id = 11888;
			Resistance[0] = 41;
			Bonding = 1;
			SellPrice = 4879;
			AvailableClasses = 0x7FFF;
			Model = 28342;
			ObjectClass = 4;
			SubClass = 1;
			Level = 50;
			Name = "Quintis' Research Gloves";
			Name2 = "Quintis' Research Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 24398;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			SpiritBonus = 11;
			IqBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Netted Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class NettedGloves : Item
	{
		public NettedGloves() : base()
		{
			Id = 12299;
			Resistance[0] = 9;
			Bonding = 1;
			SellPrice = 16;
			AvailableClasses = 0x7FFF;
			Model = 28221;
			ObjectClass = 4;
			SubClass = 1;
			Level = 8;
			Name = "Netted Gloves";
			Name2 = "Netted Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 82;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 14;
		}
	}
}


/**************************************************************
*
*				(Hands of the Exalted Herald)
*
***************************************************************/

namespace Server.Items
{
	public class HandsOfTheExaltedHerald : Item
	{
		public HandsOfTheExaltedHerald() : base()
		{
			Id = 12554;
			Resistance[0] = 52;
			Bonding = 1;
			SellPrice = 9474;
			AvailableClasses = 0x7FFF;
			Model = 28771;
			ObjectClass = 4;
			SubClass = 1;
			Level = 59;
			ReqLevel = 54;
			Name = "Hands of the Exalted Herald";
			Name2 = "Hands of the Exalted Herald";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 47373;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 30;
			SetSpell( 9318 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 13;
			IqBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Magefist Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class MagefistGloves : Item
	{
		public MagefistGloves() : base()
		{
			Id = 12977;
			Resistance[0] = 23;
			Bonding = 2;
			SellPrice = 355;
			AvailableClasses = 0x7FFF;
			Model = 16642;
			ObjectClass = 4;
			SubClass = 1;
			Level = 20;
			ReqLevel = 15;
			Name = "Magefist Gloves";
			Name2 = "Magefist Gloves";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 1776;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 20;
			StaminaBonus = 3;
			IqBonus = 4;
			SpiritBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Demonskin Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class DemonskinGloves : Item
	{
		public DemonskinGloves() : base()
		{
			Id = 13181;
			Resistance[0] = 51;
			Bonding = 1;
			SellPrice = 8797;
			AvailableClasses = 0x7FFF;
			Model = 23732;
			ObjectClass = 4;
			SubClass = 1;
			Level = 57;
			ReqLevel = 52;
			Name = "Demonskin Gloves";
			Name2 = "Demonskin Gloves";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 43988;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 30;
			IqBonus = 17;
			SpiritBonus = 9;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Hands of Power)
*
***************************************************************/

namespace Server.Items
{
	public class HandsOfPower : Item
	{
		public HandsOfPower() : base()
		{
			Id = 13253;
			Resistance[0] = 53;
			Bonding = 1;
			SellPrice = 9983;
			AvailableClasses = 0x7FFF;
			Model = 23846;
			ObjectClass = 4;
			SubClass = 1;
			Level = 60;
			ReqLevel = 55;
			Name = "Hands of Power";
			Name2 = "Hands of Power";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 49916;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 30;
			SetSpell( 18049 , 1 , 0 , -1 , 0 , -1 );
			IqBonus = 6;
			SpiritBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Darkbind Fingers)
*
***************************************************************/

namespace Server.Items
{
	public class DarkbindFingers : Item
	{
		public DarkbindFingers() : base()
		{
			Id = 13525;
			Resistance[0] = 50;
			Bonding = 1;
			SellPrice = 8698;
			AvailableClasses = 0x7FFF;
			Model = 24177;
			ObjectClass = 4;
			SubClass = 1;
			Level = 62;
			ReqLevel = 57;
			Name = "Darkbind Fingers";
			Name2 = "Darkbind Fingers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 43492;
			Resistance[5] = 20;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Runecloth Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class RuneclothGloves : Item
	{
		public RuneclothGloves() : base()
		{
			Id = 13863;
			Resistance[0] = 45;
			Bonding = 2;
			SellPrice = 6617;
			AvailableClasses = 0x7FFF;
			Model = 25231;
			ObjectClass = 4;
			SubClass = 1;
			Level = 55;
			ReqLevel = 50;
			Name = "Runecloth Gloves";
			Name2 = "Runecloth Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 33085;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			SetSpell( 9417 , 1 , 0 , -1 , 0 , -1 );
			IqBonus = 9;
			SpiritBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Frostweave Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class FrostweaveGloves : Item
	{
		public FrostweaveGloves() : base()
		{
			Id = 13870;
			Resistance[0] = 43;
			Bonding = 2;
			SellPrice = 5471;
			AvailableClasses = 0x7FFF;
			Model = 24616;
			ObjectClass = 4;
			SubClass = 1;
			Level = 53;
			ReqLevel = 47;
			Name = "Frostweave Gloves";
			Name2 = "Frostweave Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 27358;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			SetSpell( 9308 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Cindercloth Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class CinderclothGloves : Item
	{
		public CinderclothGloves() : base()
		{
			Id = 14043;
			Resistance[0] = 44;
			Bonding = 2;
			SellPrice = 5955;
			AvailableClasses = 0x7FFF;
			Model = 24896;
			ObjectClass = 4;
			SubClass = 1;
			Level = 54;
			ReqLevel = 49;
			Name = "Cindercloth Gloves";
			Name2 = "Cindercloth Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 29778;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			SetSpell( 9295 , 1 , 0 , -1 , 0 , -1 );
			IqBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Beaded Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class BeadedGloves : Item
	{
		public BeadedGloves() : base()
		{
			Id = 14089;
			Resistance[0] = 11;
			SellPrice = 30;
			AvailableClasses = 0x7FFF;
			Model = 25867;
			ObjectClass = 4;
			SubClass = 1;
			Level = 10;
			ReqLevel = 5;
			Name = "Beaded Gloves";
			Name2 = "Beaded Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 151;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 16;
		}
	}
}


/**************************************************************
*
*				(Brightcloth Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class BrightclothGloves : Item
	{
		public BrightclothGloves() : base()
		{
			Id = 14101;
			Resistance[0] = 44;
			Bonding = 2;
			SellPrice = 6066;
			AvailableClasses = 0x7FFF;
			Model = 16779;
			Resistance[4] = 12;
			ObjectClass = 4;
			SubClass = 1;
			Level = 54;
			ReqLevel = 49;
			Name = "Brightcloth Gloves";
			Name2 = "Brightcloth Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 30334;
			Resistance[5] = 11;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Native Handwraps)
*
***************************************************************/

namespace Server.Items
{
	public class NativeHandwraps : Item
	{
		public NativeHandwraps() : base()
		{
			Id = 14102;
			Resistance[0] = 15;
			SellPrice = 60;
			AvailableClasses = 0x7FFF;
			Model = 16586;
			ObjectClass = 4;
			SubClass = 1;
			Level = 13;
			ReqLevel = 8;
			Name = "Native Handwraps";
			Name2 = "Native Handwraps";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 300;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 18;
		}
	}
}


/**************************************************************
*
*				(Aboriginal Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class AboriginalGloves : Item
	{
		public AboriginalGloves() : base()
		{
			Id = 14117;
			Resistance[0] = 18;
			Bonding = 2;
			SellPrice = 163;
			AvailableClasses = 0x7FFF;
			Model = 14542;
			ObjectClass = 4;
			SubClass = 1;
			Level = 16;
			ReqLevel = 11;
			Name = "Aboriginal Gloves";
			Name2 = "Aboriginal Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 708;
			BuyPrice = 816;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 18;
		}
	}
}


/**************************************************************
*
*				(Ritual Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class RitualGloves : Item
	{
		public RitualGloves() : base()
		{
			Id = 14124;
			Resistance[0] = 21;
			Bonding = 2;
			SellPrice = 292;
			AvailableClasses = 0x7FFF;
			Model = 16657;
			ObjectClass = 4;
			SubClass = 1;
			Level = 20;
			ReqLevel = 15;
			Name = "Ritual Gloves";
			Name2 = "Ritual Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 709;
			BuyPrice = 1463;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Ghostweave Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class GhostweaveGloves : Item
	{
		public GhostweaveGloves() : base()
		{
			Id = 14142;
			Resistance[0] = 44;
			Bonding = 2;
			SellPrice = 6087;
			AvailableClasses = 0x7FFF;
			Model = 24977;
			ObjectClass = 4;
			SubClass = 1;
			Level = 54;
			ReqLevel = 49;
			Name = "Ghostweave Gloves";
			Name2 = "Ghostweave Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 30436;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			SetSpell( 18379 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Gloves of Spell Mastery)
*
***************************************************************/

namespace Server.Items
{
	public class GlovesOfSpellMastery : Item
	{
		public GlovesOfSpellMastery() : base()
		{
			Id = 14146;
			Resistance[0] = 60;
			Bonding = 2;
			SellPrice = 14084;
			AvailableClasses = 0x7B90;
			Model = 24986;
			ObjectClass = 4;
			SubClass = 1;
			Level = 62;
			ReqLevel = 57;
			Name = "Gloves of Spell Mastery";
			Name2 = "Gloves of Spell Mastery";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 70421;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			SetSpell( 18382 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 10;
			IqBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Pagan Mitts)
*
***************************************************************/

namespace Server.Items
{
	public class PaganMitts : Item
	{
		public PaganMitts() : base()
		{
			Id = 14162;
			Resistance[0] = 23;
			Bonding = 2;
			SellPrice = 445;
			AvailableClasses = 0x7FFF;
			Model = 11144;
			ObjectClass = 4;
			SubClass = 1;
			Level = 23;
			ReqLevel = 18;
			Name = "Pagan Mitts";
			Name2 = "Pagan Mitts";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 710;
			BuyPrice = 2228;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Buccaneer's Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class BuccaneersGloves : Item
	{
		public BuccaneersGloves() : base()
		{
			Id = 14168;
			Resistance[0] = 21;
			Bonding = 2;
			SellPrice = 275;
			AvailableClasses = 0x7FFF;
			Model = 28056;
			ObjectClass = 4;
			SubClass = 1;
			Level = 20;
			ReqLevel = 15;
			Name = "Buccaneer's Gloves";
			Name2 = "Buccaneer's Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 709;
			BuyPrice = 1379;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Watcher's Handwraps)
*
***************************************************************/

namespace Server.Items
{
	public class WatchersHandwraps : Item
	{
		public WatchersHandwraps() : base()
		{
			Id = 14181;
			Resistance[0] = 26;
			Bonding = 2;
			SellPrice = 775;
			AvailableClasses = 0x7FFF;
			Model = 25971;
			ObjectClass = 4;
			SubClass = 1;
			Level = 28;
			ReqLevel = 23;
			Name = "Watcher's Handwraps";
			Name2 = "Watcher's Handwraps";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 712;
			BuyPrice = 3877;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Raincaller Mitts)
*
***************************************************************/

namespace Server.Items
{
	public class RaincallerMitts : Item
	{
		public RaincallerMitts() : base()
		{
			Id = 14191;
			Resistance[0] = 27;
			Bonding = 2;
			SellPrice = 881;
			AvailableClasses = 0x7FFF;
			Model = 25987;
			ObjectClass = 4;
			SubClass = 1;
			Level = 30;
			ReqLevel = 25;
			Name = "Raincaller Mitts";
			Name2 = "Raincaller Mitts";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 712;
			BuyPrice = 4407;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Thistlefur Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class ThistlefurGloves : Item
	{
		public ThistlefurGloves() : base()
		{
			Id = 14199;
			Resistance[0] = 28;
			Bonding = 2;
			SellPrice = 1240;
			AvailableClasses = 0x7FFF;
			Model = 26007;
			ObjectClass = 4;
			SubClass = 1;
			Level = 33;
			ReqLevel = 28;
			Name = "Thistlefur Gloves";
			Name2 = "Thistlefur Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 713;
			BuyPrice = 6200;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Vital Handwraps)
*
***************************************************************/

namespace Server.Items
{
	public class VitalHandwraps : Item
	{
		public VitalHandwraps() : base()
		{
			Id = 14211;
			Resistance[0] = 29;
			Bonding = 2;
			SellPrice = 1325;
			AvailableClasses = 0x7FFF;
			Model = 26020;
			ObjectClass = 4;
			SubClass = 1;
			Level = 34;
			ReqLevel = 29;
			Name = "Vital Handwraps";
			Name2 = "Vital Handwraps";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 714;
			BuyPrice = 6626;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Geomancer's Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class GeomancersGloves : Item
	{
		public GeomancersGloves() : base()
		{
			Id = 14222;
			Resistance[0] = 31;
			Bonding = 2;
			SellPrice = 1834;
			AvailableClasses = 0x7FFF;
			Model = 26050;
			ObjectClass = 4;
			SubClass = 1;
			Level = 37;
			ReqLevel = 32;
			Name = "Geomancer's Gloves";
			Name2 = "Geomancer's Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 715;
			BuyPrice = 9174;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Embersilk Mitts)
*
***************************************************************/

namespace Server.Items
{
	public class EmbersilkMitts : Item
	{
		public EmbersilkMitts() : base()
		{
			Id = 14231;
			Resistance[0] = 31;
			Bonding = 2;
			SellPrice = 1904;
			AvailableClasses = 0x7FFF;
			Model = 26062;
			ObjectClass = 4;
			SubClass = 1;
			Level = 38;
			ReqLevel = 33;
			Name = "Embersilk Mitts";
			Name2 = "Embersilk Mitts";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 715;
			BuyPrice = 9524;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Darkmist Handguards)
*
***************************************************************/

namespace Server.Items
{
	public class DarkmistHandguards : Item
	{
		public DarkmistHandguards() : base()
		{
			Id = 14241;
			Resistance[0] = 34;
			Bonding = 2;
			SellPrice = 2311;
			AvailableClasses = 0x7FFF;
			Model = 26102;
			ObjectClass = 4;
			SubClass = 1;
			Level = 41;
			ReqLevel = 36;
			Name = "Darkmist Handguards";
			Name2 = "Darkmist Handguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 716;
			BuyPrice = 11558;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Lunar Handwraps)
*
***************************************************************/

namespace Server.Items
{
	public class LunarHandwraps : Item
	{
		public LunarHandwraps() : base()
		{
			Id = 14253;
			Resistance[0] = 35;
			Bonding = 2;
			SellPrice = 2819;
			AvailableClasses = 0x7FFF;
			Model = 26113;
			ObjectClass = 4;
			SubClass = 1;
			Level = 43;
			ReqLevel = 38;
			Name = "Lunar Handwraps";
			Name2 = "Lunar Handwraps";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 717;
			BuyPrice = 14095;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Bloodwoven Mitts)
*
***************************************************************/

namespace Server.Items
{
	public class BloodwovenMitts : Item
	{
		public BloodwovenMitts() : base()
		{
			Id = 14262;
			Resistance[0] = 37;
			Bonding = 2;
			SellPrice = 3156;
			AvailableClasses = 0x7FFF;
			Model = 26193;
			ObjectClass = 4;
			SubClass = 1;
			Level = 45;
			ReqLevel = 40;
			Name = "Bloodwoven Mitts";
			Name2 = "Bloodwoven Mitts";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 717;
			BuyPrice = 15783;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Gaea's Handwraps)
*
***************************************************************/

namespace Server.Items
{
	public class GaeasHandwraps : Item
	{
		public GaeasHandwraps() : base()
		{
			Id = 14272;
			Resistance[0] = 38;
			Bonding = 2;
			SellPrice = 3820;
			AvailableClasses = 0x7FFF;
			Model = 26143;
			ObjectClass = 4;
			SubClass = 1;
			Level = 47;
			ReqLevel = 42;
			Name = "Gaea's Handwraps";
			Name2 = "Gaea's Handwraps";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 718;
			BuyPrice = 19104;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Opulent Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class OpulentGloves : Item
	{
		public OpulentGloves() : base()
		{
			Id = 14282;
			Resistance[0] = 41;
			Bonding = 2;
			SellPrice = 4552;
			AvailableClasses = 0x7FFF;
			Model = 26132;
			ObjectClass = 4;
			SubClass = 1;
			Level = 50;
			ReqLevel = 45;
			Name = "Opulent Gloves";
			Name2 = "Opulent Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 719;
			BuyPrice = 22760;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Arachnidian Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class ArachnidianGloves : Item
	{
		public ArachnidianGloves() : base()
		{
			Id = 14294;
			Resistance[0] = 41;
			Bonding = 2;
			SellPrice = 5223;
			AvailableClasses = 0x7FFF;
			Model = 26208;
			ObjectClass = 4;
			SubClass = 1;
			Level = 51;
			ReqLevel = 46;
			Name = "Arachnidian Gloves";
			Name2 = "Arachnidian Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 719;
			BuyPrice = 26119;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Bonecaster's Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class BonecastersGloves : Item
	{
		public BonecastersGloves() : base()
		{
			Id = 14302;
			Resistance[0] = 45;
			Bonding = 2;
			SellPrice = 6517;
			AvailableClasses = 0x7FFF;
			Model = 26275;
			ObjectClass = 4;
			SubClass = 1;
			Level = 56;
			ReqLevel = 51;
			Name = "Bonecaster's Gloves";
			Name2 = "Bonecaster's Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 721;
			BuyPrice = 32587;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Celestial Handwraps)
*
***************************************************************/

namespace Server.Items
{
	public class CelestialHandwraps : Item
	{
		public CelestialHandwraps() : base()
		{
			Id = 14314;
			Resistance[0] = 47;
			Bonding = 2;
			SellPrice = 7854;
			AvailableClasses = 0x7FFF;
			Model = 26258;
			ObjectClass = 4;
			SubClass = 1;
			Level = 58;
			ReqLevel = 53;
			Name = "Celestial Handwraps";
			Name2 = "Celestial Handwraps";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 722;
			BuyPrice = 39270;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Resplendent Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class ResplendentGauntlets : Item
	{
		public ResplendentGauntlets() : base()
		{
			Id = 14323;
			Resistance[0] = 48;
			Bonding = 2;
			SellPrice = 8322;
			AvailableClasses = 0x7FFF;
			Model = 26290;
			ObjectClass = 4;
			SubClass = 1;
			Level = 60;
			ReqLevel = 55;
			Name = "Resplendent Gauntlets";
			Name2 = "Resplendent Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 722;
			BuyPrice = 41612;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Eternal Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class EternalGloves : Item
	{
		public EternalGloves() : base()
		{
			Id = 14333;
			Resistance[0] = 51;
			Bonding = 2;
			SellPrice = 9987;
			AvailableClasses = 0x7FFF;
			Model = 26222;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Eternal Gloves";
			Name2 = "Eternal Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 723;
			BuyPrice = 49937;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Mystic's Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class MysticsGloves : Item
	{
		public MysticsGloves() : base()
		{
			Id = 14367;
			Resistance[0] = 20;
			Bonding = 2;
			SellPrice = 251;
			AvailableClasses = 0x7FFF;
			Model = 25885;
			ObjectClass = 4;
			SubClass = 1;
			Level = 19;
			ReqLevel = 14;
			Name = "Mystic's Gloves";
			Name2 = "Mystic's Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1259;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 20;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Sanguine Handwraps)
*
***************************************************************/

namespace Server.Items
{
	public class SanguineHandwraps : Item
	{
		public SanguineHandwraps() : base()
		{
			Id = 14377;
			Resistance[0] = 25;
			Bonding = 2;
			SellPrice = 602;
			AvailableClasses = 0x7FFF;
			Model = 25961;
			ObjectClass = 4;
			SubClass = 1;
			Level = 26;
			ReqLevel = 21;
			Name = "Sanguine Handwraps";
			Name2 = "Sanguine Handwraps";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3011;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			StaminaBonus = 5;
			SpiritBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Resilient Handgrips)
*
***************************************************************/

namespace Server.Items
{
	public class ResilientHandgrips : Item
	{
		public ResilientHandgrips() : base()
		{
			Id = 14403;
			Resistance[0] = 27;
			Bonding = 2;
			SellPrice = 1017;
			AvailableClasses = 0x7FFF;
			Model = 25999;
			ObjectClass = 4;
			SubClass = 1;
			Level = 31;
			ReqLevel = 26;
			Name = "Resilient Handgrips";
			Name2 = "Resilient Handgrips";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5088;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			SpiritBonus = 6;
			AgilityBonus = 3;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Stonecloth Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class StoneclothGloves : Item
	{
		public StoneclothGloves() : base()
		{
			Id = 14411;
			Resistance[0] = 29;
			Bonding = 2;
			SellPrice = 1387;
			AvailableClasses = 0x7FFF;
			Model = 26029;
			ObjectClass = 4;
			SubClass = 1;
			Level = 35;
			ReqLevel = 30;
			Name = "Stonecloth Gloves";
			Name2 = "Stonecloth Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6938;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			IqBonus = 8;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Silksand Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class SilksandGloves : Item
	{
		public SilksandGloves() : base()
		{
			Id = 14422;
			Resistance[0] = 33;
			Bonding = 2;
			SellPrice = 2262;
			AvailableClasses = 0x7FFF;
			Model = 26081;
			ObjectClass = 4;
			SubClass = 1;
			Level = 40;
			ReqLevel = 35;
			Name = "Silksand Gloves";
			Name2 = "Silksand Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11314;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			IqBonus = 10;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Windchaser Handguards)
*
***************************************************************/

namespace Server.Items
{
	public class WindchaserHandguards : Item
	{
		public WindchaserHandguards() : base()
		{
			Id = 14431;
			Resistance[0] = 36;
			Bonding = 2;
			SellPrice = 2877;
			AvailableClasses = 0x7FFF;
			Model = 26154;
			ObjectClass = 4;
			SubClass = 1;
			Level = 44;
			ReqLevel = 39;
			Name = "Windchaser Handguards";
			Name2 = "Windchaser Handguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 14388;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			IqBonus = 13;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Venomshroud Mitts)
*
***************************************************************/

namespace Server.Items
{
	public class VenomshroudMitts : Item
	{
		public VenomshroudMitts() : base()
		{
			Id = 14442;
			Resistance[0] = 40;
			Bonding = 2;
			SellPrice = 4481;
			AvailableClasses = 0x7FFF;
			Model = 16633;
			ObjectClass = 4;
			SubClass = 1;
			Level = 49;
			ReqLevel = 44;
			Name = "Venomshroud Mitts";
			Name2 = "Venomshroud Mitts";
			Resistance[3] = 3;
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 22407;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			IqBonus = 12;
			SpiritBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Highborne Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class HighborneGloves : Item
	{
		public HighborneGloves() : base()
		{
			Id = 14451;
			Resistance[0] = 43;
			Bonding = 2;
			SellPrice = 5536;
			AvailableClasses = 0x7FFF;
			Model = 18423;
			ObjectClass = 4;
			SubClass = 1;
			Level = 53;
			ReqLevel = 48;
			Name = "Highborne Gloves";
			Name2 = "Highborne Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 27684;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			IqBonus = 10;
			SpiritBonus = 10;
			AgilityBonus = 5;
			StrBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Elunarian Handgrips)
*
***************************************************************/

namespace Server.Items
{
	public class ElunarianHandgrips : Item
	{
		public ElunarianHandgrips() : base()
		{
			Id = 14461;
			Resistance[0] = 50;
			Bonding = 2;
			SellPrice = 9342;
			AvailableClasses = 0x7FFF;
			Model = 26236;
			ObjectClass = 4;
			SubClass = 1;
			Level = 62;
			ReqLevel = 57;
			Name = "Elunarian Handgrips";
			Name2 = "Elunarian Handgrips";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 46714;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			IqBonus = 12;
			SpiritBonus = 8;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Darkshade Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class DarkshadeGloves : Item
	{
		public DarkshadeGloves() : base()
		{
			Id = 14543;
			Resistance[6] = 15;
			Resistance[0] = 55;
			Bonding = 1;
			SellPrice = 10478;
			AvailableClasses = 0x7FFF;
			Model = 28703;
			ObjectClass = 4;
			SubClass = 1;
			Level = 62;
			ReqLevel = 57;
			Name = "Darkshade Gloves";
			Name2 = "Darkshade Gloves";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 52394;
			Resistance[5] = 10;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 30;
			SpiritBonus = 7;
			StaminaBonus = 6;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Welldrip Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class WelldripGloves : Item
	{
		public WelldripGloves() : base()
		{
			Id = 15401;
			Resistance[0] = 16;
			Bonding = 1;
			SellPrice = 72;
			AvailableClasses = 0x7FFF;
			Model = 28183;
			ObjectClass = 4;
			SubClass = 1;
			Level = 14;
			Name = "Welldrip Gloves";
			Name2 = "Welldrip Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 364;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 18;
		}
	}
}


/**************************************************************
*
*				(Pardoc Grips)
*
***************************************************************/

namespace Server.Items
{
	public class PardocGrips : Item
	{
		public PardocGrips() : base()
		{
			Id = 15585;
			Resistance[0] = 29;
			Bonding = 1;
			SellPrice = 1446;
			AvailableClasses = 0x7FFF;
			Model = 28289;
			ObjectClass = 4;
			SubClass = 1;
			Level = 35;
			Name = "Pardoc Grips";
			Name2 = "Pardoc Grips";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7234;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			IqBonus = 8;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Freewind Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class FreewindGloves : Item
	{
		public FreewindGloves() : base()
		{
			Id = 15858;
			Resistance[0] = 48;
			Bonding = 1;
			SellPrice = 7530;
			AvailableClasses = 0x7FFF;
			Model = 26540;
			ObjectClass = 4;
			SubClass = 1;
			Level = 59;
			Name = "Freewind Gloves";
			Name2 = "Freewind Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 37653;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			IqBonus = 19;
		}
	}
}


/**************************************************************
*
*				(Knight-Lieutenant's Silk Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class KnightLieutenantsSilkGloves : Item
	{
		public KnightLieutenantsSilkGloves() : base()
		{
			Id = 16391;
			Resistance[0] = 56;
			Bonding = 1;
			SellPrice = 5652;
			AvailableClasses = 0x80;
			Model = 31064;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Knight-Lieutenant's Silk Gloves";
			Name2 = "Knight-Lieutenant's Silk Gloves";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 28261;
			Sets = 343;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 30;
			Flags = 32768;
			SetSpell( 23037 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 14248 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Marshal's Silk Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class MarshalsSilkGloves : Item
	{
		public MarshalsSilkGloves() : base()
		{
			Id = 16440;
			Resistance[0] = 63;
			Bonding = 1;
			SellPrice = 8810;
			AvailableClasses = 0x80;
			Model = 30339;
			ObjectClass = 4;
			SubClass = 1;
			Level = 65;
			ReqLevel = 60;
			Name = "Marshal's Silk Gloves";
			Name2 = "Marshal's Silk Gloves";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 44054;
			Sets = 388;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 35;
			Flags = 32768;
			SetSpell( 14798 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 16;
		}
	}
}


/**************************************************************
*
*				(Blood Guard's Silk Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class BloodGuardsSilkGloves : Item
	{
		public BloodGuardsSilkGloves() : base()
		{
			Id = 16487;
			Resistance[0] = 56;
			Bonding = 1;
			SellPrice = 5716;
			AvailableClasses = 0x80;
			Model = 31098;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Blood Guard's Silk Gloves";
			Name2 = "Blood Guard's Silk Gloves";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 28584;
			Sets = 341;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 30;
			Flags = 32768;
			SetSpell( 23037 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 14248 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 11;
		}
	}
}


/**************************************************************
*
*				(General's Silk Handguards)
*
***************************************************************/

namespace Server.Items
{
	public class GeneralsSilkHandguards : Item
	{
		public GeneralsSilkHandguards() : base()
		{
			Id = 16540;
			Resistance[0] = 63;
			Bonding = 1;
			SellPrice = 8406;
			AvailableClasses = 0x80;
			Model = 30379;
			ObjectClass = 4;
			SubClass = 1;
			Level = 65;
			ReqLevel = 60;
			Name = "General's Silk Handguards";
			Name2 = "General's Silk Handguards";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 42031;
			Sets = 387;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 35;
			Flags = 32768;
			SetSpell( 23037 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 14798 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 16;
		}
	}
}


/**************************************************************
*
*				(Magister's Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class MagistersGloves : Item
	{
		public MagistersGloves() : base()
		{
			Id = 16684;
			Resistance[0] = 52;
			Bonding = 2;
			SellPrice = 9093;
			AvailableClasses = 0x7FFF;
			Model = 29593;
			ObjectClass = 4;
			SubClass = 1;
			Level = 59;
			ReqLevel = 54;
			Name = "Magister's Gloves";
			Name2 = "Magister's Gloves";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 45468;
			Sets = 181;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 30;
			IqBonus = 14;
			SpiritBonus = 14;
			StaminaBonus = 6;
			AgilityBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Devout Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class DevoutGloves : Item
	{
		public DevoutGloves() : base()
		{
			Id = 16692;
			Resistance[0] = 52;
			Bonding = 1;
			SellPrice = 9372;
			AvailableClasses = 0x7FFF;
			Model = 30427;
			ObjectClass = 4;
			SubClass = 1;
			Level = 59;
			ReqLevel = 54;
			Name = "Devout Gloves";
			Name2 = "Devout Gloves";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 46861;
			Sets = 182;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 30;
			IqBonus = 17;
			SpiritBonus = 10;
			StaminaBonus = 7;
			AgilityBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Dreadmist Wraps)
*
***************************************************************/

namespace Server.Items
{
	public class DreadmistWraps : Item
	{
		public DreadmistWraps() : base()
		{
			Id = 16705;
			Resistance[0] = 52;
			Bonding = 2;
			SellPrice = 9127;
			AvailableClasses = 0x7FFF;
			Model = 29800;
			ObjectClass = 4;
			SubClass = 1;
			Level = 59;
			ReqLevel = 54;
			Name = "Dreadmist Wraps";
			Name2 = "Dreadmist Wraps";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 45639;
			Sets = 183;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 30;
			IqBonus = 14;
			SpiritBonus = 9;
			StaminaBonus = 9;
			AgilityBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Witherseed Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class WitherseedGloves : Item
	{
		public WitherseedGloves() : base()
		{
			Id = 16738;
			Resistance[0] = 39;
			Bonding = 1;
			SellPrice = 3893;
			AvailableClasses = 0x7FFF;
			Model = 27910;
			ObjectClass = 4;
			SubClass = 1;
			Level = 48;
			Name = "Witherseed Gloves";
			Name2 = "Witherseed Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 19468;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			IqBonus = 13;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Shredder Operating Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class ShredderOperatingGloves : Item
	{
		public ShredderOperatingGloves() : base()
		{
			Id = 16740;
			Resistance[0] = 27;
			Bonding = 1;
			SellPrice = 942;
			AvailableClasses = 0x7FFF;
			Model = 27912;
			ObjectClass = 4;
			SubClass = 1;
			Level = 31;
			Name = "Shredder Operating Gloves";
			Name2 = "Shredder Operating Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4712;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			SpiritBonus = 6;
			StaminaBonus = 5;
			AgilityBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Arcanist Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class ArcanistGloves : Item
	{
		public ArcanistGloves() : base()
		{
			Id = 16801;
			Resistance[0] = 63;
			Bonding = 1;
			SellPrice = 17322;
			AvailableClasses = 0x80;
			Model = 30585;
			Resistance[2] = 7;
			ObjectClass = 4;
			SubClass = 1;
			Level = 66;
			ReqLevel = 60;
			Name = "Arcanist Gloves";
			Name2 = "Arcanist Gloves";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 86612;
			Sets = 201;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			SetSpell( 21618 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 18;
			IqBonus = 10;
			StaminaBonus = 17;
		}
	}
}


/**************************************************************
*
*				(Felheart Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class FelheartGloves : Item
	{
		public FelheartGloves() : base()
		{
			Id = 16805;
			Resistance[0] = 63;
			Bonding = 1;
			SellPrice = 17583;
			AvailableClasses = 0x100;
			Model = 31971;
			Resistance[2] = 7;
			ObjectClass = 4;
			SubClass = 1;
			Level = 66;
			ReqLevel = 60;
			Name = "Felheart Gloves";
			Name2 = "Felheart Gloves";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 87918;
			Sets = 203;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			SetSpell( 18384 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 9415 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 15;
			IqBonus = 8;
			StaminaBonus = 18;
		}
	}
}


/**************************************************************
*
*				(Gloves of Prophecy)
*
***************************************************************/

namespace Server.Items
{
	public class GlovesOfProphecy : Item
	{
		public GlovesOfProphecy() : base()
		{
			Id = 16812;
			Resistance[0] = 63;
			Bonding = 1;
			SellPrice = 18040;
			AvailableClasses = 0x10;
			Model = 30620;
			Resistance[2] = 7;
			ObjectClass = 4;
			SubClass = 1;
			Level = 66;
			ReqLevel = 60;
			Name = "Gloves of Prophecy";
			Name2 = "Gloves of Prophecy";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 90203;
			Sets = 202;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			SetSpell( 21626 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 9406 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 15;
			IqBonus = 15;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Netherwind Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class NetherwindGloves : Item
	{
		public NetherwindGloves() : base()
		{
			Id = 16913;
			Resistance[0] = 72;
			Bonding = 1;
			SellPrice = 28109;
			AvailableClasses = 0x80;
			Model = 29781;
			ObjectClass = 4;
			SubClass = 1;
			Level = 76;
			ReqLevel = 60;
			Name = "Netherwind Gloves";
			Name2 = "Netherwind Gloves";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 140546;
			Sets = 210;
			Resistance[5] = 10;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			SetSpell( 18384 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 9344 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 17;
			IqBonus = 14;
			StaminaBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Handguards of Transcendence)
*
***************************************************************/

namespace Server.Items
{
	public class HandguardsOfTranscendence : Item
	{
		public HandguardsOfTranscendence() : base()
		{
			Id = 16920;
			Resistance[0] = 72;
			Bonding = 1;
			SellPrice = 28856;
			AvailableClasses = 0x10;
			Model = 29781;
			ObjectClass = 4;
			SubClass = 1;
			Level = 76;
			ReqLevel = 60;
			Name = "Handguards of Transcendence";
			Name2 = "Handguards of Transcendence";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 144281;
			Sets = 211;
			Resistance[5] = 10;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			SetSpell( 18384 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 9316 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 20;
			IqBonus = 13;
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Nemesis Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class NemesisGloves : Item
	{
		public NemesisGloves() : base()
		{
			Id = 16928;
			Resistance[0] = 72;
			Bonding = 1;
			SellPrice = 27573;
			AvailableClasses = 0x100;
			Model = 29856;
			ObjectClass = 4;
			SubClass = 1;
			Level = 76;
			ReqLevel = 60;
			Name = "Nemesis Gloves";
			Name2 = "Nemesis Gloves";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 137868;
			Sets = 212;
			Resistance[5] = 10;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			SetSpell( 20885 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 9343 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 16;
			IqBonus = 7;
			StaminaBonus = 17;
		}
	}
}


/**************************************************************
*
*				(Flarecore Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class FlarecoreGloves : Item
	{
		public FlarecoreGloves() : base()
		{
			Id = 16979;
			Resistance[0] = 60;
			Bonding = 1;
			SellPrice = 14901;
			AvailableClasses = 0x7B90;
			Model = 28754;
			Resistance[2] = 25;
			ObjectClass = 4;
			SubClass = 1;
			Level = 62;
			ReqLevel = 57;
			Name = "Flarecore Gloves";
			Name2 = "Flarecore Gloves";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 74509;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			SpiritBonus = 14;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Knight-Lieutenant's Dreadweave Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class KnightLieutenantsDreadweaveGloves : Item
	{
		public KnightLieutenantsDreadweaveGloves() : base()
		{
			Id = 17564;
			Resistance[0] = 56;
			Bonding = 1;
			SellPrice = 5866;
			AvailableClasses = 0x100;
			Model = 31060;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Knight-Lieutenant's Dreadweave Gloves";
			Name2 = "Knight-Lieutenant's Dreadweave Gloves";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 29332;
			Sets = 346;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 30;
			Flags = 32768;
			SetSpell( 23046 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 18;
			SpiritBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Blood Guard's Dreadweave Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class BloodGuardsDreadweaveGloves : Item
	{
		public BloodGuardsDreadweaveGloves() : base()
		{
			Id = 17577;
			Resistance[0] = 56;
			Bonding = 1;
			SellPrice = 5717;
			AvailableClasses = 0x100;
			Model = 27256;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Blood Guard's Dreadweave Gloves";
			Name2 = "Blood Guard's Dreadweave Gloves";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 28589;
			Sets = 345;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 30;
			Flags = 32768;
			SetSpell( 23046 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 14248 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Marshal's Dreadweave Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class MarshalsDreadweaveGloves : Item
	{
		public MarshalsDreadweaveGloves() : base()
		{
			Id = 17584;
			Resistance[0] = 63;
			Bonding = 1;
			SellPrice = 8847;
			AvailableClasses = 0x100;
			Model = 30339;
			ObjectClass = 4;
			SubClass = 1;
			Level = 65;
			ReqLevel = 60;
			Name = "Marshal's Dreadweave Gloves";
			Name2 = "Marshal's Dreadweave Gloves";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 44236;
			Sets = 392;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 35;
			Flags = 32768;
			SetSpell( 23046 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 14798 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 16;
		}
	}
}


/**************************************************************
*
*				(General's Dreadweave Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class GeneralsDreadweaveGloves : Item
	{
		public GeneralsDreadweaveGloves() : base()
		{
			Id = 17588;
			Resistance[0] = 63;
			Bonding = 1;
			SellPrice = 8124;
			AvailableClasses = 0x100;
			Model = 30379;
			ObjectClass = 4;
			SubClass = 1;
			Level = 65;
			ReqLevel = 60;
			Name = "General's Dreadweave Gloves";
			Name2 = "General's Dreadweave Gloves";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 40621;
			Sets = 391;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 35;
			Flags = 32768;
			SetSpell( 23046 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 14798 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 16;
		}
	}
}


/**************************************************************
*
*				(Knight-Lieutenant's Satin Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class KnightLieutenantsSatinGloves : Item
	{
		public KnightLieutenantsSatinGloves() : base()
		{
			Id = 17596;
			Resistance[0] = 56;
			Bonding = 1;
			SellPrice = 5696;
			AvailableClasses = 0x10;
			Model = 31062;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Knight-Lieutenant's Satin Gloves";
			Name2 = "Knight-Lieutenant's Satin Gloves";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 28480;
			Sets = 344;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 30;
			Flags = 32768;
			SetSpell( 23043 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 14248 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Marshal's Satin Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class MarshalsSatinGloves : Item
	{
		public MarshalsSatinGloves() : base()
		{
			Id = 17608;
			Resistance[0] = 63;
			Bonding = 1;
			SellPrice = 8123;
			AvailableClasses = 0x10;
			Model = 30339;
			ObjectClass = 4;
			SubClass = 1;
			Level = 65;
			ReqLevel = 60;
			Name = "Marshal's Satin Gloves";
			Name2 = "Marshal's Satin Gloves";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 40617;
			Sets = 389;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 35;
			Flags = 32768;
			SetSpell( 14798 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 23043 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 16;
		}
	}
}


/**************************************************************
*
*				(Blood Guard's Satin Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class BloodGuardsSatinGloves : Item
	{
		public BloodGuardsSatinGloves() : base()
		{
			Id = 17617;
			Resistance[0] = 56;
			Bonding = 1;
			SellPrice = 5868;
			AvailableClasses = 0x10;
			Model = 31028;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Blood Guard's Satin Gloves";
			Name2 = "Blood Guard's Satin Gloves";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 29344;
			Sets = 342;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 30;
			Flags = 32768;
			SetSpell( 23043 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 14248 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 11;
		}
	}
}


/**************************************************************
*
*				(General's Satin Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class GeneralsSatinGloves : Item
	{
		public GeneralsSatinGloves() : base()
		{
			Id = 17620;
			Resistance[0] = 63;
			Bonding = 1;
			SellPrice = 8721;
			AvailableClasses = 0x10;
			Model = 30347;
			ObjectClass = 4;
			SubClass = 1;
			Level = 65;
			ReqLevel = 60;
			Name = "General's Satin Gloves";
			Name2 = "General's Satin Gloves";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 43605;
			Sets = 390;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 35;
			Flags = 32768;
			SetSpell( 23043 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 14798 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 16;
		}
	}
}


/**************************************************************
*
*				(Jumanza Grips)
*
***************************************************************/

namespace Server.Items
{
	public class JumanzaGrips : Item
	{
		public JumanzaGrips() : base()
		{
			Id = 18083;
			Resistance[0] = 42;
			Bonding = 1;
			SellPrice = 4522;
			AvailableClasses = 0x7FFF;
			Model = 30474;
			ObjectClass = 4;
			SubClass = 1;
			Level = 47;
			ReqLevel = 42;
			Name = "Jumanza Grips";
			Name2 = "Jumanza Grips";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 22613;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 30;
			SpiritBonus = 11;
			IqBonus = 10;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Gloves of Shadowy Mist)
*
***************************************************************/

namespace Server.Items
{
	public class GlovesOfShadowyMist : Item
	{
		public GlovesOfShadowyMist() : base()
		{
			Id = 18306;
			Resistance[0] = 47;
			Bonding = 1;
			SellPrice = 7215;
			AvailableClasses = 0x7FFF;
			Model = 30669;
			ObjectClass = 4;
			SubClass = 1;
			Level = 58;
			ReqLevel = 53;
			Name = "Gloves of Shadowy Mist";
			Name2 = "Gloves of Shadowy Mist";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 36075;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			SetSpell( 9326 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Gordok's Handwraps)
*
***************************************************************/

namespace Server.Items
{
	public class GordoksHandwraps : Item
	{
		public GordoksHandwraps() : base()
		{
			Id = 18369;
			Resistance[0] = 53;
			Bonding = 1;
			SellPrice = 9915;
			AvailableClasses = 0x7FFF;
			Model = 16710;
			ObjectClass = 4;
			SubClass = 1;
			Level = 60;
			Name = "Gordok's Handwraps";
			Name2 = "Gordok's Handwraps";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 49577;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 30;
			SetSpell( 18384 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 10;
			SpiritBonus = 10;
			IqBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Brightspark Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class BrightsparkGloves : Item
	{
		public BrightsparkGloves() : base()
		{
			Id = 18387;
			Resistance[0] = 53;
			Bonding = 1;
			SellPrice = 9488;
			AvailableClasses = 0x7FFF;
			Model = 13656;
			ObjectClass = 4;
			SubClass = 1;
			Level = 60;
			ReqLevel = 55;
			Name = "Brightspark Gloves";
			Name2 = "Brightspark Gloves";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 47443;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 30;
			SetSpell( 18384 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 15;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Felcloth Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class FelclothGloves : Item
	{
		public FelclothGloves() : base()
		{
			Id = 18407;
			Resistance[0] = 55;
			Bonding = 2;
			SellPrice = 11139;
			AvailableClasses = 0x7FFF;
			Model = 17216;
			ObjectClass = 4;
			SubClass = 1;
			Level = 62;
			ReqLevel = 57;
			Name = "Felcloth Gloves";
			Name2 = "Felcloth Gloves";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 55696;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 30;
			SetSpell( 18013 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Inferno Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class InfernoGloves : Item
	{
		public InfernoGloves() : base()
		{
			Id = 18408;
			Resistance[0] = 55;
			Bonding = 2;
			SellPrice = 11178;
			AvailableClasses = 0x7FFF;
			Model = 30772;
			ObjectClass = 4;
			SubClass = 1;
			Level = 62;
			ReqLevel = 57;
			Name = "Inferno Gloves";
			Name2 = "Inferno Gloves";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 55893;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 30;
			SetSpell( 17871 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Mooncloth Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class MoonclothGloves : Item
	{
		public MoonclothGloves() : base()
		{
			Id = 18409;
			Resistance[0] = 55;
			Bonding = 2;
			SellPrice = 11219;
			AvailableClasses = 0x7FFF;
			Model = 30774;
			ObjectClass = 4;
			SubClass = 1;
			Level = 62;
			ReqLevel = 57;
			Name = "Mooncloth Gloves";
			Name2 = "Mooncloth Gloves";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 56096;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 30;
			SpiritBonus = 16;
			IqBonus = 15;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Shivery Handwraps)
*
***************************************************************/

namespace Server.Items
{
	public class ShiveryHandwraps : Item
	{
		public ShiveryHandwraps() : base()
		{
			Id = 18693;
			Resistance[0] = 55;
			Bonding = 1;
			SellPrice = 11425;
			AvailableClasses = 0x7FFF;
			Model = 31136;
			ObjectClass = 4;
			SubClass = 1;
			Level = 62;
			ReqLevel = 57;
			Name = "Shivery Handwraps";
			Name2 = "Shivery Handwraps";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 57127;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 30;
			SetSpell( 9305 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 12;
			StaminaBonus = 12;
			IqBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Shadowy Laced Handwraps)
*
***************************************************************/

namespace Server.Items
{
	public class ShadowyLacedHandwraps : Item
	{
		public ShadowyLacedHandwraps() : base()
		{
			Id = 18730;
			Resistance[0] = 53;
			Bonding = 1;
			SellPrice = 10250;
			AvailableClasses = 0x7FFF;
			Model = 31180;
			ObjectClass = 4;
			SubClass = 1;
			Level = 60;
			ReqLevel = 55;
			Name = "Shadowy Laced Handwraps";
			Name2 = "Shadowy Laced Handwraps";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 51254;
			Resistance[5] = 12;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 30;
			SetSpell( 21363 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Gloves of the Hypnotic Flame)
*
***************************************************************/

namespace Server.Items
{
	public class GlovesOfTheHypnoticFlame : Item
	{
		public GlovesOfTheHypnoticFlame() : base()
		{
			Id = 18808;
			Resistance[0] = 67;
			Bonding = 1;
			SellPrice = 22665;
			AvailableClasses = 0x7FFF;
			Model = 31276;
			ObjectClass = 4;
			SubClass = 1;
			Level = 70;
			ReqLevel = 60;
			Name = "Gloves of the Hypnotic Flame";
			Name2 = "Gloves of the Hypnotic Flame";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 113326;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			SetSpell( 17747 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 9415 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 19;
			StaminaBonus = 18;
			IqBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Greenleaf Handwraps)
*
***************************************************************/

namespace Server.Items
{
	public class GreenleafHandwraps : Item
	{
		public GreenleafHandwraps() : base()
		{
			Id = 19116;
			Resistance[0] = 41;
			Bonding = 1;
			SellPrice = 4590;
			AvailableClasses = 0x7FFF;
			Model = 31625;
			ObjectClass = 4;
			SubClass = 1;
			Level = 50;
			Name = "Greenleaf Handwraps";
			Name2 = "Greenleaf Handwraps";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 22952;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			SetSpell( 9408 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Everwarm Handwraps)
*
***************************************************************/

namespace Server.Items
{
	public class EverwarmHandwraps : Item
	{
		public EverwarmHandwraps() : base()
		{
			Id = 19123;
			Resistance[0] = 39;
			Bonding = 1;
			SellPrice = 4114;
			AvailableClasses = 0x7FFF;
			Model = 31634;
			ObjectClass = 4;
			SubClass = 1;
			Level = 48;
			Name = "Everwarm Handwraps";
			Name2 = "Everwarm Handwraps";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 20572;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 25;
			SetSpell( 21618 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Gloves of Rapid Evolution)
*
***************************************************************/

namespace Server.Items
{
	public class GlovesOfRapidEvolution : Item
	{
		public GlovesOfRapidEvolution() : base()
		{
			Id = 19369;
			Resistance[0] = 70;
			Bonding = 1;
			SellPrice = 25870;
			AvailableClasses = 0x7FFF;
			Model = 31888;
			ObjectClass = 4;
			SubClass = 1;
			Level = 73;
			ReqLevel = 60;
			Name = "Gloves of Rapid Evolution";
			Name2 = "Gloves of Rapid Evolution";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 129350;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			SpiritBonus = 12;
			IqBonus = 32;
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Ebony Flame Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class EbonyFlameGloves : Item
	{
		public EbonyFlameGloves() : base()
		{
			Id = 19407;
			Resistance[0] = 72;
			Bonding = 1;
			SellPrice = 28312;
			AvailableClasses = 0x7FFF;
			Model = 18858;
			ObjectClass = 4;
			SubClass = 1;
			Level = 75;
			ReqLevel = 60;
			Name = "Ebony Flame Gloves";
			Name2 = "Ebony Flame Gloves";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 141561;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			SetSpell( 18020 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 12;
			StaminaBonus = 17;
		}
	}
}


