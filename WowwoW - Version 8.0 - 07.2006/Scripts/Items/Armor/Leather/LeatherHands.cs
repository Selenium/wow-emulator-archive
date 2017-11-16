/**************************************************************
*
*		Made by fulgas (fulgas@gmail.com)
*
*  WowwoW Item Designer ( 2005/8/23 - 10:05:23 )
*
***************************************************************/

using System;
using System.Collections;

/***************************************************************/

/**************************************************************
*
*				(Cured Leather Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class CuredLeatherGloves : Item
	{
		public CuredLeatherGloves() : base()
		{
			Id = 239;
			Resistance[0] = 48;
			SellPrice = 282;
			AvailableClasses = 0x7FFF;
			Model = 14475;
			ObjectClass = 4;
			SubClass = 2;
			Level = 22;
			ReqLevel = 17;
			Name = "Cured Leather Gloves";
			Name2 = "Cured Leather Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 1413;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Dirty Leather Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class DirtyLeatherGloves : Item
	{
		public DirtyLeatherGloves() : base()
		{
			Id = 714;
			Resistance[0] = 21;
			SellPrice = 6;
			AvailableClasses = 0x7FFF;
			Model = 14445;
			ObjectClass = 4;
			SubClass = 2;
			Level = 5;
			ReqLevel = 1;
			Name = "Dirty Leather Gloves";
			Name2 = "Dirty Leather Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 32;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 16;
		}
	}
}


/**************************************************************
*
*				(Brawler Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class BrawlerGloves : Item
	{
		public BrawlerGloves() : base()
		{
			Id = 720;
			Resistance[0] = 62;
			Bonding = 2;
			SellPrice = 1070;
			AvailableClasses = 0x7FFF;
			Model = 2368;
			ObjectClass = 4;
			SubClass = 2;
			Level = 28;
			ReqLevel = 23;
			Name = "Brawler Gloves";
			Name2 = "Brawler Gloves";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 5350;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			StrBonus = 8;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Rough Leather Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class RoughLeatherGloves : Item
	{
		public RoughLeatherGloves() : base()
		{
			Id = 797;
			Resistance[0] = 33;
			SellPrice = 35;
			AvailableClasses = 0x7FFF;
			Model = 17068;
			ObjectClass = 4;
			SubClass = 2;
			Level = 10;
			ReqLevel = 5;
			Name = "Rough Leather Gloves";
			Name2 = "Rough Leather Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 176;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Tanned Leather Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class TannedLeatherGloves : Item
	{
		public TannedLeatherGloves() : base()
		{
			Id = 844;
			Resistance[0] = 43;
			SellPrice = 144;
			AvailableClasses = 0x7FFF;
			Model = 2101;
			ObjectClass = 4;
			SubClass = 2;
			Level = 17;
			ReqLevel = 12;
			Name = "Tanned Leather Gloves";
			Name2 = "Tanned Leather Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 720;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Gloves of Holy Might)
*
***************************************************************/

