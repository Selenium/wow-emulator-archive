/**************************************************************
*
*		Made by fulgas (fulgas@gmail.com)
*
*  WowwoW Item Designer ( 2005/8/23 - 10:06:05 )
*
***************************************************************/

using System;
using System.Collections;

/***************************************************************/

/**************************************************************
*
*				(Blackrock Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class BlackrockPauldrons : Item
	{
		public BlackrockPauldrons() : base()
		{
			Id = 1445;
			Resistance[0] = 126;
			SellPrice = 583;
			AvailableClasses = 0x7FFF;
			Model = 10167;
			ObjectClass = 4;
			SubClass = 3;
			Level = 23;
			ReqLevel = 18;
			Name = "Blackrock Pauldrons";
			Name2 = "Blackrock Pauldrons";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2919;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Laced Mail Shoulderpads)
*
***************************************************************/

namespace Server.Items
{
	public class LacedMailShoulderpads : Item
	{
		public LacedMailShoulderpads() : base()
		{
			Id = 1744;
			Resistance[0] = 113;
			SellPrice = 260;
			AvailableClasses = 0x7FFF;
			Model = 6914;
			ObjectClass = 4;
			SubClass = 3;
			Level = 20;
			ReqLevel = 15;
			Name = "Laced Mail Shoulderpads";
			Name2 = "Laced Mail Shoulderpads";
			AvailableRaces = 0x1FF;
			BuyPrice = 1302;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Linked Chain Shoulderpads)
*
***************************************************************/

namespace Server.Items
{
	public class LinkedChainShoulderpads : Item
	{
		public LinkedChainShoulderpads() : base()
		{
			Id = 1752;
			Resistance[0] = 115;
			SellPrice = 286;
			AvailableClasses = 0x7FFF;
			Model = 6914;
			ObjectClass = 4;
			SubClass = 3;
			Level = 21;
			ReqLevel = 16;
			Name = "Linked Chain Shoulderpads";
			Name2 = "Linked Chain Shoulderpads";
			AvailableRaces = 0x1FF;
			BuyPrice = 1433;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Reinforced Chain Shoulderpads)
*
***************************************************************/

namespace Server.Items
{
	public class ReinforcedChainShoulderpads : Item
	{
		public ReinforcedChainShoulderpads() : base()
		{
			Id = 1760;
			Resistance[0] = 128;
			SellPrice = 609;
			AvailableClasses = 0x7FFF;
			Model = 6914;
			ObjectClass = 4;
			SubClass = 3;
			Level = 27;
			ReqLevel = 22;
			Name = "Reinforced Chain Shoulderpads";
			Name2 = "Reinforced Chain Shoulderpads";
			AvailableRaces = 0x1FF;
			BuyPrice = 3045;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Cutthroat Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class CutthroatPauldrons : Item
	{
		public CutthroatPauldrons() : base()
		{
			Id = 3231;
			Resistance[0] = 137;
			Bonding = 2;
			SellPrice = 1266;
			AvailableClasses = 0x7FFF;
			Model = 10166;
			ObjectClass = 4;
			SubClass = 3;
			Level = 25;
			ReqLevel = 20;
			Name = "Cutthroat Pauldrons";
			Name2 = "Cutthroat Pauldrons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6332;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 55;
			StrBonus = 4;
			StaminaBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Rough Bronze Shoulders)
*
***************************************************************/

namespace Server.Items
{
	public class RoughBronzeShoulders : Item
	{
		public RoughBronzeShoulders() : base()
		{
			Id = 3480;
			Resistance[0] = 124;
			SellPrice = 532;
			AvailableClasses = 0x7FFF;
			Model = 23531;
			ObjectClass = 4;
			SubClass = 3;
			Level = 22;
			ReqLevel = 17;
			Name = "Rough Bronze Shoulders";
			Name2 = "Rough Bronze Shoulders";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2660;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Silvered Bronze Shoulders)
*
***************************************************************/

namespace Server.Items
{
	public class SilveredBronzeShoulders : Item
	{
		public SilveredBronzeShoulders() : base()
		{
			Id = 3481;
			Resistance[0] = 137;
			Bonding = 2;
			SellPrice = 1284;
			AvailableClasses = 0x7FFF;
			Model = 9407;
			ObjectClass = 4;
			SubClass = 3;
			Level = 25;
			ReqLevel = 20;
			Name = "Silvered Bronze Shoulders";
			Name2 = "Silvered Bronze Shoulders";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6422;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 55;
			StrBonus = 3;
			StaminaBonus = 3;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Brigand's Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class BrigandsPauldrons : Item
	{
		public BrigandsPauldrons() : base()
		{
			Id = 3765;
			Resistance[0] = 173;
			Bonding = 1;
			SellPrice = 4811;
			AvailableClasses = 0x7FFF;
			Model = 6971;
			ObjectClass = 4;
			SubClass = 3;
			Level = 40;
			Name = "Brigand's Pauldrons";
			Name2 = "Brigand's Pauldrons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 24057;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			StrBonus = 8;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Double Mail Shoulderpads)
*
***************************************************************/

namespace Server.Items
{
	public class DoubleMailShoulderpads : Item
	{
		public DoubleMailShoulderpads() : base()
		{
			Id = 3814;
			Resistance[0] = 153;
			SellPrice = 1891;
			AvailableClasses = 0x7FFF;
			Model = 6914;
			ObjectClass = 4;
			SubClass = 3;
			Level = 39;
			ReqLevel = 34;
			Name = "Double Mail Shoulderpads";
			Name2 = "Double Mail Shoulderpads";
			AvailableRaces = 0x1FF;
			BuyPrice = 9457;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Green Iron Shoulders)
*
***************************************************************/

namespace Server.Items
{
	public class GreenIronShoulders : Item
	{
		public GreenIronShoulders() : base()
		{
			Id = 3840;
			Resistance[0] = 153;
			Bonding = 2;
			SellPrice = 2571;
			AvailableClasses = 0x7FFF;
			Model = 9422;
			ObjectClass = 4;
			SubClass = 3;
			Level = 32;
			ReqLevel = 27;
			Name = "Green Iron Shoulders";
			Name2 = "Green Iron Shoulders";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 12855;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			StaminaBonus = 7;
			StrBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Golden Scale Shoulders)
*
***************************************************************/

namespace Server.Items
{
	public class GoldenScaleShoulders : Item
	{
		public GoldenScaleShoulders() : base()
		{
			Id = 3841;
			Resistance[0] = 160;
			Bonding = 2;
			SellPrice = 3106;
			AvailableClasses = 0x7FFF;
			Model = 9424;
			ObjectClass = 4;
			SubClass = 3;
			Level = 35;
			ReqLevel = 30;
			Name = "Golden Scale Shoulders";
			Name2 = "Golden Scale Shoulders";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 15534;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			StrBonus = 7;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Laminated Scale Shoulderpads)
*
***************************************************************/

namespace Server.Items
{
	public class LaminatedScaleShoulderpads : Item
	{
		public LaminatedScaleShoulderpads() : base()
		{
			Id = 3998;
			Resistance[0] = 201;
			SellPrice = 5656;
			AvailableClasses = 0x7FFF;
			Model = 10170;
			ObjectClass = 4;
			SubClass = 3;
			Level = 55;
			ReqLevel = 50;
			Name = "Laminated Scale Shoulderpads";
			Name2 = "Laminated Scale Shoulderpads";
			AvailableRaces = 0x1FF;
			BuyPrice = 28280;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Overlinked Chain Shoulderpads)
*
***************************************************************/

namespace Server.Items
{
	public class OverlinkedChainShoulderpads : Item
	{
		public OverlinkedChainShoulderpads() : base()
		{
			Id = 4006;
			Resistance[0] = 161;
			SellPrice = 2434;
			AvailableClasses = 0x7FFF;
			Model = 28392;
			ObjectClass = 4;
			SubClass = 3;
			Level = 42;
			ReqLevel = 37;
			Name = "Overlinked Chain Shoulderpads";
			Name2 = "Overlinked Chain Shoulderpads";
			AvailableRaces = 0x1FF;
			BuyPrice = 12172;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Frost Metal Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class FrostMetalPauldrons : Item
	{
		public FrostMetalPauldrons() : base()
		{
			Id = 4123;
			Resistance[0] = 164;
			Bonding = 1;
			SellPrice = 3804;
			AvailableClasses = 0x7FFF;
			Model = 6919;
			ObjectClass = 4;
			SubClass = 3;
			Level = 37;
			Name = "Frost Metal Pauldrons";
			Name2 = "Frost Metal Pauldrons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 19022;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			StaminaBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Grim Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class GrimPauldrons : Item
	{
		public GrimPauldrons() : base()
		{
			Id = 4443;
			Resistance[0] = 162;
			Bonding = 1;
			SellPrice = 3472;
			AvailableClasses = 0x7FFF;
			Model = 11327;
			ObjectClass = 4;
			SubClass = 3;
			Level = 36;
			Name = "Grim Pauldrons";
			Name2 = "Grim Pauldrons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 17360;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			StrBonus = 7;
			IqBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Burnished Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class BurnishedPauldrons : Item
	{
		public BurnishedPauldrons() : base()
		{
			Id = 4694;
			Resistance[0] = 124;
			SellPrice = 515;
			AvailableClasses = 0x7FFF;
			Model = 25770;
			ObjectClass = 4;
			SubClass = 3;
			Level = 22;
			ReqLevel = 17;
			Name = "Burnished Pauldrons";
			Name2 = "Burnished Pauldrons";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2576;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Lambent Scale Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class LambentScalePauldrons : Item
	{
		public LambentScalePauldrons() : base()
		{
			Id = 4705;
			Resistance[0] = 142;
			Bonding = 2;
			SellPrice = 1449;
			AvailableClasses = 0x7FFF;
			Model = 25783;
			ObjectClass = 4;
			SubClass = 3;
			Level = 27;
			ReqLevel = 22;
			Name = "Lambent Scale Pauldrons";
			Name2 = "Lambent Scale Pauldrons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7248;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 55;
			StrBonus = 5;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Chief Brigadier Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class ChiefBrigadierPauldrons : Item
	{
		public ChiefBrigadierPauldrons() : base()
		{
			Id = 4725;
			Resistance[0] = 173;
			Bonding = 2;
			SellPrice = 4736;
			AvailableClasses = 0x7FFF;
			Model = 25897;
			ObjectClass = 4;
			SubClass = 3;
			Level = 40;
			ReqLevel = 35;
			Name = "Chief Brigadier Pauldrons";
			Name2 = "Chief Brigadier Pauldrons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 23680;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			StrBonus = 8;
			IqBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Blackforge Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class BlackforgePauldrons : Item
	{
		public BlackforgePauldrons() : base()
		{
			Id = 4733;
			Resistance[0] = 190;
			Bonding = 2;
			SellPrice = 7957;
			AvailableClasses = 0x7FFF;
			Model = 26078;
			ObjectClass = 4;
			SubClass = 3;
			Level = 46;
			ReqLevel = 41;
			Name = "Blackforge Pauldrons";
			Name2 = "Blackforge Pauldrons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 39789;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			SpiritBonus = 10;
			IqBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Glorious Shoulders)
*
***************************************************************/

namespace Server.Items
{
	public class GloriousShoulders : Item
	{
		public GloriousShoulders() : base()
		{
			Id = 4833;
			Resistance[0] = 144;
			Bonding = 2;
			SellPrice = 1731;
			AvailableClasses = 0x7FFF;
			Model = 6929;
			ObjectClass = 4;
			SubClass = 3;
			Level = 28;
			ReqLevel = 23;
			Name = "Glorious Shoulders";
			Name2 = "Glorious Shoulders";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 8658;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			StaminaBonus = 5;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Elite Shoulders)
*
***************************************************************/

namespace Server.Items
{
	public class EliteShoulders : Item
	{
		public EliteShoulders() : base()
		{
			Id = 4835;
			Resistance[0] = 149;
			Bonding = 2;
			SellPrice = 2110;
			AvailableClasses = 0x7FFF;
			Model = 6912;
			ObjectClass = 4;
			SubClass = 3;
			Level = 30;
			ReqLevel = 25;
			Name = "Elite Shoulders";
			Name2 = "Elite Shoulders";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 10550;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			StrBonus = 6;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Durable Chain Shoulders)
*
***************************************************************/

namespace Server.Items
{
	public class DurableChainShoulders : Item
	{
		public DurableChainShoulders() : base()
		{
			Id = 6189;
			Resistance[0] = 128;
			Bonding = 1;
			SellPrice = 624;
			AvailableClasses = 0x7FFF;
			Model = 10448;
			ObjectClass = 4;
			SubClass = 3;
			Level = 24;
			Name = "Durable Chain Shoulders";
			Name2 = "Durable Chain Shoulders";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 3122;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Glimmering Mail Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class GlimmeringMailPauldrons : Item
	{
		public GlimmeringMailPauldrons() : base()
		{
			Id = 6388;
			Resistance[0] = 149;
			Bonding = 2;
			SellPrice = 2043;
			AvailableClasses = 0x7FFF;
			Model = 25806;
			ObjectClass = 4;
			SubClass = 3;
			Level = 30;
			ReqLevel = 25;
			Name = "Glimmering Mail Pauldrons";
			Name2 = "Glimmering Mail Pauldrons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 10216;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			StrBonus = 6;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Mail Combat Spaulders)
*
***************************************************************/

namespace Server.Items
{
	public class MailCombatSpaulders : Item
	{
		public MailCombatSpaulders() : base()
		{
			Id = 6404;
			Resistance[0] = 160;
			Bonding = 2;
			SellPrice = 3242;
			AvailableClasses = 0x7FFF;
			Model = 25815;
			ObjectClass = 4;
			SubClass = 3;
			Level = 35;
			ReqLevel = 30;
			Name = "Mail Combat Spaulders";
			Name2 = "Mail Combat Spaulders";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 16211;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			StrBonus = 7;
			IqBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Defender Spaulders)
*
***************************************************************/

namespace Server.Items
{
	public class DefenderSpaulders : Item
	{
		public DefenderSpaulders() : base()
		{
			Id = 6579;
			Resistance[0] = 128;
			SellPrice = 667;
			AvailableClasses = 0x7FFF;
			Model = 25764;
			ObjectClass = 4;
			SubClass = 3;
			Level = 24;
			ReqLevel = 19;
			Name = "Defender Spaulders";
			Name2 = "Defender Spaulders";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 3339;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Battleforge Shoulderguards)
*
***************************************************************/

namespace Server.Items
{
	public class BattleforgeShoulderguards : Item
	{
		public BattleforgeShoulderguards() : base()
		{
			Id = 6597;
			Resistance[0] = 144;
			Bonding = 2;
			SellPrice = 1707;
			AvailableClasses = 0x7FFF;
			Model = 25799;
			ObjectClass = 4;
			SubClass = 3;
			Level = 28;
			ReqLevel = 23;
			Name = "Battleforge Shoulderguards";
			Name2 = "Battleforge Shoulderguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1174;
			BuyPrice = 8536;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Enforcer Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class EnforcerPauldrons : Item
	{
		public EnforcerPauldrons() : base()
		{
			Id = 6747;
			Resistance[0] = 173;
			Bonding = 1;
			SellPrice = 5015;
			AvailableClasses = 0x7FFF;
			Model = 12986;
			ObjectClass = 4;
			SubClass = 3;
			Level = 40;
			Name = "Enforcer Pauldrons";
			Name2 = "Enforcer Pauldrons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 25076;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			StrBonus = 8;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Sanguine Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class SanguinePauldrons : Item
	{
		public SanguinePauldrons() : base()
		{
			Id = 6792;
			Resistance[0] = 173;
			Bonding = 1;
			SellPrice = 4738;
			AvailableClasses = 0x7FFF;
			Model = 13052;
			ObjectClass = 4;
			SubClass = 3;
			Level = 40;
			Name = "Sanguine Pauldrons";
			Name2 = "Sanguine Pauldrons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 23693;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			StrBonus = 8;
			IqBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Phalanx Spaulders)
*
***************************************************************/

namespace Server.Items
{
	public class PhalanxSpaulders : Item
	{
		public PhalanxSpaulders() : base()
		{
			Id = 7424;
			Resistance[0] = 155;
			Bonding = 2;
			SellPrice = 2709;
			AvailableClasses = 0x7FFF;
			Model = 26040;
			ObjectClass = 4;
			SubClass = 3;
			Level = 33;
			ReqLevel = 28;
			Name = "Phalanx Spaulders";
			Name2 = "Phalanx Spaulders";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1175;
			BuyPrice = 13545;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Knight's Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class KnightsPauldrons : Item
	{
		public KnightsPauldrons() : base()
		{
			Id = 7459;
			Resistance[0] = 167;
			Bonding = 2;
			SellPrice = 4317;
			AvailableClasses = 0x7FFF;
			Model = 25872;
			ObjectClass = 4;
			SubClass = 3;
			Level = 38;
			ReqLevel = 33;
			Name = "Knight's Pauldrons";
			Name2 = "Knight's Pauldrons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1177;
			BuyPrice = 21588;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Captain's Shoulderguards)
*
***************************************************************/

namespace Server.Items
{
	public class CaptainsShoulderguards : Item
	{
		public CaptainsShoulderguards() : base()
		{
			Id = 7491;
			Resistance[0] = 181;
			Bonding = 2;
			SellPrice = 6158;
			AvailableClasses = 0x7FFF;
			Model = 25822;
			ObjectClass = 4;
			SubClass = 3;
			Level = 43;
			ReqLevel = 38;
			Name = "Captain's Shoulderguards";
			Name2 = "Captain's Shoulderguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1179;
			BuyPrice = 30792;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Champion's Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class ChampionsPauldrons : Item
	{
		public ChampionsPauldrons() : base()
		{
			Id = 7543;
			Resistance[0] = 194;
			Bonding = 2;
			SellPrice = 8123;
			AvailableClasses = 0x7FFF;
			Model = 26091;
			ObjectClass = 4;
			SubClass = 3;
			Level = 47;
			ReqLevel = 42;
			Name = "Champion's Pauldrons";
			Name2 = "Champion's Pauldrons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1180;
			BuyPrice = 40619;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Herod's Shoulder)
*
***************************************************************/

namespace Server.Items
{
	public class HerodsShoulder : Item
	{
		public HerodsShoulder() : base()
		{
			Id = 7718;
			Resistance[0] = 196;
			Bonding = 1;
			SellPrice = 6867;
			AvailableClasses = 0x7FFF;
			Model = 15809;
			ObjectClass = 4;
			SubClass = 3;
			Level = 42;
			ReqLevel = 37;
			Name = "Herod's Shoulder";
			Name2 = "Herod's Shoulder";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 34338;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 70;
			StrBonus = 6;
			StaminaBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Barbaric Iron Shoulders)
*
***************************************************************/

namespace Server.Items
{
	public class BarbaricIronShoulders : Item
	{
		public BarbaricIronShoulders() : base()
		{
			Id = 7913;
			Resistance[0] = 153;
			Bonding = 2;
			SellPrice = 2500;
			AvailableClasses = 0x7FFF;
			Model = 16081;
			ObjectClass = 4;
			SubClass = 3;
			Level = 32;
			ReqLevel = 27;
			Name = "Barbaric Iron Shoulders";
			Name2 = "Barbaric Iron Shoulders";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 12502;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			StrBonus = 6;
			AgilityBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Mithril Scale Shoulders)
*
***************************************************************/

namespace Server.Items
{
	public class MithrilScaleShoulders : Item
	{
		public MithrilScaleShoulders() : base()
		{
			Id = 7932;
			Resistance[0] = 194;
			Bonding = 2;
			SellPrice = 8661;
			AvailableClasses = 0x7FFF;
			Model = 16111;
			ObjectClass = 4;
			SubClass = 3;
			Level = 47;
			ReqLevel = 42;
			Name = "Mithril Scale Shoulders";
			Name2 = "Mithril Scale Shoulders";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 43309;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			IqBonus = 10;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Myrmidon's Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class MyrmidonsPauldrons : Item
	{
		public MyrmidonsPauldrons() : base()
		{
			Id = 8133;
			Resistance[0] = 205;
			Bonding = 2;
			SellPrice = 10517;
			AvailableClasses = 0x7FFF;
			Model = 26114;
			ObjectClass = 4;
			SubClass = 3;
			Level = 50;
			ReqLevel = 45;
			Name = "Myrmidon's Pauldrons";
			Name2 = "Myrmidon's Pauldrons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 52585;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			SpiritBonus = 11;
			IqBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Tough Scorpid Shoulders)
*
***************************************************************/

namespace Server.Items
{
	public class ToughScorpidShoulders : Item
	{
		public ToughScorpidShoulders() : base()
		{
			Id = 8207;
			Resistance[0] = 197;
			Bonding = 2;
			SellPrice = 8978;
			AvailableClasses = 0x7FFF;
			Model = 16519;
			ObjectClass = 4;
			SubClass = 3;
			Level = 48;
			ReqLevel = 43;
			Name = "Tough Scorpid Shoulders";
			Name2 = "Tough Scorpid Shoulders";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 44892;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			AgilityBonus = 10;
			IqBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Ebonhold Shoulderpads)
*
***************************************************************/

namespace Server.Items
{
	public class EbonholdShoulderpads : Item
	{
		public EbonholdShoulderpads() : base()
		{
			Id = 8272;
			Resistance[0] = 220;
			Bonding = 2;
			SellPrice = 13697;
			AvailableClasses = 0x7FFF;
			Model = 26217;
			ObjectClass = 4;
			SubClass = 3;
			Level = 54;
			ReqLevel = 49;
			Name = "Ebonhold Shoulderpads";
			Name2 = "Ebonhold Shoulderpads";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 68489;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			SpiritBonus = 12;
			IqBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Hero's Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class HerosPauldrons : Item
	{
		public HerosPauldrons() : base()
		{
			Id = 8310;
			Resistance[0] = 242;
			Bonding = 2;
			SellPrice = 19419;
			AvailableClasses = 0x7FFF;
			Model = 26321;
			ObjectClass = 4;
			SubClass = 3;
			Level = 60;
			ReqLevel = 55;
			Name = "Hero's Pauldrons";
			Name2 = "Hero's Pauldrons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 97099;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			SpiritBonus = 13;
			IqBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Rockshard Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class RockshardPauldrons : Item
	{
		public RockshardPauldrons() : base()
		{
			Id = 9411;
			Resistance[0] = 186;
			Bonding = 1;
			SellPrice = 7156;
			AvailableClasses = 0x7FFF;
			Model = 6480;
			ObjectClass = 4;
			SubClass = 3;
			Level = 45;
			ReqLevel = 40;
			Name = "Rockshard Pauldrons";
			Name2 = "Rockshard Pauldrons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 35780;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			StrBonus = 2;
			SpiritBonus = 9;
			IqBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Spaulders of a Lost Age)
*
***************************************************************/

namespace Server.Items
{
	public class SpauldersOfALostAge : Item
	{
		public SpauldersOfALostAge() : base()
		{
			Id = 9430;
			Resistance[0] = 205;
			Bonding = 2;
			SellPrice = 8553;
			AvailableClasses = 0x7FFF;
			Model = 18333;
			ObjectClass = 4;
			SubClass = 3;
			Level = 45;
			ReqLevel = 40;
			Name = "Spaulders of a Lost Age";
			Name2 = "Spaulders of a Lost Age";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 42768;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 70;
			StaminaBonus = 16;
			IqBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Fortified Spaulders)
*
***************************************************************/

namespace Server.Items
{
	public class FortifiedSpaulders : Item
	{
		public FortifiedSpaulders() : base()
		{
			Id = 9817;
			Resistance[0] = 139;
			Bonding = 2;
			SellPrice = 1426;
			AvailableClasses = 0x7FFF;
			Model = 25774;
			ObjectClass = 4;
			SubClass = 3;
			Level = 26;
			ReqLevel = 21;
			Name = "Fortified Spaulders";
			Name2 = "Fortified Spaulders";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1173;
			BuyPrice = 7134;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Banded Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class BandedPauldrons : Item
	{
		public BandedPauldrons() : base()
		{
			Id = 9842;
			Resistance[0] = 153;
			Bonding = 2;
			SellPrice = 2391;
			AvailableClasses = 0x7FFF;
			Model = 27776;
			ObjectClass = 4;
			SubClass = 3;
			Level = 32;
			ReqLevel = 27;
			Name = "Banded Pauldrons";
			Name2 = "Banded Pauldrons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1175;
			BuyPrice = 11958;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Renegade Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class RenegadePauldrons : Item
	{
		public RenegadePauldrons() : base()
		{
			Id = 9872;
			Resistance[0] = 164;
			Bonding = 2;
			SellPrice = 4101;
			AvailableClasses = 0x7FFF;
			Model = 25790;
			ObjectClass = 4;
			SubClass = 3;
			Level = 37;
			ReqLevel = 32;
			Name = "Renegade Pauldrons";
			Name2 = "Renegade Pauldrons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1177;
			BuyPrice = 20508;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Jazeraint Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class JazeraintPauldrons : Item
	{
		public JazeraintPauldrons() : base()
		{
			Id = 9904;
			Resistance[0] = 176;
			Bonding = 2;
			SellPrice = 5420;
			AvailableClasses = 0x7FFF;
			Model = 27790;
			ObjectClass = 4;
			SubClass = 3;
			Level = 41;
			ReqLevel = 36;
			Name = "Jazeraint Pauldrons";
			Name2 = "Jazeraint Pauldrons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1178;
			BuyPrice = 27104;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Brigade Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class BrigadePauldrons : Item
	{
		public BrigadePauldrons() : base()
		{
			Id = 9934;
			Resistance[0] = 184;
			Bonding = 2;
			SellPrice = 6577;
			AvailableClasses = 0x7FFF;
			Model = 25935;
			ObjectClass = 4;
			SubClass = 3;
			Level = 44;
			ReqLevel = 39;
			Name = "Brigade Pauldrons";
			Name2 = "Brigade Pauldrons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1179;
			BuyPrice = 32888;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Warmonger's Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class WarmongersPauldrons : Item
	{
		public WarmongersPauldrons() : base()
		{
			Id = 9965;
			Resistance[0] = 201;
			Bonding = 2;
			SellPrice = 9973;
			AvailableClasses = 0x7FFF;
			Model = 26194;
			ObjectClass = 4;
			SubClass = 3;
			Level = 49;
			ReqLevel = 44;
			Name = "Warmonger's Pauldrons";
			Name2 = "Warmonger's Pauldrons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1181;
			BuyPrice = 49866;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Lord's Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class LordsPauldrons : Item
	{
		public LordsPauldrons() : base()
		{
			Id = 10085;
			Resistance[0] = 212;
			Bonding = 2;
			SellPrice = 11529;
			AvailableClasses = 0x7FFF;
			Model = 26329;
			ObjectClass = 4;
			SubClass = 3;
			Level = 52;
			ReqLevel = 47;
			Name = "Lord's Pauldrons";
			Name2 = "Lord's Pauldrons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1182;
			BuyPrice = 57648;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Ornate Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class OrnatePauldrons : Item
	{
		public OrnatePauldrons() : base()
		{
			Id = 10125;
			Resistance[0] = 227;
			Bonding = 2;
			SellPrice = 14551;
			AvailableClasses = 0x7FFF;
			Model = 26301;
			ObjectClass = 4;
			SubClass = 3;
			Level = 56;
			ReqLevel = 51;
			Name = "Ornate Pauldrons";
			Name2 = "Ornate Pauldrons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1183;
			BuyPrice = 72757;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Mercurial Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class MercurialPauldrons : Item
	{
		public MercurialPauldrons() : base()
		{
			Id = 10163;
			Resistance[0] = 249;
			Bonding = 2;
			SellPrice = 20264;
			AvailableClasses = 0x7FFF;
			Model = 23490;
			ObjectClass = 4;
			SubClass = 3;
			Level = 62;
			ReqLevel = 57;
			Name = "Mercurial Pauldrons";
			Name2 = "Mercurial Pauldrons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1185;
			BuyPrice = 101320;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Crusader's Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class CrusadersPauldrons : Item
	{
		public CrusadersPauldrons() : base()
		{
			Id = 10200;
			Resistance[0] = 216;
			Bonding = 2;
			SellPrice = 12314;
			AvailableClasses = 0x7FFF;
			Model = 26164;
			ObjectClass = 4;
			SubClass = 3;
			Level = 53;
			ReqLevel = 48;
			Name = "Crusader's Pauldrons";
			Name2 = "Crusader's Pauldrons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1182;
			BuyPrice = 61571;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Engraved Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class EngravedPauldrons : Item
	{
		public EngravedPauldrons() : base()
		{
			Id = 10237;
			Resistance[0] = 234;
			Bonding = 2;
			SellPrice = 16287;
			AvailableClasses = 0x7FFF;
			Model = 26273;
			ObjectClass = 4;
			SubClass = 3;
			Level = 58;
			ReqLevel = 53;
			Name = "Engraved Pauldrons";
			Name2 = "Engraved Pauldrons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1184;
			BuyPrice = 81436;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Masterwork Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class MasterworkPauldrons : Item
	{
		public MasterworkPauldrons() : base()
		{
			Id = 10274;
			Resistance[0] = 253;
			Bonding = 2;
			SellPrice = 21118;
			AvailableClasses = 0x7FFF;
			Model = 27805;
			ObjectClass = 4;
			SubClass = 3;
			Level = 63;
			ReqLevel = 58;
			Name = "Masterwork Pauldrons";
			Name2 = "Masterwork Pauldrons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1185;
			BuyPrice = 105594;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Raider's Shoulderpads)
*
***************************************************************/

namespace Server.Items
{
	public class RaidersShoulderpads : Item
	{
		public RaidersShoulderpads() : base()
		{
			Id = 10407;
			Resistance[0] = 122;
			SellPrice = 431;
			AvailableClasses = 0x7FFF;
			Model = 25777;
			ObjectClass = 4;
			SubClass = 3;
			Level = 21;
			ReqLevel = 16;
			Name = "Raider's Shoulderpads";
			Name2 = "Raider's Shoulderpads";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2159;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Dregmetal Spaulders)
*
***************************************************************/

namespace Server.Items
{
	public class DregmetalSpaulders : Item
	{
		public DregmetalSpaulders() : base()
		{
			Id = 11722;
			Resistance[0] = 246;
			Bonding = 1;
			SellPrice = 16610;
			AvailableClasses = 0x7FFF;
			Model = 28721;
			ObjectClass = 4;
			SubClass = 3;
			Level = 55;
			ReqLevel = 50;
			Name = "Dregmetal Spaulders";
			Name2 = "Dregmetal Spaulders";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 83052;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 70;
			IqBonus = 10;
			StrBonus = 6;
			StaminaBonus = 5;
			SpiritBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Lead Surveyor's Mantle)
*
***************************************************************/

namespace Server.Items
{
	public class LeadSurveyorsMantle : Item
	{
		public LeadSurveyorsMantle() : base()
		{
			Id = 11842;
			Resistance[0] = 223;
			Bonding = 1;
			SellPrice = 14208;
			AvailableClasses = 0x7FFF;
			Model = 28792;
			ObjectClass = 4;
			SubClass = 3;
			Level = 55;
			ReqLevel = 50;
			Name = "Lead Surveyor's Mantle";
			Name2 = "Lead Surveyor's Mantle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 71043;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			SpiritBonus = 14;
			IqBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Bonespike Shoulder)
*
***************************************************************/

namespace Server.Items
{
	public class BonespikeShoulder : Item
	{
		public BonespikeShoulder() : base()
		{
			Id = 12588;
			Resistance[0] = 278;
			Bonding = 1;
			SellPrice = 25446;
			AvailableClasses = 0x7FFF;
			Model = 22795;
			ObjectClass = 4;
			SubClass = 3;
			Level = 63;
			ReqLevel = 58;
			Name = "Bonespike Shoulder";
			Name2 = "Bonespike Shoulder";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 127233;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 70;
			SetSpell( 16550 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Sparkleshell Mantle)
*
***************************************************************/

namespace Server.Items
{
	public class SparkleshellMantle : Item
	{
		public SparkleshellMantle() : base()
		{
			Id = 13131;
			Resistance[0] = 161;
			Bonding = 2;
			SellPrice = 2312;
			AvailableClasses = 0x7FFF;
			Model = 28444;
			ObjectClass = 4;
			SubClass = 3;
			Level = 29;
			ReqLevel = 24;
			Name = "Sparkleshell Mantle";
			Name2 = "Sparkleshell Mantle";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 11563;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 70;
			StaminaBonus = 10;
			AgilityBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Skeletal Shoulders)
*
***************************************************************/

namespace Server.Items
{
	public class SkeletalShoulders : Item
	{
		public SkeletalShoulders() : base()
		{
			Id = 13132;
			Resistance[0] = 199;
			Bonding = 2;
			SellPrice = 7340;
			AvailableClasses = 0x7FFF;
			Model = 28443;
			ObjectClass = 4;
			SubClass = 3;
			Level = 43;
			ReqLevel = 38;
			Name = "Skeletal Shoulders";
			Name2 = "Skeletal Shoulders";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 36702;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 70;
			StrBonus = 6;
			StaminaBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Drakesfire Epaulets)
*
***************************************************************/

namespace Server.Items
{
	public class DrakesfireEpaulets : Item
	{
		public DrakesfireEpaulets() : base()
		{
			Id = 13133;
			Resistance[0] = 270;
			Bonding = 2;
			SellPrice = 23083;
			AvailableClasses = 0x7FFF;
			Model = 28665;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 3;
			Level = 61;
			ReqLevel = 56;
			Name = "Drakesfire Epaulets";
			Name2 = "Drakesfire Epaulets";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 115416;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 70;
			SpiritBonus = 14;
			StaminaBonus = 5;
			IqBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Windshrieker Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class WindshriekerPauldrons : Item
	{
		public WindshriekerPauldrons() : base()
		{
			Id = 13538;
			Resistance[6] = 20;
			Resistance[0] = 242;
			Bonding = 1;
			SellPrice = 19223;
			AvailableClasses = 0x7FFF;
			Model = 24193;
			ObjectClass = 4;
			SubClass = 3;
			Level = 60;
			ReqLevel = 55;
			Name = "Windshrieker Pauldrons";
			Name2 = "Windshrieker Pauldrons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 96115;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Royal Cap Spaulders)
*
***************************************************************/

namespace Server.Items
{
	public class RoyalCapSpaulders : Item
	{
		public RoyalCapSpaulders() : base()
		{
			Id = 14548;
			Resistance[0] = 274;
			Bonding = 1;
			SellPrice = 24792;
			AvailableClasses = 0x7FFF;
			Model = 28817;
			ObjectClass = 4;
			SubClass = 3;
			Level = 62;
			ReqLevel = 57;
			Name = "Royal Cap Spaulders";
			Name2 = "Royal Cap Spaulders";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 123964;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 70;
			SetSpell( 9315 , 1 , 0 , -1 , 0 , -1 );
			IqBonus = 13;
			SpiritBonus = 9;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(War Paint Shoulder Pads)
*
***************************************************************/

namespace Server.Items
{
	public class WarPaintShoulderPads : Item
	{
		public WarPaintShoulderPads() : base()
		{
			Id = 14728;
			Resistance[0] = 124;
			SellPrice = 485;
			AvailableClasses = 0x7FFF;
			Model = 26988;
			ObjectClass = 4;
			SubClass = 3;
			Level = 22;
			ReqLevel = 17;
			Name = "War Paint Shoulder Pads";
			Name2 = "War Paint Shoulder Pads";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2428;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Hulking Spaulders)
*
***************************************************************/

namespace Server.Items
{
	public class HulkingSpaulders : Item
	{
		public HulkingSpaulders() : base()
		{
			Id = 14749;
			Resistance[0] = 139;
			Bonding = 2;
			SellPrice = 1325;
			AvailableClasses = 0x7FFF;
			Model = 27014;
			ObjectClass = 4;
			SubClass = 3;
			Level = 26;
			ReqLevel = 21;
			Name = "Hulking Spaulders";
			Name2 = "Hulking Spaulders";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6625;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 55;
			StrBonus = 4;
			IqBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Slayer's Shoulder Pads)
*
***************************************************************/

namespace Server.Items
{
	public class SlayersShoulderPads : Item
	{
		public SlayersShoulderPads() : base()
		{
			Id = 14758;
			Resistance[0] = 151;
			Bonding = 2;
			SellPrice = 2267;
			AvailableClasses = 0x7FFF;
			Model = 27030;
			ObjectClass = 4;
			SubClass = 3;
			Level = 31;
			ReqLevel = 26;
			Name = "Slayer's Shoulder Pads";
			Name2 = "Slayer's Shoulder Pads";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11335;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			StaminaBonus = 5;
			StrBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Enduring Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class EnduringPauldrons : Item
	{
		public EnduringPauldrons() : base()
		{
			Id = 14767;
			Resistance[0] = 167;
			Bonding = 2;
			SellPrice = 4478;
			AvailableClasses = 0x7FFF;
			Model = 27054;
			ObjectClass = 4;
			SubClass = 3;
			Level = 38;
			ReqLevel = 33;
			Name = "Enduring Pauldrons";
			Name2 = "Enduring Pauldrons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 22393;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			StrBonus = 8;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Ravager's Mantle)
*
***************************************************************/

namespace Server.Items
{
	public class RavagersMantle : Item
	{
		public RavagersMantle() : base()
		{
			Id = 14776;
			Resistance[0] = 181;
			Bonding = 2;
			SellPrice = 6326;
			AvailableClasses = 0x7FFF;
			Model = 27096;
			ObjectClass = 4;
			SubClass = 3;
			Level = 43;
			ReqLevel = 38;
			Name = "Ravager's Mantle";
			Name2 = "Ravager's Mantle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 31633;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			StrBonus = 7;
			StaminaBonus = 5;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Khan's Mantle)
*
***************************************************************/

namespace Server.Items
{
	public class KhansMantle : Item
	{
		public KhansMantle() : base()
		{
			Id = 14787;
			Resistance[0] = 194;
			Bonding = 2;
			SellPrice = 8323;
			AvailableClasses = 0x7FFF;
			Model = 16079;
			ObjectClass = 4;
			SubClass = 3;
			Level = 47;
			ReqLevel = 42;
			Name = "Khan's Mantle";
			Name2 = "Khan's Mantle";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 41618;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			AgilityBonus = 12;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Protector Pads)
*
***************************************************************/

namespace Server.Items
{
	public class ProtectorPads : Item
	{
		public ProtectorPads() : base()
		{
			Id = 14797;
			Resistance[0] = 209;
			Bonding = 2;
			SellPrice = 11427;
			AvailableClasses = 0x7FFF;
			Model = 27160;
			ObjectClass = 4;
			SubClass = 3;
			Level = 51;
			ReqLevel = 46;
			Name = "Protector Pads";
			Name2 = "Protector Pads";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 57137;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			StaminaBonus = 9;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Bloodlust Epaulets)
*
***************************************************************/

namespace Server.Items
{
	public class BloodlustEpaulets : Item
	{
		public BloodlustEpaulets() : base()
		{
			Id = 14806;
			Resistance[0] = 231;
			Bonding = 2;
			SellPrice = 15560;
			AvailableClasses = 0x7FFF;
			Model = 23490;
			ObjectClass = 4;
			SubClass = 3;
			Level = 57;
			ReqLevel = 52;
			Name = "Bloodlust Epaulets";
			Name2 = "Bloodlust Epaulets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 77804;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			StaminaBonus = 9;
			SpiritBonus = 14;
		}
	}
}


/**************************************************************
*
*				(Warstrike Shoulder Pads)
*
***************************************************************/

namespace Server.Items
{
	public class WarstrikeShoulderPads : Item
	{
		public WarstrikeShoulderPads() : base()
		{
			Id = 14817;
			Resistance[0] = 249;
			Bonding = 2;
			SellPrice = 20883;
			AvailableClasses = 0x7FFF;
			Model = 27142;
			ObjectClass = 4;
			SubClass = 3;
			Level = 62;
			ReqLevel = 57;
			Name = "Warstrike Shoulder Pads";
			Name2 = "Warstrike Shoulder Pads";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 104419;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			SpiritBonus = 16;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Blue Dragonscale Shoulders)
*
***************************************************************/

namespace Server.Items
{
	public class BlueDragonscaleShoulders : Item
	{
		public BlueDragonscaleShoulders() : base()
		{
			Id = 15049;
			Resistance[6] = 6;
			Resistance[0] = 262;
			Bonding = 2;
			SellPrice = 20543;
			AvailableClasses = 0x7FFF;
			Model = 25677;
			ObjectClass = 4;
			SubClass = 3;
			Level = 59;
			ReqLevel = 54;
			Name = "Blue Dragonscale Shoulders";
			Name2 = "Blue Dragonscale Shoulders";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 102716;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 70;
			SpiritBonus = 21;
			IqBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Black Dragonscale Shoulders)
*
***************************************************************/

namespace Server.Items
{
	public class BlackDragonscaleShoulders : Item
	{
		public BlackDragonscaleShoulders() : base()
		{
			Id = 15051;
			Resistance[0] = 266;
			Bonding = 2;
			SellPrice = 21736;
			AvailableClasses = 0x7FFF;
			Model = 27945;
			Resistance[2] = 6;
			ObjectClass = 4;
			SubClass = 3;
			Level = 60;
			ReqLevel = 55;
			Name = "Black Dragonscale Shoulders";
			Name2 = "Black Dragonscale Shoulders";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 108683;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 70;
			SetSpell( 14049 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Heavy Scorpid Shoulders)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyScorpidShoulders : Item
	{
		public HeavyScorpidShoulders() : base()
		{
			Id = 15081;
			Resistance[0] = 245;
			Bonding = 2;
			SellPrice = 20261;
			AvailableClasses = 0x7FFF;
			Model = 25713;
			ObjectClass = 4;
			SubClass = 3;
			Level = 61;
			ReqLevel = 56;
			Name = "Heavy Scorpid Shoulders";
			Name2 = "Heavy Scorpid Shoulders";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 101305;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			StaminaBonus = 14;
			IqBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Bloodspattered Shoulder Pads)
*
***************************************************************/

namespace Server.Items
{
	public class BloodspatteredShoulderPads : Item
	{
		public BloodspatteredShoulderPads() : base()
		{
			Id = 15496;
			Resistance[0] = 122;
			SellPrice = 461;
			AvailableClasses = 0x7FFF;
			Model = 27003;
			ObjectClass = 4;
			SubClass = 3;
			Level = 21;
			ReqLevel = 16;
			Name = "Bloodspattered Shoulder Pads";
			Name2 = "Bloodspattered Shoulder Pads";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2309;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 50;
		}
	}
}


/**************************************************************
*
*				(Outrunner's Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class OutrunnersPauldrons : Item
	{
		public OutrunnersPauldrons() : base()
		{
			Id = 15505;
			Resistance[0] = 126;
			SellPrice = 561;
			AvailableClasses = 0x7FFF;
			Model = 26997;
			ObjectClass = 4;
			SubClass = 3;
			Level = 23;
			ReqLevel = 18;
			Name = "Outrunner's Pauldrons";
			Name2 = "Outrunner's Pauldrons";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2808;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Grunt's Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class GruntsPauldrons : Item
	{
		public GruntsPauldrons() : base()
		{
			Id = 15513;
			Resistance[0] = 137;
			Bonding = 2;
			SellPrice = 1264;
			AvailableClasses = 0x7FFF;
			Model = 26975;
			ObjectClass = 4;
			SubClass = 3;
			Level = 25;
			ReqLevel = 20;
			Name = "Grunt's Pauldrons";
			Name2 = "Grunt's Pauldrons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1173;
			BuyPrice = 6320;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Spiked Chain Shoulder Pads)
*
***************************************************************/

namespace Server.Items
{
	public class SpikedChainShoulderPads : Item
	{
		public SpikedChainShoulderPads() : base()
		{
			Id = 15523;
			Resistance[0] = 142;
			Bonding = 2;
			SellPrice = 1474;
			AvailableClasses = 0x7FFF;
			Model = 26965;
			ObjectClass = 4;
			SubClass = 3;
			Level = 27;
			ReqLevel = 22;
			Name = "Spiked Chain Shoulder Pads";
			Name2 = "Spiked Chain Shoulder Pads";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1173;
			BuyPrice = 7373;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 55;
		}
	}
}


/**************************************************************
*
*				(Sentry's Shoulderguards)
*
***************************************************************/

namespace Server.Items
{
	public class SentrysShoulderguards : Item
	{
		public SentrysShoulderguards() : base()
		{
			Id = 15531;
			Resistance[0] = 149;
			Bonding = 2;
			SellPrice = 2076;
			AvailableClasses = 0x7FFF;
			Model = 27080;
			ObjectClass = 4;
			SubClass = 3;
			Level = 30;
			ReqLevel = 25;
			Name = "Sentry's Shoulderguards";
			Name2 = "Sentry's Shoulderguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1174;
			BuyPrice = 10380;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Wicked Chain Shoulder Pads)
*
***************************************************************/

namespace Server.Items
{
	public class WickedChainShoulderPads : Item
	{
		public WickedChainShoulderPads() : base()
		{
			Id = 15542;
			Resistance[0] = 153;
			Bonding = 2;
			SellPrice = 2365;
			AvailableClasses = 0x7FFF;
			Model = 27044;
			ObjectClass = 4;
			SubClass = 3;
			Level = 32;
			ReqLevel = 27;
			Name = "Wicked Chain Shoulder Pads";
			Name2 = "Wicked Chain Shoulder Pads";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1175;
			BuyPrice = 11827;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Thick Scale Shoulder Pads)
*
***************************************************************/

namespace Server.Items
{
	public class ThickScaleShoulderPads : Item
	{
		public ThickScaleShoulderPads() : base()
		{
			Id = 15553;
			Resistance[0] = 158;
			Bonding = 2;
			SellPrice = 3061;
			AvailableClasses = 0x7FFF;
			Model = 27023;
			ObjectClass = 4;
			SubClass = 3;
			Level = 34;
			ReqLevel = 29;
			Name = "Thick Scale Shoulder Pads";
			Name2 = "Thick Scale Shoulder Pads";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1176;
			BuyPrice = 15306;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Pillager's Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class PillagersPauldrons : Item
	{
		public PillagersPauldrons() : base()
		{
			Id = 15562;
			Resistance[0] = 162;
			Bonding = 2;
			SellPrice = 3558;
			AvailableClasses = 0x7FFF;
			Model = 27071;
			ObjectClass = 4;
			SubClass = 3;
			Level = 36;
			ReqLevel = 31;
			Name = "Pillager's Pauldrons";
			Name2 = "Pillager's Pauldrons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1176;
			BuyPrice = 17790;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Marauder's Shoulder Pads)
*
***************************************************************/

namespace Server.Items
{
	public class MaraudersShoulderPads : Item
	{
		public MaraudersShoulderPads() : base()
		{
			Id = 15574;
			Resistance[0] = 173;
			Bonding = 2;
			SellPrice = 5150;
			AvailableClasses = 0x7FFF;
			Model = 25872;
			ObjectClass = 4;
			SubClass = 3;
			Level = 40;
			ReqLevel = 35;
			Name = "Marauder's Shoulder Pads";
			Name2 = "Marauder's Shoulder Pads";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1178;
			BuyPrice = 25751;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Sparkleshell Shoulder Pads)
*
***************************************************************/

namespace Server.Items
{
	public class SparkleshellShoulderPads : Item
	{
		public SparkleshellShoulderPads() : base()
		{
			Id = 15583;
			Resistance[0] = 176;
			Bonding = 2;
			SellPrice = 5344;
			AvailableClasses = 0x7FFF;
			Model = 27116;
			ObjectClass = 4;
			SubClass = 3;
			Level = 41;
			ReqLevel = 36;
			Name = "Sparkleshell Shoulder Pads";
			Name2 = "Sparkleshell Shoulder Pads";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1178;
			BuyPrice = 26722;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Steadfast Shoulders)
*
***************************************************************/

namespace Server.Items
{
	public class SteadfastShoulders : Item
	{
		public SteadfastShoulders() : base()
		{
			Id = 15597;
			Resistance[0] = 179;
			Bonding = 2;
			SellPrice = 5642;
			AvailableClasses = 0x7FFF;
			Model = 27893;
			ObjectClass = 4;
			SubClass = 3;
			Level = 42;
			ReqLevel = 37;
			Name = "Steadfast Shoulders";
			Name2 = "Steadfast Shoulders";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1178;
			BuyPrice = 28214;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Ancient Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class AncientPauldrons : Item
	{
		public AncientPauldrons() : base()
		{
			Id = 15608;
			Resistance[0] = 184;
			Bonding = 2;
			SellPrice = 7035;
			AvailableClasses = 0x7FFF;
			Model = 27123;
			ObjectClass = 4;
			SubClass = 3;
			Level = 44;
			ReqLevel = 39;
			Name = "Ancient Pauldrons";
			Name2 = "Ancient Pauldrons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1179;
			BuyPrice = 35177;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Bonelink Epaulets)
*
***************************************************************/

namespace Server.Items
{
	public class BonelinkEpaulets : Item
	{
		public BonelinkEpaulets() : base()
		{
			Id = 15617;
			Resistance[0] = 186;
			Bonding = 2;
			SellPrice = 7107;
			AvailableClasses = 0x7FFF;
			Model = 26091;
			ObjectClass = 4;
			SubClass = 3;
			Level = 45;
			ReqLevel = 40;
			Name = "Bonelink Epaulets";
			Name2 = "Bonelink Epaulets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1179;
			BuyPrice = 35538;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Gryphon Mail Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class GryphonMailPauldrons : Item
	{
		public GryphonMailPauldrons() : base()
		{
			Id = 15628;
			Resistance[0] = 197;
			Bonding = 2;
			SellPrice = 9570;
			AvailableClasses = 0x7FFF;
			Model = 27134;
			ObjectClass = 4;
			SubClass = 3;
			Level = 48;
			ReqLevel = 43;
			Name = "Gryphon Mail Pauldrons";
			Name2 = "Gryphon Mail Pauldrons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1180;
			BuyPrice = 47854;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Formidable Shoulder Pads)
*
***************************************************************/

namespace Server.Items
{
	public class FormidableShoulderPads : Item
	{
		public FormidableShoulderPads() : base()
		{
			Id = 15638;
			Resistance[0] = 201;
			Bonding = 2;
			SellPrice = 9614;
			AvailableClasses = 0x7FFF;
			Model = 27218;
			ObjectClass = 4;
			SubClass = 3;
			Level = 49;
			ReqLevel = 44;
			Name = "Formidable Shoulder Pads";
			Name2 = "Formidable Shoulder Pads";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1181;
			BuyPrice = 48074;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Ironhide Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class IronhidePauldrons : Item
	{
		public IronhidePauldrons() : base()
		{
			Id = 15647;
			Resistance[0] = 216;
			Bonding = 2;
			SellPrice = 13125;
			AvailableClasses = 0x7FFF;
			Model = 27177;
			ObjectClass = 4;
			SubClass = 3;
			Level = 53;
			ReqLevel = 48;
			Name = "Ironhide Pauldrons";
			Name2 = "Ironhide Pauldrons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1182;
			BuyPrice = 65628;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Merciless Epaulets)
*
***************************************************************/

namespace Server.Items
{
	public class MercilessEpaulets : Item
	{
		public MercilessEpaulets() : base()
		{
			Id = 15656;
			Resistance[0] = 220;
			Bonding = 2;
			SellPrice = 13366;
			AvailableClasses = 0x7FFF;
			Model = 27291;
			ObjectClass = 4;
			SubClass = 3;
			Level = 54;
			ReqLevel = 49;
			Name = "Merciless Epaulets";
			Name2 = "Merciless Epaulets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1182;
			BuyPrice = 66833;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Impenetrable Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class ImpenetrablePauldrons : Item
	{
		public ImpenetrablePauldrons() : base()
		{
			Id = 15666;
			Resistance[0] = 238;
			Bonding = 2;
			SellPrice = 18375;
			AvailableClasses = 0x7FFF;
			Model = 27302;
			ObjectClass = 4;
			SubClass = 3;
			Level = 59;
			ReqLevel = 54;
			Name = "Impenetrable Pauldrons";
			Name2 = "Impenetrable Pauldrons";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1184;
			BuyPrice = 91877;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Magnificent Shoulders)
*
***************************************************************/

namespace Server.Items
{
	public class MagnificentShoulders : Item
	{
		public MagnificentShoulders() : base()
		{
			Id = 15677;
			Resistance[0] = 245;
			Bonding = 2;
			SellPrice = 19605;
			AvailableClasses = 0x7FFF;
			Model = 27320;
			ObjectClass = 4;
			SubClass = 3;
			Level = 61;
			ReqLevel = 56;
			Name = "Magnificent Shoulders";
			Name2 = "Magnificent Shoulders";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1185;
			BuyPrice = 98029;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Triumphant Shoulder Pads)
*
***************************************************************/

namespace Server.Items
{
	public class TriumphantShoulderPads : Item
	{
		public TriumphantShoulderPads() : base()
		{
			Id = 15686;
			Resistance[0] = 253;
			Bonding = 2;
			SellPrice = 22331;
			AvailableClasses = 0x7FFF;
			Model = 16079;
			ObjectClass = 4;
			SubClass = 3;
			Level = 63;
			ReqLevel = 58;
			Name = "Triumphant Shoulder Pads";
			Name2 = "Triumphant Shoulder Pads";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 1185;
			BuyPrice = 111657;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
		}
	}
}


/**************************************************************
*
*				(Wrangling Spaulders)
*
***************************************************************/

namespace Server.Items
{
	public class WranglingSpaulders : Item
	{
		public WranglingSpaulders() : base()
		{
			Id = 15698;
			Resistance[0] = 167;
			Bonding = 1;
			SellPrice = 4273;
			AvailableClasses = 0x7FFF;
			Model = 26419;
			ObjectClass = 4;
			SubClass = 3;
			Level = 38;
			Name = "Wrangling Spaulders";
			Name2 = "Wrangling Spaulders";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 21368;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			StaminaBonus = 6;
			StrBonus = 8;
			AgilityBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Lieutenant Commander's Chain Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class LieutenantCommandersChainPauldrons : Item
	{
		public LieutenantCommandersChainPauldrons() : base()
		{
			Id = 16427;
			Resistance[0] = 278;
			Bonding = 1;
			SellPrice = 12923;
			AvailableClasses = 0x04;
			Model = 31247;
			ObjectClass = 4;
			SubClass = 3;
			Level = 63;
			ReqLevel = 58;
			Name = "Lieutenant Commander's Chain Pauldrons";
			Name2 = "Lieutenant Commander's Chain Pauldrons";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 64619;
			Sets = 362;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			Durability = 70;
			Flags = 32768;
			SetSpell( 9141 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 20;
			AgilityBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Field Marshal's Chain Spaulders)
*
***************************************************************/

namespace Server.Items
{
	public class FieldMarshalsChainSpaulders : Item
	{
		public FieldMarshalsChainSpaulders() : base()
		{
			Id = 16468;
			Resistance[0] = 312;
			Bonding = 1;
			SellPrice = 19065;
			AvailableClasses = 0x04;
			Model = 32092;
			ObjectClass = 4;
			SubClass = 3;
			Level = 65;
			ReqLevel = 60;
			Name = "Field Marshal's Chain Spaulders";
			Name2 = "Field Marshal's Chain Spaulders";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 95325;
			Sets = 395;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			Durability = 85;
			Flags = 32768;
			SetSpell( 9332 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 26;
			AgilityBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Champion's Mail Shoulders)
*
***************************************************************/

namespace Server.Items
{
	public class ChampionsMailShoulders : Item
	{
		public ChampionsMailShoulders() : base()
		{
			Id = 16524;
			Resistance[0] = 278;
			Bonding = 1;
			SellPrice = 13117;
			AvailableClasses = 0x40;
			Model = 30382;
			ObjectClass = 4;
			SubClass = 3;
			Level = 63;
			ReqLevel = 58;
			Name = "Champion's Mail Shoulders";
			Name2 = "Champion's Mail Shoulders";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 65588;
			Sets = 301;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			Durability = 70;
			Flags = 32768;
			SetSpell( 9396 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 16;
			SpiritBonus = 15;
			StrBonus = 5;
			AgilityBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Champion's Chain Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class ChampionsChainPauldrons : Item
	{
		public ChampionsChainPauldrons() : base()
		{
			Id = 16528;
			Resistance[0] = 278;
			Bonding = 1;
			SellPrice = 13309;
			AvailableClasses = 0x04;
			Model = 31047;
			ObjectClass = 4;
			SubClass = 3;
			Level = 63;
			ReqLevel = 58;
			Name = "Champion's Chain Pauldrons";
			Name2 = "Champion's Chain Pauldrons";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 66545;
			Sets = 361;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			Durability = 70;
			Flags = 32768;
			SetSpell( 9141 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 20;
			AgilityBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Warlord's Chain Shoulders)
*
***************************************************************/

namespace Server.Items
{
	public class WarlordsChainShoulders : Item
	{
		public WarlordsChainShoulders() : base()
		{
			Id = 16568;
			Resistance[0] = 312;
			Bonding = 1;
			SellPrice = 19558;
			AvailableClasses = 0x04;
			Model = 32125;
			ObjectClass = 4;
			SubClass = 3;
			Level = 65;
			ReqLevel = 60;
			Name = "Warlord's Chain Shoulders";
			Name2 = "Warlord's Chain Shoulders";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 97793;
			Sets = 396;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			Durability = 85;
			Flags = 32768;
			SetSpell( 9332 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 26;
			AgilityBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Warlord's Mail Spaulders)
*
***************************************************************/

namespace Server.Items
{
	public class WarlordsMailSpaulders : Item
	{
		public WarlordsMailSpaulders() : base()
		{
			Id = 16580;
			Resistance[0] = 312;
			Bonding = 1;
			SellPrice = 18994;
			AvailableClasses = 0x40;
			Model = 32128;
			ObjectClass = 4;
			SubClass = 3;
			Level = 65;
			ReqLevel = 60;
			Name = "Warlord's Mail Spaulders";
			Name2 = "Warlord's Mail Spaulders";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 94971;
			Sets = 386;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			MaxCount = 1;
			Material = 5;
			Durability = 85;
			Flags = 32768;
			SetSpell( 9398 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 18;
			SpiritBonus = 17;
			StrBonus = 11;
			AgilityBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Pauldrons of Elements)
*
***************************************************************/

namespace Server.Items
{
	public class PauldronsOfElements : Item
	{
		public PauldronsOfElements() : base()
		{
			Id = 16669;
			Resistance[0] = 266;
			Bonding = 1;
			SellPrice = 21995;
			AvailableClasses = 0x7FFF;
			Model = 30925;
			ObjectClass = 4;
			SubClass = 3;
			Level = 60;
			ReqLevel = 55;
			Name = "Pauldrons of Elements";
			Name2 = "Pauldrons of Elements";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 109977;
			Sets = 187;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 70;
			SpiritBonus = 15;
			StaminaBonus = 14;
			IqBonus = 6;
			StrBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Beaststalker's Mantle)
*
***************************************************************/

namespace Server.Items
{
	public class BeaststalkersMantle : Item
	{
		public BeaststalkersMantle() : base()
		{
			Id = 16679;
			Resistance[0] = 266;
			Bonding = 1;
			SellPrice = 22822;
			AvailableClasses = 0x7FFF;
			Model = 31409;
			ObjectClass = 4;
			SubClass = 3;
			Level = 60;
			ReqLevel = 55;
			Name = "Beaststalker's Mantle";
			Name2 = "Beaststalker's Mantle";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 114114;
			Sets = 186;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 70;
			StaminaBonus = 17;
			AgilityBonus = 11;
			SpiritBonus = 7;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Arcmetal Shoulders)
*
***************************************************************/

namespace Server.Items
{
	public class ArcmetalShoulders : Item
	{
		public ArcmetalShoulders() : base()
		{
			Id = 16793;
			Resistance[0] = 167;
			Bonding = 1;
			SellPrice = 4353;
			AvailableClasses = 0x7FFF;
			Model = 28454;
			ObjectClass = 4;
			SubClass = 3;
			Level = 38;
			Name = "Arcmetal Shoulders";
			Name2 = "Arcmetal Shoulders";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 21765;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 60;
			AgilityBonus = 9;
			StaminaBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Earthfury Epaulets)
*
***************************************************************/

namespace Server.Items
{
	public class EarthfuryEpaulets : Item
	{
		public EarthfuryEpaulets() : base()
		{
			Id = 16844;
			Resistance[0] = 317;
			Bonding = 1;
			SellPrice = 39582;
			AvailableClasses = 0x40;
			Model = 31833;
			ObjectClass = 4;
			SubClass = 3;
			Level = 66;
			ReqLevel = 60;
			Name = "Earthfury Epaulets";
			Name2 = "Earthfury Epaulets";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 197913;
			Sets = 207;
			Resistance[5] = 7;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 85;
			SetSpell( 21618 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 9406 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 18;
			IqBonus = 10;
			StaminaBonus = 17;
		}
	}
}


/**************************************************************
*
*				(Giantstalker's Epaulets)
*
***************************************************************/

namespace Server.Items
{
	public class GiantstalkersEpaulets : Item
	{
		public GiantstalkersEpaulets() : base()
		{
			Id = 16848;
			Resistance[0] = 317;
			Bonding = 1;
			SellPrice = 41237;
			AvailableClasses = 0x04;
			Model = 32030;
			ObjectClass = 4;
			SubClass = 3;
			Level = 66;
			ReqLevel = 60;
			Name = "Giantstalker's Epaulets";
			Name2 = "Giantstalker's Epaulets";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 206188;
			Sets = 206;
			Resistance[5] = 7;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 85;
			SetSpell( 15464 , 1 , 0 , -1 , 0 , -1 );
			AgilityBonus = 24;
			SpiritBonus = 5;
			IqBonus = 9;
			StaminaBonus = 14;
		}
	}
}


/**************************************************************
*
*				(Dragonstalker's Spaulders)
*
***************************************************************/

namespace Server.Items
{
	public class DragonstalkersSpaulders : Item
	{
		public DragonstalkersSpaulders() : base()
		{
			Id = 16937;
			Resistance[0] = 362;
			Bonding = 1;
			SellPrice = 64482;
			AvailableClasses = 0x04;
			Model = 29815;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 3;
			Level = 76;
			ReqLevel = 60;
			Name = "Dragonstalker's Spaulders";
			Name2 = "Dragonstalker's Spaulders";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 322412;
			Sets = 215;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 85;
			AgilityBonus = 23;
			SpiritBonus = 14;
			IqBonus = 8;
			StaminaBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Epaulets of Ten Storms)
*
***************************************************************/

namespace Server.Items
{
	public class EpauletsOfTenStorms : Item
	{
		public EpauletsOfTenStorms() : base()
		{
			Id = 16945;
			Resistance[0] = 362;
			Bonding = 1;
			SellPrice = 68140;
			AvailableClasses = 0x7FFF;
			Model = 29802;
			ObjectClass = 4;
			SubClass = 3;
			Level = 76;
			ReqLevel = 60;
			Name = "Epaulets of Ten Storms";
			Name2 = "Epaulets of Ten Storms";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 340701;
			Sets = 216;
			Resistance[5] = 9;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 85;
			SetSpell( 9408 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 17;
			IqBonus = 10;
			StaminaBonus = 23;
		}
	}
}


/**************************************************************
*
*				(Fiery Chain Shoulders)
*
***************************************************************/

namespace Server.Items
{
	public class FieryChainShoulders : Item
	{
		public FieryChainShoulders() : base()
		{
			Id = 16988;
			Resistance[0] = 299;
			Bonding = 2;
			SellPrice = 31460;
			AvailableClasses = 0x7FFF;
			Model = 28773;
			Resistance[2] = 25;
			ObjectClass = 4;
			SubClass = 3;
			Level = 62;
			ReqLevel = 57;
			Name = "Fiery Chain Shoulders";
			Name2 = "Fiery Chain Shoulders";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 157303;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 85;
			SpiritBonus = 14;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Denwatcher's Shoulders)
*
***************************************************************/

namespace Server.Items
{
	public class DenwatchersShoulders : Item
	{
		public DenwatchersShoulders() : base()
		{
			Id = 18494;
			Resistance[0] = 266;
			Bonding = 1;
			SellPrice = 21444;
			AvailableClasses = 0x7FFF;
			Model = 30830;
			ObjectClass = 4;
			SubClass = 3;
			Level = 60;
			ReqLevel = 55;
			Name = "Denwatcher's Shoulders";
			Name2 = "Denwatcher's Shoulders";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 107223;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 70;
			SetSpell( 9346 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 10;
			IqBonus = 10;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Bone Golem Shoulders)
*
***************************************************************/

namespace Server.Items
{
	public class BoneGolemShoulders : Item
	{
		public BoneGolemShoulders() : base()
		{
			Id = 18686;
			Resistance[0] = 274;
			Bonding = 1;
			SellPrice = 24527;
			AvailableClasses = 0x7FFF;
			Model = 31130;
			ObjectClass = 4;
			SubClass = 3;
			Level = 62;
			ReqLevel = 57;
			Name = "Bone Golem Shoulders";
			Name2 = "Bone Golem Shoulders";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 122638;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 2;
			Durability = 70;
			AgilityBonus = 19;
			SpiritBonus = 9;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Stratholme Militia Shoulderguard)
*
***************************************************************/

namespace Server.Items
{
	public class StratholmeMilitiaShoulderguard : Item
	{
		public StratholmeMilitiaShoulderguard() : base()
		{
			Id = 18742;
			Resistance[0] = 266;
			Bonding = 1;
			SellPrice = 21444;
			AvailableClasses = 0x7FFF;
			Model = 31194;
			ObjectClass = 4;
			SubClass = 3;
			Level = 60;
			ReqLevel = 55;
			Name = "Stratholme Militia Shoulderguard";
			Name2 = "Stratholme Militia Shoulderguard";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 107223;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 70;
			AgilityBonus = 22;
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Deep Earth Spaulders)
*
***************************************************************/

namespace Server.Items
{
	public class DeepEarthSpaulders : Item
	{
		public DeepEarthSpaulders() : base()
		{
			Id = 18829;
			Resistance[0] = 399;
			Bonding = 1;
			SellPrice = 48836;
			AvailableClasses = 0x7FFF;
			Model = 31468;
			ObjectClass = 4;
			SubClass = 3;
			Level = 71;
			ReqLevel = 60;
			Name = "Deep Earth Spaulders";
			Name2 = "Deep Earth Spaulders";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 244184;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 85;
			SetSpell( 17997 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 12;
			StaminaBonus = 11;
			IqBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Winteraxe Epaulets)
*
***************************************************************/

namespace Server.Items
{
	public class WinteraxeEpaulets : Item
	{
		public WinteraxeEpaulets() : base()
		{
			Id = 19111;
			Resistance[0] = 278;
			Bonding = 1;
			SellPrice = 24824;
			AvailableClasses = 0x7FFF;
			Model = 31618;
			ObjectClass = 4;
			SubClass = 3;
			Level = 63;
			ReqLevel = 58;
			Name = "Winteraxe Epaulets";
			Name2 = "Winteraxe Epaulets";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 124124;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 70;
			SpiritBonus = 10;
			IqBonus = 6;
			StaminaBonus = 20;
		}
	}
}


/**************************************************************
*
*				(Black Brood Pauldrons)
*
***************************************************************/

namespace Server.Items
{
	public class BlackBroodPauldrons : Item
	{
		public BlackBroodPauldrons() : base()
		{
			Id = 19373;
			Resistance[0] = 357;
			Bonding = 1;
			SellPrice = 65375;
			AvailableClasses = 0x7FFF;
			Model = 31194;
			ObjectClass = 4;
			SubClass = 3;
			Level = 75;
			ReqLevel = 60;
			Name = "Black Brood Pauldrons";
			Name2 = "Black Brood Pauldrons";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 326877;
			InventoryType = InventoryTypes.Shoulder;
			Stackable = 1;
			Material = 5;
			Durability = 85;
			SetSpell( 21631 , 1 , 0 , -1 , 0 , -1 );
			AgilityBonus = 17;
			SpiritBonus = 15;
			StaminaBonus = 12;
		}
	}
}


