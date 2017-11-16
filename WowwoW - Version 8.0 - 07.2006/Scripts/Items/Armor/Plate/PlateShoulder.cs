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
*				(Heavy Mithril Shoulder)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyMithrilShoulder : Item
	{
		public HeavyMithrilShoulder() : base()
		{
			Id = 7918;
			Resistance[0] = 225;
			Bonding = 2;
			SellPrice = 3701;
			AvailableClasses = 0x7FFF;
			Model = 16089;
			ObjectClass = 4;
			SubClass = 4;
			Level = 41;
			ReqLevel = 40;
			Name = "Heavy Mithril Shoulder";
			Name2 = "Heavy Mithril Shoulder";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 18508;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 6;
			Durability = 70;
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Ornate Mithril Shoulder)
*
***************************************************************/

namespace Server.Items
{
	public class OrnateMithrilShoulder : Item
	{
		public OrnateMithrilShoulder() : base()
		{
			Id = 7928;
			Resistance[0] = 327;
			Bonding = 2;
			SellPrice = 4857;
			AvailableClasses = 0x7FFF;
			Model = 16106;
			ObjectClass = 4;
			SubClass = 4;
			Level = 45;
			ReqLevel = 40;
			Name = "Ornate Mithril Shoulder";
			Name2 = "Ornate Mithril Shoulder";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 24286;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 6;
			Durability = 70;
			SetSpell( 13669 , 1 , 0 , -1 , 0 , -1 );
			StrBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Light Plate Shoulderpads)
*
***************************************************************/

namespace Server.Items
{
	public class LightPlateShoulderpads : Item
	{
		public LightPlateShoulderpads() : base()
		{
			Id = 8086;
			Resistance[0] = 348;
			SellPrice = 3730;
			AvailableClasses = 0x7FFF;
			Model = 28403;
			ObjectClass = 4;
			SubClass = 4;
			Level = 54;
			ReqLevel = 49;
			Name = "Light Plate Shoulderpads";
			Name2 = "Light Plate Shoulderpads";
			AvailableRaces = 0x1FF;
			BuyPrice = 18652;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 6;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Chromite Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class ChromitePauldrons : Item
	{
		public ChromitePauldrons() : base()
		{
			Id = 8144;
			Resistance[0] = 327;
			Bonding = 2;
			SellPrice = 5036;
			AvailableClasses = 0x7FFF;
			Model = 27336;
			ObjectClass = 4;
			SubClass = 4;
			Level = 45;
			ReqLevel = 40;
			Name = "Chromite Pauldrons";
			Name2 = "Chromite Pauldrons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 25181;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 6;
			Durability = 70;
			StrBonus = 10;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Jouster's Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class JoustersPauldrons : Item
	{
		public JoustersPauldrons() : base()
		{
			Id = 8163;
			Resistance[0] = 225;
			Bonding = 2;
			SellPrice = 3688;
			AvailableClasses = 0x7FFF;
			Model = 27346;
			ObjectClass = 4;
			SubClass = 4;
			Level = 41;
			ReqLevel = 40;
			Name = "Jouster's Pauldrons";
			Name2 = "Jouster's Pauldrons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 18441;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 6;
			Durability = 70;
			StrBonus = 9;
			IqBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Valorous Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class ValorousPauldrons : Item
	{
		public ValorousPauldrons() : base()
		{
			Id = 8281;
			Resistance[0] = 347;
			Bonding = 2;
			SellPrice = 5982;
			AvailableClasses = 0x7FFF;
			Model = 27378;
			ObjectClass = 4;
			SubClass = 4;
			Level = 48;
			ReqLevel = 43;
			Name = "Valorous Pauldrons";
			Name2 = "Valorous Pauldrons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 29914;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 6;
			Durability = 70;
			StrBonus = 10;
			IqBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Alabaster Plate Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class AlabasterPlatePauldrons : Item
	{
		public AlabasterPlatePauldrons() : base()
		{
			Id = 8319;
			Resistance[0] = 393;
			Bonding = 2;
			SellPrice = 9181;
			AvailableClasses = 0x7FFF;
			Model = 27396;
			ObjectClass = 4;
			SubClass = 4;
			Level = 55;
			ReqLevel = 50;
			Name = "Alabaster Plate Pauldrons";
			Name2 = "Alabaster Plate Pauldrons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 45906;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 6;
			Durability = 70;
			StrBonus = 12;
			IqBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Field Plate Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class FieldPlatePauldrons : Item
	{
		public FieldPlatePauldrons() : base()
		{
			Id = 9292;
			Resistance[0] = 255;
			Bonding = 2;
			SellPrice = 3684;
			AvailableClasses = 0x7FFF;
			Model = 27361;
			ObjectClass = 4;
			SubClass = 4;
			Level = 42;
			ReqLevel = 40;
			Name = "Field Plate Pauldrons";
			Name2 = "Field Plate Pauldrons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1199;
			BuyPrice = 18424;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 6;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Big Bad Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class BigBadPauldrons : Item
	{
		public BigBadPauldrons() : base()
		{
			Id = 9476;
			Resistance[0] = 396;
			Bonding = 1;
			SellPrice = 8593;
			AvailableClasses = 0x7FFF;
			Model = 18389;
			ObjectClass = 4;
			SubClass = 4;
			Level = 50;
			ReqLevel = 45;
			Name = "Big Bad Pauldrons";
			Name2 = "Big Bad Pauldrons";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 42968;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 6;
			Durability = 80;
			StrBonus = 12;
			StaminaBonus = 12;
			IqBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Gemshale Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class GemshalePauldrons : Item
	{
		public GemshalePauldrons() : base()
		{
			Id = 9531;
			Resistance[0] = 334;
			Bonding = 1;
			SellPrice = 5264;
			AvailableClasses = 0x7FFF;
			Model = 18497;
			ObjectClass = 4;
			SubClass = 4;
			Level = 46;
			Name = "Gemshale Pauldrons";
			Name2 = "Gemshale Pauldrons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 26322;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 6;
			Durability = 70;
			StrBonus = 10;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Embossed Plate Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class EmbossedPlatePauldrons : Item
	{
		public EmbossedPlatePauldrons() : base()
		{
			Id = 9971;
			Resistance[0] = 286;
			Bonding = 2;
			SellPrice = 3995;
			AvailableClasses = 0x7FFF;
			Model = 27355;
			ObjectClass = 4;
			SubClass = 4;
			Level = 43;
			ReqLevel = 40;
			Name = "Embossed Plate Pauldrons";
			Name2 = "Embossed Plate Pauldrons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1200;
			BuyPrice = 19976;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 6;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Gothic Plate Spaulders)
*
***************************************************************/

namespace Server.Items
{
	public class GothicPlateSpaulders : Item
	{
		public GothicPlateSpaulders() : base()
		{
			Id = 10092;
			Resistance[0] = 341;
			Bonding = 2;
			SellPrice = 5602;
			AvailableClasses = 0x7FFF;
			Model = 27371;
			ObjectClass = 4;
			SubClass = 4;
			Level = 47;
			ReqLevel = 42;
			Name = "Gothic Plate Spaulders";
			Name2 = "Gothic Plate Spaulders";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1201;
			BuyPrice = 28011;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 6;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Revenant Shoulders)
*
***************************************************************/

namespace Server.Items
{
	public class RevenantShoulders : Item
	{
		public RevenantShoulders() : base()
		{
			Id = 10134;
			Resistance[0] = 366;
			Bonding = 2;
			SellPrice = 7664;
			AvailableClasses = 0x7FFF;
			Model = 27431;
			ObjectClass = 4;
			SubClass = 4;
			Level = 51;
			ReqLevel = 46;
			Name = "Revenant Shoulders";
			Name2 = "Revenant Shoulders";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1202;
			BuyPrice = 38320;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 6;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Templar Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class TemplarPauldrons : Item
	{
		public TemplarPauldrons() : base()
		{
			Id = 10170;
			Resistance[0] = 400;
			Bonding = 2;
			SellPrice = 10105;
			AvailableClasses = 0x7FFF;
			Model = 27414;
			ObjectClass = 4;
			SubClass = 4;
			Level = 56;
			ReqLevel = 51;
			Name = "Templar Pauldrons";
			Name2 = "Templar Pauldrons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1204;
			BuyPrice = 50528;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 6;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Overlord's Spaulders)
*
***************************************************************/

namespace Server.Items
{
	public class OverlordsSpaulders : Item
	{
		public OverlordsSpaulders() : base()
		{
			Id = 10209;
			Resistance[0] = 360;
			Bonding = 2;
			SellPrice = 7216;
			AvailableClasses = 0x7FFF;
			Model = 27403;
			ObjectClass = 4;
			SubClass = 4;
			Level = 50;
			ReqLevel = 45;
			Name = "Overlord's Spaulders";
			Name2 = "Overlord's Spaulders";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1202;
			BuyPrice = 36080;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 6;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Heavy Lamellar Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyLamellarPauldrons : Item
	{
		public HeavyLamellarPauldrons() : base()
		{
			Id = 10245;
			Resistance[0] = 380;
			Bonding = 2;
			SellPrice = 8548;
			AvailableClasses = 0x7FFF;
			Model = 27386;
			ObjectClass = 4;
			SubClass = 4;
			Level = 53;
			ReqLevel = 48;
			Name = "Heavy Lamellar Pauldrons";
			Name2 = "Heavy Lamellar Pauldrons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1203;
			BuyPrice = 42744;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 6;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Emerald Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class EmeraldPauldrons : Item
	{
		public EmeraldPauldrons() : base()
		{
			Id = 10281;
			Resistance[0] = 414;
			Bonding = 2;
			SellPrice = 11272;
			AvailableClasses = 0x7FFF;
			Model = 27422;
			ObjectClass = 4;
			SubClass = 4;
			Level = 58;
			ReqLevel = 53;
			Name = "Emerald Pauldrons";
			Name2 = "Emerald Pauldrons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1205;
			BuyPrice = 56362;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 6;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Imbued Plate Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class ImbuedPlatePauldrons : Item
	{
		public ImbuedPlatePauldrons() : base()
		{
			Id = 10374;
			Resistance[0] = 421;
			Bonding = 2;
			SellPrice = 11837;
			AvailableClasses = 0x7FFF;
			Model = 26364;
			ObjectClass = 4;
			SubClass = 4;
			Level = 59;
			ReqLevel = 54;
			Name = "Imbued Plate Pauldrons";
			Name2 = "Imbued Plate Pauldrons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 59186;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 6;
			Durability = 70;
			StrBonus = 13;
			IqBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Commander's Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class CommandersPauldrons : Item
	{
		public CommandersPauldrons() : base()
		{
			Id = 10383;
			Resistance[0] = 434;
			Bonding = 2;
			SellPrice = 12521;
			AvailableClasses = 0x7FFF;
			Model = 26337;
			ObjectClass = 4;
			SubClass = 4;
			Level = 61;
			ReqLevel = 56;
			Name = "Commander's Pauldrons";
			Name2 = "Commander's Pauldrons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1206;
			BuyPrice = 62609;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 6;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Hyperion Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class HyperionPauldrons : Item
	{
		public HyperionPauldrons() : base()
		{
			Id = 10390;
			Resistance[0] = 448;
			Bonding = 2;
			SellPrice = 14175;
			AvailableClasses = 0x7FFF;
			Model = 26342;
			ObjectClass = 4;
			SubClass = 4;
			Level = 63;
			ReqLevel = 58;
			Name = "Hyperion Pauldrons";
			Name2 = "Hyperion Pauldrons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1206;
			BuyPrice = 70876;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 6;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Dark Iron Shoulders)
*
***************************************************************/

namespace Server.Items
{
	public class DarkIronShoulders : Item
	{
		public DarkIronShoulders() : base()
		{
			Id = 11605;
			Resistance[0] = 514;
			Bonding = 2;
			SellPrice = 10776;
			AvailableClasses = 0x7FFF;
			Model = 21574;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 4;
			Level = 58;
			ReqLevel = 53;
			Name = "Dark Iron Shoulders";
			Name2 = "Dark Iron Shoulders";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 53880;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 6;
			Durability = 70;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Earthslag Shoulders)
*
***************************************************************/

namespace Server.Items
{
	public class EarthslagShoulders : Item
	{
		public EarthslagShoulders() : base()
		{
			Id = 11632;
			Resistance[0] = 373;
			Bonding = 1;
			SellPrice = 7800;
			AvailableClasses = 0x7FFF;
			Model = 28725;
			ObjectClass = 4;
			SubClass = 4;
			Level = 52;
			ReqLevel = 47;
			Name = "Earthslag Shoulders";
			Name2 = "Earthslag Shoulders";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 39001;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 6;
			Durability = 70;
			StrBonus = 11;
			IqBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Bark Iron Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class BarkIronPauldrons : Item
	{
		public BarkIronPauldrons() : base()
		{
			Id = 11889;
			Resistance[0] = 360;
			Bonding = 1;
			SellPrice = 7345;
			AvailableClasses = 0x7FFF;
			Model = 28304;
			ObjectClass = 4;
			SubClass = 4;
			Level = 50;
			Name = "Bark Iron Pauldrons";
			Name2 = "Bark Iron Pauldrons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 36728;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 6;
			Durability = 70;
			StrBonus = 11;
			AgilityBonus = 5;
			IqBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Imperial Plate Shoulders)
*
***************************************************************/

namespace Server.Items
{
	public class ImperialPlateShoulders : Item
	{
		public ImperialPlateShoulders() : base()
		{
			Id = 12428;
			Resistance[0] = 380;
			Bonding = 2;
			SellPrice = 8646;
			AvailableClasses = 0x7FFF;
			Model = 24509;
			ObjectClass = 4;
			SubClass = 4;
			Level = 53;
			ReqLevel = 47;
			Name = "Imperial Plate Shoulders";
			Name2 = "Imperial Plate Shoulders";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 43233;
			Sets = 321;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 6;
			Durability = 70;
			StrBonus = 12;
			StaminaBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Ebonsteel Spaulders)
*
***************************************************************/

namespace Server.Items
{
	public class EbonsteelSpaulders : Item
	{
		public EbonsteelSpaulders() : base()
		{
			Id = 12557;
			Resistance[0] = 463;
			Bonding = 1;
			SellPrice = 14368;
			AvailableClasses = 0x7FFF;
			Model = 28727;
			ObjectClass = 4;
			SubClass = 4;
			Level = 59;
			ReqLevel = 54;
			Name = "Ebonsteel Spaulders";
			Name2 = "Ebonsteel Spaulders";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 71841;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 6;
			Durability = 80;
			IqBonus = 9;
			StaminaBonus = 17;
			AgilityBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Runic Plate Shoulders)
*
***************************************************************/

namespace Server.Items
{
	public class RunicPlateShoulders : Item
	{
		public RunicPlateShoulders() : base()
		{
			Id = 12610;
			Resistance[0] = 527;
			Bonding = 2;
			SellPrice = 12247;
			AvailableClasses = 0x7FFF;
			Model = 23490;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 4;
			Level = 60;
			ReqLevel = 55;
			Name = "Runic Plate Shoulders";
			Name2 = "Runic Plate Shoulders";
			Resistance[3] = 10;
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 61238;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 6;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Wyrmslayer Spaulders)
*
***************************************************************/

namespace Server.Items
{
	public class WyrmslayerSpaulders : Item
	{
		public WyrmslayerSpaulders() : base()
		{
			Id = 13066;
			Resistance[0] = 403;
			Bonding = 2;
			SellPrice = 8997;
			AvailableClasses = 0x7FFF;
			Model = 28351;
			ObjectClass = 4;
			SubClass = 4;
			Level = 51;
			ReqLevel = 46;
			Name = "Wyrmslayer Spaulders";
			Name2 = "Wyrmslayer Spaulders";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 44989;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 6;
			Durability = 80;
			StrBonus = 12;
			StaminaBonus = 12;
			AgilityBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Slamshot Shoulders)
*
***************************************************************/

namespace Server.Items
{
	public class SlamshotShoulders : Item
	{
		public SlamshotShoulders() : base()
		{
			Id = 13166;
			Resistance[0] = 470;
			Bonding = 1;
			SellPrice = 14204;
			AvailableClasses = 0x7FFF;
			Model = 23704;
			ObjectClass = 4;
			SubClass = 4;
			Level = 60;
			ReqLevel = 55;
			Name = "Slamshot Shoulders";
			Name2 = "Slamshot Shoulders";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 71024;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 6;
			Durability = 80;
			SetSpell( 9331 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 21;
		}
	}
}


/**************************************************************
*
*				(Wailing Nightbane Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class WailingNightbanePauldrons : Item
	{
		public WailingNightbanePauldrons() : base()
		{
			Id = 13405;
			Resistance[0] = 448;
			Bonding = 1;
			SellPrice = 13102;
			AvailableClasses = 0x7FFF;
			Model = 24115;
			ObjectClass = 4;
			SubClass = 4;
			Level = 57;
			ReqLevel = 52;
			Name = "Wailing Nightbane Pauldrons";
			Name2 = "Wailing Nightbane Pauldrons";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 65511;
			Resistance[5] = 10;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 6;
			Durability = 80;
			StaminaBonus = 14;
			IqBonus = 5;
			StrBonus = 14;
		}
	}
}


/**************************************************************
*
*				(Acid-etched Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class AcidEtchedPauldrons : Item
	{
		public AcidEtchedPauldrons() : base()
		{
			Id = 13533;
			Resistance[0] = 434;
			Bonding = 1;
			SellPrice = 12810;
			AvailableClasses = 0x7FFF;
			Model = 24185;
			ObjectClass = 4;
			SubClass = 4;
			Level = 61;
			ReqLevel = 56;
			Name = "Acid-etched Pauldrons";
			Name2 = "Acid-etched Pauldrons";
			Resistance[3] = 20;
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 64052;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 6;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Stoneform Shoulders)
*
***************************************************************/

namespace Server.Items
{
	public class StoneformShoulders : Item
	{
		public StoneformShoulders() : base()
		{
			Id = 13955;
			Resistance[0] = 688;
			Bonding = 1;
			SellPrice = 16367;
			AvailableClasses = 0x7FFF;
			Model = 24777;
			ObjectClass = 4;
			SubClass = 4;
			Level = 61;
			ReqLevel = 56;
			Name = "Stoneform Shoulders";
			Name2 = "Stoneform Shoulders";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 81837;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 6;
			Durability = 80;
			SetSpell( 13385 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Stockade Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class StockadePauldrons : Item
	{
		public StockadePauldrons() : base()
		{
			Id = 14552;
			Resistance[0] = 472;
			Bonding = 2;
			SellPrice = 15378;
			AvailableClasses = 0x7FFF;
			Model = 28282;
			ObjectClass = 4;
			SubClass = 4;
			Level = 55;
			ReqLevel = 50;
			Name = "Stockade Pauldrons";
			Name2 = "Stockade Pauldrons";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 76890;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 6;
			Durability = 100;
			SetSpell( 13390 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 20;
			IqBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Symbolic Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class SymbolicPauldrons : Item
	{
		public SymbolicPauldrons() : base()
		{
			Id = 14830;
			Resistance[0] = 255;
			Bonding = 2;
			SellPrice = 3801;
			AvailableClasses = 0x7FFF;
			Model = 26818;
			ObjectClass = 4;
			SubClass = 4;
			Level = 42;
			ReqLevel = 40;
			Name = "Symbolic Pauldrons";
			Name2 = "Symbolic Pauldrons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 19007;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 6;
			Durability = 70;
			StaminaBonus = 11;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Tyrant's Epaulets)
*
***************************************************************/

namespace Server.Items
{
	public class TyrantsEpaulets : Item
	{
		public TyrantsEpaulets() : base()
		{
			Id = 14841;
			Resistance[0] = 321;
			Bonding = 2;
			SellPrice = 4284;
			AvailableClasses = 0x7FFF;
			Model = 26688;
			ObjectClass = 4;
			SubClass = 4;
			Level = 44;
			ReqLevel = 40;
			Name = "Tyrant's Epaulets";
			Name2 = "Tyrant's Epaulets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 21423;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 6;
			Durability = 70;
			StaminaBonus = 12;
			AgilityBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Sunscale Spaulders)
*
***************************************************************/

namespace Server.Items
{
	public class SunscaleSpaulders : Item
	{
		public SunscaleSpaulders() : base()
		{
			Id = 14851;
			Resistance[0] = 366;
			Bonding = 2;
			SellPrice = 7416;
			AvailableClasses = 0x7FFF;
			Model = 26825;
			ObjectClass = 4;
			SubClass = 4;
			Level = 51;
			ReqLevel = 46;
			Name = "Sunscale Spaulders";
			Name2 = "Sunscale Spaulders";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 37083;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 6;
			Durability = 70;
			StaminaBonus = 13;
			AgilityBonus = 5;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Vanguard Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class VanguardPauldrons : Item
	{
		public VanguardPauldrons() : base()
		{
			Id = 14860;
			Resistance[0] = 400;
			Bonding = 2;
			SellPrice = 10523;
			AvailableClasses = 0x7FFF;
			Model = 27876;
			ObjectClass = 4;
			SubClass = 4;
			Level = 56;
			ReqLevel = 51;
			Name = "Vanguard Pauldrons";
			Name2 = "Vanguard Pauldrons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 52616;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 6;
			Durability = 70;
			StaminaBonus = 8;
			IqBonus = 12;
			AgilityBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Warleader's Shoulders)
*
***************************************************************/

namespace Server.Items
{
	public class WarleadersShoulders : Item
	{
		public WarleadersShoulders() : base()
		{
			Id = 14868;
			Resistance[0] = 434;
			Bonding = 2;
			SellPrice = 13109;
			AvailableClasses = 0x7FFF;
			Model = 26885;
			ObjectClass = 4;
			SubClass = 4;
			Level = 61;
			ReqLevel = 56;
			Name = "Warleader's Shoulders";
			Name2 = "Warleader's Shoulders";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 65547;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 6;
			Durability = 70;
			StaminaBonus = 17;
			StrBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Saltstone Shoulder Pads)
*
***************************************************************/

namespace Server.Items
{
	public class SaltstoneShoulderPads : Item
	{
		public SaltstoneShoulderPads() : base()
		{
			Id = 14901;
			Resistance[0] = 225;
			Bonding = 2;
			SellPrice = 3494;
			AvailableClasses = 0x7FFF;
			Model = 26655;
			ObjectClass = 4;
			SubClass = 4;
			Level = 41;
			ReqLevel = 40;
			Name = "Saltstone Shoulder Pads";
			Name2 = "Saltstone Shoulder Pads";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1199;
			BuyPrice = 17472;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 6;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Brutish Shoulders)
*
***************************************************************/

namespace Server.Items
{
	public class BrutishShoulders : Item
	{
		public BrutishShoulders() : base()
		{
			Id = 14909;
			Resistance[0] = 327;
			Bonding = 2;
			SellPrice = 4897;
			AvailableClasses = 0x7FFF;
			Model = 27904;
			ObjectClass = 4;
			SubClass = 4;
			Level = 45;
			ReqLevel = 40;
			Name = "Brutish Shoulders";
			Name2 = "Brutish Shoulders";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1200;
			BuyPrice = 24486;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 6;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Jade Epaulets)
*
***************************************************************/

namespace Server.Items
{
	public class JadeEpaulets : Item
	{
		public JadeEpaulets() : base()
		{
			Id = 14921;
			Resistance[0] = 354;
			Bonding = 2;
			SellPrice = 6407;
			AvailableClasses = 0x7FFF;
			Model = 26797;
			ObjectClass = 4;
			SubClass = 4;
			Level = 49;
			ReqLevel = 44;
			Name = "Jade Epaulets";
			Name2 = "Jade Epaulets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1202;
			BuyPrice = 32036;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 6;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Lofty Shoulder Pads)
*
***************************************************************/

namespace Server.Items
{
	public class LoftyShoulderPads : Item
	{
		public LoftyShoulderPads() : base()
		{
			Id = 14929;
			Resistance[0] = 387;
			Bonding = 2;
			SellPrice = 8999;
			AvailableClasses = 0x7FFF;
			Model = 26875;
			ObjectClass = 4;
			SubClass = 4;
			Level = 54;
			ReqLevel = 49;
			Name = "Lofty Shoulder Pads";
			Name2 = "Lofty Shoulder Pads";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1203;
			BuyPrice = 44997;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 6;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Heroic Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class HeroicPauldrons : Item
	{
		public HeroicPauldrons() : base()
		{
			Id = 14937;
			Resistance[0] = 421;
			Bonding = 2;
			SellPrice = 11406;
			AvailableClasses = 0x7FFF;
			Model = 27940;
			ObjectClass = 4;
			SubClass = 4;
			Level = 59;
			ReqLevel = 54;
			Name = "Heroic Pauldrons";
			Name2 = "Heroic Pauldrons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1205;
			BuyPrice = 57030;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 6;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Warbringer's Spaulders)
*
***************************************************************/

namespace Server.Items
{
	public class WarbringersSpaulders : Item
	{
		public WarbringersSpaulders() : base()
		{
			Id = 14946;
			Resistance[0] = 286;
			Bonding = 2;
			SellPrice = 4151;
			AvailableClasses = 0x7FFF;
			Model = 26645;
			ObjectClass = 4;
			SubClass = 4;
			Level = 43;
			ReqLevel = 40;
			Name = "Warbringer's Spaulders";
			Name2 = "Warbringer's Spaulders";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1200;
			BuyPrice = 20757;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 6;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Bloodforged Shoulder Pads)
*
***************************************************************/

namespace Server.Items
{
	public class BloodforgedShoulderPads : Item
	{
		public BloodforgedShoulderPads() : base()
		{
			Id = 14955;
			Resistance[0] = 341;
			Bonding = 2;
			SellPrice = 5418;
			AvailableClasses = 0x7FFF;
			Model = 26843;
			ObjectClass = 4;
			SubClass = 4;
			Level = 47;
			ReqLevel = 42;
			Name = "Bloodforged Shoulder Pads";
			Name2 = "Bloodforged Shoulder Pads";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1201;
			BuyPrice = 27090;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 6;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(High Chief's Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class HighChiefsPauldrons : Item
	{
		public HighChiefsPauldrons() : base()
		{
			Id = 14963;
			Resistance[0] = 380;
			Bonding = 2;
			SellPrice = 8301;
			AvailableClasses = 0x7FFF;
			Model = 26834;
			ObjectClass = 4;
			SubClass = 4;
			Level = 53;
			ReqLevel = 48;
			Name = "High Chief's Pauldrons";
			Name2 = "High Chief's Pauldrons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1203;
			BuyPrice = 41509;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 6;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Glorious Shoulder Pads)
*
***************************************************************/

namespace Server.Items
{
	public class GloriousShoulderPads : Item
	{
		public GloriousShoulderPads() : base()
		{
			Id = 14971;
			Resistance[0] = 407;
			Bonding = 2;
			SellPrice = 11076;
			AvailableClasses = 0x7FFF;
			Model = 26864;
			ObjectClass = 4;
			SubClass = 4;
			Level = 57;
			ReqLevel = 52;
			Name = "Glorious Shoulder Pads";
			Name2 = "Glorious Shoulder Pads";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1204;
			BuyPrice = 55380;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 6;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Exalted Epaulets)
*
***************************************************************/

namespace Server.Items
{
	public class ExaltedEpaulets : Item
	{
		public ExaltedEpaulets() : base()
		{
			Id = 14981;
			Resistance[0] = 441;
			Bonding = 2;
			SellPrice = 13764;
			AvailableClasses = 0x7FFF;
			Model = 26894;
			ObjectClass = 4;
			SubClass = 4;
			Level = 62;
			ReqLevel = 57;
			Name = "Exalted Epaulets";
			Name2 = "Exalted Epaulets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1206;
			BuyPrice = 68824;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 6;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Lieutenant Commander's Plate Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class LieutenantCommandersPlatePauldrons : Item
	{
		public LieutenantCommandersPlatePauldrons() : base()
		{
			Id = 16432;
			Resistance[0] = 493;
			Bonding = 1;
			SellPrice = 8736;
			AvailableClasses = 0x01;
			Model = 26662;
			ObjectClass = 4;
			SubClass = 4;
			Level = 63;
			ReqLevel = 58;
			Name = "Lieutenant Commander's Plate Pauldrons";
			Name2 = "Lieutenant Commander's Plate Pauldrons";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 43683;
			Sets = 282;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			MaxCount = 1;
			Material = 6;
			Durability = 80;
			Flags = 32768;
			StaminaBonus = 23;
			StrBonus = 7;
			AgilityBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Lieutenant Commander's Lamellar Shoulders)
*
***************************************************************/

namespace Server.Items
{
	public class LieutenantCommandersLamellarShoulders : Item
	{
		public LieutenantCommandersLamellarShoulders() : base()
		{
			Id = 16436;
			Resistance[0] = 493;
			Bonding = 1;
			SellPrice = 8863;
			AvailableClasses = 0x02;
			Model = 31085;
			ObjectClass = 4;
			SubClass = 4;
			Level = 63;
			ReqLevel = 58;
			Name = "Lieutenant Commander's Lamellar Shoulders";
			Name2 = "Lieutenant Commander's Lamellar Shoulders";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 44318;
			Sets = 401;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			MaxCount = 1;
			Material = 6;
			Durability = 80;
			Flags = 32768;
			StaminaBonus = 12;
			StrBonus = 12;
			AgilityBonus = 12;
			SpiritBonus = 7;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Field Marshal's Lamellar Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class FieldMarshalsLamellarPauldrons : Item
	{
		public FieldMarshalsLamellarPauldrons() : base()
		{
			Id = 16476;
			Resistance[0] = 553;
			Bonding = 1;
			SellPrice = 12091;
			AvailableClasses = 0x02;
			Model = 30318;
			ObjectClass = 4;
			SubClass = 4;
			Level = 65;
			ReqLevel = 60;
			Name = "Field Marshal's Lamellar Pauldrons";
			Name2 = "Field Marshal's Lamellar Pauldrons";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 60456;
			Sets = 402;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			MaxCount = 1;
			Material = 6;
			Durability = 100;
			Flags = 32768;
			StaminaBonus = 18;
			StrBonus = 17;
			AgilityBonus = 11;
			SpiritBonus = 10;
			IqBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Field Marshal's Plate Shoulderguards)
*
***************************************************************/

namespace Server.Items
{
	public class FieldMarshalsPlateShoulderguards : Item
	{
		public FieldMarshalsPlateShoulderguards() : base()
		{
			Id = 16480;
			Resistance[0] = 553;
			Bonding = 1;
			SellPrice = 12277;
			AvailableClasses = 0x01;
			Model = 30318;
			ObjectClass = 4;
			SubClass = 4;
			Level = 65;
			ReqLevel = 60;
			Name = "Field Marshal's Plate Shoulderguards";
			Name2 = "Field Marshal's Plate Shoulderguards";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 61389;
			Sets = 384;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			MaxCount = 1;
			Material = 6;
			Durability = 100;
			Flags = 32768;
			StaminaBonus = 26;
			StrBonus = 15;
			AgilityBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Champion's Plate Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class ChampionsPlatePauldrons : Item
	{
		public ChampionsPlatePauldrons() : base()
		{
			Id = 16516;
			Resistance[0] = 493;
			Bonding = 1;
			SellPrice = 8223;
			AvailableClasses = 0x01;
			Model = 31049;
			ObjectClass = 4;
			SubClass = 4;
			Level = 63;
			ReqLevel = 58;
			Name = "Champion's Plate Pauldrons";
			Name2 = "Champion's Plate Pauldrons";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 41118;
			Sets = 281;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			MaxCount = 1;
			Material = 6;
			Durability = 80;
			Flags = 32768;
			StaminaBonus = 23;
			StrBonus = 7;
			AgilityBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Warlord's Plate Shoulders)
*
***************************************************************/

namespace Server.Items
{
	public class WarlordsPlateShoulders : Item
	{
		public WarlordsPlateShoulders() : base()
		{
			Id = 16544;
			Resistance[0] = 553;
			Bonding = 1;
			SellPrice = 12795;
			AvailableClasses = 0x01;
			Model = 30928;
			ObjectClass = 4;
			SubClass = 4;
			Level = 65;
			ReqLevel = 60;
			Name = "Warlord's Plate Shoulders";
			Name2 = "Warlord's Plate Shoulders";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 63979;
			Sets = 383;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			MaxCount = 1;
			Material = 6;
			Durability = 100;
			Flags = 32768;
			StaminaBonus = 26;
			StrBonus = 15;
			AgilityBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Lightforge Spaulders)
*
***************************************************************/

namespace Server.Items
{
	public class LightforgeSpaulders : Item
	{
		public LightforgeSpaulders() : base()
		{
			Id = 16729;
			Resistance[0] = 470;
			Bonding = 1;
			SellPrice = 14592;
			AvailableClasses = 0x7FFF;
			Model = 29971;
			ObjectClass = 4;
			SubClass = 4;
			Level = 60;
			ReqLevel = 55;
			Name = "Lightforge Spaulders";
			Name2 = "Lightforge Spaulders";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 72964;
			Sets = 188;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 6;
			Durability = 80;
			StaminaBonus = 15;
			SpiritBonus = 11;
			StrBonus = 9;
			IqBonus = 5;
			AgilityBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Spaulders of Valor)
*
***************************************************************/

namespace Server.Items
{
	public class SpauldersOfValor : Item
	{
		public SpauldersOfValor() : base()
		{
			Id = 16733;
			Resistance[0] = 470;
			Bonding = 1;
			SellPrice = 15207;
			AvailableClasses = 0x7FFF;
			Model = 29964;
			ObjectClass = 4;
			SubClass = 4;
			Level = 60;
			ReqLevel = 55;
			Name = "Spaulders of Valor";
			Name2 = "Spaulders of Valor";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 76038;
			Sets = 189;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 6;
			Durability = 80;
			StaminaBonus = 17;
			StrBonus = 11;
			AgilityBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Lawbringer Spaulders)
*
***************************************************************/

namespace Server.Items
{
	public class LawbringerSpaulders : Item
	{
		public LawbringerSpaulders() : base()
		{
			Id = 16856;
			Resistance[0] = 562;
			Bonding = 1;
			SellPrice = 25485;
			AvailableClasses = 0x02;
			Model = 31510;
			ObjectClass = 4;
			SubClass = 4;
			Level = 66;
			ReqLevel = 60;
			Name = "Lawbringer Spaulders";
			Name2 = "Lawbringer Spaulders";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 127425;
			Sets = 208;
			Resistance[5] = 7;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 6;
			Durability = 100;
			SetSpell( 9406 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 15;
			IqBonus = 8;
			StaminaBonus = 22;
			StrBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Pauldrons of Might)
*
***************************************************************/

namespace Server.Items
{
	public class PauldronsOfMight : Item
	{
		public PauldronsOfMight() : base()
		{
			Id = 16868;
			Resistance[0] = 562;
			Bonding = 1;
			SellPrice = 27364;
			AvailableClasses = 0x01;
			Model = 31024;
			ObjectClass = 4;
			SubClass = 4;
			Level = 66;
			ReqLevel = 60;
			Name = "Pauldrons of Might";
			Name2 = "Pauldrons of Might";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 136824;
			Sets = 209;
			Resistance[5] = 7;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 6;
			Durability = 100;
			SetSpell( 13675 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 13383 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 22;
			StrBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Judgement Spaulders)
*
***************************************************************/

namespace Server.Items
{
	public class JudgementSpaulders : Item
	{
		public JudgementSpaulders() : base()
		{
			Id = 16953;
			Resistance[0] = 642;
			Bonding = 1;
			SellPrice = 42155;
			AvailableClasses = 0x02;
			Model = 29882;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 4;
			Level = 76;
			ReqLevel = 60;
			Name = "Judgement Spaulders";
			Name2 = "Judgement Spaulders";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 210776;
			Sets = 217;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 6;
			Durability = 100;
			SetSpell( 21363 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 9408 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 17;
			IqBonus = 8;
			StaminaBonus = 20;
		}
	}
}


/**************************************************************
*
*				(Pauldrons of Wrath)
*
***************************************************************/

namespace Server.Items
{
	public class PauldronsOfWrath : Item
	{
		public PauldronsOfWrath() : base()
		{
			Id = 16961;
			Resistance[0] = 642;
			Bonding = 1;
			SellPrice = 44583;
			AvailableClasses = 0x01;
			Model = 29867;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 4;
			Level = 76;
			ReqLevel = 60;
			Name = "Pauldrons of Wrath";
			Name2 = "Pauldrons of Wrath";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 222915;
			Sets = 218;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 6;
			Durability = 100;
			SetSpell( 23516 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 13385 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 27;
			StrBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Hulkstone Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class HulkstonePauldrons : Item
	{
		public HulkstonePauldrons() : base()
		{
			Id = 17779;
			Resistance[0] = 341;
			Bonding = 1;
			SellPrice = 5547;
			AvailableClasses = 0x7FFF;
			Model = 29955;
			ObjectClass = 4;
			SubClass = 4;
			Level = 47;
			Name = "Hulkstone Pauldrons";
			Name2 = "Hulkstone Pauldrons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 27736;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 6;
			Durability = 70;
			StaminaBonus = 13;
			StrBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Bile-etched Spaulders)
*
***************************************************************/

namespace Server.Items
{
	public class BileEtchedSpaulders : Item
	{
		public BileEtchedSpaulders() : base()
		{
			Id = 18384;
			Resistance[0] = 485;
			Bonding = 1;
			SellPrice = 16093;
			AvailableClasses = 0x7FFF;
			Model = 30743;
			ObjectClass = 4;
			SubClass = 4;
			Level = 62;
			ReqLevel = 57;
			Name = "Bile-etched Spaulders";
			Name2 = "Bile-etched Spaulders";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 80467;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 6;
			Durability = 80;
			SetSpell( 13385 , 1 , 0 , -1 , 0 , -1 );
			StrBonus = 17;
			StaminaBonus = 6;
			SpiritBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Bulky Iron Spaulders)
*
***************************************************************/

namespace Server.Items
{
	public class BulkyIronSpaulders : Item
	{
		public BulkyIronSpaulders() : base()
		{
			Id = 18493;
			Resistance[0] = 470;
			Bonding = 1;
			SellPrice = 14233;
			AvailableClasses = 0x7FFF;
			Model = 30829;
			ObjectClass = 4;
			SubClass = 4;
			Level = 60;
			ReqLevel = 55;
			Name = "Bulky Iron Spaulders";
			Name2 = "Bulky Iron Spaulders";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 71165;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 6;
			Durability = 80;
			SetSpell( 13384 , 1 , 0 , -1 , 0 , -1 );
			StrBonus = 15;
			StaminaBonus = 12;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Emerald Peak Spaulders)
*
***************************************************************/

namespace Server.Items
{
	public class EmeraldPeakSpaulders : Item
	{
		public EmeraldPeakSpaulders() : base()
		{
			Id = 19037;
			Resistance[0] = 347;
			Bonding = 1;
			SellPrice = 5877;
			AvailableClasses = 0x7FFF;
			Model = 31523;
			ObjectClass = 4;
			SubClass = 4;
			Level = 48;
			Name = "Emerald Peak Spaulders";
			Name2 = "Emerald Peak Spaulders";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 29389;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 6;
			Durability = 70;
			AgilityBonus = 6;
			StaminaBonus = 10;
			StrBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Drake Talon Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class DrakeTalonPauldrons : Item
	{
		public DrakeTalonPauldrons() : base()
		{
			Id = 19394;
			Resistance[0] = 634;
			Bonding = 1;
			SellPrice = 39395;
			AvailableClasses = 0x7FFF;
			Model = 31926;
			ObjectClass = 4;
			SubClass = 4;
			Level = 75;
			ReqLevel = 60;
			Name = "Drake Talon Pauldrons";
			Name2 = "Drake Talon Pauldrons";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 196975;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 6;
			Durability = 100;
			SetSpell( 13669 , 1 , 0 , -1 , 0 , -1 );
			AgilityBonus = 20;
			StrBonus = 20;
			StaminaBonus = 17;
		}
	}
}


