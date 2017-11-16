/**************************************************************
*
*		Made by fulgas (fulgas@gmail.com)
*
*  WowwoW Item Designer ( 2005/8/23 - 10:11:18 )
*
***************************************************************/

using System;
using System.Collections;

/***************************************************************/

/**************************************************************
*
*				(Heavy Mithril Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyMithrilBreastplate : Item
	{
		public HeavyMithrilBreastplate() : base()
		{
			Id = 7930;
			Resistance[0] = 536;
			Bonding = 2;
			SellPrice = 7045;
			AvailableClasses = 0x7FFF;
			Model = 16109;
			ObjectClass = 4;
			SubClass = 4;
			Level = 46;
			ReqLevel = 41;
			Name = "Heavy Mithril Breastplate";
			Name2 = "Heavy Mithril Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 35228;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 115;
			StaminaBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Ornate Mithril Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class OrnateMithrilBreastplate : Item
	{
		public OrnateMithrilBreastplate() : base()
		{
			Id = 7935;
			Resistance[0] = 463;
			Bonding = 2;
			SellPrice = 8368;
			AvailableClasses = 0x7FFF;
			Model = 16117;
			ObjectClass = 4;
			SubClass = 4;
			Level = 48;
			ReqLevel = 43;
			Name = "Ornate Mithril Breastplate";
			Name2 = "Ornate Mithril Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 41842;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 115;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 13669 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Truesilver Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class TruesilverBreastplate : Item
	{
		public TruesilverBreastplate() : base()
		{
			Id = 7939;
			Resistance[0] = 519;
			Bonding = 2;
			SellPrice = 10899;
			AvailableClasses = 0x7FFF;
			Model = 24393;
			ObjectClass = 4;
			SubClass = 4;
			Level = 49;
			ReqLevel = 44;
			Name = "Truesilver Breastplate";
			Name2 = "Truesilver Breastplate";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 54496;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 135;
			SetSpell( 9778 , 1 , 0 , 10000 , 0 , -1 );
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Light Plate Chestpiece)
*
***************************************************************/

namespace Server.Items
{
	public class LightPlateChestpiece : Item
	{
		public LightPlateChestpiece() : base()
		{
			Id = 8080;
			Resistance[0] = 497;
			SellPrice = 5987;
			AvailableClasses = 0x7FFF;
			Model = 28398;
			ObjectClass = 4;
			SubClass = 4;
			Level = 58;
			ReqLevel = 53;
			Name = "Light Plate Chestpiece";
			Name2 = "Light Plate Chestpiece";
			AvailableRaces = 0x1FF;
			BuyPrice = 29936;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 115;
		}
	}
}


/**************************************************************
*
*				(Platemail Armor)
*
***************************************************************/

namespace Server.Items
{
	public class PlatemailArmor : Item
	{
		public PlatemailArmor() : base()
		{
			Id = 8094;
			Resistance[0] = 456;
			SellPrice = 5458;
			AvailableClasses = 0x7FFF;
			Model = 28394;
			ObjectClass = 4;
			SubClass = 4;
			Level = 50;
			ReqLevel = 45;
			Name = "Platemail Armor";
			Name2 = "Platemail Armor";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 27290;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 115;
		}
	}
}


/**************************************************************
*
*				(Chromite Chestplate)
*
***************************************************************/