namespace Server.Items
{
	public class GlovesOfHolyMight : Item
	{
		public GlovesOfHolyMight() : base()
		{
			Id = 867;
			Resistance[0] = 86;
			Bonding = 2;
			SellPrice = 5344;
			AvailableClasses = 0x7FFF;
			Model = 17180;
			ObjectClass = 4;
			SubClass = 2;
			Level = 42;
			ReqLevel = 37;
			Name = "Gloves of Holy Might";
			Name2 = "Gloves of Holy Might";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 26720;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 40;
			SetSpell( 7597 , 1 , 0 , 0 , 0 , -1 );
			SetSpell( 9331 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 18074 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Naga Battle Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class NagaBattleGloves : Item
	{
		public NagaBattleGloves() : base()
		{
			Id = 888;
			Resistance[0] = 61;
			Bonding = 1;
			SellPrice = 980;
			AvailableClasses = 0x7FFF;
			Model = 17182;
			ObjectClass = 4;
			SubClass = 2;
			Level = 27;
			ReqLevel = 22;
			Name = "Naga Battle Gloves";
			Name2 = "Naga Battle Gloves";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 4903;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			IqBonus = 7;
			StaminaBonus = 4;
			StrBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Black Whelp Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class BlackWhelpGloves : Item
	{
		public BlackWhelpGloves() : base()
		{
			Id = 1302;
			Resistance[0] = 46;
			Bonding = 1;
			SellPrice = 262;
			AvailableClasses = 0x7FFF;
			Model = 17174;
			ObjectClass = 4;
			SubClass = 2;
			Level = 18;
			Name = "Black Whelp Gloves";
			Name2 = "Black Whelp Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1312;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 20;
			StrBonus = 2;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Ghoul Fingers)
*
***************************************************************/

namespace Server.Items
{
	public class GhoulFingers : Item
	{
		public GhoulFingers() : base()
		{
			Id = 1314;
			Resistance[0] = 48;
			Bonding = 2;
			SellPrice = 362;
			AvailableClasses = 0x7FFF;
			Model = 17179;
			ObjectClass = 4;
			SubClass = 2;
			Level = 20;
			ReqLevel = 15;
			Name = "Ghoul Fingers";
			Name2 = "Ghoul Fingers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1814;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 25;
			StrBonus = 3;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Lion-stamped Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class LionStampedGloves : Item
	{
		public LionStampedGloves() : base()
		{
			Id = 1359;
			Resistance[0] = 28;
			Bonding = 1;
			SellPrice = 19;
			AvailableClasses = 0x7FFF;
			Model = 6751;
			ObjectClass = 4;
			SubClass = 2;
			Level = 8;
			Name = "Lion-stamped Gloves";
			Name2 = "Lion-stamped Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 95;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 18;
		}
	}
}


/**************************************************************
*
*				(Ragged Leather Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class RaggedLeatherGloves : Item
	{
		public RaggedLeatherGloves() : base()
		{
			Id = 1368;
			Resistance[0] = 17;
			SellPrice = 2;
			AvailableClasses = 0x7FFF;
			Model = 17184;
			ObjectClass = 4;
			SubClass = 2;
			Level = 4;
			ReqLevel = 1;
			Name = "Ragged Leather Gloves";
			Name2 = "Ragged Leather Gloves";
			AvailableRaces = 0x1FF;
			BuyPrice = 14;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 16;
		}
	}
}


/**************************************************************
*
*				(Worn Leather Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class WornLeatherGloves : Item
	{
		public WornLeatherGloves() : base()
		{
			Id = 1422;
			Resistance[0] = 22;
			SellPrice = 6;
			AvailableClasses = 0x7FFF;
			Model = 14345;
			ObjectClass = 4;
			SubClass = 2;
			Level = 6;
			ReqLevel = 1;
			Name = "Worn Leather Gloves";
			Name2 = "Worn Leather Gloves";
			AvailableRaces = 0x1FF;
			BuyPrice = 31;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 16;
		}
	}
}


/**************************************************************
*
*				(Warped Leather Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class WarpedLeatherGloves : Item
	{
		public WarpedLeatherGloves() : base()
		{
			Id = 1506;
			Resistance[0] = 36;
			SellPrice = 51;
			AvailableClasses = 0x7FFF;
			Model = 17077;
			ObjectClass = 4;
			SubClass = 2;
			Level = 13;
			ReqLevel = 8;
			Name = "Warped Leather Gloves";
			Name2 = "Warped Leather Gloves";
			AvailableRaces = 0x1FF;
			BuyPrice = 255;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Patched Leather Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class PatchedLeatherGloves : Item
	{
		public PatchedLeatherGloves() : base()
		{
			Id = 1791;
			Resistance[0] = 41;
			SellPrice = 90;
			AvailableClasses = 0x7FFF;
			Model = 972;
			ObjectClass = 4;
			SubClass = 2;
			Level = 17;
			ReqLevel = 12;
			Name = "Patched Leather Gloves";
			Name2 = "Patched Leather Gloves";
			AvailableRaces = 0x1FF;
			BuyPrice = 450;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Rawhide Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class RawhideGloves : Item
	{
		public RawhideGloves() : base()
		{
			Id = 1799;
			Resistance[0] = 46;
			SellPrice = 211;
			AvailableClasses = 0x7FFF;
			Model = 17066;
			ObjectClass = 4;
			SubClass = 2;
			Level = 23;
			ReqLevel = 18;
			Name = "Rawhide Gloves";
			Name2 = "Rawhide Gloves";
			AvailableRaces = 0x1FF;
			BuyPrice = 1056;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Tough Leather Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class ToughLeatherGloves : Item
	{
		public ToughLeatherGloves() : base()
		{
			Id = 1807;
			Resistance[0] = 52;
			SellPrice = 387;
			AvailableClasses = 0x7FFF;
			Model = 17072;
			ObjectClass = 4;
			SubClass = 2;
			Level = 29;
			ReqLevel = 24;
			Name = "Tough Leather Gloves";
			Name2 = "Tough Leather Gloves";
			AvailableRaces = 0x1FF;
			BuyPrice = 1939;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Metalworking Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class MetalworkingGloves : Item
	{
		public MetalworkingGloves() : base()
		{
			Id = 1944;
			Resistance[0] = 46;
			Bonding = 2;
			SellPrice = 259;
			AvailableClasses = 0x7FFF;
			Model = 17062;
			ObjectClass = 4;
			SubClass = 2;
			Level = 18;
			ReqLevel = 13;
			Name = "Metalworking Gloves";
			Name2 = "Metalworking Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1296;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 20;
			StrBonus = 3;
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Woodworking Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class WoodworkingGloves : Item
	{
		public WoodworkingGloves() : base()
		{
			Id = 1945;
			Resistance[0] = 46;
			Bonding = 2;
			SellPrice = 267;
			AvailableClasses = 0x7FFF;
			Model = 17189;
			ObjectClass = 4;
			SubClass = 2;
			Level = 18;
			ReqLevel = 13;
			Name = "Woodworking Gloves";
			Name2 = "Woodworking Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1337;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 20;
			SpiritBonus = 3;
			IqBonus = 2;
		}
	}
}


/**************************************************************
*
*				(White Wolf Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class WhiteWolfGloves : Item
	{
		public WhiteWolfGloves() : base()
		{
			Id = 1965;
			Resistance[0] = 33;
			SellPrice = 36;
			AvailableClasses = 0x7FFF;
			Model = 3846;
			ObjectClass = 4;
			SubClass = 2;
			Level = 10;
			ReqLevel = 5;
			Name = "White Wolf Gloves";
			Name2 = "White Wolf Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 180;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Wolfclaw Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class WolfclawGloves : Item
	{
		public WolfclawGloves() : base()
		{
			Id = 1978;
			Resistance[0] = 61;
			Bonding = 2;
			SellPrice = 980;
			AvailableClasses = 0x7FFF;
			Model = 12813;
			ObjectClass = 4;
			SubClass = 2;
			Level = 27;
			ReqLevel = 22;
			Name = "Wolfclaw Gloves";
			Name2 = "Wolfclaw Gloves";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 4904;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			AgilityBonus = 6;
			StrBonus = 5;
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Dusty Mining Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class DustyMiningGloves : Item
	{
		public DustyMiningGloves() : base()
		{
			Id = 2036;
			Resistance[0] = 46;
			Bonding = 1;
			SellPrice = 258;
			AvailableClasses = 0x7FFF;
			Model = 17054;
			ObjectClass = 4;
			SubClass = 2;
			Level = 18;
			Name = "Dusty Mining Gloves";
			Name2 = "Dusty Mining Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1291;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 20;
			StrBonus = 3;
			AgilityBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Cracked Leather Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class CrackedLeatherGloves : Item
	{
		public CrackedLeatherGloves() : base()
		{
			Id = 2125;
			Resistance[0] = 21;
			SellPrice = 6;
			AvailableClasses = 0x7FFF;
			Model = 17176;
			ObjectClass = 4;
			SubClass = 2;
			Level = 5;
			ReqLevel = 1;
			Name = "Cracked Leather Gloves";
			Name2 = "Cracked Leather Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 32;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 16;
		}
	}
}


/**************************************************************
*
*				(Cuirboulli Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class CuirboulliGloves : Item
	{
		public CuirboulliGloves() : base()
		{
			Id = 2145;
			Resistance[0] = 53;
			SellPrice = 529;
			AvailableClasses = 0x7FFF;
			Model = 14480;
			ObjectClass = 4;
			SubClass = 2;
			Level = 27;
			ReqLevel = 22;
			Name = "Cuirboulli Gloves";
			Name2 = "Cuirboulli Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 2648;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Foreman's Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class ForemansGloves : Item
	{
		public ForemansGloves() : base()
		{
			Id = 2167;
			Resistance[0] = 48;
			Bonding = 2;
			SellPrice = 339;
			AvailableClasses = 0x7FFF;
			Model = 17178;
			ObjectClass = 4;
			SubClass = 2;
			Level = 20;
			ReqLevel = 15;
			Name = "Foreman's Gloves";
			Name2 = "Foreman's Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1695;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 25;
			StrBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Fine Leather Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class FineLeatherGloves : Item
	{
		public FineLeatherGloves() : base()
		{
			Id = 2312;
			Resistance[0] = 43;
			Bonding = 2;
			SellPrice = 181;
			AvailableClasses = 0x7FFF;
			Model = 5406;
			ObjectClass = 4;
			SubClass = 2;
			Level = 15;
			ReqLevel = 10;
			Name = "Fine Leather Gloves";
			Name2 = "Fine Leather Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 905;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 20;
			SpiritBonus = 2;
			IqBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Battered Leather Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class BatteredLeatherGloves : Item
	{
		public BatteredLeatherGloves() : base()
		{
			Id = 2375;
			Resistance[0] = 33;
			SellPrice = 34;
			AvailableClasses = 0x7FFF;
			Model = 17051;
			ObjectClass = 4;
			SubClass = 2;
			Level = 10;
			ReqLevel = 5;
			Name = "Battered Leather Gloves";
			Name2 = "Battered Leather Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 173;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Studded Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class StuddedGloves : Item
	{
		public StuddedGloves() : base()
		{
			Id = 2469;
			Resistance[0] = 62;
			SellPrice = 1266;
			AvailableClasses = 0x7FFF;
			Model = 17027;
			ObjectClass = 4;
			SubClass = 2;
			Level = 37;
			ReqLevel = 32;
			Name = "Studded Gloves";
			Name2 = "Studded Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 6334;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Reinforced Leather Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class ReinforcedLeatherGloves : Item
	{
		public ReinforcedLeatherGloves() : base()
		{
			Id = 2475;
			Resistance[0] = 79;
			SellPrice = 3459;
			AvailableClasses = 0x7FFF;
			Model = 2686;
			ObjectClass = 4;
			SubClass = 2;
			Level = 50;
			ReqLevel = 45;
			Name = "Reinforced Leather Gloves";
			Name2 = "Reinforced Leather Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 17298;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Elven Spirit Claws)
*
***************************************************************/

namespace Server.Items
{
	public class ElvenSpiritClaws : Item
	{
		public ElvenSpiritClaws() : base()
		{
			Id = 2564;
			Resistance[0] = 91;
			Bonding = 2;
			SellPrice = 6817;
			AvailableClasses = 0x7FFF;
			Model = 4485;
			ObjectClass = 4;
			SubClass = 2;
			Level = 50;
			ReqLevel = 45;
			Name = "Elven Spirit Claws";
			Name2 = "Elven Spirit Claws";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 34085;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			SetSpell( 9361 , 1 , 0 , -1 , 0 , -1 );
			IqBonus = 9;
			SpiritBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Burnt Leather Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class BurntLeatherGloves : Item
	{
		public BurntLeatherGloves() : base()
		{
			Id = 2964;
			Resistance[0] = 33;
			SellPrice = 36;
			AvailableClasses = 0x7FFF;
			Model = 17175;
			ObjectClass = 4;
			SubClass = 2;
			Level = 10;
			ReqLevel = 5;
			Name = "Burnt Leather Gloves";
			Name2 = "Burnt Leather Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 181;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Hunting Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class HuntingGloves : Item
	{
		public HuntingGloves() : base()
		{
			Id = 2976;
			Resistance[0] = 43;
			Bonding = 2;
			SellPrice = 171;
			AvailableClasses = 0x7FFF;
			Model = 14536;
			ObjectClass = 4;
			SubClass = 2;
			Level = 15;
			ReqLevel = 10;
			Name = "Hunting Gloves";
			Name2 = "Hunting Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 859;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 20;
			StaminaBonus = 1;
			AgilityBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Inscribed Leather Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class InscribedLeatherGloves : Item
	{
		public InscribedLeatherGloves() : base()
		{
			Id = 2988;
			Resistance[0] = 47;
			Bonding = 2;
			SellPrice = 314;
			AvailableClasses = 0x7FFF;
			Model = 14411;
			ObjectClass = 4;
			SubClass = 2;
			Level = 19;
			ReqLevel = 14;
			Name = "Inscribed Leather Gloves";
			Name2 = "Inscribed Leather Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1571;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 25;
			IqBonus = 3;
			AgilityBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Forest Leather Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class ForestLeatherGloves : Item
	{
		public ForestLeatherGloves() : base()
		{
			Id = 3058;
			Resistance[0] = 53;
			Bonding = 2;
			SellPrice = 682;
			AvailableClasses = 0x7FFF;
			Model = 17055;
			ObjectClass = 4;
			SubClass = 2;
			Level = 25;
			ReqLevel = 20;
			Name = "Forest Leather Gloves";
			Name2 = "Forest Leather Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3414;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StaminaBonus = 4;
			AgilityBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Driving Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class DrivingGloves : Item
	{
		public DrivingGloves() : base()
		{
			Id = 3152;
			Resistance[0] = 30;
			Bonding = 1;
			SellPrice = 28;
			AvailableClasses = 0x7FFF;
			Model = 17177;
			ObjectClass = 4;
			SubClass = 2;
			Level = 9;
			Name = "Driving Gloves";
			Name2 = "Driving Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 140;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 18;
		}
	}
}


/**************************************************************
*
*				(Tribal Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class TribalGloves : Item
	{
		public TribalGloves() : base()
		{
			Id = 3286;
			Resistance[0] = 37;
			SellPrice = 59;
			AvailableClasses = 0x7FFF;
			Model = 27995;
			ObjectClass = 4;
			SubClass = 2;
			Level = 12;
			ReqLevel = 7;
			Name = "Tribal Gloves";
			Name2 = "Tribal Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 297;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Ceremonial Leather Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class CeremonialLeatherGloves : Item
	{
		public CeremonialLeatherGloves() : base()
		{
			Id = 3314;
			Resistance[0] = 43;
			Bonding = 2;
			SellPrice = 171;
			AvailableClasses = 0x7FFF;
			Model = 14546;
			ObjectClass = 4;
			SubClass = 2;
			Level = 15;
			ReqLevel = 10;
			Name = "Ceremonial Leather Gloves";
			Name2 = "Ceremonial Leather Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 856;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 20;
			AgilityBonus = 2;
			StrBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Shepherd's Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class ShepherdsGloves : Item
	{
		public ShepherdsGloves() : base()
		{
			Id = 3754;
			Resistance[0] = 61;
			Bonding = 1;
			SellPrice = 1492;
			AvailableClasses = 0x7FFF;
			Model = 17186;
			ObjectClass = 4;
			SubClass = 2;
			Level = 33;
			Name = "Shepherd's Gloves";
			Name2 = "Shepherd's Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7461;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StrBonus = 7;
			AgilityBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Hardened Leather Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class HardenedLeatherGloves : Item
	{
		public HardenedLeatherGloves() : base()
		{
			Id = 3804;
			Resistance[0] = 58;
			SellPrice = 765;
			AvailableClasses = 0x7FFF;
			Model = 19044;
			ObjectClass = 4;
			SubClass = 2;
			Level = 36;
			ReqLevel = 31;
			Name = "Hardened Leather Gloves";
			Name2 = "Hardened Leather Gloves";
			AvailableRaces = 0x1FF;
			BuyPrice = 3825;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Thick Leather Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class ThickLeatherGloves : Item
	{
		public ThickLeatherGloves() : base()
		{
			Id = 3965;
			Resistance[0] = 74;
			SellPrice = 2221;
			AvailableClasses = 0x7FFF;
			Model = 17188;
			ObjectClass = 4;
			SubClass = 2;
			Level = 49;
			ReqLevel = 44;
			Name = "Thick Leather Gloves";
			Name2 = "Thick Leather Gloves";
			AvailableRaces = 0x1FF;
			BuyPrice = 11105;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Smooth Leather Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class SmoothLeatherGloves : Item
	{
		public SmoothLeatherGloves() : base()
		{
			Id = 3973;
			Resistance[0] = 84;
			SellPrice = 3657;
			AvailableClasses = 0x7FFF;
			Model = 17069;
			ObjectClass = 4;
			SubClass = 2;
			Level = 58;
			ReqLevel = 53;
			Name = "Smooth Leather Gloves";
			Name2 = "Smooth Leather Gloves";
			AvailableRaces = 0x1FF;
			BuyPrice = 18286;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Imperial Leather Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class ImperialLeatherGloves : Item
	{
		public ImperialLeatherGloves() : base()
		{
			Id = 4063;
			Resistance[0] = 73;
			Bonding = 2;
			SellPrice = 3596;
			AvailableClasses = 0x7FFF;
			Model = 17181;
			ObjectClass = 4;
			SubClass = 2;
			Level = 43;
			ReqLevel = 38;
			Name = "Imperial Leather Gloves";
			Name2 = "Imperial Leather Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 17980;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StrBonus = 9;
			AgilityBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Tiger Hunter Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class TigerHunterGloves : Item
	{
		public TigerHunterGloves() : base()
		{
			Id = 4107;
			Resistance[0] = 65;
			Bonding = 1;
			SellPrice = 2136;
			AvailableClasses = 0x7FFF;
			Model = 4438;
			ObjectClass = 4;
			SubClass = 2;
			Level = 37;
			Name = "Tiger Hunter Gloves";
			Name2 = "Tiger Hunter Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 10682;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			AgilityBonus = 8;
			StrBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Embossed Leather Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class EmbossedLeatherGloves : Item
	{
		public EmbossedLeatherGloves() : base()
		{
			Id = 4239;
			Resistance[0] = 39;
			SellPrice = 71;
			AvailableClasses = 0x7FFF;
			Model = 9503;
			ObjectClass = 4;
			SubClass = 2;
			Level = 13;
			ReqLevel = 8;
			Name = "Embossed Leather Gloves";
			Name2 = "Embossed Leather Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 357;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Hillman's Leather Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class HillmansLeatherGloves : Item
	{
		public HillmansLeatherGloves() : base()
		{
			Id = 4247;
			Resistance[0] = 57;
			Bonding = 2;
			SellPrice = 1049;
			AvailableClasses = 0x7FFF;
			Model = 2362;
			ObjectClass = 4;
			SubClass = 2;
			Level = 29;
			ReqLevel = 24;
			Name = "Hillman's Leather Gloves";
			Name2 = "Hillman's Leather Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5248;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StaminaBonus = 6;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Dark Leather Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class DarkLeatherGloves : Item
	{
		public DarkLeatherGloves() : base()
		{
			Id = 4248;
			Resistance[0] = 54;
			Bonding = 2;
			SellPrice = 791;
			AvailableClasses = 0x7FFF;
			Model = 9526;
			ObjectClass = 4;
			SubClass = 2;
			Level = 26;
			ReqLevel = 21;
			Name = "Dark Leather Gloves";
			Name2 = "Dark Leather Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3958;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			SetSpell( 9133 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Toughened Leather Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class ToughenedLeatherGloves : Item
	{
		public ToughenedLeatherGloves() : base()
		{
			Id = 4253;
			Resistance[0] = 61;
			Bonding = 2;
			SellPrice = 962;
			AvailableClasses = 0x7FFF;
			Model = 27881;
			ObjectClass = 4;
			SubClass = 2;
			Level = 27;
			ReqLevel = 22;
			Name = "Toughened Leather Gloves";
			Name2 = "Toughened Leather Gloves";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 4810;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			AgilityBonus = 6;
			IqBonus = 6;
			StaminaBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Barbaric Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class BarbaricGloves : Item
	{
		public BarbaricGloves() : base()
		{
			Id = 4254;
			Resistance[0] = 58;
			Bonding = 2;
			SellPrice = 1071;
			AvailableClasses = 0x7FFF;
			Model = 9543;
			ObjectClass = 4;
			SubClass = 2;
			Level = 30;
			ReqLevel = 25;
			Name = "Barbaric Gloves";
			Name2 = "Barbaric Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5356;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StaminaBonus = 5;
			IqBonus = 4;
			AgilityBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Seawolf Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class SeawolfGloves : Item
	{
		public SeawolfGloves() : base()
		{
			Id = 4509;
			Resistance[0] = 69;
			Bonding = 1;
			SellPrice = 2794;
			AvailableClasses = 0x7FFF;
			Model = 17185;
			ObjectClass = 4;
			SubClass = 2;
			Level = 40;
			Name = "Seawolf Gloves";
			Name2 = "Seawolf Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 13970;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StrBonus = 11;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Battleworn Leather Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class BattlewornLeatherGloves : Item
	{
		public BattlewornLeatherGloves() : base()
		{
			Id = 4914;
			Resistance[0] = 21;
			Bonding = 1;
			SellPrice = 5;
			AvailableClasses = 0x7FFF;
			Model = 17075;
			ObjectClass = 4;
			SubClass = 2;
			Level = 5;
			Name = "Battleworn Leather Gloves";
			Name2 = "Battleworn Leather Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 29;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 16;
		}
	}
}


/**************************************************************
*
*				(Veiled Grips)
*
***************************************************************/

namespace Server.Items
{
	public class VeiledGrips : Item
	{
		public VeiledGrips() : base()
		{
			Id = 4940;
			Resistance[0] = 33;
			Bonding = 1;
			SellPrice = 36;
			AvailableClasses = 0x7FFF;
			Model = 17074;
			ObjectClass = 4;
			SubClass = 2;
			Level = 10;
			Name = "Veiled Grips";
			Name2 = "Veiled Grips";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 182;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Double-layered Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class DoubleLayeredGloves : Item
	{
		public DoubleLayeredGloves() : base()
		{
			Id = 4962;
			Resistance[0] = 28;
			Bonding = 1;
			SellPrice = 20;
			AvailableClasses = 0x7FFF;
			Model = 5418;
			ObjectClass = 4;
			SubClass = 2;
			Level = 8;
			Name = "Double-layered Gloves";
			Name2 = "Double-layered Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 100;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 18;
		}
	}
}


/**************************************************************
*
*				(Prospector Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class ProspectorGloves : Item
	{
		public ProspectorGloves() : base()
		{
			Id = 4980;
			Resistance[0] = 65;
			Bonding = 1;
			SellPrice = 2209;
			AvailableClasses = 0x7FFF;
			Model = 5435;
			ObjectClass = 4;
			SubClass = 2;
			Level = 37;
			Name = "Prospector Gloves";
			Name2 = "Prospector Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11048;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			AgilityBonus = 8;
			SpiritBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Gloves of the Moon)
*
***************************************************************/

namespace Server.Items
{
	public class GlovesOfTheMoon : Item
	{
		public GlovesOfTheMoon() : base()
		{
			Id = 5299;
			Resistance[0] = 48;
			Bonding = 1;
			SellPrice = 359;
			AvailableClasses = 0x7FFF;
			Model = 17223;
			ObjectClass = 4;
			SubClass = 2;
			Level = 20;
			Name = "Gloves of the Moon";
			Name2 = "Gloves of the Moon";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1795;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 25;
			StaminaBonus = 3;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Archery Training Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class ArcheryTrainingGloves : Item
	{
		public ArcheryTrainingGloves() : base()
		{
			Id = 5394;
			Resistance[0] = 21;
			Bonding = 1;
			SellPrice = 6;
			AvailableClasses = 0x7FFF;
			Model = 7823;
			ObjectClass = 4;
			SubClass = 2;
			Level = 5;
			Name = "Archery Training Gloves";
			Name2 = "Archery Training Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 31;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 16;
		}
	}
}


/**************************************************************
*
*				(Hammerfist Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class HammerfistGloves : Item
	{
		public HammerfistGloves() : base()
		{
			Id = 5629;
			Resistance[0] = 48;
			Bonding = 1;
			SellPrice = 347;
			AvailableClasses = 0x7FFF;
			Model = 8450;
			ObjectClass = 4;
			SubClass = 2;
			Level = 20;
			Name = "Hammerfist Gloves";
			Name2 = "Hammerfist Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1736;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 25;
			StrBonus = 3;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Windfelt Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class WindfeltGloves : Item
	{
		public WindfeltGloves() : base()
		{
			Id = 5630;
			Resistance[0] = 48;
			Bonding = 1;
			SellPrice = 348;
			AvailableClasses = 0x7FFF;
			Model = 8449;
			ObjectClass = 4;
			SubClass = 2;
			Level = 20;
			Name = "Windfelt Gloves";
			Name2 = "Windfelt Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1743;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 25;
			SpiritBonus = 3;
			IqBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Sewing Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class SewingGloves : Item
	{
		public SewingGloves() : base()
		{
			Id = 5939;
			Resistance[0] = 28;
			Bonding = 1;
			SellPrice = 20;
			AvailableClasses = 0x7FFF;
			Model = 9374;
			ObjectClass = 4;
			SubClass = 2;
			Level = 8;
			Name = "Sewing Gloves";
			Name2 = "Sewing Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 100;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 18;
		}
	}
}


/**************************************************************
*
*				(Guardian Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class GuardianGloves : Item
	{
		public GuardianGloves() : base()
		{
			Id = 5966;
			Resistance[0] = 63;
			SellPrice = 1374;
			AvailableClasses = 0x7FFF;
			Model = 9549;
			ObjectClass = 4;
			SubClass = 2;
			Level = 38;
			ReqLevel = 33;
			Name = "Guardian Gloves";
			Name2 = "Guardian Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 6873;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Wolf Handler Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class WolfHandlerGloves : Item
	{
		public WolfHandlerGloves() : base()
		{
			Id = 6171;
			Resistance[0] = 21;
			Bonding = 1;
			SellPrice = 6;
			AvailableClasses = 0x7FFF;
			Model = 9374;
			ObjectClass = 4;
			SubClass = 2;
			Level = 5;
			Name = "Wolf Handler Gloves";
			Name2 = "Wolf Handler Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 32;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 16;
		}
	}
}


/**************************************************************
*
*				(Emblazoned Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class EmblazonedGloves : Item
	{
		public EmblazonedGloves() : base()
		{
			Id = 6397;
			Resistance[0] = 57;
			Bonding = 2;
			SellPrice = 985;
			AvailableClasses = 0x7FFF;
			Model = 14603;
			ObjectClass = 4;
			SubClass = 2;
			Level = 29;
			ReqLevel = 24;
			Name = "Emblazoned Gloves";
			Name2 = "Emblazoned Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4929;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StaminaBonus = 6;
			AgilityBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Insignia Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class InsigniaGloves : Item
	{
		public InsigniaGloves() : base()
		{
			Id = 6408;
			Resistance[0] = 62;
			Bonding = 2;
			SellPrice = 1654;
			AvailableClasses = 0x7FFF;
			Model = 17061;
			ObjectClass = 4;
			SubClass = 2;
			Level = 34;
			ReqLevel = 29;
			Name = "Insignia Gloves";
			Name2 = "Insignia Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 8271;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StrBonus = 7;
			AgilityBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Glyphed Mitts)
*
***************************************************************/

namespace Server.Items
{
	public class GlyphedMitts : Item
	{
		public GlyphedMitts() : base()
		{
			Id = 6419;
			Resistance[0] = 66;
			Bonding = 2;
			SellPrice = 2299;
			AvailableClasses = 0x7FFF;
			Model = 14676;
			ObjectClass = 4;
			SubClass = 2;
			Level = 38;
			ReqLevel = 33;
			Name = "Glyphed Mitts";
			Name2 = "Glyphed Mitts";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11497;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StrBonus = 8;
			AgilityBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Deviate Scale Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class DeviateScaleGloves : Item
	{
		public DeviateScaleGloves() : base()
		{
			Id = 6467;
			Resistance[0] = 49;
			Bonding = 2;
			SellPrice = 420;
			AvailableClasses = 0x7FFF;
			Model = 11952;
			ObjectClass = 4;
			SubClass = 2;
			Level = 21;
			ReqLevel = 16;
			Name = "Deviate Scale Gloves";
			Name2 = "Deviate Scale Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2103;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 25;
			StaminaBonus = 3;
			AgilityBonus = 3;
		}
	}
}


/**************************************************************
*
*				(Pioneer Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class PioneerGloves : Item
	{
		public PioneerGloves() : base()
		{
			Id = 6521;
			Resistance[0] = 35;
			SellPrice = 47;
			AvailableClasses = 0x7FFF;
			Model = 6717;
			ObjectClass = 4;
			SubClass = 2;
			Level = 11;
			ReqLevel = 6;
			Name = "Pioneer Gloves";
			Name2 = "Pioneer Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 236;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Bard's Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class BardsGloves : Item
	{
		public BardsGloves() : base()
		{
			Id = 6554;
			Resistance[0] = 45;
			Bonding = 2;
			SellPrice = 229;
			AvailableClasses = 0x7FFF;
			Model = 14729;
			ObjectClass = 4;
			SubClass = 2;
			Level = 17;
			ReqLevel = 12;
			Name = "Bard's Gloves";
			Name2 = "Bard's Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 729;
			BuyPrice = 1145;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Scouting Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class ScoutingGloves : Item
	{
		public ScoutingGloves() : base()
		{
			Id = 6586;
			Resistance[0] = 51;
			Bonding = 2;
			SellPrice = 505;
			AvailableClasses = 0x7FFF;
			Model = 14755;
			ObjectClass = 4;
			SubClass = 2;
			Level = 23;
			ReqLevel = 18;
			Name = "Scouting Gloves";
			Name2 = "Scouting Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 731;
			BuyPrice = 2526;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Dervish Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class DervishGloves : Item
	{
		public DervishGloves() : base()
		{
			Id = 6605;
			Resistance[0] = 56;
			Bonding = 2;
			SellPrice = 971;
			AvailableClasses = 0x7FFF;
			Model = 14775;
			ObjectClass = 4;
			SubClass = 2;
			Level = 28;
			ReqLevel = 23;
			Name = "Dervish Gloves";
			Name2 = "Dervish Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 733;
			BuyPrice = 4857;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Razzeric's Racing Grips)
*
***************************************************************/

namespace Server.Items
{
	public class RazzericsRacingGrips : Item
	{
		public RazzericsRacingGrips() : base()
		{
			Id = 6727;
			Resistance[0] = 70;
			Bonding = 1;
			SellPrice = 2996;
			AvailableClasses = 0x7FFF;
			Model = 17067;
			ObjectClass = 4;
			SubClass = 2;
			Level = 41;
			Name = "Razzeric's Racing Grips";
			Name2 = "Razzeric's Racing Grips";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 14982;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StaminaBonus = 9;
			AgilityBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Gnomish Mechanic's Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class GnomishMechanicsGloves : Item
	{
		public GnomishMechanicsGloves() : base()
		{
			Id = 6732;
			Resistance[0] = 66;
			Bonding = 1;
			SellPrice = 2421;
			AvailableClasses = 0x7FFF;
			Model = 12943;
			ObjectClass = 4;
			SubClass = 2;
			Level = 38;
			Name = "Gnomish Mechanic's Gloves";
			Name2 = "Gnomish Mechanic's Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 12108;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StrBonus = 8;
			SpiritBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Braced Handguards)
*
***************************************************************/

namespace Server.Items
{
	public class BracedHandguards : Item
	{
		public BracedHandguards() : base()
		{
			Id = 6784;
			Resistance[0] = 64;
			Bonding = 1;
			SellPrice = 2031;
			AvailableClasses = 0x7FFF;
			Model = 13026;
			ObjectClass = 4;
			SubClass = 2;
			Level = 36;
			Name = "Braced Handguards";
			Name2 = "Braced Handguards";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 10159;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StaminaBonus = 7;
			AgilityBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Stormfire Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class StormfireGauntlets : Item
	{
		public StormfireGauntlets() : base()
		{
			Id = 6794;
			Resistance[0] = 69;
			Bonding = 1;
			SellPrice = 2641;
			AvailableClasses = 0x7FFF;
			Model = 17187;
			ObjectClass = 4;
			SubClass = 2;
			Level = 40;
			Name = "Stormfire Gauntlets";
			Name2 = "Stormfire Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 13206;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StrBonus = 10;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Red Whelp Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class RedWhelpGloves : Item
	{
		public RedWhelpGloves() : base()
		{
			Id = 7284;
			Resistance[0] = 52;
			Bonding = 2;
			SellPrice = 586;
			AvailableClasses = 0x7FFF;
			Model = 3992;
			ObjectClass = 4;
			SubClass = 2;
			Level = 24;
			ReqLevel = 19;
			Name = "Red Whelp Gloves";
			Name2 = "Red Whelp Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2933;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 25;
			Flags = 64;
			SetSpell( 9233 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Nimble Leather Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class NimbleLeatherGloves : Item
	{
		public NimbleLeatherGloves() : base()
		{
			Id = 7285;
			Resistance[0] = 52;
			Bonding = 2;
			SellPrice = 588;
			AvailableClasses = 0x7FFF;
			Model = 14004;
			ObjectClass = 4;
			SubClass = 2;
			Level = 24;
			ReqLevel = 19;
			Name = "Nimble Leather Gloves";
			Name2 = "Nimble Leather Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 2944;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 25;
			AgilityBonus = 4;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Fletcher's Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class FletchersGloves : Item
	{
		public FletchersGloves() : base()
		{
			Id = 7348;
			Resistance[0] = 53;
			Bonding = 2;
			SellPrice = 690;
			AvailableClasses = 0x7FFF;
			Model = 6735;
			ObjectClass = 4;
			SubClass = 2;
			Level = 25;
			ReqLevel = 20;
			Name = "Fletcher's Gloves";
			Name2 = "Fletcher's Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3454;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			SetSpell( 9132 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 21352 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Herbalist's Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class HerbalistsGloves : Item
	{
		public HerbalistsGloves() : base()
		{
			Id = 7349;
			Resistance[0] = 55;
			Bonding = 2;
			SellPrice = 861;
			AvailableClasses = 0x7FFF;
			Model = 17230;
			ObjectClass = 4;
			SubClass = 2;
			Level = 27;
			ReqLevel = 22;
			Name = "Herbalist's Gloves";
			Name2 = "Herbalist's Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4308;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			SetSpell( 9134 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Pilferer's Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class PilferersGloves : Item
	{
		public PilferersGloves() : base()
		{
			Id = 7358;
			Resistance[0] = 56;
			Bonding = 2;
			SellPrice = 885;
			AvailableClasses = 0x7FFF;
			Model = 2057;
			ObjectClass = 4;
			SubClass = 2;
			Level = 28;
			ReqLevel = 23;
			Name = "Pilferer's Gloves";
			Name2 = "Pilferer's Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4428;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			AgilityBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Heavy Earthen Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class HeavyEarthenGloves : Item
	{
		public HeavyEarthenGloves() : base()
		{
			Id = 7359;
			Resistance[0] = 57;
			Bonding = 2;
			SellPrice = 978;
			AvailableClasses = 0x7FFF;
			Model = 17225;
			ObjectClass = 4;
			SubClass = 2;
			Level = 29;
			ReqLevel = 24;
			Name = "Heavy Earthen Gloves";
			Name2 = "Heavy Earthen Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 4890;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			SetSpell( 9329 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Infiltrator Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class InfiltratorGloves : Item
	{
		public InfiltratorGloves() : base()
		{
			Id = 7412;
			Resistance[0] = 60;
			Bonding = 2;
			SellPrice = 1302;
			AvailableClasses = 0x7FFF;
			Model = 21902;
			ObjectClass = 4;
			SubClass = 2;
			Level = 32;
			ReqLevel = 27;
			Name = "Infiltrator Gloves";
			Name2 = "Infiltrator Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 734;
			BuyPrice = 6512;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Sentinel Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class SentinelGloves : Item
	{
		public SentinelGloves() : base()
		{
			Id = 7443;
			Resistance[0] = 65;
			Bonding = 2;
			SellPrice = 2243;
			AvailableClasses = 0x7FFF;
			Model = 15000;
			ObjectClass = 4;
			SubClass = 2;
			Level = 37;
			ReqLevel = 32;
			Name = "Sentinel Gloves";
			Name2 = "Sentinel Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 736;
			BuyPrice = 11217;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Ranger Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class RangerGloves : Item
	{
		public RangerGloves() : base()
		{
			Id = 7480;
			Resistance[0] = 70;
			Bonding = 2;
			SellPrice = 3019;
			AvailableClasses = 0x7FFF;
			Model = 15018;
			ObjectClass = 4;
			SubClass = 2;
			Level = 41;
			ReqLevel = 36;
			Name = "Ranger Gloves";
			Name2 = "Ranger Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 737;
			BuyPrice = 15095;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Cabalist Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class CabalistGloves : Item
	{
		public CabalistGloves() : base()
		{
			Id = 7530;
			Resistance[0] = 77;
			Bonding = 2;
			SellPrice = 4273;
			AvailableClasses = 0x7FFF;
			Model = 15415;
			ObjectClass = 4;
			SubClass = 2;
			Level = 46;
			ReqLevel = 41;
			Name = "Cabalist Gloves";
			Name2 = "Cabalist Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 739;
			BuyPrice = 21366;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Ebon Vise)
*
***************************************************************/

namespace Server.Items
{
	public class EbonVise : Item
	{
		public EbonVise() : base()
		{
			Id = 7690;
			Resistance[0] = 70;
			Bonding = 1;
			SellPrice = 2232;
			AvailableClasses = 0x7FFF;
			Model = 15753;
			ObjectClass = 4;
			SubClass = 2;
			Level = 35;
			ReqLevel = 30;
			Name = "Ebon Vise";
			Name2 = "Ebon Vise";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 11164;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			StrBonus = 4;
			AgilityBonus = 6;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Dog Training Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class DogTrainingGloves : Item
	{
		public DogTrainingGloves() : base()
		{
			Id = 7756;
			Resistance[0] = 62;
			Bonding = 1;
			SellPrice = 1606;
			AvailableClasses = 0x7FFF;
			Model = 15894;
			ObjectClass = 4;
			SubClass = 2;
			Level = 34;
			ReqLevel = 29;
			Name = "Dog Training Gloves";
			Name2 = "Dog Training Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 8030;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			SetSpell( 14565 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Ninja Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class NinjaGloves : Item
	{
		public NinjaGloves() : base()
		{
			Id = 7951;
			Resistance[0] = 26;
			Bonding = 1;
			SellPrice = 1134;
			AvailableClasses = 0x7FFF;
			Model = 17183;
			Resistance[2] = 1;
			ObjectClass = 4;
			SubClass = 2;
			Level = 30;
			Name = "Ninja Gloves";
			Name2 = "Ninja Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5671;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
		}
	}
}


/**************************************************************
*
*				(Heraldic Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class HeraldicGloves : Item
	{
		public HeraldicGloves() : base()
		{
			Id = 8121;
			Resistance[0] = 79;
			Bonding = 2;
			SellPrice = 4843;
			AvailableClasses = 0x7FFF;
			Model = 14698;
			ObjectClass = 4;
			SubClass = 2;
			Level = 47;
			ReqLevel = 42;
			Name = "Heraldic Gloves";
			Name2 = "Heraldic Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 24219;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StrBonus = 10;
			AgilityBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Serpentskin Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class SerpentskinGloves : Item
	{
		public SerpentskinGloves() : base()
		{
			Id = 8260;
			Resistance[0] = 86;
			Bonding = 2;
			SellPrice = 6938;
			AvailableClasses = 0x7FFF;
			Model = 17263;
			ObjectClass = 4;
			SubClass = 2;
			Level = 52;
			ReqLevel = 47;
			Name = "Serpentskin Gloves";
			Name2 = "Serpentskin Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 34691;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StrBonus = 11;
			AgilityBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Traveler's Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class TravelersGloves : Item
	{
		public TravelersGloves() : base()
		{
			Id = 8298;
			Resistance[0] = 92;
			Bonding = 2;
			SellPrice = 8565;
			AvailableClasses = 0x7FFF;
			Model = 17314;
			ObjectClass = 4;
			SubClass = 2;
			Level = 57;
			ReqLevel = 52;
			Name = "Traveler's Gloves";
			Name2 = "Traveler's Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 42825;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StrBonus = 13;
			SpiritBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Gauntlets of the Sea)
*
***************************************************************/

namespace Server.Items
{
	public class GauntletsOfTheSea : Item
	{
		public GauntletsOfTheSea() : base()
		{
			Id = 8346;
			Resistance[0] = 85;
			Bonding = 2;
			SellPrice = 5363;
			AvailableClasses = 0x7FFF;
			Model = 16678;
			ObjectClass = 4;
			SubClass = 2;
			Level = 46;
			ReqLevel = 41;
			Name = "Gauntlets of the Sea";
			Name2 = "Gauntlets of the Sea";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 26815;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			SetSpell( 10577 , 0 , 0 , 1800000 , 30 , 180000 );
			AgilityBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Mud's Crushers)
*
***************************************************************/

namespace Server.Items
{
	public class MudsCrushers : Item
	{
		public MudsCrushers() : base()
		{
			Id = 9518;
			Resistance[0] = 64;
			Bonding = 1;
			SellPrice = 1899;
			AvailableClasses = 0x7FFF;
			Model = 18443;
			ObjectClass = 4;
			SubClass = 2;
			Level = 36;
			Name = "Mud's Crushers";
			Name2 = "Mud's Crushers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 9499;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StrBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Pratt's Handcrafted Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class PrattsHandcraftedGloves : Item
	{
		public PrattsHandcraftedGloves() : base()
		{
			Id = 9631;
			Resistance[0] = 76;
			Bonding = 1;
			SellPrice = 3868;
			AvailableClasses = 0x7FFF;
			Model = 28339;
			ObjectClass = 4;
			SubClass = 2;
			Level = 45;
			Name = "Pratt's Handcrafted Gloves";
			Name2 = "Pratt's Handcrafted Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 19341;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StrBonus = 10;
			AgilityBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Jangdor's Handcrafted Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class JangdorsHandcraftedGloves : Item
	{
		public JangdorsHandcraftedGloves() : base()
		{
			Id = 9632;
			Resistance[0] = 76;
			Bonding = 1;
			SellPrice = 3883;
			AvailableClasses = 0x7FFF;
			Model = 28283;
			ObjectClass = 4;
			SubClass = 2;
			Level = 45;
			Name = "Jangdor's Handcrafted Gloves";
			Name2 = "Jangdor's Handcrafted Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 19416;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StrBonus = 10;
			AgilityBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Gloves of Insight)
*
***************************************************************/

namespace Server.Items
{
	public class GlovesOfInsight : Item
	{
		public GlovesOfInsight() : base()
		{
			Id = 9698;
			Resistance[0] = 61;
			Bonding = 1;
			SellPrice = 1504;
			AvailableClasses = 0x7FFF;
			Model = 17186;
			ObjectClass = 4;
			SubClass = 2;
			Level = 33;
			Name = "Gloves of Insight";
			Name2 = "Gloves of Insight";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 7524;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StaminaBonus = 7;
			SpiritBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Rustler Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class RustlerGloves : Item
	{
		public RustlerGloves() : base()
		{
			Id = 9704;
			Resistance[0] = 73;
			Bonding = 1;
			SellPrice = 3573;
			AvailableClasses = 0x7FFF;
			Model = 28296;
			ObjectClass = 4;
			SubClass = 2;
			Level = 43;
			Name = "Rustler Gloves";
			Name2 = "Rustler Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 17865;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StrBonus = 9;
			SpiritBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Gypsy Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class GypsyGloves : Item
	{
		public GypsyGloves() : base()
		{
			Id = 9755;
			Resistance[0] = 39;
			SellPrice = 73;
			AvailableClasses = 0x7FFF;
			Model = 19032;
			ObjectClass = 4;
			SubClass = 2;
			Level = 13;
			ReqLevel = 8;
			Name = "Gypsy Gloves";
			Name2 = "Gypsy Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 366;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Bandit Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class BanditGloves : Item
	{
		public BanditGloves() : base()
		{
			Id = 9780;
			Resistance[0] = 48;
			Bonding = 2;
			SellPrice = 369;
			AvailableClasses = 0x7FFF;
			Model = 28428;
			ObjectClass = 4;
			SubClass = 2;
			Level = 20;
			ReqLevel = 15;
			Name = "Bandit Gloves";
			Name2 = "Bandit Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 730;
			BuyPrice = 1849;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Superior Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class SuperiorGloves : Item
	{
		public SuperiorGloves() : base()
		{
			Id = 9806;
			Resistance[0] = 55;
			Bonding = 2;
			SellPrice = 833;
			AvailableClasses = 0x7FFF;
			Model = 2358;
			ObjectClass = 4;
			SubClass = 2;
			Level = 27;
			ReqLevel = 22;
			Name = "Superior Gloves";
			Name2 = "Superior Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 732;
			BuyPrice = 4169;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Scaled Leather Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class ScaledLeatherGloves : Item
	{
		public ScaledLeatherGloves() : base()
		{
			Id = 9832;
			Resistance[0] = 59;
			Bonding = 2;
			SellPrice = 1248;
			AvailableClasses = 0x7FFF;
			Model = 27766;
			ObjectClass = 4;
			SubClass = 2;
			Level = 31;
			ReqLevel = 26;
			Name = "Scaled Leather Gloves";
			Name2 = "Scaled Leather Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 734;
			BuyPrice = 6240;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Archer's Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class ArchersGloves : Item
	{
		public ArchersGloves() : base()
		{
			Id = 9861;
			Resistance[0] = 63;
			Bonding = 2;
			SellPrice = 1753;
			AvailableClasses = 0x7FFF;
			Model = 18929;
			ObjectClass = 4;
			SubClass = 2;
			Level = 35;
			ReqLevel = 30;
			Name = "Archer's Gloves";
			Name2 = "Archer's Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 735;
			BuyPrice = 8768;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Huntsman's Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class HuntsmansGloves : Item
	{
		public HuntsmansGloves() : base()
		{
			Id = 9892;
			Resistance[0] = 69;
			Bonding = 2;
			SellPrice = 2857;
			AvailableClasses = 0x7FFF;
			Model = 18912;
			ObjectClass = 4;
			SubClass = 2;
			Level = 40;
			ReqLevel = 35;
			Name = "Huntsman's Gloves";
			Name2 = "Huntsman's Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 737;
			BuyPrice = 14287;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Tracker's Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class TrackersGloves : Item
	{
		public TrackersGloves() : base()
		{
			Id = 9920;
			Resistance[0] = 75;
			Bonding = 2;
			SellPrice = 3721;
			AvailableClasses = 0x7FFF;
			Model = 18936;
			ObjectClass = 4;
			SubClass = 2;
			Level = 44;
			ReqLevel = 39;
			Name = "Tracker's Gloves";
			Name2 = "Tracker's Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 738;
			BuyPrice = 18606;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Chieftain's Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class ChieftainsGloves : Item
	{
		public ChieftainsGloves() : base()
		{
			Id = 9952;
			Resistance[0] = 82;
			Bonding = 2;
			SellPrice = 5255;
			AvailableClasses = 0x7FFF;
			Model = 18946;
			ObjectClass = 4;
			SubClass = 2;
			Level = 49;
			ReqLevel = 44;
			Name = "Chieftain's Gloves";
			Name2 = "Chieftain's Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 740;
			BuyPrice = 26276;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Righteous Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class RighteousGloves : Item
	{
		public RighteousGloves() : base()
		{
			Id = 10072;
			Resistance[0] = 84;
			Bonding = 2;
			SellPrice = 6177;
			AvailableClasses = 0x7FFF;
			Model = 19017;
			ObjectClass = 4;
			SubClass = 2;
			Level = 51;
			ReqLevel = 46;
			Name = "Righteous Gloves";
			Name2 = "Righteous Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 740;
			BuyPrice = 30886;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Wanderer's Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class WanderersGloves : Item
	{
		public WanderersGloves() : base()
		{
			Id = 10110;
			Resistance[0] = 90;
			Bonding = 2;
			SellPrice = 7947;
			AvailableClasses = 0x7FFF;
			Model = 27726;
			ObjectClass = 4;
			SubClass = 2;
			Level = 55;
			ReqLevel = 50;
			Name = "Wanderer's Gloves";
			Name2 = "Wanderer's Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 742;
			BuyPrice = 39739;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Mighty Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class MightyGauntlets : Item
	{
		public MightyGauntlets() : base()
		{
			Id = 10149;
			Resistance[0] = 97;
			Bonding = 2;
			SellPrice = 10915;
			AvailableClasses = 0x7FFF;
			Model = 27745;
			ObjectClass = 4;
			SubClass = 2;
			Level = 61;
			ReqLevel = 56;
			Name = "Mighty Gauntlets";
			Name2 = "Mighty Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 744;
			BuyPrice = 54579;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Swashbuckler's Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class SwashbucklersGloves : Item
	{
		public SwashbucklersGloves() : base()
		{
			Id = 10186;
			Resistance[0] = 87;
			Bonding = 2;
			SellPrice = 6966;
			AvailableClasses = 0x7FFF;
			Model = 19005;
			ObjectClass = 4;
			SubClass = 2;
			Level = 53;
			ReqLevel = 48;
			Name = "Swashbuckler's Gloves";
			Name2 = "Swashbuckler's Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 741;
			BuyPrice = 34834;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Nightshade Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class NightshadeGloves : Item
	{
		public NightshadeGloves() : base()
		{
			Id = 10225;
			Resistance[0] = 95;
			Bonding = 2;
			SellPrice = 10012;
			AvailableClasses = 0x7FFF;
			Model = 18981;
			ObjectClass = 4;
			SubClass = 2;
			Level = 59;
			ReqLevel = 54;
			Name = "Nightshade Gloves";
			Name2 = "Nightshade Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 743;
			BuyPrice = 50062;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Adventurer's Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class AdventurersGloves : Item
	{
		public AdventurersGloves() : base()
		{
			Id = 10260;
			Resistance[0] = 100;
			Bonding = 2;
			SellPrice = 11945;
			AvailableClasses = 0x7FFF;
			Model = 27845;
			ObjectClass = 4;
			SubClass = 2;
			Level = 63;
			ReqLevel = 58;
			Name = "Adventurer's Gloves";
			Name2 = "Adventurer's Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 744;
			BuyPrice = 59729;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Blackened Defias Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class BlackenedDefiasGloves : Item
	{
		public BlackenedDefiasGloves() : base()
		{
			Id = 10401;
			Resistance[0] = 46;
			Bonding = 2;
			SellPrice = 255;
			AvailableClasses = 0x7FFF;
			Model = 27946;
			ObjectClass = 4;
			SubClass = 2;
			Level = 18;
			ReqLevel = 13;
			Name = "Blackened Defias Gloves";
			Name2 = "Blackened Defias Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1278;
			Sets = 161;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 20;
			StrBonus = 3;
			StaminaBonus = 1;
		}
	}
}


/**************************************************************
*
*				(Gloves of the Fang)
*
***************************************************************/

namespace Server.Items
{
	public class GlovesOfTheFang : Item
	{
		public GlovesOfTheFang() : base()
		{
			Id = 10413;
			Resistance[0] = 47;
			Bonding = 2;
			SellPrice = 307;
			AvailableClasses = 0x7FFF;
			Model = 19125;
			ObjectClass = 4;
			SubClass = 2;
			Level = 19;
			ReqLevel = 14;
			Name = "Gloves of the Fang";
			Name2 = "Gloves of the Fang";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1539;
			Sets = 162;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 25;
			AgilityBonus = 3;
			StrBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Nomadic Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class NomadicGloves : Item
	{
		public NomadicGloves() : base()
		{
			Id = 10636;
			Resistance[0] = 21;
			Bonding = 1;
			SellPrice = 6;
			AvailableClasses = 0x7FFF;
			Model = 12415;
			ObjectClass = 4;
			SubClass = 2;
			Level = 5;
			Name = "Nomadic Gloves";
			Name2 = "Nomadic Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 30;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 16;
		}
	}
}


/**************************************************************
*
*				(Swine Fists)
*
***************************************************************/

namespace Server.Items
{
	public class SwineFists : Item
	{
		public SwineFists() : base()
		{
			Id = 10760;
			Resistance[0] = 68;
			Bonding = 1;
			SellPrice = 2428;
			AvailableClasses = 0x7FFF;
			Model = 28683;
			ObjectClass = 4;
			SubClass = 2;
			Level = 39;
			ReqLevel = 34;
			Name = "Swine Fists";
			Name2 = "Swine Fists";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 12141;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StrBonus = 8;
			AgilityBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Bonefingers)
*
***************************************************************/

namespace Server.Items
{
	public class Bonefingers : Item
	{
		public Bonefingers() : base()
		{
			Id = 10765;
			Resistance[0] = 73;
			Bonding = 1;
			SellPrice = 3367;
			AvailableClasses = 0x7FFF;
			Model = 28688;
			ObjectClass = 4;
			SubClass = 2;
			Level = 43;
			ReqLevel = 38;
			Name = "Bonefingers";
			Name2 = "Bonefingers";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 16837;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StaminaBonus = 9;
			SpiritBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Arachnid Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class ArachnidGloves : Item
	{
		public ArachnidGloves() : base()
		{
			Id = 10777;
			Resistance[0] = 79;
			Bonding = 1;
			SellPrice = 4014;
			AvailableClasses = 0x7FFF;
			Model = 28595;
			ObjectClass = 4;
			SubClass = 2;
			Level = 42;
			ReqLevel = 37;
			Name = "Arachnid Gloves";
			Name2 = "Arachnid Gloves";
			Resistance[3] = 10;
			Quality = 3;
			AvailableRaces = 0x1FF;
			Extra = 739;
			BuyPrice = 20070;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Ogreseer Fists)
*
***************************************************************/

namespace Server.Items
{
	public class OgreseerFists : Item
	{
		public OgreseerFists() : base()
		{
			Id = 11665;
			Resistance[0] = 88;
			Bonding = 1;
			SellPrice = 7110;
			AvailableClasses = 0x7FFF;
			Model = 17263;
			ObjectClass = 4;
			SubClass = 2;
			Level = 54;
			ReqLevel = 49;
			Name = "Ogreseer Fists";
			Name2 = "Ogreseer Fists";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 35550;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			IqBonus = 10;
			SpiritBonus = 10;
			StrBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Nightfall Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class NightfallGloves : Item
	{
		public NightfallGloves() : base()
		{
			Id = 12114;
			Resistance[0] = 91;
			Bonding = 1;
			SellPrice = 8734;
			AvailableClasses = 0x7FFF;
			Model = 28222;
			ObjectClass = 4;
			SubClass = 2;
			Level = 56;
			Name = "Nightfall Gloves";
			Name2 = "Nightfall Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 43671;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			AgilityBonus = 12;
			StrBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Bloodfire Talons)
*
***************************************************************/

namespace Server.Items
{
	public class BloodfireTalons : Item
	{
		public BloodfireTalons() : base()
		{
			Id = 12464;
			Resistance[0] = 96;
			Bonding = 1;
			SellPrice = 8520;
			AvailableClasses = 0x7FFF;
			Model = 28680;
			Resistance[2] = 10;
			ObjectClass = 4;
			SubClass = 2;
			Level = 53;
			ReqLevel = 48;
			Name = "Bloodfire Talons";
			Name2 = "Bloodfire Talons";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 42601;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			SetSpell( 9346 , 1 , 0 , 0 , 0 , 0 );
			IqBonus = 9;
			SpiritBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Bingles' Flying Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class BinglesFlyingGloves : Item
	{
		public BinglesFlyingGloves() : base()
		{
			Id = 12522;
			Resistance[0] = 43;
			Bonding = 1;
			SellPrice = 182;
			AvailableClasses = 0x7FFF;
			Model = 28077;
			ObjectClass = 4;
			SubClass = 2;
			Level = 15;
			Name = "Bingles' Flying Gloves";
			Name2 = "Bingles' Flying Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 910;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 20;
			AgilityBonus = 2;
			SpiritBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Mar Alom's Grip)
*
***************************************************************/

namespace Server.Items
{
	public class MarAlomsGrip : Item
	{
		public MarAlomsGrip() : base()
		{
			Id = 12547;
			Resistance[0] = 100;
			Bonding = 2;
			SellPrice = 10519;
			AvailableClasses = 0x7FFF;
			Model = 28797;
			ObjectClass = 4;
			SubClass = 2;
			Level = 56;
			ReqLevel = 51;
			Name = "Mar Alom's Grip";
			Name2 = "Mar Alom's Grip";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 52596;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			SetSpell( 9408 , 1 , 0 , 0 , 0 , 0 );
			IqBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Fallbrush Handgrips)
*
***************************************************************/

namespace Server.Items
{
	public class FallbrushHandgrips : Item
	{
		public FallbrushHandgrips() : base()
		{
			Id = 13184;
			Resistance[0] = 107;
			Bonding = 1;
			SellPrice = 13638;
			AvailableClasses = 0x7FFF;
			Model = 23736;
			ObjectClass = 4;
			SubClass = 2;
			Level = 61;
			ReqLevel = 56;
			Name = "Fallbrush Handgrips";
			Name2 = "Fallbrush Handgrips";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 68191;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			IqBonus = 22;
			SpiritBonus = 5;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Slaghide Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class SlaghideGauntlets : Item
	{
		public SlaghideGauntlets() : base()
		{
			Id = 13258;
			Resistance[0] = 207;
			Bonding = 1;
			SellPrice = 13343;
			AvailableClasses = 0x7FFF;
			Model = 23853;
			ObjectClass = 4;
			SubClass = 2;
			Level = 61;
			ReqLevel = 56;
			Name = "Slaghide Gauntlets";
			Name2 = "Slaghide Gauntlets";
			Quality = 3;
			AvailableRaces = 0x1FF;
			Extra = 745;
			BuyPrice = 66715;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 35;
		}
	}
}


/**************************************************************
*
*				(Skul's Fingerbone Claws)
*
***************************************************************/

namespace Server.Items
{
	public class SkulsFingerboneClaws : Item
	{
		public SkulsFingerboneClaws() : base()
		{
			Id = 13395;
			Resistance[0] = 105;
			Bonding = 1;
			SellPrice = 11403;
			AvailableClasses = 0x7FFF;
			Model = 29009;
			ObjectClass = 4;
			SubClass = 2;
			Level = 59;
			ReqLevel = 54;
			Name = "Skul's Fingerbone Claws";
			Name2 = "Skul's Fingerbone Claws";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 57019;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			SetSpell( 14049 , 1 , 0 , 0 , 0 , 0 );
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Gargoyle Slashers)
*
***************************************************************/

namespace Server.Items
{
	public class GargoyleSlashers : Item
	{
		public GargoyleSlashers() : base()
		{
			Id = 13957;
			Resistance[0] = 107;
			Bonding = 1;
			SellPrice = 12427;
			AvailableClasses = 0x7FFF;
			Model = 24768;
			ObjectClass = 4;
			SubClass = 2;
			Level = 61;
			ReqLevel = 56;
			Name = "Gargoyle Slashers";
			Name2 = "Gargoyle Slashers";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 62139;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			SetSpell( 7597 , 1 , 0 , 0 , 0 , 0 );
			AgilityBonus = 5;
			StrBonus = 10;
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Prospector's Mitts)
*
***************************************************************/

namespace Server.Items
{
	public class ProspectorsMitts : Item
	{
		public ProspectorsMitts() : base()
		{
			Id = 14564;
			Resistance[0] = 47;
			Bonding = 2;
			SellPrice = 304;
			AvailableClasses = 0x7FFF;
			Model = 27519;
			ObjectClass = 4;
			SubClass = 2;
			Level = 19;
			ReqLevel = 14;
			Name = "Prospector's Mitts";
			Name2 = "Prospector's Mitts";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1523;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 25;
			StrBonus = 3;
			AgilityBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Bristlebark Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class BristlebarkGloves : Item
	{
		public BristlebarkGloves() : base()
		{
			Id = 14572;
			Resistance[0] = 52;
			Bonding = 2;
			SellPrice = 609;
			AvailableClasses = 0x7FFF;
			Model = 27672;
			ObjectClass = 4;
			SubClass = 2;
			Level = 24;
			ReqLevel = 19;
			Name = "Bristlebark Gloves";
			Name2 = "Bristlebark Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 3047;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 25;
			AgilityBonus = 4;
			StrBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Dokebi Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class DokebiGloves : Item
	{
		public DokebiGloves() : base()
		{
			Id = 14583;
			Resistance[0] = 60;
			Bonding = 2;
			SellPrice = 1333;
			AvailableClasses = 0x7FFF;
			Model = 27966;
			ObjectClass = 4;
			SubClass = 2;
			Level = 32;
			ReqLevel = 27;
			Name = "Dokebi Gloves";
			Name2 = "Dokebi Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 6668;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			SpiritBonus = 6;
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Hawkeye's Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class HawkeyesGloves : Item
	{
		public HawkeyesGloves() : base()
		{
			Id = 14594;
			Resistance[0] = 65;
			Bonding = 2;
			SellPrice = 2236;
			AvailableClasses = 0x7FFF;
			Model = 27977;
			ObjectClass = 4;
			SubClass = 2;
			Level = 37;
			ReqLevel = 32;
			Name = "Hawkeye's Gloves";
			Name2 = "Hawkeye's Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11182;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StaminaBonus = 7;
			AgilityBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Warden's Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class WardensGloves : Item
	{
		public WardensGloves() : base()
		{
			Id = 14606;
			Resistance[0] = 70;
			Bonding = 2;
			SellPrice = 2955;
			AvailableClasses = 0x7FFF;
			Model = 15000;
			ObjectClass = 4;
			SubClass = 2;
			Level = 41;
			ReqLevel = 36;
			Name = "Warden's Gloves";
			Name2 = "Warden's Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 14775;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			IqBonus = 11;
			SpiritBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Cadaverous Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class CadaverousGloves : Item
	{
		public CadaverousGloves() : base()
		{
			Id = 14640;
			Resistance[0] = 97;
			Bonding = 1;
			SellPrice = 10556;
			AvailableClasses = 0x7FFF;
			Model = 25253;
			ObjectClass = 4;
			SubClass = 2;
			Level = 61;
			ReqLevel = 56;
			Name = "Cadaverous Gloves";
			Name2 = "Cadaverous Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 52783;
			Sets = 121;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StrBonus = 11;
			IqBonus = 10;
			AgilityBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Scorpashi Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class ScorpashiGloves : Item
	{
		public ScorpashiGloves() : base()
		{
			Id = 14657;
			Resistance[0] = 77;
			Bonding = 2;
			SellPrice = 4195;
			AvailableClasses = 0x7FFF;
			Model = 27577;
			ObjectClass = 4;
			SubClass = 2;
			Level = 46;
			ReqLevel = 41;
			Name = "Scorpashi Gloves";
			Name2 = "Scorpashi Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 20979;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			IqBonus = 12;
			AgilityBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Keeper's Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class KeepersGloves : Item
	{
		public KeepersGloves() : base()
		{
			Id = 14666;
			Resistance[0] = 84;
			Bonding = 2;
			SellPrice = 6367;
			AvailableClasses = 0x7FFF;
			Model = 27567;
			ObjectClass = 4;
			SubClass = 2;
			Level = 51;
			ReqLevel = 46;
			Name = "Keeper's Gloves";
			Name2 = "Keeper's Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 31836;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			SpiritBonus = 11;
			IqBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Pridelord Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class PridelordGloves : Item
	{
		public PridelordGloves() : base()
		{
			Id = 14675;
			Resistance[0] = 91;
			Bonding = 2;
			SellPrice = 8182;
			AvailableClasses = 0x7FFF;
			Model = 27648;
			ObjectClass = 4;
			SubClass = 2;
			Level = 56;
			ReqLevel = 51;
			Name = "Pridelord Gloves";
			Name2 = "Pridelord Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 40910;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			AgilityBonus = 12;
			StaminaBonus = 8;
			StrBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Indomitable Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class IndomitableGauntlets : Item
	{
		public IndomitableGauntlets() : base()
		{
			Id = 14685;
			Resistance[0] = 99;
			Bonding = 2;
			SellPrice = 11594;
			AvailableClasses = 0x7FFF;
			Model = 17263;
			ObjectClass = 4;
			SubClass = 2;
			Level = 62;
			ReqLevel = 57;
			Name = "Indomitable Gauntlets";
			Name2 = "Indomitable Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 57970;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			StaminaBonus = 13;
			SpiritBonus = 14;
		}
	}
}


/**************************************************************
*
*				(Primal Mitts)
*
***************************************************************/

namespace Server.Items
{
	public class PrimalMitts : Item
	{
		public PrimalMitts() : base()
		{
			Id = 15008;
			Resistance[0] = 33;
			SellPrice = 37;
			AvailableClasses = 0x7FFF;
			Model = 28009;
			ObjectClass = 4;
			SubClass = 2;
			Level = 10;
			ReqLevel = 5;
			Name = "Primal Mitts";
			Name2 = "Primal Mitts";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 186;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Lupine Handwraps)
*
***************************************************************/

namespace Server.Items
{
	public class LupineHandwraps : Item
	{
		public LupineHandwraps() : base()
		{
			Id = 15016;
			Resistance[0] = 44;
			Bonding = 2;
			SellPrice = 200;
			AvailableClasses = 0x7FFF;
			Model = 27990;
			ObjectClass = 4;
			SubClass = 2;
			Level = 16;
			ReqLevel = 11;
			Name = "Lupine Handwraps";
			Name2 = "Lupine Handwraps";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 729;
			BuyPrice = 1001;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Devilsaur Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class DevilsaurGauntlets : Item
	{
		public DevilsaurGauntlets() : base()
		{
			Id = 15063;
			Resistance[0] = 103;
			Bonding = 2;
			SellPrice = 11701;
			AvailableClasses = 0x7FFF;
			Model = 26072;
			ObjectClass = 4;
			SubClass = 2;
			Level = 58;
			ReqLevel = 53;
			Name = "Devilsaur Gauntlets";
			Name2 = "Devilsaur Gauntlets";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 58505;
			Sets = 143;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			SetSpell( 9335 , 1 , 0 , 0 , 0 , 0 );
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Frostsaber Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class FrostsaberGloves : Item
	{
		public FrostsaberGloves() : base()
		{
			Id = 15070;
			Resistance[0] = 95;
			Bonding = 2;
			SellPrice = 9504;
			AvailableClasses = 0x7FFF;
			Model = 25702;
			Resistance[4] = 13;
			ObjectClass = 4;
			SubClass = 2;
			Level = 59;
			ReqLevel = 54;
			Name = "Frostsaber Gloves";
			Name2 = "Frostsaber Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 47521;
			Resistance[5] = 12;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Chimeric Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class ChimericGloves : Item
	{
		public ChimericGloves() : base()
		{
			Id = 15074;
			Resistance[6] = 11;
			Resistance[0] = 87;
			Bonding = 2;
			SellPrice = 6867;
			AvailableClasses = 0x7FFF;
			Model = 25706;
			ObjectClass = 4;
			SubClass = 2;
			Level = 53;
			ReqLevel = 48;
			Name = "Chimeric Gloves";
			Name2 = "Chimeric Gloves";
			Resistance[3] = 12;
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 34335;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Wicked Leather Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class WickedLeatherGauntlets : Item
	{
		public WickedLeatherGauntlets() : base()
		{
			Id = 15083;
			Resistance[0] = 86;
			Bonding = 2;
			SellPrice = 6872;
			AvailableClasses = 0x7FFF;
			Model = 25724;
			ObjectClass = 4;
			SubClass = 2;
			Level = 52;
			ReqLevel = 47;
			Name = "Wicked Leather Gauntlets";
			Name2 = "Wicked Leather Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 34363;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			AgilityBonus = 12;
			StaminaBonus = 11;
		}
	}
}


/**************************************************************
*
*				(Runic Leather Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class RunicLeatherGauntlets : Item
	{
		public RunicLeatherGauntlets() : base()
		{
			Id = 15091;
			Resistance[0] = 88;
			Bonding = 2;
			SellPrice = 7195;
			AvailableClasses = 0x7FFF;
			Model = 25735;
			ObjectClass = 4;
			SubClass = 2;
			Level = 54;
			ReqLevel = 49;
			Name = "Runic Leather Gauntlets";
			Name2 = "Runic Leather Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 35978;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			IqBonus = 14;
			SpiritBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Rigid Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class RigidGloves : Item
	{
		public RigidGloves() : base()
		{
			Id = 15115;
			Resistance[0] = 50;
			Bonding = 2;
			SellPrice = 473;
			AvailableClasses = 0x7FFF;
			Model = 27878;
			ObjectClass = 4;
			SubClass = 2;
			Level = 22;
			ReqLevel = 17;
			Name = "Rigid Gloves";
			Name2 = "Rigid Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 731;
			BuyPrice = 2369;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 25;
		}
	}
}


/**************************************************************
*
*				(Robust Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class RobustGloves : Item
	{
		public RobustGloves() : base()
		{
			Id = 15125;
			Resistance[0] = 57;
			Bonding = 2;
			SellPrice = 990;
			AvailableClasses = 0x7FFF;
			Model = 27881;
			ObjectClass = 4;
			SubClass = 2;
			Level = 29;
			ReqLevel = 24;
			Name = "Robust Gloves";
			Name2 = "Robust Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 733;
			BuyPrice = 4954;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Cutthroat's Mitts)
*
***************************************************************/

namespace Server.Items
{
	public class CutthroatsMitts : Item
	{
		public CutthroatsMitts() : base()
		{
			Id = 15137;
			Resistance[0] = 61;
			Bonding = 2;
			SellPrice = 1516;
			AvailableClasses = 0x7FFF;
			Model = 27715;
			ObjectClass = 4;
			SubClass = 2;
			Level = 33;
			ReqLevel = 28;
			Name = "Cutthroat's Mitts";
			Name2 = "Cutthroat's Mitts";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 734;
			BuyPrice = 7583;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Ghostwalker Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class GhostwalkerGloves : Item
	{
		public GhostwalkerGloves() : base()
		{
			Id = 15149;
			Resistance[0] = 64;
			Bonding = 2;
			SellPrice = 1960;
			AvailableClasses = 0x7FFF;
			Model = 3846;
			ObjectClass = 4;
			SubClass = 2;
			Level = 36;
			ReqLevel = 31;
			Name = "Ghostwalker Gloves";
			Name2 = "Ghostwalker Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 735;
			BuyPrice = 9800;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Nocturnal Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class NocturnalGloves : Item
	{
		public NocturnalGloves() : base()
		{
			Id = 15155;
			Resistance[0] = 68;
			Bonding = 2;
			SellPrice = 2571;
			AvailableClasses = 0x7FFF;
			Model = 27722;
			ObjectClass = 4;
			SubClass = 2;
			Level = 39;
			ReqLevel = 34;
			Name = "Nocturnal Gloves";
			Name2 = "Nocturnal Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 736;
			BuyPrice = 12856;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Imposing Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class ImposingGloves : Item
	{
		public ImposingGloves() : base()
		{
			Id = 15166;
			Resistance[0] = 76;
			Bonding = 2;
			SellPrice = 3945;
			AvailableClasses = 0x7FFF;
			Model = 27921;
			ObjectClass = 4;
			SubClass = 2;
			Level = 45;
			ReqLevel = 40;
			Name = "Imposing Gloves";
			Name2 = "Imposing Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 738;
			BuyPrice = 19728;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Potent Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class PotentGloves : Item
	{
		public PotentGloves() : base()
		{
			Id = 15174;
			Resistance[0] = 83;
			Bonding = 2;
			SellPrice = 6017;
			AvailableClasses = 0x7FFF;
			Model = 27591;
			ObjectClass = 4;
			SubClass = 2;
			Level = 50;
			ReqLevel = 45;
			Name = "Potent Gloves";
			Name2 = "Potent Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 740;
			BuyPrice = 30087;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Praetorian Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class PraetorianGloves : Item
	{
		public PraetorianGloves() : base()
		{
			Id = 15184;
			Resistance[0] = 88;
			Bonding = 2;
			SellPrice = 7197;
			AvailableClasses = 0x7FFF;
			Model = 27661;
			ObjectClass = 4;
			SubClass = 2;
			Level = 54;
			ReqLevel = 49;
			Name = "Praetorian Gloves";
			Name2 = "Praetorian Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 741;
			BuyPrice = 35986;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Grand Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class GrandGauntlets : Item
	{
		public GrandGauntlets() : base()
		{
			Id = 15192;
			Resistance[0] = 96;
			Bonding = 2;
			SellPrice = 10595;
			AvailableClasses = 0x7FFF;
			Model = 27635;
			ObjectClass = 4;
			SubClass = 2;
			Level = 60;
			ReqLevel = 55;
			Name = "Grand Gauntlets";
			Name2 = "Grand Gauntlets";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 743;
			BuyPrice = 52979;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Grizzly Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class GrizzlyGloves : Item
	{
		public GrizzlyGloves() : base()
		{
			Id = 15300;
			Resistance[0] = 41;
			SellPrice = 86;
			AvailableClasses = 0x7FFF;
			Model = 12415;
			ObjectClass = 4;
			SubClass = 2;
			Level = 14;
			ReqLevel = 9;
			Name = "Grizzly Gloves";
			Name2 = "Grizzly Gloves";
			Quality = 1;
			AvailableRaces = 0x1FF;
			BuyPrice = 432;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Feral Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class FeralGloves : Item
	{
		public FeralGloves() : base()
		{
			Id = 15310;
			Resistance[0] = 46;
			Bonding = 2;
			SellPrice = 279;
			AvailableClasses = 0x7FFF;
			Model = 28046;
			ObjectClass = 4;
			SubClass = 2;
			Level = 18;
			ReqLevel = 13;
			Name = "Feral Gloves";
			Name2 = "Feral Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 729;
			BuyPrice = 1398;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 20;
		}
	}
}


/**************************************************************
*
*				(Wrangler's Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class WranglersGloves : Item
	{
		public WranglersGloves() : base()
		{
			Id = 15334;
			Resistance[0] = 55;
			Bonding = 2;
			SellPrice = 828;
			AvailableClasses = 0x7FFF;
			Model = 28005;
			ObjectClass = 4;
			SubClass = 2;
			Level = 27;
			ReqLevel = 22;
			Name = "Wrangler's Gloves";
			Name2 = "Wrangler's Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 732;
			BuyPrice = 4141;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Pathfinder Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class PathfinderGloves : Item
	{
		public PathfinderGloves() : base()
		{
			Id = 15343;
			Resistance[0] = 58;
			Bonding = 2;
			SellPrice = 1139;
			AvailableClasses = 0x7FFF;
			Model = 27677;
			ObjectClass = 4;
			SubClass = 2;
			Level = 30;
			ReqLevel = 25;
			Name = "Pathfinder Gloves";
			Name2 = "Pathfinder Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 733;
			BuyPrice = 5698;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Headhunter's Mitts)
*
***************************************************************/

namespace Server.Items
{
	public class HeadhuntersMitts : Item
	{
		public HeadhuntersMitts() : base()
		{
			Id = 15355;
			Resistance[0] = 62;
			Bonding = 2;
			SellPrice = 1620;
			AvailableClasses = 0x7FFF;
			Model = 27701;
			ObjectClass = 4;
			SubClass = 2;
			Level = 34;
			ReqLevel = 29;
			Name = "Headhunter's Mitts";
			Name2 = "Headhunter's Mitts";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 735;
			BuyPrice = 8100;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Trickster's Handwraps)
*
***************************************************************/

namespace Server.Items
{
	public class TrickstersHandwraps : Item
	{
		public TrickstersHandwraps() : base()
		{
			Id = 15365;
			Resistance[0] = 66;
			Bonding = 2;
			SellPrice = 2415;
			AvailableClasses = 0x7FFF;
			Model = 27955;
			ObjectClass = 4;
			SubClass = 2;
			Level = 38;
			ReqLevel = 33;
			Name = "Trickster's Handwraps";
			Name2 = "Trickster's Handwraps";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 736;
			BuyPrice = 12078;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Wolf Rider's Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class WolfRidersGloves : Item
	{
		public WolfRidersGloves() : base()
		{
			Id = 15372;
			Resistance[0] = 73;
			Bonding = 2;
			SellPrice = 3383;
			AvailableClasses = 0x7FFF;
			Model = 27970;
			ObjectClass = 4;
			SubClass = 2;
			Level = 43;
			ReqLevel = 38;
			Name = "Wolf Rider's Gloves";
			Name2 = "Wolf Rider's Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 738;
			BuyPrice = 16917;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Rageclaw Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class RageclawGloves : Item
	{
		public RageclawGloves() : base()
		{
			Id = 15383;
			Resistance[0] = 80;
			Bonding = 2;
			SellPrice = 5313;
			AvailableClasses = 0x7FFF;
			Model = 15415;
			ObjectClass = 4;
			SubClass = 2;
			Level = 48;
			ReqLevel = 43;
			Name = "Rageclaw Gloves";
			Name2 = "Rageclaw Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 739;
			BuyPrice = 26565;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Jadefire Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class JadefireGloves : Item
	{
		public JadefireGloves() : base()
		{
			Id = 15393;
			Resistance[0] = 86;
			Bonding = 2;
			SellPrice = 6479;
			AvailableClasses = 0x7FFF;
			Model = 27657;
			ObjectClass = 4;
			SubClass = 2;
			Level = 52;
			ReqLevel = 47;
			Name = "Jadefire Gloves";
			Name2 = "Jadefire Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 741;
			BuyPrice = 32395;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Shucking Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class ShuckingGloves : Item
	{
		public ShuckingGloves() : base()
		{
			Id = 15405;
			Resistance[0] = 45;
			Bonding = 1;
			SellPrice = 245;
			AvailableClasses = 0x7FFF;
			Model = 9529;
			ObjectClass = 4;
			SubClass = 2;
			Level = 17;
			Name = "Shucking Gloves";
			Name2 = "Shucking Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 1225;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 20;
			StaminaBonus = 2;
			SpiritBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Peerless Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class PeerlessGloves : Item
	{
		public PeerlessGloves() : base()
		{
			Id = 15429;
			Resistance[0] = 94;
			Bonding = 2;
			SellPrice = 9049;
			AvailableClasses = 0x7FFF;
			Model = 28034;
			ObjectClass = 4;
			SubClass = 2;
			Level = 58;
			ReqLevel = 53;
			Name = "Peerless Gloves";
			Name2 = "Peerless Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 743;
			BuyPrice = 45248;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Supreme Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class SupremeGloves : Item
	{
		public SupremeGloves() : base()
		{
			Id = 15438;
			Resistance[0] = 100;
			Bonding = 2;
			SellPrice = 12264;
			AvailableClasses = 0x7FFF;
			Model = 29013;
			ObjectClass = 4;
			SubClass = 2;
			Level = 63;
			ReqLevel = 58;
			Name = "Supreme Gloves";
			Name2 = "Supreme Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			Extra = 744;
			BuyPrice = 61324;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
		}
	}
}


/**************************************************************
*
*				(Blight Leather Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class BlightLeatherGloves : Item
	{
		public BlightLeatherGloves() : base()
		{
			Id = 15708;
			Resistance[0] = 94;
			Bonding = 1;
			SellPrice = 8965;
			AvailableClasses = 0x7FFF;
			Model = 26436;
			ObjectClass = 4;
			SubClass = 2;
			Level = 58;
			Name = "Blight Leather Gloves";
			Name2 = "Blight Leather Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 44825;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			AgilityBonus = 13;
			StrBonus = 8;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Knight-Lieutenant's Leather Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class KnightLieutenantsLeatherGauntlets : Item
	{
		public KnightLieutenantsLeatherGauntlets() : base()
		{
			Id = 16396;
			Resistance[0] = 110;
			Bonding = 1;
			SellPrice = 7388;
			AvailableClasses = 0x08;
			Model = 31075;
			ObjectClass = 4;
			SubClass = 2;
			Level = 63;
			ReqLevel = 58;
			Name = "Knight-Lieutenant's Leather Gauntlets";
			Name2 = "Knight-Lieutenant's Leather Gauntlets";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 36942;
			Sets = 348;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			MaxCount = 1;
			Material = 8;
			Durability = 35;
			Flags = 32768;
			SetSpell( 15807 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 15;
			AgilityBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Knight-Lieutenant's Dragonhide Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class KnightLieutenantsDragonhideGloves : Item
	{
		public KnightLieutenantsDragonhideGloves() : base()
		{
			Id = 16397;
			Resistance[0] = 110;
			Bonding = 1;
			SellPrice = 7414;
			AvailableClasses = 0x400;
			Model = 31071;
			ObjectClass = 4;
			SubClass = 2;
			Level = 63;
			ReqLevel = 58;
			Name = "Knight-Lieutenant's Dragonhide Gloves";
			Name2 = "Knight-Lieutenant's Dragonhide Gloves";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 37072;
			Sets = 381;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			MaxCount = 1;
			Material = 8;
			Durability = 35;
			Flags = 32768;
			SetSpell( 23217 , 1 , 0 , -1 , 0 , -1 );
			StrBonus = 12;
			AgilityBonus = 12;
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Marshal's Dragonhide Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class MarshalsDragonhideGauntlets : Item
	{
		public MarshalsDragonhideGauntlets() : base()
		{
			Id = 16448;
			Resistance[0] = 123;
			Bonding = 1;
			SellPrice = 10545;
			AvailableClasses = 0x400;
			Model = 30334;
			ObjectClass = 4;
			SubClass = 2;
			Level = 65;
			ReqLevel = 60;
			Name = "Marshal's Dragonhide Gauntlets";
			Name2 = "Marshal's Dragonhide Gauntlets";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 52729;
			Sets = 397;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			MaxCount = 1;
			Material = 8;
			Durability = 40;
			Flags = 32768;
			SetSpell( 23217 , 1 , 0 , -1 , 0 , -1 );
			StrBonus = 18;
			AgilityBonus = 17;
			StaminaBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Marshal's Leather Handgrips)
*
***************************************************************/

namespace Server.Items
{
	public class MarshalsLeatherHandgrips : Item
	{
		public MarshalsLeatherHandgrips() : base()
		{
			Id = 16454;
			Resistance[0] = 123;
			Bonding = 1;
			SellPrice = 10778;
			AvailableClasses = 0x08;
			Model = 30334;
			ObjectClass = 4;
			SubClass = 2;
			Level = 65;
			ReqLevel = 60;
			Name = "Marshal's Leather Handgrips";
			Name2 = "Marshal's Leather Handgrips";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 53893;
			Sets = 394;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			MaxCount = 1;
			Material = 8;
			Durability = 40;
			Flags = 32768;
			SetSpell( 14049 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 18;
			AgilityBonus = 14;
		}
	}
}


/**************************************************************
*
*				(Blood Guard's Dragonhide Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class BloodGuardsDragonhideGauntlets : Item
	{
		public BloodGuardsDragonhideGauntlets() : base()
		{
			Id = 16496;
			Resistance[0] = 110;
			Bonding = 1;
			SellPrice = 6853;
			AvailableClasses = 0x400;
			Model = 27265;
			ObjectClass = 4;
			SubClass = 2;
			Level = 63;
			ReqLevel = 58;
			Name = "Blood Guard's Dragonhide Gauntlets";
			Name2 = "Blood Guard's Dragonhide Gauntlets";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 34268;
			Sets = 382;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			MaxCount = 1;
			Material = 8;
			Durability = 35;
			Flags = 32768;
			SetSpell( 23217 , 1 , 0 , -1 , 0 , -1 );
			StrBonus = 12;
			AgilityBonus = 12;
			StaminaBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Blood Guard's Leather Vices)
*
***************************************************************/

namespace Server.Items
{
	public class BloodGuardsLeatherVices : Item
	{
		public BloodGuardsLeatherVices() : base()
		{
			Id = 16499;
			Resistance[0] = 110;
			Bonding = 1;
			SellPrice = 6932;
			AvailableClasses = 0x08;
			Model = 31036;
			ObjectClass = 4;
			SubClass = 2;
			Level = 63;
			ReqLevel = 58;
			Name = "Blood Guard's Leather Vices";
			Name2 = "Blood Guard's Leather Vices";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 34664;
			Sets = 347;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			MaxCount = 1;
			Material = 8;
			Durability = 35;
			Flags = 32768;
			SetSpell( 15807 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 15;
			AgilityBonus = 10;
		}
	}
}


/**************************************************************
*
*				(General's Dragonhide Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class GeneralsDragonhideGloves : Item
	{
		public GeneralsDragonhideGloves() : base()
		{
			Id = 16555;
			Resistance[0] = 123;
			Bonding = 1;
			SellPrice = 10312;
			AvailableClasses = 0x400;
			Model = 32107;
			ObjectClass = 4;
			SubClass = 2;
			Level = 65;
			ReqLevel = 60;
			Name = "General's Dragonhide Gloves";
			Name2 = "General's Dragonhide Gloves";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 51560;
			Sets = 398;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			MaxCount = 1;
			Material = 8;
			Durability = 40;
			Flags = 32768;
			SetSpell( 23217 , 1 , 0 , -1 , 0 , -1 );
			StrBonus = 18;
			AgilityBonus = 17;
			StaminaBonus = 15;
		}
	}
}


/**************************************************************
*
*				(General's Leather Mitts)
*
***************************************************************/

namespace Server.Items
{
	public class GeneralsLeatherMitts : Item
	{
		public GeneralsLeatherMitts() : base()
		{
			Id = 16560;
			Resistance[0] = 123;
			Bonding = 1;
			SellPrice = 10506;
			AvailableClasses = 0x08;
			Model = 32113;
			ObjectClass = 4;
			SubClass = 2;
			Level = 65;
			ReqLevel = 60;
			Name = "General's Leather Mitts";
			Name2 = "General's Leather Mitts";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 52533;
			Sets = 393;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			MaxCount = 1;
			Material = 8;
			Durability = 40;
			Flags = 32768;
			SetSpell( 14049 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 18;
			AgilityBonus = 14;
		}
	}
}


/**************************************************************
*
*				(Shadowcraft Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class ShadowcraftGloves : Item
	{
		public ShadowcraftGloves() : base()
		{
			Id = 16712;
			Resistance[0] = 105;
			Bonding = 1;
			SellPrice = 11714;
			AvailableClasses = 0x7FFF;
			Model = 28166;
			ObjectClass = 4;
			SubClass = 2;
			Level = 59;
			ReqLevel = 54;
			Name = "Shadowcraft Gloves";
			Name2 = "Shadowcraft Gloves";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 58570;
			Sets = 184;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			AgilityBonus = 14;
			IqBonus = 10;
			StaminaBonus = 9;
			StrBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Wildheart Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class WildheartGloves : Item
	{
		public WildheartGloves() : base()
		{
			Id = 16717;
			Resistance[0] = 105;
			Bonding = 2;
			SellPrice = 12244;
			AvailableClasses = 0x7FFF;
			Model = 29979;
			ObjectClass = 4;
			SubClass = 2;
			Level = 59;
			ReqLevel = 54;
			Name = "Wildheart Gloves";
			Name2 = "Wildheart Gloves";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 61223;
			Sets = 185;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			IqBonus = 21;
			SpiritBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Oilrag Handwraps)
*
***************************************************************/

namespace Server.Items
{
	public class OilragHandwraps : Item
	{
		public OilragHandwraps() : base()
		{
			Id = 16741;
			Resistance[0] = 59;
			Bonding = 1;
			SellPrice = 1178;
			AvailableClasses = 0x7FFF;
			Model = 27913;
			ObjectClass = 4;
			SubClass = 2;
			Level = 31;
			Name = "Oilrag Handwraps";
			Name2 = "Oilrag Handwraps";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 5890;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			IqBonus = 8;
			SpiritBonus = 2;
			StaminaBonus = 2;
		}
	}
}


/**************************************************************
*
*				(Nightslayer Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class NightslayerGloves : Item
	{
		public NightslayerGloves() : base()
		{
			Id = 16826;
			Resistance[0] = 125;
			Bonding = 1;
			SellPrice = 22057;
			AvailableClasses = 0x08;
			Model = 31503;
			Resistance[2] = 7;
			ObjectClass = 4;
			SubClass = 2;
			Level = 66;
			ReqLevel = 60;
			Name = "Nightslayer Gloves";
			Name2 = "Nightslayer Gloves";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 110287;
			Sets = 204;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 40;
			SetSpell( 15464 , 1 , 0 , -1 , 0 , -1 );
			AgilityBonus = 18;
			StaminaBonus = 17;
			StrBonus = 12;
		}
	}
}


/**************************************************************
*
*				(Cenarion Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class CenarionGloves : Item
	{
		public CenarionGloves() : base()
		{
			Id = 16831;
			Resistance[0] = 125;
			Bonding = 1;
			SellPrice = 23055;
			AvailableClasses = 0x400;
			Model = 31726;
			Resistance[2] = 7;
			ObjectClass = 4;
			SubClass = 2;
			Level = 66;
			ReqLevel = 60;
			Name = "Cenarion Gloves";
			Name2 = "Cenarion Gloves";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 115275;
			Sets = 205;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 40;
			SetSpell( 9406 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 18;
			IqBonus = 15;
			StaminaBonus = 17;
		}
	}
}


/**************************************************************
*
*				(Braidfur Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class BraidfurGloves : Item
	{
		public BraidfurGloves() : base()
		{
			Id = 16873;
			Resistance[0] = 66;
			Bonding = 1;
			SellPrice = 2254;
			AvailableClasses = 0x7FFF;
			Model = 28522;
			ObjectClass = 4;
			SubClass = 2;
			Level = 38;
			Name = "Braidfur Gloves";
			Name2 = "Braidfur Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11271;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			SpiritBonus = 7;
			StaminaBonus = 5;
			IqBonus = 4;
		}
	}
}


/**************************************************************
*
*				(Stormrage Handguards)
*
***************************************************************/

namespace Server.Items
{
	public class StormrageHandguards : Item
	{
		public StormrageHandguards() : base()
		{
			Id = 16899;
			Resistance[0] = 140;
			Bonding = 1;
			SellPrice = 35940;
			AvailableClasses = 0x400;
			Model = 29776;
			ObjectClass = 4;
			SubClass = 2;
			Level = 76;
			ReqLevel = 60;
			Name = "Stormrage Handguards";
			Name2 = "Stormrage Handguards";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 179700;
			Sets = 214;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 40;
			SetSpell( 7694 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 9318 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 13;
			IqBonus = 25;
			StaminaBonus = 8;
			StrBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Bloodfang Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class BloodfangGloves : Item
	{
		public BloodfangGloves() : base()
		{
			Id = 16907;
			Resistance[0] = 140;
			Bonding = 1;
			SellPrice = 37004;
			AvailableClasses = 0x08;
			Model = 29749;
			ObjectClass = 4;
			SubClass = 2;
			Level = 76;
			ReqLevel = 60;
			Name = "Bloodfang Gloves";
			Name2 = "Bloodfang Gloves";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 185021;
			Sets = 213;
			Resistance[5] = 10;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 40;
			SetSpell( 7219 , 1 , 0 , -1 , 0 , -1 );
			AgilityBonus = 20;
			StaminaBonus = 20;
			StrBonus = 19;
		}
	}
}


/**************************************************************
*
*				(Duskwing Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class DuskwingGloves : Item
	{
		public DuskwingGloves() : base()
		{
			Id = 16994;
			Resistance[0] = 96;
			Bonding = 1;
			SellPrice = 9884;
			AvailableClasses = 0x7FFF;
			Model = 28822;
			ObjectClass = 4;
			SubClass = 2;
			Level = 60;
			Name = "Duskwing Gloves";
			Name2 = "Duskwing Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 49420;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			SpiritBonus = 14;
			StaminaBonus = 11;
			IqBonus = 5;
		}
	}
}


/**************************************************************
*
*				(Gloves of the Greatfather)
*
***************************************************************/

namespace Server.Items
{
	public class GlovesOfTheGreatfather : Item
	{
		public GlovesOfTheGreatfather() : base()
		{
			Id = 17721;
			Resistance[0] = 66;
			Bonding = 2;
			SellPrice = 2268;
			AvailableClasses = 0x7FFF;
			Model = 29898;
			ObjectClass = 4;
			SubClass = 2;
			Level = 38;
			ReqLevel = 33;
			Name = "Gloves of the Greatfather";
			Name2 = "Gloves of the Greatfather";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 11340;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			SetSpell( 9406 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 7696 , 1 , 0 , -1 , 0 , -1 );
		}
	}
}


/**************************************************************
*
*				(Shadowskin Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class ShadowskinGloves : Item
	{
		public ShadowskinGloves() : base()
		{
			Id = 18238;
			Resistance[0] = 76;
			Bonding = 2;
			SellPrice = 3321;
			AvailableClasses = 0x7FFF;
			Model = 15753;
			ObjectClass = 4;
			SubClass = 2;
			Level = 40;
			ReqLevel = 35;
			Name = "Shadowskin Gloves";
			Name2 = "Shadowskin Gloves";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 16608;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 6;
		}
	}
}


/**************************************************************
*
*				(Gloves of Restoration)
*
***************************************************************/

namespace Server.Items
{
	public class GlovesOfRestoration : Item
	{
		public GlovesOfRestoration() : base()
		{
			Id = 18309;
			Resistance[0] = 105;
			Bonding = 1;
			SellPrice = 11296;
			AvailableClasses = 0x7FFF;
			Model = 30672;
			ObjectClass = 4;
			SubClass = 2;
			Level = 59;
			ReqLevel = 54;
			Name = "Gloves of Restoration";
			Name2 = "Gloves of Restoration";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 56480;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			SetSpell( 18030 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 10;
			SpiritBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Stonebark Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class StonebarkGauntlets : Item
	{
		public StonebarkGauntlets() : base()
		{
			Id = 18344;
			Resistance[0] = 105;
			Bonding = 1;
			SellPrice = 11296;
			AvailableClasses = 0x7FFF;
			Model = 25706;
			ObjectClass = 4;
			SubClass = 2;
			Level = 59;
			ReqLevel = 54;
			Name = "Stonebark Gauntlets";
			Name2 = "Stonebark Gauntlets";
			Resistance[3] = 16;
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 56480;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			AgilityBonus = 10;
			StaminaBonus = 10;
		}
	}
}


/**************************************************************
*
*				(Gordok's Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class GordoksGloves : Item
	{
		public GordoksGloves() : base()
		{
			Id = 18368;
			Resistance[0] = 106;
			Bonding = 1;
			SellPrice = 12348;
			AvailableClasses = 0x7FFF;
			Model = 30719;
			ObjectClass = 4;
			SubClass = 2;
			Level = 60;
			Name = "Gordok's Gloves";
			Name2 = "Gordok's Gloves";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 61742;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			SetSpell( 18384 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 10;
			SpiritBonus = 10;
			IqBonus = 9;
		}
	}
}


/**************************************************************
*
*				(Quickdraw Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class QuickdrawGloves : Item
	{
		public QuickdrawGloves() : base()
		{
			Id = 18377;
			Resistance[0] = 109;
			Bonding = 1;
			SellPrice = 13076;
			AvailableClasses = 0x7FFF;
			Model = 30729;
			ObjectClass = 4;
			SubClass = 2;
			Level = 62;
			ReqLevel = 57;
			Name = "Quickdraw Gloves";
			Name2 = "Quickdraw Gloves";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 65383;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			SetSpell( 13669 , 1 , 0 , -1 , 0 , -1 );
			AgilityBonus = 8;
			StrBonus = 7;
			StaminaBonus = 7;
		}
	}
}


/**************************************************************
*
*				(Doomhide Gauntlets)
*
***************************************************************/

namespace Server.Items
{
	public class DoomhideGauntlets : Item
	{
		public DoomhideGauntlets() : base()
		{
			Id = 18544;
			Resistance[0] = 133;
			Bonding = 1;
			SellPrice = 29212;
			AvailableClasses = 0x7FFF;
			Model = 30893;
			Resistance[2] = 8;
			ObjectClass = 4;
			SubClass = 2;
			Level = 71;
			ReqLevel = 60;
			Name = "Doomhide Gauntlets";
			Name2 = "Doomhide Gauntlets";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 146060;
			Resistance[5] = 8;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 40;
			SetSpell( 15809 , 1 , 0 , -1 , 0 , -1 );
			StaminaBonus = 14;
			AgilityBonus = 14;
		}
	}
}


/**************************************************************
*
*				(Plaguebat Fur Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class PlaguebatFurGloves : Item
	{
		public PlaguebatFurGloves() : base()
		{
			Id = 18744;
			Resistance[0] = 103;
			Bonding = 1;
			SellPrice = 11371;
			AvailableClasses = 0x7FFF;
			Model = 31196;
			ObjectClass = 4;
			SubClass = 2;
			Level = 58;
			ReqLevel = 53;
			Name = "Plaguebat Fur Gloves";
			Name2 = "Plaguebat Fur Gloves";
			Quality = 3;
			AvailableRaces = 0x1FF;
			BuyPrice = 56859;
			Resistance[5] = 10;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 35;
			StaminaBonus = 14;
			AgilityBonus = 13;
		}
	}
}


/**************************************************************
*
*				(Aged Core Leather Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class AgedCoreLeatherGloves : Item
	{
		public AgedCoreLeatherGloves() : base()
		{
			Id = 18823;
			Resistance[0] = 130;
			Bonding = 1;
			SellPrice = 26506;
			AvailableClasses = 0x7FFF;
			Model = 31290;
			Resistance[2] = 8;
			ObjectClass = 4;
			SubClass = 2;
			Level = 69;
			ReqLevel = 60;
			Name = "Aged Core Leather Gloves";
			Name2 = "Aged Core Leather Gloves";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 132532;
			Resistance[5] = 5;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 40;
			SetSpell( 7597 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 7576 , 1 , 0 , -1 , 0 , -1 );
			StrBonus = 15;
			StaminaBonus = 15;
		}
	}
}


/**************************************************************
*
*				(Owlbeast Hide Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class OwlbeastHideGloves : Item
	{
		public OwlbeastHideGloves() : base()
		{
			Id = 19119;
			Resistance[0] = 83;
			Bonding = 1;
			SellPrice = 5803;
			AvailableClasses = 0x7FFF;
			Model = 31630;
			ObjectClass = 4;
			SubClass = 2;
			Level = 50;
			Name = "Owlbeast Hide Gloves";
			Name2 = "Owlbeast Hide Gloves";
			Quality = 2;
			AvailableRaces = 0x1FF;
			BuyPrice = 29015;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			Material = 8;
			Durability = 30;
			SpiritBonus = 9;
			IqBonus = 8;
			StaminaBonus = 8;
		}
	}
}


/**************************************************************
*
*				(Taut Dragonhide Gloves)
*
***************************************************************/

namespace Server.Items
{
	public class TautDragonhideGloves : Item
	{
		public TautDragonhideGloves() : base()
		{
			Id = 19390;
			Resistance[0] = 142;
			Bonding = 1;
			SellPrice = 39443;
			AvailableClasses = 0x7FFF;
			Model = 31919;
			ObjectClass = 4;
			SubClass = 2;
			Level = 77;
			ReqLevel = 60;
			Name = "Taut Dragonhide Gloves";
			Name2 = "Taut Dragonhide Gloves";
			Quality = 4;
			AvailableRaces = 0x1FF;
			BuyPrice = 197217;
			InventoryType = InventoryTypes.Hands;
			Stackable = 1;
			SetSpell( 18384 , 1 , 0 , -1 , 0 , -1 );
			SetSpell( 21627 , 1 , 0 , -1 , 0 , -1 );
			SpiritBonus = 20;
			StaminaBonus = 20;
		}
	}
}


