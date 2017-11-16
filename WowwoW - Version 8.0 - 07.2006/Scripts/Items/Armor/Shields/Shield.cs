/**************************************************************
*
*		Made by fulgas (fulgas@gmail.com)
*
*  WowwoW Item Designer ( 2005/8/23 - 10:05:50 )
*
***************************************************************/

using System;
using System.Collections;

/***************************************************************/

/**************************************************************
*
*				(Dented Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class DentedBuckler : Item
	{
		public DentedBuckler() : base()
		{
			Id = 1166;
			Resistance[0] = 55;
			Block = 1;
			SellPrice = 16;
			AvailableClasses = 0x7FFF;
			Model = 2208;
			ObjectClass = 4;
			SubClass = 6;
			Level = 5;
			ReqLevel = 1;
			Name = "Dented Buckler";
			Name2 = "Dented Buckler";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 84;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 35;
			Flags = 16;
		}
	}
}


/**************************************************************
*
*				(Small Targe)
*
***************************************************************/

namespace Server.Items
{
	public class SmallTarge : Item
	{
		public SmallTarge() : base()
		{
			Id = 1167;
			Resistance[0] = 161;
			Block = 3;
			SellPrice = 96;
			AvailableClasses = 0x7FFF;
			Model = 18506;
			ObjectClass = 4;
			SubClass = 6;
			Level = 10;
			ReqLevel = 5;
			Name = "Small Targe";
			Name2 = "Small Targe";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 483;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 45;
			Flags = 16;
		}
	}
}


/**************************************************************
*
*				(Skullflame Shield)
*
***************************************************************/