namespace Server.Items
{
	public class ChromiteChestplate : Item
	{
		public ChromiteChestplate() : base()
		{
			Id = 8138;
			Resistance[0] = 454;
			Bonding = 2;
			SellPrice = 7666;
			AvailableClasses = 0x7FFF;
			Model = 27330;
			ObjectClass = 4;
			SubClass = 4;
			Level = 47;
			ReqLevel = 42;
			Name = "Chromite Chestplate";
			Name2 = "Chromite Chestplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 38330;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 115;
			StrBonus = 11;
			StaminaBonus = 11;
			IqBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Jouster's Chestplate)
*
***************************************************************/

namespace Server.Items
{
	public class JoustersChestplate : Item
	{
		public JoustersChestplate() : base()
		{
			Id = 8157;
			Resistance[0] = 339;
			Bonding = 2;
			SellPrice = 5197;
			AvailableClasses = 0x7FFF;
			Model = 27340;
			ObjectClass = 4;
			SubClass = 4;
			Level = 42;
			ReqLevel = 40;
			Name = "Jouster's Chestplate";
			Name2 = "Jouster's Chestplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 25989;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 115;
			StrBonus = 15;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Valorous Chestguard)
*
***************************************************************/

namespace Server.Items
{
	public class ValorousChestguard : Item
	{
		public ValorousChestguard() : base()
		{
			Id = 8274;
			Resistance[0] = 489;
			Bonding = 2;
			SellPrice = 10251;
			AvailableClasses = 0x7FFF;
			Model = 27372;
			ObjectClass = 4;
			SubClass = 4;
			Level = 51;
			ReqLevel = 46;
			Name = "Valorous Chestguard";
			Name2 = "Valorous Chestguard";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 51259;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 115;
			StrBonus = 20;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Alabaster Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class AlabasterBreastplate : Item
	{
		public AlabasterBreastplate() : base()
		{
			Id = 8312;
			Resistance[0] = 543;
			Bonding = 2;
			SellPrice = 14810;
			AvailableClasses = 0x7FFF;
			Model = 27389;
			ObjectClass = 4;
			SubClass = 4;
			Level = 57;
			ReqLevel = 52;
			Name = "Alabaster Breastplate";
			Name2 = "Alabaster Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 74053;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 115;
			StrBonus = 17;
			StaminaBonus = 3;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Field Plate Armor)
*
***************************************************************/

namespace Server.Items
{
	public class FieldPlateArmor : Item
	{
		public FieldPlateArmor() : base()
		{
			Id = 9286;
			Resistance[0] = 428;
			Bonding = 2;
			SellPrice = 6040;
			AvailableClasses = 0x7FFF;
			Model = 27356;
			ObjectClass = 4;
			SubClass = 4;
			Level = 44;
			ReqLevel = 40;
			Name = "Field Plate Armor";
			Name2 = "Field Plate Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 528;
			BuyPrice = 30203;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 115;
		}
	}
}


/**************************************************************
*
*				(Embossed Plate Armor)
*
***************************************************************/

namespace Server.Items
{
	public class EmbossedPlateArmor : Item
	{
		public EmbossedPlateArmor() : base()
		{
			Id = 9966;
			Resistance[0] = 437;
			Bonding = 2;
			SellPrice = 6743;
			AvailableClasses = 0x7FFF;
			Model = 27348;
			ObjectClass = 4;
			SubClass = 4;
			Level = 45;
			ReqLevel = 40;
			Name = "Embossed Plate Armor";
			Name2 = "Embossed Plate Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 528;
			BuyPrice = 33715;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 115;
		}
	}
}


/**************************************************************
*
*				(Gothic Plate Armor)
*
***************************************************************/

namespace Server.Items
{
	public class GothicPlateArmor : Item
	{
		public GothicPlateArmor() : base()
		{
			Id = 10086;
			Resistance[0] = 471;
			Bonding = 2;
			SellPrice = 8438;
			AvailableClasses = 0x7FFF;
			Model = 27363;
			ObjectClass = 4;
			SubClass = 4;
			Level = 49;
			ReqLevel = 44;
			Name = "Gothic Plate Armor";
			Name2 = "Gothic Plate Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 530;
			BuyPrice = 42194;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 115;
		}
	}
}


/**************************************************************
*
*				(Revenant Chestplate)
*
***************************************************************/

namespace Server.Items
{
	public class RevenantChestplate : Item
	{
		public RevenantChestplate() : base()
		{
			Id = 10128;
			Resistance[0] = 515;
			Bonding = 2;
			SellPrice = 11907;
			AvailableClasses = 0x7FFF;
			Model = 27427;
			ObjectClass = 4;
			SubClass = 4;
			Level = 54;
			ReqLevel = 49;
			Name = "Revenant Chestplate";
			Name2 = "Revenant Chestplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 531;
			BuyPrice = 59538;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 115;
		}
	}
}


/**************************************************************
*
*				(Templar Chestplate)
*
***************************************************************/

namespace Server.Items
{
	public class TemplarChestplate : Item
	{
		public TemplarChestplate() : base()
		{
			Id = 10164;
			Resistance[0] = 552;
			Bonding = 2;
			SellPrice = 14808;
			AvailableClasses = 0x7FFF;
			Model = 27407;
			ObjectClass = 4;
			SubClass = 4;
			Level = 58;
			ReqLevel = 53;
			Name = "Templar Chestplate";
			Name2 = "Templar Chestplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 533;
			BuyPrice = 74044;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 115;
		}
	}
}


/**************************************************************
*
*				(Overlord's Chestplate)
*
***************************************************************/

namespace Server.Items
{
	public class OverlordsChestplate : Item
	{
		public OverlordsChestplate() : base()
		{
			Id = 10203;
			Resistance[0] = 497;
			Bonding = 2;
			SellPrice = 10397;
			AvailableClasses = 0x7FFF;
			Model = 27397;
			ObjectClass = 4;
			SubClass = 4;
			Level = 52;
			ReqLevel = 47;
			Name = "Overlord's Chestplate";
			Name2 = "Overlord's Chestplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 531;
			BuyPrice = 51986;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 115;
		}
	}
}


/**************************************************************
*
*				(Heavy Lamellar Chestpiece)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyLamellarChestpiece : Item
	{
		public HeavyLamellarChestpiece() : base()
		{
			Id = 10240;
			Resistance[0] = 524;
			Bonding = 2;
			SellPrice = 12576;
			AvailableClasses = 0x7FFF;
			Model = 27384;
			ObjectClass = 4;
			SubClass = 4;
			Level = 55;
			ReqLevel = 50;
			Name = "Heavy Lamellar Chestpiece";
			Name2 = "Heavy Lamellar Chestpiece";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 532;
			BuyPrice = 62882;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 115;
		}
	}
}


/**************************************************************
*
*				(Emerald Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class EmeraldBreastplate : Item
	{
		public EmeraldBreastplate() : base()
		{
			Id = 10275;
			Resistance[0] = 570;
			Bonding = 2;
			SellPrice = 16204;
			AvailableClasses = 0x7FFF;
			Model = 27416;
			ObjectClass = 4;
			SubClass = 4;
			Level = 60;
			ReqLevel = 55;
			Name = "Emerald Breastplate";
			Name2 = "Emerald Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 533;
			BuyPrice = 81021;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 115;
		}
	}
}


/**************************************************************
*
*				(Imbued Plate Armor)
*
***************************************************************/

namespace Server.Items
{
	public class ImbuedPlateArmor : Item
	{
		public ImbuedPlateArmor() : base()
		{
			Id = 10368;
			Resistance[0] = 588;
			Bonding = 2;
			SellPrice = 17868;
			AvailableClasses = 0x7FFF;
			Model = 26351;
			ObjectClass = 4;
			SubClass = 4;
			Level = 62;
			ReqLevel = 57;
			Name = "Imbued Plate Armor";
			Name2 = "Imbued Plate Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 89343;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 115;
			StrBonus = 15;
			StaminaBonus = 14;
			IqBonus = 14;
		}
	}
}


/**************************************************************
*
*				(Commander's Armor)
*
***************************************************************/

namespace Server.Items
{
	public class CommandersArmor : Item
	{
		public CommandersArmor() : base()
		{
			Id = 10378;
			Resistance[0] = 597;
			Bonding = 2;
			SellPrice = 19466;
			AvailableClasses = 0x7FFF;
			Model = 26332;
			ObjectClass = 4;
			SubClass = 4;
			Level = 63;
			ReqLevel = 58;
			Name = "Commander's Armor";
			Name2 = "Commander's Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 534;
			BuyPrice = 97332;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 115;
		}
	}
}


/**************************************************************
*
*				(Hyperion Armor)
*
***************************************************************/

namespace Server.Items
{
	public class HyperionArmor : Item
	{
		public HyperionArmor() : base()
		{
			Id = 10384;
			Resistance[0] = 615;
			Bonding = 2;
			SellPrice = 20370;
			AvailableClasses = 0x7FFF;
			Model = 19844;
			ObjectClass = 4;
			SubClass = 4;
			Level = 65;
			ReqLevel = 60;
			Name = "Hyperion Armor";
			Name2 = "Hyperion Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 535;
			BuyPrice = 101850;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 115;
		}
	}
}


/**************************************************************
*
*				(Carapace of Tuten'kash)
*
***************************************************************/

namespace Server.Items
{
	public class CarapaceOfTutenkash : Item
	{
		public CarapaceOfTutenkash() : base()
		{
			Id = 10775;
			Resistance[0] = 373;
			Bonding = 1;
			SellPrice = 6377;
			AvailableClasses = 0x7FFF;
			Model = 28694;
			ObjectClass = 4;
			SubClass = 4;
			Level = 42;
			ReqLevel = 40;
			Name = "Carapace of Tuten'kash";
			Name2 = "Carapace of Tuten'kash";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 31888;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 135;
			StaminaBonus = 15;
			StrBonus = 10;
			AgilityBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Warrior's Embrace)
*
***************************************************************/

namespace Server.Items
{
	public class WarriorsEmbrace : Item
	{
		public WarriorsEmbrace() : base()
		{
			Id = 10845;
			Resistance[0] = 567;
			Bonding = 1;
			SellPrice = 14233;
			AvailableClasses = 0x7FFF;
			Model = 19893;
			ObjectClass = 4;
			SubClass = 4;
			Level = 54;
			ReqLevel = 49;
			Name = "Warrior's Embrace";
			Name2 = "Warrior's Embrace";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 71166;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 135;
			SetSpell( 13670 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 11;
			AgilityBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Warforged Chestplate)
*
***************************************************************/

namespace Server.Items
{
	public class WarforgedChestplate : Item
	{
		public WarforgedChestplate() : base()
		{
			Id = 11195;
			Resistance[0] = 543;
			Bonding = 1;
			SellPrice = 13655;
			AvailableClasses = 0x7FFF;
			Model = 28185;
			ObjectClass = 4;
			SubClass = 4;
			Level = 57;
			Name = "Warforged Chestplate";
			Name2 = "Warforged Chestplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 68278;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 115;
			StrBonus = 24;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Dark Iron Plate)
*
***************************************************************/

namespace Server.Items
{
	public class DarkIronPlate : Item
	{
		public DarkIronPlate() : base()
		{
			Id = 11604;
			Resistance[0] = 817;
			Bonding = 1;
			SellPrice = 19428;
			AvailableClasses = 0x7FFF;
			Model = 21580;
			Resistance[2] = 19;
			ObjectClass = 4;
			SubClass = 4;
			Level = 59;
			ReqLevel = 54;
			Name = "Dark Iron Plate";
			Name2 = "Dark Iron Plate";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 97143;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 135;
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Spiderfang Carapace)
*
***************************************************************/

namespace Server.Items
{
	public class SpiderfangCarapace : Item
	{
		public SpiderfangCarapace() : base()
		{
			Id = 11633;
			Resistance[0] = 515;
			Bonding = 1;
			SellPrice = 11730;
			AvailableClasses = 0x7FFF;
			Model = 21898;
			ObjectClass = 4;
			SubClass = 4;
			Level = 54;
			ReqLevel = 49;
			Name = "Spiderfang Carapace";
			Name2 = "Spiderfang Carapace";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 58650;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 115;
			StrBonus = 16;
			StaminaBonus = 14;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Carapace of Anub'shiah)
*
***************************************************************/

namespace Server.Items
{
	public class CarapaceOfAnubshiah : Item
	{
		public CarapaceOfAnubshiah() : base()
		{
			Id = 11678;
			Resistance[0] = 577;
			Bonding = 1;
			SellPrice = 15596;
			AvailableClasses = 0x7FFF;
			Model = 21578;
			ObjectClass = 4;
			SubClass = 4;
			Level = 55;
			ReqLevel = 50;
			Name = "Carapace of Anub'shiah";
			Name2 = "Carapace of Anub'shiah";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 77981;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 135;
			StaminaBonus = 22;
			StrBonus = 11;
			AgilityBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Boulderskin Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class BoulderskinBreastplate : Item
	{
		public BoulderskinBreastplate() : base()
		{
			Id = 12106;
			Resistance[0] = 770;
			Bonding = 1;
			SellPrice = 16824;
			AvailableClasses = 0x7FFF;
			Model = 28089;
			ObjectClass = 4;
			SubClass = 4;
			Level = 60;
			Name = "Boulderskin Breastplate";
			Name2 = "Boulderskin Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 84121;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 115;
			StrBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Thorium Armor)
*
***************************************************************/

namespace Server.Items
{
	public class ThoriumArmor : Item
	{
		public ThoriumArmor() : base()
		{
			Id = 12405;
			Resistance[6] = 8;
			Resistance[0] = 480;
			Bonding = 2;
			SellPrice = 9239;
			AvailableClasses = 0x7FFF;
			Model = 25751;
			Resistance[2] = 8;
			Resistance[4] = 8;
			ObjectClass = 4;
			SubClass = 4;
			Level = 50;
			ReqLevel = 45;
			Name = "Thorium Armor";
			Name2 = "Thorium Armor";
			Resistance[3] = 8;
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 46199;
			Resistance[5] = 8;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 115;
		}
	}
}


/**************************************************************
*
*				(Imperial Plate Chest)
*
***************************************************************/

namespace Server.Items
{
	public class ImperialPlateChest : Item
	{
		public ImperialPlateChest() : base()
		{
			Id = 12422;
			Resistance[0] = 570;
			Bonding = 2;
			SellPrice = 16204;
			AvailableClasses = 0x7FFF;
			Model = 25749;
			ObjectClass = 4;
			SubClass = 4;
			Level = 60;
			ReqLevel = 55;
			Name = "Imperial Plate Chest";
			Name2 = "Imperial Plate Chest";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 81021;
			Sets = 321;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 115;
			StrBonus = 18;
			StaminaBonus = 17;
		}
	}
}


/**************************************************************
*
*				(Runic Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class RunicBreastplate : Item
	{
		public RunicBreastplate() : base()
		{
			Id = 12613;
			Resistance[0] = 738;
			Bonding = 2;
			SellPrice = 18205;
			AvailableClasses = 0x7FFF;
			Model = 19730;
			Resistance[2] = 15;
			ObjectClass = 4;
			SubClass = 4;
			Level = 62;
			ReqLevel = 57;
			Name = "Runic Breastplate";
			Name2 = "Runic Breastplate";
			Resistance[3] = 15;
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 91025;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 115;
		}
	}
}


/**************************************************************
*
*				(Enchanted Thorium Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class EnchantedThoriumBreastplate : Item
	{
		public EnchantedThoriumBreastplate() : base()
		{
			Id = 12618;
			Resistance[0] = 657;
			Bonding = 2;
			SellPrice = 23972;
			AvailableClasses = 0x7FFF;
			Model = 25746;
			ObjectClass = 4;
			SubClass = 4;
			Level = 63;
			ReqLevel = 58;
			Name = "Enchanted Thorium Breastplate";
			Name2 = "Enchanted Thorium Breastplate";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 119863;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 135;
			SetSpell( 13388 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 26;
			StrBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Demon Forged Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class DemonForgedBreastplate : Item
	{
		public DemonForgedBreastplate() : base()
		{
			Id = 12628;
			Resistance[0] = 597;
			Bonding = 2;
			SellPrice = 16640;
			AvailableClasses = 0x7FFF;
			Model = 22892;
			ObjectClass = 4;
			SubClass = 4;
			Level = 57;
			ReqLevel = 52;
			Name = "Demon Forged Breastplate";
			Name2 = "Demon Forged Breastplate";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 83203;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 135;
			SetSpell( 16611 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Breastplate of the Chromatic Flight)
*
***************************************************************/

namespace Server.Items
{
	public class BreastplateOfTheChromaticFlight : Item
	{
		public BreastplateOfTheChromaticFlight() : base()
		{
			Id = 12895;
			Resistance[0] = 706;
			Bonding = 1;
			SellPrice = 29461;
			AvailableClasses = 0x7FFF;
			Model = 28335;
			Resistance[2] = 15;
			ObjectClass = 4;
			SubClass = 4;
			Level = 62;
			Name = "Breastplate of the Chromatic Flight";
			Name2 = "Breastplate of the Chromatic Flight";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 147308;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 165;
			StaminaBonus = 30;
			StrBonus = 20;
			AgilityBonus = 10;
		}
	}
}


/**************************************************************
*
*				(General's Ceremonial Plate)
*
***************************************************************/

namespace Server.Items
{
	public class GeneralsCeremonialPlate : Item
	{
		public GeneralsCeremonialPlate() : base()
		{
			Id = 12970;
			Resistance[0] = 654;
			Bonding = 1;
			SellPrice = 22768;
			AvailableClasses = 0x7FFF;
			Model = 23709;
			ObjectClass = 4;
			SubClass = 4;
			Level = 63;
			ReqLevel = 58;
			Name = "General's Ceremonial Plate";
			Name2 = "General's Ceremonial Plate";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 113840;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			SetSpell( 18190 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 30;
		}
	}
}


/**************************************************************
*
*				(Hydralick Armor)
*
***************************************************************/

namespace Server.Items
{
	public class HydralickArmor : Item
	{
		public HydralickArmor() : base()
		{
			Id = 13067;
			Resistance[0] = 567;
			Bonding = 2;
			SellPrice = 14341;
			AvailableClasses = 0x7FFF;
			Model = 28355;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 4;
			Level = 54;
			ReqLevel = 49;
			Name = "Hydralick Armor";
			Name2 = "Hydralick Armor";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 71709;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 135;
			StrBonus = 13;
			StaminaBonus = 20;
			AgilityBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Plate of the Shaman King)
*
***************************************************************/

namespace Server.Items
{
	public class PlateOfTheShamanKing : Item
	{
		public PlateOfTheShamanKing() : base()
		{
			Id = 13168;
			Resistance[0] = 627;
			Bonding = 1;
			SellPrice = 19085;
			AvailableClasses = 0x7FFF;
			Model = 23559;
			ObjectClass = 4;
			SubClass = 4;
			Level = 60;
			ReqLevel = 55;
			Name = "Plate of the Shaman King";
			Name2 = "Plate of the Shaman King";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 95425;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 135;
			StaminaBonus = 12;
			IqBonus = 29;
		}
	}
}


/**************************************************************
*
*				(Skul's Cold Embrace)
*
***************************************************************/

namespace Server.Items
{
	public class SkulsColdEmbrace : Item
	{
		public SkulsColdEmbrace() : base()
		{
			Id = 13394;
			Resistance[0] = 617;
			Bonding = 1;
			SellPrice = 18176;
			AvailableClasses = 0x7FFF;
			Model = 24102;
			Resistance[4] = 10;
			ObjectClass = 4;
			SubClass = 4;
			Level = 59;
			ReqLevel = 54;
			Name = "Skul's Cold Embrace";
			Name2 = "Skul's Cold Embrace";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 90880;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 135;
			StaminaBonus = 20;
			IqBonus = 9;
			StrBonus = 19;
		}
	}
}


/**************************************************************
*
*				(Deathbone Chestplate)
*
***************************************************************/

namespace Server.Items
{
	public class DeathboneChestplate : Item
	{
		public DeathboneChestplate() : base()
		{
			Id = 14624;
			Resistance[0] = 637;
			Bonding = 1;
			SellPrice = 20578;
			AvailableClasses = 0x7FFF;
			Model = 24102;
			ObjectClass = 4;
			SubClass = 4;
			Level = 61;
			ReqLevel = 56;
			Name = "Deathbone Chestplate";
			Name2 = "Deathbone Chestplate";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 102891;
			Sets = 124;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 135;
			SetSpell( 13389 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 12;
			IqBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Symbolic Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class SymbolicBreastplate : Item
	{
		public SymbolicBreastplate() : base()
		{
			Id = 14821;
			Resistance[0] = 382;
			Bonding = 2;
			SellPrice = 5290;
			AvailableClasses = 0x7FFF;
			Model = 26811;
			ObjectClass = 4;
			SubClass = 4;
			Level = 43;
			ReqLevel = 40;
			Name = "Symbolic Breastplate";
			Name2 = "Symbolic Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 26452;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 115;
			StrBonus = 14;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Tyrant's Chestpiece)
*
***************************************************************/

namespace Server.Items
{
	public class TyrantsChestpiece : Item
	{
		public TyrantsChestpiece() : base()
		{
			Id = 14835;
			Resistance[0] = 463;
			Bonding = 2;
			SellPrice = 8192;
			AvailableClasses = 0x7FFF;
			Model = 26687;
			ObjectClass = 4;
			SubClass = 4;
			Level = 48;
			ReqLevel = 43;
			Name = "Tyrant's Chestpiece";
			Name2 = "Tyrant's Chestpiece";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 40964;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 115;
			StrBonus = 16;
			StaminaBonus = 7;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Sunscale Chestguard)
*
***************************************************************/

namespace Server.Items
{
	public class SunscaleChestguard : Item
	{
		public SunscaleChestguard() : base()
		{
			Id = 14844;
			Resistance[0] = 515;
			Bonding = 2;
			SellPrice = 11471;
			AvailableClasses = 0x7FFF;
			Model = 26820;
			ObjectClass = 4;
			SubClass = 4;
			Level = 54;
			ReqLevel = 49;
			Name = "Sunscale Chestguard";
			Name2 = "Sunscale Chestguard";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 57358;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 115;
			StaminaBonus = 21;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Vanguard Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class VanguardBreastplate : Item
	{
		public VanguardBreastplate() : base()
		{
			Id = 14854;
			Resistance[0] = 561;
			Bonding = 2;
			SellPrice = 16204;
			AvailableClasses = 0x7FFF;
			Model = 26846;
			ObjectClass = 4;
			SubClass = 4;
			Level = 59;
			ReqLevel = 54;
			Name = "Vanguard Breastplate";
			Name2 = "Vanguard Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 81023;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 115;
			StaminaBonus = 22;
			IqBonus = 7;
			AgilityBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Warleader's Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class WarleadersBreastplate : Item
	{
		public WarleadersBreastplate() : base()
		{
			Id = 14862;
			Resistance[0] = 597;
			Bonding = 2;
			SellPrice = 18339;
			AvailableClasses = 0x7FFF;
			Model = 26880;
			ObjectClass = 4;
			SubClass = 4;
			Level = 63;
			ReqLevel = 58;
			Name = "Warleader's Breastplate";
			Name2 = "Warleader's Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 91699;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 115;
			StaminaBonus = 25;
			StrBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Saltstone Surcoat)
*
***************************************************************/

namespace Server.Items
{
	public class SaltstoneSurcoat : Item
	{
		public SaltstoneSurcoat() : base()
		{
			Id = 14895;
			Resistance[0] = 300;
			Bonding = 2;
			SellPrice = 4904;
			AvailableClasses = 0x7FFF;
			Model = 26654;
			ObjectClass = 4;
			SubClass = 4;
			Level = 41;
			ReqLevel = 40;
			Name = "Saltstone Surcoat";
			Name2 = "Saltstone Surcoat";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 527;
			BuyPrice = 24524;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 115;
		}
	}
}


/**************************************************************
*
*				(Brutish Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class BrutishBreastplate : Item
	{
		public BrutishBreastplate() : base()
		{
			Id = 14904;
			Resistance[0] = 480;
			Bonding = 2;
			SellPrice = 9245;
			AvailableClasses = 0x7FFF;
			Model = 27899;
			ObjectClass = 4;
			SubClass = 4;
			Level = 50;
			ReqLevel = 45;
			Name = "Brutish Breastplate";
			Name2 = "Brutish Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 530;
			BuyPrice = 46227;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 115;
		}
	}
}


/**************************************************************
*
*				(Jade Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class JadeBreastplate : Item
	{
		public JadeBreastplate() : base()
		{
			Id = 14915;
			Resistance[0] = 506;
			Bonding = 2;
			SellPrice = 11569;
			AvailableClasses = 0x7FFF;
			Model = 26795;
			ObjectClass = 4;
			SubClass = 4;
			Level = 53;
			ReqLevel = 48;
			Name = "Jade Breastplate";
			Name2 = "Jade Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 531;
			BuyPrice = 57847;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 115;
		}
	}
}


/**************************************************************
*
*				(Lofty Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class LoftyBreastplate : Item
	{
		public LoftyBreastplate() : base()
		{
			Id = 14924;
			Resistance[0] = 543;
			Bonding = 2;
			SellPrice = 14031;
			AvailableClasses = 0x7FFF;
			Model = 26871;
			ObjectClass = 4;
			SubClass = 4;
			Level = 57;
			ReqLevel = 52;
			Name = "Lofty Breastplate";
			Name2 = "Lofty Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 532;
			BuyPrice = 70158;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 115;
		}
	}
}


/**************************************************************
*
*				(Heroic Armor)
*
***************************************************************/

namespace Server.Items
{
	public class HeroicArmor : Item
	{
		public HeroicArmor() : base()
		{
			Id = 14931;
			Resistance[0] = 588;
			Bonding = 2;
			SellPrice = 18548;
			AvailableClasses = 0x7FFF;
			Model = 27932;
			ObjectClass = 4;
			SubClass = 4;
			Level = 62;
			ReqLevel = 57;
			Name = "Heroic Armor";
			Name2 = "Heroic Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 534;
			BuyPrice = 92743;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 115;
		}
	}
}


/**************************************************************
*
*				(Warbringer's Chestguard)
*
***************************************************************/

namespace Server.Items
{
	public class WarbringersChestguard : Item
	{
		public WarbringersChestguard() : base()
		{
			Id = 14939;
			Resistance[0] = 446;
			Bonding = 2;
			SellPrice = 6793;
			AvailableClasses = 0x7FFF;
			Model = 26636;
			ObjectClass = 4;
			SubClass = 4;
			Level = 46;
			ReqLevel = 41;
			Name = "Warbringer's Chestguard";
			Name2 = "Warbringer's Chestguard";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 529;
			BuyPrice = 33965;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 115;
		}
	}
}


/**************************************************************
*
*				(Bloodforged Chestpiece)
*
***************************************************************/

namespace Server.Items
{
	public class BloodforgedChestpiece : Item
	{
		public BloodforgedChestpiece() : base()
		{
			Id = 14948;
			Resistance[0] = 489;
			Bonding = 2;
			SellPrice = 10301;
			AvailableClasses = 0x7FFF;
			Model = 26838;
			ObjectClass = 4;
			SubClass = 4;
			Level = 51;
			ReqLevel = 46;
			Name = "Bloodforged Chestpiece";
			Name2 = "Bloodforged Chestpiece";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 530;
			BuyPrice = 51509;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 115;
		}
	}
}


/**************************************************************
*
*				(High Chief's Armor)
*
***************************************************************/

namespace Server.Items
{
	public class HighChiefsArmor : Item
	{
		public HighChiefsArmor() : base()
		{
			Id = 14958;
			Resistance[0] = 534;
			Bonding = 2;
			SellPrice = 12938;
			AvailableClasses = 0x7FFF;
			Model = 26827;
			ObjectClass = 4;
			SubClass = 4;
			Level = 56;
			ReqLevel = 51;
			Name = "High Chief's Armor";
			Name2 = "High Chief's Armor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 532;
			BuyPrice = 64694;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 115;
		}
	}
}


/**************************************************************
*
*				(Glorious Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class GloriousBreastplate : Item
	{
		public GloriousBreastplate() : base()
		{
			Id = 14966;
			Resistance[0] = 579;
			Bonding = 2;
			SellPrice = 17801;
			AvailableClasses = 0x7FFF;
			Model = 26859;
			ObjectClass = 4;
			SubClass = 4;
			Level = 61;
			ReqLevel = 56;
			Name = "Glorious Breastplate";
			Name2 = "Glorious Breastplate";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 534;
			BuyPrice = 89006;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 115;
		}
	}
}


/**************************************************************
*
*				(Exalted Harness)
*
***************************************************************/

namespace Server.Items
{
	public class ExaltedHarness : Item
	{
		public ExaltedHarness() : base()
		{
			Id = 14975;
			Resistance[0] = 615;
			Bonding = 2;
			SellPrice = 20219;
			AvailableClasses = 0x7FFF;
			Model = 26890;
			ObjectClass = 4;
			SubClass = 4;
			Level = 65;
			ReqLevel = 60;
			Name = "Exalted Harness";
			Name2 = "Exalted Harness";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 535;
			BuyPrice = 101099;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 115;
		}
	}
}


/**************************************************************
*
*				(Ornate Adamantium Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class OrnateAdamantiumBreastplate : Item
	{
		public OrnateAdamantiumBreastplate() : base()
		{
			Id = 15413;
			Resistance[0] = 807;
			Bonding = 1;
			SellPrice = 22519;
			AvailableClasses = 0x7FFF;
			Model = 26373;
			ObjectClass = 4;
			SubClass = 4;
			Level = 63;
			Name = "Ornate Adamantium Breastplate";
			Name2 = "Ornate Adamantium Breastplate";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 112596;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 135;
			SetSpell( 13390 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 22;
		}
	}
}


/**************************************************************
*
*				(Knight-Captain's Plate Chestguard)
*
***************************************************************/

namespace Server.Items
{
	public class KnightCaptainsPlateChestguard : Item
	{
		public KnightCaptainsPlateChestguard() : base()
		{
			Id = 16430;
			Resistance[0] = 657;
			Bonding = 1;
			SellPrice = 11564;
			AvailableClasses = 0x01;
			Model = 31083;
			ObjectClass = 4;
			SubClass = 4;
			Level = 63;
			ReqLevel = 58;
			Name = "Knight-Captain's Plate Chestguard";
			Name2 = "Knight-Captain's Plate Chestguard";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 57824;
			Sets = 282;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			MaxCount = 1;
			Material = 6;
			Durability = 135;
			Flags = 32768;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 25;
			StrBonus = 9;
			AgilityBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Knight-Captain's Lamellar Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class KnightCaptainsLamellarBreastplate : Item
	{
		public KnightCaptainsLamellarBreastplate() : base()
		{
			Id = 16433;
			Resistance[0] = 657;
			Bonding = 1;
			SellPrice = 11691;
			AvailableClasses = 0x02;
			Model = 30315;
			ObjectClass = 4;
			SubClass = 4;
			Level = 63;
			ReqLevel = 58;
			Name = "Knight-Captain's Lamellar Breastplate";
			Name2 = "Knight-Captain's Lamellar Breastplate";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 58457;
			Sets = 401;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			MaxCount = 1;
			Material = 6;
			Durability = 135;
			Flags = 32768;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 25;
			StrBonus = 9;
			AgilityBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Field Marshal's Lamellar Chestplate)
*
***************************************************************/

namespace Server.Items
{
	public class FieldMarshalsLamellarChestplate : Item
	{
		public FieldMarshalsLamellarChestplate() : base()
		{
			Id = 16473;
			Resistance[0] = 738;
			Bonding = 1;
			SellPrice = 17181;
			AvailableClasses = 0x02;
			Model = 30315;
			ObjectClass = 4;
			SubClass = 4;
			Level = 65;
			ReqLevel = 60;
			Name = "Field Marshal's Lamellar Chestplate";
			Name2 = "Field Marshal's Lamellar Chestplate";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 85907;
			Sets = 402;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			MaxCount = 1;
			Material = 6;
			Durability = 165;
			Flags = 32768;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 35;
			StrBonus = 14;
			AgilityBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Field Marshal's Plate Armor)
*
***************************************************************/

namespace Server.Items
{
	public class FieldMarshalsPlateArmor : Item
	{
		public FieldMarshalsPlateArmor() : base()
		{
			Id = 16477;
			Resistance[0] = 738;
			Bonding = 1;
			SellPrice = 16184;
			AvailableClasses = 0x01;
			Model = 30315;
			ObjectClass = 4;
			SubClass = 4;
			Level = 65;
			ReqLevel = 60;
			Name = "Field Marshal's Plate Armor";
			Name2 = "Field Marshal's Plate Armor";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 80921;
			Sets = 384;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			MaxCount = 1;
			Material = 6;
			Durability = 165;
			Flags = 32768;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 35;
			StrBonus = 13;
			AgilityBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Legionnaire's Plate Armor)
*
***************************************************************/

namespace Server.Items
{
	public class LegionnairesPlateArmor : Item
	{
		public LegionnairesPlateArmor() : base()
		{
			Id = 16513;
			Resistance[0] = 657;
			Bonding = 1;
			SellPrice = 11991;
			AvailableClasses = 0x01;
			Model = 27274;
			ObjectClass = 4;
			SubClass = 4;
			Level = 63;
			ReqLevel = 58;
			Name = "Legionnaire's Plate Armor";
			Name2 = "Legionnaire's Plate Armor";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 59955;
			Sets = 281;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			MaxCount = 1;
			Material = 6;
			Durability = 135;
			Flags = 32768;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 25;
			StrBonus = 9;
			AgilityBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Warlord's Plate Armor)
*
***************************************************************/

namespace Server.Items
{
	public class WarlordsPlateArmor : Item
	{
		public WarlordsPlateArmor() : base()
		{
			Id = 16541;
			Resistance[0] = 738;
			Bonding = 1;
			SellPrice = 16875;
			AvailableClasses = 0x01;
			Model = 30373;
			ObjectClass = 4;
			SubClass = 4;
			Level = 65;
			ReqLevel = 60;
			Name = "Warlord's Plate Armor";
			Name2 = "Warlord's Plate Armor";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 84375;
			Sets = 383;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			MaxCount = 1;
			Material = 6;
			Durability = 165;
			Flags = 32768;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 35;
			StrBonus = 13;
			AgilityBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Lightforge Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class LightforgeBreastplate : Item
	{
		public LightforgeBreastplate() : base()
		{
			Id = 16726;
			Resistance[0] = 657;
			Bonding = 1;
			SellPrice = 22270;
			AvailableClasses = 0x7FFF;
			Model = 29969;
			ObjectClass = 4;
			SubClass = 4;
			Level = 63;
			ReqLevel = 58;
			Name = "Lightforge Breastplate";
			Name2 = "Lightforge Breastplate";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 111353;
			Sets = 188;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 135;
			StaminaBonus = 21;
			SpiritBonus = 16;
			StrBonus = 13;
			IqBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Breastplate of Valor)
*
***************************************************************/

namespace Server.Items
{
	public class BreastplateOfValor : Item
	{
		public BreastplateOfValor() : base()
		{
			Id = 16730;
			Resistance[0] = 657;
			Bonding = 1;
			SellPrice = 22609;
			AvailableClasses = 0x7FFF;
			Model = 29958;
			ObjectClass = 4;
			SubClass = 4;
			Level = 63;
			ReqLevel = 58;
			Name = "Breastplate of Valor";
			Name2 = "Breastplate of Valor";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 113045;
			Sets = 189;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 135;
			StaminaBonus = 24;
			StrBonus = 15;
			AgilityBonus = 10;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Lawbringer Chestguard)
*
***************************************************************/

namespace Server.Items
{
	public class LawbringerChestguard : Item
	{
		public LawbringerChestguard() : base()
		{
			Id = 16853;
			Resistance[0] = 749;
			Bonding = 1;
			SellPrice = 37144;
			AvailableClasses = 0x02;
			Model = 31505;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 4;
			Level = 66;
			ReqLevel = 60;
			Name = "Lawbringer Chestguard";
			Name2 = "Lawbringer Chestguard";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 185721;
			Sets = 208;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 165;
			SetSpell( 9408 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 21;
			IqBonus = 13;
			StaminaBonus = 26;
			StrBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Breastplate of Might)
*
***************************************************************/

namespace Server.Items
{
	public class BreastplateOfMight : Item
	{
		public BreastplateOfMight() : base()
		{
			Id = 16865;
			Resistance[0] = 749;
			Bonding = 1;
			SellPrice = 36095;
			AvailableClasses = 0x01;
			Model = 31021;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 4;
			Level = 66;
			ReqLevel = 60;
			Name = "Breastplate of Might";
			Name2 = "Breastplate of Might";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 180477;
			Sets = 209;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 165;
			SetSpell( 13676 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 13385 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 28;
			StrBonus = 20;
		}
	}
}


/**************************************************************
*
*				(Judgement Breastplate)
*
***************************************************************/

namespace Server.Items
{
	public class JudgementBreastplate : Item
	{
		public JudgementBreastplate() : base()
		{
			Id = 16958;
			Resistance[0] = 857;
			Bonding = 1;
			SellPrice = 58801;
			AvailableClasses = 0x02;
			Model = 29874;
			Resistance[2] = 6;
			ObjectClass = 4;
			SubClass = 4;
			Level = 76;
			ReqLevel = 60;
			Name = "Judgement Breastplate";
			Name2 = "Judgement Breastplate";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 294007;
			Sets = 217;
			Resistance[5] = 6;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 165;
			AgilityBonus = 5;
			SpiritBonus = 18;
			IqBonus = 16;
			StaminaBonus = 33;
			StrBonus = 17;
		}
	}
}


/**************************************************************
*
*				(Breastplate of Wrath)
*
***************************************************************/

namespace Server.Items
{
	public class BreastplateOfWrath : Item
	{
		public BreastplateOfWrath() : base()
		{
			Id = 16966;
			Resistance[0] = 857;
			Bonding = 1;
			SellPrice = 60503;
			AvailableClasses = 0x01;
			Model = 29858;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 4;
			Level = 76;
			ReqLevel = 60;
			Name = "Breastplate of Wrath";
			Name2 = "Breastplate of Wrath";
			Resistance[3] = 10;
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 302519;
			Sets = 218;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 165;
			SetSpell( 18185 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 40;
			StrBonus = 17;
		}
	}
}


/**************************************************************
*
*				(Energized Chestplate)
*
***************************************************************/

namespace Server.Items
{
	public class EnergizedChestplate : Item
	{
		public EnergizedChestplate() : base()
		{
			Id = 18312;
			Resistance[0] = 617;
			Bonding = 1;
			SellPrice = 18073;
			AvailableClasses = 0x7FFF;
			Model = 30675;
			ObjectClass = 4;
			SubClass = 4;
			Level = 59;
			ReqLevel = 54;
			Name = "Energized Chestplate";
			Name2 = "Energized Chestplate";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 90369;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 135;
			SetSpell( 21363 , 1 , 0 , -1 , 0 , -1 );
			StrBonus = 13;
			StaminaBonus = 20;
			SpiritBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Kromcrush's Chestplate)
*
***************************************************************/

namespace Server.Items
{
	public class KromcrushsChestplate : Item
	{
		public KromcrushsChestplate() : base()
		{
			Id = 18503;
			Resistance[0] = 777;
			Bonding = 1;
			SellPrice = 22521;
			AvailableClasses = 0x7FFF;
			Model = 30837;
			ObjectClass = 4;
			SubClass = 4;
			Level = 62;
			ReqLevel = 57;
			Name = "Kromcrush's Chestplate";
			Name2 = "Kromcrush's Chestplate";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 112609;
			InventoryType = InventoryTypes.Chest;
			Stackable = 1;
			Material = 6;
			Durability = 135;
			SetSpell( 13390 , 1 , 0 , -1 , 0 , -1 );
			StrBonus = 16;
			StaminaBonus = 16;
		}
	}
}


