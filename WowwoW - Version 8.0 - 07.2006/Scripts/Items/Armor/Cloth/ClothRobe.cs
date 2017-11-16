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
*				(Apprentice's Robe)
*
***************************************************************/

namespace Server.Items
{
	public class ApprenticesRobe : Item
	{
		public ApprenticesRobe() : base()
		{
			Id = 56;
			Resistance[0] = 3;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 12647;
			ObjectClass = 4;
			SubClass = 1;
			Level = 1;
			ReqLevel = 1;
			Name = "Apprentice's Robe";
			Name2 = "Apprentice's Robe";
			AvailableRaces = 0x1FF;
			BuyPrice = 5;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Acolyte's Robe)
*
***************************************************************/

namespace Server.Items
{
	public class AcolytesRobe : Item
	{
		public AcolytesRobe() : base()
		{
			Id = 57;
			Resistance[0] = 3;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 12645;
			ObjectClass = 4;
			SubClass = 1;
			Level = 1;
			ReqLevel = 1;
			Name = "Acolyte's Robe";
			Name2 = "Acolyte's Robe";
			AvailableRaces = 0x1FF;
			BuyPrice = 5;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Robes of Insight)
*
***************************************************************/

namespace Server.Items
{
	public class RobesOfInsight : Item
	{
		public RobesOfInsight() : base()
		{
			Id = 940;
			Resistance[0] = 74;
			Bonding = 2;
			SellPrice = 12565;
			AvailableClasses = 0x7FFF;
			Model = 16676;
			ObjectClass = 4;
			SubClass = 1;
			Level = 47;
			ReqLevel = 42;
			Name = "Robes of Insight";
			Name2 = "Robes of Insight";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 62829;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 100;
			SetSpell( 18820 , 0 , 0 , 900000 , 28 , 300000 );
			SpiritBonus = 25;
			IqBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Well-stitched Robe)
*
***************************************************************/

namespace Server.Items
{
	public class WellStitchedRobe : Item
	{
		public WellStitchedRobe() : base()
		{
			Id = 1171;
			Resistance[0] = 18;
			Bonding = 1;
			SellPrice = 55;
			AvailableClasses = 0x7FFF;
			Model = 12707;
			ObjectClass = 4;
			SubClass = 1;
			Level = 10;
			Name = "Well-stitched Robe";
			Name2 = "Well-stitched Robe";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 277;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Robes of the Shadowcaster)
*
***************************************************************/

namespace Server.Items
{
	public class RobesOfTheShadowcaster : Item
	{
		public RobesOfTheShadowcaster() : base()
		{
			Id = 1297;
			Resistance[0] = 44;
			Bonding = 2;
			SellPrice = 2038;
			AvailableClasses = 0x7FFF;
			Model = 19035;
			ObjectClass = 4;
			SubClass = 1;
			Level = 31;
			ReqLevel = 26;
			Name = "Robes of the Shadowcaster";
			Name2 = "Robes of the Shadowcaster";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 10193;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
			SpiritBonus = 1;
			IqBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Frayed Robe)
*
***************************************************************/

namespace Server.Items
{
	public class FrayedRobe : Item
	{
		public FrayedRobe() : base()
		{
			Id = 1380;
			Resistance[0] = 8;
			SellPrice = 4;
			AvailableClasses = 0x7FFF;
			Model = 12426;
			ObjectClass = 4;
			SubClass = 1;
			Level = 4;
			ReqLevel = 1;
			Name = "Frayed Robe";
			Name2 = "Frayed Robe";
			AvailableRaces = 0x1FF;
			BuyPrice = 21;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Harvester's Robe)
*
***************************************************************/

namespace Server.Items
{
	public class HarvestersRobe : Item
	{
		public HarvestersRobe() : base()
		{
			Id = 1561;
			Resistance[0] = 28;
			Bonding = 1;
			SellPrice = 268;
			AvailableClasses = 0x7FFF;
			Model = 12671;
			ObjectClass = 4;
			SubClass = 1;
			Level = 15;
			Name = "Harvester's Robe";
			Name2 = "Harvester's Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1343;
			InventoryType = InventoryTypes.Robe;
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
*				(Robe of the Magi)
*
***************************************************************/

namespace Server.Items
{
	public class RobeOfTheMagi : Item
	{
		public RobeOfTheMagi() : base()
		{
			Id = 1716;
			Resistance[0] = 58;
			Bonding = 2;
			SellPrice = 5067;
			AvailableClasses = 0x7FFF;
			Model = 16667;
			ObjectClass = 4;
			SubClass = 1;
			Level = 40;
			ReqLevel = 35;
			Name = "Robe of the Magi";
			Name2 = "Robe of the Magi";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 25335;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 80;
			SetSpell( 15714 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 6;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Pressed Felt Robe)
*
***************************************************************/

namespace Server.Items
{
	public class PressedFeltRobe : Item
	{
		public PressedFeltRobe() : base()
		{
			Id = 1997;
			Resistance[0] = 46;
			Bonding = 2;
			SellPrice = 2538;
			AvailableClasses = 0x7FFF;
			Model = 16670;
			ObjectClass = 4;
			SubClass = 1;
			Level = 34;
			ReqLevel = 29;
			Name = "Pressed Felt Robe";
			Name2 = "Pressed Felt Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 12694;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
			SpiritBonus = 3;
			IqBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Scholarly Robes)
*
***************************************************************/

namespace Server.Items
{
	public class ScholarlyRobes : Item
	{
		public ScholarlyRobes() : base()
		{
			Id = 2034;
			Resistance[0] = 39;
			Bonding = 2;
			SellPrice = 1035;
			AvailableClasses = 0x7FFF;
			Model = 12699;
			ObjectClass = 4;
			SubClass = 1;
			Level = 25;
			ReqLevel = 20;
			Name = "Scholarly Robes";
			Name2 = "Scholarly Robes";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5179;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 65;
			SpiritBonus = 2;
			IqBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Light Magesmith Robe)
*
***************************************************************/

namespace Server.Items
{
	public class LightMagesmithRobe : Item
	{
		public LightMagesmithRobe() : base()
		{
			Id = 2110;
			Resistance[0] = 8;
			SellPrice = 6;
			AvailableClasses = 0x7FFF;
			Model = 12674;
			ObjectClass = 4;
			SubClass = 1;
			Level = 4;
			ReqLevel = 1;
			Name = "Light Magesmith Robe";
			Name2 = "Light Magesmith Robe";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 31;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Snowy Robe)
*
***************************************************************/

namespace Server.Items
{
	public class SnowyRobe : Item
	{
		public SnowyRobe() : base()
		{
			Id = 2114;
			Resistance[0] = 15;
			SellPrice = 31;
			AvailableClasses = 0x7FFF;
			Model = 16654;
			ObjectClass = 4;
			SubClass = 1;
			Level = 8;
			ReqLevel = 3;
			Name = "Snowy Robe";
			Name2 = "Snowy Robe";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 155;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Inferno Robe)
*
***************************************************************/

namespace Server.Items
{
	public class InfernoRobe : Item
	{
		public InfernoRobe() : base()
		{
			Id = 2231;
			Resistance[0] = 53;
			Bonding = 1;
			SellPrice = 4386;
			AvailableClasses = 0x7FFF;
			Model = 16671;
			ObjectClass = 4;
			SubClass = 1;
			Level = 40;
			Name = "Inferno Robe";
			Name2 = "Inferno Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 21933;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
			SetSpell( 17747 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Necrology Robes)
*
***************************************************************/

namespace Server.Items
{
	public class NecrologyRobes : Item
	{
		public NecrologyRobes() : base()
		{
			Id = 2292;
			Resistance[0] = 43;
			Bonding = 2;
			SellPrice = 1334;
			AvailableClasses = 0x7FFF;
			Model = 19037;
			ObjectClass = 4;
			SubClass = 1;
			Level = 25;
			ReqLevel = 20;
			Name = "Necrology Robes";
			Name2 = "Necrology Robes";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 6673;
			Resistance[5] = 5;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 75;
			SpiritBonus = 12;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Sacrificial Robes)
*
***************************************************************/

namespace Server.Items
{
	public class SacrificialRobes : Item
	{
		public SacrificialRobes() : base()
		{
			Id = 2566;
			Resistance[0] = 41;
			Bonding = 2;
			SellPrice = 1322;
			AvailableClasses = 0x7FFF;
			Model = 16666;
			ObjectClass = 4;
			SubClass = 1;
			Level = 27;
			ReqLevel = 22;
			Name = "Sacrificial Robes";
			Name2 = "Sacrificial Robes";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6613;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
			StaminaBonus = 3;
			IqBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Red Linen Robe)
*
***************************************************************/

namespace Server.Items
{
	public class RedLinenRobe : Item
	{
		public RedLinenRobe() : base()
		{
			Id = 2572;
			Resistance[0] = 19;
			Bonding = 2;
			SellPrice = 99;
			AvailableClasses = 0x7FFF;
			Model = 12687;
			ObjectClass = 4;
			SubClass = 1;
			Level = 10;
			ReqLevel = 5;
			Name = "Red Linen Robe";
			Name2 = "Red Linen Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 496;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			SpiritBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Gray Woolen Robe)
*
***************************************************************/

namespace Server.Items
{
	public class GrayWoolenRobe : Item
	{
		public GrayWoolenRobe() : base()
		{
			Id = 2585;
			Resistance[0] = 35;
			Bonding = 2;
			SellPrice = 638;
			AvailableClasses = 0x7FFF;
			Model = 12669;
			ObjectClass = 4;
			SubClass = 1;
			Level = 21;
			ReqLevel = 16;
			Name = "Gray Woolen Robe";
			Name2 = "Gray Woolen Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3193;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 60;
			SpiritBonus = 5;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Gamemaster's Robe)
*
***************************************************************/

namespace Server.Items
{
	public class GamemastersRobe : Item
	{
		public GamemastersRobe() : base()
		{
			Id = 2586;
			Resistance[0] = 3;
			Bonding = 1;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 22033;
			ObjectClass = 4;
			SubClass = 1;
			Level = 1;
			Name = "Gamemaster's Robe";
			Name2 = "Gamemaster's Robe";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 6;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Plain Robe)
*
***************************************************************/

namespace Server.Items
{
	public class PlainRobe : Item
	{
		public PlainRobe() : base()
		{
			Id = 2612;
			Resistance[0] = 15;
			SellPrice = 32;
			AvailableClasses = 0x7FFF;
			Model = 12704;
			ObjectClass = 4;
			SubClass = 1;
			Level = 8;
			ReqLevel = 3;
			Name = "Plain Robe";
			Name2 = "Plain Robe";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 163;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Double-stitched Robes)
*
***************************************************************/

namespace Server.Items
{
	public class DoubleStitchedRobes : Item
	{
		public DoubleStitchedRobes() : base()
		{
			Id = 2613;
			Resistance[0] = 23;
			SellPrice = 121;
			AvailableClasses = 0x7FFF;
			Model = 12661;
			ObjectClass = 4;
			SubClass = 1;
			Level = 13;
			ReqLevel = 8;
			Name = "Double-stitched Robes";
			Name2 = "Double-stitched Robes";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 607;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Robe of Apprenticeship)
*
***************************************************************/

namespace Server.Items
{
	public class RobeOfApprenticeship : Item
	{
		public RobeOfApprenticeship() : base()
		{
			Id = 2614;
			Resistance[0] = 29;
			SellPrice = 232;
			AvailableClasses = 0x7FFF;
			Model = 16614;
			ObjectClass = 4;
			SubClass = 1;
			Level = 17;
			ReqLevel = 12;
			Name = "Robe of Apprenticeship";
			Name2 = "Robe of Apprenticeship";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1161;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Chromatic Robe)
*
***************************************************************/

namespace Server.Items
{
	public class ChromaticRobe : Item
	{
		public ChromaticRobe() : base()
		{
			Id = 2615;
			Resistance[0] = 40;
			SellPrice = 1018;
			AvailableClasses = 0x7FFF;
			Model = 12655;
			ObjectClass = 4;
			SubClass = 1;
			Level = 29;
			ReqLevel = 24;
			Name = "Chromatic Robe";
			Name2 = "Chromatic Robe";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 5091;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Shimmering Silk Robes)
*
***************************************************************/

namespace Server.Items
{
	public class ShimmeringSilkRobes : Item
	{
		public ShimmeringSilkRobes() : base()
		{
			Id = 2616;
			Resistance[0] = 35;
			SellPrice = 531;
			AvailableClasses = 0x7FFF;
			Model = 12701;
			ObjectClass = 4;
			SubClass = 1;
			Level = 23;
			ReqLevel = 18;
			Name = "Shimmering Silk Robes";
			Name2 = "Shimmering Silk Robes";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2659;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Burning Robes)
*
***************************************************************/

namespace Server.Items
{
	public class BurningRobes : Item
	{
		public BurningRobes() : base()
		{
			Id = 2617;
			Resistance[0] = 46;
			SellPrice = 2198;
			AvailableClasses = 0x7FFF;
			Model = 12654;
			ObjectClass = 4;
			SubClass = 1;
			Level = 37;
			ReqLevel = 32;
			Name = "Burning Robes";
			Name2 = "Burning Robes";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 10991;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Silver Dress Robes)
*
***************************************************************/

namespace Server.Items
{
	public class SilverDressRobes : Item
	{
		public SilverDressRobes() : base()
		{
			Id = 2618;
			Resistance[0] = 62;
			SellPrice = 5327;
			AvailableClasses = 0x7FFF;
			Model = 12702;
			ObjectClass = 4;
			SubClass = 1;
			Level = 50;
			ReqLevel = 45;
			Name = "Silver Dress Robes";
			Name2 = "Silver Dress Robes";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 26639;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Black Velvet Robes)
*
***************************************************************/

namespace Server.Items
{
	public class BlackVelvetRobes : Item
	{
		public BlackVelvetRobes() : base()
		{
			Id = 2800;
			Resistance[0] = 44;
			Bonding = 2;
			SellPrice = 1525;
			AvailableClasses = 0x7FFF;
			Model = 21114;
			ObjectClass = 4;
			SubClass = 1;
			Level = 26;
			ReqLevel = 21;
			Name = "Black Velvet Robes";
			Name2 = "Black Velvet Robes";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 7625;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 75;
			SpiritBonus = 12;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Seer's Robe)
*
***************************************************************/

namespace Server.Items
{
	public class SeersRobe : Item
	{
		public SeersRobe() : base()
		{
			Id = 2981;
			Resistance[0] = 35;
			Bonding = 2;
			SellPrice = 648;
			AvailableClasses = 0x7FFF;
			Model = 14549;
			ObjectClass = 4;
			SubClass = 1;
			Level = 21;
			ReqLevel = 16;
			Name = "Seer's Robe";
			Name2 = "Seer's Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3242;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 60;
			SpiritBonus = 6;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Noble's Robe)
*
***************************************************************/

namespace Server.Items
{
	public class NoblesRobe : Item
	{
		public NoblesRobe() : base()
		{
			Id = 3019;
			Resistance[0] = 32;
			Bonding = 2;
			SellPrice = 423;
			AvailableClasses = 0x7FFF;
			Model = 12682;
			ObjectClass = 4;
			SubClass = 1;
			Level = 18;
			ReqLevel = 13;
			Name = "Noble's Robe";
			Name2 = "Noble's Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2115;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 55;
			StrBonus = 1;
			StaminaBonus = 3;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Bright Robe)
*
***************************************************************/

namespace Server.Items
{
	public class BrightRobe : Item
	{
		public BrightRobe() : base()
		{
			Id = 3069;
			Resistance[0] = 41;
			Bonding = 2;
			SellPrice = 1412;
			AvailableClasses = 0x7FFF;
			Model = 27554;
			ObjectClass = 4;
			SubClass = 1;
			Level = 27;
			ReqLevel = 22;
			Name = "Bright Robe";
			Name2 = "Bright Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7063;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
			IqBonus = 8;
			SpiritBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Smoldering Robe)
*
***************************************************************/

namespace Server.Items
{
	public class SmolderingRobe : Item
	{
		public SmolderingRobe() : base()
		{
			Id = 3072;
			Resistance[0] = 40;
			Bonding = 2;
			SellPrice = 1207;
			AvailableClasses = 0x7FFF;
			Model = 16694;
			ObjectClass = 4;
			SubClass = 1;
			Level = 26;
			ReqLevel = 21;
			Name = "Smoldering Robe";
			Name2 = "Smoldering Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6036;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 65;
			StaminaBonus = 6;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Robe of the Keeper)
*
***************************************************************/

namespace Server.Items
{
	public class RobeOfTheKeeper : Item
	{
		public RobeOfTheKeeper() : base()
		{
			Id = 3161;
			Resistance[0] = 28;
			Bonding = 1;
			SellPrice = 294;
			AvailableClasses = 0x7FFF;
			Model = 16696;
			ObjectClass = 4;
			SubClass = 1;
			Level = 15;
			Name = "Robe of the Keeper";
			Name2 = "Robe of the Keeper";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1474;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 50;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Warm Winter Robe)
*
***************************************************************/

namespace Server.Items
{
	public class WarmWinterRobe : Item
	{
		public WarmWinterRobe() : base()
		{
			Id = 3216;
			Resistance[0] = 18;
			Bonding = 1;
			SellPrice = 55;
			AvailableClasses = 0x7FFF;
			Model = 18121;
			ObjectClass = 4;
			SubClass = 1;
			Level = 10;
			Name = "Warm Winter Robe";
			Name2 = "Warm Winter Robe";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 275;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Scarlet Initiate Robes)
*
***************************************************************/

namespace Server.Items
{
	public class ScarletInitiateRobes : Item
	{
		public ScarletInitiateRobes() : base()
		{
			Id = 3260;
			Resistance[0] = 8;
			SellPrice = 6;
			AvailableClasses = 0x7FFF;
			Model = 16612;
			ObjectClass = 4;
			SubClass = 1;
			Level = 4;
			ReqLevel = 1;
			Name = "Scarlet Initiate Robes";
			Name2 = "Scarlet Initiate Robes";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 31;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Spider Web Robe)
*
***************************************************************/

namespace Server.Items
{
	public class SpiderWebRobe : Item
	{
		public SpiderWebRobe() : base()
		{
			Id = 3328;
			Resistance[0] = 17;
			SellPrice = 46;
			AvailableClasses = 0x7FFF;
			Model = 16655;
			ObjectClass = 4;
			SubClass = 1;
			Level = 9;
			ReqLevel = 4;
			Name = "Spider Web Robe";
			Name2 = "Spider Web Robe";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 233;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(High Robe of the Adjudicator)
*
***************************************************************/

namespace Server.Items
{
	public class HighRobeOfTheAdjudicator : Item
	{
		public HighRobeOfTheAdjudicator() : base()
		{
			Id = 3461;
			Resistance[0] = 38;
			Bonding = 1;
			SellPrice = 1005;
			AvailableClasses = 0x7FFF;
			Model = 12672;
			ObjectClass = 4;
			SubClass = 1;
			Level = 24;
			Name = "High Robe of the Adjudicator";
			Name2 = "High Robe of the Adjudicator";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5029;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 65;
			SpiritBonus = 2;
			IqBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Robe of Solomon)
*
***************************************************************/

namespace Server.Items
{
	public class RobeOfSolomon : Item
	{
		public RobeOfSolomon() : base()
		{
			Id = 3555;
			Resistance[0] = 39;
			Bonding = 1;
			SellPrice = 1032;
			AvailableClasses = 0x7FFF;
			Model = 16615;
			ObjectClass = 4;
			SubClass = 1;
			Level = 25;
			Name = "Robe of Solomon";
			Name2 = "Robe of Solomon";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5161;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 65;
			StaminaBonus = 7;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Fen Keeper Robe)
*
***************************************************************/

namespace Server.Items
{
	public class FenKeeperRobe : Item
	{
		public FenKeeperRobe() : base()
		{
			Id = 3558;
			Resistance[0] = 39;
			Bonding = 1;
			SellPrice = 1044;
			AvailableClasses = 0x7FFF;
			Model = 16528;
			ObjectClass = 4;
			SubClass = 1;
			Level = 25;
			Name = "Fen Keeper Robe";
			Name2 = "Fen Keeper Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5220;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 65;
			IqBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Vicar's Robe)
*
***************************************************************/

namespace Server.Items
{
	public class VicarsRobe : Item
	{
		public VicarsRobe() : base()
		{
			Id = 3569;
			Resistance[0] = 40;
			Bonding = 2;
			SellPrice = 1262;
			AvailableClasses = 0x7FFF;
			Model = 18122;
			ObjectClass = 4;
			SubClass = 1;
			Level = 26;
			ReqLevel = 21;
			Name = "Vicar's Robe";
			Name2 = "Vicar's Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6310;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 65;
			StaminaBonus = 4;
			IqBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Silver-thread Robe)
*
***************************************************************/

namespace Server.Items
{
	public class SilverThreadRobe : Item
	{
		public SilverThreadRobe() : base()
		{
			Id = 4035;
			Resistance[0] = 44;
			Bonding = 2;
			SellPrice = 1988;
			AvailableClasses = 0x7FFF;
			Model = 16643;
			ObjectClass = 4;
			SubClass = 1;
			Level = 31;
			ReqLevel = 26;
			Name = "Silver-thread Robe";
			Name2 = "Silver-thread Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 9944;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
			SpiritBonus = 11;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Nightsky Robe)
*
***************************************************************/

namespace Server.Items
{
	public class NightskyRobe : Item
	{
		public NightskyRobe() : base()
		{
			Id = 4038;
			Resistance[0] = 49;
			Bonding = 2;
			SellPrice = 3562;
			AvailableClasses = 0x7FFF;
			Model = 27557;
			ObjectClass = 4;
			SubClass = 1;
			Level = 37;
			ReqLevel = 32;
			Name = "Nightsky Robe";
			Name2 = "Nightsky Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 17810;
			InventoryType = InventoryTypes.Robe;
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
*				(Robe of Crystal Waters)
*
***************************************************************/

namespace Server.Items
{
	public class RobeOfCrystalWaters : Item
	{
		public RobeOfCrystalWaters() : base()
		{
			Id = 4120;
			Resistance[0] = 53;
			Bonding = 1;
			SellPrice = 4192;
			AvailableClasses = 0x7FFF;
			Model = 16695;
			ObjectClass = 4;
			SubClass = 1;
			Level = 40;
			Name = "Robe of Crystal Waters";
			Name2 = "Robe of Crystal Waters";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 20963;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
			StaminaBonus = 8;
			IqBonus = 9;
			SpiritBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Beastwalker Robe)
*
***************************************************************/

namespace Server.Items
{
	public class BeastwalkerRobe : Item
	{
		public BeastwalkerRobe() : base()
		{
			Id = 4476;
			Resistance[0] = 46;
			Bonding = 2;
			SellPrice = 2734;
			AvailableClasses = 0x7FFF;
			Model = 12650;
			ObjectClass = 4;
			SubClass = 1;
			Level = 34;
			ReqLevel = 29;
			Name = "Beastwalker Robe";
			Name2 = "Beastwalker Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 13672;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
			StaminaBonus = 6;
			AgilityBonus = 3;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Doomsayer's Robe)
*
***************************************************************/

namespace Server.Items
{
	public class DoomsayersRobe : Item
	{
		public DoomsayersRobe() : base()
		{
			Id = 4746;
			Resistance[0] = 53;
			Bonding = 1;
			SellPrice = 4324;
			AvailableClasses = 0x7FFF;
			Model = 12718;
			ObjectClass = 4;
			SubClass = 1;
			Level = 40;
			Name = "Doomsayer's Robe";
			Name2 = "Doomsayer's Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 21620;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
			IqBonus = 20;
			StaminaBonus = -10;
		}
	}
}


/**************************************************************
*
*				(Solstice Robe)
*
***************************************************************/

namespace Server.Items
{
	public class SolsticeRobe : Item
	{
		public SolsticeRobe() : base()
		{
			Id = 4782;
			Resistance[0] = 32;
			Bonding = 2;
			SellPrice = 415;
			AvailableClasses = 0x7FFF;
			Model = 16812;
			ObjectClass = 4;
			SubClass = 1;
			Level = 18;
			ReqLevel = 13;
			Name = "Solstice Robe";
			Name2 = "Solstice Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2076;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 55;
			StaminaBonus = 1;
			SpiritBonus = 1;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Mage Dragon Robe)
*
***************************************************************/

namespace Server.Items
{
	public class MageDragonRobe : Item
	{
		public MageDragonRobe() : base()
		{
			Id = 4989;
			Resistance[0] = 105;
			Bonding = 1;
			SellPrice = 9058;
			AvailableClasses = 0x7FFF;
			Model = 16673;
			ObjectClass = 4;
			SubClass = 1;
			Level = 50;
			Name = "Mage Dragon Robe";
			Name2 = "Mage Dragon Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 45292;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			IqBonus = 25;
			StrBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Dalaran Wizard's Robe)
*
***************************************************************/

namespace Server.Items
{
	public class DalaranWizardsRobe : Item
	{
		public DalaranWizardsRobe() : base()
		{
			Id = 5110;
			Resistance[0] = 30;
			SellPrice = 257;
			AvailableClasses = 0x7FFF;
			Model = 12656;
			ObjectClass = 4;
			SubClass = 1;
			Level = 18;
			ReqLevel = 13;
			Name = "Dalaran Wizard's Robe";
			Name2 = "Dalaran Wizard's Robe";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1289;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Lesser Wizard's Robe)
*
***************************************************************/

namespace Server.Items
{
	public class LesserWizardsRobe : Item
	{
		public LesserWizardsRobe() : base()
		{
			Id = 5766;
			Resistance[0] = 41;
			Bonding = 2;
			SellPrice = 1338;
			AvailableClasses = 0x7FFF;
			Model = 12397;
			ObjectClass = 4;
			SubClass = 1;
			Level = 27;
			ReqLevel = 22;
			Name = "Lesser Wizard's Robe";
			Name2 = "Lesser Wizard's Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6691;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
			SpiritBonus = 8;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Violet Robes)
*
***************************************************************/

namespace Server.Items
{
	public class VioletRobes : Item
	{
		public VioletRobes() : base()
		{
			Id = 5767;
			Resistance[0] = 17;
			SellPrice = 44;
			AvailableClasses = 0x7FFF;
			Model = 16611;
			ObjectClass = 4;
			SubClass = 1;
			Level = 9;
			ReqLevel = 4;
			Name = "Violet Robes";
			Name2 = "Violet Robes";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 221;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Robes of Arcana)
*
***************************************************************/

namespace Server.Items
{
	public class RobesOfArcana : Item
	{
		public RobesOfArcana() : base()
		{
			Id = 5770;
			Resistance[0] = 43;
			Bonding = 2;
			SellPrice = 1807;
			AvailableClasses = 0x7FFF;
			Model = 12695;
			ObjectClass = 4;
			SubClass = 1;
			Level = 30;
			ReqLevel = 25;
			Name = "Robes of Arcana";
			Name2 = "Robes of Arcana";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 9037;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
			SpiritBonus = 8;
			IqBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Robes of Antiquity)
*
***************************************************************/

namespace Server.Items
{
	public class RobesOfAntiquity : Item
	{
		public RobesOfAntiquity() : base()
		{
			Id = 5812;
			Resistance[0] = 39;
			Bonding = 1;
			SellPrice = 1129;
			AvailableClasses = 0x7FFF;
			Model = 12694;
			ObjectClass = 4;
			SubClass = 1;
			Level = 25;
			Name = "Robes of Antiquity";
			Name2 = "Robes of Antiquity";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5645;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 65;
			SpiritBonus = 2;
			IqBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Neophyte's Robe)
*
***************************************************************/

namespace Server.Items
{
	public class NeophytesRobe : Item
	{
		public NeophytesRobe() : base()
		{
			Id = 6098;
			Resistance[0] = 3;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 12679;
			ObjectClass = 4;
			SubClass = 1;
			Level = 1;
			ReqLevel = 1;
			Name = "Neophyte's Robe";
			Name2 = "Neophyte's Robe";
			AvailableRaces = 0x1FF;
			BuyPrice = 4;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Apprentice's Robe)
*
***************************************************************/

namespace Server.Items
{
	public class DwarfApprenticesRobe : Item
	{
		public DwarfApprenticesRobe() : base()
		{
			Id = 6116;
			Resistance[0] = 3;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 12648;
			ObjectClass = 4;
			SubClass = 1;
			Level = 1;
			ReqLevel = 1;
			Name = "Apprentice's Robe";
			Name2 = "Apprentice's Robe";
			AvailableRaces = 0x1FF;
			BuyPrice = 4;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Neophyte's Robe)
*
***************************************************************/

namespace Server.Items
{
	public class NightElfNeophytesRobe : Item
	{
		public NightElfNeophytesRobe() : base()
		{
			Id = 6119;
			Resistance[0] = 3;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 12681;
			ObjectClass = 4;
			SubClass = 1;
			Level = 1;
			ReqLevel = 1;
			Name = "Neophyte's Robe";
			Name2 = "Neophyte's Robe";
			AvailableRaces = 0x1FF;
			BuyPrice = 4;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Novice's Robe)
*
***************************************************************/

namespace Server.Items
{
	public class NovicesRobe : Item
	{
		public NovicesRobe() : base()
		{
			Id = 6123;
			Resistance[0] = 3;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 12683;
			ObjectClass = 4;
			SubClass = 1;
			Level = 1;
			ReqLevel = 1;
			Name = "Novice's Robe";
			Name2 = "Novice's Robe";
			AvailableRaces = 0x1FF;
			BuyPrice = 4;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Acolyte's Robe)
*
***************************************************************/

namespace Server.Items
{
	public class HordeAcolytesRobe : Item
	{
		public HordeAcolytesRobe() : base()
		{
			Id = 6129;
			Resistance[0] = 3;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 12646;
			ObjectClass = 4;
			SubClass = 1;
			Level = 1;
			ReqLevel = 1;
			Name = "Acolyte's Robe";
			Name2 = "Acolyte's Robe";
			AvailableRaces = 0x1FF;
			BuyPrice = 5;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Novice's Robe)
*
***************************************************************/

namespace Server.Items
{
	public class TaurenNovicesRobe : Item
	{
		public TaurenNovicesRobe() : base()
		{
			Id = 6139;
			Resistance[0] = 3;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 12684;
			ObjectClass = 4;
			SubClass = 1;
			Level = 1;
			ReqLevel = 1;
			Name = "Novice's Robe";
			Name2 = "Novice's Robe";
			AvailableRaces = 0x1FF;
			BuyPrice = 4;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Apprentice's Robe)
*
***************************************************************/

namespace Server.Items
{
	public class HordeApprenticesRobe : Item
	{
		public HordeApprenticesRobe() : base()
		{
			Id = 6140;
			Resistance[0] = 3;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 12649;
			ObjectClass = 4;
			SubClass = 1;
			Level = 1;
			ReqLevel = 1;
			Name = "Apprentice's Robe";
			Name2 = "Apprentice's Robe";
			AvailableRaces = 0x1FF;
			BuyPrice = 4;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Neophyte's Robe)
*
***************************************************************/

namespace Server.Items
{
	public class HordeNeophytesRobe : Item
	{
		public HordeNeophytesRobe() : base()
		{
			Id = 6144;
			Resistance[0] = 3;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 12680;
			ObjectClass = 4;
			SubClass = 1;
			Level = 1;
			ReqLevel = 1;
			Name = "Neophyte's Robe";
			Name2 = "Neophyte's Robe";
			AvailableRaces = 0x1FF;
			BuyPrice = 5;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Bloody Apron)
*
***************************************************************/

namespace Server.Items
{
	public class BloodyApron : Item
	{
		public BloodyApron() : base()
		{
			Id = 6226;
			Resistance[0] = 37;
			Bonding = 1;
			SellPrice = 890;
			AvailableClasses = 0x7FFF;
			Model = 12652;
			ObjectClass = 4;
			SubClass = 1;
			Level = 23;
			ReqLevel = 18;
			Name = "Bloody Apron";
			Name2 = "Bloody Apron";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4452;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 65;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Brown Linen Robe)
*
***************************************************************/

namespace Server.Items
{
	public class BrownLinenRobe : Item
	{
		public BrownLinenRobe() : base()
		{
			Id = 6238;
			Resistance[0] = 19;
			Bonding = 2;
			SellPrice = 98;
			AvailableClasses = 0x7FFF;
			Model = 12389;
			ObjectClass = 4;
			SubClass = 1;
			Level = 10;
			ReqLevel = 5;
			Name = "Brown Linen Robe";
			Name2 = "Brown Linen Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 491;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			IqBonus = 1;
		}
	}
}


/**************************************************************
*
*				(White Linen Robe)
*
***************************************************************/

namespace Server.Items
{
	public class WhiteLinenRobe : Item
	{
		public WhiteLinenRobe() : base()
		{
			Id = 6241;
			Resistance[0] = 19;
			Bonding = 2;
			SellPrice = 99;
			AvailableClasses = 0x7FFF;
			Model = 17123;
			ObjectClass = 4;
			SubClass = 1;
			Level = 10;
			ReqLevel = 5;
			Name = "White Linen Robe";
			Name2 = "White Linen Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 496;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			SpiritBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Blue Linen Robe)
*
***************************************************************/

namespace Server.Items
{
	public class BlueLinenRobe : Item
	{
		public BlueLinenRobe() : base()
		{
			Id = 6242;
			Resistance[0] = 26;
			Bonding = 2;
			SellPrice = 243;
			AvailableClasses = 0x7FFF;
			Model = 12386;
			ObjectClass = 4;
			SubClass = 1;
			Level = 14;
			ReqLevel = 9;
			Name = "Blue Linen Robe";
			Name2 = "Blue Linen Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1217;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 50;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Blue Overalls)
*
***************************************************************/

namespace Server.Items
{
	public class BlueOveralls : Item
	{
		public BlueOveralls() : base()
		{
			Id = 6263;
			Resistance[0] = 34;
			Bonding = 2;
			SellPrice = 589;
			AvailableClasses = 0x7FFF;
			Model = 11182;
			ObjectClass = 4;
			SubClass = 1;
			Level = 20;
			ReqLevel = 15;
			Name = "Blue Overalls";
			Name2 = "Blue Overalls";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2947;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 60;
			StrBonus = 4;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Greater Adept's Robe)
*
***************************************************************/

namespace Server.Items
{
	public class GreaterAdeptsRobe : Item
	{
		public GreaterAdeptsRobe() : base()
		{
			Id = 6264;
			Resistance[0] = 37;
			Bonding = 2;
			SellPrice = 884;
			AvailableClasses = 0x7FFF;
			Model = 12716;
			ObjectClass = 4;
			SubClass = 1;
			Level = 23;
			ReqLevel = 18;
			Name = "Greater Adept's Robe";
			Name2 = "Greater Adept's Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4420;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 65;
			StaminaBonus = 1;
			SpiritBonus = 2;
			IqBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Robes of Arugal)
*
***************************************************************/

namespace Server.Items
{
	public class RobesOfArugal : Item
	{
		public RobesOfArugal() : base()
		{
			Id = 6324;
			Resistance[0] = 46;
			Bonding = 1;
			SellPrice = 1892;
			AvailableClasses = 0x7FFF;
			Model = 12696;
			ObjectClass = 4;
			SubClass = 1;
			Level = 29;
			ReqLevel = 24;
			Name = "Robes of Arugal";
			Name2 = "Robes of Arugal";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 9463;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 80;
			IqBonus = 10;
			SpiritBonus = 9;
			StaminaBonus = 5;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Aurora Robe)
*
***************************************************************/

namespace Server.Items
{
	public class AuroraRobe : Item
	{
		public AuroraRobe() : base()
		{
			Id = 6415;
			Resistance[0] = 54;
			Bonding = 2;
			SellPrice = 4565;
			AvailableClasses = 0x7FFF;
			Model = 12653;
			ObjectClass = 4;
			SubClass = 1;
			Level = 41;
			ReqLevel = 36;
			Name = "Aurora Robe";
			Name2 = "Aurora Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 22825;
			InventoryType = InventoryTypes.Robe;
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
*				(Mistscape Robe)
*
***************************************************************/

namespace Server.Items
{
	public class MistscapeRobe : Item
	{
		public MistscapeRobe() : base()
		{
			Id = 6427;
			Resistance[0] = 60;
			Bonding = 2;
			SellPrice = 7016;
			AvailableClasses = 0x7FFF;
			Model = 12676;
			ObjectClass = 4;
			SubClass = 1;
			Level = 46;
			ReqLevel = 41;
			Name = "Mistscape Robe";
			Name2 = "Mistscape Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 35081;
			InventoryType = InventoryTypes.Robe;
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
*				(Robe of the Moccasin)
*
***************************************************************/

namespace Server.Items
{
	public class RobeOfTheMoccasin : Item
	{
		public RobeOfTheMoccasin() : base()
		{
			Id = 6465;
			Resistance[0] = 36;
			Bonding = 1;
			SellPrice = 768;
			AvailableClasses = 0x7FFF;
			Model = 12693;
			ObjectClass = 4;
			SubClass = 1;
			Level = 22;
			ReqLevel = 17;
			Name = "Robe of the Moccasin";
			Name2 = "Robe of the Moccasin";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3843;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 60;
			StrBonus = 2;
			StaminaBonus = 2;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Harlequin Robes)
*
***************************************************************/

namespace Server.Items
{
	public class HarlequinRobes : Item
	{
		public HarlequinRobes() : base()
		{
			Id = 6503;
			Resistance[0] = 36;
			Bonding = 1;
			SellPrice = 762;
			AvailableClasses = 0x7FFF;
			Model = 12670;
			ObjectClass = 4;
			SubClass = 1;
			Level = 22;
			Name = "Harlequin Robes";
			Name2 = "Harlequin Robes";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3814;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 60;
			SpiritBonus = 2;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Journeyman's Robe)
*
***************************************************************/

namespace Server.Items
{
	public class JourneymansRobe : Item
	{
		public JourneymansRobe() : base()
		{
			Id = 6511;
			Resistance[0] = 21;
			Bonding = 2;
			SellPrice = 121;
			AvailableClasses = 0x7FFF;
			Model = 16698;
			ObjectClass = 4;
			SubClass = 1;
			Level = 11;
			ReqLevel = 6;
			Name = "Journeyman's Robe";
			Name2 = "Journeyman's Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 608;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			SpiritBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Disciple's Robe)
*
***************************************************************/

namespace Server.Items
{
	public class DisciplesRobe : Item
	{
		public DisciplesRobe() : base()
		{
			Id = 6512;
			Resistance[0] = 25;
			Bonding = 2;
			SellPrice = 191;
			AvailableClasses = 0x7FFF;
			Model = 16813;
			ObjectClass = 4;
			SubClass = 1;
			Level = 13;
			ReqLevel = 8;
			Name = "Disciple's Robe";
			Name2 = "Disciple's Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 455;
			BuyPrice = 955;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Ancestral Robe)
*
***************************************************************/

namespace Server.Items
{
	public class AncestralRobe : Item
	{
		public AncestralRobe() : base()
		{
			Id = 6527;
			Resistance[0] = 25;
			Bonding = 2;
			SellPrice = 187;
			AvailableClasses = 0x7FFF;
			Model = 12422;
			ObjectClass = 4;
			SubClass = 1;
			Level = 13;
			ReqLevel = 8;
			Name = "Ancestral Robe";
			Name2 = "Ancestral Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 937;
			InventoryType = InventoryTypes.Robe;
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
*				(Spellbinder Robe)
*
***************************************************************/

namespace Server.Items
{
	public class SpellbinderRobe : Item
	{
		public SpellbinderRobe() : base()
		{
			Id = 6528;
			Resistance[0] = 30;
			Bonding = 2;
			SellPrice = 358;
			AvailableClasses = 0x7FFF;
			Model = 16567;
			ObjectClass = 4;
			SubClass = 1;
			Level = 17;
			ReqLevel = 12;
			Name = "Spellbinder Robe";
			Name2 = "Spellbinder Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1792;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 55;
			IqBonus = 4;
			SpiritBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Barbaric Cloth Robe)
*
***************************************************************/

namespace Server.Items
{
	public class BarbaricClothRobe : Item
	{
		public BarbaricClothRobe() : base()
		{
			Id = 6531;
			Resistance[0] = 32;
			Bonding = 2;
			SellPrice = 417;
			AvailableClasses = 0x7FFF;
			Model = 19110;
			ObjectClass = 4;
			SubClass = 1;
			Level = 18;
			ReqLevel = 13;
			Name = "Barbaric Cloth Robe";
			Name2 = "Barbaric Cloth Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2085;
			InventoryType = InventoryTypes.Robe;
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
*				(Willow Robe)
*
***************************************************************/

namespace Server.Items
{
	public class WillowRobe : Item
	{
		public WillowRobe() : base()
		{
			Id = 6538;
			Resistance[0] = 33;
			Bonding = 2;
			SellPrice = 492;
			AvailableClasses = 0x7FFF;
			Model = 16522;
			ObjectClass = 4;
			SubClass = 1;
			Level = 19;
			ReqLevel = 14;
			Name = "Willow Robe";
			Name2 = "Willow Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 457;
			BuyPrice = 2461;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Shimmering Robe)
*
***************************************************************/

namespace Server.Items
{
	public class ShimmeringRobe : Item
	{
		public ShimmeringRobe() : base()
		{
			Id = 6569;
			Resistance[0] = 39;
			Bonding = 2;
			SellPrice = 1044;
			AvailableClasses = 0x7FFF;
			Model = 18120;
			ObjectClass = 4;
			SubClass = 1;
			Level = 25;
			ReqLevel = 20;
			Name = "Shimmering Robe";
			Name2 = "Shimmering Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 459;
			BuyPrice = 5222;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Sage's Robe)
*
***************************************************************/

namespace Server.Items
{
	public class SagesRobe : Item
	{
		public SagesRobe() : base()
		{
			Id = 6610;
			Resistance[0] = 44;
			Bonding = 2;
			SellPrice = 2156;
			AvailableClasses = 0x7FFF;
			Model = 16878;
			ObjectClass = 4;
			SubClass = 1;
			Level = 32;
			ReqLevel = 27;
			Name = "Sage's Robe";
			Name2 = "Sage's Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 461;
			BuyPrice = 10780;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Death Speaker Robes)
*
***************************************************************/

namespace Server.Items
{
	public class DeathSpeakerRobes : Item
	{
		public DeathSpeakerRobes() : base()
		{
			Id = 6682;
			Resistance[0] = 44;
			Bonding = 1;
			SellPrice = 1900;
			AvailableClasses = 0x7FFF;
			Model = 12858;
			ObjectClass = 4;
			SubClass = 1;
			Level = 31;
			ReqLevel = 26;
			Name = "Death Speaker Robes";
			Name2 = "Death Speaker Robes";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 9504;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
			StaminaBonus = 3;
			SpiritBonus = 8;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(White Woolen Dress)
*
***************************************************************/

namespace Server.Items
{
	public class WhiteWoolenDress : Item
	{
		public WhiteWoolenDress() : base()
		{
			Id = 6787;
			Resistance[0] = 34;
			SellPrice = 466;
			AvailableClasses = 0x7FFF;
			Model = 13046;
			ObjectClass = 4;
			SubClass = 1;
			Level = 22;
			ReqLevel = 17;
			Name = "White Woolen Dress";
			Name2 = "White Woolen Dress";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2331;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Baroque Apron)
*
***************************************************************/

namespace Server.Items
{
	public class BaroqueApron : Item
	{
		public BaroqueApron() : base()
		{
			Id = 6801;
			Resistance[0] = 53;
			Bonding = 1;
			SellPrice = 4456;
			AvailableClasses = 0x7FFF;
			Model = 13077;
			ObjectClass = 4;
			SubClass = 1;
			Level = 40;
			Name = "Baroque Apron";
			Name2 = "Baroque Apron";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 22282;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
			StrBonus = 6;
			StaminaBonus = 6;
			IqBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Enchanted Gold Bloodrobe)
*
***************************************************************/

namespace Server.Items
{
	public class EnchantedGoldBloodrobe : Item
	{
		public EnchantedGoldBloodrobe() : base()
		{
			Id = 6900;
			Resistance[0] = 55;
			Bonding = 1;
			SellPrice = 4685;
			AvailableClasses = 0x100;
			Model = 13337;
			ObjectClass = 4;
			SubClass = 1;
			Level = 38;
			Name = "Enchanted Gold Bloodrobe";
			Name2 = "Enchanted Gold Bloodrobe";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 23427;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 80;
			StaminaBonus = 10;
			SpiritBonus = 17;
		}
	}
}


/**************************************************************
*
*				(Robe of Power)
*
***************************************************************/

namespace Server.Items
{
	public class RobeOfPower : Item
	{
		public RobeOfPower() : base()
		{
			Id = 7054;
			Resistance[0] = 55;
			Bonding = 1;
			SellPrice = 4700;
			AvailableClasses = 0x7FFF;
			Model = 17133;
			ObjectClass = 4;
			SubClass = 1;
			Level = 38;
			ReqLevel = 33;
			Name = "Robe of Power";
			Name2 = "Robe of Power";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 23504;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 80;
			SetSpell( 9343 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 12;
			IqBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Crimson Silk Robe)
*
***************************************************************/

namespace Server.Items
{
	public class CrimsonSilkRobe : Item
	{
		public CrimsonSilkRobe() : base()
		{
			Id = 7063;
			Resistance[0] = 54;
			Bonding = 2;
			SellPrice = 4741;
			AvailableClasses = 0x7FFF;
			Model = 12675;
			ObjectClass = 4;
			SubClass = 1;
			Level = 41;
			ReqLevel = 36;
			Name = "Crimson Silk Robe";
			Name2 = "Crimson Silk Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 23707;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
			SpiritBonus = 15;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Efflorescent Robe)
*
***************************************************************/

namespace Server.Items
{
	public class EfflorescentRobe : Item
	{
		public EfflorescentRobe() : base()
		{
			Id = 7334;
			Resistance[0] = 41;
			Bonding = 1;
			SellPrice = 1544;
			AvailableClasses = 0x7FFF;
			Model = 16523;
			ObjectClass = 4;
			SubClass = 1;
			Level = 28;
			Name = "Efflorescent Robe";
			Name2 = "Efflorescent Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7721;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
			StaminaBonus = 9;
			SpiritBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Elder's Robe)
*
***************************************************************/

namespace Server.Items
{
	public class EldersRobe : Item
	{
		public EldersRobe() : base()
		{
			Id = 7369;
			Resistance[0] = 46;
			Bonding = 2;
			SellPrice = 2955;
			AvailableClasses = 0x7FFF;
			Model = 16607;
			ObjectClass = 4;
			SubClass = 1;
			Level = 35;
			ReqLevel = 30;
			Name = "Elder's Robe";
			Name2 = "Elder's Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 462;
			BuyPrice = 14777;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Twilight Robe)
*
***************************************************************/

namespace Server.Items
{
	public class TwilightRobe : Item
	{
		public TwilightRobe() : base()
		{
			Id = 7430;
			Resistance[0] = 53;
			Bonding = 2;
			SellPrice = 4194;
			AvailableClasses = 0x7FFF;
			Model = 14990;
			ObjectClass = 4;
			SubClass = 1;
			Level = 40;
			ReqLevel = 35;
			Name = "Twilight Robe";
			Name2 = "Twilight Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 464;
			BuyPrice = 20974;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Regal Robe)
*
***************************************************************/

namespace Server.Items
{
	public class RegalRobe : Item
	{
		public RegalRobe() : base()
		{
			Id = 7468;
			Resistance[0] = 59;
			Bonding = 2;
			SellPrice = 6763;
			AvailableClasses = 0x7FFF;
			Model = 15005;
			ObjectClass = 4;
			SubClass = 1;
			Level = 45;
			ReqLevel = 40;
			Name = "Regal Robe";
			Name2 = "Regal Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 465;
			BuyPrice = 33815;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Manaweave Robe)
*
***************************************************************/

namespace Server.Items
{
	public class ManaweaveRobe : Item
	{
		public ManaweaveRobe() : base()
		{
			Id = 7509;
			Resistance[0] = 28;
			Bonding = 1;
			SellPrice = 275;
			AvailableClasses = 0x80;
			Model = 22958;
			ObjectClass = 4;
			SubClass = 1;
			Level = 15;
			Name = "Manaweave Robe";
			Name2 = "Manaweave Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1376;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 50;
			SpiritBonus = 2;
			IqBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Spellfire Robes)
*
***************************************************************/

namespace Server.Items
{
	public class SpellfireRobes : Item
	{
		public SpellfireRobes() : base()
		{
			Id = 7510;
			Resistance[0] = 28;
			Bonding = 1;
			SellPrice = 276;
			AvailableClasses = 0x80;
			Model = 15201;
			ObjectClass = 4;
			SubClass = 1;
			Level = 15;
			Name = "Spellfire Robes";
			Name2 = "Spellfire Robes";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1381;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 50;
			SpiritBonus = 2;
			IqBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Astral Knot Robe)
*
***************************************************************/

namespace Server.Items
{
	public class AstralKnotRobe : Item
	{
		public AstralKnotRobe() : base()
		{
			Id = 7511;
			Resistance[0] = 40;
			Bonding = 1;
			SellPrice = 1203;
			AvailableClasses = 0x80;
			Model = 15223;
			ObjectClass = 4;
			SubClass = 1;
			Level = 26;
			Name = "Astral Knot Robe";
			Name2 = "Astral Knot Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6016;
			InventoryType = InventoryTypes.Robe;
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
*				(Nether-lace Robe)
*
***************************************************************/

namespace Server.Items
{
	public class NetherLaceRobe : Item
	{
		public NetherLaceRobe() : base()
		{
			Id = 7512;
			Resistance[0] = 40;
			Bonding = 1;
			SellPrice = 1207;
			AvailableClasses = 0x80;
			Model = 15232;
			ObjectClass = 4;
			SubClass = 1;
			Level = 26;
			Name = "Nether-lace Robe";
			Name2 = "Nether-lace Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6039;
			InventoryType = InventoryTypes.Robe;
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
*				(Gossamer Robe)
*
***************************************************************/

namespace Server.Items
{
	public class GossamerRobe : Item
	{
		public GossamerRobe() : base()
		{
			Id = 7518;
			Resistance[0] = 65;
			Bonding = 2;
			SellPrice = 9406;
			AvailableClasses = 0x7FFF;
			Model = 15400;
			ObjectClass = 4;
			SubClass = 1;
			Level = 50;
			ReqLevel = 45;
			Name = "Gossamer Robe";
			Name2 = "Gossamer Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 467;
			BuyPrice = 47031;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Robe of Doan)
*
***************************************************************/

namespace Server.Items
{
	public class RobeOfDoan : Item
	{
		public RobeOfDoan() : base()
		{
			Id = 7711;
			Resistance[0] = 50;
			Bonding = 1;
			SellPrice = 1171;
			AvailableClasses = 0x7FFF;
			Model = 12673;
			ObjectClass = 4;
			SubClass = 1;
			Level = 38;
			ReqLevel = 33;
			Name = "Robe of Doan";
			Name2 = "Robe of Doan";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5855;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
			StaminaBonus = 4;
			IqBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Beguiler Robes)
*
***************************************************************/

namespace Server.Items
{
	public class BeguilerRobes : Item
	{
		public BeguilerRobes() : base()
		{
			Id = 7728;
			Resistance[0] = 50;
			Bonding = 2;
			SellPrice = 3223;
			AvailableClasses = 0x7FFF;
			Model = 19109;
			ObjectClass = 4;
			SubClass = 1;
			Level = 34;
			ReqLevel = 29;
			Name = "Beguiler Robes";
			Name2 = "Beguiler Robes";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 16118;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 80;
			IqBonus = 8;
			StaminaBonus = 7;
			SpiritBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Hibernal Robe)
*
***************************************************************/

namespace Server.Items
{
	public class HibernalRobe : Item
	{
		public HibernalRobe() : base()
		{
			Id = 8113;
			Resistance[0] = 66;
			Bonding = 2;
			SellPrice = 9694;
			AvailableClasses = 0x7FFF;
			Model = 19901;
			ObjectClass = 4;
			SubClass = 1;
			Level = 51;
			ReqLevel = 46;
			Name = "Hibernal Robe";
			Name2 = "Hibernal Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 48473;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
			StaminaBonus = 4;
			SpiritBonus = 20;
		}
	}
}


/**************************************************************
*
*				(Imperial Red Robe)
*
***************************************************************/

namespace Server.Items
{
	public class ImperialRedRobe : Item
	{
		public ImperialRedRobe() : base()
		{
			Id = 8252;
			Resistance[0] = 73;
			Bonding = 2;
			SellPrice = 13622;
			AvailableClasses = 0x7FFF;
			Model = 17236;
			ObjectClass = 4;
			SubClass = 1;
			Level = 56;
			ReqLevel = 51;
			Name = "Imperial Red Robe";
			Name2 = "Imperial Red Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 68114;
			InventoryType = InventoryTypes.Robe;
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
*				(Arcane Robe)
*
***************************************************************/

namespace Server.Items
{
	public class ArcaneRobe : Item
	{
		public ArcaneRobe() : base()
		{
			Id = 8290;
			Resistance[0] = 79;
			Bonding = 2;
			SellPrice = 17585;
			AvailableClasses = 0x7FFF;
			Model = 17276;
			ObjectClass = 4;
			SubClass = 1;
			Level = 61;
			ReqLevel = 56;
			Name = "Arcane Robe";
			Name2 = "Arcane Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 87927;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
			StaminaBonus = 7;
			IqBonus = 23;
		}
	}
}


/**************************************************************
*
*				(Mechbuilder's Overalls)
*
***************************************************************/

namespace Server.Items
{
	public class MechbuildersOveralls : Item
	{
		public MechbuildersOveralls() : base()
		{
			Id = 9508;
			Resistance[6] = 5;
			Resistance[0] = 48;
			Bonding = 2;
			SellPrice = 2352;
			AvailableClasses = 0x7FFF;
			Model = 18428;
			ObjectClass = 4;
			SubClass = 1;
			Level = 31;
			ReqLevel = 26;
			Name = "Mechbuilder's Overalls";
			Name2 = "Mechbuilder's Overalls";
			Quality = 3;
			AvailableRaces = 0x1FF;
			SkillRank = 75;
			Skill = 202;
			BuyPrice = 11762;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 80;
			SpiritBonus = 15;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Sleeping Robes)
*
***************************************************************/

namespace Server.Items
{
	public class SleepingRobes : Item
	{
		public SleepingRobes() : base()
		{
			Id = 9598;
			Resistance[0] = 19;
			Bonding = 1;
			SellPrice = 94;
			AvailableClasses = 0x7FFF;
			Model = 19011;
			ObjectClass = 4;
			SubClass = 1;
			Level = 10;
			Name = "Sleeping Robes";
			Name2 = "Sleeping Robes";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 473;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Civinad Robes)
*
***************************************************************/

namespace Server.Items
{
	public class CivinadRobes : Item
	{
		public CivinadRobes() : base()
		{
			Id = 9623;
			Resistance[0] = 54;
			Bonding = 1;
			SellPrice = 4198;
			AvailableClasses = 0x7FFF;
			Model = 18883;
			ObjectClass = 4;
			SubClass = 1;
			Level = 37;
			Name = "Civinad Robes";
			Name2 = "Civinad Robes";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 20992;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 80;
			IqBonus = 18;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Royal Highmark Vestments)
*
***************************************************************/

namespace Server.Items
{
	public class RoyalHighmarkVestments : Item
	{
		public RoyalHighmarkVestments() : base()
		{
			Id = 9649;
			Resistance[0] = 71;
			Bonding = 1;
			SellPrice = 13229;
			AvailableClasses = 0x7FFF;
			Model = 28294;
			ObjectClass = 4;
			SubClass = 1;
			Level = 55;
			Name = "Royal Highmark Vestments";
			Name2 = "Royal Highmark Vestments";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 66146;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
			StaminaBonus = 3;
			SpiritBonus = 3;
			IqBonus = 16;
		}
	}
}


/**************************************************************
*
*				(Simple Robe)
*
***************************************************************/

namespace Server.Items
{
	public class SimpleRobe : Item
	{
		public SimpleRobe() : base()
		{
			Id = 9748;
			Resistance[0] = 28;
			Bonding = 2;
			SellPrice = 274;
			AvailableClasses = 0x7FFF;
			Model = 18883;
			ObjectClass = 4;
			SubClass = 1;
			Level = 15;
			ReqLevel = 10;
			Name = "Simple Robe";
			Name2 = "Simple Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 455;
			BuyPrice = 1371;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Greenweave Robe)
*
***************************************************************/

namespace Server.Items
{
	public class GreenweaveRobe : Item
	{
		public GreenweaveRobe() : base()
		{
			Id = 9773;
			Resistance[0] = 41;
			Bonding = 2;
			SellPrice = 1369;
			AvailableClasses = 0x7FFF;
			Model = 25944;
			ObjectClass = 4;
			SubClass = 1;
			Level = 27;
			ReqLevel = 22;
			Name = "Greenweave Robe";
			Name2 = "Greenweave Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 459;
			BuyPrice = 6847;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Ivycloth Robe)
*
***************************************************************/

namespace Server.Items
{
	public class IvyclothRobe : Item
	{
		public IvyclothRobe() : base()
		{
			Id = 9798;
			Resistance[0] = 42;
			Bonding = 2;
			SellPrice = 1686;
			AvailableClasses = 0x7FFF;
			Model = 18120;
			ObjectClass = 4;
			SubClass = 1;
			Level = 29;
			ReqLevel = 24;
			Name = "Ivycloth Robe";
			Name2 = "Ivycloth Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 460;
			BuyPrice = 8434;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Durable Robe)
*
***************************************************************/

namespace Server.Items
{
	public class DurableRobe : Item
	{
		public DurableRobe() : base()
		{
			Id = 9826;
			Resistance[0] = 46;
			Bonding = 2;
			SellPrice = 2600;
			AvailableClasses = 0x7FFF;
			Model = 27856;
			ObjectClass = 4;
			SubClass = 1;
			Level = 34;
			ReqLevel = 29;
			Name = "Durable Robe";
			Name2 = "Durable Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 462;
			BuyPrice = 13001;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Conjurer's Robe)
*
***************************************************************/

namespace Server.Items
{
	public class ConjurersRobe : Item
	{
		public ConjurersRobe() : base()
		{
			Id = 9852;
			Resistance[0] = 50;
			Bonding = 2;
			SellPrice = 3820;
			AvailableClasses = 0x7FFF;
			Model = 28425;
			ObjectClass = 4;
			SubClass = 1;
			Level = 38;
			ReqLevel = 33;
			Name = "Conjurer's Robe";
			Name2 = "Conjurer's Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 463;
			BuyPrice = 19102;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Sorcerer Robe)
*
***************************************************************/

namespace Server.Items
{
	public class SorcererRobe : Item
	{
		public SorcererRobe() : base()
		{
			Id = 9884;
			Resistance[0] = 57;
			Bonding = 2;
			SellPrice = 5448;
			AvailableClasses = 0x7FFF;
			Model = 28074;
			ObjectClass = 4;
			SubClass = 1;
			Level = 43;
			ReqLevel = 38;
			Name = "Sorcerer Robe";
			Name2 = "Sorcerer Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 465;
			BuyPrice = 27244;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Royal Gown)
*
***************************************************************/

namespace Server.Items
{
	public class RoyalGown : Item
	{
		public RoyalGown() : base()
		{
			Id = 9913;
			Resistance[0] = 63;
			Bonding = 2;
			SellPrice = 8490;
			AvailableClasses = 0x7FFF;
			Model = 28417;
			ObjectClass = 4;
			SubClass = 1;
			Level = 48;
			ReqLevel = 43;
			Name = "Royal Gown";
			Name2 = "Royal Gown";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 466;
			BuyPrice = 42454;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Abjurer's Robe)
*
***************************************************************/

namespace Server.Items
{
	public class AbjurersRobe : Item
	{
		public AbjurersRobe() : base()
		{
			Id = 9943;
			Resistance[0] = 69;
			Bonding = 2;
			SellPrice = 11271;
			AvailableClasses = 0x7FFF;
			Model = 27800;
			ObjectClass = 4;
			SubClass = 1;
			Level = 53;
			ReqLevel = 48;
			Name = "Abjurer's Robe";
			Name2 = "Abjurer's Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 468;
			BuyPrice = 56358;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Black Mageweave Robe)
*
***************************************************************/

namespace Server.Items
{
	public class BlackMageweaveRobe : Item
	{
		public BlackMageweaveRobe() : base()
		{
			Id = 10001;
			Resistance[0] = 55;
			Bonding = 2;
			SellPrice = 5257;
			AvailableClasses = 0x7FFF;
			Model = 19141;
			ObjectClass = 4;
			SubClass = 1;
			Level = 42;
			ReqLevel = 37;
			Name = "Black Mageweave Robe";
			Name2 = "Black Mageweave Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 26285;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
			IqBonus = 14;
			SpiritBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Shadoweave Robe)
*
***************************************************************/

namespace Server.Items
{
	public class ShadoweaveRobe : Item
	{
		public ShadoweaveRobe() : base()
		{
			Id = 10004;
			Resistance[0] = 57;
			Bonding = 2;
			SellPrice = 5738;
			AvailableClasses = 0x7FFF;
			Model = 24951;
			ObjectClass = 4;
			SubClass = 1;
			Level = 43;
			ReqLevel = 38;
			Name = "Shadoweave Robe";
			Name2 = "Shadoweave Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 28694;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
			SetSpell( 9328 , 1 , 0 , -1 , 0 , -1 );
			IqBonus = 7;
		}
	}
}


/**************************************************************
*
*				(White Wedding Dress)
*
***************************************************************/

namespace Server.Items
{
	public class WhiteWeddingDress : Item
	{
		public WhiteWeddingDress() : base()
		{
			Id = 10040;
			Resistance[0] = 44;
			SellPrice = 1767;
			AvailableClasses = 0x7FFF;
			Model = 13119;
			ObjectClass = 4;
			SubClass = 1;
			Level = 35;
			ReqLevel = 30;
			Name = "White Wedding Dress";
			Name2 = "White Wedding Dress";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 8836;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Cindercloth Robe)
*
***************************************************************/

namespace Server.Items
{
	public class CinderclothRobe : Item
	{
		public CinderclothRobe() : base()
		{
			Id = 10042;
			Resistance[0] = 59;
			Bonding = 2;
			SellPrice = 6644;
			AvailableClasses = 0x7FFF;
			Model = 14606;
			ObjectClass = 4;
			SubClass = 1;
			Level = 45;
			ReqLevel = 40;
			Name = "Cindercloth Robe";
			Name2 = "Cindercloth Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 33222;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
			SetSpell( 17868 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Duskwoven Robe)
*
***************************************************************/

namespace Server.Items
{
	public class DuskwovenRobe : Item
	{
		public DuskwovenRobe() : base()
		{
			Id = 10065;
			Resistance[0] = 71;
			Bonding = 2;
			SellPrice = 12153;
			AvailableClasses = 0x7FFF;
			Model = 28165;
			ObjectClass = 4;
			SubClass = 1;
			Level = 55;
			ReqLevel = 50;
			Name = "Duskwoven Robe";
			Name2 = "Duskwoven Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 469;
			BuyPrice = 60767;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Councillor's Robes)
*
***************************************************************/

namespace Server.Items
{
	public class CouncillorsRobes : Item
	{
		public CouncillorsRobes() : base()
		{
			Id = 10102;
			Resistance[0] = 76;
			Bonding = 2;
			SellPrice = 15020;
			AvailableClasses = 0x7FFF;
			Model = 27609;
			ObjectClass = 4;
			SubClass = 1;
			Level = 59;
			ReqLevel = 54;
			Name = "Councillor's Robes";
			Name2 = "Councillor's Robes";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 470;
			BuyPrice = 75101;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(High Councillor's Robe)
*
***************************************************************/

namespace Server.Items
{
	public class HighCouncillorsRobe : Item
	{
		public HighCouncillorsRobe() : base()
		{
			Id = 10143;
			Resistance[0] = 82;
			Bonding = 2;
			SellPrice = 19772;
			AvailableClasses = 0x7FFF;
			Model = 27645;
			ObjectClass = 4;
			SubClass = 1;
			Level = 64;
			ReqLevel = 59;
			Name = "High Councillor's Robe";
			Name2 = "High Councillor's Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 472;
			BuyPrice = 98864;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Mystical Robe)
*
***************************************************************/

namespace Server.Items
{
	public class MysticalRobe : Item
	{
		public MysticalRobe() : base()
		{
			Id = 10178;
			Resistance[0] = 75;
			Bonding = 2;
			SellPrice = 14475;
			AvailableClasses = 0x7FFF;
			Model = 28112;
			ObjectClass = 4;
			SubClass = 1;
			Level = 58;
			ReqLevel = 53;
			Name = "Mystical Robe";
			Name2 = "Mystical Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 470;
			BuyPrice = 72375;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Elegant Robes)
*
***************************************************************/

namespace Server.Items
{
	public class ElegantRobes : Item
	{
		public ElegantRobes() : base()
		{
			Id = 10215;
			Resistance[0] = 80;
			Bonding = 2;
			SellPrice = 17387;
			AvailableClasses = 0x7FFF;
			Model = 28992;
			ObjectClass = 4;
			SubClass = 1;
			Level = 62;
			ReqLevel = 57;
			Name = "Elegant Robes";
			Name2 = "Elegant Robes";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 471;
			BuyPrice = 86939;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Master's Robe)
*
***************************************************************/

namespace Server.Items
{
	public class MastersRobe : Item
	{
		public MastersRobe() : base()
		{
			Id = 10254;
			Resistance[0] = 83;
			Bonding = 2;
			SellPrice = 22164;
			AvailableClasses = 0x7FFF;
			Model = 28479;
			ObjectClass = 4;
			SubClass = 1;
			Level = 65;
			ReqLevel = 60;
			Name = "Master's Robe";
			Name2 = "Master's Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 472;
			BuyPrice = 110823;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Robes of the Lich)
*
***************************************************************/

namespace Server.Items
{
	public class RobesOfTheLich : Item
	{
		public RobesOfTheLich() : base()
		{
			Id = 10762;
			Resistance[0] = 64;
			Bonding = 1;
			SellPrice = 6903;
			AvailableClasses = 0x7FFF;
			Model = 19953;
			ObjectClass = 4;
			SubClass = 1;
			Level = 44;
			ReqLevel = 39;
			Name = "Robes of the Lich";
			Name2 = "Robes of the Lich";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 34519;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 80;
			SpiritBonus = 10;
			StaminaBonus = 20;
		}
	}
}


/**************************************************************
*
*				(Woodland Robes)
*
***************************************************************/

namespace Server.Items
{
	public class WoodlandRobes : Item
	{
		public WoodlandRobes() : base()
		{
			Id = 11189;
			Resistance[0] = 10;
			Bonding = 1;
			SellPrice = 10;
			AvailableClasses = 0x7FFF;
			Model = 28178;
			ObjectClass = 4;
			SubClass = 1;
			Level = 5;
			Name = "Woodland Robes";
			Name2 = "Woodland Robes";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 52;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Robes of the Royal Crown)
*
***************************************************************/

namespace Server.Items
{
	public class RobesOfTheRoyalCrown : Item
	{
		public RobesOfTheRoyalCrown() : base()
		{
			Id = 11924;
			Resistance[0] = 85;
			Bonding = 1;
			SellPrice = 20475;
			AvailableClasses = 0x7FFF;
			Model = 28814;
			ObjectClass = 4;
			SubClass = 1;
			Level = 60;
			ReqLevel = 55;
			Name = "Robes of the Royal Crown";
			Name2 = "Robes of the Royal Crown";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 102378;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 80;
			IqBonus = 29;
			SpiritBonus = 9;
			StaminaBonus = 5;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Embrace of the Wind Serpent)
*
***************************************************************/

namespace Server.Items
{
	public class EmbraceOfTheWindSerpent : Item
	{
		public EmbraceOfTheWindSerpent() : base()
		{
			Id = 12462;
			Resistance[0] = 86;
			Bonding = 1;
			SellPrice = 20274;
			AvailableClasses = 0x7FFF;
			Model = 28272;
			ObjectClass = 4;
			SubClass = 1;
			Level = 55;
			ReqLevel = 50;
			Name = "Embrace of the Wind Serpent";
			Name2 = "Embrace of the Wind Serpent";
			Resistance[3] = 12;
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 101370;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 100;
			IqBonus = 30;
			SpiritBonus = 17;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Funeral Pyre Vestment)
*
***************************************************************/

namespace Server.Items
{
	public class FuneralPyreVestment : Item
	{
		public FuneralPyreVestment() : base()
		{
			Id = 12542;
			Resistance[0] = 73;
			Bonding = 2;
			SellPrice = 12356;
			AvailableClasses = 0x7FFF;
			Model = 26053;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 1;
			Level = 51;
			ReqLevel = 46;
			Name = "Funeral Pyre Vestment";
			Name2 = "Funeral Pyre Vestment";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 61781;
			Resistance[5] = 10;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 80;
			IqBonus = 25;
		}
	}
}


/**************************************************************
*
*				(Widow's Clutch)
*
***************************************************************/

namespace Server.Items
{
	public class WidowsClutch : Item
	{
		public WidowsClutch() : base()
		{
			Id = 13080;
			Resistance[0] = 150;
			Bonding = 1;
			SellPrice = 22512;
			AvailableClasses = 0x7FFF;
			Model = 23604;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Widow's Clutch";
			Name2 = "Widow's Clutch";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 112562;
			Resistance[5] = 13;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			SpiritBonus = 24;
			IqBonus = 15;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Alanna's Embrace)
*
***************************************************************/

namespace Server.Items
{
	public class AlannasEmbrace : Item
	{
		public AlannasEmbrace() : base()
		{
			Id = 13314;
			Resistance[0] = 96;
			Bonding = 1;
			SellPrice = 30222;
			AvailableClasses = 0x7FFF;
			Model = 24760;
			ObjectClass = 4;
			SubClass = 1;
			Level = 62;
			ReqLevel = 57;
			Name = "Alanna's Embrace";
			Name2 = "Alanna's Embrace";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 151110;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 100;
			SetSpell( 14799 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 20;
			IqBonus = 20;
			StaminaBonus = 20;
		}
	}
}


/**************************************************************
*
*				(Robes of the Exalted)
*
***************************************************************/

namespace Server.Items
{
	public class RobesOfTheExalted : Item
	{
		public RobesOfTheExalted() : base()
		{
			Id = 13346;
			Resistance[0] = 89;
			Bonding = 1;
			SellPrice = 23118;
			AvailableClasses = 0x7FFF;
			Model = 24025;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Robes of the Exalted";
			Name2 = "Robes of the Exalted";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 115591;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 80;
			SetSpell( 18042 , 1 , 0 , -1 , 0 , -1 );
			IqBonus = 11;
			SpiritBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Coldtouch Phantom Wraps)
*
***************************************************************/

namespace Server.Items
{
	public class ColdtouchPhantomWraps : Item
	{
		public ColdtouchPhantomWraps() : base()
		{
			Id = 13535;
			Resistance[6] = 13;
			Resistance[0] = 77;
			Bonding = 1;
			SellPrice = 16829;
			AvailableClasses = 0x7FFF;
			Model = 24189;
			Resistance[4] = 20;
			ObjectClass = 4;
			SubClass = 1;
			Level = 60;
			ReqLevel = 55;
			Name = "Coldtouch Phantom Wraps";
			Name2 = "Coldtouch Phantom Wraps";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 84146;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Runecloth Robe)
*
***************************************************************/

namespace Server.Items
{
	public class RuneclothRobe : Item
	{
		public RuneclothRobe() : base()
		{
			Id = 13858;
			Resistance[0] = 68;
			Bonding = 2;
			SellPrice = 10917;
			AvailableClasses = 0x7FFF;
			Model = 24601;
			ObjectClass = 4;
			SubClass = 1;
			Level = 52;
			ReqLevel = 47;
			Name = "Runecloth Robe";
			Name2 = "Runecloth Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 54589;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
			SpiritBonus = 17;
			IqBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Frostweave Robe)
*
***************************************************************/

namespace Server.Items
{
	public class FrostweaveRobe : Item
	{
		public FrostweaveRobe() : base()
		{
			Id = 13868;
			Resistance[0] = 66;
			Bonding = 2;
			SellPrice = 9665;
			AvailableClasses = 0x7FFF;
			Model = 24612;
			ObjectClass = 4;
			SubClass = 1;
			Level = 51;
			ReqLevel = 46;
			Name = "Frostweave Robe";
			Name2 = "Frostweave Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 48328;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
			SetSpell( 17890 , 1 , 0 , -1 , 0 , -1 );
			IqBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Beaded Robe)
*
***************************************************************/

namespace Server.Items
{
	public class BeadedRobe : Item
	{
		public BeadedRobe() : base()
		{
			Id = 14091;
			Resistance[0] = 21;
			Bonding = 2;
			SellPrice = 119;
			AvailableClasses = 0x7FFF;
			Model = 25869;
			ObjectClass = 4;
			SubClass = 1;
			Level = 11;
			ReqLevel = 6;
			Name = "Beaded Robe";
			Name2 = "Beaded Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 454;
			BuyPrice = 599;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Brightcloth Robe)
*
***************************************************************/

namespace Server.Items
{
	public class BrightclothRobe : Item
	{
		public BrightclothRobe() : base()
		{
			Id = 14100;
			Resistance[0] = 70;
			Bonding = 2;
			SellPrice = 12089;
			AvailableClasses = 0x7FFF;
			Model = 15820;
			Resistance[4] = 16;
			ObjectClass = 4;
			SubClass = 1;
			Level = 54;
			ReqLevel = 49;
			Name = "Brightcloth Robe";
			Name2 = "Brightcloth Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 60449;
			Resistance[5] = 15;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Felcloth Robe)
*
***************************************************************/

namespace Server.Items
{
	public class FelclothRobe : Item
	{
		public FelclothRobe() : base()
		{
			Id = 14106;
			Resistance[0] = 79;
			Bonding = 2;
			SellPrice = 18053;
			AvailableClasses = 0x7FFF;
			Model = 24932;
			ObjectClass = 4;
			SubClass = 1;
			Level = 61;
			ReqLevel = 56;
			Name = "Felcloth Robe";
			Name2 = "Felcloth Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 90268;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
			SetSpell( 18015 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Native Robe)
*
***************************************************************/

namespace Server.Items
{
	public class NativeRobe : Item
	{
		public NativeRobe() : base()
		{
			Id = 14109;
			Resistance[0] = 29;
			Bonding = 2;
			SellPrice = 341;
			AvailableClasses = 0x7FFF;
			Model = 25877;
			ObjectClass = 4;
			SubClass = 1;
			Level = 16;
			ReqLevel = 11;
			Name = "Native Robe";
			Name2 = "Native Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 456;
			BuyPrice = 1705;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Aboriginal Robe)
*
***************************************************************/

namespace Server.Items
{
	public class AboriginalRobe : Item
	{
		public AboriginalRobe() : base()
		{
			Id = 14120;
			Resistance[0] = 34;
			Bonding = 2;
			SellPrice = 577;
			AvailableClasses = 0x7FFF;
			Model = 16531;
			ObjectClass = 4;
			SubClass = 1;
			Level = 20;
			ReqLevel = 15;
			Name = "Aboriginal Robe";
			Name2 = "Aboriginal Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 457;
			BuyPrice = 2887;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Ritual Shroud)
*
***************************************************************/

namespace Server.Items
{
	public class RitualShroud : Item
	{
		public RitualShroud() : base()
		{
			Id = 14127;
			Resistance[0] = 38;
			Bonding = 2;
			SellPrice = 999;
			AvailableClasses = 0x7FFF;
			Model = 15201;
			ObjectClass = 4;
			SubClass = 1;
			Level = 24;
			ReqLevel = 19;
			Name = "Ritual Shroud";
			Name2 = "Ritual Shroud";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 458;
			BuyPrice = 4999;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Wizardweave Robe)
*
***************************************************************/

namespace Server.Items
{
	public class WizardweaveRobe : Item
	{
		public WizardweaveRobe() : base()
		{
			Id = 14128;
			Resistance[6] = 17;
			Resistance[0] = 77;
			Bonding = 2;
			SellPrice = 16093;
			AvailableClasses = 0x7FFF;
			Model = 24945;
			Resistance[2] = 18;
			ObjectClass = 4;
			SubClass = 1;
			Level = 60;
			ReqLevel = 55;
			Name = "Wizardweave Robe";
			Name2 = "Wizardweave Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 80465;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Robe of Winter Night)
*
***************************************************************/

namespace Server.Items
{
	public class RobeOfWinterNight : Item
	{
		public RobeOfWinterNight() : base()
		{
			Id = 14136;
			Resistance[0] = 81;
			Bonding = 2;
			SellPrice = 17025;
			AvailableClasses = 0x7FFF;
			Model = 25834;
			ObjectClass = 4;
			SubClass = 1;
			Level = 57;
			ReqLevel = 52;
			Name = "Robe of Winter Night";
			Name2 = "Robe of Winter Night";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 85127;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 80;
			SetSpell( 18018 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 17900 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Robe of Evocation)
*
***************************************************************/

namespace Server.Items
{
	public class RobeOfEvocation : Item
	{
		public RobeOfEvocation() : base()
		{
			Id = 14150;
			Resistance[0] = 32;
			Bonding = 1;
			SellPrice = 420;
			AvailableClasses = 0x7FFF;
			Model = 24988;
			ObjectClass = 4;
			SubClass = 1;
			Level = 18;
			ReqLevel = 13;
			Name = "Robe of Evocation";
			Name2 = "Robe of Evocation";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2103;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 55;
			SpiritBonus = 4;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Robe of the Archmage)
*
***************************************************************/

namespace Server.Items
{
	public class RobeOfTheArchmage : Item
	{
		public RobeOfTheArchmage() : base()
		{
			Id = 14152;
			Resistance[0] = 96;
			Bonding = 1;
			SellPrice = 28815;
			AvailableClasses = 0x7A80;
			Model = 25205;
			ObjectClass = 4;
			SubClass = 1;
			Level = 62;
			ReqLevel = 57;
			Name = "Robe of the Archmage";
			Name2 = "Robe of the Archmage";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 144076;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 100;
			SetSpell( 18056 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 18384 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 18385 , 0 , 0 , 300000 , 30 , 120000 );
			SpiritBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Robe of the Void)
*
***************************************************************/

namespace Server.Items
{
	public class RobeOfTheVoid : Item
	{
		public RobeOfTheVoid() : base()
		{
			Id = 14153;
			Resistance[0] = 96;
			Bonding = 1;
			SellPrice = 28920;
			AvailableClasses = 0x7B00;
			Model = 25201;
			ObjectClass = 4;
			SubClass = 1;
			Level = 62;
			ReqLevel = 57;
			Name = "Robe of the Void";
			Name2 = "Robe of the Void";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 144603;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 100;
			SetSpell( 18024 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 18386 , 0 , 0 , 600000 , 0 , 0 );
			StaminaBonus = 14;
		}
	}
}


/**************************************************************
*
*				(Truefaith Vestments)
*
***************************************************************/

namespace Server.Items
{
	public class TruefaithVestments : Item
	{
		public TruefaithVestments() : base()
		{
			Id = 14154;
			Resistance[0] = 96;
			Bonding = 1;
			SellPrice = 29028;
			AvailableClasses = 0x7A10;
			Model = 25203;
			ObjectClass = 4;
			SubClass = 1;
			Level = 62;
			ReqLevel = 57;
			Name = "Truefaith Vestments";
			Name2 = "Truefaith Vestments";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 145144;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 100;
			SetSpell( 18044 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 18379 , 1 , 0 , 0 , 0 , 0 );
			SetSpell( 18388 , 1 , 0 , 0 , 0 , 0 );
			StaminaBonus = 14;
		}
	}
}


/**************************************************************
*
*				(Pagan Wraps)
*
***************************************************************/

namespace Server.Items
{
	public class PaganWraps : Item
	{
		public PaganWraps() : base()
		{
			Id = 14163;
			Resistance[0] = 40;
			Bonding = 2;
			SellPrice = 1168;
			AvailableClasses = 0x7FFF;
			Model = 25894;
			ObjectClass = 4;
			SubClass = 1;
			Level = 26;
			ReqLevel = 21;
			Name = "Pagan Wraps";
			Name2 = "Pagan Wraps";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 459;
			BuyPrice = 5841;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Buccaneer's Robes)
*
***************************************************************/

namespace Server.Items
{
	public class BuccaneersRobes : Item
	{
		public BuccaneersRobes() : base()
		{
			Id = 14172;
			Resistance[0] = 37;
			Bonding = 2;
			SellPrice = 837;
			AvailableClasses = 0x7FFF;
			Model = 28098;
			ObjectClass = 4;
			SubClass = 1;
			Level = 23;
			ReqLevel = 18;
			Name = "Buccaneer's Robes";
			Name2 = "Buccaneer's Robes";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 458;
			BuyPrice = 4188;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Watcher's Robes)
*
***************************************************************/

namespace Server.Items
{
	public class WatchersRobes : Item
	{
		public WatchersRobes() : base()
		{
			Id = 14184;
			Resistance[0] = 43;
			Bonding = 2;
			SellPrice = 1716;
			AvailableClasses = 0x7FFF;
			Model = 25976;
			ObjectClass = 4;
			SubClass = 1;
			Level = 30;
			ReqLevel = 25;
			Name = "Watcher's Robes";
			Name2 = "Watcher's Robes";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 460;
			BuyPrice = 8584;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Raincaller Robes)
*
***************************************************************/

namespace Server.Items
{
	public class RaincallerRobes : Item
	{
		public RaincallerRobes() : base()
		{
			Id = 14192;
			Resistance[0] = 44;
			Bonding = 2;
			SellPrice = 1946;
			AvailableClasses = 0x7FFF;
			Model = 25989;
			ObjectClass = 4;
			SubClass = 1;
			Level = 31;
			ReqLevel = 26;
			Name = "Raincaller Robes";
			Name2 = "Raincaller Robes";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 461;
			BuyPrice = 9732;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Thistlefur Robe)
*
***************************************************************/

namespace Server.Items
{
	public class ThistlefurRobe : Item
	{
		public ThistlefurRobe() : base()
		{
			Id = 14204;
			Resistance[0] = 48;
			Bonding = 2;
			SellPrice = 3041;
			AvailableClasses = 0x7FFF;
			Model = 26011;
			ObjectClass = 4;
			SubClass = 1;
			Level = 36;
			ReqLevel = 31;
			Name = "Thistlefur Robe";
			Name2 = "Thistlefur Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 462;
			BuyPrice = 15206;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Vital Raiment)
*
***************************************************************/

namespace Server.Items
{
	public class VitalRaiment : Item
	{
		public VitalRaiment() : base()
		{
			Id = 14213;
			Resistance[0] = 49;
			Bonding = 2;
			SellPrice = 3553;
			AvailableClasses = 0x7FFF;
			Model = 26017;
			ObjectClass = 4;
			SubClass = 1;
			Level = 37;
			ReqLevel = 32;
			Name = "Vital Raiment";
			Name2 = "Vital Raiment";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 463;
			BuyPrice = 17768;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Geomancer's Wraps)
*
***************************************************************/

namespace Server.Items
{
	public class GeomancersWraps : Item
	{
		public GeomancersWraps() : base()
		{
			Id = 14225;
			Resistance[0] = 54;
			Bonding = 2;
			SellPrice = 4694;
			AvailableClasses = 0x7FFF;
			Model = 26053;
			ObjectClass = 4;
			SubClass = 1;
			Level = 41;
			ReqLevel = 36;
			Name = "Geomancer's Wraps";
			Name2 = "Geomancer's Wraps";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 464;
			BuyPrice = 23471;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Embersilk Robes)
*
***************************************************************/

namespace Server.Items
{
	public class EmbersilkRobes : Item
	{
		public EmbersilkRobes() : base()
		{
			Id = 14234;
			Resistance[0] = 55;
			Bonding = 2;
			SellPrice = 5240;
			AvailableClasses = 0x7FFF;
			Model = 26067;
			ObjectClass = 4;
			SubClass = 1;
			Level = 42;
			ReqLevel = 37;
			Name = "Embersilk Robes";
			Name2 = "Embersilk Robes";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 464;
			BuyPrice = 26200;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Darkmist Wraps)
*
***************************************************************/

namespace Server.Items
{
	public class DarkmistWraps : Item
	{
		public DarkmistWraps() : base()
		{
			Id = 14244;
			Resistance[0] = 60;
			Bonding = 2;
			SellPrice = 6870;
			AvailableClasses = 0x7FFF;
			Model = 28991;
			ObjectClass = 4;
			SubClass = 1;
			Level = 46;
			ReqLevel = 41;
			Name = "Darkmist Wraps";
			Name2 = "Darkmist Wraps";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 466;
			BuyPrice = 34354;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Lunar Raiment)
*
***************************************************************/

namespace Server.Items
{
	public class LunarRaiment : Item
	{
		public LunarRaiment() : base()
		{
			Id = 14254;
			Resistance[0] = 61;
			Bonding = 2;
			SellPrice = 7698;
			AvailableClasses = 0x7FFF;
			Model = 26119;
			ObjectClass = 4;
			SubClass = 1;
			Level = 47;
			ReqLevel = 42;
			Name = "Lunar Raiment";
			Name2 = "Lunar Raiment";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 466;
			BuyPrice = 38493;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Bloodwoven Wraps)
*
***************************************************************/

namespace Server.Items
{
	public class BloodwovenWraps : Item
	{
		public BloodwovenWraps() : base()
		{
			Id = 14265;
			Resistance[0] = 66;
			Bonding = 2;
			SellPrice = 9853;
			AvailableClasses = 0x7FFF;
			Model = 26198;
			ObjectClass = 4;
			SubClass = 1;
			Level = 51;
			ReqLevel = 46;
			Name = "Bloodwoven Wraps";
			Name2 = "Bloodwoven Wraps";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 467;
			BuyPrice = 49268;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Gaea's Raiment)
*
***************************************************************/

namespace Server.Items
{
	public class GaeasRaiment : Item
	{
		public GaeasRaiment() : base()
		{
			Id = 14275;
			Resistance[0] = 68;
			Bonding = 2;
			SellPrice = 11115;
			AvailableClasses = 0x7FFF;
			Model = 26142;
			ObjectClass = 4;
			SubClass = 1;
			Level = 52;
			ReqLevel = 47;
			Name = "Gaea's Raiment";
			Name2 = "Gaea's Raiment";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 468;
			BuyPrice = 55575;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Opulent Robes)
*
***************************************************************/

namespace Server.Items
{
	public class OpulentRobes : Item
	{
		public OpulentRobes() : base()
		{
			Id = 14284;
			Resistance[0] = 73;
			Bonding = 2;
			SellPrice = 13135;
			AvailableClasses = 0x7FFF;
			Model = 26131;
			ObjectClass = 4;
			SubClass = 1;
			Level = 56;
			ReqLevel = 51;
			Name = "Opulent Robes";
			Name2 = "Opulent Robes";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 469;
			BuyPrice = 65678;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Arachnidian Robes)
*
***************************************************************/

namespace Server.Items
{
	public class ArachnidianRobes : Item
	{
		public ArachnidianRobes() : base()
		{
			Id = 14297;
			Resistance[0] = 74;
			Bonding = 2;
			SellPrice = 13556;
			AvailableClasses = 0x7FFF;
			Model = 26211;
			ObjectClass = 4;
			SubClass = 1;
			Level = 57;
			ReqLevel = 52;
			Name = "Arachnidian Robes";
			Name2 = "Arachnidian Robes";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 469;
			BuyPrice = 67782;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Bonecaster's Shroud)
*
***************************************************************/

namespace Server.Items
{
	public class BonecastersShroud : Item
	{
		public BonecastersShroud() : base()
		{
			Id = 14303;
			Resistance[0] = 77;
			Bonding = 2;
			SellPrice = 16209;
			AvailableClasses = 0x7FFF;
			Model = 18834;
			ObjectClass = 4;
			SubClass = 1;
			Level = 60;
			ReqLevel = 55;
			Name = "Bonecaster's Shroud";
			Name2 = "Bonecaster's Shroud";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 470;
			BuyPrice = 81045;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Celestial Silk Robes)
*
***************************************************************/

namespace Server.Items
{
	public class CelestialSilkRobes : Item
	{
		public CelestialSilkRobes() : base()
		{
			Id = 14317;
			Resistance[0] = 79;
			Bonding = 2;
			SellPrice = 16633;
			AvailableClasses = 0x7FFF;
			Model = 26254;
			ObjectClass = 4;
			SubClass = 1;
			Level = 61;
			ReqLevel = 56;
			Name = "Celestial Silk Robes";
			Name2 = "Celestial Silk Robes";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 471;
			BuyPrice = 83165;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Resplendent Robes)
*
***************************************************************/

namespace Server.Items
{
	public class ResplendentRobes : Item
	{
		public ResplendentRobes() : base()
		{
			Id = 14326;
			Resistance[0] = 81;
			Bonding = 2;
			SellPrice = 19479;
			AvailableClasses = 0x7FFF;
			Model = 28993;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Resplendent Robes";
			Name2 = "Resplendent Robes";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 471;
			BuyPrice = 97399;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Eternal Wraps)
*
***************************************************************/

namespace Server.Items
{
	public class EternalWraps : Item
	{
		public EternalWraps() : base()
		{
			Id = 14336;
			Resistance[0] = 83;
			Bonding = 2;
			SellPrice = 20137;
			AvailableClasses = 0x7FFF;
			Model = 26226;
			ObjectClass = 4;
			SubClass = 1;
			Level = 65;
			ReqLevel = 60;
			Name = "Eternal Wraps";
			Name2 = "Eternal Wraps";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 472;
			BuyPrice = 100686;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Freezing Lich Robes)
*
***************************************************************/

namespace Server.Items
{
	public class FreezingLichRobes : Item
	{
		public FreezingLichRobes() : base()
		{
			Id = 14340;
			Resistance[0] = 88;
			Bonding = 1;
			SellPrice = 21778;
			AvailableClasses = 0x7FFF;
			Model = 25039;
			Resistance[4] = 15;
			ObjectClass = 4;
			SubClass = 1;
			Level = 62;
			ReqLevel = 57;
			Name = "Freezing Lich Robes";
			Name2 = "Freezing Lich Robes";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 108891;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 80;
			SetSpell( 17902 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Mystic's Robe)
*
***************************************************************/

namespace Server.Items
{
	public class MysticsRobe : Item
	{
		public MysticsRobe() : base()
		{
			Id = 14371;
			Resistance[0] = 37;
			Bonding = 2;
			SellPrice = 815;
			AvailableClasses = 0x7FFF;
			Model = 25889;
			ObjectClass = 4;
			SubClass = 1;
			Level = 23;
			ReqLevel = 18;
			Name = "Mystic's Robe";
			Name2 = "Mystic's Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4079;
			InventoryType = InventoryTypes.Robe;
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
*				(Sanguine Robe)
*
***************************************************************/

namespace Server.Items
{
	public class SanguineRobe : Item
	{
		public SanguineRobe() : base()
		{
			Id = 14380;
			Resistance[0] = 41;
			Bonding = 2;
			SellPrice = 1473;
			AvailableClasses = 0x7FFF;
			Model = 25956;
			ObjectClass = 4;
			SubClass = 1;
			Level = 28;
			ReqLevel = 23;
			Name = "Sanguine Robe";
			Name2 = "Sanguine Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7369;
			InventoryType = InventoryTypes.Robe;
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
*				(Resilient Robe)
*
***************************************************************/

namespace Server.Items
{
	public class ResilientRobe : Item
	{
		public ResilientRobe() : base()
		{
			Id = 14405;
			Resistance[0] = 45;
			Bonding = 2;
			SellPrice = 2480;
			AvailableClasses = 0x7FFF;
			Model = 27873;
			ObjectClass = 4;
			SubClass = 1;
			Level = 33;
			ReqLevel = 28;
			Name = "Resilient Robe";
			Name2 = "Resilient Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 12402;
			InventoryType = InventoryTypes.Robe;
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
*				(Stonecloth Robe)
*
***************************************************************/

namespace Server.Items
{
	public class StoneclothRobe : Item
	{
		public StoneclothRobe() : base()
		{
			Id = 14413;
			Resistance[0] = 52;
			Bonding = 2;
			SellPrice = 3947;
			AvailableClasses = 0x7FFF;
			Model = 26038;
			ObjectClass = 4;
			SubClass = 1;
			Level = 39;
			ReqLevel = 34;
			Name = "Stonecloth Robe";
			Name2 = "Stonecloth Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 19736;
			InventoryType = InventoryTypes.Robe;
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
*				(Silksand Wraps)
*
***************************************************************/

namespace Server.Items
{
	public class SilksandWraps : Item
	{
		public SilksandWraps() : base()
		{
			Id = 14425;
			Resistance[0] = 58;
			Bonding = 2;
			SellPrice = 6223;
			AvailableClasses = 0x7FFF;
			Model = 26092;
			ObjectClass = 4;
			SubClass = 1;
			Level = 44;
			ReqLevel = 39;
			Name = "Silksand Wraps";
			Name2 = "Silksand Wraps";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 31118;
			InventoryType = InventoryTypes.Robe;
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
*				(Windchaser Robes)
*
***************************************************************/

namespace Server.Items
{
	public class WindchaserRobes : Item
	{
		public WindchaserRobes() : base()
		{
			Id = 14434;
			Resistance[0] = 64;
			Bonding = 2;
			SellPrice = 8706;
			AvailableClasses = 0x7FFF;
			Model = 26174;
			ObjectClass = 4;
			SubClass = 1;
			Level = 49;
			ReqLevel = 44;
			Name = "Windchaser Robes";
			Name2 = "Windchaser Robes";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 43531;
			InventoryType = InventoryTypes.Robe;
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
*				(Venomshroud Silk Robes)
*
***************************************************************/

namespace Server.Items
{
	public class VenomshroudSilkRobes : Item
	{
		public VenomshroudSilkRobes() : base()
		{
			Id = 14445;
			Resistance[0] = 70;
			Bonding = 2;
			SellPrice = 12353;
			AvailableClasses = 0x7FFF;
			Model = 19901;
			ObjectClass = 4;
			SubClass = 1;
			Level = 54;
			ReqLevel = 49;
			Name = "Venomshroud Silk Robes";
			Name2 = "Venomshroud Silk Robes";
			Resistance[3] = 4;
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 61765;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
			IqBonus = 11;
			StaminaBonus = 20;
		}
	}
}


/**************************************************************
*
*				(Highborne Robes)
*
***************************************************************/

namespace Server.Items
{
	public class HighborneRobes : Item
	{
		public HighborneRobes() : base()
		{
			Id = 14453;
			Resistance[0] = 76;
			Bonding = 2;
			SellPrice = 15677;
			AvailableClasses = 0x7FFF;
			Model = 26157;
			ObjectClass = 4;
			SubClass = 1;
			Level = 59;
			ReqLevel = 54;
			Name = "Highborne Robes";
			Name2 = "Highborne Robes";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 78386;
			InventoryType = InventoryTypes.Robe;
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
*				(Elunarian Silk Robes)
*
***************************************************************/

namespace Server.Items
{
	public class ElunarianSilkRobes : Item
	{
		public ElunarianSilkRobes() : base()
		{
			Id = 14464;
			Resistance[0] = 82;
			Bonding = 2;
			SellPrice = 20822;
			AvailableClasses = 0x7FFF;
			Model = 27228;
			ObjectClass = 4;
			SubClass = 1;
			Level = 64;
			ReqLevel = 59;
			Name = "Elunarian Silk Robes";
			Name2 = "Elunarian Silk Robes";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 104114;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
			StaminaBonus = 12;
			IqBonus = 21;
			StrBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Necropile Robe)
*
***************************************************************/

namespace Server.Items
{
	public class NecropileRobe : Item
	{
		public NecropileRobe() : base()
		{
			Id = 14626;
			Resistance[0] = 87;
			Bonding = 1;
			SellPrice = 20732;
			AvailableClasses = 0x7FFF;
			Model = 25245;
			ObjectClass = 4;
			SubClass = 1;
			Level = 61;
			ReqLevel = 56;
			Name = "Necropile Robe";
			Name2 = "Necropile Robe";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 103664;
			Sets = 122;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 80;
			StaminaBonus = 25;
			IqBonus = 12;
			SpiritBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Dustfall Robes)
*
***************************************************************/

namespace Server.Items
{
	public class DustfallRobes : Item
	{
		public DustfallRobes() : base()
		{
			Id = 15455;
			Resistance[0] = 49;
			Bonding = 1;
			SellPrice = 3541;
			AvailableClasses = 0x7FFF;
			Model = 28323;
			ObjectClass = 4;
			SubClass = 1;
			Level = 37;
			Name = "Dustfall Robes";
			Name2 = "Dustfall Robes";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 17705;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
			SpiritBonus = 11;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Astoria Robes)
*
***************************************************************/

namespace Server.Items
{
	public class AstoriaRobes : Item
	{
		public AstoriaRobes() : base()
		{
			Id = 15824;
			Resistance[0] = 76;
			Bonding = 1;
			SellPrice = 15061;
			AvailableClasses = 0x7FFF;
			Model = 26513;
			ObjectClass = 4;
			SubClass = 1;
			Level = 59;
			Name = "Astoria Robes";
			Name2 = "Astoria Robes";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 75307;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
			SpiritBonus = 20;
			IqBonus = 10;
			StrBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Knight-Captain's Silk Raiment)
*
***************************************************************/

namespace Server.Items
{
	public class KnightCaptainsSilkRaiment : Item
	{
		public KnightCaptainsSilkRaiment() : base()
		{
			Id = 16413;
			Resistance[0] = 89;
			Bonding = 1;
			SellPrice = 11692;
			AvailableClasses = 0x80;
			Model = 31057;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Knight-Captain's Silk Raiment";
			Name2 = "Knight-Captain's Silk Raiment";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 58463;
			Sets = 343;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 80;
			Flags = 32768;
			SetSpell( 18384 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 20;
			SpiritBonus = 20;
		}
	}
}


/**************************************************************
*
*				(Field Marshal's Silk Vestments)
*
***************************************************************/

namespace Server.Items
{
	public class FieldMarshalsSilkVestments : Item
	{
		public FieldMarshalsSilkVestments() : base()
		{
			Id = 16443;
			Resistance[0] = 100;
			Bonding = 1;
			SellPrice = 16561;
			AvailableClasses = 0x80;
			Model = 30343;
			ObjectClass = 4;
			SubClass = 1;
			Level = 65;
			ReqLevel = 60;
			Name = "Field Marshal's Silk Vestments";
			Name2 = "Field Marshal's Silk Vestments";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 82809;
			Sets = 388;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 100;
			Flags = 32768;
			SetSpell( 18384 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 30;
			SpiritBonus = 25;
		}
	}
}


/**************************************************************
*
*				(Legionnaire's Silk Robes)
*
***************************************************************/

namespace Server.Items
{
	public class LegionnairesSilkRobes : Item
	{
		public LegionnairesSilkRobes() : base()
		{
			Id = 16491;
			Resistance[0] = 89;
			Bonding = 1;
			SellPrice = 11906;
			AvailableClasses = 0x80;
			Model = 31102;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Legionnaire's Silk Robes";
			Name2 = "Legionnaire's Silk Robes";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 59534;
			Sets = 341;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 80;
			Flags = 32768;
			SetSpell( 18384 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 20;
			SpiritBonus = 20;
		}
	}
}


/**************************************************************
*
*				(Warlord's Silk Raiment)
*
***************************************************************/

namespace Server.Items
{
	public class WarlordsSilkRaiment : Item
	{
		public WarlordsSilkRaiment() : base()
		{
			Id = 16535;
			Resistance[0] = 100;
			Bonding = 1;
			SellPrice = 17748;
			AvailableClasses = 0x80;
			Model = 30351;
			ObjectClass = 4;
			SubClass = 1;
			Level = 65;
			ReqLevel = 60;
			Name = "Warlord's Silk Raiment";
			Name2 = "Warlord's Silk Raiment";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 88743;
			Sets = 387;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 100;
			Flags = 32768;
			SetSpell( 18384 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 30;
			SpiritBonus = 25;
		}
	}
}


/**************************************************************
*
*				(Moon Robes of Elune)
*
***************************************************************/

namespace Server.Items
{
	public class MoonRobesOfElune : Item
	{
		public MoonRobesOfElune() : base()
		{
			Id = 16604;
			Resistance[0] = 10;
			Bonding = 1;
			SellPrice = 17;
			AvailableClasses = 0x10;
			Model = 27472;
			ObjectClass = 4;
			SubClass = 1;
			Level = 5;
			Name = "Moon Robes of Elune";
			Name2 = "Moon Robes of Elune";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 86;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 40;
			IqBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Friar's Robes of the Light)
*
***************************************************************/

namespace Server.Items
{
	public class FriarsRobesOfTheLight : Item
	{
		public FriarsRobesOfTheLight() : base()
		{
			Id = 16605;
			Resistance[0] = 10;
			Bonding = 1;
			SellPrice = 17;
			AvailableClasses = 0x10;
			Model = 27473;
			ObjectClass = 4;
			SubClass = 1;
			Level = 5;
			Name = "Friar's Robes of the Light";
			Name2 = "Friar's Robes of the Light";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 87;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 40;
			IqBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Juju Hex Robes)
*
***************************************************************/

namespace Server.Items
{
	public class JujuHexRobes : Item
	{
		public JujuHexRobes() : base()
		{
			Id = 16606;
			Resistance[0] = 10;
			Bonding = 1;
			SellPrice = 17;
			AvailableClasses = 0x10;
			Model = 27477;
			ObjectClass = 4;
			SubClass = 1;
			Level = 5;
			Name = "Juju Hex Robes";
			Name2 = "Juju Hex Robes";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 87;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 40;
			IqBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Acolyte's Sacrificial Robes)
*
***************************************************************/

namespace Server.Items
{
	public class AcolytesSacrificialRobes : Item
	{
		public AcolytesSacrificialRobes() : base()
		{
			Id = 16607;
			Resistance[0] = 10;
			Bonding = 1;
			SellPrice = 16;
			AvailableClasses = 0x10;
			Model = 27479;
			ObjectClass = 4;
			SubClass = 1;
			Level = 5;
			Name = "Acolyte's Sacrificial Robes";
			Name2 = "Acolyte's Sacrificial Robes";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 80;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 40;
			IqBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Magister's Robes)
*
***************************************************************/

namespace Server.Items
{
	public class MagistersRobes : Item
	{
		public MagistersRobes() : base()
		{
			Id = 16688;
			Resistance[0] = 89;
			Bonding = 1;
			SellPrice = 22445;
			AvailableClasses = 0x7FFF;
			Model = 29591;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Magister's Robes";
			Name2 = "Magister's Robes";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 112228;
			Sets = 181;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 80;
			SpiritBonus = 31;
			IqBonus = 8;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Devout Robe)
*
***************************************************************/

namespace Server.Items
{
	public class DevoutRobe : Item
	{
		public DevoutRobe() : base()
		{
			Id = 16690;
			Resistance[0] = 89;
			Bonding = 1;
			SellPrice = 22616;
			AvailableClasses = 0x7FFF;
			Model = 30422;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Devout Robe";
			Name2 = "Devout Robe";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 113080;
			Sets = 182;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 80;
			SpiritBonus = 24;
			IqBonus = 15;
			StaminaBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Dreadmist Robe)
*
***************************************************************/

namespace Server.Items
{
	public class DreadmistRobe : Item
	{
		public DreadmistRobe() : base()
		{
			Id = 16700;
			Resistance[0] = 89;
			Bonding = 1;
			SellPrice = 24071;
			AvailableClasses = 0x7FFF;
			Model = 29792;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Dreadmist Robe";
			Name2 = "Dreadmist Robe";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 120358;
			Sets = 183;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 80;
			SpiritBonus = 21;
			StaminaBonus = 20;
			IqBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Arcanist Robes)
*
***************************************************************/

namespace Server.Items
{
	public class ArcanistRobes : Item
	{
		public ArcanistRobes() : base()
		{
			Id = 16798;
			Resistance[0] = 102;
			Bonding = 1;
			SellPrice = 34253;
			AvailableClasses = 0x80;
			Model = 30581;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 1;
			Level = 66;
			ReqLevel = 60;
			Name = "Arcanist Robes";
			Name2 = "Arcanist Robes";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 171269;
			Sets = 201;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 100;
			SetSpell( 9345 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 33;
			IqBonus = 14;
			StaminaBonus = 19;
		}
	}
}


/**************************************************************
*
*				(Felheart Robes)
*
***************************************************************/

namespace Server.Items
{
	public class FelheartRobes : Item
	{
		public FelheartRobes() : base()
		{
			Id = 16809;
			Resistance[0] = 102;
			Bonding = 1;
			SellPrice = 35690;
			AvailableClasses = 0x100;
			Model = 31973;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 1;
			Level = 66;
			ReqLevel = 60;
			Name = "Felheart Robes";
			Name2 = "Felheart Robes";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 178450;
			Sets = 203;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 100;
			SetSpell( 9417 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 20;
			IqBonus = 10;
			StaminaBonus = 31;
		}
	}
}


/**************************************************************
*
*				(Robes of Prophecy)
*
***************************************************************/

namespace Server.Items
{
	public class RobesOfProphecy : Item
	{
		public RobesOfProphecy() : base()
		{
			Id = 16815;
			Resistance[0] = 102;
			Bonding = 1;
			SellPrice = 33855;
			AvailableClasses = 0x10;
			Model = 31490;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 1;
			Level = 66;
			ReqLevel = 60;
			Name = "Robes of Prophecy";
			Name2 = "Robes of Prophecy";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 169278;
			Sets = 202;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 100;
			SetSpell( 9408 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 27;
			IqBonus = 17;
			StaminaBonus = 20;
		}
	}
}


/**************************************************************
*
*				(Netherwind Robes)
*
***************************************************************/

namespace Server.Items
{
	public class NetherwindRobes : Item
	{
		public NetherwindRobes() : base()
		{
			Id = 16916;
			Resistance[0] = 116;
			Bonding = 1;
			SellPrice = 56861;
			AvailableClasses = 0x7FFF;
			Model = 29869;
			Resistance[2] = 9;
			ObjectClass = 4;
			SubClass = 1;
			Level = 76;
			ReqLevel = 60;
			Name = "Netherwind Robes";
			Name2 = "Netherwind Robes";
			Resistance[3] = 3;
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 284307;
			Sets = 210;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 100;
			SetSpell( 17868 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 36;
			IqBonus = 17;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Robes of Transcendence)
*
***************************************************************/

namespace Server.Items
{
	public class RobesOfTranscendence : Item
	{
		public RobesOfTranscendence() : base()
		{
			Id = 16923;
			Resistance[0] = 116;
			Bonding = 1;
			SellPrice = 58349;
			AvailableClasses = 0x10;
			Model = 29784;
			ObjectClass = 4;
			SubClass = 1;
			Level = 76;
			ReqLevel = 60;
			Name = "Robes of Transcendence";
			Name2 = "Robes of Transcendence";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 291748;
			Sets = 211;
			Resistance[5] = 8;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 100;
			SetSpell( 17371 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 27;
			IqBonus = 27;
			StaminaBonus = 17;
		}
	}
}


/**************************************************************
*
*				(Nemesis Robes)
*
***************************************************************/

namespace Server.Items
{
	public class NemesisRobes : Item
	{
		public NemesisRobes() : base()
		{
			Id = 16931;
			Resistance[0] = 116;
			Bonding = 1;
			SellPrice = 55790;
			AvailableClasses = 0x7FFF;
			Model = 29861;
			Resistance[2] = 3;
			ObjectClass = 4;
			SubClass = 1;
			Level = 76;
			ReqLevel = 60;
			Name = "Nemesis Robes";
			Name2 = "Nemesis Robes";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 278950;
			Sets = 212;
			Resistance[5] = 9;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 100;
			SetSpell( 18009 , 1 , 0 , -1 , 0 , -1 );
			AgilityBonus = 5;
			SpiritBonus = 23;
			IqBonus = 17;
			StaminaBonus = 27;
		}
	}
}


/**************************************************************
*
*				(Zealot's Robe)
*
***************************************************************/

namespace Server.Items
{
	public class ZealotsRobe : Item
	{
		public ZealotsRobe() : base()
		{
			Id = 17043;
			Resistance[0] = 48;
			Bonding = 1;
			SellPrice = 3054;
			AvailableClasses = 0x7FFF;
			Model = 28871;
			ObjectClass = 4;
			SubClass = 1;
			Level = 36;
			Name = "Zealot's Robe";
			Name2 = "Zealot's Robe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 15274;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
			StaminaBonus = 12;
			SpiritBonus = 4;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Chan's Imperial Robes)
*
***************************************************************/

namespace Server.Items
{
	public class ChansImperialRobes : Item
	{
		public ChansImperialRobes() : base()
		{
			Id = 17050;
			Resistance[0] = 75;
			Bonding = 2;
			SellPrice = 12536;
			AvailableClasses = 0x7FFF;
			Model = 28990;
			ObjectClass = 4;
			SubClass = 1;
			Level = 52;
			ReqLevel = 47;
			Name = "Chan's Imperial Robes";
			Name2 = "Chan's Imperial Robes";
			Resistance[3] = 5;
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 62683;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 80;
			StaminaBonus = 20;
			IqBonus = 10;
			SpiritBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Knight-Captain's Dreadweave Robe)
*
***************************************************************/

namespace Server.Items
{
	public class KnightCaptainsDreadweaveRobe : Item
	{
		public KnightCaptainsDreadweaveRobe() : base()
		{
			Id = 17568;
			Resistance[0] = 89;
			Bonding = 1;
			SellPrice = 11054;
			AvailableClasses = 0x100;
			Model = 31053;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Knight-Captain's Dreadweave Robe";
			Name2 = "Knight-Captain's Dreadweave Robe";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 55273;
			Sets = 346;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 80;
			Flags = 32768;
			SetSpell( 9345 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 20;
			SpiritBonus = 20;
		}
	}
}


/**************************************************************
*
*				(Legionnaire's Dreadweave Robe)
*
***************************************************************/

namespace Server.Items
{
	public class LegionnairesDreadweaveRobe : Item
	{
		public LegionnairesDreadweaveRobe() : base()
		{
			Id = 17572;
			Resistance[0] = 89;
			Bonding = 1;
			SellPrice = 11223;
			AvailableClasses = 0x100;
			Model = 27260;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Legionnaire's Dreadweave Robe";
			Name2 = "Legionnaire's Dreadweave Robe";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 56119;
			Sets = 345;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 80;
			Flags = 32768;
			SetSpell( 9345 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 20;
			SpiritBonus = 20;
		}
	}
}


/**************************************************************
*
*				(Field Marshal's Dreadweave Robe)
*
***************************************************************/

namespace Server.Items
{
	public class FieldMarshalsDreadweaveRobe : Item
	{
		public FieldMarshalsDreadweaveRobe() : base()
		{
			Id = 17581;
			Resistance[0] = 100;
			Bonding = 1;
			SellPrice = 17059;
			AvailableClasses = 0x100;
			Model = 30343;
			ObjectClass = 4;
			SubClass = 1;
			Level = 65;
			ReqLevel = 60;
			Name = "Field Marshal's Dreadweave Robe";
			Name2 = "Field Marshal's Dreadweave Robe";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 85298;
			Sets = 392;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 100;
			Flags = 32768;
			SetSpell( 9345 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 30;
			SpiritBonus = 25;
		}
	}
}


/**************************************************************
*
*				(Warlord's Dreadweave Robe)
*
***************************************************************/

namespace Server.Items
{
	public class WarlordsDreadweaveRobe : Item
	{
		public WarlordsDreadweaveRobe() : base()
		{
			Id = 17592;
			Resistance[0] = 100;
			Bonding = 1;
			SellPrice = 16497;
			AvailableClasses = 0x100;
			Model = 30351;
			ObjectClass = 4;
			SubClass = 1;
			Level = 65;
			ReqLevel = 60;
			Name = "Warlord's Dreadweave Robe";
			Name2 = "Warlord's Dreadweave Robe";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 82487;
			Sets = 391;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 100;
			Flags = 32768;
			SetSpell( 9345 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 30;
			SpiritBonus = 25;
		}
	}
}


/**************************************************************
*
*				(Knight-Captain's Satin Robes)
*
***************************************************************/

namespace Server.Items
{
	public class KnightCaptainsSatinRobes : Item
	{
		public KnightCaptainsSatinRobes() : base()
		{
			Id = 17600;
			Resistance[0] = 89;
			Bonding = 1;
			SellPrice = 11866;
			AvailableClasses = 0x10;
			Model = 31058;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Knight-Captain's Satin Robes";
			Name2 = "Knight-Captain's Satin Robes";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 59333;
			Sets = 344;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 80;
			Flags = 32768;
			SetSpell( 9345 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 20;
			SpiritBonus = 20;
		}
	}
}


/**************************************************************
*
*				(Field Marshal's Satin Vestments)
*
***************************************************************/

namespace Server.Items
{
	public class FieldMarshalsSatinVestments : Item
	{
		public FieldMarshalsSatinVestments() : base()
		{
			Id = 17605;
			Resistance[0] = 100;
			Bonding = 1;
			SellPrice = 17755;
			AvailableClasses = 0x10;
			Model = 30343;
			ObjectClass = 4;
			SubClass = 1;
			Level = 65;
			ReqLevel = 60;
			Name = "Field Marshal's Satin Vestments";
			Name2 = "Field Marshal's Satin Vestments";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 88777;
			Sets = 389;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 100;
			Flags = 32768;
			SetSpell( 9345 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 30;
			SpiritBonus = 25;
		}
	}
}


/**************************************************************
*
*				(Legionnaire's Satin Vestments)
*
***************************************************************/

namespace Server.Items
{
	public class LegionnairesSatinVestments : Item
	{
		public LegionnairesSatinVestments() : base()
		{
			Id = 17612;
			Resistance[0] = 89;
			Bonding = 1;
			SellPrice = 11221;
			AvailableClasses = 0x10;
			Model = 30351;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Legionnaire's Satin Vestments";
			Name2 = "Legionnaire's Satin Vestments";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 56108;
			Sets = 342;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 80;
			Flags = 32768;
			SetSpell( 9345 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 20;
			SpiritBonus = 20;
		}
	}
}


/**************************************************************
*
*				(Warlord's Satin Robes)
*
***************************************************************/

namespace Server.Items
{
	public class WarlordsSatinRobes : Item
	{
		public WarlordsSatinRobes() : base()
		{
			Id = 17624;
			Resistance[0] = 100;
			Bonding = 1;
			SellPrice = 17691;
			AvailableClasses = 0x10;
			Model = 30351;
			ObjectClass = 4;
			SubClass = 1;
			Level = 65;
			ReqLevel = 60;
			Name = "Warlord's Satin Robes";
			Name2 = "Warlord's Satin Robes";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 88455;
			Sets = 390;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 100;
			Flags = 32768;
			SetSpell( 9345 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 30;
			SpiritBonus = 25;
		}
	}
}


/**************************************************************
*
*				(Nature's Embrace)
*
***************************************************************/

namespace Server.Items
{
	public class NaturesEmbrace : Item
	{
		public NaturesEmbrace() : base()
		{
			Id = 17741;
			Resistance[0] = 73;
			Bonding = 1;
			SellPrice = 11447;
			AvailableClasses = 0x7FFF;
			Model = 29918;
			ObjectClass = 4;
			SubClass = 1;
			Level = 51;
			ReqLevel = 46;
			Name = "Nature's Embrace";
			Name2 = "Nature's Embrace";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 57238;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 80;
			SetSpell( 21518 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 18378 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Acumen Robes)
*
***************************************************************/

namespace Server.Items
{
	public class AcumenRobes : Item
	{
		public AcumenRobes() : base()
		{
			Id = 17775;
			Resistance[0] = 61;
			Bonding = 1;
			SellPrice = 7841;
			AvailableClasses = 0x7FFF;
			Model = 29951;
			ObjectClass = 4;
			SubClass = 1;
			Level = 47;
			Name = "Acumen Robes";
			Name2 = "Acumen Robes";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 39207;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
			SpiritBonus = 20;
		}
	}
}


/**************************************************************
*
*				(Robe of Everlasting Night)
*
***************************************************************/

namespace Server.Items
{
	public class RobeOfEverlastingNight : Item
	{
		public RobeOfEverlastingNight() : base()
		{
			Id = 18385;
			Resistance[0] = 88;
			Bonding = 1;
			SellPrice = 21536;
			AvailableClasses = 0x7FFF;
			Model = 30744;
			ObjectClass = 4;
			SubClass = 1;
			Level = 62;
			ReqLevel = 57;
			Name = "Robe of Everlasting Night";
			Name2 = "Robe of Everlasting Night";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 107684;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 80;
			SetSpell( 14054 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 13;
			StaminaBonus = 11;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Robe of Combustion)
*
***************************************************************/

namespace Server.Items
{
	public class RobeOfCombustion : Item
	{
		public RobeOfCombustion() : base()
		{
			Id = 18450;
			Resistance[0] = 77;
			Bonding = 1;
			SellPrice = 15814;
			AvailableClasses = 0x7FFF;
			Model = 30802;
			ObjectClass = 4;
			SubClass = 1;
			Level = 60;
			ReqLevel = 55;
			Name = "Robe of Combustion";
			Name2 = "Robe of Combustion";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 79073;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 70;
			SetSpell( 17867 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 17;
		}
	}
}


/**************************************************************
*
*				(Mooncloth Robe)
*
***************************************************************/

namespace Server.Items
{
	public class MoonclothRobe : Item
	{
		public MoonclothRobe() : base()
		{
			Id = 18486;
			Resistance[0] = 87;
			Bonding = 2;
			SellPrice = 21683;
			AvailableClasses = 0x7FFF;
			Model = 30824;
			ObjectClass = 4;
			SubClass = 1;
			Level = 61;
			ReqLevel = 56;
			Name = "Mooncloth Robe";
			Name2 = "Mooncloth Robe";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 108417;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 80;
			SpiritBonus = 25;
			IqBonus = 12;
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Mindsurge Robe)
*
***************************************************************/

namespace Server.Items
{
	public class MindsurgeRobe : Item
	{
		public MindsurgeRobe() : base()
		{
			Id = 18532;
			Resistance[0] = 88;
			Bonding = 1;
			SellPrice = 21629;
			AvailableClasses = 0x7FFF;
			Model = 30868;
			ObjectClass = 4;
			SubClass = 1;
			Level = 62;
			ReqLevel = 57;
			Name = "Mindsurge Robe";
			Name2 = "Mindsurge Robe";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 108145;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 80;
			SetSpell( 20959 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 13;
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Robe of Volatile Power)
*
***************************************************************/

namespace Server.Items
{
	public class RobeOfVolatilePower : Item
	{
		public RobeOfVolatilePower() : base()
		{
			Id = 19145;
			Resistance[0] = 102;
			Bonding = 1;
			SellPrice = 37033;
			AvailableClasses = 0x7FFF;
			Model = 31663;
			ObjectClass = 4;
			SubClass = 1;
			Level = 66;
			ReqLevel = 60;
			Name = "Robe of Volatile Power";
			Name2 = "Robe of Volatile Power";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 185169;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 100;
			SetSpell( 18382 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 14047 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 15;
			StaminaBonus = 10;
			IqBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Flarecore Robe)
*
***************************************************************/

namespace Server.Items
{
	public class FlarecoreRobe : Item
	{
		public FlarecoreRobe() : base()
		{
			Id = 19156;
			Resistance[0] = 102;
			Bonding = 2;
			SellPrice = 34911;
			AvailableClasses = 0x7FFF;
			Model = 31673;
			Resistance[2] = 15;
			ObjectClass = 4;
			SubClass = 1;
			Level = 66;
			ReqLevel = 60;
			Name = "Flarecore Robe";
			Name2 = "Flarecore Robe";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 174557;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 100;
			SetSpell( 13830 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 35;
		}
	}
}


/**************************************************************
*
*				(Black Ash Robe)
*
***************************************************************/

namespace Server.Items
{
	public class BlackAshRobe : Item
	{
		public BlackAshRobe() : base()
		{
			Id = 19399;
			Resistance[0] = 114;
			Bonding = 1;
			SellPrice = 53541;
			AvailableClasses = 0x7FFF;
			Model = 31930;
			Resistance[2] = 30;
			ObjectClass = 4;
			SubClass = 1;
			Level = 75;
			ReqLevel = 60;
			Name = "Black Ash Robe";
			Name2 = "Black Ash Robe";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 267707;
			InventoryType = InventoryTypes.Robe;
			Stackable = 1;
			Material = 7;
			Durability = 100;
			SpiritBonus = 22;
			IqBonus = 17;
			StaminaBonus = 21;
		}
	}
}


