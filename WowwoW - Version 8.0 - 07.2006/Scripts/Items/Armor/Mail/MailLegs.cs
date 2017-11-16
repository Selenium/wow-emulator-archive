/**************************************************************
*
*		Made by fulgas (fulgas@gmail.com)
*
*  WowwoW Item Designer ( 2005/8/23 - 10:05:24 )
*
***************************************************************/

using System;
using System.Collections;

/***************************************************************/

/**************************************************************
*
*				(Scalemail Pants)
*
***************************************************************/

namespace Server.Items
{
	public class ScalemailPants : Item
	{
		public ScalemailPants() : base()
		{
			Id = 286;
			Resistance[0] = 144;
			SellPrice = 645;
			AvailableClasses = 0x7FFF;
			Model = 10400;
			ObjectClass = 4;
			SubClass = 3;
			Level = 22;
			ReqLevel = 17;
			Name = "Scalemail Pants";
			Name2 = "Scalemail Pants";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 3229;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Chainmail Pants)
*
***************************************************************/

namespace Server.Items
{
	public class ChainmailPants : Item
	{
		public ChainmailPants() : base()
		{
			Id = 848;
			Resistance[0] = 132;
			SellPrice = 351;
			AvailableClasses = 0x7FFF;
			Model = 697;
			ObjectClass = 4;
			SubClass = 3;
			Level = 17;
			ReqLevel = 12;
			Name = "Chainmail Pants";
			Name2 = "Chainmail Pants";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1755;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Worn Mail Pants)
*
***************************************************************/

namespace Server.Items
{
	public class WornMailPants : Item
	{
		public WornMailPants() : base()
		{
			Id = 1735;
			Resistance[0] = 96;
			SellPrice = 89;
			AvailableClasses = 0x7FFF;
			Model = 687;
			ObjectClass = 4;
			SubClass = 3;
			Level = 12;
			ReqLevel = 7;
			Name = "Worn Mail Pants";
			Name2 = "Worn Mail Pants";
			AvailableRaces = 0x1FF;
			BuyPrice = 449;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Laced Mail Pants)
*
***************************************************************/

namespace Server.Items
{
	public class LacedMailPants : Item
	{
		public LacedMailPants() : base()
		{
			Id = 1743;
			Resistance[0] = 130;
			SellPrice = 299;
			AvailableClasses = 0x7FFF;
			Model = 687;
			ObjectClass = 4;
			SubClass = 3;
			Level = 19;
			ReqLevel = 14;
			Name = "Laced Mail Pants";
			Name2 = "Laced Mail Pants";
			AvailableRaces = 0x1FF;
			BuyPrice = 1497;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Linked Chain Pants)
*
***************************************************************/

namespace Server.Items
{
	public class LinkedChainPants : Item
	{
		public LinkedChainPants() : base()
		{
			Id = 1751;
			Resistance[0] = 144;
			SellPrice = 676;
			AvailableClasses = 0x7FFF;
			Model = 687;
			ObjectClass = 4;
			SubClass = 3;
			Level = 25;
			ReqLevel = 20;
			Name = "Linked Chain Pants";
			Name2 = "Linked Chain Pants";
			AvailableRaces = 0x1FF;
			BuyPrice = 3384;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Reinforced Chain Pants)
*
***************************************************************/

namespace Server.Items
{
	public class ReinforcedChainPants : Item
	{
		public ReinforcedChainPants() : base()
		{
			Id = 1759;
			Resistance[0] = 146;
			SellPrice = 732;
			AvailableClasses = 0x7FFF;
			Model = 687;
			ObjectClass = 4;
			SubClass = 3;
			Level = 26;
			ReqLevel = 21;
			Name = "Reinforced Chain Pants";
			Name2 = "Reinforced Chain Pants";
			AvailableRaces = 0x1FF;
			BuyPrice = 3661;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Goblin Mail Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class GoblinMailLeggings : Item
	{
		public GoblinMailLeggings() : base()
		{
			Id = 1943;
			Resistance[0] = 144;
			Bonding = 2;
			SellPrice = 713;
			AvailableClasses = 0x7FFF;
			Model = 697;
			ObjectClass = 4;
			SubClass = 3;
			Level = 19;
			ReqLevel = 14;
			Name = "Goblin Mail Leggings";
			Name2 = "Goblin Mail Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3566;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			StrBonus = 4;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Polished Scale Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class PolishedScaleLeggings : Item
	{
		public PolishedScaleLeggings() : base()
		{
			Id = 2152;
			Resistance[0] = 157;
			SellPrice = 1181;
			AvailableClasses = 0x7FFF;
			Model = 2989;
			ObjectClass = 4;
			SubClass = 3;
			Level = 27;
			ReqLevel = 22;
			Name = "Polished Scale Leggings";
			Name2 = "Polished Scale Leggings";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 5906;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Foreman's Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class ForemansLeggings : Item
	{
		public ForemansLeggings() : base()
		{
			Id = 2166;
			Resistance[0] = 147;
			Bonding = 2;
			SellPrice = 810;
			AvailableClasses = 0x7FFF;
			Model = 685;
			ObjectClass = 4;
			SubClass = 3;
			Level = 20;
			ReqLevel = 15;
			Name = "Foreman's Leggings";
			Name2 = "Foreman's Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4054;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			StaminaBonus = 3;
			AgilityBonus = 3;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Tarnished Chain Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class TarnishedChainLeggings : Item
	{
		public TarnishedChainLeggings() : base()
		{
			Id = 2381;
			Resistance[0] = 58;
			SellPrice = 15;
			AvailableClasses = 0x7FFF;
			Model = 2217;
			ObjectClass = 4;
			SubClass = 3;
			Level = 5;
			ReqLevel = 1;
			Name = "Tarnished Chain Leggings";
			Name2 = "Tarnished Chain Leggings";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 75;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Rusted Chain Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class RustedChainLeggings : Item
	{
		public RustedChainLeggings() : base()
		{
			Id = 2388;
			Resistance[0] = 58;
			SellPrice = 15;
			AvailableClasses = 0x7FFF;
			Model = 2228;
			ObjectClass = 4;
			SubClass = 3;
			Level = 5;
			ReqLevel = 1;
			Name = "Rusted Chain Leggings";
			Name2 = "Rusted Chain Leggings";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 77;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Light Mail Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class LightMailLeggings : Item
	{
		public LightMailLeggings() : base()
		{
			Id = 2394;
			Resistance[0] = 90;
			SellPrice = 83;
			AvailableClasses = 0x7FFF;
			Model = 2217;
			ObjectClass = 4;
			SubClass = 3;
			Level = 10;
			ReqLevel = 5;
			Name = "Light Mail Leggings";
			Name2 = "Light Mail Leggings";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 416;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Light Chain Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class LightChainLeggings : Item
	{
		public LightChainLeggings() : base()
		{
			Id = 2400;
			Resistance[0] = 90;
			SellPrice = 87;
			AvailableClasses = 0x7FFF;
			Model = 2270;
			ObjectClass = 4;
			SubClass = 3;
			Level = 10;
			ReqLevel = 5;
			Name = "Light Chain Leggings";
			Name2 = "Light Chain Leggings";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 437;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Augmented Chain Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class AugmentedChainLeggings : Item
	{
		public AugmentedChainLeggings() : base()
		{
			Id = 2418;
			Resistance[0] = 182;
			SellPrice = 3146;
			AvailableClasses = 0x7FFF;
			Model = 2969;
			ObjectClass = 4;
			SubClass = 3;
			Level = 37;
			ReqLevel = 32;
			Name = "Augmented Chain Leggings";
			Name2 = "Augmented Chain Leggings";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 15731;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
		}
	}
}


/**************************************************************
*
*				(Brigandine Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class BrigandineLeggings : Item
	{
		public BrigandineLeggings() : base()
		{
			Id = 2425;
			Resistance[0] = 227;
			SellPrice = 8615;
			AvailableClasses = 0x7FFF;
			Model = 2976;
			ObjectClass = 4;
			SubClass = 3;
			Level = 50;
			ReqLevel = 45;
			Name = "Brigandine Leggings";
			Name2 = "Brigandine Leggings";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 43077;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
		}
	}
}


/**************************************************************
*
*				(Malleable Chain Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class MalleableChainLeggings : Item
	{
		public MalleableChainLeggings() : base()
		{
			Id = 2545;
			Resistance[0] = 163;
			Bonding = 1;
			SellPrice = 1796;
			AvailableClasses = 0x7FFF;
			Model = 3043;
			ObjectClass = 4;
			SubClass = 3;
			Level = 26;
			Name = "Malleable Chain Leggings";
			Name2 = "Malleable Chain Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 8984;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 70;
			StrBonus = 7;
			StaminaBonus = 3;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Loose Chain Pants)
*
***************************************************************/

namespace Server.Items
{
	public class LooseChainPants : Item
	{
		public LooseChainPants() : base()
		{
			Id = 2646;
			Resistance[0] = 73;
			SellPrice = 31;
			AvailableClasses = 0x7FFF;
			Model = 2217;
			ObjectClass = 4;
			SubClass = 3;
			Level = 8;
			ReqLevel = 3;
			Name = "Loose Chain Pants";
			Name2 = "Loose Chain Pants";
			AvailableRaces = 0x1FF;
			BuyPrice = 159;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Flimsy Chain Pants)
*
***************************************************************/

namespace Server.Items
{
	public class FlimsyChainPants : Item
	{
		public FlimsyChainPants() : base()
		{
			Id = 2654;
			Resistance[0] = 37;
			SellPrice = 2;
			AvailableClasses = 0x7FFF;
			Model = 2217;
			ObjectClass = 4;
			SubClass = 3;
			Level = 2;
			ReqLevel = 1;
			Name = "Flimsy Chain Pants";
			Name2 = "Flimsy Chain Pants";
			AvailableRaces = 0x1FF;
			BuyPrice = 14;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Settler's Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class SettlersLeggings : Item
	{
		public SettlersLeggings() : base()
		{
			Id = 2694;
			Resistance[0] = 139;
			Bonding = 1;
			SellPrice = 539;
			AvailableClasses = 0x7FFF;
			Model = 28250;
			ObjectClass = 4;
			SubClass = 3;
			Level = 17;
			Name = "Settler's Leggings";
			Name2 = "Settler's Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2697;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			AgilityBonus = 3;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Copper Chain Pants)
*
***************************************************************/

namespace Server.Items
{
	public class CopperChainPants : Item
	{
		public CopperChainPants() : base()
		{
			Id = 2852;
			Resistance[0] = 83;
			SellPrice = 67;
			AvailableClasses = 0x7FFF;
			Model = 13095;
			ObjectClass = 4;
			SubClass = 3;
			Level = 9;
			ReqLevel = 4;
			Name = "Copper Chain Pants";
			Name2 = "Copper Chain Pants";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 335;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Rough Bronze Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class RoughBronzeLeggings : Item
	{
		public RoughBronzeLeggings() : base()
		{
			Id = 2865;
			Resistance[0] = 149;
			Bonding = 2;
			SellPrice = 962;
			AvailableClasses = 0x7FFF;
			Model = 4333;
			ObjectClass = 4;
			SubClass = 3;
			Level = 21;
			ReqLevel = 16;
			Name = "Rough Bronze Leggings";
			Name2 = "Rough Bronze Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4810;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 65;
			StaminaBonus = 5;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Darkshire Mail Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class DarkshireMailLeggings : Item
	{
		public DarkshireMailLeggings() : base()
		{
			Id = 2906;
			Resistance[0] = 163;
			Bonding = 1;
			SellPrice = 1810;
			AvailableClasses = 0x7FFF;
			Model = 2922;
			ObjectClass = 4;
			SubClass = 3;
			Level = 26;
			Name = "Darkshire Mail Leggings";
			Name2 = "Darkshire Mail Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 9051;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 70;
			StrBonus = 6;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Warrior's Pants)
*
***************************************************************/

namespace Server.Items
{
	public class WarriorsPants : Item
	{
		public WarriorsPants() : base()
		{
			Id = 2966;
			Resistance[0] = 94;
			Bonding = 2;
			SellPrice = 146;
			AvailableClasses = 0x7FFF;
			Model = 7193;
			ObjectClass = 4;
			SubClass = 3;
			Level = 10;
			ReqLevel = 5;
			Name = "Warrior's Pants";
			Name2 = "Warrior's Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 731;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 50;
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Veteran Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class VeteranLeggings : Item
	{
		public VeteranLeggings() : base()
		{
			Id = 2978;
			Resistance[0] = 126;
			Bonding = 2;
			SellPrice = 415;
			AvailableClasses = 0x7FFF;
			Model = 22693;
			ObjectClass = 4;
			SubClass = 3;
			Level = 15;
			ReqLevel = 10;
			Name = "Veteran Leggings";
			Name2 = "Veteran Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2079;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 55;
			StrBonus = 2;
			AgilityBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Burnished Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class BurnishedLeggings : Item
	{
		public BurnishedLeggings() : base()
		{
			Id = 2990;
			Resistance[0] = 149;
			Bonding = 2;
			SellPrice = 933;
			AvailableClasses = 0x7FFF;
			Model = 25768;
			ObjectClass = 4;
			SubClass = 3;
			Level = 21;
			ReqLevel = 16;
			Name = "Burnished Leggings";
			Name2 = "Burnished Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4666;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 65;
			StrBonus = 4;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Lambent Scale Legguards)
*
***************************************************************/

namespace Server.Items
{
	public class LambentScaleLegguards : Item
	{
		public LambentScaleLegguards() : base()
		{
			Id = 3048;
			Resistance[0] = 163;
			Bonding = 2;
			SellPrice = 1919;
			AvailableClasses = 0x7FFF;
			Model = 11525;
			ObjectClass = 4;
			SubClass = 3;
			Level = 26;
			ReqLevel = 21;
			Name = "Lambent Scale Legguards";
			Name2 = "Lambent Scale Legguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 9598;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 70;
			StrBonus = 7;
			AgilityBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Battle Chain Pants)
*
***************************************************************/

namespace Server.Items
{
	public class BattleChainPants : Item
	{
		public BattleChainPants() : base()
		{
			Id = 3282;
			Resistance[0] = 107;
			Bonding = 2;
			SellPrice = 235;
			AvailableClasses = 0x7FFF;
			Model = 26932;
			ObjectClass = 4;
			SubClass = 3;
			Level = 12;
			ReqLevel = 7;
			Name = "Battle Chain Pants";
			Name2 = "Battle Chain Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1177;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 50;
			StaminaBonus = 1;
			StrBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Brackwater Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class BrackwaterLeggings : Item
	{
		public BrackwaterLeggings() : base()
		{
			Id = 3305;
			Resistance[0] = 132;
			Bonding = 2;
			SellPrice = 492;
			AvailableClasses = 0x7FFF;
			Model = 26948;
			ObjectClass = 4;
			SubClass = 3;
			Level = 16;
			ReqLevel = 11;
			Name = "Brackwater Leggings";
			Name2 = "Brackwater Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2463;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 55;
			StaminaBonus = 3;
			AgilityBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Runed Copper Pants)
*
***************************************************************/

namespace Server.Items
{
	public class RunedCopperPants : Item
	{
		public RunedCopperPants() : base()
		{
			Id = 3473;
			Resistance[0] = 113;
			Bonding = 2;
			SellPrice = 299;
			AvailableClasses = 0x7FFF;
			Model = 25849;
			ObjectClass = 4;
			SubClass = 3;
			Level = 13;
			ReqLevel = 8;
			Name = "Runed Copper Pants";
			Name2 = "Runed Copper Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1498;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 50;
			StrBonus = 2;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Mercenary Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class MercenaryLeggings : Item
	{
		public MercenaryLeggings() : base()
		{
			Id = 3751;
			Resistance[0] = 173;
			Bonding = 1;
			SellPrice = 2661;
			AvailableClasses = 0x7FFF;
			Model = 3083;
			ObjectClass = 4;
			SubClass = 3;
			Level = 30;
			Name = "Mercenary Leggings";
			Name2 = "Mercenary Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 13307;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
			StrBonus = 7;
			AgilityBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Double Mail Pants)
*
***************************************************************/

namespace Server.Items
{
	public class DoubleMailPants : Item
	{
		public DoubleMailPants() : base()
		{
			Id = 3813;
			Resistance[0] = 168;
			SellPrice = 1772;
			AvailableClasses = 0x7FFF;
			Model = 687;
			ObjectClass = 4;
			SubClass = 3;
			Level = 35;
			ReqLevel = 30;
			Name = "Double Mail Pants";
			Name2 = "Double Mail Pants";
			AvailableRaces = 0x1FF;
			BuyPrice = 8862;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
		}
	}
}


/**************************************************************
*
*				(Green Iron Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class GreenIronLeggings : Item
	{
		public GreenIronLeggings() : base()
		{
			Id = 3842;
			Resistance[0] = 176;
			Bonding = 2;
			SellPrice = 2906;
			AvailableClasses = 0x7FFF;
			Model = 9415;
			ObjectClass = 4;
			SubClass = 3;
			Level = 31;
			ReqLevel = 26;
			Name = "Green Iron Leggings";
			Name2 = "Green Iron Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 14531;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
			StaminaBonus = 8;
			StrBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Golden Scale Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class GoldenScaleLeggings : Item
	{
		public GoldenScaleLeggings() : base()
		{
			Id = 3843;
			Resistance[0] = 184;
			Bonding = 2;
			SellPrice = 3882;
			AvailableClasses = 0x7FFF;
			Model = 9242;
			ObjectClass = 4;
			SubClass = 3;
			Level = 34;
			ReqLevel = 29;
			Name = "Golden Scale Leggings";
			Name2 = "Golden Scale Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 19413;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
			StrBonus = 11;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Laminated Scale Pants)
*
***************************************************************/

namespace Server.Items
{
	public class LaminatedScalePants : Item
	{
		public LaminatedScalePants() : base()
		{
			Id = 3997;
			Resistance[0] = 238;
			SellPrice = 7929;
			AvailableClasses = 0x7FFF;
			Model = 4339;
			ObjectClass = 4;
			SubClass = 3;
			Level = 56;
			ReqLevel = 51;
			Name = "Laminated Scale Pants";
			Name2 = "Laminated Scale Pants";
			AvailableRaces = 0x1FF;
			BuyPrice = 39648;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
		}
	}
}


/**************************************************************
*
*				(Overlinked Chain Pants)
*
***************************************************************/

namespace Server.Items
{
	public class OverlinkedChainPants : Item
	{
		public OverlinkedChainPants() : base()
		{
			Id = 4005;
			Resistance[0] = 190;
			SellPrice = 3477;
			AvailableClasses = 0x7FFF;
			Model = 4333;
			ObjectClass = 4;
			SubClass = 3;
			Level = 43;
			ReqLevel = 38;
			Name = "Overlinked Chain Pants";
			Name2 = "Overlinked Chain Pants";
			AvailableRaces = 0x1FF;
			BuyPrice = 17389;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
		}
	}
}


/**************************************************************
*
*				(Chief Brigadier Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class ChiefBrigadierLeggings : Item
	{
		public ChiefBrigadierLeggings() : base()
		{
			Id = 4079;
			Resistance[0] = 202;
			Bonding = 2;
			SellPrice = 6753;
			AvailableClasses = 0x7FFF;
			Model = 25896;
			ObjectClass = 4;
			SubClass = 3;
			Level = 40;
			ReqLevel = 35;
			Name = "Chief Brigadier Leggings";
			Name2 = "Chief Brigadier Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 33766;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
			StrBonus = 11;
			IqBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Blackforge Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class BlackforgeLeggings : Item
	{
		public BlackforgeLeggings() : base()
		{
			Id = 4084;
			Resistance[0] = 222;
			Bonding = 2;
			SellPrice = 10136;
			AvailableClasses = 0x7FFF;
			Model = 3409;
			ObjectClass = 4;
			SubClass = 3;
			Level = 46;
			ReqLevel = 41;
			Name = "Blackforge Leggings";
			Name2 = "Blackforge Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 50681;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
			SpiritBonus = 13;
			AgilityBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Iridescent Scale Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class IridescentScaleLeggings : Item
	{
		public IridescentScaleLeggings() : base()
		{
			Id = 4478;
			Resistance[0] = 217;
			Bonding = 2;
			SellPrice = 10176;
			AvailableClasses = 0x7FFF;
			Model = 4744;
			Resistance[2] = 13;
			Resistance[4] = 13;
			ObjectClass = 4;
			SubClass = 3;
			Level = 45;
			ReqLevel = 40;
			Name = "Iridescent Scale Leggings";
			Name2 = "Iridescent Scale Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 50883;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
		}
	}
}


/**************************************************************
*
*				(Stromgarde Cavalry Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class StromgardeCavalryLeggings : Item
	{
		public StromgardeCavalryLeggings() : base()
		{
			Id = 4741;
			Resistance[0] = 192;
			Bonding = 1;
			SellPrice = 5438;
			AvailableClasses = 0x7FFF;
			Model = 4912;
			ObjectClass = 4;
			SubClass = 3;
			Level = 37;
			Name = "Stromgarde Cavalry Leggings";
			Name2 = "Stromgarde Cavalry Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 27194;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
			StrBonus = 8;
			StaminaBonus = 6;
			AgilityBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Mighty Chain Pants)
*
***************************************************************/

namespace Server.Items
{
	public class MightyChainPants : Item
	{
		public MightyChainPants() : base()
		{
			Id = 4800;
			Resistance[0] = 155;
			Bonding = 2;
			SellPrice = 1221;
			AvailableClasses = 0x7FFF;
			Model = 697;
			ObjectClass = 4;
			SubClass = 3;
			Level = 23;
			ReqLevel = 18;
			Name = "Mighty Chain Pants";
			Name2 = "Mighty Chain Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6109;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 65;
			StrBonus = 5;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Legionnaire's Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class LegionnairesLeggings : Item
	{
		public LegionnairesLeggings() : base()
		{
			Id = 4816;
			Resistance[0] = 157;
			Bonding = 2;
			SellPrice = 1503;
			AvailableClasses = 0x7FFF;
			Model = 4978;
			ObjectClass = 4;
			SubClass = 3;
			Level = 24;
			ReqLevel = 19;
			Name = "Legionnaire's Leggings";
			Name2 = "Legionnaire's Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7518;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 65;
			StrBonus = 5;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Battleworn Chain Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class BattlewornChainLeggings : Item
	{
		public BattlewornChainLeggings() : base()
		{
			Id = 4917;
			Resistance[0] = 58;
			Bonding = 1;
			SellPrice = 14;
			AvailableClasses = 0x7FFF;
			Model = 5337;
			ObjectClass = 4;
			SubClass = 3;
			Level = 5;
			Name = "Battleworn Chain Leggings";
			Name2 = "Battleworn Chain Leggings";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 72;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Brass Scale Pants)
*
***************************************************************/

namespace Server.Items
{
	public class BrassScalePants : Item
	{
		public BrassScalePants() : base()
		{
			Id = 5941;
			Resistance[0] = 96;
			Bonding = 1;
			SellPrice = 115;
			AvailableClasses = 0x7FFF;
			Model = 4339;
			ObjectClass = 4;
			SubClass = 3;
			Level = 11;
			Name = "Brass Scale Pants";
			Name2 = "Brass Scale Pants";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 578;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Stormwind Guard Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class StormwindGuardLeggings : Item
	{
		public StormwindGuardLeggings() : base()
		{
			Id = 6084;
			Resistance[0] = 113;
			Bonding = 1;
			SellPrice = 290;
			AvailableClasses = 0x7FFF;
			Model = 9738;
			ObjectClass = 4;
			SubClass = 3;
			Level = 13;
			Name = "Stormwind Guard Leggings";
			Name2 = "Stormwind Guard Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1454;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 50;
			StrBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Chausses of Westfall)
*
***************************************************************/

namespace Server.Items
{
	public class ChaussesOfWestfall : Item
	{
		public ChaussesOfWestfall() : base()
		{
			Id = 6087;
			Resistance[0] = 173;
			Bonding = 1;
			SellPrice = 1727;
			AvailableClasses = 0x7FFF;
			Model = 9742;
			ObjectClass = 4;
			SubClass = 3;
			Level = 24;
			Name = "Chausses of Westfall";
			Name2 = "Chausses of Westfall";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 8639;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
			StaminaBonus = 5;
			StrBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Infantry Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class InfantryLeggings : Item
	{
		public InfantryLeggings() : base()
		{
			Id = 6337;
			Resistance[0] = 107;
			Bonding = 2;
			SellPrice = 245;
			AvailableClasses = 0x7FFF;
			Model = 3058;
			ObjectClass = 4;
			SubClass = 3;
			Level = 12;
			ReqLevel = 7;
			Name = "Infantry Leggings";
			Name2 = "Infantry Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 580;
			BuyPrice = 1225;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Glimmering Mail Legguards)
*
***************************************************************/

namespace Server.Items
{
	public class GlimmeringMailLegguards : Item
	{
		public GlimmeringMailLegguards() : base()
		{
			Id = 6386;
			Resistance[0] = 173;
			Bonding = 2;
			SellPrice = 2692;
			AvailableClasses = 0x7FFF;
			Model = 25805;
			ObjectClass = 4;
			SubClass = 3;
			Level = 30;
			ReqLevel = 25;
			Name = "Glimmering Mail Legguards";
			Name2 = "Glimmering Mail Legguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 13462;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
			StrBonus = 8;
			AgilityBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Mail Combat Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class MailCombatLeggings : Item
	{
		public MailCombatLeggings() : base()
		{
			Id = 6402;
			Resistance[0] = 189;
			Bonding = 2;
			SellPrice = 4699;
			AvailableClasses = 0x7FFF;
			Model = 25812;
			ObjectClass = 4;
			SubClass = 3;
			Level = 36;
			ReqLevel = 31;
			Name = "Mail Combat Leggings";
			Name2 = "Mail Combat Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 23496;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
			StrBonus = 9;
			IqBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Soldier's Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class SoldiersLeggings : Item
	{
		public SoldiersLeggings() : base()
		{
			Id = 6546;
			Resistance[0] = 139;
			Bonding = 2;
			SellPrice = 533;
			AvailableClasses = 0x7FFF;
			Model = 25759;
			ObjectClass = 4;
			SubClass = 3;
			Level = 17;
			ReqLevel = 12;
			Name = "Soldier's Leggings";
			Name2 = "Soldier's Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 582;
			BuyPrice = 2668;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Defender Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class DefenderLeggings : Item
	{
		public DefenderLeggings() : base()
		{
			Id = 6578;
			Resistance[0] = 155;
			Bonding = 2;
			SellPrice = 1302;
			AvailableClasses = 0x7FFF;
			Model = 12453;
			ObjectClass = 4;
			SubClass = 3;
			Level = 23;
			ReqLevel = 18;
			Name = "Defender Leggings";
			Name2 = "Defender Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 584;
			BuyPrice = 6514;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Battleforge Legguards)
*
***************************************************************/

namespace Server.Items
{
	public class BattleforgeLegguards : Item
	{
		public BattleforgeLegguards() : base()
		{
			Id = 6596;
			Resistance[0] = 168;
			Bonding = 2;
			SellPrice = 2258;
			AvailableClasses = 0x7FFF;
			Model = 25796;
			ObjectClass = 4;
			SubClass = 3;
			Level = 28;
			ReqLevel = 23;
			Name = "Battleforge Legguards";
			Name2 = "Battleforge Legguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 586;
			BuyPrice = 11290;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
		}
	}
}


/**************************************************************
*
*				(Juggernaut Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class JuggernautLeggings : Item
	{
		public JuggernautLeggings() : base()
		{
			Id = 6671;
			Resistance[0] = 165;
			Bonding = 1;
			SellPrice = 2068;
			AvailableClasses = 0x7FFF;
			Model = 12795;
			ObjectClass = 4;
			SubClass = 3;
			Level = 27;
			Name = "Juggernaut Leggings";
			Name2 = "Juggernaut Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 10341;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 70;
			StrBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Fire Hardened Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class FireHardenedLeggings : Item
	{
		public FireHardenedLeggings() : base()
		{
			Id = 6973;
			Resistance[0] = 171;
			Bonding = 1;
			SellPrice = 2465;
			AvailableClasses = 0x01;
			Model = 22481;
			ObjectClass = 4;
			SubClass = 3;
			Level = 29;
			Name = "Fire Hardened Leggings";
			Name2 = "Fire Hardened Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 12326;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
			StrBonus = 7;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Brutal Legguards)
*
***************************************************************/

namespace Server.Items
{
	public class BrutalLegguards : Item
	{
		public BrutalLegguards() : base()
		{
			Id = 7132;
			Resistance[0] = 171;
			Bonding = 1;
			SellPrice = 2338;
			AvailableClasses = 0x01;
			Model = 3541;
			ObjectClass = 4;
			SubClass = 3;
			Level = 29;
			Name = "Brutal Legguards";
			Name2 = "Brutal Legguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11692;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
			StrBonus = 7;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Phalanx Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class PhalanxLeggings : Item
	{
		public PhalanxLeggings() : base()
		{
			Id = 7423;
			Resistance[0] = 184;
			Bonding = 2;
			SellPrice = 3941;
			AvailableClasses = 0x7FFF;
			Model = 26039;
			ObjectClass = 4;
			SubClass = 3;
			Level = 34;
			ReqLevel = 29;
			Name = "Phalanx Leggings";
			Name2 = "Phalanx Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 588;
			BuyPrice = 19709;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
		}
	}
}


/**************************************************************
*
*				(Knight's Legguards)
*
***************************************************************/

namespace Server.Items
{
	public class KnightsLegguards : Item
	{
		public KnightsLegguards() : base()
		{
			Id = 7455;
			Resistance[0] = 199;
			Bonding = 2;
			SellPrice = 5937;
			AvailableClasses = 0x7FFF;
			Model = 25868;
			ObjectClass = 4;
			SubClass = 3;
			Level = 39;
			ReqLevel = 34;
			Name = "Knight's Legguards";
			Name2 = "Knight's Legguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 589;
			BuyPrice = 29688;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
		}
	}
}


/**************************************************************
*
*				(Captain's Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class CaptainsLeggings : Item
	{
		public CaptainsLeggings() : base()
		{
			Id = 7487;
			Resistance[0] = 211;
			Bonding = 2;
			SellPrice = 8665;
			AvailableClasses = 0x7FFF;
			Model = 25820;
			ObjectClass = 4;
			SubClass = 3;
			Level = 43;
			ReqLevel = 38;
			Name = "Captain's Leggings";
			Name2 = "Captain's Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 591;
			BuyPrice = 43328;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
		}
	}
}


/**************************************************************
*
*				(Champion's Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class ChampionsLeggings : Item
	{
		public ChampionsLeggings() : base()
		{
			Id = 7539;
			Resistance[0] = 230;
			Bonding = 2;
			SellPrice = 12692;
			AvailableClasses = 0x7FFF;
			Model = 3193;
			ObjectClass = 4;
			SubClass = 3;
			Level = 48;
			ReqLevel = 43;
			Name = "Champion's Leggings";
			Name2 = "Champion's Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 592;
			BuyPrice = 63461;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
		}
	}
}


/**************************************************************
*
*				(Mithril Scale Pants)
*
***************************************************************/

namespace Server.Items
{
	public class MithrilScalePants : Item
	{
		public MithrilScalePants() : base()
		{
			Id = 7920;
			Resistance[0] = 208;
			Bonding = 2;
			SellPrice = 8053;
			AvailableClasses = 0x7FFF;
			Model = 3409;
			ObjectClass = 4;
			SubClass = 3;
			Level = 42;
			ReqLevel = 37;
			Name = "Mithril Scale Pants";
			Name2 = "Mithril Scale Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 40265;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
			SetSpell( 13669 , 1 , 0 , -1 , 0 , -1 );
			IqBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Orcish War Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class OrcishWarLeggings : Item
	{
		public OrcishWarLeggings() : base()
		{
			Id = 7929;
			Resistance[0] = 208;
			Bonding = 2;
			SellPrice = 7739;
			AvailableClasses = 0x7FFF;
			Model = 23538;
			ObjectClass = 4;
			SubClass = 3;
			Level = 42;
			ReqLevel = 37;
			Name = "Orcish War Leggings";
			Name2 = "Orcish War Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 38698;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
			StrBonus = 17;
		}
	}
}


/**************************************************************
*
*				(Myrmidon's Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class MyrmidonsLeggings : Item
	{
		public MyrmidonsLeggings() : base()
		{
			Id = 8132;
			Resistance[0] = 243;
			Bonding = 2;
			SellPrice = 14485;
			AvailableClasses = 0x7FFF;
			Model = 26110;
			ObjectClass = 4;
			SubClass = 3;
			Level = 51;
			ReqLevel = 46;
			Name = "Myrmidon's Leggings";
			Name2 = "Myrmidon's Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 72426;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
			AgilityBonus = 14;
			IqBonus = 14;
		}
	}
}


/**************************************************************
*
*				(Turtle Scale Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class TurtleScaleLeggings : Item
	{
		public TurtleScaleLeggings() : base()
		{
			Id = 8185;
			Resistance[0] = 226;
			Bonding = 2;
			SellPrice = 10952;
			AvailableClasses = 0x7FFF;
			Model = 16487;
			ObjectClass = 4;
			SubClass = 3;
			Level = 47;
			ReqLevel = 42;
			Name = "Turtle Scale Leggings";
			Name2 = "Turtle Scale Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 54764;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
			StaminaBonus = 11;
			IqBonus = 11;
			SpiritBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Tough Scorpid Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class ToughScorpidLeggings : Item
	{
		public ToughScorpidLeggings() : base()
		{
			Id = 8206;
			Resistance[0] = 235;
			Bonding = 2;
			SellPrice = 12704;
			AvailableClasses = 0x7FFF;
			Model = 16517;
			ObjectClass = 4;
			SubClass = 3;
			Level = 49;
			ReqLevel = 44;
			Name = "Tough Scorpid Leggings";
			Name2 = "Tough Scorpid Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 63521;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
			AgilityBonus = 17;
			IqBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Ebonhold Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class EbonholdLeggings : Item
	{
		public EbonholdLeggings() : base()
		{
			Id = 8271;
			Resistance[0] = 265;
			Bonding = 2;
			SellPrice = 20358;
			AvailableClasses = 0x7FFF;
			Model = 21694;
			ObjectClass = 4;
			SubClass = 3;
			Level = 56;
			ReqLevel = 51;
			Name = "Ebonhold Leggings";
			Name2 = "Ebonhold Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 101790;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
			StaminaBonus = 14;
			AgilityBonus = 5;
			IqBonus = 14;
		}
	}
}


/**************************************************************
*
*				(Hero's Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class HerosLeggings : Item
	{
		public HerosLeggings() : base()
		{
			Id = 8309;
			Resistance[0] = 286;
			Bonding = 2;
			SellPrice = 26278;
			AvailableClasses = 0x7FFF;
			Model = 26317;
			ObjectClass = 4;
			SubClass = 3;
			Level = 61;
			ReqLevel = 56;
			Name = "Hero's Leggings";
			Name2 = "Hero's Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 131394;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
			AgilityBonus = 18;
			IqBonus = 17;
		}
	}
}


/**************************************************************
*
*				(Legguards of the Vault)
*
***************************************************************/

namespace Server.Items
{
	public class LegguardsOfTheVault : Item
	{
		public LegguardsOfTheVault() : base()
		{
			Id = 9396;
			Resistance[0] = 218;
			Bonding = 2;
			SellPrice = 7319;
			AvailableClasses = 0x7FFF;
			Model = 18274;
			ObjectClass = 4;
			SubClass = 3;
			Level = 39;
			ReqLevel = 34;
			Name = "Legguards of the Vault";
			Name2 = "Legguards of the Vault";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 36596;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 90;
			AgilityBonus = 5;
			StrBonus = 13;
			StaminaBonus = 13;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Barkmail Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class BarkmailLeggings : Item
	{
		public BarkmailLeggings() : base()
		{
			Id = 9599;
			Resistance[0] = 94;
			Bonding = 1;
			SellPrice = 142;
			AvailableClasses = 0x7FFF;
			Model = 26948;
			ObjectClass = 4;
			SubClass = 3;
			Level = 10;
			Name = "Barkmail Leggings";
			Name2 = "Barkmail Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 713;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 50;
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Dual Reinforced Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class DualReinforcedLeggings : Item
	{
		public DualReinforcedLeggings() : base()
		{
			Id = 9625;
			Resistance[0] = 391;
			Bonding = 1;
			SellPrice = 6344;
			AvailableClasses = 0x7FFF;
			Model = 28317;
			ObjectClass = 4;
			SubClass = 3;
			Level = 37;
			Name = "Dual Reinforced Leggings";
			Name2 = "Dual Reinforced Leggings";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 31721;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 90;
			SetSpell( 7518 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Cadet Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class CadetLeggings : Item
	{
		public CadetLeggings() : base()
		{
			Id = 9763;
			Resistance[0] = 119;
			Bonding = 2;
			SellPrice = 336;
			AvailableClasses = 0x7FFF;
			Model = 22687;
			ObjectClass = 4;
			SubClass = 3;
			Level = 14;
			ReqLevel = 9;
			Name = "Cadet Leggings";
			Name2 = "Cadet Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 581;
			BuyPrice = 1681;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Raider's Legguards)
*
***************************************************************/

namespace Server.Items
{
	public class RaidersLegguards : Item
	{
		public RaidersLegguards() : base()
		{
			Id = 9789;
			Resistance[0] = 144;
			Bonding = 2;
			SellPrice = 741;
			AvailableClasses = 0x7FFF;
			Model = 3541;
			ObjectClass = 4;
			SubClass = 3;
			Level = 19;
			ReqLevel = 14;
			Name = "Raider's Legguards";
			Name2 = "Raider's Legguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 583;
			BuyPrice = 3709;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Fortified Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class FortifiedLeggings : Item
	{
		public FortifiedLeggings() : base()
		{
			Id = 9815;
			Resistance[0] = 160;
			Bonding = 2;
			SellPrice = 1664;
			AvailableClasses = 0x7FFF;
			Model = 697;
			ObjectClass = 4;
			SubClass = 3;
			Level = 25;
			ReqLevel = 20;
			Name = "Fortified Leggings";
			Name2 = "Fortified Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 585;
			BuyPrice = 8320;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Banded Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class BandedLeggings : Item
	{
		public BandedLeggings() : base()
		{
			Id = 9841;
			Resistance[0] = 179;
			Bonding = 2;
			SellPrice = 3163;
			AvailableClasses = 0x7FFF;
			Model = 27770;
			ObjectClass = 4;
			SubClass = 3;
			Level = 32;
			ReqLevel = 27;
			Name = "Banded Leggings";
			Name2 = "Banded Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 587;
			BuyPrice = 15815;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
		}
	}
}


/**************************************************************
*
*				(Renegade Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class RenegadeLeggings : Item
	{
		public RenegadeLeggings() : base()
		{
			Id = 9871;
			Resistance[0] = 192;
			Bonding = 2;
			SellPrice = 5425;
			AvailableClasses = 0x7FFF;
			Model = 26249;
			ObjectClass = 4;
			SubClass = 3;
			Level = 37;
			ReqLevel = 32;
			Name = "Renegade Leggings";
			Name2 = "Renegade Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 589;
			BuyPrice = 27128;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
		}
	}
}


/**************************************************************
*
*				(Jazeraint Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class JazeraintLeggings : Item
	{
		public JazeraintLeggings() : base()
		{
			Id = 9903;
			Resistance[0] = 208;
			Bonding = 2;
			SellPrice = 7742;
			AvailableClasses = 0x7FFF;
			Model = 26163;
			ObjectClass = 4;
			SubClass = 3;
			Level = 42;
			ReqLevel = 37;
			Name = "Jazeraint Leggings";
			Name2 = "Jazeraint Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 590;
			BuyPrice = 38714;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
		}
	}
}


/**************************************************************
*
*				(Brigade Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class BrigadeLeggings : Item
	{
		public BrigadeLeggings() : base()
		{
			Id = 9933;
			Resistance[0] = 217;
			Bonding = 2;
			SellPrice = 9394;
			AvailableClasses = 0x7FFF;
			Model = 25934;
			ObjectClass = 4;
			SubClass = 3;
			Level = 45;
			ReqLevel = 40;
			Name = "Brigade Leggings";
			Name2 = "Brigade Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 591;
			BuyPrice = 46970;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
		}
	}
}


/**************************************************************
*
*				(Warmonger's Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class WarmongersLeggings : Item
	{
		public WarmongersLeggings() : base()
		{
			Id = 9964;
			Resistance[0] = 235;
			Bonding = 2;
			SellPrice = 13190;
			AvailableClasses = 0x7FFF;
			Model = 26191;
			ObjectClass = 4;
			SubClass = 3;
			Level = 49;
			ReqLevel = 44;
			Name = "Warmonger's Leggings";
			Name2 = "Warmonger's Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 593;
			BuyPrice = 65952;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
		}
	}
}


/**************************************************************
*
*				(Lord's Legguards)
*
***************************************************************/

namespace Server.Items
{
	public class LordsLegguards : Item
	{
		public LordsLegguards() : base()
		{
			Id = 10084;
			Resistance[0] = 248;
			Bonding = 2;
			SellPrice = 15246;
			AvailableClasses = 0x7FFF;
			Model = 19720;
			ObjectClass = 4;
			SubClass = 3;
			Level = 52;
			ReqLevel = 47;
			Name = "Lord's Legguards";
			Name2 = "Lord's Legguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 594;
			BuyPrice = 76231;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
		}
	}
}


/**************************************************************
*
*				(Ornate Legguards)
*
***************************************************************/

namespace Server.Items
{
	public class OrnateLegguards : Item
	{
		public OrnateLegguards() : base()
		{
			Id = 10124;
			Resistance[0] = 269;
			Bonding = 2;
			SellPrice = 20396;
			AvailableClasses = 0x7FFF;
			Model = 19708;
			ObjectClass = 4;
			SubClass = 3;
			Level = 57;
			ReqLevel = 52;
			Name = "Ornate Legguards";
			Name2 = "Ornate Legguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 595;
			BuyPrice = 101982;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
		}
	}
}


/**************************************************************
*
*				(Mercurial Legguards)
*
***************************************************************/

namespace Server.Items
{
	public class MercurialLegguards : Item
	{
		public MercurialLegguards() : base()
		{
			Id = 10162;
			Resistance[0] = 295;
			Bonding = 2;
			SellPrice = 28137;
			AvailableClasses = 0x7FFF;
			Model = 26130;
			ObjectClass = 4;
			SubClass = 3;
			Level = 63;
			ReqLevel = 58;
			Name = "Mercurial Legguards";
			Name2 = "Mercurial Legguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 597;
			BuyPrice = 140688;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
		}
	}
}


/**************************************************************
*
*				(Crusader's Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class CrusadersLeggings : Item
	{
		public CrusadersLeggings() : base()
		{
			Id = 10199;
			Resistance[0] = 256;
			Bonding = 2;
			SellPrice = 17261;
			AvailableClasses = 0x7FFF;
			Model = 26163;
			ObjectClass = 4;
			SubClass = 3;
			Level = 54;
			ReqLevel = 49;
			Name = "Crusader's Leggings";
			Name2 = "Crusader's Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 594;
			BuyPrice = 86305;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
		}
	}
}


/**************************************************************
*
*				(Engraved Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class EngravedLeggings : Item
	{
		public EngravedLeggings() : base()
		{
			Id = 10236;
			Resistance[0] = 278;
			Bonding = 2;
			SellPrice = 22615;
			AvailableClasses = 0x7FFF;
			Model = 26272;
			ObjectClass = 4;
			SubClass = 3;
			Level = 59;
			ReqLevel = 54;
			Name = "Engraved Leggings";
			Name2 = "Engraved Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 596;
			BuyPrice = 113079;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
		}
	}
}


/**************************************************************
*
*				(Masterwork Legplates)
*
***************************************************************/

namespace Server.Items
{
	public class MasterworkLegplates : Item
	{
		public MasterworkLegplates() : base()
		{
			Id = 10273;
			Resistance[0] = 299;
			Bonding = 2;
			SellPrice = 29323;
			AvailableClasses = 0x7FFF;
			Model = 26248;
			ObjectClass = 4;
			SubClass = 3;
			Level = 64;
			ReqLevel = 59;
			Name = "Masterwork Legplates";
			Name2 = "Masterwork Legplates";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 598;
			BuyPrice = 146619;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
		}
	}
}


/**************************************************************
*
*				(Scarlet Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class ScarletLeggings : Item
	{
		public ScarletLeggings() : base()
		{
			Id = 10330;
			Resistance[0] = 233;
			Bonding = 1;
			SellPrice = 9587;
			AvailableClasses = 0x7FFF;
			Model = 3519;
			ObjectClass = 4;
			SubClass = 3;
			Level = 43;
			ReqLevel = 38;
			Name = "Scarlet Leggings";
			Name2 = "Scarlet Leggings";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 47938;
			Sets = 163;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 90;
			StrBonus = 20;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Silvered Bronze Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class SilveredBronzeLeggings : Item
	{
		public SilveredBronzeLeggings() : base()
		{
			Id = 10423;
			Resistance[0] = 176;
			Bonding = 2;
			SellPrice = 2842;
			AvailableClasses = 0x7FFF;
			Model = 19201;
			ObjectClass = 4;
			SubClass = 3;
			Level = 31;
			ReqLevel = 26;
			Name = "Silvered Bronze Leggings";
			Name2 = "Silvered Bronze Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 14211;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
			StrBonus = 7;
			StaminaBonus = 6;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Painted Chain Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class PaintedChainLeggings : Item
	{
		public PaintedChainLeggings() : base()
		{
			Id = 10635;
			Resistance[0] = 58;
			Bonding = 1;
			SellPrice = 14;
			AvailableClasses = 0x7FFF;
			Model = 28230;
			ObjectClass = 4;
			SubClass = 3;
			Level = 5;
			Name = "Painted Chain Leggings";
			Name2 = "Painted Chain Leggings";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 73;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Savage Gladiator Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class SavageGladiatorLeggings : Item
	{
		public SavageGladiatorLeggings() : base()
		{
			Id = 11728;
			Resistance[0] = 296;
			Bonding = 1;
			SellPrice = 25336;
			AvailableClasses = 0x7FFF;
			Model = 21694;
			ObjectClass = 4;
			SubClass = 3;
			Level = 57;
			ReqLevel = 52;
			Name = "Savage Gladiator Leggings";
			Name2 = "Savage Gladiator Leggings";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 126681;
			Sets = 1;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 90;
			StaminaBonus = 19;
			IqBonus = 18;
			StrBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Searingscale Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class SearingscaleLeggings : Item
	{
		public SearingscaleLeggings() : base()
		{
			Id = 11749;
			Resistance[0] = 277;
			Bonding = 1;
			SellPrice = 20141;
			AvailableClasses = 0x7FFF;
			Model = 28722;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 3;
			Level = 53;
			ReqLevel = 48;
			Name = "Searingscale Leggings";
			Name2 = "Searingscale Leggings";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 100708;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 90;
			IqBonus = 25;
			SpiritBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Roamer's Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class RoamersLeggings : Item
	{
		public RoamersLeggings() : base()
		{
			Id = 11852;
			Resistance[0] = 58;
			Bonding = 1;
			SellPrice = 14;
			AvailableClasses = 0x7FFF;
			Model = 19575;
			ObjectClass = 4;
			SubClass = 3;
			Level = 5;
			Name = "Roamer's Leggings";
			Name2 = "Roamer's Leggings";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 71;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Outrider Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class OutriderLeggings : Item
	{
		public OutriderLeggings() : base()
		{
			Id = 11882;
			Resistance[0] = 265;
			Bonding = 1;
			SellPrice = 20520;
			AvailableClasses = 0x7FFF;
			Model = 27770;
			ObjectClass = 4;
			SubClass = 3;
			Level = 56;
			Name = "Outrider Leggings";
			Name2 = "Outrider Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 102603;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
			StrBonus = 16;
			StaminaBonus = 16;
		}
	}
}


/**************************************************************
*
*				(Radiant Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class RadiantLeggings : Item
	{
		public RadiantLeggings() : base()
		{
			Id = 12420;
			Resistance[0] = 286;
			Bonding = 2;
			SellPrice = 25330;
			AvailableClasses = 0x7FFF;
			Model = 25745;
			Resistance[4] = 18;
			ObjectClass = 4;
			SubClass = 3;
			Level = 61;
			ReqLevel = 56;
			Name = "Radiant Leggings";
			Name2 = "Radiant Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 126654;
			Resistance[5] = 18;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
		}
	}
}


/**************************************************************
*
*				(Legguards of the Chromatic Defier)
*
***************************************************************/

namespace Server.Items
{
	public class LegguardsOfTheChromaticDefier : Item
	{
		public LegguardsOfTheChromaticDefier() : base()
		{
			Id = 12903;
			Resistance[6] = 5;
			Resistance[0] = 349;
			Bonding = 1;
			SellPrice = 45482;
			AvailableClasses = 0x7FFF;
			Model = 23473;
			Resistance[2] = 5;
			Resistance[4] = 5;
			ObjectClass = 4;
			SubClass = 3;
			Level = 62;
			Name = "Legguards of the Chromatic Defier";
			Name2 = "Legguards of the Chromatic Defier";
			Resistance[3] = 5;
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 227412;
			Resistance[5] = 5;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 105;
			AgilityBonus = 33;
			StrBonus = 9;
			StaminaBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Legplates of the Chromatic Defier)
*
***************************************************************/

namespace Server.Items
{
	public class LegplatesOfTheChromaticDefier : Item
	{
		public LegplatesOfTheChromaticDefier() : base()
		{
			Id = 12945;
			Resistance[6] = 5;
			Resistance[0] = 349;
			Bonding = 1;
			SellPrice = 42565;
			AvailableClasses = 0x7FFF;
			Model = 23473;
			Resistance[2] = 5;
			Resistance[4] = 5;
			ObjectClass = 4;
			SubClass = 3;
			Level = 62;
			Name = "Legplates of the Chromatic Defier";
			Name2 = "Legplates of the Chromatic Defier";
			Resistance[3] = 5;
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 212825;
			Resistance[5] = 5;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 105;
			SpiritBonus = 19;
			IqBonus = 26;
			StaminaBonus = 16;
		}
	}
}


/**************************************************************
*
*				(Tristam Legguards)
*
***************************************************************/

namespace Server.Items
{
	public class TristamLegguards : Item
	{
		public TristamLegguards() : base()
		{
			Id = 12964;
			Resistance[0] = 324;
			Bonding = 1;
			SellPrice = 33388;
			AvailableClasses = 0x7FFF;
			Model = 23548;
			ObjectClass = 4;
			SubClass = 3;
			Level = 63;
			ReqLevel = 58;
			Name = "Tristam Legguards";
			Name2 = "Tristam Legguards";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 166942;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 90;
			SetSpell( 15806 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 13670 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Dreamsinger Legguards)
*
***************************************************************/

namespace Server.Items
{
	public class DreamsingerLegguards : Item
	{
		public DreamsingerLegguards() : base()
		{
			Id = 13010;
			Resistance[0] = 179;
			Bonding = 2;
			SellPrice = 2241;
			AvailableClasses = 0x7FFF;
			Model = 28438;
			ObjectClass = 4;
			SubClass = 3;
			Level = 26;
			ReqLevel = 21;
			Name = "Dreamsinger Legguards";
			Name2 = "Dreamsinger Legguards";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 11207;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 80;
			IqBonus = 5;
			StaminaBonus = 8;
			StrBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Firemane Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class FiremaneLeggings : Item
	{
		public FiremaneLeggings() : base()
		{
			Id = 13129;
			Resistance[0] = 218;
			Bonding = 2;
			SellPrice = 7621;
			AvailableClasses = 0x7FFF;
			Model = 28437;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 3;
			Level = 39;
			ReqLevel = 34;
			Name = "Firemane Leggings";
			Name2 = "Firemane Leggings";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 38107;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 90;
			StrBonus = 19;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Windrunner Legguards)
*
***************************************************************/

namespace Server.Items
{
	public class WindrunnerLegguards : Item
	{
		public WindrunnerLegguards() : base()
		{
			Id = 13130;
			Resistance[0] = 291;
			Bonding = 2;
			SellPrice = 25065;
			AvailableClasses = 0x7FFF;
			Model = 28447;
			ObjectClass = 4;
			SubClass = 3;
			Level = 56;
			ReqLevel = 51;
			Name = "Windrunner Legguards";
			Name2 = "Windrunner Legguards";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 125329;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 90;
			AgilityBonus = 27;
			IqBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Woollies of the Prancing Minstrel)
*
***************************************************************/

namespace Server.Items
{
	public class WoolliesOfThePrancingMinstrel : Item
	{
		public WoolliesOfThePrancingMinstrel() : base()
		{
			Id = 13383;
			Resistance[0] = 301;
			Bonding = 1;
			SellPrice = 26864;
			AvailableClasses = 0x7FFF;
			Model = 24070;
			ObjectClass = 4;
			SubClass = 3;
			Level = 58;
			ReqLevel = 53;
			Name = "Woollies of the Prancing Minstrel";
			Name2 = "Woollies of the Prancing Minstrel";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 134323;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 90;
			SetSpell( 13670 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 10;
			IqBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Maelstrom Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class MaelstromLeggings : Item
	{
		public MaelstromLeggings() : base()
		{
			Id = 14522;
			Resistance[0] = 320;
			Bonding = 1;
			SellPrice = 31318;
			AvailableClasses = 0x7FFF;
			Model = 25111;
			ObjectClass = 4;
			SubClass = 3;
			Level = 62;
			ReqLevel = 57;
			Name = "Maelstrom Leggings";
			Name2 = "Maelstrom Leggings";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 156591;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 90;
			AgilityBonus = 6;
			IqBonus = 20;
			SpiritBonus = 20;
			StrBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Bloodmail Legguards)
*
***************************************************************/

namespace Server.Items
{
	public class BloodmailLegguards : Item
	{
		public BloodmailLegguards() : base()
		{
			Id = 14612;
			Resistance[0] = 286;
			Bonding = 1;
			SellPrice = 27185;
			AvailableClasses = 0x7FFF;
			Model = 25223;
			ObjectClass = 4;
			SubClass = 3;
			Level = 61;
			ReqLevel = 56;
			Name = "Bloodmail Legguards";
			Name2 = "Bloodmail Legguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 135925;
			Sets = 123;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
			IqBonus = 25;
			StaminaBonus = 6;
			StrBonus = 3;
		}
	}
}


/**************************************************************
*
*				(War Paint Legguards)
*
***************************************************************/

namespace Server.Items
{
	public class WarPaintLegguards : Item
	{
		public WarPaintLegguards() : base()
		{
			Id = 14727;
			Resistance[0] = 144;
			Bonding = 2;
			SellPrice = 778;
			AvailableClasses = 0x7FFF;
			Model = 26986;
			ObjectClass = 4;
			SubClass = 3;
			Level = 19;
			ReqLevel = 14;
			Name = "War Paint Legguards";
			Name2 = "War Paint Legguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3890;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			StaminaBonus = 4;
			StrBonus = 3;
			AgilityBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Hulking Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class HulkingLeggings : Item
	{
		public HulkingLeggings() : base()
		{
			Id = 14748;
			Resistance[0] = 160;
			Bonding = 2;
			SellPrice = 1550;
			AvailableClasses = 0x7FFF;
			Model = 27013;
			ObjectClass = 4;
			SubClass = 3;
			Level = 25;
			ReqLevel = 20;
			Name = "Hulking Leggings";
			Name2 = "Hulking Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7752;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 70;
			StrBonus = 8;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Slayer's Pants)
*
***************************************************************/

namespace Server.Items
{
	public class SlayersPants : Item
	{
		public SlayersPants() : base()
		{
			Id = 14757;
			Resistance[0] = 179;
			Bonding = 2;
			SellPrice = 3298;
			AvailableClasses = 0x7FFF;
			Model = 27028;
			ObjectClass = 4;
			SubClass = 3;
			Level = 32;
			ReqLevel = 27;
			Name = "Slayer's Pants";
			Name2 = "Slayer's Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 16491;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
			StrBonus = 11;
			StaminaBonus = 3;
			IqBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Enduring Breeches)
*
***************************************************************/

namespace Server.Items
{
	public class EnduringBreeches : Item
	{
		public EnduringBreeches() : base()
		{
			Id = 14766;
			Resistance[0] = 192;
			Bonding = 2;
			SellPrice = 5486;
			AvailableClasses = 0x7FFF;
			Model = 27050;
			ObjectClass = 4;
			SubClass = 3;
			Level = 37;
			ReqLevel = 32;
			Name = "Enduring Breeches";
			Name2 = "Enduring Breeches";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 27430;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
			StrBonus = 8;
			StaminaBonus = 6;
			AgilityBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Ravager's Woolies)
*
***************************************************************/

namespace Server.Items
{
	public class RavagersWoolies : Item
	{
		public RavagersWoolies() : base()
		{
			Id = 14775;
			Resistance[0] = 211;
			Bonding = 2;
			SellPrice = 8367;
			AvailableClasses = 0x7FFF;
			Model = 27097;
			ObjectClass = 4;
			SubClass = 3;
			Level = 43;
			ReqLevel = 38;
			Name = "Ravager's Woolies";
			Name2 = "Ravager's Woolies";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 41836;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
			StaminaBonus = 10;
			IqBonus = 9;
			StrBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Khan's Legguards)
*
***************************************************************/

namespace Server.Items
{
	public class KhansLegguards : Item
	{
		public KhansLegguards() : base()
		{
			Id = 14786;
			Resistance[0] = 226;
			Bonding = 2;
			SellPrice = 11841;
			AvailableClasses = 0x7FFF;
			Model = 27150;
			ObjectClass = 4;
			SubClass = 3;
			Level = 47;
			ReqLevel = 42;
			Name = "Khan's Legguards";
			Name2 = "Khan's Legguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 59209;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
			StaminaBonus = 14;
			AgilityBonus = 11;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Protector Legguards)
*
***************************************************************/

namespace Server.Items
{
	public class ProtectorLegguards : Item
	{
		public ProtectorLegguards() : base()
		{
			Id = 14796;
			Resistance[0] = 252;
			Bonding = 2;
			SellPrice = 16983;
			AvailableClasses = 0x7FFF;
			Model = 27157;
			ObjectClass = 4;
			SubClass = 3;
			Level = 53;
			ReqLevel = 48;
			Name = "Protector Legguards";
			Name2 = "Protector Legguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 84917;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
			IqBonus = 21;
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Bloodlust Britches)
*
***************************************************************/

namespace Server.Items
{
	public class BloodlustBritches : Item
	{
		public BloodlustBritches() : base()
		{
			Id = 14805;
			Resistance[0] = 269;
			Bonding = 2;
			SellPrice = 20577;
			AvailableClasses = 0x7FFF;
			Model = 27195;
			ObjectClass = 4;
			SubClass = 3;
			Level = 57;
			ReqLevel = 52;
			Name = "Bloodlust Britches";
			Name2 = "Bloodlust Britches";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 102886;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
			StaminaBonus = 15;
			SpiritBonus = 7;
			IqBonus = 14;
		}
	}
}


/**************************************************************
*
*				(Warstrike Legguards)
*
***************************************************************/

namespace Server.Items
{
	public class WarstrikeLegguards : Item
	{
		public WarstrikeLegguards() : base()
		{
			Id = 14816;
			Resistance[0] = 290;
			Bonding = 2;
			SellPrice = 27620;
			AvailableClasses = 0x7FFF;
			Model = 27140;
			ObjectClass = 4;
			SubClass = 3;
			Level = 62;
			ReqLevel = 57;
			Name = "Warstrike Legguards";
			Name2 = "Warstrike Legguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 138101;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
			IqBonus = 22;
			StaminaBonus = 10;
			SpiritBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Green Dragonscale Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class GreenDragonscaleLeggings : Item
	{
		public GreenDragonscaleLeggings() : base()
		{
			Id = 15046;
			Resistance[0] = 282;
			Bonding = 2;
			SellPrice = 22482;
			AvailableClasses = 0x7FFF;
			Model = 25673;
			ObjectClass = 4;
			SubClass = 3;
			Level = 54;
			ReqLevel = 49;
			Name = "Green Dragonscale Leggings";
			Name2 = "Green Dragonscale Leggings";
			Resistance[3] = 11;
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 112410;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 90;
			IqBonus = 26;
		}
	}
}


/**************************************************************
*
*				(Black Dragonscale Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class BlackDragonscaleLeggings : Item
	{
		public BlackDragonscaleLeggings() : base()
		{
			Id = 15052;
			Resistance[0] = 320;
			Bonding = 2;
			SellPrice = 31933;
			AvailableClasses = 0x7FFF;
			Model = 27944;
			Resistance[2] = 13;
			ObjectClass = 4;
			SubClass = 3;
			Level = 62;
			ReqLevel = 57;
			Name = "Black Dragonscale Leggings";
			Name2 = "Black Dragonscale Leggings";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 159667;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 90;
			SetSpell( 15813 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Heavy Scorpid Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyScorpidLeggings : Item
	{
		public HeavyScorpidLeggings() : base()
		{
			Id = 15079;
			Resistance[0] = 269;
			Bonding = 2;
			SellPrice = 21760;
			AvailableClasses = 0x7FFF;
			Model = 25714;
			ObjectClass = 4;
			SubClass = 3;
			Level = 57;
			ReqLevel = 52;
			Name = "Heavy Scorpid Leggings";
			Name2 = "Heavy Scorpid Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 108803;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
			IqBonus = 20;
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Guststorm Legguards)
*
***************************************************************/

namespace Server.Items
{
	public class GuststormLegguards : Item
	{
		public GuststormLegguards() : base()
		{
			Id = 15203;
			Resistance[0] = 141;
			Bonding = 1;
			SellPrice = 621;
			AvailableClasses = 0x7FFF;
			Model = 28189;
			ObjectClass = 4;
			SubClass = 3;
			Level = 18;
			Name = "Guststorm Legguards";
			Name2 = "Guststorm Legguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3107;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			StrBonus = 3;
			StaminaBonus = 3;
			IqBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Gargoyle Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class GargoyleLeggings : Item
	{
		public GargoyleLeggings() : base()
		{
			Id = 15451;
			Resistance[0] = 141;
			Bonding = 1;
			SellPrice = 643;
			AvailableClasses = 0x7FFF;
			Model = 2922;
			ObjectClass = 4;
			SubClass = 3;
			Level = 18;
			Name = "Gargoyle Leggings";
			Name2 = "Gargoyle Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3216;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			StrBonus = 2;
			StaminaBonus = 2;
			AgilityBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Plainsguard Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class PlainsguardLeggings : Item
	{
		public PlainsguardLeggings() : base()
		{
			Id = 15470;
			Resistance[0] = 171;
			Bonding = 1;
			SellPrice = 2432;
			AvailableClasses = 0x7FFF;
			Model = 28290;
			ObjectClass = 4;
			SubClass = 3;
			Level = 29;
			Name = "Plainsguard Leggings";
			Name2 = "Plainsguard Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 12162;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
			StaminaBonus = 8;
			StrBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Charger's Pants)
*
***************************************************************/

namespace Server.Items
{
	public class ChargersPants : Item
	{
		public ChargersPants() : base()
		{
			Id = 15477;
			Resistance[0] = 101;
			Bonding = 2;
			SellPrice = 192;
			AvailableClasses = 0x7FFF;
			Model = 26941;
			ObjectClass = 4;
			SubClass = 3;
			Level = 11;
			ReqLevel = 6;
			Name = "Charger's Pants";
			Name2 = "Charger's Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 580;
			BuyPrice = 960;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(War Torn Pants)
*
***************************************************************/

namespace Server.Items
{
	public class WarTornPants : Item
	{
		public WarTornPants() : base()
		{
			Id = 15485;
			Resistance[0] = 119;
			Bonding = 2;
			SellPrice = 344;
			AvailableClasses = 0x7FFF;
			Model = 26955;
			ObjectClass = 4;
			SubClass = 3;
			Level = 14;
			ReqLevel = 9;
			Name = "War Torn Pants";
			Name2 = "War Torn Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 581;
			BuyPrice = 1722;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Bloodspattered Loincloth)
*
***************************************************************/

namespace Server.Items
{
	public class BloodspatteredLoincloth : Item
	{
		public BloodspatteredLoincloth() : base()
		{
			Id = 15493;
			Resistance[0] = 141;
			Bonding = 2;
			SellPrice = 647;
			AvailableClasses = 0x7FFF;
			Model = 26998;
			ObjectClass = 4;
			SubClass = 3;
			Level = 18;
			ReqLevel = 13;
			Name = "Bloodspattered Loincloth";
			Name2 = "Bloodspattered Loincloth";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 582;
			BuyPrice = 3238;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Outrunner's Legguards)
*
***************************************************************/

namespace Server.Items
{
	public class OutrunnersLegguards : Item
	{
		public OutrunnersLegguards() : base()
		{
			Id = 15503;
			Resistance[0] = 152;
			Bonding = 2;
			SellPrice = 1091;
			AvailableClasses = 0x7FFF;
			Model = 26995;
			ObjectClass = 4;
			SubClass = 3;
			Level = 22;
			ReqLevel = 17;
			Name = "Outrunner's Legguards";
			Name2 = "Outrunner's Legguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 584;
			BuyPrice = 5457;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Grunt's Legguards)
*
***************************************************************/

namespace Server.Items
{
	public class GruntsLegguards : Item
	{
		public GruntsLegguards() : base()
		{
			Id = 15511;
			Resistance[0] = 157;
			Bonding = 2;
			SellPrice = 1474;
			AvailableClasses = 0x7FFF;
			Model = 26974;
			ObjectClass = 4;
			SubClass = 3;
			Level = 24;
			ReqLevel = 19;
			Name = "Grunt's Legguards";
			Name2 = "Grunt's Legguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 584;
			BuyPrice = 7371;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Spiked Chain Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class SpikedChainLeggings : Item
	{
		public SpikedChainLeggings() : base()
		{
			Id = 15521;
			Resistance[0] = 165;
			Bonding = 2;
			SellPrice = 1942;
			AvailableClasses = 0x7FFF;
			Model = 26968;
			ObjectClass = 4;
			SubClass = 3;
			Level = 27;
			ReqLevel = 22;
			Name = "Spiked Chain Leggings";
			Name2 = "Spiked Chain Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 585;
			BuyPrice = 9712;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Sentry's Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class SentrysLeggings : Item
	{
		public SentrysLeggings() : base()
		{
			Id = 15529;
			Resistance[0] = 171;
			Bonding = 2;
			SellPrice = 2487;
			AvailableClasses = 0x7FFF;
			Model = 27076;
			ObjectClass = 4;
			SubClass = 3;
			Level = 29;
			ReqLevel = 24;
			Name = "Sentry's Leggings";
			Name2 = "Sentry's Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 586;
			BuyPrice = 12437;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
		}
	}
}


/**************************************************************
*
*				(Wicked Chain Legguards)
*
***************************************************************/

namespace Server.Items
{
	public class WickedChainLegguards : Item
	{
		public WickedChainLegguards() : base()
		{
			Id = 15541;
			Resistance[0] = 181;
			Bonding = 2;
			SellPrice = 3441;
			AvailableClasses = 0x7FFF;
			Model = 27043;
			ObjectClass = 4;
			SubClass = 3;
			Level = 33;
			ReqLevel = 28;
			Name = "Wicked Chain Legguards";
			Name2 = "Wicked Chain Legguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 587;
			BuyPrice = 17205;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
		}
	}
}


/**************************************************************
*
*				(Thick Scale Legguards)
*
***************************************************************/

namespace Server.Items
{
	public class ThickScaleLegguards : Item
	{
		public ThickScaleLegguards() : base()
		{
			Id = 15551;
			Resistance[0] = 187;
			Bonding = 2;
			SellPrice = 4438;
			AvailableClasses = 0x7FFF;
			Model = 27020;
			ObjectClass = 4;
			SubClass = 3;
			Level = 35;
			ReqLevel = 30;
			Name = "Thick Scale Legguards";
			Name2 = "Thick Scale Legguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 588;
			BuyPrice = 22190;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
		}
	}
}


/**************************************************************
*
*				(Pillager's Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class PillagersLeggings : Item
	{
		public PillagersLeggings() : base()
		{
			Id = 15561;
			Resistance[0] = 189;
			Bonding = 2;
			SellPrice = 4705;
			AvailableClasses = 0x7FFF;
			Model = 27070;
			ObjectClass = 4;
			SubClass = 3;
			Level = 36;
			ReqLevel = 31;
			Name = "Pillager's Leggings";
			Name2 = "Pillager's Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 588;
			BuyPrice = 23527;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
		}
	}
}


/**************************************************************
*
*				(Marauder's Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class MaraudersLeggings : Item
	{
		public MaraudersLeggings() : base()
		{
			Id = 15573;
			Resistance[0] = 195;
			Bonding = 2;
			SellPrice = 5840;
			AvailableClasses = 0x7FFF;
			Model = 27061;
			ObjectClass = 4;
			SubClass = 3;
			Level = 38;
			ReqLevel = 33;
			Name = "Marauder's Leggings";
			Name2 = "Marauder's Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 589;
			BuyPrice = 29202;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
		}
	}
}


/**************************************************************
*
*				(Sparkleshell Legguards)
*
***************************************************************/

namespace Server.Items
{
	public class SparkleshellLegguards : Item
	{
		public SparkleshellLegguards() : base()
		{
			Id = 15582;
			Resistance[0] = 202;
			Bonding = 2;
			SellPrice = 6544;
			AvailableClasses = 0x7FFF;
			Model = 27114;
			ObjectClass = 4;
			SubClass = 3;
			Level = 40;
			ReqLevel = 35;
			Name = "Sparkleshell Legguards";
			Name2 = "Sparkleshell Legguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 590;
			BuyPrice = 32721;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
		}
	}
}


/**************************************************************
*
*				(Steadfast Legplates)
*
***************************************************************/

namespace Server.Items
{
	public class SteadfastLegplates : Item
	{
		public SteadfastLegplates() : base()
		{
			Id = 15596;
			Resistance[0] = 205;
			Bonding = 2;
			SellPrice = 6909;
			AvailableClasses = 0x7FFF;
			Model = 27890;
			ObjectClass = 4;
			SubClass = 3;
			Level = 41;
			ReqLevel = 36;
			Name = "Steadfast Legplates";
			Name2 = "Steadfast Legplates";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 590;
			BuyPrice = 34546;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
		}
	}
}


/**************************************************************
*
*				(Ancient Legguards)
*
***************************************************************/

namespace Server.Items
{
	public class AncientLegguards : Item
	{
		public AncientLegguards() : base()
		{
			Id = 15607;
			Resistance[0] = 214;
			Bonding = 2;
			SellPrice = 9305;
			AvailableClasses = 0x7FFF;
			Model = 27121;
			ObjectClass = 4;
			SubClass = 3;
			Level = 44;
			ReqLevel = 39;
			Name = "Ancient Legguards";
			Name2 = "Ancient Legguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 591;
			BuyPrice = 46529;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
		}
	}
}


/**************************************************************
*
*				(Bonelink Legplates)
*
***************************************************************/

namespace Server.Items
{
	public class BonelinkLegplates : Item
	{
		public BonelinkLegplates() : base()
		{
			Id = 15616;
			Resistance[0] = 222;
			Bonding = 2;
			SellPrice = 10151;
			AvailableClasses = 0x7FFF;
			Model = 27327;
			ObjectClass = 4;
			SubClass = 3;
			Level = 46;
			ReqLevel = 41;
			Name = "Bonelink Legplates";
			Name2 = "Bonelink Legplates";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 592;
			BuyPrice = 50755;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
		}
	}
}


/**************************************************************
*
*				(Gryphon Mail Legguards)
*
***************************************************************/

namespace Server.Items
{
	public class GryphonMailLegguards : Item
	{
		public GryphonMailLegguards() : base()
		{
			Id = 15627;
			Resistance[0] = 239;
			Bonding = 2;
			SellPrice = 14493;
			AvailableClasses = 0x7FFF;
			Model = 27133;
			ObjectClass = 4;
			SubClass = 3;
			Level = 50;
			ReqLevel = 45;
			Name = "Gryphon Mail Legguards";
			Name2 = "Gryphon Mail Legguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 593;
			BuyPrice = 72468;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
		}
	}
}


/**************************************************************
*
*				(Formidable Legguards)
*
***************************************************************/

namespace Server.Items
{
	public class FormidableLegguards : Item
	{
		public FormidableLegguards() : base()
		{
			Id = 15637;
			Resistance[0] = 243;
			Bonding = 2;
			SellPrice = 14557;
			AvailableClasses = 0x7FFF;
			Model = 27214;
			ObjectClass = 4;
			SubClass = 3;
			Level = 51;
			ReqLevel = 46;
			Name = "Formidable Legguards";
			Name2 = "Formidable Legguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 593;
			BuyPrice = 72786;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
		}
	}
}


/**************************************************************
*
*				(Ironhide Legguards)
*
***************************************************************/

namespace Server.Items
{
	public class IronhideLegguards : Item
	{
		public IronhideLegguards() : base()
		{
			Id = 15646;
			Resistance[0] = 260;
			Bonding = 2;
			SellPrice = 19506;
			AvailableClasses = 0x7FFF;
			Model = 27174;
			ObjectClass = 4;
			SubClass = 3;
			Level = 55;
			ReqLevel = 50;
			Name = "Ironhide Legguards";
			Name2 = "Ironhide Legguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 595;
			BuyPrice = 97534;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
		}
	}
}


/**************************************************************
*
*				(Merciless Legguards)
*
***************************************************************/

namespace Server.Items
{
	public class MercilessLegguards : Item
	{
		public MercilessLegguards() : base()
		{
			Id = 15655;
			Resistance[0] = 265;
			Bonding = 2;
			SellPrice = 19862;
			AvailableClasses = 0x7FFF;
			Model = 27289;
			ObjectClass = 4;
			SubClass = 3;
			Level = 56;
			ReqLevel = 51;
			Name = "Merciless Legguards";
			Name2 = "Merciless Legguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 595;
			BuyPrice = 99310;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
		}
	}
}


/**************************************************************
*
*				(Impenetrable Legguards)
*
***************************************************************/

namespace Server.Items
{
	public class ImpenetrableLegguards : Item
	{
		public ImpenetrableLegguards() : base()
		{
			Id = 15665;
			Resistance[0] = 282;
			Bonding = 2;
			SellPrice = 25520;
			AvailableClasses = 0x7FFF;
			Model = 27300;
			ObjectClass = 4;
			SubClass = 3;
			Level = 60;
			ReqLevel = 55;
			Name = "Impenetrable Legguards";
			Name2 = "Impenetrable Legguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 596;
			BuyPrice = 127600;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
		}
	}
}


/**************************************************************
*
*				(Magnificent Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class MagnificentLeggings : Item
	{
		public MagnificentLeggings() : base()
		{
			Id = 15676;
			Resistance[0] = 286;
			Bonding = 2;
			SellPrice = 25928;
			AvailableClasses = 0x7FFF;
			Model = 27319;
			ObjectClass = 4;
			SubClass = 3;
			Level = 61;
			ReqLevel = 56;
			Name = "Magnificent Leggings";
			Name2 = "Magnificent Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 597;
			BuyPrice = 129644;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
		}
	}
}


/**************************************************************
*
*				(Triumphant Legplates)
*
***************************************************************/

namespace Server.Items
{
	public class TriumphantLegplates : Item
	{
		public TriumphantLegplates() : base()
		{
			Id = 15685;
			Resistance[0] = 295;
			Bonding = 2;
			SellPrice = 29539;
			AvailableClasses = 0x7FFF;
			Model = 27311;
			ObjectClass = 4;
			SubClass = 3;
			Level = 63;
			ReqLevel = 58;
			Name = "Triumphant Legplates";
			Name2 = "Triumphant Legplates";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 597;
			BuyPrice = 147698;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 75;
		}
	}
}


/**************************************************************
*
*				(Knight-Captain's Chain Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class KnightCaptainsChainLeggings : Item
	{
		public KnightCaptainsChainLeggings() : base()
		{
			Id = 16426;
			Resistance[0] = 324;
			Bonding = 1;
			SellPrice = 16635;
			AvailableClasses = 0x04;
			Model = 31242;
			ObjectClass = 4;
			SubClass = 3;
			Level = 63;
			ReqLevel = 58;
			Name = "Knight-Captain's Chain Leggings";
			Name2 = "Knight-Captain's Chain Leggings";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 83178;
			Sets = 362;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			Durability = 90;
			Flags = 32768;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 13669 , 1 , 0 , -1 , 0 , -1 );
			AgilityBonus = 18;
			StaminaBonus = 17;
		}
	}
}


/**************************************************************
*
*				(Marshal's Chain Legguards)
*
***************************************************************/

namespace Server.Items
{
	public class MarshalsChainLegguards : Item
	{
		public MarshalsChainLegguards() : base()
		{
			Id = 16467;
			Resistance[0] = 364;
			Bonding = 1;
			SellPrice = 25213;
			AvailableClasses = 0x04;
			Model = 32097;
			ObjectClass = 4;
			SubClass = 3;
			Level = 65;
			ReqLevel = 60;
			Name = "Marshal's Chain Legguards";
			Name2 = "Marshal's Chain Legguards";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 126068;
			Sets = 395;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			Durability = 105;
			Flags = 32768;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 13669 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 15464 , 1 , 0 , -1 , 0 , -1 );
			AgilityBonus = 23;
			StaminaBonus = 22;
		}
	}
}


/**************************************************************
*
*				(Legionnaire's Mail Legguards)
*
***************************************************************/

namespace Server.Items
{
	public class LegionnairesMailLegguards : Item
	{
		public LegionnairesMailLegguards() : base()
		{
			Id = 16523;
			Resistance[0] = 324;
			Bonding = 1;
			SellPrice = 17349;
			AvailableClasses = 0x40;
			Model = 31186;
			ObjectClass = 4;
			SubClass = 3;
			Level = 63;
			ReqLevel = 58;
			Name = "Legionnaire's Mail Legguards";
			Name2 = "Legionnaire's Mail Legguards";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 86745;
			Sets = 301;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			Durability = 90;
			Flags = 32768;
			SetSpell( 15715 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 20;
			SpiritBonus = 11;
			AgilityBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Legionnaire's Chain Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class LegionnairesChainLeggings : Item
	{
		public LegionnairesChainLeggings() : base()
		{
			Id = 16527;
			Resistance[0] = 324;
			Bonding = 1;
			SellPrice = 17603;
			AvailableClasses = 0x04;
			Model = 30367;
			ObjectClass = 4;
			SubClass = 3;
			Level = 63;
			ReqLevel = 58;
			Name = "Legionnaire's Chain Leggings";
			Name2 = "Legionnaire's Chain Leggings";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 88015;
			Sets = 361;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			Durability = 90;
			Flags = 32768;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 13669 , 1 , 0 , -1 , 0 , -1 );
			AgilityBonus = 18;
			StaminaBonus = 17;
		}
	}
}


/**************************************************************
*
*				(General's Chain Legguards)
*
***************************************************************/

namespace Server.Items
{
	public class GeneralsChainLegguards : Item
	{
		public GeneralsChainLegguards() : base()
		{
			Id = 16567;
			Resistance[0] = 364;
			Bonding = 1;
			SellPrice = 25868;
			AvailableClasses = 0x04;
			Model = 32120;
			ObjectClass = 4;
			SubClass = 3;
			Level = 65;
			ReqLevel = 60;
			Name = "General's Chain Legguards";
			Name2 = "General's Chain Legguards";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 129343;
			Sets = 396;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			Durability = 105;
			Flags = 32768;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 13669 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 15464 , 1 , 0 , -1 , 0 , -1 );
			AgilityBonus = 23;
			StaminaBonus = 22;
		}
	}
}


/**************************************************************
*
*				(General's Mail Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class GeneralsMailLeggings : Item
	{
		public GeneralsMailLeggings() : base()
		{
			Id = 16579;
			Resistance[0] = 364;
			Bonding = 1;
			SellPrice = 25119;
			AvailableClasses = 0x40;
			Model = 32127;
			ObjectClass = 4;
			SubClass = 3;
			Level = 65;
			ReqLevel = 60;
			Name = "General's Mail Leggings";
			Name2 = "General's Mail Leggings";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 125598;
			Sets = 386;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			Durability = 105;
			Flags = 32768;
			SetSpell( 14127 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 23;
			SpiritBonus = 19;
			AgilityBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Kilt of Elements)
*
***************************************************************/

namespace Server.Items
{
	public class KiltOfElements : Item
	{
		public KiltOfElements() : base()
		{
			Id = 16668;
			Resistance[0] = 315;
			Bonding = 1;
			SellPrice = 30541;
			AvailableClasses = 0x7FFF;
			Model = 31415;
			ObjectClass = 4;
			SubClass = 3;
			Level = 61;
			ReqLevel = 56;
			Name = "Kilt of Elements";
			Name2 = "Kilt of Elements";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 152707;
			Sets = 187;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 90;
			IqBonus = 20;
			SpiritBonus = 15;
			StrBonus = 12;
			StaminaBonus = 7;
			AgilityBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Beaststalker's Pants)
*
***************************************************************/

namespace Server.Items
{
	public class BeaststalkersPants : Item
	{
		public BeaststalkersPants() : base()
		{
			Id = 16678;
			Resistance[0] = 315;
			Bonding = 1;
			SellPrice = 31694;
			AvailableClasses = 0x7FFF;
			Model = 31403;
			ObjectClass = 4;
			SubClass = 3;
			Level = 61;
			ReqLevel = 56;
			Name = "Beaststalker's Pants";
			Name2 = "Beaststalker's Pants";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 158473;
			Sets = 186;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 90;
			AgilityBonus = 26;
			IqBonus = 12;
			StaminaBonus = 6;
			StrBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Earthfury Legguards)
*
***************************************************************/

namespace Server.Items
{
	public class EarthfuryLegguards : Item
	{
		public EarthfuryLegguards() : base()
		{
			Id = 16843;
			Resistance[0] = 369;
			Bonding = 1;
			SellPrice = 52346;
			AvailableClasses = 0x40;
			Model = 31836;
			ObjectClass = 4;
			SubClass = 3;
			Level = 66;
			ReqLevel = 60;
			Name = "Earthfury Legguards";
			Name2 = "Earthfury Legguards";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 261730;
			Sets = 207;
			Resistance[5] = 10;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 105;
			SetSpell( 21627 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 9417 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 19;
			IqBonus = 21;
			StaminaBonus = 18;
		}
	}
}


/**************************************************************
*
*				(Giantstalker's Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class GiantstalkersLeggings : Item
	{
		public GiantstalkersLeggings() : base()
		{
			Id = 16847;
			Resistance[0] = 369;
			Bonding = 1;
			SellPrice = 54543;
			AvailableClasses = 0x04;
			Model = 32029;
			ObjectClass = 4;
			SubClass = 3;
			Level = 66;
			ReqLevel = 60;
			Name = "Giantstalker's Leggings";
			Name2 = "Giantstalker's Leggings";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 272715;
			Sets = 206;
			Resistance[5] = 10;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 105;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			AgilityBonus = 32;
			SpiritBonus = 6;
			IqBonus = 8;
			StaminaBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Dragonstalker's Legguards)
*
***************************************************************/

namespace Server.Items
{
	public class DragonstalkersLegguards : Item
	{
		public DragonstalkersLegguards() : base()
		{
			Id = 16938;
			Resistance[6] = 10;
			Resistance[0] = 422;
			Bonding = 1;
			SellPrice = 85917;
			AvailableClasses = 0x04;
			Model = 29814;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 3;
			Level = 76;
			ReqLevel = 60;
			Name = "Dragonstalker's Legguards";
			Name2 = "Dragonstalker's Legguards";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 429588;
			Sets = 215;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 105;
			SetSpell( 15465 , 1 , 0 , -1 , 0 , -1 );
			AgilityBonus = 31;
			SpiritBonus = 10;
			IqBonus = 11;
			StaminaBonus = 17;
		}
	}
}


/**************************************************************
*
*				(Legplates of Ten Storms)
*
***************************************************************/

namespace Server.Items
{
	public class LegplatesOfTenStorms : Item
	{
		public LegplatesOfTenStorms() : base()
		{
			Id = 16946;
			Resistance[6] = 10;
			Resistance[0] = 422;
			Bonding = 1;
			SellPrice = 90773;
			AvailableClasses = 0x40;
			Model = 28447;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 3;
			Level = 76;
			ReqLevel = 60;
			Name = "Legplates of Ten Storms";
			Name2 = "Legplates of Ten Storms";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 453866;
			Sets = 216;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 105;
			SetSpell( 18384 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 13881 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 18;
			IqBonus = 20;
			StaminaBonus = 16;
		}
	}
}


/**************************************************************
*
*				(Cobalt Legguards)
*
***************************************************************/

namespace Server.Items
{
	public class CobaltLegguards : Item
	{
		public CobaltLegguards() : base()
		{
			Id = 17006;
			Resistance[0] = 165;
			Bonding = 1;
			SellPrice = 1966;
			AvailableClasses = 0x7FFF;
			Model = 26995;
			ObjectClass = 4;
			SubClass = 3;
			Level = 27;
			Name = "Cobalt Legguards";
			Name2 = "Cobalt Legguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 9831;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 70;
			StaminaBonus = 7;
			StrBonus = 5;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Infernal Trickster Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class InfernalTricksterLeggings : Item
	{
		public InfernalTricksterLeggings() : base()
		{
			Id = 17754;
			Resistance[0] = 263;
			Bonding = 1;
			SellPrice = 17394;
			AvailableClasses = 0x7FFF;
			Model = 29934;
			ObjectClass = 4;
			SubClass = 3;
			Level = 50;
			ReqLevel = 45;
			Name = "Infernal Trickster Leggings";
			Name2 = "Infernal Trickster Leggings";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 86971;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 90;
			SetSpell( 7569 , 1 , 0 , -1 , 0 , -1 );
			AgilityBonus = 20;
			SpiritBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Silvermoon Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class SilvermoonLeggings : Item
	{
		public SilvermoonLeggings() : base()
		{
			Id = 18378;
			Resistance[0] = 320;
			Bonding = 1;
			SellPrice = 31384;
			AvailableClasses = 0x7FFF;
			Model = 30730;
			ObjectClass = 4;
			SubClass = 3;
			Level = 62;
			ReqLevel = 57;
			Name = "Silvermoon Leggings";
			Name2 = "Silvermoon Leggings";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 156920;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 90;
			SetSpell( 9346 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 16;
			IqBonus = 10;
			StaminaBonus = 16;
			AgilityBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Leggings of Destruction)
*
***************************************************************/

namespace Server.Items
{
	public class LeggingsOfDestruction : Item
	{
		public LeggingsOfDestruction() : base()
		{
			Id = 18524;
			Resistance[0] = 324;
			Bonding = 1;
			SellPrice = 35596;
			AvailableClasses = 0x7FFF;
			Model = 30857;
			ObjectClass = 4;
			SubClass = 3;
			Level = 63;
			ReqLevel = 58;
			Name = "Leggings of Destruction";
			Name2 = "Leggings of Destruction";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 177982;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 90;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			AgilityBonus = 14;
			SpiritBonus = 13;
			StaminaBonus = 20;
		}
	}
}


/**************************************************************
*
*				(Emberweave Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class EmberweaveLeggings : Item
	{
		public EmberweaveLeggings() : base()
		{
			Id = 19433;
			Resistance[0] = 417;
			Bonding = 1;
			SellPrice = 80659;
			AvailableClasses = 0x7FFF;
			Model = 31968;
			Resistance[2] = 35;
			ObjectClass = 4;
			SubClass = 3;
			Level = 75;
			ReqLevel = 60;
			Name = "Emberweave Leggings";
			Name2 = "Emberweave Leggings";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 403299;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 5;
			Durability = 105;
			StaminaBonus = 22;
			AgilityBonus = 17;
			SpiritBonus = 12;
		}
	}
}


