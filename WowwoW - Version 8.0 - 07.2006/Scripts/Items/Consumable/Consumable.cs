/**************************************************************
*
*		Made by fulgas (fulgas@gmail.com)
*
*  WowwoW Item Designer ( 2005/8/23 - 10:05:18 )
*
***************************************************************/

using System;
using System.Collections;

/***************************************************************/

/**************************************************************
*
*				(Tough Jerky)
*
***************************************************************/

namespace Server.Items
{
	public class ToughJerky : Item
	{
		public ToughJerky() : base()
		{
			Id = 117;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 2473;
			ObjectClass = 0;
			SubClass = 0;
			Level = 5;
			ReqLevel = 1;
			Name = "Tough Jerky";
			Name2 = "Tough Jerky";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 25;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 433 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Minor Healing Potion)
*
***************************************************************/

namespace Server.Items
{
	public class MinorHealingPotion : Item
	{
		public MinorHealingPotion() : base()
		{
			Id = 118;
			SellPrice = 5;
			AvailableClasses = 0x7FFF;
			Model = 15710;
			ObjectClass = 0;
			SubClass = 0;
			Level = 5;
			ReqLevel = 1;
			Name = "Minor Healing Potion";
			Name2 = "Minor Healing Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 20;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 439 , 0 , -1 , 0 , 4 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Refreshing Spring Water)
*
***************************************************************/

namespace Server.Items
{
	public class RefreshingSpringWater : Item
	{
		public RefreshingSpringWater() : base()
		{
			Id = 159;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 18084;
			ObjectClass = 0;
			SubClass = 0;
			Level = 5;
			ReqLevel = 1;
			Name = "Refreshing Spring Water";
			Name2 = "Refreshing Spring Water";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 25;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 430 , 0 , -1 , 0 , 59 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Dalaran Sharp)
*
***************************************************************/

namespace Server.Items
{
	public class DalaranSharp : Item
	{
		public DalaranSharp() : base()
		{
			Id = 414;
			SellPrice = 6;
			AvailableClasses = 0x7FFF;
			Model = 21904;
			ObjectClass = 0;
			SubClass = 0;
			Level = 15;
			ReqLevel = 5;
			Name = "Dalaran Sharp";
			Name2 = "Dalaran Sharp";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 125;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 434 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Dwarven Mild)
*
***************************************************************/

namespace Server.Items
{
	public class DwarvenMild : Item
	{
		public DwarvenMild() : base()
		{
			Id = 422;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 6352;
			ObjectClass = 0;
			SubClass = 0;
			Level = 25;
			ReqLevel = 15;
			Name = "Dwarven Mild";
			Name2 = "Dwarven Mild";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 500;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 435 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Goretusk Liver Pie)
*
***************************************************************/

namespace Server.Items
{
	public class GoretuskLiverPie : Item
	{
		public GoretuskLiverPie() : base()
		{
			Id = 724;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 6385;
			ObjectClass = 0;
			SubClass = 0;
			Level = 15;
			ReqLevel = 5;
			Name = "Goretusk Liver Pie";
			Name2 = "Goretusk Liver Pie";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 100;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 5005 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Westfall Stew)
*
***************************************************************/

namespace Server.Items
{
	public class WestfallStew : Item
	{
		public WestfallStew() : base()
		{
			Id = 733;
			SellPrice = 100;
			AvailableClasses = 0x7FFF;
			Model = 6428;
			ObjectClass = 0;
			SubClass = 0;
			Level = 15;
			ReqLevel = 5;
			Name = "Westfall Stew";
			Name2 = "Westfall Stew";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 400;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 7;
			SetSpell( 435 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Slitherskin Mackerel)
*
***************************************************************/

namespace Server.Items
{
	public class SlitherskinMackerel : Item
	{
		public SlitherskinMackerel() : base()
		{
			Id = 787;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 24697;
			ObjectClass = 0;
			SubClass = 0;
			Level = 5;
			ReqLevel = 1;
			Name = "Slitherskin Mackerel";
			Name2 = "Slitherskin Mackerel";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 25;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 8;
			SetSpell( 433 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Large Rope Net)
*
***************************************************************/

namespace Server.Items
{
	public class LargeRopeNet : Item
	{
		public LargeRopeNet() : base()
		{
			Id = 835;
			SellPrice = 23;
			AvailableClasses = 0x7FFF;
			Model = 1007;
			ObjectClass = 0;
			SubClass = 0;
			Level = 12;
			ReqLevel = 2;
			Name = "Large Rope Net";
			Name2 = "Large Rope Net";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 95;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = 8;
			SetSpell( 8312 , 0 , -1 , 0 , 29 , 180000 );
		}
	}
}


/**************************************************************
*
*				(Lesser Healing Potion)
*
***************************************************************/

namespace Server.Items
{
	public class LesserHealingPotion : Item
	{
		public LesserHealingPotion() : base()
		{
			Id = 858;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 15711;
			ObjectClass = 0;
			SubClass = 0;
			Level = 13;
			ReqLevel = 3;
			Name = "Lesser Healing Potion";
			Name2 = "Lesser Healing Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 100;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 440 , 0 , -1 , 0 , 4 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Healing Potion)
*
***************************************************************/

namespace Server.Items
{
	public class HealingPotion : Item
	{
		public HealingPotion() : base()
		{
			Id = 929;
			SellPrice = 75;
			AvailableClasses = 0x7FFF;
			Model = 15712;
			ObjectClass = 0;
			SubClass = 0;
			Level = 22;
			ReqLevel = 12;
			Name = "Healing Potion";
			Name2 = "Healing Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 300;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 441 , 0 , -1 , 0 , 4 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Scroll of Strength)
*
***************************************************************/

namespace Server.Items
{
	public class ScrollOfStrength : Item
	{
		public ScrollOfStrength() : base()
		{
			Id = 954;
			SellPrice = 50;
			AvailableClasses = 0x7FFF;
			Model = 3331;
			ObjectClass = 0;
			SubClass = 0;
			Level = 20;
			ReqLevel = 10;
			Name = "Scroll of Strength";
			Name2 = "Scroll of Strength";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 200;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 7;
			SetSpell( 8118 , 0 , -1 , 1000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Scroll of Intellect)
*
***************************************************************/

namespace Server.Items
{
	public class ScrollOfIntellect : Item
	{
		public ScrollOfIntellect() : base()
		{
			Id = 955;
			SellPrice = 37;
			AvailableClasses = 0x7FFF;
			Model = 2616;
			ObjectClass = 0;
			SubClass = 0;
			Level = 15;
			ReqLevel = 5;
			Name = "Scroll of Intellect";
			Name2 = "Scroll of Intellect";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 150;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 7;
			SetSpell( 8096 , 0 , -1 , 1000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Healing Herb)
*
***************************************************************/

namespace Server.Items
{
	public class HealingHerb : Item
	{
		public HealingHerb() : base()
		{
			Id = 961;
			SellPrice = 2;
			AvailableClasses = 0x7FFF;
			Model = 6387;
			ObjectClass = 0;
			SubClass = 0;
			Level = 5;
			Name = "Healing Herb";
			Name2 = "Healing Herb";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 10;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 7;
			SetSpell( 433 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Seasoned Wolf Kabob)
*
***************************************************************/

namespace Server.Items
{
	public class SeasonedWolfKabob : Item
	{
		public SeasonedWolfKabob() : base()
		{
			Id = 1017;
			SellPrice = 100;
			AvailableClasses = 0x7FFF;
			Model = 1116;
			ObjectClass = 0;
			SubClass = 0;
			Level = 25;
			ReqLevel = 15;
			Name = "Seasoned Wolf Kabob";
			Name2 = "Seasoned Wolf Kabob";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 400;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 5006 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Redridge Goulash)
*
***************************************************************/

namespace Server.Items
{
	public class RedridgeGoulash : Item
	{
		public RedridgeGoulash() : base()
		{
			Id = 1082;
			SellPrice = 150;
			AvailableClasses = 0x7FFF;
			Model = 6406;
			ObjectClass = 0;
			SubClass = 0;
			Level = 20;
			ReqLevel = 10;
			Name = "Redridge Goulash";
			Name2 = "Redridge Goulash";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 600;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 5006 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Conjured Bread)
*
***************************************************************/

namespace Server.Items
{
	public class ConjuredBread : Item
	{
		public ConjuredBread() : base()
		{
			Id = 1113;
			AvailableClasses = 0x7FFF;
			Model = 6413;
			ObjectClass = 0;
			SubClass = 0;
			Level = 15;
			ReqLevel = 5;
			Name = "Conjured Bread";
			Name2 = "Conjured Bread";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			Flags = 2;
			SetSpell( 434 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Conjured Rye)
*
***************************************************************/

namespace Server.Items
{
	public class ConjuredRye : Item
	{
		public ConjuredRye() : base()
		{
			Id = 1114;
			AvailableClasses = 0x7FFF;
			Model = 6343;
			ObjectClass = 0;
			SubClass = 0;
			Level = 25;
			ReqLevel = 15;
			Name = "Conjured Rye";
			Name2 = "Conjured Rye";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			Flags = 2;
			SetSpell( 435 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Flash Bundle)
*
***************************************************************/

namespace Server.Items
{
	public class FlashBundle : Item
	{
		public FlashBundle() : base()
		{
			Id = 1127;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 1816;
			ObjectClass = 0;
			SubClass = 0;
			Level = 20;
			Name = "Flash Bundle";
			Name2 = "Flash Bundle";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 100;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
			SetSpell( 2120 , 0 , -1 , 0 , 24 , 60000 );
		}
	}
}


/**************************************************************
*
*				(Oil of Olaf)
*
***************************************************************/

namespace Server.Items
{
	public class OilOfOlaf : Item
	{
		public OilOfOlaf() : base()
		{
			Id = 1177;
			SellPrice = 3;
			AvailableClasses = 0x7FFF;
			Model = 6400;
			ObjectClass = 0;
			SubClass = 0;
			Level = 8;
			Name = "Oil of Olaf";
			Name2 = "Oil of Olaf";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 12;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
			SetSpell( 673 , 0 , -1 , 1000 , 0 , 0 );
		}
	}
}


/**************************************************************
*
*				(Explosive Rocket)
*
***************************************************************/

namespace Server.Items
{
	public class ExplosiveRocket : Item
	{
		public ExplosiveRocket() : base()
		{
			Id = 1178;
			SellPrice = 7;
			AvailableClasses = 0x7FFF;
			Model = 6336;
			ObjectClass = 0;
			SubClass = 0;
			Level = 8;
			Name = "Explosive Rocket";
			Name2 = "Explosive Rocket";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 30;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 1940 , 0 , -1 , 0 , 24 , 60000 );
		}
	}
}


/**************************************************************
*
*				(Ice Cold Milk)
*
***************************************************************/

namespace Server.Items
{
	public class IceColdMilk : Item
	{
		public IceColdMilk() : base()
		{
			Id = 1179;
			SellPrice = 6;
			AvailableClasses = 0x7FFF;
			Model = 18090;
			ObjectClass = 0;
			SubClass = 0;
			Level = 15;
			ReqLevel = 5;
			Name = "Ice Cold Milk";
			Name2 = "Ice Cold Milk";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 125;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 7;
			SetSpell( 431 , 0 , -1 , 0 , 59 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Scroll of Stamina)
*
***************************************************************/

namespace Server.Items
{
	public class ScrollOfStamina : Item
	{
		public ScrollOfStamina() : base()
		{
			Id = 1180;
			SellPrice = 37;
			AvailableClasses = 0x7FFF;
			Model = 1093;
			ObjectClass = 0;
			SubClass = 0;
			Level = 15;
			ReqLevel = 5;
			Name = "Scroll of Stamina";
			Name2 = "Scroll of Stamina";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 150;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 7;
			SetSpell( 8099 , 0 , -1 , 1000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Scroll of Spirit)
*
***************************************************************/

namespace Server.Items
{
	public class ScrollOfSpirit : Item
	{
		public ScrollOfSpirit() : base()
		{
			Id = 1181;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 2616;
			ObjectClass = 0;
			SubClass = 0;
			Level = 10;
			ReqLevel = 1;
			Name = "Scroll of Spirit";
			Name2 = "Scroll of Spirit";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 100;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 7;
			SetSpell( 8112 , 0 , -1 , 1000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Spiked Collar)
*
***************************************************************/

namespace Server.Items
{
	public class SpikedCollar : Item
	{
		public SpikedCollar() : base()
		{
			Id = 1187;
			Bonding = 1;
			SellPrice = 1081;
			AvailableClasses = 0x7FFF;
			Model = 6415;
			ObjectClass = 0;
			SubClass = 0;
			Level = 30;
			ReqLevel = 20;
			Name = "Spiked Collar";
			Name2 = "Spiked Collar";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4325;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = 2;
			SetSpell( 8176 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Bag of Marbles)
*
***************************************************************/

namespace Server.Items
{
	public class BagOfMarbles : Item
	{
		public BagOfMarbles() : base()
		{
			Id = 1191;
			SellPrice = 82;
			AvailableClasses = 0x7FFF;
			Model = 1816;
			ObjectClass = 0;
			SubClass = 0;
			Level = 8;
			Name = "Bag of Marbles";
			Name2 = "Bag of Marbles";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 330;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			SetSpell( 5917 , 0 , -10 , 0 , 29 , 180000 );
		}
	}
}


/**************************************************************
*
*				(Melon Juice)
*
***************************************************************/

namespace Server.Items
{
	public class MelonJuice : Item
	{
		public MelonJuice() : base()
		{
			Id = 1205;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 18078;
			ObjectClass = 0;
			SubClass = 0;
			Level = 25;
			ReqLevel = 15;
			Name = "Melon Juice";
			Name2 = "Melon Juice";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 500;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 7;
			SetSpell( 432 , 0 , -1 , 0 , 59 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Keg of Thunderbrew Lager)
*
***************************************************************/

namespace Server.Items
{
	public class KegOfThunderbrewLager : Item
	{
		public KegOfThunderbrewLager() : base()
		{
			Id = 1262;
			SellPrice = 111;
			AvailableClasses = 0x7FFF;
			Model = 7923;
			ObjectClass = 0;
			SubClass = 0;
			Level = 15;
			Name = "Keg of Thunderbrew Lager";
			Name2 = "Keg of Thunderbrew Lager";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 445;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			SetSpell( 5257 , 0 , -5 , -1 , 59 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Fishliver Oil)
*
***************************************************************/

namespace Server.Items
{
	public class FishliverOil : Item
	{
		public FishliverOil() : base()
		{
			Id = 1322;
			SellPrice = 68;
			AvailableClasses = 0x7FFF;
			Model = 6373;
			ObjectClass = 0;
			SubClass = 0;
			Level = 21;
			Name = "Fishliver Oil";
			Name2 = "Fishliver Oil";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 275;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
			SetSpell( 7396 , 0 , -1 , -1 , 28 , 300000 );
		}
	}
}


/**************************************************************
*
*				(Sauteed Sunfish)
*
***************************************************************/

namespace Server.Items
{
	public class SauteedSunfish : Item
	{
		public SauteedSunfish() : base()
		{
			Id = 1326;
			SellPrice = 10;
			AvailableClasses = 0x7FFF;
			Model = 2661;
			ObjectClass = 0;
			SubClass = 0;
			Level = 15;
			Name = "Sauteed Sunfish";
			Name2 = "Sauteed Sunfish";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 40;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 434 , 0 , -1 , -1 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Magic Candle)
*
***************************************************************/

namespace Server.Items
{
	public class MagicCandle : Item
	{
		public MagicCandle() : base()
		{
			Id = 1399;
			SellPrice = 12;
			AvailableClasses = 0x7FFF;
			Model = 6395;
			ObjectClass = 0;
			SubClass = 0;
			Level = 8;
			ReqLevel = 1;
			Name = "Magic Candle";
			Name2 = "Magic Candle";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 50;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 133 , 0 , -1 , 0 , 24 , 60000 );
		}
	}
}


/**************************************************************
*
*				(Green Tea Leaf)
*
***************************************************************/

namespace Server.Items
{
	public class GreenTeaLeaf : Item
	{
		public GreenTeaLeaf() : base()
		{
			Id = 1401;
			SellPrice = 14;
			AvailableClasses = 0x7FFF;
			Model = 18088;
			ObjectClass = 0;
			SubClass = 0;
			Level = 14;
			ReqLevel = 4;
			Name = "Green Tea Leaf";
			Name2 = "Green Tea Leaf";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 56;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 833 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Glowing Wax Stick)
*
***************************************************************/

namespace Server.Items
{
	public class GlowingWaxStick : Item
	{
		public GlowingWaxStick() : base()
		{
			Id = 1434;
			SellPrice = 43;
			AvailableClasses = 0x7FFF;
			Model = 6383;
			ObjectClass = 0;
			SubClass = 0;
			Level = 7;
			Name = "Glowing Wax Stick";
			Name2 = "Glowing Wax Stick";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 175;
			InventoryType = InventoryTypes.None;
			Delay = 2000;
			Stackable = 20;
			Material = 2;
			SetSpell( 13424 , 0 , -1 , 0 , 29 , 180000 );
		}
	}
}


/**************************************************************
*
*				(Scroll of Agility II)
*
***************************************************************/

namespace Server.Items
{
	public class ScrollOfAgilityII : Item
	{
		public ScrollOfAgilityII() : base()
		{
			Id = 1477;
			SellPrice = 87;
			AvailableClasses = 0x7FFF;
			Model = 3331;
			ObjectClass = 0;
			SubClass = 0;
			Level = 35;
			ReqLevel = 25;
			Name = "Scroll of Agility II";
			Name2 = "Scroll of Agility II";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 350;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 7;
			SetSpell( 8116 , 0 , -1 , 1000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Scroll of Protection II)
*
***************************************************************/

namespace Server.Items
{
	public class ScrollOfProtectionII : Item
	{
		public ScrollOfProtectionII() : base()
		{
			Id = 1478;
			SellPrice = 62;
			AvailableClasses = 0x7FFF;
			Model = 1093;
			ObjectClass = 0;
			SubClass = 0;
			Level = 25;
			ReqLevel = 15;
			Name = "Scroll of Protection II";
			Name2 = "Scroll of Protection II";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 250;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 7;
			SetSpell( 8094 , 0 , -1 , 1000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Conjured Pumpernickel)
*
***************************************************************/

namespace Server.Items
{
	public class ConjuredPumpernickel : Item
	{
		public ConjuredPumpernickel() : base()
		{
			Id = 1487;
			AvailableClasses = 0x7FFF;
			Model = 6344;
			ObjectClass = 0;
			SubClass = 0;
			Level = 35;
			ReqLevel = 25;
			Name = "Conjured Pumpernickel";
			Name2 = "Conjured Pumpernickel";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			Flags = 2;
			SetSpell( 1127 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Moonberry Juice)
*
***************************************************************/

namespace Server.Items
{
	public class MoonberryJuice : Item
	{
		public MoonberryJuice() : base()
		{
			Id = 1645;
			SellPrice = 100;
			AvailableClasses = 0x7FFF;
			Model = 18060;
			ObjectClass = 0;
			SubClass = 0;
			Level = 45;
			ReqLevel = 35;
			Name = "Moonberry Juice";
			Name2 = "Moonberry Juice";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 7;
			SetSpell( 1135 , 0 , -1 , 0 , 59 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Crystal Basilisk Spine)
*
***************************************************************/

namespace Server.Items
{
	public class CrystalBasiliskSpine : Item
	{
		public CrystalBasiliskSpine() : base()
		{
			Id = 1703;
			SellPrice = 81;
			AvailableClasses = 0x7FFF;
			Model = 6349;
			ObjectClass = 0;
			SubClass = 0;
			Level = 35;
			ReqLevel = 25;
			Name = "Crystal Basilisk Spine";
			Name2 = "Crystal Basilisk Spine";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 325;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
			SetSpell( 1138 , 0 , -1 , 0 , 28 , 300000 );
		}
	}
}


/**************************************************************
*
*				(Stormwind Brie)
*
***************************************************************/

namespace Server.Items
{
	public class StormwindBrie : Item
	{
		public StormwindBrie() : base()
		{
			Id = 1707;
			SellPrice = 62;
			AvailableClasses = 0x7FFF;
			Model = 21905;
			ObjectClass = 0;
			SubClass = 0;
			Level = 35;
			ReqLevel = 25;
			Name = "Stormwind Brie";
			Name2 = "Stormwind Brie";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 1127 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Sweet Nectar)
*
***************************************************************/

namespace Server.Items
{
	public class SweetNectar : Item
	{
		public SweetNectar() : base()
		{
			Id = 1708;
			SellPrice = 50;
			AvailableClasses = 0x7FFF;
			Model = 18114;
			ObjectClass = 0;
			SubClass = 0;
			Level = 35;
			ReqLevel = 25;
			Name = "Sweet Nectar";
			Name2 = "Sweet Nectar";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 3;
			SetSpell( 1133 , 0 , -1 , 0 , 59 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Greater Healing Potion)
*
***************************************************************/

namespace Server.Items
{
	public class GreaterHealingPotion : Item
	{
		public GreaterHealingPotion() : base()
		{
			Id = 1710;
			SellPrice = 125;
			AvailableClasses = 0x7FFF;
			Model = 15713;
			ObjectClass = 0;
			SubClass = 0;
			Level = 31;
			ReqLevel = 21;
			Name = "Greater Healing Potion";
			Name2 = "Greater Healing Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 500;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
			SetSpell( 2024 , 0 , -1 , 0 , 4 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Scroll of Stamina II)
*
***************************************************************/

namespace Server.Items
{
	public class ScrollOfStaminaII : Item
	{
		public ScrollOfStaminaII() : base()
		{
			Id = 1711;
			SellPrice = 75;
			AvailableClasses = 0x7FFF;
			Model = 1093;
			ObjectClass = 0;
			SubClass = 0;
			Level = 30;
			ReqLevel = 20;
			Name = "Scroll of Stamina II";
			Name2 = "Scroll of Stamina II";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 300;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 7;
			SetSpell( 8100 , 0 , -1 , 1000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Scroll of Spirit II)
*
***************************************************************/

namespace Server.Items
{
	public class ScrollOfSpiritII : Item
	{
		public ScrollOfSpiritII() : base()
		{
			Id = 1712;
			SellPrice = 62;
			AvailableClasses = 0x7FFF;
			Model = 2616;
			ObjectClass = 0;
			SubClass = 0;
			Level = 25;
			ReqLevel = 15;
			Name = "Scroll of Spirit II";
			Name2 = "Scroll of Spirit II";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 250;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 7;
			SetSpell( 8113 , 0 , -1 , 1000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Restoring Balm)
*
***************************************************************/

namespace Server.Items
{
	public class RestoringBalm : Item
	{
		public RestoringBalm() : base()
		{
			Id = 1970;
			SellPrice = 120;
			AvailableClasses = 0x7FFF;
			Model = 1805;
			ObjectClass = 0;
			SubClass = 0;
			Level = 24;
			Name = "Restoring Balm";
			Name2 = "Restoring Balm";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 480;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 2;
			SetSpell( 8070 , 0 , -1 , -1 , 30 , 180000 );
		}
	}
}


/**************************************************************
*
*				(Darnassian Bleu)
*
***************************************************************/

namespace Server.Items
{
	public class DarnassianBleu : Item
	{
		public DarnassianBleu() : base()
		{
			Id = 2070;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 6353;
			ObjectClass = 0;
			SubClass = 0;
			Level = 5;
			ReqLevel = 1;
			Name = "Darnassian Bleu";
			Name2 = "Darnassian Bleu";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 25;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 433 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Magic Dust)
*
***************************************************************/

namespace Server.Items
{
	public class MagicDust : Item
	{
		public MagicDust() : base()
		{
			Id = 2091;
			SellPrice = 213;
			AvailableClasses = 0x7FFF;
			Model = 6396;
			ObjectClass = 0;
			SubClass = 0;
			Level = 20;
			ReqLevel = 10;
			Name = "Magic Dust";
			Name2 = "Magic Dust";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 855;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
			SetSpell( 1090 , 0 , -1 , 0 , 29 , 180000 );
		}
	}
}


/**************************************************************
*
*				(Conjured Purified Water)
*
***************************************************************/

namespace Server.Items
{
	public class ConjuredPurifiedWater : Item
	{
		public ConjuredPurifiedWater() : base()
		{
			Id = 2136;
			AvailableClasses = 0x7FFF;
			Model = 18085;
			ObjectClass = 0;
			SubClass = 0;
			Level = 25;
			ReqLevel = 15;
			Name = "Conjured Purified Water";
			Name2 = "Conjured Purified Water";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 7;
			Flags = 2;
			SetSpell( 432 , 0 , -1 , 0 , 59 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Haunch of Meat)
*
***************************************************************/

namespace Server.Items
{
	public class HaunchOfMeat : Item
	{
		public HaunchOfMeat() : base()
		{
			Id = 2287;
			SellPrice = 6;
			AvailableClasses = 0x7FFF;
			Model = 2474;
			ObjectClass = 0;
			SubClass = 0;
			Level = 15;
			ReqLevel = 5;
			Name = "Haunch of Meat";
			Name2 = "Haunch of Meat";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 125;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 434 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Conjured Fresh Water)
*
***************************************************************/

namespace Server.Items
{
	public class ConjuredFreshWater : Item
	{
		public ConjuredFreshWater() : base()
		{
			Id = 2288;
			AvailableClasses = 0x7FFF;
			Model = 18084;
			ObjectClass = 0;
			SubClass = 0;
			Level = 15;
			ReqLevel = 5;
			Name = "Conjured Fresh Water";
			Name2 = "Conjured Fresh Water";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 7;
			Flags = 2;
			SetSpell( 431 , 0 , -1 , 0 , 59 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Scroll of Strength II)
*
***************************************************************/

namespace Server.Items
{
	public class ScrollOfStrengthII : Item
	{
		public ScrollOfStrengthII() : base()
		{
			Id = 2289;
			SellPrice = 87;
			AvailableClasses = 0x7FFF;
			Model = 3331;
			ObjectClass = 0;
			SubClass = 0;
			Level = 35;
			ReqLevel = 25;
			Name = "Scroll of Strength II";
			Name2 = "Scroll of Strength II";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 350;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 7;
			Sheath = 1;
			SetSpell( 8119 , 0 , -1 , 1000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Scroll of Intellect II)
*
***************************************************************/

namespace Server.Items
{
	public class ScrollOfIntellectII : Item
	{
		public ScrollOfIntellectII() : base()
		{
			Id = 2290;
			SellPrice = 75;
			AvailableClasses = 0x7FFF;
			Model = 2616;
			ObjectClass = 0;
			SubClass = 0;
			Level = 30;
			ReqLevel = 20;
			Name = "Scroll of Intellect II";
			Name2 = "Scroll of Intellect II";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 300;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 7;
			Sheath = 1;
			SetSpell( 8097 , 0 , -1 , 1000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Light Armor Kit)
*
***************************************************************/

namespace Server.Items
{
	public class LightArmorKit : Item
	{
		public LightArmorKit() : base()
		{
			Id = 2304;
			SellPrice = 15;
			AvailableClasses = 0x7FFF;
			Model = 7450;
			ObjectClass = 0;
			SubClass = 0;
			Level = 5;
			ReqLevel = 1;
			Name = "Light Armor Kit";
			Name2 = "Light Armor Kit";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 60;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 8;
			Flags = 64;
			SetSpell( 2831 , 0 , -1 , 1000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Medium Armor Kit)
*
***************************************************************/

namespace Server.Items
{
	public class MediumArmorKit : Item
	{
		public MediumArmorKit() : base()
		{
			Id = 2313;
			SellPrice = 200;
			AvailableClasses = 0x7FFF;
			Model = 7451;
			ObjectClass = 0;
			SubClass = 0;
			Level = 15;
			ReqLevel = 5;
			Name = "Medium Armor Kit";
			Name2 = "Medium Armor Kit";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 800;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 8;
			Flags = 64;
			SetSpell( 2832 , 0 , -1 , 1000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Elixir of Lion's Strength)
*
***************************************************************/

namespace Server.Items
{
	public class ElixirOfLionsStrength : Item
	{
		public ElixirOfLionsStrength() : base()
		{
			Id = 2454;
			SellPrice = 20;
			AvailableClasses = 0x7FFF;
			Model = 15733;
			ObjectClass = 0;
			SubClass = 0;
			Level = 5;
			ReqLevel = 1;
			Name = "Elixir of Lion's Strength";
			Name2 = "Elixir of Lion's Strength";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 80;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 2367 , 0 , -1 , 0 , 79 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Minor Mana Potion)
*
***************************************************************/

namespace Server.Items
{
	public class MinorManaPotion : Item
	{
		public MinorManaPotion() : base()
		{
			Id = 2455;
			SellPrice = 10;
			AvailableClasses = 0x7FFF;
			Model = 15715;
			ObjectClass = 0;
			SubClass = 0;
			Level = 15;
			ReqLevel = 5;
			Name = "Minor Mana Potion";
			Name2 = "Minor Mana Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 40;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 437 , 0 , -1 , 0 , 4 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Minor Rejuvenation Potion)
*
***************************************************************/

namespace Server.Items
{
	public class MinorRejuvenationPotion : Item
	{
		public MinorRejuvenationPotion() : base()
		{
			Id = 2456;
			SellPrice = 15;
			AvailableClasses = 0x7FFF;
			Model = 2345;
			ObjectClass = 0;
			SubClass = 0;
			Level = 15;
			ReqLevel = 5;
			Name = "Minor Rejuvenation Potion";
			Name2 = "Minor Rejuvenation Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 60;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 2370 , 0 , -1 , 0 , 4 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Elixir of Minor Agility)
*
***************************************************************/

namespace Server.Items
{
	public class ElixirOfMinorAgility : Item
	{
		public ElixirOfMinorAgility() : base()
		{
			Id = 2457;
			SellPrice = 15;
			AvailableClasses = 0x7FFF;
			Model = 15738;
			ObjectClass = 0;
			SubClass = 0;
			Level = 12;
			ReqLevel = 2;
			Name = "Elixir of Minor Agility";
			Name2 = "Elixir of Minor Agility";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 60;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 2374 , 0 , -1 , 0 , 79 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Elixir of Minor Fortitude)
*
***************************************************************/

namespace Server.Items
{
	public class ElixirOfMinorFortitude : Item
	{
		public ElixirOfMinorFortitude() : base()
		{
			Id = 2458;
			SellPrice = 15;
			AvailableClasses = 0x7FFF;
			Model = 15792;
			ObjectClass = 0;
			SubClass = 0;
			Level = 12;
			ReqLevel = 2;
			Name = "Elixir of Minor Fortitude";
			Name2 = "Elixir of Minor Fortitude";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 60;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 2378 , 0 , -1 , 0 , 79 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Swiftness Potion)
*
***************************************************************/

namespace Server.Items
{
	public class SwiftnessPotion : Item
	{
		public SwiftnessPotion() : base()
		{
			Id = 2459;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 15742;
			ObjectClass = 0;
			SubClass = 0;
			Level = 15;
			ReqLevel = 5;
			Name = "Swiftness Potion";
			Name2 = "Swiftness Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 100;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 2379 , 0 , -1 , 0 , 4 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Elixir of Tongues (NYI))
*
***************************************************************/

namespace Server.Items
{
	public class ElixirOfTonguesNYI : Item
	{
		public ElixirOfTonguesNYI() : base()
		{
			Id = 2460;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Description = "This potion has no effect until we put languages in.";
			Model = 6373;
			ObjectClass = 0;
			SubClass = 0;
			Level = 15;
			ReqLevel = 5;
			Name = "Elixir of Tongues (NYI)";
			Name2 = "Elixir of Tongues (NYI)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 100;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
		}
	}
}


/**************************************************************
*
*				(Flask of Port)
*
***************************************************************/

namespace Server.Items
{
	public class FlaskOfPort : Item
	{
		public FlaskOfPort() : base()
		{
			Id = 2593;
			SellPrice = 37;
			AvailableClasses = 0x7FFF;
			Model = 6373;
			ObjectClass = 0;
			SubClass = 0;
			Level = 15;
			Name = "Flask of Port";
			Name2 = "Flask of Port";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 150;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 3;
			SetSpell( 11008 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Flagon of Mead)
*
***************************************************************/

namespace Server.Items
{
	public class FlagonOfMead : Item
	{
		public FlagonOfMead() : base()
		{
			Id = 2594;
			SellPrice = 375;
			AvailableClasses = 0x7FFF;
			Model = 18115;
			ObjectClass = 0;
			SubClass = 0;
			Level = 25;
			Name = "Flagon of Mead";
			Name2 = "Flagon of Mead";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1500;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 3;
			SetSpell( 11009 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Jug of Bourbon)
*
***************************************************************/

namespace Server.Items
{
	public class JugOfBourbon : Item
	{
		public JugOfBourbon() : base()
		{
			Id = 2595;
			SellPrice = 500;
			AvailableClasses = 0x7FFF;
			Model = 7921;
			ObjectClass = 0;
			SubClass = 0;
			Level = 35;
			Name = "Jug of Bourbon";
			Name2 = "Jug of Bourbon";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 11009 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Skin of Dwarven Stout)
*
***************************************************************/

namespace Server.Items
{
	public class SkinOfDwarvenStout : Item
	{
		public SkinOfDwarvenStout() : base()
		{
			Id = 2596;
			SellPrice = 30;
			AvailableClasses = 0x7FFF;
			Model = 18085;
			ObjectClass = 0;
			SubClass = 0;
			Level = 15;
			Name = "Skin of Dwarven Stout";
			Name2 = "Skin of Dwarven Stout";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 120;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 11008 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Jungle Remedy)
*
***************************************************************/

namespace Server.Items
{
	public class JungleRemedy : Item
	{
		public JungleRemedy() : base()
		{
			Id = 2633;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 2533;
			ObjectClass = 0;
			SubClass = 0;
			Level = 32;
			ReqLevel = 22;
			Name = "Jungle Remedy";
			Name2 = "Jungle Remedy";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 100;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 7;
			SetSpell( 3592 , 0 , -1 , 0 , 4 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Charred Wolf Meat)
*
***************************************************************/

namespace Server.Items
{
	public class CharredWolfMeat : Item
	{
		public CharredWolfMeat() : base()
		{
			Id = 2679;
			SellPrice = 5;
			AvailableClasses = 0x7FFF;
			Model = 2474;
			ObjectClass = 0;
			SubClass = 0;
			Level = 5;
			ReqLevel = 1;
			Name = "Charred Wolf Meat";
			Name2 = "Charred Wolf Meat";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 20;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 433 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Spiced Wolf Meat)
*
***************************************************************/

namespace Server.Items
{
	public class SpicedWolfMeat : Item
	{
		public SpicedWolfMeat() : base()
		{
			Id = 2680;
			SellPrice = 10;
			AvailableClasses = 0x7FFF;
			Model = 25468;
			ObjectClass = 0;
			SubClass = 0;
			Level = 7;
			ReqLevel = 1;
			Name = "Spiced Wolf Meat";
			Name2 = "Spiced Wolf Meat";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 40;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 5004 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Roasted Boar Meat)
*
***************************************************************/

namespace Server.Items
{
	public class RoastedBoarMeat : Item
	{
		public RoastedBoarMeat() : base()
		{
			Id = 2681;
			SellPrice = 6;
			AvailableClasses = 0x7FFF;
			Model = 2474;
			ObjectClass = 0;
			SubClass = 0;
			Level = 7;
			ReqLevel = 1;
			Name = "Roasted Boar Meat";
			Name2 = "Roasted Boar Meat";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 24;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 433 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Cooked Crab Claw)
*
***************************************************************/

namespace Server.Items
{
	public class CookedCrabClaw : Item
	{
		public CookedCrabClaw() : base()
		{
			Id = 2682;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 2627;
			ObjectClass = 0;
			SubClass = 0;
			Level = 15;
			ReqLevel = 5;
			Name = "Cooked Crab Claw";
			Name2 = "Cooked Crab Claw";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 100;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 2639 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Crab Cake)
*
***************************************************************/

namespace Server.Items
{
	public class CrabCake : Item
	{
		public CrabCake() : base()
		{
			Id = 2683;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 6345;
			ObjectClass = 0;
			SubClass = 0;
			Level = 15;
			ReqLevel = 5;
			Name = "Crab Cake";
			Name2 = "Crab Cake";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 100;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 5005 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Coyote Steak)
*
***************************************************************/

namespace Server.Items
{
	public class CoyoteSteak : Item
	{
		public CoyoteSteak() : base()
		{
			Id = 2684;
			SellPrice = 20;
			AvailableClasses = 0x7FFF;
			Model = 25468;
			ObjectClass = 0;
			SubClass = 0;
			Level = 15;
			ReqLevel = 5;
			Name = "Coyote Steak";
			Name2 = "Coyote Steak";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 80;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 5005 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Succulent Pork Ribs)
*
***************************************************************/

namespace Server.Items
{
	public class SucculentPorkRibs : Item
	{
		public SucculentPorkRibs() : base()
		{
			Id = 2685;
			SellPrice = 75;
			AvailableClasses = 0x7FFF;
			Model = 2473;
			ObjectClass = 0;
			SubClass = 0;
			Level = 20;
			ReqLevel = 10;
			Name = "Succulent Pork Ribs";
			Name2 = "Succulent Pork Ribs";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 300;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 435 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Thunder Ale)
*
***************************************************************/

namespace Server.Items
{
	public class ThunderAle : Item
	{
		public ThunderAle() : base()
		{
			Id = 2686;
			SellPrice = 12;
			AvailableClasses = 0x7FFF;
			Model = 18117;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			ReqLevel = 1;
			Name = "Thunder Ale";
			Name2 = "Thunder Ale";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 50;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 3;
			SetSpell( 11007 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Dry Pork Ribs)
*
***************************************************************/

namespace Server.Items
{
	public class DryPorkRibs : Item
	{
		public DryPorkRibs() : base()
		{
			Id = 2687;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 21327;
			ObjectClass = 0;
			SubClass = 0;
			Level = 15;
			ReqLevel = 5;
			Name = "Dry Pork Ribs";
			Name2 = "Dry Pork Ribs";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 100;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 5005 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Bottle of Pinot Noir)
*
***************************************************************/

namespace Server.Items
{
	public class BottleOfPinotNoir : Item
	{
		public BottleOfPinotNoir() : base()
		{
			Id = 2723;
			SellPrice = 12;
			AvailableClasses = 0x7FFF;
			Model = 18079;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			ReqLevel = 1;
			Name = "Bottle of Pinot Noir";
			Name2 = "Bottle of Pinot Noir";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 50;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 3;
			SetSpell( 11007 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Beer Basted Boar Ribs)
*
***************************************************************/

namespace Server.Items
{
	public class BeerBastedBoarRibs : Item
	{
		public BeerBastedBoarRibs() : base()
		{
			Id = 2888;
			SellPrice = 10;
			AvailableClasses = 0x7FFF;
			Model = 21327;
			ObjectClass = 0;
			SubClass = 0;
			Level = 8;
			ReqLevel = 1;
			Name = "Beer Basted Boar Ribs";
			Name2 = "Beer Basted Boar Ribs";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 40;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 5004 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Deadly Poison)
*
***************************************************************/

namespace Server.Items
{
	public class DeadlyPoison : Item
	{
		public DeadlyPoison() : base()
		{
			Id = 2892;
			SellPrice = 30;
			AvailableClasses = 0x08;
			Model = 13707;
			ObjectClass = 0;
			SubClass = 0;
			Level = 30;
			ReqLevel = 30;
			Name = "Deadly Poison";
			Name2 = "Deadly Poison";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 120;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 3;
			Flags = 64;
			SetSpell( 2823 , 0 , -1 , 0 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Deadly Poison II)
*
***************************************************************/

namespace Server.Items
{
	public class DeadlyPoisonII : Item
	{
		public DeadlyPoisonII() : base()
		{
			Id = 2893;
			SellPrice = 55;
			AvailableClasses = 0x08;
			Model = 13707;
			ObjectClass = 0;
			SubClass = 0;
			Level = 38;
			ReqLevel = 38;
			Name = "Deadly Poison II";
			Name2 = "Deadly Poison II";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 220;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 3;
			Flags = 64;
			SetSpell( 2824 , 0 , -1 , 0 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Rhapsody Malt)
*
***************************************************************/

namespace Server.Items
{
	public class RhapsodyMalt : Item
	{
		public RhapsodyMalt() : base()
		{
			Id = 2894;
			SellPrice = 12;
			AvailableClasses = 0x7FFF;
			Model = 18117;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			ReqLevel = 1;
			Name = "Rhapsody Malt";
			Name2 = "Rhapsody Malt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 50;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
			SetSpell( 11007 , 0 , -1 , 0 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Scroll of Agility)
*
***************************************************************/

namespace Server.Items
{
	public class ScrollOfAgility : Item
	{
		public ScrollOfAgility() : base()
		{
			Id = 3012;
			SellPrice = 50;
			AvailableClasses = 0x7FFF;
			Model = 3331;
			ObjectClass = 0;
			SubClass = 0;
			Level = 20;
			ReqLevel = 10;
			Name = "Scroll of Agility";
			Name2 = "Scroll of Agility";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 200;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
			SetSpell( 8115 , 0 , -1 , 1000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Scroll of Protection)
*
***************************************************************/

namespace Server.Items
{
	public class ScrollOfProtection : Item
	{
		public ScrollOfProtection() : base()
		{
			Id = 3013;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 1093;
			ObjectClass = 0;
			SubClass = 0;
			Level = 10;
			ReqLevel = 1;
			Name = "Scroll of Protection";
			Name2 = "Scroll of Protection";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 100;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
			SetSpell( 8091 , 0 , -1 , 1000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Mug of Shimmer Stout)
*
***************************************************************/

namespace Server.Items
{
	public class MugOfShimmerStout : Item
	{
		public MugOfShimmerStout() : base()
		{
			Id = 3087;
			SellPrice = 11;
			AvailableClasses = 0x7FFF;
			Model = 18115;
			ObjectClass = 0;
			SubClass = 0;
			Level = 15;
			Name = "Mug of Shimmer Stout";
			Name2 = "Mug of Shimmer Stout";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 45;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
			Language = 7;
			SetSpell( 437 , 0 , -1 , -1 , 4 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Blood Sausage)
*
***************************************************************/

namespace Server.Items
{
	public class BloodSausage : Item
	{
		public BloodSausage() : base()
		{
			Id = 3220;
			SellPrice = 40;
			AvailableClasses = 0x7FFF;
			Model = 25469;
			ObjectClass = 0;
			SubClass = 0;
			Level = 15;
			ReqLevel = 5;
			Name = "Blood Sausage";
			Name2 = "Blood Sausage";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 160;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 5005 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Weak Troll's Blood Potion)
*
***************************************************************/

namespace Server.Items
{
	public class WeakTrollsBloodPotion : Item
	{
		public WeakTrollsBloodPotion() : base()
		{
			Id = 3382;
			SellPrice = 10;
			AvailableClasses = 0x7FFF;
			Model = 15734;
			ObjectClass = 0;
			SubClass = 0;
			Level = 8;
			ReqLevel = 1;
			Name = "Weak Troll's Blood Potion";
			Name2 = "Weak Troll's Blood Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 40;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 3219 , 0 , -1 , 0 , 79 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Elixir of Wisdom)
*
***************************************************************/

namespace Server.Items
{
	public class ElixirOfWisdom : Item
	{
		public ElixirOfWisdom() : base()
		{
			Id = 3383;
			SellPrice = 100;
			AvailableClasses = 0x7FFF;
			Model = 15745;
			ObjectClass = 0;
			SubClass = 0;
			Level = 20;
			ReqLevel = 10;
			Name = "Elixir of Wisdom";
			Name2 = "Elixir of Wisdom";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 400;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 3166 , 0 , -1 , 0 , 79 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Minor Magic Resistance Potion)
*
***************************************************************/

namespace Server.Items
{
	public class MinorMagicResistancePotion : Item
	{
		public MinorMagicResistancePotion() : base()
		{
			Id = 3384;
			SellPrice = 20;
			AvailableClasses = 0x7FFF;
			Model = 292;
			ObjectClass = 0;
			SubClass = 0;
			Level = 22;
			ReqLevel = 12;
			Name = "Minor Magic Resistance Potion";
			Name2 = "Minor Magic Resistance Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 80;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 2380 , 0 , -1 , 0 , 4 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Lesser Mana Potion)
*
***************************************************************/

namespace Server.Items
{
	public class LesserManaPotion : Item
	{
		public LesserManaPotion() : base()
		{
			Id = 3385;
			SellPrice = 30;
			AvailableClasses = 0x7FFF;
			Model = 15716;
			ObjectClass = 0;
			SubClass = 0;
			Level = 24;
			ReqLevel = 14;
			Name = "Lesser Mana Potion";
			Name2 = "Lesser Mana Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 120;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 438 , 0 , -1 , 0 , 4 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Elixir of Poison Resistance)
*
***************************************************************/

namespace Server.Items
{
	public class ElixirOfPoisonResistance : Item
	{
		public ElixirOfPoisonResistance() : base()
		{
			Id = 3386;
			SellPrice = 35;
			AvailableClasses = 0x7FFF;
			Model = 15750;
			ObjectClass = 0;
			SubClass = 0;
			Level = 24;
			ReqLevel = 14;
			Name = "Elixir of Poison Resistance";
			Name2 = "Elixir of Poison Resistance";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 140;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 6513 , 0 , -1 , 0 , 79 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Limited Invulnerability Potion)
*
***************************************************************/

namespace Server.Items
{
	public class LimitedInvulnerabilityPotion : Item
	{
		public LimitedInvulnerabilityPotion() : base()
		{
			Id = 3387;
			SellPrice = 30;
			AvailableClasses = 0x7FFF;
			Model = 24213;
			ObjectClass = 0;
			SubClass = 0;
			Level = 50;
			ReqLevel = 45;
			Name = "Limited Invulnerability Potion";
			Name2 = "Limited Invulnerability Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 120;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 3169 , 0 , -1 , 0 , 4 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Strong Troll's Blood Potion)
*
***************************************************************/

namespace Server.Items
{
	public class StrongTrollsBloodPotion : Item
	{
		public StrongTrollsBloodPotion() : base()
		{
			Id = 3388;
			SellPrice = 40;
			AvailableClasses = 0x7FFF;
			Model = 15770;
			ObjectClass = 0;
			SubClass = 0;
			Level = 25;
			ReqLevel = 15;
			Name = "Strong Troll's Blood Potion";
			Name2 = "Strong Troll's Blood Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 160;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 3222 , 0 , -1 , 0 , 79 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Elixir of Defense)
*
***************************************************************/

namespace Server.Items
{
	public class ElixirOfDefense : Item
	{
		public ElixirOfDefense() : base()
		{
			Id = 3389;
			SellPrice = 40;
			AvailableClasses = 0x7FFF;
			Model = 15773;
			ObjectClass = 0;
			SubClass = 0;
			Level = 26;
			ReqLevel = 16;
			Name = "Elixir of Defense";
			Name2 = "Elixir of Defense";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 160;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 3220 , 0 , -1 , 0 , 79 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Elixir of Lesser Agility)
*
***************************************************************/

namespace Server.Items
{
	public class ElixirOfLesserAgility : Item
	{
		public ElixirOfLesserAgility() : base()
		{
			Id = 3390;
			SellPrice = 35;
			AvailableClasses = 0x7FFF;
			Model = 15787;
			ObjectClass = 0;
			SubClass = 0;
			Level = 28;
			ReqLevel = 18;
			Name = "Elixir of Lesser Agility";
			Name2 = "Elixir of Lesser Agility";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 140;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 3160 , 0 , -1 , 0 , 79 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Elixir of Ogre's Strength)
*
***************************************************************/

namespace Server.Items
{
	public class ElixirOfOgresStrength : Item
	{
		public ElixirOfOgresStrength() : base()
		{
			Id = 3391;
			SellPrice = 20;
			AvailableClasses = 0x7FFF;
			Model = 15789;
			ObjectClass = 0;
			SubClass = 0;
			Level = 30;
			ReqLevel = 20;
			Name = "Elixir of Ogre's Strength";
			Name2 = "Elixir of Ogre's Strength";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 80;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 3164 , 0 , -1 , 0 , 79 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Slumber Sand)
*
***************************************************************/

namespace Server.Items
{
	public class SlumberSand : Item
	{
		public SlumberSand() : base()
		{
			Id = 3434;
			SellPrice = 3;
			AvailableClasses = 0x7FFF;
			Model = 6371;
			ObjectClass = 0;
			SubClass = 0;
			Level = 7;
			Name = "Slumber Sand";
			Name2 = "Slumber Sand";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 15;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
			SetSpell( 700 , 0 , -1 , -1 , 29 , 180000 );
		}
	}
}


/**************************************************************
*
*				(Senggin Root)
*
***************************************************************/

namespace Server.Items
{
	public class SengginRoot : Item
	{
		public SengginRoot() : base()
		{
			Id = 3448;
			SellPrice = 6;
			AvailableClasses = 0x7FFF;
			Model = 1464;
			ObjectClass = 0;
			SubClass = 0;
			Level = 15;
			Name = "Senggin Root";
			Name2 = "Senggin Root";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 25;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 2639 , 0 , -1 , -1 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Dog Whistle)
*
***************************************************************/

namespace Server.Items
{
	public class DogWhistle : Item
	{
		public DogWhistle() : base()
		{
			Id = 3456;
			Bonding = 1;
			SellPrice = 6375;
			AvailableClasses = 0x7FFF;
			Model = 15798;
			ObjectClass = 0;
			SubClass = 0;
			Level = 30;
			ReqLevel = 25;
			Name = "Dog Whistle";
			Name2 = "Dog Whistle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 25500;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			SetSpell( 9515 , 0 , -3 , 600000 , 94 , 60000 );
		}
	}
}


/**************************************************************
*
*				(Crocolisk Steak)
*
***************************************************************/

namespace Server.Items
{
	public class CrocoliskSteak : Item
	{
		public CrocoliskSteak() : base()
		{
			Id = 3662;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 22194;
			ObjectClass = 0;
			SubClass = 0;
			Level = 15;
			ReqLevel = 5;
			Name = "Crocolisk Steak";
			Name2 = "Crocolisk Steak";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 100;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 5005 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Murloc Fin Soup)
*
***************************************************************/

namespace Server.Items
{
	public class MurlocFinSoup : Item
	{
		public MurlocFinSoup() : base()
		{
			Id = 3663;
			SellPrice = 125;
			AvailableClasses = 0x7FFF;
			Model = 6347;
			ObjectClass = 0;
			SubClass = 0;
			Level = 25;
			ReqLevel = 15;
			Name = "Murloc Fin Soup";
			Name2 = "Murloc Fin Soup";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 500;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 5006 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Crocolisk Gumbo)
*
***************************************************************/

namespace Server.Items
{
	public class CrocoliskGumbo : Item
	{
		public CrocoliskGumbo() : base()
		{
			Id = 3664;
			SellPrice = 100;
			AvailableClasses = 0x7FFF;
			Model = 6347;
			ObjectClass = 0;
			SubClass = 0;
			Level = 25;
			ReqLevel = 15;
			Name = "Crocolisk Gumbo";
			Name2 = "Crocolisk Gumbo";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 400;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 5006 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Curiously Tasty Omelet)
*
***************************************************************/

namespace Server.Items
{
	public class CuriouslyTastyOmelet : Item
	{
		public CuriouslyTastyOmelet() : base()
		{
			Id = 3665;
			SellPrice = 150;
			AvailableClasses = 0x7FFF;
			Model = 18053;
			ObjectClass = 0;
			SubClass = 0;
			Level = 25;
			ReqLevel = 15;
			Name = "Curiously Tasty Omelet";
			Name2 = "Curiously Tasty Omelet";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 600;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 5006 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Gooey Spider Cake)
*
***************************************************************/

namespace Server.Items
{
	public class GooeySpiderCake : Item
	{
		public GooeySpiderCake() : base()
		{
			Id = 3666;
			SellPrice = 100;
			AvailableClasses = 0x7FFF;
			Model = 6342;
			ObjectClass = 0;
			SubClass = 0;
			Level = 25;
			ReqLevel = 15;
			Name = "Gooey Spider Cake";
			Name2 = "Gooey Spider Cake";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 400;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 5006 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Southshore Stout)
*
***************************************************************/

namespace Server.Items
{
	public class SouthshoreStout : Item
	{
		public SouthshoreStout() : base()
		{
			Id = 3703;
			SellPrice = 36;
			AvailableClasses = 0x7FFF;
			Model = 18102;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Southshore Stout";
			Name2 = "Southshore Stout";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 145;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
			Flags = 2048;
			SetSpell( 11008 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Big Bear Steak)
*
***************************************************************/

namespace Server.Items
{
	public class BigBearSteak : Item
	{
		public BigBearSteak() : base()
		{
			Id = 3726;
			SellPrice = 125;
			AvailableClasses = 0x7FFF;
			Model = 22194;
			ObjectClass = 0;
			SubClass = 0;
			Level = 25;
			ReqLevel = 15;
			Name = "Big Bear Steak";
			Name2 = "Big Bear Steak";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 500;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 5006 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Hot Lion Chops)
*
***************************************************************/

namespace Server.Items
{
	public class HotLionChops : Item
	{
		public HotLionChops() : base()
		{
			Id = 3727;
			SellPrice = 125;
			AvailableClasses = 0x7FFF;
			Model = 6327;
			ObjectClass = 0;
			SubClass = 0;
			Level = 25;
			ReqLevel = 15;
			Name = "Hot Lion Chops";
			Name2 = "Hot Lion Chops";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 500;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 5006 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Tasty Lion Steak)
*
***************************************************************/

namespace Server.Items
{
	public class TastyLionSteak : Item
	{
		public TastyLionSteak() : base()
		{
			Id = 3728;
			SellPrice = 300;
			AvailableClasses = 0x7FFF;
			Model = 6419;
			ObjectClass = 0;
			SubClass = 0;
			Level = 30;
			ReqLevel = 20;
			Name = "Tasty Lion Steak";
			Name2 = "Tasty Lion Steak";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1200;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 5007 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Soothing Turtle Bisque)
*
***************************************************************/

namespace Server.Items
{
	public class SoothingTurtleBisque : Item
	{
		public SoothingTurtleBisque() : base()
		{
			Id = 3729;
			SellPrice = 300;
			AvailableClasses = 0x7FFF;
			Model = 6414;
			ObjectClass = 0;
			SubClass = 0;
			Level = 35;
			ReqLevel = 25;
			Name = "Soothing Turtle Bisque";
			Name2 = "Soothing Turtle Bisque";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1200;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 5007 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Mutton Chop)
*
***************************************************************/

namespace Server.Items
{
	public class MuttonChop : Item
	{
		public MuttonChop() : base()
		{
			Id = 3770;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 6350;
			ObjectClass = 0;
			SubClass = 0;
			Level = 25;
			ReqLevel = 15;
			Name = "Mutton Chop";
			Name2 = "Mutton Chop";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 500;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 435 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Wild Hog Shank)
*
***************************************************************/

namespace Server.Items
{
	public class WildHogShank : Item
	{
		public WildHogShank() : base()
		{
			Id = 3771;
			SellPrice = 50;
			AvailableClasses = 0x7FFF;
			Model = 4113;
			ObjectClass = 0;
			SubClass = 0;
			Level = 35;
			ReqLevel = 25;
			Name = "Wild Hog Shank";
			Name2 = "Wild Hog Shank";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 1127 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Conjured Spring Water)
*
***************************************************************/

namespace Server.Items
{
	public class ConjuredSpringWater : Item
	{
		public ConjuredSpringWater() : base()
		{
			Id = 3772;
			AvailableClasses = 0x7FFF;
			Model = 18079;
			ObjectClass = 0;
			SubClass = 0;
			Level = 35;
			ReqLevel = 25;
			Name = "Conjured Spring Water";
			Name2 = "Conjured Spring Water";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 3;
			Flags = 2;
			SetSpell( 1133 , 0 , -1 , 0 , 59 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Crippling Poison)
*
***************************************************************/

namespace Server.Items
{
	public class CripplingPoison : Item
	{
		public CripplingPoison() : base()
		{
			Id = 3775;
			SellPrice = 13;
			AvailableClasses = 0x08;
			Model = 13708;
			ObjectClass = 0;
			SubClass = 0;
			Level = 20;
			ReqLevel = 20;
			Name = "Crippling Poison";
			Name2 = "Crippling Poison";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 52;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 3;
			Flags = 64;
			SetSpell( 3408 , 0 , -1 , 0 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Crippling Poison II)
*
***************************************************************/

namespace Server.Items
{
	public class CripplingPoisonII : Item
	{
		public CripplingPoisonII() : base()
		{
			Id = 3776;
			SellPrice = 175;
			AvailableClasses = 0x08;
			Model = 2947;
			ObjectClass = 0;
			SubClass = 0;
			Level = 50;
			ReqLevel = 50;
			Name = "Crippling Poison II";
			Name2 = "Crippling Poison II";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 700;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 3;
			Flags = 64;
			SetSpell( 11202 , 0 , -1 , 0 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Lesser Invisibility Potion)
*
***************************************************************/

namespace Server.Items
{
	public class LesserInvisibilityPotion : Item
	{
		public LesserInvisibilityPotion() : base()
		{
			Id = 3823;
			SellPrice = 100;
			AvailableClasses = 0x7FFF;
			Model = 2354;
			ObjectClass = 0;
			SubClass = 0;
			Level = 33;
			ReqLevel = 23;
			Name = "Lesser Invisibility Potion";
			Name2 = "Lesser Invisibility Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 400;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 3680 , 0 , -1 , 600000 , 4 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Shadow Oil)
*
***************************************************************/

namespace Server.Items
{
	public class ShadowOil : Item
	{
		public ShadowOil() : base()
		{
			Id = 3824;
			SellPrice = 150;
			AvailableClasses = 0x7FFF;
			Model = 17469;
			ObjectClass = 0;
			SubClass = 0;
			Level = 34;
			ReqLevel = 24;
			Name = "Shadow Oil";
			Name2 = "Shadow Oil";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 600;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			Flags = 64;
			SetSpell( 3594 , 0 , -1 , 1000 , 0 , 0 );
		}
	}
}


/**************************************************************
*
*				(Elixir of Fortitude)
*
***************************************************************/

namespace Server.Items
{
	public class ElixirOfFortitude : Item
	{
		public ElixirOfFortitude() : base()
		{
			Id = 3825;
			SellPrice = 110;
			AvailableClasses = 0x7FFF;
			Model = 15790;
			ObjectClass = 0;
			SubClass = 0;
			Level = 35;
			ReqLevel = 25;
			Name = "Elixir of Fortitude";
			Name2 = "Elixir of Fortitude";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 440;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 3593 , 0 , -1 , 0 , 79 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Mighty Troll's Blood Potion)
*
***************************************************************/

namespace Server.Items
{
	public class MightyTrollsBloodPotion : Item
	{
		public MightyTrollsBloodPotion() : base()
		{
			Id = 3826;
			SellPrice = 105;
			AvailableClasses = 0x7FFF;
			Model = 15793;
			ObjectClass = 0;
			SubClass = 0;
			Level = 36;
			ReqLevel = 26;
			Name = "Mighty Troll's Blood Potion";
			Name2 = "Mighty Troll's Blood Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 420;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 3223 , 0 , -1 , 0 , 79 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Mana Potion)
*
***************************************************************/

namespace Server.Items
{
	public class ManaPotion : Item
	{
		public ManaPotion() : base()
		{
			Id = 3827;
			SellPrice = 120;
			AvailableClasses = 0x7FFF;
			Model = 15717;
			ObjectClass = 0;
			SubClass = 0;
			Level = 32;
			ReqLevel = 22;
			Name = "Mana Potion";
			Name2 = "Mana Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 480;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 2023 , 0 , -1 , 0 , 4 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Elixir of Detect Lesser Invisibility)
*
***************************************************************/

namespace Server.Items
{
	public class ElixirOfDetectLesserInvisibility : Item
	{
		public ElixirOfDetectLesserInvisibility() : base()
		{
			Id = 3828;
			SellPrice = 150;
			AvailableClasses = 0x7FFF;
			Model = 4137;
			ObjectClass = 0;
			SubClass = 0;
			Level = 39;
			ReqLevel = 29;
			Name = "Elixir of Detect Lesser Invisibility";
			Name2 = "Elixir of Detect Lesser Invisibility";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 600;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 6512 , 0 , -1 , 0 , 79 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Frost Oil)
*
***************************************************************/

namespace Server.Items
{
	public class FrostOil : Item
	{
		public FrostOil() : base()
		{
			Id = 3829;
			SellPrice = 150;
			AvailableClasses = 0x7FFF;
			Model = 15794;
			ObjectClass = 0;
			SubClass = 0;
			Level = 40;
			ReqLevel = 30;
			Name = "Frost Oil";
			Name2 = "Frost Oil";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 600;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			Flags = 64;
			SetSpell( 3595 , 0 , -1 , 1000 , 0 , 0 );
		}
	}
}


/**************************************************************
*
*				(Fine Aged Cheddar)
*
***************************************************************/

namespace Server.Items
{
	public class FineAgedCheddar : Item
	{
		public FineAgedCheddar() : base()
		{
			Id = 3927;
			SellPrice = 150;
			AvailableClasses = 0x7FFF;
			Model = 6425;
			ObjectClass = 0;
			SubClass = 0;
			Level = 45;
			ReqLevel = 35;
			Name = "Fine Aged Cheddar";
			Name2 = "Fine Aged Cheddar";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 1129 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Superior Healing Potion)
*
***************************************************************/

namespace Server.Items
{
	public class SuperiorHealingPotion : Item
	{
		public SuperiorHealingPotion() : base()
		{
			Id = 3928;
			SellPrice = 250;
			AvailableClasses = 0x7FFF;
			Model = 15714;
			ObjectClass = 0;
			SubClass = 0;
			Level = 45;
			ReqLevel = 35;
			Name = "Superior Healing Potion";
			Name2 = "Superior Healing Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1000;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
			SetSpell( 4042 , 0 , -1 , 0 , 4 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Heavy Armor Kit)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyArmorKit : Item
	{
		public HeavyArmorKit() : base()
		{
			Id = 4265;
			SellPrice = 650;
			AvailableClasses = 0x7FFF;
			Model = 7452;
			ObjectClass = 0;
			SubClass = 0;
			Level = 30;
			ReqLevel = 20;
			Name = "Heavy Armor Kit";
			Name2 = "Heavy Armor Kit";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2600;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 8;
			Flags = 64;
			SetSpell( 2833 , 0 , -1 , 1000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Scroll of Intellect III)
*
***************************************************************/

namespace Server.Items
{
	public class ScrollOfIntellectIII : Item
	{
		public ScrollOfIntellectIII() : base()
		{
			Id = 4419;
			SellPrice = 112;
			AvailableClasses = 0x7FFF;
			Model = 2616;
			ObjectClass = 0;
			SubClass = 0;
			Level = 45;
			ReqLevel = 35;
			Name = "Scroll of Intellect III";
			Name2 = "Scroll of Intellect III";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 450;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 7;
			Sheath = 1;
			SetSpell( 8098 , 0 , -1 , 1000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Scroll of Protection III)
*
***************************************************************/

namespace Server.Items
{
	public class ScrollOfProtectionIII : Item
	{
		public ScrollOfProtectionIII() : base()
		{
			Id = 4421;
			SellPrice = 100;
			AvailableClasses = 0x7FFF;
			Model = 1093;
			ObjectClass = 0;
			SubClass = 0;
			Level = 40;
			ReqLevel = 30;
			Name = "Scroll of Protection III";
			Name2 = "Scroll of Protection III";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 400;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 7;
			SetSpell( 8095 , 0 , -1 , 1000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Scroll of Stamina III)
*
***************************************************************/

namespace Server.Items
{
	public class ScrollOfStaminaIII : Item
	{
		public ScrollOfStaminaIII() : base()
		{
			Id = 4422;
			SellPrice = 112;
			AvailableClasses = 0x7FFF;
			Model = 1093;
			ObjectClass = 0;
			SubClass = 0;
			Level = 45;
			ReqLevel = 35;
			Name = "Scroll of Stamina III";
			Name2 = "Scroll of Stamina III";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 450;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 7;
			SetSpell( 8101 , 0 , -1 , 1000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Scroll of Spirit III)
*
***************************************************************/

namespace Server.Items
{
	public class ScrollOfSpiritIII : Item
	{
		public ScrollOfSpiritIII() : base()
		{
			Id = 4424;
			SellPrice = 100;
			AvailableClasses = 0x7FFF;
			Model = 2616;
			ObjectClass = 0;
			SubClass = 0;
			Level = 40;
			ReqLevel = 30;
			Name = "Scroll of Spirit III";
			Name2 = "Scroll of Spirit III";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 400;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 7;
			SetSpell( 8114 , 0 , -1 , 1000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Scroll of Agility III)
*
***************************************************************/

namespace Server.Items
{
	public class ScrollOfAgilityIII : Item
	{
		public ScrollOfAgilityIII() : base()
		{
			Id = 4425;
			SellPrice = 125;
			AvailableClasses = 0x7FFF;
			Model = 3331;
			ObjectClass = 0;
			SubClass = 0;
			Level = 50;
			ReqLevel = 40;
			Name = "Scroll of Agility III";
			Name2 = "Scroll of Agility III";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 500;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 7;
			SetSpell( 8117 , 0 , -1 , 1000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Scroll of Strength III)
*
***************************************************************/

namespace Server.Items
{
	public class ScrollOfStrengthIII : Item
	{
		public ScrollOfStrengthIII() : base()
		{
			Id = 4426;
			SellPrice = 125;
			AvailableClasses = 0x7FFF;
			Model = 3331;
			ObjectClass = 0;
			SubClass = 0;
			Level = 50;
			ReqLevel = 40;
			Name = "Scroll of Strength III";
			Name2 = "Scroll of Strength III";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 500;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 7;
			SetSpell( 8120 , 0 , -1 , 1000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Barbecued Buzzard Wing)
*
***************************************************************/

namespace Server.Items
{
	public class BarbecuedBuzzardWing : Item
	{
		public BarbecuedBuzzardWing() : base()
		{
			Id = 4457;
			SellPrice = 300;
			AvailableClasses = 0x7FFF;
			Model = 6327;
			ObjectClass = 0;
			SubClass = 0;
			Level = 35;
			ReqLevel = 25;
			Name = "Barbecued Buzzard Wing";
			Name2 = "Barbecued Buzzard Wing";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1200;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 5007 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Burning Charm)
*
***************************************************************/

namespace Server.Items
{
	public class BurningCharm : Item
	{
		public BurningCharm() : base()
		{
			Id = 4479;
			SellPrice = 178;
			AvailableClasses = 0x7FFF;
			Model = 6337;
			ObjectClass = 0;
			SubClass = 0;
			Level = 35;
			ReqLevel = 25;
			Name = "Burning Charm";
			Name2 = "Burning Charm";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 715;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
			SetSpell( 4132 , 0 , -1 , 10000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Thundering Charm)
*
***************************************************************/

namespace Server.Items
{
	public class ThunderingCharm : Item
	{
		public ThunderingCharm() : base()
		{
			Id = 4480;
			SellPrice = 185;
			AvailableClasses = 0x7FFF;
			Model = 6424;
			ObjectClass = 0;
			SubClass = 0;
			Level = 35;
			ReqLevel = 25;
			Name = "Thundering Charm";
			Name2 = "Thundering Charm";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 740;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
			SetSpell( 4131 , 0 , -1 , 10000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Cresting Charm)
*
***************************************************************/

namespace Server.Items
{
	public class CrestingCharm : Item
	{
		public CrestingCharm() : base()
		{
			Id = 4481;
			SellPrice = 176;
			AvailableClasses = 0x7FFF;
			Model = 6346;
			ObjectClass = 0;
			SubClass = 0;
			Level = 35;
			ReqLevel = 25;
			Name = "Cresting Charm";
			Name2 = "Cresting Charm";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 705;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
			SetSpell( 4130 , 0 , -1 , 10000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Shiny Red Apple)
*
***************************************************************/

namespace Server.Items
{
	public class ShinyRedApple : Item
	{
		public ShinyRedApple() : base()
		{
			Id = 4536;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 6410;
			ObjectClass = 0;
			SubClass = 0;
			Level = 5;
			ReqLevel = 1;
			Name = "Shiny Red Apple";
			Name2 = "Shiny Red Apple";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 25;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 433 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Tel'Abim Banana)
*
***************************************************************/

namespace Server.Items
{
	public class TelAbimBanana : Item
	{
		public TelAbimBanana() : base()
		{
			Id = 4537;
			SellPrice = 6;
			AvailableClasses = 0x7FFF;
			Model = 6420;
			ObjectClass = 0;
			SubClass = 0;
			Level = 15;
			ReqLevel = 5;
			Name = "Tel'Abim Banana";
			Name2 = "Tel'Abim Banana";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 125;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 434 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Snapvine Watermelon)
*
***************************************************************/

namespace Server.Items
{
	public class SnapvineWatermelon : Item
	{
		public SnapvineWatermelon() : base()
		{
			Id = 4538;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 4781;
			ObjectClass = 0;
			SubClass = 0;
			Level = 25;
			ReqLevel = 15;
			Name = "Snapvine Watermelon";
			Name2 = "Snapvine Watermelon";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 500;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 435 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Goldenbark Apple)
*
***************************************************************/

namespace Server.Items
{
	public class GoldenbarkApple : Item
	{
		public GoldenbarkApple() : base()
		{
			Id = 4539;
			SellPrice = 50;
			AvailableClasses = 0x7FFF;
			Model = 7856;
			ObjectClass = 0;
			SubClass = 0;
			Level = 35;
			ReqLevel = 25;
			Name = "Goldenbark Apple";
			Name2 = "Goldenbark Apple";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 1127 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Tough Hunk of Bread)
*
***************************************************************/

namespace Server.Items
{
	public class ToughHunkOfBread : Item
	{
		public ToughHunkOfBread() : base()
		{
			Id = 4540;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 6399;
			ObjectClass = 0;
			SubClass = 0;
			Level = 5;
			ReqLevel = 1;
			Name = "Tough Hunk of Bread";
			Name2 = "Tough Hunk of Bread";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 25;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 433 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Freshly Baked Bread)
*
***************************************************************/

namespace Server.Items
{
	public class FreshlyBakedBread : Item
	{
		public FreshlyBakedBread() : base()
		{
			Id = 4541;
			SellPrice = 6;
			AvailableClasses = 0x7FFF;
			Model = 6343;
			ObjectClass = 0;
			SubClass = 0;
			Level = 15;
			ReqLevel = 5;
			Name = "Freshly Baked Bread";
			Name2 = "Freshly Baked Bread";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 125;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 434 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Moist Cornbread)
*
***************************************************************/

namespace Server.Items
{
	public class MoistCornbread : Item
	{
		public MoistCornbread() : base()
		{
			Id = 4542;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 6344;
			ObjectClass = 0;
			SubClass = 0;
			Level = 25;
			ReqLevel = 15;
			Name = "Moist Cornbread";
			Name2 = "Moist Cornbread";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 500;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 435 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Mulgore Spice Bread)
*
***************************************************************/

namespace Server.Items
{
	public class MulgoreSpiceBread : Item
	{
		public MulgoreSpiceBread() : base()
		{
			Id = 4544;
			SellPrice = 50;
			AvailableClasses = 0x7FFF;
			Model = 6399;
			ObjectClass = 0;
			SubClass = 0;
			Level = 35;
			ReqLevel = 25;
			Name = "Mulgore Spice Bread";
			Name2 = "Mulgore Spice Bread";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 1127 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Call of the Raptor)
*
***************************************************************/

namespace Server.Items
{
	public class CallOfTheRaptor : Item
	{
		public CallOfTheRaptor() : base()
		{
			Id = 4546;
			SellPrice = 533;
			AvailableClasses = 0x7FFF;
			Model = 6338;
			ObjectClass = 0;
			SubClass = 0;
			Level = 37;
			Name = "Call of the Raptor";
			Name2 = "Call of the Raptor";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2135;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			SetSpell( 4318 , 0 , -3 , 1000 , 0 , 0 );
		}
	}
}


/**************************************************************
*
*				(Longjaw Mud Snapper)
*
***************************************************************/

namespace Server.Items
{
	public class LongjawMudSnapper : Item
	{
		public LongjawMudSnapper() : base()
		{
			Id = 4592;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 24702;
			ObjectClass = 0;
			SubClass = 0;
			Level = 15;
			ReqLevel = 5;
			Name = "Longjaw Mud Snapper";
			Name2 = "Longjaw Mud Snapper";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 20;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 434 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Bristle Whisker Catfish)
*
***************************************************************/

namespace Server.Items
{
	public class BristleWhiskerCatfish : Item
	{
		public BristleWhiskerCatfish() : base()
		{
			Id = 4593;
			SellPrice = 4;
			AvailableClasses = 0x7FFF;
			Model = 24710;
			ObjectClass = 0;
			SubClass = 0;
			Level = 25;
			ReqLevel = 15;
			Name = "Bristle Whisker Catfish";
			Name2 = "Bristle Whisker Catfish";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 500;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 435 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Rockscale Cod)
*
***************************************************************/

namespace Server.Items
{
	public class RockscaleCod : Item
	{
		public RockscaleCod() : base()
		{
			Id = 4594;
			SellPrice = 6;
			AvailableClasses = 0x7FFF;
			Model = 4823;
			ObjectClass = 0;
			SubClass = 0;
			Level = 35;
			ReqLevel = 25;
			Name = "Rockscale Cod";
			Name2 = "Rockscale Cod";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 1127 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Junglevine Wine)
*
***************************************************************/

namespace Server.Items
{
	public class JunglevineWine : Item
	{
		public JunglevineWine() : base()
		{
			Id = 4595;
			SellPrice = 75;
			AvailableClasses = 0x7FFF;
			Model = 18078;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Junglevine Wine";
			Name2 = "Junglevine Wine";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 300;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 3;
			SetSpell( 11009 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Discolored Healing Potion)
*
***************************************************************/

namespace Server.Items
{
	public class DiscoloredHealingPotion : Item
	{
		public DiscoloredHealingPotion() : base()
		{
			Id = 4596;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 15736;
			ObjectClass = 0;
			SubClass = 0;
			Level = 15;
			ReqLevel = 5;
			Name = "Discolored Healing Potion";
			Name2 = "Discolored Healing Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 100;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 440 , 0 , -1 , 0 , 4 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Goblin Fishing Pole)
*
***************************************************************/

namespace Server.Items
{
	public class GoblinFishingPole : Item
	{
		public GoblinFishingPole() : base()
		{
			Id = 4598;
			SellPrice = 212;
			AvailableClasses = 0x7FFF;
			Model = 18063;
			ObjectClass = 0;
			SubClass = 0;
			Level = 35;
			Name = "Goblin Fishing Pole";
			Name2 = "Goblin Fishing Pole";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 850;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 8;
			Flags = 64;
			SetSpell( 4062 , 0 , -1 , 0 , 24 , 60000 );
		}
	}
}


/**************************************************************
*
*				(Cured Ham Steak)
*
***************************************************************/

namespace Server.Items
{
	public class CuredHamSteak : Item
	{
		public CuredHamSteak() : base()
		{
			Id = 4599;
			SellPrice = 100;
			AvailableClasses = 0x7FFF;
			Model = 6350;
			ObjectClass = 0;
			SubClass = 0;
			Level = 45;
			ReqLevel = 35;
			Name = "Cured Ham Steak";
			Name2 = "Cured Ham Steak";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 1129 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Cherry Grog)
*
***************************************************************/

namespace Server.Items
{
	public class CherryGrog : Item
	{
		public CherryGrog() : base()
		{
			Id = 4600;
			SellPrice = 85;
			AvailableClasses = 0x7FFF;
			Model = 18119;
			ObjectClass = 0;
			SubClass = 0;
			Level = 35;
			ReqLevel = 25;
			Name = "Cherry Grog";
			Name2 = "Cherry Grog";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 340;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 3;
			SetSpell( 11009 , 0 , -1 , 0 , 59 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Soft Banana Bread)
*
***************************************************************/

namespace Server.Items
{
	public class SoftBananaBread : Item
	{
		public SoftBananaBread() : base()
		{
			Id = 4601;
			SellPrice = 100;
			AvailableClasses = 0x7FFF;
			Model = 6413;
			ObjectClass = 0;
			SubClass = 0;
			Level = 45;
			ReqLevel = 35;
			Name = "Soft Banana Bread";
			Name2 = "Soft Banana Bread";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 1129 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Moon Harvest Pumpkin)
*
***************************************************************/

namespace Server.Items
{
	public class MoonHarvestPumpkin : Item
	{
		public MoonHarvestPumpkin() : base()
		{
			Id = 4602;
			SellPrice = 100;
			AvailableClasses = 0x7FFF;
			Model = 6402;
			ObjectClass = 0;
			SubClass = 0;
			Level = 45;
			ReqLevel = 35;
			Name = "Moon Harvest Pumpkin";
			Name2 = "Moon Harvest Pumpkin";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 1129 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Raw Spotted Yellowtail)
*
***************************************************************/

namespace Server.Items
{
	public class RawSpottedYellowtail : Item
	{
		public RawSpottedYellowtail() : base()
		{
			Id = 4603;
			SellPrice = 4;
			AvailableClasses = 0x7FFF;
			Model = 4811;
			ObjectClass = 0;
			SubClass = 0;
			Level = 45;
			ReqLevel = 35;
			Name = "Raw Spotted Yellowtail";
			Name2 = "Raw Spotted Yellowtail";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 80;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 1127 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Forest Mushroom Cap)
*
***************************************************************/

namespace Server.Items
{
	public class ForestMushroomCap : Item
	{
		public ForestMushroomCap() : base()
		{
			Id = 4604;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 15852;
			ObjectClass = 0;
			SubClass = 0;
			Level = 5;
			ReqLevel = 1;
			Name = "Forest Mushroom Cap";
			Name2 = "Forest Mushroom Cap";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 25;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 433 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Red-speckled Mushroom)
*
***************************************************************/

namespace Server.Items
{
	public class RedSpeckledMushroom : Item
	{
		public RedSpeckledMushroom() : base()
		{
			Id = 4605;
			SellPrice = 6;
			AvailableClasses = 0x7FFF;
			Model = 15853;
			ObjectClass = 0;
			SubClass = 0;
			Level = 15;
			ReqLevel = 5;
			Name = "Red-speckled Mushroom";
			Name2 = "Red-speckled Mushroom";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 125;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 434 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Spongy Morel)
*
***************************************************************/

namespace Server.Items
{
	public class SpongyMorel : Item
	{
		public SpongyMorel() : base()
		{
			Id = 4606;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 15854;
			ObjectClass = 0;
			SubClass = 0;
			Level = 25;
			ReqLevel = 15;
			Name = "Spongy Morel";
			Name2 = "Spongy Morel";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 500;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 435 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Delicious Cave Mold)
*
***************************************************************/

namespace Server.Items
{
	public class DeliciousCaveMold : Item
	{
		public DeliciousCaveMold() : base()
		{
			Id = 4607;
			SellPrice = 50;
			AvailableClasses = 0x7FFF;
			Model = 6355;
			ObjectClass = 0;
			SubClass = 0;
			Level = 35;
			ReqLevel = 25;
			Name = "Delicious Cave Mold";
			Name2 = "Delicious Cave Mold";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 1127 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Raw Black Truffle)
*
***************************************************************/

namespace Server.Items
{
	public class RawBlackTruffle : Item
	{
		public RawBlackTruffle() : base()
		{
			Id = 4608;
			SellPrice = 100;
			AvailableClasses = 0x7FFF;
			Model = 15855;
			ObjectClass = 0;
			SubClass = 0;
			Level = 45;
			ReqLevel = 35;
			Name = "Raw Black Truffle";
			Name2 = "Raw Black Truffle";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 1129 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Lesser Stoneshield Potion)
*
***************************************************************/

namespace Server.Items
{
	public class LesserStoneshieldPotion : Item
	{
		public LesserStoneshieldPotion() : base()
		{
			Id = 4623;
			SellPrice = 375;
			AvailableClasses = 0x7FFF;
			Model = 24215;
			ObjectClass = 0;
			SubClass = 0;
			Level = 43;
			ReqLevel = 33;
			Name = "Lesser Stoneshield Potion";
			Name2 = "Lesser Stoneshield Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1500;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 4941 , 0 , -1 , 0 , 4 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Small Pumpkin)
*
***************************************************************/

namespace Server.Items
{
	public class SmallPumpkin : Item
	{
		public SmallPumpkin() : base()
		{
			Id = 4656;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 6402;
			ObjectClass = 0;
			SubClass = 0;
			Level = 5;
			ReqLevel = 1;
			Name = "Small Pumpkin";
			Name2 = "Small Pumpkin";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 25;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 433 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Enchanted Water)
*
***************************************************************/

namespace Server.Items
{
	public class EnchantedWater : Item
	{
		public EnchantedWater() : base()
		{
			Id = 4791;
			SellPrice = 133;
			AvailableClasses = 0x7FFF;
			Model = 6374;
			ObjectClass = 0;
			SubClass = 0;
			Level = 35;
			ReqLevel = 25;
			Name = "Enchanted Water";
			Name2 = "Enchanted Water";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 535;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 3;
			SetSpell( 1133 , 0 , -1 , 0 , 59 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Really Sticky Glue)
*
***************************************************************/

namespace Server.Items
{
	public class ReallyStickyGlue : Item
	{
		public ReallyStickyGlue() : base()
		{
			Id = 4941;
			SellPrice = 11;
			AvailableClasses = 0x7FFF;
			Model = 1805;
			ObjectClass = 0;
			SubClass = 0;
			Level = 10;
			Name = "Really Sticky Glue";
			Name2 = "Really Sticky Glue";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 45;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 8312 , 0 , -1 , 0 , 29 , 180000 );
		}
	}
}


/**************************************************************
*
*				(Faintly Glowing Skull)
*
***************************************************************/

namespace Server.Items
{
	public class FaintlyGlowingSkull : Item
	{
		public FaintlyGlowingSkull() : base()
		{
			Id = 4945;
			Bonding = 1;
			SellPrice = 37;
			AvailableClasses = 0x7FFF;
			Model = 7099;
			ObjectClass = 0;
			SubClass = 0;
			Level = 9;
			Name = "Faintly Glowing Skull";
			Name2 = "Faintly Glowing Skull";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 150;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			SetSpell( 16375 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Stormstout)
*
***************************************************************/

namespace Server.Items
{
	public class Stormstout : Item
	{
		public Stormstout() : base()
		{
			Id = 4952;
			SellPrice = 63;
			AvailableClasses = 0x7FFF;
			Model = 18099;
			ObjectClass = 0;
			SubClass = 0;
			Level = 15;
			Name = "Stormstout";
			Name2 = "Stormstout";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 255;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
			SetSpell( 5020 , 0 , -1 , 0 , 59 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Trogg Ale)
*
***************************************************************/

namespace Server.Items
{
	public class TroggAle : Item
	{
		public TroggAle() : base()
		{
			Id = 4953;
			SellPrice = 88;
			AvailableClasses = 0x7FFF;
			Model = 18117;
			ObjectClass = 0;
			SubClass = 0;
			Level = 17;
			Name = "Trogg Ale";
			Name2 = "Trogg Ale";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 355;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
			SetSpell( 5021 , 0 , -1 , 0 , 59 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Fertile Bulb)
*
***************************************************************/

namespace Server.Items
{
	public class FertileBulb : Item
	{
		public FertileBulb() : base()
		{
			Id = 5013;
			SellPrice = 38;
			AvailableClasses = 0x7FFF;
			Model = 6376;
			ObjectClass = 0;
			SubClass = 0;
			Level = 15;
			ReqLevel = 5;
			Name = "Fertile Bulb";
			Name2 = "Fertile Bulb";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 152;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
			SetSpell( 5100 , 0 , -1 , 0 , 24 , 60000 );
		}
	}
}


/**************************************************************
*
*				(Red Ribboned Wrapping Paper)
*
***************************************************************/

namespace Server.Items
{
	public class RedRibbonedWrappingPaper : Item
	{
		public RedRibbonedWrappingPaper() : base()
		{
			Id = 5042;
			SellPrice = 12;
			AvailableClasses = 0x7FFF;
			Model = 6405;
			ObjectClass = 0;
			SubClass = 0;
			Level = 5;
			Name = "Red Ribboned Wrapping Paper";
			Name2 = "Red Ribboned Wrapping Paper";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 50;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
			Flags = 512;
		}
	}
}


/**************************************************************
*
*				(Red Ribboned Gift)
*
***************************************************************/

namespace Server.Items
{
	public class RedRibbonedGift : Item
	{
		public RedRibbonedGift() : base()
		{
			Id = 5043;
			AvailableClasses = 0x7FFF;
			Model = 6404;
			ObjectClass = 0;
			SubClass = 0;
			Level = 5;
			Name = "Red Ribboned Gift";
			Name2 = "Red Ribboned Gift";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Flags = 512;
		}
	}
}


/**************************************************************
*
*				(Blue Ribboned Gift)
*
***************************************************************/

namespace Server.Items
{
	public class BlueRibbonedGift : Item
	{
		public BlueRibbonedGift() : base()
		{
			Id = 5044;
			AvailableClasses = 0x7FFF;
			Model = 6329;
			ObjectClass = 0;
			SubClass = 0;
			Level = 5;
			Name = "Blue Ribboned Gift";
			Name2 = "Blue Ribboned Gift";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Flags = 512;
		}
	}
}


/**************************************************************
*
*				(Blue Ribboned Wrapping Paper)
*
***************************************************************/

namespace Server.Items
{
	public class BlueRibbonedWrappingPaper : Item
	{
		public BlueRibbonedWrappingPaper() : base()
		{
			Id = 5048;
			SellPrice = 12;
			AvailableClasses = 0x7FFF;
			Model = 6330;
			ObjectClass = 0;
			SubClass = 0;
			Level = 5;
			Name = "Blue Ribboned Wrapping Paper";
			Name2 = "Blue Ribboned Wrapping Paper";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 50;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
			Flags = 512;
		}
	}
}


/**************************************************************
*
*				(Ripe Watermelon)
*
***************************************************************/

namespace Server.Items
{
	public class RipeWatermelon : Item
	{
		public RipeWatermelon() : base()
		{
			Id = 5057;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 6390;
			ObjectClass = 0;
			SubClass = 0;
			Level = 5;
			ReqLevel = 1;
			Name = "Ripe Watermelon";
			Name2 = "Ripe Watermelon";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 25;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 433 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Fissure Plant)
*
***************************************************************/

namespace Server.Items
{
	public class FissurePlant : Item
	{
		public FissurePlant() : base()
		{
			Id = 5066;
			SellPrice = 21;
			AvailableClasses = 0x7FFF;
			Model = 6377;
			ObjectClass = 0;
			SubClass = 0;
			Level = 15;
			ReqLevel = 5;
			Name = "Fissure Plant";
			Name2 = "Fissure Plant";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 85;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
			SetSpell( 434 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Rainbow Fin Albacore)
*
***************************************************************/

namespace Server.Items
{
	public class RainbowFinAlbacore : Item
	{
		public RainbowFinAlbacore() : base()
		{
			Id = 5095;
			SellPrice = 3;
			AvailableClasses = 0x7FFF;
			Model = 24704;
			ObjectClass = 0;
			SubClass = 0;
			Level = 15;
			ReqLevel = 5;
			Name = "Rainbow Fin Albacore";
			Name2 = "Rainbow Fin Albacore";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 125;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 434 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Sprouted Frond)
*
***************************************************************/

namespace Server.Items
{
	public class SproutedFrond : Item
	{
		public SproutedFrond() : base()
		{
			Id = 5205;
			SellPrice = 31;
			AvailableClasses = 0x7FFF;
			Model = 6416;
			ObjectClass = 0;
			SubClass = 0;
			Level = 15;
			ReqLevel = 5;
			Name = "Sprouted Frond";
			Name2 = "Sprouted Frond";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 125;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 3;
			SetSpell( 2052 , 0 , -1 , 0 , 30 , 180000 );
		}
	}
}


/**************************************************************
*
*				(Bogling Root)
*
***************************************************************/

namespace Server.Items
{
	public class BoglingRoot : Item
	{
		public BoglingRoot() : base()
		{
			Id = 5206;
			SellPrice = 37;
			AvailableClasses = 0x7FFF;
			Model = 6331;
			ObjectClass = 0;
			SubClass = 0;
			Level = 12;
			Name = "Bogling Root";
			Name2 = "Bogling Root";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 150;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 3;
			SetSpell( 5665 , 0 , -1 , 0 , 102 , 600000 );
		}
	}
}


/**************************************************************
*
*				(Minor Soulstone)
*
***************************************************************/

namespace Server.Items
{
	public class MinorSoulstone : Item
	{
		public MinorSoulstone() : base()
		{
			Id = 5232;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 6009;
			ObjectClass = 0;
			SubClass = 0;
			Level = 18;
			Name = "Minor Soulstone";
			Name2 = "Minor Soulstone";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = 3;
			Flags = 66;
			SetSpell( 20707 , 0 , -1 , 0 , 831 , 1800000 );
		}
	}
}


/**************************************************************
*
*				(Mind-numbing Poison)
*
***************************************************************/

namespace Server.Items
{
	public class MindNumbingPoison : Item
	{
		public MindNumbingPoison() : base()
		{
			Id = 5237;
			SellPrice = 18;
			AvailableClasses = 0x08;
			Model = 13709;
			ObjectClass = 0;
			SubClass = 0;
			Level = 24;
			ReqLevel = 24;
			Name = "Mind-numbing Poison";
			Name2 = "Mind-numbing Poison";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 72;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 3;
			Flags = 64;
			SetSpell( 5761 , 0 , -1 , 0 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Raptor Punch)
*
***************************************************************/

namespace Server.Items
{
	public class RaptorPunch : Item
	{
		public RaptorPunch() : base()
		{
			Id = 5342;
			SellPrice = 88;
			AvailableClasses = 0x7FFF;
			Model = 18099;
			ObjectClass = 0;
			SubClass = 0;
			Level = 18;
			Name = "Raptor Punch";
			Name2 = "Raptor Punch";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 355;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
			SetSpell( 6114 , 0 , -1 , 0 , 59 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Conjured Muffin)
*
***************************************************************/

namespace Server.Items
{
	public class ConjuredMuffin : Item
	{
		public ConjuredMuffin() : base()
		{
			Id = 5349;
			AvailableClasses = 0x7FFF;
			Model = 6342;
			ObjectClass = 0;
			SubClass = 0;
			Level = 5;
			ReqLevel = 1;
			Name = "Conjured Muffin";
			Name2 = "Conjured Muffin";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			Flags = 2;
			SetSpell( 433 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Conjured Water)
*
***************************************************************/

namespace Server.Items
{
	public class ConjuredWater : Item
	{
		public ConjuredWater() : base()
		{
			Id = 5350;
			AvailableClasses = 0x7FFF;
			Model = 18081;
			ObjectClass = 0;
			SubClass = 0;
			Level = 5;
			ReqLevel = 1;
			Name = "Conjured Water";
			Name2 = "Conjured Water";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 7;
			Flags = 2;
			SetSpell( 430 , 0 , -1 , 0 , 59 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Fiery Enchantment)
*
***************************************************************/

namespace Server.Items
{
	public class FieryEnchantment : Item
	{
		public FieryEnchantment() : base()
		{
			Id = 5421;
			SellPrice = 650;
			AvailableClasses = 0x7FFF;
			Model = 7899;
			ObjectClass = 0;
			SubClass = 0;
			Level = 45;
			Name = "Fiery Enchantment";
			Name2 = "Fiery Enchantment";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2600;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = 8;
			Flags = 64;
			SetSpell( 6296 , 0 , -1 , 1000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Severed Voodoo Claw)
*
***************************************************************/

namespace Server.Items
{
	public class SeveredVoodooClaw : Item
	{
		public SeveredVoodooClaw() : base()
		{
			Id = 5457;
			SellPrice = 23;
			AvailableClasses = 0x7FFF;
			Model = 1496;
			ObjectClass = 0;
			SubClass = 0;
			Level = 5;
			Name = "Severed Voodoo Claw";
			Name2 = "Severed Voodoo Claw";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 95;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
			SetSpell( 8277 , 0 , -1 , 0 , 29 , 180000 );
		}
	}
}


/**************************************************************
*
*				(Kaldorei Spider Kabob)
*
***************************************************************/

namespace Server.Items
{
	public class KaldoreiSpiderKabob : Item
	{
		public KaldoreiSpiderKabob() : base()
		{
			Id = 5472;
			SellPrice = 10;
			AvailableClasses = 0x7FFF;
			Model = 25473;
			ObjectClass = 0;
			SubClass = 0;
			Level = 7;
			ReqLevel = 1;
			Name = "Kaldorei Spider Kabob";
			Name2 = "Kaldorei Spider Kabob";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 40;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 5004 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Scorpid Surprise)
*
***************************************************************/

namespace Server.Items
{
	public class ScorpidSurprise : Item
	{
		public ScorpidSurprise() : base()
		{
			Id = 5473;
			SellPrice = 10;
			AvailableClasses = 0x7FFF;
			Model = 7994;
			ObjectClass = 0;
			SubClass = 0;
			Level = 8;
			ReqLevel = 1;
			Name = "Scorpid Surprise";
			Name2 = "Scorpid Surprise";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 40;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 6410 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Roasted Kodo Meat)
*
***************************************************************/

namespace Server.Items
{
	public class RoastedKodoMeat : Item
	{
		public RoastedKodoMeat() : base()
		{
			Id = 5474;
			SellPrice = 9;
			AvailableClasses = 0x7FFF;
			Model = 25481;
			ObjectClass = 0;
			SubClass = 0;
			Level = 10;
			ReqLevel = 1;
			Name = "Roasted Kodo Meat";
			Name2 = "Roasted Kodo Meat";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 36;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 5004 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Fillet of Frenzy)
*
***************************************************************/

namespace Server.Items
{
	public class FilletOfFrenzy : Item
	{
		public FilletOfFrenzy() : base()
		{
			Id = 5476;
			SellPrice = 3;
			AvailableClasses = 0x7FFF;
			Model = 7996;
			ObjectClass = 0;
			SubClass = 0;
			Level = 15;
			ReqLevel = 5;
			Name = "Fillet of Frenzy";
			Name2 = "Fillet of Frenzy";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 12;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 5005 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Strider Stew)
*
***************************************************************/

namespace Server.Items
{
	public class StriderStew : Item
	{
		public StriderStew() : base()
		{
			Id = 5477;
			SellPrice = 18;
			AvailableClasses = 0x7FFF;
			Model = 6406;
			ObjectClass = 0;
			SubClass = 0;
			Level = 15;
			ReqLevel = 5;
			Name = "Strider Stew";
			Name2 = "Strider Stew";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 74;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 5005 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Dig Rat Stew)
*
***************************************************************/

namespace Server.Items
{
	public class DigRatStew : Item
	{
		public DigRatStew() : base()
		{
			Id = 5478;
			SellPrice = 70;
			AvailableClasses = 0x7FFF;
			Model = 557;
			ObjectClass = 0;
			SubClass = 0;
			Level = 20;
			ReqLevel = 10;
			Name = "Dig Rat Stew";
			Name2 = "Dig Rat Stew";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 280;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 435 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Crispy Lizard Tail)
*
***************************************************************/

namespace Server.Items
{
	public class CrispyLizardTail : Item
	{
		public CrispyLizardTail() : base()
		{
			Id = 5479;
			SellPrice = 125;
			AvailableClasses = 0x7FFF;
			Model = 8088;
			ObjectClass = 0;
			SubClass = 0;
			Level = 22;
			ReqLevel = 12;
			Name = "Crispy Lizard Tail";
			Name2 = "Crispy Lizard Tail";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 500;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 5006 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Lean Venison)
*
***************************************************************/

namespace Server.Items
{
	public class LeanVenison : Item
	{
		public LeanVenison() : base()
		{
			Id = 5480;
			SellPrice = 95;
			AvailableClasses = 0x7FFF;
			Model = 25475;
			ObjectClass = 0;
			SubClass = 0;
			Level = 25;
			ReqLevel = 15;
			Name = "Lean Venison";
			Name2 = "Lean Venison";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 380;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 5006 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Healthstone)
*
***************************************************************/

namespace Server.Items
{
	public class Healthstone : Item
	{
		public Healthstone() : base()
		{
			Id = 5509;
			AvailableClasses = 0x7FFF;
			Model = 8026;
			ObjectClass = 0;
			SubClass = 0;
			Level = 34;
			ReqLevel = 24;
			Name = "Healthstone";
			Name2 = "Healthstone";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Flags = 2;
			SetSpell( 5720 , 0 , -1 , 0 , 30 , 180000 );
		}
	}
}


/**************************************************************
*
*				(Greater Healthstone)
*
***************************************************************/

namespace Server.Items
{
	public class GreaterHealthstone : Item
	{
		public GreaterHealthstone() : base()
		{
			Id = 5510;
			AvailableClasses = 0x7FFF;
			Model = 8026;
			ObjectClass = 0;
			SubClass = 0;
			Level = 46;
			ReqLevel = 36;
			Name = "Greater Healthstone";
			Name2 = "Greater Healthstone";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Flags = 2;
			SetSpell( 5723 , 0 , -1 , 0 , 30 , 180000 );
		}
	}
}


/**************************************************************
*
*				(Lesser Healthstone)
*
***************************************************************/

namespace Server.Items
{
	public class LesserHealthstone : Item
	{
		public LesserHealthstone() : base()
		{
			Id = 5511;
			AvailableClasses = 0x7FFF;
			Model = 8026;
			ObjectClass = 0;
			SubClass = 0;
			Level = 22;
			ReqLevel = 12;
			Name = "Lesser Healthstone";
			Name2 = "Lesser Healthstone";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Flags = 2;
			SetSpell( 6263 , 0 , -1 , 0 , 30 , 180000 );
		}
	}
}


/**************************************************************
*
*				(Minor Healthstone)
*
***************************************************************/

namespace Server.Items
{
	public class MinorHealthstone : Item
	{
		public MinorHealthstone() : base()
		{
			Id = 5512;
			AvailableClasses = 0x7FFF;
			Model = 8026;
			ObjectClass = 0;
			SubClass = 0;
			Level = 10;
			ReqLevel = 1;
			Name = "Minor Healthstone";
			Name2 = "Minor Healthstone";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Flags = 2;
			SetSpell( 6262 , 0 , -1 , 0 , 30 , 180000 );
		}
	}
}


/**************************************************************
*
*				(Mana Jade)
*
***************************************************************/

namespace Server.Items
{
	public class ManaJade : Item
	{
		public ManaJade() : base()
		{
			Id = 5513;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 7393;
			ObjectClass = 0;
			SubClass = 0;
			Level = 38;
			ReqLevel = 38;
			Name = "Mana Jade";
			Name2 = "Mana Jade";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Flags = 2;
			SetSpell( 10052 , 0 , -1 , 0 , 100 , 180000 );
		}
	}
}


/**************************************************************
*
*				(Boiled Clams)
*
***************************************************************/

namespace Server.Items
{
	public class BoiledClams : Item
	{
		public BoiledClams() : base()
		{
			Id = 5525;
			SellPrice = 20;
			AvailableClasses = 0x7FFF;
			Model = 8048;
			ObjectClass = 0;
			SubClass = 0;
			Level = 15;
			ReqLevel = 5;
			Name = "Boiled Clams";
			Name2 = "Boiled Clams";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 80;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 5005 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Clam Chowder)
*
***************************************************************/

namespace Server.Items
{
	public class ClamChowder : Item
	{
		public ClamChowder() : base()
		{
			Id = 5526;
			SellPrice = 75;
			AvailableClasses = 0x7FFF;
			Model = 8049;
			ObjectClass = 0;
			SubClass = 0;
			Level = 20;
			ReqLevel = 10;
			Name = "Clam Chowder";
			Name2 = "Clam Chowder";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 300;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 435 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Goblin Deviled Clams)
*
***************************************************************/

namespace Server.Items
{
	public class GoblinDeviledClams : Item
	{
		public GoblinDeviledClams() : base()
		{
			Id = 5527;
			SellPrice = 95;
			AvailableClasses = 0x7FFF;
			Model = 7177;
			ObjectClass = 0;
			SubClass = 0;
			Level = 25;
			ReqLevel = 15;
			Name = "Goblin Deviled Clams";
			Name2 = "Goblin Deviled Clams";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 380;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 5006 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Rage Potion)
*
***************************************************************/

namespace Server.Items
{
	public class RagePotion : Item
	{
		public RagePotion() : base()
		{
			Id = 5631;
			SellPrice = 30;
			AvailableClasses = 0x01;
			Model = 15741;
			ObjectClass = 0;
			SubClass = 0;
			Level = 14;
			ReqLevel = 4;
			Name = "Rage Potion";
			Name2 = "Rage Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 120;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 6612 , 0 , -1 , 0 , 4 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Great Rage Potion)
*
***************************************************************/

namespace Server.Items
{
	public class GreatRagePotion : Item
	{
		public GreatRagePotion() : base()
		{
			Id = 5633;
			SellPrice = 150;
			AvailableClasses = 0x01;
			Model = 15791;
			ObjectClass = 0;
			SubClass = 0;
			Level = 35;
			ReqLevel = 25;
			Name = "Great Rage Potion";
			Name2 = "Great Rage Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 600;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
			SetSpell( 6613 , 0 , -1 , 0 , 4 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Free Action Potion)
*
***************************************************************/

namespace Server.Items
{
	public class FreeActionPotion : Item
	{
		public FreeActionPotion() : base()
		{
			Id = 5634;
			SellPrice = 75;
			AvailableClasses = 0x7FFF;
			Model = 8453;
			ObjectClass = 0;
			SubClass = 0;
			Level = 30;
			ReqLevel = 20;
			Name = "Free Action Potion";
			Name2 = "Free Action Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 300;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 6615 , 0 , -1 , 0 , 4 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Red Fireworks Rocket)
*
***************************************************************/

namespace Server.Items
{
	public class RedFireworksRocket : Item
	{
		public RedFireworksRocket() : base()
		{
			Id = 5740;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 8733;
			ObjectClass = 0;
			SubClass = 0;
			Level = 20;
			Name = "Red Fireworks Rocket";
			Name2 = "Red Fireworks Rocket";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 100;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
			SetSpell( 6668 , 0 , -1 , 1000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Light of Elune)
*
***************************************************************/

namespace Server.Items
{
	public class LightOfElune : Item
	{
		public LightOfElune() : base()
		{
			Id = 5816;
			SellPrice = 405;
			AvailableClasses = 0x7FFF;
			Model = 9058;
			ObjectClass = 0;
			SubClass = 0;
			Level = 25;
			Name = "Light of Elune";
			Name2 = "Light of Elune";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1620;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = 3;
			SetSpell( 6724 , 0 , -1 , 0 , 4 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Poisonous Mushroom)
*
***************************************************************/

namespace Server.Items
{
	public class PoisonousMushroom : Item
	{
		public PoisonousMushroom() : base()
		{
			Id = 5823;
			SellPrice = 5;
			AvailableClasses = 0x7FFF;
			Model = 15856;
			ObjectClass = 0;
			SubClass = 0;
			Level = 15;
			ReqLevel = 5;
			Name = "Poisonous Mushroom";
			Name2 = "Poisonous Mushroom";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 20;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
			SetSpell( 6727 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Party Grenade)
*
***************************************************************/

namespace Server.Items
{
	public class PartyGrenade : Item
	{
		public PartyGrenade() : base()
		{
			Id = 5859;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 9163;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Party Grenade";
			Name2 = "Party Grenade";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 100;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
			Flags = 64;
			SetSpell( 6758 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Super Snuff)
*
***************************************************************/

namespace Server.Items
{
	public class SuperSnuff : Item
	{
		public SuperSnuff() : base()
		{
			Id = 5878;
			SellPrice = 92;
			AvailableClasses = 0x7FFF;
			Model = 8932;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Super Snuff";
			Name2 = "Super Snuff";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 370;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 6902 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Crate With Holes)
*
***************************************************************/

namespace Server.Items
{
	public class CrateWithHoles : Item
	{
		public CrateWithHoles() : base()
		{
			Id = 5880;
			Bonding = 4;
			AvailableClasses = 0x7FFF;
			Model = 9288;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Crate With Holes";
			Name2 = "Crate With Holes";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 6918 , 0 , -5 , 30000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Moist Towelette)
*
***************************************************************/

namespace Server.Items
{
	public class MoistTowelette : Item
	{
		public MoistTowelette() : base()
		{
			Id = 5951;
			SellPrice = 41;
			AvailableClasses = 0x7FFF;
			Model = 9430;
			ObjectClass = 0;
			SubClass = 0;
			Level = 30;
			Name = "Moist Towelette";
			Name2 = "Moist Towelette";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 165;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
			Flags = 64;
			SetSpell( 7108 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Elixir of Water Breathing)
*
***************************************************************/

namespace Server.Items
{
	public class ElixirOfWaterBreathing : Item
	{
		public ElixirOfWaterBreathing() : base()
		{
			Id = 5996;
			SellPrice = 95;
			AvailableClasses = 0x7FFF;
			Model = 4836;
			ObjectClass = 0;
			SubClass = 0;
			Level = 18;
			ReqLevel = 8;
			Name = "Elixir of Water Breathing";
			Name2 = "Elixir of Water Breathing";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 380;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 7178 , 0 , -1 , 0 , 79 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Elixir of Minor Defense)
*
***************************************************************/

namespace Server.Items
{
	public class ElixirOfMinorDefense : Item
	{
		public ElixirOfMinorDefense() : base()
		{
			Id = 5997;
			SellPrice = 5;
			AvailableClasses = 0x7FFF;
			Model = 15732;
			ObjectClass = 0;
			SubClass = 0;
			Level = 5;
			ReqLevel = 1;
			Name = "Elixir of Minor Defense";
			Name2 = "Elixir of Minor Defense";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 20;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 673 , 0 , -1 , 0 , 79 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Giant Clam Scorcho)
*
***************************************************************/

namespace Server.Items
{
	public class GiantClamScorcho : Item
	{
		public GiantClamScorcho() : base()
		{
			Id = 6038;
			SellPrice = 312;
			AvailableClasses = 0x7FFF;
			Model = 9633;
			ObjectClass = 0;
			SubClass = 0;
			Level = 35;
			ReqLevel = 25;
			Name = "Giant Clam Scorcho";
			Name2 = "Giant Clam Scorcho";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1250;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 5007 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Shadow Protection Potion)
*
***************************************************************/

namespace Server.Items
{
	public class ShadowProtectionPotion : Item
	{
		public ShadowProtectionPotion() : base()
		{
			Id = 6048;
			SellPrice = 100;
			AvailableClasses = 0x7FFF;
			Model = 15774;
			ObjectClass = 0;
			SubClass = 0;
			Level = 27;
			ReqLevel = 17;
			Name = "Shadow Protection Potion";
			Name2 = "Shadow Protection Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 400;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 7242 , 0 , -1 , 0 , 4 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Fire Protection Potion)
*
***************************************************************/

namespace Server.Items
{
	public class FireProtectionPotion : Item
	{
		public FireProtectionPotion() : base()
		{
			Id = 6049;
			SellPrice = 170;
			AvailableClasses = 0x7FFF;
			Model = 9639;
			ObjectClass = 0;
			SubClass = 0;
			Level = 33;
			ReqLevel = 23;
			Name = "Fire Protection Potion";
			Name2 = "Fire Protection Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 680;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 7233 , 0 , -1 , 0 , 4 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Frost Protection Potion)
*
***************************************************************/

namespace Server.Items
{
	public class FrostProtectionPotion : Item
	{
		public FrostProtectionPotion() : base()
		{
			Id = 6050;
			SellPrice = 300;
			AvailableClasses = 0x7FFF;
			Model = 9058;
			ObjectClass = 0;
			SubClass = 0;
			Level = 38;
			ReqLevel = 28;
			Name = "Frost Protection Potion";
			Name2 = "Frost Protection Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1200;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 7239 , 0 , -1 , 0 , 4 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Holy Protection Potion)
*
***************************************************************/

namespace Server.Items
{
	public class HolyProtectionPotion : Item
	{
		public HolyProtectionPotion() : base()
		{
			Id = 6051;
			SellPrice = 62;
			AvailableClasses = 0x7FFF;
			Model = 15747;
			ObjectClass = 0;
			SubClass = 0;
			Level = 20;
			ReqLevel = 10;
			Name = "Holy Protection Potion";
			Name2 = "Holy Protection Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 250;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 7245 , 0 , -1 , 0 , 4 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Nature Protection Potion)
*
***************************************************************/

namespace Server.Items
{
	public class NatureProtectionPotion : Item
	{
		public NatureProtectionPotion() : base()
		{
			Id = 6052;
			SellPrice = 300;
			AvailableClasses = 0x7FFF;
			Model = 4135;
			ObjectClass = 0;
			SubClass = 0;
			Level = 38;
			ReqLevel = 28;
			Name = "Nature Protection Potion";
			Name2 = "Nature Protection Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1200;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 7254 , 0 , -1 , 0 , 4 , 120000 );
		}
	}
}


/**************************************************************
*
*				(War Horn Mouthpiece)
*
***************************************************************/

namespace Server.Items
{
	public class WarHornMouthpiece : Item
	{
		public WarHornMouthpiece() : base()
		{
			Id = 6074;
			Bonding = 4;
			AvailableClasses = 0x7FFF;
			Model = 9711;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "War Horn Mouthpiece";
			Name2 = "War Horn Mouthpiece";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 7285 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Greater Mana Potion)
*
***************************************************************/

namespace Server.Items
{
	public class GreaterManaPotion : Item
	{
		public GreaterManaPotion() : base()
		{
			Id = 6149;
			SellPrice = 120;
			AvailableClasses = 0x7FFF;
			Model = 15718;
			ObjectClass = 0;
			SubClass = 0;
			Level = 41;
			ReqLevel = 31;
			Name = "Greater Mana Potion";
			Name2 = "Greater Mana Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 480;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 11903 , 0 , -1 , 0 , 4 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Unlit Poor Torch)
*
***************************************************************/

namespace Server.Items
{
	public class UnlitPoorTorch : Item
	{
		public UnlitPoorTorch() : base()
		{
			Id = 6183;
			SellPrice = 2;
			AvailableClasses = 0x7FFF;
			Model = 12311;
			ObjectClass = 0;
			SubClass = 0;
			Level = 10;
			Name = "Unlit Poor Torch";
			Name2 = "Unlit Poor Torch";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 25;
			Skill = 142;
			BuyPrice = 10;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
			Flags = 64;
			SetSpell( 7364 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Raw Longjaw Mud Snapper)
*
***************************************************************/

namespace Server.Items
{
	public class RawLongjawMudSnapper : Item
	{
		public RawLongjawMudSnapper() : base()
		{
			Id = 6289;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 24702;
			ObjectClass = 0;
			SubClass = 0;
			Level = 15;
			ReqLevel = 5;
			Name = "Raw Longjaw Mud Snapper";
			Name2 = "Raw Longjaw Mud Snapper";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 20;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 433 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Brilliant Smallfish)
*
***************************************************************/

namespace Server.Items
{
	public class BrilliantSmallfish : Item
	{
		public BrilliantSmallfish() : base()
		{
			Id = 6290;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 18536;
			ObjectClass = 0;
			SubClass = 0;
			Level = 5;
			ReqLevel = 1;
			Name = "Brilliant Smallfish";
			Name2 = "Brilliant Smallfish";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 25;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 8;
			SetSpell( 433 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Raw Brilliant Smallfish)
*
***************************************************************/

namespace Server.Items
{
	public class RawBrilliantSmallfish : Item
	{
		public RawBrilliantSmallfish() : base()
		{
			Id = 6291;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 18535;
			ObjectClass = 0;
			SubClass = 0;
			Level = 5;
			ReqLevel = 1;
			Name = "Raw Brilliant Smallfish";
			Name2 = "Raw Brilliant Smallfish";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 20;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 8;
			SetSpell( 7737 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Sickly Looking Fish)
*
***************************************************************/

namespace Server.Items
{
	public class SicklyLookingFish : Item
	{
		public SicklyLookingFish() : base()
		{
			Id = 6299;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 24696;
			ObjectClass = 0;
			SubClass = 0;
			Level = 5;
			ReqLevel = 1;
			Name = "Sickly Looking Fish";
			Name2 = "Sickly Looking Fish";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 25;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 8;
			SetSpell( 7737 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Raw Slitherskin Mackerel)
*
***************************************************************/

namespace Server.Items
{
	public class RawSlitherskinMackerel : Item
	{
		public RawSlitherskinMackerel() : base()
		{
			Id = 6303;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 24697;
			ObjectClass = 0;
			SubClass = 0;
			Level = 5;
			ReqLevel = 1;
			Name = "Raw Slitherskin Mackerel";
			Name2 = "Raw Slitherskin Mackerel";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 20;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 8;
			SetSpell( 7737 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Raw Bristle Whisker Catfish)
*
***************************************************************/

namespace Server.Items
{
	public class RawBristleWhiskerCatfish : Item
	{
		public RawBristleWhiskerCatfish() : base()
		{
			Id = 6308;
			SellPrice = 2;
			AvailableClasses = 0x7FFF;
			Model = 24710;
			ObjectClass = 0;
			SubClass = 0;
			Level = 25;
			ReqLevel = 15;
			Name = "Raw Bristle Whisker Catfish";
			Name2 = "Raw Bristle Whisker Catfish";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 40;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 434 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Loch Frenzy Delight)
*
***************************************************************/

namespace Server.Items
{
	public class LochFrenzyDelight : Item
	{
		public LochFrenzyDelight() : base()
		{
			Id = 6316;
			SellPrice = 3;
			AvailableClasses = 0x7FFF;
			Model = 11268;
			ObjectClass = 0;
			SubClass = 0;
			Level = 15;
			ReqLevel = 5;
			Name = "Loch Frenzy Delight";
			Name2 = "Loch Frenzy Delight";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 60;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 434 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Raw Loch Frenzy)
*
***************************************************************/

namespace Server.Items
{
	public class RawLochFrenzy : Item
	{
		public RawLochFrenzy() : base()
		{
			Id = 6317;
			SellPrice = 2;
			AvailableClasses = 0x7FFF;
			Model = 4813;
			ObjectClass = 0;
			SubClass = 0;
			Level = 15;
			ReqLevel = 5;
			Name = "Raw Loch Frenzy";
			Name2 = "Raw Loch Frenzy";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 40;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 433 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Raw Rainbow Fin Albacore)
*
***************************************************************/

namespace Server.Items
{
	public class RawRainbowFinAlbacore : Item
	{
		public RawRainbowFinAlbacore() : base()
		{
			Id = 6361;
			SellPrice = 2;
			AvailableClasses = 0x7FFF;
			Model = 24709;
			ObjectClass = 0;
			SubClass = 0;
			Level = 15;
			ReqLevel = 5;
			Name = "Raw Rainbow Fin Albacore";
			Name2 = "Raw Rainbow Fin Albacore";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 40;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 433 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Raw Rockscale Cod)
*
***************************************************************/

namespace Server.Items
{
	public class RawRockscaleCod : Item
	{
		public RawRockscaleCod() : base()
		{
			Id = 6362;
			SellPrice = 4;
			AvailableClasses = 0x7FFF;
			Model = 4823;
			ObjectClass = 0;
			SubClass = 0;
			Level = 35;
			ReqLevel = 25;
			Name = "Raw Rockscale Cod";
			Name2 = "Raw Rockscale Cod";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 80;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 435 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Swim Speed Potion)
*
***************************************************************/

namespace Server.Items
{
	public class SwimSpeedPotion : Item
	{
		public SwimSpeedPotion() : base()
		{
			Id = 6372;
			SellPrice = 35;
			AvailableClasses = 0x7FFF;
			Model = 15748;
			ObjectClass = 0;
			SubClass = 0;
			Level = 20;
			ReqLevel = 10;
			Name = "Swim Speed Potion";
			Name2 = "Swim Speed Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 140;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 7840 , 0 , -1 , 0 , 4 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Elixir of Firepower)
*
***************************************************************/

namespace Server.Items
{
	public class ElixirOfFirepower : Item
	{
		public ElixirOfFirepower() : base()
		{
			Id = 6373;
			SellPrice = 35;
			AvailableClasses = 0x7FFF;
			Model = 15788;
			ObjectClass = 0;
			SubClass = 0;
			Level = 28;
			ReqLevel = 18;
			Name = "Elixir of Firepower";
			Name2 = "Elixir of Firepower";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 140;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 7844 , 0 , -1 , 0 , 79 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Oil Covered Fish)
*
***************************************************************/

namespace Server.Items
{
	public class OilCoveredFish : Item
	{
		public OilCoveredFish() : base()
		{
			Id = 6458;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 11932;
			ObjectClass = 0;
			SubClass = 0;
			Level = 15;
			ReqLevel = 5;
			Name = "Oil Covered Fish";
			Name2 = "Oil Covered Fish";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 4;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 433 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Wailing Essence)
*
***************************************************************/

namespace Server.Items
{
	public class WailingEssence : Item
	{
		public WailingEssence() : base()
		{
			Id = 6464;
			Bonding = 4;
			AvailableClasses = 0x7FFF;
			Model = 12926;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Wailing Essence";
			Name2 = "Wailing Essence";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Singed Scale)
*
***************************************************************/

namespace Server.Items
{
	public class SingedScale : Item
	{
		public SingedScale() : base()
		{
			Id = 6486;
			Bonding = 4;
			AvailableClasses = 0x7FFF;
			Model = 10043;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Singed Scale";
			Name2 = "Singed Scale";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Shiny Bauble)
*
***************************************************************/

namespace Server.Items
{
	public class ShinyBauble : Item
	{
		public ShinyBauble() : base()
		{
			Id = 6529;
			SellPrice = 12;
			AvailableClasses = 0x7FFF;
			Model = 12410;
			ObjectClass = 0;
			SubClass = 0;
			Level = 10;
			Name = "Shiny Bauble";
			Name2 = "Shiny Bauble";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 50;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			Flags = 64;
			SetSpell( 8087 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Nightcrawlers)
*
***************************************************************/

namespace Server.Items
{
	public class Nightcrawlers : Item
	{
		public Nightcrawlers() : base()
		{
			Id = 6530;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 18097;
			ObjectClass = 0;
			SubClass = 0;
			Level = 20;
			Name = "Nightcrawlers";
			Name2 = "Nightcrawlers";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 50;
			Skill = 356;
			BuyPrice = 100;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			Flags = 64;
			SetSpell( 8088 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Bright Baubles)
*
***************************************************************/

namespace Server.Items
{
	public class BrightBaubles : Item
	{
		public BrightBaubles() : base()
		{
			Id = 6532;
			SellPrice = 62;
			AvailableClasses = 0x7FFF;
			Model = 12423;
			ObjectClass = 0;
			SubClass = 0;
			Level = 30;
			Name = "Bright Baubles";
			Name2 = "Bright Baubles";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 100;
			Skill = 356;
			BuyPrice = 250;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			Flags = 64;
			SetSpell( 8090 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Earth Sapta)
*
***************************************************************/

namespace Server.Items
{
	public class EarthSapta : Item
	{
		public EarthSapta() : base()
		{
			Id = 6635;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 6400;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Earth Sapta";
			Name2 = "Earth Sapta";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			SetSpell( 8202 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Fire Sapta)
*
***************************************************************/

namespace Server.Items
{
	public class FireSapta : Item
	{
		public FireSapta() : base()
		{
			Id = 6636;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 12621;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Fire Sapta";
			Name2 = "Fire Sapta";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			SetSpell( 8898 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Water Sapta)
*
***************************************************************/

namespace Server.Items
{
	public class WaterSapta : Item
	{
		public WaterSapta() : base()
		{
			Id = 6637;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 6340;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Water Sapta";
			Name2 = "Water Sapta";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			SetSpell( 8899 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Bloated Smallfish)
*
***************************************************************/

namespace Server.Items
{
	public class BloatedSmallfish : Item
	{
		public BloatedSmallfish() : base()
		{
			Id = 6643;
			SellPrice = 6;
			AvailableClasses = 0x7FFF;
			Model = 18535;
			ObjectClass = 0;
			SubClass = 0;
			Level = 5;
			ReqLevel = 1;
			Name = "Bloated Smallfish";
			Name2 = "Bloated Smallfish";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 25;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = 8;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Bloated Mud Snapper)
*
***************************************************************/

namespace Server.Items
{
	public class BloatedMudSnapper : Item
	{
		public BloatedMudSnapper() : base()
		{
			Id = 6645;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 24694;
			ObjectClass = 0;
			SubClass = 0;
			Level = 15;
			ReqLevel = 5;
			Name = "Bloated Mud Snapper";
			Name2 = "Bloated Mud Snapper";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 100;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Bloated Catfish)
*
***************************************************************/

namespace Server.Items
{
	public class BloatedCatfish : Item
	{
		public BloatedCatfish() : base()
		{
			Id = 6647;
			SellPrice = 40;
			AvailableClasses = 0x7FFF;
			Model = 24711;
			ObjectClass = 0;
			SubClass = 0;
			Level = 25;
			ReqLevel = 15;
			Name = "Bloated Catfish";
			Name2 = "Bloated Catfish";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 160;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Savory Deviate Delight)
*
***************************************************************/

namespace Server.Items
{
	public class SavoryDeviateDelight : Item
	{
		public SavoryDeviateDelight() : base()
		{
			Id = 6657;
			SellPrice = 5;
			AvailableClasses = 0x7FFF;
			Model = 12780;
			ObjectClass = 0;
			SubClass = 0;
			Level = 18;
			Name = "Savory Deviate Delight";
			Name2 = "Savory Deviate Delight";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 20;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 8213 , 0 , -1 , 10000 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Elixir of Giant Growth)
*
***************************************************************/

namespace Server.Items
{
	public class ElixirOfGiantGrowth : Item
	{
		public ElixirOfGiantGrowth() : base()
		{
			Id = 6662;
			SellPrice = 95;
			AvailableClasses = 0x7FFF;
			Model = 11462;
			ObjectClass = 0;
			SubClass = 0;
			Level = 18;
			ReqLevel = 8;
			Name = "Elixir of Giant Growth";
			Name2 = "Elixir of Giant Growth";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 380;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 8212 , 0 , -1 , 0 , 79 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Bartleby's Mug)
*
***************************************************************/

namespace Server.Items
{
	public class BartlebysMug : Item
	{
		public BartlebysMug() : base()
		{
			Id = 6781;
			Bonding = 4;
			AvailableClasses = 0x7FFF;
			Model = 18100;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Bartleby's Mug";
			Name2 = "Bartleby's Mug";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Marshal Haggard's Badge)
*
***************************************************************/

namespace Server.Items
{
	public class MarshalHaggardsBadge : Item
	{
		public MarshalHaggardsBadge() : base()
		{
			Id = 6782;
			Bonding = 4;
			AvailableClasses = 0x7FFF;
			Model = 13024;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Marshal Haggard's Badge";
			Name2 = "Marshal Haggard's Badge";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Frog Leg Stew)
*
***************************************************************/

namespace Server.Items
{
	public class FrogLegStew : Item
	{
		public FrogLegStew() : base()
		{
			Id = 6807;
			SellPrice = 62;
			AvailableClasses = 0x7FFF;
			Model = 557;
			ObjectClass = 0;
			SubClass = 0;
			Level = 35;
			Name = "Frog Leg Stew";
			Name2 = "Frog Leg Stew";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1250;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 1127 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Aquadynamic Fish Lens)
*
***************************************************************/

namespace Server.Items
{
	public class AquadynamicFishLens : Item
	{
		public AquadynamicFishLens() : base()
		{
			Id = 6811;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 13086;
			ObjectClass = 0;
			SubClass = 0;
			Level = 20;
			Name = "Aquadynamic Fish Lens";
			Name2 = "Aquadynamic Fish Lens";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 50;
			Skill = 356;
			BuyPrice = 100;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			Flags = 64;
			SetSpell( 8532 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Case of Elunite)
*
***************************************************************/

namespace Server.Items
{
	public class CaseOfElunite : Item
	{
		public CaseOfElunite() : base()
		{
			Id = 6812;
			Bonding = 4;
			AvailableClasses = 0x7FFF;
			Model = 13100;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Case of Elunite";
			Name2 = "Case of Elunite";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Vial of Phlogiston)
*
***************************************************************/

namespace Server.Items
{
	public class VialOfPhlogiston : Item
	{
		public VialOfPhlogiston() : base()
		{
			Id = 6841;
			Bonding = 4;
			AvailableClasses = 0x7FFF;
			Model = 4984;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Vial of Phlogiston";
			Name2 = "Vial of Phlogiston";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 2048;
		}
	}
}


/**************************************************************
*
*				(Furen's Instructions)
*
***************************************************************/

namespace Server.Items
{
	public class FurensInstructions : Item
	{
		public FurensInstructions() : base()
		{
			Id = 6842;
			Bonding = 4;
			AvailableClasses = 0x7FFF;
			Model = 7798;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Furen's Instructions";
			Name2 = "Furen's Instructions";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			PageText = 831;
		}
	}
}


/**************************************************************
*
*				(Essence of the Exile)
*
***************************************************************/

namespace Server.Items
{
	public class EssenceOfTheExile : Item
	{
		public EssenceOfTheExile() : base()
		{
			Id = 6851;
			Bonding = 4;
			AvailableClasses = 0x7FFF;
			Model = 19800;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Essence of the Exile";
			Name2 = "Essence of the Exile";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Spotted Yellowtail)
*
***************************************************************/

namespace Server.Items
{
	public class SpottedYellowtail : Item
	{
		public SpottedYellowtail() : base()
		{
			Id = 6887;
			SellPrice = 5;
			AvailableClasses = 0x7FFF;
			Model = 4811;
			ObjectClass = 0;
			SubClass = 0;
			Level = 45;
			ReqLevel = 35;
			Name = "Spotted Yellowtail";
			Name2 = "Spotted Yellowtail";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 1129 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Herb Baked Egg)
*
***************************************************************/

namespace Server.Items
{
	public class HerbBakedEgg : Item
	{
		public HerbBakedEgg() : base()
		{
			Id = 6888;
			SellPrice = 10;
			AvailableClasses = 0x7FFF;
			Model = 18052;
			ObjectClass = 0;
			SubClass = 0;
			Level = 7;
			ReqLevel = 1;
			Name = "Herb Baked Egg";
			Name2 = "Herb Baked Egg";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 40;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 5004 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Smoked Bear Meat)
*
***************************************************************/

namespace Server.Items
{
	public class SmokedBearMeat : Item
	{
		public SmokedBearMeat() : base()
		{
			Id = 6890;
			SellPrice = 6;
			AvailableClasses = 0x7FFF;
			Model = 4113;
			ObjectClass = 0;
			SubClass = 0;
			Level = 15;
			ReqLevel = 5;
			Name = "Smoked Bear Meat";
			Name2 = "Smoked Bear Meat";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 125;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 434 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Furen's Notes)
*
***************************************************************/

namespace Server.Items
{
	public class FurensNotes : Item
	{
		public FurensNotes() : base()
		{
			Id = 6926;
			Bonding = 4;
			AvailableClasses = 0x7FFF;
			Description = "This letter is sealed";
			Model = 13430;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Furen's Notes";
			Name2 = "Furen's Notes";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Big Will's Ear)
*
***************************************************************/

namespace Server.Items
{
	public class BigWillsEar : Item
	{
		public BigWillsEar() : base()
		{
			Id = 6927;
			Bonding = 4;
			AvailableClasses = 0x7FFF;
			Model = 13433;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Big Will's Ear";
			Name2 = "Big Will's Ear";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 2048;
		}
	}
}


/**************************************************************
*
*				(Bath'rah's Parchment)
*
***************************************************************/

namespace Server.Items
{
	public class BathrahsParchment : Item
	{
		public BathrahsParchment() : base()
		{
			Id = 6929;
			Bonding = 4;
			AvailableClasses = 0x7FFF;
			Model = 7798;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Bath'rah's Parchment";
			Name2 = "Bath'rah's Parchment";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			PageText = 855;
		}
	}
}


/**************************************************************
*
*				(Instant Poison)
*
***************************************************************/

namespace Server.Items
{
	public class InstantPoison : Item
	{
		public InstantPoison() : base()
		{
			Id = 6947;
			SellPrice = 5;
			AvailableClasses = 0x08;
			Model = 13710;
			ObjectClass = 0;
			SubClass = 0;
			Level = 20;
			ReqLevel = 20;
			Name = "Instant Poison";
			Name2 = "Instant Poison";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 22;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 3;
			Flags = 64;
			SetSpell( 8679 , 0 , -1 , 0 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Instant Poison II)
*
***************************************************************/

namespace Server.Items
{
	public class InstantPoisonII : Item
	{
		public InstantPoisonII() : base()
		{
			Id = 6949;
			SellPrice = 20;
			AvailableClasses = 0x08;
			Model = 13710;
			ObjectClass = 0;
			SubClass = 0;
			Level = 28;
			ReqLevel = 28;
			Name = "Instant Poison II";
			Name2 = "Instant Poison II";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 80;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 3;
			Flags = 64;
			SetSpell( 8686 , 0 , -1 , 0 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Instant Poison III)
*
***************************************************************/

namespace Server.Items
{
	public class InstantPoisonIII : Item
	{
		public InstantPoisonIII() : base()
		{
			Id = 6950;
			SellPrice = 30;
			AvailableClasses = 0x08;
			Model = 13710;
			ObjectClass = 0;
			SubClass = 0;
			Level = 36;
			ReqLevel = 36;
			Name = "Instant Poison III";
			Name2 = "Instant Poison III";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 120;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 3;
			Flags = 64;
			SetSpell( 8688 , 0 , -1 , 0 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Mind-numbing Poison II)
*
***************************************************************/

namespace Server.Items
{
	public class MindNumbingPoisonII : Item
	{
		public MindNumbingPoisonII() : base()
		{
			Id = 6951;
			SellPrice = 75;
			AvailableClasses = 0x08;
			Model = 13709;
			ObjectClass = 0;
			SubClass = 0;
			Level = 38;
			ReqLevel = 38;
			Name = "Mind-numbing Poison II";
			Name2 = "Mind-numbing Poison II";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 300;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 3;
			Flags = 64;
			SetSpell( 8693 , 0 , -1 , 0 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Leg Meat)
*
***************************************************************/

namespace Server.Items
{
	public class LegMeat : Item
	{
		public LegMeat() : base()
		{
			Id = 7097;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 2474;
			ObjectClass = 0;
			SubClass = 0;
			Level = 5;
			ReqLevel = 1;
			Name = "Leg Meat";
			Name2 = "Leg Meat";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 25;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 433 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Powdered Azurite)
*
***************************************************************/

namespace Server.Items
{
	public class PowderedAzurite : Item
	{
		public PowderedAzurite() : base()
		{
			Id = 7127;
			Bonding = 4;
			AvailableClasses = 0x7FFF;
			Model = 7171;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Powdered Azurite";
			Name2 = "Powdered Azurite";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Balnir Snapdragons)
*
***************************************************************/

namespace Server.Items
{
	public class BalnirSnapdragons : Item
	{
		public BalnirSnapdragons() : base()
		{
			Id = 7227;
			Bonding = 4;
			AvailableClasses = 0x7FFF;
			Model = 13905;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Balnir Snapdragons";
			Name2 = "Balnir Snapdragons";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Tigule and Foror's Strawberry Ice Cream)
*
***************************************************************/

namespace Server.Items
{
	public class TiguleAndFororsStrawberryIceCream : Item
	{
		public TiguleAndFororsStrawberryIceCream() : base()
		{
			Id = 7228;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 13906;
			ObjectClass = 0;
			SubClass = 0;
			Level = 25;
			ReqLevel = 15;
			Name = "Tigule and Foror's Strawberry Ice Cream";
			Name2 = "Tigule and Foror's Strawberry Ice Cream";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 500;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 435 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Ur's Treatise on Shadow Magic)
*
***************************************************************/

namespace Server.Items
{
	public class UrsTreatiseOnShadowMagic : Item
	{
		public UrsTreatiseOnShadowMagic() : base()
		{
			Id = 7266;
			Bonding = 4;
			AvailableClasses = 0x7FFF;
			Model = 11181;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Ur's Treatise on Shadow Magic";
			Name2 = "Ur's Treatise on Shadow Magic";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			PageText = 891;
		}
	}
}


/**************************************************************
*
*				(Flesh Eating Worm)
*
***************************************************************/

namespace Server.Items
{
	public class FleshEatingWorm : Item
	{
		public FleshEatingWorm() : base()
		{
			Id = 7307;
			SellPrice = 62;
			AvailableClasses = 0x7FFF;
			Model = 18098;
			ObjectClass = 0;
			SubClass = 0;
			Level = 30;
			Name = "Flesh Eating Worm";
			Name2 = "Flesh Eating Worm";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 100;
			Skill = 356;
			BuyPrice = 250;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			Flags = 64;
			SetSpell( 9092 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Tabetha's Instructions)
*
***************************************************************/

namespace Server.Items
{
	public class TabethasInstructions : Item
	{
		public TabethasInstructions() : base()
		{
			Id = 7516;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 15274;
			ObjectClass = 0;
			SubClass = 0;
			Name = "Tabetha's Instructions";
			Name2 = "Tabetha's Instructions";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			PageText = 911;
		}
	}
}


/**************************************************************
*
*				(Dolanaar Delivery)
*
***************************************************************/

namespace Server.Items
{
	public class DolanaarDelivery : Item
	{
		public DolanaarDelivery() : base()
		{
			Id = 7627;
			Bonding = 4;
			AvailableClasses = 0x7FFF;
			Model = 15590;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Dolanaar Delivery";
			Name2 = "Dolanaar Delivery";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Ukor's Burden)
*
***************************************************************/

namespace Server.Items
{
	public class UkorsBurden : Item
	{
		public UkorsBurden() : base()
		{
			Id = 7629;
			Bonding = 4;
			AvailableClasses = 0x7FFF;
			Model = 362;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Ukor's Burden";
			Name2 = "Ukor's Burden";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Thistle Tea)
*
***************************************************************/

namespace Server.Items
{
	public class ThistleTea : Item
	{
		public ThistleTea() : base()
		{
			Id = 7676;
			SellPrice = 30;
			AvailableClasses = 0x08;
			Model = 18091;
			ObjectClass = 0;
			SubClass = 0;
			Level = 15;
			ReqLevel = 5;
			Name = "Thistle Tea";
			Name2 = "Thistle Tea";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 120;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 3;
			SetSpell( 9512 , 0 , -1 , 300000 , 59 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Lollipop)
*
***************************************************************/

namespace Server.Items
{
	public class Lollipop : Item
	{
		public Lollipop() : base()
		{
			Id = 7806;
			SellPrice = 10;
			AvailableClasses = 0x7FFF;
			Model = 15963;
			ObjectClass = 0;
			SubClass = 0;
			Level = 5;
			ReqLevel = 1;
			Name = "Lollipop";
			Name2 = "Lollipop";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 40;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 5004 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Candy Bar)
*
***************************************************************/

namespace Server.Items
{
	public class CandyBar : Item
	{
		public CandyBar() : base()
		{
			Id = 7807;
			SellPrice = 10;
			AvailableClasses = 0x7FFF;
			Model = 15964;
			ObjectClass = 0;
			SubClass = 0;
			Level = 5;
			ReqLevel = 1;
			Name = "Candy Bar";
			Name2 = "Candy Bar";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 40;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 5004 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Chocolate Square)
*
***************************************************************/

namespace Server.Items
{
	public class ChocolateSquare : Item
	{
		public ChocolateSquare() : base()
		{
			Id = 7808;
			SellPrice = 10;
			AvailableClasses = 0x7FFF;
			Model = 15965;
			ObjectClass = 0;
			SubClass = 0;
			Level = 5;
			ReqLevel = 1;
			Name = "Chocolate Square";
			Name2 = "Chocolate Square";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 40;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 5004 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(E.C.A.C.)
*
***************************************************************/

namespace Server.Items
{
	public class ECAC : Item
	{
		public ECAC() : base()
		{
			Id = 7970;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Description = "Enormous Chemically Altered Cracker";
			Model = 16206;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "E.C.A.C.";
			Name2 = "E.C.A.C.";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 1088;
			SetSpell( 9976 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Mana Citrine)
*
***************************************************************/

namespace Server.Items
{
	public class ManaCitrine : Item
	{
		public ManaCitrine() : base()
		{
			Id = 8007;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 6496;
			ObjectClass = 0;
			SubClass = 0;
			Level = 48;
			ReqLevel = 48;
			Name = "Mana Citrine";
			Name2 = "Mana Citrine";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Flags = 2;
			SetSpell( 10057 , 0 , -1 , 0 , 100 , 180000 );
		}
	}
}


/**************************************************************
*
*				(Mana Ruby)
*
***************************************************************/

namespace Server.Items
{
	public class ManaRuby : Item
	{
		public ManaRuby() : base()
		{
			Id = 8008;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 7045;
			ObjectClass = 0;
			SubClass = 0;
			Level = 58;
			ReqLevel = 58;
			Name = "Mana Ruby";
			Name2 = "Mana Ruby";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Flags = 2;
			SetSpell( 10058 , 0 , -1 , 0 , 100 , 180000 );
		}
	}
}


/**************************************************************
*
*				(Emerald Dreamcatcher)
*
***************************************************************/

namespace Server.Items
{
	public class EmeraldDreamcatcher : Item
	{
		public EmeraldDreamcatcher() : base()
		{
			Id = 8048;
			Bonding = 4;
			AvailableClasses = 0x7FFF;
			Model = 16300;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Emerald Dreamcatcher";
			Name2 = "Emerald Dreamcatcher";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Conjured Sourdough)
*
***************************************************************/

namespace Server.Items
{
	public class ConjuredSourdough : Item
	{
		public ConjuredSourdough() : base()
		{
			Id = 8075;
			AvailableClasses = 0x7FFF;
			Model = 6399;
			ObjectClass = 0;
			SubClass = 0;
			Level = 45;
			ReqLevel = 35;
			Name = "Conjured Sourdough";
			Name2 = "Conjured Sourdough";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			Flags = 2;
			SetSpell( 1129 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Conjured Sweet Roll)
*
***************************************************************/

namespace Server.Items
{
	public class ConjuredSweetRoll : Item
	{
		public ConjuredSweetRoll() : base()
		{
			Id = 8076;
			AvailableClasses = 0x7FFF;
			Model = 21203;
			ObjectClass = 0;
			SubClass = 0;
			Level = 55;
			ReqLevel = 45;
			Name = "Conjured Sweet Roll";
			Name2 = "Conjured Sweet Roll";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			Flags = 2;
			SetSpell( 1131 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Conjured Mineral Water)
*
***************************************************************/

namespace Server.Items
{
	public class ConjuredMineralWater : Item
	{
		public ConjuredMineralWater() : base()
		{
			Id = 8077;
			AvailableClasses = 0x7FFF;
			Model = 18078;
			ObjectClass = 0;
			SubClass = 0;
			Level = 45;
			ReqLevel = 35;
			Name = "Conjured Mineral Water";
			Name2 = "Conjured Mineral Water";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 3;
			Flags = 2;
			SetSpell( 1135 , 0 , -1 , 0 , 59 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Conjured Sparkling Water)
*
***************************************************************/

namespace Server.Items
{
	public class ConjuredSparklingWater : Item
	{
		public ConjuredSparklingWater() : base()
		{
			Id = 8078;
			AvailableClasses = 0x7FFF;
			Model = 18080;
			ObjectClass = 0;
			SubClass = 0;
			Level = 55;
			ReqLevel = 45;
			Name = "Conjured Sparkling Water";
			Name2 = "Conjured Sparkling Water";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 3;
			Flags = 2;
			SetSpell( 1137 , 0 , -1 , 0 , 59 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Conjured Crystal Water)
*
***************************************************************/

namespace Server.Items
{
	public class ConjuredCrystalWater : Item
	{
		public ConjuredCrystalWater() : base()
		{
			Id = 8079;
			AvailableClasses = 0x7FFF;
			Model = 21794;
			ObjectClass = 0;
			SubClass = 0;
			Level = 65;
			ReqLevel = 55;
			Name = "Conjured Crystal Water";
			Name2 = "Conjured Crystal Water";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 3;
			Flags = 2;
			SetSpell( 22734 , 0 , -1 , 0 , 59 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Hinott's Oil)
*
***************************************************************/

namespace Server.Items
{
	public class HinottsOil : Item
	{
		public HinottsOil() : base()
		{
			Id = 8095;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 16325;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			ReqLevel = 1;
			Name = "Hinott's Oil";
			Name2 = "Hinott's Oil";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 1024;
			SetSpell( 10723 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Test Stationery)
*
***************************************************************/

namespace Server.Items
{
	public class TestStationery : Item
	{
		public TestStationery() : base()
		{
			Id = 8164;
			SellPrice = 2;
			AvailableClasses = 0x7FFF;
			Model = 1069;
			ObjectClass = 0;
			SubClass = 0;
			Name = "Test Stationery";
			Name2 = "Test Stationery";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 10;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Thick Armor Kit)
*
***************************************************************/

namespace Server.Items
{
	public class ThickArmorKit : Item
	{
		public ThickArmorKit() : base()
		{
			Id = 8173;
			SellPrice = 1000;
			AvailableClasses = 0x7FFF;
			Model = 26389;
			ObjectClass = 0;
			SubClass = 0;
			Level = 40;
			ReqLevel = 30;
			Name = "Thick Armor Kit";
			Name2 = "Thick Armor Kit";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 4000;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 8;
			Flags = 64;
			SetSpell( 10344 , 0 , -1 , 1000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Mithril Head Trout)
*
***************************************************************/

namespace Server.Items
{
	public class MithrilHeadTrout : Item
	{
		public MithrilHeadTrout() : base()
		{
			Id = 8364;
			SellPrice = 6;
			AvailableClasses = 0x7FFF;
			Model = 1208;
			ObjectClass = 0;
			SubClass = 0;
			Level = 35;
			ReqLevel = 25;
			Name = "Mithril Head Trout";
			Name2 = "Mithril Head Trout";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1250;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 1127 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Raw Mithril Head Trout)
*
***************************************************************/

namespace Server.Items
{
	public class RawMithrilHeadTrout : Item
	{
		public RawMithrilHeadTrout() : base()
		{
			Id = 8365;
			SellPrice = 4;
			AvailableClasses = 0x7FFF;
			Model = 1208;
			ObjectClass = 0;
			SubClass = 0;
			Level = 35;
			ReqLevel = 25;
			Name = "Raw Mithril Head Trout";
			Name2 = "Raw Mithril Head Trout";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 80;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 435 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Bloated Trout)
*
***************************************************************/

namespace Server.Items
{
	public class BloatedTrout : Item
	{
		public BloatedTrout() : base()
		{
			Id = 8366;
			SellPrice = 100;
			AvailableClasses = 0x7FFF;
			Model = 1208;
			ObjectClass = 0;
			SubClass = 0;
			Level = 35;
			ReqLevel = 25;
			Name = "Bloated Trout";
			Name2 = "Bloated Trout";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 400;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(R.O.I.D.S.)
*
***************************************************************/

namespace Server.Items
{
	public class ROIDS : Item
	{
		public ROIDS() : base()
		{
			Id = 8410;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Description = "Robust Operational Imbue Derived From Snickerfang";
			Model = 16801;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "R.O.I.D.S.";
			Name2 = "R.O.I.D.S.";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			SetSpell( 10667 , 0 , -1 , 0 , 103 , 3600000 );
		}
	}
}


/**************************************************************
*
*				(Lung Juice Cocktail)
*
***************************************************************/

namespace Server.Items
{
	public class LungJuiceCocktail : Item
	{
		public LungJuiceCocktail() : base()
		{
			Id = 8411;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Description = "100% Grade A Lung Juice - Freshly Squeezed";
			Model = 18114;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Lung Juice Cocktail";
			Name2 = "Lung Juice Cocktail";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			SetSpell( 10668 , 0 , -1 , 0 , 103 , 3600000 );
		}
	}
}


/**************************************************************
*
*				(Ground Scorpok Assay)
*
***************************************************************/

namespace Server.Items
{
	public class GroundScorpokAssay : Item
	{
		public GroundScorpokAssay() : base()
		{
			Id = 8412;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 16803;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Ground Scorpok Assay";
			Name2 = "Ground Scorpok Assay";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			SetSpell( 10669 , 0 , -1 , 0 , 103 , 3600000 );
		}
	}
}


/**************************************************************
*
*				(Cerebral Cortex Compound)
*
***************************************************************/

namespace Server.Items
{
	public class CerebralCortexCompound : Item
	{
		public CerebralCortexCompound() : base()
		{
			Id = 8423;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Description = "Best Served Chilled";
			Model = 16836;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Cerebral Cortex Compound";
			Name2 = "Cerebral Cortex Compound";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			SetSpell( 10692 , 0 , -1 , 0 , 103 , 3600000 );
		}
	}
}


/**************************************************************
*
*				(Gizzard Gum)
*
***************************************************************/

namespace Server.Items
{
	public class GizzardGum : Item
	{
		public GizzardGum() : base()
		{
			Id = 8424;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Description = "Strawberry Flavor";
			Model = 16837;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Gizzard Gum";
			Name2 = "Gizzard Gum";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			SetSpell( 10693 , 0 , -1 , 0 , 103 , 3600000 );
		}
	}
}


/**************************************************************
*
*				(Eau de Mixilpixil)
*
***************************************************************/

namespace Server.Items
{
	public class EauDeMixilpixil : Item
	{
		public EauDeMixilpixil() : base()
		{
			Id = 8432;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 16325;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			ReqLevel = 1;
			Name = "Eau de Mixilpixil";
			Name2 = "Eau de Mixilpixil";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 1024;
			SetSpell( 10723 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Executioner's Key)
*
***************************************************************/

namespace Server.Items
{
	public class ExecutionersKey : Item
	{
		public ExecutionersKey() : base()
		{
			Id = 8444;
			AvailableClasses = 0x7FFF;
			Model = 7737;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Executioner's Key";
			Name2 = "Executioner's Key";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Flags = 64;
			SetSpell( 10738 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Noggenfogger Elixir)
*
***************************************************************/

namespace Server.Items
{
	public class NoggenfoggerElixir : Item
	{
		public NoggenfoggerElixir() : base()
		{
			Id = 8529;
			Bonding = 1;
			SellPrice = 175;
			AvailableClasses = 0x7FFF;
			Model = 17403;
			ObjectClass = 0;
			SubClass = 0;
			Level = 45;
			ReqLevel = 35;
			Name = "Noggenfogger Elixir";
			Name2 = "Noggenfogger Elixir";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 3500;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 16589 , 0 , -1 , -1 , 4 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Divino-matic Rod)
*
***************************************************************/

namespace Server.Items
{
	public class DivinoMaticRod : Item
	{
		public DivinoMaticRod() : base()
		{
			Id = 8548;
			Bonding = 4;
			AvailableClasses = 0x7FFF;
			Model = 17461;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Divino-matic Rod";
			Name2 = "Divino-matic Rod";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 2048;
		}
	}
}


/**************************************************************
*
*				(Morning Glory Dew)
*
***************************************************************/

namespace Server.Items
{
	public class MorningGloryDew : Item
	{
		public MorningGloryDew() : base()
		{
			Id = 8766;
			SellPrice = 200;
			AvailableClasses = 0x7FFF;
			Model = 926;
			ObjectClass = 0;
			SubClass = 0;
			Level = 55;
			ReqLevel = 45;
			Name = "Morning Glory Dew";
			Name2 = "Morning Glory Dew";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 4000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 7;
			SetSpell( 1137 , 0 , -1 , 0 , 59 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Instant Poison IV)
*
***************************************************************/

namespace Server.Items
{
	public class InstantPoisonIV : Item
	{
		public InstantPoisonIV() : base()
		{
			Id = 8926;
			SellPrice = 75;
			AvailableClasses = 0x08;
			Model = 13710;
			ObjectClass = 0;
			SubClass = 0;
			Level = 44;
			ReqLevel = 44;
			Name = "Instant Poison IV";
			Name2 = "Instant Poison IV";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 300;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 3;
			Flags = 64;
			SetSpell( 11338 , 0 , -1 , 0 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Instant Poison V)
*
***************************************************************/

namespace Server.Items
{
	public class InstantPoisonV : Item
	{
		public InstantPoisonV() : base()
		{
			Id = 8927;
			SellPrice = 100;
			AvailableClasses = 0x08;
			Model = 13710;
			ObjectClass = 0;
			SubClass = 0;
			Level = 52;
			ReqLevel = 52;
			Name = "Instant Poison V";
			Name2 = "Instant Poison V";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 400;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 3;
			Flags = 64;
			SetSpell( 11339 , 0 , -1 , 0 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Instant Poison VI)
*
***************************************************************/

namespace Server.Items
{
	public class InstantPoisonVI : Item
	{
		public InstantPoisonVI() : base()
		{
			Id = 8928;
			SellPrice = 125;
			AvailableClasses = 0x08;
			Model = 13710;
			ObjectClass = 0;
			SubClass = 0;
			Level = 60;
			ReqLevel = 60;
			Name = "Instant Poison VI";
			Name2 = "Instant Poison VI";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 500;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 3;
			Flags = 64;
			SetSpell( 11340 , 0 , -1 , 0 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Alterac Swiss)
*
***************************************************************/

namespace Server.Items
{
	public class AlteracSwiss : Item
	{
		public AlteracSwiss() : base()
		{
			Id = 8932;
			SellPrice = 200;
			AvailableClasses = 0x7FFF;
			Model = 21906;
			ObjectClass = 0;
			SubClass = 0;
			Level = 55;
			ReqLevel = 45;
			Name = "Alterac Swiss";
			Name2 = "Alterac Swiss";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 4000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 1131 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Dried King Bolete)
*
***************************************************************/

namespace Server.Items
{
	public class DriedKingBolete : Item
	{
		public DriedKingBolete() : base()
		{
			Id = 8948;
			SellPrice = 200;
			AvailableClasses = 0x7FFF;
			Model = 17880;
			ObjectClass = 0;
			SubClass = 0;
			Level = 55;
			ReqLevel = 45;
			Name = "Dried King Bolete";
			Name2 = "Dried King Bolete";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 4000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 1131 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Elixir of Agility)
*
***************************************************************/

namespace Server.Items
{
	public class ElixirOfAgility : Item
	{
		public ElixirOfAgility() : base()
		{
			Id = 8949;
			SellPrice = 200;
			AvailableClasses = 0x7FFF;
			Model = 17882;
			ObjectClass = 0;
			SubClass = 0;
			Level = 37;
			ReqLevel = 27;
			Name = "Elixir of Agility";
			Name2 = "Elixir of Agility";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 800;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 11328 , 0 , -1 , 0 , 79 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Homemade Cherry Pie)
*
***************************************************************/

namespace Server.Items
{
	public class HomemadeCherryPie : Item
	{
		public HomemadeCherryPie() : base()
		{
			Id = 8950;
			SellPrice = 200;
			AvailableClasses = 0x7FFF;
			Model = 6342;
			ObjectClass = 0;
			SubClass = 0;
			Level = 55;
			ReqLevel = 45;
			Name = "Homemade Cherry Pie";
			Name2 = "Homemade Cherry Pie";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 4000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 1131 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Elixir of Greater Defense)
*
***************************************************************/

namespace Server.Items
{
	public class ElixirOfGreaterDefense : Item
	{
		public ElixirOfGreaterDefense() : base()
		{
			Id = 8951;
			SellPrice = 200;
			AvailableClasses = 0x7FFF;
			Model = 17883;
			ObjectClass = 0;
			SubClass = 0;
			Level = 39;
			ReqLevel = 29;
			Name = "Elixir of Greater Defense";
			Name2 = "Elixir of Greater Defense";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 800;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 11349 , 0 , -1 , 0 , 79 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Roasted Quail)
*
***************************************************************/

namespace Server.Items
{
	public class RoastedQuail : Item
	{
		public RoastedQuail() : base()
		{
			Id = 8952;
			SellPrice = 200;
			AvailableClasses = 0x7FFF;
			Model = 4112;
			ObjectClass = 0;
			SubClass = 0;
			Level = 55;
			ReqLevel = 45;
			Name = "Roasted Quail";
			Name2 = "Roasted Quail";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 4000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 1131 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Deep Fried Plantains)
*
***************************************************************/

namespace Server.Items
{
	public class DeepFriedPlantains : Item
	{
		public DeepFriedPlantains() : base()
		{
			Id = 8953;
			SellPrice = 200;
			AvailableClasses = 0x7FFF;
			Model = 17881;
			ObjectClass = 0;
			SubClass = 0;
			Level = 55;
			ReqLevel = 45;
			Name = "Deep Fried Plantains";
			Name2 = "Deep Fried Plantains";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 4000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 1131 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Oil of Immolation)
*
***************************************************************/

namespace Server.Items
{
	public class OilOfImmolation : Item
	{
		public OilOfImmolation() : base()
		{
			Id = 8956;
			SellPrice = 200;
			AvailableClasses = 0x7FFF;
			Model = 2351;
			ObjectClass = 0;
			SubClass = 0;
			Level = 41;
			ReqLevel = 31;
			Name = "Oil of Immolation";
			Name2 = "Oil of Immolation";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 800;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 11350 , 0 , -1 , 0 , 79 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Spinefin Halibut)
*
***************************************************************/

namespace Server.Items
{
	public class SpinefinHalibut : Item
	{
		public SpinefinHalibut() : base()
		{
			Id = 8957;
			SellPrice = 200;
			AvailableClasses = 0x7FFF;
			Model = 24718;
			ObjectClass = 0;
			SubClass = 0;
			Level = 55;
			ReqLevel = 45;
			Name = "Spinefin Halibut";
			Name2 = "Spinefin Halibut";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 4000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 1131 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Raw Spinefin Halibut)
*
***************************************************************/

namespace Server.Items
{
	public class RawSpinefinHalibut : Item
	{
		public RawSpinefinHalibut() : base()
		{
			Id = 8959;
			SellPrice = 160;
			AvailableClasses = 0x7FFF;
			Model = 24718;
			ObjectClass = 0;
			SubClass = 0;
			Level = 55;
			ReqLevel = 45;
			Name = "Raw Spinefin Halibut";
			Name2 = "Raw Spinefin Halibut";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 3200;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 1129 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Deadly Poison III)
*
***************************************************************/

namespace Server.Items
{
	public class DeadlyPoisonIII : Item
	{
		public DeadlyPoisonIII() : base()
		{
			Id = 8984;
			SellPrice = 100;
			AvailableClasses = 0x08;
			Model = 13707;
			ObjectClass = 0;
			SubClass = 0;
			Level = 46;
			ReqLevel = 46;
			Name = "Deadly Poison III";
			Name2 = "Deadly Poison III";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 400;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 3;
			Flags = 64;
			SetSpell( 11355 , 0 , -1 , 0 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Deadly Poison IV)
*
***************************************************************/

namespace Server.Items
{
	public class DeadlyPoisonIV : Item
	{
		public DeadlyPoisonIV() : base()
		{
			Id = 8985;
			SellPrice = 150;
			AvailableClasses = 0x08;
			Model = 13707;
			ObjectClass = 0;
			SubClass = 0;
			Level = 54;
			ReqLevel = 54;
			Name = "Deadly Poison IV";
			Name2 = "Deadly Poison IV";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 600;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 3;
			Flags = 64;
			SetSpell( 11356 , 0 , -1 , 0 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Restorative Potion)
*
***************************************************************/

namespace Server.Items
{
	public class RestorativePotion : Item
	{
		public RestorativePotion() : base()
		{
			Id = 9030;
			SellPrice = 200;
			AvailableClasses = 0x7FFF;
			Model = 926;
			ObjectClass = 0;
			SubClass = 0;
			Level = 42;
			ReqLevel = 32;
			Name = "Restorative Potion";
			Name2 = "Restorative Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 800;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 11359 , 0 , -1 , 0 , 4 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Magic Resistance Potion)
*
***************************************************************/

namespace Server.Items
{
	public class MagicResistancePotion : Item
	{
		public MagicResistancePotion() : base()
		{
			Id = 9036;
			SellPrice = 20;
			AvailableClasses = 0x7FFF;
			Model = 1215;
			ObjectClass = 0;
			SubClass = 0;
			Level = 42;
			ReqLevel = 32;
			Name = "Magic Resistance Potion";
			Name2 = "Magic Resistance Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 80;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 11364 , 0 , -1 , 0 , 4 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Gift of Arthas)
*
***************************************************************/

namespace Server.Items
{
	public class GiftOfArthas : Item
	{
		public GiftOfArthas() : base()
		{
			Id = 9088;
			SellPrice = 250;
			AvailableClasses = 0x7FFF;
			Model = 17889;
			ObjectClass = 0;
			SubClass = 0;
			Level = 48;
			ReqLevel = 38;
			Name = "Gift of Arthas";
			Name2 = "Gift of Arthas";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1000;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
			SetSpell( 11371 , 0 , -1 , 0 , 4 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Wildvine Potion)
*
***************************************************************/

namespace Server.Items
{
	public class WildvinePotion : Item
	{
		public WildvinePotion() : base()
		{
			Id = 9144;
			SellPrice = 250;
			AvailableClasses = 0x7FFF;
			Model = 17893;
			ObjectClass = 0;
			SubClass = 0;
			Level = 45;
			ReqLevel = 35;
			Name = "Wildvine Potion";
			Name2 = "Wildvine Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1000;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
			SetSpell( 11387 , 0 , -1 , 0 , 4 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Elixir of Detect Undead)
*
***************************************************************/

namespace Server.Items
{
	public class ElixirOfDetectUndead : Item
	{
		public ElixirOfDetectUndead() : base()
		{
			Id = 9154;
			SellPrice = 300;
			AvailableClasses = 0x7FFF;
			Model = 15714;
			ObjectClass = 0;
			SubClass = 0;
			Level = 46;
			ReqLevel = 36;
			Name = "Elixir of Detect Undead";
			Name2 = "Elixir of Detect Undead";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1200;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
			SetSpell( 11389 , 0 , -1 , 0 , 79 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Arcane Elixir)
*
***************************************************************/

namespace Server.Items
{
	public class ArcaneElixir : Item
	{
		public ArcaneElixir() : base()
		{
			Id = 9155;
			SellPrice = 400;
			AvailableClasses = 0x7FFF;
			Model = 17896;
			ObjectClass = 0;
			SubClass = 0;
			Level = 47;
			ReqLevel = 37;
			Name = "Arcane Elixir";
			Name2 = "Arcane Elixir";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1600;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
			SetSpell( 11390 , 0 , -1 , 0 , 79 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Invisibility Potion)
*
***************************************************************/

namespace Server.Items
{
	public class InvisibilityPotion : Item
	{
		public InvisibilityPotion() : base()
		{
			Id = 9172;
			SellPrice = 500;
			AvailableClasses = 0x7FFF;
			Model = 17898;
			ObjectClass = 0;
			SubClass = 0;
			Level = 47;
			ReqLevel = 37;
			Name = "Invisibility Potion";
			Name2 = "Invisibility Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2000;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 11392 , 0 , -1 , 600000 , 4 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Elixir of Greater Intellect)
*
***************************************************************/

namespace Server.Items
{
	public class ElixirOfGreaterIntellect : Item
	{
		public ElixirOfGreaterIntellect() : base()
		{
			Id = 9179;
			SellPrice = 1000;
			AvailableClasses = 0x7FFF;
			Model = 3664;
			ObjectClass = 0;
			SubClass = 0;
			Level = 47;
			ReqLevel = 37;
			Name = "Elixir of Greater Intellect";
			Name2 = "Elixir of Greater Intellect";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 4000;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 11396 , 0 , -1 , 0 , 79 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Mind-numbing Poison III)
*
***************************************************************/

namespace Server.Items
{
	public class MindNumbingPoisonIII : Item
	{
		public MindNumbingPoisonIII() : base()
		{
			Id = 9186;
			SellPrice = 175;
			AvailableClasses = 0x08;
			Model = 13709;
			ObjectClass = 0;
			SubClass = 0;
			Level = 52;
			ReqLevel = 52;
			Name = "Mind-numbing Poison III";
			Name2 = "Mind-numbing Poison III";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 700;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 3;
			Flags = 64;
			SetSpell( 11399 , 0 , -1 , 0 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Elixir of Greater Agility)
*
***************************************************************/

namespace Server.Items
{
	public class ElixirOfGreaterAgility : Item
	{
		public ElixirOfGreaterAgility() : base()
		{
			Id = 9187;
			SellPrice = 600;
			AvailableClasses = 0x7FFF;
			Model = 17902;
			ObjectClass = 0;
			SubClass = 0;
			Level = 48;
			ReqLevel = 38;
			Name = "Elixir of Greater Agility";
			Name2 = "Elixir of Greater Agility";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2400;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 11334 , 0 , -1 , 0 , 79 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Elixir of Dream Vision)
*
***************************************************************/

namespace Server.Items
{
	public class ElixirOfDreamVision : Item
	{
		public ElixirOfDreamVision() : base()
		{
			Id = 9197;
			SellPrice = 600;
			AvailableClasses = 0x7FFF;
			Model = 4134;
			ObjectClass = 0;
			SubClass = 0;
			Level = 48;
			ReqLevel = 38;
			Name = "Elixir of Dream Vision";
			Name2 = "Elixir of Dream Vision";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2400;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			Flags = 64;
			SetSpell( 11403 , 0 , -1 , 0 , 79 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Elixir of Giants)
*
***************************************************************/

namespace Server.Items
{
	public class ElixirOfGiants : Item
	{
		public ElixirOfGiants() : base()
		{
			Id = 9206;
			SellPrice = 700;
			AvailableClasses = 0x7FFF;
			Model = 17904;
			ObjectClass = 0;
			SubClass = 0;
			Level = 48;
			ReqLevel = 38;
			Name = "Elixir of Giants";
			Name2 = "Elixir of Giants";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2800;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 11405 , 0 , -1 , 0 , 79 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Elixir of Demonslaying)
*
***************************************************************/

namespace Server.Items
{
	public class ElixirOfDemonslaying : Item
	{
		public ElixirOfDemonslaying() : base()
		{
			Id = 9224;
			SellPrice = 700;
			AvailableClasses = 0x7FFF;
			Model = 16325;
			ObjectClass = 0;
			SubClass = 0;
			Level = 50;
			ReqLevel = 40;
			Name = "Elixir of Demonslaying";
			Name2 = "Elixir of Demonslaying";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2800;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 11406 , 0 , -1 , 0 , 79 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Elixir of Detect Demon)
*
***************************************************************/

namespace Server.Items
{
	public class ElixirOfDetectDemon : Item
	{
		public ElixirOfDetectDemon() : base()
		{
			Id = 9233;
			SellPrice = 500;
			AvailableClasses = 0x7FFF;
			Model = 15714;
			ObjectClass = 0;
			SubClass = 0;
			Level = 50;
			ReqLevel = 40;
			Name = "Elixir of Detect Demon";
			Name2 = "Elixir of Detect Demon";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2000;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
			SetSpell( 11407 , 0 , -1 , 0 , 79 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Volatile Rum)
*
***************************************************************/

namespace Server.Items
{
	public class VolatileRum : Item
	{
		public VolatileRum() : base()
		{
			Id = 9260;
			SellPrice = 400;
			AvailableClasses = 0x7FFF;
			Model = 18059;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Volatile Rum";
			Name2 = "Volatile Rum";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1600;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 3;
			SetSpell( 11009 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Elixir of Shadow Power)
*
***************************************************************/

namespace Server.Items
{
	public class ElixirOfShadowPower : Item
	{
		public ElixirOfShadowPower() : base()
		{
			Id = 9264;
			SellPrice = 35;
			AvailableClasses = 0x7FFF;
			Model = 24216;
			ObjectClass = 0;
			SubClass = 0;
			Level = 50;
			ReqLevel = 40;
			Name = "Elixir of Shadow Power";
			Name2 = "Elixir of Shadow Power";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 140;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 11474 , 0 , -1 , 0 , 79 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Default Stationery)
*
***************************************************************/

namespace Server.Items
{
	public class DefaultStationery : Item
	{
		public DefaultStationery() : base()
		{
			Id = 9311;
			AvailableClasses = 0x7FFF;
			Model = 7798;
			ObjectClass = 0;
			SubClass = 0;
			Name = "Default Stationery";
			Name2 = "Default Stationery";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			PageMaterial = 1;
		}
	}
}


/**************************************************************
*
*				(Blue Firework)
*
***************************************************************/

namespace Server.Items
{
	public class BlueFirework : Item
	{
		public BlueFirework() : base()
		{
			Id = 9312;
			SellPrice = 12;
			AvailableClasses = 0x7FFF;
			Model = 18066;
			ObjectClass = 0;
			SubClass = 0;
			Level = 20;
			Name = "Blue Firework";
			Name2 = "Blue Firework";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 50;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
			SetSpell( 11540 , 0 , -1 , 1000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Green Firework)
*
***************************************************************/

namespace Server.Items
{
	public class GreenFirework : Item
	{
		public GreenFirework() : base()
		{
			Id = 9313;
			SellPrice = 12;
			AvailableClasses = 0x7FFF;
			Model = 18067;
			ObjectClass = 0;
			SubClass = 0;
			Level = 20;
			Name = "Green Firework";
			Name2 = "Green Firework";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 50;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
			SetSpell( 11541 , 0 , -1 , 1000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Red Streaks Firework)
*
***************************************************************/

namespace Server.Items
{
	public class RedStreaksFirework : Item
	{
		public RedStreaksFirework() : base()
		{
			Id = 9314;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 18068;
			ObjectClass = 0;
			SubClass = 0;
			Level = 20;
			Name = "Red Streaks Firework";
			Name2 = "Red Streaks Firework";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 100;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
			SetSpell( 11542 , 0 , -1 , 1000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Yellow Rose Firework)
*
***************************************************************/

namespace Server.Items
{
	public class YellowRoseFirework : Item
	{
		public YellowRoseFirework() : base()
		{
			Id = 9315;
			SellPrice = 37;
			AvailableClasses = 0x7FFF;
			Model = 18070;
			ObjectClass = 0;
			SubClass = 0;
			Level = 20;
			Name = "Yellow Rose Firework";
			Name2 = "Yellow Rose Firework";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 150;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
			SetSpell( 11544 , 0 , -1 , 1000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Red, White and Blue Firework)
*
***************************************************************/

namespace Server.Items
{
	public class RedWhiteAndBlueFirework : Item
	{
		public RedWhiteAndBlueFirework() : base()
		{
			Id = 9317;
			SellPrice = 62;
			AvailableClasses = 0x7FFF;
			Model = 18069;
			ObjectClass = 0;
			SubClass = 0;
			Level = 20;
			Name = "Red, White and Blue Firework";
			Name2 = "Red, White and Blue Firework";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 250;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
			SetSpell( 11543 , 0 , -1 , 1000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Red Firework)
*
***************************************************************/

namespace Server.Items
{
	public class RedFirework : Item
	{
		public RedFirework() : base()
		{
			Id = 9318;
			SellPrice = 12;
			AvailableClasses = 0x7FFF;
			Model = 8733;
			ObjectClass = 0;
			SubClass = 0;
			Level = 20;
			Name = "Red Firework";
			Name2 = "Red Firework";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 50;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
			SetSpell( 6668 , 0 , -1 , 1000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Nimboya's Laden Pike)
*
***************************************************************/

namespace Server.Items
{
	public class NimboyasLadenPike : Item
	{
		public NimboyasLadenPike() : base()
		{
			Id = 9319;
			Bonding = 4;
			AvailableClasses = 0x7FFF;
			Model = 25592;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Nimboya's Laden Pike";
			Name2 = "Nimboya's Laden Pike";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 1088;
			SetSpell( 11547 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Cuergo's Gold)
*
***************************************************************/

namespace Server.Items
{
	public class CuergosGold : Item
	{
		public CuergosGold() : base()
		{
			Id = 9360;
			SellPrice = 400;
			AvailableClasses = 0x7FFF;
			Model = 18059;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Cuergo's Gold";
			Name2 = "Cuergo's Gold";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1600;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = 3;
			SetSpell( 11009 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Cuergo's Gold with Worm)
*
***************************************************************/

namespace Server.Items
{
	public class CuergosGoldWithWorm : Item
	{
		public CuergosGoldWithWorm() : base()
		{
			Id = 9361;
			SellPrice = 400;
			AvailableClasses = 0x7FFF;
			Model = 18059;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Cuergo's Gold with Worm";
			Name2 = "Cuergo's Gold with Worm";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1600;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = 3;
			SetSpell( 11629 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Major Healthstone)
*
***************************************************************/

namespace Server.Items
{
	public class MajorHealthstone : Item
	{
		public MajorHealthstone() : base()
		{
			Id = 9421;
			AvailableClasses = 0x7FFF;
			Model = 8026;
			ObjectClass = 0;
			SubClass = 0;
			Level = 58;
			ReqLevel = 48;
			Name = "Major Healthstone";
			Name2 = "Major Healthstone";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Flags = 2;
			SetSpell( 11732 , 0 , -1 , 0 , 30 , 180000 );
		}
	}
}


/**************************************************************
*
*				(Bubbling Water)
*
***************************************************************/

namespace Server.Items
{
	public class BubblingWater : Item
	{
		public BubblingWater() : base()
		{
			Id = 9451;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 926;
			ObjectClass = 0;
			SubClass = 0;
			Level = 25;
			ReqLevel = 15;
			Name = "Bubbling Water";
			Name2 = "Bubbling Water";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 500;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 7;
			SetSpell( 432 , 0 , -1 , 0 , 59 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Simple Scroll)
*
***************************************************************/

namespace Server.Items
{
	public class SimpleScroll : Item
	{
		public SimpleScroll() : base()
		{
			Id = 9546;
			Bonding = 4;
			AvailableClasses = 0x7FFF;
			Model = 1301;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Simple Scroll";
			Name2 = "Simple Scroll";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			PageText = 2443;
			PageMaterial = 1;
		}
	}
}


/**************************************************************
*
*				(Hallowed Scroll)
*
***************************************************************/

namespace Server.Items
{
	public class HallowedScroll : Item
	{
		public HallowedScroll() : base()
		{
			Id = 9569;
			Bonding = 4;
			AvailableClasses = 0x7FFF;
			Model = 1301;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Hallowed Scroll";
			Name2 = "Hallowed Scroll";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			PageText = 2467;
			PageMaterial = 1;
		}
	}
}


/**************************************************************
*
*				(Grilled King Crawler Legs)
*
***************************************************************/

namespace Server.Items
{
	public class GrilledKingCrawlerLegs : Item
	{
		public GrilledKingCrawlerLegs() : base()
		{
			Id = 9681;
			SellPrice = 50;
			AvailableClasses = 0x7FFF;
			Model = 7980;
			ObjectClass = 0;
			SubClass = 0;
			Level = 45;
			ReqLevel = 35;
			Name = "Grilled King Crawler Legs";
			Name2 = "Grilled King Crawler Legs";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 1129 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Scroll of Protection IV)
*
***************************************************************/

namespace Server.Items
{
	public class ScrollOfProtectionIV : Item
	{
		public ScrollOfProtectionIV() : base()
		{
			Id = 10305;
			SellPrice = 100;
			AvailableClasses = 0x7FFF;
			Model = 1093;
			ObjectClass = 0;
			SubClass = 0;
			Level = 55;
			ReqLevel = 45;
			Name = "Scroll of Protection IV";
			Name2 = "Scroll of Protection IV";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 550;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 7;
			SetSpell( 12175 , 0 , -1 , 1000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Scroll of Spirit IV)
*
***************************************************************/

namespace Server.Items
{
	public class ScrollOfSpiritIV : Item
	{
		public ScrollOfSpiritIV() : base()
		{
			Id = 10306;
			SellPrice = 100;
			AvailableClasses = 0x7FFF;
			Model = 2616;
			ObjectClass = 0;
			SubClass = 0;
			Level = 55;
			ReqLevel = 45;
			Name = "Scroll of Spirit IV";
			Name2 = "Scroll of Spirit IV";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 550;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 7;
			SetSpell( 12177 , 0 , -1 , 1000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Scroll of Stamina IV)
*
***************************************************************/

namespace Server.Items
{
	public class ScrollOfStaminaIV : Item
	{
		public ScrollOfStaminaIV() : base()
		{
			Id = 10307;
			SellPrice = 112;
			AvailableClasses = 0x7FFF;
			Model = 1093;
			ObjectClass = 0;
			SubClass = 0;
			Level = 60;
			ReqLevel = 50;
			Name = "Scroll of Stamina IV";
			Name2 = "Scroll of Stamina IV";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 600;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 7;
			SetSpell( 12178 , 0 , -1 , 1000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Scroll of Intellect IV)
*
***************************************************************/

namespace Server.Items
{
	public class ScrollOfIntellectIV : Item
	{
		public ScrollOfIntellectIV() : base()
		{
			Id = 10308;
			SellPrice = 112;
			AvailableClasses = 0x7FFF;
			Model = 2616;
			ObjectClass = 0;
			SubClass = 0;
			Level = 60;
			ReqLevel = 50;
			Name = "Scroll of Intellect IV";
			Name2 = "Scroll of Intellect IV";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 600;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 7;
			Sheath = 1;
			SetSpell( 12176 , 0 , -1 , 1000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Scroll of Agility IV)
*
***************************************************************/

namespace Server.Items
{
	public class ScrollOfAgilityIV : Item
	{
		public ScrollOfAgilityIV() : base()
		{
			Id = 10309;
			SellPrice = 125;
			AvailableClasses = 0x7FFF;
			Model = 3331;
			ObjectClass = 0;
			SubClass = 0;
			Level = 65;
			ReqLevel = 55;
			Name = "Scroll of Agility IV";
			Name2 = "Scroll of Agility IV";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 650;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 7;
			SetSpell( 12174 , 0 , -1 , 1000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Scroll of Strength IV)
*
***************************************************************/

namespace Server.Items
{
	public class ScrollOfStrengthIV : Item
	{
		public ScrollOfStrengthIV() : base()
		{
			Id = 10310;
			SellPrice = 125;
			AvailableClasses = 0x7FFF;
			Model = 3331;
			ObjectClass = 0;
			SubClass = 0;
			Level = 65;
			ReqLevel = 55;
			Name = "Scroll of Strength IV";
			Name2 = "Scroll of Strength IV";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 650;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 7;
			SetSpell( 12179 , 0 , -1 , 1000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Catseye Elixir)
*
***************************************************************/

namespace Server.Items
{
	public class CatseyeElixir : Item
	{
		public CatseyeElixir() : base()
		{
			Id = 10592;
			SellPrice = 150;
			AvailableClasses = 0x7FFF;
			Model = 19520;
			ObjectClass = 0;
			SubClass = 0;
			Level = 40;
			ReqLevel = 30;
			Name = "Catseye Elixir";
			Name2 = "Catseye Elixir";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 600;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 12608 , 0 , -1 , 0 , 79 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Runed Scroll)
*
***************************************************************/

namespace Server.Items
{
	public class RunedScroll : Item
	{
		public RunedScroll() : base()
		{
			Id = 10621;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 1301;
			ObjectClass = 0;
			SubClass = 0;
			Level = 15;
			ReqLevel = 15;
			Name = "Runed Scroll";
			Name2 = "Runed Scroll";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			StartQuest = 3513;
			MaxCount = 1;
			Material = -1;
			Flags = 2048;
		}
	}
}


/**************************************************************
*
*				(Essence of Hakkar)
*
***************************************************************/

namespace Server.Items
{
	public class EssenceOfHakkar : Item
	{
		public EssenceOfHakkar() : base()
		{
			Id = 10663;
			Bonding = 4;
			AvailableClasses = 0x7FFF;
			Model = 19576;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Essence of Hakkar";
			Name2 = "Essence of Hakkar";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 3136;
			SetSpell( 12735 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Colossal Parachute)
*
***************************************************************/

namespace Server.Items
{
	public class ColossalParachute : Item
	{
		public ColossalParachute() : base()
		{
			Id = 10684;
			Bonding = 1;
			SellPrice = 500;
			AvailableClasses = 0x7FFF;
			Model = 19606;
			ObjectClass = 0;
			SubClass = 0;
			Level = 25;
			Name = "Colossal Parachute";
			Name2 = "Colossal Parachute";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			SetSpell( 12438 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Empty Vial Labeled #1)
*
***************************************************************/

namespace Server.Items
{
	public class EmptyVialLabeled1 : Item
	{
		public EmptyVialLabeled1() : base()
		{
			Id = 10687;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 18077;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Empty Vial Labeled #1";
			Name2 = "Empty Vial Labeled #1";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 12802 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Empty Vial Labeled #2)
*
***************************************************************/

namespace Server.Items
{
	public class EmptyVialLabeled2 : Item
	{
		public EmptyVialLabeled2() : base()
		{
			Id = 10688;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 18077;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Empty Vial Labeled #2";
			Name2 = "Empty Vial Labeled #2";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 12805 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Empty Vial Labeled #3)
*
***************************************************************/

namespace Server.Items
{
	public class EmptyVialLabeled3 : Item
	{
		public EmptyVialLabeled3() : base()
		{
			Id = 10689;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 18077;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Empty Vial Labeled #3";
			Name2 = "Empty Vial Labeled #3";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 12806 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Empty Vial Labeled #4)
*
***************************************************************/

namespace Server.Items
{
	public class EmptyVialLabeled4 : Item
	{
		public EmptyVialLabeled4() : base()
		{
			Id = 10690;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 18077;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Empty Vial Labeled #4";
			Name2 = "Empty Vial Labeled #4";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 12808 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(M73 Frag Grenade)
*
***************************************************************/

namespace Server.Items
{
	public class M73FragGrenade : Item
	{
		public M73FragGrenade() : base()
		{
			Id = 10830;
			Bonding = 1;
			SellPrice = 750;
			AvailableClasses = 0x7FFF;
			Model = 25482;
			ObjectClass = 0;
			SubClass = 0;
			Level = 53;
			Name = "M73 Frag Grenade";
			Name2 = "M73 Frag Grenade";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 3000;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 8;
			Flags = 64;
			SetSpell( 13808 , 0 , -1 , 0 , 24 , 60000 );
		}
	}
}


/**************************************************************
*
*				(Goldthorn Tea)
*
***************************************************************/

namespace Server.Items
{
	public class GoldthornTea : Item
	{
		public GoldthornTea() : base()
		{
			Id = 10841;
			SellPrice = 85;
			AvailableClasses = 0x7FFF;
			Model = 19873;
			ObjectClass = 0;
			SubClass = 0;
			Level = 35;
			ReqLevel = 25;
			Name = "Goldthorn Tea";
			Name2 = "Goldthorn Tea";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 340;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 3;
			SetSpell( 1133 , 0 , -1 , 0 , 59 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Wound Poison)
*
***************************************************************/

namespace Server.Items
{
	public class WoundPoison : Item
	{
		public WoundPoison() : base()
		{
			Id = 10918;
			SellPrice = 42;
			AvailableClasses = 0x08;
			Model = 13708;
			ObjectClass = 0;
			SubClass = 0;
			Level = 32;
			ReqLevel = 32;
			Name = "Wound Poison";
			Name2 = "Wound Poison";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 170;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 3;
			Flags = 64;
			SetSpell( 13219 , 0 , -1 , 0 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Wound Poison II)
*
***************************************************************/

namespace Server.Items
{
	public class WoundPoisonII : Item
	{
		public WoundPoisonII() : base()
		{
			Id = 10920;
			SellPrice = 67;
			AvailableClasses = 0x08;
			Model = 13708;
			ObjectClass = 0;
			SubClass = 0;
			Level = 40;
			ReqLevel = 40;
			Name = "Wound Poison II";
			Name2 = "Wound Poison II";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 270;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 3;
			Flags = 64;
			SetSpell( 13225 , 0 , -1 , 0 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Wound Poison III)
*
***************************************************************/

namespace Server.Items
{
	public class WoundPoisonIII : Item
	{
		public WoundPoisonIII() : base()
		{
			Id = 10921;
			SellPrice = 125;
			AvailableClasses = 0x08;
			Model = 13708;
			ObjectClass = 0;
			SubClass = 0;
			Level = 48;
			ReqLevel = 48;
			Name = "Wound Poison III";
			Name2 = "Wound Poison III";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 500;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 3;
			Flags = 64;
			SetSpell( 13226 , 0 , -1 , 0 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Wound Poison IV)
*
***************************************************************/

namespace Server.Items
{
	public class WoundPoisonIV : Item
	{
		public WoundPoisonIV() : base()
		{
			Id = 10922;
			SellPrice = 175;
			AvailableClasses = 0x08;
			Model = 13708;
			ObjectClass = 0;
			SubClass = 0;
			Level = 56;
			ReqLevel = 56;
			Name = "Wound Poison IV";
			Name2 = "Wound Poison IV";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 700;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 3;
			Flags = 64;
			SetSpell( 13227 , 0 , -1 , 0 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Special Chicken Feed)
*
***************************************************************/

namespace Server.Items
{
	public class SpecialChickenFeed : Item
	{
		public SpecialChickenFeed() : base()
		{
			Id = 11109;
			SellPrice = 6;
			AvailableClasses = 0x7FFF;
			Model = 7087;
			ObjectClass = 0;
			SubClass = 0;
			Level = 5;
			ReqLevel = 1;
			Name = "Special Chicken Feed";
			Name2 = "Special Chicken Feed";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 25;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			SetSpell( 7737 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Samophlange Manual Page)
*
***************************************************************/

namespace Server.Items
{
	public class SamophlangeManualPage : Item
	{
		public SamophlangeManualPage() : base()
		{
			Id = 11148;
			Bonding = 4;
			AvailableClasses = 0x7FFF;
			Model = 7629;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Samophlange Manual Page";
			Name2 = "Samophlange Manual Page";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			Flags = 1088;
			SetSpell( 14199 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Dark Keeper Key)
*
***************************************************************/

namespace Server.Items
{
	public class DarkKeeperKey : Item
	{
		public DarkKeeperKey() : base()
		{
			Id = 11197;
			AvailableClasses = 0x7FFF;
			Model = 20983;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Dark Keeper Key";
			Name2 = "Dark Keeper Key";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 13564 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Dark Iron Ale Mug)
*
***************************************************************/

namespace Server.Items
{
	public class DarkIronAleMug : Item
	{
		public DarkIronAleMug() : base()
		{
			Id = 11325;
			SellPrice = 150;
			AvailableClasses = 0x7FFF;
			Model = 18099;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Dark Iron Ale Mug";
			Name2 = "Dark Iron Ale Mug";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 600;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			Flags = 64;
			SetSpell( 14814 , 0 , -1 , 1000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Giant Silver Vein)
*
***************************************************************/

namespace Server.Items
{
	public class GiantSilverVein : Item
	{
		public GiantSilverVein() : base()
		{
			Id = 11405;
			Bonding = 4;
			AvailableClasses = 0x7FFF;
			Model = 21367;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Giant Silver Vein";
			Name2 = "Giant Silver Vein";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Nagmara's Filled Vial)
*
***************************************************************/

namespace Server.Items
{
	public class NagmarasFilledVial : Item
	{
		public NagmarasFilledVial() : base()
		{
			Id = 11413;
			Bonding = 4;
			AvailableClasses = 0x7FFF;
			Model = 4136;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Nagmara's Filled Vial";
			Name2 = "Nagmara's Filled Vial";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Mixed Berries)
*
***************************************************************/

namespace Server.Items
{
	public class MixedBerries : Item
	{
		public MixedBerries() : base()
		{
			Id = 11415;
			SellPrice = 200;
			AvailableClasses = 0x7FFF;
			Model = 21369;
			ObjectClass = 0;
			SubClass = 0;
			Level = 55;
			ReqLevel = 45;
			Name = "Mixed Berries";
			Name2 = "Mixed Berries";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 4000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 1131 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Grim Guzzler Boar)
*
***************************************************************/

namespace Server.Items
{
	public class GrimGuzzlerBoar : Item
	{
		public GrimGuzzlerBoar() : base()
		{
			Id = 11444;
			SellPrice = 200;
			AvailableClasses = 0x7FFF;
			Model = 2376;
			ObjectClass = 0;
			SubClass = 0;
			Level = 55;
			ReqLevel = 45;
			Name = "Grim Guzzler Boar";
			Name2 = "Grim Guzzler Boar";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 4000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 1131 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Cactus Apple Surprise)
*
***************************************************************/

namespace Server.Items
{
	public class CactusAppleSurprise : Item
	{
		public CactusAppleSurprise() : base()
		{
			Id = 11584;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 6410;
			ObjectClass = 0;
			SubClass = 0;
			Level = 5;
			Name = "Cactus Apple Surprise";
			Name2 = "Cactus Apple Surprise";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 25;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 5004 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Wizbang's Special Brew)
*
***************************************************************/

namespace Server.Items
{
	public class WizbangsSpecialBrew : Item
	{
		public WizbangsSpecialBrew() : base()
		{
			Id = 11846;
			SellPrice = 30;
			AvailableClasses = 0x7FFF;
			Model = 21845;
			ObjectClass = 0;
			SubClass = 0;
			Level = 15;
			Name = "Wizbang's Special Brew";
			Name2 = "Wizbang's Special Brew";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 120;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 11008 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Shadowforge Torch)
*
***************************************************************/

namespace Server.Items
{
	public class ShadowforgeTorch : Item
	{
		public ShadowforgeTorch() : base()
		{
			Id = 11885;
			SellPrice = 711;
			AvailableClasses = 0x7FFF;
			Model = 12738;
			ObjectClass = 0;
			SubClass = 0;
			Level = 60;
			Name = "Shadowforge Torch";
			Name2 = "Shadowforge Torch";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2846;
			InventoryType = InventoryTypes.None;
			Delay = 500;
			Stackable = 1;
			Material = -1;
			Sheath = 7;
			Flags = 64;
			SetSpell( 3366 , 0 , -1 , 0 , 0 , 0 );
		}
	}
}


/**************************************************************
*
*				(Empty Cursed Ooze Jar)
*
***************************************************************/

namespace Server.Items
{
	public class EmptyCursedOozeJar : Item
	{
		public EmptyCursedOozeJar() : base()
		{
			Id = 11914;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 20791;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Empty Cursed Ooze Jar";
			Name2 = "Empty Cursed Ooze Jar";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			Flags = 64;
			SetSpell( 15698 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Empty Tainted Ooze Jar)
*
***************************************************************/

namespace Server.Items
{
	public class EmptyTaintedOozeJar : Item
	{
		public EmptyTaintedOozeJar() : base()
		{
			Id = 11948;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 20791;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Empty Tainted Ooze Jar";
			Name2 = "Empty Tainted Ooze Jar";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			Flags = 64;
			SetSpell( 15699 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Windblossom Berries)
*
***************************************************************/

namespace Server.Items
{
	public class WindblossomBerries : Item
	{
		public WindblossomBerries() : base()
		{
			Id = 11950;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 21973;
			ObjectClass = 0;
			SubClass = 0;
			Level = 55;
			ReqLevel = 45;
			Name = "Windblossom Berries";
			Name2 = "Windblossom Berries";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 18234 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Whipper Root Tuber)
*
***************************************************************/

namespace Server.Items
{
	public class WhipperRootTuber : Item
	{
		public WhipperRootTuber() : base()
		{
			Id = 11951;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 21974;
			ObjectClass = 0;
			SubClass = 0;
			Level = 55;
			ReqLevel = 45;
			Name = "Whipper Root Tuber";
			Name2 = "Whipper Root Tuber";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 15700 , 0 , -1 , 60000 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Night Dragon's Breath)
*
***************************************************************/

namespace Server.Items
{
	public class NightDragonsBreath : Item
	{
		public NightDragonsBreath() : base()
		{
			Id = 11952;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 21975;
			ObjectClass = 0;
			SubClass = 0;
			Level = 55;
			ReqLevel = 45;
			Name = "Night Dragon's Breath";
			Name2 = "Night Dragon's Breath";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 15701 , 0 , -1 , 60000 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Empty Pure Sample Jar)
*
***************************************************************/

namespace Server.Items
{
	public class EmptyPureSampleJar : Item
	{
		public EmptyPureSampleJar() : base()
		{
			Id = 11953;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 20791;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Empty Pure Sample Jar";
			Name2 = "Empty Pure Sample Jar";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			Flags = 64;
			SetSpell( 15702 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Dark Dwarven Lager)
*
***************************************************************/

namespace Server.Items
{
	public class DarkDwarvenLager : Item
	{
		public DarkDwarvenLager() : base()
		{
			Id = 12003;
			SellPrice = 250;
			AvailableClasses = 0x7FFF;
			Model = 18115;
			ObjectClass = 0;
			SubClass = 0;
			Level = 55;
			Name = "Dark Dwarven Lager";
			Name2 = "Dark Dwarven Lager";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 3;
			SetSpell( 11629 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Dreamless Sleep Potion)
*
***************************************************************/

namespace Server.Items
{
	public class DreamlessSleepPotion : Item
	{
		public DreamlessSleepPotion() : base()
		{
			Id = 12190;
			SellPrice = 250;
			AvailableClasses = 0x7FFF;
			Model = 17403;
			ObjectClass = 0;
			SubClass = 0;
			Level = 45;
			ReqLevel = 35;
			Name = "Dreamless Sleep Potion";
			Name2 = "Dreamless Sleep Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1000;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
			Flags = 64;
			SetSpell( 15822 , 0 , -1 , 0 , 4 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Lean Wolf Steak)
*
***************************************************************/

namespace Server.Items
{
	public class LeanWolfSteak : Item
	{
		public LeanWolfSteak() : base()
		{
			Id = 12209;
			SellPrice = 95;
			AvailableClasses = 0x7FFF;
			Model = 22194;
			ObjectClass = 0;
			SubClass = 0;
			Level = 25;
			ReqLevel = 15;
			Name = "Lean Wolf Steak";
			Name2 = "Lean Wolf Steak";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 380;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 5006 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Roast Raptor)
*
***************************************************************/

namespace Server.Items
{
	public class RoastRaptor : Item
	{
		public RoastRaptor() : base()
		{
			Id = 12210;
			SellPrice = 300;
			AvailableClasses = 0x7FFF;
			Model = 20803;
			ObjectClass = 0;
			SubClass = 0;
			Level = 35;
			ReqLevel = 25;
			Name = "Roast Raptor";
			Name2 = "Roast Raptor";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1200;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 5007 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Jungle Stew)
*
***************************************************************/

namespace Server.Items
{
	public class JungleStew : Item
	{
		public JungleStew() : base()
		{
			Id = 12212;
			SellPrice = 300;
			AvailableClasses = 0x7FFF;
			Model = 21473;
			ObjectClass = 0;
			SubClass = 0;
			Level = 35;
			ReqLevel = 25;
			Name = "Jungle Stew";
			Name2 = "Jungle Stew";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1200;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 5007 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Carrion Surprise)
*
***************************************************************/

namespace Server.Items
{
	public class CarrionSurprise : Item
	{
		public CarrionSurprise() : base()
		{
			Id = 12213;
			SellPrice = 300;
			AvailableClasses = 0x7FFF;
			Model = 22197;
			ObjectClass = 0;
			SubClass = 0;
			Level = 35;
			ReqLevel = 25;
			Name = "Carrion Surprise";
			Name2 = "Carrion Surprise";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1200;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 5007 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Mystery Stew)
*
***************************************************************/

namespace Server.Items
{
	public class MysteryStew : Item
	{
		public MysteryStew() : base()
		{
			Id = 12214;
			SellPrice = 300;
			AvailableClasses = 0x7FFF;
			Model = 22198;
			ObjectClass = 0;
			SubClass = 0;
			Level = 35;
			ReqLevel = 25;
			Name = "Mystery Stew";
			Name2 = "Mystery Stew";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1200;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 5007 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Heavy Kodo Stew)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyKodoStew : Item
	{
		public HeavyKodoStew() : base()
		{
			Id = 12215;
			SellPrice = 300;
			AvailableClasses = 0x7FFF;
			Model = 22198;
			ObjectClass = 0;
			SubClass = 0;
			Level = 40;
			ReqLevel = 35;
			Name = "Heavy Kodo Stew";
			Name2 = "Heavy Kodo Stew";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1200;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 10256 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Spiced Chili Crab)
*
***************************************************************/

namespace Server.Items
{
	public class SpicedChiliCrab : Item
	{
		public SpicedChiliCrab() : base()
		{
			Id = 12216;
			SellPrice = 300;
			AvailableClasses = 0x7FFF;
			Model = 22196;
			ObjectClass = 0;
			SubClass = 0;
			Level = 45;
			ReqLevel = 40;
			Name = "Spiced Chili Crab";
			Name2 = "Spiced Chili Crab";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1200;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 10256 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Dragonbreath Chili)
*
***************************************************************/

namespace Server.Items
{
	public class DragonbreathChili : Item
	{
		public DragonbreathChili() : base()
		{
			Id = 12217;
			SellPrice = 300;
			AvailableClasses = 0x7FFF;
			Model = 21473;
			ObjectClass = 0;
			SubClass = 0;
			Level = 40;
			ReqLevel = 35;
			Name = "Dragonbreath Chili";
			Name2 = "Dragonbreath Chili";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1200;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			Flags = 64;
			SetSpell( 15852 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Monster Omelet)
*
***************************************************************/

namespace Server.Items
{
	public class MonsterOmelet : Item
	{
		public MonsterOmelet() : base()
		{
			Id = 12218;
			SellPrice = 300;
			AvailableClasses = 0x7FFF;
			Model = 6353;
			ObjectClass = 0;
			SubClass = 0;
			Level = 45;
			ReqLevel = 40;
			Name = "Monster Omelet";
			Name2 = "Monster Omelet";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1200;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 10256 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Crispy Bat Wing)
*
***************************************************************/

namespace Server.Items
{
	public class CrispyBatWing : Item
	{
		public CrispyBatWing() : base()
		{
			Id = 12224;
			SellPrice = 10;
			AvailableClasses = 0x7FFF;
			Model = 22200;
			ObjectClass = 0;
			SubClass = 0;
			Level = 7;
			ReqLevel = 1;
			Name = "Crispy Bat Wing";
			Name2 = "Crispy Bat Wing";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 40;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 5004 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Darkshore Grouper)
*
***************************************************************/

namespace Server.Items
{
	public class DarkshoreGrouper : Item
	{
		public DarkshoreGrouper() : base()
		{
			Id = 12238;
			SellPrice = 2;
			AvailableClasses = 0x7FFF;
			Model = 24698;
			ObjectClass = 0;
			SubClass = 0;
			Level = 15;
			ReqLevel = 5;
			Name = "Darkshore Grouper";
			Name2 = "Darkshore Grouper";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 40;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 434 , 0 , -1 , 0 , 0 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Roughshod Pike)
*
***************************************************************/

namespace Server.Items
{
	public class RoughshodPike : Item
	{
		public RoughshodPike() : base()
		{
			Id = 12533;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 18125;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Roughshod Pike";
			Name2 = "Roughshod Pike";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 1088;
		}
	}
}


/**************************************************************
*
*				(Immature Venom Sac)
*
***************************************************************/

namespace Server.Items
{
	public class ImmatureVenomSac : Item
	{
		public ImmatureVenomSac() : base()
		{
			Id = 12586;
			AvailableClasses = 0x7FFF;
			Description = "Protects the brood against Mother's Milk. Efficacy decays over time.";
			Model = 22793;
			ObjectClass = 0;
			SubClass = 0;
			Level = 50;
			Name = "Immature Venom Sac";
			Name2 = "Immature Venom Sac";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 50;
			Material = -1;
			Flags = 64;
			SetSpell( 16537 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Attuned Dampener)
*
***************************************************************/

namespace Server.Items
{
	public class AttunedDampener : Item
	{
		public AttunedDampener() : base()
		{
			Id = 12650;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Description = "This object has been attuned to work against a specific being.";
			Model = 22926;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Attuned Dampener";
			Name2 = "Attuned Dampener";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 16629 , 0 , -1 , 60000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Warosh's Mojo)
*
***************************************************************/

namespace Server.Items
{
	public class WaroshsMojo : Item
	{
		public WaroshsMojo() : base()
		{
			Id = 12712;
			Bonding = 4;
			AvailableClasses = 0x7FFF;
			Model = 15794;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Warosh's Mojo";
			Name2 = "Warosh's Mojo";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 2048;
		}
	}
}


/**************************************************************
*
*				(Winterfall Firewater)
*
***************************************************************/

namespace Server.Items
{
	public class WinterfallFirewater : Item
	{
		public WinterfallFirewater() : base()
		{
			Id = 12820;
			AvailableClasses = 0x7FFF;
			Model = 15787;
			ObjectClass = 0;
			SubClass = 0;
			Level = 50;
			ReqLevel = 45;
			Name = "Winterfall Firewater";
			Name2 = "Winterfall Firewater";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
			Language = 7;
			PageMaterial = 1;
			SetSpell( 17038 , 0 , -1 , 60000 , 0 , 60000 );
		}
	}
}


/**************************************************************
*
*				(Arnak's Hoof)
*
***************************************************************/

namespace Server.Items
{
	public class ArnaksHoof : Item
	{
		public ArnaksHoof() : base()
		{
			Id = 12884;
			Bonding = 4;
			AvailableClasses = 0x7FFF;
			Model = 23358;
			ObjectClass = 0;
			SubClass = 0;
			Name = "Arnak's Hoof";
			Name2 = "Arnak's Hoof";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 2048;
		}
	}
}


/**************************************************************
*
*				(Pamela's Doll)
*
***************************************************************/

namespace Server.Items
{
	public class PamelasDoll : Item
	{
		public PamelasDoll() : base()
		{
			Id = 12885;
			Bonding = 4;
			AvailableClasses = 0x7FFF;
			Model = 2622;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Pamela's Doll";
			Name2 = "Pamela's Doll";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Pamela's Doll's Head)
*
***************************************************************/

namespace Server.Items
{
	public class PamelasDollsHead : Item
	{
		public PamelasDollsHead() : base()
		{
			Id = 12886;
			Bonding = 4;
			AvailableClasses = 0x7FFF;
			Model = 23370;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Pamela's Doll's Head";
			Name2 = "Pamela's Doll's Head";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 1088;
			SetSpell( 17133 , 0 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Joseph's Wedding Ring)
*
***************************************************************/

namespace Server.Items
{
	public class JosephsWeddingRing : Item
	{
		public JosephsWeddingRing() : base()
		{
			Id = 12894;
			Bonding = 4;
			AvailableClasses = 0x7FFF;
			Model = 224;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Joseph's Wedding Ring";
			Name2 = "Joseph's Wedding Ring";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Empty Canteen)
*
***************************************************************/

namespace Server.Items
{
	public class EmptyCanteen : Item
	{
		public EmptyCanteen() : base()
		{
			Id = 12922;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 18057;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Empty Canteen";
			Name2 = "Empty Canteen";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 64;
			SetSpell( 17161 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Ritual Candle)
*
***************************************************************/

namespace Server.Items
{
	public class RitualCandle : Item
	{
		public RitualCandle() : base()
		{
			Id = 12924;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Description = "A ritual candle from the depths of Jaedenar, new home of the Shadow Council.";
			Model = 6623;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Ritual Candle";
			Name2 = "Ritual Candle";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			MaxCount = 5;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Resonating Skull)
*
***************************************************************/

namespace Server.Items
{
	public class ResonatingSkull : Item
	{
		public ResonatingSkull() : base()
		{
			Id = 13155;
			Bonding = 4;
			AvailableClasses = 0x7FFF;
			Model = 23658;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Resonating Skull";
			Name2 = "Resonating Skull";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Mystic Crystal)
*
***************************************************************/

namespace Server.Items
{
	public class MysticCrystal : Item
	{
		public MysticCrystal() : base()
		{
			Id = 13156;
			Bonding = 4;
			AvailableClasses = 0x7FFF;
			Model = 2516;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Mystic Crystal";
			Name2 = "Mystic Crystal";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 1088;
			SetSpell( 17271 , 0 , 0 , 1000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Wrapped Gift)
*
***************************************************************/

namespace Server.Items
{
	public class WrappedGift : Item
	{
		public WrappedGift() : base()
		{
			Id = 13367;
			AvailableClasses = 0x7FFF;
			Model = 24053;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Wrapped Gift";
			Name2 = "Wrapped Gift";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Mighty Rage Potion)
*
***************************************************************/

namespace Server.Items
{
	public class MightyRagePotion : Item
	{
		public MightyRagePotion() : base()
		{
			Id = 13442;
			SellPrice = 500;
			AvailableClasses = 0x01;
			Model = 19547;
			ObjectClass = 0;
			SubClass = 0;
			Level = 51;
			ReqLevel = 46;
			Name = "Mighty Rage Potion";
			Name2 = "Mighty Rage Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2000;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
			SetSpell( 17528 , 0 , -1 , 0 , 4 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Superior Mana Potion)
*
***************************************************************/

namespace Server.Items
{
	public class SuperiorManaPotion : Item
	{
		public SuperiorManaPotion() : base()
		{
			Id = 13443;
			SellPrice = 400;
			AvailableClasses = 0x7FFF;
			Model = 24151;
			ObjectClass = 0;
			SubClass = 0;
			Level = 51;
			ReqLevel = 41;
			Name = "Superior Mana Potion";
			Name2 = "Superior Mana Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1600;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 17530 , 0 , -1 , 0 , 4 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Major Mana Potion)
*
***************************************************************/

namespace Server.Items
{
	public class MajorManaPotion : Item
	{
		public MajorManaPotion() : base()
		{
			Id = 13444;
			SellPrice = 1500;
			AvailableClasses = 0x7FFF;
			Model = 21672;
			ObjectClass = 0;
			SubClass = 0;
			Level = 59;
			ReqLevel = 49;
			Name = "Major Mana Potion";
			Name2 = "Major Mana Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 6000;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 17531 , 0 , -1 , 0 , 4 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Elixir of Superior Defense)
*
***************************************************************/

namespace Server.Items
{
	public class ElixirOfSuperiorDefense : Item
	{
		public ElixirOfSuperiorDefense() : base()
		{
			Id = 13445;
			SellPrice = 500;
			AvailableClasses = 0x7FFF;
			Model = 16321;
			ObjectClass = 0;
			SubClass = 0;
			Level = 53;
			ReqLevel = 43;
			Name = "Elixir of Superior Defense";
			Name2 = "Elixir of Superior Defense";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2000;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 11348 , 0 , -1 , 0 , 79 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Major Healing Potion)
*
***************************************************************/

namespace Server.Items
{
	public class MajorHealingPotion : Item
	{
		public MajorHealingPotion() : base()
		{
			Id = 13446;
			SellPrice = 1000;
			AvailableClasses = 0x7FFF;
			Model = 24152;
			ObjectClass = 0;
			SubClass = 0;
			Level = 55;
			ReqLevel = 45;
			Name = "Major Healing Potion";
			Name2 = "Major Healing Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 4000;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
			SetSpell( 17534 , 0 , -1 , 0 , 4 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Elixir of the Sages)
*
***************************************************************/

namespace Server.Items
{
	public class ElixirOfTheSages : Item
	{
		public ElixirOfTheSages() : base()
		{
			Id = 13447;
			SellPrice = 1250;
			AvailableClasses = 0x7FFF;
			Model = 24211;
			ObjectClass = 0;
			SubClass = 0;
			Level = 54;
			ReqLevel = 44;
			Name = "Elixir of the Sages";
			Name2 = "Elixir of the Sages";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 5000;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 17535 , 0 , -1 , 0 , 79 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Elixir of the Mongoose)
*
***************************************************************/

namespace Server.Items
{
	public class ElixirOfTheMongoose : Item
	{
		public ElixirOfTheMongoose() : base()
		{
			Id = 13452;
			SellPrice = 1250;
			AvailableClasses = 0x7FFF;
			Model = 16836;
			ObjectClass = 0;
			SubClass = 0;
			Level = 56;
			ReqLevel = 46;
			Name = "Elixir of the Mongoose";
			Name2 = "Elixir of the Mongoose";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 5000;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 17538 , 0 , -1 , 0 , 79 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Elixir of Brute Force)
*
***************************************************************/

namespace Server.Items
{
	public class ElixirOfBruteForce : Item
	{
		public ElixirOfBruteForce() : base()
		{
			Id = 13453;
			SellPrice = 1250;
			AvailableClasses = 0x7FFF;
			Model = 24212;
			ObjectClass = 0;
			SubClass = 0;
			Level = 55;
			ReqLevel = 45;
			Name = "Elixir of Brute Force";
			Name2 = "Elixir of Brute Force";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 5000;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 17537 , 0 , -1 , 0 , 79 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Greater Arcane Elixir)
*
***************************************************************/

namespace Server.Items
{
	public class GreaterArcaneElixir : Item
	{
		public GreaterArcaneElixir() : base()
		{
			Id = 13454;
			SellPrice = 750;
			AvailableClasses = 0x7FFF;
			Model = 17898;
			ObjectClass = 0;
			SubClass = 0;
			Level = 57;
			ReqLevel = 47;
			Name = "Greater Arcane Elixir";
			Name2 = "Greater Arcane Elixir";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 3000;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
			SetSpell( 17539 , 0 , -1 , 0 , 79 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Greater Stoneshield Potion)
*
***************************************************************/

namespace Server.Items
{
	public class GreaterStoneshieldPotion : Item
	{
		public GreaterStoneshieldPotion() : base()
		{
			Id = 13455;
			SellPrice = 750;
			AvailableClasses = 0x7FFF;
			Model = 17974;
			ObjectClass = 0;
			SubClass = 0;
			Level = 56;
			ReqLevel = 46;
			Name = "Greater Stoneshield Potion";
			Name2 = "Greater Stoneshield Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 3000;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 17540 , 0 , -1 , 0 , 4 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Greater Frost Protection Potion)
*
***************************************************************/

namespace Server.Items
{
	public class GreaterFrostProtectionPotion : Item
	{
		public GreaterFrostProtectionPotion() : base()
		{
			Id = 13456;
			SellPrice = 750;
			AvailableClasses = 0x7FFF;
			Model = 15794;
			ObjectClass = 0;
			SubClass = 0;
			Level = 58;
			ReqLevel = 48;
			Name = "Greater Frost Protection Potion";
			Name2 = "Greater Frost Protection Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 3000;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 17544 , 0 , -1 , 0 , 4 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Greater Fire Protection Potion)
*
***************************************************************/

namespace Server.Items
{
	public class GreaterFireProtectionPotion : Item
	{
		public GreaterFireProtectionPotion() : base()
		{
			Id = 13457;
			SellPrice = 750;
			AvailableClasses = 0x7FFF;
			Model = 15741;
			ObjectClass = 0;
			SubClass = 0;
			Level = 58;
			ReqLevel = 48;
			Name = "Greater Fire Protection Potion";
			Name2 = "Greater Fire Protection Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 3000;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 17543 , 0 , -1 , 0 , 4 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Greater Nature Protection Potion)
*
***************************************************************/

namespace Server.Items
{
	public class GreaterNatureProtectionPotion : Item
	{
		public GreaterNatureProtectionPotion() : base()
		{
			Id = 13458;
			SellPrice = 750;
			AvailableClasses = 0x7FFF;
			Model = 23739;
			ObjectClass = 0;
			SubClass = 0;
			Level = 58;
			ReqLevel = 48;
			Name = "Greater Nature Protection Potion";
			Name2 = "Greater Nature Protection Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 3000;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 17546 , 0 , -1 , 0 , 4 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Greater Shadow Protection Potion)
*
***************************************************************/

namespace Server.Items
{
	public class GreaterShadowProtectionPotion : Item
	{
		public GreaterShadowProtectionPotion() : base()
		{
			Id = 13459;
			SellPrice = 100;
			AvailableClasses = 0x7FFF;
			Model = 17469;
			ObjectClass = 0;
			SubClass = 0;
			Level = 58;
			ReqLevel = 48;
			Name = "Greater Shadow Protection Potion";
			Name2 = "Greater Shadow Protection Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 400;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 17548 , 0 , -1 , 0 , 4 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Greater Arcane Protection Potion)
*
***************************************************************/

namespace Server.Items
{
	public class GreaterArcaneProtectionPotion : Item
	{
		public GreaterArcaneProtectionPotion() : base()
		{
			Id = 13461;
			SellPrice = 750;
			AvailableClasses = 0x7FFF;
			Model = 17403;
			ObjectClass = 0;
			SubClass = 0;
			Level = 58;
			ReqLevel = 48;
			Name = "Greater Arcane Protection Potion";
			Name2 = "Greater Arcane Protection Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 3000;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 17549 , 0 , -1 , 0 , 4 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Purification Potion)
*
***************************************************************/

namespace Server.Items
{
	public class PurificationPotion : Item
	{
		public PurificationPotion() : base()
		{
			Id = 13462;
			SellPrice = 750;
			AvailableClasses = 0x7FFF;
			Model = 24156;
			ObjectClass = 0;
			SubClass = 0;
			Level = 57;
			ReqLevel = 47;
			Name = "Purification Potion";
			Name2 = "Purification Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 3000;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 17550 , 0 , -1 , 0 , 4 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Flask of Petrification)
*
***************************************************************/

namespace Server.Items
{
	public class FlaskOfPetrification : Item
	{
		public FlaskOfPetrification() : base()
		{
			Id = 13506;
			SellPrice = 5000;
			AvailableClasses = 0x7FFF;
			Model = 26865;
			ObjectClass = 0;
			SubClass = 0;
			Level = 60;
			ReqLevel = 50;
			Name = "Flask of Petrification";
			Name2 = "Flask of Petrification";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 20000;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 17624 , 0 , -1 , 0 , 79 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Eye of Arachnida)
*
***************************************************************/

namespace Server.Items
{
	public class EyeOfArachnida : Item
	{
		public EyeOfArachnida() : base()
		{
			Id = 13508;
			Bonding = 1;
			SellPrice = 4778;
			AvailableClasses = 0x7FFF;
			Model = 1504;
			ObjectClass = 0;
			SubClass = 0;
			Level = 60;
			ReqLevel = 55;
			Name = "Eye of Arachnida";
			Name2 = "Eye of Arachnida";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 19115;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			SetSpell( 126 , 0 , -3 , -1 , 94 , 60000 );
		}
	}
}


/**************************************************************
*
*				(Clutch of Foresight)
*
***************************************************************/

namespace Server.Items
{
	public class ClutchOfForesight : Item
	{
		public ClutchOfForesight() : base()
		{
			Id = 13509;
			Bonding = 1;
			SellPrice = 5393;
			AvailableClasses = 0x7FFF;
			Model = 7247;
			ObjectClass = 0;
			SubClass = 0;
			Level = 60;
			ReqLevel = 55;
			Name = "Clutch of Foresight";
			Name2 = "Clutch of Foresight";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 21573;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			SetSpell( 2139 , 0 , -1 , -1 , 29 , 180000 );
		}
	}
}


/**************************************************************
*
*				(Flask of the Titans)
*
***************************************************************/

namespace Server.Items
{
	public class FlaskOfTheTitans : Item
	{
		public FlaskOfTheTitans() : base()
		{
			Id = 13510;
			SellPrice = 5000;
			AvailableClasses = 0x7FFF;
			Model = 24213;
			ObjectClass = 0;
			SubClass = 0;
			Level = 60;
			ReqLevel = 50;
			Name = "Flask of the Titans";
			Name2 = "Flask of the Titans";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 20000;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 17626 , 0 , -1 , 0 , 79 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Flask of Distilled Wisdom)
*
***************************************************************/

namespace Server.Items
{
	public class FlaskOfDistilledWisdom : Item
	{
		public FlaskOfDistilledWisdom() : base()
		{
			Id = 13511;
			SellPrice = 5000;
			AvailableClasses = 0x7FFF;
			Model = 21531;
			ObjectClass = 0;
			SubClass = 0;
			Level = 60;
			ReqLevel = 50;
			Name = "Flask of Distilled Wisdom";
			Name2 = "Flask of Distilled Wisdom";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 20000;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 17627 , 0 , -1 , 0 , 79 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Flask of Supreme Power)
*
***************************************************************/

namespace Server.Items
{
	public class FlaskOfSupremePower : Item
	{
		public FlaskOfSupremePower() : base()
		{
			Id = 13512;
			SellPrice = 5000;
			AvailableClasses = 0x7FFF;
			Model = 19547;
			ObjectClass = 0;
			SubClass = 0;
			Level = 60;
			ReqLevel = 50;
			Name = "Flask of Supreme Power";
			Name2 = "Flask of Supreme Power";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 20000;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 17628 , 0 , -1 , 0 , 79 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Flask of Chromatic Resistance)
*
***************************************************************/

namespace Server.Items
{
	public class FlaskOfChromaticResistance : Item
	{
		public FlaskOfChromaticResistance() : base()
		{
			Id = 13513;
			SellPrice = 5000;
			AvailableClasses = 0x7FFF;
			Model = 22191;
			ObjectClass = 0;
			SubClass = 0;
			Level = 60;
			ReqLevel = 50;
			Name = "Flask of Chromatic Resistance";
			Name2 = "Flask of Chromatic Resistance";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 20000;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 17629 , 0 , -1 , 0 , 79 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Wail of the Banshee)
*
***************************************************************/

namespace Server.Items
{
	public class WailOfTheBanshee : Item
	{
		public WailOfTheBanshee() : base()
		{
			Id = 13514;
			Bonding = 1;
			SellPrice = 5820;
			AvailableClasses = 0x7FFF;
			Model = 24169;
			ObjectClass = 0;
			SubClass = 0;
			Level = 60;
			ReqLevel = 55;
			Name = "Wail of the Banshee";
			Name2 = "Wail of the Banshee";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 23280;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			SetSpell( 17639 , 0 , -3 , 600000 , 29 , 180000 );
		}
	}
}


/**************************************************************
*
*				(Bloodbelly Fish)
*
***************************************************************/

namespace Server.Items
{
	public class BloodbellyFish : Item
	{
		public BloodbellyFish() : base()
		{
			Id = 13546;
			SellPrice = 62;
			AvailableClasses = 0x7FFF;
			Model = 4809;
			ObjectClass = 0;
			SubClass = 0;
			Level = 35;
			ReqLevel = 25;
			Name = "Bloodbelly Fish";
			Name2 = "Bloodbelly Fish";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1250;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 1129 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Remains of Trey Lightforge)
*
***************************************************************/

namespace Server.Items
{
	public class RemainsOfTreyLightforge : Item
	{
		public RemainsOfTreyLightforge() : base()
		{
			Id = 13562;
			Bonding = 4;
			AvailableClasses = 0x7FFF;
			Model = 24231;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Remains of Trey Lightforge";
			Name2 = "Remains of Trey Lightforge";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Kodo Bone)
*
***************************************************************/

namespace Server.Items
{
	public class KodoBone : Item
	{
		public KodoBone() : base()
		{
			Id = 13703;
			Bonding = 4;
			AvailableClasses = 0x7FFF;
			Model = 24415;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Kodo Bone";
			Name2 = "Kodo Bone";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Enriched Manna Biscuit)
*
***************************************************************/

namespace Server.Items
{
	public class EnrichedMannaBiscuit : Item
	{
		public EnrichedMannaBiscuit() : base()
		{
			Id = 13724;
			SellPrice = 300;
			AvailableClasses = 0x7FFF;
			Model = 21203;
			ObjectClass = 0;
			SubClass = 0;
			Level = 55;
			ReqLevel = 45;
			Name = "Enriched Manna Biscuit";
			Name2 = "Enriched Manna Biscuit";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 6000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 18071 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Raw Glossy Mightfish)
*
***************************************************************/

namespace Server.Items
{
	public class RawGlossyMightfish : Item
	{
		public RawGlossyMightfish() : base()
		{
			Id = 13754;
			SellPrice = 6;
			AvailableClasses = 0x7FFF;
			Model = 7176;
			ObjectClass = 0;
			SubClass = 0;
			Level = 45;
			ReqLevel = 35;
			Name = "Raw Glossy Mightfish";
			Name2 = "Raw Glossy Mightfish";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 120;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 1127 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Winter Squid)
*
***************************************************************/

namespace Server.Items
{
	public class WinterSquid : Item
	{
		public WinterSquid() : base()
		{
			Id = 13755;
			SellPrice = 7;
			AvailableClasses = 0x7FFF;
			Model = 18537;
			ObjectClass = 0;
			SubClass = 0;
			Level = 45;
			ReqLevel = 35;
			Name = "Winter Squid";
			Name2 = "Winter Squid";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 140;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 1127 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Raw Summer Bass)
*
***************************************************************/

namespace Server.Items
{
	public class RawSummerBass : Item
	{
		public RawSummerBass() : base()
		{
			Id = 13756;
			SellPrice = 9;
			AvailableClasses = 0x7FFF;
			Model = 4813;
			ObjectClass = 0;
			SubClass = 0;
			Level = 45;
			ReqLevel = 35;
			Name = "Raw Summer Bass";
			Name2 = "Raw Summer Bass";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 180;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 1127 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Raw Redgill)
*
***************************************************************/

namespace Server.Items
{
	public class RawRedgill : Item
	{
		public RawRedgill() : base()
		{
			Id = 13758;
			SellPrice = 4;
			AvailableClasses = 0x7FFF;
			Model = 4809;
			ObjectClass = 0;
			SubClass = 0;
			Level = 45;
			ReqLevel = 35;
			Name = "Raw Redgill";
			Name2 = "Raw Redgill";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 80;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 1127 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Raw Nightfin Snapper)
*
***************************************************************/

namespace Server.Items
{
	public class RawNightfinSnapper : Item
	{
		public RawNightfinSnapper() : base()
		{
			Id = 13759;
			SellPrice = 10;
			AvailableClasses = 0x7FFF;
			Model = 24713;
			ObjectClass = 0;
			SubClass = 0;
			Level = 45;
			ReqLevel = 35;
			Name = "Raw Nightfin Snapper";
			Name2 = "Raw Nightfin Snapper";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 200;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 1127 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Raw Sunscale Salmon)
*
***************************************************************/

namespace Server.Items
{
	public class RawSunscaleSalmon : Item
	{
		public RawSunscaleSalmon() : base()
		{
			Id = 13760;
			SellPrice = 10;
			AvailableClasses = 0x7FFF;
			Model = 24716;
			ObjectClass = 0;
			SubClass = 0;
			Level = 45;
			ReqLevel = 35;
			Name = "Raw Sunscale Salmon";
			Name2 = "Raw Sunscale Salmon";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 200;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 1127 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Frozen Eggs)
*
***************************************************************/

namespace Server.Items
{
	public class FrozenEggs : Item
	{
		public FrozenEggs() : base()
		{
			Id = 13761;
			Bonding = 4;
			AvailableClasses = 0x7FFF;
			Model = 11448;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Frozen Eggs";
			Name2 = "Frozen Eggs";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Blessed Sunfruit)
*
***************************************************************/

namespace Server.Items
{
	public class BlessedSunfruit : Item
	{
		public BlessedSunfruit() : base()
		{
			Id = 13810;
			Bonding = 1;
			SellPrice = 300;
			AvailableClasses = 0x7FFF;
			Model = 24568;
			ObjectClass = 0;
			SubClass = 0;
			Level = 55;
			ReqLevel = 45;
			Name = "Blessed Sunfruit";
			Name2 = "Blessed Sunfruit";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 6000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			Flags = 64;
			SetSpell( 18124 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Blessed Sunfruit Juice)
*
***************************************************************/

namespace Server.Items
{
	public class BlessedSunfruitJuice : Item
	{
		public BlessedSunfruitJuice() : base()
		{
			Id = 13813;
			Bonding = 1;
			SellPrice = 300;
			AvailableClasses = 0x7FFF;
			Model = 24570;
			ObjectClass = 0;
			SubClass = 0;
			Level = 55;
			ReqLevel = 45;
			Name = "Blessed Sunfruit Juice";
			Name2 = "Blessed Sunfruit Juice";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 6000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			Flags = 64;
			SetSpell( 18140 , 0 , -1 , 0 , 59 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Hot Wolf Ribs)
*
***************************************************************/

namespace Server.Items
{
	public class HotWolfRibs : Item
	{
		public HotWolfRibs() : base()
		{
			Id = 13851;
			SellPrice = 312;
			AvailableClasses = 0x7FFF;
			Model = 21327;
			ObjectClass = 0;
			SubClass = 0;
			Level = 35;
			ReqLevel = 25;
			Name = "Hot Wolf Ribs";
			Name2 = "Hot Wolf Ribs";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1250;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 5007 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Bloated Redgill)
*
***************************************************************/

namespace Server.Items
{
	public class BloatedRedgill : Item
	{
		public BloatedRedgill() : base()
		{
			Id = 13881;
			SellPrice = 100;
			AvailableClasses = 0x7FFF;
			Model = 4809;
			ObjectClass = 0;
			SubClass = 0;
			Level = 45;
			Name = "Bloated Redgill";
			Name2 = "Bloated Redgill";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 400;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Darkclaw Lobster)
*
***************************************************************/

namespace Server.Items
{
	public class DarkclawLobster : Item
	{
		public DarkclawLobster() : base()
		{
			Id = 13888;
			SellPrice = 12;
			AvailableClasses = 0x7FFF;
			Model = 24629;
			ObjectClass = 0;
			SubClass = 0;
			Level = 55;
			ReqLevel = 45;
			Name = "Darkclaw Lobster";
			Name2 = "Darkclaw Lobster";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 240;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 1129 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Raw Whitescale Salmon)
*
***************************************************************/

namespace Server.Items
{
	public class RawWhitescaleSalmon : Item
	{
		public RawWhitescaleSalmon() : base()
		{
			Id = 13889;
			SellPrice = 5;
			AvailableClasses = 0x7FFF;
			Model = 24719;
			ObjectClass = 0;
			SubClass = 0;
			Level = 55;
			ReqLevel = 45;
			Name = "Raw Whitescale Salmon";
			Name2 = "Raw Whitescale Salmon";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 1129 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Bloated Salmon)
*
***************************************************************/

namespace Server.Items
{
	public class BloatedSalmon : Item
	{
		public BloatedSalmon() : base()
		{
			Id = 13891;
			SellPrice = 100;
			AvailableClasses = 0x7FFF;
			Model = 4809;
			ObjectClass = 0;
			SubClass = 0;
			Level = 55;
			Name = "Bloated Salmon";
			Name2 = "Bloated Salmon";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 400;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Large Raw Mightfish)
*
***************************************************************/

namespace Server.Items
{
	public class LargeRawMightfish : Item
	{
		public LargeRawMightfish() : base()
		{
			Id = 13893;
			SellPrice = 15;
			AvailableClasses = 0x7FFF;
			Model = 11932;
			ObjectClass = 0;
			SubClass = 0;
			Level = 55;
			ReqLevel = 45;
			Name = "Large Raw Mightfish";
			Name2 = "Large Raw Mightfish";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 60;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 1129 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Cooked Glossy Mightfish)
*
***************************************************************/

namespace Server.Items
{
	public class CookedGlossyMightfish : Item
	{
		public CookedGlossyMightfish() : base()
		{
			Id = 13927;
			SellPrice = 8;
			AvailableClasses = 0x7FFF;
			Model = 7176;
			ObjectClass = 0;
			SubClass = 0;
			Level = 45;
			ReqLevel = 35;
			Name = "Cooked Glossy Mightfish";
			Name2 = "Cooked Glossy Mightfish";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 32;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 18229 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Grilled Squid)
*
***************************************************************/

namespace Server.Items
{
	public class GrilledSquid : Item
	{
		public GrilledSquid() : base()
		{
			Id = 13928;
			SellPrice = 8;
			AvailableClasses = 0x7FFF;
			Model = 18537;
			ObjectClass = 0;
			SubClass = 0;
			Level = 45;
			ReqLevel = 35;
			Name = "Grilled Squid";
			Name2 = "Grilled Squid";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 160;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 18230 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Hot Smoked Bass)
*
***************************************************************/

namespace Server.Items
{
	public class HotSmokedBass : Item
	{
		public HotSmokedBass() : base()
		{
			Id = 13929;
			SellPrice = 10;
			AvailableClasses = 0x7FFF;
			Model = 4813;
			ObjectClass = 0;
			SubClass = 0;
			Level = 45;
			ReqLevel = 35;
			Name = "Hot Smoked Bass";
			Name2 = "Hot Smoked Bass";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 40;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 18231 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Filet of Redgill)
*
***************************************************************/

namespace Server.Items
{
	public class FiletOfRedgill : Item
	{
		public FiletOfRedgill() : base()
		{
			Id = 13930;
			SellPrice = 5;
			AvailableClasses = 0x7FFF;
			Model = 4809;
			ObjectClass = 0;
			SubClass = 0;
			Level = 45;
			ReqLevel = 35;
			Name = "Filet of Redgill";
			Name2 = "Filet of Redgill";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 100;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 1129 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Nightfin Soup)
*
***************************************************************/

namespace Server.Items
{
	public class NightfinSoup : Item
	{
		public NightfinSoup() : base()
		{
			Id = 13931;
			SellPrice = 12;
			AvailableClasses = 0x7FFF;
			Model = 24733;
			ObjectClass = 0;
			SubClass = 0;
			Level = 45;
			ReqLevel = 35;
			Name = "Nightfin Soup";
			Name2 = "Nightfin Soup";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 240;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 18233 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Poached Sunscale Salmon)
*
***************************************************************/

namespace Server.Items
{
	public class PoachedSunscaleSalmon : Item
	{
		public PoachedSunscaleSalmon() : base()
		{
			Id = 13932;
			SellPrice = 12;
			AvailableClasses = 0x7FFF;
			Model = 24716;
			ObjectClass = 0;
			SubClass = 0;
			Level = 45;
			ReqLevel = 35;
			Name = "Poached Sunscale Salmon";
			Name2 = "Poached Sunscale Salmon";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 240;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 18232 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Lobster Stew)
*
***************************************************************/

namespace Server.Items
{
	public class LobsterStew : Item
	{
		public LobsterStew() : base()
		{
			Id = 13933;
			SellPrice = 14;
			AvailableClasses = 0x7FFF;
			Model = 24733;
			ObjectClass = 0;
			SubClass = 0;
			Level = 55;
			ReqLevel = 45;
			Name = "Lobster Stew";
			Name2 = "Lobster Stew";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 280;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 1131 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Mightfish Steak)
*
***************************************************************/

namespace Server.Items
{
	public class MightfishSteak : Item
	{
		public MightfishSteak() : base()
		{
			Id = 13934;
			SellPrice = 18;
			AvailableClasses = 0x7FFF;
			Model = 22194;
			ObjectClass = 0;
			SubClass = 0;
			Level = 55;
			ReqLevel = 45;
			Name = "Mightfish Steak";
			Name2 = "Mightfish Steak";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 72;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 18234 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Baked Salmon)
*
***************************************************************/

namespace Server.Items
{
	public class BakedSalmon : Item
	{
		public BakedSalmon() : base()
		{
			Id = 13935;
			SellPrice = 10;
			AvailableClasses = 0x7FFF;
			Model = 24719;
			ObjectClass = 0;
			SubClass = 0;
			Level = 55;
			ReqLevel = 45;
			Name = "Baked Salmon";
			Name2 = "Baked Salmon";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1200;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 1131 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Kravel's Crate)
*
***************************************************************/

namespace Server.Items
{
	public class KravelsCrate : Item
	{
		public KravelsCrate() : base()
		{
			Id = 14542;
			Bonding = 4;
			AvailableClasses = 0x7FFF;
			Model = 11449;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Kravel's Crate";
			Name2 = "Kravel's Crate";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Lily Root)
*
***************************************************************/

namespace Server.Items
{
	public class LilyRoot : Item
	{
		public LilyRoot() : base()
		{
			Id = 14894;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 25542;
			ObjectClass = 0;
			SubClass = 0;
			Level = 51;
			Name = "Lily Root";
			Name2 = "Lily Root";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = 3;
			Flags = 2;
			SetSpell( 18832 , 0 , -1 , 0 , 4 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Bundle of Relics)
*
***************************************************************/

namespace Server.Items
{
	public class BundleOfRelics : Item
	{
		public BundleOfRelics() : base()
		{
			Id = 15314;
			Bonding = 4;
			AvailableClasses = 0x7FFF;
			Model = 1168;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Bundle of Relics";
			Name2 = "Bundle of Relics";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Rugged Armor Kit)
*
***************************************************************/

namespace Server.Items
{
	public class RuggedArmorKit : Item
	{
		public RuggedArmorKit() : base()
		{
			Id = 15564;
			SellPrice = 1000;
			AvailableClasses = 0x7FFF;
			Model = 26388;
			ObjectClass = 0;
			SubClass = 0;
			Level = 50;
			ReqLevel = 40;
			Name = "Rugged Armor Kit";
			Name2 = "Rugged Armor Kit";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 4000;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 8;
			Flags = 64;
			SetSpell( 19057 , 0 , -1 , 1000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Tea with Sugar)
*
***************************************************************/

namespace Server.Items
{
	public class TeaWithSugar : Item
	{
		public TeaWithSugar() : base()
		{
			Id = 15723;
			Bonding = 1;
			SellPrice = 2825;
			AvailableClasses = 0x7FFF;
			Model = 19873;
			ObjectClass = 0;
			SubClass = 0;
			Level = 60;
			ReqLevel = 50;
			Name = "Tea with Sugar";
			Name2 = "Tea with Sugar";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11300;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = 3;
			SetSpell( 19199 , 0 , -3 , 0 , 30 , 180000 );
		}
	}
}


/**************************************************************
*
*				(Mechanical Yeti)
*
***************************************************************/

namespace Server.Items
{
	public class MechanicalYeti : Item
	{
		public MechanicalYeti() : base()
		{
			Id = 15778;
			Bonding = 1;
			SellPrice = 1250;
			AvailableClasses = 0x7FFF;
			Model = 26461;
			ObjectClass = 0;
			SubClass = 0;
			Level = 58;
			Name = "Mechanical Yeti";
			Name2 = "Mechanical Yeti";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = 3;
			SetSpell( 19363 , 0 , -3 , 600000 , 94 , 60000 );
		}
	}
}


/**************************************************************
*
*				(Bean Soup)
*
***************************************************************/

namespace Server.Items
{
	public class BeanSoup : Item
	{
		public BeanSoup() : base()
		{
			Id = 16166;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 26731;
			ObjectClass = 0;
			SubClass = 0;
			Level = 5;
			ReqLevel = 1;
			Name = "Bean Soup";
			Name2 = "Bean Soup";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 25;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 433 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Versicolor Treat)
*
***************************************************************/

namespace Server.Items
{
	public class VersicolorTreat : Item
	{
		public VersicolorTreat() : base()
		{
			Id = 16167;
			SellPrice = 6;
			AvailableClasses = 0x7FFF;
			Model = 26732;
			ObjectClass = 0;
			SubClass = 0;
			Level = 15;
			ReqLevel = 5;
			Name = "Versicolor Treat";
			Name2 = "Versicolor Treat";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 125;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 434 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Heaven Peach)
*
***************************************************************/

namespace Server.Items
{
	public class HeavenPeach : Item
	{
		public HeavenPeach() : base()
		{
			Id = 16168;
			SellPrice = 100;
			AvailableClasses = 0x7FFF;
			Model = 26735;
			ObjectClass = 0;
			SubClass = 0;
			Level = 45;
			ReqLevel = 35;
			Name = "Heaven Peach";
			Name2 = "Heaven Peach";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 1129 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Wild Ricecake)
*
***************************************************************/

namespace Server.Items
{
	public class WildRicecake : Item
	{
		public WildRicecake() : base()
		{
			Id = 16169;
			SellPrice = 62;
			AvailableClasses = 0x7FFF;
			Model = 26736;
			ObjectClass = 0;
			SubClass = 0;
			Level = 35;
			ReqLevel = 25;
			Name = "Wild Ricecake";
			Name2 = "Wild Ricecake";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 1127 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Steamed Mandu)
*
***************************************************************/

namespace Server.Items
{
	public class SteamedMandu : Item
	{
		public SteamedMandu() : base()
		{
			Id = 16170;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 26734;
			ObjectClass = 0;
			SubClass = 0;
			Level = 25;
			ReqLevel = 15;
			Name = "Steamed Mandu";
			Name2 = "Steamed Mandu";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 500;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 435 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Shinsollo)
*
***************************************************************/

namespace Server.Items
{
	public class Shinsollo : Item
	{
		public Shinsollo() : base()
		{
			Id = 16171;
			SellPrice = 200;
			AvailableClasses = 0x7FFF;
			Model = 26733;
			ObjectClass = 0;
			SubClass = 0;
			Level = 55;
			ReqLevel = 45;
			Name = "Shinsollo";
			Name2 = "Shinsollo";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 4000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 1131 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Bundle of Hides)
*
***************************************************************/

namespace Server.Items
{
	public class BundleOfHides : Item
	{
		public BundleOfHides() : base()
		{
			Id = 16282;
			Bonding = 4;
			AvailableClasses = 0x7FFF;
			Model = 7382;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Bundle of Hides";
			Name2 = "Bundle of Hides";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
		}
	}
}


/**************************************************************
*
*				(Undermine Clam Chowder)
*
***************************************************************/

namespace Server.Items
{
	public class UndermineClamChowder : Item
	{
		public UndermineClamChowder() : base()
		{
			Id = 16766;
			SellPrice = 100;
			AvailableClasses = 0x7FFF;
			Model = 24733;
			ObjectClass = 0;
			SubClass = 0;
			Level = 45;
			ReqLevel = 35;
			Name = "Undermine Clam Chowder";
			Name2 = "Undermine Clam Chowder";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 1129 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Lesser Soulstone)
*
***************************************************************/

namespace Server.Items
{
	public class LesserSoulstone : Item
	{
		public LesserSoulstone() : base()
		{
			Id = 16892;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 6009;
			ObjectClass = 0;
			SubClass = 0;
			Level = 30;
			Name = "Lesser Soulstone";
			Name2 = "Lesser Soulstone";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = 3;
			Flags = 66;
			SetSpell( 20762 , 0 , -1 , 0 , 831 , 1800000 );
		}
	}
}


/**************************************************************
*
*				(Soulstone)
*
***************************************************************/

namespace Server.Items
{
	public class Soulstone : Item
	{
		public Soulstone() : base()
		{
			Id = 16893;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 6009;
			ObjectClass = 0;
			SubClass = 0;
			Level = 40;
			Name = "Soulstone";
			Name2 = "Soulstone";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = 3;
			Flags = 66;
			SetSpell( 20763 , 0 , -1 , 0 , 831 , 1800000 );
		}
	}
}


/**************************************************************
*
*				(Greater Soulstone)
*
***************************************************************/

namespace Server.Items
{
	public class GreaterSoulstone : Item
	{
		public GreaterSoulstone() : base()
		{
			Id = 16895;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 6009;
			ObjectClass = 0;
			SubClass = 0;
			Level = 50;
			Name = "Greater Soulstone";
			Name2 = "Greater Soulstone";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = 3;
			Flags = 66;
			SetSpell( 20764 , 0 , -1 , 0 , 831 , 1800000 );
		}
	}
}


/**************************************************************
*
*				(Major Soulstone)
*
***************************************************************/

namespace Server.Items
{
	public class MajorSoulstone : Item
	{
		public MajorSoulstone() : base()
		{
			Id = 16896;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 6009;
			ObjectClass = 0;
			SubClass = 0;
			Level = 60;
			Name = "Major Soulstone";
			Name2 = "Major Soulstone";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = 3;
			Flags = 66;
			SetSpell( 20765 , 0 , -1 , 0 , 831 , 1800000 );
		}
	}
}


/**************************************************************
*
*				(Clamlette Surprise)
*
***************************************************************/

namespace Server.Items
{
	public class ClamletteSurprise : Item
	{
		public ClamletteSurprise() : base()
		{
			Id = 16971;
			SellPrice = 300;
			AvailableClasses = 0x7FFF;
			Model = 16211;
			ObjectClass = 0;
			SubClass = 0;
			Level = 45;
			ReqLevel = 40;
			Name = "Clamlette Surprise";
			Name2 = "Clamlette Surprise";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1200;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 10256 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Rumsey Rum)
*
***************************************************************/

namespace Server.Items
{
	public class RumseyRum : Item
	{
		public RumseyRum() : base()
		{
			Id = 17048;
			Bonding = 1;
			SellPrice = 400;
			AvailableClasses = 0x7FFF;
			Model = 18119;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Rumsey Rum";
			Name2 = "Rumsey Rum";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1600;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 3;
			SetSpell( 20875 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Deeprun Rat Kabob)
*
***************************************************************/

namespace Server.Items
{
	public class DeeprunRatKabob : Item
	{
		public DeeprunRatKabob() : base()
		{
			Id = 17119;
			SellPrice = 6;
			AvailableClasses = 0x7FFF;
			Model = 29036;
			ObjectClass = 0;
			SubClass = 0;
			Level = 15;
			ReqLevel = 5;
			Name = "Deeprun Rat Kabob";
			Name2 = "Deeprun Rat Kabob";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 125;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 434 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Holiday Spirits)
*
***************************************************************/

namespace Server.Items
{
	public class HolidaySpirits : Item
	{
		public HolidaySpirits() : base()
		{
			Id = 17196;
			SellPrice = 12;
			AvailableClasses = 0x7FFF;
			Model = 18079;
			ObjectClass = 0;
			SubClass = 0;
			Level = 5;
			ReqLevel = 1;
			Name = "Holiday Spirits";
			Name2 = "Holiday Spirits";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 50;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 3;
			SetSpell( 11007 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Gingerbread Cookie)
*
***************************************************************/

namespace Server.Items
{
	public class GingerbreadCookie : Item
	{
		public GingerbreadCookie() : base()
		{
			Id = 17197;
			SellPrice = 10;
			AvailableClasses = 0x7FFF;
			Model = 29166;
			ObjectClass = 0;
			SubClass = 0;
			Level = 7;
			ReqLevel = 1;
			Name = "Gingerbread Cookie";
			Name2 = "Gingerbread Cookie";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 40;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 5004 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Egg Nog)
*
***************************************************************/

namespace Server.Items
{
	public class EggNog : Item
	{
		public EggNog() : base()
		{
			Id = 17198;
			SellPrice = 9;
			AvailableClasses = 0x7FFF;
			Model = 29172;
			ObjectClass = 0;
			SubClass = 0;
			Level = 10;
			ReqLevel = 1;
			Name = "Egg Nog";
			Name2 = "Egg Nog";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 36;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 21149 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Snowball)
*
***************************************************************/

namespace Server.Items
{
	public class Snowball : Item
	{
		public Snowball() : base()
		{
			Id = 17202;
			AvailableClasses = 0x7FFF;
			Model = 29169;
			ObjectClass = 0;
			SubClass = 0;
			Level = 5;
			Name = "Snowball";
			Name2 = "Snowball";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 10;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			Flags = 64;
			SetSpell( 21343 , 0 , -1 , 1000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Spider Sausage)
*
***************************************************************/

namespace Server.Items
{
	public class SpiderSausage : Item
	{
		public SpiderSausage() : base()
		{
			Id = 17222;
			SellPrice = 300;
			AvailableClasses = 0x7FFF;
			Model = 29193;
			ObjectClass = 0;
			SubClass = 0;
			Level = 40;
			ReqLevel = 35;
			Name = "Spider Sausage";
			Name2 = "Spider Sausage";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1200;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 10256 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Blue Ribboned Holiday Gift)
*
***************************************************************/

namespace Server.Items
{
	public class BlueRibbonedHolidayGift : Item
	{
		public BlueRibbonedHolidayGift() : base()
		{
			Id = 17302;
			AvailableClasses = 0x7FFF;
			Model = 29444;
			ObjectClass = 0;
			SubClass = 0;
			Level = 5;
			Name = "Blue Ribboned Holiday Gift";
			Name2 = "Blue Ribboned Holiday Gift";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Flags = 512;
		}
	}
}


/**************************************************************
*
*				(Blue Ribboned Wrapping Paper)
*
***************************************************************/

namespace Server.Items
{
	public class BlueRibbonedWrappingPaper17303 : Item
	{
		public BlueRibbonedWrappingPaper17303() : base()
		{
			Id = 17303;
			SellPrice = 2;
			AvailableClasses = 0x7FFF;
			Model = 29442;
			ObjectClass = 0;
			SubClass = 0;
			Level = 5;
			Name = "Blue Ribboned Wrapping Paper";
			Name2 = "Blue Ribboned Wrapping Paper";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 10;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
			Flags = 512;
		}
	}
}


/**************************************************************
*
*				(Green Ribboned Wrapping Paper)
*
***************************************************************/

namespace Server.Items
{
	public class GreenRibbonedWrappingPaper : Item
	{
		public GreenRibbonedWrappingPaper() : base()
		{
			Id = 17304;
			SellPrice = 2;
			AvailableClasses = 0x7FFF;
			Model = 29440;
			ObjectClass = 0;
			SubClass = 0;
			Level = 5;
			Name = "Green Ribboned Wrapping Paper";
			Name2 = "Green Ribboned Wrapping Paper";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 10;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
			Flags = 512;
		}
	}
}


/**************************************************************
*
*				(Green Ribboned Holiday Gift)
*
***************************************************************/

namespace Server.Items
{
	public class GreenRibbonedHolidayGift : Item
	{
		public GreenRibbonedHolidayGift() : base()
		{
			Id = 17305;
			AvailableClasses = 0x7FFF;
			Model = 29441;
			ObjectClass = 0;
			SubClass = 0;
			Level = 5;
			Name = "Green Ribboned Holiday Gift";
			Name2 = "Green Ribboned Holiday Gift";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Flags = 512;
		}
	}
}


/**************************************************************
*
*				(Purple Ribboned Wrapping Paper)
*
***************************************************************/

namespace Server.Items
{
	public class PurpleRibbonedWrappingPaper : Item
	{
		public PurpleRibbonedWrappingPaper() : base()
		{
			Id = 17307;
			SellPrice = 2;
			AvailableClasses = 0x7FFF;
			Model = 29443;
			ObjectClass = 0;
			SubClass = 0;
			Level = 5;
			Name = "Purple Ribboned Wrapping Paper";
			Name2 = "Purple Ribboned Wrapping Paper";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 10;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
			Flags = 512;
		}
	}
}


/**************************************************************
*
*				(Purple Ribboned Holiday Gift)
*
***************************************************************/

namespace Server.Items
{
	public class PurpleRibbonedHolidayGift : Item
	{
		public PurpleRibbonedHolidayGift() : base()
		{
			Id = 17308;
			AvailableClasses = 0x7FFF;
			Model = 29445;
			ObjectClass = 0;
			SubClass = 0;
			Level = 5;
			Name = "Purple Ribboned Holiday Gift";
			Name2 = "Purple Ribboned Holiday Gift";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Flags = 512;
		}
	}
}


/**************************************************************
*
*				(Candy Cane)
*
***************************************************************/

namespace Server.Items
{
	public class CandyCane : Item
	{
		public CandyCane() : base()
		{
			Id = 17344;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 29331;
			ObjectClass = 0;
			SubClass = 0;
			Level = 5;
			ReqLevel = 1;
			Name = "Candy Cane";
			Name2 = "Candy Cane";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 25;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 433 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Major Healing Draught)
*
***************************************************************/

namespace Server.Items
{
	public class MajorHealingDraught : Item
	{
		public MajorHealingDraught() : base()
		{
			Id = 17348;
			Bonding = 1;
			SellPrice = 250;
			AvailableClasses = 0x7FFF;
			Model = 15771;
			ObjectClass = 0;
			SubClass = 0;
			Level = 55;
			ReqLevel = 45;
			Name = "Major Healing Draught";
			Name2 = "Major Healing Draught";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1000;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			MaxCount = 10;
			Material = -1;
			SetSpell( 21393 , 0 , -1 , 0 , 4 , 300000 );
		}
	}
}


/**************************************************************
*
*				(Superior Healing Draught)
*
***************************************************************/

namespace Server.Items
{
	public class SuperiorHealingDraught : Item
	{
		public SuperiorHealingDraught() : base()
		{
			Id = 17349;
			Bonding = 1;
			SellPrice = 125;
			AvailableClasses = 0x7FFF;
			Model = 29352;
			ObjectClass = 0;
			SubClass = 0;
			Level = 45;
			ReqLevel = 35;
			Name = "Superior Healing Draught";
			Name2 = "Superior Healing Draught";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 500;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			MaxCount = 10;
			Material = -1;
			SetSpell( 21394 , 0 , -1 , 0 , 4 , 300000 );
		}
	}
}


/**************************************************************
*
*				(Major Mana Draught)
*
***************************************************************/

namespace Server.Items
{
	public class MajorManaDraught : Item
	{
		public MajorManaDraught() : base()
		{
			Id = 17351;
			Bonding = 1;
			SellPrice = 250;
			AvailableClasses = 0x7FFF;
			Model = 29353;
			ObjectClass = 0;
			SubClass = 0;
			Level = 55;
			ReqLevel = 45;
			Name = "Major Mana Draught";
			Name2 = "Major Mana Draught";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1000;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			MaxCount = 10;
			Material = 3;
			SetSpell( 21395 , 0 , -1 , 0 , 4 , 300000 );
		}
	}
}


/**************************************************************
*
*				(Superior Mana Draught)
*
***************************************************************/

namespace Server.Items
{
	public class SuperiorManaDraught : Item
	{
		public SuperiorManaDraught() : base()
		{
			Id = 17352;
			Bonding = 1;
			SellPrice = 125;
			AvailableClasses = 0x7FFF;
			Model = 29354;
			ObjectClass = 0;
			SubClass = 0;
			Level = 45;
			ReqLevel = 35;
			Name = "Superior Mana Draught";
			Name2 = "Superior Mana Draught";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 500;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			MaxCount = 10;
			Material = 3;
			SetSpell( 21396 , 0 , -1 , 0 , 4 , 300000 );
		}
	}
}


/**************************************************************
*
*				(Greatfather's Winter Ale)
*
***************************************************************/

namespace Server.Items
{
	public class GreatfathersWinterAle : Item
	{
		public GreatfathersWinterAle() : base()
		{
			Id = 17402;
			SellPrice = 500;
			AvailableClasses = 0x7FFF;
			Model = 18117;
			ObjectClass = 0;
			SubClass = 0;
			Level = 35;
			Name = "Greatfather's Winter Ale";
			Name2 = "Greatfather's Winter Ale";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 11009 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Steamwheedle Fizzy Spirits)
*
***************************************************************/

namespace Server.Items
{
	public class SteamwheedleFizzySpirits : Item
	{
		public SteamwheedleFizzySpirits() : base()
		{
			Id = 17403;
			SellPrice = 37;
			AvailableClasses = 0x7FFF;
			Model = 18080;
			ObjectClass = 0;
			SubClass = 0;
			Level = 15;
			Name = "Steamwheedle Fizzy Spirits";
			Name2 = "Steamwheedle Fizzy Spirits";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 150;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 3;
			SetSpell( 11008 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Blended Bean Brew)
*
***************************************************************/

namespace Server.Items
{
	public class BlendedBeanBrew : Item
	{
		public BlendedBeanBrew() : base()
		{
			Id = 17404;
			SellPrice = 6;
			AvailableClasses = 0x7FFF;
			Model = 19873;
			ObjectClass = 0;
			SubClass = 0;
			Level = 15;
			ReqLevel = 5;
			Name = "Blended Bean Brew";
			Name2 = "Blended Bean Brew";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 125;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 7;
			SetSpell( 431 , 0 , -1 , 0 , 59 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Green Garden Tea)
*
***************************************************************/

namespace Server.Items
{
	public class GreenGardenTea : Item
	{
		public GreenGardenTea() : base()
		{
			Id = 17405;
			SellPrice = 50;
			AvailableClasses = 0x7FFF;
			Model = 18091;
			ObjectClass = 0;
			SubClass = 0;
			Level = 35;
			ReqLevel = 25;
			Name = "Green Garden Tea";
			Name2 = "Green Garden Tea";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 3;
			SetSpell( 1133 , 0 , -1 , 0 , 59 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Holiday Cheesewheel)
*
***************************************************************/

namespace Server.Items
{
	public class HolidayCheesewheel : Item
	{
		public HolidayCheesewheel() : base()
		{
			Id = 17406;
			SellPrice = 6;
			AvailableClasses = 0x7FFF;
			Model = 6425;
			ObjectClass = 0;
			SubClass = 0;
			Level = 15;
			ReqLevel = 5;
			Name = "Holiday Cheesewheel";
			Name2 = "Holiday Cheesewheel";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 125;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 434 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Graccu's Homemade Meat Pie)
*
***************************************************************/

namespace Server.Items
{
	public class GraccusHomemadeMeatPie : Item
	{
		public GraccusHomemadeMeatPie() : base()
		{
			Id = 17407;
			SellPrice = 50;
			AvailableClasses = 0x7FFF;
			Model = 1041;
			ObjectClass = 0;
			SubClass = 0;
			Level = 35;
			ReqLevel = 25;
			Name = "Graccu's Homemade Meat Pie";
			Name2 = "Graccu's Homemade Meat Pie";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 1127 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Spicy Beefstick)
*
***************************************************************/

namespace Server.Items
{
	public class SpicyBeefstick : Item
	{
		public SpicyBeefstick() : base()
		{
			Id = 17408;
			SellPrice = 100;
			AvailableClasses = 0x7FFF;
			Model = 25469;
			ObjectClass = 0;
			SubClass = 0;
			Level = 45;
			ReqLevel = 35;
			Name = "Spicy Beefstick";
			Name2 = "Spicy Beefstick";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 1129 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Elixir of Frost Power)
*
***************************************************************/

namespace Server.Items
{
	public class ElixirOfFrostPower : Item
	{
		public ElixirOfFrostPower() : base()
		{
			Id = 17708;
			SellPrice = 35;
			AvailableClasses = 0x7FFF;
			Model = 4136;
			ObjectClass = 0;
			SubClass = 0;
			Level = 38;
			ReqLevel = 28;
			Name = "Elixir of Frost Power";
			Name2 = "Elixir of Frost Power";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 140;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 21920 , 0 , -1 , 0 , 79 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Razorlash Root)
*
***************************************************************/

namespace Server.Items
{
	public class RazorlashRoot : Item
	{
		public RazorlashRoot() : base()
		{
			Id = 17747;
			SellPrice = 500;
			AvailableClasses = 0x7FFF;
			Model = 6624;
			ObjectClass = 0;
			SubClass = 0;
			Level = 50;
			ReqLevel = 40;
			Name = "Razorlash Root";
			Name2 = "Razorlash Root";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2000;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
			SetSpell( 21955 , 0 , -1 , 0 , 30 , 180000 );
		}
	}
}


/**************************************************************
*
*				(Tough Jerky)
*
***************************************************************/

namespace Server.Items
{
	public class ToughJerky18000 : Item
	{
		public ToughJerky18000() : base()
		{
			Id = 18000;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 2473;
			ObjectClass = 0;
			SubClass = 0;
			Level = 5;
			ReqLevel = 1;
			Name = "Tough Jerky";
			Name2 = "Tough Jerky";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 25;
			InventoryType = InventoryTypes.None;
			Stackable = 4;
			Material = -1;
			SetSpell( 433 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Tough Hunk of Bread)
*
***************************************************************/

namespace Server.Items
{
	public class ToughHunkOfBread18001 : Item
	{
		public ToughHunkOfBread18001() : base()
		{
			Id = 18001;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 6399;
			ObjectClass = 0;
			SubClass = 0;
			Level = 5;
			ReqLevel = 1;
			Name = "Tough Hunk of Bread";
			Name2 = "Tough Hunk of Bread";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 25;
			InventoryType = InventoryTypes.None;
			Stackable = 4;
			Material = -1;
			SetSpell( 433 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Forest Mushroom Cap)
*
***************************************************************/

namespace Server.Items
{
	public class ForestMushroomCap18002 : Item
	{
		public ForestMushroomCap18002() : base()
		{
			Id = 18002;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 15852;
			ObjectClass = 0;
			SubClass = 0;
			Level = 5;
			ReqLevel = 1;
			Name = "Forest Mushroom Cap";
			Name2 = "Forest Mushroom Cap";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 25;
			InventoryType = InventoryTypes.None;
			Stackable = 4;
			Material = -1;
			SetSpell( 433 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Shiny Red Apple)
*
***************************************************************/

namespace Server.Items
{
	public class ShinyRedApple18003 : Item
	{
		public ShinyRedApple18003() : base()
		{
			Id = 18003;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 6410;
			ObjectClass = 0;
			SubClass = 0;
			Level = 5;
			ReqLevel = 1;
			Name = "Shiny Red Apple";
			Name2 = "Shiny Red Apple";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 25;
			InventoryType = InventoryTypes.None;
			Stackable = 4;
			Material = -1;
			SetSpell( 433 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Darnassian Bleu)
*
***************************************************************/

namespace Server.Items
{
	public class DarnassianBleu18004 : Item
	{
		public DarnassianBleu18004() : base()
		{
			Id = 18004;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 6353;
			ObjectClass = 0;
			SubClass = 0;
			Level = 5;
			ReqLevel = 1;
			Name = "Darnassian Bleu";
			Name2 = "Darnassian Bleu";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 25;
			InventoryType = InventoryTypes.None;
			Stackable = 2;
			Material = -1;
			SetSpell( 433 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Refreshing Spring Water)
*
***************************************************************/

namespace Server.Items
{
	public class RefreshingSpringWater18005 : Item
	{
		public RefreshingSpringWater18005() : base()
		{
			Id = 18005;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 18084;
			ObjectClass = 0;
			SubClass = 0;
			Level = 5;
			ReqLevel = 1;
			Name = "Refreshing Spring Water";
			Name2 = "Refreshing Spring Water";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 25;
			InventoryType = InventoryTypes.None;
			Stackable = 2;
			Material = -1;
			SetSpell( 430 , 0 , -1 , 0 , 59 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Tender Wolf Steak)
*
***************************************************************/

namespace Server.Items
{
	public class TenderWolfSteak : Item
	{
		public TenderWolfSteak() : base()
		{
			Id = 18045;
			SellPrice = 300;
			AvailableClasses = 0x7FFF;
			Model = 30437;
			ObjectClass = 0;
			SubClass = 0;
			Level = 45;
			ReqLevel = 40;
			Name = "Tender Wolf Steak";
			Name2 = "Tender Wolf Steak";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1200;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 10256 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Blizzard Stationery)
*
***************************************************************/

namespace Server.Items
{
	public class BlizzardStationery : Item
	{
		public BlizzardStationery() : base()
		{
			Id = 18154;
			AvailableClasses = 0x7FFF;
			Model = 30658;
			ObjectClass = 0;
			SubClass = 0;
			Name = "Blizzard Stationery";
			Name2 = "Blizzard Stationery";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
		}
	}
}


/**************************************************************
*
*				(Core Armor Kit)
*
***************************************************************/

namespace Server.Items
{
	public class CoreArmorKit : Item
	{
		public CoreArmorKit() : base()
		{
			Id = 18251;
			SellPrice = 5000;
			AvailableClasses = 0x7FFF;
			Model = 30647;
			ObjectClass = 0;
			SubClass = 0;
			Level = 60;
			ReqLevel = 50;
			Name = "Core Armor Kit";
			Name2 = "Core Armor Kit";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 20000;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 8;
			Flags = 64;
			SetSpell( 22725 , 0 , -1 , 1000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Major Rejuvenation Potion)
*
***************************************************************/

namespace Server.Items
{
	public class MajorRejuvenationPotion : Item
	{
		public MajorRejuvenationPotion() : base()
		{
			Id = 18253;
			SellPrice = 15;
			AvailableClasses = 0x7FFF;
			Model = 24217;
			ObjectClass = 0;
			SubClass = 0;
			Level = 60;
			ReqLevel = 50;
			Name = "Major Rejuvenation Potion";
			Name2 = "Major Rejuvenation Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 60;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 22729 , 0 , -1 , 0 , 4 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Runn Tum Tuber Surprise)
*
***************************************************************/

namespace Server.Items
{
	public class RunnTumTuberSurprise : Item
	{
		public RunnTumTuberSurprise() : base()
		{
			Id = 18254;
			SellPrice = 18;
			AvailableClasses = 0x7FFF;
			Model = 26733;
			ObjectClass = 0;
			SubClass = 0;
			Level = 55;
			ReqLevel = 45;
			Name = "Runn Tum Tuber Surprise";
			Name2 = "Runn Tum Tuber Surprise";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 72;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 22731 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Runn Tum Tuber)
*
***************************************************************/

namespace Server.Items
{
	public class RunnTumTuber : Item
	{
		public RunnTumTuber() : base()
		{
			Id = 18255;
			SellPrice = 15;
			AvailableClasses = 0x7FFF;
			Model = 21974;
			ObjectClass = 0;
			SubClass = 0;
			Level = 55;
			ReqLevel = 45;
			Name = "Runn Tum Tuber";
			Name2 = "Runn Tum Tuber";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 60;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 1129 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Gordok Ogre Suit)
*
***************************************************************/

namespace Server.Items
{
	public class GordokOgreSuit : Item
	{
		public GordokOgreSuit() : base()
		{
			Id = 18258;
			AvailableClasses = 0x7FFF;
			Description = "It lifts AND supports!";
			Model = 30611;
			ObjectClass = 0;
			SubClass = 0;
			Level = 55;
			ReqLevel = 55;
			Name = "Gordok Ogre Suit";
			Name2 = "Gordok Ogre Suit";
			Quality = 2;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			SetSpell( 22736 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Gordok Green Grog)
*
***************************************************************/

namespace Server.Items
{
	public class GordokGreenGrog : Item
	{
		public GordokGreenGrog() : base()
		{
			Id = 18269;
			Bonding = 1;
			SellPrice = 375;
			AvailableClasses = 0x7FFF;
			Model = 18119;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Gordok Green Grog";
			Name2 = "Gordok Green Grog";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1500;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 3;
			SetSpell( 22789 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Kreeg's Stout Beatdown)
*
***************************************************************/

namespace Server.Items
{
	public class KreegsStoutBeatdown : Item
	{
		public KreegsStoutBeatdown() : base()
		{
			Id = 18284;
			Bonding = 1;
			SellPrice = 375;
			AvailableClasses = 0x7FFF;
			Model = 18115;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Kreeg's Stout Beatdown";
			Name2 = "Kreeg's Stout Beatdown";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1500;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 3;
			SetSpell( 22790 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Evermurky)
*
***************************************************************/

namespace Server.Items
{
	public class Evermurky : Item
	{
		public Evermurky() : base()
		{
			Id = 18287;
			SellPrice = 50;
			AvailableClasses = 0x7FFF;
			Description = "Tastes better going down than coming up!";
			Model = 18080;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Evermurky";
			Name2 = "Evermurky";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 200;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 3;
			SetSpell( 11008 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Molasses Firewater)
*
***************************************************************/

namespace Server.Items
{
	public class MolassesFirewater : Item
	{
		public MolassesFirewater() : base()
		{
			Id = 18288;
			SellPrice = 250;
			AvailableClasses = 0x7FFF;
			Description = "Do not consume near open flames.";
			Model = 7921;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Molasses Firewater";
			Name2 = "Molasses Firewater";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 11009 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Elixir of Greater Water Breathing)
*
***************************************************************/

namespace Server.Items
{
	public class ElixirOfGreaterWaterBreathing : Item
	{
		public ElixirOfGreaterWaterBreathing() : base()
		{
			Id = 18294;
			SellPrice = 250;
			AvailableClasses = 0x7FFF;
			Model = 3665;
			ObjectClass = 0;
			SubClass = 0;
			Level = 45;
			ReqLevel = 35;
			Name = "Elixir of Greater Water Breathing";
			Name2 = "Elixir of Greater Water Breathing";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1000;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = 3;
			SetSpell( 22807 , 0 , -1 , 0 , 79 , 3000 );
		}
	}
}


/**************************************************************
*
*				(Thornling Seed)
*
***************************************************************/

namespace Server.Items
{
	public class ThornlingSeed : Item
	{
		public ThornlingSeed() : base()
		{
			Id = 18297;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 30650;
			ObjectClass = 0;
			SubClass = 0;
			Level = 60;
			ReqLevel = 55;
			Name = "Thornling Seed";
			Name2 = "Thornling Seed";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
			SetSpell( 22792 , 0 , -1 , 900000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Alliance Battle Standard)
*
***************************************************************/

namespace Server.Items
{
	public class AllianceBattleStandard : Item
	{
		public AllianceBattleStandard() : base()
		{
			Id = 18606;
			Bonding = 1;
			SellPrice = 12500;
			AvailableClasses = 0x7FFF;
			Model = 31256;
			ObjectClass = 0;
			SubClass = 0;
			Name = "Alliance Battle Standard";
			Name2 = "Alliance Battle Standard";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 50000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			SetSpell( 23034 , 0 , 0 , 600000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Horde Battle Standard)
*
***************************************************************/

namespace Server.Items
{
	public class HordeBattleStandard : Item
	{
		public HordeBattleStandard() : base()
		{
			Id = 18607;
			Bonding = 1;
			SellPrice = 12500;
			AvailableClasses = 0x7FFF;
			Model = 31257;
			ObjectClass = 0;
			SubClass = 0;
			Name = "Horde Battle Standard";
			Name2 = "Horde Battle Standard";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 50000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			SetSpell( 23035 , 0 , 0 , 600000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Moonbrook Riot Taffy)
*
***************************************************************/

namespace Server.Items
{
	public class MoonbrookRiotTaffy : Item
	{
		public MoonbrookRiotTaffy() : base()
		{
			Id = 18632;
			SellPrice = 50;
			AvailableClasses = 0x7FFF;
			Model = 16837;
			ObjectClass = 0;
			SubClass = 0;
			Level = 35;
			ReqLevel = 25;
			Name = "Moonbrook Riot Taffy";
			Name2 = "Moonbrook Riot Taffy";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 1127 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Styleen's Sour Suckerpop)
*
***************************************************************/

namespace Server.Items
{
	public class StyleensSourSuckerpop : Item
	{
		public StyleensSourSuckerpop() : base()
		{
			Id = 18633;
			SellPrice = 6;
			AvailableClasses = 0x7FFF;
			Model = 30996;
			ObjectClass = 0;
			SubClass = 0;
			Level = 15;
			ReqLevel = 5;
			Name = "Styleen's Sour Suckerpop";
			Name2 = "Styleen's Sour Suckerpop";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 125;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 434 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Bellara's Nutterbar)
*
***************************************************************/

namespace Server.Items
{
	public class BellarasNutterbar : Item
	{
		public BellarasNutterbar() : base()
		{
			Id = 18635;
			SellPrice = 100;
			AvailableClasses = 0x7FFF;
			Model = 30997;
			ObjectClass = 0;
			SubClass = 0;
			Level = 45;
			ReqLevel = 35;
			Name = "Bellara's Nutterbar";
			Name2 = "Bellara's Nutterbar";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 1129 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Happy Fun Rock)
*
***************************************************************/

namespace Server.Items
{
	public class HappyFunRock : Item
	{
		public HappyFunRock() : base()
		{
			Id = 18640;
			AvailableClasses = 0x7FFF;
			Model = 24591;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			ReqLevel = 1;
			Name = "Happy Fun Rock";
			Name2 = "Happy Fun Rock";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 2;
			MaxCount = 4;
			Material = -1;
			SetSpell( 23065 , 0 , -1 , 1000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Heavy Leather Ball)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyLeatherBall : Item
	{
		public HeavyLeatherBall() : base()
		{
			Id = 18662;
			SellPrice = 5;
			AvailableClasses = 0x7FFF;
			Model = 31197;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			ReqLevel = 1;
			Name = "Heavy Leather Ball";
			Name2 = "Heavy Leather Ball";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 20;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			MaxCount = 10;
			Material = -1;
			SetSpell( 23135 , 0 , -1 , 1000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Combat Healing Potion)
*
***************************************************************/

namespace Server.Items
{
	public class CombatHealingPotion : Item
	{
		public CombatHealingPotion() : base()
		{
			Id = 18839;
			Bonding = 1;
			SellPrice = 250;
			AvailableClasses = 0x7FFF;
			Model = 29352;
			ObjectClass = 0;
			SubClass = 0;
			Level = 45;
			ReqLevel = 35;
			Name = "Combat Healing Potion";
			Name2 = "Combat Healing Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1000;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			MaxCount = 5;
			Material = -1;
			SetSpell( 4042 , 0 , -1 , 0 , 4 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Combat Mana Potion)
*
***************************************************************/

namespace Server.Items
{
	public class CombatManaPotion : Item
	{
		public CombatManaPotion() : base()
		{
			Id = 18841;
			Bonding = 1;
			SellPrice = 275;
			AvailableClasses = 0x7FFF;
			Model = 29354;
			ObjectClass = 0;
			SubClass = 0;
			Level = 51;
			ReqLevel = 41;
			Name = "Combat Mana Potion";
			Name2 = "Combat Mana Potion";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1100;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			MaxCount = 5;
			Material = 3;
			SetSpell( 17530 , 0 , -1 , 0 , 4 , 120000 );
		}
	}
}


/**************************************************************
*
*				(Minor Healthstone)
*
***************************************************************/

namespace Server.Items
{
	public class MinorHealthstone19004 : Item
	{
		public MinorHealthstone19004() : base()
		{
			Id = 19004;
			AvailableClasses = 0x7FFF;
			Model = 8026;
			ObjectClass = 0;
			SubClass = 0;
			Level = 10;
			ReqLevel = 1;
			Name = "Minor Healthstone";
			Name2 = "Minor Healthstone";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Flags = 2;
			SetSpell( 23468 , 0 , -1 , 0 , 30 , 180000 );
		}
	}
}


/**************************************************************
*
*				(Minor Healthstone)
*
***************************************************************/

namespace Server.Items
{
	public class MinorHealthstone19005 : Item
	{
		public MinorHealthstone19005() : base()
		{
			Id = 19005;
			AvailableClasses = 0x7FFF;
			Model = 8026;
			ObjectClass = 0;
			SubClass = 0;
			Level = 10;
			ReqLevel = 1;
			Name = "Minor Healthstone";
			Name2 = "Minor Healthstone";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Flags = 2;
			SetSpell( 23469 , 0 , -1 , 0 , 30 , 180000 );
		}
	}
}


/**************************************************************
*
*				(Lesser Healthstone)
*
***************************************************************/

namespace Server.Items
{
	public class LesserHealthstone19006 : Item
	{
		public LesserHealthstone19006() : base()
		{
			Id = 19006;
			AvailableClasses = 0x7FFF;
			Model = 8026;
			ObjectClass = 0;
			SubClass = 0;
			Level = 22;
			ReqLevel = 12;
			Name = "Lesser Healthstone";
			Name2 = "Lesser Healthstone";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Flags = 2;
			SetSpell( 23470 , 0 , -1 , 0 , 30 , 180000 );
		}
	}
}


/**************************************************************
*
*				(Lesser Healthstone)
*
***************************************************************/

namespace Server.Items
{
	public class LesserHealthstone19007 : Item
	{
		public LesserHealthstone19007() : base()
		{
			Id = 19007;
			AvailableClasses = 0x7FFF;
			Model = 8026;
			ObjectClass = 0;
			SubClass = 0;
			Level = 22;
			ReqLevel = 12;
			Name = "Lesser Healthstone";
			Name2 = "Lesser Healthstone";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Flags = 2;
			SetSpell( 23471 , 0 , -1 , 0 , 30 , 180000 );
		}
	}
}


/**************************************************************
*
*				(Healthstone)
*
***************************************************************/

namespace Server.Items
{
	public class Healthstone19008 : Item
	{
		public Healthstone19008() : base()
		{
			Id = 19008;
			AvailableClasses = 0x7FFF;
			Model = 8026;
			ObjectClass = 0;
			SubClass = 0;
			Level = 34;
			ReqLevel = 24;
			Name = "Healthstone";
			Name2 = "Healthstone";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Flags = 2;
			SetSpell( 23472 , 0 , -1 , 0 , 30 , 180000 );
		}
	}
}


/**************************************************************
*
*				(Healthstone)
*
***************************************************************/

namespace Server.Items
{
	public class Healthstone19009 : Item
	{
		public Healthstone19009() : base()
		{
			Id = 19009;
			AvailableClasses = 0x7FFF;
			Model = 8026;
			ObjectClass = 0;
			SubClass = 0;
			Level = 34;
			ReqLevel = 24;
			Name = "Healthstone";
			Name2 = "Healthstone";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Flags = 2;
			SetSpell( 23473 , 0 , -1 , 0 , 30 , 180000 );
		}
	}
}


/**************************************************************
*
*				(Greater Healthstone)
*
***************************************************************/

namespace Server.Items
{
	public class GreaterHealthstone19010 : Item
	{
		public GreaterHealthstone19010() : base()
		{
			Id = 19010;
			AvailableClasses = 0x7FFF;
			Model = 8026;
			ObjectClass = 0;
			SubClass = 0;
			Level = 46;
			ReqLevel = 36;
			Name = "Greater Healthstone";
			Name2 = "Greater Healthstone";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Flags = 2;
			SetSpell( 23474 , 0 , -1 , 0 , 30 , 180000 );
		}
	}
}


/**************************************************************
*
*				(Greater Healthstone)
*
***************************************************************/

namespace Server.Items
{
	public class GreaterHealthstone19011 : Item
	{
		public GreaterHealthstone19011() : base()
		{
			Id = 19011;
			AvailableClasses = 0x7FFF;
			Model = 8026;
			ObjectClass = 0;
			SubClass = 0;
			Level = 46;
			ReqLevel = 36;
			Name = "Greater Healthstone";
			Name2 = "Greater Healthstone";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Flags = 2;
			SetSpell( 23475 , 0 , -1 , 0 , 30 , 180000 );
		}
	}
}


/**************************************************************
*
*				(Major Healthstone)
*
***************************************************************/

namespace Server.Items
{
	public class MajorHealthstone19012 : Item
	{
		public MajorHealthstone19012() : base()
		{
			Id = 19012;
			AvailableClasses = 0x7FFF;
			Model = 8026;
			ObjectClass = 0;
			SubClass = 0;
			Level = 58;
			ReqLevel = 48;
			Name = "Major Healthstone";
			Name2 = "Major Healthstone";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Flags = 2;
			SetSpell( 23476 , 0 , -1 , 0 , 30 , 180000 );
		}
	}
}


/**************************************************************
*
*				(Major Healthstone)
*
***************************************************************/

namespace Server.Items
{
	public class MajorHealthstone19013 : Item
	{
		public MajorHealthstone19013() : base()
		{
			Id = 19013;
			AvailableClasses = 0x7FFF;
			Model = 8026;
			ObjectClass = 0;
			SubClass = 0;
			Level = 58;
			ReqLevel = 48;
			Name = "Major Healthstone";
			Name2 = "Major Healthstone";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = 1;
			Flags = 2;
			SetSpell( 23477 , 0 , -1 , 0 , 30 , 180000 );
		}
	}
}


/**************************************************************
*
*				(Snake Bloom Firework)
*
***************************************************************/

namespace Server.Items
{
	public class SnakeBloomFirework : Item
	{
		public SnakeBloomFirework() : base()
		{
			Id = 19026;
			SellPrice = 250;
			AvailableClasses = 0x7FFF;
			Model = 18070;
			ObjectClass = 0;
			SubClass = 0;
			Level = 50;
			Name = "Snake Bloom Firework";
			Name2 = "Snake Bloom Firework";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1000;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = -1;
			SetSpell( 11544 , 0 , -1 , 1000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Stormpike Battle Standard)
*
***************************************************************/

namespace Server.Items
{
	public class StormpikeBattleStandard : Item
	{
		public StormpikeBattleStandard() : base()
		{
			Id = 19045;
			Bonding = 1;
			SellPrice = 12500;
			AvailableClasses = 0x7FFF;
			Model = 31256;
			ObjectClass = 0;
			SubClass = 0;
			Name = "Stormpike Battle Standard";
			Name2 = "Stormpike Battle Standard";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 50000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			SetSpell( 23539 , 0 , 0 , 900000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Frostwolf Battle Standard)
*
***************************************************************/

namespace Server.Items
{
	public class FrostwolfBattleStandard : Item
	{
		public FrostwolfBattleStandard() : base()
		{
			Id = 19046;
			Bonding = 1;
			SellPrice = 12500;
			AvailableClasses = 0x7FFF;
			Model = 31257;
			ObjectClass = 0;
			SubClass = 0;
			Name = "Frostwolf Battle Standard";
			Name2 = "Frostwolf Battle Standard";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 50000;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			Material = -1;
			SetSpell( 23538 , 0 , 0 , 900000 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Warsong Gulch Enriched Ration)
*
***************************************************************/

namespace Server.Items
{
	public class WarsongGulchEnrichedRation : Item
	{
		public WarsongGulchEnrichedRation() : base()
		{
			Id = 19060;
			Bonding = 1;
			SellPrice = 100;
			AvailableClasses = 0x7FFF;
			Model = 21203;
			ObjectClass = 0;
			SubClass = 0;
			Level = 55;
			ReqLevel = 45;
			Name = "Warsong Gulch Enriched Ration";
			Name2 = "Warsong Gulch Enriched Ration";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 23540 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Warsong Gulch Iron Ration)
*
***************************************************************/

namespace Server.Items
{
	public class WarsongGulchIronRation : Item
	{
		public WarsongGulchIronRation() : base()
		{
			Id = 19061;
			Bonding = 1;
			SellPrice = 75;
			AvailableClasses = 0x7FFF;
			Model = 6344;
			ObjectClass = 0;
			SubClass = 0;
			Level = 45;
			ReqLevel = 35;
			Name = "Warsong Gulch Iron Ration";
			Name2 = "Warsong Gulch Iron Ration";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1500;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 23541 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Warsong Gulch Field Ration)
*
***************************************************************/

namespace Server.Items
{
	public class WarsongGulchFieldRation : Item
	{
		public WarsongGulchFieldRation() : base()
		{
			Id = 19062;
			Bonding = 1;
			SellPrice = 50;
			AvailableClasses = 0x7FFF;
			Model = 6413;
			ObjectClass = 0;
			SubClass = 0;
			Level = 35;
			ReqLevel = 25;
			Name = "Warsong Gulch Field Ration";
			Name2 = "Warsong Gulch Field Ration";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 23542 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Fire Runed Grimoire)
*
***************************************************************/

namespace Server.Items
{
	public class FireRunedGrimoire : Item
	{
		public FireRunedGrimoire() : base()
		{
			Id = 19142;
			Bonding = 1;
			SellPrice = 18903;
			AvailableClasses = 0x7FFF;
			Model = 23321;
			ObjectClass = 0;
			SubClass = 0;
			Level = 70;
			ReqLevel = 60;
			Name = "Fire Runed Grimoire";
			Name2 = "Fire Runed Grimoire";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 75615;
			InventoryType = InventoryTypes.HeldInHand;
			Stackable = 1;
			Material = 8;
			SetSpell( 9416 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 21;
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Sentinel Basic Care Package)
*
***************************************************************/

namespace Server.Items
{
	public class SentinelBasicCarePackage : Item
	{
		public SentinelBasicCarePackage() : base()
		{
			Id = 19150;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 26420;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Sentinel Basic Care Package";
			Name2 = "Sentinel Basic Care Package";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Sentinel Standard Care Package)
*
***************************************************************/

namespace Server.Items
{
	public class SentinelStandardCarePackage : Item
	{
		public SentinelStandardCarePackage() : base()
		{
			Id = 19151;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 26420;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Sentinel Standard Care Package";
			Name2 = "Sentinel Standard Care Package";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Sentinel Advanced Care Package)
*
***************************************************************/

namespace Server.Items
{
	public class SentinelAdvancedCarePackage : Item
	{
		public SentinelAdvancedCarePackage() : base()
		{
			Id = 19152;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 26420;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Sentinel Advanced Care Package";
			Name2 = "Sentinel Advanced Care Package";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Outrider Advanced Care Package)
*
***************************************************************/

namespace Server.Items
{
	public class OutriderAdvancedCarePackage : Item
	{
		public OutriderAdvancedCarePackage() : base()
		{
			Id = 19153;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 7242;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Outrider Advanced Care Package";
			Name2 = "Outrider Advanced Care Package";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Outrider Basic Care Package)
*
***************************************************************/

namespace Server.Items
{
	public class OutriderBasicCarePackage : Item
	{
		public OutriderBasicCarePackage() : base()
		{
			Id = 19154;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 7242;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Outrider Basic Care Package";
			Name2 = "Outrider Basic Care Package";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Outrider Standard Care Package)
*
***************************************************************/

namespace Server.Items
{
	public class OutriderStandardCarePackage : Item
	{
		public OutriderStandardCarePackage() : base()
		{
			Id = 19155;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 7242;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Outrider Standard Care Package";
			Name2 = "Outrider Standard Care Package";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = -1;
			Flags = 4;
		}
	}
}


/**************************************************************
*
*				(Darkmoon Faire Prize Ticket)
*
***************************************************************/

namespace Server.Items
{
	public class DarkmoonFairePrizeTicket : Item
	{
		public DarkmoonFairePrizeTicket() : base()
		{
			Id = 19182;
			Bonding = 1;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 31745;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Darkmoon Faire Prize Ticket";
			Name2 = "Darkmoon Faire Prize Ticket";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 100;
			InventoryType = InventoryTypes.None;
			Stackable = 200;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Hourglass Sand)
*
***************************************************************/

namespace Server.Items
{
	public class HourglassSand : Item
	{
		public HourglassSand() : base()
		{
			Id = 19183;
			AvailableClasses = 0x7FFF;
			Model = 2596;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Hourglass Sand";
			Name2 = "Hourglass Sand";
			Quality = 1;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 5;
			Material = -1;
			Flags = 64;
			SetSpell( 23645 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Darkmoon Special Reserve)
*
***************************************************************/

namespace Server.Items
{
	public class DarkmoonSpecialReserve : Item
	{
		public DarkmoonSpecialReserve() : base()
		{
			Id = 19221;
			SellPrice = 12;
			AvailableClasses = 0x7FFF;
			Model = 18119;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Darkmoon Special Reserve";
			Name2 = "Darkmoon Special Reserve";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 50;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 3;
			SetSpell( 11629 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Cheap Beer)
*
***************************************************************/

namespace Server.Items
{
	public class CheapBeer : Item
	{
		public CheapBeer() : base()
		{
			Id = 19222;
			SellPrice = 2;
			AvailableClasses = 0x7FFF;
			Model = 18102;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Cheap Beer";
			Name2 = "Cheap Beer";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 10;
			InventoryType = InventoryTypes.None;
			Stackable = 10;
			Material = 3;
			SetSpell( 11007 , 0 , -1 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Darkmoon Dog)
*
***************************************************************/

namespace Server.Items
{
	public class DarkmoonDog : Item
	{
		public DarkmoonDog() : base()
		{
			Id = 19223;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 31742;
			ObjectClass = 0;
			SubClass = 0;
			Level = 5;
			ReqLevel = 1;
			Name = "Darkmoon Dog";
			Name2 = "Darkmoon Dog";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 25;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 433 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Red Hot Wings)
*
***************************************************************/

namespace Server.Items
{
	public class RedHotWings : Item
	{
		public RedHotWings() : base()
		{
			Id = 19224;
			SellPrice = 50;
			AvailableClasses = 0x7FFF;
			Model = 22200;
			ObjectClass = 0;
			SubClass = 0;
			Level = 35;
			ReqLevel = 25;
			Name = "Red Hot Wings";
			Name2 = "Red Hot Wings";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 1127 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Deep Fried Candybar)
*
***************************************************************/

namespace Server.Items
{
	public class DeepFriedCandybar : Item
	{
		public DeepFriedCandybar() : base()
		{
			Id = 19225;
			SellPrice = 200;
			AvailableClasses = 0x7FFF;
			Model = 15964;
			ObjectClass = 0;
			SubClass = 0;
			Level = 55;
			ReqLevel = 45;
			Name = "Deep Fried Candybar";
			Name2 = "Deep Fried Candybar";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 4000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 1131 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Fizzy Faire Drink)
*
***************************************************************/

namespace Server.Items
{
	public class FizzyFaireDrink : Item
	{
		public FizzyFaireDrink() : base()
		{
			Id = 19299;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 18115;
			ObjectClass = 0;
			SubClass = 0;
			Level = 25;
			ReqLevel = 15;
			Name = "Fizzy Faire Drink";
			Name2 = "Fizzy Faire Drink";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 500;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 7;
			SetSpell( 432 , 0 , -1 , 0 , 59 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Bottled Winterspring Water)
*
***************************************************************/

namespace Server.Items
{
	public class BottledWinterspringWater : Item
	{
		public BottledWinterspringWater() : base()
		{
			Id = 19300;
			SellPrice = 100;
			AvailableClasses = 0x7FFF;
			Model = 21794;
			ObjectClass = 0;
			SubClass = 0;
			Level = 45;
			ReqLevel = 35;
			Name = "Bottled Winterspring Water";
			Name2 = "Bottled Winterspring Water";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = 7;
			SetSpell( 1135 , 0 , -1 , 0 , 59 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Alterac Manna Biscuit)
*
***************************************************************/

namespace Server.Items
{
	public class AlteracMannaBiscuit : Item
	{
		public AlteracMannaBiscuit() : base()
		{
			Id = 19301;
			Bonding = 1;
			SellPrice = 350;
			AvailableClasses = 0x7FFF;
			Model = 21203;
			ObjectClass = 0;
			SubClass = 0;
			Level = 60;
			ReqLevel = 51;
			Name = "Alterac Manna Biscuit";
			Name2 = "Alterac Manna Biscuit";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 7000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 23692 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Spiced Beef Jerky)
*
***************************************************************/

namespace Server.Items
{
	public class SpicedBeefJerky : Item
	{
		public SpicedBeefJerky() : base()
		{
			Id = 19304;
			SellPrice = 6;
			AvailableClasses = 0x7FFF;
			Model = 31803;
			ObjectClass = 0;
			SubClass = 0;
			Level = 15;
			ReqLevel = 5;
			Name = "Spiced Beef Jerky";
			Name2 = "Spiced Beef Jerky";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 125;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 434 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Pickled Kodo Foot)
*
***************************************************************/

namespace Server.Items
{
	public class PickledKodoFoot : Item
	{
		public PickledKodoFoot() : base()
		{
			Id = 19305;
			SellPrice = 25;
			AvailableClasses = 0x7FFF;
			Model = 31802;
			ObjectClass = 0;
			SubClass = 0;
			Level = 25;
			ReqLevel = 15;
			Name = "Pickled Kodo Foot";
			Name2 = "Pickled Kodo Foot";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 500;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 435 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Crunchy Frog)
*
***************************************************************/

namespace Server.Items
{
	public class CrunchyFrog : Item
	{
		public CrunchyFrog() : base()
		{
			Id = 19306;
			SellPrice = 100;
			AvailableClasses = 0x7FFF;
			Model = 31804;
			ObjectClass = 0;
			SubClass = 0;
			Level = 45;
			ReqLevel = 35;
			Name = "Crunchy Frog";
			Name2 = "Crunchy Frog";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			SetSpell( 1129 , 0 , -1 , 0 , 11 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Bottled Alterac Spring Water)
*
***************************************************************/

namespace Server.Items
{
	public class BottledAlteracSpringWater : Item
	{
		public BottledAlteracSpringWater() : base()
		{
			Id = 19318;
			Bonding = 1;
			SellPrice = 250;
			AvailableClasses = 0x7FFF;
			Description = "From the mountain springs of Alterac!";
			Model = 18080;
			ObjectClass = 0;
			SubClass = 0;
			Level = 55;
			ReqLevel = 45;
			Name = "Bottled Alterac Spring Water";
			Name2 = "Bottled Alterac Spring Water";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 5000;
			InventoryType = InventoryTypes.None;
			Stackable = 20;
			Material = -1;
			Flags = 64;
			SetSpell( 23698 , 0 , -1 , 0 , 59 , 1000 );
		}
	}
}


/**************************************************************
*
*				(Mysterious Lockbox)
*
***************************************************************/

namespace Server.Items
{
	public class MysteriousLockbox : Item
	{
		public MysteriousLockbox() : base()
		{
			Id = 19425;
			Bonding = 1;
			AvailableClasses = 0x7FFF;
			Model = 18721;
			ObjectClass = 0;
			SubClass = 0;
			Level = 1;
			Name = "Mysterious Lockbox";
			Name2 = "Mysterious Lockbox";
			Quality = 2;
			AvailableRaces = 0x1FF;
			InventoryType = InventoryTypes.None;
			Stackable = 1;
			MaxCount = 1;
			Material = 2;
			Flags = 4;
		}
	}
}


