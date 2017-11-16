/**************************************************************
*
*		Made by fulgas (fulgas@gmail.com)
*
*  WowwoW Item Designer ( 2005/8/23 - 10:09:43 )
*
***************************************************************/

using System;
using System.Collections;

/***************************************************************/

/**************************************************************
*
*				(Guild Tabard)
*
***************************************************************/

namespace Server.Items
{
	public class GuildTabard : Item
	{
		public GuildTabard() : base()
		{
			Id = 5976;
			SellPrice = 2500;
			AvailableClasses = 0x7FFF;
			Model = 20621;
			ObjectClass = 4;
			SubClass = 0;
			Level = 1;
			Name = "Guild Tabard";
			Name2 = "Guild Tabard";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 10000;
			InventoryType = InventoryTypes.Tabard;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Tabard of the Scarlet Crusade)
*
***************************************************************/

namespace Server.Items
{
	public class TabardOfTheScarletCrusade : Item
	{
		public TabardOfTheScarletCrusade() : base()
		{
			Id = 7725;
			Bonding = 1;
			SellPrice = 7143;
			AvailableClasses = 0x7FFF;
			Model = 15817;
			ObjectClass = 4;
			SubClass = 0;
			Level = 1;
			Name = "Tabard of the Scarlet Crusade";
			Name2 = "Tabard of the Scarlet Crusade";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 28575;
			InventoryType = InventoryTypes.Tabard;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Flags = 16;
		}
	}
}


/**************************************************************
*
*				(Tabard of Stormwind)
*
***************************************************************/

namespace Server.Items
{
	public class TabardOfStormwind : Item
	{
		public TabardOfStormwind() : base()
		{
			Id = 11364;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 21338;
			ObjectClass = 4;
			SubClass = 0;
			Level = 1;
			Name = "Tabard of Stormwind";
			Name2 = "Tabard of Stormwind";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.Tabard;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 16;
		}
	}
}


/**************************************************************
*
*				(Private's Tabard)
*
***************************************************************/

namespace Server.Items
{
	public class PrivatesTabard : Item
	{
		public PrivatesTabard() : base()
		{
			Id = 15196;
			Bonding = 1;
			SellPrice = 2500;
			AvailableClasses = 0x7FFF;
			Model = 31254;
			ObjectClass = 4;
			SubClass = 0;
			Level = 20;
			Name = "Private's Tabard";
			Name2 = "Private's Tabard";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 10000;
			InventoryType = InventoryTypes.Tabard;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Scout's Tabard)
*
***************************************************************/

namespace Server.Items
{
	public class ScoutsTabard : Item
	{
		public ScoutsTabard() : base()
		{
			Id = 15197;
			Bonding = 1;
			SellPrice = 2500;
			AvailableClasses = 0x7FFF;
			Model = 31255;
			ObjectClass = 4;
			SubClass = 0;
			Level = 20;
			Name = "Scout's Tabard";
			Name2 = "Scout's Tabard";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 10000;
			InventoryType = InventoryTypes.Tabard;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Knight's Colors)
*
***************************************************************/

namespace Server.Items
{
	public class KnightsColors : Item
	{
		public KnightsColors() : base()
		{
			Id = 15198;
			Bonding = 1;
			SellPrice = 10000;
			AvailableClasses = 0x7FFF;
			Model = 31253;
			ObjectClass = 4;
			SubClass = 0;
			Level = 40;
			Name = "Knight's Colors";
			Name2 = "Knight's Colors";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 40000;
			InventoryType = InventoryTypes.Tabard;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Stone Guard's Herald)
*
***************************************************************/

namespace Server.Items
{
	public class StoneGuardsHerald : Item
	{
		public StoneGuardsHerald() : base()
		{
			Id = 15199;
			Bonding = 1;
			SellPrice = 10000;
			AvailableClasses = 0x7FFF;
			Model = 31252;
			ObjectClass = 4;
			SubClass = 0;
			Level = 40;
			Name = "Stone Guard's Herald";
			Name2 = "Stone Guard's Herald";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 40000;
			InventoryType = InventoryTypes.Tabard;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Frostwolf Battle Tabard)
*
***************************************************************/

namespace Server.Items
{
	public class FrostwolfBattleTabard : Item
	{
		public FrostwolfBattleTabard() : base()
		{
			Id = 19031;
			Bonding = 1;
			SellPrice = 2500;
			AvailableClasses = 0x7FFF;
			Model = 31527;
			ObjectClass = 4;
			SubClass = 0;
			Level = 20;
			Name = "Frostwolf Battle Tabard";
			Name2 = "Frostwolf Battle Tabard";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 10000;
			InventoryType = InventoryTypes.Tabard;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Stormpike Battle Tabard)
*
***************************************************************/

namespace Server.Items
{
	public class StormpikeBattleTabard : Item
	{
		public StormpikeBattleTabard() : base()
		{
			Id = 19032;
			Bonding = 1;
			SellPrice = 2500;
			AvailableClasses = 0x7FFF;
			Model = 31528;
			ObjectClass = 4;
			SubClass = 0;
			Level = 20;
			Name = "Stormpike Battle Tabard";
			Name2 = "Stormpike Battle Tabard";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 10000;
			InventoryType = InventoryTypes.Tabard;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Contest Winner's Tabard)
*
***************************************************************/

namespace Server.Items
{
	public class ContestWinnersTabard : Item
	{
		public ContestWinnersTabard() : base()
		{
			Id = 19160;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 31676;
			ObjectClass = 4;
			SubClass = 0;
			Level = 1;
			Name = "Contest Winner's Tabard";
			Name2 = "Contest Winner's Tabard";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.Tabard;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Warsong Battle Tabard)
*
***************************************************************/

namespace Server.Items
{
	public class WarsongBattleTabard : Item
	{
		public WarsongBattleTabard() : base()
		{
			Id = 19505;
			Bonding = 1;
			SellPrice = 12500;
			AvailableClasses = 0x7FFF;
			Model = 32031;
			ObjectClass = 4;
			SubClass = 0;
			Level = 20;
			Name = "Warsong Battle Tabard";
			Name2 = "Warsong Battle Tabard";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 50000;
			InventoryType = InventoryTypes.Tabard;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Silverwing Battle Tabard)
*
***************************************************************/

namespace Server.Items
{
	public class SilverwingBattleTabard : Item
	{
		public SilverwingBattleTabard() : base()
		{
			Id = 19506;
			Bonding = 1;
			SellPrice = 12500;
			AvailableClasses = 0x7FFF;
			Model = 32026;
			ObjectClass = 4;
			SubClass = 0;
			Level = 20;
			Name = "Silverwing Battle Tabard";
			Name2 = "Silverwing Battle Tabard";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 50000;
			InventoryType = InventoryTypes.Tabard;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
		}
	}
}


