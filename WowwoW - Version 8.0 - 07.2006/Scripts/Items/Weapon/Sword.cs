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
*				(Worn Shortsword)
*
***************************************************************/

namespace Server.Items
{
	public class WornShortsword : Item
	{
		public WornShortsword() : base()
		{
			Id = 25;
			SellPrice = 7;
			AvailableClasses = 0x7FFF;
			Model = 1542;
			ObjectClass = 2;
			SubClass = 7;
			Level = 2;
			ReqLevel = 1;
			Name = "Worn Shortsword";
			Name2 = "Worn Shortsword";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 35;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1900;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 20;
			Language = 1;
			SetDamage( 1 , 3 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Notched Shortsword)
*
***************************************************************/

namespace Server.Items
{
	public class NotchedShortsword : Item
	{
		public NotchedShortsword() : base()
		{
			Id = 727;
			Bonding = 2;
			SellPrice = 244;
			AvailableClasses = 0x7FFF;
			Model = 26577;
			ObjectClass = 2;
			SubClass = 7;
			Level = 10;
			ReqLevel = 5;
			Name = "Notched Shortsword";
			Name2 = "Notched Shortsword";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5168;
			BuyPrice = 1224;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2100;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 40;
			SetDamage( 8 , 15 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Dragonmaw Shortsword)
*
***************************************************************/

namespace Server.Items
{
	public class DragonmawShortsword : Item
	{
		public DragonmawShortsword() : base()
		{
			Id = 753;
			Bonding = 2;
			SellPrice = 3842;
			AvailableClasses = 0x7FFF;
			Model = 20094;
			ObjectClass = 2;
			SubClass = 7;
			Level = 28;
			ReqLevel = 23;
			Name = "Dragonmaw Shortsword";
			Name2 = "Dragonmaw Shortsword";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 19211;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2200;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 70;
			SetDamage( 22 , 42 , Resistances.Armor );
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Shortsword of Vengeance)
*
***************************************************************/

namespace Server.Items
{
	public class ShortswordOfVengeance : Item
	{
		public ShortswordOfVengeance() : base()
		{
			Id = 754;
			Bonding = 2;
			SellPrice = 23556;
			AvailableClasses = 0x7FFF;
			Model = 20218;
			ObjectClass = 2;
			SubClass = 7;
			Level = 47;
			ReqLevel = 42;
			Name = "Shortsword of Vengeance";
			Name2 = "Shortsword of Vengeance";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 117784;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2400;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetSpell( 13519 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 53 , 99 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Bloodrazor)
*
***************************************************************/

namespace Server.Items
{
	public class Bloodrazor : Item
	{
		public Bloodrazor() : base()
		{
			Id = 809;
			Bonding = 2;
			SellPrice = 39125;
			AvailableClasses = 0x7FFF;
			Model = 20033;
			ObjectClass = 2;
			SubClass = 7;
			Level = 50;
			ReqLevel = 45;
			Name = "Bloodrazor";
			Name2 = "Bloodrazor";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 195625;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2700;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 105;
			SetSpell( 17504 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 70 , 130 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Cutlass)
*
***************************************************************/

namespace Server.Items
{
	public class Cutlass : Item
	{
		public Cutlass() : base()
		{
			Id = 851;
			SellPrice = 404;
			AvailableClasses = 0x7FFF;
			Model = 22077;
			ObjectClass = 2;
			SubClass = 7;
			Level = 15;
			ReqLevel = 10;
			Name = "Cutlass";
			Name2 = "Cutlass";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2023;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2200;
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
*				(Knightly Longsword)
*
***************************************************************/

namespace Server.Items
{
	public class KnightlyLongsword : Item
	{
		public KnightlyLongsword() : base()
		{
			Id = 864;
			Bonding = 2;
			SellPrice = 9716;
			AvailableClasses = 0x7FFF;
			Model = 26579;
			ObjectClass = 2;
			SubClass = 7;
			Level = 38;
			ReqLevel = 33;
			Name = "Knightly Longsword";
			Name2 = "Knightly Longsword";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5240;
			BuyPrice = 48580;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1500;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 21 , 40 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Dazzling Longsword)
*
***************************************************************/

namespace Server.Items
{
	public class DazzlingLongsword : Item
	{
		public DazzlingLongsword() : base()
		{
			Id = 869;
			Bonding = 2;
			SellPrice = 18529;
			AvailableClasses = 0x7FFF;
			Model = 5163;
			ObjectClass = 2;
			SubClass = 7;
			Level = 41;
			ReqLevel = 36;
			Name = "Dazzling Longsword";
			Name2 = "Dazzling Longsword";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 92648;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1700;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 105;
			SetSpell( 13752 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 37 , 70 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Black Metal Shortsword)
*
***************************************************************/

namespace Server.Items
{
	public class BlackMetalShortsword : Item
	{
		public BlackMetalShortsword() : base()
		{
			Id = 886;
			Bonding = 2;
			SellPrice = 2949;
			AvailableClasses = 0x7FFF;
			Model = 20093;
			ObjectClass = 2;
			SubClass = 7;
			Level = 26;
			ReqLevel = 21;
			Name = "Black Metal Shortsword";
			Name2 = "Black Metal Shortsword";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 14747;
			Resistance[5] = 4;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1700;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 70;
			SetDamage( 16 , 30 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Longsword)
*
***************************************************************/

namespace Server.Items
{
	public class Longsword : Item
	{
		public Longsword() : base()
		{
			Id = 923;
			SellPrice = 1748;
			AvailableClasses = 0x7FFF;
			Model = 22080;
			ObjectClass = 2;
			SubClass = 7;
			Level = 26;
			ReqLevel = 21;
			Name = "Longsword";
			Name2 = "Longsword";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 8743;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2300;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 70;
			SetDamage( 19 , 37 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Night Watch Shortsword)
*
***************************************************************/

namespace Server.Items
{
	public class NightWatchShortsword : Item
	{
		public NightWatchShortsword() : base()
		{
			Id = 935;
			Bonding = 2;
			SellPrice = 1742;
			AvailableClasses = 0x7FFF;
			Model = 8274;
			ObjectClass = 2;
			SubClass = 7;
			Level = 20;
			ReqLevel = 15;
			Name = "Night Watch Shortsword";
			Name2 = "Night Watch Shortsword";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 8712;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2600;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			SetDamage( 24 , 46 , Resistances.Armor );
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Fire Sword of Crippling)
*
***************************************************************/

namespace Server.Items
{
	public class FireSwordOfCrippling : Item
	{
		public FireSwordOfCrippling() : base()
		{
			Id = 997;
			SellPrice = 3;
			AvailableClasses = 0x7FFF;
			Model = 859;
			ObjectClass = 2;
			SubClass = 7;
			Level = 1;
			ReqLevel = 1;
			Name = "Fire Sword of Crippling";
			Name2 = "Fire Sword of Crippling";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 17;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2000;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 20;
			Flags = 16;
			SetSpell( 89 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 1 , 2 , Resistances.Fire );
		}
	}
}


/**************************************************************
*
*				(Well-used Sword)
*
***************************************************************/

namespace Server.Items
{
	public class WellUsedSword : Item
	{
		public WellUsedSword() : base()
		{
			Id = 1008;
			Bonding = 1;
			SellPrice = 144;
			AvailableClasses = 0x7FFF;
			Model = 1550;
			ObjectClass = 2;
			SubClass = 7;
			Level = 10;
			Name = "Well-used Sword";
			Name2 = "Well-used Sword";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 720;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2100;
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
*				(Militia Shortsword)
*
***************************************************************/

namespace Server.Items
{
	public class MilitiaShortsword : Item
	{
		public MilitiaShortsword() : base()
		{
			Id = 1161;
			Bonding = 1;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 1544;
			ObjectClass = 2;
			SubClass = 7;
			Level = 5;
			Name = "Militia Shortsword";
			Name2 = "Militia Shortsword";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 128;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2500;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 30;
			SetDamage( 3 , 7 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Redridge Machete)
*
***************************************************************/

namespace Server.Items
{
	public class RedridgeMachete : Item
	{
		public RedridgeMachete() : base()
		{
			Id = 1219;
			Bonding = 2;
			SellPrice = 823;
			AvailableClasses = 0x7FFF;
			Model = 20122;
			ObjectClass = 2;
			SubClass = 7;
			Level = 16;
			ReqLevel = 11;
			Name = "Redridge Machete";
			Name2 = "Redridge Machete";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4119;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2300;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 50;
			SetDamage( 13 , 25 , Resistances.Armor );
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Scorpion Sting)
*
***************************************************************/

namespace Server.Items
{
	public class ScorpionSting : Item
	{
		public ScorpionSting() : base()
		{
			Id = 1265;
			Bonding = 2;
			SellPrice = 11774;
			AvailableClasses = 0x7FFF;
			Model = 20156;
			ObjectClass = 2;
			SubClass = 7;
			Level = 39;
			ReqLevel = 34;
			Name = "Scorpion Sting";
			Name2 = "Scorpion Sting";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 58874;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2400;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetSpell( 18208 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 44 , 83 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Dull Blade)
*
***************************************************************/

namespace Server.Items
{
	public class DullBlade : Item
	{
		public DullBlade() : base()
		{
			Id = 1384;
			SellPrice = 11;
			AvailableClasses = 0x7FFF;
			Model = 1546;
			ObjectClass = 2;
			SubClass = 7;
			Level = 3;
			ReqLevel = 1;
			Name = "Dull Blade";
			Name2 = "Dull Blade";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 56;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1900;
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
*				(Feeble Sword)
*
***************************************************************/

namespace Server.Items
{
	public class FeebleSword : Item
	{
		public FeebleSword() : base()
		{
			Id = 1413;
			SellPrice = 55;
			AvailableClasses = 0x7FFF;
			Model = 1547;
			ObjectClass = 2;
			SubClass = 7;
			Level = 8;
			ReqLevel = 3;
			Name = "Feeble Sword";
			Name2 = "Feeble Sword";
			AvailableRaces = 0x1FF;
			BuyPrice = 276;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2000;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 35;
			SetDamage( 3 , 7 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Scimitar of Atun)
*
***************************************************************/

namespace Server.Items
{
	public class ScimitarOfAtun : Item
	{
		public ScimitarOfAtun() : base()
		{
			Id = 1469;
			Bonding = 2;
			SellPrice = 1180;
			AvailableClasses = 0x7FFF;
			Model = 20154;
			ObjectClass = 2;
			SubClass = 7;
			Level = 19;
			ReqLevel = 14;
			Name = "Scimitar of Atun";
			Name2 = "Scimitar of Atun";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5900;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2600;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 55;
			SetDamage( 17 , 33 , Resistances.Armor );
			AgilityBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Shadowfang)
*
***************************************************************/

namespace Server.Items
{
	public class Shadowfang : Item
	{
		public Shadowfang() : base()
		{
			Id = 1482;
			Bonding = 2;
			SellPrice = 2964;
			AvailableClasses = 0x7FFF;
			Model = 20089;
			ObjectClass = 2;
			SubClass = 7;
			Level = 24;
			ReqLevel = 19;
			Name = "Shadowfang";
			Name2 = "Shadowfang";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 14822;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2700;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetSpell( 13440 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 29 , 55 , Resistances.Armor );
			SetDamage( 4 , 8 , Resistances.Shadow );
		}
	}
}


/**************************************************************
*
*				(Heavy Marauder Scimitar)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyMarauderScimitar : Item
	{
		public HeavyMarauderScimitar() : base()
		{
			Id = 1493;
			Bonding = 2;
			SellPrice = 3922;
			AvailableClasses = 0x7FFF;
			Model = 5165;
			ObjectClass = 2;
			SubClass = 7;
			Level = 27;
			ReqLevel = 22;
			Name = "Heavy Marauder Scimitar";
			Name2 = "Heavy Marauder Scimitar";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 19610;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2400;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 80;
			SetDamage( 28 , 54 , Resistances.Armor );
			StrBonus = 4;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Commoner's Sword)
*
***************************************************************/

namespace Server.Items
{
	public class CommonersSword : Item
	{
		public CommonersSword() : base()
		{
			Id = 1511;
			SellPrice = 193;
			AvailableClasses = 0x7FFF;
			Model = 20173;
			ObjectClass = 2;
			SubClass = 7;
			Level = 13;
			ReqLevel = 8;
			Name = "Commoner's Sword";
			Name2 = "Commoner's Sword";
			AvailableRaces = 0x1FF;
			BuyPrice = 969;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2300;
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
*				(Sword of Decay)
*
***************************************************************/

namespace Server.Items
{
	public class SwordOfDecay : Item
	{
		public SwordOfDecay() : base()
		{
			Id = 1727;
			Bonding = 2;
			SellPrice = 4562;
			AvailableClasses = 0x7FFF;
			Model = 12827;
			ObjectClass = 2;
			SubClass = 7;
			Level = 28;
			ReqLevel = 23;
			Name = "Sword of Decay";
			Name2 = "Sword of Decay";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 22814;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2700;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 80;
			SetSpell( 13528 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 33 , 62 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Teebu's Blazing Longsword)
*
***************************************************************/

namespace Server.Items
{
	public class TeebusBlazingLongsword : Item
	{
		public TeebusBlazingLongsword() : base()
		{
			Id = 1728;
			Bonding = 2;
			SellPrice = 87008;
			AvailableClasses = 0x7FFF;
			Model = 19997;
			ObjectClass = 2;
			SubClass = 7;
			Level = 65;
			ReqLevel = 60;
			Name = "Teebu's Blazing Longsword";
			Name2 = "Teebu's Blazing Longsword";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 435040;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2900;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 3;
			Durability = 105;
			SetSpell( 18086 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 96 , 178 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Stock Shortsword)
*
***************************************************************/

namespace Server.Items
{
	public class StockShortsword : Item
	{
		public StockShortsword() : base()
		{
			Id = 1817;
			SellPrice = 501;
			AvailableClasses = 0x7FFF;
			Model = 20164;
			ObjectClass = 2;
			SubClass = 7;
			Level = 19;
			ReqLevel = 14;
			Name = "Stock Shortsword";
			Name2 = "Stock Shortsword";
			AvailableRaces = 0x1FF;
			BuyPrice = 2507;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1800;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 55;
			SetDamage( 7 , 14 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Warped Blade)
*
***************************************************************/

namespace Server.Items
{
	public class WarpedBlade : Item
	{
		public WarpedBlade() : base()
		{
			Id = 1821;
			SellPrice = 988;
			AvailableClasses = 0x7FFF;
			Model = 5151;
			ObjectClass = 2;
			SubClass = 7;
			Level = 24;
			ReqLevel = 19;
			Name = "Warped Blade";
			Name2 = "Warped Blade";
			AvailableRaces = 0x1FF;
			BuyPrice = 4940;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1600;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			SetDamage( 8 , 15 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Short Cutlass)
*
***************************************************************/

namespace Server.Items
{
	public class ShortCutlass : Item
	{
		public ShortCutlass() : base()
		{
			Id = 1829;
			SellPrice = 1563;
			AvailableClasses = 0x7FFF;
			Model = 15591;
			ObjectClass = 2;
			SubClass = 7;
			Level = 29;
			ReqLevel = 24;
			Name = "Short Cutlass";
			Name2 = "Short Cutlass";
			AvailableRaces = 0x1FF;
			BuyPrice = 7818;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2700;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 17 , 32 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Defias Rapier)
*
***************************************************************/

namespace Server.Items
{
	public class DefiasRapier : Item
	{
		public DefiasRapier() : base()
		{
			Id = 1925;
			Bonding = 2;
			SellPrice = 787;
			AvailableClasses = 0x7FFF;
			Model = 20114;
			ObjectClass = 2;
			SubClass = 7;
			Level = 16;
			ReqLevel = 11;
			Name = "Defias Rapier";
			Name2 = "Defias Rapier";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3938;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1600;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 50;
			SetDamage( 9 , 17 , Resistances.Armor );
			AgilityBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Buzz Saw)
*
***************************************************************/

namespace Server.Items
{
	public class BuzzSaw : Item
	{
		public BuzzSaw() : base()
		{
			Id = 1937;
			Bonding = 1;
			SellPrice = 1700;
			AvailableClasses = 0x7FFF;
			Model = 5040;
			ObjectClass = 2;
			SubClass = 7;
			Level = 21;
			ReqLevel = 16;
			Name = "Buzz Saw";
			Name2 = "Buzz Saw";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 8500;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2400;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 60;
			SetDamage( 17 , 33 , Resistances.Armor );
			AgilityBonus = 2;
			StrBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Blackwater Cutlass)
*
***************************************************************/

namespace Server.Items
{
	public class BlackwaterCutlass : Item
	{
		public BlackwaterCutlass() : base()
		{
			Id = 1951;
			Bonding = 2;
			SellPrice = 1258;
			AvailableClasses = 0x7FFF;
			Model = 8279;
			ObjectClass = 2;
			SubClass = 7;
			Level = 19;
			ReqLevel = 14;
			Name = "Blackwater Cutlass";
			Name2 = "Blackwater Cutlass";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6290;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1900;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 55;
			SetDamage( 12 , 24 , Resistances.Armor );
			AgilityBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Twisted Sabre)
*
***************************************************************/

namespace Server.Items
{
	public class TwistedSabre : Item
	{
		public TwistedSabre() : base()
		{
			Id = 2011;
			Bonding = 2;
			SellPrice = 3840;
			AvailableClasses = 0x7FFF;
			Model = 20120;
			ObjectClass = 2;
			SubClass = 7;
			Level = 26;
			ReqLevel = 21;
			Name = "Twisted Sabre";
			Name2 = "Twisted Sabre";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 19200;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1800;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 80;
			SetDamage( 21 , 39 , Resistances.Armor );
			IqBonus = 5;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Skeletal Longsword)
*
***************************************************************/

namespace Server.Items
{
	public class SkeletalLongsword : Item
	{
		public SkeletalLongsword() : base()
		{
			Id = 2018;
			Bonding = 2;
			SellPrice = 3269;
			AvailableClasses = 0x7FFF;
			Model = 20088;
			ObjectClass = 2;
			SubClass = 7;
			Level = 27;
			ReqLevel = 22;
			Name = "Skeletal Longsword";
			Name2 = "Skeletal Longsword";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 16345;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2200;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 70;
			SetDamage( 21 , 40 , Resistances.Armor );
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Scimitar)
*
***************************************************************/

namespace Server.Items
{
	public class Scimitar : Item
	{
		public Scimitar() : base()
		{
			Id = 2027;
			SellPrice = 763;
			AvailableClasses = 0x7FFF;
			Model = 22079;
			ObjectClass = 2;
			SubClass = 7;
			Level = 19;
			ReqLevel = 14;
			Name = "Scimitar";
			Name2 = "Scimitar";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 3815;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2300;
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
*				(Sword of the Night Sky)
*
***************************************************************/

namespace Server.Items
{
	public class SwordOfTheNightSky : Item
	{
		public SwordOfTheNightSky() : base()
		{
			Id = 2035;
			Bonding = 2;
			SellPrice = 2300;
			AvailableClasses = 0x7FFF;
			Model = 5161;
			ObjectClass = 2;
			SubClass = 7;
			Level = 24;
			ReqLevel = 19;
			Name = "Sword of the Night Sky";
			Name2 = "Sword of the Night Sky";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11503;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1700;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			SetDamage( 14 , 27 , Resistances.Armor );
			AgilityBonus = 2;
			StrBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Bluegill Kukri)
*
***************************************************************/

namespace Server.Items
{
	public class BluegillKukri : Item
	{
		public BluegillKukri() : base()
		{
			Id = 2046;
			Bonding = 2;
			SellPrice = 2461;
			AvailableClasses = 0x7FFF;
			Model = 22226;
			ObjectClass = 2;
			SubClass = 7;
			Level = 24;
			ReqLevel = 19;
			Name = "Bluegill Kukri";
			Name2 = "Bluegill Kukri";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 12307;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2800;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			SetDamage( 24 , 45 , Resistances.Armor );
			StrBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Pitted Defias Shortsword)
*
***************************************************************/

namespace Server.Items
{
	public class PittedDefiasShortsword : Item
	{
		public PittedDefiasShortsword() : base()
		{
			Id = 2057;
			SellPrice = 16;
			AvailableClasses = 0x7FFF;
			Model = 20175;
			ObjectClass = 2;
			SubClass = 7;
			Level = 4;
			ReqLevel = 1;
			Name = "Pitted Defias Shortsword";
			Name2 = "Pitted Defias Shortsword";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 81;
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
*				(Rockjaw Blade)
*
***************************************************************/

namespace Server.Items
{
	public class RockjawBlade : Item
	{
		public RockjawBlade() : base()
		{
			Id = 2065;
			SellPrice = 113;
			AvailableClasses = 0x7FFF;
			Model = 20212;
			ObjectClass = 2;
			SubClass = 7;
			Level = 9;
			ReqLevel = 4;
			Name = "Rockjaw Blade";
			Name2 = "Rockjaw Blade";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 569;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2100;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 35;
			SetDamage( 5 , 11 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Solid Shortblade)
*
***************************************************************/

namespace Server.Items
{
	public class SolidShortblade : Item
	{
		public SolidShortblade() : base()
		{
			Id = 2074;
			Bonding = 1;
			SellPrice = 1054;
			AvailableClasses = 0x7FFF;
			Model = 20168;
			ObjectClass = 2;
			SubClass = 7;
			Level = 18;
			Name = "Solid Shortblade";
			Name2 = "Solid Shortblade";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5271;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2500;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 55;
			SetDamage( 16 , 30 , Resistances.Armor );
			StrBonus = 1;
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Northern Shortsword)
*
***************************************************************/

namespace Server.Items
{
	public class NorthernShortsword : Item
	{
		public NorthernShortsword() : base()
		{
			Id = 2078;
			Bonding = 2;
			SellPrice = 1070;
			AvailableClasses = 0x7FFF;
			Model = 20157;
			ObjectClass = 2;
			SubClass = 7;
			Level = 18;
			ReqLevel = 13;
			Name = "Northern Shortsword";
			Name2 = "Northern Shortsword";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5177;
			BuyPrice = 5350;
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
*				(Shortsword)
*
***************************************************************/

namespace Server.Items
{
	public class Shortsword : Item
	{
		public Shortsword() : base()
		{
			Id = 2131;
			SellPrice = 10;
			AvailableClasses = 0x7FFF;
			Model = 22075;
			ObjectClass = 2;
			SubClass = 7;
			Level = 3;
			ReqLevel = 1;
			Name = "Shortsword";
			Name2 = "Shortsword";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 54;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2600;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 20;
			SetDamage( 2 , 4 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Krol Blade)
*
***************************************************************/

namespace Server.Items
{
	public class KrolBlade : Item
	{
		public KrolBlade() : base()
		{
			Id = 2244;
			Bonding = 2;
			SellPrice = 51857;
			AvailableClasses = 0x7FFF;
			Model = 8090;
			ObjectClass = 2;
			SubClass = 7;
			Level = 56;
			ReqLevel = 51;
			Name = "Krol Blade";
			Name2 = "Krol Blade";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 259289;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2800;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 105;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 80 , 149 , Resistances.Armor );
			StrBonus = 7;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Frostmane Shortsword)
*
***************************************************************/

namespace Server.Items
{
	public class FrostmaneShortsword : Item
	{
		public FrostmaneShortsword() : base()
		{
			Id = 2258;
			SellPrice = 83;
			AvailableClasses = 0x7FFF;
			Model = 4260;
			ObjectClass = 2;
			SubClass = 7;
			Level = 8;
			ReqLevel = 3;
			Name = "Frostmane Shortsword";
			Name2 = "Frostmane Shortsword";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 416;
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
*				(Phytoblade)
*
***************************************************************/

namespace Server.Items
{
	public class Phytoblade : Item
	{
		public Phytoblade() : base()
		{
			Id = 2263;
			Bonding = 1;
			SellPrice = 2619;
			AvailableClasses = 0x7FFF;
			Model = 5170;
			ObjectClass = 2;
			SubClass = 7;
			Level = 25;
			Name = "Phytoblade";
			Name2 = "Phytoblade";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 100;
			Skill = 182;
			BuyPrice = 13098;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2800;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			SetSpell( 14119 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 25 , 47 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Stonesplinter Blade)
*
***************************************************************/

namespace Server.Items
{
	public class StonesplinterBlade : Item
	{
		public StonesplinterBlade() : base()
		{
			Id = 2268;
			SellPrice = 146;
			AvailableClasses = 0x7FFF;
			Model = 20213;
			ObjectClass = 2;
			SubClass = 7;
			Level = 10;
			ReqLevel = 5;
			Name = "Stonesplinter Blade";
			Name2 = "Stonesplinter Blade";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 732;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2000;
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
*				(Rodentia Shortsword)
*
***************************************************************/

namespace Server.Items
{
	public class RodentiaShortsword : Item
	{
		public RodentiaShortsword() : base()
		{
			Id = 2282;
			SellPrice = 139;
			AvailableClasses = 0x7FFF;
			Model = 20211;
			ObjectClass = 2;
			SubClass = 7;
			Level = 10;
			ReqLevel = 5;
			Name = "Rodentia Shortsword";
			Name2 = "Rodentia Shortsword";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 696;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2300;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 40;
			SetDamage( 7 , 13 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Peon Sword)
*
***************************************************************/

namespace Server.Items
{
	public class PeonSword : Item
	{
		public PeonSword() : base()
		{
			Id = 2481;
			SellPrice = 17;
			AvailableClasses = 0x7FFF;
			Model = 16155;
			ObjectClass = 2;
			SubClass = 7;
			Level = 4;
			ReqLevel = 1;
			Name = "Peon Sword";
			Name2 = "Peon Sword";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 86;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2400;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Flags = 16;
			SetDamage( 2 , 5 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Gladius)
*
***************************************************************/

namespace Server.Items
{
	public class Gladius : Item
	{
		public Gladius() : base()
		{
			Id = 2488;
			SellPrice = 107;
			AvailableClasses = 0x7FFF;
			Model = 22078;
			ObjectClass = 2;
			SubClass = 7;
			Level = 9;
			ReqLevel = 4;
			Name = "Gladius";
			Name2 = "Gladius";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 536;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2100;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 35;
			SetDamage( 5 , 11 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Raider Shortsword)
*
***************************************************************/

namespace Server.Items
{
	public class RaiderShortsword : Item
	{
		public RaiderShortsword() : base()
		{
			Id = 2496;
			SellPrice = 80;
			AvailableClasses = 0x7FFF;
			Model = 2398;
			ObjectClass = 2;
			SubClass = 7;
			Level = 8;
			ReqLevel = 3;
			Name = "Raider Shortsword";
			Name2 = "Raider Shortsword";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 404;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2500;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Flags = 16;
			SetDamage( 5 , 11 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Broadsword)
*
***************************************************************/

namespace Server.Items
{
	public class Broadsword : Item
	{
		public Broadsword() : base()
		{
			Id = 2520;
			SellPrice = 4925;
			AvailableClasses = 0x7FFF;
			Model = 22085;
			ObjectClass = 2;
			SubClass = 7;
			Level = 36;
			ReqLevel = 31;
			Name = "Broadsword";
			Name2 = "Broadsword";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 24628;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2300;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 28 , 53 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Falchion)
*
***************************************************************/

namespace Server.Items
{
	public class Falchion : Item
	{
		public Falchion() : base()
		{
			Id = 2528;
			SellPrice = 10367;
			AvailableClasses = 0x7FFF;
			Model = 22081;
			ObjectClass = 2;
			SubClass = 7;
			Level = 46;
			ReqLevel = 41;
			Name = "Falchion";
			Name2 = "Falchion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 51836;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2200;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 39 , 74 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Copper Shortsword)
*
***************************************************************/

namespace Server.Items
{
	public class CopperShortsword : Item
	{
		public CopperShortsword() : base()
		{
			Id = 2847;
			SellPrice = 110;
			AvailableClasses = 0x7FFF;
			Model = 4805;
			ObjectClass = 2;
			SubClass = 7;
			Level = 9;
			ReqLevel = 4;
			Name = "Copper Shortsword";
			Name2 = "Copper Shortsword";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 551;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2100;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 35;
			SetDamage( 5 , 11 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Bronze Shortsword)
*
***************************************************************/

namespace Server.Items
{
	public class BronzeShortsword : Item
	{
		public BronzeShortsword() : base()
		{
			Id = 2850;
			SellPrice = 1439;
			AvailableClasses = 0x7FFF;
			Model = 3855;
			ObjectClass = 2;
			SubClass = 7;
			Level = 24;
			ReqLevel = 19;
			Name = "Bronze Shortsword";
			Name2 = "Bronze Shortsword";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 7197;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2100;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			SetDamage( 16 , 31 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Viking Sword)
*
***************************************************************/

namespace Server.Items
{
	public class VikingSword : Item
	{
		public VikingSword() : base()
		{
			Id = 3186;
			Bonding = 2;
			SellPrice = 4436;
			AvailableClasses = 0x7FFF;
			Model = 26576;
			ObjectClass = 2;
			SubClass = 7;
			Level = 30;
			ReqLevel = 25;
			Name = "Viking Sword";
			Name2 = "Viking Sword";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5213;
			BuyPrice = 22180;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2700;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 29 , 55 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Forsaken Shortsword)
*
***************************************************************/

namespace Server.Items
{
	public class ForsakenShortsword : Item
	{
		public ForsakenShortsword() : base()
		{
			Id = 3267;
			Bonding = 1;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 20176;
			ObjectClass = 2;
			SubClass = 7;
			Level = 5;
			Name = "Forsaken Shortsword";
			Name2 = "Forsaken Shortsword";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 128;
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
*				(Deadman Blade)
*
***************************************************************/

namespace Server.Items
{
	public class DeadmanBlade : Item
	{
		public DeadmanBlade() : base()
		{
			Id = 3295;
			SellPrice = 10;
			AvailableClasses = 0x7FFF;
			Model = 3434;
			ObjectClass = 2;
			SubClass = 7;
			Level = 3;
			ReqLevel = 1;
			Name = "Deadman Blade";
			Name2 = "Deadman Blade";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 54;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2500;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 20;
			SetDamage( 2 , 4 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Short Sabre)
*
***************************************************************/

namespace Server.Items
{
	public class ShortSabre : Item
	{
		public ShortSabre() : base()
		{
			Id = 3319;
			SellPrice = 110;
			AvailableClasses = 0x7FFF;
			Model = 5007;
			ObjectClass = 2;
			SubClass = 7;
			Level = 9;
			ReqLevel = 4;
			Name = "Short Sabre";
			Name2 = "Short Sabre";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 550;
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
*				(Lucine Longsword)
*
***************************************************************/

namespace Server.Items
{
	public class LucineLongsword : Item
	{
		public LucineLongsword() : base()
		{
			Id = 3400;
			Bonding = 1;
			SellPrice = 2761;
			AvailableClasses = 0x7FFF;
			Model = 20110;
			ObjectClass = 2;
			SubClass = 7;
			Level = 25;
			Name = "Lucine Longsword";
			Name2 = "Lucine Longsword";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 13806;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2500;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			SetDamage( 22 , 42 , Resistances.Armor );
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Deathstalker Shortsword)
*
***************************************************************/

namespace Server.Items
{
	public class DeathstalkerShortsword : Item
	{
		public DeathstalkerShortsword() : base()
		{
			Id = 3455;
			Bonding = 1;
			SellPrice = 188;
			AvailableClasses = 0x7FFF;
			Model = 20015;
			ObjectClass = 2;
			SubClass = 7;
			Level = 11;
			Name = "Deathstalker Shortsword";
			Name2 = "Deathstalker Shortsword";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 941;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2100;
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
*				(Talonstrike)
*
***************************************************************/

namespace Server.Items
{
	public class Talonstrike : Item
	{
		public Talonstrike() : base()
		{
			Id = 3462;
			Bonding = 1;
			SellPrice = 2283;
			AvailableClasses = 0x7FFF;
			Model = 28607;
			ObjectClass = 2;
			SubClass = 7;
			Level = 24;
			Name = "Talonstrike";
			Name2 = "Talonstrike";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11418;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1600;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			SetDamage( 13 , 26 , Resistances.Armor );
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Daryl's Shortsword)
*
***************************************************************/

namespace Server.Items
{
	public class DarylsShortsword : Item
	{
		public DarylsShortsword() : base()
		{
			Id = 3572;
			Bonding = 1;
			SellPrice = 972;
			AvailableClasses = 0x7FFF;
			Model = 5151;
			ObjectClass = 2;
			SubClass = 7;
			Level = 17;
			Name = "Daryl's Shortsword";
			Name2 = "Daryl's Shortsword";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4861;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2300;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 50;
			SetDamage( 14 , 26 , Resistances.Armor );
			AgilityBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Decapitating Sword)
*
***************************************************************/

namespace Server.Items
{
	public class DecapitatingSword : Item
	{
		public DecapitatingSword() : base()
		{
			Id = 3740;
			Bonding = 2;
			SellPrice = 2452;
			AvailableClasses = 0x7FFF;
			Model = 22226;
			ObjectClass = 2;
			SubClass = 7;
			Level = 24;
			ReqLevel = 19;
			Name = "Decapitating Sword";
			Name2 = "Decapitating Sword";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5195;
			BuyPrice = 12262;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2600;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			SetDamage( 22 , 42 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Light Scimitar)
*
***************************************************************/

namespace Server.Items
{
	public class LightScimitar : Item
	{
		public LightScimitar() : base()
		{
			Id = 3783;
			SellPrice = 3048;
			AvailableClasses = 0x7FFF;
			Model = 20216;
			ObjectClass = 2;
			SubClass = 7;
			Level = 36;
			ReqLevel = 31;
			Name = "Light Scimitar";
			Name2 = "Light Scimitar";
			AvailableRaces = 0x1FF;
			BuyPrice = 15244;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1900;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 15 , 28 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Hardened Iron Shortsword)
*
***************************************************************/

namespace Server.Items
{
	public class HardenedIronShortsword : Item
	{
		public HardenedIronShortsword() : base()
		{
			Id = 3849;
			Bonding = 2;
			SellPrice = 5468;
			AvailableClasses = 0x7FFF;
			Model = 5153;
			ObjectClass = 2;
			SubClass = 7;
			Level = 32;
			ReqLevel = 27;
			Name = "Hardened Iron Shortsword";
			Name2 = "Hardened Iron Shortsword";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 27340;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1800;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 21 , 39 , Resistances.Armor );
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Jade Serpentblade)
*
***************************************************************/

namespace Server.Items
{
	public class JadeSerpentblade : Item
	{
		public JadeSerpentblade() : base()
		{
			Id = 3850;
			Bonding = 2;
			SellPrice = 7304;
			AvailableClasses = 0x7FFF;
			Model = 20215;
			ObjectClass = 2;
			SubClass = 7;
			Level = 35;
			ReqLevel = 30;
			Name = "Jade Serpentblade";
			Name2 = "Jade Serpentblade";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 36523;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2600;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 33 , 62 , Resistances.Armor );
			StrBonus = 4;
			AgilityBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Smotts' Cutlass)
*
***************************************************************/

namespace Server.Items
{
	public class SmottsCutlass : Item
	{
		public SmottsCutlass() : base()
		{
			Id = 3935;
			Bonding = 4;
			AvailableClasses = 0x7FFF;
			Model = 4800;
			ObjectClass = 2;
			SubClass = 7;
			Level = 25;
			ReqLevel = 20;
			Name = "Smotts' Cutlass";
			Name2 = "Smotts' Cutlass";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1900;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			Flags = 2048;
			SetDamage( 15 , 29 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Sharp Shortsword)
*
***************************************************************/

namespace Server.Items
{
	public class SharpShortsword : Item
	{
		public SharpShortsword() : base()
		{
			Id = 4017;
			SellPrice = 6910;
			AvailableClasses = 0x7FFF;
			Model = 20225;
			ObjectClass = 2;
			SubClass = 7;
			Level = 46;
			ReqLevel = 41;
			Name = "Sharp Shortsword";
			Name2 = "Sharp Shortsword";
			AvailableRaces = 0x1FF;
			BuyPrice = 34550;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1800;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 20 , 39 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Olmann Sewar)
*
***************************************************************/

namespace Server.Items
{
	public class OlmannSewar : Item
	{
		public OlmannSewar() : base()
		{
			Id = 4116;
			Bonding = 1;
			SellPrice = 12337;
			AvailableClasses = 0x7FFF;
			Model = 20223;
			ObjectClass = 2;
			SubClass = 7;
			Level = 41;
			Name = "Olmann Sewar";
			Name2 = "Olmann Sewar";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 61686;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2700;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 43 , 81 , Resistances.Armor );
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Fine Scimitar)
*
***************************************************************/

namespace Server.Items
{
	public class FineScimitar : Item
	{
		public FineScimitar() : base()
		{
			Id = 4560;
			SellPrice = 37;
			AvailableClasses = 0x7FFF;
			Model = 4788;
			ObjectClass = 2;
			SubClass = 7;
			Level = 6;
			ReqLevel = 1;
			Name = "Fine Scimitar";
			Name2 = "Fine Scimitar";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 185;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1900;
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
*				(Enamelled Broadsword)
*
***************************************************************/

namespace Server.Items
{
	public class EnamelledBroadsword : Item
	{
		public EnamelledBroadsword() : base()
		{
			Id = 4765;
			Bonding = 2;
			SellPrice = 575;
			AvailableClasses = 0x7FFF;
			Model = 7313;
			ObjectClass = 2;
			SubClass = 7;
			Level = 14;
			ReqLevel = 9;
			Name = "Enamelled Broadsword";
			Name2 = "Enamelled Broadsword";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2877;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2400;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 45;
			SetDamage( 12 , 23 , Resistances.Armor );
			StrBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Feral Blade)
*
***************************************************************/

namespace Server.Items
{
	public class FeralBlade : Item
	{
		public FeralBlade() : base()
		{
			Id = 4766;
			Bonding = 2;
			SellPrice = 481;
			AvailableClasses = 0x7FFF;
			Model = 7314;
			ObjectClass = 2;
			SubClass = 7;
			Level = 13;
			ReqLevel = 8;
			Name = "Feral Blade";
			Name2 = "Feral Blade";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2407;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2600;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 45;
			SetDamage( 12 , 24 , Resistances.Armor );
			AgilityBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Harpy Wing Clipper)
*
***************************************************************/

namespace Server.Items
{
	public class HarpyWingClipper : Item
	{
		public HarpyWingClipper() : base()
		{
			Id = 4932;
			Bonding = 1;
			SellPrice = 179;
			AvailableClasses = 0x7FFF;
			Model = 20013;
			ObjectClass = 2;
			SubClass = 7;
			Level = 11;
			Name = "Harpy Wing Clipper";
			Name2 = "Harpy Wing Clipper";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 899;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2600;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 40;
			SetDamage( 9 , 17 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Sword of Hammerfall)
*
***************************************************************/

namespace Server.Items
{
	public class SwordOfHammerfall : Item
	{
		public SwordOfHammerfall() : base()
		{
			Id = 4977;
			Bonding = 1;
			SellPrice = 11893;
			AvailableClasses = 0x7FFF;
			Model = 20009;
			ObjectClass = 2;
			SubClass = 7;
			Level = 41;
			Name = "Sword of Hammerfall";
			Name2 = "Sword of Hammerfall";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 59465;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2300;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 37 , 69 , Resistances.Armor );
			StrBonus = 4;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Dwarf Captain's Sword)
*
***************************************************************/

namespace Server.Items
{
	public class DwarfCaptainsSword : Item
	{
		public DwarfCaptainsSword() : base()
		{
			Id = 4987;
			Bonding = 1;
			SellPrice = 15584;
			AvailableClasses = 0x7FFF;
			Model = 20083;
			ObjectClass = 2;
			SubClass = 7;
			Level = 45;
			Name = "Dwarf Captain's Sword";
			Name2 = "Dwarf Captain's Sword";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 77920;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2500;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 46 , 87 , Resistances.Armor );
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Cruel Barb)
*
***************************************************************/

namespace Server.Items
{
	public class CruelBarb : Item
	{
		public CruelBarb() : base()
		{
			Id = 5191;
			Bonding = 1;
			SellPrice = 2964;
			AvailableClasses = 0x7FFF;
			Model = 7311;
			ObjectClass = 2;
			SubClass = 7;
			Level = 24;
			ReqLevel = 19;
			Name = "Cruel Barb";
			Name2 = "Cruel Barb";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 14822;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2800;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetSpell( 9141 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 30 , 57 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Thief's Blade)
*
***************************************************************/

namespace Server.Items
{
	public class ThiefsBlade : Item
	{
		public ThiefsBlade() : base()
		{
			Id = 5192;
			Bonding = 1;
			SellPrice = 1803;
			AvailableClasses = 0x7FFF;
			Model = 5144;
			ObjectClass = 2;
			SubClass = 7;
			Level = 22;
			ReqLevel = 17;
			Name = "Thief's Blade";
			Name2 = "Thief's Blade";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 9015;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1700;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 3;
			Durability = 60;
			SetDamage( 13 , 25 , Resistances.Armor );
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Elegant Shortsword)
*
***************************************************************/

namespace Server.Items
{
	public class ElegantShortsword : Item
	{
		public ElegantShortsword() : base()
		{
			Id = 5321;
			Bonding = 1;
			SellPrice = 1484;
			AvailableClasses = 0x7FFF;
			Model = 20014;
			ObjectClass = 2;
			SubClass = 7;
			Level = 20;
			Name = "Elegant Shortsword";
			Name2 = "Elegant Shortsword";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7423;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2000;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 55;
			SetDamage( 14 , 26 , Resistances.Armor );
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Thistlewood Blade)
*
***************************************************************/

namespace Server.Items
{
	public class ThistlewoodBlade : Item
	{
		public ThistlewoodBlade() : base()
		{
			Id = 5586;
			Bonding = 1;
			SellPrice = 26;
			AvailableClasses = 0x7FFF;
			Model = 1547;
			ObjectClass = 2;
			SubClass = 7;
			Level = 5;
			Name = "Thistlewood Blade";
			Name2 = "Thistlewood Blade";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 130;
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
*				(Pale Skinner)
*
***************************************************************/

namespace Server.Items
{
	public class PaleSkinner : Item
	{
		public PaleSkinner() : base()
		{
			Id = 5744;
			Bonding = 2;
			SellPrice = 386;
			AvailableClasses = 0x7FFF;
			Model = 8279;
			ObjectClass = 2;
			SubClass = 7;
			Level = 12;
			ReqLevel = 7;
			Name = "Pale Skinner";
			Name2 = "Pale Skinner";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = -1;
			BuyPrice = 1933;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2200;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 40;
			SetDamage( 10 , 19 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Wingblade)
*
***************************************************************/

namespace Server.Items
{
	public class Wingblade : Item
	{
		public Wingblade() : base()
		{
			Id = 6504;
			Bonding = 1;
			SellPrice = 2933;
			AvailableClasses = 0x7FFF;
			Model = 20116;
			ObjectClass = 2;
			SubClass = 7;
			Level = 24;
			Name = "Wingblade";
			Name2 = "Wingblade";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 14667;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2200;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 24 , 45 , Resistances.Armor );
			AgilityBonus = 5;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Sword of Zeal)
*
***************************************************************/

namespace Server.Items
{
	public class SwordOfZeal : Item
	{
		public SwordOfZeal() : base()
		{
			Id = 6622;
			Bonding = 2;
			SellPrice = 55400;
			AvailableClasses = 0x7FFF;
			Model = 21554;
			ObjectClass = 2;
			SubClass = 7;
			Level = 63;
			ReqLevel = 58;
			Name = "Sword of Zeal";
			Name2 = "Sword of Zeal";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 277000;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2800;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetSpell( 8191 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 81 , 151 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Butcher's Slicer)
*
***************************************************************/

namespace Server.Items
{
	public class ButchersSlicer : Item
	{
		public ButchersSlicer() : base()
		{
			Id = 6633;
			Bonding = 1;
			SellPrice = 2131;
			AvailableClasses = 0x7FFF;
			Model = 12610;
			ObjectClass = 2;
			SubClass = 7;
			Level = 23;
			ReqLevel = 18;
			Name = "Butcher's Slicer";
			Name2 = "Butcher's Slicer";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 10659;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2900;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			SetDamage( 23 , 44 , Resistances.Armor );
			StrBonus = 2;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Sword of Omen)
*
***************************************************************/

namespace Server.Items
{
	public class SwordOfOmen : Item
	{
		public SwordOfOmen() : base()
		{
			Id = 6802;
			Bonding = 1;
			SellPrice = 18255;
			AvailableClasses = 0x7FFF;
			Model = 20010;
			ObjectClass = 2;
			SubClass = 7;
			Level = 44;
			Name = "Sword of Omen";
			Name2 = "Sword of Omen";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 91277;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1900;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetDamage( 39 , 74 , Resistances.Armor );
			StrBonus = 9;
			StaminaBonus = 4;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Sword of Serenity)
*
***************************************************************/

namespace Server.Items
{
	public class SwordOfSerenity : Item
	{
		public SwordOfSerenity() : base()
		{
			Id = 6829;
			Bonding = 1;
			SellPrice = 18714;
			AvailableClasses = 0x7FFF;
			Model = 20075;
			ObjectClass = 2;
			SubClass = 7;
			Level = 44;
			Name = "Sword of Serenity";
			Name2 = "Sword of Serenity";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 93572;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2200;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetDamage( 46 , 86 , Resistances.Armor );
			StaminaBonus = 9;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Elunite Sword)
*
***************************************************************/

namespace Server.Items
{
	public class EluniteSword : Item
	{
		public EluniteSword() : base()
		{
			Id = 6967;
			Bonding = 1;
			SellPrice = 696;
			AvailableClasses = 0x01;
			Model = 20162;
			ObjectClass = 2;
			SubClass = 7;
			Level = 15;
			Name = "Elunite Sword";
			Name2 = "Elunite Sword";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3481;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2100;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 50;
			SetDamage( 11 , 21 , Resistances.Armor );
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Umbral Sword)
*
***************************************************************/

namespace Server.Items
{
	public class UmbralSword : Item
	{
		public UmbralSword() : base()
		{
			Id = 6984;
			Bonding = 1;
			SellPrice = 688;
			AvailableClasses = 0x01;
			Model = 20159;
			ObjectClass = 2;
			SubClass = 7;
			Level = 15;
			Name = "Umbral Sword";
			Name2 = "Umbral Sword";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3441;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2100;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 50;
			SetDamage( 11 , 21 , Resistances.Armor );
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Haggard's Sword)
*
***************************************************************/

namespace Server.Items
{
	public class HaggardsSword : Item
	{
		public HaggardsSword() : base()
		{
			Id = 6985;
			Bonding = 1;
			SellPrice = 690;
			AvailableClasses = 0x01;
			Model = 20163;
			ObjectClass = 2;
			SubClass = 7;
			Level = 15;
			Name = "Haggard's Sword";
			Name2 = "Haggard's Sword";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3454;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2100;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 50;
			SetDamage( 11 , 21 , Resistances.Armor );
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Heirloom Sword)
*
***************************************************************/

namespace Server.Items
{
	public class HeirloomSword : Item
	{
		public HeirloomSword() : base()
		{
			Id = 7118;
			Bonding = 1;
			SellPrice = 690;
			AvailableClasses = 0x01;
			Model = 20161;
			ObjectClass = 2;
			SubClass = 7;
			Level = 15;
			Name = "Heirloom Sword";
			Name2 = "Heirloom Sword";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3454;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2100;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 50;
			SetDamage( 11 , 21 , Resistances.Armor );
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Thun'grim's Sword)
*
***************************************************************/

namespace Server.Items
{
	public class ThungrimsSword : Item
	{
		public ThungrimsSword() : base()
		{
			Id = 7329;
			Bonding = 1;
			SellPrice = 703;
			AvailableClasses = 0x01;
			Model = 20160;
			ObjectClass = 2;
			SubClass = 7;
			Level = 15;
			Name = "Thun'grim's Sword";
			Name2 = "Thun'grim's Sword";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3519;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2100;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 50;
			SetDamage( 11 , 21 , Resistances.Armor );
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Wicked Mithril Blade)
*
***************************************************************/

namespace Server.Items
{
	public class WickedMithrilBlade : Item
	{
		public WickedMithrilBlade() : base()
		{
			Id = 7943;
			Bonding = 2;
			SellPrice = 15891;
			AvailableClasses = 0x7FFF;
			Model = 16128;
			ObjectClass = 2;
			SubClass = 7;
			Level = 45;
			ReqLevel = 40;
			Name = "Wicked Mithril Blade";
			Name2 = "Wicked Mithril Blade";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 79459;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2300;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 43 , 80 , Resistances.Armor );
			StrBonus = 6;
			AgilityBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Dazzling Mithril Rapier)
*
***************************************************************/

namespace Server.Items
{
	public class DazzlingMithrilRapier : Item
	{
		public DazzlingMithrilRapier() : base()
		{
			Id = 7944;
			Bonding = 2;
			SellPrice = 20092;
			AvailableClasses = 0x7FFF;
			Model = 20221;
			ObjectClass = 2;
			SubClass = 7;
			Level = 48;
			ReqLevel = 43;
			Name = "Dazzling Mithril Rapier";
			Name2 = "Dazzling Mithril Rapier";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 100463;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1700;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 34 , 63 , Resistances.Armor );
			AgilityBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Phantom Blade)
*
***************************************************************/

namespace Server.Items
{
	public class PhantomBlade : Item
	{
		public PhantomBlade() : base()
		{
			Id = 7961;
			Bonding = 2;
			SellPrice = 25508;
			AvailableClasses = 0x7FFF;
			Model = 25053;
			ObjectClass = 2;
			SubClass = 7;
			Level = 49;
			ReqLevel = 44;
			Name = "Phantom Blade";
			Name2 = "Phantom Blade";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 127541;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2600;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 90;
			SetSpell( 9806 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 59 , 111 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Hanzo Sword)
*
***************************************************************/

namespace Server.Items
{
	public class HanzoSword : Item
	{
		public HanzoSword() : base()
		{
			Id = 8190;
			Bonding = 2;
			SellPrice = 37286;
			AvailableClasses = 0x7FFF;
			Model = 20081;
			ObjectClass = 2;
			SubClass = 7;
			Level = 55;
			ReqLevel = 50;
			Name = "Hanzo Sword";
			Name2 = "Hanzo Sword";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 186433;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1500;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetSpell( 16405 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 38 , 71 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Ebon Scimitar)
*
***************************************************************/

namespace Server.Items
{
	public class EbonScimitar : Item
	{
		public EbonScimitar() : base()
		{
			Id = 8196;
			Bonding = 2;
			SellPrice = 13979;
			AvailableClasses = 0x7FFF;
			Model = 26572;
			ObjectClass = 2;
			SubClass = 7;
			Level = 43;
			ReqLevel = 38;
			Name = "Ebon Scimitar";
			Name2 = "Ebon Scimitar";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5258;
			BuyPrice = 69895;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1900;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 33 , 62 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Blade of the Basilisk)
*
***************************************************************/

namespace Server.Items
{
	public class BladeOfTheBasilisk : Item
	{
		public BladeOfTheBasilisk() : base()
		{
			Id = 8223;
			Bonding = 2;
			SellPrice = 10066;
			AvailableClasses = 0x7FFF;
			Model = 20073;
			ObjectClass = 2;
			SubClass = 7;
			Level = 37;
			ReqLevel = 32;
			Name = "Blade of the Basilisk";
			Name2 = "Blade of the Basilisk";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 50333;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1900;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetSpell( 10351 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 33 , 62 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Silithid Ripper)
*
***************************************************************/

namespace Server.Items
{
	public class SilithidRipper : Item
	{
		public SilithidRipper() : base()
		{
			Id = 8224;
			Bonding = 2;
			SellPrice = 7655;
			AvailableClasses = 0x7FFF;
			Model = 22232;
			ObjectClass = 2;
			SubClass = 7;
			Level = 36;
			ReqLevel = 31;
			Name = "Silithid Ripper";
			Name2 = "Silithid Ripper";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 38278;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2300;
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
*				(Tainted Pierce)
*
***************************************************************/

namespace Server.Items
{
	public class TaintedPierce : Item
	{
		public TaintedPierce() : base()
		{
			Id = 8225;
			Bonding = 2;
			SellPrice = 9222;
			AvailableClasses = 0x7FFF;
			Model = 20076;
			ObjectClass = 2;
			SubClass = 7;
			Level = 36;
			ReqLevel = 31;
			Name = "Tainted Pierce";
			Name2 = "Tainted Pierce";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 46111;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1900;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetSpell( 13530 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 32 , 60 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(The Butcher)
*
***************************************************************/

namespace Server.Items
{
	public class TheButcher : Item
	{
		public TheButcher() : base()
		{
			Id = 8226;
			Bonding = 2;
			SellPrice = 5747;
			AvailableClasses = 0x7FFF;
			Model = 16539;
			ObjectClass = 2;
			SubClass = 7;
			Level = 31;
			ReqLevel = 26;
			Name = "The Butcher";
			Name2 = "The Butcher";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 28737;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2800;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetDamage( 38 , 72 , Resistances.Armor );
			AgilityBonus = 5;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Sang'thraze the Deflector)
*
***************************************************************/

namespace Server.Items
{
	public class SangthrazeTheDeflector : Item
	{
		public SangthrazeTheDeflector() : base()
		{
			Id = 9379;
			Bonding = 1;
			SellPrice = 26383;
			AvailableClasses = 0x7FFF;
			Model = 20032;
			ObjectClass = 2;
			SubClass = 7;
			Level = 49;
			ReqLevel = 44;
			Name = "Sang'thraze the Deflector";
			Name2 = "Sang'thraze the Deflector";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 131917;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1700;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			Flags = 1024;
			SetSpell( 13665 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 34 , 65 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Jang'thraze the Protector)
*
***************************************************************/

namespace Server.Items
{
	public class JangthrazeTheProtector : Item
	{
		public JangthrazeTheProtector() : base()
		{
			Id = 9380;
			Bonding = 1;
			SellPrice = 28334;
			AvailableClasses = 0x7FFF;
			Model = 20031;
			ObjectClass = 2;
			SubClass = 7;
			Level = 50;
			ReqLevel = 45;
			Name = "Jang'thraze the Protector";
			Name2 = "Jang'thraze the Protector";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 141671;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1900;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 3;
			Flags = 1104;
			SetSpell( 11654 , 0 , 0 , -1 , 0 , -1 );
			SetSpell( 11657 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 44 , 83 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Annealed Blade)
*
***************************************************************/

namespace Server.Items
{
	public class AnnealedBlade : Item
	{
		public AnnealedBlade() : base()
		{
			Id = 9392;
			Bonding = 2;
			SellPrice = 12980;
			AvailableClasses = 0x7FFF;
			Model = 18270;
			ObjectClass = 2;
			SubClass = 7;
			Level = 40;
			ReqLevel = 35;
			Name = "Annealed Blade";
			Name2 = "Annealed Blade";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 64901;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1800;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetDamage( 34 , 64 , Resistances.Armor );
			StrBonus = 6;
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Nordic Longshank)
*
***************************************************************/

namespace Server.Items
{
	public class NordicLongshank : Item
	{
		public NordicLongshank() : base()
		{
			Id = 9401;
			Bonding = 1;
			SellPrice = 16901;
			AvailableClasses = 0x7FFF;
			Model = 7485;
			ObjectClass = 2;
			SubClass = 7;
			Level = 43;
			ReqLevel = 38;
			Name = "Nordic Longshank";
			Name2 = "Nordic Longshank";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 84507;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2200;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetDamage( 45 , 84 , Resistances.Armor );
			AgilityBonus = 8;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Ginn-su Sword)
*
***************************************************************/

namespace Server.Items
{
	public class GinnSuSword : Item
	{
		public GinnSuSword() : base()
		{
			Id = 9424;
			Bonding = 2;
			SellPrice = 13594;
			AvailableClasses = 0x7FFF;
			Model = 18325;
			ObjectClass = 2;
			SubClass = 7;
			Level = 41;
			ReqLevel = 36;
			Name = "Ginn-su Sword";
			Name2 = "Ginn-su Sword";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 67970;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1700;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 90;
			SetDamage( 33 , 62 , Resistances.Armor );
			AgilityBonus = 8;
			StrBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Electrocutioner Leg)
*
***************************************************************/

namespace Server.Items
{
	public class ElectrocutionerLeg : Item
	{
		public ElectrocutionerLeg() : base()
		{
			Id = 9446;
			Bonding = 1;
			SellPrice = 7564;
			AvailableClasses = 0x7FFF;
			Model = 16538;
			ObjectClass = 2;
			SubClass = 7;
			Level = 34;
			ReqLevel = 29;
			Name = "Electrocutioner Leg";
			Name2 = "Electrocutioner Leg";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 37820;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1700;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetSpell( 13482 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 26 , 49 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Bloodletter Scalpel)
*
***************************************************************/

namespace Server.Items
{
	public class BloodletterScalpel : Item
	{
		public BloodletterScalpel() : base()
		{
			Id = 9511;
			Bonding = 2;
			SellPrice = 21060;
			AvailableClasses = 0x7FFF;
			Model = 20029;
			ObjectClass = 2;
			SubClass = 7;
			Level = 46;
			ReqLevel = 41;
			Name = "Bloodletter Scalpel";
			Name2 = "Bloodletter Scalpel";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 105300;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1800;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetSpell( 13486 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 39 , 73 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Reforged Blade of Heroes)
*
***************************************************************/

namespace Server.Items
{
	public class ReforgedBladeOfHeroes : Item
	{
		public ReforgedBladeOfHeroes() : base()
		{
			Id = 9718;
			Bonding = 2;
			SellPrice = 11421;
			AvailableClasses = 0x7FFF;
			Model = 13488;
			ObjectClass = 2;
			SubClass = 7;
			Level = 38;
			ReqLevel = 33;
			Name = "Reforged Blade of Heroes";
			Name2 = "Reforged Blade of Heroes";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 57106;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2200;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetDamage( 31 , 59 , Resistances.Armor );
			SetDamage( 5 , 10 , Resistances.Fire );
			StaminaBonus = 8;
			StrBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Enchanted Azsharite Felbane Sword)
*
***************************************************************/

namespace Server.Items
{
	public class EnchantedAzshariteFelbaneSword : Item
	{
		public EnchantedAzshariteFelbaneSword() : base()
		{
			Id = 10696;
			Bonding = 1;
			SellPrice = 41890;
			AvailableClasses = 0x7FFF;
			Description = "Etched across the blade: Rakh'likh";
			Model = 22229;
			ObjectClass = 2;
			SubClass = 7;
			Level = 60;
			Name = "Enchanted Azsharite Felbane Sword";
			Name2 = "Enchanted Azsharite Felbane Sword";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 209454;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2000;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetSpell( 18079 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 12938 , 0 , 0 , 0 , 0 , 0 );
			SetDamage( 50 , 93 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Firebreather)
*
***************************************************************/

namespace Server.Items
{
	public class Firebreather : Item
	{
		public Firebreather() : base()
		{
			Id = 10797;
			Bonding = 1;
			SellPrice = 35069;
			AvailableClasses = 0x7FFF;
			Model = 20030;
			ObjectClass = 2;
			SubClass = 7;
			Level = 53;
			ReqLevel = 48;
			Name = "Firebreather";
			Name2 = "Firebreather";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 175347;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2200;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetSpell( 16413 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 54 , 101 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Blade of the Wretched)
*
***************************************************************/

namespace Server.Items
{
	public class BladeOfTheWretched : Item
	{
		public BladeOfTheWretched() : base()
		{
			Id = 10803;
			Bonding = 1;
			SellPrice = 29441;
			AvailableClasses = 0x7FFF;
			Model = 20035;
			ObjectClass = 2;
			SubClass = 7;
			Level = 54;
			ReqLevel = 49;
			Name = "Blade of the Wretched";
			Name2 = "Blade of the Wretched";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 147207;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2100;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetSpell( 18088 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 47 , 88 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Vanquisher's Sword)
*
***************************************************************/

namespace Server.Items
{
	public class VanquishersSword : Item
	{
		public VanquishersSword() : base()
		{
			Id = 10823;
			Bonding = 1;
			SellPrice = 17796;
			AvailableClasses = 0x7FFF;
			Model = 20086;
			ObjectClass = 2;
			SubClass = 7;
			Level = 44;
			Name = "Vanquisher's Sword";
			Name2 = "Vanquisher's Sword";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 88981;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2200;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetSpell( 9335 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 46 , 86 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Dragon's Call)
*
***************************************************************/

namespace Server.Items
{
	public class DragonsCall : Item
	{
		public DragonsCall() : base()
		{
			Id = 10847;
			Bonding = 1;
			SellPrice = 56921;
			AvailableClasses = 0x7FFF;
			Model = 20571;
			ObjectClass = 2;
			SubClass = 7;
			Level = 57;
			ReqLevel = 52;
			Name = "Dragon's Call";
			Name2 = "Dragon's Call";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 284608;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2500;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 105;
			SetSpell( 13049 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 72 , 135 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Jang'thraze the Protector)
*
***************************************************************/

namespace Server.Items
{
	public class JangthrazeTheProtector11086 : Item
	{
		public JangthrazeTheProtector11086() : base()
		{
			Id = 11086;
			Bonding = 1;
			SellPrice = 27403;
			AvailableClasses = 0x7FFF;
			Model = 20031;
			ObjectClass = 2;
			SubClass = 7;
			Level = 50;
			ReqLevel = 45;
			Name = "Jang'thraze the Protector";
			Name2 = "Jang'thraze the Protector";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 137016;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1900;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			Flags = 1088;
			SetSpell( 11654 , 0 , -1 , -1 , 0 , -1 );
			SetSpell( 11657 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 44 , 83 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Darkwater Talwar)
*
***************************************************************/

namespace Server.Items
{
	public class DarkwaterTalwar : Item
	{
		public DarkwaterTalwar() : base()
		{
			Id = 11121;
			Bonding = 1;
			SellPrice = 2941;
			AvailableClasses = 0x7FFF;
			Model = 20094;
			ObjectClass = 2;
			SubClass = 7;
			Level = 26;
			ReqLevel = 21;
			Name = "Darkwater Talwar";
			Name2 = "Darkwater Talwar";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 14705;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2200;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 70;
			SetSpell( 16408 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 20 , 39 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Arbiter's Blade)
*
***************************************************************/

namespace Server.Items
{
	public class ArbitersBlade : Item
	{
		public ArbitersBlade() : base()
		{
			Id = 11784;
			Bonding = 1;
			SellPrice = 33835;
			AvailableClasses = 0x7FFF;
			Model = 21773;
			ObjectClass = 2;
			SubClass = 7;
			Level = 53;
			ReqLevel = 48;
			Name = "Arbiter's Blade";
			Name2 = "Arbiter's Blade";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 169177;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2400;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetDamage( 59 , 110 , Resistances.Armor );
			IqBonus = 10;
			SpiritBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Lord General's Sword)
*
***************************************************************/

namespace Server.Items
{
	public class LordGeneralsSword : Item
	{
		public LordGeneralsSword() : base()
		{
			Id = 11817;
			Bonding = 1;
			SellPrice = 39254;
			AvailableClasses = 0x7FFF;
			Model = 21809;
			ObjectClass = 2;
			SubClass = 7;
			Level = 56;
			ReqLevel = 51;
			Name = "Lord General's Sword";
			Name2 = "Lord General's Sword";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 196273;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2600;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetSpell( 15602 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 67 , 125 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Linken's Sword of Mastery)
*
***************************************************************/

namespace Server.Items
{
	public class LinkensSwordOfMastery : Item
	{
		public LinkensSwordOfMastery() : base()
		{
			Id = 11902;
			Bonding = 1;
			SellPrice = 34194;
			AvailableClasses = 0x7FFF;
			Model = 22227;
			ObjectClass = 2;
			SubClass = 7;
			Level = 56;
			Name = "Linken's Sword of Mastery";
			Name2 = "Linken's Sword of Mastery";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 170973;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1800;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetSpell( 18089 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 42 , 78 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Blade of Reckoning)
*
***************************************************************/

namespace Server.Items
{
	public class BladeOfReckoning : Item
	{
		public BladeOfReckoning() : base()
		{
			Id = 12061;
			Bonding = 1;
			SellPrice = 40212;
			AvailableClasses = 0x7FFF;
			Model = 28086;
			ObjectClass = 2;
			SubClass = 7;
			Level = 60;
			Name = "Blade of Reckoning";
			Name2 = "Blade of Reckoning";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 201060;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2400;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetSpell( 9332 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 60 , 112 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Doomforged Straightedge)
*
***************************************************************/

namespace Server.Items
{
	public class DoomforgedStraightedge : Item
	{
		public DoomforgedStraightedge() : base()
		{
			Id = 12535;
			Bonding = 2;
			SellPrice = 34925;
			AvailableClasses = 0x7FFF;
			Model = 22733;
			ObjectClass = 2;
			SubClass = 7;
			Level = 54;
			ReqLevel = 49;
			Name = "Doomforged Straightedge";
			Name2 = "Doomforged Straightedge";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 174629;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1900;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetSpell( 9141 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 47 , 89 , Resistances.Armor );
			StrBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Grand Marshal's Longsword)
*
***************************************************************/

namespace Server.Items
{
	public class GrandMarshalsLongsword : Item
	{
		public GrandMarshalsLongsword() : base()
		{
			Id = 12584;
			Bonding = 1;
			SellPrice = 49636;
			AvailableClasses = 0x7FFF;
			Model = 31966;
			ObjectClass = 2;
			SubClass = 7;
			Level = 78;
			ReqLevel = 60;
			Name = "Grand Marshal's Longsword";
			Name2 = "Grand Marshal's Longsword";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 248182;
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
*				(Blazing Rapier)
*
***************************************************************/

namespace Server.Items
{
	public class BlazingRapier : Item
	{
		public BlazingRapier() : base()
		{
			Id = 12777;
			Bonding = 2;
			SellPrice = 38648;
			AvailableClasses = 0x7FFF;
			Model = 23241;
			ObjectClass = 2;
			SubClass = 7;
			Level = 56;
			ReqLevel = 51;
			Name = "Blazing Rapier";
			Name2 = "Blazing Rapier";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 193242;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1700;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetSpell( 16898 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 44 , 82 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Frostguard)
*
***************************************************************/

namespace Server.Items
{
	public class Frostguard : Item
	{
		public Frostguard() : base()
		{
			Id = 12797;
			Bonding = 2;
			SellPrice = 56943;
			AvailableClasses = 0x7FFF;
			Model = 23274;
			ObjectClass = 2;
			SubClass = 7;
			Level = 63;
			ReqLevel = 58;
			Name = "Frostguard";
			Name2 = "Frostguard";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 284716;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2300;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetSpell( 16927 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 66 , 124 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Dal'Rend's Tribal Guardian)
*
***************************************************************/

namespace Server.Items
{
	public class DalRendsTribalGuardian : Item
	{
		public DalRendsTribalGuardian() : base()
		{
			Id = 12939;
			Resistance[0] = 100;
			Bonding = 1;
			SellPrice = 60363;
			AvailableClasses = 0x7FFF;
			Model = 25647;
			ObjectClass = 2;
			SubClass = 7;
			Level = 63;
			ReqLevel = 58;
			Name = "Dal'Rend's Tribal Guardian";
			Name2 = "Dal'Rend's Tribal Guardian";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 301818;
			Sets = 41;
			InventoryType = InventoryTypes.OffHand;
			Delay = 1800;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetSpell( 13385 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 52 , 97 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Dal'Rend's Sacred Charge)
*
***************************************************************/

namespace Server.Items
{
	public class DalRendsSacredCharge : Item
	{
		public DalRendsSacredCharge() : base()
		{
			Id = 12940;
			Bonding = 1;
			SellPrice = 54812;
			AvailableClasses = 0x7FFF;
			Model = 25648;
			ObjectClass = 2;
			SubClass = 7;
			Level = 63;
			ReqLevel = 58;
			Name = "Dal'Rend's Sacred Charge";
			Name2 = "Dal'Rend's Sacred Charge";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 274063;
			Sets = 41;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2800;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 81 , 151 , Resistances.Armor );
			StrBonus = 4;
		}
	}
}


/**************************************************************
*
*				(The Black Knight)
*
***************************************************************/

namespace Server.Items
{
	public class TheBlackKnight : Item
	{
		public TheBlackKnight() : base()
		{
			Id = 12974;
			Bonding = 2;
			SellPrice = 6105;
			AvailableClasses = 0x7FFF;
			Model = 28676;
			ObjectClass = 2;
			SubClass = 7;
			Level = 31;
			ReqLevel = 26;
			Name = "The Black Knight";
			Name2 = "The Black Knight";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 30525;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1900;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetSpell( 14106 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 26 , 49 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Ironpatch Blade)
*
***************************************************************/

namespace Server.Items
{
	public class IronpatchBlade : Item
	{
		public IronpatchBlade() : base()
		{
			Id = 12976;
			Bonding = 2;
			SellPrice = 1770;
			AvailableClasses = 0x7FFF;
			Model = 8272;
			ObjectClass = 2;
			SubClass = 7;
			Level = 20;
			ReqLevel = 15;
			Name = "Ironpatch Blade";
			Name2 = "Ironpatch Blade";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 8852;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2600;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			SetDamage( 24 , 46 , Resistances.Armor );
			StrBonus = 4;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Sword of Corruption)
*
***************************************************************/

namespace Server.Items
{
	public class SwordOfCorruption : Item
	{
		public SwordOfCorruption() : base()
		{
			Id = 13032;
			Bonding = 2;
			SellPrice = 4138;
			AvailableClasses = 0x7FFF;
			Model = 25639;
			ObjectClass = 2;
			SubClass = 7;
			Level = 27;
			ReqLevel = 22;
			Name = "Sword of Corruption";
			Name2 = "Sword of Corruption";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 20693;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2100;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 80;
			SetSpell( 17510 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 25 , 47 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Zealot Blade)
*
***************************************************************/

namespace Server.Items
{
	public class ZealotBlade : Item
	{
		public ZealotBlade() : base()
		{
			Id = 13033;
			Bonding = 2;
			SellPrice = 8094;
			AvailableClasses = 0x7FFF;
			Model = 28594;
			ObjectClass = 2;
			SubClass = 7;
			Level = 34;
			ReqLevel = 29;
			Name = "Zealot Blade";
			Name2 = "Zealot Blade";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 40472;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2800;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetDamage( 43 , 81 , Resistances.Armor );
			IqBonus = 6;
			SpiritBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Speedsteel Rapier)
*
***************************************************************/

namespace Server.Items
{
	public class SpeedsteelRapier : Item
	{
		public SpeedsteelRapier() : base()
		{
			Id = 13034;
			Bonding = 2;
			SellPrice = 14710;
			AvailableClasses = 0x7FFF;
			Model = 28708;
			ObjectClass = 2;
			SubClass = 7;
			Level = 41;
			ReqLevel = 36;
			Name = "Speedsteel Rapier";
			Name2 = "Speedsteel Rapier";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 73551;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1800;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetDamage( 35 , 66 , Resistances.Armor );
			AgilityBonus = 8;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Serpent Slicer)
*
***************************************************************/

namespace Server.Items
{
	public class SerpentSlicer : Item
	{
		public SerpentSlicer() : base()
		{
			Id = 13035;
			Bonding = 2;
			SellPrice = 25141;
			AvailableClasses = 0x7FFF;
			Model = 25640;
			ObjectClass = 2;
			SubClass = 7;
			Level = 49;
			ReqLevel = 44;
			Name = "Serpent Slicer";
			Name2 = "Serpent Slicer";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 125706;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2500;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetSpell( 17511 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 57 , 107 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Assassination Blade)
*
***************************************************************/

namespace Server.Items
{
	public class AssassinationBlade : Item
	{
		public AssassinationBlade() : base()
		{
			Id = 13036;
			Bonding = 2;
			SellPrice = 40988;
			AvailableClasses = 0x7FFF;
			Model = 25641;
			ObjectClass = 2;
			SubClass = 7;
			Level = 57;
			ReqLevel = 52;
			Name = "Assassination Blade";
			Name2 = "Assassination Blade";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 204943;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2700;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 71 , 132 , Resistances.Armor );
			StrBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Phase Blade)
*
***************************************************************/

namespace Server.Items
{
	public class PhaseBlade : Item
	{
		public PhaseBlade() : base()
		{
			Id = 13182;
			Bonding = 1;
			SellPrice = 30885;
			AvailableClasses = 0x7FFF;
			Model = 23734;
			ObjectClass = 2;
			SubClass = 7;
			Level = 54;
			ReqLevel = 49;
			Name = "Phase Blade";
			Name2 = "Phase Blade";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 154429;
			InventoryType = InventoryTypes.OffHand;
			Delay = 2100;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 47 , 88 , Resistances.Armor );
			StaminaBonus = 8;
			StrBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Argent Avenger)
*
***************************************************************/

namespace Server.Items
{
	public class ArgentAvenger : Item
	{
		public ArgentAvenger() : base()
		{
			Id = 13246;
			Bonding = 1;
			SellPrice = 53622;
			AvailableClasses = 0x7FFF;
			Model = 23836;
			ObjectClass = 2;
			SubClass = 7;
			Level = 62;
			Name = "Argent Avenger";
			Name2 = "Argent Avenger";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 268114;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2200;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetSpell( 17352 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 71 , 108 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Skullforge Reaver)
*
***************************************************************/

namespace Server.Items
{
	public class SkullforgeReaver : Item
	{
		public SkullforgeReaver() : base()
		{
			Id = 13361;
			Bonding = 1;
			SellPrice = 56730;
			AvailableClasses = 0x7FFF;
			Model = 25036;
			ObjectClass = 2;
			SubClass = 7;
			Level = 63;
			ReqLevel = 58;
			Name = "Skullforge Reaver";
			Name2 = "Skullforge Reaver";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 283650;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2500;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 90;
			SetSpell( 17484 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 72 , 135 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Fine Longsword)
*
***************************************************************/

namespace Server.Items
{
	public class FineLongsword : Item
	{
		public FineLongsword() : base()
		{
			Id = 13816;
			SellPrice = 10561;
			AvailableClasses = 0x7FFF;
			Model = 20225;
			ObjectClass = 2;
			SubClass = 7;
			Level = 52;
			ReqLevel = 47;
			Name = "Fine Longsword";
			Name2 = "Fine Longsword";
			AvailableRaces = 0x1FF;
			BuyPrice = 52808;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2200;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 28 , 53 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Silent Fang)
*
***************************************************************/

namespace Server.Items
{
	public class SilentFang : Item
	{
		public SilentFang() : base()
		{
			Id = 13953;
			Bonding = 1;
			SellPrice = 56880;
			AvailableClasses = 0x7FFF;
			Model = 24756;
			ObjectClass = 2;
			SubClass = 7;
			Level = 62;
			ReqLevel = 57;
			Name = "Silent Fang";
			Name2 = "Silent Fang";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 284402;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1600;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetSpell( 18278 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 45 , 85 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Cursed Felblade)
*
***************************************************************/

namespace Server.Items
{
	public class CursedFelblade : Item
	{
		public CursedFelblade() : base()
		{
			Id = 14145;
			Bonding = 1;
			SellPrice = 1032;
			AvailableClasses = 0x7FFF;
			Model = 24981;
			ObjectClass = 2;
			SubClass = 7;
			Level = 18;
			ReqLevel = 13;
			Name = "Cursed Felblade";
			Name2 = "Cursed Felblade";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5161;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2600;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 55;
			SetSpell( 18381 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 16 , 31 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Ebon Hilt of Marduk)
*
***************************************************************/

namespace Server.Items
{
	public class EbonHiltOfMarduk : Item
	{
		public EbonHiltOfMarduk() : base()
		{
			Id = 14576;
			Bonding = 1;
			SellPrice = 48770;
			AvailableClasses = 0x7FFF;
			Model = 25173;
			ObjectClass = 2;
			SubClass = 7;
			Level = 59;
			ReqLevel = 54;
			Name = "Ebon Hilt of Marduk";
			Name2 = "Ebon Hilt of Marduk";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 243853;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2700;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetSpell( 18656 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 73 , 137 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Raider Shortsword)
*
***************************************************************/

namespace Server.Items
{
	public class RaiderShortsword15210 : Item
	{
		public RaiderShortsword15210() : base()
		{
			Id = 15210;
			Bonding = 2;
			SellPrice = 825;
			AvailableClasses = 0x7FFF;
			Model = 28544;
			ObjectClass = 2;
			SubClass = 7;
			Level = 16;
			ReqLevel = 11;
			Name = "Raider Shortsword";
			Name2 = "Raider Shortsword";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5177;
			BuyPrice = 4128;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1900;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 50;
			SetDamage( 11 , 20 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Militant Shortsword)
*
***************************************************************/

namespace Server.Items
{
	public class MilitantShortsword : Item
	{
		public MilitantShortsword() : base()
		{
			Id = 15211;
			Bonding = 2;
			SellPrice = 1916;
			AvailableClasses = 0x7FFF;
			Model = 28567;
			ObjectClass = 2;
			SubClass = 7;
			Level = 22;
			ReqLevel = 17;
			Name = "Militant Shortsword";
			Name2 = "Militant Shortsword";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5195;
			BuyPrice = 9584;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2500;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 60;
			SetDamage( 19 , 36 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Fighter Broadsword)
*
***************************************************************/

namespace Server.Items
{
	public class FighterBroadsword : Item
	{
		public FighterBroadsword() : base()
		{
			Id = 15212;
			Bonding = 2;
			SellPrice = 3450;
			AvailableClasses = 0x7FFF;
			Model = 28527;
			ObjectClass = 2;
			SubClass = 7;
			Level = 27;
			ReqLevel = 22;
			Name = "Fighter Broadsword";
			Name2 = "Fighter Broadsword";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5204;
			BuyPrice = 17252;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2800;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 70;
			SetDamage( 27 , 51 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Mercenary Blade)
*
***************************************************************/

namespace Server.Items
{
	public class MercenaryBlade : Item
	{
		public MercenaryBlade() : base()
		{
			Id = 15213;
			Bonding = 2;
			SellPrice = 8165;
			AvailableClasses = 0x7FFF;
			Model = 28570;
			ObjectClass = 2;
			SubClass = 7;
			Level = 36;
			ReqLevel = 31;
			Name = "Mercenary Blade";
			Name2 = "Mercenary Blade";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5231;
			BuyPrice = 40829;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2400;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 31 , 59 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Nobles Brand)
*
***************************************************************/

namespace Server.Items
{
	public class NoblesBrand : Item
	{
		public NoblesBrand() : base()
		{
			Id = 15214;
			Bonding = 2;
			SellPrice = 11356;
			AvailableClasses = 0x7FFF;
			Model = 28561;
			ObjectClass = 2;
			SubClass = 7;
			Level = 40;
			ReqLevel = 35;
			Name = "Nobles Brand";
			Name2 = "Nobles Brand";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5249;
			BuyPrice = 56781;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2100;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 32 , 61 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Furious Falchion)
*
***************************************************************/

namespace Server.Items
{
	public class FuriousFalchion : Item
	{
		public FuriousFalchion() : base()
		{
			Id = 15215;
			Bonding = 2;
			SellPrice = 16744;
			AvailableClasses = 0x7FFF;
			Model = 28528;
			ObjectClass = 2;
			SubClass = 7;
			Level = 45;
			ReqLevel = 40;
			Name = "Furious Falchion";
			Name2 = "Furious Falchion";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5258;
			BuyPrice = 83720;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2500;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 46 , 87 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Rune Sword)
*
***************************************************************/

namespace Server.Items
{
	public class RuneSword : Item
	{
		public RuneSword() : base()
		{
			Id = 15216;
			Bonding = 2;
			SellPrice = 25932;
			AvailableClasses = 0x7FFF;
			Model = 28530;
			ObjectClass = 2;
			SubClass = 7;
			Level = 51;
			ReqLevel = 46;
			Name = "Rune Sword";
			Name2 = "Rune Sword";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5276;
			BuyPrice = 129661;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1600;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 34 , 63 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Widow Blade)
*
***************************************************************/

namespace Server.Items
{
	public class WidowBlade : Item
	{
		public WidowBlade() : base()
		{
			Id = 15217;
			Bonding = 2;
			SellPrice = 30996;
			AvailableClasses = 0x7FFF;
			Model = 28458;
			ObjectClass = 2;
			SubClass = 7;
			Level = 54;
			ReqLevel = 49;
			Name = "Widow Blade";
			Name2 = "Widow Blade";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5285;
			BuyPrice = 154980;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2000;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 45 , 84 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Crystal Sword)
*
***************************************************************/

namespace Server.Items
{
	public class CrystalSword : Item
	{
		public CrystalSword() : base()
		{
			Id = 15218;
			Bonding = 2;
			SellPrice = 37047;
			AvailableClasses = 0x7FFF;
			Model = 28346;
			ObjectClass = 2;
			SubClass = 7;
			Level = 57;
			ReqLevel = 52;
			Name = "Crystal Sword";
			Name2 = "Crystal Sword";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5294;
			BuyPrice = 185239;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2300;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 54 , 102 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Dimensional Blade)
*
***************************************************************/

namespace Server.Items
{
	public class DimensionalBlade : Item
	{
		public DimensionalBlade() : base()
		{
			Id = 15219;
			Bonding = 2;
			SellPrice = 41376;
			AvailableClasses = 0x7FFF;
			Model = 13078;
			ObjectClass = 2;
			SubClass = 7;
			Level = 59;
			ReqLevel = 54;
			Name = "Dimensional Blade";
			Name2 = "Dimensional Blade";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5303;
			BuyPrice = 206882;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1600;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 39 , 73 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Battlefell Sabre)
*
***************************************************************/

namespace Server.Items
{
	public class BattlefellSabre : Item
	{
		public BattlefellSabre() : base()
		{
			Id = 15220;
			Bonding = 2;
			SellPrice = 43493;
			AvailableClasses = 0x7FFF;
			Model = 28316;
			ObjectClass = 2;
			SubClass = 7;
			Level = 62;
			ReqLevel = 57;
			Name = "Battlefell Sabre";
			Name2 = "Battlefell Sabre";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5312;
			BuyPrice = 217465;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2200;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 57 , 106 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Holy War Sword)
*
***************************************************************/

namespace Server.Items
{
	public class HolyWarSword : Item
	{
		public HolyWarSword() : base()
		{
			Id = 15221;
			Bonding = 2;
			SellPrice = 51946;
			AvailableClasses = 0x7FFF;
			Model = 28552;
			ObjectClass = 2;
			SubClass = 7;
			Level = 65;
			ReqLevel = 60;
			Name = "Holy War Sword";
			Name2 = "Holy War Sword";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5321;
			BuyPrice = 259732;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2200;
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
*				(Briarsteel Shortsword)
*
***************************************************************/

namespace Server.Items
{
	public class BriarsteelShortsword : Item
	{
		public BriarsteelShortsword() : base()
		{
			Id = 15335;
			Bonding = 1;
			SellPrice = 580;
			AvailableClasses = 0x7FFF;
			Model = 28093;
			ObjectClass = 2;
			SubClass = 7;
			Level = 14;
			Name = "Briarsteel Shortsword";
			Name2 = "Briarsteel Shortsword";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2904;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2500;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 45;
			SetDamage( 12 , 24 , Resistances.Armor );
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Tidecrest Blade)
*
***************************************************************/

namespace Server.Items
{
	public class TidecrestBlade : Item
	{
		public TidecrestBlade() : base()
		{
			Id = 15705;
			Bonding = 1;
			SellPrice = 33830;
			AvailableClasses = 0x7FFF;
			Model = 26432;
			ObjectClass = 2;
			SubClass = 7;
			Level = 57;
			Name = "Tidecrest Blade";
			Name2 = "Tidecrest Blade";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 169154;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2600;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 62 , 115 , Resistances.Armor );
			StrBonus = 8;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Beaststalker Blade)
*
***************************************************************/

namespace Server.Items
{
	public class BeaststalkerBlade : Item
	{
		public BeaststalkerBlade() : base()
		{
			Id = 15782;
			Bonding = 1;
			SellPrice = 43142;
			AvailableClasses = 0x7FFF;
			Model = 26463;
			ObjectClass = 2;
			SubClass = 7;
			Level = 60;
			Name = "Beaststalker Blade";
			Name2 = "Beaststalker Blade";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 215714;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2200;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetSpell( 19380 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 55 , 103 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Intrepid Shortsword)
*
***************************************************************/

namespace Server.Items
{
	public class IntrepidShortsword : Item
	{
		public IntrepidShortsword() : base()
		{
			Id = 15800;
			Bonding = 1;
			SellPrice = 36082;
			AvailableClasses = 0x7FFF;
			Model = 26477;
			ObjectClass = 2;
			SubClass = 7;
			Level = 58;
			Name = "Intrepid Shortsword";
			Name2 = "Intrepid Shortsword";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 180413;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2100;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 50 , 95 , Resistances.Armor );
			StaminaBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Valiant Shortsword)
*
***************************************************************/

namespace Server.Items
{
	public class ValiantShortsword : Item
	{
		public ValiantShortsword() : base()
		{
			Id = 15801;
			Bonding = 1;
			SellPrice = 35860;
			AvailableClasses = 0x7FFF;
			Model = 26479;
			ObjectClass = 2;
			SubClass = 7;
			Level = 58;
			Name = "Valiant Shortsword";
			Name2 = "Valiant Shortsword";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 179303;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2100;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 50 , 95 , Resistances.Armor );
			SpiritBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Mirah's Song)
*
***************************************************************/

namespace Server.Items
{
	public class MirahsSong : Item
	{
		public MirahsSong() : base()
		{
			Id = 15806;
			Bonding = 1;
			SellPrice = 51273;
			AvailableClasses = 0x7FFF;
			Model = 26494;
			ObjectClass = 2;
			SubClass = 7;
			Level = 61;
			Name = "Mirah's Song";
			Name2 = "Mirah's Song";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 256366;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1800;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetDamage( 57 , 87 , Resistances.Armor );
			AgilityBonus = 9;
			StrBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Hameya's Slayer)
*
***************************************************************/

namespace Server.Items
{
	public class HameyasSlayer : Item
	{
		public HameyasSlayer() : base()
		{
			Id = 15814;
			Bonding = 1;
			SellPrice = 41911;
			AvailableClasses = 0x7FFF;
			Model = 26503;
			ObjectClass = 2;
			SubClass = 7;
			Level = 60;
			Name = "Hameya's Slayer";
			Name2 = "Hameya's Slayer";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 209558;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2000;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetSpell( 16406 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 57 , 86 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(High Warlord's Blade)
*
***************************************************************/

namespace Server.Items
{
	public class HighWarlordsBlade : Item
	{
		public HighWarlordsBlade() : base()
		{
			Id = 16345;
			Bonding = 1;
			SellPrice = 49483;
			AvailableClasses = 0x7FFF;
			Model = 31997;
			ObjectClass = 2;
			SubClass = 7;
			Level = 78;
			ReqLevel = 60;
			Name = "High Warlord's Blade";
			Name2 = "High Warlord's Blade";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 247416;
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
*				(Outlaw Sabre)
*
***************************************************************/

namespace Server.Items
{
	public class OutlawSabre : Item
	{
		public OutlawSabre() : base()
		{
			Id = 16886;
			Bonding = 1;
			SellPrice = 5492;
			AvailableClasses = 0x7FFF;
			Model = 28586;
			ObjectClass = 2;
			SubClass = 7;
			Level = 30;
			Name = "Outlaw Sabre";
			Name2 = "Outlaw Sabre";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 27462;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2700;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetSpell( 20732 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 35 , 67 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Slatemetal Cutlass)
*
***************************************************************/

namespace Server.Items
{
	public class SlatemetalCutlass : Item
	{
		public SlatemetalCutlass() : base()
		{
			Id = 16890;
			Bonding = 1;
			SellPrice = 2483;
			AvailableClasses = 0x7FFF;
			Model = 28593;
			ObjectClass = 2;
			SubClass = 7;
			Level = 24;
			Name = "Slatemetal Cutlass";
			Name2 = "Slatemetal Cutlass";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 12416;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2200;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			SetDamage( 19 , 35 , Resistances.Armor );
			StrBonus = 2;
			AgilityBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Claystone Shortsword)
*
***************************************************************/

namespace Server.Items
{
	public class ClaystoneShortsword : Item
	{
		public ClaystoneShortsword() : base()
		{
			Id = 16891;
			Bonding = 1;
			SellPrice = 1697;
			AvailableClasses = 0x7FFF;
			Model = 28608;
			ObjectClass = 2;
			SubClass = 7;
			Level = 21;
			Name = "Claystone Shortsword";
			Name2 = "Claystone Shortsword";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 8485;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2200;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 60;
			SetDamage( 16 , 30 , Resistances.Armor );
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Dark Iron Reaver)
*
***************************************************************/

namespace Server.Items
{
	public class DarkIronReaver : Item
	{
		public DarkIronReaver() : base()
		{
			Id = 17015;
			Bonding = 2;
			SellPrice = 63738;
			AvailableClasses = 0x7FFF;
			Model = 28848;
			Resistance[2] = 6;
			ObjectClass = 2;
			SubClass = 7;
			Level = 65;
			ReqLevel = 60;
			Name = "Dark Iron Reaver";
			Name2 = "Dark Iron Reaver";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 318693;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2400;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetDamage( 71 , 134 , Resistances.Armor );
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Joonho's Mercy)
*
***************************************************************/

namespace Server.Items
{
	public class JoonhosMercy : Item
	{
		public JoonhosMercy() : base()
		{
			Id = 17054;
			Bonding = 2;
			SellPrice = 28788;
			AvailableClasses = 0x7FFF;
			Model = 28876;
			ObjectClass = 2;
			SubClass = 7;
			Level = 50;
			ReqLevel = 45;
			Name = "Joonho's Mercy";
			Name2 = "Joonho's Mercy";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 143942;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2100;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetSpell( 20883 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 49 , 91 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Vis'kag the Bloodletter)
*
***************************************************************/

namespace Server.Items
{
	public class ViskagTheBloodletter : Item
	{
		public ViskagTheBloodletter() : base()
		{
			Id = 17075;
			Bonding = 1;
			SellPrice = 135266;
			AvailableClasses = 0x7FFF;
			Model = 29132;
			ObjectClass = 2;
			SubClass = 7;
			Level = 74;
			ReqLevel = 60;
			Name = "Vis'kag the Bloodletter";
			Name2 = "Vis'kag the Bloodletter";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 676334;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2600;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 3;
			Durability = 105;
			SetSpell( 21140 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 100 , 187 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Azuresong Mageblade)
*
***************************************************************/

namespace Server.Items
{
	public class AzuresongMageblade : Item
	{
		public AzuresongMageblade() : base()
		{
			Id = 17103;
			Bonding = 1;
			SellPrice = 111823;
			AvailableClasses = 0x7FFF;
			Model = 29677;
			ObjectClass = 2;
			SubClass = 7;
			Level = 71;
			ReqLevel = 60;
			Name = "Azuresong Mageblade";
			Name2 = "Azuresong Mageblade";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 559117;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2400;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 105;
			SetSpell( 18384 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 18056 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 64 , 140 , Resistances.Armor );
			SpiritBonus = 12;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Thrash Blade)
*
***************************************************************/

namespace Server.Items
{
	public class ThrashBlade : Item
	{
		public ThrashBlade() : base()
		{
			Id = 17705;
			Bonding = 1;
			SellPrice = 32854;
			AvailableClasses = 0x7FFF;
			Model = 29769;
			ObjectClass = 2;
			SubClass = 7;
			Level = 53;
			Name = "Thrash Blade";
			Name2 = "Thrash Blade";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 164272;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2700;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetSpell( 21919 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 66 , 124 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Inventor's Focal Sword)
*
***************************************************************/

namespace Server.Items
{
	public class InventorsFocalSword : Item
	{
		public InventorsFocalSword() : base()
		{
			Id = 17719;
			Bonding = 1;
			SellPrice = 32106;
			AvailableClasses = 0x7FFF;
			Model = 29897;
			ObjectClass = 2;
			SubClass = 7;
			Level = 53;
			ReqLevel = 48;
			Name = "Inventor's Focal Sword";
			Name2 = "Inventor's Focal Sword";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 160530;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2200;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetSpell( 18384 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 54 , 101 , Resistances.Armor );
			SpiritBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Fiendish Machete)
*
***************************************************************/

namespace Server.Items
{
	public class FiendishMachete : Item
	{
		public FiendishMachete() : base()
		{
			Id = 18310;
			Bonding = 1;
			SellPrice = 47406;
			AvailableClasses = 0x7FFF;
			Model = 30673;
			ObjectClass = 2;
			SubClass = 7;
			Level = 59;
			ReqLevel = 54;
			Name = "Fiendish Machete";
			Name2 = "Fiendish Machete";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 237032;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2400;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetSpell( 22836 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 74 , 112 , Resistances.Armor );
			AgilityBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Quel'Serrar)
*
***************************************************************/

namespace Server.Items
{
	public class QuelSerrar : Item
	{
		public QuelSerrar() : base()
		{
			Id = 18348;
			Bonding = 1;
			SellPrice = 112651;
			AvailableClasses = 0x03;
			Description = "The High Blade";
			Model = 30994;
			ObjectClass = 2;
			SubClass = 7;
			Level = 71;
			ReqLevel = 60;
			Name = "Quel'Serrar";
			Name2 = "Quel'Serrar";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 563257;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2000;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 3;
			Durability = 105;
			Flags = 32768;
			SetSpell( 22850 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 84 , 126 , Resistances.Armor );
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Mind Carver)
*
***************************************************************/

namespace Server.Items
{
	public class MindCarver : Item
	{
		public MindCarver() : base()
		{
			Id = 18396;
			Bonding = 1;
			SellPrice = 57516;
			AvailableClasses = 0x7FFF;
			Model = 30754;
			ObjectClass = 2;
			SubClass = 7;
			Level = 62;
			ReqLevel = 57;
			Name = "Mind Carver";
			Name2 = "Mind Carver";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 287583;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2000;
			Stackable = 1;
			Material = 6;
			Sheath = 3;
			Durability = 90;
			SetSpell( 9417 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 57 , 106 , Resistances.Armor );
			SpiritBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Ogre Pocket Knife)
*
***************************************************************/

namespace Server.Items
{
	public class OgrePocketKnife : Item
	{
		public OgrePocketKnife() : base()
		{
			Id = 18463;
			Bonding = 1;
			SellPrice = 41472;
			AvailableClasses = 0x7FFF;
			Model = 30814;
			ObjectClass = 2;
			SubClass = 7;
			Level = 60;
			ReqLevel = 55;
			Name = "Ogre Pocket Knife";
			Name2 = "Ogre Pocket Knife";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 207361;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2400;
			Stackable = 1;
			Material = 6;
			Sheath = 3;
			Durability = 75;
			SetSpell( 9329 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 60 , 112 , Resistances.Armor );
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Cho'Rush's Blade)
*
***************************************************************/

namespace Server.Items
{
	public class ChoRushsBlade : Item
	{
		public ChoRushsBlade() : base()
		{
			Id = 18484;
			Bonding = 1;
			SellPrice = 53822;
			AvailableClasses = 0x7FFF;
			Model = 30822;
			ObjectClass = 2;
			SubClass = 7;
			Level = 61;
			ReqLevel = 56;
			Name = "Cho'Rush's Blade";
			Name2 = "Cho'Rush's Blade";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 269110;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2400;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetSpell( 9335 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 67 , 125 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(The Twin Blades of Azzinoth)
*
***************************************************************/

namespace Server.Items
{
	public class TheTwinBladesOfAzzinoth : Item
	{
		public TheTwinBladesOfAzzinoth() : base()
		{
			Id = 18582;
			Resistance[6] = 100;
			Bonding = 1;
			SellPrice = 1224473;
			AvailableClasses = 0x7FFF;
			Model = 30936;
			ObjectClass = 2;
			SubClass = 7;
			Level = 100;
			ReqLevel = 70;
			Name = "The Twin Blades of Azzinoth";
			Name2 = "The Twin Blades of Azzinoth";
			Quality = 6;
			AvailableRaces = 0x1FF;
			BuyPrice = 6122369;
			Resistance[5] = 100;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1500;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Sheath = 3;
			Flags = 33792;
			SetSpell( 22988 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 22989 , 0 , 0 , -1 , 0 , -1 );
			SetDamage( 162 , 169 , Resistances.Armor );
			SetDamage( 40 , 60 , Resistances.Shadow );
			SetDamage( 40 , 60 , Resistances.Arcane );
			AgilityBonus = 75;
			StaminaBonus = 100;
			SpiritBonus = 150;
		}
	}
}


/**************************************************************
*
*				(Keen Machete)
*
***************************************************************/

namespace Server.Items
{
	public class KeenMachete : Item
	{
		public KeenMachete() : base()
		{
			Id = 18610;
			Bonding = 2;
			SellPrice = 36;
			AvailableClasses = 0x7FFF;
			Model = 5139;
			ObjectClass = 2;
			SubClass = 7;
			Level = 6;
			ReqLevel = 1;
			Name = "Keen Machete";
			Name2 = "Keen Machete";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 181;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1800;
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
*				(Brutality Blade)
*
***************************************************************/

namespace Server.Items
{
	public class BrutalityBlade : Item
	{
		public BrutalityBlade() : base()
		{
			Id = 18832;
			Bonding = 1;
			SellPrice = 104089;
			AvailableClasses = 0x7FFF;
			Model = 31309;
			ObjectClass = 2;
			SubClass = 7;
			Level = 70;
			ReqLevel = 60;
			Name = "Brutality Blade";
			Name2 = "Brutality Blade";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 520447;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2500;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 3;
			Durability = 105;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 90 , 168 , Resistances.Armor );
			StrBonus = 9;
			AgilityBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Brushwood Blade)
*
***************************************************************/

namespace Server.Items
{
	public class BrushwoodBlade18957 : Item
	{
		public BrushwoodBlade18957() : base()
		{
			Id = 18957;
			Bonding = 1;
			SellPrice = 288;
			AvailableClasses = 0x7FFF;
			Model = 31400;
			ObjectClass = 2;
			SubClass = 7;
			Level = 10;
			Name = "Brushwood Blade";
			Name2 = "Brushwood Blade";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1441;
			InventoryType = InventoryTypes.TwoHanded;
			Delay = 3000;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 40;
			SetDamage( 17 , 26 , Resistances.Armor );
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Thunderfury, Blessed Blade of the Windseeker)
*
***************************************************************/

namespace Server.Items
{
	public class ThunderfuryBlessedBladeOfTheWindseeker : Item
	{
		public ThunderfuryBlessedBladeOfTheWindseeker() : base()
		{
			Id = 19019;
			Bonding = 1;
			SellPrice = 251765;
			AvailableClasses = 0x7FFF;
			Model = 30606;
			Resistance[2] = 8;
			ObjectClass = 2;
			SubClass = 7;
			Level = 80;
			ReqLevel = 60;
			Name = "Thunderfury, Blessed Blade of the Windseeker";
			Name2 = "Thunderfury, Blessed Blade of the Windseeker";
			Resistance[3] = 9;
			Quality = 5;
			AvailableRaces = 0x1FF;
			BuyPrice = 1258828;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1900;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 1;
			Durability = 125;
			SetSpell( 21992 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 44 , 115 , Resistances.Armor );
			SetDamage( 16 , 30 , Resistances.Nature );
			AgilityBonus = 5;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Zorbin's Mega-Slicer)
*
***************************************************************/

namespace Server.Items
{
	public class ZorbinsMegaSlicer : Item
	{
		public ZorbinsMegaSlicer() : base()
		{
			Id = 19040;
			Bonding = 1;
			SellPrice = 19468;
			AvailableClasses = 0x7FFF;
			Model = 31526;
			ObjectClass = 2;
			SubClass = 7;
			Level = 48;
			Name = "Zorbin's Mega-Slicer";
			Name2 = "Zorbin's Mega-Slicer";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 97341;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2300;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 46 , 86 , Resistances.Armor );
			AgilityBonus = 6;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Cold Forged Blade)
*
***************************************************************/

namespace Server.Items
{
	public class ColdForgedBlade : Item
	{
		public ColdForgedBlade() : base()
		{
			Id = 19110;
			Bonding = 1;
			SellPrice = 54922;
			AvailableClasses = 0x7FFF;
			Model = 31617;
			ObjectClass = 2;
			SubClass = 7;
			Level = 63;
			ReqLevel = 58;
			Name = "Cold Forged Blade";
			Name2 = "Cold Forged Blade";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 274611;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2600;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			SetDamage( 75 , 140 , Resistances.Armor );
			StaminaBonus = 13;
			AgilityBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Blackguard)
*
***************************************************************/

namespace Server.Items
{
	public class Blackguard : Item
	{
		public Blackguard() : base()
		{
			Id = 19168;
			Bonding = 2;
			SellPrice = 102890;
			AvailableClasses = 0x7FFF;
			Model = 31692;
			ObjectClass = 2;
			SubClass = 7;
			Level = 70;
			ReqLevel = 60;
			Name = "Blackguard";
			Name2 = "Blackguard";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 514451;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1800;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 105;
			SetSpell( 13665 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 65 , 121 , Resistances.Armor );
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Maladath, Runed Blade of the Black Flight)
*
***************************************************************/

namespace Server.Items
{
	public class MaladathRunedBladeOfTheBlackFlight : Item
	{
		public MaladathRunedBladeOfTheBlackFlight() : base()
		{
			Id = 19351;
			Bonding = 1;
			SellPrice = 139989;
			AvailableClasses = 0x7FFF;
			Model = 31866;
			ObjectClass = 2;
			SubClass = 7;
			Level = 75;
			ReqLevel = 60;
			Name = "Maladath, Runed Blade of the Black Flight";
			Name2 = "Maladath, Runed Blade of the Black Flight";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 699948;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2200;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 3;
			Durability = 105;
			SetSpell( 13665 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 14121 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 86 , 162 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Chromatically Tempered Sword)
*
***************************************************************/

namespace Server.Items
{
	public class ChromaticallyTemperedSword : Item
	{
		public ChromaticallyTemperedSword() : base()
		{
			Id = 19352;
			Bonding = 1;
			SellPrice = 158929;
			AvailableClasses = 0x7FFF;
			Model = 31867;
			ObjectClass = 2;
			SubClass = 7;
			Level = 77;
			ReqLevel = 60;
			Name = "Chromatically Tempered Sword";
			Name2 = "Chromatically Tempered Sword";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 794646;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2600;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 3;
			Durability = 105;
			SetDamage( 106 , 198 , Resistances.Armor );
			AgilityBonus = 14;
			StrBonus = 14;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Legionnaire's Sword)
*
***************************************************************/

namespace Server.Items
{
	public class LegionnairesSword : Item
	{
		public LegionnairesSword() : base()
		{
			Id = 19550;
			Bonding = 1;
			SellPrice = 54922;
			AvailableClasses = 0x7FFF;
			Model = 32076;
			ObjectClass = 2;
			SubClass = 7;
			Level = 63;
			ReqLevel = 58;
			Name = "Legionnaire's Sword";
			Name2 = "Legionnaire's Sword";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 274611;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2700;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			Flags = 32768;
			SetDamage( 78 , 146 , Resistances.Armor );
			StrBonus = 13;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Legionnaire's Sword)
*
***************************************************************/

namespace Server.Items
{
	public class LegionnairesSword19551 : Item
	{
		public LegionnairesSword19551() : base()
		{
			Id = 19551;
			Bonding = 1;
			SellPrice = 32156;
			AvailableClasses = 0x7FFF;
			Model = 32076;
			ObjectClass = 2;
			SubClass = 7;
			Level = 53;
			ReqLevel = 48;
			Name = "Legionnaire's Sword";
			Name2 = "Legionnaire's Sword";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 160783;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2700;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			Flags = 32768;
			SetDamage( 66 , 124 , Resistances.Armor );
			StrBonus = 11;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Legionnaire's Sword)
*
***************************************************************/

namespace Server.Items
{
	public class LegionnairesSword19552 : Item
	{
		public LegionnairesSword19552() : base()
		{
			Id = 19552;
			Bonding = 1;
			SellPrice = 15899;
			AvailableClasses = 0x7FFF;
			Model = 32076;
			ObjectClass = 2;
			SubClass = 7;
			Level = 43;
			ReqLevel = 38;
			Name = "Legionnaire's Sword";
			Name2 = "Legionnaire's Sword";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 79498;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2700;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			Flags = 32768;
			SetDamage( 55 , 103 , Resistances.Armor );
			StrBonus = 8;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Legionnaire's Sword)
*
***************************************************************/

namespace Server.Items
{
	public class LegionnairesSword19553 : Item
	{
		public LegionnairesSword19553() : base()
		{
			Id = 19553;
			Bonding = 1;
			SellPrice = 6843;
			AvailableClasses = 0x7FFF;
			Model = 32076;
			ObjectClass = 2;
			SubClass = 7;
			Level = 33;
			ReqLevel = 28;
			Name = "Legionnaire's Sword";
			Name2 = "Legionnaire's Sword";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 34217;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2700;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			Flags = 32768;
			SetDamage( 40 , 75 , Resistances.Armor );
			StrBonus = 7;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Protector's Sword)
*
***************************************************************/

namespace Server.Items
{
	public class ProtectorsSword : Item
	{
		public ProtectorsSword() : base()
		{
			Id = 19554;
			Bonding = 1;
			SellPrice = 54922;
			AvailableClasses = 0x7FFF;
			Model = 32077;
			ObjectClass = 2;
			SubClass = 7;
			Level = 63;
			ReqLevel = 58;
			Name = "Protector's Sword";
			Name2 = "Protector's Sword";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 274611;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2700;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			Flags = 32768;
			SetDamage( 78 , 146 , Resistances.Armor );
			StrBonus = 13;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Protector's Sword)
*
***************************************************************/

namespace Server.Items
{
	public class ProtectorsSword19555 : Item
	{
		public ProtectorsSword19555() : base()
		{
			Id = 19555;
			Bonding = 1;
			SellPrice = 32156;
			AvailableClasses = 0x7FFF;
			Model = 32077;
			ObjectClass = 2;
			SubClass = 7;
			Level = 53;
			ReqLevel = 48;
			Name = "Protector's Sword";
			Name2 = "Protector's Sword";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 160783;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2700;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			Flags = 32768;
			SetDamage( 66 , 124 , Resistances.Armor );
			StrBonus = 11;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Protector's Sword)
*
***************************************************************/

namespace Server.Items
{
	public class ProtectorsSword19556 : Item
	{
		public ProtectorsSword19556() : base()
		{
			Id = 19556;
			Bonding = 1;
			SellPrice = 15899;
			AvailableClasses = 0x7FFF;
			Model = 32077;
			ObjectClass = 2;
			SubClass = 7;
			Level = 43;
			ReqLevel = 38;
			Name = "Protector's Sword";
			Name2 = "Protector's Sword";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 79498;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2700;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			Flags = 32768;
			SetDamage( 55 , 103 , Resistances.Armor );
			StrBonus = 8;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Protector's Sword)
*
***************************************************************/

namespace Server.Items
{
	public class ProtectorsSword19557 : Item
	{
		public ProtectorsSword19557() : base()
		{
			Id = 19557;
			Bonding = 1;
			SellPrice = 6843;
			AvailableClasses = 0x7FFF;
			Model = 32077;
			ObjectClass = 2;
			SubClass = 7;
			Level = 33;
			ReqLevel = 28;
			Name = "Protector's Sword";
			Name2 = "Protector's Sword";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 34217;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2700;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 3;
			Durability = 90;
			Flags = 32768;
			SetDamage( 40 , 75 , Resistances.Armor );
			SpiritBonus = 7;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Forged Glave (L))
*
***************************************************************/

namespace Server.Items
{
	public class ForgedGlaveL : Item
	{
		public ForgedGlaveL() : base()
		{
			Id = 20050;
			Bonding = 1;
			SellPrice = 300000;
			AvailableClasses = 0x7FFF;
			Model = 22672;
			ObjectClass = 2;
			SubClass = 7;
			ReqLevel = 120;
			Name = "Forged Glave (L)";
			Name2 = "Forged Glave (L)";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 1600000;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1414;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 300;
			SetDamage( 193 , 298 , Resistances.Armor );
			AgilityBonus = 34;
			StrBonus = 39;
			SpiritBonus = -21;
			IqBonus = -40;
		}
	}
}


/**************************************************************
*
*				(Satanic Glave (R))
*
***************************************************************/

namespace Server.Items
{
	public class SatanicGlaveR : Item
	{
		public SatanicGlaveR() : base()
		{
			Id = 20051;
			Bonding = 1;
			SellPrice = 300000;
			AvailableClasses = 0x7FFF;
			Model = 22694;
			ObjectClass = 2;
			SubClass = 7;
			ReqLevel = 120;
			Name = "Satanic Glave (R)";
			Name2 = "Satanic Glave (R)";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 1600000;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1539;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 300;
			SetDamage( 188 , 287 , Resistances.Armor );
			AgilityBonus = 30;
			StrBonus = 40;
			SpiritBonus = -34;
			IqBonus = -24;
		}
	}
}


/**************************************************************
*
*				(Concrete Glave)
*
***************************************************************/

namespace Server.Items
{
	public class ConcreteGlave : Item
	{
		public ConcreteGlave() : base()
		{
			Id = 20052;
			Bonding = 1;
			SellPrice = 450000;
			AvailableClasses = 0x7FFF;
			Model = 25504;
			ObjectClass = 2;
			SubClass = 7;
			ReqLevel = 150;
			Name = "Concrete Glave";
			Name2 = "Concrete Glave";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 2100000;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1459;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 300;
			SetDamage( 287 , 328 , Resistances.Armor );
			AgilityBonus = 49;
			StrBonus = 50;
			SpiritBonus = -46;
			IqBonus = -51;
		}
	}
}


/**************************************************************
*
*				(Silver Glave)
*
***************************************************************/

namespace Server.Items
{
	public class SilverGlave : Item
	{
		public SilverGlave() : base()
		{
			Id = 20053;
			Bonding = 1;
			SellPrice = 450000;
			AvailableClasses = 0x7FFF;
			Model = 4290;
			ObjectClass = 2;
			SubClass = 7;
			ReqLevel = 150;
			Name = "Silver Glave";
			Name2 = "Silver Glave";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 2100000;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1423;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 300;
			SetDamage( 286 , 329 , Resistances.Armor );
			AgilityBonus = 52;
			StrBonus = 47;
			SpiritBonus = -50;
			IqBonus = -50;
		}
	}
}


/**************************************************************
*
*				(Glave of Blessing)
*
***************************************************************/

namespace Server.Items
{
	public class GlaveOfBlessing : Item
	{
		public GlaveOfBlessing() : base()
		{
			Id = 20054;
			Bonding = 1;
			SellPrice = 800000;
			AvailableClasses = 0x7FFF;
			Model = 29397;
			ObjectClass = 2;
			SubClass = 7;
			ReqLevel = 180;
			Name = "Glave of Blessing";
			Name2 = "Glave of Blessing";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 3000000;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1594;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 300;
			SetDamage( 539 , 565 , Resistances.Armor );
			AgilityBonus = 70;
			StrBonus = 78;
			SpiritBonus = -73;
			IqBonus = -71;
		}
	}
}


/**************************************************************
*
*				(Shadow Glave)
*
***************************************************************/

namespace Server.Items
{
	public class ShadowGlave : Item
	{
		public ShadowGlave() : base()
		{
			Id = 20055;
			Bonding = 1;
			SellPrice = 800000;
			AvailableClasses = 0x7FFF;
			Model = 25508;
			ObjectClass = 2;
			SubClass = 7;
			ReqLevel = 180;
			Name = "Shadow Glave";
			Name2 = "Shadow Glave";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 3000000;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1458;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 300;
			SetDamage( 532 , 566 , Resistances.Armor );
			AgilityBonus = 80;
			StrBonus = 69;
			SpiritBonus = -68;
			IqBonus = -75;
		}
	}
}


/**************************************************************
*
*				(Swamp Glave)
*
***************************************************************/

namespace Server.Items
{
	public class SwampGlave : Item
	{
		public SwampGlave() : base()
		{
			Id = 20057;
			Bonding = 1;
			SellPrice = 1500000;
			AvailableClasses = 0x7FFF;
			Model = 24925;
			ObjectClass = 2;
			SubClass = 7;
			ReqLevel = 200;
			Name = "Swamp Glave";
			Name2 = "Swamp Glave";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 3700000;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1448;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 300;
			SetDamage( 809 , 832 , Resistances.Armor );
			AgilityBonus = 112;
			StrBonus = 112;
			SpiritBonus = -72;
			IqBonus = -90;
		}
	}
}


/**************************************************************
*
*				(Oblitiration Glave)
*
***************************************************************/

namespace Server.Items
{
	public class OblitirationGlave : Item
	{
		public OblitirationGlave() : base()
		{
			Id = 20058;
			Bonding = 1;
			SellPrice = 1800000;
			AvailableClasses = 0x7FFF;
			Model = 4291;
			ObjectClass = 2;
			SubClass = 7;
			ReqLevel = 225;
			Name = "Oblitiration Glave";
			Name2 = "Oblitiration Glave";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 4800000;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1499;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 300;
			SetDamage( 1026 , 1062 , Resistances.Armor );
			AgilityBonus = 114;
			StrBonus = 114;
			SpiritBonus = -75;
			IqBonus = -79;
		}
	}
}


/**************************************************************
*
*				(Chaos Glave)
*
***************************************************************/

namespace Server.Items
{
	public class ChaosGlave : Item
	{
		public ChaosGlave() : base()
		{
			Id = 20059;
			Bonding = 1;
			SellPrice = 1800000;
			AvailableClasses = 0x7FFF;
			Model = 25511;
			ObjectClass = 2;
			SubClass = 7;
			ReqLevel = 225;
			Name = "Chaos Glave";
			Name2 = "Chaos Glave";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 4800000;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1554;
			Stackable = 1;
			Material = 1;
			Sheath = 1;
			Durability = 300;
			SetDamage( 1029 , 1062 , Resistances.Armor );
			AgilityBonus = 115;
			StrBonus = 113;
			SpiritBonus = -71;
			IqBonus = -82;
		}
	}
}


