/**************************************************************
*
*		Made by fulgas (fulgas@gmail.com)
*
*  WowwoW Item Designer ( 2005/8/23 - 10:11:26 )
*
***************************************************************/

using System;
using System.Collections;

/***************************************************************/

/**************************************************************
*
*				(Light Plate Belt)
*
***************************************************************/

namespace Server.Items
{
	public class LightPlateBelt : Item
	{
		public LightPlateBelt() : base()
		{
			Id = 8081;
			Resistance[0] = 275;
			SellPrice = 2834;
			AvailableClasses = 0x7FFF;
			Model = 28399;
			ObjectClass = 4;
			SubClass = 4;
			Level = 57;
			ReqLevel = 52;
			Name = "Light Plate Belt";
			Name2 = "Light Plate Belt";
			AvailableRaces = 0x1FF;
			BuyPrice = 14172;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Platemail Belt)
*
***************************************************************/

namespace Server.Items
{
	public class PlatemailBelt : Item
	{
		public PlatemailBelt() : base()
		{
			Id = 8088;
			Resistance[0] = 257;
			SellPrice = 2667;
			AvailableClasses = 0x7FFF;
			Model = 28395;
			ObjectClass = 4;
			SubClass = 4;
			Level = 50;
			ReqLevel = 45;
			Name = "Platemail Belt";
			Name2 = "Platemail Belt";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 13335;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Chromite Girdle)
*
***************************************************************/

namespace Server.Items
{
	public class ChromiteGirdle : Item
	{
		public ChromiteGirdle() : base()
		{
			Id = 8140;
			Resistance[0] = 215;
			Bonding = 2;
			SellPrice = 2837;
			AvailableClasses = 0x7FFF;
			Model = 27332;
			ObjectClass = 4;
			SubClass = 4;
			Level = 43;
			ReqLevel = 40;
			Name = "Chromite Girdle";
			Name2 = "Chromite Girdle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 14188;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
			StrBonus = 9;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Jouster's Girdle)
*
***************************************************************/

namespace Server.Items
{
	public class JoustersGirdle : Item
	{
		public JoustersGirdle() : base()
		{
			Id = 8159;
			Resistance[0] = 149;
			Bonding = 2;
			SellPrice = 2244;
			AvailableClasses = 0x7FFF;
			Model = 27342;
			ObjectClass = 4;
			SubClass = 4;
			Level = 40;
			ReqLevel = 40;
			Name = "Jouster's Girdle";
			Name2 = "Jouster's Girdle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11221;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
			StrBonus = 10;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Valorous Girdle)
*
***************************************************************/

namespace Server.Items
{
	public class ValorousGirdle : Item
	{
		public ValorousGirdle() : base()
		{
			Id = 8277;
			Resistance[0] = 251;
			Bonding = 2;
			SellPrice = 3625;
			AvailableClasses = 0x7FFF;
			Model = 27375;
			ObjectClass = 4;
			SubClass = 4;
			Level = 46;
			ReqLevel = 41;
			Name = "Valorous Girdle";
			Name2 = "Valorous Girdle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 18128;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
			StrBonus = 13;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Alabaster Plate Girdle)
*
***************************************************************/

namespace Server.Items
{
	public class AlabasterPlateGirdle : Item
	{
		public AlabasterPlateGirdle() : base()
		{
			Id = 8315;
			Resistance[0] = 280;
			Bonding = 2;
			SellPrice = 5061;
			AvailableClasses = 0x7FFF;
			Model = 27391;
			ObjectClass = 4;
			SubClass = 4;
			Level = 52;
			ReqLevel = 47;
			Name = "Alabaster Plate Girdle";
			Name2 = "Alabaster Plate Girdle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 25306;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
			StrBonus = 15;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Field Plate Girdle)
*
***************************************************************/

namespace Server.Items
{
	public class FieldPlateGirdle : Item
	{
		public FieldPlateGirdle() : base()
		{
			Id = 9288;
			Resistance[0] = 169;
			Bonding = 2;
			SellPrice = 2414;
			AvailableClasses = 0x7FFF;
			Model = 27359;
			ObjectClass = 4;
			SubClass = 4;
			Level = 41;
			ReqLevel = 40;
			Name = "Field Plate Girdle";
			Name2 = "Field Plate Girdle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 947;
			BuyPrice = 12074;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Embossed Plate Girdle)
*
***************************************************************/

namespace Server.Items
{
	public class EmbossedPlateGirdle : Item
	{
		public EmbossedPlateGirdle() : base()
		{
			Id = 9968;
			Resistance[0] = 191;
			Bonding = 2;
			SellPrice = 2695;
			AvailableClasses = 0x7FFF;
			Model = 27352;
			ObjectClass = 4;
			SubClass = 4;
			Level = 42;
			ReqLevel = 40;
			Name = "Embossed Plate Girdle";
			Name2 = "Embossed Plate Girdle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 947;
			BuyPrice = 13476;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Gothic Plate Girdle)
*
***************************************************************/

namespace Server.Items
{
	public class GothicPlateGirdle : Item
	{
		public GothicPlateGirdle() : base()
		{
			Id = 10088;
			Resistance[0] = 246;
			Bonding = 2;
			SellPrice = 3154;
			AvailableClasses = 0x7FFF;
			Model = 27365;
			ObjectClass = 4;
			SubClass = 4;
			Level = 45;
			ReqLevel = 40;
			Name = "Gothic Plate Girdle";
			Name2 = "Gothic Plate Girdle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 948;
			BuyPrice = 15772;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Revenant Girdle)
*
***************************************************************/

namespace Server.Items
{
	public class RevenantGirdle : Item
	{
		public RevenantGirdle() : base()
		{
			Id = 10130;
			Resistance[0] = 270;
			Bonding = 2;
			SellPrice = 4706;
			AvailableClasses = 0x7FFF;
			Model = 27429;
			ObjectClass = 4;
			SubClass = 4;
			Level = 50;
			ReqLevel = 45;
			Name = "Revenant Girdle";
			Name2 = "Revenant Girdle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 950;
			BuyPrice = 23531;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Templar Girdle)
*
***************************************************************/

namespace Server.Items
{
	public class TemplarGirdle : Item
	{
		public TemplarGirdle() : base()
		{
			Id = 10166;
			Resistance[0] = 290;
			Bonding = 2;
			SellPrice = 5908;
			AvailableClasses = 0x7FFF;
			Model = 27411;
			ObjectClass = 4;
			SubClass = 4;
			Level = 54;
			ReqLevel = 49;
			Name = "Templar Girdle";
			Name2 = "Templar Girdle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 951;
			BuyPrice = 29542;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Overlord's Girdle)
*
***************************************************************/

namespace Server.Items
{
	public class OverlordsGirdle : Item
	{
		public OverlordsGirdle() : base()
		{
			Id = 10206;
			Resistance[0] = 260;
			Bonding = 2;
			SellPrice = 4048;
			AvailableClasses = 0x7FFF;
			Model = 27399;
			ObjectClass = 4;
			SubClass = 4;
			Level = 48;
			ReqLevel = 43;
			Name = "Overlord's Girdle";
			Name2 = "Overlord's Girdle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 949;
			BuyPrice = 20243;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Heavy Lamellar Girdle)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyLamellarGirdle : Item
	{
		public HeavyLamellarGirdle() : base()
		{
			Id = 10243;
			Resistance[0] = 275;
			Bonding = 2;
			SellPrice = 5035;
			AvailableClasses = 0x7FFF;
			Model = 27382;
			ObjectClass = 4;
			SubClass = 4;
			Level = 51;
			ReqLevel = 46;
			Name = "Heavy Lamellar Girdle";
			Name2 = "Heavy Lamellar Girdle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 950;
			BuyPrice = 25179;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Emerald Girdle)
*
***************************************************************/

namespace Server.Items
{
	public class EmeraldGirdle : Item
	{
		public EmeraldGirdle() : base()
		{
			Id = 10278;
			Resistance[0] = 295;
			Bonding = 2;
			SellPrice = 6239;
			AvailableClasses = 0x7FFF;
			Model = 27418;
			ObjectClass = 4;
			SubClass = 4;
			Level = 55;
			ReqLevel = 50;
			Name = "Emerald Girdle";
			Name2 = "Emerald Girdle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 952;
			BuyPrice = 31197;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Imbued Plate Girdle)
*
***************************************************************/

namespace Server.Items
{
	public class ImbuedPlateGirdle : Item
	{
		public ImbuedPlateGirdle() : base()
		{
			Id = 10370;
			Resistance[0] = 305;
			Bonding = 2;
			SellPrice = 6985;
			AvailableClasses = 0x7FFF;
			Model = 26353;
			ObjectClass = 4;
			SubClass = 4;
			Level = 57;
			ReqLevel = 52;
			Name = "Imbued Plate Girdle";
			Name2 = "Imbued Plate Girdle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 34929;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
			StrBonus = 13;
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Commander's Girdle)
*
***************************************************************/

namespace Server.Items
{
	public class CommandersGirdle : Item
	{
		public CommandersGirdle() : base()
		{
			Id = 10381;
			Resistance[0] = 315;
			Bonding = 2;
			SellPrice = 8094;
			AvailableClasses = 0x7FFF;
			Model = 26335;
			ObjectClass = 4;
			SubClass = 4;
			Level = 59;
			ReqLevel = 54;
			Name = "Commander's Girdle";
			Name2 = "Commander's Girdle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 953;
			BuyPrice = 40471;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Hyperion Girdle)
*
***************************************************************/

namespace Server.Items
{
	public class HyperionGirdle : Item
	{
		public HyperionGirdle() : base()
		{
			Id = 10387;
			Resistance[0] = 326;
			Bonding = 2;
			SellPrice = 8475;
			AvailableClasses = 0x7FFF;
			Model = 26340;
			ObjectClass = 4;
			SubClass = 4;
			Level = 61;
			ReqLevel = 56;
			Name = "Hyperion Girdle";
			Name2 = "Hyperion Girdle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 954;
			BuyPrice = 42379;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Atal'ai Girdle)
*
***************************************************************/

namespace Server.Items
{
	public class AtalaiGirdle : Item
	{
		public AtalaiGirdle() : base()
		{
			Id = 10788;
			Resistance[0] = 280;
			Bonding = 1;
			SellPrice = 5338;
			AvailableClasses = 0x7FFF;
			Model = 19996;
			ObjectClass = 4;
			SubClass = 4;
			Level = 52;
			ReqLevel = 47;
			Name = "Atal'ai Girdle";
			Name2 = "Atal'ai Girdle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 951;
			BuyPrice = 26693;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Atal'alarion's Tusk Ring)
*
***************************************************************/

namespace Server.Items
{
	public class AtalalarionsTuskRing : Item
	{
		public AtalalarionsTuskRing() : base()
		{
			Id = 10798;
			Resistance[0] = 302;
			Bonding = 1;
			SellPrice = 6263;
			AvailableClasses = 0x7FFF;
			Model = 28640;
			ObjectClass = 4;
			SubClass = 4;
			Level = 51;
			ReqLevel = 46;
			Name = "Atal'alarion's Tusk Ring";
			Name2 = "Atal'alarion's Tusk Ring";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 31319;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 5;
			Durability = 45;
			StrBonus = 18;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Stonewall Girdle)
*
***************************************************************/

namespace Server.Items
{
	public class StonewallGirdle : Item
	{
		public StonewallGirdle() : base()
		{
			Id = 11703;
			Resistance[0] = 455;
			Bonding = 1;
			SellPrice = 6148;
			AvailableClasses = 0x7FFF;
			Model = 28686;
			ObjectClass = 4;
			SubClass = 4;
			Level = 55;
			ReqLevel = 50;
			Name = "Stonewall Girdle";
			Name2 = "Stonewall Girdle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 30743;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Stalwart Clutch)
*
***************************************************************/

namespace Server.Items
{
	public class StalwartClutch : Item
	{
		public StalwartClutch() : base()
		{
			Id = 12115;
			Resistance[0] = 300;
			Bonding = 1;
			SellPrice = 7012;
			AvailableClasses = 0x7FFF;
			Model = 28224;
			ObjectClass = 4;
			SubClass = 4;
			Level = 56;
			Name = "Stalwart Clutch";
			Name2 = "Stalwart Clutch";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 35060;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
			SetSpell( 13387 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Thorium Belt)
*
***************************************************************/

namespace Server.Items
{
	public class ThoriumBelt : Item
	{
		public ThoriumBelt() : base()
		{
			Id = 12406;
			Resistance[6] = 6;
			Resistance[0] = 270;
			Bonding = 2;
			SellPrice = 4636;
			AvailableClasses = 0x7FFF;
			Model = 22550;
			Resistance[2] = 6;
			Resistance[4] = 6;
			ObjectClass = 4;
			SubClass = 4;
			Level = 50;
			ReqLevel = 45;
			Name = "Thorium Belt";
			Name2 = "Thorium Belt";
			Resistance[3] = 6;
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 23183;
			Resistance[5] = 6;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Imperial Plate Belt)
*
***************************************************************/

namespace Server.Items
{
	public class ImperialPlateBelt : Item
	{
		public ImperialPlateBelt() : base()
		{
			Id = 12424;
			Resistance[0] = 285;
			Bonding = 2;
			SellPrice = 5533;
			AvailableClasses = 0x7FFF;
			Model = 24514;
			ObjectClass = 4;
			SubClass = 4;
			Level = 53;
			ReqLevel = 47;
			Name = "Imperial Plate Belt";
			Name2 = "Imperial Plate Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 27665;
			Sets = 321;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
			StrBonus = 12;
			StaminaBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Girdle of Uther)
*
***************************************************************/

namespace Server.Items
{
	public class GirdleOfUther : Item
	{
		public GirdleOfUther() : base()
		{
			Id = 13077;
			Resistance[0] = 336;
			Bonding = 2;
			SellPrice = 8226;
			AvailableClasses = 0x7FFF;
			Model = 28364;
			ObjectClass = 4;
			SubClass = 4;
			Level = 57;
			ReqLevel = 52;
			Name = "Girdle of Uther";
			Name2 = "Girdle of Uther";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 41132;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 6;
			Durability = 45;
			StrBonus = 9;
			StaminaBonus = 10;
			IqBonus = 10;
			SpiritBonus = 9;
			AgilityBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Brigam Girdle)
*
***************************************************************/

namespace Server.Items
{
	public class BrigamGirdle : Item
	{
		public BrigamGirdle() : base()
		{
			Id = 13142;
			Resistance[0] = 369;
			Bonding = 1;
			SellPrice = 11641;
			AvailableClasses = 0x7FFF;
			Model = 23628;
			ObjectClass = 4;
			SubClass = 4;
			Level = 63;
			ReqLevel = 58;
			Name = "Brigam Girdle";
			Name2 = "Brigam Girdle";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 58209;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 6;
			Durability = 45;
			StrBonus = 15;
			StaminaBonus = 16;
			IqBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Enormous Ogre Belt)
*
***************************************************************/

namespace Server.Items
{
	public class EnormousOgreBelt : Item
	{
		public EnormousOgreBelt() : base()
		{
			Id = 13145;
			Resistance[0] = 164;
			Bonding = 2;
			SellPrice = 2704;
			AvailableClasses = 0x7FFF;
			Model = 28356;
			ObjectClass = 4;
			SubClass = 4;
			Level = 40;
			ReqLevel = 40;
			Name = "Enormous Ogre Belt";
			Name2 = "Enormous Ogre Belt";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 13522;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 6;
			Durability = 45;
			StrBonus = 12;
			StaminaBonus = 5;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Rainbow Girdle)
*
***************************************************************/

namespace Server.Items
{
	public class RainbowGirdle : Item
	{
		public RainbowGirdle() : base()
		{
			Id = 13384;
			Resistance[0] = 341;
			Bonding = 1;
			SellPrice = 8988;
			AvailableClasses = 0x7FFF;
			Model = 24071;
			ObjectClass = 4;
			SubClass = 4;
			Level = 58;
			ReqLevel = 53;
			Name = "Rainbow Girdle";
			Name2 = "Rainbow Girdle";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 44941;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 6;
			Durability = 45;
			StrBonus = -10;
			StaminaBonus = 12;
			IqBonus = 12;
			SpiritBonus = 12;
			AgilityBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Handcrafted Mastersmith Girdle)
*
***************************************************************/

namespace Server.Items
{
	public class HandcraftedMastersmithGirdle : Item
	{
		public HandcraftedMastersmithGirdle() : base()
		{
			Id = 13502;
			Resistance[0] = 519;
			Bonding = 1;
			SellPrice = 11987;
			AvailableClasses = 0x7FFF;
			Model = 24164;
			ObjectClass = 4;
			SubClass = 4;
			Level = 63;
			ReqLevel = 58;
			Name = "Handcrafted Mastersmith Girdle";
			Name2 = "Handcrafted Mastersmith Girdle";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 59937;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 6;
			Durability = 45;
			StrBonus = 11;
			StaminaBonus = 10;
			AgilityBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Omokk's Girth Restrainer)
*
***************************************************************/

namespace Server.Items
{
	public class OmokksGirthRestrainer : Item
	{
		public OmokksGirthRestrainer() : base()
		{
			Id = 13959;
			Resistance[0] = 353;
			Bonding = 1;
			SellPrice = 9542;
			AvailableClasses = 0x7FFF;
			Model = 30535;
			ObjectClass = 4;
			SubClass = 4;
			Level = 60;
			Name = "Omokk's Girth Restrainer";
			Name2 = "Omokk's Girth Restrainer";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 47712;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 6;
			Durability = 45;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			StrBonus = 15;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Deathbone Girdle)
*
***************************************************************/

namespace Server.Items
{
	public class DeathboneGirdle : Item
	{
		public DeathboneGirdle() : base()
		{
			Id = 14620;
			Resistance[0] = 326;
			Bonding = 1;
			SellPrice = 8446;
			AvailableClasses = 0x7FFF;
			Model = 25225;
			ObjectClass = 4;
			SubClass = 4;
			Level = 61;
			ReqLevel = 56;
			Name = "Deathbone Girdle";
			Name2 = "Deathbone Girdle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 42231;
			Sets = 124;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
			StrBonus = 15;
			StaminaBonus = 8;
			AgilityBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Symbolic Belt)
*
***************************************************************/

namespace Server.Items
{
	public class SymbolicBelt : Item
	{
		public SymbolicBelt() : base()
		{
			Id = 14827;
			Resistance[0] = 169;
			Bonding = 2;
			SellPrice = 2320;
			AvailableClasses = 0x7FFF;
			Model = 26810;
			ObjectClass = 4;
			SubClass = 4;
			Level = 41;
			ReqLevel = 40;
			Name = "Symbolic Belt";
			Name2 = "Symbolic Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11600;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
			StrBonus = 8;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Tyrant's Belt)
*
***************************************************************/

namespace Server.Items
{
	public class TyrantsBelt : Item
	{
		public TyrantsBelt() : base()
		{
			Id = 14838;
			Resistance[0] = 215;
			Bonding = 2;
			SellPrice = 2892;
			AvailableClasses = 0x7FFF;
			Model = 26686;
			ObjectClass = 4;
			SubClass = 4;
			Level = 43;
			ReqLevel = 40;
			Name = "Tyrant's Belt";
			Name2 = "Tyrant's Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 14460;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
			StrBonus = 9;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Sunscale Belt)
*
***************************************************************/

namespace Server.Items
{
	public class SunscaleBelt : Item
	{
		public SunscaleBelt() : base()
		{
			Id = 14847;
			Resistance[0] = 265;
			Bonding = 2;
			SellPrice = 4254;
			AvailableClasses = 0x7FFF;
			Model = 26819;
			ObjectClass = 4;
			SubClass = 4;
			Level = 49;
			ReqLevel = 44;
			Name = "Sunscale Belt";
			Name2 = "Sunscale Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 21272;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
			StrBonus = 10;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Vanguard Girdle)
*
***************************************************************/

namespace Server.Items
{
	public class VanguardGirdle : Item
	{
		public VanguardGirdle() : base()
		{
			Id = 14856;
			Resistance[0] = 290;
			Bonding = 2;
			SellPrice = 6156;
			AvailableClasses = 0x7FFF;
			Model = 26848;
			ObjectClass = 4;
			SubClass = 4;
			Level = 54;
			ReqLevel = 49;
			Name = "Vanguard Girdle";
			Name2 = "Vanguard Girdle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 30781;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
			IqBonus = 9;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Warleader's Belt)
*
***************************************************************/

namespace Server.Items
{
	public class WarleadersBelt : Item
	{
		public WarleadersBelt() : base()
		{
			Id = 14864;
			Resistance[0] = 315;
			Bonding = 2;
			SellPrice = 7602;
			AvailableClasses = 0x7FFF;
			Model = 26879;
			ObjectClass = 4;
			SubClass = 4;
			Level = 59;
			ReqLevel = 54;
			Name = "Warleader's Belt";
			Name2 = "Warleader's Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 38012;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
			StrBonus = 6;
			StaminaBonus = 10;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Saltstone Girdle)
*
***************************************************************/

namespace Server.Items
{
	public class SaltstoneGirdle : Item
	{
		public SaltstoneGirdle() : base()
		{
			Id = 14898;
			Resistance[0] = 149;
			Bonding = 2;
			SellPrice = 2295;
			AvailableClasses = 0x7FFF;
			Model = 26650;
			ObjectClass = 4;
			SubClass = 4;
			Level = 40;
			ReqLevel = 40;
			Name = "Saltstone Girdle";
			Name2 = "Saltstone Girdle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 947;
			BuyPrice = 11475;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Brutish Belt)
*
***************************************************************/

namespace Server.Items
{
	public class BrutishBelt : Item
	{
		public BrutishBelt() : base()
		{
			Id = 14906;
			Resistance[0] = 241;
			Bonding = 2;
			SellPrice = 2989;
			AvailableClasses = 0x7FFF;
			Model = 27902;
			ObjectClass = 4;
			SubClass = 4;
			Level = 44;
			Name = "Brutish Belt";
			Name2 = "Brutish Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 948;
			BuyPrice = 14947;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Jade Belt)
*
***************************************************************/

namespace Server.Items
{
	public class JadeBelt : Item
	{
		public JadeBelt() : base()
		{
			Id = 14918;
			Resistance[0] = 255;
			Bonding = 2;
			SellPrice = 3654;
			AvailableClasses = 0x7FFF;
			Model = 26792;
			ObjectClass = 4;
			SubClass = 4;
			Level = 47;
			ReqLevel = 42;
			Name = "Jade Belt";
			Name2 = "Jade Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 949;
			BuyPrice = 18273;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Lofty Belt)
*
***************************************************************/

namespace Server.Items
{
	public class LoftyBelt : Item
	{
		public LoftyBelt() : base()
		{
			Id = 14927;
			Resistance[0] = 280;
			Bonding = 2;
			SellPrice = 5301;
			AvailableClasses = 0x7FFF;
			Model = 26870;
			ObjectClass = 4;
			SubClass = 4;
			Level = 52;
			ReqLevel = 47;
			Name = "Lofty Belt";
			Name2 = "Lofty Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 951;
			BuyPrice = 26505;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Heroic Girdle)
*
***************************************************************/

namespace Server.Items
{
	public class HeroicGirdle : Item
	{
		public HeroicGirdle() : base()
		{
			Id = 14934;
			Resistance[0] = 305;
			Bonding = 2;
			SellPrice = 6754;
			AvailableClasses = 0x7FFF;
			Model = 27935;
			ObjectClass = 4;
			SubClass = 4;
			Level = 57;
			ReqLevel = 52;
			Name = "Heroic Girdle";
			Name2 = "Heroic Girdle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 952;
			BuyPrice = 33770;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Warbringer's Belt)
*
***************************************************************/

namespace Server.Items
{
	public class WarbringersBelt : Item
	{
		public WarbringersBelt() : base()
		{
			Id = 14943;
			Resistance[0] = 191;
			Bonding = 2;
			SellPrice = 2534;
			AvailableClasses = 0x7FFF;
			Model = 26634;
			ObjectClass = 4;
			SubClass = 4;
			Level = 42;
			ReqLevel = 40;
			Name = "Warbringer's Belt";
			Name2 = "Warbringer's Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 947;
			BuyPrice = 12671;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Bloodforged Belt)
*
***************************************************************/

namespace Server.Items
{
	public class BloodforgedBelt : Item
	{
		public BloodforgedBelt() : base()
		{
			Id = 14950;
			Resistance[0] = 251;
			Bonding = 2;
			SellPrice = 3630;
			AvailableClasses = 0x7FFF;
			Model = 26836;
			ObjectClass = 4;
			SubClass = 4;
			Level = 46;
			ReqLevel = 41;
			Name = "Bloodforged Belt";
			Name2 = "Bloodforged Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 949;
			BuyPrice = 18153;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(High Chief's Belt)
*
***************************************************************/

namespace Server.Items
{
	public class HighChiefsBelt : Item
	{
		public HighChiefsBelt() : base()
		{
			Id = 14960;
			Resistance[0] = 275;
			Bonding = 2;
			SellPrice = 4870;
			AvailableClasses = 0x7FFF;
			Model = 26828;
			ObjectClass = 4;
			SubClass = 4;
			Level = 51;
			ReqLevel = 46;
			Name = "High Chief's Belt";
			Name2 = "High Chief's Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 950;
			BuyPrice = 24353;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Glorious Belt)
*
***************************************************************/

namespace Server.Items
{
	public class GloriousBelt : Item
	{
		public GloriousBelt() : base()
		{
			Id = 14968;
			Resistance[0] = 295;
			Bonding = 2;
			SellPrice = 6502;
			AvailableClasses = 0x7FFF;
			Model = 26856;
			ObjectClass = 4;
			SubClass = 4;
			Level = 55;
			ReqLevel = 50;
			Name = "Glorious Belt";
			Name2 = "Glorious Belt";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 952;
			BuyPrice = 32510;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Exalted Girdle)
*
***************************************************************/

namespace Server.Items
{
	public class ExaltedGirdle : Item
	{
		public ExaltedGirdle() : base()
		{
			Id = 14977;
			Resistance[0] = 320;
			Bonding = 2;
			SellPrice = 7982;
			AvailableClasses = 0x7FFF;
			Model = 26889;
			ObjectClass = 4;
			SubClass = 4;
			Level = 60;
			ReqLevel = 55;
			Name = "Exalted Girdle";
			Name2 = "Exalted Girdle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 953;
			BuyPrice = 39913;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Gearforge Girdle)
*
***************************************************************/

namespace Server.Items
{
	public class GearforgeGirdle : Item
	{
		public GearforgeGirdle() : base()
		{
			Id = 15709;
			Resistance[0] = 310;
			Bonding = 1;
			SellPrice = 7270;
			AvailableClasses = 0x7FFF;
			Model = 26437;
			ObjectClass = 4;
			SubClass = 4;
			Level = 58;
			Name = "Gearforge Girdle";
			Name2 = "Gearforge Girdle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 36352;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 6;
			Durability = 40;
			StrBonus = 16;
			AgilityBonus = 4;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Lightforge Belt)
*
***************************************************************/

namespace Server.Items
{
	public class LightforgeBelt : Item
	{
		public LightforgeBelt() : base()
		{
			Id = 16723;
			Resistance[0] = 341;
			Bonding = 2;
			SellPrice = 8625;
			AvailableClasses = 0x7FFF;
			Model = 29966;
			ObjectClass = 4;
			SubClass = 4;
			Level = 58;
			ReqLevel = 53;
			Name = "Lightforge Belt";
			Name2 = "Lightforge Belt";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 43127;
			Sets = 188;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 6;
			Durability = 45;
			SpiritBonus = 15;
			IqBonus = 6;
			StaminaBonus = 9;
			StrBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Belt of Valor)
*
***************************************************************/

namespace Server.Items
{
	public class BeltOfValor : Item
	{
		public BeltOfValor() : base()
		{
			Id = 16736;
			Resistance[0] = 341;
			Bonding = 1;
			SellPrice = 9295;
			AvailableClasses = 0x7FFF;
			Model = 29959;
			ObjectClass = 4;
			SubClass = 4;
			Level = 58;
			ReqLevel = 53;
			Name = "Belt of Valor";
			Name2 = "Belt of Valor";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 46475;
			Sets = 189;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 6;
			Durability = 45;
			StrBonus = 14;
			StaminaBonus = 8;
			AgilityBonus = 7;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Lawbringer Belt)
*
***************************************************************/

namespace Server.Items
{
	public class LawbringerBelt : Item
	{
		public LawbringerBelt() : base()
		{
			Id = 16858;
			Resistance[0] = 421;
			Bonding = 2;
			SellPrice = 17119;
			AvailableClasses = 0x02;
			Model = 31353;
			Resistance[2] = 7;
			ObjectClass = 4;
			SubClass = 4;
			Level = 66;
			ReqLevel = 60;
			Name = "Lawbringer Belt";
			Name2 = "Lawbringer Belt";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 85599;
			Sets = 208;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 6;
			Durability = 55;
			SetSpell( 9406 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 20;
			IqBonus = 8;
			StaminaBonus = 15;
			StrBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Belt of Might)
*
***************************************************************/

namespace Server.Items
{
	public class BeltOfMight : Item
	{
		public BeltOfMight() : base()
		{
			Id = 16864;
			Resistance[0] = 421;
			Bonding = 2;
			SellPrice = 17981;
			AvailableClasses = 0x01;
			Model = 31019;
			Resistance[2] = 7;
			ObjectClass = 4;
			SubClass = 4;
			Level = 66;
			ReqLevel = 60;
			Name = "Belt of Might";
			Name2 = "Belt of Might";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 89909;
			Sets = 209;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 6;
			Durability = 55;
			SetSpell( 13669 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 13383 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 15;
			StrBonus = 21;
		}
	}
}


/**************************************************************
*
*				(Judgement Belt)
*
***************************************************************/

namespace Server.Items
{
	public class JudgementBelt : Item
	{
		public JudgementBelt() : base()
		{
			Id = 16952;
			Resistance[0] = 482;
			Bonding = 1;
			SellPrice = 27996;
			AvailableClasses = 0x02;
			Model = 29875;
			ObjectClass = 4;
			SubClass = 4;
			Level = 76;
			ReqLevel = 60;
			Name = "Judgement Belt";
			Name2 = "Judgement Belt";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 139982;
			Sets = 217;
			Resistance[5] = 10;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 6;
			Durability = 55;
			SetSpell( 18029 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 23;
			IqBonus = 8;
			StaminaBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Waistband of Wrath)
*
***************************************************************/

namespace Server.Items
{
	public class WaistbandOfWrath : Item
	{
		public WaistbandOfWrath() : base()
		{
			Id = 16960;
			Resistance[0] = 482;
			Bonding = 1;
			SellPrice = 29614;
			AvailableClasses = 0x01;
			Model = 29864;
			ObjectClass = 4;
			SubClass = 4;
			Level = 76;
			ReqLevel = 60;
			Name = "Waistband of Wrath";
			Name2 = "Waistband of Wrath";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 148074;
			Sets = 218;
			Resistance[5] = 10;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 6;
			Durability = 55;
			SetSpell( 13676 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 13385 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 20;
			StrBonus = 20;
		}
	}
}


/**************************************************************
*
*				(Elemental Plate Girdle)
*
***************************************************************/

namespace Server.Items
{
	public class ElementalPlateGirdle : Item
	{
		public ElementalPlateGirdle() : base()
		{
			Id = 18529;
			Resistance[0] = 358;
			Bonding = 1;
			SellPrice = 9963;
			AvailableClasses = 0x7FFF;
			Model = 30865;
			ObjectClass = 4;
			SubClass = 4;
			Level = 61;
			ReqLevel = 56;
			Name = "Elemental Plate Girdle";
			Name2 = "Elemental Plate Girdle";
			Quality = 3;
			AvailableRaces = 0x1FF;
			Extra = 3499;
			BuyPrice = 49816;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 6;
			Durability = 45;
			StrBonus = 17;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Unmelting Ice Girdle)
*
***************************************************************/

namespace Server.Items
{
	public class UnmeltingIceGirdle : Item
	{
		public UnmeltingIceGirdle() : base()
		{
			Id = 18547;
			Resistance[0] = 452;
			Bonding = 1;
			SellPrice = 23619;
			AvailableClasses = 0x7FFF;
			Model = 30894;
			Resistance[4] = 16;
			ObjectClass = 4;
			SubClass = 4;
			Level = 71;
			ReqLevel = 60;
			Name = "Unmelting Ice Girdle";
			Name2 = "Unmelting Ice Girdle";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 118096;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 6;
			Durability = 55;
			SetSpell( 13387 , 1 , 0 , -1 , 0 , -1 );
			AgilityBonus = 14;
			StrBonus = 14;
			StaminaBonus = 14;
		}
	}
}


/**************************************************************
*
*				(Belt of the Ordained)
*
***************************************************************/

namespace Server.Items
{
	public class BeltOfTheOrdained : Item
	{
		public BeltOfTheOrdained() : base()
		{
			Id = 18702;
			Resistance[0] = 353;
			Bonding = 1;
			SellPrice = 9488;
			AvailableClasses = 0x7FFF;
			Model = 31143;
			ObjectClass = 4;
			SubClass = 4;
			Level = 60;
			ReqLevel = 55;
			Name = "Belt of the Ordained";
			Name2 = "Belt of the Ordained";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 47443;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 6;
			Durability = 45;
			SetSpell( 18032 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 8;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Girdle of the Dawn)
*
***************************************************************/

namespace Server.Items
{
	public class GirdleOfTheDawn : Item
	{
		public GirdleOfTheDawn() : base()
		{
			Id = 19051;
			Resistance[0] = 341;
			Bonding = 2;
			SellPrice = 9365;
			AvailableClasses = 0x7FFF;
			Model = 31565;
			ObjectClass = 4;
			SubClass = 4;
			Level = 58;
			ReqLevel = 53;
			Name = "Girdle of the Dawn";
			Name2 = "Girdle of the Dawn";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 46827;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = -1;
			Durability = 45;
			StrBonus = 21;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Frostwolf Plate Belt)
*
***************************************************************/

namespace Server.Items
{
	public class FrostwolfPlateBelt : Item
	{
		public FrostwolfPlateBelt() : base()
		{
			Id = 19087;
			Resistance[0] = 353;
			Bonding = 1;
			SellPrice = 10176;
			AvailableClasses = 0x7FFF;
			Model = 31598;
			Resistance[4] = 5;
			ObjectClass = 4;
			SubClass = 4;
			Level = 60;
			ReqLevel = 55;
			Name = "Frostwolf Plate Belt";
			Name2 = "Frostwolf Plate Belt";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 50881;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 5;
			Durability = 45;
			Flags = 32768;
			AgilityBonus = 7;
			StaminaBonus = 8;
			StrBonus = 18;
		}
	}
}


/**************************************************************
*
*				(Stormpike Plate Girdle)
*
***************************************************************/

namespace Server.Items
{
	public class StormpikePlateGirdle : Item
	{
		public StormpikePlateGirdle() : base()
		{
			Id = 19091;
			Resistance[0] = 353;
			Bonding = 1;
			SellPrice = 9488;
			AvailableClasses = 0x7FFF;
			Model = 31597;
			Resistance[4] = 5;
			ObjectClass = 4;
			SubClass = 4;
			Level = 60;
			ReqLevel = 55;
			Name = "Stormpike Plate Girdle";
			Name2 = "Stormpike Plate Girdle";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 47443;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 5;
			Durability = 45;
			Flags = 32768;
			AgilityBonus = 7;
			StaminaBonus = 8;
			StrBonus = 18;
		}
	}
}


/**************************************************************
*
*				(Onslaught Girdle)
*
***************************************************************/

namespace Server.Items
{
	public class OnslaughtGirdle : Item
	{
		public OnslaughtGirdle() : base()
		{
			Id = 19137;
			Resistance[0] = 494;
			Bonding = 1;
			SellPrice = 31469;
			AvailableClasses = 0x7FFF;
			Model = 31654;
			ObjectClass = 4;
			SubClass = 4;
			Level = 78;
			ReqLevel = 60;
			Name = "Onslaught Girdle";
			Name2 = "Onslaught Girdle";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 157346;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 6;
			Durability = 55;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 15464 , 1 , 0 , -1 , 0 , -1 );
			StrBonus = 31;
			StaminaBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Girdle of the Fallen Crusader)
*
***************************************************************/

namespace Server.Items
{
	public class GirdleOfTheFallenCrusader : Item
	{
		public GirdleOfTheFallenCrusader() : base()
		{
			Id = 19392;
			Resistance[0] = 488;
			Bonding = 1;
			SellPrice = 31776;
			AvailableClasses = 0x7FFF;
			Model = 31924;
			ObjectClass = 4;
			SubClass = 4;
			Level = 77;
			ReqLevel = 60;
			Name = "Girdle of the Fallen Crusader";
			Name2 = "Girdle of the Fallen Crusader";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 158883;
			InventoryType = InventoryTypes.Waist;
			Stackable = 1;
			Material = 6;
			Durability = 55;
			StrBonus = 20;
			StaminaBonus = 15;
			SpiritBonus = 17;
			IqBonus = 13;
			AgilityBonus = 10;
		}
	}
}


