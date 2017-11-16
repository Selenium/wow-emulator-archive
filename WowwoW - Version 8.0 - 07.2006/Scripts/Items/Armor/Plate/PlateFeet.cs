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
*				(Heavy Mithril Boots)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyMithrilBoots : Item
	{
		public HeavyMithrilBoots() : base()
		{
			Id = 7933;
			Resistance[0] = 382;
			Bonding = 2;
			SellPrice = 5769;
			AvailableClasses = 0x7FFF;
			Model = 16113;
			ObjectClass = 4;
			SubClass = 4;
			Level = 47;
			ReqLevel = 42;
			Name = "Heavy Mithril Boots";
			Name2 = "Heavy Mithril Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 28847;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 55;
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Ornate Mithril Boots)
*
***************************************************************/

namespace Server.Items
{
	public class OrnateMithrilBoots : Item
	{
		public OrnateMithrilBoots() : base()
		{
			Id = 7936;
			Resistance[0] = 324;
			Bonding = 2;
			SellPrice = 6739;
			AvailableClasses = 0x7FFF;
			Model = 16118;
			ObjectClass = 4;
			SubClass = 4;
			Level = 49;
			ReqLevel = 44;
			Name = "Ornate Mithril Boots";
			Name2 = "Ornate Mithril Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 33696;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 55;
			SetSpell( 13669 , 1 , 0 , 0 , 0 , 0 );
			SetSpell( 9774 , 0 , 0 , 1800000 , 28 , 30000 );
		}
	}
}


/**************************************************************
*
*				(Light Plate Boots)
*
***************************************************************/

namespace Server.Items
{
	public class LightPlateBoots : Item
	{
		public LightPlateBoots() : base()
		{
			Id = 8082;
			Resistance[0] = 308;
			SellPrice = 3189;
			AvailableClasses = 0x7FFF;
			Model = 28404;
			ObjectClass = 4;
			SubClass = 4;
			Level = 52;
			ReqLevel = 47;
			Name = "Light Plate Boots";
			Name2 = "Light Plate Boots";
			AvailableRaces = 0x1FF;
			BuyPrice = 15945;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Platemail Boots)
*
***************************************************************/

namespace Server.Items
{
	public class PlatemailBoots : Item
	{
		public PlatemailBoots() : base()
		{
			Id = 8089;
			Resistance[0] = 314;
			SellPrice = 4016;
			AvailableClasses = 0x7FFF;
			Model = 28396;
			ObjectClass = 4;
			SubClass = 4;
			Level = 50;
			ReqLevel = 45;
			Name = "Platemail Boots";
			Name2 = "Platemail Boots";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 20081;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Chromite Greaves)
*
***************************************************************/

namespace Server.Items
{
	public class ChromiteGreaves : Item
	{
		public ChromiteGreaves() : base()
		{
			Id = 8141;
			Resistance[0] = 294;
			Bonding = 2;
			SellPrice = 4613;
			AvailableClasses = 0x7FFF;
			Model = 27334;
			ObjectClass = 4;
			SubClass = 4;
			Level = 44;
			ReqLevel = 40;
			Name = "Chromite Greaves";
			Name2 = "Chromite Greaves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 23068;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 55;
			StrBonus = 4;
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Jouster's Greaves)
*
***************************************************************/

namespace Server.Items
{
	public class JoustersGreaves : Item
	{
		public JoustersGreaves() : base()
		{
			Id = 8160;
			Resistance[0] = 182;
			Bonding = 2;
			SellPrice = 3378;
			AvailableClasses = 0x7FFF;
			Model = 27343;
			ObjectClass = 4;
			SubClass = 4;
			Level = 40;
			ReqLevel = 40;
			Name = "Jouster's Greaves";
			Name2 = "Jouster's Greaves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 16893;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 55;
			StrBonus = 8;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Valorous Greaves)
*
***************************************************************/

namespace Server.Items
{
	public class ValorousGreaves : Item
	{
		public ValorousGreaves() : base()
		{
			Id = 8278;
			Resistance[0] = 312;
			Bonding = 2;
			SellPrice = 5477;
			AvailableClasses = 0x7FFF;
			Model = 27376;
			ObjectClass = 4;
			SubClass = 4;
			Level = 47;
			ReqLevel = 42;
			Name = "Valorous Greaves";
			Name2 = "Valorous Greaves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 27387;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 55;
			StaminaBonus = 10;
			AgilityBonus = 4;
			IqBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Alabaster Plate Greaves)
*
***************************************************************/

namespace Server.Items
{
	public class AlabasterPlateGreaves : Item
	{
		public AlabasterPlateGreaves() : base()
		{
			Id = 8316;
			Resistance[0] = 348;
			Bonding = 2;
			SellPrice = 8078;
			AvailableClasses = 0x7FFF;
			Model = 27392;
			ObjectClass = 4;
			SubClass = 4;
			Level = 53;
			ReqLevel = 48;
			Name = "Alabaster Plate Greaves";
			Name2 = "Alabaster Plate Greaves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 40393;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 55;
			StrBonus = 12;
			StaminaBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Field Plate Boots)
*
***************************************************************/

namespace Server.Items
{
	public class FieldPlateBoots : Item
	{
		public FieldPlateBoots() : base()
		{
			Id = 9289;
			Resistance[0] = 206;
			Bonding = 2;
			SellPrice = 3635;
			AvailableClasses = 0x7FFF;
			Model = 27357;
			ObjectClass = 4;
			SubClass = 4;
			Level = 41;
			ReqLevel = 40;
			Name = "Field Plate Boots";
			Name2 = "Field Plate Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 863;
			BuyPrice = 18178;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Revelosh's Boots)
*
***************************************************************/

namespace Server.Items
{
	public class ReveloshsBoots : Item
	{
		public ReveloshsBoots() : base()
		{
			Id = 9387;
			Resistance[0] = 206;
			Bonding = 1;
			SellPrice = 3438;
			AvailableClasses = 0x7FFF;
			Model = 18430;
			ObjectClass = 4;
			SubClass = 4;
			Level = 41;
			ReqLevel = 40;
			Name = "Revelosh's Boots";
			Name2 = "Revelosh's Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 863;
			BuyPrice = 17194;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Shinkicker Boots)
*
***************************************************************/

namespace Server.Items
{
	public class ShinkickerBoots : Item
	{
		public ShinkickerBoots() : base()
		{
			Id = 9637;
			Resistance[0] = 300;
			Bonding = 1;
			SellPrice = 4749;
			AvailableClasses = 0x7FFF;
			Model = 28252;
			ObjectClass = 4;
			SubClass = 4;
			Level = 45;
			Name = "Shinkicker Boots";
			Name2 = "Shinkicker Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 23747;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 55;
			StrBonus = 10;
			AgilityBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Gnomish Water Sinking Device)
*
***************************************************************/

namespace Server.Items
{
	public class GnomishWaterSinkingDevice : Item
	{
		public GnomishWaterSinkingDevice() : base()
		{
			Id = 9646;
			Resistance[0] = 324;
			Bonding = 1;
			SellPrice = 6791;
			AvailableClasses = 0x7FFF;
			Model = 28172;
			ObjectClass = 4;
			SubClass = 4;
			Level = 49;
			Name = "Gnomish Water Sinking Device";
			Name2 = "Gnomish Water Sinking Device";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 33959;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 55;
			AgilityBonus = -5;
			StaminaBonus = 16;
		}
	}
}


/**************************************************************
*
*				(Rushridge Boots)
*
***************************************************************/

namespace Server.Items
{
	public class RushridgeBoots : Item
	{
		public RushridgeBoots() : base()
		{
			Id = 9662;
			Resistance[0] = 262;
			Bonding = 1;
			SellPrice = 4258;
			AvailableClasses = 0x7FFF;
			Model = 28295;
			ObjectClass = 4;
			SubClass = 4;
			Level = 43;
			Name = "Rushridge Boots";
			Name2 = "Rushridge Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 21291;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 55;
			StaminaBonus = 10;
			AgilityBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Embossed Plate Boots)
*
***************************************************************/

namespace Server.Items
{
	public class EmbossedPlateBoots : Item
	{
		public EmbossedPlateBoots() : base()
		{
			Id = 9973;
			Resistance[0] = 233;
			Bonding = 2;
			SellPrice = 3727;
			AvailableClasses = 0x7FFF;
			Model = 27349;
			ObjectClass = 4;
			SubClass = 4;
			Level = 42;
			ReqLevel = 40;
			Name = "Embossed Plate Boots";
			Name2 = "Embossed Plate Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 863;
			BuyPrice = 18637;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Gothic Sabatons)
*
***************************************************************/

namespace Server.Items
{
	public class GothicSabatons : Item
	{
		public GothicSabatons() : base()
		{
			Id = 10089;
			Resistance[0] = 300;
			Bonding = 2;
			SellPrice = 4749;
			AvailableClasses = 0x7FFF;
			Model = 27370;
			ObjectClass = 4;
			SubClass = 4;
			Level = 45;
			ReqLevel = 40;
			Name = "Gothic Sabatons";
			Name2 = "Gothic Sabatons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 864;
			BuyPrice = 23747;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Revenant Boots)
*
***************************************************************/

namespace Server.Items
{
	public class RevenantBoots : Item
	{
		public RevenantBoots() : base()
		{
			Id = 10131;
			Resistance[0] = 330;
			Bonding = 2;
			SellPrice = 7085;
			AvailableClasses = 0x7FFF;
			Model = 27425;
			ObjectClass = 4;
			SubClass = 4;
			Level = 50;
			ReqLevel = 45;
			Name = "Revenant Boots";
			Name2 = "Revenant Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 866;
			BuyPrice = 35428;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Templar Boots)
*
***************************************************************/

namespace Server.Items
{
	public class TemplarBoots : Item
	{
		public TemplarBoots() : base()
		{
			Id = 10167;
			Resistance[0] = 361;
			Bonding = 2;
			SellPrice = 9429;
			AvailableClasses = 0x7FFF;
			Model = 27405;
			ObjectClass = 4;
			SubClass = 4;
			Level = 55;
			ReqLevel = 50;
			Name = "Templar Boots";
			Name2 = "Templar Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 868;
			BuyPrice = 47147;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Overlord's Greaves)
*
***************************************************************/

namespace Server.Items
{
	public class OverlordsGreaves : Item
	{
		public OverlordsGreaves() : base()
		{
			Id = 10201;
			Resistance[0] = 318;
			Bonding = 2;
			SellPrice = 5960;
			AvailableClasses = 0x7FFF;
			Model = 27400;
			ObjectClass = 4;
			SubClass = 4;
			Level = 48;
			ReqLevel = 43;
			Name = "Overlord's Greaves";
			Name2 = "Overlord's Greaves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 865;
			BuyPrice = 29801;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Heavy Lamellar Boots)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyLamellarBoots : Item
	{
		public HeavyLamellarBoots() : base()
		{
			Id = 10238;
			Resistance[0] = 342;
			Bonding = 2;
			SellPrice = 7650;
			AvailableClasses = 0x7FFF;
			Model = 27380;
			ObjectClass = 4;
			SubClass = 4;
			Level = 52;
			ReqLevel = 47;
			Name = "Heavy Lamellar Boots";
			Name2 = "Heavy Lamellar Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 867;
			BuyPrice = 38250;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Emerald Sabatons)
*
***************************************************************/

namespace Server.Items
{
	public class EmeraldSabatons : Item
	{
		public EmeraldSabatons() : base()
		{
			Id = 10276;
			Resistance[0] = 367;
			Bonding = 2;
			SellPrice = 9847;
			AvailableClasses = 0x7FFF;
			Model = 27419;
			ObjectClass = 4;
			SubClass = 4;
			Level = 56;
			ReqLevel = 51;
			Name = "Emerald Sabatons";
			Name2 = "Emerald Sabatons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 868;
			BuyPrice = 49238;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Imbued Plate Greaves)
*
***************************************************************/

namespace Server.Items
{
	public class ImbuedPlateGreaves : Item
	{
		public ImbuedPlateGreaves() : base()
		{
			Id = 10371;
			Resistance[0] = 379;
			Bonding = 2;
			SellPrice = 11149;
			AvailableClasses = 0x7FFF;
			Model = 26354;
			ObjectClass = 4;
			SubClass = 4;
			Level = 58;
			ReqLevel = 53;
			Name = "Imbued Plate Greaves";
			Name2 = "Imbued Plate Greaves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 55747;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 55;
			StrBonus = 13;
			IqBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Commander's Boots)
*
***************************************************************/

namespace Server.Items
{
	public class CommandersBoots : Item
	{
		public CommandersBoots() : base()
		{
			Id = 10376;
			Resistance[0] = 392;
			Bonding = 2;
			SellPrice = 12519;
			AvailableClasses = 0x7FFF;
			Model = 26333;
			ObjectClass = 4;
			SubClass = 4;
			Level = 60;
			ReqLevel = 55;
			Name = "Commander's Boots";
			Name2 = "Commander's Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 869;
			BuyPrice = 62599;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Hyperion Greaves)
*
***************************************************************/

namespace Server.Items
{
	public class HyperionGreaves : Item
	{
		public HyperionGreaves() : base()
		{
			Id = 10385;
			Resistance[0] = 404;
			Bonding = 2;
			SellPrice = 13247;
			AvailableClasses = 0x7FFF;
			Model = 26341;
			ObjectClass = 4;
			SubClass = 4;
			Level = 62;
			ReqLevel = 57;
			Name = "Hyperion Greaves";
			Name2 = "Hyperion Greaves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 870;
			BuyPrice = 66239;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Steelsmith Greaves)
*
***************************************************************/

namespace Server.Items
{
	public class SteelsmithGreaves : Item
	{
		public SteelsmithGreaves() : base()
		{
			Id = 10707;
			Resistance[0] = 342;
			Bonding = 1;
			SellPrice = 7772;
			AvailableClasses = 0x7FFF;
			Model = 19742;
			ObjectClass = 4;
			SubClass = 4;
			Level = 52;
			Name = "Steelsmith Greaves";
			Name2 = "Steelsmith Greaves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 38862;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 55;
			StrBonus = 11;
			StaminaBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Shalehusk Boots)
*
***************************************************************/

namespace Server.Items
{
	public class ShalehuskBoots : Item
	{
		public ShalehuskBoots() : base()
		{
			Id = 11787;
			Resistance[0] = 417;
			Bonding = 1;
			SellPrice = 13732;
			AvailableClasses = 0x7FFF;
			Model = 28669;
			ObjectClass = 4;
			SubClass = 4;
			Level = 58;
			ReqLevel = 53;
			Name = "Shalehusk Boots";
			Name2 = "Shalehusk Boots";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 68664;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 65;
			SetSpell( 13670 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Eschewal Greaves)
*
***************************************************************/

namespace Server.Items
{
	public class EschewalGreaves : Item
	{
		public EschewalGreaves() : base()
		{
			Id = 11872;
			Resistance[0] = 354;
			Bonding = 1;
			SellPrice = 8566;
			AvailableClasses = 0x7FFF;
			Model = 28164;
			ObjectClass = 4;
			SubClass = 4;
			Level = 54;
			Name = "Eschewal Greaves";
			Name2 = "Eschewal Greaves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 42830;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 55;
			SetSpell( 13669 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Cragplate Greaves)
*
***************************************************************/

namespace Server.Items
{
	public class CragplateGreaves : Item
	{
		public CragplateGreaves() : base()
		{
			Id = 11919;
			Resistance[0] = 361;
			Bonding = 1;
			SellPrice = 9572;
			AvailableClasses = 0x7FFF;
			Model = 28136;
			ObjectClass = 4;
			SubClass = 4;
			Level = 55;
			Name = "Cragplate Greaves";
			Name2 = "Cragplate Greaves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 47862;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 55;
			StrBonus = 12;
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Shieldplate Sabatons)
*
***************************************************************/

namespace Server.Items
{
	public class ShieldplateSabatons : Item
	{
		public ShieldplateSabatons() : base()
		{
			Id = 12021;
			Resistance[0] = 354;
			Bonding = 1;
			SellPrice = 9327;
			AvailableClasses = 0x7FFF;
			Model = 23483;
			ObjectClass = 4;
			SubClass = 4;
			Level = 54;
			Name = "Shieldplate Sabatons";
			Name2 = "Shieldplate Sabatons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 46636;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 55;
			StrBonus = 12;
			StaminaBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Thorium Boots)
*
***************************************************************/

namespace Server.Items
{
	public class ThoriumBoots : Item
	{
		public ThoriumBoots() : base()
		{
			Id = 12409;
			Resistance[6] = 7;
			Resistance[0] = 367;
			Bonding = 2;
			SellPrice = 10336;
			AvailableClasses = 0x7FFF;
			Model = 25752;
			Resistance[2] = 7;
			Resistance[4] = 7;
			ObjectClass = 4;
			SubClass = 4;
			Level = 56;
			ReqLevel = 51;
			Name = "Thorium Boots";
			Name2 = "Thorium Boots";
			Resistance[3] = 7;
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 51682;
			Resistance[5] = 7;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Imperial Plate Boots)
*
***************************************************************/

namespace Server.Items
{
	public class ImperialPlateBoots : Item
	{
		public ImperialPlateBoots() : base()
		{
			Id = 12426;
			Resistance[0] = 386;
			Bonding = 2;
			SellPrice = 12062;
			AvailableClasses = 0x7FFF;
			Model = 24513;
			ObjectClass = 4;
			SubClass = 4;
			Level = 59;
			ReqLevel = 54;
			Name = "Imperial Plate Boots";
			Name2 = "Imperial Plate Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 60311;
			Sets = 321;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 55;
			StrBonus = 13;
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Battlechaser's Greaves)
*
***************************************************************/

namespace Server.Items
{
	public class BattlechasersGreaves : Item
	{
		public BattlechasersGreaves() : base()
		{
			Id = 12555;
			Resistance[0] = 397;
			Bonding = 2;
			SellPrice = 11406;
			AvailableClasses = 0x7FFF;
			Model = 27829;
			ObjectClass = 4;
			SubClass = 4;
			Level = 55;
			ReqLevel = 50;
			Name = "Battlechaser's Greaves";
			Name2 = "Battlechaser's Greaves";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 57032;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 65;
			AgilityBonus = 13;
			StrBonus = 14;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Runic Plate Boots)
*
***************************************************************/

namespace Server.Items
{
	public class RunicPlateBoots : Item
	{
		public RunicPlateBoots() : base()
		{
			Id = 12611;
			Resistance[0] = 492;
			Bonding = 2;
			SellPrice = 12293;
			AvailableClasses = 0x7FFF;
			Model = 23486;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 4;
			Level = 60;
			ReqLevel = 55;
			Name = "Runic Plate Boots";
			Name2 = "Runic Plate Boots";
			Resistance[3] = 10;
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 61468;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Obsidian Greaves)
*
***************************************************************/

namespace Server.Items
{
	public class ObsidianGreaves : Item
	{
		public ObsidianGreaves() : base()
		{
			Id = 13068;
			Resistance[0] = 257;
			Bonding = 2;
			SellPrice = 4785;
			AvailableClasses = 0x7FFF;
			Model = 28362;
			ObjectClass = 4;
			SubClass = 4;
			Level = 42;
			ReqLevel = 40;
			Name = "Obsidian Greaves";
			Name2 = "Obsidian Greaves";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 23927;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 65;
			AgilityBonus = 6;
			StrBonus = 10;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Sapphiron's Scale Boots)
*
***************************************************************/

namespace Server.Items
{
	public class SapphironsScaleBoots : Item
	{
		public SapphironsScaleBoots() : base()
		{
			Id = 13070;
			Resistance[0] = 417;
			Bonding = 2;
			SellPrice = 14087;
			AvailableClasses = 0x7FFF;
			Model = 28353;
			ObjectClass = 4;
			SubClass = 4;
			Level = 58;
			ReqLevel = 53;
			Name = "Sapphiron's Scale Boots";
			Name2 = "Sapphiron's Scale Boots";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 70437;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 65;
			AgilityBonus = 9;
			StrBonus = 14;
			StaminaBonus = 14;
		}
	}
}


/**************************************************************
*
*				(Ribsteel Footguards)
*
***************************************************************/

namespace Server.Items
{
	public class RibsteelFootguards : Item
	{
		public RibsteelFootguards() : base()
		{
			Id = 13259;
			Resistance[0] = 438;
			Bonding = 1;
			SellPrice = 16069;
			AvailableClasses = 0x7FFF;
			Model = 23856;
			ObjectClass = 4;
			SubClass = 4;
			Level = 61;
			ReqLevel = 56;
			Name = "Ribsteel Footguards";
			Name2 = "Ribsteel Footguards";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 80348;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 65;
			StrBonus = 10;
			StaminaBonus = 17;
			AgilityBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Master Cannoneer Boots)
*
***************************************************************/

namespace Server.Items
{
	public class MasterCannoneerBoots : Item
	{
		public MasterCannoneerBoots() : base()
		{
			Id = 13381;
			Resistance[0] = 438;
			Bonding = 1;
			SellPrice = 15433;
			AvailableClasses = 0x7FFF;
			Model = 24068;
			ObjectClass = 4;
			SubClass = 4;
			Level = 61;
			ReqLevel = 56;
			Name = "Master Cannoneer Boots";
			Name2 = "Master Cannoneer Boots";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 77167;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 65;
			StrBonus = 10;
			StaminaBonus = 21;
		}
	}
}


/**************************************************************
*
*				(Lavawalker Greaves)
*
***************************************************************/

namespace Server.Items
{
	public class LavawalkerGreaves : Item
	{
		public LavawalkerGreaves() : base()
		{
			Id = 13527;
			Resistance[0] = 404;
			Bonding = 1;
			SellPrice = 13149;
			AvailableClasses = 0x7FFF;
			Model = 24179;
			Resistance[2] = 20;
			ObjectClass = 4;
			SubClass = 4;
			Level = 62;
			ReqLevel = 57;
			Name = "Lavawalker Greaves";
			Name2 = "Lavawalker Greaves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 65746;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Corpselight Greaves)
*
***************************************************************/

namespace Server.Items
{
	public class CorpselightGreaves : Item
	{
		public CorpselightGreaves() : base()
		{
			Id = 14537;
			Resistance[0] = 445;
			Bonding = 1;
			SellPrice = 17001;
			AvailableClasses = 0x7FFF;
			Model = 25160;
			ObjectClass = 4;
			SubClass = 4;
			Level = 62;
			ReqLevel = 57;
			Name = "Corpselight Greaves";
			Name2 = "Corpselight Greaves";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 85008;
			Resistance[5] = 10;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 65;
			StaminaBonus = 22;
		}
	}
}


/**************************************************************
*
*				(Boots of Avoidance)
*
***************************************************************/

namespace Server.Items
{
	public class BootsOfAvoidance : Item
	{
		public BootsOfAvoidance() : base()
		{
			Id = 14549;
			Resistance[0] = 360;
			Bonding = 2;
			SellPrice = 7807;
			AvailableClasses = 0x7FFF;
			Model = 28276;
			ObjectClass = 4;
			SubClass = 4;
			Level = 45;
			ReqLevel = 40;
			Name = "Boots of Avoidance";
			Name2 = "Boots of Avoidance";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 39038;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 75;
			SetSpell( 13670 , 1 , 0 , -1 , 0 , -1 );
			AgilityBonus = 14;
			StaminaBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Deathbone Sabatons)
*
***************************************************************/

namespace Server.Items
{
	public class DeathboneSabatons : Item
	{
		public DeathboneSabatons() : base()
		{
			Id = 14621;
			Resistance[0] = 398;
			Bonding = 1;
			SellPrice = 12717;
			AvailableClasses = 0x7FFF;
			Model = 25227;
			ObjectClass = 4;
			SubClass = 4;
			Level = 61;
			ReqLevel = 56;
			Name = "Deathbone Sabatons";
			Name2 = "Deathbone Sabatons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 63588;
			Sets = 124;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 55;
			StaminaBonus = 12;
			IqBonus = 10;
			AgilityBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Symbolic Greaves)
*
***************************************************************/

namespace Server.Items
{
	public class SymbolicGreaves : Item
	{
		public SymbolicGreaves() : base()
		{
			Id = 14828;
			Resistance[0] = 233;
			Bonding = 2;
			SellPrice = 3772;
			AvailableClasses = 0x7FFF;
			Model = 26813;
			ObjectClass = 4;
			SubClass = 4;
			Level = 42;
			ReqLevel = 40;
			Name = "Symbolic Greaves";
			Name2 = "Symbolic Greaves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 18864;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 55;
			StrBonus = 9;
			StaminaBonus = 6;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Tyrant's Greaves)
*
***************************************************************/

namespace Server.Items
{
	public class TyrantsGreaves : Item
	{
		public TyrantsGreaves() : base()
		{
			Id = 14839;
			Resistance[0] = 294;
			Bonding = 2;
			SellPrice = 4701;
			AvailableClasses = 0x7FFF;
			Model = 26690;
			ObjectClass = 4;
			SubClass = 4;
			Level = 44;
			ReqLevel = 40;
			Name = "Tyrant's Greaves";
			Name2 = "Tyrant's Greaves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 23509;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 55;
			AgilityBonus = 4;
			StaminaBonus = 8;
			StrBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Sunscale Sabatons)
*
***************************************************************/

namespace Server.Items
{
	public class SunscaleSabatons : Item
	{
		public SunscaleSabatons() : base()
		{
			Id = 14848;
			Resistance[0] = 330;
			Bonding = 2;
			SellPrice = 6854;
			AvailableClasses = 0x7FFF;
			Model = 26822;
			ObjectClass = 4;
			SubClass = 4;
			Level = 50;
			ReqLevel = 45;
			Name = "Sunscale Sabatons";
			Name2 = "Sunscale Sabatons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 34271;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 55;
			StaminaBonus = 14;
			AgilityBonus = 3;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Vanguard Sabatons)
*
***************************************************************/

namespace Server.Items
{
	public class VanguardSabatons : Item
	{
		public VanguardSabatons() : base()
		{
			Id = 14857;
			Resistance[0] = 354;
			Bonding = 2;
			SellPrice = 9266;
			AvailableClasses = 0x7FFF;
			Model = 26850;
			ObjectClass = 4;
			SubClass = 4;
			Level = 54;
			ReqLevel = 49;
			Name = "Vanguard Sabatons";
			Name2 = "Vanguard Sabatons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 46332;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 55;
			StaminaBonus = 13;
			StrBonus = 8;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Warleader's Greaves)
*
***************************************************************/

namespace Server.Items
{
	public class WarleadersGreaves : Item
	{
		public WarleadersGreaves() : base()
		{
			Id = 14865;
			Resistance[0] = 392;
			Bonding = 2;
			SellPrice = 12018;
			AvailableClasses = 0x7FFF;
			Model = 26883;
			ObjectClass = 4;
			SubClass = 4;
			Level = 60;
			ReqLevel = 55;
			Name = "Warleader's Greaves";
			Name2 = "Warleader's Greaves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 60094;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 55;
			StaminaBonus = 16;
			IqBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Saltstone Sabatons)
*
***************************************************************/

namespace Server.Items
{
	public class SaltstoneSabatons : Item
	{
		public SaltstoneSabatons() : base()
		{
			Id = 14896;
			Resistance[0] = 182;
			Bonding = 2;
			SellPrice = 3418;
			AvailableClasses = 0x7FFF;
			Model = 26652;
			ObjectClass = 4;
			SubClass = 4;
			Level = 40;
			ReqLevel = 40;
			Name = "Saltstone Sabatons";
			Name2 = "Saltstone Sabatons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 863;
			BuyPrice = 17091;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Brutish Boots)
*
***************************************************************/

namespace Server.Items
{
	public class BrutishBoots : Item
	{
		public BrutishBoots() : base()
		{
			Id = 14911;
			Resistance[0] = 306;
			Bonding = 2;
			SellPrice = 5327;
			AvailableClasses = 0x7FFF;
			Model = 27905;
			ObjectClass = 4;
			SubClass = 4;
			Level = 46;
			ReqLevel = 41;
			Name = "Brutish Boots";
			Name2 = "Brutish Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 865;
			BuyPrice = 26637;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Jade Greaves)
*
***************************************************************/

namespace Server.Items
{
	public class JadeGreaves : Item
	{
		public JadeGreaves() : base()
		{
			Id = 14913;
			Resistance[0] = 324;
			Bonding = 2;
			SellPrice = 6697;
			AvailableClasses = 0x7FFF;
			Model = 26799;
			ObjectClass = 4;
			SubClass = 4;
			Level = 49;
			ReqLevel = 44;
			Name = "Jade Greaves";
			Name2 = "Jade Greaves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 866;
			BuyPrice = 33487;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Lofty Sabatons)
*
***************************************************************/

namespace Server.Items
{
	public class LoftySabatons : Item
	{
		public LoftySabatons() : base()
		{
			Id = 14922;
			Resistance[0] = 348;
			Bonding = 2;
			SellPrice = 8273;
			AvailableClasses = 0x7FFF;
			Model = 26874;
			ObjectClass = 4;
			SubClass = 4;
			Level = 53;
			ReqLevel = 48;
			Name = "Lofty Sabatons";
			Name2 = "Lofty Sabatons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 867;
			BuyPrice = 41366;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Heroic Greaves)
*
***************************************************************/

namespace Server.Items
{
	public class HeroicGreaves : Item
	{
		public HeroicGreaves() : base()
		{
			Id = 14932;
			Resistance[0] = 379;
			Bonding = 2;
			SellPrice = 11784;
			AvailableClasses = 0x7FFF;
			Model = 27829;
			ObjectClass = 4;
			SubClass = 4;
			Level = 58;
			ReqLevel = 53;
			Name = "Heroic Greaves";
			Name2 = "Heroic Greaves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 869;
			BuyPrice = 58922;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Warbringer's Sabatons)
*
***************************************************************/

namespace Server.Items
{
	public class WarbringersSabatons : Item
	{
		public WarbringersSabatons() : base()
		{
			Id = 14940;
			Resistance[0] = 262;
			Bonding = 2;
			SellPrice = 4059;
			AvailableClasses = 0x7FFF;
			Model = 26643;
			ObjectClass = 4;
			SubClass = 4;
			Level = 43;
			ReqLevel = 40;
			Name = "Warbringer's Sabatons";
			Name2 = "Warbringer's Sabatons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 864;
			BuyPrice = 20297;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Bloodforged Sabatons)
*
***************************************************************/

namespace Server.Items
{
	public class BloodforgedSabatons : Item
	{
		public BloodforgedSabatons() : base()
		{
			Id = 14951;
			Resistance[0] = 312;
			Bonding = 2;
			SellPrice = 5902;
			AvailableClasses = 0x7FFF;
			Model = 26842;
			ObjectClass = 4;
			SubClass = 4;
			Level = 47;
			ReqLevel = 42;
			Name = "Bloodforged Sabatons";
			Name2 = "Bloodforged Sabatons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 865;
			BuyPrice = 29511;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(High Chief's Sabatons)
*
***************************************************************/

namespace Server.Items
{
	public class HighChiefsSabatons : Item
	{
		public HighChiefsSabatons() : base()
		{
			Id = 14957;
			Resistance[0] = 336;
			Bonding = 2;
			SellPrice = 7223;
			AvailableClasses = 0x7FFF;
			Model = 26833;
			ObjectClass = 4;
			SubClass = 4;
			Level = 51;
			ReqLevel = 46;
			Name = "High Chief's Sabatons";
			Name2 = "High Chief's Sabatons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 866;
			BuyPrice = 36119;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Glorious Sabatons)
*
***************************************************************/

namespace Server.Items
{
	public class GloriousSabatons : Item
	{
		public GloriousSabatons() : base()
		{
			Id = 14972;
			Resistance[0] = 367;
			Bonding = 2;
			SellPrice = 10486;
			AvailableClasses = 0x7FFF;
			Model = 26862;
			ObjectClass = 4;
			SubClass = 4;
			Level = 56;
			ReqLevel = 51;
			Name = "Glorious Sabatons";
			Name2 = "Glorious Sabatons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 868;
			BuyPrice = 52430;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Exalted Sabatons)
*
***************************************************************/

namespace Server.Items
{
	public class ExaltedSabatons : Item
	{
		public ExaltedSabatons() : base()
		{
			Id = 14978;
			Resistance[0] = 410;
			Bonding = 2;
			SellPrice = 13913;
			AvailableClasses = 0x7FFF;
			Model = 27832;
			ObjectClass = 4;
			SubClass = 4;
			Level = 63;
			ReqLevel = 58;
			Name = "Exalted Sabatons";
			Name2 = "Exalted Sabatons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 870;
			BuyPrice = 69566;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Knight-Lieutenant's Plate Boots)
*
***************************************************************/

namespace Server.Items
{
	public class KnightLieutenantsPlateBoots : Item
	{
		public KnightLieutenantsPlateBoots() : base()
		{
			Id = 16405;
			Resistance[0] = 452;
			Bonding = 1;
			SellPrice = 8286;
			AvailableClasses = 0x01;
			Model = 26752;
			ObjectClass = 4;
			SubClass = 4;
			Level = 63;
			ReqLevel = 58;
			Name = "Knight-Lieutenant's Plate Boots";
			Name2 = "Knight-Lieutenant's Plate Boots";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 41433;
			Sets = 282;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			MaxCount = 1;
			Material = 6;
			Durability = 65;
			Flags = 32768;
			StaminaBonus = 23;
			StrBonus = 8;
			AgilityBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Knight-Lieutenant's Lamellar Sabatons)
*
***************************************************************/

namespace Server.Items
{
	public class KnightLieutenantsLamellarSabatons : Item
	{
		public KnightLieutenantsLamellarSabatons() : base()
		{
			Id = 16409;
			Resistance[0] = 452;
			Bonding = 1;
			SellPrice = 8413;
			AvailableClasses = 0x02;
			Model = 31082;
			ObjectClass = 4;
			SubClass = 4;
			Level = 63;
			ReqLevel = 58;
			Name = "Knight-Lieutenant's Lamellar Sabatons";
			Name2 = "Knight-Lieutenant's Lamellar Sabatons";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 42068;
			Sets = 401;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			MaxCount = 1;
			Material = 6;
			Durability = 65;
			Flags = 32768;
			StaminaBonus = 16;
			StrBonus = 15;
			SpiritBonus = 7;
			AgilityBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Marshal's Lamellar Boots)
*
***************************************************************/

namespace Server.Items
{
	public class MarshalsLamellarBoots : Item
	{
		public MarshalsLamellarBoots() : base()
		{
			Id = 16472;
			Resistance[0] = 507;
			Bonding = 1;
			SellPrice = 12839;
			AvailableClasses = 0x02;
			Model = 30319;
			ObjectClass = 4;
			SubClass = 4;
			Level = 65;
			ReqLevel = 60;
			Name = "Marshal's Lamellar Boots";
			Name2 = "Marshal's Lamellar Boots";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 64195;
			Sets = 402;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			MaxCount = 1;
			Material = 6;
			Durability = 75;
			Flags = 32768;
			StaminaBonus = 26;
			StrBonus = 15;
			SpiritBonus = 8;
			AgilityBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Marshal's Plate Boots)
*
***************************************************************/

namespace Server.Items
{
	public class MarshalsPlateBoots : Item
	{
		public MarshalsPlateBoots() : base()
		{
			Id = 16483;
			Resistance[0] = 507;
			Bonding = 1;
			SellPrice = 12418;
			AvailableClasses = 0x01;
			Model = 30319;
			ObjectClass = 4;
			SubClass = 4;
			Level = 65;
			ReqLevel = 60;
			Name = "Marshal's Plate Boots";
			Name2 = "Marshal's Plate Boots";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 62094;
			Sets = 384;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			MaxCount = 1;
			Material = 6;
			Durability = 75;
			Flags = 32768;
			StaminaBonus = 26;
			StrBonus = 15;
			AgilityBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Blood Guard's Plate Boots)
*
***************************************************************/

namespace Server.Items
{
	public class BloodGuardsPlateBoots : Item
	{
		public BloodGuardsPlateBoots() : base()
		{
			Id = 16509;
			Resistance[0] = 452;
			Bonding = 1;
			SellPrice = 8866;
			AvailableClasses = 0x01;
			Model = 31050;
			ObjectClass = 4;
			SubClass = 4;
			Level = 63;
			ReqLevel = 58;
			Name = "Blood Guard's Plate Boots";
			Name2 = "Blood Guard's Plate Boots";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 44331;
			Sets = 281;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			MaxCount = 1;
			Material = 6;
			Durability = 65;
			Flags = 32768;
			StaminaBonus = 23;
			StrBonus = 8;
			AgilityBonus = 5;
		}
	}
}


/**************************************************************
*
*				(General's Plate Boots)
*
***************************************************************/

namespace Server.Items
{
	public class GeneralsPlateBoots : Item
	{
		public GeneralsPlateBoots() : base()
		{
			Id = 16545;
			Resistance[0] = 507;
			Bonding = 1;
			SellPrice = 12842;
			AvailableClasses = 0x01;
			Model = 30370;
			ObjectClass = 4;
			SubClass = 4;
			Level = 65;
			ReqLevel = 60;
			Name = "General's Plate Boots";
			Name2 = "General's Plate Boots";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 64214;
			Sets = 383;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			MaxCount = 1;
			Material = 6;
			Durability = 75;
			Flags = 32768;
			StaminaBonus = 26;
			StrBonus = 15;
			AgilityBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Lightforge Boots)
*
***************************************************************/

namespace Server.Items
{
	public class LightforgeBoots : Item
	{
		public LightforgeBoots() : base()
		{
			Id = 16725;
			Resistance[0] = 424;
			Bonding = 1;
			SellPrice = 13688;
			AvailableClasses = 0x7FFF;
			Model = 29967;
			ObjectClass = 4;
			SubClass = 4;
			Level = 59;
			ReqLevel = 54;
			Name = "Lightforge Boots";
			Name2 = "Lightforge Boots";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 68444;
			Sets = 188;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 65;
			StaminaBonus = 18;
			IqBonus = 9;
			StrBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Boots of Valor)
*
***************************************************************/

namespace Server.Items
{
	public class BootsOfValor : Item
	{
		public BootsOfValor() : base()
		{
			Id = 16734;
			Resistance[0] = 424;
			Bonding = 1;
			SellPrice = 14536;
			AvailableClasses = 0x7FFF;
			Model = 29960;
			ObjectClass = 4;
			SubClass = 4;
			Level = 59;
			ReqLevel = 54;
			Name = "Boots of Valor";
			Name2 = "Boots of Valor";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 72680;
			Sets = 189;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 65;
			StaminaBonus = 20;
			StrBonus = 8;
			AgilityBonus = 4;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Lawbringer Boots)
*
***************************************************************/

namespace Server.Items
{
	public class LawbringerBoots : Item
	{
		public LawbringerBoots() : base()
		{
			Id = 16859;
			Resistance[0] = 515;
			Bonding = 1;
			SellPrice = 25778;
			AvailableClasses = 0x02;
			Model = 31354;
			ObjectClass = 4;
			SubClass = 4;
			Level = 66;
			ReqLevel = 60;
			Name = "Lawbringer Boots";
			Name2 = "Lawbringer Boots";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 128891;
			Sets = 208;
			Resistance[5] = 7;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 75;
			SetSpell( 21624 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 9406 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 13;
			IqBonus = 10;
			StaminaBonus = 20;
			StrBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Sabatons of Might)
*
***************************************************************/

namespace Server.Items
{
	public class SabatonsOfMight : Item
	{
		public SabatonsOfMight() : base()
		{
			Id = 16862;
			Resistance[0] = 515;
			Bonding = 1;
			SellPrice = 26778;
			AvailableClasses = 0x01;
			Model = 31025;
			ObjectClass = 4;
			SubClass = 4;
			Level = 66;
			ReqLevel = 60;
			Name = "Sabatons of Might";
			Name2 = "Sabatons of Might";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 133891;
			Sets = 209;
			Resistance[5] = 7;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 75;
			SetSpell( 13383 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 26;
			StrBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Judgement Sabatons)
*
***************************************************************/

namespace Server.Items
{
	public class JudgementSabatons : Item
	{
		public JudgementSabatons() : base()
		{
			Id = 16957;
			Resistance[0] = 589;
			Bonding = 1;
			SellPrice = 43944;
			AvailableClasses = 0x02;
			Model = 29879;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 4;
			Level = 76;
			ReqLevel = 60;
			Name = "Judgement Sabatons";
			Name2 = "Judgement Sabatons";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 219723;
			Sets = 217;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 75;
			SetSpell( 9316 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 15;
			IqBonus = 12;
			StaminaBonus = 23;
		}
	}
}


/**************************************************************
*
*				(Sabatons of Wrath)
*
***************************************************************/

namespace Server.Items
{
	public class SabatonsOfWrath : Item
	{
		public SabatonsOfWrath() : base()
		{
			Id = 16965;
			Resistance[0] = 589;
			Bonding = 1;
			SellPrice = 45221;
			AvailableClasses = 0x01;
			Model = 29863;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 4;
			Level = 76;
			ReqLevel = 60;
			Name = "Sabatons of Wrath";
			Name2 = "Sabatons of Wrath";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 226108;
			Sets = 218;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 75;
			SetSpell( 23515 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 13385 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 30;
			StrBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Jungle Boots)
*
***************************************************************/

namespace Server.Items
{
	public class JungleBoots : Item
	{
		public JungleBoots() : base()
		{
			Id = 17688;
			Resistance[0] = 182;
			Bonding = 1;
			SellPrice = 3155;
			AvailableClasses = 0x7FFF;
			Model = 29693;
			ObjectClass = 4;
			SubClass = 4;
			Level = 40;
			Name = "Jungle Boots";
			Name2 = "Jungle Boots";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 15776;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 55;
			StaminaBonus = 4;
			StrBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Grimy Metal Boots)
*
***************************************************************/

namespace Server.Items
{
	public class GrimyMetalBoots : Item
	{
		public GrimyMetalBoots() : base()
		{
			Id = 18521;
			Resistance[0] = 552;
			Bonding = 1;
			SellPrice = 17606;
			AvailableClasses = 0x7FFF;
			Model = 30854;
			ObjectClass = 4;
			SubClass = 4;
			Level = 63;
			ReqLevel = 58;
			Name = "Grimy Metal Boots";
			Name2 = "Grimy Metal Boots";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 88032;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 65;
			SetSpell( 13669 , 1 , 0 , -1 , 0 , -1 );
			StrBonus = 17;
		}
	}
}


/**************************************************************
*
*				(Death Knight Sabatons)
*
***************************************************************/

namespace Server.Items
{
	public class DeathKnightSabatons : Item
	{
		public DeathKnightSabatons() : base()
		{
			Id = 18692;
			Resistance[0] = 424;
			Bonding = 1;
			SellPrice = 14375;
			AvailableClasses = 0x7FFF;
			Model = 31133;
			ObjectClass = 4;
			SubClass = 4;
			Level = 59;
			ReqLevel = 54;
			Name = "Death Knight Sabatons";
			Name2 = "Death Knight Sabatons";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 71877;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 65;
			StrBonus = 11;
			StaminaBonus = 11;
			SpiritBonus = 11;
			IqBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Core Forged Greaves)
*
***************************************************************/

namespace Server.Items
{
	public class CoreForgedGreaves : Item
	{
		public CoreForgedGreaves() : base()
		{
			Id = 18806;
			Resistance[0] = 634;
			Bonding = 1;
			SellPrice = 33761;
			AvailableClasses = 0x7FFF;
			Model = 31271;
			Resistance[2] = 12;
			ObjectClass = 4;
			SubClass = 4;
			Level = 70;
			ReqLevel = 60;
			Name = "Core Forged Greaves";
			Name2 = "Core Forged Greaves";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 168806;
			Resistance[5] = 8;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 75;
			SetSpell( 7517 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 28;
		}
	}
}


/**************************************************************
*
*				(Magma Tempered Boots)
*
***************************************************************/

namespace Server.Items
{
	public class MagmaTemperedBoots : Item
	{
		public MagmaTemperedBoots() : base()
		{
			Id = 18824;
			Resistance[0] = 544;
			Bonding = 1;
			SellPrice = 33518;
			AvailableClasses = 0x7FFF;
			Model = 31295;
			Resistance[2] = 8;
			ObjectClass = 4;
			SubClass = 4;
			Level = 70;
			ReqLevel = 60;
			Name = "Magma Tempered Boots";
			Name2 = "Magma Tempered Boots";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 167591;
			InventoryType = InventoryTypes.Feet;
			Stackable = 1;
			Material = 6;
			Durability = 75;
			SetSpell( 9406 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 19;
			SpiritBonus = 18;
			IqBonus = 12;
		}
	}
}


