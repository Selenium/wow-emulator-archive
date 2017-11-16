/**************************************************************
*
*		Made by fulgas (fulgas@gmail.com)
*
*  WowwoW Item Designer ( 2005/8/23 - 10:05:32 )
*
***************************************************************/

using System;
using System.Collections;

/***************************************************************/

/**************************************************************
*
*				(Vendetta)
*
***************************************************************/

namespace Server.Items
{
	public class Vendetta : Item
	{
		public Vendetta() : base()
		{
			Id = 776;
			Bonding = 2;
			SellPrice = 5765;
			AvailableClasses = 0x7FFF;
			Model = 6452;
			ObjectClass = 2;
			SubClass = 15;
			Level = 31;
			ReqLevel = 26;
			Name = "Vendetta";
			Name2 = "Vendetta";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 28826;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1300;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			SetDamage( 17 , 33 , Resistances.Armor );
			AgilityBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Small Hand Blade)
*
***************************************************************/

namespace Server.Items
{
	public class SmallHandBlade : Item
	{
		public SmallHandBlade() : base()
		{
			Id = 816;
			Bonding = 2;
			SellPrice = 305;
			AvailableClasses = 0x7FFF;
			Model = 6472;
			ObjectClass = 2;
			SubClass = 15;
			Level = 11;
			ReqLevel = 6;
			Name = "Small Hand Blade";
			Name2 = "Small Hand Blade";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1527;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1500;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 30;
			SetDamage( 6 , 12 , Resistances.Armor );
			AgilityBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Slicer Blade)
*
***************************************************************/

namespace Server.Items
{
	public class SlicerBlade : Item
	{
		public SlicerBlade() : base()
		{
			Id = 820;
			Bonding = 2;
			SellPrice = 947;
			AvailableClasses = 0x7FFF;
			Model = 6470;
			ObjectClass = 2;
			SubClass = 15;
			Level = 17;
			ReqLevel = 12;
			Name = "Slicer Blade";
			Name2 = "Slicer Blade";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4738;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1500;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 35;
			SetDamage( 9 , 17 , Resistances.Armor );
			AgilityBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Venom Web Fang)
*
***************************************************************/

namespace Server.Items
{
	public class VenomWebFang : Item
	{
		public VenomWebFang() : base()
		{
			Id = 899;
			Bonding = 2;
			SellPrice = 1248;
			AvailableClasses = 0x7FFF;
			Model = 6459;
			ObjectClass = 2;
			SubClass = 15;
			Level = 19;
			ReqLevel = 14;
			Name = "Venom Web Fang";
			Name2 = "Venom Web Fang";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6241;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1500;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 40;
			SetSpell( 18077 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 10 , 19 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Giant Tarantula Fang)
*
***************************************************************/

namespace Server.Items
{
	public class GiantTarantulaFang : Item
	{
		public GiantTarantulaFang() : base()
		{
			Id = 1287;
			Bonding = 2;
			SellPrice = 703;
			AvailableClasses = 0x7FFF;
			Model = 6447;
			ObjectClass = 2;
			SubClass = 15;
			Level = 15;
			ReqLevel = 10;
			Name = "Giant Tarantula Fang";
			Name2 = "Giant Tarantula Fang";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3518;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1400;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 35;
			SetDamage( 7 , 14 , Resistances.Armor );
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Tigerbane)
*
***************************************************************/

namespace Server.Items
{
	public class Tigerbane : Item
	{
		public Tigerbane() : base()
		{
			Id = 1465;
			Bonding = 2;
			SellPrice = 9824;
			AvailableClasses = 0x7FFF;
			Model = 20594;
			ObjectClass = 2;
			SubClass = 15;
			Level = 38;
			ReqLevel = 33;
			Name = "Tigerbane";
			Name2 = "Tigerbane";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 49124;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1900;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 55;
			SetSpell( 19691 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 27 , 51 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Jeweled Dagger)
*
***************************************************************/

namespace Server.Items
{
	public class JeweledDagger : Item
	{
		public JeweledDagger() : base()
		{
			Id = 1917;
			Bonding = 2;
			SellPrice = 251;
			AvailableClasses = 0x7FFF;
			Model = 20435;
			ObjectClass = 2;
			SubClass = 15;
			Level = 10;
			ReqLevel = 5;
			Name = "Jeweled Dagger";
			Name2 = "Jeweled Dagger";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1256;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1600;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 25;
			SetDamage( 6 , 11 , Resistances.Armor );
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Assassin's Blade)
*
***************************************************************/

namespace Server.Items
{
	public class AssassinsBlade : Item
	{
		public AssassinsBlade() : base()
		{
			Id = 1935;
			Bonding = 2;
			SellPrice = 2974;
			AvailableClasses = 0x7FFF;
			Model = 20471;
			ObjectClass = 2;
			SubClass = 15;
			Level = 24;
			ReqLevel = 19;
			Name = "Assassin's Blade";
			Name2 = "Assassin's Blade";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 14874;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1900;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 50;
			SetDamage( 20 , 39 , Resistances.Armor );
			AgilityBonus = 4;
			StrBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Goblin Screwdriver)
*
***************************************************************/

namespace Server.Items
{
	public class GoblinScrewdriver : Item
	{
		public GoblinScrewdriver() : base()
		{
			Id = 1936;
			Bonding = 2;
			SellPrice = 1113;
			AvailableClasses = 0x7FFF;
			Model = 20399;
			ObjectClass = 2;
			SubClass = 15;
			Level = 18;
			ReqLevel = 13;
			Name = "Goblin Screwdriver";
			Name2 = "Goblin Screwdriver";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5569;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1400;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 40;
			SetDamage( 8 , 17 , Resistances.Armor );
			AgilityBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Hollowfang Blade)
*
***************************************************************/

namespace Server.Items
{
	public class HollowfangBlade : Item
	{
		public HollowfangBlade() : base()
		{
			Id = 2020;
			Bonding = 2;
			SellPrice = 1049;
			AvailableClasses = 0x7FFF;
			Model = 20492;
			ObjectClass = 2;
			SubClass = 15;
			Level = 18;
			ReqLevel = 13;
			Name = "Hollowfang Blade";
			Name2 = "Hollowfang Blade";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5249;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1400;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 40;
			SetDamage( 8 , 17 , Resistances.Armor );
			StrBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Long Crawler Limb)
*
***************************************************************/

namespace Server.Items
{
	public class LongCrawlerLimb : Item
	{
		public LongCrawlerLimb() : base()
		{
			Id = 2088;
			Bonding = 2;
			SellPrice = 729;
			AvailableClasses = 0x7FFF;
			Model = 6455;
			ObjectClass = 2;
			SubClass = 15;
			Level = 15;
			ReqLevel = 10;
			Name = "Long Crawler Limb";
			Name2 = "Long Crawler Limb";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3648;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1600;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 35;
			SetDamage( 8 , 16 , Resistances.Armor );
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Scrimshaw Dagger)
*
***************************************************************/

namespace Server.Items
{
	public class ScrimshawDagger : Item
	{
		public ScrimshawDagger() : base()
		{
			Id = 2089;
			Bonding = 1;
			SellPrice = 1113;
			AvailableClasses = 0x7FFF;
			Model = 20407;
			ObjectClass = 2;
			SubClass = 15;
			Level = 18;
			Name = "Scrimshaw Dagger";
			Name2 = "Scrimshaw Dagger";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5567;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1800;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 40;
			SetDamage( 11 , 21 , Resistances.Armor );
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Worn Dagger)
*
***************************************************************/

namespace Server.Items
{
	public class WornDagger : Item
	{
		public WornDagger() : base()
		{
			Id = 2092;
			SellPrice = 7;
			AvailableClasses = 0x7FFF;
			Model = 6442;
			ObjectClass = 2;
			SubClass = 15;
			Level = 2;
			ReqLevel = 1;
			Name = "Worn Dagger";
			Name2 = "Worn Dagger";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 35;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1600;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 16;
			SetDamage( 1 , 2 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Whittling Knife)
*
***************************************************************/

namespace Server.Items
{
	public class WhittlingKnife : Item
	{
		public WhittlingKnife() : base()
		{
			Id = 2137;
			Bonding = 1;
			SellPrice = 24;
			AvailableClasses = 0x7FFF;
			Model = 6437;
			ObjectClass = 2;
			SubClass = 15;
			Level = 5;
			Name = "Whittling Knife";
			Name2 = "Whittling Knife";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 124;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1500;
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
*				(Sharpened Letter Opener)
*
***************************************************************/

namespace Server.Items
{
	public class SharpenedLetterOpener : Item
	{
		public SharpenedLetterOpener() : base()
		{
			Id = 2138;
			SellPrice = 38;
			AvailableClasses = 0x7FFF;
			Model = 6460;
			ObjectClass = 2;
			SubClass = 15;
			Level = 7;
			ReqLevel = 2;
			Name = "Sharpened Letter Opener";
			Name2 = "Sharpened Letter Opener";
			AvailableRaces = 0x1FF;
			BuyPrice = 192;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1700;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 25;
			SetDamage( 2 , 5 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Dirk)
*
***************************************************************/

namespace Server.Items
{
	public class Dirk : Item
	{
		public Dirk() : base()
		{
			Id = 2139;
			SellPrice = 11;
			AvailableClasses = 0x7FFF;
			Model = 22135;
			ObjectClass = 2;
			SubClass = 15;
			Level = 3;
			ReqLevel = 1;
			Name = "Dirk";
			Name2 = "Dirk";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 57;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1600;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 18;
			SetDamage( 1 , 3 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Carving Knife)
*
***************************************************************/

namespace Server.Items
{
	public class CarvingKnife : Item
	{
		public CarvingKnife() : base()
		{
			Id = 2140;
			Bonding = 2;
			SellPrice = 323;
			AvailableClasses = 0x7FFF;
			Model = 6440;
			ObjectClass = 2;
			SubClass = 15;
			Level = 11;
			ReqLevel = 6;
			Name = "Carving Knife";
			Name2 = "Carving Knife";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5171;
			BuyPrice = 1616;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1600;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 30;
			SetDamage( 6 , 13 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Shadowblade)
*
***************************************************************/

namespace Server.Items
{
	public class Shadowblade : Item
	{
		public Shadowblade() : base()
		{
			Id = 2163;
			Bonding = 2;
			SellPrice = 46710;
			AvailableClasses = 0x7FFF;
			Model = 20291;
			ObjectClass = 2;
			SubClass = 15;
			Level = 53;
			ReqLevel = 48;
			Name = "Shadowblade";
			Name2 = "Shadowblade";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 233550;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1400;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetSpell( 18138 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 38 , 71 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Gut Ripper)
*
***************************************************************/

namespace Server.Items
{
	public class GutRipper : Item
	{
		public GutRipper() : base()
		{
			Id = 2164;
			Bonding = 2;
			SellPrice = 27031;
			AvailableClasses = 0x7FFF;
			Model = 20312;
			ObjectClass = 2;
			SubClass = 15;
			Level = 45;
			ReqLevel = 40;
			Name = "Gut Ripper";
			Name2 = "Gut Ripper";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 135159;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1800;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetSpell( 18107 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 42 , 80 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Buzzer Blade)
*
***************************************************************/

namespace Server.Items
{
	public class BuzzerBlade : Item
	{
		public BuzzerBlade() : base()
		{
			Id = 2169;
			SellPrice = 943;
			AvailableClasses = 0x7FFF;
			Model = 20347;
			ObjectClass = 2;
			SubClass = 15;
			Level = 21;
			ReqLevel = 16;
			Name = "Buzzer Blade";
			Name2 = "Buzzer Blade";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 4717;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1500;
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
*				(Anvilmar Knife)
*
***************************************************************/

namespace Server.Items
{
	public class AnvilmarKnife : Item
	{
		public AnvilmarKnife() : base()
		{
			Id = 2195;
			Bonding = 1;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 6432;
			ObjectClass = 2;
			SubClass = 15;
			Level = 5;
			Name = "Anvilmar Knife";
			Name2 = "Anvilmar Knife";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 127;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1600;
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
*				(Jambiya)
*
***************************************************************/

namespace Server.Items
{
	public class Jambiya : Item
	{
		public Jambiya() : base()
		{
			Id = 2207;
			SellPrice = 478;
			AvailableClasses = 0x7FFF;
			Model = 22137;
			ObjectClass = 2;
			SubClass = 15;
			Level = 16;
			ReqLevel = 11;
			Name = "Jambiya";
			Name2 = "Jambiya";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2390;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1400;
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
*				(Poniard)
*
***************************************************************/

namespace Server.Items
{
	public class Poniard : Item
	{
		public Poniard() : base()
		{
			Id = 2208;
			SellPrice = 730;
			AvailableClasses = 0x7FFF;
			Model = 22142;
			ObjectClass = 2;
			SubClass = 15;
			Level = 19;
			ReqLevel = 14;
			Name = "Poniard";
			Name2 = "Poniard";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 3650;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1300;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 40;
			SetDamage( 7 , 15 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Kris)
*
***************************************************************/

namespace Server.Items
{
	public class Kris : Item
	{
		public Kris() : base()
		{
			Id = 2209;
			SellPrice = 1423;
			AvailableClasses = 0x7FFF;
			Model = 22139;
			ObjectClass = 2;
			SubClass = 15;
			Level = 24;
			ReqLevel = 19;
			Name = "Kris";
			Name2 = "Kris";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 7115;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1600;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 45;
			SetDamage( 12 , 23 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Craftsman's Dagger)
*
***************************************************************/

namespace Server.Items
{
	public class CraftsmansDagger : Item
	{
		public CraftsmansDagger() : base()
		{
			Id = 2218;
			Bonding = 1;
			SellPrice = 501;
			AvailableClasses = 0x7FFF;
			Model = 20451;
			ObjectClass = 2;
			SubClass = 15;
			Level = 13;
			Name = "Craftsman's Dagger";
			Name2 = "Craftsman's Dagger";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2505;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1700;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 30;
			SetDamage( 8 , 15 , Resistances.Armor );
			AgilityBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Militia Dagger)
*
***************************************************************/

namespace Server.Items
{
	public class MilitiaDagger : Item
	{
		public MilitiaDagger() : base()
		{
			Id = 2224;
			Bonding = 1;
			SellPrice = 24;
			AvailableClasses = 0x7FFF;
			Model = 6432;
			ObjectClass = 2;
			SubClass = 15;
			Level = 5;
			Name = "Militia Dagger";
			Name2 = "Militia Dagger";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 122;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1500;
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
*				(Sharp Kitchen Knife)
*
***************************************************************/

namespace Server.Items
{
	public class SharpKitchenKnife : Item
	{
		public SharpKitchenKnife() : base()
		{
			Id = 2225;
			Bonding = 1;
			SellPrice = 183;
			AvailableClasses = 0x7FFF;
			Model = 20470;
			ObjectClass = 2;
			SubClass = 15;
			Level = 11;
			Name = "Sharp Kitchen Knife";
			Name2 = "Sharp Kitchen Knife";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 916;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1500;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 30;
			SetDamage( 5 , 10 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Brackclaw)
*
***************************************************************/

namespace Server.Items
{
	public class Brackclaw : Item
	{
		public Brackclaw() : base()
		{
			Id = 2235;
			Bonding = 2;
			SellPrice = 1281;
			AvailableClasses = 0x7FFF;
			Model = 20598;
			ObjectClass = 2;
			SubClass = 15;
			Level = 19;
			ReqLevel = 14;
			Name = "Brackclaw";
			Name2 = "Brackclaw";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6406;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1400;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 40;
			SetDamage( 9 , 18 , Resistances.Armor );
			StrBonus = 1;
			AgilityBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Blackfang)
*
***************************************************************/

namespace Server.Items
{
	public class Blackfang : Item
	{
		public Blackfang() : base()
		{
			Id = 2236;
			Bonding = 2;
			SellPrice = 3386;
			AvailableClasses = 0x7FFF;
			Model = 20345;
			ObjectClass = 2;
			SubClass = 15;
			Level = 25;
			ReqLevel = 20;
			Name = "Blackfang";
			Name2 = "Blackfang";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 16931;
			Resistance[5] = 5;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1500;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 3;
			Durability = 50;
			SetDamage( 17 , 32 , Resistances.Armor );
			IqBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Stonesplinter Dagger)
*
***************************************************************/

namespace Server.Items
{
	public class StonesplinterDagger : Item
	{
		public StonesplinterDagger() : base()
		{
			Id = 2266;
			Bonding = 2;
			SellPrice = 479;
			AvailableClasses = 0x7FFF;
			Model = 20427;
			ObjectClass = 2;
			SubClass = 15;
			Level = 13;
			ReqLevel = 8;
			Name = "Stonesplinter Dagger";
			Name2 = "Stonesplinter Dagger";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2396;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1500;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 30;
			SetDamage( 7 , 14 , Resistances.Armor );
			AgilityBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Small Knife)
*
***************************************************************/

namespace Server.Items
{
	public class SmallKnife : Item
	{
		public SmallKnife() : base()
		{
			Id = 2484;
			SellPrice = 17;
			AvailableClasses = 0x7FFF;
			Model = 6442;
			ObjectClass = 2;
			SubClass = 15;
			Level = 4;
			ReqLevel = 1;
			Name = "Small Knife";
			Name2 = "Small Knife";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 87;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1400;
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
*				(Stiletto)
*
***************************************************************/

namespace Server.Items
{
	public class Stiletto : Item
	{
		public Stiletto() : base()
		{
			Id = 2494;
			SellPrice = 80;
			AvailableClasses = 0x7FFF;
			Model = 22136;
			ObjectClass = 2;
			SubClass = 15;
			Level = 8;
			ReqLevel = 3;
			Name = "Stiletto";
			Name2 = "Stiletto";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 401;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1500;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 25;
			SetDamage( 3 , 7 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Scuffed Dagger)
*
***************************************************************/

namespace Server.Items
{
	public class ScuffedDagger : Item
	{
		public ScuffedDagger() : base()
		{
			Id = 2502;
			SellPrice = 59;
			AvailableClasses = 0x7FFF;
			Model = 6444;
			ObjectClass = 2;
			SubClass = 15;
			Level = 7;
			ReqLevel = 2;
			Name = "Scuffed Dagger";
			Name2 = "Scuffed Dagger";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 295;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1500;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Flags = 16;
			SetDamage( 3 , 6 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Main Gauche)
*
***************************************************************/

namespace Server.Items
{
	public class MainGauche : Item
	{
		public MainGauche() : base()
		{
			Id = 2526;
			SellPrice = 3867;
			AvailableClasses = 0x7FFF;
			Model = 22141;
			ObjectClass = 2;
			SubClass = 15;
			Level = 34;
			ReqLevel = 29;
			Name = "Main Gauche";
			Name2 = "Main Gauche";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 19336;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1600;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 55;
			SetDamage( 18 , 35 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Rondel)
*
***************************************************************/

namespace Server.Items
{
	public class Rondel : Item
	{
		public Rondel() : base()
		{
			Id = 2534;
			SellPrice = 9086;
			AvailableClasses = 0x7FFF;
			Model = 22140;
			ObjectClass = 2;
			SubClass = 15;
			Level = 44;
			ReqLevel = 39;
			Name = "Rondel";
			Name2 = "Rondel";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 45431;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1600;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 55;
			SetDamage( 27 , 50 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Evocator's Blade)
*
***************************************************************/

namespace Server.Items
{
	public class EvocatorsBlade : Item
	{
		public EvocatorsBlade() : base()
		{
			Id = 2567;
			Bonding = 2;
			SellPrice = 2509;
			AvailableClasses = 0x7FFF;
			Model = 20590;
			ObjectClass = 2;
			SubClass = 15;
			Level = 23;
			ReqLevel = 18;
			Name = "Evocator's Blade";
			Name2 = "Evocator's Blade";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 12546;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1600;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 3;
			Durability = 50;
			SetDamage( 17 , 32 , Resistances.Armor );
			SpiritBonus = 4;
			IqBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Curved Dagger)
*
***************************************************************/

namespace Server.Items
{
	public class CurvedDagger : Item
	{
		public CurvedDagger() : base()
		{
			Id = 2632;
			Bonding = 2;
			SellPrice = 605;
			AvailableClasses = 0x7FFF;
			Model = 20473;
			ObjectClass = 2;
			SubClass = 15;
			Level = 14;
			ReqLevel = 9;
			Name = "Curved Dagger";
			Name2 = "Curved Dagger";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5171;
			BuyPrice = 3029;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1600;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 35;
			SetDamage( 8 , 15 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Fisherman Knife)
*
***************************************************************/

namespace Server.Items
{
	public class FishermanKnife : Item
	{
		public FishermanKnife() : base()
		{
			Id = 2763;
			SellPrice = 240;
			AvailableClasses = 0x7FFF;
			Model = 6437;
			ObjectClass = 2;
			SubClass = 15;
			Level = 14;
			ReqLevel = 9;
			Name = "Fisherman Knife";
			Name2 = "Fisherman Knife";
			AvailableRaces = 0x1FF;
			BuyPrice = 1203;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1400;
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
*				(Small Dagger)
*
***************************************************************/

namespace Server.Items
{
	public class SmallDagger : Item
	{
		public SmallDagger() : base()
		{
			Id = 2764;
			SellPrice = 440;
			AvailableClasses = 0x7FFF;
			Model = 6444;
			ObjectClass = 2;
			SubClass = 15;
			Level = 18;
			ReqLevel = 13;
			Name = "Small Dagger";
			Name2 = "Small Dagger";
			AvailableRaces = 0x1FF;
			BuyPrice = 2202;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1400;
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
*				(Hunting Knife)
*
***************************************************************/

namespace Server.Items
{
	public class HuntingKnife : Item
	{
		public HuntingKnife() : base()
		{
			Id = 2765;
			SellPrice = 811;
			AvailableClasses = 0x7FFF;
			Model = 20383;
			ObjectClass = 2;
			SubClass = 15;
			Level = 23;
			ReqLevel = 18;
			Name = "Hunting Knife";
			Name2 = "Hunting Knife";
			AvailableRaces = 0x1FF;
			BuyPrice = 4057;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1700;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 45;
			SetDamage( 8 , 16 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Deft Stiletto)
*
***************************************************************/

namespace Server.Items
{
	public class DeftStiletto : Item
	{
		public DeftStiletto() : base()
		{
			Id = 2766;
			SellPrice = 1564;
			AvailableClasses = 0x7FFF;
			Model = 6445;
			ObjectClass = 2;
			SubClass = 15;
			Level = 29;
			ReqLevel = 24;
			Name = "Deft Stiletto";
			Name2 = "Deft Stiletto";
			AvailableRaces = 0x1FF;
			BuyPrice = 7823;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1400;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 55;
			SetDamage( 8 , 17 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Trogg Dagger)
*
***************************************************************/

namespace Server.Items
{
	public class TroggDagger : Item
	{
		public TroggDagger() : base()
		{
			Id = 2787;
			SellPrice = 10;
			AvailableClasses = 0x7FFF;
			Model = 20534;
			ObjectClass = 2;
			SubClass = 15;
			Level = 3;
			ReqLevel = 1;
			Name = "Trogg Dagger";
			Name2 = "Trogg Dagger";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 53;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1500;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 18;
			SetDamage( 1 , 2 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Cross Dagger)
*
***************************************************************/

namespace Server.Items
{
	public class CrossDagger : Item
	{
		public CrossDagger() : base()
		{
			Id = 2819;
			Bonding = 2;
			SellPrice = 3830;
			AvailableClasses = 0x7FFF;
			Model = 6443;
			ObjectClass = 2;
			SubClass = 15;
			Level = 28;
			ReqLevel = 23;
			Name = "Cross Dagger";
			Name2 = "Cross Dagger";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5216;
			BuyPrice = 19152;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1300;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 50;
			SetDamage( 13 , 25 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Thornblade)
*
***************************************************************/

namespace Server.Items
{
	public class Thornblade : Item
	{
		public Thornblade() : base()
		{
			Id = 2908;
			Bonding = 1;
			SellPrice = 1409;
			AvailableClasses = 0x7FFF;
			Model = 20605;
			ObjectClass = 2;
			SubClass = 15;
			Level = 20;
			Name = "Thornblade";
			Name2 = "Thornblade";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7048;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1600;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 40;
			SetDamage( 11 , 21 , Resistances.Armor );
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Claw of the Shadowmancer)
*
***************************************************************/

namespace Server.Items
{
	public class ClawOfTheShadowmancer : Item
	{
		public ClawOfTheShadowmancer() : base()
		{
			Id = 2912;
			Bonding = 2;
			SellPrice = 6731;
			AvailableClasses = 0x7FFF;
			Model = 20320;
			ObjectClass = 2;
			SubClass = 15;
			Level = 32;
			ReqLevel = 27;
			Name = "Claw of the Shadowmancer";
			Name2 = "Claw of the Shadowmancer";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 33656;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1900;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			SetSpell( 16409 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 27 , 51 , Resistances.Armor );
			SpiritBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Prison Shank)
*
***************************************************************/

namespace Server.Items
{
	public class PrisonShank : Item
	{
		public PrisonShank() : base()
		{
			Id = 2941;
			Bonding = 1;
			SellPrice = 3552;
			AvailableClasses = 0x7FFF;
			Model = 20359;
			ObjectClass = 2;
			SubClass = 15;
			Level = 26;
			ReqLevel = 21;
			Name = "Prison Shank";
			Name2 = "Prison Shank";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 17761;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1800;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 60;
			SetDamage( 21 , 39 , Resistances.Armor );
			AgilityBonus = 5;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Hook Dagger)
*
***************************************************************/

namespace Server.Items
{
	public class HookDagger : Item
	{
		public HookDagger() : base()
		{
			Id = 3184;
			Bonding = 2;
			SellPrice = 1394;
			AvailableClasses = 0x7FFF;
			Model = 20396;
			ObjectClass = 2;
			SubClass = 15;
			Level = 20;
			ReqLevel = 15;
			Name = "Hook Dagger";
			Name2 = "Hook Dagger";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5189;
			BuyPrice = 6973;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1500;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 40;
			SetDamage( 10 , 20 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Sacrificial Kris)
*
***************************************************************/

namespace Server.Items
{
	public class SacrificialKris : Item
	{
		public SacrificialKris() : base()
		{
			Id = 3187;
			Bonding = 2;
			SellPrice = 14870;
			AvailableClasses = 0x7FFF;
			Model = 20573;
			ObjectClass = 2;
			SubClass = 15;
			Level = 44;
			ReqLevel = 39;
			Name = "Sacrificial Kris";
			Name2 = "Sacrificial Kris";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5261;
			BuyPrice = 74353;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1400;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 55;
			SetDamage( 25 , 47 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Wicked Dagger)
*
***************************************************************/

namespace Server.Items
{
	public class WickedDagger : Item
	{
		public WickedDagger() : base()
		{
			Id = 3222;
			SellPrice = 1203;
			AvailableClasses = 0x7FFF;
			Model = 6439;
			ObjectClass = 2;
			SubClass = 15;
			Level = 19;
			ReqLevel = 14;
			Name = "Wicked Dagger";
			Name2 = "Wicked Dagger";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6015;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1600;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			SetDamage( 9 , 17 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Bloodstained Knife)
*
***************************************************************/

namespace Server.Items
{
	public class BloodstainedKnife : Item
	{
		public BloodstainedKnife() : base()
		{
			Id = 3225;
			SellPrice = 109;
			AvailableClasses = 0x7FFF;
			Model = 6437;
			ObjectClass = 2;
			SubClass = 15;
			Level = 9;
			ReqLevel = 4;
			Name = "Bloodstained Knife";
			Name2 = "Bloodstained Knife";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 548;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1600;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 25;
			SetDamage( 4 , 8 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Forsaken Dagger)
*
***************************************************************/

namespace Server.Items
{
	public class ForsakenDagger : Item
	{
		public ForsakenDagger() : base()
		{
			Id = 3268;
			Bonding = 1;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 6432;
			ObjectClass = 2;
			SubClass = 15;
			Level = 5;
			Name = "Forsaken Dagger";
			Name2 = "Forsaken Dagger";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 128;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1600;
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
*				(Deadman Dagger)
*
***************************************************************/

namespace Server.Items
{
	public class DeadmanDagger : Item
	{
		public DeadmanDagger() : base()
		{
			Id = 3296;
			SellPrice = 10;
			AvailableClasses = 0x7FFF;
			Model = 6442;
			ObjectClass = 2;
			SubClass = 15;
			Level = 3;
			ReqLevel = 1;
			Name = "Deadman Dagger";
			Name2 = "Deadman Dagger";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 54;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1400;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 18;
			SetDamage( 1 , 2 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Flesh Piercer)
*
***************************************************************/

namespace Server.Items
{
	public class FleshPiercer : Item
	{
		public FleshPiercer() : base()
		{
			Id = 3336;
			Bonding = 2;
			SellPrice = 3986;
			AvailableClasses = 0x7FFF;
			Model = 20341;
			ObjectClass = 2;
			SubClass = 15;
			Level = 29;
			ReqLevel = 24;
			Name = "Flesh Piercer";
			Name2 = "Flesh Piercer";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 19933;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2000;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 55;
			SetSpell( 18078 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 21 , 40 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Doomspike)
*
***************************************************************/

namespace Server.Items
{
	public class Doomspike : Item
	{
		public Doomspike() : base()
		{
			Id = 3413;
			Bonding = 2;
			SellPrice = 3229;
			AvailableClasses = 0x7FFF;
			Model = 20589;
			ObjectClass = 2;
			SubClass = 15;
			Level = 25;
			ReqLevel = 20;
			Name = "Doomspike";
			Name2 = "Doomspike";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 16147;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1500;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 50;
			SetDamage( 17 , 32 , Resistances.Armor );
			StrBonus = 3;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Ceremonial Knife)
*
***************************************************************/

namespace Server.Items
{
	public class CeremonialKnife : Item
	{
		public CeremonialKnife() : base()
		{
			Id = 3445;
			Bonding = 1;
			SellPrice = 226;
			AvailableClasses = 0x7FFF;
			Model = 20599;
			ObjectClass = 2;
			SubClass = 15;
			Level = 12;
			Name = "Ceremonial Knife";
			Name2 = "Ceremonial Knife";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1133;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1400;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 30;
			SetDamage( 5 , 10 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Deadly Bronze Poniard)
*
***************************************************************/

namespace Server.Items
{
	public class DeadlyBronzePoniard : Item
	{
		public DeadlyBronzePoniard() : base()
		{
			Id = 3490;
			Bonding = 2;
			SellPrice = 2731;
			AvailableClasses = 0x7FFF;
			Model = 6445;
			ObjectClass = 2;
			SubClass = 15;
			Level = 25;
			ReqLevel = 20;
			Name = "Deadly Bronze Poniard";
			Name2 = "Deadly Bronze Poniard";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 13658;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1800;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 45;
			SetDamage( 16 , 30 , Resistances.Armor );
			AgilityBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Serrated Knife)
*
***************************************************************/

namespace Server.Items
{
	public class SerratedKnife : Item
	{
		public SerratedKnife() : base()
		{
			Id = 3581;
			Bonding = 1;
			SellPrice = 1046;
			AvailableClasses = 0x7FFF;
			Model = 20414;
			ObjectClass = 2;
			SubClass = 15;
			Level = 18;
			Name = "Serrated Knife";
			Name2 = "Serrated Knife";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5230;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1600;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 40;
			SetDamage( 10 , 19 , Resistances.Armor );
			StaminaBonus = 1;
			AgilityBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Shiny Dirk)
*
***************************************************************/

namespace Server.Items
{
	public class ShinyDirk : Item
	{
		public ShinyDirk() : base()
		{
			Id = 3786;
			SellPrice = 3957;
			AvailableClasses = 0x7FFF;
			Model = 6468;
			ObjectClass = 2;
			SubClass = 15;
			Level = 39;
			ReqLevel = 34;
			Name = "Shiny Dirk";
			Name2 = "Shiny Dirk";
			AvailableRaces = 0x1FF;
			BuyPrice = 19785;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1600;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 55;
			SetDamage( 14 , 27 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Big Bronze Knife)
*
***************************************************************/

namespace Server.Items
{
	public class BigBronzeKnife : Item
	{
		public BigBronzeKnife() : base()
		{
			Id = 3848;
			Bonding = 2;
			SellPrice = 1426;
			AvailableClasses = 0x7FFF;
			Model = 6434;
			ObjectClass = 2;
			SubClass = 15;
			Level = 20;
			ReqLevel = 15;
			Name = "Big Bronze Knife";
			Name2 = "Big Bronze Knife";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7130;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1900;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 40;
			SetDamage( 13 , 25 , Resistances.Armor );
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Fine Pointed Dagger)
*
***************************************************************/

namespace Server.Items
{
	public class FinePointedDagger : Item
	{
		public FinePointedDagger() : base()
		{
			Id = 4023;
			SellPrice = 6215;
			AvailableClasses = 0x7FFF;
			Model = 4119;
			ObjectClass = 2;
			SubClass = 15;
			Level = 44;
			ReqLevel = 39;
			Name = "Fine Pointed Dagger";
			Name2 = "Fine Pointed Dagger";
			AvailableRaces = 0x1FF;
			BuyPrice = 31079;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1400;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 55;
			SetDamage( 15 , 28 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Dreadblade)
*
***************************************************************/

namespace Server.Items
{
	public class Dreadblade : Item
	{
		public Dreadblade() : base()
		{
			Id = 4088;
			Bonding = 2;
			SellPrice = 18523;
			AvailableClasses = 0x7FFF;
			Model = 28520;
			ObjectClass = 2;
			SubClass = 15;
			Level = 47;
			ReqLevel = 42;
			Name = "Dreadblade";
			Name2 = "Dreadblade";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5270;
			BuyPrice = 92615;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1500;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 55;
			SetDamage( 29 , 55 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Widowmaker)
*
***************************************************************/

namespace Server.Items
{
	public class Widowmaker : Item
	{
		public Widowmaker() : base()
		{
			Id = 4091;
			Bonding = 2;
			SellPrice = 22479;
			AvailableClasses = 0x7FFF;
			Model = 20380;
			ObjectClass = 2;
			SubClass = 15;
			Level = 47;
			ReqLevel = 42;
			Name = "Widowmaker";
			Name2 = "Widowmaker";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 112398;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1900;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			SetDamage( 42 , 78 , Resistances.Armor );
			AgilityBonus = 8;
			StrBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Small Green Dagger)
*
***************************************************************/

namespace Server.Items
{
	public class SmallGreenDagger : Item
	{
		public SmallGreenDagger() : base()
		{
			Id = 4302;
			SellPrice = 146;
			AvailableClasses = 0x7FFF;
			Model = 3006;
			ObjectClass = 2;
			SubClass = 15;
			Level = 10;
			ReqLevel = 5;
			Name = "Small Green Dagger";
			Name2 = "Small Green Dagger";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 732;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1500;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 25;
			SetDamage( 4 , 9 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Blackvenom Blade)
*
***************************************************************/

namespace Server.Items
{
	public class BlackvenomBlade : Item
	{
		public BlackvenomBlade() : base()
		{
			Id = 4446;
			Bonding = 2;
			SellPrice = 3594;
			AvailableClasses = 0x7FFF;
			Model = 20369;
			ObjectClass = 2;
			SubClass = 15;
			Level = 26;
			ReqLevel = 21;
			Name = "Blackvenom Blade";
			Name2 = "Blackvenom Blade";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 17972;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1800;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 60;
			SetSpell( 13518 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 21 , 39 , Resistances.Armor );
			SetDamage( 1 , 7 , Resistances.Shadow );
			AgilityBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Naraxis' Fang)
*
***************************************************************/

namespace Server.Items
{
	public class NaraxisFang : Item
	{
		public NaraxisFang() : base()
		{
			Id = 4449;
			Bonding = 2;
			SellPrice = 3332;
			AvailableClasses = 0x7FFF;
			Model = 20439;
			ObjectClass = 2;
			SubClass = 15;
			Level = 27;
			ReqLevel = 22;
			Name = "Naraxis' Fang";
			Name2 = "Naraxis' Fang";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 16662;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1600;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 50;
			SetSpell( 16400 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 15 , 29 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Talon of Vultros)
*
***************************************************************/

namespace Server.Items
{
	public class TalonOfVultros : Item
	{
		public TalonOfVultros() : base()
		{
			Id = 4454;
			Bonding = 2;
			SellPrice = 3800;
			AvailableClasses = 0x7FFF;
			Model = 20592;
			ObjectClass = 2;
			SubClass = 15;
			Level = 26;
			ReqLevel = 21;
			Name = "Talon of Vultros";
			Name2 = "Talon of Vultros";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 19001;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2000;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 3;
			Durability = 60;
			SetDamage( 23 , 44 , Resistances.Armor );
			AgilityBonus = 5;
			IqBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Simple Dagger)
*
***************************************************************/

namespace Server.Items
{
	public class SimpleDagger : Item
	{
		public SimpleDagger() : base()
		{
			Id = 4565;
			SellPrice = 38;
			AvailableClasses = 0x7FFF;
			Model = 6433;
			ObjectClass = 2;
			SubClass = 15;
			Level = 6;
			ReqLevel = 1;
			Name = "Simple Dagger";
			Name2 = "Simple Dagger";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 193;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1800;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 20;
			SetDamage( 3 , 6 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(War Knife)
*
***************************************************************/

namespace Server.Items
{
	public class WarKnife : Item
	{
		public WarKnife() : base()
		{
			Id = 4571;
			Bonding = 2;
			SellPrice = 979;
			AvailableClasses = 0x7FFF;
			Model = 20430;
			ObjectClass = 2;
			SubClass = 15;
			Level = 17;
			ReqLevel = 12;
			Name = "War Knife";
			Name2 = "War Knife";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5180;
			BuyPrice = 4896;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1700;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 35;
			SetDamage( 10 , 19 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Long Bayonet)
*
***************************************************************/

namespace Server.Items
{
	public class LongBayonet : Item
	{
		public LongBayonet() : base()
		{
			Id = 4840;
			Bonding = 1;
			SellPrice = 142;
			AvailableClasses = 0x7FFF;
			Model = 13908;
			ObjectClass = 2;
			SubClass = 15;
			Level = 10;
			Name = "Long Bayonet";
			Name2 = "Long Bayonet";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 713;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1700;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 25;
			SetDamage( 5 , 10 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Primitive Hand Blade)
*
***************************************************************/

namespace Server.Items
{
	public class PrimitiveHandBlade : Item
	{
		public PrimitiveHandBlade() : base()
		{
			Id = 4925;
			Bonding = 1;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 6457;
			ObjectClass = 2;
			SubClass = 15;
			Level = 5;
			Name = "Primitive Hand Blade";
			Name2 = "Primitive Hand Blade";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 129;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1700;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 20;
			SetDamage( 2 , 5 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Jagged Dagger)
*
***************************************************************/

namespace Server.Items
{
	public class JaggedDagger : Item
	{
		public JaggedDagger() : base()
		{
			Id = 4947;
			Bonding = 1;
			SellPrice = 325;
			AvailableClasses = 0x7FFF;
			Model = 20603;
			ObjectClass = 2;
			SubClass = 15;
			Level = 11;
			Name = "Jagged Dagger";
			Name2 = "Jagged Dagger";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1627;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1500;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 30;
			SetDamage( 6 , 12 , Resistances.Armor );
			StrBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Compact Fighting Knife)
*
***************************************************************/

namespace Server.Items
{
	public class CompactFightingKnife : Item
	{
		public CompactFightingKnife() : base()
		{
			Id = 4974;
			Bonding = 1;
			SellPrice = 388;
			AvailableClasses = 0x7FFF;
			Model = 3006;
			ObjectClass = 2;
			SubClass = 15;
			Level = 12;
			Name = "Compact Fighting Knife";
			Name2 = "Compact Fighting Knife";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1940;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1500;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 30;
			SetDamage( 6 , 13 , Resistances.Armor );
			AgilityBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Shadow Hunter Knife)
*
***************************************************************/

namespace Server.Items
{
	public class ShadowHunterKnife : Item
	{
		public ShadowHunterKnife() : base()
		{
			Id = 5040;
			Bonding = 4;
			AvailableClasses = 0x7FFF;
			Model = 20321;
			ObjectClass = 2;
			SubClass = 15;
			Level = 32;
			ReqLevel = 27;
			Name = "Shadow Hunter Knife";
			Name2 = "Shadow Hunter Knife";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1700;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 55;
			SetDamage( 18 , 35 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Razormane Backstabber)
*
***************************************************************/

namespace Server.Items
{
	public class RazormaneBackstabber : Item
	{
		public RazormaneBackstabber() : base()
		{
			Id = 5093;
			Bonding = 1;
			SellPrice = 247;
			AvailableClasses = 0x7FFF;
			Model = 20392;
			ObjectClass = 2;
			SubClass = 15;
			Level = 21;
			ReqLevel = 16;
			Name = "Razormane Backstabber";
			Name2 = "Razormane Backstabber";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1238;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1700;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 40;
			SetDamage( 11 , 21 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Ritual Blade)
*
***************************************************************/

namespace Server.Items
{
	public class RitualBlade : Item
	{
		public RitualBlade() : base()
		{
			Id = 5112;
			Bonding = 2;
			SellPrice = 730;
			AvailableClasses = 0x7FFF;
			Model = 20491;
			ObjectClass = 2;
			SubClass = 15;
			Level = 15;
			ReqLevel = 10;
			Name = "Ritual Blade";
			Name2 = "Ritual Blade";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3651;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1400;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 35;
			SetDamage( 7 , 14 , Resistances.Armor );
			AgilityBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Scarlet Kris)
*
***************************************************************/

namespace Server.Items
{
	public class ScarletKris : Item
	{
		public ScarletKris() : base()
		{
			Id = 5267;
			Bonding = 2;
			SellPrice = 59851;
			AvailableClasses = 0x7FFF;
			Model = 3363;
			ObjectClass = 2;
			SubClass = 15;
			Level = 63;
			ReqLevel = 58;
			Name = "Scarlet Kris";
			Name2 = "Scarlet Kris";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 299255;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1500;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			SetDamage( 43 , 81 , Resistances.Armor );
			AgilityBonus = 10;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Harpy Skinner)
*
***************************************************************/

namespace Server.Items
{
	public class HarpySkinner : Item
	{
		public HarpySkinner() : base()
		{
			Id = 5279;
			Bonding = 1;
			SellPrice = 1436;
			AvailableClasses = 0x7FFF;
			Model = 20411;
			ObjectClass = 2;
			SubClass = 15;
			Level = 20;
			Name = "Harpy Skinner";
			Name2 = "Harpy Skinner";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7184;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1400;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 40;
			SetDamage( 9 , 18 , Resistances.Armor );
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Thistlewood Dagger)
*
***************************************************************/

namespace Server.Items
{
	public class ThistlewoodDagger : Item
	{
		public ThistlewoodDagger() : base()
		{
			Id = 5392;
			Bonding = 1;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 6432;
			ObjectClass = 2;
			SubClass = 15;
			Level = 5;
			Name = "Thistlewood Dagger";
			Name2 = "Thistlewood Dagger";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 127;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1700;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 20;
			SetDamage( 2 , 5 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Threshadon Fang)
*
***************************************************************/

namespace Server.Items
{
	public class ThreshadonFang : Item
	{
		public ThreshadonFang() : base()
		{
			Id = 5516;
			SellPrice = 317;
			AvailableClasses = 0x7FFF;
			Model = 8028;
			ObjectClass = 2;
			SubClass = 15;
			Level = 16;
			ReqLevel = 11;
			Name = "Threshadon Fang";
			Name2 = "Threshadon Fang";
			AvailableRaces = 0x1FF;
			BuyPrice = 1589;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1500;
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
*				(Pearl-handled Dagger)
*
***************************************************************/

namespace Server.Items
{
	public class PearlHandledDagger : Item
	{
		public PearlHandledDagger() : base()
		{
			Id = 5540;
			Bonding = 2;
			SellPrice = 2107;
			AvailableClasses = 0x7FFF;
			Model = 6439;
			ObjectClass = 2;
			SubClass = 15;
			Level = 23;
			ReqLevel = 18;
			Name = "Pearl-handled Dagger";
			Name2 = "Pearl-handled Dagger";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 10539;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1700;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 45;
			SetDamage( 13 , 26 , Resistances.Armor );
			AgilityBonus = 2;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Pruning Knife)
*
***************************************************************/

namespace Server.Items
{
	public class PruningKnife : Item
	{
		public PruningKnife() : base()
		{
			Id = 5605;
			Bonding = 1;
			SellPrice = 150;
			AvailableClasses = 0x7FFF;
			Model = 3550;
			ObjectClass = 2;
			SubClass = 15;
			Level = 10;
			Name = "Pruning Knife";
			Name2 = "Pruning Knife";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 750;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1600;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 25;
			SetDamage( 4 , 9 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Gutwrencher)
*
***************************************************************/

namespace Server.Items
{
	public class Gutwrencher : Item
	{
		public Gutwrencher() : base()
		{
			Id = 5616;
			Bonding = 2;
			SellPrice = 22738;
			AvailableClasses = 0x7FFF;
			Model = 20376;
			ObjectClass = 2;
			SubClass = 15;
			Level = 47;
			ReqLevel = 42;
			Name = "Gutwrencher";
			Name2 = "Gutwrencher";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 113690;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1600;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			SetSpell( 16406 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 35 , 66 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Relic Blade)
*
***************************************************************/

namespace Server.Items
{
	public class RelicBlade : Item
	{
		public RelicBlade() : base()
		{
			Id = 5627;
			Bonding = 1;
			SellPrice = 1379;
			AvailableClasses = 0x7FFF;
			Model = 20354;
			ObjectClass = 2;
			SubClass = 15;
			Level = 20;
			Name = "Relic Blade";
			Name2 = "Relic Blade";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6896;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1800;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 40;
			SetDamage( 12 , 24 , Resistances.Armor );
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Wyvern Tailspike)
*
***************************************************************/

namespace Server.Items
{
	public class WyvernTailspike : Item
	{
		public WyvernTailspike() : base()
		{
			Id = 5752;
			Bonding = 2;
			SellPrice = 3109;
			AvailableClasses = 0x7FFF;
			Model = 20596;
			ObjectClass = 2;
			SubClass = 15;
			Level = 26;
			ReqLevel = 21;
			Name = "Wyvern Tailspike";
			Name2 = "Wyvern Tailspike";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 15548;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1800;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 50;
			SetSpell( 16400 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 17 , 32 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Sliverblade)
*
***************************************************************/

namespace Server.Items
{
	public class Sliverblade : Item
	{
		public Sliverblade() : base()
		{
			Id = 5756;
			Bonding = 2;
			SellPrice = 10026;
			AvailableClasses = 0x7FFF;
			Model = 20591;
			ObjectClass = 2;
			SubClass = 15;
			Level = 37;
			ReqLevel = 32;
			Name = "Sliverblade";
			Name2 = "Sliverblade";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 50134;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1400;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			SetSpell( 18398 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 24 , 46 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Meteor Shard)
*
***************************************************************/

namespace Server.Items
{
	public class MeteorShard : Item
	{
		public MeteorShard() : base()
		{
			Id = 6220;
			Bonding = 1;
			SellPrice = 4893;
			AvailableClasses = 0x7FFF;
			Model = 20536;
			ObjectClass = 2;
			SubClass = 15;
			Level = 29;
			ReqLevel = 24;
			Name = "Meteor Shard";
			Name2 = "Meteor Shard";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 24468;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1800;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			SetSpell( 13442 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 23 , 43 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Howling Blade)
*
***************************************************************/

namespace Server.Items
{
	public class HowlingBlade : Item
	{
		public HowlingBlade() : base()
		{
			Id = 6331;
			Bonding = 2;
			SellPrice = 9466;
			AvailableClasses = 0x7FFF;
			Model = 20333;
			ObjectClass = 2;
			SubClass = 15;
			Level = 36;
			ReqLevel = 31;
			Name = "Howling Blade";
			Name2 = "Howling Blade";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 47333;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1400;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			SetSpell( 13490 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 23 , 44 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Spikelash Dagger)
*
***************************************************************/

namespace Server.Items
{
	public class SpikelashDagger : Item
	{
		public SpikelashDagger() : base()
		{
			Id = 6333;
			Bonding = 2;
			SellPrice = 1929;
			AvailableClasses = 0x7FFF;
			Model = 20604;
			ObjectClass = 2;
			SubClass = 15;
			Level = 22;
			ReqLevel = 17;
			Name = "Spikelash Dagger";
			Name2 = "Spikelash Dagger";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 9645;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1900;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 45;
			SetDamage( 14 , 28 , Resistances.Armor );
			AgilityBonus = 2;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Tail Spike)
*
***************************************************************/

namespace Server.Items
{
	public class TailSpike : Item
	{
		public TailSpike() : base()
		{
			Id = 6448;
			Bonding = 1;
			SellPrice = 1942;
			AvailableClasses = 0x7FFF;
			Model = 20349;
			ObjectClass = 2;
			SubClass = 15;
			Level = 22;
			ReqLevel = 17;
			Name = "Tail Spike";
			Name2 = "Tail Spike";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 9714;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1800;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 45;
			SetDamage( 14 , 26 , Resistances.Armor );
			AgilityBonus = 2;
			StrBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Julie's Dagger)
*
***************************************************************/

namespace Server.Items
{
	public class JuliesDagger : Item
	{
		public JuliesDagger() : base()
		{
			Id = 6660;
			Bonding = 2;
			SellPrice = 36157;
			AvailableClasses = 0x7FFF;
			Model = 13001;
			ObjectClass = 2;
			SubClass = 15;
			Level = 55;
			ReqLevel = 50;
			Name = "Julie's Dagger";
			Name2 = "Julie's Dagger";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 180788;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1300;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			SetSpell( 8348 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 33 , 62 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Thornspike)
*
***************************************************************/

namespace Server.Items
{
	public class Thornspike : Item
	{
		public Thornspike() : base()
		{
			Id = 6681;
			SellPrice = 3124;
			AvailableClasses = 0x7FFF;
			Model = 20593;
			ObjectClass = 2;
			SubClass = 15;
			Level = 32;
			ReqLevel = 27;
			Name = "Thornspike";
			Name2 = "Thornspike";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 15622;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1700;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 55;
			SetDamage( 18 , 35 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Swinetusk Shank)
*
***************************************************************/

namespace Server.Items
{
	public class SwinetuskShank : Item
	{
		public SwinetuskShank() : base()
		{
			Id = 6691;
			Bonding = 1;
			SellPrice = 8866;
			AvailableClasses = 0x7FFF;
			Model = 12880;
			ObjectClass = 2;
			SubClass = 15;
			Level = 35;
			ReqLevel = 30;
			Name = "Swinetusk Shank";
			Name2 = "Swinetusk Shank";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 44332;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1500;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			SetDamage( 24 , 45 , Resistances.Armor );
			StaminaBonus = 6;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Black Menace)
*
***************************************************************/

namespace Server.Items
{
	public class BlackMenace : Item
	{
		public BlackMenace() : base()
		{
			Id = 6831;
			Bonding = 1;
			SellPrice = 17522;
			AvailableClasses = 0x7FFF;
			Model = 20292;
			ObjectClass = 2;
			SubClass = 15;
			Level = 44;
			Name = "Black Menace";
			Name2 = "Black Menace";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 87613;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1500;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			SetSpell( 13440 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 31 , 58 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Bite of Serra'kis)
*
***************************************************************/

namespace Server.Items
{
	public class BiteOfSerrakis : Item
	{
		public BiteOfSerrakis() : base()
		{
			Id = 6904;
			Bonding = 1;
			SellPrice = 4665;
			AvailableClasses = 0x7FFF;
			Model = 20575;
			ObjectClass = 2;
			SubClass = 15;
			Level = 28;
			ReqLevel = 23;
			Name = "Bite of Serra'kis";
			Name2 = "Bite of Serra'kis";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 23326;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1300;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 60;
			SetSpell( 8313 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 16 , 30 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Elunite Dagger)
*
***************************************************************/

namespace Server.Items
{
	public class EluniteDagger : Item
	{
		public EluniteDagger() : base()
		{
			Id = 6969;
			Bonding = 1;
			SellPrice = 701;
			AvailableClasses = 0x01;
			Model = 20400;
			ObjectClass = 2;
			SubClass = 15;
			Level = 15;
			Name = "Elunite Dagger";
			Name2 = "Elunite Dagger";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3506;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1700;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 35;
			SetDamage( 9 , 17 , Resistances.Armor );
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Haggard's Dagger)
*
***************************************************************/

namespace Server.Items
{
	public class HaggardsDagger : Item
	{
		public HaggardsDagger() : base()
		{
			Id = 6980;
			Bonding = 1;
			SellPrice = 677;
			AvailableClasses = 0x01;
			Model = 20601;
			ObjectClass = 2;
			SubClass = 15;
			Level = 15;
			Name = "Haggard's Dagger";
			Name2 = "Haggard's Dagger";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3389;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1700;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 35;
			SetDamage( 9 , 17 , Resistances.Armor );
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Umbral Dagger)
*
***************************************************************/

namespace Server.Items
{
	public class UmbralDagger : Item
	{
		public UmbralDagger() : base()
		{
			Id = 6981;
			Bonding = 1;
			SellPrice = 680;
			AvailableClasses = 0x01;
			Model = 20606;
			ObjectClass = 2;
			SubClass = 15;
			Level = 15;
			Name = "Umbral Dagger";
			Name2 = "Umbral Dagger";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3402;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1700;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 35;
			SetDamage( 9 , 17 , Resistances.Armor );
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Heirloom Dagger)
*
***************************************************************/

namespace Server.Items
{
	public class HeirloomDagger : Item
	{
		public HeirloomDagger() : base()
		{
			Id = 7116;
			Bonding = 1;
			SellPrice = 685;
			AvailableClasses = 0x01;
			Model = 20602;
			ObjectClass = 2;
			SubClass = 15;
			Level = 15;
			Name = "Heirloom Dagger";
			Name2 = "Heirloom Dagger";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3428;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1700;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 35;
			SetDamage( 9 , 17 , Resistances.Armor );
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Copper Dagger)
*
***************************************************************/

namespace Server.Items
{
	public class CopperDagger : Item
	{
		public CopperDagger() : base()
		{
			Id = 7166;
			SellPrice = 194;
			AvailableClasses = 0x7FFF;
			Model = 13848;
			ObjectClass = 2;
			SubClass = 15;
			Level = 11;
			ReqLevel = 6;
			Name = "Copper Dagger";
			Name2 = "Copper Dagger";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 973;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1500;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 30;
			SetDamage( 5 , 10 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Blade of Cunning)
*
***************************************************************/

namespace Server.Items
{
	public class BladeOfCunning : Item
	{
		public BladeOfCunning() : base()
		{
			Id = 7298;
			Bonding = 1;
			SellPrice = 468;
			AvailableClasses = 0x08;
			Model = 20425;
			ObjectClass = 2;
			SubClass = 15;
			Level = 13;
			Name = "Blade of Cunning";
			Name2 = "Blade of Cunning";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2344;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2000;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 3;
			Durability = 30;
			SetDamage( 9 , 18 , Resistances.Armor );
			AgilityBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Thun'grim's Dagger)
*
***************************************************************/

namespace Server.Items
{
	public class ThungrimsDagger : Item
	{
		public ThungrimsDagger() : base()
		{
			Id = 7327;
			Bonding = 1;
			SellPrice = 698;
			AvailableClasses = 0x01;
			Model = 20398;
			ObjectClass = 2;
			SubClass = 15;
			Level = 15;
			Name = "Thun'grim's Dagger";
			Name2 = "Thun'grim's Dagger";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3493;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1700;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 35;
			SetDamage( 9 , 17 , Resistances.Armor );
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Torturing Poker)
*
***************************************************************/

namespace Server.Items
{
	public class TorturingPoker : Item
	{
		public TorturingPoker() : base()
		{
			Id = 7682;
			Bonding = 1;
			SellPrice = 7678;
			AvailableClasses = 0x7FFF;
			Model = 6555;
			ObjectClass = 2;
			SubClass = 15;
			Level = 34;
			ReqLevel = 29;
			Name = "Torturing Poker";
			Name2 = "Torturing Poker";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 38392;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1700;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			SetDamage( 21 , 39 , Resistances.Armor );
			SetDamage( 5 , 7 , Resistances.Fire );
		}
	}
}


/**************************************************************
*
*				(Hypnotic Blade)
*
***************************************************************/

namespace Server.Items
{
	public class HypnoticBlade : Item
	{
		public HypnoticBlade() : base()
		{
			Id = 7714;
			Bonding = 1;
			SellPrice = 3834;
			AvailableClasses = 0x7FFF;
			Model = 20318;
			ObjectClass = 2;
			SubClass = 15;
			Level = 39;
			ReqLevel = 34;
			Name = "Hypnotic Blade";
			Name2 = "Hypnotic Blade";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 19174;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1400;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			SetDamage( 26 , 49 , Resistances.Armor );
			SpiritBonus = 8;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Ebon Shiv)
*
***************************************************************/

namespace Server.Items
{
	public class EbonShiv : Item
	{
		public EbonShiv() : base()
		{
			Id = 7947;
			Bonding = 2;
			SellPrice = 24892;
			AvailableClasses = 0x7FFF;
			Model = 16130;
			ObjectClass = 2;
			SubClass = 15;
			Level = 51;
			ReqLevel = 46;
			Name = "Ebon Shiv";
			Name2 = "Ebon Shiv";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 124460;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1500;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 55;
			SetDamage( 32 , 59 , Resistances.Armor );
			AgilityBonus = 9;
		}
	}
}


/**************************************************************
*
*				(The Ziggler)
*
***************************************************************/

namespace Server.Items
{
	public class TheZiggler : Item
	{
		public TheZiggler() : base()
		{
			Id = 8006;
			Bonding = 2;
			SellPrice = 12472;
			AvailableClasses = 0x7FFF;
			Model = 20326;
			ObjectClass = 2;
			SubClass = 15;
			Level = 39;
			ReqLevel = 34;
			Name = "The Ziggler";
			Name2 = "The Ziggler";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 62360;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1700;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			SetSpell( 13482 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 31 , 59 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Stonevault Shiv)
*
***************************************************************/

namespace Server.Items
{
	public class StonevaultShiv : Item
	{
		public StonevaultShiv() : base()
		{
			Id = 9384;
			Bonding = 2;
			SellPrice = 9789;
			AvailableClasses = 0x7FFF;
			Model = 18264;
			ObjectClass = 2;
			SubClass = 15;
			Level = 36;
			ReqLevel = 31;
			Name = "Stonevault Shiv";
			Name2 = "Stonevault Shiv";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 48947;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1500;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			SetDamage( 25 , 47 , Resistances.Armor );
			AgilityBonus = 7;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Toxic Revenger)
*
***************************************************************/

namespace Server.Items
{
	public class ToxicRevenger : Item
	{
		public ToxicRevenger() : base()
		{
			Id = 9453;
			Bonding = 1;
			SellPrice = 6592;
			AvailableClasses = 0x7FFF;
			Model = 20595;
			ObjectClass = 2;
			SubClass = 15;
			Level = 32;
			ReqLevel = 27;
			Name = "Toxic Revenger";
			Name2 = "Toxic Revenger";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 32961;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1900;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			SetSpell( 11790 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 27 , 51 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Gahz'rilla Fang)
*
***************************************************************/

namespace Server.Items
{
	public class GahzrillaFang : Item
	{
		public GahzrillaFang() : base()
		{
			Id = 9467;
			Bonding = 1;
			SellPrice = 18681;
			AvailableClasses = 0x7FFF;
			Model = 20311;
			ObjectClass = 2;
			SubClass = 15;
			Level = 47;
			ReqLevel = 42;
			Name = "Gahz'rilla Fang";
			Name2 = "Gahz'rilla Fang";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 93409;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1800;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 3;
			Durability = 55;
			SetSpell( 3742 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 35 , 66 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Silent Hunter)
*
***************************************************************/

namespace Server.Items
{
	public class SilentHunter : Item
	{
		public SilentHunter() : base()
		{
			Id = 9520;
			Bonding = 1;
			SellPrice = 11461;
			AvailableClasses = 0x7FFF;
			Model = 20574;
			ObjectClass = 2;
			SubClass = 15;
			Level = 41;
			Name = "Silent Hunter";
			Name2 = "Silent Hunter";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 57309;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1800;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 55;
			SetDamage( 29 , 54 , Resistances.Armor );
			AgilityBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Tok'kar's Murloc Shanker)
*
***************************************************************/

namespace Server.Items
{
	public class TokkarsMurlocShanker : Item
	{
		public TokkarsMurlocShanker() : base()
		{
			Id = 9680;
			Bonding = 1;
			SellPrice = 14090;
			AvailableClasses = 0x7FFF;
			Model = 20475;
			ObjectClass = 2;
			SubClass = 15;
			Level = 43;
			Name = "Tok'kar's Murloc Shanker";
			Name2 = "Tok'kar's Murloc Shanker";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 70451;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1600;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 55;
			SetDamage( 28 , 52 , Resistances.Armor );
			StaminaBonus = 3;
			AgilityBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Diabolist's Blade)
*
***************************************************************/

namespace Server.Items
{
	public class DiabolistsBlade : Item
	{
		public DiabolistsBlade() : base()
		{
			Id = 10049;
			Bonding = 1;
			SellPrice = 2653;
			AvailableClasses = 0x100;
			Model = 20472;
			ObjectClass = 2;
			SubClass = 15;
			Level = 25;
			Name = "Diabolist's Blade";
			Name2 = "Diabolist's Blade";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 13267;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1500;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 45;
			Flags = 16;
			SetSpell( 7707 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 13 , 25 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Camping Knife)
*
***************************************************************/

namespace Server.Items
{
	public class CampingKnife : Item
	{
		public CampingKnife() : base()
		{
			Id = 10547;
			Bonding = 1;
			SellPrice = 81;
			AvailableClasses = 0x7FFF;
			Model = 6472;
			ObjectClass = 2;
			SubClass = 15;
			Level = 8;
			Name = "Camping Knife";
			Name2 = "Camping Knife";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 408;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1400;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 25;
			SetDamage( 3 , 6 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Stealthblade)
*
***************************************************************/

namespace Server.Items
{
	public class Stealthblade : Item
	{
		public Stealthblade() : base()
		{
			Id = 10625;
			Bonding = 2;
			SellPrice = 27366;
			AvailableClasses = 0x7FFF;
			Model = 20315;
			ObjectClass = 2;
			SubClass = 15;
			Level = 49;
			ReqLevel = 44;
			Name = "Stealthblade";
			Name2 = "Stealthblade";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 136831;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1400;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			SetSpell( 12685 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 32 , 60 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Enchanted Azsharite Felbane Dagger)
*
***************************************************************/

namespace Server.Items
{
	public class EnchantedAzshariteFelbaneDagger : Item
	{
		public EnchantedAzshariteFelbaneDagger() : base()
		{
			Id = 10697;
			Bonding = 1;
			SellPrice = 42044;
			AvailableClasses = 0x7FFF;
			Description = "Engraved upon the blade: Rakh'likh";
			Model = 20570;
			ObjectClass = 2;
			SubClass = 15;
			Level = 60;
			Name = "Enchanted Azsharite Felbane Dagger";
			Name2 = "Enchanted Azsharite Felbane Dagger";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 210221;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1500;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 55;
			SetSpell( 18079 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 12938 , 0 , 0 , 0 , 0 , 0 );
			SetDamage( 37 , 70 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Fiendish Skiv)
*
***************************************************************/

namespace Server.Items
{
	public class FiendishSkiv : Item
	{
		public FiendishSkiv() : base()
		{
			Id = 10703;
			Bonding = 1;
			SellPrice = 16792;
			AvailableClasses = 0x7FFF;
			Model = 20297;
			ObjectClass = 2;
			SubClass = 15;
			Level = 45;
			Name = "Fiendish Skiv";
			Name2 = "Fiendish Skiv";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 83963;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1900;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 55;
			SetDamage( 35 , 66 , Resistances.Armor );
			StrBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Lifeforce Dirk)
*
***************************************************************/

namespace Server.Items
{
	public class LifeforceDirk : Item
	{
		public LifeforceDirk() : base()
		{
			Id = 10750;
			Bonding = 1;
			SellPrice = 35315;
			AvailableClasses = 0x7FFF;
			Model = 20569;
			ObjectClass = 2;
			SubClass = 15;
			Level = 54;
			Name = "Lifeforce Dirk";
			Name2 = "Lifeforce Dirk";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 176577;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1600;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			SetDamage( 40 , 75 , Resistances.Armor );
			StaminaBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Coldrage Dagger)
*
***************************************************************/

namespace Server.Items
{
	public class ColdrageDagger : Item
	{
		public ColdrageDagger() : base()
		{
			Id = 10761;
			Bonding = 1;
			SellPrice = 17193;
			AvailableClasses = 0x7FFF;
			Model = 20572;
			ObjectClass = 2;
			SubClass = 15;
			Level = 44;
			ReqLevel = 39;
			Name = "Coldrage Dagger";
			Name2 = "Coldrage Dagger";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 85966;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1500;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			SetSpell( 13439 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 31 , 58 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Dire Nail)
*
***************************************************************/

namespace Server.Items
{
	public class DireNail : Item
	{
		public DireNail() : base()
		{
			Id = 10828;
			Bonding = 1;
			SellPrice = 40427;
			AvailableClasses = 0x7FFF;
			Model = 20273;
			ObjectClass = 2;
			SubClass = 15;
			Level = 56;
			ReqLevel = 51;
			Name = "Dire Nail";
			Name2 = "Dire Nail";
			Quality = 3;
			AvailableRaces = 0x1FF;
			Extra = 5315;
			BuyPrice = 202136;
			Resistance[5] = 5;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1500;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			SetDamage( 38 , 72 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Hookfang Shanker)
*
***************************************************************/

namespace Server.Items
{
	public class HookfangShanker : Item
	{
		public HookfangShanker() : base()
		{
			Id = 11635;
			Bonding = 1;
			SellPrice = 35451;
			AvailableClasses = 0x7FFF;
			Model = 28779;
			ObjectClass = 2;
			SubClass = 15;
			Level = 54;
			ReqLevel = 49;
			Name = "Hookfang Shanker";
			Name2 = "Hookfang Shanker";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 177256;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1400;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			SetSpell( 13526 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 35 , 65 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Ceremonial Elven Blade)
*
***************************************************************/

namespace Server.Items
{
	public class CeremonialElvenBlade : Item
	{
		public CeremonialElvenBlade() : base()
		{
			Id = 11856;
			Bonding = 1;
			SellPrice = 15775;
			AvailableClasses = 0x7FFF;
			Model = 28312;
			ObjectClass = 2;
			SubClass = 15;
			Level = 45;
			Name = "Ceremonial Elven Blade";
			Name2 = "Ceremonial Elven Blade";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 78876;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1800;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 55;
			SetDamage( 33 , 63 , Resistances.Armor );
			StaminaBonus = 3;
			AgilityBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Blood-etched Blade)
*
***************************************************************/

namespace Server.Items
{
	public class BloodEtchedBlade : Item
	{
		public BloodEtchedBlade() : base()
		{
			Id = 11922;
			Bonding = 1;
			SellPrice = 43491;
			AvailableClasses = 0x7FFF;
			Model = 25609;
			ObjectClass = 2;
			SubClass = 15;
			Level = 57;
			ReqLevel = 52;
			Name = "Blood-etched Blade";
			Name2 = "Blood-etched Blade";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 217457;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1500;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			SetSpell( 15695 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 21 , 40 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Skilled Fighting Blade)
*
***************************************************************/

namespace Server.Items
{
	public class SkilledFightingBlade : Item
	{
		public SkilledFightingBlade() : base()
		{
			Id = 12062;
			Bonding = 1;
			SellPrice = 40365;
			AvailableClasses = 0x7FFF;
			Model = 25611;
			ObjectClass = 2;
			SubClass = 15;
			Level = 60;
			Name = "Skilled Fighting Blade";
			Name2 = "Skilled Fighting Blade";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 201827;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1400;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 55;
			SetSpell( 15776 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 35 , 65 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Broad Bladed Knife)
*
***************************************************************/

namespace Server.Items
{
	public class BroadBladedKnife : Item
	{
		public BroadBladedKnife() : base()
		{
			Id = 12247;
			Bonding = 2;
			SellPrice = 5674;
			AvailableClasses = 0x7FFF;
			Model = 22247;
			ObjectClass = 2;
			SubClass = 15;
			Level = 32;
			ReqLevel = 27;
			Name = "Broad Bladed Knife";
			Name2 = "Broad Bladed Knife";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 28372;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2000;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 55;
			SetDamage( 23 , 44 , Resistances.Armor );
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Daring Dirk)
*
***************************************************************/

namespace Server.Items
{
	public class DaringDirk : Item
	{
		public DaringDirk() : base()
		{
			Id = 12248;
			Bonding = 2;
			SellPrice = 6405;
			AvailableClasses = 0x7FFF;
			Model = 22248;
			ObjectClass = 2;
			SubClass = 15;
			Level = 34;
			ReqLevel = 29;
			Name = "Daring Dirk";
			Name2 = "Daring Dirk";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 32029;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1600;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 55;
			SetDamage( 19 , 37 , Resistances.Armor );
			AgilityBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Glinting Steel Dagger)
*
***************************************************************/

namespace Server.Items
{
	public class GlintingSteelDagger : Item
	{
		public GlintingSteelDagger() : base()
		{
			Id = 12259;
			Bonding = 2;
			SellPrice = 8072;
			AvailableClasses = 0x7FFF;
			Model = 4119;
			ObjectClass = 2;
			SubClass = 15;
			Level = 36;
			ReqLevel = 31;
			Name = "Glinting Steel Dagger";
			Name2 = "Glinting Steel Dagger";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 40363;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1500;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 55;
			SetSpell( 9141 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 19 , 37 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Searing Golden Blade)
*
***************************************************************/

namespace Server.Items
{
	public class SearingGoldenBlade : Item
	{
		public SearingGoldenBlade() : base()
		{
			Id = 12260;
			Bonding = 2;
			SellPrice = 10395;
			AvailableClasses = 0x7FFF;
			Model = 22258;
			ObjectClass = 2;
			SubClass = 15;
			Level = 39;
			ReqLevel = 34;
			Name = "Searing Golden Blade";
			Name2 = "Searing Golden Blade";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 51977;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1400;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 55;
			SetSpell( 7689 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 21 , 39 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Searing Needle)
*
***************************************************************/

namespace Server.Items
{
	public class SearingNeedle : Item
	{
		public SearingNeedle() : base()
		{
			Id = 12531;
			Bonding = 2;
			SellPrice = 28883;
			AvailableClasses = 0x7FFF;
			Model = 22721;
			ObjectClass = 2;
			SubClass = 15;
			Level = 51;
			ReqLevel = 46;
			Name = "Searing Needle";
			Name2 = "Searing Needle";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 144416;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1800;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			SetSpell( 16454 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 42 , 80 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Keris of Zul'Serak)
*
***************************************************************/

namespace Server.Items
{
	public class KerisOfZulSerak : Item
	{
		public KerisOfZulSerak() : base()
		{
			Id = 12582;
			Bonding = 1;
			SellPrice = 51199;
			AvailableClasses = 0x7FFF;
			Model = 28789;
			ObjectClass = 2;
			SubClass = 15;
			Level = 60;
			ReqLevel = 55;
			Name = "Keris of Zul'Serak";
			Name2 = "Keris of Zul'Serak";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 255997;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1800;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			SetSpell( 16528 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 49 , 93 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Felstriker)
*
***************************************************************/

namespace Server.Items
{
	public class Felstriker : Item
	{
		public Felstriker() : base()
		{
			Id = 12590;
			Bonding = 1;
			SellPrice = 75624;
			AvailableClasses = 0x7FFF;
			Model = 25613;
			ObjectClass = 2;
			SubClass = 15;
			Level = 63;
			ReqLevel = 58;
			Name = "Felstriker";
			Name2 = "Felstriker";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 378124;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1700;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetSpell( 16551 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 54 , 101 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Finkle's Skinner)
*
***************************************************************/

namespace Server.Items
{
	public class FinklesSkinner : Item
	{
		public FinklesSkinner() : base()
		{
			Id = 12709;
			Bonding = 1;
			SellPrice = 57991;
			AvailableClasses = 0x7FFF;
			Description = "Property of Finkle Einhorn, Grandmaster Adventurer";
			Model = 22977;
			ObjectClass = 2;
			SubClass = 15;
			Level = 63;
			ReqLevel = 58;
			Name = "Finkle's Skinner";
			Name2 = "Finkle's Skinner";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 289956;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1300;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			SetSpell( 16718 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 18067 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 37 , 70 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Heartseeker)
*
***************************************************************/

namespace Server.Items
{
	public class Heartseeker : Item
	{
		public Heartseeker() : base()
		{
			Id = 12783;
			Bonding = 2;
			SellPrice = 58215;
			AvailableClasses = 0x7FFF;
			Model = 23248;
			ObjectClass = 2;
			SubClass = 15;
			Level = 63;
			ReqLevel = 58;
			Name = "Heartseeker";
			Name2 = "Heartseeker";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 291079;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1700;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 49 , 92 , Resistances.Armor );
			StrBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Barman Shanker)
*
***************************************************************/

namespace Server.Items
{
	public class BarmanShanker : Item
	{
		public BarmanShanker() : base()
		{
			Id = 12791;
			Bonding = 1;
			SellPrice = 39411;
			AvailableClasses = 0x7FFF;
			Model = 23262;
			ObjectClass = 2;
			SubClass = 15;
			Level = 55;
			ReqLevel = 50;
			Name = "Barman Shanker";
			Name2 = "Barman Shanker";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 197059;
			InventoryType = InventoryTypes.OneHand;
			Delay = 2000;
			Stackable = 1;
			Material = 1;
			Sheath = 7;
			Durability = 65;
			SetSpell( 13318 , 2 , 0 , 0 , 0 , -1 );
			SetDamage( 51 , 95 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Fang of the Crystal Spider)
*
***************************************************************/

namespace Server.Items
{
	public class FangOfTheCrystalSpider : Item
	{
		public FangOfTheCrystalSpider() : base()
		{
			Id = 13218;
			Bonding = 1;
			SellPrice = 53388;
			AvailableClasses = 0x7FFF;
			Model = 23791;
			ObjectClass = 2;
			SubClass = 15;
			Level = 61;
			ReqLevel = 56;
			Name = "Fang of the Crystal Spider";
			Name2 = "Fang of the Crystal Spider";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 266942;
			Sets = 65;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1600;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			SetSpell( 17331 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 45 , 84 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Gift of the Elven Magi)
*
***************************************************************/

namespace Server.Items
{
	public class GiftOfTheElvenMagi : Item
	{
		public GiftOfTheElvenMagi() : base()
		{
			Id = 13360;
			Bonding = 1;
			SellPrice = 56517;
			AvailableClasses = 0x7FFF;
			Model = 24046;
			ObjectClass = 2;
			SubClass = 15;
			Level = 63;
			ReqLevel = 58;
			Name = "Gift of the Elven Magi";
			Name2 = "Gift of the Elven Magi";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 282585;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1500;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			SetDamage( 43 , 81 , Resistances.Armor );
			IqBonus = 6;
			SpiritBonus = 10;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Bonescraper)
*
***************************************************************/

namespace Server.Items
{
	public class Bonescraper : Item
	{
		public Bonescraper() : base()
		{
			Id = 13368;
			Bonding = 1;
			SellPrice = 55438;
			AvailableClasses = 0x7FFF;
			Model = 25614;
			ObjectClass = 2;
			SubClass = 15;
			Level = 62;
			ReqLevel = 57;
			Name = "Bonescraper";
			Name2 = "Bonescraper";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 277190;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1400;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			SetSpell( 9336 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 40 , 74 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Spiked Dagger)
*
***************************************************************/

namespace Server.Items
{
	public class SpikedDagger : Item
	{
		public SpikedDagger() : base()
		{
			Id = 13822;
			SellPrice = 11442;
			AvailableClasses = 0x7FFF;
			Model = 4119;
			ObjectClass = 2;
			SubClass = 15;
			Level = 53;
			ReqLevel = 48;
			Name = "Spiked Dagger";
			Name2 = "Spiked Dagger";
			AvailableRaces = 0x1FF;
			BuyPrice = 57212;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1600;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 55;
			SetDamage( 21 , 40 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Witchblade)
*
***************************************************************/

namespace Server.Items
{
	public class Witchblade : Item
	{
		public Witchblade() : base()
		{
			Id = 13964;
			Bonding = 1;
			SellPrice = 52306;
			AvailableClasses = 0x7FFF;
			Model = 24775;
			ObjectClass = 2;
			SubClass = 15;
			Level = 62;
			ReqLevel = 57;
			Name = "Witchblade";
			Name2 = "Witchblade";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 261533;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1600;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			SetSpell( 13599 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 9414 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 45 , 85 , Resistances.Armor );
			SpiritBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Darrowspike)
*
***************************************************************/

namespace Server.Items
{
	public class Darrowspike : Item
	{
		public Darrowspike() : base()
		{
			Id = 13984;
			Bonding = 1;
			SellPrice = 57806;
			AvailableClasses = 0x7FFF;
			Model = 26679;
			ObjectClass = 2;
			SubClass = 15;
			Level = 63;
			Name = "Darrowspike";
			Name2 = "Darrowspike";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 289034;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1500;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			SetSpell( 18276 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 43 , 81 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Frightalon)
*
***************************************************************/

namespace Server.Items
{
	public class Frightalon : Item
	{
		public Frightalon() : base()
		{
			Id = 14024;
			Bonding = 1;
			SellPrice = 52422;
			AvailableClasses = 0x7FFF;
			Model = 20592;
			ObjectClass = 2;
			SubClass = 15;
			Level = 61;
			ReqLevel = 56;
			Name = "Frightalon";
			Name2 = "Frightalon";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 262111;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1400;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			SetSpell( 19755 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 39 , 73 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Chanting Blade)
*
***************************************************************/

namespace Server.Items
{
	public class ChantingBlade : Item
	{
		public ChantingBlade() : base()
		{
			Id = 14151;
			Bonding = 1;
			SellPrice = 1055;
			AvailableClasses = 0x7FFF;
			Model = 24990;
			ObjectClass = 2;
			SubClass = 15;
			Level = 18;
			ReqLevel = 13;
			Name = "Chanting Blade";
			Name2 = "Chanting Blade";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5279;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1500;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 40;
			SetDamage( 9 , 18 , Resistances.Armor );
			AgilityBonus = 1;
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Alcor's Sunrazor)
*
***************************************************************/

namespace Server.Items
{
	public class AlcorsSunrazor : Item
	{
		public AlcorsSunrazor() : base()
		{
			Id = 14555;
			Bonding = 1;
			SellPrice = 78772;
			AvailableClasses = 0x7FFF;
			Model = 25612;
			Resistance[2] = 10;
			ObjectClass = 2;
			SubClass = 15;
			Level = 63;
			ReqLevel = 58;
			Name = "Alcor's Sunrazor";
			Name2 = "Alcor's Sunrazor";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 393863;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1300;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetSpell( 18833 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 41 , 77 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Battle Knife)
*
***************************************************************/

namespace Server.Items
{
	public class BattleKnife : Item
	{
		public BattleKnife() : base()
		{
			Id = 15241;
			Bonding = 2;
			SellPrice = 3012;
			AvailableClasses = 0x7FFF;
			Model = 20414;
			ObjectClass = 2;
			SubClass = 15;
			Level = 26;
			ReqLevel = 21;
			Name = "Battle Knife";
			Name2 = "Battle Knife";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5207;
			BuyPrice = 15060;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1600;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 50;
			SetDamage( 15 , 28 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Honed Stiletto)
*
***************************************************************/

namespace Server.Items
{
	public class HonedStiletto : Item
	{
		public HonedStiletto() : base()
		{
			Id = 15242;
			Bonding = 2;
			SellPrice = 4426;
			AvailableClasses = 0x7FFF;
			Model = 28568;
			ObjectClass = 2;
			SubClass = 15;
			Level = 30;
			ReqLevel = 25;
			Name = "Honed Stiletto";
			Name2 = "Honed Stiletto";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5216;
			BuyPrice = 22133;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1400;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 55;
			SetDamage( 15 , 29 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Deadly Kris)
*
***************************************************************/

namespace Server.Items
{
	public class DeadlyKris : Item
	{
		public DeadlyKris() : base()
		{
			Id = 15243;
			Bonding = 2;
			SellPrice = 7871;
			AvailableClasses = 0x7FFF;
			Model = 28348;
			ObjectClass = 2;
			SubClass = 15;
			Level = 36;
			ReqLevel = 31;
			Name = "Deadly Kris";
			Name2 = "Deadly Kris";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5234;
			BuyPrice = 39357;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1400;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 55;
			SetDamage( 18 , 35 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Razor Blade)
*
***************************************************************/

namespace Server.Items
{
	public class RazorBlade : Item
	{
		public RazorBlade() : base()
		{
			Id = 15244;
			Bonding = 2;
			SellPrice = 12769;
			AvailableClasses = 0x7FFF;
			Model = 3175;
			ObjectClass = 2;
			SubClass = 15;
			Level = 42;
			ReqLevel = 37;
			Name = "Razor Blade";
			Name2 = "Razor Blade";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5252;
			BuyPrice = 63848;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1700;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 55;
			SetDamage( 28 , 53 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Vorpal Dagger)
*
***************************************************************/

namespace Server.Items
{
	public class VorpalDagger : Item
	{
		public VorpalDagger() : base()
		{
			Id = 15245;
			Bonding = 2;
			SellPrice = 23284;
			AvailableClasses = 0x7FFF;
			Model = 6448;
			ObjectClass = 2;
			SubClass = 15;
			Level = 50;
			ReqLevel = 45;
			Name = "Vorpal Dagger";
			Name2 = "Vorpal Dagger";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5279;
			BuyPrice = 116423;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1600;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 55;
			SetDamage( 33 , 62 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Demon Blade)
*
***************************************************************/

namespace Server.Items
{
	public class DemonBlade : Item
	{
		public DemonBlade() : base()
		{
			Id = 15246;
			Bonding = 2;
			SellPrice = 45704;
			AvailableClasses = 0x7FFF;
			Model = 20299;
			ObjectClass = 2;
			SubClass = 15;
			Level = 62;
			ReqLevel = 57;
			Name = "Demon Blade";
			Name2 = "Demon Blade";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5315;
			BuyPrice = 228524;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1800;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 55;
			SetDamage( 46 , 87 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Bloodstrike Dagger)
*
***************************************************************/

namespace Server.Items
{
	public class BloodstrikeDagger : Item
	{
		public BloodstrikeDagger() : base()
		{
			Id = 15247;
			Bonding = 2;
			SellPrice = 50576;
			AvailableClasses = 0x7FFF;
			Model = 28327;
			ObjectClass = 2;
			SubClass = 15;
			Level = 64;
			ReqLevel = 59;
			Name = "Bloodstrike Dagger";
			Name2 = "Bloodstrike Dagger";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 5324;
			BuyPrice = 252880;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1700;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 55;
			SetDamage( 45 , 85 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Curvewood Dagger)
*
***************************************************************/

namespace Server.Items
{
	public class CurvewoodDagger : Item
	{
		public CurvewoodDagger() : base()
		{
			Id = 15396;
			Bonding = 1;
			SellPrice = 582;
			AvailableClasses = 0x7FFF;
			Model = 26602;
			ObjectClass = 2;
			SubClass = 15;
			Level = 14;
			Name = "Curvewood Dagger";
			Name2 = "Curvewood Dagger";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2913;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1500;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 35;
			SetDamage( 7 , 14 , Resistances.Armor );
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Kris of Orgrimmar)
*
***************************************************************/

namespace Server.Items
{
	public class KrisOfOrgrimmar : Item
	{
		public KrisOfOrgrimmar() : base()
		{
			Id = 15443;
			Bonding = 1;
			SellPrice = 1119;
			AvailableClasses = 0x7FFF;
			Model = 28199;
			ObjectClass = 2;
			SubClass = 15;
			Level = 18;
			Name = "Kris of Orgrimmar";
			Name2 = "Kris of Orgrimmar";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5598;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1500;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 40;
			SetDamage( 9 , 18 , Resistances.Armor );
			StaminaBonus = 1;
			IqBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Hunt Tracker Blade)
*
***************************************************************/

namespace Server.Items
{
	public class HuntTrackerBlade : Item
	{
		public HuntTrackerBlade() : base()
		{
			Id = 15706;
			Bonding = 1;
			SellPrice = 33830;
			AvailableClasses = 0x7FFF;
			Model = 26433;
			ObjectClass = 2;
			SubClass = 15;
			Level = 57;
			Name = "Hunt Tracker Blade";
			Name2 = "Hunt Tracker Blade";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 169154;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1500;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 55;
			SetDamage( 35 , 66 , Resistances.Armor );
			IqBonus = 5;
			AgilityBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Beasthunter Dagger)
*
***************************************************************/

namespace Server.Items
{
	public class BeasthunterDagger : Item
	{
		public BeasthunterDagger() : base()
		{
			Id = 15783;
			Bonding = 1;
			SellPrice = 43292;
			AvailableClasses = 0x7FFF;
			Model = 26464;
			ObjectClass = 2;
			SubClass = 15;
			Level = 60;
			Name = "Beasthunter Dagger";
			Name2 = "Beasthunter Dagger";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 216460;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1700;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 55;
			SetSpell( 19380 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 42 , 79 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Fang of the Mystics)
*
***************************************************************/

namespace Server.Items
{
	public class FangOfTheMystics : Item
	{
		public FangOfTheMystics() : base()
		{
			Id = 17070;
			Bonding = 1;
			SellPrice = 109307;
			AvailableClasses = 0x7FFF;
			Model = 29706;
			ObjectClass = 2;
			SubClass = 15;
			Level = 70;
			ReqLevel = 60;
			Name = "Fang of the Mystics";
			Name2 = "Fang of the Mystics";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 546537;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1500;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetSpell( 18384 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 21362 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 54 , 101 , Resistances.Armor );
			SpiritBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Gutgore Ripper)
*
***************************************************************/

namespace Server.Items
{
	public class GutgoreRipper : Item
	{
		public GutgoreRipper() : base()
		{
			Id = 17071;
			Bonding = 1;
			SellPrice = 104472;
			AvailableClasses = 0x7FFF;
			Model = 29167;
			ObjectClass = 2;
			SubClass = 15;
			Level = 69;
			ReqLevel = 60;
			Name = "Gutgore Ripper";
			Name2 = "Gutgore Ripper";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 522363;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1800;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetSpell( 21151 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 63 , 119 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Shard of the Defiler)
*
***************************************************************/

namespace Server.Items
{
	public class ShardOfTheDefiler : Item
	{
		public ShardOfTheDefiler() : base()
		{
			Id = 17142;
			Bonding = 1;
			SellPrice = 159115;
			AvailableClasses = 0x7FFF;
			Model = 29097;
			ObjectClass = 2;
			SubClass = 15;
			Level = 70;
			ReqLevel = 60;
			Name = "Shard of the Defiler";
			Name2 = "Shard of the Defiler";
			Quality = 5;
			AvailableRaces = 0x1FF;
			BuyPrice = 795578;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1100;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Sheath = 1;
			Durability = 95;
			SetSpell( 21079 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 52 , 61 , Resistances.Armor );
			SetDamage( 10 , 15 , Resistances.Shadow );
		}
	}
}


/**************************************************************
*
*				(Charstone Dirk)
*
***************************************************************/

namespace Server.Items
{
	public class CharstoneDirk : Item
	{
		public CharstoneDirk() : base()
		{
			Id = 17710;
			Bonding = 1;
			SellPrice = 35483;
			AvailableClasses = 0x7FFF;
			Model = 29872;
			ObjectClass = 2;
			SubClass = 15;
			Level = 54;
			ReqLevel = 49;
			Name = "Charstone Dirk";
			Name2 = "Charstone Dirk";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 177417;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1600;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			SetSpell( 21623 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 40 , 75 , Resistances.Armor );
			SpiritBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Satyr's Lash)
*
***************************************************************/

namespace Server.Items
{
	public class SatyrsLash : Item
	{
		public SatyrsLash() : base()
		{
			Id = 17752;
			Bonding = 1;
			SellPrice = 28785;
			AvailableClasses = 0x7FFF;
			Model = 29931;
			ObjectClass = 2;
			SubClass = 15;
			Level = 50;
			ReqLevel = 45;
			Name = "Satyr's Lash";
			Name2 = "Satyr's Lash";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 143928;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1700;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			SetSpell( 18205 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 39 , 74 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Blade of Eternal Darkness)
*
***************************************************************/

namespace Server.Items
{
	public class BladeOfEternalDarkness : Item
	{
		public BladeOfEternalDarkness() : base()
		{
			Id = 17780;
			Bonding = 1;
			SellPrice = 46796;
			AvailableClasses = 0x7FFF;
			Model = 29957;
			ObjectClass = 2;
			SubClass = 15;
			Level = 54;
			Name = "Blade of Eternal Darkness";
			Name2 = "Blade of Eternal Darkness";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 233983;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1500;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			Flags = 64;
			SetSpell( 21978 , 0 , 0 , 30000 , 0 , -1 );
			SetDamage( 33 , 69 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Blade of the New Moon)
*
***************************************************************/

namespace Server.Items
{
	public class BladeOfTheNewMoon : Item
	{
		public BladeOfTheNewMoon() : base()
		{
			Id = 18372;
			Bonding = 1;
			SellPrice = 56716;
			AvailableClasses = 0x7FFF;
			Model = 30724;
			ObjectClass = 2;
			SubClass = 15;
			Level = 62;
			ReqLevel = 57;
			Name = "Blade of the New Moon";
			Name2 = "Blade of the New Moon";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 283580;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1400;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			SetSpell( 9326 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 40 , 74 , Resistances.Armor );
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Distracting Dagger)
*
***************************************************************/

namespace Server.Items
{
	public class DistractingDagger : Item
	{
		public DistractingDagger() : base()
		{
			Id = 18392;
			Bonding = 1;
			SellPrice = 56710;
			AvailableClasses = 0x7FFF;
			Model = 6443;
			ObjectClass = 2;
			SubClass = 15;
			Level = 62;
			ReqLevel = 57;
			Name = "Distracting Dagger";
			Name2 = "Distracting Dagger";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 283553;
			InventoryType = InventoryTypes.OffHand;
			Delay = 1300;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			SetSpell( 15717 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 42 , 64 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Lorespinner)
*
***************************************************************/

namespace Server.Items
{
	public class Lorespinner : Item
	{
		public Lorespinner() : base()
		{
			Id = 18491;
			Bonding = 1;
			SellPrice = 40695;
			AvailableClasses = 0x7FFF;
			Model = 30827;
			ObjectClass = 2;
			SubClass = 15;
			Level = 57;
			Name = "Lorespinner";
			Name2 = "Lorespinner";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 203475;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1500;
			Stackable = 1;
			Material = 4;
			Sheath = 3;
			Durability = 65;
			SetSpell( 21361 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 45 , 68 , Resistances.Armor );
			IqBonus = 5;
			SpiritBonus = 6;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Specter's Blade)
*
***************************************************************/

namespace Server.Items
{
	public class SpectersBlade : Item
	{
		public SpectersBlade() : base()
		{
			Id = 18758;
			Bonding = 1;
			SellPrice = 54072;
			AvailableClasses = 0x7FFF;
			Model = 20574;
			ObjectClass = 2;
			SubClass = 15;
			Level = 62;
			ReqLevel = 57;
			Name = "Specter's Blade";
			Name2 = "Specter's Blade";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 270363;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1800;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			SetSpell( 18098 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 51 , 96 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Core Hound Tooth)
*
***************************************************************/

namespace Server.Items
{
	public class CoreHoundTooth : Item
	{
		public CoreHoundTooth() : base()
		{
			Id = 18805;
			Bonding = 1;
			SellPrice = 109275;
			AvailableClasses = 0x7FFF;
			Model = 31266;
			ObjectClass = 2;
			SubClass = 15;
			Level = 70;
			ReqLevel = 60;
			Name = "Core Hound Tooth";
			Name2 = "Core Hound Tooth";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 546375;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1600;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 9331 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 57 , 107 , Resistances.Armor );
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Perdition's Blade)
*
***************************************************************/

namespace Server.Items
{
	public class PerditionsBlade : Item
	{
		public PerditionsBlade() : base()
		{
			Id = 18816;
			Bonding = 1;
			SellPrice = 148714;
			AvailableClasses = 0x7FFF;
			Model = 31283;
			ObjectClass = 2;
			SubClass = 15;
			Level = 77;
			ReqLevel = 60;
			Name = "Perdition's Blade";
			Name2 = "Perdition's Blade";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 743570;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1800;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetSpell( 23267 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 73 , 137 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Grand Marshal's Dirk)
*
***************************************************************/

namespace Server.Items
{
	public class GrandMarshalsDirk : Item
	{
		public GrandMarshalsDirk() : base()
		{
			Id = 18838;
			Bonding = 1;
			SellPrice = 48458;
			AvailableClasses = 0x7FFF;
			Model = 31379;
			ObjectClass = 2;
			SubClass = 15;
			Level = 78;
			ReqLevel = 60;
			Name = "Grand Marshal's Dirk";
			Name2 = "Grand Marshal's Dirk";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 242293;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2000;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			Flags = 32768;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 9335 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 95 , 143 , Resistances.Armor );
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(High Warlord's Razor)
*
***************************************************************/

namespace Server.Items
{
	public class HighWarlordsRazor : Item
	{
		public HighWarlordsRazor() : base()
		{
			Id = 18840;
			Bonding = 1;
			SellPrice = 48812;
			AvailableClasses = 0x7FFF;
			Model = 31381;
			ObjectClass = 2;
			SubClass = 15;
			Level = 78;
			ReqLevel = 60;
			Name = "High Warlord's Razor";
			Name2 = "High Warlord's Razor";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 244064;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 2000;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			Flags = 32768;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 9335 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 95 , 143 , Resistances.Armor );
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Sorcerous Dagger)
*
***************************************************************/

namespace Server.Items
{
	public class SorcerousDagger : Item
	{
		public SorcerousDagger() : base()
		{
			Id = 18878;
			Bonding = 1;
			SellPrice = 85645;
			AvailableClasses = 0x7FFF;
			Model = 31337;
			ObjectClass = 2;
			SubClass = 15;
			Level = 65;
			ReqLevel = 60;
			Name = "Sorcerous Dagger";
			Name2 = "Sorcerous Dagger";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 428226;
			InventoryType = InventoryTypes.OneHand;
			Delay = 1400;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetSpell( 14799 , 1 , 0 , -1 , 0 , -1 );
			SetDamage( 39 , 79 , Resistances.Armor );
			SpiritBonus = 17;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Glacial Blade)
*
***************************************************************/

namespace Server.Items
{
	public class GlacialBlade : Item
	{
		public GlacialBlade() : base()
		{
			Id = 19099;
			Bonding = 1;
			SellPrice = 63065;
			AvailableClasses = 0x7FFF;
			Model = 31605;
			ObjectClass = 2;
			SubClass = 15;
			Level = 65;
			ReqLevel = 60;
			Name = "Glacial Blade";
			Name2 = "Glacial Blade";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 315329;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1800;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			Flags = 32768;
			SetSpell( 18398 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 53 , 100 , Resistances.Armor );
			AgilityBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Electrified Dagger)
*
***************************************************************/

namespace Server.Items
{
	public class ElectrifiedDagger : Item
	{
		public ElectrifiedDagger() : base()
		{
			Id = 19100;
			Bonding = 1;
			SellPrice = 63300;
			AvailableClasses = 0x7FFF;
			Model = 31606;
			ObjectClass = 2;
			SubClass = 15;
			Level = 65;
			ReqLevel = 60;
			Name = "Electrified Dagger";
			Name2 = "Electrified Dagger";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 316503;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1800;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 3;
			Durability = 65;
			Flags = 32768;
			SetSpell( 23592 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 53 , 100 , Resistances.Armor );
			AgilityBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Black Amnesty)
*
***************************************************************/

namespace Server.Items
{
	public class BlackAmnesty : Item
	{
		public BlackAmnesty() : base()
		{
			Id = 19166;
			Bonding = 1;
			SellPrice = 92896;
			AvailableClasses = 0x7FFF;
			Model = 31686;
			ObjectClass = 2;
			SubClass = 15;
			Level = 66;
			ReqLevel = 60;
			Name = "Black Amnesty";
			Name2 = "Black Amnesty";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 464480;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1600;
			Stackable = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetSpell( 23604 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 53 , 100 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(The Lobotomizer)
*
***************************************************************/

namespace Server.Items
{
	public class TheLobotomizer : Item
	{
		public TheLobotomizer() : base()
		{
			Id = 19324;
			Bonding = 1;
			SellPrice = 251323;
			AvailableClasses = 0x7FFF;
			Model = 31820;
			ObjectClass = 2;
			SubClass = 15;
			Level = 65;
			ReqLevel = 60;
			Name = "The Lobotomizer";
			Name2 = "The Lobotomizer";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 1256618;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1800;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			Flags = 32768;
			SetSpell( 17148 , 2 , 0 , -1 , 0 , -1 );
			SetDamage( 59 , 111 , Resistances.Armor );
		}
	}
}


/**************************************************************
*
*				(Dragonfang Blade)
*
***************************************************************/

namespace Server.Items
{
	public class DragonfangBlade : Item
	{
		public DragonfangBlade() : base()
		{
			Id = 19346;
			Bonding = 1;
			SellPrice = 130907;
			AvailableClasses = 0x7FFF;
			Model = 31864;
			ObjectClass = 2;
			SubClass = 15;
			Level = 74;
			ReqLevel = 60;
			Name = "Dragonfang Blade";
			Name2 = "Dragonfang Blade";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 654536;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1800;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 3;
			Durability = 75;
			SetDamage( 69 , 130 , Resistances.Armor );
			AgilityBonus = 16;
			StaminaBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Scout's Blade)
*
***************************************************************/

namespace Server.Items
{
	public class ScoutsBlade : Item
	{
		public ScoutsBlade() : base()
		{
			Id = 19542;
			Bonding = 1;
			SellPrice = 54922;
			AvailableClasses = 0x7FFF;
			Model = 32074;
			ObjectClass = 2;
			SubClass = 15;
			Level = 63;
			ReqLevel = 58;
			Name = "Scout's Blade";
			Name2 = "Scout's Blade";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 274611;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1700;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 4;
			Durability = 65;
			Flags = 32768;
			SetDamage( 49 , 92 , Resistances.Armor );
			AgilityBonus = 13;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Scout's Blade)
*
***************************************************************/

namespace Server.Items
{
	public class ScoutsBlade19543 : Item
	{
		public ScoutsBlade19543() : base()
		{
			Id = 19543;
			Bonding = 1;
			SellPrice = 32156;
			AvailableClasses = 0x7FFF;
			Model = 32074;
			ObjectClass = 2;
			SubClass = 15;
			Level = 53;
			ReqLevel = 48;
			Name = "Scout's Blade";
			Name2 = "Scout's Blade";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 160783;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1700;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 4;
			Durability = 65;
			Flags = 32768;
			SetDamage( 41 , 78 , Resistances.Armor );
			AgilityBonus = 11;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Scout's Blade)
*
***************************************************************/

namespace Server.Items
{
	public class ScoutsBlade19544 : Item
	{
		public ScoutsBlade19544() : base()
		{
			Id = 19544;
			Bonding = 1;
			SellPrice = 15899;
			AvailableClasses = 0x7FFF;
			Model = 32074;
			ObjectClass = 2;
			SubClass = 15;
			Level = 43;
			ReqLevel = 38;
			Name = "Scout's Blade";
			Name2 = "Scout's Blade";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 79498;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1700;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 4;
			Durability = 65;
			Flags = 32768;
			SetDamage( 34 , 65 , Resistances.Armor );
			AgilityBonus = 8;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Scout's Blade)
*
***************************************************************/

namespace Server.Items
{
	public class ScoutsBlade19545 : Item
	{
		public ScoutsBlade19545() : base()
		{
			Id = 19545;
			Bonding = 1;
			SellPrice = 6843;
			AvailableClasses = 0x7FFF;
			Model = 32074;
			ObjectClass = 2;
			SubClass = 15;
			Level = 33;
			ReqLevel = 28;
			Name = "Scout's Blade";
			Name2 = "Scout's Blade";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 34217;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1700;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 4;
			Durability = 65;
			Flags = 32768;
			SetDamage( 25 , 47 , Resistances.Armor );
			AgilityBonus = 7;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Sentinel's Blade)
*
***************************************************************/

namespace Server.Items
{
	public class SentinelsBlade : Item
	{
		public SentinelsBlade() : base()
		{
			Id = 19546;
			Bonding = 1;
			SellPrice = 54922;
			AvailableClasses = 0x7FFF;
			Model = 32075;
			ObjectClass = 2;
			SubClass = 15;
			Level = 63;
			ReqLevel = 58;
			Name = "Sentinel's Blade";
			Name2 = "Sentinel's Blade";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 274611;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1700;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 4;
			Durability = 65;
			Flags = 32768;
			SetDamage( 49 , 92 , Resistances.Armor );
			AgilityBonus = 13;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Sentinel's Blade)
*
***************************************************************/

namespace Server.Items
{
	public class SentinelsBlade19547 : Item
	{
		public SentinelsBlade19547() : base()
		{
			Id = 19547;
			Bonding = 1;
			SellPrice = 32156;
			AvailableClasses = 0x7FFF;
			Model = 32075;
			ObjectClass = 2;
			SubClass = 15;
			Level = 53;
			ReqLevel = 48;
			Name = "Sentinel's Blade";
			Name2 = "Sentinel's Blade";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 160783;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1700;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 4;
			Durability = 65;
			Flags = 32768;
			SetDamage( 41 , 78 , Resistances.Armor );
			AgilityBonus = 11;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Sentinel's Blade)
*
***************************************************************/

namespace Server.Items
{
	public class SentinelsBlade19548 : Item
	{
		public SentinelsBlade19548() : base()
		{
			Id = 19548;
			Bonding = 1;
			SellPrice = 15899;
			AvailableClasses = 0x7FFF;
			Model = 32075;
			ObjectClass = 2;
			SubClass = 15;
			Level = 43;
			ReqLevel = 38;
			Name = "Sentinel's Blade";
			Name2 = "Sentinel's Blade";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 79498;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1700;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 4;
			Durability = 65;
			Flags = 32768;
			SetDamage( 34 , 65 , Resistances.Armor );
			AgilityBonus = 8;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Sentinel's Blade)
*
***************************************************************/

namespace Server.Items
{
	public class SentinelsBlade19549 : Item
	{
		public SentinelsBlade19549() : base()
		{
			Id = 19549;
			Bonding = 1;
			SellPrice = 6843;
			AvailableClasses = 0x7FFF;
			Model = 32075;
			ObjectClass = 2;
			SubClass = 15;
			Level = 33;
			ReqLevel = 28;
			Name = "Sentinel's Blade";
			Name2 = "Sentinel's Blade";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 34217;
			InventoryType = InventoryTypes.MainGauche;
			Delay = 1700;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Sheath = 4;
			Durability = 65;
			Flags = 32768;
			SetDamage( 25 , 47 , Resistances.Armor );
			AgilityBonus = 7;
			StaminaBonus = 3;
		}
	}
}


