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
*				(Pirates Patch (Test))
*
***************************************************************/

namespace Server.Items
{
	public class PiratesPatchTest : Item
	{
		public PiratesPatchTest() : base()
		{
			Id = 1162;
			Resistance[0] = 23;
			SellPrice = 44;
			AvailableClasses = 0x7FFF;
			Model = 13219;
			ObjectClass = 4;
			SubClass = 1;
			Level = 10;
			ReqLevel = 5;
			Name = "Pirates Patch (Test)";
			Name2 = "Pirates Patch (Test)";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 222;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
		}
	}
}


/**************************************************************
*
*				(Augural Shroud)
*
***************************************************************/

namespace Server.Items
{
	public class AuguralShroud : Item
	{
		public AuguralShroud() : base()
		{
			Id = 2620;
			Resistance[0] = 42;
			Bonding = 2;
			SellPrice = 3013;
			AvailableClasses = 0x7FFF;
			Model = 15284;
			ObjectClass = 4;
			SubClass = 1;
			Level = 39;
			ReqLevel = 34;
			Name = "Augural Shroud";
			Name2 = "Augural Shroud";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 15067;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			AgilityBonus = 11;
			SpiritBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Cowl of Necromancy)
*
***************************************************************/

namespace Server.Items
{
	public class CowlOfNecromancy : Item
	{
		public CowlOfNecromancy() : base()
		{
			Id = 2621;
			Resistance[0] = 39;
			Bonding = 2;
			SellPrice = 2357;
			AvailableClasses = 0x7FFF;
			Model = 15295;
			ObjectClass = 4;
			SubClass = 1;
			Level = 36;
			ReqLevel = 31;
			Name = "Cowl of Necromancy";
			Name2 = "Cowl of Necromancy";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11787;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			SpiritBonus = 15;
			StaminaBonus = -5;
		}
	}
}


/**************************************************************
*
*				(Nimar's Tribal Headdress)
*
***************************************************************/

namespace Server.Items
{
	public class NimarsTribalHeaddress : Item
	{
		public NimarsTribalHeaddress() : base()
		{
			Id = 2622;
			Resistance[0] = 40;
			Bonding = 2;
			SellPrice = 2603;
			AvailableClasses = 0x7FFF;
			Model = 13244;
			ObjectClass = 4;
			SubClass = 1;
			Level = 37;
			ReqLevel = 32;
			Name = "Nimar's Tribal Headdress";
			Name2 = "Nimar's Tribal Headdress";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 13015;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			StaminaBonus = 6;
			SpiritBonus = 7;
			IqBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Holy Diadem)
*
***************************************************************/

namespace Server.Items
{
	public class HolyDiadem : Item
	{
		public HolyDiadem() : base()
		{
			Id = 2623;
			Resistance[0] = 44;
			Bonding = 2;
			SellPrice = 3554;
			AvailableClasses = 0x7FFF;
			Model = 15336;
			ObjectClass = 4;
			SubClass = 1;
			Level = 41;
			ReqLevel = 36;
			Name = "Holy Diadem";
			Name2 = "Holy Diadem";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 17772;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			StaminaBonus = 11;
			IqBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Thinking Cap)
*
***************************************************************/

namespace Server.Items
{
	public class ThinkingCap : Item
	{
		public ThinkingCap() : base()
		{
			Id = 2624;
			Resistance[0] = 45;
			Bonding = 2;
			SellPrice = 3852;
			AvailableClasses = 0x7FFF;
			Model = 15547;
			ObjectClass = 4;
			SubClass = 1;
			Level = 42;
			ReqLevel = 37;
			Name = "Thinking Cap";
			Name2 = "Thinking Cap";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 19264;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			SpiritBonus = 17;
		}
	}
}


/**************************************************************
*
*				(Holy Shroud)
*
***************************************************************/

namespace Server.Items
{
	public class HolyShroud : Item
	{
		public HolyShroud() : base()
		{
			Id = 2721;
			Resistance[0] = 40;
			Bonding = 2;
			SellPrice = 1982;
			AvailableClasses = 0x7FFF;
			Model = 16826;
			ObjectClass = 4;
			SubClass = 1;
			Level = 32;
			ReqLevel = 27;
			Name = "Holy Shroud";
			Name2 = "Holy Shroud";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 9914;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 50;
			SetSpell( 9318 , 1 , 0 , -1 , 0 , -1 );
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(First Mate Hat)
*
***************************************************************/

namespace Server.Items
{
	public class FirstMateHat : Item
	{
		public FirstMateHat() : base()
		{
			Id = 2955;
			Resistance[0] = 43;
			Bonding = 2;
			SellPrice = 3449;
			AvailableClasses = 0x7FFF;
			Model = 16545;
			ObjectClass = 4;
			SubClass = 1;
			Level = 40;
			ReqLevel = 35;
			Name = "First Mate Hat";
			Name2 = "First Mate Hat";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 17247;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			StaminaBonus = 11;
			IqBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Deprecated Silver-thread Cowl)
*
***************************************************************/

namespace Server.Items
{
	public class DeprecatedSilverThreadCowl : Item
	{
		public DeprecatedSilverThreadCowl() : base()
		{
			Id = 3068;
			Resistance[0] = 36;
			Bonding = 2;
			SellPrice = 1700;
			AvailableClasses = 0x7FFF;
			Model = 16824;
			ObjectClass = 4;
			SubClass = 1;
			Level = 32;
			ReqLevel = 27;
			Name = "Deprecated Silver-thread Cowl";
			Name2 = "Deprecated Silver-thread Cowl";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 8501;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			Flags = 16;
			SpiritBonus = 8;
			IqBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Eye of Flame)
*
***************************************************************/

namespace Server.Items
{
	public class EyeOfFlame : Item
	{
		public EyeOfFlame() : base()
		{
			Id = 3075;
			Resistance[0] = 70;
			Bonding = 2;
			SellPrice = 15073;
			AvailableClasses = 0x7FFF;
			Model = 15322;
			Resistance[2] = 15;
			ObjectClass = 4;
			SubClass = 1;
			Level = 55;
			ReqLevel = 49;
			Name = "Eye of Flame";
			Name2 = "Eye of Flame";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 75368;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 60;
			SetSpell( 17878 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 10;
			IqBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Silk Wizard Hat)
*
***************************************************************/

namespace Server.Items
{
	public class SilkWizardHat : Item
	{
		public SilkWizardHat() : base()
		{
			Id = 3345;
			Resistance[0] = 40;
			Bonding = 2;
			SellPrice = 2720;
			AvailableClasses = 0x7FFF;
			Model = 15912;
			ObjectClass = 4;
			SubClass = 1;
			Level = 37;
			ReqLevel = 32;
			Name = "Silk Wizard Hat";
			Name2 = "Silk Wizard Hat";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 13601;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			SpiritBonus = 10;
			IqBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Dread Mage Hat)
*
***************************************************************/

namespace Server.Items
{
	public class DreadMageHat : Item
	{
		public DreadMageHat() : base()
		{
			Id = 3556;
			Resistance[0] = 35;
			Bonding = 1;
			SellPrice = 1285;
			AvailableClasses = 0x7B00;
			Model = 16544;
			ObjectClass = 4;
			SubClass = 1;
			Level = 30;
			Name = "Dread Mage Hat";
			Name2 = "Dread Mage Hat";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6429;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			SpiritBonus = 7;
			IqBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Hooded Cowl)
*
***************************************************************/

namespace Server.Items
{
	public class HoodedCowl : Item
	{
		public HoodedCowl() : base()
		{
			Id = 3732;
			Resistance[0] = 33;
			Bonding = 1;
			SellPrice = 801;
			AvailableClasses = 0x7FFF;
			Model = 15339;
			ObjectClass = 4;
			SubClass = 1;
			Level = 30;
			Name = "Hooded Cowl";
			Name2 = "Hooded Cowl";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 4006;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Russet Hat)
*
***************************************************************/

namespace Server.Items
{
	public class RussetHat : Item
	{
		public RussetHat() : base()
		{
			Id = 3889;
			Resistance[0] = 38;
			SellPrice = 1584;
			AvailableClasses = 0x7FFF;
			Model = 15908;
			ObjectClass = 4;
			SubClass = 1;
			Level = 37;
			ReqLevel = 32;
			Name = "Russet Hat";
			Name2 = "Russet Hat";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 7922;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Embroidered Hat)
*
***************************************************************/

namespace Server.Items
{
	public class EmbroideredHat : Item
	{
		public EmbroideredHat() : base()
		{
			Id = 3892;
			Resistance[0] = 50;
			SellPrice = 4388;
			AvailableClasses = 0x7FFF;
			Model = 16775;
			ObjectClass = 4;
			SubClass = 1;
			Level = 50;
			ReqLevel = 45;
			Name = "Embroidered Hat";
			Name2 = "Embroidered Hat";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 21940;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Nightsky Cowl)
*
***************************************************************/

namespace Server.Items
{
	public class NightskyCowl : Item
	{
		public NightskyCowl() : base()
		{
			Id = 4039;
			Resistance[0] = 38;
			Bonding = 2;
			SellPrice = 2215;
			AvailableClasses = 0x7FFF;
			Model = 15298;
			ObjectClass = 4;
			SubClass = 1;
			Level = 35;
			ReqLevel = 30;
			Name = "Nightsky Cowl";
			Name2 = "Nightsky Cowl";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11078;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			SpiritBonus = 12;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Aurora Cowl)
*
***************************************************************/

namespace Server.Items
{
	public class AuroraCowl : Item
	{
		public AuroraCowl() : base()
		{
			Id = 4041;
			Resistance[0] = 42;
			Bonding = 2;
			SellPrice = 3149;
			AvailableClasses = 0x7FFF;
			Model = 15287;
			ObjectClass = 4;
			SubClass = 1;
			Level = 39;
			ReqLevel = 34;
			Name = "Aurora Cowl";
			Name2 = "Aurora Cowl";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 15749;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			StaminaBonus = 10;
			SpiritBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Enchanter's Cowl)
*
***************************************************************/

namespace Server.Items
{
	public class EnchantersCowl : Item
	{
		public EnchantersCowl() : base()
		{
			Id = 4322;
			Resistance[0] = 37;
			Bonding = 2;
			SellPrice = 1810;
			AvailableClasses = 0x7FFF;
			Model = 15314;
			ObjectClass = 4;
			SubClass = 1;
			Level = 33;
			ReqLevel = 28;
			Name = "Enchanter's Cowl";
			Name2 = "Enchanter's Cowl";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 9053;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			SpiritBonus = 10;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Shadow Hood)
*
***************************************************************/

namespace Server.Items
{
	public class ShadowHood : Item
	{
		public ShadowHood() : base()
		{
			Id = 4323;
			Resistance[0] = 37;
			Bonding = 2;
			SellPrice = 1999;
			AvailableClasses = 0x7FFF;
			Model = 15319;
			ObjectClass = 4;
			SubClass = 1;
			Level = 34;
			ReqLevel = 29;
			Name = "Shadow Hood";
			Name2 = "Shadow Hood";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 9995;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			SetSpell( 7708 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Flying Tiger Goggles)
*
***************************************************************/

namespace Server.Items
{
	public class FlyingTigerGoggles : Item
	{
		public FlyingTigerGoggles() : base()
		{
			Id = 4368;
			Resistance[0] = 27;
			Bonding = 2;
			SellPrice = 408;
			AvailableClasses = 0x7FFF;
			Model = 13236;
			ObjectClass = 4;
			SubClass = 1;
			Level = 20;
			Name = "Flying Tiger Goggles";
			Name2 = "Flying Tiger Goggles";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 100;
			Skill = 202;
			BuyPrice = 2043;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 35;
			StaminaBonus = 4;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Shadow Goggles)
*
***************************************************************/

namespace Server.Items
{
	public class ShadowGoggles : Item
	{
		public ShadowGoggles() : base()
		{
			Id = 4373;
			Resistance[0] = 31;
			Bonding = 2;
			SellPrice = 722;
			AvailableClasses = 0x7FFF;
			Model = 26619;
			ObjectClass = 4;
			SubClass = 1;
			Level = 24;
			Name = "Shadow Goggles";
			Name2 = "Shadow Goggles";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 120;
			Skill = 202;
			BuyPrice = 3613;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 40;
			IqBonus = 6;
			SpiritBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Green Tinted Goggles)
*
***************************************************************/

namespace Server.Items
{
	public class GreenTintedGoggles : Item
	{
		public GreenTintedGoggles() : base()
		{
			Id = 4385;
			Resistance[0] = 35;
			Bonding = 2;
			SellPrice = 1410;
			AvailableClasses = 0x7FFF;
			Model = 22422;
			ObjectClass = 4;
			SubClass = 1;
			Level = 30;
			Name = "Green Tinted Goggles";
			Name2 = "Green Tinted Goggles";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 150;
			Skill = 202;
			BuyPrice = 7052;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			StaminaBonus = 8;
			IqBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Craftsman's Monocle)
*
***************************************************************/

namespace Server.Items
{
	public class CraftsmansMonocle : Item
	{
		public CraftsmansMonocle() : base()
		{
			Id = 4393;
			Resistance[0] = 40;
			Bonding = 2;
			SellPrice = 2632;
			AvailableClasses = 0x7FFF;
			Model = 13215;
			ObjectClass = 4;
			SubClass = 1;
			Level = 37;
			ReqLevel = 32;
			Name = "Craftsman's Monocle";
			Name2 = "Craftsman's Monocle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 185;
			Skill = 202;
			BuyPrice = 13162;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			SpiritBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Living Cowl)
*
***************************************************************/

namespace Server.Items
{
	public class LivingCowl : Item
	{
		public LivingCowl() : base()
		{
			Id = 5608;
			Resistance[0] = 43;
			Bonding = 2;
			SellPrice = 3463;
			AvailableClasses = 0x7FFF;
			Model = 15278;
			ObjectClass = 4;
			SubClass = 1;
			Level = 40;
			ReqLevel = 35;
			Name = "Living Cowl";
			Name2 = "Living Cowl";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 17315;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			StaminaBonus = 11;
			IqBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Circlet of the Order)
*
***************************************************************/

namespace Server.Items
{
	public class CircletOfTheOrder : Item
	{
		public CircletOfTheOrder() : base()
		{
			Id = 5624;
			Resistance[0] = 41;
			Bonding = 2;
			SellPrice = 2926;
			AvailableClasses = 0x7FFF;
			Model = 15905;
			ObjectClass = 4;
			SubClass = 1;
			Level = 38;
			ReqLevel = 33;
			Name = "Circlet of the Order";
			Name2 = "Circlet of the Order";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 14634;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			StaminaBonus = 7;
			SpiritBonus = 3;
			IqBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Mistscape Wizard Hat)
*
***************************************************************/

namespace Server.Items
{
	public class MistscapeWizardHat : Item
	{
		public MistscapeWizardHat() : base()
		{
			Id = 6429;
			Resistance[0] = 47;
			Bonding = 2;
			SellPrice = 4544;
			AvailableClasses = 0x7FFF;
			Model = 15910;
			ObjectClass = 4;
			SubClass = 1;
			Level = 44;
			ReqLevel = 39;
			Name = "Mistscape Wizard Hat";
			Name2 = "Mistscape Wizard Hat";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 22724;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			StaminaBonus = 4;
			SpiritBonus = 10;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Azure Silk Hood)
*
***************************************************************/

namespace Server.Items
{
	public class AzureSilkHood : Item
	{
		public AzureSilkHood() : base()
		{
			Id = 7048;
			Resistance[0] = 33;
			SellPrice = 745;
			AvailableClasses = 0x7FFF;
			Model = 15283;
			ObjectClass = 4;
			SubClass = 1;
			Level = 29;
			ReqLevel = 24;
			Name = "Azure Silk Hood";
			Name2 = "Azure Silk Hood";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 3725;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Silk Headband)
*
***************************************************************/

namespace Server.Items
{
	public class SilkHeadband : Item
	{
		public SilkHeadband() : base()
		{
			Id = 7050;
			Resistance[0] = 34;
			SellPrice = 999;
			AvailableClasses = 0x7FFF;
			Model = 15863;
			ObjectClass = 4;
			SubClass = 1;
			Level = 32;
			ReqLevel = 27;
			Name = "Silk Headband";
			Name2 = "Silk Headband";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 4995;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Elder's Hat)
*
***************************************************************/

namespace Server.Items
{
	public class EldersHat : Item
	{
		public EldersHat() : base()
		{
			Id = 7357;
			Resistance[0] = 37;
			Bonding = 2;
			SellPrice = 1875;
			AvailableClasses = 0x7FFF;
			Model = 15906;
			ObjectClass = 4;
			SubClass = 1;
			Level = 34;
			ReqLevel = 29;
			Name = "Elder's Hat";
			Name2 = "Elder's Hat";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 630;
			BuyPrice = 9378;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Twilight Cowl)
*
***************************************************************/

namespace Server.Items
{
	public class TwilightCowl : Item
	{
		public TwilightCowl() : base()
		{
			Id = 7432;
			Resistance[0] = 41;
			Bonding = 2;
			SellPrice = 2717;
			AvailableClasses = 0x7FFF;
			Model = 16825;
			ObjectClass = 4;
			SubClass = 1;
			Level = 38;
			ReqLevel = 33;
			Name = "Twilight Cowl";
			Name2 = "Twilight Cowl";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 631;
			BuyPrice = 13589;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Regal Wizard Hat)
*
***************************************************************/

namespace Server.Items
{
	public class RegalWizardHat : Item
	{
		public RegalWizardHat() : base()
		{
			Id = 7470;
			Resistance[0] = 45;
			Bonding = 2;
			SellPrice = 3668;
			AvailableClasses = 0x7FFF;
			Model = 15911;
			ObjectClass = 4;
			SubClass = 1;
			Level = 42;
			ReqLevel = 37;
			Name = "Regal Wizard Hat";
			Name2 = "Regal Wizard Hat";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 632;
			BuyPrice = 18341;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Gossamer Headpiece)
*
***************************************************************/

namespace Server.Items
{
	public class GossamerHeadpiece : Item
	{
		public GossamerHeadpiece() : base()
		{
			Id = 7520;
			Resistance[0] = 50;
			Bonding = 2;
			SellPrice = 5747;
			AvailableClasses = 0x7FFF;
			Model = 15909;
			ObjectClass = 4;
			SubClass = 1;
			Level = 47;
			ReqLevel = 42;
			Name = "Gossamer Headpiece";
			Name2 = "Gossamer Headpiece";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 634;
			BuyPrice = 28737;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Embalmed Shroud)
*
***************************************************************/

namespace Server.Items
{
	public class EmbalmedShroud : Item
	{
		public EmbalmedShroud() : base()
		{
			Id = 7691;
			Resistance[0] = 42;
			Bonding = 1;
			SellPrice = 2689;
			AvailableClasses = 0x7FFF;
			Model = 16823;
			ObjectClass = 4;
			SubClass = 1;
			Level = 35;
			ReqLevel = 30;
			Name = "Embalmed Shroud";
			Name2 = "Embalmed Shroud";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 13445;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 50;
			IqBonus = 12;
			StaminaBonus = 7;
			SpiritBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Whitemane's Chapeau)
*
***************************************************************/

namespace Server.Items
{
	public class WhitemanesChapeau : Item
	{
		public WhitemanesChapeau() : base()
		{
			Id = 7720;
			Resistance[0] = 52;
			Bonding = 1;
			SellPrice = 5356;
			AvailableClasses = 0x7FFF;
			Model = 16224;
			ObjectClass = 4;
			SubClass = 1;
			Level = 44;
			ReqLevel = 39;
			Name = "Whitemane's Chapeau";
			Name2 = "Whitemane's Chapeau";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 26783;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 50;
			IqBonus = 14;
			SpiritBonus = 14;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Lucky Fishing Hat)
*
***************************************************************/

namespace Server.Items
{
	public class LuckyFishingHat : Item
	{
		public LuckyFishingHat() : base()
		{
			Id = 7996;
			Resistance[0] = 42;
			SellPrice = 244;
			AvailableClasses = 0x7FFF;
			Model = 16548;
			ObjectClass = 4;
			SubClass = 1;
			Level = 20;
			ReqLevel = 15;
			Name = "Lucky Fishing Hat";
			Name2 = "Lucky Fishing Hat";
			Quality = 1;
			AvailableRaces = 0x1FF;
			SkillRank = 1;
			Skill = 356;
			BuyPrice = 1222;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = -1;
			SetSpell( 7823 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Hibernal Cowl)
*
***************************************************************/

namespace Server.Items
{
	public class HibernalCowl : Item
	{
		public HibernalCowl() : base()
		{
			Id = 8115;
			Resistance[0] = 51;
			Bonding = 2;
			SellPrice = 5980;
			AvailableClasses = 0x7FFF;
			Model = 16638;
			ObjectClass = 4;
			SubClass = 1;
			Level = 48;
			ReqLevel = 43;
			Name = "Hibernal Cowl";
			Name2 = "Hibernal Cowl";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 29902;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			SpiritBonus = 13;
			IqBonus = 14;
		}
	}
}


/**************************************************************
*
*				(Imperial Red Circlet)
*
***************************************************************/

namespace Server.Items
{
	public class ImperialRedCirclet : Item
	{
		public ImperialRedCirclet() : base()
		{
			Id = 8254;
			Resistance[0] = 56;
			Bonding = 2;
			SellPrice = 8639;
			AvailableClasses = 0x7FFF;
			Model = 18728;
			ObjectClass = 4;
			SubClass = 1;
			Level = 53;
			ReqLevel = 48;
			Name = "Imperial Red Circlet";
			Name2 = "Imperial Red Circlet";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 43199;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			SpiritBonus = 16;
			IqBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Arcane Cover)
*
***************************************************************/

namespace Server.Items
{
	public class ArcaneCover : Item
	{
		public ArcaneCover() : base()
		{
			Id = 8292;
			Resistance[0] = 61;
			Bonding = 2;
			SellPrice = 11476;
			AvailableClasses = 0x7FFF;
			Model = 17274;
			ObjectClass = 4;
			SubClass = 1;
			Level = 58;
			ReqLevel = 53;
			Name = "Arcane Cover";
			Name2 = "Arcane Cover";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 57382;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			StaminaBonus = 10;
			SpiritBonus = 17;
			IqBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Interlaced Cowl)
*
***************************************************************/

namespace Server.Items
{
	public class InterlacedCowl : Item
	{
		public InterlacedCowl() : base()
		{
			Id = 8746;
			Resistance[0] = 33;
			SellPrice = 682;
			AvailableClasses = 0x7FFF;
			Model = 18416;
			ObjectClass = 4;
			SubClass = 1;
			Level = 33;
			ReqLevel = 28;
			Name = "Interlaced Cowl";
			Name2 = "Interlaced Cowl";
			AvailableRaces = 0x1FF;
			BuyPrice = 3411;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Crochet Hat)
*
***************************************************************/

namespace Server.Items
{
	public class CrochetHat : Item
	{
		public CrochetHat() : base()
		{
			Id = 8749;
			Resistance[0] = 41;
			SellPrice = 1603;
			AvailableClasses = 0x7FFF;
			Model = 18414;
			ObjectClass = 4;
			SubClass = 1;
			Level = 43;
			ReqLevel = 38;
			Name = "Crochet Hat";
			Name2 = "Crochet Hat";
			AvailableRaces = 0x1FF;
			BuyPrice = 8019;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Twill Cover)
*
***************************************************************/

namespace Server.Items
{
	public class TwillCover : Item
	{
		public TwillCover() : base()
		{
			Id = 8754;
			Resistance[0] = 53;
			SellPrice = 3937;
			AvailableClasses = 0x7FFF;
			Model = 18422;
			ObjectClass = 4;
			SubClass = 1;
			Level = 56;
			ReqLevel = 51;
			Name = "Twill Cover";
			Name2 = "Twill Cover";
			AvailableRaces = 0x1FF;
			BuyPrice = 19687;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Miner's Hat of the Deep)
*
***************************************************************/

namespace Server.Items
{
	public class MinersHatOfTheDeep : Item
	{
		public MinersHatOfTheDeep() : base()
		{
			Id = 9429;
			Resistance[0] = 52;
			Bonding = 2;
			SellPrice = 5236;
			AvailableClasses = 0x7FFF;
			Model = 18376;
			ObjectClass = 4;
			SubClass = 1;
			Level = 44;
			ReqLevel = 39;
			Name = "Miner's Hat of the Deep";
			Name2 = "Miner's Hat of the Deep";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 26184;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 50;
			IqBonus = 10;
			SpiritBonus = 17;
			StaminaBonus = 7;
			AgilityBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Papal Fez)
*
***************************************************************/

namespace Server.Items
{
	public class PapalFez : Item
	{
		public PapalFez() : base()
		{
			Id = 9431;
			Resistance[0] = 51;
			Bonding = 2;
			SellPrice = 4885;
			AvailableClasses = 0x7FFF;
			Model = 18334;
			ObjectClass = 4;
			SubClass = 1;
			Level = 43;
			ReqLevel = 38;
			Name = "Papal Fez";
			Name2 = "Papal Fez";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 24426;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 50;
			SetSpell( 9408 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 17;
			IqBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Bad Mojo Mask)
*
***************************************************************/

namespace Server.Items
{
	public class BadMojoMask : Item
	{
		public BadMojoMask() : base()
		{
			Id = 9470;
			Resistance[0] = 57;
			Bonding = 1;
			SellPrice = 7858;
			AvailableClasses = 0x7FFF;
			Model = 18689;
			ObjectClass = 4;
			SubClass = 1;
			Level = 49;
			ReqLevel = 44;
			Name = "Bad Mojo Mask";
			Name2 = "Bad Mojo Mask";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 39292;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 50;
			SetSpell( 9414 , 1 , 0 , 900000 , 0 , 180000 );
			SpiritBonus = 24;
		}
	}
}


/**************************************************************
*
*				(Electromagnetic Gigaflux Reactivator)
*
***************************************************************/

namespace Server.Items
{
	public class ElectromagneticGigafluxReactivator : Item
	{
		public ElectromagneticGigafluxReactivator() : base()
		{
			Id = 9492;
			Resistance[0] = 44;
			Bonding = 1;
			SellPrice = 3172;
			AvailableClasses = 0x7FFF;
			Model = 18415;
			ObjectClass = 4;
			SubClass = 1;
			Level = 37;
			ReqLevel = 32;
			Name = "Electromagnetic Gigaflux Reactivator";
			Name2 = "Electromagnetic Gigaflux Reactivator";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 15862;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 50;
			Flags = 64;
			SetSpell( 11826 , 0 , 0 , 1800000 , 24 , 60000 );
			IqBonus = 12;
			SpiritBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Speedy Racer Goggles)
*
***************************************************************/

namespace Server.Items
{
	public class SpeedyRacerGoggles : Item
	{
		public SpeedyRacerGoggles() : base()
		{
			Id = 9653;
			Resistance[0] = 53;
			Bonding = 1;
			SellPrice = 6745;
			AvailableClasses = 0x7FFF;
			Model = 18579;
			ObjectClass = 4;
			SubClass = 1;
			Level = 50;
			Name = "Speedy Racer Goggles";
			Name2 = "Speedy Racer Goggles";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 33727;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			AgilityBonus = 14;
			SpiritBonus = 14;
		}
	}
}


/**************************************************************
*
*				(Conjurer's Hood)
*
***************************************************************/

namespace Server.Items
{
	public class ConjurersHood : Item
	{
		public ConjurersHood() : base()
		{
			Id = 9849;
			Resistance[0] = 39;
			Bonding = 2;
			SellPrice = 2385;
			AvailableClasses = 0x7FFF;
			Model = 16638;
			ObjectClass = 4;
			SubClass = 1;
			Level = 36;
			ReqLevel = 31;
			Name = "Conjurer's Hood";
			Name2 = "Conjurer's Hood";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 630;
			BuyPrice = 11927;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Sorcerer Hat)
*
***************************************************************/

namespace Server.Items
{
	public class SorcererHat : Item
	{
		public SorcererHat() : base()
		{
			Id = 9878;
			Resistance[0] = 44;
			Bonding = 2;
			SellPrice = 3424;
			AvailableClasses = 0x7FFF;
			Model = 28067;
			ObjectClass = 4;
			SubClass = 1;
			Level = 41;
			ReqLevel = 36;
			Name = "Sorcerer Hat";
			Name2 = "Sorcerer Hat";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 632;
			BuyPrice = 17124;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Royal Headband)
*
***************************************************************/

namespace Server.Items
{
	public class RoyalHeadband : Item
	{
		public RoyalHeadband() : base()
		{
			Id = 9915;
			Resistance[0] = 48;
			Bonding = 2;
			SellPrice = 5091;
			AvailableClasses = 0x7FFF;
			Model = 28414;
			ObjectClass = 4;
			SubClass = 1;
			Level = 45;
			ReqLevel = 40;
			Name = "Royal Headband";
			Name2 = "Royal Headband";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 633;
			BuyPrice = 25456;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Abjurer's Hood)
*
***************************************************************/

namespace Server.Items
{
	public class AbjurersHood : Item
	{
		public AbjurersHood() : base()
		{
			Id = 9940;
			Resistance[0] = 53;
			Bonding = 2;
			SellPrice = 6954;
			AvailableClasses = 0x7FFF;
			Model = 27799;
			ObjectClass = 4;
			SubClass = 1;
			Level = 50;
			ReqLevel = 45;
			Name = "Abjurer's Hood";
			Name2 = "Abjurer's Hood";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 635;
			BuyPrice = 34772;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(White Bandit Mask)
*
***************************************************************/

namespace Server.Items
{
	public class WhiteBanditMask : Item
	{
		public WhiteBanditMask() : base()
		{
			Id = 10008;
			Resistance[0] = 46;
			Bonding = 2;
			SellPrice = 4365;
			AvailableClasses = 0x7FFF;
			Model = 18861;
			ObjectClass = 4;
			SubClass = 1;
			Level = 43;
			ReqLevel = 38;
			Name = "White Bandit Mask";
			Name2 = "White Bandit Mask";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 21826;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			AgilityBonus = 11;
			StrBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Black Mageweave Headband)
*
***************************************************************/

namespace Server.Items
{
	public class BlackMageweaveHeadband : Item
	{
		public BlackMageweaveHeadband() : base()
		{
			Id = 10024;
			Resistance[0] = 49;
			Bonding = 2;
			SellPrice = 5421;
			AvailableClasses = 0x7FFF;
			Model = 18860;
			ObjectClass = 4;
			SubClass = 1;
			Level = 46;
			ReqLevel = 41;
			Name = "Black Mageweave Headband";
			Name2 = "Black Mageweave Headband";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 27107;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			IqBonus = 13;
			SpiritBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Shadoweave Mask)
*
***************************************************************/

namespace Server.Items
{
	public class ShadoweaveMask : Item
	{
		public ShadoweaveMask() : base()
		{
			Id = 10025;
			Resistance[0] = 52;
			Bonding = 2;
			SellPrice = 6790;
			AvailableClasses = 0x7FFF;
			Model = 19060;
			ObjectClass = 4;
			SubClass = 1;
			Level = 49;
			ReqLevel = 44;
			Name = "Shadoweave Mask";
			Name2 = "Shadoweave Mask";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 33952;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			SetSpell( 14794 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Admiral's Hat)
*
***************************************************************/

namespace Server.Items
{
	public class AdmiralsHat : Item
	{
		public AdmiralsHat() : base()
		{
			Id = 10030;
			Resistance[0] = 51;
			Bonding = 2;
			SellPrice = 6007;
			AvailableClasses = 0x7FFF;
			Model = 18872;
			ObjectClass = 4;
			SubClass = 1;
			Level = 48;
			ReqLevel = 43;
			Name = "Admiral's Hat";
			Name2 = "Admiral's Hat";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 30037;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			SetSpell( 12022 , 0 , 0 , 900000 , 102 , 600000 );
		}
	}
}


/**************************************************************
*
*				(Red Mageweave Headband)
*
***************************************************************/

namespace Server.Items
{
	public class RedMageweaveHeadband : Item
	{
		public RedMageweaveHeadband() : base()
		{
			Id = 10033;
			Resistance[0] = 51;
			Bonding = 2;
			SellPrice = 6075;
			AvailableClasses = 0x7FFF;
			Model = 18879;
			ObjectClass = 4;
			SubClass = 1;
			Level = 48;
			ReqLevel = 43;
			Name = "Red Mageweave Headband";
			Name2 = "Red Mageweave Headband";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 30377;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			SpiritBonus = 20;
		}
	}
}


/**************************************************************
*
*				(Dreamweave Circlet)
*
***************************************************************/

namespace Server.Items
{
	public class DreamweaveCirclet : Item
	{
		public DreamweaveCirclet() : base()
		{
			Id = 10041;
			Resistance[0] = 53;
			Bonding = 2;
			SellPrice = 7161;
			AvailableClasses = 0x7FFF;
			Model = 19000;
			ObjectClass = 4;
			SubClass = 1;
			Level = 50;
			ReqLevel = 45;
			Name = "Dreamweave Circlet";
			Name2 = "Dreamweave Circlet";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 35806;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			SetSpell( 9344 , 1 , 0 , -1 , 0 , -1 );
			IqBonus = 12;
			SpiritBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Duskwoven Turban)
*
***************************************************************/

namespace Server.Items
{
	public class DuskwovenTurban : Item
	{
		public DuskwovenTurban() : base()
		{
			Id = 10061;
			Resistance[0] = 54;
			Bonding = 2;
			SellPrice = 7661;
			AvailableClasses = 0x7FFF;
			Model = 28131;
			ObjectClass = 4;
			SubClass = 1;
			Level = 51;
			ReqLevel = 46;
			Name = "Duskwoven Turban";
			Name2 = "Duskwoven Turban";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 635;
			BuyPrice = 38309;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Councillor's Circlet)
*
***************************************************************/

namespace Server.Items
{
	public class CouncillorsCirclet : Item
	{
		public CouncillorsCirclet() : base()
		{
			Id = 10097;
			Resistance[0] = 60;
			Bonding = 2;
			SellPrice = 10991;
			AvailableClasses = 0x7FFF;
			Model = 27606;
			ObjectClass = 4;
			SubClass = 1;
			Level = 57;
			ReqLevel = 52;
			Name = "Councillor's Circlet";
			Name2 = "Councillor's Circlet";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 637;
			BuyPrice = 54959;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(High Councillor's Circlet)
*
***************************************************************/

namespace Server.Items
{
	public class HighCouncillorsCirclet : Item
	{
		public HighCouncillorsCirclet() : base()
		{
			Id = 10139;
			Resistance[0] = 65;
			Bonding = 2;
			SellPrice = 14258;
			AvailableClasses = 0x7FFF;
			Model = 28852;
			ObjectClass = 4;
			SubClass = 1;
			Level = 62;
			ReqLevel = 57;
			Name = "High Councillor's Circlet";
			Name2 = "High Councillor's Circlet";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 639;
			BuyPrice = 71291;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Mystical Headwrap)
*
***************************************************************/

namespace Server.Items
{
	public class MysticalHeadwrap : Item
	{
		public MysticalHeadwrap() : base()
		{
			Id = 10175;
			Resistance[0] = 58;
			Bonding = 2;
			SellPrice = 9010;
			AvailableClasses = 0x7FFF;
			Model = 28853;
			ObjectClass = 4;
			SubClass = 1;
			Level = 55;
			ReqLevel = 50;
			Name = "Mystical Headwrap";
			Name2 = "Mystical Headwrap";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 637;
			BuyPrice = 45054;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Elegant Circlet)
*
***************************************************************/

namespace Server.Items
{
	public class ElegantCirclet : Item
	{
		public ElegantCirclet() : base()
		{
			Id = 10219;
			Resistance[0] = 63;
			Bonding = 2;
			SellPrice = 12011;
			AvailableClasses = 0x7FFF;
			Model = 28851;
			ObjectClass = 4;
			SubClass = 1;
			Level = 60;
			ReqLevel = 55;
			Name = "Elegant Circlet";
			Name2 = "Elegant Circlet";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 638;
			BuyPrice = 60056;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Master's Hat)
*
***************************************************************/

namespace Server.Items
{
	public class MastersHat : Item
	{
		public MastersHat() : base()
		{
			Id = 10250;
			Resistance[0] = 66;
			Bonding = 2;
			SellPrice = 14866;
			AvailableClasses = 0x7FFF;
			Model = 27824;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Master's Hat";
			Name2 = "Master's Hat";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 639;
			BuyPrice = 74331;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Sage's Circlet)
*
***************************************************************/

namespace Server.Items
{
	public class SagesCirclet : Item
	{
		public SagesCirclet() : base()
		{
			Id = 10288;
			Resistance[0] = 36;
			Bonding = 2;
			SellPrice = 1410;
			AvailableClasses = 0x7FFF;
			Model = 18976;
			ObjectClass = 4;
			SubClass = 1;
			Level = 31;
			ReqLevel = 26;
			Name = "Sage's Circlet";
			Name2 = "Sage's Circlet";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 629;
			BuyPrice = 7052;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Durable Hat)
*
***************************************************************/

namespace Server.Items
{
	public class DurableHat : Item
	{
		public DurableHat() : base()
		{
			Id = 10289;
			Resistance[0] = 36;
			Bonding = 2;
			SellPrice = 1557;
			AvailableClasses = 0x7FFF;
			Model = 27862;
			ObjectClass = 4;
			SubClass = 1;
			Level = 32;
			ReqLevel = 27;
			Name = "Durable Hat";
			Name2 = "Durable Hat";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 629;
			BuyPrice = 7787;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Bright-Eye Goggles)
*
***************************************************************/

namespace Server.Items
{
	public class BrightEyeGoggles : Item
	{
		public BrightEyeGoggles() : base()
		{
			Id = 10499;
			Resistance[0] = 38;
			Bonding = 2;
			SellPrice = 2105;
			AvailableClasses = 0x7FFF;
			Model = 19397;
			ObjectClass = 4;
			SubClass = 1;
			Level = 35;
			Name = "Bright-Eye Goggles";
			Name2 = "Bright-Eye Goggles";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 175;
			Skill = 202;
			BuyPrice = 10526;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			IqBonus = 9;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Fire Goggles)
*
***************************************************************/

namespace Server.Items
{
	public class FireGoggles : Item
	{
		public FireGoggles() : base()
		{
			Id = 10500;
			Resistance[0] = 44;
			Bonding = 2;
			SellPrice = 3478;
			AvailableClasses = 0x7FFF;
			Model = 19399;
			Resistance[2] = 17;
			ObjectClass = 4;
			SubClass = 1;
			Level = 41;
			Name = "Fire Goggles";
			Name2 = "Fire Goggles";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 205;
			Skill = 202;
			BuyPrice = 17394;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Catseye Ultra Goggles)
*
***************************************************************/

namespace Server.Items
{
	public class CatseyeUltraGoggles : Item
	{
		public CatseyeUltraGoggles() : base()
		{
			Id = 10501;
			Resistance[0] = 47;
			Bonding = 2;
			SellPrice = 4398;
			AvailableClasses = 0x7FFF;
			Model = 19402;
			ObjectClass = 4;
			SubClass = 1;
			Level = 44;
			Name = "Catseye Ultra Goggles";
			Name2 = "Catseye Ultra Goggles";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 220;
			Skill = 202;
			BuyPrice = 21993;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			SetSpell( 12418 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Spellpower Goggles Xtreme)
*
***************************************************************/

namespace Server.Items
{
	public class SpellpowerGogglesXtreme : Item
	{
		public SpellpowerGogglesXtreme() : base()
		{
			Id = 10502;
			Resistance[0] = 46;
			Bonding = 2;
			SellPrice = 4088;
			AvailableClasses = 0x7FFF;
			Model = 19409;
			ObjectClass = 4;
			SubClass = 1;
			Level = 43;
			Name = "Spellpower Goggles Xtreme";
			Name2 = "Spellpower Goggles Xtreme";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 215;
			Skill = 202;
			BuyPrice = 20441;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			SetSpell( 14248 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Rose Colored Goggles)
*
***************************************************************/

namespace Server.Items
{
	public class RoseColoredGoggles : Item
	{
		public RoseColoredGoggles() : base()
		{
			Id = 10503;
			Resistance[0] = 49;
			Bonding = 2;
			SellPrice = 5169;
			AvailableClasses = 0x7FFF;
			Model = 22423;
			ObjectClass = 4;
			SubClass = 1;
			Level = 46;
			Name = "Rose Colored Goggles";
			Name2 = "Rose Colored Goggles";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 230;
			Skill = 202;
			BuyPrice = 25847;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			IqBonus = 13;
			SpiritBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Green Lens)
*
***************************************************************/

namespace Server.Items
{
	public class GreenLens : Item
	{
		public GreenLens() : base()
		{
			Id = 10504;
			Resistance[0] = 57;
			Bonding = 2;
			SellPrice = 7770;
			AvailableClasses = 0x7FFF;
			Model = 19563;
			ObjectClass = 4;
			SubClass = 1;
			Level = 49;
			Name = "Green Lens";
			Name2 = "Green Lens";
			Quality = 3;
			AvailableRaces = 0x1FF;
			Extra = 8652;
			SkillRank = 245;
			Skill = 202;
			BuyPrice = 38852;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 50;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Deepdive Helmet)
*
***************************************************************/

namespace Server.Items
{
	public class DeepdiveHelmet : Item
	{
		public DeepdiveHelmet() : base()
		{
			Id = 10506;
			Resistance[0] = 49;
			Bonding = 2;
			SellPrice = 5227;
			AvailableClasses = 0x7FFF;
			Model = 23161;
			ObjectClass = 4;
			SubClass = 1;
			Level = 46;
			Name = "Deepdive Helmet";
			Name2 = "Deepdive Helmet";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 230;
			Skill = 202;
			BuyPrice = 26136;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			SetSpell( 11789 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Goblin Construction Helmet)
*
***************************************************************/

namespace Server.Items
{
	public class GoblinConstructionHelmet : Item
	{
		public GoblinConstructionHelmet() : base()
		{
			Id = 10543;
			Resistance[0] = 44;
			Bonding = 1;
			SellPrice = 3517;
			AvailableClasses = 0x7FFF;
			Model = 20814;
			Resistance[2] = 15;
			ObjectClass = 4;
			SubClass = 1;
			Level = 41;
			Name = "Goblin Construction Helmet";
			Name2 = "Goblin Construction Helmet";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 205;
			Skill = 202;
			BuyPrice = 17585;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			SetSpell( 12561 , 0 , 0 , 3600000 , 28 , 60000 );
		}
	}
}


/**************************************************************
*
*				(Gnomish Goggles)
*
***************************************************************/

namespace Server.Items
{
	public class GnomishGoggles : Item
	{
		public GnomishGoggles() : base()
		{
			Id = 10545;
			Resistance[0] = 45;
			Bonding = 1;
			SellPrice = 3929;
			AvailableClasses = 0x7FFF;
			Model = 22420;
			ObjectClass = 4;
			SubClass = 1;
			Level = 42;
			Name = "Gnomish Goggles";
			Name2 = "Gnomish Goggles";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 210;
			Skill = 202;
			BuyPrice = 19646;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			AgilityBonus = 9;
			StaminaBonus = 9;
			IqBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Corpseshroud)
*
***************************************************************/

namespace Server.Items
{
	public class Corpseshroud : Item
	{
		public Corpseshroud() : base()
		{
			Id = 10574;
			Resistance[0] = 47;
			Bonding = 2;
			SellPrice = 3775;
			AvailableClasses = 0x7FFF;
			Model = 19903;
			ObjectClass = 4;
			SubClass = 1;
			Level = 40;
			ReqLevel = 35;
			Name = "Corpseshroud";
			Name2 = "Corpseshroud";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 18878;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 50;
			IqBonus = 6;
			SpiritBonus = 19;
			AgilityBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Goblin Rocket Helmet)
*
***************************************************************/

namespace Server.Items
{
	public class GoblinRocketHelmet : Item
	{
		public GoblinRocketHelmet() : base()
		{
			Id = 10588;
			Resistance[0] = 50;
			Bonding = 2;
			SellPrice = 5834;
			AvailableClasses = 0x7FFF;
			Model = 23166;
			ObjectClass = 4;
			SubClass = 1;
			Level = 47;
			Name = "Goblin Rocket Helmet";
			Name2 = "Goblin Rocket Helmet";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 235;
			Skill = 202;
			BuyPrice = 29171;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			SetSpell( 22641 , 0 , 0 , 1200000 , 29 , 180000 );
			StaminaBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Soulcatcher Halo)
*
***************************************************************/

namespace Server.Items
{
	public class SoulcatcherHalo : Item
	{
		public SoulcatcherHalo() : base()
		{
			Id = 10630;
			Resistance[0] = 59;
			Bonding = 2;
			SellPrice = 8664;
			AvailableClasses = 0x7FFF;
			Model = 22928;
			ObjectClass = 4;
			SubClass = 1;
			Level = 51;
			ReqLevel = 46;
			Name = "Soulcatcher Halo";
			Name2 = "Soulcatcher Halo";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 43320;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 50;
			SpiritBonus = 25;
			IqBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Gnomish Mind Control Cap)
*
***************************************************************/

namespace Server.Items
{
	public class GnomishMindControlCap : Item
	{
		public GnomishMindControlCap() : base()
		{
			Id = 10726;
			Resistance[0] = 50;
			Bonding = 2;
			SellPrice = 5520;
			AvailableClasses = 0x7FFF;
			Model = 19667;
			ObjectClass = 4;
			SubClass = 1;
			Level = 47;
			Name = "Gnomish Mind Control Cap";
			Name2 = "Gnomish Mind Control Cap";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 215;
			Skill = 202;
			BuyPrice = 27603;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			SetSpell( 13180 , 0 , 0 , 1800000 , 28 , 300000 );
			IqBonus = 14;
		}
	}
}


/**************************************************************
*
*				(Gemburst Circlet)
*
***************************************************************/

namespace Server.Items
{
	public class GemburstCirclet : Item
	{
		public GemburstCirclet() : base()
		{
			Id = 10751;
			Resistance[0] = 63;
			Bonding = 1;
			SellPrice = 10634;
			AvailableClasses = 0x7FFF;
			Model = 19920;
			ObjectClass = 4;
			SubClass = 1;
			Level = 54;
			Name = "Gemburst Circlet";
			Name2 = "Gemburst Circlet";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 53170;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 50;
			AgilityBonus = 5;
			SpiritBonus = 17;
			IqBonus = 18;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Hakkar'i Shroud)
*
***************************************************************/

namespace Server.Items
{
	public class HakkariShroud : Item
	{
		public HakkariShroud() : base()
		{
			Id = 10782;
			Resistance[0] = 58;
			Bonding = 1;
			SellPrice = 4538;
			AvailableClasses = 0x7FFF;
			Model = 19930;
			ObjectClass = 4;
			SubClass = 1;
			Level = 55;
			Name = "Hakkar'i Shroud";
			Name2 = "Hakkar'i Shroud";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 22694;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			StaminaBonus = 16;
			SpiritBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Circle of Flame)
*
***************************************************************/

namespace Server.Items
{
	public class CircleOfFlame : Item
	{
		public CircleOfFlame() : base()
		{
			Id = 11808;
			Resistance[0] = 74;
			Bonding = 1;
			SellPrice = 19292;
			AvailableClasses = 0x7FFF;
			Model = 28268;
			Resistance[2] = 15;
			ObjectClass = 4;
			SubClass = 1;
			Level = 59;
			ReqLevel = 54;
			Name = "Circle of Flame";
			Name2 = "Circle of Flame";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 96460;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 60;
			SetSpell( 17447 , 0 , 0 , 300000 , 12 , 180000 );
			IqBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Chief Architect's Monocle)
*
***************************************************************/

namespace Server.Items
{
	public class ChiefArchitectsMonocle : Item
	{
		public ChiefArchitectsMonocle() : base()
		{
			Id = 11839;
			Resistance[0] = 64;
			Bonding = 1;
			SellPrice = 11191;
			AvailableClasses = 0x7FFF;
			Model = 21839;
			ObjectClass = 4;
			SubClass = 1;
			Level = 55;
			ReqLevel = 50;
			Name = "Chief Architect's Monocle";
			Name2 = "Chief Architect's Monocle";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 55958;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 50;
			SpiritBonus = 27;
			IqBonus = 3;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Gamemaster Hood)
*
***************************************************************/

namespace Server.Items
{
	public class GamemasterHood : Item
	{
		public GamemasterHood() : base()
		{
			Id = 12064;
			Resistance[0] = 2;
			Bonding = 1;
			SellPrice = 1;
			AvailableClasses = 0x7FFF;
			Model = 22036;
			ObjectClass = 4;
			SubClass = 1;
			Level = 1;
			Name = "Gamemaster Hood";
			Name2 = "Gamemaster Hood";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 4;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Bloodsail Admiral's Hat)
*
***************************************************************/

namespace Server.Items
{
	public class BloodsailAdmiralsHat : Item
	{
		public BloodsailAdmiralsHat() : base()
		{
			Id = 12185;
			Resistance[0] = 63;
			Bonding = 1;
			SellPrice = 12895;
			AvailableClasses = 0x7FFF;
			Model = 22184;
			ObjectClass = 4;
			SubClass = 1;
			Level = 60;
			Name = "Bloodsail Admiral's Hat";
			Name2 = "Bloodsail Admiral's Hat";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 64477;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			SetSpell( 17567 , 0 , 0 , -1 , 0 , -1 );
			StaminaBonus = 25;
		}
	}
}


/**************************************************************
*
*				(Starfire Tiara)
*
***************************************************************/

namespace Server.Items
{
	public class StarfireTiara : Item
	{
		public StarfireTiara() : base()
		{
			Id = 12604;
			Resistance[0] = 69;
			Bonding = 1;
			SellPrice = 14368;
			AvailableClasses = 0x7FFF;
			Model = 22833;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 1;
			Level = 60;
			ReqLevel = 55;
			Name = "Starfire Tiara";
			Name2 = "Starfire Tiara";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 71844;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 50;
			IqBonus = 10;
			SpiritBonus = 28;
		}
	}
}


/**************************************************************
*
*				(Cap of the Scarlet Savant)
*
***************************************************************/

namespace Server.Items
{
	public class CapOfTheScarletSavant : Item
	{
		public CapOfTheScarletSavant() : base()
		{
			Id = 12752;
			Resistance[0] = 78;
			Bonding = 1;
			SellPrice = 22907;
			AvailableClasses = 0x5D0;
			Model = 23197;
			ObjectClass = 4;
			SubClass = 1;
			Level = 62;
			Name = "Cap of the Scarlet Savant";
			Name2 = "Cap of the Scarlet Savant";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 114539;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 60;
			SetSpell( 18382 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 20;
			StaminaBonus = 17;
		}
	}
}


/**************************************************************
*
*				(Cassandra's Grace)
*
***************************************************************/

namespace Server.Items
{
	public class CassandrasGrace : Item
	{
		public CassandrasGrace() : base()
		{
			Id = 13102;
			Resistance[0] = 55;
			Bonding = 2;
			SellPrice = 6879;
			AvailableClasses = 0x7FFF;
			Model = 28974;
			ObjectClass = 4;
			SubClass = 1;
			Level = 47;
			ReqLevel = 42;
			Name = "Cassandra's Grace";
			Name2 = "Cassandra's Grace";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 34399;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 50;
			SetSpell( 17371 , 1 , 0 , -1 , 0 , -1 );
			IqBonus = 9;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Crown of the Penitent)
*
***************************************************************/

namespace Server.Items
{
	public class CrownOfThePenitent : Item
	{
		public CrownOfThePenitent() : base()
		{
			Id = 13216;
			Resistance[0] = 64;
			Bonding = 1;
			SellPrice = 13250;
			AvailableClasses = 0x7FFF;
			Model = 23777;
			ObjectClass = 4;
			SubClass = 1;
			Level = 61;
			Name = "Crown of the Penitent";
			Name2 = "Crown of the Penitent";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 66252;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			SetSpell( 21626 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 20;
		}
	}
}


/**************************************************************
*
*				(The Postmaster's Band)
*
***************************************************************/

namespace Server.Items
{
	public class ThePostmastersBand : Item
	{
		public ThePostmastersBand() : base()
		{
			Id = 13390;
			Resistance[0] = 70;
			Bonding = 1;
			SellPrice = 16367;
			AvailableClasses = 0x7FFF;
			Model = 24292;
			ObjectClass = 4;
			SubClass = 1;
			Level = 61;
			ReqLevel = 56;
			Name = "The Postmaster's Band";
			Name2 = "The Postmaster's Band";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 81837;
			Sets = 81;
			Resistance[5] = 10;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 50;
			SpiritBonus = 30;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Runecloth Headband)
*
***************************************************************/

namespace Server.Items
{
	public class RuneclothHeadband : Item
	{
		public RuneclothHeadband() : base()
		{
			Id = 13866;
			Resistance[0] = 62;
			Bonding = 2;
			SellPrice = 11358;
			AvailableClasses = 0x7FFF;
			Model = 25230;
			ObjectClass = 4;
			SubClass = 1;
			Level = 59;
			ReqLevel = 54;
			Name = "Runecloth Headband";
			Name2 = "Runecloth Headband";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 56794;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			SpiritBonus = 20;
			IqBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Dreadmaster's Shroud)
*
***************************************************************/

namespace Server.Items
{
	public class DreadmastersShroud : Item
	{
		public DreadmastersShroud() : base()
		{
			Id = 13936;
			Resistance[0] = 120;
			Bonding = 1;
			SellPrice = 17248;
			AvailableClasses = 0x7FFF;
			Model = 25403;
			ObjectClass = 4;
			SubClass = 1;
			Level = 62;
			ReqLevel = 57;
			Name = "Dreadmaster's Shroud";
			Name2 = "Dreadmaster's Shroud";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 86241;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			SetSpell( 14047 , 1 , 0 , -1 , 0 , -1 );
			IqBonus = 13;
			SpiritBonus = 20;
		}
	}
}


/**************************************************************
*
*				(Crown of Caer Darrow)
*
***************************************************************/

namespace Server.Items
{
	public class CrownOfCaerDarrow : Item
	{
		public CrownOfCaerDarrow() : base()
		{
			Id = 13986;
			Resistance[0] = 73;
			Bonding = 1;
			SellPrice = 17469;
			AvailableClasses = 0x7FFF;
			Model = 26680;
			Resistance[4] = 15;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			Name = "Crown of Caer Darrow";
			Name2 = "Crown of Caer Darrow";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 87349;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 50;
			SpiritBonus = 20;
			IqBonus = 20;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Felcloth Hood)
*
***************************************************************/

namespace Server.Items
{
	public class FelclothHood : Item
	{
		public FelclothHood() : base()
		{
			Id = 14111;
			Resistance[0] = 61;
			Bonding = 2;
			SellPrice = 10775;
			AvailableClasses = 0x7FFF;
			Model = 24933;
			ObjectClass = 4;
			SubClass = 1;
			Level = 58;
			ReqLevel = 53;
			Name = "Felcloth Hood";
			Name2 = "Felcloth Hood";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 53875;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			SetSpell( 18011 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Wizardweave Turban)
*
***************************************************************/

namespace Server.Items
{
	public class WizardweaveTurban : Item
	{
		public WizardweaveTurban() : base()
		{
			Id = 14130;
			Resistance[6] = 18;
			Resistance[0] = 64;
			Bonding = 2;
			SellPrice = 12768;
			AvailableClasses = 0x7FFF;
			Model = 24942;
			Resistance[2] = 18;
			ObjectClass = 4;
			SubClass = 1;
			Level = 61;
			ReqLevel = 56;
			Name = "Wizardweave Turban";
			Name2 = "Wizardweave Turban";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 63843;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Mooncloth Circlet)
*
***************************************************************/

namespace Server.Items
{
	public class MoonclothCirclet : Item
	{
		public MoonclothCirclet() : base()
		{
			Id = 14140;
			Resistance[0] = 71;
			Bonding = 2;
			SellPrice = 16693;
			AvailableClasses = 0x7FFF;
			Model = 28414;
			ObjectClass = 4;
			SubClass = 1;
			Level = 62;
			ReqLevel = 57;
			Name = "Mooncloth Circlet";
			Name2 = "Mooncloth Circlet";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 83469;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 50;
			SpiritBonus = 23;
			IqBonus = 15;
			StaminaBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Watcher's Cap)
*
***************************************************************/

namespace Server.Items
{
	public class WatchersCap : Item
	{
		public WatchersCap() : base()
		{
			Id = 14178;
			Resistance[0] = 36;
			Bonding = 2;
			SellPrice = 1532;
			AvailableClasses = 0x7FFF;
			Model = 26302;
			ObjectClass = 4;
			SubClass = 1;
			Level = 31;
			ReqLevel = 26;
			Name = "Watcher's Cap";
			Name2 = "Watcher's Cap";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 629;
			BuyPrice = 7661;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Raincaller Cap)
*
***************************************************************/

namespace Server.Items
{
	public class RaincallerCap : Item
	{
		public RaincallerCap() : base()
		{
			Id = 14189;
			Resistance[0] = 36;
			Bonding = 2;
			SellPrice = 1588;
			AvailableClasses = 0x7FFF;
			Model = 15283;
			ObjectClass = 4;
			SubClass = 1;
			Level = 32;
			ReqLevel = 27;
			Name = "Raincaller Cap";
			Name2 = "Raincaller Cap";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 629;
			BuyPrice = 7940;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Thistlefur Cap)
*
***************************************************************/

namespace Server.Items
{
	public class ThistlefurCap : Item
	{
		public ThistlefurCap() : base()
		{
			Id = 14200;
			Resistance[0] = 38;
			Bonding = 2;
			SellPrice = 2258;
			AvailableClasses = 0x7FFF;
			Model = 15293;
			ObjectClass = 4;
			SubClass = 1;
			Level = 35;
			ReqLevel = 30;
			Name = "Thistlefur Cap";
			Name2 = "Thistlefur Cap";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 630;
			BuyPrice = 11294;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Vital Headband)
*
***************************************************************/

namespace Server.Items
{
	public class VitalHeadband : Item
	{
		public VitalHeadband() : base()
		{
			Id = 14208;
			Resistance[0] = 39;
			Bonding = 2;
			SellPrice = 2316;
			AvailableClasses = 0x7FFF;
			Model = 26308;
			ObjectClass = 4;
			SubClass = 1;
			Level = 36;
			ReqLevel = 31;
			Name = "Vital Headband";
			Name2 = "Vital Headband";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 630;
			BuyPrice = 11580;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Geomancer's Cap)
*
***************************************************************/

namespace Server.Items
{
	public class GeomancersCap : Item
	{
		public GeomancersCap() : base()
		{
			Id = 14220;
			Resistance[0] = 43;
			Bonding = 2;
			SellPrice = 3442;
			AvailableClasses = 0x7FFF;
			Model = 26044;
			ObjectClass = 4;
			SubClass = 1;
			Level = 40;
			ReqLevel = 35;
			Name = "Geomancer's Cap";
			Name2 = "Geomancer's Cap";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 632;
			BuyPrice = 17214;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Embersilk Coronet)
*
***************************************************************/

namespace Server.Items
{
	public class EmbersilkCoronet : Item
	{
		public EmbersilkCoronet() : base()
		{
			Id = 14228;
			Resistance[0] = 44;
			Bonding = 2;
			SellPrice = 3559;
			AvailableClasses = 0x7FFF;
			Model = 26059;
			ObjectClass = 4;
			SubClass = 1;
			Level = 41;
			ReqLevel = 36;
			Name = "Embersilk Coronet";
			Name2 = "Embersilk Coronet";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 632;
			BuyPrice = 17799;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Darkmist Wizard Hat)
*
***************************************************************/

namespace Server.Items
{
	public class DarkmistWizardHat : Item
	{
		public DarkmistWizardHat() : base()
		{
			Id = 14246;
			Resistance[0] = 47;
			Bonding = 2;
			SellPrice = 4451;
			AvailableClasses = 0x7FFF;
			Model = 26309;
			ObjectClass = 4;
			SubClass = 1;
			Level = 44;
			ReqLevel = 39;
			Name = "Darkmist Wizard Hat";
			Name2 = "Darkmist Wizard Hat";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 633;
			BuyPrice = 22256;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Lunar Coronet)
*
***************************************************************/

namespace Server.Items
{
	public class LunarCoronet : Item
	{
		public LunarCoronet() : base()
		{
			Id = 14252;
			Resistance[0] = 48;
			Bonding = 2;
			SellPrice = 4914;
			AvailableClasses = 0x7FFF;
			Model = 18992;
			ObjectClass = 4;
			SubClass = 1;
			Level = 45;
			ReqLevel = 40;
			Name = "Lunar Coronet";
			Name2 = "Lunar Coronet";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 633;
			BuyPrice = 24571;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Bloodwoven Mask)
*
***************************************************************/

namespace Server.Items
{
	public class BloodwovenMask : Item
	{
		public BloodwovenMask() : base()
		{
			Id = 14263;
			Resistance[0] = 51;
			Bonding = 2;
			SellPrice = 5987;
			AvailableClasses = 0x7FFF;
			Model = 15308;
			ObjectClass = 4;
			SubClass = 1;
			Level = 48;
			ReqLevel = 43;
			Name = "Bloodwoven Mask";
			Name2 = "Bloodwoven Mask";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 634;
			BuyPrice = 29936;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Gaea's Circlet)
*
***************************************************************/

namespace Server.Items
{
	public class GaeasCirclet : Item
	{
		public GaeasCirclet() : base()
		{
			Id = 14271;
			Resistance[0] = 52;
			Bonding = 2;
			SellPrice = 6599;
			AvailableClasses = 0x7FFF;
			Model = 26307;
			ObjectClass = 4;
			SubClass = 1;
			Level = 49;
			ReqLevel = 44;
			Name = "Gaea's Circlet";
			Name2 = "Gaea's Circlet";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 635;
			BuyPrice = 32995;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Opulent Crown)
*
***************************************************************/

namespace Server.Items
{
	public class OpulentCrown : Item
	{
		public OpulentCrown() : base()
		{
			Id = 14281;
			Resistance[0] = 56;
			Bonding = 2;
			SellPrice = 8178;
			AvailableClasses = 0x7FFF;
			Model = 26128;
			ObjectClass = 4;
			SubClass = 1;
			Level = 53;
			ReqLevel = 48;
			Name = "Opulent Crown";
			Name2 = "Opulent Crown";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 636;
			BuyPrice = 40890;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Arachnidian Circlet)
*
***************************************************************/

namespace Server.Items
{
	public class ArachnidianCirclet : Item
	{
		public ArachnidianCirclet() : base()
		{
			Id = 14293;
			Resistance[0] = 58;
			Bonding = 2;
			SellPrice = 9857;
			AvailableClasses = 0x7FFF;
			Model = 26214;
			ObjectClass = 4;
			SubClass = 1;
			Level = 55;
			ReqLevel = 50;
			Name = "Arachnidian Circlet";
			Name2 = "Arachnidian Circlet";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 637;
			BuyPrice = 49287;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Bonecaster's Crown)
*
***************************************************************/

namespace Server.Items
{
	public class BonecastersCrown : Item
	{
		public BonecastersCrown() : base()
		{
			Id = 14307;
			Resistance[0] = 62;
			Bonding = 2;
			SellPrice = 12064;
			AvailableClasses = 0x7FFF;
			Model = 26277;
			ObjectClass = 4;
			SubClass = 1;
			Level = 59;
			ReqLevel = 54;
			Name = "Bonecaster's Crown";
			Name2 = "Bonecaster's Crown";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 638;
			BuyPrice = 60323;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Celestial Crown)
*
***************************************************************/

namespace Server.Items
{
	public class CelestialCrown : Item
	{
		public CelestialCrown() : base()
		{
			Id = 14312;
			Resistance[0] = 64;
			Bonding = 2;
			SellPrice = 13541;
			AvailableClasses = 0x7FFF;
			Model = 26255;
			ObjectClass = 4;
			SubClass = 1;
			Level = 61;
			ReqLevel = 56;
			Name = "Celestial Crown";
			Name2 = "Celestial Crown";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 639;
			BuyPrice = 67708;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Resplendent Circlet)
*
***************************************************************/

namespace Server.Items
{
	public class ResplendentCirclet : Item
	{
		public ResplendentCirclet() : base()
		{
			Id = 14322;
			Resistance[0] = 65;
			Bonding = 2;
			SellPrice = 13712;
			AvailableClasses = 0x7FFF;
			Model = 26292;
			ObjectClass = 4;
			SubClass = 1;
			Level = 62;
			ReqLevel = 57;
			Name = "Resplendent Circlet";
			Name2 = "Resplendent Circlet";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 639;
			BuyPrice = 68563;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Eternal Crown)
*
***************************************************************/

namespace Server.Items
{
	public class EternalCrown : Item
	{
		public EternalCrown() : base()
		{
			Id = 14332;
			Resistance[0] = 67;
			Bonding = 2;
			SellPrice = 15674;
			AvailableClasses = 0x7FFF;
			Model = 26224;
			ObjectClass = 4;
			SubClass = 1;
			Level = 64;
			ReqLevel = 59;
			Name = "Eternal Crown";
			Name2 = "Eternal Crown";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 640;
			BuyPrice = 78373;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Resilient Cap)
*
***************************************************************/

namespace Server.Items
{
	public class ResilientCap : Item
	{
		public ResilientCap() : base()
		{
			Id = 14401;
			Resistance[0] = 37;
			Bonding = 2;
			SellPrice = 1786;
			AvailableClasses = 0x7FFF;
			Model = 25996;
			ObjectClass = 4;
			SubClass = 1;
			Level = 33;
			ReqLevel = 28;
			Name = "Resilient Cap";
			Name2 = "Resilient Cap";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 8933;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			SpiritBonus = 11;
			IqBonus = 4;
			AgilityBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Stonecloth Circlet)
*
***************************************************************/

namespace Server.Items
{
	public class StoneclothCirclet : Item
	{
		public StoneclothCirclet() : base()
		{
			Id = 14410;
			Resistance[0] = 41;
			Bonding = 2;
			SellPrice = 2709;
			AvailableClasses = 0x7FFF;
			Model = 26033;
			ObjectClass = 4;
			SubClass = 1;
			Level = 38;
			ReqLevel = 33;
			Name = "Stonecloth Circlet";
			Name2 = "Stonecloth Circlet";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 13549;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			SpiritBonus = 10;
			StrBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Silksand Circlet)
*
***************************************************************/

namespace Server.Items
{
	public class SilksandCirclet : Item
	{
		public SilksandCirclet() : base()
		{
			Id = 14421;
			Resistance[0] = 45;
			Bonding = 2;
			SellPrice = 3945;
			AvailableClasses = 0x7FFF;
			Model = 26093;
			ObjectClass = 4;
			SubClass = 1;
			Level = 42;
			ReqLevel = 37;
			Name = "Silksand Circlet";
			Name2 = "Silksand Circlet";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 19725;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			StaminaBonus = 6;
			SpiritBonus = 9;
			IqBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Windchaser Coronet)
*
***************************************************************/

namespace Server.Items
{
	public class WindchaserCoronet : Item
	{
		public WindchaserCoronet() : base()
		{
			Id = 14436;
			Resistance[0] = 49;
			Bonding = 2;
			SellPrice = 5270;
			AvailableClasses = 0x7FFF;
			Model = 26150;
			ObjectClass = 4;
			SubClass = 1;
			Level = 46;
			ReqLevel = 41;
			Name = "Windchaser Coronet";
			Name2 = "Windchaser Coronet";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 26351;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			AgilityBonus = 4;
			SpiritBonus = 15;
			IqBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Venomshroud Mask)
*
***************************************************************/

namespace Server.Items
{
	public class VenomshroudMask : Item
	{
		public VenomshroudMask() : base()
		{
			Id = 14441;
			Resistance[0] = 53;
			Bonding = 2;
			SellPrice = 7166;
			AvailableClasses = 0x7FFF;
			Model = 26305;
			ObjectClass = 4;
			SubClass = 1;
			Level = 50;
			ReqLevel = 45;
			Name = "Venomshroud Mask";
			Name2 = "Venomshroud Mask";
			Resistance[3] = 4;
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 35834;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			SpiritBonus = 16;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Highborne Crown)
*
***************************************************************/

namespace Server.Items
{
	public class HighborneCrown : Item
	{
		public HighborneCrown() : base()
		{
			Id = 14449;
			Resistance[0] = 60;
			Bonding = 2;
			SellPrice = 10125;
			AvailableClasses = 0x7FFF;
			Model = 26170;
			ObjectClass = 4;
			SubClass = 1;
			Level = 57;
			ReqLevel = 52;
			Name = "Highborne Crown";
			Name2 = "Highborne Crown";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 50628;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			SpiritBonus = 22;
			IqBonus = 6;
			StrBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Elunarian Diadem)
*
***************************************************************/

namespace Server.Items
{
	public class ElunarianDiadem : Item
	{
		public ElunarianDiadem() : base()
		{
			Id = 14460;
			Resistance[0] = 66;
			Bonding = 2;
			SellPrice = 14661;
			AvailableClasses = 0x7FFF;
			Model = 26243;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Elunarian Diadem";
			Name2 = "Elunarian Diadem";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 73309;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			SpiritBonus = 20;
			StaminaBonus = 16;
		}
	}
}


/**************************************************************
*
*				(Spellpower Goggles Xtreme Plus)
*
***************************************************************/

namespace Server.Items
{
	public class SpellpowerGogglesXtremePlus : Item
	{
		public SpellpowerGogglesXtremePlus() : base()
		{
			Id = 15999;
			Resistance[0] = 57;
			Bonding = 2;
			SellPrice = 9002;
			AvailableClasses = 0x7FFF;
			Model = 26614;
			ObjectClass = 4;
			SubClass = 1;
			Level = 54;
			Name = "Spellpower Goggles Xtreme Plus";
			Name2 = "Spellpower Goggles Xtreme Plus";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 270;
			Skill = 202;
			BuyPrice = 45014;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			SetSpell( 14054 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Master Engineer's Goggles)
*
***************************************************************/

namespace Server.Items
{
	public class MasterEngineersGoggles : Item
	{
		public MasterEngineersGoggles() : base()
		{
			Id = 16008;
			Resistance[0] = 61;
			Bonding = 2;
			SellPrice = 11739;
			AvailableClasses = 0x7FFF;
			Model = 26621;
			ObjectClass = 4;
			SubClass = 1;
			Level = 58;
			Name = "Master Engineer's Goggles";
			Name2 = "Master Engineer's Goggles";
			Quality = 2;
			AvailableRaces = 0x1FF;
			SkillRank = 280;
			Skill = 202;
			BuyPrice = 58696;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 45;
			IqBonus = 17;
			StaminaBonus = 16;
		}
	}
}


/**************************************************************
*
*				(Lieutenant Commander's Crown)
*
***************************************************************/

namespace Server.Items
{
	public class LieutenantCommandersCrown : Item
	{
		public LieutenantCommandersCrown() : base()
		{
			Id = 16416;
			Resistance[0] = 73;
			Bonding = 1;
			SellPrice = 8864;
			AvailableClasses = 0x80;
			Model = 27232;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Lieutenant Commander's Crown";
			Name2 = "Lieutenant Commander's Crown";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 44322;
			Sets = 343;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 50;
			Flags = 32768;
			SetSpell( 18384 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 16;
			SpiritBonus = 16;
			IqBonus = 16;
		}
	}
}


/**************************************************************
*
*				(Field Marshal's Coronet)
*
***************************************************************/

namespace Server.Items
{
	public class FieldMarshalsCoronet : Item
	{
		public FieldMarshalsCoronet() : base()
		{
			Id = 16441;
			Resistance[0] = 81;
			Bonding = 1;
			SellPrice = 13263;
			AvailableClasses = 0x80;
			Model = 30341;
			ObjectClass = 4;
			SubClass = 1;
			Level = 65;
			ReqLevel = 60;
			Name = "Field Marshal's Coronet";
			Name2 = "Field Marshal's Coronet";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 66316;
			Sets = 388;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 60;
			Flags = 32768;
			SetSpell( 18384 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 24;
			SpiritBonus = 24;
			IqBonus = 19;
		}
	}
}


/**************************************************************
*
*				(Champion's Silk Hood)
*
***************************************************************/

namespace Server.Items
{
	public class ChampionsSilkHood : Item
	{
		public ChampionsSilkHood() : base()
		{
			Id = 16489;
			Resistance[0] = 73;
			Bonding = 1;
			SellPrice = 8638;
			AvailableClasses = 0x80;
			Model = 31099;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Champion's Silk Hood";
			Name2 = "Champion's Silk Hood";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 43191;
			Sets = 341;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 50;
			Flags = 32768;
			SetSpell( 18384 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 16;
			SpiritBonus = 16;
			IqBonus = 16;
		}
	}
}


/**************************************************************
*
*				(Warlord's Silk Cowl)
*
***************************************************************/

namespace Server.Items
{
	public class WarlordsSilkCowl : Item
	{
		public WarlordsSilkCowl() : base()
		{
			Id = 16533;
			Resistance[0] = 81;
			Bonding = 1;
			SellPrice = 13217;
			AvailableClasses = 0x80;
			Model = 30352;
			ObjectClass = 4;
			SubClass = 1;
			Level = 65;
			ReqLevel = 60;
			Name = "Warlord's Silk Cowl";
			Name2 = "Warlord's Silk Cowl";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 66087;
			Sets = 387;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 60;
			Flags = 32768;
			SetSpell( 18384 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 24;
			SpiritBonus = 24;
			IqBonus = 19;
		}
	}
}


/**************************************************************
*
*				(Magister's Crown)
*
***************************************************************/

namespace Server.Items
{
	public class MagistersCrown : Item
	{
		public MagistersCrown() : base()
		{
			Id = 16686;
			Resistance[0] = 71;
			Bonding = 1;
			SellPrice = 15912;
			AvailableClasses = 0x7FFF;
			Model = 31087;
			ObjectClass = 4;
			SubClass = 1;
			Level = 62;
			ReqLevel = 57;
			Name = "Magister's Crown";
			Name2 = "Magister's Crown";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 79562;
			Sets = 181;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 50;
			SpiritBonus = 30;
			IqBonus = 5;
			StaminaBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Devout Crown)
*
***************************************************************/

namespace Server.Items
{
	public class DevoutCrown : Item
	{
		public DevoutCrown() : base()
		{
			Id = 16693;
			Resistance[0] = 71;
			Bonding = 1;
			SellPrice = 16335;
			AvailableClasses = 0x7FFF;
			Model = 31104;
			ObjectClass = 4;
			SubClass = 1;
			Level = 62;
			ReqLevel = 57;
			Name = "Devout Crown";
			Name2 = "Devout Crown";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 81676;
			Sets = 182;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 50;
			SpiritBonus = 24;
			IqBonus = 15;
			StaminaBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Dreadmist Mask)
*
***************************************************************/

namespace Server.Items
{
	public class DreadmistMask : Item
	{
		public DreadmistMask() : base()
		{
			Id = 16698;
			Resistance[0] = 71;
			Bonding = 1;
			SellPrice = 16636;
			AvailableClasses = 0x7FFF;
			Model = 31263;
			ObjectClass = 4;
			SubClass = 1;
			Level = 62;
			ReqLevel = 57;
			Name = "Dreadmist Mask";
			Name2 = "Dreadmist Mask";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 83182;
			Sets = 183;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 50;
			SpiritBonus = 23;
			StaminaBonus = 15;
			IqBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Arcanist Crown)
*
***************************************************************/

namespace Server.Items
{
	public class ArcanistCrown : Item
	{
		public ArcanistCrown() : base()
		{
			Id = 16795;
			Resistance[0] = 83;
			Bonding = 1;
			SellPrice = 27359;
			AvailableClasses = 0x80;
			Model = 31517;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 1;
			Level = 66;
			ReqLevel = 60;
			Name = "Arcanist Crown";
			Name2 = "Arcanist Crown";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 136797;
			Sets = 201;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 60;
			SetSpell( 9344 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 35;
			IqBonus = 8;
			StaminaBonus = 14;
		}
	}
}


/**************************************************************
*
*				(Felheart Horns)
*
***************************************************************/

namespace Server.Items
{
	public class FelheartHorns : Item
	{
		public FelheartHorns() : base()
		{
			Id = 16808;
			Resistance[0] = 83;
			Bonding = 1;
			SellPrice = 26668;
			AvailableClasses = 0x100;
			Model = 31987;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 1;
			Level = 66;
			ReqLevel = 60;
			Name = "Felheart Horns";
			Name2 = "Felheart Horns";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 133344;
			Sets = 203;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 60;
			SetSpell( 21595 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 9414 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 20;
			IqBonus = 12;
			StaminaBonus = 27;
		}
	}
}


/**************************************************************
*
*				(Circlet of Prophecy)
*
***************************************************************/

namespace Server.Items
{
	public class CircletOfProphecy : Item
	{
		public CircletOfProphecy() : base()
		{
			Id = 16813;
			Resistance[0] = 83;
			Bonding = 1;
			SellPrice = 27866;
			AvailableClasses = 0x10;
			Model = 31371;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 1;
			Level = 66;
			ReqLevel = 60;
			Name = "Circlet of Prophecy";
			Name2 = "Circlet of Prophecy";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 139330;
			Sets = 202;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 60;
			SetSpell( 9417 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 27;
			IqBonus = 20;
			StaminaBonus = 17;
		}
	}
}


/**************************************************************
*
*				(Netherwind Crown)
*
***************************************************************/

namespace Server.Items
{
	public class NetherwindCrown : Item
	{
		public NetherwindCrown() : base()
		{
			Id = 16914;
			Resistance[0] = 94;
			Bonding = 1;
			SellPrice = 42324;
			AvailableClasses = 0x80;
			Model = 29873;
			Resistance[4] = 10;
			ObjectClass = 4;
			SubClass = 1;
			Level = 76;
			ReqLevel = 60;
			Name = "Netherwind Crown";
			Name2 = "Netherwind Crown";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 211623;
			Sets = 210;
			Resistance[5] = 10;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 60;
			SetSpell( 18049 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 32;
			IqBonus = 12;
			StaminaBonus = 14;
		}
	}
}


/**************************************************************
*
*				(Halo of Transcendence)
*
***************************************************************/

namespace Server.Items
{
	public class HaloOfTranscendence : Item
	{
		public HaloOfTranscendence() : base()
		{
			Id = 16921;
			Resistance[0] = 94;
			Bonding = 1;
			SellPrice = 43440;
			AvailableClasses = 0x10;
			Model = 29780;
			Resistance[2] = 10;
			Resistance[4] = 10;
			ObjectClass = 4;
			SubClass = 1;
			Level = 76;
			ReqLevel = 60;
			Name = "Halo of Transcendence";
			Name2 = "Halo of Transcendence";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 217204;
			Sets = 211;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 60;
			SetSpell( 18034 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 27;
			IqBonus = 22;
			StaminaBonus = 17;
		}
	}
}


/**************************************************************
*
*				(Nemesis Skullcap)
*
***************************************************************/

namespace Server.Items
{
	public class NemesisSkullcap : Item
	{
		public NemesisSkullcap() : base()
		{
			Id = 16929;
			Resistance[0] = 94;
			Bonding = 1;
			SellPrice = 41521;
			AvailableClasses = 0x100;
			Model = 29862;
			Resistance[4] = 10;
			ObjectClass = 4;
			SubClass = 1;
			Level = 76;
			ReqLevel = 60;
			Name = "Nemesis Skullcap";
			Name2 = "Nemesis Skullcap";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 207606;
			Sets = 212;
			Resistance[5] = 10;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 60;
			SetSpell( 21599 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 14799 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 18;
			IqBonus = 13;
			StaminaBonus = 27;
		}
	}
}


/**************************************************************
*
*				(Lieutenant Commander's Headguard)
*
***************************************************************/

namespace Server.Items
{
	public class LieutenantCommandersHeadguard : Item
	{
		public LieutenantCommandersHeadguard() : base()
		{
			Id = 17566;
			Resistance[0] = 73;
			Bonding = 1;
			SellPrice = 8863;
			AvailableClasses = 0x100;
			Model = 30341;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Lieutenant Commander's Headguard";
			Name2 = "Lieutenant Commander's Headguard";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 44318;
			Sets = 346;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 50;
			Flags = 32768;
			SetSpell( 9345 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 20;
			SpiritBonus = 20;
		}
	}
}


/**************************************************************
*
*				(Champion's Dreadweave Hood)
*
***************************************************************/

namespace Server.Items
{
	public class ChampionsDreadweaveHood : Item
	{
		public ChampionsDreadweaveHood() : base()
		{
			Id = 17570;
			Resistance[0] = 73;
			Bonding = 1;
			SellPrice = 8354;
			AvailableClasses = 0x100;
			Model = 27258;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Champion's Dreadweave Hood";
			Name2 = "Champion's Dreadweave Hood";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 41774;
			Sets = 345;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 50;
			Flags = 32768;
			SetSpell( 9345 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 20;
			SpiritBonus = 20;
		}
	}
}


/**************************************************************
*
*				(Field Marshal's Coronal)
*
***************************************************************/

namespace Server.Items
{
	public class FieldMarshalsCoronal : Item
	{
		public FieldMarshalsCoronal() : base()
		{
			Id = 17578;
			Resistance[0] = 81;
			Bonding = 1;
			SellPrice = 12655;
			AvailableClasses = 0x100;
			Model = 30341;
			ObjectClass = 4;
			SubClass = 1;
			Level = 65;
			ReqLevel = 60;
			Name = "Field Marshal's Coronal";
			Name2 = "Field Marshal's Coronal";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 63275;
			Sets = 392;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 60;
			Flags = 32768;
			SetSpell( 14799 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 28;
			SpiritBonus = 24;
		}
	}
}


/**************************************************************
*
*				(Warlord's Dreadweave Hood)
*
***************************************************************/

namespace Server.Items
{
	public class WarlordsDreadweaveHood : Item
	{
		public WarlordsDreadweaveHood() : base()
		{
			Id = 17591;
			Resistance[0] = 81;
			Bonding = 1;
			SellPrice = 12326;
			AvailableClasses = 0x100;
			Model = 30352;
			ObjectClass = 4;
			SubClass = 1;
			Level = 65;
			ReqLevel = 60;
			Name = "Warlord's Dreadweave Hood";
			Name2 = "Warlord's Dreadweave Hood";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 61631;
			Sets = 391;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 60;
			Flags = 32768;
			SetSpell( 14799 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 28;
			SpiritBonus = 24;
		}
	}
}


/**************************************************************
*
*				(Lieutenant Commander's Diadem)
*
***************************************************************/

namespace Server.Items
{
	public class LieutenantCommandersDiadem : Item
	{
		public LieutenantCommandersDiadem() : base()
		{
			Id = 17598;
			Resistance[0] = 73;
			Bonding = 1;
			SellPrice = 8607;
			AvailableClasses = 0x10;
			Model = 31065;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Lieutenant Commander's Diadem";
			Name2 = "Lieutenant Commander's Diadem";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 43035;
			Sets = 344;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 50;
			Flags = 32768;
			SetSpell( 9345 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 20;
			SpiritBonus = 20;
		}
	}
}


/**************************************************************
*
*				(Field Marshal's Headdress)
*
***************************************************************/

namespace Server.Items
{
	public class FieldMarshalsHeaddress : Item
	{
		public FieldMarshalsHeaddress() : base()
		{
			Id = 17602;
			Resistance[0] = 81;
			Bonding = 1;
			SellPrice = 13175;
			AvailableClasses = 0x10;
			Model = 30341;
			ObjectClass = 4;
			SubClass = 1;
			Level = 65;
			ReqLevel = 60;
			Name = "Field Marshal's Headdress";
			Name2 = "Field Marshal's Headdress";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 65878;
			Sets = 389;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 60;
			Flags = 32768;
			SetSpell( 14799 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 28;
			SpiritBonus = 24;
		}
	}
}


/**************************************************************
*
*				(Champion's Satin Cowl)
*
***************************************************************/

namespace Server.Items
{
	public class ChampionsSatinCowl : Item
	{
		public ChampionsSatinCowl() : base()
		{
			Id = 17610;
			Resistance[0] = 73;
			Bonding = 1;
			SellPrice = 8352;
			AvailableClasses = 0x10;
			Model = 31030;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Champion's Satin Cowl";
			Name2 = "Champion's Satin Cowl";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 41761;
			Sets = 342;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 50;
			Flags = 32768;
			SetSpell( 9345 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 20;
			SpiritBonus = 20;
		}
	}
}


/**************************************************************
*
*				(Warlord's Satin Cowl)
*
***************************************************************/

namespace Server.Items
{
	public class WarlordsSatinCowl : Item
	{
		public WarlordsSatinCowl() : base()
		{
			Id = 17623;
			Resistance[0] = 81;
			Bonding = 1;
			SellPrice = 13221;
			AvailableClasses = 0x10;
			Model = 30352;
			ObjectClass = 4;
			SubClass = 1;
			Level = 65;
			ReqLevel = 60;
			Name = "Warlord's Satin Cowl";
			Name2 = "Warlord's Satin Cowl";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 66106;
			Sets = 390;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			MaxCount = 1;
			Material = 7;
			Durability = 60;
			Flags = 32768;
			SetSpell( 14799 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 28;
			SpiritBonus = 24;
		}
	}
}


/**************************************************************
*
*				(Eye of Theradras)
*
***************************************************************/

namespace Server.Items
{
	public class EyeOfTheradras : Item
	{
		public EyeOfTheradras() : base()
		{
			Id = 17715;
			Resistance[0] = 63;
			Bonding = 1;
			SellPrice = 10225;
			AvailableClasses = 0x7FFF;
			Model = 29894;
			ObjectClass = 4;
			SubClass = 1;
			Level = 54;
			ReqLevel = 49;
			Name = "Eye of Theradras";
			Name2 = "Eye of Theradras";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 51128;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 50;
			SpiritBonus = 20;
			StaminaBonus = 13;
			IqBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Crown of the Ogre King)
*
***************************************************************/

namespace Server.Items
{
	public class CrownOfTheOgreKing : Item
	{
		public CrownOfTheOgreKing() : base()
		{
			Id = 18526;
			Resistance[0] = 73;
			Bonding = 1;
			SellPrice = 17924;
			AvailableClasses = 0x7FFF;
			Model = 30860;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Crown of the Ogre King";
			Name2 = "Crown of the Ogre King";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 89621;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 3;
			Durability = 50;
			SetSpell( 18384 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 18;
			IqBonus = 11;
			StaminaBonus = 16;
		}
	}
}


/**************************************************************
*
*				(Crimson Felt Hat)
*
***************************************************************/

namespace Server.Items
{
	public class CrimsonFeltHat : Item
	{
		public CrimsonFeltHat() : base()
		{
			Id = 18727;
			Resistance[0] = 68;
			Bonding = 1;
			SellPrice = 14487;
			AvailableClasses = 0x7FFF;
			Model = 31177;
			ObjectClass = 4;
			SubClass = 1;
			Level = 59;
			ReqLevel = 54;
			Name = "Crimson Felt Hat";
			Name2 = "Crimson Felt Hat";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 72438;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 50;
			SetSpell( 14798 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 8;
			IqBonus = 8;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Frost Runed Headdress)
*
***************************************************************/

namespace Server.Items
{
	public class FrostRunedHeaddress : Item
	{
		public FrostRunedHeaddress() : base()
		{
			Id = 19105;
			Resistance[0] = 73;
			Bonding = 1;
			SellPrice = 16476;
			AvailableClasses = 0x7FFF;
			Model = 24818;
			ObjectClass = 4;
			SubClass = 1;
			Level = 63;
			ReqLevel = 58;
			Name = "Frost Runed Headdress";
			Name2 = "Frost Runed Headdress";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 82383;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 7;
			Durability = 50;
			SetSpell( 17901 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 10;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Crystal Adorned Crown)
*
***************************************************************/

namespace Server.Items
{
	public class CrystalAdornedCrown : Item
	{
		public CrystalAdornedCrown() : base()
		{
			Id = 19132;
			Resistance[0] = 85;
			Bonding = 1;
			SellPrice = 28438;
			AvailableClasses = 0x7FFF;
			Model = 31650;
			ObjectClass = 4;
			SubClass = 1;
			Level = 68;
			ReqLevel = 60;
			Name = "Crystal Adorned Crown";
			Name2 = "Crystal Adorned Crown";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 142191;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 3;
			Durability = 60;
			SetSpell( 23593 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 14;
			IqBonus = 13;
		}
	}
}


