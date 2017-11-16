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
*				(Steel Plate Helm)
*
***************************************************************/

namespace Server.Items
{
	public class SteelPlateHelm : Item
	{
		public SteelPlateHelm() : base()
		{
			Id = 7922;
			Resistance[0] = 355;
			SellPrice = 2377;
			AvailableClasses = 0x7FFF;
			Model = 16093;
			ObjectClass = 4;
			SubClass = 4;
			Level = 43;
			ReqLevel = 40;
			Name = "Steel Plate Helm";
			Name2 = "Steel Plate Helm";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 11885;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 6;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Heavy Mithril Helm)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyMithrilHelm : Item
	{
		public HeavyMithrilHelm() : base()
		{
			Id = 7934;
			Resistance[0] = 469;
			Bonding = 2;
			SellPrice = 5790;
			AvailableClasses = 0x7FFF;
			Model = 16115;
			ObjectClass = 4;
			SubClass = 4;
			Level = 47;
			ReqLevel = 42;
			Name = "Heavy Mithril Helm";
			Name2 = "Heavy Mithril Helm";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 28952;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 6;
			Durability = 70;
			StaminaBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Ornate Mithril Helm)
*
***************************************************************/

namespace Server.Items
{
	public class OrnateMithrilHelm : Item
	{
		public OrnateMithrilHelm() : base()
		{
			Id = 7937;
			Resistance[0] = 383;
			Bonding = 2;
			SellPrice = 6763;
			AvailableClasses = 0x7FFF;
			Model = 16119;
			ObjectClass = 4;
			SubClass = 4;
			Level = 49;
			ReqLevel = 44;
			Name = "Ornate Mithril Helm";
			Name2 = "Ornate Mithril Helm";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 33818;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 6;
			Durability = 70;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			StrBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Platemail Helm)
*
***************************************************************/

namespace Server.Items
{
	public class PlatemailHelm : Item
	{
		public PlatemailHelm() : base()
		{
			Id = 8092;
			Resistance[0] = 371;
			SellPrice = 4062;
			AvailableClasses = 0x7FFF;
			Model = 15340;
			ObjectClass = 4;
			SubClass = 4;
			Level = 50;
			ReqLevel = 45;
			Name = "Platemail Helm";
			Name2 = "Platemail Helm";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 20312;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 6;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Chromite Barbute)
*
***************************************************************/

namespace Server.Items
{
	public class ChromiteBarbute : Item
	{
		public ChromiteBarbute() : base()
		{
			Id = 8142;
			Resistance[0] = 348;
			Bonding = 2;
			SellPrice = 4630;
			AvailableClasses = 0x7FFF;
			Model = 27338;
			ObjectClass = 4;
			SubClass = 4;
			Level = 44;
			ReqLevel = 40;
			Name = "Chromite Barbute";
			Name2 = "Chromite Barbute";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 23152;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 6;
			Durability = 70;
			AgilityBonus = 12;
			StrBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Jouster's Visor)
*
***************************************************************/

namespace Server.Items
{
	public class JoustersVisor : Item
	{
		public JoustersVisor() : base()
		{
			Id = 8161;
			Resistance[0] = 215;
			Bonding = 2;
			SellPrice = 3390;
			AvailableClasses = 0x7FFF;
			Model = 27347;
			ObjectClass = 4;
			SubClass = 4;
			Level = 40;
			ReqLevel = 40;
			Name = "Jouster's Visor";
			Name2 = "Jouster's Visor";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 16954;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 6;
			Durability = 70;
			StaminaBonus = 11;
			AgilityBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Valorous Helm)
*
***************************************************************/

namespace Server.Items
{
	public class ValorousHelm : Item
	{
		public ValorousHelm() : base()
		{
			Id = 8279;
			Resistance[0] = 376;
			Bonding = 2;
			SellPrice = 5937;
			AvailableClasses = 0x7FFF;
			Model = 27379;
			ObjectClass = 4;
			SubClass = 4;
			Level = 48;
			ReqLevel = 43;
			Name = "Valorous Helm";
			Name2 = "Valorous Helm";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 29688;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 6;
			Durability = 70;
			AgilityBonus = 14;
			StaminaBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Alabaster Plate Helmet)
*
***************************************************************/

namespace Server.Items
{
	public class AlabasterPlateHelmet : Item
	{
		public AlabasterPlateHelmet() : base()
		{
			Id = 8317;
			Resistance[0] = 419;
			Bonding = 2;
			SellPrice = 8595;
			AvailableClasses = 0x7FFF;
			Model = 27395;
			ObjectClass = 4;
			SubClass = 4;
			Level = 54;
			ReqLevel = 49;
			Name = "Alabaster Plate Helmet";
			Name2 = "Alabaster Plate Helmet";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 42977;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 6;
			Durability = 70;
			StaminaBonus = 16;
			IqBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Light Plate Helmet)
*
***************************************************************/

namespace Server.Items
{
	public class LightPlateHelmet : Item
	{
		public LightPlateHelmet() : base()
		{
			Id = 8755;
			Resistance[0] = 383;
			SellPrice = 3728;
			AvailableClasses = 0x7FFF;
			Model = 28847;
			ObjectClass = 4;
			SubClass = 4;
			Level = 55;
			ReqLevel = 50;
			Name = "Light Plate Helmet";
			Name2 = "Light Plate Helmet";
			AvailableRaces = 0x1FF;
			BuyPrice = 18642;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 5;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Field Plate Helmet)
*
***************************************************************/

namespace Server.Items
{
	public class FieldPlateHelmet : Item
	{
		public FieldPlateHelmet() : base()
		{
			Id = 9290;
			Resistance[0] = 276;
			Bonding = 2;
			SellPrice = 3940;
			AvailableClasses = 0x7FFF;
			Model = 25839;
			ObjectClass = 4;
			SubClass = 4;
			Level = 42;
			ReqLevel = 40;
			Name = "Field Plate Helmet";
			Name2 = "Field Plate Helmet";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 695;
			BuyPrice = 19703;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 6;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Horned Viking Helmet)
*
***************************************************************/

namespace Server.Items
{
	public class HornedVikingHelmet : Item
	{
		public HornedVikingHelmet() : base()
		{
			Id = 9394;
			Resistance[0] = 303;
			Bonding = 1;
			SellPrice = 4575;
			AvailableClasses = 0x7FFF;
			Model = 21301;
			ObjectClass = 4;
			SubClass = 4;
			Level = 42;
			ReqLevel = 40;
			Name = "Horned Viking Helmet";
			Name2 = "Horned Viking Helmet";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 22878;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 6;
			Durability = 80;
			SetSpell( 22641 , 0 , 0 , 1800000 , 29 , 180000 );
			AgilityBonus = 10;
			StaminaBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Sentinel's Guard)
*
***************************************************************/

namespace Server.Items
{
	public class SentinelsGuard : Item
	{
		public SentinelsGuard() : base()
		{
			Id = 9664;
			Resistance[0] = 355;
			Bonding = 1;
			SellPrice = 5002;
			AvailableClasses = 0x7FFF;
			Model = 18584;
			ObjectClass = 4;
			SubClass = 4;
			Level = 45;
			Name = "Sentinel's Guard";
			Name2 = "Sentinel's Guard";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 25013;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 6;
			Durability = 70;
			IqBonus = 6;
			AgilityBonus = 9;
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Embossed Plate Helmet)
*
***************************************************************/

namespace Server.Items
{
	public class EmbossedPlateHelmet : Item
	{
		public EmbossedPlateHelmet() : base()
		{
			Id = 9969;
			Resistance[0] = 310;
			Bonding = 2;
			SellPrice = 3964;
			AvailableClasses = 0x7FFF;
			Model = 27511;
			ObjectClass = 4;
			SubClass = 4;
			Level = 43;
			ReqLevel = 40;
			Name = "Embossed Plate Helmet";
			Name2 = "Embossed Plate Helmet";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 696;
			BuyPrice = 19824;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 6;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Gothic Plate Helmet)
*
***************************************************************/

namespace Server.Items
{
	public class GothicPlateHelmet : Item
	{
		public GothicPlateHelmet() : base()
		{
			Id = 10090;
			Resistance[0] = 362;
			Bonding = 2;
			SellPrice = 5148;
			AvailableClasses = 0x7FFF;
			Model = 27366;
			ObjectClass = 4;
			SubClass = 4;
			Level = 46;
			ReqLevel = 41;
			Name = "Gothic Plate Helmet";
			Name2 = "Gothic Plate Helmet";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 697;
			BuyPrice = 25742;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 6;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Revenant Helmet)
*
***************************************************************/

namespace Server.Items
{
	public class RevenantHelmet : Item
	{
		public RevenantHelmet() : base()
		{
			Id = 10132;
			Resistance[0] = 397;
			Bonding = 2;
			SellPrice = 7608;
			AvailableClasses = 0x7FFF;
			Model = 19759;
			ObjectClass = 4;
			SubClass = 4;
			Level = 51;
			ReqLevel = 46;
			Name = "Revenant Helmet";
			Name2 = "Revenant Helmet";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 698;
			BuyPrice = 38043;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 6;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Templar Crown)
*
***************************************************************/

namespace Server.Items
{
	public class TemplarCrown : Item
	{
		public TemplarCrown() : base()
		{
			Id = 10168;
			Resistance[0] = 434;
			Bonding = 2;
			SellPrice = 10032;
			AvailableClasses = 0x7FFF;
			Model = 27408;
			ObjectClass = 4;
			SubClass = 4;
			Level = 56;
			ReqLevel = 51;
			Name = "Templar Crown";
			Name2 = "Templar Crown";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 700;
			BuyPrice = 50161;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 6;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Overlord's Crown)
*
***************************************************************/

namespace Server.Items
{
	public class OverlordsCrown : Item
	{
		public OverlordsCrown() : base()
		{
			Id = 10207;
			Resistance[0] = 383;
			Bonding = 2;
			SellPrice = 6695;
			AvailableClasses = 0x7FFF;
			Model = 27404;
			ObjectClass = 4;
			SubClass = 4;
			Level = 49;
			ReqLevel = 44;
			Name = "Overlord's Crown";
			Name2 = "Overlord's Crown";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 698;
			BuyPrice = 33477;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 6;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Heavy Lamellar Helm)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyLamellarHelm : Item
	{
		public HeavyLamellarHelm() : base()
		{
			Id = 10241;
			Resistance[0] = 411;
			Bonding = 2;
			SellPrice = 8425;
			AvailableClasses = 0x7FFF;
			Model = 27387;
			ObjectClass = 4;
			SubClass = 4;
			Level = 53;
			ReqLevel = 48;
			Name = "Heavy Lamellar Helm";
			Name2 = "Heavy Lamellar Helm";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 699;
			BuyPrice = 42125;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 6;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Emerald Helm)
*
***************************************************************/

namespace Server.Items
{
	public class EmeraldHelm : Item
	{
		public EmeraldHelm() : base()
		{
			Id = 10279;
			Resistance[0] = 448;
			Bonding = 2;
			SellPrice = 11188;
			AvailableClasses = 0x7FFF;
			Model = 27423;
			ObjectClass = 4;
			SubClass = 4;
			Level = 58;
			ReqLevel = 53;
			Name = "Emerald Helm";
			Name2 = "Emerald Helm";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 701;
			BuyPrice = 55944;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 6;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Imbued Plate Helmet)
*
***************************************************************/

namespace Server.Items
{
	public class ImbuedPlateHelmet : Item
	{
		public ImbuedPlateHelmet() : base()
		{
			Id = 10372;
			Resistance[0] = 456;
			Bonding = 2;
			SellPrice = 11750;
			AvailableClasses = 0x7FFF;
			Model = 26365;
			ObjectClass = 4;
			SubClass = 4;
			Level = 59;
			ReqLevel = 54;
			Name = "Imbued Plate Helmet";
			Name2 = "Imbued Plate Helmet";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 58754;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 6;
			Durability = 70;
			AgilityBonus = 17;
			StaminaBonus = 17;
		}
	}
}


/**************************************************************
*
*				(Commander's Helm)
*
***************************************************************/

namespace Server.Items
{
	public class CommandersHelm : Item
	{
		public CommandersHelm() : base()
		{
			Id = 10379;
			Resistance[0] = 471;
			Bonding = 2;
			SellPrice = 13290;
			AvailableClasses = 0x7FFF;
			Model = 27749;
			ObjectClass = 4;
			SubClass = 4;
			Level = 61;
			ReqLevel = 56;
			Name = "Commander's Helm";
			Name2 = "Commander's Helm";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 702;
			BuyPrice = 66454;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 6;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Hyperion Helm)
*
***************************************************************/

namespace Server.Items
{
	public class HyperionHelm : Item
	{
		public HyperionHelm() : base()
		{
			Id = 10388;
			Resistance[0] = 485;
			Bonding = 2;
			SellPrice = 14068;
			AvailableClasses = 0x7FFF;
			Model = 26257;
			ObjectClass = 4;
			SubClass = 4;
			Level = 63;
			ReqLevel = 58;
			Name = "Hyperion Helm";
			Name2 = "Hyperion Helm";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 702;
			BuyPrice = 70344;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 6;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Avenguard Helm)
*
***************************************************************/

namespace Server.Items
{
	public class AvenguardHelm : Item
	{
		public AvenguardHelm() : base()
		{
			Id = 10749;
			Resistance[0] = 461;
			Bonding = 1;
			SellPrice = 10554;
			AvailableClasses = 0x7FFF;
			Model = 19728;
			ObjectClass = 4;
			SubClass = 4;
			Level = 54;
			Name = "Avenguard Helm";
			Name2 = "Avenguard Helm";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 52774;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 6;
			Durability = 80;
			IqBonus = 10;
			AgilityBonus = 5;
			StaminaBonus = 25;
		}
	}
}


/**************************************************************
*
*				(Icemetal Barbute)
*
***************************************************************/

namespace Server.Items
{
	public class IcemetalBarbute : Item
	{
		public IcemetalBarbute() : base()
		{
			Id = 10763;
			Resistance[0] = 383;
			Bonding = 1;
			SellPrice = 5197;
			AvailableClasses = 0x7FFF;
			Model = 28783;
			Resistance[4] = 10;
			ObjectClass = 4;
			SubClass = 4;
			Level = 44;
			ReqLevel = 40;
			Name = "Icemetal Barbute";
			Name2 = "Icemetal Barbute";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 25989;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 6;
			Durability = 80;
			StrBonus = 15;
			IqBonus = 7;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Golem Skull Helm)
*
***************************************************************/

namespace Server.Items
{
	public class GolemSkullHelm : Item
	{
		public GolemSkullHelm() : base()
		{
			Id = 11746;
			Resistance[0] = 477;
			Bonding = 1;
			SellPrice = 11861;
			AvailableClasses = 0x7FFF;
			Model = 21717;
			ObjectClass = 4;
			SubClass = 4;
			Level = 56;
			ReqLevel = 51;
			Name = "Golem Skull Helm";
			Name2 = "Golem Skull Helm";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 59309;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 6;
			Durability = 80;
			SetSpell( 13386 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 18;
			StrBonus = 18;
		}
	}
}


/**************************************************************
*
*				(Thorium Helm)
*
***************************************************************/

namespace Server.Items
{
	public class ThoriumHelm : Item
	{
		public ThoriumHelm() : base()
		{
			Id = 12410;
			Resistance[6] = 10;
			Resistance[0] = 434;
			Bonding = 2;
			SellPrice = 10372;
			AvailableClasses = 0x7FFF;
			Model = 25856;
			Resistance[2] = 10;
			Resistance[4] = 10;
			ObjectClass = 4;
			SubClass = 4;
			Level = 56;
			ReqLevel = 51;
			Name = "Thorium Helm";
			Name2 = "Thorium Helm";
			Resistance[3] = 10;
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 51863;
			Resistance[5] = 10;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 6;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Imperial Plate Helm)
*
***************************************************************/

namespace Server.Items
{
	public class ImperialPlateHelm : Item
	{
		public ImperialPlateHelm() : base()
		{
			Id = 12427;
			Resistance[0] = 456;
			Bonding = 2;
			SellPrice = 12106;
			AvailableClasses = 0x7FFF;
			Model = 24510;
			ObjectClass = 4;
			SubClass = 4;
			Level = 59;
			ReqLevel = 54;
			Name = "Imperial Plate Helm";
			Name2 = "Imperial Plate Helm";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 60530;
			Sets = 321;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 6;
			Durability = 70;
			StrBonus = 18;
			StaminaBonus = 17;
		}
	}
}


/**************************************************************
*
*				(Runic Plate Helm)
*
***************************************************************/

namespace Server.Items
{
	public class RunicPlateHelm : Item
	{
		public RunicPlateHelm() : base()
		{
			Id = 12612;
			Resistance[0] = 621;
			Bonding = 2;
			SellPrice = 12956;
			AvailableClasses = 0x7FFF;
			Model = 23491;
			Resistance[2] = 13;
			ObjectClass = 4;
			SubClass = 4;
			Level = 61;
			ReqLevel = 56;
			Name = "Runic Plate Helm";
			Name2 = "Runic Plate Helm";
			Resistance[3] = 13;
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 64783;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 6;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Enchanted Thorium Helm)
*
***************************************************************/

namespace Server.Items
{
	public class EnchantedThoriumHelm : Item
	{
		public EnchantedThoriumHelm() : base()
		{
			Id = 12620;
			Resistance[0] = 526;
			Bonding = 2;
			SellPrice = 17245;
			AvailableClasses = 0x7FFF;
			Model = 22886;
			ObjectClass = 4;
			SubClass = 4;
			Level = 62;
			ReqLevel = 57;
			Name = "Enchanted Thorium Helm";
			Name2 = "Enchanted Thorium Helm";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 86225;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 6;
			Durability = 80;
			SetSpell( 13388 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 25;
			StrBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Whitesoul Helm)
*
***************************************************************/

namespace Server.Items
{
	public class WhitesoulHelm : Item
	{
		public WhitesoulHelm() : base()
		{
			Id = 12633;
			Resistance[0] = 629;
			Bonding = 2;
			SellPrice = 14859;
			AvailableClasses = 0x7FFF;
			Model = 22901;
			ObjectClass = 4;
			SubClass = 4;
			Level = 60;
			ReqLevel = 55;
			Name = "Whitesoul Helm";
			Name2 = "Whitesoul Helm";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 74299;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 6;
			Durability = 80;
			SetSpell( 18029 , 1 , 0 , -1 , 0 , -1 );
			IqBonus = 15;
			SpiritBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Lionheart Helm)
*
***************************************************************/

namespace Server.Items
{
	public class LionheartHelm : Item
	{
		public LionheartHelm() : base()
		{
			Id = 12640;
			Resistance[0] = 565;
			Bonding = 2;
			SellPrice = 21894;
			AvailableClasses = 0x7FFF;
			Model = 22920;
			ObjectClass = 4;
			SubClass = 4;
			Level = 61;
			ReqLevel = 56;
			Name = "Lionheart Helm";
			Name2 = "Lionheart Helm";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 109471;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 6;
			Durability = 100;
			SetSpell( 7598 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 15465 , 1 , 0 , -1 , 0 , -1 );
			StrBonus = 18;
		}
	}
}


/**************************************************************
*
*				(Skull of Gyth)
*
***************************************************************/

namespace Server.Items
{
	public class SkullOfGyth : Item
	{
		public SkullOfGyth() : base()
		{
			Id = 12952;
			Resistance[0] = 685;
			Bonding = 1;
			SellPrice = 14336;
			AvailableClasses = 0x7FFF;
			Model = 23519;
			ObjectClass = 4;
			SubClass = 4;
			Level = 63;
			ReqLevel = 58;
			Name = "Skull of Gyth";
			Name2 = "Skull of Gyth";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 71682;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 6;
			Durability = 70;
			StaminaBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Mugthol's Helm)
*
***************************************************************/

namespace Server.Items
{
	public class MugtholsHelm : Item
	{
		public MugtholsHelm() : base()
		{
			Id = 13073;
			Resistance[0] = 445;
			Bonding = 2;
			SellPrice = 9080;
			AvailableClasses = 0x7FFF;
			Model = 28360;
			ObjectClass = 4;
			SubClass = 4;
			Level = 52;
			ReqLevel = 47;
			Name = "Mugthol's Helm";
			Name2 = "Mugthol's Helm";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 45404;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 6;
			Durability = 80;
			IqBonus = 17;
			StrBonus = 10;
			StaminaBonus = 17;
		}
	}
}


/**************************************************************
*
*				(Symbolic Crown)
*
***************************************************************/

namespace Server.Items
{
	public class SymbolicCrown : Item
	{
		public SymbolicCrown() : base()
		{
			Id = 14831;
			Resistance[0] = 310;
			Bonding = 2;
			SellPrice = 4120;
			AvailableClasses = 0x7FFF;
			Model = 27182;
			ObjectClass = 4;
			SubClass = 4;
			Level = 43;
			ReqLevel = 40;
			Name = "Symbolic Crown";
			Name2 = "Symbolic Crown";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 20603;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 6;
			Durability = 70;
			StaminaBonus = 16;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Tyrant's Helm)
*
***************************************************************/

namespace Server.Items
{
	public class TyrantsHelm : Item
	{
		public TyrantsHelm() : base()
		{
			Id = 14843;
			Resistance[0] = 362;
			Bonding = 2;
			SellPrice = 5036;
			AvailableClasses = 0x7FFF;
			Model = 26692;
			ObjectClass = 4;
			SubClass = 4;
			Level = 46;
			ReqLevel = 41;
			Name = "Tyrant's Helm";
			Name2 = "Tyrant's Helm";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 25180;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 6;
			Durability = 70;
			StaminaBonus = 16;
			StrBonus = 5;
			AgilityBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Sunscale Helmet)
*
***************************************************************/

namespace Server.Items
{
	public class SunscaleHelmet : Item
	{
		public SunscaleHelmet() : base()
		{
			Id = 14849;
			Resistance[0] = 411;
			Bonding = 2;
			SellPrice = 8271;
			AvailableClasses = 0x7FFF;
			Model = 27186;
			ObjectClass = 4;
			SubClass = 4;
			Level = 53;
			ReqLevel = 48;
			Name = "Sunscale Helmet";
			Name2 = "Sunscale Helmet";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 41358;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 6;
			Durability = 70;
			StrBonus = 16;
			StaminaBonus = 12;
			AgilityBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Vanguard Headdress)
*
***************************************************************/

namespace Server.Items
{
	public class VanguardHeaddress : Item
	{
		public VanguardHeaddress() : base()
		{
			Id = 14858;
			Resistance[0] = 448;
			Bonding = 2;
			SellPrice = 11740;
			AvailableClasses = 0x7FFF;
			Model = 28985;
			ObjectClass = 4;
			SubClass = 4;
			Level = 58;
			ReqLevel = 53;
			Name = "Vanguard Headdress";
			Name2 = "Vanguard Headdress";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 58702;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 6;
			Durability = 70;
			StaminaBonus = 21;
			StrBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Warleader's Crown)
*
***************************************************************/

namespace Server.Items
{
	public class WarleadersCrown : Item
	{
		public WarleadersCrown() : base()
		{
			Id = 14866;
			Resistance[0] = 478;
			Bonding = 2;
			SellPrice = 13301;
			AvailableClasses = 0x7FFF;
			Model = 27180;
			ObjectClass = 4;
			SubClass = 4;
			Level = 62;
			ReqLevel = 57;
			Name = "Warleader's Crown";
			Name2 = "Warleader's Crown";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 66507;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 6;
			Durability = 70;
			StrBonus = 18;
			StaminaBonus = 16;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Saltstone Helm)
*
***************************************************************/

namespace Server.Items
{
	public class SaltstoneHelm : Item
	{
		public SaltstoneHelm() : base()
		{
			Id = 14899;
			Resistance[0] = 244;
			Bonding = 2;
			SellPrice = 3731;
			AvailableClasses = 0x7FFF;
			Model = 26656;
			ObjectClass = 4;
			SubClass = 4;
			Level = 41;
			ReqLevel = 40;
			Name = "Saltstone Helm";
			Name2 = "Saltstone Helm";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 695;
			BuyPrice = 18655;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 6;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Brutish Helmet)
*
***************************************************************/

namespace Server.Items
{
	public class BrutishHelmet : Item
	{
		public BrutishHelmet() : base()
		{
			Id = 14907;
			Resistance[0] = 376;
			Bonding = 2;
			SellPrice = 6123;
			AvailableClasses = 0x7FFF;
			Model = 27906;
			ObjectClass = 4;
			SubClass = 4;
			Level = 48;
			ReqLevel = 43;
			Name = "Brutish Helmet";
			Name2 = "Brutish Helmet";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 697;
			BuyPrice = 30619;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 6;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Jade Circlet)
*
***************************************************************/

namespace Server.Items
{
	public class JadeCirclet : Item
	{
		public JadeCirclet() : base()
		{
			Id = 14919;
			Resistance[0] = 404;
			Bonding = 2;
			SellPrice = 7717;
			AvailableClasses = 0x7FFF;
			Model = 27839;
			ObjectClass = 4;
			SubClass = 4;
			Level = 52;
			ReqLevel = 47;
			Name = "Jade Circlet";
			Name2 = "Jade Circlet";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 699;
			BuyPrice = 38588;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 6;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Lofty Helm)
*
***************************************************************/

namespace Server.Items
{
	public class LoftyHelm : Item
	{
		public LoftyHelm() : base()
		{
			Id = 14925;
			Resistance[0] = 441;
			Bonding = 2;
			SellPrice = 10562;
			AvailableClasses = 0x7FFF;
			Model = 28015;
			ObjectClass = 4;
			SubClass = 4;
			Level = 57;
			ReqLevel = 52;
			Name = "Lofty Helm";
			Name2 = "Lofty Helm";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 700;
			BuyPrice = 52810;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 6;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Heroic Skullcap)
*
***************************************************************/

namespace Server.Items
{
	public class HeroicSkullcap : Item
	{
		public HeroicSkullcap() : base()
		{
			Id = 14935;
			Resistance[0] = 463;
			Bonding = 2;
			SellPrice = 11885;
			AvailableClasses = 0x7FFF;
			Model = 27942;
			ObjectClass = 4;
			SubClass = 4;
			Level = 60;
			ReqLevel = 55;
			Name = "Heroic Skullcap";
			Name2 = "Heroic Skullcap";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 701;
			BuyPrice = 59428;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 6;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Warbringer's Crown)
*
***************************************************************/

namespace Server.Items
{
	public class WarbringersCrown : Item
	{
		public WarbringersCrown() : base()
		{
			Id = 14944;
			Resistance[0] = 355;
			Bonding = 2;
			SellPrice = 4806;
			AvailableClasses = 0x7FFF;
			Model = 27512;
			ObjectClass = 4;
			SubClass = 4;
			Level = 45;
			ReqLevel = 40;
			Name = "Warbringer's Crown";
			Name2 = "Warbringer's Crown";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 696;
			BuyPrice = 24031;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 6;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Bloodforged Helmet)
*
***************************************************************/

namespace Server.Items
{
	public class BloodforgedHelmet : Item
	{
		public BloodforgedHelmet() : base()
		{
			Id = 14952;
			Resistance[0] = 390;
			Bonding = 2;
			SellPrice = 7323;
			AvailableClasses = 0x7FFF;
			Model = 26257;
			ObjectClass = 4;
			SubClass = 4;
			Level = 50;
			ReqLevel = 45;
			Name = "Bloodforged Helmet";
			Name2 = "Bloodforged Helmet";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 698;
			BuyPrice = 36619;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 6;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(High Chief's Crown)
*
***************************************************************/

namespace Server.Items
{
	public class HighChiefsCrown : Item
	{
		public HighChiefsCrown() : base()
		{
			Id = 14961;
			Resistance[0] = 426;
			Bonding = 2;
			SellPrice = 9259;
			AvailableClasses = 0x7FFF;
			Model = 27835;
			ObjectClass = 4;
			SubClass = 4;
			Level = 55;
			ReqLevel = 50;
			Name = "High Chief's Crown";
			Name2 = "High Chief's Crown";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 700;
			BuyPrice = 46295;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 6;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Glorious Headdress)
*
***************************************************************/

namespace Server.Items
{
	public class GloriousHeaddress : Item
	{
		public GloriousHeaddress() : base()
		{
			Id = 14969;
			Resistance[0] = 456;
			Bonding = 2;
			SellPrice = 12241;
			AvailableClasses = 0x7FFF;
			Model = 28024;
			ObjectClass = 4;
			SubClass = 4;
			Level = 59;
			ReqLevel = 54;
			Name = "Glorious Headdress";
			Name2 = "Glorious Headdress";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 701;
			BuyPrice = 61205;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 6;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Exalted Helmet)
*
***************************************************************/

namespace Server.Items
{
	public class ExaltedHelmet : Item
	{
		public ExaltedHelmet() : base()
		{
			Id = 14979;
			Resistance[0] = 492;
			Bonding = 2;
			SellPrice = 14664;
			AvailableClasses = 0x7FFF;
			Model = 26893;
			ObjectClass = 4;
			SubClass = 4;
			Level = 64;
			ReqLevel = 59;
			Name = "Exalted Helmet";
			Name2 = "Exalted Helmet";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 703;
			BuyPrice = 73324;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 6;
			Durability = 70;
		}
	}
}


/**************************************************************
*
*				(Lieutenant Commander's Plate Helm)
*
***************************************************************/

namespace Server.Items
{
	public class LieutenantCommandersPlateHelm : Item
	{
		public LieutenantCommandersPlateHelm() : base()
		{
			Id = 16429;
			Resistance[0] = 534;
			Bonding = 1;
			SellPrice = 8641;
			AvailableClasses = 0x01;
			Model = 28934;
			ObjectClass = 4;
			SubClass = 4;
			Level = 63;
			ReqLevel = 58;
			Name = "Lieutenant Commander's Plate Helm";
			Name2 = "Lieutenant Commander's Plate Helm";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 43208;
			Sets = 282;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			MaxCount = 1;
			Material = 6;
			Durability = 80;
			Flags = 32768;
			StaminaBonus = 31;
			StrBonus = 9;
			AgilityBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Lieutenant Commander's Lamellar Headguard)
*
***************************************************************/

namespace Server.Items
{
	public class LieutenantCommandersLamellarHeadguard : Item
	{
		public LieutenantCommandersLamellarHeadguard() : base()
		{
			Id = 16434;
			Resistance[0] = 534;
			Bonding = 1;
			SellPrice = 8800;
			AvailableClasses = 0x02;
			Model = 30316;
			ObjectClass = 4;
			SubClass = 4;
			Level = 63;
			ReqLevel = 58;
			Name = "Lieutenant Commander's Lamellar Headguard";
			Name2 = "Lieutenant Commander's Lamellar Headguard";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 44003;
			Sets = 401;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			MaxCount = 1;
			Material = 6;
			Durability = 80;
			Flags = 32768;
			StaminaBonus = 31;
			StrBonus = 9;
			AgilityBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Field Marshal's Lamellar Faceguard)
*
***************************************************************/

namespace Server.Items
{
	public class FieldMarshalsLamellarFaceguard : Item
	{
		public FieldMarshalsLamellarFaceguard() : base()
		{
			Id = 16474;
			Resistance[0] = 599;
			Bonding = 1;
			SellPrice = 12933;
			AvailableClasses = 0x02;
			Model = 30316;
			ObjectClass = 4;
			SubClass = 4;
			Level = 65;
			ReqLevel = 60;
			Name = "Field Marshal's Lamellar Faceguard";
			Name2 = "Field Marshal's Lamellar Faceguard";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 64665;
			Sets = 402;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			MaxCount = 1;
			Material = 6;
			Durability = 100;
			Flags = 32768;
			StaminaBonus = 35;
			StrBonus = 19;
			AgilityBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Field Marshal's Plate Helm)
*
***************************************************************/

namespace Server.Items
{
	public class FieldMarshalsPlateHelm : Item
	{
		public FieldMarshalsPlateHelm() : base()
		{
			Id = 16478;
			Resistance[0] = 599;
			Bonding = 1;
			SellPrice = 12185;
			AvailableClasses = 0x01;
			Model = 30316;
			ObjectClass = 4;
			SubClass = 4;
			Level = 65;
			ReqLevel = 60;
			Name = "Field Marshal's Plate Helm";
			Name2 = "Field Marshal's Plate Helm";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 60926;
			Sets = 384;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			MaxCount = 1;
			Material = 6;
			Durability = 100;
			Flags = 32768;
			StaminaBonus = 35;
			StrBonus = 19;
			AgilityBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Champion's Plate Headguard)
*
***************************************************************/

namespace Server.Items
{
	public class ChampionsPlateHeadguard : Item
	{
		public ChampionsPlateHeadguard() : base()
		{
			Id = 16514;
			Resistance[0] = 534;
			Bonding = 1;
			SellPrice = 9024;
			AvailableClasses = 0x01;
			Model = 30071;
			ObjectClass = 4;
			SubClass = 4;
			Level = 63;
			ReqLevel = 58;
			Name = "Champion's Plate Headguard";
			Name2 = "Champion's Plate Headguard";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 45121;
			Sets = 281;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			MaxCount = 1;
			Material = 6;
			Durability = 80;
			Flags = 32768;
			StaminaBonus = 31;
			StrBonus = 9;
			AgilityBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Warlord's Plate Headpiece)
*
***************************************************************/

namespace Server.Items
{
	public class WarlordsPlateHeadpiece : Item
	{
		public WarlordsPlateHeadpiece() : base()
		{
			Id = 16542;
			Resistance[0] = 599;
			Bonding = 1;
			SellPrice = 12703;
			AvailableClasses = 0x01;
			Model = 30374;
			ObjectClass = 4;
			SubClass = 4;
			Level = 65;
			ReqLevel = 60;
			Name = "Warlord's Plate Headpiece";
			Name2 = "Warlord's Plate Headpiece";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 63516;
			Sets = 383;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			MaxCount = 1;
			Material = 6;
			Durability = 100;
			Flags = 32768;
			StaminaBonus = 35;
			StrBonus = 19;
			AgilityBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Lightforge Helm)
*
***************************************************************/

namespace Server.Items
{
	public class LightforgeHelm : Item
	{
		public LightforgeHelm() : base()
		{
			Id = 16727;
			Resistance[0] = 526;
			Bonding = 1;
			SellPrice = 15968;
			AvailableClasses = 0x7FFF;
			Model = 31207;
			ObjectClass = 4;
			SubClass = 4;
			Level = 62;
			ReqLevel = 57;
			Name = "Lightforge Helm";
			Name2 = "Lightforge Helm";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 79842;
			Sets = 188;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 6;
			Durability = 80;
			StaminaBonus = 20;
			StrBonus = 13;
			SpiritBonus = 14;
			IqBonus = 10;
			AgilityBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Helm of Valor)
*
***************************************************************/

namespace Server.Items
{
	public class HelmOfValor : Item
	{
		public HelmOfValor() : base()
		{
			Id = 16731;
			Resistance[0] = 526;
			Bonding = 1;
			SellPrice = 16210;
			AvailableClasses = 0x7FFF;
			Model = 31284;
			ObjectClass = 4;
			SubClass = 4;
			Level = 62;
			ReqLevel = 57;
			Name = "Helm of Valor";
			Name2 = "Helm of Valor";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 81051;
			Sets = 189;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 6;
			Durability = 80;
			StaminaBonus = 23;
			StrBonus = 15;
			AgilityBonus = 9;
			IqBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Lawbringer Helm)
*
***************************************************************/

namespace Server.Items
{
	public class LawbringerHelm : Item
	{
		public LawbringerHelm() : base()
		{
			Id = 16854;
			Resistance[0] = 608;
			Bonding = 1;
			SellPrice = 27956;
			AvailableClasses = 0x02;
			Model = 31506;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 4;
			Level = 66;
			ReqLevel = 60;
			Name = "Lawbringer Helm";
			Name2 = "Lawbringer Helm";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 139784;
			Sets = 208;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 6;
			Durability = 100;
			SetSpell( 21619 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 9408 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 24;
			IqBonus = 10;
			StaminaBonus = 20;
			StrBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Helm of Might)
*
***************************************************************/

namespace Server.Items
{
	public class HelmOfMight : Item
	{
		public HelmOfMight() : base()
		{
			Id = 16866;
			Resistance[0] = 608;
			Bonding = 1;
			SellPrice = 27170;
			AvailableClasses = 0x01;
			Model = 31260;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 4;
			Level = 66;
			ReqLevel = 60;
			Name = "Helm of Might";
			Name2 = "Helm of Might";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 135851;
			Sets = 209;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 6;
			Durability = 100;
			SetSpell( 13669 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 13385 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 35;
			StrBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Judgement Crown)
*
***************************************************************/

namespace Server.Items
{
	public class JudgementCrown : Item
	{
		public JudgementCrown() : base()
		{
			Id = 16955;
			Resistance[0] = 696;
			Bonding = 1;
			SellPrice = 42472;
			AvailableClasses = 0x02;
			Model = 29881;
			Resistance[4] = 10;
			ObjectClass = 4;
			SubClass = 4;
			Level = 76;
			ReqLevel = 60;
			Name = "Judgement Crown";
			Name2 = "Judgement Crown";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 212361;
			Sets = 217;
			Resistance[5] = 10;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 6;
			Durability = 100;
			SetSpell( 18033 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 29;
			IqBonus = 17;
			StaminaBonus = 21;
		}
	}
}


/**************************************************************
*
*				(Helm of Wrath)
*
***************************************************************/

namespace Server.Items
{
	public class HelmOfWrath : Item
	{
		public HelmOfWrath() : base()
		{
			Id = 16963;
			Resistance[0] = 696;
			Bonding = 1;
			SellPrice = 44900;
			AvailableClasses = 0x01;
			Model = 29865;
			Resistance[4] = 10;
			ObjectClass = 4;
			SubClass = 4;
			Level = 76;
			ReqLevel = 60;
			Name = "Helm of Wrath";
			Name2 = "Helm of Wrath";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 224501;
			Sets = 218;
			Resistance[5] = 10;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 6;
			Durability = 100;
			SetSpell( 18185 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 40;
			StrBonus = 17;
		}
	}
}


/**************************************************************
*
*				(Helm of the Mountain)
*
***************************************************************/

namespace Server.Items
{
	public class HelmOfTheMountain : Item
	{
		public HelmOfTheMountain() : base()
		{
			Id = 17734;
			Resistance[0] = 683;
			Bonding = 1;
			SellPrice = 10457;
			AvailableClasses = 0x7FFF;
			Model = 29911;
			ObjectClass = 4;
			SubClass = 4;
			Level = 53;
			ReqLevel = 48;
			Name = "Helm of the Mountain";
			Name2 = "Helm of the Mountain";
			Resistance[3] = 10;
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 52285;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 6;
			Durability = 80;
			SetSpell( 13385 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Helm of Awareness)
*
***************************************************************/

namespace Server.Items
{
	public class HelmOfAwareness : Item
	{
		public HelmOfAwareness() : base()
		{
			Id = 18313;
			Resistance[0] = 493;
			Bonding = 1;
			SellPrice = 13694;
			AvailableClasses = 0x7FFF;
			Model = 30677;
			ObjectClass = 4;
			SubClass = 4;
			Level = 58;
			ReqLevel = 53;
			Name = "Helm of Awareness";
			Name2 = "Helm of Awareness";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 68474;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 6;
			Durability = 80;
			SetSpell( 13670 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 17;
		}
	}
}


/**************************************************************
*
*				(Scarab Plate Helm)
*
***************************************************************/

namespace Server.Items
{
	public class ScarabPlateHelm : Item
	{
		public ScarabPlateHelm() : base()
		{
			Id = 18480;
			Resistance[0] = 463;
			Bonding = 1;
			SellPrice = 11860;
			AvailableClasses = 0x7FFF;
			Model = 30821;
			ObjectClass = 4;
			SubClass = 4;
			Level = 60;
			ReqLevel = 55;
			Name = "Scarab Plate Helm";
			Name2 = "Scarab Plate Helm";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 59304;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 6;
			Durability = 70;
			SpiritBonus = 20;
			StaminaBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Grand Crusader's Helm)
*
***************************************************************/

namespace Server.Items
{
	public class GrandCrusadersHelm : Item
	{
		public GrandCrusadersHelm() : base()
		{
			Id = 18718;
			Resistance[0] = 584;
			Bonding = 1;
			SellPrice = 16580;
			AvailableClasses = 0x7FFF;
			Model = 31167;
			ObjectClass = 4;
			SubClass = 4;
			Level = 63;
			ReqLevel = 58;
			Name = "Grand Crusader's Helm";
			Name2 = "Grand Crusader's Helm";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 82901;
			Resistance[5] = 15;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 6;
			Durability = 80;
			StrBonus = 16;
			StaminaBonus = 16;
			IqBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Dark Iron Helm)
*
***************************************************************/

namespace Server.Items
{
	public class DarkIronHelm : Item
	{
		public DarkIronHelm() : base()
		{
			Id = 19148;
			Resistance[0] = 758;
			Bonding = 2;
			SellPrice = 25399;
			AvailableClasses = 0x7FFF;
			Model = 31671;
			Resistance[2] = 35;
			ObjectClass = 4;
			SubClass = 4;
			Level = 66;
			ReqLevel = 60;
			Name = "Dark Iron Helm";
			Name2 = "Dark Iron Helm";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 126998;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 6;
			Durability = 100;
			StaminaBonus = 20;
		}
	}
}


/**************************************************************
*
*				(Helm of Endless Rage)
*
***************************************************************/

namespace Server.Items
{
	public class HelmOfEndlessRage : Item
	{
		public HelmOfEndlessRage() : base()
		{
			Id = 19372;
			Resistance[0] = 679;
			Bonding = 1;
			SellPrice = 41178;
			AvailableClasses = 0x7FFF;
			Model = 31891;
			ObjectClass = 4;
			SubClass = 4;
			Level = 74;
			ReqLevel = 60;
			Name = "Helm of Endless Rage";
			Name2 = "Helm of Endless Rage";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 205894;
			InventoryType = InventoryTypes.Head;
			Stackable = 1;
			Material = 6;
			Durability = 100;
			StrBonus = 26;
			AgilityBonus = 26;
			StaminaBonus = 29;
		}
	}
}


