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
*				(Heavy Mithril Gauntlet)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyMithrilGauntlet : Item
	{
		public HeavyMithrilGauntlet() : base()
		{
			Id = 7919;
			Resistance[0] = 268;
			Bonding = 2;
			SellPrice = 2476;
			AvailableClasses = 0x7FFF;
			Model = 16091;
			ObjectClass = 4;
			SubClass = 4;
			Level = 41;
			ReqLevel = 40;
			Name = "Heavy Mithril Gauntlet";
			Name2 = "Heavy Mithril Gauntlet";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 12382;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 40;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Ornate Mithril Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class OrnateMithrilGloves : Item
	{
		public OrnateMithrilGloves() : base()
		{
			Id = 7927;
			Resistance[0] = 268;
			Bonding = 2;
			SellPrice = 2987;
			AvailableClasses = 0x7FFF;
			Model = 16105;
			ObjectClass = 4;
			SubClass = 4;
			Level = 44;
			ReqLevel = 40;
			Name = "Ornate Mithril Gloves";
			Name2 = "Ornate Mithril Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 14935;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 40;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Truesilver Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class TruesilverGauntlets : Item
	{
		public TruesilverGauntlets() : base()
		{
			Id = 7938;
			Resistance[0] = 300;
			Bonding = 2;
			SellPrice = 4028;
			AvailableClasses = 0x7FFF;
			Model = 16124;
			ObjectClass = 4;
			SubClass = 4;
			Level = 45;
			ReqLevel = 40;
			Name = "Truesilver Gauntlets";
			Name2 = "Truesilver Gauntlets";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 20142;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 45;
			StrBonus = 16;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Light Plate Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class LightPlateGloves : Item
	{
		public LightPlateGloves() : base()
		{
			Id = 8084;
			Resistance[0] = 300;
			SellPrice = 2703;
			AvailableClasses = 0x7FFF;
			Model = 28401;
			ObjectClass = 4;
			SubClass = 4;
			Level = 56;
			ReqLevel = 51;
			Name = "Light Plate Gloves";
			Name2 = "Light Plate Gloves";
			AvailableRaces = 0x1FF;
			BuyPrice = 13517;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Platemail Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class PlatemailGloves : Item
	{
		public PlatemailGloves() : base()
		{
			Id = 8091;
			Resistance[0] = 285;
			SellPrice = 2697;
			AvailableClasses = 0x7FFF;
			Model = 28397;
			ObjectClass = 4;
			SubClass = 4;
			Level = 50;
			ReqLevel = 45;
			Name = "Platemail Gloves";
			Name2 = "Platemail Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 13489;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Chromite Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class ChromiteGauntlets : Item
	{
		public ChromiteGauntlets() : base()
		{
			Id = 8139;
			Resistance[0] = 268;
			Bonding = 2;
			SellPrice = 3053;
			AvailableClasses = 0x7FFF;
			Model = 27331;
			ObjectClass = 4;
			SubClass = 4;
			Level = 44;
			ReqLevel = 40;
			Name = "Chromite Gauntlets";
			Name2 = "Chromite Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 15269;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 40;
			StrBonus = 12;
			AgilityBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Jouster's Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class JoustersGauntlets : Item
	{
		public JoustersGauntlets() : base()
		{
			Id = 8158;
			Resistance[0] = 166;
			Bonding = 2;
			SellPrice = 2236;
			AvailableClasses = 0x7FFF;
			Model = 27341;
			ObjectClass = 4;
			SubClass = 4;
			Level = 40;
			ReqLevel = 40;
			Name = "Jouster's Gauntlets";
			Name2 = "Jouster's Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11181;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 40;
			StrBonus = 11;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Valorous Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class ValorousGauntlets : Item
	{
		public ValorousGauntlets() : base()
		{
			Id = 8276;
			Resistance[0] = 284;
			Bonding = 2;
			SellPrice = 3901;
			AvailableClasses = 0x7FFF;
			Model = 27374;
			ObjectClass = 4;
			SubClass = 4;
			Level = 47;
			ReqLevel = 42;
			Name = "Valorous Gauntlets";
			Name2 = "Valorous Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 19509;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 40;
			StrBonus = 14;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Alabaster Plate Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class AlabasterPlateGauntlets : Item
	{
		public AlabasterPlateGauntlets() : base()
		{
			Id = 8314;
			Resistance[0] = 317;
			Bonding = 2;
			SellPrice = 5344;
			AvailableClasses = 0x7FFF;
			Model = 27390;
			ObjectClass = 4;
			SubClass = 4;
			Level = 53;
			ReqLevel = 48;
			Name = "Alabaster Plate Gauntlets";
			Name2 = "Alabaster Plate Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 26721;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 40;
			StrBonus = 14;
			AgilityBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Field Plate Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class FieldPlateGauntlets : Item
	{
		public FieldPlateGauntlets() : base()
		{
			Id = 9287;
			Resistance[0] = 188;
			Bonding = 2;
			SellPrice = 2406;
			AvailableClasses = 0x7FFF;
			Model = 27358;
			ObjectClass = 4;
			SubClass = 4;
			Level = 41;
			ReqLevel = 40;
			Name = "Field Plate Gauntlets";
			Name2 = "Field Plate Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 779;
			BuyPrice = 12031;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Cragfists)
*
***************************************************************/

namespace Server.Items
{
	public class Cragfists : Item
	{
		public Cragfists() : base()
		{
			Id = 9410;
			Resistance[0] = 300;
			Bonding = 1;
			SellPrice = 3785;
			AvailableClasses = 0x7FFF;
			Model = 29000;
			ObjectClass = 4;
			SubClass = 4;
			Level = 45;
			ReqLevel = 40;
			Name = "Cragfists";
			Name2 = "Cragfists";
			Quality = 3;
			AvailableRaces = 0x1FF;
			Extra = 782;
			BuyPrice = 18925;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 45;
			SetSpell( 7518 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Vice Grips)
*
***************************************************************/

namespace Server.Items
{
	public class ViceGrips : Item
	{
		public ViceGrips() : base()
		{
			Id = 9640;
			Resistance[0] = 318;
			Bonding = 1;
			SellPrice = 4840;
			AvailableClasses = 0x7FFF;
			Model = 18573;
			ObjectClass = 4;
			SubClass = 4;
			Level = 48;
			ReqLevel = 43;
			Name = "Vice Grips";
			Name2 = "Vice Grips";
			Quality = 3;
			AvailableRaces = 0x1FF;
			Extra = 783;
			BuyPrice = 24201;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 45;
			SetSpell( 9142 , 1 , 0 , 0 , 0 , 0 );
		}
	}
}


/**************************************************************
*
*				(Granite Grips)
*
***************************************************************/

namespace Server.Items
{
	public class GraniteGrips : Item
	{
		public GraniteGrips() : base()
		{
			Id = 9656;
			Resistance[0] = 295;
			Bonding = 1;
			SellPrice = 4251;
			AvailableClasses = 0x7FFF;
			Model = 18580;
			ObjectClass = 4;
			SubClass = 4;
			Level = 49;
			Name = "Granite Grips";
			Name2 = "Granite Grips";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 21256;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 40;
			StrBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Embossed Plate Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class EmbossedPlateGauntlets : Item
	{
		public EmbossedPlateGauntlets() : base()
		{
			Id = 9967;
			Resistance[0] = 239;
			Bonding = 2;
			SellPrice = 2900;
			AvailableClasses = 0x7FFF;
			Model = 27351;
			ObjectClass = 4;
			SubClass = 4;
			Level = 43;
			ReqLevel = 40;
			Name = "Embossed Plate Gauntlets";
			Name2 = "Embossed Plate Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 780;
			BuyPrice = 14503;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Gothic Plate Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class GothicPlateGauntlets : Item
	{
		public GothicPlateGauntlets() : base()
		{
			Id = 10087;
			Resistance[0] = 278;
			Bonding = 2;
			SellPrice = 3393;
			AvailableClasses = 0x7FFF;
			Model = 27364;
			ObjectClass = 4;
			SubClass = 4;
			Level = 46;
			ReqLevel = 41;
			Name = "Gothic Plate Gauntlets";
			Name2 = "Gothic Plate Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 781;
			BuyPrice = 16968;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Revenant Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class RevenantGauntlets : Item
	{
		public RevenantGauntlets() : base()
		{
			Id = 10129;
			Resistance[0] = 300;
			Bonding = 2;
			SellPrice = 4689;
			AvailableClasses = 0x7FFF;
			Model = 27428;
			ObjectClass = 4;
			SubClass = 4;
			Level = 50;
			ReqLevel = 45;
			Name = "Revenant Gauntlets";
			Name2 = "Revenant Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 782;
			BuyPrice = 23445;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Templar Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class TemplarGauntlets : Item
	{
		public TemplarGauntlets() : base()
		{
			Id = 10165;
			Resistance[0] = 328;
			Bonding = 2;
			SellPrice = 6240;
			AvailableClasses = 0x7FFF;
			Model = 29014;
			ObjectClass = 4;
			SubClass = 4;
			Level = 55;
			ReqLevel = 50;
			Name = "Templar Gauntlets";
			Name2 = "Templar Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 784;
			BuyPrice = 31200;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Overlord's Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class OverlordsGauntlets : Item
	{
		public OverlordsGauntlets() : base()
		{
			Id = 10205;
			Resistance[0] = 295;
			Bonding = 2;
			SellPrice = 4316;
			AvailableClasses = 0x7FFF;
			Model = 27398;
			ObjectClass = 4;
			SubClass = 4;
			Level = 49;
			ReqLevel = 44;
			Name = "Overlord's Gauntlets";
			Name2 = "Overlord's Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 782;
			BuyPrice = 21580;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Heavy Lamellar Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyLamellarGauntlets : Item
	{
		public HeavyLamellarGauntlets() : base()
		{
			Id = 10242;
			Resistance[0] = 311;
			Bonding = 2;
			SellPrice = 5318;
			AvailableClasses = 0x7FFF;
			Model = 27381;
			ObjectClass = 4;
			SubClass = 4;
			Level = 52;
			ReqLevel = 47;
			Name = "Heavy Lamellar Gauntlets";
			Name2 = "Heavy Lamellar Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 783;
			BuyPrice = 26592;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Emerald Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class EmeraldGauntlets : Item
	{
		public EmeraldGauntlets() : base()
		{
			Id = 10277;
			Resistance[0] = 339;
			Bonding = 2;
			SellPrice = 6985;
			AvailableClasses = 0x7FFF;
			Model = 29003;
			ObjectClass = 4;
			SubClass = 4;
			Level = 57;
			ReqLevel = 52;
			Name = "Emerald Gauntlets";
			Name2 = "Emerald Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 784;
			BuyPrice = 34926;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Imbued Plate Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class ImbuedPlateGauntlets : Item
	{
		public ImbuedPlateGauntlets() : base()
		{
			Id = 10369;
			Resistance[0] = 345;
			Bonding = 2;
			SellPrice = 7377;
			AvailableClasses = 0x7FFF;
			Model = 26352;
			ObjectClass = 4;
			SubClass = 4;
			Level = 58;
			ReqLevel = 53;
			Name = "Imbued Plate Gauntlets";
			Name2 = "Imbued Plate Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 36886;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 40;
			StrBonus = 18;
			StaminaBonus = 3;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Commander's Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class CommandersGauntlets : Item
	{
		public CommandersGauntlets() : base()
		{
			Id = 10380;
			Resistance[0] = 356;
			Bonding = 2;
			SellPrice = 8468;
			AvailableClasses = 0x7FFF;
			Model = 26334;
			ObjectClass = 4;
			SubClass = 4;
			Level = 60;
			ReqLevel = 55;
			Name = "Commander's Gauntlets";
			Name2 = "Commander's Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 785;
			BuyPrice = 42342;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Hyperion Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class HyperionGauntlets : Item
	{
		public HyperionGauntlets() : base()
		{
			Id = 10386;
			Resistance[0] = 368;
			Bonding = 2;
			SellPrice = 8865;
			AvailableClasses = 0x7FFF;
			Model = 26339;
			ObjectClass = 4;
			SubClass = 4;
			Level = 62;
			ReqLevel = 57;
			Name = "Hyperion Gauntlets";
			Name2 = "Hyperion Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 786;
			BuyPrice = 44329;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Fists of Phalanx)
*
***************************************************************/

namespace Server.Items
{
	public class FistsOfPhalanx : Item
	{
		public FistsOfPhalanx() : base()
		{
			Id = 11745;
			Resistance[0] = 334;
			Bonding = 1;
			SellPrice = 6565;
			AvailableClasses = 0x7FFF;
			Model = 28740;
			ObjectClass = 4;
			SubClass = 4;
			Level = 56;
			ReqLevel = 51;
			Name = "Fists of Phalanx";
			Name2 = "Fists of Phalanx";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 32825;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 40;
			StrBonus = 17;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Lavaplate Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class LavaplateGauntlets : Item
	{
		public LavaplateGauntlets() : base()
		{
			Id = 12111;
			Resistance[0] = 345;
			Bonding = 1;
			SellPrice = 7768;
			AvailableClasses = 0x7FFF;
			Model = 28202;
			ObjectClass = 4;
			SubClass = 4;
			Level = 58;
			Name = "Lavaplate Gauntlets";
			Name2 = "Lavaplate Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 38841;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 40;
			StrBonus = 17;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Fiery Plate Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class FieryPlateGauntlets : Item
	{
		public FieryPlateGauntlets() : base()
		{
			Id = 12631;
			Resistance[0] = 379;
			Bonding = 2;
			SellPrice = 8919;
			AvailableClasses = 0x7FFF;
			Model = 25747;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 4;
			Level = 58;
			ReqLevel = 53;
			Name = "Fiery Plate Gauntlets";
			Name2 = "Fiery Plate Gauntlets";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 44598;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 45;
			SetSpell( 7721 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Backusarian Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class BackusarianGauntlets : Item
	{
		public BackusarianGauntlets() : base()
		{
			Id = 12637;
			Resistance[0] = 392;
			Bonding = 1;
			SellPrice = 10316;
			AvailableClasses = 0x7FFF;
			Model = 22910;
			ObjectClass = 4;
			SubClass = 4;
			Level = 60;
			ReqLevel = 55;
			Name = "Backusarian Gauntlets";
			Name2 = "Backusarian Gauntlets";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 51582;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 45;
			StrBonus = 9;
			IqBonus = 14;
			StaminaBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Stronghold Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class StrongholdGauntlets : Item
	{
		public StrongholdGauntlets() : base()
		{
			Id = 12639;
			Resistance[0] = 441;
			Bonding = 2;
			SellPrice = 15271;
			AvailableClasses = 0x7FFF;
			Model = 25750;
			ObjectClass = 4;
			SubClass = 4;
			Level = 62;
			ReqLevel = 57;
			Name = "Stronghold Gauntlets";
			Name2 = "Stronghold Gauntlets";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 76359;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 55;
			SetSpell( 7219 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 13665 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Plated Fist of Hakoo)
*
***************************************************************/

namespace Server.Items
{
	public class PlatedFistOfHakoo : Item
	{
		public PlatedFistOfHakoo() : base()
		{
			Id = 13071;
			Resistance[0] = 300;
			Bonding = 2;
			SellPrice = 4061;
			AvailableClasses = 0x7FFF;
			Model = 28354;
			ObjectClass = 4;
			SubClass = 4;
			Level = 45;
			ReqLevel = 40;
			Name = "Plated Fist of Hakoo";
			Name2 = "Plated Fist of Hakoo";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 20308;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 45;
			StrBonus = 10;
			AgilityBonus = 10;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Stonegrip Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class StonegripGauntlets : Item
	{
		public StonegripGauntlets() : base()
		{
			Id = 13072;
			Resistance[0] = 392;
			Bonding = 2;
			SellPrice = 10426;
			AvailableClasses = 0x7FFF;
			Model = 28352;
			ObjectClass = 4;
			SubClass = 4;
			Level = 60;
			ReqLevel = 55;
			Name = "Stonegrip Gauntlets";
			Name2 = "Stonegrip Gauntlets";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 52134;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 45;
			SetSpell( 13390 , 1 , 0 , -1 , 0 , -1 );
			StrBonus = 9;
			StaminaBonus = 14;
		}
	}
}


/**************************************************************
*
*				(Reiver Claws)
*
***************************************************************/

namespace Server.Items
{
	public class ReiverClaws : Item
	{
		public ReiverClaws() : base()
		{
			Id = 13162;
			Resistance[0] = 398;
			Bonding = 1;
			SellPrice = 10558;
			AvailableClasses = 0x7FFF;
			Model = 23675;
			ObjectClass = 4;
			SubClass = 4;
			Level = 61;
			ReqLevel = 56;
			Name = "Reiver Claws";
			Name2 = "Reiver Claws";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 52793;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 45;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 15;
			StrBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Banshee's Touch)
*
***************************************************************/

namespace Server.Items
{
	public class BansheesTouch : Item
	{
		public BansheesTouch() : base()
		{
			Id = 13539;
			Resistance[6] = 13;
			Resistance[0] = 356;
			Bonding = 1;
			SellPrice = 8535;
			AvailableClasses = 0x7FFF;
			Model = 24194;
			Resistance[4] = 13;
			ObjectClass = 4;
			SubClass = 4;
			Level = 60;
			ReqLevel = 55;
			Name = "Banshee's Touch";
			Name2 = "Banshee's Touch";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 42677;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Boneclenched Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class BoneclenchedGauntlets : Item
	{
		public BoneclenchedGauntlets() : base()
		{
			Id = 14525;
			Resistance[0] = 624;
			Bonding = 1;
			SellPrice = 10561;
			AvailableClasses = 0x7FFF;
			Model = 25116;
			Resistance[4] = 10;
			ObjectClass = 4;
			SubClass = 4;
			Level = 62;
			ReqLevel = 57;
			Name = "Boneclenched Gauntlets";
			Name2 = "Boneclenched Gauntlets";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 52805;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 45;
		}
	}
}


/**************************************************************
*
*				(Deathbone Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class DeathboneGauntlets : Item
	{
		public DeathboneGauntlets() : base()
		{
			Id = 14622;
			Resistance[0] = 362;
			Bonding = 1;
			SellPrice = 8510;
			AvailableClasses = 0x7FFF;
			Model = 25224;
			ObjectClass = 4;
			SubClass = 4;
			Level = 61;
			ReqLevel = 56;
			Name = "Deathbone Gauntlets";
			Name2 = "Deathbone Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 42553;
			Sets = 124;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 40;
			StrBonus = 15;
			StaminaBonus = 8;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Symbolic Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class SymbolicGauntlets : Item
	{
		public SymbolicGauntlets() : base()
		{
			Id = 14826;
			Resistance[0] = 188;
			Bonding = 2;
			SellPrice = 2311;
			AvailableClasses = 0x7FFF;
			Model = 26812;
			ObjectClass = 4;
			SubClass = 4;
			Level = 41;
			ReqLevel = 40;
			Name = "Symbolic Gauntlets";
			Name2 = "Symbolic Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11557;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 40;
			StrBonus = 9;
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Tyrant's Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class TyrantsGauntlets : Item
	{
		public TyrantsGauntlets() : base()
		{
			Id = 14833;
			Resistance[0] = 268;
			Bonding = 2;
			SellPrice = 2988;
			AvailableClasses = 0x7FFF;
			Model = 29015;
			ObjectClass = 4;
			SubClass = 4;
			Level = 44;
			ReqLevel = 40;
			Name = "Tyrant's Gauntlets";
			Name2 = "Tyrant's Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 14944;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 40;
			StrBonus = 12;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Sunscale Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class SunscaleGauntlets : Item
	{
		public SunscaleGauntlets() : base()
		{
			Id = 14846;
			Resistance[0] = 300;
			Bonding = 2;
			SellPrice = 4534;
			AvailableClasses = 0x7FFF;
			Model = 27190;
			ObjectClass = 4;
			SubClass = 4;
			Level = 50;
			ReqLevel = 45;
			Name = "Sunscale Gauntlets";
			Name2 = "Sunscale Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 22673;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 40;
			StrBonus = 12;
			StaminaBonus = 7;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Vanguard Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class VanguardGauntlets : Item
	{
		public VanguardGauntlets() : base()
		{
			Id = 14855;
			Resistance[0] = 328;
			Bonding = 2;
			SellPrice = 6502;
			AvailableClasses = 0x7FFF;
			Model = 26847;
			ObjectClass = 4;
			SubClass = 4;
			Level = 55;
			ReqLevel = 50;
			Name = "Vanguard Gauntlets";
			Name2 = "Vanguard Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 32510;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 40;
			StaminaBonus = 12;
			IqBonus = 6;
			AgilityBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Warleader's Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class WarleadersGauntlets : Item
	{
		public WarleadersGauntlets() : base()
		{
			Id = 14863;
			Resistance[0] = 356;
			Bonding = 2;
			SellPrice = 7951;
			AvailableClasses = 0x7FFF;
			Model = 26881;
			ObjectClass = 4;
			SubClass = 4;
			Level = 60;
			ReqLevel = 55;
			Name = "Warleader's Gauntlets";
			Name2 = "Warleader's Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 39759;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 40;
			StrBonus = 17;
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Saltstone Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class SaltstoneGauntlets : Item
	{
		public SaltstoneGauntlets() : base()
		{
			Id = 14897;
			Resistance[0] = 166;
			Bonding = 2;
			SellPrice = 2286;
			AvailableClasses = 0x7FFF;
			Model = 27838;
			ObjectClass = 4;
			SubClass = 4;
			Level = 40;
			ReqLevel = 40;
			Name = "Saltstone Gauntlets";
			Name2 = "Saltstone Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 779;
			BuyPrice = 11434;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Brutish Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class BrutishGauntlets : Item
	{
		public BrutishGauntlets() : base()
		{
			Id = 14905;
			Resistance[0] = 273;
			Bonding = 2;
			SellPrice = 3217;
			AvailableClasses = 0x7FFF;
			Model = 27901;
			ObjectClass = 4;
			SubClass = 4;
			Level = 45;
			ReqLevel = 40;
			Name = "Brutish Gauntlets";
			Name2 = "Brutish Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 780;
			BuyPrice = 16086;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Jade Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class JadeGauntlets : Item
	{
		public JadeGauntlets() : base()
		{
			Id = 14917;
			Resistance[0] = 289;
			Bonding = 2;
			SellPrice = 3931;
			AvailableClasses = 0x7FFF;
			Model = 26798;
			ObjectClass = 4;
			SubClass = 4;
			Level = 48;
			ReqLevel = 43;
			Name = "Jade Gauntlets";
			Name2 = "Jade Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 781;
			BuyPrice = 19659;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Lofty Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class LoftyGauntlets : Item
	{
		public LoftyGauntlets() : base()
		{
			Id = 14926;
			Resistance[0] = 317;
			Bonding = 2;
			SellPrice = 5598;
			AvailableClasses = 0x7FFF;
			Model = 26872;
			ObjectClass = 4;
			SubClass = 4;
			Level = 53;
			ReqLevel = 48;
			Name = "Lofty Gauntlets";
			Name2 = "Lofty Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 783;
			BuyPrice = 27991;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Heroic Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class HeroicGauntlets : Item
	{
		public HeroicGauntlets() : base()
		{
			Id = 14933;
			Resistance[0] = 345;
			Bonding = 2;
			SellPrice = 7884;
			AvailableClasses = 0x7FFF;
			Model = 27934;
			ObjectClass = 4;
			SubClass = 4;
			Level = 58;
			ReqLevel = 53;
			Name = "Heroic Gauntlets";
			Name2 = "Heroic Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 785;
			BuyPrice = 39420;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Warbringer's Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class WarbringersGauntlets : Item
	{
		public WarbringersGauntlets() : base()
		{
			Id = 14942;
			Resistance[0] = 212;
			Bonding = 2;
			SellPrice = 2524;
			AvailableClasses = 0x7FFF;
			Model = 26640;
			ObjectClass = 4;
			SubClass = 4;
			Level = 42;
			ReqLevel = 40;
			Name = "Warbringer's Gauntlets";
			Name2 = "Warbringer's Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 779;
			BuyPrice = 12624;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Bloodforged Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class BloodforgedGauntlets : Item
	{
		public BloodforgedGauntlets() : base()
		{
			Id = 14949;
			Resistance[0] = 284;
			Bonding = 2;
			SellPrice = 3907;
			AvailableClasses = 0x7FFF;
			Model = 28996;
			ObjectClass = 4;
			SubClass = 4;
			Level = 47;
			ReqLevel = 42;
			Name = "Bloodforged Gauntlets";
			Name2 = "Bloodforged Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 781;
			BuyPrice = 19535;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(High Chief's Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class HighChiefsGauntlets : Item
	{
		public HighChiefsGauntlets() : base()
		{
			Id = 14959;
			Resistance[0] = 311;
			Bonding = 2;
			SellPrice = 5143;
			AvailableClasses = 0x7FFF;
			Model = 26830;
			ObjectClass = 4;
			SubClass = 4;
			Level = 52;
			ReqLevel = 47;
			Name = "High Chief's Gauntlets";
			Name2 = "High Chief's Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 783;
			BuyPrice = 25717;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Glorious Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class GloriousGauntlets : Item
	{
		public GloriousGauntlets() : base()
		{
			Id = 14967;
			Resistance[0] = 334;
			Bonding = 2;
			SellPrice = 6867;
			AvailableClasses = 0x7FFF;
			Model = 27833;
			ObjectClass = 4;
			SubClass = 4;
			Level = 56;
			ReqLevel = 51;
			Name = "Glorious Gauntlets";
			Name2 = "Glorious Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 784;
			BuyPrice = 34337;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Exalted Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class ExaltedGauntlets : Item
	{
		public ExaltedGauntlets() : base()
		{
			Id = 14976;
			Resistance[0] = 362;
			Bonding = 2;
			SellPrice = 8349;
			AvailableClasses = 0x7FFF;
			Model = 26888;
			ObjectClass = 4;
			SubClass = 4;
			Level = 61;
			ReqLevel = 56;
			Name = "Exalted Gauntlets";
			Name2 = "Exalted Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 786;
			BuyPrice = 41748;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 40;
		}
	}
}


/**************************************************************
*
*				(Emerald Mist Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class EmeraldMistGauntlets : Item
	{
		public EmeraldMistGauntlets() : base()
		{
			Id = 15795;
			Resistance[0] = 345;
			Bonding = 1;
			SellPrice = 7631;
			AvailableClasses = 0x7FFF;
			Model = 26473;
			ObjectClass = 4;
			SubClass = 4;
			Level = 58;
			Name = "Emerald Mist Gauntlets";
			Name2 = "Emerald Mist Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 38157;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 40;
			StrBonus = 12;
			StaminaBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Knight-Lieutenant's Plate Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class KnightLieutenantsPlateGauntlets : Item
	{
		public KnightLieutenantsPlateGauntlets() : base()
		{
			Id = 16406;
			Resistance[0] = 410;
			Bonding = 1;
			SellPrice = 5545;
			AvailableClasses = 0x01;
			Model = 31086;
			ObjectClass = 4;
			SubClass = 4;
			Level = 63;
			ReqLevel = 58;
			Name = "Knight-Lieutenant's Plate Gauntlets";
			Name2 = "Knight-Lieutenant's Plate Gauntlets";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 27728;
			Sets = 282;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			MaxCount = 1;
			Material = 6;
			Durability = 45;
			Flags = 32768;
			SetSpell( 22778 , 1 , 0 , -1 , 0 , -1 );
			StrBonus = 16;
			StaminaBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Knight-Lieutenant's Lamellar Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class KnightLieutenantsLamellarGauntlets : Item
	{
		public KnightLieutenantsLamellarGauntlets() : base()
		{
			Id = 16410;
			Resistance[0] = 410;
			Bonding = 1;
			SellPrice = 5630;
			AvailableClasses = 0x02;
			Model = 30321;
			ObjectClass = 4;
			SubClass = 4;
			Level = 63;
			ReqLevel = 58;
			Name = "Knight-Lieutenant's Lamellar Gauntlets";
			Name2 = "Knight-Lieutenant's Lamellar Gauntlets";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 28152;
			Sets = 401;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			MaxCount = 1;
			Material = 6;
			Durability = 45;
			Flags = 32768;
			SetSpell( 23300 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 16;
			StrBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Marshal's Lamellar Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class MarshalsLamellarGloves : Item
	{
		public MarshalsLamellarGloves() : base()
		{
			Id = 16471;
			Resistance[0] = 461;
			Bonding = 1;
			SellPrice = 8528;
			AvailableClasses = 0x02;
			Model = 30321;
			ObjectClass = 4;
			SubClass = 4;
			Level = 65;
			ReqLevel = 60;
			Name = "Marshal's Lamellar Gloves";
			Name2 = "Marshal's Lamellar Gloves";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 42644;
			Sets = 402;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			MaxCount = 1;
			Material = 6;
			Durability = 55;
			Flags = 32768;
			SetSpell( 23300 , 1 , 0 , -1 , 0 , -1 );
			StrBonus = 20;
			StaminaBonus = 16;
			AgilityBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Marshal's Plate Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class MarshalsPlateGauntlets : Item
	{
		public MarshalsPlateGauntlets() : base()
		{
			Id = 16484;
			Resistance[0] = 461;
			Bonding = 1;
			SellPrice = 8309;
			AvailableClasses = 0x01;
			Model = 30321;
			ObjectClass = 4;
			SubClass = 4;
			Level = 65;
			ReqLevel = 60;
			Name = "Marshal's Plate Gauntlets";
			Name2 = "Marshal's Plate Gauntlets";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 41548;
			Sets = 384;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			MaxCount = 1;
			Material = 6;
			Durability = 55;
			Flags = 32768;
			SetSpell( 22778 , 1 , 0 , -1 , 0 , -1 );
			StrBonus = 18;
			StaminaBonus = 17;
			AgilityBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Blood Guard's Plate Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class BloodGuardsPlateGloves : Item
	{
		public BloodGuardsPlateGloves() : base()
		{
			Id = 16510;
			Resistance[0] = 410;
			Bonding = 1;
			SellPrice = 5931;
			AvailableClasses = 0x01;
			Model = 31051;
			ObjectClass = 4;
			SubClass = 4;
			Level = 63;
			ReqLevel = 58;
			Name = "Blood Guard's Plate Gloves";
			Name2 = "Blood Guard's Plate Gloves";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 29657;
			Sets = 281;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			MaxCount = 1;
			Material = 6;
			Durability = 45;
			Flags = 32768;
			SetSpell( 22778 , 1 , 0 , -1 , 0 , -1 );
			StrBonus = 16;
			StaminaBonus = 15;
		}
	}
}


/**************************************************************
*
*				(General's Plate Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class GeneralsPlateGauntlets : Item
	{
		public GeneralsPlateGauntlets() : base()
		{
			Id = 16548;
			Resistance[0] = 461;
			Bonding = 1;
			SellPrice = 8655;
			AvailableClasses = 0x01;
			Model = 30371;
			ObjectClass = 4;
			SubClass = 4;
			Level = 65;
			ReqLevel = 60;
			Name = "General's Plate Gauntlets";
			Name2 = "General's Plate Gauntlets";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 43275;
			Sets = 383;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			MaxCount = 1;
			Material = 6;
			Durability = 55;
			Flags = 32768;
			SetSpell( 22778 , 1 , 0 , -1 , 0 , -1 );
			StrBonus = 18;
			StaminaBonus = 17;
			AgilityBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Lightforge Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class LightforgeGauntlets : Item
	{
		public LightforgeGauntlets() : base()
		{
			Id = 16724;
			Resistance[0] = 386;
			Bonding = 1;
			SellPrice = 9091;
			AvailableClasses = 0x7FFF;
			Model = 29970;
			ObjectClass = 4;
			SubClass = 4;
			Level = 59;
			ReqLevel = 54;
			Name = "Lightforge Gauntlets";
			Name2 = "Lightforge Gauntlets";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 45459;
			Sets = 188;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 45;
			IqBonus = 14;
			StrBonus = 14;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Gauntlets of Valor)
*
***************************************************************/

namespace Server.Items
{
	public class GauntletsOfValor : Item
	{
		public GauntletsOfValor() : base()
		{
			Id = 16737;
			Resistance[0] = 386;
			Bonding = 1;
			SellPrice = 9794;
			AvailableClasses = 0x7FFF;
			Model = 29962;
			ObjectClass = 4;
			SubClass = 4;
			Level = 59;
			ReqLevel = 54;
			Name = "Gauntlets of Valor";
			Name2 = "Gauntlets of Valor";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 48974;
			Sets = 189;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 45;
			StrBonus = 17;
			StaminaBonus = 10;
			IqBonus = 8;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Lawbringer Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class LawbringerGauntlets : Item
	{
		public LawbringerGauntlets() : base()
		{
			Id = 16860;
			Resistance[0] = 468;
			Bonding = 1;
			SellPrice = 17249;
			AvailableClasses = 0x02;
			Model = 31507;
			Resistance[2] = 7;
			ObjectClass = 4;
			SubClass = 4;
			Level = 66;
			ReqLevel = 60;
			Name = "Lawbringer Gauntlets";
			Name2 = "Lawbringer Gauntlets";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 86247;
			Sets = 208;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 55;
			SetSpell( 9406 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 15;
			IqBonus = 14;
			StaminaBonus = 15;
			StrBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Gauntlets of Might)
*
***************************************************************/

namespace Server.Items
{
	public class GauntletsOfMight : Item
	{
		public GauntletsOfMight() : base()
		{
			Id = 16863;
			Resistance[0] = 468;
			Bonding = 1;
			SellPrice = 17917;
			AvailableClasses = 0x01;
			Model = 31022;
			Resistance[2] = 7;
			ObjectClass = 4;
			SubClass = 4;
			Level = 66;
			ReqLevel = 60;
			Name = "Gauntlets of Might";
			Name2 = "Gauntlets of Might";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 89589;
			Sets = 209;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 55;
			SetSpell( 15464 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 13383 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 17;
			StrBonus = 22;
		}
	}
}


/**************************************************************
*
*				(Judgement Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class JudgementGauntlets : Item
	{
		public JudgementGauntlets() : base()
		{
			Id = 16956;
			Resistance[0] = 535;
			Bonding = 1;
			SellPrice = 28422;
			AvailableClasses = 0x02;
			Model = 29877;
			ObjectClass = 4;
			SubClass = 4;
			Level = 76;
			ReqLevel = 60;
			Name = "Judgement Gauntlets";
			Name2 = "Judgement Gauntlets";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 142110;
			Sets = 217;
			Resistance[5] = 10;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 55;
			SetSpell( 21626 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 9314 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 20;
			IqBonus = 10;
			StaminaBonus = 17;
		}
	}
}


/**************************************************************
*
*				(Gauntlets of Wrath)
*
***************************************************************/

namespace Server.Items
{
	public class GauntletsOfWrath : Item
	{
		public GauntletsOfWrath() : base()
		{
			Id = 16964;
			Resistance[0] = 535;
			Bonding = 1;
			SellPrice = 30040;
			AvailableClasses = 0x01;
			Model = 29860;
			ObjectClass = 4;
			SubClass = 4;
			Level = 76;
			ReqLevel = 60;
			Name = "Gauntlets of Wrath";
			Name2 = "Gauntlets of Wrath";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 150203;
			Sets = 218;
			Resistance[5] = 10;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 55;
			SetSpell( 13665 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 13385 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 20;
			StrBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Branchclaw Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class BranchclawGauntlets : Item
	{
		public BranchclawGauntlets() : base()
		{
			Id = 17770;
			Resistance[0] = 284;
			Bonding = 1;
			SellPrice = 3851;
			AvailableClasses = 0x7FFF;
			Model = 30957;
			ObjectClass = 4;
			SubClass = 4;
			Level = 47;
			Name = "Branchclaw Gauntlets";
			Name2 = "Branchclaw Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 19258;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 40;
			SetSpell( 21346 , 1 , 0 , -1 , 0 , -1 );
			StrBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Razor Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class RazorGauntlets : Item
	{
		public RazorGauntlets() : base()
		{
			Id = 18326;
			Resistance[0] = 386;
			Bonding = 1;
			SellPrice = 9036;
			AvailableClasses = 0x7FFF;
			Model = 30686;
			ObjectClass = 4;
			SubClass = 4;
			Level = 59;
			ReqLevel = 54;
			Name = "Razor Gauntlets";
			Name2 = "Razor Gauntlets";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 45184;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 45;
			SetSpell( 20886 , 1 , 0 , -1 , 0 , -1 );
			StrBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Gordok's Handguards)
*
***************************************************************/

namespace Server.Items
{
	public class GordoksHandguards : Item
	{
		public GordoksHandguards() : base()
		{
			Id = 18366;
			Resistance[0] = 392;
			Bonding = 1;
			SellPrice = 9805;
			AvailableClasses = 0x7FFF;
			Model = 30721;
			ObjectClass = 4;
			SubClass = 4;
			Level = 60;
			Name = "Gordok's Handguards";
			Name2 = "Gordok's Handguards";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 49025;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 45;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 10;
			StrBonus = 10;
			IqBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Force Imbued Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class ForceImbuedGauntlets : Item
	{
		public ForceImbuedGauntlets() : base()
		{
			Id = 18383;
			Resistance[0] = 538;
			Bonding = 1;
			SellPrice = 10179;
			AvailableClasses = 0x7FFF;
			Model = 30740;
			ObjectClass = 4;
			SubClass = 4;
			Level = 61;
			ReqLevel = 56;
			Name = "Force Imbued Gauntlets";
			Name2 = "Force Imbued Gauntlets";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 50897;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 45;
			SetSpell( 13385 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 14;
		}
	}
}


/**************************************************************
*
*				(Death Grips)
*
***************************************************************/

namespace Server.Items
{
	public class DeathGrips : Item
	{
		public DeathGrips() : base()
		{
			Id = 18722;
			Resistance[0] = 404;
			Bonding = 1;
			SellPrice = 10688;
			AvailableClasses = 0x7FFF;
			Model = 31173;
			ObjectClass = 4;
			SubClass = 4;
			Level = 62;
			ReqLevel = 57;
			Name = "Death Grips";
			Name2 = "Death Grips";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 53442;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 45;
			SetSpell( 7219 , 1 , 0 , -1 , 0 , -1 );
			StrBonus = 22;
		}
	}
}


/**************************************************************
*
*				(Gloves of the Dawn)
*
***************************************************************/

namespace Server.Items
{
	public class GlovesOfTheDawn : Item
	{
		public GlovesOfTheDawn() : base()
		{
			Id = 19057;
			Resistance[0] = 417;
			Bonding = 2;
			SellPrice = 11606;
			AvailableClasses = 0x7FFF;
			Model = 31564;
			ObjectClass = 4;
			SubClass = 4;
			Level = 64;
			ReqLevel = 59;
			Name = "Gloves of the Dawn";
			Name2 = "Gloves of the Dawn";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 58031;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = -1;
			Durability = 45;
			StrBonus = 23;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Slagplate Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class SlagplateGauntlets : Item
	{
		public SlagplateGauntlets() : base()
		{
			Id = 19126;
			Resistance[0] = 295;
			Bonding = 1;
			SellPrice = 4451;
			AvailableClasses = 0x7FFF;
			Model = 31638;
			ObjectClass = 4;
			SubClass = 4;
			Level = 49;
			Name = "Slagplate Gauntlets";
			Name2 = "Slagplate Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 22255;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 40;
			StrBonus = 12;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Flameguard Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class FlameguardGauntlets : Item
	{
		public FlameguardGauntlets() : base()
		{
			Id = 19143;
			Resistance[0] = 488;
			Bonding = 1;
			SellPrice = 21283;
			AvailableClasses = 0x7FFF;
			Model = 31660;
			ObjectClass = 4;
			SubClass = 4;
			Level = 69;
			ReqLevel = 60;
			Name = "Flameguard Gauntlets";
			Name2 = "Flameguard Gauntlets";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 106417;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 6;
			Durability = 55;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 15813 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Dark Iron Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class DarkIronGauntlets : Item
	{
		public DarkIronGauntlets() : base()
		{
			Id = 19164;
			Resistance[0] = 495;
			Bonding = 2;
			SellPrice = 22425;
			AvailableClasses = 0x7FFF;
			Model = 31683;
			Resistance[2] = 28;
			ObjectClass = 4;
			SubClass = 4;
			Level = 70;
			ReqLevel = 60;
			Name = "Dark Iron Gauntlets";
			Name2 = "Dark Iron Gauntlets";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 112127;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 55;
			StaminaBonus = 16;
			AgilityBonus = 12;
		}
	}
}


