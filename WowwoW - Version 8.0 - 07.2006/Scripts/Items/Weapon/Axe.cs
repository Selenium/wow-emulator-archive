/**************************************************************
*
*		Made by fulgas (fulgas@gmail.com)
*
*  WowwoW Item Designer ( 2005/8/23 - 10:05:15 )
*
***************************************************************/

using System;
using System.Collections;

/***************************************************************/

/**************************************************************
*
*				(Worn Axe)
*
***************************************************************/

namespace Server.Items
{
	public class WornAxe : Item
	{
		public WornAxe() : base()
		{
			Id = 37;
			SellPrice = 7;
			AvailableClasses = 0x7FFF;
			Model = 14029;
			ObjectClass = 2;
			SubClass = 0;
			Level = 2;
			ReqLevel = 1;
			Name = "Worn Axe";
			Name2 = "Worn Axe";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 38;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2000;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 20;
			SetDamage( 1 , 3 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Lumberjack Axe)
*
***************************************************************/

namespace Server.Items
{
	public class LumberjackAxe : Item
	{
		public LumberjackAxe() : base()
		{
			Id = 768;
			SellPrice = 113;
			AvailableClasses = 0x7FFF;
			Model = 5012;
			ObjectClass = 2;
			SubClass = 0;
			Level = 9;
			ReqLevel = 4;
			Name = "Lumberjack Axe";
			Name2 = "Lumberjack Axe";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 567;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2600;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 35;
			SetDamage( 7 , 13 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Kobold Excavation Pick)
*
***************************************************************/

namespace Server.Items
{
	public class KoboldExcavationPick : Item
	{
		public KoboldExcavationPick() : base()
		{
			Id = 778;
			SellPrice = 55;
			AvailableClasses = 0x7FFF;
			Model = 6259;
			ObjectClass = 2;
			SubClass = 0;
			Level = 7;
			ReqLevel = 2;
			Name = "Kobold Excavation Pick";
			Name2 = "Kobold Excavation Pick";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 278;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2400;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 30;
			SetDamage( 4 , 9 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Forester's Axe)
*
***************************************************************/

namespace Server.Items
{
	public class ForestersAxe : Item
	{
		public ForestersAxe() : base()
		{
			Id = 790;
			Bonding = 2;
			SellPrice = 2020;
			AvailableClasses = 0x7FFF;
			Model = 19401;
			ObjectClass = 2;
			SubClass = 0;
			Level = 23;
			ReqLevel = 18;
			Name = "Forester's Axe";
			Name2 = "Forester's Axe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5196;
			BuyPrice = 10101;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2500;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			SetDamage( 20 , 38 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Axe of the Deep Woods)
*
***************************************************************/

namespace Server.Items
{
	public class AxeOfTheDeepWoods : Item
	{
		public AxeOfTheDeepWoods() : base()
		{
			Id = 811;
			Bonding = 2;
			SellPrice = 54123;
			AvailableClasses = 0x7FFF;
			Model = 19137;
			ObjectClass = 2;
			SubClass = 0;
			Level = 57;
			ReqLevel = 52;
			Name = "Axe of the Deep Woods";
			Name2 = "Axe of the Deep Woods";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 270619;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2700;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 105;
			SetSpell( 18104 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 78 , 146 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Brutish Riverpaw Axe)
*
***************************************************************/

namespace Server.Items
{
	public class BrutishRiverpawAxe : Item
	{
		public BrutishRiverpawAxe() : base()
		{
			Id = 826;
			Bonding = 2;
			SellPrice = 732;
			AvailableClasses = 0x7FFF;
			Model = 19271;
			ObjectClass = 2;
			SubClass = 0;
			Level = 15;
			ReqLevel = 10;
			Name = "Brutish Riverpaw Axe";
			Name2 = "Brutish Riverpaw Axe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3661;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2800;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 50;
			SetDamage( 15 , 29 , Resistances.Armor );
			StrBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Hatchet)
*
***************************************************************/

namespace Server.Items
{
	public class Hatchet : Item
	{
		public Hatchet() : base()
		{
			Id = 853;
			SellPrice = 481;
			AvailableClasses = 0x7FFF;
			Model = 22102;
			ObjectClass = 2;
			SubClass = 0;
			Level = 16;
			ReqLevel = 11;
			Name = "Hatchet";
			Name2 = "Hatchet";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2409;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2500;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 50;
			SetDamage( 12 , 24 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Gloom Reaper)
*
***************************************************************/

namespace Server.Items
{
	public class GloomReaper : Item
	{
		public GloomReaper() : base()
		{
			Id = 863;
			Bonding = 2;
			SellPrice = 8964;
			AvailableClasses = 0x7FFF;
			Model = 19213;
			ObjectClass = 2;
			SubClass = 0;
			Level = 37;
			ReqLevel = 32;
			Name = "Gloom Reaper";
			Name2 = "Gloom Reaper";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5241;
			BuyPrice = 44820;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2700;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 37 , 69 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Flurry Axe)
*
***************************************************************/

namespace Server.Items
{
	public class FlurryAxe : Item
	{
		public FlurryAxe() : base()
		{
			Id = 871;
			Bonding = 2;
			SellPrice = 29627;
			AvailableClasses = 0x7FFF;
			Model = 19235;
			ObjectClass = 2;
			SubClass = 0;
			Level = 47;
			ReqLevel = 42;
			Name = "Flurry Axe";
			Name2 = "Flurry Axe";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 148139;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1500;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 105;
			SetSpell( 18797 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 37 , 69 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Black Metal Axe)
*
***************************************************************/

namespace Server.Items
{
	public class BlackMetalAxe : Item
	{
		public BlackMetalAxe() : base()
		{
			Id = 885;
			Bonding = 2;
			SellPrice = 2300;
			AvailableClasses = 0x7FFF;
			Model = 14036;
			ObjectClass = 2;
			SubClass = 0;
			Level = 24;
			ReqLevel = 19;
			Name = "Black Metal Axe";
			Name2 = "Black Metal Axe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11504;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2100;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			SetDamage( 18 , 34 , Resistances.Armor );
			StaminaBonus = 2;
			StrBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Double Axe)
*
***************************************************************/

namespace Server.Items
{
	public class DoubleAxe : Item
	{
		public DoubleAxe() : base()
		{
			Id = 927;
			SellPrice = 1390;
			AvailableClasses = 0x7FFF;
			Model = 22106;
			ObjectClass = 2;
			SubClass = 0;
			Level = 24;
			ReqLevel = 19;
			Name = "Double Axe";
			Name2 = "Double Axe";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 6953;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2500;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			SetDamage( 19 , 36 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Stalvan's Reaper)
*
***************************************************************/

namespace Server.Items
{
	public class StalvansReaper : Item
	{
		public StalvansReaper() : base()
		{
			Id = 934;
			Bonding = 2;
			SellPrice = 10682;
			AvailableClasses = 0x7FFF;
			Model = 19405;
			ObjectClass = 2;
			SubClass = 0;
			Level = 37;
			ReqLevel = 32;
			Name = "Stalvan's Reaper";
			Name2 = "Stalvan's Reaper";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 53411;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2900;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetSpell( 13524 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 50 , 94 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Sharp Axe)
*
***************************************************************/

namespace Server.Items
{
	public class SharpAxe : Item
	{
		public SharpAxe() : base()
		{
			Id = 1011;
			Bonding = 1;
			SellPrice = 80;
			AvailableClasses = 0x7FFF;
			Model = 19273;
			ObjectClass = 2;
			SubClass = 0;
			Level = 8;
			Name = "Sharp Axe";
			Name2 = "Sharp Axe";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 400;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2600;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 35;
			SetDamage( 6 , 11 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Butcher's Cleaver)
*
***************************************************************/

namespace Server.Items
{
	public class ButchersCleaver : Item
	{
		public ButchersCleaver() : base()
		{
			Id = 1292;
			Bonding = 1;
			SellPrice = 3300;
			AvailableClasses = 0x7FFF;
			Model = 8466;
			ObjectClass = 2;
			SubClass = 0;
			Level = 25;
			ReqLevel = 20;
			Name = "Butcher's Cleaver";
			Name2 = "Butcher's Cleaver";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 16504;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1700;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 23 , 32 , Resistances.Armor );
			StrBonus = 5;
			AgilityBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Stone Tomahawk)
*
***************************************************************/

namespace Server.Items
{
	public class StoneTomahawk : Item
	{
		public StoneTomahawk() : base()
		{
			Id = 1383;
			Bonding = 1;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 8495;
			ObjectClass = 2;
			SubClass = 0;
			Level = 5;
			Name = "Stone Tomahawk";
			Name2 = "Stone Tomahawk";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 126;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2100;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 30;
			SetDamage( 3 , 6 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Rusty Hatchet)
*
***************************************************************/

namespace Server.Items
{
	public class RustyHatchet : Item
	{
		public RustyHatchet() : base()
		{
			Id = 1416;
			SellPrice = 72;
			AvailableClasses = 0x7FFF;
			Model = 8495;
			ObjectClass = 2;
			SubClass = 0;
			Level = 9;
			ReqLevel = 4;
			Name = "Rusty Hatchet";
			Name2 = "Rusty Hatchet";
			AvailableRaces = 0x1FF;
			BuyPrice = 364;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2100;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 35;
			SetDamage( 4 , 8 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Axe of the Enforcer)
*
***************************************************************/

namespace Server.Items
{
	public class AxeOfTheEnforcer : Item
	{
		public AxeOfTheEnforcer() : base()
		{
			Id = 1454;
			Bonding = 2;
			SellPrice = 3937;
			AvailableClasses = 0x7FFF;
			Model = 8457;
			ObjectClass = 2;
			SubClass = 0;
			Level = 27;
			ReqLevel = 22;
			Name = "Axe of the Enforcer";
			Name2 = "Axe of the Enforcer";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 19689;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2600;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 80;
			SetDamage( 31 , 58 , Resistances.Armor );
			StrBonus = 4;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Shadowhide Scalper)
*
***************************************************************/

namespace Server.Items
{
	public class ShadowhideScalper : Item
	{
		public ShadowhideScalper() : base()
		{
			Id = 1459;
			Bonding = 2;
			SellPrice = 2380;
			AvailableClasses = 0x7FFF;
			Model = 19136;
			ObjectClass = 2;
			SubClass = 0;
			Level = 24;
			ReqLevel = 19;
			Name = "Shadowhide Scalper";
			Name2 = "Shadowhide Scalper";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11902;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2900;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			SetDamage( 25 , 47 , Resistances.Armor );
			StrBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Grimclaw)
*
***************************************************************/

namespace Server.Items
{
	public class Grimclaw : Item
	{
		public Grimclaw() : base()
		{
			Id = 1481;
			Bonding = 2;
			SellPrice = 3337;
			AvailableClasses = 0x7FFF;
			Model = 25595;
			ObjectClass = 2;
			SubClass = 0;
			Level = 25;
			ReqLevel = 20;
			Name = "Grimclaw";
			Name2 = "Grimclaw";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 16688;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2000;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetSpell( 13440 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 22 , 42 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Worn Hatchet)
*
***************************************************************/

namespace Server.Items
{
	public class WornHatchet : Item
	{
		public WornHatchet() : base()
		{
			Id = 1516;
			SellPrice = 237;
			AvailableClasses = 0x7FFF;
			Model = 8498;
			ObjectClass = 2;
			SubClass = 0;
			Level = 14;
			ReqLevel = 9;
			Name = "Worn Hatchet";
			Name2 = "Worn Hatchet";
			AvailableRaces = 0x1FF;
			BuyPrice = 1185;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2100;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 45;
			SetDamage( 6 , 12 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Sickle Axe)
*
***************************************************************/

namespace Server.Items
{
	public class SickleAxe : Item
	{
		public SickleAxe() : base()
		{
			Id = 1602;
			Bonding = 2;
			SellPrice = 11685;
			AvailableClasses = 0x7FFF;
			Model = 8489;
			ObjectClass = 2;
			SubClass = 0;
			Level = 39;
			ReqLevel = 34;
			Name = "Sickle Axe";
			Name2 = "Sickle Axe";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 58427;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2600;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetDamage( 48 , 90 , Resistances.Armor );
			AgilityBonus = 5;
			StrBonus = 6;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Unbalanced Axe)
*
***************************************************************/

namespace Server.Items
{
	public class UnbalancedAxe : Item
	{
		public UnbalancedAxe() : base()
		{
			Id = 1816;
			SellPrice = 486;
			AvailableClasses = 0x7FFF;
			Model = 8495;
			ObjectClass = 2;
			SubClass = 0;
			Level = 19;
			ReqLevel = 14;
			Name = "Unbalanced Axe";
			Name2 = "Unbalanced Axe";
			AvailableRaces = 0x1FF;
			BuyPrice = 2432;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2400;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 55;
			SetDamage( 9 , 18 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Gouging Pick)
*
***************************************************************/

namespace Server.Items
{
	public class GougingPick : Item
	{
		public GougingPick() : base()
		{
			Id = 1819;
			SellPrice = 768;
			AvailableClasses = 0x7FFF;
			Model = 14039;
			ObjectClass = 2;
			SubClass = 0;
			Level = 22;
			ReqLevel = 17;
			Name = "Gouging Pick";
			Name2 = "Gouging Pick";
			AvailableRaces = 0x1FF;
			BuyPrice = 3840;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1800;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 60;
			SetDamage( 8 , 16 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Meat Cleaver)
*
***************************************************************/

namespace Server.Items
{
	public class MeatCleaver : Item
	{
		public MeatCleaver() : base()
		{
			Id = 1827;
			SellPrice = 1282;
			AvailableClasses = 0x7FFF;
			Model = 8482;
			ObjectClass = 2;
			SubClass = 0;
			Level = 27;
			ReqLevel = 22;
			Name = "Meat Cleaver";
			Name2 = "Meat Cleaver";
			AvailableRaces = 0x1FF;
			BuyPrice = 6412;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2400;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 70;
			SetDamage( 14 , 26 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Deadmines Cleaver)
*
***************************************************************/

namespace Server.Items
{
	public class DeadminesCleaver : Item
	{
		public DeadminesCleaver() : base()
		{
			Id = 1927;
			Bonding = 2;
			SellPrice = 690;
			AvailableClasses = 0x7FFF;
			Model = 19276;
			ObjectClass = 2;
			SubClass = 0;
			Level = 15;
			ReqLevel = 10;
			Name = "Deadmines Cleaver";
			Name2 = "Deadmines Cleaver";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3451;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2600;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 50;
			SetDamage( 14 , 27 , Resistances.Armor );
			IqBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Ebonclaw Reaver)
*
***************************************************************/

namespace Server.Items
{
	public class EbonclawReaver : Item
	{
		public EbonclawReaver() : base()
		{
			Id = 1994;
			Bonding = 2;
			SellPrice = 16696;
			AvailableClasses = 0x7FFF;
			Model = 19129;
			ObjectClass = 2;
			SubClass = 0;
			Level = 46;
			ReqLevel = 41;
			Name = "Ebonclaw Reaver";
			Name2 = "Ebonclaw Reaver";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5268;
			BuyPrice = 83480;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1800;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 34 , 64 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Cleaver)
*
***************************************************************/

namespace Server.Items
{
	public class Cleaver : Item
	{
		public Cleaver() : base()
		{
			Id = 2029;
			SellPrice = 883;
			AvailableClasses = 0x7FFF;
			Model = 19281;
			ObjectClass = 2;
			SubClass = 0;
			Level = 20;
			ReqLevel = 15;
			Name = "Cleaver";
			Name2 = "Cleaver";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 4419;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2200;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 55;
			SetDamage( 14 , 26 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Crescent of Forlorn Spirits)
*
***************************************************************/

namespace Server.Items
{
	public class CrescentOfForlornSpirits : Item
	{
		public CrescentOfForlornSpirits() : base()
		{
			Id = 2044;
			Bonding = 1;
			SellPrice = 7357;
			AvailableClasses = 0x7FFF;
			Model = 19220;
			ObjectClass = 2;
			SubClass = 0;
			Level = 35;
			Name = "Crescent of Forlorn Spirits";
			Name2 = "Crescent of Forlorn Spirits";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 36787;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1600;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 20 , 38 , Resistances.Armor );
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Anvilmar Hand Axe)
*
***************************************************************/

namespace Server.Items
{
	public class AnvilmarHandAxe : Item
	{
		public AnvilmarHandAxe() : base()
		{
			Id = 2047;
			Bonding = 1;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 8473;
			ObjectClass = 2;
			SubClass = 0;
			Level = 5;
			Name = "Anvilmar Hand Axe";
			Name2 = "Anvilmar Hand Axe";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 129;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2000;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 30;
			SetDamage( 2 , 5 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Trogg Hand Axe)
*
***************************************************************/

namespace Server.Items
{
	public class TroggHandAxe : Item
	{
		public TroggHandAxe() : base()
		{
			Id = 2054;
			SellPrice = 16;
			AvailableClasses = 0x7FFF;
			Model = 19299;
			ObjectClass = 2;
			SubClass = 0;
			Level = 4;
			ReqLevel = 1;
			Name = "Trogg Hand Axe";
			Name2 = "Trogg Hand Axe";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 80;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2000;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 25;
			SetDamage( 2 , 4 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Skull Hatchet)
*
***************************************************************/

namespace Server.Items
{
	public class SkullHatchet : Item
	{
		public SkullHatchet() : base()
		{
			Id = 2066;
			SellPrice = 81;
			AvailableClasses = 0x7FFF;
			Model = 19203;
			ObjectClass = 2;
			SubClass = 0;
			Level = 8;
			ReqLevel = 3;
			Name = "Skull Hatchet";
			Name2 = "Skull Hatchet";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 407;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2000;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 35;
			SetDamage( 4 , 9 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Dwarven Hatchet)
*
***************************************************************/

namespace Server.Items
{
	public class DwarvenHatchet : Item
	{
		public DwarvenHatchet() : base()
		{
			Id = 2073;
			Bonding = 2;
			SellPrice = 742;
			AvailableClasses = 0x7FFF;
			Model = 19134;
			ObjectClass = 2;
			SubClass = 0;
			Level = 15;
			ReqLevel = 10;
			Name = "Dwarven Hatchet";
			Name2 = "Dwarven Hatchet";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5169;
			BuyPrice = 3713;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2000;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 50;
			SetDamage( 10 , 20 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Hillborne Axe)
*
***************************************************************/

namespace Server.Items
{
	public class HillborneAxe : Item
	{
		public HillborneAxe() : base()
		{
			Id = 2080;
			Bonding = 2;
			SellPrice = 6590;
			AvailableClasses = 0x7FFF;
			Model = 19400;
			ObjectClass = 2;
			SubClass = 0;
			Level = 34;
			ReqLevel = 29;
			Name = "Hillborne Axe";
			Name2 = "Hillborne Axe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5232;
			BuyPrice = 32954;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2200;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 27 , 51 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Hand Axe)
*
***************************************************************/

namespace Server.Items
{
	public class HandAxe : Item
	{
		public HandAxe() : base()
		{
			Id = 2134;
			SellPrice = 16;
			AvailableClasses = 0x7FFF;
			Model = 22101;
			ObjectClass = 2;
			SubClass = 0;
			Level = 4;
			ReqLevel = 1;
			Name = "Hand Axe";
			Name2 = "Hand Axe";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 82;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2000;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 25;
			SetDamage( 2 , 4 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Frostmane Hand Axe)
*
***************************************************************/

namespace Server.Items
{
	public class FrostmaneHandAxe : Item
	{
		public FrostmaneHandAxe() : base()
		{
			Id = 2260;
			SellPrice = 106;
			AvailableClasses = 0x7FFF;
			Model = 8470;
			ObjectClass = 2;
			SubClass = 0;
			Level = 9;
			ReqLevel = 4;
			Name = "Frostmane Hand Axe";
			Name2 = "Frostmane Hand Axe";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 532;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2000;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 35;
			SetDamage( 5 , 10 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Stonesplinter Axe)
*
***************************************************************/

namespace Server.Items
{
	public class StonesplinterAxe : Item
	{
		public StonesplinterAxe() : base()
		{
			Id = 2265;
			Bonding = 2;
			SellPrice = 477;
			AvailableClasses = 0x7FFF;
			Model = 19297;
			ObjectClass = 2;
			SubClass = 0;
			Level = 13;
			ReqLevel = 8;
			Name = "Stonesplinter Axe";
			Name2 = "Stonesplinter Axe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2387;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2200;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 45;
			SetDamage( 10 , 20 , Resistances.Armor );
			StrBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Rodentia Flint Axe)
*
***************************************************************/

namespace Server.Items
{
	public class RodentiaFlintAxe : Item
	{
		public RodentiaFlintAxe() : base()
		{
			Id = 2281;
			Bonding = 2;
			SellPrice = 300;
			AvailableClasses = 0x7FFF;
			Model = 19297;
			ObjectClass = 2;
			SubClass = 0;
			Level = 11;
			ReqLevel = 6;
			Name = "Rodentia Flint Axe";
			Name2 = "Rodentia Flint Axe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1504;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2000;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 40;
			SetDamage( 8 , 16 , Resistances.Armor );
			IqBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Inferior Tomahawk)
*
***************************************************************/

namespace Server.Items
{
	public class InferiorTomahawk : Item
	{
		public InferiorTomahawk() : base()
		{
			Id = 2482;
			SellPrice = 11;
			AvailableClasses = 0x7FFF;
			Model = 8495;
			ObjectClass = 2;
			SubClass = 0;
			Level = 3;
			ReqLevel = 1;
			Name = "Inferior Tomahawk";
			Name2 = "Inferior Tomahawk";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 58;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2100;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Flags = 16;
			SetDamage( 1 , 3 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Tomahawk)
*
***************************************************************/

namespace Server.Items
{
	public class Tomahawk : Item
	{
		public Tomahawk() : base()
		{
			Id = 2490;
			SellPrice = 108;
			AvailableClasses = 0x7FFF;
			Model = 8488;
			ObjectClass = 2;
			SubClass = 0;
			Level = 9;
			ReqLevel = 4;
			Name = "Tomahawk";
			Name2 = "Tomahawk";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 540;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1700;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 35;
			SetDamage( 4 , 9 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Small Tomahawk)
*
***************************************************************/

namespace Server.Items
{
	public class SmallTomahawk : Item
	{
		public SmallTomahawk() : base()
		{
			Id = 2498;
			SellPrice = 81;
			AvailableClasses = 0x7FFF;
			Model = 19299;
			ObjectClass = 2;
			SubClass = 0;
			Level = 8;
			ReqLevel = 3;
			Name = "Small Tomahawk";
			Name2 = "Small Tomahawk";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 407;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1800;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Flags = 16;
			SetDamage( 4 , 8 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Crescent Axe)
*
***************************************************************/

namespace Server.Items
{
	public class CrescentAxe : Item
	{
		public CrescentAxe() : base()
		{
			Id = 2522;
			SellPrice = 4509;
			AvailableClasses = 0x7FFF;
			Model = 8485;
			ObjectClass = 2;
			SubClass = 0;
			Level = 35;
			ReqLevel = 30;
			Name = "Crescent Axe";
			Name2 = "Crescent Axe";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 22548;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2600;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 31 , 58 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Francisca)
*
***************************************************************/

namespace Server.Items
{
	public class Francisca : Item
	{
		public Francisca() : base()
		{
			Id = 2530;
			SellPrice = 10443;
			AvailableClasses = 0x7FFF;
			Model = 22105;
			ObjectClass = 2;
			SubClass = 0;
			Level = 46;
			ReqLevel = 41;
			Name = "Francisca";
			Name2 = "Francisca";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 52219;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2300;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 41 , 78 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Guillotine Axe)
*
***************************************************************/

namespace Server.Items
{
	public class GuillotineAxe : Item
	{
		public GuillotineAxe() : base()
		{
			Id = 2807;
			Bonding = 2;
			SellPrice = 2452;
			AvailableClasses = 0x7FFF;
			Model = 9118;
			ObjectClass = 2;
			SubClass = 0;
			Level = 23;
			ReqLevel = 18;
			Name = "Guillotine Axe";
			Name2 = "Guillotine Axe";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 12264;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2700;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 28 , 53 , Resistances.Armor );
			AgilityBonus = 3;
			StrBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Curve-bladed Ripper)
*
***************************************************************/

namespace Server.Items
{
	public class CurveBladedRipper : Item
	{
		public CurveBladedRipper() : base()
		{
			Id = 2815;
			Bonding = 2;
			SellPrice = 19778;
			AvailableClasses = 0x7FFF;
			Model = 8467;
			ObjectClass = 2;
			SubClass = 0;
			Level = 45;
			ReqLevel = 40;
			Name = "Curve-bladed Ripper";
			Name2 = "Curve-bladed Ripper";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 98890;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1900;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetDamage( 40 , 75 , Resistances.Armor );
			StaminaBonus = 5;
			StrBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Copper Axe)
*
***************************************************************/

namespace Server.Items
{
	public class CopperAxe : Item
	{
		public CopperAxe() : base()
		{
			Id = 2845;
			SellPrice = 109;
			AvailableClasses = 0x7FFF;
			Model = 14035;
			ObjectClass = 2;
			SubClass = 0;
			Level = 9;
			ReqLevel = 4;
			Name = "Copper Axe";
			Name2 = "Copper Axe";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 546;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1900;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 35;
			SetDamage( 5 , 10 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Bronze Axe)
*
***************************************************************/

namespace Server.Items
{
	public class BronzeAxe : Item
	{
		public BronzeAxe() : base()
		{
			Id = 2849;
			SellPrice = 1269;
			AvailableClasses = 0x7FFF;
			Model = 19929;
			ObjectClass = 2;
			SubClass = 0;
			Level = 23;
			ReqLevel = 18;
			Name = "Bronze Axe";
			Name2 = "Bronze Axe";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 6345;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2100;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			SetDamage( 15 , 29 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Bearded Boneaxe)
*
***************************************************************/

namespace Server.Items
{
	public class BeardedBoneaxe : Item
	{
		public BeardedBoneaxe() : base()
		{
			Id = 2878;
			Bonding = 2;
			SellPrice = 5143;
			AvailableClasses = 0x7FFF;
			Model = 8456;
			ObjectClass = 2;
			SubClass = 0;
			Level = 30;
			ReqLevel = 25;
			Name = "Bearded Boneaxe";
			Name2 = "Bearded Boneaxe";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 25718;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1900;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetDamage( 25 , 47 , Resistances.Armor );
			StrBonus = 4;
			AgilityBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Striking Hatchet)
*
***************************************************************/

namespace Server.Items
{
	public class StrikingHatchet : Item
	{
		public StrikingHatchet() : base()
		{
			Id = 3071;
			Bonding = 1;
			SellPrice = 231;
			AvailableClasses = 0x7FFF;
			Model = 19209;
			ObjectClass = 2;
			SubClass = 0;
			Level = 12;
			Name = "Striking Hatchet";
			Name2 = "Striking Hatchet";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1155;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1700;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 40;
			SetDamage( 6 , 12 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Thelsamar Axe)
*
***************************************************************/

namespace Server.Items
{
	public class ThelsamarAxe : Item
	{
		public ThelsamarAxe() : base()
		{
			Id = 3154;
			Bonding = 1;
			SellPrice = 1094;
			AvailableClasses = 0x7FFF;
			Model = 18340;
			ObjectClass = 2;
			SubClass = 0;
			Level = 18;
			Name = "Thelsamar Axe";
			Name2 = "Thelsamar Axe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5470;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2100;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 55;
			SetDamage( 13 , 25 , Resistances.Armor );
			AgilityBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Deadman Cleaver)
*
***************************************************************/

namespace Server.Items
{
	public class DeadmanCleaver : Item
	{
		public DeadmanCleaver() : base()
		{
			Id = 3293;
			SellPrice = 11;
			AvailableClasses = 0x7FFF;
			Model = 19281;
			ObjectClass = 2;
			SubClass = 0;
			Level = 3;
			ReqLevel = 1;
			Name = "Deadman Cleaver";
			Name2 = "Deadman Cleaver";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 58;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2200;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 20;
			SetDamage( 1 , 4 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Ceremonial Tomahawk)
*
***************************************************************/

namespace Server.Items
{
	public class CeremonialTomahawk : Item
	{
		public CeremonialTomahawk() : base()
		{
			Id = 3443;
			Bonding = 1;
			SellPrice = 138;
			AvailableClasses = 0x7FFF;
			Model = 8495;
			ObjectClass = 2;
			SubClass = 0;
			Level = 10;
			Name = "Ceremonial Tomahawk";
			Name2 = "Ceremonial Tomahawk";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 691;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1700;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 40;
			SetDamage( 5 , 10 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Thick War Axe)
*
***************************************************************/

namespace Server.Items
{
	public class ThickWarAxe : Item
	{
		public ThickWarAxe() : base()
		{
			Id = 3489;
			Bonding = 2;
			SellPrice = 937;
			AvailableClasses = 0x7FFF;
			Model = 8496;
			ObjectClass = 2;
			SubClass = 0;
			Level = 17;
			ReqLevel = 12;
			Name = "Thick War Axe";
			Name2 = "Thick War Axe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4688;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2500;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 50;
			SetDamage( 15 , 28 , Resistances.Armor );
			StaminaBonus = 1;
			StrBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Fish Gutter)
*
***************************************************************/

namespace Server.Items
{
	public class FishGutter : Item
	{
		public FishGutter() : base()
		{
			Id = 3755;
			Bonding = 1;
			SellPrice = 5447;
			AvailableClasses = 0x7FFF;
			Model = 19228;
			ObjectClass = 2;
			SubClass = 0;
			Level = 32;
			Name = "Fish Gutter";
			Name2 = "Fish Gutter";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 27236;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2100;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 24 , 46 , Resistances.Armor );
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Keen Axe)
*
***************************************************************/

namespace Server.Items
{
	public class KeenAxe : Item
	{
		public KeenAxe() : base()
		{
			Id = 3785;
			SellPrice = 3650;
			AvailableClasses = 0x7FFF;
			Model = 8480;
			ObjectClass = 2;
			SubClass = 0;
			Level = 38;
			ReqLevel = 33;
			Name = "Keen Axe";
			Name2 = "Keen Axe";
			AvailableRaces = 0x1FF;
			BuyPrice = 18250;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2200;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 19 , 35 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Heavy Flint Axe)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyFlintAxe : Item
	{
		public HeavyFlintAxe() : base()
		{
			Id = 4019;
			SellPrice = 8336;
			AvailableClasses = 0x7FFF;
			Model = 8478;
			ObjectClass = 2;
			SubClass = 0;
			Level = 48;
			ReqLevel = 43;
			Name = "Heavy Flint Axe";
			Name2 = "Heavy Flint Axe";
			AvailableRaces = 0x1FF;
			BuyPrice = 41683;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2300;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 27 , 52 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Guerrilla Cleaver)
*
***************************************************************/

namespace Server.Items
{
	public class GuerrillaCleaver : Item
	{
		public GuerrillaCleaver() : base()
		{
			Id = 4126;
			Bonding = 1;
			SellPrice = 6396;
			AvailableClasses = 0x7FFF;
			Model = 19217;
			ObjectClass = 2;
			SubClass = 0;
			Level = 34;
			Name = "Guerrilla Cleaver";
			Name2 = "Guerrilla Cleaver";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 31980;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2800;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 34 , 65 , Resistances.Armor );
			StaminaBonus = 4;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Flesh Carver)
*
***************************************************************/

namespace Server.Items
{
	public class FleshCarver : Item
	{
		public FleshCarver() : base()
		{
			Id = 4445;
			Bonding = 2;
			SellPrice = 2068;
			AvailableClasses = 0x7FFF;
			Model = 19398;
			ObjectClass = 2;
			SubClass = 0;
			Level = 23;
			ReqLevel = 18;
			Name = "Flesh Carver";
			Name2 = "Flesh Carver";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 10341;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2300;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			SetDamage( 18 , 35 , Resistances.Armor );
			AgilityBonus = 2;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Scalping Tomahawk)
*
***************************************************************/

namespace Server.Items
{
	public class ScalpingTomahawk : Item
	{
		public ScalpingTomahawk() : base()
		{
			Id = 4561;
			Bonding = 2;
			SellPrice = 309;
			AvailableClasses = 0x7FFF;
			Model = 19299;
			ObjectClass = 2;
			SubClass = 0;
			Level = 11;
			ReqLevel = 6;
			Name = "Scalping Tomahawk";
			Name2 = "Scalping Tomahawk";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5169;
			BuyPrice = 1546;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1800;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 40;
			SetDamage( 7 , 14 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Grunt Axe)
*
***************************************************************/

namespace Server.Items
{
	public class GruntAxe : Item
	{
		public GruntAxe() : base()
		{
			Id = 4568;
			Bonding = 2;
			SellPrice = 1694;
			AvailableClasses = 0x7FFF;
			Model = 22478;
			ObjectClass = 2;
			SubClass = 0;
			Level = 21;
			ReqLevel = 16;
			Name = "Grunt Axe";
			Name2 = "Grunt Axe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5187;
			BuyPrice = 8474;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2300;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 60;
			SetDamage( 17 , 32 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Blurred Axe)
*
***************************************************************/

namespace Server.Items
{
	public class BlurredAxe : Item
	{
		public BlurredAxe() : base()
		{
			Id = 4824;
			Bonding = 2;
			SellPrice = 3371;
			AvailableClasses = 0x7FFF;
			Model = 8459;
			ObjectClass = 2;
			SubClass = 0;
			Level = 27;
			ReqLevel = 22;
			Name = "Blurred Axe";
			Name2 = "Blurred Axe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 16856;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1700;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 70;
			SetDamage( 16 , 31 , Resistances.Armor );
			AgilityBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Callous Axe)
*
***************************************************************/

namespace Server.Items
{
	public class CallousAxe : Item
	{
		public CallousAxe() : base()
		{
			Id = 4825;
			Bonding = 2;
			SellPrice = 4094;
			AvailableClasses = 0x7FFF;
			Model = 8461;
			ObjectClass = 2;
			SubClass = 0;
			Level = 29;
			ReqLevel = 24;
			Name = "Callous Axe";
			Name2 = "Callous Axe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 20472;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2800;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetSpell( 9139 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 29 , 55 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Marauder Axe)
*
***************************************************************/

namespace Server.Items
{
	public class MarauderAxe : Item
	{
		public MarauderAxe() : base()
		{
			Id = 4826;
			Bonding = 2;
			SellPrice = 3087;
			AvailableClasses = 0x7FFF;
			Model = 19224;
			ObjectClass = 2;
			SubClass = 0;
			Level = 26;
			ReqLevel = 21;
			Name = "Marauder Axe";
			Name2 = "Marauder Axe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 15436;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2000;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 70;
			SetDamage( 18 , 35 , Resistances.Armor );
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Primitive Hatchet)
*
***************************************************************/

namespace Server.Items
{
	public class PrimitiveHatchet : Item
	{
		public PrimitiveHatchet() : base()
		{
			Id = 4923;
			Bonding = 1;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 8498;
			ObjectClass = 2;
			SubClass = 0;
			Level = 5;
			Name = "Primitive Hatchet";
			Name2 = "Primitive Hatchet";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 128;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2200;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 30;
			SetDamage( 3 , 6 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Orcish Cleaver)
*
***************************************************************/

namespace Server.Items
{
	public class OrcishCleaver : Item
	{
		public OrcishCleaver() : base()
		{
			Id = 4949;
			Bonding = 2;
			SellPrice = 1706;
			AvailableClasses = 0x7FFF;
			Model = 19214;
			ObjectClass = 2;
			SubClass = 0;
			Level = 21;
			ReqLevel = 16;
			Name = "Orcish Cleaver";
			Name2 = "Orcish Cleaver";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 8532;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1800;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 60;
			SetDamage( 13 , 25 , Resistances.Armor );
			StrBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Smite's Reaver)
*
***************************************************************/

namespace Server.Items
{
	public class SmitesReaver : Item
	{
		public SmitesReaver() : base()
		{
			Id = 5196;
			Bonding = 1;
			SellPrice = 1830;
			AvailableClasses = 0x7FFF;
			Model = 13913;
			ObjectClass = 2;
			SubClass = 0;
			Level = 22;
			ReqLevel = 17;
			Name = "Smite's Reaver";
			Name2 = "Smite's Reaver";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 9154;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1900;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 60;
			SetDamage( 14 , 28 , Resistances.Armor );
			StrBonus = 2;
			IqBonus = 1;
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Pointed Axe)
*
***************************************************************/

namespace Server.Items
{
	public class PointedAxe : Item
	{
		public PointedAxe() : base()
		{
			Id = 5344;
			Bonding = 1;
			SellPrice = 562;
			AvailableClasses = 0x7FFF;
			Model = 8485;
			ObjectClass = 2;
			SubClass = 0;
			Level = 14;
			Name = "Pointed Axe";
			Name2 = "Pointed Axe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2812;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1900;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 45;
			SetDamage( 9 , 18 , Resistances.Armor );
			AgilityBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Serpent's Kiss)
*
***************************************************************/

namespace Server.Items
{
	public class SerpentsKiss : Item
	{
		public SerpentsKiss() : base()
		{
			Id = 5426;
			Bonding = 2;
			SellPrice = 1686;
			AvailableClasses = 0x7FFF;
			Model = 19396;
			ObjectClass = 2;
			SubClass = 0;
			Level = 20;
			ReqLevel = 15;
			Name = "Serpent's Kiss";
			Name2 = "Serpent's Kiss";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 8431;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2500;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			SetSpell( 18197 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 23 , 44 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Defender Axe)
*
***************************************************************/

namespace Server.Items
{
	public class DefenderAxe : Item
	{
		public DefenderAxe() : base()
		{
			Id = 5459;
			Resistance[0] = 10;
			Bonding = 1;
			SellPrice = 472;
			AvailableClasses = 0x7FFF;
			Model = 7965;
			ObjectClass = 2;
			SubClass = 0;
			Level = 13;
			Name = "Defender Axe";
			Name2 = "Defender Axe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2361;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2300;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 45;
			SetDamage( 11 , 21 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Barreling Reaper)
*
***************************************************************/

namespace Server.Items
{
	public class BarrelingReaper : Item
	{
		public BarrelingReaper() : base()
		{
			Id = 6194;
			Bonding = 1;
			SellPrice = 5308;
			AvailableClasses = 0x7FFF;
			Model = 19404;
			ObjectClass = 2;
			SubClass = 0;
			Level = 32;
			Name = "Barreling Reaper";
			Name2 = "Barreling Reaper";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 26543;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1900;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 22 , 41 , Resistances.Armor );
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Pronged Reaver)
*
***************************************************************/

namespace Server.Items
{
	public class ProngedReaver : Item
	{
		public ProngedReaver() : base()
		{
			Id = 6692;
			Bonding = 1;
			SellPrice = 9788;
			AvailableClasses = 0x7FFF;
			Model = 25597;
			ObjectClass = 2;
			SubClass = 0;
			Level = 36;
			ReqLevel = 31;
			Name = "Pronged Reaver";
			Name2 = "Pronged Reaver";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 48942;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2400;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetDamage( 40 , 75 , Resistances.Armor );
			IqBonus = 5;
			StrBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Bleeding Crescent)
*
***************************************************************/

namespace Server.Items
{
	public class BleedingCrescent : Item
	{
		public BleedingCrescent() : base()
		{
			Id = 6738;
			Bonding = 1;
			SellPrice = 7040;
			AvailableClasses = 0x7FFF;
			Model = 19126;
			ObjectClass = 2;
			SubClass = 0;
			Level = 35;
			Name = "Bleeding Crescent";
			Name2 = "Bleeding Crescent";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 35203;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2400;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetSpell( 16403 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 30 , 57 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Elunite Axe)
*
***************************************************************/

namespace Server.Items
{
	public class EluniteAxe : Item
	{
		public EluniteAxe() : base()
		{
			Id = 6966;
			Bonding = 1;
			SellPrice = 693;
			AvailableClasses = 0x01;
			Model = 19135;
			ObjectClass = 2;
			SubClass = 0;
			Level = 15;
			Name = "Elunite Axe";
			Name2 = "Elunite Axe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3468;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2700;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 50;
			SetDamage( 14 , 28 , Resistances.Armor );
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Umbral Axe)
*
***************************************************************/

namespace Server.Items
{
	public class UmbralAxe : Item
	{
		public UmbralAxe() : base()
		{
			Id = 6978;
			Bonding = 1;
			SellPrice = 672;
			AvailableClasses = 0x01;
			Model = 19133;
			ObjectClass = 2;
			SubClass = 0;
			Level = 15;
			Name = "Umbral Axe";
			Name2 = "Umbral Axe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3363;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2700;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 50;
			SetDamage( 14 , 28 , Resistances.Armor );
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Haggard's Axe)
*
***************************************************************/

namespace Server.Items
{
	public class HaggardsAxe : Item
	{
		public HaggardsAxe() : base()
		{
			Id = 6979;
			Bonding = 1;
			SellPrice = 675;
			AvailableClasses = 0x01;
			Model = 19274;
			ObjectClass = 2;
			SubClass = 0;
			Level = 15;
			Name = "Haggard's Axe";
			Name2 = "Haggard's Axe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3376;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2700;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 50;
			SetDamage( 14 , 28 , Resistances.Armor );
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Heirloom Axe)
*
***************************************************************/

namespace Server.Items
{
	public class HeirloomAxe : Item
	{
		public HeirloomAxe() : base()
		{
			Id = 7115;
			Bonding = 1;
			SellPrice = 683;
			AvailableClasses = 0x01;
			Model = 19204;
			ObjectClass = 2;
			SubClass = 0;
			Level = 15;
			Name = "Heirloom Axe";
			Name2 = "Heirloom Axe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3415;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2700;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 50;
			SetDamage( 14 , 28 , Resistances.Armor );
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Thun'grim's Axe)
*
***************************************************************/

namespace Server.Items
{
	public class ThungrimsAxe : Item
	{
		public ThungrimsAxe() : base()
		{
			Id = 7326;
			Bonding = 1;
			SellPrice = 696;
			AvailableClasses = 0x01;
			Model = 19132;
			ObjectClass = 2;
			SubClass = 0;
			Level = 15;
			Name = "Thun'grim's Axe";
			Name2 = "Thun'grim's Axe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3480;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2700;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 50;
			SetDamage( 14 , 28 , Resistances.Armor );
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Steelclaw Reaver)
*
***************************************************************/

namespace Server.Items
{
	public class SteelclawReaver : Item
	{
		public SteelclawReaver() : base()
		{
			Id = 7761;
			Bonding = 2;
			SellPrice = 11290;
			AvailableClasses = 0x7FFF;
			Model = 19210;
			ObjectClass = 2;
			SubClass = 0;
			Level = 38;
			ReqLevel = 33;
			Name = "Steelclaw Reaver";
			Name2 = "Steelclaw Reaver";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 56453;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1800;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetDamage( 32 , 61 , Resistances.Armor );
			AgilityBonus = 3;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Headsplitter)
*
***************************************************************/

namespace Server.Items
{
	public class Headsplitter : Item
	{
		public Headsplitter() : base()
		{
			Id = 7786;
			Bonding = 2;
			SellPrice = 5605;
			AvailableClasses = 0x7FFF;
			Model = 15938;
			ObjectClass = 2;
			SubClass = 0;
			Level = 30;
			ReqLevel = 25;
			Name = "Headsplitter";
			Name2 = "Headsplitter";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 28028;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2300;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetDamage( 30 , 57 , Resistances.Armor );
			StrBonus = 3;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Heavy Mithril Axe)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyMithrilAxe : Item
	{
		public HeavyMithrilAxe() : base()
		{
			Id = 7941;
			Bonding = 2;
			SellPrice = 12520;
			AvailableClasses = 0x7FFF;
			Model = 16126;
			ObjectClass = 2;
			SubClass = 0;
			Level = 42;
			ReqLevel = 37;
			Name = "Heavy Mithril Axe";
			Name2 = "Heavy Mithril Axe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 62601;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2700;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 45 , 85 , Resistances.Armor );
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Blue Glittering Axe)
*
***************************************************************/

namespace Server.Items
{
	public class BlueGlitteringAxe : Item
	{
		public BlueGlitteringAxe() : base()
		{
			Id = 7942;
			Bonding = 2;
			SellPrice = 14659;
			AvailableClasses = 0x7FFF;
			Model = 5639;
			ObjectClass = 2;
			SubClass = 0;
			Level = 44;
			ReqLevel = 39;
			Name = "Blue Glittering Axe";
			Name2 = "Blue Glittering Axe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 73296;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1800;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 32 , 61 , Resistances.Armor );
			AgilityBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Shovelphlange's Mining Axe)
*
***************************************************************/

namespace Server.Items
{
	public class ShovelphlangesMiningAxe : Item
	{
		public ShovelphlangesMiningAxe() : base()
		{
			Id = 9378;
			Bonding = 2;
			SellPrice = 11380;
			AvailableClasses = 0x7FFF;
			Model = 18257;
			ObjectClass = 2;
			SubClass = 0;
			Level = 38;
			ReqLevel = 33;
			Name = "Shovelphlange's Mining Axe";
			Name2 = "Shovelphlange's Mining Axe";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 56901;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2800;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetSpell( 9140 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 50 , 94 , Resistances.Armor );
			StrBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Digmaster 5000)
*
***************************************************************/

namespace Server.Items
{
	public class Digmaster5000 : Item
	{
		public Digmaster5000() : base()
		{
			Id = 9465;
			Bonding = 2;
			SellPrice = 18560;
			AvailableClasses = 0x7FFF;
			Model = 18377;
			ObjectClass = 2;
			SubClass = 0;
			Level = 45;
			ReqLevel = 40;
			Name = "Digmaster 5000";
			Name2 = "Digmaster 5000";
			Quality = 3;
			AvailableRaces = 0x1FF;
			SkillRank = 175;
			Skill = 186;
			BuyPrice = 92804;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1800;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetSpell( 11791 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 38 , 71 , Resistances.Armor );
			AgilityBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Ripsaw)
*
***************************************************************/

namespace Server.Items
{
	public class Ripsaw : Item
	{
		public Ripsaw() : base()
		{
			Id = 9478;
			Bonding = 1;
			SellPrice = 28853;
			AvailableClasses = 0x7FFF;
			Model = 25598;
			ObjectClass = 2;
			SubClass = 0;
			Level = 50;
			ReqLevel = 45;
			Name = "Ripsaw";
			Name2 = "Ripsaw";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 144265;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2700;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetSpell( 16405 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 63 , 117 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Vibroblade)
*
***************************************************************/

namespace Server.Items
{
	public class Vibroblade : Item
	{
		public Vibroblade() : base()
		{
			Id = 9485;
			Bonding = 2;
			SellPrice = 5288;
			AvailableClasses = 0x7FFF;
			Model = 18403;
			ObjectClass = 2;
			SubClass = 0;
			Level = 30;
			ReqLevel = 25;
			Name = "Vibroblade";
			Name2 = "Vibroblade";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 26440;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1600;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetSpell( 11791 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 21 , 40 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Shoni's Disarming Tool)
*
***************************************************************/

namespace Server.Items
{
	public class ShonisDisarmingTool : Item
	{
		public ShonisDisarmingTool() : base()
		{
			Id = 9608;
			Bonding = 1;
			SellPrice = 5028;
			AvailableClasses = 0x7FFF;
			Model = 7494;
			ObjectClass = 2;
			SubClass = 0;
			Level = 31;
			Name = "Shoni's Disarming Tool";
			Name2 = "Shoni's Disarming Tool";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 25144;
			InventoryType = InventoryTypes.OffHand;
			Delay = 1900;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetSpell( 11879 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 21 , 40 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Force of the Hippogryph)
*
***************************************************************/

namespace Server.Items
{
	public class ForceOfTheHippogryph : Item
	{
		public ForceOfTheHippogryph() : base()
		{
			Id = 9684;
			Bonding = 1;
			SellPrice = 25729;
			AvailableClasses = 0x7FFF;
			Model = 19130;
			ObjectClass = 2;
			SubClass = 0;
			Level = 51;
			Name = "Force of the Hippogryph";
			Name2 = "Force of the Hippogryph";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 128648;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2400;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 51 , 95 , Resistances.Armor );
			AgilityBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Winter's Bite)
*
***************************************************************/

namespace Server.Items
{
	public class WintersBite : Item
	{
		public WintersBite() : base()
		{
			Id = 10623;
			Bonding = 2;
			SellPrice = 24748;
			AvailableClasses = 0x7FFF;
			Model = 18391;
			ObjectClass = 2;
			SubClass = 0;
			Level = 48;
			ReqLevel = 43;
			Name = "Winter's Bite";
			Name2 = "Winter's Bite";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 123740;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2100;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetSpell( 13439 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 47 , 88 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Axe of the Ebon Drake)
*
***************************************************************/

namespace Server.Items
{
	public class AxeOfTheEbonDrake : Item
	{
		public AxeOfTheEbonDrake() : base()
		{
			Id = 10744;
			Bonding = 1;
			SellPrice = 24159;
			AvailableClasses = 0x7FFF;
			Model = 19130;
			ObjectClass = 2;
			SubClass = 0;
			Level = 51;
			Name = "Axe of the Ebon Drake";
			Name2 = "Axe of the Ebon Drake";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 120797;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1900;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 40 , 75 , Resistances.Armor );
			StrBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Glutton's Cleaver)
*
***************************************************************/

namespace Server.Items
{
	public class GluttonsCleaver : Item
	{
		public GluttonsCleaver() : base()
		{
			Id = 10772;
			Bonding = 1;
			SellPrice = 12170;
			AvailableClasses = 0x7FFF;
			Model = 8466;
			ObjectClass = 2;
			SubClass = 0;
			Level = 41;
			ReqLevel = 36;
			Name = "Glutton's Cleaver";
			Name2 = "Glutton's Cleaver";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 60853;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2000;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetSpell( 18075 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 32 , 60 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Eater of the Dead)
*
***************************************************************/

namespace Server.Items
{
	public class EaterOfTheDead : Item
	{
		public EaterOfTheDead() : base()
		{
			Id = 10805;
			Bonding = 1;
			SellPrice = 29661;
			AvailableClasses = 0x7FFF;
			Model = 19127;
			ObjectClass = 2;
			SubClass = 0;
			Level = 54;
			ReqLevel = 49;
			Name = "Eater of the Dead";
			Name2 = "Eater of the Dead";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 148309;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2200;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetSpell( 18074 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 49 , 92 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Tooth of Eranikus)
*
***************************************************************/

namespace Server.Items
{
	public class ToothOfEranikus : Item
	{
		public ToothOfEranikus() : base()
		{
			Id = 10837;
			Bonding = 1;
			SellPrice = 38801;
			AvailableClasses = 0x7FFF;
			Model = 19841;
			ObjectClass = 2;
			SubClass = 0;
			Level = 56;
			ReqLevel = 51;
			Name = "Tooth of Eranikus";
			Name2 = "Tooth of Eranikus";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 194005;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2400;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetSpell( 15464 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 62 , 116 , Resistances.Armor );
			StrBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Grizzle's Skinner)
*
***************************************************************/

namespace Server.Items
{
	public class GrizzlesSkinner : Item
	{
		public GrizzlesSkinner() : base()
		{
			Id = 11702;
			Bonding = 1;
			SellPrice = 30627;
			AvailableClasses = 0x7FFF;
			Model = 28765;
			ObjectClass = 2;
			SubClass = 0;
			Level = 55;
			ReqLevel = 50;
			Name = "Grizzle's Skinner";
			Name2 = "Grizzle's Skinner";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 153135;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2400;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 55 , 103 , Resistances.Armor );
			StrBonus = 5;
			StaminaBonus = 5;
			AgilityBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Wraith Scythe)
*
***************************************************************/

namespace Server.Items
{
	public class WraithScythe : Item
	{
		public WraithScythe() : base()
		{
			Id = 11920;
			Bonding = 1;
			SellPrice = 40732;
			AvailableClasses = 0x7FFF;
			Model = 28679;
			ObjectClass = 2;
			SubClass = 0;
			Level = 56;
			ReqLevel = 51;
			Name = "Wraith Scythe";
			Name2 = "Wraith Scythe";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 203662;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2200;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			Flags = 64;
			SetSpell( 16414 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 57 , 106 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Ribsplitter)
*
***************************************************************/

namespace Server.Items
{
	public class Ribsplitter : Item
	{
		public Ribsplitter() : base()
		{
			Id = 12527;
			Bonding = 2;
			SellPrice = 35332;
			AvailableClasses = 0x7FFF;
			Model = 21952;
			ObjectClass = 2;
			SubClass = 0;
			Level = 53;
			ReqLevel = 48;
			Name = "Ribsplitter";
			Name2 = "Ribsplitter";
			Quality = 3;
			AvailableRaces = 0x1FF;
			Extra = 5304;
			BuyPrice = 176662;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2700;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetSpell( 9140 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 66 , 124 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Demonfork)
*
***************************************************************/

namespace Server.Items
{
	public class Demonfork : Item
	{
		public Demonfork() : base()
		{
			Id = 12621;
			Bonding = 1;
			SellPrice = 45085;
			AvailableClasses = 0x7FFF;
			Model = 22885;
			ObjectClass = 2;
			SubClass = 0;
			Level = 59;
			ReqLevel = 54;
			Name = "Demonfork";
			Name2 = "Demonfork";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 225425;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2800;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetSpell( 16603 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 76 , 142 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Ornate Thorium Handaxe)
*
***************************************************************/

namespace Server.Items
{
	public class OrnateThoriumHandaxe : Item
	{
		public OrnateThoriumHandaxe() : base()
		{
			Id = 12773;
			Bonding = 1;
			SellPrice = 33079;
			AvailableClasses = 0x7FFF;
			Model = 23234;
			ObjectClass = 2;
			SubClass = 0;
			Level = 55;
			ReqLevel = 50;
			Name = "Ornate Thorium Handaxe";
			Name2 = "Ornate Thorium Handaxe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 165399;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1900;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 43 , 81 , Resistances.Armor );
			StrBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Dawn's Edge)
*
***************************************************************/

namespace Server.Items
{
	public class DawnsEdge : Item
	{
		public DawnsEdge() : base()
		{
			Id = 12774;
			Bonding = 2;
			SellPrice = 36044;
			AvailableClasses = 0x7FFF;
			Model = 23236;
			ObjectClass = 2;
			SubClass = 0;
			Level = 55;
			ReqLevel = 50;
			Name = "Dawn's Edge";
			Name2 = "Dawn's Edge";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 180220;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2100;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 53 , 100 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Annihilator)
*
***************************************************************/

namespace Server.Items
{
	public class Annihilator : Item
	{
		public Annihilator() : base()
		{
			Id = 12798;
			Bonding = 2;
			SellPrice = 57150;
			AvailableClasses = 0x7FFF;
			Model = 28849;
			ObjectClass = 2;
			SubClass = 0;
			Level = 63;
			ReqLevel = 58;
			Name = "Annihilator";
			Name2 = "Annihilator";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 285752;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1700;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetSpell( 16928 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 49 , 92 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Razor's Edge)
*
***************************************************************/

namespace Server.Items
{
	public class RazorsEdge : Item
	{
		public RazorsEdge() : base()
		{
			Id = 12990;
			Bonding = 2;
			SellPrice = 2589;
			AvailableClasses = 0x7FFF;
			Model = 28810;
			ObjectClass = 2;
			SubClass = 0;
			Level = 23;
			ReqLevel = 18;
			Name = "Razor's Edge";
			Name2 = "Razor's Edge";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 12946;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2400;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 25 , 48 , Resistances.Armor );
			StrBonus = 4;
			IqBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Axe of Rin'ji)
*
***************************************************************/

namespace Server.Items
{
	public class AxeOfRinji : Item
	{
		public AxeOfRinji() : base()
		{
			Id = 13014;
			Bonding = 2;
			SellPrice = 34705;
			AvailableClasses = 0x7FFF;
			Model = 25594;
			ObjectClass = 2;
			SubClass = 0;
			Level = 53;
			ReqLevel = 48;
			Name = "Axe of Rin'ji";
			Name2 = "Axe of Rin'ji";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 173526;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1900;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetDamage( 46 , 87 , Resistances.Armor );
			StaminaBonus = 11;
			AgilityBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Serathil)
*
***************************************************************/

namespace Server.Items
{
	public class Serathil : Item
	{
		public Serathil() : base()
		{
			Id = 13015;
			Resistance[0] = 100;
			Bonding = 2;
			SellPrice = 53957;
			AvailableClasses = 0x7FFF;
			Model = 28748;
			ObjectClass = 2;
			SubClass = 0;
			Level = 61;
			ReqLevel = 56;
			Name = "Serathil";
			Name2 = "Serathil";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 269788;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1900;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetDamage( 53 , 99 , Resistances.Armor );
			StrBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Rivenspike)
*
***************************************************************/

namespace Server.Items
{
	public class Rivenspike : Item
	{
		public Rivenspike() : base()
		{
			Id = 13286;
			Bonding = 1;
			SellPrice = 44106;
			AvailableClasses = 0x7FFF;
			Model = 23909;
			ObjectClass = 2;
			SubClass = 0;
			Level = 58;
			ReqLevel = 53;
			Name = "Rivenspike";
			Name2 = "Rivenspike";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 220533;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2900;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetSpell( 17315 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 77 , 144 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Soul Breaker)
*
***************************************************************/

namespace Server.Items
{
	public class SoulBreaker : Item
	{
		public SoulBreaker() : base()
		{
			Id = 13408;
			Bonding = 1;
			SellPrice = 44142;
			AvailableClasses = 0x7FFF;
			Model = 24119;
			ObjectClass = 2;
			SubClass = 0;
			Level = 57;
			ReqLevel = 52;
			Name = "Soul Breaker";
			Name2 = "Soul Breaker";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 220713;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1600;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetSpell( 17506 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 42 , 78 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Jagged Axe)
*
***************************************************************/

namespace Server.Items
{
	public class JaggedAxe : Item
	{
		public JaggedAxe() : base()
		{
			Id = 13818;
			SellPrice = 13431;
			AvailableClasses = 0x7FFF;
			Model = 8478;
			ObjectClass = 2;
			SubClass = 0;
			Level = 56;
			ReqLevel = 51;
			Name = "Jagged Axe";
			Name2 = "Jagged Axe";
			AvailableRaces = 0x1FF;
			BuyPrice = 67157;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1900;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 26 , 50 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Iceblade Hacker)
*
***************************************************************/

namespace Server.Items
{
	public class IcebladeHacker : Item
	{
		public IcebladeHacker() : base()
		{
			Id = 13952;
			Bonding = 1;
			SellPrice = 56683;
			AvailableClasses = 0x7FFF;
			Model = 28782;
			ObjectClass = 2;
			SubClass = 0;
			Level = 62;
			ReqLevel = 57;
			Name = "Iceblade Hacker";
			Name2 = "Iceblade Hacker";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 283415;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2000;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetDamage( 57 , 106 , Resistances.Armor );
			SetDamage( 1 , 5 , Resistances.Frost );
		}
	}
}


/**************************************************************
*
*				(Ridge Cleaver)
*
***************************************************************/

namespace Server.Items
{
	public class RidgeCleaver : Item
	{
		public RidgeCleaver() : base()
		{
			Id = 15230;
			Bonding = 2;
			SellPrice = 2755;
			AvailableClasses = 0x7FFF;
			Model = 28539;
			ObjectClass = 2;
			SubClass = 0;
			Level = 25;
			ReqLevel = 20;
			Name = "Ridge Cleaver";
			Name2 = "Ridge Cleaver";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5205;
			BuyPrice = 13778;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2200;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			SetDamage( 19 , 37 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Splitting Hatchet)
*
***************************************************************/

namespace Server.Items
{
	public class SplittingHatchet : Item
	{
		public SplittingHatchet() : base()
		{
			Id = 15231;
			Bonding = 2;
			SellPrice = 5033;
			AvailableClasses = 0x7FFF;
			Model = 28469;
			ObjectClass = 2;
			SubClass = 0;
			Level = 31;
			ReqLevel = 26;
			Name = "Splitting Hatchet";
			Name2 = "Splitting Hatchet";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5223;
			BuyPrice = 25166;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1800;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 20 , 38 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Hacking Cleaver)
*
***************************************************************/

namespace Server.Items
{
	public class HackingCleaver : Item
	{
		public HackingCleaver() : base()
		{
			Id = 15232;
			Bonding = 2;
			SellPrice = 6112;
			AvailableClasses = 0x7FFF;
			Model = 28542;
			ObjectClass = 2;
			SubClass = 0;
			Level = 33;
			ReqLevel = 28;
			Name = "Hacking Cleaver";
			Name2 = "Hacking Cleaver";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5223;
			BuyPrice = 30561;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1900;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 22 , 43 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Savage Axe)
*
***************************************************************/

namespace Server.Items
{
	public class SavageAxe : Item
	{
		public SavageAxe() : base()
		{
			Id = 15233;
			Bonding = 2;
			SellPrice = 10476;
			AvailableClasses = 0x7FFF;
			Model = 28525;
			ObjectClass = 2;
			SubClass = 0;
			Level = 39;
			ReqLevel = 34;
			Name = "Savage Axe";
			Name2 = "Savage Axe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5241;
			BuyPrice = 52380;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2800;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 42 , 78 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Greater Scythe)
*
***************************************************************/

namespace Server.Items
{
	public class GreaterScythe : Item
	{
		public GreaterScythe() : base()
		{
			Id = 15234;
			Bonding = 2;
			SellPrice = 11354;
			AvailableClasses = 0x7FFF;
			Model = 5640;
			ObjectClass = 2;
			SubClass = 0;
			Level = 40;
			ReqLevel = 35;
			Name = "Greater Scythe";
			Name2 = "Greater Scythe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5250;
			BuyPrice = 56770;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2800;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 43 , 81 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Crescent Edge)
*
***************************************************************/

namespace Server.Items
{
	public class CrescentEdge : Item
	{
		public CrescentEdge() : base()
		{
			Id = 15235;
			Bonding = 2;
			SellPrice = 21090;
			AvailableClasses = 0x7FFF;
			Model = 28341;
			ObjectClass = 2;
			SubClass = 0;
			Level = 48;
			ReqLevel = 43;
			Name = "Crescent Edge";
			Name2 = "Crescent Edge";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5268;
			BuyPrice = 105454;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2100;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 42 , 78 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Moon Cleaver)
*
***************************************************************/

namespace Server.Items
{
	public class MoonCleaver : Item
	{
		public MoonCleaver() : base()
		{
			Id = 15236;
			Bonding = 2;
			SellPrice = 27485;
			AvailableClasses = 0x7FFF;
			Model = 28566;
			ObjectClass = 2;
			SubClass = 0;
			Level = 52;
			ReqLevel = 47;
			Name = "Moon Cleaver";
			Name2 = "Moon Cleaver";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5286;
			BuyPrice = 137428;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2200;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 47 , 89 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Corpse Harvester)
*
***************************************************************/

namespace Server.Items
{
	public class CorpseHarvester : Item
	{
		public CorpseHarvester() : base()
		{
			Id = 15237;
			Bonding = 2;
			SellPrice = 30526;
			AvailableClasses = 0x7FFF;
			Model = 28338;
			ObjectClass = 2;
			SubClass = 0;
			Level = 55;
			ReqLevel = 50;
			Name = "Corpse Harvester";
			Name2 = "Corpse Harvester";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5295;
			BuyPrice = 152630;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2600;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 59 , 111 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Warlord's Axe)
*
***************************************************************/

namespace Server.Items
{
	public class WarlordsAxe : Item
	{
		public WarlordsAxe() : base()
		{
			Id = 15238;
			Bonding = 2;
			SellPrice = 36496;
			AvailableClasses = 0x7FFF;
			Model = 28459;
			ObjectClass = 2;
			SubClass = 0;
			Level = 58;
			ReqLevel = 53;
			Name = "Warlord's Axe";
			Name2 = "Warlord's Axe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5304;
			BuyPrice = 182480;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2300;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 55 , 104 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Felstone Reaver)
*
***************************************************************/

namespace Server.Items
{
	public class FelstoneReaver : Item
	{
		public FelstoneReaver() : base()
		{
			Id = 15239;
			Bonding = 2;
			SellPrice = 42409;
			AvailableClasses = 0x7FFF;
			Model = 28523;
			ObjectClass = 2;
			SubClass = 0;
			Level = 61;
			ReqLevel = 56;
			Name = "Felstone Reaver";
			Name2 = "Felstone Reaver";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5313;
			BuyPrice = 212049;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2000;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 51 , 95 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Demon's Claw)
*
***************************************************************/

namespace Server.Items
{
	public class DemonsClaw : Item
	{
		public DemonsClaw() : base()
		{
			Id = 15240;
			Bonding = 2;
			SellPrice = 49281;
			AvailableClasses = 0x7FFF;
			Model = 28504;
			ObjectClass = 2;
			SubClass = 0;
			Level = 64;
			ReqLevel = 59;
			Name = "Demon's Claw";
			Name2 = "Demon's Claw";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5322;
			BuyPrice = 246405;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2300;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 61 , 115 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Windreaper)
*
***************************************************************/

namespace Server.Items
{
	public class Windreaper : Item
	{
		public Windreaper() : base()
		{
			Id = 15853;
			Bonding = 1;
			SellPrice = 51418;
			AvailableClasses = 0x7FFF;
			Model = 26535;
			ObjectClass = 2;
			SubClass = 0;
			Level = 60;
			Name = "Windreaper";
			Name2 = "Windreaper";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 257091;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2300;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetSpell( 20586 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 63 , 118 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Blitzcleaver)
*
***************************************************************/

namespace Server.Items
{
	public class Blitzcleaver : Item
	{
		public Blitzcleaver() : base()
		{
			Id = 15862;
			Bonding = 1;
			SellPrice = 28789;
			AvailableClasses = 0x7FFF;
			Model = 26545;
			ObjectClass = 2;
			SubClass = 0;
			Level = 54;
			Name = "Blitzcleaver";
			Name2 = "Blitzcleaver";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 143946;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2200;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetSpell( 9331 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 49 , 92 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Ichor Spitter)
*
***************************************************************/

namespace Server.Items
{
	public class IchorSpitter : Item
	{
		public IchorSpitter() : base()
		{
			Id = 17002;
			Bonding = 1;
			SellPrice = 44825;
			AvailableClasses = 0x7FFF;
			Model = 28834;
			ObjectClass = 2;
			SubClass = 0;
			Level = 61;
			Name = "Ichor Spitter";
			Name2 = "Ichor Spitter";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 224127;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2400;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetSpell( 17511 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 61 , 114 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Dark Iron Destroyer)
*
***************************************************************/

namespace Server.Items
{
	public class DarkIronDestroyer : Item
	{
		public DarkIronDestroyer() : base()
		{
			Id = 17016;
			Bonding = 2;
			SellPrice = 63973;
			AvailableClasses = 0x7FFF;
			Model = 23276;
			Resistance[2] = 6;
			ObjectClass = 2;
			SubClass = 0;
			Level = 65;
			ReqLevel = 60;
			Name = "Dark Iron Destroyer";
			Name2 = "Dark Iron Destroyer";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 319868;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2400;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetDamage( 71 , 134 , Resistances.Armor );
			StrBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Gutterblade)
*
***************************************************************/

namespace Server.Items
{
	public class Gutterblade : Item
	{
		public Gutterblade() : base()
		{
			Id = 17046;
			Bonding = 1;
			SellPrice = 4796;
			AvailableClasses = 0x7FFF;
			Model = 28873;
			ObjectClass = 2;
			SubClass = 0;
			Level = 31;
			Name = "Gutterblade";
			Name2 = "Gutterblade";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 23983;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2200;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 25 , 46 , Resistances.Armor );
			StrBonus = 3;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Deathbringer)
*
***************************************************************/

namespace Server.Items
{
	public class Deathbringer : Item
	{
		public Deathbringer() : base()
		{
			Id = 17068;
			Bonding = 1;
			SellPrice = 134832;
			AvailableClasses = 0x7FFF;
			Model = 29161;
			ObjectClass = 2;
			SubClass = 0;
			Level = 75;
			ReqLevel = 60;
			Name = "Deathbringer";
			Name2 = "Deathbringer";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 674164;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2900;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 105;
			SetSpell( 18138 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 114 , 213 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Edge of Winter)
*
***************************************************************/

namespace Server.Items
{
	public class EdgeOfWinter : Item
	{
		public EdgeOfWinter() : base()
		{
			Id = 17704;
			Bonding = 2;
			SellPrice = 9178;
			AvailableClasses = 0x7FFF;
			Model = 29759;
			ObjectClass = 2;
			SubClass = 0;
			Level = 38;
			ReqLevel = 33;
			Name = "Edge of Winter";
			Name2 = "Edge of Winter";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 45890;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2100;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetSpell( 16407 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 30 , 56 , Resistances.Armor );
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Well Balanced Axe)
*
***************************************************************/

namespace Server.Items
{
	public class WellBalancedAxe : Item
	{
		public WellBalancedAxe() : base()
		{
			Id = 18347;
			Bonding = 1;
			SellPrice = 43067;
			AvailableClasses = 0x7FFF;
			Model = 30699;
			ObjectClass = 2;
			SubClass = 0;
			Level = 61;
			ReqLevel = 56;
			Name = "Well Balanced Axe";
			Name2 = "Well Balanced Axe";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 215336;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1900;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 48 , 90 , Resistances.Armor );
			AgilityBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Hedgecutter)
*
***************************************************************/

namespace Server.Items
{
	public class Hedgecutter : Item
	{
		public Hedgecutter() : base()
		{
			Id = 18498;
			Bonding = 1;
			SellPrice = 47443;
			AvailableClasses = 0x7FFF;
			Model = 30834;
			ObjectClass = 2;
			SubClass = 0;
			Level = 60;
			ReqLevel = 55;
			Name = "Hedgecutter";
			Name2 = "Hedgecutter";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 237219;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1900;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetDamage( 60 , 90 , Resistances.Armor );
			StaminaBonus = 12;
			StrBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Bone Slicing Hatchet)
*
***************************************************************/

namespace Server.Items
{
	public class BoneSlicingHatchet : Item
	{
		public BoneSlicingHatchet() : base()
		{
			Id = 18737;
			Bonding = 1;
			SellPrice = 52427;
			AvailableClasses = 0x7FFF;
			Model = 31189;
			ObjectClass = 2;
			SubClass = 0;
			Level = 62;
			ReqLevel = 57;
			Name = "Bone Slicing Hatchet";
			Name2 = "Bone Slicing Hatchet";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 262137;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1700;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetDamage( 48 , 90 , Resistances.Armor );
			AgilityBonus = 13;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Grand Marshal's Handaxe)
*
***************************************************************/

namespace Server.Items
{
	public class GrandMarshalsHandaxe : Item
	{
		public GrandMarshalsHandaxe() : base()
		{
			Id = 18827;
			Bonding = 1;
			SellPrice = 50048;
			AvailableClasses = 0x7FFF;
			Model = 31956;
			ObjectClass = 2;
			SubClass = 0;
			Level = 78;
			ReqLevel = 60;
			Name = "Grand Marshal's Handaxe";
			Name2 = "Grand Marshal's Handaxe";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 250241;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2900;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 105;
			Flags = 32768;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 9335 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 138 , 207 , Resistances.Armor );
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(High Warlord's Cleaver)
*
***************************************************************/

namespace Server.Items
{
	public class HighWarlordsCleaver : Item
	{
		public HighWarlordsCleaver() : base()
		{
			Id = 18828;
			Bonding = 1;
			SellPrice = 50225;
			AvailableClasses = 0x7FFF;
			Model = 31957;
			ObjectClass = 2;
			SubClass = 0;
			Level = 78;
			ReqLevel = 60;
			Name = "High Warlord's Cleaver";
			Name2 = "High Warlord's Cleaver";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 251127;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2900;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 105;
			Flags = 32768;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 9335 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 138 , 207 , Resistances.Armor );
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Frostbite)
*
***************************************************************/

namespace Server.Items
{
	public class Frostbite : Item
	{
		public Frostbite() : base()
		{
			Id = 19103;
			Bonding = 1;
			SellPrice = 63999;
			AvailableClasses = 0x7FFF;
			Model = 31611;
			ObjectClass = 2;
			SubClass = 0;
			Level = 65;
			ReqLevel = 60;
			Name = "Frostbite";
			Name2 = "Frostbite";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 319995;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2700;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			Flags = 32768;
			SetDamage( 80 , 150 , Resistances.Armor );
			StrBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Doom's Edge)
*
***************************************************************/

namespace Server.Items
{
	public class DoomsEdge : Item
	{
		public DoomsEdge() : base()
		{
			Id = 19362;
			Bonding = 1;
			SellPrice = 106098;
			AvailableClasses = 0x7FFF;
			Model = 31869;
			ObjectClass = 2;
			SubClass = 0;
			Level = 70;
			ReqLevel = 60;
			Name = "Doom's Edge";
			Name2 = "Doom's Edge";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 530494;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2300;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 3;
			Durability = 105;
			SetDamage( 83 , 154 , Resistances.Armor );
			AgilityBonus = 16;
			StrBonus = 9;
			StaminaBonus = 7;
		}
	}
}


