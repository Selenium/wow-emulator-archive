/**************************************************************
*
*		Made by fulgas (fulgas@gmail.com)
*
*  WowwoW Item Designer ( 2005/8/23 - 10:11:17 )
*
***************************************************************/

using System;
using System.Collections;

/***************************************************************/

/**************************************************************
*
*				(Heavy Mithril Pants)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyMithrilPants : Item
	{
		public HeavyMithrilPants() : base()
		{
			Id = 7921;
			Resistance[0] = 417;
			Bonding = 2;
			SellPrice = 5387;
			AvailableClasses = 0x7FFF;
			Model = 16092;
			ObjectClass = 4;
			SubClass = 4;
			Level = 42;
			ReqLevel = 40;
			Name = "Heavy Mithril Pants";
			Name2 = "Heavy Mithril Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 26936;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 85;
			StaminaBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Ornate Mithril Pants)
*
***************************************************************/

namespace Server.Items
{
	public class OrnateMithrilPants : Item
	{
		public OrnateMithrilPants() : base()
		{
			Id = 7926;
			Resistance[0] = 375;
			Bonding = 2;
			SellPrice = 5952;
			AvailableClasses = 0x7FFF;
			Model = 16103;
			ObjectClass = 4;
			SubClass = 4;
			Level = 44;
			ReqLevel = 40;
			Name = "Ornate Mithril Pants";
			Name2 = "Ornate Mithril Pants";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 29761;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 85;
			SetSpell( 13669 , 1 , 0 , -1 , 0 , -1 );
			StrBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Light Plate Pants)
*
***************************************************************/

namespace Server.Items
{
	public class LightPlatePants : Item
	{
		public LightPlatePants() : base()
		{
			Id = 8085;
			Resistance[0] = 413;
			SellPrice = 5253;
			AvailableClasses = 0x7FFF;
			Model = 28402;
			ObjectClass = 4;
			SubClass = 4;
			Level = 55;
			ReqLevel = 50;
			Name = "Light Plate Pants";
			Name2 = "Light Plate Pants";
			AvailableRaces = 0x1FF;
			BuyPrice = 26269;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Platemail Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class PlatemailLeggings : Item
	{
		public PlatemailLeggings() : base()
		{
			Id = 8093;
			Resistance[0] = 399;
			SellPrice = 5437;
			AvailableClasses = 0x7FFF;
			Model = 25833;
			ObjectClass = 4;
			SubClass = 4;
			Level = 50;
			ReqLevel = 45;
			Name = "Platemail Leggings";
			Name2 = "Platemail Leggings";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 27186;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Chromite Legplates)
*
***************************************************************/

namespace Server.Items
{
	public class ChromiteLegplates : Item
	{
		public ChromiteLegplates() : base()
		{
			Id = 8143;
			Resistance[0] = 390;
			Bonding = 2;
			SellPrice = 7227;
			AvailableClasses = 0x7FFF;
			Model = 27335;
			ObjectClass = 4;
			SubClass = 4;
			Level = 46;
			ReqLevel = 41;
			Name = "Chromite Legplates";
			Name2 = "Chromite Legplates";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 36135;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 85;
			StrBonus = 13;
			IqBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Jouster's Legplates)
*
***************************************************************/

namespace Server.Items
{
	public class JoustersLegplates : Item
	{
		public JoustersLegplates() : base()
		{
			Id = 8162;
			Resistance[0] = 263;
			Bonding = 2;
			SellPrice = 4900;
			AvailableClasses = 0x7FFF;
			Model = 27344;
			ObjectClass = 4;
			SubClass = 4;
			Level = 41;
			ReqLevel = 40;
			Name = "Jouster's Legplates";
			Name2 = "Jouster's Legplates";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 24500;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 85;
			StrBonus = 11;
			IqBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Valorous Legguards)
*
***************************************************************/

namespace Server.Items
{
	public class ValorousLegguards : Item
	{
		public ValorousLegguards() : base()
		{
			Id = 8280;
			Resistance[0] = 413;
			Bonding = 2;
			SellPrice = 8503;
			AvailableClasses = 0x7FFF;
			Model = 27377;
			ObjectClass = 4;
			SubClass = 4;
			Level = 49;
			ReqLevel = 44;
			Name = "Valorous Legguards";
			Name2 = "Valorous Legguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 42518;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 85;
			StrBonus = 14;
			IqBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Alabaster Plate Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class AlabasterPlateLeggings : Item
	{
		public AlabasterPlateLeggings() : base()
		{
			Id = 8318;
			Resistance[0] = 467;
			Bonding = 2;
			SellPrice = 12926;
			AvailableClasses = 0x7FFF;
			Model = 27393;
			ObjectClass = 4;
			SubClass = 4;
			Level = 56;
			ReqLevel = 51;
			Name = "Alabaster Plate Leggings";
			Name2 = "Alabaster Plate Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 64634;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 85;
			StrBonus = 15;
			StaminaBonus = 3;
			IqBonus = 16;
		}
	}
}


/**************************************************************
*
*				(Field Plate Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class FieldPlateLeggings : Item
	{
		public FieldPlateLeggings() : base()
		{
			Id = 9291;
			Resistance[0] = 334;
			Bonding = 2;
			SellPrice = 5286;
			AvailableClasses = 0x7FFF;
			Model = 27360;
			ObjectClass = 4;
			SubClass = 4;
			Level = 43;
			ReqLevel = 40;
			Name = "Field Plate Leggings";
			Name2 = "Field Plate Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 612;
			BuyPrice = 26432;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Embossed Plate Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class EmbossedPlateLeggings : Item
	{
		public EmbossedPlateLeggings() : base()
		{
			Id = 9970;
			Resistance[0] = 375;
			Bonding = 2;
			SellPrice = 5730;
			AvailableClasses = 0x7FFF;
			Model = 27354;
			ObjectClass = 4;
			SubClass = 4;
			Level = 44;
			ReqLevel = 40;
			Name = "Embossed Plate Leggings";
			Name2 = "Embossed Plate Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 612;
			BuyPrice = 28654;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Gothic Plate Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class GothicPlateLeggings : Item
	{
		public GothicPlateLeggings() : base()
		{
			Id = 10091;
			Resistance[0] = 397;
			Bonding = 2;
			SellPrice = 7441;
			AvailableClasses = 0x7FFF;
			Model = 27367;
			ObjectClass = 4;
			SubClass = 4;
			Level = 47;
			ReqLevel = 42;
			Name = "Gothic Plate Leggings";
			Name2 = "Gothic Plate Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 613;
			BuyPrice = 37208;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Revenant Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class RevenantLeggings : Item
	{
		public RevenantLeggings() : base()
		{
			Id = 10133;
			Resistance[0] = 435;
			Bonding = 2;
			SellPrice = 10792;
			AvailableClasses = 0x7FFF;
			Model = 27430;
			ObjectClass = 4;
			SubClass = 4;
			Level = 52;
			ReqLevel = 47;
			Name = "Revenant Leggings";
			Name2 = "Revenant Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 615;
			BuyPrice = 53964;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Templar Legplates)
*
***************************************************************/

namespace Server.Items
{
	public class TemplarLegplates : Item
	{
		public TemplarLegplates() : base()
		{
			Id = 10169;
			Resistance[0] = 475;
			Bonding = 2;
			SellPrice = 14230;
			AvailableClasses = 0x7FFF;
			Model = 27413;
			ObjectClass = 4;
			SubClass = 4;
			Level = 57;
			ReqLevel = 52;
			Name = "Templar Legplates";
			Name2 = "Templar Legplates";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 616;
			BuyPrice = 71151;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Overlord's Legplates)
*
***************************************************************/

namespace Server.Items
{
	public class OverlordsLegplates : Item
	{
		public OverlordsLegplates() : base()
		{
			Id = 10208;
			Resistance[0] = 420;
			Bonding = 2;
			SellPrice = 9586;
			AvailableClasses = 0x7FFF;
			Model = 27401;
			ObjectClass = 4;
			SubClass = 4;
			Level = 50;
			ReqLevel = 45;
			Name = "Overlord's Legplates";
			Name2 = "Overlord's Legplates";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 614;
			BuyPrice = 47933;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Heavy Lamellar Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyLamellarLeggings : Item
	{
		public HeavyLamellarLeggings() : base()
		{
			Id = 10244;
			Resistance[0] = 451;
			Bonding = 2;
			SellPrice = 12039;
			AvailableClasses = 0x7FFF;
			Model = 27383;
			ObjectClass = 4;
			SubClass = 4;
			Level = 54;
			ReqLevel = 49;
			Name = "Heavy Lamellar Leggings";
			Name2 = "Heavy Lamellar Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 615;
			BuyPrice = 60199;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Emerald Legplates)
*
***************************************************************/

namespace Server.Items
{
	public class EmeraldLegplates : Item
	{
		public EmeraldLegplates() : base()
		{
			Id = 10280;
			Resistance[0] = 491;
			Bonding = 2;
			SellPrice = 15723;
			AvailableClasses = 0x7FFF;
			Model = 13206;
			ObjectClass = 4;
			SubClass = 4;
			Level = 59;
			ReqLevel = 54;
			Name = "Emerald Legplates";
			Name2 = "Emerald Legplates";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 617;
			BuyPrice = 78615;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Imbued Plate Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class ImbuedPlateLeggings : Item
	{
		public ImbuedPlateLeggings() : base()
		{
			Id = 10373;
			Resistance[0] = 507;
			Bonding = 2;
			SellPrice = 17336;
			AvailableClasses = 0x7FFF;
			Model = 26355;
			ObjectClass = 4;
			SubClass = 4;
			Level = 61;
			ReqLevel = 56;
			Name = "Imbued Plate Leggings";
			Name2 = "Imbued Plate Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 86682;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 85;
			StrBonus = 18;
			IqBonus = 17;
		}
	}
}


/**************************************************************
*
*				(Commander's Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class CommandersLeggings : Item
	{
		public CommandersLeggings() : base()
		{
			Id = 10382;
			Resistance[0] = 515;
			Bonding = 2;
			SellPrice = 18808;
			AvailableClasses = 0x7FFF;
			Model = 26336;
			ObjectClass = 4;
			SubClass = 4;
			Level = 62;
			ReqLevel = 57;
			Name = "Commander's Leggings";
			Name2 = "Commander's Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 618;
			BuyPrice = 94041;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Hyperion Legplates)
*
***************************************************************/

namespace Server.Items
{
	public class HyperionLegplates : Item
	{
		public HyperionLegplates() : base()
		{
			Id = 10389;
			Resistance[0] = 530;
			Bonding = 2;
			SellPrice = 19770;
			AvailableClasses = 0x7FFF;
			Model = 19843;
			ObjectClass = 4;
			SubClass = 4;
			Level = 64;
			ReqLevel = 59;
			Name = "Hyperion Legplates";
			Name2 = "Hyperion Legplates";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 619;
			BuyPrice = 98854;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Silvershell Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class SilvershellLeggings : Item
	{
		public SilvershellLeggings() : base()
		{
			Id = 10633;
			Resistance[0] = 470;
			Bonding = 2;
			SellPrice = 11684;
			AvailableClasses = 0x7FFF;
			Model = 19900;
			ObjectClass = 4;
			SubClass = 4;
			Level = 51;
			ReqLevel = 46;
			Name = "Silvershell Leggings";
			Name2 = "Silvershell Leggings";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 58420;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 100;
			StaminaBonus = 12;
			StrBonus = 20;
			IqBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Centurion Legplates)
*
***************************************************************/

namespace Server.Items
{
	public class CenturionLegplates : Item
	{
		public CenturionLegplates() : base()
		{
			Id = 10740;
			Resistance[0] = 443;
			Bonding = 1;
			SellPrice = 10692;
			AvailableClasses = 0x7FFF;
			Model = 28310;
			ObjectClass = 4;
			SubClass = 4;
			Level = 53;
			Name = "Centurion Legplates";
			Name2 = "Centurion Legplates";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 53464;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 85;
			StrBonus = 15;
			AgilityBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Lavacrest Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class LavacrestLeggings : Item
	{
		public LavacrestLeggings() : base()
		{
			Id = 11802;
			Resistance[0] = 483;
			Bonding = 1;
			SellPrice = 14980;
			AvailableClasses = 0x7FFF;
			Model = 19843;
			ObjectClass = 4;
			SubClass = 4;
			Level = 58;
			ReqLevel = 53;
			Name = "Lavacrest Leggings";
			Name2 = "Lavacrest Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 74901;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 85;
			StrBonus = 20;
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Bejeweled Legguards)
*
***************************************************************/

namespace Server.Items
{
	public class BejeweledLegguards : Item
	{
		public BejeweledLegguards() : base()
		{
			Id = 11910;
			Resistance[0] = 459;
			Bonding = 1;
			SellPrice = 12345;
			AvailableClasses = 0x7FFF;
			Model = 28076;
			ObjectClass = 4;
			SubClass = 4;
			Level = 55;
			Name = "Bejeweled Legguards";
			Name2 = "Bejeweled Legguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 61727;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 85;
			SetSpell( 13669 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 15;
			IqBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Legplates of the Eternal Guardian)
*
***************************************************************/

namespace Server.Items
{
	public class LegplatesOfTheEternalGuardian : Item
	{
		public LegplatesOfTheEternalGuardian() : base()
		{
			Id = 11927;
			Resistance[0] = 742;
			Bonding = 1;
			SellPrice = 16456;
			AvailableClasses = 0x7FFF;
			Model = 21961;
			ObjectClass = 4;
			SubClass = 4;
			Level = 57;
			ReqLevel = 52;
			Name = "Legplates of the Eternal Guardian";
			Name2 = "Legplates of the Eternal Guardian";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 82283;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 100;
			SetSpell( 18196 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Thorium Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class ThoriumLeggings : Item
	{
		public ThoriumLeggings() : base()
		{
			Id = 12414;
			Resistance[6] = 10;
			Resistance[0] = 499;
			Bonding = 2;
			SellPrice = 17376;
			AvailableClasses = 0x7FFF;
			Model = 22951;
			Resistance[2] = 10;
			Resistance[4] = 10;
			ObjectClass = 4;
			SubClass = 4;
			Level = 60;
			ReqLevel = 55;
			Name = "Thorium Leggings";
			Name2 = "Thorium Leggings";
			Resistance[3] = 10;
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 86882;
			Resistance[5] = 10;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Imperial Plate Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class ImperialPlateLeggings : Item
	{
		public ImperialPlateLeggings() : base()
		{
			Id = 12429;
			Resistance[0] = 507;
			Bonding = 2;
			SellPrice = 17923;
			AvailableClasses = 0x7FFF;
			Model = 24506;
			ObjectClass = 4;
			SubClass = 4;
			Level = 61;
			ReqLevel = 56;
			Name = "Imperial Plate Leggings";
			Name2 = "Imperial Plate Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 89615;
			Sets = 321;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 85;
			StrBonus = 18;
			StaminaBonus = 18;
		}
	}
}


/**************************************************************
*
*				(Runic Plate Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class RunicPlateLeggings : Item
	{
		public RunicPlateLeggings() : base()
		{
			Id = 12614;
			Resistance[0] = 665;
			Bonding = 2;
			SellPrice = 18272;
			AvailableClasses = 0x7FFF;
			Model = 23485;
			Resistance[2] = 14;
			ObjectClass = 4;
			SubClass = 4;
			Level = 62;
			ReqLevel = 57;
			Name = "Runic Plate Leggings";
			Name2 = "Runic Plate Leggings";
			Resistance[3] = 14;
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 91363;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Enchanted Thorium Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class EnchantedThoriumLeggings : Item
	{
		public EnchantedThoriumLeggings() : base()
		{
			Id = 12619;
			Resistance[0] = 575;
			Bonding = 2;
			SellPrice = 24058;
			AvailableClasses = 0x7FFF;
			Model = 22882;
			ObjectClass = 4;
			SubClass = 4;
			Level = 63;
			ReqLevel = 58;
			Name = "Enchanted Thorium Leggings";
			Name2 = "Enchanted Thorium Leggings";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 120290;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 100;
			SetSpell( 13387 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 21;
			StrBonus = 20;
		}
	}
}


/**************************************************************
*
*				(Warmaster Legguards)
*
***************************************************************/

namespace Server.Items
{
	public class WarmasterLegguards : Item
	{
		public WarmasterLegguards() : base()
		{
			Id = 12935;
			Resistance[0] = 575;
			Bonding = 1;
			SellPrice = 23196;
			AvailableClasses = 0x7FFF;
			Model = 28625;
			ObjectClass = 4;
			SubClass = 4;
			Level = 63;
			ReqLevel = 58;
			Name = "Warmaster Legguards";
			Name2 = "Warmaster Legguards";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 115982;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 100;
			SetSpell( 13670 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 15;
			StrBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Golem Shard Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class GolemShardLeggings : Item
	{
		public GolemShardLeggings() : base()
		{
			Id = 13074;
			Resistance[0] = 429;
			Bonding = 2;
			SellPrice = 8024;
			AvailableClasses = 0x7FFF;
			Model = 21961;
			ObjectClass = 4;
			SubClass = 4;
			Level = 46;
			ReqLevel = 41;
			Name = "Golem Shard Leggings";
			Name2 = "Golem Shard Leggings";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 40124;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 100;
			SetSpell( 13384 , 1 , 0 , -1 , 0 , -1 );
			StrBonus = 22;
		}
	}
}


/**************************************************************
*
*				(Direwing Legguards)
*
***************************************************************/

namespace Server.Items
{
	public class DirewingLegguards : Item
	{
		public DirewingLegguards() : base()
		{
			Id = 13075;
			Resistance[0] = 575;
			Bonding = 2;
			SellPrice = 22090;
			AvailableClasses = 0x7FFF;
			Model = 28716;
			ObjectClass = 4;
			SubClass = 4;
			Level = 63;
			ReqLevel = 58;
			Name = "Direwing Legguards";
			Name2 = "Direwing Legguards";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 110454;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 100;
			StrBonus = 15;
			StaminaBonus = 16;
			IqBonus = 16;
			AgilityBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Handcrafted Mastersmith Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class HandcraftedMastersmithLeggings : Item
	{
		public HandcraftedMastersmithLeggings() : base()
		{
			Id = 13498;
			Resistance[0] = 785;
			Bonding = 1;
			SellPrice = 18274;
			AvailableClasses = 0x7FFF;
			Model = 24162;
			ObjectClass = 4;
			SubClass = 4;
			Level = 62;
			ReqLevel = 57;
			Name = "Handcrafted Mastersmith Leggings";
			Name2 = "Handcrafted Mastersmith Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 91372;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Cloudkeeper Legplates)
*
***************************************************************/

namespace Server.Items
{
	public class CloudkeeperLegplates : Item
	{
		public CloudkeeperLegplates() : base()
		{
			Id = 14554;
			Resistance[0] = 617;
			Bonding = 2;
			SellPrice = 29900;
			AvailableClasses = 0x7FFF;
			Model = 25343;
			ObjectClass = 4;
			SubClass = 4;
			Level = 62;
			ReqLevel = 57;
			Name = "Cloudkeeper Legplates";
			Name2 = "Cloudkeeper Legplates";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 149502;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 120;
			SetSpell( 18787 , 0 , 0 , 900000 , 28 , 300000 );
			StaminaBonus = 20;
			StrBonus = 20;
			AgilityBonus = 20;
		}
	}
}


/**************************************************************
*
*				(Deathbone Legguards)
*
***************************************************************/

namespace Server.Items
{
	public class DeathboneLegguards : Item
	{
		public DeathboneLegguards() : base()
		{
			Id = 14623;
			Resistance[0] = 507;
			Bonding = 1;
			SellPrice = 17085;
			AvailableClasses = 0x7FFF;
			Model = 25226;
			ObjectClass = 4;
			SubClass = 4;
			Level = 61;
			ReqLevel = 56;
			Name = "Deathbone Legguards";
			Name2 = "Deathbone Legguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 85428;
			Sets = 124;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 85;
			StrBonus = 15;
			AgilityBonus = 14;
			IqBonus = 14;
		}
	}
}


/**************************************************************
*
*				(Symbolic Legplates)
*
***************************************************************/

namespace Server.Items
{
	public class SymbolicLegplates : Item
	{
		public SymbolicLegplates() : base()
		{
			Id = 14829;
			Resistance[0] = 297;
			Bonding = 2;
			SellPrice = 5049;
			AvailableClasses = 0x7FFF;
			Model = 26814;
			ObjectClass = 4;
			SubClass = 4;
			Level = 42;
			ReqLevel = 40;
			Name = "Symbolic Legplates";
			Name2 = "Symbolic Legplates";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 25249;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 85;
			StrBonus = 15;
			AgilityBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Tyrant's Legplates)
*
***************************************************************/

namespace Server.Items
{
	public class TyrantsLegplates : Item
	{
		public TyrantsLegplates() : base()
		{
			Id = 14840;
			Resistance[0] = 397;
			Bonding = 2;
			SellPrice = 7925;
			AvailableClasses = 0x7FFF;
			Model = 26691;
			ObjectClass = 4;
			SubClass = 4;
			Level = 47;
			ReqLevel = 42;
			Name = "Tyrant's Legplates";
			Name2 = "Tyrant's Legplates";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 39627;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 85;
			StrBonus = 19;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Sunscale Legplates)
*
***************************************************************/

namespace Server.Items
{
	public class SunscaleLegplates : Item
	{
		public SunscaleLegplates() : base()
		{
			Id = 14850;
			Resistance[0] = 435;
			Bonding = 2;
			SellPrice = 10442;
			AvailableClasses = 0x7FFF;
			Model = 26824;
			ObjectClass = 4;
			SubClass = 4;
			Level = 52;
			ReqLevel = 47;
			Name = "Sunscale Legplates";
			Name2 = "Sunscale Legplates";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 52214;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 85;
			StrBonus = 19;
			StaminaBonus = 7;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Vanguard Legplates)
*
***************************************************************/

namespace Server.Items
{
	public class VanguardLegplates : Item
	{
		public VanguardLegplates() : base()
		{
			Id = 14859;
			Resistance[0] = 475;
			Bonding = 2;
			SellPrice = 14820;
			AvailableClasses = 0x7FFF;
			Model = 26849;
			ObjectClass = 4;
			SubClass = 4;
			Level = 57;
			ReqLevel = 52;
			Name = "Vanguard Legplates";
			Name2 = "Vanguard Legplates";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 74102;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 85;
			IqBonus = 21;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Warleader's Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class WarleadersLeggings : Item
	{
		public WarleadersLeggings() : base()
		{
			Id = 14867;
			Resistance[0] = 515;
			Bonding = 2;
			SellPrice = 17802;
			AvailableClasses = 0x7FFF;
			Model = 26884;
			ObjectClass = 4;
			SubClass = 4;
			Level = 62;
			ReqLevel = 57;
			Name = "Warleader's Leggings";
			Name2 = "Warleader's Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 89014;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 85;
			StrBonus = 15;
			StaminaBonus = 18;
			AgilityBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Saltstone Legplates)
*
***************************************************************/

namespace Server.Items
{
	public class SaltstoneLegplates : Item
	{
		public SaltstoneLegplates() : base()
		{
			Id = 14900;
			Resistance[0] = 232;
			Bonding = 2;
			SellPrice = 4298;
			AvailableClasses = 0x7FFF;
			Model = 26651;
			ObjectClass = 4;
			SubClass = 4;
			Level = 40;
			ReqLevel = 40;
			Name = "Saltstone Legplates";
			Name2 = "Saltstone Legplates";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 611;
			BuyPrice = 21490;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Brutish Legguards)
*
***************************************************************/

namespace Server.Items
{
	public class BrutishLegguards : Item
	{
		public BrutishLegguards() : base()
		{
			Id = 14908;
			Resistance[0] = 405;
			Bonding = 2;
			SellPrice = 8195;
			AvailableClasses = 0x7FFF;
			Model = 27900;
			ObjectClass = 4;
			SubClass = 4;
			Level = 48;
			ReqLevel = 43;
			Name = "Brutish Legguards";
			Name2 = "Brutish Legguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 613;
			BuyPrice = 40977;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Jade Legplates)
*
***************************************************************/

namespace Server.Items
{
	public class JadeLegplates : Item
	{
		public JadeLegplates() : base()
		{
			Id = 14920;
			Resistance[0] = 427;
			Bonding = 2;
			SellPrice = 9744;
			AvailableClasses = 0x7FFF;
			Model = 26800;
			ObjectClass = 4;
			SubClass = 4;
			Level = 51;
			ReqLevel = 46;
			Name = "Jade Legplates";
			Name2 = "Jade Legplates";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 614;
			BuyPrice = 48723;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Lofty Legguards)
*
***************************************************************/

namespace Server.Items
{
	public class LoftyLegguards : Item
	{
		public LoftyLegguards() : base()
		{
			Id = 14928;
			Resistance[0] = 459;
			Bonding = 2;
			SellPrice = 12673;
			AvailableClasses = 0x7FFF;
			Model = 26873;
			ObjectClass = 4;
			SubClass = 4;
			Level = 55;
			ReqLevel = 50;
			Name = "Lofty Legguards";
			Name2 = "Lofty Legguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 616;
			BuyPrice = 63368;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Heroic Legplates)
*
***************************************************************/

namespace Server.Items
{
	public class HeroicLegplates : Item
	{
		public HeroicLegplates() : base()
		{
			Id = 14936;
			Resistance[0] = 507;
			Bonding = 2;
			SellPrice = 16702;
			AvailableClasses = 0x7FFF;
			Model = 27938;
			ObjectClass = 4;
			SubClass = 4;
			Level = 61;
			ReqLevel = 56;
			Name = "Heroic Legplates";
			Name2 = "Heroic Legplates";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 618;
			BuyPrice = 83513;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Warbringer's Legguards)
*
***************************************************************/

namespace Server.Items
{
	public class WarbringersLegguards : Item
	{
		public WarbringersLegguards() : base()
		{
			Id = 14945;
			Resistance[0] = 382;
			Bonding = 2;
			SellPrice = 6432;
			AvailableClasses = 0x7FFF;
			Model = 26641;
			ObjectClass = 4;
			SubClass = 4;
			Level = 45;
			ReqLevel = 40;
			Name = "Warbringer's Legguards";
			Name2 = "Warbringer's Legguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 612;
			BuyPrice = 32162;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Bloodforged Legplates)
*
***************************************************************/

namespace Server.Items
{
	public class BloodforgedLegplates : Item
	{
		public BloodforgedLegplates() : base()
		{
			Id = 14953;
			Resistance[0] = 413;
			Bonding = 2;
			SellPrice = 9158;
			AvailableClasses = 0x7FFF;
			Model = 26840;
			ObjectClass = 4;
			SubClass = 4;
			Level = 49;
			ReqLevel = 44;
			Name = "Bloodforged Legplates";
			Name2 = "Bloodforged Legplates";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 614;
			BuyPrice = 45794;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(High Chief's Legguards)
*
***************************************************************/

namespace Server.Items
{
	public class HighChiefsLegguards : Item
	{
		public HighChiefsLegguards() : base()
		{
			Id = 14962;
			Resistance[0] = 451;
			Bonding = 2;
			SellPrice = 11690;
			AvailableClasses = 0x7FFF;
			Model = 26831;
			ObjectClass = 4;
			SubClass = 4;
			Level = 54;
			ReqLevel = 49;
			Name = "High Chief's Legguards";
			Name2 = "High Chief's Legguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 615;
			BuyPrice = 58454;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Glorious Legplates)
*
***************************************************************/

namespace Server.Items
{
	public class GloriousLegplates : Item
	{
		public GloriousLegplates() : base()
		{
			Id = 14970;
			Resistance[0] = 483;
			Bonding = 2;
			SellPrice = 15598;
			AvailableClasses = 0x7FFF;
			Model = 26861;
			ObjectClass = 4;
			SubClass = 4;
			Level = 58;
			ReqLevel = 53;
			Name = "Glorious Legplates";
			Name2 = "Glorious Legplates";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 617;
			BuyPrice = 77992;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Exalted Legplates)
*
***************************************************************/

namespace Server.Items
{
	public class ExaltedLegplates : Item
	{
		public ExaltedLegplates() : base()
		{
			Id = 14980;
			Resistance[0] = 522;
			Bonding = 2;
			SellPrice = 19201;
			AvailableClasses = 0x7FFF;
			Model = 26891;
			ObjectClass = 4;
			SubClass = 4;
			Level = 63;
			ReqLevel = 58;
			Name = "Exalted Legplates";
			Name2 = "Exalted Legplates";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 618;
			BuyPrice = 96008;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 85;
		}
	}
}


/**************************************************************
*
*				(Knight-Captain's Plate Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class KnightCaptainsPlateLeggings : Item
	{
		public KnightCaptainsPlateLeggings() : base()
		{
			Id = 16431;
			Resistance[0] = 575;
			Bonding = 1;
			SellPrice = 11606;
			AvailableClasses = 0x01;
			Model = 26659;
			ObjectClass = 4;
			SubClass = 4;
			Level = 63;
			ReqLevel = 58;
			Name = "Knight-Captain's Plate Leggings";
			Name2 = "Knight-Captain's Plate Leggings";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 58031;
			Sets = 282;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			MaxCount = 1;
			Material = 6;
			Durability = 100;
			Flags = 32768;
			SetSpell( 7598 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 13;
			StrBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Knight-Captain's Lamellar Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class KnightCaptainsLamellarLeggings : Item
	{
		public KnightCaptainsLamellarLeggings() : base()
		{
			Id = 16435;
			Resistance[0] = 575;
			Bonding = 1;
			SellPrice = 11775;
			AvailableClasses = 0x02;
			Model = 31084;
			ObjectClass = 4;
			SubClass = 4;
			Level = 63;
			ReqLevel = 58;
			Name = "Knight-Captain's Lamellar Leggings";
			Name2 = "Knight-Captain's Lamellar Leggings";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 58878;
			Sets = 401;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			MaxCount = 1;
			Material = 6;
			Durability = 100;
			Flags = 32768;
			SetSpell( 7598 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 13;
			StrBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Marshal's Lamellar Legplates)
*
***************************************************************/

namespace Server.Items
{
	public class MarshalsLamellarLegplates : Item
	{
		public MarshalsLamellarLegplates() : base()
		{
			Id = 16475;
			Resistance[0] = 646;
			Bonding = 1;
			SellPrice = 17755;
			AvailableClasses = 0x02;
			Model = 30317;
			ObjectClass = 4;
			SubClass = 4;
			Level = 65;
			ReqLevel = 60;
			Name = "Marshal's Lamellar Legplates";
			Name2 = "Marshal's Lamellar Legplates";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 88777;
			Sets = 402;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			MaxCount = 1;
			Material = 6;
			Durability = 120;
			Flags = 32768;
			SetSpell( 15464 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 7598 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 19;
			StaminaBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Marshal's Plate Legguards)
*
***************************************************************/

namespace Server.Items
{
	public class MarshalsPlateLegguards : Item
	{
		public MarshalsPlateLegguards() : base()
		{
			Id = 16479;
			Resistance[0] = 646;
			Bonding = 1;
			SellPrice = 16309;
			AvailableClasses = 0x01;
			Model = 30317;
			ObjectClass = 4;
			SubClass = 4;
			Level = 65;
			ReqLevel = 60;
			Name = "Marshal's Plate Legguards";
			Name2 = "Marshal's Plate Legguards";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 81548;
			Sets = 384;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			MaxCount = 1;
			Material = 6;
			Durability = 120;
			Flags = 32768;
			SetSpell( 7598 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 15464 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 20;
			StrBonus = 16;
		}
	}
}


/**************************************************************
*
*				(Legionnaire's Plate Legguards)
*
***************************************************************/

namespace Server.Items
{
	public class LegionnairesPlateLegguards : Item
	{
		public LegionnairesPlateLegguards() : base()
		{
			Id = 16515;
			Resistance[0] = 575;
			Bonding = 1;
			SellPrice = 12075;
			AvailableClasses = 0x01;
			Model = 31052;
			ObjectClass = 4;
			SubClass = 4;
			Level = 63;
			ReqLevel = 58;
			Name = "Legionnaire's Plate Legguards";
			Name2 = "Legionnaire's Plate Legguards";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 60375;
			Sets = 281;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			MaxCount = 1;
			Material = 6;
			Durability = 100;
			Flags = 32768;
			SetSpell( 7598 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 13;
			StrBonus = 7;
		}
	}
}


/**************************************************************
*
*				(General's Plate Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class GeneralsPlateLeggings : Item
	{
		public GeneralsPlateLeggings() : base()
		{
			Id = 16543;
			Resistance[0] = 646;
			Bonding = 1;
			SellPrice = 17000;
			AvailableClasses = 0x01;
			Model = 30375;
			ObjectClass = 4;
			SubClass = 4;
			Level = 65;
			ReqLevel = 60;
			Name = "General's Plate Leggings";
			Name2 = "General's Plate Leggings";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 85001;
			Sets = 383;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			MaxCount = 1;
			Material = 6;
			Durability = 120;
			Flags = 32768;
			SetSpell( 7598 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 15464 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 20;
			StrBonus = 16;
		}
	}
}


/**************************************************************
*
*				(Lightforge Legplates)
*
***************************************************************/

namespace Server.Items
{
	public class LightforgeLegplates : Item
	{
		public LightforgeLegplates() : base()
		{
			Id = 16728;
			Resistance[0] = 557;
			Bonding = 1;
			SellPrice = 20354;
			AvailableClasses = 0x7FFF;
			Model = 29972;
			ObjectClass = 4;
			SubClass = 4;
			Level = 61;
			ReqLevel = 56;
			Name = "Lightforge Legplates";
			Name2 = "Lightforge Legplates";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 101773;
			Sets = 188;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 100;
			StrBonus = 20;
			StaminaBonus = 14;
			SpiritBonus = 12;
			IqBonus = 9;
			AgilityBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Legplates of Valor)
*
***************************************************************/

namespace Server.Items
{
	public class LegplatesOfValor : Item
	{
		public LegplatesOfValor() : base()
		{
			Id = 16732;
			Resistance[0] = 557;
			Bonding = 1;
			SellPrice = 21213;
			AvailableClasses = 0x7FFF;
			Model = 29963;
			ObjectClass = 4;
			SubClass = 4;
			Level = 61;
			ReqLevel = 56;
			Name = "Legplates of Valor";
			Name2 = "Legplates of Valor";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 106066;
			Sets = 189;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 100;
			StrBonus = 23;
			StaminaBonus = 15;
			AgilityBonus = 11;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Lawbringer Legplates)
*
***************************************************************/

namespace Server.Items
{
	public class LawbringerLegplates : Item
	{
		public LawbringerLegplates() : base()
		{
			Id = 16855;
			Resistance[0] = 655;
			Bonding = 1;
			SellPrice = 33848;
			AvailableClasses = 0x02;
			Model = 31352;
			ObjectClass = 4;
			SubClass = 4;
			Level = 66;
			ReqLevel = 60;
			Name = "Lawbringer Legplates";
			Name2 = "Lawbringer Legplates";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 169242;
			Sets = 208;
			Resistance[5] = 10;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 120;
			SetSpell( 21625 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 9408 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 18;
			IqBonus = 18;
			StaminaBonus = 24;
			StrBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Legplates of Might)
*
***************************************************************/

namespace Server.Items
{
	public class LegplatesOfMight : Item
	{
		public LegplatesOfMight() : base()
		{
			Id = 16867;
			Resistance[0] = 655;
			Bonding = 1;
			SellPrice = 36358;
			AvailableClasses = 0x01;
			Model = 31023;
			ObjectClass = 4;
			SubClass = 4;
			Level = 66;
			ReqLevel = 60;
			Name = "Legplates of Might";
			Name2 = "Legplates of Might";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 181792;
			Sets = 209;
			Resistance[5] = 10;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 120;
			SetSpell( 13665 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 13385 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 23;
			StrBonus = 24;
		}
	}
}


/**************************************************************
*
*				(Judgement Legplates)
*
***************************************************************/

namespace Server.Items
{
	public class JudgementLegplates : Item
	{
		public JudgementLegplates() : base()
		{
			Id = 16954;
			Resistance[6] = 10;
			Resistance[0] = 749;
			Bonding = 1;
			SellPrice = 56415;
			AvailableClasses = 0x02;
			Model = 29878;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 4;
			Level = 76;
			ReqLevel = 60;
			Name = "Judgement Legplates";
			Name2 = "Judgement Legplates";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 282077;
			Sets = 217;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 120;
			SetSpell( 18029 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 27;
			IqBonus = 17;
			StaminaBonus = 26;
		}
	}
}


/**************************************************************
*
*				(Legplates of Wrath)
*
***************************************************************/

namespace Server.Items
{
	public class LegplatesOfWrath : Item
	{
		public LegplatesOfWrath() : base()
		{
			Id = 16962;
			Resistance[6] = 10;
			Resistance[0] = 749;
			Bonding = 1;
			SellPrice = 59652;
			AvailableClasses = 0x01;
			Model = 25226;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 4;
			Level = 76;
			ReqLevel = 60;
			Name = "Legplates of Wrath";
			Name2 = "Legplates of Wrath";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 298263;
			Sets = 218;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 120;
			SetSpell( 13670 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 18185 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 27;
			StrBonus = 19;
		}
	}
}


/**************************************************************
*
*				(Dark Iron Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class DarkIronLeggings : Item
	{
		public DarkIronLeggings() : base()
		{
			Id = 17013;
			Resistance[0] = 778;
			Bonding = 2;
			SellPrice = 26441;
			AvailableClasses = 0x7FFF;
			Model = 28843;
			Resistance[2] = 30;
			ObjectClass = 4;
			SubClass = 4;
			Level = 60;
			ReqLevel = 55;
			Name = "Dark Iron Leggings";
			Name2 = "Dark Iron Leggings";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 132207;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 120;
			StaminaBonus = 14;
		}
	}
}


/**************************************************************
*
*				(Elemental Rockridge Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class ElementalRockridgeLeggings : Item
	{
		public ElementalRockridgeLeggings() : base()
		{
			Id = 17711;
			Resistance[0] = 496;
			Bonding = 1;
			SellPrice = 14244;
			AvailableClasses = 0x7FFF;
			Model = 29880;
			ObjectClass = 4;
			SubClass = 4;
			Level = 54;
			ReqLevel = 49;
			Name = "Elemental Rockridge Leggings";
			Name2 = "Elemental Rockridge Leggings";
			Resistance[3] = 10;
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 71223;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 100;
			StaminaBonus = 18;
			StrBonus = 20;
		}
	}
}


/**************************************************************
*
*				(Breakwater Legguards)
*
***************************************************************/

namespace Server.Items
{
	public class BreakwaterLegguards : Item
	{
		public BreakwaterLegguards() : base()
		{
			Id = 18305;
			Resistance[0] = 483;
			Bonding = 1;
			SellPrice = 14375;
			AvailableClasses = 0x7FFF;
			Model = 30671;
			ObjectClass = 4;
			SubClass = 4;
			Level = 58;
			ReqLevel = 53;
			Name = "Breakwater Legguards";
			Name2 = "Breakwater Legguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 71879;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 85;
			SetSpell( 13665 , 1 , 0 , -1 , 0 , -1 );
			StrBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Eldritch Reinforced Legplates)
*
***************************************************************/

namespace Server.Items
{
	public class EldritchReinforcedLegplates : Item
	{
		public EldritchReinforcedLegplates() : base()
		{
			Id = 18380;
			Resistance[0] = 566;
			Bonding = 1;
			SellPrice = 21135;
			AvailableClasses = 0x7FFF;
			Model = 30737;
			ObjectClass = 4;
			SubClass = 4;
			Level = 62;
			ReqLevel = 57;
			Name = "Eldritch Reinforced Legplates";
			Name2 = "Eldritch Reinforced Legplates";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 105677;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 100;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			StrBonus = 15;
			StaminaBonus = 20;
			AgilityBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Wraithplate Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class WraithplateLeggings : Item
	{
		public WraithplateLeggings() : base()
		{
			Id = 18690;
			Resistance[0] = 696;
			Bonding = 1;
			SellPrice = 22026;
			AvailableClasses = 0x7FFF;
			Model = 25226;
			ObjectClass = 4;
			SubClass = 4;
			Level = 62;
			ReqLevel = 57;
			Name = "Wraithplate Leggings";
			Name2 = "Wraithplate Leggings";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 110130;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 100;
			SetSpell( 13665 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 20;
		}
	}
}


/**************************************************************
*
*				(Chitinous Plate Legguards)
*
***************************************************************/

namespace Server.Items
{
	public class ChitinousPlateLegguards : Item
	{
		public ChitinousPlateLegguards() : base()
		{
			Id = 18739;
			Resistance[0] = 557;
			Bonding = 1;
			SellPrice = 20124;
			AvailableClasses = 0x7FFF;
			Model = 31191;
			ObjectClass = 4;
			SubClass = 4;
			Level = 61;
			ReqLevel = 56;
			Name = "Chitinous Plate Legguards";
			Name2 = "Chitinous Plate Legguards";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 100624;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 100;
			SetSpell( 21363 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 20;
			StaminaBonus = 20;
		}
	}
}


/**************************************************************
*
*				(Flamewaker Legplates)
*
***************************************************************/

namespace Server.Items
{
	public class FlamewakerLegplates : Item
	{
		public FlamewakerLegplates() : base()
		{
			Id = 18861;
			Resistance[0] = 748;
			Bonding = 1;
			SellPrice = 28493;
			AvailableClasses = 0x7FFF;
			Model = 31320;
			Resistance[2] = 11;
			ObjectClass = 4;
			SubClass = 4;
			Level = 61;
			ReqLevel = 56;
			Name = "Flamewaker Legplates";
			Name2 = "Flamewaker Legplates";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 142467;
			Resistance[5] = 11;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 120;
			SetSpell( 13669 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 22;
			StrBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Laquered Wooden Plate Legplates)
*
***************************************************************/

namespace Server.Items
{
	public class LaqueredWoodenPlateLegplates : Item
	{
		public LaqueredWoodenPlateLegplates() : base()
		{
			Id = 19117;
			Resistance[0] = 420;
			Bonding = 1;
			SellPrice = 8915;
			AvailableClasses = 0x7FFF;
			Model = 31626;
			ObjectClass = 4;
			SubClass = 4;
			Level = 50;
			Name = "Laquered Wooden Plate Legplates";
			Name2 = "Laquered Wooden Plate Legplates";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 44578;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 85;
			StrBonus = 17;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Slagplate Leggings)
*
***************************************************************/

namespace Server.Items
{
	public class SlagplateLeggings : Item
	{
		public SlagplateLeggings() : base()
		{
			Id = 19124;
			Resistance[0] = 405;
			Bonding = 1;
			SellPrice = 8259;
			AvailableClasses = 0x7FFF;
			Model = 31635;
			ObjectClass = 4;
			SubClass = 4;
			Level = 48;
			Name = "Slagplate Leggings";
			Name2 = "Slagplate Leggings";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 41296;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 85;
			SetSpell( 7516 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 12;
			StrBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Legguards of the Fallen Crusader)
*
***************************************************************/

namespace Server.Items
{
	public class LegguardsOfTheFallenCrusader : Item
	{
		public LegguardsOfTheFallenCrusader() : base()
		{
			Id = 19402;
			Resistance[0] = 740;
			Bonding = 1;
			SellPrice = 55609;
			AvailableClasses = 0x7FFF;
			Model = 31933;
			ObjectClass = 4;
			SubClass = 4;
			Level = 75;
			ReqLevel = 60;
			Name = "Legguards of the Fallen Crusader";
			Name2 = "Legguards of the Fallen Crusader";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 278048;
			InventoryType = InventoryTypes.Legs;
			Stackable = 1;
			Material = 6;
			Durability = 120;
			StrBonus = 28;
			AgilityBonus = 22;
			SpiritBonus = 17;
			StaminaBonus = 22;
		}
	}
}


