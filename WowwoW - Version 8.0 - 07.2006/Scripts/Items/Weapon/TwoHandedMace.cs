/**************************************************************
*
*		Made by fulgas (fulgas@gmail.com)
*
*  WowwoW Item Designer ( 2005/8/23 - 10:05:41 )
*
***************************************************************/

using System;
using System.Collections;

/***************************************************************/

/**************************************************************
*
*				(Ironwood Treebranch)
*
***************************************************************/

namespace Server.Items
{
	public class IronwoodTreebranch : Item
	{
		public IronwoodTreebranch() : base()
		{
			Id = 911;
			Bonding = 2;
			SellPrice = 3324;
			AvailableClasses = 0x7FFF;
			Model = 28628;
			ObjectClass = 2;
			SubClass = 5;
			Level = 25;
			ReqLevel = 20;
			Name = "Ironwood Treebranch";
			Name2 = "Ironwood Treebranch";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 16622;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3400;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 75;
			SetDamage( 45 , 69 , Resistances.Armor );
			StrBonus = 8;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Maul)
*
***************************************************************/

namespace Server.Items
{
	public class Maul : Item
	{
		public Maul() : base()
		{
			Id = 924;
			SellPrice = 2194;
			AvailableClasses = 0x7FFF;
			Model = 22131;
			ObjectClass = 2;
			SubClass = 5;
			Level = 26;
			ReqLevel = 21;
			Name = "Maul";
			Name2 = "Maul";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 10972;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2900;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 80;
			SetDamage( 37 , 56 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Kobold Mining Shovel)
*
***************************************************************/

namespace Server.Items
{
	public class KoboldMiningShovel : Item
	{
		public KoboldMiningShovel() : base()
		{
			Id = 1195;
			SellPrice = 47;
			AvailableClasses = 0x7FFF;
			Model = 7495;
			ObjectClass = 2;
			SubClass = 5;
			Level = 6;
			ReqLevel = 3;
			Name = "Kobold Mining Shovel";
			Name2 = "Kobold Mining Shovel";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 236;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2700;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 35;
			SetDamage( 6 , 10 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Giant Mace)
*
***************************************************************/

namespace Server.Items
{
	public class GiantMace : Item
	{
		public GiantMace() : base()
		{
			Id = 1197;
			SellPrice = 533;
			AvailableClasses = 0x7FFF;
			Model = 5226;
			ObjectClass = 2;
			SubClass = 5;
			Level = 15;
			ReqLevel = 10;
			Name = "Giant Mace";
			Name2 = "Giant Mace";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2666;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3500;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 55;
			SetDamage( 25 , 38 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Heavy Gnoll War Club)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyGnollWarClub : Item
	{
		public HeavyGnollWarClub() : base()
		{
			Id = 1218;
			Bonding = 2;
			SellPrice = 2064;
			AvailableClasses = 0x7FFF;
			Model = 5527;
			ObjectClass = 2;
			SubClass = 5;
			Level = 21;
			ReqLevel = 16;
			Name = "Heavy Gnoll War Club";
			Name2 = "Heavy Gnoll War Club";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 10321;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3700;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 65;
			SetDamage( 40 , 61 , Resistances.Armor );
			StrBonus = 10;
			AgilityBonus = -10;
		}
	}
}


/**************************************************************
*
*				(Headbasher)
*
***************************************************************/

namespace Server.Items
{
	public class Headbasher : Item
	{
		public Headbasher() : base()
		{
			Id = 1264;
			Bonding = 1;
			SellPrice = 3671;
			AvailableClasses = 0x7FFF;
			Model = 5530;
			ObjectClass = 2;
			SubClass = 5;
			Level = 26;
			Name = "Headbasher";
			Name2 = "Headbasher";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 18357;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2300;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 80;
			SetDamage( 32 , 49 , Resistances.Armor );
			StrBonus = 8;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Cracked Sledge)
*
***************************************************************/

namespace Server.Items
{
	public class CrackedSledge : Item
	{
		public CrackedSledge() : base()
		{
			Id = 1414;
			SellPrice = 97;
			AvailableClasses = 0x7FFF;
			Model = 19525;
			ObjectClass = 2;
			SubClass = 5;
			Level = 9;
			ReqLevel = 4;
			Name = "Cracked Sledge";
			Name2 = "Cracked Sledge";
			AvailableRaces = 0x1FF;
			BuyPrice = 486;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3300;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 40;
			SetDamage( 10 , 15 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Shadowhide Maul)
*
***************************************************************/

namespace Server.Items
{
	public class ShadowhideMaul : Item
	{
		public ShadowhideMaul() : base()
		{
			Id = 1458;
			Bonding = 2;
			SellPrice = 2623;
			AvailableClasses = 0x7FFF;
			Model = 8601;
			ObjectClass = 2;
			SubClass = 5;
			Level = 23;
			ReqLevel = 18;
			Name = "Shadowhide Maul";
			Name2 = "Shadowhide Maul";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 13117;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3000;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 70;
			SetDamage( 36 , 55 , Resistances.Armor );
			StrBonus = 6;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Rusty Warhammer)
*
***************************************************************/

namespace Server.Items
{
	public class RustyWarhammer : Item
	{
		public RustyWarhammer() : base()
		{
			Id = 1514;
			SellPrice = 294;
			AvailableClasses = 0x7FFF;
			Model = 19533;
			ObjectClass = 2;
			SubClass = 5;
			Level = 14;
			ReqLevel = 9;
			Name = "Rusty Warhammer";
			Name2 = "Rusty Warhammer";
			AvailableRaces = 0x1FF;
			BuyPrice = 1470;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3000;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 50;
			SetDamage( 13 , 21 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Huge Stone Club)
*
***************************************************************/

namespace Server.Items
{
	public class HugeStoneClub : Item
	{
		public HugeStoneClub() : base()
		{
			Id = 1523;
			Bonding = 2;
			SellPrice = 10261;
			AvailableClasses = 0x7FFF;
			Model = 5534;
			ObjectClass = 2;
			SubClass = 5;
			Level = 36;
			ReqLevel = 31;
			Name = "Huge Stone Club";
			Name2 = "Huge Stone Club";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 51305;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3600;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 85;
			SetDamage( 71 , 107 , Resistances.Armor );
			StaminaBonus = 14;
		}
	}
}


/**************************************************************
*
*				(Korg Bat)
*
***************************************************************/

namespace Server.Items
{
	public class KorgBat : Item
	{
		public KorgBat() : base()
		{
			Id = 1679;
			Bonding = 2;
			SellPrice = 9635;
			AvailableClasses = 0x7FFF;
			Model = 5137;
			ObjectClass = 2;
			SubClass = 5;
			Level = 36;
			ReqLevel = 31;
			Name = "Korg Bat";
			Name2 = "Korg Bat";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 48177;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3100;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 85;
			SetDamage( 61 , 92 , Resistances.Armor );
			StrBonus = 12;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Thornstone Sledgehammer)
*
***************************************************************/

namespace Server.Items
{
	public class ThornstoneSledgehammer : Item
	{
		public ThornstoneSledgehammer() : base()
		{
			Id = 1722;
			Bonding = 2;
			SellPrice = 19407;
			AvailableClasses = 0x7FFF;
			Model = 15467;
			ObjectClass = 2;
			SubClass = 5;
			Level = 42;
			ReqLevel = 37;
			Name = "Thornstone Sledgehammer";
			Name2 = "Thornstone Sledgehammer";
			Resistance[3] = 10;
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 97038;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3200;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 100;
			SetDamage( 95 , 143 , Resistances.Armor );
			StrBonus = 20;
		}
	}
}


/**************************************************************
*
*				(Battered Mallet)
*
***************************************************************/

namespace Server.Items
{
	public class BatteredMallet : Item
	{
		public BatteredMallet() : base()
		{
			Id = 1814;
			SellPrice = 603;
			AvailableClasses = 0x7FFF;
			Model = 19534;
			ObjectClass = 2;
			SubClass = 5;
			Level = 19;
			ReqLevel = 14;
			Name = "Battered Mallet";
			Name2 = "Battered Mallet";
			AvailableRaces = 0x1FF;
			BuyPrice = 3018;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2900;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 65;
			SetDamage( 17 , 26 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Wooden Maul)
*
***************************************************************/

namespace Server.Items
{
	public class WoodenMaul : Item
	{
		public WoodenMaul() : base()
		{
			Id = 1820;
			SellPrice = 963;
			AvailableClasses = 0x7FFF;
			Model = 19535;
			ObjectClass = 2;
			SubClass = 5;
			Level = 22;
			ReqLevel = 17;
			Name = "Wooden Maul";
			Name2 = "Wooden Maul";
			AvailableRaces = 0x1FF;
			BuyPrice = 4818;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2900;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 70;
			SetDamage( 20 , 30 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Rock Maul)
*
***************************************************************/

namespace Server.Items
{
	public class RockMaul : Item
	{
		public RockMaul() : base()
		{
			Id = 1826;
			SellPrice = 1765;
			AvailableClasses = 0x7FFF;
			Model = 8587;
			ObjectClass = 2;
			SubClass = 5;
			Level = 27;
			ReqLevel = 22;
			Name = "Rock Maul";
			Name2 = "Rock Maul";
			AvailableRaces = 0x1FF;
			BuyPrice = 8828;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2900;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 80;
			SetDamage( 25 , 38 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Slaghammer)
*
***************************************************************/

namespace Server.Items
{
	public class Slaghammer : Item
	{
		public Slaghammer() : base()
		{
			Id = 1976;
			Bonding = 2;
			SellPrice = 6340;
			AvailableClasses = 0x7FFF;
			Model = 8590;
			ObjectClass = 2;
			SubClass = 5;
			Level = 29;
			ReqLevel = 24;
			Name = "Slaghammer";
			Name2 = "Slaghammer";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 31703;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2800;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 100;
			SetDamage( 53 , 80 , Resistances.Armor );
			StaminaBonus = 10;
			StrBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Ballast Maul)
*
***************************************************************/

namespace Server.Items
{
	public class BallastMaul : Item
	{
		public BallastMaul() : base()
		{
			Id = 1990;
			Bonding = 2;
			SellPrice = 10077;
			AvailableClasses = 0x7FFF;
			Model = 5533;
			ObjectClass = 2;
			SubClass = 5;
			Level = 36;
			ReqLevel = 31;
			Name = "Ballast Maul";
			Name2 = "Ballast Maul";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5238;
			BuyPrice = 50385;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3400;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 85;
			SetDamage( 67 , 101 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Goblin Power Shovel)
*
***************************************************************/

namespace Server.Items
{
	public class GoblinPowerShovel : Item
	{
		public GoblinPowerShovel() : base()
		{
			Id = 1991;
			Bonding = 2;
			SellPrice = 8357;
			AvailableClasses = 0x7FFF;
			Model = 18269;
			ObjectClass = 2;
			SubClass = 5;
			Level = 34;
			ReqLevel = 29;
			Name = "Goblin Power Shovel";
			Name2 = "Goblin Power Shovel";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 41788;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3300;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 85;
			SetDamage( 60 , 91 , Resistances.Armor );
			StrBonus = 6;
			AgilityBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Rock Hammer)
*
***************************************************************/

namespace Server.Items
{
	public class RockHammer : Item
	{
		public RockHammer() : base()
		{
			Id = 2026;
			SellPrice = 1257;
			AvailableClasses = 0x7FFF;
			Model = 8593;
			ObjectClass = 2;
			SubClass = 5;
			Level = 21;
			ReqLevel = 16;
			Name = "Rock Hammer";
			Name2 = "Rock Hammer";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 6286;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3700;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 65;
			SetDamage( 37 , 56 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Kazon's Maul)
*
***************************************************************/

namespace Server.Items
{
	public class KazonsMaul : Item
	{
		public KazonsMaul() : base()
		{
			Id = 2058;
			Bonding = 2;
			SellPrice = 4197;
			AvailableClasses = 0x7FFF;
			Model = 19611;
			ObjectClass = 2;
			SubClass = 5;
			Level = 27;
			ReqLevel = 22;
			Name = "Kazon's Maul";
			Name2 = "Kazon's Maul";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 20986;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3400;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 80;
			SetDamage( 49 , 75 , Resistances.Armor );
			StrBonus = 8;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Icepane Warhammer)
*
***************************************************************/

namespace Server.Items
{
	public class IcepaneWarhammer : Item
	{
		public IcepaneWarhammer() : base()
		{
			Id = 2254;
			Bonding = 2;
			SellPrice = 506;
			AvailableClasses = 0x7FFF;
			Model = 19612;
			ObjectClass = 2;
			SubClass = 5;
			Level = 12;
			ReqLevel = 7;
			Name = "Icepane Warhammer";
			Name2 = "Icepane Warhammer";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2534;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3300;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 50;
			SetDamage( 22 , 34 , Resistances.Armor );
			StrBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Battleworn Hammer)
*
***************************************************************/

namespace Server.Items
{
	public class BattlewornHammer : Item
	{
		public BattlewornHammer() : base()
		{
			Id = 2361;
			SellPrice = 9;
			AvailableClasses = 0x7FFF;
			Model = 8690;
			ObjectClass = 2;
			SubClass = 5;
			Level = 2;
			ReqLevel = 1;
			Name = "Battleworn Hammer";
			Name2 = "Battleworn Hammer";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 45;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2900;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 25;
			SetDamage( 3 , 5 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Large Club)
*
***************************************************************/

namespace Server.Items
{
	public class LargeClub : Item
	{
		public LargeClub() : base()
		{
			Id = 2480;
			SellPrice = 14;
			AvailableClasses = 0x7FFF;
			Model = 19601;
			ObjectClass = 2;
			SubClass = 5;
			Level = 3;
			ReqLevel = 1;
			Name = "Large Club";
			Name2 = "Large Club";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 72;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3200;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 25;
			SetDamage( 4 , 6 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Large Stone Mace)
*
***************************************************************/

namespace Server.Items
{
	public class LargeStoneMace : Item
	{
		public LargeStoneMace() : base()
		{
			Id = 2486;
			SellPrice = 13;
			AvailableClasses = 0x7FFF;
			Model = 19627;
			ObjectClass = 2;
			SubClass = 5;
			Level = 3;
			ReqLevel = 1;
			Name = "Large Stone Mace";
			Name2 = "Large Stone Mace";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 66;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3200;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			SetDamage( 3 , 6 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Wooden Mallet)
*
***************************************************************/

namespace Server.Items
{
	public class WoodenMallet : Item
	{
		public WoodenMallet() : base()
		{
			Id = 2493;
			SellPrice = 140;
			AvailableClasses = 0x7FFF;
			Model = 22121;
			ObjectClass = 2;
			SubClass = 5;
			Level = 9;
			ReqLevel = 4;
			Name = "Wooden Mallet";
			Name2 = "Wooden Mallet";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 701;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2600;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 40;
			SetDamage( 10 , 16 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Wooden Warhammer)
*
***************************************************************/

namespace Server.Items
{
	public class WoodenWarhammer : Item
	{
		public WoodenWarhammer() : base()
		{
			Id = 2501;
			SellPrice = 144;
			AvailableClasses = 0x7FFF;
			Model = 19614;
			ObjectClass = 2;
			SubClass = 5;
			Level = 9;
			ReqLevel = 4;
			Name = "Wooden Warhammer";
			Name2 = "Wooden Warhammer";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 721;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3000;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Flags = 16;
			SetDamage( 12 , 18 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(War Hammer)
*
***************************************************************/

namespace Server.Items
{
	public class WarHammer : Item
	{
		public WarHammer() : base()
		{
			Id = 2525;
			SellPrice = 5297;
			AvailableClasses = 0x7FFF;
			Model = 22133;
			ObjectClass = 2;
			SubClass = 5;
			Level = 35;
			ReqLevel = 30;
			Name = "War Hammer";
			Name2 = "War Hammer";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 26489;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3500;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 85;
			SetDamage( 62 , 94 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(War Maul)
*
***************************************************************/

namespace Server.Items
{
	public class WarMaul : Item
	{
		public WarMaul() : base()
		{
			Id = 2533;
			SellPrice = 12221;
			AvailableClasses = 0x7FFF;
			Model = 22134;
			ObjectClass = 2;
			SubClass = 5;
			Level = 45;
			ReqLevel = 40;
			Name = "War Maul";
			Name2 = "War Maul";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 61107;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3300;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 85;
			SetDamage( 85 , 129 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Taran Icebreaker)
*
***************************************************************/

namespace Server.Items
{
	public class TaranIcebreaker : Item
	{
		public TaranIcebreaker() : base()
		{
			Id = 2915;
			Bonding = 2;
			SellPrice = 55289;
			AvailableClasses = 0x7FFF;
			Model = 19664;
			ObjectClass = 2;
			SubClass = 5;
			Level = 52;
			ReqLevel = 47;
			Name = "Taran Icebreaker";
			Name2 = "Taran Icebreaker";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 276447;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2300;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 120;
			SetSpell( 16415 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 91 , 137 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Coldridge Hammer)
*
***************************************************************/

namespace Server.Items
{
	public class ColdridgeHammer : Item
	{
		public ColdridgeHammer() : base()
		{
			Id = 3103;
			Bonding = 1;
			SellPrice = 466;
			AvailableClasses = 0x7FFF;
			Model = 8588;
			ObjectClass = 2;
			SubClass = 5;
			Level = 12;
			Name = "Coldridge Hammer";
			Name2 = "Coldridge Hammer";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2334;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2700;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 50;
			SetDamage( 18 , 27 , Resistances.Armor );
			StrBonus = 1;
			IqBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Beatstick)
*
***************************************************************/

namespace Server.Items
{
	public class Beatstick : Item
	{
		public Beatstick() : base()
		{
			Id = 3190;
			SellPrice = 99;
			AvailableClasses = 0x7FFF;
			Model = 6799;
			ObjectClass = 2;
			SubClass = 5;
			Level = 8;
			ReqLevel = 3;
			Name = "Beatstick";
			Name2 = "Beatstick";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 499;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2600;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 40;
			SetDamage( 9 , 14 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Oak Mallet)
*
***************************************************************/

namespace Server.Items
{
	public class OakMallet : Item
	{
		public OakMallet() : base()
		{
			Id = 3193;
			Bonding = 2;
			SellPrice = 2072;
			AvailableClasses = 0x7FFF;
			Model = 19545;
			ObjectClass = 2;
			SubClass = 5;
			Level = 21;
			ReqLevel = 16;
			Name = "Oak Mallet";
			Name2 = "Oak Mallet";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5193;
			BuyPrice = 10361;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3500;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 65;
			SetDamage( 38 , 58 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Black Malice)
*
***************************************************************/

namespace Server.Items
{
	public class BlackMalice : Item
	{
		public BlackMalice() : base()
		{
			Id = 3194;
			Bonding = 2;
			SellPrice = 2495;
			AvailableClasses = 0x7FFF;
			Model = 19622;
			ObjectClass = 2;
			SubClass = 5;
			Level = 21;
			ReqLevel = 16;
			Name = "Black Malice";
			Name2 = "Black Malice";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 12479;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3300;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 75;
			SetSpell( 18205 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 48 , 73 , Resistances.Armor );
			SetDamage( 1 , 6 , Resistances.Shadow );
		}
	}
}


/**************************************************************
*
*				(Battering Hammer)
*
***************************************************************/

namespace Server.Items
{
	public class BatteringHammer : Item
	{
		public BatteringHammer() : base()
		{
			Id = 3198;
			Bonding = 2;
			SellPrice = 2741;
			AvailableClasses = 0x7FFF;
			Model = 8585;
			ObjectClass = 2;
			SubClass = 5;
			Level = 23;
			ReqLevel = 18;
			Name = "Battering Hammer";
			Name2 = "Battering Hammer";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5202;
			BuyPrice = 13709;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3100;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 70;
			SetDamage( 37 , 57 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Dense Triangle Mace)
*
***************************************************************/

namespace Server.Items
{
	public class DenseTriangleMace : Item
	{
		public DenseTriangleMace() : base()
		{
			Id = 3203;
			Bonding = 2;
			SellPrice = 5436;
			AvailableClasses = 0x7FFF;
			Model = 5228;
			ObjectClass = 2;
			SubClass = 5;
			Level = 28;
			ReqLevel = 23;
			Name = "Dense Triangle Mace";
			Name2 = "Dense Triangle Mace";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 27184;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2400;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 95;
			SetDamage( 44 , 66 , Resistances.Armor );
			StrBonus = 10;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Conk Hammer)
*
***************************************************************/

namespace Server.Items
{
	public class ConkHammer : Item
	{
		public ConkHammer() : base()
		{
			Id = 3208;
			Bonding = 2;
			SellPrice = 25378;
			AvailableClasses = 0x7FFF;
			Model = 5232;
			ObjectClass = 2;
			SubClass = 5;
			Level = 48;
			ReqLevel = 43;
			Name = "Conk Hammer";
			Name2 = "Conk Hammer";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5274;
			BuyPrice = 126893;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3500;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 85;
			SetDamage( 104 , 157 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Farmer's Shovel)
*
***************************************************************/

namespace Server.Items
{
	public class FarmersShovel : Item
	{
		public FarmersShovel() : base()
		{
			Id = 3334;
			SellPrice = 68;
			AvailableClasses = 0x7FFF;
			Model = 7495;
			ObjectClass = 2;
			SubClass = 5;
			Level = 7;
			ReqLevel = 2;
			Name = "Farmer's Shovel";
			Name2 = "Farmer's Shovel";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 343;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3700;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 35;
			SetDamage( 11 , 17 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Bonecracker)
*
***************************************************************/

namespace Server.Items
{
	public class Bonecracker : Item
	{
		public Bonecracker() : base()
		{
			Id = 3440;
			Bonding = 1;
			SellPrice = 640;
			AvailableClasses = 0x7FFF;
			Model = 6806;
			ObjectClass = 2;
			SubClass = 5;
			Level = 13;
			Name = "Bonecracker";
			Name2 = "Bonecracker";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3202;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3200;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 50;
			SetDamage( 23 , 35 , Resistances.Armor );
			StrBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Trogg Beater)
*
***************************************************************/

namespace Server.Items
{
	public class TroggBeater : Item
	{
		public TroggBeater() : base()
		{
			Id = 3571;
			Bonding = 2;
			SellPrice = 2118;
			AvailableClasses = 0x7FFF;
			Model = 19546;
			ObjectClass = 2;
			SubClass = 5;
			Level = 21;
			ReqLevel = 16;
			Name = "Trogg Beater";
			Name2 = "Trogg Beater";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 10593;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3600;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 65;
			SetDamage( 39 , 60 , Resistances.Armor );
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Large War Club)
*
***************************************************************/

namespace Server.Items
{
	public class LargeWarClub : Item
	{
		public LargeWarClub() : base()
		{
			Id = 3782;
			SellPrice = 3451;
			AvailableClasses = 0x7FFF;
			Model = 19532;
			ObjectClass = 2;
			SubClass = 5;
			Level = 35;
			ReqLevel = 30;
			Name = "Large War Club";
			Name2 = "Large War Club";
			AvailableRaces = 0x1FF;
			BuyPrice = 17257;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3100;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 85;
			SetDamage( 35 , 53 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Solid Iron Maul)
*
***************************************************************/

namespace Server.Items
{
	public class SolidIronMaul : Item
	{
		public SolidIronMaul() : base()
		{
			Id = 3851;
			Bonding = 2;
			SellPrice = 6258;
			AvailableClasses = 0x7FFF;
			Model = 19647;
			ObjectClass = 2;
			SubClass = 5;
			Level = 31;
			ReqLevel = 26;
			Name = "Solid Iron Maul";
			Name2 = "Solid Iron Maul";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 31294;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3500;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 85;
			SetDamage( 59 , 89 , Resistances.Armor );
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Golden Iron Destroyer)
*
***************************************************************/

namespace Server.Items
{
	public class GoldenIronDestroyer : Item
	{
		public GoldenIronDestroyer() : base()
		{
			Id = 3852;
			Bonding = 2;
			SellPrice = 8360;
			AvailableClasses = 0x7FFF;
			Model = 15468;
			ObjectClass = 2;
			SubClass = 5;
			Level = 34;
			ReqLevel = 29;
			Name = "Golden Iron Destroyer";
			Name2 = "Golden Iron Destroyer";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 41804;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2750;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 85;
			SetDamage( 50 , 76 , Resistances.Armor );
			StrBonus = 11;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Crushing Maul)
*
***************************************************************/

namespace Server.Items
{
	public class CrushingMaul : Item
	{
		public CrushingMaul() : base()
		{
			Id = 4022;
			SellPrice = 12059;
			AvailableClasses = 0x7FFF;
			Model = 19526;
			ObjectClass = 2;
			SubClass = 5;
			Level = 50;
			ReqLevel = 45;
			Name = "Crushing Maul";
			Name2 = "Crushing Maul";
			AvailableRaces = 0x1FF;
			BuyPrice = 60297;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3300;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 85;
			SetDamage( 61 , 92 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Silver Spade)
*
***************************************************************/

namespace Server.Items
{
	public class SilverSpade : Item
	{
		public SilverSpade() : base()
		{
			Id = 4128;
			Bonding = 1;
			SellPrice = 14587;
			AvailableClasses = 0x7FFF;
			Model = 18269;
			ObjectClass = 2;
			SubClass = 5;
			Level = 41;
			Name = "Silver Spade";
			Name2 = "Silver Spade";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 72939;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3700;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 85;
			SetDamage( 89 , 134 , Resistances.Armor );
			StaminaBonus = 4;
			IqBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Servomechanic Sledgehammer)
*
***************************************************************/

namespace Server.Items
{
	public class ServomechanicSledgehammer : Item
	{
		public ServomechanicSledgehammer() : base()
		{
			Id = 4548;
			Bonding = 1;
			SellPrice = 15028;
			AvailableClasses = 0x7FFF;
			Model = 3151;
			ObjectClass = 2;
			SubClass = 5;
			Level = 41;
			Name = "Servomechanic Sledgehammer";
			Name2 = "Servomechanic Sledgehammer";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 100;
			Skill = 202;
			BuyPrice = 75143;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2200;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 85;
			SetSpell( 7560 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 53 , 80 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Spiked Club)
*
***************************************************************/

namespace Server.Items
{
	public class SpikedClub : Item
	{
		public SpikedClub() : base()
		{
			Id = 4564;
			Bonding = 2;
			SellPrice = 610;
			AvailableClasses = 0x7FFF;
			Model = 6813;
			ObjectClass = 2;
			SubClass = 5;
			Level = 13;
			ReqLevel = 8;
			Name = "Spiked Club";
			Name2 = "Spiked Club";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5175;
			BuyPrice = 3053;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3100;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 50;
			SetDamage( 22 , 34 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Birchwood Maul)
*
***************************************************************/

namespace Server.Items
{
	public class BirchwoodMaul : Item
	{
		public BirchwoodMaul() : base()
		{
			Id = 4570;
			Bonding = 2;
			SellPrice = 922;
			AvailableClasses = 0x7FFF;
			Model = 8586;
			ObjectClass = 2;
			SubClass = 5;
			Level = 15;
			ReqLevel = 10;
			Name = "Birchwood Maul";
			Name2 = "Birchwood Maul";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5175;
			BuyPrice = 4611;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3300;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 55;
			SetDamage( 26 , 40 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Ironwood Maul)
*
***************************************************************/

namespace Server.Items
{
	public class IronwoodMaul : Item
	{
		public IronwoodMaul() : base()
		{
			Id = 4777;
			Bonding = 2;
			SellPrice = 1408;
			AvailableClasses = 0x7FFF;
			Model = 19538;
			ObjectClass = 2;
			SubClass = 5;
			Level = 18;
			ReqLevel = 13;
			Name = "Ironwood Maul";
			Name2 = "Ironwood Maul";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7040;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2800;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 60;
			SetDamage( 26 , 40 , Resistances.Armor );
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Heavy Spiked Mace)
*
***************************************************************/

namespace Server.Items
{
	public class HeavySpikedMace : Item
	{
		public HeavySpikedMace() : base()
		{
			Id = 4778;
			Bonding = 2;
			SellPrice = 1470;
			AvailableClasses = 0x7FFF;
			Model = 6808;
			ObjectClass = 2;
			SubClass = 5;
			Level = 19;
			ReqLevel = 14;
			Name = "Heavy Spiked Mace";
			Name2 = "Heavy Spiked Mace";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7350;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3400;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 65;
			SetDamage( 34 , 51 , Resistances.Armor );
			StrBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Goblin Smasher)
*
***************************************************************/

namespace Server.Items
{
	public class GoblinSmasher : Item
	{
		public GoblinSmasher() : base()
		{
			Id = 4964;
			Bonding = 1;
			SellPrice = 503;
			AvailableClasses = 0x7FFF;
			Model = 19544;
			ObjectClass = 2;
			SubClass = 5;
			Level = 12;
			Name = "Goblin Smasher";
			Name2 = "Goblin Smasher";
			Quality = 2;
			AvailableRaces = 0x120;
			BuyPrice = 2516;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3100;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 50;
			SetDamage( 20 , 31 , Resistances.Armor );
			StrBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Rock Pulverizer)
*
***************************************************************/

namespace Server.Items
{
	public class RockPulverizer : Item
	{
		public RockPulverizer() : base()
		{
			Id = 4983;
			Bonding = 1;
			SellPrice = 16837;
			AvailableClasses = 0x7FFF;
			Model = 19596;
			ObjectClass = 2;
			SubClass = 5;
			Level = 42;
			Name = "Rock Pulverizer";
			Name2 = "Rock Pulverizer";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 84185;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3700;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 85;
			SetSpell( 15806 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 92 , 139 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Rhahk'Zor's Hammer)
*
***************************************************************/

namespace Server.Items
{
	public class RhahkZorsHammer : Item
	{
		public RhahkZorsHammer() : base()
		{
			Id = 5187;
			SellPrice = 1081;
			AvailableClasses = 0x7FFF;
			Model = 8600;
			ObjectClass = 2;
			SubClass = 5;
			Level = 20;
			ReqLevel = 15;
			Name = "Rhahk'Zor's Hammer";
			Name2 = "Rhahk'Zor's Hammer";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 5407;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3200;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 65;
			SetDamage( 30 , 46 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Demolition Hammer)
*
***************************************************************/

namespace Server.Items
{
	public class DemolitionHammer : Item
	{
		public DemolitionHammer() : base()
		{
			Id = 5322;
			Bonding = 1;
			SellPrice = 4016;
			AvailableClasses = 0x7FFF;
			Model = 19611;
			ObjectClass = 2;
			SubClass = 5;
			Level = 26;
			Name = "Demolition Hammer";
			Name2 = "Demolition Hammer";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 20081;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2300;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 80;
			SetDamage( 32 , 49 , Resistances.Armor );
			StrBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Stonewood Hammer)
*
***************************************************************/

namespace Server.Items
{
	public class StonewoodHammer : Item
	{
		public StonewoodHammer() : base()
		{
			Id = 5345;
			Bonding = 1;
			SellPrice = 705;
			AvailableClasses = 0x7FFF;
			Model = 8602;
			ObjectClass = 2;
			SubClass = 5;
			Level = 14;
			Name = "Stonewood Hammer";
			Name2 = "Stonewood Hammer";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3529;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3200;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 50;
			SetDamage( 24 , 37 , Resistances.Armor );
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Militia Warhammer)
*
***************************************************************/

namespace Server.Items
{
	public class MilitiaWarhammer : Item
	{
		public MilitiaWarhammer() : base()
		{
			Id = 5579;
			Bonding = 1;
			SellPrice = 32;
			AvailableClasses = 0x7FFF;
			Model = 19544;
			ObjectClass = 2;
			SubClass = 5;
			Level = 5;
			Name = "Militia Warhammer";
			Name2 = "Militia Warhammer";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 160;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2900;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 35;
			SetDamage( 6 , 9 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Thicket Hammer)
*
***************************************************************/

namespace Server.Items
{
	public class ThicketHammer : Item
	{
		public ThicketHammer() : base()
		{
			Id = 5595;
			Bonding = 1;
			SellPrice = 235;
			AvailableClasses = 0x7FFF;
			Model = 8298;
			ObjectClass = 2;
			SubClass = 5;
			Level = 11;
			Name = "Thicket Hammer";
			Name2 = "Thicket Hammer";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1177;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3100;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 45;
			SetDamage( 16 , 24 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Anvilmar Sledge)
*
***************************************************************/

namespace Server.Items
{
	public class AnvilmarSledge : Item
	{
		public AnvilmarSledge() : base()
		{
			Id = 5761;
			Bonding = 1;
			SellPrice = 30;
			AvailableClasses = 0x7FFF;
			Model = 19544;
			ObjectClass = 2;
			SubClass = 5;
			Level = 5;
			Name = "Anvilmar Sledge";
			Name2 = "Anvilmar Sledge";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 153;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3100;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 35;
			SetDamage( 6 , 10 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Glacial Stone)
*
***************************************************************/

namespace Server.Items
{
	public class GlacialStone : Item
	{
		public GlacialStone() : base()
		{
			Id = 5815;
			Bonding = 1;
			SellPrice = 5871;
			AvailableClasses = 0x7FFF;
			Model = 9057;
			ObjectClass = 2;
			SubClass = 5;
			Level = 31;
			Name = "Glacial Stone";
			Name2 = "Glacial Stone";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 29355;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3600;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 85;
			SetSpell( 20869 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 60 , 91 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Orc Crusher)
*
***************************************************************/

namespace Server.Items
{
	public class OrcCrusher : Item
	{
		public OrcCrusher() : base()
		{
			Id = 6093;
			Bonding = 1;
			SellPrice = 4418;
			AvailableClasses = 0x7FFF;
			Model = 19646;
			ObjectClass = 2;
			SubClass = 5;
			Level = 27;
			Name = "Orc Crusher";
			Name2 = "Orc Crusher";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 22091;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3600;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 80;
			SetDamage( 52 , 79 , Resistances.Armor );
			StrBonus = 8;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Burrowing Shovel)
*
***************************************************************/

namespace Server.Items
{
	public class BurrowingShovel : Item
	{
		public BurrowingShovel() : base()
		{
			Id = 6205;
			Bonding = 2;
			SellPrice = 922;
			AvailableClasses = 0x7FFF;
			Model = 7495;
			ObjectClass = 2;
			SubClass = 5;
			Level = 15;
			ReqLevel = 10;
			Name = "Burrowing Shovel";
			Name2 = "Burrowing Shovel";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4613;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2300;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 55;
			SetDamage( 18 , 28 , Resistances.Armor );
			AgilityBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Heavy Copper Maul)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyCopperMaul : Item
	{
		public HeavyCopperMaul() : base()
		{
			Id = 6214;
			SellPrice = 595;
			AvailableClasses = 0x7FFF;
			Model = 10642;
			ObjectClass = 2;
			SubClass = 5;
			Level = 16;
			ReqLevel = 11;
			Name = "Heavy Copper Maul";
			Name2 = "Heavy Copper Maul";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2978;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2800;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 55;
			SetDamage( 21 , 32 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(The Pacifier)
*
***************************************************************/

namespace Server.Items
{
	public class ThePacifier : Item
	{
		public ThePacifier() : base()
		{
			Id = 6327;
			Bonding = 2;
			SellPrice = 12823;
			AvailableClasses = 0x7FFF;
			Model = 11271;
			ObjectClass = 2;
			SubClass = 5;
			Level = 37;
			ReqLevel = 32;
			Name = "The Pacifier";
			Name2 = "The Pacifier";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 64118;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 4000;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 100;
			SetDamage( 104 , 156 , Resistances.Armor );
			StrBonus = 18;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Verigan's Fist)
*
***************************************************************/

namespace Server.Items
{
	public class VerigansFist : Item
	{
		public VerigansFist() : base()
		{
			Id = 6953;
			Bonding = 1;
			SellPrice = 7459;
			AvailableClasses = 0x02;
			Model = 13466;
			ObjectClass = 2;
			SubClass = 5;
			Level = 31;
			Name = "Verigan's Fist";
			Name2 = "Verigan's Fist";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 37297;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3200;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 100;
			SetDamage( 65 , 99 , Resistances.Armor );
			StaminaBonus = 7;
			IqBonus = 12;
			SpiritBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Whirlwind Warhammer)
*
***************************************************************/

namespace Server.Items
{
	public class WhirlwindWarhammer : Item
	{
		public WhirlwindWarhammer() : base()
		{
			Id = 6976;
			Bonding = 1;
			SellPrice = 17264;
			AvailableClasses = 0x01;
			Model = 25079;
			ObjectClass = 2;
			SubClass = 5;
			Level = 40;
			Name = "Whirlwind Warhammer";
			Name2 = "Whirlwind Warhammer";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 86321;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3400;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 100;
			SetDamage( 97 , 146 , Resistances.Armor );
			StaminaBonus = 14;
			StrBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Smite's Mighty Hammer)
*
***************************************************************/

namespace Server.Items
{
	public class SmitesMightyHammer : Item
	{
		public SmitesMightyHammer() : base()
		{
			Id = 7230;
			Bonding = 1;
			SellPrice = 3103;
			AvailableClasses = 0x7FFF;
			Model = 19610;
			ObjectClass = 2;
			SubClass = 5;
			Level = 23;
			ReqLevel = 18;
			Name = "Smite's Mighty Hammer";
			Name2 = "Smite's Mighty Hammer";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 15515;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3500;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 80;
			SetDamage( 55 , 83 , Resistances.Armor );
			StrBonus = 11;
			AgilityBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Mograine's Might)
*
***************************************************************/

namespace Server.Items
{
	public class MograinesMight : Item
	{
		public MograinesMight() : base()
		{
			Id = 7723;
			Bonding = 1;
			SellPrice = 22567;
			AvailableClasses = 0x7FFF;
			Model = 21252;
			ObjectClass = 2;
			SubClass = 5;
			Level = 44;
			ReqLevel = 39;
			Name = "Mograine's Might";
			Name2 = "Mograine's Might";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 112836;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2800;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 100;
			SetDamage( 87 , 131 , Resistances.Armor );
			IqBonus = 16;
			StaminaBonus = 17;
		}
	}
}


/**************************************************************
*
*				(Cobalt Crusher)
*
***************************************************************/

namespace Server.Items
{
	public class CobaltCrusher : Item
	{
		public CobaltCrusher() : base()
		{
			Id = 7730;
			Bonding = 2;
			SellPrice = 10146;
			AvailableClasses = 0x7FFF;
			Model = 15466;
			ObjectClass = 2;
			SubClass = 5;
			Level = 34;
			ReqLevel = 29;
			Name = "Cobalt Crusher";
			Name2 = "Cobalt Crusher";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 50732;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3200;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 100;
			SetSpell( 18204 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 74 , 111 , Resistances.Armor );
			SetDamage( 5 , 5 , Resistances.Frost );
		}
	}
}


/**************************************************************
*
*				(Bronze Warhammer)
*
***************************************************************/

namespace Server.Items
{
	public class BronzeWarhammer : Item
	{
		public BronzeWarhammer() : base()
		{
			Id = 7956;
			SellPrice = 1944;
			AvailableClasses = 0x7FFF;
			Model = 16146;
			ObjectClass = 2;
			SubClass = 5;
			Level = 25;
			ReqLevel = 20;
			Name = "Bronze Warhammer";
			Name2 = "Bronze Warhammer";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 9722;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3100;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 75;
			SetDamage( 37 , 57 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(The Shoveler)
*
***************************************************************/

namespace Server.Items
{
	public class TheShoveler : Item
	{
		public TheShoveler() : base()
		{
			Id = 9391;
			Bonding = 2;
			SellPrice = 12831;
			AvailableClasses = 0x01;
			Model = 18269;
			ObjectClass = 2;
			SubClass = 5;
			Level = 37;
			ReqLevel = 32;
			Name = "The Shoveler";
			Name2 = "The Shoveler";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 64158;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3400;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 100;
			SetSpell( 9331 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 88 , 133 , Resistances.Armor );
			StaminaBonus = 15;
		}
	}
}


/**************************************************************
*
*				(The Rockpounder)
*
***************************************************************/

namespace Server.Items
{
	public class TheRockpounder : Item
	{
		public TheRockpounder() : base()
		{
			Id = 9413;
			Bonding = 1;
			SellPrice = 32248;
			AvailableClasses = 0x7FFF;
			Model = 19620;
			ObjectClass = 2;
			SubClass = 5;
			Level = 49;
			ReqLevel = 44;
			Name = "The Rockpounder";
			Name2 = "The Rockpounder";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 161244;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3700;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 100;
			SetSpell( 7598 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 126 , 190 , Resistances.Armor );
			StrBonus = 5;
		}
	}
}


/**************************************************************
*
*				(The Jackhammer)
*
***************************************************************/

namespace Server.Items
{
	public class TheJackhammer : Item
	{
		public TheJackhammer() : base()
		{
			Id = 9423;
			Bonding = 2;
			SellPrice = 25463;
			AvailableClasses = 0x7FFF;
			Model = 18324;
			ObjectClass = 2;
			SubClass = 5;
			Level = 45;
			ReqLevel = 40;
			Name = "The Jackhammer";
			Name2 = "The Jackhammer";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 127319;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2500;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 100;
			SetSpell( 13533 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 79 , 119 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Manual Crowd Pummeler)
*
***************************************************************/

namespace Server.Items
{
	public class ManualCrowdPummeler : Item
	{
		public ManualCrowdPummeler() : base()
		{
			Id = 9449;
			Bonding = 1;
			SellPrice = 9564;
			AvailableClasses = 0x7FFF;
			Model = 19645;
			ObjectClass = 2;
			SubClass = 5;
			Level = 34;
			ReqLevel = 29;
			Name = "Manual Crowd Pummeler";
			Name2 = "Manual Crowd Pummeler";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 47822;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2000;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 100;
			SetSpell( 13494 , 0 , 3 , -1 , 0 , -1 );
			SetDamage( 46 , 70 , Resistances.Armor );
			StrBonus = 16;
			AgilityBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Mechanic's Pipehammer)
*
***************************************************************/

namespace Server.Items
{
	public class MechanicsPipehammer : Item
	{
		public MechanicsPipehammer() : base()
		{
			Id = 9604;
			Bonding = 1;
			SellPrice = 5632;
			AvailableClasses = 0x7FFF;
			Model = 18531;
			ObjectClass = 2;
			SubClass = 5;
			Level = 30;
			Name = "Mechanic's Pipehammer";
			Name2 = "Mechanic's Pipehammer";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 28160;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2800;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 85;
			SetDamage( 45 , 69 , Resistances.Armor );
			StaminaBonus = 10;
			SpiritBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Tok'kar's Murloc Basher)
*
***************************************************************/

namespace Server.Items
{
	public class TokkarsMurlocBasher : Item
	{
		public TokkarsMurlocBasher() : base()
		{
			Id = 9678;
			Bonding = 1;
			SellPrice = 17485;
			AvailableClasses = 0x7FFF;
			Model = 5233;
			ObjectClass = 2;
			SubClass = 5;
			Level = 43;
			Name = "Tok'kar's Murloc Basher";
			Name2 = "Tok'kar's Murloc Basher";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 87429;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2800;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 85;
			SetDamage( 72 , 109 , Resistances.Armor );
			StaminaBonus = 18;
		}
	}
}


/**************************************************************
*
*				(Ragehammer)
*
***************************************************************/

namespace Server.Items
{
	public class Ragehammer : Item
	{
		public Ragehammer() : base()
		{
			Id = 10626;
			Bonding = 2;
			SellPrice = 36732;
			AvailableClasses = 0x7FFF;
			Model = 19617;
			ObjectClass = 2;
			SubClass = 5;
			Level = 50;
			ReqLevel = 45;
			Name = "Ragehammer";
			Name2 = "Ragehammer";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 183661;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3700;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 100;
			SetSpell( 12686 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 128 , 193 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Cragwood Maul)
*
***************************************************************/

namespace Server.Items
{
	public class CragwoodMaul : Item
	{
		public CragwoodMaul() : base()
		{
			Id = 11265;
			Bonding = 1;
			SellPrice = 16484;
			AvailableClasses = 0x7FFF;
			Model = 28629;
			ObjectClass = 2;
			SubClass = 5;
			Level = 42;
			Name = "Cragwood Maul";
			Name2 = "Cragwood Maul";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 82424;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2800;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 85;
			SetDamage( 70 , 105 , Resistances.Armor );
			StaminaBonus = 17;
		}
	}
}


/**************************************************************
*
*				(Dark Iron Pulverizer)
*
***************************************************************/

namespace Server.Items
{
	public class DarkIronPulverizer : Item
	{
		public DarkIronPulverizer() : base()
		{
			Id = 11608;
			Bonding = 2;
			SellPrice = 45760;
			AvailableClasses = 0x7FFF;
			Model = 25046;
			ObjectClass = 2;
			SubClass = 5;
			Level = 55;
			ReqLevel = 50;
			Name = "Dark Iron Pulverizer";
			Name2 = "Dark Iron Pulverizer";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 228803;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3700;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 100;
			SetSpell( 15283 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 140 , 211 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Force of Magma)
*
***************************************************************/

namespace Server.Items
{
	public class ForceOfMagma : Item
	{
		public ForceOfMagma() : base()
		{
			Id = 11803;
			Bonding = 1;
			SellPrice = 41814;
			AvailableClasses = 0x7FFF;
			Model = 21793;
			ObjectClass = 2;
			SubClass = 5;
			Level = 56;
			ReqLevel = 51;
			Name = "Force of Magma";
			Name2 = "Force of Magma";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 209074;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3200;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 85;
			SetSpell( 18086 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 111 , 167 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Impervious Giant)
*
***************************************************************/

namespace Server.Items
{
	public class ImperviousGiant : Item
	{
		public ImperviousGiant() : base()
		{
			Id = 11921;
			Resistance[0] = 30;
			Bonding = 1;
			SellPrice = 54167;
			AvailableClasses = 0x7FFF;
			Model = 25625;
			ObjectClass = 2;
			SubClass = 5;
			Level = 57;
			ReqLevel = 52;
			Name = "Impervious Giant";
			Name2 = "Impervious Giant";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 270836;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2700;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 100;
			SetSpell( 15464 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 7598 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 105 , 159 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(The Judge's Gavel)
*
***************************************************************/

namespace Server.Items
{
	public class TheJudgesGavel : Item
	{
		public TheJudgesGavel() : base()
		{
			Id = 12528;
			Bonding = 2;
			SellPrice = 37833;
			AvailableClasses = 0x7FFF;
			Model = 28673;
			ObjectClass = 2;
			SubClass = 5;
			Level = 52;
			ReqLevel = 47;
			Name = "The Judge's Gavel";
			Name2 = "The Judge's Gavel";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 189165;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2900;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 100;
			SetSpell( 16451 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 104 , 157 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Enchanted Battlehammer)
*
***************************************************************/

namespace Server.Items
{
	public class EnchantedBattlehammer : Item
	{
		public EnchantedBattlehammer() : base()
		{
			Id = 12776;
			Bonding = 2;
			SellPrice = 48124;
			AvailableClasses = 0x7FFF;
			Model = 23240;
			ObjectClass = 2;
			SubClass = 5;
			Level = 56;
			ReqLevel = 51;
			Name = "Enchanted Battlehammer";
			Name2 = "Enchanted Battlehammer";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 240624;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2600;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 100;
			SetSpell( 13665 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 15465 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 100 , 150 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Hammer of the Titans)
*
***************************************************************/

namespace Server.Items
{
	public class HammerOfTheTitans : Item
	{
		public HammerOfTheTitans() : base()
		{
			Id = 12796;
			Bonding = 2;
			SellPrice = 70912;
			AvailableClasses = 0x7FFF;
			Model = 25047;
			ObjectClass = 2;
			SubClass = 5;
			Level = 63;
			ReqLevel = 58;
			Name = "Hammer of the Titans";
			Name2 = "Hammer of the Titans";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 354564;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3800;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 100;
			SetSpell( 56 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 163 , 246 , Resistances.Armor );
			StrBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Seeping Willow)
*
***************************************************************/

namespace Server.Items
{
	public class SeepingWillow : Item
	{
		public SeepingWillow() : base()
		{
			Id = 12969;
			Bonding = 1;
			SellPrice = 70884;
			AvailableClasses = 0x7FFF;
			Model = 23557;
			ObjectClass = 2;
			SubClass = 5;
			Level = 63;
			ReqLevel = 58;
			Name = "Seeping Willow";
			Name2 = "Seeping Willow";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 354420;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3300;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 100;
			SetSpell( 17196 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 142 , 214 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Rakzur Club)
*
***************************************************************/

namespace Server.Items
{
	public class RakzurClub : Item
	{
		public RakzurClub() : base()
		{
			Id = 12983;
			Bonding = 2;
			SellPrice = 2362;
			AvailableClasses = 0x7FFF;
			Model = 28809;
			ObjectClass = 2;
			SubClass = 5;
			Level = 21;
			ReqLevel = 16;
			Name = "Rakzur Club";
			Name2 = "Rakzur Club";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 11813;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2600;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 75;
			SetDamage( 38 , 57 , Resistances.Armor );
			StrBonus = 4;
			IqBonus = 5;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Viscous Hammer)
*
***************************************************************/

namespace Server.Items
{
	public class ViscousHammer : Item
	{
		public ViscousHammer() : base()
		{
			Id = 13045;
			Bonding = 2;
			SellPrice = 10809;
			AvailableClasses = 0x7FFF;
			Model = 25627;
			ObjectClass = 2;
			SubClass = 5;
			Level = 35;
			ReqLevel = 30;
			Name = "Viscous Hammer";
			Name2 = "Viscous Hammer";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 54048;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2900;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 100;
			SetSpell( 15806 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 70 , 105 , Resistances.Armor );
			StrBonus = 3;
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Blanchard's Stout)
*
***************************************************************/

namespace Server.Items
{
	public class BlanchardsStout : Item
	{
		public BlanchardsStout() : base()
		{
			Id = 13046;
			Bonding = 2;
			SellPrice = 35042;
			AvailableClasses = 0x7FFF;
			Model = 28677;
			Resistance[2] = 5;
			ObjectClass = 2;
			SubClass = 5;
			Level = 50;
			ReqLevel = 45;
			Name = "Blanchard's Stout";
			Name2 = "Blanchard's Stout";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 175213;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3100;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 100;
			SetDamage( 107 , 162 , Resistances.Armor );
			StrBonus = 20;
			StaminaBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Twig of the World Tree)
*
***************************************************************/

namespace Server.Items
{
	public class TwigOfTheWorldTree : Item
	{
		public TwigOfTheWorldTree() : base()
		{
			Id = 13047;
			Bonding = 2;
			SellPrice = 56588;
			AvailableClasses = 0x7FFF;
			Model = 25626;
			ObjectClass = 2;
			SubClass = 5;
			Level = 58;
			ReqLevel = 53;
			Name = "Twig of the World Tree";
			Name2 = "Twig of the World Tree";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 282942;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3700;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 100;
			SetDamage( 147 , 221 , Resistances.Armor );
			StrBonus = 14;
			IqBonus = 12;
			StaminaBonus = 21;
		}
	}
}


/**************************************************************
*
*				(Fist of Omokk)
*
***************************************************************/

namespace Server.Items
{
	public class FistOfOmokk : Item
	{
		public FistOfOmokk() : base()
		{
			Id = 13167;
			Bonding = 1;
			SellPrice = 59410;
			AvailableClasses = 0x7FFF;
			Model = 25180;
			ObjectClass = 2;
			SubClass = 5;
			Level = 60;
			ReqLevel = 55;
			Name = "Fist of Omokk";
			Name2 = "Fist of Omokk";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 297052;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3300;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 100;
			SetDamage( 135 , 204 , Resistances.Armor );
			StrBonus = 29;
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Malown's Slam)
*
***************************************************************/

namespace Server.Items
{
	public class MalownsSlam : Item
	{
		public MalownsSlam() : base()
		{
			Id = 13393;
			Bonding = 1;
			SellPrice = 62380;
			AvailableClasses = 0x7FFF;
			Model = 25629;
			ObjectClass = 2;
			SubClass = 5;
			Level = 61;
			ReqLevel = 56;
			Name = "Malown's Slam";
			Name2 = "Malown's Slam";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 311904;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3800;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 100;
			SetSpell( 17500 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 158 , 238 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Bulky Maul)
*
***************************************************************/

namespace Server.Items
{
	public class BulkyMaul : Item
	{
		public BulkyMaul() : base()
		{
			Id = 13821;
			SellPrice = 17993;
			AvailableClasses = 0x7FFF;
			Model = 28691;
			ObjectClass = 2;
			SubClass = 5;
			Level = 57;
			ReqLevel = 52;
			Name = "Bulky Maul";
			Name2 = "Bulky Maul";
			AvailableRaces = 0x1FF;
			BuyPrice = 89968;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3600;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 85;
			SetDamage( 76 , 115 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Frightskull Shaft)
*
***************************************************************/

namespace Server.Items
{
	public class FrightskullShaft : Item
	{
		public FrightskullShaft() : base()
		{
			Id = 14531;
			Bonding = 1;
			SellPrice = 59891;
			AvailableClasses = 0x7FFF;
			Model = 25148;
			ObjectClass = 2;
			SubClass = 5;
			Level = 59;
			ReqLevel = 54;
			Name = "Frightskull Shaft";
			Name2 = "Frightskull Shaft";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 299458;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3400;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 100;
			SetSpell( 18633 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 137 , 206 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Hefty Battlehammer)
*
***************************************************************/

namespace Server.Items
{
	public class HeftyBattlehammer : Item
	{
		public HeftyBattlehammer() : base()
		{
			Id = 15259;
			Bonding = 2;
			SellPrice = 3306;
			AvailableClasses = 0x7FFF;
			Model = 28548;
			ObjectClass = 2;
			SubClass = 5;
			Level = 25;
			ReqLevel = 20;
			Name = "Hefty Battlehammer";
			Name2 = "Hefty Battlehammer";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5211;
			BuyPrice = 16533;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3200;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 75;
			SetDamage( 43 , 65 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Stone Hammer)
*
***************************************************************/

namespace Server.Items
{
	public class StoneHammer : Item
	{
		public StoneHammer() : base()
		{
			Id = 15260;
			Bonding = 2;
			SellPrice = 11556;
			AvailableClasses = 0x7FFF;
			Model = 28468;
			ObjectClass = 2;
			SubClass = 5;
			Level = 38;
			ReqLevel = 33;
			Name = "Stone Hammer";
			Name2 = "Stone Hammer";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5247;
			BuyPrice = 57783;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3000;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 85;
			SetDamage( 64 , 96 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Sequoia Branch)
*
***************************************************************/

namespace Server.Items
{
	public class SequoiaBranch : Item
	{
		public SequoiaBranch() : base()
		{
			Id = 15261;
			Bonding = 2;
			SellPrice = 13530;
			AvailableClasses = 0x7FFF;
			Model = 28524;
			ObjectClass = 2;
			SubClass = 5;
			Level = 40;
			ReqLevel = 35;
			Name = "Sequoia Branch";
			Name2 = "Sequoia Branch";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5256;
			BuyPrice = 67653;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3800;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 85;
			SetDamage( 88 , 132 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Greater Maul)
*
***************************************************************/

namespace Server.Items
{
	public class GreaterMaul : Item
	{
		public GreaterMaul() : base()
		{
			Id = 15262;
			Bonding = 2;
			SellPrice = 21552;
			AvailableClasses = 0x7FFF;
			Model = 28540;
			ObjectClass = 2;
			SubClass = 5;
			Level = 46;
			ReqLevel = 41;
			Name = "Greater Maul";
			Name2 = "Greater Maul";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5274;
			BuyPrice = 107763;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3400;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 85;
			SetDamage( 97 , 146 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Royal Mallet)
*
***************************************************************/

namespace Server.Items
{
	public class RoyalMallet : Item
	{
		public RoyalMallet() : base()
		{
			Id = 15263;
			Bonding = 2;
			SellPrice = 28889;
			AvailableClasses = 0x7FFF;
			Model = 28534;
			ObjectClass = 2;
			SubClass = 5;
			Level = 50;
			ReqLevel = 45;
			Name = "Royal Mallet";
			Name2 = "Royal Mallet";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5283;
			BuyPrice = 144448;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2700;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 85;
			SetDamage( 83 , 126 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Backbreaker)
*
***************************************************************/

namespace Server.Items
{
	public class Backbreaker : Item
	{
		public Backbreaker() : base()
		{
			Id = 15264;
			Bonding = 2;
			SellPrice = 41517;
			AvailableClasses = 0x7FFF;
			Model = 28311;
			ObjectClass = 2;
			SubClass = 5;
			Level = 56;
			ReqLevel = 51;
			Name = "Backbreaker";
			Name2 = "Backbreaker";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5301;
			BuyPrice = 207589;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3100;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 85;
			SetDamage( 107 , 162 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Painbringer)
*
***************************************************************/

namespace Server.Items
{
	public class Painbringer : Item
	{
		public Painbringer() : base()
		{
			Id = 15265;
			Bonding = 2;
			SellPrice = 46823;
			AvailableClasses = 0x7FFF;
			Model = 28499;
			ObjectClass = 2;
			SubClass = 5;
			Level = 58;
			ReqLevel = 53;
			Name = "Painbringer";
			Name2 = "Painbringer";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5310;
			BuyPrice = 234116;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2800;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 85;
			SetDamage( 100 , 151 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Fierce Mauler)
*
***************************************************************/

namespace Server.Items
{
	public class FierceMauler : Item
	{
		public FierceMauler() : base()
		{
			Id = 15266;
			Bonding = 2;
			SellPrice = 54405;
			AvailableClasses = 0x7FFF;
			Model = 28526;
			ObjectClass = 2;
			SubClass = 5;
			Level = 61;
			ReqLevel = 56;
			Name = "Fierce Mauler";
			Name2 = "Fierce Mauler";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5319;
			BuyPrice = 272026;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3300;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 85;
			SetDamage( 125 , 188 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Brutehammer)
*
***************************************************************/

namespace Server.Items
{
	public class Brutehammer : Item
	{
		public Brutehammer() : base()
		{
			Id = 15267;
			Bonding = 2;
			SellPrice = 60203;
			AvailableClasses = 0x7FFF;
			Model = 28674;
			ObjectClass = 2;
			SubClass = 5;
			Level = 63;
			ReqLevel = 58;
			Name = "Brutehammer";
			Name2 = "Brutehammer";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5319;
			BuyPrice = 301018;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3400;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 85;
			SetDamage( 133 , 200 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Shimmering Platinum Warhammer)
*
***************************************************************/

namespace Server.Items
{
	public class ShimmeringPlatinumWarhammer : Item
	{
		public ShimmeringPlatinumWarhammer() : base()
		{
			Id = 15418;
			Bonding = 1;
			SellPrice = 73597;
			AvailableClasses = 0x7FFF;
			Model = 27412;
			ObjectClass = 2;
			SubClass = 5;
			Level = 63;
			Name = "Shimmering Platinum Warhammer";
			Name2 = "Shimmering Platinum Warhammer";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 367988;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3100;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 100;
			SetSpell( 19874 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 142 , 192 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Brute Hammer)
*
***************************************************************/

namespace Server.Items
{
	public class BruteHammer : Item
	{
		public BruteHammer() : base()
		{
			Id = 15464;
			Bonding = 1;
			SellPrice = 4504;
			AvailableClasses = 0x7FFF;
			Model = 28096;
			ObjectClass = 2;
			SubClass = 5;
			Level = 28;
			Name = "Brute Hammer";
			Name2 = "Brute Hammer";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 22523;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3300;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 80;
			SetDamage( 50 , 76 , Resistances.Armor );
			StaminaBonus = 8;
			StrBonus = 4;
			AgilityBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Earthshaker)
*
***************************************************************/

namespace Server.Items
{
	public class Earthshaker : Item
	{
		public Earthshaker() : base()
		{
			Id = 17073;
			Bonding = 1;
			SellPrice = 113631;
			AvailableClasses = 0x7FFF;
			Model = 29168;
			ObjectClass = 2;
			SubClass = 5;
			Level = 66;
			ReqLevel = 60;
			Name = "Earthshaker";
			Name2 = "Earthshaker";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 568157;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3500;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 120;
			SetSpell( 21152 , 2 , 0 , -1 , 0 , -1 );
			SetSpell( 9332 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 175 , 263 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Sulfuras, Hand of Ragnaros)
*
***************************************************************/

namespace Server.Items
{
	public class SulfurasHandOfRagnaros : Item
	{
		public SulfurasHandOfRagnaros() : base()
		{
			Id = 17182;
			Bonding = 1;
			SellPrice = 332623;
			AvailableClasses = 0x7FFF;
			Model = 29698;
			Resistance[2] = 30;
			ObjectClass = 2;
			SubClass = 5;
			Level = 80;
			ReqLevel = 60;
			Name = "Sulfuras, Hand of Ragnaros";
			Name2 = "Sulfuras, Hand of Ragnaros";
			Quality = 5;
			AvailableRaces = 0x1FF;
			BuyPrice = 1663117;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3700;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 1;
			Durability = 145;
			SetSpell( 21162 , 2 , 0 , -1 , 0 , -1 );
			SetSpell( 21142 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 223 , 372 , Resistances.Armor );
			StrBonus = 12;
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Sulfuron Hammer)
*
***************************************************************/

namespace Server.Items
{
	public class SulfuronHammer : Item
	{
		public SulfuronHammer() : base()
		{
			Id = 17193;
			Bonding = 2;
			SellPrice = 122311;
			AvailableClasses = 0x7FFF;
			Model = 29699;
			ObjectClass = 2;
			SubClass = 5;
			Level = 67;
			ReqLevel = 60;
			Name = "Sulfuron Hammer";
			Name2 = "Sulfuron Hammer";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 611555;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3700;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 120;
			SetSpell( 21159 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 176 , 295 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Princess Theradras' Scepter)
*
***************************************************************/

namespace Server.Items
{
	public class PrincessTheradrasScepter : Item
	{
		public PrincessTheradrasScepter() : base()
		{
			Id = 17766;
			Bonding = 1;
			SellPrice = 44863;
			AvailableClasses = 0x7FFF;
			Model = 29939;
			ObjectClass = 2;
			SubClass = 5;
			Level = 54;
			ReqLevel = 49;
			Name = "Princess Theradras' Scepter";
			Name2 = "Princess Theradras' Scepter";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 224317;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3400;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 100;
			SetSpell( 21961 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 126 , 190 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Bonecrusher)
*
***************************************************************/

namespace Server.Items
{
	public class Bonecrusher : Item
	{
		public Bonecrusher() : base()
		{
			Id = 18420;
			Bonding = 1;
			SellPrice = 71236;
			AvailableClasses = 0x7FFF;
			Model = 30792;
			ObjectClass = 2;
			SubClass = 5;
			Level = 63;
			Name = "Bonecrusher";
			Name2 = "Bonecrusher";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 356184;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3000;
			Stackable = 1;
			Material = 2;
			Sheath = 1;
			Durability = 100;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 129 , 194 , Resistances.Armor );
			StrBonus = 30;
		}
	}
}


/**************************************************************
*
*				(Skullcracking Mace)
*
***************************************************************/

namespace Server.Items
{
	public class SkullcrackingMace : Item
	{
		public SkullcrackingMace() : base()
		{
			Id = 18481;
			Bonding = 1;
			SellPrice = 51451;
			AvailableClasses = 0x7FFF;
			Model = 5233;
			ObjectClass = 2;
			SubClass = 5;
			Level = 60;
			ReqLevel = 55;
			Name = "Skullcracking Mace";
			Name2 = "Skullcracking Mace";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 257259;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3200;
			Stackable = 1;
			Material = 6;
			Sheath = 1;
			Durability = 85;
			SetDamage( 119 , 179 , Resistances.Armor );
			StrBonus = 22;
			AgilityBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Unyielding Maul)
*
***************************************************************/

namespace Server.Items
{
	public class UnyieldingMaul : Item
	{
		public UnyieldingMaul() : base()
		{
			Id = 18531;
			Resistance[0] = 250;
			Bonding = 1;
			SellPrice = 65383;
			AvailableClasses = 0x7FFF;
			Model = 30867;
			ObjectClass = 2;
			SubClass = 5;
			Level = 62;
			ReqLevel = 57;
			Name = "Unyielding Maul";
			Name2 = "Unyielding Maul";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 326918;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3200;
			Stackable = 1;
			Material = 6;
			Sheath = 1;
			Durability = 100;
			SetSpell( 13387 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 135 , 204 , Resistances.Armor );
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Hammer of the Grand Crusader)
*
***************************************************************/

namespace Server.Items
{
	public class HammerOfTheGrandCrusader : Item
	{
		public HammerOfTheGrandCrusader() : base()
		{
			Id = 18717;
			Bonding = 1;
			SellPrice = 68818;
			AvailableClasses = 0x7FFF;
			Model = 23239;
			ObjectClass = 2;
			SubClass = 5;
			Level = 63;
			ReqLevel = 58;
			Name = "Hammer of the Grand Crusader";
			Name2 = "Hammer of the Grand Crusader";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 344091;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2700;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 100;
			SetSpell( 9408 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 116 , 175 , Resistances.Armor );
			SpiritBonus = 26;
			StaminaBonus = 10;
			IqBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Finkle's Lava Dredger)
*
***************************************************************/

namespace Server.Items
{
	public class FinklesLavaDredger : Item
	{
		public FinklesLavaDredger() : base()
		{
			Id = 18803;
			Bonding = 1;
			SellPrice = 135594;
			AvailableClasses = 0x7FFF;
			Description = "Property of Finkle Einhorn, Grandmaster Adventurer";
			Model = 31265;
			Resistance[2] = 15;
			ObjectClass = 2;
			SubClass = 5;
			Level = 70;
			ReqLevel = 60;
			Name = "Finkle's Lava Dredger";
			Name2 = "Finkle's Lava Dredger";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 677972;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 2900;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 120;
			SetSpell( 21365 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 155 , 234 , Resistances.Armor );
			StaminaBonus = 25;
			SpiritBonus = 24;
		}
	}
}


/**************************************************************
*
*				(Grand Marshal's Battle Hammer)
*
***************************************************************/

namespace Server.Items
{
	public class GrandMarshalsBattleHammer : Item
	{
		public GrandMarshalsBattleHammer() : base()
		{
			Id = 18867;
			Bonding = 1;
			SellPrice = 62542;
			AvailableClasses = 0x7FFF;
			Model = 31954;
			ObjectClass = 2;
			SubClass = 5;
			Level = 78;
			ReqLevel = 60;
			Name = "Grand Marshal's Battle Hammer";
			Name2 = "Grand Marshal's Battle Hammer";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 312712;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3800;
			Stackable = 1;
			Material = 2;
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
*				(High Warlord's Pulverizer)
*
***************************************************************/

namespace Server.Items
{
	public class HighWarlordsPulverizer : Item
	{
		public HighWarlordsPulverizer() : base()
		{
			Id = 18868;
			Bonding = 1;
			SellPrice = 62763;
			AvailableClasses = 0x7FFF;
			Model = 31750;
			ObjectClass = 2;
			SubClass = 5;
			Level = 78;
			ReqLevel = 60;
			Name = "High Warlord's Pulverizer";
			Name2 = "High Warlord's Pulverizer";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 313819;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3800;
			Stackable = 1;
			Material = 2;
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
*				(The Unstoppable Force)
*
***************************************************************/

namespace Server.Items
{
	public class TheUnstoppableForce : Item
	{
		public TheUnstoppableForce() : base()
		{
			Id = 19323;
			Bonding = 1;
			SellPrice = 312980;
			AvailableClasses = 0x7FFF;
			Model = 31817;
			ObjectClass = 2;
			SubClass = 5;
			Level = 65;
			ReqLevel = 60;
			Name = "The Unstoppable Force";
			Name2 = "The Unstoppable Force";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 1564900;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3800;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 1;
			Durability = 120;
			Flags = 32768;
			SetSpell( 7598 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 23699 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 175 , 292 , Resistances.Armor );
			StrBonus = 19;
			StaminaBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Draconic Maul)
*
***************************************************************/

namespace Server.Items
{
	public class DraconicMaul : Item
	{
		public DraconicMaul() : base()
		{
			Id = 19358;
			Bonding = 1;
			SellPrice = 130638;
			AvailableClasses = 0x7FFF;
			Model = 31877;
			ObjectClass = 2;
			SubClass = 5;
			Level = 70;
			ReqLevel = 60;
			Name = "Draconic Maul";
			Name2 = "Draconic Maul";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 653192;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3500;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 120;
			SetSpell( 7598 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 187 , 282 , Resistances.Armor );
			StrBonus = 27;
			StaminaBonus = 19;
		}
	}
}


