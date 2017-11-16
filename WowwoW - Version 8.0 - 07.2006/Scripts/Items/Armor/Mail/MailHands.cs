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
*				(Scalemail Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class ScalemailGloves : Item
	{
		public ScalemailGloves() : base()
		{
			Id = 718;
			Resistance[0] = 103;
			SellPrice = 322;
			AvailableClasses = 0x7FFF;
			Model = 6986;
			ObjectClass = 4;
			SubClass = 3;
			Level = 22;
			ReqLevel = 17;
			Name = "Scalemail Gloves";
			Name2 = "Scalemail Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1614;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Chainmail Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class ChainmailGloves : Item
	{
		public ChainmailGloves() : base()
		{
			Id = 850;
			Resistance[0] = 94;
			SellPrice = 176;
			AvailableClasses = 0x7FFF;
			Model = 6871;
			ObjectClass = 4;
			SubClass = 3;
			Level = 17;
			ReqLevel = 12;
			Name = "Chainmail Gloves";
			Name2 = "Chainmail Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 883;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Bridgeworker's Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class BridgeworkersGloves : Item
	{
		public BridgeworkersGloves() : base()
		{
			Id = 1303;
			Resistance[0] = 105;
			Bonding = 1;
			SellPrice = 418;
			AvailableClasses = 0x7FFF;
			Model = 6871;
			ObjectClass = 4;
			SubClass = 3;
			Level = 20;
			Name = "Bridgeworker's Gloves";
			Name2 = "Bridgeworker's Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2091;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 30;
			StrBonus = 4;
			IqBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Stormwind Chain Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class StormwindChainGloves : Item
	{
		public StormwindChainGloves() : base()
		{
			Id = 1360;
			Resistance[0] = 64;
			Bonding = 1;
			SellPrice = 42;
			AvailableClasses = 0x7FFF;
			Model = 7000;
			ObjectClass = 4;
			SubClass = 3;
			Level = 10;
			Name = "Stormwind Chain Gloves";
			Name2 = "Stormwind Chain Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 210;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Blackrock Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class BlackrockGauntlets : Item
	{
		public BlackrockGauntlets() : base()
		{
			Id = 1448;
			Resistance[0] = 105;
			Bonding = 2;
			SellPrice = 405;
			AvailableClasses = 0x7FFF;
			Model = 6842;
			ObjectClass = 4;
			SubClass = 3;
			Level = 20;
			ReqLevel = 15;
			Name = "Blackrock Gauntlets";
			Name2 = "Blackrock Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2027;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 30;
			StrBonus = 3;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Worn Mail Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class WornMailGloves : Item
	{
		public WornMailGloves() : base()
		{
			Id = 1734;
			Resistance[0] = 65;
			SellPrice = 39;
			AvailableClasses = 0x7FFF;
			Model = 6905;
			ObjectClass = 4;
			SubClass = 3;
			Level = 11;
			ReqLevel = 6;
			Name = "Worn Mail Gloves";
			Name2 = "Worn Mail Gloves";
			AvailableRaces = 0x1FF;
			BuyPrice = 197;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Laced Mail Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class LacedMailGloves : Item
	{
		public LacedMailGloves() : base()
		{
			Id = 1742;
			Resistance[0] = 91;
			SellPrice = 129;
			AvailableClasses = 0x7FFF;
			Model = 6905;
			ObjectClass = 4;
			SubClass = 3;
			Level = 18;
			ReqLevel = 13;
			Name = "Laced Mail Gloves";
			Name2 = "Laced Mail Gloves";
			AvailableRaces = 0x1FF;
			BuyPrice = 648;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Linked Chain Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class LinkedChainGloves : Item
	{
		public LinkedChainGloves() : base()
		{
			Id = 1750;
			Resistance[0] = 101;
			SellPrice = 298;
			AvailableClasses = 0x7FFF;
			Model = 6905;
			ObjectClass = 4;
			SubClass = 3;
			Level = 24;
			ReqLevel = 19;
			Name = "Linked Chain Gloves";
			Name2 = "Linked Chain Gloves";
			AvailableRaces = 0x1FF;
			BuyPrice = 1491;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Reinforced Chain Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class ReinforcedChainGloves : Item
	{
		public ReinforcedChainGloves() : base()
		{
			Id = 1758;
			Resistance[0] = 111;
			SellPrice = 534;
			AvailableClasses = 0x7FFF;
			Model = 6905;
			ObjectClass = 4;
			SubClass = 3;
			Level = 30;
			ReqLevel = 25;
			Name = "Reinforced Chain Gloves";
			Name2 = "Reinforced Chain Gloves";
			AvailableRaces = 0x1FF;
			BuyPrice = 2670;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Chief Brigadier Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class ChiefBrigadierGauntlets : Item
	{
		public ChiefBrigadierGauntlets() : base()
		{
			Id = 1988;
			Resistance[0] = 139;
			Bonding = 2;
			SellPrice = 2852;
			AvailableClasses = 0x7FFF;
			Model = 25892;
			ObjectClass = 4;
			SubClass = 3;
			Level = 38;
			ReqLevel = 33;
			Name = "Chief Brigadier Gauntlets";
			Name2 = "Chief Brigadier Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 14260;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			StrBonus = 6;
			StaminaBonus = 6;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Polished Scale Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class PolishedScaleGloves : Item
	{
		public PolishedScaleGloves() : base()
		{
			Id = 2151;
			Resistance[0] = 112;
			SellPrice = 588;
			AvailableClasses = 0x7FFF;
			Model = 6975;
			ObjectClass = 4;
			SubClass = 3;
			Level = 27;
			ReqLevel = 22;
			Name = "Polished Scale Gloves";
			Name2 = "Polished Scale Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2941;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Gloves of Brawn)
*
***************************************************************/

namespace Server.Items
{
	public class GlovesOfBrawn : Item
	{
		public GlovesOfBrawn() : base()
		{
			Id = 2230;
			Resistance[0] = 112;
			Bonding = 1;
			SellPrice = 714;
			AvailableClasses = 0x7FFF;
			Model = 6930;
			ObjectClass = 4;
			SubClass = 3;
			Level = 24;
			Name = "Gloves of Brawn";
			Name2 = "Gloves of Brawn";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3570;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 30;
			StrBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Sapper's Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class SappersGloves : Item
	{
		public SappersGloves() : base()
		{
			Id = 2274;
			Resistance[0] = 99;
			Bonding = 2;
			SellPrice = 289;
			AvailableClasses = 0x7FFF;
			Model = 6883;
			ObjectClass = 4;
			SubClass = 3;
			Level = 17;
			ReqLevel = 12;
			Name = "Sapper's Gloves";
			Name2 = "Sapper's Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1447;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 25;
			StrBonus = 3;
			AgilityBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Tarnished Chain Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class TarnishedChainGloves : Item
	{
		public TarnishedChainGloves() : base()
		{
			Id = 2385;
			Resistance[0] = 42;
			SellPrice = 7;
			AvailableClasses = 0x7FFF;
			Model = 6905;
			ObjectClass = 4;
			SubClass = 3;
			Level = 5;
			ReqLevel = 1;
			Name = "Tarnished Chain Gloves";
			Name2 = "Tarnished Chain Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 37;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 18;
		}
	}
}


/**************************************************************
*
*				(Rusted Chain Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class RustedChainGloves : Item
	{
		public RustedChainGloves() : base()
		{
			Id = 2391;
			Resistance[0] = 42;
			SellPrice = 7;
			AvailableClasses = 0x7FFF;
			Model = 6954;
			ObjectClass = 4;
			SubClass = 3;
			Level = 5;
			ReqLevel = 1;
			Name = "Rusted Chain Gloves";
			Name2 = "Rusted Chain Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 38;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 18;
		}
	}
}


/**************************************************************
*
*				(Light Mail Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class LightMailGloves : Item
	{
		public LightMailGloves() : base()
		{
			Id = 2397;
			Resistance[0] = 64;
			SellPrice = 43;
			AvailableClasses = 0x7FFF;
			Model = 6955;
			ObjectClass = 4;
			SubClass = 3;
			Level = 10;
			ReqLevel = 5;
			Name = "Light Mail Gloves";
			Name2 = "Light Mail Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 215;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Light Chain Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class LightChainGloves : Item
	{
		public LightChainGloves() : base()
		{
			Id = 2403;
			Resistance[0] = 64;
			SellPrice = 44;
			AvailableClasses = 0x7FFF;
			Model = 6954;
			ObjectClass = 4;
			SubClass = 3;
			Level = 10;
			ReqLevel = 5;
			Name = "Light Chain Gloves";
			Name2 = "Light Chain Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 220;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Augmented Chain Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class AugmentedChainGloves : Item
	{
		public AugmentedChainGloves() : base()
		{
			Id = 2422;
			Resistance[0] = 130;
			SellPrice = 1596;
			AvailableClasses = 0x7FFF;
			Model = 6822;
			ObjectClass = 4;
			SubClass = 3;
			Level = 37;
			ReqLevel = 32;
			Name = "Augmented Chain Gloves";
			Name2 = "Augmented Chain Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 7981;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Brigandine Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class BrigandineGloves : Item
	{
		public BrigandineGloves() : base()
		{
			Id = 2428;
			Resistance[0] = 162;
			SellPrice = 4044;
			AvailableClasses = 0x7FFF;
			Model = 6856;
			ObjectClass = 4;
			SubClass = 3;
			Level = 50;
			ReqLevel = 45;
			Name = "Brigandine Gloves";
			Name2 = "Brigandine Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 20222;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Boar Handler Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class BoarHandlerGloves : Item
	{
		public BoarHandlerGloves() : base()
		{
			Id = 2547;
			Resistance[0] = 42;
			Bonding = 1;
			SellPrice = 7;
			AvailableClasses = 0x7FFF;
			Model = 6905;
			ObjectClass = 4;
			SubClass = 3;
			Level = 5;
			Name = "Boar Handler Gloves";
			Name2 = "Boar Handler Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 36;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 18;
		}
	}
}


/**************************************************************
*
*				(Loose Chain Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class LooseChainGloves : Item
	{
		public LooseChainGloves() : base()
		{
			Id = 2645;
			Resistance[0] = 48;
			SellPrice = 11;
			AvailableClasses = 0x7FFF;
			Model = 6905;
			ObjectClass = 4;
			SubClass = 3;
			Level = 7;
			ReqLevel = 2;
			Name = "Loose Chain Gloves";
			Name2 = "Loose Chain Gloves";
			AvailableRaces = 0x1FF;
			BuyPrice = 56;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Flimsy Chain Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class FlimsyChainGloves : Item
	{
		public FlimsyChainGloves() : base()
		{
			Id = 2653;
			Resistance[0] = 35;
			SellPrice = 3;
			AvailableClasses = 0x7FFF;
			Model = 6905;
			ObjectClass = 4;
			SubClass = 3;
			Level = 4;
			ReqLevel = 1;
			Name = "Flimsy Chain Gloves";
			Name2 = "Flimsy Chain Gloves";
			AvailableRaces = 0x1FF;
			BuyPrice = 15;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 18;
		}
	}
}


/**************************************************************
*
*				(Warrior's Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class WarriorsGloves : Item
	{
		public WarriorsGloves() : base()
		{
			Id = 2968;
			Resistance[0] = 59;
			SellPrice = 33;
			AvailableClasses = 0x7FFF;
			Model = 22676;
			ObjectClass = 4;
			SubClass = 3;
			Level = 9;
			ReqLevel = 4;
			Name = "Warrior's Gloves";
			Name2 = "Warrior's Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 169;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Veteran Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class VeteranGloves : Item
	{
		public VeteranGloves() : base()
		{
			Id = 2980;
			Resistance[0] = 90;
			Bonding = 2;
			SellPrice = 209;
			AvailableClasses = 0x7FFF;
			Model = 12450;
			ObjectClass = 4;
			SubClass = 3;
			Level = 15;
			ReqLevel = 10;
			Name = "Veteran Gloves";
			Name2 = "Veteran Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1047;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 25;
			StrBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Burnished Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class BurnishedGloves : Item
	{
		public BurnishedGloves() : base()
		{
			Id = 2992;
			Resistance[0] = 105;
			Bonding = 2;
			SellPrice = 408;
			AvailableClasses = 0x7FFF;
			Model = 16731;
			ObjectClass = 4;
			SubClass = 3;
			Level = 20;
			ReqLevel = 15;
			Name = "Burnished Gloves";
			Name2 = "Burnished Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2044;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 30;
			StrBonus = 4;
			AgilityBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Lambent Scale Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class LambentScaleGloves : Item
	{
		public LambentScaleGloves() : base()
		{
			Id = 3047;
			Resistance[0] = 118;
			Bonding = 2;
			SellPrice = 1052;
			AvailableClasses = 0x7FFF;
			Model = 25782;
			ObjectClass = 4;
			SubClass = 3;
			Level = 27;
			ReqLevel = 22;
			Name = "Lambent Scale Gloves";
			Name2 = "Lambent Scale Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5260;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			StrBonus = 6;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Battle Chain Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class BattleChainGloves : Item
	{
		public BattleChainGloves() : base()
		{
			Id = 3281;
			Resistance[0] = 68;
			SellPrice = 56;
			AvailableClasses = 0x7FFF;
			Model = 27175;
			ObjectClass = 4;
			SubClass = 3;
			Level = 11;
			ReqLevel = 6;
			Name = "Battle Chain Gloves";
			Name2 = "Battle Chain Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 280;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Brackwater Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class BrackwaterGauntlets : Item
	{
		public BrackwaterGauntlets() : base()
		{
			Id = 3304;
			Resistance[0] = 81;
			SellPrice = 106;
			AvailableClasses = 0x7FFF;
			Model = 28997;
			ObjectClass = 4;
			SubClass = 3;
			Level = 14;
			ReqLevel = 9;
			Name = "Brackwater Gauntlets";
			Name2 = "Brackwater Gauntlets";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 533;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Gauntlets of Ogre Strength)
*
***************************************************************/

namespace Server.Items
{
	public class GauntletsOfOgreStrength : Item
	{
		public GauntletsOfOgreStrength() : base()
		{
			Id = 3341;
			Resistance[0] = 128;
			Bonding = 2;
			SellPrice = 1621;
			AvailableClasses = 0x7FFF;
			Model = 6920;
			ObjectClass = 4;
			SubClass = 3;
			Level = 32;
			ReqLevel = 27;
			Name = "Gauntlets of Ogre Strength";
			Name2 = "Gauntlets of Ogre Strength";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 8108;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			SetSpell( 9329 , 1 , 0 , -1 , 0 , -1 );
			StrBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Rugged Mail Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class RuggedMailGloves : Item
	{
		public RuggedMailGloves() : base()
		{
			Id = 3458;
			Resistance[0] = 101;
			Bonding = 1;
			SellPrice = 334;
			AvailableClasses = 0x7FFF;
			Model = 6982;
			ObjectClass = 4;
			SubClass = 3;
			Level = 18;
			Name = "Rugged Mail Gloves";
			Name2 = "Rugged Mail Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1670;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 25;
			StrBonus = 3;
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Runed Copper Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class RunedCopperGauntlets : Item
	{
		public RunedCopperGauntlets() : base()
		{
			Id = 3472;
			Resistance[0] = 73;
			SellPrice = 71;
			AvailableClasses = 0x7FFF;
			Model = 25850;
			ObjectClass = 4;
			SubClass = 3;
			Level = 12;
			ReqLevel = 7;
			Name = "Runed Copper Gauntlets";
			Name2 = "Runed Copper Gauntlets";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 357;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Gemmed Copper Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class GemmedCopperGauntlets : Item
	{
		public GemmedCopperGauntlets() : base()
		{
			Id = 3474;
			Resistance[0] = 90;
			Bonding = 2;
			SellPrice = 216;
			AvailableClasses = 0x7FFF;
			Model = 9390;
			ObjectClass = 4;
			SubClass = 3;
			Level = 15;
			ReqLevel = 10;
			Name = "Gemmed Copper Gauntlets";
			Name2 = "Gemmed Copper Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 749;
			BuyPrice = 1083;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Silvered Bronze Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class SilveredBronzeGauntlets : Item
	{
		public SilveredBronzeGauntlets() : base()
		{
			Id = 3483;
			Resistance[0] = 118;
			Bonding = 2;
			SellPrice = 965;
			AvailableClasses = 0x7FFF;
			Model = 9406;
			ObjectClass = 4;
			SubClass = 3;
			Level = 27;
			ReqLevel = 22;
			Name = "Silvered Bronze Gauntlets";
			Name2 = "Silvered Bronze Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4828;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			StrBonus = 4;
			StaminaBonus = 4;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Green Iron Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class GreenIronGauntlets : Item
	{
		public GreenIronGauntlets() : base()
		{
			Id = 3485;
			Resistance[0] = 124;
			Bonding = 2;
			SellPrice = 1295;
			AvailableClasses = 0x7FFF;
			Model = 9414;
			ObjectClass = 4;
			SubClass = 3;
			Level = 30;
			ReqLevel = 25;
			Name = "Green Iron Gauntlets";
			Name2 = "Green Iron Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6477;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			StaminaBonus = 6;
			StrBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Night Watch Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class NightWatchGauntlets : Item
	{
		public NightWatchGauntlets() : base()
		{
			Id = 3559;
			Resistance[0] = 107;
			Bonding = 1;
			SellPrice = 473;
			AvailableClasses = 0x7FFF;
			Model = 11626;
			ObjectClass = 4;
			SubClass = 3;
			Level = 21;
			Name = "Night Watch Gauntlets";
			Name2 = "Night Watch Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2368;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 30;
			StrBonus = 4;
			AgilityBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Double Mail Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class DoubleMailGloves : Item
	{
		public DoubleMailGloves() : base()
		{
			Id = 3812;
			Resistance[0] = 122;
			SellPrice = 971;
			AvailableClasses = 0x7FFF;
			Model = 6905;
			ObjectClass = 4;
			SubClass = 3;
			Level = 36;
			ReqLevel = 31;
			Name = "Double Mail Gloves";
			Name2 = "Double Mail Gloves";
			AvailableRaces = 0x1FF;
			BuyPrice = 4856;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Laminated Scale Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class LaminatedScaleGloves : Item
	{
		public LaminatedScaleGloves() : base()
		{
			Id = 3996;
			Resistance[0] = 179;
			SellPrice = 4659;
			AvailableClasses = 0x7FFF;
			Model = 6949;
			ObjectClass = 4;
			SubClass = 3;
			Level = 59;
			ReqLevel = 54;
			Name = "Laminated Scale Gloves";
			Name2 = "Laminated Scale Gloves";
			AvailableRaces = 0x1FF;
			BuyPrice = 23299;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Overlinked Chain Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class OverlinkedChainGloves : Item
	{
		public OverlinkedChainGloves() : base()
		{
			Id = 4004;
			Resistance[0] = 145;
			SellPrice = 2357;
			AvailableClasses = 0x7FFF;
			Model = 6967;
			ObjectClass = 4;
			SubClass = 3;
			Level = 47;
			ReqLevel = 42;
			Name = "Overlinked Chain Gloves";
			Name2 = "Overlinked Chain Gloves";
			AvailableRaces = 0x1FF;
			BuyPrice = 11788;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Glimmering Mail Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class GlimmeringMailGauntlets : Item
	{
		public GlimmeringMailGauntlets() : base()
		{
			Id = 4072;
			Resistance[0] = 124;
			Bonding = 2;
			SellPrice = 1340;
			AvailableClasses = 0x7FFF;
			Model = 25802;
			ObjectClass = 4;
			SubClass = 3;
			Level = 30;
			ReqLevel = 25;
			Name = "Glimmering Mail Gauntlets";
			Name2 = "Glimmering Mail Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6704;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			StrBonus = 7;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Mail Combat Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class MailCombatGauntlets : Item
	{
		public MailCombatGauntlets() : base()
		{
			Id = 4075;
			Resistance[0] = 131;
			Bonding = 2;
			SellPrice = 1984;
			AvailableClasses = 0x7FFF;
			Model = 25811;
			ObjectClass = 4;
			SubClass = 3;
			Level = 34;
			ReqLevel = 29;
			Name = "Mail Combat Gauntlets";
			Name2 = "Mail Combat Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 9924;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			StrBonus = 8;
			AgilityBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Blackforge Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class BlackforgeGauntlets : Item
	{
		public BlackforgeGauntlets() : base()
		{
			Id = 4083;
			Resistance[0] = 153;
			Bonding = 2;
			SellPrice = 4328;
			AvailableClasses = 0x7FFF;
			Model = 26075;
			ObjectClass = 4;
			SubClass = 3;
			Level = 44;
			ReqLevel = 39;
			Name = "Blackforge Gauntlets";
			Name2 = "Blackforge Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 21644;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			IqBonus = 12;
			AgilityBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Bonefist Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class BonefistGauntlets : Item
	{
		public BonefistGauntlets() : base()
		{
			Id = 4465;
			Resistance[0] = 128;
			Bonding = 2;
			SellPrice = 1585;
			AvailableClasses = 0x7FFF;
			Model = 6844;
			ObjectClass = 4;
			SubClass = 3;
			Level = 32;
			ReqLevel = 27;
			Name = "Bonefist Gauntlets";
			Name2 = "Bonefist Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7928;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			StrBonus = 8;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Skeletal Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class SkeletalGauntlets : Item
	{
		public SkeletalGauntlets() : base()
		{
			Id = 4676;
			Resistance[0] = 99;
			Bonding = 2;
			SellPrice = 278;
			AvailableClasses = 0x7FFF;
			Model = 6991;
			ObjectClass = 4;
			SubClass = 3;
			Level = 17;
			ReqLevel = 12;
			Name = "Skeletal Gauntlets";
			Name2 = "Skeletal Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1390;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 25;
			StrBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Painted Chain Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class PaintedChainGloves : Item
	{
		public PaintedChainGloves() : base()
		{
			Id = 4910;
			Resistance[0] = 42;
			Bonding = 1;
			SellPrice = 7;
			AvailableClasses = 0x7FFF;
			Model = 6969;
			ObjectClass = 4;
			SubClass = 3;
			Level = 5;
			Name = "Painted Chain Gloves";
			Name2 = "Painted Chain Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 38;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 18;
		}
	}
}


/**************************************************************
*
*				(Riveted Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class RivetedGauntlets : Item
	{
		public RivetedGauntlets() : base()
		{
			Id = 5312;
			Resistance[0] = 105;
			Bonding = 1;
			SellPrice = 419;
			AvailableClasses = 0x7FFF;
			Model = 7540;
			ObjectClass = 4;
			SubClass = 3;
			Level = 20;
			Name = "Riveted Gauntlets";
			Name2 = "Riveted Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2099;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 30;
			StrBonus = 4;
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Moss-covered Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class MossCoveredGauntlets : Item
	{
		public MossCoveredGauntlets() : base()
		{
			Id = 5589;
			Resistance[0] = 64;
			Bonding = 1;
			SellPrice = 41;
			AvailableClasses = 0x7FFF;
			Model = 8292;
			ObjectClass = 4;
			SubClass = 3;
			Level = 10;
			Name = "Moss-covered Gauntlets";
			Name2 = "Moss-covered Gauntlets";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 206;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Cold Steel Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class ColdSteelGauntlets : Item
	{
		public ColdSteelGauntlets() : base()
		{
			Id = 6063;
			Resistance[0] = 55;
			Bonding = 1;
			SellPrice = 23;
			AvailableClasses = 0x7FFF;
			Model = 6954;
			ObjectClass = 4;
			SubClass = 3;
			Level = 8;
			Name = "Cold Steel Gauntlets";
			Name2 = "Cold Steel Gauntlets";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 117;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Dagmire Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class DagmireGauntlets : Item
	{
		public DagmireGauntlets() : base()
		{
			Id = 6481;
			Resistance[0] = 110;
			Bonding = 1;
			SellPrice = 641;
			AvailableClasses = 0x7FFF;
			Model = 12068;
			ObjectClass = 4;
			SubClass = 3;
			Level = 23;
			Name = "Dagmire Gauntlets";
			Name2 = "Dagmire Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3209;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 30;
			StrBonus = 5;
			AgilityBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Infantry Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class InfantryGauntlets : Item
	{
		public InfantryGauntlets() : base()
		{
			Id = 6510;
			Resistance[0] = 68;
			SellPrice = 54;
			AvailableClasses = 0x7FFF;
			Model = 22682;
			ObjectClass = 4;
			SubClass = 3;
			Level = 11;
			ReqLevel = 6;
			Name = "Infantry Gauntlets";
			Name2 = "Infantry Gauntlets";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 272;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Soldier's Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class SoldiersGauntlets : Item
	{
		public SoldiersGauntlets() : base()
		{
			Id = 6547;
			Resistance[0] = 99;
			Bonding = 2;
			SellPrice = 267;
			AvailableClasses = 0x7FFF;
			Model = 25756;
			ObjectClass = 4;
			SubClass = 3;
			Level = 17;
			ReqLevel = 12;
			Name = "Soldier's Gauntlets";
			Name2 = "Soldier's Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 750;
			BuyPrice = 1339;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Defender Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class DefenderGauntlets : Item
	{
		public DefenderGauntlets() : base()
		{
			Id = 6577;
			Resistance[0] = 110;
			Bonding = 2;
			SellPrice = 649;
			AvailableClasses = 0x7FFF;
			Model = 25761;
			ObjectClass = 4;
			SubClass = 3;
			Level = 23;
			ReqLevel = 18;
			Name = "Defender Gauntlets";
			Name2 = "Defender Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 752;
			BuyPrice = 3245;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Battleforge Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class BattleforgeGauntlets : Item
	{
		public BattleforgeGauntlets() : base()
		{
			Id = 6595;
			Resistance[0] = 120;
			Bonding = 2;
			SellPrice = 1124;
			AvailableClasses = 0x7FFF;
			Model = 25794;
			ObjectClass = 4;
			SubClass = 3;
			Level = 28;
			ReqLevel = 23;
			Name = "Battleforge Gauntlets";
			Name2 = "Battleforge Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 754;
			BuyPrice = 5624;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Algae Fists)
*
***************************************************************/

namespace Server.Items
{
	public class AlgaeFists : Item
	{
		public AlgaeFists() : base()
		{
			Id = 6906;
			Resistance[0] = 132;
			Bonding = 1;
			SellPrice = 1275;
			AvailableClasses = 0x7FFF;
			Model = 13361;
			ObjectClass = 4;
			SubClass = 3;
			Level = 28;
			ReqLevel = 23;
			Name = "Algae Fists";
			Name2 = "Algae Fists";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 6377;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 40;
			StrBonus = 10;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Fire Hardened Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class FireHardenedGauntlets : Item
	{
		public FireHardenedGauntlets() : base()
		{
			Id = 6974;
			Resistance[0] = 126;
			Bonding = 1;
			SellPrice = 1497;
			AvailableClasses = 0x01;
			Model = 22482;
			ObjectClass = 4;
			SubClass = 3;
			Level = 31;
			Name = "Fire Hardened Gauntlets";
			Name2 = "Fire Hardened Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7485;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			StrBonus = 6;
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Brutal Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class BrutalGauntlets : Item
	{
		public BrutalGauntlets() : base()
		{
			Id = 7129;
			Resistance[0] = 126;
			Bonding = 1;
			SellPrice = 1546;
			AvailableClasses = 0x01;
			Model = 13484;
			ObjectClass = 4;
			SubClass = 3;
			Level = 31;
			Name = "Brutal Gauntlets";
			Name2 = "Brutal Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7734;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			StrBonus = 6;
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Phalanx Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class PhalanxGauntlets : Item
	{
		public PhalanxGauntlets() : base()
		{
			Id = 7421;
			Resistance[0] = 129;
			Bonding = 2;
			SellPrice = 1778;
			AvailableClasses = 0x7FFF;
			Model = 26036;
			ObjectClass = 4;
			SubClass = 3;
			Level = 33;
			ReqLevel = 28;
			Name = "Phalanx Gauntlets";
			Name2 = "Phalanx Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 755;
			BuyPrice = 8891;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Knight's Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class KnightsGauntlets : Item
	{
		public KnightsGauntlets() : base()
		{
			Id = 7457;
			Resistance[0] = 137;
			Bonding = 2;
			SellPrice = 2564;
			AvailableClasses = 0x7FFF;
			Model = 25865;
			ObjectClass = 4;
			SubClass = 3;
			Level = 37;
			ReqLevel = 32;
			Name = "Knight's Gauntlets";
			Name2 = "Knight's Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 757;
			BuyPrice = 12823;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Captain's Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class CaptainsGauntlets : Item
	{
		public CaptainsGauntlets() : base()
		{
			Id = 7489;
			Resistance[0] = 146;
			Bonding = 2;
			SellPrice = 3740;
			AvailableClasses = 0x7FFF;
			Model = 25819;
			ObjectClass = 4;
			SubClass = 3;
			Level = 41;
			ReqLevel = 36;
			Name = "Captain's Gauntlets";
			Name2 = "Captain's Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 758;
			BuyPrice = 18703;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Champion's Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class ChampionsGauntlets : Item
	{
		public ChampionsGauntlets() : base()
		{
			Id = 7541;
			Resistance[0] = 158;
			Bonding = 2;
			SellPrice = 5479;
			AvailableClasses = 0x7FFF;
			Model = 26089;
			ObjectClass = 4;
			SubClass = 3;
			Level = 46;
			ReqLevel = 41;
			Name = "Champion's Gauntlets";
			Name2 = "Champion's Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 760;
			BuyPrice = 27396;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Polar Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class PolarGauntlets : Item
	{
		public PolarGauntlets() : base()
		{
			Id = 7606;
			Resistance[0] = 109;
			Bonding = 1;
			SellPrice = 557;
			AvailableClasses = 0x7FFF;
			Model = 15721;
			ObjectClass = 4;
			SubClass = 3;
			Level = 22;
			Name = "Polar Gauntlets";
			Name2 = "Polar Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2788;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 30;
			StrBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Gauntlets of Divinity)
*
***************************************************************/

namespace Server.Items
{
	public class GauntletsOfDivinity : Item
	{
		public GauntletsOfDivinity() : base()
		{
			Id = 7724;
			Resistance[0] = 168;
			Bonding = 1;
			SellPrice = 5436;
			AvailableClasses = 0x7FFF;
			Model = 16223;
			ObjectClass = 4;
			SubClass = 3;
			Level = 44;
			ReqLevel = 39;
			Name = "Gauntlets of Divinity";
			Name2 = "Gauntlets of Divinity";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 27180;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 40;
			SetSpell( 15807 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Barbaric Iron Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class BarbaricIronGloves : Item
	{
		public BarbaricIronGloves() : base()
		{
			Id = 7917;
			Resistance[0] = 137;
			Bonding = 2;
			SellPrice = 2711;
			AvailableClasses = 0x7FFF;
			Model = 16087;
			ObjectClass = 4;
			SubClass = 3;
			Level = 37;
			ReqLevel = 32;
			Name = "Barbaric Iron Gloves";
			Name2 = "Barbaric Iron Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 13557;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			StrBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Myrmidon's Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class MyrmidonsGauntlets : Item
	{
		public MyrmidonsGauntlets() : base()
		{
			Id = 8128;
			Resistance[0] = 168;
			Bonding = 2;
			SellPrice = 6229;
			AvailableClasses = 0x7FFF;
			Model = 26107;
			ObjectClass = 4;
			SubClass = 3;
			Level = 49;
			ReqLevel = 44;
			Name = "Myrmidon's Gauntlets";
			Name2 = "Myrmidon's Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 31148;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			StaminaBonus = 11;
			SpiritBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Turtle Scale Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class TurtleScaleGloves : Item
	{
		public TurtleScaleGloves() : base()
		{
			Id = 8187;
			Resistance[0] = 146;
			Bonding = 2;
			SellPrice = 3477;
			AvailableClasses = 0x7FFF;
			Model = 16488;
			ObjectClass = 4;
			SubClass = 3;
			Level = 41;
			ReqLevel = 36;
			Name = "Turtle Scale Gloves";
			Name2 = "Turtle Scale Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 17387;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			StaminaBonus = 7;
			IqBonus = 6;
			SpiritBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Tough Scorpid Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class ToughScorpidGloves : Item
	{
		public ToughScorpidGloves() : base()
		{
			Id = 8204;
			Resistance[0] = 155;
			Bonding = 2;
			SellPrice = 4676;
			AvailableClasses = 0x7FFF;
			Model = 16515;
			ObjectClass = 4;
			SubClass = 3;
			Level = 45;
			ReqLevel = 40;
			Name = "Tough Scorpid Gloves";
			Name2 = "Tough Scorpid Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 23382;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			AgilityBonus = 10;
			IqBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Ebonhold Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class EbonholdGauntlets : Item
	{
		public EbonholdGauntlets() : base()
		{
			Id = 8267;
			Resistance[0] = 183;
			Bonding = 2;
			SellPrice = 8927;
			AvailableClasses = 0x7FFF;
			Model = 28726;
			ObjectClass = 4;
			SubClass = 3;
			Level = 54;
			ReqLevel = 49;
			Name = "Ebonhold Gauntlets";
			Name2 = "Ebonhold Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 44639;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			IqBonus = 14;
			SpiritBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Hero's Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class HerosGauntlets : Item
	{
		public HerosGauntlets() : base()
		{
			Id = 8305;
			Resistance[0] = 198;
			Bonding = 2;
			SellPrice = 11743;
			AvailableClasses = 0x7FFF;
			Model = 26316;
			ObjectClass = 4;
			SubClass = 3;
			Level = 59;
			ReqLevel = 54;
			Name = "Hero's Gauntlets";
			Name2 = "Hero's Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 58718;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			AgilityBonus = 13;
			SpiritBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Dragonscale Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class DragonscaleGauntlets : Item
	{
		public DragonscaleGauntlets() : base()
		{
			Id = 8347;
			Resistance[0] = 171;
			Bonding = 2;
			SellPrice = 5979;
			AvailableClasses = 0x7FFF;
			Model = 16731;
			ObjectClass = 4;
			SubClass = 3;
			Level = 45;
			ReqLevel = 40;
			Name = "Dragonscale Gauntlets";
			Name2 = "Dragonscale Gauntlets";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 29899;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 40;
			SetSpell( 7597 , 1 , 0 , 0 , 0 , 0 );
			IqBonus = 6;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Golden Scale Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class GoldenScaleGauntlets : Item
	{
		public GoldenScaleGauntlets() : base()
		{
			Id = 9366;
			Resistance[0] = 146;
			Bonding = 2;
			SellPrice = 3689;
			AvailableClasses = 0x7FFF;
			Model = 18256;
			ObjectClass = 4;
			SubClass = 3;
			Level = 41;
			ReqLevel = 36;
			Name = "Golden Scale Gauntlets";
			Name2 = "Golden Scale Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 18446;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			StrBonus = 11;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Reticulated Bone Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class ReticulatedBoneGauntlets : Item
	{
		public ReticulatedBoneGauntlets() : base()
		{
			Id = 9435;
			Resistance[0] = 149;
			Bonding = 2;
			SellPrice = 2916;
			AvailableClasses = 0x7FFF;
			Model = 18339;
			ObjectClass = 4;
			SubClass = 3;
			Level = 36;
			ReqLevel = 31;
			Name = "Reticulated Bone Gauntlets";
			Name2 = "Reticulated Bone Gauntlets";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 14583;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 40;
			StrBonus = 13;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Grubbis Paws)
*
***************************************************************/

namespace Server.Items
{
	public class GrubbisPaws : Item
	{
		public GrubbisPaws() : base()
		{
			Id = 9445;
			Resistance[0] = 144;
			Bonding = 1;
			SellPrice = 2260;
			AvailableClasses = 0x7FFF;
			Model = 18364;
			ObjectClass = 4;
			SubClass = 3;
			Level = 34;
			ReqLevel = 29;
			Name = "Grubbis Paws";
			Name2 = "Grubbis Paws";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 11302;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 40;
			AgilityBonus = 5;
			StrBonus = 6;
			IqBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Cadet Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class CadetGauntlets : Item
	{
		public CadetGauntlets() : base()
		{
			Id = 9762;
			Resistance[0] = 77;
			SellPrice = 92;
			AvailableClasses = 0x7FFF;
			Model = 22686;
			ObjectClass = 4;
			SubClass = 3;
			Level = 13;
			ReqLevel = 8;
			Name = "Cadet Gauntlets";
			Name2 = "Cadet Gauntlets";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 463;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Raider's Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class RaidersGauntlets : Item
	{
		public RaidersGauntlets() : base()
		{
			Id = 9787;
			Resistance[0] = 103;
			Bonding = 2;
			SellPrice = 358;
			AvailableClasses = 0x7FFF;
			Model = 13484;
			ObjectClass = 4;
			SubClass = 3;
			Level = 19;
			ReqLevel = 14;
			Name = "Raider's Gauntlets";
			Name2 = "Raider's Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 751;
			BuyPrice = 1791;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Fortified Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class FortifiedGauntlets : Item
	{
		public FortifiedGauntlets() : base()
		{
			Id = 9813;
			Resistance[0] = 114;
			Bonding = 2;
			SellPrice = 825;
			AvailableClasses = 0x7FFF;
			Model = 25773;
			ObjectClass = 4;
			SubClass = 3;
			Level = 25;
			ReqLevel = 20;
			Name = "Fortified Gauntlets";
			Name2 = "Fortified Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 753;
			BuyPrice = 4129;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Banded Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class BandedGauntlets : Item
	{
		public BandedGauntlets() : base()
		{
			Id = 9839;
			Resistance[0] = 126;
			Bonding = 2;
			SellPrice = 1426;
			AvailableClasses = 0x7FFF;
			Model = 27778;
			ObjectClass = 4;
			SubClass = 3;
			Level = 31;
			ReqLevel = 26;
			Name = "Banded Gauntlets";
			Name2 = "Banded Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 755;
			BuyPrice = 7134;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Renegade Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class RenegadeGauntlets : Item
	{
		public RenegadeGauntlets() : base()
		{
			Id = 9868;
			Resistance[0] = 133;
			Bonding = 2;
			SellPrice = 2160;
			AvailableClasses = 0x7FFF;
			Model = 25788;
			ObjectClass = 4;
			SubClass = 3;
			Level = 35;
			ReqLevel = 30;
			Name = "Renegade Gauntlets";
			Name2 = "Renegade Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 756;
			BuyPrice = 10802;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Jazeraint Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class JazeraintGauntlets : Item
	{
		public JazeraintGauntlets() : base()
		{
			Id = 9900;
			Resistance[0] = 144;
			Bonding = 2;
			SellPrice = 3195;
			AvailableClasses = 0x7FFF;
			Model = 27791;
			ObjectClass = 4;
			SubClass = 3;
			Level = 40;
			ReqLevel = 35;
			Name = "Jazeraint Gauntlets";
			Name2 = "Jazeraint Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 758;
			BuyPrice = 15975;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Brigade Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class BrigadeGauntlets : Item
	{
		public BrigadeGauntlets() : base()
		{
			Id = 9930;
			Resistance[0] = 151;
			Bonding = 2;
			SellPrice = 4287;
			AvailableClasses = 0x7FFF;
			Model = 25933;
			ObjectClass = 4;
			SubClass = 3;
			Level = 43;
			ReqLevel = 38;
			Name = "Brigade Gauntlets";
			Name2 = "Brigade Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 759;
			BuyPrice = 21439;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Warmonger's Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class WarmongersGauntlets : Item
	{
		public WarmongersGauntlets() : base()
		{
			Id = 9960;
			Resistance[0] = 162;
			Bonding = 2;
			SellPrice = 5623;
			AvailableClasses = 0x7FFF;
			Model = 26185;
			ObjectClass = 4;
			SubClass = 3;
			Level = 47;
			ReqLevel = 42;
			Name = "Warmonger's Gauntlets";
			Name2 = "Warmonger's Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 760;
			BuyPrice = 28119;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Lord's Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class LordsGauntlets : Item
	{
		public LordsGauntlets() : base()
		{
			Id = 10080;
			Resistance[0] = 171;
			Bonding = 2;
			SellPrice = 7319;
			AvailableClasses = 0x7FFF;
			Model = 26328;
			ObjectClass = 4;
			SubClass = 3;
			Level = 50;
			ReqLevel = 45;
			Name = "Lord's Gauntlets";
			Name2 = "Lord's Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 761;
			BuyPrice = 36598;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Ornate Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class OrnateGauntlets : Item
	{
		public OrnateGauntlets() : base()
		{
			Id = 10121;
			Resistance[0] = 189;
			Bonding = 2;
			SellPrice = 10515;
			AvailableClasses = 0x7FFF;
			Model = 26293;
			ObjectClass = 4;
			SubClass = 3;
			Level = 56;
			ReqLevel = 51;
			Name = "Ornate Gauntlets";
			Name2 = "Ornate Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 763;
			BuyPrice = 52576;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Mercurial Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class MercurialGauntlets : Item
	{
		public MercurialGauntlets() : base()
		{
			Id = 10161;
			Resistance[0] = 204;
			Bonding = 2;
			SellPrice = 12713;
			AvailableClasses = 0x7FFF;
			Model = 26125;
			ObjectClass = 4;
			SubClass = 3;
			Level = 61;
			ReqLevel = 56;
			Name = "Mercurial Gauntlets";
			Name2 = "Mercurial Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 765;
			BuyPrice = 63568;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Crusader's Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class CrusadersGauntlets : Item
	{
		public CrusadersGauntlets() : base()
		{
			Id = 10196;
			Resistance[0] = 177;
			Bonding = 2;
			SellPrice = 7593;
			AvailableClasses = 0x7FFF;
			Model = 26162;
			ObjectClass = 4;
			SubClass = 3;
			Level = 52;
			ReqLevel = 47;
			Name = "Crusader's Gauntlets";
			Name2 = "Crusader's Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 762;
			BuyPrice = 37967;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Engraved Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class EngravedGauntlets : Item
	{
		public EngravedGauntlets() : base()
		{
			Id = 10232;
			Resistance[0] = 195;
			Bonding = 2;
			SellPrice = 11732;
			AvailableClasses = 0x7FFF;
			Model = 26269;
			ObjectClass = 4;
			SubClass = 3;
			Level = 58;
			ReqLevel = 53;
			Name = "Engraved Gauntlets";
			Name2 = "Engraved Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 764;
			BuyPrice = 58663;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Masterwork Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class MasterworkGauntlets : Item
	{
		public MasterworkGauntlets() : base()
		{
			Id = 10268;
			Resistance[0] = 210;
			Bonding = 2;
			SellPrice = 14758;
			AvailableClasses = 0x7FFF;
			Model = 26244;
			ObjectClass = 4;
			SubClass = 3;
			Level = 63;
			ReqLevel = 58;
			Name = "Masterwork Gauntlets";
			Name2 = "Masterwork Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 765;
			BuyPrice = 73791;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Scarlet Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class ScarletGauntlets : Item
	{
		public ScarletGauntlets() : base()
		{
			Id = 10331;
			Resistance[0] = 139;
			Bonding = 2;
			SellPrice = 2728;
			AvailableClasses = 0x7FFF;
			Model = 15816;
			ObjectClass = 4;
			SubClass = 3;
			Level = 38;
			ReqLevel = 33;
			Name = "Scarlet Gauntlets";
			Name2 = "Scarlet Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 13644;
			Sets = 163;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			StrBonus = 8;
			AgilityBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Stormgale Fists)
*
***************************************************************/

namespace Server.Items
{
	public class StormgaleFists : Item
	{
		public StormgaleFists() : base()
		{
			Id = 10584;
			Resistance[0] = 149;
			Bonding = 2;
			SellPrice = 2905;
			AvailableClasses = 0x7FFF;
			Model = 28685;
			ObjectClass = 4;
			SubClass = 3;
			Level = 36;
			ReqLevel = 31;
			Name = "Stormgale Fists";
			Name2 = "Stormgale Fists";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 14528;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 40;
			StrBonus = 10;
			IqBonus = 7;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Murkwater Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class MurkwaterGauntlets : Item
	{
		public MurkwaterGauntlets() : base()
		{
			Id = 10631;
			Resistance[0] = 174;
			Bonding = 2;
			SellPrice = 6086;
			AvailableClasses = 0x7FFF;
			Model = 28800;
			ObjectClass = 4;
			SubClass = 3;
			Level = 46;
			ReqLevel = 41;
			Name = "Murkwater Gauntlets";
			Name2 = "Murkwater Gauntlets";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 30433;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 40;
			StrBonus = 13;
			SpiritBonus = 4;
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Savage Gladiator Grips)
*
***************************************************************/

namespace Server.Items
{
	public class SavageGladiatorGrips : Item
	{
		public SavageGladiatorGrips() : base()
		{
			Id = 11730;
			Resistance[0] = 211;
			Bonding = 1;
			SellPrice = 12762;
			AvailableClasses = 0x7FFF;
			Model = 28723;
			ObjectClass = 4;
			SubClass = 3;
			Level = 57;
			ReqLevel = 52;
			Name = "Savage Gladiator Grips";
			Name2 = "Savage Gladiator Grips";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 63813;
			Sets = 1;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 40;
			AgilityBonus = 9;
			IqBonus = 14;
			StaminaBonus = 14;
		}
	}
}


/**************************************************************
*
*				(Molten Fists)
*
***************************************************************/

namespace Server.Items
{
	public class MoltenFists : Item
	{
		public MoltenFists() : base()
		{
			Id = 11814;
			Resistance[0] = 215;
			Bonding = 1;
			SellPrice = 13083;
			AvailableClasses = 0x7FFF;
			Model = 21805;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 3;
			Level = 58;
			ReqLevel = 53;
			Name = "Molten Fists";
			Name2 = "Molten Fists";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 65415;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 40;
			SetSpell( 18186 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Maddening Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class MaddeningGauntlets : Item
	{
		public MaddeningGauntlets() : base()
		{
			Id = 11867;
			Resistance[0] = 180;
			Bonding = 1;
			SellPrice = 8769;
			AvailableClasses = 0x7FFF;
			Model = 28332;
			ObjectClass = 4;
			SubClass = 3;
			Level = 53;
			Name = "Maddening Gauntlets";
			Name2 = "Maddening Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 43848;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			StrBonus = 15;
			AgilityBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Grotslab Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class GrotslabGloves : Item
	{
		public GrotslabGloves() : base()
		{
			Id = 11918;
			Resistance[0] = 186;
			Bonding = 1;
			SellPrice = 9537;
			AvailableClasses = 0x7FFF;
			Model = 28186;
			ObjectClass = 4;
			SubClass = 3;
			Level = 55;
			Name = "Grotslab Gloves";
			Name2 = "Grotslab Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 47687;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			AgilityBonus = 12;
			SpiritBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Brazen Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class BrazenGauntlets : Item
	{
		public BrazenGauntlets() : base()
		{
			Id = 12051;
			Resistance[0] = 183;
			Bonding = 1;
			SellPrice = 8996;
			AvailableClasses = 0x7FFF;
			Model = 28090;
			ObjectClass = 4;
			SubClass = 3;
			Level = 54;
			Name = "Brazen Gauntlets";
			Name2 = "Brazen Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 44983;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			StrBonus = 12;
			StaminaBonus = 2;
			AgilityBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Radiant Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class RadiantGloves : Item
	{
		public RadiantGloves() : base()
		{
			Id = 12418;
			Resistance[0] = 192;
			Bonding = 2;
			SellPrice = 10242;
			AvailableClasses = 0x7FFF;
			Model = 25744;
			Resistance[4] = 12;
			ObjectClass = 4;
			SubClass = 3;
			Level = 57;
			ReqLevel = 52;
			Name = "Radiant Gloves";
			Name2 = "Radiant Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 51214;
			Resistance[5] = 12;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Storm Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class StormGauntlets : Item
	{
		public StormGauntlets() : base()
		{
			Id = 12632;
			Resistance[0] = 218;
			Bonding = 2;
			SellPrice = 14099;
			AvailableClasses = 0x7FFF;
			Model = 25835;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 3;
			Level = 59;
			ReqLevel = 54;
			Name = "Storm Gauntlets";
			Name2 = "Storm Gauntlets";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 70498;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 40;
			SetSpell( 16615 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 9361 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Thorbia's Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class ThorbiasGauntlets : Item
	{
		public ThorbiasGauntlets() : base()
		{
			Id = 12994;
			Resistance[0] = 122;
			Bonding = 2;
			SellPrice = 787;
			AvailableClasses = 0x7FFF;
			Model = 27778;
			ObjectClass = 4;
			SubClass = 3;
			Level = 23;
			ReqLevel = 18;
			Name = "Thorbia's Gauntlets";
			Name2 = "Thorbia's Gauntlets";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 3939;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			StrBonus = 8;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Battlecaller Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class BattlecallerGauntlets : Item
	{
		public BattlecallerGauntlets() : base()
		{
			Id = 13126;
			Resistance[0] = 198;
			Bonding = 2;
			SellPrice = 10374;
			AvailableClasses = 0x7FFF;
			Model = 28434;
			ObjectClass = 4;
			SubClass = 3;
			Level = 53;
			ReqLevel = 48;
			Name = "Battlecaller Gauntlets";
			Name2 = "Battlecaller Gauntlets";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 51870;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 40;
			StrBonus = 8;
			StaminaBonus = 9;
			IqBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Gilded Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class GildedGauntlets : Item
	{
		public GildedGauntlets() : base()
		{
			Id = 13244;
			Resistance[0] = 201;
			Bonding = 1;
			SellPrice = 12068;
			AvailableClasses = 0x7FFF;
			Model = 23827;
			ObjectClass = 4;
			SubClass = 3;
			Level = 60;
			ReqLevel = 55;
			Name = "Gilded Gauntlets";
			Name2 = "Gilded Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 60342;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			StaminaBonus = 13;
			SpiritBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Trueaim Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class TrueaimGauntlets : Item
	{
		public TrueaimGauntlets() : base()
		{
			Id = 13255;
			Resistance[0] = 198;
			Bonding = 1;
			SellPrice = 11972;
			AvailableClasses = 0x7FFF;
			Model = 23849;
			ObjectClass = 4;
			SubClass = 3;
			Level = 59;
			ReqLevel = 54;
			Name = "Trueaim Gauntlets";
			Name2 = "Trueaim Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 59861;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			SetSpell( 17818 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Dracorian Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class DracorianGauntlets : Item
	{
		public DracorianGauntlets() : base()
		{
			Id = 13344;
			Resistance[0] = 231;
			Bonding = 1;
			SellPrice = 17210;
			AvailableClasses = 0x7FFF;
			Model = 29001;
			ObjectClass = 4;
			SubClass = 3;
			Level = 63;
			ReqLevel = 58;
			Name = "Dracorian Gauntlets";
			Name2 = "Dracorian Gauntlets";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 86053;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 40;
			IqBonus = 18;
			StaminaBonus = 10;
			SpiritBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Darkspinner Claws)
*
***************************************************************/

namespace Server.Items
{
	public class DarkspinnerClaws : Item
	{
		public DarkspinnerClaws() : base()
		{
			Id = 13532;
			Resistance[0] = 204;
			Bonding = 1;
			SellPrice = 12762;
			AvailableClasses = 0x7FFF;
			Model = 24183;
			ObjectClass = 4;
			SubClass = 3;
			Level = 61;
			ReqLevel = 56;
			Name = "Darkspinner Claws";
			Name2 = "Darkspinner Claws";
			Resistance[3] = 13;
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 63810;
			Resistance[5] = 13;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Voone's Vice Grips)
*
***************************************************************/

namespace Server.Items
{
	public class VoonesViceGrips : Item
	{
		public VoonesViceGrips() : base()
		{
			Id = 13963;
			Resistance[0] = 221;
			Bonding = 1;
			SellPrice = 14533;
			AvailableClasses = 0x7FFF;
			Model = 29016;
			ObjectClass = 4;
			SubClass = 3;
			Level = 60;
			Name = "Voone's Vice Grips";
			Name2 = "Voone's Vice Grips";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 72665;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 40;
			SetSpell( 15465 , 1 , 0 , -1 , 0 , -1 );
			StrBonus = 6;
			AgilityBonus = 6;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Edgemaster's Handguards)
*
***************************************************************/

namespace Server.Items
{
	public class EdgemastersHandguards : Item
	{
		public EdgemastersHandguards() : base()
		{
			Id = 14551;
			Resistance[0] = 201;
			Bonding = 2;
			SellPrice = 10601;
			AvailableClasses = 0x7FFF;
			Model = 28280;
			ObjectClass = 4;
			SubClass = 3;
			Level = 49;
			ReqLevel = 44;
			Name = "Edgemaster's Handguards";
			Name2 = "Edgemaster's Handguards";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 53008;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 50;
			SetSpell( 15874 , 1 , 0 , 0 , 0 , 0 );
			SetSpell( 7578 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 7527 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Bloodmail Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class BloodmailGauntlets : Item
	{
		public BloodmailGauntlets() : base()
		{
			Id = 14615;
			Resistance[0] = 204;
			Bonding = 1;
			SellPrice = 12430;
			AvailableClasses = 0x7FFF;
			Model = 25221;
			ObjectClass = 4;
			SubClass = 3;
			Level = 61;
			ReqLevel = 56;
			Name = "Bloodmail Gauntlets";
			Name2 = "Bloodmail Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 62152;
			Sets = 123;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			IqBonus = 17;
			SpiritBonus = 7;
		}
	}
}


/**************************************************************
*
*				(War Paint Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class WarPaintGloves : Item
	{
		public WarPaintGloves() : base()
		{
			Id = 14726;
			Resistance[0] = 101;
			Bonding = 2;
			SellPrice = 337;
			AvailableClasses = 0x7FFF;
			Model = 26985;
			ObjectClass = 4;
			SubClass = 3;
			Level = 18;
			ReqLevel = 13;
			Name = "War Paint Gloves";
			Name2 = "War Paint Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1685;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 25;
			StrBonus = 3;
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Hulking Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class HulkingGauntlets : Item
	{
		public HulkingGauntlets() : base()
		{
			Id = 14747;
			Resistance[0] = 110;
			Bonding = 2;
			SellPrice = 668;
			AvailableClasses = 0x7FFF;
			Model = 27012;
			ObjectClass = 4;
			SubClass = 3;
			Level = 23;
			ReqLevel = 18;
			Name = "Hulking Gauntlets";
			Name2 = "Hulking Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3343;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 30;
			StrBonus = 5;
			AgilityBonus = 2;
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Slayer's Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class SlayersGloves : Item
	{
		public SlayersGloves() : base()
		{
			Id = 14754;
			Resistance[0] = 122;
			Bonding = 2;
			SellPrice = 1193;
			AvailableClasses = 0x7FFF;
			Model = 27027;
			ObjectClass = 4;
			SubClass = 3;
			Level = 29;
			ReqLevel = 24;
			Name = "Slayer's Gloves";
			Name2 = "Slayer's Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5965;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			StaminaBonus = 6;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Enduring Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class EnduringGauntlets : Item
	{
		public EnduringGauntlets() : base()
		{
			Id = 14764;
			Resistance[0] = 133;
			Bonding = 2;
			SellPrice = 2250;
			AvailableClasses = 0x7FFF;
			Model = 27053;
			ObjectClass = 4;
			SubClass = 3;
			Level = 35;
			ReqLevel = 30;
			Name = "Enduring Gauntlets";
			Name2 = "Enduring Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11254;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			StrBonus = 7;
			StaminaBonus = 5;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Ravager's Handwraps)
*
***************************************************************/

namespace Server.Items
{
	public class RavagersHandwraps : Item
	{
		public RavagersHandwraps() : base()
		{
			Id = 14772;
			Resistance[0] = 144;
			Bonding = 2;
			SellPrice = 3284;
			AvailableClasses = 0x7FFF;
			Model = 29007;
			ObjectClass = 4;
			SubClass = 3;
			Level = 40;
			ReqLevel = 35;
			Name = "Ravager's Handwraps";
			Name2 = "Ravager's Handwraps";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 16423;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			StrBonus = 9;
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Khan's Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class KhansGloves : Item
	{
		public KhansGloves() : base()
		{
			Id = 14782;
			Resistance[0] = 155;
			Bonding = 2;
			SellPrice = 5004;
			AvailableClasses = 0x7FFF;
			Model = 27148;
			ObjectClass = 4;
			SubClass = 3;
			Level = 45;
			ReqLevel = 40;
			Name = "Khan's Gloves";
			Name2 = "Khan's Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 25023;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			StaminaBonus = 10;
			IqBonus = 7;
			SpiritBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Protector Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class ProtectorGauntlets : Item
	{
		public ProtectorGauntlets() : base()
		{
			Id = 14792;
			Resistance[0] = 171;
			Bonding = 2;
			SellPrice = 6960;
			AvailableClasses = 0x7FFF;
			Model = 27156;
			ObjectClass = 4;
			SubClass = 3;
			Level = 50;
			ReqLevel = 45;
			Name = "Protector Gauntlets";
			Name2 = "Protector Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 34800;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			IqBonus = 15;
			AgilityBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Bloodlust Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class BloodlustGauntlets : Item
	{
		public BloodlustGauntlets() : base()
		{
			Id = 14802;
			Resistance[0] = 186;
			Bonding = 2;
			SellPrice = 9749;
			AvailableClasses = 0x7FFF;
			Model = 27196;
			ObjectClass = 4;
			SubClass = 3;
			Level = 55;
			ReqLevel = 50;
			Name = "Bloodlust Gauntlets";
			Name2 = "Bloodlust Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 48747;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			StaminaBonus = 12;
			AgilityBonus = 7;
			StrBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Warstrike Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class WarstrikeGauntlets : Item
	{
		public WarstrikeGauntlets() : base()
		{
			Id = 14815;
			Resistance[0] = 207;
			Bonding = 2;
			SellPrice = 13760;
			AvailableClasses = 0x7FFF;
			Model = 27536;
			ObjectClass = 4;
			SubClass = 3;
			Level = 62;
			ReqLevel = 57;
			Name = "Warstrike Gauntlets";
			Name2 = "Warstrike Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 68803;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			IqBonus = 10;
			SpiritBonus = 10;
			StaminaBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Heavy Scorpid Gauntlet)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyScorpidGauntlet : Item
	{
		public HeavyScorpidGauntlet() : base()
		{
			Id = 15078;
			Resistance[0] = 186;
			Bonding = 2;
			SellPrice = 9649;
			AvailableClasses = 0x7FFF;
			Model = 25718;
			ObjectClass = 4;
			SubClass = 3;
			Level = 55;
			ReqLevel = 50;
			Name = "Heavy Scorpid Gauntlet";
			Name2 = "Heavy Scorpid Gauntlet";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 48245;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			StaminaBonus = 12;
			IqBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Noosegrip Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class NoosegripGauntlets : Item
	{
		public NoosegripGauntlets() : base()
		{
			Id = 15402;
			Resistance[0] = 81;
			Bonding = 1;
			SellPrice = 109;
			AvailableClasses = 0x7FFF;
			Model = 28223;
			ObjectClass = 4;
			SubClass = 3;
			Level = 14;
			Name = "Noosegrip Gauntlets";
			Name2 = "Noosegrip Gauntlets";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 549;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Palestrider Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class PalestriderGloves : Item
	{
		public PalestriderGloves() : base()
		{
			Id = 15463;
			Resistance[0] = 114;
			Bonding = 1;
			SellPrice = 787;
			AvailableClasses = 0x7FFF;
			Model = 28288;
			ObjectClass = 4;
			SubClass = 3;
			Level = 25;
			Name = "Palestrider Gloves";
			Name2 = "Palestrider Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3937;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 30;
			StrBonus = 5;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Charger's Handwraps)
*
***************************************************************/

namespace Server.Items
{
	public class ChargersHandwraps : Item
	{
		public ChargersHandwraps() : base()
		{
			Id = 15476;
			Resistance[0] = 64;
			SellPrice = 44;
			AvailableClasses = 0x7FFF;
			Model = 28998;
			ObjectClass = 4;
			SubClass = 3;
			Level = 10;
			ReqLevel = 5;
			Name = "Charger's Handwraps";
			Name2 = "Charger's Handwraps";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 220;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(War Torn Handgrips)
*
***************************************************************/

namespace Server.Items
{
	public class WarTornHandgrips : Item
	{
		public WarTornHandgrips() : base()
		{
			Id = 15484;
			Resistance[0] = 73;
			SellPrice = 68;
			AvailableClasses = 0x7FFF;
			Model = 26954;
			ObjectClass = 4;
			SubClass = 3;
			Level = 12;
			ReqLevel = 7;
			Name = "War Torn Handgrips";
			Name2 = "War Torn Handgrips";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 342;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Bloodspattered Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class BloodspatteredGloves : Item
	{
		public BloodspatteredGloves() : base()
		{
			Id = 15491;
			Resistance[0] = 90;
			Bonding = 2;
			SellPrice = 211;
			AvailableClasses = 0x7FFF;
			Model = 27000;
			ObjectClass = 4;
			SubClass = 3;
			Level = 15;
			ReqLevel = 10;
			Name = "Bloodspattered Gloves";
			Name2 = "Bloodspattered Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 749;
			BuyPrice = 1057;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Outrunner's Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class OutrunnersGloves : Item
	{
		public OutrunnersGloves() : base()
		{
			Id = 15502;
			Resistance[0] = 105;
			Bonding = 2;
			SellPrice = 411;
			AvailableClasses = 0x7FFF;
			Model = 26994;
			ObjectClass = 4;
			SubClass = 3;
			Level = 20;
			ReqLevel = 15;
			Name = "Outrunner's Gloves";
			Name2 = "Outrunner's Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 751;
			BuyPrice = 2055;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Grunt's Handwraps)
*
***************************************************************/

namespace Server.Items
{
	public class GruntsHandwraps : Item
	{
		public GruntsHandwraps() : base()
		{
			Id = 15509;
			Resistance[0] = 107;
			Bonding = 2;
			SellPrice = 485;
			AvailableClasses = 0x7FFF;
			Model = 26973;
			ObjectClass = 4;
			SubClass = 3;
			Level = 21;
			ReqLevel = 16;
			Name = "Grunt's Handwraps";
			Name2 = "Grunt's Handwraps";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 751;
			BuyPrice = 2426;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Spiked Chain Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class SpikedChainGauntlets : Item
	{
		public SpikedChainGauntlets() : base()
		{
			Id = 15520;
			Resistance[0] = 116;
			Bonding = 2;
			SellPrice = 879;
			AvailableClasses = 0x7FFF;
			Model = 26963;
			ObjectClass = 4;
			SubClass = 3;
			Level = 26;
			ReqLevel = 21;
			Name = "Spiked Chain Gauntlets";
			Name2 = "Spiked Chain Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 753;
			BuyPrice = 4397;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Sentry's Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class SentrysGloves : Item
	{
		public SentrysGloves() : base()
		{
			Id = 15527;
			Resistance[0] = 118;
			Bonding = 2;
			SellPrice = 1020;
			AvailableClasses = 0x7FFF;
			Model = 27075;
			ObjectClass = 4;
			SubClass = 3;
			Level = 27;
			ReqLevel = 22;
			Name = "Sentry's Gloves";
			Name2 = "Sentry's Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 753;
			BuyPrice = 5101;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Wicked Chain Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class WickedChainGauntlets : Item
	{
		public WickedChainGauntlets() : base()
		{
			Id = 15538;
			Resistance[0] = 124;
			Bonding = 2;
			SellPrice = 1412;
			AvailableClasses = 0x7FFF;
			Model = 27041;
			ObjectClass = 4;
			SubClass = 3;
			Level = 30;
			ReqLevel = 25;
			Name = "Wicked Chain Gauntlets";
			Name2 = "Wicked Chain Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 754;
			BuyPrice = 7063;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Thick Scale Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class ThickScaleGauntlets : Item
	{
		public ThickScaleGauntlets() : base()
		{
			Id = 15548;
			Resistance[0] = 128;
			Bonding = 2;
			SellPrice = 1649;
			AvailableClasses = 0x7FFF;
			Model = 27019;
			ObjectClass = 4;
			SubClass = 3;
			Level = 32;
			ReqLevel = 27;
			Name = "Thick Scale Gauntlets";
			Name2 = "Thick Scale Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 755;
			BuyPrice = 8245;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Pillager's Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class PillagersGloves : Item
	{
		public PillagersGloves() : base()
		{
			Id = 15560;
			Resistance[0] = 131;
			Bonding = 2;
			SellPrice = 1937;
			AvailableClasses = 0x7FFF;
			Model = 27069;
			ObjectClass = 4;
			SubClass = 3;
			Level = 34;
			ReqLevel = 29;
			Name = "Pillager's Gloves";
			Name2 = "Pillager's Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 756;
			BuyPrice = 9686;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Marauder's Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class MaraudersGauntlets : Item
	{
		public MaraudersGauntlets() : base()
		{
			Id = 15570;
			Resistance[0] = 135;
			Bonding = 2;
			SellPrice = 2431;
			AvailableClasses = 0x7FFF;
			Model = 27060;
			ObjectClass = 4;
			SubClass = 3;
			Level = 36;
			ReqLevel = 31;
			Name = "Marauder's Gauntlets";
			Name2 = "Marauder's Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 756;
			BuyPrice = 12159;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Sparkleshell Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class SparkleshellGauntlets : Item
	{
		public SparkleshellGauntlets() : base()
		{
			Id = 15581;
			Resistance[0] = 139;
			Bonding = 2;
			SellPrice = 2794;
			AvailableClasses = 0x7FFF;
			Model = 27113;
			ObjectClass = 4;
			SubClass = 3;
			Level = 38;
			ReqLevel = 33;
			Name = "Sparkleshell Gauntlets";
			Name2 = "Sparkleshell Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 757;
			BuyPrice = 13973;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Steadfast Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class SteadfastGloves : Item
	{
		public SteadfastGloves() : base()
		{
			Id = 15595;
			Resistance[0] = 142;
			Bonding = 2;
			SellPrice = 2950;
			AvailableClasses = 0x7FFF;
			Model = 27892;
			ObjectClass = 4;
			SubClass = 3;
			Level = 39;
			ReqLevel = 34;
			Name = "Steadfast Gloves";
			Name2 = "Steadfast Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 757;
			BuyPrice = 14752;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Ancient Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class AncientGauntlets : Item
	{
		public AncientGauntlets() : base()
		{
			Id = 15605;
			Resistance[0] = 149;
			Bonding = 2;
			SellPrice = 3858;
			AvailableClasses = 0x7FFF;
			Model = 27119;
			ObjectClass = 4;
			SubClass = 3;
			Level = 42;
			ReqLevel = 37;
			Name = "Ancient Gauntlets";
			Name2 = "Ancient Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 758;
			BuyPrice = 19293;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Bonelink Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class BonelinkGauntlets : Item
	{
		public BonelinkGauntlets() : base()
		{
			Id = 15612;
			Resistance[0] = 153;
			Bonding = 2;
			SellPrice = 4285;
			AvailableClasses = 0x7FFF;
			Model = 27326;
			ObjectClass = 4;
			SubClass = 3;
			Level = 44;
			ReqLevel = 39;
			Name = "Bonelink Gauntlets";
			Name2 = "Bonelink Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 759;
			BuyPrice = 21426;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Gryphon Mail Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class GryphonMailGauntlets : Item
	{
		public GryphonMailGauntlets() : base()
		{
			Id = 15625;
			Resistance[0] = 162;
			Bonding = 2;
			SellPrice = 5818;
			AvailableClasses = 0x7FFF;
			Model = 31382;
			ObjectClass = 4;
			SubClass = 3;
			Level = 47;
			ReqLevel = 42;
			Name = "Gryphon Mail Gauntlets";
			Name2 = "Gryphon Mail Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 760;
			BuyPrice = 29094;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Formidable Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class FormidableGauntlets : Item
	{
		public FormidableGauntlets() : base()
		{
			Id = 15635;
			Resistance[0] = 164;
			Bonding = 2;
			SellPrice = 5896;
			AvailableClasses = 0x7FFF;
			Model = 27825;
			ObjectClass = 4;
			SubClass = 3;
			Level = 48;
			ReqLevel = 43;
			Name = "Formidable Gauntlets";
			Name2 = "Formidable Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 760;
			BuyPrice = 29483;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Ironhide Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class IronhideGauntlets : Item
	{
		public IronhideGauntlets() : base()
		{
			Id = 15644;
			Resistance[0] = 177;
			Bonding = 2;
			SellPrice = 8130;
			AvailableClasses = 0x7FFF;
			Model = 29006;
			ObjectClass = 4;
			SubClass = 3;
			Level = 52;
			ReqLevel = 47;
			Name = "Ironhide Gauntlets";
			Name2 = "Ironhide Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 762;
			BuyPrice = 40651;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Merciless Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class MercilessGauntlets : Item
	{
		public MercilessGauntlets() : base()
		{
			Id = 15653;
			Resistance[0] = 180;
			Bonding = 2;
			SellPrice = 8053;
			AvailableClasses = 0x7FFF;
			Model = 27287;
			ObjectClass = 4;
			SubClass = 3;
			Level = 53;
			ReqLevel = 48;
			Name = "Merciless Gauntlets";
			Name2 = "Merciless Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 762;
			BuyPrice = 40266;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Impenetrable Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class ImpenetrableGauntlets : Item
	{
		public ImpenetrableGauntlets() : base()
		{
			Id = 15662;
			Resistance[0] = 192;
			Bonding = 2;
			SellPrice = 10801;
			AvailableClasses = 0x7FFF;
			Model = 27299;
			ObjectClass = 4;
			SubClass = 3;
			Level = 57;
			ReqLevel = 52;
			Name = "Impenetrable Gauntlets";
			Name2 = "Impenetrable Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 763;
			BuyPrice = 54007;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Magnificent Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class MagnificentGauntlets : Item
	{
		public MagnificentGauntlets() : base()
		{
			Id = 15672;
			Resistance[0] = 201;
			Bonding = 2;
			SellPrice = 12164;
			AvailableClasses = 0x7FFF;
			Model = 27317;
			ObjectClass = 4;
			SubClass = 3;
			Level = 60;
			ReqLevel = 55;
			Name = "Magnificent Gauntlets";
			Name2 = "Magnificent Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 764;
			BuyPrice = 60821;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Triumphant Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class TriumphantGauntlets : Item
	{
		public TriumphantGauntlets() : base()
		{
			Id = 15682;
			Resistance[0] = 210;
			Bonding = 2;
			SellPrice = 14610;
			AvailableClasses = 0x7FFF;
			Model = 27309;
			ObjectClass = 4;
			SubClass = 3;
			Level = 63;
			ReqLevel = 58;
			Name = "Triumphant Gauntlets";
			Name2 = "Triumphant Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 765;
			BuyPrice = 73050;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Bricksteel Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class BricksteelGauntlets : Item
	{
		public BricksteelGauntlets() : base()
		{
			Id = 15823;
			Resistance[0] = 186;
			Bonding = 1;
			SellPrice = 9191;
			AvailableClasses = 0x7FFF;
			Model = 26512;
			ObjectClass = 4;
			SubClass = 3;
			Level = 55;
			Name = "Bricksteel Gauntlets";
			Name2 = "Bricksteel Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 45958;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			StrBonus = 18;
		}
	}
}


/**************************************************************
*
*				(Knight-Lieutenant's Chain Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class KnightLieutenantsChainGauntlets : Item
	{
		public KnightLieutenantsChainGauntlets() : base()
		{
			Id = 16403;
			Resistance[0] = 231;
			Bonding = 1;
			SellPrice = 8223;
			AvailableClasses = 0x04;
			Model = 31245;
			ObjectClass = 4;
			SubClass = 3;
			Level = 63;
			ReqLevel = 58;
			Name = "Knight-Lieutenant's Chain Gauntlets";
			Name2 = "Knight-Lieutenant's Chain Gauntlets";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 41118;
			Sets = 362;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			Durability = 40;
			Flags = 32768;
			SetSpell( 23157 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 18;
			AgilityBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Marshal's Chain Grips)
*
***************************************************************/

namespace Server.Items
{
	public class MarshalsChainGrips : Item
	{
		public MarshalsChainGrips() : base()
		{
			Id = 16463;
			Resistance[0] = 260;
			Bonding = 1;
			SellPrice = 12420;
			AvailableClasses = 0x04;
			Model = 32098;
			ObjectClass = 4;
			SubClass = 3;
			Level = 65;
			ReqLevel = 60;
			Name = "Marshal's Chain Grips";
			Name2 = "Marshal's Chain Grips";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 62100;
			Sets = 395;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			Durability = 50;
			Flags = 32768;
			SetSpell( 23157 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 18;
			AgilityBonus = 17;
			SpiritBonus = 16;
		}
	}
}


/**************************************************************
*
*				(Blood Guard's Mail Grips)
*
***************************************************************/

namespace Server.Items
{
	public class BloodGuardsMailGrips : Item
	{
		public BloodGuardsMailGrips() : base()
		{
			Id = 16519;
			Resistance[0] = 231;
			Bonding = 1;
			SellPrice = 8318;
			AvailableClasses = 0x40;
			Model = 27279;
			ObjectClass = 4;
			SubClass = 3;
			Level = 63;
			ReqLevel = 58;
			Name = "Blood Guard's Mail Grips";
			Name2 = "Blood Guard's Mail Grips";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 41593;
			Sets = 301;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			Durability = 40;
			Flags = 32768;
			SetSpell( 14254 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 15;
			SpiritBonus = 7;
			StrBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Blood Guard's Chain Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class BloodGuardsChainGauntlets : Item
	{
		public BloodGuardsChainGauntlets() : base()
		{
			Id = 16530;
			Resistance[0] = 231;
			Bonding = 1;
			SellPrice = 8896;
			AvailableClasses = 0x04;
			Model = 31182;
			ObjectClass = 4;
			SubClass = 3;
			Level = 63;
			ReqLevel = 58;
			Name = "Blood Guard's Chain Gauntlets";
			Name2 = "Blood Guard's Chain Gauntlets";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 44482;
			Sets = 361;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			Durability = 40;
			Flags = 32768;
			SetSpell( 23157 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 18;
			AgilityBonus = 11;
		}
	}
}


/**************************************************************
*
*				(General's Chain Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class GeneralsChainGloves : Item
	{
		public GeneralsChainGloves() : base()
		{
			Id = 16571;
			Resistance[0] = 260;
			Bonding = 1;
			SellPrice = 12186;
			AvailableClasses = 0x04;
			Model = 32119;
			ObjectClass = 4;
			SubClass = 3;
			Level = 65;
			ReqLevel = 60;
			Name = "General's Chain Gloves";
			Name2 = "General's Chain Gloves";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 60932;
			Sets = 396;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			Durability = 50;
			Flags = 32768;
			SetSpell( 23157 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 18;
			AgilityBonus = 17;
			SpiritBonus = 16;
		}
	}
}


/**************************************************************
*
*				(General's Mail Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class GeneralsMailGauntlets : Item
	{
		public GeneralsMailGauntlets() : base()
		{
			Id = 16574;
			Resistance[0] = 260;
			Bonding = 1;
			SellPrice = 12326;
			AvailableClasses = 0x40;
			Model = 32100;
			ObjectClass = 4;
			SubClass = 3;
			Level = 65;
			ReqLevel = 60;
			Name = "General's Mail Gauntlets";
			Name2 = "General's Mail Gauntlets";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 61631;
			Sets = 386;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			Durability = 50;
			Flags = 32768;
			SetSpell( 14248 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 17;
			SpiritBonus = 15;
			StrBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Gauntlets of Elements)
*
***************************************************************/

namespace Server.Items
{
	public class GauntletsOfElements : Item
	{
		public GauntletsOfElements() : base()
		{
			Id = 16672;
			Resistance[0] = 218;
			Bonding = 1;
			SellPrice = 14059;
			AvailableClasses = 0x7FFF;
			Model = 31414;
			ObjectClass = 4;
			SubClass = 3;
			Level = 59;
			ReqLevel = 54;
			Name = "Gauntlets of Elements";
			Name2 = "Gauntlets of Elements";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 70299;
			Sets = 187;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 40;
			IqBonus = 16;
			SpiritBonus = 10;
			StrBonus = 9;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Beaststalker's Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class BeaststalkersGloves : Item
	{
		public BeaststalkersGloves() : base()
		{
			Id = 16676;
			Resistance[0] = 218;
			Bonding = 1;
			SellPrice = 14268;
			AvailableClasses = 0x7FFF;
			Model = 31406;
			ObjectClass = 4;
			SubClass = 3;
			Level = 59;
			ReqLevel = 54;
			Name = "Beaststalker's Gloves";
			Name2 = "Beaststalker's Gloves";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 71344;
			Sets = 186;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 40;
			AgilityBonus = 14;
			IqBonus = 10;
			StaminaBonus = 9;
			SpiritBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Earthfury Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class EarthfuryGauntlets : Item
	{
		public EarthfuryGauntlets() : base()
		{
			Id = 16839;
			Resistance[0] = 264;
			Bonding = 1;
			SellPrice = 25781;
			AvailableClasses = 0x40;
			Model = 31834;
			Resistance[2] = 7;
			ObjectClass = 4;
			SubClass = 3;
			Level = 66;
			ReqLevel = 60;
			Name = "Earthfury Gauntlets";
			Name2 = "Earthfury Gauntlets";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 128905;
			Sets = 207;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 50;
			SetSpell( 18384 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 9415 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 13;
			IqBonus = 15;
			StaminaBonus = 14;
		}
	}
}


/**************************************************************
*
*				(Giantstalker's Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class GiantstalkersGloves : Item
	{
		public GiantstalkersGloves() : base()
		{
			Id = 16852;
			Resistance[0] = 264;
			Bonding = 1;
			SellPrice = 27762;
			AvailableClasses = 0x04;
			Model = 32024;
			Resistance[2] = 7;
			ObjectClass = 4;
			SubClass = 3;
			Level = 66;
			ReqLevel = 60;
			Name = "Giantstalker's Gloves";
			Name2 = "Giantstalker's Gloves";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 138810;
			Sets = 206;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 50;
			SetSpell( 15465 , 1 , 0 , -1 , 0 , -1 );
			AgilityBonus = 18;
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Dragonstalker's Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class DragonstalkersGauntlets : Item
	{
		public DragonstalkersGauntlets() : base()
		{
			Id = 16940;
			Resistance[0] = 301;
			Bonding = 1;
			SellPrice = 43275;
			AvailableClasses = 0x04;
			Model = 29811;
			ObjectClass = 4;
			SubClass = 3;
			Level = 76;
			ReqLevel = 60;
			Name = "Dragonstalker's Gauntlets";
			Name2 = "Dragonstalker's Gauntlets";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 216379;
			Sets = 215;
			Resistance[5] = 10;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 50;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			AgilityBonus = 20;
			SpiritBonus = 13;
			IqBonus = 6;
			StaminaBonus = 17;
		}
	}
}


/**************************************************************
*
*				(Gauntlets of Ten Storms)
*
***************************************************************/

namespace Server.Items
{
	public class GauntletsOfTenStorms : Item
	{
		public GauntletsOfTenStorms() : base()
		{
			Id = 16948;
			Resistance[0] = 301;
			Bonding = 1;
			SellPrice = 41356;
			AvailableClasses = 0x7FFF;
			Model = 29789;
			Resistance[2] = 6;
			Resistance[4] = 6;
			ObjectClass = 4;
			SubClass = 3;
			Level = 76;
			ReqLevel = 60;
			Name = "Gauntlets of Ten Storms";
			Name2 = "Gauntlets of Ten Storms";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 206780;
			Sets = 216;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 50;
			SetSpell( 9408 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 9361 , 1 , 0 , -1 , 0 , -1 );
			IqBonus = 23;
			StaminaBonus = 7;
			StrBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Warsong Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class WarsongGauntlets : Item
	{
		public WarsongGauntlets() : base()
		{
			Id = 16978;
			Resistance[0] = 130;
			Bonding = 1;
			SellPrice = 1158;
			AvailableClasses = 0x7FFF;
			Model = 28750;
			ObjectClass = 4;
			SubClass = 3;
			Level = 27;
			Name = "Warsong Gauntlets";
			Name2 = "Warsong Gauntlets";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 5794;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 40;
			StrBonus = 10;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Sandspire Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class SandspireGloves : Item
	{
		public SandspireGloves() : base()
		{
			Id = 16986;
			Resistance[0] = 114;
			Bonding = 1;
			SellPrice = 850;
			AvailableClasses = 0x7FFF;
			Model = 28288;
			ObjectClass = 4;
			SubClass = 3;
			Level = 25;
			Name = "Sandspire Gloves";
			Name2 = "Sandspire Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4254;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 30;
			StrBonus = 5;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Stonerender Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class StonerenderGauntlets : Item
	{
		public StonerenderGauntlets() : base()
		{
			Id = 17007;
			Resistance[0] = 209;
			Bonding = 2;
			SellPrice = 11447;
			AvailableClasses = 0x7FFF;
			Model = 28838;
			ObjectClass = 4;
			SubClass = 3;
			Level = 51;
			ReqLevel = 46;
			Name = "Stonerender Gauntlets";
			Name2 = "Stonerender Gauntlets";
			Resistance[3] = 10;
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 57238;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 50;
			IqBonus = 20;
			StaminaBonus = 10;
			SpiritBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Rockgrip Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class RockgripGauntlets : Item
	{
		public RockgripGauntlets() : base()
		{
			Id = 17736;
			Resistance[0] = 198;
			Bonding = 1;
			SellPrice = 9646;
			AvailableClasses = 0x7FFF;
			Model = 29912;
			ObjectClass = 4;
			SubClass = 3;
			Level = 53;
			ReqLevel = 48;
			Name = "Rockgrip Gauntlets";
			Name2 = "Rockgrip Gauntlets";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 48234;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 40;
			SetSpell( 9335 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 10;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Gauntlets of Accuracy)
*
***************************************************************/

namespace Server.Items
{
	public class GauntletsOfAccuracy : Item
	{
		public GauntletsOfAccuracy() : base()
		{
			Id = 18349;
			Resistance[0] = 204;
			Bonding = 1;
			SellPrice = 12454;
			AvailableClasses = 0x7FFF;
			Model = 30702;
			ObjectClass = 4;
			SubClass = 3;
			Level = 61;
			ReqLevel = 56;
			Name = "Gauntlets of Accuracy";
			Name2 = "Gauntlets of Accuracy";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 62270;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 35;
			SetSpell( 15464 , 1 , 0 , -1 , 0 , -1 );
			AgilityBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Gordok's Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class GordoksGauntlets : Item
	{
		public GordoksGauntlets() : base()
		{
			Id = 18367;
			Resistance[0] = 221;
			Bonding = 1;
			SellPrice = 14762;
			AvailableClasses = 0x7FFF;
			Model = 30720;
			ObjectClass = 4;
			SubClass = 3;
			Level = 60;
			Name = "Gordok's Gauntlets";
			Name2 = "Gordok's Gauntlets";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 73814;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 40;
			SetSpell( 18384 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 10;
			SpiritBonus = 10;
			IqBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Harmonious Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class HarmoniousGauntlets : Item
	{
		public HarmoniousGauntlets() : base()
		{
			Id = 18527;
			Resistance[0] = 231;
			Bonding = 1;
			SellPrice = 17988;
			AvailableClasses = 0x7FFF;
			Model = 30862;
			ObjectClass = 4;
			SubClass = 3;
			Level = 63;
			ReqLevel = 58;
			Name = "Harmonious Gauntlets";
			Name2 = "Harmonious Gauntlets";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 89941;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 5;
			Durability = 40;
			SetSpell( 18035 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 5;
			IqBonus = 5;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Chromatic Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class ChromaticGauntlets : Item
	{
		public ChromaticGauntlets() : base()
		{
			Id = 19157;
			Resistance[0] = 279;
			Bonding = 2;
			SellPrice = 31943;
			AvailableClasses = 0x7FFF;
			Model = 31680;
			Resistance[2] = 5;
			Resistance[4] = 5;
			Resistance[1] = 5;
			ObjectClass = 4;
			SubClass = 3;
			Level = 70;
			ReqLevel = 60;
			Name = "Chromatic Gauntlets";
			Name2 = "Chromatic Gauntlets";
			Resistance[3] = 5;
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 159715;
			Resistance[5] = 5;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 7;
			Durability = 50;
			SetSpell( 15810 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 18384 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


