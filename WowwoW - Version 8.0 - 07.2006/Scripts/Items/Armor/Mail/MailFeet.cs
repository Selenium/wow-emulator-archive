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
*				(Scalemail Boots)
*
***************************************************************/

namespace Server.Items
{
	public class ScalemailBoots : Item
	{
		public ScalemailBoots() : base()
		{
			Id = 287;
			Resistance[0] = 113;
			SellPrice = 488;
			AvailableClasses = 0x7FFF;
			Model = 12745;
			ObjectClass = 4;
			SubClass = 3;
			Level = 22;
			ReqLevel = 17;
			Name = "Scalemail Boots";
			Name2 = "Scalemail Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2441;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Chainmail Boots)
*
***************************************************************/

namespace Server.Items
{
	public class ChainmailBoots : Item
	{
		public ChainmailBoots() : base()
		{
			Id = 849;
			Resistance[0] = 104;
			SellPrice = 265;
			AvailableClasses = 0x7FFF;
			Model = 6869;
			ObjectClass = 4;
			SubClass = 3;
			Level = 17;
			ReqLevel = 12;
			Name = "Chainmail Boots";
			Name2 = "Chainmail Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1326;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Blackrock Boots)
*
***************************************************************/

namespace Server.Items
{
	public class BlackrockBoots : Item
	{
		public BlackrockBoots() : base()
		{
			Id = 1446;
			Resistance[0] = 113;
			Bonding = 2;
			SellPrice = 568;
			AvailableClasses = 0x7FFF;
			Model = 6841;
			ObjectClass = 4;
			SubClass = 3;
			Level = 19;
			ReqLevel = 14;
			Name = "Blackrock Boots";
			Name2 = "Blackrock Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2842;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 40;
			StrBonus = 3;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Black Ogre Kickers)
*
***************************************************************/

namespace Server.Items
{
	public class BlackOgreKickers : Item
	{
		public BlackOgreKickers() : base()
		{
			Id = 1678;
			Resistance[0] = 166;
			Bonding = 2;
			SellPrice = 4581;
			AvailableClasses = 0x7FFF;
			Model = 11269;
			ObjectClass = 4;
			SubClass = 3;
			Level = 37;
			ReqLevel = 32;
			Name = "Black Ogre Kickers";
			Name2 = "Black Ogre Kickers";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 22907;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			StrBonus = 6;
			StaminaBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Worn Mail Boots)
*
***************************************************************/

namespace Server.Items
{
	public class WornMailBoots : Item
	{
		public WornMailBoots() : base()
		{
			Id = 1731;
			Resistance[0] = 80;
			SellPrice = 92;
			AvailableClasses = 0x7FFF;
			Model = 6903;
			ObjectClass = 4;
			SubClass = 3;
			Level = 13;
			ReqLevel = 8;
			Name = "Worn Mail Boots";
			Name2 = "Worn Mail Boots";
			AvailableRaces = 0x1FF;
			BuyPrice = 461;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Laced Mail Boots)
*
***************************************************************/

namespace Server.Items
{
	public class LacedMailBoots : Item
	{
		public LacedMailBoots() : base()
		{
			Id = 1739;
			Resistance[0] = 104;
			SellPrice = 255;
			AvailableClasses = 0x7FFF;
			Model = 6903;
			ObjectClass = 4;
			SubClass = 3;
			Level = 20;
			ReqLevel = 15;
			Name = "Laced Mail Boots";
			Name2 = "Laced Mail Boots";
			AvailableRaces = 0x1FF;
			BuyPrice = 1279;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Linked Chain Boots)
*
***************************************************************/

namespace Server.Items
{
	public class LinkedChainBoots : Item
	{
		public LinkedChainBoots() : base()
		{
			Id = 1747;
			Resistance[0] = 106;
			SellPrice = 302;
			AvailableClasses = 0x7FFF;
			Model = 6903;
			ObjectClass = 4;
			SubClass = 3;
			Level = 21;
			ReqLevel = 16;
			Name = "Linked Chain Boots";
			Name2 = "Linked Chain Boots";
			AvailableRaces = 0x1FF;
			BuyPrice = 1514;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Reinforced Chain Boots)
*
***************************************************************/

namespace Server.Items
{
	public class ReinforcedChainBoots : Item
	{
		public ReinforcedChainBoots() : base()
		{
			Id = 1755;
			Resistance[0] = 117;
			SellPrice = 597;
			AvailableClasses = 0x7FFF;
			Model = 6903;
			ObjectClass = 4;
			SubClass = 3;
			Level = 27;
			ReqLevel = 22;
			Name = "Reinforced Chain Boots";
			Name2 = "Reinforced Chain Boots";
			AvailableRaces = 0x1FF;
			BuyPrice = 2989;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Dragonmaw Chain Boots)
*
***************************************************************/

namespace Server.Items
{
	public class DragonmawChainBoots : Item
	{
		public DragonmawChainBoots() : base()
		{
			Id = 1955;
			Resistance[0] = 130;
			Bonding = 2;
			SellPrice = 1573;
			AvailableClasses = 0x7FFF;
			Model = 6907;
			ObjectClass = 4;
			SubClass = 3;
			Level = 27;
			ReqLevel = 22;
			Name = "Dragonmaw Chain Boots";
			Name2 = "Dragonmaw Chain Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7868;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
			StaminaBonus = 6;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Tunneler's Boots)
*
***************************************************************/

namespace Server.Items
{
	public class TunnelersBoots : Item
	{
		public TunnelersBoots() : base()
		{
			Id = 2037;
			Resistance[0] = 111;
			Bonding = 1;
			SellPrice = 469;
			AvailableClasses = 0x7FFF;
			Model = 11447;
			ObjectClass = 4;
			SubClass = 3;
			Level = 18;
			Name = "Tunneler's Boots";
			Name2 = "Tunneler's Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2345;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 40;
			StaminaBonus = 3;
			IqBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Polished Scale Boots)
*
***************************************************************/

namespace Server.Items
{
	public class PolishedScaleBoots : Item
	{
		public PolishedScaleBoots() : base()
		{
			Id = 2149;
			Resistance[0] = 123;
			SellPrice = 879;
			AvailableClasses = 0x7FFF;
			Model = 6972;
			ObjectClass = 4;
			SubClass = 3;
			Level = 27;
			ReqLevel = 22;
			Name = "Polished Scale Boots";
			Name2 = "Polished Scale Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 4397;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Tarnished Chain Boots)
*
***************************************************************/

namespace Server.Items
{
	public class TarnishedChainBoots : Item
	{
		public TarnishedChainBoots() : base()
		{
			Id = 2383;
			Resistance[0] = 46;
			SellPrice = 11;
			AvailableClasses = 0x7FFF;
			Model = 6903;
			ObjectClass = 4;
			SubClass = 3;
			Level = 5;
			ReqLevel = 1;
			Name = "Tarnished Chain Boots";
			Name2 = "Tarnished Chain Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 57;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Rusted Chain Boots)
*
***************************************************************/

namespace Server.Items
{
	public class RustedChainBoots : Item
	{
		public RustedChainBoots() : base()
		{
			Id = 2389;
			Resistance[0] = 46;
			SellPrice = 11;
			AvailableClasses = 0x7FFF;
			Model = 6952;
			ObjectClass = 4;
			SubClass = 3;
			Level = 5;
			ReqLevel = 1;
			Name = "Rusted Chain Boots";
			Name2 = "Rusted Chain Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 59;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Light Mail Boots)
*
***************************************************************/

namespace Server.Items
{
	public class LightMailBoots : Item
	{
		public LightMailBoots() : base()
		{
			Id = 2395;
			Resistance[0] = 70;
			SellPrice = 64;
			AvailableClasses = 0x7FFF;
			Model = 6903;
			ObjectClass = 4;
			SubClass = 3;
			Level = 10;
			ReqLevel = 5;
			Name = "Light Mail Boots";
			Name2 = "Light Mail Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 322;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Light Chain Boots)
*
***************************************************************/

namespace Server.Items
{
	public class LightChainBoots : Item
	{
		public LightChainBoots() : base()
		{
			Id = 2401;
			Resistance[0] = 70;
			SellPrice = 66;
			AvailableClasses = 0x7FFF;
			Model = 6952;
			ObjectClass = 4;
			SubClass = 3;
			Level = 10;
			ReqLevel = 5;
			Name = "Light Chain Boots";
			Name2 = "Light Chain Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 330;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Augmented Chain Boots)
*
***************************************************************/

namespace Server.Items
{
	public class AugmentedChainBoots : Item
	{
		public AugmentedChainBoots() : base()
		{
			Id = 2420;
			Resistance[0] = 143;
			SellPrice = 2387;
			AvailableClasses = 0x7FFF;
			Model = 6820;
			ObjectClass = 4;
			SubClass = 3;
			Level = 37;
			ReqLevel = 32;
			Name = "Augmented Chain Boots";
			Name2 = "Augmented Chain Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 11937;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Brigandine Boots)
*
***************************************************************/

namespace Server.Items
{
	public class BrigandineBoots : Item
	{
		public BrigandineBoots() : base()
		{
			Id = 2426;
			Resistance[0] = 178;
			SellPrice = 6513;
			AvailableClasses = 0x7FFF;
			Model = 6854;
			ObjectClass = 4;
			SubClass = 3;
			Level = 50;
			ReqLevel = 45;
			Name = "Brigandine Boots";
			Name2 = "Brigandine Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 32568;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Loose Chain Boots)
*
***************************************************************/

namespace Server.Items
{
	public class LooseChainBoots : Item
	{
		public LooseChainBoots() : base()
		{
			Id = 2642;
			Resistance[0] = 62;
			SellPrice = 33;
			AvailableClasses = 0x7FFF;
			Model = 6903;
			ObjectClass = 4;
			SubClass = 3;
			Level = 9;
			ReqLevel = 4;
			Name = "Loose Chain Boots";
			Name2 = "Loose Chain Boots";
			AvailableRaces = 0x1FF;
			BuyPrice = 166;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Flimsy Chain Boots)
*
***************************************************************/

namespace Server.Items
{
	public class FlimsyChainBoots : Item
	{
		public FlimsyChainBoots() : base()
		{
			Id = 2650;
			Resistance[0] = 34;
			SellPrice = 3;
			AvailableClasses = 0x7FFF;
			Model = 6903;
			ObjectClass = 4;
			SubClass = 3;
			Level = 3;
			ReqLevel = 1;
			Name = "Flimsy Chain Boots";
			Name2 = "Flimsy Chain Boots";
			AvailableRaces = 0x1FF;
			BuyPrice = 16;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Outfitter Boots)
*
***************************************************************/

namespace Server.Items
{
	public class OutfitterBoots : Item
	{
		public OutfitterBoots() : base()
		{
			Id = 2691;
			Resistance[0] = 46;
			Bonding = 1;
			SellPrice = 10;
			AvailableClasses = 0x7FFF;
			Model = 6903;
			ObjectClass = 4;
			SubClass = 3;
			Level = 5;
			Name = "Outfitter Boots";
			Name2 = "Outfitter Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 54;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Gold Militia Boots)
*
***************************************************************/

namespace Server.Items
{
	public class GoldMilitiaBoots : Item
	{
		public GoldMilitiaBoots() : base()
		{
			Id = 2910;
			Resistance[0] = 126;
			Bonding = 1;
			SellPrice = 1257;
			AvailableClasses = 0x7FFF;
			Model = 6931;
			ObjectClass = 4;
			SubClass = 3;
			Level = 25;
			Name = "Gold Militia Boots";
			Name2 = "Gold Militia Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6286;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 45;
			StrBonus = 3;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Warrior's Boots)
*
***************************************************************/

namespace Server.Items
{
	public class WarriorsBoots : Item
	{
		public WarriorsBoots() : base()
		{
			Id = 2967;
			Resistance[0] = 70;
			SellPrice = 66;
			AvailableClasses = 0x7FFF;
			Model = 22673;
			ObjectClass = 4;
			SubClass = 3;
			Level = 10;
			ReqLevel = 5;
			Name = "Warrior's Boots";
			Name2 = "Warrior's Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 331;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Veteran Boots)
*
***************************************************************/

namespace Server.Items
{
	public class VeteranBoots : Item
	{
		public VeteranBoots() : base()
		{
			Id = 2979;
			Resistance[0] = 89;
			SellPrice = 157;
			AvailableClasses = 0x7FFF;
			Model = 22690;
			ObjectClass = 4;
			SubClass = 3;
			Level = 14;
			ReqLevel = 9;
			Name = "Veteran Boots";
			Name2 = "Veteran Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 785;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Burnished Boots)
*
***************************************************************/

namespace Server.Items
{
	public class BurnishedBoots : Item
	{
		public BurnishedBoots() : base()
		{
			Id = 2991;
			Resistance[0] = 117;
			Bonding = 2;
			SellPrice = 705;
			AvailableClasses = 0x7FFF;
			Model = 25765;
			ObjectClass = 4;
			SubClass = 3;
			Level = 21;
			ReqLevel = 16;
			Name = "Burnished Boots";
			Name2 = "Burnished Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3528;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 40;
			StrBonus = 2;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Lambent Scale Boots)
*
***************************************************************/

namespace Server.Items
{
	public class LambentScaleBoots : Item
	{
		public LambentScaleBoots() : base()
		{
			Id = 3045;
			Resistance[0] = 130;
			Bonding = 2;
			SellPrice = 1573;
			AvailableClasses = 0x7FFF;
			Model = 25778;
			ObjectClass = 4;
			SubClass = 3;
			Level = 27;
			ReqLevel = 22;
			Name = "Lambent Scale Boots";
			Name2 = "Lambent Scale Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7869;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
			StaminaBonus = 6;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Battle Chain Boots)
*
***************************************************************/

namespace Server.Items
{
	public class BattleChainBoots : Item
	{
		public BattleChainBoots() : base()
		{
			Id = 3279;
			Resistance[0] = 80;
			SellPrice = 105;
			AvailableClasses = 0x7FFF;
			Model = 26927;
			ObjectClass = 4;
			SubClass = 3;
			Level = 12;
			ReqLevel = 7;
			Name = "Battle Chain Boots";
			Name2 = "Battle Chain Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 525;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Brackwater Boots)
*
***************************************************************/

namespace Server.Items
{
	public class BrackwaterBoots : Item
	{
		public BrackwaterBoots() : base()
		{
			Id = 3302;
			Resistance[0] = 99;
			Bonding = 2;
			SellPrice = 319;
			AvailableClasses = 0x7FFF;
			Model = 26944;
			ObjectClass = 4;
			SubClass = 3;
			Level = 15;
			ReqLevel = 10;
			Name = "Brackwater Boots";
			Name2 = "Brackwater Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1595;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Perrine's Boots)
*
***************************************************************/

namespace Server.Items
{
	public class PerrinesBoots : Item
	{
		public PerrinesBoots() : base()
		{
			Id = 3332;
			Resistance[0] = 65;
			SellPrice = 48;
			AvailableClasses = 0x7FFF;
			Model = 6987;
			ObjectClass = 4;
			SubClass = 3;
			Level = 9;
			ReqLevel = 4;
			Name = "Perrine's Boots";
			Name2 = "Perrine's Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 242;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Cryptwalker Boots)
*
***************************************************************/

namespace Server.Items
{
	public class CryptwalkerBoots : Item
	{
		public CryptwalkerBoots() : base()
		{
			Id = 3447;
			Resistance[0] = 61;
			Bonding = 1;
			SellPrice = 34;
			AvailableClasses = 0x7FFF;
			Model = 6880;
			ObjectClass = 4;
			SubClass = 3;
			Level = 8;
			Name = "Cryptwalker Boots";
			Name2 = "Cryptwalker Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 174;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Copper Chain Boots)
*
***************************************************************/

namespace Server.Items
{
	public class CopperChainBoots : Item
	{
		public CopperChainBoots() : base()
		{
			Id = 3469;
			Resistance[0] = 65;
			SellPrice = 49;
			AvailableClasses = 0x7FFF;
			Model = 23528;
			ObjectClass = 4;
			SubClass = 3;
			Level = 9;
			ReqLevel = 4;
			Name = "Copper Chain Boots";
			Name2 = "Copper Chain Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 245;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Silvered Bronze Boots)
*
***************************************************************/

namespace Server.Items
{
	public class SilveredBronzeBoots : Item
	{
		public SilveredBronzeBoots() : base()
		{
			Id = 3482;
			Resistance[0] = 128;
			Bonding = 2;
			SellPrice = 1317;
			AvailableClasses = 0x7FFF;
			Model = 9404;
			ObjectClass = 4;
			SubClass = 3;
			Level = 26;
			ReqLevel = 21;
			Name = "Silvered Bronze Boots";
			Name2 = "Silvered Bronze Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6588;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 45;
			StrBonus = 4;
			StaminaBonus = 4;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Green Iron Boots)
*
***************************************************************/

namespace Server.Items
{
	public class GreenIronBoots : Item
	{
		public GreenIronBoots() : base()
		{
			Id = 3484;
			Resistance[0] = 134;
			Bonding = 2;
			SellPrice = 1767;
			AvailableClasses = 0x7FFF;
			Model = 9412;
			ObjectClass = 4;
			SubClass = 3;
			Level = 29;
			ReqLevel = 24;
			Name = "Green Iron Boots";
			Name2 = "Green Iron Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 8837;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
			StaminaBonus = 7;
			StrBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Double Mail Boots)
*
***************************************************************/

namespace Server.Items
{
	public class DoubleMailBoots : Item
	{
		public DoubleMailBoots() : base()
		{
			Id = 3809;
			Resistance[0] = 126;
			SellPrice = 962;
			AvailableClasses = 0x7FFF;
			Model = 6903;
			ObjectClass = 4;
			SubClass = 3;
			Level = 32;
			ReqLevel = 27;
			Name = "Double Mail Boots";
			Name2 = "Double Mail Boots";
			AvailableRaces = 0x1FF;
			BuyPrice = 4813;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Polished Steel Boots)
*
***************************************************************/

namespace Server.Items
{
	public class PolishedSteelBoots : Item
	{
		public PolishedSteelBoots() : base()
		{
			Id = 3846;
			Resistance[0] = 151;
			Bonding = 2;
			SellPrice = 3937;
			AvailableClasses = 0x7FFF;
			Model = 23537;
			ObjectClass = 4;
			SubClass = 3;
			Level = 37;
			ReqLevel = 32;
			Name = "Polished Steel Boots";
			Name2 = "Polished Steel Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 19685;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
			StaminaBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Golden Scale Boots)
*
***************************************************************/

namespace Server.Items
{
	public class GoldenScaleBoots : Item
	{
		public GoldenScaleBoots() : base()
		{
			Id = 3847;
			Resistance[0] = 159;
			Bonding = 2;
			SellPrice = 4977;
			AvailableClasses = 0x7FFF;
			Model = 9426;
			ObjectClass = 4;
			SubClass = 3;
			Level = 40;
			ReqLevel = 35;
			Name = "Golden Scale Boots";
			Name2 = "Golden Scale Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 24887;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
			StrBonus = 8;
			IqBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Laminated Scale Boots)
*
***************************************************************/

namespace Server.Items
{
	public class LaminatedScaleBoots : Item
	{
		public LaminatedScaleBoots() : base()
		{
			Id = 3993;
			Resistance[0] = 178;
			SellPrice = 4940;
			AvailableClasses = 0x7FFF;
			Model = 6947;
			ObjectClass = 4;
			SubClass = 3;
			Level = 53;
			ReqLevel = 48;
			Name = "Laminated Scale Boots";
			Name2 = "Laminated Scale Boots";
			AvailableRaces = 0x1FF;
			BuyPrice = 24704;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Overlinked Chain Boots)
*
***************************************************************/

namespace Server.Items
{
	public class OverlinkedChainBoots : Item
	{
		public OverlinkedChainBoots() : base()
		{
			Id = 4001;
			Resistance[0] = 157;
			SellPrice = 3170;
			AvailableClasses = 0x7FFF;
			Model = 6965;
			ObjectClass = 4;
			SubClass = 3;
			Level = 46;
			ReqLevel = 41;
			Name = "Overlinked Chain Boots";
			Name2 = "Overlinked Chain Boots";
			AvailableRaces = 0x1FF;
			BuyPrice = 15852;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Glimmering Mail Greaves)
*
***************************************************************/

namespace Server.Items
{
	public class GlimmeringMailGreaves : Item
	{
		public GlimmeringMailGreaves() : base()
		{
			Id = 4073;
			Resistance[0] = 138;
			Bonding = 2;
			SellPrice = 2230;
			AvailableClasses = 0x7FFF;
			Model = 25804;
			ObjectClass = 4;
			SubClass = 3;
			Level = 31;
			ReqLevel = 26;
			Name = "Glimmering Mail Greaves";
			Name2 = "Glimmering Mail Greaves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11151;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
			StrBonus = 6;
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Mail Combat Boots)
*
***************************************************************/

namespace Server.Items
{
	public class MailCombatBoots : Item
	{
		public MailCombatBoots() : base()
		{
			Id = 4076;
			Resistance[0] = 147;
			Bonding = 2;
			SellPrice = 3301;
			AvailableClasses = 0x7FFF;
			Model = 25810;
			ObjectClass = 4;
			SubClass = 3;
			Level = 35;
			ReqLevel = 30;
			Name = "Mail Combat Boots";
			Name2 = "Mail Combat Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 16508;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
			StrBonus = 3;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Darkspear Boots)
*
***************************************************************/

namespace Server.Items
{
	public class DarkspearBoots : Item
	{
		public DarkspearBoots() : base()
		{
			Id = 4136;
			Resistance[0] = 164;
			Bonding = 1;
			SellPrice = 6021;
			AvailableClasses = 0x7FFF;
			Model = 6885;
			ObjectClass = 4;
			SubClass = 3;
			Level = 42;
			Name = "Darkspear Boots";
			Name2 = "Darkspear Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 30109;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
			StrBonus = 9;
			IqBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Trouncing Boots)
*
***************************************************************/

namespace Server.Items
{
	public class TrouncingBoots : Item
	{
		public TrouncingBoots() : base()
		{
			Id = 4464;
			Resistance[0] = 140;
			Bonding = 2;
			SellPrice = 2380;
			AvailableClasses = 0x7FFF;
			Model = 7002;
			ObjectClass = 4;
			SubClass = 3;
			Level = 32;
			ReqLevel = 27;
			Name = "Trouncing Boots";
			Name2 = "Trouncing Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11901;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
			StrBonus = 6;
			AgilityBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Ironheel Boots)
*
***************************************************************/

namespace Server.Items
{
	public class IronheelBoots : Item
	{
		public IronheelBoots() : base()
		{
			Id = 4653;
			Resistance[0] = 171;
			Bonding = 1;
			SellPrice = 7178;
			AvailableClasses = 0x7FFF;
			Model = 6944;
			ObjectClass = 4;
			SubClass = 3;
			Level = 45;
			Name = "Ironheel Boots";
			Name2 = "Ironheel Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 35890;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
			StrBonus = 10;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Lightweight Boots)
*
***************************************************************/

namespace Server.Items
{
	public class LightweightBoots : Item
	{
		public LightweightBoots() : base()
		{
			Id = 4946;
			Resistance[0] = 70;
			Bonding = 1;
			SellPrice = 67;
			AvailableClasses = 0x7FFF;
			Model = 6876;
			ObjectClass = 4;
			SubClass = 3;
			Level = 10;
			Name = "Lightweight Boots";
			Name2 = "Lightweight Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 337;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Cliff Runner Boots)
*
***************************************************************/

namespace Server.Items
{
	public class CliffRunnerBoots : Item
	{
		public CliffRunnerBoots() : base()
		{
			Id = 4972;
			Resistance[0] = 70;
			Bonding = 1;
			SellPrice = 64;
			AvailableClasses = 0x7FFF;
			Model = 6876;
			ObjectClass = 4;
			SubClass = 3;
			Level = 10;
			Name = "Cliff Runner Boots";
			Name2 = "Cliff Runner Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 320;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Padded Lamellar Boots)
*
***************************************************************/

namespace Server.Items
{
	public class PaddedLamellarBoots : Item
	{
		public PaddedLamellarBoots() : base()
		{
			Id = 5320;
			Resistance[0] = 104;
			Bonding = 1;
			SellPrice = 372;
			AvailableClasses = 0x7FFF;
			Model = 7554;
			ObjectClass = 4;
			SubClass = 3;
			Level = 16;
			Name = "Padded Lamellar Boots";
			Name2 = "Padded Lamellar Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1862;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			StrBonus = 2;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Tracking Boots)
*
***************************************************************/

namespace Server.Items
{
	public class TrackingBoots : Item
	{
		public TrackingBoots() : base()
		{
			Id = 5399;
			Resistance[0] = 46;
			Bonding = 1;
			SellPrice = 11;
			AvailableClasses = 0x7FFF;
			Model = 7835;
			ObjectClass = 4;
			SubClass = 3;
			Level = 5;
			Name = "Tracking Boots";
			Name2 = "Tracking Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 59;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Greaves of the People's Militia)
*
***************************************************************/

namespace Server.Items
{
	public class GreavesOfThePeoplesMilitia : Item
	{
		public GreavesOfThePeoplesMilitia() : base()
		{
			Id = 5944;
			Resistance[0] = 99;
			Bonding = 1;
			SellPrice = 331;
			AvailableClasses = 0x7FFF;
			Model = 7554;
			ObjectClass = 4;
			SubClass = 3;
			Level = 15;
			Name = "Greaves of the People's Militia";
			Name2 = "Greaves of the People's Militia";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1655;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Mud Stompers)
*
***************************************************************/

namespace Server.Items
{
	public class MudStompers : Item
	{
		public MudStompers() : base()
		{
			Id = 6188;
			Resistance[0] = 99;
			Bonding = 1;
			SellPrice = 305;
			AvailableClasses = 0x7FFF;
			Model = 10434;
			ObjectClass = 4;
			SubClass = 3;
			Level = 15;
			Name = "Mud Stompers";
			Name2 = "Mud Stompers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1525;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Rough Bronze Boots)
*
***************************************************************/

namespace Server.Items
{
	public class RoughBronzeBoots : Item
	{
		public RoughBronzeBoots() : base()
		{
			Id = 6350;
			Resistance[0] = 106;
			SellPrice = 295;
			AvailableClasses = 0x7FFF;
			Model = 6885;
			ObjectClass = 4;
			SubClass = 3;
			Level = 18;
			ReqLevel = 13;
			Name = "Rough Bronze Boots";
			Name2 = "Rough Bronze Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1478;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Chief Brigadier Boots)
*
***************************************************************/

namespace Server.Items
{
	public class ChiefBrigadierBoots : Item
	{
		public ChiefBrigadierBoots() : base()
		{
			Id = 6412;
			Resistance[0] = 156;
			Bonding = 2;
			SellPrice = 4711;
			AvailableClasses = 0x7FFF;
			Model = 25883;
			ObjectClass = 4;
			SubClass = 3;
			Level = 39;
			ReqLevel = 34;
			Name = "Chief Brigadier Boots";
			Name2 = "Chief Brigadier Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 23558;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
			StrBonus = 8;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Blackforge Greaves)
*
***************************************************************/

namespace Server.Items
{
	public class BlackforgeGreaves : Item
	{
		public BlackforgeGreaves() : base()
		{
			Id = 6423;
			Resistance[0] = 171;
			Bonding = 2;
			SellPrice = 7233;
			AvailableClasses = 0x7FFF;
			Model = 26077;
			ObjectClass = 4;
			SubClass = 3;
			Level = 45;
			ReqLevel = 40;
			Name = "Blackforge Greaves";
			Name2 = "Blackforge Greaves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 36168;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
			AgilityBonus = 10;
			StrBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Savage Trodders)
*
***************************************************************/

namespace Server.Items
{
	public class SavageTrodders : Item
	{
		public SavageTrodders() : base()
		{
			Id = 6459;
			Resistance[0] = 122;
			Bonding = 1;
			SellPrice = 934;
			AvailableClasses = 0x7FFF;
			Model = 11935;
			ObjectClass = 4;
			SubClass = 3;
			Level = 23;
			ReqLevel = 18;
			Name = "Savage Trodders";
			Name2 = "Savage Trodders";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4674;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 45;
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Infantry Boots)
*
***************************************************************/

namespace Server.Items
{
	public class InfantryBoots : Item
	{
		public InfantryBoots() : base()
		{
			Id = 6506;
			Resistance[0] = 75;
			SellPrice = 87;
			AvailableClasses = 0x7FFF;
			Model = 22680;
			ObjectClass = 4;
			SubClass = 3;
			Level = 11;
			ReqLevel = 6;
			Name = "Infantry Boots";
			Name2 = "Infantry Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 436;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Soldier's Boots)
*
***************************************************************/

namespace Server.Items
{
	public class SoldiersBoots : Item
	{
		public SoldiersBoots() : base()
		{
			Id = 6551;
			Resistance[0] = 109;
			Bonding = 2;
			SellPrice = 409;
			AvailableClasses = 0x7FFF;
			Model = 6931;
			ObjectClass = 4;
			SubClass = 3;
			Level = 17;
			ReqLevel = 12;
			Name = "Soldier's Boots";
			Name2 = "Soldier's Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 834;
			BuyPrice = 2048;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Defender Boots)
*
***************************************************************/

namespace Server.Items
{
	public class DefenderBoots : Item
	{
		public DefenderBoots() : base()
		{
			Id = 6573;
			Resistance[0] = 122;
			Bonding = 2;
			SellPrice = 938;
			AvailableClasses = 0x7FFF;
			Model = 25760;
			ObjectClass = 4;
			SubClass = 3;
			Level = 23;
			ReqLevel = 18;
			Name = "Defender Boots";
			Name2 = "Defender Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 836;
			BuyPrice = 4691;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Battleforge Boots)
*
***************************************************************/

namespace Server.Items
{
	public class BattleforgeBoots : Item
	{
		public BattleforgeBoots() : base()
		{
			Id = 6590;
			Resistance[0] = 134;
			Bonding = 2;
			SellPrice = 1830;
			AvailableClasses = 0x7FFF;
			Model = 25793;
			ObjectClass = 4;
			SubClass = 3;
			Level = 29;
			ReqLevel = 24;
			Name = "Battleforge Boots";
			Name2 = "Battleforge Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 838;
			BuyPrice = 9153;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Dredge Boots)
*
***************************************************************/

namespace Server.Items
{
	public class DredgeBoots : Item
	{
		public DredgeBoots() : base()
		{
			Id = 6666;
			Resistance[0] = 119;
			Bonding = 1;
			SellPrice = 830;
			AvailableClasses = 0x7FFF;
			Model = 12784;
			ObjectClass = 4;
			SubClass = 3;
			Level = 22;
			Name = "Dredge Boots";
			Name2 = "Dredge Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4152;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 45;
			StaminaBonus = 4;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Phalanx Boots)
*
***************************************************************/

namespace Server.Items
{
	public class PhalanxBoots : Item
	{
		public PhalanxBoots() : base()
		{
			Id = 7417;
			Resistance[0] = 144;
			Bonding = 2;
			SellPrice = 2903;
			AvailableClasses = 0x7FFF;
			Model = 26030;
			ObjectClass = 4;
			SubClass = 3;
			Level = 34;
			ReqLevel = 29;
			Name = "Phalanx Boots";
			Name2 = "Phalanx Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 840;
			BuyPrice = 14519;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Knight's Boots)
*
***************************************************************/

namespace Server.Items
{
	public class KnightsBoots : Item
	{
		public KnightsBoots() : base()
		{
			Id = 7458;
			Resistance[0] = 151;
			Bonding = 2;
			SellPrice = 3983;
			AvailableClasses = 0x7FFF;
			Model = 25860;
			ObjectClass = 4;
			SubClass = 3;
			Level = 37;
			ReqLevel = 32;
			Name = "Knight's Boots";
			Name2 = "Knight's Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 841;
			BuyPrice = 19916;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Captain's Boots)
*
***************************************************************/

namespace Server.Items
{
	public class CaptainsBoots : Item
	{
		public CaptainsBoots() : base()
		{
			Id = 7490;
			Resistance[0] = 164;
			Bonding = 2;
			SellPrice = 5680;
			AvailableClasses = 0x7FFF;
			Model = 25817;
			ObjectClass = 4;
			SubClass = 3;
			Level = 42;
			ReqLevel = 37;
			Name = "Captain's Boots";
			Name2 = "Captain's Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 842;
			BuyPrice = 28403;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Champion's Greaves)
*
***************************************************************/

namespace Server.Items
{
	public class ChampionsGreaves : Item
	{
		public ChampionsGreaves() : base()
		{
			Id = 7542;
			Resistance[0] = 174;
			Bonding = 2;
			SellPrice = 8284;
			AvailableClasses = 0x7FFF;
			Model = 26090;
			ObjectClass = 4;
			SubClass = 3;
			Level = 46;
			ReqLevel = 41;
			Name = "Champion's Greaves";
			Name2 = "Champion's Greaves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 844;
			BuyPrice = 41422;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Barbaric Iron Boots)
*
***************************************************************/

namespace Server.Items
{
	public class BarbaricIronBoots : Item
	{
		public BarbaricIronBoots() : base()
		{
			Id = 7916;
			Resistance[0] = 149;
			Bonding = 2;
			SellPrice = 3700;
			AvailableClasses = 0x7FFF;
			Model = 16086;
			ObjectClass = 4;
			SubClass = 3;
			Level = 36;
			ReqLevel = 31;
			Name = "Barbaric Iron Boots";
			Name2 = "Barbaric Iron Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 18502;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
			StrBonus = 7;
			AgilityBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Myrmidon's Greaves)
*
***************************************************************/

namespace Server.Items
{
	public class MyrmidonsGreaves : Item
	{
		public MyrmidonsGreaves() : base()
		{
			Id = 8130;
			Resistance[0] = 184;
			Bonding = 2;
			SellPrice = 9458;
			AvailableClasses = 0x7FFF;
			Model = 26109;
			ObjectClass = 4;
			SubClass = 3;
			Level = 49;
			ReqLevel = 44;
			Name = "Myrmidon's Greaves";
			Name2 = "Myrmidon's Greaves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 47294;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
			AgilityBonus = 14;
			SpiritBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Tough Scorpid Boots)
*
***************************************************************/

namespace Server.Items
{
	public class ToughScorpidBoots : Item
	{
		public ToughScorpidBoots() : base()
		{
			Id = 8209;
			Resistance[0] = 178;
			Bonding = 2;
			SellPrice = 8375;
			AvailableClasses = 0x7FFF;
			Model = 16521;
			ObjectClass = 4;
			SubClass = 3;
			Level = 47;
			ReqLevel = 42;
			Name = "Tough Scorpid Boots";
			Name2 = "Tough Scorpid Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 41879;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
			AgilityBonus = 12;
			IqBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Ebonhold Boots)
*
***************************************************************/

namespace Server.Items
{
	public class EbonholdBoots : Item
	{
		public EbonholdBoots() : base()
		{
			Id = 8269;
			Resistance[0] = 205;
			Bonding = 2;
			SellPrice = 14362;
			AvailableClasses = 0x7FFF;
			Model = 28667;
			ObjectClass = 4;
			SubClass = 3;
			Level = 55;
			ReqLevel = 50;
			Name = "Ebonhold Boots";
			Name2 = "Ebonhold Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 71813;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
			StaminaBonus = 16;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Hero's Boots)
*
***************************************************************/

namespace Server.Items
{
	public class HerosBoots : Item
	{
		public HerosBoots() : base()
		{
			Id = 8307;
			Resistance[0] = 221;
			Bonding = 2;
			SellPrice = 18717;
			AvailableClasses = 0x7FFF;
			Model = 26310;
			ObjectClass = 4;
			SubClass = 3;
			Level = 60;
			ReqLevel = 55;
			Name = "Hero's Boots";
			Name2 = "Hero's Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 93586;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
			StaminaBonus = 19;
			IqBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Caverndeep Trudgers)
*
***************************************************************/

namespace Server.Items
{
	public class CaverndeepTrudgers : Item
	{
		public CaverndeepTrudgers() : base()
		{
			Id = 9510;
			Resistance[0] = 154;
			Bonding = 2;
			SellPrice = 2945;
			AvailableClasses = 0x7FFF;
			Model = 18431;
			ObjectClass = 4;
			SubClass = 3;
			Level = 32;
			ReqLevel = 27;
			Name = "Caverndeep Trudgers";
			Name2 = "Caverndeep Trudgers";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 14729;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			AgilityBonus = 4;
			StrBonus = 4;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Cadet Boots)
*
***************************************************************/

namespace Server.Items
{
	public class CadetBoots : Item
	{
		public CadetBoots() : base()
		{
			Id = 9759;
			Resistance[0] = 84;
			SellPrice = 138;
			AvailableClasses = 0x7FFF;
			Model = 22684;
			ObjectClass = 4;
			SubClass = 3;
			Level = 13;
			ReqLevel = 8;
			Name = "Cadet Boots";
			Name2 = "Cadet Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 690;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Raider's Boots)
*
***************************************************************/

namespace Server.Items
{
	public class RaidersBoots : Item
	{
		public RaidersBoots() : base()
		{
			Id = 9784;
			Resistance[0] = 113;
			Bonding = 2;
			SellPrice = 533;
			AvailableClasses = 0x7FFF;
			Model = 6987;
			ObjectClass = 4;
			SubClass = 3;
			Level = 19;
			ReqLevel = 14;
			Name = "Raider's Boots";
			Name2 = "Raider's Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 835;
			BuyPrice = 2669;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Fortified Boots)
*
***************************************************************/

namespace Server.Items
{
	public class FortifiedBoots : Item
	{
		public FortifiedBoots() : base()
		{
			Id = 9810;
			Resistance[0] = 126;
			Bonding = 2;
			SellPrice = 1231;
			AvailableClasses = 0x7FFF;
			Model = 6869;
			ObjectClass = 4;
			SubClass = 3;
			Level = 25;
			ReqLevel = 20;
			Name = "Fortified Boots";
			Name2 = "Fortified Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 837;
			BuyPrice = 6155;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Renegade Boots)
*
***************************************************************/

namespace Server.Items
{
	public class RenegadeBoots : Item
	{
		public RenegadeBoots() : base()
		{
			Id = 9864;
			Resistance[0] = 149;
			Bonding = 2;
			SellPrice = 3527;
			AvailableClasses = 0x7FFF;
			Model = 25980;
			ObjectClass = 4;
			SubClass = 3;
			Level = 36;
			ReqLevel = 31;
			Name = "Renegade Boots";
			Name2 = "Renegade Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 840;
			BuyPrice = 17637;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Jazeraint Boots)
*
***************************************************************/

namespace Server.Items
{
	public class JazeraintBoots : Item
	{
		public JazeraintBoots() : base()
		{
			Id = 9895;
			Resistance[0] = 159;
			Bonding = 2;
			SellPrice = 5221;
			AvailableClasses = 0x7FFF;
			Model = 27787;
			ObjectClass = 4;
			SubClass = 3;
			Level = 40;
			ReqLevel = 35;
			Name = "Jazeraint Boots";
			Name2 = "Jazeraint Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 842;
			BuyPrice = 26105;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Brigade Boots)
*
***************************************************************/

namespace Server.Items
{
	public class BrigadeBoots : Item
	{
		public BrigadeBoots() : base()
		{
			Id = 9926;
			Resistance[0] = 166;
			Bonding = 2;
			SellPrice = 6368;
			AvailableClasses = 0x7FFF;
			Model = 25930;
			ObjectClass = 4;
			SubClass = 3;
			Level = 43;
			ReqLevel = 38;
			Name = "Brigade Boots";
			Name2 = "Brigade Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 843;
			BuyPrice = 31840;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Warmonger's Greaves)
*
***************************************************************/

namespace Server.Items
{
	public class WarmongersGreaves : Item
	{
		public WarmongersGreaves() : base()
		{
			Id = 9962;
			Resistance[0] = 181;
			Bonding = 2;
			SellPrice = 9218;
			AvailableClasses = 0x7FFF;
			Model = 26188;
			ObjectClass = 4;
			SubClass = 3;
			Level = 48;
			ReqLevel = 43;
			Name = "Warmonger's Greaves";
			Name2 = "Warmonger's Greaves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 844;
			BuyPrice = 46092;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Lord's Boots)
*
***************************************************************/

namespace Server.Items
{
	public class LordsBoots : Item
	{
		public LordsBoots() : base()
		{
			Id = 10082;
			Resistance[0] = 191;
			Bonding = 2;
			SellPrice = 10752;
			AvailableClasses = 0x7FFF;
			Model = 26326;
			ObjectClass = 4;
			SubClass = 3;
			Level = 51;
			ReqLevel = 46;
			Name = "Lord's Boots";
			Name2 = "Lord's Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 845;
			BuyPrice = 53763;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Ornate Greaves)
*
***************************************************************/

namespace Server.Items
{
	public class OrnateGreaves : Item
	{
		public OrnateGreaves() : base()
		{
			Id = 10119;
			Resistance[0] = 211;
			Bonding = 2;
			SellPrice = 16676;
			AvailableClasses = 0x7FFF;
			Model = 26297;
			ObjectClass = 4;
			SubClass = 3;
			Level = 57;
			ReqLevel = 52;
			Name = "Ornate Greaves";
			Name2 = "Ornate Greaves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 847;
			BuyPrice = 83383;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Mercurial Greaves)
*
***************************************************************/

namespace Server.Items
{
	public class MercurialGreaves : Item
	{
		public MercurialGreaves() : base()
		{
			Id = 10155;
			Resistance[0] = 225;
			Bonding = 2;
			SellPrice = 20168;
			AvailableClasses = 0x7FFF;
			Model = 26129;
			ObjectClass = 4;
			SubClass = 3;
			Level = 61;
			ReqLevel = 56;
			Name = "Mercurial Greaves";
			Name2 = "Mercurial Greaves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 849;
			BuyPrice = 100842;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Crusader's Boots)
*
***************************************************************/

namespace Server.Items
{
	public class CrusadersBoots : Item
	{
		public CrusadersBoots() : base()
		{
			Id = 10192;
			Resistance[0] = 198;
			Bonding = 2;
			SellPrice = 13212;
			AvailableClasses = 0x7FFF;
			Model = 26160;
			ObjectClass = 4;
			SubClass = 3;
			Level = 53;
			ReqLevel = 48;
			Name = "Crusader's Boots";
			Name2 = "Crusader's Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 846;
			BuyPrice = 66060;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Engraved Boots)
*
***************************************************************/

namespace Server.Items
{
	public class EngravedBoots : Item
	{
		public EngravedBoots() : base()
		{
			Id = 10234;
			Resistance[0] = 215;
			Bonding = 2;
			SellPrice = 17801;
			AvailableClasses = 0x7FFF;
			Model = 26264;
			ObjectClass = 4;
			SubClass = 3;
			Level = 58;
			ReqLevel = 53;
			Name = "Engraved Boots";
			Name2 = "Engraved Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 848;
			BuyPrice = 89007;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Masterwork Boots)
*
***************************************************************/

namespace Server.Items
{
	public class MasterworkBoots : Item
	{
		public MasterworkBoots() : base()
		{
			Id = 10270;
			Resistance[0] = 231;
			Bonding = 2;
			SellPrice = 22396;
			AvailableClasses = 0x7FFF;
			Model = 26237;
			ObjectClass = 4;
			SubClass = 3;
			Level = 63;
			ReqLevel = 58;
			Name = "Masterwork Boots";
			Name2 = "Masterwork Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 849;
			BuyPrice = 111982;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Scarlet Boots)
*
***************************************************************/

namespace Server.Items
{
	public class ScarletBoots : Item
	{
		public ScarletBoots() : base()
		{
			Id = 10332;
			Resistance[0] = 161;
			Bonding = 2;
			SellPrice = 3790;
			AvailableClasses = 0x7FFF;
			Model = 28383;
			ObjectClass = 4;
			SubClass = 3;
			Level = 35;
			ReqLevel = 30;
			Name = "Scarlet Boots";
			Name2 = "Scarlet Boots";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 18950;
			Sets = 163;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			StaminaBonus = 12;
			AgilityBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Banded Boots)
*
***************************************************************/

namespace Server.Items
{
	public class BandedBoots : Item
	{
		public BandedBoots() : base()
		{
			Id = 10409;
			Resistance[0] = 140;
			Bonding = 2;
			SellPrice = 2409;
			AvailableClasses = 0x7FFF;
			Model = 27771;
			ObjectClass = 4;
			SubClass = 3;
			Level = 32;
			ReqLevel = 27;
			Name = "Banded Boots";
			Name2 = "Banded Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 839;
			BuyPrice = 12049;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Quagmire Galoshes)
*
***************************************************************/

namespace Server.Items
{
	public class QuagmireGaloshes : Item
	{
		public QuagmireGaloshes() : base()
		{
			Id = 10658;
			Resistance[0] = 126;
			Bonding = 1;
			SellPrice = 1249;
			AvailableClasses = 0x7FFF;
			Model = 28238;
			ObjectClass = 4;
			SubClass = 3;
			Level = 25;
			Name = "Quagmire Galoshes";
			Name2 = "Quagmire Galoshes";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6248;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 45;
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Boots of Zua'tec)
*
***************************************************************/

namespace Server.Items
{
	public class BootsOfZuatec : Item
	{
		public BootsOfZuatec() : base()
		{
			Id = 10701;
			Resistance[0] = 171;
			Bonding = 1;
			SellPrice = 7536;
			AvailableClasses = 0x7FFF;
			Model = 28263;
			ObjectClass = 4;
			SubClass = 3;
			Level = 45;
			Name = "Boots of Zua'tec";
			Name2 = "Boots of Zua'tec";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 37680;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
			StaminaBonus = 13;
			IqBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Atal'ai Boots)
*
***************************************************************/

namespace Server.Items
{
	public class AtalaiBoots : Item
	{
		public AtalaiBoots() : base()
		{
			Id = 10786;
			Resistance[0] = 195;
			Bonding = 1;
			SellPrice = 11977;
			AvailableClasses = 0x7FFF;
			Model = 19794;
			ObjectClass = 4;
			SubClass = 3;
			Level = 52;
			ReqLevel = 47;
			Name = "Atal'ai Boots";
			Name2 = "Atal'ai Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 846;
			BuyPrice = 59889;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Bloodshot Greaves)
*
***************************************************************/

namespace Server.Items
{
	public class BloodshotGreaves : Item
	{
		public BloodshotGreaves() : base()
		{
			Id = 10846;
			Resistance[0] = 221;
			Bonding = 1;
			SellPrice = 16143;
			AvailableClasses = 0x7FFF;
			Model = 19898;
			ObjectClass = 4;
			SubClass = 3;
			Level = 54;
			ReqLevel = 49;
			Name = "Bloodshot Greaves";
			Name2 = "Bloodshot Greaves";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 80717;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			StaminaBonus = 20;
			AgilityBonus = 6;
			StrBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Fleetfoot Greaves)
*
***************************************************************/

namespace Server.Items
{
	public class FleetfootGreaves : Item
	{
		public FleetfootGreaves() : base()
		{
			Id = 11627;
			Resistance[0] = 198;
			Bonding = 1;
			SellPrice = 12224;
			AvailableClasses = 0x7FFF;
			Model = 28658;
			ObjectClass = 4;
			SubClass = 3;
			Level = 53;
			ReqLevel = 48;
			Name = "Fleetfoot Greaves";
			Name2 = "Fleetfoot Greaves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 61120;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
			AgilityBonus = 15;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Savage Gladiator Greaves)
*
***************************************************************/

namespace Server.Items
{
	public class SavageGladiatorGreaves : Item
	{
		public SavageGladiatorGreaves() : base()
		{
			Id = 11731;
			Resistance[0] = 233;
			Bonding = 1;
			SellPrice = 19300;
			AvailableClasses = 0x7FFF;
			Model = 28666;
			ObjectClass = 4;
			SubClass = 3;
			Level = 57;
			ReqLevel = 52;
			Name = "Savage Gladiator Greaves";
			Name2 = "Savage Gladiator Greaves";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 96500;
			Sets = 1;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			AgilityBonus = 13;
			StrBonus = 13;
			StaminaBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Radiant Boots)
*
***************************************************************/

namespace Server.Items
{
	public class RadiantBoots : Item
	{
		public RadiantBoots() : base()
		{
			Id = 12419;
			Resistance[0] = 215;
			Bonding = 2;
			SellPrice = 16421;
			AvailableClasses = 0x7FFF;
			Model = 25741;
			Resistance[4] = 15;
			ObjectClass = 4;
			SubClass = 3;
			Level = 58;
			ReqLevel = 53;
			Name = "Radiant Boots";
			Name2 = "Radiant Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 82107;
			Resistance[5] = 15;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Silver-linked Footguards)
*
***************************************************************/

namespace Server.Items
{
	public class SilverLinkedFootguards : Item
	{
		public SilverLinkedFootguards() : base()
		{
			Id = 12982;
			Resistance[0] = 129;
			Bonding = 2;
			SellPrice = 850;
			AvailableClasses = 0x7FFF;
			Model = 28452;
			ObjectClass = 4;
			SubClass = 3;
			Level = 21;
			ReqLevel = 16;
			Name = "Silver-linked Footguards";
			Name2 = "Silver-linked Footguards";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 4254;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 45;
			StrBonus = 3;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Ravasaur Scale Boots)
*
***************************************************************/

namespace Server.Items
{
	public class RavasaurScaleBoots : Item
	{
		public RavasaurScaleBoots() : base()
		{
			Id = 13124;
			Resistance[0] = 161;
			Bonding = 2;
			SellPrice = 3996;
			AvailableClasses = 0x7FFF;
			Model = 28441;
			ObjectClass = 4;
			SubClass = 3;
			Level = 35;
			ReqLevel = 30;
			Name = "Ravasaur Scale Boots";
			Name2 = "Ravasaur Scale Boots";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 19981;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			IqBonus = 5;
			StrBonus = 3;
			StaminaBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Elven Chain Boots)
*
***************************************************************/

namespace Server.Items
{
	public class ElvenChainBoots : Item
	{
		public ElvenChainBoots() : base()
		{
			Id = 13125;
			Resistance[0] = 206;
			Bonding = 2;
			SellPrice = 12954;
			AvailableClasses = 0x7FFF;
			Model = 28439;
			ObjectClass = 4;
			SubClass = 3;
			Level = 50;
			ReqLevel = 45;
			Name = "Elven Chain Boots";
			Name2 = "Elven Chain Boots";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 64770;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			AgilityBonus = 18;
			StaminaBonus = 3;
			IqBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Wind Dancer Boots)
*
***************************************************************/

namespace Server.Items
{
	public class WindDancerBoots : Item
	{
		public WindDancerBoots() : base()
		{
			Id = 13260;
			Resistance[0] = 247;
			Bonding = 1;
			SellPrice = 22561;
			AvailableClasses = 0x7FFF;
			Model = 23861;
			ObjectClass = 4;
			SubClass = 3;
			Level = 61;
			ReqLevel = 56;
			Name = "Wind Dancer Boots";
			Name2 = "Wind Dancer Boots";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 112807;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			SetSpell( 13669 , 1 , 0 , -1 , 0 , -1 );
			IqBonus = 16;
			SpiritBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Swiftdart Battleboots)
*
***************************************************************/

namespace Server.Items
{
	public class SwiftdartBattleboots : Item
	{
		public SwiftdartBattleboots() : base()
		{
			Id = 13284;
			Resistance[0] = 218;
			Bonding = 1;
			SellPrice = 17312;
			AvailableClasses = 0x7FFF;
			Model = 23901;
			ObjectClass = 4;
			SubClass = 3;
			Level = 59;
			ReqLevel = 54;
			Name = "Swiftdart Battleboots";
			Name2 = "Swiftdart Battleboots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 86560;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
			StaminaBonus = 5;
			AgilityBonus = 17;
		}
	}
}


/**************************************************************
*
*				(Timmy's Galoshes)
*
***************************************************************/

namespace Server.Items
{
	public class TimmysGaloshes : Item
	{
		public TimmysGaloshes() : base()
		{
			Id = 13402;
			Resistance[0] = 240;
			Bonding = 1;
			SellPrice = 21168;
			AvailableClasses = 0x7FFF;
			Model = 24112;
			ObjectClass = 4;
			SubClass = 3;
			Level = 59;
			ReqLevel = 54;
			Name = "Timmy's Galoshes";
			Name2 = "Timmy's Galoshes";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 105842;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			IqBonus = 11;
			AgilityBonus = 11;
			StrBonus = 11;
			StaminaBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Windreaver Greaves)
*
***************************************************************/

namespace Server.Items
{
	public class WindreaverGreaves : Item
	{
		public WindreaverGreaves() : base()
		{
			Id = 13967;
			Resistance[0] = 247;
			Bonding = 1;
			SellPrice = 23338;
			AvailableClasses = 0x7FFF;
			Model = 28604;
			ObjectClass = 4;
			SubClass = 3;
			Level = 61;
			ReqLevel = 56;
			Name = "Windreaver Greaves";
			Name2 = "Windreaver Greaves";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 116691;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			AgilityBonus = 20;
			IqBonus = 7;
			StrBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Bloodmail Boots)
*
***************************************************************/

namespace Server.Items
{
	public class BloodmailBoots : Item
	{
		public BloodmailBoots() : base()
		{
			Id = 14616;
			Resistance[0] = 225;
			Bonding = 1;
			SellPrice = 18799;
			AvailableClasses = 0x7FFF;
			Model = 25220;
			ObjectClass = 4;
			SubClass = 3;
			Level = 61;
			ReqLevel = 56;
			Name = "Bloodmail Boots";
			Name2 = "Bloodmail Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 93996;
			Sets = 123;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
			IqBonus = 20;
		}
	}
}


/**************************************************************
*
*				(War Paint Anklewraps)
*
***************************************************************/

namespace Server.Items
{
	public class WarPaintAnklewraps : Item
	{
		public WarPaintAnklewraps() : base()
		{
			Id = 14722;
			Resistance[0] = 109;
			Bonding = 2;
			SellPrice = 424;
			AvailableClasses = 0x7FFF;
			Model = 26983;
			ObjectClass = 4;
			SubClass = 3;
			Level = 17;
			ReqLevel = 12;
			Name = "War Paint Anklewraps";
			Name2 = "War Paint Anklewraps";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2121;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 40;
			StrBonus = 2;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Hulking Boots)
*
***************************************************************/

namespace Server.Items
{
	public class HulkingBoots : Item
	{
		public HulkingBoots() : base()
		{
			Id = 14742;
			Resistance[0] = 124;
			Bonding = 2;
			SellPrice = 1118;
			AvailableClasses = 0x7FFF;
			Model = 27009;
			ObjectClass = 4;
			SubClass = 3;
			Level = 24;
			ReqLevel = 19;
			Name = "Hulking Boots";
			Name2 = "Hulking Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5592;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 45;
			StaminaBonus = 4;
			StrBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Slayer's Slippers)
*
***************************************************************/

namespace Server.Items
{
	public class SlayersSlippers : Item
	{
		public SlayersSlippers() : base()
		{
			Id = 14756;
			Resistance[0] = 134;
			Bonding = 2;
			SellPrice = 1860;
			AvailableClasses = 0x7FFF;
			Model = 27035;
			ObjectClass = 4;
			SubClass = 3;
			Level = 29;
			ReqLevel = 24;
			Name = "Slayer's Slippers";
			Name2 = "Slayer's Slippers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 9300;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
			StrBonus = 6;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Enduring Boots)
*
***************************************************************/

namespace Server.Items
{
	public class EnduringBoots : Item
	{
		public EnduringBoots() : base()
		{
			Id = 14762;
			Resistance[0] = 151;
			Bonding = 2;
			SellPrice = 4074;
			AvailableClasses = 0x7FFF;
			Model = 27047;
			ObjectClass = 4;
			SubClass = 3;
			Level = 37;
			ReqLevel = 32;
			Name = "Enduring Boots";
			Name2 = "Enduring Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 20373;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
			StaminaBonus = 8;
			StrBonus = 4;
			IqBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Ravager's Sandals)
*
***************************************************************/

namespace Server.Items
{
	public class RavagersSandals : Item
	{
		public RavagersSandals() : base()
		{
			Id = 14769;
			Resistance[0] = 164;
			Bonding = 2;
			SellPrice = 5554;
			AvailableClasses = 0x7FFF;
			Model = 27093;
			ObjectClass = 4;
			SubClass = 3;
			Level = 42;
			ReqLevel = 37;
			Name = "Ravager's Sandals";
			Name2 = "Ravager's Sandals";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 27772;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
			StaminaBonus = 10;
			IqBonus = 4;
			StrBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Khan's Greaves)
*
***************************************************************/

namespace Server.Items
{
	public class KhansGreaves : Item
	{
		public KhansGreaves() : base()
		{
			Id = 14784;
			Resistance[0] = 174;
			Bonding = 2;
			SellPrice = 8202;
			AvailableClasses = 0x7FFF;
			Model = 27149;
			ObjectClass = 4;
			SubClass = 3;
			Level = 46;
			ReqLevel = 41;
			Name = "Khan's Greaves";
			Name2 = "Khan's Greaves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 41011;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
			StaminaBonus = 12;
			SpiritBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Protector Ankleguards)
*
***************************************************************/

namespace Server.Items
{
	public class ProtectorAnkleguards : Item
	{
		public ProtectorAnkleguards() : base()
		{
			Id = 14794;
			Resistance[0] = 188;
			Bonding = 2;
			SellPrice = 10563;
			AvailableClasses = 0x7FFF;
			Model = 27158;
			ObjectClass = 4;
			SubClass = 3;
			Level = 50;
			ReqLevel = 45;
			Name = "Protector Ankleguards";
			Name2 = "Protector Ankleguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 52818;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
			StaminaBonus = 8;
			IqBonus = 8;
			SpiritBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Bloodlust Boots)
*
***************************************************************/

namespace Server.Items
{
	public class BloodlustBoots : Item
	{
		public BloodlustBoots() : base()
		{
			Id = 14799;
			Resistance[0] = 215;
			Bonding = 2;
			SellPrice = 17308;
			AvailableClasses = 0x7FFF;
			Model = 27192;
			ObjectClass = 4;
			SubClass = 3;
			Level = 58;
			ReqLevel = 53;
			Name = "Bloodlust Boots";
			Name2 = "Bloodlust Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 86542;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
			IqBonus = 14;
			StrBonus = 4;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Warstrike Sabatons)
*
***************************************************************/

namespace Server.Items
{
	public class WarstrikeSabatons : Item
	{
		public WarstrikeSabatons() : base()
		{
			Id = 14809;
			Resistance[0] = 228;
			Bonding = 2;
			SellPrice = 20276;
			AvailableClasses = 0x7FFF;
			Model = 27827;
			ObjectClass = 4;
			SubClass = 3;
			Level = 62;
			ReqLevel = 57;
			Name = "Warstrike Sabatons";
			Name2 = "Warstrike Sabatons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 101382;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
			StaminaBonus = 16;
			AgilityBonus = 6;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Crustacean Boots)
*
***************************************************************/

namespace Server.Items
{
	public class CrustaceanBoots : Item
	{
		public CrustaceanBoots() : base()
		{
			Id = 15406;
			Resistance[0] = 109;
			Bonding = 1;
			SellPrice = 402;
			AvailableClasses = 0x7FFF;
			Model = 28138;
			ObjectClass = 4;
			SubClass = 3;
			Level = 17;
			Name = "Crustacean Boots";
			Name2 = "Crustacean Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2012;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 40;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Charger's Boots)
*
***************************************************************/

namespace Server.Items
{
	public class ChargersBoots : Item
	{
		public ChargersBoots() : base()
		{
			Id = 15473;
			Resistance[0] = 70;
			SellPrice = 65;
			AvailableClasses = 0x7FFF;
			Model = 26939;
			ObjectClass = 4;
			SubClass = 3;
			Level = 10;
			ReqLevel = 5;
			Name = "Charger's Boots";
			Name2 = "Charger's Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 328;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(War Torn Greaves)
*
***************************************************************/

namespace Server.Items
{
	public class WarTornGreaves : Item
	{
		public WarTornGreaves() : base()
		{
			Id = 15481;
			Resistance[0] = 84;
			SellPrice = 127;
			AvailableClasses = 0x7FFF;
			Model = 26956;
			ObjectClass = 4;
			SubClass = 3;
			Level = 13;
			ReqLevel = 8;
			Name = "War Torn Greaves";
			Name2 = "War Torn Greaves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 639;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Bloodspattered Sabatons)
*
***************************************************************/

namespace Server.Items
{
	public class BloodspatteredSabatons : Item
	{
		public BloodspatteredSabatons() : base()
		{
			Id = 15489;
			Resistance[0] = 104;
			Bonding = 2;
			SellPrice = 363;
			AvailableClasses = 0x7FFF;
			Model = 27001;
			ObjectClass = 4;
			SubClass = 3;
			Level = 16;
			ReqLevel = 11;
			Name = "Bloodspattered Sabatons";
			Name2 = "Bloodspattered Sabatons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 834;
			BuyPrice = 1817;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Outrunner's Slippers)
*
***************************************************************/

namespace Server.Items
{
	public class OutrunnersSlippers : Item
	{
		public OutrunnersSlippers() : base()
		{
			Id = 15498;
			Resistance[0] = 115;
			Bonding = 2;
			SellPrice = 674;
			AvailableClasses = 0x7FFF;
			Model = 27541;
			ObjectClass = 4;
			SubClass = 3;
			Level = 20;
			ReqLevel = 15;
			Name = "Outrunner's Slippers";
			Name2 = "Outrunner's Slippers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 835;
			BuyPrice = 3370;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Grunt's AnkleWraps)
*
***************************************************************/

namespace Server.Items
{
	public class GruntsAnkleWraps : Item
	{
		public GruntsAnkleWraps() : base()
		{
			Id = 15506;
			Resistance[0] = 117;
			Bonding = 2;
			SellPrice = 723;
			AvailableClasses = 0x7FFF;
			Model = 26970;
			ObjectClass = 4;
			SubClass = 3;
			Level = 21;
			ReqLevel = 16;
			Name = "Grunt's AnkleWraps";
			Name2 = "Grunt's AnkleWraps";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 835;
			BuyPrice = 3615;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Spiked Chain Slippers)
*
***************************************************************/

namespace Server.Items
{
	public class SpikedChainSlippers : Item
	{
		public SpikedChainSlippers() : base()
		{
			Id = 15516;
			Resistance[0] = 130;
			Bonding = 2;
			SellPrice = 1587;
			AvailableClasses = 0x7FFF;
			Model = 26964;
			ObjectClass = 4;
			SubClass = 3;
			Level = 27;
			ReqLevel = 22;
			Name = "Spiked Chain Slippers";
			Name2 = "Spiked Chain Slippers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 837;
			BuyPrice = 7939;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Sentry's Slippers)
*
***************************************************************/

namespace Server.Items
{
	public class SentrysSlippers : Item
	{
		public SentrysSlippers() : base()
		{
			Id = 15525;
			Resistance[0] = 132;
			Bonding = 2;
			SellPrice = 1634;
			AvailableClasses = 0x7FFF;
			Model = 27540;
			ObjectClass = 4;
			SubClass = 3;
			Level = 28;
			ReqLevel = 23;
			Name = "Sentry's Slippers";
			Name2 = "Sentry's Slippers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 838;
			BuyPrice = 8171;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Wicked Chain Boots)
*
***************************************************************/

namespace Server.Items
{
	public class WickedChainBoots : Item
	{
		public WickedChainBoots() : base()
		{
			Id = 15534;
			Resistance[0] = 138;
			Bonding = 2;
			SellPrice = 2308;
			AvailableClasses = 0x7FFF;
			Model = 27037;
			ObjectClass = 4;
			SubClass = 3;
			Level = 31;
			ReqLevel = 26;
			Name = "Wicked Chain Boots";
			Name2 = "Wicked Chain Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 839;
			BuyPrice = 11542;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Thick Scale Sabatons)
*
***************************************************************/

namespace Server.Items
{
	public class ThickScaleSabatons : Item
	{
		public ThickScaleSabatons() : base()
		{
			Id = 15544;
			Resistance[0] = 140;
			Bonding = 2;
			SellPrice = 2448;
			AvailableClasses = 0x7FFF;
			Model = 27022;
			ObjectClass = 4;
			SubClass = 3;
			Level = 32;
			ReqLevel = 27;
			Name = "Thick Scale Sabatons";
			Name2 = "Thick Scale Sabatons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 839;
			BuyPrice = 12243;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Pillager's Boots)
*
***************************************************************/

namespace Server.Items
{
	public class PillagersBoots : Item
	{
		public PillagersBoots() : base()
		{
			Id = 15555;
			Resistance[0] = 142;
			Bonding = 2;
			SellPrice = 2802;
			AvailableClasses = 0x7FFF;
			Model = 27065;
			ObjectClass = 4;
			SubClass = 3;
			Level = 33;
			ReqLevel = 28;
			Name = "Pillager's Boots";
			Name2 = "Pillager's Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 839;
			BuyPrice = 14013;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Marauder's Boots)
*
***************************************************************/

namespace Server.Items
{
	public class MaraudersBoots : Item
	{
		public MaraudersBoots() : base()
		{
			Id = 15565;
			Resistance[0] = 153;
			Bonding = 2;
			SellPrice = 4274;
			AvailableClasses = 0x7FFF;
			Model = 27059;
			ObjectClass = 4;
			SubClass = 3;
			Level = 38;
			ReqLevel = 33;
			Name = "Marauder's Boots";
			Name2 = "Marauder's Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 841;
			BuyPrice = 21370;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Sparkleshell Sabatons)
*
***************************************************************/

namespace Server.Items
{
	public class SparkleshellSabatons : Item
	{
		public SparkleshellSabatons() : base()
		{
			Id = 15576;
			Resistance[0] = 156;
			Bonding = 2;
			SellPrice = 4462;
			AvailableClasses = 0x7FFF;
			Model = 27115;
			ObjectClass = 4;
			SubClass = 3;
			Level = 39;
			ReqLevel = 34;
			Name = "Sparkleshell Sabatons";
			Name2 = "Sparkleshell Sabatons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 841;
			BuyPrice = 22314;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Steadfast Stompers)
*
***************************************************************/

namespace Server.Items
{
	public class SteadfastStompers : Item
	{
		public SteadfastStompers() : base()
		{
			Id = 15589;
			Resistance[0] = 161;
			Bonding = 2;
			SellPrice = 5462;
			AvailableClasses = 0x7FFF;
			Model = 27891;
			ObjectClass = 4;
			SubClass = 3;
			Level = 41;
			ReqLevel = 36;
			Name = "Steadfast Stompers";
			Name2 = "Steadfast Stompers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 842;
			BuyPrice = 27314;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Ancient Greaves)
*
***************************************************************/

namespace Server.Items
{
	public class AncientGreaves : Item
	{
		public AncientGreaves() : base()
		{
			Id = 15599;
			Resistance[0] = 168;
			Bonding = 2;
			SellPrice = 6631;
			AvailableClasses = 0x7FFF;
			Model = 27120;
			ObjectClass = 4;
			SubClass = 3;
			Level = 44;
			ReqLevel = 39;
			Name = "Ancient Greaves";
			Name2 = "Ancient Greaves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 843;
			BuyPrice = 33156;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Bonelink Sabatons)
*
***************************************************************/

namespace Server.Items
{
	public class BonelinkSabatons : Item
	{
		public BonelinkSabatons() : base()
		{
			Id = 15614;
			Resistance[0] = 171;
			Bonding = 2;
			SellPrice = 7026;
			AvailableClasses = 0x7FFF;
			Model = 27328;
			ObjectClass = 4;
			SubClass = 3;
			Level = 45;
			ReqLevel = 40;
			Name = "Bonelink Sabatons";
			Name2 = "Bonelink Sabatons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 843;
			BuyPrice = 35132;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Gryphon Mail Greaves)
*
***************************************************************/

namespace Server.Items
{
	public class GryphonMailGreaves : Item
	{
		public GryphonMailGreaves() : base()
		{
			Id = 15626;
			Resistance[0] = 178;
			Bonding = 2;
			SellPrice = 8798;
			AvailableClasses = 0x7FFF;
			Model = 27132;
			ObjectClass = 4;
			SubClass = 3;
			Level = 47;
			ReqLevel = 42;
			Name = "Gryphon Mail Greaves";
			Name2 = "Gryphon Mail Greaves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 844;
			BuyPrice = 43993;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Formidable Sabatons)
*
***************************************************************/

namespace Server.Items
{
	public class FormidableSabatons : Item
	{
		public FormidableSabatons() : base()
		{
			Id = 15630;
			Resistance[0] = 184;
			Bonding = 2;
			SellPrice = 10312;
			AvailableClasses = 0x7FFF;
			Model = 27215;
			ObjectClass = 4;
			SubClass = 3;
			Level = 49;
			ReqLevel = 44;
			Name = "Formidable Sabatons";
			Name2 = "Formidable Sabatons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 845;
			BuyPrice = 51564;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Ironhide Greaves)
*
***************************************************************/

namespace Server.Items
{
	public class IronhideGreaves : Item
	{
		public IronhideGreaves() : base()
		{
			Id = 15642;
			Resistance[0] = 195;
			Bonding = 2;
			SellPrice = 12162;
			AvailableClasses = 0x7FFF;
			Model = 27173;
			ObjectClass = 4;
			SubClass = 3;
			Level = 52;
			ReqLevel = 47;
			Name = "Ironhide Greaves";
			Name2 = "Ironhide Greaves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 846;
			BuyPrice = 60811;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Impenetrable Sabatons)
*
***************************************************************/

namespace Server.Items
{
	public class ImpenetrableSabatons : Item
	{
		public ImpenetrableSabatons() : base()
		{
			Id = 15658;
			Resistance[0] = 218;
			Bonding = 2;
			SellPrice = 17850;
			AvailableClasses = 0x7FFF;
			Model = 27301;
			ObjectClass = 4;
			SubClass = 3;
			Level = 59;
			ReqLevel = 54;
			Name = "Impenetrable Sabatons";
			Name2 = "Impenetrable Sabatons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 848;
			BuyPrice = 89254;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Magnificent Greaves)
*
***************************************************************/

namespace Server.Items
{
	public class MagnificentGreaves : Item
	{
		public MagnificentGreaves() : base()
		{
			Id = 15674;
			Resistance[0] = 221;
			Bonding = 2;
			SellPrice = 18464;
			AvailableClasses = 0x7FFF;
			Model = 27318;
			ObjectClass = 4;
			SubClass = 3;
			Level = 60;
			ReqLevel = 55;
			Name = "Magnificent Greaves";
			Name2 = "Magnificent Greaves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 848;
			BuyPrice = 92321;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Triumphant Sabatons)
*
***************************************************************/

namespace Server.Items
{
	public class TriumphantSabatons : Item
	{
		public TriumphantSabatons() : base()
		{
			Id = 15678;
			Resistance[0] = 231;
			Bonding = 2;
			SellPrice = 21693;
			AvailableClasses = 0x7FFF;
			Model = 27312;
			ObjectClass = 4;
			SubClass = 3;
			Level = 63;
			ReqLevel = 58;
			Name = "Triumphant Sabatons";
			Name2 = "Triumphant Sabatons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 849;
			BuyPrice = 108468;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Merciless Greaves)
*
***************************************************************/

namespace Server.Items
{
	public class MercilessGreaves : Item
	{
		public MercilessGreaves() : base()
		{
			Id = 15694;
			Resistance[0] = 201;
			Bonding = 2;
			SellPrice = 13264;
			AvailableClasses = 0x7FFF;
			Model = 27288;
			ObjectClass = 4;
			SubClass = 3;
			Level = 54;
			ReqLevel = 49;
			Name = "Merciless Greaves";
			Name2 = "Merciless Greaves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 846;
			BuyPrice = 66322;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Knight-Lieutenant's Chain Boots)
*
***************************************************************/

namespace Server.Items
{
	public class KnightLieutenantsChainBoots : Item
	{
		public KnightLieutenantsChainBoots() : base()
		{
			Id = 16401;
			Resistance[0] = 255;
			Bonding = 1;
			SellPrice = 13596;
			AvailableClasses = 0x04;
			Model = 31244;
			ObjectClass = 4;
			SubClass = 3;
			Level = 63;
			ReqLevel = 58;
			Name = "Knight-Lieutenant's Chain Boots";
			Name2 = "Knight-Lieutenant's Chain Boots";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 67983;
			Sets = 362;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			Durability = 60;
			Flags = 32768;
			SetSpell( 13669 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 17;
			AgilityBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Marshal's Chain Boots)
*
***************************************************************/

namespace Server.Items
{
	public class MarshalsChainBoots : Item
	{
		public MarshalsChainBoots() : base()
		{
			Id = 16462;
			Resistance[0] = 286;
			Bonding = 1;
			SellPrice = 18642;
			AvailableClasses = 0x04;
			Model = 32095;
			ObjectClass = 4;
			SubClass = 3;
			Level = 65;
			ReqLevel = 60;
			Name = "Marshal's Chain Boots";
			Name2 = "Marshal's Chain Boots";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 93211;
			Sets = 395;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			Durability = 70;
			Flags = 32768;
			SetSpell( 13669 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 26;
			AgilityBonus = 14;
		}
	}
}


/**************************************************************
*
*				(Blood Guard's Mail Walkers)
*
***************************************************************/

namespace Server.Items
{
	public class BloodGuardsMailWalkers : Item
	{
		public BloodGuardsMailWalkers() : base()
		{
			Id = 16518;
			Resistance[0] = 255;
			Bonding = 1;
			SellPrice = 12485;
			AvailableClasses = 0x40;
			Model = 31183;
			ObjectClass = 4;
			SubClass = 3;
			Level = 63;
			ReqLevel = 58;
			Name = "Blood Guard's Mail Walkers";
			Name2 = "Blood Guard's Mail Walkers";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 62426;
			Sets = 301;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			Durability = 60;
			Flags = 32768;
			SetSpell( 9343 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 22801 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 14;
			SpiritBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Blood Guard's Chain Boots)
*
***************************************************************/

namespace Server.Items
{
	public class BloodGuardsChainBoots : Item
	{
		public BloodGuardsChainBoots() : base()
		{
			Id = 16531;
			Resistance[0] = 255;
			Bonding = 1;
			SellPrice = 13452;
			AvailableClasses = 0x04;
			Model = 31181;
			ObjectClass = 4;
			SubClass = 3;
			Level = 63;
			ReqLevel = 58;
			Name = "Blood Guard's Chain Boots";
			Name2 = "Blood Guard's Chain Boots";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 67261;
			Sets = 361;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			Durability = 60;
			Flags = 32768;
			SetSpell( 13669 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 17;
			AgilityBonus = 10;
		}
	}
}


/**************************************************************
*
*				(General's Chain Boots)
*
***************************************************************/

namespace Server.Items
{
	public class GeneralsChainBoots : Item
	{
		public GeneralsChainBoots() : base()
		{
			Id = 16569;
			Resistance[0] = 286;
			Bonding = 1;
			SellPrice = 19629;
			AvailableClasses = 0x04;
			Model = 32124;
			ObjectClass = 4;
			SubClass = 3;
			Level = 65;
			ReqLevel = 60;
			Name = "General's Chain Boots";
			Name2 = "General's Chain Boots";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 98146;
			Sets = 396;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			Durability = 70;
			Flags = 32768;
			SetSpell( 13669 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 26;
			AgilityBonus = 14;
		}
	}
}


/**************************************************************
*
*				(General's Mail Boots)
*
***************************************************************/

namespace Server.Items
{
	public class GeneralsMailBoots : Item
	{
		public GeneralsMailBoots() : base()
		{
			Id = 16573;
			Resistance[0] = 286;
			Bonding = 1;
			SellPrice = 18502;
			AvailableClasses = 0x40;
			Model = 32126;
			ObjectClass = 4;
			SubClass = 3;
			Level = 65;
			ReqLevel = 60;
			Name = "General's Mail Boots";
			Name2 = "General's Mail Boots";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 92513;
			Sets = 386;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			Durability = 70;
			Flags = 32768;
			SetSpell( 22801 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 14254 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 18;
			SpiritBonus = 17;
		}
	}
}


/**************************************************************
*
*				(Boots of Elements)
*
***************************************************************/

namespace Server.Items
{
	public class BootsOfElements : Item
	{
		public BootsOfElements() : base()
		{
			Id = 16670;
			Resistance[0] = 240;
			Bonding = 1;
			SellPrice = 21027;
			AvailableClasses = 0x7FFF;
			Model = 31412;
			ObjectClass = 4;
			SubClass = 3;
			Level = 59;
			ReqLevel = 54;
			Name = "Boots of Elements";
			Name2 = "Boots of Elements";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 105136;
			Sets = 187;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			IqBonus = 17;
			AgilityBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Beaststalker's Boots)
*
***************************************************************/

namespace Server.Items
{
	public class BeaststalkersBoots : Item
	{
		public BeaststalkersBoots() : base()
		{
			Id = 16675;
			Resistance[0] = 240;
			Bonding = 1;
			SellPrice = 21421;
			AvailableClasses = 0x7FFF;
			Model = 31408;
			ObjectClass = 4;
			SubClass = 3;
			Level = 59;
			ReqLevel = 54;
			Name = "Beaststalker's Boots";
			Name2 = "Beaststalker's Boots";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 107106;
			Sets = 186;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			AgilityBonus = 21;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Earthfury Boots)
*
***************************************************************/

namespace Server.Items
{
	public class EarthfuryBoots : Item
	{
		public EarthfuryBoots() : base()
		{
			Id = 16837;
			Resistance[0] = 290;
			Bonding = 1;
			SellPrice = 38550;
			AvailableClasses = 0x40;
			Model = 31830;
			ObjectClass = 4;
			SubClass = 3;
			Level = 66;
			ReqLevel = 60;
			Name = "Earthfury Boots";
			Name2 = "Earthfury Boots";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 192750;
			Sets = 207;
			Resistance[5] = 7;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 70;
			SetSpell( 9406 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 10;
			IqBonus = 22;
			StaminaBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Giantstalker's Boots)
*
***************************************************************/

namespace Server.Items
{
	public class GiantstalkersBoots : Item
	{
		public GiantstalkersBoots() : base()
		{
			Id = 16849;
			Resistance[0] = 290;
			Bonding = 1;
			SellPrice = 41382;
			AvailableClasses = 0x04;
			Model = 32040;
			ObjectClass = 4;
			SubClass = 3;
			Level = 66;
			ReqLevel = 60;
			Name = "Giantstalker's Boots";
			Name2 = "Giantstalker's Boots";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 206912;
			Sets = 206;
			Resistance[5] = 7;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 70;
			AgilityBonus = 28;
			IqBonus = 6;
			StaminaBonus = 14;
		}
	}
}


/**************************************************************
*
*				(Dragonstalker's Greaves)
*
***************************************************************/

namespace Server.Items
{
	public class DragonstalkersGreaves : Item
	{
		public DragonstalkersGreaves() : base()
		{
			Id = 16941;
			Resistance[0] = 332;
			Bonding = 1;
			SellPrice = 67178;
			AvailableClasses = 0x04;
			Model = 29813;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 3;
			Level = 76;
			ReqLevel = 60;
			Name = "Dragonstalker's Greaves";
			Name2 = "Dragonstalker's Greaves";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 335892;
			Sets = 215;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 70;
			AgilityBonus = 30;
			SpiritBonus = 6;
			IqBonus = 6;
			StaminaBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Greaves of Ten Storms)
*
***************************************************************/

namespace Server.Items
{
	public class GreavesOfTenStorms : Item
	{
		public GreavesOfTenStorms() : base()
		{
			Id = 16949;
			Resistance[0] = 332;
			Bonding = 1;
			SellPrice = 62552;
			AvailableClasses = 0x40;
			Model = 29791;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 3;
			Level = 76;
			ReqLevel = 60;
			Name = "Greaves of Ten Storms";
			Name2 = "Greaves of Ten Storms";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 312760;
			Sets = 216;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 70;
			SetSpell( 14799 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 16;
			IqBonus = 16;
			StaminaBonus = 17;
		}
	}
}


/**************************************************************
*
*				(Black Dragonscale Boots)
*
***************************************************************/

namespace Server.Items
{
	public class BlackDragonscaleBoots : Item
	{
		public BlackDragonscaleBoots() : base()
		{
			Id = 16984;
			Resistance[0] = 270;
			Bonding = 2;
			SellPrice = 32653;
			AvailableClasses = 0x7FFF;
			Model = 28760;
			Resistance[2] = 24;
			ObjectClass = 4;
			SubClass = 3;
			Level = 61;
			ReqLevel = 56;
			Name = "Black Dragonscale Boots";
			Name2 = "Black Dragonscale Boots";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 163269;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 8;
			Durability = 70;
			SetSpell( 9335 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Flame Walkers)
*
***************************************************************/

namespace Server.Items
{
	public class FlameWalkers : Item
	{
		public FlameWalkers() : base()
		{
			Id = 18047;
			Resistance[0] = 251;
			Bonding = 1;
			SellPrice = 24428;
			AvailableClasses = 0x7FFF;
			Model = 30439;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 3;
			Level = 62;
			ReqLevel = 57;
			Name = "Flame Walkers";
			Name2 = "Flame Walkers";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 122141;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			SetSpell( 13670 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Merciful Greaves)
*
***************************************************************/

namespace Server.Items
{
	public class MercifulGreaves : Item
	{
		public MercifulGreaves() : base()
		{
			Id = 18318;
			Resistance[0] = 240;
			Bonding = 1;
			SellPrice = 22057;
			AvailableClasses = 0x7FFF;
			Model = 30679;
			ObjectClass = 4;
			SubClass = 3;
			Level = 59;
			ReqLevel = 54;
			Name = "Merciful Greaves";
			Name2 = "Merciful Greaves";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 110286;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			SetSpell( 9407 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 14;
			StaminaBonus = 14;
		}
	}
}


/**************************************************************
*
*				(Odious Greaves)
*
***************************************************************/

namespace Server.Items
{
	public class OdiousGreaves : Item
	{
		public OdiousGreaves() : base()
		{
			Id = 18379;
			Resistance[0] = 251;
			Bonding = 1;
			SellPrice = 23791;
			AvailableClasses = 0x7FFF;
			Model = 30736;
			ObjectClass = 4;
			SubClass = 3;
			Level = 62;
			ReqLevel = 57;
			Name = "Odious Greaves";
			Name2 = "Odious Greaves";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 118957;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			SetSpell( 9332 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 18;
			SpiritBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Bloody Chain Boots)
*
***************************************************************/

namespace Server.Items
{
	public class BloodyChainBoots : Item
	{
		public BloodyChainBoots() : base()
		{
			Id = 18612;
			Resistance[0] = 61;
			Bonding = 2;
			SellPrice = 34;
			AvailableClasses = 0x7FFF;
			Model = 6845;
			ObjectClass = 4;
			SubClass = 3;
			Level = 8;
			ReqLevel = 3;
			Name = "Bloody Chain Boots";
			Name2 = "Bloody Chain Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 171;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Shadowy Mail Greaves)
*
***************************************************************/

namespace Server.Items
{
	public class ShadowyMailGreaves : Item
	{
		public ShadowyMailGreaves() : base()
		{
			Id = 18694;
			Resistance[0] = 251;
			Bonding = 1;
			SellPrice = 25910;
			AvailableClasses = 0x7FFF;
			Model = 7002;
			ObjectClass = 4;
			SubClass = 3;
			Level = 62;
			ReqLevel = 57;
			Name = "Shadowy Mail Greaves";
			Name2 = "Shadowy Mail Greaves";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 129554;
			Resistance[5] = 10;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			StaminaBonus = 22;
		}
	}
}


/**************************************************************
*
*				(Sabatons of the Flamewalker)
*
***************************************************************/

namespace Server.Items
{
	public class SabatonsOfTheFlamewalker : Item
	{
		public SabatonsOfTheFlamewalker() : base()
		{
			Id = 19144;
			Resistance[0] = 298;
			Bonding = 1;
			SellPrice = 45973;
			AvailableClasses = 0x7FFF;
			Model = 31662;
			ObjectClass = 4;
			SubClass = 3;
			Level = 68;
			ReqLevel = 60;
			Name = "Sabatons of the Flamewalker";
			Name2 = "Sabatons of the Flamewalker";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 229869;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 5;
			Durability = 70;
			SetSpell( 9336 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 27;
			SpiritBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Dusty Mail Boots)
*
***************************************************************/

namespace Server.Items
{
	public class DustyMailBoots : Item
	{
		public DustyMailBoots() : base()
		{
			Id = 19509;
			Resistance[0] = 221;
			Bonding = 1;
			SellPrice = 2583;
			AvailableClasses = 0x7FFF;
			Model = 32038;
			ObjectClass = 4;
			SubClass = 3;
			Level = 41;
			ReqLevel = 36;
			Name = "Dusty Mail Boots";
			Name2 = "Dusty Mail Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 12917;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			Durability = 50;
			StaminaBonus = 9;
		}
	}
}


