/**************************************************************
*
*		Made by fulgas (fulgas@gmail.com)
*
*  WowwoW Item Designer ( 2005/8/23 - 10:05:31 )
*
***************************************************************/

using System;
using System.Collections;

/***************************************************************/

/**************************************************************
*
*				(Tunnel Pick)
*
***************************************************************/

namespace Server.Items
{
	public class TunnelPick : Item
	{
		public TunnelPick() : base()
		{
			Id = 756;
			Bonding = 2;
			SellPrice = 4963;
			AvailableClasses = 0x7FFF;
			Model = 6264;
			ObjectClass = 2;
			SubClass = 1;
			Level = 29;
			ReqLevel = 24;
			Name = "Tunnel Pick";
			Name2 = "Tunnel Pick";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 24818;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3100;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 85;
			SetDamage( 49 , 74 , Resistances.Armor );
			StaminaBonus = 7;
			AgilityBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Fiery War Axe)
*
***************************************************************/

namespace Server.Items
{
	public class FieryWarAxe : Item
	{
		public FieryWarAxe() : base()
		{
			Id = 870;
			Bonding = 2;
			SellPrice = 21528;
			AvailableClasses = 0x7FFF;
			Model = 19303;
			ObjectClass = 2;
			SubClass = 1;
			Level = 40;
			ReqLevel = 35;
			Name = "Fiery War Axe";
			Name2 = "Fiery War Axe";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 107640;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2900;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 120;
			SetSpell( 18796 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 93 , 141 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Rockslicer)
*
***************************************************************/

namespace Server.Items
{
	public class Rockslicer : Item
	{
		public Rockslicer() : base()
		{
			Id = 872;
			Bonding = 1;
			SellPrice = 2011;
			AvailableClasses = 0x7FFF;
			Model = 19242;
			ObjectClass = 2;
			SubClass = 1;
			Level = 21;
			ReqLevel = 16;
			Name = "Rockslicer";
			Name2 = "Rockslicer";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 10058;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3300;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 65;
			SetDamage( 36 , 55 , Resistances.Armor );
			StrBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Battle Axe)
*
***************************************************************/

namespace Server.Items
{
	public class BattleAxe : Item
	{
		public BattleAxe() : base()
		{
			Id = 926;
			SellPrice = 1956;
			AvailableClasses = 0x7FFF;
			Model = 22108;
			ObjectClass = 2;
			SubClass = 1;
			Level = 25;
			ReqLevel = 20;
			Name = "Battle Axe";
			Name2 = "Battle Axe";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 9784;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3800;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 75;
			SetDamage( 46 , 70 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Tabar)
*
***************************************************************/

namespace Server.Items
{
	public class Tabar : Item
	{
		public Tabar() : base()
		{
			Id = 1196;
			SellPrice = 442;
			AvailableClasses = 0x7FFF;
			Model = 22114;
			ObjectClass = 2;
			SubClass = 1;
			Level = 14;
			ReqLevel = 9;
			Name = "Tabar";
			Name2 = "Tabar";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2214;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3200;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 50;
			SetDamage( 21 , 32 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Lupine Axe)
*
***************************************************************/

namespace Server.Items
{
	public class LupineAxe : Item
	{
		public LupineAxe() : base()
		{
			Id = 1220;
			Bonding = 2;
			SellPrice = 1807;
			AvailableClasses = 0x7FFF;
			Model = 19232;
			ObjectClass = 2;
			SubClass = 1;
			Level = 20;
			ReqLevel = 15;
			Name = "Lupine Axe";
			Name2 = "Lupine Axe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 9039;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2300;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 65;
			SetDamage( 24 , 36 , Resistances.Armor );
			AgilityBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Brain Hacker)
*
***************************************************************/

namespace Server.Items
{
	public class BrainHacker : Item
	{
		public BrainHacker() : base()
		{
			Id = 1263;
			Bonding = 2;
			SellPrice = 79064;
			AvailableClasses = 0x7FFF;
			Model = 22215;
			ObjectClass = 2;
			SubClass = 1;
			Level = 60;
			ReqLevel = 55;
			Name = "Brain Hacker";
			Name2 = "Brain Hacker";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 395323;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2100;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 120;
			SetSpell( 17148 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 95 , 143 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Night Reaver)
*
***************************************************************/

namespace Server.Items
{
	public class NightReaver : Item
	{
		public NightReaver() : base()
		{
			Id = 1318;
			Bonding = 2;
			SellPrice = 3066;
			AvailableClasses = 0x7FFF;
			Model = 19290;
			ObjectClass = 2;
			SubClass = 1;
			Level = 23;
			ReqLevel = 18;
			Name = "Night Reaver";
			Name2 = "Night Reaver";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 15332;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3300;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 80;
			SetSpell( 13480 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 52 , 78 , Resistances.Armor );
			SetDamage( 1 , 5 , Resistances.Shadow );
		}
	}
}


/**************************************************************
*
*				(Thistlewood Axe)
*
***************************************************************/

namespace Server.Items
{
	public class ThistlewoodAxe : Item
	{
		public ThistlewoodAxe() : base()
		{
			Id = 1386;
			Bonding = 1;
			SellPrice = 32;
			AvailableClasses = 0x7FFF;
			Model = 19247;
			ObjectClass = 2;
			SubClass = 1;
			Level = 5;
			Name = "Thistlewood Axe";
			Name2 = "Thistlewood Axe";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 160;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3500;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 35;
			SetDamage( 7 , 11 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Beaten Battle Axe)
*
***************************************************************/

namespace Server.Items
{
	public class BeatenBattleAxe : Item
	{
		public BeatenBattleAxe() : base()
		{
			Id = 1417;
			SellPrice = 65;
			AvailableClasses = 0x7FFF;
			Model = 8501;
			ObjectClass = 2;
			SubClass = 1;
			Level = 8;
			ReqLevel = 3;
			Name = "Beaten Battle Axe";
			Name2 = "Beaten Battle Axe";
			AvailableRaces = 0x1FF;
			BuyPrice = 326;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3100;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 40;
			SetDamage( 8 , 13 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Blackrock Champion's Axe)
*
***************************************************************/

namespace Server.Items
{
	public class BlackrockChampionsAxe : Item
	{
		public BlackrockChampionsAxe() : base()
		{
			Id = 1455;
			Bonding = 2;
			SellPrice = 2931;
			AvailableClasses = 0x7FFF;
			Model = 22214;
			ObjectClass = 2;
			SubClass = 1;
			Level = 24;
			ReqLevel = 19;
			Name = "Blackrock Champion's Axe";
			Name2 = "Blackrock Champion's Axe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 14657;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3200;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 75;
			SetDamage( 41 , 62 , Resistances.Armor );
			StrBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Slayer's Battle Axe)
*
***************************************************************/

namespace Server.Items
{
	public class SlayersBattleAxe : Item
	{
		public SlayersBattleAxe() : base()
		{
			Id = 1461;
			Bonding = 2;
			SellPrice = 3387;
			AvailableClasses = 0x7FFF;
			Model = 19375;
			ObjectClass = 2;
			SubClass = 1;
			Level = 25;
			ReqLevel = 20;
			Name = "Slayer's Battle Axe";
			Name2 = "Slayer's Battle Axe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 16936;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2900;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 75;
			SetDamage( 39 , 59 , Resistances.Armor );
			StrBonus = 6;
			AgilityBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Crude Battle Axe)
*
***************************************************************/

namespace Server.Items
{
	public class CrudeBattleAxe : Item
	{
		public CrudeBattleAxe() : base()
		{
			Id = 1512;
			SellPrice = 194;
			AvailableClasses = 0x7FFF;
			Model = 19226;
			ObjectClass = 2;
			SubClass = 1;
			Level = 12;
			ReqLevel = 7;
			Name = "Crude Battle Axe";
			Name2 = "Crude Battle Axe";
			AvailableRaces = 0x1FF;
			BuyPrice = 973;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3000;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 50;
			SetDamage( 12 , 18 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Lumbering Ogre Axe)
*
***************************************************************/

namespace Server.Items
{
	public class LumberingOgreAxe : Item
	{
		public LumberingOgreAxe() : base()
		{
			Id = 1521;
			Bonding = 2;
			SellPrice = 19205;
			AvailableClasses = 0x7FFF;
			Model = 19306;
			ObjectClass = 2;
			SubClass = 1;
			Level = 44;
			ReqLevel = 39;
			Name = "Lumbering Ogre Axe";
			Name2 = "Lumbering Ogre Axe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 96027;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3900;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 85;
			SetDamage( 105 , 158 , Resistances.Armor );
			StrBonus = 15;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Grinning Axe)
*
***************************************************************/

namespace Server.Items
{
	public class GrinningAxe : Item
	{
		public GrinningAxe() : base()
		{
			Id = 1639;
			Bonding = 2;
			SellPrice = 28460;
			AvailableClasses = 0x7FFF;
			Model = 5128;
			ObjectClass = 2;
			SubClass = 1;
			Level = 49;
			ReqLevel = 44;
			Name = "Grinning Axe";
			Name2 = "Grinning Axe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5282;
			BuyPrice = 142301;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2800;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 85;
			SetDamage( 85 , 128 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Monstrous War Axe)
*
***************************************************************/

namespace Server.Items
{
	public class MonstrousWarAxe : Item
	{
		public MonstrousWarAxe() : base()
		{
			Id = 1640;
			Bonding = 2;
			SellPrice = 15637;
			AvailableClasses = 0x7FFF;
			Model = 8526;
			ObjectClass = 2;
			SubClass = 1;
			Level = 42;
			ReqLevel = 37;
			Name = "Monstrous War Axe";
			Name2 = "Monstrous War Axe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5255;
			BuyPrice = 78188;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3700;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 85;
			SetDamage( 92 , 139 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Headchopper)
*
***************************************************************/

namespace Server.Items
{
	public class Headchopper : Item
	{
		public Headchopper() : base()
		{
			Id = 1680;
			Bonding = 2;
			SellPrice = 18234;
			AvailableClasses = 0x7FFF;
			Model = 19304;
			ObjectClass = 2;
			SubClass = 1;
			Level = 44;
			ReqLevel = 39;
			Name = "Headchopper";
			Name2 = "Headchopper";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 91170;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2900;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 85;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 78 , 117 , Resistances.Armor );
			StrBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Short-handled Battle Axe)
*
***************************************************************/

namespace Server.Items
{
	public class ShortHandledBattleAxe : Item
	{
		public ShortHandledBattleAxe() : base()
		{
			Id = 1812;
			SellPrice = 452;
			AvailableClasses = 0x7FFF;
			Model = 19245;
			ObjectClass = 2;
			SubClass = 1;
			Level = 17;
			ReqLevel = 12;
			Name = "Short-handled Battle Axe";
			Name2 = "Short-handled Battle Axe";
			AvailableRaces = 0x1FF;
			BuyPrice = 2264;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3100;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 60;
			SetDamage( 16 , 25 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Shiny War Axe)
*
***************************************************************/

namespace Server.Items
{
	public class ShinyWarAxe : Item
	{
		public ShinyWarAxe() : base()
		{
			Id = 1824;
			SellPrice = 1104;
			AvailableClasses = 0x7FFF;
			Model = 19292;
			ObjectClass = 2;
			SubClass = 1;
			Level = 23;
			ReqLevel = 18;
			Name = "Shiny War Axe";
			Name2 = "Shiny War Axe";
			AvailableRaces = 0x1FF;
			BuyPrice = 5523;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2400;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 70;
			SetDamage( 17 , 26 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Stone War Axe)
*
***************************************************************/

namespace Server.Items
{
	public class StoneWarAxe : Item
	{
		public StoneWarAxe() : base()
		{
			Id = 1828;
			SellPrice = 1609;
			AvailableClasses = 0x7FFF;
			Model = 19369;
			ObjectClass = 2;
			SubClass = 1;
			Level = 27;
			ReqLevel = 22;
			Name = "Stone War Axe";
			Name2 = "Stone War Axe";
			AvailableRaces = 0x1FF;
			BuyPrice = 8046;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2600;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 80;
			SetDamage( 22 , 34 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Miner's Revenge)
*
***************************************************************/

namespace Server.Items
{
	public class MinersRevenge : Item
	{
		public MinersRevenge() : base()
		{
			Id = 1893;
			Bonding = 1;
			SellPrice = 1775;
			AvailableClasses = 0x7FFF;
			Model = 19234;
			ObjectClass = 2;
			SubClass = 1;
			Level = 20;
			Name = "Miner's Revenge";
			Name2 = "Miner's Revenge";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 8876;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3500;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 65;
			SetDamage( 36 , 55 , Resistances.Armor );
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Cold Iron Pick)
*
***************************************************************/

namespace Server.Items
{
	public class ColdIronPick : Item
	{
		public ColdIronPick() : base()
		{
			Id = 1959;
			Bonding = 2;
			SellPrice = 1223;
			AvailableClasses = 0x7FFF;
			Model = 14038;
			ObjectClass = 2;
			SubClass = 1;
			Level = 17;
			ReqLevel = 12;
			Name = "Cold Iron Pick";
			Name2 = "Cold Iron Pick";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6117;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3000;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 60;
			SetDamage( 27 , 41 , Resistances.Armor );
			SetDamage( 1 , 5 , Resistances.Frost );
			StaminaBonus = 2;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Black Metal War Axe)
*
***************************************************************/

namespace Server.Items
{
	public class BlackMetalWarAxe : Item
	{
		public BlackMetalWarAxe() : base()
		{
			Id = 2015;
			Bonding = 2;
			SellPrice = 4443;
			AvailableClasses = 0x7FFF;
			Model = 19255;
			ObjectClass = 2;
			SubClass = 1;
			Level = 28;
			ReqLevel = 23;
			Name = "Black Metal War Axe";
			Name2 = "Black Metal War Axe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 22219;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2900;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 80;
			SetDamage( 44 , 66 , Resistances.Armor );
			StrBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Bearded Axe)
*
***************************************************************/

namespace Server.Items
{
	public class BeardedAxe : Item
	{
		public BeardedAxe() : base()
		{
			Id = 2025;
			SellPrice = 1060;
			AvailableClasses = 0x7FFF;
			Model = 22115;
			ObjectClass = 2;
			SubClass = 1;
			Level = 20;
			ReqLevel = 15;
			Name = "Bearded Axe";
			Name2 = "Bearded Axe";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 5304;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3300;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 65;
			SetDamage( 31 , 47 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Shadowhide Battle Axe)
*
***************************************************************/

namespace Server.Items
{
	public class ShadowhideBattleAxe : Item
	{
		public ShadowhideBattleAxe() : base()
		{
			Id = 2175;
			Bonding = 2;
			SellPrice = 2683;
			AvailableClasses = 0x7FFF;
			Model = 8534;
			ObjectClass = 2;
			SubClass = 1;
			Level = 23;
			ReqLevel = 18;
			Name = "Shadowhide Battle Axe";
			Name2 = "Shadowhide Battle Axe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 13416;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3200;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 70;
			SetDamage( 39 , 59 , Resistances.Armor );
			StrBonus = 6;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Brashclaw's Chopper)
*
***************************************************************/

namespace Server.Items
{
	public class BrashclawsChopper : Item
	{
		public BrashclawsChopper() : base()
		{
			Id = 2203;
			Bonding = 2;
			SellPrice = 1492;
			AvailableClasses = 0x7FFF;
			Model = 8506;
			ObjectClass = 2;
			SubClass = 1;
			Level = 19;
			ReqLevel = 14;
			Name = "Brashclaw's Chopper";
			Name2 = "Brashclaw's Chopper";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7463;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3400;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 65;
			SetDamage( 34 , 51 , Resistances.Armor );
			StrBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Heavy Ogre War Axe)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyOgreWarAxe : Item
	{
		public HeavyOgreWarAxe() : base()
		{
			Id = 2227;
			Bonding = 2;
			SellPrice = 4133;
			AvailableClasses = 0x7FFF;
			Model = 22219;
			ObjectClass = 2;
			SubClass = 1;
			Level = 27;
			ReqLevel = 22;
			Name = "Heavy Ogre War Axe";
			Name2 = "Heavy Ogre War Axe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 20667;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3800;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 80;
			SetDamage( 55 , 84 , Resistances.Armor );
			StrBonus = 7;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Kang the Decapitator)
*
***************************************************************/

namespace Server.Items
{
	public class KangTheDecapitator : Item
	{
		public KangTheDecapitator() : base()
		{
			Id = 2291;
			Bonding = 2;
			SellPrice = 44580;
			AvailableClasses = 0x7FFF;
			Model = 19305;
			ObjectClass = 2;
			SubClass = 1;
			Level = 49;
			ReqLevel = 44;
			Name = "Kang the Decapitator";
			Name2 = "Kang the Decapitator";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 222900;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3600;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 120;
			SetSpell( 17153 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 136 , 205 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Burning War Axe)
*
***************************************************************/

namespace Server.Items
{
	public class BurningWarAxe : Item
	{
		public BurningWarAxe() : base()
		{
			Id = 2299;
			Bonding = 2;
			SellPrice = 8756;
			AvailableClasses = 0x7FFF;
			Model = 19389;
			ObjectClass = 2;
			SubClass = 1;
			Level = 33;
			ReqLevel = 28;
			Name = "Burning War Axe";
			Name2 = "Burning War Axe";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 43784;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3300;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 100;
			SetSpell( 18199 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 73 , 110 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Broad Axe)
*
***************************************************************/

namespace Server.Items
{
	public class BroadAxe : Item
	{
		public BroadAxe() : base()
		{
			Id = 2479;
			SellPrice = 21;
			AvailableClasses = 0x7FFF;
			Model = 8512;
			ObjectClass = 2;
			SubClass = 1;
			Level = 4;
			ReqLevel = 1;
			Name = "Broad Axe";
			Name2 = "Broad Axe";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 107;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3100;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 30;
			SetDamage( 5 , 8 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Rough Broad Axe)
*
***************************************************************/

namespace Server.Items
{
	public class RoughBroadAxe : Item
	{
		public RoughBroadAxe() : base()
		{
			Id = 2483;
			SellPrice = 14;
			AvailableClasses = 0x7FFF;
			Model = 19243;
			ObjectClass = 2;
			SubClass = 1;
			Level = 3;
			ReqLevel = 1;
			Name = "Rough Broad Axe";
			Name2 = "Rough Broad Axe";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 73;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2800;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			SetDamage( 3 , 5 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Large Axe)
*
***************************************************************/

namespace Server.Items
{
	public class LargeAxe : Item
	{
		public LargeAxe() : base()
		{
			Id = 2491;
			SellPrice = 96;
			AvailableClasses = 0x7FFF;
			Model = 22112;
			ObjectClass = 2;
			SubClass = 1;
			Level = 8;
			ReqLevel = 3;
			Name = "Large Axe";
			Name2 = "Large Axe";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 484;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2800;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 40;
			SetDamage( 9 , 15 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Double-bladed Axe)
*
***************************************************************/

namespace Server.Items
{
	public class DoubleBladedAxe : Item
	{
		public DoubleBladedAxe() : base()
		{
			Id = 2499;
			SellPrice = 143;
			AvailableClasses = 0x7FFF;
			Model = 8511;
			ObjectClass = 2;
			SubClass = 1;
			Level = 9;
			ReqLevel = 4;
			Name = "Double-bladed Axe";
			Name2 = "Double-bladed Axe";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 716;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3200;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Flags = 16;
			SetDamage( 12 , 19 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Bullova)
*
***************************************************************/

namespace Server.Items
{
	public class Bullova : Item
	{
		public Bullova() : base()
		{
			Id = 2523;
			SellPrice = 5657;
			AvailableClasses = 0x7FFF;
			Model = 22216;
			ObjectClass = 2;
			SubClass = 1;
			Level = 35;
			ReqLevel = 30;
			Name = "Bullova";
			Name2 = "Bullova";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 28285;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3800;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 85;
			SetDamage( 68 , 102 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Great Axe)
*
***************************************************************/

namespace Server.Items
{
	public class GreatAxe : Item
	{
		public GreatAxe() : base()
		{
			Id = 2531;
			SellPrice = 11233;
			AvailableClasses = 0x7FFF;
			Model = 22111;
			ObjectClass = 2;
			SubClass = 1;
			Level = 44;
			ReqLevel = 39;
			Name = "Great Axe";
			Name2 = "Great Axe";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 56169;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3600;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 85;
			SetDamage( 90 , 135 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Mo'grosh Can Opener)
*
***************************************************************/

namespace Server.Items
{
	public class MogroshCanOpener : Item
	{
		public MogroshCanOpener() : base()
		{
			Id = 2823;
			Bonding = 2;
			SellPrice = 1618;
			AvailableClasses = 0x7FFF;
			Model = 19236;
			ObjectClass = 2;
			SubClass = 1;
			Level = 19;
			ReqLevel = 14;
			Name = "Mo'grosh Can Opener";
			Name2 = "Mo'grosh Can Opener";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 8092;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3200;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 65;
			SetDamage( 32 , 48 , Resistances.Armor );
			StrBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Dwarven Tree Chopper)
*
***************************************************************/

namespace Server.Items
{
	public class DwarvenTreeChopper : Item
	{
		public DwarvenTreeChopper() : base()
		{
			Id = 2907;
			Bonding = 1;
			SellPrice = 1755;
			AvailableClasses = 0x7FFF;
			Model = 19227;
			ObjectClass = 2;
			SubClass = 1;
			Level = 20;
			Name = "Dwarven Tree Chopper";
			Name2 = "Dwarven Tree Chopper";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 8778;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3300;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 65;
			SetSpell( 7552 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 34 , 52 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Wood Chopper)
*
***************************************************************/

namespace Server.Items
{
	public class WoodChopper : Item
	{
		public WoodChopper() : base()
		{
			Id = 3189;
			SellPrice = 99;
			AvailableClasses = 0x7FFF;
			Model = 8525;
			ObjectClass = 2;
			SubClass = 1;
			Level = 8;
			ReqLevel = 3;
			Name = "Wood Chopper";
			Name2 = "Wood Chopper";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 497;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3300;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 40;
			SetDamage( 11 , 17 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Arced War Axe)
*
***************************************************************/

namespace Server.Items
{
	public class ArcedWarAxe : Item
	{
		public ArcedWarAxe() : base()
		{
			Id = 3191;
			Bonding = 1;
			SellPrice = 3857;
			AvailableClasses = 0x7FFF;
			Model = 11165;
			ObjectClass = 2;
			SubClass = 1;
			Level = 26;
			ReqLevel = 21;
			Name = "Arced War Axe";
			Name2 = "Arced War Axe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 19289;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3300;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 80;
			SetDamage( 46 , 70 , Resistances.Armor );
			StrBonus = 6;
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Barbaric Battle Axe)
*
***************************************************************/

namespace Server.Items
{
	public class BarbaricBattleAxe : Item
	{
		public BarbaricBattleAxe() : base()
		{
			Id = 3195;
			Bonding = 2;
			SellPrice = 1372;
			AvailableClasses = 0x7FFF;
			Model = 8499;
			ObjectClass = 2;
			SubClass = 1;
			Level = 18;
			ReqLevel = 13;
			Name = "Barbaric Battle Axe";
			Name2 = "Barbaric Battle Axe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5183;
			BuyPrice = 6862;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3600;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 60;
			SetDamage( 34 , 52 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Battle Slayer)
*
***************************************************************/

namespace Server.Items
{
	public class BattleSlayer : Item
	{
		public BattleSlayer() : base()
		{
			Id = 3199;
			Bonding = 2;
			SellPrice = 2262;
			AvailableClasses = 0x7FFF;
			Model = 19372;
			ObjectClass = 2;
			SubClass = 1;
			Level = 22;
			ReqLevel = 17;
			Name = "Battle Slayer";
			Name2 = "Battle Slayer";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5201;
			BuyPrice = 11310;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3300;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 70;
			SetDamage( 38 , 58 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Barbarian War Axe)
*
***************************************************************/

namespace Server.Items
{
	public class BarbarianWarAxe : Item
	{
		public BarbarianWarAxe() : base()
		{
			Id = 3201;
			Bonding = 2;
			SellPrice = 4496;
			AvailableClasses = 0x7FFF;
			Model = 19283;
			ObjectClass = 2;
			SubClass = 1;
			Level = 28;
			ReqLevel = 23;
			Name = "Barbarian War Axe";
			Name2 = "Barbarian War Axe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5219;
			BuyPrice = 22483;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3100;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 80;
			SetDamage( 47 , 71 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Brutal War Axe)
*
***************************************************************/

namespace Server.Items
{
	public class BrutalWarAxe : Item
	{
		public BrutalWarAxe() : base()
		{
			Id = 3210;
			Bonding = 2;
			SellPrice = 5626;
			AvailableClasses = 0x7FFF;
			Model = 19275;
			ObjectClass = 2;
			SubClass = 1;
			Level = 30;
			ReqLevel = 25;
			Name = "Brutal War Axe";
			Name2 = "Brutal War Axe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5219;
			BuyPrice = 28134;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3600;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 85;
			SetDamage( 58 , 88 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Vile Fin Battle Axe)
*
***************************************************************/

namespace Server.Items
{
	public class VileFinBattleAxe : Item
	{
		public VileFinBattleAxe() : base()
		{
			Id = 3325;
			SellPrice = 140;
			AvailableClasses = 0x7FFF;
			Model = 19252;
			ObjectClass = 2;
			SubClass = 1;
			Level = 9;
			ReqLevel = 4;
			Name = "Vile Fin Battle Axe";
			Name2 = "Vile Fin Battle Axe";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 703;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3100;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 40;
			SetDamage( 12 , 19 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Copper Battle Axe)
*
***************************************************************/

namespace Server.Items
{
	public class CopperBattleAxe : Item
	{
		public CopperBattleAxe() : base()
		{
			Id = 3488;
			Bonding = 2;
			SellPrice = 613;
			AvailableClasses = 0x7FFF;
			Model = 8516;
			ObjectClass = 2;
			SubClass = 1;
			Level = 13;
			ReqLevel = 8;
			Name = "Copper Battle Axe";
			Name2 = "Copper Battle Axe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3066;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3200;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 50;
			SetDamage( 23 , 35 , Resistances.Armor );
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Logsplitter)
*
***************************************************************/

namespace Server.Items
{
	public class Logsplitter : Item
	{
		public Logsplitter() : base()
		{
			Id = 3586;
			Bonding = 1;
			SellPrice = 1034;
			AvailableClasses = 0x7FFF;
			Model = 19231;
			ObjectClass = 2;
			SubClass = 1;
			Level = 16;
			Name = "Logsplitter";
			Name2 = "Logsplitter";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5171;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3600;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 55;
			SetDamage( 31 , 47 , Resistances.Armor );
			StrBonus = 3;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Hefty War Axe)
*
***************************************************************/

namespace Server.Items
{
	public class HeftyWarAxe : Item
	{
		public HeftyWarAxe() : base()
		{
			Id = 3779;
			SellPrice = 2835;
			AvailableClasses = 0x7FFF;
			Model = 19287;
			ObjectClass = 2;
			SubClass = 1;
			Level = 32;
			ReqLevel = 27;
			Name = "Hefty War Axe";
			Name2 = "Hefty War Axe";
			AvailableRaces = 0x1FF;
			BuyPrice = 14175;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2800;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 85;
			SetDamage( 29 , 44 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Massive Iron Axe)
*
***************************************************************/

namespace Server.Items
{
	public class MassiveIronAxe : Item
	{
		public MassiveIronAxe() : base()
		{
			Id = 3855;
			Bonding = 2;
			SellPrice = 11248;
			AvailableClasses = 0x7FFF;
			Model = 8528;
			ObjectClass = 2;
			SubClass = 1;
			Level = 37;
			ReqLevel = 32;
			Name = "Massive Iron Axe";
			Name2 = "Massive Iron Axe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 56243;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3500;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 85;
			SetDamage( 71 , 108 , Resistances.Armor );
			StrBonus = 11;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Shadow Crescent Axe)
*
***************************************************************/

namespace Server.Items
{
	public class ShadowCrescentAxe : Item
	{
		public ShadowCrescentAxe() : base()
		{
			Id = 3856;
			Bonding = 2;
			SellPrice = 14221;
			AvailableClasses = 0x7FFF;
			Model = 8533;
			ObjectClass = 2;
			SubClass = 1;
			Level = 40;
			ReqLevel = 35;
			Name = "Shadow Crescent Axe";
			Name2 = "Shadow Crescent Axe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 71106;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2500;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 85;
			SetDamage( 58 , 87 , Resistances.Armor );
			StrBonus = 11;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Splintering Battle Axe)
*
***************************************************************/

namespace Server.Items
{
	public class SplinteringBattleAxe : Item
	{
		public SplinteringBattleAxe() : base()
		{
			Id = 4020;
			SellPrice = 11189;
			AvailableClasses = 0x7FFF;
			Model = 19374;
			ObjectClass = 2;
			SubClass = 1;
			Level = 49;
			ReqLevel = 44;
			Name = "Splintering Battle Axe";
			Name2 = "Splintering Battle Axe";
			AvailableRaces = 0x1FF;
			BuyPrice = 55948;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3300;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 85;
			SetDamage( 60 , 91 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Severing Axe)
*
***************************************************************/

namespace Server.Items
{
	public class SeveringAxe : Item
	{
		public SeveringAxe() : base()
		{
			Id = 4562;
			Bonding = 2;
			SellPrice = 298;
			AvailableClasses = 0x7FFF;
			Model = 8531;
			ObjectClass = 2;
			SubClass = 1;
			Level = 10;
			ReqLevel = 5;
			Name = "Severing Axe";
			Name2 = "Severing Axe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5174;
			BuyPrice = 1491;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3200;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 45;
			SetDamage( 18 , 27 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Taskmaster Axe)
*
***************************************************************/

namespace Server.Items
{
	public class TaskmasterAxe : Item
	{
		public TaskmasterAxe() : base()
		{
			Id = 5194;
			Bonding = 1;
			SellPrice = 3079;
			AvailableClasses = 0x7FFF;
			Model = 19296;
			ObjectClass = 2;
			SubClass = 1;
			Level = 23;
			ReqLevel = 18;
			Name = "Taskmaster Axe";
			Name2 = "Taskmaster Axe";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 15399;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2700;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 80;
			SetDamage( 42 , 64 , Resistances.Armor );
			IqBonus = 8;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Zhovur Axe)
*
***************************************************************/

namespace Server.Items
{
	public class ZhovurAxe : Item
	{
		public ZhovurAxe() : base()
		{
			Id = 5318;
			Bonding = 1;
			SellPrice = 1789;
			AvailableClasses = 0x7FFF;
			Model = 22225;
			ObjectClass = 2;
			SubClass = 1;
			Level = 20;
			Name = "Zhovur Axe";
			Name2 = "Zhovur Axe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 8946;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3100;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 65;
			SetDamage( 32 , 49 , Resistances.Armor );
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Boahn's Fang)
*
***************************************************************/

namespace Server.Items
{
	public class BoahnsFang : Item
	{
		public BoahnsFang() : base()
		{
			Id = 5423;
			Bonding = 2;
			SellPrice = 2084;
			AvailableClasses = 0x7FFF;
			Model = 19221;
			ObjectClass = 2;
			SubClass = 1;
			Level = 20;
			ReqLevel = 15;
			Name = "Boahn's Fang";
			Name2 = "Boahn's Fang";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 10421;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2500;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 75;
			SetDamage( 35 , 53 , Resistances.Armor );
			StrBonus = 9;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Skullchipper)
*
***************************************************************/

namespace Server.Items
{
	public class Skullchipper : Item
	{
		public Skullchipper() : base()
		{
			Id = 5626;
			Bonding = 1;
			SellPrice = 1717;
			AvailableClasses = 0x7FFF;
			Model = 19246;
			ObjectClass = 2;
			SubClass = 1;
			Level = 20;
			Name = "Skullchipper";
			Name2 = "Skullchipper";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 8587;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3500;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 65;
			SetDamage( 36 , 55 , Resistances.Armor );
			StrBonus = 6;
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Scythe Axe)
*
***************************************************************/

namespace Server.Items
{
	public class ScytheAxe : Item
	{
		public ScytheAxe() : base()
		{
			Id = 5749;
			Bonding = 2;
			SellPrice = 2664;
			AvailableClasses = 0x7FFF;
			Model = 19291;
			ObjectClass = 2;
			SubClass = 1;
			Level = 23;
			ReqLevel = 18;
			Name = "Scythe Axe";
			Name2 = "Scythe Axe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 13321;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3600;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 70;
			SetDamage( 43 , 66 , Resistances.Armor );
			StaminaBonus = 3;
			AgilityBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Brave's Axe)
*
***************************************************************/

namespace Server.Items
{
	public class BravesAxe : Item
	{
		public BravesAxe() : base()
		{
			Id = 5777;
			Bonding = 1;
			SellPrice = 30;
			AvailableClasses = 0x7FFF;
			Model = 8899;
			ObjectClass = 2;
			SubClass = 1;
			Level = 5;
			Name = "Brave's Axe";
			Name2 = "Brave's Axe";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 151;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3300;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 35;
			SetDamage( 7 , 11 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Piercing Axe)
*
***************************************************************/

namespace Server.Items
{
	public class PiercingAxe : Item
	{
		public PiercingAxe() : base()
		{
			Id = 6094;
			Bonding = 1;
			SellPrice = 1278;
			AvailableClasses = 0x7FFF;
			Model = 19390;
			ObjectClass = 2;
			SubClass = 1;
			Level = 18;
			Name = "Piercing Axe";
			Name2 = "Piercing Axe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6393;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3300;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 60;
			SetDamage( 31 , 47 , Resistances.Armor );
			AgilityBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Rock Chipper)
*
***************************************************************/

namespace Server.Items
{
	public class RockChipper : Item
	{
		public RockChipper() : base()
		{
			Id = 6206;
			SellPrice = 555;
			AvailableClasses = 0x7FFF;
			Model = 14040;
			ObjectClass = 2;
			SubClass = 1;
			Level = 15;
			ReqLevel = 10;
			Name = "Rock Chipper";
			Name2 = "Rock Chipper";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2777;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3500;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 55;
			SetDamage( 25 , 38 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Corpsemaker)
*
***************************************************************/

namespace Server.Items
{
	public class Corpsemaker : Item
	{
		public Corpsemaker() : base()
		{
			Id = 6687;
			Bonding = 1;
			SellPrice = 9930;
			AvailableClasses = 0x7FFF;
			Model = 22217;
			ObjectClass = 2;
			SubClass = 1;
			Level = 34;
			ReqLevel = 29;
			Name = "Corpsemaker";
			Name2 = "Corpsemaker";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 49652;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3800;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 100;
			SetDamage( 88 , 132 , Resistances.Armor );
			StrBonus = 15;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Bonebiter)
*
***************************************************************/

namespace Server.Items
{
	public class Bonebiter : Item
	{
		public Bonebiter() : base()
		{
			Id = 6830;
			Bonding = 1;
			SellPrice = 23476;
			AvailableClasses = 0x7FFF;
			Model = 18607;
			ObjectClass = 2;
			SubClass = 1;
			Level = 44;
			Name = "Bonebiter";
			Name2 = "Bonebiter";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 117381;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3400;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 100;
			SetDamage( 105 , 159 , Resistances.Armor );
			StrBonus = 20;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Reef Axe)
*
***************************************************************/

namespace Server.Items
{
	public class ReefAxe : Item
	{
		public ReefAxe() : base()
		{
			Id = 6905;
			Bonding = 1;
			SellPrice = 4010;
			AvailableClasses = 0x7FFF;
			Model = 22222;
			ObjectClass = 2;
			SubClass = 1;
			Level = 27;
			ReqLevel = 22;
			Name = "Reef Axe";
			Name2 = "Reef Axe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 20054;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3300;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 80;
			SetDamage( 48 , 73 , Resistances.Armor );
			StaminaBonus = 5;
			IqBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Whirlwind Axe)
*
***************************************************************/

namespace Server.Items
{
	public class WhirlwindAxe : Item
	{
		public WhirlwindAxe() : base()
		{
			Id = 6975;
			Bonding = 1;
			SellPrice = 16766;
			AvailableClasses = 0x01;
			Model = 22734;
			ObjectClass = 2;
			SubClass = 1;
			Level = 40;
			Name = "Whirlwind Axe";
			Name2 = "Whirlwind Axe";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 83831;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3600;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 100;
			SetDamage( 102 , 154 , Resistances.Armor );
			StrBonus = 15;
			StaminaBonus = 14;
		}
	}
}


/**************************************************************
*
*				(Ravager)
*
***************************************************************/

namespace Server.Items
{
	public class Ravager : Item
	{
		public Ravager() : base()
		{
			Id = 7717;
			Bonding = 1;
			SellPrice = 18923;
			AvailableClasses = 0x7FFF;
			Model = 22221;
			ObjectClass = 2;
			SubClass = 1;
			Level = 42;
			ReqLevel = 37;
			Name = "Ravager";
			Name2 = "Ravager";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 94616;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3500;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 100;
			SetSpell( 9632 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 104 , 157 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Bloodspiller)
*
***************************************************************/

namespace Server.Items
{
	public class Bloodspiller : Item
	{
		public Bloodspiller() : base()
		{
			Id = 7753;
			Bonding = 2;
			SellPrice = 7874;
			AvailableClasses = 0x7FFF;
			Model = 19371;
			ObjectClass = 2;
			SubClass = 1;
			Level = 32;
			ReqLevel = 27;
			Name = "Bloodspiller";
			Name2 = "Bloodspiller";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 39371;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2700;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 100;
			SetSpell( 18200 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 57 , 87 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Bronze Battle Axe)
*
***************************************************************/

namespace Server.Items
{
	public class BronzeBattleAxe : Item
	{
		public BronzeBattleAxe() : base()
		{
			Id = 7958;
			SellPrice = 2435;
			AvailableClasses = 0x7FFF;
			Model = 19272;
			ObjectClass = 2;
			SubClass = 1;
			Level = 27;
			ReqLevel = 22;
			Name = "Bronze Battle Axe";
			Name2 = "Bronze Battle Axe";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 12178;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2900;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 80;
			SetDamage( 39 , 59 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Obsidian Cleaver)
*
***************************************************************/

namespace Server.Items
{
	public class ObsidianCleaver : Item
	{
		public ObsidianCleaver() : base()
		{
			Id = 9383;
			Bonding = 2;
			SellPrice = 16895;
			AvailableClasses = 0x7FFF;
			Model = 18328;
			ObjectClass = 2;
			SubClass = 1;
			Level = 40;
			ReqLevel = 35;
			Name = "Obsidian Cleaver";
			Name2 = "Obsidian Cleaver";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 84476;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3300;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 100;
			SetDamage( 94 , 141 , Resistances.Armor );
			StaminaBonus = 19;
			StrBonus = 6;
			AgilityBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Pendulum of Doom)
*
***************************************************************/

namespace Server.Items
{
	public class PendulumOfDoom : Item
	{
		public PendulumOfDoom() : base()
		{
			Id = 9425;
			Bonding = 2;
			SellPrice = 21489;
			AvailableClasses = 0x7FFF;
			Model = 22220;
			ObjectClass = 2;
			SubClass = 1;
			Level = 44;
			ReqLevel = 39;
			Name = "Pendulum of Doom";
			Name2 = "Pendulum of Doom";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 107446;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 4000;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 100;
			SetSpell( 10373 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 124 , 187 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Thermaplugg's Left Arm)
*
***************************************************************/

namespace Server.Items
{
	public class ThermapluggsLeftArm : Item
	{
		public ThermapluggsLeftArm() : base()
		{
			Id = 9459;
			Bonding = 1;
			SellPrice = 13560;
			AvailableClasses = 0x7FFF;
			Model = 19298;
			ObjectClass = 2;
			SubClass = 1;
			Level = 37;
			ReqLevel = 32;
			Name = "Thermaplugg's Left Arm";
			Name2 = "Thermaplugg's Left Arm";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 67801;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2700;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 100;
			SetDamage( 70 , 106 , Resistances.Armor );
			StrBonus = 18;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(The Minotaur)
*
***************************************************************/

namespace Server.Items
{
	public class TheMinotaur : Item
	{
		public TheMinotaur() : base()
		{
			Id = 9481;
			Bonding = 2;
			SellPrice = 34067;
			AvailableClasses = 0x7FFF;
			Model = 19309;
			ObjectClass = 2;
			SubClass = 1;
			Level = 49;
			ReqLevel = 44;
			Name = "The Minotaur";
			Name2 = "The Minotaur";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 170335;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3200;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 100;
			SetDamage( 109 , 164 , Resistances.Armor );
			StaminaBonus = 24;
			IqBonus = 5;
			StrBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Supercharger Battle Axe)
*
***************************************************************/

namespace Server.Items
{
	public class SuperchargerBattleAxe : Item
	{
		public SuperchargerBattleAxe() : base()
		{
			Id = 9486;
			Bonding = 2;
			SellPrice = 5483;
			AvailableClasses = 0x7FFF;
			Model = 19295;
			ObjectClass = 2;
			SubClass = 1;
			Level = 28;
			ReqLevel = 23;
			Name = "Supercharger Battle Axe";
			Name2 = "Supercharger Battle Axe";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 27417;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2800;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 95;
			SetSpell( 13527 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 51 , 78 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Skullsplitter)
*
***************************************************************/

namespace Server.Items
{
	public class Skullsplitter : Item
	{
		public Skullsplitter() : base()
		{
			Id = 9521;
			Bonding = 1;
			SellPrice = 14382;
			AvailableClasses = 0x7FFF;
			Model = 19307;
			ObjectClass = 2;
			SubClass = 1;
			Level = 41;
			Name = "Skullsplitter";
			Name2 = "Skullsplitter";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 71912;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2900;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 85;
			SetDamage( 70 , 105 , Resistances.Armor );
			StrBonus = 15;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Dwarven Charge)
*
***************************************************************/

namespace Server.Items
{
	public class DwarvenCharge : Item
	{
		public DwarvenCharge() : base()
		{
			Id = 9626;
			Bonding = 1;
			SellPrice = 16243;
			AvailableClasses = 0x7FFF;
			Model = 19302;
			ObjectClass = 2;
			SubClass = 1;
			Level = 42;
			Name = "Dwarven Charge";
			Name2 = "Dwarven Charge";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 81219;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2900;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 85;
			SetDamage( 72 , 109 , Resistances.Armor );
			StrBonus = 12;
			StaminaBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Tok'kar's Murloc Chopper)
*
***************************************************************/

namespace Server.Items
{
	public class TokkarsMurlocChopper : Item
	{
		public TokkarsMurlocChopper() : base()
		{
			Id = 9679;
			Bonding = 1;
			SellPrice = 17550;
			AvailableClasses = 0x7FFF;
			Model = 22223;
			ObjectClass = 2;
			SubClass = 1;
			Level = 43;
			Name = "Tok'kar's Murloc Chopper";
			Name2 = "Tok'kar's Murloc Chopper";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 87750;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3200;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 85;
			SetDamage( 83 , 125 , Resistances.Armor );
			StrBonus = 15;
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Will of the Mountain Giant)
*
***************************************************************/

namespace Server.Items
{
	public class WillOfTheMountainGiant : Item
	{
		public WillOfTheMountainGiant() : base()
		{
			Id = 9685;
			Bonding = 1;
			SellPrice = 32277;
			AvailableClasses = 0x7FFF;
			Model = 19311;
			ObjectClass = 2;
			SubClass = 1;
			Level = 51;
			ReqLevel = 46;
			Name = "Will of the Mountain Giant";
			Name2 = "Will of the Mountain Giant";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 161389;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2800;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Flags = 16;
			SetDamage( 84 , 127 , Resistances.Armor );
			StaminaBonus = 7;
			StrBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Manslayer)
*
***************************************************************/

namespace Server.Items
{
	public class Manslayer : Item
	{
		public Manslayer() : base()
		{
			Id = 10570;
			Bonding = 2;
			SellPrice = 15875;
			AvailableClasses = 0x7FFF;
			Model = 28796;
			ObjectClass = 2;
			SubClass = 1;
			Level = 39;
			ReqLevel = 34;
			Name = "Manslayer";
			Name2 = "Manslayer";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 79375;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3200;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 100;
			SetSpell( 15808 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 88 , 133 , Resistances.Armor );
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Will of the Mountain Giant)
*
***************************************************************/

namespace Server.Items
{
	public class WillOfTheMountainGiant10652 : Item
	{
		public WillOfTheMountainGiant10652() : base()
		{
			Id = 10652;
			Bonding = 1;
			SellPrice = 30308;
			AvailableClasses = 0x7FFF;
			Model = 22213;
			ObjectClass = 2;
			SubClass = 1;
			Level = 51;
			Name = "Will of the Mountain Giant";
			Name2 = "Will of the Mountain Giant";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 151543;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2800;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 85;
			SetDamage( 88 , 133 , Resistances.Armor );
			StrBonus = 15;
			StaminaBonus = 14;
		}
	}
}


/**************************************************************
*
*				(Dark Iron Sunderer)
*
***************************************************************/

namespace Server.Items
{
	public class DarkIronSunderer : Item
	{
		public DarkIronSunderer() : base()
		{
			Id = 11607;
			Bonding = 2;
			SellPrice = 51225;
			AvailableClasses = 0x7FFF;
			Model = 22218;
			ObjectClass = 2;
			SubClass = 1;
			Level = 57;
			ReqLevel = 52;
			Name = "Dark Iron Sunderer";
			Name2 = "Dark Iron Sunderer";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 256125;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2600;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 100;
			SetSpell( 15280 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 101 , 153 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Angerforge's Battle Axe)
*
***************************************************************/

namespace Server.Items
{
	public class AngerforgesBattleAxe : Item
	{
		public AngerforgesBattleAxe() : base()
		{
			Id = 11816;
			Bonding = 1;
			SellPrice = 40735;
			AvailableClasses = 0x7FFF;
			Model = 22212;
			ObjectClass = 2;
			SubClass = 1;
			Level = 56;
			ReqLevel = 51;
			Name = "Angerforge's Battle Axe";
			Name2 = "Angerforge's Battle Axe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 203678;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2600;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 85;
			SetDamage( 90 , 136 , Resistances.Armor );
			StrBonus = 22;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Beastslayer)
*
***************************************************************/

namespace Server.Items
{
	public class Beastslayer : Item
	{
		public Beastslayer() : base()
		{
			Id = 11907;
			Bonding = 1;
			SellPrice = 41050;
			AvailableClasses = 0x7FFF;
			Model = 28073;
			ObjectClass = 2;
			SubClass = 1;
			Level = 55;
			Name = "Beastslayer";
			Name2 = "Beastslayer";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 205250;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3300;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 85;
			SetSpell( 18076 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 112 , 169 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Dreadforge Retaliator)
*
***************************************************************/

namespace Server.Items
{
	public class DreadforgeRetaliator : Item
	{
		public DreadforgeRetaliator() : base()
		{
			Id = 11931;
			Bonding = 1;
			SellPrice = 58103;
			AvailableClasses = 0x7FFF;
			Model = 28719;
			ObjectClass = 2;
			SubClass = 1;
			Level = 59;
			ReqLevel = 54;
			Name = "Dreadforge Retaliator";
			Name2 = "Dreadforge Retaliator";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 290516;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3700;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 100;
			SetSpell( 13665 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 9336 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 149 , 225 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Limb Cleaver)
*
***************************************************************/

namespace Server.Items
{
	public class LimbCleaver : Item
	{
		public LimbCleaver() : base()
		{
			Id = 12000;
			Bonding = 1;
			SellPrice = 41053;
			AvailableClasses = 0x7FFF;
			Model = 28207;
			ObjectClass = 2;
			SubClass = 1;
			Level = 55;
			Name = "Limb Cleaver";
			Name2 = "Limb Cleaver";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 205269;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2400;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 85;
			SetDamage( 82 , 123 , Resistances.Armor );
			StrBonus = 21;
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Merciless Axe)
*
***************************************************************/

namespace Server.Items
{
	public class MercilessAxe : Item
	{
		public MercilessAxe() : base()
		{
			Id = 12249;
			Bonding = 2;
			SellPrice = 6039;
			AvailableClasses = 0x7FFF;
			Model = 22249;
			ObjectClass = 2;
			SubClass = 1;
			Level = 31;
			ReqLevel = 26;
			Name = "Merciless Axe";
			Name2 = "Merciless Axe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 30195;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3200;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 85;
			SetDamage( 54 , 81 , Resistances.Armor );
			StrBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Midnight Axe)
*
***************************************************************/

namespace Server.Items
{
	public class MidnightAxe : Item
	{
		public MidnightAxe() : base()
		{
			Id = 12250;
			Bonding = 2;
			SellPrice = 8068;
			AvailableClasses = 0x7FFF;
			Model = 22250;
			ObjectClass = 2;
			SubClass = 1;
			Level = 34;
			ReqLevel = 29;
			Name = "Midnight Axe";
			Name2 = "Midnight Axe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 40341;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2700;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 85;
			SetSpell( 13440 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 49 , 75 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Worn Battleaxe)
*
***************************************************************/

namespace Server.Items
{
	public class WornBattleaxe : Item
	{
		public WornBattleaxe() : base()
		{
			Id = 12282;
			SellPrice = 8;
			AvailableClasses = 0x7FFF;
			Model = 22291;
			ObjectClass = 2;
			SubClass = 1;
			Level = 2;
			ReqLevel = 1;
			Name = "Worn Battleaxe";
			Name2 = "Worn Battleaxe";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 43;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2900;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 25;
			SetDamage( 3 , 5 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Huge Thorium Battleaxe)
*
***************************************************************/

namespace Server.Items
{
	public class HugeThoriumBattleaxe : Item
	{
		public HugeThoriumBattleaxe() : base()
		{
			Id = 12775;
			Bonding = 2;
			SellPrice = 39949;
			AvailableClasses = 0x7FFF;
			Model = 23434;
			ObjectClass = 2;
			SubClass = 1;
			Level = 56;
			ReqLevel = 51;
			Name = "Huge Thorium Battleaxe";
			Name2 = "Huge Thorium Battleaxe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 199746;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3300;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 85;
			SetSpell( 15768 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 114 , 172 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Arcanite Reaper)
*
***************************************************************/

namespace Server.Items
{
	public class ArcaniteReaper : Item
	{
		public ArcaniteReaper() : base()
		{
			Id = 12784;
			Bonding = 2;
			SellPrice = 73036;
			AvailableClasses = 0x7FFF;
			Model = 23904;
			ObjectClass = 2;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Arcanite Reaper";
			Name2 = "Arcanite Reaper";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 365181;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3800;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 100;
			SetSpell( 15816 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 153 , 256 , Resistances.Armor );
			StaminaBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Prospector Axe)
*
***************************************************************/

namespace Server.Items
{
	public class ProspectorAxe : Item
	{
		public ProspectorAxe() : base()
		{
			Id = 12975;
			Bonding = 2;
			SellPrice = 2205;
			AvailableClasses = 0x7FFF;
			Model = 28804;
			ObjectClass = 2;
			SubClass = 1;
			Level = 20;
			ReqLevel = 15;
			Name = "Prospector Axe";
			Name2 = "Prospector Axe";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 11026;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2400;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 75;
			SetDamage( 33 , 51 , Resistances.Armor );
			StaminaBonus = 8;
			StrBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Lord Alexander's Battle Axe)
*
***************************************************************/

namespace Server.Items
{
	public class LordAlexandersBattleAxe : Item
	{
		public LordAlexandersBattleAxe() : base()
		{
			Id = 13003;
			Bonding = 2;
			SellPrice = 49640;
			AvailableClasses = 0x7FFF;
			Model = 28794;
			ObjectClass = 2;
			SubClass = 1;
			Level = 56;
			ReqLevel = 51;
			Name = "Lord Alexander's Battle Axe";
			Name2 = "Lord Alexander's Battle Axe";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 248203;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3200;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 100;
			SetDamage( 123 , 185 , Resistances.Armor );
			StrBonus = 16;
			StaminaBonus = 16;
			AgilityBonus = 17;
		}
	}
}


/**************************************************************
*
*				(Killmaim)
*
***************************************************************/

namespace Server.Items
{
	public class Killmaim : Item
	{
		public Killmaim() : base()
		{
			Id = 13016;
			Bonding = 2;
			SellPrice = 4771;
			AvailableClasses = 0x7FFF;
			Model = 28791;
			ObjectClass = 2;
			SubClass = 1;
			Level = 26;
			ReqLevel = 21;
			Name = "Killmaim";
			Name2 = "Killmaim";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 23855;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3200;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 95;
			SetSpell( 13318 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 55 , 84 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Hellslayer Battle Axe)
*
***************************************************************/

namespace Server.Items
{
	public class HellslayerBattleAxe : Item
	{
		public HellslayerBattleAxe() : base()
		{
			Id = 13017;
			Bonding = 2;
			SellPrice = 17209;
			AvailableClasses = 0x7FFF;
			Model = 25599;
			ObjectClass = 2;
			SubClass = 1;
			Level = 40;
			ReqLevel = 35;
			Name = "Hellslayer Battle Axe";
			Name2 = "Hellslayer Battle Axe";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 86048;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2900;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 100;
			SetSpell( 18198 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 82 , 124 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Executioner's Cleaver)
*
***************************************************************/

namespace Server.Items
{
	public class ExecutionersCleaver : Item
	{
		public ExecutionersCleaver() : base()
		{
			Id = 13018;
			Bonding = 2;
			SellPrice = 31967;
			AvailableClasses = 0x7FFF;
			Model = 23228;
			ObjectClass = 2;
			SubClass = 1;
			Level = 48;
			ReqLevel = 43;
			Name = "Executioner's Cleaver";
			Name2 = "Executioner's Cleaver";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 159835;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3800;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 100;
			SetSpell( 15464 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 127 , 191 , Resistances.Armor );
			StrBonus = 23;
		}
	}
}


/**************************************************************
*
*				(The Nicker)
*
***************************************************************/

namespace Server.Items
{
	public class TheNicker : Item
	{
		public TheNicker() : base()
		{
			Id = 13285;
			Bonding = 1;
			SellPrice = 54924;
			AvailableClasses = 0x7FFF;
			Model = 23908;
			ObjectClass = 2;
			SubClass = 1;
			Level = 58;
			ReqLevel = 53;
			Name = "The Nicker";
			Name2 = "The Nicker";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 274624;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 4000;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 100;
			SetSpell( 17407 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 159 , 239 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Balanced War Axe)
*
***************************************************************/

namespace Server.Items
{
	public class BalancedWarAxe : Item
	{
		public BalancedWarAxe() : base()
		{
			Id = 13819;
			SellPrice = 19880;
			AvailableClasses = 0x7FFF;
			Model = 19374;
			ObjectClass = 2;
			SubClass = 1;
			Level = 59;
			ReqLevel = 54;
			Name = "Balanced War Axe";
			Name2 = "Balanced War Axe";
			AvailableRaces = 0x1FF;
			BuyPrice = 99404;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2500;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 85;
			SetDamage( 55 , 83 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Gravestone War Axe)
*
***************************************************************/

namespace Server.Items
{
	public class GravestoneWarAxe : Item
	{
		public GravestoneWarAxe() : base()
		{
			Id = 13983;
			Bonding = 1;
			SellPrice = 66754;
			AvailableClasses = 0x7FFF;
			Model = 24816;
			ObjectClass = 2;
			SubClass = 1;
			Level = 62;
			ReqLevel = 57;
			Name = "Gravestone War Axe";
			Name2 = "Gravestone War Axe";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 333772;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3400;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 100;
			SetSpell( 18289 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 144 , 217 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Twin-bladed Axe)
*
***************************************************************/

namespace Server.Items
{
	public class TwinBladedAxe : Item
	{
		public TwinBladedAxe() : base()
		{
			Id = 15268;
			Bonding = 2;
			SellPrice = 1024;
			AvailableClasses = 0x7FFF;
			Model = 28460;
			ObjectClass = 2;
			SubClass = 1;
			Level = 16;
			ReqLevel = 11;
			Name = "Twin-bladed Axe";
			Name2 = "Twin-bladed Axe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5183;
			BuyPrice = 5121;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2700;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 55;
			SetDamage( 23 , 35 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Massive Battle Axe)
*
***************************************************************/

namespace Server.Items
{
	public class MassiveBattleAxe : Item
	{
		public MassiveBattleAxe() : base()
		{
			Id = 15269;
			Bonding = 2;
			SellPrice = 3036;
			AvailableClasses = 0x7FFF;
			Model = 28573;
			ObjectClass = 2;
			SubClass = 1;
			Level = 24;
			ReqLevel = 19;
			Name = "Massive Battle Axe";
			Name2 = "Massive Battle Axe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5201;
			BuyPrice = 15183;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3300;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 75;
			SetDamage( 42 , 64 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Gigantic War Axe)
*
***************************************************************/

namespace Server.Items
{
	public class GiganticWarAxe : Item
	{
		public GiganticWarAxe() : base()
		{
			Id = 15270;
			Bonding = 2;
			SellPrice = 22775;
			AvailableClasses = 0x7FFF;
			Model = 28533;
			ObjectClass = 2;
			SubClass = 1;
			Level = 46;
			ReqLevel = 41;
			Name = "Gigantic War Axe";
			Name2 = "Gigantic War Axe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5273;
			BuyPrice = 113877;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3200;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 85;
			SetDamage( 91 , 137 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Colossal Great Axe)
*
***************************************************************/

namespace Server.Items
{
	public class ColossalGreatAxe : Item
	{
		public ColossalGreatAxe() : base()
		{
			Id = 15271;
			Bonding = 2;
			SellPrice = 43701;
			AvailableClasses = 0x7FFF;
			Model = 28334;
			ObjectClass = 2;
			SubClass = 1;
			Level = 56;
			ReqLevel = 51;
			Name = "Colossal Great Axe";
			Name2 = "Colossal Great Axe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5300;
			BuyPrice = 218506;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3800;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 85;
			SetDamage( 132 , 198 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Razor Axe)
*
***************************************************************/

namespace Server.Items
{
	public class RazorAxe : Item
	{
		public RazorAxe() : base()
		{
			Id = 15272;
			Bonding = 2;
			SellPrice = 51740;
			AvailableClasses = 0x7FFF;
			Model = 28541;
			ObjectClass = 2;
			SubClass = 1;
			Level = 59;
			ReqLevel = 54;
			Name = "Razor Axe";
			Name2 = "Razor Axe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5309;
			BuyPrice = 258702;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2500;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 85;
			SetDamage( 91 , 138 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Death Striker)
*
***************************************************************/

namespace Server.Items
{
	public class DeathStriker : Item
	{
		public DeathStriker() : base()
		{
			Id = 15273;
			Bonding = 2;
			SellPrice = 57108;
			AvailableClasses = 0x7FFF;
			Model = 28349;
			ObjectClass = 2;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Death Striker";
			Name2 = "Death Striker";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5318;
			BuyPrice = 285543;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2800;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 85;
			SetDamage( 109 , 165 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Axe of Orgrimmar)
*
***************************************************************/

namespace Server.Items
{
	public class AxeOfOrgrimmar : Item
	{
		public AxeOfOrgrimmar() : base()
		{
			Id = 15424;
			Bonding = 1;
			SellPrice = 1404;
			AvailableClasses = 0x7FFF;
			Model = 3243;
			ObjectClass = 2;
			SubClass = 1;
			Level = 18;
			Name = "Axe of Orgrimmar";
			Name2 = "Axe of Orgrimmar";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7023;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3300;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 60;
			SetDamage( 31 , 47 , Resistances.Armor );
			StaminaBonus = 3;
			StrBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Spinal Reaper)
*
***************************************************************/

namespace Server.Items
{
	public class SpinalReaper : Item
	{
		public SpinalReaper() : base()
		{
			Id = 17104;
			Bonding = 1;
			SellPrice = 179067;
			AvailableClasses = 0x7FFF;
			Model = 29194;
			ObjectClass = 2;
			SubClass = 1;
			Level = 76;
			ReqLevel = 60;
			Name = "Spinal Reaper";
			Name2 = "Spinal Reaper";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 895337;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3400;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 120;
			SetSpell( 21185 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 15806 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 203 , 305 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Gatorbite Axe)
*
***************************************************************/

namespace Server.Items
{
	public class GatorbiteAxe : Item
	{
		public GatorbiteAxe() : base()
		{
			Id = 17730;
			Bonding = 1;
			SellPrice = 42951;
			AvailableClasses = 0x7FFF;
			Model = 29907;
			ObjectClass = 2;
			SubClass = 1;
			Level = 53;
			ReqLevel = 48;
			Name = "Gatorbite Axe";
			Name2 = "Gatorbite Axe";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 214759;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3200;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 100;
			SetSpell( 21949 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 117 , 176 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Waveslicer)
*
***************************************************************/

namespace Server.Items
{
	public class Waveslicer : Item
	{
		public Waveslicer() : base()
		{
			Id = 18324;
			Bonding = 1;
			SellPrice = 55189;
			AvailableClasses = 0x7FFF;
			Model = 13360;
			ObjectClass = 2;
			SubClass = 1;
			Level = 58;
			ReqLevel = 53;
			Name = "Waveslicer";
			Name2 = "Waveslicer";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 275949;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3100;
			Stackable = 1;
			Material = 6;
			Sheath = 1;
			Durability = 100;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 123 , 185 , Resistances.Armor );
			StrBonus = 26;
		}
	}
}


/**************************************************************
*
*				(Treant's Bane)
*
***************************************************************/

namespace Server.Items
{
	public class TreantsBane : Item
	{
		public TreantsBane() : base()
		{
			Id = 18538;
			Bonding = 1;
			SellPrice = 96748;
			AvailableClasses = 0x7FFF;
			Model = 30881;
			ObjectClass = 2;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Treant's Bane";
			Name2 = "Treant's Bane";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 483741;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2700;
			Stackable = 1;
			Material = 6;
			Sheath = 1;
			Durability = 120;
			SetSpell( 7598 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 128 , 193 , Resistances.Armor );
			StrBonus = 25;
			StaminaBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Malicious Axe)
*
***************************************************************/

namespace Server.Items
{
	public class MaliciousAxe : Item
	{
		public MaliciousAxe() : base()
		{
			Id = 18759;
			Bonding = 1;
			SellPrice = 67844;
			AvailableClasses = 0x7FFF;
			Model = 31219;
			ObjectClass = 2;
			SubClass = 1;
			Level = 62;
			ReqLevel = 57;
			Name = "Malicious Axe";
			Name2 = "Malicious Axe";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 339223;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3100;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 100;
			SetSpell( 9334 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 131 , 197 , Resistances.Armor );
			StaminaBonus = 30;
		}
	}
}


/**************************************************************
*
*				(Grand Marshal's Sunderer)
*
***************************************************************/

namespace Server.Items
{
	public class GrandMarshalsSunderer : Item
	{
		public GrandMarshalsSunderer() : base()
		{
			Id = 18830;
			Bonding = 1;
			SellPrice = 57227;
			AvailableClasses = 0x7FFF;
			Model = 31302;
			ObjectClass = 2;
			SubClass = 1;
			Level = 78;
			ReqLevel = 60;
			Name = "Grand Marshal's Sunderer";
			Name2 = "Grand Marshal's Sunderer";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 286137;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3800;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 120;
			Flags = 32768;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 235 , 353 , Resistances.Armor );
			StaminaBonus = 41;
			StrBonus = 26;
		}
	}
}


/**************************************************************
*
*				(High Warlord's Battle Axe)
*
***************************************************************/

namespace Server.Items
{
	public class HighWarlordsBattleAxe : Item
	{
		public HighWarlordsBattleAxe() : base()
		{
			Id = 18831;
			Bonding = 1;
			SellPrice = 57448;
			AvailableClasses = 0x7FFF;
			Model = 31958;
			ObjectClass = 2;
			SubClass = 1;
			Level = 78;
			ReqLevel = 60;
			Name = "High Warlord's Battle Axe";
			Name2 = "High Warlord's Battle Axe";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 287244;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3800;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 120;
			Flags = 32768;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 235 , 353 , Resistances.Armor );
			StaminaBonus = 41;
			StrBonus = 26;
		}
	}
}


/**************************************************************
*
*				(Nightfall)
*
***************************************************************/

namespace Server.Items
{
	public class Nightfall : Item
	{
		public Nightfall() : base()
		{
			Id = 19169;
			Bonding = 2;
			SellPrice = 129112;
			AvailableClasses = 0x7FFF;
			Model = 31735;
			ObjectClass = 2;
			SubClass = 1;
			Level = 70;
			ReqLevel = 60;
			Name = "Nightfall";
			Name2 = "Nightfall";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 645562;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3200;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 120;
			SetSpell( 23605 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 171 , 258 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Drake Talon Cleaver)
*
***************************************************************/

namespace Server.Items
{
	public class DrakeTalonCleaver : Item
	{
		public DrakeTalonCleaver() : base()
		{
			Id = 19353;
			Bonding = 1;
			SellPrice = 180812;
			AvailableClasses = 0x7FFF;
			Model = 31857;
			ObjectClass = 2;
			SubClass = 1;
			Level = 75;
			ReqLevel = 60;
			Name = "Drake Talon Cleaver";
			Name2 = "Drake Talon Cleaver";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 904062;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3400;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 120;
			SetSpell( 21140 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 199 , 300 , Resistances.Armor );
			StrBonus = 22;
			StaminaBonus = 17;
		}
	}
}


/**************************************************************
*
*				(Draconic Avenger)
*
***************************************************************/

namespace Server.Items
{
	public class DraconicAvenger : Item
	{
		public DraconicAvenger() : base()
		{
			Id = 19354;
			Bonding = 1;
			SellPrice = 135086;
			AvailableClasses = 0x7FFF;
			Model = 31858;
			ObjectClass = 2;
			SubClass = 1;
			Level = 71;
			ReqLevel = 60;
			Name = "Draconic Avenger";
			Name2 = "Draconic Avenger";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 675430;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3200;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 120;
			SetSpell( 13667 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 174 , 262 , Resistances.Armor );
			StrBonus = 21;
			StaminaBonus = 18;
		}
	}
}