namespace Server.Items
{
	public class SkullflameShield : Item
	{
		public SkullflameShield() : base()
		{
			Id = 1168;
			Resistance[0] = 2256;
			Bonding = 2;
			Block = 40;
			SellPrice = 42296;
			AvailableClasses = 0x7FFF;
			Model = 30993;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 6;
			Level = 59;
			ReqLevel = 54;
			Name = "Skullflame Shield";
			Name2 = "Skullflame Shield";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 211484;
			Resistance[5] = 10;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 120;
			SetSpell( 18815 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 18816 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Blackskull Shield)
*
***************************************************************/

namespace Server.Items
{
	public class BlackskullShield : Item
	{
		public BlackskullShield() : base()
		{
			Id = 1169;
			Resistance[0] = 1895;
			Bonding = 2;
			Block = 30;
			SellPrice = 18815;
			AvailableClasses = 0x7FFF;
			Model = 18816;
			ObjectClass = 4;
			SubClass = 6;
			Level = 46;
			ReqLevel = 41;
			Name = "Blackskull Shield";
			Name2 = "Blackskull Shield";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 94076;
			Resistance[5] = 10;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 120;
			IqBonus = 10;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Banded Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class BandedBuckler : Item
	{
		public BandedBuckler() : base()
		{
			Id = 1193;
			Resistance[0] = 336;
			Block = 5;
			SellPrice = 355;
			AvailableClasses = 0x7FFF;
			Model = 27782;
			ObjectClass = 4;
			SubClass = 6;
			Level = 17;
			ReqLevel = 12;
			Name = "Banded Buckler";
			Name2 = "Banded Buckler";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1779;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 60;
			Flags = 16;
		}
	}
}


/**************************************************************
*
*				(Large Wooden Shield)
*
***************************************************************/

namespace Server.Items
{
	public class LargeWoodenShield : Item
	{
		public LargeWoodenShield() : base()
		{
			Id = 1200;
			Resistance[0] = 55;
			Block = 1;
			SellPrice = 16;
			AvailableClasses = 0x7FFF;
			Model = 18663;
			ObjectClass = 4;
			SubClass = 6;
			Level = 5;
			ReqLevel = 1;
			Name = "Large Wooden Shield";
			Name2 = "Large Wooden Shield";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 82;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Dull Heater Shield)
*
***************************************************************/

namespace Server.Items
{
	public class DullHeaterShield : Item
	{
		public DullHeaterShield() : base()
		{
			Id = 1201;
			Resistance[0] = 161;
			Block = 3;
			SellPrice = 94;
			AvailableClasses = 0x7FFF;
			Model = 2161;
			ObjectClass = 4;
			SubClass = 6;
			Level = 10;
			ReqLevel = 5;
			Name = "Dull Heater Shield";
			Name2 = "Dull Heater Shield";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 473;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Wall Shield)
*
***************************************************************/

namespace Server.Items
{
	public class WallShield : Item
	{
		public WallShield() : base()
		{
			Id = 1202;
			Resistance[0] = 336;
			Block = 5;
			SellPrice = 367;
			AvailableClasses = 0x7FFF;
			Model = 2329;
			ObjectClass = 4;
			SubClass = 6;
			Level = 17;
			ReqLevel = 12;
			Name = "Wall Shield";
			Name2 = "Wall Shield";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1839;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Aegis of Stormwind)
*
***************************************************************/

namespace Server.Items
{
	public class AegisOfStormwind : Item
	{
		public AegisOfStormwind() : base()
		{
			Id = 1203;
			Resistance[0] = 1867;
			Bonding = 2;
			Block = 33;
			SellPrice = 23505;
			AvailableClasses = 0x7FFF;
			Model = 2594;
			ObjectClass = 4;
			SubClass = 6;
			Level = 54;
			ReqLevel = 49;
			Name = "Aegis of Stormwind";
			Name2 = "Aegis of Stormwind";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 117526;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 100;
			StaminaBonus = 15;
			StrBonus = 6;
		}
	}
}


/**************************************************************
*
*				(The Green Tower)
*
***************************************************************/

namespace Server.Items
{
	public class TheGreenTower : Item
	{
		public TheGreenTower() : base()
		{
			Id = 1204;
			Resistance[0] = 1308;
			Bonding = 2;
			Block = 25;
			SellPrice = 12577;
			AvailableClasses = 0x7FFF;
			Model = 1644;
			ObjectClass = 4;
			SubClass = 6;
			Level = 41;
			ReqLevel = 36;
			Name = "The Green Tower";
			Name2 = "The Green Tower";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 62886;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 120;
			SetSpell( 18097 , 1 , 0 , 0 , 0 , 0 );
			IqBonus = 7;
			StaminaBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Fire Hardened Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class FireHardenedBuckler : Item
	{
		public FireHardenedBuckler() : base()
		{
			Id = 1276;
			Resistance[0] = 528;
			Bonding = 1;
			Block = 10;
			SellPrice = 2220;
			AvailableClasses = 0x7FFF;
			Model = 2210;
			ObjectClass = 4;
			SubClass = 6;
			Level = 27;
			Name = "Fire Hardened Buckler";
			Name2 = "Fire Hardened Buckler";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11101;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 80;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Warrior's Shield)
*
***************************************************************/

namespace Server.Items
{
	public class WarriorsShield : Item
	{
		public WarriorsShield() : base()
		{
			Id = 1438;
			Resistance[0] = 135;
			Block = 3;
			SellPrice = 70;
			AvailableClasses = 0x7FFF;
			Model = 25943;
			ObjectClass = 4;
			SubClass = 6;
			Level = 9;
			ReqLevel = 4;
			Name = "Warrior's Shield";
			Name2 = "Warrior's Shield";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 352;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Shield of the Faith)
*
***************************************************************/

namespace Server.Items
{
	public class ShieldOfTheFaith : Item
	{
		public ShieldOfTheFaith() : base()
		{
			Id = 1547;
			Resistance[0] = 578;
			Bonding = 1;
			Block = 11;
			SellPrice = 2795;
			AvailableClasses = 0x7FFF;
			Model = 21551;
			ObjectClass = 4;
			SubClass = 6;
			Level = 30;
			Name = "Shield of the Faith";
			Name2 = "Shield of the Faith";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 13978;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Buckler of the Seas)
*
***************************************************************/

namespace Server.Items
{
	public class BucklerOfTheSeas : Item
	{
		public BucklerOfTheSeas() : base()
		{
			Id = 1557;
			Resistance[0] = 411;
			Bonding = 1;
			Block = 7;
			SellPrice = 918;
			AvailableClasses = 0x7FFF;
			Model = 18456;
			ObjectClass = 4;
			SubClass = 6;
			Level = 20;
			Name = "Buckler of the Seas";
			Name2 = "Buckler of the Seas";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4594;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 65;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Wall of the Dead)
*
***************************************************************/

namespace Server.Items
{
	public class WallOfTheDead : Item
	{
		public WallOfTheDead() : base()
		{
			Id = 1979;
			Resistance[0] = 1937;
			Bonding = 2;
			Block = 34;
			SellPrice = 23273;
			AvailableClasses = 0x7FFF;
			Model = 18793;
			ObjectClass = 4;
			SubClass = 6;
			Level = 50;
			ReqLevel = 45;
			Name = "Wall of the Dead";
			Name2 = "Wall of the Dead";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 116369;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 120;
			SetSpell( 19409 , 1 , 0 , -1 , 0 , -1 );
			StrBonus = 10;
			StaminaBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Green Carapace Shield)
*
***************************************************************/

namespace Server.Items
{
	public class GreenCarapaceShield : Item
	{
		public GreenCarapaceShield() : base()
		{
			Id = 2021;
			Resistance[0] = 428;
			Bonding = 2;
			Block = 7;
			SellPrice = 1025;
			AvailableClasses = 0x7FFF;
			Model = 18650;
			ObjectClass = 4;
			SubClass = 6;
			Level = 21;
			ReqLevel = 16;
			Name = "Green Carapace Shield";
			Name2 = "Green Carapace Shield";
			Resistance[3] = 4;
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5129;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Troll Protector)
*
***************************************************************/

namespace Server.Items
{
	public class TrollProtector : Item
	{
		public TrollProtector() : base()
		{
			Id = 2040;
			Resistance[0] = 1676;
			Bonding = 2;
			Block = 27;
			SellPrice = 15296;
			AvailableClasses = 0x7FFF;
			Model = 18399;
			ObjectClass = 4;
			SubClass = 6;
			Level = 48;
			ReqLevel = 43;
			Name = "Troll Protector";
			Name2 = "Troll Protector";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 76482;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 100;
			SetSpell( 13675 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Large Round Shield)
*
***************************************************************/

namespace Server.Items
{
	public class LargeRoundShield : Item
	{
		public LargeRoundShield() : base()
		{
			Id = 2129;
			Resistance[0] = 55;
			Block = 1;
			SellPrice = 15;
			AvailableClasses = 0x7FFF;
			Model = 18662;
			ObjectClass = 4;
			SubClass = 6;
			Level = 5;
			ReqLevel = 1;
			Name = "Large Round Shield";
			Name2 = "Large Round Shield";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 77;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Small Shield)
*
***************************************************************/

namespace Server.Items
{
	public class SmallShield : Item
	{
		public SmallShield() : base()
		{
			Id = 2133;
			Resistance[0] = 55;
			Block = 1;
			SellPrice = 15;
			AvailableClasses = 0x7FFF;
			Model = 18480;
			ObjectClass = 4;
			SubClass = 6;
			Level = 5;
			ReqLevel = 1;
			Name = "Small Shield";
			Name2 = "Small Shield";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 79;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 35;
			Flags = 16;
		}
	}
}


/**************************************************************
*
*				(Battered Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class BatteredBuckler : Item
	{
		public BatteredBuckler() : base()
		{
			Id = 2210;
			Resistance[0] = 12;
			Block = 1;
			SellPrice = 3;
			AvailableClasses = 0x7FFF;
			Model = 2552;
			ObjectClass = 4;
			SubClass = 6;
			Level = 2;
			ReqLevel = 1;
			Name = "Battered Buckler";
			Name2 = "Battered Buckler";
			AvailableRaces = 0x1FF;
			BuyPrice = 15;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Bent Large Shield)
*
***************************************************************/

namespace Server.Items
{
	public class BentLargeShield : Item
	{
		public BentLargeShield() : base()
		{
			Id = 2211;
			Resistance[0] = 32;
			Block = 1;
			SellPrice = 7;
			AvailableClasses = 0x7FFF;
			Model = 18656;
			ObjectClass = 4;
			SubClass = 6;
			Level = 4;
			ReqLevel = 1;
			Name = "Bent Large Shield";
			Name2 = "Bent Large Shield";
			AvailableRaces = 0x1FF;
			BuyPrice = 35;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Cracked Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class CrackedBuckler : Item
	{
		public CrackedBuckler() : base()
		{
			Id = 2212;
			Resistance[0] = 61;
			Block = 1;
			SellPrice = 16;
			AvailableClasses = 0x7FFF;
			Model = 2553;
			ObjectClass = 4;
			SubClass = 6;
			Level = 6;
			ReqLevel = 1;
			Name = "Cracked Buckler";
			Name2 = "Cracked Buckler";
			AvailableRaces = 0x1FF;
			BuyPrice = 80;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Worn Large Shield)
*
***************************************************************/

namespace Server.Items
{
	public class WornLargeShield : Item
	{
		public WornLargeShield() : base()
		{
			Id = 2213;
			Resistance[0] = 79;
			Block = 1;
			SellPrice = 24;
			AvailableClasses = 0x7FFF;
			Model = 18673;
			ObjectClass = 4;
			SubClass = 6;
			Level = 7;
			ReqLevel = 2;
			Name = "Worn Large Shield";
			Name2 = "Worn Large Shield";
			AvailableRaces = 0x1FF;
			BuyPrice = 121;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Wooden Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class WoodenBuckler : Item
	{
		public WoodenBuckler() : base()
		{
			Id = 2214;
			Resistance[0] = 282;
			Block = 3;
			SellPrice = 182;
			AvailableClasses = 0x7FFF;
			Model = 17884;
			ObjectClass = 4;
			SubClass = 6;
			Level = 15;
			ReqLevel = 10;
			Name = "Wooden Buckler";
			Name2 = "Wooden Buckler";
			AvailableRaces = 0x1FF;
			BuyPrice = 910;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Wooden Shield)
*
***************************************************************/

namespace Server.Items
{
	public class WoodenShield : Item
	{
		public WoodenShield() : base()
		{
			Id = 2215;
			Resistance[0] = 172;
			Block = 2;
			SellPrice = 81;
			AvailableClasses = 0x7FFF;
			Model = 18670;
			ObjectClass = 4;
			SubClass = 6;
			Level = 11;
			ReqLevel = 6;
			Name = "Wooden Shield";
			Name2 = "Wooden Shield";
			AvailableRaces = 0x1FF;
			BuyPrice = 405;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Simple Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class SimpleBuckler : Item
	{
		public SimpleBuckler() : base()
		{
			Id = 2216;
			Resistance[0] = 297;
			Block = 3;
			SellPrice = 210;
			AvailableClasses = 0x7FFF;
			Model = 18486;
			ObjectClass = 4;
			SubClass = 6;
			Level = 16;
			ReqLevel = 11;
			Name = "Simple Buckler";
			Name2 = "Simple Buckler";
			AvailableRaces = 0x1FF;
			BuyPrice = 1054;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Rectangular Shield)
*
***************************************************************/

namespace Server.Items
{
	public class RectangularShield : Item
	{
		public RectangularShield() : base()
		{
			Id = 2217;
			Resistance[0] = 311;
			Block = 4;
			SellPrice = 243;
			AvailableClasses = 0x7FFF;
			Model = 18665;
			ObjectClass = 4;
			SubClass = 6;
			Level = 17;
			ReqLevel = 12;
			Name = "Rectangular Shield";
			Name2 = "Rectangular Shield";
			AvailableRaces = 0x1FF;
			BuyPrice = 1216;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Small Round Shield)
*
***************************************************************/

namespace Server.Items
{
	public class SmallRoundShield : Item
	{
		public SmallRoundShield() : base()
		{
			Id = 2219;
			Resistance[0] = 383;
			Block = 5;
			SellPrice = 457;
			AvailableClasses = 0x7FFF;
			Model = 18485;
			ObjectClass = 4;
			SubClass = 6;
			Level = 22;
			ReqLevel = 17;
			Name = "Small Round Shield";
			Name2 = "Small Round Shield";
			AvailableRaces = 0x1FF;
			BuyPrice = 2288;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Box Shield)
*
***************************************************************/

namespace Server.Items
{
	public class BoxShield : Item
	{
		public BoxShield() : base()
		{
			Id = 2220;
			Resistance[0] = 397;
			Block = 6;
			SellPrice = 519;
			AvailableClasses = 0x7FFF;
			Model = 18729;
			ObjectClass = 4;
			SubClass = 6;
			Level = 23;
			ReqLevel = 18;
			Name = "Box Shield";
			Name2 = "Box Shield";
			AvailableRaces = 0x1FF;
			BuyPrice = 2596;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Targe Shield)
*
***************************************************************/

namespace Server.Items
{
	public class TargeShield : Item
	{
		public TargeShield() : base()
		{
			Id = 2221;
			Resistance[0] = 469;
			Block = 7;
			SellPrice = 910;
			AvailableClasses = 0x7FFF;
			Model = 18484;
			ObjectClass = 4;
			SubClass = 6;
			Level = 28;
			ReqLevel = 23;
			Name = "Targe Shield";
			Name2 = "Targe Shield";
			AvailableRaces = 0x1FF;
			BuyPrice = 4550;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 80;
		}
	}
}


/**************************************************************
*
*				(Tower Shield)
*
***************************************************************/

namespace Server.Items
{
	public class TowerShield : Item
	{
		public TowerShield() : base()
		{
			Id = 2222;
			Resistance[0] = 483;
			Block = 8;
			SellPrice = 1005;
			AvailableClasses = 0x7FFF;
			Model = 2559;
			ObjectClass = 4;
			SubClass = 6;
			Level = 29;
			ReqLevel = 24;
			Name = "Tower Shield";
			Name2 = "Tower Shield";
			AvailableRaces = 0x1FF;
			BuyPrice = 5025;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Militia Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class MilitiaBuckler : Item
	{
		public MilitiaBuckler() : base()
		{
			Id = 2249;
			Resistance[0] = 161;
			Bonding = 1;
			Block = 3;
			SellPrice = 91;
			AvailableClasses = 0x7FFF;
			Model = 2632;
			ObjectClass = 4;
			SubClass = 6;
			Level = 10;
			Name = "Militia Buckler";
			Name2 = "Militia Buckler";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 457;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Worn Wooden Shield)
*
***************************************************************/

namespace Server.Items
{
	public class WornWoodenShield : Item
	{
		public WornWoodenShield() : base()
		{
			Id = 2362;
			Resistance[0] = 5;
			Block = 1;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 18730;
			ObjectClass = 4;
			SubClass = 6;
			Level = 1;
			ReqLevel = 1;
			Name = "Worn Wooden Shield";
			Name2 = "Worn Wooden Shield";
			AvailableRaces = 0x1FF;
			BuyPrice = 7;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Worn Heater Shield)
*
***************************************************************/

namespace Server.Items
{
	public class WornHeaterShield : Item
	{
		public WornHeaterShield() : base()
		{
			Id = 2376;
			Resistance[0] = 161;
			Block = 3;
			SellPrice = 89;
			AvailableClasses = 0x7FFF;
			Model = 18672;
			ObjectClass = 4;
			SubClass = 6;
			Level = 10;
			ReqLevel = 5;
			Name = "Worn Heater Shield";
			Name2 = "Worn Heater Shield";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 447;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Round Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class RoundBuckler : Item
	{
		public RoundBuckler() : base()
		{
			Id = 2377;
			Resistance[0] = 161;
			Block = 3;
			SellPrice = 89;
			AvailableClasses = 0x7FFF;
			Model = 18509;
			ObjectClass = 4;
			SubClass = 6;
			Level = 10;
			ReqLevel = 5;
			Name = "Round Buckler";
			Name2 = "Round Buckler";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 449;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 45;
			Flags = 16;
		}
	}
}


/**************************************************************
*
*				(Ringed Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class RingedBuckler : Item
	{
		public RingedBuckler() : base()
		{
			Id = 2441;
			Resistance[0] = 413;
			Block = 7;
			SellPrice = 729;
			AvailableClasses = 0x7FFF;
			Model = 18468;
			ObjectClass = 4;
			SubClass = 6;
			Level = 22;
			ReqLevel = 17;
			Name = "Ringed Buckler";
			Name2 = "Ringed Buckler";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 3646;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 70;
			Flags = 16;
		}
	}
}


/**************************************************************
*
*				(Reinforced Targe)
*
***************************************************************/

namespace Server.Items
{
	public class ReinforcedTarge : Item
	{
		public ReinforcedTarge() : base()
		{
			Id = 2442;
			Resistance[0] = 491;
			Block = 9;
			SellPrice = 1312;
			AvailableClasses = 0x7FFF;
			Model = 2324;
			ObjectClass = 4;
			SubClass = 6;
			Level = 27;
			ReqLevel = 22;
			Name = "Reinforced Targe";
			Name2 = "Reinforced Targe";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 6564;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 80;
			Flags = 16;
		}
	}
}


/**************************************************************
*
*				(Metal Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class MetalBuckler : Item
	{
		public MetalBuckler() : base()
		{
			Id = 2443;
			Resistance[0] = 646;
			Block = 14;
			SellPrice = 3417;
			AvailableClasses = 0x7FFF;
			Model = 18477;
			ObjectClass = 4;
			SubClass = 6;
			Level = 37;
			ReqLevel = 32;
			Name = "Metal Buckler";
			Name2 = "Metal Buckler";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 17085;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
			Flags = 16;
		}
	}
}


/**************************************************************
*
*				(Ornate Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class OrnateBuckler : Item
	{
		public OrnateBuckler() : base()
		{
			Id = 2444;
			Resistance[0] = 1457;
			Block = 23;
			SellPrice = 9393;
			AvailableClasses = 0x7FFF;
			Model = 18516;
			ObjectClass = 4;
			SubClass = 6;
			Level = 50;
			ReqLevel = 45;
			Name = "Ornate Buckler";
			Name2 = "Ornate Buckler";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 46967;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Large Metal Shield)
*
***************************************************************/

namespace Server.Items
{
	public class LargeMetalShield : Item
	{
		public LargeMetalShield() : base()
		{
			Id = 2445;
			Resistance[0] = 413;
			Block = 7;
			SellPrice = 686;
			AvailableClasses = 0x7FFF;
			Model = 18749;
			ObjectClass = 4;
			SubClass = 6;
			Level = 22;
			ReqLevel = 17;
			Name = "Large Metal Shield";
			Name2 = "Large Metal Shield";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 3433;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Kite Shield)
*
***************************************************************/

namespace Server.Items
{
	public class KiteShield : Item
	{
		public KiteShield() : base()
		{
			Id = 2446;
			Resistance[0] = 491;
			Block = 9;
			SellPrice = 1236;
			AvailableClasses = 0x7FFF;
			Model = 18733;
			ObjectClass = 4;
			SubClass = 6;
			Level = 27;
			ReqLevel = 22;
			Name = "Kite Shield";
			Name2 = "Kite Shield";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 6182;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 80;
		}
	}
}


/**************************************************************
*
*				(Heavy Pavise)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyPavise : Item
	{
		public HeavyPavise() : base()
		{
			Id = 2448;
			Resistance[0] = 646;
			Block = 14;
			SellPrice = 3231;
			AvailableClasses = 0x7FFF;
			Model = 18732;
			ObjectClass = 4;
			SubClass = 6;
			Level = 37;
			ReqLevel = 32;
			Name = "Heavy Pavise";
			Name2 = "Heavy Pavise";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 16158;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Crested Heater Shield)
*
***************************************************************/

namespace Server.Items
{
	public class CrestedHeaterShield : Item
	{
		public CrestedHeaterShield() : base()
		{
			Id = 2451;
			Resistance[0] = 1457;
			Block = 23;
			SellPrice = 8725;
			AvailableClasses = 0x7FFF;
			Model = 18772;
			ObjectClass = 4;
			SubClass = 6;
			Level = 50;
			ReqLevel = 45;
			Name = "Crested Heater Shield";
			Name2 = "Crested Heater Shield";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 43629;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Stone Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class StoneBuckler : Item
	{
		public StoneBuckler() : base()
		{
			Id = 2900;
			Resistance[0] = 161;
			Bonding = 1;
			Block = 3;
			SellPrice = 89;
			AvailableClasses = 0x7FFF;
			Model = 18528;
			ObjectClass = 4;
			SubClass = 6;
			Level = 10;
			Name = "Stone Buckler";
			Name2 = "Stone Buckler";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 446;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Gold Lion Shield)
*
***************************************************************/

namespace Server.Items
{
	public class GoldLionShield : Item
	{
		public GoldLionShield() : base()
		{
			Id = 2916;
			Resistance[0] = 645;
			Bonding = 1;
			Block = 13;
			SellPrice = 4405;
			AvailableClasses = 0x7FFF;
			Model = 2934;
			ObjectClass = 4;
			SubClass = 6;
			Level = 34;
			Name = "Gold Lion Shield";
			Name2 = "Gold Lion Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 22028;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
			StrBonus = 2;
			StaminaBonus = 5;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Ironplate Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class IronplateBuckler : Item
	{
		public IronplateBuckler() : base()
		{
			Id = 3160;
			Resistance[0] = 328;
			Bonding = 1;
			Block = 5;
			SellPrice = 470;
			AvailableClasses = 0x7FFF;
			Model = 3304;
			ObjectClass = 4;
			SubClass = 6;
			Level = 15;
			Name = "Ironplate Buckler";
			Name2 = "Ironplate Buckler";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2351;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 55;
			IqBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Deathguard Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class DeathguardBuckler : Item
	{
		public DeathguardBuckler() : base()
		{
			Id = 3276;
			Resistance[0] = 55;
			Bonding = 1;
			Block = 1;
			SellPrice = 15;
			AvailableClasses = 0x7FFF;
			Model = 18490;
			ObjectClass = 4;
			SubClass = 6;
			Level = 5;
			Name = "Deathguard Buckler";
			Name2 = "Deathguard Buckler";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 76;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Faerleia's Shield)
*
***************************************************************/

namespace Server.Items
{
	public class FaerleiasShield : Item
	{
		public FaerleiasShield() : base()
		{
			Id = 3450;
			Resistance[0] = 328;
			Bonding = 1;
			Block = 5;
			SellPrice = 443;
			AvailableClasses = 0x7FFF;
			Model = 18659;
			ObjectClass = 4;
			SubClass = 6;
			Level = 15;
			Name = "Faerleia's Shield";
			Name2 = "Faerleia's Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2217;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 55;
			StrBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Warrior's Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class WarriorsBuckler : Item
	{
		public WarriorsBuckler() : base()
		{
			Id = 3648;
			Resistance[0] = 132;
			SellPrice = 123;
			AvailableClasses = 0x7FFF;
			Model = 18492;
			ObjectClass = 4;
			SubClass = 6;
			Level = 11;
			ReqLevel = 6;
			Name = "Warrior's Buckler";
			Name2 = "Warrior's Buckler";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 617;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
		}
	}
}


/**************************************************************
*
*				(Tribal Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class TribalBuckler : Item
	{
		public TribalBuckler() : base()
		{
			Id = 3649;
			Resistance[0] = 189;
			Block = 3;
			SellPrice = 115;
			AvailableClasses = 0x7FFF;
			Model = 18512;
			ObjectClass = 4;
			SubClass = 6;
			Level = 11;
			ReqLevel = 6;
			Name = "Tribal Buckler";
			Name2 = "Tribal Buckler";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 575;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Battle Shield)
*
***************************************************************/

namespace Server.Items
{
	public class BattleShield : Item
	{
		public BattleShield() : base()
		{
			Id = 3650;
			Resistance[0] = 135;
			Block = 3;
			SellPrice = 68;
			AvailableClasses = 0x7FFF;
			Model = 18655;
			ObjectClass = 4;
			SubClass = 6;
			Level = 9;
			ReqLevel = 4;
			Name = "Battle Shield";
			Name2 = "Battle Shield";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 342;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Veteran Shield)
*
***************************************************************/

namespace Server.Items
{
	public class VeteranShield : Item
	{
		public VeteranShield() : base()
		{
			Id = 3651;
			Resistance[0] = 328;
			Bonding = 2;
			Block = 5;
			SellPrice = 435;
			AvailableClasses = 0x7FFF;
			Model = 2052;
			ObjectClass = 4;
			SubClass = 6;
			Level = 15;
			ReqLevel = 10;
			Name = "Veteran Shield";
			Name2 = "Veteran Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2176;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 55;
			StrBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Hunting Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class HuntingBuckler : Item
	{
		public HuntingBuckler() : base()
		{
			Id = 3652;
			Resistance[0] = 311;
			Bonding = 2;
			Block = 5;
			SellPrice = 364;
			AvailableClasses = 0x7FFF;
			Model = 18488;
			ObjectClass = 4;
			SubClass = 6;
			Level = 14;
			ReqLevel = 9;
			Name = "Hunting Buckler";
			Name2 = "Hunting Buckler";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1820;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 50;
			StaminaBonus = 1;
			SpiritBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Ceremonial Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class CeremonialBuckler : Item
	{
		public CeremonialBuckler() : base()
		{
			Id = 3653;
			Resistance[0] = 328;
			Bonding = 2;
			Block = 5;
			SellPrice = 438;
			AvailableClasses = 0x7FFF;
			Model = 1673;
			ObjectClass = 4;
			SubClass = 6;
			Level = 15;
			ReqLevel = 10;
			Name = "Ceremonial Buckler";
			Name2 = "Ceremonial Buckler";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2192;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 55;
			IqBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Brackwater Shield)
*
***************************************************************/

namespace Server.Items
{
	public class BrackwaterShield : Item
	{
		public BrackwaterShield() : base()
		{
			Id = 3654;
			Resistance[0] = 311;
			Bonding = 2;
			Block = 5;
			SellPrice = 366;
			AvailableClasses = 0x7FFF;
			Model = 18657;
			ObjectClass = 4;
			SubClass = 6;
			Level = 14;
			ReqLevel = 9;
			Name = "Brackwater Shield";
			Name2 = "Brackwater Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1834;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 50;
			AgilityBonus = 1;
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Burnished Shield)
*
***************************************************************/

namespace Server.Items
{
	public class BurnishedShield : Item
	{
		public BurnishedShield() : base()
		{
			Id = 3655;
			Resistance[0] = 428;
			Bonding = 2;
			Block = 7;
			SellPrice = 1022;
			AvailableClasses = 0x7FFF;
			Model = 18696;
			ObjectClass = 4;
			SubClass = 6;
			Level = 21;
			ReqLevel = 16;
			Name = "Burnished Shield";
			Name2 = "Burnished Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5111;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 65;
			StaminaBonus = 3;
			StrBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Lambent Scale Shield)
*
***************************************************************/

namespace Server.Items
{
	public class LambentScaleShield : Item
	{
		public LambentScaleShield() : base()
		{
			Id = 3656;
			Resistance[0] = 528;
			Bonding = 2;
			Block = 10;
			SellPrice = 2116;
			AvailableClasses = 0x7FFF;
			Model = 18702;
			ObjectClass = 4;
			SubClass = 6;
			Level = 27;
			ReqLevel = 22;
			Name = "Lambent Scale Shield";
			Name2 = "Lambent Scale Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 10584;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 80;
			StrBonus = 4;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Sentry Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class SentryBuckler : Item
	{
		public SentryBuckler() : base()
		{
			Id = 3743;
			Resistance[0] = 545;
			Bonding = 1;
			Block = 10;
			SellPrice = 2451;
			AvailableClasses = 0x7FFF;
			Model = 6275;
			ObjectClass = 4;
			SubClass = 6;
			Level = 28;
			Name = "Sentry Buckler";
			Name2 = "Sentry Buckler";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 12256;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 80;
			SpiritBonus = 1;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Deadskull Shield)
*
***************************************************************/

namespace Server.Items
{
	public class DeadskullShield : Item
	{
		public DeadskullShield() : base()
		{
			Id = 3761;
			Resistance[0] = 611;
			Bonding = 1;
			Block = 12;
			SellPrice = 3306;
			AvailableClasses = 0x7FFF;
			Model = 18769;
			ObjectClass = 4;
			SubClass = 6;
			Level = 32;
			Name = "Deadskull Shield";
			Name2 = "Deadskull Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 16533;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
			StrBonus = 1;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Lunar Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class LunarBuckler : Item
	{
		public LunarBuckler() : base()
		{
			Id = 3763;
			Resistance[0] = 963;
			Bonding = 1;
			Block = 17;
			SellPrice = 6761;
			AvailableClasses = 0x7FFF;
			Model = 6272;
			ObjectClass = 4;
			SubClass = 6;
			Level = 40;
			Name = "Lunar Buckler";
			Name2 = "Lunar Buckler";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 33805;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
			StrBonus = 3;
			IqBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Reflective Heater)
*
***************************************************************/

namespace Server.Items
{
	public class ReflectiveHeater : Item
	{
		public ReflectiveHeater() : base()
		{
			Id = 3816;
			Resistance[0] = 583;
			Block = 11;
			SellPrice = 2102;
			AvailableClasses = 0x7FFF;
			Model = 4130;
			ObjectClass = 4;
			SubClass = 6;
			Level = 36;
			ReqLevel = 31;
			Name = "Reflective Heater";
			Name2 = "Reflective Heater";
			AvailableRaces = 0x1FF;
			BuyPrice = 10511;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Reinforced Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class ReinforcedBuckler : Item
	{
		public ReinforcedBuckler() : base()
		{
			Id = 3817;
			Resistance[0] = 540;
			Block = 9;
			SellPrice = 1585;
			AvailableClasses = 0x7FFF;
			Model = 18481;
			ObjectClass = 4;
			SubClass = 6;
			Level = 33;
			ReqLevel = 28;
			Name = "Reinforced Buckler";
			Name2 = "Reinforced Buckler";
			AvailableRaces = 0x1FF;
			BuyPrice = 7925;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Protective Pavise)
*
***************************************************************/

namespace Server.Items
{
	public class ProtectivePavise : Item
	{
		public ProtectivePavise() : base()
		{
			Id = 3986;
			Resistance[0] = 1317;
			Block = 17;
			SellPrice = 5332;
			AvailableClasses = 0x7FFF;
			Model = 18814;
			ObjectClass = 4;
			SubClass = 6;
			Level = 48;
			ReqLevel = 43;
			Name = "Protective Pavise";
			Name2 = "Protective Pavise";
			AvailableRaces = 0x1FF;
			BuyPrice = 26664;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Deflecting Tower)
*
***************************************************************/

namespace Server.Items
{
	public class DeflectingTower : Item
	{
		public DeflectingTower() : base()
		{
			Id = 3987;
			Resistance[0] = 1442;
			Block = 21;
			SellPrice = 6837;
			AvailableClasses = 0x7FFF;
			Model = 18774;
			ObjectClass = 4;
			SubClass = 6;
			Level = 53;
			ReqLevel = 48;
			Name = "Deflecting Tower";
			Name2 = "Deflecting Tower";
			AvailableRaces = 0x1FF;
			BuyPrice = 34185;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Blocking Targe)
*
***************************************************************/

namespace Server.Items
{
	public class BlockingTarge : Item
	{
		public BlockingTarge() : base()
		{
			Id = 3989;
			Resistance[0] = 1015;
			Block = 14;
			SellPrice = 3154;
			AvailableClasses = 0x7FFF;
			Model = 18472;
			ObjectClass = 4;
			SubClass = 6;
			Level = 42;
			ReqLevel = 37;
			Name = "Blocking Targe";
			Name2 = "Blocking Targe";
			AvailableRaces = 0x1FF;
			BuyPrice = 15772;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Crested Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class CrestedBuckler : Item
	{
		public CrestedBuckler() : base()
		{
			Id = 3990;
			Resistance[0] = 1517;
			Block = 23;
			SellPrice = 8237;
			AvailableClasses = 0x7FFF;
			Model = 17885;
			ObjectClass = 4;
			SubClass = 6;
			Level = 56;
			ReqLevel = 51;
			Name = "Crested Buckler";
			Name2 = "Crested Buckler";
			AvailableRaces = 0x1FF;
			BuyPrice = 41186;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Emblazoned Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class EmblazonedBuckler : Item
	{
		public EmblazonedBuckler() : base()
		{
			Id = 4064;
			Resistance[0] = 578;
			Bonding = 2;
			Block = 11;
			SellPrice = 2987;
			AvailableClasses = 0x7FFF;
			Model = 18487;
			ObjectClass = 4;
			SubClass = 6;
			Level = 30;
			ReqLevel = 25;
			Name = "Emblazoned Buckler";
			Name2 = "Emblazoned Buckler";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 14938;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
			IqBonus = 5;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Combat Shield)
*
***************************************************************/

namespace Server.Items
{
	public class CombatShield : Item
	{
		public CombatShield() : base()
		{
			Id = 4065;
			Resistance[0] = 678;
			Bonding = 2;
			Block = 14;
			SellPrice = 5311;
			AvailableClasses = 0x7FFF;
			Model = 18699;
			ObjectClass = 4;
			SubClass = 6;
			Level = 36;
			ReqLevel = 31;
			Name = "Combat Shield";
			Name2 = "Combat Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 26558;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
			StrBonus = 7;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Insignia Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class InsigniaBuckler : Item
	{
		public InsigniaBuckler() : base()
		{
			Id = 4066;
			Resistance[0] = 661;
			Bonding = 2;
			Block = 14;
			SellPrice = 4845;
			AvailableClasses = 0x7FFF;
			Model = 4403;
			ObjectClass = 4;
			SubClass = 6;
			Level = 35;
			ReqLevel = 30;
			Name = "Insignia Buckler";
			Name2 = "Insignia Buckler";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 24227;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
			IqBonus = 7;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Glyphed Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class GlyphedBuckler : Item
	{
		public GlyphedBuckler() : base()
		{
			Id = 4067;
			Resistance[0] = 728;
			Bonding = 2;
			Block = 16;
			SellPrice = 6381;
			AvailableClasses = 0x7FFF;
			Model = 6272;
			ObjectClass = 4;
			SubClass = 6;
			Level = 39;
			ReqLevel = 34;
			Name = "Glyphed Buckler";
			Name2 = "Glyphed Buckler";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 31909;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
			IqBonus = 7;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Chief Brigadier Shield)
*
***************************************************************/

namespace Server.Items
{
	public class ChiefBrigadierShield : Item
	{
		public ChiefBrigadierShield() : base()
		{
			Id = 4068;
			Resistance[0] = 963;
			Bonding = 2;
			Block = 17;
			SellPrice = 6918;
			AvailableClasses = 0x7FFF;
			Model = 26325;
			ObjectClass = 4;
			SubClass = 6;
			Level = 40;
			ReqLevel = 35;
			Name = "Chief Brigadier Shield";
			Name2 = "Chief Brigadier Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 34592;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Blackforge Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class BlackforgeBuckler : Item
	{
		public BlackforgeBuckler() : base()
		{
			Id = 4069;
			Resistance[0] = 1465;
			Bonding = 2;
			Block = 22;
			SellPrice = 11900;
			AvailableClasses = 0x7FFF;
			Model = 26085;
			ObjectClass = 4;
			SubClass = 6;
			Level = 47;
			ReqLevel = 42;
			Name = "Blackforge Buckler";
			Name2 = "Blackforge Buckler";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 59503;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
			IqBonus = 10;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Jouster's Crest)
*
***************************************************************/

namespace Server.Items
{
	public class JoustersCrest : Item
	{
		public JoustersCrest() : base()
		{
			Id = 4070;
			Resistance[0] = 1101;
			Bonding = 2;
			Block = 17;
			SellPrice = 7527;
			AvailableClasses = 0x7FFF;
			Model = 18771;
			ObjectClass = 4;
			SubClass = 6;
			Level = 41;
			ReqLevel = 36;
			Name = "Jouster's Crest";
			Name2 = "Jouster's Crest";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 37638;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Grom'gol Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class GromgolBuckler : Item
	{
		public GromgolBuckler() : base()
		{
			Id = 4115;
			Resistance[0] = 695;
			Bonding = 1;
			Block = 15;
			SellPrice = 5783;
			AvailableClasses = 0x7FFF;
			Model = 17888;
			ObjectClass = 4;
			SubClass = 6;
			Level = 37;
			Name = "Grom'gol Buckler";
			Name2 = "Grom'gol Buckler";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 28915;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
			StrBonus = 2;
			StaminaBonus = 3;
			IqBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Collection Plate)
*
***************************************************************/

namespace Server.Items
{
	public class CollectionPlate : Item
	{
		public CollectionPlate() : base()
		{
			Id = 4129;
			Resistance[0] = 1380;
			Bonding = 1;
			Block = 20;
			SellPrice = 9444;
			AvailableClasses = 0x7FFF;
			Model = 4458;
			ObjectClass = 4;
			SubClass = 6;
			Level = 44;
			Name = "Collection Plate";
			Name2 = "Collection Plate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 47221;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
			StrBonus = 2;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Standard Issue Shield)
*
***************************************************************/

namespace Server.Items
{
	public class StandardIssueShield : Item
	{
		public StandardIssueShield() : base()
		{
			Id = 4263;
			Resistance[0] = 161;
			Block = 3;
			SellPrice = 94;
			AvailableClasses = 0x7FFF;
			Model = 18668;
			ObjectClass = 4;
			SubClass = 6;
			Level = 10;
			ReqLevel = 5;
			Name = "Standard Issue Shield";
			Name2 = "Standard Issue Shield";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 470;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Dust Bowl)
*
***************************************************************/

namespace Server.Items
{
	public class DustBowl : Item
	{
		public DustBowl() : base()
		{
			Id = 4290;
			Resistance[0] = 378;
			Bonding = 2;
			Block = 6;
			SellPrice = 715;
			AvailableClasses = 0x7FFF;
			Model = 4400;
			ObjectClass = 4;
			SubClass = 6;
			Level = 18;
			ReqLevel = 13;
			Name = "Dust Bowl";
			Name2 = "Dust Bowl";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3576;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 60;
			StrBonus = 2;
			IqBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Black Husk Shield)
*
***************************************************************/

namespace Server.Items
{
	public class BlackHuskShield : Item
	{
		public BlackHuskShield() : base()
		{
			Id = 4444;
			Resistance[0] = 478;
			Bonding = 2;
			Block = 9;
			SellPrice = 1490;
			AvailableClasses = 0x7FFF;
			Model = 18694;
			ObjectClass = 4;
			SubClass = 6;
			Level = 24;
			ReqLevel = 19;
			Name = "Black Husk Shield";
			Name2 = "Black Husk Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7450;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 75;
			SetSpell( 14253 , 0 , 5 , 0 , 28 , 300000 );
			IqBonus = 4;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Nefarious Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class NefariousBuckler : Item
	{
		public NefariousBuckler() : base()
		{
			Id = 4477;
			Resistance[0] = 645;
			Bonding = 2;
			Block = 13;
			SellPrice = 4390;
			AvailableClasses = 0x7FFF;
			Model = 17887;
			ObjectClass = 4;
			SubClass = 6;
			Level = 34;
			ReqLevel = 29;
			Name = "Nefarious Buckler";
			Name2 = "Nefarious Buckler";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 21953;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
			StaminaBonus = 6;
			StrBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Pit Fighter's Shield)
*
***************************************************************/

namespace Server.Items
{
	public class PitFightersShield : Item
	{
		public PitFightersShield() : base()
		{
			Id = 4507;
			Resistance[0] = 1148;
			Bonding = 1;
			Block = 18;
			SellPrice = 8282;
			AvailableClasses = 0x7FFF;
			Model = 18653;
			ObjectClass = 4;
			SubClass = 6;
			Level = 42;
			Name = "Pit Fighter's Shield";
			Name2 = "Pit Fighter's Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 41411;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
			StrBonus = 8;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Salbac Shield)
*
***************************************************************/

namespace Server.Items
{
	public class SalbacShield : Item
	{
		public SalbacShield() : base()
		{
			Id = 4652;
			Resistance[0] = 1408;
			Bonding = 1;
			Block = 20;
			SellPrice = 10126;
			AvailableClasses = 0x7FFF;
			Model = 18789;
			ObjectClass = 4;
			SubClass = 6;
			Level = 45;
			Name = "Salbac Shield";
			Name2 = "Salbac Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 50631;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
			StrBonus = 9;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Guardian Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class GuardianBuckler : Item
	{
		public GuardianBuckler() : base()
		{
			Id = 4820;
			Resistance[0] = 495;
			Bonding = 2;
			Block = 9;
			SellPrice = 1664;
			AvailableClasses = 0x7FFF;
			Model = 18511;
			ObjectClass = 4;
			SubClass = 6;
			Level = 25;
			ReqLevel = 20;
			Name = "Guardian Buckler";
			Name2 = "Guardian Buckler";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 8320;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 75;
			StaminaBonus = 3;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Bear Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class BearBuckler : Item
	{
		public BearBuckler() : base()
		{
			Id = 4821;
			Resistance[0] = 461;
			Bonding = 2;
			Block = 8;
			SellPrice = 1308;
			AvailableClasses = 0x7FFF;
			Model = 3445;
			ObjectClass = 4;
			SubClass = 6;
			Level = 23;
			ReqLevel = 18;
			Name = "Bear Buckler";
			Name2 = "Bear Buckler";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6541;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 70;
			StrBonus = 3;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Owl's Disk)
*
***************************************************************/

namespace Server.Items
{
	public class OwlsDisk : Item
	{
		public OwlsDisk() : base()
		{
			Id = 4822;
			Resistance[0] = 461;
			Bonding = 2;
			Block = 8;
			SellPrice = 1349;
			AvailableClasses = 0x7FFF;
			Model = 4983;
			ObjectClass = 4;
			SubClass = 6;
			Level = 23;
			ReqLevel = 18;
			Name = "Owl's Disk";
			Name2 = "Owl's Disk";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6746;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 70;
			SpiritBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Thick Bark Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class ThickBarkBuckler : Item
	{
		public ThickBarkBuckler() : base()
		{
			Id = 4911;
			Resistance[0] = 55;
			Bonding = 1;
			Block = 1;
			SellPrice = 15;
			AvailableClasses = 0x7FFF;
			Model = 18522;
			ObjectClass = 4;
			SubClass = 6;
			Level = 5;
			Name = "Thick Bark Buckler";
			Name2 = "Thick Bark Buckler";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 76;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Charging Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class ChargingBuckler : Item
	{
		public ChargingBuckler() : base()
		{
			Id = 4937;
			Resistance[0] = 135;
			Bonding = 1;
			Block = 3;
			SellPrice = 71;
			AvailableClasses = 0x7FFF;
			Model = 18510;
			ObjectClass = 4;
			SubClass = 6;
			Level = 9;
			Name = "Charging Buckler";
			Name2 = "Charging Buckler";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 356;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Tribal Warrior's Shield)
*
***************************************************************/

namespace Server.Items
{
	public class TribalWarriorsShield : Item
	{
		public TribalWarriorsShield() : base()
		{
			Id = 4967;
			Resistance[0] = 189;
			Bonding = 1;
			Block = 3;
			SellPrice = 116;
			AvailableClasses = 0x7FFF;
			Model = 5422;
			ObjectClass = 4;
			SubClass = 6;
			Level = 11;
			Name = "Tribal Warrior's Shield";
			Name2 = "Tribal Warrior's Shield";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 580;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Vigilant Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class VigilantBuckler : Item
	{
		public VigilantBuckler() : base()
		{
			Id = 4975;
			Resistance[0] = 728;
			Bonding = 1;
			Block = 16;
			SellPrice = 6477;
			AvailableClasses = 0x7FFF;
			Model = 18491;
			ObjectClass = 4;
			SubClass = 6;
			Level = 39;
			Name = "Vigilant Buckler";
			Name2 = "Vigilant Buckler";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 32389;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
			SetSpell( 13674 , 1 , 0 , 0 , 0 , -1 );
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Razormane War Shield)
*
***************************************************************/

namespace Server.Items
{
	public class RazormaneWarShield : Item
	{
		public RazormaneWarShield() : base()
		{
			Id = 5094;
			Resistance[0] = 444;
			Bonding = 1;
			Block = 8;
			SellPrice = 233;
			AvailableClasses = 0x7FFF;
			Model = 5808;
			ObjectClass = 4;
			SubClass = 6;
			Level = 24;
			ReqLevel = 19;
			Name = "Razormane War Shield";
			Name2 = "Razormane War Shield";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1168;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 75;
		}
	}
}


/**************************************************************
*
*				(Cobalt Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class CobaltBuckler : Item
	{
		public CobaltBuckler() : base()
		{
			Id = 5302;
			Resistance[0] = 411;
			Bonding = 1;
			Block = 7;
			SellPrice = 929;
			AvailableClasses = 0x7FFF;
			Model = 18451;
			ObjectClass = 4;
			SubClass = 6;
			Level = 20;
			Name = "Cobalt Buckler";
			Name2 = "Cobalt Buckler";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4647;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 65;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Welding Shield)
*
***************************************************************/

namespace Server.Items
{
	public class WeldingShield : Item
	{
		public WeldingShield() : base()
		{
			Id = 5325;
			Resistance[0] = 345;
			Bonding = 1;
			Block = 6;
			SellPrice = 498;
			AvailableClasses = 0x7FFF;
			Model = 7559;
			ObjectClass = 4;
			SubClass = 6;
			Level = 16;
			Name = "Welding Shield";
			Name2 = "Welding Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2493;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 55;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Ward of the Vale)
*
***************************************************************/

namespace Server.Items
{
	public class WardOfTheVale : Item
	{
		public WardOfTheVale() : base()
		{
			Id = 5357;
			Resistance[0] = 528;
			Bonding = 1;
			Block = 10;
			SellPrice = 2221;
			AvailableClasses = 0x7FFF;
			Model = 1685;
			ObjectClass = 4;
			SubClass = 6;
			Level = 27;
			Name = "Ward of the Vale";
			Name2 = "Ward of the Vale";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11107;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 80;
			SpiritBonus = 1;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Woodland Shield)
*
***************************************************************/

namespace Server.Items
{
	public class WoodlandShield : Item
	{
		public WoodlandShield() : base()
		{
			Id = 5395;
			Resistance[0] = 55;
			Bonding = 1;
			Block = 1;
			SellPrice = 16;
			AvailableClasses = 0x7FFF;
			Model = 18671;
			ObjectClass = 4;
			SubClass = 6;
			Level = 5;
			Name = "Woodland Shield";
			Name2 = "Woodland Shield";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 82;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Gold-plated Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class GoldPlatedBuckler : Item
	{
		public GoldPlatedBuckler() : base()
		{
			Id = 5443;
			Resistance[0] = 471;
			Bonding = 1;
			Block = 9;
			SellPrice = 1067;
			AvailableClasses = 0x7FFF;
			Model = 18523;
			ObjectClass = 4;
			SubClass = 6;
			Level = 20;
			ReqLevel = 15;
			Name = "Gold-plated Buckler";
			Name2 = "Gold-plated Buckler";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 5335;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 75;
			StaminaBonus = 5;
			AgilityBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Crag Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class CragBuckler : Item
	{
		public CragBuckler() : base()
		{
			Id = 5593;
			Resistance[0] = 189;
			Bonding = 1;
			Block = 3;
			SellPrice = 116;
			AvailableClasses = 0x7FFF;
			Model = 8296;
			ObjectClass = 4;
			SubClass = 6;
			Level = 11;
			Name = "Crag Buckler";
			Name2 = "Crag Buckler";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 582;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Bone Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class BoneBuckler : Item
	{
		public BoneBuckler() : base()
		{
			Id = 5940;
			Resistance[0] = 220;
			Bonding = 1;
			Block = 4;
			SellPrice = 153;
			AvailableClasses = 0x7FFF;
			Model = 2916;
			ObjectClass = 4;
			SubClass = 6;
			Level = 12;
			Name = "Bone Buckler";
			Name2 = "Bone Buckler";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 769;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Pikeman Shield)
*
***************************************************************/

namespace Server.Items
{
	public class PikemanShield : Item
	{
		public PikemanShield() : base()
		{
			Id = 6078;
			Resistance[0] = 55;
			Bonding = 1;
			Block = 1;
			SellPrice = 15;
			AvailableClasses = 0x7FFF;
			Model = 18664;
			ObjectClass = 4;
			SubClass = 6;
			Level = 5;
			Name = "Pikeman Shield";
			Name2 = "Pikeman Shield";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 78;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Dwarven Kite Shield)
*
***************************************************************/

namespace Server.Items
{
	public class DwarvenKiteShield : Item
	{
		public DwarvenKiteShield() : base()
		{
			Id = 6176;
			Resistance[0] = 55;
			Bonding = 1;
			Block = 1;
			SellPrice = 15;
			AvailableClasses = 0x7FFF;
			Model = 3725;
			ObjectClass = 4;
			SubClass = 6;
			Level = 5;
			Name = "Dwarven Kite Shield";
			Name2 = "Dwarven Kite Shield";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 79;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Dwarven Defender)
*
***************************************************************/

namespace Server.Items
{
	public class DwarvenDefender : Item
	{
		public DwarvenDefender() : base()
		{
			Id = 6187;
			Resistance[0] = 361;
			Bonding = 1;
			Block = 6;
			SellPrice = 613;
			AvailableClasses = 0x7FFF;
			Model = 18658;
			ObjectClass = 4;
			SubClass = 6;
			Level = 17;
			Name = "Dwarven Defender";
			Name2 = "Dwarven Defender";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3066;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 60;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Thuggish Shield)
*
***************************************************************/

namespace Server.Items
{
	public class ThuggishShield : Item
	{
		public ThuggishShield() : base()
		{
			Id = 6203;
			Resistance[0] = 189;
			Block = 3;
			SellPrice = 121;
			AvailableClasses = 0x7FFF;
			Model = 18669;
			ObjectClass = 4;
			SubClass = 6;
			Level = 11;
			ReqLevel = 6;
			Name = "Thuggish Shield";
			Name2 = "Thuggish Shield";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 608;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Crest of Darkshire)
*
***************************************************************/

namespace Server.Items
{
	public class CrestOfDarkshire : Item
	{
		public CrestOfDarkshire() : base()
		{
			Id = 6223;
			Resistance[0] = 661;
			Bonding = 1;
			Block = 14;
			SellPrice = 4797;
			AvailableClasses = 0x7FFF;
			Model = 10721;
			ObjectClass = 4;
			SubClass = 6;
			Level = 35;
			Name = "Crest of Darkshire";
			Name2 = "Crest of Darkshire";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 23986;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
			StrBonus = 2;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Commander's Crest)
*
***************************************************************/

namespace Server.Items
{
	public class CommandersCrest : Item
	{
		public CommandersCrest() : base()
		{
			Id = 6320;
			Resistance[0] = 623;
			Bonding = 1;
			Block = 13;
			SellPrice = 2711;
			AvailableClasses = 0x7FFF;
			Model = 18700;
			ObjectClass = 4;
			SubClass = 6;
			Level = 28;
			ReqLevel = 23;
			Name = "Commander's Crest";
			Name2 = "Commander's Crest";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 13556;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 95;
			IqBonus = 3;
			StaminaBonus = 3;
			StrBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Inscribed Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class InscribedBuckler : Item
	{
		public InscribedBuckler() : base()
		{
			Id = 6380;
			Resistance[0] = 378;
			Bonding = 2;
			Block = 6;
			SellPrice = 654;
			AvailableClasses = 0x7FFF;
			Model = 1673;
			ObjectClass = 4;
			SubClass = 6;
			Level = 18;
			ReqLevel = 13;
			Name = "Inscribed Buckler";
			Name2 = "Inscribed Buckler";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3271;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 60;
			SpiritBonus = 2;
			IqBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Forest Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class ForestBuckler : Item
	{
		public ForestBuckler() : base()
		{
			Id = 6383;
			Resistance[0] = 478;
			Bonding = 2;
			Block = 9;
			SellPrice = 1519;
			AvailableClasses = 0x7FFF;
			Model = 18483;
			ObjectClass = 4;
			SubClass = 6;
			Level = 24;
			ReqLevel = 19;
			Name = "Forest Buckler";
			Name2 = "Forest Buckler";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7596;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 75;
			SpiritBonus = 4;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Glimmering Shield)
*
***************************************************************/

namespace Server.Items
{
	public class GlimmeringShield : Item
	{
		public GlimmeringShield() : base()
		{
			Id = 6400;
			Resistance[0] = 595;
			Bonding = 2;
			Block = 12;
			SellPrice = 3089;
			AvailableClasses = 0x7FFF;
			Model = 11559;
			ObjectClass = 4;
			SubClass = 6;
			Level = 31;
			ReqLevel = 26;
			Name = "Glimmering Shield";
			Name2 = "Glimmering Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 15445;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
			StrBonus = 4;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Worn Turtle Shell Shield)
*
***************************************************************/

namespace Server.Items
{
	public class WornTurtleShellShield : Item
	{
		public WornTurtleShellShield() : base()
		{
			Id = 6447;
			Resistance[0] = 412;
			Block = 6;
			SellPrice = 562;
			AvailableClasses = 0x7FFF;
			Model = 22805;
			ObjectClass = 4;
			SubClass = 6;
			Level = 20;
			ReqLevel = 15;
			Name = "Worn Turtle Shell Shield";
			Name2 = "Worn Turtle Shell Shield";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2810;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Bard's Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class BardsBuckler : Item
	{
		public BardsBuckler() : base()
		{
			Id = 6559;
			Resistance[0] = 345;
			Bonding = 2;
			Block = 6;
			SellPrice = 533;
			AvailableClasses = 0x7FFF;
			Model = 2210;
			ObjectClass = 4;
			SubClass = 6;
			Level = 16;
			ReqLevel = 11;
			Name = "Bard's Buckler";
			Name2 = "Bard's Buckler";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1998;
			BuyPrice = 2668;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Soldier's Shield)
*
***************************************************************/

namespace Server.Items
{
	public class SoldiersShield : Item
	{
		public SoldiersShield() : base()
		{
			Id = 6560;
			Resistance[0] = 361;
			Bonding = 2;
			Block = 6;
			SellPrice = 615;
			AvailableClasses = 0x7FFF;
			Model = 25955;
			ObjectClass = 4;
			SubClass = 6;
			Level = 17;
			ReqLevel = 12;
			Name = "Soldier's Shield";
			Name2 = "Soldier's Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1998;
			BuyPrice = 3079;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Scouting Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class ScoutingBuckler : Item
	{
		public ScoutingBuckler() : base()
		{
			Id = 6571;
			Resistance[0] = 445;
			Bonding = 2;
			Block = 8;
			SellPrice = 1166;
			AvailableClasses = 0x7FFF;
			Model = 18493;
			ObjectClass = 4;
			SubClass = 6;
			Level = 22;
			ReqLevel = 17;
			Name = "Scouting Buckler";
			Name2 = "Scouting Buckler";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2010;
			BuyPrice = 5834;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Defender Shield)
*
***************************************************************/

namespace Server.Items
{
	public class DefenderShield : Item
	{
		public DefenderShield() : base()
		{
			Id = 6572;
			Resistance[0] = 461;
			Bonding = 2;
			Block = 8;
			SellPrice = 1323;
			AvailableClasses = 0x7FFF;
			Model = 18701;
			ObjectClass = 4;
			SubClass = 6;
			Level = 23;
			ReqLevel = 18;
			Name = "Defender Shield";
			Name2 = "Defender Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2010;
			BuyPrice = 6618;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Dervish Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class DervishBuckler : Item
	{
		public DervishBuckler() : base()
		{
			Id = 6598;
			Resistance[0] = 545;
			Bonding = 2;
			Block = 10;
			SellPrice = 2426;
			AvailableClasses = 0x7FFF;
			Model = 18449;
			ObjectClass = 4;
			SubClass = 6;
			Level = 28;
			ReqLevel = 23;
			Name = "Dervish Buckler";
			Name2 = "Dervish Buckler";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2022;
			BuyPrice = 12131;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 80;
		}
	}
}


/**************************************************************
*
*				(Battleforge Shield)
*
***************************************************************/

namespace Server.Items
{
	public class BattleforgeShield : Item
	{
		public BattleforgeShield() : base()
		{
			Id = 6599;
			Resistance[0] = 561;
			Bonding = 2;
			Block = 11;
			SellPrice = 2678;
			AvailableClasses = 0x7FFF;
			Model = 26014;
			ObjectClass = 4;
			SubClass = 6;
			Level = 29;
			ReqLevel = 24;
			Name = "Battleforge Shield";
			Name2 = "Battleforge Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2022;
			BuyPrice = 13393;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Seedcloud Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class SeedcloudBuckler : Item
	{
		public SeedcloudBuckler() : base()
		{
			Id = 6630;
			Resistance[0] = 566;
			Bonding = 1;
			Block = 11;
			SellPrice = 2067;
			AvailableClasses = 0x7FFF;
			Model = 6274;
			ObjectClass = 4;
			SubClass = 6;
			Level = 25;
			ReqLevel = 20;
			Name = "Seedcloud Buckler";
			Name2 = "Seedcloud Buckler";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 10337;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 90;
			IqBonus = 3;
			SpiritBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Constable Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class ConstableBuckler : Item
	{
		public ConstableBuckler() : base()
		{
			Id = 6676;
			Resistance[0] = 528;
			Bonding = 1;
			Block = 10;
			SellPrice = 2245;
			AvailableClasses = 0x7FFF;
			Model = 12805;
			ObjectClass = 4;
			SubClass = 6;
			Level = 27;
			Name = "Constable Buckler";
			Name2 = "Constable Buckler";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11229;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 80;
			StaminaBonus = 4;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Heart of Agamaggan)
*
***************************************************************/

namespace Server.Items
{
	public class HeartOfAgamaggan : Item
	{
		public HeartOfAgamaggan() : base()
		{
			Id = 6694;
			Resistance[0] = 776;
			Bonding = 1;
			Block = 17;
			SellPrice = 6309;
			AvailableClasses = 0x7FFF;
			Model = 18454;
			ObjectClass = 4;
			SubClass = 6;
			Level = 36;
			ReqLevel = 31;
			Name = "Heart of Agamaggan";
			Name2 = "Heart of Agamaggan";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 31546;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 100;
			IqBonus = 8;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Marbled Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class MarbledBuckler : Item
	{
		public MarbledBuckler() : base()
		{
			Id = 6725;
			Resistance[0] = 775;
			Bonding = 1;
			Block = 17;
			SellPrice = 6105;
			AvailableClasses = 0x7FFF;
			Model = 18469;
			ObjectClass = 4;
			SubClass = 6;
			Level = 36;
			Name = "Marbled Buckler";
			Name2 = "Marbled Buckler";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 30528;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 100;
			AgilityBonus = 5;
			StrBonus = 5;
			IqBonus = 5;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Basalt Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class BasaltBuckler : Item
	{
		public BasaltBuckler() : base()
		{
			Id = 6746;
			Resistance[0] = 963;
			Bonding = 1;
			Block = 17;
			SellPrice = 7075;
			AvailableClasses = 0x7FFF;
			Model = 18507;
			ObjectClass = 4;
			SubClass = 6;
			Level = 40;
			Name = "Basalt Buckler";
			Name2 = "Basalt Buckler";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 35379;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
			StaminaBonus = 2;
			SpiritBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Visionary Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class VisionaryBuckler : Item
	{
		public VisionaryBuckler() : base()
		{
			Id = 6828;
			Resistance[0] = 711;
			Bonding = 1;
			Block = 15;
			SellPrice = 6268;
			AvailableClasses = 0x7FFF;
			Model = 18476;
			ObjectClass = 4;
			SubClass = 6;
			Level = 38;
			Name = "Visionary Buckler";
			Name2 = "Visionary Buckler";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 31340;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
			StaminaBonus = 4;
			IqBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Furen's Favor)
*
***************************************************************/

namespace Server.Items
{
	public class FurensFavor : Item
	{
		public FurensFavor() : base()
		{
			Id = 6970;
			Resistance[0] = 411;
			Bonding = 1;
			Block = 7;
			SellPrice = 906;
			AvailableClasses = 0x01;
			Model = 21475;
			ObjectClass = 4;
			SubClass = 6;
			Level = 20;
			Name = "Furen's Favor";
			Name2 = "Furen's Favor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4531;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 65;
			StrBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Arctic Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class ArcticBuckler : Item
	{
		public ArcticBuckler() : base()
		{
			Id = 7002;
			Resistance[0] = 642;
			Bonding = 1;
			Block = 13;
			SellPrice = 3028;
			AvailableClasses = 0x7FFF;
			Model = 4743;
			Resistance[4] = 5;
			ObjectClass = 4;
			SubClass = 6;
			Level = 29;
			Name = "Arctic Buckler";
			Name2 = "Arctic Buckler";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 15141;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 100;
			IqBonus = 8;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Infantry Shield)
*
***************************************************************/

namespace Server.Items
{
	public class InfantryShield : Item
	{
		public InfantryShield() : base()
		{
			Id = 7108;
			Resistance[0] = 207;
			Bonding = 2;
			Block = 4;
			SellPrice = 209;
			AvailableClasses = 0x7FFF;
			Model = 18661;
			ObjectClass = 4;
			SubClass = 6;
			Level = 11;
			ReqLevel = 6;
			Name = "Infantry Shield";
			Name2 = "Infantry Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 6278;
			BuyPrice = 1046;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Pioneer Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class PioneerBuckler : Item
	{
		public PioneerBuckler() : base()
		{
			Id = 7109;
			Resistance[0] = 135;
			Block = 3;
			SellPrice = 74;
			AvailableClasses = 0x7FFF;
			Model = 18508;
			ObjectClass = 4;
			SubClass = 6;
			Level = 9;
			ReqLevel = 4;
			Name = "Pioneer Buckler";
			Name2 = "Pioneer Buckler";
			Quality = 1;
			AvailableRaces = 0x1FF;
			Extra = -1;
			BuyPrice = 372;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Ruga's Bulwark)
*
***************************************************************/

namespace Server.Items
{
	public class RugasBulwark : Item
	{
		public RugasBulwark() : base()
		{
			Id = 7120;
			Resistance[0] = 411;
			Bonding = 1;
			Block = 7;
			SellPrice = 895;
			AvailableClasses = 0x01;
			Model = 22730;
			ObjectClass = 4;
			SubClass = 6;
			Level = 20;
			Name = "Ruga's Bulwark";
			Name2 = "Ruga's Bulwark";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4479;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 65;
			StrBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Stormwind Guard Shield)
*
***************************************************************/

namespace Server.Items
{
	public class StormwindGuardShield : Item
	{
		public StormwindGuardShield() : base()
		{
			Id = 7188;
			Resistance[0] = 110;
			SellPrice = 1485;
			AvailableClasses = 0x7FFF;
			Model = 13863;
			ObjectClass = 4;
			SubClass = 6;
			Level = 24;
			ReqLevel = 19;
			Name = "Stormwind Guard Shield";
			Name2 = "Stormwind Guard Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7426;
			Resistance[5] = 1;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Infiltrator Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class InfiltratorBuckler : Item
	{
		public InfiltratorBuckler() : base()
		{
			Id = 7330;
			Resistance[0] = 628;
			Bonding = 2;
			Block = 13;
			SellPrice = 3923;
			AvailableClasses = 0x7FFF;
			Model = 2632;
			ObjectClass = 4;
			SubClass = 6;
			Level = 33;
			ReqLevel = 28;
			Name = "Infiltrator Buckler";
			Name2 = "Infiltrator Buckler";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2028;
			BuyPrice = 19615;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Phalanx Shield)
*
***************************************************************/

namespace Server.Items
{
	public class PhalanxShield : Item
	{
		public PhalanxShield() : base()
		{
			Id = 7331;
			Resistance[0] = 645;
			Bonding = 2;
			Block = 13;
			SellPrice = 4330;
			AvailableClasses = 0x7FFF;
			Model = 26046;
			ObjectClass = 4;
			SubClass = 6;
			Level = 34;
			ReqLevel = 29;
			Name = "Phalanx Shield";
			Name2 = "Phalanx Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2034;
			BuyPrice = 21654;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Sentinel Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class SentinelBuckler : Item
	{
		public SentinelBuckler() : base()
		{
			Id = 7463;
			Resistance[0] = 711;
			Bonding = 2;
			Block = 15;
			SellPrice = 6202;
			AvailableClasses = 0x7FFF;
			Model = 4403;
			ObjectClass = 4;
			SubClass = 6;
			Level = 38;
			ReqLevel = 33;
			Name = "Sentinel Buckler";
			Name2 = "Sentinel Buckler";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2040;
			BuyPrice = 31013;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Knight's Crest)
*
***************************************************************/

namespace Server.Items
{
	public class KnightsCrest : Item
	{
		public KnightsCrest() : base()
		{
			Id = 7465;
			Resistance[0] = 728;
			Bonding = 2;
			Block = 16;
			SellPrice = 6747;
			AvailableClasses = 0x7FFF;
			Model = 26065;
			ObjectClass = 4;
			SubClass = 6;
			Level = 39;
			ReqLevel = 34;
			Name = "Knight's Crest";
			Name2 = "Knight's Crest";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2040;
			BuyPrice = 33735;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Captain's Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class CaptainsBuckler : Item
	{
		public CaptainsBuckler() : base()
		{
			Id = 7495;
			Resistance[0] = 1380;
			Bonding = 2;
			Block = 20;
			SellPrice = 9558;
			AvailableClasses = 0x7FFF;
			Model = 18451;
			ObjectClass = 4;
			SubClass = 6;
			Level = 44;
			ReqLevel = 39;
			Name = "Captain's Buckler";
			Name2 = "Captain's Buckler";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2052;
			BuyPrice = 47792;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Field Plate Shield)
*
***************************************************************/

namespace Server.Items
{
	public class FieldPlateShield : Item
	{
		public FieldPlateShield() : base()
		{
			Id = 7496;
			Resistance[0] = 1257;
			Bonding = 2;
			Block = 19;
			SellPrice = 8882;
			AvailableClasses = 0x7FFF;
			Model = 18697;
			ObjectClass = 4;
			SubClass = 6;
			Level = 43;
			ReqLevel = 38;
			Name = "Field Plate Shield";
			Name2 = "Field Plate Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2052;
			BuyPrice = 44412;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Champion's Wall Shield)
*
***************************************************************/

namespace Server.Items
{
	public class ChampionsWallShield : Item
	{
		public ChampionsWallShield() : base()
		{
			Id = 7536;
			Resistance[0] = 1493;
			Bonding = 2;
			Block = 23;
			SellPrice = 13048;
			AvailableClasses = 0x7FFF;
			Model = 26099;
			ObjectClass = 4;
			SubClass = 6;
			Level = 48;
			ReqLevel = 43;
			Name = "Champion's Wall Shield";
			Name2 = "Champion's Wall Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2058;
			BuyPrice = 65244;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Gothic Shield)
*
***************************************************************/

namespace Server.Items
{
	public class GothicShield : Item
	{
		public GothicShield() : base()
		{
			Id = 7537;
			Resistance[0] = 1521;
			Bonding = 2;
			Block = 23;
			SellPrice = 14012;
			AvailableClasses = 0x7FFF;
			Model = 18775;
			ObjectClass = 4;
			SubClass = 6;
			Level = 49;
			ReqLevel = 44;
			Name = "Gothic Shield";
			Name2 = "Gothic Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2064;
			BuyPrice = 70062;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Aegis of the Scarlet Commander)
*
***************************************************************/

namespace Server.Items
{
	public class AegisOfTheScarletCommander : Item
	{
		public AegisOfTheScarletCommander() : base()
		{
			Id = 7726;
			Resistance[0] = 1548;
			Bonding = 1;
			Block = 23;
			SellPrice = 11681;
			AvailableClasses = 0x7FFF;
			Model = 18751;
			ObjectClass = 4;
			SubClass = 6;
			Level = 44;
			ReqLevel = 39;
			Name = "Aegis of the Scarlet Commander";
			Name2 = "Aegis of the Scarlet Commander";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 58406;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 100;
			IqBonus = 7;
			StaminaBonus = 8;
			StrBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Vile Protector)
*
***************************************************************/

namespace Server.Items
{
	public class VileProtector : Item
	{
		public VileProtector() : base()
		{
			Id = 7747;
			Resistance[0] = 1051;
			Bonding = 1;
			Block = 17;
			SellPrice = 7754;
			AvailableClasses = 0x7FFF;
			Model = 18792;
			ObjectClass = 4;
			SubClass = 6;
			Level = 41;
			Name = "Vile Protector";
			Name2 = "Vile Protector";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 38774;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
			SetSpell( 7619 , 1 , 0 , -1 , 0 , -1 );
			StrBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Forcestone Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class ForcestoneBuckler : Item
	{
		public ForcestoneBuckler() : base()
		{
			Id = 7748;
			Resistance[0] = 1408;
			Bonding = 1;
			Block = 20;
			SellPrice = 10862;
			AvailableClasses = 0x7FFF;
			Model = 4405;
			ObjectClass = 4;
			SubClass = 6;
			Level = 45;
			Name = "Forcestone Buckler";
			Name2 = "Forcestone Buckler";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 54312;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
			Flags = 16;
			StaminaBonus = 3;
			IqBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Resplendent Guardian)
*
***************************************************************/

namespace Server.Items
{
	public class ResplendentGuardian : Item
	{
		public ResplendentGuardian() : base()
		{
			Id = 7787;
			Resistance[0] = 680;
			Bonding = 2;
			Block = 14;
			SellPrice = 3960;
			AvailableClasses = 0x7FFF;
			Model = 18455;
			ObjectClass = 4;
			SubClass = 6;
			Level = 31;
			ReqLevel = 26;
			Name = "Resplendent Guardian";
			Name2 = "Resplendent Guardian";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 19802;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 100;
			SetSpell( 13674 , 1 , 0 , 90000 , 0 , -1 );
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Myrmidon's Defender)
*
***************************************************************/

namespace Server.Items
{
	public class MyrmidonsDefender : Item
	{
		public MyrmidonsDefender() : base()
		{
			Id = 8134;
			Resistance[0] = 1578;
			Bonding = 2;
			Block = 25;
			SellPrice = 15993;
			AvailableClasses = 0x7FFF;
			Model = 26120;
			ObjectClass = 4;
			SubClass = 6;
			Level = 51;
			ReqLevel = 46;
			Name = "Myrmidon's Defender";
			Name2 = "Myrmidon's Defender";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 79966;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
			StaminaBonus = 2;
			AgilityBonus = 2;
			IqBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Chromite Shield)
*
***************************************************************/

namespace Server.Items
{
	public class ChromiteShield : Item
	{
		public ChromiteShield() : base()
		{
			Id = 8135;
			Resistance[0] = 1436;
			Bonding = 2;
			Block = 21;
			SellPrice = 11234;
			AvailableClasses = 0x7FFF;
			Model = 27339;
			ObjectClass = 4;
			SubClass = 6;
			Level = 46;
			ReqLevel = 41;
			Name = "Chromite Shield";
			Name2 = "Chromite Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 56171;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
			StrBonus = 3;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Ebonhold Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class EbonholdBuckler : Item
	{
		public EbonholdBuckler() : base()
		{
			Id = 8275;
			Resistance[0] = 1720;
			Bonding = 2;
			Block = 30;
			SellPrice = 22028;
			AvailableClasses = 0x7FFF;
			Model = 26232;
			ObjectClass = 4;
			SubClass = 6;
			Level = 56;
			ReqLevel = 51;
			Name = "Ebonhold Buckler";
			Name2 = "Ebonhold Buckler";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 110140;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
			StaminaBonus = 4;
			IqBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Valorous Shield)
*
***************************************************************/

namespace Server.Items
{
	public class ValorousShield : Item
	{
		public ValorousShield() : base()
		{
			Id = 8282;
			Resistance[0] = 1578;
			Bonding = 2;
			Block = 25;
			SellPrice = 15695;
			AvailableClasses = 0x7FFF;
			Model = 18790;
			ObjectClass = 4;
			SubClass = 6;
			Level = 51;
			ReqLevel = 46;
			Name = "Valorous Shield";
			Name2 = "Valorous Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 78478;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
			StrBonus = 6;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Hero's Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class HerosBuckler : Item
	{
		public HerosBuckler() : base()
		{
			Id = 8313;
			Resistance[0] = 1890;
			Bonding = 2;
			Block = 36;
			SellPrice = 30637;
			AvailableClasses = 0x7FFF;
			Model = 26324;
			ObjectClass = 4;
			SubClass = 6;
			Level = 62;
			ReqLevel = 57;
			Name = "Hero's Buckler";
			Name2 = "Hero's Buckler";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 153187;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
			StrBonus = 7;
			SpiritBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Alabaster Shield)
*
***************************************************************/

namespace Server.Items
{
	public class AlabasterShield : Item
	{
		public AlabasterShield() : base()
		{
			Id = 8320;
			Resistance[0] = 1748;
			Bonding = 2;
			Block = 31;
			SellPrice = 22092;
			AvailableClasses = 0x7FFF;
			Model = 27571;
			ObjectClass = 4;
			SubClass = 6;
			Level = 57;
			ReqLevel = 52;
			Name = "Alabaster Shield";
			Name2 = "Alabaster Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 110461;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
			StrBonus = 3;
			StaminaBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Battered Viking Shield)
*
***************************************************************/

namespace Server.Items
{
	public class BatteredVikingShield : Item
	{
		public BatteredVikingShield() : base()
		{
			Id = 9403;
			Resistance[0] = 907;
			Block = 15;
			SellPrice = 4436;
			AvailableClasses = 0x7FFF;
			Model = 18824;
			ObjectClass = 4;
			SubClass = 6;
			Level = 40;
			ReqLevel = 35;
			Name = "Battered Viking Shield";
			Name2 = "Battered Viking Shield";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 22184;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
			StaminaBonus = 8;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Olaf's All Purpose Shield)
*
***************************************************************/

namespace Server.Items
{
	public class OlafsAllPurposeShield : Item
	{
		public OlafsAllPurposeShield() : base()
		{
			Id = 9404;
			Resistance[0] = 1287;
			Bonding = 1;
			Block = 22;
			SellPrice = 9398;
			AvailableClasses = 0x7FFF;
			Model = 18826;
			ObjectClass = 4;
			SubClass = 6;
			Level = 42;
			ReqLevel = 37;
			Name = "Olaf's All Purpose Shield";
			Name2 = "Olaf's All Purpose Shield";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 46991;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 100;
			SetSpell( 12438 , 0 , 0 , 3600000 , 28 , 300000 );
			StaminaBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Techbot CPU Shell)
*
***************************************************************/

namespace Server.Items
{
	public class TechbotCPUShell : Item
	{
		public TechbotCPUShell() : base()
		{
			Id = 9444;
			Resistance[0] = 475;
			Block = 9;
			SellPrice = 1120;
			AvailableClasses = 0x7FFF;
			Model = 8296;
			ObjectClass = 4;
			SubClass = 6;
			Level = 26;
			ReqLevel = 21;
			Name = "Techbot CPU Shell";
			Name2 = "Techbot CPU Shell";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 5602;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 80;
		}
	}
}


/**************************************************************
*
*				(Thermaplugg's Central Core)
*
***************************************************************/

namespace Server.Items
{
	public class ThermapluggsCentralCore : Item
	{
		public ThermapluggsCentralCore() : base()
		{
			Id = 9458;
			Resistance[0] = 795;
			Bonding = 1;
			Block = 18;
			SellPrice = 6917;
			AvailableClasses = 0x7FFF;
			Model = 18374;
			ObjectClass = 4;
			SubClass = 6;
			Level = 37;
			ReqLevel = 32;
			Name = "Thermaplugg's Central Core";
			Name2 = "Thermaplugg's Central Core";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 34589;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 100;
			SetSpell( 13959 , 1 , 0 , 0 , 0 , -1 );
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Energized Stone Circle)
*
***************************************************************/

namespace Server.Items
{
	public class EnergizedStoneCircle : Item
	{
		public EnergizedStoneCircle() : base()
		{
			Id = 9522;
			Resistance[0] = 678;
			Bonding = 1;
			Block = 14;
			SellPrice = 4938;
			AvailableClasses = 0x7FFF;
			Model = 18447;
			ObjectClass = 4;
			SubClass = 6;
			Level = 36;
			Name = "Energized Stone Circle";
			Name2 = "Energized Stone Circle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 24694;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
			StaminaBonus = 2;
			IqBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Bastion of Stormwind)
*
***************************************************************/

namespace Server.Items
{
	public class BastionOfStormwind : Item
	{
		public BastionOfStormwind() : base()
		{
			Id = 9607;
			Resistance[0] = 495;
			Bonding = 1;
			Block = 9;
			SellPrice = 1762;
			AvailableClasses = 0x02;
			Model = 18533;
			ObjectClass = 4;
			SubClass = 6;
			Level = 25;
			Name = "Bastion of Stormwind";
			Name2 = "Bastion of Stormwind";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 8810;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 75;
			SetSpell( 7516 , 1 , 0 , 0 , 0 , 0 );
		}
	}
}


/**************************************************************
*
*				(Optomatic Deflector)
*
***************************************************************/

namespace Server.Items
{
	public class OptomaticDeflector : Item
	{
		public OptomaticDeflector() : base()
		{
			Id = 9643;
			Resistance[0] = 1578;
			Bonding = 1;
			Block = 25;
			SellPrice = 15988;
			AvailableClasses = 0x7FFF;
			Model = 18822;
			ObjectClass = 4;
			SubClass = 6;
			Level = 51;
			Name = "Optomatic Deflector";
			Name2 = "Optomatic Deflector";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 79942;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
			SetSpell( 13675 , 1 , 0 , 90000 , 0 , -1 );
			StrBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Earthclasp Barrier)
*
***************************************************************/

namespace Server.Items
{
	public class EarthclaspBarrier : Item
	{
		public EarthclaspBarrier() : base()
		{
			Id = 9661;
			Resistance[0] = 1257;
			Bonding = 1;
			Block = 19;
			SellPrice = 9051;
			AvailableClasses = 0x7FFF;
			Model = 20900;
			ObjectClass = 4;
			SubClass = 6;
			Level = 43;
			Name = "Earthclasp Barrier";
			Name2 = "Earthclasp Barrier";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 45257;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
			StaminaBonus = 1;
			IqBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Tharg's Disk)
*
***************************************************************/

namespace Server.Items
{
	public class ThargsDisk : Item
	{
		public ThargsDisk() : base()
		{
			Id = 9706;
			Resistance[0] = 1257;
			Bonding = 1;
			Block = 19;
			SellPrice = 9212;
			AvailableClasses = 0x7FFF;
			Model = 20975;
			ObjectClass = 4;
			SubClass = 6;
			Level = 43;
			Name = "Tharg's Disk";
			Name2 = "Tharg's Disk";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 46062;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Gypsy Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class GypsyBuckler : Item
	{
		public GypsyBuckler() : base()
		{
			Id = 9753;
			Resistance[0] = 239;
			Bonding = 2;
			Block = 4;
			SellPrice = 248;
			AvailableClasses = 0x7FFF;
			Model = 18469;
			ObjectClass = 4;
			SubClass = 6;
			Level = 12;
			ReqLevel = 7;
			Name = "Gypsy Buckler";
			Name2 = "Gypsy Buckler";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 6278;
			BuyPrice = 1242;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Cadet Shield)
*
***************************************************************/

namespace Server.Items
{
	public class CadetShield : Item
	{
		public CadetShield() : base()
		{
			Id = 9764;
			Resistance[0] = 274;
			Bonding = 2;
			Block = 5;
			SellPrice = 300;
			AvailableClasses = 0x7FFF;
			Model = 18823;
			ObjectClass = 4;
			SubClass = 6;
			Level = 13;
			ReqLevel = 8;
			Name = "Cadet Shield";
			Name2 = "Cadet Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 6279;
			BuyPrice = 1501;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Bandit Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class BanditBuckler : Item
	{
		public BanditBuckler() : base()
		{
			Id = 9778;
			Resistance[0] = 411;
			Bonding = 2;
			Block = 7;
			SellPrice = 940;
			AvailableClasses = 0x7FFF;
			Model = 20826;
			ObjectClass = 4;
			SubClass = 6;
			Level = 20;
			ReqLevel = 15;
			Name = "Bandit Buckler";
			Name2 = "Bandit Buckler";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2004;
			BuyPrice = 4702;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Raider's Shield)
*
***************************************************************/

namespace Server.Items
{
	public class RaidersShield : Item
	{
		public RaidersShield() : base()
		{
			Id = 9790;
			Resistance[0] = 395;
			Bonding = 2;
			Block = 7;
			SellPrice = 794;
			AvailableClasses = 0x7FFF;
			Model = 18657;
			ObjectClass = 4;
			SubClass = 6;
			Level = 19;
			ReqLevel = 14;
			Name = "Raider's Shield";
			Name2 = "Raider's Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2004;
			BuyPrice = 3972;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Superior Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class SuperiorBuckler : Item
	{
		public SuperiorBuckler() : base()
		{
			Id = 9804;
			Resistance[0] = 511;
			Bonding = 2;
			Block = 9;
			SellPrice = 1874;
			AvailableClasses = 0x7FFF;
			Model = 1685;
			ObjectClass = 4;
			SubClass = 6;
			Level = 26;
			ReqLevel = 21;
			Name = "Superior Buckler";
			Name2 = "Superior Buckler";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2016;
			BuyPrice = 9372;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 80;
		}
	}
}


/**************************************************************
*
*				(Fortified Shield)
*
***************************************************************/

namespace Server.Items
{
	public class FortifiedShield : Item
	{
		public FortifiedShield() : base()
		{
			Id = 9816;
			Resistance[0] = 495;
			Bonding = 2;
			Block = 9;
			SellPrice = 1781;
			AvailableClasses = 0x7FFF;
			Model = 26121;
			ObjectClass = 4;
			SubClass = 6;
			Level = 25;
			ReqLevel = 20;
			Name = "Fortified Shield";
			Name2 = "Fortified Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2016;
			BuyPrice = 8906;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 75;
		}
	}
}


/**************************************************************
*
*				(Scaled Shield)
*
***************************************************************/

namespace Server.Items
{
	public class ScaledShield : Item
	{
		public ScaledShield() : base()
		{
			Id = 9830;
			Resistance[0] = 611;
			Bonding = 2;
			Block = 12;
			SellPrice = 3489;
			AvailableClasses = 0x7FFF;
			Model = 6274;
			ObjectClass = 4;
			SubClass = 6;
			Level = 32;
			ReqLevel = 27;
			Name = "Scaled Shield";
			Name2 = "Scaled Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2026;
			BuyPrice = 17445;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Banded Shield)
*
***************************************************************/

namespace Server.Items
{
	public class BandedShield : Item
	{
		public BandedShield() : base()
		{
			Id = 9843;
			Resistance[0] = 628;
			Bonding = 2;
			Block = 13;
			SellPrice = 3739;
			AvailableClasses = 0x7FFF;
			Model = 26060;
			ObjectClass = 4;
			SubClass = 6;
			Level = 33;
			ReqLevel = 28;
			Name = "Banded Shield";
			Name2 = "Banded Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2028;
			BuyPrice = 18696;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Archer's Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class ArchersBuckler : Item
	{
		public ArchersBuckler() : base()
		{
			Id = 9858;
			Resistance[0] = 678;
			Bonding = 2;
			Block = 14;
			SellPrice = 4882;
			AvailableClasses = 0x7FFF;
			Model = 18488;
			ObjectClass = 4;
			SubClass = 6;
			Level = 36;
			ReqLevel = 31;
			Name = "Archer's Buckler";
			Name2 = "Archer's Buckler";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2034;
			BuyPrice = 24414;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Renegade Shield)
*
***************************************************************/

namespace Server.Items
{
	public class RenegadeShield : Item
	{
		public RenegadeShield() : base()
		{
			Id = 9873;
			Resistance[0] = 695;
			Bonding = 2;
			Block = 15;
			SellPrice = 5828;
			AvailableClasses = 0x7FFF;
			Model = 25988;
			ObjectClass = 4;
			SubClass = 6;
			Level = 37;
			ReqLevel = 32;
			Name = "Renegade Shield";
			Name2 = "Renegade Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2040;
			BuyPrice = 29141;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Elven Protector)
*
***************************************************************/

namespace Server.Items
{
	public class ElvenProtector : Item
	{
		public ElvenProtector() : base()
		{
			Id = 9888;
			Resistance[0] = 630;
			Bonding = 2;
			SellPrice = 8411;
			AvailableClasses = 0x7FFF;
			Model = 20873;
			ObjectClass = 4;
			SubClass = 6;
			Level = 42;
			ReqLevel = 37;
			Name = "Elven Protector";
			Name2 = "Elven Protector";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2044;
			BuyPrice = 42057;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
		}
	}
}


/**************************************************************
*
*				(Jazeraint Shield)
*
***************************************************************/

namespace Server.Items
{
	public class JazeraintShield : Item
	{
		public JazeraintShield() : base()
		{
			Id = 9899;
			Resistance[0] = 1148;
			Bonding = 2;
			Block = 18;
			SellPrice = 7920;
			AvailableClasses = 0x7FFF;
			Model = 25911;
			ObjectClass = 4;
			SubClass = 6;
			Level = 42;
			ReqLevel = 37;
			Name = "Jazeraint Shield";
			Name2 = "Jazeraint Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2046;
			BuyPrice = 39600;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Brigade Defender)
*
***************************************************************/

namespace Server.Items
{
	public class BrigadeDefender : Item
	{
		public BrigadeDefender() : base()
		{
			Id = 9918;
			Resistance[0] = 1408;
			Bonding = 2;
			Block = 20;
			SellPrice = 10212;
			AvailableClasses = 0x7FFF;
			Model = 25940;
			ObjectClass = 4;
			SubClass = 6;
			Level = 45;
			ReqLevel = 40;
			Name = "Brigade Defender";
			Name2 = "Brigade Defender";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2052;
			BuyPrice = 51061;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Embossed Plate Shield)
*
***************************************************************/

namespace Server.Items
{
	public class EmbossedPlateShield : Item
	{
		public EmbossedPlateShield() : base()
		{
			Id = 9935;
			Resistance[0] = 1408;
			Bonding = 2;
			Block = 20;
			SellPrice = 10097;
			AvailableClasses = 0x7FFF;
			Model = 18819;
			ObjectClass = 4;
			SubClass = 6;
			Level = 45;
			ReqLevel = 40;
			Name = "Embossed Plate Shield";
			Name2 = "Embossed Plate Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2052;
			BuyPrice = 50486;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Warmonger's Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class WarmongersBuckler : Item
	{
		public WarmongersBuckler() : base()
		{
			Id = 9958;
			Resistance[0] = 1550;
			Bonding = 2;
			Block = 24;
			SellPrice = 14724;
			AvailableClasses = 0x7FFF;
			Model = 26234;
			ObjectClass = 4;
			SubClass = 6;
			Level = 50;
			ReqLevel = 45;
			Name = "Warmonger's Buckler";
			Name2 = "Warmonger's Buckler";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2064;
			BuyPrice = 73620;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Overlord's Shield)
*
***************************************************************/

namespace Server.Items
{
	public class OverlordsShield : Item
	{
		public OverlordsShield() : base()
		{
			Id = 9974;
			Resistance[0] = 1606;
			Bonding = 2;
			Block = 26;
			SellPrice = 16449;
			AvailableClasses = 0x7FFF;
			Model = 18815;
			ObjectClass = 4;
			SubClass = 6;
			Level = 52;
			ReqLevel = 47;
			Name = "Overlord's Shield";
			Name2 = "Overlord's Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2070;
			BuyPrice = 82246;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Lord's Crest)
*
***************************************************************/

namespace Server.Items
{
	public class LordsCrest : Item
	{
		public LordsCrest() : base()
		{
			Id = 10078;
			Resistance[0] = 1635;
			Bonding = 2;
			Block = 27;
			SellPrice = 18642;
			AvailableClasses = 0x7FFF;
			Model = 20972;
			ObjectClass = 4;
			SubClass = 6;
			Level = 53;
			ReqLevel = 48;
			Name = "Lord's Crest";
			Name2 = "Lord's Crest";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2070;
			BuyPrice = 93213;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Revenant Deflector)
*
***************************************************************/

namespace Server.Items
{
	public class RevenantDeflector : Item
	{
		public RevenantDeflector() : base()
		{
			Id = 10093;
			Resistance[0] = 1663;
			Bonding = 2;
			Block = 28;
			SellPrice = 18903;
			AvailableClasses = 0x7FFF;
			Model = 27432;
			ObjectClass = 4;
			SubClass = 6;
			Level = 54;
			ReqLevel = 49;
			Name = "Revenant Deflector";
			Name2 = "Revenant Deflector";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2070;
			BuyPrice = 94517;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Mercurial Guard)
*
***************************************************************/

namespace Server.Items
{
	public class MercurialGuard : Item
	{
		public MercurialGuard() : base()
		{
			Id = 10158;
			Resistance[0] = 1946;
			Bonding = 2;
			Block = 37;
			SellPrice = 31040;
			AvailableClasses = 0x7FFF;
			Model = 26152;
			ObjectClass = 4;
			SubClass = 6;
			Level = 64;
			ReqLevel = 59;
			Name = "Mercurial Guard";
			Name2 = "Mercurial Guard";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2094;
			BuyPrice = 155200;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Crusader's Shield)
*
***************************************************************/

namespace Server.Items
{
	public class CrusadersShield : Item
	{
		public CrusadersShield() : base()
		{
			Id = 10195;
			Resistance[0] = 1691;
			Bonding = 2;
			Block = 29;
			SellPrice = 19221;
			AvailableClasses = 0x7FFF;
			Model = 26176;
			ObjectClass = 4;
			SubClass = 6;
			Level = 55;
			ReqLevel = 50;
			Name = "Crusader's Shield";
			Name2 = "Crusader's Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2076;
			BuyPrice = 96107;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Heavy Lamellar Shield)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyLamellarShield : Item
	{
		public HeavyLamellarShield() : base()
		{
			Id = 10204;
			Resistance[0] = 1691;
			Bonding = 2;
			Block = 29;
			SellPrice = 19888;
			AvailableClasses = 0x7FFF;
			Model = 27388;
			ObjectClass = 4;
			SubClass = 6;
			Level = 55;
			ReqLevel = 50;
			Name = "Heavy Lamellar Shield";
			Name2 = "Heavy Lamellar Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2076;
			BuyPrice = 99441;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Masterwork Shield)
*
***************************************************************/

namespace Server.Items
{
	public class MasterworkShield : Item
	{
		public MasterworkShield() : base()
		{
			Id = 10271;
			Resistance[0] = 1975;
			Bonding = 2;
			Block = 38;
			SellPrice = 32592;
			AvailableClasses = 0x7FFF;
			Model = 27806;
			ObjectClass = 4;
			SubClass = 6;
			Level = 65;
			ReqLevel = 60;
			Name = "Masterwork Shield";
			Name2 = "Masterwork Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2094;
			BuyPrice = 162960;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Ornate Shield)
*
***************************************************************/

namespace Server.Items
{
	public class OrnateShield : Item
	{
		public OrnateShield() : base()
		{
			Id = 10362;
			Resistance[0] = 1776;
			Bonding = 2;
			Block = 32;
			SellPrice = 24760;
			AvailableClasses = 0x7FFF;
			Model = 20910;
			ObjectClass = 4;
			SubClass = 6;
			Level = 58;
			ReqLevel = 53;
			Name = "Ornate Shield";
			Name2 = "Ornate Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2082;
			BuyPrice = 123802;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Engraved Wall)
*
***************************************************************/

namespace Server.Items
{
	public class EngravedWall : Item
	{
		public EngravedWall() : base()
		{
			Id = 10363;
			Resistance[0] = 1833;
			Bonding = 2;
			Block = 34;
			SellPrice = 27396;
			AvailableClasses = 0x7FFF;
			Model = 26283;
			ObjectClass = 4;
			SubClass = 6;
			Level = 60;
			ReqLevel = 55;
			Name = "Engraved Wall";
			Name2 = "Engraved Wall";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2082;
			BuyPrice = 136982;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Templar Shield)
*
***************************************************************/

namespace Server.Items
{
	public class TemplarShield : Item
	{
		public TemplarShield() : base()
		{
			Id = 10364;
			Resistance[0] = 1776;
			Bonding = 2;
			Block = 32;
			SellPrice = 24938;
			AvailableClasses = 0x7FFF;
			Model = 27415;
			ObjectClass = 4;
			SubClass = 6;
			Level = 58;
			ReqLevel = 53;
			Name = "Templar Shield";
			Name2 = "Templar Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2082;
			BuyPrice = 124692;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Emerald Shield)
*
***************************************************************/

namespace Server.Items
{
	public class EmeraldShield : Item
	{
		public EmeraldShield() : base()
		{
			Id = 10365;
			Resistance[0] = 1805;
			Bonding = 2;
			Block = 33;
			SellPrice = 26276;
			AvailableClasses = 0x7FFF;
			Model = 27803;
			ObjectClass = 4;
			SubClass = 6;
			Level = 59;
			ReqLevel = 54;
			Name = "Emerald Shield";
			Name2 = "Emerald Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2082;
			BuyPrice = 131381;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Demon Guard)
*
***************************************************************/

namespace Server.Items
{
	public class DemonGuard : Item
	{
		public DemonGuard() : base()
		{
			Id = 10366;
			Resistance[0] = 1918;
			Bonding = 2;
			Block = 36;
			SellPrice = 32052;
			AvailableClasses = 0x7FFF;
			Model = 20831;
			ObjectClass = 4;
			SubClass = 6;
			Level = 63;
			ReqLevel = 58;
			Name = "Demon Guard";
			Name2 = "Demon Guard";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2088;
			BuyPrice = 160263;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Hyperion Shield)
*
***************************************************************/

namespace Server.Items
{
	public class HyperionShield : Item
	{
		public HyperionShield() : base()
		{
			Id = 10367;
			Resistance[0] = 1975;
			Bonding = 2;
			Block = 38;
			SellPrice = 32971;
			AvailableClasses = 0x7FFF;
			Model = 20971;
			ObjectClass = 4;
			SubClass = 6;
			Level = 65;
			ReqLevel = 60;
			Name = "Hyperion Shield";
			Name2 = "Hyperion Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2094;
			BuyPrice = 164856;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Aegis of Battle)
*
***************************************************************/

namespace Server.Items
{
	public class AegisOfBattle : Item
	{
		public AegisOfBattle() : base()
		{
			Id = 10686;
			Resistance[0] = 1691;
			Bonding = 1;
			Block = 29;
			SellPrice = 21163;
			AvailableClasses = 0x7FFF;
			Model = 20820;
			ObjectClass = 4;
			SubClass = 6;
			Level = 55;
			Name = "Aegis of Battle";
			Name2 = "Aegis of Battle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 105815;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
			StaminaBonus = 10;
			AgilityBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Savage Boar's Guard)
*
***************************************************************/

namespace Server.Items
{
	public class SavageBoarsGuard : Item
	{
		public SavageBoarsGuard() : base()
		{
			Id = 10767;
			Resistance[0] = 1287;
			Bonding = 1;
			Block = 22;
			SellPrice = 9652;
			AvailableClasses = 0x7FFF;
			Model = 20974;
			ObjectClass = 4;
			SubClass = 6;
			Level = 42;
			ReqLevel = 37;
			Name = "Savage Boar's Guard";
			Name2 = "Savage Boar's Guard";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 48260;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 100;
			StrBonus = 11;
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Crest of Supremacy)
*
***************************************************************/

namespace Server.Items
{
	public class CrestOfSupremacy : Item
	{
		public CrestOfSupremacy() : base()
		{
			Id = 10835;
			Resistance[0] = 1930;
			Bonding = 1;
			Block = 35;
			SellPrice = 24645;
			AvailableClasses = 0x7FFF;
			Model = 19840;
			ObjectClass = 4;
			SubClass = 6;
			Level = 56;
			ReqLevel = 51;
			Name = "Crest of Supremacy";
			Name2 = "Crest of Supremacy";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 123225;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 100;
			AgilityBonus = 6;
			SpiritBonus = 7;
			IqBonus = 7;
			StaminaBonus = 7;
			StrBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Stoneshell Guard)
*
***************************************************************/

namespace Server.Items
{
	public class StoneshellGuard : Item
	{
		public StoneshellGuard() : base()
		{
			Id = 11631;
			Resistance[0] = 1706;
			Bonding = 1;
			Block = 26;
			SellPrice = 16578;
			AvailableClasses = 0x7FFF;
			Model = 21613;
			ObjectClass = 4;
			SubClass = 6;
			Level = 52;
			ReqLevel = 47;
			Name = "Stoneshell Guard";
			Name2 = "Stoneshell Guard";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 82890;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
			StrBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Rock Golem Bulwark)
*
***************************************************************/

namespace Server.Items
{
	public class RockGolemBulwark : Item
	{
		public RockGolemBulwark() : base()
		{
			Id = 11785;
			Resistance[6] = 15;
			Resistance[0] = 1994;
			Bonding = 1;
			Block = 36;
			SellPrice = 29082;
			AvailableClasses = 0x7FFF;
			Model = 18814;
			ObjectClass = 4;
			SubClass = 6;
			Level = 58;
			ReqLevel = 53;
			Name = "Rock Golem Bulwark";
			Name2 = "Rock Golem Bulwark";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 145414;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 100;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Shizzle's Drizzle Blocker)
*
***************************************************************/

namespace Server.Items
{
	public class ShizzlesDrizzleBlocker : Item
	{
		public ShizzlesDrizzleBlocker() : base()
		{
			Id = 11915;
			Resistance[0] = 1691;
			Bonding = 1;
			Block = 29;
			SellPrice = 20124;
			AvailableClasses = 0x7FFF;
			Model = 18750;
			ObjectClass = 4;
			SubClass = 6;
			Level = 55;
			Name = "Shizzle's Drizzle Blocker";
			Name2 = "Shizzle's Drizzle Blocker";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 100623;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
			StrBonus = 13;
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Draconian Deflector)
*
***************************************************************/

namespace Server.Items
{
	public class DraconianDeflector : Item
	{
		public DraconianDeflector() : base()
		{
			Id = 12602;
			Resistance[0] = 2153;
			Bonding = 1;
			Block = 40;
			SellPrice = 35212;
			AvailableClasses = 0x7FFF;
			Model = 23419;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 6;
			Level = 63;
			ReqLevel = 58;
			Name = "Draconian Deflector";
			Name2 = "Draconian Deflector";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 176064;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 100;
			SetSpell( 13390 , 1 , 0 , 0 , 0 , -1 );
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Redbeard Crest)
*
***************************************************************/

namespace Server.Items
{
	public class RedbeardCrest : Item
	{
		public RedbeardCrest() : base()
		{
			Id = 12997;
			Resistance[0] = 547;
			Bonding = 2;
			Block = 11;
			SellPrice = 1920;
			AvailableClasses = 0x7FFF;
			Model = 28811;
			ObjectClass = 4;
			SubClass = 6;
			Level = 24;
			ReqLevel = 19;
			Name = "Redbeard Crest";
			Name2 = "Redbeard Crest";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 9600;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 90;
			StrBonus = 6;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Shield of Thorsen)
*
***************************************************************/

namespace Server.Items
{
	public class ShieldOfThorsen : Item
	{
		public ShieldOfThorsen() : base()
		{
			Id = 13079;
			Resistance[0] = 711;
			Bonding = 2;
			Block = 14;
			SellPrice = 3359;
			AvailableClasses = 0x7FFF;
			Model = 28742;
			ObjectClass = 4;
			SubClass = 6;
			Level = 30;
			ReqLevel = 25;
			Name = "Shield of Thorsen";
			Name2 = "Shield of Thorsen";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 16798;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 100;
			StrBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Skullance Shield)
*
***************************************************************/

namespace Server.Items
{
	public class SkullanceShield : Item
	{
		public SkullanceShield() : base()
		{
			Id = 13081;
			Resistance[0] = 814;
			Bonding = 2;
			Block = 19;
			SellPrice = 7123;
			AvailableClasses = 0x7FFF;
			Model = 18790;
			ObjectClass = 4;
			SubClass = 6;
			Level = 38;
			ReqLevel = 33;
			Name = "Skullance Shield";
			Name2 = "Skullance Shield";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 35617;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 100;
			StrBonus = 8;
			StaminaBonus = 5;
			AgilityBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Mountainside Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class MountainsideBuckler : Item
	{
		public MountainsideBuckler() : base()
		{
			Id = 13082;
			Resistance[0] = 1612;
			Bonding = 2;
			Block = 25;
			SellPrice = 13235;
			AvailableClasses = 0x7FFF;
			Model = 25134;
			ObjectClass = 4;
			SubClass = 6;
			Level = 46;
			ReqLevel = 41;
			Name = "Mountainside Buckler";
			Name2 = "Mountainside Buckler";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 66175;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 100;
			IqBonus = 12;
			SpiritBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Garrett Family Crest)
*
***************************************************************/

namespace Server.Items
{
	public class GarrettFamilyCrest : Item
	{
		public GarrettFamilyCrest() : base()
		{
			Id = 13083;
			Resistance[0] = 2121;
			Bonding = 2;
			Block = 39;
			SellPrice = 34694;
			AvailableClasses = 0x7FFF;
			Model = 25133;
			ObjectClass = 4;
			SubClass = 6;
			Level = 62;
			ReqLevel = 57;
			Name = "Garrett Family Crest";
			Name2 = "Garrett Family Crest";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 173470;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 100;
			AgilityBonus = 5;
			SpiritBonus = 4;
			IqBonus = 17;
		}
	}
}


/**************************************************************
*
*				(Rhombeard Protector)
*
***************************************************************/

namespace Server.Items
{
	public class RhombeardProtector : Item
	{
		public RhombeardProtector() : base()
		{
			Id = 13205;
			Resistance[0] = 2089;
			Bonding = 1;
			Block = 38;
			SellPrice = 35031;
			AvailableClasses = 0x7FFF;
			Model = 23750;
			ObjectClass = 4;
			SubClass = 6;
			Level = 61;
			ReqLevel = 56;
			Name = "Rhombeard Protector";
			Name2 = "Rhombeard Protector";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 175155;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 100;
			IqBonus = 10;
			SpiritBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Argent Defender)
*
***************************************************************/

namespace Server.Items
{
	public class ArgentDefender : Item
	{
		public ArgentDefender() : base()
		{
			Id = 13243;
			Resistance[0] = 2121;
			Bonding = 1;
			Block = 39;
			SellPrice = 36515;
			AvailableClasses = 0x7FFF;
			Model = 25133;
			ObjectClass = 4;
			SubClass = 6;
			Level = 62;
			Name = "Argent Defender";
			Name2 = "Argent Defender";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 182578;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 100;
			SetSpell( 17350 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Kresh's Back)
*
***************************************************************/

namespace Server.Items
{
	public class KreshsBack : Item
	{
		public KreshsBack() : base()
		{
			Id = 13245;
			Resistance[0] = 471;
			Bonding = 1;
			Block = 9;
			SellPrice = 1064;
			AvailableClasses = 0x7FFF;
			Model = 23835;
			ObjectClass = 4;
			SubClass = 6;
			Level = 20;
			ReqLevel = 15;
			Name = "Kresh's Back";
			Name2 = "Kresh's Back";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 5323;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 75;
			SetSpell( 7517 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Astral Guard)
*
***************************************************************/

namespace Server.Items
{
	public class AstralGuard : Item
	{
		public AstralGuard() : base()
		{
			Id = 13254;
			Resistance[0] = 1720;
			Bonding = 1;
			Block = 30;
			SellPrice = 21569;
			AvailableClasses = 0x7FFF;
			Model = 23847;
			ObjectClass = 4;
			SubClass = 6;
			Level = 56;
			ReqLevel = 51;
			Name = "Astral Guard";
			Name2 = "Astral Guard";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 4313;
			BuyPrice = 107849;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Crest of Retribution)
*
***************************************************************/

namespace Server.Items
{
	public class CrestOfRetribution : Item
	{
		public CrestOfRetribution() : base()
		{
			Id = 13375;
			Resistance[0] = 2057;
			Bonding = 1;
			Block = 38;
			SellPrice = 30656;
			AvailableClasses = 0x7FFF;
			Model = 23825;
			ObjectClass = 4;
			SubClass = 6;
			Level = 60;
			ReqLevel = 55;
			Name = "Crest of Retribution";
			Name2 = "Crest of Retribution";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 153284;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 100;
			SetSpell( 17495 , 1 , 0 , 0 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Husk of Nerub'enkan)
*
***************************************************************/

namespace Server.Items
{
	public class HuskOfNerubenkan : Item
	{
		public HuskOfNerubenkan() : base()
		{
			Id = 13529;
			Resistance[0] = 2089;
			Bonding = 1;
			Block = 38;
			SellPrice = 32303;
			AvailableClasses = 0x7FFF;
			Model = 4107;
			ObjectClass = 4;
			SubClass = 6;
			Level = 61;
			ReqLevel = 56;
			Name = "Husk of Nerub'enkan";
			Name2 = "Husk of Nerub'enkan";
			Resistance[3] = 15;
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 161517;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 100;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Darrowshire Strongguard)
*
***************************************************************/

namespace Server.Items
{
	public class DarrowshireStrongguard : Item
	{
		public DarrowshireStrongguard() : base()
		{
			Id = 14002;
			Resistance[0] = 2153;
			Bonding = 1;
			Block = 40;
			SellPrice = 36720;
			AvailableClasses = 0x7FFF;
			Model = 22831;
			Resistance[4] = 10;
			ObjectClass = 4;
			SubClass = 6;
			Level = 63;
			Name = "Darrowshire Strongguard";
			Name2 = "Darrowshire Strongguard";
			Resistance[3] = 10;
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 183600;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 100;
			IqBonus = 8;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Rattlecage Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class RattlecageBuckler : Item
	{
		public RattlecageBuckler() : base()
		{
			Id = 14528;
			Resistance[0] = 2121;
			Bonding = 1;
			Block = 39;
			SellPrice = 34181;
			AvailableClasses = 0x7FFF;
			Model = 25138;
			ObjectClass = 4;
			SubClass = 6;
			Level = 62;
			ReqLevel = 57;
			Name = "Rattlecage Buckler";
			Name2 = "Rattlecage Buckler";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 170909;
			Resistance[5] = 7;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 100;
			IqBonus = 7;
			SpiritBonus = 12;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Hawkeye's Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class HawkeyesBuckler : Item
	{
		public HawkeyesBuckler() : base()
		{
			Id = 14607;
			Resistance[0] = 695;
			Bonding = 2;
			Block = 15;
			SellPrice = 5581;
			AvailableClasses = 0x7FFF;
			Model = 27981;
			ObjectClass = 4;
			SubClass = 6;
			Level = 37;
			ReqLevel = 32;
			Name = "Hawkeye's Buckler";
			Name2 = "Hawkeye's Buckler";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 27906;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
			StrBonus = 5;
			SpiritBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Dokebi Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class DokebiBuckler : Item
	{
		public DokebiBuckler() : base()
		{
			Id = 14608;
			Resistance[0] = 595;
			Bonding = 2;
			Block = 12;
			SellPrice = 3162;
			AvailableClasses = 0x7FFF;
			Model = 18487;
			ObjectClass = 4;
			SubClass = 6;
			Level = 31;
			ReqLevel = 26;
			Name = "Dokebi Buckler";
			Name2 = "Dokebi Buckler";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 15810;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
			StaminaBonus = 3;
			SpiritBonus = 5;
		}
	}
}


/**************************************************************
*
*				(War Paint Shield)
*
***************************************************************/

namespace Server.Items
{
	public class WarPaintShield : Item
	{
		public WarPaintShield() : base()
		{
			Id = 14729;
			Resistance[0] = 411;
			Bonding = 2;
			Block = 7;
			SellPrice = 870;
			AvailableClasses = 0x7FFF;
			Model = 23835;
			ObjectClass = 4;
			SubClass = 6;
			Level = 20;
			ReqLevel = 15;
			Name = "War Paint Shield";
			Name2 = "War Paint Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4350;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 65;
			StrBonus = 2;
			IqBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Ravager's Shield)
*
***************************************************************/

namespace Server.Items
{
	public class RavagersShield : Item
	{
		public RavagersShield() : base()
		{
			Id = 14777;
			Resistance[0] = 1380;
			Bonding = 2;
			Block = 20;
			SellPrice = 9710;
			AvailableClasses = 0x7FFF;
			Model = 27099;
			ObjectClass = 4;
			SubClass = 6;
			Level = 44;
			ReqLevel = 39;
			Name = "Ravager's Shield";
			Name2 = "Ravager's Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 48551;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
			SpiritBonus = 7;
			IqBonus = 6;
			StrBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Khan's Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class KhansBuckler : Item
	{
		public KhansBuckler() : base()
		{
			Id = 14780;
			Resistance[0] = 1521;
			Bonding = 2;
			Block = 23;
			SellPrice = 14289;
			AvailableClasses = 0x7FFF;
			Model = 20833;
			ObjectClass = 4;
			SubClass = 6;
			Level = 49;
			ReqLevel = 44;
			Name = "Khan's Buckler";
			Name2 = "Khan's Buckler";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 71446;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
			StaminaBonus = 5;
			SpiritBonus = 9;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Protector Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class ProtectorBuckler : Item
	{
		public ProtectorBuckler() : base()
		{
			Id = 14790;
			Resistance[0] = 1663;
			Bonding = 2;
			Block = 28;
			SellPrice = 18781;
			AvailableClasses = 0x7FFF;
			Model = 27162;
			ObjectClass = 4;
			SubClass = 6;
			Level = 54;
			ReqLevel = 49;
			Name = "Protector Buckler";
			Name2 = "Protector Buckler";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 93907;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
			AgilityBonus = 3;
			IqBonus = 5;
			SpiritBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Bloodlust Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class BloodlustBuckler : Item
	{
		public BloodlustBuckler() : base()
		{
			Id = 14800;
			Resistance[0] = 1805;
			Bonding = 2;
			Block = 33;
			SellPrice = 25826;
			AvailableClasses = 0x7FFF;
			Model = 27202;
			ObjectClass = 4;
			SubClass = 6;
			Level = 59;
			ReqLevel = 54;
			Name = "Bloodlust Buckler";
			Name2 = "Bloodlust Buckler";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 129132;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
			SpiritBonus = 7;
			IqBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Warstrike Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class WarstrikeBuckler : Item
	{
		public WarstrikeBuckler() : base()
		{
			Id = 14812;
			Resistance[0] = 1946;
			Bonding = 2;
			Block = 37;
			SellPrice = 32007;
			AvailableClasses = 0x7FFF;
			Model = 27145;
			ObjectClass = 4;
			SubClass = 6;
			Level = 64;
			ReqLevel = 59;
			Name = "Warstrike Buckler";
			Name2 = "Warstrike Buckler";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 160037;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
			StaminaBonus = 3;
			IqBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Symbolic Crest)
*
***************************************************************/

namespace Server.Items
{
	public class SymbolicCrest : Item
	{
		public SymbolicCrest() : base()
		{
			Id = 14825;
			Resistance[0] = 1257;
			Bonding = 2;
			Block = 19;
			SellPrice = 8595;
			AvailableClasses = 0x7FFF;
			Model = 25134;
			ObjectClass = 4;
			SubClass = 6;
			Level = 43;
			ReqLevel = 38;
			Name = "Symbolic Crest";
			Name2 = "Symbolic Crest";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 42977;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
			StaminaBonus = 7;
			StrBonus = 4;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Tyrant's Shield)
*
***************************************************************/

namespace Server.Items
{
	public class TyrantsShield : Item
	{
		public TyrantsShield() : base()
		{
			Id = 14842;
			Resistance[0] = 1493;
			Bonding = 2;
			Block = 23;
			SellPrice = 12483;
			AvailableClasses = 0x7FFF;
			Model = 26693;
			ObjectClass = 4;
			SubClass = 6;
			Level = 48;
			ReqLevel = 43;
			Name = "Tyrant's Shield";
			Name2 = "Tyrant's Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 62415;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
			StrBonus = 9;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Sunscale Shield)
*
***************************************************************/

namespace Server.Items
{
	public class SunscaleShield : Item
	{
		public SunscaleShield() : base()
		{
			Id = 14852;
			Resistance[0] = 1663;
			Bonding = 2;
			Block = 28;
			SellPrice = 19420;
			AvailableClasses = 0x7FFF;
			Model = 11925;
			ObjectClass = 4;
			SubClass = 6;
			Level = 54;
			ReqLevel = 49;
			Name = "Sunscale Shield";
			Name2 = "Sunscale Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 97100;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
			IqBonus = 3;
			StaminaBonus = 10;
			StrBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Saltstone Shield)
*
***************************************************************/

namespace Server.Items
{
	public class SaltstoneShield : Item
	{
		public SaltstoneShield() : base()
		{
			Id = 14902;
			Resistance[0] = 1051;
			Bonding = 2;
			Block = 17;
			SellPrice = 7482;
			AvailableClasses = 0x7FFF;
			Model = 23847;
			ObjectClass = 4;
			SubClass = 6;
			Level = 41;
			ReqLevel = 36;
			Name = "Saltstone Shield";
			Name2 = "Saltstone Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2046;
			BuyPrice = 37413;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Brutish Shield)
*
***************************************************************/

namespace Server.Items
{
	public class BrutishShield : Item
	{
		public BrutishShield() : base()
		{
			Id = 14912;
			Resistance[0] = 1550;
			Bonding = 2;
			Block = 24;
			SellPrice = 15232;
			AvailableClasses = 0x7FFF;
			Model = 11925;
			ObjectClass = 4;
			SubClass = 6;
			Level = 50;
			ReqLevel = 45;
			Name = "Brutish Shield";
			Name2 = "Brutish Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2064;
			BuyPrice = 76163;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Jade Deflector)
*
***************************************************************/

namespace Server.Items
{
	public class JadeDeflector : Item
	{
		public JadeDeflector() : base()
		{
			Id = 14916;
			Resistance[0] = 1635;
			Bonding = 2;
			Block = 27;
			SellPrice = 17254;
			AvailableClasses = 0x7FFF;
			Model = 22805;
			ObjectClass = 4;
			SubClass = 6;
			Level = 53;
			ReqLevel = 48;
			Name = "Jade Deflector";
			Name2 = "Jade Deflector";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2070;
			BuyPrice = 86272;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Lofty Shield)
*
***************************************************************/

namespace Server.Items
{
	public class LoftyShield : Item
	{
		public LoftyShield() : base()
		{
			Id = 14930;
			Resistance[0] = 1748;
			Bonding = 2;
			Block = 31;
			SellPrice = 22950;
			AvailableClasses = 0x7FFF;
			Model = 20974;
			ObjectClass = 4;
			SubClass = 6;
			Level = 57;
			ReqLevel = 52;
			Name = "Lofty Shield";
			Name2 = "Lofty Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2076;
			BuyPrice = 114751;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Warbringer's Shield)
*
***************************************************************/

namespace Server.Items
{
	public class WarbringersShield : Item
	{
		public WarbringersShield() : base()
		{
			Id = 14947;
			Resistance[0] = 1436;
			Bonding = 2;
			Block = 21;
			SellPrice = 11198;
			AvailableClasses = 0x7FFF;
			Model = 23825;
			ObjectClass = 4;
			SubClass = 6;
			Level = 46;
			ReqLevel = 41;
			Name = "Warbringer's Shield";
			Name2 = "Warbringer's Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2058;
			BuyPrice = 55992;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Bloodforged Shield)
*
***************************************************************/

namespace Server.Items
{
	public class BloodforgedShield : Item
	{
		public BloodforgedShield() : base()
		{
			Id = 14954;
			Resistance[0] = 1578;
			Bonding = 2;
			Block = 25;
			SellPrice = 15234;
			AvailableClasses = 0x7FFF;
			Model = 26844;
			ObjectClass = 4;
			SubClass = 6;
			Level = 51;
			ReqLevel = 46;
			Name = "Bloodforged Shield";
			Name2 = "Bloodforged Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2064;
			BuyPrice = 76174;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(High Chief's Shield)
*
***************************************************************/

namespace Server.Items
{
	public class HighChiefsShield : Item
	{
		public HighChiefsShield() : base()
		{
			Id = 14964;
			Resistance[0] = 1720;
			Bonding = 2;
			Block = 30;
			SellPrice = 21741;
			AvailableClasses = 0x7FFF;
			Model = 23419;
			ObjectClass = 4;
			SubClass = 6;
			Level = 56;
			ReqLevel = 51;
			Name = "High Chief's Shield";
			Name2 = "High Chief's Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2076;
			BuyPrice = 108705;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Glorious Shield)
*
***************************************************************/

namespace Server.Items
{
	public class GloriousShield : Item
	{
		public GloriousShield() : base()
		{
			Id = 14973;
			Resistance[0] = 1833;
			Bonding = 2;
			Block = 34;
			SellPrice = 27810;
			AvailableClasses = 0x7FFF;
			Model = 26868;
			ObjectClass = 4;
			SubClass = 6;
			Level = 60;
			ReqLevel = 55;
			Name = "Glorious Shield";
			Name2 = "Glorious Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2082;
			BuyPrice = 139051;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Exalted Shield)
*
***************************************************************/

namespace Server.Items
{
	public class ExaltedShield : Item
	{
		public ExaltedShield() : base()
		{
			Id = 14982;
			Resistance[0] = 1975;
			Bonding = 2;
			Block = 38;
			SellPrice = 34119;
			AvailableClasses = 0x7FFF;
			Model = 26911;
			ObjectClass = 4;
			SubClass = 6;
			Level = 65;
			ReqLevel = 60;
			Name = "Exalted Shield";
			Name2 = "Exalted Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2094;
			BuyPrice = 170595;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Primal Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class PrimalBuckler : Item
	{
		public PrimalBuckler() : base()
		{
			Id = 15006;
			Resistance[0] = 135;
			Block = 3;
			SellPrice = 72;
			AvailableClasses = 0x7FFF;
			Model = 18508;
			ObjectClass = 4;
			SubClass = 6;
			Level = 9;
			ReqLevel = 4;
			Name = "Primal Buckler";
			Name2 = "Primal Buckler";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 364;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Lupine Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class LupineBuckler : Item
	{
		public LupineBuckler() : base()
		{
			Id = 15014;
			Resistance[0] = 361;
			Bonding = 2;
			Block = 6;
			SellPrice = 585;
			AvailableClasses = 0x7FFF;
			Model = 28579;
			ObjectClass = 4;
			SubClass = 6;
			Level = 17;
			ReqLevel = 12;
			Name = "Lupine Buckler";
			Name2 = "Lupine Buckler";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1996;
			BuyPrice = 2927;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Rigid Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class RigidBuckler : Item
	{
		public RigidBuckler() : base()
		{
			Id = 15113;
			Resistance[0] = 461;
			Bonding = 2;
			Block = 8;
			SellPrice = 1361;
			AvailableClasses = 0x7FFF;
			Model = 2211;
			ObjectClass = 4;
			SubClass = 6;
			Level = 23;
			ReqLevel = 18;
			Name = "Rigid Buckler";
			Name2 = "Rigid Buckler";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2010;
			BuyPrice = 6805;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Robust Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class RobustBuckler : Item
	{
		public RobustBuckler() : base()
		{
			Id = 15123;
			Resistance[0] = 545;
			Bonding = 2;
			Block = 10;
			SellPrice = 2463;
			AvailableClasses = 0x7FFF;
			Model = 18449;
			ObjectClass = 4;
			SubClass = 6;
			Level = 28;
			ReqLevel = 23;
			Name = "Robust Buckler";
			Name2 = "Robust Buckler";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2020;
			BuyPrice = 12319;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 80;
		}
	}
}


/**************************************************************
*
*				(Cutthroat's Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class CutthroatsBuckler : Item
	{
		public CutthroatsBuckler() : base()
		{
			Id = 15133;
			Resistance[0] = 628;
			Bonding = 2;
			Block = 13;
			SellPrice = 3826;
			AvailableClasses = 0x7FFF;
			Model = 27720;
			ObjectClass = 4;
			SubClass = 6;
			Level = 33;
			ReqLevel = 28;
			Name = "Cutthroat's Buckler";
			Name2 = "Cutthroat's Buckler";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2026;
			BuyPrice = 19134;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Ghostwalker Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class GhostwalkerBuckler : Item
	{
		public GhostwalkerBuckler() : base()
		{
			Id = 15145;
			Resistance[0] = 678;
			Bonding = 2;
			Block = 14;
			SellPrice = 4943;
			AvailableClasses = 0x7FFF;
			Model = 27690;
			ObjectClass = 4;
			SubClass = 6;
			Level = 36;
			ReqLevel = 31;
			Name = "Ghostwalker Buckler";
			Name2 = "Ghostwalker Buckler";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2032;
			BuyPrice = 24717;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Steelcap Shield)
*
***************************************************************/

namespace Server.Items
{
	public class SteelcapShield : Item
	{
		public SteelcapShield() : base()
		{
			Id = 15207;
			Resistance[0] = 411;
			Bonding = 1;
			Block = 7;
			SellPrice = 868;
			AvailableClasses = 0x7FFF;
			Model = 26322;
			ObjectClass = 4;
			SubClass = 6;
			Level = 20;
			Name = "Steelcap Shield";
			Name2 = "Steelcap Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4342;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 65;
			StaminaBonus = 2;
			StrBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Grizzly Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class GrizzlyBuckler : Item
	{
		public GrizzlyBuckler() : base()
		{
			Id = 15298;
			Resistance[0] = 274;
			Bonding = 2;
			Block = 5;
			SellPrice = 305;
			AvailableClasses = 0x7FFF;
			Model = 28017;
			ObjectClass = 4;
			SubClass = 6;
			Level = 13;
			ReqLevel = 8;
			Name = "Grizzly Buckler";
			Name2 = "Grizzly Buckler";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 6272;
			BuyPrice = 1525;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Feral Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class FeralBuckler : Item
	{
		public FeralBuckler() : base()
		{
			Id = 15307;
			Resistance[0] = 395;
			Bonding = 2;
			Block = 7;
			SellPrice = 815;
			AvailableClasses = 0x7FFF;
			Model = 20826;
			ObjectClass = 4;
			SubClass = 6;
			Level = 19;
			ReqLevel = 14;
			Name = "Feral Buckler";
			Name2 = "Feral Buckler";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2004;
			BuyPrice = 4077;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Wrangler's Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class WranglersBuckler : Item
	{
		public WranglersBuckler() : base()
		{
			Id = 15332;
			Resistance[0] = 528;
			Bonding = 2;
			Block = 10;
			SellPrice = 2263;
			AvailableClasses = 0x7FFF;
			Model = 18493;
			ObjectClass = 4;
			SubClass = 6;
			Level = 27;
			ReqLevel = 22;
			Name = "Wrangler's Buckler";
			Name2 = "Wrangler's Buckler";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2014;
			BuyPrice = 11319;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 80;
		}
	}
}


/**************************************************************
*
*				(Pathfinder Guard)
*
***************************************************************/

namespace Server.Items
{
	public class PathfinderGuard : Item
	{
		public PathfinderGuard() : base()
		{
			Id = 15342;
			Resistance[0] = 578;
			Bonding = 2;
			Block = 11;
			SellPrice = 2907;
			AvailableClasses = 0x7FFF;
			Model = 28583;
			ObjectClass = 4;
			SubClass = 6;
			Level = 30;
			ReqLevel = 25;
			Name = "Pathfinder Guard";
			Name2 = "Pathfinder Guard";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2020;
			BuyPrice = 14537;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Headhunter's Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class HeadhuntersBuckler : Item
	{
		public HeadhuntersBuckler() : base()
		{
			Id = 15352;
			Resistance[0] = 645;
			Bonding = 2;
			Block = 13;
			SellPrice = 4101;
			AvailableClasses = 0x7FFF;
			Model = 28269;
			ObjectClass = 4;
			SubClass = 6;
			Level = 34;
			ReqLevel = 29;
			Name = "Headhunter's Buckler";
			Name2 = "Headhunter's Buckler";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2032;
			BuyPrice = 20507;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Trickster's Protector)
*
***************************************************************/

namespace Server.Items
{
	public class TrickstersProtector : Item
	{
		public TrickstersProtector() : base()
		{
			Id = 15367;
			Resistance[0] = 728;
			Bonding = 2;
			Block = 16;
			SellPrice = 6246;
			AvailableClasses = 0x7FFF;
			Model = 28026;
			ObjectClass = 4;
			SubClass = 6;
			Level = 39;
			ReqLevel = 34;
			Name = "Trickster's Protector";
			Name2 = "Trickster's Protector";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2038;
			BuyPrice = 31233;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Clink Shield)
*
***************************************************************/

namespace Server.Items
{
	public class ClinkShield : Item
	{
		public ClinkShield() : base()
		{
			Id = 15466;
			Resistance[0] = 545;
			Bonding = 1;
			Block = 10;
			SellPrice = 2323;
			AvailableClasses = 0x7FFF;
			Model = 28269;
			ObjectClass = 4;
			SubClass = 6;
			Level = 28;
			Name = "Clink Shield";
			Name2 = "Clink Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11619;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 80;
			StaminaBonus = 4;
			AgilityBonus = 2;
			StrBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Charger's Shield)
*
***************************************************************/

namespace Server.Items
{
	public class ChargersShield : Item
	{
		public ChargersShield() : base()
		{
			Id = 15478;
			Resistance[0] = 112;
			Block = 2;
			SellPrice = 52;
			AvailableClasses = 0x7FFF;
			Model = 3931;
			ObjectClass = 4;
			SubClass = 6;
			Level = 8;
			ReqLevel = 3;
			Name = "Charger's Shield";
			Name2 = "Charger's Shield";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 260;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(War Torn Shield)
*
***************************************************************/

namespace Server.Items
{
	public class WarTornShield : Item
	{
		public WarTornShield() : base()
		{
			Id = 15486;
			Resistance[0] = 239;
			Bonding = 2;
			Block = 4;
			SellPrice = 245;
			AvailableClasses = 0x7FFF;
			Model = 26959;
			ObjectClass = 4;
			SubClass = 6;
			Level = 12;
			ReqLevel = 7;
			Name = "War Torn Shield";
			Name2 = "War Torn Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 6278;
			BuyPrice = 1229;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Bloodspattered Shield)
*
***************************************************************/

namespace Server.Items
{
	public class BloodspatteredShield : Item
	{
		public BloodspatteredShield() : base()
		{
			Id = 15494;
			Resistance[0] = 378;
			Bonding = 2;
			Block = 6;
			SellPrice = 693;
			AvailableClasses = 0x7FFF;
			Model = 23750;
			ObjectClass = 4;
			SubClass = 6;
			Level = 18;
			ReqLevel = 13;
			Name = "Bloodspattered Shield";
			Name2 = "Bloodspattered Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1998;
			BuyPrice = 3467;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Outrunner's Shield)
*
***************************************************************/

namespace Server.Items
{
	public class OutrunnersShield : Item
	{
		public OutrunnersShield() : base()
		{
			Id = 15504;
			Resistance[0] = 445;
			Bonding = 2;
			Block = 8;
			SellPrice = 1168;
			AvailableClasses = 0x7FFF;
			Model = 26855;
			ObjectClass = 4;
			SubClass = 6;
			Level = 22;
			ReqLevel = 17;
			Name = "Outrunner's Shield";
			Name2 = "Outrunner's Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2010;
			BuyPrice = 5843;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Grunt's Shield)
*
***************************************************************/

namespace Server.Items
{
	public class GruntsShield : Item
	{
		public GruntsShield() : base()
		{
			Id = 15512;
			Resistance[0] = 478;
			Bonding = 2;
			Block = 9;
			SellPrice = 1578;
			AvailableClasses = 0x7FFF;
			Model = 26978;
			ObjectClass = 4;
			SubClass = 6;
			Level = 24;
			ReqLevel = 19;
			Name = "Grunt's Shield";
			Name2 = "Grunt's Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2010;
			BuyPrice = 7891;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 75;
		}
	}
}


/**************************************************************
*
*				(Spiked Chain Shield)
*
***************************************************************/

namespace Server.Items
{
	public class SpikedChainShield : Item
	{
		public SpikedChainShield() : base()
		{
			Id = 15522;
			Resistance[0] = 561;
			Bonding = 2;
			Block = 11;
			SellPrice = 2516;
			AvailableClasses = 0x7FFF;
			Model = 18775;
			ObjectClass = 4;
			SubClass = 6;
			Level = 29;
			ReqLevel = 24;
			Name = "Spiked Chain Shield";
			Name2 = "Spiked Chain Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2022;
			BuyPrice = 12584;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Sentry's Shield)
*
***************************************************************/

namespace Server.Items
{
	public class SentrysShield : Item
	{
		public SentrysShield() : base()
		{
			Id = 15530;
			Resistance[0] = 595;
			Bonding = 2;
			Block = 12;
			SellPrice = 3222;
			AvailableClasses = 0x7FFF;
			Model = 27084;
			ObjectClass = 4;
			SubClass = 6;
			Level = 31;
			ReqLevel = 26;
			Name = "Sentry's Shield";
			Name2 = "Sentry's Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2028;
			BuyPrice = 16110;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Wicked Chain Shield)
*
***************************************************************/

namespace Server.Items
{
	public class WickedChainShield : Item
	{
		public WickedChainShield() : base()
		{
			Id = 15543;
			Resistance[0] = 645;
			Bonding = 2;
			Block = 13;
			SellPrice = 4179;
			AvailableClasses = 0x7FFF;
			Model = 26060;
			ObjectClass = 4;
			SubClass = 6;
			Level = 34;
			ReqLevel = 29;
			Name = "Wicked Chain Shield";
			Name2 = "Wicked Chain Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2034;
			BuyPrice = 20898;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Thick Scale Shield)
*
***************************************************************/

namespace Server.Items
{
	public class ThickScaleShield : Item
	{
		public ThickScaleShield() : base()
		{
			Id = 15552;
			Resistance[0] = 678;
			Bonding = 2;
			Block = 14;
			SellPrice = 5226;
			AvailableClasses = 0x7FFF;
			Model = 27024;
			ObjectClass = 4;
			SubClass = 6;
			Level = 36;
			ReqLevel = 31;
			Name = "Thick Scale Shield";
			Name2 = "Thick Scale Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2034;
			BuyPrice = 26130;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Pillager's Shield)
*
***************************************************************/

namespace Server.Items
{
	public class PillagersShield : Item
	{
		public PillagersShield() : base()
		{
			Id = 15563;
			Resistance[0] = 695;
			Bonding = 2;
			Block = 15;
			SellPrice = 5562;
			AvailableClasses = 0x7FFF;
			Model = 20973;
			ObjectClass = 4;
			SubClass = 6;
			Level = 37;
			ReqLevel = 32;
			Name = "Pillager's Shield";
			Name2 = "Pillager's Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2040;
			BuyPrice = 27814;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Marauder's Crest)
*
***************************************************************/

namespace Server.Items
{
	public class MaraudersCrest : Item
	{
		public MaraudersCrest() : base()
		{
			Id = 15569;
			Resistance[0] = 963;
			Bonding = 2;
			Block = 17;
			SellPrice = 7162;
			AvailableClasses = 0x7FFF;
			Model = 27064;
			ObjectClass = 4;
			SubClass = 6;
			Level = 40;
			ReqLevel = 35;
			Name = "Marauder's Crest";
			Name2 = "Marauder's Crest";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2046;
			BuyPrice = 35813;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Sparkleshell Shield)
*
***************************************************************/

namespace Server.Items
{
	public class SparkleshellShield : Item
	{
		public SparkleshellShield() : base()
		{
			Id = 15584;
			Resistance[0] = 1051;
			Bonding = 2;
			Block = 17;
			SellPrice = 7594;
			AvailableClasses = 0x7FFF;
			Model = 25911;
			ObjectClass = 4;
			SubClass = 6;
			Level = 41;
			ReqLevel = 36;
			Name = "Sparkleshell Shield";
			Name2 = "Sparkleshell Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2044;
			BuyPrice = 37973;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Steadfast Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class SteadfastBuckler : Item
	{
		public SteadfastBuckler() : base()
		{
			Id = 15592;
			Resistance[0] = 1257;
			Bonding = 2;
			Block = 19;
			SellPrice = 8465;
			AvailableClasses = 0x7FFF;
			Model = 27896;
			ObjectClass = 4;
			SubClass = 6;
			Level = 43;
			ReqLevel = 38;
			Name = "Steadfast Buckler";
			Name2 = "Steadfast Buckler";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2050;
			BuyPrice = 42328;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Ancient Defender)
*
***************************************************************/

namespace Server.Items
{
	public class AncientDefender : Item
	{
		public AncientDefender() : base()
		{
			Id = 15604;
			Resistance[0] = 1436;
			Bonding = 2;
			Block = 21;
			SellPrice = 11158;
			AvailableClasses = 0x7FFF;
			Model = 27126;
			ObjectClass = 4;
			SubClass = 6;
			Level = 46;
			ReqLevel = 41;
			Name = "Ancient Defender";
			Name2 = "Ancient Defender";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2056;
			BuyPrice = 55790;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Bonelink Wall Shield)
*
***************************************************************/

namespace Server.Items
{
	public class BonelinkWallShield : Item
	{
		public BonelinkWallShield() : base()
		{
			Id = 15618;
			Resistance[0] = 1465;
			Bonding = 2;
			Block = 22;
			SellPrice = 11782;
			AvailableClasses = 0x7FFF;
			Model = 26099;
			ObjectClass = 4;
			SubClass = 6;
			Level = 47;
			ReqLevel = 42;
			Name = "Bonelink Wall Shield";
			Name2 = "Bonelink Wall Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2056;
			BuyPrice = 58910;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Gryphon Mail Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class GryphonMailBuckler : Item
	{
		public GryphonMailBuckler() : base()
		{
			Id = 15621;
			Resistance[0] = 1578;
			Bonding = 2;
			Block = 25;
			SellPrice = 15766;
			AvailableClasses = 0x7FFF;
			Model = 27135;
			ObjectClass = 4;
			SubClass = 6;
			Level = 51;
			ReqLevel = 46;
			Name = "Gryphon Mail Buckler";
			Name2 = "Gryphon Mail Buckler";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2062;
			BuyPrice = 78830;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Formidable Crest)
*
***************************************************************/

namespace Server.Items
{
	public class FormidableCrest : Item
	{
		public FormidableCrest() : base()
		{
			Id = 15633;
			Resistance[0] = 1606;
			Bonding = 2;
			Block = 26;
			SellPrice = 16210;
			AvailableClasses = 0x7FFF;
			Model = 27222;
			ObjectClass = 4;
			SubClass = 6;
			Level = 52;
			ReqLevel = 47;
			Name = "Formidable Crest";
			Name2 = "Formidable Crest";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2068;
			BuyPrice = 81050;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Ironhide Shield)
*
***************************************************************/

namespace Server.Items
{
	public class IronhideShield : Item
	{
		public IronhideShield() : base()
		{
			Id = 15648;
			Resistance[0] = 1720;
			Bonding = 2;
			Block = 30;
			SellPrice = 22212;
			AvailableClasses = 0x7FFF;
			Model = 27179;
			ObjectClass = 4;
			SubClass = 6;
			Level = 56;
			ReqLevel = 51;
			Name = "Ironhide Shield";
			Name2 = "Ironhide Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2074;
			BuyPrice = 111061;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Merciless Shield)
*
***************************************************************/

namespace Server.Items
{
	public class MercilessShield : Item
	{
		public MercilessShield() : base()
		{
			Id = 15657;
			Resistance[0] = 1748;
			Bonding = 2;
			Block = 31;
			SellPrice = 22625;
			AvailableClasses = 0x7FFF;
			Model = 27294;
			ObjectClass = 4;
			SubClass = 6;
			Level = 57;
			ReqLevel = 52;
			Name = "Merciless Shield";
			Name2 = "Merciless Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2074;
			BuyPrice = 113128;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Impenetrable Wall)
*
***************************************************************/

namespace Server.Items
{
	public class ImpenetrableWall : Item
	{
		public ImpenetrableWall() : base()
		{
			Id = 15667;
			Resistance[0] = 1861;
			Bonding = 2;
			Block = 35;
			SellPrice = 28785;
			AvailableClasses = 0x7FFF;
			Model = 27305;
			ObjectClass = 4;
			SubClass = 6;
			Level = 61;
			ReqLevel = 56;
			Name = "Impenetrable Wall";
			Name2 = "Impenetrable Wall";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2086;
			BuyPrice = 143928;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Magnificent Guard)
*
***************************************************************/

namespace Server.Items
{
	public class MagnificentGuard : Item
	{
		public MagnificentGuard() : base()
		{
			Id = 15675;
			Resistance[0] = 1890;
			Bonding = 2;
			Block = 36;
			SellPrice = 28932;
			AvailableClasses = 0x7FFF;
			Model = 26152;
			ObjectClass = 4;
			SubClass = 6;
			Level = 62;
			ReqLevel = 57;
			Name = "Magnificent Guard";
			Name2 = "Magnificent Guard";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2086;
			BuyPrice = 144661;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Triumphant Shield)
*
***************************************************************/

namespace Server.Items
{
	public class TriumphantShield : Item
	{
		public TriumphantShield() : base()
		{
			Id = 15687;
			Resistance[0] = 1975;
			Bonding = 2;
			Block = 38;
			SellPrice = 32493;
			AvailableClasses = 0x7FFF;
			Model = 26120;
			ObjectClass = 4;
			SubClass = 6;
			Level = 65;
			ReqLevel = 60;
			Name = "Triumphant Shield";
			Name2 = "Triumphant Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2092;
			BuyPrice = 162469;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Studded Ring Shield)
*
***************************************************************/

namespace Server.Items
{
	public class StuddedRingShield : Item
	{
		public StuddedRingShield() : base()
		{
			Id = 15695;
			Resistance[0] = 711;
			Bonding = 1;
			Block = 15;
			SellPrice = 5771;
			AvailableClasses = 0x7FFF;
			Model = 26413;
			ObjectClass = 4;
			SubClass = 6;
			Level = 38;
			Name = "Studded Ring Shield";
			Name2 = "Studded Ring Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 28856;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
			StrBonus = 6;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Anchorhold Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class AnchorholdBuckler : Item
	{
		public AnchorholdBuckler() : base()
		{
			Id = 15865;
			Resistance[0] = 728;
			Bonding = 1;
			Block = 16;
			SellPrice = 6562;
			AvailableClasses = 0x7FFF;
			Model = 26548;
			ObjectClass = 4;
			SubClass = 6;
			Level = 39;
			Name = "Anchorhold Buckler";
			Name2 = "Anchorhold Buckler";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 32811;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
			SpiritBonus = 6;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Heroic Guard)
*
***************************************************************/

namespace Server.Items
{
	public class HeroicGuard : Item
	{
		public HeroicGuard() : base()
		{
			Id = 15887;
			Resistance[0] = 1890;
			Bonding = 2;
			Block = 36;
			SellPrice = 29581;
			AvailableClasses = 0x7FFF;
			Model = 26921;
			ObjectClass = 4;
			SubClass = 6;
			Level = 62;
			ReqLevel = 57;
			Name = "Heroic Guard";
			Name2 = "Heroic Guard";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 2088;
			BuyPrice = 147908;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Vanguard Shield)
*
***************************************************************/

namespace Server.Items
{
	public class VanguardShield : Item
	{
		public VanguardShield() : base()
		{
			Id = 15890;
			Resistance[0] = 1805;
			Bonding = 2;
			Block = 33;
			SellPrice = 25831;
			AvailableClasses = 0x7FFF;
			Model = 26855;
			ObjectClass = 4;
			SubClass = 6;
			Level = 59;
			ReqLevel = 54;
			Name = "Vanguard Shield";
			Name2 = "Vanguard Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 129157;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
			StaminaBonus = 12;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Hulking Shield)
*
***************************************************************/

namespace Server.Items
{
	public class HulkingShield : Item
	{
		public HulkingShield() : base()
		{
			Id = 15891;
			Resistance[0] = 511;
			Bonding = 2;
			Block = 9;
			SellPrice = 2014;
			AvailableClasses = 0x7FFF;
			Model = 23825;
			ObjectClass = 4;
			SubClass = 6;
			Level = 26;
			ReqLevel = 21;
			Name = "Hulking Shield";
			Name2 = "Hulking Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 10074;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 80;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Slayer's Shield)
*
***************************************************************/

namespace Server.Items
{
	public class SlayersShield : Item
	{
		public SlayersShield() : base()
		{
			Id = 15892;
			Resistance[0] = 611;
			Bonding = 2;
			Block = 12;
			SellPrice = 3582;
			AvailableClasses = 0x7FFF;
			Model = 27036;
			ObjectClass = 4;
			SubClass = 6;
			Level = 32;
			ReqLevel = 27;
			Name = "Slayer's Shield";
			Name2 = "Slayer's Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 17911;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
			StrBonus = 6;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Prospector's Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class ProspectorsBuckler : Item
	{
		public ProspectorsBuckler() : base()
		{
			Id = 15893;
			Resistance[0] = 428;
			Bonding = 2;
			Block = 7;
			SellPrice = 1082;
			AvailableClasses = 0x7FFF;
			Model = 27527;
			ObjectClass = 4;
			SubClass = 6;
			Level = 21;
			ReqLevel = 16;
			Name = "Prospector's Buckler";
			Name2 = "Prospector's Buckler";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5410;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 65;
			StaminaBonus = 1;
			SpiritBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Bristlebark Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class BristlebarkBuckler : Item
	{
		public BristlebarkBuckler() : base()
		{
			Id = 15894;
			Resistance[0] = 495;
			Bonding = 2;
			Block = 9;
			SellPrice = 1802;
			AvailableClasses = 0x7FFF;
			Model = 18483;
			ObjectClass = 4;
			SubClass = 6;
			Level = 25;
			ReqLevel = 20;
			Name = "Bristlebark Buckler";
			Name2 = "Bristlebark Buckler";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 9010;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 75;
			AgilityBonus = 2;
			SpiritBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Burnt Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class BurntBuckler : Item
	{
		public BurntBuckler() : base()
		{
			Id = 15895;
			Resistance[0] = 112;
			Block = 2;
			SellPrice = 53;
			AvailableClasses = 0x7FFF;
			Model = 28449;
			ObjectClass = 4;
			SubClass = 6;
			Level = 8;
			ReqLevel = 3;
			Name = "Burnt Buckler";
			Name2 = "Burnt Buckler";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 265;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Imbued Shield)
*
***************************************************************/

namespace Server.Items
{
	public class ImbuedShield : Item
	{
		public ImbuedShield() : base()
		{
			Id = 15943;
			Resistance[0] = 1861;
			Bonding = 2;
			Block = 35;
			SellPrice = 27752;
			AvailableClasses = 0x7FFF;
			Model = 27588;
			ObjectClass = 4;
			SubClass = 6;
			Level = 61;
			ReqLevel = 56;
			Name = "Imbued Shield";
			Name2 = "Imbued Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 138761;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
			StrBonus = 3;
			StaminaBonus = 14;
		}
	}
}


/**************************************************************
*
*				(Enduring Shield)
*
***************************************************************/

namespace Server.Items
{
	public class EnduringShield : Item
	{
		public EnduringShield() : base()
		{
			Id = 15990;
			Resistance[0] = 728;
			Bonding = 2;
			Block = 16;
			SellPrice = 6850;
			AvailableClasses = 0x7FFF;
			Model = 27055;
			ObjectClass = 4;
			SubClass = 6;
			Level = 39;
			ReqLevel = 34;
			Name = "Enduring Shield";
			Name2 = "Enduring Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 34252;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
			StrBonus = 6;
			StaminaBonus = 4;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Warleader's Shield)
*
***************************************************************/

namespace Server.Items
{
	public class WarleadersShield : Item
	{
		public WarleadersShield() : base()
		{
			Id = 15991;
			Resistance[0] = 1918;
			Bonding = 2;
			Block = 36;
			SellPrice = 29230;
			AvailableClasses = 0x7FFF;
			Model = 18775;
			ObjectClass = 4;
			SubClass = 6;
			Level = 63;
			ReqLevel = 58;
			Name = "Warleader's Shield";
			Name2 = "Warleader's Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 146151;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
			StaminaBonus = 14;
			AgilityBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Driftmire Shield)
*
***************************************************************/

namespace Server.Items
{
	public class DriftmireShield : Item
	{
		public DriftmireShield() : base()
		{
			Id = 16660;
			Resistance[0] = 528;
			Bonding = 1;
			Block = 10;
			SellPrice = 2200;
			AvailableClasses = 0x7FFF;
			Model = 27517;
			ObjectClass = 4;
			SubClass = 6;
			Level = 27;
			Name = "Driftmire Shield";
			Name2 = "Driftmire Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11004;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 80;
			SpiritBonus = 3;
			StrBonus = 2;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Captain Rackmore's Wheel)
*
***************************************************************/

namespace Server.Items
{
	public class CaptainRackmoresWheel : Item
	{
		public CaptainRackmoresWheel() : base()
		{
			Id = 16788;
			Resistance[0] = 678;
			Bonding = 1;
			Block = 14;
			SellPrice = 5095;
			AvailableClasses = 0x7FFF;
			Model = 28407;
			ObjectClass = 4;
			SubClass = 6;
			Level = 36;
			Name = "Captain Rackmore's Wheel";
			Name2 = "Captain Rackmore's Wheel";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 25476;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Sacred Protector)
*
***************************************************************/

namespace Server.Items
{
	public class SacredProtector : Item
	{
		public SacredProtector() : base()
		{
			Id = 16998;
			Resistance[0] = 2121;
			Bonding = 1;
			Block = 39;
			SellPrice = 35631;
			AvailableClasses = 0x7FFF;
			Model = 28829;
			ObjectClass = 4;
			SubClass = 6;
			Level = 62;
			Name = "Sacred Protector";
			Name2 = "Sacred Protector";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 178156;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 100;
			StaminaBonus = 15;
			SpiritBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Drillborer Disk)
*
***************************************************************/

namespace Server.Items
{
	public class DrillborerDisk : Item
	{
		public DrillborerDisk() : base()
		{
			Id = 17066;
			Resistance[0] = 2539;
			Bonding = 1;
			Block = 46;
			SellPrice = 57970;
			AvailableClasses = 0x7FFF;
			Model = 29701;
			ObjectClass = 4;
			SubClass = 6;
			Level = 67;
			ReqLevel = 60;
			Name = "Drillborer Disk";
			Name2 = "Drillborer Disk";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 289852;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 120;
			SetSpell( 15438 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 13675 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 22852 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Malistar's Defender)
*
***************************************************************/

namespace Server.Items
{
	public class MalistarsDefender : Item
	{
		public MalistarsDefender() : base()
		{
			Id = 17106;
			Resistance[0] = 2822;
			Bonding = 1;
			Block = 52;
			SellPrice = 87960;
			AvailableClasses = 0x7FFF;
			Model = 29702;
			ObjectClass = 4;
			SubClass = 6;
			Level = 75;
			ReqLevel = 60;
			Name = "Malistar's Defender";
			Name2 = "Malistar's Defender";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 439804;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 120;
			SetSpell( 21365 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 12;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Dented Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class DentedBuckler17183 : Item
	{
		public DentedBuckler17183() : base()
		{
			Id = 17183;
			Resistance[0] = 29;
			Block = 1;
			SellPrice = 6;
			AvailableClasses = 0x7FFF;
			Model = 2208;
			ObjectClass = 4;
			SubClass = 6;
			Level = 3;
			ReqLevel = 1;
			Name = "Dented Buckler";
			Name2 = "Dented Buckler";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 34;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Small Shield)
*
***************************************************************/

namespace Server.Items
{
	public class SmallShield17184 : Item
	{
		public SmallShield17184() : base()
		{
			Id = 17184;
			Resistance[0] = 29;
			Block = 1;
			SellPrice = 6;
			AvailableClasses = 0x7FFF;
			Model = 18480;
			ObjectClass = 4;
			SubClass = 6;
			Level = 3;
			ReqLevel = 1;
			Name = "Small Shield";
			Name2 = "Small Shield";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 34;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Round Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class RoundBuckler17185 : Item
	{
		public RoundBuckler17185() : base()
		{
			Id = 17185;
			Resistance[0] = 112;
			Block = 2;
			SellPrice = 48;
			AvailableClasses = 0x7FFF;
			Model = 18509;
			ObjectClass = 4;
			SubClass = 6;
			Level = 8;
			ReqLevel = 3;
			Name = "Round Buckler";
			Name2 = "Round Buckler";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 243;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Small Targe)
*
***************************************************************/

namespace Server.Items
{
	public class SmallTarge17186 : Item
	{
		public SmallTarge17186() : base()
		{
			Id = 17186;
			Resistance[0] = 112;
			Block = 2;
			SellPrice = 48;
			AvailableClasses = 0x7FFF;
			Model = 18506;
			ObjectClass = 4;
			SubClass = 6;
			Level = 8;
			ReqLevel = 3;
			Name = "Small Targe";
			Name2 = "Small Targe";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 243;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Banded Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class BandedBuckler17187 : Item
	{
		public BandedBuckler17187() : base()
		{
			Id = 17187;
			Resistance[0] = 289;
			Block = 4;
			SellPrice = 215;
			AvailableClasses = 0x7FFF;
			Model = 27782;
			ObjectClass = 4;
			SubClass = 6;
			Level = 14;
			ReqLevel = 9;
			Name = "Banded Buckler";
			Name2 = "Banded Buckler";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1078;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Ringed Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class RingedBuckler17188 : Item
	{
		public RingedBuckler17188() : base()
		{
			Id = 17188;
			Resistance[0] = 367;
			Block = 6;
			SellPrice = 453;
			AvailableClasses = 0x7FFF;
			Model = 18468;
			ObjectClass = 4;
			SubClass = 6;
			Level = 19;
			ReqLevel = 14;
			Name = "Ringed Buckler";
			Name2 = "Ringed Buckler";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2265;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 65;
		}
	}
}


/**************************************************************
*
*				(Metal Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class MetalBuckler17189 : Item
	{
		public MetalBuckler17189() : base()
		{
			Id = 17189;
			Resistance[0] = 599;
			Block = 12;
			SellPrice = 2408;
			AvailableClasses = 0x7FFF;
			Model = 18477;
			ObjectClass = 4;
			SubClass = 6;
			Level = 34;
			ReqLevel = 29;
			Name = "Metal Buckler";
			Name2 = "Metal Buckler";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 12043;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Ornate Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class OrnateBuckler17190 : Item
	{
		public OrnateBuckler17190() : base()
		{
			Id = 17190;
			Resistance[0] = 1377;
			Block = 20;
			SellPrice = 6921;
			AvailableClasses = 0x7FFF;
			Model = 18516;
			ObjectClass = 4;
			SubClass = 6;
			Level = 47;
			ReqLevel = 42;
			Name = "Ornate Buckler";
			Name2 = "Ornate Buckler";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 34609;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Reinforced Targe)
*
***************************************************************/

namespace Server.Items
{
	public class ReinforcedTarge17192 : Item
	{
		public ReinforcedTarge17192() : base()
		{
			Id = 17192;
			Resistance[0] = 444;
			Block = 8;
			SellPrice = 879;
			AvailableClasses = 0x7FFF;
			Model = 2324;
			ObjectClass = 4;
			SubClass = 6;
			Level = 24;
			ReqLevel = 19;
			Name = "Reinforced Targe";
			Name2 = "Reinforced Targe";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 4399;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 75;
		}
	}
}


/**************************************************************
*
*				(Forcestone Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class ForcestoneBuckler17508 : Item
	{
		public ForcestoneBuckler17508() : base()
		{
			Id = 17508;
			Resistance[0] = 1051;
			Bonding = 1;
			Block = 17;
			SellPrice = 7270;
			AvailableClasses = 0x7FFF;
			Model = 4405;
			ObjectClass = 4;
			SubClass = 6;
			Level = 41;
			Name = "Forcestone Buckler";
			Name2 = "Forcestone Buckler";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 36350;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 85;
			StaminaBonus = 3;
			IqBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Gizlock's Hypertech Buckler)
*
***************************************************************/

namespace Server.Items
{
	public class GizlocksHypertechBuckler : Item
	{
		public GizlocksHypertechBuckler() : base()
		{
			Id = 17718;
			Resistance[0] = 1835;
			Bonding = 1;
			Block = 32;
			SellPrice = 22630;
			AvailableClasses = 0x7FFF;
			Model = 29896;
			ObjectClass = 4;
			SubClass = 6;
			Level = 53;
			ReqLevel = 48;
			Name = "Gizlock's Hypertech Buckler";
			Name2 = "Gizlock's Hypertech Buckler";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 113150;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 100;
			SetSpell( 21618 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 10;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Force Reactive Disk)
*
***************************************************************/

namespace Server.Items
{
	public class ForceReactiveDisk : Item
	{
		public ForceReactiveDisk() : base()
		{
			Id = 18168;
			Resistance[0] = 2548;
			Bonding = 2;
			Block = 44;
			SellPrice = 56416;
			AvailableClasses = 0x7FFF;
			Model = 30561;
			ObjectClass = 4;
			SubClass = 6;
			Level = 65;
			ReqLevel = 60;
			Name = "Force Reactive Disk";
			Name2 = "Force Reactive Disk";
			Quality = 4;
			AvailableRaces = 0x1FF;
			SkillRank = 300;
			Skill = 202;
			BuyPrice = 282082;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = -1;
			Sheath = 4;
			Durability = 120;
			SetSpell( 22618 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 22620 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Petrified Bark Shield)
*
***************************************************************/

namespace Server.Items
{
	public class PetrifiedBarkShield : Item
	{
		public PetrifiedBarkShield() : base()
		{
			Id = 18352;
			Resistance[0] = 1861;
			Bonding = 1;
			Block = 35;
			SellPrice = 28072;
			AvailableClasses = 0x7FFF;
			Model = 30706;
			ObjectClass = 4;
			SubClass = 6;
			Level = 61;
			ReqLevel = 56;
			Name = "Petrified Bark Shield";
			Name2 = "Petrified Bark Shield";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 140363;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 2;
			Sheath = 4;
			Durability = 85;
			SetSpell( 22852 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Observer's Shield)
*
***************************************************************/

namespace Server.Items
{
	public class ObserversShield : Item
	{
		public ObserversShield() : base()
		{
			Id = 18485;
			Resistance[0] = 2089;
			Bonding = 1;
			Block = 38;
			SellPrice = 34569;
			AvailableClasses = 0x7FFF;
			Model = 20900;
			ObjectClass = 4;
			SubClass = 6;
			Level = 61;
			ReqLevel = 56;
			Name = "Observer's Shield";
			Name2 = "Observer's Shield";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 172849;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 6;
			Sheath = 4;
			Durability = 100;
			SpiritBonus = 14;
			IqBonus = 5;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Barrier Shield)
*
***************************************************************/

namespace Server.Items
{
	public class BarrierShield : Item
	{
		public BarrierShield() : base()
		{
			Id = 18499;
			Resistance[0] = 2121;
			Bonding = 1;
			Block = 39;
			SellPrice = 34589;
			AvailableClasses = 0x7FFF;
			Model = 30835;
			ObjectClass = 4;
			SubClass = 6;
			Level = 62;
			ReqLevel = 57;
			Name = "Barrier Shield";
			Name2 = "Barrier Shield";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 172945;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 6;
			Sheath = 4;
			Durability = 100;
			SetSpell( 13675 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 22912 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Milli's Shield)
*
***************************************************************/

namespace Server.Items
{
	public class MillisShield : Item
	{
		public MillisShield() : base()
		{
			Id = 18535;
			Resistance[0] = 2106;
			Bonding = 1;
			Block = 37;
			SellPrice = 30231;
			AvailableClasses = 0x7FFF;
			Model = 30872;
			ObjectClass = 4;
			SubClass = 6;
			Level = 59;
			Name = "Milli's Shield";
			Name2 = "Milli's Shield";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 151155;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 2;
			Sheath = 4;
			Durability = 100;
			SetSpell( 21347 , 1 , 0 , -1 , 0 , -1 );
			IqBonus = 7;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Avalanchion's Stony Hide)
*
***************************************************************/

namespace Server.Items
{
	public class AvalanchionsStonyHide : Item
	{
		public AvalanchionsStonyHide() : base()
		{
			Id = 18673;
			Resistance[0] = 2026;
			Bonding = 2;
			Block = 37;
			SellPrice = 28918;
			AvailableClasses = 0x7FFF;
			Model = 31121;
			ObjectClass = 4;
			SubClass = 6;
			Level = 59;
			ReqLevel = 54;
			Name = "Avalanchion's Stony Hide";
			Name2 = "Avalanchion's Stony Hide";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 144591;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 100;
			SetSpell( 23172 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 16;
		}
	}
}


/**************************************************************
*
*				(Intricately Runed Shield)
*
***************************************************************/

namespace Server.Items
{
	public class IntricatelyRunedShield : Item
	{
		public IntricatelyRunedShield() : base()
		{
			Id = 18696;
			Resistance[0] = 2121;
			Bonding = 1;
			Block = 39;
			SellPrice = 33476;
			AvailableClasses = 0x7FFF;
			Model = 18790;
			ObjectClass = 4;
			SubClass = 6;
			Level = 62;
			ReqLevel = 57;
			Name = "Intricately Runed Shield";
			Name2 = "Intricately Runed Shield";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 167382;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 6;
			Sheath = 4;
			Durability = 100;
			SetSpell( 23181 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Dreadguard's Protector)
*
***************************************************************/

namespace Server.Items
{
	public class DreadguardsProtector : Item
	{
		public DreadguardsProtector() : base()
		{
			Id = 18756;
			Resistance[0] = 2121;
			Bonding = 1;
			Block = 39;
			SellPrice = 33420;
			AvailableClasses = 0x7FFF;
			Model = 31216;
			ObjectClass = 4;
			SubClass = 6;
			Level = 62;
			ReqLevel = 57;
			Name = "Dreadguard's Protector";
			Name2 = "Dreadguard's Protector";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 167101;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 2;
			Sheath = 4;
			Durability = 100;
			StrBonus = 18;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Grand Marshal's Aegis)
*
***************************************************************/

namespace Server.Items
{
	public class GrandMarshalsAegis : Item
	{
		public GrandMarshalsAegis() : base()
		{
			Id = 18825;
			Resistance[0] = 2929;
			Bonding = 1;
			Block = 55;
			SellPrice = 31807;
			AvailableClasses = 0x7FFF;
			Model = 31733;
			ObjectClass = 4;
			SubClass = 6;
			Level = 78;
			ReqLevel = 60;
			Name = "Grand Marshal's Aegis";
			Name2 = "Grand Marshal's Aegis";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 159036;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 120;
			Flags = 32768;
			SetSpell( 13959 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 23;
			StrBonus = 10;
		}
	}
}


/**************************************************************
*
*				(High Warlord's Shield Wall)
*
***************************************************************/

namespace Server.Items
{
	public class HighWarlordsShieldWall : Item
	{
		public HighWarlordsShieldWall() : base()
		{
			Id = 18826;
			Resistance[0] = 2929;
			Bonding = 1;
			Block = 55;
			SellPrice = 31917;
			AvailableClasses = 0x7FFF;
			Model = 31746;
			ObjectClass = 4;
			SubClass = 6;
			Level = 78;
			ReqLevel = 60;
			Name = "High Warlord's Shield Wall";
			Name2 = "High Warlord's Shield Wall";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 159587;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 1;
			Sheath = 4;
			Durability = 120;
			Flags = 32768;
			SetSpell( 13959 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 23;
			StrBonus = 10;
		}
	}
}


/**************************************************************
*
*				(The Immovable Object)
*
***************************************************************/

namespace Server.Items
{
	public class TheImmovableObject : Item
	{
		public TheImmovableObject() : base()
		{
			Id = 19321;
			Resistance[0] = 2468;
			Bonding = 1;
			Block = 44;
			SellPrice = 159059;
			AvailableClasses = 0x7FFF;
			Model = 31815;
			ObjectClass = 4;
			SubClass = 6;
			Level = 65;
			ReqLevel = 60;
			Name = "The Immovable Object";
			Name2 = "The Immovable Object";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 795297;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 4;
			Durability = 120;
			Flags = 32768;
			SetSpell( 23516 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Red Dragonscale Protector)
*
***************************************************************/

namespace Server.Items
{
	public class RedDragonscaleProtector : Item
	{
		public RedDragonscaleProtector() : base()
		{
			Id = 19348;
			Resistance[0] = 2787;
			Bonding = 1;
			Block = 51;
			SellPrice = 84402;
			AvailableClasses = 0x7FFF;
			Model = 31851;
			ObjectClass = 4;
			SubClass = 6;
			Level = 74;
			ReqLevel = 60;
			Name = "Red Dragonscale Protector";
			Name2 = "Red Dragonscale Protector";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 422012;
			InventoryType = InventoryTypes.Shield;
			Stackable = 1;
			Material = 6;
			Sheath = 4;
			Durability = 120;
			SetSpell( 18030 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 17;
			IqBonus = 6;
			StaminaBonus = 6;
		}
	}
}


